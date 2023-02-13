namespace Azure.ResourceManager.ManagedServices
{
    public static partial class ManagedServicesExtensions
    {
        public static Azure.Response<Azure.ResourceManager.ManagedServices.ManagedServicesMarketplaceRegistrationResource> GetManagedServicesMarketplaceRegistration(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, string marketplaceIdentifier, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ManagedServices.ManagedServicesMarketplaceRegistrationResource>> GetManagedServicesMarketplaceRegistrationAsync(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, string marketplaceIdentifier, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.ManagedServices.ManagedServicesMarketplaceRegistrationResource GetManagedServicesMarketplaceRegistrationResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.ManagedServices.ManagedServicesMarketplaceRegistrationCollection GetManagedServicesMarketplaceRegistrations(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope) { throw null; }
        public static Azure.Response<Azure.ResourceManager.ManagedServices.ManagedServicesRegistrationResource> GetManagedServicesRegistration(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, string registrationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.ManagedServices.ManagedServicesRegistrationAssignmentResource> GetManagedServicesRegistrationAssignment(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, string registrationAssignmentId, bool? expandRegistrationDefinition = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ManagedServices.ManagedServicesRegistrationAssignmentResource>> GetManagedServicesRegistrationAssignmentAsync(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, string registrationAssignmentId, bool? expandRegistrationDefinition = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.ManagedServices.ManagedServicesRegistrationAssignmentResource GetManagedServicesRegistrationAssignmentResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.ManagedServices.ManagedServicesRegistrationAssignmentCollection GetManagedServicesRegistrationAssignments(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ManagedServices.ManagedServicesRegistrationResource>> GetManagedServicesRegistrationAsync(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, string registrationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.ManagedServices.ManagedServicesRegistrationResource GetManagedServicesRegistrationResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.ManagedServices.ManagedServicesRegistrationCollection GetManagedServicesRegistrations(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope) { throw null; }
    }
    public partial class ManagedServicesMarketplaceRegistrationCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ManagedServices.ManagedServicesMarketplaceRegistrationResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ManagedServices.ManagedServicesMarketplaceRegistrationResource>, System.Collections.IEnumerable
    {
        protected ManagedServicesMarketplaceRegistrationCollection() { }
        public virtual Azure.Response<bool> Exists(string marketplaceIdentifier, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string marketplaceIdentifier, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ManagedServices.ManagedServicesMarketplaceRegistrationResource> Get(string marketplaceIdentifier, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ManagedServices.ManagedServicesMarketplaceRegistrationResource> GetAll(string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ManagedServices.ManagedServicesMarketplaceRegistrationResource> GetAllAsync(string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ManagedServices.ManagedServicesMarketplaceRegistrationResource>> GetAsync(string marketplaceIdentifier, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ManagedServices.ManagedServicesMarketplaceRegistrationResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ManagedServices.ManagedServicesMarketplaceRegistrationResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ManagedServices.ManagedServicesMarketplaceRegistrationResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ManagedServices.ManagedServicesMarketplaceRegistrationResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ManagedServicesMarketplaceRegistrationData : Azure.ResourceManager.Models.ResourceData
    {
        internal ManagedServicesMarketplaceRegistrationData() { }
        public Azure.ResourceManager.ManagedServices.Models.ManagedServicesPlan Plan { get { throw null; } }
        public Azure.ResourceManager.ManagedServices.Models.ManagedServicesMarketplaceRegistrationProperties Properties { get { throw null; } }
    }
    public partial class ManagedServicesMarketplaceRegistrationResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ManagedServicesMarketplaceRegistrationResource() { }
        public virtual Azure.ResourceManager.ManagedServices.ManagedServicesMarketplaceRegistrationData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string scope, string marketplaceIdentifier) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ManagedServices.ManagedServicesMarketplaceRegistrationResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ManagedServices.ManagedServicesMarketplaceRegistrationResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ManagedServicesRegistrationAssignmentCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ManagedServices.ManagedServicesRegistrationAssignmentResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ManagedServices.ManagedServicesRegistrationAssignmentResource>, System.Collections.IEnumerable
    {
        protected ManagedServicesRegistrationAssignmentCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ManagedServices.ManagedServicesRegistrationAssignmentResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string registrationAssignmentId, Azure.ResourceManager.ManagedServices.ManagedServicesRegistrationAssignmentData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ManagedServices.ManagedServicesRegistrationAssignmentResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string registrationAssignmentId, Azure.ResourceManager.ManagedServices.ManagedServicesRegistrationAssignmentData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string registrationAssignmentId, bool? expandRegistrationDefinition = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string registrationAssignmentId, bool? expandRegistrationDefinition = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ManagedServices.ManagedServicesRegistrationAssignmentResource> Get(string registrationAssignmentId, bool? expandRegistrationDefinition = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ManagedServices.ManagedServicesRegistrationAssignmentResource> GetAll(bool? expandRegistrationDefinition = default(bool?), string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ManagedServices.ManagedServicesRegistrationAssignmentResource> GetAllAsync(bool? expandRegistrationDefinition = default(bool?), string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ManagedServices.ManagedServicesRegistrationAssignmentResource>> GetAsync(string registrationAssignmentId, bool? expandRegistrationDefinition = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ManagedServices.ManagedServicesRegistrationAssignmentResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ManagedServices.ManagedServicesRegistrationAssignmentResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ManagedServices.ManagedServicesRegistrationAssignmentResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ManagedServices.ManagedServicesRegistrationAssignmentResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ManagedServicesRegistrationAssignmentData : Azure.ResourceManager.Models.ResourceData
    {
        public ManagedServicesRegistrationAssignmentData() { }
        public Azure.ResourceManager.ManagedServices.Models.ManagedServicesRegistrationAssignmentProperties Properties { get { throw null; } set { } }
    }
    public partial class ManagedServicesRegistrationAssignmentResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ManagedServicesRegistrationAssignmentResource() { }
        public virtual Azure.ResourceManager.ManagedServices.ManagedServicesRegistrationAssignmentData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string scope, string registrationAssignmentId) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ManagedServices.ManagedServicesRegistrationAssignmentResource> Get(bool? expandRegistrationDefinition = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ManagedServices.ManagedServicesRegistrationAssignmentResource>> GetAsync(bool? expandRegistrationDefinition = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ManagedServices.ManagedServicesRegistrationAssignmentResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.ManagedServices.ManagedServicesRegistrationAssignmentData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ManagedServices.ManagedServicesRegistrationAssignmentResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.ManagedServices.ManagedServicesRegistrationAssignmentData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ManagedServicesRegistrationCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ManagedServices.ManagedServicesRegistrationResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ManagedServices.ManagedServicesRegistrationResource>, System.Collections.IEnumerable
    {
        protected ManagedServicesRegistrationCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ManagedServices.ManagedServicesRegistrationResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string registrationId, Azure.ResourceManager.ManagedServices.ManagedServicesRegistrationData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ManagedServices.ManagedServicesRegistrationResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string registrationId, Azure.ResourceManager.ManagedServices.ManagedServicesRegistrationData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string registrationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string registrationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ManagedServices.ManagedServicesRegistrationResource> Get(string registrationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ManagedServices.ManagedServicesRegistrationResource> GetAll(string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ManagedServices.ManagedServicesRegistrationResource> GetAllAsync(string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ManagedServices.ManagedServicesRegistrationResource>> GetAsync(string registrationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ManagedServices.ManagedServicesRegistrationResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ManagedServices.ManagedServicesRegistrationResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ManagedServices.ManagedServicesRegistrationResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ManagedServices.ManagedServicesRegistrationResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ManagedServicesRegistrationData : Azure.ResourceManager.Models.ResourceData
    {
        public ManagedServicesRegistrationData() { }
        public Azure.ResourceManager.ManagedServices.Models.ManagedServicesPlan Plan { get { throw null; } set { } }
        public Azure.ResourceManager.ManagedServices.Models.ManagedServicesRegistrationProperties Properties { get { throw null; } set { } }
    }
    public partial class ManagedServicesRegistrationResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ManagedServicesRegistrationResource() { }
        public virtual Azure.ResourceManager.ManagedServices.ManagedServicesRegistrationData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string scope, string registrationId) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ManagedServices.ManagedServicesRegistrationResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ManagedServices.ManagedServicesRegistrationResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ManagedServices.ManagedServicesRegistrationResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.ManagedServices.ManagedServicesRegistrationData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ManagedServices.ManagedServicesRegistrationResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.ManagedServices.ManagedServicesRegistrationData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.ManagedServices.Models
{
    public partial class ManagedServicesAuthorization
    {
        public ManagedServicesAuthorization(System.Guid principalId, string roleDefinitionId) { }
        public System.Collections.Generic.IList<System.Guid> DelegatedRoleDefinitionIds { get { throw null; } }
        public System.Guid PrincipalId { get { throw null; } set { } }
        public string PrincipalIdDisplayName { get { throw null; } set { } }
        public string RoleDefinitionId { get { throw null; } set { } }
    }
    public partial class ManagedServicesEligibleApprover
    {
        public ManagedServicesEligibleApprover(System.Guid principalId) { }
        public System.Guid PrincipalId { get { throw null; } set { } }
        public string PrincipalIdDisplayName { get { throw null; } set { } }
    }
    public partial class ManagedServicesEligibleAuthorization
    {
        public ManagedServicesEligibleAuthorization(System.Guid principalId, string roleDefinitionId) { }
        public Azure.ResourceManager.ManagedServices.Models.ManagedServicesJustInTimeAccessPolicy JustInTimeAccessPolicy { get { throw null; } set { } }
        public System.Guid PrincipalId { get { throw null; } set { } }
        public string PrincipalIdDisplayName { get { throw null; } set { } }
        public string RoleDefinitionId { get { throw null; } set { } }
    }
    public partial class ManagedServicesJustInTimeAccessPolicy
    {
        public ManagedServicesJustInTimeAccessPolicy(Azure.ResourceManager.ManagedServices.Models.MultiFactorAuthProvider multiFactorAuthProvider) { }
        public System.Collections.Generic.IList<Azure.ResourceManager.ManagedServices.Models.ManagedServicesEligibleApprover> ManagedByTenantApprovers { get { throw null; } }
        public System.TimeSpan? MaximumActivationDuration { get { throw null; } set { } }
        public Azure.ResourceManager.ManagedServices.Models.MultiFactorAuthProvider MultiFactorAuthProvider { get { throw null; } set { } }
    }
    public partial class ManagedServicesMarketplaceRegistrationProperties
    {
        internal ManagedServicesMarketplaceRegistrationProperties() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.ManagedServices.Models.ManagedServicesAuthorization> Authorizations { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.ManagedServices.Models.ManagedServicesEligibleAuthorization> EligibleAuthorizations { get { throw null; } }
        public System.Guid ManagedByTenantId { get { throw null; } }
        public string OfferDisplayName { get { throw null; } }
        public string PlanDisplayName { get { throw null; } }
        public string PublisherDisplayName { get { throw null; } }
    }
    public partial class ManagedServicesPlan
    {
        public ManagedServicesPlan(string name, string publisher, string product, string version) { }
        public string Name { get { throw null; } set { } }
        public string Product { get { throw null; } set { } }
        public string Publisher { get { throw null; } set { } }
        public string Version { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ManagedServicesProvisioningState : System.IEquatable<Azure.ResourceManager.ManagedServices.Models.ManagedServicesProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ManagedServicesProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.ManagedServices.Models.ManagedServicesProvisioningState Accepted { get { throw null; } }
        public static Azure.ResourceManager.ManagedServices.Models.ManagedServicesProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.ManagedServices.Models.ManagedServicesProvisioningState Created { get { throw null; } }
        public static Azure.ResourceManager.ManagedServices.Models.ManagedServicesProvisioningState Creating { get { throw null; } }
        public static Azure.ResourceManager.ManagedServices.Models.ManagedServicesProvisioningState Deleted { get { throw null; } }
        public static Azure.ResourceManager.ManagedServices.Models.ManagedServicesProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.ManagedServices.Models.ManagedServicesProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.ManagedServices.Models.ManagedServicesProvisioningState NotSpecified { get { throw null; } }
        public static Azure.ResourceManager.ManagedServices.Models.ManagedServicesProvisioningState Ready { get { throw null; } }
        public static Azure.ResourceManager.ManagedServices.Models.ManagedServicesProvisioningState Running { get { throw null; } }
        public static Azure.ResourceManager.ManagedServices.Models.ManagedServicesProvisioningState Succeeded { get { throw null; } }
        public static Azure.ResourceManager.ManagedServices.Models.ManagedServicesProvisioningState Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ManagedServices.Models.ManagedServicesProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ManagedServices.Models.ManagedServicesProvisioningState left, Azure.ResourceManager.ManagedServices.Models.ManagedServicesProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.ManagedServices.Models.ManagedServicesProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ManagedServices.Models.ManagedServicesProvisioningState left, Azure.ResourceManager.ManagedServices.Models.ManagedServicesProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ManagedServicesRegistrationAssignmentProperties
    {
        public ManagedServicesRegistrationAssignmentProperties(Azure.Core.ResourceIdentifier registrationId) { }
        public Azure.ResourceManager.ManagedServices.Models.ManagedServicesProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.ManagedServices.Models.ManagedServicesRegistrationAssignmentRegistrationData RegistrationDefinition { get { throw null; } }
        public Azure.Core.ResourceIdentifier RegistrationId { get { throw null; } set { } }
    }
    public partial class ManagedServicesRegistrationAssignmentRegistrationData : Azure.ResourceManager.Models.ResourceData
    {
        internal ManagedServicesRegistrationAssignmentRegistrationData() { }
        public Azure.ResourceManager.ManagedServices.Models.ManagedServicesPlan Plan { get { throw null; } }
        public Azure.ResourceManager.ManagedServices.Models.ManagedServicesRegistrationAssignmentRegistrationProperties Properties { get { throw null; } }
    }
    public partial class ManagedServicesRegistrationAssignmentRegistrationProperties
    {
        internal ManagedServicesRegistrationAssignmentRegistrationProperties() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.ManagedServices.Models.ManagedServicesAuthorization> Authorizations { get { throw null; } }
        public string Description { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.ManagedServices.Models.ManagedServicesEligibleAuthorization> EligibleAuthorizations { get { throw null; } }
        public System.Guid? ManagedByTenantId { get { throw null; } }
        public string ManagedByTenantName { get { throw null; } }
        public System.Guid? ManageeTenantId { get { throw null; } }
        public string ManageeTenantName { get { throw null; } }
        public Azure.ResourceManager.ManagedServices.Models.ManagedServicesProvisioningState? ProvisioningState { get { throw null; } }
        public string RegistrationDefinitionName { get { throw null; } }
    }
    public partial class ManagedServicesRegistrationProperties
    {
        public ManagedServicesRegistrationProperties(System.Collections.Generic.IEnumerable<Azure.ResourceManager.ManagedServices.Models.ManagedServicesAuthorization> authorizations, System.Guid managedByTenantId) { }
        public System.Collections.Generic.IList<Azure.ResourceManager.ManagedServices.Models.ManagedServicesAuthorization> Authorizations { get { throw null; } }
        public string Description { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ManagedServices.Models.ManagedServicesEligibleAuthorization> EligibleAuthorizations { get { throw null; } }
        public System.Guid ManagedByTenantId { get { throw null; } set { } }
        public string ManagedByTenantName { get { throw null; } }
        public System.Guid? ManageeTenantId { get { throw null; } }
        public string ManageeTenantName { get { throw null; } }
        public Azure.ResourceManager.ManagedServices.Models.ManagedServicesProvisioningState? ProvisioningState { get { throw null; } }
        public string RegistrationDefinitionName { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MultiFactorAuthProvider : System.IEquatable<Azure.ResourceManager.ManagedServices.Models.MultiFactorAuthProvider>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MultiFactorAuthProvider(string value) { throw null; }
        public static Azure.ResourceManager.ManagedServices.Models.MultiFactorAuthProvider Azure { get { throw null; } }
        public static Azure.ResourceManager.ManagedServices.Models.MultiFactorAuthProvider None { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ManagedServices.Models.MultiFactorAuthProvider other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ManagedServices.Models.MultiFactorAuthProvider left, Azure.ResourceManager.ManagedServices.Models.MultiFactorAuthProvider right) { throw null; }
        public static implicit operator Azure.ResourceManager.ManagedServices.Models.MultiFactorAuthProvider (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ManagedServices.Models.MultiFactorAuthProvider left, Azure.ResourceManager.ManagedServices.Models.MultiFactorAuthProvider right) { throw null; }
        public override string ToString() { throw null; }
    }
}
