namespace Azure.ResourceManager.Resources._Deployments
{
    public partial class AzureResourceManagerResources_DeploymentsContext : System.ClientModel.Primitives.ModelReaderWriterContext
    {
        internal AzureResourceManagerResources_DeploymentsContext() { }
        public static Azure.ResourceManager.Resources._Deployments.AzureResourceManagerResources_DeploymentsContext Default { get { throw null; } }
        protected override bool TryGetTypeBuilderCore(System.Type type, out System.ClientModel.Primitives.ModelReaderWriterTypeBuilder builder) { throw null; }
    }
    public partial class DeploymentCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Resources._Deployments.DeploymentResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources._Deployments.DeploymentResource>, System.Collections.IEnumerable
    {
        protected DeploymentCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Resources._Deployments.DeploymentResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string deploymentName, Azure.ResourceManager.Resources._Deployments.Models.Deployment deployment, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Resources._Deployments.DeploymentResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string deploymentName, Azure.ResourceManager.Resources._Deployments.Models.Deployment deployment, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string deploymentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string deploymentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Resources._Deployments.DeploymentResource> Get(string deploymentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Resources._Deployments.DeploymentResource> GetAll(string filter = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Resources._Deployments.DeploymentResource> GetAllAsync(string filter = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources._Deployments.DeploymentResource>> GetAsync(string deploymentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Resources._Deployments.DeploymentResource> GetIfExists(string deploymentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Resources._Deployments.DeploymentResource>> GetIfExistsAsync(string deploymentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Resources._Deployments.DeploymentResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Resources._Deployments.DeploymentResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Resources._Deployments.DeploymentResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources._Deployments.DeploymentResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class DeploymentExtendedData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources._Deployments.DeploymentExtendedData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources._Deployments.DeploymentExtendedData>
    {
        internal DeploymentExtendedData() { }
        public string Location { get { throw null; } }
        public Azure.ResourceManager.Resources._Deployments.Models.DeploymentPropertiesExtended Properties { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Resources._Deployments.DeploymentExtendedData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources._Deployments.DeploymentExtendedData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources._Deployments.DeploymentExtendedData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources._Deployments.DeploymentExtendedData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources._Deployments.DeploymentExtendedData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources._Deployments.DeploymentExtendedData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources._Deployments.DeploymentExtendedData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DeploymentResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources._Deployments.DeploymentExtendedData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources._Deployments.DeploymentExtendedData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected DeploymentResource() { }
        public virtual Azure.ResourceManager.Resources._Deployments.DeploymentExtendedData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.Resources._Deployments.DeploymentResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources._Deployments.DeploymentResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response Cancel(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> CancelAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string deploymentName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Resources._Deployments.Models.DeploymentExportResult> ExportTemplate(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources._Deployments.Models.DeploymentExportResult>> ExportTemplateAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Resources._Deployments.DeploymentResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources._Deployments.DeploymentResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Resources._Deployments.DeploymentResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources._Deployments.DeploymentResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Resources._Deployments.DeploymentResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources._Deployments.DeploymentResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.Resources._Deployments.DeploymentExtendedData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources._Deployments.DeploymentExtendedData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources._Deployments.DeploymentExtendedData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources._Deployments.DeploymentExtendedData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources._Deployments.DeploymentExtendedData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources._Deployments.DeploymentExtendedData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources._Deployments.DeploymentExtendedData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Resources._Deployments.DeploymentResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Resources._Deployments.Models.Deployment deployment, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Resources._Deployments.DeploymentResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Resources._Deployments.Models.Deployment deployment, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Resources._Deployments.Models.DeploymentValidateResult> Validate(Azure.WaitUntil waitUntil, Azure.ResourceManager.Resources._Deployments.Models.Deployment deployment, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Resources._Deployments.Models.DeploymentValidateResult>> ValidateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Resources._Deployments.Models.Deployment deployment, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Resources._Deployments.Models.WhatIfOperationResult> WhatIf(Azure.WaitUntil waitUntil, Azure.ResourceManager.Resources._Deployments.Models.DeploymentWhatIf deploymentWhatIf, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Resources._Deployments.Models.WhatIfOperationResult>> WhatIfAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Resources._Deployments.Models.DeploymentWhatIf deploymentWhatIf, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public static partial class ResourcesDeploymentsExtensions
    {
        public static Azure.Response<Azure.ResourceManager.Resources._Deployments.Models.TemplateHashResult> CalculateTemplateHash(this Azure.ResourceManager.Resources.TenantResource tenantResource, System.BinaryData template, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources._Deployments.Models.TemplateHashResult>> CalculateTemplateHashAsync(this Azure.ResourceManager.Resources.TenantResource tenantResource, System.BinaryData template, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response CheckExistence(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, string deploymentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response> CheckExistenceAsync(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, string deploymentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response CheckExistenceAtManagementGroupScope(this Azure.ResourceManager.ManagementGroups.ManagementGroupResource managementGroupResource, string deploymentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response> CheckExistenceAtManagementGroupScopeAsync(this Azure.ResourceManager.ManagementGroups.ManagementGroupResource managementGroupResource, string deploymentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response CheckExistenceAtScope(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, string deploymentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response> CheckExistenceAtScopeAsync(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, string deploymentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response CheckExistenceAtSubscriptionScope(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string deploymentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response> CheckExistenceAtSubscriptionScopeAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string deploymentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response CheckExistenceAtTenantScope(this Azure.ResourceManager.Resources.TenantResource tenantResource, string deploymentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response> CheckExistenceAtTenantScopeAsync(this Azure.ResourceManager.Resources.TenantResource tenantResource, string deploymentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Resources._Deployments.Models.ArmDeploymentOperation> Get(this Azure.ResourceManager.Resources.TenantResource tenantResource, string resourceGroupName, string deploymentName, string operationId, string subscriptionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Resources._Deployments.Models.ArmDeploymentOperation> GetAll(this Azure.ResourceManager.Resources.TenantResource tenantResource, string resourceGroupName, string deploymentName, string subscriptionId, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Resources._Deployments.Models.ArmDeploymentOperation> GetAllAsync(this Azure.ResourceManager.Resources.TenantResource tenantResource, string resourceGroupName, string deploymentName, string subscriptionId, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources._Deployments.Models.ArmDeploymentOperation>> GetAsync(this Azure.ResourceManager.Resources.TenantResource tenantResource, string resourceGroupName, string deploymentName, string operationId, string subscriptionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Resources._Deployments.DeploymentResource> GetDeployment(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, string deploymentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Resources._Deployments.DeploymentResource> GetDeployment(this Azure.ResourceManager.ManagementGroups.ManagementGroupResource managementGroupResource, string deploymentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Resources._Deployments.DeploymentResource> GetDeployment(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string deploymentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Resources._Deployments.DeploymentResource> GetDeployment(this Azure.ResourceManager.Resources.TenantResource tenantResource, string deploymentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources._Deployments.DeploymentResource>> GetDeploymentAsync(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, string deploymentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources._Deployments.DeploymentResource>> GetDeploymentAsync(this Azure.ResourceManager.ManagementGroups.ManagementGroupResource managementGroupResource, string deploymentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources._Deployments.DeploymentResource>> GetDeploymentAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string deploymentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources._Deployments.DeploymentResource>> GetDeploymentAsync(this Azure.ResourceManager.Resources.TenantResource tenantResource, string deploymentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Resources._Deployments.DeploymentResource GetDeploymentResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Resources._Deployments.DeploymentCollection GetDeployments(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope) { throw null; }
        public static Azure.ResourceManager.Resources._Deployments.DeploymentCollection GetDeployments(this Azure.ResourceManager.ManagementGroups.ManagementGroupResource managementGroupResource) { throw null; }
        public static Azure.ResourceManager.Resources._Deployments.DeploymentCollection GetDeployments(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource) { throw null; }
        public static Azure.ResourceManager.Resources._Deployments.DeploymentCollection GetDeployments(this Azure.ResourceManager.Resources.TenantResource tenantResource) { throw null; }
    }
}
namespace Azure.ResourceManager.Resources._Deployments.Mocking
{
    public partial class MockableResourcesDeploymentsArmClient : Azure.ResourceManager.ArmResource
    {
        protected MockableResourcesDeploymentsArmClient() { }
        public virtual Azure.Response CheckExistence(Azure.Core.ResourceIdentifier scope, string deploymentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> CheckExistenceAsync(Azure.Core.ResourceIdentifier scope, string deploymentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response CheckExistenceAtScope(Azure.Core.ResourceIdentifier scope, string deploymentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> CheckExistenceAtScopeAsync(Azure.Core.ResourceIdentifier scope, string deploymentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Resources._Deployments.DeploymentResource> GetDeployment(Azure.Core.ResourceIdentifier scope, string deploymentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources._Deployments.DeploymentResource>> GetDeploymentAsync(Azure.Core.ResourceIdentifier scope, string deploymentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Resources._Deployments.DeploymentResource GetDeploymentResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Resources._Deployments.DeploymentCollection GetDeployments(Azure.Core.ResourceIdentifier scope) { throw null; }
    }
    public partial class MockableResourcesDeploymentsManagementGroupResource : Azure.ResourceManager.ArmResource
    {
        protected MockableResourcesDeploymentsManagementGroupResource() { }
        public virtual Azure.Response CheckExistenceAtManagementGroupScope(string deploymentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> CheckExistenceAtManagementGroupScopeAsync(string deploymentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Resources._Deployments.DeploymentResource> GetDeployment(string deploymentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources._Deployments.DeploymentResource>> GetDeploymentAsync(string deploymentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Resources._Deployments.DeploymentCollection GetDeployments() { throw null; }
    }
    public partial class MockableResourcesDeploymentsSubscriptionResource : Azure.ResourceManager.ArmResource
    {
        protected MockableResourcesDeploymentsSubscriptionResource() { }
        public virtual Azure.Response CheckExistenceAtSubscriptionScope(string deploymentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> CheckExistenceAtSubscriptionScopeAsync(string deploymentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Resources._Deployments.DeploymentResource> GetDeployment(string deploymentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources._Deployments.DeploymentResource>> GetDeploymentAsync(string deploymentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Resources._Deployments.DeploymentCollection GetDeployments() { throw null; }
    }
    public partial class MockableResourcesDeploymentsTenantResource : Azure.ResourceManager.ArmResource
    {
        protected MockableResourcesDeploymentsTenantResource() { }
        public virtual Azure.Response<Azure.ResourceManager.Resources._Deployments.Models.TemplateHashResult> CalculateTemplateHash(System.BinaryData template, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources._Deployments.Models.TemplateHashResult>> CalculateTemplateHashAsync(System.BinaryData template, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response CheckExistenceAtTenantScope(string deploymentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> CheckExistenceAtTenantScopeAsync(string deploymentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Resources._Deployments.Models.ArmDeploymentOperation> Get(string resourceGroupName, string deploymentName, string operationId, string subscriptionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Resources._Deployments.Models.ArmDeploymentOperation> GetAll(string resourceGroupName, string deploymentName, string subscriptionId, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Resources._Deployments.Models.ArmDeploymentOperation> GetAllAsync(string resourceGroupName, string deploymentName, string subscriptionId, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources._Deployments.Models.ArmDeploymentOperation>> GetAsync(string resourceGroupName, string deploymentName, string operationId, string subscriptionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Resources._Deployments.DeploymentResource> GetDeployment(string deploymentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources._Deployments.DeploymentResource>> GetDeploymentAsync(string deploymentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Resources._Deployments.DeploymentCollection GetDeployments() { throw null; }
    }
}
namespace Azure.ResourceManager.Resources._Deployments.Models
{
    public partial class Alias : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources._Deployments.Models.Alias>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources._Deployments.Models.Alias>
    {
        internal Alias() { }
        public Azure.ResourceManager.Resources._Deployments.Models.AliasPathMetadata DefaultMetadata { get { throw null; } }
        public string DefaultPath { get { throw null; } }
        public Azure.ResourceManager.Resources._Deployments.Models.AliasPattern DefaultPattern { get { throw null; } }
        public string Name { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Resources._Deployments.Models.AliasPath> Paths { get { throw null; } }
        public Azure.ResourceManager.Resources._Deployments.Models.AliasType? Type { get { throw null; } }
        protected virtual Azure.ResourceManager.Resources._Deployments.Models.Alias JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Resources._Deployments.Models.Alias PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Resources._Deployments.Models.Alias System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources._Deployments.Models.Alias>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources._Deployments.Models.Alias>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources._Deployments.Models.Alias System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources._Deployments.Models.Alias>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources._Deployments.Models.Alias>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources._Deployments.Models.Alias>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AliasPath : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources._Deployments.Models.AliasPath>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources._Deployments.Models.AliasPath>
    {
        internal AliasPath() { }
        public System.Collections.Generic.IList<string> ApiVersions { get { throw null; } }
        public Azure.ResourceManager.Resources._Deployments.Models.AliasPathMetadata Metadata { get { throw null; } }
        public string Path { get { throw null; } }
        public Azure.ResourceManager.Resources._Deployments.Models.AliasPattern Pattern { get { throw null; } }
        protected virtual Azure.ResourceManager.Resources._Deployments.Models.AliasPath JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Resources._Deployments.Models.AliasPath PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Resources._Deployments.Models.AliasPath System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources._Deployments.Models.AliasPath>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources._Deployments.Models.AliasPath>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources._Deployments.Models.AliasPath System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources._Deployments.Models.AliasPath>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources._Deployments.Models.AliasPath>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources._Deployments.Models.AliasPath>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AliasPathAttributes : System.IEquatable<Azure.ResourceManager.Resources._Deployments.Models.AliasPathAttributes>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AliasPathAttributes(string value) { throw null; }
        public static Azure.ResourceManager.Resources._Deployments.Models.AliasPathAttributes Modifiable { get { throw null; } }
        public static Azure.ResourceManager.Resources._Deployments.Models.AliasPathAttributes None { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Resources._Deployments.Models.AliasPathAttributes other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Resources._Deployments.Models.AliasPathAttributes left, Azure.ResourceManager.Resources._Deployments.Models.AliasPathAttributes right) { throw null; }
        public static implicit operator Azure.ResourceManager.Resources._Deployments.Models.AliasPathAttributes (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Resources._Deployments.Models.AliasPathAttributes? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Resources._Deployments.Models.AliasPathAttributes left, Azure.ResourceManager.Resources._Deployments.Models.AliasPathAttributes right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class AliasPathMetadata : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources._Deployments.Models.AliasPathMetadata>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources._Deployments.Models.AliasPathMetadata>
    {
        internal AliasPathMetadata() { }
        public Azure.ResourceManager.Resources._Deployments.Models.AliasPathAttributes? Attributes { get { throw null; } }
        public Azure.ResourceManager.Resources._Deployments.Models.AliasPathTokenType? Type { get { throw null; } }
        protected virtual Azure.ResourceManager.Resources._Deployments.Models.AliasPathMetadata JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Resources._Deployments.Models.AliasPathMetadata PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Resources._Deployments.Models.AliasPathMetadata System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources._Deployments.Models.AliasPathMetadata>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources._Deployments.Models.AliasPathMetadata>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources._Deployments.Models.AliasPathMetadata System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources._Deployments.Models.AliasPathMetadata>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources._Deployments.Models.AliasPathMetadata>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources._Deployments.Models.AliasPathMetadata>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AliasPathTokenType : System.IEquatable<Azure.ResourceManager.Resources._Deployments.Models.AliasPathTokenType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AliasPathTokenType(string value) { throw null; }
        public static Azure.ResourceManager.Resources._Deployments.Models.AliasPathTokenType Any { get { throw null; } }
        public static Azure.ResourceManager.Resources._Deployments.Models.AliasPathTokenType Array { get { throw null; } }
        public static Azure.ResourceManager.Resources._Deployments.Models.AliasPathTokenType Boolean { get { throw null; } }
        public static Azure.ResourceManager.Resources._Deployments.Models.AliasPathTokenType Integer { get { throw null; } }
        public static Azure.ResourceManager.Resources._Deployments.Models.AliasPathTokenType NotSpecified { get { throw null; } }
        public static Azure.ResourceManager.Resources._Deployments.Models.AliasPathTokenType Number { get { throw null; } }
        public static Azure.ResourceManager.Resources._Deployments.Models.AliasPathTokenType Object { get { throw null; } }
        public static Azure.ResourceManager.Resources._Deployments.Models.AliasPathTokenType String { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Resources._Deployments.Models.AliasPathTokenType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Resources._Deployments.Models.AliasPathTokenType left, Azure.ResourceManager.Resources._Deployments.Models.AliasPathTokenType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Resources._Deployments.Models.AliasPathTokenType (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Resources._Deployments.Models.AliasPathTokenType? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Resources._Deployments.Models.AliasPathTokenType left, Azure.ResourceManager.Resources._Deployments.Models.AliasPathTokenType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class AliasPattern : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources._Deployments.Models.AliasPattern>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources._Deployments.Models.AliasPattern>
    {
        internal AliasPattern() { }
        public string Phrase { get { throw null; } }
        public Azure.ResourceManager.Resources._Deployments.Models.AliasPatternType? Type { get { throw null; } }
        public string Variable { get { throw null; } }
        protected virtual Azure.ResourceManager.Resources._Deployments.Models.AliasPattern JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Resources._Deployments.Models.AliasPattern PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Resources._Deployments.Models.AliasPattern System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources._Deployments.Models.AliasPattern>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources._Deployments.Models.AliasPattern>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources._Deployments.Models.AliasPattern System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources._Deployments.Models.AliasPattern>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources._Deployments.Models.AliasPattern>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources._Deployments.Models.AliasPattern>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public enum AliasPatternType
    {
        NotSpecified = 0,
        Extract = 1,
    }
    public enum AliasType
    {
        NotSpecified = 0,
        PlainText = 1,
        Mask = 2,
    }
    public partial class ApiProfile : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources._Deployments.Models.ApiProfile>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources._Deployments.Models.ApiProfile>
    {
        internal ApiProfile() { }
        public string ApiVersion { get { throw null; } }
        public string ProfileVersion { get { throw null; } }
        protected virtual Azure.ResourceManager.Resources._Deployments.Models.ApiProfile JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Resources._Deployments.Models.ApiProfile PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Resources._Deployments.Models.ApiProfile System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources._Deployments.Models.ApiProfile>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources._Deployments.Models.ApiProfile>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources._Deployments.Models.ApiProfile System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources._Deployments.Models.ApiProfile>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources._Deployments.Models.ApiProfile>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources._Deployments.Models.ApiProfile>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ArmDeploymentExtensionDefinition : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources._Deployments.Models.ArmDeploymentExtensionDefinition>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources._Deployments.Models.ArmDeploymentExtensionDefinition>
    {
        internal ArmDeploymentExtensionDefinition() { }
        public string Alias { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, Azure.ResourceManager.Resources._Deployments.Models.DeploymentExtensionConfigItem> Config { get { throw null; } }
        public string ConfigId { get { throw null; } }
        public string Name { get { throw null; } }
        public string Version { get { throw null; } }
        protected virtual Azure.ResourceManager.Resources._Deployments.Models.ArmDeploymentExtensionDefinition JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Resources._Deployments.Models.ArmDeploymentExtensionDefinition PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Resources._Deployments.Models.ArmDeploymentExtensionDefinition System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources._Deployments.Models.ArmDeploymentExtensionDefinition>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources._Deployments.Models.ArmDeploymentExtensionDefinition>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources._Deployments.Models.ArmDeploymentExtensionDefinition System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources._Deployments.Models.ArmDeploymentExtensionDefinition>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources._Deployments.Models.ArmDeploymentExtensionDefinition>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources._Deployments.Models.ArmDeploymentExtensionDefinition>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ArmDeploymentOperation : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources._Deployments.Models.ArmDeploymentOperation>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources._Deployments.Models.ArmDeploymentOperation>
    {
        internal ArmDeploymentOperation() { }
        public string Id { get { throw null; } }
        public string OperationId { get { throw null; } }
        public Azure.ResourceManager.Resources._Deployments.Models.DeploymentOperationProperties Properties { get { throw null; } }
        protected virtual Azure.ResourceManager.Resources._Deployments.Models.ArmDeploymentOperation JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Resources._Deployments.Models.ArmDeploymentOperation PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Resources._Deployments.Models.ArmDeploymentOperation System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources._Deployments.Models.ArmDeploymentOperation>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources._Deployments.Models.ArmDeploymentOperation>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources._Deployments.Models.ArmDeploymentOperation System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources._Deployments.Models.ArmDeploymentOperation>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources._Deployments.Models.ArmDeploymentOperation>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources._Deployments.Models.ArmDeploymentOperation>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public static partial class ArmResourcesDeploymentsModelFactory
    {
        public static Azure.ResourceManager.Resources._Deployments.Models.Alias Alias(string name = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources._Deployments.Models.AliasPath> paths = null, Azure.ResourceManager.Resources._Deployments.Models.AliasType? type = default(Azure.ResourceManager.Resources._Deployments.Models.AliasType?), string defaultPath = null, Azure.ResourceManager.Resources._Deployments.Models.AliasPattern defaultPattern = null, Azure.ResourceManager.Resources._Deployments.Models.AliasPathMetadata defaultMetadata = null) { throw null; }
        public static Azure.ResourceManager.Resources._Deployments.Models.AliasPath AliasPath(string path = null, System.Collections.Generic.IEnumerable<string> apiVersions = null, Azure.ResourceManager.Resources._Deployments.Models.AliasPattern pattern = null, Azure.ResourceManager.Resources._Deployments.Models.AliasPathMetadata metadata = null) { throw null; }
        public static Azure.ResourceManager.Resources._Deployments.Models.AliasPathMetadata AliasPathMetadata(Azure.ResourceManager.Resources._Deployments.Models.AliasPathTokenType? type = default(Azure.ResourceManager.Resources._Deployments.Models.AliasPathTokenType?), Azure.ResourceManager.Resources._Deployments.Models.AliasPathAttributes? attributes = default(Azure.ResourceManager.Resources._Deployments.Models.AliasPathAttributes?)) { throw null; }
        public static Azure.ResourceManager.Resources._Deployments.Models.AliasPattern AliasPattern(string phrase = null, string variable = null, Azure.ResourceManager.Resources._Deployments.Models.AliasPatternType? type = default(Azure.ResourceManager.Resources._Deployments.Models.AliasPatternType?)) { throw null; }
        public static Azure.ResourceManager.Resources._Deployments.Models.ApiProfile ApiProfile(string profileVersion = null, string apiVersion = null) { throw null; }
        public static Azure.ResourceManager.Resources._Deployments.Models.ArmDeploymentExtensionDefinition ArmDeploymentExtensionDefinition(string alias = null, string name = null, string version = null, string configId = null, System.Collections.Generic.IReadOnlyDictionary<string, Azure.ResourceManager.Resources._Deployments.Models.DeploymentExtensionConfigItem> config = null) { throw null; }
        public static Azure.ResourceManager.Resources._Deployments.Models.ArmDeploymentOperation ArmDeploymentOperation(string id = null, string operationId = null, Azure.ResourceManager.Resources._Deployments.Models.DeploymentOperationProperties properties = null) { throw null; }
        public static Azure.ResourceManager.Resources._Deployments.Models.BasicDependency BasicDependency(string id = null, string resourceType = null, string resourceName = null) { throw null; }
        public static Azure.ResourceManager.Resources._Deployments.Models.Dependency Dependency(System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources._Deployments.Models.BasicDependency> dependsOn = null, string id = null, string resourceType = null, string resourceName = null) { throw null; }
        public static Azure.ResourceManager.Resources._Deployments.Models.Deployment Deployment(string location = null, Azure.ResourceManager.Resources._Deployments.Models.DeploymentProperties properties = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.ResourceManager.Resources._Deployments.Models.DeploymentIdentity identity = null) { throw null; }
        public static Azure.ResourceManager.Resources._Deployments.Models.DeploymentDiagnosticsDefinition DeploymentDiagnosticsDefinition(Azure.ResourceManager.Resources._Deployments.Models.Level level = default(Azure.ResourceManager.Resources._Deployments.Models.Level), string code = null, string message = null, string target = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources._Deployments.Models.ErrorAdditionalInfo> additionalInfo = null) { throw null; }
        public static Azure.ResourceManager.Resources._Deployments.Models.DeploymentExportResult DeploymentExportResult(System.BinaryData template = null) { throw null; }
        public static Azure.ResourceManager.Resources._Deployments.DeploymentExtendedData DeploymentExtendedData(string id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.Resources._Deployments.Models.DeploymentPropertiesExtended properties = null, string location = null, System.Collections.Generic.IDictionary<string, string> tags = null) { throw null; }
        public static Azure.ResourceManager.Resources._Deployments.Models.DeploymentExtensionConfigItem DeploymentExtensionConfigItem(Azure.ResourceManager.Resources._Deployments.Models.ExtensionConfigPropertyType? type = default(Azure.ResourceManager.Resources._Deployments.Models.ExtensionConfigPropertyType?), System.BinaryData value = null, Azure.ResourceManager.Resources._Deployments.Models.KeyVaultParameterReference keyVaultReference = null) { throw null; }
        public static Azure.ResourceManager.Resources._Deployments.Models.DeploymentExternalInput DeploymentExternalInput(System.BinaryData value = null) { throw null; }
        public static Azure.ResourceManager.Resources._Deployments.Models.DeploymentExternalInputDefinition DeploymentExternalInputDefinition(string kind = null, System.BinaryData config = null) { throw null; }
        public static Azure.ResourceManager.Resources._Deployments.Models.DeploymentIdentity DeploymentIdentity(Azure.ResourceManager.Resources._Deployments.Models.DeploymentIdentityType type = default(Azure.ResourceManager.Resources._Deployments.Models.DeploymentIdentityType), System.Collections.Generic.IDictionary<string, Azure.ResourceManager.Models.UserAssignedIdentity> userAssignedIdentities = null) { throw null; }
        public static Azure.ResourceManager.Resources._Deployments.Models.DeploymentOperationProperties DeploymentOperationProperties(Azure.ResourceManager.Resources._Deployments.Models.ProvisioningOperation? provisioningOperation = default(Azure.ResourceManager.Resources._Deployments.Models.ProvisioningOperation?), string provisioningState = null, System.DateTimeOffset? timestamp = default(System.DateTimeOffset?), string duration = null, string serviceRequestId = null, string statusCode = null, Azure.ResourceManager.Resources._Deployments.Models.StatusMessage statusMessage = null, Azure.ResourceManager.Resources._Deployments.Models.TargetResource targetResource = null, System.BinaryData requestContent = null, System.BinaryData responseContent = null) { throw null; }
        public static Azure.ResourceManager.Resources._Deployments.Models.DeploymentProperties DeploymentProperties(System.BinaryData template = null, Azure.ResourceManager.Resources._Deployments.Models.TemplateLink templateLink = null, System.Collections.Generic.IDictionary<string, Azure.ResourceManager.Resources._Deployments.Models.DeploymentParameterValue> parameters = null, System.Collections.Generic.IDictionary<string, Azure.ResourceManager.Resources._Deployments.Models.DeploymentExternalInput> externalInputs = null, System.Collections.Generic.IDictionary<string, Azure.ResourceManager.Resources._Deployments.Models.DeploymentExternalInputDefinition> externalInputDefinitions = null, Azure.ResourceManager.Resources._Deployments.Models.ParametersLink parametersLink = null, System.Collections.Generic.IDictionary<string, System.Collections.Generic.IDictionary<string, Azure.ResourceManager.Resources._Deployments.Models.DeploymentExtensionConfigItem>> extensionConfigs = null, Azure.ResourceManager.Resources._Deployments.Models.DeploymentMode mode = Azure.ResourceManager.Resources._Deployments.Models.DeploymentMode.Incremental, string debugSettingDetailLevel = null, Azure.ResourceManager.Resources._Deployments.Models.OnErrorDeployment onErrorDeployment = null, Azure.ResourceManager.Resources._Deployments.Models.ExpressionEvaluationOptionsScopeType? expressionEvaluationOptionsScope = default(Azure.ResourceManager.Resources._Deployments.Models.ExpressionEvaluationOptionsScopeType?), Azure.ResourceManager.Resources._Deployments.Models.ValidationLevel? validationLevel = default(Azure.ResourceManager.Resources._Deployments.Models.ValidationLevel?)) { throw null; }
        public static Azure.ResourceManager.Resources._Deployments.Models.DeploymentPropertiesExtended DeploymentPropertiesExtended(Azure.ResourceManager.Resources._Deployments.Models.ProvisioningState? provisioningState = default(Azure.ResourceManager.Resources._Deployments.Models.ProvisioningState?), string correlationId = null, System.DateTimeOffset? timestamp = default(System.DateTimeOffset?), string duration = null, System.BinaryData outputs = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources._Deployments.Models.Provider> providers = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources._Deployments.Models.Dependency> dependencies = null, Azure.ResourceManager.Resources._Deployments.Models.TemplateLink templateLink = null, System.BinaryData parameters = null, Azure.ResourceManager.Resources._Deployments.Models.ParametersLink parametersLink = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources._Deployments.Models.ArmDeploymentExtensionDefinition> extensions = null, Azure.ResourceManager.Resources._Deployments.Models.DeploymentMode? mode = default(Azure.ResourceManager.Resources._Deployments.Models.DeploymentMode?), string debugSettingDetailLevel = null, Azure.ResourceManager.Resources._Deployments.Models.OnErrorDeploymentExtended onErrorDeployment = null, string templateHash = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources._Deployments.Models.ResourceReference> outputResources = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources._Deployments.Models.ResourceReference> validatedResources = null, Azure.ResourceManager.Resources._Deployments.Models.ErrorResponse error = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources._Deployments.Models.DeploymentDiagnosticsDefinition> diagnostics = null, Azure.ResourceManager.Resources._Deployments.Models.ValidationLevel? validationLevel = default(Azure.ResourceManager.Resources._Deployments.Models.ValidationLevel?)) { throw null; }
        public static Azure.ResourceManager.Resources._Deployments.Models.DeploymentValidateResult DeploymentValidateResult(Azure.ResourceManager.Resources._Deployments.Models.ErrorResponse error = null, string id = null, string name = null, string type = null, Azure.ResourceManager.Resources._Deployments.Models.DeploymentPropertiesExtended properties = null) { throw null; }
        public static Azure.ResourceManager.Resources._Deployments.Models.DeploymentWhatIf DeploymentWhatIf(string location = null, Azure.ResourceManager.Resources._Deployments.Models.DeploymentWhatIfProperties properties = null) { throw null; }
        public static Azure.ResourceManager.Resources._Deployments.Models.DeploymentWhatIfProperties DeploymentWhatIfProperties(System.BinaryData template = null, Azure.ResourceManager.Resources._Deployments.Models.TemplateLink templateLink = null, System.Collections.Generic.IDictionary<string, Azure.ResourceManager.Resources._Deployments.Models.DeploymentParameterValue> parameters = null, System.Collections.Generic.IDictionary<string, Azure.ResourceManager.Resources._Deployments.Models.DeploymentExternalInput> externalInputs = null, System.Collections.Generic.IDictionary<string, Azure.ResourceManager.Resources._Deployments.Models.DeploymentExternalInputDefinition> externalInputDefinitions = null, Azure.ResourceManager.Resources._Deployments.Models.ParametersLink parametersLink = null, System.Collections.Generic.IDictionary<string, System.Collections.Generic.IDictionary<string, Azure.ResourceManager.Resources._Deployments.Models.DeploymentExtensionConfigItem>> extensionConfigs = null, Azure.ResourceManager.Resources._Deployments.Models.DeploymentMode mode = Azure.ResourceManager.Resources._Deployments.Models.DeploymentMode.Incremental, string debugSettingDetailLevel = null, Azure.ResourceManager.Resources._Deployments.Models.OnErrorDeployment onErrorDeployment = null, Azure.ResourceManager.Resources._Deployments.Models.ExpressionEvaluationOptionsScopeType? expressionEvaluationOptionsScope = default(Azure.ResourceManager.Resources._Deployments.Models.ExpressionEvaluationOptionsScopeType?), Azure.ResourceManager.Resources._Deployments.Models.ValidationLevel? validationLevel = default(Azure.ResourceManager.Resources._Deployments.Models.ValidationLevel?), Azure.ResourceManager.Resources._Deployments.Models.WhatIfResultFormat? whatIfResultFormat = default(Azure.ResourceManager.Resources._Deployments.Models.WhatIfResultFormat?)) { throw null; }
        public static Azure.ResourceManager.Resources._Deployments.Models.ErrorAdditionalInfo ErrorAdditionalInfo(string type = null, System.BinaryData info = null) { throw null; }
        public static Azure.ResourceManager.Resources._Deployments.Models.ErrorResponse ErrorResponse(string code = null, string message = null, string target = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources._Deployments.Models.ErrorResponse> details = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources._Deployments.Models.ErrorAdditionalInfo> additionalInfo = null) { throw null; }
        public static Azure.ResourceManager.Resources._Deployments.Models.OnErrorDeploymentExtended OnErrorDeploymentExtended(string provisioningState = null, Azure.ResourceManager.Resources._Deployments.Models.OnErrorDeploymentType? type = default(Azure.ResourceManager.Resources._Deployments.Models.OnErrorDeploymentType?), string deploymentName = null) { throw null; }
        public static Azure.ResourceManager.Resources._Deployments.Models.Provider Provider(string id = null, string @namespace = null, string registrationState = null, string registrationPolicy = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources._Deployments.Models.ProviderResourceType> resourceTypes = null, Azure.ResourceManager.Resources._Deployments.Models.ProviderAuthorizationConsentState? providerAuthorizationConsentState = default(Azure.ResourceManager.Resources._Deployments.Models.ProviderAuthorizationConsentState?)) { throw null; }
        public static Azure.ResourceManager.Resources._Deployments.Models.ProviderExtendedLocation ProviderExtendedLocation(string location = null, string type = null, System.Collections.Generic.IEnumerable<string> extendedLocations = null) { throw null; }
        public static Azure.ResourceManager.Resources._Deployments.Models.ProviderResourceType ProviderResourceType(string resourceType = null, System.Collections.Generic.IEnumerable<string> locations = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources._Deployments.Models.ProviderExtendedLocation> locationMappings = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources._Deployments.Models.Alias> aliases = null, System.Collections.Generic.IEnumerable<string> apiVersions = null, string defaultApiVersion = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources._Deployments.Models.ZoneMapping> zoneMappings = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources._Deployments.Models.ApiProfile> apiProfiles = null, string capabilities = null, System.Collections.Generic.IDictionary<string, string> properties = null) { throw null; }
        public static Azure.ResourceManager.Resources._Deployments.Models.ResourceReference ResourceReference(string id = null, Azure.ResourceManager.Resources._Deployments.Models.ArmDeploymentExtensionDefinition extension = null, string resourceType = null, System.BinaryData identifiers = null, string apiVersion = null) { throw null; }
        public static Azure.ResourceManager.Resources._Deployments.Models.ScopedDeployment ScopedDeployment(string location = null, Azure.ResourceManager.Resources._Deployments.Models.DeploymentProperties properties = null, System.Collections.Generic.IDictionary<string, string> tags = null) { throw null; }
        public static Azure.ResourceManager.Resources._Deployments.Models.ScopedDeploymentWhatIf ScopedDeploymentWhatIf(string location = null, Azure.ResourceManager.Resources._Deployments.Models.DeploymentWhatIfProperties properties = null) { throw null; }
        public static Azure.ResourceManager.Resources._Deployments.Models.StatusMessage StatusMessage(string status = null, Azure.ResourceManager.Resources._Deployments.Models.ErrorResponse error = null) { throw null; }
        public static Azure.ResourceManager.Resources._Deployments.Models.TargetResource TargetResource(string id = null, string resourceName = null, string resourceType = null, Azure.ResourceManager.Resources._Deployments.Models.ArmDeploymentExtensionDefinition extension = null, System.BinaryData identifiers = null, string apiVersion = null, string symbolicName = null) { throw null; }
        public static Azure.ResourceManager.Resources._Deployments.Models.TemplateHashResult TemplateHashResult(string minifiedTemplate = null, string templateHash = null) { throw null; }
        public static Azure.ResourceManager.Resources._Deployments.Models.WhatIfChange WhatIfChange(string resourceId = null, string deploymentId = null, string symbolicName = null, System.BinaryData identifiers = null, Azure.ResourceManager.Resources._Deployments.Models.ArmDeploymentExtensionDefinition extension = null, Azure.ResourceManager.Resources._Deployments.Models.ChangeType changeType = Azure.ResourceManager.Resources._Deployments.Models.ChangeType.Create, string unsupportedReason = null, System.BinaryData before = null, System.BinaryData after = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources._Deployments.Models.WhatIfPropertyChange> delta = null) { throw null; }
        public static Azure.ResourceManager.Resources._Deployments.Models.WhatIfOperationResult WhatIfOperationResult(string status = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources._Deployments.Models.WhatIfChange> changes = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources._Deployments.Models.WhatIfChange> potentialChanges = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources._Deployments.Models.DeploymentDiagnosticsDefinition> diagnostics = null, Azure.ResourceManager.Resources._Deployments.Models.ErrorResponse error = null) { throw null; }
        public static Azure.ResourceManager.Resources._Deployments.Models.WhatIfPropertyChange WhatIfPropertyChange(string path = null, Azure.ResourceManager.Resources._Deployments.Models.PropertyChangeType propertyChangeType = Azure.ResourceManager.Resources._Deployments.Models.PropertyChangeType.Create, System.BinaryData before = null, System.BinaryData after = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources._Deployments.Models.WhatIfPropertyChange> children = null) { throw null; }
        public static Azure.ResourceManager.Resources._Deployments.Models.ZoneMapping ZoneMapping(string location = null, System.Collections.Generic.IEnumerable<string> zones = null) { throw null; }
    }
    public partial class BasicDependency : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources._Deployments.Models.BasicDependency>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources._Deployments.Models.BasicDependency>
    {
        internal BasicDependency() { }
        public string Id { get { throw null; } }
        public string ResourceName { get { throw null; } }
        public string ResourceType { get { throw null; } }
        protected virtual Azure.ResourceManager.Resources._Deployments.Models.BasicDependency JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Resources._Deployments.Models.BasicDependency PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Resources._Deployments.Models.BasicDependency System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources._Deployments.Models.BasicDependency>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources._Deployments.Models.BasicDependency>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources._Deployments.Models.BasicDependency System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources._Deployments.Models.BasicDependency>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources._Deployments.Models.BasicDependency>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources._Deployments.Models.BasicDependency>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public enum ChangeType
    {
        Create = 0,
        Delete = 1,
        Ignore = 2,
        Deploy = 3,
        NoChange = 4,
        Modify = 5,
        Unsupported = 6,
    }
    public partial class Dependency : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources._Deployments.Models.Dependency>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources._Deployments.Models.Dependency>
    {
        internal Dependency() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.Resources._Deployments.Models.BasicDependency> DependsOn { get { throw null; } }
        public string Id { get { throw null; } }
        public string ResourceName { get { throw null; } }
        public string ResourceType { get { throw null; } }
        protected virtual Azure.ResourceManager.Resources._Deployments.Models.Dependency JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Resources._Deployments.Models.Dependency PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Resources._Deployments.Models.Dependency System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources._Deployments.Models.Dependency>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources._Deployments.Models.Dependency>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources._Deployments.Models.Dependency System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources._Deployments.Models.Dependency>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources._Deployments.Models.Dependency>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources._Deployments.Models.Dependency>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class Deployment : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources._Deployments.Models.Deployment>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources._Deployments.Models.Deployment>
    {
        public Deployment(Azure.ResourceManager.Resources._Deployments.Models.DeploymentProperties properties) { }
        public Azure.ResourceManager.Resources._Deployments.Models.DeploymentIdentity Identity { get { throw null; } set { } }
        public string Location { get { throw null; } set { } }
        public Azure.ResourceManager.Resources._Deployments.Models.DeploymentProperties Properties { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        protected virtual Azure.ResourceManager.Resources._Deployments.Models.Deployment JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Resources._Deployments.Models.Deployment PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Resources._Deployments.Models.Deployment System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources._Deployments.Models.Deployment>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources._Deployments.Models.Deployment>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources._Deployments.Models.Deployment System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources._Deployments.Models.Deployment>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources._Deployments.Models.Deployment>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources._Deployments.Models.Deployment>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DeploymentDiagnosticsDefinition : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources._Deployments.Models.DeploymentDiagnosticsDefinition>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources._Deployments.Models.DeploymentDiagnosticsDefinition>
    {
        internal DeploymentDiagnosticsDefinition() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Resources._Deployments.Models.ErrorAdditionalInfo> AdditionalInfo { get { throw null; } }
        public string Code { get { throw null; } }
        public Azure.ResourceManager.Resources._Deployments.Models.Level Level { get { throw null; } }
        public string Message { get { throw null; } }
        public string Target { get { throw null; } }
        protected virtual Azure.ResourceManager.Resources._Deployments.Models.DeploymentDiagnosticsDefinition JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Resources._Deployments.Models.DeploymentDiagnosticsDefinition PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Resources._Deployments.Models.DeploymentDiagnosticsDefinition System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources._Deployments.Models.DeploymentDiagnosticsDefinition>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources._Deployments.Models.DeploymentDiagnosticsDefinition>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources._Deployments.Models.DeploymentDiagnosticsDefinition System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources._Deployments.Models.DeploymentDiagnosticsDefinition>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources._Deployments.Models.DeploymentDiagnosticsDefinition>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources._Deployments.Models.DeploymentDiagnosticsDefinition>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DeploymentExportResult : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources._Deployments.Models.DeploymentExportResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources._Deployments.Models.DeploymentExportResult>
    {
        internal DeploymentExportResult() { }
        public System.BinaryData Template { get { throw null; } }
        protected virtual Azure.ResourceManager.Resources._Deployments.Models.DeploymentExportResult JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Resources._Deployments.Models.DeploymentExportResult PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Resources._Deployments.Models.DeploymentExportResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources._Deployments.Models.DeploymentExportResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources._Deployments.Models.DeploymentExportResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources._Deployments.Models.DeploymentExportResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources._Deployments.Models.DeploymentExportResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources._Deployments.Models.DeploymentExportResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources._Deployments.Models.DeploymentExportResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DeploymentExtensionConfigItem : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources._Deployments.Models.DeploymentExtensionConfigItem>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources._Deployments.Models.DeploymentExtensionConfigItem>
    {
        public DeploymentExtensionConfigItem() { }
        public Azure.ResourceManager.Resources._Deployments.Models.KeyVaultParameterReference KeyVaultReference { get { throw null; } set { } }
        public Azure.ResourceManager.Resources._Deployments.Models.ExtensionConfigPropertyType? Type { get { throw null; } }
        public System.BinaryData Value { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Resources._Deployments.Models.DeploymentExtensionConfigItem JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Resources._Deployments.Models.DeploymentExtensionConfigItem PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Resources._Deployments.Models.DeploymentExtensionConfigItem System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources._Deployments.Models.DeploymentExtensionConfigItem>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources._Deployments.Models.DeploymentExtensionConfigItem>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources._Deployments.Models.DeploymentExtensionConfigItem System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources._Deployments.Models.DeploymentExtensionConfigItem>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources._Deployments.Models.DeploymentExtensionConfigItem>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources._Deployments.Models.DeploymentExtensionConfigItem>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DeploymentExternalInput : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources._Deployments.Models.DeploymentExternalInput>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources._Deployments.Models.DeploymentExternalInput>
    {
        public DeploymentExternalInput(System.BinaryData value) { }
        public System.BinaryData Value { get { throw null; } }
        protected virtual Azure.ResourceManager.Resources._Deployments.Models.DeploymentExternalInput JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Resources._Deployments.Models.DeploymentExternalInput PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Resources._Deployments.Models.DeploymentExternalInput System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources._Deployments.Models.DeploymentExternalInput>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources._Deployments.Models.DeploymentExternalInput>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources._Deployments.Models.DeploymentExternalInput System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources._Deployments.Models.DeploymentExternalInput>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources._Deployments.Models.DeploymentExternalInput>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources._Deployments.Models.DeploymentExternalInput>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DeploymentExternalInputDefinition : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources._Deployments.Models.DeploymentExternalInputDefinition>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources._Deployments.Models.DeploymentExternalInputDefinition>
    {
        public DeploymentExternalInputDefinition(string kind) { }
        public System.BinaryData Config { get { throw null; } set { } }
        public string Kind { get { throw null; } }
        protected virtual Azure.ResourceManager.Resources._Deployments.Models.DeploymentExternalInputDefinition JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Resources._Deployments.Models.DeploymentExternalInputDefinition PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Resources._Deployments.Models.DeploymentExternalInputDefinition System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources._Deployments.Models.DeploymentExternalInputDefinition>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources._Deployments.Models.DeploymentExternalInputDefinition>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources._Deployments.Models.DeploymentExternalInputDefinition System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources._Deployments.Models.DeploymentExternalInputDefinition>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources._Deployments.Models.DeploymentExternalInputDefinition>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources._Deployments.Models.DeploymentExternalInputDefinition>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DeploymentIdentity : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources._Deployments.Models.DeploymentIdentity>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources._Deployments.Models.DeploymentIdentity>
    {
        public DeploymentIdentity(Azure.ResourceManager.Resources._Deployments.Models.DeploymentIdentityType type) { }
        public Azure.ResourceManager.Resources._Deployments.Models.DeploymentIdentityType Type { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, Azure.ResourceManager.Models.UserAssignedIdentity> UserAssignedIdentities { get { throw null; } }
        protected virtual Azure.ResourceManager.Resources._Deployments.Models.DeploymentIdentity JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Resources._Deployments.Models.DeploymentIdentity PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Resources._Deployments.Models.DeploymentIdentity System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources._Deployments.Models.DeploymentIdentity>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources._Deployments.Models.DeploymentIdentity>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources._Deployments.Models.DeploymentIdentity System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources._Deployments.Models.DeploymentIdentity>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources._Deployments.Models.DeploymentIdentity>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources._Deployments.Models.DeploymentIdentity>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DeploymentIdentityType : System.IEquatable<Azure.ResourceManager.Resources._Deployments.Models.DeploymentIdentityType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DeploymentIdentityType(string value) { throw null; }
        public static Azure.ResourceManager.Resources._Deployments.Models.DeploymentIdentityType None { get { throw null; } }
        public static Azure.ResourceManager.Resources._Deployments.Models.DeploymentIdentityType UserAssigned { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Resources._Deployments.Models.DeploymentIdentityType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Resources._Deployments.Models.DeploymentIdentityType left, Azure.ResourceManager.Resources._Deployments.Models.DeploymentIdentityType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Resources._Deployments.Models.DeploymentIdentityType (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Resources._Deployments.Models.DeploymentIdentityType? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Resources._Deployments.Models.DeploymentIdentityType left, Azure.ResourceManager.Resources._Deployments.Models.DeploymentIdentityType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public enum DeploymentMode
    {
        Incremental = 0,
        Complete = 1,
    }
    public partial class DeploymentOperationProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources._Deployments.Models.DeploymentOperationProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources._Deployments.Models.DeploymentOperationProperties>
    {
        internal DeploymentOperationProperties() { }
        public string Duration { get { throw null; } }
        public Azure.ResourceManager.Resources._Deployments.Models.ProvisioningOperation? ProvisioningOperation { get { throw null; } }
        public string ProvisioningState { get { throw null; } }
        public System.BinaryData RequestContent { get { throw null; } }
        public System.BinaryData ResponseContent { get { throw null; } }
        public string ServiceRequestId { get { throw null; } }
        public string StatusCode { get { throw null; } }
        public Azure.ResourceManager.Resources._Deployments.Models.StatusMessage StatusMessage { get { throw null; } }
        public Azure.ResourceManager.Resources._Deployments.Models.TargetResource TargetResource { get { throw null; } }
        public System.DateTimeOffset? Timestamp { get { throw null; } }
        protected virtual Azure.ResourceManager.Resources._Deployments.Models.DeploymentOperationProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Resources._Deployments.Models.DeploymentOperationProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Resources._Deployments.Models.DeploymentOperationProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources._Deployments.Models.DeploymentOperationProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources._Deployments.Models.DeploymentOperationProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources._Deployments.Models.DeploymentOperationProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources._Deployments.Models.DeploymentOperationProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources._Deployments.Models.DeploymentOperationProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources._Deployments.Models.DeploymentOperationProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DeploymentParameterValue : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources._Deployments.Models.DeploymentParameterValue>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources._Deployments.Models.DeploymentParameterValue>
    {
        public DeploymentParameterValue() { }
        public string Expression { get { throw null; } set { } }
        public Azure.ResourceManager.Resources._Deployments.Models.KeyVaultParameterReference Reference { get { throw null; } set { } }
        public System.BinaryData Value { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Resources._Deployments.Models.DeploymentParameterValue JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Resources._Deployments.Models.DeploymentParameterValue PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Resources._Deployments.Models.DeploymentParameterValue System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources._Deployments.Models.DeploymentParameterValue>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources._Deployments.Models.DeploymentParameterValue>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources._Deployments.Models.DeploymentParameterValue System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources._Deployments.Models.DeploymentParameterValue>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources._Deployments.Models.DeploymentParameterValue>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources._Deployments.Models.DeploymentParameterValue>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DeploymentProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources._Deployments.Models.DeploymentProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources._Deployments.Models.DeploymentProperties>
    {
        public DeploymentProperties(Azure.ResourceManager.Resources._Deployments.Models.DeploymentMode mode) { }
        public string DebugSettingDetailLevel { get { throw null; } set { } }
        public Azure.ResourceManager.Resources._Deployments.Models.ExpressionEvaluationOptionsScopeType? ExpressionEvaluationOptionsScope { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, System.Collections.Generic.IDictionary<string, Azure.ResourceManager.Resources._Deployments.Models.DeploymentExtensionConfigItem>> ExtensionConfigs { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, Azure.ResourceManager.Resources._Deployments.Models.DeploymentExternalInputDefinition> ExternalInputDefinitions { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, Azure.ResourceManager.Resources._Deployments.Models.DeploymentExternalInput> ExternalInputs { get { throw null; } }
        public Azure.ResourceManager.Resources._Deployments.Models.DeploymentMode Mode { get { throw null; } }
        public Azure.ResourceManager.Resources._Deployments.Models.OnErrorDeployment OnErrorDeployment { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, Azure.ResourceManager.Resources._Deployments.Models.DeploymentParameterValue> Parameters { get { throw null; } }
        public Azure.ResourceManager.Resources._Deployments.Models.ParametersLink ParametersLink { get { throw null; } set { } }
        public System.BinaryData Template { get { throw null; } set { } }
        public Azure.ResourceManager.Resources._Deployments.Models.TemplateLink TemplateLink { get { throw null; } set { } }
        public Azure.ResourceManager.Resources._Deployments.Models.ValidationLevel? ValidationLevel { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Resources._Deployments.Models.DeploymentProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Resources._Deployments.Models.DeploymentProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Resources._Deployments.Models.DeploymentProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources._Deployments.Models.DeploymentProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources._Deployments.Models.DeploymentProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources._Deployments.Models.DeploymentProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources._Deployments.Models.DeploymentProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources._Deployments.Models.DeploymentProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources._Deployments.Models.DeploymentProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DeploymentPropertiesExtended : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources._Deployments.Models.DeploymentPropertiesExtended>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources._Deployments.Models.DeploymentPropertiesExtended>
    {
        internal DeploymentPropertiesExtended() { }
        public string CorrelationId { get { throw null; } }
        public string DebugSettingDetailLevel { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Resources._Deployments.Models.Dependency> Dependencies { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Resources._Deployments.Models.DeploymentDiagnosticsDefinition> Diagnostics { get { throw null; } }
        public string Duration { get { throw null; } }
        public Azure.ResourceManager.Resources._Deployments.Models.ErrorResponse Error { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Resources._Deployments.Models.ArmDeploymentExtensionDefinition> Extensions { get { throw null; } }
        public Azure.ResourceManager.Resources._Deployments.Models.DeploymentMode? Mode { get { throw null; } }
        public Azure.ResourceManager.Resources._Deployments.Models.OnErrorDeploymentExtended OnErrorDeployment { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Resources._Deployments.Models.ResourceReference> OutputResources { get { throw null; } }
        public System.BinaryData Outputs { get { throw null; } }
        public System.BinaryData Parameters { get { throw null; } }
        public Azure.ResourceManager.Resources._Deployments.Models.ParametersLink ParametersLink { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Resources._Deployments.Models.Provider> Providers { get { throw null; } }
        public Azure.ResourceManager.Resources._Deployments.Models.ProvisioningState? ProvisioningState { get { throw null; } }
        public string TemplateHash { get { throw null; } }
        public Azure.ResourceManager.Resources._Deployments.Models.TemplateLink TemplateLink { get { throw null; } }
        public System.DateTimeOffset? Timestamp { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Resources._Deployments.Models.ResourceReference> ValidatedResources { get { throw null; } }
        public Azure.ResourceManager.Resources._Deployments.Models.ValidationLevel? ValidationLevel { get { throw null; } }
        protected virtual Azure.ResourceManager.Resources._Deployments.Models.DeploymentPropertiesExtended JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Resources._Deployments.Models.DeploymentPropertiesExtended PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Resources._Deployments.Models.DeploymentPropertiesExtended System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources._Deployments.Models.DeploymentPropertiesExtended>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources._Deployments.Models.DeploymentPropertiesExtended>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources._Deployments.Models.DeploymentPropertiesExtended System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources._Deployments.Models.DeploymentPropertiesExtended>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources._Deployments.Models.DeploymentPropertiesExtended>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources._Deployments.Models.DeploymentPropertiesExtended>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DeploymentValidateResult : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources._Deployments.Models.DeploymentValidateResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources._Deployments.Models.DeploymentValidateResult>
    {
        internal DeploymentValidateResult() { }
        public Azure.ResourceManager.Resources._Deployments.Models.ErrorResponse Error { get { throw null; } }
        public string Id { get { throw null; } }
        public string Name { get { throw null; } }
        public Azure.ResourceManager.Resources._Deployments.Models.DeploymentPropertiesExtended Properties { get { throw null; } }
        public string Type { get { throw null; } }
        protected virtual Azure.ResourceManager.Resources._Deployments.Models.DeploymentValidateResult JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Resources._Deployments.Models.DeploymentValidateResult PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Resources._Deployments.Models.DeploymentValidateResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources._Deployments.Models.DeploymentValidateResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources._Deployments.Models.DeploymentValidateResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources._Deployments.Models.DeploymentValidateResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources._Deployments.Models.DeploymentValidateResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources._Deployments.Models.DeploymentValidateResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources._Deployments.Models.DeploymentValidateResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DeploymentWhatIf : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources._Deployments.Models.DeploymentWhatIf>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources._Deployments.Models.DeploymentWhatIf>
    {
        public DeploymentWhatIf(Azure.ResourceManager.Resources._Deployments.Models.DeploymentWhatIfProperties properties) { }
        public string Location { get { throw null; } set { } }
        public Azure.ResourceManager.Resources._Deployments.Models.DeploymentWhatIfProperties Properties { get { throw null; } }
        protected virtual Azure.ResourceManager.Resources._Deployments.Models.DeploymentWhatIf JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Resources._Deployments.Models.DeploymentWhatIf PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Resources._Deployments.Models.DeploymentWhatIf System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources._Deployments.Models.DeploymentWhatIf>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources._Deployments.Models.DeploymentWhatIf>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources._Deployments.Models.DeploymentWhatIf System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources._Deployments.Models.DeploymentWhatIf>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources._Deployments.Models.DeploymentWhatIf>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources._Deployments.Models.DeploymentWhatIf>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DeploymentWhatIfProperties : Azure.ResourceManager.Resources._Deployments.Models.DeploymentProperties, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources._Deployments.Models.DeploymentWhatIfProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources._Deployments.Models.DeploymentWhatIfProperties>
    {
        public DeploymentWhatIfProperties(Azure.ResourceManager.Resources._Deployments.Models.DeploymentMode mode) : base (default(Azure.ResourceManager.Resources._Deployments.Models.DeploymentMode)) { }
        public Azure.ResourceManager.Resources._Deployments.Models.WhatIfResultFormat? WhatIfResultFormat { get { throw null; } set { } }
        protected override Azure.ResourceManager.Resources._Deployments.Models.DeploymentProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.ResourceManager.Resources._Deployments.Models.DeploymentProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Resources._Deployments.Models.DeploymentWhatIfProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources._Deployments.Models.DeploymentWhatIfProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources._Deployments.Models.DeploymentWhatIfProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources._Deployments.Models.DeploymentWhatIfProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources._Deployments.Models.DeploymentWhatIfProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources._Deployments.Models.DeploymentWhatIfProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources._Deployments.Models.DeploymentWhatIfProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ErrorAdditionalInfo : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources._Deployments.Models.ErrorAdditionalInfo>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources._Deployments.Models.ErrorAdditionalInfo>
    {
        internal ErrorAdditionalInfo() { }
        public System.BinaryData Info { get { throw null; } }
        public string Type { get { throw null; } }
        protected virtual Azure.ResourceManager.Resources._Deployments.Models.ErrorAdditionalInfo JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Resources._Deployments.Models.ErrorAdditionalInfo PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Resources._Deployments.Models.ErrorAdditionalInfo System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources._Deployments.Models.ErrorAdditionalInfo>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources._Deployments.Models.ErrorAdditionalInfo>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources._Deployments.Models.ErrorAdditionalInfo System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources._Deployments.Models.ErrorAdditionalInfo>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources._Deployments.Models.ErrorAdditionalInfo>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources._Deployments.Models.ErrorAdditionalInfo>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ErrorResponse : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources._Deployments.Models.ErrorResponse>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources._Deployments.Models.ErrorResponse>
    {
        internal ErrorResponse() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Resources._Deployments.Models.ErrorAdditionalInfo> AdditionalInfo { get { throw null; } }
        public string Code { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Resources._Deployments.Models.ErrorResponse> Details { get { throw null; } }
        public string Message { get { throw null; } }
        public string Target { get { throw null; } }
        protected virtual Azure.ResourceManager.Resources._Deployments.Models.ErrorResponse JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Resources._Deployments.Models.ErrorResponse PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Resources._Deployments.Models.ErrorResponse System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources._Deployments.Models.ErrorResponse>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources._Deployments.Models.ErrorResponse>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources._Deployments.Models.ErrorResponse System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources._Deployments.Models.ErrorResponse>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources._Deployments.Models.ErrorResponse>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources._Deployments.Models.ErrorResponse>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ExpressionEvaluationOptionsScopeType : System.IEquatable<Azure.ResourceManager.Resources._Deployments.Models.ExpressionEvaluationOptionsScopeType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ExpressionEvaluationOptionsScopeType(string value) { throw null; }
        public static Azure.ResourceManager.Resources._Deployments.Models.ExpressionEvaluationOptionsScopeType Inner { get { throw null; } }
        public static Azure.ResourceManager.Resources._Deployments.Models.ExpressionEvaluationOptionsScopeType NotSpecified { get { throw null; } }
        public static Azure.ResourceManager.Resources._Deployments.Models.ExpressionEvaluationOptionsScopeType Outer { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Resources._Deployments.Models.ExpressionEvaluationOptionsScopeType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Resources._Deployments.Models.ExpressionEvaluationOptionsScopeType left, Azure.ResourceManager.Resources._Deployments.Models.ExpressionEvaluationOptionsScopeType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Resources._Deployments.Models.ExpressionEvaluationOptionsScopeType (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Resources._Deployments.Models.ExpressionEvaluationOptionsScopeType? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Resources._Deployments.Models.ExpressionEvaluationOptionsScopeType left, Azure.ResourceManager.Resources._Deployments.Models.ExpressionEvaluationOptionsScopeType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ExtensionConfigPropertyType : System.IEquatable<Azure.ResourceManager.Resources._Deployments.Models.ExtensionConfigPropertyType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ExtensionConfigPropertyType(string value) { throw null; }
        public static Azure.ResourceManager.Resources._Deployments.Models.ExtensionConfigPropertyType Array { get { throw null; } }
        public static Azure.ResourceManager.Resources._Deployments.Models.ExtensionConfigPropertyType Bool { get { throw null; } }
        public static Azure.ResourceManager.Resources._Deployments.Models.ExtensionConfigPropertyType Int { get { throw null; } }
        public static Azure.ResourceManager.Resources._Deployments.Models.ExtensionConfigPropertyType Object { get { throw null; } }
        public static Azure.ResourceManager.Resources._Deployments.Models.ExtensionConfigPropertyType SecureObject { get { throw null; } }
        public static Azure.ResourceManager.Resources._Deployments.Models.ExtensionConfigPropertyType SecureString { get { throw null; } }
        public static Azure.ResourceManager.Resources._Deployments.Models.ExtensionConfigPropertyType String { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Resources._Deployments.Models.ExtensionConfigPropertyType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Resources._Deployments.Models.ExtensionConfigPropertyType left, Azure.ResourceManager.Resources._Deployments.Models.ExtensionConfigPropertyType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Resources._Deployments.Models.ExtensionConfigPropertyType (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Resources._Deployments.Models.ExtensionConfigPropertyType? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Resources._Deployments.Models.ExtensionConfigPropertyType left, Azure.ResourceManager.Resources._Deployments.Models.ExtensionConfigPropertyType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class KeyVaultParameterReference : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources._Deployments.Models.KeyVaultParameterReference>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources._Deployments.Models.KeyVaultParameterReference>
    {
        public KeyVaultParameterReference(string keyVaultId, string secretName) { }
        public string KeyVaultId { get { throw null; } set { } }
        public string SecretName { get { throw null; } set { } }
        public string SecretVersion { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Resources._Deployments.Models.KeyVaultParameterReference JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Resources._Deployments.Models.KeyVaultParameterReference PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Resources._Deployments.Models.KeyVaultParameterReference System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources._Deployments.Models.KeyVaultParameterReference>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources._Deployments.Models.KeyVaultParameterReference>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources._Deployments.Models.KeyVaultParameterReference System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources._Deployments.Models.KeyVaultParameterReference>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources._Deployments.Models.KeyVaultParameterReference>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources._Deployments.Models.KeyVaultParameterReference>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct Level : System.IEquatable<Azure.ResourceManager.Resources._Deployments.Models.Level>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public Level(string value) { throw null; }
        public static Azure.ResourceManager.Resources._Deployments.Models.Level Error { get { throw null; } }
        public static Azure.ResourceManager.Resources._Deployments.Models.Level Info { get { throw null; } }
        public static Azure.ResourceManager.Resources._Deployments.Models.Level Warning { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Resources._Deployments.Models.Level other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Resources._Deployments.Models.Level left, Azure.ResourceManager.Resources._Deployments.Models.Level right) { throw null; }
        public static implicit operator Azure.ResourceManager.Resources._Deployments.Models.Level (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Resources._Deployments.Models.Level? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Resources._Deployments.Models.Level left, Azure.ResourceManager.Resources._Deployments.Models.Level right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class OnErrorDeployment : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources._Deployments.Models.OnErrorDeployment>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources._Deployments.Models.OnErrorDeployment>
    {
        public OnErrorDeployment() { }
        public string DeploymentName { get { throw null; } set { } }
        public Azure.ResourceManager.Resources._Deployments.Models.OnErrorDeploymentType? Type { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Resources._Deployments.Models.OnErrorDeployment JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Resources._Deployments.Models.OnErrorDeployment PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Resources._Deployments.Models.OnErrorDeployment System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources._Deployments.Models.OnErrorDeployment>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources._Deployments.Models.OnErrorDeployment>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources._Deployments.Models.OnErrorDeployment System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources._Deployments.Models.OnErrorDeployment>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources._Deployments.Models.OnErrorDeployment>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources._Deployments.Models.OnErrorDeployment>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class OnErrorDeploymentExtended : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources._Deployments.Models.OnErrorDeploymentExtended>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources._Deployments.Models.OnErrorDeploymentExtended>
    {
        internal OnErrorDeploymentExtended() { }
        public string DeploymentName { get { throw null; } }
        public string ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.Resources._Deployments.Models.OnErrorDeploymentType? Type { get { throw null; } }
        protected virtual Azure.ResourceManager.Resources._Deployments.Models.OnErrorDeploymentExtended JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Resources._Deployments.Models.OnErrorDeploymentExtended PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Resources._Deployments.Models.OnErrorDeploymentExtended System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources._Deployments.Models.OnErrorDeploymentExtended>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources._Deployments.Models.OnErrorDeploymentExtended>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources._Deployments.Models.OnErrorDeploymentExtended System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources._Deployments.Models.OnErrorDeploymentExtended>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources._Deployments.Models.OnErrorDeploymentExtended>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources._Deployments.Models.OnErrorDeploymentExtended>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public enum OnErrorDeploymentType
    {
        LastSuccessful = 0,
        SpecificDeployment = 1,
    }
    public partial class ParametersLink : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources._Deployments.Models.ParametersLink>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources._Deployments.Models.ParametersLink>
    {
        public ParametersLink(string uri) { }
        public string ContentVersion { get { throw null; } set { } }
        public string Uri { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Resources._Deployments.Models.ParametersLink JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Resources._Deployments.Models.ParametersLink PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Resources._Deployments.Models.ParametersLink System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources._Deployments.Models.ParametersLink>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources._Deployments.Models.ParametersLink>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources._Deployments.Models.ParametersLink System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources._Deployments.Models.ParametersLink>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources._Deployments.Models.ParametersLink>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources._Deployments.Models.ParametersLink>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public enum PropertyChangeType
    {
        Create = 0,
        Delete = 1,
        Modify = 2,
        Array = 3,
        NoEffect = 4,
    }
    public partial class Provider : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources._Deployments.Models.Provider>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources._Deployments.Models.Provider>
    {
        internal Provider() { }
        public string Id { get { throw null; } }
        public string Namespace { get { throw null; } }
        public Azure.ResourceManager.Resources._Deployments.Models.ProviderAuthorizationConsentState? ProviderAuthorizationConsentState { get { throw null; } }
        public string RegistrationPolicy { get { throw null; } }
        public string RegistrationState { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Resources._Deployments.Models.ProviderResourceType> ResourceTypes { get { throw null; } }
        protected virtual Azure.ResourceManager.Resources._Deployments.Models.Provider JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Resources._Deployments.Models.Provider PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Resources._Deployments.Models.Provider System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources._Deployments.Models.Provider>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources._Deployments.Models.Provider>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources._Deployments.Models.Provider System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources._Deployments.Models.Provider>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources._Deployments.Models.Provider>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources._Deployments.Models.Provider>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ProviderAuthorizationConsentState : System.IEquatable<Azure.ResourceManager.Resources._Deployments.Models.ProviderAuthorizationConsentState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ProviderAuthorizationConsentState(string value) { throw null; }
        public static Azure.ResourceManager.Resources._Deployments.Models.ProviderAuthorizationConsentState Consented { get { throw null; } }
        public static Azure.ResourceManager.Resources._Deployments.Models.ProviderAuthorizationConsentState NotRequired { get { throw null; } }
        public static Azure.ResourceManager.Resources._Deployments.Models.ProviderAuthorizationConsentState NotSpecified { get { throw null; } }
        public static Azure.ResourceManager.Resources._Deployments.Models.ProviderAuthorizationConsentState Required { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Resources._Deployments.Models.ProviderAuthorizationConsentState other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Resources._Deployments.Models.ProviderAuthorizationConsentState left, Azure.ResourceManager.Resources._Deployments.Models.ProviderAuthorizationConsentState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Resources._Deployments.Models.ProviderAuthorizationConsentState (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Resources._Deployments.Models.ProviderAuthorizationConsentState? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Resources._Deployments.Models.ProviderAuthorizationConsentState left, Azure.ResourceManager.Resources._Deployments.Models.ProviderAuthorizationConsentState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ProviderExtendedLocation : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources._Deployments.Models.ProviderExtendedLocation>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources._Deployments.Models.ProviderExtendedLocation>
    {
        internal ProviderExtendedLocation() { }
        public System.Collections.Generic.IList<string> ExtendedLocations { get { throw null; } }
        public string Location { get { throw null; } }
        public string Type { get { throw null; } }
        protected virtual Azure.ResourceManager.Resources._Deployments.Models.ProviderExtendedLocation JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Resources._Deployments.Models.ProviderExtendedLocation PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Resources._Deployments.Models.ProviderExtendedLocation System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources._Deployments.Models.ProviderExtendedLocation>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources._Deployments.Models.ProviderExtendedLocation>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources._Deployments.Models.ProviderExtendedLocation System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources._Deployments.Models.ProviderExtendedLocation>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources._Deployments.Models.ProviderExtendedLocation>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources._Deployments.Models.ProviderExtendedLocation>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ProviderResourceType : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources._Deployments.Models.ProviderResourceType>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources._Deployments.Models.ProviderResourceType>
    {
        internal ProviderResourceType() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.Resources._Deployments.Models.Alias> Aliases { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Resources._Deployments.Models.ApiProfile> ApiProfiles { get { throw null; } }
        public System.Collections.Generic.IList<string> ApiVersions { get { throw null; } }
        public string Capabilities { get { throw null; } }
        public string DefaultApiVersion { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Resources._Deployments.Models.ProviderExtendedLocation> LocationMappings { get { throw null; } }
        public System.Collections.Generic.IList<string> Locations { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> Properties { get { throw null; } }
        public string ResourceType { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Resources._Deployments.Models.ZoneMapping> ZoneMappings { get { throw null; } }
        protected virtual Azure.ResourceManager.Resources._Deployments.Models.ProviderResourceType JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Resources._Deployments.Models.ProviderResourceType PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Resources._Deployments.Models.ProviderResourceType System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources._Deployments.Models.ProviderResourceType>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources._Deployments.Models.ProviderResourceType>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources._Deployments.Models.ProviderResourceType System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources._Deployments.Models.ProviderResourceType>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources._Deployments.Models.ProviderResourceType>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources._Deployments.Models.ProviderResourceType>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public enum ProvisioningOperation
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
    public readonly partial struct ProvisioningState : System.IEquatable<Azure.ResourceManager.Resources._Deployments.Models.ProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.Resources._Deployments.Models.ProvisioningState Accepted { get { throw null; } }
        public static Azure.ResourceManager.Resources._Deployments.Models.ProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.Resources._Deployments.Models.ProvisioningState Created { get { throw null; } }
        public static Azure.ResourceManager.Resources._Deployments.Models.ProvisioningState Creating { get { throw null; } }
        public static Azure.ResourceManager.Resources._Deployments.Models.ProvisioningState Deleted { get { throw null; } }
        public static Azure.ResourceManager.Resources._Deployments.Models.ProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.Resources._Deployments.Models.ProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.Resources._Deployments.Models.ProvisioningState NotSpecified { get { throw null; } }
        public static Azure.ResourceManager.Resources._Deployments.Models.ProvisioningState Ready { get { throw null; } }
        public static Azure.ResourceManager.Resources._Deployments.Models.ProvisioningState Running { get { throw null; } }
        public static Azure.ResourceManager.Resources._Deployments.Models.ProvisioningState Succeeded { get { throw null; } }
        public static Azure.ResourceManager.Resources._Deployments.Models.ProvisioningState Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Resources._Deployments.Models.ProvisioningState other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Resources._Deployments.Models.ProvisioningState left, Azure.ResourceManager.Resources._Deployments.Models.ProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Resources._Deployments.Models.ProvisioningState (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Resources._Deployments.Models.ProvisioningState? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Resources._Deployments.Models.ProvisioningState left, Azure.ResourceManager.Resources._Deployments.Models.ProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ResourceReference : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources._Deployments.Models.ResourceReference>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources._Deployments.Models.ResourceReference>
    {
        internal ResourceReference() { }
        public string ApiVersion { get { throw null; } }
        public Azure.ResourceManager.Resources._Deployments.Models.ArmDeploymentExtensionDefinition Extension { get { throw null; } }
        public string Id { get { throw null; } }
        public System.BinaryData Identifiers { get { throw null; } }
        public string ResourceType { get { throw null; } }
        protected virtual Azure.ResourceManager.Resources._Deployments.Models.ResourceReference JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Resources._Deployments.Models.ResourceReference PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Resources._Deployments.Models.ResourceReference System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources._Deployments.Models.ResourceReference>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources._Deployments.Models.ResourceReference>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources._Deployments.Models.ResourceReference System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources._Deployments.Models.ResourceReference>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources._Deployments.Models.ResourceReference>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources._Deployments.Models.ResourceReference>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ScopedDeployment : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources._Deployments.Models.ScopedDeployment>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources._Deployments.Models.ScopedDeployment>
    {
        public ScopedDeployment(string location, Azure.ResourceManager.Resources._Deployments.Models.DeploymentProperties properties) { }
        public string Location { get { throw null; } }
        public Azure.ResourceManager.Resources._Deployments.Models.DeploymentProperties Properties { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        protected virtual Azure.ResourceManager.Resources._Deployments.Models.ScopedDeployment JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Resources._Deployments.Models.ScopedDeployment PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Resources._Deployments.Models.ScopedDeployment System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources._Deployments.Models.ScopedDeployment>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources._Deployments.Models.ScopedDeployment>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources._Deployments.Models.ScopedDeployment System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources._Deployments.Models.ScopedDeployment>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources._Deployments.Models.ScopedDeployment>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources._Deployments.Models.ScopedDeployment>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ScopedDeploymentWhatIf : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources._Deployments.Models.ScopedDeploymentWhatIf>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources._Deployments.Models.ScopedDeploymentWhatIf>
    {
        public ScopedDeploymentWhatIf(string location, Azure.ResourceManager.Resources._Deployments.Models.DeploymentWhatIfProperties properties) { }
        public string Location { get { throw null; } }
        public Azure.ResourceManager.Resources._Deployments.Models.DeploymentWhatIfProperties Properties { get { throw null; } }
        protected virtual Azure.ResourceManager.Resources._Deployments.Models.ScopedDeploymentWhatIf JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Resources._Deployments.Models.ScopedDeploymentWhatIf PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Resources._Deployments.Models.ScopedDeploymentWhatIf System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources._Deployments.Models.ScopedDeploymentWhatIf>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources._Deployments.Models.ScopedDeploymentWhatIf>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources._Deployments.Models.ScopedDeploymentWhatIf System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources._Deployments.Models.ScopedDeploymentWhatIf>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources._Deployments.Models.ScopedDeploymentWhatIf>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources._Deployments.Models.ScopedDeploymentWhatIf>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class StatusMessage : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources._Deployments.Models.StatusMessage>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources._Deployments.Models.StatusMessage>
    {
        internal StatusMessage() { }
        public Azure.ResourceManager.Resources._Deployments.Models.ErrorResponse Error { get { throw null; } }
        public string Status { get { throw null; } }
        protected virtual Azure.ResourceManager.Resources._Deployments.Models.StatusMessage JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Resources._Deployments.Models.StatusMessage PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Resources._Deployments.Models.StatusMessage System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources._Deployments.Models.StatusMessage>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources._Deployments.Models.StatusMessage>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources._Deployments.Models.StatusMessage System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources._Deployments.Models.StatusMessage>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources._Deployments.Models.StatusMessage>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources._Deployments.Models.StatusMessage>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class TargetResource : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources._Deployments.Models.TargetResource>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources._Deployments.Models.TargetResource>
    {
        internal TargetResource() { }
        public string ApiVersion { get { throw null; } }
        public Azure.ResourceManager.Resources._Deployments.Models.ArmDeploymentExtensionDefinition Extension { get { throw null; } }
        public string Id { get { throw null; } }
        public System.BinaryData Identifiers { get { throw null; } }
        public string ResourceName { get { throw null; } }
        public string ResourceType { get { throw null; } }
        public string SymbolicName { get { throw null; } }
        protected virtual Azure.ResourceManager.Resources._Deployments.Models.TargetResource JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Resources._Deployments.Models.TargetResource PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Resources._Deployments.Models.TargetResource System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources._Deployments.Models.TargetResource>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources._Deployments.Models.TargetResource>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources._Deployments.Models.TargetResource System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources._Deployments.Models.TargetResource>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources._Deployments.Models.TargetResource>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources._Deployments.Models.TargetResource>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class TemplateHashResult : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources._Deployments.Models.TemplateHashResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources._Deployments.Models.TemplateHashResult>
    {
        internal TemplateHashResult() { }
        public string MinifiedTemplate { get { throw null; } }
        public string TemplateHash { get { throw null; } }
        protected virtual Azure.ResourceManager.Resources._Deployments.Models.TemplateHashResult JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Resources._Deployments.Models.TemplateHashResult PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Resources._Deployments.Models.TemplateHashResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources._Deployments.Models.TemplateHashResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources._Deployments.Models.TemplateHashResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources._Deployments.Models.TemplateHashResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources._Deployments.Models.TemplateHashResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources._Deployments.Models.TemplateHashResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources._Deployments.Models.TemplateHashResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class TemplateLink : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources._Deployments.Models.TemplateLink>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources._Deployments.Models.TemplateLink>
    {
        public TemplateLink() { }
        public string ContentVersion { get { throw null; } set { } }
        public string Id { get { throw null; } set { } }
        public string QueryString { get { throw null; } set { } }
        public string RelativePath { get { throw null; } set { } }
        public string Uri { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Resources._Deployments.Models.TemplateLink JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Resources._Deployments.Models.TemplateLink PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Resources._Deployments.Models.TemplateLink System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources._Deployments.Models.TemplateLink>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources._Deployments.Models.TemplateLink>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources._Deployments.Models.TemplateLink System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources._Deployments.Models.TemplateLink>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources._Deployments.Models.TemplateLink>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources._Deployments.Models.TemplateLink>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ValidationLevel : System.IEquatable<Azure.ResourceManager.Resources._Deployments.Models.ValidationLevel>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ValidationLevel(string value) { throw null; }
        public static Azure.ResourceManager.Resources._Deployments.Models.ValidationLevel Provider { get { throw null; } }
        public static Azure.ResourceManager.Resources._Deployments.Models.ValidationLevel ProviderNoRbac { get { throw null; } }
        public static Azure.ResourceManager.Resources._Deployments.Models.ValidationLevel Template { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Resources._Deployments.Models.ValidationLevel other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Resources._Deployments.Models.ValidationLevel left, Azure.ResourceManager.Resources._Deployments.Models.ValidationLevel right) { throw null; }
        public static implicit operator Azure.ResourceManager.Resources._Deployments.Models.ValidationLevel (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Resources._Deployments.Models.ValidationLevel? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Resources._Deployments.Models.ValidationLevel left, Azure.ResourceManager.Resources._Deployments.Models.ValidationLevel right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class WhatIfChange : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources._Deployments.Models.WhatIfChange>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources._Deployments.Models.WhatIfChange>
    {
        internal WhatIfChange() { }
        public System.BinaryData After { get { throw null; } }
        public System.BinaryData Before { get { throw null; } }
        public Azure.ResourceManager.Resources._Deployments.Models.ChangeType ChangeType { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Resources._Deployments.Models.WhatIfPropertyChange> Delta { get { throw null; } }
        public string DeploymentId { get { throw null; } }
        public Azure.ResourceManager.Resources._Deployments.Models.ArmDeploymentExtensionDefinition Extension { get { throw null; } }
        public System.BinaryData Identifiers { get { throw null; } }
        public string ResourceId { get { throw null; } }
        public string SymbolicName { get { throw null; } }
        public string UnsupportedReason { get { throw null; } }
        protected virtual Azure.ResourceManager.Resources._Deployments.Models.WhatIfChange JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Resources._Deployments.Models.WhatIfChange PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Resources._Deployments.Models.WhatIfChange System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources._Deployments.Models.WhatIfChange>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources._Deployments.Models.WhatIfChange>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources._Deployments.Models.WhatIfChange System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources._Deployments.Models.WhatIfChange>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources._Deployments.Models.WhatIfChange>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources._Deployments.Models.WhatIfChange>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class WhatIfOperationResult : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources._Deployments.Models.WhatIfOperationResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources._Deployments.Models.WhatIfOperationResult>
    {
        internal WhatIfOperationResult() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.Resources._Deployments.Models.WhatIfChange> Changes { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Resources._Deployments.Models.DeploymentDiagnosticsDefinition> Diagnostics { get { throw null; } }
        public Azure.ResourceManager.Resources._Deployments.Models.ErrorResponse Error { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Resources._Deployments.Models.WhatIfChange> PotentialChanges { get { throw null; } }
        public string Status { get { throw null; } }
        protected virtual Azure.ResourceManager.Resources._Deployments.Models.WhatIfOperationResult JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Resources._Deployments.Models.WhatIfOperationResult PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Resources._Deployments.Models.WhatIfOperationResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources._Deployments.Models.WhatIfOperationResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources._Deployments.Models.WhatIfOperationResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources._Deployments.Models.WhatIfOperationResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources._Deployments.Models.WhatIfOperationResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources._Deployments.Models.WhatIfOperationResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources._Deployments.Models.WhatIfOperationResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class WhatIfPropertyChange : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources._Deployments.Models.WhatIfPropertyChange>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources._Deployments.Models.WhatIfPropertyChange>
    {
        internal WhatIfPropertyChange() { }
        public System.BinaryData After { get { throw null; } }
        public System.BinaryData Before { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Resources._Deployments.Models.WhatIfPropertyChange> Children { get { throw null; } }
        public string Path { get { throw null; } }
        public Azure.ResourceManager.Resources._Deployments.Models.PropertyChangeType PropertyChangeType { get { throw null; } }
        protected virtual Azure.ResourceManager.Resources._Deployments.Models.WhatIfPropertyChange JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Resources._Deployments.Models.WhatIfPropertyChange PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Resources._Deployments.Models.WhatIfPropertyChange System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources._Deployments.Models.WhatIfPropertyChange>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources._Deployments.Models.WhatIfPropertyChange>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources._Deployments.Models.WhatIfPropertyChange System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources._Deployments.Models.WhatIfPropertyChange>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources._Deployments.Models.WhatIfPropertyChange>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources._Deployments.Models.WhatIfPropertyChange>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public enum WhatIfResultFormat
    {
        ResourceIdOnly = 0,
        FullResourcePayloads = 1,
    }
    public partial class ZoneMapping : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources._Deployments.Models.ZoneMapping>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources._Deployments.Models.ZoneMapping>
    {
        internal ZoneMapping() { }
        public string Location { get { throw null; } }
        public System.Collections.Generic.IList<string> Zones { get { throw null; } }
        protected virtual Azure.ResourceManager.Resources._Deployments.Models.ZoneMapping JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Resources._Deployments.Models.ZoneMapping PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Resources._Deployments.Models.ZoneMapping System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources._Deployments.Models.ZoneMapping>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources._Deployments.Models.ZoneMapping>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources._Deployments.Models.ZoneMapping System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources._Deployments.Models.ZoneMapping>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources._Deployments.Models.ZoneMapping>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources._Deployments.Models.ZoneMapping>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
}
