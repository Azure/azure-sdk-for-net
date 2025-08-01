namespace Azure.ResourceManager.Resources
{
    public partial class ArmDeploymentCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Resources.ArmDeploymentResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.ArmDeploymentResource>, System.Collections.IEnumerable
    {
        protected ArmDeploymentCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Resources.ArmDeploymentResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string deploymentName, Azure.ResourceManager.Resources.Models.ArmDeploymentContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Resources.ArmDeploymentResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string deploymentName, Azure.ResourceManager.Resources.Models.ArmDeploymentContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string deploymentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string deploymentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Resources.ArmDeploymentResource> Get(string deploymentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Resources.ArmDeploymentResource> GetAll(string filter = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Resources.ArmDeploymentResource> GetAllAsync(string filter = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources.ArmDeploymentResource>> GetAsync(string deploymentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Resources.ArmDeploymentResource> GetIfExists(string deploymentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Resources.ArmDeploymentResource>> GetIfExistsAsync(string deploymentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Resources.ArmDeploymentResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Resources.ArmDeploymentResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Resources.ArmDeploymentResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.ArmDeploymentResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ArmDeploymentData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.ArmDeploymentData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.ArmDeploymentData>
    {
        internal ArmDeploymentData() { }
        public Azure.Core.AzureLocation? Location { get { throw null; } }
        public Azure.ResourceManager.Resources.Models.ArmDeploymentPropertiesExtended Properties { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, string> Tags { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.ArmDeploymentData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.ArmDeploymentData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.ArmDeploymentData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.ArmDeploymentData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.ArmDeploymentData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.ArmDeploymentData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.ArmDeploymentData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ArmDeploymentResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.ArmDeploymentData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.ArmDeploymentData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ArmDeploymentResource() { }
        public virtual Azure.ResourceManager.Resources.ArmDeploymentData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.Resources.ArmDeploymentResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources.ArmDeploymentResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response Cancel(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> CancelAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response CheckExistence(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> CheckExistenceAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string scope, string deploymentName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Resources.Models.ArmDeploymentExportResult> ExportTemplate(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources.Models.ArmDeploymentExportResult>> ExportTemplateAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Resources.ArmDeploymentResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources.ArmDeploymentResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Resources.Models.ArmDeploymentOperation> GetDeploymentOperation(string operationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources.Models.ArmDeploymentOperation>> GetDeploymentOperationAsync(string operationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Resources.Models.ArmDeploymentOperation> GetDeploymentOperations(int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Resources.Models.ArmDeploymentOperation> GetDeploymentOperationsAsync(int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Resources.ArmDeploymentResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources.ArmDeploymentResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Resources.ArmDeploymentResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources.ArmDeploymentResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.Resources.ArmDeploymentData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.ArmDeploymentData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.ArmDeploymentData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.ArmDeploymentData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.ArmDeploymentData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.ArmDeploymentData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.ArmDeploymentData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Resources.ArmDeploymentResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Resources.Models.ArmDeploymentContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Resources.ArmDeploymentResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Resources.Models.ArmDeploymentContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Resources.Models.ArmDeploymentValidateResult> Validate(Azure.WaitUntil waitUntil, Azure.ResourceManager.Resources.Models.ArmDeploymentContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Resources.Models.ArmDeploymentValidateResult>> ValidateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Resources.Models.ArmDeploymentContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Resources.Models.WhatIfOperationResult> WhatIf(Azure.WaitUntil waitUntil, Azure.ResourceManager.Resources.Models.ArmDeploymentWhatIfContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Resources.Models.WhatIfOperationResult>> WhatIfAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Resources.Models.ArmDeploymentWhatIfContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class AzureResourceManagerResourcesContext : System.ClientModel.Primitives.ModelReaderWriterContext
    {
        internal AzureResourceManagerResourcesContext() { }
        public static Azure.ResourceManager.Resources.AzureResourceManagerResourcesContext Default { get { throw null; } }
        protected override bool TryGetTypeBuilderCore(System.Type type, out System.ClientModel.Primitives.ModelReaderWriterTypeBuilder builder) { throw null; }
    }
    public static partial class ResourcesExtensions
    {
        public static Azure.Response<Azure.ResourceManager.Resources.Models.TemplateHashResult> CalculateDeploymentTemplateHash(this Azure.ResourceManager.Resources.TenantResource tenantResource, System.BinaryData template, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources.Models.TemplateHashResult>> CalculateDeploymentTemplateHashAsync(this Azure.ResourceManager.Resources.TenantResource tenantResource, System.BinaryData template, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Resources.ArmDeploymentResource> GetArmDeployment(this Azure.ResourceManager.ManagementGroups.ManagementGroupResource managementGroupResource, string deploymentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Resources.ArmDeploymentResource> GetArmDeployment(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string deploymentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Resources.ArmDeploymentResource> GetArmDeployment(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string deploymentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Resources.ArmDeploymentResource> GetArmDeployment(this Azure.ResourceManager.Resources.TenantResource tenantResource, string deploymentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources.ArmDeploymentResource>> GetArmDeploymentAsync(this Azure.ResourceManager.ManagementGroups.ManagementGroupResource managementGroupResource, string deploymentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources.ArmDeploymentResource>> GetArmDeploymentAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string deploymentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources.ArmDeploymentResource>> GetArmDeploymentAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string deploymentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources.ArmDeploymentResource>> GetArmDeploymentAsync(this Azure.ResourceManager.Resources.TenantResource tenantResource, string deploymentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Resources.ArmDeploymentResource GetArmDeploymentResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Resources.ArmDeploymentCollection GetArmDeployments(this Azure.ResourceManager.ManagementGroups.ManagementGroupResource managementGroupResource) { throw null; }
        public static Azure.ResourceManager.Resources.ArmDeploymentCollection GetArmDeployments(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.ResourceManager.Resources.ArmDeploymentCollection GetArmDeployments(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource) { throw null; }
        public static Azure.ResourceManager.Resources.ArmDeploymentCollection GetArmDeployments(this Azure.ResourceManager.Resources.TenantResource tenantResource) { throw null; }
    }
}
namespace Azure.ResourceManager.Resources.Mocking
{
    public partial class MockableResourcesArmClient : Azure.ResourceManager.ArmResource
    {
        protected MockableResourcesArmClient() { }
        public virtual Azure.ResourceManager.Resources.ArmDeploymentResource GetArmDeploymentResource(Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class MockableResourcesManagementGroupResource : Azure.ResourceManager.ArmResource
    {
        protected MockableResourcesManagementGroupResource() { }
        public virtual Azure.Response<Azure.ResourceManager.Resources.ArmDeploymentResource> GetArmDeployment(string deploymentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources.ArmDeploymentResource>> GetArmDeploymentAsync(string deploymentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Resources.ArmDeploymentCollection GetArmDeployments() { throw null; }
    }
    public partial class MockableResourcesResourceGroupResource : Azure.ResourceManager.ArmResource
    {
        protected MockableResourcesResourceGroupResource() { }
        public virtual Azure.Response<Azure.ResourceManager.Resources.ArmDeploymentResource> GetArmDeployment(string deploymentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources.ArmDeploymentResource>> GetArmDeploymentAsync(string deploymentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Resources.ArmDeploymentCollection GetArmDeployments() { throw null; }
    }
    public partial class MockableResourcesSubscriptionResource : Azure.ResourceManager.ArmResource
    {
        protected MockableResourcesSubscriptionResource() { }
        public virtual Azure.Response<Azure.ResourceManager.Resources.ArmDeploymentResource> GetArmDeployment(string deploymentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources.ArmDeploymentResource>> GetArmDeploymentAsync(string deploymentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Resources.ArmDeploymentCollection GetArmDeployments() { throw null; }
    }
    public partial class MockableResourcesTenantResource : Azure.ResourceManager.ArmResource
    {
        protected MockableResourcesTenantResource() { }
        public virtual Azure.Response<Azure.ResourceManager.Resources.Models.TemplateHashResult> CalculateDeploymentTemplateHash(System.BinaryData template, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources.Models.TemplateHashResult>> CalculateDeploymentTemplateHashAsync(System.BinaryData template, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Resources.ArmDeploymentResource> GetArmDeployment(string deploymentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources.ArmDeploymentResource>> GetArmDeploymentAsync(string deploymentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Resources.ArmDeploymentCollection GetArmDeployments() { throw null; }
    }
}
namespace Azure.ResourceManager.Resources.Models
{
    public partial class ArmDependency : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Models.ArmDependency>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.ArmDependency>
    {
        internal ArmDependency() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Resources.Models.BasicArmDependency> DependsOn { get { throw null; } }
        public string Id { get { throw null; } }
        public string ResourceName { get { throw null; } }
        public Azure.Core.ResourceType? ResourceType { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.Models.ArmDependency System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Models.ArmDependency>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Models.ArmDependency>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.Models.ArmDependency System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.ArmDependency>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.ArmDependency>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.ArmDependency>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ArmDeploymentContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Models.ArmDeploymentContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.ArmDeploymentContent>
    {
        public ArmDeploymentContent(Azure.ResourceManager.Resources.Models.ArmDeploymentProperties properties) { }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public Azure.Core.AzureLocation? Location { get { throw null; } set { } }
        public Azure.ResourceManager.Resources.Models.ArmDeploymentProperties Properties { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.Models.ArmDeploymentContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Models.ArmDeploymentContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Models.ArmDeploymentContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.Models.ArmDeploymentContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.ArmDeploymentContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.ArmDeploymentContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.ArmDeploymentContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ArmDeploymentExportResult : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Models.ArmDeploymentExportResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.ArmDeploymentExportResult>
    {
        internal ArmDeploymentExportResult() { }
        public System.BinaryData Template { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.Models.ArmDeploymentExportResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Models.ArmDeploymentExportResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Models.ArmDeploymentExportResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.Models.ArmDeploymentExportResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.ArmDeploymentExportResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.ArmDeploymentExportResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.ArmDeploymentExportResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ArmDeploymentExtensionConfigItem : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Models.ArmDeploymentExtensionConfigItem>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.ArmDeploymentExtensionConfigItem>
    {
        public ArmDeploymentExtensionConfigItem() { }
        public Azure.ResourceManager.Resources.Models.ExtensionConfigPropertyType? ExtensionConfigPropertyType { get { throw null; } }
        public Azure.ResourceManager.Resources.Models.KeyVaultParameterReference KeyVaultReference { get { throw null; } set { } }
        public System.BinaryData Value { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.Models.ArmDeploymentExtensionConfigItem System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Models.ArmDeploymentExtensionConfigItem>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Models.ArmDeploymentExtensionConfigItem>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.Models.ArmDeploymentExtensionConfigItem System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.ArmDeploymentExtensionConfigItem>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.ArmDeploymentExtensionConfigItem>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.ArmDeploymentExtensionConfigItem>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ArmDeploymentExtensionDefinition : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Models.ArmDeploymentExtensionDefinition>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.ArmDeploymentExtensionDefinition>
    {
        internal ArmDeploymentExtensionDefinition() { }
        public string Alias { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, Azure.ResourceManager.Resources.Models.ArmDeploymentExtensionConfigItem> Config { get { throw null; } }
        public string ConfigId { get { throw null; } }
        public string Name { get { throw null; } }
        public string Version { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.Models.ArmDeploymentExtensionDefinition System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Models.ArmDeploymentExtensionDefinition>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Models.ArmDeploymentExtensionDefinition>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.Models.ArmDeploymentExtensionDefinition System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.ArmDeploymentExtensionDefinition>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.ArmDeploymentExtensionDefinition>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.ArmDeploymentExtensionDefinition>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ArmDeploymentExternalInput : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Models.ArmDeploymentExternalInput>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.ArmDeploymentExternalInput>
    {
        public ArmDeploymentExternalInput(System.BinaryData value) { }
        public System.BinaryData Value { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.Models.ArmDeploymentExternalInput System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Models.ArmDeploymentExternalInput>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Models.ArmDeploymentExternalInput>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.Models.ArmDeploymentExternalInput System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.ArmDeploymentExternalInput>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.ArmDeploymentExternalInput>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.ArmDeploymentExternalInput>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ArmDeploymentExternalInputDefinition : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Models.ArmDeploymentExternalInputDefinition>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.ArmDeploymentExternalInputDefinition>
    {
        public ArmDeploymentExternalInputDefinition(string kind) { }
        public System.BinaryData Config { get { throw null; } set { } }
        public string Kind { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.Models.ArmDeploymentExternalInputDefinition System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Models.ArmDeploymentExternalInputDefinition>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Models.ArmDeploymentExternalInputDefinition>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.Models.ArmDeploymentExternalInputDefinition System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.ArmDeploymentExternalInputDefinition>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.ArmDeploymentExternalInputDefinition>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.ArmDeploymentExternalInputDefinition>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public enum ArmDeploymentMode
    {
        Incremental = 0,
        Complete = 1,
    }
    public partial class ArmDeploymentOperation : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Models.ArmDeploymentOperation>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.ArmDeploymentOperation>
    {
        internal ArmDeploymentOperation() { }
        public string Id { get { throw null; } }
        public string OperationId { get { throw null; } }
        public Azure.ResourceManager.Resources.Models.ArmDeploymentOperationProperties Properties { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.Models.ArmDeploymentOperation System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Models.ArmDeploymentOperation>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Models.ArmDeploymentOperation>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.Models.ArmDeploymentOperation System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.ArmDeploymentOperation>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.ArmDeploymentOperation>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.ArmDeploymentOperation>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ArmDeploymentOperationProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Models.ArmDeploymentOperationProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.ArmDeploymentOperationProperties>
    {
        internal ArmDeploymentOperationProperties() { }
        public System.TimeSpan? Duration { get { throw null; } }
        public Azure.ResourceManager.Resources.Models.ProvisioningOperationKind? ProvisioningOperation { get { throw null; } }
        public string ProvisioningState { get { throw null; } }
        public System.BinaryData RequestContent { get { throw null; } }
        public System.BinaryData ResponseContent { get { throw null; } }
        public string ServiceRequestId { get { throw null; } }
        public string StatusCode { get { throw null; } }
        public Azure.ResourceManager.Resources.Models.StatusMessage StatusMessage { get { throw null; } }
        public Azure.ResourceManager.Resources.Models.TargetResource TargetResource { get { throw null; } }
        public System.DateTimeOffset? Timestamp { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.Models.ArmDeploymentOperationProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Models.ArmDeploymentOperationProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Models.ArmDeploymentOperationProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.Models.ArmDeploymentOperationProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.ArmDeploymentOperationProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.ArmDeploymentOperationProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.ArmDeploymentOperationProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ArmDeploymentParametersLink : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Models.ArmDeploymentParametersLink>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.ArmDeploymentParametersLink>
    {
        public ArmDeploymentParametersLink(System.Uri uri) { }
        public string ContentVersion { get { throw null; } set { } }
        public System.Uri Uri { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.Models.ArmDeploymentParametersLink System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Models.ArmDeploymentParametersLink>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Models.ArmDeploymentParametersLink>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.Models.ArmDeploymentParametersLink System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.ArmDeploymentParametersLink>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.ArmDeploymentParametersLink>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.ArmDeploymentParametersLink>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ArmDeploymentProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Models.ArmDeploymentProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.ArmDeploymentProperties>
    {
        public ArmDeploymentProperties(Azure.ResourceManager.Resources.Models.ArmDeploymentMode mode) { }
        public string DebugSettingDetailLevel { get { throw null; } set { } }
        public Azure.ResourceManager.Resources.Models.ErrorDeployment ErrorDeployment { get { throw null; } set { } }
        public Azure.ResourceManager.Resources.Models.ExpressionEvaluationScope? ExpressionEvaluationScope { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, System.Collections.Generic.IDictionary<string, Azure.ResourceManager.Resources.Models.ArmDeploymentExtensionConfigItem>> ExtensionConfigs { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, Azure.ResourceManager.Resources.Models.ArmDeploymentExternalInputDefinition> ExternalInputDefinitions { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, Azure.ResourceManager.Resources.Models.ArmDeploymentExternalInput> ExternalInputs { get { throw null; } }
        public Azure.ResourceManager.Resources.Models.ArmDeploymentMode Mode { get { throw null; } }
        public System.BinaryData Parameters { get { throw null; } set { } }
        public Azure.ResourceManager.Resources.Models.ArmDeploymentParametersLink ParametersLink { get { throw null; } set { } }
        public System.BinaryData Template { get { throw null; } set { } }
        public Azure.ResourceManager.Resources.Models.ArmDeploymentTemplateLink TemplateLink { get { throw null; } set { } }
        public Azure.ResourceManager.Resources.Models.ValidationLevel? ValidationLevel { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.Models.ArmDeploymentProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Models.ArmDeploymentProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Models.ArmDeploymentProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.Models.ArmDeploymentProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.ArmDeploymentProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.ArmDeploymentProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.ArmDeploymentProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ArmDeploymentPropertiesExtended : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Models.ArmDeploymentPropertiesExtended>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.ArmDeploymentPropertiesExtended>
    {
        internal ArmDeploymentPropertiesExtended() { }
        public string CorrelationId { get { throw null; } }
        public string DebugSettingDetailLevel { get { throw null; } [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)] set { } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Resources.Models.ArmDependency> Dependencies { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Resources.Models.DeploymentDiagnosticsDefinition> Diagnostics { get { throw null; } }
        public System.TimeSpan? Duration { get { throw null; } }
        public Azure.ResponseError Error { get { throw null; } }
        public Azure.ResourceManager.Resources.Models.ErrorDeploymentExtended ErrorDeployment { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Resources.Models.ArmDeploymentExtensionDefinition> Extensions { get { throw null; } }
        public Azure.ResourceManager.Resources.Models.ArmDeploymentMode? Mode { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Resources.Models.ArmResourceReference> OutputResourceDetails { get { throw null; } }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Resources.Models.SubResource> OutputResources { get { throw null; } }
        public System.BinaryData Outputs { get { throw null; } }
        public System.BinaryData Parameters { get { throw null; } }
        public Azure.ResourceManager.Resources.Models.ArmDeploymentParametersLink ParametersLink { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Resources.ResourceProviderData> Providers { get { throw null; } }
        public Azure.ResourceManager.Resources.Models.ResourcesProvisioningState? ProvisioningState { get { throw null; } }
        public string TemplateHash { get { throw null; } }
        public Azure.ResourceManager.Resources.Models.ArmDeploymentTemplateLink TemplateLink { get { throw null; } }
        public System.DateTimeOffset? Timestamp { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Resources.Models.ArmResourceReference> ValidatedResourceDetails { get { throw null; } }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Resources.Models.SubResource> ValidatedResources { get { throw null; } }
        public Azure.ResourceManager.Resources.Models.ValidationLevel? ValidationLevel { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.Models.ArmDeploymentPropertiesExtended System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Models.ArmDeploymentPropertiesExtended>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Models.ArmDeploymentPropertiesExtended>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.Models.ArmDeploymentPropertiesExtended System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.ArmDeploymentPropertiesExtended>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.ArmDeploymentPropertiesExtended>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.ArmDeploymentPropertiesExtended>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ArmDeploymentTemplateLink : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Models.ArmDeploymentTemplateLink>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.ArmDeploymentTemplateLink>
    {
        public ArmDeploymentTemplateLink() { }
        public string ContentVersion { get { throw null; } set { } }
        public string Id { get { throw null; } set { } }
        public string QueryString { get { throw null; } set { } }
        public string RelativePath { get { throw null; } set { } }
        public System.Uri Uri { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.Models.ArmDeploymentTemplateLink System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Models.ArmDeploymentTemplateLink>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Models.ArmDeploymentTemplateLink>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.Models.ArmDeploymentTemplateLink System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.ArmDeploymentTemplateLink>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.ArmDeploymentTemplateLink>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.ArmDeploymentTemplateLink>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ArmDeploymentValidateResult : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Models.ArmDeploymentValidateResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.ArmDeploymentValidateResult>
    {
        internal ArmDeploymentValidateResult() { }
        public Azure.ResponseError Error { get { throw null; } }
        public Azure.ResourceManager.Resources.Models.ArmDeploymentPropertiesExtended Properties { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.Models.ArmDeploymentValidateResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Models.ArmDeploymentValidateResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Models.ArmDeploymentValidateResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.Models.ArmDeploymentValidateResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.ArmDeploymentValidateResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.ArmDeploymentValidateResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.ArmDeploymentValidateResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ArmDeploymentWhatIfContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Models.ArmDeploymentWhatIfContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.ArmDeploymentWhatIfContent>
    {
        public ArmDeploymentWhatIfContent(Azure.ResourceManager.Resources.Models.ArmDeploymentWhatIfProperties properties) { }
        public Azure.Core.AzureLocation? Location { get { throw null; } set { } }
        public Azure.ResourceManager.Resources.Models.ArmDeploymentWhatIfProperties Properties { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.Models.ArmDeploymentWhatIfContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Models.ArmDeploymentWhatIfContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Models.ArmDeploymentWhatIfContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.Models.ArmDeploymentWhatIfContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.ArmDeploymentWhatIfContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.ArmDeploymentWhatIfContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.ArmDeploymentWhatIfContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ArmDeploymentWhatIfProperties : Azure.ResourceManager.Resources.Models.ArmDeploymentProperties, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Models.ArmDeploymentWhatIfProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.ArmDeploymentWhatIfProperties>
    {
        public ArmDeploymentWhatIfProperties(Azure.ResourceManager.Resources.Models.ArmDeploymentMode mode) : base (default(Azure.ResourceManager.Resources.Models.ArmDeploymentMode)) { }
        public Azure.ResourceManager.Resources.Models.WhatIfResultFormat? WhatIfResultFormat { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.Models.ArmDeploymentWhatIfProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Models.ArmDeploymentWhatIfProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Models.ArmDeploymentWhatIfProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.Models.ArmDeploymentWhatIfProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.ArmDeploymentWhatIfProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.ArmDeploymentWhatIfProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.ArmDeploymentWhatIfProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ArmResourceReference : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Models.ArmResourceReference>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.ArmResourceReference>
    {
        internal ArmResourceReference() { }
        public string ApiVersion { get { throw null; } }
        public Azure.ResourceManager.Resources.Models.ArmDeploymentExtensionDefinition Extension { get { throw null; } }
        public Azure.Core.ResourceIdentifier Id { get { throw null; } }
        public System.BinaryData Identifiers { get { throw null; } }
        public string ResourceType { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.Models.ArmResourceReference System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Models.ArmResourceReference>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Models.ArmResourceReference>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.Models.ArmResourceReference System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.ArmResourceReference>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.ArmResourceReference>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.ArmResourceReference>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public static partial class ArmResourcesModelFactory
    {
        public static Azure.ResourceManager.Resources.Models.ArmDependency ArmDependency(System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Models.BasicArmDependency> dependsOn = null, string id = null, Azure.Core.ResourceType? resourceType = default(Azure.Core.ResourceType?), string resourceName = null) { throw null; }
        public static Azure.ResourceManager.Resources.Models.ArmDeploymentContent ArmDeploymentContent(Azure.Core.AzureLocation? location = default(Azure.Core.AzureLocation?), Azure.ResourceManager.Resources.Models.ArmDeploymentProperties properties = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.ResourceManager.Models.ManagedServiceIdentity identity = null) { throw null; }
        public static Azure.ResourceManager.Resources.ArmDeploymentData ArmDeploymentData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.Core.AzureLocation? location = default(Azure.Core.AzureLocation?), Azure.ResourceManager.Resources.Models.ArmDeploymentPropertiesExtended properties = null, System.Collections.Generic.IReadOnlyDictionary<string, string> tags = null) { throw null; }
        public static Azure.ResourceManager.Resources.Models.ArmDeploymentExportResult ArmDeploymentExportResult(System.BinaryData template = null) { throw null; }
        public static Azure.ResourceManager.Resources.Models.ArmDeploymentExtensionConfigItem ArmDeploymentExtensionConfigItem(Azure.ResourceManager.Resources.Models.ExtensionConfigPropertyType? extensionConfigPropertyType = default(Azure.ResourceManager.Resources.Models.ExtensionConfigPropertyType?), System.BinaryData value = null, Azure.ResourceManager.Resources.Models.KeyVaultParameterReference keyVaultReference = null) { throw null; }
        public static Azure.ResourceManager.Resources.Models.ArmDeploymentExtensionDefinition ArmDeploymentExtensionDefinition(string alias = null, string name = null, string version = null, string configId = null, System.Collections.Generic.IReadOnlyDictionary<string, Azure.ResourceManager.Resources.Models.ArmDeploymentExtensionConfigItem> config = null) { throw null; }
        public static Azure.ResourceManager.Resources.Models.ArmDeploymentExternalInputDefinition ArmDeploymentExternalInputDefinition(string kind = null, System.BinaryData config = null) { throw null; }
        public static Azure.ResourceManager.Resources.Models.ArmDeploymentOperation ArmDeploymentOperation(string id = null, string operationId = null, Azure.ResourceManager.Resources.Models.ArmDeploymentOperationProperties properties = null) { throw null; }
        public static Azure.ResourceManager.Resources.Models.ArmDeploymentOperationProperties ArmDeploymentOperationProperties(Azure.ResourceManager.Resources.Models.ProvisioningOperationKind? provisioningOperation = default(Azure.ResourceManager.Resources.Models.ProvisioningOperationKind?), string provisioningState = null, System.DateTimeOffset? timestamp = default(System.DateTimeOffset?), System.TimeSpan? duration = default(System.TimeSpan?), string serviceRequestId = null, string statusCode = null, Azure.ResourceManager.Resources.Models.StatusMessage statusMessage = null, Azure.ResourceManager.Resources.Models.TargetResource targetResource = null, System.BinaryData requestContent = null, System.BinaryData responseContent = null) { throw null; }
        public static Azure.ResourceManager.Resources.Models.ArmDeploymentProperties ArmDeploymentProperties(System.BinaryData template = null, Azure.ResourceManager.Resources.Models.ArmDeploymentTemplateLink templateLink = null, System.BinaryData parameters = null, System.Collections.Generic.IDictionary<string, Azure.ResourceManager.Resources.Models.ArmDeploymentExternalInput> externalInputs = null, System.Collections.Generic.IDictionary<string, Azure.ResourceManager.Resources.Models.ArmDeploymentExternalInputDefinition> externalInputDefinitions = null, Azure.ResourceManager.Resources.Models.ArmDeploymentParametersLink parametersLink = null, System.Collections.Generic.IDictionary<string, System.Collections.Generic.IDictionary<string, Azure.ResourceManager.Resources.Models.ArmDeploymentExtensionConfigItem>> extensionConfigs = null, Azure.ResourceManager.Resources.Models.ArmDeploymentMode mode = Azure.ResourceManager.Resources.Models.ArmDeploymentMode.Incremental, string debugSettingDetailLevel = null, Azure.ResourceManager.Resources.Models.ErrorDeployment errorDeployment = null, Azure.ResourceManager.Resources.Models.ExpressionEvaluationScope? expressionEvaluationScope = default(Azure.ResourceManager.Resources.Models.ExpressionEvaluationScope?), Azure.ResourceManager.Resources.Models.ValidationLevel? validationLevel = default(Azure.ResourceManager.Resources.Models.ValidationLevel?)) { throw null; }
        public static Azure.ResourceManager.Resources.Models.ArmDeploymentPropertiesExtended ArmDeploymentPropertiesExtended(Azure.ResourceManager.Resources.Models.ResourcesProvisioningState? provisioningState = default(Azure.ResourceManager.Resources.Models.ResourcesProvisioningState?), string correlationId = null, System.DateTimeOffset? timestamp = default(System.DateTimeOffset?), System.TimeSpan? duration = default(System.TimeSpan?), System.BinaryData outputs = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.ResourceProviderData> providers = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Models.ArmDependency> dependencies = null, Azure.ResourceManager.Resources.Models.ArmDeploymentTemplateLink templateLink = null, System.BinaryData parameters = null, Azure.ResourceManager.Resources.Models.ArmDeploymentParametersLink parametersLink = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Models.ArmDeploymentExtensionDefinition> extensions = null, Azure.ResourceManager.Resources.Models.ArmDeploymentMode? mode = default(Azure.ResourceManager.Resources.Models.ArmDeploymentMode?), string debugSettingDetailLevel = null, Azure.ResourceManager.Resources.Models.ErrorDeploymentExtended errorDeployment = null, string templateHash = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Models.ArmResourceReference> outputResourceDetails = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Models.ArmResourceReference> validatedResourceDetails = null, Azure.ResponseError error = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Models.DeploymentDiagnosticsDefinition> diagnostics = null, Azure.ResourceManager.Resources.Models.ValidationLevel? validationLevel = default(Azure.ResourceManager.Resources.Models.ValidationLevel?)) { throw null; }
        public static Azure.ResourceManager.Resources.Models.ArmDeploymentValidateResult ArmDeploymentValidateResult(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResponseError error = null, Azure.ResourceManager.Resources.Models.ArmDeploymentPropertiesExtended properties = null) { throw null; }
        public static Azure.ResourceManager.Resources.Models.ArmDeploymentWhatIfContent ArmDeploymentWhatIfContent(Azure.Core.AzureLocation? location = default(Azure.Core.AzureLocation?), Azure.ResourceManager.Resources.Models.ArmDeploymentWhatIfProperties properties = null) { throw null; }
        public static Azure.ResourceManager.Resources.Models.ArmDeploymentWhatIfProperties ArmDeploymentWhatIfProperties(System.BinaryData template = null, Azure.ResourceManager.Resources.Models.ArmDeploymentTemplateLink templateLink = null, System.BinaryData parameters = null, System.Collections.Generic.IDictionary<string, Azure.ResourceManager.Resources.Models.ArmDeploymentExternalInput> externalInputs = null, System.Collections.Generic.IDictionary<string, Azure.ResourceManager.Resources.Models.ArmDeploymentExternalInputDefinition> externalInputDefinitions = null, Azure.ResourceManager.Resources.Models.ArmDeploymentParametersLink parametersLink = null, System.Collections.Generic.IDictionary<string, System.Collections.Generic.IDictionary<string, Azure.ResourceManager.Resources.Models.ArmDeploymentExtensionConfigItem>> extensionConfigs = null, Azure.ResourceManager.Resources.Models.ArmDeploymentMode mode = Azure.ResourceManager.Resources.Models.ArmDeploymentMode.Incremental, string debugSettingDetailLevel = null, Azure.ResourceManager.Resources.Models.ErrorDeployment errorDeployment = null, Azure.ResourceManager.Resources.Models.ExpressionEvaluationScope? expressionEvaluationScope = default(Azure.ResourceManager.Resources.Models.ExpressionEvaluationScope?), Azure.ResourceManager.Resources.Models.ValidationLevel? validationLevel = default(Azure.ResourceManager.Resources.Models.ValidationLevel?), Azure.ResourceManager.Resources.Models.WhatIfResultFormat? whatIfResultFormat = default(Azure.ResourceManager.Resources.Models.WhatIfResultFormat?)) { throw null; }
        public static Azure.ResourceManager.Resources.Models.ArmResourceReference ArmResourceReference(Azure.Core.ResourceIdentifier id = null, Azure.ResourceManager.Resources.Models.ArmDeploymentExtensionDefinition extension = null, string resourceType = null, System.BinaryData identifiers = null, string apiVersion = null) { throw null; }
        public static Azure.ResourceManager.Resources.Models.BasicArmDependency BasicArmDependency(string id = null, Azure.Core.ResourceType? resourceType = default(Azure.Core.ResourceType?), string resourceName = null) { throw null; }
        public static Azure.ResourceManager.Resources.Models.DeploymentDiagnosticsDefinition DeploymentDiagnosticsDefinition(Azure.ResourceManager.Resources.Models.Level level = default(Azure.ResourceManager.Resources.Models.Level), string code = null, string message = null, string target = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Models.ErrorAdditionalInfo> additionalInfo = null) { throw null; }
        public static Azure.ResourceManager.Resources.Models.ErrorAdditionalInfo ErrorAdditionalInfo(string errorAdditionalInfoType = null, System.BinaryData info = null) { throw null; }
        public static Azure.ResourceManager.Resources.Models.ErrorDeploymentExtended ErrorDeploymentExtended(string provisioningState = null, Azure.ResourceManager.Resources.Models.ErrorDeploymentType? deploymentType = default(Azure.ResourceManager.Resources.Models.ErrorDeploymentType?), string deploymentName = null) { throw null; }
        public static Azure.ResourceManager.Resources.Models.StatusMessage StatusMessage(string status = null, Azure.ResponseError error = null) { throw null; }
        public static Azure.ResourceManager.Resources.Models.TargetResource TargetResource(string id = null, string resourceName = null, Azure.Core.ResourceType? resourceType = default(Azure.Core.ResourceType?), Azure.ResourceManager.Resources.Models.ArmDeploymentExtensionDefinition extension = null, System.BinaryData identifiers = null, string apiVersion = null, string symbolicName = null) { throw null; }
        public static Azure.ResourceManager.Resources.Models.TemplateHashResult TemplateHashResult(string minifiedTemplate = null, string templateHash = null) { throw null; }
        public static Azure.ResourceManager.Resources.Models.WhatIfChange WhatIfChange(string resourceId = null, string deploymentId = null, string symbolicName = null, System.BinaryData identifiers = null, Azure.ResourceManager.Resources.Models.ArmDeploymentExtensionDefinition extension = null, Azure.ResourceManager.Resources.Models.WhatIfChangeType changeType = Azure.ResourceManager.Resources.Models.WhatIfChangeType.Create, string unsupportedReason = null, System.BinaryData before = null, System.BinaryData after = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Models.WhatIfPropertyChange> delta = null) { throw null; }
        public static Azure.ResourceManager.Resources.Models.WhatIfOperationResult WhatIfOperationResult(string status = null, Azure.ResponseError error = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Models.WhatIfChange> changes = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Models.WhatIfChange> potentialChanges = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Models.DeploymentDiagnosticsDefinition> diagnostics = null) { throw null; }
        public static Azure.ResourceManager.Resources.Models.WhatIfPropertyChange WhatIfPropertyChange(string path = null, Azure.ResourceManager.Resources.Models.WhatIfPropertyChangeType propertyChangeType = Azure.ResourceManager.Resources.Models.WhatIfPropertyChangeType.Create, System.BinaryData before = null, System.BinaryData after = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Models.WhatIfPropertyChange> children = null) { throw null; }
    }
    public partial class BasicArmDependency : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Models.BasicArmDependency>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.BasicArmDependency>
    {
        internal BasicArmDependency() { }
        public string Id { get { throw null; } }
        public string ResourceName { get { throw null; } }
        public Azure.Core.ResourceType? ResourceType { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.Models.BasicArmDependency System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Models.BasicArmDependency>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Models.BasicArmDependency>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.Models.BasicArmDependency System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.BasicArmDependency>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.BasicArmDependency>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.BasicArmDependency>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DeploymentDiagnosticsDefinition : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Models.DeploymentDiagnosticsDefinition>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.DeploymentDiagnosticsDefinition>
    {
        internal DeploymentDiagnosticsDefinition() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Resources.Models.ErrorAdditionalInfo> AdditionalInfo { get { throw null; } }
        public string Code { get { throw null; } }
        public Azure.ResourceManager.Resources.Models.Level Level { get { throw null; } }
        public string Message { get { throw null; } }
        public string Target { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.Models.DeploymentDiagnosticsDefinition System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Models.DeploymentDiagnosticsDefinition>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Models.DeploymentDiagnosticsDefinition>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.Models.DeploymentDiagnosticsDefinition System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.DeploymentDiagnosticsDefinition>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.DeploymentDiagnosticsDefinition>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.DeploymentDiagnosticsDefinition>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ErrorAdditionalInfo : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Models.ErrorAdditionalInfo>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.ErrorAdditionalInfo>
    {
        internal ErrorAdditionalInfo() { }
        public string ErrorAdditionalInfoType { get { throw null; } }
        public System.BinaryData Info { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.Models.ErrorAdditionalInfo System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Models.ErrorAdditionalInfo>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Models.ErrorAdditionalInfo>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.Models.ErrorAdditionalInfo System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.ErrorAdditionalInfo>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.ErrorAdditionalInfo>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.ErrorAdditionalInfo>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ErrorDeployment : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Models.ErrorDeployment>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.ErrorDeployment>
    {
        public ErrorDeployment() { }
        public string DeploymentName { get { throw null; } set { } }
        public Azure.ResourceManager.Resources.Models.ErrorDeploymentType? DeploymentType { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.Models.ErrorDeployment System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Models.ErrorDeployment>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Models.ErrorDeployment>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.Models.ErrorDeployment System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.ErrorDeployment>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.ErrorDeployment>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.ErrorDeployment>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ErrorDeploymentExtended : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Models.ErrorDeploymentExtended>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.ErrorDeploymentExtended>
    {
        internal ErrorDeploymentExtended() { }
        public string DeploymentName { get { throw null; } }
        public Azure.ResourceManager.Resources.Models.ErrorDeploymentType? DeploymentType { get { throw null; } }
        public string ProvisioningState { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.Models.ErrorDeploymentExtended System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Models.ErrorDeploymentExtended>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Models.ErrorDeploymentExtended>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.Models.ErrorDeploymentExtended System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.ErrorDeploymentExtended>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.ErrorDeploymentExtended>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.ErrorDeploymentExtended>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public enum ErrorDeploymentType
    {
        LastSuccessful = 0,
        SpecificDeployment = 1,
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ExpressionEvaluationScope : System.IEquatable<Azure.ResourceManager.Resources.Models.ExpressionEvaluationScope>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ExpressionEvaluationScope(string value) { throw null; }
        public static Azure.ResourceManager.Resources.Models.ExpressionEvaluationScope Inner { get { throw null; } }
        public static Azure.ResourceManager.Resources.Models.ExpressionEvaluationScope NotSpecified { get { throw null; } }
        public static Azure.ResourceManager.Resources.Models.ExpressionEvaluationScope Outer { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Resources.Models.ExpressionEvaluationScope other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Resources.Models.ExpressionEvaluationScope left, Azure.ResourceManager.Resources.Models.ExpressionEvaluationScope right) { throw null; }
        public static implicit operator Azure.ResourceManager.Resources.Models.ExpressionEvaluationScope (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Resources.Models.ExpressionEvaluationScope left, Azure.ResourceManager.Resources.Models.ExpressionEvaluationScope right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ExtensionConfigPropertyType : System.IEquatable<Azure.ResourceManager.Resources.Models.ExtensionConfigPropertyType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ExtensionConfigPropertyType(string value) { throw null; }
        public static Azure.ResourceManager.Resources.Models.ExtensionConfigPropertyType Array { get { throw null; } }
        public static Azure.ResourceManager.Resources.Models.ExtensionConfigPropertyType Bool { get { throw null; } }
        public static Azure.ResourceManager.Resources.Models.ExtensionConfigPropertyType Int { get { throw null; } }
        public static Azure.ResourceManager.Resources.Models.ExtensionConfigPropertyType Object { get { throw null; } }
        public static Azure.ResourceManager.Resources.Models.ExtensionConfigPropertyType SecureObject { get { throw null; } }
        public static Azure.ResourceManager.Resources.Models.ExtensionConfigPropertyType SecureString { get { throw null; } }
        public static Azure.ResourceManager.Resources.Models.ExtensionConfigPropertyType String { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Resources.Models.ExtensionConfigPropertyType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Resources.Models.ExtensionConfigPropertyType left, Azure.ResourceManager.Resources.Models.ExtensionConfigPropertyType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Resources.Models.ExtensionConfigPropertyType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Resources.Models.ExtensionConfigPropertyType left, Azure.ResourceManager.Resources.Models.ExtensionConfigPropertyType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class KeyVaultParameterReference : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Models.KeyVaultParameterReference>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.KeyVaultParameterReference>
    {
        public KeyVaultParameterReference(Azure.ResourceManager.Resources.Models.WritableSubResource keyVault, string secretName) { }
        public Azure.Core.ResourceIdentifier KeyVaultId { get { throw null; } set { } }
        public string SecretName { get { throw null; } set { } }
        public string SecretVersion { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.Models.KeyVaultParameterReference System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Models.KeyVaultParameterReference>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Models.KeyVaultParameterReference>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.Models.KeyVaultParameterReference System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.KeyVaultParameterReference>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.KeyVaultParameterReference>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.KeyVaultParameterReference>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct Level : System.IEquatable<Azure.ResourceManager.Resources.Models.Level>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public Level(string value) { throw null; }
        public static Azure.ResourceManager.Resources.Models.Level Error { get { throw null; } }
        public static Azure.ResourceManager.Resources.Models.Level Info { get { throw null; } }
        public static Azure.ResourceManager.Resources.Models.Level Warning { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Resources.Models.Level other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Resources.Models.Level left, Azure.ResourceManager.Resources.Models.Level right) { throw null; }
        public static implicit operator Azure.ResourceManager.Resources.Models.Level (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Resources.Models.Level left, Azure.ResourceManager.Resources.Models.Level right) { throw null; }
        public override string ToString() { throw null; }
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
    public readonly partial struct ResourcesProvisioningState : System.IEquatable<Azure.ResourceManager.Resources.Models.ResourcesProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ResourcesProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.Resources.Models.ResourcesProvisioningState Accepted { get { throw null; } }
        public static Azure.ResourceManager.Resources.Models.ResourcesProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.Resources.Models.ResourcesProvisioningState Created { get { throw null; } }
        public static Azure.ResourceManager.Resources.Models.ResourcesProvisioningState Creating { get { throw null; } }
        public static Azure.ResourceManager.Resources.Models.ResourcesProvisioningState Deleted { get { throw null; } }
        public static Azure.ResourceManager.Resources.Models.ResourcesProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.Resources.Models.ResourcesProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.Resources.Models.ResourcesProvisioningState NotSpecified { get { throw null; } }
        public static Azure.ResourceManager.Resources.Models.ResourcesProvisioningState Ready { get { throw null; } }
        public static Azure.ResourceManager.Resources.Models.ResourcesProvisioningState Running { get { throw null; } }
        public static Azure.ResourceManager.Resources.Models.ResourcesProvisioningState Succeeded { get { throw null; } }
        public static Azure.ResourceManager.Resources.Models.ResourcesProvisioningState Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Resources.Models.ResourcesProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Resources.Models.ResourcesProvisioningState left, Azure.ResourceManager.Resources.Models.ResourcesProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Resources.Models.ResourcesProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Resources.Models.ResourcesProvisioningState left, Azure.ResourceManager.Resources.Models.ResourcesProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class StatusMessage : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Models.StatusMessage>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.StatusMessage>
    {
        internal StatusMessage() { }
        public Azure.ResponseError Error { get { throw null; } }
        public string Status { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.Models.StatusMessage System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Models.StatusMessage>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Models.StatusMessage>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.Models.StatusMessage System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.StatusMessage>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.StatusMessage>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.StatusMessage>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class TargetResource : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Models.TargetResource>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.TargetResource>
    {
        internal TargetResource() { }
        public string ApiVersion { get { throw null; } }
        public Azure.ResourceManager.Resources.Models.ArmDeploymentExtensionDefinition Extension { get { throw null; } }
        public string Id { get { throw null; } }
        public System.BinaryData Identifiers { get { throw null; } }
        public string ResourceName { get { throw null; } }
        public Azure.Core.ResourceType? ResourceType { get { throw null; } }
        public string SymbolicName { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.Models.TargetResource System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Models.TargetResource>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Models.TargetResource>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.Models.TargetResource System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.TargetResource>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.TargetResource>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.TargetResource>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class TemplateHashResult : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Models.TemplateHashResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.TemplateHashResult>
    {
        internal TemplateHashResult() { }
        public string MinifiedTemplate { get { throw null; } }
        public string TemplateHash { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.Models.TemplateHashResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Models.TemplateHashResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Models.TemplateHashResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.Models.TemplateHashResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.TemplateHashResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.TemplateHashResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.TemplateHashResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ValidationLevel : System.IEquatable<Azure.ResourceManager.Resources.Models.ValidationLevel>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ValidationLevel(string value) { throw null; }
        public static Azure.ResourceManager.Resources.Models.ValidationLevel Provider { get { throw null; } }
        public static Azure.ResourceManager.Resources.Models.ValidationLevel ProviderNoRbac { get { throw null; } }
        public static Azure.ResourceManager.Resources.Models.ValidationLevel Template { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Resources.Models.ValidationLevel other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Resources.Models.ValidationLevel left, Azure.ResourceManager.Resources.Models.ValidationLevel right) { throw null; }
        public static implicit operator Azure.ResourceManager.Resources.Models.ValidationLevel (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Resources.Models.ValidationLevel left, Azure.ResourceManager.Resources.Models.ValidationLevel right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class WhatIfChange : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Models.WhatIfChange>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.WhatIfChange>
    {
        internal WhatIfChange() { }
        public System.BinaryData After { get { throw null; } }
        public System.BinaryData Before { get { throw null; } }
        public Azure.ResourceManager.Resources.Models.WhatIfChangeType ChangeType { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Resources.Models.WhatIfPropertyChange> Delta { get { throw null; } }
        public string DeploymentId { get { throw null; } }
        public Azure.ResourceManager.Resources.Models.ArmDeploymentExtensionDefinition Extension { get { throw null; } }
        public System.BinaryData Identifiers { get { throw null; } }
        public string ResourceId { get { throw null; } }
        public string SymbolicName { get { throw null; } }
        public string UnsupportedReason { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.Models.WhatIfChange System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Models.WhatIfChange>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Models.WhatIfChange>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.Models.WhatIfChange System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.WhatIfChange>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.WhatIfChange>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.WhatIfChange>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
    public partial class WhatIfOperationResult : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Models.WhatIfOperationResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.WhatIfOperationResult>
    {
        internal WhatIfOperationResult() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Resources.Models.WhatIfChange> Changes { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Resources.Models.DeploymentDiagnosticsDefinition> Diagnostics { get { throw null; } }
        public Azure.ResponseError Error { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Resources.Models.WhatIfChange> PotentialChanges { get { throw null; } }
        public string Status { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.Models.WhatIfOperationResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Models.WhatIfOperationResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Models.WhatIfOperationResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.Models.WhatIfOperationResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.WhatIfOperationResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.WhatIfOperationResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.WhatIfOperationResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class WhatIfPropertyChange : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Models.WhatIfPropertyChange>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.WhatIfPropertyChange>
    {
        internal WhatIfPropertyChange() { }
        public System.BinaryData After { get { throw null; } }
        public System.BinaryData Before { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Resources.Models.WhatIfPropertyChange> Children { get { throw null; } }
        public string Path { get { throw null; } }
        public Azure.ResourceManager.Resources.Models.WhatIfPropertyChangeType PropertyChangeType { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.Models.WhatIfPropertyChange System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Models.WhatIfPropertyChange>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Models.WhatIfPropertyChange>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.Models.WhatIfPropertyChange System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.WhatIfPropertyChange>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.WhatIfPropertyChange>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.WhatIfPropertyChange>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
}
