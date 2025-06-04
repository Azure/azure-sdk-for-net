namespace Azure.ResourceManager.ApiCenter
{
    public static partial class ApiCenterExtensions
    {
        public static Azure.ResourceManager.ApiCenter.ApiDefinitionEntityResource GetApiDefinitionEntityResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.ApiCenter.ApiDeploymentEntityResource GetApiDeploymentEntityResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.ApiCenter.ApiEntityResource GetApiEntityResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.ApiCenter.ApiVersionEntityResource GetApiVersionEntityResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.ApiCenter.EnvironmentEntityResource GetEnvironmentEntityResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.ApiCenter.MetadataSchemaEntityResource GetMetadataSchemaEntityResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.ApiCenter.ServiceEntityCollection GetServiceEntities(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.ApiCenter.ServiceEntityResource> GetServiceEntities(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.ApiCenter.ServiceEntityResource> GetServiceEntitiesAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.ApiCenter.ServiceEntityResource> GetServiceEntity(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string serviceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiCenter.ServiceEntityResource>> GetServiceEntityAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string serviceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.ApiCenter.ServiceEntityResource GetServiceEntityResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.ApiCenter.WorkspaceEntityResource GetWorkspaceEntityResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class ApiDefinitionEntityCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ApiCenter.ApiDefinitionEntityResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ApiCenter.ApiDefinitionEntityResource>, System.Collections.IEnumerable
    {
        protected ApiDefinitionEntityCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ApiCenter.ApiDefinitionEntityResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string definitionName, Azure.ResourceManager.ApiCenter.ApiDefinitionEntityData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ApiCenter.ApiDefinitionEntityResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string definitionName, Azure.ResourceManager.ApiCenter.ApiDefinitionEntityData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string definitionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string definitionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiCenter.ApiDefinitionEntityResource> Get(string definitionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ApiCenter.ApiDefinitionEntityResource> GetAll(string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ApiCenter.ApiDefinitionEntityResource> GetAllAsync(string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiCenter.ApiDefinitionEntityResource>> GetAsync(string definitionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.ApiCenter.ApiDefinitionEntityResource> GetIfExists(string definitionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.ApiCenter.ApiDefinitionEntityResource>> GetIfExistsAsync(string definitionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ApiCenter.ApiDefinitionEntityResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ApiCenter.ApiDefinitionEntityResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ApiCenter.ApiDefinitionEntityResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ApiCenter.ApiDefinitionEntityResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ApiDefinitionEntityData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ApiCenter.ApiDefinitionEntityData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApiCenter.ApiDefinitionEntityData>
    {
        public ApiDefinitionEntityData() { }
        public Azure.ResourceManager.ApiCenter.Models.ApiDefinitionEntityProperties Properties { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ApiCenter.ApiDefinitionEntityData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ApiCenter.ApiDefinitionEntityData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ApiCenter.ApiDefinitionEntityData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ApiCenter.ApiDefinitionEntityData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApiCenter.ApiDefinitionEntityData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApiCenter.ApiDefinitionEntityData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApiCenter.ApiDefinitionEntityData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ApiDefinitionEntityResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ApiCenter.ApiDefinitionEntityData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApiCenter.ApiDefinitionEntityData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ApiDefinitionEntityResource() { }
        public virtual Azure.ResourceManager.ApiCenter.ApiDefinitionEntityData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string serviceName, string workspaceName, string apiName, string versionName, string definitionName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ApiCenter.Models.ApiSpecExportResult> ExportSpecification(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ApiCenter.Models.ApiSpecExportResult>> ExportSpecificationAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiCenter.ApiDefinitionEntityResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiCenter.ApiDefinitionEntityResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Head(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> HeadAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation ImportSpecification(Azure.WaitUntil waitUntil, Azure.ResourceManager.ApiCenter.Models.ApiSpecImportContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> ImportSpecificationAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.ApiCenter.Models.ApiSpecImportContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.ApiCenter.ApiDefinitionEntityData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ApiCenter.ApiDefinitionEntityData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ApiCenter.ApiDefinitionEntityData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ApiCenter.ApiDefinitionEntityData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApiCenter.ApiDefinitionEntityData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApiCenter.ApiDefinitionEntityData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApiCenter.ApiDefinitionEntityData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ApiCenter.ApiDefinitionEntityResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.ApiCenter.ApiDefinitionEntityData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ApiCenter.ApiDefinitionEntityResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.ApiCenter.ApiDefinitionEntityData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ApiDeploymentEntityCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ApiCenter.ApiDeploymentEntityResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ApiCenter.ApiDeploymentEntityResource>, System.Collections.IEnumerable
    {
        protected ApiDeploymentEntityCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ApiCenter.ApiDeploymentEntityResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string deploymentName, Azure.ResourceManager.ApiCenter.ApiDeploymentEntityData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ApiCenter.ApiDeploymentEntityResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string deploymentName, Azure.ResourceManager.ApiCenter.ApiDeploymentEntityData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string deploymentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string deploymentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiCenter.ApiDeploymentEntityResource> Get(string deploymentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ApiCenter.ApiDeploymentEntityResource> GetAll(string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ApiCenter.ApiDeploymentEntityResource> GetAllAsync(string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiCenter.ApiDeploymentEntityResource>> GetAsync(string deploymentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.ApiCenter.ApiDeploymentEntityResource> GetIfExists(string deploymentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.ApiCenter.ApiDeploymentEntityResource>> GetIfExistsAsync(string deploymentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ApiCenter.ApiDeploymentEntityResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ApiCenter.ApiDeploymentEntityResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ApiCenter.ApiDeploymentEntityResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ApiCenter.ApiDeploymentEntityResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ApiDeploymentEntityData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ApiCenter.ApiDeploymentEntityData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApiCenter.ApiDeploymentEntityData>
    {
        public ApiDeploymentEntityData() { }
        public Azure.ResourceManager.ApiCenter.Models.ApiDeploymentEntityProperties Properties { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ApiCenter.ApiDeploymentEntityData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ApiCenter.ApiDeploymentEntityData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ApiCenter.ApiDeploymentEntityData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ApiCenter.ApiDeploymentEntityData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApiCenter.ApiDeploymentEntityData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApiCenter.ApiDeploymentEntityData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApiCenter.ApiDeploymentEntityData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ApiDeploymentEntityResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ApiCenter.ApiDeploymentEntityData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApiCenter.ApiDeploymentEntityData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ApiDeploymentEntityResource() { }
        public virtual Azure.ResourceManager.ApiCenter.ApiDeploymentEntityData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string serviceName, string workspaceName, string apiName, string deploymentName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiCenter.ApiDeploymentEntityResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiCenter.ApiDeploymentEntityResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Head(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> HeadAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.ApiCenter.ApiDeploymentEntityData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ApiCenter.ApiDeploymentEntityData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ApiCenter.ApiDeploymentEntityData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ApiCenter.ApiDeploymentEntityData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApiCenter.ApiDeploymentEntityData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApiCenter.ApiDeploymentEntityData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApiCenter.ApiDeploymentEntityData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ApiCenter.ApiDeploymentEntityResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.ApiCenter.ApiDeploymentEntityData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ApiCenter.ApiDeploymentEntityResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.ApiCenter.ApiDeploymentEntityData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ApiEntityCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ApiCenter.ApiEntityResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ApiCenter.ApiEntityResource>, System.Collections.IEnumerable
    {
        protected ApiEntityCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ApiCenter.ApiEntityResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string apiName, Azure.ResourceManager.ApiCenter.ApiEntityData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ApiCenter.ApiEntityResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string apiName, Azure.ResourceManager.ApiCenter.ApiEntityData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string apiName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string apiName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiCenter.ApiEntityResource> Get(string apiName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ApiCenter.ApiEntityResource> GetAll(string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ApiCenter.ApiEntityResource> GetAllAsync(string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiCenter.ApiEntityResource>> GetAsync(string apiName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.ApiCenter.ApiEntityResource> GetIfExists(string apiName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.ApiCenter.ApiEntityResource>> GetIfExistsAsync(string apiName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ApiCenter.ApiEntityResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ApiCenter.ApiEntityResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ApiCenter.ApiEntityResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ApiCenter.ApiEntityResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ApiEntityData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ApiCenter.ApiEntityData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApiCenter.ApiEntityData>
    {
        public ApiEntityData() { }
        public Azure.ResourceManager.ApiCenter.Models.ApiEntityProperties Properties { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ApiCenter.ApiEntityData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ApiCenter.ApiEntityData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ApiCenter.ApiEntityData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ApiCenter.ApiEntityData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApiCenter.ApiEntityData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApiCenter.ApiEntityData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApiCenter.ApiEntityData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ApiEntityResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ApiCenter.ApiEntityData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApiCenter.ApiEntityData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ApiEntityResource() { }
        public virtual Azure.ResourceManager.ApiCenter.ApiEntityData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string serviceName, string workspaceName, string apiName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiCenter.ApiEntityResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ApiCenter.ApiDeploymentEntityCollection GetApiDeploymentEntities() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiCenter.ApiDeploymentEntityResource> GetApiDeploymentEntity(string deploymentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiCenter.ApiDeploymentEntityResource>> GetApiDeploymentEntityAsync(string deploymentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ApiCenter.ApiVersionEntityCollection GetApiVersionEntities() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiCenter.ApiVersionEntityResource> GetApiVersionEntity(string versionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiCenter.ApiVersionEntityResource>> GetApiVersionEntityAsync(string versionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiCenter.ApiEntityResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Head(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> HeadAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.ApiCenter.ApiEntityData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ApiCenter.ApiEntityData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ApiCenter.ApiEntityData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ApiCenter.ApiEntityData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApiCenter.ApiEntityData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApiCenter.ApiEntityData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApiCenter.ApiEntityData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ApiCenter.ApiEntityResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.ApiCenter.ApiEntityData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ApiCenter.ApiEntityResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.ApiCenter.ApiEntityData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ApiVersionEntityCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ApiCenter.ApiVersionEntityResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ApiCenter.ApiVersionEntityResource>, System.Collections.IEnumerable
    {
        protected ApiVersionEntityCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ApiCenter.ApiVersionEntityResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string versionName, Azure.ResourceManager.ApiCenter.ApiVersionEntityData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ApiCenter.ApiVersionEntityResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string versionName, Azure.ResourceManager.ApiCenter.ApiVersionEntityData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string versionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string versionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiCenter.ApiVersionEntityResource> Get(string versionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ApiCenter.ApiVersionEntityResource> GetAll(string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ApiCenter.ApiVersionEntityResource> GetAllAsync(string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiCenter.ApiVersionEntityResource>> GetAsync(string versionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.ApiCenter.ApiVersionEntityResource> GetIfExists(string versionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.ApiCenter.ApiVersionEntityResource>> GetIfExistsAsync(string versionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ApiCenter.ApiVersionEntityResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ApiCenter.ApiVersionEntityResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ApiCenter.ApiVersionEntityResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ApiCenter.ApiVersionEntityResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ApiVersionEntityData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ApiCenter.ApiVersionEntityData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApiCenter.ApiVersionEntityData>
    {
        public ApiVersionEntityData() { }
        public Azure.ResourceManager.ApiCenter.Models.ApiVersionEntityProperties Properties { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ApiCenter.ApiVersionEntityData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ApiCenter.ApiVersionEntityData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ApiCenter.ApiVersionEntityData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ApiCenter.ApiVersionEntityData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApiCenter.ApiVersionEntityData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApiCenter.ApiVersionEntityData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApiCenter.ApiVersionEntityData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ApiVersionEntityResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ApiCenter.ApiVersionEntityData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApiCenter.ApiVersionEntityData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ApiVersionEntityResource() { }
        public virtual Azure.ResourceManager.ApiCenter.ApiVersionEntityData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string serviceName, string workspaceName, string apiName, string versionName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiCenter.ApiVersionEntityResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ApiCenter.ApiDefinitionEntityCollection GetApiDefinitionEntities() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiCenter.ApiDefinitionEntityResource> GetApiDefinitionEntity(string definitionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiCenter.ApiDefinitionEntityResource>> GetApiDefinitionEntityAsync(string definitionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiCenter.ApiVersionEntityResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Head(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> HeadAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.ApiCenter.ApiVersionEntityData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ApiCenter.ApiVersionEntityData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ApiCenter.ApiVersionEntityData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ApiCenter.ApiVersionEntityData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApiCenter.ApiVersionEntityData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApiCenter.ApiVersionEntityData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApiCenter.ApiVersionEntityData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ApiCenter.ApiVersionEntityResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.ApiCenter.ApiVersionEntityData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ApiCenter.ApiVersionEntityResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.ApiCenter.ApiVersionEntityData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class AzureResourceManagerApiCenterContext : System.ClientModel.Primitives.ModelReaderWriterContext
    {
        internal AzureResourceManagerApiCenterContext() { }
        public static Azure.ResourceManager.ApiCenter.AzureResourceManagerApiCenterContext Default { get { throw null; } }
        protected override bool TryGetTypeBuilderCore(System.Type type, out System.ClientModel.Primitives.ModelReaderWriterTypeBuilder builder) { throw null; }
    }
    public partial class EnvironmentEntityCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ApiCenter.EnvironmentEntityResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ApiCenter.EnvironmentEntityResource>, System.Collections.IEnumerable
    {
        protected EnvironmentEntityCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ApiCenter.EnvironmentEntityResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string environmentName, Azure.ResourceManager.ApiCenter.EnvironmentEntityData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ApiCenter.EnvironmentEntityResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string environmentName, Azure.ResourceManager.ApiCenter.EnvironmentEntityData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string environmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string environmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiCenter.EnvironmentEntityResource> Get(string environmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ApiCenter.EnvironmentEntityResource> GetAll(string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ApiCenter.EnvironmentEntityResource> GetAllAsync(string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiCenter.EnvironmentEntityResource>> GetAsync(string environmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.ApiCenter.EnvironmentEntityResource> GetIfExists(string environmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.ApiCenter.EnvironmentEntityResource>> GetIfExistsAsync(string environmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ApiCenter.EnvironmentEntityResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ApiCenter.EnvironmentEntityResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ApiCenter.EnvironmentEntityResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ApiCenter.EnvironmentEntityResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class EnvironmentEntityData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ApiCenter.EnvironmentEntityData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApiCenter.EnvironmentEntityData>
    {
        public EnvironmentEntityData() { }
        public Azure.ResourceManager.ApiCenter.Models.EnvironmentEntityProperties Properties { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ApiCenter.EnvironmentEntityData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ApiCenter.EnvironmentEntityData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ApiCenter.EnvironmentEntityData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ApiCenter.EnvironmentEntityData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApiCenter.EnvironmentEntityData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApiCenter.EnvironmentEntityData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApiCenter.EnvironmentEntityData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class EnvironmentEntityResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ApiCenter.EnvironmentEntityData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApiCenter.EnvironmentEntityData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected EnvironmentEntityResource() { }
        public virtual Azure.ResourceManager.ApiCenter.EnvironmentEntityData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string serviceName, string workspaceName, string environmentName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiCenter.EnvironmentEntityResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiCenter.EnvironmentEntityResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Head(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> HeadAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.ApiCenter.EnvironmentEntityData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ApiCenter.EnvironmentEntityData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ApiCenter.EnvironmentEntityData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ApiCenter.EnvironmentEntityData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApiCenter.EnvironmentEntityData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApiCenter.EnvironmentEntityData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApiCenter.EnvironmentEntityData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ApiCenter.EnvironmentEntityResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.ApiCenter.EnvironmentEntityData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ApiCenter.EnvironmentEntityResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.ApiCenter.EnvironmentEntityData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class MetadataSchemaEntityCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ApiCenter.MetadataSchemaEntityResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ApiCenter.MetadataSchemaEntityResource>, System.Collections.IEnumerable
    {
        protected MetadataSchemaEntityCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ApiCenter.MetadataSchemaEntityResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string metadataSchemaName, Azure.ResourceManager.ApiCenter.MetadataSchemaEntityData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ApiCenter.MetadataSchemaEntityResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string metadataSchemaName, Azure.ResourceManager.ApiCenter.MetadataSchemaEntityData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string metadataSchemaName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string metadataSchemaName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiCenter.MetadataSchemaEntityResource> Get(string metadataSchemaName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ApiCenter.MetadataSchemaEntityResource> GetAll(string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ApiCenter.MetadataSchemaEntityResource> GetAllAsync(string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiCenter.MetadataSchemaEntityResource>> GetAsync(string metadataSchemaName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.ApiCenter.MetadataSchemaEntityResource> GetIfExists(string metadataSchemaName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.ApiCenter.MetadataSchemaEntityResource>> GetIfExistsAsync(string metadataSchemaName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ApiCenter.MetadataSchemaEntityResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ApiCenter.MetadataSchemaEntityResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ApiCenter.MetadataSchemaEntityResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ApiCenter.MetadataSchemaEntityResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class MetadataSchemaEntityData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ApiCenter.MetadataSchemaEntityData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApiCenter.MetadataSchemaEntityData>
    {
        public MetadataSchemaEntityData() { }
        public Azure.ResourceManager.ApiCenter.Models.MetadataSchemaEntityProperties Properties { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ApiCenter.MetadataSchemaEntityData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ApiCenter.MetadataSchemaEntityData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ApiCenter.MetadataSchemaEntityData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ApiCenter.MetadataSchemaEntityData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApiCenter.MetadataSchemaEntityData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApiCenter.MetadataSchemaEntityData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApiCenter.MetadataSchemaEntityData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MetadataSchemaEntityResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ApiCenter.MetadataSchemaEntityData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApiCenter.MetadataSchemaEntityData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected MetadataSchemaEntityResource() { }
        public virtual Azure.ResourceManager.ApiCenter.MetadataSchemaEntityData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string serviceName, string metadataSchemaName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiCenter.MetadataSchemaEntityResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiCenter.MetadataSchemaEntityResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Head(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> HeadAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.ApiCenter.MetadataSchemaEntityData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ApiCenter.MetadataSchemaEntityData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ApiCenter.MetadataSchemaEntityData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ApiCenter.MetadataSchemaEntityData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApiCenter.MetadataSchemaEntityData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApiCenter.MetadataSchemaEntityData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApiCenter.MetadataSchemaEntityData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ApiCenter.MetadataSchemaEntityResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.ApiCenter.MetadataSchemaEntityData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ApiCenter.MetadataSchemaEntityResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.ApiCenter.MetadataSchemaEntityData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ServiceEntityCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ApiCenter.ServiceEntityResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ApiCenter.ServiceEntityResource>, System.Collections.IEnumerable
    {
        protected ServiceEntityCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ApiCenter.ServiceEntityResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string serviceName, Azure.ResourceManager.ApiCenter.ServiceEntityData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ApiCenter.ServiceEntityResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string serviceName, Azure.ResourceManager.ApiCenter.ServiceEntityData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string serviceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string serviceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiCenter.ServiceEntityResource> Get(string serviceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ApiCenter.ServiceEntityResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ApiCenter.ServiceEntityResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiCenter.ServiceEntityResource>> GetAsync(string serviceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.ApiCenter.ServiceEntityResource> GetIfExists(string serviceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.ApiCenter.ServiceEntityResource>> GetIfExistsAsync(string serviceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ApiCenter.ServiceEntityResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ApiCenter.ServiceEntityResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ApiCenter.ServiceEntityResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ApiCenter.ServiceEntityResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ServiceEntityData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ApiCenter.ServiceEntityData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApiCenter.ServiceEntityData>
    {
        public ServiceEntityData(Azure.Core.AzureLocation location) { }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public Azure.ResourceManager.ApiCenter.Models.ApiCenterProvisioningState? ServiceEntityProvisioningState { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ApiCenter.ServiceEntityData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ApiCenter.ServiceEntityData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ApiCenter.ServiceEntityData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ApiCenter.ServiceEntityData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApiCenter.ServiceEntityData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApiCenter.ServiceEntityData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApiCenter.ServiceEntityData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ServiceEntityResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ApiCenter.ServiceEntityData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApiCenter.ServiceEntityData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ServiceEntityResource() { }
        public virtual Azure.ResourceManager.ApiCenter.ServiceEntityData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.ApiCenter.ServiceEntityResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiCenter.ServiceEntityResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string serviceName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ApiCenter.Models.MetadataSchemaExportResult> ExportMetadataSchema(Azure.WaitUntil waitUntil, Azure.ResourceManager.ApiCenter.Models.MetadataSchemaExportContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ApiCenter.Models.MetadataSchemaExportResult>> ExportMetadataSchemaAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.ApiCenter.Models.MetadataSchemaExportContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiCenter.ServiceEntityResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiCenter.ServiceEntityResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ApiCenter.MetadataSchemaEntityCollection GetMetadataSchemaEntities() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiCenter.MetadataSchemaEntityResource> GetMetadataSchemaEntity(string metadataSchemaName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiCenter.MetadataSchemaEntityResource>> GetMetadataSchemaEntityAsync(string metadataSchemaName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ApiCenter.WorkspaceEntityCollection GetWorkspaceEntities() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiCenter.WorkspaceEntityResource> GetWorkspaceEntity(string workspaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiCenter.WorkspaceEntityResource>> GetWorkspaceEntityAsync(string workspaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiCenter.ServiceEntityResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiCenter.ServiceEntityResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiCenter.ServiceEntityResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiCenter.ServiceEntityResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.ApiCenter.ServiceEntityData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ApiCenter.ServiceEntityData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ApiCenter.ServiceEntityData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ApiCenter.ServiceEntityData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApiCenter.ServiceEntityData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApiCenter.ServiceEntityData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApiCenter.ServiceEntityData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiCenter.ServiceEntityResource> Update(Azure.ResourceManager.ApiCenter.Models.ServiceEntityPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiCenter.ServiceEntityResource>> UpdateAsync(Azure.ResourceManager.ApiCenter.Models.ServiceEntityPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class WorkspaceEntityCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ApiCenter.WorkspaceEntityResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ApiCenter.WorkspaceEntityResource>, System.Collections.IEnumerable
    {
        protected WorkspaceEntityCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ApiCenter.WorkspaceEntityResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string workspaceName, Azure.ResourceManager.ApiCenter.WorkspaceEntityData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ApiCenter.WorkspaceEntityResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string workspaceName, Azure.ResourceManager.ApiCenter.WorkspaceEntityData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string workspaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string workspaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiCenter.WorkspaceEntityResource> Get(string workspaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ApiCenter.WorkspaceEntityResource> GetAll(string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ApiCenter.WorkspaceEntityResource> GetAllAsync(string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiCenter.WorkspaceEntityResource>> GetAsync(string workspaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.ApiCenter.WorkspaceEntityResource> GetIfExists(string workspaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.ApiCenter.WorkspaceEntityResource>> GetIfExistsAsync(string workspaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ApiCenter.WorkspaceEntityResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ApiCenter.WorkspaceEntityResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ApiCenter.WorkspaceEntityResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ApiCenter.WorkspaceEntityResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class WorkspaceEntityData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ApiCenter.WorkspaceEntityData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApiCenter.WorkspaceEntityData>
    {
        public WorkspaceEntityData() { }
        public Azure.ResourceManager.ApiCenter.Models.WorkspaceEntityProperties Properties { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ApiCenter.WorkspaceEntityData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ApiCenter.WorkspaceEntityData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ApiCenter.WorkspaceEntityData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ApiCenter.WorkspaceEntityData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApiCenter.WorkspaceEntityData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApiCenter.WorkspaceEntityData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApiCenter.WorkspaceEntityData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class WorkspaceEntityResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ApiCenter.WorkspaceEntityData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApiCenter.WorkspaceEntityData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected WorkspaceEntityResource() { }
        public virtual Azure.ResourceManager.ApiCenter.WorkspaceEntityData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string serviceName, string workspaceName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiCenter.WorkspaceEntityResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ApiCenter.ApiEntityCollection GetApiEntities() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiCenter.ApiEntityResource> GetApiEntity(string apiName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiCenter.ApiEntityResource>> GetApiEntityAsync(string apiName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiCenter.WorkspaceEntityResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ApiCenter.EnvironmentEntityCollection GetEnvironmentEntities() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiCenter.EnvironmentEntityResource> GetEnvironmentEntity(string environmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiCenter.EnvironmentEntityResource>> GetEnvironmentEntityAsync(string environmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Head(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> HeadAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.ApiCenter.WorkspaceEntityData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ApiCenter.WorkspaceEntityData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ApiCenter.WorkspaceEntityData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ApiCenter.WorkspaceEntityData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApiCenter.WorkspaceEntityData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApiCenter.WorkspaceEntityData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApiCenter.WorkspaceEntityData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ApiCenter.WorkspaceEntityResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.ApiCenter.WorkspaceEntityData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ApiCenter.WorkspaceEntityResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.ApiCenter.WorkspaceEntityData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.ApiCenter.Mocking
{
    public partial class MockableApiCenterArmClient : Azure.ResourceManager.ArmResource
    {
        protected MockableApiCenterArmClient() { }
        public virtual Azure.ResourceManager.ApiCenter.ApiDefinitionEntityResource GetApiDefinitionEntityResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.ApiCenter.ApiDeploymentEntityResource GetApiDeploymentEntityResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.ApiCenter.ApiEntityResource GetApiEntityResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.ApiCenter.ApiVersionEntityResource GetApiVersionEntityResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.ApiCenter.EnvironmentEntityResource GetEnvironmentEntityResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.ApiCenter.MetadataSchemaEntityResource GetMetadataSchemaEntityResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.ApiCenter.ServiceEntityResource GetServiceEntityResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.ApiCenter.WorkspaceEntityResource GetWorkspaceEntityResource(Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class MockableApiCenterResourceGroupResource : Azure.ResourceManager.ArmResource
    {
        protected MockableApiCenterResourceGroupResource() { }
        public virtual Azure.ResourceManager.ApiCenter.ServiceEntityCollection GetServiceEntities() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiCenter.ServiceEntityResource> GetServiceEntity(string serviceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiCenter.ServiceEntityResource>> GetServiceEntityAsync(string serviceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class MockableApiCenterSubscriptionResource : Azure.ResourceManager.ArmResource
    {
        protected MockableApiCenterSubscriptionResource() { }
        public virtual Azure.Pageable<Azure.ResourceManager.ApiCenter.ServiceEntityResource> GetServiceEntities(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ApiCenter.ServiceEntityResource> GetServiceEntitiesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
    public partial class ApiContact : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ApiCenter.Models.ApiContact>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApiCenter.Models.ApiContact>
    {
        public ApiContact() { }
        public string Email { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public System.Uri Uri { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ApiCenter.Models.ApiContact System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ApiCenter.Models.ApiContact>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ApiCenter.Models.ApiContact>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ApiCenter.Models.ApiContact System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApiCenter.Models.ApiContact>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApiCenter.Models.ApiContact>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApiCenter.Models.ApiContact>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ApiDefinitionEntityProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ApiCenter.Models.ApiDefinitionEntityProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApiCenter.Models.ApiDefinitionEntityProperties>
    {
        public ApiDefinitionEntityProperties(string title) { }
        public string Description { get { throw null; } set { } }
        public Azure.ResourceManager.ApiCenter.Models.ApiSpecification Specification { get { throw null; } }
        public string Title { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ApiCenter.Models.ApiDefinitionEntityProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ApiCenter.Models.ApiDefinitionEntityProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ApiCenter.Models.ApiDefinitionEntityProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ApiCenter.Models.ApiDefinitionEntityProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApiCenter.Models.ApiDefinitionEntityProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApiCenter.Models.ApiDefinitionEntityProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApiCenter.Models.ApiDefinitionEntityProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ApiDeploymentEntityProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ApiCenter.Models.ApiDeploymentEntityProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApiCenter.Models.ApiDeploymentEntityProperties>
    {
        public ApiDeploymentEntityProperties() { }
        public System.BinaryData CustomProperties { get { throw null; } set { } }
        public string DefinitionId { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public string EnvironmentId { get { throw null; } set { } }
        public System.Collections.Generic.IList<System.Uri> ServerRuntimeUri { get { throw null; } }
        public Azure.ResourceManager.ApiCenter.Models.DeploymentState? State { get { throw null; } set { } }
        public string Title { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ApiCenter.Models.ApiDeploymentEntityProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ApiCenter.Models.ApiDeploymentEntityProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ApiCenter.Models.ApiDeploymentEntityProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ApiCenter.Models.ApiDeploymentEntityProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApiCenter.Models.ApiDeploymentEntityProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApiCenter.Models.ApiDeploymentEntityProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApiCenter.Models.ApiDeploymentEntityProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ApiEntityProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ApiCenter.Models.ApiEntityProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApiCenter.Models.ApiEntityProperties>
    {
        public ApiEntityProperties(string title, Azure.ResourceManager.ApiCenter.Models.ApiKind kind) { }
        public System.Collections.Generic.IList<Azure.ResourceManager.ApiCenter.Models.ApiContact> Contacts { get { throw null; } }
        public System.BinaryData CustomProperties { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ApiCenter.Models.ExternalDocumentation> ExternalDocumentation { get { throw null; } }
        public Azure.ResourceManager.ApiCenter.Models.ApiKind Kind { get { throw null; } set { } }
        public Azure.ResourceManager.ApiCenter.Models.ApiLicense License { get { throw null; } set { } }
        public Azure.ResourceManager.ApiCenter.Models.LifecycleStage? LifecycleStage { get { throw null; } }
        public string Summary { get { throw null; } set { } }
        public System.Uri TermsOfServiceUri { get { throw null; } set { } }
        public string Title { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ApiCenter.Models.ApiEntityProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ApiCenter.Models.ApiEntityProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ApiCenter.Models.ApiEntityProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ApiCenter.Models.ApiEntityProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApiCenter.Models.ApiEntityProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApiCenter.Models.ApiEntityProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApiCenter.Models.ApiEntityProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
    public partial class ApiLicense : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ApiCenter.Models.ApiLicense>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApiCenter.Models.ApiLicense>
    {
        public ApiLicense() { }
        public System.Uri Identifier { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public System.Uri Uri { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ApiCenter.Models.ApiLicense System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ApiCenter.Models.ApiLicense>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ApiCenter.Models.ApiLicense>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ApiCenter.Models.ApiLicense System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApiCenter.Models.ApiLicense>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApiCenter.Models.ApiLicense>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApiCenter.Models.ApiLicense>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ApiSpecExportResult : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ApiCenter.Models.ApiSpecExportResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApiCenter.Models.ApiSpecExportResult>
    {
        internal ApiSpecExportResult() { }
        public Azure.ResourceManager.ApiCenter.Models.ApiSpecExportResultFormat? Format { get { throw null; } }
        public string Value { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
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
    public partial class ApiSpecification : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ApiCenter.Models.ApiSpecification>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApiCenter.Models.ApiSpecification>
    {
        internal ApiSpecification() { }
        public string Name { get { throw null; } }
        public string Version { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ApiCenter.Models.ApiSpecification System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ApiCenter.Models.ApiSpecification>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ApiCenter.Models.ApiSpecification>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ApiCenter.Models.ApiSpecification System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApiCenter.Models.ApiSpecification>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApiCenter.Models.ApiSpecification>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApiCenter.Models.ApiSpecification>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ApiSpecImportContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ApiCenter.Models.ApiSpecImportContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApiCenter.Models.ApiSpecImportContent>
    {
        public ApiSpecImportContent() { }
        public Azure.ResourceManager.ApiCenter.Models.ApiSpecImportSourceFormat? Format { get { throw null; } set { } }
        public Azure.ResourceManager.ApiCenter.Models.ApiSpecImportRequestSpecification Specification { get { throw null; } set { } }
        public string Value { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
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
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
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
    public partial class ApiVersionEntityProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ApiCenter.Models.ApiVersionEntityProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApiCenter.Models.ApiVersionEntityProperties>
    {
        public ApiVersionEntityProperties(string title, Azure.ResourceManager.ApiCenter.Models.LifecycleStage lifecycleStage) { }
        public Azure.ResourceManager.ApiCenter.Models.LifecycleStage LifecycleStage { get { throw null; } set { } }
        public string Title { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ApiCenter.Models.ApiVersionEntityProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ApiCenter.Models.ApiVersionEntityProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ApiCenter.Models.ApiVersionEntityProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ApiCenter.Models.ApiVersionEntityProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApiCenter.Models.ApiVersionEntityProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApiCenter.Models.ApiVersionEntityProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApiCenter.Models.ApiVersionEntityProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public static partial class ArmApiCenterModelFactory
    {
        public static Azure.ResourceManager.ApiCenter.ApiDefinitionEntityData ApiDefinitionEntityData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.ApiCenter.Models.ApiDefinitionEntityProperties properties = null) { throw null; }
        public static Azure.ResourceManager.ApiCenter.Models.ApiDefinitionEntityProperties ApiDefinitionEntityProperties(string title = null, string description = null, Azure.ResourceManager.ApiCenter.Models.ApiSpecification specification = null) { throw null; }
        public static Azure.ResourceManager.ApiCenter.ApiDeploymentEntityData ApiDeploymentEntityData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.ApiCenter.Models.ApiDeploymentEntityProperties properties = null) { throw null; }
        public static Azure.ResourceManager.ApiCenter.ApiEntityData ApiEntityData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.ApiCenter.Models.ApiEntityProperties properties = null) { throw null; }
        public static Azure.ResourceManager.ApiCenter.Models.ApiEntityProperties ApiEntityProperties(string title = null, Azure.ResourceManager.ApiCenter.Models.ApiKind kind = default(Azure.ResourceManager.ApiCenter.Models.ApiKind), string description = null, string summary = null, Azure.ResourceManager.ApiCenter.Models.LifecycleStage? lifecycleStage = default(Azure.ResourceManager.ApiCenter.Models.LifecycleStage?), System.Uri termsOfServiceUri = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ApiCenter.Models.ExternalDocumentation> externalDocumentation = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ApiCenter.Models.ApiContact> contacts = null, Azure.ResourceManager.ApiCenter.Models.ApiLicense license = null, System.BinaryData customProperties = null) { throw null; }
        public static Azure.ResourceManager.ApiCenter.Models.ApiSpecExportResult ApiSpecExportResult(Azure.ResourceManager.ApiCenter.Models.ApiSpecExportResultFormat? format = default(Azure.ResourceManager.ApiCenter.Models.ApiSpecExportResultFormat?), string value = null) { throw null; }
        public static Azure.ResourceManager.ApiCenter.Models.ApiSpecification ApiSpecification(string name = null, string version = null) { throw null; }
        public static Azure.ResourceManager.ApiCenter.ApiVersionEntityData ApiVersionEntityData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.ApiCenter.Models.ApiVersionEntityProperties properties = null) { throw null; }
        public static Azure.ResourceManager.ApiCenter.EnvironmentEntityData EnvironmentEntityData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.ApiCenter.Models.EnvironmentEntityProperties properties = null) { throw null; }
        public static Azure.ResourceManager.ApiCenter.MetadataSchemaEntityData MetadataSchemaEntityData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.ApiCenter.Models.MetadataSchemaEntityProperties properties = null) { throw null; }
        public static Azure.ResourceManager.ApiCenter.Models.MetadataSchemaExportResult MetadataSchemaExportResult(Azure.ResourceManager.ApiCenter.Models.MetadataSchemaExportFormat? format = default(Azure.ResourceManager.ApiCenter.Models.MetadataSchemaExportFormat?), string value = null) { throw null; }
        public static Azure.ResourceManager.ApiCenter.ServiceEntityData ServiceEntityData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.ApiCenter.Models.ApiCenterProvisioningState? serviceEntityProvisioningState = default(Azure.ResourceManager.ApiCenter.Models.ApiCenterProvisioningState?), Azure.ResourceManager.Models.ManagedServiceIdentity identity = null) { throw null; }
        public static Azure.ResourceManager.ApiCenter.WorkspaceEntityData WorkspaceEntityData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.ApiCenter.Models.WorkspaceEntityProperties properties = null) { throw null; }
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
    public partial class EnvironmentEntityProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ApiCenter.Models.EnvironmentEntityProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApiCenter.Models.EnvironmentEntityProperties>
    {
        public EnvironmentEntityProperties(string title, Azure.ResourceManager.ApiCenter.Models.EnvironmentKind kind) { }
        public System.BinaryData CustomProperties { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public Azure.ResourceManager.ApiCenter.Models.EnvironmentKind Kind { get { throw null; } set { } }
        public Azure.ResourceManager.ApiCenter.Models.EnvironmentOnboarding Onboarding { get { throw null; } set { } }
        public Azure.ResourceManager.ApiCenter.Models.EnvironmentServer Server { get { throw null; } set { } }
        public string Title { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ApiCenter.Models.EnvironmentEntityProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ApiCenter.Models.EnvironmentEntityProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ApiCenter.Models.EnvironmentEntityProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ApiCenter.Models.EnvironmentEntityProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApiCenter.Models.EnvironmentEntityProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApiCenter.Models.EnvironmentEntityProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApiCenter.Models.EnvironmentEntityProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
    public partial class EnvironmentOnboarding : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ApiCenter.Models.EnvironmentOnboarding>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApiCenter.Models.EnvironmentOnboarding>
    {
        public EnvironmentOnboarding() { }
        public System.Collections.Generic.IList<System.Uri> DeveloperPortalUri { get { throw null; } }
        public string Instructions { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ApiCenter.Models.EnvironmentOnboarding System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ApiCenter.Models.EnvironmentOnboarding>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ApiCenter.Models.EnvironmentOnboarding>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ApiCenter.Models.EnvironmentOnboarding System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApiCenter.Models.EnvironmentOnboarding>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApiCenter.Models.EnvironmentOnboarding>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApiCenter.Models.EnvironmentOnboarding>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class EnvironmentServer : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ApiCenter.Models.EnvironmentServer>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApiCenter.Models.EnvironmentServer>
    {
        public EnvironmentServer() { }
        public System.Collections.Generic.IList<System.Uri> ManagementPortalUri { get { throw null; } }
        public Azure.ResourceManager.ApiCenter.Models.EnvironmentServerType? ServerType { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
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
        public static Azure.ResourceManager.ApiCenter.Models.EnvironmentServerType ApigeeApiManagement { get { throw null; } }
        public static Azure.ResourceManager.ApiCenter.Models.EnvironmentServerType AwsApiGateway { get { throw null; } }
        public static Azure.ResourceManager.ApiCenter.Models.EnvironmentServerType AzureApiManagement { get { throw null; } }
        public static Azure.ResourceManager.ApiCenter.Models.EnvironmentServerType AzureComputeService { get { throw null; } }
        public static Azure.ResourceManager.ApiCenter.Models.EnvironmentServerType KongApiGateway { get { throw null; } }
        public static Azure.ResourceManager.ApiCenter.Models.EnvironmentServerType Kubernetes { get { throw null; } }
        public static Azure.ResourceManager.ApiCenter.Models.EnvironmentServerType MuleSoftApiManagement { get { throw null; } }
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
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ApiCenter.Models.ExternalDocumentation System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ApiCenter.Models.ExternalDocumentation>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ApiCenter.Models.ExternalDocumentation>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ApiCenter.Models.ExternalDocumentation System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApiCenter.Models.ExternalDocumentation>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApiCenter.Models.ExternalDocumentation>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApiCenter.Models.ExternalDocumentation>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
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
    public partial class MetadataSchemaEntityProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ApiCenter.Models.MetadataSchemaEntityProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApiCenter.Models.MetadataSchemaEntityProperties>
    {
        public MetadataSchemaEntityProperties(string schema) { }
        public System.Collections.Generic.IList<Azure.ResourceManager.ApiCenter.Models.MetadataAssignment> AssignedTo { get { throw null; } }
        public string Schema { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ApiCenter.Models.MetadataSchemaEntityProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ApiCenter.Models.MetadataSchemaEntityProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ApiCenter.Models.MetadataSchemaEntityProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ApiCenter.Models.MetadataSchemaEntityProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApiCenter.Models.MetadataSchemaEntityProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApiCenter.Models.MetadataSchemaEntityProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApiCenter.Models.MetadataSchemaEntityProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MetadataSchemaExportContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ApiCenter.Models.MetadataSchemaExportContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApiCenter.Models.MetadataSchemaExportContent>
    {
        public MetadataSchemaExportContent() { }
        public Azure.ResourceManager.ApiCenter.Models.MetadataAssignmentEntity? AssignedTo { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
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
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ApiCenter.Models.MetadataSchemaExportResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ApiCenter.Models.MetadataSchemaExportResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ApiCenter.Models.MetadataSchemaExportResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ApiCenter.Models.MetadataSchemaExportResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApiCenter.Models.MetadataSchemaExportResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApiCenter.Models.MetadataSchemaExportResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApiCenter.Models.MetadataSchemaExportResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ServiceEntityPatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ApiCenter.Models.ServiceEntityPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApiCenter.Models.ServiceEntityPatch>
    {
        public ServiceEntityPatch() { }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ApiCenter.Models.ServiceEntityPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ApiCenter.Models.ServiceEntityPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ApiCenter.Models.ServiceEntityPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ApiCenter.Models.ServiceEntityPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApiCenter.Models.ServiceEntityPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApiCenter.Models.ServiceEntityPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApiCenter.Models.ServiceEntityPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class WorkspaceEntityProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ApiCenter.Models.WorkspaceEntityProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApiCenter.Models.WorkspaceEntityProperties>
    {
        public WorkspaceEntityProperties(string title) { }
        public string Description { get { throw null; } set { } }
        public string Title { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ApiCenter.Models.WorkspaceEntityProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ApiCenter.Models.WorkspaceEntityProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ApiCenter.Models.WorkspaceEntityProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ApiCenter.Models.WorkspaceEntityProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApiCenter.Models.WorkspaceEntityProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApiCenter.Models.WorkspaceEntityProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApiCenter.Models.WorkspaceEntityProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
}
