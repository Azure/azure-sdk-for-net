namespace Azure.Communication.Administration
{
    public partial class CommunicationIdentityClient
    {
        protected CommunicationIdentityClient() { }
        public CommunicationIdentityClient(string connectionString, Azure.Communication.Administration.CommunicationIdentityClientOptions? options = null) { }
        public virtual Azure.Response<Azure.Communication.CommunicationUser> CreateUser(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Communication.CommunicationUser>> CreateUserAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response DeleteUser(Azure.Communication.CommunicationUser communicationUser, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteUserAsync(Azure.Communication.CommunicationUser communicationUser, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Communication.Administration.Models.CommunicationUserToken> IssueToken(Azure.Communication.CommunicationUser communicationUser, System.Collections.Generic.IEnumerable<Azure.Communication.Administration.CommunicationTokenScope> scopes, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Communication.Administration.Models.CommunicationUserToken>> IssueTokenAsync(Azure.Communication.CommunicationUser communicationUser, System.Collections.Generic.IEnumerable<Azure.Communication.Administration.CommunicationTokenScope> scopes, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response RevokeTokens(Azure.Communication.CommunicationUser communicationUser, System.DateTimeOffset? issuedBefore = default(System.DateTimeOffset?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> RevokeTokensAsync(Azure.Communication.CommunicationUser communicationUser, System.DateTimeOffset? issuedBefore = default(System.DateTimeOffset?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class CommunicationIdentityClientOptions : Azure.Core.ClientOptions
    {
        public const Azure.Communication.Administration.CommunicationIdentityClientOptions.ServiceVersion LatestVersion = Azure.Communication.Administration.CommunicationIdentityClientOptions.ServiceVersion.V1;
        public CommunicationIdentityClientOptions(Azure.Communication.Administration.CommunicationIdentityClientOptions.ServiceVersion version = Azure.Communication.Administration.CommunicationIdentityClientOptions.ServiceVersion.V1, Azure.Core.RetryOptions? retryOptions = null, Azure.Core.Pipeline.HttpPipelineTransport? transport = null) { }
        public enum ServiceVersion
        {
            V1 = 1,
        }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct CommunicationTokenScope : System.IEquatable<Azure.Communication.Administration.CommunicationTokenScope>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public CommunicationTokenScope(string value) { throw null; }
        public static Azure.Communication.Administration.CommunicationTokenScope Chat { get { throw null; } }
        public static Azure.Communication.Administration.CommunicationTokenScope Pstn { get { throw null; } }
        public static Azure.Communication.Administration.CommunicationTokenScope VoIP { get { throw null; } }
        public bool Equals(Azure.Communication.Administration.CommunicationTokenScope other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Communication.Administration.CommunicationTokenScope left, Azure.Communication.Administration.CommunicationTokenScope right) { throw null; }
        public static implicit operator Azure.Communication.Administration.CommunicationTokenScope (string value) { throw null; }
        public static bool operator !=(Azure.Communication.Administration.CommunicationTokenScope left, Azure.Communication.Administration.CommunicationTokenScope right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class PhoneNumberAdministrationClient
    {
        protected PhoneNumberAdministrationClient() { }
        public PhoneNumberAdministrationClient(string connectionString) { }
        public PhoneNumberAdministrationClient(string connectionString, Azure.Communication.Administration.PhoneNumberAdministrationClientOptions? options = null) { }
        public virtual Azure.Response CancelSearch(string searchId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> CancelSearchAsync(string searchId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response ConfigureNumber(Azure.Communication.Administration.Models.PstnConfiguration pstnConfiguration, Azure.Communication.PhoneNumber phoneNumber, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> ConfigureNumberAsync(Azure.Communication.Administration.Models.PstnConfiguration pstnConfiguration, Azure.Communication.PhoneNumber phoneNumber, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Communication.Administration.Models.CreateSearchResponse> CreateSearch(Azure.Communication.Administration.Models.CreateSearchOptions body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Communication.Administration.Models.CreateSearchResponse>> CreateSearchAsync(Azure.Communication.Administration.Models.CreateSearchOptions body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Communication.Administration.Models.AreaCodes> GetAllAreaCodes(string locationType, string countryCode, string phonePlanId, System.Collections.Generic.IEnumerable<Azure.Communication.Administration.Models.LocationOptionsQuery> locationOptions, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Communication.Administration.Models.AreaCodes>> GetAllAreaCodesAsync(string locationType, string countryCode, string phonePlanId, System.Collections.Generic.IEnumerable<Azure.Communication.Administration.Models.LocationOptionsQuery> locationOptions, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.Communication.Administration.Models.AcquiredPhoneNumber> GetAllPhoneNumbers(string? locale = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.Communication.Administration.Models.AcquiredPhoneNumber> GetAllPhoneNumbersAsync(string? locale = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.Communication.Administration.Models.PhoneNumberEntity> GetAllReleases(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.Communication.Administration.Models.PhoneNumberEntity> GetAllReleasesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.Communication.Administration.Models.PhoneNumberEntity> GetAllSearches(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.Communication.Administration.Models.PhoneNumberEntity> GetAllSearchesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.Communication.Administration.Models.PhoneNumberCountry> GetAllSupportedCountries(string? locale = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.Communication.Administration.Models.PhoneNumberCountry> GetAllSupportedCountriesAsync(string? locale = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Communication.Administration.Models.UpdatePhoneNumberCapabilitiesResponse> GetCapabilitiesUpdate(string capabilitiesUpdateId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Communication.Administration.Models.UpdatePhoneNumberCapabilitiesResponse>> GetCapabilitiesUpdateAsync(string capabilitiesUpdateId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Communication.Administration.Models.NumberConfigurationResponse> GetNumberConfiguration(Azure.Communication.PhoneNumber phoneNumber, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Communication.Administration.Models.NumberConfigurationResponse>> GetNumberConfigurationAsync(Azure.Communication.PhoneNumber phoneNumber, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.Communication.Administration.Models.PhonePlanGroup> GetPhonePlanGroups(string countryCode, string? locale = null, bool? includeRateInformation = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.Communication.Administration.Models.PhonePlanGroup> GetPhonePlanGroupsAsync(string countryCode, string? locale = null, bool? includeRateInformation = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Communication.Administration.Models.LocationOptionsResponse> GetPhonePlanLocationOptions(string countryCode, string phonePlanGroupId, string phonePlanId, string? locale = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Communication.Administration.Models.LocationOptionsResponse>> GetPhonePlanLocationOptionsAsync(string countryCode, string phonePlanGroupId, string phonePlanId, string? locale = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.Communication.Administration.Models.PhonePlan> GetPhonePlans(string countryCode, string phonePlanGroupId, string? locale = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.Communication.Administration.Models.PhonePlan> GetPhonePlansAsync(string countryCode, string phonePlanGroupId, string? locale = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Communication.Administration.Models.PhoneNumberRelease> GetReleaseById(string releaseId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Communication.Administration.Models.PhoneNumberRelease>> GetReleaseByIdAsync(string releaseId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Communication.Administration.Models.PhoneNumberSearch> GetSearchById(string searchId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Communication.Administration.Models.PhoneNumberSearch>> GetSearchByIdAsync(string searchId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response PurchaseSearch(string searchId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> PurchaseSearchAsync(string searchId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Communication.Administration.Models.ReleaseResponse> ReleasePhoneNumbers(System.Collections.Generic.IEnumerable<Azure.Communication.PhoneNumber> phoneNumbers, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Communication.Administration.Models.ReleaseResponse>> ReleasePhoneNumbersAsync(System.Collections.Generic.IEnumerable<Azure.Communication.PhoneNumber> phoneNumbers, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response UnconfigureNumber(Azure.Communication.PhoneNumber phoneNumber, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> UnconfigureNumberAsync(Azure.Communication.PhoneNumber phoneNumber, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Communication.Administration.Models.UpdateNumberCapabilitiesResponse> UpdateCapabilities(System.Collections.Generic.IDictionary<string, Azure.Communication.Administration.Models.NumberUpdateCapabilities> phoneNumberUpdateCapabilities, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Communication.Administration.Models.UpdateNumberCapabilitiesResponse>> UpdateCapabilitiesAsync(System.Collections.Generic.IDictionary<string, Azure.Communication.Administration.Models.NumberUpdateCapabilities> phoneNumberUpdateCapabilities, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class PhoneNumberAdministrationClientOptions : Azure.Core.ClientOptions
    {
        public const Azure.Communication.Administration.PhoneNumberAdministrationClientOptions.ServiceVersion LatestVersion = Azure.Communication.Administration.PhoneNumberAdministrationClientOptions.ServiceVersion.V1;
        public PhoneNumberAdministrationClientOptions(Azure.Communication.Administration.PhoneNumberAdministrationClientOptions.ServiceVersion version = Azure.Communication.Administration.PhoneNumberAdministrationClientOptions.ServiceVersion.V1, Azure.Core.RetryOptions? retryOptions = null, Azure.Core.Pipeline.HttpPipelineTransport? transport = null) { }
        public enum ServiceVersion
        {
            V1 = 1,
        }
    }
}
namespace Azure.Communication.Administration.Models
{
    public partial class AcquiredPhoneNumber
    {
        internal AcquiredPhoneNumber() { }
        public System.Collections.Generic.IReadOnlyList<Azure.Communication.Administration.Models.PhoneNumberCapability> AcquiredCapabilities { get { throw null; } }
        public Azure.Communication.Administration.Models.ActivationState? ActivationState { get { throw null; } }
        public Azure.Communication.Administration.Models.AssignmentStatus? AssignmentStatus { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Communication.Administration.Models.PhoneNumberCapability> AvailableCapabilities { get { throw null; } }
        public string PhoneNumber { get { throw null; } }
        public string PlaceName { get { throw null; } }
    }
    public partial class AcquiredPhoneNumbers
    {
        internal AcquiredPhoneNumbers() { }
        public string NextLink { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Communication.Administration.Models.AcquiredPhoneNumber> PhoneNumbers { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ActivationState : System.IEquatable<Azure.Communication.Administration.Models.ActivationState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ActivationState(string value) { throw null; }
        public static Azure.Communication.Administration.Models.ActivationState Activated { get { throw null; } }
        public static Azure.Communication.Administration.Models.ActivationState AssignmentFailed { get { throw null; } }
        public static Azure.Communication.Administration.Models.ActivationState AssignmentPending { get { throw null; } }
        public static Azure.Communication.Administration.Models.ActivationState UpdateFailed { get { throw null; } }
        public static Azure.Communication.Administration.Models.ActivationState UpdatePending { get { throw null; } }
        public bool Equals(Azure.Communication.Administration.Models.ActivationState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Communication.Administration.Models.ActivationState left, Azure.Communication.Administration.Models.ActivationState right) { throw null; }
        public static implicit operator Azure.Communication.Administration.Models.ActivationState (string value) { throw null; }
        public static bool operator !=(Azure.Communication.Administration.Models.ActivationState left, Azure.Communication.Administration.Models.ActivationState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class AreaCodes
    {
        internal AreaCodes() { }
        public string NextLink { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> PrimaryAreaCodes { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> SecondaryAreaCodes { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AssignmentStatus : System.IEquatable<Azure.Communication.Administration.Models.AssignmentStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AssignmentStatus(string value) { throw null; }
        public static Azure.Communication.Administration.Models.AssignmentStatus ConferenceAssigned { get { throw null; } }
        public static Azure.Communication.Administration.Models.AssignmentStatus FirstPartyAppAssigned { get { throw null; } }
        public static Azure.Communication.Administration.Models.AssignmentStatus ThirdPartyAppAssigned { get { throw null; } }
        public static Azure.Communication.Administration.Models.AssignmentStatus Unassigned { get { throw null; } }
        public static Azure.Communication.Administration.Models.AssignmentStatus Unknown { get { throw null; } }
        public static Azure.Communication.Administration.Models.AssignmentStatus UserAssigned { get { throw null; } }
        public bool Equals(Azure.Communication.Administration.Models.AssignmentStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Communication.Administration.Models.AssignmentStatus left, Azure.Communication.Administration.Models.AssignmentStatus right) { throw null; }
        public static implicit operator Azure.Communication.Administration.Models.AssignmentStatus (string value) { throw null; }
        public static bool operator !=(Azure.Communication.Administration.Models.AssignmentStatus left, Azure.Communication.Administration.Models.AssignmentStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct CapabilitiesUpdateStatus : System.IEquatable<Azure.Communication.Administration.Models.CapabilitiesUpdateStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public CapabilitiesUpdateStatus(string value) { throw null; }
        public static Azure.Communication.Administration.Models.CapabilitiesUpdateStatus Complete { get { throw null; } }
        public static Azure.Communication.Administration.Models.CapabilitiesUpdateStatus Error { get { throw null; } }
        public static Azure.Communication.Administration.Models.CapabilitiesUpdateStatus InProgress { get { throw null; } }
        public static Azure.Communication.Administration.Models.CapabilitiesUpdateStatus Pending { get { throw null; } }
        public bool Equals(Azure.Communication.Administration.Models.CapabilitiesUpdateStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Communication.Administration.Models.CapabilitiesUpdateStatus left, Azure.Communication.Administration.Models.CapabilitiesUpdateStatus right) { throw null; }
        public static implicit operator Azure.Communication.Administration.Models.CapabilitiesUpdateStatus (string value) { throw null; }
        public static bool operator !=(Azure.Communication.Administration.Models.CapabilitiesUpdateStatus left, Azure.Communication.Administration.Models.CapabilitiesUpdateStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class CarrierDetails
    {
        internal CarrierDetails() { }
        public string LocalizedName { get { throw null; } }
        public string Name { get { throw null; } }
    }
    public partial class CommunicationUserToken
    {
        internal CommunicationUserToken() { }
        public System.DateTimeOffset ExpiresOn { get { throw null; } }
        public string Token { get { throw null; } }
        public Azure.Communication.CommunicationUser User { get { throw null; } }
    }
    public partial class CreateSearchOptions
    {
        public CreateSearchOptions(string displayName, string description, System.Collections.Generic.IEnumerable<string> phonePlanIds, string areaCode) { }
        public string AreaCode { get { throw null; } }
        public string Description { get { throw null; } }
        public string DisplayName { get { throw null; } }
        public System.Collections.Generic.IList<Azure.Communication.Administration.Models.LocationOptionsDetails> LocationOptions { get { throw null; } }
        public System.Collections.Generic.IList<string> PhonePlanIds { get { throw null; } }
        public int? Quantity { get { throw null; } set { } }
    }
    public partial class CreateSearchResponse
    {
        internal CreateSearchResponse() { }
        public string SearchId { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct CurrencyType : System.IEquatable<Azure.Communication.Administration.Models.CurrencyType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public CurrencyType(string value) { throw null; }
        public static Azure.Communication.Administration.Models.CurrencyType USD { get { throw null; } }
        public bool Equals(Azure.Communication.Administration.Models.CurrencyType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Communication.Administration.Models.CurrencyType left, Azure.Communication.Administration.Models.CurrencyType right) { throw null; }
        public static implicit operator Azure.Communication.Administration.Models.CurrencyType (string value) { throw null; }
        public static bool operator !=(Azure.Communication.Administration.Models.CurrencyType left, Azure.Communication.Administration.Models.CurrencyType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class LocationOptions
    {
        public LocationOptions() { }
        public string LabelId { get { throw null; } set { } }
        public string LabelName { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.Communication.Administration.Models.LocationOptionsDetails> Options { get { throw null; } }
    }
    public partial class LocationOptionsDetails
    {
        public LocationOptionsDetails() { }
        public System.Collections.Generic.IList<Azure.Communication.Administration.Models.LocationOptions> LocationOptions { get { throw null; } }
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
        public Azure.Communication.Administration.Models.LocationOptions LocationOptions { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct LocationType : System.IEquatable<Azure.Communication.Administration.Models.LocationType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public LocationType(string value) { throw null; }
        public static Azure.Communication.Administration.Models.LocationType CivicAddress { get { throw null; } }
        public static Azure.Communication.Administration.Models.LocationType NotRequired { get { throw null; } }
        public static Azure.Communication.Administration.Models.LocationType Selection { get { throw null; } }
        public bool Equals(Azure.Communication.Administration.Models.LocationType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Communication.Administration.Models.LocationType left, Azure.Communication.Administration.Models.LocationType right) { throw null; }
        public static implicit operator Azure.Communication.Administration.Models.LocationType (string value) { throw null; }
        public static bool operator !=(Azure.Communication.Administration.Models.LocationType left, Azure.Communication.Administration.Models.LocationType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class NumberConfigurationResponse
    {
        internal NumberConfigurationResponse() { }
        public Azure.Communication.Administration.Models.PstnConfiguration PstnConfiguration { get { throw null; } }
    }
    public partial class NumberUpdateCapabilities
    {
        public NumberUpdateCapabilities() { }
        public System.Collections.Generic.IList<Azure.Communication.Administration.Models.PhoneNumberCapability> Add { get { throw null; } }
        public System.Collections.Generic.IList<Azure.Communication.Administration.Models.PhoneNumberCapability> Remove { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PhoneNumberCapability : System.IEquatable<Azure.Communication.Administration.Models.PhoneNumberCapability>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PhoneNumberCapability(string value) { throw null; }
        public static Azure.Communication.Administration.Models.PhoneNumberCapability A2PSmsCapable { get { throw null; } }
        public static Azure.Communication.Administration.Models.PhoneNumberCapability A2PSmsEnabled { get { throw null; } }
        public static Azure.Communication.Administration.Models.PhoneNumberCapability Azure { get { throw null; } }
        public static Azure.Communication.Administration.Models.PhoneNumberCapability Calling { get { throw null; } }
        public static Azure.Communication.Administration.Models.PhoneNumberCapability ConferenceAssignment { get { throw null; } }
        public static Azure.Communication.Administration.Models.PhoneNumberCapability FirstPartyAppAssignment { get { throw null; } }
        public static Azure.Communication.Administration.Models.PhoneNumberCapability FirstPartyVoiceAppAssignment { get { throw null; } }
        public static Azure.Communication.Administration.Models.PhoneNumberCapability Geographic { get { throw null; } }
        public static Azure.Communication.Administration.Models.PhoneNumberCapability InboundA2PSms { get { throw null; } }
        public static Azure.Communication.Administration.Models.PhoneNumberCapability InboundCalling { get { throw null; } }
        public static Azure.Communication.Administration.Models.PhoneNumberCapability InboundP2PSms { get { throw null; } }
        public static Azure.Communication.Administration.Models.PhoneNumberCapability NonGeographic { get { throw null; } }
        public static Azure.Communication.Administration.Models.PhoneNumberCapability Office365 { get { throw null; } }
        public static Azure.Communication.Administration.Models.PhoneNumberCapability OutboundA2PSms { get { throw null; } }
        public static Azure.Communication.Administration.Models.PhoneNumberCapability OutboundCalling { get { throw null; } }
        public static Azure.Communication.Administration.Models.PhoneNumberCapability OutboundP2PSms { get { throw null; } }
        public static Azure.Communication.Administration.Models.PhoneNumberCapability P2PSmsCapable { get { throw null; } }
        public static Azure.Communication.Administration.Models.PhoneNumberCapability P2PSmsEnabled { get { throw null; } }
        public static Azure.Communication.Administration.Models.PhoneNumberCapability Premium { get { throw null; } }
        public static Azure.Communication.Administration.Models.PhoneNumberCapability ThirdPartyAppAssignment { get { throw null; } }
        public static Azure.Communication.Administration.Models.PhoneNumberCapability TollCalling { get { throw null; } }
        public static Azure.Communication.Administration.Models.PhoneNumberCapability TollFree { get { throw null; } }
        public static Azure.Communication.Administration.Models.PhoneNumberCapability TollFreeCalling { get { throw null; } }
        public static Azure.Communication.Administration.Models.PhoneNumberCapability UserAssignment { get { throw null; } }
        public bool Equals(Azure.Communication.Administration.Models.PhoneNumberCapability other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Communication.Administration.Models.PhoneNumberCapability left, Azure.Communication.Administration.Models.PhoneNumberCapability right) { throw null; }
        public static implicit operator Azure.Communication.Administration.Models.PhoneNumberCapability (string value) { throw null; }
        public static bool operator !=(Azure.Communication.Administration.Models.PhoneNumberCapability left, Azure.Communication.Administration.Models.PhoneNumberCapability right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class PhoneNumberCountries
    {
        internal PhoneNumberCountries() { }
        public System.Collections.Generic.IReadOnlyList<Azure.Communication.Administration.Models.PhoneNumberCountry> Countries { get { throw null; } }
        public string NextLink { get { throw null; } }
    }
    public partial class PhoneNumberCountry
    {
        internal PhoneNumberCountry() { }
        public string CountryCode { get { throw null; } }
        public string LocalizedName { get { throw null; } }
    }
    public partial class PhoneNumberEntities
    {
        internal PhoneNumberEntities() { }
        public System.Collections.Generic.IReadOnlyList<Azure.Communication.Administration.Models.PhoneNumberEntity> Entities { get { throw null; } }
        public string NextLink { get { throw null; } }
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
        public System.Collections.Generic.IReadOnlyDictionary<string, Azure.Communication.Administration.Models.PhoneNumberReleaseDetails> PhoneNumberReleaseStatusDetails { get { throw null; } }
        public string ReleaseId { get { throw null; } }
        public Azure.Communication.Administration.Models.ReleaseStatus? Status { get { throw null; } }
    }
    public partial class PhoneNumberReleaseDetails
    {
        internal PhoneNumberReleaseDetails() { }
        public int? ErrorCode { get { throw null; } }
        public Azure.Communication.Administration.Models.PhoneNumberReleaseStatus? Status { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PhoneNumberReleaseStatus : System.IEquatable<Azure.Communication.Administration.Models.PhoneNumberReleaseStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PhoneNumberReleaseStatus(string value) { throw null; }
        public static Azure.Communication.Administration.Models.PhoneNumberReleaseStatus Error { get { throw null; } }
        public static Azure.Communication.Administration.Models.PhoneNumberReleaseStatus InProgress { get { throw null; } }
        public static Azure.Communication.Administration.Models.PhoneNumberReleaseStatus Pending { get { throw null; } }
        public static Azure.Communication.Administration.Models.PhoneNumberReleaseStatus Success { get { throw null; } }
        public bool Equals(Azure.Communication.Administration.Models.PhoneNumberReleaseStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Communication.Administration.Models.PhoneNumberReleaseStatus left, Azure.Communication.Administration.Models.PhoneNumberReleaseStatus right) { throw null; }
        public static implicit operator Azure.Communication.Administration.Models.PhoneNumberReleaseStatus (string value) { throw null; }
        public static bool operator !=(Azure.Communication.Administration.Models.PhoneNumberReleaseStatus left, Azure.Communication.Administration.Models.PhoneNumberReleaseStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class PhoneNumberSearch
    {
        internal PhoneNumberSearch() { }
        public string AreaCode { get { throw null; } }
        public System.DateTimeOffset? CreatedAt { get { throw null; } }
        public string Description { get { throw null; } }
        public string DisplayName { get { throw null; } }
        public int? ErrorCode { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Communication.Administration.Models.LocationOptionsDetails> LocationOptions { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> PhoneNumbers { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> PhonePlanIds { get { throw null; } }
        public int? Quantity { get { throw null; } }
        public System.DateTimeOffset? ReservationExpiryDate { get { throw null; } }
        public string SearchId { get { throw null; } }
        public Azure.Communication.Administration.Models.SearchStatus? Status { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PhoneNumberType : System.IEquatable<Azure.Communication.Administration.Models.PhoneNumberType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PhoneNumberType(string value) { throw null; }
        public static Azure.Communication.Administration.Models.PhoneNumberType Geographic { get { throw null; } }
        public static Azure.Communication.Administration.Models.PhoneNumberType Indirect { get { throw null; } }
        public static Azure.Communication.Administration.Models.PhoneNumberType TollFree { get { throw null; } }
        public static Azure.Communication.Administration.Models.PhoneNumberType Unknown { get { throw null; } }
        public bool Equals(Azure.Communication.Administration.Models.PhoneNumberType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Communication.Administration.Models.PhoneNumberType left, Azure.Communication.Administration.Models.PhoneNumberType right) { throw null; }
        public static implicit operator Azure.Communication.Administration.Models.PhoneNumberType (string value) { throw null; }
        public static bool operator !=(Azure.Communication.Administration.Models.PhoneNumberType left, Azure.Communication.Administration.Models.PhoneNumberType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class PhonePlan
    {
        internal PhonePlan() { }
        public System.Collections.Generic.IReadOnlyList<string> AreaCodes { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Communication.Administration.Models.PhoneNumberCapability> Capabilities { get { throw null; } }
        public string LocalizedName { get { throw null; } }
        public Azure.Communication.Administration.Models.LocationType LocationType { get { throw null; } }
        public int? MaximumSearchSize { get { throw null; } }
        public string PhonePlanId { get { throw null; } }
    }
    public partial class PhonePlanGroup
    {
        internal PhonePlanGroup() { }
        public Azure.Communication.Administration.Models.CarrierDetails CarrierDetails { get { throw null; } }
        public string LocalizedDescription { get { throw null; } }
        public string LocalizedName { get { throw null; } }
        public Azure.Communication.Administration.Models.PhoneNumberType? PhoneNumberType { get { throw null; } }
        public string PhonePlanGroupId { get { throw null; } }
        public Azure.Communication.Administration.Models.RateInformation RateInformation { get { throw null; } }
    }
    public partial class PhonePlanGroups
    {
        internal PhonePlanGroups() { }
        public string NextLink { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Communication.Administration.Models.PhonePlanGroup> PhonePlanGroupsValue { get { throw null; } }
    }
    public partial class PhonePlansResponse
    {
        internal PhonePlansResponse() { }
        public string NextLink { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Communication.Administration.Models.PhonePlan> PhonePlans { get { throw null; } }
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
        public Azure.Communication.Administration.Models.CurrencyType? CurrencyType { get { throw null; } }
        public double? MonthlyRate { get { throw null; } }
        public string RateErrorMessage { get { throw null; } }
    }
    public partial class ReleaseResponse
    {
        internal ReleaseResponse() { }
        public string ReleaseId { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ReleaseStatus : System.IEquatable<Azure.Communication.Administration.Models.ReleaseStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ReleaseStatus(string value) { throw null; }
        public static Azure.Communication.Administration.Models.ReleaseStatus Complete { get { throw null; } }
        public static Azure.Communication.Administration.Models.ReleaseStatus Expired { get { throw null; } }
        public static Azure.Communication.Administration.Models.ReleaseStatus Failed { get { throw null; } }
        public static Azure.Communication.Administration.Models.ReleaseStatus InProgress { get { throw null; } }
        public static Azure.Communication.Administration.Models.ReleaseStatus Pending { get { throw null; } }
        public bool Equals(Azure.Communication.Administration.Models.ReleaseStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Communication.Administration.Models.ReleaseStatus left, Azure.Communication.Administration.Models.ReleaseStatus right) { throw null; }
        public static implicit operator Azure.Communication.Administration.Models.ReleaseStatus (string value) { throw null; }
        public static bool operator !=(Azure.Communication.Administration.Models.ReleaseStatus left, Azure.Communication.Administration.Models.ReleaseStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SearchStatus : System.IEquatable<Azure.Communication.Administration.Models.SearchStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SearchStatus(string value) { throw null; }
        public static Azure.Communication.Administration.Models.SearchStatus Cancelled { get { throw null; } }
        public static Azure.Communication.Administration.Models.SearchStatus Cancelling { get { throw null; } }
        public static Azure.Communication.Administration.Models.SearchStatus Completing { get { throw null; } }
        public static Azure.Communication.Administration.Models.SearchStatus Error { get { throw null; } }
        public static Azure.Communication.Administration.Models.SearchStatus Expired { get { throw null; } }
        public static Azure.Communication.Administration.Models.SearchStatus Expiring { get { throw null; } }
        public static Azure.Communication.Administration.Models.SearchStatus InProgress { get { throw null; } }
        public static Azure.Communication.Administration.Models.SearchStatus Manual { get { throw null; } }
        public static Azure.Communication.Administration.Models.SearchStatus Pending { get { throw null; } }
        public static Azure.Communication.Administration.Models.SearchStatus PurchasePending { get { throw null; } }
        public static Azure.Communication.Administration.Models.SearchStatus Refreshing { get { throw null; } }
        public static Azure.Communication.Administration.Models.SearchStatus Reserved { get { throw null; } }
        public static Azure.Communication.Administration.Models.SearchStatus Success { get { throw null; } }
        public bool Equals(Azure.Communication.Administration.Models.SearchStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Communication.Administration.Models.SearchStatus left, Azure.Communication.Administration.Models.SearchStatus right) { throw null; }
        public static implicit operator Azure.Communication.Administration.Models.SearchStatus (string value) { throw null; }
        public static bool operator !=(Azure.Communication.Administration.Models.SearchStatus left, Azure.Communication.Administration.Models.SearchStatus right) { throw null; }
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
        public Azure.Communication.Administration.Models.CapabilitiesUpdateStatus? CapabilitiesUpdateStatus { get { throw null; } }
        public System.DateTimeOffset? CreatedAt { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, Azure.Communication.Administration.Models.NumberUpdateCapabilities> PhoneNumberCapabilitiesUpdates { get { throw null; } }
    }
}
