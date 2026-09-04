namespace Azure.Provisioning.DomainRegistration
{
    public enum AppServiceDnsType
    {
        AzureDns = 0,
        DefaultDomainRegistrarDns = 1,
    }
    public partial class AppServiceDomain : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public AppServiceDomain(string bicepIdentifier, string resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<string> AuthCode { get { throw null; } set { } }
        public Azure.Provisioning.DomainRegistration.DomainPurchaseConsent Consent { get { throw null; } set { } }
        public Azure.Provisioning.DomainRegistration.RegistrationContactInfo ContactAdmin { get { throw null; } set { } }
        public Azure.Provisioning.DomainRegistration.RegistrationContactInfo ContactBilling { get { throw null; } set { } }
        public Azure.Provisioning.DomainRegistration.RegistrationContactInfo ContactRegistrant { get { throw null; } set { } }
        public Azure.Provisioning.DomainRegistration.RegistrationContactInfo ContactTech { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> CreatedOn { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.DomainRegistration.AppServiceDnsType> DnsType { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> DnsZoneId { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.DomainRegistration.DomainNotRenewableReason> DomainNotRenewableReasons { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> ExpireOn { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<bool> IsAutoRenew { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsDnsRecordManagementReady { get { throw null; } }
        public Azure.Provisioning.BicepValue<bool> IsDomainPrivacyEnabled { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Kind { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> LastRenewedOn { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> Location { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.DomainRegistration.AppServiceHostName> ManagedHostNames { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<string> NameServers { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.DomainRegistration.AppServiceDomainProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.DomainRegistration.AppServiceDomainStatus> RegistrationStatus { get { throw null; } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.DomainRegistration.AppServiceDnsType> TargetDnsType { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.DomainRegistration.AppServiceDomain FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public override Azure.Provisioning.Primitives.ResourceNameRequirements GetResourceNameRequirements() { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2024_11_01;
        }
    }
    public enum AppServiceDomainProvisioningState
    {
        Succeeded = 0,
        Failed = 1,
        Canceled = 2,
        InProgress = 3,
        Deleting = 4,
    }
    public enum AppServiceDomainStatus
    {
        Active = 0,
        Awaiting = 1,
        Cancelled = 2,
        Confiscated = 3,
        Disabled = 4,
        Excluded = 5,
        Expired = 6,
        Failed = 7,
        Held = 8,
        Locked = 9,
        Parked = 10,
        Pending = 11,
        Reserved = 12,
        Reverted = 13,
        Suspended = 14,
        Transferred = 15,
        Unknown = 16,
        Unlocked = 17,
        Unparked = 18,
        Updated = 19,
        JsonConverterFailed = 20,
    }
    public partial class AppServiceHostName : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public AppServiceHostName() { }
        public Azure.Provisioning.BicepValue<string> AzureResourceName { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.DomainRegistration.AppServiceResourceType> AzureResourceType { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.DomainRegistration.CustomHostNameDnsRecordType> CustomHostNameDnsRecordType { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.DomainRegistration.AppServiceHostNameType> HostNameType { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } }
        public Azure.Provisioning.BicepList<string> SiteNames { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum AppServiceHostNameType
    {
        Verified = 0,
        Managed = 1,
    }
    public enum AppServiceResourceType
    {
        Website = 0,
        TrafficManager = 1,
    }
    public enum CustomHostNameDnsRecordType
    {
        CName = 0,
        A = 1,
    }
    public enum DomainNotRenewableReason
    {
        RegistrationStatusNotSupportedForRenewal = 0,
        ExpirationNotInRenewalTimeRange = 1,
        SubscriptionNotActive = 2,
    }
    public partial class DomainOwnershipIdentifier : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public DomainOwnershipIdentifier(string bicepIdentifier, string resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Kind { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> OwnershipId { get { throw null; } set { } }
        public Azure.Provisioning.DomainRegistration.AppServiceDomain Parent { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.DomainRegistration.DomainOwnershipIdentifier FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2024_11_01;
        }
    }
    public partial class DomainPurchaseConsent : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public DomainPurchaseConsent() { }
        public Azure.Provisioning.BicepValue<string> AgreedBy { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> AgreedOn { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<string> AgreementKeys { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class RegistrationAddressInfo : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public RegistrationAddressInfo() { }
        public Azure.Provisioning.BicepValue<string> Address1 { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Address2 { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> City { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Country { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> PostalCode { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> State { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class RegistrationContactInfo : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public RegistrationContactInfo() { }
        public Azure.Provisioning.DomainRegistration.RegistrationAddressInfo AddressMailing { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Email { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Fax { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> JobTitle { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> NameFirst { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> NameLast { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> NameMiddle { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Organization { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Phone { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class TopLevelDomain : Azure.Provisioning.Primitives.ProvisionableResource
    {
        internal TopLevelDomain() : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<bool> IsDomainPrivacySupported { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Kind { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.DomainRegistration.TopLevelDomain FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2024_11_01;
        }
    }
}
