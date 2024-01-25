namespace Azure.ResourceManager.Authorization
{
    public static partial class AuthorizationExtensions
    {
        public static Azure.Response ElevateAccessGlobalAdministrator(this Azure.ResourceManager.Resources.TenantResource tenantResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response> ElevateAccessGlobalAdministratorAsync(this Azure.ResourceManager.Resources.TenantResource tenantResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Authorization.AuthorizationProviderOperationsMetadataCollection GetAllAuthorizationProviderOperationsMetadata(this Azure.ResourceManager.Resources.TenantResource tenantResource) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Authorization.AuthorizationProviderOperationsMetadataResource> GetAuthorizationProviderOperationsMetadata(this Azure.ResourceManager.Resources.TenantResource tenantResource, string resourceProviderNamespace, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Authorization.AuthorizationProviderOperationsMetadataResource>> GetAuthorizationProviderOperationsMetadataAsync(this Azure.ResourceManager.Resources.TenantResource tenantResource, string resourceProviderNamespace, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Authorization.AuthorizationProviderOperationsMetadataResource GetAuthorizationProviderOperationsMetadataResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Authorization.AuthorizationRoleDefinitionResource> GetAuthorizationRoleDefinition(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, Azure.Core.ResourceIdentifier roleDefinitionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Authorization.AuthorizationRoleDefinitionResource> GetAuthorizationRoleDefinition(this Azure.ResourceManager.ArmResource armResource, Azure.Core.ResourceIdentifier roleDefinitionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Authorization.AuthorizationRoleDefinitionResource>> GetAuthorizationRoleDefinitionAsync(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, Azure.Core.ResourceIdentifier roleDefinitionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Authorization.AuthorizationRoleDefinitionResource>> GetAuthorizationRoleDefinitionAsync(this Azure.ResourceManager.ArmResource armResource, Azure.Core.ResourceIdentifier roleDefinitionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Authorization.AuthorizationRoleDefinitionResource GetAuthorizationRoleDefinitionResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Authorization.AuthorizationRoleDefinitionCollection GetAuthorizationRoleDefinitions(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope) { throw null; }
        public static Azure.ResourceManager.Authorization.AuthorizationRoleDefinitionCollection GetAuthorizationRoleDefinitions(this Azure.ResourceManager.ArmResource armResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Authorization.Models.RoleDefinitionPermission> GetAzurePermissionsForResourceGroups(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Authorization.Models.RoleDefinitionPermission> GetAzurePermissionsForResourceGroupsAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Authorization.Models.RoleDefinitionPermission> GetAzurePermissionsForResources(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string resourceProviderNamespace, string parentResourcePath, string resourceType, string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Authorization.Models.RoleDefinitionPermission> GetAzurePermissionsForResourcesAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string resourceProviderNamespace, string parentResourcePath, string resourceType, string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Authorization.Models.AuthorizationClassicAdministrator> GetClassicAdministrators(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Authorization.Models.AuthorizationClassicAdministrator> GetClassicAdministratorsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Authorization.DenyAssignmentResource> GetDenyAssignment(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, string denyAssignmentId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Authorization.DenyAssignmentResource> GetDenyAssignment(this Azure.ResourceManager.ArmResource armResource, string denyAssignmentId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Authorization.DenyAssignmentResource>> GetDenyAssignmentAsync(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, string denyAssignmentId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Authorization.DenyAssignmentResource>> GetDenyAssignmentAsync(this Azure.ResourceManager.ArmResource armResource, string denyAssignmentId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Authorization.DenyAssignmentResource GetDenyAssignmentResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Authorization.DenyAssignmentCollection GetDenyAssignments(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope) { throw null; }
        public static Azure.ResourceManager.Authorization.DenyAssignmentCollection GetDenyAssignments(this Azure.ResourceManager.ArmResource armResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Authorization.Models.EligibleChildResource> GetEligibleChildResources(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Authorization.Models.EligibleChildResource> GetEligibleChildResourcesAsync(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Authorization.RoleAssignmentResource> GetRoleAssignment(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, string roleAssignmentName, string tenantId = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Authorization.RoleAssignmentResource> GetRoleAssignment(this Azure.ResourceManager.ArmResource armResource, string roleAssignmentName, string tenantId = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Authorization.RoleAssignmentResource>> GetRoleAssignmentAsync(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, string roleAssignmentName, string tenantId = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Authorization.RoleAssignmentResource>> GetRoleAssignmentAsync(this Azure.ResourceManager.ArmResource armResource, string roleAssignmentName, string tenantId = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Authorization.RoleAssignmentResource GetRoleAssignmentResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Authorization.RoleAssignmentCollection GetRoleAssignments(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope) { throw null; }
        public static Azure.ResourceManager.Authorization.RoleAssignmentCollection GetRoleAssignments(this Azure.ResourceManager.ArmResource armResource) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Authorization.RoleAssignmentScheduleResource> GetRoleAssignmentSchedule(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, string roleAssignmentScheduleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Authorization.RoleAssignmentScheduleResource> GetRoleAssignmentSchedule(this Azure.ResourceManager.ArmResource armResource, string roleAssignmentScheduleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Authorization.RoleAssignmentScheduleResource>> GetRoleAssignmentScheduleAsync(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, string roleAssignmentScheduleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Authorization.RoleAssignmentScheduleResource>> GetRoleAssignmentScheduleAsync(this Azure.ResourceManager.ArmResource armResource, string roleAssignmentScheduleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Authorization.RoleAssignmentScheduleInstanceResource> GetRoleAssignmentScheduleInstance(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, string roleAssignmentScheduleInstanceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Authorization.RoleAssignmentScheduleInstanceResource> GetRoleAssignmentScheduleInstance(this Azure.ResourceManager.ArmResource armResource, string roleAssignmentScheduleInstanceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Authorization.RoleAssignmentScheduleInstanceResource>> GetRoleAssignmentScheduleInstanceAsync(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, string roleAssignmentScheduleInstanceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Authorization.RoleAssignmentScheduleInstanceResource>> GetRoleAssignmentScheduleInstanceAsync(this Azure.ResourceManager.ArmResource armResource, string roleAssignmentScheduleInstanceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Authorization.RoleAssignmentScheduleInstanceResource GetRoleAssignmentScheduleInstanceResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Authorization.RoleAssignmentScheduleInstanceCollection GetRoleAssignmentScheduleInstances(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope) { throw null; }
        public static Azure.ResourceManager.Authorization.RoleAssignmentScheduleInstanceCollection GetRoleAssignmentScheduleInstances(this Azure.ResourceManager.ArmResource armResource) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Authorization.RoleAssignmentScheduleRequestResource> GetRoleAssignmentScheduleRequest(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, string roleAssignmentScheduleRequestName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Authorization.RoleAssignmentScheduleRequestResource> GetRoleAssignmentScheduleRequest(this Azure.ResourceManager.ArmResource armResource, string roleAssignmentScheduleRequestName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Authorization.RoleAssignmentScheduleRequestResource>> GetRoleAssignmentScheduleRequestAsync(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, string roleAssignmentScheduleRequestName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Authorization.RoleAssignmentScheduleRequestResource>> GetRoleAssignmentScheduleRequestAsync(this Azure.ResourceManager.ArmResource armResource, string roleAssignmentScheduleRequestName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Authorization.RoleAssignmentScheduleRequestResource GetRoleAssignmentScheduleRequestResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Authorization.RoleAssignmentScheduleRequestCollection GetRoleAssignmentScheduleRequests(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope) { throw null; }
        public static Azure.ResourceManager.Authorization.RoleAssignmentScheduleRequestCollection GetRoleAssignmentScheduleRequests(this Azure.ResourceManager.ArmResource armResource) { throw null; }
        public static Azure.ResourceManager.Authorization.RoleAssignmentScheduleResource GetRoleAssignmentScheduleResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Authorization.RoleAssignmentScheduleCollection GetRoleAssignmentSchedules(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope) { throw null; }
        public static Azure.ResourceManager.Authorization.RoleAssignmentScheduleCollection GetRoleAssignmentSchedules(this Azure.ResourceManager.ArmResource armResource) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Authorization.RoleEligibilityScheduleResource> GetRoleEligibilitySchedule(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, string roleEligibilityScheduleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Authorization.RoleEligibilityScheduleResource> GetRoleEligibilitySchedule(this Azure.ResourceManager.ArmResource armResource, string roleEligibilityScheduleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Authorization.RoleEligibilityScheduleResource>> GetRoleEligibilityScheduleAsync(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, string roleEligibilityScheduleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Authorization.RoleEligibilityScheduleResource>> GetRoleEligibilityScheduleAsync(this Azure.ResourceManager.ArmResource armResource, string roleEligibilityScheduleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Authorization.RoleEligibilityScheduleInstanceResource> GetRoleEligibilityScheduleInstance(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, string roleEligibilityScheduleInstanceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Authorization.RoleEligibilityScheduleInstanceResource> GetRoleEligibilityScheduleInstance(this Azure.ResourceManager.ArmResource armResource, string roleEligibilityScheduleInstanceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Authorization.RoleEligibilityScheduleInstanceResource>> GetRoleEligibilityScheduleInstanceAsync(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, string roleEligibilityScheduleInstanceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Authorization.RoleEligibilityScheduleInstanceResource>> GetRoleEligibilityScheduleInstanceAsync(this Azure.ResourceManager.ArmResource armResource, string roleEligibilityScheduleInstanceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Authorization.RoleEligibilityScheduleInstanceResource GetRoleEligibilityScheduleInstanceResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Authorization.RoleEligibilityScheduleInstanceCollection GetRoleEligibilityScheduleInstances(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope) { throw null; }
        public static Azure.ResourceManager.Authorization.RoleEligibilityScheduleInstanceCollection GetRoleEligibilityScheduleInstances(this Azure.ResourceManager.ArmResource armResource) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Authorization.RoleEligibilityScheduleRequestResource> GetRoleEligibilityScheduleRequest(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, string roleEligibilityScheduleRequestName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Authorization.RoleEligibilityScheduleRequestResource> GetRoleEligibilityScheduleRequest(this Azure.ResourceManager.ArmResource armResource, string roleEligibilityScheduleRequestName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Authorization.RoleEligibilityScheduleRequestResource>> GetRoleEligibilityScheduleRequestAsync(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, string roleEligibilityScheduleRequestName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Authorization.RoleEligibilityScheduleRequestResource>> GetRoleEligibilityScheduleRequestAsync(this Azure.ResourceManager.ArmResource armResource, string roleEligibilityScheduleRequestName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Authorization.RoleEligibilityScheduleRequestResource GetRoleEligibilityScheduleRequestResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Authorization.RoleEligibilityScheduleRequestCollection GetRoleEligibilityScheduleRequests(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope) { throw null; }
        public static Azure.ResourceManager.Authorization.RoleEligibilityScheduleRequestCollection GetRoleEligibilityScheduleRequests(this Azure.ResourceManager.ArmResource armResource) { throw null; }
        public static Azure.ResourceManager.Authorization.RoleEligibilityScheduleResource GetRoleEligibilityScheduleResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Authorization.RoleEligibilityScheduleCollection GetRoleEligibilitySchedules(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope) { throw null; }
        public static Azure.ResourceManager.Authorization.RoleEligibilityScheduleCollection GetRoleEligibilitySchedules(this Azure.ResourceManager.ArmResource armResource) { throw null; }
        public static Azure.ResourceManager.Authorization.RoleManagementPolicyCollection GetRoleManagementPolicies(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope) { throw null; }
        public static Azure.ResourceManager.Authorization.RoleManagementPolicyCollection GetRoleManagementPolicies(this Azure.ResourceManager.ArmResource armResource) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Authorization.RoleManagementPolicyResource> GetRoleManagementPolicy(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, string roleManagementPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Authorization.RoleManagementPolicyResource> GetRoleManagementPolicy(this Azure.ResourceManager.ArmResource armResource, string roleManagementPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Authorization.RoleManagementPolicyAssignmentResource> GetRoleManagementPolicyAssignment(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, string roleManagementPolicyAssignmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Authorization.RoleManagementPolicyAssignmentResource> GetRoleManagementPolicyAssignment(this Azure.ResourceManager.ArmResource armResource, string roleManagementPolicyAssignmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Authorization.RoleManagementPolicyAssignmentResource>> GetRoleManagementPolicyAssignmentAsync(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, string roleManagementPolicyAssignmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Authorization.RoleManagementPolicyAssignmentResource>> GetRoleManagementPolicyAssignmentAsync(this Azure.ResourceManager.ArmResource armResource, string roleManagementPolicyAssignmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Authorization.RoleManagementPolicyAssignmentResource GetRoleManagementPolicyAssignmentResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Authorization.RoleManagementPolicyAssignmentCollection GetRoleManagementPolicyAssignments(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope) { throw null; }
        public static Azure.ResourceManager.Authorization.RoleManagementPolicyAssignmentCollection GetRoleManagementPolicyAssignments(this Azure.ResourceManager.ArmResource armResource) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Authorization.RoleManagementPolicyResource>> GetRoleManagementPolicyAsync(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, string roleManagementPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Authorization.RoleManagementPolicyResource>> GetRoleManagementPolicyAsync(this Azure.ResourceManager.ArmResource armResource, string roleManagementPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Authorization.RoleManagementPolicyResource GetRoleManagementPolicyResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class AuthorizationProviderOperationsMetadataCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Authorization.AuthorizationProviderOperationsMetadataResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Authorization.AuthorizationProviderOperationsMetadataResource>, System.Collections.IEnumerable
    {
        protected AuthorizationProviderOperationsMetadataCollection() { }
        public virtual Azure.Response<bool> Exists(string resourceProviderNamespace, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string resourceProviderNamespace, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Authorization.AuthorizationProviderOperationsMetadataResource> Get(string resourceProviderNamespace, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Authorization.AuthorizationProviderOperationsMetadataResource> GetAll(string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Authorization.AuthorizationProviderOperationsMetadataResource> GetAllAsync(string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Authorization.AuthorizationProviderOperationsMetadataResource>> GetAsync(string resourceProviderNamespace, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Authorization.AuthorizationProviderOperationsMetadataResource> GetIfExists(string resourceProviderNamespace, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Authorization.AuthorizationProviderOperationsMetadataResource>> GetIfExistsAsync(string resourceProviderNamespace, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Authorization.AuthorizationProviderOperationsMetadataResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Authorization.AuthorizationProviderOperationsMetadataResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Authorization.AuthorizationProviderOperationsMetadataResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Authorization.AuthorizationProviderOperationsMetadataResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class AuthorizationProviderOperationsMetadataData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Authorization.AuthorizationProviderOperationsMetadataData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.AuthorizationProviderOperationsMetadataData>
    {
        internal AuthorizationProviderOperationsMetadataData() { }
        public string DisplayName { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Authorization.Models.AuthorizationProviderOperationInfo> Operations { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Authorization.Models.AuthorizationProviderResourceType> ResourceTypes { get { throw null; } }
        Azure.ResourceManager.Authorization.AuthorizationProviderOperationsMetadataData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Authorization.AuthorizationProviderOperationsMetadataData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Authorization.AuthorizationProviderOperationsMetadataData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Authorization.AuthorizationProviderOperationsMetadataData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.AuthorizationProviderOperationsMetadataData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.AuthorizationProviderOperationsMetadataData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.AuthorizationProviderOperationsMetadataData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AuthorizationProviderOperationsMetadataResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected AuthorizationProviderOperationsMetadataResource() { }
        public virtual Azure.ResourceManager.Authorization.AuthorizationProviderOperationsMetadataData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string resourceProviderNamespace) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Authorization.AuthorizationProviderOperationsMetadataResource> Get(string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Authorization.AuthorizationProviderOperationsMetadataResource>> GetAsync(string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class AuthorizationRoleDefinitionCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Authorization.AuthorizationRoleDefinitionResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Authorization.AuthorizationRoleDefinitionResource>, System.Collections.IEnumerable
    {
        protected AuthorizationRoleDefinitionCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Authorization.AuthorizationRoleDefinitionResource> CreateOrUpdate(Azure.WaitUntil waitUntil, Azure.Core.ResourceIdentifier roleDefinitionId, Azure.ResourceManager.Authorization.AuthorizationRoleDefinitionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Authorization.AuthorizationRoleDefinitionResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, Azure.Core.ResourceIdentifier roleDefinitionId, Azure.ResourceManager.Authorization.AuthorizationRoleDefinitionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(Azure.Core.ResourceIdentifier roleDefinitionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(Azure.Core.ResourceIdentifier roleDefinitionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Authorization.AuthorizationRoleDefinitionResource> Get(Azure.Core.ResourceIdentifier roleDefinitionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Authorization.AuthorizationRoleDefinitionResource> GetAll(string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Authorization.AuthorizationRoleDefinitionResource> GetAllAsync(string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Authorization.AuthorizationRoleDefinitionResource>> GetAsync(Azure.Core.ResourceIdentifier roleDefinitionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Authorization.AuthorizationRoleDefinitionResource> GetIfExists(Azure.Core.ResourceIdentifier roleDefinitionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Authorization.AuthorizationRoleDefinitionResource>> GetIfExistsAsync(Azure.Core.ResourceIdentifier roleDefinitionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Authorization.AuthorizationRoleDefinitionResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Authorization.AuthorizationRoleDefinitionResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Authorization.AuthorizationRoleDefinitionResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Authorization.AuthorizationRoleDefinitionResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class AuthorizationRoleDefinitionData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Authorization.AuthorizationRoleDefinitionData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.AuthorizationRoleDefinitionData>
    {
        public AuthorizationRoleDefinitionData() { }
        public System.Collections.Generic.IList<string> AssignableScopes { get { throw null; } }
        public string Description { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Authorization.Models.RoleDefinitionPermission> Permissions { get { throw null; } }
        public string RoleName { get { throw null; } set { } }
        public Azure.ResourceManager.Authorization.Models.AuthorizationRoleType? RoleType { get { throw null; } set { } }
        Azure.ResourceManager.Authorization.AuthorizationRoleDefinitionData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Authorization.AuthorizationRoleDefinitionData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Authorization.AuthorizationRoleDefinitionData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Authorization.AuthorizationRoleDefinitionData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.AuthorizationRoleDefinitionData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.AuthorizationRoleDefinitionData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.AuthorizationRoleDefinitionData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AuthorizationRoleDefinitionResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected AuthorizationRoleDefinitionResource() { }
        public virtual Azure.ResourceManager.Authorization.AuthorizationRoleDefinitionData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string scope, Azure.Core.ResourceIdentifier roleDefinitionId) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Authorization.AuthorizationRoleDefinitionResource> Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Authorization.AuthorizationRoleDefinitionResource>> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Authorization.AuthorizationRoleDefinitionResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Authorization.AuthorizationRoleDefinitionResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Authorization.AuthorizationRoleDefinitionResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Authorization.AuthorizationRoleDefinitionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Authorization.AuthorizationRoleDefinitionResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Authorization.AuthorizationRoleDefinitionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DenyAssignmentCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Authorization.DenyAssignmentResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Authorization.DenyAssignmentResource>, System.Collections.IEnumerable
    {
        protected DenyAssignmentCollection() { }
        public virtual Azure.Response<bool> Exists(string denyAssignmentId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string denyAssignmentId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Authorization.DenyAssignmentResource> Get(string denyAssignmentId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Authorization.DenyAssignmentResource> GetAll(string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Authorization.DenyAssignmentResource> GetAllAsync(string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Authorization.DenyAssignmentResource>> GetAsync(string denyAssignmentId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Authorization.DenyAssignmentResource> GetIfExists(string denyAssignmentId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Authorization.DenyAssignmentResource>> GetIfExistsAsync(string denyAssignmentId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Authorization.DenyAssignmentResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Authorization.DenyAssignmentResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Authorization.DenyAssignmentResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Authorization.DenyAssignmentResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class DenyAssignmentData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Authorization.DenyAssignmentData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.DenyAssignmentData>
    {
        internal DenyAssignmentData() { }
        public string DenyAssignmentName { get { throw null; } }
        public string Description { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Authorization.Models.RoleManagementPrincipal> ExcludePrincipals { get { throw null; } }
        public bool? IsAppliedToChildScopes { get { throw null; } }
        public bool? IsSystemProtected { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Authorization.Models.DenyAssignmentPermission> Permissions { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Authorization.Models.RoleManagementPrincipal> Principals { get { throw null; } }
        public string Scope { get { throw null; } }
        Azure.ResourceManager.Authorization.DenyAssignmentData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Authorization.DenyAssignmentData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Authorization.DenyAssignmentData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Authorization.DenyAssignmentData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.DenyAssignmentData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.DenyAssignmentData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.DenyAssignmentData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DenyAssignmentResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected DenyAssignmentResource() { }
        public virtual Azure.ResourceManager.Authorization.DenyAssignmentData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string scope, string denyAssignmentId) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Authorization.DenyAssignmentResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Authorization.DenyAssignmentResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class RoleAssignmentCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Authorization.RoleAssignmentResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Authorization.RoleAssignmentResource>, System.Collections.IEnumerable
    {
        protected RoleAssignmentCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Authorization.RoleAssignmentResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string roleAssignmentName, Azure.ResourceManager.Authorization.Models.RoleAssignmentCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Authorization.RoleAssignmentResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string roleAssignmentName, Azure.ResourceManager.Authorization.Models.RoleAssignmentCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string roleAssignmentName, string tenantId = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string roleAssignmentName, string tenantId = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Authorization.RoleAssignmentResource> Get(string roleAssignmentName, string tenantId = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Authorization.RoleAssignmentResource> GetAll(string filter = null, string tenantId = null, string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Authorization.RoleAssignmentResource> GetAllAsync(string filter = null, string tenantId = null, string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Authorization.RoleAssignmentResource>> GetAsync(string roleAssignmentName, string tenantId = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Authorization.RoleAssignmentResource> GetIfExists(string roleAssignmentName, string tenantId = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Authorization.RoleAssignmentResource>> GetIfExistsAsync(string roleAssignmentName, string tenantId = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Authorization.RoleAssignmentResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Authorization.RoleAssignmentResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Authorization.RoleAssignmentResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Authorization.RoleAssignmentResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class RoleAssignmentData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Authorization.RoleAssignmentData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.RoleAssignmentData>
    {
        internal RoleAssignmentData() { }
        public string Condition { get { throw null; } }
        public string ConditionVersion { get { throw null; } }
        public string CreatedBy { get { throw null; } }
        public System.DateTimeOffset? CreatedOn { get { throw null; } }
        public Azure.Core.ResourceIdentifier DelegatedManagedIdentityResourceId { get { throw null; } }
        public string Description { get { throw null; } }
        public System.Guid? PrincipalId { get { throw null; } }
        public Azure.ResourceManager.Authorization.Models.RoleManagementPrincipalType? PrincipalType { get { throw null; } }
        public Azure.Core.ResourceIdentifier RoleDefinitionId { get { throw null; } }
        public string Scope { get { throw null; } }
        public string UpdatedBy { get { throw null; } }
        public System.DateTimeOffset? UpdatedOn { get { throw null; } }
        Azure.ResourceManager.Authorization.RoleAssignmentData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Authorization.RoleAssignmentData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Authorization.RoleAssignmentData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Authorization.RoleAssignmentData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.RoleAssignmentData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.RoleAssignmentData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.RoleAssignmentData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RoleAssignmentResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected RoleAssignmentResource() { }
        public virtual Azure.ResourceManager.Authorization.RoleAssignmentData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string scope, string roleAssignmentName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Authorization.RoleAssignmentResource> Delete(Azure.WaitUntil waitUntil, string tenantId = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Authorization.RoleAssignmentResource>> DeleteAsync(Azure.WaitUntil waitUntil, string tenantId = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Authorization.RoleAssignmentResource> Get(string tenantId = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Authorization.RoleAssignmentResource>> GetAsync(string tenantId = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Authorization.RoleAssignmentResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Authorization.Models.RoleAssignmentCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Authorization.RoleAssignmentResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Authorization.Models.RoleAssignmentCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class RoleAssignmentScheduleCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Authorization.RoleAssignmentScheduleResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Authorization.RoleAssignmentScheduleResource>, System.Collections.IEnumerable
    {
        protected RoleAssignmentScheduleCollection() { }
        public virtual Azure.Response<bool> Exists(string roleAssignmentScheduleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string roleAssignmentScheduleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Authorization.RoleAssignmentScheduleResource> Get(string roleAssignmentScheduleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Authorization.RoleAssignmentScheduleResource> GetAll(string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Authorization.RoleAssignmentScheduleResource> GetAllAsync(string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Authorization.RoleAssignmentScheduleResource>> GetAsync(string roleAssignmentScheduleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Authorization.RoleAssignmentScheduleResource> GetIfExists(string roleAssignmentScheduleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Authorization.RoleAssignmentScheduleResource>> GetIfExistsAsync(string roleAssignmentScheduleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Authorization.RoleAssignmentScheduleResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Authorization.RoleAssignmentScheduleResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Authorization.RoleAssignmentScheduleResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Authorization.RoleAssignmentScheduleResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class RoleAssignmentScheduleData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Authorization.RoleAssignmentScheduleData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.RoleAssignmentScheduleData>
    {
        internal RoleAssignmentScheduleData() { }
        public Azure.ResourceManager.Authorization.Models.RoleAssignmentScheduleAssignmentType? AssignmentType { get { throw null; } }
        public string Condition { get { throw null; } }
        public string ConditionVersion { get { throw null; } }
        public System.DateTimeOffset? CreatedOn { get { throw null; } }
        public System.DateTimeOffset? EndOn { get { throw null; } }
        public Azure.ResourceManager.Authorization.Models.RoleManagementExpandedProperties ExpandedProperties { get { throw null; } }
        public Azure.Core.ResourceIdentifier LinkedRoleEligibilityScheduleId { get { throw null; } }
        public Azure.ResourceManager.Authorization.Models.RoleManagementScheduleMemberType? MemberType { get { throw null; } }
        public System.Guid? PrincipalId { get { throw null; } }
        public Azure.ResourceManager.Authorization.Models.RoleManagementPrincipalType? PrincipalType { get { throw null; } }
        public Azure.Core.ResourceIdentifier RoleAssignmentScheduleRequestId { get { throw null; } }
        public Azure.Core.ResourceIdentifier RoleDefinitionId { get { throw null; } }
        public string Scope { get { throw null; } }
        public System.DateTimeOffset? StartOn { get { throw null; } }
        public Azure.ResourceManager.Authorization.Models.RoleManagementScheduleStatus? Status { get { throw null; } }
        public System.DateTimeOffset? UpdatedOn { get { throw null; } }
        Azure.ResourceManager.Authorization.RoleAssignmentScheduleData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Authorization.RoleAssignmentScheduleData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Authorization.RoleAssignmentScheduleData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Authorization.RoleAssignmentScheduleData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.RoleAssignmentScheduleData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.RoleAssignmentScheduleData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.RoleAssignmentScheduleData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RoleAssignmentScheduleInstanceCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Authorization.RoleAssignmentScheduleInstanceResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Authorization.RoleAssignmentScheduleInstanceResource>, System.Collections.IEnumerable
    {
        protected RoleAssignmentScheduleInstanceCollection() { }
        public virtual Azure.Response<bool> Exists(string roleAssignmentScheduleInstanceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string roleAssignmentScheduleInstanceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Authorization.RoleAssignmentScheduleInstanceResource> Get(string roleAssignmentScheduleInstanceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Authorization.RoleAssignmentScheduleInstanceResource> GetAll(string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Authorization.RoleAssignmentScheduleInstanceResource> GetAllAsync(string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Authorization.RoleAssignmentScheduleInstanceResource>> GetAsync(string roleAssignmentScheduleInstanceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Authorization.RoleAssignmentScheduleInstanceResource> GetIfExists(string roleAssignmentScheduleInstanceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Authorization.RoleAssignmentScheduleInstanceResource>> GetIfExistsAsync(string roleAssignmentScheduleInstanceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Authorization.RoleAssignmentScheduleInstanceResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Authorization.RoleAssignmentScheduleInstanceResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Authorization.RoleAssignmentScheduleInstanceResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Authorization.RoleAssignmentScheduleInstanceResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class RoleAssignmentScheduleInstanceData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Authorization.RoleAssignmentScheduleInstanceData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.RoleAssignmentScheduleInstanceData>
    {
        internal RoleAssignmentScheduleInstanceData() { }
        public Azure.ResourceManager.Authorization.Models.RoleAssignmentScheduleAssignmentType? AssignmentType { get { throw null; } }
        public string Condition { get { throw null; } }
        public string ConditionVersion { get { throw null; } }
        public System.DateTimeOffset? CreatedOn { get { throw null; } }
        public System.DateTimeOffset? EndOn { get { throw null; } }
        public Azure.ResourceManager.Authorization.Models.RoleManagementExpandedProperties ExpandedProperties { get { throw null; } }
        public Azure.Core.ResourceIdentifier LinkedRoleEligibilityScheduleId { get { throw null; } }
        public Azure.Core.ResourceIdentifier LinkedRoleEligibilityScheduleInstanceId { get { throw null; } }
        public Azure.ResourceManager.Authorization.Models.RoleManagementScheduleMemberType? MemberType { get { throw null; } }
        public Azure.Core.ResourceIdentifier OriginRoleAssignmentId { get { throw null; } }
        public System.Guid? PrincipalId { get { throw null; } }
        public Azure.ResourceManager.Authorization.Models.RoleManagementPrincipalType? PrincipalType { get { throw null; } }
        public Azure.Core.ResourceIdentifier RoleAssignmentScheduleId { get { throw null; } }
        public Azure.Core.ResourceIdentifier RoleDefinitionId { get { throw null; } }
        public string Scope { get { throw null; } }
        public System.DateTimeOffset? StartOn { get { throw null; } }
        public Azure.ResourceManager.Authorization.Models.RoleManagementScheduleStatus? Status { get { throw null; } }
        Azure.ResourceManager.Authorization.RoleAssignmentScheduleInstanceData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Authorization.RoleAssignmentScheduleInstanceData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Authorization.RoleAssignmentScheduleInstanceData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Authorization.RoleAssignmentScheduleInstanceData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.RoleAssignmentScheduleInstanceData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.RoleAssignmentScheduleInstanceData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.RoleAssignmentScheduleInstanceData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RoleAssignmentScheduleInstanceResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected RoleAssignmentScheduleInstanceResource() { }
        public virtual Azure.ResourceManager.Authorization.RoleAssignmentScheduleInstanceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string scope, string roleAssignmentScheduleInstanceName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Authorization.RoleAssignmentScheduleInstanceResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Authorization.RoleAssignmentScheduleInstanceResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class RoleAssignmentScheduleRequestCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Authorization.RoleAssignmentScheduleRequestResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Authorization.RoleAssignmentScheduleRequestResource>, System.Collections.IEnumerable
    {
        protected RoleAssignmentScheduleRequestCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Authorization.RoleAssignmentScheduleRequestResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string roleAssignmentScheduleRequestName, Azure.ResourceManager.Authorization.RoleAssignmentScheduleRequestData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Authorization.RoleAssignmentScheduleRequestResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string roleAssignmentScheduleRequestName, Azure.ResourceManager.Authorization.RoleAssignmentScheduleRequestData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string roleAssignmentScheduleRequestName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string roleAssignmentScheduleRequestName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Authorization.RoleAssignmentScheduleRequestResource> Get(string roleAssignmentScheduleRequestName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Authorization.RoleAssignmentScheduleRequestResource> GetAll(string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Authorization.RoleAssignmentScheduleRequestResource> GetAllAsync(string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Authorization.RoleAssignmentScheduleRequestResource>> GetAsync(string roleAssignmentScheduleRequestName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Authorization.RoleAssignmentScheduleRequestResource> GetIfExists(string roleAssignmentScheduleRequestName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Authorization.RoleAssignmentScheduleRequestResource>> GetIfExistsAsync(string roleAssignmentScheduleRequestName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Authorization.RoleAssignmentScheduleRequestResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Authorization.RoleAssignmentScheduleRequestResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Authorization.RoleAssignmentScheduleRequestResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Authorization.RoleAssignmentScheduleRequestResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class RoleAssignmentScheduleRequestData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Authorization.RoleAssignmentScheduleRequestData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.RoleAssignmentScheduleRequestData>
    {
        public RoleAssignmentScheduleRequestData() { }
        public string ApprovalId { get { throw null; } }
        public string Condition { get { throw null; } set { } }
        public string ConditionVersion { get { throw null; } set { } }
        public System.DateTimeOffset? CreatedOn { get { throw null; } }
        public System.TimeSpan? Duration { get { throw null; } set { } }
        public System.DateTimeOffset? EndOn { get { throw null; } set { } }
        public Azure.ResourceManager.Authorization.Models.RoleManagementExpandedProperties ExpandedProperties { get { throw null; } }
        public Azure.ResourceManager.Authorization.Models.RoleManagementScheduleExpirationType? ExpirationType { get { throw null; } set { } }
        public string Justification { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier LinkedRoleEligibilityScheduleId { get { throw null; } set { } }
        public System.Guid? PrincipalId { get { throw null; } set { } }
        public Azure.ResourceManager.Authorization.Models.RoleManagementPrincipalType? PrincipalType { get { throw null; } }
        public System.Guid? RequestorId { get { throw null; } }
        public Azure.ResourceManager.Authorization.Models.RoleManagementScheduleRequestType? RequestType { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier RoleDefinitionId { get { throw null; } set { } }
        public string Scope { get { throw null; } }
        public System.DateTimeOffset? StartOn { get { throw null; } set { } }
        public Azure.ResourceManager.Authorization.Models.RoleManagementScheduleStatus? Status { get { throw null; } }
        public Azure.Core.ResourceIdentifier TargetRoleAssignmentScheduleId { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier TargetRoleAssignmentScheduleInstanceId { get { throw null; } set { } }
        public Azure.ResourceManager.Authorization.Models.RoleAssignmentScheduleTicketInfo TicketInfo { get { throw null; } set { } }
        Azure.ResourceManager.Authorization.RoleAssignmentScheduleRequestData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Authorization.RoleAssignmentScheduleRequestData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Authorization.RoleAssignmentScheduleRequestData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Authorization.RoleAssignmentScheduleRequestData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.RoleAssignmentScheduleRequestData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.RoleAssignmentScheduleRequestData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.RoleAssignmentScheduleRequestData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RoleAssignmentScheduleRequestResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected RoleAssignmentScheduleRequestResource() { }
        public virtual Azure.ResourceManager.Authorization.RoleAssignmentScheduleRequestData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response Cancel(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> CancelAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string scope, string roleAssignmentScheduleRequestName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Authorization.RoleAssignmentScheduleRequestResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Authorization.RoleAssignmentScheduleRequestResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Authorization.RoleAssignmentScheduleRequestResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Authorization.RoleAssignmentScheduleRequestData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Authorization.RoleAssignmentScheduleRequestResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Authorization.RoleAssignmentScheduleRequestData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Authorization.RoleAssignmentScheduleRequestResource> Validate(Azure.ResourceManager.Authorization.RoleAssignmentScheduleRequestData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Authorization.RoleAssignmentScheduleRequestResource>> ValidateAsync(Azure.ResourceManager.Authorization.RoleAssignmentScheduleRequestData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class RoleAssignmentScheduleResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected RoleAssignmentScheduleResource() { }
        public virtual Azure.ResourceManager.Authorization.RoleAssignmentScheduleData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string scope, string roleAssignmentScheduleName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Authorization.RoleAssignmentScheduleResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Authorization.RoleAssignmentScheduleResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class RoleEligibilityScheduleCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Authorization.RoleEligibilityScheduleResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Authorization.RoleEligibilityScheduleResource>, System.Collections.IEnumerable
    {
        protected RoleEligibilityScheduleCollection() { }
        public virtual Azure.Response<bool> Exists(string roleEligibilityScheduleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string roleEligibilityScheduleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Authorization.RoleEligibilityScheduleResource> Get(string roleEligibilityScheduleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Authorization.RoleEligibilityScheduleResource> GetAll(string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Authorization.RoleEligibilityScheduleResource> GetAllAsync(string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Authorization.RoleEligibilityScheduleResource>> GetAsync(string roleEligibilityScheduleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Authorization.RoleEligibilityScheduleResource> GetIfExists(string roleEligibilityScheduleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Authorization.RoleEligibilityScheduleResource>> GetIfExistsAsync(string roleEligibilityScheduleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Authorization.RoleEligibilityScheduleResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Authorization.RoleEligibilityScheduleResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Authorization.RoleEligibilityScheduleResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Authorization.RoleEligibilityScheduleResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class RoleEligibilityScheduleData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Authorization.RoleEligibilityScheduleData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.RoleEligibilityScheduleData>
    {
        internal RoleEligibilityScheduleData() { }
        public string Condition { get { throw null; } }
        public string ConditionVersion { get { throw null; } }
        public System.DateTimeOffset? CreatedOn { get { throw null; } }
        public System.DateTimeOffset? EndOn { get { throw null; } }
        public Azure.ResourceManager.Authorization.Models.RoleManagementExpandedProperties ExpandedProperties { get { throw null; } }
        public Azure.ResourceManager.Authorization.Models.RoleManagementScheduleMemberType? MemberType { get { throw null; } }
        public System.Guid? PrincipalId { get { throw null; } }
        public Azure.ResourceManager.Authorization.Models.RoleManagementPrincipalType? PrincipalType { get { throw null; } }
        public Azure.Core.ResourceIdentifier RoleDefinitionId { get { throw null; } }
        public Azure.Core.ResourceIdentifier RoleEligibilityScheduleRequestId { get { throw null; } }
        public string Scope { get { throw null; } }
        public System.DateTimeOffset? StartOn { get { throw null; } }
        public Azure.ResourceManager.Authorization.Models.RoleManagementScheduleStatus? Status { get { throw null; } }
        public System.DateTimeOffset? UpdatedOn { get { throw null; } }
        Azure.ResourceManager.Authorization.RoleEligibilityScheduleData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Authorization.RoleEligibilityScheduleData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Authorization.RoleEligibilityScheduleData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Authorization.RoleEligibilityScheduleData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.RoleEligibilityScheduleData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.RoleEligibilityScheduleData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.RoleEligibilityScheduleData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RoleEligibilityScheduleInstanceCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Authorization.RoleEligibilityScheduleInstanceResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Authorization.RoleEligibilityScheduleInstanceResource>, System.Collections.IEnumerable
    {
        protected RoleEligibilityScheduleInstanceCollection() { }
        public virtual Azure.Response<bool> Exists(string roleEligibilityScheduleInstanceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string roleEligibilityScheduleInstanceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Authorization.RoleEligibilityScheduleInstanceResource> Get(string roleEligibilityScheduleInstanceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Authorization.RoleEligibilityScheduleInstanceResource> GetAll(string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Authorization.RoleEligibilityScheduleInstanceResource> GetAllAsync(string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Authorization.RoleEligibilityScheduleInstanceResource>> GetAsync(string roleEligibilityScheduleInstanceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Authorization.RoleEligibilityScheduleInstanceResource> GetIfExists(string roleEligibilityScheduleInstanceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Authorization.RoleEligibilityScheduleInstanceResource>> GetIfExistsAsync(string roleEligibilityScheduleInstanceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Authorization.RoleEligibilityScheduleInstanceResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Authorization.RoleEligibilityScheduleInstanceResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Authorization.RoleEligibilityScheduleInstanceResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Authorization.RoleEligibilityScheduleInstanceResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class RoleEligibilityScheduleInstanceData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Authorization.RoleEligibilityScheduleInstanceData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.RoleEligibilityScheduleInstanceData>
    {
        internal RoleEligibilityScheduleInstanceData() { }
        public string Condition { get { throw null; } }
        public string ConditionVersion { get { throw null; } }
        public System.DateTimeOffset? CreatedOn { get { throw null; } }
        public System.DateTimeOffset? EndOn { get { throw null; } }
        public Azure.ResourceManager.Authorization.Models.RoleManagementExpandedProperties ExpandedProperties { get { throw null; } }
        public Azure.ResourceManager.Authorization.Models.RoleManagementScheduleMemberType? MemberType { get { throw null; } }
        public System.Guid? PrincipalId { get { throw null; } }
        public Azure.ResourceManager.Authorization.Models.RoleManagementPrincipalType? PrincipalType { get { throw null; } }
        public Azure.Core.ResourceIdentifier RoleDefinitionId { get { throw null; } }
        public Azure.Core.ResourceIdentifier RoleEligibilityScheduleId { get { throw null; } }
        public string Scope { get { throw null; } }
        public System.DateTimeOffset? StartOn { get { throw null; } }
        public Azure.ResourceManager.Authorization.Models.RoleManagementScheduleStatus? Status { get { throw null; } }
        Azure.ResourceManager.Authorization.RoleEligibilityScheduleInstanceData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Authorization.RoleEligibilityScheduleInstanceData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Authorization.RoleEligibilityScheduleInstanceData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Authorization.RoleEligibilityScheduleInstanceData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.RoleEligibilityScheduleInstanceData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.RoleEligibilityScheduleInstanceData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.RoleEligibilityScheduleInstanceData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RoleEligibilityScheduleInstanceResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected RoleEligibilityScheduleInstanceResource() { }
        public virtual Azure.ResourceManager.Authorization.RoleEligibilityScheduleInstanceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string scope, string roleEligibilityScheduleInstanceName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Authorization.RoleEligibilityScheduleInstanceResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Authorization.RoleEligibilityScheduleInstanceResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class RoleEligibilityScheduleRequestCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Authorization.RoleEligibilityScheduleRequestResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Authorization.RoleEligibilityScheduleRequestResource>, System.Collections.IEnumerable
    {
        protected RoleEligibilityScheduleRequestCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Authorization.RoleEligibilityScheduleRequestResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string roleEligibilityScheduleRequestName, Azure.ResourceManager.Authorization.RoleEligibilityScheduleRequestData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Authorization.RoleEligibilityScheduleRequestResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string roleEligibilityScheduleRequestName, Azure.ResourceManager.Authorization.RoleEligibilityScheduleRequestData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string roleEligibilityScheduleRequestName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string roleEligibilityScheduleRequestName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Authorization.RoleEligibilityScheduleRequestResource> Get(string roleEligibilityScheduleRequestName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Authorization.RoleEligibilityScheduleRequestResource> GetAll(string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Authorization.RoleEligibilityScheduleRequestResource> GetAllAsync(string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Authorization.RoleEligibilityScheduleRequestResource>> GetAsync(string roleEligibilityScheduleRequestName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Authorization.RoleEligibilityScheduleRequestResource> GetIfExists(string roleEligibilityScheduleRequestName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Authorization.RoleEligibilityScheduleRequestResource>> GetIfExistsAsync(string roleEligibilityScheduleRequestName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Authorization.RoleEligibilityScheduleRequestResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Authorization.RoleEligibilityScheduleRequestResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Authorization.RoleEligibilityScheduleRequestResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Authorization.RoleEligibilityScheduleRequestResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class RoleEligibilityScheduleRequestData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Authorization.RoleEligibilityScheduleRequestData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.RoleEligibilityScheduleRequestData>
    {
        public RoleEligibilityScheduleRequestData() { }
        public string ApprovalId { get { throw null; } }
        public string Condition { get { throw null; } set { } }
        public string ConditionVersion { get { throw null; } set { } }
        public System.DateTimeOffset? CreatedOn { get { throw null; } }
        public System.TimeSpan? Duration { get { throw null; } set { } }
        public System.DateTimeOffset? EndOn { get { throw null; } set { } }
        public Azure.ResourceManager.Authorization.Models.RoleManagementExpandedProperties ExpandedProperties { get { throw null; } }
        public Azure.ResourceManager.Authorization.Models.RoleManagementScheduleExpirationType? ExpirationType { get { throw null; } set { } }
        public string Justification { get { throw null; } set { } }
        public System.Guid? PrincipalId { get { throw null; } set { } }
        public Azure.ResourceManager.Authorization.Models.RoleManagementPrincipalType? PrincipalType { get { throw null; } }
        public System.Guid? RequestorId { get { throw null; } }
        public Azure.ResourceManager.Authorization.Models.RoleManagementScheduleRequestType? RequestType { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier RoleDefinitionId { get { throw null; } set { } }
        public string Scope { get { throw null; } }
        public System.DateTimeOffset? StartOn { get { throw null; } set { } }
        public Azure.ResourceManager.Authorization.Models.RoleManagementScheduleStatus? Status { get { throw null; } }
        public Azure.Core.ResourceIdentifier TargetRoleEligibilityScheduleId { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier TargetRoleEligibilityScheduleInstanceId { get { throw null; } set { } }
        public Azure.ResourceManager.Authorization.Models.RoleEligibilityScheduleRequestPropertiesTicketInfo TicketInfo { get { throw null; } set { } }
        Azure.ResourceManager.Authorization.RoleEligibilityScheduleRequestData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Authorization.RoleEligibilityScheduleRequestData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Authorization.RoleEligibilityScheduleRequestData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Authorization.RoleEligibilityScheduleRequestData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.RoleEligibilityScheduleRequestData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.RoleEligibilityScheduleRequestData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.RoleEligibilityScheduleRequestData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RoleEligibilityScheduleRequestResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected RoleEligibilityScheduleRequestResource() { }
        public virtual Azure.ResourceManager.Authorization.RoleEligibilityScheduleRequestData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response Cancel(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> CancelAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string scope, string roleEligibilityScheduleRequestName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Authorization.RoleEligibilityScheduleRequestResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Authorization.RoleEligibilityScheduleRequestResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Authorization.RoleEligibilityScheduleRequestResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Authorization.RoleEligibilityScheduleRequestData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Authorization.RoleEligibilityScheduleRequestResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Authorization.RoleEligibilityScheduleRequestData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Authorization.RoleEligibilityScheduleRequestResource> Validate(Azure.ResourceManager.Authorization.RoleEligibilityScheduleRequestData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Authorization.RoleEligibilityScheduleRequestResource>> ValidateAsync(Azure.ResourceManager.Authorization.RoleEligibilityScheduleRequestData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class RoleEligibilityScheduleResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected RoleEligibilityScheduleResource() { }
        public virtual Azure.ResourceManager.Authorization.RoleEligibilityScheduleData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string scope, string roleEligibilityScheduleName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Authorization.RoleEligibilityScheduleResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Authorization.RoleEligibilityScheduleResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class RoleManagementPolicyAssignmentCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Authorization.RoleManagementPolicyAssignmentResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Authorization.RoleManagementPolicyAssignmentResource>, System.Collections.IEnumerable
    {
        protected RoleManagementPolicyAssignmentCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Authorization.RoleManagementPolicyAssignmentResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string roleManagementPolicyAssignmentName, Azure.ResourceManager.Authorization.RoleManagementPolicyAssignmentData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Authorization.RoleManagementPolicyAssignmentResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string roleManagementPolicyAssignmentName, Azure.ResourceManager.Authorization.RoleManagementPolicyAssignmentData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string roleManagementPolicyAssignmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string roleManagementPolicyAssignmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Authorization.RoleManagementPolicyAssignmentResource> Get(string roleManagementPolicyAssignmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Authorization.RoleManagementPolicyAssignmentResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Authorization.RoleManagementPolicyAssignmentResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Authorization.RoleManagementPolicyAssignmentResource>> GetAsync(string roleManagementPolicyAssignmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Authorization.RoleManagementPolicyAssignmentResource> GetIfExists(string roleManagementPolicyAssignmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Authorization.RoleManagementPolicyAssignmentResource>> GetIfExistsAsync(string roleManagementPolicyAssignmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Authorization.RoleManagementPolicyAssignmentResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Authorization.RoleManagementPolicyAssignmentResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Authorization.RoleManagementPolicyAssignmentResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Authorization.RoleManagementPolicyAssignmentResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class RoleManagementPolicyAssignmentData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Authorization.RoleManagementPolicyAssignmentData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.RoleManagementPolicyAssignmentData>
    {
        public RoleManagementPolicyAssignmentData() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Authorization.Models.RoleManagementPolicyRule> EffectiveRules { get { throw null; } }
        public Azure.ResourceManager.Authorization.Models.PolicyAssignmentProperties PolicyAssignmentProperties { get { throw null; } }
        public Azure.Core.ResourceIdentifier PolicyId { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier RoleDefinitionId { get { throw null; } set { } }
        public string Scope { get { throw null; } set { } }
        Azure.ResourceManager.Authorization.RoleManagementPolicyAssignmentData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Authorization.RoleManagementPolicyAssignmentData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Authorization.RoleManagementPolicyAssignmentData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Authorization.RoleManagementPolicyAssignmentData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.RoleManagementPolicyAssignmentData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.RoleManagementPolicyAssignmentData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.RoleManagementPolicyAssignmentData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RoleManagementPolicyAssignmentResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected RoleManagementPolicyAssignmentResource() { }
        public virtual Azure.ResourceManager.Authorization.RoleManagementPolicyAssignmentData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string scope, string roleManagementPolicyAssignmentName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Authorization.RoleManagementPolicyAssignmentResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Authorization.RoleManagementPolicyAssignmentResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Authorization.RoleManagementPolicyAssignmentResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Authorization.RoleManagementPolicyAssignmentData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Authorization.RoleManagementPolicyAssignmentResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Authorization.RoleManagementPolicyAssignmentData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class RoleManagementPolicyCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Authorization.RoleManagementPolicyResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Authorization.RoleManagementPolicyResource>, System.Collections.IEnumerable
    {
        protected RoleManagementPolicyCollection() { }
        public virtual Azure.Response<bool> Exists(string roleManagementPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string roleManagementPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Authorization.RoleManagementPolicyResource> Get(string roleManagementPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Authorization.RoleManagementPolicyResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Authorization.RoleManagementPolicyResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Authorization.RoleManagementPolicyResource>> GetAsync(string roleManagementPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Authorization.RoleManagementPolicyResource> GetIfExists(string roleManagementPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Authorization.RoleManagementPolicyResource>> GetIfExistsAsync(string roleManagementPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Authorization.RoleManagementPolicyResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Authorization.RoleManagementPolicyResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Authorization.RoleManagementPolicyResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Authorization.RoleManagementPolicyResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class RoleManagementPolicyData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Authorization.RoleManagementPolicyData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.RoleManagementPolicyData>
    {
        public RoleManagementPolicyData() { }
        public string Description { get { throw null; } set { } }
        public string DisplayName { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Authorization.Models.RoleManagementPolicyRule> EffectiveRules { get { throw null; } }
        public bool? IsOrganizationDefault { get { throw null; } set { } }
        public Azure.ResourceManager.Authorization.Models.RoleManagementPrincipal LastModifiedBy { get { throw null; } }
        public System.DateTimeOffset? LastModifiedOn { get { throw null; } }
        public Azure.ResourceManager.Authorization.Models.RoleManagementPolicyProperties PolicyProperties { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Authorization.Models.RoleManagementPolicyRule> Rules { get { throw null; } }
        public string Scope { get { throw null; } set { } }
        Azure.ResourceManager.Authorization.RoleManagementPolicyData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Authorization.RoleManagementPolicyData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Authorization.RoleManagementPolicyData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Authorization.RoleManagementPolicyData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.RoleManagementPolicyData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.RoleManagementPolicyData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.RoleManagementPolicyData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RoleManagementPolicyResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected RoleManagementPolicyResource() { }
        public virtual Azure.ResourceManager.Authorization.RoleManagementPolicyData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string scope, string roleManagementPolicyName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Authorization.RoleManagementPolicyResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Authorization.RoleManagementPolicyResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Authorization.RoleManagementPolicyResource> Update(Azure.ResourceManager.Authorization.RoleManagementPolicyData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Authorization.RoleManagementPolicyResource>> UpdateAsync(Azure.ResourceManager.Authorization.RoleManagementPolicyData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.Authorization.Mocking
{
    public partial class MockableAuthorizationArmClient : Azure.ResourceManager.ArmResource
    {
        protected MockableAuthorizationArmClient() { }
        public virtual Azure.ResourceManager.Authorization.AuthorizationProviderOperationsMetadataResource GetAuthorizationProviderOperationsMetadataResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Authorization.AuthorizationRoleDefinitionResource> GetAuthorizationRoleDefinition(Azure.Core.ResourceIdentifier scope, Azure.Core.ResourceIdentifier roleDefinitionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Authorization.AuthorizationRoleDefinitionResource>> GetAuthorizationRoleDefinitionAsync(Azure.Core.ResourceIdentifier scope, Azure.Core.ResourceIdentifier roleDefinitionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Authorization.AuthorizationRoleDefinitionResource GetAuthorizationRoleDefinitionResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Authorization.AuthorizationRoleDefinitionCollection GetAuthorizationRoleDefinitions(Azure.Core.ResourceIdentifier scope) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Authorization.DenyAssignmentResource> GetDenyAssignment(Azure.Core.ResourceIdentifier scope, string denyAssignmentId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Authorization.DenyAssignmentResource>> GetDenyAssignmentAsync(Azure.Core.ResourceIdentifier scope, string denyAssignmentId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Authorization.DenyAssignmentResource GetDenyAssignmentResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Authorization.DenyAssignmentCollection GetDenyAssignments(Azure.Core.ResourceIdentifier scope) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Authorization.Models.EligibleChildResource> GetEligibleChildResources(Azure.Core.ResourceIdentifier scope, string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Authorization.Models.EligibleChildResource> GetEligibleChildResourcesAsync(Azure.Core.ResourceIdentifier scope, string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Authorization.RoleAssignmentResource> GetRoleAssignment(Azure.Core.ResourceIdentifier scope, string roleAssignmentName, string tenantId = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Authorization.RoleAssignmentResource>> GetRoleAssignmentAsync(Azure.Core.ResourceIdentifier scope, string roleAssignmentName, string tenantId = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Authorization.RoleAssignmentResource GetRoleAssignmentResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Authorization.RoleAssignmentCollection GetRoleAssignments(Azure.Core.ResourceIdentifier scope) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Authorization.RoleAssignmentScheduleResource> GetRoleAssignmentSchedule(Azure.Core.ResourceIdentifier scope, string roleAssignmentScheduleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Authorization.RoleAssignmentScheduleResource>> GetRoleAssignmentScheduleAsync(Azure.Core.ResourceIdentifier scope, string roleAssignmentScheduleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Authorization.RoleAssignmentScheduleInstanceResource> GetRoleAssignmentScheduleInstance(Azure.Core.ResourceIdentifier scope, string roleAssignmentScheduleInstanceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Authorization.RoleAssignmentScheduleInstanceResource>> GetRoleAssignmentScheduleInstanceAsync(Azure.Core.ResourceIdentifier scope, string roleAssignmentScheduleInstanceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Authorization.RoleAssignmentScheduleInstanceResource GetRoleAssignmentScheduleInstanceResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Authorization.RoleAssignmentScheduleInstanceCollection GetRoleAssignmentScheduleInstances(Azure.Core.ResourceIdentifier scope) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Authorization.RoleAssignmentScheduleRequestResource> GetRoleAssignmentScheduleRequest(Azure.Core.ResourceIdentifier scope, string roleAssignmentScheduleRequestName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Authorization.RoleAssignmentScheduleRequestResource>> GetRoleAssignmentScheduleRequestAsync(Azure.Core.ResourceIdentifier scope, string roleAssignmentScheduleRequestName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Authorization.RoleAssignmentScheduleRequestResource GetRoleAssignmentScheduleRequestResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Authorization.RoleAssignmentScheduleRequestCollection GetRoleAssignmentScheduleRequests(Azure.Core.ResourceIdentifier scope) { throw null; }
        public virtual Azure.ResourceManager.Authorization.RoleAssignmentScheduleResource GetRoleAssignmentScheduleResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Authorization.RoleAssignmentScheduleCollection GetRoleAssignmentSchedules(Azure.Core.ResourceIdentifier scope) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Authorization.RoleEligibilityScheduleResource> GetRoleEligibilitySchedule(Azure.Core.ResourceIdentifier scope, string roleEligibilityScheduleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Authorization.RoleEligibilityScheduleResource>> GetRoleEligibilityScheduleAsync(Azure.Core.ResourceIdentifier scope, string roleEligibilityScheduleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Authorization.RoleEligibilityScheduleInstanceResource> GetRoleEligibilityScheduleInstance(Azure.Core.ResourceIdentifier scope, string roleEligibilityScheduleInstanceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Authorization.RoleEligibilityScheduleInstanceResource>> GetRoleEligibilityScheduleInstanceAsync(Azure.Core.ResourceIdentifier scope, string roleEligibilityScheduleInstanceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Authorization.RoleEligibilityScheduleInstanceResource GetRoleEligibilityScheduleInstanceResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Authorization.RoleEligibilityScheduleInstanceCollection GetRoleEligibilityScheduleInstances(Azure.Core.ResourceIdentifier scope) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Authorization.RoleEligibilityScheduleRequestResource> GetRoleEligibilityScheduleRequest(Azure.Core.ResourceIdentifier scope, string roleEligibilityScheduleRequestName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Authorization.RoleEligibilityScheduleRequestResource>> GetRoleEligibilityScheduleRequestAsync(Azure.Core.ResourceIdentifier scope, string roleEligibilityScheduleRequestName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Authorization.RoleEligibilityScheduleRequestResource GetRoleEligibilityScheduleRequestResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Authorization.RoleEligibilityScheduleRequestCollection GetRoleEligibilityScheduleRequests(Azure.Core.ResourceIdentifier scope) { throw null; }
        public virtual Azure.ResourceManager.Authorization.RoleEligibilityScheduleResource GetRoleEligibilityScheduleResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Authorization.RoleEligibilityScheduleCollection GetRoleEligibilitySchedules(Azure.Core.ResourceIdentifier scope) { throw null; }
        public virtual Azure.ResourceManager.Authorization.RoleManagementPolicyCollection GetRoleManagementPolicies(Azure.Core.ResourceIdentifier scope) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Authorization.RoleManagementPolicyResource> GetRoleManagementPolicy(Azure.Core.ResourceIdentifier scope, string roleManagementPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Authorization.RoleManagementPolicyAssignmentResource> GetRoleManagementPolicyAssignment(Azure.Core.ResourceIdentifier scope, string roleManagementPolicyAssignmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Authorization.RoleManagementPolicyAssignmentResource>> GetRoleManagementPolicyAssignmentAsync(Azure.Core.ResourceIdentifier scope, string roleManagementPolicyAssignmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Authorization.RoleManagementPolicyAssignmentResource GetRoleManagementPolicyAssignmentResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Authorization.RoleManagementPolicyAssignmentCollection GetRoleManagementPolicyAssignments(Azure.Core.ResourceIdentifier scope) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Authorization.RoleManagementPolicyResource>> GetRoleManagementPolicyAsync(Azure.Core.ResourceIdentifier scope, string roleManagementPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Authorization.RoleManagementPolicyResource GetRoleManagementPolicyResource(Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class MockableAuthorizationArmResource : Azure.ResourceManager.ArmResource
    {
        protected MockableAuthorizationArmResource() { }
        public virtual Azure.Response<Azure.ResourceManager.Authorization.AuthorizationRoleDefinitionResource> GetAuthorizationRoleDefinition(Azure.Core.ResourceIdentifier roleDefinitionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Authorization.AuthorizationRoleDefinitionResource>> GetAuthorizationRoleDefinitionAsync(Azure.Core.ResourceIdentifier roleDefinitionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Authorization.AuthorizationRoleDefinitionCollection GetAuthorizationRoleDefinitions() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Authorization.DenyAssignmentResource> GetDenyAssignment(string denyAssignmentId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Authorization.DenyAssignmentResource>> GetDenyAssignmentAsync(string denyAssignmentId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Authorization.DenyAssignmentCollection GetDenyAssignments() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Authorization.RoleAssignmentResource> GetRoleAssignment(string roleAssignmentName, string tenantId = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Authorization.RoleAssignmentResource>> GetRoleAssignmentAsync(string roleAssignmentName, string tenantId = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Authorization.RoleAssignmentCollection GetRoleAssignments() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Authorization.RoleAssignmentScheduleResource> GetRoleAssignmentSchedule(string roleAssignmentScheduleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Authorization.RoleAssignmentScheduleResource>> GetRoleAssignmentScheduleAsync(string roleAssignmentScheduleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Authorization.RoleAssignmentScheduleInstanceResource> GetRoleAssignmentScheduleInstance(string roleAssignmentScheduleInstanceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Authorization.RoleAssignmentScheduleInstanceResource>> GetRoleAssignmentScheduleInstanceAsync(string roleAssignmentScheduleInstanceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Authorization.RoleAssignmentScheduleInstanceCollection GetRoleAssignmentScheduleInstances() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Authorization.RoleAssignmentScheduleRequestResource> GetRoleAssignmentScheduleRequest(string roleAssignmentScheduleRequestName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Authorization.RoleAssignmentScheduleRequestResource>> GetRoleAssignmentScheduleRequestAsync(string roleAssignmentScheduleRequestName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Authorization.RoleAssignmentScheduleRequestCollection GetRoleAssignmentScheduleRequests() { throw null; }
        public virtual Azure.ResourceManager.Authorization.RoleAssignmentScheduleCollection GetRoleAssignmentSchedules() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Authorization.RoleEligibilityScheduleResource> GetRoleEligibilitySchedule(string roleEligibilityScheduleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Authorization.RoleEligibilityScheduleResource>> GetRoleEligibilityScheduleAsync(string roleEligibilityScheduleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Authorization.RoleEligibilityScheduleInstanceResource> GetRoleEligibilityScheduleInstance(string roleEligibilityScheduleInstanceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Authorization.RoleEligibilityScheduleInstanceResource>> GetRoleEligibilityScheduleInstanceAsync(string roleEligibilityScheduleInstanceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Authorization.RoleEligibilityScheduleInstanceCollection GetRoleEligibilityScheduleInstances() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Authorization.RoleEligibilityScheduleRequestResource> GetRoleEligibilityScheduleRequest(string roleEligibilityScheduleRequestName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Authorization.RoleEligibilityScheduleRequestResource>> GetRoleEligibilityScheduleRequestAsync(string roleEligibilityScheduleRequestName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Authorization.RoleEligibilityScheduleRequestCollection GetRoleEligibilityScheduleRequests() { throw null; }
        public virtual Azure.ResourceManager.Authorization.RoleEligibilityScheduleCollection GetRoleEligibilitySchedules() { throw null; }
        public virtual Azure.ResourceManager.Authorization.RoleManagementPolicyCollection GetRoleManagementPolicies() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Authorization.RoleManagementPolicyResource> GetRoleManagementPolicy(string roleManagementPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Authorization.RoleManagementPolicyAssignmentResource> GetRoleManagementPolicyAssignment(string roleManagementPolicyAssignmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Authorization.RoleManagementPolicyAssignmentResource>> GetRoleManagementPolicyAssignmentAsync(string roleManagementPolicyAssignmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Authorization.RoleManagementPolicyAssignmentCollection GetRoleManagementPolicyAssignments() { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Authorization.RoleManagementPolicyResource>> GetRoleManagementPolicyAsync(string roleManagementPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class MockableAuthorizationResourceGroupResource : Azure.ResourceManager.ArmResource
    {
        protected MockableAuthorizationResourceGroupResource() { }
        public virtual Azure.Pageable<Azure.ResourceManager.Authorization.Models.RoleDefinitionPermission> GetAzurePermissionsForResourceGroups(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Authorization.Models.RoleDefinitionPermission> GetAzurePermissionsForResourceGroupsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Authorization.Models.RoleDefinitionPermission> GetAzurePermissionsForResources(string resourceProviderNamespace, string parentResourcePath, string resourceType, string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Authorization.Models.RoleDefinitionPermission> GetAzurePermissionsForResourcesAsync(string resourceProviderNamespace, string parentResourcePath, string resourceType, string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class MockableAuthorizationSubscriptionResource : Azure.ResourceManager.ArmResource
    {
        protected MockableAuthorizationSubscriptionResource() { }
        public virtual Azure.Pageable<Azure.ResourceManager.Authorization.Models.AuthorizationClassicAdministrator> GetClassicAdministrators(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Authorization.Models.AuthorizationClassicAdministrator> GetClassicAdministratorsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class MockableAuthorizationTenantResource : Azure.ResourceManager.ArmResource
    {
        protected MockableAuthorizationTenantResource() { }
        public virtual Azure.Response ElevateAccessGlobalAdministrator(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> ElevateAccessGlobalAdministratorAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Authorization.AuthorizationProviderOperationsMetadataCollection GetAllAuthorizationProviderOperationsMetadata() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Authorization.AuthorizationProviderOperationsMetadataResource> GetAuthorizationProviderOperationsMetadata(string resourceProviderNamespace, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Authorization.AuthorizationProviderOperationsMetadataResource>> GetAuthorizationProviderOperationsMetadataAsync(string resourceProviderNamespace, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.Authorization.Models
{
    public static partial class ArmAuthorizationModelFactory
    {
        public static Azure.ResourceManager.Authorization.Models.AuthorizationClassicAdministrator AuthorizationClassicAdministrator(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string emailAddress = null, string role = null) { throw null; }
        public static Azure.ResourceManager.Authorization.Models.AuthorizationProviderOperationInfo AuthorizationProviderOperationInfo(string name = null, string displayName = null, string description = null, string origin = null, System.BinaryData properties = null, bool? isDataAction = default(bool?)) { throw null; }
        public static Azure.ResourceManager.Authorization.AuthorizationProviderOperationsMetadataData AuthorizationProviderOperationsMetadataData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string displayName = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Authorization.Models.AuthorizationProviderResourceType> resourceTypes = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Authorization.Models.AuthorizationProviderOperationInfo> operations = null) { throw null; }
        public static Azure.ResourceManager.Authorization.Models.AuthorizationProviderResourceType AuthorizationProviderResourceType(string name = null, string displayName = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Authorization.Models.AuthorizationProviderOperationInfo> operations = null) { throw null; }
        public static Azure.ResourceManager.Authorization.AuthorizationRoleDefinitionData AuthorizationRoleDefinitionData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string roleName = null, string description = null, Azure.ResourceManager.Authorization.Models.AuthorizationRoleType? roleType = default(Azure.ResourceManager.Authorization.Models.AuthorizationRoleType?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.Authorization.Models.RoleDefinitionPermission> permissions = null, System.Collections.Generic.IEnumerable<string> assignableScopes = null) { throw null; }
        public static Azure.ResourceManager.Authorization.DenyAssignmentData DenyAssignmentData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string denyAssignmentName = null, string description = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Authorization.Models.DenyAssignmentPermission> permissions = null, string scope = null, bool? isAppliedToChildScopes = default(bool?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.Authorization.Models.RoleManagementPrincipal> principals = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Authorization.Models.RoleManagementPrincipal> excludePrincipals = null, bool? isSystemProtected = default(bool?)) { throw null; }
        public static Azure.ResourceManager.Authorization.Models.DenyAssignmentPermission DenyAssignmentPermission(System.Collections.Generic.IEnumerable<string> actions = null, System.Collections.Generic.IEnumerable<string> notActions = null, System.Collections.Generic.IEnumerable<string> dataActions = null, System.Collections.Generic.IEnumerable<string> notDataActions = null, string condition = null, string conditionVersion = null) { throw null; }
        public static Azure.ResourceManager.Authorization.Models.EligibleChildResource EligibleChildResource(string id = null, string name = null, string resourceType = null) { throw null; }
        public static Azure.ResourceManager.Authorization.Models.PolicyAssignmentProperties PolicyAssignmentProperties(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.Core.ResourceIdentifier policyId = null, Azure.ResourceManager.Authorization.Models.RoleManagementPrincipal lastModifiedBy = null, System.DateTimeOffset? lastModifiedOn = default(System.DateTimeOffset?), Azure.Core.ResourceIdentifier roleDefinitionId = null, string roleDefinitionDisplayName = null, Azure.ResourceManager.Authorization.Models.AuthorizationRoleType? roleType = default(Azure.ResourceManager.Authorization.Models.AuthorizationRoleType?), Azure.Core.ResourceIdentifier scopeId = null, string scopeDisplayName = null, Azure.ResourceManager.Authorization.Models.RoleManagementScopeType? scopeType = default(Azure.ResourceManager.Authorization.Models.RoleManagementScopeType?)) { throw null; }
        public static Azure.ResourceManager.Authorization.Models.RoleAssignmentCreateOrUpdateContent RoleAssignmentCreateOrUpdateContent(string scope = null, Azure.Core.ResourceIdentifier roleDefinitionId = null, System.Guid principalId = default(System.Guid), Azure.ResourceManager.Authorization.Models.RoleManagementPrincipalType? principalType = default(Azure.ResourceManager.Authorization.Models.RoleManagementPrincipalType?), string description = null, string condition = null, string conditionVersion = null, System.DateTimeOffset? createdOn = default(System.DateTimeOffset?), System.DateTimeOffset? updatedOn = default(System.DateTimeOffset?), string createdBy = null, string updatedBy = null, Azure.Core.ResourceIdentifier delegatedManagedIdentityResourceId = null) { throw null; }
        public static Azure.ResourceManager.Authorization.RoleAssignmentData RoleAssignmentData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string scope = null, Azure.Core.ResourceIdentifier roleDefinitionId = null, System.Guid? principalId = default(System.Guid?), Azure.ResourceManager.Authorization.Models.RoleManagementPrincipalType? principalType = default(Azure.ResourceManager.Authorization.Models.RoleManagementPrincipalType?), string description = null, string condition = null, string conditionVersion = null, System.DateTimeOffset? createdOn = default(System.DateTimeOffset?), System.DateTimeOffset? updatedOn = default(System.DateTimeOffset?), string createdBy = null, string updatedBy = null, Azure.Core.ResourceIdentifier delegatedManagedIdentityResourceId = null) { throw null; }
        public static Azure.ResourceManager.Authorization.RoleAssignmentScheduleData RoleAssignmentScheduleData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string scope = null, Azure.Core.ResourceIdentifier roleDefinitionId = null, System.Guid? principalId = default(System.Guid?), Azure.ResourceManager.Authorization.Models.RoleManagementPrincipalType? principalType = default(Azure.ResourceManager.Authorization.Models.RoleManagementPrincipalType?), Azure.Core.ResourceIdentifier roleAssignmentScheduleRequestId = null, Azure.Core.ResourceIdentifier linkedRoleEligibilityScheduleId = null, Azure.ResourceManager.Authorization.Models.RoleAssignmentScheduleAssignmentType? assignmentType = default(Azure.ResourceManager.Authorization.Models.RoleAssignmentScheduleAssignmentType?), Azure.ResourceManager.Authorization.Models.RoleManagementScheduleMemberType? memberType = default(Azure.ResourceManager.Authorization.Models.RoleManagementScheduleMemberType?), Azure.ResourceManager.Authorization.Models.RoleManagementScheduleStatus? status = default(Azure.ResourceManager.Authorization.Models.RoleManagementScheduleStatus?), System.DateTimeOffset? startOn = default(System.DateTimeOffset?), System.DateTimeOffset? endOn = default(System.DateTimeOffset?), string condition = null, string conditionVersion = null, System.DateTimeOffset? createdOn = default(System.DateTimeOffset?), System.DateTimeOffset? updatedOn = default(System.DateTimeOffset?), Azure.ResourceManager.Authorization.Models.RoleManagementExpandedProperties expandedProperties = null) { throw null; }
        public static Azure.ResourceManager.Authorization.RoleAssignmentScheduleInstanceData RoleAssignmentScheduleInstanceData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string scope = null, Azure.Core.ResourceIdentifier roleDefinitionId = null, System.Guid? principalId = default(System.Guid?), Azure.ResourceManager.Authorization.Models.RoleManagementPrincipalType? principalType = default(Azure.ResourceManager.Authorization.Models.RoleManagementPrincipalType?), Azure.Core.ResourceIdentifier roleAssignmentScheduleId = null, Azure.Core.ResourceIdentifier originRoleAssignmentId = null, Azure.ResourceManager.Authorization.Models.RoleManagementScheduleStatus? status = default(Azure.ResourceManager.Authorization.Models.RoleManagementScheduleStatus?), System.DateTimeOffset? startOn = default(System.DateTimeOffset?), System.DateTimeOffset? endOn = default(System.DateTimeOffset?), Azure.Core.ResourceIdentifier linkedRoleEligibilityScheduleId = null, Azure.Core.ResourceIdentifier linkedRoleEligibilityScheduleInstanceId = null, Azure.ResourceManager.Authorization.Models.RoleAssignmentScheduleAssignmentType? assignmentType = default(Azure.ResourceManager.Authorization.Models.RoleAssignmentScheduleAssignmentType?), Azure.ResourceManager.Authorization.Models.RoleManagementScheduleMemberType? memberType = default(Azure.ResourceManager.Authorization.Models.RoleManagementScheduleMemberType?), string condition = null, string conditionVersion = null, System.DateTimeOffset? createdOn = default(System.DateTimeOffset?), Azure.ResourceManager.Authorization.Models.RoleManagementExpandedProperties expandedProperties = null) { throw null; }
        public static Azure.ResourceManager.Authorization.RoleAssignmentScheduleRequestData RoleAssignmentScheduleRequestData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string scope = null, Azure.Core.ResourceIdentifier roleDefinitionId = null, System.Guid? principalId = default(System.Guid?), Azure.ResourceManager.Authorization.Models.RoleManagementPrincipalType? principalType = default(Azure.ResourceManager.Authorization.Models.RoleManagementPrincipalType?), Azure.ResourceManager.Authorization.Models.RoleManagementScheduleRequestType? requestType = default(Azure.ResourceManager.Authorization.Models.RoleManagementScheduleRequestType?), Azure.ResourceManager.Authorization.Models.RoleManagementScheduleStatus? status = default(Azure.ResourceManager.Authorization.Models.RoleManagementScheduleStatus?), string approvalId = null, Azure.Core.ResourceIdentifier targetRoleAssignmentScheduleId = null, Azure.Core.ResourceIdentifier targetRoleAssignmentScheduleInstanceId = null, Azure.Core.ResourceIdentifier linkedRoleEligibilityScheduleId = null, string justification = null, Azure.ResourceManager.Authorization.Models.RoleAssignmentScheduleTicketInfo ticketInfo = null, string condition = null, string conditionVersion = null, System.DateTimeOffset? createdOn = default(System.DateTimeOffset?), System.Guid? requestorId = default(System.Guid?), Azure.ResourceManager.Authorization.Models.RoleManagementExpandedProperties expandedProperties = null, System.DateTimeOffset? startOn = default(System.DateTimeOffset?), Azure.ResourceManager.Authorization.Models.RoleManagementScheduleExpirationType? expirationType = default(Azure.ResourceManager.Authorization.Models.RoleManagementScheduleExpirationType?), System.DateTimeOffset? endOn = default(System.DateTimeOffset?), System.TimeSpan? duration = default(System.TimeSpan?)) { throw null; }
        public static Azure.ResourceManager.Authorization.RoleEligibilityScheduleData RoleEligibilityScheduleData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string scope = null, Azure.Core.ResourceIdentifier roleDefinitionId = null, System.Guid? principalId = default(System.Guid?), Azure.ResourceManager.Authorization.Models.RoleManagementPrincipalType? principalType = default(Azure.ResourceManager.Authorization.Models.RoleManagementPrincipalType?), Azure.Core.ResourceIdentifier roleEligibilityScheduleRequestId = null, Azure.ResourceManager.Authorization.Models.RoleManagementScheduleMemberType? memberType = default(Azure.ResourceManager.Authorization.Models.RoleManagementScheduleMemberType?), Azure.ResourceManager.Authorization.Models.RoleManagementScheduleStatus? status = default(Azure.ResourceManager.Authorization.Models.RoleManagementScheduleStatus?), System.DateTimeOffset? startOn = default(System.DateTimeOffset?), System.DateTimeOffset? endOn = default(System.DateTimeOffset?), string condition = null, string conditionVersion = null, System.DateTimeOffset? createdOn = default(System.DateTimeOffset?), System.DateTimeOffset? updatedOn = default(System.DateTimeOffset?), Azure.ResourceManager.Authorization.Models.RoleManagementExpandedProperties expandedProperties = null) { throw null; }
        public static Azure.ResourceManager.Authorization.RoleEligibilityScheduleInstanceData RoleEligibilityScheduleInstanceData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string scope = null, Azure.Core.ResourceIdentifier roleDefinitionId = null, System.Guid? principalId = default(System.Guid?), Azure.ResourceManager.Authorization.Models.RoleManagementPrincipalType? principalType = default(Azure.ResourceManager.Authorization.Models.RoleManagementPrincipalType?), Azure.Core.ResourceIdentifier roleEligibilityScheduleId = null, Azure.ResourceManager.Authorization.Models.RoleManagementScheduleStatus? status = default(Azure.ResourceManager.Authorization.Models.RoleManagementScheduleStatus?), System.DateTimeOffset? startOn = default(System.DateTimeOffset?), System.DateTimeOffset? endOn = default(System.DateTimeOffset?), Azure.ResourceManager.Authorization.Models.RoleManagementScheduleMemberType? memberType = default(Azure.ResourceManager.Authorization.Models.RoleManagementScheduleMemberType?), string condition = null, string conditionVersion = null, System.DateTimeOffset? createdOn = default(System.DateTimeOffset?), Azure.ResourceManager.Authorization.Models.RoleManagementExpandedProperties expandedProperties = null) { throw null; }
        public static Azure.ResourceManager.Authorization.RoleEligibilityScheduleRequestData RoleEligibilityScheduleRequestData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string scope = null, Azure.Core.ResourceIdentifier roleDefinitionId = null, System.Guid? principalId = default(System.Guid?), Azure.ResourceManager.Authorization.Models.RoleManagementPrincipalType? principalType = default(Azure.ResourceManager.Authorization.Models.RoleManagementPrincipalType?), Azure.ResourceManager.Authorization.Models.RoleManagementScheduleRequestType? requestType = default(Azure.ResourceManager.Authorization.Models.RoleManagementScheduleRequestType?), Azure.ResourceManager.Authorization.Models.RoleManagementScheduleStatus? status = default(Azure.ResourceManager.Authorization.Models.RoleManagementScheduleStatus?), string approvalId = null, Azure.Core.ResourceIdentifier targetRoleEligibilityScheduleId = null, Azure.Core.ResourceIdentifier targetRoleEligibilityScheduleInstanceId = null, string justification = null, Azure.ResourceManager.Authorization.Models.RoleEligibilityScheduleRequestPropertiesTicketInfo ticketInfo = null, string condition = null, string conditionVersion = null, System.DateTimeOffset? createdOn = default(System.DateTimeOffset?), System.Guid? requestorId = default(System.Guid?), Azure.ResourceManager.Authorization.Models.RoleManagementExpandedProperties expandedProperties = null, System.DateTimeOffset? startOn = default(System.DateTimeOffset?), Azure.ResourceManager.Authorization.Models.RoleManagementScheduleExpirationType? expirationType = default(Azure.ResourceManager.Authorization.Models.RoleManagementScheduleExpirationType?), System.DateTimeOffset? endOn = default(System.DateTimeOffset?), System.TimeSpan? duration = default(System.TimeSpan?)) { throw null; }
        public static Azure.ResourceManager.Authorization.Models.RoleManagementExpandedProperties RoleManagementExpandedProperties(System.Guid? principalId = default(System.Guid?), string principalDisplayName = null, string email = null, Azure.ResourceManager.Authorization.Models.RoleManagementPrincipalType? principalType = default(Azure.ResourceManager.Authorization.Models.RoleManagementPrincipalType?), Azure.Core.ResourceIdentifier roleDefinitionId = null, string roleDefinitionDisplayName = null, Azure.ResourceManager.Authorization.Models.AuthorizationRoleType? roleType = default(Azure.ResourceManager.Authorization.Models.AuthorizationRoleType?), Azure.Core.ResourceIdentifier scopeId = null, string scopeDisplayName = null, Azure.ResourceManager.Authorization.Models.RoleManagementScopeType? scopeType = default(Azure.ResourceManager.Authorization.Models.RoleManagementScopeType?)) { throw null; }
        public static Azure.ResourceManager.Authorization.RoleManagementPolicyAssignmentData RoleManagementPolicyAssignmentData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string scope = null, Azure.Core.ResourceIdentifier roleDefinitionId = null, Azure.Core.ResourceIdentifier policyId = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Authorization.Models.RoleManagementPolicyRule> effectiveRules = null, Azure.ResourceManager.Authorization.Models.PolicyAssignmentProperties policyAssignmentProperties = null) { throw null; }
        public static Azure.ResourceManager.Authorization.RoleManagementPolicyData RoleManagementPolicyData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string scope = null, string displayName = null, string description = null, bool? isOrganizationDefault = default(bool?), Azure.ResourceManager.Authorization.Models.RoleManagementPrincipal lastModifiedBy = null, System.DateTimeOffset? lastModifiedOn = default(System.DateTimeOffset?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.Authorization.Models.RoleManagementPolicyRule> rules = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Authorization.Models.RoleManagementPolicyRule> effectiveRules = null, Azure.ResourceManager.Authorization.Models.RoleManagementPolicyProperties policyProperties = null) { throw null; }
        public static Azure.ResourceManager.Authorization.Models.RoleManagementPolicyProperties RoleManagementPolicyProperties(Azure.Core.ResourceIdentifier scopeId = null, string scopeDisplayName = null, Azure.ResourceManager.Authorization.Models.RoleManagementScopeType? scopeType = default(Azure.ResourceManager.Authorization.Models.RoleManagementScopeType?)) { throw null; }
        public static Azure.ResourceManager.Authorization.Models.RoleManagementPrincipal RoleManagementPrincipal(string id = null, string displayName = null, Azure.ResourceManager.Authorization.Models.RoleManagementPrincipalType? principalType = default(Azure.ResourceManager.Authorization.Models.RoleManagementPrincipalType?), string email = null) { throw null; }
    }
    public partial class AuthorizationClassicAdministrator : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Authorization.Models.AuthorizationClassicAdministrator>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.Models.AuthorizationClassicAdministrator>
    {
        internal AuthorizationClassicAdministrator() { }
        public string EmailAddress { get { throw null; } }
        public string Role { get { throw null; } }
        Azure.ResourceManager.Authorization.Models.AuthorizationClassicAdministrator System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Authorization.Models.AuthorizationClassicAdministrator>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Authorization.Models.AuthorizationClassicAdministrator>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Authorization.Models.AuthorizationClassicAdministrator System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.Models.AuthorizationClassicAdministrator>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.Models.AuthorizationClassicAdministrator>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.Models.AuthorizationClassicAdministrator>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AuthorizationProviderOperationInfo : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Authorization.Models.AuthorizationProviderOperationInfo>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.Models.AuthorizationProviderOperationInfo>
    {
        internal AuthorizationProviderOperationInfo() { }
        public string Description { get { throw null; } }
        public string DisplayName { get { throw null; } }
        public bool? IsDataAction { get { throw null; } }
        public string Name { get { throw null; } }
        public string Origin { get { throw null; } }
        public System.BinaryData Properties { get { throw null; } }
        Azure.ResourceManager.Authorization.Models.AuthorizationProviderOperationInfo System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Authorization.Models.AuthorizationProviderOperationInfo>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Authorization.Models.AuthorizationProviderOperationInfo>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Authorization.Models.AuthorizationProviderOperationInfo System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.Models.AuthorizationProviderOperationInfo>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.Models.AuthorizationProviderOperationInfo>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.Models.AuthorizationProviderOperationInfo>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AuthorizationProviderResourceType : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Authorization.Models.AuthorizationProviderResourceType>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.Models.AuthorizationProviderResourceType>
    {
        internal AuthorizationProviderResourceType() { }
        public string DisplayName { get { throw null; } }
        public string Name { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Authorization.Models.AuthorizationProviderOperationInfo> Operations { get { throw null; } }
        Azure.ResourceManager.Authorization.Models.AuthorizationProviderResourceType System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Authorization.Models.AuthorizationProviderResourceType>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Authorization.Models.AuthorizationProviderResourceType>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Authorization.Models.AuthorizationProviderResourceType System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.Models.AuthorizationProviderResourceType>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.Models.AuthorizationProviderResourceType>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.Models.AuthorizationProviderResourceType>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AuthorizationRoleType : System.IEquatable<Azure.ResourceManager.Authorization.Models.AuthorizationRoleType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AuthorizationRoleType(string value) { throw null; }
        public static Azure.ResourceManager.Authorization.Models.AuthorizationRoleType BuiltInRole { get { throw null; } }
        public static Azure.ResourceManager.Authorization.Models.AuthorizationRoleType CustomRole { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Authorization.Models.AuthorizationRoleType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Authorization.Models.AuthorizationRoleType left, Azure.ResourceManager.Authorization.Models.AuthorizationRoleType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Authorization.Models.AuthorizationRoleType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Authorization.Models.AuthorizationRoleType left, Azure.ResourceManager.Authorization.Models.AuthorizationRoleType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DenyAssignmentPermission : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Authorization.Models.DenyAssignmentPermission>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.Models.DenyAssignmentPermission>
    {
        internal DenyAssignmentPermission() { }
        public System.Collections.Generic.IReadOnlyList<string> Actions { get { throw null; } }
        public string Condition { get { throw null; } }
        public string ConditionVersion { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> DataActions { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> NotActions { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> NotDataActions { get { throw null; } }
        Azure.ResourceManager.Authorization.Models.DenyAssignmentPermission System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Authorization.Models.DenyAssignmentPermission>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Authorization.Models.DenyAssignmentPermission>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Authorization.Models.DenyAssignmentPermission System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.Models.DenyAssignmentPermission>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.Models.DenyAssignmentPermission>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.Models.DenyAssignmentPermission>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class EligibleChildResource : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Authorization.Models.EligibleChildResource>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.Models.EligibleChildResource>
    {
        internal EligibleChildResource() { }
        public string Id { get { throw null; } }
        public string Name { get { throw null; } }
        public string ResourceType { get { throw null; } }
        Azure.ResourceManager.Authorization.Models.EligibleChildResource System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Authorization.Models.EligibleChildResource>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Authorization.Models.EligibleChildResource>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Authorization.Models.EligibleChildResource System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.Models.EligibleChildResource>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.Models.EligibleChildResource>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.Models.EligibleChildResource>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct NotificationDeliveryType : System.IEquatable<Azure.ResourceManager.Authorization.Models.NotificationDeliveryType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public NotificationDeliveryType(string value) { throw null; }
        public static Azure.ResourceManager.Authorization.Models.NotificationDeliveryType Email { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Authorization.Models.NotificationDeliveryType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Authorization.Models.NotificationDeliveryType left, Azure.ResourceManager.Authorization.Models.NotificationDeliveryType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Authorization.Models.NotificationDeliveryType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Authorization.Models.NotificationDeliveryType left, Azure.ResourceManager.Authorization.Models.NotificationDeliveryType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class PolicyAssignmentProperties : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Authorization.Models.PolicyAssignmentProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.Models.PolicyAssignmentProperties>
    {
        internal PolicyAssignmentProperties() { }
        public Azure.ResourceManager.Authorization.Models.RoleManagementPrincipal LastModifiedBy { get { throw null; } }
        public System.DateTimeOffset? LastModifiedOn { get { throw null; } }
        public Azure.Core.ResourceIdentifier PolicyId { get { throw null; } }
        public string RoleDefinitionDisplayName { get { throw null; } }
        public Azure.Core.ResourceIdentifier RoleDefinitionId { get { throw null; } }
        public Azure.ResourceManager.Authorization.Models.AuthorizationRoleType? RoleType { get { throw null; } }
        public string ScopeDisplayName { get { throw null; } }
        public Azure.Core.ResourceIdentifier ScopeId { get { throw null; } }
        public Azure.ResourceManager.Authorization.Models.RoleManagementScopeType? ScopeType { get { throw null; } }
        Azure.ResourceManager.Authorization.Models.PolicyAssignmentProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Authorization.Models.PolicyAssignmentProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Authorization.Models.PolicyAssignmentProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Authorization.Models.PolicyAssignmentProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.Models.PolicyAssignmentProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.Models.PolicyAssignmentProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.Models.PolicyAssignmentProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RoleAssignmentCreateOrUpdateContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Authorization.Models.RoleAssignmentCreateOrUpdateContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.Models.RoleAssignmentCreateOrUpdateContent>
    {
        public RoleAssignmentCreateOrUpdateContent(Azure.Core.ResourceIdentifier roleDefinitionId, System.Guid principalId) { }
        public string Condition { get { throw null; } set { } }
        public string ConditionVersion { get { throw null; } set { } }
        public string CreatedBy { get { throw null; } }
        public System.DateTimeOffset? CreatedOn { get { throw null; } }
        public Azure.Core.ResourceIdentifier DelegatedManagedIdentityResourceId { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public System.Guid PrincipalId { get { throw null; } }
        public Azure.ResourceManager.Authorization.Models.RoleManagementPrincipalType? PrincipalType { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier RoleDefinitionId { get { throw null; } }
        public string Scope { get { throw null; } }
        public string UpdatedBy { get { throw null; } }
        public System.DateTimeOffset? UpdatedOn { get { throw null; } }
        Azure.ResourceManager.Authorization.Models.RoleAssignmentCreateOrUpdateContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Authorization.Models.RoleAssignmentCreateOrUpdateContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Authorization.Models.RoleAssignmentCreateOrUpdateContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Authorization.Models.RoleAssignmentCreateOrUpdateContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.Models.RoleAssignmentCreateOrUpdateContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.Models.RoleAssignmentCreateOrUpdateContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.Models.RoleAssignmentCreateOrUpdateContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RoleAssignmentEnablementRuleType : System.IEquatable<Azure.ResourceManager.Authorization.Models.RoleAssignmentEnablementRuleType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RoleAssignmentEnablementRuleType(string value) { throw null; }
        public static Azure.ResourceManager.Authorization.Models.RoleAssignmentEnablementRuleType Justification { get { throw null; } }
        public static Azure.ResourceManager.Authorization.Models.RoleAssignmentEnablementRuleType MultiFactorAuthentication { get { throw null; } }
        public static Azure.ResourceManager.Authorization.Models.RoleAssignmentEnablementRuleType Ticketing { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Authorization.Models.RoleAssignmentEnablementRuleType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Authorization.Models.RoleAssignmentEnablementRuleType left, Azure.ResourceManager.Authorization.Models.RoleAssignmentEnablementRuleType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Authorization.Models.RoleAssignmentEnablementRuleType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Authorization.Models.RoleAssignmentEnablementRuleType left, Azure.ResourceManager.Authorization.Models.RoleAssignmentEnablementRuleType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RoleAssignmentScheduleAssignmentType : System.IEquatable<Azure.ResourceManager.Authorization.Models.RoleAssignmentScheduleAssignmentType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RoleAssignmentScheduleAssignmentType(string value) { throw null; }
        public static Azure.ResourceManager.Authorization.Models.RoleAssignmentScheduleAssignmentType Activated { get { throw null; } }
        public static Azure.ResourceManager.Authorization.Models.RoleAssignmentScheduleAssignmentType Assigned { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Authorization.Models.RoleAssignmentScheduleAssignmentType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Authorization.Models.RoleAssignmentScheduleAssignmentType left, Azure.ResourceManager.Authorization.Models.RoleAssignmentScheduleAssignmentType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Authorization.Models.RoleAssignmentScheduleAssignmentType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Authorization.Models.RoleAssignmentScheduleAssignmentType left, Azure.ResourceManager.Authorization.Models.RoleAssignmentScheduleAssignmentType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class RoleAssignmentScheduleTicketInfo : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Authorization.Models.RoleAssignmentScheduleTicketInfo>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.Models.RoleAssignmentScheduleTicketInfo>
    {
        public RoleAssignmentScheduleTicketInfo() { }
        public string TicketNumber { get { throw null; } set { } }
        public string TicketSystem { get { throw null; } set { } }
        Azure.ResourceManager.Authorization.Models.RoleAssignmentScheduleTicketInfo System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Authorization.Models.RoleAssignmentScheduleTicketInfo>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Authorization.Models.RoleAssignmentScheduleTicketInfo>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Authorization.Models.RoleAssignmentScheduleTicketInfo System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.Models.RoleAssignmentScheduleTicketInfo>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.Models.RoleAssignmentScheduleTicketInfo>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.Models.RoleAssignmentScheduleTicketInfo>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RoleDefinitionPermission : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Authorization.Models.RoleDefinitionPermission>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.Models.RoleDefinitionPermission>
    {
        public RoleDefinitionPermission() { }
        public System.Collections.Generic.IList<string> Actions { get { throw null; } }
        public System.Collections.Generic.IList<string> DataActions { get { throw null; } }
        public System.Collections.Generic.IList<string> NotActions { get { throw null; } }
        public System.Collections.Generic.IList<string> NotDataActions { get { throw null; } }
        Azure.ResourceManager.Authorization.Models.RoleDefinitionPermission System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Authorization.Models.RoleDefinitionPermission>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Authorization.Models.RoleDefinitionPermission>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Authorization.Models.RoleDefinitionPermission System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.Models.RoleDefinitionPermission>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.Models.RoleDefinitionPermission>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.Models.RoleDefinitionPermission>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RoleEligibilityScheduleRequestPropertiesTicketInfo : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Authorization.Models.RoleEligibilityScheduleRequestPropertiesTicketInfo>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.Models.RoleEligibilityScheduleRequestPropertiesTicketInfo>
    {
        public RoleEligibilityScheduleRequestPropertiesTicketInfo() { }
        public string TicketNumber { get { throw null; } set { } }
        public string TicketSystem { get { throw null; } set { } }
        Azure.ResourceManager.Authorization.Models.RoleEligibilityScheduleRequestPropertiesTicketInfo System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Authorization.Models.RoleEligibilityScheduleRequestPropertiesTicketInfo>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Authorization.Models.RoleEligibilityScheduleRequestPropertiesTicketInfo>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Authorization.Models.RoleEligibilityScheduleRequestPropertiesTicketInfo System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.Models.RoleEligibilityScheduleRequestPropertiesTicketInfo>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.Models.RoleEligibilityScheduleRequestPropertiesTicketInfo>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.Models.RoleEligibilityScheduleRequestPropertiesTicketInfo>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RoleManagementApprovalMode : System.IEquatable<Azure.ResourceManager.Authorization.Models.RoleManagementApprovalMode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RoleManagementApprovalMode(string value) { throw null; }
        public static Azure.ResourceManager.Authorization.Models.RoleManagementApprovalMode NoApproval { get { throw null; } }
        public static Azure.ResourceManager.Authorization.Models.RoleManagementApprovalMode Parallel { get { throw null; } }
        public static Azure.ResourceManager.Authorization.Models.RoleManagementApprovalMode Serial { get { throw null; } }
        public static Azure.ResourceManager.Authorization.Models.RoleManagementApprovalMode SingleStage { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Authorization.Models.RoleManagementApprovalMode other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Authorization.Models.RoleManagementApprovalMode left, Azure.ResourceManager.Authorization.Models.RoleManagementApprovalMode right) { throw null; }
        public static implicit operator Azure.ResourceManager.Authorization.Models.RoleManagementApprovalMode (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Authorization.Models.RoleManagementApprovalMode left, Azure.ResourceManager.Authorization.Models.RoleManagementApprovalMode right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class RoleManagementApprovalSettings : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Authorization.Models.RoleManagementApprovalSettings>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.Models.RoleManagementApprovalSettings>
    {
        public RoleManagementApprovalSettings() { }
        public Azure.ResourceManager.Authorization.Models.RoleManagementApprovalMode? ApprovalMode { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Authorization.Models.RoleManagementApprovalStage> ApprovalStages { get { throw null; } }
        public bool? IsApprovalRequired { get { throw null; } set { } }
        public bool? IsApprovalRequiredForExtension { get { throw null; } set { } }
        public bool? IsRequestorJustificationRequired { get { throw null; } set { } }
        Azure.ResourceManager.Authorization.Models.RoleManagementApprovalSettings System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Authorization.Models.RoleManagementApprovalSettings>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Authorization.Models.RoleManagementApprovalSettings>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Authorization.Models.RoleManagementApprovalSettings System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.Models.RoleManagementApprovalSettings>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.Models.RoleManagementApprovalSettings>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.Models.RoleManagementApprovalSettings>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RoleManagementApprovalStage : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Authorization.Models.RoleManagementApprovalStage>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.Models.RoleManagementApprovalStage>
    {
        public RoleManagementApprovalStage() { }
        public int? ApprovalStageTimeOutInDays { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Authorization.Models.RoleManagementUserInfo> EscalationApprovers { get { throw null; } }
        public int? EscalationTimeInMinutes { get { throw null; } set { } }
        public bool? IsApproverJustificationRequired { get { throw null; } set { } }
        public bool? IsEscalationEnabled { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Authorization.Models.RoleManagementUserInfo> PrimaryApprovers { get { throw null; } }
        Azure.ResourceManager.Authorization.Models.RoleManagementApprovalStage System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Authorization.Models.RoleManagementApprovalStage>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Authorization.Models.RoleManagementApprovalStage>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Authorization.Models.RoleManagementApprovalStage System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.Models.RoleManagementApprovalStage>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.Models.RoleManagementApprovalStage>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.Models.RoleManagementApprovalStage>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RoleManagementAssignmentLevel : System.IEquatable<Azure.ResourceManager.Authorization.Models.RoleManagementAssignmentLevel>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RoleManagementAssignmentLevel(string value) { throw null; }
        public static Azure.ResourceManager.Authorization.Models.RoleManagementAssignmentLevel Assignment { get { throw null; } }
        public static Azure.ResourceManager.Authorization.Models.RoleManagementAssignmentLevel Eligibility { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Authorization.Models.RoleManagementAssignmentLevel other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Authorization.Models.RoleManagementAssignmentLevel left, Azure.ResourceManager.Authorization.Models.RoleManagementAssignmentLevel right) { throw null; }
        public static implicit operator Azure.ResourceManager.Authorization.Models.RoleManagementAssignmentLevel (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Authorization.Models.RoleManagementAssignmentLevel left, Azure.ResourceManager.Authorization.Models.RoleManagementAssignmentLevel right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class RoleManagementExpandedProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Authorization.Models.RoleManagementExpandedProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.Models.RoleManagementExpandedProperties>
    {
        internal RoleManagementExpandedProperties() { }
        public string Email { get { throw null; } }
        public string PrincipalDisplayName { get { throw null; } }
        public System.Guid? PrincipalId { get { throw null; } }
        public Azure.ResourceManager.Authorization.Models.RoleManagementPrincipalType? PrincipalType { get { throw null; } }
        public string RoleDefinitionDisplayName { get { throw null; } }
        public Azure.Core.ResourceIdentifier RoleDefinitionId { get { throw null; } }
        public Azure.ResourceManager.Authorization.Models.AuthorizationRoleType? RoleType { get { throw null; } }
        public string ScopeDisplayName { get { throw null; } }
        public Azure.Core.ResourceIdentifier ScopeId { get { throw null; } }
        public Azure.ResourceManager.Authorization.Models.RoleManagementScopeType? ScopeType { get { throw null; } }
        Azure.ResourceManager.Authorization.Models.RoleManagementExpandedProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Authorization.Models.RoleManagementExpandedProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Authorization.Models.RoleManagementExpandedProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Authorization.Models.RoleManagementExpandedProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.Models.RoleManagementExpandedProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.Models.RoleManagementExpandedProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.Models.RoleManagementExpandedProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RoleManagementPolicyApprovalRule : Azure.ResourceManager.Authorization.Models.RoleManagementPolicyRule, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Authorization.Models.RoleManagementPolicyApprovalRule>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.Models.RoleManagementPolicyApprovalRule>
    {
        public RoleManagementPolicyApprovalRule() { }
        public Azure.ResourceManager.Authorization.Models.RoleManagementApprovalSettings Settings { get { throw null; } set { } }
        Azure.ResourceManager.Authorization.Models.RoleManagementPolicyApprovalRule System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Authorization.Models.RoleManagementPolicyApprovalRule>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Authorization.Models.RoleManagementPolicyApprovalRule>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Authorization.Models.RoleManagementPolicyApprovalRule System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.Models.RoleManagementPolicyApprovalRule>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.Models.RoleManagementPolicyApprovalRule>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.Models.RoleManagementPolicyApprovalRule>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RoleManagementPolicyAuthenticationContextRule : Azure.ResourceManager.Authorization.Models.RoleManagementPolicyRule, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Authorization.Models.RoleManagementPolicyAuthenticationContextRule>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.Models.RoleManagementPolicyAuthenticationContextRule>
    {
        public RoleManagementPolicyAuthenticationContextRule() { }
        public string ClaimValue { get { throw null; } set { } }
        public bool? IsEnabled { get { throw null; } set { } }
        Azure.ResourceManager.Authorization.Models.RoleManagementPolicyAuthenticationContextRule System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Authorization.Models.RoleManagementPolicyAuthenticationContextRule>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Authorization.Models.RoleManagementPolicyAuthenticationContextRule>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Authorization.Models.RoleManagementPolicyAuthenticationContextRule System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.Models.RoleManagementPolicyAuthenticationContextRule>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.Models.RoleManagementPolicyAuthenticationContextRule>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.Models.RoleManagementPolicyAuthenticationContextRule>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RoleManagementPolicyEnablementRule : Azure.ResourceManager.Authorization.Models.RoleManagementPolicyRule, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Authorization.Models.RoleManagementPolicyEnablementRule>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.Models.RoleManagementPolicyEnablementRule>
    {
        public RoleManagementPolicyEnablementRule() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.Authorization.Models.RoleAssignmentEnablementRuleType> EnablementRules { get { throw null; } }
        Azure.ResourceManager.Authorization.Models.RoleManagementPolicyEnablementRule System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Authorization.Models.RoleManagementPolicyEnablementRule>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Authorization.Models.RoleManagementPolicyEnablementRule>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Authorization.Models.RoleManagementPolicyEnablementRule System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.Models.RoleManagementPolicyEnablementRule>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.Models.RoleManagementPolicyEnablementRule>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.Models.RoleManagementPolicyEnablementRule>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RoleManagementPolicyExpirationRule : Azure.ResourceManager.Authorization.Models.RoleManagementPolicyRule, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Authorization.Models.RoleManagementPolicyExpirationRule>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.Models.RoleManagementPolicyExpirationRule>
    {
        public RoleManagementPolicyExpirationRule() { }
        public bool? IsExpirationRequired { get { throw null; } set { } }
        public System.TimeSpan? MaximumDuration { get { throw null; } set { } }
        Azure.ResourceManager.Authorization.Models.RoleManagementPolicyExpirationRule System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Authorization.Models.RoleManagementPolicyExpirationRule>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Authorization.Models.RoleManagementPolicyExpirationRule>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Authorization.Models.RoleManagementPolicyExpirationRule System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.Models.RoleManagementPolicyExpirationRule>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.Models.RoleManagementPolicyExpirationRule>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.Models.RoleManagementPolicyExpirationRule>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RoleManagementPolicyNotificationLevel : System.IEquatable<Azure.ResourceManager.Authorization.Models.RoleManagementPolicyNotificationLevel>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RoleManagementPolicyNotificationLevel(string value) { throw null; }
        public static Azure.ResourceManager.Authorization.Models.RoleManagementPolicyNotificationLevel All { get { throw null; } }
        public static Azure.ResourceManager.Authorization.Models.RoleManagementPolicyNotificationLevel Critical { get { throw null; } }
        public static Azure.ResourceManager.Authorization.Models.RoleManagementPolicyNotificationLevel None { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Authorization.Models.RoleManagementPolicyNotificationLevel other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Authorization.Models.RoleManagementPolicyNotificationLevel left, Azure.ResourceManager.Authorization.Models.RoleManagementPolicyNotificationLevel right) { throw null; }
        public static implicit operator Azure.ResourceManager.Authorization.Models.RoleManagementPolicyNotificationLevel (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Authorization.Models.RoleManagementPolicyNotificationLevel left, Azure.ResourceManager.Authorization.Models.RoleManagementPolicyNotificationLevel right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class RoleManagementPolicyNotificationRule : Azure.ResourceManager.Authorization.Models.RoleManagementPolicyRule, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Authorization.Models.RoleManagementPolicyNotificationRule>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.Models.RoleManagementPolicyNotificationRule>
    {
        public RoleManagementPolicyNotificationRule() { }
        public bool? AreDefaultRecipientsEnabled { get { throw null; } set { } }
        public Azure.ResourceManager.Authorization.Models.NotificationDeliveryType? NotificationDeliveryType { get { throw null; } set { } }
        public Azure.ResourceManager.Authorization.Models.RoleManagementPolicyNotificationLevel? NotificationLevel { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> NotificationRecipients { get { throw null; } }
        public Azure.ResourceManager.Authorization.Models.RoleManagementPolicyRecipientType? RecipientType { get { throw null; } set { } }
        Azure.ResourceManager.Authorization.Models.RoleManagementPolicyNotificationRule System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Authorization.Models.RoleManagementPolicyNotificationRule>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Authorization.Models.RoleManagementPolicyNotificationRule>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Authorization.Models.RoleManagementPolicyNotificationRule System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.Models.RoleManagementPolicyNotificationRule>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.Models.RoleManagementPolicyNotificationRule>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.Models.RoleManagementPolicyNotificationRule>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RoleManagementPolicyProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Authorization.Models.RoleManagementPolicyProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.Models.RoleManagementPolicyProperties>
    {
        internal RoleManagementPolicyProperties() { }
        public string ScopeDisplayName { get { throw null; } }
        public Azure.Core.ResourceIdentifier ScopeId { get { throw null; } }
        public Azure.ResourceManager.Authorization.Models.RoleManagementScopeType? ScopeType { get { throw null; } }
        Azure.ResourceManager.Authorization.Models.RoleManagementPolicyProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Authorization.Models.RoleManagementPolicyProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Authorization.Models.RoleManagementPolicyProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Authorization.Models.RoleManagementPolicyProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.Models.RoleManagementPolicyProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.Models.RoleManagementPolicyProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.Models.RoleManagementPolicyProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RoleManagementPolicyRecipientType : System.IEquatable<Azure.ResourceManager.Authorization.Models.RoleManagementPolicyRecipientType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RoleManagementPolicyRecipientType(string value) { throw null; }
        public static Azure.ResourceManager.Authorization.Models.RoleManagementPolicyRecipientType Admin { get { throw null; } }
        public static Azure.ResourceManager.Authorization.Models.RoleManagementPolicyRecipientType Approver { get { throw null; } }
        public static Azure.ResourceManager.Authorization.Models.RoleManagementPolicyRecipientType Requestor { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Authorization.Models.RoleManagementPolicyRecipientType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Authorization.Models.RoleManagementPolicyRecipientType left, Azure.ResourceManager.Authorization.Models.RoleManagementPolicyRecipientType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Authorization.Models.RoleManagementPolicyRecipientType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Authorization.Models.RoleManagementPolicyRecipientType left, Azure.ResourceManager.Authorization.Models.RoleManagementPolicyRecipientType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public abstract partial class RoleManagementPolicyRule : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Authorization.Models.RoleManagementPolicyRule>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.Models.RoleManagementPolicyRule>
    {
        protected RoleManagementPolicyRule() { }
        public string Id { get { throw null; } set { } }
        public Azure.ResourceManager.Authorization.Models.RoleManagementPolicyRuleTarget Target { get { throw null; } set { } }
        Azure.ResourceManager.Authorization.Models.RoleManagementPolicyRule System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Authorization.Models.RoleManagementPolicyRule>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Authorization.Models.RoleManagementPolicyRule>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Authorization.Models.RoleManagementPolicyRule System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.Models.RoleManagementPolicyRule>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.Models.RoleManagementPolicyRule>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.Models.RoleManagementPolicyRule>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RoleManagementPolicyRuleTarget : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Authorization.Models.RoleManagementPolicyRuleTarget>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.Models.RoleManagementPolicyRuleTarget>
    {
        public RoleManagementPolicyRuleTarget() { }
        public string Caller { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> EnforcedSettings { get { throw null; } }
        public System.Collections.Generic.IList<string> InheritableSettings { get { throw null; } }
        public Azure.ResourceManager.Authorization.Models.RoleManagementAssignmentLevel? Level { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Operations { get { throw null; } }
        public System.Collections.Generic.IList<string> TargetObjects { get { throw null; } }
        Azure.ResourceManager.Authorization.Models.RoleManagementPolicyRuleTarget System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Authorization.Models.RoleManagementPolicyRuleTarget>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Authorization.Models.RoleManagementPolicyRuleTarget>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Authorization.Models.RoleManagementPolicyRuleTarget System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.Models.RoleManagementPolicyRuleTarget>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.Models.RoleManagementPolicyRuleTarget>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.Models.RoleManagementPolicyRuleTarget>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RoleManagementPrincipal : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Authorization.Models.RoleManagementPrincipal>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.Models.RoleManagementPrincipal>
    {
        internal RoleManagementPrincipal() { }
        public string DisplayName { get { throw null; } }
        public string Email { get { throw null; } }
        public string Id { get { throw null; } }
        public Azure.ResourceManager.Authorization.Models.RoleManagementPrincipalType? PrincipalType { get { throw null; } }
        Azure.ResourceManager.Authorization.Models.RoleManagementPrincipal System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Authorization.Models.RoleManagementPrincipal>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Authorization.Models.RoleManagementPrincipal>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Authorization.Models.RoleManagementPrincipal System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.Models.RoleManagementPrincipal>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.Models.RoleManagementPrincipal>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.Models.RoleManagementPrincipal>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RoleManagementPrincipalType : System.IEquatable<Azure.ResourceManager.Authorization.Models.RoleManagementPrincipalType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RoleManagementPrincipalType(string value) { throw null; }
        public static Azure.ResourceManager.Authorization.Models.RoleManagementPrincipalType Device { get { throw null; } }
        public static Azure.ResourceManager.Authorization.Models.RoleManagementPrincipalType ForeignGroup { get { throw null; } }
        public static Azure.ResourceManager.Authorization.Models.RoleManagementPrincipalType Group { get { throw null; } }
        public static Azure.ResourceManager.Authorization.Models.RoleManagementPrincipalType ServicePrincipal { get { throw null; } }
        public static Azure.ResourceManager.Authorization.Models.RoleManagementPrincipalType User { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Authorization.Models.RoleManagementPrincipalType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Authorization.Models.RoleManagementPrincipalType left, Azure.ResourceManager.Authorization.Models.RoleManagementPrincipalType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Authorization.Models.RoleManagementPrincipalType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Authorization.Models.RoleManagementPrincipalType left, Azure.ResourceManager.Authorization.Models.RoleManagementPrincipalType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RoleManagementScheduleExpirationType : System.IEquatable<Azure.ResourceManager.Authorization.Models.RoleManagementScheduleExpirationType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RoleManagementScheduleExpirationType(string value) { throw null; }
        public static Azure.ResourceManager.Authorization.Models.RoleManagementScheduleExpirationType AfterDateTime { get { throw null; } }
        public static Azure.ResourceManager.Authorization.Models.RoleManagementScheduleExpirationType AfterDuration { get { throw null; } }
        public static Azure.ResourceManager.Authorization.Models.RoleManagementScheduleExpirationType NoExpiration { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Authorization.Models.RoleManagementScheduleExpirationType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Authorization.Models.RoleManagementScheduleExpirationType left, Azure.ResourceManager.Authorization.Models.RoleManagementScheduleExpirationType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Authorization.Models.RoleManagementScheduleExpirationType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Authorization.Models.RoleManagementScheduleExpirationType left, Azure.ResourceManager.Authorization.Models.RoleManagementScheduleExpirationType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RoleManagementScheduleMemberType : System.IEquatable<Azure.ResourceManager.Authorization.Models.RoleManagementScheduleMemberType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RoleManagementScheduleMemberType(string value) { throw null; }
        public static Azure.ResourceManager.Authorization.Models.RoleManagementScheduleMemberType Direct { get { throw null; } }
        public static Azure.ResourceManager.Authorization.Models.RoleManagementScheduleMemberType Group { get { throw null; } }
        public static Azure.ResourceManager.Authorization.Models.RoleManagementScheduleMemberType Inherited { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Authorization.Models.RoleManagementScheduleMemberType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Authorization.Models.RoleManagementScheduleMemberType left, Azure.ResourceManager.Authorization.Models.RoleManagementScheduleMemberType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Authorization.Models.RoleManagementScheduleMemberType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Authorization.Models.RoleManagementScheduleMemberType left, Azure.ResourceManager.Authorization.Models.RoleManagementScheduleMemberType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RoleManagementScheduleRequestType : System.IEquatable<Azure.ResourceManager.Authorization.Models.RoleManagementScheduleRequestType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RoleManagementScheduleRequestType(string value) { throw null; }
        public static Azure.ResourceManager.Authorization.Models.RoleManagementScheduleRequestType AdminAssign { get { throw null; } }
        public static Azure.ResourceManager.Authorization.Models.RoleManagementScheduleRequestType AdminExtend { get { throw null; } }
        public static Azure.ResourceManager.Authorization.Models.RoleManagementScheduleRequestType AdminRemove { get { throw null; } }
        public static Azure.ResourceManager.Authorization.Models.RoleManagementScheduleRequestType AdminRenew { get { throw null; } }
        public static Azure.ResourceManager.Authorization.Models.RoleManagementScheduleRequestType AdminUpdate { get { throw null; } }
        public static Azure.ResourceManager.Authorization.Models.RoleManagementScheduleRequestType SelfActivate { get { throw null; } }
        public static Azure.ResourceManager.Authorization.Models.RoleManagementScheduleRequestType SelfDeactivate { get { throw null; } }
        public static Azure.ResourceManager.Authorization.Models.RoleManagementScheduleRequestType SelfExtend { get { throw null; } }
        public static Azure.ResourceManager.Authorization.Models.RoleManagementScheduleRequestType SelfRenew { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Authorization.Models.RoleManagementScheduleRequestType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Authorization.Models.RoleManagementScheduleRequestType left, Azure.ResourceManager.Authorization.Models.RoleManagementScheduleRequestType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Authorization.Models.RoleManagementScheduleRequestType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Authorization.Models.RoleManagementScheduleRequestType left, Azure.ResourceManager.Authorization.Models.RoleManagementScheduleRequestType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RoleManagementScheduleStatus : System.IEquatable<Azure.ResourceManager.Authorization.Models.RoleManagementScheduleStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RoleManagementScheduleStatus(string value) { throw null; }
        public static Azure.ResourceManager.Authorization.Models.RoleManagementScheduleStatus Accepted { get { throw null; } }
        public static Azure.ResourceManager.Authorization.Models.RoleManagementScheduleStatus AdminApproved { get { throw null; } }
        public static Azure.ResourceManager.Authorization.Models.RoleManagementScheduleStatus AdminDenied { get { throw null; } }
        public static Azure.ResourceManager.Authorization.Models.RoleManagementScheduleStatus Canceled { get { throw null; } }
        public static Azure.ResourceManager.Authorization.Models.RoleManagementScheduleStatus Denied { get { throw null; } }
        public static Azure.ResourceManager.Authorization.Models.RoleManagementScheduleStatus Failed { get { throw null; } }
        public static Azure.ResourceManager.Authorization.Models.RoleManagementScheduleStatus FailedAsResourceIsLocked { get { throw null; } }
        public static Azure.ResourceManager.Authorization.Models.RoleManagementScheduleStatus Granted { get { throw null; } }
        public static Azure.ResourceManager.Authorization.Models.RoleManagementScheduleStatus Invalid { get { throw null; } }
        public static Azure.ResourceManager.Authorization.Models.RoleManagementScheduleStatus PendingAdminDecision { get { throw null; } }
        public static Azure.ResourceManager.Authorization.Models.RoleManagementScheduleStatus PendingApproval { get { throw null; } }
        public static Azure.ResourceManager.Authorization.Models.RoleManagementScheduleStatus PendingApprovalProvisioning { get { throw null; } }
        public static Azure.ResourceManager.Authorization.Models.RoleManagementScheduleStatus PendingEvaluation { get { throw null; } }
        public static Azure.ResourceManager.Authorization.Models.RoleManagementScheduleStatus PendingExternalProvisioning { get { throw null; } }
        public static Azure.ResourceManager.Authorization.Models.RoleManagementScheduleStatus PendingProvisioning { get { throw null; } }
        public static Azure.ResourceManager.Authorization.Models.RoleManagementScheduleStatus PendingRevocation { get { throw null; } }
        public static Azure.ResourceManager.Authorization.Models.RoleManagementScheduleStatus PendingScheduleCreation { get { throw null; } }
        public static Azure.ResourceManager.Authorization.Models.RoleManagementScheduleStatus Provisioned { get { throw null; } }
        public static Azure.ResourceManager.Authorization.Models.RoleManagementScheduleStatus ProvisioningStarted { get { throw null; } }
        public static Azure.ResourceManager.Authorization.Models.RoleManagementScheduleStatus Revoked { get { throw null; } }
        public static Azure.ResourceManager.Authorization.Models.RoleManagementScheduleStatus ScheduleCreated { get { throw null; } }
        public static Azure.ResourceManager.Authorization.Models.RoleManagementScheduleStatus TimedOut { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Authorization.Models.RoleManagementScheduleStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Authorization.Models.RoleManagementScheduleStatus left, Azure.ResourceManager.Authorization.Models.RoleManagementScheduleStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.Authorization.Models.RoleManagementScheduleStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Authorization.Models.RoleManagementScheduleStatus left, Azure.ResourceManager.Authorization.Models.RoleManagementScheduleStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RoleManagementScopeType : System.IEquatable<Azure.ResourceManager.Authorization.Models.RoleManagementScopeType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RoleManagementScopeType(string value) { throw null; }
        public static Azure.ResourceManager.Authorization.Models.RoleManagementScopeType ManagementGroup { get { throw null; } }
        public static Azure.ResourceManager.Authorization.Models.RoleManagementScopeType ResourceGroup { get { throw null; } }
        public static Azure.ResourceManager.Authorization.Models.RoleManagementScopeType Subscription { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Authorization.Models.RoleManagementScopeType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Authorization.Models.RoleManagementScopeType left, Azure.ResourceManager.Authorization.Models.RoleManagementScopeType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Authorization.Models.RoleManagementScopeType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Authorization.Models.RoleManagementScopeType left, Azure.ResourceManager.Authorization.Models.RoleManagementScopeType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class RoleManagementUserInfo : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Authorization.Models.RoleManagementUserInfo>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.Models.RoleManagementUserInfo>
    {
        public RoleManagementUserInfo() { }
        public string Description { get { throw null; } set { } }
        public string Id { get { throw null; } set { } }
        public bool? IsBackup { get { throw null; } set { } }
        public Azure.ResourceManager.Authorization.Models.RoleManagementUserType? UserType { get { throw null; } set { } }
        Azure.ResourceManager.Authorization.Models.RoleManagementUserInfo System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Authorization.Models.RoleManagementUserInfo>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Authorization.Models.RoleManagementUserInfo>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Authorization.Models.RoleManagementUserInfo System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.Models.RoleManagementUserInfo>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.Models.RoleManagementUserInfo>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.Models.RoleManagementUserInfo>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RoleManagementUserType : System.IEquatable<Azure.ResourceManager.Authorization.Models.RoleManagementUserType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RoleManagementUserType(string value) { throw null; }
        public static Azure.ResourceManager.Authorization.Models.RoleManagementUserType Group { get { throw null; } }
        public static Azure.ResourceManager.Authorization.Models.RoleManagementUserType User { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Authorization.Models.RoleManagementUserType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Authorization.Models.RoleManagementUserType left, Azure.ResourceManager.Authorization.Models.RoleManagementUserType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Authorization.Models.RoleManagementUserType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Authorization.Models.RoleManagementUserType left, Azure.ResourceManager.Authorization.Models.RoleManagementUserType right) { throw null; }
        public override string ToString() { throw null; }
    }
}
