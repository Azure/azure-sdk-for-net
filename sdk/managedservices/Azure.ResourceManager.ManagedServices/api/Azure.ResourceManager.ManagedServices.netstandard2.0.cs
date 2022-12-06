namespace Azure.ResourceManager.ManagedServices
{
    public static partial class ManagedServicesExtensions
    {
        public static Azure.Response<Azure.ResourceManager.ManagedServices.MarketplaceRegistrationDefinitionResource> GetMarketplaceRegistrationDefinition(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, string marketplaceIdentifier, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ManagedServices.MarketplaceRegistrationDefinitionResource>> GetMarketplaceRegistrationDefinitionAsync(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, string marketplaceIdentifier, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.ManagedServices.MarketplaceRegistrationDefinitionResource GetMarketplaceRegistrationDefinitionResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.ManagedServices.MarketplaceRegistrationDefinitionCollection GetMarketplaceRegistrationDefinitions(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope) { throw null; }
        public static Azure.Response<Azure.ResourceManager.ManagedServices.RegistrationAssignmentResource> GetRegistrationAssignment(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, string registrationAssignmentId, bool? expandRegistrationDefinition = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ManagedServices.RegistrationAssignmentResource>> GetRegistrationAssignmentAsync(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, string registrationAssignmentId, bool? expandRegistrationDefinition = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.ManagedServices.RegistrationAssignmentResource GetRegistrationAssignmentResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.ManagedServices.RegistrationAssignmentCollection GetRegistrationAssignments(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope) { throw null; }
        public static Azure.Response<Azure.ResourceManager.ManagedServices.RegistrationDefinitionResource> GetRegistrationDefinition(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, string registrationDefinitionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ManagedServices.RegistrationDefinitionResource>> GetRegistrationDefinitionAsync(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, string registrationDefinitionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.ManagedServices.RegistrationDefinitionResource GetRegistrationDefinitionResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.ManagedServices.RegistrationDefinitionCollection GetRegistrationDefinitions(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope) { throw null; }
    }
    public partial class MarketplaceRegistrationDefinitionCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ManagedServices.MarketplaceRegistrationDefinitionResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ManagedServices.MarketplaceRegistrationDefinitionResource>, System.Collections.IEnumerable
    {
        protected MarketplaceRegistrationDefinitionCollection() { }
        public virtual Azure.Response<bool> Exists(string marketplaceIdentifier, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string marketplaceIdentifier, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ManagedServices.MarketplaceRegistrationDefinitionResource> Get(string marketplaceIdentifier, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ManagedServices.MarketplaceRegistrationDefinitionResource> GetAll(string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ManagedServices.MarketplaceRegistrationDefinitionResource> GetAllAsync(string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ManagedServices.MarketplaceRegistrationDefinitionResource>> GetAsync(string marketplaceIdentifier, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ManagedServices.MarketplaceRegistrationDefinitionResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ManagedServices.MarketplaceRegistrationDefinitionResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ManagedServices.MarketplaceRegistrationDefinitionResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ManagedServices.MarketplaceRegistrationDefinitionResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class MarketplaceRegistrationDefinitionData : Azure.ResourceManager.Models.ResourceData
    {
        internal MarketplaceRegistrationDefinitionData() { }
        public Azure.ResourceManager.ManagedServices.Models.ManagedServicesPlan Plan { get { throw null; } }
        public Azure.ResourceManager.ManagedServices.Models.MarketplaceRegistrationDefinitionProperties Properties { get { throw null; } }
    }
    public partial class MarketplaceRegistrationDefinitionResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected MarketplaceRegistrationDefinitionResource() { }
        public virtual Azure.ResourceManager.ManagedServices.MarketplaceRegistrationDefinitionData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string scope, string marketplaceIdentifier) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ManagedServices.MarketplaceRegistrationDefinitionResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ManagedServices.MarketplaceRegistrationDefinitionResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class RegistrationAssignmentCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ManagedServices.RegistrationAssignmentResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ManagedServices.RegistrationAssignmentResource>, System.Collections.IEnumerable
    {
        protected RegistrationAssignmentCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ManagedServices.RegistrationAssignmentResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string registrationAssignmentId, Azure.ResourceManager.ManagedServices.RegistrationAssignmentData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ManagedServices.RegistrationAssignmentResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string registrationAssignmentId, Azure.ResourceManager.ManagedServices.RegistrationAssignmentData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string registrationAssignmentId, bool? expandRegistrationDefinition = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string registrationAssignmentId, bool? expandRegistrationDefinition = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ManagedServices.RegistrationAssignmentResource> Get(string registrationAssignmentId, bool? expandRegistrationDefinition = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ManagedServices.RegistrationAssignmentResource> GetAll(bool? expandRegistrationDefinition = default(bool?), string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ManagedServices.RegistrationAssignmentResource> GetAllAsync(bool? expandRegistrationDefinition = default(bool?), string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ManagedServices.RegistrationAssignmentResource>> GetAsync(string registrationAssignmentId, bool? expandRegistrationDefinition = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ManagedServices.RegistrationAssignmentResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ManagedServices.RegistrationAssignmentResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ManagedServices.RegistrationAssignmentResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ManagedServices.RegistrationAssignmentResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class RegistrationAssignmentData : Azure.ResourceManager.Models.ResourceData
    {
        public RegistrationAssignmentData() { }
        public Azure.ResourceManager.ManagedServices.Models.RegistrationAssignmentProperties Properties { get { throw null; } set { } }
    }
    public partial class RegistrationAssignmentResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected RegistrationAssignmentResource() { }
        public virtual Azure.ResourceManager.ManagedServices.RegistrationAssignmentData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string scope, string registrationAssignmentId) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ManagedServices.RegistrationAssignmentResource> Get(bool? expandRegistrationDefinition = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ManagedServices.RegistrationAssignmentResource>> GetAsync(bool? expandRegistrationDefinition = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ManagedServices.RegistrationAssignmentResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.ManagedServices.RegistrationAssignmentData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ManagedServices.RegistrationAssignmentResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.ManagedServices.RegistrationAssignmentData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class RegistrationDefinitionCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ManagedServices.RegistrationDefinitionResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ManagedServices.RegistrationDefinitionResource>, System.Collections.IEnumerable
    {
        protected RegistrationDefinitionCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ManagedServices.RegistrationDefinitionResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string registrationDefinitionId, Azure.ResourceManager.ManagedServices.RegistrationDefinitionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ManagedServices.RegistrationDefinitionResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string registrationDefinitionId, Azure.ResourceManager.ManagedServices.RegistrationDefinitionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string registrationDefinitionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string registrationDefinitionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ManagedServices.RegistrationDefinitionResource> Get(string registrationDefinitionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ManagedServices.RegistrationDefinitionResource> GetAll(string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ManagedServices.RegistrationDefinitionResource> GetAllAsync(string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ManagedServices.RegistrationDefinitionResource>> GetAsync(string registrationDefinitionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ManagedServices.RegistrationDefinitionResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ManagedServices.RegistrationDefinitionResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ManagedServices.RegistrationDefinitionResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ManagedServices.RegistrationDefinitionResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class RegistrationDefinitionData : Azure.ResourceManager.Models.ResourceData
    {
        public RegistrationDefinitionData() { }
        public Azure.ResourceManager.ManagedServices.Models.ManagedServicesPlan Plan { get { throw null; } set { } }
        public Azure.ResourceManager.ManagedServices.Models.RegistrationDefinitionProperties Properties { get { throw null; } set { } }
    }
    public partial class RegistrationDefinitionResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected RegistrationDefinitionResource() { }
        public virtual Azure.ResourceManager.ManagedServices.RegistrationDefinitionData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string scope, string registrationDefinitionId) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ManagedServices.RegistrationDefinitionResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ManagedServices.RegistrationDefinitionResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ManagedServices.RegistrationDefinitionResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.ManagedServices.RegistrationDefinitionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ManagedServices.RegistrationDefinitionResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.ManagedServices.RegistrationDefinitionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.ManagedServices.Models
{
    public partial class Authorization
    {
        public Authorization(string principalId, string roleDefinitionId) { }
        public System.Collections.Generic.IList<System.Guid> DelegatedRoleDefinitionIds { get { throw null; } }
        public string PrincipalId { get { throw null; } set { } }
        public string PrincipalIdDisplayName { get { throw null; } set { } }
        public string RoleDefinitionId { get { throw null; } set { } }
    }
    public partial class EligibleApprover
    {
        public EligibleApprover(string principalId) { }
        public string PrincipalId { get { throw null; } set { } }
        public string PrincipalIdDisplayName { get { throw null; } set { } }
    }
    public partial class EligibleAuthorization
    {
        public EligibleAuthorization(string principalId, string roleDefinitionId) { }
        public Azure.ResourceManager.ManagedServices.Models.JustInTimeAccessPolicy JustInTimeAccessPolicy { get { throw null; } set { } }
        public string PrincipalId { get { throw null; } set { } }
        public string PrincipalIdDisplayName { get { throw null; } set { } }
        public string RoleDefinitionId { get { throw null; } set { } }
    }
    public partial class JustInTimeAccessPolicy
    {
        public JustInTimeAccessPolicy(Azure.ResourceManager.ManagedServices.Models.MultiFactorAuthProvider multiFactorAuthProvider) { }
        public System.Collections.Generic.IList<Azure.ResourceManager.ManagedServices.Models.EligibleApprover> ManagedByTenantApprovers { get { throw null; } }
        public System.TimeSpan? MaximumActivationDuration { get { throw null; } set { } }
        public Azure.ResourceManager.ManagedServices.Models.MultiFactorAuthProvider MultiFactorAuthProvider { get { throw null; } set { } }
    }
    public partial class ManagedServicesPlan
    {
        public ManagedServicesPlan(string name, string publisher, string product, string version) { }
        public string Name { get { throw null; } set { } }
        public string Product { get { throw null; } set { } }
        public string Publisher { get { throw null; } set { } }
        public string Version { get { throw null; } set { } }
    }
    public partial class MarketplaceRegistrationDefinitionProperties
    {
        internal MarketplaceRegistrationDefinitionProperties() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.ManagedServices.Models.Authorization> Authorizations { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.ManagedServices.Models.EligibleAuthorization> EligibleAuthorizations { get { throw null; } }
        public string ManagedByTenantId { get { throw null; } }
        public string OfferDisplayName { get { throw null; } }
        public string PlanDisplayName { get { throw null; } }
        public string PublisherDisplayName { get { throw null; } }
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
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ProvisioningState : System.IEquatable<Azure.ResourceManager.ManagedServices.Models.ProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.ManagedServices.Models.ProvisioningState Accepted { get { throw null; } }
        public static Azure.ResourceManager.ManagedServices.Models.ProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.ManagedServices.Models.ProvisioningState Created { get { throw null; } }
        public static Azure.ResourceManager.ManagedServices.Models.ProvisioningState Creating { get { throw null; } }
        public static Azure.ResourceManager.ManagedServices.Models.ProvisioningState Deleted { get { throw null; } }
        public static Azure.ResourceManager.ManagedServices.Models.ProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.ManagedServices.Models.ProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.ManagedServices.Models.ProvisioningState NotSpecified { get { throw null; } }
        public static Azure.ResourceManager.ManagedServices.Models.ProvisioningState Ready { get { throw null; } }
        public static Azure.ResourceManager.ManagedServices.Models.ProvisioningState Running { get { throw null; } }
        public static Azure.ResourceManager.ManagedServices.Models.ProvisioningState Succeeded { get { throw null; } }
        public static Azure.ResourceManager.ManagedServices.Models.ProvisioningState Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ManagedServices.Models.ProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ManagedServices.Models.ProvisioningState left, Azure.ResourceManager.ManagedServices.Models.ProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.ManagedServices.Models.ProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ManagedServices.Models.ProvisioningState left, Azure.ResourceManager.ManagedServices.Models.ProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class RegistrationAssignmentProperties
    {
        public RegistrationAssignmentProperties(string registrationDefinitionId) { }
        public Azure.ResourceManager.ManagedServices.Models.ProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.ManagedServices.Models.RegistrationAssignmentPropertiesRegistrationDefinition RegistrationDefinition { get { throw null; } }
        public string RegistrationDefinitionId { get { throw null; } set { } }
    }
    public partial class RegistrationAssignmentPropertiesRegistrationDefinition : Azure.ResourceManager.Models.ResourceData
    {
        internal RegistrationAssignmentPropertiesRegistrationDefinition() { }
        public Azure.ResourceManager.ManagedServices.Models.ManagedServicesPlan Plan { get { throw null; } }
        public Azure.ResourceManager.ManagedServices.Models.RegistrationAssignmentPropertiesRegistrationDefinitionProperties Properties { get { throw null; } }
    }
    public partial class RegistrationAssignmentPropertiesRegistrationDefinitionProperties
    {
        internal RegistrationAssignmentPropertiesRegistrationDefinitionProperties() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.ManagedServices.Models.Authorization> Authorizations { get { throw null; } }
        public string Description { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.ManagedServices.Models.EligibleAuthorization> EligibleAuthorizations { get { throw null; } }
        public string ManagedByTenantId { get { throw null; } }
        public string ManagedByTenantName { get { throw null; } }
        public string ManageeTenantId { get { throw null; } }
        public string ManageeTenantName { get { throw null; } }
        public Azure.ResourceManager.ManagedServices.Models.ProvisioningState? ProvisioningState { get { throw null; } }
        public string RegistrationDefinitionName { get { throw null; } }
    }
    public partial class RegistrationDefinitionProperties
    {
        public RegistrationDefinitionProperties(System.Collections.Generic.IEnumerable<Azure.ResourceManager.ManagedServices.Models.Authorization> authorizations, string managedByTenantId) { }
        public System.Collections.Generic.IList<Azure.ResourceManager.ManagedServices.Models.Authorization> Authorizations { get { throw null; } }
        public string Description { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ManagedServices.Models.EligibleAuthorization> EligibleAuthorizations { get { throw null; } }
        public string ManagedByTenantId { get { throw null; } set { } }
        public string ManagedByTenantName { get { throw null; } }
        public string ManageeTenantId { get { throw null; } }
        public string ManageeTenantName { get { throw null; } }
        public Azure.ResourceManager.ManagedServices.Models.ProvisioningState? ProvisioningState { get { throw null; } }
        public string RegistrationDefinitionName { get { throw null; } set { } }
    }
}
