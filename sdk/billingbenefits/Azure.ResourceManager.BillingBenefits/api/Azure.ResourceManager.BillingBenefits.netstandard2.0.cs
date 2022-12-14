namespace Azure.ResourceManager.BillingBenefits
{
    public static partial class BillingBenefitsExtensions
    {
        public static Azure.ResourceManager.BillingBenefits.ReservationOrderAliasModelResource GetReservationOrderAliasModel(this Azure.ResourceManager.Resources.TenantResource tenantResource) { throw null; }
        public static Azure.ResourceManager.BillingBenefits.ReservationOrderAliasModelResource GetReservationOrderAliasModelResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.BillingBenefits.SavingsPlanModelResource GetSavingsPlanModelResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.BillingBenefits.SavingsPlanModelResource> GetSavingsPlanModels(this Azure.ResourceManager.Resources.TenantResource tenantResource, string filter = null, string orderby = null, string refreshSummary = null, float? skiptoken = default(float?), string selectedState = null, float? take = default(float?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.BillingBenefits.SavingsPlanModelResource> GetSavingsPlanModelsAsync(this Azure.ResourceManager.Resources.TenantResource tenantResource, string filter = null, string orderby = null, string refreshSummary = null, float? skiptoken = default(float?), string selectedState = null, float? take = default(float?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.BillingBenefits.SavingsPlanOrderAliasModelResource GetSavingsPlanOrderAliasModel(this Azure.ResourceManager.Resources.TenantResource tenantResource) { throw null; }
        public static Azure.ResourceManager.BillingBenefits.SavingsPlanOrderAliasModelResource GetSavingsPlanOrderAliasModelResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.BillingBenefits.SavingsPlanOrderModelResource> GetSavingsPlanOrderModel(this Azure.ResourceManager.Resources.TenantResource tenantResource, string savingsPlanOrderId, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.BillingBenefits.SavingsPlanOrderModelResource>> GetSavingsPlanOrderModelAsync(this Azure.ResourceManager.Resources.TenantResource tenantResource, string savingsPlanOrderId, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.BillingBenefits.SavingsPlanOrderModelResource GetSavingsPlanOrderModelResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.BillingBenefits.SavingsPlanOrderModelCollection GetSavingsPlanOrderModels(this Azure.ResourceManager.Resources.TenantResource tenantResource) { throw null; }
        public static Azure.Response<Azure.ResourceManager.BillingBenefits.Models.SavingsPlanValidateResponse> ValidatePurchase(this Azure.ResourceManager.Resources.TenantResource tenantResource, Azure.ResourceManager.BillingBenefits.Models.SavingsPlanPurchaseValidateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.BillingBenefits.Models.SavingsPlanValidateResponse>> ValidatePurchaseAsync(this Azure.ResourceManager.Resources.TenantResource tenantResource, Azure.ResourceManager.BillingBenefits.Models.SavingsPlanPurchaseValidateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ReservationOrderAliasModelData : Azure.ResourceManager.Models.ResourceData
    {
        public ReservationOrderAliasModelData(Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsSku sku) { }
        public Azure.ResourceManager.BillingBenefits.Models.AppliedScopeProperties AppliedScopeProperties { get { throw null; } set { } }
        public Azure.ResourceManager.BillingBenefits.Models.AppliedScopeType? AppliedScopeType { get { throw null; } set { } }
        public Azure.ResourceManager.BillingBenefits.Models.BillingPlan? BillingPlan { get { throw null; } set { } }
        public string BillingScopeId { get { throw null; } set { } }
        public string DisplayName { get { throw null; } set { } }
        public Azure.Core.AzureLocation? Location { get { throw null; } set { } }
        public Azure.ResourceManager.BillingBenefits.Models.ProvisioningState? ProvisioningState { get { throw null; } }
        public int? Quantity { get { throw null; } set { } }
        public bool? Renew { get { throw null; } set { } }
        public string ReservationOrderId { get { throw null; } }
        public Azure.ResourceManager.BillingBenefits.Models.InstanceFlexibility? ReservedResourceInstanceFlexibility { get { throw null; } set { } }
        public Azure.ResourceManager.BillingBenefits.Models.ReservedResourceType? ReservedResourceType { get { throw null; } set { } }
        public System.DateTimeOffset? ReviewOn { get { throw null; } set { } }
        public string SkuName { get { throw null; } set { } }
        public Azure.ResourceManager.BillingBenefits.Models.Term? Term { get { throw null; } set { } }
    }
    public partial class ReservationOrderAliasModelResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ReservationOrderAliasModelResource() { }
        public virtual Azure.ResourceManager.BillingBenefits.ReservationOrderAliasModelData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.BillingBenefits.ReservationOrderAliasModelResource> CreateOrUpdate(Azure.WaitUntil waitUntil, Azure.ResourceManager.BillingBenefits.Models.ReservationOrderAliasModelCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.BillingBenefits.ReservationOrderAliasModelResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.BillingBenefits.Models.ReservationOrderAliasModelCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string reservationOrderAliasName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.BillingBenefits.ReservationOrderAliasModelResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.BillingBenefits.ReservationOrderAliasModelResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SavingsPlanModelCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.BillingBenefits.SavingsPlanModelResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.BillingBenefits.SavingsPlanModelResource>, System.Collections.IEnumerable
    {
        protected SavingsPlanModelCollection() { }
        public virtual Azure.Response<bool> Exists(string savingsPlanId, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string savingsPlanId, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.BillingBenefits.SavingsPlanModelResource> Get(string savingsPlanId, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.BillingBenefits.SavingsPlanModelResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.BillingBenefits.SavingsPlanModelResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.BillingBenefits.SavingsPlanModelResource>> GetAsync(string savingsPlanId, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.BillingBenefits.SavingsPlanModelResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.BillingBenefits.SavingsPlanModelResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.BillingBenefits.SavingsPlanModelResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.BillingBenefits.SavingsPlanModelResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class SavingsPlanModelData : Azure.ResourceManager.Models.ResourceData
    {
        public SavingsPlanModelData(Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsSku sku) { }
        public Azure.ResourceManager.BillingBenefits.Models.AppliedScopeProperties AppliedScopeProperties { get { throw null; } set { } }
        public Azure.ResourceManager.BillingBenefits.Models.AppliedScopeType? AppliedScopeType { get { throw null; } set { } }
        public System.DateTimeOffset? BenefitStartOn { get { throw null; } set { } }
        public string BillingAccountId { get { throw null; } }
        public Azure.ResourceManager.BillingBenefits.Models.BillingPlan? BillingPlan { get { throw null; } set { } }
        public string BillingProfileId { get { throw null; } }
        public string BillingScopeId { get { throw null; } set { } }
        public Azure.ResourceManager.BillingBenefits.Models.Commitment Commitment { get { throw null; } set { } }
        public string CustomerId { get { throw null; } }
        public string DisplayName { get { throw null; } set { } }
        public string DisplayProvisioningState { get { throw null; } }
        public System.DateTimeOffset? EffectiveOn { get { throw null; } }
        public System.DateTimeOffset? ExpiryOn { get { throw null; } }
        public Azure.ResourceManager.BillingBenefits.Models.ExtendedStatusInfo ExtendedStatusInfo { get { throw null; } }
        public Azure.ResourceManager.BillingBenefits.Models.ProvisioningState? ProvisioningState { get { throw null; } }
        public System.DateTimeOffset? PurchaseOn { get { throw null; } }
        public bool? Renew { get { throw null; } set { } }
        public string RenewDestination { get { throw null; } set { } }
        public Azure.ResourceManager.BillingBenefits.Models.PurchaseRequest RenewPurchaseProperties { get { throw null; } set { } }
        public string RenewSource { get { throw null; } set { } }
        public string SkuName { get { throw null; } set { } }
        public Azure.ResourceManager.BillingBenefits.Models.Term? Term { get { throw null; } set { } }
        public string UserFriendlyAppliedScopeType { get { throw null; } }
        public Azure.ResourceManager.BillingBenefits.Models.Utilization Utilization { get { throw null; } }
    }
    public partial class SavingsPlanModelResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected SavingsPlanModelResource() { }
        public virtual Azure.ResourceManager.BillingBenefits.SavingsPlanModelData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string savingsPlanOrderId, string savingsPlanId) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.BillingBenefits.SavingsPlanModelResource> Get(string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.BillingBenefits.SavingsPlanModelResource>> GetAsync(string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.BillingBenefits.SavingsPlanModelResource> Update(Azure.ResourceManager.BillingBenefits.Models.SavingsPlanModelPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.BillingBenefits.SavingsPlanModelResource>> UpdateAsync(Azure.ResourceManager.BillingBenefits.Models.SavingsPlanModelPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.BillingBenefits.Models.SavingsPlanValidateResponse> ValidateUpdate(Azure.ResourceManager.BillingBenefits.Models.SavingsPlanUpdateValidateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.BillingBenefits.Models.SavingsPlanValidateResponse>> ValidateUpdateAsync(Azure.ResourceManager.BillingBenefits.Models.SavingsPlanUpdateValidateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SavingsPlanOrderAliasModelData : Azure.ResourceManager.Models.ResourceData
    {
        public SavingsPlanOrderAliasModelData(Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsSku sku) { }
        public Azure.ResourceManager.BillingBenefits.Models.AppliedScopeProperties AppliedScopeProperties { get { throw null; } set { } }
        public Azure.ResourceManager.BillingBenefits.Models.AppliedScopeType? AppliedScopeType { get { throw null; } set { } }
        public Azure.ResourceManager.BillingBenefits.Models.BillingPlan? BillingPlan { get { throw null; } set { } }
        public string BillingScopeId { get { throw null; } set { } }
        public Azure.ResourceManager.BillingBenefits.Models.Commitment Commitment { get { throw null; } set { } }
        public string DisplayName { get { throw null; } set { } }
        public string Kind { get { throw null; } set { } }
        public Azure.ResourceManager.BillingBenefits.Models.ProvisioningState? ProvisioningState { get { throw null; } }
        public string SavingsPlanOrderId { get { throw null; } }
        public string SkuName { get { throw null; } set { } }
        public Azure.ResourceManager.BillingBenefits.Models.Term? Term { get { throw null; } set { } }
    }
    public partial class SavingsPlanOrderAliasModelResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected SavingsPlanOrderAliasModelResource() { }
        public virtual Azure.ResourceManager.BillingBenefits.SavingsPlanOrderAliasModelData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.BillingBenefits.SavingsPlanOrderAliasModelResource> CreateOrUpdate(Azure.WaitUntil waitUntil, Azure.ResourceManager.BillingBenefits.SavingsPlanOrderAliasModelData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.BillingBenefits.SavingsPlanOrderAliasModelResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.BillingBenefits.SavingsPlanOrderAliasModelData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string savingsPlanOrderAliasName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.BillingBenefits.SavingsPlanOrderAliasModelResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.BillingBenefits.SavingsPlanOrderAliasModelResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SavingsPlanOrderModelCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.BillingBenefits.SavingsPlanOrderModelResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.BillingBenefits.SavingsPlanOrderModelResource>, System.Collections.IEnumerable
    {
        protected SavingsPlanOrderModelCollection() { }
        public virtual Azure.Response<bool> Exists(string savingsPlanOrderId, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string savingsPlanOrderId, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.BillingBenefits.SavingsPlanOrderModelResource> Get(string savingsPlanOrderId, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.BillingBenefits.SavingsPlanOrderModelResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.BillingBenefits.SavingsPlanOrderModelResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.BillingBenefits.SavingsPlanOrderModelResource>> GetAsync(string savingsPlanOrderId, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.BillingBenefits.SavingsPlanOrderModelResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.BillingBenefits.SavingsPlanOrderModelResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.BillingBenefits.SavingsPlanOrderModelResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.BillingBenefits.SavingsPlanOrderModelResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class SavingsPlanOrderModelData : Azure.ResourceManager.Models.ResourceData
    {
        public SavingsPlanOrderModelData(Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsSku sku) { }
        public System.DateTimeOffset? BenefitStartOn { get { throw null; } set { } }
        public string BillingAccountId { get { throw null; } }
        public Azure.ResourceManager.BillingBenefits.Models.BillingPlan? BillingPlan { get { throw null; } set { } }
        public string BillingProfileId { get { throw null; } }
        public string BillingScopeId { get { throw null; } set { } }
        public string CustomerId { get { throw null; } }
        public string DisplayName { get { throw null; } set { } }
        public System.DateTimeOffset? ExpiryOn { get { throw null; } }
        public Azure.ResourceManager.BillingBenefits.Models.ExtendedStatusInfo ExtendedStatusInfo { get { throw null; } }
        public Azure.ResourceManager.BillingBenefits.Models.BillingPlanInformation PlanInformation { get { throw null; } set { } }
        public Azure.ResourceManager.BillingBenefits.Models.ProvisioningState? ProvisioningState { get { throw null; } }
        public System.Collections.Generic.IList<string> SavingsPlans { get { throw null; } }
        public string SkuName { get { throw null; } set { } }
        public Azure.ResourceManager.BillingBenefits.Models.Term? Term { get { throw null; } set { } }
    }
    public partial class SavingsPlanOrderModelResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected SavingsPlanOrderModelResource() { }
        public virtual Azure.ResourceManager.BillingBenefits.SavingsPlanOrderModelData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string savingsPlanOrderId) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.BillingBenefits.Models.RoleAssignmentEntity> Elevate(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.BillingBenefits.Models.RoleAssignmentEntity>> ElevateAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.BillingBenefits.SavingsPlanOrderModelResource> Get(string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.BillingBenefits.SavingsPlanOrderModelResource>> GetAsync(string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.BillingBenefits.SavingsPlanModelResource> GetSavingsPlanModel(string savingsPlanId, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.BillingBenefits.SavingsPlanModelResource>> GetSavingsPlanModelAsync(string savingsPlanId, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.BillingBenefits.SavingsPlanModelCollection GetSavingsPlanModels() { throw null; }
    }
}
namespace Azure.ResourceManager.BillingBenefits.Models
{
    public partial class AppliedScopeProperties
    {
        public AppliedScopeProperties() { }
        public string DisplayName { get { throw null; } set { } }
        public string ManagementGroupId { get { throw null; } set { } }
        public string ResourceGroupId { get { throw null; } set { } }
        public string SubscriptionId { get { throw null; } set { } }
        public System.Guid? TenantId { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AppliedScopeType : System.IEquatable<Azure.ResourceManager.BillingBenefits.Models.AppliedScopeType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AppliedScopeType(string value) { throw null; }
        public static Azure.ResourceManager.BillingBenefits.Models.AppliedScopeType ManagementGroup { get { throw null; } }
        public static Azure.ResourceManager.BillingBenefits.Models.AppliedScopeType Shared { get { throw null; } }
        public static Azure.ResourceManager.BillingBenefits.Models.AppliedScopeType Single { get { throw null; } }
        public bool Equals(Azure.ResourceManager.BillingBenefits.Models.AppliedScopeType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.BillingBenefits.Models.AppliedScopeType left, Azure.ResourceManager.BillingBenefits.Models.AppliedScopeType right) { throw null; }
        public static implicit operator Azure.ResourceManager.BillingBenefits.Models.AppliedScopeType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.BillingBenefits.Models.AppliedScopeType left, Azure.ResourceManager.BillingBenefits.Models.AppliedScopeType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class BillingBenefitsSku
    {
        public BillingBenefitsSku() { }
        public string Name { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct BillingPlan : System.IEquatable<Azure.ResourceManager.BillingBenefits.Models.BillingPlan>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public BillingPlan(string value) { throw null; }
        public static Azure.ResourceManager.BillingBenefits.Models.BillingPlan P1M { get { throw null; } }
        public bool Equals(Azure.ResourceManager.BillingBenefits.Models.BillingPlan other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.BillingBenefits.Models.BillingPlan left, Azure.ResourceManager.BillingBenefits.Models.BillingPlan right) { throw null; }
        public static implicit operator Azure.ResourceManager.BillingBenefits.Models.BillingPlan (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.BillingBenefits.Models.BillingPlan left, Azure.ResourceManager.BillingBenefits.Models.BillingPlan right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class BillingPlanInformation
    {
        public BillingPlanInformation() { }
        public System.DateTimeOffset? NextPaymentDueOn { get { throw null; } set { } }
        public Azure.ResourceManager.BillingBenefits.Models.Price PricingCurrencyTotal { get { throw null; } set { } }
        public System.DateTimeOffset? StartOn { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.BillingBenefits.Models.PaymentDetail> Transactions { get { throw null; } }
    }
    public partial class Commitment : Azure.ResourceManager.BillingBenefits.Models.Price
    {
        public Commitment() { }
        public Azure.ResourceManager.BillingBenefits.Models.CommitmentGrain? Grain { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct CommitmentGrain : System.IEquatable<Azure.ResourceManager.BillingBenefits.Models.CommitmentGrain>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public CommitmentGrain(string value) { throw null; }
        public static Azure.ResourceManager.BillingBenefits.Models.CommitmentGrain Hourly { get { throw null; } }
        public bool Equals(Azure.ResourceManager.BillingBenefits.Models.CommitmentGrain other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.BillingBenefits.Models.CommitmentGrain left, Azure.ResourceManager.BillingBenefits.Models.CommitmentGrain right) { throw null; }
        public static implicit operator Azure.ResourceManager.BillingBenefits.Models.CommitmentGrain (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.BillingBenefits.Models.CommitmentGrain left, Azure.ResourceManager.BillingBenefits.Models.CommitmentGrain right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ExtendedStatusInfo
    {
        internal ExtendedStatusInfo() { }
        public string Message { get { throw null; } }
        public string StatusCode { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct InstanceFlexibility : System.IEquatable<Azure.ResourceManager.BillingBenefits.Models.InstanceFlexibility>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public InstanceFlexibility(string value) { throw null; }
        public static Azure.ResourceManager.BillingBenefits.Models.InstanceFlexibility Off { get { throw null; } }
        public static Azure.ResourceManager.BillingBenefits.Models.InstanceFlexibility On { get { throw null; } }
        public bool Equals(Azure.ResourceManager.BillingBenefits.Models.InstanceFlexibility other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.BillingBenefits.Models.InstanceFlexibility left, Azure.ResourceManager.BillingBenefits.Models.InstanceFlexibility right) { throw null; }
        public static implicit operator Azure.ResourceManager.BillingBenefits.Models.InstanceFlexibility (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.BillingBenefits.Models.InstanceFlexibility left, Azure.ResourceManager.BillingBenefits.Models.InstanceFlexibility right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class PaymentDetail
    {
        public PaymentDetail() { }
        public string BillingAccount { get { throw null; } set { } }
        public Azure.ResourceManager.BillingBenefits.Models.Price BillingCurrencyTotal { get { throw null; } set { } }
        public System.DateTimeOffset? DueOn { get { throw null; } set { } }
        public Azure.ResourceManager.BillingBenefits.Models.ExtendedStatusInfo ExtendedStatusInfo { get { throw null; } }
        public System.DateTimeOffset? PaymentOn { get { throw null; } set { } }
        public Azure.ResourceManager.BillingBenefits.Models.Price PricingCurrencyTotal { get { throw null; } set { } }
        public Azure.ResourceManager.BillingBenefits.Models.PaymentStatus? Status { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PaymentStatus : System.IEquatable<Azure.ResourceManager.BillingBenefits.Models.PaymentStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PaymentStatus(string value) { throw null; }
        public static Azure.ResourceManager.BillingBenefits.Models.PaymentStatus Cancelled { get { throw null; } }
        public static Azure.ResourceManager.BillingBenefits.Models.PaymentStatus Failed { get { throw null; } }
        public static Azure.ResourceManager.BillingBenefits.Models.PaymentStatus Scheduled { get { throw null; } }
        public static Azure.ResourceManager.BillingBenefits.Models.PaymentStatus Succeeded { get { throw null; } }
        public bool Equals(Azure.ResourceManager.BillingBenefits.Models.PaymentStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.BillingBenefits.Models.PaymentStatus left, Azure.ResourceManager.BillingBenefits.Models.PaymentStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.BillingBenefits.Models.PaymentStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.BillingBenefits.Models.PaymentStatus left, Azure.ResourceManager.BillingBenefits.Models.PaymentStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class Price
    {
        public Price() { }
        public double? Amount { get { throw null; } set { } }
        public string CurrencyCode { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ProvisioningState : System.IEquatable<Azure.ResourceManager.BillingBenefits.Models.ProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.BillingBenefits.Models.ProvisioningState Cancelled { get { throw null; } }
        public static Azure.ResourceManager.BillingBenefits.Models.ProvisioningState ConfirmedBilling { get { throw null; } }
        public static Azure.ResourceManager.BillingBenefits.Models.ProvisioningState Created { get { throw null; } }
        public static Azure.ResourceManager.BillingBenefits.Models.ProvisioningState Creating { get { throw null; } }
        public static Azure.ResourceManager.BillingBenefits.Models.ProvisioningState Expired { get { throw null; } }
        public static Azure.ResourceManager.BillingBenefits.Models.ProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.BillingBenefits.Models.ProvisioningState PendingBilling { get { throw null; } }
        public static Azure.ResourceManager.BillingBenefits.Models.ProvisioningState Succeeded { get { throw null; } }
        public bool Equals(Azure.ResourceManager.BillingBenefits.Models.ProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.BillingBenefits.Models.ProvisioningState left, Azure.ResourceManager.BillingBenefits.Models.ProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.BillingBenefits.Models.ProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.BillingBenefits.Models.ProvisioningState left, Azure.ResourceManager.BillingBenefits.Models.ProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class PurchaseRequest
    {
        public PurchaseRequest() { }
        public Azure.ResourceManager.BillingBenefits.Models.AppliedScopeProperties AppliedScopeProperties { get { throw null; } set { } }
        public Azure.ResourceManager.BillingBenefits.Models.AppliedScopeType? AppliedScopeType { get { throw null; } set { } }
        public Azure.ResourceManager.BillingBenefits.Models.BillingPlan? BillingPlan { get { throw null; } set { } }
        public string BillingScopeId { get { throw null; } set { } }
        public Azure.ResourceManager.BillingBenefits.Models.Commitment Commitment { get { throw null; } set { } }
        public string DisplayName { get { throw null; } set { } }
        public System.DateTimeOffset? EffectiveOn { get { throw null; } }
        public bool? Renew { get { throw null; } set { } }
        public string SkuName { get { throw null; } set { } }
        public Azure.ResourceManager.BillingBenefits.Models.Term? Term { get { throw null; } set { } }
    }
    public partial class ReservationOrderAliasModelCreateOrUpdateContent : Azure.ResourceManager.Models.ResourceData
    {
        public ReservationOrderAliasModelCreateOrUpdateContent(Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsSku sku) { }
        public Azure.ResourceManager.BillingBenefits.Models.AppliedScopeProperties AppliedScopeProperties { get { throw null; } set { } }
        public Azure.ResourceManager.BillingBenefits.Models.AppliedScopeType? AppliedScopeType { get { throw null; } set { } }
        public Azure.ResourceManager.BillingBenefits.Models.BillingPlan? BillingPlan { get { throw null; } set { } }
        public string BillingScopeId { get { throw null; } set { } }
        public string DisplayName { get { throw null; } set { } }
        public Azure.Core.AzureLocation? Location { get { throw null; } set { } }
        public int? Quantity { get { throw null; } set { } }
        public bool? Renew { get { throw null; } set { } }
        public Azure.ResourceManager.BillingBenefits.Models.InstanceFlexibility? ReservedResourceInstanceFlexibility { get { throw null; } set { } }
        public Azure.ResourceManager.BillingBenefits.Models.ReservedResourceType? ReservedResourceType { get { throw null; } set { } }
        public System.DateTimeOffset? ReviewOn { get { throw null; } set { } }
        public string SkuName { get { throw null; } set { } }
        public Azure.ResourceManager.BillingBenefits.Models.Term? Term { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ReservedResourceType : System.IEquatable<Azure.ResourceManager.BillingBenefits.Models.ReservedResourceType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ReservedResourceType(string value) { throw null; }
        public static Azure.ResourceManager.BillingBenefits.Models.ReservedResourceType AppService { get { throw null; } }
        public static Azure.ResourceManager.BillingBenefits.Models.ReservedResourceType AVS { get { throw null; } }
        public static Azure.ResourceManager.BillingBenefits.Models.ReservedResourceType AzureDataExplorer { get { throw null; } }
        public static Azure.ResourceManager.BillingBenefits.Models.ReservedResourceType AzureFiles { get { throw null; } }
        public static Azure.ResourceManager.BillingBenefits.Models.ReservedResourceType BlockBlob { get { throw null; } }
        public static Azure.ResourceManager.BillingBenefits.Models.ReservedResourceType CosmosDb { get { throw null; } }
        public static Azure.ResourceManager.BillingBenefits.Models.ReservedResourceType Databricks { get { throw null; } }
        public static Azure.ResourceManager.BillingBenefits.Models.ReservedResourceType DataFactory { get { throw null; } }
        public static Azure.ResourceManager.BillingBenefits.Models.ReservedResourceType DedicatedHost { get { throw null; } }
        public static Azure.ResourceManager.BillingBenefits.Models.ReservedResourceType ManagedDisk { get { throw null; } }
        public static Azure.ResourceManager.BillingBenefits.Models.ReservedResourceType MariaDb { get { throw null; } }
        public static Azure.ResourceManager.BillingBenefits.Models.ReservedResourceType MySql { get { throw null; } }
        public static Azure.ResourceManager.BillingBenefits.Models.ReservedResourceType NetAppStorage { get { throw null; } }
        public static Azure.ResourceManager.BillingBenefits.Models.ReservedResourceType PostgreSql { get { throw null; } }
        public static Azure.ResourceManager.BillingBenefits.Models.ReservedResourceType RedHat { get { throw null; } }
        public static Azure.ResourceManager.BillingBenefits.Models.ReservedResourceType RedHatOsa { get { throw null; } }
        public static Azure.ResourceManager.BillingBenefits.Models.ReservedResourceType RedisCache { get { throw null; } }
        public static Azure.ResourceManager.BillingBenefits.Models.ReservedResourceType SapHana { get { throw null; } }
        public static Azure.ResourceManager.BillingBenefits.Models.ReservedResourceType SqlAzureHybridBenefit { get { throw null; } }
        public static Azure.ResourceManager.BillingBenefits.Models.ReservedResourceType SqlDatabases { get { throw null; } }
        public static Azure.ResourceManager.BillingBenefits.Models.ReservedResourceType SqlDataWarehouse { get { throw null; } }
        public static Azure.ResourceManager.BillingBenefits.Models.ReservedResourceType SqlEdge { get { throw null; } }
        public static Azure.ResourceManager.BillingBenefits.Models.ReservedResourceType SuseLinux { get { throw null; } }
        public static Azure.ResourceManager.BillingBenefits.Models.ReservedResourceType VirtualMachines { get { throw null; } }
        public static Azure.ResourceManager.BillingBenefits.Models.ReservedResourceType VirtualMachineSoftware { get { throw null; } }
        public static Azure.ResourceManager.BillingBenefits.Models.ReservedResourceType VMwareCloudSimple { get { throw null; } }
        public bool Equals(Azure.ResourceManager.BillingBenefits.Models.ReservedResourceType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.BillingBenefits.Models.ReservedResourceType left, Azure.ResourceManager.BillingBenefits.Models.ReservedResourceType right) { throw null; }
        public static implicit operator Azure.ResourceManager.BillingBenefits.Models.ReservedResourceType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.BillingBenefits.Models.ReservedResourceType left, Azure.ResourceManager.BillingBenefits.Models.ReservedResourceType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class RoleAssignmentEntity
    {
        internal RoleAssignmentEntity() { }
        public string Id { get { throw null; } }
        public string Name { get { throw null; } }
        public string PrincipalId { get { throw null; } }
        public string RoleDefinitionId { get { throw null; } }
        public string Scope { get { throw null; } }
    }
    public partial class SavingsPlanModelPatch
    {
        public SavingsPlanModelPatch() { }
        public Azure.ResourceManager.BillingBenefits.Models.SavingsPlanUpdateRequestProperties Properties { get { throw null; } set { } }
    }
    public partial class SavingsPlanPurchaseValidateContent
    {
        public SavingsPlanPurchaseValidateContent() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.BillingBenefits.SavingsPlanOrderAliasModelData> Benefits { get { throw null; } }
    }
    public partial class SavingsPlanUpdateRequestProperties
    {
        public SavingsPlanUpdateRequestProperties() { }
        public Azure.ResourceManager.BillingBenefits.Models.AppliedScopeProperties AppliedScopeProperties { get { throw null; } set { } }
        public Azure.ResourceManager.BillingBenefits.Models.AppliedScopeType? AppliedScopeType { get { throw null; } set { } }
        public string DisplayName { get { throw null; } set { } }
        public bool? Renew { get { throw null; } set { } }
        public Azure.ResourceManager.BillingBenefits.Models.PurchaseRequest RenewPurchaseProperties { get { throw null; } set { } }
    }
    public partial class SavingsPlanUpdateValidateContent
    {
        public SavingsPlanUpdateValidateContent() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.BillingBenefits.Models.SavingsPlanUpdateRequestProperties> Benefits { get { throw null; } }
    }
    public partial class SavingsPlanValidateResponse
    {
        internal SavingsPlanValidateResponse() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.BillingBenefits.Models.SavingsPlanValidResponseProperty> Benefits { get { throw null; } }
        public string NextLink { get { throw null; } }
    }
    public partial class SavingsPlanValidResponseProperty
    {
        internal SavingsPlanValidResponseProperty() { }
        public string Reason { get { throw null; } }
        public string ReasonCode { get { throw null; } }
        public bool? Valid { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct Term : System.IEquatable<Azure.ResourceManager.BillingBenefits.Models.Term>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public Term(string value) { throw null; }
        public static Azure.ResourceManager.BillingBenefits.Models.Term P1Y { get { throw null; } }
        public static Azure.ResourceManager.BillingBenefits.Models.Term P3Y { get { throw null; } }
        public static Azure.ResourceManager.BillingBenefits.Models.Term P5Y { get { throw null; } }
        public bool Equals(Azure.ResourceManager.BillingBenefits.Models.Term other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.BillingBenefits.Models.Term left, Azure.ResourceManager.BillingBenefits.Models.Term right) { throw null; }
        public static implicit operator Azure.ResourceManager.BillingBenefits.Models.Term (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.BillingBenefits.Models.Term left, Azure.ResourceManager.BillingBenefits.Models.Term right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class Utilization
    {
        internal Utilization() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.BillingBenefits.Models.UtilizationAggregates> Aggregates { get { throw null; } }
        public string Trend { get { throw null; } }
    }
    public partial class UtilizationAggregates
    {
        internal UtilizationAggregates() { }
        public float? Grain { get { throw null; } }
        public string GrainUnit { get { throw null; } }
        public float? Value { get { throw null; } }
        public string ValueUnit { get { throw null; } }
    }
}
