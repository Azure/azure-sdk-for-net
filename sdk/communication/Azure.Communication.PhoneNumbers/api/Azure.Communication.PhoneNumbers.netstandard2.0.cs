namespace Azure.Communication.PhoneNumbers
{
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
    public partial class PhoneNumberAdministrativeDivision : System.ClientModel.Primitives.IJsonModel<Azure.Communication.PhoneNumbers.PhoneNumberAdministrativeDivision>, System.ClientModel.Primitives.IPersistableModel<Azure.Communication.PhoneNumbers.PhoneNumberAdministrativeDivision>
    {
        internal PhoneNumberAdministrativeDivision() { }
        public string AbbreviatedName { get { throw null; } }
        public string LocalizedName { get { throw null; } }
        Azure.Communication.PhoneNumbers.PhoneNumberAdministrativeDivision System.ClientModel.Primitives.IJsonModel<Azure.Communication.PhoneNumbers.PhoneNumberAdministrativeDivision>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Communication.PhoneNumbers.PhoneNumberAdministrativeDivision>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.ModelReaderWriterOptions options) { }
        Azure.Communication.PhoneNumbers.PhoneNumberAdministrativeDivision System.ClientModel.Primitives.IPersistableModel<Azure.Communication.PhoneNumbers.PhoneNumberAdministrativeDivision>.Create(System.BinaryData data, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Communication.PhoneNumbers.PhoneNumberAdministrativeDivision>.GetFormatFromOptions(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Communication.PhoneNumbers.PhoneNumberAdministrativeDivision>.Write(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PhoneNumberAreaCode : System.ClientModel.Primitives.IJsonModel<Azure.Communication.PhoneNumbers.PhoneNumberAreaCode>, System.ClientModel.Primitives.IPersistableModel<Azure.Communication.PhoneNumbers.PhoneNumberAreaCode>
    {
        internal PhoneNumberAreaCode() { }
        public string AreaCode { get { throw null; } }
        Azure.Communication.PhoneNumbers.PhoneNumberAreaCode System.ClientModel.Primitives.IJsonModel<Azure.Communication.PhoneNumbers.PhoneNumberAreaCode>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Communication.PhoneNumbers.PhoneNumberAreaCode>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.ModelReaderWriterOptions options) { }
        Azure.Communication.PhoneNumbers.PhoneNumberAreaCode System.ClientModel.Primitives.IPersistableModel<Azure.Communication.PhoneNumbers.PhoneNumberAreaCode>.Create(System.BinaryData data, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Communication.PhoneNumbers.PhoneNumberAreaCode>.GetFormatFromOptions(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Communication.PhoneNumbers.PhoneNumberAreaCode>.Write(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
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
    public partial class PhoneNumberCapabilities : System.ClientModel.Primitives.IJsonModel<Azure.Communication.PhoneNumbers.PhoneNumberCapabilities>, System.ClientModel.Primitives.IPersistableModel<Azure.Communication.PhoneNumbers.PhoneNumberCapabilities>
    {
        public PhoneNumberCapabilities(Azure.Communication.PhoneNumbers.PhoneNumberCapabilityType calling, Azure.Communication.PhoneNumbers.PhoneNumberCapabilityType sms) { }
        public Azure.Communication.PhoneNumbers.PhoneNumberCapabilityType Calling { get { throw null; } set { } }
        public Azure.Communication.PhoneNumbers.PhoneNumberCapabilityType Sms { get { throw null; } set { } }
        Azure.Communication.PhoneNumbers.PhoneNumberCapabilities System.ClientModel.Primitives.IJsonModel<Azure.Communication.PhoneNumbers.PhoneNumberCapabilities>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Communication.PhoneNumbers.PhoneNumberCapabilities>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.ModelReaderWriterOptions options) { }
        Azure.Communication.PhoneNumbers.PhoneNumberCapabilities System.ClientModel.Primitives.IPersistableModel<Azure.Communication.PhoneNumbers.PhoneNumberCapabilities>.Create(System.BinaryData data, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Communication.PhoneNumbers.PhoneNumberCapabilities>.GetFormatFromOptions(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Communication.PhoneNumbers.PhoneNumberCapabilities>.Write(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
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
    public partial class PhoneNumberCost : System.ClientModel.Primitives.IJsonModel<Azure.Communication.PhoneNumbers.PhoneNumberCost>, System.ClientModel.Primitives.IPersistableModel<Azure.Communication.PhoneNumbers.PhoneNumberCost>
    {
        internal PhoneNumberCost() { }
        public double Amount { get { throw null; } }
        public Azure.Communication.PhoneNumbers.BillingFrequency BillingFrequency { get { throw null; } }
        public string IsoCurrencySymbol { get { throw null; } }
        Azure.Communication.PhoneNumbers.PhoneNumberCost System.ClientModel.Primitives.IJsonModel<Azure.Communication.PhoneNumbers.PhoneNumberCost>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Communication.PhoneNumbers.PhoneNumberCost>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.ModelReaderWriterOptions options) { }
        Azure.Communication.PhoneNumbers.PhoneNumberCost System.ClientModel.Primitives.IPersistableModel<Azure.Communication.PhoneNumbers.PhoneNumberCost>.Create(System.BinaryData data, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Communication.PhoneNumbers.PhoneNumberCost>.GetFormatFromOptions(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Communication.PhoneNumbers.PhoneNumberCost>.Write(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PhoneNumberCountry : System.ClientModel.Primitives.IJsonModel<Azure.Communication.PhoneNumbers.PhoneNumberCountry>, System.ClientModel.Primitives.IPersistableModel<Azure.Communication.PhoneNumbers.PhoneNumberCountry>
    {
        internal PhoneNumberCountry() { }
        public string CountryCode { get { throw null; } }
        public string LocalizedName { get { throw null; } }
        Azure.Communication.PhoneNumbers.PhoneNumberCountry System.ClientModel.Primitives.IJsonModel<Azure.Communication.PhoneNumbers.PhoneNumberCountry>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Communication.PhoneNumbers.PhoneNumberCountry>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.ModelReaderWriterOptions options) { }
        Azure.Communication.PhoneNumbers.PhoneNumberCountry System.ClientModel.Primitives.IPersistableModel<Azure.Communication.PhoneNumbers.PhoneNumberCountry>.Create(System.BinaryData data, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Communication.PhoneNumbers.PhoneNumberCountry>.GetFormatFromOptions(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Communication.PhoneNumbers.PhoneNumberCountry>.Write(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PhoneNumberLocality : System.ClientModel.Primitives.IJsonModel<Azure.Communication.PhoneNumbers.PhoneNumberLocality>, System.ClientModel.Primitives.IPersistableModel<Azure.Communication.PhoneNumbers.PhoneNumberLocality>
    {
        internal PhoneNumberLocality() { }
        public Azure.Communication.PhoneNumbers.PhoneNumberAdministrativeDivision AdministrativeDivision { get { throw null; } }
        public string LocalizedName { get { throw null; } }
        Azure.Communication.PhoneNumbers.PhoneNumberLocality System.ClientModel.Primitives.IJsonModel<Azure.Communication.PhoneNumbers.PhoneNumberLocality>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Communication.PhoneNumbers.PhoneNumberLocality>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.ModelReaderWriterOptions options) { }
        Azure.Communication.PhoneNumbers.PhoneNumberLocality System.ClientModel.Primitives.IPersistableModel<Azure.Communication.PhoneNumbers.PhoneNumberLocality>.Create(System.BinaryData data, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Communication.PhoneNumbers.PhoneNumberLocality>.GetFormatFromOptions(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Communication.PhoneNumbers.PhoneNumberLocality>.Write(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PhoneNumberOffering : System.ClientModel.Primitives.IJsonModel<Azure.Communication.PhoneNumbers.PhoneNumberOffering>, System.ClientModel.Primitives.IPersistableModel<Azure.Communication.PhoneNumbers.PhoneNumberOffering>
    {
        internal PhoneNumberOffering() { }
        public Azure.Communication.PhoneNumbers.PhoneNumberAssignmentType? AssignmentType { get { throw null; } }
        public Azure.Communication.PhoneNumbers.PhoneNumberCapabilities AvailableCapabilities { get { throw null; } }
        public Azure.Communication.PhoneNumbers.PhoneNumberCost Cost { get { throw null; } }
        public Azure.Communication.PhoneNumbers.PhoneNumberType? PhoneNumberType { get { throw null; } }
        Azure.Communication.PhoneNumbers.PhoneNumberOffering System.ClientModel.Primitives.IJsonModel<Azure.Communication.PhoneNumbers.PhoneNumberOffering>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Communication.PhoneNumbers.PhoneNumberOffering>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.ModelReaderWriterOptions options) { }
        Azure.Communication.PhoneNumbers.PhoneNumberOffering System.ClientModel.Primitives.IPersistableModel<Azure.Communication.PhoneNumbers.PhoneNumberOffering>.Create(System.BinaryData data, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Communication.PhoneNumbers.PhoneNumberOffering>.GetFormatFromOptions(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Communication.PhoneNumbers.PhoneNumberOffering>.Write(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PhoneNumbersClient
    {
        protected PhoneNumbersClient() { }
        public PhoneNumbersClient(string connectionString) { }
        public PhoneNumbersClient(string connectionString, Azure.Communication.PhoneNumbers.PhoneNumbersClientOptions options) { }
        public PhoneNumbersClient(System.Uri endpoint, Azure.AzureKeyCredential keyCredential, Azure.Communication.PhoneNumbers.PhoneNumbersClientOptions options = null) { }
        public PhoneNumbersClient(System.Uri endpoint, Azure.Core.TokenCredential tokenCredential, Azure.Communication.PhoneNumbers.PhoneNumbersClientOptions options = null) { }
        public virtual Azure.Pageable<Azure.Communication.PhoneNumbers.PhoneNumberAreaCode> GetAvailableAreaCodesGeographic(string twoLetterIsoCountryName, Azure.Communication.PhoneNumbers.PhoneNumberAssignmentType phoneNumberAssignmentType, string locality, string administrativeDivision = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.Communication.PhoneNumbers.PhoneNumberAreaCode> GetAvailableAreaCodesGeographicAsync(string twoLetterIsoCountryName, Azure.Communication.PhoneNumbers.PhoneNumberAssignmentType phoneNumberAssignmentType, string locality, string administrativeDivision = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.Communication.PhoneNumbers.PhoneNumberAreaCode> GetAvailableAreaCodesTollFree(string twoLetterIsoCountryName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.Communication.PhoneNumbers.PhoneNumberAreaCode> GetAvailableAreaCodesTollFreeAsync(string twoLetterIsoCountryName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.Communication.PhoneNumbers.PhoneNumberCountry> GetAvailableCountries(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.Communication.PhoneNumbers.PhoneNumberCountry> GetAvailableCountriesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.Communication.PhoneNumbers.PhoneNumberLocality> GetAvailableLocalities(string twoLetterIsoCountryName, string administrativeDivision = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.Communication.PhoneNumbers.PhoneNumberLocality> GetAvailableLocalitiesAsync(string twoLetterIsoCountryName, string administrativeDivision = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.Communication.PhoneNumbers.PhoneNumberOffering> GetAvailableOfferings(string twoLetterIsoCountryName, Azure.Communication.PhoneNumbers.PhoneNumberType? phoneNumberType = default(Azure.Communication.PhoneNumbers.PhoneNumberType?), Azure.Communication.PhoneNumbers.PhoneNumberAssignmentType? phoneNumberAssignmentType = default(Azure.Communication.PhoneNumbers.PhoneNumberAssignmentType?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.Communication.PhoneNumbers.PhoneNumberOffering> GetAvailableOfferingsAsync(string twoLetterIsoCountryName, Azure.Communication.PhoneNumbers.PhoneNumberType? phoneNumberType = default(Azure.Communication.PhoneNumbers.PhoneNumberType?), Azure.Communication.PhoneNumbers.PhoneNumberAssignmentType? phoneNumberAssignmentType = default(Azure.Communication.PhoneNumbers.PhoneNumberAssignmentType?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Communication.PhoneNumbers.PhoneNumberSearchResult> GetPhoneNumberSearchResult(string searchId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Communication.PhoneNumbers.PhoneNumberSearchResult>> GetPhoneNumberSearchResultAsync(string searchId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Communication.PhoneNumbers.PurchasedPhoneNumber> GetPurchasedPhoneNumber(string phoneNumber, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Communication.PhoneNumbers.PurchasedPhoneNumber>> GetPurchasedPhoneNumberAsync(string phoneNumber, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.Communication.PhoneNumbers.PurchasedPhoneNumber> GetPurchasedPhoneNumbers(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.Communication.PhoneNumbers.PurchasedPhoneNumber> GetPurchasedPhoneNumbersAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Communication.PhoneNumbers.PurchasePhoneNumbersOperation StartPurchasePhoneNumbers(string searchId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Communication.PhoneNumbers.PurchasePhoneNumbersOperation> StartPurchasePhoneNumbersAsync(string searchId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Communication.PhoneNumbers.ReleasePhoneNumberOperation StartReleasePhoneNumber(string phoneNumber, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Communication.PhoneNumbers.ReleasePhoneNumberOperation> StartReleasePhoneNumberAsync(string phoneNumber, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Communication.PhoneNumbers.SearchAvailablePhoneNumbersOperation StartSearchAvailablePhoneNumbers(string twoLetterIsoCountryName, Azure.Communication.PhoneNumbers.PhoneNumberType phoneNumberType, Azure.Communication.PhoneNumbers.PhoneNumberAssignmentType phoneNumberAssignmentType, Azure.Communication.PhoneNumbers.PhoneNumberCapabilities capabilities, Azure.Communication.PhoneNumbers.PhoneNumberSearchOptions options = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Communication.PhoneNumbers.SearchAvailablePhoneNumbersOperation> StartSearchAvailablePhoneNumbersAsync(string twoLetterIsoCountryName, Azure.Communication.PhoneNumbers.PhoneNumberType phoneNumberType, Azure.Communication.PhoneNumbers.PhoneNumberAssignmentType phoneNumberAssignmentType, Azure.Communication.PhoneNumbers.PhoneNumberCapabilities capabilities, Azure.Communication.PhoneNumbers.PhoneNumberSearchOptions options = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Communication.PhoneNumbers.UpdatePhoneNumberCapabilitiesOperation StartUpdateCapabilities(string phoneNumber, Azure.Communication.PhoneNumbers.PhoneNumberCapabilityType? calling = default(Azure.Communication.PhoneNumbers.PhoneNumberCapabilityType?), Azure.Communication.PhoneNumbers.PhoneNumberCapabilityType? sms = default(Azure.Communication.PhoneNumbers.PhoneNumberCapabilityType?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Communication.PhoneNumbers.UpdatePhoneNumberCapabilitiesOperation> StartUpdateCapabilitiesAsync(string phoneNumber, Azure.Communication.PhoneNumbers.PhoneNumberCapabilityType? calling = default(Azure.Communication.PhoneNumbers.PhoneNumberCapabilityType?), Azure.Communication.PhoneNumbers.PhoneNumberCapabilityType? sms = default(Azure.Communication.PhoneNumbers.PhoneNumberCapabilityType?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class PhoneNumbersClientOptions : Azure.Core.ClientOptions
    {
        public PhoneNumbersClientOptions(Azure.Communication.PhoneNumbers.PhoneNumbersClientOptions.ServiceVersion version = Azure.Communication.PhoneNumbers.PhoneNumbersClientOptions.ServiceVersion.V2022_12_01) { }
        public string? AcceptedLanguage { get { throw null; } set { } }
        public enum ServiceVersion
        {
            V2021_03_07 = 1,
            V2022_01_11_Preview_2 = 2,
            V2022_12_01 = 3,
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
    public partial class PhoneNumberSearchResult : System.ClientModel.Primitives.IJsonModel<Azure.Communication.PhoneNumbers.PhoneNumberSearchResult>, System.ClientModel.Primitives.IPersistableModel<Azure.Communication.PhoneNumbers.PhoneNumberSearchResult>
    {
        internal PhoneNumberSearchResult() { }
        public Azure.Communication.PhoneNumbers.PhoneNumberAssignmentType AssignmentType { get { throw null; } }
        public Azure.Communication.PhoneNumbers.PhoneNumberCapabilities Capabilities { get { throw null; } }
        public Azure.Communication.PhoneNumbers.PhoneNumberCost Cost { get { throw null; } }
        public Azure.Communication.PhoneNumbers.PhoneNumberSearchResultError? Error { get { throw null; } }
        public int? ErrorCode { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> PhoneNumbers { get { throw null; } }
        public Azure.Communication.PhoneNumbers.PhoneNumberType PhoneNumberType { get { throw null; } }
        public System.DateTimeOffset SearchExpiresOn { get { throw null; } }
        public string SearchId { get { throw null; } }
        Azure.Communication.PhoneNumbers.PhoneNumberSearchResult System.ClientModel.Primitives.IJsonModel<Azure.Communication.PhoneNumbers.PhoneNumberSearchResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Communication.PhoneNumbers.PhoneNumberSearchResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.ModelReaderWriterOptions options) { }
        Azure.Communication.PhoneNumbers.PhoneNumberSearchResult System.ClientModel.Primitives.IPersistableModel<Azure.Communication.PhoneNumbers.PhoneNumberSearchResult>.Create(System.BinaryData data, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Communication.PhoneNumbers.PhoneNumberSearchResult>.GetFormatFromOptions(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Communication.PhoneNumbers.PhoneNumberSearchResult>.Write(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
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
        public static Azure.Communication.PhoneNumbers.PhoneNumberAdministrativeDivision PhoneNumberAdministrativeDivision(string localizedName = null, string abbreviatedName = null) { throw null; }
        public static Azure.Communication.PhoneNumbers.PhoneNumberAreaCode PhoneNumberAreaCode(string areaCode = null) { throw null; }
        public static Azure.Communication.PhoneNumbers.PhoneNumberCost PhoneNumberCost(double amount = 0, string isoCurrencySymbol = null, Azure.Communication.PhoneNumbers.BillingFrequency billingFrequency = default(Azure.Communication.PhoneNumbers.BillingFrequency)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.Communication.PhoneNumbers.PhoneNumberCost PhoneNumberCost(double amount, string currencyCode, string billingFrequency) { throw null; }
        public static Azure.Communication.PhoneNumbers.PhoneNumberCountry PhoneNumberCountry(string localizedName = null, string countryCode = null) { throw null; }
        public static Azure.Communication.PhoneNumbers.PhoneNumberLocality PhoneNumberLocality(string localizedName = null, Azure.Communication.PhoneNumbers.PhoneNumberAdministrativeDivision administrativeDivision = null) { throw null; }
        public static Azure.Communication.PhoneNumbers.PhoneNumberOffering PhoneNumberOffering(Azure.Communication.PhoneNumbers.PhoneNumberType? phoneNumberType = default(Azure.Communication.PhoneNumbers.PhoneNumberType?), Azure.Communication.PhoneNumbers.PhoneNumberAssignmentType? assignmentType = default(Azure.Communication.PhoneNumbers.PhoneNumberAssignmentType?), Azure.Communication.PhoneNumbers.PhoneNumberCapabilities availableCapabilities = null, Azure.Communication.PhoneNumbers.PhoneNumberCost cost = null) { throw null; }
        public static Azure.Communication.PhoneNumbers.PhoneNumberSearchResult PhoneNumberSearchResult(string searchId, System.Collections.Generic.IEnumerable<string> phoneNumbers, Azure.Communication.PhoneNumbers.PhoneNumberType phoneNumberType, Azure.Communication.PhoneNumbers.PhoneNumberAssignmentType assignmentType, Azure.Communication.PhoneNumbers.PhoneNumberCapabilities capabilities, Azure.Communication.PhoneNumbers.PhoneNumberCost cost, System.DateTimeOffset searchExpiresOn) { throw null; }
        public static Azure.Communication.PhoneNumbers.PhoneNumberSearchResult PhoneNumberSearchResult(string searchId = null, System.Collections.Generic.IEnumerable<string> phoneNumbers = null, Azure.Communication.PhoneNumbers.PhoneNumberType phoneNumberType = default(Azure.Communication.PhoneNumbers.PhoneNumberType), Azure.Communication.PhoneNumbers.PhoneNumberAssignmentType assignmentType = default(Azure.Communication.PhoneNumbers.PhoneNumberAssignmentType), Azure.Communication.PhoneNumbers.PhoneNumberCapabilities capabilities = null, Azure.Communication.PhoneNumbers.PhoneNumberCost cost = null, System.DateTimeOffset searchExpiresOn = default(System.DateTimeOffset), int? errorCode = default(int?), Azure.Communication.PhoneNumbers.PhoneNumberSearchResultError? error = default(Azure.Communication.PhoneNumbers.PhoneNumberSearchResultError?)) { throw null; }
        public static Azure.Communication.PhoneNumbers.PurchasedPhoneNumber PurchasedPhoneNumber(string id, string phoneNumber, string countryCode, Azure.Communication.PhoneNumbers.PhoneNumberType phoneNumberType, Azure.Communication.PhoneNumbers.PhoneNumberCapabilities capabilities, Azure.Communication.PhoneNumbers.PhoneNumberAssignmentType assignmentType, System.DateTimeOffset purchaseDate, Azure.Communication.PhoneNumbers.PhoneNumberCost cost) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PhoneNumberType : System.IEquatable<Azure.Communication.PhoneNumbers.PhoneNumberType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PhoneNumberType(string value) { throw null; }
        public static Azure.Communication.PhoneNumbers.PhoneNumberType Geographic { get { throw null; } }
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
    public partial class PurchasedPhoneNumber : System.ClientModel.Primitives.IJsonModel<Azure.Communication.PhoneNumbers.PurchasedPhoneNumber>, System.ClientModel.Primitives.IPersistableModel<Azure.Communication.PhoneNumbers.PurchasedPhoneNumber>
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
        Azure.Communication.PhoneNumbers.PurchasedPhoneNumber System.ClientModel.Primitives.IJsonModel<Azure.Communication.PhoneNumbers.PurchasedPhoneNumber>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Communication.PhoneNumbers.PurchasedPhoneNumber>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.ModelReaderWriterOptions options) { }
        Azure.Communication.PhoneNumbers.PurchasedPhoneNumber System.ClientModel.Primitives.IPersistableModel<Azure.Communication.PhoneNumbers.PurchasedPhoneNumber>.Create(System.BinaryData data, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Communication.PhoneNumbers.PurchasedPhoneNumber>.GetFormatFromOptions(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Communication.PhoneNumbers.PurchasedPhoneNumber>.Write(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
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
