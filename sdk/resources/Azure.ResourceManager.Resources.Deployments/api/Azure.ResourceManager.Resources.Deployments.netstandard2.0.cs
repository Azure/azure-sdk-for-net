namespace Azure.ResourceManager.Resources.Deployments
{
    public partial class ArmDeploymentCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Resources.Deployments.ArmDeploymentResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Deployments.ArmDeploymentResource>, System.Collections.IEnumerable
    {
        protected ArmDeploymentCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Resources.Deployments.ArmDeploymentResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string deploymentName, Azure.ResourceManager.Resources.Deployments.Models.ArmDeploymentContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Resources.Deployments.ArmDeploymentResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string deploymentName, Azure.ResourceManager.Resources.Deployments.Models.ArmDeploymentContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string deploymentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string deploymentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Resources.Deployments.ArmDeploymentResource> Get(string deploymentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Resources.Deployments.ArmDeploymentResource> GetAll(string filter = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Resources.Deployments.ArmDeploymentResource> GetAllAsync(string filter = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources.Deployments.ArmDeploymentResource>> GetAsync(string deploymentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Resources.Deployments.ArmDeploymentResource> GetIfExists(string deploymentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Resources.Deployments.ArmDeploymentResource>> GetIfExistsAsync(string deploymentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Resources.Deployments.ArmDeploymentResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Resources.Deployments.ArmDeploymentResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Resources.Deployments.ArmDeploymentResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Deployments.ArmDeploymentResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ArmDeploymentData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Deployments.ArmDeploymentData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Deployments.ArmDeploymentData>
    {
        internal ArmDeploymentData() { }
        public Azure.Core.AzureLocation? Location { get { throw null; } }
        public Azure.ResourceManager.Resources.Deployments.Models.ArmDeploymentPropertiesExtended Properties { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, string> Tags { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.Deployments.ArmDeploymentData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Deployments.ArmDeploymentData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Deployments.ArmDeploymentData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.Deployments.ArmDeploymentData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Deployments.ArmDeploymentData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Deployments.ArmDeploymentData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Deployments.ArmDeploymentData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ArmDeploymentResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Deployments.ArmDeploymentData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Deployments.ArmDeploymentData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ArmDeploymentResource() { }
        public virtual Azure.ResourceManager.Resources.Deployments.ArmDeploymentData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.Resources.Deployments.ArmDeploymentResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources.Deployments.ArmDeploymentResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response Cancel(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> CancelAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response CheckExistence(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> CheckExistenceAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string scope, string deploymentName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Resources.Deployments.Models.ArmDeploymentExportResult> ExportTemplate(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources.Deployments.Models.ArmDeploymentExportResult>> ExportTemplateAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Resources.Deployments.ArmDeploymentResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources.Deployments.ArmDeploymentResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Resources.Deployments.Models.ArmDeploymentOperation> GetDeploymentOperation(string operationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources.Deployments.Models.ArmDeploymentOperation>> GetDeploymentOperationAsync(string operationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Resources.Deployments.Models.ArmDeploymentOperation> GetDeploymentOperations(int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Resources.Deployments.Models.ArmDeploymentOperation> GetDeploymentOperationsAsync(int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Resources.Deployments.ArmDeploymentResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources.Deployments.ArmDeploymentResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Resources.Deployments.ArmDeploymentResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources.Deployments.ArmDeploymentResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.Resources.Deployments.ArmDeploymentData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Deployments.ArmDeploymentData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Deployments.ArmDeploymentData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.Deployments.ArmDeploymentData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Deployments.ArmDeploymentData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Deployments.ArmDeploymentData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Deployments.ArmDeploymentData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Resources.Deployments.ArmDeploymentResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Resources.Deployments.Models.ArmDeploymentContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Resources.Deployments.ArmDeploymentResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Resources.Deployments.Models.ArmDeploymentContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Resources.Deployments.Models.ArmDeploymentValidateResult> Validate(Azure.WaitUntil waitUntil, Azure.ResourceManager.Resources.Deployments.Models.ArmDeploymentContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Resources.Deployments.Models.ArmDeploymentValidateResult>> ValidateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Resources.Deployments.Models.ArmDeploymentContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Resources.Deployments.Models.WhatIfOperationResult> WhatIf(Azure.WaitUntil waitUntil, Azure.ResourceManager.Resources.Deployments.Models.ArmDeploymentWhatIfContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Resources.Deployments.Models.WhatIfOperationResult>> WhatIfAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Resources.Deployments.Models.ArmDeploymentWhatIfContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class AzureResourceManagerResourcesDeploymentsContext : System.ClientModel.Primitives.ModelReaderWriterContext
    {
        internal AzureResourceManagerResourcesDeploymentsContext() { }
        public static Azure.ResourceManager.Resources.Deployments.AzureResourceManagerResourcesDeploymentsContext Default { get { throw null; } }
        protected override bool TryGetTypeBuilderCore(System.Type type, out System.ClientModel.Primitives.ModelReaderWriterTypeBuilder builder) { throw null; }
    }
    public static partial class ResourcesDeploymentsExtensions
    {
        public static Azure.Response<Azure.ResourceManager.Resources.Deployments.Models.TemplateHashResult> CalculateDeploymentTemplateHash(this Azure.ResourceManager.Resources.TenantResource tenantResource, System.BinaryData template, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources.Deployments.Models.TemplateHashResult>> CalculateDeploymentTemplateHashAsync(this Azure.ResourceManager.Resources.TenantResource tenantResource, System.BinaryData template, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Resources.Deployments.ArmDeploymentResource> GetArmDeployment(this Azure.ResourceManager.ManagementGroups.ManagementGroupResource managementGroupResource, string deploymentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Resources.Deployments.ArmDeploymentResource> GetArmDeployment(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string deploymentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Resources.Deployments.ArmDeploymentResource> GetArmDeployment(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string deploymentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Resources.Deployments.ArmDeploymentResource> GetArmDeployment(this Azure.ResourceManager.Resources.TenantResource tenantResource, string deploymentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources.Deployments.ArmDeploymentResource>> GetArmDeploymentAsync(this Azure.ResourceManager.ManagementGroups.ManagementGroupResource managementGroupResource, string deploymentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources.Deployments.ArmDeploymentResource>> GetArmDeploymentAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string deploymentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources.Deployments.ArmDeploymentResource>> GetArmDeploymentAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string deploymentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources.Deployments.ArmDeploymentResource>> GetArmDeploymentAsync(this Azure.ResourceManager.Resources.TenantResource tenantResource, string deploymentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Resources.Deployments.ArmDeploymentResource GetArmDeploymentResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Resources.Deployments.ArmDeploymentCollection GetArmDeployments(this Azure.ResourceManager.ManagementGroups.ManagementGroupResource managementGroupResource) { throw null; }
        public static Azure.ResourceManager.Resources.Deployments.ArmDeploymentCollection GetArmDeployments(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.ResourceManager.Resources.Deployments.ArmDeploymentCollection GetArmDeployments(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource) { throw null; }
        public static Azure.ResourceManager.Resources.Deployments.ArmDeploymentCollection GetArmDeployments(this Azure.ResourceManager.Resources.TenantResource tenantResource) { throw null; }
    }
}
namespace Azure.ResourceManager.Resources.Deployments.Mocking
{
    public partial class MockableResourcesDeploymentsArmClient : Azure.ResourceManager.ArmResource
    {
        protected MockableResourcesDeploymentsArmClient() { }
        public virtual Azure.ResourceManager.Resources.Deployments.ArmDeploymentResource GetArmDeploymentResource(Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class MockableResourcesDeploymentsManagementGroupResource : Azure.ResourceManager.ArmResource
    {
        protected MockableResourcesDeploymentsManagementGroupResource() { }
        public virtual Azure.Response<Azure.ResourceManager.Resources.Deployments.ArmDeploymentResource> GetArmDeployment(string deploymentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources.Deployments.ArmDeploymentResource>> GetArmDeploymentAsync(string deploymentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Resources.Deployments.ArmDeploymentCollection GetArmDeployments() { throw null; }
    }
    public partial class MockableResourcesDeploymentsResourceGroupResource : Azure.ResourceManager.ArmResource
    {
        protected MockableResourcesDeploymentsResourceGroupResource() { }
        public virtual Azure.Response<Azure.ResourceManager.Resources.Deployments.ArmDeploymentResource> GetArmDeployment(string deploymentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources.Deployments.ArmDeploymentResource>> GetArmDeploymentAsync(string deploymentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Resources.Deployments.ArmDeploymentCollection GetArmDeployments() { throw null; }
    }
    public partial class MockableResourcesDeploymentsSubscriptionResource : Azure.ResourceManager.ArmResource
    {
        protected MockableResourcesDeploymentsSubscriptionResource() { }
        public virtual Azure.Response<Azure.ResourceManager.Resources.Deployments.ArmDeploymentResource> GetArmDeployment(string deploymentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources.Deployments.ArmDeploymentResource>> GetArmDeploymentAsync(string deploymentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Resources.Deployments.ArmDeploymentCollection GetArmDeployments() { throw null; }
    }
    public partial class MockableResourcesDeploymentsTenantResource : Azure.ResourceManager.ArmResource
    {
        protected MockableResourcesDeploymentsTenantResource() { }
        public virtual Azure.Response<Azure.ResourceManager.Resources.Deployments.Models.TemplateHashResult> CalculateDeploymentTemplateHash(System.BinaryData template, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources.Deployments.Models.TemplateHashResult>> CalculateDeploymentTemplateHashAsync(System.BinaryData template, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Resources.Deployments.ArmDeploymentResource> GetArmDeployment(string deploymentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources.Deployments.ArmDeploymentResource>> GetArmDeploymentAsync(string deploymentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Resources.Deployments.ArmDeploymentCollection GetArmDeployments() { throw null; }
    }
}
namespace Azure.ResourceManager.Resources.Deployments.Models
{
    public partial class ApiProfile : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Deployments.Models.ApiProfile>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Deployments.Models.ApiProfile>
    {
        internal ApiProfile() { }
        public string ApiVersion { get { throw null; } }
        public string ProfileVersion { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.Deployments.Models.ApiProfile System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Deployments.Models.ApiProfile>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Deployments.Models.ApiProfile>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.Deployments.Models.ApiProfile System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Deployments.Models.ApiProfile>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Deployments.Models.ApiProfile>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Deployments.Models.ApiProfile>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ArmDependency : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Deployments.Models.ArmDependency>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Deployments.Models.ArmDependency>
    {
        internal ArmDependency() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Resources.Deployments.Models.BasicArmDependency> DependsOn { get { throw null; } }
        public string Id { get { throw null; } }
        public string ResourceName { get { throw null; } }
        public Azure.Core.ResourceType? ResourceType { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.Deployments.Models.ArmDependency System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Deployments.Models.ArmDependency>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Deployments.Models.ArmDependency>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.Deployments.Models.ArmDependency System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Deployments.Models.ArmDependency>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Deployments.Models.ArmDependency>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Deployments.Models.ArmDependency>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ArmDeploymentContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Deployments.Models.ArmDeploymentContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Deployments.Models.ArmDeploymentContent>
    {
        public ArmDeploymentContent(Azure.ResourceManager.Resources.Deployments.Models.ArmDeploymentProperties properties) { }
        public Azure.ResourceManager.Resources.Deployments.Models.DeploymentIdentity Identity { get { throw null; } set { } }
        public Azure.Core.AzureLocation? Location { get { throw null; } set { } }
        public Azure.ResourceManager.Resources.Deployments.Models.ArmDeploymentProperties Properties { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.Deployments.Models.ArmDeploymentContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Deployments.Models.ArmDeploymentContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Deployments.Models.ArmDeploymentContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.Deployments.Models.ArmDeploymentContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Deployments.Models.ArmDeploymentContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Deployments.Models.ArmDeploymentContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Deployments.Models.ArmDeploymentContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ArmDeploymentExportResult : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Deployments.Models.ArmDeploymentExportResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Deployments.Models.ArmDeploymentExportResult>
    {
        internal ArmDeploymentExportResult() { }
        public System.BinaryData Template { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.Deployments.Models.ArmDeploymentExportResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Deployments.Models.ArmDeploymentExportResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Deployments.Models.ArmDeploymentExportResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.Deployments.Models.ArmDeploymentExportResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Deployments.Models.ArmDeploymentExportResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Deployments.Models.ArmDeploymentExportResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Deployments.Models.ArmDeploymentExportResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ArmDeploymentExtensionConfigItem : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Deployments.Models.ArmDeploymentExtensionConfigItem>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Deployments.Models.ArmDeploymentExtensionConfigItem>
    {
        public ArmDeploymentExtensionConfigItem() { }
        public Azure.ResourceManager.Resources.Deployments.Models.ExtensionConfigPropertyType? ExtensionConfigPropertyType { get { throw null; } }
        public Azure.ResourceManager.Resources.Deployments.Models.KeyVaultParameterReference KeyVaultReference { get { throw null; } set { } }
        public System.BinaryData Value { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.Deployments.Models.ArmDeploymentExtensionConfigItem System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Deployments.Models.ArmDeploymentExtensionConfigItem>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Deployments.Models.ArmDeploymentExtensionConfigItem>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.Deployments.Models.ArmDeploymentExtensionConfigItem System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Deployments.Models.ArmDeploymentExtensionConfigItem>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Deployments.Models.ArmDeploymentExtensionConfigItem>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Deployments.Models.ArmDeploymentExtensionConfigItem>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ArmDeploymentExtensionDefinition : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Deployments.Models.ArmDeploymentExtensionDefinition>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Deployments.Models.ArmDeploymentExtensionDefinition>
    {
        internal ArmDeploymentExtensionDefinition() { }
        public string Alias { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, Azure.ResourceManager.Resources.Deployments.Models.ArmDeploymentExtensionConfigItem> Config { get { throw null; } }
        public string ConfigId { get { throw null; } }
        public string Name { get { throw null; } }
        public string Version { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.Deployments.Models.ArmDeploymentExtensionDefinition System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Deployments.Models.ArmDeploymentExtensionDefinition>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Deployments.Models.ArmDeploymentExtensionDefinition>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.Deployments.Models.ArmDeploymentExtensionDefinition System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Deployments.Models.ArmDeploymentExtensionDefinition>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Deployments.Models.ArmDeploymentExtensionDefinition>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Deployments.Models.ArmDeploymentExtensionDefinition>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ArmDeploymentExternalInput : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Deployments.Models.ArmDeploymentExternalInput>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Deployments.Models.ArmDeploymentExternalInput>
    {
        public ArmDeploymentExternalInput(System.BinaryData value) { }
        public System.BinaryData Value { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.Deployments.Models.ArmDeploymentExternalInput System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Deployments.Models.ArmDeploymentExternalInput>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Deployments.Models.ArmDeploymentExternalInput>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.Deployments.Models.ArmDeploymentExternalInput System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Deployments.Models.ArmDeploymentExternalInput>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Deployments.Models.ArmDeploymentExternalInput>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Deployments.Models.ArmDeploymentExternalInput>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ArmDeploymentExternalInputDefinition : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Deployments.Models.ArmDeploymentExternalInputDefinition>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Deployments.Models.ArmDeploymentExternalInputDefinition>
    {
        public ArmDeploymentExternalInputDefinition(string kind) { }
        public System.BinaryData Config { get { throw null; } set { } }
        public string Kind { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.Deployments.Models.ArmDeploymentExternalInputDefinition System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Deployments.Models.ArmDeploymentExternalInputDefinition>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Deployments.Models.ArmDeploymentExternalInputDefinition>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.Deployments.Models.ArmDeploymentExternalInputDefinition System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Deployments.Models.ArmDeploymentExternalInputDefinition>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Deployments.Models.ArmDeploymentExternalInputDefinition>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Deployments.Models.ArmDeploymentExternalInputDefinition>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public enum ArmDeploymentMode
    {
        Incremental = 0,
        Complete = 1,
    }
    public partial class ArmDeploymentOperation : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Deployments.Models.ArmDeploymentOperation>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Deployments.Models.ArmDeploymentOperation>
    {
        internal ArmDeploymentOperation() { }
        public string Id { get { throw null; } }
        public string OperationId { get { throw null; } }
        public Azure.ResourceManager.Resources.Deployments.Models.ArmDeploymentOperationProperties Properties { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.Deployments.Models.ArmDeploymentOperation System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Deployments.Models.ArmDeploymentOperation>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Deployments.Models.ArmDeploymentOperation>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.Deployments.Models.ArmDeploymentOperation System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Deployments.Models.ArmDeploymentOperation>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Deployments.Models.ArmDeploymentOperation>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Deployments.Models.ArmDeploymentOperation>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ArmDeploymentOperationProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Deployments.Models.ArmDeploymentOperationProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Deployments.Models.ArmDeploymentOperationProperties>
    {
        internal ArmDeploymentOperationProperties() { }
        public System.TimeSpan? Duration { get { throw null; } }
        public Azure.ResourceManager.Resources.Deployments.Models.ProvisioningOperationKind? ProvisioningOperation { get { throw null; } }
        public string ProvisioningState { get { throw null; } }
        public System.BinaryData RequestContent { get { throw null; } }
        public System.BinaryData ResponseContent { get { throw null; } }
        public string ServiceRequestId { get { throw null; } }
        public string StatusCode { get { throw null; } }
        public Azure.ResourceManager.Resources.Deployments.Models.StatusMessage StatusMessage { get { throw null; } }
        public Azure.ResourceManager.Resources.Deployments.Models.TargetResource TargetResource { get { throw null; } }
        public System.DateTimeOffset? Timestamp { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.Deployments.Models.ArmDeploymentOperationProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Deployments.Models.ArmDeploymentOperationProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Deployments.Models.ArmDeploymentOperationProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.Deployments.Models.ArmDeploymentOperationProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Deployments.Models.ArmDeploymentOperationProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Deployments.Models.ArmDeploymentOperationProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Deployments.Models.ArmDeploymentOperationProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ArmDeploymentParametersLink : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Deployments.Models.ArmDeploymentParametersLink>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Deployments.Models.ArmDeploymentParametersLink>
    {
        public ArmDeploymentParametersLink(System.Uri uri) { }
        public string ContentVersion { get { throw null; } set { } }
        public System.Uri Uri { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.Deployments.Models.ArmDeploymentParametersLink System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Deployments.Models.ArmDeploymentParametersLink>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Deployments.Models.ArmDeploymentParametersLink>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.Deployments.Models.ArmDeploymentParametersLink System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Deployments.Models.ArmDeploymentParametersLink>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Deployments.Models.ArmDeploymentParametersLink>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Deployments.Models.ArmDeploymentParametersLink>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ArmDeploymentProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Deployments.Models.ArmDeploymentProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Deployments.Models.ArmDeploymentProperties>
    {
        public ArmDeploymentProperties(Azure.ResourceManager.Resources.Deployments.Models.ArmDeploymentMode mode) { }
        public string DebugSettingDetailLevel { get { throw null; } set { } }
        public Azure.ResourceManager.Resources.Deployments.Models.ErrorDeployment ErrorDeployment { get { throw null; } set { } }
        public Azure.ResourceManager.Resources.Deployments.Models.ExpressionEvaluationScope? ExpressionEvaluationScope { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, System.Collections.Generic.IDictionary<string, Azure.ResourceManager.Resources.Deployments.Models.ArmDeploymentExtensionConfigItem>> ExtensionConfigs { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, Azure.ResourceManager.Resources.Deployments.Models.ArmDeploymentExternalInputDefinition> ExternalInputDefinitions { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, Azure.ResourceManager.Resources.Deployments.Models.ArmDeploymentExternalInput> ExternalInputs { get { throw null; } }
        public Azure.ResourceManager.Resources.Deployments.Models.ArmDeploymentMode Mode { get { throw null; } }
        public System.BinaryData Parameters { get { throw null; } set { } }
        public Azure.ResourceManager.Resources.Deployments.Models.ArmDeploymentParametersLink ParametersLink { get { throw null; } set { } }
        public System.BinaryData Template { get { throw null; } set { } }
        public Azure.ResourceManager.Resources.Deployments.Models.ArmDeploymentTemplateLink TemplateLink { get { throw null; } set { } }
        public Azure.ResourceManager.Resources.Deployments.Models.ValidationLevel? ValidationLevel { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.Deployments.Models.ArmDeploymentProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Deployments.Models.ArmDeploymentProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Deployments.Models.ArmDeploymentProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.Deployments.Models.ArmDeploymentProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Deployments.Models.ArmDeploymentProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Deployments.Models.ArmDeploymentProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Deployments.Models.ArmDeploymentProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ArmDeploymentPropertiesExtended : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Deployments.Models.ArmDeploymentPropertiesExtended>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Deployments.Models.ArmDeploymentPropertiesExtended>
    {
        internal ArmDeploymentPropertiesExtended() { }
        public string CorrelationId { get { throw null; } }
        public string DebugSettingDetailLevel { get { throw null; } [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)] set { } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Resources.Deployments.Models.ArmDependency> Dependencies { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Resources.Deployments.Models.DeploymentDiagnosticsDefinition> Diagnostics { get { throw null; } }
        public System.TimeSpan? Duration { get { throw null; } }
        public Azure.ResponseError Error { get { throw null; } }
        public Azure.ResourceManager.Resources.Deployments.Models.ErrorDeploymentExtended ErrorDeployment { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Resources.Deployments.Models.ArmDeploymentExtensionDefinition> Extensions { get { throw null; } }
        public Azure.ResourceManager.Resources.Deployments.Models.ArmDeploymentMode? Mode { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Resources.Deployments.Models.ArmResourceReference> OutputResourceDetails { get { throw null; } }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Resources.Models.SubResource> OutputResources { get { throw null; } }
        public System.BinaryData Outputs { get { throw null; } }
        public System.BinaryData Parameters { get { throw null; } }
        public Azure.ResourceManager.Resources.Deployments.Models.ArmDeploymentParametersLink ParametersLink { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Resources.Deployments.Models.Provider> Providers { get { throw null; } }
        public Azure.ResourceManager.Resources.Deployments.Models.ResourcesProvisioningState? ProvisioningState { get { throw null; } }
        public string TemplateHash { get { throw null; } }
        public Azure.ResourceManager.Resources.Deployments.Models.ArmDeploymentTemplateLink TemplateLink { get { throw null; } }
        public System.DateTimeOffset? Timestamp { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Resources.Deployments.Models.ArmResourceReference> ValidatedResourceDetails { get { throw null; } }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Resources.Models.SubResource> ValidatedResources { get { throw null; } }
        public Azure.ResourceManager.Resources.Deployments.Models.ValidationLevel? ValidationLevel { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.Deployments.Models.ArmDeploymentPropertiesExtended System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Deployments.Models.ArmDeploymentPropertiesExtended>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Deployments.Models.ArmDeploymentPropertiesExtended>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.Deployments.Models.ArmDeploymentPropertiesExtended System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Deployments.Models.ArmDeploymentPropertiesExtended>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Deployments.Models.ArmDeploymentPropertiesExtended>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Deployments.Models.ArmDeploymentPropertiesExtended>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ArmDeploymentTemplateLink : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Deployments.Models.ArmDeploymentTemplateLink>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Deployments.Models.ArmDeploymentTemplateLink>
    {
        public ArmDeploymentTemplateLink() { }
        public string ContentVersion { get { throw null; } set { } }
        public string Id { get { throw null; } set { } }
        public string QueryString { get { throw null; } set { } }
        public string RelativePath { get { throw null; } set { } }
        public System.Uri Uri { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.Deployments.Models.ArmDeploymentTemplateLink System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Deployments.Models.ArmDeploymentTemplateLink>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Deployments.Models.ArmDeploymentTemplateLink>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.Deployments.Models.ArmDeploymentTemplateLink System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Deployments.Models.ArmDeploymentTemplateLink>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Deployments.Models.ArmDeploymentTemplateLink>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Deployments.Models.ArmDeploymentTemplateLink>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ArmDeploymentValidateResult : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Deployments.Models.ArmDeploymentValidateResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Deployments.Models.ArmDeploymentValidateResult>
    {
        internal ArmDeploymentValidateResult() { }
        public Azure.ResponseError Error { get { throw null; } }
        public Azure.ResourceManager.Resources.Deployments.Models.ArmDeploymentPropertiesExtended Properties { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.Deployments.Models.ArmDeploymentValidateResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Deployments.Models.ArmDeploymentValidateResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Deployments.Models.ArmDeploymentValidateResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.Deployments.Models.ArmDeploymentValidateResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Deployments.Models.ArmDeploymentValidateResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Deployments.Models.ArmDeploymentValidateResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Deployments.Models.ArmDeploymentValidateResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ArmDeploymentWhatIfContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Deployments.Models.ArmDeploymentWhatIfContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Deployments.Models.ArmDeploymentWhatIfContent>
    {
        public ArmDeploymentWhatIfContent(Azure.ResourceManager.Resources.Deployments.Models.ArmDeploymentWhatIfProperties properties) { }
        public Azure.Core.AzureLocation? Location { get { throw null; } set { } }
        public Azure.ResourceManager.Resources.Deployments.Models.ArmDeploymentWhatIfProperties Properties { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.Deployments.Models.ArmDeploymentWhatIfContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Deployments.Models.ArmDeploymentWhatIfContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Deployments.Models.ArmDeploymentWhatIfContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.Deployments.Models.ArmDeploymentWhatIfContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Deployments.Models.ArmDeploymentWhatIfContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Deployments.Models.ArmDeploymentWhatIfContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Deployments.Models.ArmDeploymentWhatIfContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ArmDeploymentWhatIfProperties : Azure.ResourceManager.Resources.Deployments.Models.ArmDeploymentProperties, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Deployments.Models.ArmDeploymentWhatIfProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Deployments.Models.ArmDeploymentWhatIfProperties>
    {
        public ArmDeploymentWhatIfProperties(Azure.ResourceManager.Resources.Deployments.Models.ArmDeploymentMode mode) : base (default(Azure.ResourceManager.Resources.Deployments.Models.ArmDeploymentMode)) { }
        public Azure.ResourceManager.Resources.Deployments.Models.WhatIfResultFormat? WhatIfResultFormat { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.Deployments.Models.ArmDeploymentWhatIfProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Deployments.Models.ArmDeploymentWhatIfProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Deployments.Models.ArmDeploymentWhatIfProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.Deployments.Models.ArmDeploymentWhatIfProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Deployments.Models.ArmDeploymentWhatIfProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Deployments.Models.ArmDeploymentWhatIfProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Deployments.Models.ArmDeploymentWhatIfProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ArmResourceReference : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Deployments.Models.ArmResourceReference>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Deployments.Models.ArmResourceReference>
    {
        internal ArmResourceReference() { }
        public string ApiVersion { get { throw null; } }
        public Azure.ResourceManager.Resources.Deployments.Models.ArmDeploymentExtensionDefinition Extension { get { throw null; } }
        public Azure.Core.ResourceIdentifier Id { get { throw null; } }
        public System.BinaryData Identifiers { get { throw null; } }
        public string ResourceType { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.Deployments.Models.ArmResourceReference System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Deployments.Models.ArmResourceReference>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Deployments.Models.ArmResourceReference>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.Deployments.Models.ArmResourceReference System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Deployments.Models.ArmResourceReference>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Deployments.Models.ArmResourceReference>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Deployments.Models.ArmResourceReference>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public static partial class ArmResourcesDeploymentsModelFactory
    {
        public static Azure.ResourceManager.Resources.Deployments.Models.ApiProfile ApiProfile(string profileVersion = null, string apiVersion = null) { throw null; }
        public static Azure.ResourceManager.Resources.Deployments.Models.ArmDependency ArmDependency(System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Deployments.Models.BasicArmDependency> dependsOn = null, string id = null, Azure.Core.ResourceType? resourceType = default(Azure.Core.ResourceType?), string resourceName = null) { throw null; }
        public static Azure.ResourceManager.Resources.Deployments.Models.ArmDeploymentContent ArmDeploymentContent(Azure.Core.AzureLocation? location = default(Azure.Core.AzureLocation?), Azure.ResourceManager.Resources.Deployments.Models.ArmDeploymentProperties properties = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.ResourceManager.Resources.Deployments.Models.DeploymentIdentity identity = null) { throw null; }
        public static Azure.ResourceManager.Resources.Deployments.ArmDeploymentData ArmDeploymentData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.Core.AzureLocation? location = default(Azure.Core.AzureLocation?), Azure.ResourceManager.Resources.Deployments.Models.ArmDeploymentPropertiesExtended properties = null, System.Collections.Generic.IReadOnlyDictionary<string, string> tags = null) { throw null; }
        public static Azure.ResourceManager.Resources.Deployments.Models.ArmDeploymentExportResult ArmDeploymentExportResult(System.BinaryData template = null) { throw null; }
        public static Azure.ResourceManager.Resources.Deployments.Models.ArmDeploymentExtensionConfigItem ArmDeploymentExtensionConfigItem(Azure.ResourceManager.Resources.Deployments.Models.ExtensionConfigPropertyType? extensionConfigPropertyType = default(Azure.ResourceManager.Resources.Deployments.Models.ExtensionConfigPropertyType?), System.BinaryData value = null, Azure.ResourceManager.Resources.Deployments.Models.KeyVaultParameterReference keyVaultReference = null) { throw null; }
        public static Azure.ResourceManager.Resources.Deployments.Models.ArmDeploymentExtensionDefinition ArmDeploymentExtensionDefinition(string alias = null, string name = null, string version = null, string configId = null, System.Collections.Generic.IReadOnlyDictionary<string, Azure.ResourceManager.Resources.Deployments.Models.ArmDeploymentExtensionConfigItem> config = null) { throw null; }
        public static Azure.ResourceManager.Resources.Deployments.Models.ArmDeploymentExternalInputDefinition ArmDeploymentExternalInputDefinition(string kind = null, System.BinaryData config = null) { throw null; }
        public static Azure.ResourceManager.Resources.Deployments.Models.ArmDeploymentOperation ArmDeploymentOperation(string id = null, string operationId = null, Azure.ResourceManager.Resources.Deployments.Models.ArmDeploymentOperationProperties properties = null) { throw null; }
        public static Azure.ResourceManager.Resources.Deployments.Models.ArmDeploymentOperationProperties ArmDeploymentOperationProperties(Azure.ResourceManager.Resources.Deployments.Models.ProvisioningOperationKind? provisioningOperation = default(Azure.ResourceManager.Resources.Deployments.Models.ProvisioningOperationKind?), string provisioningState = null, System.DateTimeOffset? timestamp = default(System.DateTimeOffset?), System.TimeSpan? duration = default(System.TimeSpan?), string serviceRequestId = null, string statusCode = null, Azure.ResourceManager.Resources.Deployments.Models.StatusMessage statusMessage = null, Azure.ResourceManager.Resources.Deployments.Models.TargetResource targetResource = null, System.BinaryData requestContent = null, System.BinaryData responseContent = null) { throw null; }
        public static Azure.ResourceManager.Resources.Deployments.Models.ArmDeploymentProperties ArmDeploymentProperties(System.BinaryData template = null, Azure.ResourceManager.Resources.Deployments.Models.ArmDeploymentTemplateLink templateLink = null, System.BinaryData parameters = null, System.Collections.Generic.IDictionary<string, Azure.ResourceManager.Resources.Deployments.Models.ArmDeploymentExternalInput> externalInputs = null, System.Collections.Generic.IDictionary<string, Azure.ResourceManager.Resources.Deployments.Models.ArmDeploymentExternalInputDefinition> externalInputDefinitions = null, Azure.ResourceManager.Resources.Deployments.Models.ArmDeploymentParametersLink parametersLink = null, System.Collections.Generic.IDictionary<string, System.Collections.Generic.IDictionary<string, Azure.ResourceManager.Resources.Deployments.Models.ArmDeploymentExtensionConfigItem>> extensionConfigs = null, Azure.ResourceManager.Resources.Deployments.Models.ArmDeploymentMode mode = Azure.ResourceManager.Resources.Deployments.Models.ArmDeploymentMode.Incremental, string debugSettingDetailLevel = null, Azure.ResourceManager.Resources.Deployments.Models.ErrorDeployment errorDeployment = null, Azure.ResourceManager.Resources.Deployments.Models.ExpressionEvaluationScope? expressionEvaluationScope = default(Azure.ResourceManager.Resources.Deployments.Models.ExpressionEvaluationScope?), Azure.ResourceManager.Resources.Deployments.Models.ValidationLevel? validationLevel = default(Azure.ResourceManager.Resources.Deployments.Models.ValidationLevel?)) { throw null; }
        public static Azure.ResourceManager.Resources.Deployments.Models.ArmDeploymentPropertiesExtended ArmDeploymentPropertiesExtended(Azure.ResourceManager.Resources.Deployments.Models.ResourcesProvisioningState? provisioningState = default(Azure.ResourceManager.Resources.Deployments.Models.ResourcesProvisioningState?), string correlationId = null, System.DateTimeOffset? timestamp = default(System.DateTimeOffset?), System.TimeSpan? duration = default(System.TimeSpan?), System.BinaryData outputs = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Deployments.Models.Provider> providers = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Deployments.Models.ArmDependency> dependencies = null, Azure.ResourceManager.Resources.Deployments.Models.ArmDeploymentTemplateLink templateLink = null, System.BinaryData parameters = null, Azure.ResourceManager.Resources.Deployments.Models.ArmDeploymentParametersLink parametersLink = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Deployments.Models.ArmDeploymentExtensionDefinition> extensions = null, Azure.ResourceManager.Resources.Deployments.Models.ArmDeploymentMode? mode = default(Azure.ResourceManager.Resources.Deployments.Models.ArmDeploymentMode?), string debugSettingDetailLevel = null, Azure.ResourceManager.Resources.Deployments.Models.ErrorDeploymentExtended errorDeployment = null, string templateHash = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Deployments.Models.ArmResourceReference> outputResourceDetails = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Deployments.Models.ArmResourceReference> validatedResourceDetails = null, Azure.ResponseError error = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Deployments.Models.DeploymentDiagnosticsDefinition> diagnostics = null, Azure.ResourceManager.Resources.Deployments.Models.ValidationLevel? validationLevel = default(Azure.ResourceManager.Resources.Deployments.Models.ValidationLevel?)) { throw null; }
        public static Azure.ResourceManager.Resources.Deployments.Models.ArmDeploymentValidateResult ArmDeploymentValidateResult(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResponseError error = null, Azure.ResourceManager.Resources.Deployments.Models.ArmDeploymentPropertiesExtended properties = null) { throw null; }
        public static Azure.ResourceManager.Resources.Deployments.Models.ArmDeploymentWhatIfContent ArmDeploymentWhatIfContent(Azure.Core.AzureLocation? location = default(Azure.Core.AzureLocation?), Azure.ResourceManager.Resources.Deployments.Models.ArmDeploymentWhatIfProperties properties = null) { throw null; }
        public static Azure.ResourceManager.Resources.Deployments.Models.ArmDeploymentWhatIfProperties ArmDeploymentWhatIfProperties(System.BinaryData template = null, Azure.ResourceManager.Resources.Deployments.Models.ArmDeploymentTemplateLink templateLink = null, System.BinaryData parameters = null, System.Collections.Generic.IDictionary<string, Azure.ResourceManager.Resources.Deployments.Models.ArmDeploymentExternalInput> externalInputs = null, System.Collections.Generic.IDictionary<string, Azure.ResourceManager.Resources.Deployments.Models.ArmDeploymentExternalInputDefinition> externalInputDefinitions = null, Azure.ResourceManager.Resources.Deployments.Models.ArmDeploymentParametersLink parametersLink = null, System.Collections.Generic.IDictionary<string, System.Collections.Generic.IDictionary<string, Azure.ResourceManager.Resources.Deployments.Models.ArmDeploymentExtensionConfigItem>> extensionConfigs = null, Azure.ResourceManager.Resources.Deployments.Models.ArmDeploymentMode mode = Azure.ResourceManager.Resources.Deployments.Models.ArmDeploymentMode.Incremental, string debugSettingDetailLevel = null, Azure.ResourceManager.Resources.Deployments.Models.ErrorDeployment errorDeployment = null, Azure.ResourceManager.Resources.Deployments.Models.ExpressionEvaluationScope? expressionEvaluationScope = default(Azure.ResourceManager.Resources.Deployments.Models.ExpressionEvaluationScope?), Azure.ResourceManager.Resources.Deployments.Models.ValidationLevel? validationLevel = default(Azure.ResourceManager.Resources.Deployments.Models.ValidationLevel?), Azure.ResourceManager.Resources.Deployments.Models.WhatIfResultFormat? whatIfResultFormat = default(Azure.ResourceManager.Resources.Deployments.Models.WhatIfResultFormat?)) { throw null; }
        public static Azure.ResourceManager.Resources.Deployments.Models.ArmResourceReference ArmResourceReference(Azure.Core.ResourceIdentifier id = null, Azure.ResourceManager.Resources.Deployments.Models.ArmDeploymentExtensionDefinition extension = null, string resourceType = null, System.BinaryData identifiers = null, string apiVersion = null) { throw null; }
        public static Azure.ResourceManager.Resources.Deployments.Models.BasicArmDependency BasicArmDependency(string id = null, Azure.Core.ResourceType? resourceType = default(Azure.Core.ResourceType?), string resourceName = null) { throw null; }
        public static Azure.ResourceManager.Resources.Deployments.Models.DeploymentDiagnosticsDefinition DeploymentDiagnosticsDefinition(Azure.ResourceManager.Resources.Deployments.Models.Level level = default(Azure.ResourceManager.Resources.Deployments.Models.Level), string code = null, string message = null, string target = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Deployments.Models.ErrorAdditionalInfo> additionalInfo = null) { throw null; }
        public static Azure.ResourceManager.Resources.Deployments.Models.DeploymentIdentity DeploymentIdentity(Azure.ResourceManager.Resources.Deployments.Models.DeploymentIdentityType identityType = default(Azure.ResourceManager.Resources.Deployments.Models.DeploymentIdentityType), System.Collections.Generic.IDictionary<string, Azure.ResourceManager.Models.UserAssignedIdentity> userAssignedIdentities = null) { throw null; }
        public static Azure.ResourceManager.Resources.Deployments.Models.ErrorAdditionalInfo ErrorAdditionalInfo(string errorAdditionalInfoType = null, System.BinaryData info = null) { throw null; }
        public static Azure.ResourceManager.Resources.Deployments.Models.ErrorDeploymentExtended ErrorDeploymentExtended(string provisioningState = null, Azure.ResourceManager.Resources.Deployments.Models.ErrorDeploymentType? deploymentType = default(Azure.ResourceManager.Resources.Deployments.Models.ErrorDeploymentType?), string deploymentName = null) { throw null; }
        public static Azure.ResourceManager.Resources.Deployments.Models.Provider Provider(string id = null, string @namespace = null, string registrationState = null, string registrationPolicy = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Deployments.Models.ProviderResourceType> resourceTypes = null, Azure.ResourceManager.Resources.Deployments.Models.ProviderAuthorizationConsentState? providerAuthorizationConsentState = default(Azure.ResourceManager.Resources.Deployments.Models.ProviderAuthorizationConsentState?)) { throw null; }
        public static Azure.ResourceManager.Resources.Deployments.Models.ProviderExtendedLocation ProviderExtendedLocation(Azure.Core.AzureLocation? location = default(Azure.Core.AzureLocation?), string providerExtendedLocationType = null, System.Collections.Generic.IEnumerable<string> extendedLocations = null) { throw null; }
        public static Azure.ResourceManager.Resources.Deployments.Models.ProviderResourceType ProviderResourceType(string resourceType = null, System.Collections.Generic.IEnumerable<string> locations = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Deployments.Models.ProviderExtendedLocation> locationMappings = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Deployments.Models.ResourceTypeAlias> aliases = null, System.Collections.Generic.IEnumerable<string> apiVersions = null, string defaultApiVersion = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Deployments.Models.ZoneMapping> zoneMappings = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Deployments.Models.ApiProfile> apiProfiles = null, string capabilities = null, System.Collections.Generic.IReadOnlyDictionary<string, string> properties = null) { throw null; }
        public static Azure.ResourceManager.Resources.Deployments.Models.ResourceTypeAlias ResourceTypeAlias(string name = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Deployments.Models.ResourceTypeAliasPath> paths = null, Azure.ResourceManager.Resources.Deployments.Models.ResourceTypeAliasType? aliasType = default(Azure.ResourceManager.Resources.Deployments.Models.ResourceTypeAliasType?), string defaultPath = null, Azure.ResourceManager.Resources.Deployments.Models.ResourceTypeAliasPattern defaultPattern = null, Azure.ResourceManager.Resources.Deployments.Models.ResourceTypeAliasPathMetadata defaultMetadata = null) { throw null; }
        public static Azure.ResourceManager.Resources.Deployments.Models.ResourceTypeAliasPath ResourceTypeAliasPath(string path = null, System.Collections.Generic.IEnumerable<string> apiVersions = null, Azure.ResourceManager.Resources.Deployments.Models.ResourceTypeAliasPattern pattern = null, Azure.ResourceManager.Resources.Deployments.Models.ResourceTypeAliasPathMetadata metadata = null) { throw null; }
        public static Azure.ResourceManager.Resources.Deployments.Models.ResourceTypeAliasPathMetadata ResourceTypeAliasPathMetadata(Azure.ResourceManager.Resources.Deployments.Models.ResourceTypeAliasPathTokenType? tokenType = default(Azure.ResourceManager.Resources.Deployments.Models.ResourceTypeAliasPathTokenType?), Azure.ResourceManager.Resources.Deployments.Models.ResourceTypeAliasPathAttribute? attributes = default(Azure.ResourceManager.Resources.Deployments.Models.ResourceTypeAliasPathAttribute?)) { throw null; }
        public static Azure.ResourceManager.Resources.Deployments.Models.ResourceTypeAliasPattern ResourceTypeAliasPattern(string phrase = null, string variable = null, Azure.ResourceManager.Resources.Deployments.Models.ResourceTypeAliasPatternType? patternType = default(Azure.ResourceManager.Resources.Deployments.Models.ResourceTypeAliasPatternType?)) { throw null; }
        public static Azure.ResourceManager.Resources.Deployments.Models.StatusMessage StatusMessage(string status = null, Azure.ResponseError error = null) { throw null; }
        public static Azure.ResourceManager.Resources.Deployments.Models.TargetResource TargetResource(string id = null, string resourceName = null, Azure.Core.ResourceType? resourceType = default(Azure.Core.ResourceType?), Azure.ResourceManager.Resources.Deployments.Models.ArmDeploymentExtensionDefinition extension = null, System.BinaryData identifiers = null, string apiVersion = null, string symbolicName = null) { throw null; }
        public static Azure.ResourceManager.Resources.Deployments.Models.TemplateHashResult TemplateHashResult(string minifiedTemplate = null, string templateHash = null) { throw null; }
        public static Azure.ResourceManager.Resources.Deployments.Models.WhatIfChange WhatIfChange(string resourceId = null, string deploymentId = null, string symbolicName = null, System.BinaryData identifiers = null, Azure.ResourceManager.Resources.Deployments.Models.ArmDeploymentExtensionDefinition extension = null, Azure.ResourceManager.Resources.Deployments.Models.WhatIfChangeType changeType = Azure.ResourceManager.Resources.Deployments.Models.WhatIfChangeType.Create, string unsupportedReason = null, System.BinaryData before = null, System.BinaryData after = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Deployments.Models.WhatIfPropertyChange> delta = null) { throw null; }
        public static Azure.ResourceManager.Resources.Deployments.Models.WhatIfOperationResult WhatIfOperationResult(string status = null, Azure.ResponseError error = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Deployments.Models.WhatIfChange> changes = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Deployments.Models.WhatIfChange> potentialChanges = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Deployments.Models.DeploymentDiagnosticsDefinition> diagnostics = null) { throw null; }
        public static Azure.ResourceManager.Resources.Deployments.Models.WhatIfPropertyChange WhatIfPropertyChange(string path = null, Azure.ResourceManager.Resources.Deployments.Models.WhatIfPropertyChangeType propertyChangeType = Azure.ResourceManager.Resources.Deployments.Models.WhatIfPropertyChangeType.Create, System.BinaryData before = null, System.BinaryData after = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Deployments.Models.WhatIfPropertyChange> children = null) { throw null; }
        public static Azure.ResourceManager.Resources.Deployments.Models.ZoneMapping ZoneMapping(Azure.Core.AzureLocation? location = default(Azure.Core.AzureLocation?), System.Collections.Generic.IEnumerable<string> zones = null) { throw null; }
    }
    public partial class BasicArmDependency : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Deployments.Models.BasicArmDependency>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Deployments.Models.BasicArmDependency>
    {
        internal BasicArmDependency() { }
        public string Id { get { throw null; } }
        public string ResourceName { get { throw null; } }
        public Azure.Core.ResourceType? ResourceType { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.Deployments.Models.BasicArmDependency System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Deployments.Models.BasicArmDependency>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Deployments.Models.BasicArmDependency>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.Deployments.Models.BasicArmDependency System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Deployments.Models.BasicArmDependency>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Deployments.Models.BasicArmDependency>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Deployments.Models.BasicArmDependency>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DeploymentDiagnosticsDefinition : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Deployments.Models.DeploymentDiagnosticsDefinition>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Deployments.Models.DeploymentDiagnosticsDefinition>
    {
        internal DeploymentDiagnosticsDefinition() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Resources.Deployments.Models.ErrorAdditionalInfo> AdditionalInfo { get { throw null; } }
        public string Code { get { throw null; } }
        public Azure.ResourceManager.Resources.Deployments.Models.Level Level { get { throw null; } }
        public string Message { get { throw null; } }
        public string Target { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.Deployments.Models.DeploymentDiagnosticsDefinition System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Deployments.Models.DeploymentDiagnosticsDefinition>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Deployments.Models.DeploymentDiagnosticsDefinition>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.Deployments.Models.DeploymentDiagnosticsDefinition System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Deployments.Models.DeploymentDiagnosticsDefinition>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Deployments.Models.DeploymentDiagnosticsDefinition>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Deployments.Models.DeploymentDiagnosticsDefinition>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DeploymentIdentity : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Deployments.Models.DeploymentIdentity>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Deployments.Models.DeploymentIdentity>
    {
        public DeploymentIdentity(Azure.ResourceManager.Resources.Deployments.Models.DeploymentIdentityType identityType) { }
        public Azure.ResourceManager.Resources.Deployments.Models.DeploymentIdentityType IdentityType { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, Azure.ResourceManager.Models.UserAssignedIdentity> UserAssignedIdentities { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.Deployments.Models.DeploymentIdentity System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Deployments.Models.DeploymentIdentity>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Deployments.Models.DeploymentIdentity>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.Deployments.Models.DeploymentIdentity System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Deployments.Models.DeploymentIdentity>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Deployments.Models.DeploymentIdentity>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Deployments.Models.DeploymentIdentity>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DeploymentIdentityType : System.IEquatable<Azure.ResourceManager.Resources.Deployments.Models.DeploymentIdentityType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DeploymentIdentityType(string value) { throw null; }
        public static Azure.ResourceManager.Resources.Deployments.Models.DeploymentIdentityType None { get { throw null; } }
        public static Azure.ResourceManager.Resources.Deployments.Models.DeploymentIdentityType UserAssigned { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Resources.Deployments.Models.DeploymentIdentityType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Resources.Deployments.Models.DeploymentIdentityType left, Azure.ResourceManager.Resources.Deployments.Models.DeploymentIdentityType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Resources.Deployments.Models.DeploymentIdentityType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Resources.Deployments.Models.DeploymentIdentityType left, Azure.ResourceManager.Resources.Deployments.Models.DeploymentIdentityType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ErrorAdditionalInfo : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Deployments.Models.ErrorAdditionalInfo>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Deployments.Models.ErrorAdditionalInfo>
    {
        internal ErrorAdditionalInfo() { }
        public string ErrorAdditionalInfoType { get { throw null; } }
        public System.BinaryData Info { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.Deployments.Models.ErrorAdditionalInfo System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Deployments.Models.ErrorAdditionalInfo>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Deployments.Models.ErrorAdditionalInfo>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.Deployments.Models.ErrorAdditionalInfo System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Deployments.Models.ErrorAdditionalInfo>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Deployments.Models.ErrorAdditionalInfo>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Deployments.Models.ErrorAdditionalInfo>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ErrorDeployment : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Deployments.Models.ErrorDeployment>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Deployments.Models.ErrorDeployment>
    {
        public ErrorDeployment() { }
        public string DeploymentName { get { throw null; } set { } }
        public Azure.ResourceManager.Resources.Deployments.Models.ErrorDeploymentType? DeploymentType { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.Deployments.Models.ErrorDeployment System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Deployments.Models.ErrorDeployment>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Deployments.Models.ErrorDeployment>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.Deployments.Models.ErrorDeployment System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Deployments.Models.ErrorDeployment>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Deployments.Models.ErrorDeployment>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Deployments.Models.ErrorDeployment>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ErrorDeploymentExtended : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Deployments.Models.ErrorDeploymentExtended>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Deployments.Models.ErrorDeploymentExtended>
    {
        internal ErrorDeploymentExtended() { }
        public string DeploymentName { get { throw null; } }
        public Azure.ResourceManager.Resources.Deployments.Models.ErrorDeploymentType? DeploymentType { get { throw null; } }
        public string ProvisioningState { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.Deployments.Models.ErrorDeploymentExtended System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Deployments.Models.ErrorDeploymentExtended>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Deployments.Models.ErrorDeploymentExtended>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.Deployments.Models.ErrorDeploymentExtended System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Deployments.Models.ErrorDeploymentExtended>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Deployments.Models.ErrorDeploymentExtended>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Deployments.Models.ErrorDeploymentExtended>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public enum ErrorDeploymentType
    {
        LastSuccessful = 0,
        SpecificDeployment = 1,
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ExpressionEvaluationScope : System.IEquatable<Azure.ResourceManager.Resources.Deployments.Models.ExpressionEvaluationScope>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ExpressionEvaluationScope(string value) { throw null; }
        public static Azure.ResourceManager.Resources.Deployments.Models.ExpressionEvaluationScope Inner { get { throw null; } }
        public static Azure.ResourceManager.Resources.Deployments.Models.ExpressionEvaluationScope NotSpecified { get { throw null; } }
        public static Azure.ResourceManager.Resources.Deployments.Models.ExpressionEvaluationScope Outer { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Resources.Deployments.Models.ExpressionEvaluationScope other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Resources.Deployments.Models.ExpressionEvaluationScope left, Azure.ResourceManager.Resources.Deployments.Models.ExpressionEvaluationScope right) { throw null; }
        public static implicit operator Azure.ResourceManager.Resources.Deployments.Models.ExpressionEvaluationScope (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Resources.Deployments.Models.ExpressionEvaluationScope left, Azure.ResourceManager.Resources.Deployments.Models.ExpressionEvaluationScope right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ExtensionConfigPropertyType : System.IEquatable<Azure.ResourceManager.Resources.Deployments.Models.ExtensionConfigPropertyType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ExtensionConfigPropertyType(string value) { throw null; }
        public static Azure.ResourceManager.Resources.Deployments.Models.ExtensionConfigPropertyType Array { get { throw null; } }
        public static Azure.ResourceManager.Resources.Deployments.Models.ExtensionConfigPropertyType Bool { get { throw null; } }
        public static Azure.ResourceManager.Resources.Deployments.Models.ExtensionConfigPropertyType Int { get { throw null; } }
        public static Azure.ResourceManager.Resources.Deployments.Models.ExtensionConfigPropertyType Object { get { throw null; } }
        public static Azure.ResourceManager.Resources.Deployments.Models.ExtensionConfigPropertyType SecureObject { get { throw null; } }
        public static Azure.ResourceManager.Resources.Deployments.Models.ExtensionConfigPropertyType SecureString { get { throw null; } }
        public static Azure.ResourceManager.Resources.Deployments.Models.ExtensionConfigPropertyType String { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Resources.Deployments.Models.ExtensionConfigPropertyType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Resources.Deployments.Models.ExtensionConfigPropertyType left, Azure.ResourceManager.Resources.Deployments.Models.ExtensionConfigPropertyType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Resources.Deployments.Models.ExtensionConfigPropertyType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Resources.Deployments.Models.ExtensionConfigPropertyType left, Azure.ResourceManager.Resources.Deployments.Models.ExtensionConfigPropertyType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class KeyVaultParameterReference : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Deployments.Models.KeyVaultParameterReference>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Deployments.Models.KeyVaultParameterReference>
    {
        public KeyVaultParameterReference(Azure.ResourceManager.Resources.Models.WritableSubResource keyVault, string secretName) { }
        public Azure.Core.ResourceIdentifier KeyVaultId { get { throw null; } set { } }
        public string SecretName { get { throw null; } set { } }
        public string SecretVersion { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.Deployments.Models.KeyVaultParameterReference System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Deployments.Models.KeyVaultParameterReference>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Deployments.Models.KeyVaultParameterReference>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.Deployments.Models.KeyVaultParameterReference System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Deployments.Models.KeyVaultParameterReference>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Deployments.Models.KeyVaultParameterReference>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Deployments.Models.KeyVaultParameterReference>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct Level : System.IEquatable<Azure.ResourceManager.Resources.Deployments.Models.Level>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public Level(string value) { throw null; }
        public static Azure.ResourceManager.Resources.Deployments.Models.Level Error { get { throw null; } }
        public static Azure.ResourceManager.Resources.Deployments.Models.Level Info { get { throw null; } }
        public static Azure.ResourceManager.Resources.Deployments.Models.Level Warning { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Resources.Deployments.Models.Level other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Resources.Deployments.Models.Level left, Azure.ResourceManager.Resources.Deployments.Models.Level right) { throw null; }
        public static implicit operator Azure.ResourceManager.Resources.Deployments.Models.Level (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Resources.Deployments.Models.Level left, Azure.ResourceManager.Resources.Deployments.Models.Level right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class Provider : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Deployments.Models.Provider>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Deployments.Models.Provider>
    {
        internal Provider() { }
        public string Id { get { throw null; } }
        public string Namespace { get { throw null; } }
        public Azure.ResourceManager.Resources.Deployments.Models.ProviderAuthorizationConsentState? ProviderAuthorizationConsentState { get { throw null; } }
        public string RegistrationPolicy { get { throw null; } }
        public string RegistrationState { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Resources.Deployments.Models.ProviderResourceType> ResourceTypes { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.Deployments.Models.Provider System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Deployments.Models.Provider>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Deployments.Models.Provider>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.Deployments.Models.Provider System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Deployments.Models.Provider>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Deployments.Models.Provider>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Deployments.Models.Provider>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ProviderAuthorizationConsentState : System.IEquatable<Azure.ResourceManager.Resources.Deployments.Models.ProviderAuthorizationConsentState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ProviderAuthorizationConsentState(string value) { throw null; }
        public static Azure.ResourceManager.Resources.Deployments.Models.ProviderAuthorizationConsentState Consented { get { throw null; } }
        public static Azure.ResourceManager.Resources.Deployments.Models.ProviderAuthorizationConsentState NotRequired { get { throw null; } }
        public static Azure.ResourceManager.Resources.Deployments.Models.ProviderAuthorizationConsentState NotSpecified { get { throw null; } }
        public static Azure.ResourceManager.Resources.Deployments.Models.ProviderAuthorizationConsentState Required { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Resources.Deployments.Models.ProviderAuthorizationConsentState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Resources.Deployments.Models.ProviderAuthorizationConsentState left, Azure.ResourceManager.Resources.Deployments.Models.ProviderAuthorizationConsentState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Resources.Deployments.Models.ProviderAuthorizationConsentState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Resources.Deployments.Models.ProviderAuthorizationConsentState left, Azure.ResourceManager.Resources.Deployments.Models.ProviderAuthorizationConsentState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ProviderExtendedLocation : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Deployments.Models.ProviderExtendedLocation>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Deployments.Models.ProviderExtendedLocation>
    {
        internal ProviderExtendedLocation() { }
        public System.Collections.Generic.IReadOnlyList<string> ExtendedLocations { get { throw null; } }
        public Azure.Core.AzureLocation? Location { get { throw null; } }
        public string ProviderExtendedLocationType { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.Deployments.Models.ProviderExtendedLocation System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Deployments.Models.ProviderExtendedLocation>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Deployments.Models.ProviderExtendedLocation>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.Deployments.Models.ProviderExtendedLocation System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Deployments.Models.ProviderExtendedLocation>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Deployments.Models.ProviderExtendedLocation>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Deployments.Models.ProviderExtendedLocation>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ProviderResourceType : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Deployments.Models.ProviderResourceType>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Deployments.Models.ProviderResourceType>
    {
        internal ProviderResourceType() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Resources.Deployments.Models.ResourceTypeAlias> Aliases { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Resources.Deployments.Models.ApiProfile> ApiProfiles { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> ApiVersions { get { throw null; } }
        public string Capabilities { get { throw null; } }
        public string DefaultApiVersion { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Resources.Deployments.Models.ProviderExtendedLocation> LocationMappings { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> Locations { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, string> Properties { get { throw null; } }
        public string ResourceType { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Resources.Deployments.Models.ZoneMapping> ZoneMappings { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.Deployments.Models.ProviderResourceType System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Deployments.Models.ProviderResourceType>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Deployments.Models.ProviderResourceType>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.Deployments.Models.ProviderResourceType System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Deployments.Models.ProviderResourceType>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Deployments.Models.ProviderResourceType>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Deployments.Models.ProviderResourceType>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public enum ProvisioningOperationKind
    {
        NotSpecified = 0,
        Create = 1,
        Delete = 2,
        Waiting = 3,
        AzureAsyncOperationWaiting = 4,
        ResourceCacheWaiting = 5,
        Action = 6,
        Read = 7,
        EvaluateDeploymentOutput = 8,
        DeploymentCleanup = 9,
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ResourcesProvisioningState : System.IEquatable<Azure.ResourceManager.Resources.Deployments.Models.ResourcesProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ResourcesProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.Resources.Deployments.Models.ResourcesProvisioningState Accepted { get { throw null; } }
        public static Azure.ResourceManager.Resources.Deployments.Models.ResourcesProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.Resources.Deployments.Models.ResourcesProvisioningState Created { get { throw null; } }
        public static Azure.ResourceManager.Resources.Deployments.Models.ResourcesProvisioningState Creating { get { throw null; } }
        public static Azure.ResourceManager.Resources.Deployments.Models.ResourcesProvisioningState Deleted { get { throw null; } }
        public static Azure.ResourceManager.Resources.Deployments.Models.ResourcesProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.Resources.Deployments.Models.ResourcesProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.Resources.Deployments.Models.ResourcesProvisioningState NotSpecified { get { throw null; } }
        public static Azure.ResourceManager.Resources.Deployments.Models.ResourcesProvisioningState Ready { get { throw null; } }
        public static Azure.ResourceManager.Resources.Deployments.Models.ResourcesProvisioningState Running { get { throw null; } }
        public static Azure.ResourceManager.Resources.Deployments.Models.ResourcesProvisioningState Succeeded { get { throw null; } }
        public static Azure.ResourceManager.Resources.Deployments.Models.ResourcesProvisioningState Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Resources.Deployments.Models.ResourcesProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Resources.Deployments.Models.ResourcesProvisioningState left, Azure.ResourceManager.Resources.Deployments.Models.ResourcesProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Resources.Deployments.Models.ResourcesProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Resources.Deployments.Models.ResourcesProvisioningState left, Azure.ResourceManager.Resources.Deployments.Models.ResourcesProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ResourceTypeAlias : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Deployments.Models.ResourceTypeAlias>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Deployments.Models.ResourceTypeAlias>
    {
        internal ResourceTypeAlias() { }
        public Azure.ResourceManager.Resources.Deployments.Models.ResourceTypeAliasType? AliasType { get { throw null; } }
        public Azure.ResourceManager.Resources.Deployments.Models.ResourceTypeAliasPathMetadata DefaultMetadata { get { throw null; } }
        public string DefaultPath { get { throw null; } }
        public Azure.ResourceManager.Resources.Deployments.Models.ResourceTypeAliasPattern DefaultPattern { get { throw null; } }
        public string Name { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Resources.Deployments.Models.ResourceTypeAliasPath> Paths { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.Deployments.Models.ResourceTypeAlias System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Deployments.Models.ResourceTypeAlias>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Deployments.Models.ResourceTypeAlias>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.Deployments.Models.ResourceTypeAlias System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Deployments.Models.ResourceTypeAlias>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Deployments.Models.ResourceTypeAlias>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Deployments.Models.ResourceTypeAlias>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ResourceTypeAliasPath : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Deployments.Models.ResourceTypeAliasPath>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Deployments.Models.ResourceTypeAliasPath>
    {
        internal ResourceTypeAliasPath() { }
        public System.Collections.Generic.IReadOnlyList<string> ApiVersions { get { throw null; } }
        public Azure.ResourceManager.Resources.Deployments.Models.ResourceTypeAliasPathMetadata Metadata { get { throw null; } }
        public string Path { get { throw null; } }
        public Azure.ResourceManager.Resources.Deployments.Models.ResourceTypeAliasPattern Pattern { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.Deployments.Models.ResourceTypeAliasPath System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Deployments.Models.ResourceTypeAliasPath>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Deployments.Models.ResourceTypeAliasPath>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.Deployments.Models.ResourceTypeAliasPath System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Deployments.Models.ResourceTypeAliasPath>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Deployments.Models.ResourceTypeAliasPath>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Deployments.Models.ResourceTypeAliasPath>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ResourceTypeAliasPathAttribute : System.IEquatable<Azure.ResourceManager.Resources.Deployments.Models.ResourceTypeAliasPathAttribute>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ResourceTypeAliasPathAttribute(string value) { throw null; }
        public static Azure.ResourceManager.Resources.Deployments.Models.ResourceTypeAliasPathAttribute Modifiable { get { throw null; } }
        public static Azure.ResourceManager.Resources.Deployments.Models.ResourceTypeAliasPathAttribute None { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Resources.Deployments.Models.ResourceTypeAliasPathAttribute other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Resources.Deployments.Models.ResourceTypeAliasPathAttribute left, Azure.ResourceManager.Resources.Deployments.Models.ResourceTypeAliasPathAttribute right) { throw null; }
        public static implicit operator Azure.ResourceManager.Resources.Deployments.Models.ResourceTypeAliasPathAttribute (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Resources.Deployments.Models.ResourceTypeAliasPathAttribute left, Azure.ResourceManager.Resources.Deployments.Models.ResourceTypeAliasPathAttribute right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ResourceTypeAliasPathMetadata : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Deployments.Models.ResourceTypeAliasPathMetadata>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Deployments.Models.ResourceTypeAliasPathMetadata>
    {
        internal ResourceTypeAliasPathMetadata() { }
        public Azure.ResourceManager.Resources.Deployments.Models.ResourceTypeAliasPathAttribute? Attributes { get { throw null; } }
        public Azure.ResourceManager.Resources.Deployments.Models.ResourceTypeAliasPathTokenType? TokenType { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.Deployments.Models.ResourceTypeAliasPathMetadata System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Deployments.Models.ResourceTypeAliasPathMetadata>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Deployments.Models.ResourceTypeAliasPathMetadata>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.Deployments.Models.ResourceTypeAliasPathMetadata System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Deployments.Models.ResourceTypeAliasPathMetadata>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Deployments.Models.ResourceTypeAliasPathMetadata>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Deployments.Models.ResourceTypeAliasPathMetadata>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ResourceTypeAliasPathTokenType : System.IEquatable<Azure.ResourceManager.Resources.Deployments.Models.ResourceTypeAliasPathTokenType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ResourceTypeAliasPathTokenType(string value) { throw null; }
        public static Azure.ResourceManager.Resources.Deployments.Models.ResourceTypeAliasPathTokenType Any { get { throw null; } }
        public static Azure.ResourceManager.Resources.Deployments.Models.ResourceTypeAliasPathTokenType Array { get { throw null; } }
        public static Azure.ResourceManager.Resources.Deployments.Models.ResourceTypeAliasPathTokenType Boolean { get { throw null; } }
        public static Azure.ResourceManager.Resources.Deployments.Models.ResourceTypeAliasPathTokenType Integer { get { throw null; } }
        public static Azure.ResourceManager.Resources.Deployments.Models.ResourceTypeAliasPathTokenType NotSpecified { get { throw null; } }
        public static Azure.ResourceManager.Resources.Deployments.Models.ResourceTypeAliasPathTokenType Number { get { throw null; } }
        public static Azure.ResourceManager.Resources.Deployments.Models.ResourceTypeAliasPathTokenType Object { get { throw null; } }
        public static Azure.ResourceManager.Resources.Deployments.Models.ResourceTypeAliasPathTokenType String { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Resources.Deployments.Models.ResourceTypeAliasPathTokenType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Resources.Deployments.Models.ResourceTypeAliasPathTokenType left, Azure.ResourceManager.Resources.Deployments.Models.ResourceTypeAliasPathTokenType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Resources.Deployments.Models.ResourceTypeAliasPathTokenType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Resources.Deployments.Models.ResourceTypeAliasPathTokenType left, Azure.ResourceManager.Resources.Deployments.Models.ResourceTypeAliasPathTokenType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ResourceTypeAliasPattern : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Deployments.Models.ResourceTypeAliasPattern>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Deployments.Models.ResourceTypeAliasPattern>
    {
        internal ResourceTypeAliasPattern() { }
        public Azure.ResourceManager.Resources.Deployments.Models.ResourceTypeAliasPatternType? PatternType { get { throw null; } }
        public string Phrase { get { throw null; } }
        public string Variable { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.Deployments.Models.ResourceTypeAliasPattern System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Deployments.Models.ResourceTypeAliasPattern>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Deployments.Models.ResourceTypeAliasPattern>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.Deployments.Models.ResourceTypeAliasPattern System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Deployments.Models.ResourceTypeAliasPattern>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Deployments.Models.ResourceTypeAliasPattern>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Deployments.Models.ResourceTypeAliasPattern>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public enum ResourceTypeAliasPatternType
    {
        NotSpecified = 0,
        Extract = 1,
    }
    public enum ResourceTypeAliasType
    {
        NotSpecified = 0,
        PlainText = 1,
        Mask = 2,
    }
    public partial class StatusMessage : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Deployments.Models.StatusMessage>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Deployments.Models.StatusMessage>
    {
        internal StatusMessage() { }
        public Azure.ResponseError Error { get { throw null; } }
        public string Status { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.Deployments.Models.StatusMessage System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Deployments.Models.StatusMessage>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Deployments.Models.StatusMessage>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.Deployments.Models.StatusMessage System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Deployments.Models.StatusMessage>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Deployments.Models.StatusMessage>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Deployments.Models.StatusMessage>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class TargetResource : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Deployments.Models.TargetResource>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Deployments.Models.TargetResource>
    {
        internal TargetResource() { }
        public string ApiVersion { get { throw null; } }
        public Azure.ResourceManager.Resources.Deployments.Models.ArmDeploymentExtensionDefinition Extension { get { throw null; } }
        public string Id { get { throw null; } }
        public System.BinaryData Identifiers { get { throw null; } }
        public string ResourceName { get { throw null; } }
        public Azure.Core.ResourceType? ResourceType { get { throw null; } }
        public string SymbolicName { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.Deployments.Models.TargetResource System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Deployments.Models.TargetResource>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Deployments.Models.TargetResource>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.Deployments.Models.TargetResource System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Deployments.Models.TargetResource>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Deployments.Models.TargetResource>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Deployments.Models.TargetResource>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class TemplateHashResult : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Deployments.Models.TemplateHashResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Deployments.Models.TemplateHashResult>
    {
        internal TemplateHashResult() { }
        public string MinifiedTemplate { get { throw null; } }
        public string TemplateHash { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.Deployments.Models.TemplateHashResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Deployments.Models.TemplateHashResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Deployments.Models.TemplateHashResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.Deployments.Models.TemplateHashResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Deployments.Models.TemplateHashResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Deployments.Models.TemplateHashResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Deployments.Models.TemplateHashResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ValidationLevel : System.IEquatable<Azure.ResourceManager.Resources.Deployments.Models.ValidationLevel>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ValidationLevel(string value) { throw null; }
        public static Azure.ResourceManager.Resources.Deployments.Models.ValidationLevel Provider { get { throw null; } }
        public static Azure.ResourceManager.Resources.Deployments.Models.ValidationLevel ProviderNoRbac { get { throw null; } }
        public static Azure.ResourceManager.Resources.Deployments.Models.ValidationLevel Template { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Resources.Deployments.Models.ValidationLevel other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Resources.Deployments.Models.ValidationLevel left, Azure.ResourceManager.Resources.Deployments.Models.ValidationLevel right) { throw null; }
        public static implicit operator Azure.ResourceManager.Resources.Deployments.Models.ValidationLevel (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Resources.Deployments.Models.ValidationLevel left, Azure.ResourceManager.Resources.Deployments.Models.ValidationLevel right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class WhatIfChange : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Deployments.Models.WhatIfChange>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Deployments.Models.WhatIfChange>
    {
        internal WhatIfChange() { }
        public System.BinaryData After { get { throw null; } }
        public System.BinaryData Before { get { throw null; } }
        public Azure.ResourceManager.Resources.Deployments.Models.WhatIfChangeType ChangeType { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Resources.Deployments.Models.WhatIfPropertyChange> Delta { get { throw null; } }
        public string DeploymentId { get { throw null; } }
        public Azure.ResourceManager.Resources.Deployments.Models.ArmDeploymentExtensionDefinition Extension { get { throw null; } }
        public System.BinaryData Identifiers { get { throw null; } }
        public string ResourceId { get { throw null; } }
        public string SymbolicName { get { throw null; } }
        public string UnsupportedReason { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.Deployments.Models.WhatIfChange System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Deployments.Models.WhatIfChange>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Deployments.Models.WhatIfChange>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.Deployments.Models.WhatIfChange System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Deployments.Models.WhatIfChange>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Deployments.Models.WhatIfChange>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Deployments.Models.WhatIfChange>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public enum WhatIfChangeType
    {
        Create = 0,
        Delete = 1,
        Ignore = 2,
        Deploy = 3,
        NoChange = 4,
        Modify = 5,
        Unsupported = 6,
    }
    public partial class WhatIfOperationResult : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Deployments.Models.WhatIfOperationResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Deployments.Models.WhatIfOperationResult>
    {
        internal WhatIfOperationResult() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Resources.Deployments.Models.WhatIfChange> Changes { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Resources.Deployments.Models.DeploymentDiagnosticsDefinition> Diagnostics { get { throw null; } }
        public Azure.ResponseError Error { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Resources.Deployments.Models.WhatIfChange> PotentialChanges { get { throw null; } }
        public string Status { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.Deployments.Models.WhatIfOperationResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Deployments.Models.WhatIfOperationResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Deployments.Models.WhatIfOperationResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.Deployments.Models.WhatIfOperationResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Deployments.Models.WhatIfOperationResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Deployments.Models.WhatIfOperationResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Deployments.Models.WhatIfOperationResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class WhatIfPropertyChange : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Deployments.Models.WhatIfPropertyChange>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Deployments.Models.WhatIfPropertyChange>
    {
        internal WhatIfPropertyChange() { }
        public System.BinaryData After { get { throw null; } }
        public System.BinaryData Before { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Resources.Deployments.Models.WhatIfPropertyChange> Children { get { throw null; } }
        public string Path { get { throw null; } }
        public Azure.ResourceManager.Resources.Deployments.Models.WhatIfPropertyChangeType PropertyChangeType { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.Deployments.Models.WhatIfPropertyChange System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Deployments.Models.WhatIfPropertyChange>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Deployments.Models.WhatIfPropertyChange>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.Deployments.Models.WhatIfPropertyChange System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Deployments.Models.WhatIfPropertyChange>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Deployments.Models.WhatIfPropertyChange>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Deployments.Models.WhatIfPropertyChange>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public enum WhatIfPropertyChangeType
    {
        Create = 0,
        Delete = 1,
        Modify = 2,
        Array = 3,
        NoEffect = 4,
    }
    public enum WhatIfResultFormat
    {
        ResourceIdOnly = 0,
        FullResourcePayloads = 1,
    }
    public partial class ZoneMapping : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Deployments.Models.ZoneMapping>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Deployments.Models.ZoneMapping>
    {
        internal ZoneMapping() { }
        public Azure.Core.AzureLocation? Location { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> Zones { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.Deployments.Models.ZoneMapping System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Deployments.Models.ZoneMapping>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Deployments.Models.ZoneMapping>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.Deployments.Models.ZoneMapping System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Deployments.Models.ZoneMapping>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Deployments.Models.ZoneMapping>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Deployments.Models.ZoneMapping>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
}
