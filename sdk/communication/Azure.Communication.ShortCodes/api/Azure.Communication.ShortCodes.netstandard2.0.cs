namespace Azure.Communication.ShortCodes
{
    public partial class AzureCommunicationShortCodesContext : System.ClientModel.Primitives.ModelReaderWriterContext
    {
        internal AzureCommunicationShortCodesContext() { }
        public static Azure.Communication.ShortCodes.AzureCommunicationShortCodesContext Default { get { throw null; } }
        protected override bool TryGetTypeBuilderCore(System.Type type, out System.ClientModel.Primitives.ModelReaderWriterTypeBuilder builder) { throw null; }
    }
    public partial class ShortCodesClient
    {
        protected ShortCodesClient() { }
        public ShortCodesClient(string connectionString) { }
        public ShortCodesClient(string connectionString, Azure.Communication.ShortCodes.ShortCodesClientOptions options) { }
        public ShortCodesClient(System.Uri endpoint, Azure.AzureKeyCredential keyCredential, Azure.Communication.ShortCodes.ShortCodesClientOptions options = null) { }
        public ShortCodesClient(System.Uri endpoint, Azure.Core.TokenCredential tokenCredential, Azure.Communication.ShortCodes.ShortCodesClientOptions options = null) { }
        public virtual Azure.Response DeleteUSProgramBrief(System.Guid programBriefId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteUSProgramBriefAsync(System.Guid programBriefId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.Communication.ShortCodes.Models.ShortCode> GetShortCodes(int? skip = default(int?), int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.Communication.ShortCodes.Models.ShortCode> GetShortCodesAsync(int? skip = default(int?), int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Communication.ShortCodes.Models.USProgramBrief> GetUSProgramBrief(System.Guid programBriefId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Communication.ShortCodes.Models.USProgramBrief>> GetUSProgramBriefAsync(System.Guid programBriefId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.Communication.ShortCodes.Models.USProgramBrief> GetUSProgramBriefs(int? skip = default(int?), int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.Communication.ShortCodes.Models.USProgramBrief> GetUSProgramBriefsAsync(int? skip = default(int?), int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Communication.ShortCodes.Models.USProgramBrief> SubmitUSProgramBrief(System.Guid programBriefId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Communication.ShortCodes.Models.USProgramBrief>> SubmitUSProgramBriefAsync(System.Guid programBriefId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Communication.ShortCodes.Models.USProgramBrief> UpsertUSProgramBrief(System.Guid programBriefId, Azure.Communication.ShortCodes.Models.USProgramBrief body = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Communication.ShortCodes.Models.USProgramBrief>> UpsertUSProgramBriefAsync(System.Guid programBriefId, Azure.Communication.ShortCodes.Models.USProgramBrief body = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ShortCodesClientOptions : Azure.Core.ClientOptions
    {
        public ShortCodesClientOptions(Azure.Communication.ShortCodes.ShortCodesClientOptions.ServiceVersion version = Azure.Communication.ShortCodes.ShortCodesClientOptions.ServiceVersion.V2021_10_25_Preview) { }
        public enum ServiceVersion
        {
            V2021_10_25_Preview = 1,
        }
    }
}
namespace Azure.Communication.ShortCodes.Models
{
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct BillingFrequency : System.IEquatable<Azure.Communication.ShortCodes.Models.BillingFrequency>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public BillingFrequency(string value) { throw null; }
        public static Azure.Communication.ShortCodes.Models.BillingFrequency Monthly { get { throw null; } }
        public static Azure.Communication.ShortCodes.Models.BillingFrequency Once { get { throw null; } }
        public bool Equals(Azure.Communication.ShortCodes.Models.BillingFrequency other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Communication.ShortCodes.Models.BillingFrequency left, Azure.Communication.ShortCodes.Models.BillingFrequency right) { throw null; }
        public static implicit operator Azure.Communication.ShortCodes.Models.BillingFrequency (string value) { throw null; }
        public static bool operator !=(Azure.Communication.ShortCodes.Models.BillingFrequency left, Azure.Communication.ShortCodes.Models.BillingFrequency right) { throw null; }
        public override string ToString() { throw null; }
    }
    public static partial class CommunicationShortCodesModelFactory
    {
        public static Azure.Communication.ShortCodes.Models.ShortCode ShortCode(string number = null, Azure.Communication.ShortCodes.Models.NumberType? numberType = default(Azure.Communication.ShortCodes.Models.NumberType?), string countryCode = null, System.Collections.Generic.IEnumerable<string> programBriefIds = null, System.DateTimeOffset? purchaseDate = default(System.DateTimeOffset?)) { throw null; }
    }
    public partial class CompanyInformation
    {
        public CompanyInformation() { }
        public string Address { get { throw null; } set { } }
        public Azure.Communication.ShortCodes.Models.ContactInformation ContactInformation { get { throw null; } set { } }
        public Azure.Communication.ShortCodes.Models.CustomerCareInformation CustomerCareInformation { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public System.Uri Url { get { throw null; } set { } }
    }
    public partial class ContactInformation
    {
        public ContactInformation() { }
        public string Email { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public string Phone { get { throw null; } set { } }
    }
    public partial class CustomerCareInformation
    {
        public CustomerCareInformation() { }
        public string Email { get { throw null; } set { } }
        public string TollFreeNumber { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MessageContentCategory : System.IEquatable<Azure.Communication.ShortCodes.Models.MessageContentCategory>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MessageContentCategory(string value) { throw null; }
        public static Azure.Communication.ShortCodes.Models.MessageContentCategory AccountNotification { get { throw null; } }
        public static Azure.Communication.ShortCodes.Models.MessageContentCategory AgeGatedContent { get { throw null; } }
        public static Azure.Communication.ShortCodes.Models.MessageContentCategory Application { get { throw null; } }
        public static Azure.Communication.ShortCodes.Models.MessageContentCategory AudioChat { get { throw null; } }
        public static Azure.Communication.ShortCodes.Models.MessageContentCategory ConversationalMessaging { get { throw null; } }
        public static Azure.Communication.ShortCodes.Models.MessageContentCategory Coupons { get { throw null; } }
        public static Azure.Communication.ShortCodes.Models.MessageContentCategory DeliveryNotification { get { throw null; } }
        public static Azure.Communication.ShortCodes.Models.MessageContentCategory Education { get { throw null; } }
        public static Azure.Communication.ShortCodes.Models.MessageContentCategory EmergencyAlerts { get { throw null; } }
        public static Azure.Communication.ShortCodes.Models.MessageContentCategory EntertainmentAlerts { get { throw null; } }
        public static Azure.Communication.ShortCodes.Models.MessageContentCategory FinancialBanking { get { throw null; } }
        public static Azure.Communication.ShortCodes.Models.MessageContentCategory FraudAlerts { get { throw null; } }
        public static Azure.Communication.ShortCodes.Models.MessageContentCategory Games { get { throw null; } }
        public static Azure.Communication.ShortCodes.Models.MessageContentCategory Gifting { get { throw null; } }
        public static Azure.Communication.ShortCodes.Models.MessageContentCategory InApplicationBilling { get { throw null; } }
        public static Azure.Communication.ShortCodes.Models.MessageContentCategory InformationalAlerts { get { throw null; } }
        public static Azure.Communication.ShortCodes.Models.MessageContentCategory LoanArrangement { get { throw null; } }
        public static Azure.Communication.ShortCodes.Models.MessageContentCategory LoyaltyProgram { get { throw null; } }
        public static Azure.Communication.ShortCodes.Models.MessageContentCategory LoyaltyProgramPointsPrizes { get { throw null; } }
        public static Azure.Communication.ShortCodes.Models.MessageContentCategory MicroBilling { get { throw null; } }
        public static Azure.Communication.ShortCodes.Models.MessageContentCategory MmsPictures { get { throw null; } }
        public static Azure.Communication.ShortCodes.Models.MessageContentCategory MobileGivingDonations { get { throw null; } }
        public static Azure.Communication.ShortCodes.Models.MessageContentCategory NoPointsPrizes { get { throw null; } }
        public static Azure.Communication.ShortCodes.Models.MessageContentCategory OnBehalfOfCarrier { get { throw null; } }
        public static Azure.Communication.ShortCodes.Models.MessageContentCategory Other { get { throw null; } }
        public static Azure.Communication.ShortCodes.Models.MessageContentCategory Political { get { throw null; } }
        public static Azure.Communication.ShortCodes.Models.MessageContentCategory PremiumWap { get { throw null; } }
        public static Azure.Communication.ShortCodes.Models.MessageContentCategory PromotionalMarketing { get { throw null; } }
        public static Azure.Communication.ShortCodes.Models.MessageContentCategory PublicServiceAnnouncements { get { throw null; } }
        public static Azure.Communication.ShortCodes.Models.MessageContentCategory QueryService { get { throw null; } }
        public static Azure.Communication.ShortCodes.Models.MessageContentCategory RingTones { get { throw null; } }
        public static Azure.Communication.ShortCodes.Models.MessageContentCategory SecurityAlerts { get { throw null; } }
        public static Azure.Communication.ShortCodes.Models.MessageContentCategory SmsChat { get { throw null; } }
        public static Azure.Communication.ShortCodes.Models.MessageContentCategory SocialMedia { get { throw null; } }
        public static Azure.Communication.ShortCodes.Models.MessageContentCategory SweepstakesContestAuction { get { throw null; } }
        public static Azure.Communication.ShortCodes.Models.MessageContentCategory TextToScreen { get { throw null; } }
        public static Azure.Communication.ShortCodes.Models.MessageContentCategory Trivia { get { throw null; } }
        public static Azure.Communication.ShortCodes.Models.MessageContentCategory TwoFactorAuthentication { get { throw null; } }
        public static Azure.Communication.ShortCodes.Models.MessageContentCategory Video { get { throw null; } }
        public static Azure.Communication.ShortCodes.Models.MessageContentCategory Voting { get { throw null; } }
        public static Azure.Communication.ShortCodes.Models.MessageContentCategory WallpaperScreensaver { get { throw null; } }
        public bool Equals(Azure.Communication.ShortCodes.Models.MessageContentCategory other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Communication.ShortCodes.Models.MessageContentCategory left, Azure.Communication.ShortCodes.Models.MessageContentCategory right) { throw null; }
        public static implicit operator Azure.Communication.ShortCodes.Models.MessageContentCategory (string value) { throw null; }
        public static bool operator !=(Azure.Communication.ShortCodes.Models.MessageContentCategory left, Azure.Communication.ShortCodes.Models.MessageContentCategory right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class MessageDetails
    {
        public MessageDetails() { }
        public string ConfirmationMessage { get { throw null; } set { } }
        public Azure.Communication.ShortCodes.Models.MessageDirectionality? Directionality { get { throw null; } set { } }
        public string HelpMessage { get { throw null; } set { } }
        public string OptInMessage { get { throw null; } set { } }
        public string OptInReply { get { throw null; } set { } }
        public string OptOutMessage { get { throw null; } set { } }
        public Azure.Communication.ShortCodes.Models.MessageRecurrence? Recurrence { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.Communication.ShortCodes.Models.MessageProtocol> SupportedProtocols { get { throw null; } }
        public System.Collections.Generic.IList<Azure.Communication.ShortCodes.Models.UseCase> UseCases { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MessageDirection : System.IEquatable<Azure.Communication.ShortCodes.Models.MessageDirection>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MessageDirection(string value) { throw null; }
        public static Azure.Communication.ShortCodes.Models.MessageDirection FromUser { get { throw null; } }
        public static Azure.Communication.ShortCodes.Models.MessageDirection ToUser { get { throw null; } }
        public bool Equals(Azure.Communication.ShortCodes.Models.MessageDirection other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Communication.ShortCodes.Models.MessageDirection left, Azure.Communication.ShortCodes.Models.MessageDirection right) { throw null; }
        public static implicit operator Azure.Communication.ShortCodes.Models.MessageDirection (string value) { throw null; }
        public static bool operator !=(Azure.Communication.ShortCodes.Models.MessageDirection left, Azure.Communication.ShortCodes.Models.MessageDirection right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MessageDirectionality : System.IEquatable<Azure.Communication.ShortCodes.Models.MessageDirectionality>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MessageDirectionality(string value) { throw null; }
        public static Azure.Communication.ShortCodes.Models.MessageDirectionality OneWay { get { throw null; } }
        public static Azure.Communication.ShortCodes.Models.MessageDirectionality TwoWay { get { throw null; } }
        public bool Equals(Azure.Communication.ShortCodes.Models.MessageDirectionality other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Communication.ShortCodes.Models.MessageDirectionality left, Azure.Communication.ShortCodes.Models.MessageDirectionality right) { throw null; }
        public static implicit operator Azure.Communication.ShortCodes.Models.MessageDirectionality (string value) { throw null; }
        public static bool operator !=(Azure.Communication.ShortCodes.Models.MessageDirectionality left, Azure.Communication.ShortCodes.Models.MessageDirectionality right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class MessageExample
    {
        public MessageExample() { }
        public Azure.Communication.ShortCodes.Models.MessageDirection? Direction { get { throw null; } set { } }
        public string Text { get { throw null; } set { } }
    }
    public partial class MessageExampleSequence
    {
        public MessageExampleSequence() { }
        public System.Collections.Generic.IList<Azure.Communication.ShortCodes.Models.MessageExample> Messages { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MessageProtocol : System.IEquatable<Azure.Communication.ShortCodes.Models.MessageProtocol>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MessageProtocol(string value) { throw null; }
        public static Azure.Communication.ShortCodes.Models.MessageProtocol Mms { get { throw null; } }
        public static Azure.Communication.ShortCodes.Models.MessageProtocol Sms { get { throw null; } }
        public bool Equals(Azure.Communication.ShortCodes.Models.MessageProtocol other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Communication.ShortCodes.Models.MessageProtocol left, Azure.Communication.ShortCodes.Models.MessageProtocol right) { throw null; }
        public static implicit operator Azure.Communication.ShortCodes.Models.MessageProtocol (string value) { throw null; }
        public static bool operator !=(Azure.Communication.ShortCodes.Models.MessageProtocol left, Azure.Communication.ShortCodes.Models.MessageProtocol right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MessageRecurrence : System.IEquatable<Azure.Communication.ShortCodes.Models.MessageRecurrence>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MessageRecurrence(string value) { throw null; }
        public static Azure.Communication.ShortCodes.Models.MessageRecurrence Subscription { get { throw null; } }
        public static Azure.Communication.ShortCodes.Models.MessageRecurrence Transaction { get { throw null; } }
        public bool Equals(Azure.Communication.ShortCodes.Models.MessageRecurrence other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Communication.ShortCodes.Models.MessageRecurrence left, Azure.Communication.ShortCodes.Models.MessageRecurrence right) { throw null; }
        public static implicit operator Azure.Communication.ShortCodes.Models.MessageRecurrence (string value) { throw null; }
        public static bool operator !=(Azure.Communication.ShortCodes.Models.MessageRecurrence left, Azure.Communication.ShortCodes.Models.MessageRecurrence right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct NumberType : System.IEquatable<Azure.Communication.ShortCodes.Models.NumberType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public NumberType(string value) { throw null; }
        public static Azure.Communication.ShortCodes.Models.NumberType AlphaId { get { throw null; } }
        public static Azure.Communication.ShortCodes.Models.NumberType ShortCode { get { throw null; } }
        public bool Equals(Azure.Communication.ShortCodes.Models.NumberType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Communication.ShortCodes.Models.NumberType left, Azure.Communication.ShortCodes.Models.NumberType right) { throw null; }
        public static implicit operator Azure.Communication.ShortCodes.Models.NumberType (string value) { throw null; }
        public static bool operator !=(Azure.Communication.ShortCodes.Models.NumberType left, Azure.Communication.ShortCodes.Models.NumberType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ProgramBriefStatus : System.IEquatable<Azure.Communication.ShortCodes.Models.ProgramBriefStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ProgramBriefStatus(string value) { throw null; }
        public static Azure.Communication.ShortCodes.Models.ProgramBriefStatus Approved { get { throw null; } }
        public static Azure.Communication.ShortCodes.Models.ProgramBriefStatus Denied { get { throw null; } }
        public static Azure.Communication.ShortCodes.Models.ProgramBriefStatus Draft { get { throw null; } }
        public static Azure.Communication.ShortCodes.Models.ProgramBriefStatus SubmitNewVanityNumbers { get { throw null; } }
        public static Azure.Communication.ShortCodes.Models.ProgramBriefStatus Submitted { get { throw null; } }
        public static Azure.Communication.ShortCodes.Models.ProgramBriefStatus UpdateProgramBrief { get { throw null; } }
        public bool Equals(Azure.Communication.ShortCodes.Models.ProgramBriefStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Communication.ShortCodes.Models.ProgramBriefStatus left, Azure.Communication.ShortCodes.Models.ProgramBriefStatus right) { throw null; }
        public static implicit operator Azure.Communication.ShortCodes.Models.ProgramBriefStatus (string value) { throw null; }
        public static bool operator !=(Azure.Communication.ShortCodes.Models.ProgramBriefStatus left, Azure.Communication.ShortCodes.Models.ProgramBriefStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ProgramDetails
    {
        public ProgramDetails() { }
        public string Description { get { throw null; } set { } }
        public System.DateTimeOffset? ExpectedDateOfService { get { throw null; } set { } }
        public bool? IsPoliticalCampaign { get { throw null; } set { } }
        public bool? IsVanity { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public Azure.Communication.ShortCodes.Models.NumberType? NumberType { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> PreferredVanityNumbers { get { throw null; } }
        public System.Uri PrivacyPolicyUrl { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.Communication.ShortCodes.Models.ProgramSignUpType> SignUpTypes { get { throw null; } }
        public System.Uri SignUpUrl { get { throw null; } set { } }
        public System.Uri TermsOfServiceUrl { get { throw null; } set { } }
        public System.Uri Url { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ProgramSignUpType : System.IEquatable<Azure.Communication.ShortCodes.Models.ProgramSignUpType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ProgramSignUpType(string value) { throw null; }
        public static Azure.Communication.ShortCodes.Models.ProgramSignUpType InteractiveVoiceResponse { get { throw null; } }
        public static Azure.Communication.ShortCodes.Models.ProgramSignUpType PointOfSale { get { throw null; } }
        public static Azure.Communication.ShortCodes.Models.ProgramSignUpType Sms { get { throw null; } }
        public static Azure.Communication.ShortCodes.Models.ProgramSignUpType Website { get { throw null; } }
        public bool Equals(Azure.Communication.ShortCodes.Models.ProgramSignUpType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Communication.ShortCodes.Models.ProgramSignUpType left, Azure.Communication.ShortCodes.Models.ProgramSignUpType right) { throw null; }
        public static implicit operator Azure.Communication.ShortCodes.Models.ProgramSignUpType (string value) { throw null; }
        public static bool operator !=(Azure.Communication.ShortCodes.Models.ProgramSignUpType left, Azure.Communication.ShortCodes.Models.ProgramSignUpType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ReviewNote
    {
        public ReviewNote() { }
        public System.DateTimeOffset? Date { get { throw null; } set { } }
        public string Message { get { throw null; } set { } }
    }
    public partial class ShortCode
    {
        internal ShortCode() { }
        public string CountryCode { get { throw null; } }
        public string Number { get { throw null; } }
        public Azure.Communication.ShortCodes.Models.NumberType? NumberType { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> ProgramBriefIds { get { throw null; } }
        public System.DateTimeOffset? PurchaseDate { get { throw null; } }
    }
    public partial class ShortCodeCost
    {
        public ShortCodeCost(double amount, string currencyCode, Azure.Communication.ShortCodes.Models.BillingFrequency billingFrequency) { }
        public double Amount { get { throw null; } set { } }
        public Azure.Communication.ShortCodes.Models.BillingFrequency BillingFrequency { get { throw null; } set { } }
        public string CurrencyCode { get { throw null; } set { } }
    }
    public partial class TrafficDetails
    {
        public TrafficDetails() { }
        public int? EstimatedRampUpTimeInDays { get { throw null; } set { } }
        public bool? IsSpiky { get { throw null; } set { } }
        public int? MonthlyAverageMessagesFromUser { get { throw null; } set { } }
        public int? MonthlyAverageMessagesToUser { get { throw null; } set { } }
        public string SpikeDetails { get { throw null; } set { } }
        public int? TotalMonthlyVolume { get { throw null; } set { } }
    }
    public partial class UseCase
    {
        public UseCase() { }
        public Azure.Communication.ShortCodes.Models.MessageContentCategory? ContentCategory { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.Communication.ShortCodes.Models.MessageExampleSequence> Examples { get { throw null; } }
    }
    public partial class USProgramBrief
    {
        public USProgramBrief(System.Guid id) { }
        public Azure.Communication.ShortCodes.Models.CompanyInformation CompanyInformation { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.Communication.ShortCodes.Models.ShortCodeCost> Costs { get { throw null; } }
        public System.Guid Id { get { throw null; } set { } }
        public Azure.Communication.ShortCodes.Models.MessageDetails MessageDetails { get { throw null; } set { } }
        public string Number { get { throw null; } set { } }
        public Azure.Communication.ShortCodes.Models.ProgramDetails ProgramDetails { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.Communication.ShortCodes.Models.ReviewNote> ReviewNotes { get { throw null; } }
        public Azure.Communication.ShortCodes.Models.ProgramBriefStatus? Status { get { throw null; } set { } }
        public System.DateTimeOffset? StatusUpdatedDate { get { throw null; } set { } }
        public System.DateTimeOffset? SubmissionDate { get { throw null; } set { } }
        public Azure.Communication.ShortCodes.Models.TrafficDetails TrafficDetails { get { throw null; } set { } }
    }
}
