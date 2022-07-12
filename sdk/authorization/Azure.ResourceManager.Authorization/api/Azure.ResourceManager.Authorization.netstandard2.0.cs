namespace Azure.ResourceManager.Authorization
{
    public static partial class AuthorizationExtensions
    {
        public static Azure.Response ElevateAccessGlobalAdministrator(this Azure.ResourceManager.Resources.TenantResource tenantResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response> ElevateAccessGlobalAdministratorAsync(this Azure.ResourceManager.Resources.TenantResource tenantResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Authorization.Models.AzurePermission> GetAzurePermissionsForResourceGroups(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Authorization.Models.AzurePermission> GetAzurePermissionsForResourceGroupsAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Authorization.Models.AzurePermission> GetAzurePermissionsForResources(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string resourceProviderNamespace, string parentResourcePath, string resourceType, string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Authorization.Models.AzurePermission> GetAzurePermissionsForResourcesAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string resourceProviderNamespace, string parentResourcePath, string resourceType, string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Authorization.Models.ClassicAdministrator> GetClassicAdministrators(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Authorization.Models.ClassicAdministrator> GetClassicAdministratorsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Authorization.ProviderOperationsCollection GetProviderOperations(this Azure.ResourceManager.Resources.TenantResource tenantResource) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Authorization.ProviderOperationsResource> GetProviderOperations(this Azure.ResourceManager.Resources.TenantResource tenantResource, string resourceProviderNamespace, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Authorization.ProviderOperationsResource>> GetProviderOperationsAsync(this Azure.ResourceManager.Resources.TenantResource tenantResource, string resourceProviderNamespace, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Authorization.ProviderOperationsResource GetProviderOperationsResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Authorization.RoleAssignmentResource> GetRoleAssignment(this Azure.ResourceManager.ArmResource armResource, string roleAssignmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Authorization.RoleAssignmentResource>> GetRoleAssignmentAsync(this Azure.ResourceManager.ArmResource armResource, string roleAssignmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Authorization.RoleAssignmentResource GetRoleAssignmentResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Authorization.RoleAssignmentCollection GetRoleAssignments(this Azure.ResourceManager.ArmResource armResource) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Authorization.RoleAssignmentScheduleResource> GetRoleAssignmentSchedule(this Azure.ResourceManager.ArmResource armResource, string roleAssignmentScheduleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Authorization.RoleAssignmentScheduleResource>> GetRoleAssignmentScheduleAsync(this Azure.ResourceManager.ArmResource armResource, string roleAssignmentScheduleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Authorization.RoleAssignmentScheduleInstanceResource> GetRoleAssignmentScheduleInstance(this Azure.ResourceManager.ArmResource armResource, string roleAssignmentScheduleInstanceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Authorization.RoleAssignmentScheduleInstanceResource>> GetRoleAssignmentScheduleInstanceAsync(this Azure.ResourceManager.ArmResource armResource, string roleAssignmentScheduleInstanceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Authorization.RoleAssignmentScheduleInstanceResource GetRoleAssignmentScheduleInstanceResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Authorization.RoleAssignmentScheduleInstanceCollection GetRoleAssignmentScheduleInstances(this Azure.ResourceManager.ArmResource armResource) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Authorization.RoleAssignmentScheduleRequestResource> GetRoleAssignmentScheduleRequest(this Azure.ResourceManager.ArmResource armResource, string roleAssignmentScheduleRequestName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Authorization.RoleAssignmentScheduleRequestResource>> GetRoleAssignmentScheduleRequestAsync(this Azure.ResourceManager.ArmResource armResource, string roleAssignmentScheduleRequestName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Authorization.RoleAssignmentScheduleRequestResource GetRoleAssignmentScheduleRequestResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Authorization.RoleAssignmentScheduleRequestCollection GetRoleAssignmentScheduleRequests(this Azure.ResourceManager.ArmResource armResource) { throw null; }
        public static Azure.ResourceManager.Authorization.RoleAssignmentScheduleResource GetRoleAssignmentScheduleResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Authorization.RoleAssignmentScheduleCollection GetRoleAssignmentSchedules(this Azure.ResourceManager.ArmResource armResource) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Authorization.RoleDefinitionResource> GetRoleDefinition(this Azure.ResourceManager.ArmResource armResource, string roleDefinitionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Authorization.RoleDefinitionResource>> GetRoleDefinitionAsync(this Azure.ResourceManager.ArmResource armResource, string roleDefinitionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Authorization.RoleDefinitionResource GetRoleDefinitionResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Authorization.RoleDefinitionCollection GetRoleDefinitions(this Azure.ResourceManager.ArmResource armResource) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Authorization.RoleEligibilityScheduleResource> GetRoleEligibilitySchedule(this Azure.ResourceManager.ArmResource armResource, string roleEligibilityScheduleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Authorization.RoleEligibilityScheduleResource>> GetRoleEligibilityScheduleAsync(this Azure.ResourceManager.ArmResource armResource, string roleEligibilityScheduleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Authorization.RoleEligibilityScheduleInstanceResource> GetRoleEligibilityScheduleInstance(this Azure.ResourceManager.ArmResource armResource, string roleEligibilityScheduleInstanceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Authorization.RoleEligibilityScheduleInstanceResource>> GetRoleEligibilityScheduleInstanceAsync(this Azure.ResourceManager.ArmResource armResource, string roleEligibilityScheduleInstanceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Authorization.RoleEligibilityScheduleInstanceResource GetRoleEligibilityScheduleInstanceResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Authorization.RoleEligibilityScheduleInstanceCollection GetRoleEligibilityScheduleInstances(this Azure.ResourceManager.ArmResource armResource) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Authorization.RoleEligibilityScheduleRequestResource> GetRoleEligibilityScheduleRequest(this Azure.ResourceManager.ArmResource armResource, string roleEligibilityScheduleRequestName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Authorization.RoleEligibilityScheduleRequestResource>> GetRoleEligibilityScheduleRequestAsync(this Azure.ResourceManager.ArmResource armResource, string roleEligibilityScheduleRequestName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Authorization.RoleEligibilityScheduleRequestResource GetRoleEligibilityScheduleRequestResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Authorization.RoleEligibilityScheduleRequestCollection GetRoleEligibilityScheduleRequests(this Azure.ResourceManager.ArmResource armResource) { throw null; }
        public static Azure.ResourceManager.Authorization.RoleEligibilityScheduleResource GetRoleEligibilityScheduleResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Authorization.RoleEligibilityScheduleCollection GetRoleEligibilitySchedules(this Azure.ResourceManager.ArmResource armResource) { throw null; }
        public static Azure.ResourceManager.Authorization.RoleManagementPolicyCollection GetRoleManagementPolicies(this Azure.ResourceManager.ArmResource armResource) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Authorization.RoleManagementPolicyResource> GetRoleManagementPolicy(this Azure.ResourceManager.ArmResource armResource, string roleManagementPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Authorization.RoleManagementPolicyAssignmentResource> GetRoleManagementPolicyAssignment(this Azure.ResourceManager.ArmResource armResource, string roleManagementPolicyAssignmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Authorization.RoleManagementPolicyAssignmentResource>> GetRoleManagementPolicyAssignmentAsync(this Azure.ResourceManager.ArmResource armResource, string roleManagementPolicyAssignmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Authorization.RoleManagementPolicyAssignmentResource GetRoleManagementPolicyAssignmentResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Authorization.RoleManagementPolicyAssignmentCollection GetRoleManagementPolicyAssignments(this Azure.ResourceManager.ArmResource armResource) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Authorization.RoleManagementPolicyResource>> GetRoleManagementPolicyAsync(this Azure.ResourceManager.ArmResource armResource, string roleManagementPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Authorization.RoleManagementPolicyResource GetRoleManagementPolicyResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class ProviderOperationsCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Authorization.ProviderOperationsResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Authorization.ProviderOperationsResource>, System.Collections.IEnumerable
    {
        protected ProviderOperationsCollection() { }
        public virtual Azure.Response<bool> Exists(string resourceProviderNamespace, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string resourceProviderNamespace, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Authorization.ProviderOperationsResource> Get(string resourceProviderNamespace, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Authorization.ProviderOperationsResource> GetAll(string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Authorization.ProviderOperationsResource> GetAllAsync(string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Authorization.ProviderOperationsResource>> GetAsync(string resourceProviderNamespace, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Authorization.ProviderOperationsResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Authorization.ProviderOperationsResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Authorization.ProviderOperationsResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Authorization.ProviderOperationsResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ProviderOperationsData : Azure.ResourceManager.Models.ResourceData
    {
        internal ProviderOperationsData() { }
        public string DisplayName { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Authorization.Models.ProviderOperation> Operations { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Authorization.Models.ProviderOperationsResourceType> ResourceTypes { get { throw null; } }
    }
    public partial class ProviderOperationsResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ProviderOperationsResource() { }
        public virtual Azure.ResourceManager.Authorization.ProviderOperationsData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string resourceProviderNamespace) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Authorization.ProviderOperationsResource> Get(string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Authorization.ProviderOperationsResource>> GetAsync(string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class RoleAssignmentCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Authorization.RoleAssignmentResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Authorization.RoleAssignmentResource>, System.Collections.IEnumerable
    {
        protected RoleAssignmentCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Authorization.RoleAssignmentResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string roleAssignmentName, Azure.ResourceManager.Authorization.Models.RoleAssignmentCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Authorization.RoleAssignmentResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string roleAssignmentName, Azure.ResourceManager.Authorization.Models.RoleAssignmentCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string roleAssignmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string roleAssignmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Authorization.RoleAssignmentResource> Get(string roleAssignmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Authorization.RoleAssignmentResource> GetAll(string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Authorization.RoleAssignmentResource> GetAllAsync(string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Authorization.RoleAssignmentResource>> GetAsync(string roleAssignmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Authorization.RoleAssignmentResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Authorization.RoleAssignmentResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Authorization.RoleAssignmentResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Authorization.RoleAssignmentResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class RoleAssignmentData : Azure.ResourceManager.Models.ResourceData
    {
        internal RoleAssignmentData() { }
        public Azure.ResourceManager.Authorization.Models.RoleAssignmentPropertiesWithScope Properties { get { throw null; } }
    }
    public partial class RoleAssignmentResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected RoleAssignmentResource() { }
        public virtual Azure.ResourceManager.Authorization.RoleAssignmentData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string scope, string roleAssignmentName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Authorization.RoleAssignmentResource> Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Authorization.RoleAssignmentResource>> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Authorization.RoleAssignmentResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Authorization.RoleAssignmentResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Authorization.RoleAssignmentScheduleResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Authorization.RoleAssignmentScheduleResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Authorization.RoleAssignmentScheduleResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Authorization.RoleAssignmentScheduleResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class RoleAssignmentScheduleData : Azure.ResourceManager.Models.ResourceData
    {
        internal RoleAssignmentScheduleData() { }
        public Azure.ResourceManager.Authorization.Models.AssignmentType? AssignmentType { get { throw null; } }
        public string Condition { get { throw null; } }
        public string ConditionVersion { get { throw null; } }
        public System.DateTimeOffset? CreatedOn { get { throw null; } }
        public System.DateTimeOffset? EndOn { get { throw null; } }
        public Azure.ResourceManager.Authorization.Models.ExpandedProperties ExpandedProperties { get { throw null; } }
        public string LinkedRoleEligibilityScheduleId { get { throw null; } }
        public Azure.ResourceManager.Authorization.Models.MemberType? MemberType { get { throw null; } }
        public string PrincipalId { get { throw null; } }
        public Azure.ResourceManager.Authorization.Models.PrincipalType? PrincipalType { get { throw null; } }
        public Azure.Core.ResourceIdentifier RoleAssignmentScheduleRequestId { get { throw null; } }
        public Azure.Core.ResourceIdentifier RoleDefinitionId { get { throw null; } }
        public string Scope { get { throw null; } }
        public System.DateTimeOffset? StartOn { get { throw null; } }
        public Azure.ResourceManager.Authorization.Models.RoleAssignmentScheduleStatus? Status { get { throw null; } }
        public System.DateTimeOffset? UpdatedOn { get { throw null; } }
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
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Authorization.RoleAssignmentScheduleInstanceResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Authorization.RoleAssignmentScheduleInstanceResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Authorization.RoleAssignmentScheduleInstanceResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Authorization.RoleAssignmentScheduleInstanceResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class RoleAssignmentScheduleInstanceData : Azure.ResourceManager.Models.ResourceData
    {
        internal RoleAssignmentScheduleInstanceData() { }
        public Azure.ResourceManager.Authorization.Models.AssignmentType? AssignmentType { get { throw null; } }
        public string Condition { get { throw null; } }
        public string ConditionVersion { get { throw null; } }
        public System.DateTimeOffset? CreatedOn { get { throw null; } }
        public System.DateTimeOffset? EndOn { get { throw null; } }
        public Azure.ResourceManager.Authorization.Models.ExpandedProperties ExpandedProperties { get { throw null; } }
        public string LinkedRoleEligibilityScheduleId { get { throw null; } }
        public string LinkedRoleEligibilityScheduleInstanceId { get { throw null; } }
        public Azure.ResourceManager.Authorization.Models.MemberType? MemberType { get { throw null; } }
        public Azure.Core.ResourceIdentifier OriginRoleAssignmentId { get { throw null; } }
        public string PrincipalId { get { throw null; } }
        public Azure.ResourceManager.Authorization.Models.PrincipalType? PrincipalType { get { throw null; } }
        public Azure.Core.ResourceIdentifier RoleAssignmentScheduleId { get { throw null; } }
        public Azure.Core.ResourceIdentifier RoleDefinitionId { get { throw null; } }
        public string Scope { get { throw null; } }
        public System.DateTimeOffset? StartOn { get { throw null; } }
        public Azure.ResourceManager.Authorization.Models.RoleAssignmentScheduleInstanceStatus? Status { get { throw null; } }
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
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Authorization.RoleAssignmentScheduleRequestResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Authorization.RoleAssignmentScheduleRequestResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Authorization.RoleAssignmentScheduleRequestResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Authorization.RoleAssignmentScheduleRequestResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class RoleAssignmentScheduleRequestData : Azure.ResourceManager.Models.ResourceData
    {
        public RoleAssignmentScheduleRequestData() { }
        public string ApprovalId { get { throw null; } }
        public string Condition { get { throw null; } set { } }
        public string ConditionVersion { get { throw null; } set { } }
        public System.DateTimeOffset? CreatedOn { get { throw null; } }
        public Azure.ResourceManager.Authorization.Models.ExpandedProperties ExpandedProperties { get { throw null; } }
        public string Justification { get { throw null; } set { } }
        public string LinkedRoleEligibilityScheduleId { get { throw null; } set { } }
        public string PrincipalId { get { throw null; } set { } }
        public Azure.ResourceManager.Authorization.Models.PrincipalType? PrincipalType { get { throw null; } }
        public string RequestorId { get { throw null; } }
        public Azure.ResourceManager.Authorization.Models.RequestType? RequestType { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier RoleDefinitionId { get { throw null; } set { } }
        public Azure.ResourceManager.Authorization.Models.RoleAssignmentScheduleInfo ScheduleInfo { get { throw null; } set { } }
        public string Scope { get { throw null; } }
        public Azure.ResourceManager.Authorization.Models.RoleAssignmentScheduleRequestStatus? Status { get { throw null; } }
        public string TargetRoleAssignmentScheduleId { get { throw null; } set { } }
        public string TargetRoleAssignmentScheduleInstanceId { get { throw null; } set { } }
        public Azure.ResourceManager.Authorization.Models.RoleAssignmentScheduleTicketInfo TicketInfo { get { throw null; } set { } }
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
    public partial class RoleDefinitionCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Authorization.RoleDefinitionResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Authorization.RoleDefinitionResource>, System.Collections.IEnumerable
    {
        protected RoleDefinitionCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Authorization.RoleDefinitionResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string roleDefinitionId, Azure.ResourceManager.Authorization.RoleDefinitionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Authorization.RoleDefinitionResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string roleDefinitionId, Azure.ResourceManager.Authorization.RoleDefinitionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string roleDefinitionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string roleDefinitionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Authorization.RoleDefinitionResource> Get(string roleDefinitionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Authorization.RoleDefinitionResource> GetAll(string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Authorization.RoleDefinitionResource> GetAllAsync(string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Authorization.RoleDefinitionResource>> GetAsync(string roleDefinitionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Authorization.RoleDefinitionResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Authorization.RoleDefinitionResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Authorization.RoleDefinitionResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Authorization.RoleDefinitionResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class RoleDefinitionData : Azure.ResourceManager.Models.ResourceData
    {
        public RoleDefinitionData() { }
        public System.Collections.Generic.IList<string> AssignableScopes { get { throw null; } }
        public string Description { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Authorization.Models.AzurePermission> Permissions { get { throw null; } }
        public string RoleName { get { throw null; } set { } }
        public string RoleType { get { throw null; } set { } }
    }
    public partial class RoleDefinitionResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected RoleDefinitionResource() { }
        public virtual Azure.ResourceManager.Authorization.RoleDefinitionData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string scope, string roleDefinitionId) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Authorization.RoleDefinitionResource> Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Authorization.RoleDefinitionResource>> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Authorization.RoleDefinitionResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Authorization.RoleDefinitionResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Authorization.RoleDefinitionResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Authorization.RoleDefinitionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Authorization.RoleDefinitionResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Authorization.RoleDefinitionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Authorization.RoleEligibilityScheduleResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Authorization.RoleEligibilityScheduleResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Authorization.RoleEligibilityScheduleResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Authorization.RoleEligibilityScheduleResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class RoleEligibilityScheduleData : Azure.ResourceManager.Models.ResourceData
    {
        internal RoleEligibilityScheduleData() { }
        public string Condition { get { throw null; } }
        public string ConditionVersion { get { throw null; } }
        public System.DateTimeOffset? CreatedOn { get { throw null; } }
        public System.DateTimeOffset? EndOn { get { throw null; } }
        public Azure.ResourceManager.Authorization.Models.ExpandedProperties ExpandedProperties { get { throw null; } }
        public Azure.ResourceManager.Authorization.Models.MemberType? MemberType { get { throw null; } }
        public string PrincipalId { get { throw null; } }
        public Azure.ResourceManager.Authorization.Models.PrincipalType? PrincipalType { get { throw null; } }
        public Azure.Core.ResourceIdentifier RoleDefinitionId { get { throw null; } }
        public Azure.Core.ResourceIdentifier RoleEligibilityScheduleRequestId { get { throw null; } }
        public string Scope { get { throw null; } }
        public System.DateTimeOffset? StartOn { get { throw null; } }
        public Azure.ResourceManager.Authorization.Models.RoleEligibilityScheduleStatus? Status { get { throw null; } }
        public System.DateTimeOffset? UpdatedOn { get { throw null; } }
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
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Authorization.RoleEligibilityScheduleInstanceResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Authorization.RoleEligibilityScheduleInstanceResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Authorization.RoleEligibilityScheduleInstanceResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Authorization.RoleEligibilityScheduleInstanceResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class RoleEligibilityScheduleInstanceData : Azure.ResourceManager.Models.ResourceData
    {
        internal RoleEligibilityScheduleInstanceData() { }
        public string Condition { get { throw null; } }
        public string ConditionVersion { get { throw null; } }
        public System.DateTimeOffset? CreatedOn { get { throw null; } }
        public System.DateTimeOffset? EndOn { get { throw null; } }
        public Azure.ResourceManager.Authorization.Models.ExpandedProperties ExpandedProperties { get { throw null; } }
        public Azure.ResourceManager.Authorization.Models.MemberType? MemberType { get { throw null; } }
        public string PrincipalId { get { throw null; } }
        public Azure.ResourceManager.Authorization.Models.PrincipalType? PrincipalType { get { throw null; } }
        public Azure.Core.ResourceIdentifier RoleDefinitionId { get { throw null; } }
        public Azure.Core.ResourceIdentifier RoleEligibilityScheduleId { get { throw null; } }
        public string Scope { get { throw null; } }
        public System.DateTimeOffset? StartOn { get { throw null; } }
        public Azure.ResourceManager.Authorization.Models.RoleEligibilityScheduleInstanceStatus? Status { get { throw null; } }
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
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Authorization.RoleEligibilityScheduleRequestResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Authorization.RoleEligibilityScheduleRequestResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Authorization.RoleEligibilityScheduleRequestResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Authorization.RoleEligibilityScheduleRequestResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class RoleEligibilityScheduleRequestData : Azure.ResourceManager.Models.ResourceData
    {
        public RoleEligibilityScheduleRequestData() { }
        public string ApprovalId { get { throw null; } }
        public string Condition { get { throw null; } set { } }
        public string ConditionVersion { get { throw null; } set { } }
        public System.DateTimeOffset? CreatedOn { get { throw null; } }
        public Azure.ResourceManager.Authorization.Models.ExpandedProperties ExpandedProperties { get { throw null; } }
        public string Justification { get { throw null; } set { } }
        public string PrincipalId { get { throw null; } set { } }
        public Azure.ResourceManager.Authorization.Models.PrincipalType? PrincipalType { get { throw null; } }
        public string RequestorId { get { throw null; } }
        public Azure.ResourceManager.Authorization.Models.RequestType? RequestType { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier RoleDefinitionId { get { throw null; } set { } }
        public Azure.ResourceManager.Authorization.Models.RoleEligibilityScheduleRequestPropertiesScheduleInfo ScheduleInfo { get { throw null; } set { } }
        public string Scope { get { throw null; } }
        public Azure.ResourceManager.Authorization.Models.RoleEligibilityScheduleRequestStatus? Status { get { throw null; } }
        public string TargetRoleEligibilityScheduleId { get { throw null; } set { } }
        public string TargetRoleEligibilityScheduleInstanceId { get { throw null; } set { } }
        public Azure.ResourceManager.Authorization.Models.RoleEligibilityScheduleRequestPropertiesTicketInfo TicketInfo { get { throw null; } set { } }
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
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Authorization.RoleManagementPolicyAssignmentResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Authorization.RoleManagementPolicyAssignmentResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Authorization.RoleManagementPolicyAssignmentResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Authorization.RoleManagementPolicyAssignmentResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class RoleManagementPolicyAssignmentData : Azure.ResourceManager.Models.ResourceData
    {
        public RoleManagementPolicyAssignmentData() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Authorization.Models.RoleManagementPolicyRule> EffectiveRules { get { throw null; } }
        public Azure.ResourceManager.Authorization.Models.PolicyAssignmentProperties PolicyAssignmentProperties { get { throw null; } }
        public Azure.Core.ResourceIdentifier PolicyId { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier RoleDefinitionId { get { throw null; } set { } }
        public string Scope { get { throw null; } set { } }
    }
    public partial class RoleManagementPolicyAssignmentResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected RoleManagementPolicyAssignmentResource() { }
        public virtual Azure.ResourceManager.Authorization.RoleManagementPolicyAssignmentData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string scope, string roleManagementPolicyAssignmentName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Authorization.RoleManagementPolicyResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Authorization.RoleManagementPolicyResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Authorization.RoleManagementPolicyResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Authorization.RoleManagementPolicyResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class RoleManagementPolicyData : Azure.ResourceManager.Models.ResourceData
    {
        public RoleManagementPolicyData() { }
        public string Description { get { throw null; } set { } }
        public string DisplayName { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Authorization.Models.RoleManagementPolicyRule> EffectiveRules { get { throw null; } }
        public bool? IsOrganizationDefault { get { throw null; } set { } }
        public Azure.ResourceManager.Authorization.Models.AzurePrincipal LastModifiedBy { get { throw null; } }
        public System.DateTimeOffset? LastModifiedOn { get { throw null; } }
        public Azure.ResourceManager.Authorization.Models.PolicyPropertiesScope PolicyScope { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Authorization.Models.RoleManagementPolicyRule> Rules { get { throw null; } }
        public string Scope { get { throw null; } set { } }
    }
    public partial class RoleManagementPolicyResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected RoleManagementPolicyResource() { }
        public virtual Azure.ResourceManager.Authorization.RoleManagementPolicyData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string scope, string roleManagementPolicyName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Authorization.RoleManagementPolicyResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Authorization.RoleManagementPolicyResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Authorization.RoleManagementPolicyResource> Update(Azure.ResourceManager.Authorization.RoleManagementPolicyData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Authorization.RoleManagementPolicyResource>> UpdateAsync(Azure.ResourceManager.Authorization.RoleManagementPolicyData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.Authorization.Models
{
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ApprovalMode : System.IEquatable<Azure.ResourceManager.Authorization.Models.ApprovalMode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ApprovalMode(string value) { throw null; }
        public static Azure.ResourceManager.Authorization.Models.ApprovalMode NoApproval { get { throw null; } }
        public static Azure.ResourceManager.Authorization.Models.ApprovalMode Parallel { get { throw null; } }
        public static Azure.ResourceManager.Authorization.Models.ApprovalMode Serial { get { throw null; } }
        public static Azure.ResourceManager.Authorization.Models.ApprovalMode SingleStage { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Authorization.Models.ApprovalMode other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Authorization.Models.ApprovalMode left, Azure.ResourceManager.Authorization.Models.ApprovalMode right) { throw null; }
        public static implicit operator Azure.ResourceManager.Authorization.Models.ApprovalMode (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Authorization.Models.ApprovalMode left, Azure.ResourceManager.Authorization.Models.ApprovalMode right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ApprovalSettings
    {
        public ApprovalSettings() { }
        public Azure.ResourceManager.Authorization.Models.ApprovalMode? ApprovalMode { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Authorization.Models.ApprovalStage> ApprovalStages { get { throw null; } }
        public bool? IsApprovalRequired { get { throw null; } set { } }
        public bool? IsApprovalRequiredForExtension { get { throw null; } set { } }
        public bool? IsRequestorJustificationRequired { get { throw null; } set { } }
    }
    public partial class ApprovalStage
    {
        public ApprovalStage() { }
        public int? ApprovalStageTimeOutInDays { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Authorization.Models.UserInfo> EscalationApprovers { get { throw null; } }
        public int? EscalationTimeInMinutes { get { throw null; } set { } }
        public bool? IsApproverJustificationRequired { get { throw null; } set { } }
        public bool? IsEscalationEnabled { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Authorization.Models.UserInfo> PrimaryApprovers { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AssignmentType : System.IEquatable<Azure.ResourceManager.Authorization.Models.AssignmentType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AssignmentType(string value) { throw null; }
        public static Azure.ResourceManager.Authorization.Models.AssignmentType Activated { get { throw null; } }
        public static Azure.ResourceManager.Authorization.Models.AssignmentType Assigned { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Authorization.Models.AssignmentType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Authorization.Models.AssignmentType left, Azure.ResourceManager.Authorization.Models.AssignmentType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Authorization.Models.AssignmentType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Authorization.Models.AssignmentType left, Azure.ResourceManager.Authorization.Models.AssignmentType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class AzurePermission
    {
        public AzurePermission() { }
        public System.Collections.Generic.IList<string> Actions { get { throw null; } }
        public System.Collections.Generic.IList<string> NotActions { get { throw null; } }
    }
    public partial class AzurePrincipal
    {
        internal AzurePrincipal() { }
        public string DisplayName { get { throw null; } }
        public string Email { get { throw null; } }
        public string Id { get { throw null; } }
        public string PrincipalType { get { throw null; } }
    }
    public partial class ClassicAdministrator : Azure.ResourceManager.Models.ResourceData
    {
        internal ClassicAdministrator() { }
        public string EmailAddress { get { throw null; } }
        public string Role { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct EnablementRule : System.IEquatable<Azure.ResourceManager.Authorization.Models.EnablementRule>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public EnablementRule(string value) { throw null; }
        public static Azure.ResourceManager.Authorization.Models.EnablementRule Justification { get { throw null; } }
        public static Azure.ResourceManager.Authorization.Models.EnablementRule MultiFactorAuthentication { get { throw null; } }
        public static Azure.ResourceManager.Authorization.Models.EnablementRule Ticketing { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Authorization.Models.EnablementRule other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Authorization.Models.EnablementRule left, Azure.ResourceManager.Authorization.Models.EnablementRule right) { throw null; }
        public static implicit operator Azure.ResourceManager.Authorization.Models.EnablementRule (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Authorization.Models.EnablementRule left, Azure.ResourceManager.Authorization.Models.EnablementRule right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ExpandedProperties
    {
        internal ExpandedProperties() { }
        public Azure.ResourceManager.Authorization.Models.ExpandedPropertiesPrincipal Principal { get { throw null; } }
        public Azure.ResourceManager.Authorization.Models.ExpandedPropertiesRoleDefinition RoleDefinition { get { throw null; } }
        public Azure.ResourceManager.Authorization.Models.ExpandedPropertiesScope Scope { get { throw null; } }
    }
    public partial class ExpandedPropertiesPrincipal
    {
        internal ExpandedPropertiesPrincipal() { }
        public string DisplayName { get { throw null; } }
        public string Email { get { throw null; } }
        public string ExpandedPropertiesPrincipalType { get { throw null; } }
        public string Id { get { throw null; } }
    }
    public partial class ExpandedPropertiesRoleDefinition
    {
        internal ExpandedPropertiesRoleDefinition() { }
        public string DisplayName { get { throw null; } }
        public string ExpandedPropertiesRoleDefinitionType { get { throw null; } }
        public Azure.Core.ResourceIdentifier Id { get { throw null; } }
    }
    public partial class ExpandedPropertiesScope
    {
        internal ExpandedPropertiesScope() { }
        public string DisplayName { get { throw null; } }
        public string ExpandedPropertiesScopeType { get { throw null; } }
        public Azure.Core.ResourceIdentifier Id { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MemberType : System.IEquatable<Azure.ResourceManager.Authorization.Models.MemberType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MemberType(string value) { throw null; }
        public static Azure.ResourceManager.Authorization.Models.MemberType Direct { get { throw null; } }
        public static Azure.ResourceManager.Authorization.Models.MemberType Group { get { throw null; } }
        public static Azure.ResourceManager.Authorization.Models.MemberType Inherited { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Authorization.Models.MemberType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Authorization.Models.MemberType left, Azure.ResourceManager.Authorization.Models.MemberType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Authorization.Models.MemberType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Authorization.Models.MemberType left, Azure.ResourceManager.Authorization.Models.MemberType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct NotificationDeliveryMechanism : System.IEquatable<Azure.ResourceManager.Authorization.Models.NotificationDeliveryMechanism>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public NotificationDeliveryMechanism(string value) { throw null; }
        public static Azure.ResourceManager.Authorization.Models.NotificationDeliveryMechanism Email { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Authorization.Models.NotificationDeliveryMechanism other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Authorization.Models.NotificationDeliveryMechanism left, Azure.ResourceManager.Authorization.Models.NotificationDeliveryMechanism right) { throw null; }
        public static implicit operator Azure.ResourceManager.Authorization.Models.NotificationDeliveryMechanism (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Authorization.Models.NotificationDeliveryMechanism left, Azure.ResourceManager.Authorization.Models.NotificationDeliveryMechanism right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct NotificationLevel : System.IEquatable<Azure.ResourceManager.Authorization.Models.NotificationLevel>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public NotificationLevel(string value) { throw null; }
        public static Azure.ResourceManager.Authorization.Models.NotificationLevel All { get { throw null; } }
        public static Azure.ResourceManager.Authorization.Models.NotificationLevel Critical { get { throw null; } }
        public static Azure.ResourceManager.Authorization.Models.NotificationLevel None { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Authorization.Models.NotificationLevel other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Authorization.Models.NotificationLevel left, Azure.ResourceManager.Authorization.Models.NotificationLevel right) { throw null; }
        public static implicit operator Azure.ResourceManager.Authorization.Models.NotificationLevel (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Authorization.Models.NotificationLevel left, Azure.ResourceManager.Authorization.Models.NotificationLevel right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class PolicyAssignmentProperties
    {
        internal PolicyAssignmentProperties() { }
        public Azure.ResourceManager.Authorization.Models.PolicyAssignmentPropertiesPolicy Policy { get { throw null; } }
        public Azure.ResourceManager.Authorization.Models.PolicyAssignmentPropertiesRoleDefinition RoleDefinition { get { throw null; } }
        public Azure.ResourceManager.Authorization.Models.PolicyAssignmentPropertiesScope Scope { get { throw null; } }
    }
    public partial class PolicyAssignmentPropertiesPolicy
    {
        internal PolicyAssignmentPropertiesPolicy() { }
        public Azure.Core.ResourceIdentifier Id { get { throw null; } }
        public Azure.ResourceManager.Authorization.Models.AzurePrincipal LastModifiedBy { get { throw null; } }
        public System.DateTimeOffset? LastModifiedOn { get { throw null; } }
    }
    public partial class PolicyAssignmentPropertiesRoleDefinition
    {
        internal PolicyAssignmentPropertiesRoleDefinition() { }
        public string DisplayName { get { throw null; } }
        public Azure.Core.ResourceIdentifier Id { get { throw null; } }
        public string PolicyAssignmentPropertiesRoleDefinitionType { get { throw null; } }
    }
    public partial class PolicyAssignmentPropertiesScope
    {
        internal PolicyAssignmentPropertiesScope() { }
        public string DisplayName { get { throw null; } }
        public Azure.Core.ResourceIdentifier Id { get { throw null; } }
        public string PolicyAssignmentPropertiesScopeType { get { throw null; } }
    }
    public partial class PolicyPropertiesScope
    {
        internal PolicyPropertiesScope() { }
        public string DisplayName { get { throw null; } }
        public Azure.Core.ResourceIdentifier Id { get { throw null; } }
        public string PolicyPropertiesScopeType { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PrincipalType : System.IEquatable<Azure.ResourceManager.Authorization.Models.PrincipalType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PrincipalType(string value) { throw null; }
        public static Azure.ResourceManager.Authorization.Models.PrincipalType Device { get { throw null; } }
        public static Azure.ResourceManager.Authorization.Models.PrincipalType ForeignGroup { get { throw null; } }
        public static Azure.ResourceManager.Authorization.Models.PrincipalType Group { get { throw null; } }
        public static Azure.ResourceManager.Authorization.Models.PrincipalType ServicePrincipal { get { throw null; } }
        public static Azure.ResourceManager.Authorization.Models.PrincipalType User { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Authorization.Models.PrincipalType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Authorization.Models.PrincipalType left, Azure.ResourceManager.Authorization.Models.PrincipalType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Authorization.Models.PrincipalType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Authorization.Models.PrincipalType left, Azure.ResourceManager.Authorization.Models.PrincipalType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ProviderOperation
    {
        internal ProviderOperation() { }
        public string Description { get { throw null; } }
        public string DisplayName { get { throw null; } }
        public string Name { get { throw null; } }
        public string Origin { get { throw null; } }
        public System.BinaryData Properties { get { throw null; } }
    }
    public partial class ProviderOperationsResourceType
    {
        internal ProviderOperationsResourceType() { }
        public string DisplayName { get { throw null; } }
        public string Name { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Authorization.Models.ProviderOperation> Operations { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RecipientType : System.IEquatable<Azure.ResourceManager.Authorization.Models.RecipientType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RecipientType(string value) { throw null; }
        public static Azure.ResourceManager.Authorization.Models.RecipientType Admin { get { throw null; } }
        public static Azure.ResourceManager.Authorization.Models.RecipientType Approver { get { throw null; } }
        public static Azure.ResourceManager.Authorization.Models.RecipientType Requestor { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Authorization.Models.RecipientType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Authorization.Models.RecipientType left, Azure.ResourceManager.Authorization.Models.RecipientType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Authorization.Models.RecipientType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Authorization.Models.RecipientType left, Azure.ResourceManager.Authorization.Models.RecipientType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RequestType : System.IEquatable<Azure.ResourceManager.Authorization.Models.RequestType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RequestType(string value) { throw null; }
        public static Azure.ResourceManager.Authorization.Models.RequestType AdminAssign { get { throw null; } }
        public static Azure.ResourceManager.Authorization.Models.RequestType AdminExtend { get { throw null; } }
        public static Azure.ResourceManager.Authorization.Models.RequestType AdminRemove { get { throw null; } }
        public static Azure.ResourceManager.Authorization.Models.RequestType AdminRenew { get { throw null; } }
        public static Azure.ResourceManager.Authorization.Models.RequestType AdminUpdate { get { throw null; } }
        public static Azure.ResourceManager.Authorization.Models.RequestType SelfActivate { get { throw null; } }
        public static Azure.ResourceManager.Authorization.Models.RequestType SelfDeactivate { get { throw null; } }
        public static Azure.ResourceManager.Authorization.Models.RequestType SelfExtend { get { throw null; } }
        public static Azure.ResourceManager.Authorization.Models.RequestType SelfRenew { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Authorization.Models.RequestType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Authorization.Models.RequestType left, Azure.ResourceManager.Authorization.Models.RequestType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Authorization.Models.RequestType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Authorization.Models.RequestType left, Azure.ResourceManager.Authorization.Models.RequestType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class RoleAssignmentCreateOrUpdateContent
    {
        public RoleAssignmentCreateOrUpdateContent(Azure.ResourceManager.Authorization.Models.RoleAssignmentProperties properties) { }
        public Azure.ResourceManager.Authorization.Models.RoleAssignmentProperties Properties { get { throw null; } }
    }
    public partial class RoleAssignmentProperties
    {
        public RoleAssignmentProperties(string roleDefinitionId, string principalId) { }
        public string PrincipalId { get { throw null; } }
        public string RoleDefinitionId { get { throw null; } }
    }
    public partial class RoleAssignmentPropertiesWithScope
    {
        internal RoleAssignmentPropertiesWithScope() { }
        public string PrincipalId { get { throw null; } }
        public Azure.Core.ResourceIdentifier RoleDefinitionId { get { throw null; } }
        public string Scope { get { throw null; } }
    }
    public partial class RoleAssignmentScheduleInfo
    {
        public RoleAssignmentScheduleInfo() { }
        public Azure.ResourceManager.Authorization.Models.RoleAssignmentScheduleInfoExpiration Expiration { get { throw null; } set { } }
        public System.DateTimeOffset? StartOn { get { throw null; } set { } }
    }
    public partial class RoleAssignmentScheduleInfoExpiration
    {
        public RoleAssignmentScheduleInfoExpiration() { }
        public string Duration { get { throw null; } set { } }
        public System.DateTimeOffset? EndOn { get { throw null; } set { } }
        public Azure.ResourceManager.Authorization.Models.RoleAssignmentScheduleType? RoleAssignmentExpirationType { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RoleAssignmentScheduleInstanceStatus : System.IEquatable<Azure.ResourceManager.Authorization.Models.RoleAssignmentScheduleInstanceStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RoleAssignmentScheduleInstanceStatus(string value) { throw null; }
        public static Azure.ResourceManager.Authorization.Models.RoleAssignmentScheduleInstanceStatus Accepted { get { throw null; } }
        public static Azure.ResourceManager.Authorization.Models.RoleAssignmentScheduleInstanceStatus AdminApproved { get { throw null; } }
        public static Azure.ResourceManager.Authorization.Models.RoleAssignmentScheduleInstanceStatus AdminDenied { get { throw null; } }
        public static Azure.ResourceManager.Authorization.Models.RoleAssignmentScheduleInstanceStatus Canceled { get { throw null; } }
        public static Azure.ResourceManager.Authorization.Models.RoleAssignmentScheduleInstanceStatus Denied { get { throw null; } }
        public static Azure.ResourceManager.Authorization.Models.RoleAssignmentScheduleInstanceStatus Failed { get { throw null; } }
        public static Azure.ResourceManager.Authorization.Models.RoleAssignmentScheduleInstanceStatus FailedAsResourceIsLocked { get { throw null; } }
        public static Azure.ResourceManager.Authorization.Models.RoleAssignmentScheduleInstanceStatus Granted { get { throw null; } }
        public static Azure.ResourceManager.Authorization.Models.RoleAssignmentScheduleInstanceStatus Invalid { get { throw null; } }
        public static Azure.ResourceManager.Authorization.Models.RoleAssignmentScheduleInstanceStatus PendingAdminDecision { get { throw null; } }
        public static Azure.ResourceManager.Authorization.Models.RoleAssignmentScheduleInstanceStatus PendingApproval { get { throw null; } }
        public static Azure.ResourceManager.Authorization.Models.RoleAssignmentScheduleInstanceStatus PendingApprovalProvisioning { get { throw null; } }
        public static Azure.ResourceManager.Authorization.Models.RoleAssignmentScheduleInstanceStatus PendingEvaluation { get { throw null; } }
        public static Azure.ResourceManager.Authorization.Models.RoleAssignmentScheduleInstanceStatus PendingExternalProvisioning { get { throw null; } }
        public static Azure.ResourceManager.Authorization.Models.RoleAssignmentScheduleInstanceStatus PendingProvisioning { get { throw null; } }
        public static Azure.ResourceManager.Authorization.Models.RoleAssignmentScheduleInstanceStatus PendingRevocation { get { throw null; } }
        public static Azure.ResourceManager.Authorization.Models.RoleAssignmentScheduleInstanceStatus PendingScheduleCreation { get { throw null; } }
        public static Azure.ResourceManager.Authorization.Models.RoleAssignmentScheduleInstanceStatus Provisioned { get { throw null; } }
        public static Azure.ResourceManager.Authorization.Models.RoleAssignmentScheduleInstanceStatus ProvisioningStarted { get { throw null; } }
        public static Azure.ResourceManager.Authorization.Models.RoleAssignmentScheduleInstanceStatus Revoked { get { throw null; } }
        public static Azure.ResourceManager.Authorization.Models.RoleAssignmentScheduleInstanceStatus ScheduleCreated { get { throw null; } }
        public static Azure.ResourceManager.Authorization.Models.RoleAssignmentScheduleInstanceStatus TimedOut { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Authorization.Models.RoleAssignmentScheduleInstanceStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Authorization.Models.RoleAssignmentScheduleInstanceStatus left, Azure.ResourceManager.Authorization.Models.RoleAssignmentScheduleInstanceStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.Authorization.Models.RoleAssignmentScheduleInstanceStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Authorization.Models.RoleAssignmentScheduleInstanceStatus left, Azure.ResourceManager.Authorization.Models.RoleAssignmentScheduleInstanceStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RoleAssignmentScheduleRequestStatus : System.IEquatable<Azure.ResourceManager.Authorization.Models.RoleAssignmentScheduleRequestStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RoleAssignmentScheduleRequestStatus(string value) { throw null; }
        public static Azure.ResourceManager.Authorization.Models.RoleAssignmentScheduleRequestStatus Accepted { get { throw null; } }
        public static Azure.ResourceManager.Authorization.Models.RoleAssignmentScheduleRequestStatus AdminApproved { get { throw null; } }
        public static Azure.ResourceManager.Authorization.Models.RoleAssignmentScheduleRequestStatus AdminDenied { get { throw null; } }
        public static Azure.ResourceManager.Authorization.Models.RoleAssignmentScheduleRequestStatus Canceled { get { throw null; } }
        public static Azure.ResourceManager.Authorization.Models.RoleAssignmentScheduleRequestStatus Denied { get { throw null; } }
        public static Azure.ResourceManager.Authorization.Models.RoleAssignmentScheduleRequestStatus Failed { get { throw null; } }
        public static Azure.ResourceManager.Authorization.Models.RoleAssignmentScheduleRequestStatus FailedAsResourceIsLocked { get { throw null; } }
        public static Azure.ResourceManager.Authorization.Models.RoleAssignmentScheduleRequestStatus Granted { get { throw null; } }
        public static Azure.ResourceManager.Authorization.Models.RoleAssignmentScheduleRequestStatus Invalid { get { throw null; } }
        public static Azure.ResourceManager.Authorization.Models.RoleAssignmentScheduleRequestStatus PendingAdminDecision { get { throw null; } }
        public static Azure.ResourceManager.Authorization.Models.RoleAssignmentScheduleRequestStatus PendingApproval { get { throw null; } }
        public static Azure.ResourceManager.Authorization.Models.RoleAssignmentScheduleRequestStatus PendingApprovalProvisioning { get { throw null; } }
        public static Azure.ResourceManager.Authorization.Models.RoleAssignmentScheduleRequestStatus PendingEvaluation { get { throw null; } }
        public static Azure.ResourceManager.Authorization.Models.RoleAssignmentScheduleRequestStatus PendingExternalProvisioning { get { throw null; } }
        public static Azure.ResourceManager.Authorization.Models.RoleAssignmentScheduleRequestStatus PendingProvisioning { get { throw null; } }
        public static Azure.ResourceManager.Authorization.Models.RoleAssignmentScheduleRequestStatus PendingRevocation { get { throw null; } }
        public static Azure.ResourceManager.Authorization.Models.RoleAssignmentScheduleRequestStatus PendingScheduleCreation { get { throw null; } }
        public static Azure.ResourceManager.Authorization.Models.RoleAssignmentScheduleRequestStatus Provisioned { get { throw null; } }
        public static Azure.ResourceManager.Authorization.Models.RoleAssignmentScheduleRequestStatus ProvisioningStarted { get { throw null; } }
        public static Azure.ResourceManager.Authorization.Models.RoleAssignmentScheduleRequestStatus Revoked { get { throw null; } }
        public static Azure.ResourceManager.Authorization.Models.RoleAssignmentScheduleRequestStatus ScheduleCreated { get { throw null; } }
        public static Azure.ResourceManager.Authorization.Models.RoleAssignmentScheduleRequestStatus TimedOut { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Authorization.Models.RoleAssignmentScheduleRequestStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Authorization.Models.RoleAssignmentScheduleRequestStatus left, Azure.ResourceManager.Authorization.Models.RoleAssignmentScheduleRequestStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.Authorization.Models.RoleAssignmentScheduleRequestStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Authorization.Models.RoleAssignmentScheduleRequestStatus left, Azure.ResourceManager.Authorization.Models.RoleAssignmentScheduleRequestStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RoleAssignmentScheduleStatus : System.IEquatable<Azure.ResourceManager.Authorization.Models.RoleAssignmentScheduleStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RoleAssignmentScheduleStatus(string value) { throw null; }
        public static Azure.ResourceManager.Authorization.Models.RoleAssignmentScheduleStatus Accepted { get { throw null; } }
        public static Azure.ResourceManager.Authorization.Models.RoleAssignmentScheduleStatus AdminApproved { get { throw null; } }
        public static Azure.ResourceManager.Authorization.Models.RoleAssignmentScheduleStatus AdminDenied { get { throw null; } }
        public static Azure.ResourceManager.Authorization.Models.RoleAssignmentScheduleStatus Canceled { get { throw null; } }
        public static Azure.ResourceManager.Authorization.Models.RoleAssignmentScheduleStatus Denied { get { throw null; } }
        public static Azure.ResourceManager.Authorization.Models.RoleAssignmentScheduleStatus Failed { get { throw null; } }
        public static Azure.ResourceManager.Authorization.Models.RoleAssignmentScheduleStatus FailedAsResourceIsLocked { get { throw null; } }
        public static Azure.ResourceManager.Authorization.Models.RoleAssignmentScheduleStatus Granted { get { throw null; } }
        public static Azure.ResourceManager.Authorization.Models.RoleAssignmentScheduleStatus Invalid { get { throw null; } }
        public static Azure.ResourceManager.Authorization.Models.RoleAssignmentScheduleStatus PendingAdminDecision { get { throw null; } }
        public static Azure.ResourceManager.Authorization.Models.RoleAssignmentScheduleStatus PendingApproval { get { throw null; } }
        public static Azure.ResourceManager.Authorization.Models.RoleAssignmentScheduleStatus PendingApprovalProvisioning { get { throw null; } }
        public static Azure.ResourceManager.Authorization.Models.RoleAssignmentScheduleStatus PendingEvaluation { get { throw null; } }
        public static Azure.ResourceManager.Authorization.Models.RoleAssignmentScheduleStatus PendingExternalProvisioning { get { throw null; } }
        public static Azure.ResourceManager.Authorization.Models.RoleAssignmentScheduleStatus PendingProvisioning { get { throw null; } }
        public static Azure.ResourceManager.Authorization.Models.RoleAssignmentScheduleStatus PendingRevocation { get { throw null; } }
        public static Azure.ResourceManager.Authorization.Models.RoleAssignmentScheduleStatus PendingScheduleCreation { get { throw null; } }
        public static Azure.ResourceManager.Authorization.Models.RoleAssignmentScheduleStatus Provisioned { get { throw null; } }
        public static Azure.ResourceManager.Authorization.Models.RoleAssignmentScheduleStatus ProvisioningStarted { get { throw null; } }
        public static Azure.ResourceManager.Authorization.Models.RoleAssignmentScheduleStatus Revoked { get { throw null; } }
        public static Azure.ResourceManager.Authorization.Models.RoleAssignmentScheduleStatus ScheduleCreated { get { throw null; } }
        public static Azure.ResourceManager.Authorization.Models.RoleAssignmentScheduleStatus TimedOut { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Authorization.Models.RoleAssignmentScheduleStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Authorization.Models.RoleAssignmentScheduleStatus left, Azure.ResourceManager.Authorization.Models.RoleAssignmentScheduleStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.Authorization.Models.RoleAssignmentScheduleStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Authorization.Models.RoleAssignmentScheduleStatus left, Azure.ResourceManager.Authorization.Models.RoleAssignmentScheduleStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class RoleAssignmentScheduleTicketInfo
    {
        public RoleAssignmentScheduleTicketInfo() { }
        public string TicketNumber { get { throw null; } set { } }
        public string TicketSystem { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RoleAssignmentScheduleType : System.IEquatable<Azure.ResourceManager.Authorization.Models.RoleAssignmentScheduleType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RoleAssignmentScheduleType(string value) { throw null; }
        public static Azure.ResourceManager.Authorization.Models.RoleAssignmentScheduleType AfterDateTime { get { throw null; } }
        public static Azure.ResourceManager.Authorization.Models.RoleAssignmentScheduleType AfterDuration { get { throw null; } }
        public static Azure.ResourceManager.Authorization.Models.RoleAssignmentScheduleType NoExpiration { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Authorization.Models.RoleAssignmentScheduleType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Authorization.Models.RoleAssignmentScheduleType left, Azure.ResourceManager.Authorization.Models.RoleAssignmentScheduleType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Authorization.Models.RoleAssignmentScheduleType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Authorization.Models.RoleAssignmentScheduleType left, Azure.ResourceManager.Authorization.Models.RoleAssignmentScheduleType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RoleEligibilityScheduleInstanceStatus : System.IEquatable<Azure.ResourceManager.Authorization.Models.RoleEligibilityScheduleInstanceStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RoleEligibilityScheduleInstanceStatus(string value) { throw null; }
        public static Azure.ResourceManager.Authorization.Models.RoleEligibilityScheduleInstanceStatus Accepted { get { throw null; } }
        public static Azure.ResourceManager.Authorization.Models.RoleEligibilityScheduleInstanceStatus AdminApproved { get { throw null; } }
        public static Azure.ResourceManager.Authorization.Models.RoleEligibilityScheduleInstanceStatus AdminDenied { get { throw null; } }
        public static Azure.ResourceManager.Authorization.Models.RoleEligibilityScheduleInstanceStatus Canceled { get { throw null; } }
        public static Azure.ResourceManager.Authorization.Models.RoleEligibilityScheduleInstanceStatus Denied { get { throw null; } }
        public static Azure.ResourceManager.Authorization.Models.RoleEligibilityScheduleInstanceStatus Failed { get { throw null; } }
        public static Azure.ResourceManager.Authorization.Models.RoleEligibilityScheduleInstanceStatus FailedAsResourceIsLocked { get { throw null; } }
        public static Azure.ResourceManager.Authorization.Models.RoleEligibilityScheduleInstanceStatus Granted { get { throw null; } }
        public static Azure.ResourceManager.Authorization.Models.RoleEligibilityScheduleInstanceStatus Invalid { get { throw null; } }
        public static Azure.ResourceManager.Authorization.Models.RoleEligibilityScheduleInstanceStatus PendingAdminDecision { get { throw null; } }
        public static Azure.ResourceManager.Authorization.Models.RoleEligibilityScheduleInstanceStatus PendingApproval { get { throw null; } }
        public static Azure.ResourceManager.Authorization.Models.RoleEligibilityScheduleInstanceStatus PendingApprovalProvisioning { get { throw null; } }
        public static Azure.ResourceManager.Authorization.Models.RoleEligibilityScheduleInstanceStatus PendingEvaluation { get { throw null; } }
        public static Azure.ResourceManager.Authorization.Models.RoleEligibilityScheduleInstanceStatus PendingExternalProvisioning { get { throw null; } }
        public static Azure.ResourceManager.Authorization.Models.RoleEligibilityScheduleInstanceStatus PendingProvisioning { get { throw null; } }
        public static Azure.ResourceManager.Authorization.Models.RoleEligibilityScheduleInstanceStatus PendingRevocation { get { throw null; } }
        public static Azure.ResourceManager.Authorization.Models.RoleEligibilityScheduleInstanceStatus PendingScheduleCreation { get { throw null; } }
        public static Azure.ResourceManager.Authorization.Models.RoleEligibilityScheduleInstanceStatus Provisioned { get { throw null; } }
        public static Azure.ResourceManager.Authorization.Models.RoleEligibilityScheduleInstanceStatus ProvisioningStarted { get { throw null; } }
        public static Azure.ResourceManager.Authorization.Models.RoleEligibilityScheduleInstanceStatus Revoked { get { throw null; } }
        public static Azure.ResourceManager.Authorization.Models.RoleEligibilityScheduleInstanceStatus ScheduleCreated { get { throw null; } }
        public static Azure.ResourceManager.Authorization.Models.RoleEligibilityScheduleInstanceStatus TimedOut { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Authorization.Models.RoleEligibilityScheduleInstanceStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Authorization.Models.RoleEligibilityScheduleInstanceStatus left, Azure.ResourceManager.Authorization.Models.RoleEligibilityScheduleInstanceStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.Authorization.Models.RoleEligibilityScheduleInstanceStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Authorization.Models.RoleEligibilityScheduleInstanceStatus left, Azure.ResourceManager.Authorization.Models.RoleEligibilityScheduleInstanceStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class RoleEligibilityScheduleRequestPropertiesScheduleInfo
    {
        public RoleEligibilityScheduleRequestPropertiesScheduleInfo() { }
        public Azure.ResourceManager.Authorization.Models.RoleEligibilityScheduleRequestPropertiesScheduleInfoExpiration Expiration { get { throw null; } set { } }
        public System.DateTimeOffset? StartOn { get { throw null; } set { } }
    }
    public partial class RoleEligibilityScheduleRequestPropertiesScheduleInfoExpiration
    {
        public RoleEligibilityScheduleRequestPropertiesScheduleInfoExpiration() { }
        public string Duration { get { throw null; } set { } }
        public System.DateTimeOffset? EndOn { get { throw null; } set { } }
        public Azure.ResourceManager.Authorization.Models.RoleEligibilityScheduleType? RoleEligibilityExpirationType { get { throw null; } set { } }
    }
    public partial class RoleEligibilityScheduleRequestPropertiesTicketInfo
    {
        public RoleEligibilityScheduleRequestPropertiesTicketInfo() { }
        public string TicketNumber { get { throw null; } set { } }
        public string TicketSystem { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RoleEligibilityScheduleRequestStatus : System.IEquatable<Azure.ResourceManager.Authorization.Models.RoleEligibilityScheduleRequestStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RoleEligibilityScheduleRequestStatus(string value) { throw null; }
        public static Azure.ResourceManager.Authorization.Models.RoleEligibilityScheduleRequestStatus Accepted { get { throw null; } }
        public static Azure.ResourceManager.Authorization.Models.RoleEligibilityScheduleRequestStatus AdminApproved { get { throw null; } }
        public static Azure.ResourceManager.Authorization.Models.RoleEligibilityScheduleRequestStatus AdminDenied { get { throw null; } }
        public static Azure.ResourceManager.Authorization.Models.RoleEligibilityScheduleRequestStatus Canceled { get { throw null; } }
        public static Azure.ResourceManager.Authorization.Models.RoleEligibilityScheduleRequestStatus Denied { get { throw null; } }
        public static Azure.ResourceManager.Authorization.Models.RoleEligibilityScheduleRequestStatus Failed { get { throw null; } }
        public static Azure.ResourceManager.Authorization.Models.RoleEligibilityScheduleRequestStatus FailedAsResourceIsLocked { get { throw null; } }
        public static Azure.ResourceManager.Authorization.Models.RoleEligibilityScheduleRequestStatus Granted { get { throw null; } }
        public static Azure.ResourceManager.Authorization.Models.RoleEligibilityScheduleRequestStatus Invalid { get { throw null; } }
        public static Azure.ResourceManager.Authorization.Models.RoleEligibilityScheduleRequestStatus PendingAdminDecision { get { throw null; } }
        public static Azure.ResourceManager.Authorization.Models.RoleEligibilityScheduleRequestStatus PendingApproval { get { throw null; } }
        public static Azure.ResourceManager.Authorization.Models.RoleEligibilityScheduleRequestStatus PendingApprovalProvisioning { get { throw null; } }
        public static Azure.ResourceManager.Authorization.Models.RoleEligibilityScheduleRequestStatus PendingEvaluation { get { throw null; } }
        public static Azure.ResourceManager.Authorization.Models.RoleEligibilityScheduleRequestStatus PendingExternalProvisioning { get { throw null; } }
        public static Azure.ResourceManager.Authorization.Models.RoleEligibilityScheduleRequestStatus PendingProvisioning { get { throw null; } }
        public static Azure.ResourceManager.Authorization.Models.RoleEligibilityScheduleRequestStatus PendingRevocation { get { throw null; } }
        public static Azure.ResourceManager.Authorization.Models.RoleEligibilityScheduleRequestStatus PendingScheduleCreation { get { throw null; } }
        public static Azure.ResourceManager.Authorization.Models.RoleEligibilityScheduleRequestStatus Provisioned { get { throw null; } }
        public static Azure.ResourceManager.Authorization.Models.RoleEligibilityScheduleRequestStatus ProvisioningStarted { get { throw null; } }
        public static Azure.ResourceManager.Authorization.Models.RoleEligibilityScheduleRequestStatus Revoked { get { throw null; } }
        public static Azure.ResourceManager.Authorization.Models.RoleEligibilityScheduleRequestStatus ScheduleCreated { get { throw null; } }
        public static Azure.ResourceManager.Authorization.Models.RoleEligibilityScheduleRequestStatus TimedOut { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Authorization.Models.RoleEligibilityScheduleRequestStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Authorization.Models.RoleEligibilityScheduleRequestStatus left, Azure.ResourceManager.Authorization.Models.RoleEligibilityScheduleRequestStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.Authorization.Models.RoleEligibilityScheduleRequestStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Authorization.Models.RoleEligibilityScheduleRequestStatus left, Azure.ResourceManager.Authorization.Models.RoleEligibilityScheduleRequestStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RoleEligibilityScheduleStatus : System.IEquatable<Azure.ResourceManager.Authorization.Models.RoleEligibilityScheduleStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RoleEligibilityScheduleStatus(string value) { throw null; }
        public static Azure.ResourceManager.Authorization.Models.RoleEligibilityScheduleStatus Accepted { get { throw null; } }
        public static Azure.ResourceManager.Authorization.Models.RoleEligibilityScheduleStatus AdminApproved { get { throw null; } }
        public static Azure.ResourceManager.Authorization.Models.RoleEligibilityScheduleStatus AdminDenied { get { throw null; } }
        public static Azure.ResourceManager.Authorization.Models.RoleEligibilityScheduleStatus Canceled { get { throw null; } }
        public static Azure.ResourceManager.Authorization.Models.RoleEligibilityScheduleStatus Denied { get { throw null; } }
        public static Azure.ResourceManager.Authorization.Models.RoleEligibilityScheduleStatus Failed { get { throw null; } }
        public static Azure.ResourceManager.Authorization.Models.RoleEligibilityScheduleStatus FailedAsResourceIsLocked { get { throw null; } }
        public static Azure.ResourceManager.Authorization.Models.RoleEligibilityScheduleStatus Granted { get { throw null; } }
        public static Azure.ResourceManager.Authorization.Models.RoleEligibilityScheduleStatus Invalid { get { throw null; } }
        public static Azure.ResourceManager.Authorization.Models.RoleEligibilityScheduleStatus PendingAdminDecision { get { throw null; } }
        public static Azure.ResourceManager.Authorization.Models.RoleEligibilityScheduleStatus PendingApproval { get { throw null; } }
        public static Azure.ResourceManager.Authorization.Models.RoleEligibilityScheduleStatus PendingApprovalProvisioning { get { throw null; } }
        public static Azure.ResourceManager.Authorization.Models.RoleEligibilityScheduleStatus PendingEvaluation { get { throw null; } }
        public static Azure.ResourceManager.Authorization.Models.RoleEligibilityScheduleStatus PendingExternalProvisioning { get { throw null; } }
        public static Azure.ResourceManager.Authorization.Models.RoleEligibilityScheduleStatus PendingProvisioning { get { throw null; } }
        public static Azure.ResourceManager.Authorization.Models.RoleEligibilityScheduleStatus PendingRevocation { get { throw null; } }
        public static Azure.ResourceManager.Authorization.Models.RoleEligibilityScheduleStatus PendingScheduleCreation { get { throw null; } }
        public static Azure.ResourceManager.Authorization.Models.RoleEligibilityScheduleStatus Provisioned { get { throw null; } }
        public static Azure.ResourceManager.Authorization.Models.RoleEligibilityScheduleStatus ProvisioningStarted { get { throw null; } }
        public static Azure.ResourceManager.Authorization.Models.RoleEligibilityScheduleStatus Revoked { get { throw null; } }
        public static Azure.ResourceManager.Authorization.Models.RoleEligibilityScheduleStatus ScheduleCreated { get { throw null; } }
        public static Azure.ResourceManager.Authorization.Models.RoleEligibilityScheduleStatus TimedOut { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Authorization.Models.RoleEligibilityScheduleStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Authorization.Models.RoleEligibilityScheduleStatus left, Azure.ResourceManager.Authorization.Models.RoleEligibilityScheduleStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.Authorization.Models.RoleEligibilityScheduleStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Authorization.Models.RoleEligibilityScheduleStatus left, Azure.ResourceManager.Authorization.Models.RoleEligibilityScheduleStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RoleEligibilityScheduleType : System.IEquatable<Azure.ResourceManager.Authorization.Models.RoleEligibilityScheduleType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RoleEligibilityScheduleType(string value) { throw null; }
        public static Azure.ResourceManager.Authorization.Models.RoleEligibilityScheduleType AfterDateTime { get { throw null; } }
        public static Azure.ResourceManager.Authorization.Models.RoleEligibilityScheduleType AfterDuration { get { throw null; } }
        public static Azure.ResourceManager.Authorization.Models.RoleEligibilityScheduleType NoExpiration { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Authorization.Models.RoleEligibilityScheduleType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Authorization.Models.RoleEligibilityScheduleType left, Azure.ResourceManager.Authorization.Models.RoleEligibilityScheduleType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Authorization.Models.RoleEligibilityScheduleType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Authorization.Models.RoleEligibilityScheduleType left, Azure.ResourceManager.Authorization.Models.RoleEligibilityScheduleType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class RoleManagementPolicyApprovalRule : Azure.ResourceManager.Authorization.Models.RoleManagementPolicyRule
    {
        public RoleManagementPolicyApprovalRule() { }
        public Azure.ResourceManager.Authorization.Models.ApprovalSettings Setting { get { throw null; } set { } }
    }
    public partial class RoleManagementPolicyAuthenticationContextRule : Azure.ResourceManager.Authorization.Models.RoleManagementPolicyRule
    {
        public RoleManagementPolicyAuthenticationContextRule() { }
        public string ClaimValue { get { throw null; } set { } }
        public bool? IsEnabled { get { throw null; } set { } }
    }
    public partial class RoleManagementPolicyEnablementRule : Azure.ResourceManager.Authorization.Models.RoleManagementPolicyRule
    {
        public RoleManagementPolicyEnablementRule() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.Authorization.Models.EnablementRule> EnabledRules { get { throw null; } }
    }
    public partial class RoleManagementPolicyExpirationRule : Azure.ResourceManager.Authorization.Models.RoleManagementPolicyRule
    {
        public RoleManagementPolicyExpirationRule() { }
        public bool? IsExpirationRequired { get { throw null; } set { } }
        public string MaximumDuration { get { throw null; } set { } }
    }
    public partial class RoleManagementPolicyNotificationRule : Azure.ResourceManager.Authorization.Models.RoleManagementPolicyRule
    {
        public RoleManagementPolicyNotificationRule() { }
        public bool? IsDefaultRecipientsEnabled { get { throw null; } set { } }
        public Azure.ResourceManager.Authorization.Models.NotificationLevel? NotificationLevel { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> NotificationRecipients { get { throw null; } }
        public Azure.ResourceManager.Authorization.Models.NotificationDeliveryMechanism? NotificationType { get { throw null; } set { } }
        public Azure.ResourceManager.Authorization.Models.RecipientType? RecipientType { get { throw null; } set { } }
    }
    public partial class RoleManagementPolicyRule
    {
        public RoleManagementPolicyRule() { }
        public Azure.Core.ResourceIdentifier Id { get { throw null; } set { } }
        public Azure.ResourceManager.Authorization.Models.RoleManagementPolicyRuleTarget Target { get { throw null; } set { } }
    }
    public partial class RoleManagementPolicyRuleTarget
    {
        public RoleManagementPolicyRuleTarget() { }
        public string Caller { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> EnforcedSettings { get { throw null; } }
        public System.Collections.Generic.IList<string> InheritableSettings { get { throw null; } }
        public string Level { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Operations { get { throw null; } }
        public System.Collections.Generic.IList<string> TargetObjects { get { throw null; } }
    }
    public partial class UserInfo
    {
        public UserInfo() { }
        public string Description { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier Id { get { throw null; } set { } }
        public bool? IsBackup { get { throw null; } set { } }
        public Azure.ResourceManager.Authorization.Models.UserType? UserType { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct UserType : System.IEquatable<Azure.ResourceManager.Authorization.Models.UserType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public UserType(string value) { throw null; }
        public static Azure.ResourceManager.Authorization.Models.UserType Group { get { throw null; } }
        public static Azure.ResourceManager.Authorization.Models.UserType User { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Authorization.Models.UserType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Authorization.Models.UserType left, Azure.ResourceManager.Authorization.Models.UserType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Authorization.Models.UserType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Authorization.Models.UserType left, Azure.ResourceManager.Authorization.Models.UserType right) { throw null; }
        public override string ToString() { throw null; }
    }
}
