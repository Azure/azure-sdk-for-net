namespace Azure.ResourceManager.Subscription
{
    public partial class BillingAccountPoliciesResponseCollection : Azure.ResourceManager.ArmCollection
    {
        protected BillingAccountPoliciesResponseCollection() { }
        public virtual Azure.Response<bool> Exists(string billingAccountId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string billingAccountId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Subscription.BillingAccountPoliciesResponseResource> Get(string billingAccountId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Subscription.BillingAccountPoliciesResponseResource>> GetAsync(string billingAccountId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class BillingAccountPoliciesResponseData : Azure.ResourceManager.Models.ResourceData
    {
        internal BillingAccountPoliciesResponseData() { }
        public Azure.ResourceManager.Subscription.Models.BillingAccountPoliciesResponseProperties Properties { get { throw null; } }
    }
    public partial class BillingAccountPoliciesResponseResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected BillingAccountPoliciesResponseResource() { }
        public virtual Azure.ResourceManager.Subscription.BillingAccountPoliciesResponseData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string billingAccountId) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Subscription.BillingAccountPoliciesResponseResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Subscription.BillingAccountPoliciesResponseResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class GetTenantPolicyResponseData : Azure.ResourceManager.Models.ResourceData
    {
        internal GetTenantPolicyResponseData() { }
        public Azure.ResourceManager.Subscription.Models.TenantPolicy Properties { get { throw null; } }
    }
    public partial class GetTenantPolicyResponseResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected GetTenantPolicyResponseResource() { }
        public virtual Azure.ResourceManager.Subscription.GetTenantPolicyResponseData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Subscription.GetTenantPolicyResponseResource> CreateOrUpdate(Azure.WaitUntil waitUntil, Azure.ResourceManager.Subscription.Models.GetTenantPolicyResponseCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Subscription.GetTenantPolicyResponseResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Subscription.Models.GetTenantPolicyResponseCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Subscription.GetTenantPolicyResponseResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Subscription.GetTenantPolicyResponseResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SubscriptionAliasResponseCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Subscription.SubscriptionAliasResponseResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Subscription.SubscriptionAliasResponseResource>, System.Collections.IEnumerable
    {
        protected SubscriptionAliasResponseCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Subscription.SubscriptionAliasResponseResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string aliasName, Azure.ResourceManager.Subscription.Models.SubscriptionAliasResponseCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Subscription.SubscriptionAliasResponseResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string aliasName, Azure.ResourceManager.Subscription.Models.SubscriptionAliasResponseCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string aliasName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string aliasName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Subscription.SubscriptionAliasResponseResource> Get(string aliasName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Subscription.SubscriptionAliasResponseResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Subscription.SubscriptionAliasResponseResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Subscription.SubscriptionAliasResponseResource>> GetAsync(string aliasName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Subscription.SubscriptionAliasResponseResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Subscription.SubscriptionAliasResponseResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Subscription.SubscriptionAliasResponseResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Subscription.SubscriptionAliasResponseResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class SubscriptionAliasResponseData : Azure.ResourceManager.Models.ResourceData
    {
        internal SubscriptionAliasResponseData() { }
        public Azure.ResourceManager.Subscription.Models.SubscriptionAliasResponseProperties Properties { get { throw null; } }
    }
    public partial class SubscriptionAliasResponseResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected SubscriptionAliasResponseResource() { }
        public virtual Azure.ResourceManager.Subscription.SubscriptionAliasResponseData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string aliasName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Subscription.SubscriptionAliasResponseResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Subscription.SubscriptionAliasResponseResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Subscription.SubscriptionAliasResponseResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Subscription.Models.SubscriptionAliasResponseCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Subscription.SubscriptionAliasResponseResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Subscription.Models.SubscriptionAliasResponseCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public static partial class SubscriptionExtensions
    {
        public static Azure.Response<Azure.ResourceManager.Subscription.Models.AcceptOwnershipStatusResponse> AcceptOwnershipStatusSubscription(this Azure.ResourceManager.Resources.TenantResource tenantResource, string subscriptionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Subscription.Models.AcceptOwnershipStatusResponse>> AcceptOwnershipStatusSubscriptionAsync(this Azure.ResourceManager.Resources.TenantResource tenantResource, string subscriptionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.ArmOperation AcceptOwnershipSubscription(this Azure.ResourceManager.Resources.TenantResource tenantResource, Azure.WaitUntil waitUntil, string subscriptionId, Azure.ResourceManager.Subscription.Models.AcceptOwnershipContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> AcceptOwnershipSubscriptionAsync(this Azure.ResourceManager.Resources.TenantResource tenantResource, Azure.WaitUntil waitUntil, string subscriptionId, Azure.ResourceManager.Subscription.Models.AcceptOwnershipContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Subscription.Models.CanceledSubscriptionId> CancelSubscription(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Subscription.Models.CanceledSubscriptionId>> CancelSubscriptionAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Subscription.Models.EnabledSubscriptionId> EnableSubscription(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Subscription.Models.EnabledSubscriptionId>> EnableSubscriptionAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Subscription.BillingAccountPoliciesResponseResource> GetBillingAccountPoliciesResponse(this Azure.ResourceManager.Resources.TenantResource tenantResource, string billingAccountId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Subscription.BillingAccountPoliciesResponseResource>> GetBillingAccountPoliciesResponseAsync(this Azure.ResourceManager.Resources.TenantResource tenantResource, string billingAccountId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Subscription.BillingAccountPoliciesResponseResource GetBillingAccountPoliciesResponseResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Subscription.BillingAccountPoliciesResponseCollection GetBillingAccountPoliciesResponses(this Azure.ResourceManager.Resources.TenantResource tenantResource) { throw null; }
        public static Azure.ResourceManager.Subscription.GetTenantPolicyResponseResource GetGetTenantPolicyResponse(this Azure.ResourceManager.Resources.TenantResource tenantResource) { throw null; }
        public static Azure.ResourceManager.Subscription.GetTenantPolicyResponseResource GetGetTenantPolicyResponseResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Subscription.Models.Location> GetLocationsSubscriptions(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Subscription.Models.Location> GetLocationsSubscriptionsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Subscription.Models.Subscription> GetSubscription(this Azure.ResourceManager.Resources.TenantResource tenantResource, string subscriptionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Subscription.SubscriptionAliasResponseResource> GetSubscriptionAliasResponse(this Azure.ResourceManager.Resources.TenantResource tenantResource, string aliasName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Subscription.SubscriptionAliasResponseResource>> GetSubscriptionAliasResponseAsync(this Azure.ResourceManager.Resources.TenantResource tenantResource, string aliasName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Subscription.SubscriptionAliasResponseResource GetSubscriptionAliasResponseResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Subscription.SubscriptionAliasResponseCollection GetSubscriptionAliasResponses(this Azure.ResourceManager.Resources.TenantResource tenantResource) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Subscription.Models.Subscription>> GetSubscriptionAsync(this Azure.ResourceManager.Resources.TenantResource tenantResource, string subscriptionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Subscription.Models.Subscription> GetSubscriptions(this Azure.ResourceManager.Resources.TenantResource tenantResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Subscription.Models.Subscription> GetSubscriptionsAsync(this Azure.ResourceManager.Resources.TenantResource tenantResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Subscription.Models.TenantIdDescription> GetTenants(this Azure.ResourceManager.Resources.TenantResource tenantResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Subscription.Models.TenantIdDescription> GetTenantsAsync(this Azure.ResourceManager.Resources.TenantResource tenantResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Subscription.Models.RenamedSubscriptionId> RenameSubscription(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.ResourceManager.Subscription.Models.SubscriptionName body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Subscription.Models.RenamedSubscriptionId>> RenameSubscriptionAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.ResourceManager.Subscription.Models.SubscriptionName body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.Subscription.Models
{
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AcceptOwnership : System.IEquatable<Azure.ResourceManager.Subscription.Models.AcceptOwnership>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AcceptOwnership(string value) { throw null; }
        public static Azure.ResourceManager.Subscription.Models.AcceptOwnership Completed { get { throw null; } }
        public static Azure.ResourceManager.Subscription.Models.AcceptOwnership Expired { get { throw null; } }
        public static Azure.ResourceManager.Subscription.Models.AcceptOwnership Pending { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Subscription.Models.AcceptOwnership other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Subscription.Models.AcceptOwnership left, Azure.ResourceManager.Subscription.Models.AcceptOwnership right) { throw null; }
        public static implicit operator Azure.ResourceManager.Subscription.Models.AcceptOwnership (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Subscription.Models.AcceptOwnership left, Azure.ResourceManager.Subscription.Models.AcceptOwnership right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class AcceptOwnershipContent
    {
        public AcceptOwnershipContent() { }
        public Azure.ResourceManager.Subscription.Models.AcceptOwnershipRequestProperties Properties { get { throw null; } set { } }
    }
    public partial class AcceptOwnershipRequestProperties
    {
        public AcceptOwnershipRequestProperties(string displayName) { }
        public string DisplayName { get { throw null; } }
        public string ManagementGroupId { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
    }
    public partial class AcceptOwnershipStatusResponse
    {
        internal AcceptOwnershipStatusResponse() { }
        public Azure.ResourceManager.Subscription.Models.AcceptOwnership? AcceptOwnershipState { get { throw null; } }
        public string BillingOwner { get { throw null; } }
        public string DisplayName { get { throw null; } }
        public Azure.ResourceManager.Subscription.Models.Provisioning? ProvisioningState { get { throw null; } }
        public string SubscriptionId { get { throw null; } }
        public string SubscriptionTenantId { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, string> Tags { get { throw null; } }
    }
    public partial class BillingAccountPoliciesResponseProperties
    {
        internal BillingAccountPoliciesResponseProperties() { }
        public bool? AllowTransfers { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Subscription.Models.ServiceTenantResponse> ServiceTenants { get { throw null; } }
    }
    public partial class CanceledSubscriptionId
    {
        internal CanceledSubscriptionId() { }
        public string SubscriptionId { get { throw null; } }
    }
    public partial class EnabledSubscriptionId
    {
        internal EnabledSubscriptionId() { }
        public string SubscriptionId { get { throw null; } }
    }
    public partial class GetTenantPolicyResponseCreateOrUpdateContent
    {
        public GetTenantPolicyResponseCreateOrUpdateContent() { }
        public bool? BlockSubscriptionsIntoTenant { get { throw null; } set { } }
        public bool? BlockSubscriptionsLeavingTenant { get { throw null; } set { } }
        public System.Collections.Generic.IList<System.Guid> ExemptedPrincipals { get { throw null; } }
    }
    public partial class Location
    {
        internal Location() { }
        public string DisplayName { get { throw null; } }
        public string Id { get { throw null; } }
        public string Latitude { get { throw null; } }
        public string Longitude { get { throw null; } }
        public string Name { get { throw null; } }
        public string SubscriptionId { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct Provisioning : System.IEquatable<Azure.ResourceManager.Subscription.Models.Provisioning>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public Provisioning(string value) { throw null; }
        public static Azure.ResourceManager.Subscription.Models.Provisioning Accepted { get { throw null; } }
        public static Azure.ResourceManager.Subscription.Models.Provisioning Pending { get { throw null; } }
        public static Azure.ResourceManager.Subscription.Models.Provisioning Succeeded { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Subscription.Models.Provisioning other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Subscription.Models.Provisioning left, Azure.ResourceManager.Subscription.Models.Provisioning right) { throw null; }
        public static implicit operator Azure.ResourceManager.Subscription.Models.Provisioning (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Subscription.Models.Provisioning left, Azure.ResourceManager.Subscription.Models.Provisioning right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ProvisioningState : System.IEquatable<Azure.ResourceManager.Subscription.Models.ProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.Subscription.Models.ProvisioningState Accepted { get { throw null; } }
        public static Azure.ResourceManager.Subscription.Models.ProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.Subscription.Models.ProvisioningState Succeeded { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Subscription.Models.ProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Subscription.Models.ProvisioningState left, Azure.ResourceManager.Subscription.Models.ProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Subscription.Models.ProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Subscription.Models.ProvisioningState left, Azure.ResourceManager.Subscription.Models.ProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class PutAliasRequestAdditionalProperties
    {
        public PutAliasRequestAdditionalProperties() { }
        public string ManagementGroupId { get { throw null; } set { } }
        public string SubscriptionOwnerId { get { throw null; } set { } }
        public string SubscriptionTenantId { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
    }
    public partial class PutAliasRequestProperties
    {
        public PutAliasRequestProperties() { }
        public Azure.ResourceManager.Subscription.Models.PutAliasRequestAdditionalProperties AdditionalProperties { get { throw null; } set { } }
        public string BillingScope { get { throw null; } set { } }
        public string DisplayName { get { throw null; } set { } }
        public string ResellerId { get { throw null; } set { } }
        public string SubscriptionId { get { throw null; } set { } }
        public Azure.ResourceManager.Subscription.Models.Workload? Workload { get { throw null; } set { } }
    }
    public partial class RenamedSubscriptionId
    {
        internal RenamedSubscriptionId() { }
        public string SubscriptionId { get { throw null; } }
    }
    public partial class ServiceTenantResponse
    {
        internal ServiceTenantResponse() { }
        public System.Guid? TenantId { get { throw null; } }
        public string TenantName { get { throw null; } }
    }
    public enum SpendingLimit
    {
        On = 0,
        Off = 1,
        CurrentPeriodOff = 2,
    }
    public partial class Subscription
    {
        internal Subscription() { }
        public string AuthorizationSource { get { throw null; } }
        public string DisplayName { get { throw null; } }
        public string Id { get { throw null; } }
        public Azure.ResourceManager.Subscription.Models.SubscriptionState? State { get { throw null; } }
        public string SubscriptionId { get { throw null; } }
        public Azure.ResourceManager.Subscription.Models.SubscriptionPolicies SubscriptionPolicies { get { throw null; } }
    }
    public partial class SubscriptionAliasResponseCreateOrUpdateContent
    {
        public SubscriptionAliasResponseCreateOrUpdateContent() { }
        public Azure.ResourceManager.Subscription.Models.PutAliasRequestProperties Properties { get { throw null; } set { } }
    }
    public partial class SubscriptionAliasResponseProperties
    {
        internal SubscriptionAliasResponseProperties() { }
        public Azure.ResourceManager.Subscription.Models.AcceptOwnership? AcceptOwnershipState { get { throw null; } }
        public System.Uri AcceptOwnershipUri { get { throw null; } }
        public string BillingScope { get { throw null; } }
        public string CreatedTime { get { throw null; } }
        public string DisplayName { get { throw null; } }
        public string ManagementGroupId { get { throw null; } }
        public Azure.ResourceManager.Subscription.Models.ProvisioningState? ProvisioningState { get { throw null; } }
        public string ResellerId { get { throw null; } }
        public string SubscriptionId { get { throw null; } }
        public string SubscriptionOwnerId { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, string> Tags { get { throw null; } }
        public Azure.ResourceManager.Subscription.Models.Workload? Workload { get { throw null; } }
    }
    public partial class SubscriptionName
    {
        public SubscriptionName() { }
        public string SubscriptionNameValue { get { throw null; } set { } }
    }
    public partial class SubscriptionPolicies
    {
        internal SubscriptionPolicies() { }
        public string LocationPlacementId { get { throw null; } }
        public string QuotaId { get { throw null; } }
        public Azure.ResourceManager.Subscription.Models.SpendingLimit? SpendingLimit { get { throw null; } }
    }
    public enum SubscriptionState
    {
        Enabled = 0,
        Warned = 1,
        PastDue = 2,
        Disabled = 3,
        Deleted = 4,
    }
    public partial class TenantIdDescription
    {
        internal TenantIdDescription() { }
        public string Id { get { throw null; } }
        public System.Guid? TenantId { get { throw null; } }
    }
    public partial class TenantPolicy
    {
        internal TenantPolicy() { }
        public bool? BlockSubscriptionsIntoTenant { get { throw null; } }
        public bool? BlockSubscriptionsLeavingTenant { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<System.Guid> ExemptedPrincipals { get { throw null; } }
        public string PolicyId { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct Workload : System.IEquatable<Azure.ResourceManager.Subscription.Models.Workload>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public Workload(string value) { throw null; }
        public static Azure.ResourceManager.Subscription.Models.Workload DevTest { get { throw null; } }
        public static Azure.ResourceManager.Subscription.Models.Workload Production { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Subscription.Models.Workload other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Subscription.Models.Workload left, Azure.ResourceManager.Subscription.Models.Workload right) { throw null; }
        public static implicit operator Azure.ResourceManager.Subscription.Models.Workload (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Subscription.Models.Workload left, Azure.ResourceManager.Subscription.Models.Workload right) { throw null; }
        public override string ToString() { throw null; }
    }
}
