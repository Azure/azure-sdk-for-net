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
    public partial class PhoneNumbersClient
    {
        protected PhoneNumbersClient() { }
        public PhoneNumbersClient(string connectionString) { }
        public PhoneNumbersClient(string connectionString, Azure.Communication.PhoneNumbers.PhoneNumbersClientOptions options) { }
        public PhoneNumbersClient(System.Uri endpoint, Azure.AzureKeyCredential keyCredential, Azure.Communication.PhoneNumbers.PhoneNumbersClientOptions options = null) { }
        public PhoneNumbersClient(System.Uri endpoint, Azure.Core.TokenCredential tokenCredential, Azure.Communication.PhoneNumbers.PhoneNumbersClientOptions options = null) { }
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
        public PhoneNumbersClientOptions(Azure.Communication.PhoneNumbers.PhoneNumbersClientOptions.ServiceVersion version = Azure.Communication.PhoneNumbers.PhoneNumbersClientOptions.ServiceVersion.V2021_03_07) { }
        public enum ServiceVersion
        {
            V2021_03_07 = 1,
        }
    }
    public partial class PhoneNumberSearchOptions
    {
        public PhoneNumberSearchOptions() { }
        public string AreaCode { get { throw null; } set { } }
        public int? Quantity { get { throw null; } set { } }
    }
    public partial class PhoneNumberSearchResult
    {
        internal PhoneNumberSearchResult() { }
        public Azure.Communication.PhoneNumbers.PhoneNumberAssignmentType AssignmentType { get { throw null; } }
        public Azure.Communication.PhoneNumbers.PhoneNumberCapabilities Capabilities { get { throw null; } }
        public Azure.Communication.PhoneNumbers.PhoneNumberCost Cost { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> PhoneNumbers { get { throw null; } }
        public Azure.Communication.PhoneNumbers.PhoneNumberType PhoneNumberType { get { throw null; } }
        public System.DateTimeOffset SearchExpiresOn { get { throw null; } }
        public string SearchId { get { throw null; } }
    }
    public static partial class PhoneNumbersModelFactory
    {
        public static Azure.Communication.PhoneNumbers.PhoneNumberCost PhoneNumberCost(double amount, string currencyCode, string billingFrequency) { throw null; }
        public static Azure.Communication.PhoneNumbers.PhoneNumberSearchResult PhoneNumberSearchResult(string searchId, System.Collections.Generic.IEnumerable<string> phoneNumbers, Azure.Communication.PhoneNumbers.PhoneNumberType phoneNumberType, Azure.Communication.PhoneNumbers.PhoneNumberAssignmentType assignmentType, Azure.Communication.PhoneNumbers.PhoneNumberCapabilities capabilities, Azure.Communication.PhoneNumbers.PhoneNumberCost cost, System.DateTimeOffset searchExpiresOn) { throw null; }
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
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.Communication.PhoneNumbers.PurchasedPhoneNumber>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.Communication.PhoneNumbers.PurchasedPhoneNumber>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
