namespace Azure.Management.Resource
{
    public partial class DeploymentClient
    {
        protected DeploymentClient() { }
        public DeploymentClient(string subscriptionId, Azure.Core.TokenCredential tokenCredential, Azure.Management.Resource.ResourceManagementClientOptions options = null) { }
        public DeploymentClient(string subscriptionId, string host, Azure.Core.TokenCredential tokenCredential, Azure.Management.Resource.ResourceManagementClientOptions options = null) { }
        public virtual Azure.Response<Azure.Management.Resource.Models.DeploymentOperation> Get(string resourceGroupName, string deploymentName, string operationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Management.Resource.Models.DeploymentOperation>> GetAsync(string resourceGroupName, string deploymentName, string operationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Management.Resource.Models.DeploymentOperation> GetAtManagementGroupScope(string groupId, string deploymentName, string operationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Management.Resource.Models.DeploymentOperation>> GetAtManagementGroupScopeAsync(string groupId, string deploymentName, string operationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Management.Resource.Models.DeploymentOperation> GetAtScope(string scope, string deploymentName, string operationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Management.Resource.Models.DeploymentOperation>> GetAtScopeAsync(string scope, string deploymentName, string operationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Management.Resource.Models.DeploymentOperation> GetAtSubscriptionScope(string deploymentName, string operationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Management.Resource.Models.DeploymentOperation>> GetAtSubscriptionScopeAsync(string deploymentName, string operationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Management.Resource.Models.DeploymentOperation> GetAtTenantScope(string deploymentName, string operationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Management.Resource.Models.DeploymentOperation>> GetAtTenantScopeAsync(string deploymentName, string operationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.Management.Resource.Models.DeploymentOperation> List(string resourceGroupName, string deploymentName, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.Management.Resource.Models.DeploymentOperation> ListAsync(string resourceGroupName, string deploymentName, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.Management.Resource.Models.DeploymentOperation> ListAtManagementGroupScope(string groupId, string deploymentName, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.Management.Resource.Models.DeploymentOperation> ListAtManagementGroupScopeAsync(string groupId, string deploymentName, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.Management.Resource.Models.DeploymentOperation> ListAtScope(string scope, string deploymentName, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.Management.Resource.Models.DeploymentOperation> ListAtScopeAsync(string scope, string deploymentName, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.Management.Resource.Models.DeploymentOperation> ListAtSubscriptionScope(string deploymentName, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.Management.Resource.Models.DeploymentOperation> ListAtSubscriptionScopeAsync(string deploymentName, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.Management.Resource.Models.DeploymentOperation> ListAtTenantScope(string deploymentName, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.Management.Resource.Models.DeploymentOperation> ListAtTenantScopeAsync(string deploymentName, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DeploymentsClient
    {
        protected DeploymentsClient() { }
        public DeploymentsClient(string subscriptionId, Azure.Core.TokenCredential tokenCredential, Azure.Management.Resource.ResourceManagementClientOptions options = null) { }
        public DeploymentsClient(string subscriptionId, string host, Azure.Core.TokenCredential tokenCredential, Azure.Management.Resource.ResourceManagementClientOptions options = null) { }
        public virtual Azure.Response<Azure.Management.Resource.Models.TemplateHashResult> CalculateTemplateHash(object template, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Management.Resource.Models.TemplateHashResult>> CalculateTemplateHashAsync(object template, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
        public virtual Azure.Response<Azure.Management.Resource.Models.DeploymentExportResult> ExportTemplate(string resourceGroupName, string deploymentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Management.Resource.Models.DeploymentExportResult>> ExportTemplateAsync(string resourceGroupName, string deploymentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Management.Resource.Models.DeploymentExportResult> ExportTemplateAtManagementGroupScope(string groupId, string deploymentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Management.Resource.Models.DeploymentExportResult>> ExportTemplateAtManagementGroupScopeAsync(string groupId, string deploymentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Management.Resource.Models.DeploymentExportResult> ExportTemplateAtScope(string scope, string deploymentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Management.Resource.Models.DeploymentExportResult>> ExportTemplateAtScopeAsync(string scope, string deploymentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Management.Resource.Models.DeploymentExportResult> ExportTemplateAtSubscriptionScope(string deploymentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Management.Resource.Models.DeploymentExportResult>> ExportTemplateAtSubscriptionScopeAsync(string deploymentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Management.Resource.Models.DeploymentExportResult> ExportTemplateAtTenantScope(string deploymentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Management.Resource.Models.DeploymentExportResult>> ExportTemplateAtTenantScopeAsync(string deploymentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Management.Resource.Models.DeploymentExtended> Get(string resourceGroupName, string deploymentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Management.Resource.Models.DeploymentExtended>> GetAsync(string resourceGroupName, string deploymentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Management.Resource.Models.DeploymentExtended> GetAtManagementGroupScope(string groupId, string deploymentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Management.Resource.Models.DeploymentExtended>> GetAtManagementGroupScopeAsync(string groupId, string deploymentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Management.Resource.Models.DeploymentExtended> GetAtScope(string scope, string deploymentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Management.Resource.Models.DeploymentExtended>> GetAtScopeAsync(string scope, string deploymentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Management.Resource.Models.DeploymentExtended> GetAtSubscriptionScope(string deploymentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Management.Resource.Models.DeploymentExtended>> GetAtSubscriptionScopeAsync(string deploymentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Management.Resource.Models.DeploymentExtended> GetAtTenantScope(string deploymentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Management.Resource.Models.DeploymentExtended>> GetAtTenantScopeAsync(string deploymentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.Management.Resource.Models.DeploymentExtended> ListAtManagementGroupScope(string groupId, string filter = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.Management.Resource.Models.DeploymentExtended> ListAtManagementGroupScopeAsync(string groupId, string filter = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.Management.Resource.Models.DeploymentExtended> ListAtScope(string scope, string filter = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.Management.Resource.Models.DeploymentExtended> ListAtScopeAsync(string scope, string filter = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.Management.Resource.Models.DeploymentExtended> ListAtSubscriptionScope(string filter = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.Management.Resource.Models.DeploymentExtended> ListAtSubscriptionScopeAsync(string filter = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.Management.Resource.Models.DeploymentExtended> ListAtTenantScope(string filter = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.Management.Resource.Models.DeploymentExtended> ListAtTenantScopeAsync(string filter = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.Management.Resource.Models.DeploymentExtended> ListByResourceGroup(string resourceGroupName, string filter = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.Management.Resource.Models.DeploymentExtended> ListByResourceGroupAsync(string resourceGroupName, string filter = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Management.Resource.DeploymentsCreateOrUpdateOperation StartCreateOrUpdate(string resourceGroupName, string deploymentName, Azure.Management.Resource.Models.Deployment parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.ValueTask<Azure.Management.Resource.DeploymentsCreateOrUpdateOperation> StartCreateOrUpdateAsync(string resourceGroupName, string deploymentName, Azure.Management.Resource.Models.Deployment parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Management.Resource.DeploymentsCreateOrUpdateAtManagementGroupScopeOperation StartCreateOrUpdateAtManagementGroupScope(string groupId, string deploymentName, Azure.Management.Resource.Models.ScopedDeployment parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.ValueTask<Azure.Management.Resource.DeploymentsCreateOrUpdateAtManagementGroupScopeOperation> StartCreateOrUpdateAtManagementGroupScopeAsync(string groupId, string deploymentName, Azure.Management.Resource.Models.ScopedDeployment parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Management.Resource.DeploymentsCreateOrUpdateAtScopeOperation StartCreateOrUpdateAtScope(string scope, string deploymentName, Azure.Management.Resource.Models.Deployment parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.ValueTask<Azure.Management.Resource.DeploymentsCreateOrUpdateAtScopeOperation> StartCreateOrUpdateAtScopeAsync(string scope, string deploymentName, Azure.Management.Resource.Models.Deployment parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Management.Resource.DeploymentsCreateOrUpdateAtSubscriptionScopeOperation StartCreateOrUpdateAtSubscriptionScope(string deploymentName, Azure.Management.Resource.Models.Deployment parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.ValueTask<Azure.Management.Resource.DeploymentsCreateOrUpdateAtSubscriptionScopeOperation> StartCreateOrUpdateAtSubscriptionScopeAsync(string deploymentName, Azure.Management.Resource.Models.Deployment parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Management.Resource.DeploymentsCreateOrUpdateAtTenantScopeOperation StartCreateOrUpdateAtTenantScope(string deploymentName, Azure.Management.Resource.Models.ScopedDeployment parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.ValueTask<Azure.Management.Resource.DeploymentsCreateOrUpdateAtTenantScopeOperation> StartCreateOrUpdateAtTenantScopeAsync(string deploymentName, Azure.Management.Resource.Models.ScopedDeployment parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Management.Resource.DeploymentsDeleteOperation StartDelete(string resourceGroupName, string deploymentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.ValueTask<Azure.Management.Resource.DeploymentsDeleteOperation> StartDeleteAsync(string resourceGroupName, string deploymentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Management.Resource.DeploymentsDeleteAtManagementGroupScopeOperation StartDeleteAtManagementGroupScope(string groupId, string deploymentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.ValueTask<Azure.Management.Resource.DeploymentsDeleteAtManagementGroupScopeOperation> StartDeleteAtManagementGroupScopeAsync(string groupId, string deploymentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Management.Resource.DeploymentsDeleteAtScopeOperation StartDeleteAtScope(string scope, string deploymentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.ValueTask<Azure.Management.Resource.DeploymentsDeleteAtScopeOperation> StartDeleteAtScopeAsync(string scope, string deploymentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Management.Resource.DeploymentsDeleteAtSubscriptionScopeOperation StartDeleteAtSubscriptionScope(string deploymentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.ValueTask<Azure.Management.Resource.DeploymentsDeleteAtSubscriptionScopeOperation> StartDeleteAtSubscriptionScopeAsync(string deploymentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Management.Resource.DeploymentsDeleteAtTenantScopeOperation StartDeleteAtTenantScope(string deploymentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.ValueTask<Azure.Management.Resource.DeploymentsDeleteAtTenantScopeOperation> StartDeleteAtTenantScopeAsync(string deploymentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Management.Resource.DeploymentsValidateOperation StartValidate(string resourceGroupName, string deploymentName, Azure.Management.Resource.Models.Deployment parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.ValueTask<Azure.Management.Resource.DeploymentsValidateOperation> StartValidateAsync(string resourceGroupName, string deploymentName, Azure.Management.Resource.Models.Deployment parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Management.Resource.DeploymentsValidateAtManagementGroupScopeOperation StartValidateAtManagementGroupScope(string groupId, string deploymentName, Azure.Management.Resource.Models.ScopedDeployment parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.ValueTask<Azure.Management.Resource.DeploymentsValidateAtManagementGroupScopeOperation> StartValidateAtManagementGroupScopeAsync(string groupId, string deploymentName, Azure.Management.Resource.Models.ScopedDeployment parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Management.Resource.DeploymentsValidateAtScopeOperation StartValidateAtScope(string scope, string deploymentName, Azure.Management.Resource.Models.Deployment parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.ValueTask<Azure.Management.Resource.DeploymentsValidateAtScopeOperation> StartValidateAtScopeAsync(string scope, string deploymentName, Azure.Management.Resource.Models.Deployment parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Management.Resource.DeploymentsValidateAtSubscriptionScopeOperation StartValidateAtSubscriptionScope(string deploymentName, Azure.Management.Resource.Models.Deployment parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.ValueTask<Azure.Management.Resource.DeploymentsValidateAtSubscriptionScopeOperation> StartValidateAtSubscriptionScopeAsync(string deploymentName, Azure.Management.Resource.Models.Deployment parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Management.Resource.DeploymentsValidateAtTenantScopeOperation StartValidateAtTenantScope(string deploymentName, Azure.Management.Resource.Models.ScopedDeployment parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.ValueTask<Azure.Management.Resource.DeploymentsValidateAtTenantScopeOperation> StartValidateAtTenantScopeAsync(string deploymentName, Azure.Management.Resource.Models.ScopedDeployment parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Management.Resource.DeploymentsWhatIfOperation StartWhatIf(string resourceGroupName, string deploymentName, Azure.Management.Resource.Models.DeploymentWhatIf parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.ValueTask<Azure.Management.Resource.DeploymentsWhatIfOperation> StartWhatIfAsync(string resourceGroupName, string deploymentName, Azure.Management.Resource.Models.DeploymentWhatIf parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Management.Resource.DeploymentsWhatIfAtSubscriptionScopeOperation StartWhatIfAtSubscriptionScope(string deploymentName, Azure.Management.Resource.Models.DeploymentWhatIf parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.ValueTask<Azure.Management.Resource.DeploymentsWhatIfAtSubscriptionScopeOperation> StartWhatIfAtSubscriptionScopeAsync(string deploymentName, Azure.Management.Resource.Models.DeploymentWhatIf parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DeploymentsCreateOrUpdateAtManagementGroupScopeOperation : Azure.Operation<Azure.Management.Resource.Models.DeploymentExtended>
    {
        internal DeploymentsCreateOrUpdateAtManagementGroupScopeOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.Management.Resource.Models.DeploymentExtended Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.Management.Resource.Models.DeploymentExtended>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.Management.Resource.Models.DeploymentExtended>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DeploymentsCreateOrUpdateAtScopeOperation : Azure.Operation<Azure.Management.Resource.Models.DeploymentExtended>
    {
        internal DeploymentsCreateOrUpdateAtScopeOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.Management.Resource.Models.DeploymentExtended Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.Management.Resource.Models.DeploymentExtended>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.Management.Resource.Models.DeploymentExtended>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DeploymentsCreateOrUpdateAtSubscriptionScopeOperation : Azure.Operation<Azure.Management.Resource.Models.DeploymentExtended>
    {
        internal DeploymentsCreateOrUpdateAtSubscriptionScopeOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.Management.Resource.Models.DeploymentExtended Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.Management.Resource.Models.DeploymentExtended>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.Management.Resource.Models.DeploymentExtended>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DeploymentsCreateOrUpdateAtTenantScopeOperation : Azure.Operation<Azure.Management.Resource.Models.DeploymentExtended>
    {
        internal DeploymentsCreateOrUpdateAtTenantScopeOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.Management.Resource.Models.DeploymentExtended Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.Management.Resource.Models.DeploymentExtended>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.Management.Resource.Models.DeploymentExtended>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DeploymentsCreateOrUpdateOperation : Azure.Operation<Azure.Management.Resource.Models.DeploymentExtended>
    {
        internal DeploymentsCreateOrUpdateOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.Management.Resource.Models.DeploymentExtended Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.Management.Resource.Models.DeploymentExtended>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.Management.Resource.Models.DeploymentExtended>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DeploymentScriptsClient
    {
        protected DeploymentScriptsClient() { }
        public DeploymentScriptsClient(string subscriptionId, Azure.Core.TokenCredential tokenCredential, Azure.Management.Resource.ResourceManagementClientOptions options = null) { }
        public DeploymentScriptsClient(string subscriptionId, string host, Azure.Core.TokenCredential tokenCredential, Azure.Management.Resource.ResourceManagementClientOptions options = null) { }
        public virtual Azure.Response Delete(string resourceGroupName, string scriptName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteAsync(string resourceGroupName, string scriptName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Management.Resource.Models.DeploymentScript> Get(string resourceGroupName, string scriptName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Management.Resource.Models.DeploymentScript>> GetAsync(string resourceGroupName, string scriptName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Management.Resource.Models.ScriptLogsList> GetLogs(string resourceGroupName, string scriptName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Management.Resource.Models.ScriptLogsList>> GetLogsAsync(string resourceGroupName, string scriptName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Management.Resource.Models.ScriptLog> GetLogsDefault(string resourceGroupName, string scriptName, int? tail = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Management.Resource.Models.ScriptLog>> GetLogsDefaultAsync(string resourceGroupName, string scriptName, int? tail = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.Management.Resource.Models.DeploymentScript> ListByResourceGroup(string resourceGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.Management.Resource.Models.DeploymentScript> ListByResourceGroupAsync(string resourceGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.Management.Resource.Models.DeploymentScript> ListBySubscription(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.Management.Resource.Models.DeploymentScript> ListBySubscriptionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Management.Resource.DeploymentScriptsCreateOperation StartCreate(string resourceGroupName, string scriptName, Azure.Management.Resource.Models.DeploymentScript deploymentScript, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.ValueTask<Azure.Management.Resource.DeploymentScriptsCreateOperation> StartCreateAsync(string resourceGroupName, string scriptName, Azure.Management.Resource.Models.DeploymentScript deploymentScript, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Management.Resource.Models.DeploymentScript> Update(string resourceGroupName, string scriptName, Azure.Management.Resource.Models.DeploymentScriptUpdateParameter deploymentScript = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Management.Resource.Models.DeploymentScript>> UpdateAsync(string resourceGroupName, string scriptName, Azure.Management.Resource.Models.DeploymentScriptUpdateParameter deploymentScript = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DeploymentScriptsCreateOperation : Azure.Operation<Azure.Management.Resource.Models.DeploymentScript>
    {
        internal DeploymentScriptsCreateOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.Management.Resource.Models.DeploymentScript Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.Management.Resource.Models.DeploymentScript>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.Management.Resource.Models.DeploymentScript>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
    public partial class DeploymentsValidateAtManagementGroupScopeOperation : Azure.Operation<Azure.Management.Resource.Models.DeploymentValidateResult>
    {
        internal DeploymentsValidateAtManagementGroupScopeOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.Management.Resource.Models.DeploymentValidateResult Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.Management.Resource.Models.DeploymentValidateResult>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.Management.Resource.Models.DeploymentValidateResult>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DeploymentsValidateAtScopeOperation : Azure.Operation<Azure.Management.Resource.Models.DeploymentValidateResult>
    {
        internal DeploymentsValidateAtScopeOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.Management.Resource.Models.DeploymentValidateResult Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.Management.Resource.Models.DeploymentValidateResult>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.Management.Resource.Models.DeploymentValidateResult>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DeploymentsValidateAtSubscriptionScopeOperation : Azure.Operation<Azure.Management.Resource.Models.DeploymentValidateResult>
    {
        internal DeploymentsValidateAtSubscriptionScopeOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.Management.Resource.Models.DeploymentValidateResult Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.Management.Resource.Models.DeploymentValidateResult>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.Management.Resource.Models.DeploymentValidateResult>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DeploymentsValidateAtTenantScopeOperation : Azure.Operation<Azure.Management.Resource.Models.DeploymentValidateResult>
    {
        internal DeploymentsValidateAtTenantScopeOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.Management.Resource.Models.DeploymentValidateResult Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.Management.Resource.Models.DeploymentValidateResult>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.Management.Resource.Models.DeploymentValidateResult>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DeploymentsValidateOperation : Azure.Operation<Azure.Management.Resource.Models.DeploymentValidateResult>
    {
        internal DeploymentsValidateOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.Management.Resource.Models.DeploymentValidateResult Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.Management.Resource.Models.DeploymentValidateResult>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.Management.Resource.Models.DeploymentValidateResult>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DeploymentsWhatIfAtSubscriptionScopeOperation : Azure.Operation<Azure.Management.Resource.Models.WhatIfOperationResult>
    {
        internal DeploymentsWhatIfAtSubscriptionScopeOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.Management.Resource.Models.WhatIfOperationResult Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.Management.Resource.Models.WhatIfOperationResult>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.Management.Resource.Models.WhatIfOperationResult>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DeploymentsWhatIfOperation : Azure.Operation<Azure.Management.Resource.Models.WhatIfOperationResult>
    {
        internal DeploymentsWhatIfOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.Management.Resource.Models.WhatIfOperationResult Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.Management.Resource.Models.WhatIfOperationResult>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.Management.Resource.Models.WhatIfOperationResult>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class OperationsClient
    {
        protected OperationsClient() { }
        public OperationsClient(Azure.Core.TokenCredential tokenCredential, Azure.Management.Resource.ResourceManagementClientOptions options = null) { }
        public OperationsClient(string host, Azure.Core.TokenCredential tokenCredential, Azure.Management.Resource.ResourceManagementClientOptions options = null) { }
        public virtual Azure.Pageable<Azure.Management.Resource.Models.Operation> List(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.Management.Resource.Models.Operation> ListAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class PolicyAssignmentsClient
    {
        protected PolicyAssignmentsClient() { }
        public PolicyAssignmentsClient(string subscriptionId, Azure.Core.TokenCredential tokenCredential, Azure.Management.Resource.ResourceManagementClientOptions options = null) { }
        public PolicyAssignmentsClient(string subscriptionId, string host, Azure.Core.TokenCredential tokenCredential, Azure.Management.Resource.ResourceManagementClientOptions options = null) { }
        public virtual Azure.Response<Azure.Management.Resource.Models.PolicyAssignment> Create(string scope, string policyAssignmentName, Azure.Management.Resource.Models.PolicyAssignment parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Management.Resource.Models.PolicyAssignment>> CreateAsync(string scope, string policyAssignmentName, Azure.Management.Resource.Models.PolicyAssignment parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Management.Resource.Models.PolicyAssignment> CreateById(string policyAssignmentId, Azure.Management.Resource.Models.PolicyAssignment parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Management.Resource.Models.PolicyAssignment>> CreateByIdAsync(string policyAssignmentId, Azure.Management.Resource.Models.PolicyAssignment parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Management.Resource.Models.PolicyAssignment> Delete(string scope, string policyAssignmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Management.Resource.Models.PolicyAssignment>> DeleteAsync(string scope, string policyAssignmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Management.Resource.Models.PolicyAssignment> DeleteById(string policyAssignmentId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Management.Resource.Models.PolicyAssignment>> DeleteByIdAsync(string policyAssignmentId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Management.Resource.Models.PolicyAssignment> Get(string scope, string policyAssignmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Management.Resource.Models.PolicyAssignment>> GetAsync(string scope, string policyAssignmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Management.Resource.Models.PolicyAssignment> GetById(string policyAssignmentId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Management.Resource.Models.PolicyAssignment>> GetByIdAsync(string policyAssignmentId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.Management.Resource.Models.PolicyAssignment> List(string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.Management.Resource.Models.PolicyAssignment> ListAsync(string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.Management.Resource.Models.PolicyAssignment> ListForManagementGroup(string managementGroupId, string filter, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.Management.Resource.Models.PolicyAssignment> ListForManagementGroupAsync(string managementGroupId, string filter, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.Management.Resource.Models.PolicyAssignment> ListForResource(string resourceGroupName, string resourceProviderNamespace, string parentResourcePath, string resourceType, string resourceName, string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.Management.Resource.Models.PolicyAssignment> ListForResourceAsync(string resourceGroupName, string resourceProviderNamespace, string parentResourcePath, string resourceType, string resourceName, string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.Management.Resource.Models.PolicyAssignment> ListForResourceGroup(string resourceGroupName, string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.Management.Resource.Models.PolicyAssignment> ListForResourceGroupAsync(string resourceGroupName, string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class PolicyDefinitionsClient
    {
        protected PolicyDefinitionsClient() { }
        public PolicyDefinitionsClient(string subscriptionId, Azure.Core.TokenCredential tokenCredential, Azure.Management.Resource.ResourceManagementClientOptions options = null) { }
        public PolicyDefinitionsClient(string subscriptionId, string host, Azure.Core.TokenCredential tokenCredential, Azure.Management.Resource.ResourceManagementClientOptions options = null) { }
        public virtual Azure.Response<Azure.Management.Resource.Models.PolicyDefinition> CreateOrUpdate(string policyDefinitionName, Azure.Management.Resource.Models.PolicyDefinition parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Management.Resource.Models.PolicyDefinition>> CreateOrUpdateAsync(string policyDefinitionName, Azure.Management.Resource.Models.PolicyDefinition parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Management.Resource.Models.PolicyDefinition> CreateOrUpdateAtManagementGroup(string policyDefinitionName, string managementGroupId, Azure.Management.Resource.Models.PolicyDefinition parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Management.Resource.Models.PolicyDefinition>> CreateOrUpdateAtManagementGroupAsync(string policyDefinitionName, string managementGroupId, Azure.Management.Resource.Models.PolicyDefinition parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response Delete(string policyDefinitionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteAsync(string policyDefinitionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response DeleteAtManagementGroup(string policyDefinitionName, string managementGroupId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteAtManagementGroupAsync(string policyDefinitionName, string managementGroupId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Management.Resource.Models.PolicyDefinition> Get(string policyDefinitionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Management.Resource.Models.PolicyDefinition>> GetAsync(string policyDefinitionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Management.Resource.Models.PolicyDefinition> GetAtManagementGroup(string policyDefinitionName, string managementGroupId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Management.Resource.Models.PolicyDefinition>> GetAtManagementGroupAsync(string policyDefinitionName, string managementGroupId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Management.Resource.Models.PolicyDefinition> GetBuiltIn(string policyDefinitionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Management.Resource.Models.PolicyDefinition>> GetBuiltInAsync(string policyDefinitionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.Management.Resource.Models.PolicyDefinition> List(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.Management.Resource.Models.PolicyDefinition> ListAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.Management.Resource.Models.PolicyDefinition> ListBuiltIn(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.Management.Resource.Models.PolicyDefinition> ListBuiltInAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.Management.Resource.Models.PolicyDefinition> ListByManagementGroup(string managementGroupId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.Management.Resource.Models.PolicyDefinition> ListByManagementGroupAsync(string managementGroupId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class PolicySetDefinitionsClient
    {
        protected PolicySetDefinitionsClient() { }
        public PolicySetDefinitionsClient(string subscriptionId, Azure.Core.TokenCredential tokenCredential, Azure.Management.Resource.ResourceManagementClientOptions options = null) { }
        public PolicySetDefinitionsClient(string subscriptionId, string host, Azure.Core.TokenCredential tokenCredential, Azure.Management.Resource.ResourceManagementClientOptions options = null) { }
        public virtual Azure.Response<Azure.Management.Resource.Models.PolicySetDefinition> CreateOrUpdate(string policySetDefinitionName, Azure.Management.Resource.Models.PolicySetDefinition parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Management.Resource.Models.PolicySetDefinition>> CreateOrUpdateAsync(string policySetDefinitionName, Azure.Management.Resource.Models.PolicySetDefinition parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Management.Resource.Models.PolicySetDefinition> CreateOrUpdateAtManagementGroup(string policySetDefinitionName, string managementGroupId, Azure.Management.Resource.Models.PolicySetDefinition parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Management.Resource.Models.PolicySetDefinition>> CreateOrUpdateAtManagementGroupAsync(string policySetDefinitionName, string managementGroupId, Azure.Management.Resource.Models.PolicySetDefinition parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response Delete(string policySetDefinitionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteAsync(string policySetDefinitionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response DeleteAtManagementGroup(string policySetDefinitionName, string managementGroupId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteAtManagementGroupAsync(string policySetDefinitionName, string managementGroupId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Management.Resource.Models.PolicySetDefinition> Get(string policySetDefinitionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Management.Resource.Models.PolicySetDefinition>> GetAsync(string policySetDefinitionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Management.Resource.Models.PolicySetDefinition> GetAtManagementGroup(string policySetDefinitionName, string managementGroupId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Management.Resource.Models.PolicySetDefinition>> GetAtManagementGroupAsync(string policySetDefinitionName, string managementGroupId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Management.Resource.Models.PolicySetDefinition> GetBuiltIn(string policySetDefinitionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Management.Resource.Models.PolicySetDefinition>> GetBuiltInAsync(string policySetDefinitionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.Management.Resource.Models.PolicySetDefinition> List(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.Management.Resource.Models.PolicySetDefinition> ListAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.Management.Resource.Models.PolicySetDefinition> ListBuiltIn(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.Management.Resource.Models.PolicySetDefinition> ListBuiltInAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.Management.Resource.Models.PolicySetDefinition> ListByManagementGroup(string managementGroupId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.Management.Resource.Models.PolicySetDefinition> ListByManagementGroupAsync(string managementGroupId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ProvidersClient
    {
        protected ProvidersClient() { }
        public ProvidersClient(string subscriptionId, Azure.Core.TokenCredential tokenCredential, Azure.Management.Resource.ResourceManagementClientOptions options = null) { }
        public ProvidersClient(string subscriptionId, string host, Azure.Core.TokenCredential tokenCredential, Azure.Management.Resource.ResourceManagementClientOptions options = null) { }
        public virtual Azure.Response<Azure.Management.Resource.Models.Provider> Get(string resourceProviderNamespace, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Management.Resource.Models.Provider>> GetAsync(string resourceProviderNamespace, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Management.Resource.Models.Provider> GetAtTenantScope(string resourceProviderNamespace, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Management.Resource.Models.Provider>> GetAtTenantScopeAsync(string resourceProviderNamespace, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.Management.Resource.Models.Provider> List(int? top = default(int?), string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.Management.Resource.Models.Provider> ListAsync(int? top = default(int?), string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.Management.Resource.Models.Provider> ListAtTenantScope(int? top = default(int?), string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.Management.Resource.Models.Provider> ListAtTenantScopeAsync(int? top = default(int?), string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Management.Resource.Models.Provider> Register(string resourceProviderNamespace, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Management.Resource.Models.Provider>> RegisterAsync(string resourceProviderNamespace, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Management.Resource.Models.Provider> Unregister(string resourceProviderNamespace, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Management.Resource.Models.Provider>> UnregisterAsync(string resourceProviderNamespace, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ResourceGroupsClient
    {
        protected ResourceGroupsClient() { }
        public ResourceGroupsClient(string subscriptionId, Azure.Core.TokenCredential tokenCredential, Azure.Management.Resource.ResourceManagementClientOptions options = null) { }
        public ResourceGroupsClient(string subscriptionId, string host, Azure.Core.TokenCredential tokenCredential, Azure.Management.Resource.ResourceManagementClientOptions options = null) { }
        public virtual Azure.Response CheckExistence(string resourceGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> CheckExistenceAsync(string resourceGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Management.Resource.Models.ResourceGroup> CreateOrUpdate(string resourceGroupName, Azure.Management.Resource.Models.ResourceGroup parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Management.Resource.Models.ResourceGroup>> CreateOrUpdateAsync(string resourceGroupName, Azure.Management.Resource.Models.ResourceGroup parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Management.Resource.Models.ResourceGroup> Get(string resourceGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Management.Resource.Models.ResourceGroup>> GetAsync(string resourceGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.Management.Resource.Models.ResourceGroup> List(string filter = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.Management.Resource.Models.ResourceGroup> ListAsync(string filter = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Management.Resource.ResourceGroupsDeleteOperation StartDelete(string resourceGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.ValueTask<Azure.Management.Resource.ResourceGroupsDeleteOperation> StartDeleteAsync(string resourceGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Management.Resource.ResourceGroupsExportTemplateOperation StartExportTemplate(string resourceGroupName, Azure.Management.Resource.Models.ExportTemplateRequest parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.ValueTask<Azure.Management.Resource.ResourceGroupsExportTemplateOperation> StartExportTemplateAsync(string resourceGroupName, Azure.Management.Resource.Models.ExportTemplateRequest parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Management.Resource.Models.ResourceGroup> Update(string resourceGroupName, Azure.Management.Resource.Models.ResourceGroupPatchable parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Management.Resource.Models.ResourceGroup>> UpdateAsync(string resourceGroupName, Azure.Management.Resource.Models.ResourceGroupPatchable parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
    public partial class ResourceGroupsExportTemplateOperation : Azure.Operation<Azure.Management.Resource.Models.ResourceGroupExportResult>
    {
        internal ResourceGroupsExportTemplateOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.Management.Resource.Models.ResourceGroupExportResult Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.Management.Resource.Models.ResourceGroupExportResult>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.Management.Resource.Models.ResourceGroupExportResult>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ResourceManagementClient
    {
        protected ResourceManagementClient() { }
        public ResourceManagementClient(string subscriptionId, Azure.Core.TokenCredential tokenCredential, Azure.Management.Resource.ResourceManagementClientOptions options = null) { }
        public ResourceManagementClient(string host, string subscriptionId, Azure.Core.TokenCredential tokenCredential, Azure.Management.Resource.ResourceManagementClientOptions options = null) { }
        public virtual Azure.Management.Resource.DeploymentClient GetDeploymentClient() { throw null; }
        public virtual Azure.Management.Resource.DeploymentsClient GetDeploymentsClient() { throw null; }
        public virtual Azure.Management.Resource.DeploymentScriptsClient GetDeploymentScriptsClient() { throw null; }
        public virtual Azure.Management.Resource.OperationsClient GetOperationsClient() { throw null; }
        public virtual Azure.Management.Resource.PolicyAssignmentsClient GetPolicyAssignmentsClient() { throw null; }
        public virtual Azure.Management.Resource.PolicyDefinitionsClient GetPolicyDefinitionsClient() { throw null; }
        public virtual Azure.Management.Resource.PolicySetDefinitionsClient GetPolicySetDefinitionsClient() { throw null; }
        public virtual Azure.Management.Resource.ProvidersClient GetProvidersClient() { throw null; }
        public virtual Azure.Management.Resource.ResourceGroupsClient GetResourceGroupsClient() { throw null; }
        public virtual Azure.Management.Resource.ResourcesClient GetResourcesClient() { throw null; }
        public virtual Azure.Management.Resource.SubscriptionsClient GetSubscriptionsClient() { throw null; }
        public virtual Azure.Management.Resource.TagsClient GetTagsClient() { throw null; }
        public virtual Azure.Management.Resource.TenantsClient GetTenantsClient() { throw null; }
    }
    public partial class ResourceManagementClientOptions : Azure.Core.ClientOptions
    {
        public ResourceManagementClientOptions() { }
    }
    public partial class ResourcesClient
    {
        protected ResourcesClient() { }
        public ResourcesClient(string subscriptionId, Azure.Core.TokenCredential tokenCredential, Azure.Management.Resource.ResourceManagementClientOptions options = null) { }
        public ResourcesClient(string subscriptionId, string host, Azure.Core.TokenCredential tokenCredential, Azure.Management.Resource.ResourceManagementClientOptions options = null) { }
        public virtual Azure.Response CheckExistence(string resourceGroupName, string resourceProviderNamespace, string parentResourcePath, string resourceType, string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> CheckExistenceAsync(string resourceGroupName, string resourceProviderNamespace, string parentResourcePath, string resourceType, string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response CheckExistenceById(string resourceId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> CheckExistenceByIdAsync(string resourceId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Management.Resource.Models.GenericResource> Get(string resourceGroupName, string resourceProviderNamespace, string parentResourcePath, string resourceType, string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Management.Resource.Models.GenericResource>> GetAsync(string resourceGroupName, string resourceProviderNamespace, string parentResourcePath, string resourceType, string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Management.Resource.Models.GenericResource> GetById(string resourceId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Management.Resource.Models.GenericResource>> GetByIdAsync(string resourceId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.Management.Resource.Models.GenericResourceExpanded> List(string filter = null, string expand = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.Management.Resource.Models.GenericResourceExpanded> ListAsync(string filter = null, string expand = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.Management.Resource.Models.GenericResourceExpanded> ListByResourceGroup(string resourceGroupName, string filter = null, string expand = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.Management.Resource.Models.GenericResourceExpanded> ListByResourceGroupAsync(string resourceGroupName, string filter = null, string expand = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Management.Resource.ResourcesCreateOrUpdateOperation StartCreateOrUpdate(string resourceGroupName, string resourceProviderNamespace, string parentResourcePath, string resourceType, string resourceName, Azure.Management.Resource.Models.GenericResource parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.ValueTask<Azure.Management.Resource.ResourcesCreateOrUpdateOperation> StartCreateOrUpdateAsync(string resourceGroupName, string resourceProviderNamespace, string parentResourcePath, string resourceType, string resourceName, Azure.Management.Resource.Models.GenericResource parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Management.Resource.ResourcesCreateOrUpdateByIdOperation StartCreateOrUpdateById(string resourceId, Azure.Management.Resource.Models.GenericResource parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.ValueTask<Azure.Management.Resource.ResourcesCreateOrUpdateByIdOperation> StartCreateOrUpdateByIdAsync(string resourceId, Azure.Management.Resource.Models.GenericResource parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Management.Resource.ResourcesDeleteOperation StartDelete(string resourceGroupName, string resourceProviderNamespace, string parentResourcePath, string resourceType, string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.ValueTask<Azure.Management.Resource.ResourcesDeleteOperation> StartDeleteAsync(string resourceGroupName, string resourceProviderNamespace, string parentResourcePath, string resourceType, string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Management.Resource.ResourcesDeleteByIdOperation StartDeleteById(string resourceId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.ValueTask<Azure.Management.Resource.ResourcesDeleteByIdOperation> StartDeleteByIdAsync(string resourceId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Management.Resource.ResourcesMoveResourcesOperation StartMoveResources(string sourceResourceGroupName, Azure.Management.Resource.Models.ResourcesMoveInfo parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.ValueTask<Azure.Management.Resource.ResourcesMoveResourcesOperation> StartMoveResourcesAsync(string sourceResourceGroupName, Azure.Management.Resource.Models.ResourcesMoveInfo parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Management.Resource.ResourcesUpdateOperation StartUpdate(string resourceGroupName, string resourceProviderNamespace, string parentResourcePath, string resourceType, string resourceName, Azure.Management.Resource.Models.GenericResource parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.ValueTask<Azure.Management.Resource.ResourcesUpdateOperation> StartUpdateAsync(string resourceGroupName, string resourceProviderNamespace, string parentResourcePath, string resourceType, string resourceName, Azure.Management.Resource.Models.GenericResource parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Management.Resource.ResourcesUpdateByIdOperation StartUpdateById(string resourceId, Azure.Management.Resource.Models.GenericResource parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.ValueTask<Azure.Management.Resource.ResourcesUpdateByIdOperation> StartUpdateByIdAsync(string resourceId, Azure.Management.Resource.Models.GenericResource parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Management.Resource.ResourcesValidateMoveResourcesOperation StartValidateMoveResources(string sourceResourceGroupName, Azure.Management.Resource.Models.ResourcesMoveInfo parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.ValueTask<Azure.Management.Resource.ResourcesValidateMoveResourcesOperation> StartValidateMoveResourcesAsync(string sourceResourceGroupName, Azure.Management.Resource.Models.ResourcesMoveInfo parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ResourcesCreateOrUpdateByIdOperation : Azure.Operation<Azure.Management.Resource.Models.GenericResource>
    {
        internal ResourcesCreateOrUpdateByIdOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.Management.Resource.Models.GenericResource Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.Management.Resource.Models.GenericResource>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.Management.Resource.Models.GenericResource>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ResourcesCreateOrUpdateOperation : Azure.Operation<Azure.Management.Resource.Models.GenericResource>
    {
        internal ResourcesCreateOrUpdateOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.Management.Resource.Models.GenericResource Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.Management.Resource.Models.GenericResource>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.Management.Resource.Models.GenericResource>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
    public partial class ResourcesUpdateByIdOperation : Azure.Operation<Azure.Management.Resource.Models.GenericResource>
    {
        internal ResourcesUpdateByIdOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.Management.Resource.Models.GenericResource Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.Management.Resource.Models.GenericResource>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.Management.Resource.Models.GenericResource>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ResourcesUpdateOperation : Azure.Operation<Azure.Management.Resource.Models.GenericResource>
    {
        internal ResourcesUpdateOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.Management.Resource.Models.GenericResource Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.Management.Resource.Models.GenericResource>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.Management.Resource.Models.GenericResource>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
    public partial class SubscriptionsClient
    {
        protected SubscriptionsClient() { }
        public SubscriptionsClient(Azure.Core.TokenCredential tokenCredential, Azure.Management.Resource.ResourceManagementClientOptions options = null) { }
        public SubscriptionsClient(string host, Azure.Core.TokenCredential tokenCredential, Azure.Management.Resource.ResourceManagementClientOptions options = null) { }
        public virtual Azure.Response<Azure.Management.Resource.Models.Subscription> Get(string subscriptionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Management.Resource.Models.Subscription>> GetAsync(string subscriptionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.Management.Resource.Models.Subscription> List(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.Management.Resource.Models.Subscription> ListAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.Management.Resource.Models.Location> ListLocations(string subscriptionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.Management.Resource.Models.Location> ListLocationsAsync(string subscriptionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class TagsClient
    {
        protected TagsClient() { }
        public TagsClient(string subscriptionId, Azure.Core.TokenCredential tokenCredential, Azure.Management.Resource.ResourceManagementClientOptions options = null) { }
        public TagsClient(string subscriptionId, string host, Azure.Core.TokenCredential tokenCredential, Azure.Management.Resource.ResourceManagementClientOptions options = null) { }
        public virtual Azure.Response<Azure.Management.Resource.Models.TagDetails> CreateOrUpdate(string tagName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Management.Resource.Models.TagDetails>> CreateOrUpdateAsync(string tagName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Management.Resource.Models.TagsResource> CreateOrUpdateAtScope(string scope, Azure.Management.Resource.Models.TagsResource parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Management.Resource.Models.TagsResource>> CreateOrUpdateAtScopeAsync(string scope, Azure.Management.Resource.Models.TagsResource parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Management.Resource.Models.TagValue> CreateOrUpdateValue(string tagName, string tagValue, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Management.Resource.Models.TagValue>> CreateOrUpdateValueAsync(string tagName, string tagValue, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response Delete(string tagName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteAsync(string tagName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response DeleteAtScope(string scope, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteAtScopeAsync(string scope, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response DeleteValue(string tagName, string tagValue, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteValueAsync(string tagName, string tagValue, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Management.Resource.Models.TagsResource> GetAtScope(string scope, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Management.Resource.Models.TagsResource>> GetAtScopeAsync(string scope, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.Management.Resource.Models.TagDetails> List(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.Management.Resource.Models.TagDetails> ListAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Management.Resource.Models.TagsResource> UpdateAtScope(string scope, Azure.Management.Resource.Models.TagsPatchResource parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Management.Resource.Models.TagsResource>> UpdateAtScopeAsync(string scope, Azure.Management.Resource.Models.TagsPatchResource parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class TenantsClient
    {
        protected TenantsClient() { }
        public TenantsClient(Azure.Core.TokenCredential tokenCredential, Azure.Management.Resource.ResourceManagementClientOptions options = null) { }
        public TenantsClient(string host, Azure.Core.TokenCredential tokenCredential, Azure.Management.Resource.ResourceManagementClientOptions options = null) { }
        public virtual Azure.Pageable<Azure.Management.Resource.Models.TenantIdDescription> List(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.Management.Resource.Models.TenantIdDescription> ListAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.Management.Resource.Models
{
    public partial class Alias
    {
        internal Alias() { }
        public string DefaultPath { get { throw null; } }
        public Azure.Management.Resource.Models.AliasPattern DefaultPattern { get { throw null; } }
        public string Name { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Management.Resource.Models.AliasPath> Paths { get { throw null; } }
        public Azure.Management.Resource.Models.AliasType? Type { get { throw null; } }
    }
    public partial class AliasPath
    {
        internal AliasPath() { }
        public System.Collections.Generic.IReadOnlyList<string> ApiVersions { get { throw null; } }
        public string Path { get { throw null; } }
        public Azure.Management.Resource.Models.AliasPattern Pattern { get { throw null; } }
    }
    public partial class AliasPattern
    {
        internal AliasPattern() { }
        public string Phrase { get { throw null; } }
        public Azure.Management.Resource.Models.AliasPatternType? Type { get { throw null; } }
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
    public partial class AzureCliScript : Azure.Management.Resource.Models.DeploymentScript
    {
        public AzureCliScript(Azure.Management.Resource.Models.ManagedServiceIdentity identity, string location, System.TimeSpan retentionInterval, string azCliVersion) : base (default(Azure.Management.Resource.Models.ManagedServiceIdentity), default(string)) { }
        public string Arguments { get { throw null; } set { } }
        public string AzCliVersion { get { throw null; } set { } }
        public Azure.Management.Resource.Models.CleanupOptions? CleanupPreference { get { throw null; } set { } }
        public Azure.Management.Resource.Models.ContainerConfiguration ContainerSettings { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.Management.Resource.Models.EnvironmentVariable> EnvironmentVariables { get { throw null; } set { } }
        public string ForceUpdateTag { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, object> Outputs { get { throw null; } }
        public string PrimaryScriptUri { get { throw null; } set { } }
        public Azure.Management.Resource.Models.ScriptProvisioningState? ProvisioningState { get { throw null; } }
        public System.TimeSpan RetentionInterval { get { throw null; } set { } }
        public string ScriptContent { get { throw null; } set { } }
        public Azure.Management.Resource.Models.ScriptStatus Status { get { throw null; } }
        public Azure.Management.Resource.Models.StorageAccountConfiguration StorageAccountSettings { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> SupportingScriptUris { get { throw null; } set { } }
        public System.TimeSpan? Timeout { get { throw null; } set { } }
    }
    public partial class AzureCliScriptProperties : Azure.Management.Resource.Models.DeploymentScriptPropertiesBase
    {
        public AzureCliScriptProperties(string azCliVersion, System.TimeSpan retentionInterval) { }
        public string Arguments { get { throw null; } set { } }
        public string AzCliVersion { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.Management.Resource.Models.EnvironmentVariable> EnvironmentVariables { get { throw null; } set { } }
        public string ForceUpdateTag { get { throw null; } set { } }
        public string PrimaryScriptUri { get { throw null; } set { } }
        public System.TimeSpan RetentionInterval { get { throw null; } set { } }
        public string ScriptContent { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> SupportingScriptUris { get { throw null; } set { } }
        public System.TimeSpan? Timeout { get { throw null; } set { } }
    }
    public partial class AzurePowerShellScript : Azure.Management.Resource.Models.DeploymentScript
    {
        public AzurePowerShellScript(Azure.Management.Resource.Models.ManagedServiceIdentity identity, string location, System.TimeSpan retentionInterval, string azPowerShellVersion) : base (default(Azure.Management.Resource.Models.ManagedServiceIdentity), default(string)) { }
        public string Arguments { get { throw null; } set { } }
        public string AzPowerShellVersion { get { throw null; } set { } }
        public Azure.Management.Resource.Models.CleanupOptions? CleanupPreference { get { throw null; } set { } }
        public Azure.Management.Resource.Models.ContainerConfiguration ContainerSettings { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.Management.Resource.Models.EnvironmentVariable> EnvironmentVariables { get { throw null; } set { } }
        public string ForceUpdateTag { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, object> Outputs { get { throw null; } }
        public string PrimaryScriptUri { get { throw null; } set { } }
        public Azure.Management.Resource.Models.ScriptProvisioningState? ProvisioningState { get { throw null; } }
        public System.TimeSpan RetentionInterval { get { throw null; } set { } }
        public string ScriptContent { get { throw null; } set { } }
        public Azure.Management.Resource.Models.ScriptStatus Status { get { throw null; } }
        public Azure.Management.Resource.Models.StorageAccountConfiguration StorageAccountSettings { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> SupportingScriptUris { get { throw null; } set { } }
        public System.TimeSpan? Timeout { get { throw null; } set { } }
    }
    public partial class AzurePowerShellScriptProperties : Azure.Management.Resource.Models.DeploymentScriptPropertiesBase
    {
        public AzurePowerShellScriptProperties(string azPowerShellVersion, System.TimeSpan retentionInterval) { }
        public string Arguments { get { throw null; } set { } }
        public string AzPowerShellVersion { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.Management.Resource.Models.EnvironmentVariable> EnvironmentVariables { get { throw null; } set { } }
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
    public readonly partial struct CleanupOptions : System.IEquatable<Azure.Management.Resource.Models.CleanupOptions>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public CleanupOptions(string value) { throw null; }
        public static Azure.Management.Resource.Models.CleanupOptions Always { get { throw null; } }
        public static Azure.Management.Resource.Models.CleanupOptions OnExpiration { get { throw null; } }
        public static Azure.Management.Resource.Models.CleanupOptions OnSuccess { get { throw null; } }
        public bool Equals(Azure.Management.Resource.Models.CleanupOptions other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Management.Resource.Models.CleanupOptions left, Azure.Management.Resource.Models.CleanupOptions right) { throw null; }
        public static implicit operator Azure.Management.Resource.Models.CleanupOptions (string value) { throw null; }
        public static bool operator !=(Azure.Management.Resource.Models.CleanupOptions left, Azure.Management.Resource.Models.CleanupOptions right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class CloudError
    {
        internal CloudError() { }
        public Azure.Management.Resource.Models.ErrorResponse Error { get { throw null; } }
    }
    public partial class ContainerConfiguration
    {
        public ContainerConfiguration() { }
        public string ContainerGroupName { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct CreatedByType : System.IEquatable<Azure.Management.Resource.Models.CreatedByType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public CreatedByType(string value) { throw null; }
        public static Azure.Management.Resource.Models.CreatedByType Application { get { throw null; } }
        public static Azure.Management.Resource.Models.CreatedByType Key { get { throw null; } }
        public static Azure.Management.Resource.Models.CreatedByType ManagedIdentity { get { throw null; } }
        public static Azure.Management.Resource.Models.CreatedByType User { get { throw null; } }
        public bool Equals(Azure.Management.Resource.Models.CreatedByType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Management.Resource.Models.CreatedByType left, Azure.Management.Resource.Models.CreatedByType right) { throw null; }
        public static implicit operator Azure.Management.Resource.Models.CreatedByType (string value) { throw null; }
        public static bool operator !=(Azure.Management.Resource.Models.CreatedByType left, Azure.Management.Resource.Models.CreatedByType right) { throw null; }
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
        public System.Collections.Generic.IReadOnlyList<Azure.Management.Resource.Models.BasicDependency> DependsOn { get { throw null; } }
        public string Id { get { throw null; } }
        public string ResourceName { get { throw null; } }
        public string ResourceType { get { throw null; } }
    }
    public partial class Deployment
    {
        public Deployment(Azure.Management.Resource.Models.DeploymentProperties properties) { }
        public string Location { get { throw null; } set { } }
        public Azure.Management.Resource.Models.DeploymentProperties Properties { get { throw null; } }
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
        public Azure.Management.Resource.Models.DeploymentPropertiesExtended Properties { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, string> Tags { get { throw null; } }
        public string Type { get { throw null; } }
    }
    public partial class DeploymentListResult
    {
        internal DeploymentListResult() { }
        public string NextLink { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Management.Resource.Models.DeploymentExtended> Value { get { throw null; } }
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
        public Azure.Management.Resource.Models.DeploymentOperationProperties Properties { get { throw null; } }
    }
    public partial class DeploymentOperationProperties
    {
        internal DeploymentOperationProperties() { }
        public string Duration { get { throw null; } }
        public Azure.Management.Resource.Models.ProvisioningOperation? ProvisioningOperation { get { throw null; } }
        public string ProvisioningState { get { throw null; } }
        public Azure.Management.Resource.Models.HttpMessage Request { get { throw null; } }
        public Azure.Management.Resource.Models.HttpMessage Response { get { throw null; } }
        public string ServiceRequestId { get { throw null; } }
        public string StatusCode { get { throw null; } }
        public object StatusMessage { get { throw null; } }
        public Azure.Management.Resource.Models.TargetResource TargetResource { get { throw null; } }
        public System.DateTimeOffset? Timestamp { get { throw null; } }
    }
    public partial class DeploymentOperationsListResult
    {
        internal DeploymentOperationsListResult() { }
        public string NextLink { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Management.Resource.Models.DeploymentOperation> Value { get { throw null; } }
    }
    public partial class DeploymentProperties
    {
        public DeploymentProperties(Azure.Management.Resource.Models.DeploymentMode mode) { }
        public Azure.Management.Resource.Models.DebugSetting DebugSetting { get { throw null; } set { } }
        public Azure.Management.Resource.Models.DeploymentMode Mode { get { throw null; } }
        public Azure.Management.Resource.Models.OnErrorDeployment OnErrorDeployment { get { throw null; } set { } }
        public object Parameters { get { throw null; } set { } }
        public Azure.Management.Resource.Models.ParametersLink ParametersLink { get { throw null; } set { } }
        public object Template { get { throw null; } set { } }
        public Azure.Management.Resource.Models.TemplateLink TemplateLink { get { throw null; } set { } }
    }
    public partial class DeploymentPropertiesExtended
    {
        internal DeploymentPropertiesExtended() { }
        public string CorrelationId { get { throw null; } }
        public Azure.Management.Resource.Models.DebugSetting DebugSetting { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Management.Resource.Models.Dependency> Dependencies { get { throw null; } }
        public string Duration { get { throw null; } }
        public Azure.Management.Resource.Models.ErrorResponse Error { get { throw null; } }
        public Azure.Management.Resource.Models.DeploymentMode? Mode { get { throw null; } }
        public Azure.Management.Resource.Models.OnErrorDeploymentExtended OnErrorDeployment { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Management.Resource.Models.ResourceReference> OutputResources { get { throw null; } }
        public object Outputs { get { throw null; } }
        public object Parameters { get { throw null; } }
        public Azure.Management.Resource.Models.ParametersLink ParametersLink { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Management.Resource.Models.Provider> Providers { get { throw null; } }
        public string ProvisioningState { get { throw null; } }
        public string TemplateHash { get { throw null; } }
        public Azure.Management.Resource.Models.TemplateLink TemplateLink { get { throw null; } }
        public System.DateTimeOffset? Timestamp { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Management.Resource.Models.ResourceReference> ValidatedResources { get { throw null; } }
    }
    public partial class DeploymentScript : Azure.Management.Resource.Models.AzureResourceBase
    {
        public DeploymentScript(Azure.Management.Resource.Models.ManagedServiceIdentity identity, string location) { }
        public Azure.Management.Resource.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public string Location { get { throw null; } set { } }
        public Azure.Management.Resource.Models.SystemData SystemData { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } set { } }
    }
    public partial class DeploymentScriptListResult
    {
        internal DeploymentScriptListResult() { }
        public string NextLink { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Management.Resource.Models.DeploymentScript> Value { get { throw null; } }
    }
    public partial class DeploymentScriptPropertiesBase
    {
        public DeploymentScriptPropertiesBase() { }
        public Azure.Management.Resource.Models.CleanupOptions? CleanupPreference { get { throw null; } set { } }
        public Azure.Management.Resource.Models.ContainerConfiguration ContainerSettings { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, object> Outputs { get { throw null; } }
        public Azure.Management.Resource.Models.ScriptProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.Management.Resource.Models.ScriptStatus Status { get { throw null; } }
        public Azure.Management.Resource.Models.StorageAccountConfiguration StorageAccountSettings { get { throw null; } set { } }
    }
    public partial class DeploymentScriptsError
    {
        internal DeploymentScriptsError() { }
        public Azure.Management.Resource.Models.ErrorResponse Error { get { throw null; } }
    }
    public partial class DeploymentScriptUpdateParameter : Azure.Management.Resource.Models.AzureResourceBase
    {
        public DeploymentScriptUpdateParameter() { }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } set { } }
    }
    public partial class DeploymentValidateResult
    {
        internal DeploymentValidateResult() { }
        public Azure.Management.Resource.Models.ErrorResponse Error { get { throw null; } }
        public Azure.Management.Resource.Models.DeploymentPropertiesExtended Properties { get { throw null; } }
    }
    public partial class DeploymentWhatIf
    {
        public DeploymentWhatIf(Azure.Management.Resource.Models.DeploymentWhatIfProperties properties) { }
        public string Location { get { throw null; } set { } }
        public Azure.Management.Resource.Models.DeploymentWhatIfProperties Properties { get { throw null; } }
    }
    public partial class DeploymentWhatIfProperties : Azure.Management.Resource.Models.DeploymentProperties
    {
        public DeploymentWhatIfProperties(Azure.Management.Resource.Models.DeploymentMode mode) : base (default(Azure.Management.Resource.Models.DeploymentMode)) { }
        public Azure.Management.Resource.Models.DeploymentWhatIfSettings WhatIfSettings { get { throw null; } set { } }
    }
    public partial class DeploymentWhatIfSettings
    {
        public DeploymentWhatIfSettings() { }
        public Azure.Management.Resource.Models.WhatIfResultFormat? ResultFormat { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct EnforcementMode : System.IEquatable<Azure.Management.Resource.Models.EnforcementMode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public EnforcementMode(string value) { throw null; }
        public static Azure.Management.Resource.Models.EnforcementMode Default { get { throw null; } }
        public static Azure.Management.Resource.Models.EnforcementMode DoNotEnforce { get { throw null; } }
        public bool Equals(Azure.Management.Resource.Models.EnforcementMode other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Management.Resource.Models.EnforcementMode left, Azure.Management.Resource.Models.EnforcementMode right) { throw null; }
        public static implicit operator Azure.Management.Resource.Models.EnforcementMode (string value) { throw null; }
        public static bool operator !=(Azure.Management.Resource.Models.EnforcementMode left, Azure.Management.Resource.Models.EnforcementMode right) { throw null; }
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
        public System.Collections.Generic.IList<Azure.Management.Resource.Models.ErrorAdditionalInfo> AdditionalInfo { get { throw null; } }
        public string Code { get { throw null; } }
        public System.Collections.Generic.IList<Azure.Management.Resource.Models.ErrorResponse> Details { get { throw null; } }
        public string Message { get { throw null; } }
        public string Target { get { throw null; } }
    }
    public partial class ExportTemplateRequest
    {
        public ExportTemplateRequest() { }
        public string Options { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Resources { get { throw null; } set { } }
    }
    public partial class GenericResource : Azure.Management.Resource.Models.Resource
    {
        public GenericResource() { }
        public Azure.Management.Resource.Models.Identity Identity { get { throw null; } set { } }
        public string Kind { get { throw null; } set { } }
        public string ManagedBy { get { throw null; } set { } }
        public Azure.Management.Resource.Models.Plan Plan { get { throw null; } set { } }
        public object Properties { get { throw null; } set { } }
        public Azure.Management.Resource.Models.Sku Sku { get { throw null; } set { } }
    }
    public partial class GenericResourceExpanded : Azure.Management.Resource.Models.GenericResource
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
        public Azure.Management.Resource.Models.ResourceIdentityType? Type { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, Azure.Management.Resource.Models.IdentityUserAssignedIdentitiesValue> UserAssignedIdentities { get { throw null; } set { } }
    }
    public partial class IdentityAutoGenerated
    {
        public IdentityAutoGenerated() { }
        public string PrincipalId { get { throw null; } }
        public string TenantId { get { throw null; } }
        public Azure.Management.Resource.Models.ResourceIdentityType? Type { get { throw null; } set { } }
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
        public Azure.Management.Resource.Models.LocationMetadata Metadata { get { throw null; } }
        public string Name { get { throw null; } }
        public string RegionalDisplayName { get { throw null; } }
        public string SubscriptionId { get { throw null; } }
    }
    public partial class LocationListResult
    {
        internal LocationListResult() { }
        public System.Collections.Generic.IReadOnlyList<Azure.Management.Resource.Models.Location> Value { get { throw null; } }
    }
    public partial class LocationMetadata
    {
        internal LocationMetadata() { }
        public string GeographyGroup { get { throw null; } }
        public string Latitude { get { throw null; } }
        public string Longitude { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Management.Resource.Models.PairedRegion> PairedRegion { get { throw null; } }
        public string PhysicalLocation { get { throw null; } }
        public Azure.Management.Resource.Models.RegionCategory? RegionCategory { get { throw null; } }
        public Azure.Management.Resource.Models.RegionType? RegionType { get { throw null; } }
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
        public System.Collections.Generic.IDictionary<string, Azure.Management.Resource.Models.UserAssignedIdentity> UserAssignedIdentities { get { throw null; } set { } }
    }
    public partial class OnErrorDeployment
    {
        public OnErrorDeployment() { }
        public string DeploymentName { get { throw null; } set { } }
        public Azure.Management.Resource.Models.OnErrorDeploymentType? Type { get { throw null; } set { } }
    }
    public partial class OnErrorDeploymentExtended
    {
        internal OnErrorDeploymentExtended() { }
        public string DeploymentName { get { throw null; } }
        public string ProvisioningState { get { throw null; } }
        public Azure.Management.Resource.Models.OnErrorDeploymentType? Type { get { throw null; } }
    }
    public enum OnErrorDeploymentType
    {
        LastSuccessful = 0,
        SpecificDeployment = 1,
    }
    public partial class Operation
    {
        internal Operation() { }
        public Azure.Management.Resource.Models.OperationDisplay Display { get { throw null; } }
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
    public partial class OperationListResult
    {
        internal OperationListResult() { }
        public string NextLink { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Management.Resource.Models.Operation> Value { get { throw null; } }
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
        public Azure.Management.Resource.Models.ParameterDefinitionsValueMetadata Metadata { get { throw null; } set { } }
        public Azure.Management.Resource.Models.ParameterType? Type { get { throw null; } set { } }
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
    public readonly partial struct ParameterType : System.IEquatable<Azure.Management.Resource.Models.ParameterType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ParameterType(string value) { throw null; }
        public static Azure.Management.Resource.Models.ParameterType Array { get { throw null; } }
        public static Azure.Management.Resource.Models.ParameterType Boolean { get { throw null; } }
        public static Azure.Management.Resource.Models.ParameterType DateTime { get { throw null; } }
        public static Azure.Management.Resource.Models.ParameterType Float { get { throw null; } }
        public static Azure.Management.Resource.Models.ParameterType Integer { get { throw null; } }
        public static Azure.Management.Resource.Models.ParameterType Object { get { throw null; } }
        public static Azure.Management.Resource.Models.ParameterType String { get { throw null; } }
        public bool Equals(Azure.Management.Resource.Models.ParameterType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Management.Resource.Models.ParameterType left, Azure.Management.Resource.Models.ParameterType right) { throw null; }
        public static implicit operator Azure.Management.Resource.Models.ParameterType (string value) { throw null; }
        public static bool operator !=(Azure.Management.Resource.Models.ParameterType left, Azure.Management.Resource.Models.ParameterType right) { throw null; }
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
    public partial class PolicyAssignment
    {
        public PolicyAssignment() { }
        public string Description { get { throw null; } set { } }
        public string DisplayName { get { throw null; } set { } }
        public Azure.Management.Resource.Models.EnforcementMode? EnforcementMode { get { throw null; } set { } }
        public string Id { get { throw null; } }
        public Azure.Management.Resource.Models.IdentityAutoGenerated Identity { get { throw null; } set { } }
        public string Location { get { throw null; } set { } }
        public object Metadata { get { throw null; } set { } }
        public string Name { get { throw null; } }
        public System.Collections.Generic.IList<string> NotScopes { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, Azure.Management.Resource.Models.ParameterValuesValue> Parameters { get { throw null; } set { } }
        public string PolicyDefinitionId { get { throw null; } set { } }
        public string Scope { get { throw null; } set { } }
        public Azure.Management.Resource.Models.PolicySku Sku { get { throw null; } set { } }
        public string Type { get { throw null; } }
    }
    public partial class PolicyAssignmentListResult
    {
        internal PolicyAssignmentListResult() { }
        public string NextLink { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Management.Resource.Models.PolicyAssignment> Value { get { throw null; } }
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
        public System.Collections.Generic.IDictionary<string, Azure.Management.Resource.Models.ParameterDefinitionsValue> Parameters { get { throw null; } set { } }
        public object PolicyRule { get { throw null; } set { } }
        public Azure.Management.Resource.Models.PolicyType? PolicyType { get { throw null; } set { } }
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
        public System.Collections.Generic.IReadOnlyList<Azure.Management.Resource.Models.PolicyDefinition> Value { get { throw null; } }
    }
    public partial class PolicyDefinitionReference
    {
        public PolicyDefinitionReference(string policyDefinitionId) { }
        public System.Collections.Generic.IList<string> GroupNames { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, Azure.Management.Resource.Models.ParameterValuesValue> Parameters { get { throw null; } set { } }
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
        public System.Collections.Generic.IDictionary<string, Azure.Management.Resource.Models.ParameterDefinitionsValue> Parameters { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.Management.Resource.Models.PolicyDefinitionGroup> PolicyDefinitionGroups { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.Management.Resource.Models.PolicyDefinitionReference> PolicyDefinitions { get { throw null; } set { } }
        public Azure.Management.Resource.Models.PolicyType? PolicyType { get { throw null; } set { } }
        public string Type { get { throw null; } }
    }
    public partial class PolicySetDefinitionListResult
    {
        internal PolicySetDefinitionListResult() { }
        public string NextLink { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Management.Resource.Models.PolicySetDefinition> Value { get { throw null; } }
    }
    public partial class PolicySku
    {
        public PolicySku(string name) { }
        public string Name { get { throw null; } set { } }
        public string Tier { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PolicyType : System.IEquatable<Azure.Management.Resource.Models.PolicyType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PolicyType(string value) { throw null; }
        public static Azure.Management.Resource.Models.PolicyType BuiltIn { get { throw null; } }
        public static Azure.Management.Resource.Models.PolicyType Custom { get { throw null; } }
        public static Azure.Management.Resource.Models.PolicyType NotSpecified { get { throw null; } }
        public static Azure.Management.Resource.Models.PolicyType Static { get { throw null; } }
        public bool Equals(Azure.Management.Resource.Models.PolicyType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Management.Resource.Models.PolicyType left, Azure.Management.Resource.Models.PolicyType right) { throw null; }
        public static implicit operator Azure.Management.Resource.Models.PolicyType (string value) { throw null; }
        public static bool operator !=(Azure.Management.Resource.Models.PolicyType left, Azure.Management.Resource.Models.PolicyType right) { throw null; }
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
        public System.Collections.Generic.IReadOnlyList<Azure.Management.Resource.Models.ProviderResourceType> ResourceTypes { get { throw null; } }
    }
    public partial class ProviderListResult
    {
        internal ProviderListResult() { }
        public string NextLink { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Management.Resource.Models.Provider> Value { get { throw null; } }
    }
    public partial class ProviderResourceType
    {
        internal ProviderResourceType() { }
        public System.Collections.Generic.IReadOnlyList<Azure.Management.Resource.Models.Alias> Aliases { get { throw null; } }
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
    public readonly partial struct RegionCategory : System.IEquatable<Azure.Management.Resource.Models.RegionCategory>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RegionCategory(string value) { throw null; }
        public static Azure.Management.Resource.Models.RegionCategory Other { get { throw null; } }
        public static Azure.Management.Resource.Models.RegionCategory Recommended { get { throw null; } }
        public bool Equals(Azure.Management.Resource.Models.RegionCategory other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Management.Resource.Models.RegionCategory left, Azure.Management.Resource.Models.RegionCategory right) { throw null; }
        public static implicit operator Azure.Management.Resource.Models.RegionCategory (string value) { throw null; }
        public static bool operator !=(Azure.Management.Resource.Models.RegionCategory left, Azure.Management.Resource.Models.RegionCategory right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RegionType : System.IEquatable<Azure.Management.Resource.Models.RegionType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RegionType(string value) { throw null; }
        public static Azure.Management.Resource.Models.RegionType Logical { get { throw null; } }
        public static Azure.Management.Resource.Models.RegionType Physical { get { throw null; } }
        public bool Equals(Azure.Management.Resource.Models.RegionType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Management.Resource.Models.RegionType left, Azure.Management.Resource.Models.RegionType right) { throw null; }
        public static implicit operator Azure.Management.Resource.Models.RegionType (string value) { throw null; }
        public static bool operator !=(Azure.Management.Resource.Models.RegionType left, Azure.Management.Resource.Models.RegionType right) { throw null; }
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
        public Azure.Management.Resource.Models.ResourceGroupProperties Properties { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } set { } }
        public string Type { get { throw null; } }
    }
    public partial class ResourceGroupExportResult
    {
        internal ResourceGroupExportResult() { }
        public Azure.Management.Resource.Models.ErrorResponse Error { get { throw null; } }
        public object Template { get { throw null; } }
    }
    public partial class ResourceGroupListResult
    {
        internal ResourceGroupListResult() { }
        public string NextLink { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Management.Resource.Models.ResourceGroup> Value { get { throw null; } }
    }
    public partial class ResourceGroupPatchable
    {
        public ResourceGroupPatchable() { }
        public string ManagedBy { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public Azure.Management.Resource.Models.ResourceGroupProperties Properties { get { throw null; } set { } }
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
    }
    public partial class ResourceListResult
    {
        internal ResourceListResult() { }
        public string NextLink { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Management.Resource.Models.GenericResourceExpanded> Value { get { throw null; } }
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
        public ScopedDeployment(string location, Azure.Management.Resource.Models.DeploymentProperties properties) { }
        public string Location { get { throw null; } }
        public Azure.Management.Resource.Models.DeploymentProperties Properties { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } set { } }
    }
    public partial class ScriptConfigurationBase
    {
        public ScriptConfigurationBase(System.TimeSpan retentionInterval) { }
        public string Arguments { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.Management.Resource.Models.EnvironmentVariable> EnvironmentVariables { get { throw null; } set { } }
        public string ForceUpdateTag { get { throw null; } set { } }
        public string PrimaryScriptUri { get { throw null; } set { } }
        public System.TimeSpan RetentionInterval { get { throw null; } set { } }
        public string ScriptContent { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> SupportingScriptUris { get { throw null; } set { } }
        public System.TimeSpan? Timeout { get { throw null; } set { } }
    }
    public partial class ScriptLog : Azure.Management.Resource.Models.AzureResourceBase
    {
        public ScriptLog() { }
        public string Log { get { throw null; } }
    }
    public partial class ScriptLogsList
    {
        internal ScriptLogsList() { }
        public System.Collections.Generic.IReadOnlyList<Azure.Management.Resource.Models.ScriptLog> Value { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ScriptProvisioningState : System.IEquatable<Azure.Management.Resource.Models.ScriptProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ScriptProvisioningState(string value) { throw null; }
        public static Azure.Management.Resource.Models.ScriptProvisioningState Canceled { get { throw null; } }
        public static Azure.Management.Resource.Models.ScriptProvisioningState Creating { get { throw null; } }
        public static Azure.Management.Resource.Models.ScriptProvisioningState Failed { get { throw null; } }
        public static Azure.Management.Resource.Models.ScriptProvisioningState ProvisioningResources { get { throw null; } }
        public static Azure.Management.Resource.Models.ScriptProvisioningState Running { get { throw null; } }
        public static Azure.Management.Resource.Models.ScriptProvisioningState Succeeded { get { throw null; } }
        public bool Equals(Azure.Management.Resource.Models.ScriptProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Management.Resource.Models.ScriptProvisioningState left, Azure.Management.Resource.Models.ScriptProvisioningState right) { throw null; }
        public static implicit operator Azure.Management.Resource.Models.ScriptProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.Management.Resource.Models.ScriptProvisioningState left, Azure.Management.Resource.Models.ScriptProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ScriptStatus
    {
        public ScriptStatus() { }
        public string ContainerInstanceId { get { throw null; } }
        public System.DateTimeOffset? EndTime { get { throw null; } }
        public Azure.Management.Resource.Models.ErrorResponse Error { get { throw null; } set { } }
        public System.DateTimeOffset? ExpirationTime { get { throw null; } }
        public System.DateTimeOffset? StartTime { get { throw null; } }
        public string StorageAccountId { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ScriptType : System.IEquatable<Azure.Management.Resource.Models.ScriptType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ScriptType(string value) { throw null; }
        public static Azure.Management.Resource.Models.ScriptType AzureCLI { get { throw null; } }
        public static Azure.Management.Resource.Models.ScriptType AzurePowerShell { get { throw null; } }
        public bool Equals(Azure.Management.Resource.Models.ScriptType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Management.Resource.Models.ScriptType left, Azure.Management.Resource.Models.ScriptType right) { throw null; }
        public static implicit operator Azure.Management.Resource.Models.ScriptType (string value) { throw null; }
        public static bool operator !=(Azure.Management.Resource.Models.ScriptType left, Azure.Management.Resource.Models.ScriptType right) { throw null; }
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
        public System.Collections.Generic.IReadOnlyList<Azure.Management.Resource.Models.ManagedByTenant> ManagedByTenants { get { throw null; } }
        public Azure.Management.Resource.Models.SubscriptionState? State { get { throw null; } }
        public string SubscriptionId { get { throw null; } }
        public Azure.Management.Resource.Models.SubscriptionPolicies SubscriptionPolicies { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, string> Tags { get { throw null; } }
        public string TenantId { get { throw null; } }
    }
    public partial class SubscriptionListResult
    {
        internal SubscriptionListResult() { }
        public string NextLink { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Management.Resource.Models.Subscription> Value { get { throw null; } }
    }
    public partial class SubscriptionPolicies
    {
        internal SubscriptionPolicies() { }
        public string LocationPlacementId { get { throw null; } }
        public string QuotaId { get { throw null; } }
        public Azure.Management.Resource.Models.SpendingLimit? SpendingLimit { get { throw null; } }
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
        public Azure.Management.Resource.Models.CreatedByType? CreatedByType { get { throw null; } set { } }
        public System.DateTimeOffset? LastModifiedAt { get { throw null; } set { } }
        public string LastModifiedBy { get { throw null; } set { } }
        public Azure.Management.Resource.Models.CreatedByType? LastModifiedByType { get { throw null; } set { } }
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
        public Azure.Management.Resource.Models.TagCount Count { get { throw null; } }
        public string Id { get { throw null; } }
        public string TagName { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Management.Resource.Models.TagValue> Values { get { throw null; } }
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
        public System.Collections.Generic.IReadOnlyList<Azure.Management.Resource.Models.TagDetails> Value { get { throw null; } }
    }
    public partial class TagsPatchResource
    {
        public TagsPatchResource() { }
        public Azure.Management.Resource.Models.TagsPatchResourceOperation? Operation { get { throw null; } set { } }
        public Azure.Management.Resource.Models.Tags Properties { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct TagsPatchResourceOperation : System.IEquatable<Azure.Management.Resource.Models.TagsPatchResourceOperation>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public TagsPatchResourceOperation(string value) { throw null; }
        public static Azure.Management.Resource.Models.TagsPatchResourceOperation Delete { get { throw null; } }
        public static Azure.Management.Resource.Models.TagsPatchResourceOperation Merge { get { throw null; } }
        public static Azure.Management.Resource.Models.TagsPatchResourceOperation Replace { get { throw null; } }
        public bool Equals(Azure.Management.Resource.Models.TagsPatchResourceOperation other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Management.Resource.Models.TagsPatchResourceOperation left, Azure.Management.Resource.Models.TagsPatchResourceOperation right) { throw null; }
        public static implicit operator Azure.Management.Resource.Models.TagsPatchResourceOperation (string value) { throw null; }
        public static bool operator !=(Azure.Management.Resource.Models.TagsPatchResourceOperation left, Azure.Management.Resource.Models.TagsPatchResourceOperation right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class TagsResource
    {
        public TagsResource(Azure.Management.Resource.Models.Tags properties) { }
        public string Id { get { throw null; } }
        public string Name { get { throw null; } }
        public Azure.Management.Resource.Models.Tags Properties { get { throw null; } set { } }
        public string Type { get { throw null; } }
    }
    public partial class TagValue
    {
        internal TagValue() { }
        public Azure.Management.Resource.Models.TagCount Count { get { throw null; } }
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
        public Azure.Management.Resource.Models.TenantCategory? TenantCategory { get { throw null; } }
        public string TenantId { get { throw null; } }
    }
    public partial class TenantListResult
    {
        internal TenantListResult() { }
        public string NextLink { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Management.Resource.Models.TenantIdDescription> Value { get { throw null; } }
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
        public Azure.Management.Resource.Models.ChangeType ChangeType { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Management.Resource.Models.WhatIfPropertyChange> Delta { get { throw null; } }
        public string ResourceId { get { throw null; } }
    }
    public partial class WhatIfOperationResult
    {
        internal WhatIfOperationResult() { }
        public System.Collections.Generic.IReadOnlyList<Azure.Management.Resource.Models.WhatIfChange> Changes { get { throw null; } }
        public Azure.Management.Resource.Models.ErrorResponse Error { get { throw null; } }
        public string Status { get { throw null; } }
    }
    public partial class WhatIfPropertyChange
    {
        internal WhatIfPropertyChange() { }
        public object After { get { throw null; } }
        public object Before { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Management.Resource.Models.WhatIfPropertyChange> Children { get { throw null; } }
        public string Path { get { throw null; } }
        public Azure.Management.Resource.Models.PropertyChangeType PropertyChangeType { get { throw null; } }
    }
    public enum WhatIfResultFormat
    {
        ResourceIdOnly = 0,
        FullResourcePayloads = 1,
    }
}
