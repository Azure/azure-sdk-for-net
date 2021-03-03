namespace Azure.Communication.PhoneNumbers
{
    public partial class PhoneNumberAdministrationClient
    {
        protected PhoneNumberAdministrationClient() { }
        public PhoneNumberAdministrationClient(string connectionString) { }
        public PhoneNumberAdministrationClient(string connectionString, Azure.Communication.PhoneNumbers.PhoneNumberAdministrationClientOptions options) { }
        public PhoneNumberAdministrationClient(System.Uri endpoint, Azure.AzureKeyCredential keyCredential, Azure.Communication.PhoneNumbers.PhoneNumberAdministrationClientOptions? options = null) { }
        public PhoneNumberAdministrationClient(System.Uri endpoint, Azure.Core.TokenCredential tokenCredential, Azure.Communication.PhoneNumbers.PhoneNumberAdministrationClientOptions? options = null) { }
        public virtual Azure.Response CancelReservation(string reservationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> CancelReservationAsync(string reservationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response ConfigureNumber(Azure.Communication.PhoneNumbers.Models.PstnConfiguration pstnConfiguration, Azure.Communication.PhoneNumberIdentifier phoneNumber, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> ConfigureNumberAsync(Azure.Communication.PhoneNumbers.Models.PstnConfiguration pstnConfiguration, Azure.Communication.PhoneNumberIdentifier phoneNumber, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Communication.PhoneNumbers.Models.AreaCodes> GetAllAreaCodes(string locationType, string countryCode, string phonePlanId, System.Collections.Generic.IEnumerable<Azure.Communication.PhoneNumbers.Models.LocationOptionsQuery> locationOptions, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Communication.PhoneNumbers.Models.AreaCodes>> GetAllAreaCodesAsync(string locationType, string countryCode, string phonePlanId, System.Collections.Generic.IEnumerable<Azure.Communication.PhoneNumbers.Models.LocationOptionsQuery> locationOptions, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.Communication.PhoneNumbers.Models.AcquiredPhoneNumber> GetAllPhoneNumbers(string? locale = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.Communication.PhoneNumbers.Models.AcquiredPhoneNumber> GetAllPhoneNumbersAsync(string? locale = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.Communication.PhoneNumbers.Models.PhoneNumberEntity> GetAllReleases(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.Communication.PhoneNumbers.Models.PhoneNumberEntity> GetAllReleasesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.Communication.PhoneNumbers.Models.PhoneNumberEntity> GetAllReservations(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.Communication.PhoneNumbers.Models.PhoneNumberEntity> GetAllReservationsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.Communication.PhoneNumbers.Models.PhoneNumberCountry> GetAllSupportedCountries(string? locale = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.Communication.PhoneNumbers.Models.PhoneNumberCountry> GetAllSupportedCountriesAsync(string? locale = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Communication.PhoneNumbers.Models.UpdatePhoneNumberCapabilitiesResponse> GetCapabilitiesUpdate(string capabilitiesUpdateId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Communication.PhoneNumbers.Models.UpdatePhoneNumberCapabilitiesResponse>> GetCapabilitiesUpdateAsync(string capabilitiesUpdateId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Communication.PhoneNumbers.Models.NumberConfigurationResponse> GetNumberConfiguration(Azure.Communication.PhoneNumberIdentifier phoneNumber, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Communication.PhoneNumbers.Models.NumberConfigurationResponse>> GetNumberConfigurationAsync(Azure.Communication.PhoneNumberIdentifier phoneNumber, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.Communication.PhoneNumbers.Models.PhonePlanGroup> GetPhonePlanGroups(string countryCode, string? locale = null, bool? includeRateInformation = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.Communication.PhoneNumbers.Models.PhonePlanGroup> GetPhonePlanGroupsAsync(string countryCode, string? locale = null, bool? includeRateInformation = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Communication.PhoneNumbers.Models.LocationOptionsResponse> GetPhonePlanLocationOptions(string countryCode, string phonePlanGroupId, string phonePlanId, string? locale = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Communication.PhoneNumbers.Models.LocationOptionsResponse>> GetPhonePlanLocationOptionsAsync(string countryCode, string phonePlanGroupId, string phonePlanId, string? locale = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.Communication.PhoneNumbers.Models.PhonePlan> GetPhonePlans(string countryCode, string phonePlanGroupId, string? locale = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.Communication.PhoneNumbers.Models.PhonePlan> GetPhonePlansAsync(string countryCode, string phonePlanGroupId, string? locale = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Communication.PhoneNumbers.Models.PhoneNumberRelease> GetReleaseById(string releaseId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Communication.PhoneNumbers.Models.PhoneNumberRelease>> GetReleaseByIdAsync(string releaseId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Communication.PhoneNumbers.Models.PhoneNumberReservation> GetReservationById(string reservationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Communication.PhoneNumbers.Models.PhoneNumberReservation>> GetReservationByIdAsync(string reservationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Communication.PhoneNumbers.Models.PhoneNumberReservationPurchaseOperation StartPurchaseReservation(string reservationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Communication.PhoneNumbers.Models.PhoneNumberReservationPurchaseOperation> StartPurchaseReservationAsync(string reservationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Communication.PhoneNumbers.Models.ReleasePhoneNumberOperation StartReleasePhoneNumber(Azure.Communication.PhoneNumberIdentifier phoneNumber, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Communication.PhoneNumbers.Models.ReleasePhoneNumberOperation> StartReleasePhoneNumberAsync(Azure.Communication.PhoneNumberIdentifier phoneNumber, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Communication.PhoneNumbers.Models.ReleasePhoneNumberOperation StartReleasePhoneNumbers(System.Collections.Generic.IEnumerable<Azure.Communication.PhoneNumberIdentifier> phoneNumbers, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Communication.PhoneNumbers.Models.ReleasePhoneNumberOperation> StartReleasePhoneNumbersAsync(System.Collections.Generic.IEnumerable<Azure.Communication.PhoneNumberIdentifier> phoneNumbers, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Communication.PhoneNumbers.Models.PhoneNumberReservationOperation StartReservation(Azure.Communication.PhoneNumbers.Models.CreateReservationOptions body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Communication.PhoneNumbers.Models.PhoneNumberReservationOperation> StartReservationAsync(Azure.Communication.PhoneNumbers.Models.CreateReservationOptions body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response UnconfigureNumber(Azure.Communication.PhoneNumberIdentifier phoneNumber, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> UnconfigureNumberAsync(Azure.Communication.PhoneNumberIdentifier phoneNumber, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Communication.PhoneNumbers.Models.UpdateNumberCapabilitiesResponse> UpdateCapabilities(System.Collections.Generic.IDictionary<string, Azure.Communication.PhoneNumbers.Models.NumberUpdateCapabilities> phoneNumberUpdateCapabilities, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Communication.PhoneNumbers.Models.UpdateNumberCapabilitiesResponse>> UpdateCapabilitiesAsync(System.Collections.Generic.IDictionary<string, Azure.Communication.PhoneNumbers.Models.NumberUpdateCapabilities> phoneNumberUpdateCapabilities, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class PhoneNumberAdministrationClientOptions : Azure.Core.ClientOptions
    {
        public const Azure.Communication.PhoneNumbers.PhoneNumberAdministrationClientOptions.ServiceVersion LatestVersion = Azure.Communication.PhoneNumbers.PhoneNumberAdministrationClientOptions.ServiceVersion.V1;
        public PhoneNumberAdministrationClientOptions(Azure.Communication.PhoneNumbers.PhoneNumberAdministrationClientOptions.ServiceVersion version = Azure.Communication.PhoneNumbers.PhoneNumberAdministrationClientOptions.ServiceVersion.V1, Azure.Core.RetryOptions? retryOptions = null, Azure.Core.Pipeline.HttpPipelineTransport? transport = null) { }
        public enum ServiceVersion
        {
            V1 = 1,
        }
    }
}
namespace Azure.Communication.PhoneNumbers.Models
{
    public partial class AcquiredPhoneNumber
    {
        internal AcquiredPhoneNumber() { }
        public System.Collections.Generic.IReadOnlyList<Azure.Communication.PhoneNumbers.Models.PhoneNumberCapability> AcquiredCapabilities { get { throw null; } }
        public Azure.Communication.PhoneNumbers.Models.ActivationState? ActivationState { get { throw null; } }
        public Azure.Communication.PhoneNumbers.Models.AssignmentStatus? AssignmentStatus { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Communication.PhoneNumbers.Models.PhoneNumberCapability> AvailableCapabilities { get { throw null; } }
        public string PhoneNumber { get { throw null; } }
        public string PlaceName { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ActivationState : System.IEquatable<Azure.Communication.PhoneNumbers.Models.ActivationState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ActivationState(string value) { throw null; }
        public static Azure.Communication.PhoneNumbers.Models.ActivationState Activated { get { throw null; } }
        public static Azure.Communication.PhoneNumbers.Models.ActivationState AssignmentFailed { get { throw null; } }
        public static Azure.Communication.PhoneNumbers.Models.ActivationState AssignmentPending { get { throw null; } }
        public static Azure.Communication.PhoneNumbers.Models.ActivationState UpdateFailed { get { throw null; } }
        public static Azure.Communication.PhoneNumbers.Models.ActivationState UpdatePending { get { throw null; } }
        public bool Equals(Azure.Communication.PhoneNumbers.Models.ActivationState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Communication.PhoneNumbers.Models.ActivationState left, Azure.Communication.PhoneNumbers.Models.ActivationState right) { throw null; }
        public static implicit operator Azure.Communication.PhoneNumbers.Models.ActivationState (string value) { throw null; }
        public static bool operator !=(Azure.Communication.PhoneNumbers.Models.ActivationState left, Azure.Communication.PhoneNumbers.Models.ActivationState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public static partial class AdministrationModelFactory
    {
        public static Azure.Communication.PhoneNumbers.Models.AcquiredPhoneNumber AcquiredPhoneNumber(string phoneNumber, System.Collections.Generic.IEnumerable<Azure.Communication.PhoneNumbers.Models.PhoneNumberCapability> acquiredCapabilities, System.Collections.Generic.IEnumerable<Azure.Communication.PhoneNumbers.Models.PhoneNumberCapability> availableCapabilities) { throw null; }
        public static Azure.Communication.PhoneNumbers.Models.AreaCodes AreaCodes(System.Collections.Generic.IReadOnlyList<string> primaryAreaCodes, System.Collections.Generic.IReadOnlyList<string> secondaryAreaCodes, string nextLink) { throw null; }
        public static Azure.Communication.PhoneNumbers.Models.CarrierDetails CarrierDetails(string name, string localizedName) { throw null; }
        public static Azure.Communication.PhoneNumbers.Models.LocationOptions LocationOptions(string labelId, string labelName, System.Collections.Generic.IList<Azure.Communication.PhoneNumbers.Models.LocationOptionsDetails> options) { throw null; }
        public static Azure.Communication.PhoneNumbers.Models.LocationOptionsDetails LocationOptionsDetails(string name, string value, System.Collections.Generic.IList<Azure.Communication.PhoneNumbers.Models.LocationOptions> locationOptions) { throw null; }
        public static Azure.Communication.PhoneNumbers.Models.LocationOptionsResponse LocationOptionsResponse(Azure.Communication.PhoneNumbers.Models.LocationOptions locationOptions) { throw null; }
        public static Azure.Communication.PhoneNumbers.Models.NumberConfigurationResponse NumberConfigurationResponse(Azure.Communication.PhoneNumbers.Models.PstnConfiguration pstnConfiguration) { throw null; }
        public static Azure.Communication.PhoneNumbers.Models.NumberUpdateCapabilities NumberUpdateCapabilities(System.Collections.Generic.IList<Azure.Communication.PhoneNumbers.Models.PhoneNumberCapability> add, System.Collections.Generic.IList<Azure.Communication.PhoneNumbers.Models.PhoneNumberCapability> remove) { throw null; }
        public static Azure.Communication.PhoneNumbers.Models.PhoneNumberCountry PhoneNumberCountry(string localizedName, string countryCode) { throw null; }
        public static Azure.Communication.PhoneNumbers.Models.PhoneNumberEntity PhoneNumberEntity(string id, System.DateTimeOffset? createdAt, string displayName, int? quantity, int? quantityObtained, string status, System.DateTimeOffset? focDate) { throw null; }
        public static Azure.Communication.PhoneNumbers.Models.PhoneNumberRelease PhoneNumberRelease(string releaseId, System.DateTimeOffset? createdAt, Azure.Communication.PhoneNumbers.Models.ReleaseStatus? status, string errorMessage, System.Collections.Generic.IReadOnlyDictionary<string, Azure.Communication.PhoneNumbers.Models.PhoneNumberReleaseDetails> phoneNumberReleaseStatusDetails) { throw null; }
        public static Azure.Communication.PhoneNumbers.Models.PhoneNumberReleaseDetails PhoneNumberReleaseDetails(Azure.Communication.PhoneNumbers.Models.PhoneNumberReleaseStatus? status, int? errorCode) { throw null; }
        public static Azure.Communication.PhoneNumbers.Models.PhoneNumberReservation PhoneNumberReservation(string reservationId, string displayName, System.DateTimeOffset? createdAt, string description, System.Collections.Generic.IReadOnlyList<string> phonePlanIds, string areaCode, int? quantity, System.Collections.Generic.IReadOnlyList<Azure.Communication.PhoneNumbers.Models.LocationOptionsDetails> locationOptions, Azure.Communication.PhoneNumbers.Models.ReservationStatus? status, System.Collections.Generic.IReadOnlyList<string> phoneNumbers, System.DateTimeOffset? reservationExpiryDate, int? errorCode) { throw null; }
        public static Azure.Communication.PhoneNumbers.Models.PhoneNumberReservationOperation PhoneNumberReservationOperation(Azure.Communication.PhoneNumbers.PhoneNumberAdministrationClient client, string reservationId) { throw null; }
        public static Azure.Communication.PhoneNumbers.Models.PhoneNumberReservationPurchaseOperation PhoneNumberReservationPurchaseOperation(Azure.Communication.PhoneNumbers.PhoneNumberAdministrationClient client, string reservationId) { throw null; }
        public static Azure.Communication.PhoneNumbers.Models.PhonePlan PhonePlan(string phonePlanId, string localizedName, Azure.Communication.PhoneNumbers.Models.LocationType locationType) { throw null; }
        public static Azure.Communication.PhoneNumbers.Models.PhonePlanGroup PhonePlanGroup(string phonePlanGroupId, string localizedName, string localizedDescription) { throw null; }
        public static Azure.Communication.PhoneNumbers.Models.RateInformation RateInformation(double? monthlyRate, Azure.Communication.PhoneNumbers.Models.CurrencyType? currencyType, string rateErrorMessage) { throw null; }
        public static Azure.Communication.PhoneNumbers.Models.ReleasePhoneNumberOperation ReleasePhoneNumberOperation(Azure.Communication.PhoneNumbers.PhoneNumberAdministrationClient client, string releaseId) { throw null; }
        public static Azure.Communication.PhoneNumbers.Models.UpdateNumberCapabilitiesResponse UpdateNumberCapabilitiesResponse(string capabilitiesUpdateId) { throw null; }
        public static Azure.Communication.PhoneNumbers.Models.UpdatePhoneNumberCapabilitiesResponse UpdatePhoneNumberCapabilitiesResponse(string capabilitiesUpdateId, System.DateTimeOffset? createdAt, Azure.Communication.PhoneNumbers.Models.CapabilitiesUpdateStatus? capabilitiesUpdateStatus, System.Collections.Generic.IReadOnlyDictionary<string, Azure.Communication.PhoneNumbers.Models.NumberUpdateCapabilities> phoneNumberCapabilitiesUpdates) { throw null; }
    }
    public partial class AreaCodes
    {
        internal AreaCodes() { }
        public string NextLink { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> PrimaryAreaCodes { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> SecondaryAreaCodes { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AssignmentStatus : System.IEquatable<Azure.Communication.PhoneNumbers.Models.AssignmentStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AssignmentStatus(string value) { throw null; }
        public static Azure.Communication.PhoneNumbers.Models.AssignmentStatus ConferenceAssigned { get { throw null; } }
        public static Azure.Communication.PhoneNumbers.Models.AssignmentStatus FirstPartyAppAssigned { get { throw null; } }
        public static Azure.Communication.PhoneNumbers.Models.AssignmentStatus ThirdPartyAppAssigned { get { throw null; } }
        public static Azure.Communication.PhoneNumbers.Models.AssignmentStatus Unassigned { get { throw null; } }
        public static Azure.Communication.PhoneNumbers.Models.AssignmentStatus Unknown { get { throw null; } }
        public static Azure.Communication.PhoneNumbers.Models.AssignmentStatus UserAssigned { get { throw null; } }
        public bool Equals(Azure.Communication.PhoneNumbers.Models.AssignmentStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Communication.PhoneNumbers.Models.AssignmentStatus left, Azure.Communication.PhoneNumbers.Models.AssignmentStatus right) { throw null; }
        public static implicit operator Azure.Communication.PhoneNumbers.Models.AssignmentStatus (string value) { throw null; }
        public static bool operator !=(Azure.Communication.PhoneNumbers.Models.AssignmentStatus left, Azure.Communication.PhoneNumbers.Models.AssignmentStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct CapabilitiesUpdateStatus : System.IEquatable<Azure.Communication.PhoneNumbers.Models.CapabilitiesUpdateStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public CapabilitiesUpdateStatus(string value) { throw null; }
        public static Azure.Communication.PhoneNumbers.Models.CapabilitiesUpdateStatus Complete { get { throw null; } }
        public static Azure.Communication.PhoneNumbers.Models.CapabilitiesUpdateStatus Error { get { throw null; } }
        public static Azure.Communication.PhoneNumbers.Models.CapabilitiesUpdateStatus InProgress { get { throw null; } }
        public static Azure.Communication.PhoneNumbers.Models.CapabilitiesUpdateStatus Pending { get { throw null; } }
        public bool Equals(Azure.Communication.PhoneNumbers.Models.CapabilitiesUpdateStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Communication.PhoneNumbers.Models.CapabilitiesUpdateStatus left, Azure.Communication.PhoneNumbers.Models.CapabilitiesUpdateStatus right) { throw null; }
        public static implicit operator Azure.Communication.PhoneNumbers.Models.CapabilitiesUpdateStatus (string value) { throw null; }
        public static bool operator !=(Azure.Communication.PhoneNumbers.Models.CapabilitiesUpdateStatus left, Azure.Communication.PhoneNumbers.Models.CapabilitiesUpdateStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class CarrierDetails
    {
        internal CarrierDetails() { }
        public string LocalizedName { get { throw null; } }
        public string Name { get { throw null; } }
    }
    public partial class CreateReservationOptions
    {
        public CreateReservationOptions(string displayName, string description, System.Collections.Generic.IEnumerable<string> phonePlanIds, string areaCode) { }
        public string AreaCode { get { throw null; } }
        public string Description { get { throw null; } }
        public string DisplayName { get { throw null; } }
        public System.Collections.Generic.IList<Azure.Communication.PhoneNumbers.Models.LocationOptionsDetails> LocationOptions { get { throw null; } }
        public System.Collections.Generic.IList<string> PhonePlanIds { get { throw null; } }
        public int? Quantity { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct CurrencyType : System.IEquatable<Azure.Communication.PhoneNumbers.Models.CurrencyType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public CurrencyType(string value) { throw null; }
        public static Azure.Communication.PhoneNumbers.Models.CurrencyType USD { get { throw null; } }
        public bool Equals(Azure.Communication.PhoneNumbers.Models.CurrencyType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Communication.PhoneNumbers.Models.CurrencyType left, Azure.Communication.PhoneNumbers.Models.CurrencyType right) { throw null; }
        public static implicit operator Azure.Communication.PhoneNumbers.Models.CurrencyType (string value) { throw null; }
        public static bool operator !=(Azure.Communication.PhoneNumbers.Models.CurrencyType left, Azure.Communication.PhoneNumbers.Models.CurrencyType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class LocationOptions
    {
        public LocationOptions() { }
        public string LabelId { get { throw null; } set { } }
        public string LabelName { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.Communication.PhoneNumbers.Models.LocationOptionsDetails> Options { get { throw null; } }
    }
    public partial class LocationOptionsDetails
    {
        public LocationOptionsDetails() { }
        public System.Collections.Generic.IList<Azure.Communication.PhoneNumbers.Models.LocationOptions> LocationOptions { get { throw null; } }
        public string Name { get { throw null; } set { } }
        public string Value { get { throw null; } set { } }
    }
    public partial class LocationOptionsQuery
    {
        public LocationOptionsQuery() { }
        public string LabelId { get { throw null; } set { } }
        public string OptionsValue { get { throw null; } set { } }
    }
    public partial class LocationOptionsResponse
    {
        internal LocationOptionsResponse() { }
        public Azure.Communication.PhoneNumbers.Models.LocationOptions LocationOptions { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct LocationType : System.IEquatable<Azure.Communication.PhoneNumbers.Models.LocationType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public LocationType(string value) { throw null; }
        public static Azure.Communication.PhoneNumbers.Models.LocationType CivicAddress { get { throw null; } }
        public static Azure.Communication.PhoneNumbers.Models.LocationType NotRequired { get { throw null; } }
        public static Azure.Communication.PhoneNumbers.Models.LocationType Selection { get { throw null; } }
        public bool Equals(Azure.Communication.PhoneNumbers.Models.LocationType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Communication.PhoneNumbers.Models.LocationType left, Azure.Communication.PhoneNumbers.Models.LocationType right) { throw null; }
        public static implicit operator Azure.Communication.PhoneNumbers.Models.LocationType (string value) { throw null; }
        public static bool operator !=(Azure.Communication.PhoneNumbers.Models.LocationType left, Azure.Communication.PhoneNumbers.Models.LocationType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class NumberConfigurationResponse
    {
        internal NumberConfigurationResponse() { }
        public Azure.Communication.PhoneNumbers.Models.PstnConfiguration PstnConfiguration { get { throw null; } }
    }
    public partial class NumberUpdateCapabilities
    {
        public NumberUpdateCapabilities() { }
        public System.Collections.Generic.IList<Azure.Communication.PhoneNumbers.Models.PhoneNumberCapability> Add { get { throw null; } }
        public System.Collections.Generic.IList<Azure.Communication.PhoneNumbers.Models.PhoneNumberCapability> Remove { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PhoneNumberCapability : System.IEquatable<Azure.Communication.PhoneNumbers.Models.PhoneNumberCapability>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PhoneNumberCapability(string value) { throw null; }
        public static Azure.Communication.PhoneNumbers.Models.PhoneNumberCapability A2PSmsCapable { get { throw null; } }
        public static Azure.Communication.PhoneNumbers.Models.PhoneNumberCapability A2PSmsEnabled { get { throw null; } }
        public static Azure.Communication.PhoneNumbers.Models.PhoneNumberCapability Azure { get { throw null; } }
        public static Azure.Communication.PhoneNumbers.Models.PhoneNumberCapability Calling { get { throw null; } }
        public static Azure.Communication.PhoneNumbers.Models.PhoneNumberCapability ConferenceAssignment { get { throw null; } }
        public static Azure.Communication.PhoneNumbers.Models.PhoneNumberCapability FirstPartyAppAssignment { get { throw null; } }
        public static Azure.Communication.PhoneNumbers.Models.PhoneNumberCapability FirstPartyVoiceAppAssignment { get { throw null; } }
        public static Azure.Communication.PhoneNumbers.Models.PhoneNumberCapability Geographic { get { throw null; } }
        public static Azure.Communication.PhoneNumbers.Models.PhoneNumberCapability InboundA2PSms { get { throw null; } }
        public static Azure.Communication.PhoneNumbers.Models.PhoneNumberCapability InboundCalling { get { throw null; } }
        public static Azure.Communication.PhoneNumbers.Models.PhoneNumberCapability InboundP2PSms { get { throw null; } }
        public static Azure.Communication.PhoneNumbers.Models.PhoneNumberCapability NonGeographic { get { throw null; } }
        public static Azure.Communication.PhoneNumbers.Models.PhoneNumberCapability Office365 { get { throw null; } }
        public static Azure.Communication.PhoneNumbers.Models.PhoneNumberCapability OutboundA2PSms { get { throw null; } }
        public static Azure.Communication.PhoneNumbers.Models.PhoneNumberCapability OutboundCalling { get { throw null; } }
        public static Azure.Communication.PhoneNumbers.Models.PhoneNumberCapability OutboundP2PSms { get { throw null; } }
        public static Azure.Communication.PhoneNumbers.Models.PhoneNumberCapability P2PSmsCapable { get { throw null; } }
        public static Azure.Communication.PhoneNumbers.Models.PhoneNumberCapability P2PSmsEnabled { get { throw null; } }
        public static Azure.Communication.PhoneNumbers.Models.PhoneNumberCapability Premium { get { throw null; } }
        public static Azure.Communication.PhoneNumbers.Models.PhoneNumberCapability ThirdPartyAppAssignment { get { throw null; } }
        public static Azure.Communication.PhoneNumbers.Models.PhoneNumberCapability TollCalling { get { throw null; } }
        public static Azure.Communication.PhoneNumbers.Models.PhoneNumberCapability TollFree { get { throw null; } }
        public static Azure.Communication.PhoneNumbers.Models.PhoneNumberCapability TollFreeCalling { get { throw null; } }
        public static Azure.Communication.PhoneNumbers.Models.PhoneNumberCapability UserAssignment { get { throw null; } }
        public bool Equals(Azure.Communication.PhoneNumbers.Models.PhoneNumberCapability other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Communication.PhoneNumbers.Models.PhoneNumberCapability left, Azure.Communication.PhoneNumbers.Models.PhoneNumberCapability right) { throw null; }
        public static implicit operator Azure.Communication.PhoneNumbers.Models.PhoneNumberCapability (string value) { throw null; }
        public static bool operator !=(Azure.Communication.PhoneNumbers.Models.PhoneNumberCapability left, Azure.Communication.PhoneNumbers.Models.PhoneNumberCapability right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class PhoneNumberCountry
    {
        internal PhoneNumberCountry() { }
        public string CountryCode { get { throw null; } }
        public string LocalizedName { get { throw null; } }
    }
    public partial class PhoneNumberEntity
    {
        internal PhoneNumberEntity() { }
        public System.DateTimeOffset? CreatedAt { get { throw null; } }
        public string DisplayName { get { throw null; } }
        public System.DateTimeOffset? FocDate { get { throw null; } }
        public string Id { get { throw null; } }
        public int? Quantity { get { throw null; } }
        public int? QuantityObtained { get { throw null; } }
        public string Status { get { throw null; } }
    }
    public partial class PhoneNumberRelease
    {
        internal PhoneNumberRelease() { }
        public System.DateTimeOffset? CreatedAt { get { throw null; } }
        public string ErrorMessage { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, Azure.Communication.PhoneNumbers.Models.PhoneNumberReleaseDetails> PhoneNumberReleaseStatusDetails { get { throw null; } }
        public string ReleaseId { get { throw null; } }
        public Azure.Communication.PhoneNumbers.Models.ReleaseStatus? Status { get { throw null; } }
    }
    public partial class PhoneNumberReleaseDetails
    {
        internal PhoneNumberReleaseDetails() { }
        public int? ErrorCode { get { throw null; } }
        public Azure.Communication.PhoneNumbers.Models.PhoneNumberReleaseStatus? Status { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PhoneNumberReleaseStatus : System.IEquatable<Azure.Communication.PhoneNumbers.Models.PhoneNumberReleaseStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PhoneNumberReleaseStatus(string value) { throw null; }
        public static Azure.Communication.PhoneNumbers.Models.PhoneNumberReleaseStatus Error { get { throw null; } }
        public static Azure.Communication.PhoneNumbers.Models.PhoneNumberReleaseStatus InProgress { get { throw null; } }
        public static Azure.Communication.PhoneNumbers.Models.PhoneNumberReleaseStatus Pending { get { throw null; } }
        public static Azure.Communication.PhoneNumbers.Models.PhoneNumberReleaseStatus Success { get { throw null; } }
        public bool Equals(Azure.Communication.PhoneNumbers.Models.PhoneNumberReleaseStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Communication.PhoneNumbers.Models.PhoneNumberReleaseStatus left, Azure.Communication.PhoneNumbers.Models.PhoneNumberReleaseStatus right) { throw null; }
        public static implicit operator Azure.Communication.PhoneNumbers.Models.PhoneNumberReleaseStatus (string value) { throw null; }
        public static bool operator !=(Azure.Communication.PhoneNumbers.Models.PhoneNumberReleaseStatus left, Azure.Communication.PhoneNumbers.Models.PhoneNumberReleaseStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class PhoneNumberReservation
    {
        internal PhoneNumberReservation() { }
        public string AreaCode { get { throw null; } }
        public System.DateTimeOffset? CreatedAt { get { throw null; } }
        public string Description { get { throw null; } }
        public string DisplayName { get { throw null; } }
        public int? ErrorCode { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Communication.PhoneNumbers.Models.LocationOptionsDetails> LocationOptions { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> PhoneNumbers { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> PhonePlanIds { get { throw null; } }
        public int? Quantity { get { throw null; } }
        public System.DateTimeOffset? ReservationExpiryDate { get { throw null; } }
        public string ReservationId { get { throw null; } }
        public Azure.Communication.PhoneNumbers.Models.ReservationStatus? Status { get { throw null; } }
    }
    public partial class PhoneNumberReservationOperation : Azure.Operation<Azure.Communication.PhoneNumbers.Models.PhoneNumberReservation>
    {
        public PhoneNumberReservationOperation(Azure.Communication.PhoneNumbers.PhoneNumberAdministrationClient client, string id, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.Communication.PhoneNumbers.Models.PhoneNumberReservation Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.Communication.PhoneNumbers.Models.PhoneNumberReservation>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.Communication.PhoneNumbers.Models.PhoneNumberReservation>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken) { throw null; }
    }
    public partial class PhoneNumberReservationPurchaseOperation : Azure.Operation<Azure.Communication.PhoneNumbers.Models.ReservationStatus>
    {
        public PhoneNumberReservationPurchaseOperation(Azure.Communication.PhoneNumbers.PhoneNumberAdministrationClient client, string id, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.Communication.PhoneNumbers.Models.ReservationStatus Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.Communication.PhoneNumbers.Models.ReservationStatus>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.Communication.PhoneNumbers.Models.ReservationStatus>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PhoneNumberType : System.IEquatable<Azure.Communication.PhoneNumbers.Models.PhoneNumberType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PhoneNumberType(string value) { throw null; }
        public static Azure.Communication.PhoneNumbers.Models.PhoneNumberType Geographic { get { throw null; } }
        public static Azure.Communication.PhoneNumbers.Models.PhoneNumberType Indirect { get { throw null; } }
        public static Azure.Communication.PhoneNumbers.Models.PhoneNumberType TollFree { get { throw null; } }
        public static Azure.Communication.PhoneNumbers.Models.PhoneNumberType Unknown { get { throw null; } }
        public bool Equals(Azure.Communication.PhoneNumbers.Models.PhoneNumberType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Communication.PhoneNumbers.Models.PhoneNumberType left, Azure.Communication.PhoneNumbers.Models.PhoneNumberType right) { throw null; }
        public static implicit operator Azure.Communication.PhoneNumbers.Models.PhoneNumberType (string value) { throw null; }
        public static bool operator !=(Azure.Communication.PhoneNumbers.Models.PhoneNumberType left, Azure.Communication.PhoneNumbers.Models.PhoneNumberType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class PhonePlan
    {
        internal PhonePlan() { }
        public System.Collections.Generic.IReadOnlyList<string> AreaCodes { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Communication.PhoneNumbers.Models.PhoneNumberCapability> Capabilities { get { throw null; } }
        public string LocalizedName { get { throw null; } }
        public Azure.Communication.PhoneNumbers.Models.LocationType LocationType { get { throw null; } }
        public int? MaximumSearchSize { get { throw null; } }
        public string PhonePlanId { get { throw null; } }
    }
    public partial class PhonePlanGroup
    {
        internal PhonePlanGroup() { }
        public Azure.Communication.PhoneNumbers.Models.CarrierDetails CarrierDetails { get { throw null; } }
        public string LocalizedDescription { get { throw null; } }
        public string LocalizedName { get { throw null; } }
        public Azure.Communication.PhoneNumbers.Models.PhoneNumberType? PhoneNumberType { get { throw null; } }
        public string PhonePlanGroupId { get { throw null; } }
        public Azure.Communication.PhoneNumbers.Models.RateInformation RateInformation { get { throw null; } }
    }
    public partial class PstnConfiguration
    {
        public PstnConfiguration(string callbackUrl) { }
        public string ApplicationId { get { throw null; } set { } }
        public string CallbackUrl { get { throw null; } set { } }
    }
    public partial class RateInformation
    {
        internal RateInformation() { }
        public Azure.Communication.PhoneNumbers.Models.CurrencyType? CurrencyType { get { throw null; } }
        public double? MonthlyRate { get { throw null; } }
        public string RateErrorMessage { get { throw null; } }
    }
    public partial class ReleasePhoneNumberOperation : Azure.Operation<Azure.Communication.PhoneNumbers.Models.PhoneNumberRelease>
    {
        public ReleasePhoneNumberOperation(Azure.Communication.PhoneNumbers.PhoneNumberAdministrationClient client, string id, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.Communication.PhoneNumbers.Models.PhoneNumberRelease Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.Communication.PhoneNumbers.Models.PhoneNumberRelease>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.Communication.PhoneNumbers.Models.PhoneNumberRelease>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ReleaseStatus : System.IEquatable<Azure.Communication.PhoneNumbers.Models.ReleaseStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ReleaseStatus(string value) { throw null; }
        public static Azure.Communication.PhoneNumbers.Models.ReleaseStatus Complete { get { throw null; } }
        public static Azure.Communication.PhoneNumbers.Models.ReleaseStatus Expired { get { throw null; } }
        public static Azure.Communication.PhoneNumbers.Models.ReleaseStatus Failed { get { throw null; } }
        public static Azure.Communication.PhoneNumbers.Models.ReleaseStatus InProgress { get { throw null; } }
        public static Azure.Communication.PhoneNumbers.Models.ReleaseStatus Pending { get { throw null; } }
        public bool Equals(Azure.Communication.PhoneNumbers.Models.ReleaseStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Communication.PhoneNumbers.Models.ReleaseStatus left, Azure.Communication.PhoneNumbers.Models.ReleaseStatus right) { throw null; }
        public static implicit operator Azure.Communication.PhoneNumbers.Models.ReleaseStatus (string value) { throw null; }
        public static bool operator !=(Azure.Communication.PhoneNumbers.Models.ReleaseStatus left, Azure.Communication.PhoneNumbers.Models.ReleaseStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ReservationStatus : System.IEquatable<Azure.Communication.PhoneNumbers.Models.ReservationStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ReservationStatus(string value) { throw null; }
        public static Azure.Communication.PhoneNumbers.Models.ReservationStatus Cancelled { get { throw null; } }
        public static Azure.Communication.PhoneNumbers.Models.ReservationStatus Cancelling { get { throw null; } }
        public static Azure.Communication.PhoneNumbers.Models.ReservationStatus Completing { get { throw null; } }
        public static Azure.Communication.PhoneNumbers.Models.ReservationStatus Error { get { throw null; } }
        public static Azure.Communication.PhoneNumbers.Models.ReservationStatus Expired { get { throw null; } }
        public static Azure.Communication.PhoneNumbers.Models.ReservationStatus Expiring { get { throw null; } }
        public static Azure.Communication.PhoneNumbers.Models.ReservationStatus InProgress { get { throw null; } }
        public static Azure.Communication.PhoneNumbers.Models.ReservationStatus Manual { get { throw null; } }
        public static Azure.Communication.PhoneNumbers.Models.ReservationStatus Pending { get { throw null; } }
        public static Azure.Communication.PhoneNumbers.Models.ReservationStatus PurchasePending { get { throw null; } }
        public static Azure.Communication.PhoneNumbers.Models.ReservationStatus Refreshing { get { throw null; } }
        public static Azure.Communication.PhoneNumbers.Models.ReservationStatus Reserved { get { throw null; } }
        public static Azure.Communication.PhoneNumbers.Models.ReservationStatus Success { get { throw null; } }
        public bool Equals(Azure.Communication.PhoneNumbers.Models.ReservationStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Communication.PhoneNumbers.Models.ReservationStatus left, Azure.Communication.PhoneNumbers.Models.ReservationStatus right) { throw null; }
        public static implicit operator Azure.Communication.PhoneNumbers.Models.ReservationStatus (string value) { throw null; }
        public static bool operator !=(Azure.Communication.PhoneNumbers.Models.ReservationStatus left, Azure.Communication.PhoneNumbers.Models.ReservationStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class UpdateNumberCapabilitiesResponse
    {
        internal UpdateNumberCapabilitiesResponse() { }
        public string CapabilitiesUpdateId { get { throw null; } }
    }
    public partial class UpdatePhoneNumberCapabilitiesResponse
    {
        internal UpdatePhoneNumberCapabilitiesResponse() { }
        public string CapabilitiesUpdateId { get { throw null; } }
        public Azure.Communication.PhoneNumbers.Models.CapabilitiesUpdateStatus? CapabilitiesUpdateStatus { get { throw null; } }
        public System.DateTimeOffset? CreatedAt { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, Azure.Communication.PhoneNumbers.Models.NumberUpdateCapabilities> PhoneNumberCapabilitiesUpdates { get { throw null; } }
    }
}
