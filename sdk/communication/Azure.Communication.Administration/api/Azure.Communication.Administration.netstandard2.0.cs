namespace Azure.Communication.Administration
{
    public partial class CommunicationIdentityClient
    {
        protected CommunicationIdentityClient() { }
        public CommunicationIdentityClient(string connectionString, Azure.Communication.Administration.CommunicationIdentityClientOptions? options = null) { }
        public virtual Azure.Response<Azure.Communication.CommunicationUserIdentifier> CreateUser(System.Collections.Generic.IEnumerable<Azure.Communication.Administration.Models.CommunicationIdentityTokenScope> scopes, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Communication.CommunicationUserIdentifier>> CreateUserAsync(System.Collections.Generic.IEnumerable<Azure.Communication.Administration.Models.CommunicationIdentityTokenScope> scopes, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response DeleteUser(Azure.Communication.CommunicationUserIdentifier communicationUser, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteUserAsync(Azure.Communication.CommunicationUserIdentifier communicationUser, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Communication.Administration.Models.CommunicationIdentityAccessToken> IssueToken(Azure.Communication.CommunicationUserIdentifier communicationUser, System.Collections.Generic.IEnumerable<Azure.Communication.Administration.Models.CommunicationIdentityTokenScope> scopes, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Communication.Administration.Models.CommunicationIdentityAccessToken>> IssueTokenAsync(Azure.Communication.CommunicationUserIdentifier communicationUser, System.Collections.Generic.IEnumerable<Azure.Communication.Administration.Models.CommunicationIdentityTokenScope> scopes, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response RevokeTokens(Azure.Communication.CommunicationUserIdentifier communicationUser, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> RevokeTokensAsync(Azure.Communication.CommunicationUserIdentifier communicationUser, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
    public partial class PhoneNumbersClient
    {
        protected PhoneNumbersClient() { }
        public PhoneNumbersClient(string connectionString) { }
        public PhoneNumbersClient(string connectionString, Azure.Communication.Administration.PhoneNumbersClientOptions? options = null) { }
        public virtual Azure.Response<Azure.Communication.Administration.Models.AcquiredPhoneNumber> GetPhoneNumber(string phoneNumber, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Communication.Administration.Models.AcquiredPhoneNumber>> GetPhoneNumberAsync(string phoneNumber, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.Communication.Administration.Models.AcquiredPhoneNumber> ListPhoneNumbers(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.Communication.Administration.Models.AcquiredPhoneNumber> ListPhoneNumbersAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Communication.Administration.Models.PurchasePhoneNumbersOperation StartPurchasePhoneNumbers(string searchId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Communication.Administration.Models.PurchasePhoneNumbersOperation> StartPurchasePhoneNumbersAsync(string searchId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Communication.Administration.Models.ReleasePhoneNumberOperation StartReleasePhoneNumber(string phoneNumber, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Communication.Administration.Models.ReleasePhoneNumberOperation> StartReleasePhoneNumberAsync(string phoneNumber, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Communication.Administration.Models.SearchAvailablePhoneNumbersOperation StartSearchAvailablePhoneNumbers(string countryCode, Azure.Communication.Administration.Models.PhoneNumberType phoneNumberType, Azure.Communication.Administration.Models.PhoneNumberAssignmentType assignmentType, Azure.Communication.Administration.Models.PhoneNumberCapabilitiesRequest capabilities, string areaCode = null, int? quantity = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Communication.Administration.Models.SearchAvailablePhoneNumbersOperation> StartSearchAvailablePhoneNumbersAsync(string countryCode, Azure.Communication.Administration.Models.PhoneNumberType phoneNumberType, Azure.Communication.Administration.Models.PhoneNumberAssignmentType assignmentType, Azure.Communication.Administration.Models.PhoneNumberCapabilitiesRequest capabilities, string areaCode = null, int? quantity = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Communication.Administration.Models.UpdatePhoneNumberCapabilitiesOperation StartUpdatePhoneNumberCapabilities(string phoneNumber, Azure.Communication.Administration.Models.PhoneNumberCapabilityValue? sms = default(Azure.Communication.Administration.Models.PhoneNumberCapabilityValue?), Azure.Communication.Administration.Models.PhoneNumberCapabilityValue? calling = default(Azure.Communication.Administration.Models.PhoneNumberCapabilityValue?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Communication.Administration.Models.UpdatePhoneNumberCapabilitiesOperation> StartUpdatePhoneNumberCapabilitiesAsync(string phoneNumber, Azure.Communication.Administration.Models.PhoneNumberCapabilityValue? sms = default(Azure.Communication.Administration.Models.PhoneNumberCapabilityValue?), Azure.Communication.Administration.Models.PhoneNumberCapabilityValue? calling = default(Azure.Communication.Administration.Models.PhoneNumberCapabilityValue?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Communication.Administration.Models.AcquiredPhoneNumber> UpdatePhoneNumber(string phoneNumber, string callbackUri = null, string applicationId = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Communication.Administration.Models.AcquiredPhoneNumber>> UpdatePhoneNumberAsync(string phoneNumber, string callbackUri = null, string applicationId = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class PhoneNumbersClientOptions : Azure.Core.ClientOptions
    {
        public const Azure.Communication.Administration.PhoneNumbersClientOptions.ServiceVersion LatestVersion = Azure.Communication.Administration.PhoneNumbersClientOptions.ServiceVersion.V1;
        public PhoneNumbersClientOptions(Azure.Communication.Administration.PhoneNumbersClientOptions.ServiceVersion version = Azure.Communication.Administration.PhoneNumbersClientOptions.ServiceVersion.V1, Azure.Core.RetryOptions? retryOptions = null, Azure.Core.Pipeline.HttpPipelineTransport? transport = null) { }
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
        public string ApplicationId { get { throw null; } }
        public Azure.Communication.Administration.Models.PhoneNumberAssignmentType AssignmentType { get { throw null; } }
        public string CallbackUri { get { throw null; } }
        public Azure.Communication.Administration.Models.PhoneNumberCapabilities Capabilities { get { throw null; } }
        public Azure.Communication.Administration.Models.PhoneNumberCost Cost { get { throw null; } }
        public string CountryCode { get { throw null; } }
        public string Id { get { throw null; } }
        public string PhoneNumber { get { throw null; } }
        public Azure.Communication.Administration.Models.PhoneNumberType PhoneNumberType { get { throw null; } }
        public System.DateTimeOffset PurchaseDate { get { throw null; } }
    }
    public static partial class AdministrationModelFactory
    {
        public static Azure.Communication.Administration.Models.AcquiredPhoneNumber AcquiredPhoneNumber(string id, string phoneNumber, string countryCode, Azure.Communication.Administration.Models.PhoneNumberType phoneNumberType, Azure.Communication.Administration.Models.PhoneNumberAssignmentType assignmentType, System.DateTimeOffset purchaseDate, Azure.Communication.Administration.Models.PhoneNumberCapabilities capabilities, string callbackUri, string applicationId, Azure.Communication.Administration.Models.PhoneNumberCost cost) { throw null; }
        public static Azure.Communication.Administration.Models.PhoneNumberCost PhoneNumberCost(double amount, string currencyCode, string billingFrequency) { throw null; }
    }
    public partial class CommunicationError
    {
        internal CommunicationError() { }
        public string Code { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Communication.Administration.Models.CommunicationError> Details { get { throw null; } }
        public Azure.Communication.Administration.Models.CommunicationError InnerError { get { throw null; } }
        public string Message { get { throw null; } }
        public string Target { get { throw null; } }
    }
    public partial class CommunicationIdentity
    {
        internal CommunicationIdentity() { }
        public string Id { get { throw null; } }
    }
    public partial class CommunicationIdentityAccessToken
    {
        internal CommunicationIdentityAccessToken() { }
        public System.DateTimeOffset ExpiresOn { get { throw null; } }
        public string Token { get { throw null; } }
    }
    public partial class CommunicationIdentityAccessTokenResult
    {
        internal CommunicationIdentityAccessTokenResult() { }
        public Azure.Communication.Administration.Models.CommunicationIdentityAccessToken AccessToken { get { throw null; } }
        public Azure.Communication.Administration.Models.CommunicationIdentity Identity { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct CommunicationIdentityTokenScope : System.IEquatable<Azure.Communication.Administration.Models.CommunicationIdentityTokenScope>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public CommunicationIdentityTokenScope(string value) { throw null; }
        public static Azure.Communication.Administration.Models.CommunicationIdentityTokenScope Chat { get { throw null; } }
        public static Azure.Communication.Administration.Models.CommunicationIdentityTokenScope Voip { get { throw null; } }
        public bool Equals(Azure.Communication.Administration.Models.CommunicationIdentityTokenScope other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Communication.Administration.Models.CommunicationIdentityTokenScope left, Azure.Communication.Administration.Models.CommunicationIdentityTokenScope right) { throw null; }
        public static implicit operator Azure.Communication.Administration.Models.CommunicationIdentityTokenScope (string value) { throw null; }
        public static bool operator !=(Azure.Communication.Administration.Models.CommunicationIdentityTokenScope left, Azure.Communication.Administration.Models.CommunicationIdentityTokenScope right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct OperationKind : System.IEquatable<Azure.Communication.Administration.Models.OperationKind>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public OperationKind(string value) { throw null; }
        public static Azure.Communication.Administration.Models.OperationKind Purchase { get { throw null; } }
        public static Azure.Communication.Administration.Models.OperationKind ReleasePhoneNumber { get { throw null; } }
        public static Azure.Communication.Administration.Models.OperationKind Search { get { throw null; } }
        public static Azure.Communication.Administration.Models.OperationKind UpdatePhoneNumberCapabilities { get { throw null; } }
        public bool Equals(Azure.Communication.Administration.Models.OperationKind other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Communication.Administration.Models.OperationKind left, Azure.Communication.Administration.Models.OperationKind right) { throw null; }
        public static implicit operator Azure.Communication.Administration.Models.OperationKind (string value) { throw null; }
        public static bool operator !=(Azure.Communication.Administration.Models.OperationKind left, Azure.Communication.Administration.Models.OperationKind right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PhoneNumberAssignmentType : System.IEquatable<Azure.Communication.Administration.Models.PhoneNumberAssignmentType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PhoneNumberAssignmentType(string value) { throw null; }
        public static Azure.Communication.Administration.Models.PhoneNumberAssignmentType Application { get { throw null; } }
        public static Azure.Communication.Administration.Models.PhoneNumberAssignmentType Person { get { throw null; } }
        public bool Equals(Azure.Communication.Administration.Models.PhoneNumberAssignmentType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Communication.Administration.Models.PhoneNumberAssignmentType left, Azure.Communication.Administration.Models.PhoneNumberAssignmentType right) { throw null; }
        public static implicit operator Azure.Communication.Administration.Models.PhoneNumberAssignmentType (string value) { throw null; }
        public static bool operator !=(Azure.Communication.Administration.Models.PhoneNumberAssignmentType left, Azure.Communication.Administration.Models.PhoneNumberAssignmentType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class PhoneNumberCapabilities
    {
        internal PhoneNumberCapabilities() { }
        public Azure.Communication.Administration.Models.PhoneNumberCapabilityValue Calling { get { throw null; } }
        public Azure.Communication.Administration.Models.PhoneNumberCapabilityValue Sms { get { throw null; } }
    }
    public partial class PhoneNumberCapabilitiesRequest
    {
        public PhoneNumberCapabilitiesRequest() { }
        public Azure.Communication.Administration.Models.PhoneNumberCapabilityValue? Calling { get { throw null; } set { } }
        public Azure.Communication.Administration.Models.PhoneNumberCapabilityValue? Sms { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PhoneNumberCapabilityValue : System.IEquatable<Azure.Communication.Administration.Models.PhoneNumberCapabilityValue>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PhoneNumberCapabilityValue(string value) { throw null; }
        public static Azure.Communication.Administration.Models.PhoneNumberCapabilityValue Inbound { get { throw null; } }
        public static Azure.Communication.Administration.Models.PhoneNumberCapabilityValue InboundOutbound { get { throw null; } }
        public static Azure.Communication.Administration.Models.PhoneNumberCapabilityValue None { get { throw null; } }
        public static Azure.Communication.Administration.Models.PhoneNumberCapabilityValue Outbound { get { throw null; } }
        public bool Equals(Azure.Communication.Administration.Models.PhoneNumberCapabilityValue other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Communication.Administration.Models.PhoneNumberCapabilityValue left, Azure.Communication.Administration.Models.PhoneNumberCapabilityValue right) { throw null; }
        public static implicit operator Azure.Communication.Administration.Models.PhoneNumberCapabilityValue (string value) { throw null; }
        public static bool operator !=(Azure.Communication.Administration.Models.PhoneNumberCapabilityValue left, Azure.Communication.Administration.Models.PhoneNumberCapabilityValue right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class PhoneNumberCost
    {
        internal PhoneNumberCost() { }
        public double Amount { get { throw null; } }
        public string BillingFrequency { get { throw null; } }
        public string CurrencyCode { get { throw null; } }
    }
    public partial class PhoneNumberSearchResult
    {
        internal PhoneNumberSearchResult() { }
        public Azure.Communication.Administration.Models.PhoneNumberAssignmentType AssignmentType { get { throw null; } }
        public Azure.Communication.Administration.Models.PhoneNumberCapabilities Capabilities { get { throw null; } }
        public Azure.Communication.Administration.Models.PhoneNumberCost Cost { get { throw null; } }
        public string Id { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> PhoneNumbers { get { throw null; } }
        public Azure.Communication.Administration.Models.PhoneNumberType PhoneNumberType { get { throw null; } }
        public System.DateTimeOffset SearchExpiresBy { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PhoneNumberType : System.IEquatable<Azure.Communication.Administration.Models.PhoneNumberType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PhoneNumberType(string value) { throw null; }
        public static Azure.Communication.Administration.Models.PhoneNumberType Geographic { get { throw null; } }
        public static Azure.Communication.Administration.Models.PhoneNumberType TollFree { get { throw null; } }
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
    public partial class PurchasePhoneNumbersOperation : Azure.Operation<Azure.Response>
    {
        internal PurchasePhoneNumbersOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.Response Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.Response>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.Response>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ReleasePhoneNumberOperation : Azure.Operation<Azure.Response>
    {
        internal ReleasePhoneNumberOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.Response Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.Response>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.Response>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SearchAvailablePhoneNumbersOperation : Azure.Operation<Azure.Communication.Administration.Models.PhoneNumberSearchResult>
    {
        internal SearchAvailablePhoneNumbersOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.Communication.Administration.Models.PhoneNumberSearchResult Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.Communication.Administration.Models.PhoneNumberSearchResult>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.Communication.Administration.Models.PhoneNumberSearchResult>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class UpdatePhoneNumberCapabilitiesOperation : Azure.Operation<Azure.Communication.Administration.Models.AcquiredPhoneNumber>
    {
        internal UpdatePhoneNumberCapabilitiesOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.Communication.Administration.Models.AcquiredPhoneNumber Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.Communication.Administration.Models.AcquiredPhoneNumber>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.Communication.Administration.Models.AcquiredPhoneNumber>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
