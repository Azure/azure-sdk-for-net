namespace Azure.Management.Resources
{
    public partial class DeploymentOperations
    {
        protected DeploymentOperations() { }
        public virtual Azure.Response<Azure.Management.Resources.Models.DeploymentOperation> Get(string resourceGroupName, string deploymentName, string operationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Management.Resources.Models.DeploymentOperation>> GetAsync(string resourceGroupName, string deploymentName, string operationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.Management.Resources.Models.DeploymentOperation> List(string resourceGroupName, string deploymentName, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.Management.Resources.Models.DeploymentOperation> ListAsync(string resourceGroupName, string deploymentName, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DeploymentsCreateOrUpdateOperation : Azure.Operation<Azure.Management.Resources.Models.DeploymentExtended>
    {
        internal DeploymentsCreateOrUpdateOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.Management.Resources.Models.DeploymentExtended Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.Management.Resources.Models.DeploymentExtended>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.Management.Resources.Models.DeploymentExtended>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DeploymentsDeleteOperation : Azure.Operation<Azure.Response>
    {
        internal DeploymentsDeleteOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.Response Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.Response>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.Response>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DeploymentsOperations
    {
        protected DeploymentsOperations() { }
        public virtual Azure.Response<Azure.Management.Resources.Models.TemplateHashResult> CalculateTemplateHash(object template, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Management.Resources.Models.TemplateHashResult>> CalculateTemplateHashAsync(object template, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response Cancel(string resourceGroupName, string deploymentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> CancelAsync(string resourceGroupName, string deploymentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response CheckExistence(string resourceGroupName, string deploymentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> CheckExistenceAsync(string resourceGroupName, string deploymentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Management.Resources.Models.DeploymentExportResult> ExportTemplate(string resourceGroupName, string deploymentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Management.Resources.Models.DeploymentExportResult>> ExportTemplateAsync(string resourceGroupName, string deploymentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Management.Resources.Models.DeploymentExtended> Get(string resourceGroupName, string deploymentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Management.Resources.Models.DeploymentExtended>> GetAsync(string resourceGroupName, string deploymentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.Management.Resources.Models.DeploymentExtended> ListByResourceGroup(string resourceGroupName, string filter = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.Management.Resources.Models.DeploymentExtended> ListByResourceGroupAsync(string resourceGroupName, string filter = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Management.Resources.DeploymentsCreateOrUpdateOperation StartCreateOrUpdate(string resourceGroupName, string deploymentName, Azure.Management.Resources.Models.Deployment parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Management.Resources.DeploymentsCreateOrUpdateOperation> StartCreateOrUpdateAsync(string resourceGroupName, string deploymentName, Azure.Management.Resources.Models.Deployment parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Management.Resources.DeploymentsDeleteOperation StartDelete(string resourceGroupName, string deploymentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Management.Resources.DeploymentsDeleteOperation> StartDeleteAsync(string resourceGroupName, string deploymentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Management.Resources.Models.DeploymentValidateResult> Validate(string resourceGroupName, string deploymentName, Azure.Management.Resources.Models.Deployment parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Management.Resources.Models.DeploymentValidateResult>> ValidateAsync(string resourceGroupName, string deploymentName, Azure.Management.Resources.Models.Deployment parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ProvidersOperations
    {
        protected ProvidersOperations() { }
        public virtual Azure.Response<Azure.Management.Resources.Models.Provider> Get(string resourceProviderNamespace, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Management.Resources.Models.Provider>> GetAsync(string resourceProviderNamespace, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.Management.Resources.Models.Provider> List(int? top = default(int?), string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.Management.Resources.Models.Provider> ListAsync(int? top = default(int?), string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Management.Resources.Models.Provider> Register(string resourceProviderNamespace, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Management.Resources.Models.Provider>> RegisterAsync(string resourceProviderNamespace, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Management.Resources.Models.Provider> Unregister(string resourceProviderNamespace, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Management.Resources.Models.Provider>> UnregisterAsync(string resourceProviderNamespace, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ResourceGroupsDeleteOperation : Azure.Operation<Azure.Response>
    {
        internal ResourceGroupsDeleteOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.Response Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.Response>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.Response>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ResourceGroupsOperations
    {
        protected ResourceGroupsOperations() { }
        public virtual Azure.Response CheckExistence(string resourceGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> CheckExistenceAsync(string resourceGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Management.Resources.Models.ResourceGroup> CreateOrUpdate(string resourceGroupName, Azure.Management.Resources.Models.ResourceGroup parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Management.Resources.Models.ResourceGroup>> CreateOrUpdateAsync(string resourceGroupName, Azure.Management.Resources.Models.ResourceGroup parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Management.Resources.Models.ResourceGroupExportResult> ExportTemplate(string resourceGroupName, Azure.Management.Resources.Models.ExportTemplateRequest parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Management.Resources.Models.ResourceGroupExportResult>> ExportTemplateAsync(string resourceGroupName, Azure.Management.Resources.Models.ExportTemplateRequest parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Management.Resources.Models.ResourceGroup> Get(string resourceGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Management.Resources.Models.ResourceGroup>> GetAsync(string resourceGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.Management.Resources.Models.ResourceGroup> List(string filter = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.Management.Resources.Models.ResourceGroup> ListAsync(string filter = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Management.Resources.ResourceGroupsDeleteOperation StartDelete(string resourceGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Management.Resources.ResourceGroupsDeleteOperation> StartDeleteAsync(string resourceGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Management.Resources.Models.ResourceGroup> Update(string resourceGroupName, Azure.Management.Resources.Models.ResourceGroupPatchable parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Management.Resources.Models.ResourceGroup>> UpdateAsync(string resourceGroupName, Azure.Management.Resources.Models.ResourceGroupPatchable parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ResourcesCreateOrUpdateByIdOperation : Azure.Operation<Azure.Management.Resources.Models.GenericResource>
    {
        internal ResourcesCreateOrUpdateByIdOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.Management.Resources.Models.GenericResource Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.Management.Resources.Models.GenericResource>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.Management.Resources.Models.GenericResource>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ResourcesCreateOrUpdateOperation : Azure.Operation<Azure.Management.Resources.Models.GenericResource>
    {
        internal ResourcesCreateOrUpdateOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.Management.Resources.Models.GenericResource Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.Management.Resources.Models.GenericResource>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.Management.Resources.Models.GenericResource>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ResourcesDeleteByIdOperation : Azure.Operation<Azure.Response>
    {
        internal ResourcesDeleteByIdOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.Response Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.Response>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.Response>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ResourcesDeleteOperation : Azure.Operation<Azure.Response>
    {
        internal ResourcesDeleteOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.Response Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.Response>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.Response>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ResourcesManagementClient
    {
        protected ResourcesManagementClient() { }
        public ResourcesManagementClient(string subscriptionId, Azure.Core.TokenCredential tokenCredential, Azure.Management.Resources.ResourcesManagementClientOptions options = null) { }
        public ResourcesManagementClient(string subscriptionId, System.Uri endpoint, Azure.Core.TokenCredential tokenCredential, Azure.Management.Resources.ResourcesManagementClientOptions options = null) { }
        public virtual Azure.Management.Resources.DeploymentOperations Deployment { get { throw null; } }
        public virtual Azure.Management.Resources.DeploymentsOperations Deployments { get { throw null; } }
        public virtual Azure.Management.Resources.ProvidersOperations Providers { get { throw null; } }
        public virtual Azure.Management.Resources.ResourceGroupsOperations ResourceGroups { get { throw null; } }
        public virtual Azure.Management.Resources.ResourcesOperations Resources { get { throw null; } }
        public virtual Azure.Management.Resources.TagsOperations Tags { get { throw null; } }
    }
    public partial class ResourcesManagementClientOptions : Azure.Core.ClientOptions
    {
        public ResourcesManagementClientOptions() { }
    }
    public partial class ResourcesMoveResourcesOperation : Azure.Operation<Azure.Response>
    {
        internal ResourcesMoveResourcesOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.Response Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.Response>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.Response>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ResourcesOperations
    {
        protected ResourcesOperations() { }
        public virtual Azure.Response CheckExistence(string resourceGroupName, string resourceProviderNamespace, string parentResourcePath, string resourceType, string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> CheckExistenceAsync(string resourceGroupName, string resourceProviderNamespace, string parentResourcePath, string resourceType, string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response CheckExistenceById(string resourceId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> CheckExistenceByIdAsync(string resourceId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Management.Resources.Models.GenericResource> Get(string resourceGroupName, string resourceProviderNamespace, string parentResourcePath, string resourceType, string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Management.Resources.Models.GenericResource>> GetAsync(string resourceGroupName, string resourceProviderNamespace, string parentResourcePath, string resourceType, string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Management.Resources.Models.GenericResource> GetById(string resourceId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Management.Resources.Models.GenericResource>> GetByIdAsync(string resourceId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.Management.Resources.Models.GenericResourceExpanded> List(string filter = null, string expand = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.Management.Resources.Models.GenericResourceExpanded> ListAsync(string filter = null, string expand = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.Management.Resources.Models.GenericResourceExpanded> ListByResourceGroup(string resourceGroupName, string filter = null, string expand = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.Management.Resources.Models.GenericResourceExpanded> ListByResourceGroupAsync(string resourceGroupName, string filter = null, string expand = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Management.Resources.ResourcesCreateOrUpdateOperation StartCreateOrUpdate(string resourceGroupName, string resourceProviderNamespace, string parentResourcePath, string resourceType, string resourceName, Azure.Management.Resources.Models.GenericResource parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Management.Resources.ResourcesCreateOrUpdateOperation> StartCreateOrUpdateAsync(string resourceGroupName, string resourceProviderNamespace, string parentResourcePath, string resourceType, string resourceName, Azure.Management.Resources.Models.GenericResource parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Management.Resources.ResourcesCreateOrUpdateByIdOperation StartCreateOrUpdateById(string resourceId, Azure.Management.Resources.Models.GenericResource parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Management.Resources.ResourcesCreateOrUpdateByIdOperation> StartCreateOrUpdateByIdAsync(string resourceId, Azure.Management.Resources.Models.GenericResource parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Management.Resources.ResourcesDeleteOperation StartDelete(string resourceGroupName, string resourceProviderNamespace, string parentResourcePath, string resourceType, string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Management.Resources.ResourcesDeleteOperation> StartDeleteAsync(string resourceGroupName, string resourceProviderNamespace, string parentResourcePath, string resourceType, string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Management.Resources.ResourcesDeleteByIdOperation StartDeleteById(string resourceId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Management.Resources.ResourcesDeleteByIdOperation> StartDeleteByIdAsync(string resourceId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Management.Resources.ResourcesMoveResourcesOperation StartMoveResources(string sourceResourceGroupName, Azure.Management.Resources.Models.ResourcesMoveInfo parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Management.Resources.ResourcesMoveResourcesOperation> StartMoveResourcesAsync(string sourceResourceGroupName, Azure.Management.Resources.Models.ResourcesMoveInfo parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Management.Resources.ResourcesUpdateOperation StartUpdate(string resourceGroupName, string resourceProviderNamespace, string parentResourcePath, string resourceType, string resourceName, Azure.Management.Resources.Models.GenericResource parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Management.Resources.ResourcesUpdateOperation> StartUpdateAsync(string resourceGroupName, string resourceProviderNamespace, string parentResourcePath, string resourceType, string resourceName, Azure.Management.Resources.Models.GenericResource parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Management.Resources.ResourcesUpdateByIdOperation StartUpdateById(string resourceId, Azure.Management.Resources.Models.GenericResource parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Management.Resources.ResourcesUpdateByIdOperation> StartUpdateByIdAsync(string resourceId, Azure.Management.Resources.Models.GenericResource parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Management.Resources.ResourcesValidateMoveResourcesOperation StartValidateMoveResources(string sourceResourceGroupName, Azure.Management.Resources.Models.ResourcesMoveInfo parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Management.Resources.ResourcesValidateMoveResourcesOperation> StartValidateMoveResourcesAsync(string sourceResourceGroupName, Azure.Management.Resources.Models.ResourcesMoveInfo parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ResourcesUpdateByIdOperation : Azure.Operation<Azure.Management.Resources.Models.GenericResource>
    {
        internal ResourcesUpdateByIdOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.Management.Resources.Models.GenericResource Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.Management.Resources.Models.GenericResource>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.Management.Resources.Models.GenericResource>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ResourcesUpdateOperation : Azure.Operation<Azure.Management.Resources.Models.GenericResource>
    {
        internal ResourcesUpdateOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.Management.Resources.Models.GenericResource Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.Management.Resources.Models.GenericResource>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.Management.Resources.Models.GenericResource>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ResourcesValidateMoveResourcesOperation : Azure.Operation<Azure.Response>
    {
        internal ResourcesValidateMoveResourcesOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.Response Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.Response>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.Response>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class TagsOperations
    {
        protected TagsOperations() { }
        public virtual Azure.Response<Azure.Management.Resources.Models.TagDetails> CreateOrUpdate(string tagName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Management.Resources.Models.TagDetails>> CreateOrUpdateAsync(string tagName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Management.Resources.Models.TagValue> CreateOrUpdateValue(string tagName, string tagValue, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Management.Resources.Models.TagValue>> CreateOrUpdateValueAsync(string tagName, string tagValue, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response Delete(string tagName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteAsync(string tagName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response DeleteValue(string tagName, string tagValue, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteValueAsync(string tagName, string tagValue, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.Management.Resources.Models.TagDetails> List(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.Management.Resources.Models.TagDetails> ListAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.Management.Resources.Models
{
    public partial class AliasPathType
    {
        internal AliasPathType() { }
        public System.Collections.Generic.IReadOnlyList<string> ApiVersions { get { throw null; } }
        public string Path { get { throw null; } }
    }
    public partial class AliasType
    {
        internal AliasType() { }
        public string Name { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Management.Resources.Models.AliasPathType> Paths { get { throw null; } }
    }
    public partial class BasicDependency
    {
        internal BasicDependency() { }
        public string Id { get { throw null; } }
        public string ResourceName { get { throw null; } }
        public string ResourceType { get { throw null; } }
    }
    public partial class DebugSetting
    {
        public DebugSetting() { }
        public string DetailLevel { get { throw null; } set { } }
    }
    public partial class Dependency
    {
        internal Dependency() { }
        public System.Collections.Generic.IReadOnlyList<Azure.Management.Resources.Models.BasicDependency> DependsOn { get { throw null; } }
        public string Id { get { throw null; } }
        public string ResourceName { get { throw null; } }
        public string ResourceType { get { throw null; } }
    }
    public partial class Deployment
    {
        public Deployment(Azure.Management.Resources.Models.DeploymentProperties properties) { }
        public Azure.Management.Resources.Models.DeploymentProperties Properties { get { throw null; } }
    }
    public partial class DeploymentExportResult
    {
        internal DeploymentExportResult() { }
        public object Template { get { throw null; } }
    }
    public partial class DeploymentExtended
    {
        internal DeploymentExtended() { }
        public string Id { get { throw null; } }
        public string Name { get { throw null; } }
        public Azure.Management.Resources.Models.DeploymentPropertiesExtended Properties { get { throw null; } }
    }
    public partial class DeploymentListResult
    {
        internal DeploymentListResult() { }
        public string NextLink { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Management.Resources.Models.DeploymentExtended> Value { get { throw null; } }
    }
    public enum DeploymentMode
    {
        Incremental = 0,
        Complete = 1,
    }
    public partial class DeploymentOperation
    {
        internal DeploymentOperation() { }
        public string Id { get { throw null; } }
        public string OperationId { get { throw null; } }
        public Azure.Management.Resources.Models.DeploymentOperationProperties Properties { get { throw null; } }
    }
    public partial class DeploymentOperationProperties
    {
        internal DeploymentOperationProperties() { }
        public string ProvisioningState { get { throw null; } }
        public Azure.Management.Resources.Models.HttpMessage Request { get { throw null; } }
        public Azure.Management.Resources.Models.HttpMessage Response { get { throw null; } }
        public string ServiceRequestId { get { throw null; } }
        public string StatusCode { get { throw null; } }
        public object StatusMessage { get { throw null; } }
        public Azure.Management.Resources.Models.TargetResource TargetResource { get { throw null; } }
        public System.DateTimeOffset? Timestamp { get { throw null; } }
    }
    public partial class DeploymentOperationsListResult
    {
        internal DeploymentOperationsListResult() { }
        public string NextLink { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Management.Resources.Models.DeploymentOperation> Value { get { throw null; } }
    }
    public partial class DeploymentProperties
    {
        public DeploymentProperties(Azure.Management.Resources.Models.DeploymentMode mode) { }
        public Azure.Management.Resources.Models.DebugSetting DebugSetting { get { throw null; } set { } }
        public Azure.Management.Resources.Models.DeploymentMode Mode { get { throw null; } }
        public string Parameters { get { throw null; } set { } }
        public Azure.Management.Resources.Models.ParametersLink ParametersLink { get { throw null; } set { } }
        public string Template { get { throw null; } set { } }
        public Azure.Management.Resources.Models.TemplateLink TemplateLink { get { throw null; } set { } }
    }
    public partial class DeploymentPropertiesExtended
    {
        internal DeploymentPropertiesExtended() { }
        public string CorrelationId { get { throw null; } }
        public Azure.Management.Resources.Models.DebugSetting DebugSetting { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Management.Resources.Models.Dependency> Dependencies { get { throw null; } }
        public Azure.Management.Resources.Models.DeploymentMode? Mode { get { throw null; } }
        public object Outputs { get { throw null; } }
        public object Parameters { get { throw null; } }
        public Azure.Management.Resources.Models.ParametersLink ParametersLink { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Management.Resources.Models.Provider> Providers { get { throw null; } }
        public string ProvisioningState { get { throw null; } }
        public object Template { get { throw null; } }
        public Azure.Management.Resources.Models.TemplateLink TemplateLink { get { throw null; } }
        public System.DateTimeOffset? Timestamp { get { throw null; } }
    }
    public partial class DeploymentValidateResult
    {
        internal DeploymentValidateResult() { }
        public Azure.Management.Resources.Models.ResourceManagementErrorWithDetails Error { get { throw null; } }
        public Azure.Management.Resources.Models.DeploymentPropertiesExtended Properties { get { throw null; } }
    }
    public partial class ExportTemplateRequest
    {
        public ExportTemplateRequest() { }
        public string Options { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Resources { get { throw null; } set { } }
    }
    public partial class GenericResource : Azure.Management.Resources.Models.Resource
    {
        public GenericResource() { }
        public Azure.Management.Resources.Models.Identity Identity { get { throw null; } set { } }
        public string Kind { get { throw null; } set { } }
        public string ManagedBy { get { throw null; } set { } }
        public Azure.Management.Resources.Models.Plan Plan { get { throw null; } set { } }
        public object Properties { get { throw null; } set { } }
        public Azure.Management.Resources.Models.Sku Sku { get { throw null; } set { } }
    }
    public partial class GenericResourceExpanded : Azure.Management.Resources.Models.GenericResource
    {
        public GenericResourceExpanded() { }
        public System.DateTimeOffset? ChangedTime { get { throw null; } }
        public System.DateTimeOffset? CreatedTime { get { throw null; } }
        public string ProvisioningState { get { throw null; } }
    }
    public partial class HttpMessage
    {
        internal HttpMessage() { }
        public object Content { get { throw null; } }
    }
    public partial class Identity
    {
        public Identity() { }
        public string PrincipalId { get { throw null; } }
        public string TenantId { get { throw null; } }
        public string Type { get { throw null; } set { } }
    }
    public partial class ParametersLink
    {
        public ParametersLink(string uri) { }
        public string ContentVersion { get { throw null; } set { } }
        public string Uri { get { throw null; } set { } }
    }
    public partial class Plan
    {
        public Plan() { }
        public string Name { get { throw null; } set { } }
        public string Product { get { throw null; } set { } }
        public string PromotionCode { get { throw null; } set { } }
        public string Publisher { get { throw null; } set { } }
        public string Version { get { throw null; } set { } }
    }
    public partial class Provider
    {
        internal Provider() { }
        public string Id { get { throw null; } }
        public string Namespace { get { throw null; } }
        public string RegistrationState { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Management.Resources.Models.ProviderResourceType> ResourceTypes { get { throw null; } }
    }
    public partial class ProviderListResult
    {
        internal ProviderListResult() { }
        public string NextLink { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Management.Resources.Models.Provider> Value { get { throw null; } }
    }
    public partial class ProviderResourceType
    {
        internal ProviderResourceType() { }
        public System.Collections.Generic.IReadOnlyList<Azure.Management.Resources.Models.AliasType> Aliases { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> ApiVersions { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> Locations { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, string> Properties { get { throw null; } }
        public string ResourceType { get { throw null; } }
    }
    public partial class Resource
    {
        public Resource() { }
        public string Id { get { throw null; } }
        public string Location { get { throw null; } set { } }
        public string Name { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } set { } }
        public string Type { get { throw null; } }
    }
    public partial class ResourceGroup
    {
        public ResourceGroup(string location) { }
        public string Id { get { throw null; } }
        public string Location { get { throw null; } set { } }
        public string ManagedBy { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public Azure.Management.Resources.Models.ResourceGroupProperties Properties { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } set { } }
    }
    public partial class ResourceGroupExportResult
    {
        internal ResourceGroupExportResult() { }
        public Azure.Management.Resources.Models.ResourceManagementErrorWithDetails Error { get { throw null; } }
        public object Template { get { throw null; } }
    }
    public partial class ResourceGroupListResult
    {
        internal ResourceGroupListResult() { }
        public string NextLink { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Management.Resources.Models.ResourceGroup> Value { get { throw null; } }
    }
    public partial class ResourceGroupPatchable
    {
        public ResourceGroupPatchable() { }
        public string ManagedBy { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public Azure.Management.Resources.Models.ResourceGroupProperties Properties { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } set { } }
    }
    public partial class ResourceGroupProperties
    {
        public ResourceGroupProperties() { }
        public string ProvisioningState { get { throw null; } }
    }
    public partial class ResourceListResult
    {
        internal ResourceListResult() { }
        public string NextLink { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Management.Resources.Models.GenericResourceExpanded> Value { get { throw null; } }
    }
    public partial class ResourceManagementErrorWithDetails
    {
        internal ResourceManagementErrorWithDetails() { }
        public string Code { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Management.Resources.Models.ResourceManagementErrorWithDetails> Details { get { throw null; } }
        public string Message { get { throw null; } }
        public string Target { get { throw null; } }
    }
    public partial class ResourcesMoveInfo
    {
        public ResourcesMoveInfo() { }
        public System.Collections.Generic.IList<string> Resources { get { throw null; } set { } }
        public string TargetResourceGroup { get { throw null; } set { } }
    }
    public partial class Sku
    {
        public Sku() { }
        public int? Capacity { get { throw null; } set { } }
        public string Family { get { throw null; } set { } }
        public string Model { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public string Size { get { throw null; } set { } }
        public string Tier { get { throw null; } set { } }
    }
    public partial class TagCount
    {
        internal TagCount() { }
        public string Type { get { throw null; } }
        public int? Value { get { throw null; } }
    }
    public partial class TagDetails
    {
        internal TagDetails() { }
        public Azure.Management.Resources.Models.TagCount Count { get { throw null; } }
        public string Id { get { throw null; } }
        public string TagName { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Management.Resources.Models.TagValue> Values { get { throw null; } }
    }
    public partial class TagsListResult
    {
        internal TagsListResult() { }
        public string NextLink { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Management.Resources.Models.TagDetails> Value { get { throw null; } }
    }
    public partial class TagValue
    {
        internal TagValue() { }
        public Azure.Management.Resources.Models.TagCount Count { get { throw null; } }
        public string Id { get { throw null; } }
        public string TagValueValue { get { throw null; } }
    }
    public partial class TargetResource
    {
        internal TargetResource() { }
        public string Id { get { throw null; } }
        public string ResourceName { get { throw null; } }
        public string ResourceType { get { throw null; } }
    }
    public partial class TemplateHashResult
    {
        internal TemplateHashResult() { }
        public string MinifiedTemplate { get { throw null; } }
        public string TemplateHash { get { throw null; } }
    }
    public partial class TemplateLink
    {
        public TemplateLink(string uri) { }
        public string ContentVersion { get { throw null; } set { } }
        public string Uri { get { throw null; } set { } }
    }
}
