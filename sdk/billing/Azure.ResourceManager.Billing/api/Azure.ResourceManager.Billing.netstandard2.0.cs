namespace Azure.ResourceManager.Billing
{
    public partial class BillingAccountPaymentMethodCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Billing.BillingAccountPaymentMethodResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Billing.BillingAccountPaymentMethodResource>, System.Collections.IEnumerable
    {
        protected BillingAccountPaymentMethodCollection() { }
        public virtual Azure.Response<bool> Exists(string paymentMethodName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string paymentMethodName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Billing.BillingAccountPaymentMethodResource> Get(string paymentMethodName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Billing.BillingAccountPaymentMethodResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Billing.BillingAccountPaymentMethodResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Billing.BillingAccountPaymentMethodResource>> GetAsync(string paymentMethodName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Billing.BillingAccountPaymentMethodResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Billing.BillingAccountPaymentMethodResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Billing.BillingAccountPaymentMethodResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Billing.BillingAccountPaymentMethodResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class BillingAccountPaymentMethodResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected BillingAccountPaymentMethodResource() { }
        public virtual Azure.ResourceManager.Billing.PaymentMethodData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string billingAccountName, string paymentMethodName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Billing.BillingAccountPaymentMethodResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Billing.BillingAccountPaymentMethodResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public static partial class BillingExtensions
    {
        public static Azure.Response<Azure.ResourceManager.Billing.BillingAccountPaymentMethodResource> GetBillingAccountPaymentMethod(this Azure.ResourceManager.Resources.TenantResource tenantResource, string billingAccountName, string paymentMethodName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Billing.BillingAccountPaymentMethodResource>> GetBillingAccountPaymentMethodAsync(this Azure.ResourceManager.Resources.TenantResource tenantResource, string billingAccountName, string paymentMethodName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Billing.BillingAccountPaymentMethodResource GetBillingAccountPaymentMethodResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Billing.BillingAccountPaymentMethodCollection GetBillingAccountPaymentMethods(this Azure.ResourceManager.Resources.TenantResource tenantResource, string billingAccountName) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Billing.BillingSubscriptionResource> GetBillingSubscription(this Azure.ResourceManager.Resources.TenantResource tenantResource, string billingAccountName, string billingSubscriptionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Billing.BillingSubscriptionAliasResource> GetBillingSubscriptionAlias(this Azure.ResourceManager.Resources.TenantResource tenantResource, string billingAccountName, string aliasName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Billing.BillingSubscriptionAliasResource>> GetBillingSubscriptionAliasAsync(this Azure.ResourceManager.Resources.TenantResource tenantResource, string billingAccountName, string aliasName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Billing.BillingSubscriptionAliasCollection GetBillingSubscriptionAliases(this Azure.ResourceManager.Resources.TenantResource tenantResource, string billingAccountName) { throw null; }
        public static Azure.ResourceManager.Billing.BillingSubscriptionAliasResource GetBillingSubscriptionAliasResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Billing.BillingSubscriptionResource>> GetBillingSubscriptionAsync(this Azure.ResourceManager.Resources.TenantResource tenantResource, string billingAccountName, string billingSubscriptionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Billing.BillingSubscriptionResource GetBillingSubscriptionResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Billing.BillingSubscriptionCollection GetBillingSubscriptions(this Azure.ResourceManager.Resources.TenantResource tenantResource, string billingAccountName) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Billing.PaymentMethodResource> GetPaymentMethod(this Azure.ResourceManager.Resources.TenantResource tenantResource, string paymentMethodName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Billing.PaymentMethodResource>> GetPaymentMethodAsync(this Azure.ResourceManager.Resources.TenantResource tenantResource, string paymentMethodName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Billing.PaymentMethodLinkResource> GetPaymentMethodLink(this Azure.ResourceManager.Resources.TenantResource tenantResource, string billingAccountName, string billingProfileName, string paymentMethodName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Billing.PaymentMethodLinkResource>> GetPaymentMethodLinkAsync(this Azure.ResourceManager.Resources.TenantResource tenantResource, string billingAccountName, string billingProfileName, string paymentMethodName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Billing.PaymentMethodLinkResource GetPaymentMethodLinkResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Billing.PaymentMethodLinkCollection GetPaymentMethodLinks(this Azure.ResourceManager.Resources.TenantResource tenantResource, string billingAccountName, string billingProfileName) { throw null; }
        public static Azure.ResourceManager.Billing.PaymentMethodResource GetPaymentMethodResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Billing.PaymentMethodCollection GetPaymentMethods(this Azure.ResourceManager.Resources.TenantResource tenantResource) { throw null; }
    }
    public partial class BillingSubscriptionAliasCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Billing.BillingSubscriptionAliasResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Billing.BillingSubscriptionAliasResource>, System.Collections.IEnumerable
    {
        protected BillingSubscriptionAliasCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Billing.BillingSubscriptionAliasResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string aliasName, Azure.ResourceManager.Billing.BillingSubscriptionAliasData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Billing.BillingSubscriptionAliasResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string aliasName, Azure.ResourceManager.Billing.BillingSubscriptionAliasData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string aliasName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string aliasName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Billing.BillingSubscriptionAliasResource> Get(string aliasName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Billing.BillingSubscriptionAliasResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Billing.BillingSubscriptionAliasResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Billing.BillingSubscriptionAliasResource>> GetAsync(string aliasName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Billing.BillingSubscriptionAliasResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Billing.BillingSubscriptionAliasResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Billing.BillingSubscriptionAliasResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Billing.BillingSubscriptionAliasResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class BillingSubscriptionAliasData : Azure.ResourceManager.Models.ResourceData
    {
        public BillingSubscriptionAliasData() { }
        public Azure.ResourceManager.Billing.Models.AutoRenew? AutoRenew { get { throw null; } set { } }
        public string BeneficiaryTenantId { get { throw null; } set { } }
        public string BillingFrequency { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyDictionary<string, string> BillingPolicies { get { throw null; } }
        public string BillingProfileDisplayName { get { throw null; } }
        public string BillingProfileId { get { throw null; } set { } }
        public string BillingProfileName { get { throw null; } }
        public string BillingSubscriptionId { get { throw null; } }
        public string ConsumptionCostCenter { get { throw null; } set { } }
        public string CustomerDisplayName { get { throw null; } }
        public string CustomerId { get { throw null; } set { } }
        public string DisplayName { get { throw null; } set { } }
        public string EnrollmentAccountDisplayName { get { throw null; } }
        public string EnrollmentAccountId { get { throw null; } }
        public System.DateTimeOffset? EnrollmentAccountStartOn { get { throw null; } }
        public string InvoiceSectionDisplayName { get { throw null; } }
        public string InvoiceSectionId { get { throw null; } set { } }
        public string InvoiceSectionName { get { throw null; } }
        public Azure.ResourceManager.Billing.Models.Amount LastMonthCharges { get { throw null; } }
        public Azure.ResourceManager.Billing.Models.Amount MonthToDateCharges { get { throw null; } }
        public string NextBillingCycleBillingFrequency { get { throw null; } }
        public string OfferId { get { throw null; } }
        public string ProductCategory { get { throw null; } }
        public string ProductType { get { throw null; } }
        public string ProductTypeId { get { throw null; } set { } }
        public System.DateTimeOffset? PurchaseOn { get { throw null; } }
        public long? Quantity { get { throw null; } set { } }
        public Azure.ResourceManager.Billing.Models.RenewalTermDetails RenewalTermDetails { get { throw null; } }
        public Azure.ResourceManager.Billing.Models.Reseller Reseller { get { throw null; } }
        public string SkuDescription { get { throw null; } }
        public string SkuId { get { throw null; } set { } }
        public Azure.ResourceManager.Billing.Models.BillingSubscriptionStatus? Status { get { throw null; } }
        public Azure.ResourceManager.Billing.Models.SubscriptionEnrollmentAccountStatus? SubscriptionEnrollmentAccountStatus { get { throw null; } }
        public string SubscriptionId { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> SuspensionReasons { get { throw null; } }
        public System.TimeSpan? TermDuration { get { throw null; } set { } }
        public System.DateTimeOffset? TermEndOn { get { throw null; } }
        public System.DateTimeOffset? TermStartOn { get { throw null; } }
    }
    public partial class BillingSubscriptionAliasResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected BillingSubscriptionAliasResource() { }
        public virtual Azure.ResourceManager.Billing.BillingSubscriptionAliasData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string billingAccountName, string aliasName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Billing.BillingSubscriptionAliasResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Billing.BillingSubscriptionAliasResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Billing.BillingSubscriptionAliasResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Billing.BillingSubscriptionAliasData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Billing.BillingSubscriptionAliasResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Billing.BillingSubscriptionAliasData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class BillingSubscriptionCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Billing.BillingSubscriptionResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Billing.BillingSubscriptionResource>, System.Collections.IEnumerable
    {
        protected BillingSubscriptionCollection() { }
        public virtual Azure.Response<bool> Exists(string billingSubscriptionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string billingSubscriptionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Billing.BillingSubscriptionResource> Get(string billingSubscriptionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Billing.BillingSubscriptionResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Billing.BillingSubscriptionResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Billing.BillingSubscriptionResource>> GetAsync(string billingSubscriptionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Billing.BillingSubscriptionResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Billing.BillingSubscriptionResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Billing.BillingSubscriptionResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Billing.BillingSubscriptionResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class BillingSubscriptionData : Azure.ResourceManager.Models.ResourceData
    {
        public BillingSubscriptionData() { }
        public Azure.ResourceManager.Billing.Models.AutoRenew? AutoRenew { get { throw null; } set { } }
        public string BeneficiaryTenantId { get { throw null; } set { } }
        public string BillingFrequency { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyDictionary<string, string> BillingPolicies { get { throw null; } }
        public string BillingProfileDisplayName { get { throw null; } }
        public string BillingProfileId { get { throw null; } set { } }
        public string BillingProfileName { get { throw null; } }
        public string ConsumptionCostCenter { get { throw null; } set { } }
        public string CustomerDisplayName { get { throw null; } }
        public string CustomerId { get { throw null; } set { } }
        public string DisplayName { get { throw null; } set { } }
        public string EnrollmentAccountDisplayName { get { throw null; } }
        public string EnrollmentAccountId { get { throw null; } }
        public System.DateTimeOffset? EnrollmentAccountStartOn { get { throw null; } }
        public string InvoiceSectionDisplayName { get { throw null; } }
        public string InvoiceSectionId { get { throw null; } set { } }
        public string InvoiceSectionName { get { throw null; } }
        public Azure.ResourceManager.Billing.Models.Amount LastMonthCharges { get { throw null; } }
        public Azure.ResourceManager.Billing.Models.Amount MonthToDateCharges { get { throw null; } }
        public string NextBillingCycleBillingFrequency { get { throw null; } }
        public string OfferId { get { throw null; } }
        public string ProductCategory { get { throw null; } }
        public string ProductType { get { throw null; } }
        public string ProductTypeId { get { throw null; } set { } }
        public System.DateTimeOffset? PurchaseOn { get { throw null; } }
        public long? Quantity { get { throw null; } set { } }
        public Azure.ResourceManager.Billing.Models.RenewalTermDetails RenewalTermDetails { get { throw null; } }
        public Azure.ResourceManager.Billing.Models.Reseller Reseller { get { throw null; } }
        public string SkuDescription { get { throw null; } }
        public string SkuId { get { throw null; } set { } }
        public Azure.ResourceManager.Billing.Models.BillingSubscriptionStatus? Status { get { throw null; } }
        public Azure.ResourceManager.Billing.Models.SubscriptionEnrollmentAccountStatus? SubscriptionEnrollmentAccountStatus { get { throw null; } }
        public string SubscriptionId { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> SuspensionReasons { get { throw null; } }
        public System.TimeSpan? TermDuration { get { throw null; } set { } }
        public System.DateTimeOffset? TermEndOn { get { throw null; } }
        public System.DateTimeOffset? TermStartOn { get { throw null; } }
    }
    public partial class BillingSubscriptionResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected BillingSubscriptionResource() { }
        public virtual Azure.ResourceManager.Billing.BillingSubscriptionData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string billingAccountName, string billingSubscriptionName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Billing.BillingSubscriptionResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Billing.BillingSubscriptionResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Billing.BillingSubscriptionResource> Merge(Azure.WaitUntil waitUntil, Azure.ResourceManager.Billing.Models.BillingSubscriptionMergeContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Billing.BillingSubscriptionResource>> MergeAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Billing.Models.BillingSubscriptionMergeContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Billing.BillingSubscriptionResource> Move(Azure.WaitUntil waitUntil, Azure.ResourceManager.Billing.Models.MoveBillingSubscriptionRequest moveBillingSubscriptionRequest, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Billing.BillingSubscriptionResource>> MoveAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Billing.Models.MoveBillingSubscriptionRequest moveBillingSubscriptionRequest, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Billing.BillingSubscriptionResource> Split(Azure.WaitUntil waitUntil, Azure.ResourceManager.Billing.Models.BillingSubscriptionSplitContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Billing.BillingSubscriptionResource>> SplitAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Billing.Models.BillingSubscriptionSplitContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Billing.BillingSubscriptionResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Billing.BillingSubscriptionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Billing.BillingSubscriptionResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Billing.BillingSubscriptionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Billing.Models.ValidateMoveBillingSubscriptionEligibilityResult> ValidateMoveEligibility(Azure.ResourceManager.Billing.Models.MoveBillingSubscriptionRequest moveBillingSubscriptionRequest, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Billing.Models.ValidateMoveBillingSubscriptionEligibilityResult>> ValidateMoveEligibilityAsync(Azure.ResourceManager.Billing.Models.MoveBillingSubscriptionRequest moveBillingSubscriptionRequest, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class PaymentMethodCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Billing.PaymentMethodResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Billing.PaymentMethodResource>, System.Collections.IEnumerable
    {
        protected PaymentMethodCollection() { }
        public virtual Azure.Response<bool> Exists(string paymentMethodName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string paymentMethodName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Billing.PaymentMethodResource> Get(string paymentMethodName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Billing.PaymentMethodResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Billing.PaymentMethodResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Billing.PaymentMethodResource>> GetAsync(string paymentMethodName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Billing.PaymentMethodResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Billing.PaymentMethodResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Billing.PaymentMethodResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Billing.PaymentMethodResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class PaymentMethodData : Azure.ResourceManager.Models.ResourceData
    {
        public PaymentMethodData() { }
        public string AccountHolderName { get { throw null; } }
        public string DisplayName { get { throw null; } }
        public string Expiration { get { throw null; } }
        public Azure.ResourceManager.Billing.Models.PaymentMethodFamily? Family { get { throw null; } set { } }
        public string LastFourDigits { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Billing.Models.PaymentMethodLogo> Logos { get { throw null; } }
        public Azure.ResourceManager.Billing.Models.PaymentMethodStatus? Status { get { throw null; } set { } }
        public string TypePropertiesType { get { throw null; } }
    }
    public partial class PaymentMethodLinkCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Billing.PaymentMethodLinkResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Billing.PaymentMethodLinkResource>, System.Collections.IEnumerable
    {
        protected PaymentMethodLinkCollection() { }
        public virtual Azure.Response<bool> Exists(string paymentMethodName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string paymentMethodName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Billing.PaymentMethodLinkResource> Get(string paymentMethodName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Billing.PaymentMethodLinkResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Billing.PaymentMethodLinkResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Billing.PaymentMethodLinkResource>> GetAsync(string paymentMethodName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Billing.PaymentMethodLinkResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Billing.PaymentMethodLinkResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Billing.PaymentMethodLinkResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Billing.PaymentMethodLinkResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class PaymentMethodLinkData : Azure.ResourceManager.Models.ResourceData
    {
        public PaymentMethodLinkData() { }
        public Azure.ResourceManager.Billing.Models.PaymentMethodProjectionProperties PaymentMethod { get { throw null; } set { } }
    }
    public partial class PaymentMethodLinkResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected PaymentMethodLinkResource() { }
        public virtual Azure.ResourceManager.Billing.PaymentMethodLinkData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string billingAccountName, string billingProfileName, string paymentMethodName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Billing.PaymentMethodLinkResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Billing.PaymentMethodLinkResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class PaymentMethodResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected PaymentMethodResource() { }
        public virtual Azure.ResourceManager.Billing.PaymentMethodData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string paymentMethodName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Billing.PaymentMethodResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Billing.PaymentMethodResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.Billing.Models
{
    public partial class Amount
    {
        internal Amount() { }
        public string Currency { get { throw null; } }
        public float? Value { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AutoRenew : System.IEquatable<Azure.ResourceManager.Billing.Models.AutoRenew>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AutoRenew(string value) { throw null; }
        public static Azure.ResourceManager.Billing.Models.AutoRenew Off { get { throw null; } }
        public static Azure.ResourceManager.Billing.Models.AutoRenew On { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Billing.Models.AutoRenew other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Billing.Models.AutoRenew left, Azure.ResourceManager.Billing.Models.AutoRenew right) { throw null; }
        public static implicit operator Azure.ResourceManager.Billing.Models.AutoRenew (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Billing.Models.AutoRenew left, Azure.ResourceManager.Billing.Models.AutoRenew right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class BillingSubscriptionMergeContent
    {
        public BillingSubscriptionMergeContent() { }
        public int? Quantity { get { throw null; } set { } }
        public string TargetBillingSubscriptionName { get { throw null; } set { } }
    }
    public partial class BillingSubscriptionSplitContent
    {
        public BillingSubscriptionSplitContent() { }
        public string BillingFrequency { get { throw null; } set { } }
        public int? Quantity { get { throw null; } set { } }
        public string TargetProductTypeId { get { throw null; } set { } }
        public string TargetSkuId { get { throw null; } set { } }
        public System.TimeSpan? TermDuration { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct BillingSubscriptionStatus : System.IEquatable<Azure.ResourceManager.Billing.Models.BillingSubscriptionStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public BillingSubscriptionStatus(string value) { throw null; }
        public static Azure.ResourceManager.Billing.Models.BillingSubscriptionStatus Active { get { throw null; } }
        public static Azure.ResourceManager.Billing.Models.BillingSubscriptionStatus AutoRenew { get { throw null; } }
        public static Azure.ResourceManager.Billing.Models.BillingSubscriptionStatus Cancelled { get { throw null; } }
        public static Azure.ResourceManager.Billing.Models.BillingSubscriptionStatus Deleted { get { throw null; } }
        public static Azure.ResourceManager.Billing.Models.BillingSubscriptionStatus Disabled { get { throw null; } }
        public static Azure.ResourceManager.Billing.Models.BillingSubscriptionStatus Expired { get { throw null; } }
        public static Azure.ResourceManager.Billing.Models.BillingSubscriptionStatus Expiring { get { throw null; } }
        public static Azure.ResourceManager.Billing.Models.BillingSubscriptionStatus Suspended { get { throw null; } }
        public static Azure.ResourceManager.Billing.Models.BillingSubscriptionStatus Unknown { get { throw null; } }
        public static Azure.ResourceManager.Billing.Models.BillingSubscriptionStatus Warned { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Billing.Models.BillingSubscriptionStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Billing.Models.BillingSubscriptionStatus left, Azure.ResourceManager.Billing.Models.BillingSubscriptionStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.Billing.Models.BillingSubscriptionStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Billing.Models.BillingSubscriptionStatus left, Azure.ResourceManager.Billing.Models.BillingSubscriptionStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class MoveBillingSubscriptionRequest
    {
        public MoveBillingSubscriptionRequest() { }
        public string DestinationEnrollmentAccountId { get { throw null; } set { } }
        public string DestinationInvoiceSectionId { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PaymentMethodFamily : System.IEquatable<Azure.ResourceManager.Billing.Models.PaymentMethodFamily>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PaymentMethodFamily(string value) { throw null; }
        public static Azure.ResourceManager.Billing.Models.PaymentMethodFamily CheckWire { get { throw null; } }
        public static Azure.ResourceManager.Billing.Models.PaymentMethodFamily CreditCard { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Billing.Models.PaymentMethodFamily other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Billing.Models.PaymentMethodFamily left, Azure.ResourceManager.Billing.Models.PaymentMethodFamily right) { throw null; }
        public static implicit operator Azure.ResourceManager.Billing.Models.PaymentMethodFamily (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Billing.Models.PaymentMethodFamily left, Azure.ResourceManager.Billing.Models.PaymentMethodFamily right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class PaymentMethodLogo
    {
        public PaymentMethodLogo() { }
        public string MimeType { get { throw null; } }
        public System.Uri Uri { get { throw null; } }
    }
    public partial class PaymentMethodProjectionProperties
    {
        public PaymentMethodProjectionProperties() { }
        public string AccountHolderName { get { throw null; } }
        public string DisplayName { get { throw null; } }
        public string Expiration { get { throw null; } }
        public Azure.ResourceManager.Billing.Models.PaymentMethodFamily? Family { get { throw null; } set { } }
        public string Id { get { throw null; } }
        public string LastFourDigits { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Billing.Models.PaymentMethodLogo> Logos { get { throw null; } }
        public string PaymentMethodProjectionPropertiesType { get { throw null; } }
        public Azure.ResourceManager.Billing.Models.PaymentMethodStatus? Status { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PaymentMethodStatus : System.IEquatable<Azure.ResourceManager.Billing.Models.PaymentMethodStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PaymentMethodStatus(string value) { throw null; }
        public static Azure.ResourceManager.Billing.Models.PaymentMethodStatus Active { get { throw null; } }
        public static Azure.ResourceManager.Billing.Models.PaymentMethodStatus Inactive { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Billing.Models.PaymentMethodStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Billing.Models.PaymentMethodStatus left, Azure.ResourceManager.Billing.Models.PaymentMethodStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.Billing.Models.PaymentMethodStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Billing.Models.PaymentMethodStatus left, Azure.ResourceManager.Billing.Models.PaymentMethodStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class RenewalTermDetails
    {
        internal RenewalTermDetails() { }
        public string BillingFrequency { get { throw null; } }
        public string ProductTypeId { get { throw null; } }
        public long? Quantity { get { throw null; } }
        public string SkuId { get { throw null; } }
        public System.TimeSpan? TermDuration { get { throw null; } }
    }
    public partial class Reseller
    {
        internal Reseller() { }
        public string Description { get { throw null; } }
        public string ResellerId { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SubscriptionEnrollmentAccountStatus : System.IEquatable<Azure.ResourceManager.Billing.Models.SubscriptionEnrollmentAccountStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SubscriptionEnrollmentAccountStatus(string value) { throw null; }
        public static Azure.ResourceManager.Billing.Models.SubscriptionEnrollmentAccountStatus Active { get { throw null; } }
        public static Azure.ResourceManager.Billing.Models.SubscriptionEnrollmentAccountStatus Cancelled { get { throw null; } }
        public static Azure.ResourceManager.Billing.Models.SubscriptionEnrollmentAccountStatus Deleted { get { throw null; } }
        public static Azure.ResourceManager.Billing.Models.SubscriptionEnrollmentAccountStatus Expired { get { throw null; } }
        public static Azure.ResourceManager.Billing.Models.SubscriptionEnrollmentAccountStatus TransferredOut { get { throw null; } }
        public static Azure.ResourceManager.Billing.Models.SubscriptionEnrollmentAccountStatus Transferring { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Billing.Models.SubscriptionEnrollmentAccountStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Billing.Models.SubscriptionEnrollmentAccountStatus left, Azure.ResourceManager.Billing.Models.SubscriptionEnrollmentAccountStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.Billing.Models.SubscriptionEnrollmentAccountStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Billing.Models.SubscriptionEnrollmentAccountStatus left, Azure.ResourceManager.Billing.Models.SubscriptionEnrollmentAccountStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SubscriptionTransferValidationErrorCode : System.IEquatable<Azure.ResourceManager.Billing.Models.SubscriptionTransferValidationErrorCode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SubscriptionTransferValidationErrorCode(string value) { throw null; }
        public static Azure.ResourceManager.Billing.Models.SubscriptionTransferValidationErrorCode AccountIsLocked { get { throw null; } }
        public static Azure.ResourceManager.Billing.Models.SubscriptionTransferValidationErrorCode AssetHasCap { get { throw null; } }
        public static Azure.ResourceManager.Billing.Models.SubscriptionTransferValidationErrorCode AssetNotActive { get { throw null; } }
        public static Azure.ResourceManager.Billing.Models.SubscriptionTransferValidationErrorCode BillingAccountInactive { get { throw null; } }
        public static Azure.ResourceManager.Billing.Models.SubscriptionTransferValidationErrorCode BillingProfilePastDue { get { throw null; } }
        public static Azure.ResourceManager.Billing.Models.SubscriptionTransferValidationErrorCode CrossBillingAccountNotAllowed { get { throw null; } }
        public static Azure.ResourceManager.Billing.Models.SubscriptionTransferValidationErrorCode DestinationBillingProfileInactive { get { throw null; } }
        public static Azure.ResourceManager.Billing.Models.SubscriptionTransferValidationErrorCode DestinationBillingProfileNotFound { get { throw null; } }
        public static Azure.ResourceManager.Billing.Models.SubscriptionTransferValidationErrorCode DestinationBillingProfilePastDue { get { throw null; } }
        public static Azure.ResourceManager.Billing.Models.SubscriptionTransferValidationErrorCode DestinationInvoiceSectionInactive { get { throw null; } }
        public static Azure.ResourceManager.Billing.Models.SubscriptionTransferValidationErrorCode DestinationInvoiceSectionNotFound { get { throw null; } }
        public static Azure.ResourceManager.Billing.Models.SubscriptionTransferValidationErrorCode InsufficientPermissionOnDestination { get { throw null; } }
        public static Azure.ResourceManager.Billing.Models.SubscriptionTransferValidationErrorCode InsufficientPermissionOnSource { get { throw null; } }
        public static Azure.ResourceManager.Billing.Models.SubscriptionTransferValidationErrorCode InvalidDestination { get { throw null; } }
        public static Azure.ResourceManager.Billing.Models.SubscriptionTransferValidationErrorCode InvalidSource { get { throw null; } }
        public static Azure.ResourceManager.Billing.Models.SubscriptionTransferValidationErrorCode InvoiceSectionIsRestricted { get { throw null; } }
        public static Azure.ResourceManager.Billing.Models.SubscriptionTransferValidationErrorCode MarketplaceNotEnabledOnDestination { get { throw null; } }
        public static Azure.ResourceManager.Billing.Models.SubscriptionTransferValidationErrorCode ProductInactive { get { throw null; } }
        public static Azure.ResourceManager.Billing.Models.SubscriptionTransferValidationErrorCode ProductNotFound { get { throw null; } }
        public static Azure.ResourceManager.Billing.Models.SubscriptionTransferValidationErrorCode ProductTypeNotSupported { get { throw null; } }
        public static Azure.ResourceManager.Billing.Models.SubscriptionTransferValidationErrorCode SourceBillingProfilePastDue { get { throw null; } }
        public static Azure.ResourceManager.Billing.Models.SubscriptionTransferValidationErrorCode SourceInvoiceSectionInactive { get { throw null; } }
        public static Azure.ResourceManager.Billing.Models.SubscriptionTransferValidationErrorCode SubscriptionNotActive { get { throw null; } }
        public static Azure.ResourceManager.Billing.Models.SubscriptionTransferValidationErrorCode SubscriptionTypeNotSupported { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Billing.Models.SubscriptionTransferValidationErrorCode other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Billing.Models.SubscriptionTransferValidationErrorCode left, Azure.ResourceManager.Billing.Models.SubscriptionTransferValidationErrorCode right) { throw null; }
        public static implicit operator Azure.ResourceManager.Billing.Models.SubscriptionTransferValidationErrorCode (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Billing.Models.SubscriptionTransferValidationErrorCode left, Azure.ResourceManager.Billing.Models.SubscriptionTransferValidationErrorCode right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ValidateMoveBillingSubscriptionEligibilityError
    {
        internal ValidateMoveBillingSubscriptionEligibilityError() { }
        public Azure.ResourceManager.Billing.Models.SubscriptionTransferValidationErrorCode? Code { get { throw null; } }
        public string Details { get { throw null; } }
        public string Message { get { throw null; } }
    }
    public partial class ValidateMoveBillingSubscriptionEligibilityResult
    {
        internal ValidateMoveBillingSubscriptionEligibilityResult() { }
        public Azure.ResourceManager.Billing.Models.ValidateMoveBillingSubscriptionEligibilityError ErrorDetails { get { throw null; } }
        public bool? IsMoveEligible { get { throw null; } }
    }
}
