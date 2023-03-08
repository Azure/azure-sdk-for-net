namespace Azure.ResourceManager.Subscription
{
    public partial class BillingAccountPolicyCollection : Azure.ResourceManager.ArmCollection
    {
        protected BillingAccountPolicyCollection() { }
        public virtual Azure.Response<bool> Exists(string billingAccountId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string billingAccountId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Subscription.BillingAccountPolicyResource> Get(string billingAccountId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Subscription.BillingAccountPolicyResource>> GetAsync(string billingAccountId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class BillingAccountPolicyData : Azure.ResourceManager.Models.ResourceData
    {
        internal BillingAccountPolicyData() { }
        public Azure.ResourceManager.Subscription.Models.BillingAccountPolicyProperties Properties { get { throw null; } }
    }
    public partial class BillingAccountPolicyResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected BillingAccountPolicyResource() { }
        public virtual Azure.ResourceManager.Subscription.BillingAccountPolicyData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string billingAccountId) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Subscription.BillingAccountPolicyResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Subscription.BillingAccountPolicyResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SubscriptionAliasCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Subscription.SubscriptionAliasResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Subscription.SubscriptionAliasResource>, System.Collections.IEnumerable
    {
        protected SubscriptionAliasCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Subscription.SubscriptionAliasResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string aliasName, Azure.ResourceManager.Subscription.Models.SubscriptionAliasCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Subscription.SubscriptionAliasResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string aliasName, Azure.ResourceManager.Subscription.Models.SubscriptionAliasCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string aliasName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string aliasName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Subscription.SubscriptionAliasResource> Get(string aliasName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Subscription.SubscriptionAliasResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Subscription.SubscriptionAliasResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Subscription.SubscriptionAliasResource>> GetAsync(string aliasName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Subscription.SubscriptionAliasResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Subscription.SubscriptionAliasResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Subscription.SubscriptionAliasResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Subscription.SubscriptionAliasResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class SubscriptionAliasData : Azure.ResourceManager.Models.ResourceData
    {
        internal SubscriptionAliasData() { }
        public Azure.ResourceManager.Subscription.Models.SubscriptionAliasProperties Properties { get { throw null; } }
    }
    public partial class SubscriptionAliasResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected SubscriptionAliasResource() { }
        public virtual Azure.ResourceManager.Subscription.SubscriptionAliasData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string aliasName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Subscription.SubscriptionAliasResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Subscription.SubscriptionAliasResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Subscription.SubscriptionAliasResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Subscription.Models.SubscriptionAliasCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Subscription.SubscriptionAliasResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Subscription.Models.SubscriptionAliasCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public static partial class SubscriptionExtensions
    {
        public static Azure.ResourceManager.ArmOperation AcceptSubscriptionOwnership(this Azure.ResourceManager.Resources.TenantResource tenantResource, Azure.WaitUntil waitUntil, string subscriptionId, Azure.ResourceManager.Subscription.Models.AcceptOwnershipContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> AcceptSubscriptionOwnershipAsync(this Azure.ResourceManager.Resources.TenantResource tenantResource, Azure.WaitUntil waitUntil, string subscriptionId, Azure.ResourceManager.Subscription.Models.AcceptOwnershipContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Subscription.Models.CanceledSubscriptionId> CancelSubscription(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Subscription.Models.CanceledSubscriptionId>> CancelSubscriptionAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Subscription.Models.EnabledSubscriptionId> EnableSubscription(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Subscription.Models.EnabledSubscriptionId>> EnableSubscriptionAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Subscription.Models.AcceptOwnershipStatus> GetAcceptOwnershipStatus(this Azure.ResourceManager.Resources.TenantResource tenantResource, string subscriptionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Subscription.Models.AcceptOwnershipStatus>> GetAcceptOwnershipStatusAsync(this Azure.ResourceManager.Resources.TenantResource tenantResource, string subscriptionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Subscription.BillingAccountPolicyCollection GetBillingAccountPolicies(this Azure.ResourceManager.Resources.TenantResource tenantResource) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Subscription.BillingAccountPolicyResource> GetBillingAccountPolicy(this Azure.ResourceManager.Resources.TenantResource tenantResource, string billingAccountId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Subscription.BillingAccountPolicyResource>> GetBillingAccountPolicyAsync(this Azure.ResourceManager.Resources.TenantResource tenantResource, string billingAccountId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Subscription.BillingAccountPolicyResource GetBillingAccountPolicyResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Subscription.SubscriptionAliasResource> GetSubscriptionAlias(this Azure.ResourceManager.Resources.TenantResource tenantResource, string aliasName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Subscription.SubscriptionAliasResource>> GetSubscriptionAliasAsync(this Azure.ResourceManager.Resources.TenantResource tenantResource, string aliasName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Subscription.SubscriptionAliasCollection GetSubscriptionAliases(this Azure.ResourceManager.Resources.TenantResource tenantResource) { throw null; }
        public static Azure.ResourceManager.Subscription.SubscriptionAliasResource GetSubscriptionAliasResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Subscription.TenantPolicyResource GetTenantPolicy(this Azure.ResourceManager.Resources.TenantResource tenantResource) { throw null; }
        public static Azure.ResourceManager.Subscription.TenantPolicyResource GetTenantPolicyResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Subscription.Models.RenamedSubscriptionId> RenameSubscription(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.ResourceManager.Subscription.Models.SubscriptionName body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Subscription.Models.RenamedSubscriptionId>> RenameSubscriptionAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.ResourceManager.Subscription.Models.SubscriptionName body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class TenantPolicyData : Azure.ResourceManager.Models.ResourceData
    {
        internal TenantPolicyData() { }
        public Azure.ResourceManager.Subscription.Models.TenantPolicyProperties Properties { get { throw null; } }
    }
    public partial class TenantPolicyResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected TenantPolicyResource() { }
        public virtual Azure.ResourceManager.Subscription.TenantPolicyData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Subscription.TenantPolicyResource> CreateOrUpdate(Azure.WaitUntil waitUntil, Azure.ResourceManager.Subscription.Models.TenantPolicyCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Subscription.TenantPolicyResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Subscription.Models.TenantPolicyCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Subscription.TenantPolicyResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Subscription.TenantPolicyResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.Subscription.Mock
{
    public partial class SubscriptionResourceExtensionClient : Azure.ResourceManager.ArmResource
    {
        protected SubscriptionResourceExtensionClient() { }
        public virtual Azure.Response<Azure.ResourceManager.Subscription.Models.CanceledSubscriptionId> CancelSubscription(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Subscription.Models.CanceledSubscriptionId>> CancelSubscriptionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Subscription.Models.EnabledSubscriptionId> EnableSubscription(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Subscription.Models.EnabledSubscriptionId>> EnableSubscriptionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Subscription.Models.RenamedSubscriptionId> RenameSubscription(Azure.ResourceManager.Subscription.Models.SubscriptionName body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Subscription.Models.RenamedSubscriptionId>> RenameSubscriptionAsync(Azure.ResourceManager.Subscription.Models.SubscriptionName body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class TenantResourceExtensionClient : Azure.ResourceManager.ArmResource
    {
        protected TenantResourceExtensionClient() { }
        public virtual Azure.ResourceManager.ArmOperation AcceptSubscriptionOwnership(Azure.WaitUntil waitUntil, string subscriptionId, Azure.ResourceManager.Subscription.Models.AcceptOwnershipContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> AcceptSubscriptionOwnershipAsync(Azure.WaitUntil waitUntil, string subscriptionId, Azure.ResourceManager.Subscription.Models.AcceptOwnershipContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Subscription.Models.AcceptOwnershipStatus> GetAcceptOwnershipStatus(string subscriptionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Subscription.Models.AcceptOwnershipStatus>> GetAcceptOwnershipStatusAsync(string subscriptionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Subscription.BillingAccountPolicyCollection GetBillingAccountPolicies() { throw null; }
        public virtual Azure.ResourceManager.Subscription.SubscriptionAliasCollection GetSubscriptionAliases() { throw null; }
        public virtual Azure.ResourceManager.Subscription.TenantPolicyResource GetTenantPolicy() { throw null; }
    }
}
namespace Azure.ResourceManager.Subscription.Models
{
    public partial class AcceptOwnershipContent
    {
        public AcceptOwnershipContent() { }
        public Azure.ResourceManager.Subscription.Models.AcceptOwnershipRequestProperties Properties { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AcceptOwnershipProvisioningState : System.IEquatable<Azure.ResourceManager.Subscription.Models.AcceptOwnershipProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AcceptOwnershipProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.Subscription.Models.AcceptOwnershipProvisioningState Accepted { get { throw null; } }
        public static Azure.ResourceManager.Subscription.Models.AcceptOwnershipProvisioningState Pending { get { throw null; } }
        public static Azure.ResourceManager.Subscription.Models.AcceptOwnershipProvisioningState Succeeded { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Subscription.Models.AcceptOwnershipProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Subscription.Models.AcceptOwnershipProvisioningState left, Azure.ResourceManager.Subscription.Models.AcceptOwnershipProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Subscription.Models.AcceptOwnershipProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Subscription.Models.AcceptOwnershipProvisioningState left, Azure.ResourceManager.Subscription.Models.AcceptOwnershipProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class AcceptOwnershipRequestProperties
    {
        public AcceptOwnershipRequestProperties(string displayName) { }
        public string DisplayName { get { throw null; } }
        public string ManagementGroupId { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AcceptOwnershipState : System.IEquatable<Azure.ResourceManager.Subscription.Models.AcceptOwnershipState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AcceptOwnershipState(string value) { throw null; }
        public static Azure.ResourceManager.Subscription.Models.AcceptOwnershipState Completed { get { throw null; } }
        public static Azure.ResourceManager.Subscription.Models.AcceptOwnershipState Expired { get { throw null; } }
        public static Azure.ResourceManager.Subscription.Models.AcceptOwnershipState Pending { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Subscription.Models.AcceptOwnershipState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Subscription.Models.AcceptOwnershipState left, Azure.ResourceManager.Subscription.Models.AcceptOwnershipState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Subscription.Models.AcceptOwnershipState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Subscription.Models.AcceptOwnershipState left, Azure.ResourceManager.Subscription.Models.AcceptOwnershipState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class AcceptOwnershipStatus
    {
        internal AcceptOwnershipStatus() { }
        public Azure.ResourceManager.Subscription.Models.AcceptOwnershipState? AcceptOwnershipState { get { throw null; } }
        public string BillingOwner { get { throw null; } }
        public string DisplayName { get { throw null; } }
        public Azure.ResourceManager.Subscription.Models.AcceptOwnershipProvisioningState? ProvisioningState { get { throw null; } }
        public string SubscriptionId { get { throw null; } }
        public System.Guid? SubscriptionTenantId { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, string> Tags { get { throw null; } }
    }
    public partial class BillingAccountPolicyProperties
    {
        internal BillingAccountPolicyProperties() { }
        public bool? AllowTransfers { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Subscription.Models.ServiceTenant> ServiceTenants { get { throw null; } }
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
    public partial class RenamedSubscriptionId
    {
        internal RenamedSubscriptionId() { }
        public string SubscriptionId { get { throw null; } }
    }
    public partial class ServiceTenant
    {
        internal ServiceTenant() { }
        public System.Guid? TenantId { get { throw null; } }
        public string TenantName { get { throw null; } }
    }
    public partial class SubscriptionAliasAdditionalProperties
    {
        public SubscriptionAliasAdditionalProperties() { }
        public string ManagementGroupId { get { throw null; } set { } }
        public string SubscriptionOwnerId { get { throw null; } set { } }
        public System.Guid? SubscriptionTenantId { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
    }
    public partial class SubscriptionAliasCreateOrUpdateContent
    {
        public SubscriptionAliasCreateOrUpdateContent() { }
        public Azure.ResourceManager.Subscription.Models.SubscriptionAliasAdditionalProperties AdditionalProperties { get { throw null; } set { } }
        public string BillingScope { get { throw null; } set { } }
        public string DisplayName { get { throw null; } set { } }
        public string ResellerId { get { throw null; } set { } }
        public string SubscriptionId { get { throw null; } set { } }
        public Azure.ResourceManager.Subscription.Models.SubscriptionWorkload? Workload { get { throw null; } set { } }
    }
    public partial class SubscriptionAliasProperties
    {
        internal SubscriptionAliasProperties() { }
        public Azure.ResourceManager.Subscription.Models.AcceptOwnershipState? AcceptOwnershipState { get { throw null; } }
        public System.Uri AcceptOwnershipUri { get { throw null; } }
        public string BillingScope { get { throw null; } }
        public System.DateTimeOffset? CreatedOn { get { throw null; } }
        public string DisplayName { get { throw null; } }
        public string ManagementGroupId { get { throw null; } }
        public Azure.ResourceManager.Subscription.Models.SubscriptionProvisioningState? ProvisioningState { get { throw null; } }
        public string ResellerId { get { throw null; } }
        public string SubscriptionId { get { throw null; } }
        public string SubscriptionOwnerId { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, string> Tags { get { throw null; } }
        public Azure.ResourceManager.Subscription.Models.SubscriptionWorkload? Workload { get { throw null; } }
    }
    public partial class SubscriptionName
    {
        public SubscriptionName() { }
        public string SubscriptionNameValue { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SubscriptionProvisioningState : System.IEquatable<Azure.ResourceManager.Subscription.Models.SubscriptionProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SubscriptionProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.Subscription.Models.SubscriptionProvisioningState Accepted { get { throw null; } }
        public static Azure.ResourceManager.Subscription.Models.SubscriptionProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.Subscription.Models.SubscriptionProvisioningState Succeeded { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Subscription.Models.SubscriptionProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Subscription.Models.SubscriptionProvisioningState left, Azure.ResourceManager.Subscription.Models.SubscriptionProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Subscription.Models.SubscriptionProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Subscription.Models.SubscriptionProvisioningState left, Azure.ResourceManager.Subscription.Models.SubscriptionProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SubscriptionWorkload : System.IEquatable<Azure.ResourceManager.Subscription.Models.SubscriptionWorkload>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SubscriptionWorkload(string value) { throw null; }
        public static Azure.ResourceManager.Subscription.Models.SubscriptionWorkload DevTest { get { throw null; } }
        public static Azure.ResourceManager.Subscription.Models.SubscriptionWorkload Production { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Subscription.Models.SubscriptionWorkload other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Subscription.Models.SubscriptionWorkload left, Azure.ResourceManager.Subscription.Models.SubscriptionWorkload right) { throw null; }
        public static implicit operator Azure.ResourceManager.Subscription.Models.SubscriptionWorkload (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Subscription.Models.SubscriptionWorkload left, Azure.ResourceManager.Subscription.Models.SubscriptionWorkload right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class TenantPolicyCreateOrUpdateContent
    {
        public TenantPolicyCreateOrUpdateContent() { }
        public bool? BlockSubscriptionsIntoTenant { get { throw null; } set { } }
        public bool? BlockSubscriptionsLeavingTenant { get { throw null; } set { } }
        public System.Collections.Generic.IList<System.Guid> ExemptedPrincipals { get { throw null; } }
    }
    public partial class TenantPolicyProperties
    {
        internal TenantPolicyProperties() { }
        public bool? BlockSubscriptionsIntoTenant { get { throw null; } }
        public bool? BlockSubscriptionsLeavingTenant { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<System.Guid> ExemptedPrincipals { get { throw null; } }
        public string PolicyId { get { throw null; } }
    }
}
