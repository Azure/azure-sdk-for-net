namespace Azure.Communication.PhoneNumbers
{
    public partial class AvailablePhoneNumber
    {
        public AvailablePhoneNumber(string countryCode, Azure.Communication.PhoneNumbers.PhoneNumberCapabilities capabilities, Azure.Communication.PhoneNumbers.PhoneNumberType phoneNumberType, Azure.Communication.PhoneNumbers.PhoneNumberAssignmentType assignmentType) { }
        public Azure.Communication.PhoneNumbers.PhoneNumberAssignmentType AssignmentType { get { throw null; } }
        public Azure.Communication.PhoneNumbers.PhoneNumberCapabilities Capabilities { get { throw null; } }
        public Azure.Communication.PhoneNumbers.PhoneNumberCost Cost { get { throw null; } }
        public string CountryCode { get { throw null; } }
        public Azure.ResponseError Error { get { throw null; } }
        public string Id { get { throw null; } }
        public bool IsAgreementToNotResellRequired { get { throw null; } }
        public string PhoneNumber { get { throw null; } }
        public Azure.Communication.PhoneNumbers.PhoneNumberType PhoneNumberType { get { throw null; } }
        public Azure.Communication.PhoneNumbers.PhoneNumberAvailabilityStatus Status { get { throw null; } }
    }
    public partial class AzureCommunicationPhoneNumbersContext : System.ClientModel.Primitives.ModelReaderWriterContext
    {
        public AzureCommunicationPhoneNumbersContext() { }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public Azure.Communication.PhoneNumbers.AzureCommunicationPhoneNumbersContext Default { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct BillingFrequency : System.IEquatable<Azure.Communication.PhoneNumbers.BillingFrequency>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public BillingFrequency(string value) { throw null; }
        public static Azure.Communication.PhoneNumbers.BillingFrequency Monthly { get { throw null; } }
        public bool Equals(Azure.Communication.PhoneNumbers.BillingFrequency other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Communication.PhoneNumbers.BillingFrequency left, Azure.Communication.PhoneNumbers.BillingFrequency right) { throw null; }
        public static implicit operator Azure.Communication.PhoneNumbers.BillingFrequency (string value) { throw null; }
        public static bool operator !=(Azure.Communication.PhoneNumbers.BillingFrequency left, Azure.Communication.PhoneNumbers.BillingFrequency right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class CreateOrUpdateReservationOptions
    {
        public CreateOrUpdateReservationOptions(System.Guid reservationId) { }
        public System.Collections.Generic.IEnumerable<Azure.Communication.PhoneNumbers.AvailablePhoneNumber> PhoneNumbersToAdd { get { throw null; } set { } }
        public System.Collections.Generic.IEnumerable<string> PhoneNumbersToRemove { get { throw null; } set { } }
        public System.Guid ReservationId { get { throw null; } }
    }
    public partial class OperatorDetails
    {
        internal OperatorDetails() { }
        public string MobileCountryCode { get { throw null; } }
        public string MobileNetworkCode { get { throw null; } }
        public string Name { get { throw null; } }
    }
    public partial class OperatorInformation
    {
        internal OperatorInformation() { }
        public string InternationalFormat { get { throw null; } }
        public string IsoCountryCode { get { throw null; } }
        public string NationalFormat { get { throw null; } }
        public Azure.Communication.PhoneNumbers.OperatorNumberType? NumberType { get { throw null; } }
        public Azure.Communication.PhoneNumbers.OperatorDetails OperatorDetails { get { throw null; } }
        public string PhoneNumber { get { throw null; } }
    }
    public partial class OperatorInformationOptions
    {
        public OperatorInformationOptions() { }
        public bool? IncludeAdditionalOperatorDetails { get { throw null; } set { } }
    }
    public partial class OperatorInformationResult
    {
        internal OperatorInformationResult() { }
        public System.Collections.Generic.IReadOnlyList<Azure.Communication.PhoneNumbers.OperatorInformation> Values { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct OperatorNumberType : System.IEquatable<Azure.Communication.PhoneNumbers.OperatorNumberType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public OperatorNumberType(string value) { throw null; }
        public static Azure.Communication.PhoneNumbers.OperatorNumberType Geographic { get { throw null; } }
        public static Azure.Communication.PhoneNumbers.OperatorNumberType Mobile { get { throw null; } }
        public static Azure.Communication.PhoneNumbers.OperatorNumberType Other { get { throw null; } }
        public static Azure.Communication.PhoneNumbers.OperatorNumberType Unknown { get { throw null; } }
        public bool Equals(Azure.Communication.PhoneNumbers.OperatorNumberType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Communication.PhoneNumbers.OperatorNumberType left, Azure.Communication.PhoneNumbers.OperatorNumberType right) { throw null; }
        public static implicit operator Azure.Communication.PhoneNumbers.OperatorNumberType (string value) { throw null; }
        public static bool operator !=(Azure.Communication.PhoneNumbers.OperatorNumberType left, Azure.Communication.PhoneNumbers.OperatorNumberType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class PhoneNumberAdministrativeDivision
    {
        internal PhoneNumberAdministrativeDivision() { }
        public string AbbreviatedName { get { throw null; } }
        public string LocalizedName { get { throw null; } }
    }
    public partial class PhoneNumberAreaCode
    {
        internal PhoneNumberAreaCode() { }
        public string AreaCode { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PhoneNumberAssignmentType : System.IEquatable<Azure.Communication.PhoneNumbers.PhoneNumberAssignmentType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PhoneNumberAssignmentType(string value) { throw null; }
        public static Azure.Communication.PhoneNumbers.PhoneNumberAssignmentType Application { get { throw null; } }
        public static Azure.Communication.PhoneNumbers.PhoneNumberAssignmentType Person { get { throw null; } }
        public bool Equals(Azure.Communication.PhoneNumbers.PhoneNumberAssignmentType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Communication.PhoneNumbers.PhoneNumberAssignmentType left, Azure.Communication.PhoneNumbers.PhoneNumberAssignmentType right) { throw null; }
        public static implicit operator Azure.Communication.PhoneNumbers.PhoneNumberAssignmentType (string value) { throw null; }
        public static bool operator !=(Azure.Communication.PhoneNumbers.PhoneNumberAssignmentType left, Azure.Communication.PhoneNumbers.PhoneNumberAssignmentType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PhoneNumberAvailabilityStatus : System.IEquatable<Azure.Communication.PhoneNumbers.PhoneNumberAvailabilityStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PhoneNumberAvailabilityStatus(string value) { throw null; }
        public static Azure.Communication.PhoneNumbers.PhoneNumberAvailabilityStatus Available { get { throw null; } }
        public static Azure.Communication.PhoneNumbers.PhoneNumberAvailabilityStatus Error { get { throw null; } }
        public static Azure.Communication.PhoneNumbers.PhoneNumberAvailabilityStatus Expired { get { throw null; } }
        public static Azure.Communication.PhoneNumbers.PhoneNumberAvailabilityStatus Purchased { get { throw null; } }
        public static Azure.Communication.PhoneNumbers.PhoneNumberAvailabilityStatus Reserved { get { throw null; } }
        public bool Equals(Azure.Communication.PhoneNumbers.PhoneNumberAvailabilityStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Communication.PhoneNumbers.PhoneNumberAvailabilityStatus left, Azure.Communication.PhoneNumbers.PhoneNumberAvailabilityStatus right) { throw null; }
        public static implicit operator Azure.Communication.PhoneNumbers.PhoneNumberAvailabilityStatus (string value) { throw null; }
        public static bool operator !=(Azure.Communication.PhoneNumbers.PhoneNumberAvailabilityStatus left, Azure.Communication.PhoneNumbers.PhoneNumberAvailabilityStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class PhoneNumberCapabilities
    {
        public PhoneNumberCapabilities(Azure.Communication.PhoneNumbers.PhoneNumberCapabilityType calling, Azure.Communication.PhoneNumbers.PhoneNumberCapabilityType sms) { }
        public Azure.Communication.PhoneNumbers.PhoneNumberCapabilityType Calling { get { throw null; } set { } }
        public Azure.Communication.PhoneNumbers.PhoneNumberCapabilityType Sms { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PhoneNumberCapabilityType : System.IEquatable<Azure.Communication.PhoneNumbers.PhoneNumberCapabilityType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PhoneNumberCapabilityType(string value) { throw null; }
        public static Azure.Communication.PhoneNumbers.PhoneNumberCapabilityType Inbound { get { throw null; } }
        public static Azure.Communication.PhoneNumbers.PhoneNumberCapabilityType InboundOutbound { get { throw null; } }
        public static Azure.Communication.PhoneNumbers.PhoneNumberCapabilityType None { get { throw null; } }
        public static Azure.Communication.PhoneNumbers.PhoneNumberCapabilityType Outbound { get { throw null; } }
        public bool Equals(Azure.Communication.PhoneNumbers.PhoneNumberCapabilityType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Communication.PhoneNumbers.PhoneNumberCapabilityType left, Azure.Communication.PhoneNumbers.PhoneNumberCapabilityType right) { throw null; }
        public static implicit operator Azure.Communication.PhoneNumbers.PhoneNumberCapabilityType (string value) { throw null; }
        public static bool operator !=(Azure.Communication.PhoneNumbers.PhoneNumberCapabilityType left, Azure.Communication.PhoneNumbers.PhoneNumberCapabilityType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class PhoneNumberCost
    {
        internal PhoneNumberCost() { }
        public double Amount { get { throw null; } }
        public Azure.Communication.PhoneNumbers.BillingFrequency BillingFrequency { get { throw null; } }
        public string IsoCurrencySymbol { get { throw null; } }
    }
    public partial class PhoneNumberCountry
    {
        internal PhoneNumberCountry() { }
        public string CountryCode { get { throw null; } }
        public string LocalizedName { get { throw null; } }
    }
    public partial class PhoneNumberLocality
    {
        internal PhoneNumberLocality() { }
        public Azure.Communication.PhoneNumbers.PhoneNumberAdministrativeDivision AdministrativeDivision { get { throw null; } }
        public string LocalizedName { get { throw null; } }
    }
    public partial class PhoneNumberOffering
    {
        internal PhoneNumberOffering() { }
        public Azure.Communication.PhoneNumbers.PhoneNumberAssignmentType? AssignmentType { get { throw null; } }
        public Azure.Communication.PhoneNumbers.PhoneNumberCapabilities AvailableCapabilities { get { throw null; } }
        public Azure.Communication.PhoneNumbers.PhoneNumberCost Cost { get { throw null; } }
        public Azure.Communication.PhoneNumbers.PhoneNumberType? PhoneNumberType { get { throw null; } }
    }
    public partial class PhoneNumbersBrowseOptions
    {
        public PhoneNumbersBrowseOptions(string countryCode, Azure.Communication.PhoneNumbers.PhoneNumberType phoneNumberType) { }
        public Azure.Communication.PhoneNumbers.PhoneNumberAssignmentType? AssignmentType { get { throw null; } set { } }
        public Azure.Communication.PhoneNumbers.PhoneNumberCapabilities Capabilities { get { throw null; } set { } }
        public string CountryCode { get { throw null; } }
        public System.Collections.Generic.IList<string> PhoneNumberPrefixes { get { throw null; } set { } }
        public Azure.Communication.PhoneNumbers.PhoneNumberType PhoneNumberType { get { throw null; } }
    }
    public partial class PhoneNumbersBrowseResult
    {
        internal PhoneNumbersBrowseResult() { }
        public System.Collections.Generic.IReadOnlyList<Azure.Communication.PhoneNumbers.AvailablePhoneNumber> PhoneNumbers { get { throw null; } }
    }
    public partial class PhoneNumbersClient
    {
        protected PhoneNumbersClient() { }
        public PhoneNumbersClient(string connectionString) { }
        public PhoneNumbersClient(string connectionString, Azure.Communication.PhoneNumbers.PhoneNumbersClientOptions options) { }
        public PhoneNumbersClient(System.Uri endpoint, Azure.AzureKeyCredential keyCredential, Azure.Communication.PhoneNumbers.PhoneNumbersClientOptions options = null) { }
        public PhoneNumbersClient(System.Uri endpoint, Azure.Core.TokenCredential tokenCredential, Azure.Communication.PhoneNumbers.PhoneNumbersClientOptions options = null) { }
        public virtual Azure.Response<Azure.Communication.PhoneNumbers.PhoneNumbersBrowseResult> BrowseAvailableNumbers(Azure.Communication.PhoneNumbers.PhoneNumbersBrowseOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Communication.PhoneNumbers.PhoneNumbersBrowseResult>> BrowseAvailableNumbersAsync(Azure.Communication.PhoneNumbers.PhoneNumbersBrowseOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Communication.PhoneNumbers.PhoneNumbersReservation> CreateOrUpdateReservation(Azure.Communication.PhoneNumbers.CreateOrUpdateReservationOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Communication.PhoneNumbers.PhoneNumbersReservation>> CreateOrUpdateReservationAsync(Azure.Communication.PhoneNumbers.CreateOrUpdateReservationOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response DeleteReservation(System.Guid reservationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteReservationAsync(System.Guid reservationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.Communication.PhoneNumbers.PhoneNumberAreaCode> GetAvailableAreaCodesGeographic(string twoLetterIsoCountryName, Azure.Communication.PhoneNumbers.PhoneNumberAssignmentType phoneNumberAssignmentType, string locality, string administrativeDivision = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.Communication.PhoneNumbers.PhoneNumberAreaCode> GetAvailableAreaCodesGeographicAsync(string twoLetterIsoCountryName, Azure.Communication.PhoneNumbers.PhoneNumberAssignmentType phoneNumberAssignmentType, string locality, string administrativeDivision = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.Communication.PhoneNumbers.PhoneNumberAreaCode> GetAvailableAreaCodesMobile(string twoLetterIsoCountryName, Azure.Communication.PhoneNumbers.PhoneNumberAssignmentType phoneNumberAssignmentType, string locality, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.Communication.PhoneNumbers.PhoneNumberAreaCode> GetAvailableAreaCodesMobileAsync(string twoLetterIsoCountryName, Azure.Communication.PhoneNumbers.PhoneNumberAssignmentType phoneNumberAssignmentType, string locality, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.Communication.PhoneNumbers.PhoneNumberAreaCode> GetAvailableAreaCodesTollFree(string twoLetterIsoCountryName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.Communication.PhoneNumbers.PhoneNumberAreaCode> GetAvailableAreaCodesTollFreeAsync(string twoLetterIsoCountryName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.Communication.PhoneNumbers.PhoneNumberCountry> GetAvailableCountries(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.Communication.PhoneNumbers.PhoneNumberCountry> GetAvailableCountriesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.Communication.PhoneNumbers.PhoneNumberLocality> GetAvailableLocalities(string twoLetterIsoCountryName, Azure.Communication.PhoneNumbers.PhoneNumberType phoneNumberType, string administrativeDivision = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.Communication.PhoneNumbers.PhoneNumberLocality> GetAvailableLocalities(string twoLetterIsoCountryName, string administrativeDivision = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.Communication.PhoneNumbers.PhoneNumberLocality> GetAvailableLocalitiesAsync(string twoLetterIsoCountryName, Azure.Communication.PhoneNumbers.PhoneNumberType phoneNumberType, string administrativeDivision = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.Communication.PhoneNumbers.PhoneNumberLocality> GetAvailableLocalitiesAsync(string twoLetterIsoCountryName, string administrativeDivision = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.Communication.PhoneNumbers.PhoneNumberOffering> GetAvailableOfferings(string twoLetterIsoCountryName, Azure.Communication.PhoneNumbers.PhoneNumberType? phoneNumberType = default(Azure.Communication.PhoneNumbers.PhoneNumberType?), Azure.Communication.PhoneNumbers.PhoneNumberAssignmentType? phoneNumberAssignmentType = default(Azure.Communication.PhoneNumbers.PhoneNumberAssignmentType?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.Communication.PhoneNumbers.PhoneNumberOffering> GetAvailableOfferingsAsync(string twoLetterIsoCountryName, Azure.Communication.PhoneNumbers.PhoneNumberType? phoneNumberType = default(Azure.Communication.PhoneNumbers.PhoneNumberType?), Azure.Communication.PhoneNumbers.PhoneNumberAssignmentType? phoneNumberAssignmentType = default(Azure.Communication.PhoneNumbers.PhoneNumberAssignmentType?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Communication.PhoneNumbers.PhoneNumberSearchResult> GetPhoneNumberSearchResult(string searchId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Communication.PhoneNumbers.PhoneNumberSearchResult>> GetPhoneNumberSearchResultAsync(string searchId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Communication.PhoneNumbers.PurchasedPhoneNumber> GetPurchasedPhoneNumber(string phoneNumber, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Communication.PhoneNumbers.PurchasedPhoneNumber>> GetPurchasedPhoneNumberAsync(string phoneNumber, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.Communication.PhoneNumbers.PurchasedPhoneNumber> GetPurchasedPhoneNumbers(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.Communication.PhoneNumbers.PurchasedPhoneNumber> GetPurchasedPhoneNumbersAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Communication.PhoneNumbers.PhoneNumbersReservation> GetReservation(System.Guid id, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Communication.PhoneNumbers.PhoneNumbersReservation>> GetReservationAsync(System.Guid id, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.Communication.PhoneNumbers.PhoneNumbersReservation> GetReservations(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.Communication.PhoneNumbers.PhoneNumbersReservation> GetReservationsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Communication.PhoneNumbers.OperatorInformationResult> SearchOperatorInformation(System.Collections.Generic.IEnumerable<string> phoneNumbers, Azure.Communication.PhoneNumbers.OperatorInformationOptions options = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Communication.PhoneNumbers.OperatorInformationResult>> SearchOperatorInformationAsync(System.Collections.Generic.IEnumerable<string> phoneNumbers, Azure.Communication.PhoneNumbers.OperatorInformationOptions options = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Communication.PhoneNumbers.PurchasePhoneNumbersOperation StartPurchasePhoneNumbers(string searchId, bool agreeToNotResell, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Communication.PhoneNumbers.PurchasePhoneNumbersOperation StartPurchasePhoneNumbers(string searchId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Communication.PhoneNumbers.PurchasePhoneNumbersOperation> StartPurchasePhoneNumbersAsync(string searchId, bool agreeToNotResell, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Communication.PhoneNumbers.PurchasePhoneNumbersOperation> StartPurchasePhoneNumbersAsync(string searchId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Communication.PhoneNumbers.PurchaseReservationOperation StartPurchaseReservation(System.Guid reservationId, bool agreeToNotResell = false, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Communication.PhoneNumbers.PurchaseReservationOperation> StartPurchaseReservationAsync(System.Guid reservationId, bool agreeToNotResell = false, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Communication.PhoneNumbers.ReleasePhoneNumberOperation StartReleasePhoneNumber(string phoneNumber, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Communication.PhoneNumbers.ReleasePhoneNumberOperation> StartReleasePhoneNumberAsync(string phoneNumber, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Communication.PhoneNumbers.SearchAvailablePhoneNumbersOperation StartSearchAvailablePhoneNumbers(string twoLetterIsoCountryName, Azure.Communication.PhoneNumbers.PhoneNumberType phoneNumberType, Azure.Communication.PhoneNumbers.PhoneNumberAssignmentType phoneNumberAssignmentType, Azure.Communication.PhoneNumbers.PhoneNumberCapabilities capabilities, Azure.Communication.PhoneNumbers.PhoneNumberSearchOptions options = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Communication.PhoneNumbers.SearchAvailablePhoneNumbersOperation> StartSearchAvailablePhoneNumbersAsync(string twoLetterIsoCountryName, Azure.Communication.PhoneNumbers.PhoneNumberType phoneNumberType, Azure.Communication.PhoneNumbers.PhoneNumberAssignmentType phoneNumberAssignmentType, Azure.Communication.PhoneNumbers.PhoneNumberCapabilities capabilities, Azure.Communication.PhoneNumbers.PhoneNumberSearchOptions options = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Communication.PhoneNumbers.UpdatePhoneNumberCapabilitiesOperation StartUpdateCapabilities(string phoneNumber, Azure.Communication.PhoneNumbers.PhoneNumberCapabilityType? calling = default(Azure.Communication.PhoneNumbers.PhoneNumberCapabilityType?), Azure.Communication.PhoneNumbers.PhoneNumberCapabilityType? sms = default(Azure.Communication.PhoneNumbers.PhoneNumberCapabilityType?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Communication.PhoneNumbers.UpdatePhoneNumberCapabilitiesOperation> StartUpdateCapabilitiesAsync(string phoneNumber, Azure.Communication.PhoneNumbers.PhoneNumberCapabilityType? calling = default(Azure.Communication.PhoneNumbers.PhoneNumberCapabilityType?), Azure.Communication.PhoneNumbers.PhoneNumberCapabilityType? sms = default(Azure.Communication.PhoneNumbers.PhoneNumberCapabilityType?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class PhoneNumbersClientOptions : Azure.Core.ClientOptions
    {
        public PhoneNumbersClientOptions(Azure.Communication.PhoneNumbers.PhoneNumbersClientOptions.ServiceVersion version = Azure.Communication.PhoneNumbers.PhoneNumbersClientOptions.ServiceVersion.V2025_06_01) { }
        public string? AcceptedLanguage { get { throw null; } set { } }
        public enum ServiceVersion
        {
            V2021_03_07 = 1,
            [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
            V2022_01_11_Preview_2 = 2,
            V2022_12_01 = 3,
            V2025_02_11 = 4,
            V2025_04_01 = 5,
            V2025_06_01 = 6,
        }
    }
    public partial class PhoneNumberSearchOptions
    {
        public PhoneNumberSearchOptions() { }
        public string AdministrativeDivision { get { throw null; } set { } }
        public string AreaCode { get { throw null; } set { } }
        public string Locality { get { throw null; } set { } }
        public int? Quantity { get { throw null; } set { } }
    }
    public partial class PhoneNumberSearchResult
    {
        internal PhoneNumberSearchResult() { }
        public Azure.Communication.PhoneNumbers.PhoneNumberAssignmentType AssignmentType { get { throw null; } }
        public Azure.Communication.PhoneNumbers.PhoneNumberCapabilities Capabilities { get { throw null; } }
        public Azure.Communication.PhoneNumbers.PhoneNumberCost Cost { get { throw null; } }
        public Azure.Communication.PhoneNumbers.PhoneNumberSearchResultError? Error { get { throw null; } }
        public int? ErrorCode { get { throw null; } }
        public bool? IsAgreementToNotResellRequired { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> PhoneNumbers { get { throw null; } }
        public Azure.Communication.PhoneNumbers.PhoneNumberType PhoneNumberType { get { throw null; } }
        public System.DateTimeOffset SearchExpiresOn { get { throw null; } }
        public string SearchId { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PhoneNumberSearchResultError : System.IEquatable<Azure.Communication.PhoneNumbers.PhoneNumberSearchResultError>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PhoneNumberSearchResultError(string value) { throw null; }
        public static Azure.Communication.PhoneNumbers.PhoneNumberSearchResultError AllNumbersNotAcquired { get { throw null; } }
        public static Azure.Communication.PhoneNumbers.PhoneNumberSearchResultError AuthorizationDenied { get { throw null; } }
        public static Azure.Communication.PhoneNumbers.PhoneNumberSearchResultError BillingUnavailable { get { throw null; } }
        public static Azure.Communication.PhoneNumbers.PhoneNumberSearchResultError InvalidAddress { get { throw null; } }
        public static Azure.Communication.PhoneNumbers.PhoneNumberSearchResultError InvalidOfferModel { get { throw null; } }
        public static Azure.Communication.PhoneNumbers.PhoneNumberSearchResultError MissingAddress { get { throw null; } }
        public static Azure.Communication.PhoneNumbers.PhoneNumberSearchResultError NoError { get { throw null; } }
        public static Azure.Communication.PhoneNumbers.PhoneNumberSearchResultError NotEnoughCredit { get { throw null; } }
        public static Azure.Communication.PhoneNumbers.PhoneNumberSearchResultError NotEnoughLicenses { get { throw null; } }
        public static Azure.Communication.PhoneNumbers.PhoneNumberSearchResultError NoWallet { get { throw null; } }
        public static Azure.Communication.PhoneNumbers.PhoneNumberSearchResultError NumbersPartiallyAcquired { get { throw null; } }
        public static Azure.Communication.PhoneNumbers.PhoneNumberSearchResultError OutOfStock { get { throw null; } }
        public static Azure.Communication.PhoneNumbers.PhoneNumberSearchResultError ProvisioningFailed { get { throw null; } }
        public static Azure.Communication.PhoneNumbers.PhoneNumberSearchResultError PurchaseFailed { get { throw null; } }
        public static Azure.Communication.PhoneNumbers.PhoneNumberSearchResultError ReservationExpired { get { throw null; } }
        public static Azure.Communication.PhoneNumbers.PhoneNumberSearchResultError UnknownErrorCode { get { throw null; } }
        public static Azure.Communication.PhoneNumbers.PhoneNumberSearchResultError UnknownSearchError { get { throw null; } }
        public bool Equals(Azure.Communication.PhoneNumbers.PhoneNumberSearchResultError other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Communication.PhoneNumbers.PhoneNumberSearchResultError left, Azure.Communication.PhoneNumbers.PhoneNumberSearchResultError right) { throw null; }
        public static implicit operator Azure.Communication.PhoneNumbers.PhoneNumberSearchResultError (string value) { throw null; }
        public static bool operator !=(Azure.Communication.PhoneNumbers.PhoneNumberSearchResultError left, Azure.Communication.PhoneNumbers.PhoneNumberSearchResultError right) { throw null; }
        public override string ToString() { throw null; }
    }
    public static partial class PhoneNumbersModelFactory
    {
        public static Azure.Communication.PhoneNumbers.AvailablePhoneNumber AvailablePhoneNumber(string id = null, string countryCode = null, string phoneNumber = null, Azure.Communication.PhoneNumbers.PhoneNumberCapabilities capabilities = null, Azure.Communication.PhoneNumbers.PhoneNumberType phoneNumberType = default(Azure.Communication.PhoneNumbers.PhoneNumberType), Azure.Communication.PhoneNumbers.PhoneNumberAssignmentType assignmentType = default(Azure.Communication.PhoneNumbers.PhoneNumberAssignmentType), Azure.Communication.PhoneNumbers.PhoneNumberCost cost = null, Azure.Communication.PhoneNumbers.PhoneNumberAvailabilityStatus status = default(Azure.Communication.PhoneNumbers.PhoneNumberAvailabilityStatus), bool isAgreementToNotResellRequired = false, Azure.ResponseError error = null) { throw null; }
        public static Azure.Communication.PhoneNumbers.OperatorDetails OperatorDetails(string name = null, string mobileNetworkCode = null, string mobileCountryCode = null) { throw null; }
        public static Azure.Communication.PhoneNumbers.OperatorInformation OperatorInformation(string phoneNumber = null, string nationalFormat = null, string internationalFormat = null, string isoCountryCode = null, Azure.Communication.PhoneNumbers.OperatorNumberType? numberType = default(Azure.Communication.PhoneNumbers.OperatorNumberType?), Azure.Communication.PhoneNumbers.OperatorDetails operatorDetails = null) { throw null; }
        public static Azure.Communication.PhoneNumbers.OperatorInformationResult OperatorInformationResult(System.Collections.Generic.IEnumerable<Azure.Communication.PhoneNumbers.OperatorInformation> values = null) { throw null; }
        public static Azure.Communication.PhoneNumbers.PhoneNumberAdministrativeDivision PhoneNumberAdministrativeDivision(string localizedName = null, string abbreviatedName = null) { throw null; }
        public static Azure.Communication.PhoneNumbers.PhoneNumberAreaCode PhoneNumberAreaCode(string areaCode = null) { throw null; }
        public static Azure.Communication.PhoneNumbers.PhoneNumberCost PhoneNumberCost(double amount = 0, string isoCurrencySymbol = null, Azure.Communication.PhoneNumbers.BillingFrequency billingFrequency = default(Azure.Communication.PhoneNumbers.BillingFrequency)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.Communication.PhoneNumbers.PhoneNumberCost PhoneNumberCost(double amount, string currencyCode, string billingFrequency) { throw null; }
        public static Azure.Communication.PhoneNumbers.PhoneNumberCountry PhoneNumberCountry(string localizedName = null, string countryCode = null) { throw null; }
        public static Azure.Communication.PhoneNumbers.PhoneNumberLocality PhoneNumberLocality(string localizedName = null, Azure.Communication.PhoneNumbers.PhoneNumberAdministrativeDivision administrativeDivision = null) { throw null; }
        public static Azure.Communication.PhoneNumbers.PhoneNumberOffering PhoneNumberOffering(Azure.Communication.PhoneNumbers.PhoneNumberType? phoneNumberType = default(Azure.Communication.PhoneNumbers.PhoneNumberType?), Azure.Communication.PhoneNumbers.PhoneNumberAssignmentType? assignmentType = default(Azure.Communication.PhoneNumbers.PhoneNumberAssignmentType?), Azure.Communication.PhoneNumbers.PhoneNumberCapabilities availableCapabilities = null, Azure.Communication.PhoneNumbers.PhoneNumberCost cost = null) { throw null; }
        public static Azure.Communication.PhoneNumbers.PhoneNumbersBrowseResult PhoneNumbersBrowseResult(System.Collections.Generic.IEnumerable<Azure.Communication.PhoneNumbers.AvailablePhoneNumber> phoneNumbers = null) { throw null; }
        public static Azure.Communication.PhoneNumbers.PhoneNumberSearchResult PhoneNumberSearchResult(string searchId, System.Collections.Generic.IEnumerable<string> phoneNumbers, Azure.Communication.PhoneNumbers.PhoneNumberType phoneNumberType, Azure.Communication.PhoneNumbers.PhoneNumberAssignmentType assignmentType, Azure.Communication.PhoneNumbers.PhoneNumberCapabilities capabilities, Azure.Communication.PhoneNumbers.PhoneNumberCost cost, System.DateTimeOffset searchExpiresOn) { throw null; }
        public static Azure.Communication.PhoneNumbers.PhoneNumberSearchResult PhoneNumberSearchResult(string searchId = null, System.Collections.Generic.IEnumerable<string> phoneNumbers = null, Azure.Communication.PhoneNumbers.PhoneNumberType phoneNumberType = default(Azure.Communication.PhoneNumbers.PhoneNumberType), Azure.Communication.PhoneNumbers.PhoneNumberAssignmentType assignmentType = default(Azure.Communication.PhoneNumbers.PhoneNumberAssignmentType), Azure.Communication.PhoneNumbers.PhoneNumberCapabilities capabilities = null, Azure.Communication.PhoneNumbers.PhoneNumberCost cost = null, System.DateTimeOffset searchExpiresOn = default(System.DateTimeOffset), bool? isAgreementToNotResellRequired = default(bool?), int? errorCode = default(int?), Azure.Communication.PhoneNumbers.PhoneNumberSearchResultError? error = default(Azure.Communication.PhoneNumbers.PhoneNumberSearchResultError?)) { throw null; }
        public static Azure.Communication.PhoneNumbers.PhoneNumberSearchResult PhoneNumberSearchResult(string searchId = null, System.Collections.Generic.IEnumerable<string> phoneNumbers = null, Azure.Communication.PhoneNumbers.PhoneNumberType phoneNumberType = default(Azure.Communication.PhoneNumbers.PhoneNumberType), Azure.Communication.PhoneNumbers.PhoneNumberAssignmentType assignmentType = default(Azure.Communication.PhoneNumbers.PhoneNumberAssignmentType), Azure.Communication.PhoneNumbers.PhoneNumberCapabilities capabilities = null, Azure.Communication.PhoneNumbers.PhoneNumberCost cost = null, System.DateTimeOffset searchExpiresOn = default(System.DateTimeOffset), int? errorCode = default(int?), Azure.Communication.PhoneNumbers.PhoneNumberSearchResultError? error = default(Azure.Communication.PhoneNumbers.PhoneNumberSearchResultError?)) { throw null; }
        public static Azure.Communication.PhoneNumbers.PhoneNumbersReservation PhoneNumbersReservation(System.Guid id = default(System.Guid), System.DateTimeOffset expiresAt = default(System.DateTimeOffset), System.Collections.Generic.IDictionary<string, Azure.Communication.PhoneNumbers.AvailablePhoneNumber> phoneNumbers = null, Azure.Communication.PhoneNumbers.ReservationStatus status = default(Azure.Communication.PhoneNumbers.ReservationStatus)) { throw null; }
        public static Azure.Communication.PhoneNumbers.PurchasedPhoneNumber PurchasedPhoneNumber(string id, string phoneNumber, string countryCode, Azure.Communication.PhoneNumbers.PhoneNumberType phoneNumberType, Azure.Communication.PhoneNumbers.PhoneNumberCapabilities capabilities, Azure.Communication.PhoneNumbers.PhoneNumberAssignmentType assignmentType, System.DateTimeOffset purchaseDate, Azure.Communication.PhoneNumbers.PhoneNumberCost cost) { throw null; }
    }
    public partial class PhoneNumbersReservation
    {
        internal PhoneNumbersReservation() { }
        public System.DateTimeOffset ExpiresAt { get { throw null; } }
        public System.Guid Id { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, Azure.Communication.PhoneNumbers.AvailablePhoneNumber> PhoneNumbers { get { throw null; } }
        public Azure.Communication.PhoneNumbers.ReservationStatus Status { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PhoneNumberType : System.IEquatable<Azure.Communication.PhoneNumbers.PhoneNumberType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PhoneNumberType(string value) { throw null; }
        public static Azure.Communication.PhoneNumbers.PhoneNumberType Geographic { get { throw null; } }
        public static Azure.Communication.PhoneNumbers.PhoneNumberType Mobile { get { throw null; } }
        public static Azure.Communication.PhoneNumbers.PhoneNumberType TollFree { get { throw null; } }
        public bool Equals(Azure.Communication.PhoneNumbers.PhoneNumberType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Communication.PhoneNumbers.PhoneNumberType left, Azure.Communication.PhoneNumbers.PhoneNumberType right) { throw null; }
        public static implicit operator Azure.Communication.PhoneNumbers.PhoneNumberType (string value) { throw null; }
        public static bool operator !=(Azure.Communication.PhoneNumbers.PhoneNumberType left, Azure.Communication.PhoneNumbers.PhoneNumberType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class PurchasedPhoneNumber
    {
        internal PurchasedPhoneNumber() { }
        public Azure.Communication.PhoneNumbers.PhoneNumberAssignmentType AssignmentType { get { throw null; } }
        public Azure.Communication.PhoneNumbers.PhoneNumberCapabilities Capabilities { get { throw null; } }
        public Azure.Communication.PhoneNumbers.PhoneNumberCost Cost { get { throw null; } }
        public string CountryCode { get { throw null; } }
        public string Id { get { throw null; } }
        public string PhoneNumber { get { throw null; } }
        public Azure.Communication.PhoneNumbers.PhoneNumberType PhoneNumberType { get { throw null; } }
        public System.DateTimeOffset PurchaseDate { get { throw null; } }
    }
    public partial class PurchasePhoneNumbersOperation : Azure.Operation
    {
        protected PurchasePhoneNumbersOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken) { throw null; }
    }
    public partial class PurchaseReservationOperation : Azure.Operation
    {
        protected PurchaseReservationOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken) { throw null; }
    }
    public partial class ReleasePhoneNumberOperation : Azure.Operation
    {
        protected ReleasePhoneNumberOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ReservationStatus : System.IEquatable<Azure.Communication.PhoneNumbers.ReservationStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ReservationStatus(string value) { throw null; }
        public static Azure.Communication.PhoneNumbers.ReservationStatus Active { get { throw null; } }
        public static Azure.Communication.PhoneNumbers.ReservationStatus Completed { get { throw null; } }
        public static Azure.Communication.PhoneNumbers.ReservationStatus Expired { get { throw null; } }
        public static Azure.Communication.PhoneNumbers.ReservationStatus Submitted { get { throw null; } }
        public bool Equals(Azure.Communication.PhoneNumbers.ReservationStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Communication.PhoneNumbers.ReservationStatus left, Azure.Communication.PhoneNumbers.ReservationStatus right) { throw null; }
        public static implicit operator Azure.Communication.PhoneNumbers.ReservationStatus (string value) { throw null; }
        public static bool operator !=(Azure.Communication.PhoneNumbers.ReservationStatus left, Azure.Communication.PhoneNumbers.ReservationStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SearchAvailablePhoneNumbersOperation : Azure.Operation<Azure.Communication.PhoneNumbers.PhoneNumberSearchResult>
    {
        protected SearchAvailablePhoneNumbersOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.Communication.PhoneNumbers.PhoneNumberSearchResult Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override Azure.Response<Azure.Communication.PhoneNumbers.PhoneNumberSearchResult> WaitForCompletion(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override Azure.Response<Azure.Communication.PhoneNumbers.PhoneNumberSearchResult> WaitForCompletion(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.Communication.PhoneNumbers.PhoneNumberSearchResult>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.Communication.PhoneNumbers.PhoneNumberSearchResult>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class UpdatePhoneNumberCapabilitiesOperation : Azure.Operation<Azure.Communication.PhoneNumbers.PurchasedPhoneNumber>
    {
        protected UpdatePhoneNumberCapabilitiesOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.Communication.PhoneNumbers.PurchasedPhoneNumber Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override Azure.Response<Azure.Communication.PhoneNumbers.PurchasedPhoneNumber> WaitForCompletion(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override Azure.Response<Azure.Communication.PhoneNumbers.PurchasedPhoneNumber> WaitForCompletion(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.Communication.PhoneNumbers.PurchasedPhoneNumber>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.Communication.PhoneNumbers.PurchasedPhoneNumber>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.Communication.PhoneNumbers.SipRouting
{
    public partial class SipRoutingClient
    {
        protected SipRoutingClient() { }
        public SipRoutingClient(string connectionString) { }
        public SipRoutingClient(string connectionString, Azure.Communication.PhoneNumbers.SipRouting.SipRoutingClientOptions options) { }
        public SipRoutingClient(System.Uri endpoint, Azure.AzureKeyCredential keyCredential, Azure.Communication.PhoneNumbers.SipRouting.SipRoutingClientOptions options = null) { }
        public SipRoutingClient(System.Uri endpoint, Azure.Core.TokenCredential tokenCredential, Azure.Communication.PhoneNumbers.SipRouting.SipRoutingClientOptions options = null) { }
        public virtual Azure.Response DeleteTrunk(string fqdn, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteTrunkAsync(string fqdn, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<System.Collections.Generic.IReadOnlyList<Azure.Communication.PhoneNumbers.SipRouting.SipTrunkRoute>> GetRoutes(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<System.Collections.Generic.IReadOnlyList<Azure.Communication.PhoneNumbers.SipRouting.SipTrunkRoute>>> GetRoutesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Communication.PhoneNumbers.SipRouting.SipTrunk> GetTrunk(string fqdn, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Communication.PhoneNumbers.SipRouting.SipTrunk>> GetTrunkAsync(string fqdn, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<System.Collections.Generic.IReadOnlyList<Azure.Communication.PhoneNumbers.SipRouting.SipTrunk>> GetTrunks(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<System.Collections.Generic.IReadOnlyList<Azure.Communication.PhoneNumbers.SipRouting.SipTrunk>>> GetTrunksAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response SetRoutes(System.Collections.Generic.IReadOnlyList<Azure.Communication.PhoneNumbers.SipRouting.SipTrunkRoute> routes, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> SetRoutesAsync(System.Collections.Generic.IReadOnlyList<Azure.Communication.PhoneNumbers.SipRouting.SipTrunkRoute> routes, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response SetTrunk(Azure.Communication.PhoneNumbers.SipRouting.SipTrunk trunk, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> SetTrunkAsync(Azure.Communication.PhoneNumbers.SipRouting.SipTrunk trunk, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response SetTrunks(System.Collections.Generic.IEnumerable<Azure.Communication.PhoneNumbers.SipRouting.SipTrunk> trunks, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> SetTrunksAsync(System.Collections.Generic.IEnumerable<Azure.Communication.PhoneNumbers.SipRouting.SipTrunk> trunks, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SipRoutingClientOptions : Azure.Core.ClientOptions
    {
        public SipRoutingClientOptions(Azure.Communication.PhoneNumbers.SipRouting.SipRoutingClientOptions.ServiceVersion version = Azure.Communication.PhoneNumbers.SipRouting.SipRoutingClientOptions.ServiceVersion.V2023_03_01) { }
        public enum ServiceVersion
        {
            V2023_03_01 = 1,
        }
    }
    public partial class SipTrunk
    {
        public SipTrunk(string fqdn, int sipSignalingPort) { }
        public string Fqdn { get { throw null; } }
        public int SipSignalingPort { get { throw null; } set { } }
    }
    public partial class SipTrunkRoute
    {
        public SipTrunkRoute(string name, string numberPattern, string description = null, System.Collections.Generic.IEnumerable<string> trunks = null) { }
        public string Description { get { throw null; } }
        public string Name { get { throw null; } }
        public string NumberPattern { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> Trunks { get { throw null; } }
    }
}
