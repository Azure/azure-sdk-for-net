namespace Azure.Provisioning.Billing
{
    public enum AgreementAcceptanceMode
    {
        Other = 0,
        ClickToAccept = 1,
        ESignEmbedded = 2,
        ESignOffline = 3,
        Implicit = 4,
        Offline = 5,
        PhysicalSign = 6,
    }
    public partial class BillingAccount : Azure.Provisioning.Primitives.ProvisionableResource
    {
        internal BillingAccount() : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.Billing.BillingAccountProperties Properties { get { throw null; } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Billing.BillingAccount FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public override Azure.Provisioning.Primitives.ResourceNameRequirements GetResourceNameRequirements() { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2024_04_01;
        }
    }
    public partial class BillingAccountEnrollmentDetails : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public BillingAccountEnrollmentDetails() { }
        public Azure.Provisioning.BicepValue<string> BillingCycle { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Channel { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Cloud { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> CountryCode { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Currency { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> EndsOn { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Billing.ExtendedTermOption> ExtendedTermOption { get { throw null; } }
        public Azure.Provisioning.Billing.EnrollmentDetailsIndirectRelationshipInfo IndirectRelationshipInfo { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> InvoiceRecipient { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Language { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Billing.EnrollmentMarkupStatus> MarkupStatus { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> PoNumber { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> StartsOn { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> SupportCoverage { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Billing.BillingEnrollmentSupportLevel> SupportLevel { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class BillingAccountPaymentMethod : Azure.Provisioning.Primitives.ProvisionableResource
    {
        internal BillingAccountPaymentMethod() : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<string> AccountHolderName { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> DisplayName { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Expiration { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Billing.PaymentMethodFamily> Family { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> LastFourDigits { get { throw null; } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Billing.PaymentMethodLogo> Logos { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.Billing.BillingAccount Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> PaymentMethodId { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> PaymentMethodType { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Billing.PaymentMethodStatus> Status { get { throw null; } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Billing.BillingAccountPaymentMethod FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2024_04_01;
        }
    }
    public partial class BillingAccountPolicy : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public BillingAccountPolicy(string bicepIdentifier, string resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } }
        public Azure.Provisioning.Billing.BillingAccount Parent { get { throw null; } set { } }
        public Azure.Provisioning.Billing.BillingAccountPolicyProperties Properties { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Billing.BillingAccountPolicy FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2024_04_01;
        }
    }
    public partial class BillingAccountPolicyProperties : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public BillingAccountPolicyProperties() { }
        public Azure.Provisioning.Billing.BillingAccountPolicyPropertiesEnterpriseAgreementPolicies EnterpriseAgreementPolicies { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Billing.MarketplacePurchasesPolicy> MarketplacePurchases { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Billing.BillingPolicySummary> Policies { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Billing.BillingProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Billing.ReservationPurchasesPolicy> ReservationPurchases { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Billing.SavingsPlanPurchasesPolicy> SavingsPlanPurchases { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class BillingAccountPolicyPropertiesEnterpriseAgreementPolicies : Azure.Provisioning.Billing.EnterpriseAgreementPolicies
    {
        public BillingAccountPolicyPropertiesEnterpriseAgreementPolicies() { }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class BillingAccountProperties : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public BillingAccountProperties() { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Billing.BillingAccountStatus> AccountStatus { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Billing.BillingAccountStatusReasonCode> AccountStatusReasonCode { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Billing.BillingAccountSubType> AccountSubType { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Billing.BillingAccountType> AccountType { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Billing.BillingAgreementType> AgreementType { get { throw null; } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Billing.BillingRelationshipType> BillingRelationshipTypes { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> DisplayName { get { throw null; } }
        public Azure.Provisioning.Billing.BillingAccountPropertiesEnrollmentDetails EnrollmentDetails { get { throw null; } }
        public Azure.Provisioning.BicepValue<bool> HasNoBillingProfiles { get { throw null; } }
        public Azure.Provisioning.BicepValue<bool> HasReadAccess { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> NotificationEmailAddress { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> PrimaryBillingTenantId { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Billing.BillingProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.BicepList<string> Qualifications { get { throw null; } }
        public Azure.Provisioning.Billing.BillingAccountPropertiesRegistrationNumber RegistrationNumber { get { throw null; } }
        public Azure.Provisioning.Billing.BillingAccountPropertiesSoldTo SoldTo { get { throw null; } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Billing.BillingTaxIdentifier> TaxIds { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class BillingAccountPropertiesEnrollmentDetails : Azure.Provisioning.Billing.BillingAccountEnrollmentDetails
    {
        public BillingAccountPropertiesEnrollmentDetails() { }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class BillingAccountPropertiesRegistrationNumber : Azure.Provisioning.Billing.BillingRegistrationNumber
    {
        public BillingAccountPropertiesRegistrationNumber() { }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class BillingAccountPropertiesSoldTo : Azure.Provisioning.Billing.BillingAddressDetails
    {
        public BillingAccountPropertiesSoldTo() { }
        protected override void DefineProvisionableProperties() { }
    }
    public enum BillingAccountStatus
    {
        Other = 0,
        Active = 1,
        UnderReview = 2,
        Disabled = 3,
        Deleted = 4,
        Extended = 5,
        Pending = 6,
        New = 7,
        Expired = 8,
        Terminated = 9,
        Transferred = 10,
    }
    public enum BillingAccountStatusReasonCode
    {
        Other = 0,
        UnusualActivity = 1,
        ManuallyTerminated = 2,
        Expired = 3,
        Transferred = 4,
        TerminateProcessing = 5,
    }
    public enum BillingAccountSubType
    {
        Other = 0,
        None = 1,
        Individual = 2,
        Professional = 3,
        Enterprise = 4,
    }
    public enum BillingAccountType
    {
        Other = 0,
        Enterprise = 1,
        Individual = 2,
        Partner = 3,
        Reseller = 4,
        ClassicPartner = 5,
        Internal = 6,
        Tenant = 7,
        Business = 8,
    }
    public partial class BillingAddressDetails : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public BillingAddressDetails() { }
        public Azure.Provisioning.BicepValue<string> AddressLine1 { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> AddressLine2 { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> AddressLine3 { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> City { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> CompanyName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Country { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> District { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Email { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> FirstName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsValidAddress { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> LastName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> MiddleName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> PhoneNumber { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> PostalCode { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Region { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class BillingAgreement : Azure.Provisioning.Primitives.ProvisionableResource
    {
        internal BillingAgreement() : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.Billing.BillingAccount Parent { get { throw null; } set { } }
        public Azure.Provisioning.Billing.BillingAgreementProperties Properties { get { throw null; } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Billing.BillingAgreement FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public override Azure.Provisioning.Primitives.ResourceNameRequirements GetResourceNameRequirements() { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2024_04_01;
        }
    }
    public enum BillingAgreementCategory
    {
        Other = 0,
        AffiliatePurchaseTerms = 1,
        IndirectForGovernmentAgreement = 2,
        MicrosoftCustomerAgreement = 3,
        MicrosoftPartnerAgreement = 4,
        UKCloudComputeFramework = 5,
    }
    public partial class BillingAgreementParticipant : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public BillingAgreementParticipant() { }
        public Azure.Provisioning.BicepValue<string> Email { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Status { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> StatusOn { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class BillingAgreementProperties : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public BillingAgreementProperties() { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Billing.AgreementAcceptanceMode> AcceptanceMode { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> AgreementLink { get { throw null; } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Billing.BillingProfileInfo> BillingProfileInfo { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Billing.BillingAgreementCategory> Category { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> DisplayName { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> EffectiveOn { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> ExpiresOn { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> LeadBillingAccountName { get { throw null; } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Billing.BillingAgreementParticipant> Participants { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Status { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum BillingAgreementType
    {
        Other = 0,
        MicrosoftCustomerAgreement = 1,
        EnterpriseAgreement = 2,
        MicrosoftOnlineServicesProgram = 3,
        MicrosoftPartnerAgreement = 4,
    }
    public partial class BillingAmount : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public BillingAmount() { }
        public Azure.Provisioning.BicepValue<string> Currency { get { throw null; } }
        public Azure.Provisioning.BicepValue<float> Value { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class BillingAppliedScopeProperties : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public BillingAppliedScopeProperties() { }
        public Azure.Provisioning.BicepValue<string> DisplayName { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> ManagementGroupId { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> ResourceGroupId { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> SubscriptionId { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> TenantId { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum BillingAppliedScopeType
    {
        Single = 0,
        Shared = 1,
        ManagementGroup = 2,
    }
    public partial class BillingAssociatedTenant : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public BillingAssociatedTenant(string bicepIdentifier, string resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.Billing.BillingAccount Parent { get { throw null; } set { } }
        public Azure.Provisioning.Billing.BillingAssociatedTenantProperties Properties { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Billing.BillingAssociatedTenant FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public override Azure.Provisioning.Primitives.ResourceNameRequirements GetResourceNameRequirements() { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2024_04_01;
        }
    }
    public partial class BillingAssociatedTenantProperties : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public BillingAssociatedTenantProperties() { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Billing.BillingManagementTenantState> BillingManagementState { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> DisplayName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ProvisioningBillingRequestId { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Billing.BillingProvisioningTenantState> ProvisioningManagementState { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Billing.BillingProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> TenantId { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class BillingAzurePlan : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public BillingAzurePlan() { }
        public Azure.Provisioning.BicepValue<string> ProductId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> SkuDescription { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> SkuId { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class BillingBeneficiary : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public BillingBeneficiary() { }
        public Azure.Provisioning.BicepValue<string> ObjectId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> TenantId { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class BillingBenefitCommitment : Azure.Provisioning.Billing.BillingPrice
    {
        public BillingBenefitCommitment() { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Billing.BillingBenefitCommitmentGrain> Grain { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum BillingBenefitCommitmentGrain
    {
        Hourly = 0,
    }
    public partial class BillingCustomer : Azure.Provisioning.Primitives.ProvisionableResource
    {
        internal BillingCustomer() : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.Billing.BillingAccount Parent { get { throw null; } set { } }
        public Azure.Provisioning.Billing.BillingCustomerProperties Properties { get { throw null; } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Billing.BillingCustomer FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public override Azure.Provisioning.Primitives.ResourceNameRequirements GetResourceNameRequirements() { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2024_04_01;
        }
    }
    public partial class BillingCustomerPolicy : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public BillingCustomerPolicy(string bicepIdentifier, string resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } }
        public Azure.Provisioning.Billing.BillingCustomer Parent { get { throw null; } set { } }
        public Azure.Provisioning.Billing.BillingCustomerPolicyProperties Properties { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Billing.BillingCustomerPolicy FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2024_04_01;
        }
    }
    public partial class BillingCustomerPolicyProperties : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public BillingCustomerPolicyProperties() { }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Billing.BillingPolicySummary> Policies { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Billing.BillingProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Billing.ViewChargesPolicy> ViewCharges { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class BillingCustomerProperties : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public BillingCustomerProperties() { }
        public Azure.Provisioning.BicepValue<string> BillingProfileDisplayName { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> BillingProfileId { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> DisplayName { get { throw null; } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Billing.BillingAzurePlan> EnabledAzurePlans { get { throw null; } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Billing.CreatedSubscriptionReseller> Resellers { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Billing.BillingCustomerStatus> Status { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> SystemId { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class BillingCustomerRoleAssignment : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public BillingCustomerRoleAssignment(string bicepIdentifier, string resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.Billing.BillingProfileCustomer Parent { get { throw null; } set { } }
        public Azure.Provisioning.Billing.BillingRoleAssignmentProperties Properties { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Billing.BillingCustomerRoleAssignment FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public override Azure.Provisioning.Primitives.ResourceNameRequirements GetResourceNameRequirements() { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2024_04_01;
        }
    }
    public partial class BillingCustomerRoleDefinition : Azure.Provisioning.Primitives.ProvisionableResource
    {
        internal BillingCustomerRoleDefinition() : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.Billing.BillingProfileCustomer Parent { get { throw null; } set { } }
        public Azure.Provisioning.Billing.BillingRoleDefinitionProperties Properties { get { throw null; } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Billing.BillingCustomerRoleDefinition FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public override Azure.Provisioning.Primitives.ResourceNameRequirements GetResourceNameRequirements() { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2024_04_01;
        }
    }
    public enum BillingCustomerStatus
    {
        Other = 0,
        Active = 1,
        Pending = 2,
        Disabled = 3,
        Warned = 4,
        Deleted = 5,
        UnderReview = 6,
    }
    public partial class BillingDepartment : Azure.Provisioning.Primitives.ProvisionableResource
    {
        internal BillingDepartment() : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.Billing.BillingAccount Parent { get { throw null; } set { } }
        public Azure.Provisioning.Billing.BillingDepartmentProperties Properties { get { throw null; } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Billing.BillingDepartment FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public override Azure.Provisioning.Primitives.ResourceNameRequirements GetResourceNameRequirements() { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2024_04_01;
        }
    }
    public partial class BillingDepartmentEnrollmentAccount : Azure.Provisioning.Primitives.ProvisionableResource
    {
        internal BillingDepartmentEnrollmentAccount() : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.Billing.BillingDepartment Parent { get { throw null; } set { } }
        public Azure.Provisioning.Billing.BillingEnrollmentAccountProperties Properties { get { throw null; } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Billing.BillingDepartmentEnrollmentAccount FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public override Azure.Provisioning.Primitives.ResourceNameRequirements GetResourceNameRequirements() { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2024_04_01;
        }
    }
    public partial class BillingDepartmentProperties : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public BillingDepartmentProperties() { }
        public Azure.Provisioning.BicepValue<string> CostCenter { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> DisplayName { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Status { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class BillingDepartmentRoleAssignment : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public BillingDepartmentRoleAssignment(string bicepIdentifier, string resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.Billing.BillingDepartment Parent { get { throw null; } set { } }
        public Azure.Provisioning.Billing.BillingRoleAssignmentProperties Properties { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Billing.BillingDepartmentRoleAssignment FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public override Azure.Provisioning.Primitives.ResourceNameRequirements GetResourceNameRequirements() { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2024_04_01;
        }
    }
    public partial class BillingDepartmentRoleDefinition : Azure.Provisioning.Primitives.ProvisionableResource
    {
        internal BillingDepartmentRoleDefinition() : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.Billing.BillingDepartment Parent { get { throw null; } set { } }
        public Azure.Provisioning.Billing.BillingRoleDefinitionProperties Properties { get { throw null; } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Billing.BillingDepartmentRoleDefinition FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public override Azure.Provisioning.Primitives.ResourceNameRequirements GetResourceNameRequirements() { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2024_04_01;
        }
    }
    public enum BillingDocumentSource
    {
        Other = 0,
        [System.Runtime.Serialization.DataMemberAttribute(Name="DRS")]
        Drs = 1,
        [System.Runtime.Serialization.DataMemberAttribute(Name="ENF")]
        Enf = 2,
    }
    public partial class BillingEnrollmentAccount : Azure.Provisioning.Primitives.ProvisionableResource
    {
        internal BillingEnrollmentAccount() : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.Billing.BillingAccount Parent { get { throw null; } set { } }
        public Azure.Provisioning.Billing.BillingEnrollmentAccountProperties Properties { get { throw null; } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Billing.BillingEnrollmentAccount FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public override Azure.Provisioning.Primitives.ResourceNameRequirements GetResourceNameRequirements() { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2024_04_01;
        }
    }
    public partial class BillingEnrollmentAccountProperties : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public BillingEnrollmentAccountProperties() { }
        public Azure.Provisioning.BicepValue<string> AccountOwner { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> AuthType { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> CostCenter { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> DepartmentDisplayName { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> DepartmentId { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> DisplayName { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> EndsOn { get { throw null; } }
        public Azure.Provisioning.BicepValue<bool> IsDevTestEnabled { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> StartsOn { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Status { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class BillingEnrollmentAccountRoleAssignment : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public BillingEnrollmentAccountRoleAssignment(string bicepIdentifier, string resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.Billing.BillingEnrollmentAccount Parent { get { throw null; } set { } }
        public Azure.Provisioning.Billing.BillingRoleAssignmentProperties Properties { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Billing.BillingEnrollmentAccountRoleAssignment FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public override Azure.Provisioning.Primitives.ResourceNameRequirements GetResourceNameRequirements() { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2024_04_01;
        }
    }
    public partial class BillingEnrollmentAccountRoleDefinition : Azure.Provisioning.Primitives.ProvisionableResource
    {
        internal BillingEnrollmentAccountRoleDefinition() : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.Billing.BillingEnrollmentAccount Parent { get { throw null; } set { } }
        public Azure.Provisioning.Billing.BillingRoleDefinitionProperties Properties { get { throw null; } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Billing.BillingEnrollmentAccountRoleDefinition FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public override Azure.Provisioning.Primitives.ResourceNameRequirements GetResourceNameRequirements() { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2024_04_01;
        }
    }
    public enum BillingEnrollmentSupportLevel
    {
        Other = 0,
        Standard = 1,
        [System.Runtime.Serialization.DataMemberAttribute(Name="Pro-Direct")]
        ProDirect = 2,
        Developer = 3,
    }
    public partial class BillingInvoice : Azure.Provisioning.Primitives.ProvisionableResource
    {
        internal BillingInvoice() : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.Billing.BillingInvoiceProperties Properties { get { throw null; } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Billing.BillingInvoice FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public override Azure.Provisioning.Primitives.ResourceNameRequirements GetResourceNameRequirements() { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2024_04_01;
        }
    }
    public partial class BillingInvoiceFailedPayment : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public BillingInvoiceFailedPayment() { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Billing.BillingInvoiceFailedPaymentReason> FailedPaymentReason { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> On { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum BillingInvoiceFailedPaymentReason
    {
        Other = 0,
        BankDeclined = 1,
        CardExpired = 2,
        IncorrectCardDetails = 3,
    }
    public partial class BillingInvoicePayment : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public BillingInvoicePayment() { }
        public Azure.Provisioning.Billing.PaymentAmount Amount { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> MadeOn { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Billing.PaymentMethodFamily> PaymentMethodFamily { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> PaymentMethodId { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> PaymentMethodType { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> PaymentType { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class BillingInvoiceProperties : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public BillingInvoiceProperties() { }
        public Azure.Provisioning.Billing.InvoicePropertiesAmountDue AmountDue { get { throw null; } }
        public Azure.Provisioning.Billing.InvoicePropertiesAzurePrepaymentApplied AzurePrepaymentApplied { get { throw null; } }
        public Azure.Provisioning.Billing.InvoicePropertiesBilledAmount BilledAmount { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> BilledDocumentId { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> BillingProfileDisplayName { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> BillingProfileId { get { throw null; } }
        public Azure.Provisioning.Billing.InvoicePropertiesCreditAmount CreditAmount { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> CreditForDocumentId { get { throw null; } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Billing.InvoiceDocument> Documents { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Billing.InvoiceDocumentType> DocumentType { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> DueOn { get { throw null; } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Billing.BillingInvoiceFailedPayment> FailedPayments { get { throw null; } }
        public Azure.Provisioning.Billing.InvoicePropertiesFreeAzureCreditApplied FreeAzureCreditApplied { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> InvoiceOn { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> InvoicePeriodEndsOn { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> InvoicePeriodStartsOn { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Billing.BillingInvoiceType> InvoiceType { get { throw null; } }
        public Azure.Provisioning.BicepValue<bool> IsMonthlyInvoice { get { throw null; } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Billing.BillingInvoicePayment> Payments { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> PurchaseOrderNumber { get { throw null; } }
        public Azure.Provisioning.Billing.InvoicePropertiesRebillDetails RebillDetails { get { throw null; } }
        public Azure.Provisioning.Billing.InvoicePropertiesRefundDetails RefundDetails { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Billing.SpecialTaxationType> SpecialTaxationType { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Billing.BillingInvoiceStatus> Status { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> SubscriptionDisplayName { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> SubscriptionId { get { throw null; } }
        public Azure.Provisioning.Billing.InvoicePropertiesSubTotal SubTotal { get { throw null; } }
        public Azure.Provisioning.Billing.InvoicePropertiesTaxAmount TaxAmount { get { throw null; } }
        public Azure.Provisioning.Billing.InvoicePropertiesTotalAmount TotalAmount { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class BillingInvoiceSection : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public BillingInvoiceSection(string bicepIdentifier, string resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.Billing.BillingProfile Parent { get { throw null; } set { } }
        public Azure.Provisioning.Billing.BillingInvoiceSectionProperties Properties { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Billing.BillingInvoiceSection FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public override Azure.Provisioning.Primitives.ResourceNameRequirements GetResourceNameRequirements() { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2024_04_01;
        }
    }
    public partial class BillingInvoiceSectionProperties : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public BillingInvoiceSectionProperties() { }
        public Azure.Provisioning.BicepValue<string> DisplayName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Billing.BillingProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Billing.InvoiceSectionStateReasonCode> ReasonCode { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Billing.InvoiceSectionState> State { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> SystemId { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> TargetCloud { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class BillingInvoiceSectionRoleAssignment : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public BillingInvoiceSectionRoleAssignment(string bicepIdentifier, string resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.Billing.BillingInvoiceSection Parent { get { throw null; } set { } }
        public Azure.Provisioning.Billing.BillingRoleAssignmentProperties Properties { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Billing.BillingInvoiceSectionRoleAssignment FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public override Azure.Provisioning.Primitives.ResourceNameRequirements GetResourceNameRequirements() { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2024_04_01;
        }
    }
    public partial class BillingInvoiceSectionRoleDefinition : Azure.Provisioning.Primitives.ProvisionableResource
    {
        internal BillingInvoiceSectionRoleDefinition() : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.Billing.BillingInvoiceSection Parent { get { throw null; } set { } }
        public Azure.Provisioning.Billing.BillingRoleDefinitionProperties Properties { get { throw null; } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Billing.BillingInvoiceSectionRoleDefinition FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public override Azure.Provisioning.Primitives.ResourceNameRequirements GetResourceNameRequirements() { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2024_04_01;
        }
    }
    public enum BillingInvoiceStatus
    {
        Other = 0,
        Due = 1,
        OverDue = 2,
        Paid = 3,
        Void = 4,
        Locked = 5,
    }
    public enum BillingInvoiceType
    {
        Other = 0,
        AzureServices = 1,
        AzureMarketplace = 2,
        AzureSupport = 3,
    }
    public enum BillingManagementTenantState
    {
        Other = 0,
        NotAllowed = 1,
        Active = 2,
        Revoked = 3,
    }
    public partial class BillingPaymentMethod : Azure.Provisioning.Primitives.ProvisionableResource
    {
        internal BillingPaymentMethod() : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<string> AccountHolderName { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> DisplayName { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Expiration { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Billing.PaymentMethodFamily> Family { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> LastFourDigits { get { throw null; } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Billing.PaymentMethodLogo> Logos { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> PaymentMethodId { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> PaymentMethodType { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Billing.PaymentMethodStatus> Status { get { throw null; } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Billing.BillingPaymentMethod FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2024_04_01;
        }
    }
    public partial class BillingPaymentMethodLink : Azure.Provisioning.Primitives.ProvisionableResource
    {
        internal BillingPaymentMethodLink() : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<string> AccountHolderName { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> DisplayName { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Expiration { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Billing.PaymentMethodFamily> Family { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> LastFourDigits { get { throw null; } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Billing.PaymentMethodLogo> Logos { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.Billing.BillingProfile Parent { get { throw null; } set { } }
        public Azure.Provisioning.Billing.PaymentMethodProjectionProperties PaymentMethod { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> PaymentMethodId { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> PaymentMethodType { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Billing.PaymentMethodStatus> Status { get { throw null; } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Billing.BillingPaymentMethodLink FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2024_04_01;
        }
    }
    public enum BillingPaymentStatus
    {
        Succeeded = 0,
        Failed = 1,
        Scheduled = 2,
        Cancelled = 3,
        Completed = 4,
        Pending = 5,
    }
    public partial class BillingPaymentTerm : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public BillingPaymentTerm() { }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> EndsOn { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsDefault { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> StartsOn { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Term { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class BillingPermission : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public BillingPermission() { }
        public Azure.Provisioning.BicepList<string> Actions { get { throw null; } }
        public Azure.Provisioning.BicepList<string> NotActions { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum BillingPlan
    {
        P1M = 0,
    }
    public partial class BillingPlanInformation : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public BillingPlanInformation() { }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> NextPaymentDueOn { get { throw null; } }
        public Azure.Provisioning.Billing.BillingPrice PricingCurrencyTotal { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> StartsOn { get { throw null; } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Billing.BillingPlanPaymentDetail> Transactions { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class BillingPlanPaymentDetail : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public BillingPlanPaymentDetail() { }
        public Azure.Provisioning.Billing.BillingPrice BillingCurrencyTotal { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> DueOn { get { throw null; } }
        public Azure.Provisioning.Billing.ExtendedStatusInfo ExtendedStatusInfo { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> PaymentCompletedOn { get { throw null; } }
        public Azure.Provisioning.Billing.BillingPrice PricingCurrencyTotal { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Billing.BillingPaymentStatus> Status { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class BillingPolicySummary : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public BillingPolicySummary() { }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Billing.BillingPolicyType> PolicyType { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Scope { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Value { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum BillingPolicyType
    {
        Other = 0,
        UserControlled = 1,
        SystemControlled = 2,
    }
    public partial class BillingPrice : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public BillingPrice() { }
        public Azure.Provisioning.BicepValue<double> Amount { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> CurrencyCode { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class BillingPrincipal : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public BillingPrincipal() { }
        public Azure.Provisioning.BicepValue<string> ObjectId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> TenantId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Upn { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum BillingPrincipalType
    {
        Unknown = 0,
        None = 1,
        User = 2,
        Group = 3,
        DirectoryRole = 4,
        ServicePrincipal = 5,
        Everyone = 6,
    }
    public partial class BillingProduct : Azure.Provisioning.Primitives.ProvisionableResource
    {
        internal BillingProduct() : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.Billing.BillingAccount Parent { get { throw null; } set { } }
        public Azure.Provisioning.Billing.BillingProductProperties Properties { get { throw null; } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Billing.BillingProduct FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public override Azure.Provisioning.Primitives.ResourceNameRequirements GetResourceNameRequirements() { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2024_04_01;
        }
    }
    public partial class BillingProductProperties : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public BillingProductProperties() { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Billing.BillingSubscriptionAutoRenewState> AutoRenew { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> AvailabilityId { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> BillingFrequency { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> BillingProfileDisplayName { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> BillingProfileId { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> CustomerDisplayName { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> CustomerId { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> DisplayName { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> EndDate { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> InvoiceSectionDisplayName { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> InvoiceSectionId { get { throw null; } }
        public Azure.Provisioning.Billing.ProductPropertiesLastCharge LastCharge { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> LastChargeDate { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> ProductType { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> ProductTypeId { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> PurchaseDate { get { throw null; } }
        public Azure.Provisioning.BicepValue<long> Quantity { get { throw null; } }
        public Azure.Provisioning.Billing.ProductPropertiesReseller Reseller { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> SkuDescription { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> SkuId { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Billing.BillingProductStatus> Status { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> TenantId { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum BillingProductStatus
    {
        Other = 0,
        Active = 1,
        Disabled = 2,
        Deleted = 3,
        PastDue = 4,
        Expiring = 5,
        Expired = 6,
        AutoRenew = 7,
        Canceled = 8,
        Suspended = 9,
    }
    public enum BillingProductTransferStatus
    {
        NotStarted = 0,
        InProgress = 1,
        Completed = 2,
        Failed = 3,
    }
    public enum BillingProductType
    {
        AzureSubscription = 0,
        AzureReservation = 1,
        Department = 2,
        SavingsPlan = 3,
        [System.Runtime.Serialization.DataMemberAttribute(Name="SAAS")]
        Saas = 4,
    }
    public partial class BillingProfile : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public BillingProfile(string bicepIdentifier, string resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.Billing.BillingAccount Parent { get { throw null; } set { } }
        public Azure.Provisioning.Billing.BillingProfileProperties Properties { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Billing.BillingProfile FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public override Azure.Provisioning.Primitives.ResourceNameRequirements GetResourceNameRequirements() { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2024_04_01;
        }
    }
    public partial class BillingProfileCustomer : Azure.Provisioning.Primitives.ProvisionableResource
    {
        internal BillingProfileCustomer() : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.Billing.BillingProfile Parent { get { throw null; } set { } }
        public Azure.Provisioning.Billing.BillingCustomerProperties Properties { get { throw null; } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Billing.BillingProfileCustomer FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public override Azure.Provisioning.Primitives.ResourceNameRequirements GetResourceNameRequirements() { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2024_04_01;
        }
    }
    public partial class BillingProfileCustomerPolicy : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public BillingProfileCustomerPolicy(string bicepIdentifier, string resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.Billing.BillingProfileCustomer Parent { get { throw null; } set { } }
        public Azure.Provisioning.Billing.BillingCustomerPolicyProperties Properties { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Billing.BillingProfileCustomerPolicy FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2024_04_01;
        }
    }
    public partial class BillingProfileInfo : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public BillingProfileInfo() { }
        public Azure.Provisioning.BicepValue<string> BillingAccountId { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> BillingProfileDisplayName { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> BillingProfileId { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> BillingProfileSystemId { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> IndirectRelationshipOrganizationName { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class BillingProfilePolicy : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public BillingProfilePolicy(string bicepIdentifier, string resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } }
        public Azure.Provisioning.Billing.BillingProfile Parent { get { throw null; } set { } }
        public Azure.Provisioning.Billing.BillingProfilePolicyProperties Properties { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Billing.BillingProfilePolicy FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2024_04_01;
        }
    }
    public partial class BillingProfilePolicyProperties : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public BillingProfilePolicyProperties() { }
        public Azure.Provisioning.Billing.BillingProfilePolicyPropertiesEnterpriseAgreementPolicies EnterpriseAgreementPolicies { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Billing.InvoiceSectionLabelManagementPolicy> InvoiceSectionLabelManagement { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Billing.MarketplacePurchasesPolicy> MarketplacePurchases { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Billing.BillingPolicySummary> Policies { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Billing.BillingProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Billing.ReservationPurchasesPolicy> ReservationPurchases { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Billing.SavingsPlanPurchasesPolicy> SavingsPlanPurchases { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Billing.ViewChargesPolicy> ViewCharges { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class BillingProfilePolicyPropertiesEnterpriseAgreementPolicies : Azure.Provisioning.Billing.EnterpriseAgreementPolicies
    {
        public BillingProfilePolicyPropertiesEnterpriseAgreementPolicies() { }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class BillingProfileProperties : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public BillingProfileProperties() { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Billing.BillingRelationshipType> BillingRelationshipType { get { throw null; } }
        public Azure.Provisioning.Billing.BillingProfilePropertiesBillTo BillTo { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Currency { get { throw null; } }
        public Azure.Provisioning.Billing.BillingProfilePropertiesCurrentPaymentTerm CurrentPaymentTerm { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> DisplayName { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Billing.BillingAzurePlan> EnabledAzurePlans { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> HasReadAccess { get { throw null; } }
        public Azure.Provisioning.Billing.BillingProfilePropertiesIndirectRelationshipInfo IndirectRelationshipInfo { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> InvoiceDay { get { throw null; } }
        public Azure.Provisioning.BicepList<string> InvoiceRecipients { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsInvoiceEmailOptIn { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Billing.BillingPaymentTerm> OtherPaymentTerms { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> PoNumber { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Billing.BillingProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.Billing.BillingProfilePropertiesShipTo ShipTo { get { throw null; } set { } }
        public Azure.Provisioning.Billing.BillingProfilePropertiesSoldTo SoldTo { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Billing.BillingSpendingLimit> SpendingLimit { get { throw null; } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Billing.SpendingLimitDetails> SpendingLimitDetails { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Billing.BillingProfileStatus> Status { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Billing.BillingProfileStatusReasonCode> StatusReasonCode { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> SystemId { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<string> TargetClouds { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class BillingProfilePropertiesBillTo : Azure.Provisioning.Billing.BillingAddressDetails
    {
        public BillingProfilePropertiesBillTo() { }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class BillingProfilePropertiesCurrentPaymentTerm : Azure.Provisioning.Billing.BillingPaymentTerm
    {
        public BillingProfilePropertiesCurrentPaymentTerm() { }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class BillingProfilePropertiesIndirectRelationshipInfo : Azure.Provisioning.Billing.IndirectRelationshipInfo
    {
        public BillingProfilePropertiesIndirectRelationshipInfo() { }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class BillingProfilePropertiesShipTo : Azure.Provisioning.Billing.BillingAddressDetails
    {
        public BillingProfilePropertiesShipTo() { }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class BillingProfilePropertiesSoldTo : Azure.Provisioning.Billing.BillingAddressDetails
    {
        public BillingProfilePropertiesSoldTo() { }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class BillingProfileRoleAssignment : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public BillingProfileRoleAssignment(string bicepIdentifier, string resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.Billing.BillingProfile Parent { get { throw null; } set { } }
        public Azure.Provisioning.Billing.BillingRoleAssignmentProperties Properties { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Billing.BillingProfileRoleAssignment FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public override Azure.Provisioning.Primitives.ResourceNameRequirements GetResourceNameRequirements() { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2024_04_01;
        }
    }
    public partial class BillingProfileRoleDefinition : Azure.Provisioning.Primitives.ProvisionableResource
    {
        internal BillingProfileRoleDefinition() : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.Billing.BillingProfile Parent { get { throw null; } set { } }
        public Azure.Provisioning.Billing.BillingRoleDefinitionProperties Properties { get { throw null; } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Billing.BillingProfileRoleDefinition FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public override Azure.Provisioning.Primitives.ResourceNameRequirements GetResourceNameRequirements() { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2024_04_01;
        }
    }
    public enum BillingProfileStatus
    {
        Other = 0,
        Active = 1,
        Disabled = 2,
        Warned = 3,
        Deleted = 4,
        UnderReview = 5,
    }
    public enum BillingProfileStatusReasonCode
    {
        Other = 0,
        PastDue = 1,
        UnusualActivity = 2,
        SpendingLimitReached = 3,
        SpendingLimitExpired = 4,
    }
    public partial class BillingProfileSubscription : Azure.Provisioning.Primitives.ProvisionableResource
    {
        internal BillingProfileSubscription() : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Billing.BillingSubscriptionAutoRenewState> AutoRenew { get { throw null; } }
        public Azure.Provisioning.Billing.BillingBeneficiary Beneficiary { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.Guid> BeneficiaryTenantId { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> BillingFrequency { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> BillingPolicies { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> BillingProfileDisplayName { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> BillingProfileId { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> BillingProfileName { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> ConsumptionCostCenter { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> CustomerDisplayName { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> CustomerId { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> CustomerName { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> DisplayName { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> EnrollmentAccountDisplayName { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> EnrollmentAccountId { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> EnrollmentAccountStartsOn { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> InvoiceSectionDisplayName { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> InvoiceSectionId { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> InvoiceSectionName { get { throw null; } }
        public Azure.Provisioning.Billing.BillingAmount LastMonthCharges { get { throw null; } }
        public Azure.Provisioning.Billing.BillingAmount MonthToDateCharges { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> NextBillingCycleBillingFrequency { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> OfferId { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Billing.BillingSubscriptionOperationStatus> OperationStatus { get { throw null; } }
        public Azure.Provisioning.Billing.BillingProfile Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ProductCategory { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> ProductType { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> ProductTypeId { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Billing.BillingProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.Guid> ProvisioningTenantId { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> PurchaseOn { get { throw null; } }
        public Azure.Provisioning.BicepValue<long> Quantity { get { throw null; } }
        public Azure.Provisioning.Billing.SubscriptionRenewalTermDetails RenewalTermDetails { get { throw null; } }
        public Azure.Provisioning.Billing.CreatedSubscriptionReseller Reseller { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.Uri> ResourceUri { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> SkuDescription { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> SkuId { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Billing.BillingSubscriptionStatus> Status { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Billing.SubscriptionEnrollmentAccountStatus> SubscriptionEnrollmentAccountStatus { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> SubscriptionId { get { throw null; } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Billing.BillingSubscriptionStatusDetails> SuspensionReasonDetails { get { throw null; } }
        public Azure.Provisioning.BicepList<string> SuspensionReasons { get { throw null; } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.Billing.BillingSystemOverrides SystemOverrides { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.TimeSpan> TermDuration { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> TermEndsOn { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> TermStartsOn { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Billing.BillingProfileSubscription FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2024_04_01;
        }
    }
    public partial class BillingProperty : Azure.Provisioning.Primitives.ProvisionableResource
    {
        internal BillingProperty() : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } }
        public Azure.Provisioning.Billing.BillingPropertyProperties Properties { get { throw null; } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Billing.BillingProperty FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2024_04_01;
        }
    }
    public partial class BillingPropertyProperties : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public BillingPropertyProperties() { }
        public Azure.Provisioning.BicepValue<string> AccountAdminNotificationEmailAddress { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Billing.BillingAgreementType> BillingAccountAgreementType { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> BillingAccountDisplayName { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> BillingAccountId { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> BillingAccountSoldToCountry { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Billing.BillingAccountStatus> BillingAccountStatus { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Billing.BillingAccountStatusReasonCode> BillingAccountStatusReasonCode { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Billing.BillingAccountSubType> BillingAccountSubType { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Billing.BillingAccountType> BillingAccountType { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> BillingCurrency { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> BillingProfileDisplayName { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> BillingProfileId { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Billing.PaymentMethodFamily> BillingProfilePaymentMethodFamily { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> BillingProfilePaymentMethodType { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Billing.BillingSpendingLimit> BillingProfileSpendingLimit { get { throw null; } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Billing.SpendingLimitDetails> BillingProfileSpendingLimitDetails { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Billing.BillingProfileStatus> BillingProfileStatus { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Billing.BillingProfileStatusReasonCode> BillingProfileStatusReasonCode { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> BillingTenantId { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> CostCenter { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> CustomerDisplayName { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> CustomerId { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Billing.BillingCustomerStatus> CustomerStatus { get { throw null; } }
        public Azure.Provisioning.Billing.BillingPropertyPropertiesEnrollmentDetails EnrollmentDetails { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> InvoiceSectionDisplayName { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> InvoiceSectionId { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Billing.InvoiceSectionState> InvoiceSectionStatus { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Billing.InvoiceSectionStateReasonCode> InvoiceSectionStatusReasonCode { get { throw null; } }
        public Azure.Provisioning.BicepValue<bool> IsAccountAdmin { get { throw null; } }
        public Azure.Provisioning.BicepValue<bool> IsTransitionedBillingAccount { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> ProductId { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> ProductName { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> SkuDescription { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> SkuId { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Billing.BillingSubscriptionStatus> SubscriptionBillingStatus { get { throw null; } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Billing.BillingSubscriptionStatusDetails> SubscriptionBillingStatusDetails { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Billing.SubscriptionBillingType> SubscriptionBillingType { get { throw null; } }
        public Azure.Provisioning.Billing.BillingPropertyPropertiesSubscriptionServiceUsageAddress SubscriptionServiceUsageAddress { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Billing.SubscriptionWorkloadType> SubscriptionWorkloadType { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class BillingPropertyPropertiesEnrollmentDetails : Azure.Provisioning.Billing.SubscriptionEnrollmentDetails
    {
        public BillingPropertyPropertiesEnrollmentDetails() { }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class BillingPropertyPropertiesSubscriptionServiceUsageAddress : Azure.Provisioning.Billing.BillingAddressDetails
    {
        public BillingPropertyPropertiesSubscriptionServiceUsageAddress() { }
        protected override void DefineProvisionableProperties() { }
    }
    public enum BillingProvisioningState
    {
        Succeeded = 0,
        Canceled = 1,
        Failed = 2,
        New = 3,
        Pending = 4,
        Provisioning = 5,
        PendingBilling = 6,
        ConfirmedBilling = 7,
        Creating = 8,
        Created = 9,
        Expired = 10,
    }
    public enum BillingProvisioningTenantState
    {
        Other = 0,
        NotRequested = 1,
        Active = 2,
        Pending = 3,
        BillingRequestExpired = 4,
        BillingRequestDeclined = 5,
        Revoked = 6,
    }
    public partial class BillingPurchaseProperties : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public BillingPurchaseProperties() { }
        public Azure.Provisioning.Billing.BillingAppliedScopeProperties AppliedScopeProperties { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Billing.BillingAppliedScopeType> AppliedScopeType { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Billing.BillingPlan> BillingPlan { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> BillingScopeId { get { throw null; } }
        public Azure.Provisioning.Billing.BillingBenefitCommitment Commitment { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> DisplayName { get { throw null; } }
        public Azure.Provisioning.BicepValue<bool> IsRenewed { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> SkuName { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Billing.BillingSavingsPlanTerm> Term { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class BillingRegistrationNumber : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public BillingRegistrationNumber() { }
        public Azure.Provisioning.BicepValue<string> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<bool> IsRequired { get { throw null; } }
        public Azure.Provisioning.BicepList<string> RegistrationNumberType { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum BillingRelationshipType
    {
        Other = 0,
        Direct = 1,
        IndirectCustomer = 2,
        IndirectPartner = 3,
        [System.Runtime.Serialization.DataMemberAttribute(Name="CSPPartner")]
        CspPartner = 4,
        [System.Runtime.Serialization.DataMemberAttribute(Name="CSPCustomer")]
        CspCustomer = 5,
    }
    public partial class BillingRequest : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public BillingRequest(string bicepIdentifier, string resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.Billing.BillingRequestProperties Properties { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Billing.BillingRequest FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public override Azure.Provisioning.Primitives.ResourceNameRequirements GetResourceNameRequirements() { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2024_04_01;
        }
    }
    public partial class BillingRequestProperties : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public BillingRequestProperties() { }
        public Azure.Provisioning.BicepDictionary<string> AdditionalInformation { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> BillingAccountDisplayName { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> BillingAccountId { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> BillingAccountName { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> BillingAccountPrimaryBillingTenantId { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> BillingProfileDisplayName { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> BillingProfileId { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> BillingProfileName { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> BillingScope { get { throw null; } }
        public Azure.Provisioning.Billing.BillingRequestPropertiesCreatedBy CreatedBy { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> CreatedOn { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> CustomerDisplayName { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> CustomerId { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> CustomerName { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> DecisionReason { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> ExpiresOn { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> InvoiceSectionDisplayName { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> InvoiceSectionId { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> InvoiceSectionName { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Justification { get { throw null; } set { } }
        public Azure.Provisioning.Billing.BillingRequestPropertiesLastUpdatedBy LastUpdatedBy { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> LastUpdatedOn { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Billing.BillingProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Billing.BillingPrincipal> Recipients { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> RequestScope { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Billing.BillingRequestType> RequestType { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> ReviewalOn { get { throw null; } }
        public Azure.Provisioning.Billing.BillingRequestPropertiesReviewedBy ReviewedBy { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Billing.BillingRequestStatus> Status { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> SubscriptionDisplayName { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> SubscriptionId { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> SubscriptionName { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class BillingRequestPropertiesCreatedBy : Azure.Provisioning.Billing.BillingPrincipal
    {
        public BillingRequestPropertiesCreatedBy() { }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class BillingRequestPropertiesLastUpdatedBy : Azure.Provisioning.Billing.BillingPrincipal
    {
        public BillingRequestPropertiesLastUpdatedBy() { }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class BillingRequestPropertiesReviewedBy : Azure.Provisioning.Billing.BillingPrincipal
    {
        public BillingRequestPropertiesReviewedBy() { }
        protected override void DefineProvisionableProperties() { }
    }
    public enum BillingRequestStatus
    {
        Other = 0,
        Pending = 1,
        Approved = 2,
        Declined = 3,
        Cancelled = 4,
        Completed = 5,
        Expired = 6,
    }
    public enum BillingRequestType
    {
        Other = 0,
        InvoiceAccess = 1,
        ProvisioningAccess = 2,
        RoleAssignment = 3,
        UpdateBillingPolicy = 4,
    }
    public partial class BillingReservation : Azure.Provisioning.Primitives.ProvisionableResource
    {
        internal BillingReservation() : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Billing.ReservationUtilizationAggregates> Aggregates { get { throw null; } }
        public Azure.Provisioning.Billing.ReservationAppliedScopeProperties AppliedScopeProperties { get { throw null; } }
        public Azure.Provisioning.BicepList<string> AppliedScopes { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> AppliedScopeType { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> BenefitStartsOn { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Billing.ReservationBillingPlan> BillingPlan { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> BillingScopeId { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Capabilities { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> DisplayName { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> DisplayProvisioningState { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> EffectiveOn { get { throw null; } }
        public Azure.Provisioning.BicepValue<int> ETag { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> ExpireOn { get { throw null; } }
        public Azure.Provisioning.Billing.ReservationExtendedStatusInfo ExtendedStatusInfo { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Billing.InstanceFlexibility> InstanceFlexibility { get { throw null; } }
        public Azure.Provisioning.BicepValue<bool> IsArchived { get { throw null; } }
        public Azure.Provisioning.BicepValue<bool> IsRenewed { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> LastUpdatedOn { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> Location { get { throw null; } }
        public Azure.Provisioning.Billing.ReservationMergeProperties MergeProperties { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.Billing.BillingReservationOrder Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ProductCode { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> ProvisioningSubState { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> PurchaseOn { get { throw null; } }
        public Azure.Provisioning.BicepValue<float> Quantity { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> RenewDestination { get { throw null; } }
        public Azure.Provisioning.Billing.ReservationRenewProperties RenewProperties { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> RenewSource { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> ReservationExpireOn { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> ReservationPurchaseOn { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> ReservedResourceType { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> ReviewOn { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> SkuDescription { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> SkuName { get { throw null; } }
        public Azure.Provisioning.Billing.ReservationSplitProperties SplitProperties { get { throw null; } }
        public Azure.Provisioning.Billing.ReservationSwapProperties SwapProperties { get { throw null; } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Term { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Trend { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> UserFriendlyAppliedScopeType { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> UserFriendlyRenewState { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Billing.BillingReservation FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2024_04_01;
        }
    }
    public partial class BillingReservationOrder : Azure.Provisioning.Primitives.ProvisionableResource
    {
        internal BillingReservationOrder() : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> BenefitStartsOn { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> BillingAccountId { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Billing.ReservationBillingPlan> BillingPlan { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> BillingProfileId { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> CreatedOn { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> CustomerId { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> DisplayName { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> EnrollmentId { get { throw null; } }
        public Azure.Provisioning.BicepValue<int> ETag { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> ExpireOn { get { throw null; } }
        public Azure.Provisioning.Billing.ReservationExtendedStatusInfo ExtendedStatusInfo { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> OriginalQuantity { get { throw null; } }
        public Azure.Provisioning.Billing.BillingAccount Parent { get { throw null; } set { } }
        public Azure.Provisioning.Billing.ReservationOrderBillingPlanInformation PlanInformation { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> ProductCode { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> RequestOn { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> ReservationExpireOn { get { throw null; } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Billing.BillingReservation> Reservations { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> ReviewedOn { get { throw null; } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Term { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Billing.BillingReservationOrder FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2024_04_01;
        }
    }
    public partial class BillingRoleAssignment : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public BillingRoleAssignment(string bicepIdentifier, string resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.Billing.BillingAccount Parent { get { throw null; } set { } }
        public Azure.Provisioning.Billing.BillingRoleAssignmentProperties Properties { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Billing.BillingRoleAssignment FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public override Azure.Provisioning.Primitives.ResourceNameRequirements GetResourceNameRequirements() { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2024_04_01;
        }
    }
    public partial class BillingRoleAssignmentProperties : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public BillingRoleAssignmentProperties() { }
        public Azure.Provisioning.BicepValue<string> BillingAccountDisplayName { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> BillingAccountId { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> BillingProfileDisplayName { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> BillingProfileId { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> BillingRequestId { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> CreatedByPrincipalId { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> CreatedByPrincipalPuid { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> CreatedByPrincipalTenantId { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> CreatedByUserEmailAddress { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> CreatedOn { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> CustomerDisplayName { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> CustomerId { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> InvoiceSectionDisplayName { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> InvoiceSectionId { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> ModifiedByPrincipalId { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> ModifiedByPrincipalPuid { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> ModifiedByPrincipalTenantId { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> ModifiedByUserEmailAddress { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> ModifiedOn { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> PrincipalDisplayName { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> PrincipalId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> PrincipalPuid { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> PrincipalTenantId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> PrincipalTenantName { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Billing.BillingPrincipalType> PrincipalType { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Billing.BillingProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> RoleDefinitionId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Scope { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> UserAuthenticationType { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> UserEmailAddress { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class BillingRoleDefinition : Azure.Provisioning.Primitives.ProvisionableResource
    {
        internal BillingRoleDefinition() : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.Billing.BillingAccount Parent { get { throw null; } set { } }
        public Azure.Provisioning.Billing.BillingRoleDefinitionProperties Properties { get { throw null; } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Billing.BillingRoleDefinition FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public override Azure.Provisioning.Primitives.ResourceNameRequirements GetResourceNameRequirements() { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2024_04_01;
        }
    }
    public partial class BillingRoleDefinitionProperties : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public BillingRoleDefinitionProperties() { }
        public Azure.Provisioning.BicepValue<string> Description { get { throw null; } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Billing.BillingPermission> Permissions { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> RoleName { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class BillingSavingsPlanModel : Azure.Provisioning.Primitives.ProvisionableResource
    {
        internal BillingSavingsPlanModel() : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.Billing.BillingAppliedScopeProperties AppliedScopeProperties { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Billing.BillingAppliedScopeType> AppliedScopeType { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> BenefitStartsOn { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> BillingAccountId { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Billing.BillingPlan> BillingPlan { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> BillingProfileId { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> BillingScopeId { get { throw null; } }
        public Azure.Provisioning.Billing.BillingBenefitCommitment Commitment { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> CustomerId { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> DisplayName { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> DisplayProvisioningState { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> EffectiveOn { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> ExpiryOn { get { throw null; } }
        public Azure.Provisioning.Billing.ExtendedStatusInfo ExtendedStatusInfo { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<bool> IsRenewed { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.Billing.SavingsPlanOrderModel Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ProductCode { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Billing.BillingProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> PurchaseOn { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> RenewDestination { get { throw null; } }
        public Azure.Provisioning.Billing.BillingPurchaseProperties RenewPurchaseProperties { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> RenewSource { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> SkuName { get { throw null; } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Billing.BillingSavingsPlanTerm> Term { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> UserFriendlyAppliedScopeType { get { throw null; } }
        public Azure.Provisioning.Billing.SavingsPlanUtilization Utilization { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Billing.BillingSavingsPlanModel FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2024_04_01;
        }
    }
    public enum BillingSavingsPlanTerm
    {
        P1Y = 0,
        P3Y = 1,
        P5Y = 2,
    }
    public partial class BillingSku : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public BillingSku() { }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum BillingSpendingLimit
    {
        Off = 0,
        On = 1,
    }
    public partial class BillingSubscription : Azure.Provisioning.Primitives.ProvisionableResource
    {
        internal BillingSubscription() : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Billing.BillingSubscriptionAutoRenewState> AutoRenew { get { throw null; } }
        public Azure.Provisioning.Billing.BillingBeneficiary Beneficiary { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.Guid> BeneficiaryTenantId { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> BillingFrequency { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> BillingPolicies { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> BillingProfileDisplayName { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> BillingProfileId { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> BillingProfileName { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> ConsumptionCostCenter { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> CustomerDisplayName { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> CustomerId { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> CustomerName { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> DisplayName { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> EnrollmentAccountDisplayName { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> EnrollmentAccountId { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> EnrollmentAccountStartsOn { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> InvoiceSectionDisplayName { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> InvoiceSectionId { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> InvoiceSectionName { get { throw null; } }
        public Azure.Provisioning.Billing.BillingAmount LastMonthCharges { get { throw null; } }
        public Azure.Provisioning.Billing.BillingAmount MonthToDateCharges { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> NextBillingCycleBillingFrequency { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> OfferId { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Billing.BillingSubscriptionOperationStatus> OperationStatus { get { throw null; } }
        public Azure.Provisioning.Billing.BillingAccount Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ProductCategory { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> ProductType { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> ProductTypeId { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Billing.BillingProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.Guid> ProvisioningTenantId { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> PurchaseOn { get { throw null; } }
        public Azure.Provisioning.BicepValue<long> Quantity { get { throw null; } }
        public Azure.Provisioning.Billing.SubscriptionRenewalTermDetails RenewalTermDetails { get { throw null; } }
        public Azure.Provisioning.Billing.CreatedSubscriptionReseller Reseller { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.Uri> ResourceUri { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> SkuDescription { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> SkuId { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Billing.BillingSubscriptionStatus> Status { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Billing.SubscriptionEnrollmentAccountStatus> SubscriptionEnrollmentAccountStatus { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> SubscriptionId { get { throw null; } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Billing.BillingSubscriptionStatusDetails> SuspensionReasonDetails { get { throw null; } }
        public Azure.Provisioning.BicepList<string> SuspensionReasons { get { throw null; } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.Billing.BillingSystemOverrides SystemOverrides { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.TimeSpan> TermDuration { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> TermEndsOn { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> TermStartsOn { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Billing.BillingSubscription FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2024_04_01;
        }
    }
    public partial class BillingSubscriptionAlias : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public BillingSubscriptionAlias(string bicepIdentifier, string resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Billing.BillingSubscriptionAutoRenewState> AutoRenew { get { throw null; } set { } }
        public Azure.Provisioning.Billing.BillingBeneficiary Beneficiary { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.Guid> BeneficiaryTenantId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> BillingFrequency { get { throw null; } set { } }
        public Azure.Provisioning.BicepDictionary<string> BillingPolicies { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> BillingProfileDisplayName { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> BillingProfileId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> BillingProfileName { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> ConsumptionCostCenter { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> CustomerDisplayName { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> CustomerId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> CustomerName { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> DisplayName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> EnrollmentAccountDisplayName { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> EnrollmentAccountId { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> EnrollmentAccountStartsOn { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> InvoiceSectionDisplayName { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> InvoiceSectionId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> InvoiceSectionName { get { throw null; } }
        public Azure.Provisioning.Billing.BillingAmount LastMonthCharges { get { throw null; } }
        public Azure.Provisioning.Billing.BillingAmount MonthToDateCharges { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> NextBillingCycleBillingFrequency { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> OfferId { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Billing.BillingSubscriptionOperationStatus> OperationStatus { get { throw null; } }
        public Azure.Provisioning.Billing.BillingAccount Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ProductCategory { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> ProductType { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> ProductTypeId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Billing.BillingProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.Guid> ProvisioningTenantId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> PurchaseOn { get { throw null; } }
        public Azure.Provisioning.BicepValue<long> Quantity { get { throw null; } set { } }
        public Azure.Provisioning.Billing.SubscriptionRenewalTermDetails RenewalTermDetails { get { throw null; } }
        public Azure.Provisioning.Billing.CreatedSubscriptionReseller Reseller { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.Uri> ResourceUri { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> SkuDescription { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> SkuId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Billing.BillingSubscriptionStatus> Status { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> SubscriptionAliasSubscriptionId { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Billing.SubscriptionEnrollmentAccountStatus> SubscriptionEnrollmentAccountStatus { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> SubscriptionId { get { throw null; } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Billing.BillingSubscriptionStatusDetails> SuspensionReasonDetails { get { throw null; } }
        public Azure.Provisioning.BicepList<string> SuspensionReasons { get { throw null; } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.Billing.BillingSystemOverrides SystemOverrides { get { throw null; } set { } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.TimeSpan> TermDuration { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> TermEndsOn { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> TermStartsOn { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Billing.BillingSubscriptionAlias FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2024_04_01;
        }
    }
    public enum BillingSubscriptionAutoRenewState
    {
        Off = 0,
        On = 1,
    }
    public enum BillingSubscriptionOperationStatus
    {
        Other = 0,
        None = 1,
        LockedForUpdate = 2,
    }
    public enum BillingSubscriptionStatus
    {
        Other = 0,
        Unknown = 1,
        Active = 2,
        Disabled = 3,
        Deleted = 4,
        Warned = 5,
        Expiring = 6,
        Expired = 7,
        AutoRenew = 8,
        Cancelled = 9,
        Suspended = 10,
        Failed = 11,
    }
    public partial class BillingSubscriptionStatusDetails : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public BillingSubscriptionStatusDetails() { }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> EffectiveOn { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Billing.SubscriptionStatusReason> Reason { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum BillingSupportedAccountType
    {
        None = 0,
        Partner = 1,
        Individual = 2,
        Enterprise = 3,
    }
    public partial class BillingSystemOverrides : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public BillingSystemOverrides() { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Billing.PolicyOverrideCancellation> Cancellation { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> CancellationAllowedEndsOn { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class BillingTaxIdentifier : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public BillingTaxIdentifier() { }
        public Azure.Provisioning.BicepValue<string> Country { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Billing.BillingTaxIdentifierType> IdentifierType { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Scope { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Billing.BillingTaxIdentifierStatus> Status { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum BillingTaxIdentifierStatus
    {
        Other = 0,
        Valid = 1,
        Invalid = 2,
    }
    public enum BillingTaxIdentifierType
    {
        Other = 0,
        BrazilCcmId = 1,
        BrazilCnpjId = 2,
        BrazilCpfId = 3,
        CanadianFederalExempt = 4,
        CanadianProvinceExempt = 5,
        ExternalTaxation = 6,
        IndiaFederalTanId = 7,
        IndiaFederalServiceTaxId = 8,
        IndiaPanId = 9,
        IndiaStateCstId = 10,
        IndiaStateGstINId = 11,
        IndiaStateVatId = 12,
        IntlExempt = 13,
        USExempt = 14,
        VatId = 15,
        LoveCode = 16,
        MobileBarCode = 17,
        NationalIdentificationNumber = 18,
        PublicSectorId = 19,
    }
    public partial class BillingTransferDetail : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public BillingTransferDetail(string bicepIdentifier, string resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<string> CanceledBy { get { throw null; } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Billing.DetailedTransferStatus> DetailedTransferStatus { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> ExpiresOn { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> InitiatorEmailId { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.Billing.BillingInvoiceSection Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> RecipientEmailId { get { throw null; } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Billing.PartnerTransferStatus> TransferStatus { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Billing.BillingTransferDetail FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public override Azure.Provisioning.Primitives.ResourceNameRequirements GetResourceNameRequirements() { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2024_04_01;
        }
    }
    public partial class BillingTransferError : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public BillingTransferError() { }
        public Azure.Provisioning.BicepValue<string> Code { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Message { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class CreatedSubscriptionReseller : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public CreatedSubscriptionReseller() { }
        public Azure.Provisioning.BicepValue<string> Description { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> ResellerId { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class DetailedTransferStatus : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public DetailedTransferStatus() { }
        public Azure.Provisioning.Billing.BillingTransferError ErrorDetails { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> ProductId { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> ProductName { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Billing.BillingProductType> ProductType { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> SkuDescription { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Billing.BillingProductTransferStatus> TransferStatus { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum EligibleProductType
    {
        DevTestAzureSubscription = 0,
        StandardAzureSubscription = 1,
        AzureReservation = 2,
    }
    public enum EnrollmentAccountOwnerViewCharge
    {
        Other = 0,
        Allowed = 1,
        Disabled = 2,
        NotAllowed = 3,
    }
    public enum EnrollmentAuthLevelState
    {
        Other = 0,
        MicrosoftAccountOnly = 1,
        MixedAccount = 2,
        OrganizationalAccountCrossTenant = 3,
        OrganizationalAccountOnly = 4,
    }
    public enum EnrollmentDepartmentAdminViewCharge
    {
        Other = 0,
        Allowed = 1,
        Disabled = 2,
        NotAllowed = 3,
    }
    public partial class EnrollmentDetailsIndirectRelationshipInfo : Azure.Provisioning.Billing.IndirectRelationshipInfo
    {
        public EnrollmentDetailsIndirectRelationshipInfo() { }
        protected override void DefineProvisionableProperties() { }
    }
    public enum EnrollmentMarkupStatus
    {
        Other = 0,
        Disabled = 1,
        Preview = 2,
        Published = 3,
        Locked = 4,
    }
    public partial class EnterpriseAgreementPolicies : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public EnterpriseAgreementPolicies() { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Billing.EnrollmentAccountOwnerViewCharge> AccountOwnerViewCharges { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Billing.EnrollmentAuthLevelState> AuthenticationType { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Billing.EnrollmentDepartmentAdminViewCharge> DepartmentAdminViewCharges { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ExtendedStatusInfo : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ExtendedStatusInfo() { }
        public Azure.Provisioning.BicepValue<string> Message { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> StatusCode { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> SubscriptionId { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum ExtendedTermOption
    {
        Other = 0,
        [System.Runtime.Serialization.DataMemberAttribute(Name="Opted-In")]
        OptedIn = 1,
        [System.Runtime.Serialization.DataMemberAttribute(Name="Opted-Out")]
        OptedOut = 2,
    }
    public partial class IndirectRelationshipInfo : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public IndirectRelationshipInfo() { }
        public Azure.Provisioning.BicepValue<string> BillingAccountName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> BillingProfileName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> DisplayName { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum InitiatorCustomerType
    {
        Partner = 0,
        EA = 1,
    }
    public enum InstanceFlexibility
    {
        On = 0,
        Off = 1,
    }
    public partial class InvoiceDocument : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public InvoiceDocument() { }
        public Azure.Provisioning.BicepList<string> DocumentNumbers { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> ExternalUri { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Billing.InvoiceDocumentType> Kind { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Billing.BillingDocumentSource> Source { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Uri { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum InvoiceDocumentType
    {
        Other = 0,
        Invoice = 1,
        VoidNote = 2,
        TaxReceipt = 3,
        CreditNote = 4,
        Summary = 5,
        Transactions = 6,
    }
    public partial class InvoicePropertiesAmountDue : Azure.Provisioning.Billing.BillingAmount
    {
        public InvoicePropertiesAmountDue() { }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class InvoicePropertiesAzurePrepaymentApplied : Azure.Provisioning.Billing.BillingAmount
    {
        public InvoicePropertiesAzurePrepaymentApplied() { }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class InvoicePropertiesBilledAmount : Azure.Provisioning.Billing.BillingAmount
    {
        public InvoicePropertiesBilledAmount() { }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class InvoicePropertiesCreditAmount : Azure.Provisioning.Billing.BillingAmount
    {
        public InvoicePropertiesCreditAmount() { }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class InvoicePropertiesFreeAzureCreditApplied : Azure.Provisioning.Billing.BillingAmount
    {
        public InvoicePropertiesFreeAzureCreditApplied() { }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class InvoicePropertiesRebillDetails : Azure.Provisioning.Billing.RebillDetails
    {
        public InvoicePropertiesRebillDetails() { }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class InvoicePropertiesRefundDetails : Azure.Provisioning.Billing.RefundDetailsSummary
    {
        public InvoicePropertiesRefundDetails() { }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class InvoicePropertiesSubTotal : Azure.Provisioning.Billing.BillingAmount
    {
        public InvoicePropertiesSubTotal() { }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class InvoicePropertiesTaxAmount : Azure.Provisioning.Billing.BillingAmount
    {
        public InvoicePropertiesTaxAmount() { }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class InvoicePropertiesTotalAmount : Azure.Provisioning.Billing.BillingAmount
    {
        public InvoicePropertiesTotalAmount() { }
        protected override void DefineProvisionableProperties() { }
    }
    public enum InvoiceSectionLabelManagementPolicy
    {
        Other = 0,
        Allowed = 1,
        NotAllowed = 2,
    }
    public enum InvoiceSectionState
    {
        Other = 0,
        Active = 1,
        Deleted = 2,
        Disabled = 3,
        UnderReview = 4,
        Warned = 5,
        Restricted = 6,
    }
    public enum InvoiceSectionStateReasonCode
    {
        Other = 0,
        PastDue = 1,
        UnusualActivity = 2,
        SpendingLimitReached = 3,
        SpendingLimitExpired = 4,
    }
    public enum MarketplacePurchasesPolicy
    {
        Other = 0,
        AllAllowed = 1,
        Disabled = 2,
        NotAllowed = 3,
        OnlyFreeAllowed = 4,
    }
    public partial class PartnerTransferDetail : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public PartnerTransferDetail(string bicepIdentifier, string resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<string> CanceledBy { get { throw null; } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Billing.DetailedTransferStatus> DetailedTransferStatus { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> ExpiresOn { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Billing.InitiatorCustomerType> InitiatorCustomerType { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> InitiatorEmailId { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.Billing.BillingProfileCustomer Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> RecipientEmailId { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> ResellerId { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> ResellerName { get { throw null; } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Billing.PartnerTransferStatus> TransferStatus { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Billing.PartnerTransferDetail FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public override Azure.Provisioning.Primitives.ResourceNameRequirements GetResourceNameRequirements() { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2024_04_01;
        }
    }
    public enum PartnerTransferStatus
    {
        Expired = 0,
        Pending = 1,
        InProgress = 2,
        Completed = 3,
        CompletedWithErrors = 4,
        Failed = 5,
        Canceled = 6,
        Declined = 7,
    }
    public partial class PaymentAmount : Azure.Provisioning.Billing.BillingAmount
    {
        public PaymentAmount() { }
        protected override void DefineProvisionableProperties() { }
    }
    public enum PaymentMethodFamily
    {
        Other = 0,
        None = 1,
        CreditCard = 2,
        Credits = 3,
        CheckWire = 4,
        EWallet = 5,
        TaskOrder = 6,
        DirectDebit = 7,
    }
    public partial class PaymentMethodLogo : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public PaymentMethodLogo() { }
        public Azure.Provisioning.BicepValue<string> MimeType { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Uri { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class PaymentMethodProjectionProperties : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public PaymentMethodProjectionProperties() { }
        public Azure.Provisioning.BicepValue<string> AccountHolderName { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> DisplayName { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Expiration { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Billing.PaymentMethodFamily> Family { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> LastFourDigits { get { throw null; } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Billing.PaymentMethodLogo> Logos { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> PaymentMethodId { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> PaymentMethodType { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Billing.PaymentMethodStatus> Status { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum PaymentMethodStatus
    {
        [System.Runtime.Serialization.DataMemberAttribute(Name="active")]
        Active = 0,
        [System.Runtime.Serialization.DataMemberAttribute(Name="inactive")]
        Inactive = 1,
    }
    public enum PolicyOverrideCancellation
    {
        NotAllowed = 0,
        Allowed = 1,
    }
    public partial class ProductPropertiesLastCharge : Azure.Provisioning.Billing.BillingAmount
    {
        public ProductPropertiesLastCharge() { }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ProductPropertiesReseller : Azure.Provisioning.Billing.CreatedSubscriptionReseller
    {
        public ProductPropertiesReseller() { }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class RebillDetails : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public RebillDetails() { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> CreditNoteDocumentId { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> InvoiceDocumentId { get { throw null; } }
        public Azure.Provisioning.Billing.RebillDetails RebillDetailsValue { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class RecipientTransferDetail : Azure.Provisioning.Primitives.ProvisionableResource
    {
        internal RecipientTransferDetail() : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Billing.EligibleProductType> AllowedProductType { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> CanceledBy { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.Guid> CustomerTenantId { get { throw null; } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Billing.DetailedTransferStatus> DetailedTransferStatus { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> ExpiresOn { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Billing.InitiatorCustomerType> InitiatorCustomerType { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> InitiatorEmailId { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> RecipientEmailId { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> ResellerId { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> ResellerName { get { throw null; } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Billing.BillingSupportedAccountType> SupportedAccounts { get { throw null; } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Billing.PartnerTransferStatus> TransferStatus { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Billing.RecipientTransferDetail FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public override Azure.Provisioning.Primitives.ResourceNameRequirements GetResourceNameRequirements() { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2024_04_01;
        }
    }
    public partial class RefundDetailsSummary : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public RefundDetailsSummary() { }
        public Azure.Provisioning.Billing.RefundDetailsSummaryAmountRefunded AmountRefunded { get { throw null; } }
        public Azure.Provisioning.Billing.RefundDetailsSummaryAmountRequested AmountRequested { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> ApprovedOn { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> CompletedOn { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> RebillInvoiceId { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> RefundOperationId { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Billing.RefundReasonCode> RefundReason { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Billing.RefundStatus> RefundStatus { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> RequestedOn { get { throw null; } }
        public Azure.Provisioning.BicepValue<int> TransactionCount { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class RefundDetailsSummaryAmountRefunded : Azure.Provisioning.Billing.BillingAmount
    {
        public RefundDetailsSummaryAmountRefunded() { }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class RefundDetailsSummaryAmountRequested : Azure.Provisioning.Billing.BillingAmount
    {
        public RefundDetailsSummaryAmountRequested() { }
        protected override void DefineProvisionableProperties() { }
    }
    public enum RefundReasonCode
    {
        Other = 0,
        AccidentalConversion = 1,
        UnclearPricing = 2,
        AccidentalPurchase = 3,
        ForgotToCancel = 4,
        UnclearDocumentation = 5,
    }
    public enum RefundStatus
    {
        Other = 0,
        Pending = 1,
        Approved = 2,
        Declined = 3,
        Cancelled = 4,
        Completed = 5,
        Expired = 6,
    }
    public partial class ReservationAppliedScopeProperties : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ReservationAppliedScopeProperties() { }
        public Azure.Provisioning.BicepValue<string> DisplayName { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> ManagementGroupId { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> ResourceGroupId { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> SubscriptionId { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> TenantId { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum ReservationBillingPlan
    {
        Upfront = 0,
        Monthly = 1,
    }
    public partial class ReservationExtendedStatusInfo : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ReservationExtendedStatusInfo() { }
        public Azure.Provisioning.BicepValue<string> ExtendedStatusDefinitionSubscriptionId { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Message { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Billing.ReservationStatusCode> StatusCode { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ReservationMergeProperties : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ReservationMergeProperties() { }
        public Azure.Provisioning.BicepValue<string> MergeDestination { get { throw null; } }
        public Azure.Provisioning.BicepList<string> MergeSources { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ReservationOrderBillingPlanInformation : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ReservationOrderBillingPlanInformation() { }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> NextPaymentDueOn { get { throw null; } }
        public Azure.Provisioning.Billing.BillingPrice PricingCurrencyTotal { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> StartsOn { get { throw null; } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Billing.ReservationPaymentDetail> Transactions { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ReservationPaymentDetail : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ReservationPaymentDetail() { }
        public Azure.Provisioning.BicepValue<string> BillingAccount { get { throw null; } }
        public Azure.Provisioning.Billing.BillingPrice BillingCurrencyTotal { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> DueOn { get { throw null; } }
        public Azure.Provisioning.Billing.ReservationExtendedStatusInfo ExtendedStatusInfo { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> PaymentOn { get { throw null; } }
        public Azure.Provisioning.Billing.BillingPrice PricingCurrencyTotal { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Billing.BillingPaymentStatus> Status { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ReservationPurchaseRequest : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ReservationPurchaseRequest() { }
        public Azure.Provisioning.Billing.ReservationAppliedScopeProperties AppliedScopeProperties { get { throw null; } }
        public Azure.Provisioning.BicepList<string> AppliedScopes { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Billing.BillingAppliedScopeType> AppliedScopeType { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Billing.ReservationBillingPlan> BillingPlan { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> BillingScopeId { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> DisplayName { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Billing.InstanceFlexibility> InstanceFlexibilityPropertiesInstanceFlexibility { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Billing.InstanceFlexibility> InstanceFlexibilityPropertiesReservedResourcePropertiesInstanceFlexibility { get { throw null; } }
        public Azure.Provisioning.BicepValue<bool> IsRenewed { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Location { get { throw null; } }
        public Azure.Provisioning.BicepValue<int> Quantity { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> ReservedResourceType { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> ReviewOn { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> SkuName { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Term { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum ReservationPurchasesPolicy
    {
        Other = 0,
        Allowed = 1,
        Disabled = 2,
        NotAllowed = 3,
    }
    public partial class ReservationRenewProperties : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ReservationRenewProperties() { }
        public Azure.Provisioning.Billing.BillingPrice BillingCurrencyTotal { get { throw null; } }
        public Azure.Provisioning.Billing.BillingPrice PricingCurrencyTotal { get { throw null; } }
        public Azure.Provisioning.Billing.ReservationPurchaseRequest PurchaseProperties { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ReservationSplitProperties : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ReservationSplitProperties() { }
        public Azure.Provisioning.BicepList<string> SplitDestinations { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> SplitSource { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum ReservationStatusCode
    {
        None = 0,
        Pending = 1,
        Processing = 2,
        Active = 3,
        PurchaseError = 4,
        PaymentInstrumentError = 5,
        Split = 6,
        Merged = 7,
        Expired = 8,
        Succeeded = 9,
        CapacityError = 10,
        CapacityRestricted = 11,
        Exchanged = 12,
        UnknownError = 13,
        RiskCheckFailed = 14,
        CreditLineCheckFailed = 15,
        Warning = 16,
        NoBenefitDueToSubscriptionTransfer = 17,
        NoBenefitDueToSubscriptionDeletion = 18,
        NoBenefit = 19,
    }
    public partial class ReservationSwapProperties : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ReservationSwapProperties() { }
        public Azure.Provisioning.BicepValue<string> SwapDestination { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> SwapSource { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ReservationUtilizationAggregates : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ReservationUtilizationAggregates() { }
        public Azure.Provisioning.BicepValue<float> Grain { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> GrainUnit { get { throw null; } }
        public Azure.Provisioning.BicepValue<float> Value { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> ValueUnit { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class SavingsPlanOrderModel : Azure.Provisioning.Primitives.ProvisionableResource
    {
        internal SavingsPlanOrderModel() : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> BenefitStartsOn { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> BillingAccountId { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Billing.BillingPlan> BillingPlan { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> BillingProfileId { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> BillingScopeId { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> CustomerId { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> DisplayName { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> ExpiryOn { get { throw null; } }
        public Azure.Provisioning.Billing.ExtendedStatusInfo ExtendedStatusInfo { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.Billing.BillingAccount Parent { get { throw null; } set { } }
        public Azure.Provisioning.Billing.BillingPlanInformation PlanInformation { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> ProductCode { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.BicepList<string> SavingsPlans { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> SkuName { get { throw null; } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Billing.BillingSavingsPlanTerm> Term { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Billing.SavingsPlanOrderModel FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2024_04_01;
        }
    }
    public enum SavingsPlanPurchasesPolicy
    {
        Other = 0,
        Allowed = 1,
        Disabled = 2,
        NotAllowed = 3,
    }
    public partial class SavingsPlanUtilization : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public SavingsPlanUtilization() { }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Billing.SavingsPlanUtilizationAggregates> Aggregates { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Trend { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class SavingsPlanUtilizationAggregates : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public SavingsPlanUtilizationAggregates() { }
        public Azure.Provisioning.BicepValue<float> Grain { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> GrainUnit { get { throw null; } }
        public Azure.Provisioning.BicepValue<float> Value { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> ValueUnit { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum SpecialTaxationType
    {
        SubtotalLevel = 0,
        InvoiceLevel = 1,
    }
    public partial class SpendingLimitDetails : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public SpendingLimitDetails() { }
        public Azure.Provisioning.BicepValue<float> Amount { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Currency { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> EndsOn { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Billing.SpendingLimitType> LimitType { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> StartsOn { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Billing.SpendingLimitStatus> Status { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum SpendingLimitStatus
    {
        Other = 0,
        None = 1,
        Active = 2,
        Expired = 3,
        LimitReached = 4,
        LimitRemoved = 5,
    }
    public enum SpendingLimitType
    {
        Other = 0,
        None = 1,
        FreeAccount = 2,
        Sandbox = 3,
        AzureForStudents = 4,
        AcademicSponsorship = 5,
        AzureConsumptionCredit = 6,
        AzurePassSponsorship = 7,
        MpnSponsorship = 8,
        [System.Runtime.Serialization.DataMemberAttribute(Name="MSDN")]
        Msdn = 9,
        NonProfitSponsorship = 10,
        Sponsorship = 11,
        StartupSponsorship = 12,
        AzureForStudentsStarter = 13,
        VisualStudio = 14,
    }
    public partial class SubscriptionBillingInvoice : Azure.Provisioning.Primitives.ProvisionableResource
    {
        internal SubscriptionBillingInvoice() : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.Billing.BillingInvoiceProperties Properties { get { throw null; } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Billing.SubscriptionBillingInvoice FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public override Azure.Provisioning.Primitives.ResourceNameRequirements GetResourceNameRequirements() { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2024_04_01;
        }
    }
    public enum SubscriptionBillingType
    {
        None = 0,
        Benefit = 1,
        Free = 2,
        Paid = 3,
        PrePaid = 4,
    }
    public enum SubscriptionEnrollmentAccountStatus
    {
        Active = 0,
        Cancelled = 1,
        Expired = 2,
        Deleted = 3,
        TransferredOut = 4,
        Transferring = 5,
        Inactive = 6,
    }
    public partial class SubscriptionEnrollmentDetails : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public SubscriptionEnrollmentDetails() { }
        public Azure.Provisioning.BicepValue<string> DepartmentDisplayName { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> DepartmentId { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> EnrollmentAccountDisplayName { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> EnrollmentAccountId { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> EnrollmentAccountStatus { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class SubscriptionPolicy : Azure.Provisioning.Primitives.ProvisionableResource
    {
        internal SubscriptionPolicy() : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } }
        public Azure.Provisioning.Billing.SubscriptionPolicyProperties Properties { get { throw null; } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Billing.SubscriptionPolicy FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2024_04_01;
        }
    }
    public partial class SubscriptionPolicyProperties : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public SubscriptionPolicyProperties() { }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Billing.BillingPolicySummary> Policies { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Billing.BillingProvisioningState> ProvisioningState { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class SubscriptionRenewalTermDetails : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public SubscriptionRenewalTermDetails() { }
        public Azure.Provisioning.BicepValue<string> BillingFrequency { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> ProductId { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> ProductTypeId { get { throw null; } }
        public Azure.Provisioning.BicepValue<long> Quantity { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> SkuId { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.TimeSpan> TermDuration { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> TermEndsOn { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum SubscriptionStatusReason
    {
        None = 0,
        Cancelled = 1,
        PastDue = 2,
        SuspiciousActivity = 3,
        Other = 4,
        Transferred = 5,
        PolicyViolation = 6,
        SpendingLimitReached = 7,
        Expired = 8,
    }
    public enum SubscriptionWorkloadType
    {
        None = 0,
        Production = 1,
        DevTest = 2,
        Internal = 3,
    }
    public enum ViewChargesPolicy
    {
        Other = 0,
        Allowed = 1,
        NotAllowed = 2,
    }
}
