namespace Azure.ResourceManager.BillingBenefits
{
    public partial class AzureResourceManagerBillingBenefitsContext : System.ClientModel.Primitives.ModelReaderWriterContext
    {
        internal AzureResourceManagerBillingBenefitsContext() { }
        public static Azure.ResourceManager.BillingBenefits.AzureResourceManagerBillingBenefitsContext Default { get { throw null; } }
        protected override bool TryGetTypeBuilderCore(System.Type type, out System.ClientModel.Primitives.ModelReaderWriterTypeBuilder builder) { throw null; }
    }
    public static partial class BillingBenefitsExtensions
    {
        public static Azure.Pageable<Azure.ResourceManager.BillingBenefits.Models.ApplicableMacc> GetAll(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.BillingBenefits.MaccResource> GetAll(this Azure.ResourceManager.Resources.TenantResource tenantResource, Azure.ResourceManager.BillingBenefits.Models.SellerResourceListRequest content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.BillingBenefits.Models.ApplicableMacc> GetAllAsync(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.BillingBenefits.MaccResource> GetAllAsync(this Azure.ResourceManager.Resources.TenantResource tenantResource, Azure.ResourceManager.BillingBenefits.Models.SellerResourceListRequest content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.BillingBenefits.FreeServicesCollection GetAllFreeServices(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.BillingBenefits.CreditResource> GetApplicable(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.BillingBenefits.CreditResource> GetApplicableAsync(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.BillingBenefits.BillingBenefitsReservationOrderAliasResource> GetBillingBenefitsReservationOrderAlias(this Azure.ResourceManager.Resources.TenantResource tenantResource, string reservationOrderAliasName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.BillingBenefits.BillingBenefitsReservationOrderAliasResource>> GetBillingBenefitsReservationOrderAliasAsync(this Azure.ResourceManager.Resources.TenantResource tenantResource, string reservationOrderAliasName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.BillingBenefits.BillingBenefitsReservationOrderAliasCollection GetBillingBenefitsReservationOrderAliases(this Azure.ResourceManager.Resources.TenantResource tenantResource) { throw null; }
        public static Azure.ResourceManager.BillingBenefits.BillingBenefitsReservationOrderAliasResource GetBillingBenefitsReservationOrderAliasResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.BillingBenefits.BillingBenefitsSavingsPlanOrderResource> GetBillingBenefitsSavingsPlanOrder(this Azure.ResourceManager.Resources.TenantResource tenantResource, string savingsPlanOrderId, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.BillingBenefits.BillingBenefitsSavingsPlanOrderAliasResource> GetBillingBenefitsSavingsPlanOrderAlias(this Azure.ResourceManager.Resources.TenantResource tenantResource, string savingsPlanOrderAliasName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.BillingBenefits.BillingBenefitsSavingsPlanOrderAliasResource>> GetBillingBenefitsSavingsPlanOrderAliasAsync(this Azure.ResourceManager.Resources.TenantResource tenantResource, string savingsPlanOrderAliasName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.BillingBenefits.BillingBenefitsSavingsPlanOrderAliasCollection GetBillingBenefitsSavingsPlanOrderAliases(this Azure.ResourceManager.Resources.TenantResource tenantResource) { throw null; }
        public static Azure.ResourceManager.BillingBenefits.BillingBenefitsSavingsPlanOrderAliasResource GetBillingBenefitsSavingsPlanOrderAliasResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.BillingBenefits.BillingBenefitsSavingsPlanOrderResource>> GetBillingBenefitsSavingsPlanOrderAsync(this Azure.ResourceManager.Resources.TenantResource tenantResource, string savingsPlanOrderId, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.BillingBenefits.BillingBenefitsSavingsPlanOrderResource GetBillingBenefitsSavingsPlanOrderResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.BillingBenefits.BillingBenefitsSavingsPlanOrderCollection GetBillingBenefitsSavingsPlanOrders(this Azure.ResourceManager.Resources.TenantResource tenantResource) { throw null; }
        public static Azure.ResourceManager.BillingBenefits.BillingBenefitsSavingsPlanResource GetBillingBenefitsSavingsPlanResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.BillingBenefits.BillingBenefitsSavingsPlanResource> GetBillingBenefitsSavingsPlans(this Azure.ResourceManager.Resources.TenantResource tenantResource, string filter = null, string orderby = null, string refreshSummary = null, float? skiptoken = default(float?), string selectedState = null, float? take = default(float?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.BillingBenefits.BillingBenefitsSavingsPlanResource> GetBillingBenefitsSavingsPlansAsync(this Azure.ResourceManager.Resources.TenantResource tenantResource, string filter = null, string orderby = null, string refreshSummary = null, float? skiptoken = default(float?), string selectedState = null, float? take = default(float?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.BillingBenefits.ConditionalCreditResource> GetConditionalCredit(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string conditionalCreditName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.BillingBenefits.ConditionalCreditResource>> GetConditionalCreditAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string conditionalCreditName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.BillingBenefits.ConditionalCreditResource> GetConditionalCreditByScope(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.BillingBenefits.ConditionalCreditResource> GetConditionalCreditByScopeAsync(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.BillingBenefits.ConditionalCreditContributorResource GetConditionalCreditContributorResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.BillingBenefits.ConditionalCreditResource GetConditionalCreditResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.BillingBenefits.ConditionalCreditCollection GetConditionalCredits(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.BillingBenefits.ConditionalCreditResource> GetConditionalCredits(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.BillingBenefits.ConditionalCreditResource> GetConditionalCreditsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.BillingBenefits.ContributorResource GetContributorResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.BillingBenefits.CreditResource> GetCredit(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string creditName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.BillingBenefits.CreditResource>> GetCreditAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string creditName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.BillingBenefits.CreditResource GetCreditResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.BillingBenefits.CreditCollection GetCredits(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.BillingBenefits.CreditResource> GetCredits(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.BillingBenefits.CreditResource> GetCreditsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.BillingBenefits.CreditSourceResource GetCreditSourceResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.BillingBenefits.DiscountResource> GetDiscount(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string discountName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.BillingBenefits.DiscountResource>> GetDiscountAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string discountName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.BillingBenefits.DiscountResource> GetDiscountByScope(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.BillingBenefits.DiscountResource> GetDiscountByScopeAsync(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.BillingBenefits.DiscountResource GetDiscountResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.BillingBenefits.DiscountCollection GetDiscounts(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.BillingBenefits.DiscountResource> GetDiscounts(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.BillingBenefits.DiscountResource> GetDiscountsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.BillingBenefits.FreeServicesResource> GetFreeServices(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string freeServiceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.BillingBenefits.FreeServicesResource> GetFreeServices(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.BillingBenefits.FreeServicesResource>> GetFreeServicesAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string freeServiceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.BillingBenefits.FreeServicesResource> GetFreeServicesAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.BillingBenefits.FreeServicesResource GetFreeServicesResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.BillingBenefits.ConditionalCreditContributorResource> GetFromApplicableConditionalCredit(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.BillingBenefits.ConditionalCreditContributorResource> GetFromApplicableConditionalCreditAsync(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.BillingBenefits.ContributorResource> GetFromApplicableMacc(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.BillingBenefits.ContributorResource> GetFromApplicableMaccAsync(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.BillingBenefits.MaccResource> GetMacc(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string maccName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.BillingBenefits.MaccResource>> GetMaccAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string maccName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.BillingBenefits.MaccResource GetMaccResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.BillingBenefits.MaccCollection GetMaccs(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.BillingBenefits.MaccResource> GetMaccs(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.BillingBenefits.MaccResource> GetMaccsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.BillingBenefits.Models.BenefitValidateResponse> Validate(this Azure.ResourceManager.Resources.TenantResource tenantResource, Azure.ResourceManager.BillingBenefits.Models.BenefitValidateRequest content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.BillingBenefits.Models.BenefitValidateResponse>> ValidateAsync(this Azure.ResourceManager.Resources.TenantResource tenantResource, Azure.ResourceManager.BillingBenefits.Models.BenefitValidateRequest content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class BillingBenefitsReservationOrderAliasCollection : Azure.ResourceManager.ArmCollection
    {
        protected BillingBenefitsReservationOrderAliasCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.BillingBenefits.BillingBenefitsReservationOrderAliasResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string reservationOrderAliasName, Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsReservationOrderAliasCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.BillingBenefits.BillingBenefitsReservationOrderAliasResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string reservationOrderAliasName, Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsReservationOrderAliasCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string reservationOrderAliasName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string reservationOrderAliasName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.BillingBenefits.BillingBenefitsReservationOrderAliasResource> Get(string reservationOrderAliasName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.BillingBenefits.BillingBenefitsReservationOrderAliasResource>> GetAsync(string reservationOrderAliasName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.BillingBenefits.BillingBenefitsReservationOrderAliasResource> GetIfExists(string reservationOrderAliasName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.BillingBenefits.BillingBenefitsReservationOrderAliasResource>> GetIfExistsAsync(string reservationOrderAliasName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class BillingBenefitsReservationOrderAliasData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.BillingBenefits.BillingBenefitsReservationOrderAliasData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.BillingBenefits.BillingBenefitsReservationOrderAliasData>
    {
        public BillingBenefitsReservationOrderAliasData() { }
        public Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsAppliedScopeProperties AppliedScopeProperties { get { throw null; } set { } }
        public Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsAppliedScopeType? AppliedScopeType { get { throw null; } set { } }
        public Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsBillingPlan? BillingPlan { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier BillingScopeId { get { throw null; } set { } }
        public string DisplayName { get { throw null; } set { } }
        public bool? IsRenewed { get { throw null; } set { } }
        public Azure.Core.AzureLocation? Location { get { throw null; } set { } }
        public Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsProvisioningState? ProvisioningState { get { throw null; } }
        public int? Quantity { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier ReservationOrderId { get { throw null; } }
        public Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsInstanceFlexibility? ReservedResourceInstanceFlexibility { get { throw null; } set { } }
        public Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsReservedResourceType? ReservedResourceType { get { throw null; } set { } }
        public System.DateTimeOffset? ReviewOn { get { throw null; } set { } }
        public string SkuName { get { throw null; } set { } }
        public Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsTerm? Term { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.BillingBenefits.BillingBenefitsReservationOrderAliasData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.BillingBenefits.BillingBenefitsReservationOrderAliasData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.BillingBenefits.BillingBenefitsReservationOrderAliasData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.BillingBenefits.BillingBenefitsReservationOrderAliasData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.BillingBenefits.BillingBenefitsReservationOrderAliasData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.BillingBenefits.BillingBenefitsReservationOrderAliasData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.BillingBenefits.BillingBenefitsReservationOrderAliasData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class BillingBenefitsReservationOrderAliasResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.BillingBenefits.BillingBenefitsReservationOrderAliasData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.BillingBenefits.BillingBenefitsReservationOrderAliasData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected BillingBenefitsReservationOrderAliasResource() { }
        public virtual Azure.ResourceManager.BillingBenefits.BillingBenefitsReservationOrderAliasData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string reservationOrderAliasName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.BillingBenefits.BillingBenefitsReservationOrderAliasResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.BillingBenefits.BillingBenefitsReservationOrderAliasResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.BillingBenefits.BillingBenefitsReservationOrderAliasData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.BillingBenefits.BillingBenefitsReservationOrderAliasData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.BillingBenefits.BillingBenefitsReservationOrderAliasData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.BillingBenefits.BillingBenefitsReservationOrderAliasData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.BillingBenefits.BillingBenefitsReservationOrderAliasData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.BillingBenefits.BillingBenefitsReservationOrderAliasData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.BillingBenefits.BillingBenefitsReservationOrderAliasData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.BillingBenefits.BillingBenefitsReservationOrderAliasResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsReservationOrderAliasCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.BillingBenefits.BillingBenefitsReservationOrderAliasResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsReservationOrderAliasCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class BillingBenefitsSavingsPlanCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.BillingBenefits.BillingBenefitsSavingsPlanResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.BillingBenefits.BillingBenefitsSavingsPlanResource>, System.Collections.IEnumerable
    {
        protected BillingBenefitsSavingsPlanCollection() { }
        public virtual Azure.Response<bool> Exists(string savingsPlanId, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string savingsPlanId, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.BillingBenefits.BillingBenefitsSavingsPlanResource> Get(string savingsPlanId, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.BillingBenefits.BillingBenefitsSavingsPlanResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.BillingBenefits.BillingBenefitsSavingsPlanResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.BillingBenefits.BillingBenefitsSavingsPlanResource>> GetAsync(string savingsPlanId, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.BillingBenefits.BillingBenefitsSavingsPlanResource> GetIfExists(string savingsPlanId, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.BillingBenefits.BillingBenefitsSavingsPlanResource>> GetIfExistsAsync(string savingsPlanId, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.BillingBenefits.BillingBenefitsSavingsPlanResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.BillingBenefits.BillingBenefitsSavingsPlanResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.BillingBenefits.BillingBenefitsSavingsPlanResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.BillingBenefits.BillingBenefitsSavingsPlanResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class BillingBenefitsSavingsPlanData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.BillingBenefits.BillingBenefitsSavingsPlanData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.BillingBenefits.BillingBenefitsSavingsPlanData>
    {
        public BillingBenefitsSavingsPlanData() { }
        public Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsAppliedScopeProperties AppliedScopeProperties { get { throw null; } set { } }
        public Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsAppliedScopeType? AppliedScopeType { get { throw null; } set { } }
        public System.DateTimeOffset? BenefitStartOn { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier BillingAccountId { get { throw null; } }
        public Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsBillingPlan? BillingPlan { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier BillingProfileId { get { throw null; } }
        public Azure.Core.ResourceIdentifier BillingScopeId { get { throw null; } set { } }
        public Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsCommitment Commitment { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier CustomerId { get { throw null; } }
        public string DisplayName { get { throw null; } set { } }
        public string DisplayProvisioningState { get { throw null; } }
        public System.DateTimeOffset? EffectOn { get { throw null; } }
        public System.DateTimeOffset? ExpireOn { get { throw null; } }
        public Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsExtendedStatusInfo ExtendedStatusInfo { get { throw null; } }
        public bool? IsRenewed { get { throw null; } set { } }
        public Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsProvisioningState? ProvisioningState { get { throw null; } }
        public System.DateTimeOffset? PurchaseOn { get { throw null; } }
        public string RenewDestination { get { throw null; } set { } }
        public Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsPurchaseContent RenewPurchaseProperties { get { throw null; } set { } }
        public string RenewSource { get { throw null; } set { } }
        public string SkuName { get { throw null; } set { } }
        public Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsTerm? Term { get { throw null; } set { } }
        public string UserFriendlyAppliedScopeType { get { throw null; } }
        public Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsSavingsPlanUtilization Utilization { get { throw null; } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.BillingBenefits.BillingBenefitsSavingsPlanData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.BillingBenefits.BillingBenefitsSavingsPlanData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.BillingBenefits.BillingBenefitsSavingsPlanData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.BillingBenefits.BillingBenefitsSavingsPlanData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.BillingBenefits.BillingBenefitsSavingsPlanData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.BillingBenefits.BillingBenefitsSavingsPlanData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.BillingBenefits.BillingBenefitsSavingsPlanData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class BillingBenefitsSavingsPlanOrderAliasCollection : Azure.ResourceManager.ArmCollection
    {
        protected BillingBenefitsSavingsPlanOrderAliasCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.BillingBenefits.BillingBenefitsSavingsPlanOrderAliasResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string savingsPlanOrderAliasName, Azure.ResourceManager.BillingBenefits.BillingBenefitsSavingsPlanOrderAliasData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.BillingBenefits.BillingBenefitsSavingsPlanOrderAliasResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string savingsPlanOrderAliasName, Azure.ResourceManager.BillingBenefits.BillingBenefitsSavingsPlanOrderAliasData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string savingsPlanOrderAliasName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string savingsPlanOrderAliasName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.BillingBenefits.BillingBenefitsSavingsPlanOrderAliasResource> Get(string savingsPlanOrderAliasName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.BillingBenefits.BillingBenefitsSavingsPlanOrderAliasResource>> GetAsync(string savingsPlanOrderAliasName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.BillingBenefits.BillingBenefitsSavingsPlanOrderAliasResource> GetIfExists(string savingsPlanOrderAliasName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.BillingBenefits.BillingBenefitsSavingsPlanOrderAliasResource>> GetIfExistsAsync(string savingsPlanOrderAliasName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class BillingBenefitsSavingsPlanOrderAliasData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.BillingBenefits.BillingBenefitsSavingsPlanOrderAliasData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.BillingBenefits.BillingBenefitsSavingsPlanOrderAliasData>
    {
        public BillingBenefitsSavingsPlanOrderAliasData() { }
        public Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsAppliedScopeProperties AppliedScopeProperties { get { throw null; } set { } }
        public Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsAppliedScopeType? AppliedScopeType { get { throw null; } set { } }
        public Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsBillingPlan? BillingPlan { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier BillingScopeId { get { throw null; } set { } }
        public Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsCommitment Commitment { get { throw null; } set { } }
        public string DisplayName { get { throw null; } set { } }
        public bool? IsRenewed { get { throw null; } set { } }
        public string Kind { get { throw null; } set { } }
        public Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.Core.ResourceIdentifier SavingsPlanOrderId { get { throw null; } }
        public string SkuName { get { throw null; } set { } }
        public Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsTerm? Term { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.BillingBenefits.BillingBenefitsSavingsPlanOrderAliasData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.BillingBenefits.BillingBenefitsSavingsPlanOrderAliasData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.BillingBenefits.BillingBenefitsSavingsPlanOrderAliasData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.BillingBenefits.BillingBenefitsSavingsPlanOrderAliasData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.BillingBenefits.BillingBenefitsSavingsPlanOrderAliasData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.BillingBenefits.BillingBenefitsSavingsPlanOrderAliasData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.BillingBenefits.BillingBenefitsSavingsPlanOrderAliasData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class BillingBenefitsSavingsPlanOrderAliasResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.BillingBenefits.BillingBenefitsSavingsPlanOrderAliasData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.BillingBenefits.BillingBenefitsSavingsPlanOrderAliasData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected BillingBenefitsSavingsPlanOrderAliasResource() { }
        public virtual Azure.ResourceManager.BillingBenefits.BillingBenefitsSavingsPlanOrderAliasData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string savingsPlanOrderAliasName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.BillingBenefits.BillingBenefitsSavingsPlanOrderAliasResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.BillingBenefits.BillingBenefitsSavingsPlanOrderAliasResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.BillingBenefits.BillingBenefitsSavingsPlanOrderAliasData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.BillingBenefits.BillingBenefitsSavingsPlanOrderAliasData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.BillingBenefits.BillingBenefitsSavingsPlanOrderAliasData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.BillingBenefits.BillingBenefitsSavingsPlanOrderAliasData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.BillingBenefits.BillingBenefitsSavingsPlanOrderAliasData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.BillingBenefits.BillingBenefitsSavingsPlanOrderAliasData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.BillingBenefits.BillingBenefitsSavingsPlanOrderAliasData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.BillingBenefits.BillingBenefitsSavingsPlanOrderAliasResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.BillingBenefits.BillingBenefitsSavingsPlanOrderAliasData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.BillingBenefits.BillingBenefitsSavingsPlanOrderAliasResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.BillingBenefits.BillingBenefitsSavingsPlanOrderAliasData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class BillingBenefitsSavingsPlanOrderCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.BillingBenefits.BillingBenefitsSavingsPlanOrderResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.BillingBenefits.BillingBenefitsSavingsPlanOrderResource>, System.Collections.IEnumerable
    {
        protected BillingBenefitsSavingsPlanOrderCollection() { }
        public virtual Azure.Response<bool> Exists(string savingsPlanOrderId, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string savingsPlanOrderId, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.BillingBenefits.BillingBenefitsSavingsPlanOrderResource> Get(string savingsPlanOrderId, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.BillingBenefits.BillingBenefitsSavingsPlanOrderResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.BillingBenefits.BillingBenefitsSavingsPlanOrderResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.BillingBenefits.BillingBenefitsSavingsPlanOrderResource>> GetAsync(string savingsPlanOrderId, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.BillingBenefits.BillingBenefitsSavingsPlanOrderResource> GetIfExists(string savingsPlanOrderId, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.BillingBenefits.BillingBenefitsSavingsPlanOrderResource>> GetIfExistsAsync(string savingsPlanOrderId, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.BillingBenefits.BillingBenefitsSavingsPlanOrderResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.BillingBenefits.BillingBenefitsSavingsPlanOrderResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.BillingBenefits.BillingBenefitsSavingsPlanOrderResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.BillingBenefits.BillingBenefitsSavingsPlanOrderResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class BillingBenefitsSavingsPlanOrderData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.BillingBenefits.BillingBenefitsSavingsPlanOrderData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.BillingBenefits.BillingBenefitsSavingsPlanOrderData>
    {
        public BillingBenefitsSavingsPlanOrderData() { }
        public System.DateTimeOffset? BenefitStartOn { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier BillingAccountId { get { throw null; } }
        public Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsBillingPlan? BillingPlan { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier BillingProfileId { get { throw null; } }
        public Azure.Core.ResourceIdentifier BillingScopeId { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier CustomerId { get { throw null; } }
        public string DisplayName { get { throw null; } set { } }
        public System.DateTimeOffset? ExpireOn { get { throw null; } }
        public Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsExtendedStatusInfo ExtendedStatusInfo { get { throw null; } }
        public Azure.ResourceManager.BillingBenefits.Models.BillingPlanInformation PlanInformation { get { throw null; } set { } }
        public Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsProvisioningState? ProvisioningState { get { throw null; } }
        public System.Collections.Generic.IList<string> SavingsPlans { get { throw null; } }
        public string SkuName { get { throw null; } set { } }
        public Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsTerm? Term { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.BillingBenefits.BillingBenefitsSavingsPlanOrderData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.BillingBenefits.BillingBenefitsSavingsPlanOrderData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.BillingBenefits.BillingBenefitsSavingsPlanOrderData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.BillingBenefits.BillingBenefitsSavingsPlanOrderData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.BillingBenefits.BillingBenefitsSavingsPlanOrderData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.BillingBenefits.BillingBenefitsSavingsPlanOrderData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.BillingBenefits.BillingBenefitsSavingsPlanOrderData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class BillingBenefitsSavingsPlanOrderResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.BillingBenefits.BillingBenefitsSavingsPlanOrderData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.BillingBenefits.BillingBenefitsSavingsPlanOrderData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected BillingBenefitsSavingsPlanOrderResource() { }
        public virtual Azure.ResourceManager.BillingBenefits.BillingBenefitsSavingsPlanOrderData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string savingsPlanOrderId) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsRoleAssignmentEntity> Elevate(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsRoleAssignmentEntity>> ElevateAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.BillingBenefits.BillingBenefitsSavingsPlanOrderResource> Get(string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.BillingBenefits.BillingBenefitsSavingsPlanOrderResource>> GetAsync(string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.BillingBenefits.BillingBenefitsSavingsPlanResource> GetBillingBenefitsSavingsPlan(string savingsPlanId, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.BillingBenefits.BillingBenefitsSavingsPlanResource>> GetBillingBenefitsSavingsPlanAsync(string savingsPlanId, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.BillingBenefits.BillingBenefitsSavingsPlanCollection GetBillingBenefitsSavingsPlans() { throw null; }
        Azure.ResourceManager.BillingBenefits.BillingBenefitsSavingsPlanOrderData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.BillingBenefits.BillingBenefitsSavingsPlanOrderData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.BillingBenefits.BillingBenefitsSavingsPlanOrderData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.BillingBenefits.BillingBenefitsSavingsPlanOrderData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.BillingBenefits.BillingBenefitsSavingsPlanOrderData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.BillingBenefits.BillingBenefitsSavingsPlanOrderData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.BillingBenefits.BillingBenefitsSavingsPlanOrderData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class BillingBenefitsSavingsPlanResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.BillingBenefits.BillingBenefitsSavingsPlanData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.BillingBenefits.BillingBenefitsSavingsPlanData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected BillingBenefitsSavingsPlanResource() { }
        public virtual Azure.ResourceManager.BillingBenefits.BillingBenefitsSavingsPlanData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string savingsPlanOrderId, string savingsPlanId) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.BillingBenefits.BillingBenefitsSavingsPlanResource> Get(string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.BillingBenefits.BillingBenefitsSavingsPlanResource>> GetAsync(string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.BillingBenefits.BillingBenefitsSavingsPlanData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.BillingBenefits.BillingBenefitsSavingsPlanData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.BillingBenefits.BillingBenefitsSavingsPlanData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.BillingBenefits.BillingBenefitsSavingsPlanData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.BillingBenefits.BillingBenefitsSavingsPlanData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.BillingBenefits.BillingBenefitsSavingsPlanData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.BillingBenefits.BillingBenefitsSavingsPlanData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.BillingBenefits.BillingBenefitsSavingsPlanResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsSavingsPlanPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.BillingBenefits.BillingBenefitsSavingsPlanResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsSavingsPlanPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.BillingBenefits.Models.SavingsPlanValidateResponse> ValidateUpdate(Azure.ResourceManager.BillingBenefits.Models.SavingsPlanUpdateValidateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.BillingBenefits.Models.SavingsPlanValidateResponse>> ValidateUpdateAsync(Azure.ResourceManager.BillingBenefits.Models.SavingsPlanUpdateValidateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ConditionalCreditCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.BillingBenefits.ConditionalCreditResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.BillingBenefits.ConditionalCreditResource>, System.Collections.IEnumerable
    {
        protected ConditionalCreditCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.BillingBenefits.ConditionalCreditResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string conditionalCreditName, Azure.ResourceManager.BillingBenefits.ConditionalCreditData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.BillingBenefits.ConditionalCreditResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string conditionalCreditName, Azure.ResourceManager.BillingBenefits.ConditionalCreditData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string conditionalCreditName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string conditionalCreditName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.BillingBenefits.ConditionalCreditResource> Get(string conditionalCreditName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.BillingBenefits.ConditionalCreditResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.BillingBenefits.ConditionalCreditResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.BillingBenefits.ConditionalCreditResource>> GetAsync(string conditionalCreditName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.BillingBenefits.ConditionalCreditResource> GetIfExists(string conditionalCreditName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.BillingBenefits.ConditionalCreditResource>> GetIfExistsAsync(string conditionalCreditName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.BillingBenefits.ConditionalCreditResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.BillingBenefits.ConditionalCreditResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.BillingBenefits.ConditionalCreditResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.BillingBenefits.ConditionalCreditResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ConditionalCreditContributorCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.BillingBenefits.ConditionalCreditContributorResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.BillingBenefits.ConditionalCreditContributorResource>, System.Collections.IEnumerable
    {
        protected ConditionalCreditContributorCollection() { }
        public virtual Azure.Response<bool> Exists(string contributorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string contributorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.BillingBenefits.ConditionalCreditContributorResource> Get(string contributorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.BillingBenefits.ConditionalCreditContributorResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.BillingBenefits.ConditionalCreditContributorResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.BillingBenefits.ConditionalCreditContributorResource>> GetAsync(string contributorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.BillingBenefits.ConditionalCreditContributorResource> GetIfExists(string contributorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.BillingBenefits.ConditionalCreditContributorResource>> GetIfExistsAsync(string contributorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.BillingBenefits.ConditionalCreditContributorResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.BillingBenefits.ConditionalCreditContributorResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.BillingBenefits.ConditionalCreditContributorResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.BillingBenefits.ConditionalCreditContributorResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ConditionalCreditContributorData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.BillingBenefits.ConditionalCreditContributorData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.BillingBenefits.ConditionalCreditContributorData>
    {
        internal ConditionalCreditContributorData() { }
        public Azure.Core.ResourceIdentifier BenefitResourceId { get { throw null; } }
        public Azure.Core.ResourceIdentifier BillingAccountResourceId { get { throw null; } }
        public string DisplayName { get { throw null; } }
        public System.DateTimeOffset? EndOn { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.BillingBenefits.Models.ContributorConditionalCreditMilestone> Milestones { get { throw null; } }
        public Azure.Core.ResourceIdentifier PrimaryBillingAccountResourceId { get { throw null; } }
        public Azure.Core.ResourceIdentifier PrimaryResourceId { get { throw null; } }
        public string ProductCode { get { throw null; } }
        public Azure.ResourceManager.BillingBenefits.Models.ConditionalCreditsProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.Core.ResourceIdentifier ResourceId { get { throw null; } }
        public System.DateTimeOffset? StartOn { get { throw null; } }
        public Azure.ResourceManager.BillingBenefits.Models.ConditionalCreditStatus? Status { get { throw null; } }
        public string SystemId { get { throw null; } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.BillingBenefits.ConditionalCreditContributorData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.BillingBenefits.ConditionalCreditContributorData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.BillingBenefits.ConditionalCreditContributorData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.BillingBenefits.ConditionalCreditContributorData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.BillingBenefits.ConditionalCreditContributorData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.BillingBenefits.ConditionalCreditContributorData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.BillingBenefits.ConditionalCreditContributorData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ConditionalCreditContributorResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.BillingBenefits.ConditionalCreditContributorData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.BillingBenefits.ConditionalCreditContributorData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ConditionalCreditContributorResource() { }
        public virtual Azure.ResourceManager.BillingBenefits.ConditionalCreditContributorData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string conditionalCreditName, string contributorName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.BillingBenefits.ConditionalCreditContributorResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.BillingBenefits.ConditionalCreditContributorResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.BillingBenefits.ConditionalCreditContributorData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.BillingBenefits.ConditionalCreditContributorData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.BillingBenefits.ConditionalCreditContributorData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.BillingBenefits.ConditionalCreditContributorData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.BillingBenefits.ConditionalCreditContributorData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.BillingBenefits.ConditionalCreditContributorData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.BillingBenefits.ConditionalCreditContributorData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ConditionalCreditData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.BillingBenefits.ConditionalCreditData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.BillingBenefits.ConditionalCreditData>
    {
        public ConditionalCreditData(Azure.Core.AzureLocation location) { }
        public string ETag { get { throw null; } }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public string Kind { get { throw null; } set { } }
        public string ManagedBy { get { throw null; } set { } }
        public Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsPlan Plan { get { throw null; } set { } }
        public Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsConditionalCreditProperties Properties { get { throw null; } set { } }
        public Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsSku Sku { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.BillingBenefits.ConditionalCreditData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.BillingBenefits.ConditionalCreditData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.BillingBenefits.ConditionalCreditData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.BillingBenefits.ConditionalCreditData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.BillingBenefits.ConditionalCreditData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.BillingBenefits.ConditionalCreditData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.BillingBenefits.ConditionalCreditData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ConditionalCreditResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.BillingBenefits.ConditionalCreditData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.BillingBenefits.ConditionalCreditData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ConditionalCreditResource() { }
        public virtual Azure.ResourceManager.BillingBenefits.ConditionalCreditData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.BillingBenefits.ConditionalCreditResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.BillingBenefits.ConditionalCreditResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.BillingBenefits.ConditionalCreditResource> Cancel(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.BillingBenefits.ConditionalCreditResource>> CancelAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string conditionalCreditName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.BillingBenefits.ConditionalCreditResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.BillingBenefits.ConditionalCreditResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.BillingBenefits.ConditionalCreditContributorResource> GetConditionalCreditContributor(string contributorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.BillingBenefits.ConditionalCreditContributorResource>> GetConditionalCreditContributorAsync(string contributorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.BillingBenefits.ConditionalCreditContributorCollection GetConditionalCreditContributors() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.BillingBenefits.ConditionalCreditResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.BillingBenefits.ConditionalCreditResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.BillingBenefits.ConditionalCreditResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.BillingBenefits.ConditionalCreditResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.BillingBenefits.ConditionalCreditData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.BillingBenefits.ConditionalCreditData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.BillingBenefits.ConditionalCreditData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.BillingBenefits.ConditionalCreditData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.BillingBenefits.ConditionalCreditData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.BillingBenefits.ConditionalCreditData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.BillingBenefits.ConditionalCreditData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.BillingBenefits.ConditionalCreditResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.BillingBenefits.Models.ConditionalCreditPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.BillingBenefits.ConditionalCreditResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.BillingBenefits.Models.ConditionalCreditPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ContributorCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.BillingBenefits.ContributorResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.BillingBenefits.ContributorResource>, System.Collections.IEnumerable
    {
        protected ContributorCollection() { }
        public virtual Azure.Response<bool> Exists(string contributorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string contributorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.BillingBenefits.ContributorResource> Get(string contributorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.BillingBenefits.ContributorResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.BillingBenefits.ContributorResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.BillingBenefits.ContributorResource>> GetAsync(string contributorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.BillingBenefits.ContributorResource> GetIfExists(string contributorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.BillingBenefits.ContributorResource>> GetIfExistsAsync(string contributorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.BillingBenefits.ContributorResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.BillingBenefits.ContributorResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.BillingBenefits.ContributorResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.BillingBenefits.ContributorResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ContributorData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.BillingBenefits.ContributorData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.BillingBenefits.ContributorData>
    {
        internal ContributorData() { }
        public Azure.ResourceManager.BillingBenefits.Models.EnablementMode? AutomaticShortfall { get { throw null; } }
        public Azure.ResourceManager.BillingBenefits.Models.AutomaticShortfallSuppressReason AutomaticShortfallSuppressReason { get { throw null; } }
        public Azure.Core.ResourceIdentifier BillingAccountResourceId { get { throw null; } }
        public Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsCommitment Commitment { get { throw null; } }
        public string DisplayName { get { throw null; } }
        public System.DateTimeOffset? EndOn { get { throw null; } }
        [System.ObsoleteAttribute("This property is obsolete and will be removed in a future release. Use MaccEntityType instead.")]
        public Azure.ResourceManager.BillingBenefits.Models.MaccEntityType EntityType { get { throw null; } }
        public bool? IsAllowContributors { get { throw null; } }
        public Azure.ResourceManager.BillingBenefits.Models.MaccEntityType? MaccEntityType { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.BillingBenefits.Models.MaccMilestone> Milestones { get { throw null; } }
        public Azure.Core.ResourceIdentifier PrimaryBillingAccountResourceId { get { throw null; } }
        public Azure.Core.ResourceIdentifier PrimaryResourceId { get { throw null; } }
        public string ProductCode { get { throw null; } }
        public string ProvisioningState { get { throw null; } }
        public Azure.Core.ResourceIdentifier ResourceId { get { throw null; } }
        public Azure.ResourceManager.BillingBenefits.Models.Shortfall Shortfall { get { throw null; } }
        public System.DateTimeOffset? StartOn { get { throw null; } }
        public Azure.ResourceManager.BillingBenefits.Models.MaccStatus? Status { get { throw null; } }
        public string SystemId { get { throw null; } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.BillingBenefits.ContributorData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.BillingBenefits.ContributorData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.BillingBenefits.ContributorData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.BillingBenefits.ContributorData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.BillingBenefits.ContributorData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.BillingBenefits.ContributorData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.BillingBenefits.ContributorData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ContributorResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.BillingBenefits.ContributorData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.BillingBenefits.ContributorData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ContributorResource() { }
        public virtual Azure.ResourceManager.BillingBenefits.ContributorData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string maccName, string contributorName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.BillingBenefits.ContributorResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.BillingBenefits.ContributorResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.BillingBenefits.ContributorData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.BillingBenefits.ContributorData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.BillingBenefits.ContributorData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.BillingBenefits.ContributorData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.BillingBenefits.ContributorData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.BillingBenefits.ContributorData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.BillingBenefits.ContributorData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CreditCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.BillingBenefits.CreditResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.BillingBenefits.CreditResource>, System.Collections.IEnumerable
    {
        protected CreditCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.BillingBenefits.CreditResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string creditName, Azure.ResourceManager.BillingBenefits.CreditData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.BillingBenefits.CreditResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string creditName, Azure.ResourceManager.BillingBenefits.CreditData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string creditName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string creditName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.BillingBenefits.CreditResource> Get(string creditName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.BillingBenefits.CreditResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.BillingBenefits.CreditResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.BillingBenefits.CreditResource>> GetAsync(string creditName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.BillingBenefits.CreditResource> GetIfExists(string creditName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.BillingBenefits.CreditResource>> GetIfExistsAsync(string creditName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.BillingBenefits.CreditResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.BillingBenefits.CreditResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.BillingBenefits.CreditResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.BillingBenefits.CreditResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class CreditData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.BillingBenefits.CreditData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.BillingBenefits.CreditData>
    {
        public CreditData(Azure.Core.AzureLocation location) { }
        public Azure.Core.ResourceIdentifier BillingAccountResourceId { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier BillingProfileResourceId { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.BillingBenefits.Models.CreditBreakdownItem> Breakdown { get { throw null; } }
        public Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsCommitment Credit { get { throw null; } set { } }
        public string CustomerId { get { throw null; } }
        public System.DateTimeOffset? EndOn { get { throw null; } set { } }
        public string ETag { get { throw null; } }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public string Kind { get { throw null; } set { } }
        public string ManagedBy { get { throw null; } set { } }
        public Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsPlan Plan { get { throw null; } set { } }
        public Azure.ResourceManager.BillingBenefits.Models.CreditPolicies Policies { get { throw null; } set { } }
        public string ProductCode { get { throw null; } set { } }
        public Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.BillingBenefits.Models.CreditReason Reason { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier ResourceId { get { throw null; } set { } }
        public Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsSku Sku { get { throw null; } set { } }
        public System.DateTimeOffset? StartOn { get { throw null; } set { } }
        public Azure.ResourceManager.BillingBenefits.Models.CreditStatus? Status { get { throw null; } set { } }
        public string SystemId { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.BillingBenefits.CreditData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.BillingBenefits.CreditData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.BillingBenefits.CreditData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.BillingBenefits.CreditData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.BillingBenefits.CreditData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.BillingBenefits.CreditData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.BillingBenefits.CreditData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CreditResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.BillingBenefits.CreditData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.BillingBenefits.CreditData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected CreditResource() { }
        public virtual Azure.ResourceManager.BillingBenefits.CreditData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.BillingBenefits.CreditResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.BillingBenefits.CreditResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.BillingBenefits.CreditResource> Cancel(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.BillingBenefits.CreditResource>> CancelAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string creditName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.BillingBenefits.CreditResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.BillingBenefits.CreditResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.BillingBenefits.CreditSourceResource> GetCreditSource(string sourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.BillingBenefits.CreditSourceResource>> GetCreditSourceAsync(string sourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.BillingBenefits.CreditSourceCollection GetCreditSources() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.BillingBenefits.CreditResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.BillingBenefits.CreditResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.BillingBenefits.CreditResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.BillingBenefits.CreditResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.BillingBenefits.CreditData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.BillingBenefits.CreditData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.BillingBenefits.CreditData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.BillingBenefits.CreditData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.BillingBenefits.CreditData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.BillingBenefits.CreditData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.BillingBenefits.CreditData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.BillingBenefits.CreditResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.BillingBenefits.Models.CreditPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.BillingBenefits.CreditResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.BillingBenefits.Models.CreditPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class CreditSourceCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.BillingBenefits.CreditSourceResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.BillingBenefits.CreditSourceResource>, System.Collections.IEnumerable
    {
        protected CreditSourceCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.BillingBenefits.CreditSourceResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string sourceName, Azure.ResourceManager.BillingBenefits.CreditSourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.BillingBenefits.CreditSourceResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string sourceName, Azure.ResourceManager.BillingBenefits.CreditSourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string sourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string sourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.BillingBenefits.CreditSourceResource> Get(string sourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.BillingBenefits.CreditSourceResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.BillingBenefits.CreditSourceResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.BillingBenefits.CreditSourceResource>> GetAsync(string sourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.BillingBenefits.CreditSourceResource> GetIfExists(string sourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.BillingBenefits.CreditSourceResource>> GetIfExistsAsync(string sourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.BillingBenefits.CreditSourceResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.BillingBenefits.CreditSourceResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.BillingBenefits.CreditSourceResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.BillingBenefits.CreditSourceResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class CreditSourceData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.BillingBenefits.CreditSourceData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.BillingBenefits.CreditSourceData>
    {
        public CreditSourceData(Azure.Core.AzureLocation location) { }
        public Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsCommitment Credit { get { throw null; } set { } }
        public string ETag { get { throw null; } }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public string ImpactedBillingPeriod { get { throw null; } set { } }
        public string Kind { get { throw null; } set { } }
        public string ManagedBy { get { throw null; } set { } }
        public Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsPlan Plan { get { throw null; } set { } }
        public Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsSku Sku { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier SourceResourceId { get { throw null; } set { } }
        public Azure.ResourceManager.BillingBenefits.Models.CreditStatus? Status { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.BillingBenefits.CreditSourceData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.BillingBenefits.CreditSourceData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.BillingBenefits.CreditSourceData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.BillingBenefits.CreditSourceData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.BillingBenefits.CreditSourceData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.BillingBenefits.CreditSourceData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.BillingBenefits.CreditSourceData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CreditSourceResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.BillingBenefits.CreditSourceData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.BillingBenefits.CreditSourceData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected CreditSourceResource() { }
        public virtual Azure.ResourceManager.BillingBenefits.CreditSourceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.BillingBenefits.CreditSourceResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.BillingBenefits.CreditSourceResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string creditName, string sourceName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.BillingBenefits.CreditSourceResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.BillingBenefits.CreditSourceResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.BillingBenefits.CreditSourceResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.BillingBenefits.CreditSourceResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.BillingBenefits.CreditSourceResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.BillingBenefits.CreditSourceResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.BillingBenefits.CreditSourceData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.BillingBenefits.CreditSourceData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.BillingBenefits.CreditSourceData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.BillingBenefits.CreditSourceData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.BillingBenefits.CreditSourceData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.BillingBenefits.CreditSourceData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.BillingBenefits.CreditSourceData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.BillingBenefits.CreditSourceResource> Update(Azure.ResourceManager.BillingBenefits.Models.CreditSourcePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.BillingBenefits.CreditSourceResource>> UpdateAsync(Azure.ResourceManager.BillingBenefits.Models.CreditSourcePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DiscountCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.BillingBenefits.DiscountResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.BillingBenefits.DiscountResource>, System.Collections.IEnumerable
    {
        protected DiscountCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.BillingBenefits.DiscountResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string discountName, Azure.ResourceManager.BillingBenefits.DiscountData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.BillingBenefits.DiscountResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string discountName, Azure.ResourceManager.BillingBenefits.DiscountData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string discountName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string discountName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.BillingBenefits.DiscountResource> Get(string discountName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.BillingBenefits.DiscountResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.BillingBenefits.DiscountResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.BillingBenefits.DiscountResource>> GetAsync(string discountName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.BillingBenefits.DiscountResource> GetIfExists(string discountName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.BillingBenefits.DiscountResource>> GetIfExistsAsync(string discountName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.BillingBenefits.DiscountResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.BillingBenefits.DiscountResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.BillingBenefits.DiscountResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.BillingBenefits.DiscountResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class DiscountData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.BillingBenefits.DiscountData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.BillingBenefits.DiscountData>
    {
        public DiscountData(Azure.Core.AzureLocation location) { }
        public string ETag { get { throw null; } }
        public Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsManagedServiceIdentity Identity { get { throw null; } set { } }
        public string Kind { get { throw null; } set { } }
        public string ManagedBy { get { throw null; } set { } }
        public Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsPlan Plan { get { throw null; } set { } }
        public Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsDiscountProperties Properties { get { throw null; } set { } }
        public Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsSku Sku { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.BillingBenefits.DiscountData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.BillingBenefits.DiscountData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.BillingBenefits.DiscountData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.BillingBenefits.DiscountData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.BillingBenefits.DiscountData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.BillingBenefits.DiscountData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.BillingBenefits.DiscountData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DiscountResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.BillingBenefits.DiscountData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.BillingBenefits.DiscountData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected DiscountResource() { }
        public virtual Azure.ResourceManager.BillingBenefits.DiscountData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.BillingBenefits.DiscountResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.BillingBenefits.DiscountResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.BillingBenefits.DiscountResource> Cancel(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.BillingBenefits.DiscountResource>> CancelAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string discountName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.BillingBenefits.DiscountResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.BillingBenefits.DiscountResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.BillingBenefits.DiscountResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.BillingBenefits.DiscountResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.BillingBenefits.DiscountResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.BillingBenefits.DiscountResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.BillingBenefits.DiscountData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.BillingBenefits.DiscountData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.BillingBenefits.DiscountData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.BillingBenefits.DiscountData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.BillingBenefits.DiscountData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.BillingBenefits.DiscountData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.BillingBenefits.DiscountData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.BillingBenefits.DiscountResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.BillingBenefits.Models.DiscountPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.BillingBenefits.DiscountResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.BillingBenefits.Models.DiscountPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class FreeServicesCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.BillingBenefits.FreeServicesResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.BillingBenefits.FreeServicesResource>, System.Collections.IEnumerable
    {
        protected FreeServicesCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.BillingBenefits.FreeServicesResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string freeServiceName, Azure.ResourceManager.BillingBenefits.FreeServicesData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.BillingBenefits.FreeServicesResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string freeServiceName, Azure.ResourceManager.BillingBenefits.FreeServicesData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string freeServiceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string freeServiceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.BillingBenefits.FreeServicesResource> Get(string freeServiceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.BillingBenefits.FreeServicesResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.BillingBenefits.FreeServicesResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.BillingBenefits.FreeServicesResource>> GetAsync(string freeServiceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.BillingBenefits.FreeServicesResource> GetIfExists(string freeServiceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.BillingBenefits.FreeServicesResource>> GetIfExistsAsync(string freeServiceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.BillingBenefits.FreeServicesResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.BillingBenefits.FreeServicesResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.BillingBenefits.FreeServicesResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.BillingBenefits.FreeServicesResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class FreeServicesData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.BillingBenefits.FreeServicesData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.BillingBenefits.FreeServicesData>
    {
        public FreeServicesData(Azure.Core.AzureLocation location) { }
        public Azure.Core.ResourceIdentifier BillingAccountResourceId { get { throw null; } }
        public Azure.Core.ResourceIdentifier BillingProfileResourceId { get { throw null; } }
        public Azure.Core.ResourceIdentifier CustomerResourceId { get { throw null; } }
        public System.DateTimeOffset? EndOn { get { throw null; } set { } }
        public string ETag { get { throw null; } }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public string Kind { get { throw null; } set { } }
        public string ManagedBy { get { throw null; } set { } }
        public Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsPlan Plan { get { throw null; } set { } }
        public string ProductCode { get { throw null; } set { } }
        public string ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsSku Sku { get { throw null; } set { } }
        public System.DateTimeOffset? StartOn { get { throw null; } set { } }
        public Azure.ResourceManager.BillingBenefits.Models.FreeServicesStatus? Status { get { throw null; } set { } }
        public string SystemId { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.BillingBenefits.FreeServicesData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.BillingBenefits.FreeServicesData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.BillingBenefits.FreeServicesData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.BillingBenefits.FreeServicesData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.BillingBenefits.FreeServicesData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.BillingBenefits.FreeServicesData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.BillingBenefits.FreeServicesData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class FreeServicesResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.BillingBenefits.FreeServicesData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.BillingBenefits.FreeServicesData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected FreeServicesResource() { }
        public virtual Azure.ResourceManager.BillingBenefits.FreeServicesData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.BillingBenefits.FreeServicesResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.BillingBenefits.FreeServicesResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string freeServiceName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.BillingBenefits.FreeServicesResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.BillingBenefits.FreeServicesResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.BillingBenefits.FreeServicesResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.BillingBenefits.FreeServicesResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.BillingBenefits.FreeServicesResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.BillingBenefits.FreeServicesResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.BillingBenefits.FreeServicesData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.BillingBenefits.FreeServicesData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.BillingBenefits.FreeServicesData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.BillingBenefits.FreeServicesData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.BillingBenefits.FreeServicesData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.BillingBenefits.FreeServicesData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.BillingBenefits.FreeServicesData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.BillingBenefits.FreeServicesResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.BillingBenefits.Models.FreeServicesPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.BillingBenefits.FreeServicesResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.BillingBenefits.Models.FreeServicesPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class MaccCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.BillingBenefits.MaccResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.BillingBenefits.MaccResource>, System.Collections.IEnumerable
    {
        protected MaccCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.BillingBenefits.MaccResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string maccName, Azure.ResourceManager.BillingBenefits.MaccData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.BillingBenefits.MaccResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string maccName, Azure.ResourceManager.BillingBenefits.MaccData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string maccName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string maccName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.BillingBenefits.MaccResource> Get(string maccName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.BillingBenefits.MaccResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.BillingBenefits.MaccResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.BillingBenefits.MaccResource>> GetAsync(string maccName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.BillingBenefits.MaccResource> GetIfExists(string maccName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.BillingBenefits.MaccResource>> GetIfExistsAsync(string maccName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.BillingBenefits.MaccResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.BillingBenefits.MaccResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.BillingBenefits.MaccResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.BillingBenefits.MaccResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class MaccData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.BillingBenefits.MaccData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.BillingBenefits.MaccData>
    {
        public MaccData(Azure.Core.AzureLocation location) { }
        public Azure.ResourceManager.BillingBenefits.Models.EnablementMode? AutomaticShortfall { get { throw null; } set { } }
        public Azure.ResourceManager.BillingBenefits.Models.AutomaticShortfallSuppressReason AutomaticShortfallSuppressReason { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier BillingAccountResourceId { get { throw null; } set { } }
        public Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsCommitment Commitment { get { throw null; } set { } }
        public string DisplayName { get { throw null; } set { } }
        public System.DateTimeOffset? EndOn { get { throw null; } set { } }
        [System.ObsoleteAttribute("This property is obsolete and will be removed in a future release. Use MaccEntityType instead.")]
        public Azure.ResourceManager.BillingBenefits.Models.MaccEntityType EntityType { get { throw null; } set { } }
        public string ETag { get { throw null; } }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public bool? IsAllowContributors { get { throw null; } set { } }
        public string Kind { get { throw null; } set { } }
        public Azure.ResourceManager.BillingBenefits.Models.MaccEntityType? MaccEntityType { get { throw null; } set { } }
        public string ManagedBy { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.BillingBenefits.Models.MaccMilestone> Milestones { get { throw null; } }
        public Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsPlan Plan { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier PrimaryBillingAccountResourceId { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier PrimaryResourceId { get { throw null; } set { } }
        public string ProductCode { get { throw null; } set { } }
        public string ProvisioningState { get { throw null; } }
        public Azure.Core.ResourceIdentifier ResourceId { get { throw null; } set { } }
        public Azure.ResourceManager.BillingBenefits.Models.Shortfall Shortfall { get { throw null; } set { } }
        public Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsSku Sku { get { throw null; } set { } }
        public System.DateTimeOffset? StartOn { get { throw null; } set { } }
        public Azure.ResourceManager.BillingBenefits.Models.MaccStatus? Status { get { throw null; } set { } }
        public string SystemId { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.BillingBenefits.MaccData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.BillingBenefits.MaccData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.BillingBenefits.MaccData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.BillingBenefits.MaccData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.BillingBenefits.MaccData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.BillingBenefits.MaccData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.BillingBenefits.MaccData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MaccResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.BillingBenefits.MaccData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.BillingBenefits.MaccData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected MaccResource() { }
        public virtual Azure.ResourceManager.BillingBenefits.MaccData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.BillingBenefits.MaccResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.BillingBenefits.MaccResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.BillingBenefits.MaccResource> Cancel(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.BillingBenefits.MaccResource>> CancelAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.BillingBenefits.MaccResource> ChargeShortfall(Azure.WaitUntil waitUntil, Azure.ResourceManager.BillingBenefits.Models.ChargeShortfallRequest content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.BillingBenefits.MaccResource>> ChargeShortfallAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.BillingBenefits.Models.ChargeShortfallRequest content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string maccName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.BillingBenefits.MaccResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.BillingBenefits.MaccResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.BillingBenefits.ContributorResource> GetContributor(string contributorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.BillingBenefits.ContributorResource>> GetContributorAsync(string contributorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.BillingBenefits.ContributorCollection GetContributors() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.BillingBenefits.MaccResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.BillingBenefits.MaccResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.BillingBenefits.MaccResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.BillingBenefits.MaccResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.BillingBenefits.MaccData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.BillingBenefits.MaccData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.BillingBenefits.MaccData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.BillingBenefits.MaccData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.BillingBenefits.MaccData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.BillingBenefits.MaccData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.BillingBenefits.MaccData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.BillingBenefits.MaccResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.BillingBenefits.Models.MaccPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.BillingBenefits.MaccResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.BillingBenefits.Models.MaccPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.BillingBenefits.MaccResource> WriteOff(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.BillingBenefits.MaccResource>> WriteOffAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.BillingBenefits.Mocking
{
    public partial class MockableBillingBenefitsArmClient : Azure.ResourceManager.ArmResource
    {
        protected MockableBillingBenefitsArmClient() { }
        public virtual Azure.Pageable<Azure.ResourceManager.BillingBenefits.Models.ApplicableMacc> GetAll(Azure.Core.ResourceIdentifier scope, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.BillingBenefits.Models.ApplicableMacc> GetAllAsync(Azure.Core.ResourceIdentifier scope, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.BillingBenefits.CreditResource> GetApplicable(Azure.Core.ResourceIdentifier scope, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.BillingBenefits.CreditResource> GetApplicableAsync(Azure.Core.ResourceIdentifier scope, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.BillingBenefits.BillingBenefitsReservationOrderAliasResource GetBillingBenefitsReservationOrderAliasResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.BillingBenefits.BillingBenefitsSavingsPlanOrderAliasResource GetBillingBenefitsSavingsPlanOrderAliasResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.BillingBenefits.BillingBenefitsSavingsPlanOrderResource GetBillingBenefitsSavingsPlanOrderResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.BillingBenefits.BillingBenefitsSavingsPlanResource GetBillingBenefitsSavingsPlanResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.BillingBenefits.ConditionalCreditResource> GetConditionalCreditByScope(Azure.Core.ResourceIdentifier scope, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.BillingBenefits.ConditionalCreditResource> GetConditionalCreditByScopeAsync(Azure.Core.ResourceIdentifier scope, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.BillingBenefits.ConditionalCreditContributorResource GetConditionalCreditContributorResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.BillingBenefits.ConditionalCreditResource GetConditionalCreditResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.BillingBenefits.ContributorResource GetContributorResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.BillingBenefits.CreditResource GetCreditResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.BillingBenefits.CreditSourceResource GetCreditSourceResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.BillingBenefits.DiscountResource> GetDiscountByScope(Azure.Core.ResourceIdentifier scope, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.BillingBenefits.DiscountResource> GetDiscountByScopeAsync(Azure.Core.ResourceIdentifier scope, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.BillingBenefits.DiscountResource GetDiscountResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.BillingBenefits.FreeServicesResource GetFreeServicesResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.BillingBenefits.ConditionalCreditContributorResource> GetFromApplicableConditionalCredit(Azure.Core.ResourceIdentifier scope, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.BillingBenefits.ConditionalCreditContributorResource> GetFromApplicableConditionalCreditAsync(Azure.Core.ResourceIdentifier scope, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.BillingBenefits.ContributorResource> GetFromApplicableMacc(Azure.Core.ResourceIdentifier scope, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.BillingBenefits.ContributorResource> GetFromApplicableMaccAsync(Azure.Core.ResourceIdentifier scope, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.BillingBenefits.MaccResource GetMaccResource(Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class MockableBillingBenefitsResourceGroupResource : Azure.ResourceManager.ArmResource
    {
        protected MockableBillingBenefitsResourceGroupResource() { }
        public virtual Azure.ResourceManager.BillingBenefits.FreeServicesCollection GetAllFreeServices() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.BillingBenefits.ConditionalCreditResource> GetConditionalCredit(string conditionalCreditName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.BillingBenefits.ConditionalCreditResource>> GetConditionalCreditAsync(string conditionalCreditName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.BillingBenefits.ConditionalCreditCollection GetConditionalCredits() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.BillingBenefits.CreditResource> GetCredit(string creditName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.BillingBenefits.CreditResource>> GetCreditAsync(string creditName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.BillingBenefits.CreditCollection GetCredits() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.BillingBenefits.DiscountResource> GetDiscount(string discountName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.BillingBenefits.DiscountResource>> GetDiscountAsync(string discountName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.BillingBenefits.DiscountCollection GetDiscounts() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.BillingBenefits.FreeServicesResource> GetFreeServices(string freeServiceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.BillingBenefits.FreeServicesResource>> GetFreeServicesAsync(string freeServiceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.BillingBenefits.MaccResource> GetMacc(string maccName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.BillingBenefits.MaccResource>> GetMaccAsync(string maccName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.BillingBenefits.MaccCollection GetMaccs() { throw null; }
    }
    public partial class MockableBillingBenefitsSubscriptionResource : Azure.ResourceManager.ArmResource
    {
        protected MockableBillingBenefitsSubscriptionResource() { }
        public virtual Azure.Pageable<Azure.ResourceManager.BillingBenefits.ConditionalCreditResource> GetConditionalCredits(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.BillingBenefits.ConditionalCreditResource> GetConditionalCreditsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.BillingBenefits.CreditResource> GetCredits(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.BillingBenefits.CreditResource> GetCreditsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.BillingBenefits.DiscountResource> GetDiscounts(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.BillingBenefits.DiscountResource> GetDiscountsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.BillingBenefits.FreeServicesResource> GetFreeServices(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.BillingBenefits.FreeServicesResource> GetFreeServicesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.BillingBenefits.MaccResource> GetMaccs(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.BillingBenefits.MaccResource> GetMaccsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class MockableBillingBenefitsTenantResource : Azure.ResourceManager.ArmResource
    {
        protected MockableBillingBenefitsTenantResource() { }
        public virtual Azure.Pageable<Azure.ResourceManager.BillingBenefits.MaccResource> GetAll(Azure.ResourceManager.BillingBenefits.Models.SellerResourceListRequest content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.BillingBenefits.MaccResource> GetAllAsync(Azure.ResourceManager.BillingBenefits.Models.SellerResourceListRequest content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.BillingBenefits.BillingBenefitsReservationOrderAliasResource> GetBillingBenefitsReservationOrderAlias(string reservationOrderAliasName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.BillingBenefits.BillingBenefitsReservationOrderAliasResource>> GetBillingBenefitsReservationOrderAliasAsync(string reservationOrderAliasName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.BillingBenefits.BillingBenefitsReservationOrderAliasCollection GetBillingBenefitsReservationOrderAliases() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.BillingBenefits.BillingBenefitsSavingsPlanOrderResource> GetBillingBenefitsSavingsPlanOrder(string savingsPlanOrderId, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.BillingBenefits.BillingBenefitsSavingsPlanOrderAliasResource> GetBillingBenefitsSavingsPlanOrderAlias(string savingsPlanOrderAliasName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.BillingBenefits.BillingBenefitsSavingsPlanOrderAliasResource>> GetBillingBenefitsSavingsPlanOrderAliasAsync(string savingsPlanOrderAliasName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.BillingBenefits.BillingBenefitsSavingsPlanOrderAliasCollection GetBillingBenefitsSavingsPlanOrderAliases() { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.BillingBenefits.BillingBenefitsSavingsPlanOrderResource>> GetBillingBenefitsSavingsPlanOrderAsync(string savingsPlanOrderId, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.BillingBenefits.BillingBenefitsSavingsPlanOrderCollection GetBillingBenefitsSavingsPlanOrders() { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.BillingBenefits.BillingBenefitsSavingsPlanResource> GetBillingBenefitsSavingsPlans(string filter = null, string orderby = null, string refreshSummary = null, float? skiptoken = default(float?), string selectedState = null, float? take = default(float?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.BillingBenefits.BillingBenefitsSavingsPlanResource> GetBillingBenefitsSavingsPlansAsync(string filter = null, string orderby = null, string refreshSummary = null, float? skiptoken = default(float?), string selectedState = null, float? take = default(float?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.BillingBenefits.Models.BenefitValidateResponse> Validate(Azure.ResourceManager.BillingBenefits.Models.BenefitValidateRequest content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.BillingBenefits.Models.BenefitValidateResponse>> ValidateAsync(Azure.ResourceManager.BillingBenefits.Models.BenefitValidateRequest content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.BillingBenefits.Models
{
    public partial class ApplicableMacc : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.BillingBenefits.Models.ApplicableMacc>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.BillingBenefits.Models.ApplicableMacc>
    {
        internal ApplicableMacc() { }
        public Azure.ResourceManager.BillingBenefits.Models.EnablementMode? AutomaticShortfall { get { throw null; } }
        public Azure.ResourceManager.BillingBenefits.Models.AutomaticShortfallSuppressReason AutomaticShortfallSuppressReason { get { throw null; } }
        public Azure.Core.ResourceIdentifier BillingAccountResourceId { get { throw null; } }
        public Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsCommitment Commitment { get { throw null; } }
        public string DisplayName { get { throw null; } }
        public System.DateTimeOffset? EndOn { get { throw null; } }
        [System.ObsoleteAttribute("This property is obsolete and will be removed in a future release. Use MaccEntityType instead.")]
        public Azure.ResourceManager.BillingBenefits.Models.MaccEntityType EntityType { get { throw null; } }
        public bool? IsAllowContributors { get { throw null; } }
        public Azure.ResourceManager.BillingBenefits.Models.MaccEntityType? MaccEntityType { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.BillingBenefits.Models.MaccMilestone> Milestones { get { throw null; } }
        public Azure.Core.ResourceIdentifier PrimaryBillingAccountResourceId { get { throw null; } }
        public Azure.Core.ResourceIdentifier PrimaryResourceId { get { throw null; } }
        public string ProductCode { get { throw null; } }
        public string ProvisioningState { get { throw null; } }
        public Azure.Core.ResourceIdentifier ResourceId { get { throw null; } }
        public Azure.ResourceManager.BillingBenefits.Models.Shortfall Shortfall { get { throw null; } }
        public System.DateTimeOffset? StartOn { get { throw null; } }
        public Azure.ResourceManager.BillingBenefits.Models.MaccStatus? Status { get { throw null; } }
        public string SystemId { get { throw null; } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.BillingBenefits.Models.ApplicableMacc System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.BillingBenefits.Models.ApplicableMacc>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.BillingBenefits.Models.ApplicableMacc>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.BillingBenefits.Models.ApplicableMacc System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.BillingBenefits.Models.ApplicableMacc>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.BillingBenefits.Models.ApplicableMacc>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.BillingBenefits.Models.ApplicableMacc>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ApplyDiscountOn : System.IEquatable<Azure.ResourceManager.BillingBenefits.Models.ApplyDiscountOn>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ApplyDiscountOn(string value) { throw null; }
        public static Azure.ResourceManager.BillingBenefits.Models.ApplyDiscountOn Consume { get { throw null; } }
        public static Azure.ResourceManager.BillingBenefits.Models.ApplyDiscountOn Purchase { get { throw null; } }
        public static Azure.ResourceManager.BillingBenefits.Models.ApplyDiscountOn Renew { get { throw null; } }
        public bool Equals(Azure.ResourceManager.BillingBenefits.Models.ApplyDiscountOn other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.BillingBenefits.Models.ApplyDiscountOn left, Azure.ResourceManager.BillingBenefits.Models.ApplyDiscountOn right) { throw null; }
        public static implicit operator Azure.ResourceManager.BillingBenefits.Models.ApplyDiscountOn (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.BillingBenefits.Models.ApplyDiscountOn? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.BillingBenefits.Models.ApplyDiscountOn left, Azure.ResourceManager.BillingBenefits.Models.ApplyDiscountOn right) { throw null; }
        public override string ToString() { throw null; }
    }
    public static partial class ArmBillingBenefitsModelFactory
    {
        public static Azure.ResourceManager.BillingBenefits.Models.ApplicableMacc ApplicableMacc(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string provisioningState = null, Azure.ResourceManager.BillingBenefits.Models.MaccStatus? status = default(Azure.ResourceManager.BillingBenefits.Models.MaccStatus?), Azure.ResourceManager.BillingBenefits.Models.MaccEntityType? entityType = default(Azure.ResourceManager.BillingBenefits.Models.MaccEntityType?), string displayName = null, string productCode = null, Azure.Core.ResourceIdentifier billingAccountResourceId = null, Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsCommitment commitment = null, System.DateTimeOffset? startOn = default(System.DateTimeOffset?), System.DateTimeOffset? endOn = default(System.DateTimeOffset?), string systemId = null, Azure.ResourceManager.BillingBenefits.Models.EnablementMode? automaticShortfall = default(Azure.ResourceManager.BillingBenefits.Models.EnablementMode?), Azure.ResourceManager.BillingBenefits.Models.AutomaticShortfallSuppressReason automaticShortfallSuppressReason = null, Azure.ResourceManager.BillingBenefits.Models.Shortfall shortfall = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.BillingBenefits.Models.MaccMilestone> milestones = null, Azure.Core.ResourceIdentifier resourceId = null, bool? isAllowContributors = default(bool?), Azure.Core.ResourceIdentifier primaryResourceId = null, Azure.Core.ResourceIdentifier primaryBillingAccountResourceId = null) { throw null; }
        public static Azure.ResourceManager.BillingBenefits.Models.Award Award(Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsCommitment credit = null, System.DateTimeOffset? startOn = default(System.DateTimeOffset?), System.DateTimeOffset? endOn = default(System.DateTimeOffset?), Azure.Core.ResourceIdentifier resourceId = null, string systemId = null, float? balanceVersion = default(float?), Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsTerm? duration = default(Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsTerm?)) { throw null; }
        public static Azure.ResourceManager.BillingBenefits.Models.BenefitValidateRequest BenefitValidateRequest(System.Collections.Generic.IEnumerable<Azure.ResourceManager.BillingBenefits.Models.BenefitValidateModel> benefits = null) { throw null; }
        public static Azure.ResourceManager.BillingBenefits.Models.BenefitValidateResponse BenefitValidateResponse(System.Collections.Generic.IEnumerable<Azure.ResourceManager.BillingBenefits.Models.BenefitValidateResponseProperty> benefits = null, string nextLink = null) { throw null; }
        public static Azure.ResourceManager.BillingBenefits.Models.BenefitValidateResponseProperty BenefitValidateResponseProperty(bool? isValid = default(bool?), string reasonCode = null, string reason = null, Azure.Core.ResourceIdentifier resourceId = null) { throw null; }
        public static Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsConditionalCreditProperties BillingBenefitsConditionalCreditProperties(string entityType = null, string displayName = null, Azure.Core.ResourceIdentifier billingAccountResourceId = null, Azure.ResourceManager.BillingBenefits.Models.ConditionalCreditsProvisioningState? provisioningState = default(Azure.ResourceManager.BillingBenefits.Models.ConditionalCreditsProvisioningState?), Azure.ResourceManager.BillingBenefits.Models.ConditionalCreditStatus? status = default(Azure.ResourceManager.BillingBenefits.Models.ConditionalCreditStatus?), System.DateTimeOffset? startOn = default(System.DateTimeOffset?), System.DateTimeOffset? endOn = default(System.DateTimeOffset?), string productCode = null, Azure.Core.ResourceIdentifier benefitResourceId = null, Azure.Core.ResourceIdentifier resourceId = null) { throw null; }
        public static Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsDiscountProperties BillingBenefitsDiscountProperties(string entityType = null, string productCode = null, System.DateTimeOffset startOn = default(System.DateTimeOffset), string systemId = null, Azure.ResourceManager.BillingBenefits.Models.DiscountProvisioningState? provisioningState = default(Azure.ResourceManager.BillingBenefits.Models.DiscountProvisioningState?), Azure.Core.ResourceIdentifier billingAccountResourceId = null, Azure.Core.ResourceIdentifier billingProfileResourceId = null, Azure.Core.ResourceIdentifier customerResourceId = null, string displayName = null, Azure.ResourceManager.BillingBenefits.Models.DiscountStatus? status = default(Azure.ResourceManager.BillingBenefits.Models.DiscountStatus?), Azure.Core.ResourceIdentifier benefitResourceId = null, Azure.ResourceManager.BillingBenefits.Models.DiscountAppliedScopeType? appliedScopeType = default(Azure.ResourceManager.BillingBenefits.Models.DiscountAppliedScopeType?)) { throw null; }
        public static Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsExtendedStatusInfo BillingBenefitsExtendedStatusInfo(string statusCode = null, string message = null) { throw null; }
        public static Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsManagedServiceIdentity BillingBenefitsManagedServiceIdentity(string principalId = null, string tenantId = null, Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsManagedServiceIdentityType type = default(Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsManagedServiceIdentityType), System.Collections.Generic.IDictionary<string, Azure.ResourceManager.Models.UserAssignedIdentity> userAssignedIdentities = null) { throw null; }
        public static Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsReservationOrderAliasCreateOrUpdateContent BillingBenefitsReservationOrderAliasCreateOrUpdateContent(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string skuName = null, Azure.Core.AzureLocation? location = default(Azure.Core.AzureLocation?), string displayName = null, Azure.Core.ResourceIdentifier billingScopeId = null, Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsTerm? term = default(Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsTerm?), Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsBillingPlan? billingPlan = default(Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsBillingPlan?), Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsAppliedScopeType? appliedScopeType = default(Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsAppliedScopeType?), Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsAppliedScopeProperties appliedScopeProperties = null, int? quantity = default(int?), bool? isRenewed = default(bool?), Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsReservedResourceType? reservedResourceType = default(Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsReservedResourceType?), System.DateTimeOffset? reviewOn = default(System.DateTimeOffset?), Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsInstanceFlexibility? reservedResourceInstanceFlexibility = default(Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsInstanceFlexibility?)) { throw null; }
        public static Azure.ResourceManager.BillingBenefits.BillingBenefitsReservationOrderAliasData BillingBenefitsReservationOrderAliasData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string displayName = null, Azure.Core.ResourceIdentifier reservationOrderId = null, Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsProvisioningState? provisioningState = default(Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsProvisioningState?), Azure.Core.ResourceIdentifier billingScopeId = null, Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsTerm? term = default(Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsTerm?), Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsBillingPlan? billingPlan = default(Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsBillingPlan?), Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsAppliedScopeType? appliedScopeType = default(Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsAppliedScopeType?), Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsAppliedScopeProperties appliedScopeProperties = null, int? quantity = default(int?), bool? isRenewed = default(bool?), Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsReservedResourceType? reservedResourceType = default(Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsReservedResourceType?), System.DateTimeOffset? reviewOn = default(System.DateTimeOffset?), Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsInstanceFlexibility? reservedResourceInstanceFlexibility = default(Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsInstanceFlexibility?), string skuName = null, Azure.Core.AzureLocation? location = default(Azure.Core.AzureLocation?)) { throw null; }
        public static Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsRoleAssignmentEntity BillingBenefitsRoleAssignmentEntity(Azure.Core.ResourceIdentifier id = null, string name = null, string principalId = null, Azure.Core.ResourceIdentifier roleDefinitionId = null, Azure.Core.ResourceIdentifier scope = null) { throw null; }
        public static Azure.ResourceManager.BillingBenefits.BillingBenefitsSavingsPlanData BillingBenefitsSavingsPlanData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string displayName = null, Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsProvisioningState? provisioningState = default(Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsProvisioningState?), string displayProvisioningState = null, Azure.Core.ResourceIdentifier billingScopeId = null, Azure.Core.ResourceIdentifier billingProfileId = null, Azure.Core.ResourceIdentifier customerId = null, Azure.Core.ResourceIdentifier billingAccountId = null, Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsTerm? term = default(Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsTerm?), Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsBillingPlan? billingPlan = default(Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsBillingPlan?), Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsAppliedScopeType? appliedScopeType = default(Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsAppliedScopeType?), string userFriendlyAppliedScopeType = null, Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsAppliedScopeProperties appliedScopeProperties = null, Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsCommitment commitment = null, System.DateTimeOffset? effectOn = default(System.DateTimeOffset?), System.DateTimeOffset? expireOn = default(System.DateTimeOffset?), System.DateTimeOffset? purchaseOn = default(System.DateTimeOffset?), System.DateTimeOffset? benefitStartOn = default(System.DateTimeOffset?), Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsExtendedStatusInfo extendedStatusInfo = null, bool? isRenewed = default(bool?), Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsSavingsPlanUtilization utilization = null, string renewSource = null, string renewDestination = null, Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsPurchaseContent renewPurchaseProperties = null, string skuName = null) { throw null; }
        public static Azure.ResourceManager.BillingBenefits.BillingBenefitsSavingsPlanOrderAliasData BillingBenefitsSavingsPlanOrderAliasData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string displayName = null, Azure.Core.ResourceIdentifier savingsPlanOrderId = null, Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsProvisioningState? provisioningState = default(Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsProvisioningState?), Azure.Core.ResourceIdentifier billingScopeId = null, Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsTerm? term = default(Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsTerm?), Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsBillingPlan? billingPlan = default(Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsBillingPlan?), Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsAppliedScopeType? appliedScopeType = default(Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsAppliedScopeType?), Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsAppliedScopeProperties appliedScopeProperties = null, Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsCommitment commitment = null, bool? isRenewed = default(bool?), string skuName = null, string kind = null) { throw null; }
        public static Azure.ResourceManager.BillingBenefits.BillingBenefitsSavingsPlanOrderData BillingBenefitsSavingsPlanOrderData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string displayName = null, Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsProvisioningState? provisioningState = default(Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsProvisioningState?), Azure.Core.ResourceIdentifier billingScopeId = null, Azure.Core.ResourceIdentifier billingProfileId = null, Azure.Core.ResourceIdentifier customerId = null, Azure.Core.ResourceIdentifier billingAccountId = null, Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsTerm? term = default(Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsTerm?), Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsBillingPlan? billingPlan = default(Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsBillingPlan?), System.DateTimeOffset? expireOn = default(System.DateTimeOffset?), System.DateTimeOffset? benefitStartOn = default(System.DateTimeOffset?), Azure.ResourceManager.BillingBenefits.Models.BillingPlanInformation planInformation = null, System.Collections.Generic.IEnumerable<string> savingsPlans = null, Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsExtendedStatusInfo extendedStatusInfo = null, string skuName = null) { throw null; }
        public static Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsSavingsPlanUtilization BillingBenefitsSavingsPlanUtilization(string trend = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsSavingsPlanUtilizationAggregate> aggregates = null) { throw null; }
        public static Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsSavingsPlanUtilizationAggregate BillingBenefitsSavingsPlanUtilizationAggregate(float? grain = default(float?), string grainUnit = null, float? value = default(float?), string valueUnit = null) { throw null; }
        public static Azure.ResourceManager.BillingBenefits.Models.BillingPlanInformation BillingPlanInformation(Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsPrice pricingCurrencyTotal = null, System.DateTimeOffset? startOn = default(System.DateTimeOffset?), System.DateTimeOffset? nextPaymentDueOn = default(System.DateTimeOffset?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.BillingBenefits.Models.SavingsPlanOrderPaymentDetail> transactions = null) { throw null; }
        public static Azure.ResourceManager.BillingBenefits.ConditionalCreditContributorData ConditionalCreditContributorData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string displayName = null, Azure.Core.ResourceIdentifier billingAccountResourceId = null, Azure.ResourceManager.BillingBenefits.Models.ConditionalCreditsProvisioningState? provisioningState = default(Azure.ResourceManager.BillingBenefits.Models.ConditionalCreditsProvisioningState?), Azure.ResourceManager.BillingBenefits.Models.ConditionalCreditStatus? status = default(Azure.ResourceManager.BillingBenefits.Models.ConditionalCreditStatus?), System.DateTimeOffset? startOn = default(System.DateTimeOffset?), System.DateTimeOffset? endOn = default(System.DateTimeOffset?), string productCode = null, Azure.Core.ResourceIdentifier benefitResourceId = null, Azure.Core.ResourceIdentifier resourceId = null, Azure.Core.ResourceIdentifier primaryResourceId = null, string systemId = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.BillingBenefits.Models.ContributorConditionalCreditMilestone> milestones = null, Azure.Core.ResourceIdentifier primaryBillingAccountResourceId = null) { throw null; }
        public static Azure.ResourceManager.BillingBenefits.ConditionalCreditData ConditionalCreditData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsConditionalCreditProperties properties = null, string managedBy = null, string kind = null, string etag = null, Azure.ResourceManager.Models.ManagedServiceIdentity identity = null, Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsSku sku = null, Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsPlan plan = null) { throw null; }
        public static Azure.ResourceManager.BillingBenefits.Models.ConditionalCreditPatch ConditionalCreditPatch(string displayName = null, System.DateTimeOffset? endOn = default(System.DateTimeOffset?), Azure.ResourceManager.BillingBenefits.Models.EnablementMode? allowContributors = default(Azure.ResourceManager.BillingBenefits.Models.EnablementMode?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.BillingBenefits.Models.ConditionalCreditMilestone> milestones = null, System.Collections.Generic.IDictionary<string, string> tags = null) { throw null; }
        public static Azure.ResourceManager.BillingBenefits.Models.ConditionsItem ConditionsItem(string conditionName = null, System.Collections.Generic.IEnumerable<string> value = null, string type = null) { throw null; }
        public static Azure.ResourceManager.BillingBenefits.Models.ContributorConditionalCreditProperties ContributorConditionalCreditProperties(string displayName = null, Azure.Core.ResourceIdentifier billingAccountResourceId = null, Azure.ResourceManager.BillingBenefits.Models.ConditionalCreditsProvisioningState? provisioningState = default(Azure.ResourceManager.BillingBenefits.Models.ConditionalCreditsProvisioningState?), Azure.ResourceManager.BillingBenefits.Models.ConditionalCreditStatus? status = default(Azure.ResourceManager.BillingBenefits.Models.ConditionalCreditStatus?), System.DateTimeOffset? startOn = default(System.DateTimeOffset?), System.DateTimeOffset? endOn = default(System.DateTimeOffset?), string productCode = null, Azure.Core.ResourceIdentifier benefitResourceId = null, Azure.Core.ResourceIdentifier resourceId = null, Azure.Core.ResourceIdentifier primaryResourceId = null, string systemId = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.BillingBenefits.Models.ContributorConditionalCreditMilestone> milestones = null, Azure.Core.ResourceIdentifier primaryBillingAccountResourceId = null) { throw null; }
        public static Azure.ResourceManager.BillingBenefits.ContributorData ContributorData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string provisioningState = null, Azure.ResourceManager.BillingBenefits.Models.MaccStatus? status = default(Azure.ResourceManager.BillingBenefits.Models.MaccStatus?), Azure.ResourceManager.BillingBenefits.Models.MaccEntityType? entityType = default(Azure.ResourceManager.BillingBenefits.Models.MaccEntityType?), string displayName = null, string productCode = null, Azure.Core.ResourceIdentifier billingAccountResourceId = null, Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsCommitment commitment = null, System.DateTimeOffset? startOn = default(System.DateTimeOffset?), System.DateTimeOffset? endOn = default(System.DateTimeOffset?), string systemId = null, Azure.ResourceManager.BillingBenefits.Models.EnablementMode? automaticShortfall = default(Azure.ResourceManager.BillingBenefits.Models.EnablementMode?), Azure.ResourceManager.BillingBenefits.Models.AutomaticShortfallSuppressReason automaticShortfallSuppressReason = null, Azure.ResourceManager.BillingBenefits.Models.Shortfall shortfall = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.BillingBenefits.Models.MaccMilestone> milestones = null, Azure.Core.ResourceIdentifier resourceId = null, bool? isAllowContributors = default(bool?), Azure.Core.ResourceIdentifier primaryResourceId = null, Azure.Core.ResourceIdentifier primaryBillingAccountResourceId = null) { throw null; }
        public static Azure.ResourceManager.BillingBenefits.Models.CreditBreakdownItem CreditBreakdownItem(Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsCommitment allocation = null, System.DateTimeOffset? startOn = default(System.DateTimeOffset?), System.DateTimeOffset? endOn = default(System.DateTimeOffset?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.BillingBenefits.Models.CreditDimension> dimensions = null) { throw null; }
        public static Azure.ResourceManager.BillingBenefits.CreditData CreditData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.BillingBenefits.Models.CreditStatus? status = default(Azure.ResourceManager.BillingBenefits.Models.CreditStatus?), string productCode = null, Azure.ResourceManager.BillingBenefits.Models.CreditReason reason = null, Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsCommitment credit = null, System.DateTimeOffset? startOn = default(System.DateTimeOffset?), System.DateTimeOffset? endOn = default(System.DateTimeOffset?), Azure.ResourceManager.BillingBenefits.Models.CreditPolicies policies = null, Azure.Core.ResourceIdentifier billingAccountResourceId = null, Azure.Core.ResourceIdentifier billingProfileResourceId = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.BillingBenefits.Models.CreditBreakdownItem> breakdown = null, Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsProvisioningState? provisioningState = default(Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsProvisioningState?), string systemId = null, string customerId = null, Azure.Core.ResourceIdentifier resourceId = null, string managedBy = null, string kind = null, string etag = null, Azure.ResourceManager.Models.ManagedServiceIdentity identity = null, Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsSku sku = null, Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsPlan plan = null) { throw null; }
        public static Azure.ResourceManager.BillingBenefits.Models.CreditPatch CreditPatch(System.Collections.Generic.IDictionary<string, string> tags = null, Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsCommitment credit = null, System.DateTimeOffset? endOn = default(System.DateTimeOffset?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.BillingBenefits.Models.CreditBreakdownItem> breakdown = null) { throw null; }
        public static Azure.ResourceManager.BillingBenefits.CreditSourceData CreditSourceData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.BillingBenefits.Models.CreditStatus? status = default(Azure.ResourceManager.BillingBenefits.Models.CreditStatus?), Azure.Core.ResourceIdentifier sourceResourceId = null, string impactedBillingPeriod = null, Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsCommitment credit = null, string managedBy = null, string kind = null, string etag = null, Azure.ResourceManager.Models.ManagedServiceIdentity identity = null, Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsSku sku = null, Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsPlan plan = null) { throw null; }
        public static Azure.ResourceManager.BillingBenefits.Models.CreditSourcePatch CreditSourcePatch(System.Collections.Generic.IDictionary<string, string> tags = null) { throw null; }
        public static Azure.ResourceManager.BillingBenefits.Models.CustomPriceProperties CustomPriceProperties(Azure.ResourceManager.BillingBenefits.Models.DiscountRuleType ruleType = default(Azure.ResourceManager.BillingBenefits.Models.DiscountRuleType), string catalogId = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.BillingBenefits.Models.CatalogClaimsItem> catalogClaims = null, string termUnits = null, string billingPeriod = null, string meterType = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.BillingBenefits.Models.MarketSetPricesItems> marketSetPrices = null) { throw null; }
        public static Azure.ResourceManager.BillingBenefits.DiscountData DiscountData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsDiscountProperties properties = null, string managedBy = null, string kind = null, string etag = null, Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsManagedServiceIdentity identity = null, Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsSku sku = null, Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsPlan plan = null) { throw null; }
        public static Azure.ResourceManager.BillingBenefits.Models.DiscountPatch DiscountPatch(string displayName = null, System.Collections.Generic.IDictionary<string, string> tags = null) { throw null; }
        public static Azure.ResourceManager.BillingBenefits.Models.DiscountTypeCustomPrice DiscountTypeCustomPrice(Azure.ResourceManager.BillingBenefits.Models.ApplyDiscountOn applyDiscountOn = default(Azure.ResourceManager.BillingBenefits.Models.ApplyDiscountOn), double? discountPercentage = default(double?), Azure.ResourceManager.BillingBenefits.Models.DiscountCombinationRule? discountCombinationRule = default(Azure.ResourceManager.BillingBenefits.Models.DiscountCombinationRule?), Azure.ResourceManager.BillingBenefits.Models.PriceGuaranteeProperties priceGuaranteeProperties = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.BillingBenefits.Models.ConditionsItem> conditions = null, string productFamilyName = null, string productId = null, string skuId = null, Azure.ResourceManager.BillingBenefits.Models.CustomPriceProperties customPriceProperties = null) { throw null; }
        public static Azure.ResourceManager.BillingBenefits.Models.DiscountTypeCustomPriceMultiCurrency DiscountTypeCustomPriceMultiCurrency(Azure.ResourceManager.BillingBenefits.Models.ApplyDiscountOn applyDiscountOn = default(Azure.ResourceManager.BillingBenefits.Models.ApplyDiscountOn), double? discountPercentage = default(double?), Azure.ResourceManager.BillingBenefits.Models.DiscountCombinationRule? discountCombinationRule = default(Azure.ResourceManager.BillingBenefits.Models.DiscountCombinationRule?), Azure.ResourceManager.BillingBenefits.Models.PriceGuaranteeProperties priceGuaranteeProperties = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.BillingBenefits.Models.ConditionsItem> conditions = null, string productFamilyName = null, string productId = null, string skuId = null, Azure.ResourceManager.BillingBenefits.Models.CustomPriceProperties customPriceProperties = null) { throw null; }
        public static Azure.ResourceManager.BillingBenefits.Models.DiscountTypeProduct DiscountTypeProduct(Azure.ResourceManager.BillingBenefits.Models.ApplyDiscountOn applyDiscountOn = default(Azure.ResourceManager.BillingBenefits.Models.ApplyDiscountOn), double? discountPercentage = default(double?), Azure.ResourceManager.BillingBenefits.Models.DiscountCombinationRule? discountCombinationRule = default(Azure.ResourceManager.BillingBenefits.Models.DiscountCombinationRule?), Azure.ResourceManager.BillingBenefits.Models.PriceGuaranteeProperties priceGuaranteeProperties = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.BillingBenefits.Models.ConditionsItem> conditions = null, string productFamilyName = null, string productId = null) { throw null; }
        public static Azure.ResourceManager.BillingBenefits.Models.DiscountTypeProductFamily DiscountTypeProductFamily(Azure.ResourceManager.BillingBenefits.Models.ApplyDiscountOn applyDiscountOn = default(Azure.ResourceManager.BillingBenefits.Models.ApplyDiscountOn), double? discountPercentage = default(double?), Azure.ResourceManager.BillingBenefits.Models.DiscountCombinationRule? discountCombinationRule = default(Azure.ResourceManager.BillingBenefits.Models.DiscountCombinationRule?), Azure.ResourceManager.BillingBenefits.Models.PriceGuaranteeProperties priceGuaranteeProperties = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.BillingBenefits.Models.ConditionsItem> conditions = null, string productFamilyName = null) { throw null; }
        public static Azure.ResourceManager.BillingBenefits.Models.DiscountTypeProductSku DiscountTypeProductSku(Azure.ResourceManager.BillingBenefits.Models.ApplyDiscountOn applyDiscountOn = default(Azure.ResourceManager.BillingBenefits.Models.ApplyDiscountOn), double? discountPercentage = default(double?), Azure.ResourceManager.BillingBenefits.Models.DiscountCombinationRule? discountCombinationRule = default(Azure.ResourceManager.BillingBenefits.Models.DiscountCombinationRule?), Azure.ResourceManager.BillingBenefits.Models.PriceGuaranteeProperties priceGuaranteeProperties = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.BillingBenefits.Models.ConditionsItem> conditions = null, string productFamilyName = null, string productId = null, string skuId = null) { throw null; }
        public static Azure.ResourceManager.BillingBenefits.Models.DiscountTypeProperties DiscountTypeProperties(string discountType = null, Azure.ResourceManager.BillingBenefits.Models.ApplyDiscountOn applyDiscountOn = default(Azure.ResourceManager.BillingBenefits.Models.ApplyDiscountOn), double? discountPercentage = default(double?), Azure.ResourceManager.BillingBenefits.Models.DiscountCombinationRule? discountCombinationRule = default(Azure.ResourceManager.BillingBenefits.Models.DiscountCombinationRule?), Azure.ResourceManager.BillingBenefits.Models.PriceGuaranteeProperties priceGuaranteeProperties = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.BillingBenefits.Models.ConditionsItem> conditions = null) { throw null; }
        public static Azure.ResourceManager.BillingBenefits.Models.EntityTypeAffiliateDiscount EntityTypeAffiliateDiscount(string productCode = null, System.DateTimeOffset startOn = default(System.DateTimeOffset), string systemId = null, Azure.ResourceManager.BillingBenefits.Models.DiscountProvisioningState? provisioningState = default(Azure.ResourceManager.BillingBenefits.Models.DiscountProvisioningState?), Azure.Core.ResourceIdentifier billingAccountResourceId = null, Azure.Core.ResourceIdentifier billingProfileResourceId = null, Azure.Core.ResourceIdentifier customerResourceId = null, string displayName = null, Azure.ResourceManager.BillingBenefits.Models.DiscountStatus? status = default(Azure.ResourceManager.BillingBenefits.Models.DiscountStatus?), Azure.Core.ResourceIdentifier benefitResourceId = null, Azure.ResourceManager.BillingBenefits.Models.DiscountAppliedScopeType? appliedScopeType = default(Azure.ResourceManager.BillingBenefits.Models.DiscountAppliedScopeType?), Azure.Core.ResourceIdentifier primaryResourceId = null, System.DateTimeOffset? endOn = default(System.DateTimeOffset?)) { throw null; }
        public static Azure.ResourceManager.BillingBenefits.Models.EntityTypePrimaryDiscount EntityTypePrimaryDiscount(string productCode = null, System.DateTimeOffset startOn = default(System.DateTimeOffset), string systemId = null, Azure.ResourceManager.BillingBenefits.Models.DiscountProvisioningState? provisioningState = default(Azure.ResourceManager.BillingBenefits.Models.DiscountProvisioningState?), Azure.Core.ResourceIdentifier billingAccountResourceId = null, Azure.Core.ResourceIdentifier billingProfileResourceId = null, Azure.Core.ResourceIdentifier customerResourceId = null, string displayName = null, Azure.ResourceManager.BillingBenefits.Models.DiscountStatus? status = default(Azure.ResourceManager.BillingBenefits.Models.DiscountStatus?), Azure.Core.ResourceIdentifier benefitResourceId = null, Azure.ResourceManager.BillingBenefits.Models.DiscountAppliedScopeType? appliedScopeType = default(Azure.ResourceManager.BillingBenefits.Models.DiscountAppliedScopeType?), Azure.ResourceManager.BillingBenefits.Models.DiscountTypeProperties discountTypeProperties = null, System.DateTimeOffset endOn = default(System.DateTimeOffset)) { throw null; }
        public static Azure.ResourceManager.BillingBenefits.FreeServicesData FreeServicesData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), string productCode = null, Azure.ResourceManager.BillingBenefits.Models.FreeServicesStatus? status = default(Azure.ResourceManager.BillingBenefits.Models.FreeServicesStatus?), System.DateTimeOffset? startOn = default(System.DateTimeOffset?), System.DateTimeOffset? endOn = default(System.DateTimeOffset?), string provisioningState = null, Azure.Core.ResourceIdentifier billingAccountResourceId = null, Azure.Core.ResourceIdentifier billingProfileResourceId = null, Azure.Core.ResourceIdentifier customerResourceId = null, string systemId = null, string managedBy = null, string kind = null, string etag = null, Azure.ResourceManager.Models.ManagedServiceIdentity identity = null, Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsSku sku = null, Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsPlan plan = null) { throw null; }
        public static Azure.ResourceManager.BillingBenefits.Models.FreeServicesPatch FreeServicesPatch(System.DateTimeOffset? endOn = default(System.DateTimeOffset?), System.Collections.Generic.IDictionary<string, string> tags = null) { throw null; }
        public static Azure.ResourceManager.BillingBenefits.MaccData MaccData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), string provisioningState = null, Azure.ResourceManager.BillingBenefits.Models.MaccStatus? status = default(Azure.ResourceManager.BillingBenefits.Models.MaccStatus?), Azure.ResourceManager.BillingBenefits.Models.MaccEntityType? entityType = default(Azure.ResourceManager.BillingBenefits.Models.MaccEntityType?), string displayName = null, string productCode = null, Azure.Core.ResourceIdentifier billingAccountResourceId = null, Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsCommitment commitment = null, System.DateTimeOffset? startOn = default(System.DateTimeOffset?), System.DateTimeOffset? endOn = default(System.DateTimeOffset?), string systemId = null, Azure.ResourceManager.BillingBenefits.Models.EnablementMode? automaticShortfall = default(Azure.ResourceManager.BillingBenefits.Models.EnablementMode?), Azure.ResourceManager.BillingBenefits.Models.AutomaticShortfallSuppressReason automaticShortfallSuppressReason = null, Azure.ResourceManager.BillingBenefits.Models.Shortfall shortfall = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.BillingBenefits.Models.MaccMilestone> milestones = null, Azure.Core.ResourceIdentifier resourceId = null, bool? isAllowContributors = default(bool?), Azure.Core.ResourceIdentifier primaryResourceId = null, Azure.Core.ResourceIdentifier primaryBillingAccountResourceId = null, string managedBy = null, string kind = null, string etag = null, Azure.ResourceManager.Models.ManagedServiceIdentity identity = null, Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsSku sku = null, Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsPlan plan = null) { throw null; }
        public static Azure.ResourceManager.BillingBenefits.Models.MaccPatch MaccPatch(Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsCommitment commitment = null, System.DateTimeOffset? endOn = default(System.DateTimeOffset?), bool? isAllowContributors = default(bool?), Azure.ResourceManager.BillingBenefits.Models.EnablementMode? automaticShortfall = default(Azure.ResourceManager.BillingBenefits.Models.EnablementMode?), Azure.ResourceManager.BillingBenefits.Models.AutomaticShortfallSuppressReason automaticShortfallSuppressReason = null, string displayName = null, Azure.ResourceManager.BillingBenefits.Models.MaccMilestoneStatus? status = default(Azure.ResourceManager.BillingBenefits.Models.MaccMilestoneStatus?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.BillingBenefits.Models.MaccMilestone> milestones = null, Azure.Core.ResourceIdentifier primaryResourceId = null, Azure.Core.ResourceIdentifier primaryBillingAccountResourceId = null, System.Collections.Generic.IDictionary<string, string> tags = null) { throw null; }
        public static Azure.ResourceManager.BillingBenefits.Models.MarketSetPricesItems MarketSetPricesItems(System.Collections.Generic.IEnumerable<string> markets = null, float value = 0f, string currency = null) { throw null; }
        public static Azure.ResourceManager.BillingBenefits.Models.PrimaryConditionalCreditProperties PrimaryConditionalCreditProperties(string displayName = null, Azure.Core.ResourceIdentifier billingAccountResourceId = null, Azure.ResourceManager.BillingBenefits.Models.ConditionalCreditsProvisioningState? provisioningState = default(Azure.ResourceManager.BillingBenefits.Models.ConditionalCreditsProvisioningState?), Azure.ResourceManager.BillingBenefits.Models.ConditionalCreditStatus? status = default(Azure.ResourceManager.BillingBenefits.Models.ConditionalCreditStatus?), System.DateTimeOffset? startOn = default(System.DateTimeOffset?), System.DateTimeOffset? endOn = default(System.DateTimeOffset?), string productCode = null, Azure.Core.ResourceIdentifier benefitResourceId = null, Azure.Core.ResourceIdentifier resourceId = null, string systemId = null, Azure.ResourceManager.BillingBenefits.Models.EnablementMode? allowContributors = default(Azure.ResourceManager.BillingBenefits.Models.EnablementMode?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.BillingBenefits.Models.ConditionalCreditMilestone> milestones = null) { throw null; }
        public static Azure.ResourceManager.BillingBenefits.Models.SavingsPlanOrderPaymentDetail SavingsPlanOrderPaymentDetail(System.DateTimeOffset? dueOn = default(System.DateTimeOffset?), System.DateTimeOffset? payOn = default(System.DateTimeOffset?), Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsPrice pricingCurrencyTotal = null, Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsPrice billingCurrencyTotal = null, Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsPaymentStatus? status = default(Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsPaymentStatus?), Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsExtendedStatusInfo extendedStatusInfo = null, string billingAccount = null) { throw null; }
        public static Azure.ResourceManager.BillingBenefits.Models.SavingsPlanUpdateValidateContent SavingsPlanUpdateValidateContent(System.Collections.Generic.IEnumerable<Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsSavingsPlanPatchProperties> benefits = null) { throw null; }
        public static Azure.ResourceManager.BillingBenefits.Models.SavingsPlanValidateModel SavingsPlanValidateModel(string displayName = null, Azure.Core.ResourceIdentifier savingsPlanOrderId = null, Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsProvisioningState? provisioningState = default(Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsProvisioningState?), Azure.Core.ResourceIdentifier billingScopeId = null, Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsTerm? term = default(Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsTerm?), Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsBillingPlan? billingPlan = default(Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsBillingPlan?), Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsAppliedScopeType? appliedScopeType = default(Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsAppliedScopeType?), Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsAppliedScopeProperties appliedScopeProperties = null, Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsCommitment commitment = null, bool? isRenewed = default(bool?), Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType? type = default(Azure.Core.ResourceType?), Azure.ResourceManager.Models.SystemData systemData = null, string skuName = null, string kind = null) { throw null; }
        public static Azure.ResourceManager.BillingBenefits.Models.SavingsPlanValidateResponse SavingsPlanValidateResponse(System.Collections.Generic.IEnumerable<Azure.ResourceManager.BillingBenefits.Models.SavingsPlanValidateResult> benefits = null, string nextLink = null) { throw null; }
        public static Azure.ResourceManager.BillingBenefits.Models.SavingsPlanValidateResult SavingsPlanValidateResult(bool? isValid = default(bool?), string reasonCode = null, string reason = null) { throw null; }
    }
    public partial class AutomaticShortfallSuppressReason : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.BillingBenefits.Models.AutomaticShortfallSuppressReason>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.BillingBenefits.Models.AutomaticShortfallSuppressReason>
    {
        public AutomaticShortfallSuppressReason() { }
        public string Code { get { throw null; } set { } }
        public string Message { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.BillingBenefits.Models.AutomaticShortfallSuppressReason JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.BillingBenefits.Models.AutomaticShortfallSuppressReason PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.BillingBenefits.Models.AutomaticShortfallSuppressReason System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.BillingBenefits.Models.AutomaticShortfallSuppressReason>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.BillingBenefits.Models.AutomaticShortfallSuppressReason>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.BillingBenefits.Models.AutomaticShortfallSuppressReason System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.BillingBenefits.Models.AutomaticShortfallSuppressReason>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.BillingBenefits.Models.AutomaticShortfallSuppressReason>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.BillingBenefits.Models.AutomaticShortfallSuppressReason>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class Award : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.BillingBenefits.Models.Award>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.BillingBenefits.Models.Award>
    {
        public Award() { }
        public float? BalanceVersion { get { throw null; } }
        public Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsCommitment Credit { get { throw null; } set { } }
        public Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsTerm? Duration { get { throw null; } set { } }
        public System.DateTimeOffset? EndOn { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier ResourceId { get { throw null; } }
        public System.DateTimeOffset? StartOn { get { throw null; } set { } }
        public string SystemId { get { throw null; } }
        protected virtual Azure.ResourceManager.BillingBenefits.Models.Award JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.BillingBenefits.Models.Award PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.BillingBenefits.Models.Award System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.BillingBenefits.Models.Award>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.BillingBenefits.Models.Award>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.BillingBenefits.Models.Award System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.BillingBenefits.Models.Award>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.BillingBenefits.Models.Award>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.BillingBenefits.Models.Award>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class BenefitValidateModel : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.BillingBenefits.Models.BenefitValidateModel>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.BillingBenefits.Models.BenefitValidateModel>
    {
        internal BenefitValidateModel() { }
        protected virtual Azure.ResourceManager.BillingBenefits.Models.BenefitValidateModel JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.BillingBenefits.Models.BenefitValidateModel PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.BillingBenefits.Models.BenefitValidateModel System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.BillingBenefits.Models.BenefitValidateModel>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.BillingBenefits.Models.BenefitValidateModel>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.BillingBenefits.Models.BenefitValidateModel System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.BillingBenefits.Models.BenefitValidateModel>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.BillingBenefits.Models.BenefitValidateModel>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.BillingBenefits.Models.BenefitValidateModel>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class BenefitValidateRequest : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.BillingBenefits.Models.BenefitValidateRequest>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.BillingBenefits.Models.BenefitValidateRequest>
    {
        public BenefitValidateRequest() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.BillingBenefits.Models.BenefitValidateModel> Benefits { get { throw null; } }
        protected virtual Azure.ResourceManager.BillingBenefits.Models.BenefitValidateRequest JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.BillingBenefits.Models.BenefitValidateRequest PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.BillingBenefits.Models.BenefitValidateRequest System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.BillingBenefits.Models.BenefitValidateRequest>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.BillingBenefits.Models.BenefitValidateRequest>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.BillingBenefits.Models.BenefitValidateRequest System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.BillingBenefits.Models.BenefitValidateRequest>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.BillingBenefits.Models.BenefitValidateRequest>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.BillingBenefits.Models.BenefitValidateRequest>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class BenefitValidateResponse : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.BillingBenefits.Models.BenefitValidateResponse>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.BillingBenefits.Models.BenefitValidateResponse>
    {
        internal BenefitValidateResponse() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.BillingBenefits.Models.BenefitValidateResponseProperty> Benefits { get { throw null; } }
        public string NextLink { get { throw null; } }
        protected virtual Azure.ResourceManager.BillingBenefits.Models.BenefitValidateResponse JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.BillingBenefits.Models.BenefitValidateResponse PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.BillingBenefits.Models.BenefitValidateResponse System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.BillingBenefits.Models.BenefitValidateResponse>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.BillingBenefits.Models.BenefitValidateResponse>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.BillingBenefits.Models.BenefitValidateResponse System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.BillingBenefits.Models.BenefitValidateResponse>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.BillingBenefits.Models.BenefitValidateResponse>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.BillingBenefits.Models.BenefitValidateResponse>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class BenefitValidateResponseProperty : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.BillingBenefits.Models.BenefitValidateResponseProperty>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.BillingBenefits.Models.BenefitValidateResponseProperty>
    {
        internal BenefitValidateResponseProperty() { }
        public bool? IsValid { get { throw null; } }
        public string Reason { get { throw null; } }
        public string ReasonCode { get { throw null; } }
        public Azure.Core.ResourceIdentifier ResourceId { get { throw null; } }
        protected virtual Azure.ResourceManager.BillingBenefits.Models.BenefitValidateResponseProperty JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.BillingBenefits.Models.BenefitValidateResponseProperty PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.BillingBenefits.Models.BenefitValidateResponseProperty System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.BillingBenefits.Models.BenefitValidateResponseProperty>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.BillingBenefits.Models.BenefitValidateResponseProperty>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.BillingBenefits.Models.BenefitValidateResponseProperty System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.BillingBenefits.Models.BenefitValidateResponseProperty>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.BillingBenefits.Models.BenefitValidateResponseProperty>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.BillingBenefits.Models.BenefitValidateResponseProperty>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class BillingBenefitsAppliedScopeProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsAppliedScopeProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsAppliedScopeProperties>
    {
        public BillingBenefitsAppliedScopeProperties() { }
        public string DisplayName { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier ManagementGroupId { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier ResourceGroupId { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier SubscriptionId { get { throw null; } set { } }
        public System.Guid? TenantId { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsAppliedScopeProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsAppliedScopeProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsAppliedScopeProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsAppliedScopeProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsAppliedScopeProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsAppliedScopeProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsAppliedScopeProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsAppliedScopeProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsAppliedScopeProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct BillingBenefitsAppliedScopeType : System.IEquatable<Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsAppliedScopeType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public BillingBenefitsAppliedScopeType(string value) { throw null; }
        public static Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsAppliedScopeType ManagementGroup { get { throw null; } }
        public static Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsAppliedScopeType Shared { get { throw null; } }
        public static Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsAppliedScopeType Single { get { throw null; } }
        public bool Equals(Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsAppliedScopeType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsAppliedScopeType left, Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsAppliedScopeType right) { throw null; }
        public static implicit operator Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsAppliedScopeType (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsAppliedScopeType? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsAppliedScopeType left, Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsAppliedScopeType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct BillingBenefitsBillingPlan : System.IEquatable<Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsBillingPlan>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public BillingBenefitsBillingPlan(string value) { throw null; }
        public static Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsBillingPlan P1M { get { throw null; } }
        public bool Equals(Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsBillingPlan other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsBillingPlan left, Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsBillingPlan right) { throw null; }
        public static implicit operator Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsBillingPlan (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsBillingPlan? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsBillingPlan left, Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsBillingPlan right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class BillingBenefitsCommitment : Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsPrice, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsCommitment>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsCommitment>
    {
        public BillingBenefitsCommitment() { }
        public Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsCommitmentGrain? Grain { get { throw null; } set { } }
        protected override Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsPrice JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsPrice PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsCommitment System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsCommitment>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsCommitment>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsCommitment System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsCommitment>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsCommitment>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsCommitment>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct BillingBenefitsCommitmentGrain : System.IEquatable<Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsCommitmentGrain>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public BillingBenefitsCommitmentGrain(string value) { throw null; }
        public static Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsCommitmentGrain FullTerm { get { throw null; } }
        public static Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsCommitmentGrain Hourly { get { throw null; } }
        public static Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsCommitmentGrain Unknown { get { throw null; } }
        public bool Equals(Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsCommitmentGrain other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsCommitmentGrain left, Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsCommitmentGrain right) { throw null; }
        public static implicit operator Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsCommitmentGrain (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsCommitmentGrain? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsCommitmentGrain left, Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsCommitmentGrain right) { throw null; }
        public override string ToString() { throw null; }
    }
    public abstract partial class BillingBenefitsConditionalCreditProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsConditionalCreditProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsConditionalCreditProperties>
    {
        internal BillingBenefitsConditionalCreditProperties() { }
        public Azure.Core.ResourceIdentifier BenefitResourceId { get { throw null; } }
        public Azure.Core.ResourceIdentifier BillingAccountResourceId { get { throw null; } set { } }
        public string DisplayName { get { throw null; } set { } }
        public System.DateTimeOffset? EndOn { get { throw null; } set { } }
        public string ProductCode { get { throw null; } set { } }
        public Azure.ResourceManager.BillingBenefits.Models.ConditionalCreditsProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.Core.ResourceIdentifier ResourceId { get { throw null; } set { } }
        public System.DateTimeOffset? StartOn { get { throw null; } set { } }
        public Azure.ResourceManager.BillingBenefits.Models.ConditionalCreditStatus? Status { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsConditionalCreditProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsConditionalCreditProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsConditionalCreditProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsConditionalCreditProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsConditionalCreditProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsConditionalCreditProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsConditionalCreditProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsConditionalCreditProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsConditionalCreditProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class BillingBenefitsDiscountProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsDiscountProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsDiscountProperties>
    {
        internal BillingBenefitsDiscountProperties() { }
        public Azure.ResourceManager.BillingBenefits.Models.DiscountAppliedScopeType? AppliedScopeType { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier BenefitResourceId { get { throw null; } }
        public Azure.Core.ResourceIdentifier BillingAccountResourceId { get { throw null; } }
        public Azure.Core.ResourceIdentifier BillingProfileResourceId { get { throw null; } }
        public Azure.Core.ResourceIdentifier CustomerResourceId { get { throw null; } }
        public string DisplayName { get { throw null; } set { } }
        public string ProductCode { get { throw null; } set { } }
        public Azure.ResourceManager.BillingBenefits.Models.DiscountProvisioningState? ProvisioningState { get { throw null; } }
        public System.DateTimeOffset StartOn { get { throw null; } set { } }
        public Azure.ResourceManager.BillingBenefits.Models.DiscountStatus? Status { get { throw null; } }
        public string SystemId { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsDiscountProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsDiscountProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsDiscountProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsDiscountProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsDiscountProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsDiscountProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsDiscountProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsDiscountProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsDiscountProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class BillingBenefitsExtendedStatusInfo : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsExtendedStatusInfo>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsExtendedStatusInfo>
    {
        internal BillingBenefitsExtendedStatusInfo() { }
        public string Message { get { throw null; } }
        public string StatusCode { get { throw null; } }
        protected virtual Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsExtendedStatusInfo JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsExtendedStatusInfo PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsExtendedStatusInfo System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsExtendedStatusInfo>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsExtendedStatusInfo>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsExtendedStatusInfo System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsExtendedStatusInfo>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsExtendedStatusInfo>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsExtendedStatusInfo>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct BillingBenefitsInstanceFlexibility : System.IEquatable<Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsInstanceFlexibility>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public BillingBenefitsInstanceFlexibility(string value) { throw null; }
        public static Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsInstanceFlexibility Off { get { throw null; } }
        public static Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsInstanceFlexibility On { get { throw null; } }
        public bool Equals(Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsInstanceFlexibility other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsInstanceFlexibility left, Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsInstanceFlexibility right) { throw null; }
        public static implicit operator Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsInstanceFlexibility (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsInstanceFlexibility? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsInstanceFlexibility left, Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsInstanceFlexibility right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class BillingBenefitsManagedServiceIdentity : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsManagedServiceIdentity>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsManagedServiceIdentity>
    {
        public BillingBenefitsManagedServiceIdentity(Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsManagedServiceIdentityType type) { }
        public string PrincipalId { get { throw null; } }
        public string TenantId { get { throw null; } }
        public Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsManagedServiceIdentityType Type { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, Azure.ResourceManager.Models.UserAssignedIdentity> UserAssignedIdentities { get { throw null; } }
        protected virtual Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsManagedServiceIdentity JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsManagedServiceIdentity PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsManagedServiceIdentity System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsManagedServiceIdentity>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsManagedServiceIdentity>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsManagedServiceIdentity System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsManagedServiceIdentity>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsManagedServiceIdentity>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsManagedServiceIdentity>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct BillingBenefitsManagedServiceIdentityType : System.IEquatable<Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsManagedServiceIdentityType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public BillingBenefitsManagedServiceIdentityType(string value) { throw null; }
        public static Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsManagedServiceIdentityType None { get { throw null; } }
        public static Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsManagedServiceIdentityType SystemAssigned { get { throw null; } }
        public static Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsManagedServiceIdentityType SystemAssignedUserAssigned { get { throw null; } }
        public static Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsManagedServiceIdentityType UserAssigned { get { throw null; } }
        public bool Equals(Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsManagedServiceIdentityType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsManagedServiceIdentityType left, Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsManagedServiceIdentityType right) { throw null; }
        public static implicit operator Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsManagedServiceIdentityType (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsManagedServiceIdentityType? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsManagedServiceIdentityType left, Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsManagedServiceIdentityType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct BillingBenefitsPaymentStatus : System.IEquatable<Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsPaymentStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public BillingBenefitsPaymentStatus(string value) { throw null; }
        public static Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsPaymentStatus Cancelled { get { throw null; } }
        public static Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsPaymentStatus Failed { get { throw null; } }
        public static Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsPaymentStatus Scheduled { get { throw null; } }
        public static Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsPaymentStatus Succeeded { get { throw null; } }
        public bool Equals(Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsPaymentStatus other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsPaymentStatus left, Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsPaymentStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsPaymentStatus (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsPaymentStatus? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsPaymentStatus left, Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsPaymentStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class BillingBenefitsPlan : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsPlan>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsPlan>
    {
        public BillingBenefitsPlan(string name, string publisher, string product) { }
        public string Name { get { throw null; } set { } }
        public string Product { get { throw null; } set { } }
        public string PromotionCode { get { throw null; } set { } }
        public string Publisher { get { throw null; } set { } }
        public string Version { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsPlan JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsPlan PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsPlan System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsPlan>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsPlan>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsPlan System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsPlan>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsPlan>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsPlan>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class BillingBenefitsPrice : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsPrice>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsPrice>
    {
        public BillingBenefitsPrice() { }
        public double? Amount { get { throw null; } set { } }
        public string CurrencyCode { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsPrice JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsPrice PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsPrice System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsPrice>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsPrice>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsPrice System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsPrice>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsPrice>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsPrice>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct BillingBenefitsProvisioningState : System.IEquatable<Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public BillingBenefitsProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsProvisioningState Cancelled { get { throw null; } }
        public static Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsProvisioningState ConfirmedBilling { get { throw null; } }
        public static Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsProvisioningState Created { get { throw null; } }
        public static Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsProvisioningState Creating { get { throw null; } }
        public static Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsProvisioningState Expired { get { throw null; } }
        public static Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsProvisioningState PendingBilling { get { throw null; } }
        public static Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsProvisioningState Succeeded { get { throw null; } }
        public bool Equals(Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsProvisioningState other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsProvisioningState left, Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsProvisioningState (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsProvisioningState? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsProvisioningState left, Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class BillingBenefitsPurchaseContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsPurchaseContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsPurchaseContent>
    {
        public BillingBenefitsPurchaseContent() { }
        public Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsAppliedScopeProperties AppliedScopeProperties { get { throw null; } set { } }
        public Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsAppliedScopeType? AppliedScopeType { get { throw null; } set { } }
        public Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsBillingPlan? BillingPlan { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier BillingScopeId { get { throw null; } set { } }
        public Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsCommitment Commitment { get { throw null; } set { } }
        public string DisplayName { get { throw null; } set { } }
        public System.DateTimeOffset? EffectOn { get { throw null; } }
        public bool? IsRenewed { get { throw null; } set { } }
        public string SkuName { get { throw null; } set { } }
        public Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsTerm? Term { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsPurchaseContent JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsPurchaseContent PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsPurchaseContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsPurchaseContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsPurchaseContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsPurchaseContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsPurchaseContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsPurchaseContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsPurchaseContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class BillingBenefitsReservationOrderAliasCreateOrUpdateContent : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsReservationOrderAliasCreateOrUpdateContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsReservationOrderAliasCreateOrUpdateContent>
    {
        public BillingBenefitsReservationOrderAliasCreateOrUpdateContent() { }
        public Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsAppliedScopeProperties AppliedScopeProperties { get { throw null; } set { } }
        public Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsAppliedScopeType? AppliedScopeType { get { throw null; } set { } }
        public Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsBillingPlan? BillingPlan { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier BillingScopeId { get { throw null; } set { } }
        public string DisplayName { get { throw null; } set { } }
        public bool? IsRenewed { get { throw null; } set { } }
        public Azure.Core.AzureLocation? Location { get { throw null; } set { } }
        public int? Quantity { get { throw null; } set { } }
        public Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsInstanceFlexibility? ReservedResourceInstanceFlexibility { get { throw null; } set { } }
        public Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsReservedResourceType? ReservedResourceType { get { throw null; } set { } }
        public System.DateTimeOffset? ReviewOn { get { throw null; } set { } }
        public string SkuName { get { throw null; } set { } }
        public Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsTerm? Term { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsReservationOrderAliasCreateOrUpdateContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsReservationOrderAliasCreateOrUpdateContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsReservationOrderAliasCreateOrUpdateContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsReservationOrderAliasCreateOrUpdateContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsReservationOrderAliasCreateOrUpdateContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsReservationOrderAliasCreateOrUpdateContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsReservationOrderAliasCreateOrUpdateContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct BillingBenefitsReservedResourceType : System.IEquatable<Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsReservedResourceType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public BillingBenefitsReservedResourceType(string value) { throw null; }
        public static Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsReservedResourceType AppService { get { throw null; } }
        public static Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsReservedResourceType Avs { get { throw null; } }
        public static Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsReservedResourceType AzureDataExplorer { get { throw null; } }
        public static Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsReservedResourceType AzureFiles { get { throw null; } }
        public static Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsReservedResourceType BlockBlob { get { throw null; } }
        public static Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsReservedResourceType CosmosDB { get { throw null; } }
        public static Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsReservedResourceType Databricks { get { throw null; } }
        public static Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsReservedResourceType DataFactory { get { throw null; } }
        public static Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsReservedResourceType DedicatedHost { get { throw null; } }
        public static Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsReservedResourceType ManagedDisk { get { throw null; } }
        public static Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsReservedResourceType MariaDB { get { throw null; } }
        public static Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsReservedResourceType MySql { get { throw null; } }
        public static Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsReservedResourceType NetAppStorage { get { throw null; } }
        public static Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsReservedResourceType PostgreSql { get { throw null; } }
        public static Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsReservedResourceType RedHat { get { throw null; } }
        public static Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsReservedResourceType RedHatOsa { get { throw null; } }
        public static Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsReservedResourceType RedisCache { get { throw null; } }
        public static Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsReservedResourceType SapHana { get { throw null; } }
        public static Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsReservedResourceType SqlAzureHybridBenefit { get { throw null; } }
        public static Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsReservedResourceType SqlDatabases { get { throw null; } }
        public static Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsReservedResourceType SqlDataWarehouse { get { throw null; } }
        public static Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsReservedResourceType SqlEdge { get { throw null; } }
        public static Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsReservedResourceType SuseLinux { get { throw null; } }
        public static Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsReservedResourceType VirtualMachines { get { throw null; } }
        public static Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsReservedResourceType VirtualMachineSoftware { get { throw null; } }
        public static Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsReservedResourceType VMwareCloudSimple { get { throw null; } }
        public bool Equals(Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsReservedResourceType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsReservedResourceType left, Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsReservedResourceType right) { throw null; }
        public static implicit operator Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsReservedResourceType (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsReservedResourceType? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsReservedResourceType left, Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsReservedResourceType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class BillingBenefitsRoleAssignmentEntity : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsRoleAssignmentEntity>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsRoleAssignmentEntity>
    {
        internal BillingBenefitsRoleAssignmentEntity() { }
        public Azure.Core.ResourceIdentifier Id { get { throw null; } }
        public string Name { get { throw null; } }
        public string PrincipalId { get { throw null; } }
        public Azure.Core.ResourceIdentifier RoleDefinitionId { get { throw null; } }
        public Azure.Core.ResourceIdentifier Scope { get { throw null; } }
        protected virtual Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsRoleAssignmentEntity JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsRoleAssignmentEntity PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsRoleAssignmentEntity System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsRoleAssignmentEntity>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsRoleAssignmentEntity>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsRoleAssignmentEntity System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsRoleAssignmentEntity>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsRoleAssignmentEntity>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsRoleAssignmentEntity>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class BillingBenefitsSavingsPlanPatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsSavingsPlanPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsSavingsPlanPatch>
    {
        public BillingBenefitsSavingsPlanPatch() { }
        public Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsSavingsPlanPatchProperties Properties { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsSavingsPlanPatch JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsSavingsPlanPatch PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsSavingsPlanPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsSavingsPlanPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsSavingsPlanPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsSavingsPlanPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsSavingsPlanPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsSavingsPlanPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsSavingsPlanPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class BillingBenefitsSavingsPlanPatchProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsSavingsPlanPatchProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsSavingsPlanPatchProperties>
    {
        public BillingBenefitsSavingsPlanPatchProperties() { }
        public Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsAppliedScopeProperties AppliedScopeProperties { get { throw null; } set { } }
        public Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsAppliedScopeType? AppliedScopeType { get { throw null; } set { } }
        public string DisplayName { get { throw null; } set { } }
        public bool? IsRenewed { get { throw null; } set { } }
        public Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsPurchaseContent RenewPurchaseProperties { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsSavingsPlanPatchProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsSavingsPlanPatchProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsSavingsPlanPatchProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsSavingsPlanPatchProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsSavingsPlanPatchProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsSavingsPlanPatchProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsSavingsPlanPatchProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsSavingsPlanPatchProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsSavingsPlanPatchProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class BillingBenefitsSavingsPlanUtilization : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsSavingsPlanUtilization>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsSavingsPlanUtilization>
    {
        internal BillingBenefitsSavingsPlanUtilization() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsSavingsPlanUtilizationAggregate> Aggregates { get { throw null; } }
        public string Trend { get { throw null; } }
        protected virtual Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsSavingsPlanUtilization JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsSavingsPlanUtilization PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsSavingsPlanUtilization System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsSavingsPlanUtilization>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsSavingsPlanUtilization>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsSavingsPlanUtilization System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsSavingsPlanUtilization>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsSavingsPlanUtilization>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsSavingsPlanUtilization>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class BillingBenefitsSavingsPlanUtilizationAggregate : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsSavingsPlanUtilizationAggregate>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsSavingsPlanUtilizationAggregate>
    {
        internal BillingBenefitsSavingsPlanUtilizationAggregate() { }
        public float? Grain { get { throw null; } }
        public string GrainUnit { get { throw null; } }
        public float? Value { get { throw null; } }
        public string ValueUnit { get { throw null; } }
        protected virtual Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsSavingsPlanUtilizationAggregate JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsSavingsPlanUtilizationAggregate PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsSavingsPlanUtilizationAggregate System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsSavingsPlanUtilizationAggregate>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsSavingsPlanUtilizationAggregate>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsSavingsPlanUtilizationAggregate System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsSavingsPlanUtilizationAggregate>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsSavingsPlanUtilizationAggregate>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsSavingsPlanUtilizationAggregate>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class BillingBenefitsSku : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsSku>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsSku>
    {
        public BillingBenefitsSku(string name) { }
        public int? Capacity { get { throw null; } set { } }
        public string Family { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public string Size { get { throw null; } set { } }
        public Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsSkuTier? Tier { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsSku JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsSku PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsSku System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsSku>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsSku>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsSku System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsSku>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsSku>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsSku>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public enum BillingBenefitsSkuTier
    {
        Free = 0,
        Basic = 1,
        Standard = 2,
        Premium = 3,
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct BillingBenefitsTerm : System.IEquatable<Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsTerm>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public BillingBenefitsTerm(string value) { throw null; }
        public static Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsTerm P1M { get { throw null; } }
        public static Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsTerm P1Y { get { throw null; } }
        public static Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsTerm P3Y { get { throw null; } }
        public static Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsTerm P5Y { get { throw null; } }
        public bool Equals(Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsTerm other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsTerm left, Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsTerm right) { throw null; }
        public static implicit operator Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsTerm (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsTerm? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsTerm left, Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsTerm right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class BillingPlanInformation : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.BillingBenefits.Models.BillingPlanInformation>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.BillingBenefits.Models.BillingPlanInformation>
    {
        public BillingPlanInformation() { }
        public System.DateTimeOffset? NextPaymentDueOn { get { throw null; } set { } }
        public Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsPrice PricingCurrencyTotal { get { throw null; } set { } }
        public System.DateTimeOffset? StartOn { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.BillingBenefits.Models.SavingsPlanOrderPaymentDetail> Transactions { get { throw null; } }
        protected virtual Azure.ResourceManager.BillingBenefits.Models.BillingPlanInformation JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.BillingBenefits.Models.BillingPlanInformation PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.BillingBenefits.Models.BillingPlanInformation System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.BillingBenefits.Models.BillingPlanInformation>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.BillingBenefits.Models.BillingPlanInformation>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.BillingBenefits.Models.BillingPlanInformation System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.BillingBenefits.Models.BillingPlanInformation>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.BillingBenefits.Models.BillingPlanInformation>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.BillingBenefits.Models.BillingPlanInformation>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CatalogClaimsItem : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.BillingBenefits.Models.CatalogClaimsItem>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.BillingBenefits.Models.CatalogClaimsItem>
    {
        public CatalogClaimsItem() { }
        public string CatalogClaimsItemType { get { throw null; } set { } }
        public string Value { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.BillingBenefits.Models.CatalogClaimsItem JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.BillingBenefits.Models.CatalogClaimsItem PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.BillingBenefits.Models.CatalogClaimsItem System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.BillingBenefits.Models.CatalogClaimsItem>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.BillingBenefits.Models.CatalogClaimsItem>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.BillingBenefits.Models.CatalogClaimsItem System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.BillingBenefits.Models.CatalogClaimsItem>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.BillingBenefits.Models.CatalogClaimsItem>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.BillingBenefits.Models.CatalogClaimsItem>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ChargeShortfallRequest : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.BillingBenefits.Models.ChargeShortfallRequest>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.BillingBenefits.Models.ChargeShortfallRequest>
    {
        public ChargeShortfallRequest() { }
        public float? BalanceVersion { get { throw null; } set { } }
        public Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsCommitment Charge { get { throw null; } set { } }
        public System.DateTimeOffset? EndOn { get { throw null; } set { } }
        public string ProductCode { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier ResourceId { get { throw null; } set { } }
        public System.DateTimeOffset? StartOn { get { throw null; } set { } }
        public string SystemId { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.BillingBenefits.Models.ChargeShortfallRequest JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.BillingBenefits.Models.ChargeShortfallRequest PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.BillingBenefits.Models.ChargeShortfallRequest System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.BillingBenefits.Models.ChargeShortfallRequest>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.BillingBenefits.Models.ChargeShortfallRequest>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.BillingBenefits.Models.ChargeShortfallRequest System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.BillingBenefits.Models.ChargeShortfallRequest>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.BillingBenefits.Models.ChargeShortfallRequest>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.BillingBenefits.Models.ChargeShortfallRequest>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ConditionalCreditMilestone : Azure.ResourceManager.BillingBenefits.Models.ConditionalCreditMilestoneBase, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.BillingBenefits.Models.ConditionalCreditMilestone>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.BillingBenefits.Models.ConditionalCreditMilestone>
    {
        public ConditionalCreditMilestone() { }
        protected override Azure.ResourceManager.BillingBenefits.Models.ConditionalCreditMilestoneBase JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.ResourceManager.BillingBenefits.Models.ConditionalCreditMilestoneBase PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.BillingBenefits.Models.ConditionalCreditMilestone System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.BillingBenefits.Models.ConditionalCreditMilestone>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.BillingBenefits.Models.ConditionalCreditMilestone>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.BillingBenefits.Models.ConditionalCreditMilestone System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.BillingBenefits.Models.ConditionalCreditMilestone>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.BillingBenefits.Models.ConditionalCreditMilestone>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.BillingBenefits.Models.ConditionalCreditMilestone>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ConditionalCreditMilestoneBase : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.BillingBenefits.Models.ConditionalCreditMilestoneBase>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.BillingBenefits.Models.ConditionalCreditMilestoneBase>
    {
        public ConditionalCreditMilestoneBase() { }
        public Azure.ResourceManager.BillingBenefits.Models.Award Award { get { throw null; } set { } }
        public System.DateTimeOffset? EndOn { get { throw null; } set { } }
        public string MilestoneId { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsPrice SpendTarget { get { throw null; } set { } }
        public Azure.ResourceManager.BillingBenefits.Models.MilestoneStatus? Status { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.BillingBenefits.Models.ConditionalCreditMilestoneBase JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.BillingBenefits.Models.ConditionalCreditMilestoneBase PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.BillingBenefits.Models.ConditionalCreditMilestoneBase System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.BillingBenefits.Models.ConditionalCreditMilestoneBase>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.BillingBenefits.Models.ConditionalCreditMilestoneBase>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.BillingBenefits.Models.ConditionalCreditMilestoneBase System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.BillingBenefits.Models.ConditionalCreditMilestoneBase>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.BillingBenefits.Models.ConditionalCreditMilestoneBase>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.BillingBenefits.Models.ConditionalCreditMilestoneBase>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ConditionalCreditPatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.BillingBenefits.Models.ConditionalCreditPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.BillingBenefits.Models.ConditionalCreditPatch>
    {
        public ConditionalCreditPatch() { }
        public Azure.ResourceManager.BillingBenefits.Models.EnablementMode? AllowContributors { get { throw null; } set { } }
        public string DisplayName { get { throw null; } set { } }
        public System.DateTimeOffset? EndOn { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.BillingBenefits.Models.ConditionalCreditMilestone> Milestones { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        protected virtual Azure.ResourceManager.BillingBenefits.Models.ConditionalCreditPatch JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.BillingBenefits.Models.ConditionalCreditPatch PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.BillingBenefits.Models.ConditionalCreditPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.BillingBenefits.Models.ConditionalCreditPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.BillingBenefits.Models.ConditionalCreditPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.BillingBenefits.Models.ConditionalCreditPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.BillingBenefits.Models.ConditionalCreditPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.BillingBenefits.Models.ConditionalCreditPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.BillingBenefits.Models.ConditionalCreditPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ConditionalCreditsProvisioningState : System.IEquatable<Azure.ResourceManager.BillingBenefits.Models.ConditionalCreditsProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ConditionalCreditsProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.BillingBenefits.Models.ConditionalCreditsProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.BillingBenefits.Models.ConditionalCreditsProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.BillingBenefits.Models.ConditionalCreditsProvisioningState Pending { get { throw null; } }
        public static Azure.ResourceManager.BillingBenefits.Models.ConditionalCreditsProvisioningState Succeeded { get { throw null; } }
        public static Azure.ResourceManager.BillingBenefits.Models.ConditionalCreditsProvisioningState Unknown { get { throw null; } }
        public bool Equals(Azure.ResourceManager.BillingBenefits.Models.ConditionalCreditsProvisioningState other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.BillingBenefits.Models.ConditionalCreditsProvisioningState left, Azure.ResourceManager.BillingBenefits.Models.ConditionalCreditsProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.BillingBenefits.Models.ConditionalCreditsProvisioningState (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.BillingBenefits.Models.ConditionalCreditsProvisioningState? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.BillingBenefits.Models.ConditionalCreditsProvisioningState left, Azure.ResourceManager.BillingBenefits.Models.ConditionalCreditsProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ConditionalCreditStatus : System.IEquatable<Azure.ResourceManager.BillingBenefits.Models.ConditionalCreditStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ConditionalCreditStatus(string value) { throw null; }
        public static Azure.ResourceManager.BillingBenefits.Models.ConditionalCreditStatus Active { get { throw null; } }
        public static Azure.ResourceManager.BillingBenefits.Models.ConditionalCreditStatus Canceled { get { throw null; } }
        public static Azure.ResourceManager.BillingBenefits.Models.ConditionalCreditStatus Completed { get { throw null; } }
        public static Azure.ResourceManager.BillingBenefits.Models.ConditionalCreditStatus Failed { get { throw null; } }
        public static Azure.ResourceManager.BillingBenefits.Models.ConditionalCreditStatus Pending { get { throw null; } }
        public static Azure.ResourceManager.BillingBenefits.Models.ConditionalCreditStatus PendingSettlement { get { throw null; } }
        public static Azure.ResourceManager.BillingBenefits.Models.ConditionalCreditStatus Scheduled { get { throw null; } }
        public static Azure.ResourceManager.BillingBenefits.Models.ConditionalCreditStatus Stopped { get { throw null; } }
        public static Azure.ResourceManager.BillingBenefits.Models.ConditionalCreditStatus Unknown { get { throw null; } }
        public bool Equals(Azure.ResourceManager.BillingBenefits.Models.ConditionalCreditStatus other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.BillingBenefits.Models.ConditionalCreditStatus left, Azure.ResourceManager.BillingBenefits.Models.ConditionalCreditStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.BillingBenefits.Models.ConditionalCreditStatus (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.BillingBenefits.Models.ConditionalCreditStatus? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.BillingBenefits.Models.ConditionalCreditStatus left, Azure.ResourceManager.BillingBenefits.Models.ConditionalCreditStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ConditionalCreditsValidateModel : Azure.ResourceManager.BillingBenefits.Models.BenefitValidateModel, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.BillingBenefits.Models.ConditionalCreditsValidateModel>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.BillingBenefits.Models.ConditionalCreditsValidateModel>
    {
        public ConditionalCreditsValidateModel() { }
        public Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsConditionalCreditProperties Properties { get { throw null; } set { } }
        protected override Azure.ResourceManager.BillingBenefits.Models.BenefitValidateModel JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.ResourceManager.BillingBenefits.Models.BenefitValidateModel PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.BillingBenefits.Models.ConditionalCreditsValidateModel System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.BillingBenefits.Models.ConditionalCreditsValidateModel>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.BillingBenefits.Models.ConditionalCreditsValidateModel>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.BillingBenefits.Models.ConditionalCreditsValidateModel System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.BillingBenefits.Models.ConditionalCreditsValidateModel>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.BillingBenefits.Models.ConditionalCreditsValidateModel>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.BillingBenefits.Models.ConditionalCreditsValidateModel>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ConditionsItem : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.BillingBenefits.Models.ConditionsItem>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.BillingBenefits.Models.ConditionsItem>
    {
        public ConditionsItem() { }
        public string ConditionName { get { throw null; } set { } }
        public string Type { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Value { get { throw null; } }
        protected virtual Azure.ResourceManager.BillingBenefits.Models.ConditionsItem JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.BillingBenefits.Models.ConditionsItem PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.BillingBenefits.Models.ConditionsItem System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.BillingBenefits.Models.ConditionsItem>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.BillingBenefits.Models.ConditionsItem>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.BillingBenefits.Models.ConditionsItem System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.BillingBenefits.Models.ConditionsItem>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.BillingBenefits.Models.ConditionsItem>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.BillingBenefits.Models.ConditionsItem>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ContributorConditionalCreditMilestone : Azure.ResourceManager.BillingBenefits.Models.ConditionalCreditMilestoneBase, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.BillingBenefits.Models.ContributorConditionalCreditMilestone>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.BillingBenefits.Models.ContributorConditionalCreditMilestone>
    {
        internal ContributorConditionalCreditMilestone() { }
        protected override Azure.ResourceManager.BillingBenefits.Models.ConditionalCreditMilestoneBase JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.ResourceManager.BillingBenefits.Models.ConditionalCreditMilestoneBase PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.BillingBenefits.Models.ContributorConditionalCreditMilestone System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.BillingBenefits.Models.ContributorConditionalCreditMilestone>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.BillingBenefits.Models.ContributorConditionalCreditMilestone>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.BillingBenefits.Models.ContributorConditionalCreditMilestone System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.BillingBenefits.Models.ContributorConditionalCreditMilestone>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.BillingBenefits.Models.ContributorConditionalCreditMilestone>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.BillingBenefits.Models.ContributorConditionalCreditMilestone>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ContributorConditionalCreditProperties : Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsConditionalCreditProperties, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.BillingBenefits.Models.ContributorConditionalCreditProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.BillingBenefits.Models.ContributorConditionalCreditProperties>
    {
        public ContributorConditionalCreditProperties() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.BillingBenefits.Models.ContributorConditionalCreditMilestone> Milestones { get { throw null; } }
        public Azure.Core.ResourceIdentifier PrimaryBillingAccountResourceId { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier PrimaryResourceId { get { throw null; } set { } }
        public string SystemId { get { throw null; } set { } }
        protected override Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsConditionalCreditProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsConditionalCreditProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.BillingBenefits.Models.ContributorConditionalCreditProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.BillingBenefits.Models.ContributorConditionalCreditProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.BillingBenefits.Models.ContributorConditionalCreditProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.BillingBenefits.Models.ContributorConditionalCreditProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.BillingBenefits.Models.ContributorConditionalCreditProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.BillingBenefits.Models.ContributorConditionalCreditProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.BillingBenefits.Models.ContributorConditionalCreditProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CreditBreakdownItem : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.BillingBenefits.Models.CreditBreakdownItem>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.BillingBenefits.Models.CreditBreakdownItem>
    {
        public CreditBreakdownItem() { }
        public Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsCommitment Allocation { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.BillingBenefits.Models.CreditDimension> Dimensions { get { throw null; } }
        public System.DateTimeOffset? EndOn { get { throw null; } set { } }
        public System.DateTimeOffset? StartOn { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.BillingBenefits.Models.CreditBreakdownItem JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.BillingBenefits.Models.CreditBreakdownItem PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.BillingBenefits.Models.CreditBreakdownItem System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.BillingBenefits.Models.CreditBreakdownItem>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.BillingBenefits.Models.CreditBreakdownItem>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.BillingBenefits.Models.CreditBreakdownItem System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.BillingBenefits.Models.CreditBreakdownItem>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.BillingBenefits.Models.CreditBreakdownItem>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.BillingBenefits.Models.CreditBreakdownItem>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CreditDimension : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.BillingBenefits.Models.CreditDimension>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.BillingBenefits.Models.CreditDimension>
    {
        public CreditDimension(string key, string value) { }
        public string Key { get { throw null; } set { } }
        public string Value { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.BillingBenefits.Models.CreditDimension JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.BillingBenefits.Models.CreditDimension PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.BillingBenefits.Models.CreditDimension System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.BillingBenefits.Models.CreditDimension>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.BillingBenefits.Models.CreditDimension>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.BillingBenefits.Models.CreditDimension System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.BillingBenefits.Models.CreditDimension>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.BillingBenefits.Models.CreditDimension>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.BillingBenefits.Models.CreditDimension>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct CreditExpirationPolicy : System.IEquatable<Azure.ResourceManager.BillingBenefits.Models.CreditExpirationPolicy>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public CreditExpirationPolicy(string value) { throw null; }
        public static Azure.ResourceManager.BillingBenefits.Models.CreditExpirationPolicy None { get { throw null; } }
        public static Azure.ResourceManager.BillingBenefits.Models.CreditExpirationPolicy SuspendBillingProfile { get { throw null; } }
        public bool Equals(Azure.ResourceManager.BillingBenefits.Models.CreditExpirationPolicy other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.BillingBenefits.Models.CreditExpirationPolicy left, Azure.ResourceManager.BillingBenefits.Models.CreditExpirationPolicy right) { throw null; }
        public static implicit operator Azure.ResourceManager.BillingBenefits.Models.CreditExpirationPolicy (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.BillingBenefits.Models.CreditExpirationPolicy? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.BillingBenefits.Models.CreditExpirationPolicy left, Azure.ResourceManager.BillingBenefits.Models.CreditExpirationPolicy right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class CreditPatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.BillingBenefits.Models.CreditPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.BillingBenefits.Models.CreditPatch>
    {
        public CreditPatch() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.BillingBenefits.Models.CreditBreakdownItem> Breakdown { get { throw null; } }
        public Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsCommitment Credit { get { throw null; } set { } }
        public System.DateTimeOffset? EndOn { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        protected virtual Azure.ResourceManager.BillingBenefits.Models.CreditPatch JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.BillingBenefits.Models.CreditPatch PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.BillingBenefits.Models.CreditPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.BillingBenefits.Models.CreditPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.BillingBenefits.Models.CreditPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.BillingBenefits.Models.CreditPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.BillingBenefits.Models.CreditPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.BillingBenefits.Models.CreditPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.BillingBenefits.Models.CreditPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CreditPolicies : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.BillingBenefits.Models.CreditPolicies>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.BillingBenefits.Models.CreditPolicies>
    {
        public CreditPolicies() { }
        public Azure.ResourceManager.BillingBenefits.Models.CreditExpirationPolicy? Expiration { get { throw null; } set { } }
        public Azure.ResourceManager.BillingBenefits.Models.CreditRedemptionPolicy? Redemption { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.BillingBenefits.Models.CreditPolicies JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.BillingBenefits.Models.CreditPolicies PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.BillingBenefits.Models.CreditPolicies System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.BillingBenefits.Models.CreditPolicies>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.BillingBenefits.Models.CreditPolicies>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.BillingBenefits.Models.CreditPolicies System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.BillingBenefits.Models.CreditPolicies>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.BillingBenefits.Models.CreditPolicies>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.BillingBenefits.Models.CreditPolicies>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CreditReason : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.BillingBenefits.Models.CreditReason>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.BillingBenefits.Models.CreditReason>
    {
        public CreditReason() { }
        public string Code { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.BillingBenefits.Models.CreditReason JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.BillingBenefits.Models.CreditReason PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.BillingBenefits.Models.CreditReason System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.BillingBenefits.Models.CreditReason>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.BillingBenefits.Models.CreditReason>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.BillingBenefits.Models.CreditReason System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.BillingBenefits.Models.CreditReason>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.BillingBenefits.Models.CreditReason>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.BillingBenefits.Models.CreditReason>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct CreditRedemptionPolicy : System.IEquatable<Azure.ResourceManager.BillingBenefits.Models.CreditRedemptionPolicy>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public CreditRedemptionPolicy(string value) { throw null; }
        public static Azure.ResourceManager.BillingBenefits.Models.CreditRedemptionPolicy AutoRedeem { get { throw null; } }
        public static Azure.ResourceManager.BillingBenefits.Models.CreditRedemptionPolicy ManualRedeem { get { throw null; } }
        public static Azure.ResourceManager.BillingBenefits.Models.CreditRedemptionPolicy NotApplicable { get { throw null; } }
        public bool Equals(Azure.ResourceManager.BillingBenefits.Models.CreditRedemptionPolicy other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.BillingBenefits.Models.CreditRedemptionPolicy left, Azure.ResourceManager.BillingBenefits.Models.CreditRedemptionPolicy right) { throw null; }
        public static implicit operator Azure.ResourceManager.BillingBenefits.Models.CreditRedemptionPolicy (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.BillingBenefits.Models.CreditRedemptionPolicy? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.BillingBenefits.Models.CreditRedemptionPolicy left, Azure.ResourceManager.BillingBenefits.Models.CreditRedemptionPolicy right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class CreditSourcePatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.BillingBenefits.Models.CreditSourcePatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.BillingBenefits.Models.CreditSourcePatch>
    {
        public CreditSourcePatch() { }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        protected virtual Azure.ResourceManager.BillingBenefits.Models.CreditSourcePatch JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.BillingBenefits.Models.CreditSourcePatch PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.BillingBenefits.Models.CreditSourcePatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.BillingBenefits.Models.CreditSourcePatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.BillingBenefits.Models.CreditSourcePatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.BillingBenefits.Models.CreditSourcePatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.BillingBenefits.Models.CreditSourcePatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.BillingBenefits.Models.CreditSourcePatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.BillingBenefits.Models.CreditSourcePatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct CreditStatus : System.IEquatable<Azure.ResourceManager.BillingBenefits.Models.CreditStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public CreditStatus(string value) { throw null; }
        public static Azure.ResourceManager.BillingBenefits.Models.CreditStatus Active { get { throw null; } }
        public static Azure.ResourceManager.BillingBenefits.Models.CreditStatus Canceled { get { throw null; } }
        public static Azure.ResourceManager.BillingBenefits.Models.CreditStatus Exhausted { get { throw null; } }
        public static Azure.ResourceManager.BillingBenefits.Models.CreditStatus Expired { get { throw null; } }
        public static Azure.ResourceManager.BillingBenefits.Models.CreditStatus Failed { get { throw null; } }
        public static Azure.ResourceManager.BillingBenefits.Models.CreditStatus NotStarted { get { throw null; } }
        public static Azure.ResourceManager.BillingBenefits.Models.CreditStatus Pending { get { throw null; } }
        public static Azure.ResourceManager.BillingBenefits.Models.CreditStatus Succeeded { get { throw null; } }
        public static Azure.ResourceManager.BillingBenefits.Models.CreditStatus Unknown { get { throw null; } }
        public bool Equals(Azure.ResourceManager.BillingBenefits.Models.CreditStatus other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.BillingBenefits.Models.CreditStatus left, Azure.ResourceManager.BillingBenefits.Models.CreditStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.BillingBenefits.Models.CreditStatus (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.BillingBenefits.Models.CreditStatus? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.BillingBenefits.Models.CreditStatus left, Azure.ResourceManager.BillingBenefits.Models.CreditStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class CreditsValidateModel : Azure.ResourceManager.BillingBenefits.Models.BenefitValidateModel, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.BillingBenefits.Models.CreditsValidateModel>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.BillingBenefits.Models.CreditsValidateModel>
    {
        public CreditsValidateModel() { }
        public Azure.Core.ResourceIdentifier BillingAccountResourceId { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier BillingProfileResourceId { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.BillingBenefits.Models.CreditBreakdownItem> Breakdown { get { throw null; } }
        public Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsCommitment Credit { get { throw null; } set { } }
        public string CustomerId { get { throw null; } }
        public System.DateTimeOffset? EndOn { get { throw null; } set { } }
        public string ETag { get { throw null; } }
        public Azure.Core.ResourceIdentifier Id { get { throw null; } }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public string Kind { get { throw null; } set { } }
        public Azure.Core.AzureLocation? Location { get { throw null; } set { } }
        public string ManagedBy { get { throw null; } set { } }
        public string Name { get { throw null; } }
        public Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsPlan Plan { get { throw null; } set { } }
        public Azure.ResourceManager.BillingBenefits.Models.CreditPolicies Policies { get { throw null; } set { } }
        public string ProductCode { get { throw null; } set { } }
        public Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.BillingBenefits.Models.CreditReason Reason { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier ResourceId { get { throw null; } set { } }
        public Azure.Core.ResourceType? ResourceType { get { throw null; } }
        public Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsSku Sku { get { throw null; } set { } }
        public System.DateTimeOffset? StartOn { get { throw null; } set { } }
        public Azure.ResourceManager.BillingBenefits.Models.CreditStatus? Status { get { throw null; } set { } }
        public Azure.ResourceManager.Models.SystemData SystemData { get { throw null; } }
        public string SystemId { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        protected override Azure.ResourceManager.BillingBenefits.Models.BenefitValidateModel JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.ResourceManager.BillingBenefits.Models.BenefitValidateModel PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.BillingBenefits.Models.CreditsValidateModel System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.BillingBenefits.Models.CreditsValidateModel>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.BillingBenefits.Models.CreditsValidateModel>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.BillingBenefits.Models.CreditsValidateModel System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.BillingBenefits.Models.CreditsValidateModel>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.BillingBenefits.Models.CreditsValidateModel>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.BillingBenefits.Models.CreditsValidateModel>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CustomPriceProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.BillingBenefits.Models.CustomPriceProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.BillingBenefits.Models.CustomPriceProperties>
    {
        public CustomPriceProperties(Azure.ResourceManager.BillingBenefits.Models.DiscountRuleType ruleType, string catalogId, System.Collections.Generic.IEnumerable<Azure.ResourceManager.BillingBenefits.Models.CatalogClaimsItem> catalogClaims, System.Collections.Generic.IEnumerable<Azure.ResourceManager.BillingBenefits.Models.MarketSetPricesItems> marketSetPrices) { }
        public string BillingPeriod { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.BillingBenefits.Models.CatalogClaimsItem> CatalogClaims { get { throw null; } }
        public string CatalogId { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.BillingBenefits.Models.MarketSetPricesItems> MarketSetPrices { get { throw null; } }
        public string MeterType { get { throw null; } set { } }
        public Azure.ResourceManager.BillingBenefits.Models.DiscountRuleType RuleType { get { throw null; } set { } }
        public string TermUnits { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.BillingBenefits.Models.CustomPriceProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.BillingBenefits.Models.CustomPriceProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.BillingBenefits.Models.CustomPriceProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.BillingBenefits.Models.CustomPriceProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.BillingBenefits.Models.CustomPriceProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.BillingBenefits.Models.CustomPriceProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.BillingBenefits.Models.CustomPriceProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.BillingBenefits.Models.CustomPriceProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.BillingBenefits.Models.CustomPriceProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DiscountAppliedScopeType : System.IEquatable<Azure.ResourceManager.BillingBenefits.Models.DiscountAppliedScopeType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DiscountAppliedScopeType(string value) { throw null; }
        public static Azure.ResourceManager.BillingBenefits.Models.DiscountAppliedScopeType BillingAccount { get { throw null; } }
        public static Azure.ResourceManager.BillingBenefits.Models.DiscountAppliedScopeType BillingProfile { get { throw null; } }
        public static Azure.ResourceManager.BillingBenefits.Models.DiscountAppliedScopeType Customer { get { throw null; } }
        public bool Equals(Azure.ResourceManager.BillingBenefits.Models.DiscountAppliedScopeType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.BillingBenefits.Models.DiscountAppliedScopeType left, Azure.ResourceManager.BillingBenefits.Models.DiscountAppliedScopeType right) { throw null; }
        public static implicit operator Azure.ResourceManager.BillingBenefits.Models.DiscountAppliedScopeType (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.BillingBenefits.Models.DiscountAppliedScopeType? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.BillingBenefits.Models.DiscountAppliedScopeType left, Azure.ResourceManager.BillingBenefits.Models.DiscountAppliedScopeType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DiscountCombinationRule : System.IEquatable<Azure.ResourceManager.BillingBenefits.Models.DiscountCombinationRule>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DiscountCombinationRule(string value) { throw null; }
        public static Azure.ResourceManager.BillingBenefits.Models.DiscountCombinationRule BestOf { get { throw null; } }
        public static Azure.ResourceManager.BillingBenefits.Models.DiscountCombinationRule Stackable { get { throw null; } }
        public bool Equals(Azure.ResourceManager.BillingBenefits.Models.DiscountCombinationRule other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.BillingBenefits.Models.DiscountCombinationRule left, Azure.ResourceManager.BillingBenefits.Models.DiscountCombinationRule right) { throw null; }
        public static implicit operator Azure.ResourceManager.BillingBenefits.Models.DiscountCombinationRule (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.BillingBenefits.Models.DiscountCombinationRule? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.BillingBenefits.Models.DiscountCombinationRule left, Azure.ResourceManager.BillingBenefits.Models.DiscountCombinationRule right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DiscountPatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.BillingBenefits.Models.DiscountPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.BillingBenefits.Models.DiscountPatch>
    {
        public DiscountPatch() { }
        public string DisplayName { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        protected virtual Azure.ResourceManager.BillingBenefits.Models.DiscountPatch JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.BillingBenefits.Models.DiscountPatch PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.BillingBenefits.Models.DiscountPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.BillingBenefits.Models.DiscountPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.BillingBenefits.Models.DiscountPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.BillingBenefits.Models.DiscountPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.BillingBenefits.Models.DiscountPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.BillingBenefits.Models.DiscountPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.BillingBenefits.Models.DiscountPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DiscountProvisioningState : System.IEquatable<Azure.ResourceManager.BillingBenefits.Models.DiscountProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DiscountProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.BillingBenefits.Models.DiscountProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.BillingBenefits.Models.DiscountProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.BillingBenefits.Models.DiscountProvisioningState Pending { get { throw null; } }
        public static Azure.ResourceManager.BillingBenefits.Models.DiscountProvisioningState Succeeded { get { throw null; } }
        public static Azure.ResourceManager.BillingBenefits.Models.DiscountProvisioningState Unknown { get { throw null; } }
        public bool Equals(Azure.ResourceManager.BillingBenefits.Models.DiscountProvisioningState other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.BillingBenefits.Models.DiscountProvisioningState left, Azure.ResourceManager.BillingBenefits.Models.DiscountProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.BillingBenefits.Models.DiscountProvisioningState (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.BillingBenefits.Models.DiscountProvisioningState? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.BillingBenefits.Models.DiscountProvisioningState left, Azure.ResourceManager.BillingBenefits.Models.DiscountProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DiscountRuleType : System.IEquatable<Azure.ResourceManager.BillingBenefits.Models.DiscountRuleType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DiscountRuleType(string value) { throw null; }
        public static Azure.ResourceManager.BillingBenefits.Models.DiscountRuleType FixedListPrice { get { throw null; } }
        public static Azure.ResourceManager.BillingBenefits.Models.DiscountRuleType FixedPriceLock { get { throw null; } }
        public static Azure.ResourceManager.BillingBenefits.Models.DiscountRuleType PriceCeiling { get { throw null; } }
        public bool Equals(Azure.ResourceManager.BillingBenefits.Models.DiscountRuleType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.BillingBenefits.Models.DiscountRuleType left, Azure.ResourceManager.BillingBenefits.Models.DiscountRuleType right) { throw null; }
        public static implicit operator Azure.ResourceManager.BillingBenefits.Models.DiscountRuleType (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.BillingBenefits.Models.DiscountRuleType? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.BillingBenefits.Models.DiscountRuleType left, Azure.ResourceManager.BillingBenefits.Models.DiscountRuleType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DiscountStatus : System.IEquatable<Azure.ResourceManager.BillingBenefits.Models.DiscountStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DiscountStatus(string value) { throw null; }
        public static Azure.ResourceManager.BillingBenefits.Models.DiscountStatus Active { get { throw null; } }
        public static Azure.ResourceManager.BillingBenefits.Models.DiscountStatus Canceled { get { throw null; } }
        public static Azure.ResourceManager.BillingBenefits.Models.DiscountStatus Expired { get { throw null; } }
        public static Azure.ResourceManager.BillingBenefits.Models.DiscountStatus Failed { get { throw null; } }
        public static Azure.ResourceManager.BillingBenefits.Models.DiscountStatus Pending { get { throw null; } }
        public bool Equals(Azure.ResourceManager.BillingBenefits.Models.DiscountStatus other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.BillingBenefits.Models.DiscountStatus left, Azure.ResourceManager.BillingBenefits.Models.DiscountStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.BillingBenefits.Models.DiscountStatus (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.BillingBenefits.Models.DiscountStatus? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.BillingBenefits.Models.DiscountStatus left, Azure.ResourceManager.BillingBenefits.Models.DiscountStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DiscountTypeCustomPrice : Azure.ResourceManager.BillingBenefits.Models.DiscountTypeProperties, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.BillingBenefits.Models.DiscountTypeCustomPrice>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.BillingBenefits.Models.DiscountTypeCustomPrice>
    {
        public DiscountTypeCustomPrice(Azure.ResourceManager.BillingBenefits.Models.ApplyDiscountOn applyDiscountOn) { }
        public Azure.ResourceManager.BillingBenefits.Models.CustomPriceProperties CustomPriceProperties { get { throw null; } set { } }
        public string ProductFamilyName { get { throw null; } set { } }
        public string ProductId { get { throw null; } set { } }
        public string SkuId { get { throw null; } set { } }
        protected override Azure.ResourceManager.BillingBenefits.Models.DiscountTypeProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.ResourceManager.BillingBenefits.Models.DiscountTypeProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.BillingBenefits.Models.DiscountTypeCustomPrice System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.BillingBenefits.Models.DiscountTypeCustomPrice>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.BillingBenefits.Models.DiscountTypeCustomPrice>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.BillingBenefits.Models.DiscountTypeCustomPrice System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.BillingBenefits.Models.DiscountTypeCustomPrice>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.BillingBenefits.Models.DiscountTypeCustomPrice>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.BillingBenefits.Models.DiscountTypeCustomPrice>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DiscountTypeCustomPriceMultiCurrency : Azure.ResourceManager.BillingBenefits.Models.DiscountTypeCustomPrice, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.BillingBenefits.Models.DiscountTypeCustomPriceMultiCurrency>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.BillingBenefits.Models.DiscountTypeCustomPriceMultiCurrency>
    {
        public DiscountTypeCustomPriceMultiCurrency(Azure.ResourceManager.BillingBenefits.Models.ApplyDiscountOn applyDiscountOn) : base (default(Azure.ResourceManager.BillingBenefits.Models.ApplyDiscountOn)) { }
        protected override Azure.ResourceManager.BillingBenefits.Models.DiscountTypeProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.ResourceManager.BillingBenefits.Models.DiscountTypeProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.BillingBenefits.Models.DiscountTypeCustomPriceMultiCurrency System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.BillingBenefits.Models.DiscountTypeCustomPriceMultiCurrency>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.BillingBenefits.Models.DiscountTypeCustomPriceMultiCurrency>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.BillingBenefits.Models.DiscountTypeCustomPriceMultiCurrency System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.BillingBenefits.Models.DiscountTypeCustomPriceMultiCurrency>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.BillingBenefits.Models.DiscountTypeCustomPriceMultiCurrency>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.BillingBenefits.Models.DiscountTypeCustomPriceMultiCurrency>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DiscountTypeProduct : Azure.ResourceManager.BillingBenefits.Models.DiscountTypeProperties, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.BillingBenefits.Models.DiscountTypeProduct>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.BillingBenefits.Models.DiscountTypeProduct>
    {
        public DiscountTypeProduct(Azure.ResourceManager.BillingBenefits.Models.ApplyDiscountOn applyDiscountOn) { }
        public string ProductFamilyName { get { throw null; } set { } }
        public string ProductId { get { throw null; } set { } }
        protected override Azure.ResourceManager.BillingBenefits.Models.DiscountTypeProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.ResourceManager.BillingBenefits.Models.DiscountTypeProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.BillingBenefits.Models.DiscountTypeProduct System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.BillingBenefits.Models.DiscountTypeProduct>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.BillingBenefits.Models.DiscountTypeProduct>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.BillingBenefits.Models.DiscountTypeProduct System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.BillingBenefits.Models.DiscountTypeProduct>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.BillingBenefits.Models.DiscountTypeProduct>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.BillingBenefits.Models.DiscountTypeProduct>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DiscountTypeProductFamily : Azure.ResourceManager.BillingBenefits.Models.DiscountTypeProperties, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.BillingBenefits.Models.DiscountTypeProductFamily>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.BillingBenefits.Models.DiscountTypeProductFamily>
    {
        public DiscountTypeProductFamily(Azure.ResourceManager.BillingBenefits.Models.ApplyDiscountOn applyDiscountOn) { }
        public string ProductFamilyName { get { throw null; } set { } }
        protected override Azure.ResourceManager.BillingBenefits.Models.DiscountTypeProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.ResourceManager.BillingBenefits.Models.DiscountTypeProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.BillingBenefits.Models.DiscountTypeProductFamily System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.BillingBenefits.Models.DiscountTypeProductFamily>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.BillingBenefits.Models.DiscountTypeProductFamily>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.BillingBenefits.Models.DiscountTypeProductFamily System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.BillingBenefits.Models.DiscountTypeProductFamily>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.BillingBenefits.Models.DiscountTypeProductFamily>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.BillingBenefits.Models.DiscountTypeProductFamily>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DiscountTypeProductSku : Azure.ResourceManager.BillingBenefits.Models.DiscountTypeProperties, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.BillingBenefits.Models.DiscountTypeProductSku>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.BillingBenefits.Models.DiscountTypeProductSku>
    {
        public DiscountTypeProductSku(Azure.ResourceManager.BillingBenefits.Models.ApplyDiscountOn applyDiscountOn) { }
        public string ProductFamilyName { get { throw null; } set { } }
        public string ProductId { get { throw null; } set { } }
        public string SkuId { get { throw null; } set { } }
        protected override Azure.ResourceManager.BillingBenefits.Models.DiscountTypeProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.ResourceManager.BillingBenefits.Models.DiscountTypeProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.BillingBenefits.Models.DiscountTypeProductSku System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.BillingBenefits.Models.DiscountTypeProductSku>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.BillingBenefits.Models.DiscountTypeProductSku>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.BillingBenefits.Models.DiscountTypeProductSku System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.BillingBenefits.Models.DiscountTypeProductSku>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.BillingBenefits.Models.DiscountTypeProductSku>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.BillingBenefits.Models.DiscountTypeProductSku>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class DiscountTypeProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.BillingBenefits.Models.DiscountTypeProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.BillingBenefits.Models.DiscountTypeProperties>
    {
        internal DiscountTypeProperties() { }
        public Azure.ResourceManager.BillingBenefits.Models.ApplyDiscountOn ApplyDiscountOn { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.BillingBenefits.Models.ConditionsItem> Conditions { get { throw null; } }
        public Azure.ResourceManager.BillingBenefits.Models.DiscountCombinationRule? DiscountCombinationRule { get { throw null; } set { } }
        public double? DiscountPercentage { get { throw null; } set { } }
        public Azure.ResourceManager.BillingBenefits.Models.PriceGuaranteeProperties PriceGuaranteeProperties { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.BillingBenefits.Models.DiscountTypeProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.BillingBenefits.Models.DiscountTypeProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.BillingBenefits.Models.DiscountTypeProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.BillingBenefits.Models.DiscountTypeProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.BillingBenefits.Models.DiscountTypeProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.BillingBenefits.Models.DiscountTypeProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.BillingBenefits.Models.DiscountTypeProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.BillingBenefits.Models.DiscountTypeProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.BillingBenefits.Models.DiscountTypeProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct EnablementMode : System.IEquatable<Azure.ResourceManager.BillingBenefits.Models.EnablementMode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public EnablementMode(string value) { throw null; }
        public static Azure.ResourceManager.BillingBenefits.Models.EnablementMode Disabled { get { throw null; } }
        public static Azure.ResourceManager.BillingBenefits.Models.EnablementMode Enabled { get { throw null; } }
        public static Azure.ResourceManager.BillingBenefits.Models.EnablementMode Unknown { get { throw null; } }
        public bool Equals(Azure.ResourceManager.BillingBenefits.Models.EnablementMode other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.BillingBenefits.Models.EnablementMode left, Azure.ResourceManager.BillingBenefits.Models.EnablementMode right) { throw null; }
        public static implicit operator Azure.ResourceManager.BillingBenefits.Models.EnablementMode (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.BillingBenefits.Models.EnablementMode? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.BillingBenefits.Models.EnablementMode left, Azure.ResourceManager.BillingBenefits.Models.EnablementMode right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class EntityTypeAffiliateDiscount : Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsDiscountProperties, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.BillingBenefits.Models.EntityTypeAffiliateDiscount>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.BillingBenefits.Models.EntityTypeAffiliateDiscount>
    {
        public EntityTypeAffiliateDiscount(string productCode, System.DateTimeOffset startOn) { }
        public System.DateTimeOffset? EndOn { get { throw null; } }
        public Azure.Core.ResourceIdentifier PrimaryResourceId { get { throw null; } }
        protected override Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsDiscountProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsDiscountProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.BillingBenefits.Models.EntityTypeAffiliateDiscount System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.BillingBenefits.Models.EntityTypeAffiliateDiscount>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.BillingBenefits.Models.EntityTypeAffiliateDiscount>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.BillingBenefits.Models.EntityTypeAffiliateDiscount System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.BillingBenefits.Models.EntityTypeAffiliateDiscount>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.BillingBenefits.Models.EntityTypeAffiliateDiscount>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.BillingBenefits.Models.EntityTypeAffiliateDiscount>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class EntityTypePrimaryDiscount : Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsDiscountProperties, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.BillingBenefits.Models.EntityTypePrimaryDiscount>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.BillingBenefits.Models.EntityTypePrimaryDiscount>
    {
        public EntityTypePrimaryDiscount(string productCode, System.DateTimeOffset startOn, System.DateTimeOffset endOn) { }
        public Azure.ResourceManager.BillingBenefits.Models.DiscountTypeProperties DiscountTypeProperties { get { throw null; } set { } }
        public System.DateTimeOffset EndOn { get { throw null; } set { } }
        protected override Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsDiscountProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsDiscountProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.BillingBenefits.Models.EntityTypePrimaryDiscount System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.BillingBenefits.Models.EntityTypePrimaryDiscount>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.BillingBenefits.Models.EntityTypePrimaryDiscount>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.BillingBenefits.Models.EntityTypePrimaryDiscount System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.BillingBenefits.Models.EntityTypePrimaryDiscount>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.BillingBenefits.Models.EntityTypePrimaryDiscount>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.BillingBenefits.Models.EntityTypePrimaryDiscount>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class FreeServicesPatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.BillingBenefits.Models.FreeServicesPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.BillingBenefits.Models.FreeServicesPatch>
    {
        public FreeServicesPatch() { }
        public System.DateTimeOffset? EndOn { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        protected virtual Azure.ResourceManager.BillingBenefits.Models.FreeServicesPatch JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.BillingBenefits.Models.FreeServicesPatch PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.BillingBenefits.Models.FreeServicesPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.BillingBenefits.Models.FreeServicesPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.BillingBenefits.Models.FreeServicesPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.BillingBenefits.Models.FreeServicesPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.BillingBenefits.Models.FreeServicesPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.BillingBenefits.Models.FreeServicesPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.BillingBenefits.Models.FreeServicesPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct FreeServicesStatus : System.IEquatable<Azure.ResourceManager.BillingBenefits.Models.FreeServicesStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public FreeServicesStatus(string value) { throw null; }
        public static Azure.ResourceManager.BillingBenefits.Models.FreeServicesStatus Active { get { throw null; } }
        public static Azure.ResourceManager.BillingBenefits.Models.FreeServicesStatus Canceled { get { throw null; } }
        public static Azure.ResourceManager.BillingBenefits.Models.FreeServicesStatus Completed { get { throw null; } }
        public static Azure.ResourceManager.BillingBenefits.Models.FreeServicesStatus Pending { get { throw null; } }
        public static Azure.ResourceManager.BillingBenefits.Models.FreeServicesStatus Unknown { get { throw null; } }
        public bool Equals(Azure.ResourceManager.BillingBenefits.Models.FreeServicesStatus other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.BillingBenefits.Models.FreeServicesStatus left, Azure.ResourceManager.BillingBenefits.Models.FreeServicesStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.BillingBenefits.Models.FreeServicesStatus (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.BillingBenefits.Models.FreeServicesStatus? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.BillingBenefits.Models.FreeServicesStatus left, Azure.ResourceManager.BillingBenefits.Models.FreeServicesStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MaccEntityType : System.IEquatable<Azure.ResourceManager.BillingBenefits.Models.MaccEntityType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MaccEntityType(string value) { throw null; }
        public static Azure.ResourceManager.BillingBenefits.Models.MaccEntityType Contributor { get { throw null; } }
        public static Azure.ResourceManager.BillingBenefits.Models.MaccEntityType Primary { get { throw null; } }
        public bool Equals(Azure.ResourceManager.BillingBenefits.Models.MaccEntityType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.BillingBenefits.Models.MaccEntityType left, Azure.ResourceManager.BillingBenefits.Models.MaccEntityType right) { throw null; }
        public static implicit operator Azure.ResourceManager.BillingBenefits.Models.MaccEntityType (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.BillingBenefits.Models.MaccEntityType? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.BillingBenefits.Models.MaccEntityType left, Azure.ResourceManager.BillingBenefits.Models.MaccEntityType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class MaccMilestone : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.BillingBenefits.Models.MaccMilestone>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.BillingBenefits.Models.MaccMilestone>
    {
        public MaccMilestone() { }
        public Azure.ResourceManager.BillingBenefits.Models.EnablementMode? AutomaticShortfall { get { throw null; } set { } }
        public Azure.ResourceManager.BillingBenefits.Models.AutomaticShortfallSuppressReason AutomaticShortfallSuppressReason { get { throw null; } set { } }
        public Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsPrice Commitment { get { throw null; } set { } }
        public System.DateTimeOffset? EndOn { get { throw null; } set { } }
        public string MilestoneId { get { throw null; } set { } }
        public Azure.ResourceManager.BillingBenefits.Models.Shortfall Shortfall { get { throw null; } set { } }
        public Azure.ResourceManager.BillingBenefits.Models.MaccMilestoneStatus? Status { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.BillingBenefits.Models.MaccMilestone JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.BillingBenefits.Models.MaccMilestone PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.BillingBenefits.Models.MaccMilestone System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.BillingBenefits.Models.MaccMilestone>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.BillingBenefits.Models.MaccMilestone>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.BillingBenefits.Models.MaccMilestone System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.BillingBenefits.Models.MaccMilestone>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.BillingBenefits.Models.MaccMilestone>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.BillingBenefits.Models.MaccMilestone>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MaccMilestoneStatus : System.IEquatable<Azure.ResourceManager.BillingBenefits.Models.MaccMilestoneStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MaccMilestoneStatus(string value) { throw null; }
        public static Azure.ResourceManager.BillingBenefits.Models.MaccMilestoneStatus Active { get { throw null; } }
        public static Azure.ResourceManager.BillingBenefits.Models.MaccMilestoneStatus Canceled { get { throw null; } }
        public static Azure.ResourceManager.BillingBenefits.Models.MaccMilestoneStatus Completed { get { throw null; } }
        public static Azure.ResourceManager.BillingBenefits.Models.MaccMilestoneStatus Failed { get { throw null; } }
        public static Azure.ResourceManager.BillingBenefits.Models.MaccMilestoneStatus Pending { get { throw null; } }
        public static Azure.ResourceManager.BillingBenefits.Models.MaccMilestoneStatus PendingSettlement { get { throw null; } }
        public static Azure.ResourceManager.BillingBenefits.Models.MaccMilestoneStatus Removed { get { throw null; } }
        public static Azure.ResourceManager.BillingBenefits.Models.MaccMilestoneStatus Scheduled { get { throw null; } }
        public static Azure.ResourceManager.BillingBenefits.Models.MaccMilestoneStatus ShortfallCharged { get { throw null; } }
        public static Azure.ResourceManager.BillingBenefits.Models.MaccMilestoneStatus ShortfallWaived { get { throw null; } }
        public static Azure.ResourceManager.BillingBenefits.Models.MaccMilestoneStatus Unknown { get { throw null; } }
        public bool Equals(Azure.ResourceManager.BillingBenefits.Models.MaccMilestoneStatus other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.BillingBenefits.Models.MaccMilestoneStatus left, Azure.ResourceManager.BillingBenefits.Models.MaccMilestoneStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.BillingBenefits.Models.MaccMilestoneStatus (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.BillingBenefits.Models.MaccMilestoneStatus? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.BillingBenefits.Models.MaccMilestoneStatus left, Azure.ResourceManager.BillingBenefits.Models.MaccMilestoneStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class MaccPatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.BillingBenefits.Models.MaccPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.BillingBenefits.Models.MaccPatch>
    {
        public MaccPatch() { }
        public Azure.ResourceManager.BillingBenefits.Models.EnablementMode? AutomaticShortfall { get { throw null; } set { } }
        public Azure.ResourceManager.BillingBenefits.Models.AutomaticShortfallSuppressReason AutomaticShortfallSuppressReason { get { throw null; } set { } }
        public Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsCommitment Commitment { get { throw null; } set { } }
        public string DisplayName { get { throw null; } set { } }
        public System.DateTimeOffset? EndOn { get { throw null; } set { } }
        public bool? IsAllowContributors { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.BillingBenefits.Models.MaccMilestone> Milestones { get { throw null; } }
        public Azure.Core.ResourceIdentifier PrimaryBillingAccountResourceId { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier PrimaryResourceId { get { throw null; } set { } }
        public Azure.ResourceManager.BillingBenefits.Models.MaccMilestoneStatus? Status { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        protected virtual Azure.ResourceManager.BillingBenefits.Models.MaccPatch JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.BillingBenefits.Models.MaccPatch PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.BillingBenefits.Models.MaccPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.BillingBenefits.Models.MaccPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.BillingBenefits.Models.MaccPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.BillingBenefits.Models.MaccPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.BillingBenefits.Models.MaccPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.BillingBenefits.Models.MaccPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.BillingBenefits.Models.MaccPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MaccStatus : System.IEquatable<Azure.ResourceManager.BillingBenefits.Models.MaccStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MaccStatus(string value) { throw null; }
        public static Azure.ResourceManager.BillingBenefits.Models.MaccStatus Active { get { throw null; } }
        public static Azure.ResourceManager.BillingBenefits.Models.MaccStatus Canceled { get { throw null; } }
        public static Azure.ResourceManager.BillingBenefits.Models.MaccStatus Completed { get { throw null; } }
        public static Azure.ResourceManager.BillingBenefits.Models.MaccStatus Failed { get { throw null; } }
        public static Azure.ResourceManager.BillingBenefits.Models.MaccStatus Pending { get { throw null; } }
        public static Azure.ResourceManager.BillingBenefits.Models.MaccStatus PendingSettlement { get { throw null; } }
        public static Azure.ResourceManager.BillingBenefits.Models.MaccStatus Scheduled { get { throw null; } }
        public static Azure.ResourceManager.BillingBenefits.Models.MaccStatus ShortfallCharged { get { throw null; } }
        public static Azure.ResourceManager.BillingBenefits.Models.MaccStatus ShortfallWaived { get { throw null; } }
        public static Azure.ResourceManager.BillingBenefits.Models.MaccStatus Stopped { get { throw null; } }
        public static Azure.ResourceManager.BillingBenefits.Models.MaccStatus Unknown { get { throw null; } }
        public bool Equals(Azure.ResourceManager.BillingBenefits.Models.MaccStatus other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.BillingBenefits.Models.MaccStatus left, Azure.ResourceManager.BillingBenefits.Models.MaccStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.BillingBenefits.Models.MaccStatus (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.BillingBenefits.Models.MaccStatus? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.BillingBenefits.Models.MaccStatus left, Azure.ResourceManager.BillingBenefits.Models.MaccStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class MaccValidateModel : Azure.ResourceManager.BillingBenefits.Models.BenefitValidateModel, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.BillingBenefits.Models.MaccValidateModel>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.BillingBenefits.Models.MaccValidateModel>
    {
        public MaccValidateModel() { }
        public Azure.ResourceManager.BillingBenefits.Models.EnablementMode? AutomaticShortfall { get { throw null; } set { } }
        public Azure.ResourceManager.BillingBenefits.Models.AutomaticShortfallSuppressReason AutomaticShortfallSuppressReason { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier BillingAccountResourceId { get { throw null; } set { } }
        public Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsCommitment Commitment { get { throw null; } set { } }
        public string DisplayName { get { throw null; } set { } }
        public System.DateTimeOffset? EndOn { get { throw null; } set { } }
        [System.ObsoleteAttribute("This property is obsolete and will be removed in a future release. Use MaccEntityType instead.")]
        public Azure.ResourceManager.BillingBenefits.Models.MaccEntityType EntityType { get { throw null; } set { } }
        public bool? IsAllowContributors { get { throw null; } set { } }
        public Azure.ResourceManager.BillingBenefits.Models.MaccEntityType? MaccEntityType { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.BillingBenefits.Models.MaccMilestone> Milestones { get { throw null; } }
        public Azure.Core.ResourceIdentifier PrimaryBillingAccountResourceId { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier PrimaryResourceId { get { throw null; } set { } }
        public string ProductCode { get { throw null; } set { } }
        public string ProvisioningState { get { throw null; } }
        public Azure.Core.ResourceIdentifier ResourceId { get { throw null; } set { } }
        public Azure.ResourceManager.BillingBenefits.Models.Shortfall Shortfall { get { throw null; } set { } }
        public System.DateTimeOffset? StartOn { get { throw null; } set { } }
        public Azure.ResourceManager.BillingBenefits.Models.MaccStatus? Status { get { throw null; } set { } }
        public string SystemId { get { throw null; } set { } }
        protected override Azure.ResourceManager.BillingBenefits.Models.BenefitValidateModel JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.ResourceManager.BillingBenefits.Models.BenefitValidateModel PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.BillingBenefits.Models.MaccValidateModel System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.BillingBenefits.Models.MaccValidateModel>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.BillingBenefits.Models.MaccValidateModel>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.BillingBenefits.Models.MaccValidateModel System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.BillingBenefits.Models.MaccValidateModel>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.BillingBenefits.Models.MaccValidateModel>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.BillingBenefits.Models.MaccValidateModel>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MarketSetPricesItems : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.BillingBenefits.Models.MarketSetPricesItems>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.BillingBenefits.Models.MarketSetPricesItems>
    {
        public MarketSetPricesItems(System.Collections.Generic.IEnumerable<string> markets, float value, string currency) { }
        public string Currency { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Markets { get { throw null; } }
        public float Value { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.BillingBenefits.Models.MarketSetPricesItems JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.BillingBenefits.Models.MarketSetPricesItems PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.BillingBenefits.Models.MarketSetPricesItems System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.BillingBenefits.Models.MarketSetPricesItems>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.BillingBenefits.Models.MarketSetPricesItems>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.BillingBenefits.Models.MarketSetPricesItems System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.BillingBenefits.Models.MarketSetPricesItems>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.BillingBenefits.Models.MarketSetPricesItems>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.BillingBenefits.Models.MarketSetPricesItems>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MilestoneStatus : System.IEquatable<Azure.ResourceManager.BillingBenefits.Models.MilestoneStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MilestoneStatus(string value) { throw null; }
        public static Azure.ResourceManager.BillingBenefits.Models.MilestoneStatus Active { get { throw null; } }
        public static Azure.ResourceManager.BillingBenefits.Models.MilestoneStatus Canceled { get { throw null; } }
        public static Azure.ResourceManager.BillingBenefits.Models.MilestoneStatus Completed { get { throw null; } }
        public static Azure.ResourceManager.BillingBenefits.Models.MilestoneStatus Failed { get { throw null; } }
        public static Azure.ResourceManager.BillingBenefits.Models.MilestoneStatus Missed { get { throw null; } }
        public static Azure.ResourceManager.BillingBenefits.Models.MilestoneStatus Pending { get { throw null; } }
        public static Azure.ResourceManager.BillingBenefits.Models.MilestoneStatus PendingSettlement { get { throw null; } }
        public static Azure.ResourceManager.BillingBenefits.Models.MilestoneStatus Removed { get { throw null; } }
        public static Azure.ResourceManager.BillingBenefits.Models.MilestoneStatus Scheduled { get { throw null; } }
        public static Azure.ResourceManager.BillingBenefits.Models.MilestoneStatus Unknown { get { throw null; } }
        public bool Equals(Azure.ResourceManager.BillingBenefits.Models.MilestoneStatus other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.BillingBenefits.Models.MilestoneStatus left, Azure.ResourceManager.BillingBenefits.Models.MilestoneStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.BillingBenefits.Models.MilestoneStatus (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.BillingBenefits.Models.MilestoneStatus? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.BillingBenefits.Models.MilestoneStatus left, Azure.ResourceManager.BillingBenefits.Models.MilestoneStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class PriceGuaranteeProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.BillingBenefits.Models.PriceGuaranteeProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.BillingBenefits.Models.PriceGuaranteeProperties>
    {
        public PriceGuaranteeProperties() { }
        public System.DateTimeOffset? PriceGuaranteeOn { get { throw null; } set { } }
        public Azure.ResourceManager.BillingBenefits.Models.PricingPolicy? PricingPolicy { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.BillingBenefits.Models.PriceGuaranteeProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.BillingBenefits.Models.PriceGuaranteeProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.BillingBenefits.Models.PriceGuaranteeProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.BillingBenefits.Models.PriceGuaranteeProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.BillingBenefits.Models.PriceGuaranteeProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.BillingBenefits.Models.PriceGuaranteeProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.BillingBenefits.Models.PriceGuaranteeProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.BillingBenefits.Models.PriceGuaranteeProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.BillingBenefits.Models.PriceGuaranteeProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PricingPolicy : System.IEquatable<Azure.ResourceManager.BillingBenefits.Models.PricingPolicy>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PricingPolicy(string value) { throw null; }
        public static Azure.ResourceManager.BillingBenefits.Models.PricingPolicy Locked { get { throw null; } }
        public static Azure.ResourceManager.BillingBenefits.Models.PricingPolicy Protected { get { throw null; } }
        public bool Equals(Azure.ResourceManager.BillingBenefits.Models.PricingPolicy other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.BillingBenefits.Models.PricingPolicy left, Azure.ResourceManager.BillingBenefits.Models.PricingPolicy right) { throw null; }
        public static implicit operator Azure.ResourceManager.BillingBenefits.Models.PricingPolicy (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.BillingBenefits.Models.PricingPolicy? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.BillingBenefits.Models.PricingPolicy left, Azure.ResourceManager.BillingBenefits.Models.PricingPolicy right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class PrimaryConditionalCreditProperties : Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsConditionalCreditProperties, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.BillingBenefits.Models.PrimaryConditionalCreditProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.BillingBenefits.Models.PrimaryConditionalCreditProperties>
    {
        public PrimaryConditionalCreditProperties() { }
        public Azure.ResourceManager.BillingBenefits.Models.EnablementMode? AllowContributors { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.BillingBenefits.Models.ConditionalCreditMilestone> Milestones { get { throw null; } }
        public string SystemId { get { throw null; } set { } }
        protected override Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsConditionalCreditProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsConditionalCreditProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.BillingBenefits.Models.PrimaryConditionalCreditProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.BillingBenefits.Models.PrimaryConditionalCreditProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.BillingBenefits.Models.PrimaryConditionalCreditProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.BillingBenefits.Models.PrimaryConditionalCreditProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.BillingBenefits.Models.PrimaryConditionalCreditProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.BillingBenefits.Models.PrimaryConditionalCreditProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.BillingBenefits.Models.PrimaryConditionalCreditProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SavingsPlanOrderPaymentDetail : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.BillingBenefits.Models.SavingsPlanOrderPaymentDetail>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.BillingBenefits.Models.SavingsPlanOrderPaymentDetail>
    {
        public SavingsPlanOrderPaymentDetail() { }
        public string BillingAccount { get { throw null; } set { } }
        public Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsPrice BillingCurrencyTotal { get { throw null; } set { } }
        public System.DateTimeOffset? DueOn { get { throw null; } set { } }
        public Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsExtendedStatusInfo ExtendedStatusInfo { get { throw null; } }
        public System.DateTimeOffset? PayOn { get { throw null; } set { } }
        public Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsPrice PricingCurrencyTotal { get { throw null; } set { } }
        public Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsPaymentStatus? Status { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.BillingBenefits.Models.SavingsPlanOrderPaymentDetail JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.BillingBenefits.Models.SavingsPlanOrderPaymentDetail PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.BillingBenefits.Models.SavingsPlanOrderPaymentDetail System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.BillingBenefits.Models.SavingsPlanOrderPaymentDetail>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.BillingBenefits.Models.SavingsPlanOrderPaymentDetail>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.BillingBenefits.Models.SavingsPlanOrderPaymentDetail System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.BillingBenefits.Models.SavingsPlanOrderPaymentDetail>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.BillingBenefits.Models.SavingsPlanOrderPaymentDetail>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.BillingBenefits.Models.SavingsPlanOrderPaymentDetail>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SavingsPlanUpdateValidateContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.BillingBenefits.Models.SavingsPlanUpdateValidateContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.BillingBenefits.Models.SavingsPlanUpdateValidateContent>
    {
        public SavingsPlanUpdateValidateContent() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsSavingsPlanPatchProperties> Benefits { get { throw null; } }
        protected virtual Azure.ResourceManager.BillingBenefits.Models.SavingsPlanUpdateValidateContent JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.BillingBenefits.Models.SavingsPlanUpdateValidateContent PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.BillingBenefits.Models.SavingsPlanUpdateValidateContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.BillingBenefits.Models.SavingsPlanUpdateValidateContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.BillingBenefits.Models.SavingsPlanUpdateValidateContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.BillingBenefits.Models.SavingsPlanUpdateValidateContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.BillingBenefits.Models.SavingsPlanUpdateValidateContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.BillingBenefits.Models.SavingsPlanUpdateValidateContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.BillingBenefits.Models.SavingsPlanUpdateValidateContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SavingsPlanValidateModel : Azure.ResourceManager.BillingBenefits.Models.BenefitValidateModel, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.BillingBenefits.Models.SavingsPlanValidateModel>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.BillingBenefits.Models.SavingsPlanValidateModel>
    {
        public SavingsPlanValidateModel() { }
        public Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsAppliedScopeProperties AppliedScopeProperties { get { throw null; } set { } }
        public Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsAppliedScopeType? AppliedScopeType { get { throw null; } set { } }
        public Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsBillingPlan? BillingPlan { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier BillingScopeId { get { throw null; } set { } }
        public Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsCommitment Commitment { get { throw null; } set { } }
        public string DisplayName { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier Id { get { throw null; } }
        public bool? IsRenewed { get { throw null; } set { } }
        public string Kind { get { throw null; } set { } }
        public string Name { get { throw null; } }
        public Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.Core.ResourceIdentifier SavingsPlanOrderId { get { throw null; } }
        public string SkuName { get { throw null; } }
        public Azure.ResourceManager.Models.SystemData SystemData { get { throw null; } }
        public Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsTerm? Term { get { throw null; } set { } }
        public Azure.Core.ResourceType? Type { get { throw null; } }
        protected override Azure.ResourceManager.BillingBenefits.Models.BenefitValidateModel JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.ResourceManager.BillingBenefits.Models.BenefitValidateModel PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.BillingBenefits.Models.SavingsPlanValidateModel System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.BillingBenefits.Models.SavingsPlanValidateModel>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.BillingBenefits.Models.SavingsPlanValidateModel>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.BillingBenefits.Models.SavingsPlanValidateModel System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.BillingBenefits.Models.SavingsPlanValidateModel>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.BillingBenefits.Models.SavingsPlanValidateModel>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.BillingBenefits.Models.SavingsPlanValidateModel>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SavingsPlanValidateResponse : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.BillingBenefits.Models.SavingsPlanValidateResponse>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.BillingBenefits.Models.SavingsPlanValidateResponse>
    {
        internal SavingsPlanValidateResponse() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.BillingBenefits.Models.SavingsPlanValidateResult> Benefits { get { throw null; } }
        public string NextLink { get { throw null; } }
        protected virtual Azure.ResourceManager.BillingBenefits.Models.SavingsPlanValidateResponse JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.BillingBenefits.Models.SavingsPlanValidateResponse PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.BillingBenefits.Models.SavingsPlanValidateResponse System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.BillingBenefits.Models.SavingsPlanValidateResponse>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.BillingBenefits.Models.SavingsPlanValidateResponse>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.BillingBenefits.Models.SavingsPlanValidateResponse System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.BillingBenefits.Models.SavingsPlanValidateResponse>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.BillingBenefits.Models.SavingsPlanValidateResponse>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.BillingBenefits.Models.SavingsPlanValidateResponse>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SavingsPlanValidateResult : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.BillingBenefits.Models.SavingsPlanValidateResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.BillingBenefits.Models.SavingsPlanValidateResult>
    {
        internal SavingsPlanValidateResult() { }
        public bool? IsValid { get { throw null; } }
        public string Reason { get { throw null; } }
        public string ReasonCode { get { throw null; } }
        protected virtual Azure.ResourceManager.BillingBenefits.Models.SavingsPlanValidateResult JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.BillingBenefits.Models.SavingsPlanValidateResult PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.BillingBenefits.Models.SavingsPlanValidateResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.BillingBenefits.Models.SavingsPlanValidateResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.BillingBenefits.Models.SavingsPlanValidateResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.BillingBenefits.Models.SavingsPlanValidateResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.BillingBenefits.Models.SavingsPlanValidateResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.BillingBenefits.Models.SavingsPlanValidateResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.BillingBenefits.Models.SavingsPlanValidateResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SellerResourceListRequest : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.BillingBenefits.Models.SellerResourceListRequest>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.BillingBenefits.Models.SellerResourceListRequest>
    {
        public SellerResourceListRequest() { }
        public Azure.Core.ResourceIdentifier BillingAccountResourceId { get { throw null; } }
        public string Filter { get { throw null; } set { } }
        public bool? IncludeContributors { get { throw null; } set { } }
        public bool? IncludeMilestones { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier PrimaryResourceId { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.BillingBenefits.Models.SellerResourceListRequest JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.BillingBenefits.Models.SellerResourceListRequest PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.BillingBenefits.Models.SellerResourceListRequest System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.BillingBenefits.Models.SellerResourceListRequest>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.BillingBenefits.Models.SellerResourceListRequest>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.BillingBenefits.Models.SellerResourceListRequest System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.BillingBenefits.Models.SellerResourceListRequest>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.BillingBenefits.Models.SellerResourceListRequest>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.BillingBenefits.Models.SellerResourceListRequest>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class Shortfall : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.BillingBenefits.Models.Shortfall>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.BillingBenefits.Models.Shortfall>
    {
        public Shortfall() { }
        public float? BalanceVersion { get { throw null; } set { } }
        public Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsCommitment Charge { get { throw null; } set { } }
        public System.DateTimeOffset? EndOn { get { throw null; } set { } }
        public string ProductCode { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier ResourceId { get { throw null; } set { } }
        public System.DateTimeOffset? StartOn { get { throw null; } set { } }
        public string SystemId { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.BillingBenefits.Models.Shortfall JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.BillingBenefits.Models.Shortfall PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.BillingBenefits.Models.Shortfall System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.BillingBenefits.Models.Shortfall>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.BillingBenefits.Models.Shortfall>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.BillingBenefits.Models.Shortfall System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.BillingBenefits.Models.Shortfall>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.BillingBenefits.Models.Shortfall>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.BillingBenefits.Models.Shortfall>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
}
