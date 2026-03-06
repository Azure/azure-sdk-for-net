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
        public static Azure.Pageable<Azure.ResourceManager.BillingBenefits.MaccResource> GetAll(this Azure.ResourceManager.Resources.TenantResource tenantResource, Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsSellerResourceListContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.BillingBenefits.SavingsPlanModelResource> GetAll(this Azure.ResourceManager.Resources.TenantResource tenantResource, string filter = null, string orderby = null, string refreshSummary = null, float? skiptoken = default(float?), string selectedState = null, float? take = default(float?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.BillingBenefits.Models.ApplicableMacc> GetAllAsync(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.BillingBenefits.MaccResource> GetAllAsync(this Azure.ResourceManager.Resources.TenantResource tenantResource, Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsSellerResourceListContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.BillingBenefits.SavingsPlanModelResource> GetAllAsync(this Azure.ResourceManager.Resources.TenantResource tenantResource, string filter = null, string orderby = null, string refreshSummary = null, float? skiptoken = default(float?), string selectedState = null, float? take = default(float?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.BillingBenefits.FreeServicesCollection GetAllFreeServices(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.BillingBenefits.CreditResource> GetApplicable(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.BillingBenefits.CreditResource> GetApplicableAsync(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.BillingBenefits.ConditionalCreditResource> GetApplicableConditionalCredits(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.BillingBenefits.ConditionalCreditResource> GetApplicableConditionalCreditsAsync(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.BillingBenefits.DiscountResource> GetApplicableDiscounts(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.BillingBenefits.DiscountResource> GetApplicableDiscountsAsync(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.BillingBenefits.ConditionalCreditResource> GetConditionalCredit(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string conditionalCreditName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.BillingBenefits.ConditionalCreditResource>> GetConditionalCreditAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string conditionalCreditName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
        public static Azure.ResourceManager.BillingBenefits.DiscountResource GetDiscountResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.BillingBenefits.DiscountCollection GetDiscounts(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.BillingBenefits.DiscountResource> GetDiscounts(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.BillingBenefits.DiscountResource> GetDiscountsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.BillingBenefits.FreeServicesResource> GetFreeServices(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string freeServiceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.BillingBenefits.FreeServicesResource> GetFreeServices(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.BillingBenefits.FreeServicesResource>> GetFreeServicesAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string freeServiceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.BillingBenefits.FreeServicesResource> GetFreeServicesAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.BillingBenefits.FreeServicesResource GetFreeServicesResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.BillingBenefits.ConditionalCreditContributorResource> GetFromApplicableConditionalCredit(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, string systemId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.BillingBenefits.ConditionalCreditContributorResource> GetFromApplicableConditionalCreditAsync(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, string systemId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.BillingBenefits.ContributorResource> GetFromApplicableMacc(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, string systemId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.BillingBenefits.ContributorResource> GetFromApplicableMaccAsync(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, string systemId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.BillingBenefits.MaccResource> GetMacc(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string maccName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.BillingBenefits.MaccResource>> GetMaccAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string maccName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.BillingBenefits.MaccResource GetMaccResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.BillingBenefits.MaccCollection GetMaccs(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.BillingBenefits.MaccResource> GetMaccs(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.BillingBenefits.MaccResource> GetMaccsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.BillingBenefits.ReservationOrderAliasResponseResource> GetReservationOrderAliasResponse(this Azure.ResourceManager.Resources.TenantResource tenantResource, string reservationOrderAliasName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.BillingBenefits.ReservationOrderAliasResponseResource>> GetReservationOrderAliasResponseAsync(this Azure.ResourceManager.Resources.TenantResource tenantResource, string reservationOrderAliasName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.BillingBenefits.ReservationOrderAliasResponseResource GetReservationOrderAliasResponseResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.BillingBenefits.ReservationOrderAliasResponseCollection GetReservationOrderAliasResponses(this Azure.ResourceManager.Resources.TenantResource tenantResource) { throw null; }
        public static Azure.ResourceManager.BillingBenefits.SavingsPlanModelResource GetSavingsPlanModelResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.BillingBenefits.SavingsPlanOrderAliasModelResource> GetSavingsPlanOrderAliasModel(this Azure.ResourceManager.Resources.TenantResource tenantResource, string savingsPlanOrderAliasName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.BillingBenefits.SavingsPlanOrderAliasModelResource>> GetSavingsPlanOrderAliasModelAsync(this Azure.ResourceManager.Resources.TenantResource tenantResource, string savingsPlanOrderAliasName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.BillingBenefits.SavingsPlanOrderAliasModelResource GetSavingsPlanOrderAliasModelResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.BillingBenefits.SavingsPlanOrderAliasModelCollection GetSavingsPlanOrderAliasModels(this Azure.ResourceManager.Resources.TenantResource tenantResource) { throw null; }
        public static Azure.Response<Azure.ResourceManager.BillingBenefits.SavingsPlanOrderModelResource> GetSavingsPlanOrderModel(this Azure.ResourceManager.Resources.TenantResource tenantResource, string savingsPlanOrderId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.BillingBenefits.SavingsPlanOrderModelResource>> GetSavingsPlanOrderModelAsync(this Azure.ResourceManager.Resources.TenantResource tenantResource, string savingsPlanOrderId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.BillingBenefits.SavingsPlanOrderModelResource GetSavingsPlanOrderModelResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.BillingBenefits.SavingsPlanOrderModelCollection GetSavingsPlanOrderModels(this Azure.ResourceManager.Resources.TenantResource tenantResource) { throw null; }
        public static Azure.Response<Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsBenefitValidateResult> Validate(this Azure.ResourceManager.Resources.TenantResource tenantResource, Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsBenefitValidateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsBenefitValidateResult>> ValidateAsync(this Azure.ResourceManager.Resources.TenantResource tenantResource, Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsBenefitValidateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
        public Azure.ResourceManager.BillingBenefits.Models.ConditionalCreditProperties Properties { get { throw null; } set { } }
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
        public bool? AllowContributors { get { throw null; } }
        public Azure.ResourceManager.BillingBenefits.Models.EnablementMode? AutomaticShortfall { get { throw null; } }
        public Azure.ResourceManager.BillingBenefits.Models.AutomaticShortfallSuppressReason AutomaticShortfallSuppressReason { get { throw null; } }
        public Azure.Core.ResourceIdentifier BillingAccountResourceId { get { throw null; } }
        public Azure.ResourceManager.BillingBenefits.Models.Commitment Commitment { get { throw null; } }
        public string DisplayName { get { throw null; } }
        public System.DateTimeOffset? EndOn { get { throw null; } }
        public Azure.ResourceManager.BillingBenefits.Models.MaccEntityType EntityType { get { throw null; } }
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
        public Azure.ResourceManager.BillingBenefits.Models.Commitment Credit { get { throw null; } set { } }
        public string CustomerId { get { throw null; } }
        public System.DateTimeOffset? EndOn { get { throw null; } set { } }
        public string ETag { get { throw null; } }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public string Kind { get { throw null; } set { } }
        public string ManagedBy { get { throw null; } set { } }
        public Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsPlan Plan { get { throw null; } set { } }
        public Azure.ResourceManager.BillingBenefits.Models.CreditPolicies Policies { get { throw null; } set { } }
        public string ProductCode { get { throw null; } set { } }
        public Azure.ResourceManager.BillingBenefits.Models.ProvisioningState? ProvisioningState { get { throw null; } }
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
        public Azure.ResourceManager.BillingBenefits.Models.Commitment Credit { get { throw null; } set { } }
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
        public Azure.ResourceManager.BillingBenefits.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public string Kind { get { throw null; } set { } }
        public string ManagedBy { get { throw null; } set { } }
        public Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsPlan Plan { get { throw null; } set { } }
        public Azure.ResourceManager.BillingBenefits.Models.DiscountProperties Properties { get { throw null; } set { } }
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
        public bool? AllowContributors { get { throw null; } set { } }
        public Azure.ResourceManager.BillingBenefits.Models.EnablementMode? AutomaticShortfall { get { throw null; } set { } }
        public Azure.ResourceManager.BillingBenefits.Models.AutomaticShortfallSuppressReason AutomaticShortfallSuppressReason { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier BillingAccountResourceId { get { throw null; } set { } }
        public Azure.ResourceManager.BillingBenefits.Models.Commitment Commitment { get { throw null; } set { } }
        public string DisplayName { get { throw null; } set { } }
        public System.DateTimeOffset? EndOn { get { throw null; } set { } }
        public Azure.ResourceManager.BillingBenefits.Models.MaccEntityType EntityType { get { throw null; } set { } }
        public string ETag { get { throw null; } }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public string Kind { get { throw null; } set { } }
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
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.BillingBenefits.MaccResource> ChargeShortfall(Azure.WaitUntil waitUntil, Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsChargeShortfallContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.BillingBenefits.MaccResource>> ChargeShortfallAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsChargeShortfallContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
    public partial class ReservationOrderAliasResponseCollection : Azure.ResourceManager.ArmCollection
    {
        protected ReservationOrderAliasResponseCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.BillingBenefits.ReservationOrderAliasResponseResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string reservationOrderAliasName, Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsReservationOrderAliasContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.BillingBenefits.ReservationOrderAliasResponseResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string reservationOrderAliasName, Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsReservationOrderAliasContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string reservationOrderAliasName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string reservationOrderAliasName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.BillingBenefits.ReservationOrderAliasResponseResource> Get(string reservationOrderAliasName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.BillingBenefits.ReservationOrderAliasResponseResource>> GetAsync(string reservationOrderAliasName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.BillingBenefits.ReservationOrderAliasResponseResource> GetIfExists(string reservationOrderAliasName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.BillingBenefits.ReservationOrderAliasResponseResource>> GetIfExistsAsync(string reservationOrderAliasName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ReservationOrderAliasResponseData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.BillingBenefits.ReservationOrderAliasResponseData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.BillingBenefits.ReservationOrderAliasResponseData>
    {
        internal ReservationOrderAliasResponseData() { }
        public Azure.ResourceManager.BillingBenefits.Models.AppliedScopeProperties AppliedScopeProperties { get { throw null; } }
        public Azure.ResourceManager.BillingBenefits.Models.AppliedScopeType? AppliedScopeType { get { throw null; } }
        public Azure.ResourceManager.BillingBenefits.Models.BillingPlan? BillingPlan { get { throw null; } }
        public string BillingScopeId { get { throw null; } }
        public string DisplayName { get { throw null; } }
        public string Location { get { throw null; } }
        public Azure.ResourceManager.BillingBenefits.Models.ProvisioningState? ProvisioningState { get { throw null; } }
        public int? Quantity { get { throw null; } }
        public bool? Renew { get { throw null; } }
        public string ReservationOrderId { get { throw null; } }
        public Azure.ResourceManager.BillingBenefits.Models.InstanceFlexibility? ReservedResourceInstanceFlexibility { get { throw null; } }
        public Azure.ResourceManager.BillingBenefits.Models.ReservedResourceType? ReservedResourceType { get { throw null; } }
        public System.DateTimeOffset? ReviewOn { get { throw null; } }
        public string SkuName { get { throw null; } }
        public Azure.ResourceManager.BillingBenefits.Models.Term? Term { get { throw null; } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.BillingBenefits.ReservationOrderAliasResponseData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.BillingBenefits.ReservationOrderAliasResponseData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.BillingBenefits.ReservationOrderAliasResponseData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.BillingBenefits.ReservationOrderAliasResponseData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.BillingBenefits.ReservationOrderAliasResponseData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.BillingBenefits.ReservationOrderAliasResponseData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.BillingBenefits.ReservationOrderAliasResponseData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ReservationOrderAliasResponseResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.BillingBenefits.ReservationOrderAliasResponseData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.BillingBenefits.ReservationOrderAliasResponseData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ReservationOrderAliasResponseResource() { }
        public virtual Azure.ResourceManager.BillingBenefits.ReservationOrderAliasResponseData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string reservationOrderAliasName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.BillingBenefits.ReservationOrderAliasResponseResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.BillingBenefits.ReservationOrderAliasResponseResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.BillingBenefits.ReservationOrderAliasResponseData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.BillingBenefits.ReservationOrderAliasResponseData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.BillingBenefits.ReservationOrderAliasResponseData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.BillingBenefits.ReservationOrderAliasResponseData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.BillingBenefits.ReservationOrderAliasResponseData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.BillingBenefits.ReservationOrderAliasResponseData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.BillingBenefits.ReservationOrderAliasResponseData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.BillingBenefits.ReservationOrderAliasResponseResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsReservationOrderAliasContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.BillingBenefits.ReservationOrderAliasResponseResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsReservationOrderAliasContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SavingsPlanModelCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.BillingBenefits.SavingsPlanModelResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.BillingBenefits.SavingsPlanModelResource>, System.Collections.IEnumerable
    {
        protected SavingsPlanModelCollection() { }
        public virtual Azure.Response<bool> Exists(string savingsPlanId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string savingsPlanId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.BillingBenefits.SavingsPlanModelResource> Get(string savingsPlanId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.BillingBenefits.SavingsPlanModelResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.BillingBenefits.SavingsPlanModelResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.BillingBenefits.SavingsPlanModelResource>> GetAsync(string savingsPlanId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.BillingBenefits.SavingsPlanModelResource> GetIfExists(string savingsPlanId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.BillingBenefits.SavingsPlanModelResource>> GetIfExistsAsync(string savingsPlanId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.BillingBenefits.SavingsPlanModelResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.BillingBenefits.SavingsPlanModelResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.BillingBenefits.SavingsPlanModelResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.BillingBenefits.SavingsPlanModelResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class SavingsPlanModelData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.BillingBenefits.SavingsPlanModelData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.BillingBenefits.SavingsPlanModelData>
    {
        internal SavingsPlanModelData() { }
        public Azure.ResourceManager.BillingBenefits.Models.AppliedScopeProperties AppliedScopeProperties { get { throw null; } }
        public Azure.ResourceManager.BillingBenefits.Models.AppliedScopeType? AppliedScopeType { get { throw null; } }
        public System.DateTimeOffset? BenefitStartOn { get { throw null; } }
        public Azure.Core.ResourceIdentifier BillingAccountId { get { throw null; } }
        public Azure.ResourceManager.BillingBenefits.Models.BillingPlan? BillingPlan { get { throw null; } }
        public Azure.Core.ResourceIdentifier BillingProfileId { get { throw null; } }
        public string BillingScopeId { get { throw null; } }
        public Azure.ResourceManager.BillingBenefits.Models.Commitment Commitment { get { throw null; } }
        public Azure.Core.ResourceIdentifier CustomerId { get { throw null; } }
        public string DisplayName { get { throw null; } }
        public string DisplayProvisioningState { get { throw null; } }
        public System.DateTimeOffset? EffectiveOn { get { throw null; } }
        public System.DateTimeOffset? ExpiryOn { get { throw null; } }
        public Azure.ResourceManager.BillingBenefits.Models.ExtendedStatusInfo ExtendedStatusInfo { get { throw null; } }
        public Azure.ResourceManager.BillingBenefits.Models.ProvisioningState? ProvisioningState { get { throw null; } }
        public System.DateTimeOffset? PurchaseOn { get { throw null; } }
        public bool? Renew { get { throw null; } }
        public string RenewDestination { get { throw null; } }
        public Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsPurchaseContent RenewPurchaseProperties { get { throw null; } }
        public string RenewSource { get { throw null; } }
        public string SkuName { get { throw null; } }
        public Azure.ResourceManager.BillingBenefits.Models.Term? Term { get { throw null; } }
        public string UserFriendlyAppliedScopeType { get { throw null; } }
        public Azure.ResourceManager.BillingBenefits.Models.Utilization Utilization { get { throw null; } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.BillingBenefits.SavingsPlanModelData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.BillingBenefits.SavingsPlanModelData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.BillingBenefits.SavingsPlanModelData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.BillingBenefits.SavingsPlanModelData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.BillingBenefits.SavingsPlanModelData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.BillingBenefits.SavingsPlanModelData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.BillingBenefits.SavingsPlanModelData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SavingsPlanModelResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.BillingBenefits.SavingsPlanModelData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.BillingBenefits.SavingsPlanModelData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected SavingsPlanModelResource() { }
        public virtual Azure.ResourceManager.BillingBenefits.SavingsPlanModelData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string savingsPlanOrderId, string savingsPlanId) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.BillingBenefits.SavingsPlanModelResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.BillingBenefits.SavingsPlanModelResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.BillingBenefits.SavingsPlanModelData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.BillingBenefits.SavingsPlanModelData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.BillingBenefits.SavingsPlanModelData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.BillingBenefits.SavingsPlanModelData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.BillingBenefits.SavingsPlanModelData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.BillingBenefits.SavingsPlanModelData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.BillingBenefits.SavingsPlanModelData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.BillingBenefits.SavingsPlanModelResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.BillingBenefits.Models.SavingsPlanModelPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.BillingBenefits.SavingsPlanModelResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.BillingBenefits.Models.SavingsPlanModelPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsSavingsPlanValidateResult> ValidateUpdate(Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsSavingsPlanUpdateValidateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsSavingsPlanValidateResult>> ValidateUpdateAsync(Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsSavingsPlanUpdateValidateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SavingsPlanOrderAliasModelCollection : Azure.ResourceManager.ArmCollection
    {
        protected SavingsPlanOrderAliasModelCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.BillingBenefits.SavingsPlanOrderAliasModelResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string savingsPlanOrderAliasName, Azure.ResourceManager.BillingBenefits.SavingsPlanOrderAliasModelData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.BillingBenefits.SavingsPlanOrderAliasModelResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string savingsPlanOrderAliasName, Azure.ResourceManager.BillingBenefits.SavingsPlanOrderAliasModelData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string savingsPlanOrderAliasName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string savingsPlanOrderAliasName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.BillingBenefits.SavingsPlanOrderAliasModelResource> Get(string savingsPlanOrderAliasName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.BillingBenefits.SavingsPlanOrderAliasModelResource>> GetAsync(string savingsPlanOrderAliasName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.BillingBenefits.SavingsPlanOrderAliasModelResource> GetIfExists(string savingsPlanOrderAliasName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.BillingBenefits.SavingsPlanOrderAliasModelResource>> GetIfExistsAsync(string savingsPlanOrderAliasName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SavingsPlanOrderAliasModelData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.BillingBenefits.SavingsPlanOrderAliasModelData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.BillingBenefits.SavingsPlanOrderAliasModelData>
    {
        internal SavingsPlanOrderAliasModelData() { }
        public Azure.ResourceManager.BillingBenefits.Models.AppliedScopeProperties AppliedScopeProperties { get { throw null; } set { } }
        public Azure.ResourceManager.BillingBenefits.Models.AppliedScopeType? AppliedScopeType { get { throw null; } set { } }
        public Azure.ResourceManager.BillingBenefits.Models.BillingPlan? BillingPlan { get { throw null; } set { } }
        public string BillingScopeId { get { throw null; } set { } }
        public Azure.ResourceManager.BillingBenefits.Models.Commitment Commitment { get { throw null; } set { } }
        public string DisplayName { get { throw null; } set { } }
        public string Kind { get { throw null; } set { } }
        public Azure.ResourceManager.BillingBenefits.Models.ProvisioningState? ProvisioningState { get { throw null; } }
        public bool? Renew { get { throw null; } set { } }
        public string SavingsPlanOrderId { get { throw null; } }
        public string SkuName { get { throw null; } set { } }
        public Azure.ResourceManager.BillingBenefits.Models.Term? Term { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.BillingBenefits.SavingsPlanOrderAliasModelData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.BillingBenefits.SavingsPlanOrderAliasModelData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.BillingBenefits.SavingsPlanOrderAliasModelData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.BillingBenefits.SavingsPlanOrderAliasModelData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.BillingBenefits.SavingsPlanOrderAliasModelData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.BillingBenefits.SavingsPlanOrderAliasModelData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.BillingBenefits.SavingsPlanOrderAliasModelData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SavingsPlanOrderAliasModelResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.BillingBenefits.SavingsPlanOrderAliasModelData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.BillingBenefits.SavingsPlanOrderAliasModelData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected SavingsPlanOrderAliasModelResource() { }
        public virtual Azure.ResourceManager.BillingBenefits.SavingsPlanOrderAliasModelData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string savingsPlanOrderAliasName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.BillingBenefits.SavingsPlanOrderAliasModelResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.BillingBenefits.SavingsPlanOrderAliasModelResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.BillingBenefits.SavingsPlanOrderAliasModelData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.BillingBenefits.SavingsPlanOrderAliasModelData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.BillingBenefits.SavingsPlanOrderAliasModelData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.BillingBenefits.SavingsPlanOrderAliasModelData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.BillingBenefits.SavingsPlanOrderAliasModelData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.BillingBenefits.SavingsPlanOrderAliasModelData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.BillingBenefits.SavingsPlanOrderAliasModelData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.BillingBenefits.SavingsPlanOrderAliasModelResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.BillingBenefits.SavingsPlanOrderAliasModelData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.BillingBenefits.SavingsPlanOrderAliasModelResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.BillingBenefits.SavingsPlanOrderAliasModelData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SavingsPlanOrderModelCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.BillingBenefits.SavingsPlanOrderModelResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.BillingBenefits.SavingsPlanOrderModelResource>, System.Collections.IEnumerable
    {
        protected SavingsPlanOrderModelCollection() { }
        public virtual Azure.Response<bool> Exists(string savingsPlanOrderId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string savingsPlanOrderId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.BillingBenefits.SavingsPlanOrderModelResource> Get(string savingsPlanOrderId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.BillingBenefits.SavingsPlanOrderModelResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.BillingBenefits.SavingsPlanOrderModelResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.BillingBenefits.SavingsPlanOrderModelResource>> GetAsync(string savingsPlanOrderId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.BillingBenefits.SavingsPlanOrderModelResource> GetIfExists(string savingsPlanOrderId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.BillingBenefits.SavingsPlanOrderModelResource>> GetIfExistsAsync(string savingsPlanOrderId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.BillingBenefits.SavingsPlanOrderModelResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.BillingBenefits.SavingsPlanOrderModelResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.BillingBenefits.SavingsPlanOrderModelResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.BillingBenefits.SavingsPlanOrderModelResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class SavingsPlanOrderModelData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.BillingBenefits.SavingsPlanOrderModelData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.BillingBenefits.SavingsPlanOrderModelData>
    {
        internal SavingsPlanOrderModelData() { }
        public System.DateTimeOffset? BenefitStartOn { get { throw null; } }
        public Azure.Core.ResourceIdentifier BillingAccountId { get { throw null; } }
        public Azure.ResourceManager.BillingBenefits.Models.BillingPlan? BillingPlan { get { throw null; } }
        public Azure.Core.ResourceIdentifier BillingProfileId { get { throw null; } }
        public string BillingScopeId { get { throw null; } }
        public Azure.Core.ResourceIdentifier CustomerId { get { throw null; } }
        public string DisplayName { get { throw null; } }
        public System.DateTimeOffset? ExpiryOn { get { throw null; } }
        public Azure.ResourceManager.BillingBenefits.Models.ExtendedStatusInfo ExtendedStatusInfo { get { throw null; } }
        public Azure.ResourceManager.BillingBenefits.Models.BillingPlanInformation PlanInformation { get { throw null; } }
        public Azure.ResourceManager.BillingBenefits.Models.ProvisioningState? ProvisioningState { get { throw null; } }
        public System.Collections.Generic.IList<string> SavingsPlans { get { throw null; } }
        public string SkuName { get { throw null; } }
        public Azure.ResourceManager.BillingBenefits.Models.Term? Term { get { throw null; } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.BillingBenefits.SavingsPlanOrderModelData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.BillingBenefits.SavingsPlanOrderModelData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.BillingBenefits.SavingsPlanOrderModelData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.BillingBenefits.SavingsPlanOrderModelData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.BillingBenefits.SavingsPlanOrderModelData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.BillingBenefits.SavingsPlanOrderModelData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.BillingBenefits.SavingsPlanOrderModelData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SavingsPlanOrderModelResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.BillingBenefits.SavingsPlanOrderModelData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.BillingBenefits.SavingsPlanOrderModelData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected SavingsPlanOrderModelResource() { }
        public virtual Azure.ResourceManager.BillingBenefits.SavingsPlanOrderModelData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string savingsPlanOrderId) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.BillingBenefits.Models.RoleAssignmentEntity> Elevate(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.BillingBenefits.Models.RoleAssignmentEntity>> ElevateAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.BillingBenefits.SavingsPlanOrderModelResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.BillingBenefits.SavingsPlanOrderModelResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.BillingBenefits.SavingsPlanModelResource> GetSavingsPlanModel(string savingsPlanId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.BillingBenefits.SavingsPlanModelResource>> GetSavingsPlanModelAsync(string savingsPlanId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.BillingBenefits.SavingsPlanModelCollection GetSavingsPlanModels() { throw null; }
        Azure.ResourceManager.BillingBenefits.SavingsPlanOrderModelData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.BillingBenefits.SavingsPlanOrderModelData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.BillingBenefits.SavingsPlanOrderModelData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.BillingBenefits.SavingsPlanOrderModelData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.BillingBenefits.SavingsPlanOrderModelData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.BillingBenefits.SavingsPlanOrderModelData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.BillingBenefits.SavingsPlanOrderModelData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        public virtual Azure.Pageable<Azure.ResourceManager.BillingBenefits.ConditionalCreditResource> GetApplicableConditionalCredits(Azure.Core.ResourceIdentifier scope, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.BillingBenefits.ConditionalCreditResource> GetApplicableConditionalCreditsAsync(Azure.Core.ResourceIdentifier scope, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.BillingBenefits.DiscountResource> GetApplicableDiscounts(Azure.Core.ResourceIdentifier scope, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.BillingBenefits.DiscountResource> GetApplicableDiscountsAsync(Azure.Core.ResourceIdentifier scope, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.BillingBenefits.ConditionalCreditContributorResource GetConditionalCreditContributorResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.BillingBenefits.ConditionalCreditResource GetConditionalCreditResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.BillingBenefits.ContributorResource GetContributorResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.BillingBenefits.CreditResource GetCreditResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.BillingBenefits.CreditSourceResource GetCreditSourceResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.BillingBenefits.DiscountResource GetDiscountResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.BillingBenefits.FreeServicesResource GetFreeServicesResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.BillingBenefits.ConditionalCreditContributorResource> GetFromApplicableConditionalCredit(Azure.Core.ResourceIdentifier scope, string systemId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.BillingBenefits.ConditionalCreditContributorResource> GetFromApplicableConditionalCreditAsync(Azure.Core.ResourceIdentifier scope, string systemId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.BillingBenefits.ContributorResource> GetFromApplicableMacc(Azure.Core.ResourceIdentifier scope, string systemId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.BillingBenefits.ContributorResource> GetFromApplicableMaccAsync(Azure.Core.ResourceIdentifier scope, string systemId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.BillingBenefits.MaccResource GetMaccResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.BillingBenefits.ReservationOrderAliasResponseResource GetReservationOrderAliasResponseResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.BillingBenefits.SavingsPlanModelResource GetSavingsPlanModelResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.BillingBenefits.SavingsPlanOrderAliasModelResource GetSavingsPlanOrderAliasModelResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.BillingBenefits.SavingsPlanOrderModelResource GetSavingsPlanOrderModelResource(Azure.Core.ResourceIdentifier id) { throw null; }
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
        public virtual Azure.Pageable<Azure.ResourceManager.BillingBenefits.MaccResource> GetAll(Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsSellerResourceListContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.BillingBenefits.SavingsPlanModelResource> GetAll(string filter = null, string orderby = null, string refreshSummary = null, float? skiptoken = default(float?), string selectedState = null, float? take = default(float?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.BillingBenefits.MaccResource> GetAllAsync(Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsSellerResourceListContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.BillingBenefits.SavingsPlanModelResource> GetAllAsync(string filter = null, string orderby = null, string refreshSummary = null, float? skiptoken = default(float?), string selectedState = null, float? take = default(float?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.BillingBenefits.ReservationOrderAliasResponseResource> GetReservationOrderAliasResponse(string reservationOrderAliasName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.BillingBenefits.ReservationOrderAliasResponseResource>> GetReservationOrderAliasResponseAsync(string reservationOrderAliasName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.BillingBenefits.ReservationOrderAliasResponseCollection GetReservationOrderAliasResponses() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.BillingBenefits.SavingsPlanOrderAliasModelResource> GetSavingsPlanOrderAliasModel(string savingsPlanOrderAliasName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.BillingBenefits.SavingsPlanOrderAliasModelResource>> GetSavingsPlanOrderAliasModelAsync(string savingsPlanOrderAliasName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.BillingBenefits.SavingsPlanOrderAliasModelCollection GetSavingsPlanOrderAliasModels() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.BillingBenefits.SavingsPlanOrderModelResource> GetSavingsPlanOrderModel(string savingsPlanOrderId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.BillingBenefits.SavingsPlanOrderModelResource>> GetSavingsPlanOrderModelAsync(string savingsPlanOrderId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.BillingBenefits.SavingsPlanOrderModelCollection GetSavingsPlanOrderModels() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsBenefitValidateResult> Validate(Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsBenefitValidateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsBenefitValidateResult>> ValidateAsync(Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsBenefitValidateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.BillingBenefits.Models
{
    public partial class ApplicableMacc : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.BillingBenefits.Models.ApplicableMacc>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.BillingBenefits.Models.ApplicableMacc>
    {
        internal ApplicableMacc() { }
        public bool? AllowContributors { get { throw null; } }
        public Azure.ResourceManager.BillingBenefits.Models.EnablementMode? AutomaticShortfall { get { throw null; } }
        public Azure.ResourceManager.BillingBenefits.Models.AutomaticShortfallSuppressReason AutomaticShortfallSuppressReason { get { throw null; } }
        public Azure.Core.ResourceIdentifier BillingAccountResourceId { get { throw null; } }
        public Azure.ResourceManager.BillingBenefits.Models.Commitment Commitment { get { throw null; } }
        public string DisplayName { get { throw null; } }
        public System.DateTimeOffset? EndOn { get { throw null; } }
        public Azure.ResourceManager.BillingBenefits.Models.MaccEntityType EntityType { get { throw null; } }
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
    public partial class AppliedScopeProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.BillingBenefits.Models.AppliedScopeProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.BillingBenefits.Models.AppliedScopeProperties>
    {
        public AppliedScopeProperties() { }
        public string DisplayName { get { throw null; } set { } }
        public string ManagementGroupId { get { throw null; } set { } }
        public string ResourceGroupId { get { throw null; } set { } }
        public string SubscriptionId { get { throw null; } set { } }
        public string TenantId { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.BillingBenefits.Models.AppliedScopeProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.BillingBenefits.Models.AppliedScopeProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.BillingBenefits.Models.AppliedScopeProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.BillingBenefits.Models.AppliedScopeProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.BillingBenefits.Models.AppliedScopeProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.BillingBenefits.Models.AppliedScopeProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.BillingBenefits.Models.AppliedScopeProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.BillingBenefits.Models.AppliedScopeProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.BillingBenefits.Models.AppliedScopeProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.BillingBenefits.Models.AppliedScopeType left, Azure.ResourceManager.BillingBenefits.Models.AppliedScopeType right) { throw null; }
        public static implicit operator Azure.ResourceManager.BillingBenefits.Models.AppliedScopeType (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.BillingBenefits.Models.AppliedScopeType? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.BillingBenefits.Models.AppliedScopeType left, Azure.ResourceManager.BillingBenefits.Models.AppliedScopeType right) { throw null; }
        public override string ToString() { throw null; }
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
        public static Azure.ResourceManager.BillingBenefits.Models.ApplicableMacc ApplicableMacc(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string provisioningState = null, Azure.ResourceManager.BillingBenefits.Models.MaccStatus? status = default(Azure.ResourceManager.BillingBenefits.Models.MaccStatus?), Azure.ResourceManager.BillingBenefits.Models.MaccEntityType? entityType = default(Azure.ResourceManager.BillingBenefits.Models.MaccEntityType?), string displayName = null, string productCode = null, Azure.Core.ResourceIdentifier billingAccountResourceId = null, Azure.ResourceManager.BillingBenefits.Models.Commitment commitment = null, System.DateTimeOffset? startOn = default(System.DateTimeOffset?), System.DateTimeOffset? endOn = default(System.DateTimeOffset?), string systemId = null, Azure.ResourceManager.BillingBenefits.Models.EnablementMode? automaticShortfall = default(Azure.ResourceManager.BillingBenefits.Models.EnablementMode?), Azure.ResourceManager.BillingBenefits.Models.AutomaticShortfallSuppressReason automaticShortfallSuppressReason = null, Azure.ResourceManager.BillingBenefits.Models.Shortfall shortfall = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.BillingBenefits.Models.MaccMilestone> milestones = null, Azure.Core.ResourceIdentifier resourceId = null, bool? allowContributors = default(bool?), Azure.Core.ResourceIdentifier primaryResourceId = null, Azure.Core.ResourceIdentifier primaryBillingAccountResourceId = null) { throw null; }
        public static Azure.ResourceManager.BillingBenefits.Models.Award Award(Azure.ResourceManager.BillingBenefits.Models.Commitment credit = null, System.DateTimeOffset? startOn = default(System.DateTimeOffset?), System.DateTimeOffset? endOn = default(System.DateTimeOffset?), Azure.Core.ResourceIdentifier resourceId = null, string systemId = null, float? balanceVersion = default(float?), Azure.ResourceManager.BillingBenefits.Models.Term? duration = default(Azure.ResourceManager.BillingBenefits.Models.Term?)) { throw null; }
        public static Azure.ResourceManager.BillingBenefits.Models.BenefitValidateResponseProperty BenefitValidateResponseProperty(bool? valid = default(bool?), string reasonCode = null, string reason = null, Azure.Core.ResourceIdentifier resourceId = null) { throw null; }
        public static Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsBenefitValidateContent BillingBenefitsBenefitValidateContent(System.Collections.Generic.IEnumerable<Azure.ResourceManager.BillingBenefits.Models.BenefitValidateModel> benefits = null) { throw null; }
        public static Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsBenefitValidateResult BillingBenefitsBenefitValidateResult(System.Collections.Generic.IEnumerable<Azure.ResourceManager.BillingBenefits.Models.BenefitValidateResponseProperty> benefits = null, string nextLink = null) { throw null; }
        public static Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsReservationOrderAliasContent BillingBenefitsReservationOrderAliasContent(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string skuName = null, string location = null, string displayName = null, string billingScopeId = null, Azure.ResourceManager.BillingBenefits.Models.Term? term = default(Azure.ResourceManager.BillingBenefits.Models.Term?), Azure.ResourceManager.BillingBenefits.Models.BillingPlan? billingPlan = default(Azure.ResourceManager.BillingBenefits.Models.BillingPlan?), Azure.ResourceManager.BillingBenefits.Models.AppliedScopeType? appliedScopeType = default(Azure.ResourceManager.BillingBenefits.Models.AppliedScopeType?), Azure.ResourceManager.BillingBenefits.Models.AppliedScopeProperties appliedScopeProperties = null, int? quantity = default(int?), bool? renew = default(bool?), Azure.ResourceManager.BillingBenefits.Models.ReservedResourceType? reservedResourceType = default(Azure.ResourceManager.BillingBenefits.Models.ReservedResourceType?), System.DateTimeOffset? reviewOn = default(System.DateTimeOffset?), Azure.ResourceManager.BillingBenefits.Models.InstanceFlexibility? reservedResourceInstanceFlexibility = default(Azure.ResourceManager.BillingBenefits.Models.InstanceFlexibility?)) { throw null; }
        public static Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsSavingsPlanUpdateValidateContent BillingBenefitsSavingsPlanUpdateValidateContent(System.Collections.Generic.IEnumerable<Azure.ResourceManager.BillingBenefits.Models.SavingsPlanUpdateRequestProperties> benefits = null) { throw null; }
        public static Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsSavingsPlanValidateResult BillingBenefitsSavingsPlanValidateResult(System.Collections.Generic.IEnumerable<Azure.ResourceManager.BillingBenefits.Models.SavingsPlanValidResponseProperty> benefits = null, string nextLink = null) { throw null; }
        public static Azure.ResourceManager.BillingBenefits.Models.BillingPlanInformation BillingPlanInformation(Azure.ResourceManager.BillingBenefits.Models.Price pricingCurrencyTotal = null, System.DateTimeOffset? startOn = default(System.DateTimeOffset?), System.DateTimeOffset? nextPaymentDueOn = default(System.DateTimeOffset?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.BillingBenefits.Models.PaymentDetail> transactions = null) { throw null; }
        public static Azure.ResourceManager.BillingBenefits.ConditionalCreditContributorData ConditionalCreditContributorData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string displayName = null, Azure.Core.ResourceIdentifier billingAccountResourceId = null, Azure.ResourceManager.BillingBenefits.Models.ConditionalCreditsProvisioningState? provisioningState = default(Azure.ResourceManager.BillingBenefits.Models.ConditionalCreditsProvisioningState?), Azure.ResourceManager.BillingBenefits.Models.ConditionalCreditStatus? status = default(Azure.ResourceManager.BillingBenefits.Models.ConditionalCreditStatus?), System.DateTimeOffset? startOn = default(System.DateTimeOffset?), System.DateTimeOffset? endOn = default(System.DateTimeOffset?), string productCode = null, Azure.Core.ResourceIdentifier benefitResourceId = null, Azure.Core.ResourceIdentifier resourceId = null, Azure.Core.ResourceIdentifier primaryResourceId = null, string systemId = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.BillingBenefits.Models.ContributorConditionalCreditMilestone> milestones = null, Azure.Core.ResourceIdentifier primaryBillingAccountResourceId = null) { throw null; }
        public static Azure.ResourceManager.BillingBenefits.ConditionalCreditData ConditionalCreditData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.BillingBenefits.Models.ConditionalCreditProperties properties = null, string managedBy = null, string kind = null, string etag = null, Azure.ResourceManager.Models.ManagedServiceIdentity identity = null, Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsSku sku = null, Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsPlan plan = null) { throw null; }
        public static Azure.ResourceManager.BillingBenefits.Models.ConditionalCreditPatch ConditionalCreditPatch(string displayName = null, System.DateTimeOffset? endOn = default(System.DateTimeOffset?), Azure.ResourceManager.BillingBenefits.Models.EnablementMode? allowContributors = default(Azure.ResourceManager.BillingBenefits.Models.EnablementMode?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.BillingBenefits.Models.ConditionalCreditMilestone> milestones = null, System.Collections.Generic.IDictionary<string, string> tags = null) { throw null; }
        public static Azure.ResourceManager.BillingBenefits.Models.ConditionalCreditProperties ConditionalCreditProperties(string entityType = null, string displayName = null, Azure.Core.ResourceIdentifier billingAccountResourceId = null, Azure.ResourceManager.BillingBenefits.Models.ConditionalCreditsProvisioningState? provisioningState = default(Azure.ResourceManager.BillingBenefits.Models.ConditionalCreditsProvisioningState?), Azure.ResourceManager.BillingBenefits.Models.ConditionalCreditStatus? status = default(Azure.ResourceManager.BillingBenefits.Models.ConditionalCreditStatus?), System.DateTimeOffset? startOn = default(System.DateTimeOffset?), System.DateTimeOffset? endOn = default(System.DateTimeOffset?), string productCode = null, Azure.Core.ResourceIdentifier benefitResourceId = null, Azure.Core.ResourceIdentifier resourceId = null) { throw null; }
        public static Azure.ResourceManager.BillingBenefits.Models.ConditionsItem ConditionsItem(string conditionName = null, System.Collections.Generic.IEnumerable<string> value = null, string type = null) { throw null; }
        public static Azure.ResourceManager.BillingBenefits.Models.ContributorConditionalCreditProperties ContributorConditionalCreditProperties(string displayName = null, Azure.Core.ResourceIdentifier billingAccountResourceId = null, Azure.ResourceManager.BillingBenefits.Models.ConditionalCreditsProvisioningState? provisioningState = default(Azure.ResourceManager.BillingBenefits.Models.ConditionalCreditsProvisioningState?), Azure.ResourceManager.BillingBenefits.Models.ConditionalCreditStatus? status = default(Azure.ResourceManager.BillingBenefits.Models.ConditionalCreditStatus?), System.DateTimeOffset? startOn = default(System.DateTimeOffset?), System.DateTimeOffset? endOn = default(System.DateTimeOffset?), string productCode = null, Azure.Core.ResourceIdentifier benefitResourceId = null, Azure.Core.ResourceIdentifier resourceId = null, Azure.Core.ResourceIdentifier primaryResourceId = null, string systemId = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.BillingBenefits.Models.ContributorConditionalCreditMilestone> milestones = null, Azure.Core.ResourceIdentifier primaryBillingAccountResourceId = null) { throw null; }
        public static Azure.ResourceManager.BillingBenefits.ContributorData ContributorData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string provisioningState = null, Azure.ResourceManager.BillingBenefits.Models.MaccStatus? status = default(Azure.ResourceManager.BillingBenefits.Models.MaccStatus?), Azure.ResourceManager.BillingBenefits.Models.MaccEntityType? entityType = default(Azure.ResourceManager.BillingBenefits.Models.MaccEntityType?), string displayName = null, string productCode = null, Azure.Core.ResourceIdentifier billingAccountResourceId = null, Azure.ResourceManager.BillingBenefits.Models.Commitment commitment = null, System.DateTimeOffset? startOn = default(System.DateTimeOffset?), System.DateTimeOffset? endOn = default(System.DateTimeOffset?), string systemId = null, Azure.ResourceManager.BillingBenefits.Models.EnablementMode? automaticShortfall = default(Azure.ResourceManager.BillingBenefits.Models.EnablementMode?), Azure.ResourceManager.BillingBenefits.Models.AutomaticShortfallSuppressReason automaticShortfallSuppressReason = null, Azure.ResourceManager.BillingBenefits.Models.Shortfall shortfall = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.BillingBenefits.Models.MaccMilestone> milestones = null, Azure.Core.ResourceIdentifier resourceId = null, bool? allowContributors = default(bool?), Azure.Core.ResourceIdentifier primaryResourceId = null, Azure.Core.ResourceIdentifier primaryBillingAccountResourceId = null) { throw null; }
        public static Azure.ResourceManager.BillingBenefits.Models.CreditBreakdownItem CreditBreakdownItem(Azure.ResourceManager.BillingBenefits.Models.Commitment allocation = null, System.DateTimeOffset? startOn = default(System.DateTimeOffset?), System.DateTimeOffset? endOn = default(System.DateTimeOffset?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.BillingBenefits.Models.CreditDimension> dimensions = null) { throw null; }
        public static Azure.ResourceManager.BillingBenefits.CreditData CreditData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.BillingBenefits.Models.CreditStatus? status = default(Azure.ResourceManager.BillingBenefits.Models.CreditStatus?), string productCode = null, Azure.ResourceManager.BillingBenefits.Models.CreditReason reason = null, Azure.ResourceManager.BillingBenefits.Models.Commitment credit = null, System.DateTimeOffset? startOn = default(System.DateTimeOffset?), System.DateTimeOffset? endOn = default(System.DateTimeOffset?), Azure.ResourceManager.BillingBenefits.Models.CreditPolicies policies = null, Azure.Core.ResourceIdentifier billingAccountResourceId = null, Azure.Core.ResourceIdentifier billingProfileResourceId = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.BillingBenefits.Models.CreditBreakdownItem> breakdown = null, Azure.ResourceManager.BillingBenefits.Models.ProvisioningState? provisioningState = default(Azure.ResourceManager.BillingBenefits.Models.ProvisioningState?), string systemId = null, string customerId = null, Azure.Core.ResourceIdentifier resourceId = null, string managedBy = null, string kind = null, string etag = null, Azure.ResourceManager.Models.ManagedServiceIdentity identity = null, Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsSku sku = null, Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsPlan plan = null) { throw null; }
        public static Azure.ResourceManager.BillingBenefits.Models.CreditPatch CreditPatch(System.Collections.Generic.IDictionary<string, string> tags = null, Azure.ResourceManager.BillingBenefits.Models.Commitment credit = null, System.DateTimeOffset? endOn = default(System.DateTimeOffset?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.BillingBenefits.Models.CreditBreakdownItem> breakdown = null) { throw null; }
        public static Azure.ResourceManager.BillingBenefits.CreditSourceData CreditSourceData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.BillingBenefits.Models.CreditStatus? status = default(Azure.ResourceManager.BillingBenefits.Models.CreditStatus?), Azure.Core.ResourceIdentifier sourceResourceId = null, string impactedBillingPeriod = null, Azure.ResourceManager.BillingBenefits.Models.Commitment credit = null, string managedBy = null, string kind = null, string etag = null, Azure.ResourceManager.Models.ManagedServiceIdentity identity = null, Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsSku sku = null, Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsPlan plan = null) { throw null; }
        public static Azure.ResourceManager.BillingBenefits.Models.CreditSourcePatch CreditSourcePatch(System.Collections.Generic.IDictionary<string, string> tags = null) { throw null; }
        public static Azure.ResourceManager.BillingBenefits.Models.CustomPriceProperties CustomPriceProperties(Azure.ResourceManager.BillingBenefits.Models.DiscountRuleType ruleType = default(Azure.ResourceManager.BillingBenefits.Models.DiscountRuleType), string catalogId = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.BillingBenefits.Models.CatalogClaimsItem> catalogClaims = null, string termUnits = null, string billingPeriod = null, string meterType = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.BillingBenefits.Models.MarketSetPricesItems> marketSetPrices = null) { throw null; }
        public static Azure.ResourceManager.BillingBenefits.DiscountData DiscountData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.BillingBenefits.Models.DiscountProperties properties = null, string managedBy = null, string kind = null, string etag = null, Azure.ResourceManager.BillingBenefits.Models.ManagedServiceIdentity identity = null, Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsSku sku = null, Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsPlan plan = null) { throw null; }
        public static Azure.ResourceManager.BillingBenefits.Models.DiscountPatch DiscountPatch(string displayName = null, System.Collections.Generic.IDictionary<string, string> tags = null) { throw null; }
        public static Azure.ResourceManager.BillingBenefits.Models.DiscountProperties DiscountProperties(string entityType = null, string productCode = null, System.DateTimeOffset startOn = default(System.DateTimeOffset), string systemId = null, Azure.ResourceManager.BillingBenefits.Models.DiscountProvisioningState? provisioningState = default(Azure.ResourceManager.BillingBenefits.Models.DiscountProvisioningState?), Azure.Core.ResourceIdentifier billingAccountResourceId = null, Azure.Core.ResourceIdentifier billingProfileResourceId = null, Azure.Core.ResourceIdentifier customerResourceId = null, string displayName = null, Azure.ResourceManager.BillingBenefits.Models.DiscountStatus? status = default(Azure.ResourceManager.BillingBenefits.Models.DiscountStatus?), Azure.Core.ResourceIdentifier benefitResourceId = null, Azure.ResourceManager.BillingBenefits.Models.DiscountAppliedScopeType? appliedScopeType = default(Azure.ResourceManager.BillingBenefits.Models.DiscountAppliedScopeType?)) { throw null; }
        public static Azure.ResourceManager.BillingBenefits.Models.DiscountTypeCustomPrice DiscountTypeCustomPrice(Azure.ResourceManager.BillingBenefits.Models.ApplyDiscountOn applyDiscountOn = default(Azure.ResourceManager.BillingBenefits.Models.ApplyDiscountOn), double? discountPercentage = default(double?), Azure.ResourceManager.BillingBenefits.Models.DiscountCombinationRule? discountCombinationRule = default(Azure.ResourceManager.BillingBenefits.Models.DiscountCombinationRule?), Azure.ResourceManager.BillingBenefits.Models.PriceGuaranteeProperties priceGuaranteeProperties = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.BillingBenefits.Models.ConditionsItem> conditions = null, string productFamilyName = null, string productId = null, string skuId = null, Azure.ResourceManager.BillingBenefits.Models.CustomPriceProperties customPriceProperties = null) { throw null; }
        public static Azure.ResourceManager.BillingBenefits.Models.DiscountTypeCustomPriceMultiCurrency DiscountTypeCustomPriceMultiCurrency(Azure.ResourceManager.BillingBenefits.Models.ApplyDiscountOn applyDiscountOn = default(Azure.ResourceManager.BillingBenefits.Models.ApplyDiscountOn), double? discountPercentage = default(double?), Azure.ResourceManager.BillingBenefits.Models.DiscountCombinationRule? discountCombinationRule = default(Azure.ResourceManager.BillingBenefits.Models.DiscountCombinationRule?), Azure.ResourceManager.BillingBenefits.Models.PriceGuaranteeProperties priceGuaranteeProperties = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.BillingBenefits.Models.ConditionsItem> conditions = null, string productFamilyName = null, string productId = null, string skuId = null, Azure.ResourceManager.BillingBenefits.Models.CustomPriceProperties customPriceProperties = null) { throw null; }
        public static Azure.ResourceManager.BillingBenefits.Models.DiscountTypeProduct DiscountTypeProduct(Azure.ResourceManager.BillingBenefits.Models.ApplyDiscountOn applyDiscountOn = default(Azure.ResourceManager.BillingBenefits.Models.ApplyDiscountOn), double? discountPercentage = default(double?), Azure.ResourceManager.BillingBenefits.Models.DiscountCombinationRule? discountCombinationRule = default(Azure.ResourceManager.BillingBenefits.Models.DiscountCombinationRule?), Azure.ResourceManager.BillingBenefits.Models.PriceGuaranteeProperties priceGuaranteeProperties = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.BillingBenefits.Models.ConditionsItem> conditions = null, string productFamilyName = null, string productId = null) { throw null; }
        public static Azure.ResourceManager.BillingBenefits.Models.DiscountTypeProductFamily DiscountTypeProductFamily(Azure.ResourceManager.BillingBenefits.Models.ApplyDiscountOn applyDiscountOn = default(Azure.ResourceManager.BillingBenefits.Models.ApplyDiscountOn), double? discountPercentage = default(double?), Azure.ResourceManager.BillingBenefits.Models.DiscountCombinationRule? discountCombinationRule = default(Azure.ResourceManager.BillingBenefits.Models.DiscountCombinationRule?), Azure.ResourceManager.BillingBenefits.Models.PriceGuaranteeProperties priceGuaranteeProperties = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.BillingBenefits.Models.ConditionsItem> conditions = null, string productFamilyName = null) { throw null; }
        public static Azure.ResourceManager.BillingBenefits.Models.DiscountTypeProductSku DiscountTypeProductSku(Azure.ResourceManager.BillingBenefits.Models.ApplyDiscountOn applyDiscountOn = default(Azure.ResourceManager.BillingBenefits.Models.ApplyDiscountOn), double? discountPercentage = default(double?), Azure.ResourceManager.BillingBenefits.Models.DiscountCombinationRule? discountCombinationRule = default(Azure.ResourceManager.BillingBenefits.Models.DiscountCombinationRule?), Azure.ResourceManager.BillingBenefits.Models.PriceGuaranteeProperties priceGuaranteeProperties = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.BillingBenefits.Models.ConditionsItem> conditions = null, string productFamilyName = null, string productId = null, string skuId = null) { throw null; }
        public static Azure.ResourceManager.BillingBenefits.Models.DiscountTypeProperties DiscountTypeProperties(string discountType = null, Azure.ResourceManager.BillingBenefits.Models.ApplyDiscountOn applyDiscountOn = default(Azure.ResourceManager.BillingBenefits.Models.ApplyDiscountOn), double? discountPercentage = default(double?), Azure.ResourceManager.BillingBenefits.Models.DiscountCombinationRule? discountCombinationRule = default(Azure.ResourceManager.BillingBenefits.Models.DiscountCombinationRule?), Azure.ResourceManager.BillingBenefits.Models.PriceGuaranteeProperties priceGuaranteeProperties = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.BillingBenefits.Models.ConditionsItem> conditions = null) { throw null; }
        public static Azure.ResourceManager.BillingBenefits.Models.EntityTypeAffiliateDiscount EntityTypeAffiliateDiscount(string productCode = null, System.DateTimeOffset startOn = default(System.DateTimeOffset), string systemId = null, Azure.ResourceManager.BillingBenefits.Models.DiscountProvisioningState? provisioningState = default(Azure.ResourceManager.BillingBenefits.Models.DiscountProvisioningState?), Azure.Core.ResourceIdentifier billingAccountResourceId = null, Azure.Core.ResourceIdentifier billingProfileResourceId = null, Azure.Core.ResourceIdentifier customerResourceId = null, string displayName = null, Azure.ResourceManager.BillingBenefits.Models.DiscountStatus? status = default(Azure.ResourceManager.BillingBenefits.Models.DiscountStatus?), Azure.Core.ResourceIdentifier benefitResourceId = null, Azure.ResourceManager.BillingBenefits.Models.DiscountAppliedScopeType? appliedScopeType = default(Azure.ResourceManager.BillingBenefits.Models.DiscountAppliedScopeType?), Azure.Core.ResourceIdentifier primaryResourceId = null, System.DateTimeOffset? endOn = default(System.DateTimeOffset?)) { throw null; }
        public static Azure.ResourceManager.BillingBenefits.Models.EntityTypePrimaryDiscount EntityTypePrimaryDiscount(string productCode = null, System.DateTimeOffset startOn = default(System.DateTimeOffset), string systemId = null, Azure.ResourceManager.BillingBenefits.Models.DiscountProvisioningState? provisioningState = default(Azure.ResourceManager.BillingBenefits.Models.DiscountProvisioningState?), Azure.Core.ResourceIdentifier billingAccountResourceId = null, Azure.Core.ResourceIdentifier billingProfileResourceId = null, Azure.Core.ResourceIdentifier customerResourceId = null, string displayName = null, Azure.ResourceManager.BillingBenefits.Models.DiscountStatus? status = default(Azure.ResourceManager.BillingBenefits.Models.DiscountStatus?), Azure.Core.ResourceIdentifier benefitResourceId = null, Azure.ResourceManager.BillingBenefits.Models.DiscountAppliedScopeType? appliedScopeType = default(Azure.ResourceManager.BillingBenefits.Models.DiscountAppliedScopeType?), Azure.ResourceManager.BillingBenefits.Models.DiscountTypeProperties discountTypeProperties = null, System.DateTimeOffset endOn = default(System.DateTimeOffset)) { throw null; }
        public static Azure.ResourceManager.BillingBenefits.Models.ExtendedStatusInfo ExtendedStatusInfo(string statusCode = null, string message = null) { throw null; }
        public static Azure.ResourceManager.BillingBenefits.FreeServicesData FreeServicesData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), string productCode = null, Azure.ResourceManager.BillingBenefits.Models.FreeServicesStatus? status = default(Azure.ResourceManager.BillingBenefits.Models.FreeServicesStatus?), System.DateTimeOffset? startOn = default(System.DateTimeOffset?), System.DateTimeOffset? endOn = default(System.DateTimeOffset?), string provisioningState = null, Azure.Core.ResourceIdentifier billingAccountResourceId = null, Azure.Core.ResourceIdentifier billingProfileResourceId = null, Azure.Core.ResourceIdentifier customerResourceId = null, string systemId = null, string managedBy = null, string kind = null, string etag = null, Azure.ResourceManager.Models.ManagedServiceIdentity identity = null, Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsSku sku = null, Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsPlan plan = null) { throw null; }
        public static Azure.ResourceManager.BillingBenefits.Models.FreeServicesPatch FreeServicesPatch(System.DateTimeOffset? endOn = default(System.DateTimeOffset?), System.Collections.Generic.IDictionary<string, string> tags = null) { throw null; }
        public static Azure.ResourceManager.BillingBenefits.MaccData MaccData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), string provisioningState = null, Azure.ResourceManager.BillingBenefits.Models.MaccStatus? status = default(Azure.ResourceManager.BillingBenefits.Models.MaccStatus?), Azure.ResourceManager.BillingBenefits.Models.MaccEntityType? entityType = default(Azure.ResourceManager.BillingBenefits.Models.MaccEntityType?), string displayName = null, string productCode = null, Azure.Core.ResourceIdentifier billingAccountResourceId = null, Azure.ResourceManager.BillingBenefits.Models.Commitment commitment = null, System.DateTimeOffset? startOn = default(System.DateTimeOffset?), System.DateTimeOffset? endOn = default(System.DateTimeOffset?), string systemId = null, Azure.ResourceManager.BillingBenefits.Models.EnablementMode? automaticShortfall = default(Azure.ResourceManager.BillingBenefits.Models.EnablementMode?), Azure.ResourceManager.BillingBenefits.Models.AutomaticShortfallSuppressReason automaticShortfallSuppressReason = null, Azure.ResourceManager.BillingBenefits.Models.Shortfall shortfall = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.BillingBenefits.Models.MaccMilestone> milestones = null, Azure.Core.ResourceIdentifier resourceId = null, bool? allowContributors = default(bool?), Azure.Core.ResourceIdentifier primaryResourceId = null, Azure.Core.ResourceIdentifier primaryBillingAccountResourceId = null, string managedBy = null, string kind = null, string etag = null, Azure.ResourceManager.Models.ManagedServiceIdentity identity = null, Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsSku sku = null, Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsPlan plan = null) { throw null; }
        public static Azure.ResourceManager.BillingBenefits.Models.MaccPatch MaccPatch(Azure.ResourceManager.BillingBenefits.Models.Commitment commitment = null, System.DateTimeOffset? endOn = default(System.DateTimeOffset?), bool? allowContributors = default(bool?), Azure.ResourceManager.BillingBenefits.Models.EnablementMode? automaticShortfall = default(Azure.ResourceManager.BillingBenefits.Models.EnablementMode?), Azure.ResourceManager.BillingBenefits.Models.AutomaticShortfallSuppressReason automaticShortfallSuppressReason = null, string displayName = null, Azure.ResourceManager.BillingBenefits.Models.MaccMilestoneStatus? status = default(Azure.ResourceManager.BillingBenefits.Models.MaccMilestoneStatus?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.BillingBenefits.Models.MaccMilestone> milestones = null, Azure.Core.ResourceIdentifier primaryResourceId = null, Azure.Core.ResourceIdentifier primaryBillingAccountResourceId = null, System.Collections.Generic.IDictionary<string, string> tags = null) { throw null; }
        public static Azure.ResourceManager.BillingBenefits.Models.ManagedServiceIdentity ManagedServiceIdentity(string principalId = null, string tenantId = null, Azure.ResourceManager.BillingBenefits.Models.ManagedServiceIdentityType type = default(Azure.ResourceManager.BillingBenefits.Models.ManagedServiceIdentityType), System.Collections.Generic.IDictionary<string, Azure.ResourceManager.Models.UserAssignedIdentity> userAssignedIdentities = null) { throw null; }
        public static Azure.ResourceManager.BillingBenefits.Models.MarketSetPricesItems MarketSetPricesItems(System.Collections.Generic.IEnumerable<string> markets = null, float value = 0f, string currency = null) { throw null; }
        public static Azure.ResourceManager.BillingBenefits.Models.PaymentDetail PaymentDetail(System.DateTimeOffset? dueOn = default(System.DateTimeOffset?), System.DateTimeOffset? paymentOn = default(System.DateTimeOffset?), Azure.ResourceManager.BillingBenefits.Models.Price pricingCurrencyTotal = null, Azure.ResourceManager.BillingBenefits.Models.Price billingCurrencyTotal = null, Azure.ResourceManager.BillingBenefits.Models.PaymentStatus? status = default(Azure.ResourceManager.BillingBenefits.Models.PaymentStatus?), Azure.ResourceManager.BillingBenefits.Models.ExtendedStatusInfo extendedStatusInfo = null, string billingAccount = null) { throw null; }
        public static Azure.ResourceManager.BillingBenefits.Models.PrimaryConditionalCreditProperties PrimaryConditionalCreditProperties(string displayName = null, Azure.Core.ResourceIdentifier billingAccountResourceId = null, Azure.ResourceManager.BillingBenefits.Models.ConditionalCreditsProvisioningState? provisioningState = default(Azure.ResourceManager.BillingBenefits.Models.ConditionalCreditsProvisioningState?), Azure.ResourceManager.BillingBenefits.Models.ConditionalCreditStatus? status = default(Azure.ResourceManager.BillingBenefits.Models.ConditionalCreditStatus?), System.DateTimeOffset? startOn = default(System.DateTimeOffset?), System.DateTimeOffset? endOn = default(System.DateTimeOffset?), string productCode = null, Azure.Core.ResourceIdentifier benefitResourceId = null, Azure.Core.ResourceIdentifier resourceId = null, string systemId = null, Azure.ResourceManager.BillingBenefits.Models.EnablementMode? allowContributors = default(Azure.ResourceManager.BillingBenefits.Models.EnablementMode?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.BillingBenefits.Models.ConditionalCreditMilestone> milestones = null) { throw null; }
        public static Azure.ResourceManager.BillingBenefits.ReservationOrderAliasResponseData ReservationOrderAliasResponseData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string displayName = null, string reservationOrderId = null, Azure.ResourceManager.BillingBenefits.Models.ProvisioningState? provisioningState = default(Azure.ResourceManager.BillingBenefits.Models.ProvisioningState?), string billingScopeId = null, Azure.ResourceManager.BillingBenefits.Models.Term? term = default(Azure.ResourceManager.BillingBenefits.Models.Term?), Azure.ResourceManager.BillingBenefits.Models.BillingPlan? billingPlan = default(Azure.ResourceManager.BillingBenefits.Models.BillingPlan?), Azure.ResourceManager.BillingBenefits.Models.AppliedScopeType? appliedScopeType = default(Azure.ResourceManager.BillingBenefits.Models.AppliedScopeType?), Azure.ResourceManager.BillingBenefits.Models.AppliedScopeProperties appliedScopeProperties = null, int? quantity = default(int?), bool? renew = default(bool?), Azure.ResourceManager.BillingBenefits.Models.ReservedResourceType? reservedResourceType = default(Azure.ResourceManager.BillingBenefits.Models.ReservedResourceType?), System.DateTimeOffset? reviewOn = default(System.DateTimeOffset?), Azure.ResourceManager.BillingBenefits.Models.InstanceFlexibility? reservedResourceInstanceFlexibility = default(Azure.ResourceManager.BillingBenefits.Models.InstanceFlexibility?), string skuName = null, string location = null) { throw null; }
        public static Azure.ResourceManager.BillingBenefits.Models.RoleAssignmentEntity RoleAssignmentEntity(string id = null, string name = null, string principalId = null, string roleDefinitionId = null, string scope = null) { throw null; }
        public static Azure.ResourceManager.BillingBenefits.SavingsPlanModelData SavingsPlanModelData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string displayName = null, Azure.ResourceManager.BillingBenefits.Models.ProvisioningState? provisioningState = default(Azure.ResourceManager.BillingBenefits.Models.ProvisioningState?), string displayProvisioningState = null, string billingScopeId = null, Azure.Core.ResourceIdentifier billingProfileId = null, Azure.Core.ResourceIdentifier customerId = null, Azure.Core.ResourceIdentifier billingAccountId = null, Azure.ResourceManager.BillingBenefits.Models.Term? term = default(Azure.ResourceManager.BillingBenefits.Models.Term?), Azure.ResourceManager.BillingBenefits.Models.BillingPlan? billingPlan = default(Azure.ResourceManager.BillingBenefits.Models.BillingPlan?), Azure.ResourceManager.BillingBenefits.Models.AppliedScopeType? appliedScopeType = default(Azure.ResourceManager.BillingBenefits.Models.AppliedScopeType?), string userFriendlyAppliedScopeType = null, Azure.ResourceManager.BillingBenefits.Models.AppliedScopeProperties appliedScopeProperties = null, Azure.ResourceManager.BillingBenefits.Models.Commitment commitment = null, System.DateTimeOffset? effectiveOn = default(System.DateTimeOffset?), System.DateTimeOffset? expiryOn = default(System.DateTimeOffset?), System.DateTimeOffset? purchaseOn = default(System.DateTimeOffset?), System.DateTimeOffset? benefitStartOn = default(System.DateTimeOffset?), Azure.ResourceManager.BillingBenefits.Models.ExtendedStatusInfo extendedStatusInfo = null, bool? renew = default(bool?), Azure.ResourceManager.BillingBenefits.Models.Utilization utilization = null, string renewSource = null, string renewDestination = null, Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsPurchaseContent renewPurchaseProperties = null, string skuName = null) { throw null; }
        public static Azure.ResourceManager.BillingBenefits.SavingsPlanOrderAliasModelData SavingsPlanOrderAliasModelData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string displayName = null, string savingsPlanOrderId = null, Azure.ResourceManager.BillingBenefits.Models.ProvisioningState? provisioningState = default(Azure.ResourceManager.BillingBenefits.Models.ProvisioningState?), string billingScopeId = null, Azure.ResourceManager.BillingBenefits.Models.Term? term = default(Azure.ResourceManager.BillingBenefits.Models.Term?), Azure.ResourceManager.BillingBenefits.Models.BillingPlan? billingPlan = default(Azure.ResourceManager.BillingBenefits.Models.BillingPlan?), Azure.ResourceManager.BillingBenefits.Models.AppliedScopeType? appliedScopeType = default(Azure.ResourceManager.BillingBenefits.Models.AppliedScopeType?), Azure.ResourceManager.BillingBenefits.Models.AppliedScopeProperties appliedScopeProperties = null, Azure.ResourceManager.BillingBenefits.Models.Commitment commitment = null, bool? renew = default(bool?), string skuName = null, string kind = null) { throw null; }
        public static Azure.ResourceManager.BillingBenefits.SavingsPlanOrderModelData SavingsPlanOrderModelData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string displayName = null, Azure.ResourceManager.BillingBenefits.Models.ProvisioningState? provisioningState = default(Azure.ResourceManager.BillingBenefits.Models.ProvisioningState?), string billingScopeId = null, Azure.Core.ResourceIdentifier billingProfileId = null, Azure.Core.ResourceIdentifier customerId = null, Azure.Core.ResourceIdentifier billingAccountId = null, Azure.ResourceManager.BillingBenefits.Models.Term? term = default(Azure.ResourceManager.BillingBenefits.Models.Term?), Azure.ResourceManager.BillingBenefits.Models.BillingPlan? billingPlan = default(Azure.ResourceManager.BillingBenefits.Models.BillingPlan?), System.DateTimeOffset? expiryOn = default(System.DateTimeOffset?), System.DateTimeOffset? benefitStartOn = default(System.DateTimeOffset?), Azure.ResourceManager.BillingBenefits.Models.BillingPlanInformation planInformation = null, System.Collections.Generic.IEnumerable<string> savingsPlans = null, Azure.ResourceManager.BillingBenefits.Models.ExtendedStatusInfo extendedStatusInfo = null, string skuName = null) { throw null; }
        public static Azure.ResourceManager.BillingBenefits.Models.SavingsPlanValidateModel SavingsPlanValidateModel(string displayName = null, string savingsPlanOrderId = null, Azure.ResourceManager.BillingBenefits.Models.ProvisioningState? provisioningState = default(Azure.ResourceManager.BillingBenefits.Models.ProvisioningState?), string billingScopeId = null, Azure.ResourceManager.BillingBenefits.Models.Term? term = default(Azure.ResourceManager.BillingBenefits.Models.Term?), Azure.ResourceManager.BillingBenefits.Models.BillingPlan? billingPlan = default(Azure.ResourceManager.BillingBenefits.Models.BillingPlan?), Azure.ResourceManager.BillingBenefits.Models.AppliedScopeType? appliedScopeType = default(Azure.ResourceManager.BillingBenefits.Models.AppliedScopeType?), Azure.ResourceManager.BillingBenefits.Models.AppliedScopeProperties appliedScopeProperties = null, Azure.ResourceManager.BillingBenefits.Models.Commitment commitment = null, bool? renew = default(bool?), Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType? type = default(Azure.Core.ResourceType?), Azure.ResourceManager.Models.SystemData systemData = null, string skuName = null, string kind = null) { throw null; }
        public static Azure.ResourceManager.BillingBenefits.Models.SavingsPlanValidResponseProperty SavingsPlanValidResponseProperty(bool? valid = default(bool?), string reasonCode = null, string reason = null) { throw null; }
        public static Azure.ResourceManager.BillingBenefits.Models.Utilization Utilization(string trend = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.BillingBenefits.Models.UtilizationAggregates> aggregates = null) { throw null; }
        public static Azure.ResourceManager.BillingBenefits.Models.UtilizationAggregates UtilizationAggregates(float? grain = default(float?), string grainUnit = null, float? value = default(float?), string valueUnit = null) { throw null; }
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
        public Azure.ResourceManager.BillingBenefits.Models.Commitment Credit { get { throw null; } set { } }
        public Azure.ResourceManager.BillingBenefits.Models.Term? Duration { get { throw null; } set { } }
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
    public partial class BenefitValidateResponseProperty : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.BillingBenefits.Models.BenefitValidateResponseProperty>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.BillingBenefits.Models.BenefitValidateResponseProperty>
    {
        internal BenefitValidateResponseProperty() { }
        public string Reason { get { throw null; } }
        public string ReasonCode { get { throw null; } }
        public Azure.Core.ResourceIdentifier ResourceId { get { throw null; } }
        public bool? Valid { get { throw null; } }
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
    public partial class BillingBenefitsBenefitValidateContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsBenefitValidateContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsBenefitValidateContent>
    {
        public BillingBenefitsBenefitValidateContent() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.BillingBenefits.Models.BenefitValidateModel> Benefits { get { throw null; } }
        protected virtual Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsBenefitValidateContent JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsBenefitValidateContent PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsBenefitValidateContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsBenefitValidateContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsBenefitValidateContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsBenefitValidateContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsBenefitValidateContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsBenefitValidateContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsBenefitValidateContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class BillingBenefitsBenefitValidateResult : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsBenefitValidateResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsBenefitValidateResult>
    {
        internal BillingBenefitsBenefitValidateResult() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.BillingBenefits.Models.BenefitValidateResponseProperty> Benefits { get { throw null; } }
        public string NextLink { get { throw null; } }
        protected virtual Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsBenefitValidateResult JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsBenefitValidateResult PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsBenefitValidateResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsBenefitValidateResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsBenefitValidateResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsBenefitValidateResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsBenefitValidateResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsBenefitValidateResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsBenefitValidateResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class BillingBenefitsChargeShortfallContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsChargeShortfallContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsChargeShortfallContent>
    {
        public BillingBenefitsChargeShortfallContent() { }
        public float? BalanceVersion { get { throw null; } set { } }
        public Azure.ResourceManager.BillingBenefits.Models.Commitment Charge { get { throw null; } set { } }
        public System.DateTimeOffset? EndOn { get { throw null; } set { } }
        public string ProductCode { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier ResourceId { get { throw null; } set { } }
        public System.DateTimeOffset? StartOn { get { throw null; } set { } }
        public string SystemId { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsChargeShortfallContent JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsChargeShortfallContent PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsChargeShortfallContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsChargeShortfallContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsChargeShortfallContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsChargeShortfallContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsChargeShortfallContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsChargeShortfallContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsChargeShortfallContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
    public partial class BillingBenefitsPurchaseContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsPurchaseContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsPurchaseContent>
    {
        public BillingBenefitsPurchaseContent() { }
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
    public partial class BillingBenefitsReservationOrderAliasContent : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsReservationOrderAliasContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsReservationOrderAliasContent>
    {
        internal BillingBenefitsReservationOrderAliasContent() { }
        public Azure.ResourceManager.BillingBenefits.Models.AppliedScopeProperties AppliedScopeProperties { get { throw null; } set { } }
        public Azure.ResourceManager.BillingBenefits.Models.AppliedScopeType? AppliedScopeType { get { throw null; } set { } }
        public Azure.ResourceManager.BillingBenefits.Models.BillingPlan? BillingPlan { get { throw null; } set { } }
        public string BillingScopeId { get { throw null; } set { } }
        public string DisplayName { get { throw null; } set { } }
        public string Location { get { throw null; } set { } }
        public int? Quantity { get { throw null; } set { } }
        public bool? Renew { get { throw null; } set { } }
        public Azure.ResourceManager.BillingBenefits.Models.InstanceFlexibility? ReservedResourceInstanceFlexibility { get { throw null; } set { } }
        public Azure.ResourceManager.BillingBenefits.Models.ReservedResourceType? ReservedResourceType { get { throw null; } set { } }
        public System.DateTimeOffset? ReviewOn { get { throw null; } set { } }
        public string SkuName { get { throw null; } }
        public Azure.ResourceManager.BillingBenefits.Models.Term? Term { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsReservationOrderAliasContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsReservationOrderAliasContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsReservationOrderAliasContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsReservationOrderAliasContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsReservationOrderAliasContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsReservationOrderAliasContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsReservationOrderAliasContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class BillingBenefitsSavingsPlanUpdateValidateContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsSavingsPlanUpdateValidateContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsSavingsPlanUpdateValidateContent>
    {
        public BillingBenefitsSavingsPlanUpdateValidateContent() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.BillingBenefits.Models.SavingsPlanUpdateRequestProperties> Benefits { get { throw null; } }
        protected virtual Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsSavingsPlanUpdateValidateContent JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsSavingsPlanUpdateValidateContent PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsSavingsPlanUpdateValidateContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsSavingsPlanUpdateValidateContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsSavingsPlanUpdateValidateContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsSavingsPlanUpdateValidateContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsSavingsPlanUpdateValidateContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsSavingsPlanUpdateValidateContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsSavingsPlanUpdateValidateContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class BillingBenefitsSavingsPlanValidateResult : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsSavingsPlanValidateResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsSavingsPlanValidateResult>
    {
        internal BillingBenefitsSavingsPlanValidateResult() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.BillingBenefits.Models.SavingsPlanValidResponseProperty> Benefits { get { throw null; } }
        public string NextLink { get { throw null; } }
        protected virtual Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsSavingsPlanValidateResult JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsSavingsPlanValidateResult PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsSavingsPlanValidateResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsSavingsPlanValidateResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsSavingsPlanValidateResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsSavingsPlanValidateResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsSavingsPlanValidateResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsSavingsPlanValidateResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsSavingsPlanValidateResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class BillingBenefitsSellerResourceListContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsSellerResourceListContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsSellerResourceListContent>
    {
        public BillingBenefitsSellerResourceListContent() { }
        public Azure.Core.ResourceIdentifier BillingAccountResourceId { get { throw null; } }
        public bool? Contributors { get { throw null; } set { } }
        public string Filter { get { throw null; } set { } }
        public bool? Milestones { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier PrimaryResourceId { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsSellerResourceListContent JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsSellerResourceListContent PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsSellerResourceListContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsSellerResourceListContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsSellerResourceListContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsSellerResourceListContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsSellerResourceListContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsSellerResourceListContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsSellerResourceListContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
    public readonly partial struct BillingPlan : System.IEquatable<Azure.ResourceManager.BillingBenefits.Models.BillingPlan>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public BillingPlan(string value) { throw null; }
        public static Azure.ResourceManager.BillingBenefits.Models.BillingPlan P1M { get { throw null; } }
        public bool Equals(Azure.ResourceManager.BillingBenefits.Models.BillingPlan other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.BillingBenefits.Models.BillingPlan left, Azure.ResourceManager.BillingBenefits.Models.BillingPlan right) { throw null; }
        public static implicit operator Azure.ResourceManager.BillingBenefits.Models.BillingPlan (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.BillingBenefits.Models.BillingPlan? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.BillingBenefits.Models.BillingPlan left, Azure.ResourceManager.BillingBenefits.Models.BillingPlan right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class BillingPlanInformation : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.BillingBenefits.Models.BillingPlanInformation>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.BillingBenefits.Models.BillingPlanInformation>
    {
        internal BillingPlanInformation() { }
        public System.DateTimeOffset? NextPaymentDueOn { get { throw null; } }
        public Azure.ResourceManager.BillingBenefits.Models.Price PricingCurrencyTotal { get { throw null; } }
        public System.DateTimeOffset? StartOn { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.BillingBenefits.Models.PaymentDetail> Transactions { get { throw null; } }
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
    public partial class Commitment : Azure.ResourceManager.BillingBenefits.Models.Price, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.BillingBenefits.Models.Commitment>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.BillingBenefits.Models.Commitment>
    {
        public Commitment() { }
        public Azure.ResourceManager.BillingBenefits.Models.CommitmentGrain? Grain { get { throw null; } set { } }
        protected override Azure.ResourceManager.BillingBenefits.Models.Price JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.ResourceManager.BillingBenefits.Models.Price PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.BillingBenefits.Models.Commitment System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.BillingBenefits.Models.Commitment>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.BillingBenefits.Models.Commitment>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.BillingBenefits.Models.Commitment System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.BillingBenefits.Models.Commitment>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.BillingBenefits.Models.Commitment>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.BillingBenefits.Models.Commitment>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct CommitmentGrain : System.IEquatable<Azure.ResourceManager.BillingBenefits.Models.CommitmentGrain>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public CommitmentGrain(string value) { throw null; }
        public static Azure.ResourceManager.BillingBenefits.Models.CommitmentGrain FullTerm { get { throw null; } }
        public static Azure.ResourceManager.BillingBenefits.Models.CommitmentGrain Hourly { get { throw null; } }
        public static Azure.ResourceManager.BillingBenefits.Models.CommitmentGrain Unknown { get { throw null; } }
        public bool Equals(Azure.ResourceManager.BillingBenefits.Models.CommitmentGrain other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.BillingBenefits.Models.CommitmentGrain left, Azure.ResourceManager.BillingBenefits.Models.CommitmentGrain right) { throw null; }
        public static implicit operator Azure.ResourceManager.BillingBenefits.Models.CommitmentGrain (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.BillingBenefits.Models.CommitmentGrain? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.BillingBenefits.Models.CommitmentGrain left, Azure.ResourceManager.BillingBenefits.Models.CommitmentGrain right) { throw null; }
        public override string ToString() { throw null; }
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
        public Azure.ResourceManager.BillingBenefits.Models.Price SpendTarget { get { throw null; } set { } }
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
    public abstract partial class ConditionalCreditProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.BillingBenefits.Models.ConditionalCreditProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.BillingBenefits.Models.ConditionalCreditProperties>
    {
        internal ConditionalCreditProperties() { }
        public Azure.Core.ResourceIdentifier BenefitResourceId { get { throw null; } }
        public Azure.Core.ResourceIdentifier BillingAccountResourceId { get { throw null; } set { } }
        public string DisplayName { get { throw null; } set { } }
        public System.DateTimeOffset? EndOn { get { throw null; } set { } }
        public string ProductCode { get { throw null; } set { } }
        public Azure.ResourceManager.BillingBenefits.Models.ConditionalCreditsProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.Core.ResourceIdentifier ResourceId { get { throw null; } set { } }
        public System.DateTimeOffset? StartOn { get { throw null; } set { } }
        public Azure.ResourceManager.BillingBenefits.Models.ConditionalCreditStatus? Status { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.BillingBenefits.Models.ConditionalCreditProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.BillingBenefits.Models.ConditionalCreditProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.BillingBenefits.Models.ConditionalCreditProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.BillingBenefits.Models.ConditionalCreditProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.BillingBenefits.Models.ConditionalCreditProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.BillingBenefits.Models.ConditionalCreditProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.BillingBenefits.Models.ConditionalCreditProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.BillingBenefits.Models.ConditionalCreditProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.BillingBenefits.Models.ConditionalCreditProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        public Azure.ResourceManager.BillingBenefits.Models.ConditionalCreditProperties Properties { get { throw null; } set { } }
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
    public partial class ContributorConditionalCreditProperties : Azure.ResourceManager.BillingBenefits.Models.ConditionalCreditProperties, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.BillingBenefits.Models.ContributorConditionalCreditProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.BillingBenefits.Models.ContributorConditionalCreditProperties>
    {
        public ContributorConditionalCreditProperties() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.BillingBenefits.Models.ContributorConditionalCreditMilestone> Milestones { get { throw null; } }
        public Azure.Core.ResourceIdentifier PrimaryBillingAccountResourceId { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier PrimaryResourceId { get { throw null; } set { } }
        public string SystemId { get { throw null; } set { } }
        protected override Azure.ResourceManager.BillingBenefits.Models.ConditionalCreditProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.ResourceManager.BillingBenefits.Models.ConditionalCreditProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        public Azure.ResourceManager.BillingBenefits.Models.Commitment Allocation { get { throw null; } set { } }
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
        public Azure.ResourceManager.BillingBenefits.Models.Commitment Credit { get { throw null; } set { } }
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
        public Azure.ResourceManager.BillingBenefits.Models.Commitment Credit { get { throw null; } set { } }
        public string CustomerId { get { throw null; } }
        public System.DateTimeOffset? EndOn { get { throw null; } set { } }
        public string ETag { get { throw null; } }
        public Azure.Core.ResourceIdentifier Id { get { throw null; } }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public string Kind { get { throw null; } set { } }
        public Azure.Core.AzureLocation Location { get { throw null; } set { } }
        public string ManagedBy { get { throw null; } set { } }
        public string Name { get { throw null; } }
        public Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsPlan Plan { get { throw null; } set { } }
        public Azure.ResourceManager.BillingBenefits.Models.CreditPolicies Policies { get { throw null; } set { } }
        public string ProductCode { get { throw null; } set { } }
        public Azure.ResourceManager.BillingBenefits.Models.ProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.BillingBenefits.Models.CreditReason Reason { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier ResourceId { get { throw null; } set { } }
        public Azure.Core.ResourceType ResourceType { get { throw null; } }
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
    public abstract partial class DiscountProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.BillingBenefits.Models.DiscountProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.BillingBenefits.Models.DiscountProperties>
    {
        internal DiscountProperties() { }
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
        protected virtual Azure.ResourceManager.BillingBenefits.Models.DiscountProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.BillingBenefits.Models.DiscountProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.BillingBenefits.Models.DiscountProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.BillingBenefits.Models.DiscountProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.BillingBenefits.Models.DiscountProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.BillingBenefits.Models.DiscountProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.BillingBenefits.Models.DiscountProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.BillingBenefits.Models.DiscountProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.BillingBenefits.Models.DiscountProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
    public partial class EntityTypeAffiliateDiscount : Azure.ResourceManager.BillingBenefits.Models.DiscountProperties, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.BillingBenefits.Models.EntityTypeAffiliateDiscount>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.BillingBenefits.Models.EntityTypeAffiliateDiscount>
    {
        public EntityTypeAffiliateDiscount(string productCode, System.DateTimeOffset startOn) { }
        public System.DateTimeOffset? EndOn { get { throw null; } }
        public Azure.Core.ResourceIdentifier PrimaryResourceId { get { throw null; } }
        protected override Azure.ResourceManager.BillingBenefits.Models.DiscountProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.ResourceManager.BillingBenefits.Models.DiscountProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.BillingBenefits.Models.EntityTypeAffiliateDiscount System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.BillingBenefits.Models.EntityTypeAffiliateDiscount>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.BillingBenefits.Models.EntityTypeAffiliateDiscount>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.BillingBenefits.Models.EntityTypeAffiliateDiscount System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.BillingBenefits.Models.EntityTypeAffiliateDiscount>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.BillingBenefits.Models.EntityTypeAffiliateDiscount>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.BillingBenefits.Models.EntityTypeAffiliateDiscount>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class EntityTypePrimaryDiscount : Azure.ResourceManager.BillingBenefits.Models.DiscountProperties, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.BillingBenefits.Models.EntityTypePrimaryDiscount>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.BillingBenefits.Models.EntityTypePrimaryDiscount>
    {
        public EntityTypePrimaryDiscount(string productCode, System.DateTimeOffset startOn, System.DateTimeOffset endOn) { }
        public Azure.ResourceManager.BillingBenefits.Models.DiscountTypeProperties DiscountTypeProperties { get { throw null; } set { } }
        public System.DateTimeOffset EndOn { get { throw null; } set { } }
        protected override Azure.ResourceManager.BillingBenefits.Models.DiscountProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.ResourceManager.BillingBenefits.Models.DiscountProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.BillingBenefits.Models.EntityTypePrimaryDiscount System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.BillingBenefits.Models.EntityTypePrimaryDiscount>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.BillingBenefits.Models.EntityTypePrimaryDiscount>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.BillingBenefits.Models.EntityTypePrimaryDiscount System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.BillingBenefits.Models.EntityTypePrimaryDiscount>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.BillingBenefits.Models.EntityTypePrimaryDiscount>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.BillingBenefits.Models.EntityTypePrimaryDiscount>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ExtendedStatusInfo : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.BillingBenefits.Models.ExtendedStatusInfo>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.BillingBenefits.Models.ExtendedStatusInfo>
    {
        internal ExtendedStatusInfo() { }
        public string Message { get { throw null; } }
        public string StatusCode { get { throw null; } }
        protected virtual Azure.ResourceManager.BillingBenefits.Models.ExtendedStatusInfo JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.BillingBenefits.Models.ExtendedStatusInfo PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.BillingBenefits.Models.ExtendedStatusInfo System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.BillingBenefits.Models.ExtendedStatusInfo>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.BillingBenefits.Models.ExtendedStatusInfo>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.BillingBenefits.Models.ExtendedStatusInfo System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.BillingBenefits.Models.ExtendedStatusInfo>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.BillingBenefits.Models.ExtendedStatusInfo>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.BillingBenefits.Models.ExtendedStatusInfo>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
    public readonly partial struct InstanceFlexibility : System.IEquatable<Azure.ResourceManager.BillingBenefits.Models.InstanceFlexibility>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public InstanceFlexibility(string value) { throw null; }
        public static Azure.ResourceManager.BillingBenefits.Models.InstanceFlexibility Off { get { throw null; } }
        public static Azure.ResourceManager.BillingBenefits.Models.InstanceFlexibility On { get { throw null; } }
        public bool Equals(Azure.ResourceManager.BillingBenefits.Models.InstanceFlexibility other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.BillingBenefits.Models.InstanceFlexibility left, Azure.ResourceManager.BillingBenefits.Models.InstanceFlexibility right) { throw null; }
        public static implicit operator Azure.ResourceManager.BillingBenefits.Models.InstanceFlexibility (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.BillingBenefits.Models.InstanceFlexibility? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.BillingBenefits.Models.InstanceFlexibility left, Azure.ResourceManager.BillingBenefits.Models.InstanceFlexibility right) { throw null; }
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
        public Azure.ResourceManager.BillingBenefits.Models.Price Commitment { get { throw null; } set { } }
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
        public bool? AllowContributors { get { throw null; } set { } }
        public Azure.ResourceManager.BillingBenefits.Models.EnablementMode? AutomaticShortfall { get { throw null; } set { } }
        public Azure.ResourceManager.BillingBenefits.Models.AutomaticShortfallSuppressReason AutomaticShortfallSuppressReason { get { throw null; } set { } }
        public Azure.ResourceManager.BillingBenefits.Models.Commitment Commitment { get { throw null; } set { } }
        public string DisplayName { get { throw null; } set { } }
        public System.DateTimeOffset? EndOn { get { throw null; } set { } }
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
        public bool? AllowContributors { get { throw null; } set { } }
        public Azure.ResourceManager.BillingBenefits.Models.EnablementMode? AutomaticShortfall { get { throw null; } set { } }
        public Azure.ResourceManager.BillingBenefits.Models.AutomaticShortfallSuppressReason AutomaticShortfallSuppressReason { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier BillingAccountResourceId { get { throw null; } set { } }
        public Azure.ResourceManager.BillingBenefits.Models.Commitment Commitment { get { throw null; } set { } }
        public string DisplayName { get { throw null; } set { } }
        public System.DateTimeOffset? EndOn { get { throw null; } set { } }
        public Azure.ResourceManager.BillingBenefits.Models.MaccEntityType EntityType { get { throw null; } set { } }
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
    public partial class ManagedServiceIdentity : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.BillingBenefits.Models.ManagedServiceIdentity>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.BillingBenefits.Models.ManagedServiceIdentity>
    {
        public ManagedServiceIdentity(Azure.ResourceManager.BillingBenefits.Models.ManagedServiceIdentityType type) { }
        public string PrincipalId { get { throw null; } }
        public string TenantId { get { throw null; } }
        public Azure.ResourceManager.BillingBenefits.Models.ManagedServiceIdentityType Type { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, Azure.ResourceManager.Models.UserAssignedIdentity> UserAssignedIdentities { get { throw null; } }
        protected virtual Azure.ResourceManager.BillingBenefits.Models.ManagedServiceIdentity JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.BillingBenefits.Models.ManagedServiceIdentity PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.BillingBenefits.Models.ManagedServiceIdentity System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.BillingBenefits.Models.ManagedServiceIdentity>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.BillingBenefits.Models.ManagedServiceIdentity>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.BillingBenefits.Models.ManagedServiceIdentity System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.BillingBenefits.Models.ManagedServiceIdentity>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.BillingBenefits.Models.ManagedServiceIdentity>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.BillingBenefits.Models.ManagedServiceIdentity>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ManagedServiceIdentityType : System.IEquatable<Azure.ResourceManager.BillingBenefits.Models.ManagedServiceIdentityType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ManagedServiceIdentityType(string value) { throw null; }
        public static Azure.ResourceManager.BillingBenefits.Models.ManagedServiceIdentityType None { get { throw null; } }
        public static Azure.ResourceManager.BillingBenefits.Models.ManagedServiceIdentityType SystemAssigned { get { throw null; } }
        public static Azure.ResourceManager.BillingBenefits.Models.ManagedServiceIdentityType SystemAssignedUserAssigned { get { throw null; } }
        public static Azure.ResourceManager.BillingBenefits.Models.ManagedServiceIdentityType UserAssigned { get { throw null; } }
        public bool Equals(Azure.ResourceManager.BillingBenefits.Models.ManagedServiceIdentityType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.BillingBenefits.Models.ManagedServiceIdentityType left, Azure.ResourceManager.BillingBenefits.Models.ManagedServiceIdentityType right) { throw null; }
        public static implicit operator Azure.ResourceManager.BillingBenefits.Models.ManagedServiceIdentityType (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.BillingBenefits.Models.ManagedServiceIdentityType? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.BillingBenefits.Models.ManagedServiceIdentityType left, Azure.ResourceManager.BillingBenefits.Models.ManagedServiceIdentityType right) { throw null; }
        public override string ToString() { throw null; }
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
    public partial class PaymentDetail : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.BillingBenefits.Models.PaymentDetail>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.BillingBenefits.Models.PaymentDetail>
    {
        internal PaymentDetail() { }
        public string BillingAccount { get { throw null; } }
        public Azure.ResourceManager.BillingBenefits.Models.Price BillingCurrencyTotal { get { throw null; } }
        public System.DateTimeOffset? DueOn { get { throw null; } }
        public Azure.ResourceManager.BillingBenefits.Models.ExtendedStatusInfo ExtendedStatusInfo { get { throw null; } }
        public System.DateTimeOffset? PaymentOn { get { throw null; } }
        public Azure.ResourceManager.BillingBenefits.Models.Price PricingCurrencyTotal { get { throw null; } }
        public Azure.ResourceManager.BillingBenefits.Models.PaymentStatus? Status { get { throw null; } }
        protected virtual Azure.ResourceManager.BillingBenefits.Models.PaymentDetail JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.BillingBenefits.Models.PaymentDetail PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.BillingBenefits.Models.PaymentDetail System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.BillingBenefits.Models.PaymentDetail>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.BillingBenefits.Models.PaymentDetail>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.BillingBenefits.Models.PaymentDetail System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.BillingBenefits.Models.PaymentDetail>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.BillingBenefits.Models.PaymentDetail>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.BillingBenefits.Models.PaymentDetail>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.BillingBenefits.Models.PaymentStatus left, Azure.ResourceManager.BillingBenefits.Models.PaymentStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.BillingBenefits.Models.PaymentStatus (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.BillingBenefits.Models.PaymentStatus? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.BillingBenefits.Models.PaymentStatus left, Azure.ResourceManager.BillingBenefits.Models.PaymentStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class Price : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.BillingBenefits.Models.Price>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.BillingBenefits.Models.Price>
    {
        public Price() { }
        public double? Amount { get { throw null; } set { } }
        public string CurrencyCode { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.BillingBenefits.Models.Price JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.BillingBenefits.Models.Price PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.BillingBenefits.Models.Price System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.BillingBenefits.Models.Price>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.BillingBenefits.Models.Price>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.BillingBenefits.Models.Price System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.BillingBenefits.Models.Price>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.BillingBenefits.Models.Price>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.BillingBenefits.Models.Price>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
    public partial class PrimaryConditionalCreditProperties : Azure.ResourceManager.BillingBenefits.Models.ConditionalCreditProperties, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.BillingBenefits.Models.PrimaryConditionalCreditProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.BillingBenefits.Models.PrimaryConditionalCreditProperties>
    {
        public PrimaryConditionalCreditProperties() { }
        public Azure.ResourceManager.BillingBenefits.Models.EnablementMode? AllowContributors { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.BillingBenefits.Models.ConditionalCreditMilestone> Milestones { get { throw null; } }
        public string SystemId { get { throw null; } set { } }
        protected override Azure.ResourceManager.BillingBenefits.Models.ConditionalCreditProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.ResourceManager.BillingBenefits.Models.ConditionalCreditProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.BillingBenefits.Models.PrimaryConditionalCreditProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.BillingBenefits.Models.PrimaryConditionalCreditProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.BillingBenefits.Models.PrimaryConditionalCreditProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.BillingBenefits.Models.PrimaryConditionalCreditProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.BillingBenefits.Models.PrimaryConditionalCreditProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.BillingBenefits.Models.PrimaryConditionalCreditProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.BillingBenefits.Models.PrimaryConditionalCreditProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.BillingBenefits.Models.ProvisioningState left, Azure.ResourceManager.BillingBenefits.Models.ProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.BillingBenefits.Models.ProvisioningState (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.BillingBenefits.Models.ProvisioningState? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.BillingBenefits.Models.ProvisioningState left, Azure.ResourceManager.BillingBenefits.Models.ProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
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
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.BillingBenefits.Models.ReservedResourceType left, Azure.ResourceManager.BillingBenefits.Models.ReservedResourceType right) { throw null; }
        public static implicit operator Azure.ResourceManager.BillingBenefits.Models.ReservedResourceType (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.BillingBenefits.Models.ReservedResourceType? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.BillingBenefits.Models.ReservedResourceType left, Azure.ResourceManager.BillingBenefits.Models.ReservedResourceType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class RoleAssignmentEntity : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.BillingBenefits.Models.RoleAssignmentEntity>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.BillingBenefits.Models.RoleAssignmentEntity>
    {
        internal RoleAssignmentEntity() { }
        public string Id { get { throw null; } }
        public string Name { get { throw null; } }
        public string PrincipalId { get { throw null; } }
        public string RoleDefinitionId { get { throw null; } }
        public string Scope { get { throw null; } }
        protected virtual Azure.ResourceManager.BillingBenefits.Models.RoleAssignmentEntity JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.BillingBenefits.Models.RoleAssignmentEntity PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.BillingBenefits.Models.RoleAssignmentEntity System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.BillingBenefits.Models.RoleAssignmentEntity>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.BillingBenefits.Models.RoleAssignmentEntity>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.BillingBenefits.Models.RoleAssignmentEntity System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.BillingBenefits.Models.RoleAssignmentEntity>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.BillingBenefits.Models.RoleAssignmentEntity>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.BillingBenefits.Models.RoleAssignmentEntity>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SavingsPlanModelPatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.BillingBenefits.Models.SavingsPlanModelPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.BillingBenefits.Models.SavingsPlanModelPatch>
    {
        public SavingsPlanModelPatch() { }
        public Azure.ResourceManager.BillingBenefits.Models.SavingsPlanUpdateRequestProperties Properties { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.BillingBenefits.Models.SavingsPlanModelPatch JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.BillingBenefits.Models.SavingsPlanModelPatch PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.BillingBenefits.Models.SavingsPlanModelPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.BillingBenefits.Models.SavingsPlanModelPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.BillingBenefits.Models.SavingsPlanModelPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.BillingBenefits.Models.SavingsPlanModelPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.BillingBenefits.Models.SavingsPlanModelPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.BillingBenefits.Models.SavingsPlanModelPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.BillingBenefits.Models.SavingsPlanModelPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SavingsPlanUpdateRequestProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.BillingBenefits.Models.SavingsPlanUpdateRequestProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.BillingBenefits.Models.SavingsPlanUpdateRequestProperties>
    {
        public SavingsPlanUpdateRequestProperties() { }
        public Azure.ResourceManager.BillingBenefits.Models.AppliedScopeProperties AppliedScopeProperties { get { throw null; } set { } }
        public Azure.ResourceManager.BillingBenefits.Models.AppliedScopeType? AppliedScopeType { get { throw null; } set { } }
        public string DisplayName { get { throw null; } set { } }
        public bool? Renew { get { throw null; } set { } }
        public Azure.ResourceManager.BillingBenefits.Models.BillingBenefitsPurchaseContent RenewPurchaseProperties { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.BillingBenefits.Models.SavingsPlanUpdateRequestProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.BillingBenefits.Models.SavingsPlanUpdateRequestProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.BillingBenefits.Models.SavingsPlanUpdateRequestProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.BillingBenefits.Models.SavingsPlanUpdateRequestProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.BillingBenefits.Models.SavingsPlanUpdateRequestProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.BillingBenefits.Models.SavingsPlanUpdateRequestProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.BillingBenefits.Models.SavingsPlanUpdateRequestProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.BillingBenefits.Models.SavingsPlanUpdateRequestProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.BillingBenefits.Models.SavingsPlanUpdateRequestProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SavingsPlanValidateModel : Azure.ResourceManager.BillingBenefits.Models.BenefitValidateModel, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.BillingBenefits.Models.SavingsPlanValidateModel>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.BillingBenefits.Models.SavingsPlanValidateModel>
    {
        internal SavingsPlanValidateModel() { }
        public Azure.ResourceManager.BillingBenefits.Models.AppliedScopeProperties AppliedScopeProperties { get { throw null; } set { } }
        public Azure.ResourceManager.BillingBenefits.Models.AppliedScopeType? AppliedScopeType { get { throw null; } set { } }
        public Azure.ResourceManager.BillingBenefits.Models.BillingPlan? BillingPlan { get { throw null; } set { } }
        public string BillingScopeId { get { throw null; } set { } }
        public Azure.ResourceManager.BillingBenefits.Models.Commitment Commitment { get { throw null; } set { } }
        public string DisplayName { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier Id { get { throw null; } }
        public string Kind { get { throw null; } set { } }
        public string Name { get { throw null; } }
        public Azure.ResourceManager.BillingBenefits.Models.ProvisioningState? ProvisioningState { get { throw null; } }
        public bool? Renew { get { throw null; } set { } }
        public string SavingsPlanOrderId { get { throw null; } }
        public string SkuName { get { throw null; } }
        public Azure.ResourceManager.Models.SystemData SystemData { get { throw null; } }
        public Azure.ResourceManager.BillingBenefits.Models.Term? Term { get { throw null; } set { } }
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
    public partial class SavingsPlanValidResponseProperty : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.BillingBenefits.Models.SavingsPlanValidResponseProperty>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.BillingBenefits.Models.SavingsPlanValidResponseProperty>
    {
        internal SavingsPlanValidResponseProperty() { }
        public string Reason { get { throw null; } }
        public string ReasonCode { get { throw null; } }
        public bool? Valid { get { throw null; } }
        protected virtual Azure.ResourceManager.BillingBenefits.Models.SavingsPlanValidResponseProperty JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.BillingBenefits.Models.SavingsPlanValidResponseProperty PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.BillingBenefits.Models.SavingsPlanValidResponseProperty System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.BillingBenefits.Models.SavingsPlanValidResponseProperty>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.BillingBenefits.Models.SavingsPlanValidResponseProperty>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.BillingBenefits.Models.SavingsPlanValidResponseProperty System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.BillingBenefits.Models.SavingsPlanValidResponseProperty>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.BillingBenefits.Models.SavingsPlanValidResponseProperty>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.BillingBenefits.Models.SavingsPlanValidResponseProperty>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class Shortfall : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.BillingBenefits.Models.Shortfall>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.BillingBenefits.Models.Shortfall>
    {
        public Shortfall() { }
        public float? BalanceVersion { get { throw null; } set { } }
        public Azure.ResourceManager.BillingBenefits.Models.Commitment Charge { get { throw null; } set { } }
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
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct Term : System.IEquatable<Azure.ResourceManager.BillingBenefits.Models.Term>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public Term(string value) { throw null; }
        public static Azure.ResourceManager.BillingBenefits.Models.Term P1M { get { throw null; } }
        public static Azure.ResourceManager.BillingBenefits.Models.Term P1Y { get { throw null; } }
        public static Azure.ResourceManager.BillingBenefits.Models.Term P3Y { get { throw null; } }
        public static Azure.ResourceManager.BillingBenefits.Models.Term P5Y { get { throw null; } }
        public bool Equals(Azure.ResourceManager.BillingBenefits.Models.Term other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.BillingBenefits.Models.Term left, Azure.ResourceManager.BillingBenefits.Models.Term right) { throw null; }
        public static implicit operator Azure.ResourceManager.BillingBenefits.Models.Term (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.BillingBenefits.Models.Term? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.BillingBenefits.Models.Term left, Azure.ResourceManager.BillingBenefits.Models.Term right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class Utilization : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.BillingBenefits.Models.Utilization>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.BillingBenefits.Models.Utilization>
    {
        internal Utilization() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.BillingBenefits.Models.UtilizationAggregates> Aggregates { get { throw null; } }
        public string Trend { get { throw null; } }
        protected virtual Azure.ResourceManager.BillingBenefits.Models.Utilization JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.BillingBenefits.Models.Utilization PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.BillingBenefits.Models.Utilization System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.BillingBenefits.Models.Utilization>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.BillingBenefits.Models.Utilization>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.BillingBenefits.Models.Utilization System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.BillingBenefits.Models.Utilization>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.BillingBenefits.Models.Utilization>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.BillingBenefits.Models.Utilization>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class UtilizationAggregates : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.BillingBenefits.Models.UtilizationAggregates>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.BillingBenefits.Models.UtilizationAggregates>
    {
        internal UtilizationAggregates() { }
        public float? Grain { get { throw null; } }
        public string GrainUnit { get { throw null; } }
        public float? Value { get { throw null; } }
        public string ValueUnit { get { throw null; } }
        protected virtual Azure.ResourceManager.BillingBenefits.Models.UtilizationAggregates JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.BillingBenefits.Models.UtilizationAggregates PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.BillingBenefits.Models.UtilizationAggregates System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.BillingBenefits.Models.UtilizationAggregates>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.BillingBenefits.Models.UtilizationAggregates>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.BillingBenefits.Models.UtilizationAggregates System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.BillingBenefits.Models.UtilizationAggregates>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.BillingBenefits.Models.UtilizationAggregates>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.BillingBenefits.Models.UtilizationAggregates>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
}
