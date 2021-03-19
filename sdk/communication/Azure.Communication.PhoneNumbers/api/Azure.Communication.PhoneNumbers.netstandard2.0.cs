namespace Azure.Communication.PhoneNumbers
{
    public partial class PhoneNumbersClient
    {
        protected PhoneNumbersClient() { }
        public PhoneNumbersClient(string connectionString) { }
        public PhoneNumbersClient(string connectionString, Azure.Communication.PhoneNumbers.PhoneNumbersClientOptions options) { }
        public PhoneNumbersClient(System.Uri endpoint, Azure.AzureKeyCredential keyCredential, Azure.Communication.PhoneNumbers.PhoneNumbersClientOptions options = null) { }
        public PhoneNumbersClient(System.Uri endpoint, Azure.Core.TokenCredential tokenCredential, Azure.Communication.PhoneNumbers.PhoneNumbersClientOptions options = null) { }
        public virtual Azure.Response<Azure.Communication.PhoneNumbers.Models.PurchasedPhoneNumber> GetPurchasedPhoneNumber(string phoneNumber, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Communication.PhoneNumbers.Models.PurchasedPhoneNumber>> GetPurchasedPhoneNumberAsync(string phoneNumber, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.Communication.PhoneNumbers.Models.PurchasedPhoneNumber> GetPurchasedPhoneNumbers(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.Communication.PhoneNumbers.Models.PurchasedPhoneNumber> GetPurchasedPhoneNumbersAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Communication.PhoneNumbers.PurchasePhoneNumbersOperation StartPurchasePhoneNumbers(string searchId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Communication.PhoneNumbers.PurchasePhoneNumbersOperation> StartPurchasePhoneNumbersAsync(string searchId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Communication.PhoneNumbers.ReleasePhoneNumberOperation StartReleasePhoneNumber(string phoneNumber, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Communication.PhoneNumbers.ReleasePhoneNumberOperation> StartReleasePhoneNumberAsync(string phoneNumber, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Communication.PhoneNumbers.SearchAvailablePhoneNumbersOperation StartSearchAvailablePhoneNumbers(string threeLetterISOCountryName, Azure.Communication.PhoneNumbers.Models.PhoneNumberType phoneNumberType, Azure.Communication.PhoneNumbers.Models.PhoneNumberAssignmentType phoneNumberAssignmentType, Azure.Communication.PhoneNumbers.Models.PhoneNumberCapabilities capabilities, Azure.Communication.PhoneNumbers.PhoneNumberSearchOptions options = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Communication.PhoneNumbers.SearchAvailablePhoneNumbersOperation> StartSearchAvailablePhoneNumbersAsync(string threeLetterISOCountryName, Azure.Communication.PhoneNumbers.Models.PhoneNumberType phoneNumberType, Azure.Communication.PhoneNumbers.Models.PhoneNumberAssignmentType phoneNumberAssignmentType, Azure.Communication.PhoneNumbers.Models.PhoneNumberCapabilities capabilities, Azure.Communication.PhoneNumbers.PhoneNumberSearchOptions options = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Communication.PhoneNumbers.UpdatePhoneNumberCapabilitiesOperation StartUpdateCapabilities(string phoneNumber, Azure.Communication.PhoneNumbers.Models.PhoneNumberCapabilityType? calling = default(Azure.Communication.PhoneNumbers.Models.PhoneNumberCapabilityType?), Azure.Communication.PhoneNumbers.Models.PhoneNumberCapabilityType? sms = default(Azure.Communication.PhoneNumbers.Models.PhoneNumberCapabilityType?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Communication.PhoneNumbers.UpdatePhoneNumberCapabilitiesOperation> StartUpdateCapabilitiesAsync(string phoneNumber, Azure.Communication.PhoneNumbers.Models.PhoneNumberCapabilityType? calling = default(Azure.Communication.PhoneNumbers.Models.PhoneNumberCapabilityType?), Azure.Communication.PhoneNumbers.Models.PhoneNumberCapabilityType? sms = default(Azure.Communication.PhoneNumbers.Models.PhoneNumberCapabilityType?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
    public partial class PurchasePhoneNumbersOperation : Azure.Operation<Azure.Communication.PhoneNumbers.Models.PurchasePhoneNumbersResult>
    {
        internal PurchasePhoneNumbersOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.Communication.PhoneNumbers.Models.PurchasePhoneNumbersResult Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.Communication.PhoneNumbers.Models.PurchasePhoneNumbersResult>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.Communication.PhoneNumbers.Models.PurchasePhoneNumbersResult>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken) { throw null; }
    }
    public partial class ReleasePhoneNumberOperation : Azure.Operation<Azure.Communication.PhoneNumbers.Models.ReleasePhoneNumberResult>
    {
        internal ReleasePhoneNumberOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.Communication.PhoneNumbers.Models.ReleasePhoneNumberResult Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.Communication.PhoneNumbers.Models.ReleasePhoneNumberResult>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.Communication.PhoneNumbers.Models.ReleasePhoneNumberResult>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken) { throw null; }
    }
    public partial class SearchAvailablePhoneNumbersOperation : Azure.Operation<Azure.Communication.PhoneNumbers.Models.PhoneNumberSearchResult>
    {
        internal SearchAvailablePhoneNumbersOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.Communication.PhoneNumbers.Models.PhoneNumberSearchResult Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.Communication.PhoneNumbers.Models.PhoneNumberSearchResult>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.Communication.PhoneNumbers.Models.PhoneNumberSearchResult>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class UpdatePhoneNumberCapabilitiesOperation : Azure.Operation<Azure.Communication.PhoneNumbers.Models.PurchasedPhoneNumber>
    {
        internal UpdatePhoneNumberCapabilitiesOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.Communication.PhoneNumbers.Models.PurchasedPhoneNumber Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.Communication.PhoneNumbers.Models.PurchasedPhoneNumber>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.Communication.PhoneNumbers.Models.PurchasedPhoneNumber>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.Communication.PhoneNumbers.Models
{
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct BillingFrequency : System.IEquatable<Azure.Communication.PhoneNumbers.Models.BillingFrequency>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public BillingFrequency(string value) { throw null; }
        public static Azure.Communication.PhoneNumbers.Models.BillingFrequency Monthly { get { throw null; } }
        public bool Equals(Azure.Communication.PhoneNumbers.Models.BillingFrequency other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Communication.PhoneNumbers.Models.BillingFrequency left, Azure.Communication.PhoneNumbers.Models.BillingFrequency right) { throw null; }
        public static implicit operator Azure.Communication.PhoneNumbers.Models.BillingFrequency (string value) { throw null; }
        public static bool operator !=(Azure.Communication.PhoneNumbers.Models.BillingFrequency left, Azure.Communication.PhoneNumbers.Models.BillingFrequency right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PhoneNumberAssignmentType : System.IEquatable<Azure.Communication.PhoneNumbers.Models.PhoneNumberAssignmentType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PhoneNumberAssignmentType(string value) { throw null; }
        public static Azure.Communication.PhoneNumbers.Models.PhoneNumberAssignmentType Application { get { throw null; } }
        public static Azure.Communication.PhoneNumbers.Models.PhoneNumberAssignmentType Person { get { throw null; } }
        public bool Equals(Azure.Communication.PhoneNumbers.Models.PhoneNumberAssignmentType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Communication.PhoneNumbers.Models.PhoneNumberAssignmentType left, Azure.Communication.PhoneNumbers.Models.PhoneNumberAssignmentType right) { throw null; }
        public static implicit operator Azure.Communication.PhoneNumbers.Models.PhoneNumberAssignmentType (string value) { throw null; }
        public static bool operator !=(Azure.Communication.PhoneNumbers.Models.PhoneNumberAssignmentType left, Azure.Communication.PhoneNumbers.Models.PhoneNumberAssignmentType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class PhoneNumberCapabilities
    {
        public PhoneNumberCapabilities(Azure.Communication.PhoneNumbers.Models.PhoneNumberCapabilityType calling, Azure.Communication.PhoneNumbers.Models.PhoneNumberCapabilityType sms) { }
        public Azure.Communication.PhoneNumbers.Models.PhoneNumberCapabilityType Calling { get { throw null; } set { } }
        public Azure.Communication.PhoneNumbers.Models.PhoneNumberCapabilityType Sms { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PhoneNumberCapabilityType : System.IEquatable<Azure.Communication.PhoneNumbers.Models.PhoneNumberCapabilityType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PhoneNumberCapabilityType(string value) { throw null; }
        public static Azure.Communication.PhoneNumbers.Models.PhoneNumberCapabilityType Inbound { get { throw null; } }
        public static Azure.Communication.PhoneNumbers.Models.PhoneNumberCapabilityType InboundOutbound { get { throw null; } }
        public static Azure.Communication.PhoneNumbers.Models.PhoneNumberCapabilityType None { get { throw null; } }
        public static Azure.Communication.PhoneNumbers.Models.PhoneNumberCapabilityType Outbound { get { throw null; } }
        public bool Equals(Azure.Communication.PhoneNumbers.Models.PhoneNumberCapabilityType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Communication.PhoneNumbers.Models.PhoneNumberCapabilityType left, Azure.Communication.PhoneNumbers.Models.PhoneNumberCapabilityType right) { throw null; }
        public static implicit operator Azure.Communication.PhoneNumbers.Models.PhoneNumberCapabilityType (string value) { throw null; }
        public static bool operator !=(Azure.Communication.PhoneNumbers.Models.PhoneNumberCapabilityType left, Azure.Communication.PhoneNumbers.Models.PhoneNumberCapabilityType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class PhoneNumberCost
    {
        internal PhoneNumberCost() { }
        public double Amount { get { throw null; } }
        public Azure.Communication.PhoneNumbers.Models.BillingFrequency BillingFrequency { get { throw null; } }
        public string ISOCurrencySymbol { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PhoneNumberOperationStatus : System.IEquatable<Azure.Communication.PhoneNumbers.Models.PhoneNumberOperationStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PhoneNumberOperationStatus(string value) { throw null; }
        public static Azure.Communication.PhoneNumbers.Models.PhoneNumberOperationStatus Failed { get { throw null; } }
        public static Azure.Communication.PhoneNumbers.Models.PhoneNumberOperationStatus NotStarted { get { throw null; } }
        public static Azure.Communication.PhoneNumbers.Models.PhoneNumberOperationStatus Running { get { throw null; } }
        public static Azure.Communication.PhoneNumbers.Models.PhoneNumberOperationStatus Succeeded { get { throw null; } }
        public bool Equals(Azure.Communication.PhoneNumbers.Models.PhoneNumberOperationStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Communication.PhoneNumbers.Models.PhoneNumberOperationStatus left, Azure.Communication.PhoneNumbers.Models.PhoneNumberOperationStatus right) { throw null; }
        public static implicit operator Azure.Communication.PhoneNumbers.Models.PhoneNumberOperationStatus (string value) { throw null; }
        public static bool operator !=(Azure.Communication.PhoneNumbers.Models.PhoneNumberOperationStatus left, Azure.Communication.PhoneNumbers.Models.PhoneNumberOperationStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PhoneNumberOperationType : System.IEquatable<Azure.Communication.PhoneNumbers.Models.PhoneNumberOperationType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PhoneNumberOperationType(string value) { throw null; }
        public static Azure.Communication.PhoneNumbers.Models.PhoneNumberOperationType Purchase { get { throw null; } }
        public static Azure.Communication.PhoneNumbers.Models.PhoneNumberOperationType ReleasePhoneNumber { get { throw null; } }
        public static Azure.Communication.PhoneNumbers.Models.PhoneNumberOperationType Search { get { throw null; } }
        public static Azure.Communication.PhoneNumbers.Models.PhoneNumberOperationType UpdatePhoneNumberCapabilities { get { throw null; } }
        public bool Equals(Azure.Communication.PhoneNumbers.Models.PhoneNumberOperationType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Communication.PhoneNumbers.Models.PhoneNumberOperationType left, Azure.Communication.PhoneNumbers.Models.PhoneNumberOperationType right) { throw null; }
        public static implicit operator Azure.Communication.PhoneNumbers.Models.PhoneNumberOperationType (string value) { throw null; }
        public static bool operator !=(Azure.Communication.PhoneNumbers.Models.PhoneNumberOperationType left, Azure.Communication.PhoneNumbers.Models.PhoneNumberOperationType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class PhoneNumberSearchResult
    {
        internal PhoneNumberSearchResult() { }
        public Azure.Communication.PhoneNumbers.Models.PhoneNumberAssignmentType AssignmentType { get { throw null; } }
        public Azure.Communication.PhoneNumbers.Models.PhoneNumberCapabilities Capabilities { get { throw null; } }
        public Azure.Communication.PhoneNumbers.Models.PhoneNumberCost Cost { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> PhoneNumbers { get { throw null; } }
        public Azure.Communication.PhoneNumbers.Models.PhoneNumberType PhoneNumberType { get { throw null; } }
        public System.DateTimeOffset SearchExpiresOn { get { throw null; } }
        public string SearchId { get { throw null; } }
    }
    public static partial class PhoneNumbersModelFactory
    {
        public static Azure.Communication.PhoneNumbers.Models.PhoneNumberCost PhoneNumberCost(double amount, string currencyCode, string billingFrequency) { throw null; }
        public static Azure.Communication.PhoneNumbers.Models.PurchasedPhoneNumber PurchasedPhoneNumber(string id, string phoneNumber, string countryCode, Azure.Communication.PhoneNumbers.Models.PhoneNumberType phoneNumberType, Azure.Communication.PhoneNumbers.Models.PhoneNumberCapabilities capabilities, Azure.Communication.PhoneNumbers.Models.PhoneNumberAssignmentType assignmentType, System.DateTimeOffset purchaseDate, Azure.Communication.PhoneNumbers.Models.PhoneNumberCost cost) { throw null; }
        public static Azure.Communication.PhoneNumbers.Models.PurchasePhoneNumbersResult PurchasePhoneNumbersResult() { throw null; }
        public static Azure.Communication.PhoneNumbers.Models.ReleasePhoneNumberResult ReleasePhoneNumberResult() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PhoneNumberType : System.IEquatable<Azure.Communication.PhoneNumbers.Models.PhoneNumberType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PhoneNumberType(string value) { throw null; }
        public static Azure.Communication.PhoneNumbers.Models.PhoneNumberType Geographic { get { throw null; } }
        public static Azure.Communication.PhoneNumbers.Models.PhoneNumberType TollFree { get { throw null; } }
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
    public partial class PurchasedPhoneNumber
    {
        internal PurchasedPhoneNumber() { }
        public Azure.Communication.PhoneNumbers.Models.PhoneNumberAssignmentType AssignmentType { get { throw null; } }
        public Azure.Communication.PhoneNumbers.Models.PhoneNumberCapabilities Capabilities { get { throw null; } }
        public Azure.Communication.PhoneNumbers.Models.PhoneNumberCost Cost { get { throw null; } }
        public string CountryCode { get { throw null; } }
        public string Id { get { throw null; } }
        public string PhoneNumber { get { throw null; } }
        public Azure.Communication.PhoneNumbers.Models.PhoneNumberType PhoneNumberType { get { throw null; } }
        public System.DateTimeOffset PurchaseDate { get { throw null; } }
    }
    public partial class PurchasePhoneNumbersResult
    {
        internal PurchasePhoneNumbersResult() { }
    }
    public partial class ReleasePhoneNumberResult
    {
        internal ReleasePhoneNumberResult() { }
    }
}
