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
        public virtual Azure.NullableResponse<Azure.ResourceManager.Billing.BillingAccountPaymentMethodResource> GetIfExists(string paymentMethodName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Billing.BillingAccountPaymentMethodResource>> GetIfExistsAsync(string paymentMethodName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Billing.BillingAccountPaymentMethodResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Billing.BillingAccountPaymentMethodResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Billing.BillingAccountPaymentMethodResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Billing.BillingAccountPaymentMethodResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class BillingAccountPaymentMethodResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected BillingAccountPaymentMethodResource() { }
        public virtual Azure.ResourceManager.Billing.BillingPaymentMethodData Data { get { throw null; } }
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
        public static Azure.Response<Azure.ResourceManager.Billing.BillingPaymentMethodResource> GetBillingPaymentMethod(this Azure.ResourceManager.Resources.TenantResource tenantResource, string paymentMethodName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Billing.BillingPaymentMethodResource>> GetBillingPaymentMethodAsync(this Azure.ResourceManager.Resources.TenantResource tenantResource, string paymentMethodName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Billing.BillingPaymentMethodLinkResource> GetBillingPaymentMethodLink(this Azure.ResourceManager.Resources.TenantResource tenantResource, string billingAccountName, string billingProfileName, string paymentMethodName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Billing.BillingPaymentMethodLinkResource>> GetBillingPaymentMethodLinkAsync(this Azure.ResourceManager.Resources.TenantResource tenantResource, string billingAccountName, string billingProfileName, string paymentMethodName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Billing.BillingPaymentMethodLinkResource GetBillingPaymentMethodLinkResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Billing.BillingPaymentMethodLinkCollection GetBillingPaymentMethodLinks(this Azure.ResourceManager.Resources.TenantResource tenantResource, string billingAccountName, string billingProfileName) { throw null; }
        public static Azure.ResourceManager.Billing.BillingPaymentMethodResource GetBillingPaymentMethodResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Billing.BillingPaymentMethodCollection GetBillingPaymentMethods(this Azure.ResourceManager.Resources.TenantResource tenantResource) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Billing.BillingSubscriptionResource> GetBillingSubscription(this Azure.ResourceManager.Resources.TenantResource tenantResource, string billingAccountName, string billingSubscriptionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Billing.BillingSubscriptionAliasResource> GetBillingSubscriptionAlias(this Azure.ResourceManager.Resources.TenantResource tenantResource, string billingAccountName, string aliasName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Billing.BillingSubscriptionAliasResource>> GetBillingSubscriptionAliasAsync(this Azure.ResourceManager.Resources.TenantResource tenantResource, string billingAccountName, string aliasName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Billing.BillingSubscriptionAliasCollection GetBillingSubscriptionAliases(this Azure.ResourceManager.Resources.TenantResource tenantResource, string billingAccountName) { throw null; }
        public static Azure.ResourceManager.Billing.BillingSubscriptionAliasResource GetBillingSubscriptionAliasResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Billing.BillingSubscriptionResource>> GetBillingSubscriptionAsync(this Azure.ResourceManager.Resources.TenantResource tenantResource, string billingAccountName, string billingSubscriptionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Billing.BillingSubscriptionResource GetBillingSubscriptionResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Billing.BillingSubscriptionCollection GetBillingSubscriptions(this Azure.ResourceManager.Resources.TenantResource tenantResource, string billingAccountName) { throw null; }
    }
    public partial class BillingPaymentMethodCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Billing.BillingPaymentMethodResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Billing.BillingPaymentMethodResource>, System.Collections.IEnumerable
    {
        protected BillingPaymentMethodCollection() { }
        public virtual Azure.Response<bool> Exists(string paymentMethodName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string paymentMethodName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Billing.BillingPaymentMethodResource> Get(string paymentMethodName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Billing.BillingPaymentMethodResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Billing.BillingPaymentMethodResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Billing.BillingPaymentMethodResource>> GetAsync(string paymentMethodName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Billing.BillingPaymentMethodResource> GetIfExists(string paymentMethodName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Billing.BillingPaymentMethodResource>> GetIfExistsAsync(string paymentMethodName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Billing.BillingPaymentMethodResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Billing.BillingPaymentMethodResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Billing.BillingPaymentMethodResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Billing.BillingPaymentMethodResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class BillingPaymentMethodData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Billing.BillingPaymentMethodData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Billing.BillingPaymentMethodData>
    {
        public BillingPaymentMethodData() { }
        public string AccountHolderName { get { throw null; } }
        public string DisplayName { get { throw null; } }
        public string Expiration { get { throw null; } }
        public Azure.ResourceManager.Billing.Models.PaymentMethodFamily? Family { get { throw null; } set { } }
        public string LastFourDigits { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Billing.Models.PaymentMethodLogo> Logos { get { throw null; } }
        public string PaymentMethodType { get { throw null; } }
        public Azure.ResourceManager.Billing.Models.PaymentMethodStatus? Status { get { throw null; } set { } }
        Azure.ResourceManager.Billing.BillingPaymentMethodData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Billing.BillingPaymentMethodData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Billing.BillingPaymentMethodData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Billing.BillingPaymentMethodData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Billing.BillingPaymentMethodData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Billing.BillingPaymentMethodData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Billing.BillingPaymentMethodData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class BillingPaymentMethodLinkCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Billing.BillingPaymentMethodLinkResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Billing.BillingPaymentMethodLinkResource>, System.Collections.IEnumerable
    {
        protected BillingPaymentMethodLinkCollection() { }
        public virtual Azure.Response<bool> Exists(string paymentMethodName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string paymentMethodName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Billing.BillingPaymentMethodLinkResource> Get(string paymentMethodName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Billing.BillingPaymentMethodLinkResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Billing.BillingPaymentMethodLinkResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Billing.BillingPaymentMethodLinkResource>> GetAsync(string paymentMethodName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Billing.BillingPaymentMethodLinkResource> GetIfExists(string paymentMethodName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Billing.BillingPaymentMethodLinkResource>> GetIfExistsAsync(string paymentMethodName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Billing.BillingPaymentMethodLinkResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Billing.BillingPaymentMethodLinkResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Billing.BillingPaymentMethodLinkResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Billing.BillingPaymentMethodLinkResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class BillingPaymentMethodLinkData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Billing.BillingPaymentMethodLinkData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Billing.BillingPaymentMethodLinkData>
    {
        public BillingPaymentMethodLinkData() { }
        public Azure.ResourceManager.Billing.Models.PaymentMethodProjectionProperties PaymentMethod { get { throw null; } set { } }
        Azure.ResourceManager.Billing.BillingPaymentMethodLinkData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Billing.BillingPaymentMethodLinkData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Billing.BillingPaymentMethodLinkData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Billing.BillingPaymentMethodLinkData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Billing.BillingPaymentMethodLinkData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Billing.BillingPaymentMethodLinkData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Billing.BillingPaymentMethodLinkData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class BillingPaymentMethodLinkResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected BillingPaymentMethodLinkResource() { }
        public virtual Azure.ResourceManager.Billing.BillingPaymentMethodLinkData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string billingAccountName, string billingProfileName, string paymentMethodName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Billing.BillingPaymentMethodLinkResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Billing.BillingPaymentMethodLinkResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class BillingPaymentMethodResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected BillingPaymentMethodResource() { }
        public virtual Azure.ResourceManager.Billing.BillingPaymentMethodData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string paymentMethodName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Billing.BillingPaymentMethodResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Billing.BillingPaymentMethodResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
        public virtual Azure.NullableResponse<Azure.ResourceManager.Billing.BillingSubscriptionAliasResource> GetIfExists(string aliasName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Billing.BillingSubscriptionAliasResource>> GetIfExistsAsync(string aliasName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Billing.BillingSubscriptionAliasResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Billing.BillingSubscriptionAliasResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Billing.BillingSubscriptionAliasResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Billing.BillingSubscriptionAliasResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class BillingSubscriptionAliasData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Billing.BillingSubscriptionAliasData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Billing.BillingSubscriptionAliasData>
    {
        public BillingSubscriptionAliasData() { }
        public Azure.ResourceManager.Billing.Models.BillingSubscriptionAutoRenewState? AutoRenew { get { throw null; } set { } }
        public string BeneficiaryTenantId { get { throw null; } set { } }
        public string BillingFrequency { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyDictionary<string, string> BillingPolicies { get { throw null; } }
        public string BillingProfileDisplayName { get { throw null; } }
        public Azure.Core.ResourceIdentifier BillingProfileId { get { throw null; } set { } }
        public string BillingProfileName { get { throw null; } }
        public Azure.Core.ResourceIdentifier BillingSubscriptionId { get { throw null; } }
        public string ConsumptionCostCenter { get { throw null; } set { } }
        public string CustomerDisplayName { get { throw null; } }
        public string CustomerId { get { throw null; } set { } }
        public string DisplayName { get { throw null; } set { } }
        public string EnrollmentAccountDisplayName { get { throw null; } }
        public string EnrollmentAccountId { get { throw null; } }
        public System.DateTimeOffset? EnrollmentAccountStartOn { get { throw null; } }
        public string InvoiceSectionDisplayName { get { throw null; } }
        public Azure.Core.ResourceIdentifier InvoiceSectionId { get { throw null; } set { } }
        public string InvoiceSectionName { get { throw null; } }
        public Azure.ResourceManager.Billing.Models.BillingAmount LastMonthCharges { get { throw null; } }
        public Azure.ResourceManager.Billing.Models.BillingAmount MonthToDateCharges { get { throw null; } }
        public string NextBillingCycleBillingFrequency { get { throw null; } }
        public string OfferId { get { throw null; } }
        public string ProductCategory { get { throw null; } }
        public string ProductType { get { throw null; } }
        public string ProductTypeId { get { throw null; } set { } }
        public System.DateTimeOffset? PurchaseOn { get { throw null; } }
        public long? Quantity { get { throw null; } set { } }
        public Azure.ResourceManager.Billing.Models.SubscriptionRenewalTermDetails RenewalTermDetails { get { throw null; } }
        public Azure.ResourceManager.Billing.Models.CreatedSubscriptionReseller Reseller { get { throw null; } }
        public string SkuDescription { get { throw null; } }
        public string SkuId { get { throw null; } set { } }
        public Azure.ResourceManager.Billing.Models.BillingSubscriptionStatus? Status { get { throw null; } }
        public Azure.ResourceManager.Billing.Models.SubscriptionEnrollmentAccountStatus? SubscriptionEnrollmentAccountStatus { get { throw null; } }
        public string SubscriptionId { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> SuspensionReasons { get { throw null; } }
        public System.TimeSpan? TermDuration { get { throw null; } set { } }
        public System.DateTimeOffset? TermEndOn { get { throw null; } }
        public System.DateTimeOffset? TermStartOn { get { throw null; } }
        Azure.ResourceManager.Billing.BillingSubscriptionAliasData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Billing.BillingSubscriptionAliasData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Billing.BillingSubscriptionAliasData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Billing.BillingSubscriptionAliasData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Billing.BillingSubscriptionAliasData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Billing.BillingSubscriptionAliasData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Billing.BillingSubscriptionAliasData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        public virtual Azure.NullableResponse<Azure.ResourceManager.Billing.BillingSubscriptionResource> GetIfExists(string billingSubscriptionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Billing.BillingSubscriptionResource>> GetIfExistsAsync(string billingSubscriptionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Billing.BillingSubscriptionResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Billing.BillingSubscriptionResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Billing.BillingSubscriptionResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Billing.BillingSubscriptionResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class BillingSubscriptionData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Billing.BillingSubscriptionData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Billing.BillingSubscriptionData>
    {
        public BillingSubscriptionData() { }
        public Azure.ResourceManager.Billing.Models.BillingSubscriptionAutoRenewState? AutoRenew { get { throw null; } set { } }
        public string BeneficiaryTenantId { get { throw null; } set { } }
        public string BillingFrequency { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyDictionary<string, string> BillingPolicies { get { throw null; } }
        public string BillingProfileDisplayName { get { throw null; } }
        public Azure.Core.ResourceIdentifier BillingProfileId { get { throw null; } set { } }
        public string BillingProfileName { get { throw null; } }
        public string ConsumptionCostCenter { get { throw null; } set { } }
        public string CustomerDisplayName { get { throw null; } }
        public string CustomerId { get { throw null; } set { } }
        public string DisplayName { get { throw null; } set { } }
        public string EnrollmentAccountDisplayName { get { throw null; } }
        public string EnrollmentAccountId { get { throw null; } }
        public System.DateTimeOffset? EnrollmentAccountStartOn { get { throw null; } }
        public string InvoiceSectionDisplayName { get { throw null; } }
        public Azure.Core.ResourceIdentifier InvoiceSectionId { get { throw null; } set { } }
        public string InvoiceSectionName { get { throw null; } }
        public Azure.ResourceManager.Billing.Models.BillingAmount LastMonthCharges { get { throw null; } }
        public Azure.ResourceManager.Billing.Models.BillingAmount MonthToDateCharges { get { throw null; } }
        public string NextBillingCycleBillingFrequency { get { throw null; } }
        public string OfferId { get { throw null; } }
        public string ProductCategory { get { throw null; } }
        public string ProductType { get { throw null; } }
        public string ProductTypeId { get { throw null; } set { } }
        public System.DateTimeOffset? PurchaseOn { get { throw null; } }
        public long? Quantity { get { throw null; } set { } }
        public Azure.ResourceManager.Billing.Models.SubscriptionRenewalTermDetails RenewalTermDetails { get { throw null; } }
        public Azure.ResourceManager.Billing.Models.CreatedSubscriptionReseller Reseller { get { throw null; } }
        public string SkuDescription { get { throw null; } }
        public string SkuId { get { throw null; } set { } }
        public Azure.ResourceManager.Billing.Models.BillingSubscriptionStatus? Status { get { throw null; } }
        public Azure.ResourceManager.Billing.Models.SubscriptionEnrollmentAccountStatus? SubscriptionEnrollmentAccountStatus { get { throw null; } }
        public string SubscriptionId { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> SuspensionReasons { get { throw null; } }
        public System.TimeSpan? TermDuration { get { throw null; } set { } }
        public System.DateTimeOffset? TermEndOn { get { throw null; } }
        public System.DateTimeOffset? TermStartOn { get { throw null; } }
        Azure.ResourceManager.Billing.BillingSubscriptionData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Billing.BillingSubscriptionData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Billing.BillingSubscriptionData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Billing.BillingSubscriptionData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Billing.BillingSubscriptionData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Billing.BillingSubscriptionData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Billing.BillingSubscriptionData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Billing.BillingSubscriptionResource> Move(Azure.WaitUntil waitUntil, Azure.ResourceManager.Billing.Models.BillingSubscriptionMoveContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Billing.BillingSubscriptionResource>> MoveAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Billing.Models.BillingSubscriptionMoveContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Billing.BillingSubscriptionResource> Split(Azure.WaitUntil waitUntil, Azure.ResourceManager.Billing.Models.BillingSubscriptionSplitContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Billing.BillingSubscriptionResource>> SplitAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Billing.Models.BillingSubscriptionSplitContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Billing.BillingSubscriptionResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Billing.BillingSubscriptionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Billing.BillingSubscriptionResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Billing.BillingSubscriptionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Billing.Models.BillingSubscriptionValidateMoveEligibilityResult> ValidateMoveEligibility(Azure.ResourceManager.Billing.Models.BillingSubscriptionMoveContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Billing.Models.BillingSubscriptionValidateMoveEligibilityResult>> ValidateMoveEligibilityAsync(Azure.ResourceManager.Billing.Models.BillingSubscriptionMoveContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.Billing.Mocking
{
    public partial class MockableBillingArmClient : Azure.ResourceManager.ArmResource
    {
        protected MockableBillingArmClient() { }
        public virtual Azure.ResourceManager.Billing.BillingAccountPaymentMethodResource GetBillingAccountPaymentMethodResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Billing.BillingPaymentMethodLinkResource GetBillingPaymentMethodLinkResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Billing.BillingPaymentMethodResource GetBillingPaymentMethodResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Billing.BillingSubscriptionAliasResource GetBillingSubscriptionAliasResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Billing.BillingSubscriptionResource GetBillingSubscriptionResource(Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class MockableBillingTenantResource : Azure.ResourceManager.ArmResource
    {
        protected MockableBillingTenantResource() { }
        public virtual Azure.Response<Azure.ResourceManager.Billing.BillingAccountPaymentMethodResource> GetBillingAccountPaymentMethod(string billingAccountName, string paymentMethodName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Billing.BillingAccountPaymentMethodResource>> GetBillingAccountPaymentMethodAsync(string billingAccountName, string paymentMethodName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Billing.BillingAccountPaymentMethodCollection GetBillingAccountPaymentMethods(string billingAccountName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Billing.BillingPaymentMethodResource> GetBillingPaymentMethod(string paymentMethodName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Billing.BillingPaymentMethodResource>> GetBillingPaymentMethodAsync(string paymentMethodName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Billing.BillingPaymentMethodLinkResource> GetBillingPaymentMethodLink(string billingAccountName, string billingProfileName, string paymentMethodName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Billing.BillingPaymentMethodLinkResource>> GetBillingPaymentMethodLinkAsync(string billingAccountName, string billingProfileName, string paymentMethodName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Billing.BillingPaymentMethodLinkCollection GetBillingPaymentMethodLinks(string billingAccountName, string billingProfileName) { throw null; }
        public virtual Azure.ResourceManager.Billing.BillingPaymentMethodCollection GetBillingPaymentMethods() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Billing.BillingSubscriptionResource> GetBillingSubscription(string billingAccountName, string billingSubscriptionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Billing.BillingSubscriptionAliasResource> GetBillingSubscriptionAlias(string billingAccountName, string aliasName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Billing.BillingSubscriptionAliasResource>> GetBillingSubscriptionAliasAsync(string billingAccountName, string aliasName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Billing.BillingSubscriptionAliasCollection GetBillingSubscriptionAliases(string billingAccountName) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Billing.BillingSubscriptionResource>> GetBillingSubscriptionAsync(string billingAccountName, string billingSubscriptionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Billing.BillingSubscriptionCollection GetBillingSubscriptions(string billingAccountName) { throw null; }
    }
}
namespace Azure.ResourceManager.Billing.Models
{
    public static partial class ArmBillingModelFactory
    {
        public static Azure.ResourceManager.Billing.Models.BillingAmount BillingAmount(string currency = null, float? value = default(float?)) { throw null; }
        public static Azure.ResourceManager.Billing.BillingPaymentMethodData BillingPaymentMethodData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.Billing.Models.PaymentMethodFamily? family = default(Azure.ResourceManager.Billing.Models.PaymentMethodFamily?), string paymentMethodType = null, string accountHolderName = null, string expiration = null, string lastFourDigits = null, string displayName = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Billing.Models.PaymentMethodLogo> logos = null, Azure.ResourceManager.Billing.Models.PaymentMethodStatus? status = default(Azure.ResourceManager.Billing.Models.PaymentMethodStatus?)) { throw null; }
        public static Azure.ResourceManager.Billing.BillingPaymentMethodLinkData BillingPaymentMethodLinkData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.Billing.Models.PaymentMethodProjectionProperties paymentMethod = null) { throw null; }
        public static Azure.ResourceManager.Billing.BillingSubscriptionAliasData BillingSubscriptionAliasData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.Billing.Models.BillingSubscriptionAutoRenewState? autoRenew = default(Azure.ResourceManager.Billing.Models.BillingSubscriptionAutoRenewState?), string beneficiaryTenantId = null, string billingFrequency = null, Azure.Core.ResourceIdentifier billingProfileId = null, System.Collections.Generic.IReadOnlyDictionary<string, string> billingPolicies = null, string billingProfileDisplayName = null, string billingProfileName = null, string consumptionCostCenter = null, string customerId = null, string customerDisplayName = null, string displayName = null, string enrollmentAccountId = null, string enrollmentAccountDisplayName = null, Azure.Core.ResourceIdentifier invoiceSectionId = null, string invoiceSectionDisplayName = null, string invoiceSectionName = null, Azure.ResourceManager.Billing.Models.BillingAmount lastMonthCharges = null, Azure.ResourceManager.Billing.Models.BillingAmount monthToDateCharges = null, string nextBillingCycleBillingFrequency = null, string offerId = null, string productCategory = null, string productType = null, string productTypeId = null, System.DateTimeOffset? purchaseOn = default(System.DateTimeOffset?), long? quantity = default(long?), Azure.ResourceManager.Billing.Models.CreatedSubscriptionReseller reseller = null, Azure.ResourceManager.Billing.Models.SubscriptionRenewalTermDetails renewalTermDetails = null, string skuDescription = null, string skuId = null, Azure.ResourceManager.Billing.Models.BillingSubscriptionStatus? status = default(Azure.ResourceManager.Billing.Models.BillingSubscriptionStatus?), string subscriptionId = null, System.Collections.Generic.IEnumerable<string> suspensionReasons = null, System.TimeSpan? termDuration = default(System.TimeSpan?), System.DateTimeOffset? termStartOn = default(System.DateTimeOffset?), System.DateTimeOffset? termEndOn = default(System.DateTimeOffset?), Azure.ResourceManager.Billing.Models.SubscriptionEnrollmentAccountStatus? subscriptionEnrollmentAccountStatus = default(Azure.ResourceManager.Billing.Models.SubscriptionEnrollmentAccountStatus?), System.DateTimeOffset? enrollmentAccountStartOn = default(System.DateTimeOffset?), Azure.Core.ResourceIdentifier billingSubscriptionId = null) { throw null; }
        public static Azure.ResourceManager.Billing.BillingSubscriptionData BillingSubscriptionData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.Billing.Models.BillingSubscriptionAutoRenewState? autoRenew = default(Azure.ResourceManager.Billing.Models.BillingSubscriptionAutoRenewState?), string beneficiaryTenantId = null, string billingFrequency = null, Azure.Core.ResourceIdentifier billingProfileId = null, System.Collections.Generic.IReadOnlyDictionary<string, string> billingPolicies = null, string billingProfileDisplayName = null, string billingProfileName = null, string consumptionCostCenter = null, string customerId = null, string customerDisplayName = null, string displayName = null, string enrollmentAccountId = null, string enrollmentAccountDisplayName = null, Azure.Core.ResourceIdentifier invoiceSectionId = null, string invoiceSectionDisplayName = null, string invoiceSectionName = null, Azure.ResourceManager.Billing.Models.BillingAmount lastMonthCharges = null, Azure.ResourceManager.Billing.Models.BillingAmount monthToDateCharges = null, string nextBillingCycleBillingFrequency = null, string offerId = null, string productCategory = null, string productType = null, string productTypeId = null, System.DateTimeOffset? purchaseOn = default(System.DateTimeOffset?), long? quantity = default(long?), Azure.ResourceManager.Billing.Models.CreatedSubscriptionReseller reseller = null, Azure.ResourceManager.Billing.Models.SubscriptionRenewalTermDetails renewalTermDetails = null, string skuDescription = null, string skuId = null, Azure.ResourceManager.Billing.Models.BillingSubscriptionStatus? status = default(Azure.ResourceManager.Billing.Models.BillingSubscriptionStatus?), string subscriptionId = null, System.Collections.Generic.IEnumerable<string> suspensionReasons = null, System.TimeSpan? termDuration = default(System.TimeSpan?), System.DateTimeOffset? termStartOn = default(System.DateTimeOffset?), System.DateTimeOffset? termEndOn = default(System.DateTimeOffset?), Azure.ResourceManager.Billing.Models.SubscriptionEnrollmentAccountStatus? subscriptionEnrollmentAccountStatus = default(Azure.ResourceManager.Billing.Models.SubscriptionEnrollmentAccountStatus?), System.DateTimeOffset? enrollmentAccountStartOn = default(System.DateTimeOffset?)) { throw null; }
        public static Azure.ResourceManager.Billing.Models.BillingSubscriptionValidateMoveEligibilityError BillingSubscriptionValidateMoveEligibilityError(Azure.ResourceManager.Billing.Models.SubscriptionTransferValidationErrorCode? code = default(Azure.ResourceManager.Billing.Models.SubscriptionTransferValidationErrorCode?), string message = null, string details = null) { throw null; }
        public static Azure.ResourceManager.Billing.Models.BillingSubscriptionValidateMoveEligibilityResult BillingSubscriptionValidateMoveEligibilityResult(bool? isMoveEligible = default(bool?), Azure.ResourceManager.Billing.Models.BillingSubscriptionValidateMoveEligibilityError errorDetails = null) { throw null; }
        public static Azure.ResourceManager.Billing.Models.CreatedSubscriptionReseller CreatedSubscriptionReseller(string resellerId = null, string description = null) { throw null; }
        public static Azure.ResourceManager.Billing.Models.PaymentMethodLogo PaymentMethodLogo(string mimeType = null, System.Uri uri = null) { throw null; }
        public static Azure.ResourceManager.Billing.Models.PaymentMethodProjectionProperties PaymentMethodProjectionProperties(Azure.Core.ResourceIdentifier paymentMethodId = null, Azure.ResourceManager.Billing.Models.PaymentMethodFamily? family = default(Azure.ResourceManager.Billing.Models.PaymentMethodFamily?), string paymentMethodProjectionPropertiesType = null, string accountHolderName = null, string expiration = null, string lastFourDigits = null, string displayName = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Billing.Models.PaymentMethodLogo> logos = null, Azure.ResourceManager.Billing.Models.PaymentMethodStatus? status = default(Azure.ResourceManager.Billing.Models.PaymentMethodStatus?)) { throw null; }
        public static Azure.ResourceManager.Billing.Models.SubscriptionRenewalTermDetails SubscriptionRenewalTermDetails(string billingFrequency = null, string productTypeId = null, long? quantity = default(long?), string skuId = null, System.TimeSpan? termDuration = default(System.TimeSpan?)) { throw null; }
    }
    public partial class BillingAmount : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Billing.Models.BillingAmount>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Billing.Models.BillingAmount>
    {
        internal BillingAmount() { }
        public string Currency { get { throw null; } }
        public float? Value { get { throw null; } }
        Azure.ResourceManager.Billing.Models.BillingAmount System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Billing.Models.BillingAmount>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Billing.Models.BillingAmount>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Billing.Models.BillingAmount System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Billing.Models.BillingAmount>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Billing.Models.BillingAmount>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Billing.Models.BillingAmount>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct BillingSubscriptionAutoRenewState : System.IEquatable<Azure.ResourceManager.Billing.Models.BillingSubscriptionAutoRenewState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public BillingSubscriptionAutoRenewState(string value) { throw null; }
        public static Azure.ResourceManager.Billing.Models.BillingSubscriptionAutoRenewState Off { get { throw null; } }
        public static Azure.ResourceManager.Billing.Models.BillingSubscriptionAutoRenewState On { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Billing.Models.BillingSubscriptionAutoRenewState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Billing.Models.BillingSubscriptionAutoRenewState left, Azure.ResourceManager.Billing.Models.BillingSubscriptionAutoRenewState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Billing.Models.BillingSubscriptionAutoRenewState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Billing.Models.BillingSubscriptionAutoRenewState left, Azure.ResourceManager.Billing.Models.BillingSubscriptionAutoRenewState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class BillingSubscriptionMergeContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Billing.Models.BillingSubscriptionMergeContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Billing.Models.BillingSubscriptionMergeContent>
    {
        public BillingSubscriptionMergeContent() { }
        public int? Quantity { get { throw null; } set { } }
        public string TargetBillingSubscriptionName { get { throw null; } set { } }
        Azure.ResourceManager.Billing.Models.BillingSubscriptionMergeContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Billing.Models.BillingSubscriptionMergeContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Billing.Models.BillingSubscriptionMergeContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Billing.Models.BillingSubscriptionMergeContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Billing.Models.BillingSubscriptionMergeContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Billing.Models.BillingSubscriptionMergeContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Billing.Models.BillingSubscriptionMergeContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class BillingSubscriptionMoveContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Billing.Models.BillingSubscriptionMoveContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Billing.Models.BillingSubscriptionMoveContent>
    {
        public BillingSubscriptionMoveContent() { }
        public string DestinationEnrollmentAccountId { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier DestinationInvoiceSectionId { get { throw null; } set { } }
        Azure.ResourceManager.Billing.Models.BillingSubscriptionMoveContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Billing.Models.BillingSubscriptionMoveContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Billing.Models.BillingSubscriptionMoveContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Billing.Models.BillingSubscriptionMoveContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Billing.Models.BillingSubscriptionMoveContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Billing.Models.BillingSubscriptionMoveContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Billing.Models.BillingSubscriptionMoveContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class BillingSubscriptionSplitContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Billing.Models.BillingSubscriptionSplitContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Billing.Models.BillingSubscriptionSplitContent>
    {
        public BillingSubscriptionSplitContent() { }
        public string BillingFrequency { get { throw null; } set { } }
        public int? Quantity { get { throw null; } set { } }
        public string TargetProductTypeId { get { throw null; } set { } }
        public string TargetSkuId { get { throw null; } set { } }
        public System.TimeSpan? TermDuration { get { throw null; } set { } }
        Azure.ResourceManager.Billing.Models.BillingSubscriptionSplitContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Billing.Models.BillingSubscriptionSplitContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Billing.Models.BillingSubscriptionSplitContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Billing.Models.BillingSubscriptionSplitContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Billing.Models.BillingSubscriptionSplitContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Billing.Models.BillingSubscriptionSplitContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Billing.Models.BillingSubscriptionSplitContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
    public partial class BillingSubscriptionValidateMoveEligibilityError : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Billing.Models.BillingSubscriptionValidateMoveEligibilityError>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Billing.Models.BillingSubscriptionValidateMoveEligibilityError>
    {
        internal BillingSubscriptionValidateMoveEligibilityError() { }
        public Azure.ResourceManager.Billing.Models.SubscriptionTransferValidationErrorCode? Code { get { throw null; } }
        public string Details { get { throw null; } }
        public string Message { get { throw null; } }
        Azure.ResourceManager.Billing.Models.BillingSubscriptionValidateMoveEligibilityError System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Billing.Models.BillingSubscriptionValidateMoveEligibilityError>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Billing.Models.BillingSubscriptionValidateMoveEligibilityError>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Billing.Models.BillingSubscriptionValidateMoveEligibilityError System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Billing.Models.BillingSubscriptionValidateMoveEligibilityError>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Billing.Models.BillingSubscriptionValidateMoveEligibilityError>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Billing.Models.BillingSubscriptionValidateMoveEligibilityError>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class BillingSubscriptionValidateMoveEligibilityResult : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Billing.Models.BillingSubscriptionValidateMoveEligibilityResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Billing.Models.BillingSubscriptionValidateMoveEligibilityResult>
    {
        internal BillingSubscriptionValidateMoveEligibilityResult() { }
        public Azure.ResourceManager.Billing.Models.BillingSubscriptionValidateMoveEligibilityError ErrorDetails { get { throw null; } }
        public bool? IsMoveEligible { get { throw null; } }
        Azure.ResourceManager.Billing.Models.BillingSubscriptionValidateMoveEligibilityResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Billing.Models.BillingSubscriptionValidateMoveEligibilityResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Billing.Models.BillingSubscriptionValidateMoveEligibilityResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Billing.Models.BillingSubscriptionValidateMoveEligibilityResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Billing.Models.BillingSubscriptionValidateMoveEligibilityResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Billing.Models.BillingSubscriptionValidateMoveEligibilityResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Billing.Models.BillingSubscriptionValidateMoveEligibilityResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CreatedSubscriptionReseller : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Billing.Models.CreatedSubscriptionReseller>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Billing.Models.CreatedSubscriptionReseller>
    {
        internal CreatedSubscriptionReseller() { }
        public string Description { get { throw null; } }
        public string ResellerId { get { throw null; } }
        Azure.ResourceManager.Billing.Models.CreatedSubscriptionReseller System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Billing.Models.CreatedSubscriptionReseller>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Billing.Models.CreatedSubscriptionReseller>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Billing.Models.CreatedSubscriptionReseller System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Billing.Models.CreatedSubscriptionReseller>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Billing.Models.CreatedSubscriptionReseller>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Billing.Models.CreatedSubscriptionReseller>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
    public partial class PaymentMethodLogo : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Billing.Models.PaymentMethodLogo>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Billing.Models.PaymentMethodLogo>
    {
        public PaymentMethodLogo() { }
        public string MimeType { get { throw null; } }
        public System.Uri Uri { get { throw null; } }
        Azure.ResourceManager.Billing.Models.PaymentMethodLogo System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Billing.Models.PaymentMethodLogo>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Billing.Models.PaymentMethodLogo>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Billing.Models.PaymentMethodLogo System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Billing.Models.PaymentMethodLogo>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Billing.Models.PaymentMethodLogo>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Billing.Models.PaymentMethodLogo>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PaymentMethodProjectionProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Billing.Models.PaymentMethodProjectionProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Billing.Models.PaymentMethodProjectionProperties>
    {
        public PaymentMethodProjectionProperties() { }
        public string AccountHolderName { get { throw null; } }
        public string DisplayName { get { throw null; } }
        public string Expiration { get { throw null; } }
        public Azure.ResourceManager.Billing.Models.PaymentMethodFamily? Family { get { throw null; } set { } }
        public string LastFourDigits { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Billing.Models.PaymentMethodLogo> Logos { get { throw null; } }
        public Azure.Core.ResourceIdentifier PaymentMethodId { get { throw null; } }
        public string PaymentMethodProjectionPropertiesType { get { throw null; } }
        public Azure.ResourceManager.Billing.Models.PaymentMethodStatus? Status { get { throw null; } set { } }
        Azure.ResourceManager.Billing.Models.PaymentMethodProjectionProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Billing.Models.PaymentMethodProjectionProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Billing.Models.PaymentMethodProjectionProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Billing.Models.PaymentMethodProjectionProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Billing.Models.PaymentMethodProjectionProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Billing.Models.PaymentMethodProjectionProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Billing.Models.PaymentMethodProjectionProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
    public partial class SubscriptionRenewalTermDetails : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Billing.Models.SubscriptionRenewalTermDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Billing.Models.SubscriptionRenewalTermDetails>
    {
        internal SubscriptionRenewalTermDetails() { }
        public string BillingFrequency { get { throw null; } }
        public string ProductTypeId { get { throw null; } }
        public long? Quantity { get { throw null; } }
        public string SkuId { get { throw null; } }
        public System.TimeSpan? TermDuration { get { throw null; } }
        Azure.ResourceManager.Billing.Models.SubscriptionRenewalTermDetails System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Billing.Models.SubscriptionRenewalTermDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Billing.Models.SubscriptionRenewalTermDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Billing.Models.SubscriptionRenewalTermDetails System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Billing.Models.SubscriptionRenewalTermDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Billing.Models.SubscriptionRenewalTermDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Billing.Models.SubscriptionRenewalTermDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
}
