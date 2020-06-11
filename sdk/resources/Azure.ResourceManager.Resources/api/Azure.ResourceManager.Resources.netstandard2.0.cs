namespace Azure.ResourceManager.Resources
{
    public partial class ApplicationDefinitionsClient
    {
        protected ApplicationDefinitionsClient() { }
        public virtual Azure.Response<Azure.ResourceManager.Resources.Models.ApplicationDefinition> Get(string resourceGroupName, string applicationDefinitionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources.Models.ApplicationDefinition>> GetAsync(string resourceGroupName, string applicationDefinitionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Resources.Models.ApplicationDefinition> GetById(string applicationDefinitionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources.Models.ApplicationDefinition>> GetByIdAsync(string applicationDefinitionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Resources.Models.ApplicationDefinition> ListByResourceGroup(string resourceGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Resources.Models.ApplicationDefinition> ListByResourceGroupAsync(string resourceGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Resources.ApplicationDefinitionsCreateOrUpdateOperation StartCreateOrUpdate(string resourceGroupName, string applicationDefinitionName, Azure.ResourceManager.Resources.Models.ApplicationDefinition parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.Resources.ApplicationDefinitionsCreateOrUpdateOperation> StartCreateOrUpdateAsync(string resourceGroupName, string applicationDefinitionName, Azure.ResourceManager.Resources.Models.ApplicationDefinition parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Resources.ApplicationDefinitionsCreateOrUpdateByIdOperation StartCreateOrUpdateById(string applicationDefinitionId, Azure.ResourceManager.Resources.Models.ApplicationDefinition parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.Resources.ApplicationDefinitionsCreateOrUpdateByIdOperation> StartCreateOrUpdateByIdAsync(string applicationDefinitionId, Azure.ResourceManager.Resources.Models.ApplicationDefinition parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Resources.ApplicationDefinitionsDeleteOperation StartDelete(string resourceGroupName, string applicationDefinitionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.Resources.ApplicationDefinitionsDeleteOperation> StartDeleteAsync(string resourceGroupName, string applicationDefinitionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Resources.ApplicationDefinitionsDeleteByIdOperation StartDeleteById(string applicationDefinitionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.Resources.ApplicationDefinitionsDeleteByIdOperation> StartDeleteByIdAsync(string applicationDefinitionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ApplicationDefinitionsCreateOrUpdateByIdOperation : Azure.Operation<Azure.ResourceManager.Resources.Models.ApplicationDefinition>
    {
        internal ApplicationDefinitionsCreateOrUpdateByIdOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.Resources.Models.ApplicationDefinition Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.Resources.Models.ApplicationDefinition>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.Resources.Models.ApplicationDefinition>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ApplicationDefinitionsCreateOrUpdateOperation : Azure.Operation<Azure.ResourceManager.Resources.Models.ApplicationDefinition>
    {
        internal ApplicationDefinitionsCreateOrUpdateOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.Resources.Models.ApplicationDefinition Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.Resources.Models.ApplicationDefinition>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.Resources.Models.ApplicationDefinition>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ApplicationDefinitionsDeleteByIdOperation : Azure.Operation<Azure.Response>
    {
        internal ApplicationDefinitionsDeleteByIdOperation() { }
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
    public partial class ApplicationDefinitionsDeleteOperation : Azure.Operation<Azure.Response>
    {
        internal ApplicationDefinitionsDeleteOperation() { }
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
    public partial class ApplicationsClient
    {
        protected ApplicationsClient() { }
        public virtual Azure.Response<Azure.ResourceManager.Resources.Models.Application> Get(string resourceGroupName, string applicationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources.Models.Application>> GetAsync(string resourceGroupName, string applicationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Resources.Models.Application> GetById(string applicationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources.Models.Application>> GetByIdAsync(string applicationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Resources.Models.Application> ListByResourceGroup(string resourceGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Resources.Models.Application> ListByResourceGroupAsync(string resourceGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Resources.Models.Application> ListBySubscription(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Resources.Models.Application> ListBySubscriptionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Resources.ApplicationsCreateOrUpdateOperation StartCreateOrUpdate(string resourceGroupName, string applicationName, Azure.ResourceManager.Resources.Models.Application parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.Resources.ApplicationsCreateOrUpdateOperation> StartCreateOrUpdateAsync(string resourceGroupName, string applicationName, Azure.ResourceManager.Resources.Models.Application parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Resources.ApplicationsCreateOrUpdateByIdOperation StartCreateOrUpdateById(string applicationId, Azure.ResourceManager.Resources.Models.Application parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.Resources.ApplicationsCreateOrUpdateByIdOperation> StartCreateOrUpdateByIdAsync(string applicationId, Azure.ResourceManager.Resources.Models.Application parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Resources.ApplicationsDeleteOperation StartDelete(string resourceGroupName, string applicationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.Resources.ApplicationsDeleteOperation> StartDeleteAsync(string resourceGroupName, string applicationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Resources.ApplicationsDeleteByIdOperation StartDeleteById(string applicationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.Resources.ApplicationsDeleteByIdOperation> StartDeleteByIdAsync(string applicationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Resources.Models.Application> Update(string resourceGroupName, string applicationName, Azure.ResourceManager.Resources.Models.Application parameters = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources.Models.Application>> UpdateAsync(string resourceGroupName, string applicationName, Azure.ResourceManager.Resources.Models.Application parameters = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Resources.Models.Application> UpdateById(string applicationId, Azure.ResourceManager.Resources.Models.Application parameters = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources.Models.Application>> UpdateByIdAsync(string applicationId, Azure.ResourceManager.Resources.Models.Application parameters = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ApplicationsCreateOrUpdateByIdOperation : Azure.Operation<Azure.ResourceManager.Resources.Models.Application>
    {
        internal ApplicationsCreateOrUpdateByIdOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.Resources.Models.Application Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.Resources.Models.Application>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.Resources.Models.Application>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ApplicationsCreateOrUpdateOperation : Azure.Operation<Azure.ResourceManager.Resources.Models.Application>
    {
        internal ApplicationsCreateOrUpdateOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.Resources.Models.Application Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.Resources.Models.Application>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.Resources.Models.Application>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ApplicationsDeleteByIdOperation : Azure.Operation<Azure.Response>
    {
        internal ApplicationsDeleteByIdOperation() { }
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
    public partial class ApplicationsDeleteOperation : Azure.Operation<Azure.Response>
    {
        internal ApplicationsDeleteOperation() { }
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
    public partial class AuthorizationClient
    {
        protected AuthorizationClient() { }
        public virtual Azure.Pageable<Azure.ResourceManager.Resources.Models.OperationAutoGenerated2> List(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Resources.Models.OperationAutoGenerated2> ListAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DeploymentClient
    {
        protected DeploymentClient() { }
        public virtual Azure.Response<Azure.ResourceManager.Resources.Models.DeploymentOperation> Get(string resourceGroupName, string deploymentName, string operationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources.Models.DeploymentOperation>> GetAsync(string resourceGroupName, string deploymentName, string operationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Resources.Models.DeploymentOperation> GetAtManagementGroupScope(string groupId, string deploymentName, string operationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources.Models.DeploymentOperation>> GetAtManagementGroupScopeAsync(string groupId, string deploymentName, string operationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Resources.Models.DeploymentOperation> GetAtScope(string scope, string deploymentName, string operationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources.Models.DeploymentOperation>> GetAtScopeAsync(string scope, string deploymentName, string operationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Resources.Models.DeploymentOperation> GetAtSubscriptionScope(string deploymentName, string operationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources.Models.DeploymentOperation>> GetAtSubscriptionScopeAsync(string deploymentName, string operationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Resources.Models.DeploymentOperation> GetAtTenantScope(string deploymentName, string operationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources.Models.DeploymentOperation>> GetAtTenantScopeAsync(string deploymentName, string operationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Resources.Models.DeploymentOperation> List(string resourceGroupName, string deploymentName, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Resources.Models.DeploymentOperation> ListAsync(string resourceGroupName, string deploymentName, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Resources.Models.DeploymentOperation> ListAtManagementGroupScope(string groupId, string deploymentName, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Resources.Models.DeploymentOperation> ListAtManagementGroupScopeAsync(string groupId, string deploymentName, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Resources.Models.DeploymentOperation> ListAtScope(string scope, string deploymentName, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Resources.Models.DeploymentOperation> ListAtScopeAsync(string scope, string deploymentName, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Resources.Models.DeploymentOperation> ListAtSubscriptionScope(string deploymentName, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Resources.Models.DeploymentOperation> ListAtSubscriptionScopeAsync(string deploymentName, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Resources.Models.DeploymentOperation> ListAtTenantScope(string deploymentName, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Resources.Models.DeploymentOperation> ListAtTenantScopeAsync(string deploymentName, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DeploymentsClient
    {
        protected DeploymentsClient() { }
        public virtual Azure.Response<Azure.ResourceManager.Resources.Models.TemplateHashResult> CalculateTemplateHash(object template, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources.Models.TemplateHashResult>> CalculateTemplateHashAsync(object template, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response Cancel(string resourceGroupName, string deploymentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> CancelAsync(string resourceGroupName, string deploymentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response CancelAtManagementGroupScope(string groupId, string deploymentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> CancelAtManagementGroupScopeAsync(string groupId, string deploymentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response CancelAtScope(string scope, string deploymentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> CancelAtScopeAsync(string scope, string deploymentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response CancelAtSubscriptionScope(string deploymentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> CancelAtSubscriptionScopeAsync(string deploymentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response CancelAtTenantScope(string deploymentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> CancelAtTenantScopeAsync(string deploymentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response CheckExistence(string resourceGroupName, string deploymentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> CheckExistenceAsync(string resourceGroupName, string deploymentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response CheckExistenceAtManagementGroupScope(string groupId, string deploymentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> CheckExistenceAtManagementGroupScopeAsync(string groupId, string deploymentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response CheckExistenceAtScope(string scope, string deploymentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> CheckExistenceAtScopeAsync(string scope, string deploymentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response CheckExistenceAtSubscriptionScope(string deploymentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> CheckExistenceAtSubscriptionScopeAsync(string deploymentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response CheckExistenceAtTenantScope(string deploymentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> CheckExistenceAtTenantScopeAsync(string deploymentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Resources.Models.DeploymentExportResult> ExportTemplate(string resourceGroupName, string deploymentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources.Models.DeploymentExportResult>> ExportTemplateAsync(string resourceGroupName, string deploymentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Resources.Models.DeploymentExportResult> ExportTemplateAtManagementGroupScope(string groupId, string deploymentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources.Models.DeploymentExportResult>> ExportTemplateAtManagementGroupScopeAsync(string groupId, string deploymentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Resources.Models.DeploymentExportResult> ExportTemplateAtScope(string scope, string deploymentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources.Models.DeploymentExportResult>> ExportTemplateAtScopeAsync(string scope, string deploymentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Resources.Models.DeploymentExportResult> ExportTemplateAtSubscriptionScope(string deploymentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources.Models.DeploymentExportResult>> ExportTemplateAtSubscriptionScopeAsync(string deploymentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Resources.Models.DeploymentExportResult> ExportTemplateAtTenantScope(string deploymentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources.Models.DeploymentExportResult>> ExportTemplateAtTenantScopeAsync(string deploymentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Resources.Models.DeploymentExtended> Get(string resourceGroupName, string deploymentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources.Models.DeploymentExtended>> GetAsync(string resourceGroupName, string deploymentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Resources.Models.DeploymentExtended> GetAtManagementGroupScope(string groupId, string deploymentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources.Models.DeploymentExtended>> GetAtManagementGroupScopeAsync(string groupId, string deploymentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Resources.Models.DeploymentExtended> GetAtScope(string scope, string deploymentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources.Models.DeploymentExtended>> GetAtScopeAsync(string scope, string deploymentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Resources.Models.DeploymentExtended> GetAtSubscriptionScope(string deploymentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources.Models.DeploymentExtended>> GetAtSubscriptionScopeAsync(string deploymentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Resources.Models.DeploymentExtended> GetAtTenantScope(string deploymentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources.Models.DeploymentExtended>> GetAtTenantScopeAsync(string deploymentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Resources.Models.DeploymentExtended> ListAtManagementGroupScope(string groupId, string filter = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Resources.Models.DeploymentExtended> ListAtManagementGroupScopeAsync(string groupId, string filter = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Resources.Models.DeploymentExtended> ListAtScope(string scope, string filter = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Resources.Models.DeploymentExtended> ListAtScopeAsync(string scope, string filter = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Resources.Models.DeploymentExtended> ListAtSubscriptionScope(string filter = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Resources.Models.DeploymentExtended> ListAtSubscriptionScopeAsync(string filter = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Resources.Models.DeploymentExtended> ListAtTenantScope(string filter = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Resources.Models.DeploymentExtended> ListAtTenantScopeAsync(string filter = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Resources.Models.DeploymentExtended> ListByResourceGroup(string resourceGroupName, string filter = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Resources.Models.DeploymentExtended> ListByResourceGroupAsync(string resourceGroupName, string filter = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Resources.DeploymentsCreateOrUpdateOperation StartCreateOrUpdate(string resourceGroupName, string deploymentName, Azure.ResourceManager.Resources.Models.Deployment parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.Resources.DeploymentsCreateOrUpdateOperation> StartCreateOrUpdateAsync(string resourceGroupName, string deploymentName, Azure.ResourceManager.Resources.Models.Deployment parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Resources.DeploymentsCreateOrUpdateAtManagementGroupScopeOperation StartCreateOrUpdateAtManagementGroupScope(string groupId, string deploymentName, Azure.ResourceManager.Resources.Models.ScopedDeployment parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.Resources.DeploymentsCreateOrUpdateAtManagementGroupScopeOperation> StartCreateOrUpdateAtManagementGroupScopeAsync(string groupId, string deploymentName, Azure.ResourceManager.Resources.Models.ScopedDeployment parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Resources.DeploymentsCreateOrUpdateAtScopeOperation StartCreateOrUpdateAtScope(string scope, string deploymentName, Azure.ResourceManager.Resources.Models.Deployment parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.Resources.DeploymentsCreateOrUpdateAtScopeOperation> StartCreateOrUpdateAtScopeAsync(string scope, string deploymentName, Azure.ResourceManager.Resources.Models.Deployment parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Resources.DeploymentsCreateOrUpdateAtSubscriptionScopeOperation StartCreateOrUpdateAtSubscriptionScope(string deploymentName, Azure.ResourceManager.Resources.Models.Deployment parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.Resources.DeploymentsCreateOrUpdateAtSubscriptionScopeOperation> StartCreateOrUpdateAtSubscriptionScopeAsync(string deploymentName, Azure.ResourceManager.Resources.Models.Deployment parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Resources.DeploymentsCreateOrUpdateAtTenantScopeOperation StartCreateOrUpdateAtTenantScope(string deploymentName, Azure.ResourceManager.Resources.Models.ScopedDeployment parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.Resources.DeploymentsCreateOrUpdateAtTenantScopeOperation> StartCreateOrUpdateAtTenantScopeAsync(string deploymentName, Azure.ResourceManager.Resources.Models.ScopedDeployment parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Resources.DeploymentsDeleteOperation StartDelete(string resourceGroupName, string deploymentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.Resources.DeploymentsDeleteOperation> StartDeleteAsync(string resourceGroupName, string deploymentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Resources.DeploymentsDeleteAtManagementGroupScopeOperation StartDeleteAtManagementGroupScope(string groupId, string deploymentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.Resources.DeploymentsDeleteAtManagementGroupScopeOperation> StartDeleteAtManagementGroupScopeAsync(string groupId, string deploymentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Resources.DeploymentsDeleteAtScopeOperation StartDeleteAtScope(string scope, string deploymentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.Resources.DeploymentsDeleteAtScopeOperation> StartDeleteAtScopeAsync(string scope, string deploymentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Resources.DeploymentsDeleteAtSubscriptionScopeOperation StartDeleteAtSubscriptionScope(string deploymentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.Resources.DeploymentsDeleteAtSubscriptionScopeOperation> StartDeleteAtSubscriptionScopeAsync(string deploymentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Resources.DeploymentsDeleteAtTenantScopeOperation StartDeleteAtTenantScope(string deploymentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.Resources.DeploymentsDeleteAtTenantScopeOperation> StartDeleteAtTenantScopeAsync(string deploymentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Resources.DeploymentsValidateOperation StartValidate(string resourceGroupName, string deploymentName, Azure.ResourceManager.Resources.Models.Deployment parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.Resources.DeploymentsValidateOperation> StartValidateAsync(string resourceGroupName, string deploymentName, Azure.ResourceManager.Resources.Models.Deployment parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Resources.DeploymentsValidateAtManagementGroupScopeOperation StartValidateAtManagementGroupScope(string groupId, string deploymentName, Azure.ResourceManager.Resources.Models.ScopedDeployment parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.Resources.DeploymentsValidateAtManagementGroupScopeOperation> StartValidateAtManagementGroupScopeAsync(string groupId, string deploymentName, Azure.ResourceManager.Resources.Models.ScopedDeployment parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Resources.DeploymentsValidateAtScopeOperation StartValidateAtScope(string scope, string deploymentName, Azure.ResourceManager.Resources.Models.Deployment parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.Resources.DeploymentsValidateAtScopeOperation> StartValidateAtScopeAsync(string scope, string deploymentName, Azure.ResourceManager.Resources.Models.Deployment parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Resources.DeploymentsValidateAtSubscriptionScopeOperation StartValidateAtSubscriptionScope(string deploymentName, Azure.ResourceManager.Resources.Models.Deployment parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.Resources.DeploymentsValidateAtSubscriptionScopeOperation> StartValidateAtSubscriptionScopeAsync(string deploymentName, Azure.ResourceManager.Resources.Models.Deployment parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Resources.DeploymentsValidateAtTenantScopeOperation StartValidateAtTenantScope(string deploymentName, Azure.ResourceManager.Resources.Models.ScopedDeployment parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.Resources.DeploymentsValidateAtTenantScopeOperation> StartValidateAtTenantScopeAsync(string deploymentName, Azure.ResourceManager.Resources.Models.ScopedDeployment parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Resources.DeploymentsWhatIfOperation StartWhatIf(string resourceGroupName, string deploymentName, Azure.ResourceManager.Resources.Models.DeploymentWhatIf parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.Resources.DeploymentsWhatIfOperation> StartWhatIfAsync(string resourceGroupName, string deploymentName, Azure.ResourceManager.Resources.Models.DeploymentWhatIf parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Resources.DeploymentsWhatIfAtSubscriptionScopeOperation StartWhatIfAtSubscriptionScope(string deploymentName, Azure.ResourceManager.Resources.Models.DeploymentWhatIf parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.Resources.DeploymentsWhatIfAtSubscriptionScopeOperation> StartWhatIfAtSubscriptionScopeAsync(string deploymentName, Azure.ResourceManager.Resources.Models.DeploymentWhatIf parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DeploymentsCreateOrUpdateAtManagementGroupScopeOperation : Azure.Operation<Azure.ResourceManager.Resources.Models.DeploymentExtended>
    {
        internal DeploymentsCreateOrUpdateAtManagementGroupScopeOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.Resources.Models.DeploymentExtended Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.Resources.Models.DeploymentExtended>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.Resources.Models.DeploymentExtended>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DeploymentsCreateOrUpdateAtScopeOperation : Azure.Operation<Azure.ResourceManager.Resources.Models.DeploymentExtended>
    {
        internal DeploymentsCreateOrUpdateAtScopeOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.Resources.Models.DeploymentExtended Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.Resources.Models.DeploymentExtended>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.Resources.Models.DeploymentExtended>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DeploymentsCreateOrUpdateAtSubscriptionScopeOperation : Azure.Operation<Azure.ResourceManager.Resources.Models.DeploymentExtended>
    {
        internal DeploymentsCreateOrUpdateAtSubscriptionScopeOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.Resources.Models.DeploymentExtended Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.Resources.Models.DeploymentExtended>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.Resources.Models.DeploymentExtended>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DeploymentsCreateOrUpdateAtTenantScopeOperation : Azure.Operation<Azure.ResourceManager.Resources.Models.DeploymentExtended>
    {
        internal DeploymentsCreateOrUpdateAtTenantScopeOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.Resources.Models.DeploymentExtended Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.Resources.Models.DeploymentExtended>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.Resources.Models.DeploymentExtended>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DeploymentsCreateOrUpdateOperation : Azure.Operation<Azure.ResourceManager.Resources.Models.DeploymentExtended>
    {
        internal DeploymentsCreateOrUpdateOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.Resources.Models.DeploymentExtended Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.Resources.Models.DeploymentExtended>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.Resources.Models.DeploymentExtended>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DeploymentScriptsClient
    {
        protected DeploymentScriptsClient() { }
        public virtual Azure.Response Delete(string resourceGroupName, string scriptName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteAsync(string resourceGroupName, string scriptName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Resources.Models.DeploymentScript> Get(string resourceGroupName, string scriptName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources.Models.DeploymentScript>> GetAsync(string resourceGroupName, string scriptName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Resources.Models.ScriptLogsList> GetLogs(string resourceGroupName, string scriptName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources.Models.ScriptLogsList>> GetLogsAsync(string resourceGroupName, string scriptName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Resources.Models.ScriptLog> GetLogsDefault(string resourceGroupName, string scriptName, int? tail = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources.Models.ScriptLog>> GetLogsDefaultAsync(string resourceGroupName, string scriptName, int? tail = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Resources.Models.DeploymentScript> ListByResourceGroup(string resourceGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Resources.Models.DeploymentScript> ListByResourceGroupAsync(string resourceGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Resources.Models.DeploymentScript> ListBySubscription(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Resources.Models.DeploymentScript> ListBySubscriptionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Resources.DeploymentScriptsCreateOperation StartCreate(string resourceGroupName, string scriptName, Azure.ResourceManager.Resources.Models.DeploymentScript deploymentScript, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.Resources.DeploymentScriptsCreateOperation> StartCreateAsync(string resourceGroupName, string scriptName, Azure.ResourceManager.Resources.Models.DeploymentScript deploymentScript, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Resources.Models.DeploymentScript> Update(string resourceGroupName, string scriptName, Azure.ResourceManager.Resources.Models.DeploymentScriptUpdateParameter deploymentScript = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources.Models.DeploymentScript>> UpdateAsync(string resourceGroupName, string scriptName, Azure.ResourceManager.Resources.Models.DeploymentScriptUpdateParameter deploymentScript = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DeploymentScriptsCreateOperation : Azure.Operation<Azure.ResourceManager.Resources.Models.DeploymentScript>
    {
        internal DeploymentScriptsCreateOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.Resources.Models.DeploymentScript Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.Resources.Models.DeploymentScript>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.Resources.Models.DeploymentScript>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DeploymentsDeleteAtManagementGroupScopeOperation : Azure.Operation<Azure.Response>
    {
        internal DeploymentsDeleteAtManagementGroupScopeOperation() { }
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
    public partial class DeploymentsDeleteAtScopeOperation : Azure.Operation<Azure.Response>
    {
        internal DeploymentsDeleteAtScopeOperation() { }
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
    public partial class DeploymentsDeleteAtSubscriptionScopeOperation : Azure.Operation<Azure.Response>
    {
        internal DeploymentsDeleteAtSubscriptionScopeOperation() { }
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
    public partial class DeploymentsDeleteAtTenantScopeOperation : Azure.Operation<Azure.Response>
    {
        internal DeploymentsDeleteAtTenantScopeOperation() { }
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
    public partial class DeploymentsValidateAtManagementGroupScopeOperation : Azure.Operation<Azure.ResourceManager.Resources.Models.DeploymentValidateResult>
    {
        internal DeploymentsValidateAtManagementGroupScopeOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.Resources.Models.DeploymentValidateResult Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.Resources.Models.DeploymentValidateResult>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.Resources.Models.DeploymentValidateResult>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DeploymentsValidateAtScopeOperation : Azure.Operation<Azure.ResourceManager.Resources.Models.DeploymentValidateResult>
    {
        internal DeploymentsValidateAtScopeOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.Resources.Models.DeploymentValidateResult Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.Resources.Models.DeploymentValidateResult>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.Resources.Models.DeploymentValidateResult>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DeploymentsValidateAtSubscriptionScopeOperation : Azure.Operation<Azure.ResourceManager.Resources.Models.DeploymentValidateResult>
    {
        internal DeploymentsValidateAtSubscriptionScopeOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.Resources.Models.DeploymentValidateResult Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.Resources.Models.DeploymentValidateResult>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.Resources.Models.DeploymentValidateResult>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DeploymentsValidateAtTenantScopeOperation : Azure.Operation<Azure.ResourceManager.Resources.Models.DeploymentValidateResult>
    {
        internal DeploymentsValidateAtTenantScopeOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.Resources.Models.DeploymentValidateResult Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.Resources.Models.DeploymentValidateResult>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.Resources.Models.DeploymentValidateResult>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DeploymentsValidateOperation : Azure.Operation<Azure.ResourceManager.Resources.Models.DeploymentValidateResult>
    {
        internal DeploymentsValidateOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.Resources.Models.DeploymentValidateResult Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.Resources.Models.DeploymentValidateResult>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.Resources.Models.DeploymentValidateResult>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DeploymentsWhatIfAtSubscriptionScopeOperation : Azure.Operation<Azure.ResourceManager.Resources.Models.WhatIfOperationResult>
    {
        internal DeploymentsWhatIfAtSubscriptionScopeOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.Resources.Models.WhatIfOperationResult Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.Resources.Models.WhatIfOperationResult>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.Resources.Models.WhatIfOperationResult>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DeploymentsWhatIfOperation : Azure.Operation<Azure.ResourceManager.Resources.Models.WhatIfOperationResult>
    {
        internal DeploymentsWhatIfOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.Resources.Models.WhatIfOperationResult Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.Resources.Models.WhatIfOperationResult>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.Resources.Models.WhatIfOperationResult>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class FeaturesClient
    {
        protected FeaturesClient() { }
        public virtual Azure.Response<Azure.ResourceManager.Resources.Models.FeatureResult> Get(string resourceProviderNamespace, string featureName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources.Models.FeatureResult>> GetAsync(string resourceProviderNamespace, string featureName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Resources.Models.FeatureResult> List(string resourceProviderNamespace, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Resources.Models.FeatureResult> ListAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Resources.Models.FeatureResult> ListAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Resources.Models.FeatureResult> ListAsync(string resourceProviderNamespace, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Resources.Models.FeatureResult> Register(string resourceProviderNamespace, string featureName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources.Models.FeatureResult>> RegisterAsync(string resourceProviderNamespace, string featureName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Resources.Models.FeatureResult> Unregister(string resourceProviderNamespace, string featureName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources.Models.FeatureResult>> UnregisterAsync(string resourceProviderNamespace, string featureName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ManagementLocksClient
    {
        protected ManagementLocksClient() { }
        public virtual Azure.Response<Azure.ResourceManager.Resources.Models.ManagementLockObject> CreateOrUpdateAtResourceGroupLevel(string resourceGroupName, string lockName, Azure.ResourceManager.Resources.Models.ManagementLockObject parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources.Models.ManagementLockObject>> CreateOrUpdateAtResourceGroupLevelAsync(string resourceGroupName, string lockName, Azure.ResourceManager.Resources.Models.ManagementLockObject parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Resources.Models.ManagementLockObject> CreateOrUpdateAtResourceLevel(string resourceGroupName, string resourceProviderNamespace, string parentResourcePath, string resourceType, string resourceName, string lockName, Azure.ResourceManager.Resources.Models.ManagementLockObject parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources.Models.ManagementLockObject>> CreateOrUpdateAtResourceLevelAsync(string resourceGroupName, string resourceProviderNamespace, string parentResourcePath, string resourceType, string resourceName, string lockName, Azure.ResourceManager.Resources.Models.ManagementLockObject parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Resources.Models.ManagementLockObject> CreateOrUpdateAtSubscriptionLevel(string lockName, Azure.ResourceManager.Resources.Models.ManagementLockObject parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources.Models.ManagementLockObject>> CreateOrUpdateAtSubscriptionLevelAsync(string lockName, Azure.ResourceManager.Resources.Models.ManagementLockObject parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Resources.Models.ManagementLockObject> CreateOrUpdateByScope(string scope, string lockName, Azure.ResourceManager.Resources.Models.ManagementLockObject parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources.Models.ManagementLockObject>> CreateOrUpdateByScopeAsync(string scope, string lockName, Azure.ResourceManager.Resources.Models.ManagementLockObject parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response DeleteAtResourceGroupLevel(string resourceGroupName, string lockName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteAtResourceGroupLevelAsync(string resourceGroupName, string lockName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response DeleteAtResourceLevel(string resourceGroupName, string resourceProviderNamespace, string parentResourcePath, string resourceType, string resourceName, string lockName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteAtResourceLevelAsync(string resourceGroupName, string resourceProviderNamespace, string parentResourcePath, string resourceType, string resourceName, string lockName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response DeleteAtSubscriptionLevel(string lockName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteAtSubscriptionLevelAsync(string lockName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response DeleteByScope(string scope, string lockName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteByScopeAsync(string scope, string lockName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Resources.Models.ManagementLockObject> GetAtResourceGroupLevel(string resourceGroupName, string lockName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources.Models.ManagementLockObject>> GetAtResourceGroupLevelAsync(string resourceGroupName, string lockName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Resources.Models.ManagementLockObject> GetAtResourceLevel(string resourceGroupName, string resourceProviderNamespace, string parentResourcePath, string resourceType, string resourceName, string lockName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources.Models.ManagementLockObject>> GetAtResourceLevelAsync(string resourceGroupName, string resourceProviderNamespace, string parentResourcePath, string resourceType, string resourceName, string lockName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Resources.Models.ManagementLockObject> GetAtSubscriptionLevel(string lockName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources.Models.ManagementLockObject>> GetAtSubscriptionLevelAsync(string lockName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Resources.Models.ManagementLockObject> GetByScope(string scope, string lockName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources.Models.ManagementLockObject>> GetByScopeAsync(string scope, string lockName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Resources.Models.ManagementLockObject> ListAtResourceGroupLevel(string resourceGroupName, string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Resources.Models.ManagementLockObject> ListAtResourceGroupLevelAsync(string resourceGroupName, string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Resources.Models.ManagementLockObject> ListAtResourceLevel(string resourceGroupName, string resourceProviderNamespace, string parentResourcePath, string resourceType, string resourceName, string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Resources.Models.ManagementLockObject> ListAtResourceLevelAsync(string resourceGroupName, string resourceProviderNamespace, string parentResourcePath, string resourceType, string resourceName, string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Resources.Models.ManagementLockObject> ListAtSubscriptionLevel(string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Resources.Models.ManagementLockObject> ListAtSubscriptionLevelAsync(string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Resources.Models.ManagementLockObject> ListByScope(string scope, string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Resources.Models.ManagementLockObject> ListByScopeAsync(string scope, string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class OperationsClient
    {
        protected OperationsClient() { }
        public virtual Azure.Pageable<Azure.ResourceManager.Resources.Models.Operation> List(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Resources.Models.Operation> ListAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class PolicyAssignmentsClient
    {
        protected PolicyAssignmentsClient() { }
        public virtual Azure.Response<Azure.ResourceManager.Resources.Models.PolicyAssignment> Create(string scope, string policyAssignmentName, Azure.ResourceManager.Resources.Models.PolicyAssignment parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources.Models.PolicyAssignment>> CreateAsync(string scope, string policyAssignmentName, Azure.ResourceManager.Resources.Models.PolicyAssignment parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Resources.Models.PolicyAssignment> CreateById(string policyAssignmentId, Azure.ResourceManager.Resources.Models.PolicyAssignment parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources.Models.PolicyAssignment>> CreateByIdAsync(string policyAssignmentId, Azure.ResourceManager.Resources.Models.PolicyAssignment parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Resources.Models.PolicyAssignment> Delete(string scope, string policyAssignmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources.Models.PolicyAssignment>> DeleteAsync(string scope, string policyAssignmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Resources.Models.PolicyAssignment> DeleteById(string policyAssignmentId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources.Models.PolicyAssignment>> DeleteByIdAsync(string policyAssignmentId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Resources.Models.PolicyAssignment> Get(string scope, string policyAssignmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources.Models.PolicyAssignment>> GetAsync(string scope, string policyAssignmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Resources.Models.PolicyAssignment> GetById(string policyAssignmentId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources.Models.PolicyAssignment>> GetByIdAsync(string policyAssignmentId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Resources.Models.PolicyAssignment> List(string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Resources.Models.PolicyAssignment> ListAsync(string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Resources.Models.PolicyAssignment> ListForManagementGroup(string managementGroupId, string filter, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Resources.Models.PolicyAssignment> ListForManagementGroupAsync(string managementGroupId, string filter, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Resources.Models.PolicyAssignment> ListForResource(string resourceGroupName, string resourceProviderNamespace, string parentResourcePath, string resourceType, string resourceName, string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Resources.Models.PolicyAssignment> ListForResourceAsync(string resourceGroupName, string resourceProviderNamespace, string parentResourcePath, string resourceType, string resourceName, string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Resources.Models.PolicyAssignment> ListForResourceGroup(string resourceGroupName, string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Resources.Models.PolicyAssignment> ListForResourceGroupAsync(string resourceGroupName, string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class PolicyDefinitionsClient
    {
        protected PolicyDefinitionsClient() { }
        public virtual Azure.Response<Azure.ResourceManager.Resources.Models.PolicyDefinition> CreateOrUpdate(string policyDefinitionName, Azure.ResourceManager.Resources.Models.PolicyDefinition parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources.Models.PolicyDefinition>> CreateOrUpdateAsync(string policyDefinitionName, Azure.ResourceManager.Resources.Models.PolicyDefinition parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Resources.Models.PolicyDefinition> CreateOrUpdateAtManagementGroup(string policyDefinitionName, string managementGroupId, Azure.ResourceManager.Resources.Models.PolicyDefinition parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources.Models.PolicyDefinition>> CreateOrUpdateAtManagementGroupAsync(string policyDefinitionName, string managementGroupId, Azure.ResourceManager.Resources.Models.PolicyDefinition parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response Delete(string policyDefinitionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteAsync(string policyDefinitionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response DeleteAtManagementGroup(string policyDefinitionName, string managementGroupId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteAtManagementGroupAsync(string policyDefinitionName, string managementGroupId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Resources.Models.PolicyDefinition> Get(string policyDefinitionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources.Models.PolicyDefinition>> GetAsync(string policyDefinitionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Resources.Models.PolicyDefinition> GetAtManagementGroup(string policyDefinitionName, string managementGroupId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources.Models.PolicyDefinition>> GetAtManagementGroupAsync(string policyDefinitionName, string managementGroupId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Resources.Models.PolicyDefinition> GetBuiltIn(string policyDefinitionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources.Models.PolicyDefinition>> GetBuiltInAsync(string policyDefinitionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Resources.Models.PolicyDefinition> List(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Resources.Models.PolicyDefinition> ListAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Resources.Models.PolicyDefinition> ListBuiltIn(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Resources.Models.PolicyDefinition> ListBuiltInAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Resources.Models.PolicyDefinition> ListByManagementGroup(string managementGroupId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Resources.Models.PolicyDefinition> ListByManagementGroupAsync(string managementGroupId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class PolicySetDefinitionsClient
    {
        protected PolicySetDefinitionsClient() { }
        public virtual Azure.Response<Azure.ResourceManager.Resources.Models.PolicySetDefinition> CreateOrUpdate(string policySetDefinitionName, Azure.ResourceManager.Resources.Models.PolicySetDefinition parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources.Models.PolicySetDefinition>> CreateOrUpdateAsync(string policySetDefinitionName, Azure.ResourceManager.Resources.Models.PolicySetDefinition parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Resources.Models.PolicySetDefinition> CreateOrUpdateAtManagementGroup(string policySetDefinitionName, string managementGroupId, Azure.ResourceManager.Resources.Models.PolicySetDefinition parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources.Models.PolicySetDefinition>> CreateOrUpdateAtManagementGroupAsync(string policySetDefinitionName, string managementGroupId, Azure.ResourceManager.Resources.Models.PolicySetDefinition parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response Delete(string policySetDefinitionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteAsync(string policySetDefinitionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response DeleteAtManagementGroup(string policySetDefinitionName, string managementGroupId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteAtManagementGroupAsync(string policySetDefinitionName, string managementGroupId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Resources.Models.PolicySetDefinition> Get(string policySetDefinitionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources.Models.PolicySetDefinition>> GetAsync(string policySetDefinitionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Resources.Models.PolicySetDefinition> GetAtManagementGroup(string policySetDefinitionName, string managementGroupId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources.Models.PolicySetDefinition>> GetAtManagementGroupAsync(string policySetDefinitionName, string managementGroupId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Resources.Models.PolicySetDefinition> GetBuiltIn(string policySetDefinitionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources.Models.PolicySetDefinition>> GetBuiltInAsync(string policySetDefinitionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Resources.Models.PolicySetDefinition> List(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Resources.Models.PolicySetDefinition> ListAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Resources.Models.PolicySetDefinition> ListBuiltIn(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Resources.Models.PolicySetDefinition> ListBuiltInAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Resources.Models.PolicySetDefinition> ListByManagementGroup(string managementGroupId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Resources.Models.PolicySetDefinition> ListByManagementGroupAsync(string managementGroupId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ProvidersClient
    {
        protected ProvidersClient() { }
        public virtual Azure.Response<Azure.ResourceManager.Resources.Models.Provider> Get(string resourceProviderNamespace, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources.Models.Provider>> GetAsync(string resourceProviderNamespace, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Resources.Models.Provider> GetAtTenantScope(string resourceProviderNamespace, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources.Models.Provider>> GetAtTenantScopeAsync(string resourceProviderNamespace, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Resources.Models.Provider> List(int? top = default(int?), string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Resources.Models.Provider> ListAsync(int? top = default(int?), string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Resources.Models.Provider> ListAtTenantScope(int? top = default(int?), string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Resources.Models.Provider> ListAtTenantScopeAsync(int? top = default(int?), string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Resources.Models.Provider> Register(string resourceProviderNamespace, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources.Models.Provider>> RegisterAsync(string resourceProviderNamespace, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Resources.Models.Provider> Unregister(string resourceProviderNamespace, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources.Models.Provider>> UnregisterAsync(string resourceProviderNamespace, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ResourceGroupsClient
    {
        protected ResourceGroupsClient() { }
        public virtual Azure.Response CheckExistence(string resourceGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> CheckExistenceAsync(string resourceGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Resources.Models.ResourceGroup> CreateOrUpdate(string resourceGroupName, Azure.ResourceManager.Resources.Models.ResourceGroup parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources.Models.ResourceGroup>> CreateOrUpdateAsync(string resourceGroupName, Azure.ResourceManager.Resources.Models.ResourceGroup parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Resources.Models.ResourceGroup> Get(string resourceGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources.Models.ResourceGroup>> GetAsync(string resourceGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Resources.Models.ResourceGroup> List(string filter = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Resources.Models.ResourceGroup> ListAsync(string filter = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Resources.ResourceGroupsDeleteOperation StartDelete(string resourceGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.Resources.ResourceGroupsDeleteOperation> StartDeleteAsync(string resourceGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Resources.ResourceGroupsExportTemplateOperation StartExportTemplate(string resourceGroupName, Azure.ResourceManager.Resources.Models.ExportTemplateRequest parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.Resources.ResourceGroupsExportTemplateOperation> StartExportTemplateAsync(string resourceGroupName, Azure.ResourceManager.Resources.Models.ExportTemplateRequest parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Resources.Models.ResourceGroup> Update(string resourceGroupName, Azure.ResourceManager.Resources.Models.ResourceGroupPatchable parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources.Models.ResourceGroup>> UpdateAsync(string resourceGroupName, Azure.ResourceManager.Resources.Models.ResourceGroupPatchable parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
    public partial class ResourceGroupsExportTemplateOperation : Azure.Operation<Azure.ResourceManager.Resources.Models.ResourceGroupExportResult>
    {
        internal ResourceGroupsExportTemplateOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.Resources.Models.ResourceGroupExportResult Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.Resources.Models.ResourceGroupExportResult>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.Resources.Models.ResourceGroupExportResult>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ResourceLinksClient
    {
        protected ResourceLinksClient() { }
        public virtual Azure.Response<Azure.ResourceManager.Resources.Models.ResourceLink> CreateOrUpdate(string linkId, Azure.ResourceManager.Resources.Models.ResourceLink parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources.Models.ResourceLink>> CreateOrUpdateAsync(string linkId, Azure.ResourceManager.Resources.Models.ResourceLink parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response Delete(string linkId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteAsync(string linkId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Resources.Models.ResourceLink> Get(string linkId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources.Models.ResourceLink>> GetAsync(string linkId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Resources.Models.ResourceLink> ListAtSourceScope(string scope, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Resources.Models.ResourceLink> ListAtSourceScopeAsync(string scope, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Resources.Models.ResourceLink> ListAtSubscription(string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Resources.Models.ResourceLink> ListAtSubscriptionAsync(string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ResourcesClient
    {
        protected ResourcesClient() { }
        public virtual Azure.Response CheckExistence(string resourceGroupName, string resourceProviderNamespace, string parentResourcePath, string resourceType, string resourceName, string apiVersion, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> CheckExistenceAsync(string resourceGroupName, string resourceProviderNamespace, string parentResourcePath, string resourceType, string resourceName, string apiVersion, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response CheckExistenceById(string resourceId, string apiVersion, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> CheckExistenceByIdAsync(string resourceId, string apiVersion, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Resources.Models.GenericResource> Get(string resourceGroupName, string resourceProviderNamespace, string parentResourcePath, string resourceType, string resourceName, string apiVersion, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources.Models.GenericResource>> GetAsync(string resourceGroupName, string resourceProviderNamespace, string parentResourcePath, string resourceType, string resourceName, string apiVersion, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Resources.Models.GenericResource> GetById(string resourceId, string apiVersion, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources.Models.GenericResource>> GetByIdAsync(string resourceId, string apiVersion, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Resources.Models.GenericResourceExpanded> List(string filter = null, string expand = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Resources.Models.GenericResourceExpanded> ListAsync(string filter = null, string expand = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Resources.Models.GenericResourceExpanded> ListByResourceGroup(string resourceGroupName, string filter = null, string expand = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Resources.Models.GenericResourceExpanded> ListByResourceGroupAsync(string resourceGroupName, string filter = null, string expand = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Resources.ResourcesCreateOrUpdateOperation StartCreateOrUpdate(string resourceGroupName, string resourceProviderNamespace, string parentResourcePath, string resourceType, string resourceName, string apiVersion, Azure.ResourceManager.Resources.Models.GenericResource parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.Resources.ResourcesCreateOrUpdateOperation> StartCreateOrUpdateAsync(string resourceGroupName, string resourceProviderNamespace, string parentResourcePath, string resourceType, string resourceName, string apiVersion, Azure.ResourceManager.Resources.Models.GenericResource parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Resources.ResourcesCreateOrUpdateByIdOperation StartCreateOrUpdateById(string resourceId, string apiVersion, Azure.ResourceManager.Resources.Models.GenericResource parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.Resources.ResourcesCreateOrUpdateByIdOperation> StartCreateOrUpdateByIdAsync(string resourceId, string apiVersion, Azure.ResourceManager.Resources.Models.GenericResource parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Resources.ResourcesDeleteOperation StartDelete(string resourceGroupName, string resourceProviderNamespace, string parentResourcePath, string resourceType, string resourceName, string apiVersion, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.Resources.ResourcesDeleteOperation> StartDeleteAsync(string resourceGroupName, string resourceProviderNamespace, string parentResourcePath, string resourceType, string resourceName, string apiVersion, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Resources.ResourcesDeleteByIdOperation StartDeleteById(string resourceId, string apiVersion, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.Resources.ResourcesDeleteByIdOperation> StartDeleteByIdAsync(string resourceId, string apiVersion, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Resources.ResourcesMoveResourcesOperation StartMoveResources(string sourceResourceGroupName, Azure.ResourceManager.Resources.Models.ResourcesMoveInfo parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.Resources.ResourcesMoveResourcesOperation> StartMoveResourcesAsync(string sourceResourceGroupName, Azure.ResourceManager.Resources.Models.ResourcesMoveInfo parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Resources.ResourcesUpdateOperation StartUpdate(string resourceGroupName, string resourceProviderNamespace, string parentResourcePath, string resourceType, string resourceName, string apiVersion, Azure.ResourceManager.Resources.Models.GenericResource parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.Resources.ResourcesUpdateOperation> StartUpdateAsync(string resourceGroupName, string resourceProviderNamespace, string parentResourcePath, string resourceType, string resourceName, string apiVersion, Azure.ResourceManager.Resources.Models.GenericResource parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Resources.ResourcesUpdateByIdOperation StartUpdateById(string resourceId, string apiVersion, Azure.ResourceManager.Resources.Models.GenericResource parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.Resources.ResourcesUpdateByIdOperation> StartUpdateByIdAsync(string resourceId, string apiVersion, Azure.ResourceManager.Resources.Models.GenericResource parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Resources.ResourcesValidateMoveResourcesOperation StartValidateMoveResources(string sourceResourceGroupName, Azure.ResourceManager.Resources.Models.ResourcesMoveInfo parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.Resources.ResourcesValidateMoveResourcesOperation> StartValidateMoveResourcesAsync(string sourceResourceGroupName, Azure.ResourceManager.Resources.Models.ResourcesMoveInfo parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ResourcesCreateOrUpdateByIdOperation : Azure.Operation<Azure.ResourceManager.Resources.Models.GenericResource>
    {
        internal ResourcesCreateOrUpdateByIdOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.Resources.Models.GenericResource Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.Resources.Models.GenericResource>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.Resources.Models.GenericResource>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ResourcesCreateOrUpdateOperation : Azure.Operation<Azure.ResourceManager.Resources.Models.GenericResource>
    {
        internal ResourcesCreateOrUpdateOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.Resources.Models.GenericResource Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.Resources.Models.GenericResource>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.Resources.Models.GenericResource>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
        public ResourcesManagementClient(string subscriptionId, Azure.Core.TokenCredential tokenCredential, Azure.ResourceManager.Resources.ResourcesManagementClientOptions options = null) { }
        public ResourcesManagementClient(System.Uri endpoint, string subscriptionId, Azure.Core.TokenCredential tokenCredential, Azure.ResourceManager.Resources.ResourcesManagementClientOptions options = null) { }
        public virtual Azure.ResourceManager.Resources.ApplicationDefinitionsClient GetApplicationDefinitionsClient() { throw null; }
        public virtual Azure.ResourceManager.Resources.ApplicationsClient GetApplicationsClient() { throw null; }
        public virtual Azure.ResourceManager.Resources.AuthorizationClient GetAuthorizationClient() { throw null; }
        public virtual Azure.ResourceManager.Resources.DeploymentClient GetDeploymentClient() { throw null; }
        public virtual Azure.ResourceManager.Resources.DeploymentsClient GetDeploymentsClient() { throw null; }
        public virtual Azure.ResourceManager.Resources.DeploymentScriptsClient GetDeploymentScriptsClient() { throw null; }
        public virtual Azure.ResourceManager.Resources.FeaturesClient GetFeaturesClient() { throw null; }
        public virtual Azure.ResourceManager.Resources.ManagementLocksClient GetManagementLocksClient() { throw null; }
        public virtual Azure.ResourceManager.Resources.OperationsClient GetOperationsClient() { throw null; }
        public virtual Azure.ResourceManager.Resources.PolicyAssignmentsClient GetPolicyAssignmentsClient() { throw null; }
        public virtual Azure.ResourceManager.Resources.PolicyDefinitionsClient GetPolicyDefinitionsClient() { throw null; }
        public virtual Azure.ResourceManager.Resources.PolicySetDefinitionsClient GetPolicySetDefinitionsClient() { throw null; }
        public virtual Azure.ResourceManager.Resources.ProvidersClient GetProvidersClient() { throw null; }
        public virtual Azure.ResourceManager.Resources.ResourceGroupsClient GetResourceGroupsClient() { throw null; }
        public virtual Azure.ResourceManager.Resources.ResourceLinksClient GetResourceLinksClient() { throw null; }
        public virtual Azure.ResourceManager.Resources.ResourcesClient GetResourcesClient() { throw null; }
        public virtual Azure.ResourceManager.Resources.ServiceClient GetServiceClient() { throw null; }
        public virtual Azure.ResourceManager.Resources.SubscriptionsClient GetSubscriptionsClient() { throw null; }
        public virtual Azure.ResourceManager.Resources.TagsClient GetTagsClient() { throw null; }
        public virtual Azure.ResourceManager.Resources.TenantsClient GetTenantsClient() { throw null; }
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
    public partial class ResourcesUpdateByIdOperation : Azure.Operation<Azure.ResourceManager.Resources.Models.GenericResource>
    {
        internal ResourcesUpdateByIdOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.Resources.Models.GenericResource Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.Resources.Models.GenericResource>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.Resources.Models.GenericResource>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ResourcesUpdateOperation : Azure.Operation<Azure.ResourceManager.Resources.Models.GenericResource>
    {
        internal ResourcesUpdateOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.Resources.Models.GenericResource Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.Resources.Models.GenericResource>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.Resources.Models.GenericResource>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
    public partial class ServiceClient
    {
        protected ServiceClient() { }
        public virtual Azure.Pageable<Azure.ResourceManager.Resources.Models.OperationAutoGenerated> ListOperations(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Resources.Models.OperationAutoGenerated> ListOperationsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SubscriptionsClient
    {
        protected SubscriptionsClient() { }
        public virtual Azure.Response<Azure.ResourceManager.Resources.Models.Subscription> Get(string subscriptionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources.Models.Subscription>> GetAsync(string subscriptionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Resources.Models.Subscription> List(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Resources.Models.Subscription> ListAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Resources.Models.Location> ListLocations(string subscriptionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Resources.Models.Location> ListLocationsAsync(string subscriptionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class TagsClient
    {
        protected TagsClient() { }
        public virtual Azure.Response<Azure.ResourceManager.Resources.Models.TagDetails> CreateOrUpdate(string tagName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources.Models.TagDetails>> CreateOrUpdateAsync(string tagName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Resources.Models.TagsResource> CreateOrUpdateAtScope(string scope, Azure.ResourceManager.Resources.Models.TagsResource parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources.Models.TagsResource>> CreateOrUpdateAtScopeAsync(string scope, Azure.ResourceManager.Resources.Models.TagsResource parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Resources.Models.TagValue> CreateOrUpdateValue(string tagName, string tagValue, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources.Models.TagValue>> CreateOrUpdateValueAsync(string tagName, string tagValue, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response Delete(string tagName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteAsync(string tagName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response DeleteAtScope(string scope, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteAtScopeAsync(string scope, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response DeleteValue(string tagName, string tagValue, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteValueAsync(string tagName, string tagValue, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Resources.Models.TagsResource> GetAtScope(string scope, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources.Models.TagsResource>> GetAtScopeAsync(string scope, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Resources.Models.TagDetails> List(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Resources.Models.TagDetails> ListAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Resources.Models.TagsResource> UpdateAtScope(string scope, Azure.ResourceManager.Resources.Models.TagsPatchResource parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources.Models.TagsResource>> UpdateAtScopeAsync(string scope, Azure.ResourceManager.Resources.Models.TagsPatchResource parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class TenantsClient
    {
        protected TenantsClient() { }
        public virtual Azure.Pageable<Azure.ResourceManager.Resources.Models.TenantIdDescription> List(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Resources.Models.TenantIdDescription> ListAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.Resources.Models
{
    public partial class Alias
    {
        internal Alias() { }
        public string DefaultPath { get { throw null; } }
        public Azure.ResourceManager.Resources.Models.AliasPattern DefaultPattern { get { throw null; } }
        public string Name { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Resources.Models.AliasPath> Paths { get { throw null; } }
        public Azure.ResourceManager.Resources.Models.AliasType? Type { get { throw null; } }
    }
    public partial class AliasPath
    {
        internal AliasPath() { }
        public System.Collections.Generic.IReadOnlyList<string> ApiVersions { get { throw null; } }
        public string Path { get { throw null; } }
        public Azure.ResourceManager.Resources.Models.AliasPattern Pattern { get { throw null; } }
    }
    public partial class AliasPattern
    {
        internal AliasPattern() { }
        public string Phrase { get { throw null; } }
        public Azure.ResourceManager.Resources.Models.AliasPatternType? Type { get { throw null; } }
        public string Variable { get { throw null; } }
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
    public partial class Application : Azure.ResourceManager.Resources.Models.GenericResourceAutoGenerated
    {
        public Application(string kind, string managedResourceGroupId) { }
        public string ApplicationDefinitionId { get { throw null; } set { } }
        public string Kind { get { throw null; } set { } }
        public string ManagedResourceGroupId { get { throw null; } set { } }
        public object Outputs { get { throw null; } }
        public object Parameters { get { throw null; } set { } }
        public Azure.ResourceManager.Resources.Models.PlanAutoGenerated Plan { get { throw null; } set { } }
        public Azure.ResourceManager.Resources.Models.ProvisioningState? ProvisioningState { get { throw null; } }
    }
    public partial class ApplicationArtifact
    {
        public ApplicationArtifact() { }
        public string Name { get { throw null; } set { } }
        public Azure.ResourceManager.Resources.Models.ApplicationArtifactType? Type { get { throw null; } set { } }
        public string Uri { get { throw null; } set { } }
    }
    public enum ApplicationArtifactType
    {
        Template = 0,
        Custom = 1,
    }
    public partial class ApplicationDefinition : Azure.ResourceManager.Resources.Models.GenericResourceAutoGenerated
    {
        public ApplicationDefinition(Azure.ResourceManager.Resources.Models.ApplicationLockLevel lockLevel, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Models.ApplicationProviderAuthorization> authorizations) { }
        public System.Collections.Generic.IList<Azure.ResourceManager.Resources.Models.ApplicationArtifact> Artifacts { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Resources.Models.ApplicationProviderAuthorization> Authorizations { get { throw null; } }
        public object CreateUiDefinition { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public string DisplayName { get { throw null; } set { } }
        public string IsEnabled { get { throw null; } set { } }
        public Azure.ResourceManager.Resources.Models.ApplicationLockLevel LockLevel { get { throw null; } set { } }
        public object MainTemplate { get { throw null; } set { } }
        public string PackageFileUri { get { throw null; } set { } }
    }
    public partial class ApplicationDefinitionListResult
    {
        internal ApplicationDefinitionListResult() { }
        public string NextLink { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Resources.Models.ApplicationDefinition> Value { get { throw null; } }
    }
    public partial class ApplicationListResult
    {
        internal ApplicationListResult() { }
        public string NextLink { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Resources.Models.Application> Value { get { throw null; } }
    }
    public enum ApplicationLockLevel
    {
        CanNotDelete = 0,
        ReadOnly = 1,
        None = 2,
    }
    public partial class ApplicationPatchable : Azure.ResourceManager.Resources.Models.GenericResourceAutoGenerated
    {
        public ApplicationPatchable() { }
        public string ApplicationDefinitionId { get { throw null; } set { } }
        public string Kind { get { throw null; } set { } }
        public string ManagedResourceGroupId { get { throw null; } set { } }
        public object Outputs { get { throw null; } }
        public object Parameters { get { throw null; } set { } }
        public Azure.ResourceManager.Resources.Models.PlanPatchable Plan { get { throw null; } set { } }
        public Azure.ResourceManager.Resources.Models.ProvisioningState? ProvisioningState { get { throw null; } }
    }
    public partial class ApplicationProviderAuthorization
    {
        public ApplicationProviderAuthorization(string principalId, string roleDefinitionId) { }
        public string PrincipalId { get { throw null; } set { } }
        public string RoleDefinitionId { get { throw null; } set { } }
    }
    public partial class AzureCliScript : Azure.ResourceManager.Resources.Models.DeploymentScript
    {
        public AzureCliScript(Azure.ResourceManager.Resources.Models.ManagedServiceIdentity identity, string location, System.TimeSpan retentionInterval, string azCliVersion) : base (default(Azure.ResourceManager.Resources.Models.ManagedServiceIdentity), default(string)) { }
        public string Arguments { get { throw null; } set { } }
        public string AzCliVersion { get { throw null; } set { } }
        public Azure.ResourceManager.Resources.Models.CleanupOptions? CleanupPreference { get { throw null; } set { } }
        public Azure.ResourceManager.Resources.Models.ContainerConfiguration ContainerSettings { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Resources.Models.EnvironmentVariable> EnvironmentVariables { get { throw null; } set { } }
        public string ForceUpdateTag { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, object> Outputs { get { throw null; } }
        public string PrimaryScriptUri { get { throw null; } set { } }
        public Azure.ResourceManager.Resources.Models.ScriptProvisioningState? ProvisioningState { get { throw null; } }
        public System.TimeSpan RetentionInterval { get { throw null; } set { } }
        public string ScriptContent { get { throw null; } set { } }
        public Azure.ResourceManager.Resources.Models.ScriptStatus Status { get { throw null; } }
        public Azure.ResourceManager.Resources.Models.StorageAccountConfiguration StorageAccountSettings { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> SupportingScriptUris { get { throw null; } set { } }
        public System.TimeSpan? Timeout { get { throw null; } set { } }
    }
    public partial class AzureCliScriptProperties : Azure.ResourceManager.Resources.Models.DeploymentScriptPropertiesBase
    {
        public AzureCliScriptProperties(string azCliVersion, System.TimeSpan retentionInterval) { }
        public string Arguments { get { throw null; } set { } }
        public string AzCliVersion { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Resources.Models.EnvironmentVariable> EnvironmentVariables { get { throw null; } set { } }
        public string ForceUpdateTag { get { throw null; } set { } }
        public string PrimaryScriptUri { get { throw null; } set { } }
        public System.TimeSpan RetentionInterval { get { throw null; } set { } }
        public string ScriptContent { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> SupportingScriptUris { get { throw null; } set { } }
        public System.TimeSpan? Timeout { get { throw null; } set { } }
    }
    public partial class AzurePowerShellScript : Azure.ResourceManager.Resources.Models.DeploymentScript
    {
        public AzurePowerShellScript(Azure.ResourceManager.Resources.Models.ManagedServiceIdentity identity, string location, System.TimeSpan retentionInterval, string azPowerShellVersion) : base (default(Azure.ResourceManager.Resources.Models.ManagedServiceIdentity), default(string)) { }
        public string Arguments { get { throw null; } set { } }
        public string AzPowerShellVersion { get { throw null; } set { } }
        public Azure.ResourceManager.Resources.Models.CleanupOptions? CleanupPreference { get { throw null; } set { } }
        public Azure.ResourceManager.Resources.Models.ContainerConfiguration ContainerSettings { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Resources.Models.EnvironmentVariable> EnvironmentVariables { get { throw null; } set { } }
        public string ForceUpdateTag { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, object> Outputs { get { throw null; } }
        public string PrimaryScriptUri { get { throw null; } set { } }
        public Azure.ResourceManager.Resources.Models.ScriptProvisioningState? ProvisioningState { get { throw null; } }
        public System.TimeSpan RetentionInterval { get { throw null; } set { } }
        public string ScriptContent { get { throw null; } set { } }
        public Azure.ResourceManager.Resources.Models.ScriptStatus Status { get { throw null; } }
        public Azure.ResourceManager.Resources.Models.StorageAccountConfiguration StorageAccountSettings { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> SupportingScriptUris { get { throw null; } set { } }
        public System.TimeSpan? Timeout { get { throw null; } set { } }
    }
    public partial class AzurePowerShellScriptProperties : Azure.ResourceManager.Resources.Models.DeploymentScriptPropertiesBase
    {
        public AzurePowerShellScriptProperties(string azPowerShellVersion, System.TimeSpan retentionInterval) { }
        public string Arguments { get { throw null; } set { } }
        public string AzPowerShellVersion { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Resources.Models.EnvironmentVariable> EnvironmentVariables { get { throw null; } set { } }
        public string ForceUpdateTag { get { throw null; } set { } }
        public string PrimaryScriptUri { get { throw null; } set { } }
        public System.TimeSpan RetentionInterval { get { throw null; } set { } }
        public string ScriptContent { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> SupportingScriptUris { get { throw null; } set { } }
        public System.TimeSpan? Timeout { get { throw null; } set { } }
    }
    public partial class AzureResourceBase
    {
        public AzureResourceBase() { }
        public string Id { get { throw null; } }
        public string Name { get { throw null; } }
        public string Type { get { throw null; } }
    }
    public partial class BasicDependency
    {
        internal BasicDependency() { }
        public string Id { get { throw null; } }
        public string ResourceName { get { throw null; } }
        public string ResourceType { get { throw null; } }
    }
    public enum ChangeType
    {
        Create = 0,
        Delete = 1,
        Ignore = 2,
        Deploy = 3,
        NoChange = 4,
        Modify = 5,
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct CleanupOptions : System.IEquatable<Azure.ResourceManager.Resources.Models.CleanupOptions>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public CleanupOptions(string value) { throw null; }
        public static Azure.ResourceManager.Resources.Models.CleanupOptions Always { get { throw null; } }
        public static Azure.ResourceManager.Resources.Models.CleanupOptions OnExpiration { get { throw null; } }
        public static Azure.ResourceManager.Resources.Models.CleanupOptions OnSuccess { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Resources.Models.CleanupOptions other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Resources.Models.CleanupOptions left, Azure.ResourceManager.Resources.Models.CleanupOptions right) { throw null; }
        public static implicit operator Azure.ResourceManager.Resources.Models.CleanupOptions (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Resources.Models.CleanupOptions left, Azure.ResourceManager.Resources.Models.CleanupOptions right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ContainerConfiguration
    {
        public ContainerConfiguration() { }
        public string ContainerGroupName { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct CreatedByType : System.IEquatable<Azure.ResourceManager.Resources.Models.CreatedByType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public CreatedByType(string value) { throw null; }
        public static Azure.ResourceManager.Resources.Models.CreatedByType Application { get { throw null; } }
        public static Azure.ResourceManager.Resources.Models.CreatedByType Key { get { throw null; } }
        public static Azure.ResourceManager.Resources.Models.CreatedByType ManagedIdentity { get { throw null; } }
        public static Azure.ResourceManager.Resources.Models.CreatedByType User { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Resources.Models.CreatedByType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Resources.Models.CreatedByType left, Azure.ResourceManager.Resources.Models.CreatedByType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Resources.Models.CreatedByType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Resources.Models.CreatedByType left, Azure.ResourceManager.Resources.Models.CreatedByType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DebugSetting
    {
        public DebugSetting() { }
        public string DetailLevel { get { throw null; } set { } }
    }
    public partial class Dependency
    {
        internal Dependency() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Resources.Models.BasicDependency> DependsOn { get { throw null; } }
        public string Id { get { throw null; } }
        public string ResourceName { get { throw null; } }
        public string ResourceType { get { throw null; } }
    }
    public partial class Deployment
    {
        public Deployment(Azure.ResourceManager.Resources.Models.DeploymentProperties properties) { }
        public string Location { get { throw null; } set { } }
        public Azure.ResourceManager.Resources.Models.DeploymentProperties Properties { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } set { } }
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
        public string Location { get { throw null; } }
        public string Name { get { throw null; } }
        public Azure.ResourceManager.Resources.Models.DeploymentPropertiesExtended Properties { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, string> Tags { get { throw null; } }
        public string Type { get { throw null; } }
    }
    public partial class DeploymentListResult
    {
        internal DeploymentListResult() { }
        public string NextLink { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Resources.Models.DeploymentExtended> Value { get { throw null; } }
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
        public Azure.ResourceManager.Resources.Models.DeploymentOperationProperties Properties { get { throw null; } }
    }
    public partial class DeploymentOperationProperties
    {
        internal DeploymentOperationProperties() { }
        public string Duration { get { throw null; } }
        public Azure.ResourceManager.Resources.Models.ProvisioningOperation? ProvisioningOperation { get { throw null; } }
        public string ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.Resources.Models.HttpMessage Request { get { throw null; } }
        public Azure.ResourceManager.Resources.Models.HttpMessage Response { get { throw null; } }
        public string ServiceRequestId { get { throw null; } }
        public string StatusCode { get { throw null; } }
        public object StatusMessage { get { throw null; } }
        public Azure.ResourceManager.Resources.Models.TargetResource TargetResource { get { throw null; } }
        public System.DateTimeOffset? Timestamp { get { throw null; } }
    }
    public partial class DeploymentOperationsListResult
    {
        internal DeploymentOperationsListResult() { }
        public string NextLink { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Resources.Models.DeploymentOperation> Value { get { throw null; } }
    }
    public partial class DeploymentProperties
    {
        public DeploymentProperties(Azure.ResourceManager.Resources.Models.DeploymentMode mode) { }
        public Azure.ResourceManager.Resources.Models.DebugSetting DebugSetting { get { throw null; } set { } }
        public Azure.ResourceManager.Resources.Models.DeploymentMode Mode { get { throw null; } }
        public Azure.ResourceManager.Resources.Models.OnErrorDeployment OnErrorDeployment { get { throw null; } set { } }
        public string Parameters { get { throw null; } set { } }
        public Azure.ResourceManager.Resources.Models.ParametersLink ParametersLink { get { throw null; } set { } }
        public string Template { get { throw null; } set { } }
        public Azure.ResourceManager.Resources.Models.TemplateLink TemplateLink { get { throw null; } set { } }
    }
    public partial class DeploymentPropertiesExtended
    {
        internal DeploymentPropertiesExtended() { }
        public string CorrelationId { get { throw null; } }
        public Azure.ResourceManager.Resources.Models.DebugSetting DebugSetting { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Resources.Models.Dependency> Dependencies { get { throw null; } }
        public string Duration { get { throw null; } }
        public Azure.ResourceManager.Resources.Models.ErrorResponse Error { get { throw null; } }
        public Azure.ResourceManager.Resources.Models.DeploymentMode? Mode { get { throw null; } }
        public Azure.ResourceManager.Resources.Models.OnErrorDeploymentExtended OnErrorDeployment { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Resources.Models.ResourceReference> OutputResources { get { throw null; } }
        public object Outputs { get { throw null; } }
        public object Parameters { get { throw null; } }
        public Azure.ResourceManager.Resources.Models.ParametersLink ParametersLink { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Resources.Models.Provider> Providers { get { throw null; } }
        public string ProvisioningState { get { throw null; } }
        public string TemplateHash { get { throw null; } }
        public Azure.ResourceManager.Resources.Models.TemplateLink TemplateLink { get { throw null; } }
        public System.DateTimeOffset? Timestamp { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Resources.Models.ResourceReference> ValidatedResources { get { throw null; } }
    }
    public partial class DeploymentScript : Azure.ResourceManager.Resources.Models.AzureResourceBase
    {
        public DeploymentScript(Azure.ResourceManager.Resources.Models.ManagedServiceIdentity identity, string location) { }
        public Azure.ResourceManager.Resources.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public string Location { get { throw null; } set { } }
        public Azure.ResourceManager.Resources.Models.SystemData SystemData { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } set { } }
    }
    public partial class DeploymentScriptListResult
    {
        internal DeploymentScriptListResult() { }
        public string NextLink { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Resources.Models.DeploymentScript> Value { get { throw null; } }
    }
    public partial class DeploymentScriptPropertiesBase
    {
        public DeploymentScriptPropertiesBase() { }
        public Azure.ResourceManager.Resources.Models.CleanupOptions? CleanupPreference { get { throw null; } set { } }
        public Azure.ResourceManager.Resources.Models.ContainerConfiguration ContainerSettings { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, object> Outputs { get { throw null; } }
        public Azure.ResourceManager.Resources.Models.ScriptProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.Resources.Models.ScriptStatus Status { get { throw null; } }
        public Azure.ResourceManager.Resources.Models.StorageAccountConfiguration StorageAccountSettings { get { throw null; } set { } }
    }
    public partial class DeploymentScriptUpdateParameter : Azure.ResourceManager.Resources.Models.AzureResourceBase
    {
        public DeploymentScriptUpdateParameter() { }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } set { } }
    }
    public partial class DeploymentValidateResult
    {
        internal DeploymentValidateResult() { }
        public Azure.ResourceManager.Resources.Models.ErrorResponse Error { get { throw null; } }
        public Azure.ResourceManager.Resources.Models.DeploymentPropertiesExtended Properties { get { throw null; } }
    }
    public partial class DeploymentWhatIf
    {
        public DeploymentWhatIf(Azure.ResourceManager.Resources.Models.DeploymentWhatIfProperties properties) { }
        public string Location { get { throw null; } set { } }
        public Azure.ResourceManager.Resources.Models.DeploymentWhatIfProperties Properties { get { throw null; } }
    }
    public partial class DeploymentWhatIfProperties : Azure.ResourceManager.Resources.Models.DeploymentProperties
    {
        public DeploymentWhatIfProperties(Azure.ResourceManager.Resources.Models.DeploymentMode mode) : base (default(Azure.ResourceManager.Resources.Models.DeploymentMode)) { }
        public Azure.ResourceManager.Resources.Models.DeploymentWhatIfSettings WhatIfSettings { get { throw null; } set { } }
    }
    public partial class DeploymentWhatIfSettings
    {
        public DeploymentWhatIfSettings() { }
        public Azure.ResourceManager.Resources.Models.WhatIfResultFormat? ResultFormat { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct EnforcementMode : System.IEquatable<Azure.ResourceManager.Resources.Models.EnforcementMode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public EnforcementMode(string value) { throw null; }
        public static Azure.ResourceManager.Resources.Models.EnforcementMode Default { get { throw null; } }
        public static Azure.ResourceManager.Resources.Models.EnforcementMode DoNotEnforce { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Resources.Models.EnforcementMode other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Resources.Models.EnforcementMode left, Azure.ResourceManager.Resources.Models.EnforcementMode right) { throw null; }
        public static implicit operator Azure.ResourceManager.Resources.Models.EnforcementMode (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Resources.Models.EnforcementMode left, Azure.ResourceManager.Resources.Models.EnforcementMode right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class EnvironmentVariable
    {
        public EnvironmentVariable(string name) { }
        public string Name { get { throw null; } set { } }
        public string SecureValue { get { throw null; } set { } }
        public string Value { get { throw null; } set { } }
    }
    public partial class ErrorAdditionalInfo
    {
        public ErrorAdditionalInfo() { }
        public object Info { get { throw null; } }
        public string Type { get { throw null; } }
    }
    public partial class ErrorResponse
    {
        public ErrorResponse() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.Resources.Models.ErrorAdditionalInfo> AdditionalInfo { get { throw null; } }
        public string Code { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Resources.Models.ErrorResponse> Details { get { throw null; } }
        public string Message { get { throw null; } }
        public string Target { get { throw null; } }
    }
    public partial class ExportTemplateRequest
    {
        public ExportTemplateRequest() { }
        public string Options { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Resources { get { throw null; } set { } }
    }
    public partial class FeatureOperationsListResult
    {
        internal FeatureOperationsListResult() { }
        public string NextLink { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Resources.Models.FeatureResult> Value { get { throw null; } }
    }
    public partial class FeatureProperties
    {
        internal FeatureProperties() { }
        public string State { get { throw null; } }
    }
    public partial class FeatureResult
    {
        internal FeatureResult() { }
        public string Id { get { throw null; } }
        public string Name { get { throw null; } }
        public Azure.ResourceManager.Resources.Models.FeatureProperties Properties { get { throw null; } }
        public string Type { get { throw null; } }
    }
    public partial class GenericResource : Azure.ResourceManager.Resources.Models.Resource
    {
        public GenericResource() { }
        public Azure.ResourceManager.Resources.Models.Identity Identity { get { throw null; } set { } }
        public string Kind { get { throw null; } set { } }
        public string ManagedBy { get { throw null; } set { } }
        public Azure.ResourceManager.Resources.Models.Plan Plan { get { throw null; } set { } }
        public object Properties { get { throw null; } set { } }
        public Azure.ResourceManager.Resources.Models.Sku Sku { get { throw null; } set { } }
    }
    public partial class GenericResourceAutoGenerated : Azure.ResourceManager.Resources.Models.Resource
    {
        public GenericResourceAutoGenerated() { }
        public Azure.ResourceManager.Resources.Models.IdentityAutoGenerated2 Identity { get { throw null; } set { } }
        public string ManagedBy { get { throw null; } set { } }
        public Azure.ResourceManager.Resources.Models.SkuAutoGenerated Sku { get { throw null; } set { } }
    }
    public partial class GenericResourceExpanded : Azure.ResourceManager.Resources.Models.GenericResource
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
        public Azure.ResourceManager.Resources.Models.ResourceIdentityType? Type { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, Azure.ResourceManager.Resources.Models.IdentityUserAssignedIdentitiesValue> UserAssignedIdentities { get { throw null; } set { } }
    }
    public partial class IdentityAutoGenerated
    {
        public IdentityAutoGenerated() { }
        public string PrincipalId { get { throw null; } }
        public string TenantId { get { throw null; } }
        public Azure.ResourceManager.Resources.Models.ResourceIdentityType? Type { get { throw null; } set { } }
    }
    public partial class IdentityAutoGenerated2
    {
        public IdentityAutoGenerated2() { }
        public string PrincipalId { get { throw null; } }
        public string TenantId { get { throw null; } }
        public Azure.ResourceManager.Resources.Models.ResourceIdentityType? Type { get { throw null; } set { } }
    }
    public partial class IdentityUserAssignedIdentitiesValue
    {
        public IdentityUserAssignedIdentitiesValue() { }
        public string ClientId { get { throw null; } }
        public string PrincipalId { get { throw null; } }
    }
    public partial class Location
    {
        internal Location() { }
        public string DisplayName { get { throw null; } }
        public string Id { get { throw null; } }
        public Azure.ResourceManager.Resources.Models.LocationMetadata Metadata { get { throw null; } }
        public string Name { get { throw null; } }
        public string RegionalDisplayName { get { throw null; } }
        public string SubscriptionId { get { throw null; } }
    }
    public partial class LocationListResult
    {
        internal LocationListResult() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Resources.Models.Location> Value { get { throw null; } }
    }
    public partial class LocationMetadata
    {
        internal LocationMetadata() { }
        public string GeographyGroup { get { throw null; } }
        public string Latitude { get { throw null; } }
        public string Longitude { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Resources.Models.PairedRegion> PairedRegion { get { throw null; } }
        public string PhysicalLocation { get { throw null; } }
        public Azure.ResourceManager.Resources.Models.RegionCategory? RegionCategory { get { throw null; } }
        public Azure.ResourceManager.Resources.Models.RegionType? RegionType { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct LockLevel : System.IEquatable<Azure.ResourceManager.Resources.Models.LockLevel>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public LockLevel(string value) { throw null; }
        public static Azure.ResourceManager.Resources.Models.LockLevel CanNotDelete { get { throw null; } }
        public static Azure.ResourceManager.Resources.Models.LockLevel NotSpecified { get { throw null; } }
        public static Azure.ResourceManager.Resources.Models.LockLevel ReadOnly { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Resources.Models.LockLevel other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Resources.Models.LockLevel left, Azure.ResourceManager.Resources.Models.LockLevel right) { throw null; }
        public static implicit operator Azure.ResourceManager.Resources.Models.LockLevel (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Resources.Models.LockLevel left, Azure.ResourceManager.Resources.Models.LockLevel right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ManagedByTenant
    {
        internal ManagedByTenant() { }
        public string TenantId { get { throw null; } }
    }
    public partial class ManagedServiceIdentity
    {
        public ManagedServiceIdentity() { }
        public string Type { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, Azure.ResourceManager.Resources.Models.UserAssignedIdentity> UserAssignedIdentities { get { throw null; } set { } }
    }
    public partial class ManagementLockListResult
    {
        internal ManagementLockListResult() { }
        public string NextLink { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Resources.Models.ManagementLockObject> Value { get { throw null; } }
    }
    public partial class ManagementLockObject
    {
        public ManagementLockObject(Azure.ResourceManager.Resources.Models.LockLevel level) { }
        public string Id { get { throw null; } }
        public Azure.ResourceManager.Resources.Models.LockLevel Level { get { throw null; } set { } }
        public string Name { get { throw null; } }
        public string Notes { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Resources.Models.ManagementLockOwner> Owners { get { throw null; } set { } }
        public string Type { get { throw null; } }
    }
    public partial class ManagementLockOwner
    {
        public ManagementLockOwner() { }
        public string ApplicationId { get { throw null; } set { } }
    }
    public partial class OnErrorDeployment
    {
        public OnErrorDeployment() { }
        public string DeploymentName { get { throw null; } set { } }
        public Azure.ResourceManager.Resources.Models.OnErrorDeploymentType? Type { get { throw null; } set { } }
    }
    public partial class OnErrorDeploymentExtended
    {
        internal OnErrorDeploymentExtended() { }
        public string DeploymentName { get { throw null; } }
        public string ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.Resources.Models.OnErrorDeploymentType? Type { get { throw null; } }
    }
    public enum OnErrorDeploymentType
    {
        LastSuccessful = 0,
        SpecificDeployment = 1,
    }
    public partial class Operation
    {
        internal Operation() { }
        public Azure.ResourceManager.Resources.Models.OperationDisplay Display { get { throw null; } }
        public string Name { get { throw null; } }
    }
    public partial class OperationAutoGenerated
    {
        internal OperationAutoGenerated() { }
        public Azure.ResourceManager.Resources.Models.OperationDisplayAutoGenerated Display { get { throw null; } }
        public string Name { get { throw null; } }
    }
    public partial class OperationAutoGenerated2
    {
        internal OperationAutoGenerated2() { }
        public Azure.ResourceManager.Resources.Models.OperationDisplayAutoGenerated2 Display { get { throw null; } }
        public string Name { get { throw null; } }
    }
    public partial class OperationDisplay
    {
        internal OperationDisplay() { }
        public string Description { get { throw null; } }
        public string Operation { get { throw null; } }
        public string Provider { get { throw null; } }
        public string Resource { get { throw null; } }
    }
    public partial class OperationDisplayAutoGenerated
    {
        internal OperationDisplayAutoGenerated() { }
        public string Operation { get { throw null; } }
        public string Provider { get { throw null; } }
        public string Resource { get { throw null; } }
    }
    public partial class OperationDisplayAutoGenerated2
    {
        internal OperationDisplayAutoGenerated2() { }
        public string Operation { get { throw null; } }
        public string Provider { get { throw null; } }
        public string Resource { get { throw null; } }
    }
    public partial class OperationListResult
    {
        internal OperationListResult() { }
        public string NextLink { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Resources.Models.Operation> Value { get { throw null; } }
    }
    public partial class OperationListResultAutoGenerated
    {
        internal OperationListResultAutoGenerated() { }
        public string NextLink { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Resources.Models.OperationAutoGenerated> Value { get { throw null; } }
    }
    public partial class OperationListResultAutoGenerated2
    {
        internal OperationListResultAutoGenerated2() { }
        public string NextLink { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Resources.Models.OperationAutoGenerated2> Value { get { throw null; } }
    }
    public partial class PairedRegion
    {
        internal PairedRegion() { }
        public string Id { get { throw null; } }
        public string Name { get { throw null; } }
        public string SubscriptionId { get { throw null; } }
    }
    public partial class ParameterDefinitionsValue
    {
        public ParameterDefinitionsValue() { }
        public System.Collections.Generic.IList<object> AllowedValues { get { throw null; } set { } }
        public object DefaultValue { get { throw null; } set { } }
        public Azure.ResourceManager.Resources.Models.ParameterDefinitionsValueMetadata Metadata { get { throw null; } set { } }
        public Azure.ResourceManager.Resources.Models.ParameterType? Type { get { throw null; } set { } }
    }
    public partial class ParameterDefinitionsValueMetadata : System.Collections.Generic.ICollection<System.Collections.Generic.KeyValuePair<string, object>>, System.Collections.Generic.IDictionary<string, object>, System.Collections.Generic.IEnumerable<System.Collections.Generic.KeyValuePair<string, object>>, System.Collections.IEnumerable
    {
        public ParameterDefinitionsValueMetadata() { }
        public string Description { get { throw null; } set { } }
        public string DisplayName { get { throw null; } set { } }
        public object this[string key] { get { throw null; } set { } }
        public System.Collections.Generic.ICollection<string> Keys { get { throw null; } }
        int System.Collections.Generic.ICollection<System.Collections.Generic.KeyValuePair<System.String,System.Object>>.Count { get { throw null; } }
        bool System.Collections.Generic.ICollection<System.Collections.Generic.KeyValuePair<System.String,System.Object>>.IsReadOnly { get { throw null; } }
        public System.Collections.Generic.ICollection<object> Values { get { throw null; } }
        public void Add(string key, object value) { }
        public bool ContainsKey(string key) { throw null; }
        public System.Collections.Generic.IEnumerator<System.Collections.Generic.KeyValuePair<string, object>> GetEnumerator() { throw null; }
        public bool Remove(string key) { throw null; }
        void System.Collections.Generic.ICollection<System.Collections.Generic.KeyValuePair<System.String,System.Object>>.Add(System.Collections.Generic.KeyValuePair<string, object> value) { }
        void System.Collections.Generic.ICollection<System.Collections.Generic.KeyValuePair<System.String,System.Object>>.Clear() { }
        bool System.Collections.Generic.ICollection<System.Collections.Generic.KeyValuePair<System.String,System.Object>>.Contains(System.Collections.Generic.KeyValuePair<string, object> value) { throw null; }
        void System.Collections.Generic.ICollection<System.Collections.Generic.KeyValuePair<System.String,System.Object>>.CopyTo(System.Collections.Generic.KeyValuePair<string, object>[] destination, int offset) { }
        bool System.Collections.Generic.ICollection<System.Collections.Generic.KeyValuePair<System.String,System.Object>>.Remove(System.Collections.Generic.KeyValuePair<string, object> value) { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
        public bool TryGetValue(string key, out object value) { throw null; }
    }
    public partial class ParametersLink
    {
        public ParametersLink(string uri) { }
        public string ContentVersion { get { throw null; } set { } }
        public string Uri { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ParameterType : System.IEquatable<Azure.ResourceManager.Resources.Models.ParameterType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ParameterType(string value) { throw null; }
        public static Azure.ResourceManager.Resources.Models.ParameterType Array { get { throw null; } }
        public static Azure.ResourceManager.Resources.Models.ParameterType Boolean { get { throw null; } }
        public static Azure.ResourceManager.Resources.Models.ParameterType DateTime { get { throw null; } }
        public static Azure.ResourceManager.Resources.Models.ParameterType Float { get { throw null; } }
        public static Azure.ResourceManager.Resources.Models.ParameterType Integer { get { throw null; } }
        public static Azure.ResourceManager.Resources.Models.ParameterType Object { get { throw null; } }
        public static Azure.ResourceManager.Resources.Models.ParameterType String { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Resources.Models.ParameterType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Resources.Models.ParameterType left, Azure.ResourceManager.Resources.Models.ParameterType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Resources.Models.ParameterType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Resources.Models.ParameterType left, Azure.ResourceManager.Resources.Models.ParameterType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ParameterValuesValue
    {
        public ParameterValuesValue() { }
        public object Value { get { throw null; } set { } }
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
    public partial class PlanAutoGenerated
    {
        public PlanAutoGenerated(string name, string publisher, string product, string version) { }
        public string Name { get { throw null; } set { } }
        public string Product { get { throw null; } set { } }
        public string PromotionCode { get { throw null; } set { } }
        public string Publisher { get { throw null; } set { } }
        public string Version { get { throw null; } set { } }
    }
    public partial class PlanPatchable
    {
        public PlanPatchable() { }
        public string Name { get { throw null; } set { } }
        public string Product { get { throw null; } set { } }
        public string PromotionCode { get { throw null; } set { } }
        public string Publisher { get { throw null; } set { } }
        public string Version { get { throw null; } set { } }
    }
    public partial class PolicyAssignment
    {
        public PolicyAssignment() { }
        public string Description { get { throw null; } set { } }
        public string DisplayName { get { throw null; } set { } }
        public Azure.ResourceManager.Resources.Models.EnforcementMode? EnforcementMode { get { throw null; } set { } }
        public string Id { get { throw null; } }
        public Azure.ResourceManager.Resources.Models.IdentityAutoGenerated Identity { get { throw null; } set { } }
        public string Location { get { throw null; } set { } }
        public object Metadata { get { throw null; } set { } }
        public string Name { get { throw null; } }
        public System.Collections.Generic.IList<string> NotScopes { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, Azure.ResourceManager.Resources.Models.ParameterValuesValue> Parameters { get { throw null; } set { } }
        public string PolicyDefinitionId { get { throw null; } set { } }
        public string Scope { get { throw null; } set { } }
        public Azure.ResourceManager.Resources.Models.PolicySku Sku { get { throw null; } set { } }
        public string Type { get { throw null; } }
    }
    public partial class PolicyAssignmentListResult
    {
        internal PolicyAssignmentListResult() { }
        public string NextLink { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Resources.Models.PolicyAssignment> Value { get { throw null; } }
    }
    public partial class PolicyDefinition
    {
        public PolicyDefinition() { }
        public string Description { get { throw null; } set { } }
        public string DisplayName { get { throw null; } set { } }
        public string Id { get { throw null; } }
        public object Metadata { get { throw null; } set { } }
        public string Mode { get { throw null; } set { } }
        public string Name { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, Azure.ResourceManager.Resources.Models.ParameterDefinitionsValue> Parameters { get { throw null; } set { } }
        public object PolicyRule { get { throw null; } set { } }
        public Azure.ResourceManager.Resources.Models.PolicyType? PolicyType { get { throw null; } set { } }
        public string Type { get { throw null; } }
    }
    public partial class PolicyDefinitionGroup
    {
        public PolicyDefinitionGroup(string name) { }
        public string AdditionalMetadataId { get { throw null; } set { } }
        public string Category { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public string DisplayName { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
    }
    public partial class PolicyDefinitionListResult
    {
        internal PolicyDefinitionListResult() { }
        public string NextLink { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Resources.Models.PolicyDefinition> Value { get { throw null; } }
    }
    public partial class PolicyDefinitionReference
    {
        public PolicyDefinitionReference(string policyDefinitionId) { }
        public System.Collections.Generic.IList<string> GroupNames { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, Azure.ResourceManager.Resources.Models.ParameterValuesValue> Parameters { get { throw null; } set { } }
        public string PolicyDefinitionId { get { throw null; } set { } }
        public string PolicyDefinitionReferenceId { get { throw null; } set { } }
    }
    public partial class PolicySetDefinition
    {
        public PolicySetDefinition() { }
        public string Description { get { throw null; } set { } }
        public string DisplayName { get { throw null; } set { } }
        public string Id { get { throw null; } }
        public object Metadata { get { throw null; } set { } }
        public string Name { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, Azure.ResourceManager.Resources.Models.ParameterDefinitionsValue> Parameters { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Resources.Models.PolicyDefinitionGroup> PolicyDefinitionGroups { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Resources.Models.PolicyDefinitionReference> PolicyDefinitions { get { throw null; } set { } }
        public Azure.ResourceManager.Resources.Models.PolicyType? PolicyType { get { throw null; } set { } }
        public string Type { get { throw null; } }
    }
    public partial class PolicySetDefinitionListResult
    {
        internal PolicySetDefinitionListResult() { }
        public string NextLink { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Resources.Models.PolicySetDefinition> Value { get { throw null; } }
    }
    public partial class PolicySku
    {
        public PolicySku(string name) { }
        public string Name { get { throw null; } set { } }
        public string Tier { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PolicyType : System.IEquatable<Azure.ResourceManager.Resources.Models.PolicyType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PolicyType(string value) { throw null; }
        public static Azure.ResourceManager.Resources.Models.PolicyType BuiltIn { get { throw null; } }
        public static Azure.ResourceManager.Resources.Models.PolicyType Custom { get { throw null; } }
        public static Azure.ResourceManager.Resources.Models.PolicyType NotSpecified { get { throw null; } }
        public static Azure.ResourceManager.Resources.Models.PolicyType Static { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Resources.Models.PolicyType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Resources.Models.PolicyType left, Azure.ResourceManager.Resources.Models.PolicyType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Resources.Models.PolicyType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Resources.Models.PolicyType left, Azure.ResourceManager.Resources.Models.PolicyType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public enum PropertyChangeType
    {
        Create = 0,
        Delete = 1,
        Modify = 2,
        Array = 3,
    }
    public partial class Provider
    {
        internal Provider() { }
        public string Id { get { throw null; } }
        public string Namespace { get { throw null; } }
        public string RegistrationPolicy { get { throw null; } }
        public string RegistrationState { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Resources.Models.ProviderResourceType> ResourceTypes { get { throw null; } }
    }
    public partial class ProviderListResult
    {
        internal ProviderListResult() { }
        public string NextLink { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Resources.Models.Provider> Value { get { throw null; } }
    }
    public partial class ProviderResourceType
    {
        internal ProviderResourceType() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Resources.Models.Alias> Aliases { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> ApiVersions { get { throw null; } }
        public string Capabilities { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> Locations { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, string> Properties { get { throw null; } }
        public string ResourceType { get { throw null; } }
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
    public readonly partial struct ProvisioningState : System.IEquatable<Azure.ResourceManager.Resources.Models.ProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.Resources.Models.ProvisioningState Accepted { get { throw null; } }
        public static Azure.ResourceManager.Resources.Models.ProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.Resources.Models.ProvisioningState Created { get { throw null; } }
        public static Azure.ResourceManager.Resources.Models.ProvisioningState Creating { get { throw null; } }
        public static Azure.ResourceManager.Resources.Models.ProvisioningState Deleted { get { throw null; } }
        public static Azure.ResourceManager.Resources.Models.ProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.Resources.Models.ProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.Resources.Models.ProvisioningState Ready { get { throw null; } }
        public static Azure.ResourceManager.Resources.Models.ProvisioningState Running { get { throw null; } }
        public static Azure.ResourceManager.Resources.Models.ProvisioningState Succeeded { get { throw null; } }
        public static Azure.ResourceManager.Resources.Models.ProvisioningState Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Resources.Models.ProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Resources.Models.ProvisioningState left, Azure.ResourceManager.Resources.Models.ProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Resources.Models.ProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Resources.Models.ProvisioningState left, Azure.ResourceManager.Resources.Models.ProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RegionCategory : System.IEquatable<Azure.ResourceManager.Resources.Models.RegionCategory>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RegionCategory(string value) { throw null; }
        public static Azure.ResourceManager.Resources.Models.RegionCategory Other { get { throw null; } }
        public static Azure.ResourceManager.Resources.Models.RegionCategory Recommended { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Resources.Models.RegionCategory other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Resources.Models.RegionCategory left, Azure.ResourceManager.Resources.Models.RegionCategory right) { throw null; }
        public static implicit operator Azure.ResourceManager.Resources.Models.RegionCategory (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Resources.Models.RegionCategory left, Azure.ResourceManager.Resources.Models.RegionCategory right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RegionType : System.IEquatable<Azure.ResourceManager.Resources.Models.RegionType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RegionType(string value) { throw null; }
        public static Azure.ResourceManager.Resources.Models.RegionType Logical { get { throw null; } }
        public static Azure.ResourceManager.Resources.Models.RegionType Physical { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Resources.Models.RegionType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Resources.Models.RegionType left, Azure.ResourceManager.Resources.Models.RegionType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Resources.Models.RegionType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Resources.Models.RegionType left, Azure.ResourceManager.Resources.Models.RegionType right) { throw null; }
        public override string ToString() { throw null; }
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
        public string Name { get { throw null; } }
        public Azure.ResourceManager.Resources.Models.ResourceGroupProperties Properties { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } set { } }
        public string Type { get { throw null; } }
    }
    public partial class ResourceGroupExportResult
    {
        internal ResourceGroupExportResult() { }
        public Azure.ResourceManager.Resources.Models.ErrorResponse Error { get { throw null; } }
        public object Template { get { throw null; } }
    }
    public partial class ResourceGroupListResult
    {
        internal ResourceGroupListResult() { }
        public string NextLink { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Resources.Models.ResourceGroup> Value { get { throw null; } }
    }
    public partial class ResourceGroupPatchable
    {
        public ResourceGroupPatchable() { }
        public string ManagedBy { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public Azure.ResourceManager.Resources.Models.ResourceGroupProperties Properties { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } set { } }
    }
    public partial class ResourceGroupProperties
    {
        public ResourceGroupProperties() { }
        public string ProvisioningState { get { throw null; } }
    }
    public enum ResourceIdentityType
    {
        SystemAssigned = 0,
        None = 1,
        UserAssigned = 2,
        SystemAssignedUserAssigned = 3,
    }
    public partial class ResourceLink
    {
        public ResourceLink() { }
        public string Id { get { throw null; } }
        public string Name { get { throw null; } }
        public Azure.ResourceManager.Resources.Models.ResourceLinkProperties Properties { get { throw null; } set { } }
        public object Type { get { throw null; } }
    }
    public partial class ResourceLinkProperties
    {
        public ResourceLinkProperties(string targetId) { }
        public string Notes { get { throw null; } set { } }
        public string SourceId { get { throw null; } }
        public string TargetId { get { throw null; } set { } }
    }
    public partial class ResourceLinkResult
    {
        internal ResourceLinkResult() { }
        public string NextLink { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Resources.Models.ResourceLink> Value { get { throw null; } }
    }
    public partial class ResourceListResult
    {
        internal ResourceListResult() { }
        public string NextLink { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Resources.Models.GenericResourceExpanded> Value { get { throw null; } }
    }
    public partial class ResourceReference
    {
        internal ResourceReference() { }
        public string Id { get { throw null; } }
    }
    public partial class ResourcesMoveInfo
    {
        public ResourcesMoveInfo() { }
        public System.Collections.Generic.IList<string> Resources { get { throw null; } set { } }
        public string TargetResourceGroup { get { throw null; } set { } }
    }
    public partial class ScopedDeployment
    {
        public ScopedDeployment(string location, Azure.ResourceManager.Resources.Models.DeploymentProperties properties) { }
        public string Location { get { throw null; } }
        public Azure.ResourceManager.Resources.Models.DeploymentProperties Properties { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } set { } }
    }
    public partial class ScriptConfigurationBase
    {
        public ScriptConfigurationBase(System.TimeSpan retentionInterval) { }
        public string Arguments { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Resources.Models.EnvironmentVariable> EnvironmentVariables { get { throw null; } set { } }
        public string ForceUpdateTag { get { throw null; } set { } }
        public string PrimaryScriptUri { get { throw null; } set { } }
        public System.TimeSpan RetentionInterval { get { throw null; } set { } }
        public string ScriptContent { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> SupportingScriptUris { get { throw null; } set { } }
        public System.TimeSpan? Timeout { get { throw null; } set { } }
    }
    public partial class ScriptLog : Azure.ResourceManager.Resources.Models.AzureResourceBase
    {
        public ScriptLog() { }
        public string Log { get { throw null; } }
    }
    public partial class ScriptLogsList
    {
        internal ScriptLogsList() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Resources.Models.ScriptLog> Value { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ScriptProvisioningState : System.IEquatable<Azure.ResourceManager.Resources.Models.ScriptProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ScriptProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.Resources.Models.ScriptProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.Resources.Models.ScriptProvisioningState Creating { get { throw null; } }
        public static Azure.ResourceManager.Resources.Models.ScriptProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.Resources.Models.ScriptProvisioningState ProvisioningResources { get { throw null; } }
        public static Azure.ResourceManager.Resources.Models.ScriptProvisioningState Running { get { throw null; } }
        public static Azure.ResourceManager.Resources.Models.ScriptProvisioningState Succeeded { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Resources.Models.ScriptProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Resources.Models.ScriptProvisioningState left, Azure.ResourceManager.Resources.Models.ScriptProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Resources.Models.ScriptProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Resources.Models.ScriptProvisioningState left, Azure.ResourceManager.Resources.Models.ScriptProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ScriptStatus
    {
        public ScriptStatus() { }
        public string ContainerInstanceId { get { throw null; } }
        public System.DateTimeOffset? EndTime { get { throw null; } }
        public Azure.ResourceManager.Resources.Models.ErrorResponse Error { get { throw null; } set { } }
        public System.DateTimeOffset? ExpirationTime { get { throw null; } }
        public System.DateTimeOffset? StartTime { get { throw null; } }
        public string StorageAccountId { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ScriptType : System.IEquatable<Azure.ResourceManager.Resources.Models.ScriptType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ScriptType(string value) { throw null; }
        public static Azure.ResourceManager.Resources.Models.ScriptType AzureCLI { get { throw null; } }
        public static Azure.ResourceManager.Resources.Models.ScriptType AzurePowerShell { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Resources.Models.ScriptType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Resources.Models.ScriptType left, Azure.ResourceManager.Resources.Models.ScriptType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Resources.Models.ScriptType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Resources.Models.ScriptType left, Azure.ResourceManager.Resources.Models.ScriptType right) { throw null; }
        public override string ToString() { throw null; }
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
    public partial class SkuAutoGenerated
    {
        public SkuAutoGenerated(string name) { }
        public int? Capacity { get { throw null; } set { } }
        public string Family { get { throw null; } set { } }
        public string Model { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public string Size { get { throw null; } set { } }
        public string Tier { get { throw null; } set { } }
    }
    public enum SpendingLimit
    {
        On = 0,
        Off = 1,
        CurrentPeriodOff = 2,
    }
    public partial class StorageAccountConfiguration
    {
        public StorageAccountConfiguration() { }
        public string StorageAccountKey { get { throw null; } set { } }
        public string StorageAccountName { get { throw null; } set { } }
    }
    public partial class Subscription
    {
        internal Subscription() { }
        public string AuthorizationSource { get { throw null; } }
        public string DisplayName { get { throw null; } }
        public string Id { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Resources.Models.ManagedByTenant> ManagedByTenants { get { throw null; } }
        public Azure.ResourceManager.Resources.Models.SubscriptionState? State { get { throw null; } }
        public string SubscriptionId { get { throw null; } }
        public Azure.ResourceManager.Resources.Models.SubscriptionPolicies SubscriptionPolicies { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, string> Tags { get { throw null; } }
        public string TenantId { get { throw null; } }
    }
    public partial class SubscriptionListResult
    {
        internal SubscriptionListResult() { }
        public string NextLink { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Resources.Models.Subscription> Value { get { throw null; } }
    }
    public partial class SubscriptionPolicies
    {
        internal SubscriptionPolicies() { }
        public string LocationPlacementId { get { throw null; } }
        public string QuotaId { get { throw null; } }
        public Azure.ResourceManager.Resources.Models.SpendingLimit? SpendingLimit { get { throw null; } }
    }
    public enum SubscriptionState
    {
        Enabled = 0,
        Warned = 1,
        PastDue = 2,
        Disabled = 3,
        Deleted = 4,
    }
    public partial class SystemData
    {
        public SystemData() { }
        public System.DateTimeOffset? CreatedAt { get { throw null; } set { } }
        public string CreatedBy { get { throw null; } set { } }
        public Azure.ResourceManager.Resources.Models.CreatedByType? CreatedByType { get { throw null; } set { } }
        public System.DateTimeOffset? LastModifiedAt { get { throw null; } set { } }
        public string LastModifiedBy { get { throw null; } set { } }
        public Azure.ResourceManager.Resources.Models.CreatedByType? LastModifiedByType { get { throw null; } set { } }
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
        public Azure.ResourceManager.Resources.Models.TagCount Count { get { throw null; } }
        public string Id { get { throw null; } }
        public string TagName { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Resources.Models.TagValue> Values { get { throw null; } }
    }
    public partial class Tags
    {
        public Tags() { }
        public System.Collections.Generic.IDictionary<string, string> TagsValue { get { throw null; } set { } }
    }
    public partial class TagsListResult
    {
        internal TagsListResult() { }
        public string NextLink { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Resources.Models.TagDetails> Value { get { throw null; } }
    }
    public partial class TagsPatchResource
    {
        public TagsPatchResource() { }
        public Azure.ResourceManager.Resources.Models.TagsPatchResourceOperation? Operation { get { throw null; } set { } }
        public Azure.ResourceManager.Resources.Models.Tags Properties { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct TagsPatchResourceOperation : System.IEquatable<Azure.ResourceManager.Resources.Models.TagsPatchResourceOperation>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public TagsPatchResourceOperation(string value) { throw null; }
        public static Azure.ResourceManager.Resources.Models.TagsPatchResourceOperation Delete { get { throw null; } }
        public static Azure.ResourceManager.Resources.Models.TagsPatchResourceOperation Merge { get { throw null; } }
        public static Azure.ResourceManager.Resources.Models.TagsPatchResourceOperation Replace { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Resources.Models.TagsPatchResourceOperation other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Resources.Models.TagsPatchResourceOperation left, Azure.ResourceManager.Resources.Models.TagsPatchResourceOperation right) { throw null; }
        public static implicit operator Azure.ResourceManager.Resources.Models.TagsPatchResourceOperation (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Resources.Models.TagsPatchResourceOperation left, Azure.ResourceManager.Resources.Models.TagsPatchResourceOperation right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class TagsResource
    {
        public TagsResource(Azure.ResourceManager.Resources.Models.Tags properties) { }
        public string Id { get { throw null; } }
        public string Name { get { throw null; } }
        public Azure.ResourceManager.Resources.Models.Tags Properties { get { throw null; } set { } }
        public string Type { get { throw null; } }
    }
    public partial class TagValue
    {
        internal TagValue() { }
        public Azure.ResourceManager.Resources.Models.TagCount Count { get { throw null; } }
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
    public enum TenantCategory
    {
        Home = 0,
        ProjectedBy = 1,
        ManagedBy = 2,
    }
    public partial class TenantIdDescription
    {
        internal TenantIdDescription() { }
        public string Country { get { throw null; } }
        public string CountryCode { get { throw null; } }
        public string DisplayName { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> Domains { get { throw null; } }
        public string Id { get { throw null; } }
        public Azure.ResourceManager.Resources.Models.TenantCategory? TenantCategory { get { throw null; } }
        public string TenantId { get { throw null; } }
    }
    public partial class TenantListResult
    {
        internal TenantListResult() { }
        public string NextLink { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Resources.Models.TenantIdDescription> Value { get { throw null; } }
    }
    public partial class UserAssignedIdentity
    {
        public UserAssignedIdentity() { }
        public string ClientId { get { throw null; } set { } }
        public string PrincipalId { get { throw null; } set { } }
    }
    public partial class WhatIfChange
    {
        internal WhatIfChange() { }
        public object After { get { throw null; } }
        public object Before { get { throw null; } }
        public Azure.ResourceManager.Resources.Models.ChangeType ChangeType { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Resources.Models.WhatIfPropertyChange> Delta { get { throw null; } }
        public string ResourceId { get { throw null; } }
    }
    public partial class WhatIfOperationResult
    {
        internal WhatIfOperationResult() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Resources.Models.WhatIfChange> Changes { get { throw null; } }
        public Azure.ResourceManager.Resources.Models.ErrorResponse Error { get { throw null; } }
        public string Status { get { throw null; } }
    }
    public partial class WhatIfPropertyChange
    {
        internal WhatIfPropertyChange() { }
        public object After { get { throw null; } }
        public object Before { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Resources.Models.WhatIfPropertyChange> Children { get { throw null; } }
        public string Path { get { throw null; } }
        public Azure.ResourceManager.Resources.Models.PropertyChangeType PropertyChangeType { get { throw null; } }
    }
    public enum WhatIfResultFormat
    {
        ResourceIdOnly = 0,
        FullResourcePayloads = 1,
    }
}
