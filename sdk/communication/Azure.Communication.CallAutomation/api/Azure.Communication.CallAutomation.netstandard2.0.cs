namespace Azure.Communication.CallAutomation
{
    public partial class AddParticipantsEventResult : Azure.Communication.CallAutomation.EventResultBase
    {
        internal AddParticipantsEventResult() { }
        public Azure.Communication.CallAutomation.AddParticipantsFailed FailureEvent { get { throw null; } }
        public Azure.Communication.CallAutomation.AddParticipantsSucceeded SuccessEvent { get { throw null; } }
    }
    public partial class AddParticipantsFailed : Azure.Communication.CallAutomation.CallAutomationEventBase
    {
        internal AddParticipantsFailed() { }
        public System.Collections.Generic.IReadOnlyList<Azure.Communication.CommunicationIdentifier> Participants { get { throw null; } }
        public static Azure.Communication.CallAutomation.AddParticipantsFailed Deserialize(string content) { throw null; }
    }
    public partial class AddParticipantsOptions
    {
        public AddParticipantsOptions(System.Collections.Generic.IEnumerable<Azure.Communication.CommunicationIdentifier> participantsToAdd) { }
        public int? InvitationTimeoutInSeconds { get { throw null; } set { } }
        public string OperationContext { get { throw null; } set { } }
        public System.Collections.Generic.IEnumerable<Azure.Communication.CommunicationIdentifier> ParticipantsToAdd { get { throw null; } }
        public Azure.Communication.CallAutomation.RepeatabilityHeaders RepeatabilityHeaders { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> SipHeaders { get { throw null; } set { } }
        public Azure.Communication.PhoneNumberIdentifier SourceCallerId { get { throw null; } set { } }
        public string SourceDisplayName { get { throw null; } set { } }
        public Azure.Communication.CommunicationIdentifier SourceIdentifier { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> VoipHeaders { get { throw null; } set { } }
    }
    public partial class AddParticipantsResult : Azure.Communication.CallAutomation.ResultWithWaitForEventBase
    {
        internal AddParticipantsResult() { }
        public string OperationContext { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Communication.CallAutomation.CallParticipant> Participants { get { throw null; } }
        public System.Threading.Tasks.Task<Azure.Communication.CallAutomation.AddParticipantsEventResult> WaitForEvent(System.TimeSpan eventTimeout = default(System.TimeSpan)) { throw null; }
    }
    public partial class AddParticipantsSucceeded : Azure.Communication.CallAutomation.CallAutomationEventBase
    {
        internal AddParticipantsSucceeded() { }
        public System.Collections.Generic.IReadOnlyList<Azure.Communication.CommunicationIdentifier> Participants { get { throw null; } }
        public static Azure.Communication.CallAutomation.AddParticipantsSucceeded Deserialize(string content) { throw null; }
    }
    public partial class AnswerCallEventResult : Azure.Communication.CallAutomation.EventResultBase
    {
        internal AnswerCallEventResult() { }
        public Azure.Communication.CallAutomation.CallConnected SuccessEvent { get { throw null; } }
    }
    public partial class AnswerCallOptions
    {
        public AnswerCallOptions(string incomingCallContext, System.Uri callbackUri) { }
        public System.Uri AzureCognitiveServicesEndpointUrl { get { throw null; } set { } }
        public System.Uri CallbackUri { get { throw null; } }
        public string IncomingCallContext { get { throw null; } }
        public Azure.Communication.CallAutomation.MediaStreamingOptions MediaStreamingOptions { get { throw null; } set { } }
        public Azure.Communication.CallAutomation.RepeatabilityHeaders RepeatabilityHeaders { get { throw null; } set { } }
    }
    public partial class AnswerCallResult : Azure.Communication.CallAutomation.ResultWithWaitForEventBase
    {
        internal AnswerCallResult() { }
        public Azure.Communication.CallAutomation.CallConnection CallConnection { get { throw null; } }
        public Azure.Communication.CallAutomation.CallConnectionProperties CallConnectionProperties { get { throw null; } }
        public System.Threading.Tasks.Task<Azure.Communication.CallAutomation.AnswerCallEventResult> WaitForEvent(System.TimeSpan eventTimeout = default(System.TimeSpan)) { throw null; }
    }
    public partial class CallAutomationClient
    {
        protected CallAutomationClient() { }
        public CallAutomationClient(string connectionString) { }
        public CallAutomationClient(string connectionString, Azure.Communication.CallAutomation.CallAutomationClientOptions options) { }
        public CallAutomationClient(System.Uri endpoint, Azure.Core.TokenCredential credential, Azure.Communication.CallAutomation.CallAutomationClientOptions options = null) { }
        public CallAutomationClient(System.Uri pmaEndpoint, string connectionString, Azure.Communication.CallAutomation.CallAutomationClientOptions options = null) { }
        public virtual Azure.Response<Azure.Communication.CallAutomation.AnswerCallResult> AnswerCall(Azure.Communication.CallAutomation.AnswerCallOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Communication.CallAutomation.AnswerCallResult> AnswerCall(string incomingCallContext, System.Uri callbackUri, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Communication.CallAutomation.AnswerCallResult>> AnswerCallAsync(Azure.Communication.CallAutomation.AnswerCallOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Communication.CallAutomation.AnswerCallResult>> AnswerCallAsync(string incomingCallContext, System.Uri callbackUri, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Communication.CallAutomation.CreateCallResult> CreateCall(Azure.Communication.CallAutomation.CreateCallOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Communication.CallAutomation.CreateCallResult>> CreateCallAsync(Azure.Communication.CallAutomation.CreateCallOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Communication.CallAutomation.CallConnection GetCallConnection(string callConnectionId) { throw null; }
        public virtual Azure.Communication.CallAutomation.CallRecording GetCallRecording() { throw null; }
        public virtual Azure.Communication.CallAutomation.EventProcessor GetEventProcessor() { throw null; }
        public virtual Azure.Response RedirectCall(Azure.Communication.CallAutomation.RedirectCallOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response RedirectCall(string incomingCallContext, Azure.Communication.CommunicationIdentifier target, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> RedirectCallAsync(Azure.Communication.CallAutomation.RedirectCallOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> RedirectCallAsync(string incomingCallContext, Azure.Communication.CommunicationIdentifier target, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response RejectCall(Azure.Communication.CallAutomation.RejectCallOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response RejectCall(string incomingCallContext, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> RejectCallAsync(Azure.Communication.CallAutomation.RejectCallOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> RejectCallAsync(string incomingCallContext, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class CallAutomationClientOptions : Azure.Core.ClientOptions
    {
        public CallAutomationClientOptions(Azure.Communication.CallAutomation.CallAutomationClientOptions.ServiceVersion version = Azure.Communication.CallAutomation.CallAutomationClientOptions.ServiceVersion.V2023_01_15_Preview) { }
        public Azure.Communication.CallAutomation.EventProcessorOptions EventProcessorOptions { get { throw null; } }
        public enum ServiceVersion
        {
            V2023_01_15_Preview = 1,
        }
    }
    public static partial class CallAutomationErrorMessages
    {
        public const string InvalidCognitiveServiceHttpsUriMessage = "Cognitive Service Uri has to be in well-formed, valid https format.";
        public const string InvalidHttpsUriMessage = "Callback Uri has to be in well-formed, valid https format.";
        public const string InvalidInvitationTimeoutInSeconds = "InvitationTimeoutInSeconds has to be between 1 and 180 seconds.";
        public const string InvalidRepeatabilityHeadersMessage = "Invalid RepeatabilityHeaders. RepeatabilityHeaders is only valid when RepeatabilityRequestId and RepeatabilityFirstSent are set to non-default value.";
        public const string OperationContextExceedsMaxLength = "OperationContext exceeds maximum string length of 5000.";
        public const string UserToUserInformationExceedsMaxLength = "UserToUserInformation exceeds maximum string length of 5000.";
    }
    public abstract partial class CallAutomationEventBase
    {
        protected CallAutomationEventBase() { }
        public string CallConnectionId { get { throw null; } }
        public string CorrelationId { get { throw null; } }
        public string? OperationContext { get { throw null; } }
        public Azure.Communication.CallAutomation.ResultInformation? ResultInformation { get { throw null; } }
        public string ServerCallId { get { throw null; } }
    }
    public static partial class CallAutomationEventParser
    {
        public static Azure.Communication.CallAutomation.CallAutomationEventBase Parse(Azure.Messaging.CloudEvent cloudEvent) { throw null; }
        public static Azure.Communication.CallAutomation.CallAutomationEventBase Parse(System.BinaryData json) { throw null; }
        public static Azure.Communication.CallAutomation.CallAutomationEventBase Parse(string eventData, string eventType) { throw null; }
        public static Azure.Communication.CallAutomation.CallAutomationEventBase[] ParseMany(Azure.Messaging.CloudEvent[] cloudEvents) { throw null; }
        public static Azure.Communication.CallAutomation.CallAutomationEventBase[] ParseMany(System.BinaryData json) { throw null; }
    }
    public abstract partial class CallAutomationEventWithReasonCodeName : Azure.Communication.CallAutomation.CallAutomationEventBase
    {
        protected CallAutomationEventWithReasonCodeName() { }
        public Azure.Communication.CallAutomation.ReasonCode ReasonCode { get { throw null; } }
    }
    public static partial class CallAutomationModelFactory
    {
        public static Azure.Communication.CallAutomation.AddParticipantsFailed AddParticipantsFailed(string callConnectionId = null, string serverCallId = null, string correlationId = null, string operationContext = null, Azure.Communication.CallAutomation.ResultInformation resultInformation = null, System.Collections.Generic.IEnumerable<Azure.Communication.CommunicationIdentifier> participants = null) { throw null; }
        public static Azure.Communication.CallAutomation.AddParticipantsResult AddParticipantsResult(System.Collections.Generic.IEnumerable<Azure.Communication.CallAutomation.CallParticipant> participants = null, string operationContext = null) { throw null; }
        public static Azure.Communication.CallAutomation.AddParticipantsSucceeded AddParticipantsSucceeded(string callConnectionId = null, string serverCallId = null, string correlationId = null, string operationContext = null, Azure.Communication.CallAutomation.ResultInformation resultInformation = null, System.Collections.Generic.IEnumerable<Azure.Communication.CommunicationIdentifier> participants = null) { throw null; }
        public static Azure.Communication.CallAutomation.AnswerCallResult AnswerCallResult(Azure.Communication.CallAutomation.CallConnection callConnection = null, Azure.Communication.CallAutomation.CallConnectionProperties callConnectionProperties = null) { throw null; }
        public static Azure.Communication.CallAutomation.CallConnected CallConnected(string callConnectionId = null, string serverCallId = null, string correlationId = null, string operationContext = null) { throw null; }
        public static Azure.Communication.CallAutomation.CallConnectionProperties CallConnectionProperties(string callConnectionId = null, string serverCallId = null, Azure.Communication.CallAutomation.CallSource callSource = null, System.Collections.Generic.IEnumerable<Azure.Communication.CommunicationIdentifier> targets = null, Azure.Communication.CallAutomation.CallConnectionState callConnectionState = default(Azure.Communication.CallAutomation.CallConnectionState), System.Uri callbackEndpoint = null, string mediaSubscriptionId = null) { throw null; }
        public static Azure.Communication.CallAutomation.CallDisconnected CallDisconnected(string callConnectionId = null, string serverCallId = null, string correlationId = null, string operationContext = null) { throw null; }
        public static Azure.Communication.CallAutomation.CallParticipant CallParticipant(Azure.Communication.CommunicationIdentifier identifier = null, bool isMuted = false) { throw null; }
        public static Azure.Communication.CallAutomation.CallTransferAccepted CallTransferAccepted(string callConnectionId = null, string serverCallId = null, string correlationId = null, string operationContext = null, Azure.Communication.CallAutomation.ResultInformation resultInformation = null) { throw null; }
        public static Azure.Communication.CallAutomation.CallTransferFailed CallTransferFailed(string callConnectionId = null, string serverCallId = null, string correlationId = null, string operationContext = null, Azure.Communication.CallAutomation.ResultInformation resultInformation = null) { throw null; }
        public static Azure.Communication.CallAutomation.ChoiceResult ChoiceResult(string label = null, string recognizedPhrase = null) { throw null; }
        public static Azure.Communication.CallAutomation.CollectTonesResult CollectTonesResult(System.Collections.Generic.IEnumerable<Azure.Communication.CallAutomation.DtmfTone> tones = null) { throw null; }
        public static Azure.Communication.CallAutomation.CreateCallResult CreateCallResult(Azure.Communication.CallAutomation.CallConnection callConnection = null, Azure.Communication.CallAutomation.CallConnectionProperties callConnectionProperties = null) { throw null; }
        public static Azure.Communication.CallAutomation.MuteParticipantsResponse MuteParticipantsResponse(string operationContext = null) { throw null; }
        public static Azure.Communication.CallAutomation.ParticipantsUpdated ParticipantsUpdated(string callConnectionId = null, string serverCallId = null, string correlationId = null, System.Collections.Generic.IEnumerable<Azure.Communication.CallAutomation.CallParticipant> participants = null) { throw null; }
        public static Azure.Communication.CallAutomation.PlayCanceled PlayCanceled(string callConnectionId = null, string serverCallId = null, string correlationId = null, string operationContext = null) { throw null; }
        public static Azure.Communication.CallAutomation.PlayCompleted PlayCompleted(string callConnectionId = null, string serverCallId = null, string correlationId = null, string operationContext = null, Azure.Communication.CallAutomation.ResultInformation resultInformation = null) { throw null; }
        public static Azure.Communication.CallAutomation.PlayFailed PlayFailed(string callConnectionId = null, string serverCallId = null, string correlationId = null, string operationContext = null, Azure.Communication.CallAutomation.ResultInformation resultInformation = null) { throw null; }
        public static Azure.Communication.CallAutomation.RecognizeCanceled RecognizeCanceled(string callConnectionId = null, string serverCallId = null, string correlationId = null, string operationContext = null) { throw null; }
        public static Azure.Communication.CallAutomation.RecognizeCompleted RecognizeCompleted(string callConnectionId = null, string serverCallId = null, string correlationId = null, string operationContext = null, Azure.Communication.CallAutomation.ResultInformation resultInformation = null, Azure.Communication.CallAutomation.CallMediaRecognitionType recognitionType = default(Azure.Communication.CallAutomation.CallMediaRecognitionType), Azure.Communication.CallAutomation.CollectTonesResult collectTonesResult = null, Azure.Communication.CallAutomation.ChoiceResult choiceResult = null) { throw null; }
        public static Azure.Communication.CallAutomation.RecognizeFailed RecognizeFailed(string callConnectionId = null, string serverCallId = null, string correlationId = null, string operationContext = null, Azure.Communication.CallAutomation.ResultInformation resultInformation = null) { throw null; }
        public static Azure.Communication.CallAutomation.RecordingStateChanged RecordingStateChanged(string callConnectionId = null, string serverCallId = null, string correlationId = null, string recordingId = null, Azure.Communication.CallAutomation.RecordingState state = default(Azure.Communication.CallAutomation.RecordingState), System.DateTimeOffset? startDateTime = default(System.DateTimeOffset?)) { throw null; }
        public static Azure.Communication.CallAutomation.RecordingStateResult RecordingStateResult(string recordingId = null, Azure.Communication.CallAutomation.RecordingState? recordingState = default(Azure.Communication.CallAutomation.RecordingState?)) { throw null; }
        public static Azure.Communication.CallAutomation.RemoveParticipantsResult RemoveParticipantsResult(string operationContext = null) { throw null; }
        public static Azure.Communication.CallAutomation.ResultInformation ResultInformation(int? code = default(int?), int? subCode = default(int?), string message = null) { throw null; }
        public static Azure.Communication.CallAutomation.TransferCallToParticipantResult TransferCallToParticipantResult(string operationContext = null) { throw null; }
        public static Azure.Communication.CallAutomation.UnmuteParticipantsResponse UnmuteParticipantsResponse(string operationContext = null) { throw null; }
    }
    public partial class CallConnected : Azure.Communication.CallAutomation.CallAutomationEventBase
    {
        internal CallConnected() { }
        public static Azure.Communication.CallAutomation.CallConnected Deserialize(string content) { throw null; }
    }
    public partial class CallConnection
    {
        protected CallConnection() { }
        public virtual string CallConnectionId { get { throw null; } }
        public virtual Azure.Response<Azure.Communication.CallAutomation.AddParticipantsResult> AddParticipants(Azure.Communication.CallAutomation.AddParticipantsOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Communication.CallAutomation.AddParticipantsResult>> AddParticipantsAsync(Azure.Communication.CallAutomation.AddParticipantsOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Communication.CallAutomation.CallConnectionProperties> GetCallConnectionProperties(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Communication.CallAutomation.CallConnectionProperties>> GetCallConnectionPropertiesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Communication.CallAutomation.CallMedia GetCallMedia() { throw null; }
        public virtual Azure.Response<Azure.Communication.CallAutomation.CallParticipant> GetParticipant(string participantMri, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Communication.CallAutomation.CallParticipant>> GetParticipantAsync(string participantMri, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<System.Collections.Generic.IReadOnlyList<Azure.Communication.CallAutomation.CallParticipant>> GetParticipants(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<System.Collections.Generic.IReadOnlyList<Azure.Communication.CallAutomation.CallParticipant>>> GetParticipantsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response HangUp(Azure.Communication.CallAutomation.HangUpOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response HangUp(bool forEveryone, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> HangUpAsync(Azure.Communication.CallAutomation.HangUpOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> HangUpAsync(bool forEveryone, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Communication.CallAutomation.MuteParticipantsResponse> MuteParticipants(Azure.Communication.CallAutomation.MuteParticipantsOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Communication.CallAutomation.MuteParticipantsResponse> MuteParticipants(Azure.Communication.CommunicationIdentifier targetParticipant, string operationContext = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Communication.CallAutomation.MuteParticipantsResponse>> MuteParticipantsAsync(Azure.Communication.CallAutomation.MuteParticipantsOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Communication.CallAutomation.MuteParticipantsResponse>> MuteParticipantsAsync(Azure.Communication.CommunicationIdentifier targetParticipant, string operationContext = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Communication.CallAutomation.RemoveParticipantsResult> RemoveParticipants(Azure.Communication.CallAutomation.RemoveParticipantsOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Communication.CallAutomation.RemoveParticipantsResult> RemoveParticipants(System.Collections.Generic.IEnumerable<Azure.Communication.CommunicationIdentifier> participantsToRemove, string operationContext = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Communication.CallAutomation.RemoveParticipantsResult>> RemoveParticipantsAsync(Azure.Communication.CallAutomation.RemoveParticipantsOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Communication.CallAutomation.RemoveParticipantsResult>> RemoveParticipantsAsync(System.Collections.Generic.IEnumerable<Azure.Communication.CommunicationIdentifier> participantsToRemove, string operationContext = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Communication.CallAutomation.TransferCallToParticipantResult> TransferCallToParticipant(Azure.Communication.CallAutomation.TransferToParticipantOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Communication.CallAutomation.TransferCallToParticipantResult>> TransferCallToParticipantAsync(Azure.Communication.CallAutomation.TransferToParticipantOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Communication.CallAutomation.UnmuteParticipantsResponse> UnmuteParticipants(Azure.Communication.CallAutomation.UnmuteParticipantsOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Communication.CallAutomation.UnmuteParticipantsResponse> UnmuteParticipants(Azure.Communication.CommunicationIdentifier targetParticipant, string operationContext = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Communication.CallAutomation.UnmuteParticipantsResponse>> UnmuteParticipantsAsync(Azure.Communication.CallAutomation.UnmuteParticipantsOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Communication.CallAutomation.UnmuteParticipantsResponse>> UnmuteParticipantsAsync(Azure.Communication.CommunicationIdentifier targetParticipant, string operationContext = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class CallConnectionProperties
    {
        internal CallConnectionProperties() { }
        public System.Uri CallbackEndpoint { get { throw null; } }
        public string CallConnectionId { get { throw null; } }
        public Azure.Communication.CallAutomation.CallConnectionState CallConnectionState { get { throw null; } }
        public Azure.Communication.CallAutomation.CallSource CallSource { get { throw null; } }
        public string MediaSubscriptionId { get { throw null; } }
        public string ServerCallId { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Communication.CommunicationIdentifier> Targets { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct CallConnectionState : System.IEquatable<Azure.Communication.CallAutomation.CallConnectionState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public CallConnectionState(string value) { throw null; }
        public static Azure.Communication.CallAutomation.CallConnectionState Connected { get { throw null; } }
        public static Azure.Communication.CallAutomation.CallConnectionState Connecting { get { throw null; } }
        public static Azure.Communication.CallAutomation.CallConnectionState Disconnected { get { throw null; } }
        public static Azure.Communication.CallAutomation.CallConnectionState Disconnecting { get { throw null; } }
        public static Azure.Communication.CallAutomation.CallConnectionState TransferAccepted { get { throw null; } }
        public static Azure.Communication.CallAutomation.CallConnectionState Transferring { get { throw null; } }
        public static Azure.Communication.CallAutomation.CallConnectionState Unknown { get { throw null; } }
        public bool Equals(Azure.Communication.CallAutomation.CallConnectionState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Communication.CallAutomation.CallConnectionState left, Azure.Communication.CallAutomation.CallConnectionState right) { throw null; }
        public static implicit operator Azure.Communication.CallAutomation.CallConnectionState (string value) { throw null; }
        public static bool operator !=(Azure.Communication.CallAutomation.CallConnectionState left, Azure.Communication.CallAutomation.CallConnectionState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class CallDisconnected : Azure.Communication.CallAutomation.CallAutomationEventBase
    {
        internal CallDisconnected() { }
        public static Azure.Communication.CallAutomation.CallDisconnected Deserialize(string content) { throw null; }
    }
    public abstract partial class CallLocator : System.IEquatable<Azure.Communication.CallAutomation.CallLocator>
    {
        protected CallLocator() { }
        public string Id { get { throw null; } }
        public abstract bool Equals(Azure.Communication.CallAutomation.CallLocator other);
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
    }
    public partial class CallMedia
    {
        protected CallMedia() { }
        public virtual string CallConnectionId { get { throw null; } }
        public virtual Azure.Response<Azure.Communication.CallAutomation.CancelAllMediaOperationsResult> CancelAllMediaOperations(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Communication.CallAutomation.CancelAllMediaOperationsResult>> CancelAllMediaOperationsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Communication.CallAutomation.PlayResult> Play(Azure.Communication.CallAutomation.PlaySource playSource, System.Collections.Generic.IEnumerable<Azure.Communication.CommunicationIdentifier> playTo, Azure.Communication.CallAutomation.PlayOptions playOptions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Communication.CallAutomation.PlayResult>> PlayAsync(Azure.Communication.CallAutomation.PlaySource playSource, System.Collections.Generic.IEnumerable<Azure.Communication.CommunicationIdentifier> playTo, Azure.Communication.CallAutomation.PlayOptions playOptions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Communication.CallAutomation.PlayResult> PlayToAll(Azure.Communication.CallAutomation.PlaySource playSource, Azure.Communication.CallAutomation.PlayOptions playOptions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Communication.CallAutomation.PlayResult>> PlayToAllAsync(Azure.Communication.CallAutomation.PlaySource playSource, Azure.Communication.CallAutomation.PlayOptions playOptions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Communication.CallAutomation.StartRecognizingResult> StartRecognizing(Azure.Communication.CallAutomation.CallMediaRecognizeOptions recognizeOptions, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Communication.CallAutomation.StartRecognizingResult>> StartRecognizingAsync(Azure.Communication.CallAutomation.CallMediaRecognizeOptions recognizeOptions, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct CallMediaRecognitionType : System.IEquatable<Azure.Communication.CallAutomation.CallMediaRecognitionType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public CallMediaRecognitionType(string value) { throw null; }
        public static Azure.Communication.CallAutomation.CallMediaRecognitionType Choices { get { throw null; } }
        public static Azure.Communication.CallAutomation.CallMediaRecognitionType Dtmf { get { throw null; } }
        public bool Equals(Azure.Communication.CallAutomation.CallMediaRecognitionType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Communication.CallAutomation.CallMediaRecognitionType left, Azure.Communication.CallAutomation.CallMediaRecognitionType right) { throw null; }
        public static implicit operator Azure.Communication.CallAutomation.CallMediaRecognitionType (string value) { throw null; }
        public static bool operator !=(Azure.Communication.CallAutomation.CallMediaRecognitionType left, Azure.Communication.CallAutomation.CallMediaRecognitionType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class CallMediaRecognizeChoiceOptions : Azure.Communication.CallAutomation.CallMediaRecognizeOptions
    {
        public CallMediaRecognizeChoiceOptions(Azure.Communication.CommunicationIdentifier targetParticipant, System.Collections.Generic.List<Azure.Communication.CallAutomation.RecognizeChoice> recognizeChoices) : base (default(Azure.Communication.CallAutomation.RecognizeInputType), default(Azure.Communication.CommunicationIdentifier)) { }
        public System.Collections.Generic.IList<Azure.Communication.CallAutomation.RecognizeChoice> RecognizeChoices { get { throw null; } }
    }
    public partial class CallMediaRecognizeDtmfOptions : Azure.Communication.CallAutomation.CallMediaRecognizeOptions
    {
        public CallMediaRecognizeDtmfOptions(Azure.Communication.CommunicationIdentifier targetParticipant, int maxTonesToCollect) : base (default(Azure.Communication.CallAutomation.RecognizeInputType), default(Azure.Communication.CommunicationIdentifier)) { }
        public System.TimeSpan InterToneTimeout { get { throw null; } set { } }
        public int MaxTonesToCollect { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Communication.CallAutomation.DtmfTone> StopTones { get { throw null; } set { } }
    }
    public abstract partial class CallMediaRecognizeOptions
    {
        protected CallMediaRecognizeOptions(Azure.Communication.CallAutomation.RecognizeInputType inputType, Azure.Communication.CommunicationIdentifier targetParticipant) { }
        public System.TimeSpan InitialSilenceTimeout { get { throw null; } set { } }
        public Azure.Communication.CallAutomation.RecognizeInputType InputType { get { throw null; } }
        public bool InterruptCallMediaOperation { get { throw null; } set { } }
        public bool InterruptPrompt { get { throw null; } set { } }
        public string OperationContext { get { throw null; } set { } }
        public Azure.Communication.CallAutomation.PlaySource Prompt { get { throw null; } set { } }
        public Azure.Communication.CommunicationIdentifier TargetParticipant { get { throw null; } }
    }
    public partial class CallParticipant
    {
        internal CallParticipant() { }
        public Azure.Communication.CommunicationIdentifier Identifier { get { throw null; } }
        public bool IsMuted { get { throw null; } }
    }
    public partial class CallRecording
    {
        protected CallRecording() { }
        public virtual Azure.Response DeleteRecording(System.Uri recordingLocation, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteRecordingAsync(System.Uri recordingLocation, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<System.IO.Stream> DownloadStreaming(System.Uri sourceLocation, Azure.HttpRange range = default(Azure.HttpRange), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<System.IO.Stream>> DownloadStreamingAsync(System.Uri sourceLocation, Azure.HttpRange range = default(Azure.HttpRange), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response DownloadTo(System.Uri sourceLocation, System.IO.Stream destinationStream, Azure.Communication.CallAutomation.ContentTransferOptions transferOptions = default(Azure.Communication.CallAutomation.ContentTransferOptions), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response DownloadTo(System.Uri sourceLocation, string destinationPath, Azure.Communication.CallAutomation.ContentTransferOptions transferOptions = default(Azure.Communication.CallAutomation.ContentTransferOptions), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DownloadToAsync(System.Uri sourceLocation, System.IO.Stream destinationStream, Azure.Communication.CallAutomation.ContentTransferOptions transferOptions = default(Azure.Communication.CallAutomation.ContentTransferOptions), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DownloadToAsync(System.Uri sourceLocation, string destinationPath, Azure.Communication.CallAutomation.ContentTransferOptions transferOptions = default(Azure.Communication.CallAutomation.ContentTransferOptions), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Communication.CallAutomation.RecordingStateResult> GetRecordingState(string recordingId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Communication.CallAutomation.RecordingStateResult>> GetRecordingStateAsync(string recordingId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response PauseRecording(string recordingId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> PauseRecordingAsync(string recordingId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response ResumeRecording(string recordingId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> ResumeRecordingAsync(string recordingId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Communication.CallAutomation.RecordingStateResult> StartRecording(Azure.Communication.CallAutomation.StartRecordingOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Communication.CallAutomation.RecordingStateResult>> StartRecordingAsync(Azure.Communication.CallAutomation.StartRecordingOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response StopRecording(string recordingId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> StopRecordingAsync(string recordingId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct CallRejectReason : System.IEquatable<Azure.Communication.CallAutomation.CallRejectReason>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public CallRejectReason(string value) { throw null; }
        public static Azure.Communication.CallAutomation.CallRejectReason Busy { get { throw null; } }
        public static Azure.Communication.CallAutomation.CallRejectReason Forbidden { get { throw null; } }
        public static Azure.Communication.CallAutomation.CallRejectReason None { get { throw null; } }
        public bool Equals(Azure.Communication.CallAutomation.CallRejectReason other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Communication.CallAutomation.CallRejectReason left, Azure.Communication.CallAutomation.CallRejectReason right) { throw null; }
        public static implicit operator Azure.Communication.CallAutomation.CallRejectReason (string value) { throw null; }
        public static bool operator !=(Azure.Communication.CallAutomation.CallRejectReason left, Azure.Communication.CallAutomation.CallRejectReason right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class CallSource
    {
        public CallSource(Azure.Communication.CommunicationIdentifier identifier) { }
        public Azure.Communication.PhoneNumberIdentifier CallerId { get { throw null; } set { } }
        public string DisplayName { get { throw null; } set { } }
        public Azure.Communication.CommunicationIdentifier Identifier { get { throw null; } }
    }
    public partial class CallTransferAccepted : Azure.Communication.CallAutomation.CallAutomationEventBase
    {
        internal CallTransferAccepted() { }
        public static Azure.Communication.CallAutomation.CallTransferAccepted Deserialize(string content) { throw null; }
    }
    public partial class CallTransferFailed : Azure.Communication.CallAutomation.CallAutomationEventBase
    {
        internal CallTransferFailed() { }
        public static Azure.Communication.CallAutomation.CallTransferFailed Deserialize(string content) { throw null; }
    }
    public partial class CancelAllMediaOperationsEventResult : Azure.Communication.CallAutomation.EventResultBase
    {
        internal CancelAllMediaOperationsEventResult() { }
        public Azure.Communication.CallAutomation.PlayCanceled PlayCanceledSucessEvent { get { throw null; } }
        public Azure.Communication.CallAutomation.RecognizeCanceled RecognizeCanceledSucessEvent { get { throw null; } }
    }
    public partial class CancelAllMediaOperationsResult : Azure.Communication.CallAutomation.ResultWithWaitForEventBase
    {
        internal CancelAllMediaOperationsResult() { }
        public System.Threading.Tasks.Task<Azure.Communication.CallAutomation.CancelAllMediaOperationsEventResult> WaitForEvent(System.TimeSpan eventTimeout = default(System.TimeSpan)) { throw null; }
    }
    public partial class ChoiceResult : Azure.Communication.CallAutomation.RecognizeResult
    {
        internal ChoiceResult() { }
        public string Label { get { throw null; } }
        public string RecognizedPhrase { get { throw null; } }
    }
    public partial class CollectTonesResult : Azure.Communication.CallAutomation.RecognizeResult
    {
        internal CollectTonesResult() { }
        public System.Collections.Generic.IReadOnlyList<Azure.Communication.CallAutomation.DtmfTone> Tones { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public partial struct ContentTransferOptions : System.IEquatable<Azure.Communication.CallAutomation.ContentTransferOptions>
    {
        public long InitialTransferSize { get { throw null; } set { } }
        public int MaximumConcurrency { get { throw null; } set { } }
        public long MaximumTransferSize { get { throw null; } set { } }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public bool Equals(Azure.Communication.CallAutomation.ContentTransferOptions obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static bool operator ==(Azure.Communication.CallAutomation.ContentTransferOptions left, Azure.Communication.CallAutomation.ContentTransferOptions right) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static bool operator !=(Azure.Communication.CallAutomation.ContentTransferOptions left, Azure.Communication.CallAutomation.ContentTransferOptions right) { throw null; }
    }
    public partial class CreateCallEventResult : Azure.Communication.CallAutomation.EventResultBase
    {
        internal CreateCallEventResult() { }
        public Azure.Communication.CallAutomation.CallConnected SuccessEvent { get { throw null; } }
    }
    public partial class CreateCallOptions
    {
        public CreateCallOptions(Azure.Communication.CallAutomation.CallSource callSource, System.Collections.Generic.IEnumerable<Azure.Communication.CommunicationIdentifier> targets, System.Uri callbackUri) { }
        public System.Uri AzureCognitiveServicesEndpointUrl { get { throw null; } set { } }
        public System.Uri CallbackUri { get { throw null; } }
        public Azure.Communication.CallAutomation.CallSource CallSource { get { throw null; } }
        public Azure.Communication.CallAutomation.MediaStreamingOptions MediaStreamingOptions { get { throw null; } set { } }
        public string OperationContext { get { throw null; } set { } }
        public Azure.Communication.CallAutomation.RepeatabilityHeaders RepeatabilityHeaders { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<Azure.Communication.CommunicationIdentifier> Targets { get { throw null; } }
    }
    public partial class CreateCallResult : Azure.Communication.CallAutomation.ResultWithWaitForEventBase
    {
        internal CreateCallResult() { }
        public Azure.Communication.CallAutomation.CallConnection CallConnection { get { throw null; } }
        public Azure.Communication.CallAutomation.CallConnectionProperties CallConnectionProperties { get { throw null; } }
        public System.Threading.Tasks.Task<Azure.Communication.CallAutomation.CreateCallEventResult> WaitForEvent(System.TimeSpan eventTimeout = default(System.TimeSpan)) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DtmfTone : System.IEquatable<Azure.Communication.CallAutomation.DtmfTone>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DtmfTone(string value) { throw null; }
        public static Azure.Communication.CallAutomation.DtmfTone A { get { throw null; } }
        public static Azure.Communication.CallAutomation.DtmfTone Asterisk { get { throw null; } }
        public static Azure.Communication.CallAutomation.DtmfTone B { get { throw null; } }
        public static Azure.Communication.CallAutomation.DtmfTone C { get { throw null; } }
        public static Azure.Communication.CallAutomation.DtmfTone D { get { throw null; } }
        public static Azure.Communication.CallAutomation.DtmfTone Eight { get { throw null; } }
        public static Azure.Communication.CallAutomation.DtmfTone Five { get { throw null; } }
        public static Azure.Communication.CallAutomation.DtmfTone Four { get { throw null; } }
        public static Azure.Communication.CallAutomation.DtmfTone Nine { get { throw null; } }
        public static Azure.Communication.CallAutomation.DtmfTone One { get { throw null; } }
        public static Azure.Communication.CallAutomation.DtmfTone Pound { get { throw null; } }
        public static Azure.Communication.CallAutomation.DtmfTone Seven { get { throw null; } }
        public static Azure.Communication.CallAutomation.DtmfTone Six { get { throw null; } }
        public static Azure.Communication.CallAutomation.DtmfTone Three { get { throw null; } }
        public static Azure.Communication.CallAutomation.DtmfTone Two { get { throw null; } }
        public static Azure.Communication.CallAutomation.DtmfTone Zero { get { throw null; } }
        public bool Equals(Azure.Communication.CallAutomation.DtmfTone other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Communication.CallAutomation.DtmfTone left, Azure.Communication.CallAutomation.DtmfTone right) { throw null; }
        public static implicit operator Azure.Communication.CallAutomation.DtmfTone (string value) { throw null; }
        public static bool operator !=(Azure.Communication.CallAutomation.DtmfTone left, Azure.Communication.CallAutomation.DtmfTone right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class EventProcessor
    {
        internal EventProcessor() { }
        public void AttachOngoingEventProcessor<TEvent>(string callConnectionId, System.Action<TEvent> eventProcessor) where TEvent : Azure.Communication.CallAutomation.CallAutomationEventBase { }
        public void DetachOngoingEventProcessor<TEvent>(string callConnectionId) where TEvent : Azure.Communication.CallAutomation.CallAutomationEventBase { }
        public void ProcessEvents(System.Collections.Generic.IEnumerable<Azure.Communication.CallAutomation.CallAutomationEventBase> events) { }
        public void ProcessEvents(System.Collections.Generic.IEnumerable<Azure.Messaging.CloudEvent> events) { }
        public System.Threading.Tasks.Task<Azure.Communication.CallAutomation.CallAutomationEventBase> WaitForSingleEvent(System.Func<Azure.Communication.CallAutomation.CallAutomationEventBase, bool> predicate, System.TimeSpan eventTimeout = default(System.TimeSpan)) { throw null; }
        public System.Threading.Tasks.Task<TEvent> WaitForSingleEvent<TEvent>(string connectionId = null, string operationContext = null, System.TimeSpan eventTimeout = default(System.TimeSpan)) where TEvent : Azure.Communication.CallAutomation.CallAutomationEventBase { throw null; }
    }
    public partial class EventProcessorOptions
    {
        public EventProcessorOptions() { }
        public System.TimeSpan EventTimeout { get { throw null; } set { } }
    }
    public abstract partial class EventResultBase
    {
        protected EventResultBase() { }
        public bool IsSuccessEvent { get { throw null; } }
    }
    public partial class FileSource : Azure.Communication.CallAutomation.PlaySource
    {
        public FileSource(System.Uri fileUri) { }
        public System.Uri FileUri { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct GenderType : System.IEquatable<Azure.Communication.CallAutomation.GenderType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public GenderType(string value) { throw null; }
        public static Azure.Communication.CallAutomation.GenderType Female { get { throw null; } }
        public static Azure.Communication.CallAutomation.GenderType Male { get { throw null; } }
        public bool Equals(Azure.Communication.CallAutomation.GenderType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Communication.CallAutomation.GenderType left, Azure.Communication.CallAutomation.GenderType right) { throw null; }
        public static implicit operator Azure.Communication.CallAutomation.GenderType (string value) { throw null; }
        public static bool operator !=(Azure.Communication.CallAutomation.GenderType left, Azure.Communication.CallAutomation.GenderType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class GroupCallLocator : Azure.Communication.CallAutomation.CallLocator
    {
        public GroupCallLocator(string id) { }
        public override bool Equals(Azure.Communication.CallAutomation.CallLocator other) { throw null; }
        public override int GetHashCode() { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class HangUpOptions
    {
        public HangUpOptions(bool forEveryone) { }
        public bool ForEveryone { get { throw null; } }
        public Azure.Communication.CallAutomation.RepeatabilityHeaders RepeatabilityHeaders { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MediaStreamingAudioChannel : System.IEquatable<Azure.Communication.CallAutomation.MediaStreamingAudioChannel>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MediaStreamingAudioChannel(string value) { throw null; }
        public static Azure.Communication.CallAutomation.MediaStreamingAudioChannel Mixed { get { throw null; } }
        public static Azure.Communication.CallAutomation.MediaStreamingAudioChannel Unmixed { get { throw null; } }
        public bool Equals(Azure.Communication.CallAutomation.MediaStreamingAudioChannel other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Communication.CallAutomation.MediaStreamingAudioChannel left, Azure.Communication.CallAutomation.MediaStreamingAudioChannel right) { throw null; }
        public static implicit operator Azure.Communication.CallAutomation.MediaStreamingAudioChannel (string value) { throw null; }
        public static bool operator !=(Azure.Communication.CallAutomation.MediaStreamingAudioChannel left, Azure.Communication.CallAutomation.MediaStreamingAudioChannel right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class MediaStreamingAudioData : Azure.Communication.CallAutomation.MediaStreamingPackageBase
    {
        internal MediaStreamingAudioData() { }
        public string Data { get { throw null; } }
        public bool IsSilent { get { throw null; } }
        public Azure.Communication.CommunicationIdentifier Participant { get { throw null; } }
        public System.DateTime Timestamp { get { throw null; } }
    }
    public partial class MediaStreamingConfiguration
    {
        public MediaStreamingConfiguration(System.Uri transportUrl, Azure.Communication.CallAutomation.MediaStreamingTransport transportType, Azure.Communication.CallAutomation.MediaStreamingContent contentType, Azure.Communication.CallAutomation.MediaStreamingAudioChannel audioChannelType) { }
        public Azure.Communication.CallAutomation.MediaStreamingAudioChannel AudioChannelType { get { throw null; } }
        public Azure.Communication.CallAutomation.MediaStreamingContent ContentType { get { throw null; } }
        public Azure.Communication.CallAutomation.MediaStreamingTransport TransportType { get { throw null; } }
        public System.Uri TransportUrl { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MediaStreamingContent : System.IEquatable<Azure.Communication.CallAutomation.MediaStreamingContent>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MediaStreamingContent(string value) { throw null; }
        public static Azure.Communication.CallAutomation.MediaStreamingContent Audio { get { throw null; } }
        public bool Equals(Azure.Communication.CallAutomation.MediaStreamingContent other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Communication.CallAutomation.MediaStreamingContent left, Azure.Communication.CallAutomation.MediaStreamingContent right) { throw null; }
        public static implicit operator Azure.Communication.CallAutomation.MediaStreamingContent (string value) { throw null; }
        public static bool operator !=(Azure.Communication.CallAutomation.MediaStreamingContent left, Azure.Communication.CallAutomation.MediaStreamingContent right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class MediaStreamingMetadata : Azure.Communication.CallAutomation.MediaStreamingPackageBase
    {
        public MediaStreamingMetadata() { }
        [System.Text.Json.Serialization.JsonPropertyNameAttribute("channels")]
        public int Channels { get { throw null; } set { } }
        [System.Text.Json.Serialization.JsonPropertyNameAttribute("encoding")]
        public string Encoding { get { throw null; } set { } }
        [System.Text.Json.Serialization.JsonPropertyNameAttribute("length")]
        public int Length { get { throw null; } set { } }
        [System.Text.Json.Serialization.JsonPropertyNameAttribute("subscriptionId")]
        public string MediaSubscriptionId { get { throw null; } set { } }
        [System.Text.Json.Serialization.JsonPropertyNameAttribute("sampleRate")]
        public int SampleRate { get { throw null; } set { } }
    }
    public partial class MediaStreamingOptions
    {
        public MediaStreamingOptions(System.Uri transportUri, Azure.Communication.CallAutomation.MediaStreamingTransport transportType, Azure.Communication.CallAutomation.MediaStreamingContent contentType, Azure.Communication.CallAutomation.MediaStreamingAudioChannel audioChannelType) { }
        public Azure.Communication.CallAutomation.MediaStreamingAudioChannel MediaStreamingAudioChannel { get { throw null; } }
        public Azure.Communication.CallAutomation.MediaStreamingContent MediaStreamingContent { get { throw null; } }
        public Azure.Communication.CallAutomation.MediaStreamingTransport MediaStreamingTransport { get { throw null; } }
        public System.Uri TransportUri { get { throw null; } }
    }
    public abstract partial class MediaStreamingPackageBase
    {
        protected MediaStreamingPackageBase() { }
    }
    public static partial class MediaStreamingPackageParser
    {
        public static Azure.Communication.CallAutomation.MediaStreamingPackageBase Parse(System.BinaryData json) { throw null; }
        public static Azure.Communication.CallAutomation.MediaStreamingPackageBase Parse(byte[] receivedBytes) { throw null; }
        public static Azure.Communication.CallAutomation.MediaStreamingPackageBase Parse(string stringJson) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MediaStreamingTransport : System.IEquatable<Azure.Communication.CallAutomation.MediaStreamingTransport>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MediaStreamingTransport(string value) { throw null; }
        public static Azure.Communication.CallAutomation.MediaStreamingTransport Websocket { get { throw null; } }
        public bool Equals(Azure.Communication.CallAutomation.MediaStreamingTransport other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Communication.CallAutomation.MediaStreamingTransport left, Azure.Communication.CallAutomation.MediaStreamingTransport right) { throw null; }
        public static implicit operator Azure.Communication.CallAutomation.MediaStreamingTransport (string value) { throw null; }
        public static bool operator !=(Azure.Communication.CallAutomation.MediaStreamingTransport left, Azure.Communication.CallAutomation.MediaStreamingTransport right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class MuteParticipantsOptions
    {
        public MuteParticipantsOptions(System.Collections.Generic.IEnumerable<Azure.Communication.CommunicationIdentifier> targetParticipants) { }
        public string OperationContext { get { throw null; } set { } }
        public Azure.Communication.CallAutomation.RepeatabilityHeaders RepeatabilityHeaders { get { throw null; } set { } }
        public System.Collections.Generic.IEnumerable<Azure.Communication.CommunicationIdentifier> TargetParticipants { get { throw null; } }
    }
    public partial class MuteParticipantsResponse
    {
        internal MuteParticipantsResponse() { }
        public string OperationContext { get { throw null; } }
    }
    public partial class ParticipantsUpdated : Azure.Communication.CallAutomation.CallAutomationEventBase
    {
        internal ParticipantsUpdated() { }
        public System.Collections.Generic.IReadOnlyList<Azure.Communication.CallAutomation.CallParticipant> Participants { get { throw null; } }
        public static Azure.Communication.CallAutomation.ParticipantsUpdated Deserialize(string content) { throw null; }
    }
    public partial class PlayCanceled : Azure.Communication.CallAutomation.CallAutomationEventBase
    {
        internal PlayCanceled() { }
        public static Azure.Communication.CallAutomation.PlayCanceled Deserialize(string content) { throw null; }
    }
    public partial class PlayCompleted : Azure.Communication.CallAutomation.CallAutomationEventWithReasonCodeName
    {
        internal PlayCompleted() { }
        public static Azure.Communication.CallAutomation.PlayCompleted Deserialize(string content) { throw null; }
    }
    public partial class PlayEventResult : Azure.Communication.CallAutomation.EventResultBase
    {
        internal PlayEventResult() { }
        public Azure.Communication.CallAutomation.PlayFailed FailureEvent { get { throw null; } }
        public Azure.Communication.CallAutomation.PlayCompleted SuccessEvent { get { throw null; } }
    }
    public partial class PlayFailed : Azure.Communication.CallAutomation.CallAutomationEventWithReasonCodeName
    {
        internal PlayFailed() { }
        public static Azure.Communication.CallAutomation.PlayFailed Deserialize(string content) { throw null; }
    }
    public partial class PlayOptions
    {
        public PlayOptions() { }
        public bool Loop { get { throw null; } set { } }
        public string OperationContext { get { throw null; } set { } }
    }
    public partial class PlayResult : Azure.Communication.CallAutomation.ResultWithWaitForEventBase
    {
        internal PlayResult() { }
        public System.Threading.Tasks.Task<Azure.Communication.CallAutomation.PlayEventResult> WaitForEvent(System.TimeSpan eventTimeout = default(System.TimeSpan)) { throw null; }
    }
    public abstract partial class PlaySource
    {
        protected PlaySource() { }
        public string PlaySourceId { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ReasonCode : System.IEquatable<Azure.Communication.CallAutomation.ReasonCode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ReasonCode(string value) { throw null; }
        public static Azure.Communication.CallAutomation.ReasonCode CompletedSuccessfully { get { throw null; } }
        public static Azure.Communication.CallAutomation.ReasonCode PlayDownloadFailed { get { throw null; } }
        public static Azure.Communication.CallAutomation.ReasonCode PlayInvalidFileFormat { get { throw null; } }
        public static Azure.Communication.CallAutomation.ReasonCode RecognizeDtmfOptionMatched { get { throw null; } }
        public static Azure.Communication.CallAutomation.ReasonCode RecognizeIncorrectToneDetected { get { throw null; } }
        public static Azure.Communication.CallAutomation.ReasonCode RecognizeInitialSilenceTimedOut { get { throw null; } }
        public static Azure.Communication.CallAutomation.ReasonCode RecognizeInterDigitTimedOut { get { throw null; } }
        public static Azure.Communication.CallAutomation.ReasonCode RecognizeMaxDigitsReceived { get { throw null; } }
        public static Azure.Communication.CallAutomation.ReasonCode RecognizePlayPromptFailed { get { throw null; } }
        public static Azure.Communication.CallAutomation.ReasonCode RecognizeSpeechOptionMatched { get { throw null; } }
        public static Azure.Communication.CallAutomation.ReasonCode RecognizeSpeechOptionNotMatched { get { throw null; } }
        public static Azure.Communication.CallAutomation.ReasonCode RecognizeStopToneDetected { get { throw null; } }
        public static Azure.Communication.CallAutomation.ReasonCode UnspecifiedError { get { throw null; } }
        public bool Equals(Azure.Communication.CallAutomation.ReasonCode other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Communication.CallAutomation.ReasonCode left, Azure.Communication.CallAutomation.ReasonCode right) { throw null; }
        public static implicit operator Azure.Communication.CallAutomation.ReasonCode (string value) { throw null; }
        public static bool operator !=(Azure.Communication.CallAutomation.ReasonCode left, Azure.Communication.CallAutomation.ReasonCode right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class RecognizeCanceled : Azure.Communication.CallAutomation.CallAutomationEventBase
    {
        internal RecognizeCanceled() { }
        public static Azure.Communication.CallAutomation.RecognizeCanceled Deserialize(string content) { throw null; }
    }
    public partial class RecognizeChoice
    {
        public RecognizeChoice(string label, System.Collections.Generic.IEnumerable<string> phrases) { }
        public string Label { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Phrases { get { throw null; } }
        public Azure.Communication.CallAutomation.DtmfTone? Tone { get { throw null; } set { } }
    }
    public partial class RecognizeCompleted : Azure.Communication.CallAutomation.CallAutomationEventBase
    {
        internal RecognizeCompleted() { }
        public Azure.Communication.CallAutomation.RecognizeResult RecognizeResult { get { throw null; } }
        public static Azure.Communication.CallAutomation.RecognizeCompleted Deserialize(string content) { throw null; }
    }
    public partial class RecognizeFailed : Azure.Communication.CallAutomation.CallAutomationEventWithReasonCodeName
    {
        internal RecognizeFailed() { }
        public static Azure.Communication.CallAutomation.RecognizeFailed Deserialize(string content) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RecognizeInputType : System.IEquatable<Azure.Communication.CallAutomation.RecognizeInputType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RecognizeInputType(string value) { throw null; }
        public static Azure.Communication.CallAutomation.RecognizeInputType Choices { get { throw null; } }
        public static Azure.Communication.CallAutomation.RecognizeInputType Dtmf { get { throw null; } }
        public bool Equals(Azure.Communication.CallAutomation.RecognizeInputType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Communication.CallAutomation.RecognizeInputType left, Azure.Communication.CallAutomation.RecognizeInputType right) { throw null; }
        public static implicit operator Azure.Communication.CallAutomation.RecognizeInputType (string value) { throw null; }
        public static bool operator !=(Azure.Communication.CallAutomation.RecognizeInputType left, Azure.Communication.CallAutomation.RecognizeInputType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public abstract partial class RecognizeResult
    {
        protected RecognizeResult() { }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RecordingChannel : System.IEquatable<Azure.Communication.CallAutomation.RecordingChannel>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RecordingChannel(string value) { throw null; }
        public static Azure.Communication.CallAutomation.RecordingChannel Mixed { get { throw null; } }
        public static Azure.Communication.CallAutomation.RecordingChannel Unmixed { get { throw null; } }
        public bool Equals(Azure.Communication.CallAutomation.RecordingChannel other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Communication.CallAutomation.RecordingChannel left, Azure.Communication.CallAutomation.RecordingChannel right) { throw null; }
        public static implicit operator Azure.Communication.CallAutomation.RecordingChannel (string value) { throw null; }
        public static bool operator !=(Azure.Communication.CallAutomation.RecordingChannel left, Azure.Communication.CallAutomation.RecordingChannel right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RecordingContent : System.IEquatable<Azure.Communication.CallAutomation.RecordingContent>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RecordingContent(string value) { throw null; }
        public static Azure.Communication.CallAutomation.RecordingContent Audio { get { throw null; } }
        public static Azure.Communication.CallAutomation.RecordingContent AudioVideo { get { throw null; } }
        public bool Equals(Azure.Communication.CallAutomation.RecordingContent other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Communication.CallAutomation.RecordingContent left, Azure.Communication.CallAutomation.RecordingContent right) { throw null; }
        public static implicit operator Azure.Communication.CallAutomation.RecordingContent (string value) { throw null; }
        public static bool operator !=(Azure.Communication.CallAutomation.RecordingContent left, Azure.Communication.CallAutomation.RecordingContent right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RecordingFormat : System.IEquatable<Azure.Communication.CallAutomation.RecordingFormat>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RecordingFormat(string value) { throw null; }
        public static Azure.Communication.CallAutomation.RecordingFormat Mp3 { get { throw null; } }
        public static Azure.Communication.CallAutomation.RecordingFormat Mp4 { get { throw null; } }
        public static Azure.Communication.CallAutomation.RecordingFormat Wav { get { throw null; } }
        public bool Equals(Azure.Communication.CallAutomation.RecordingFormat other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Communication.CallAutomation.RecordingFormat left, Azure.Communication.CallAutomation.RecordingFormat right) { throw null; }
        public static implicit operator Azure.Communication.CallAutomation.RecordingFormat (string value) { throw null; }
        public static bool operator !=(Azure.Communication.CallAutomation.RecordingFormat left, Azure.Communication.CallAutomation.RecordingFormat right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RecordingState : System.IEquatable<Azure.Communication.CallAutomation.RecordingState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RecordingState(string value) { throw null; }
        public static Azure.Communication.CallAutomation.RecordingState Active { get { throw null; } }
        public static Azure.Communication.CallAutomation.RecordingState Inactive { get { throw null; } }
        public bool Equals(Azure.Communication.CallAutomation.RecordingState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Communication.CallAutomation.RecordingState left, Azure.Communication.CallAutomation.RecordingState right) { throw null; }
        public static implicit operator Azure.Communication.CallAutomation.RecordingState (string value) { throw null; }
        public static bool operator !=(Azure.Communication.CallAutomation.RecordingState left, Azure.Communication.CallAutomation.RecordingState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class RecordingStateChanged : Azure.Communication.CallAutomation.CallAutomationEventBase
    {
        internal RecordingStateChanged() { }
        public string RecordingId { get { throw null; } }
        public System.DateTimeOffset? StartDateTime { get { throw null; } }
        public Azure.Communication.CallAutomation.RecordingState State { get { throw null; } set { } }
        public static Azure.Communication.CallAutomation.RecordingStateChanged Deserialize(string content) { throw null; }
    }
    public partial class RecordingStateResult
    {
        internal RecordingStateResult() { }
        public string RecordingId { get { throw null; } }
        public Azure.Communication.CallAutomation.RecordingState? RecordingState { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RecordingStorageType : System.IEquatable<Azure.Communication.CallAutomation.RecordingStorageType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RecordingStorageType(string value) { throw null; }
        public static Azure.Communication.CallAutomation.RecordingStorageType Acs { get { throw null; } }
        public static Azure.Communication.CallAutomation.RecordingStorageType BlobStorage { get { throw null; } }
        public bool Equals(Azure.Communication.CallAutomation.RecordingStorageType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Communication.CallAutomation.RecordingStorageType left, Azure.Communication.CallAutomation.RecordingStorageType right) { throw null; }
        public static implicit operator Azure.Communication.CallAutomation.RecordingStorageType (string value) { throw null; }
        public static bool operator !=(Azure.Communication.CallAutomation.RecordingStorageType left, Azure.Communication.CallAutomation.RecordingStorageType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class RedirectCallOptions
    {
        public RedirectCallOptions(string incomingCallContext, Azure.Communication.CommunicationIdentifier target) { }
        public string IncomingCallContext { get { throw null; } }
        public Azure.Communication.CallAutomation.RepeatabilityHeaders RepeatabilityHeaders { get { throw null; } set { } }
        public Azure.Communication.CommunicationIdentifier Target { get { throw null; } }
    }
    public partial class RejectCallOptions
    {
        public RejectCallOptions(string incomingCallContext) { }
        public Azure.Communication.CallAutomation.CallRejectReason CallRejectReason { get { throw null; } set { } }
        public string IncomingCallContext { get { throw null; } }
        public Azure.Communication.CallAutomation.RepeatabilityHeaders RepeatabilityHeaders { get { throw null; } set { } }
    }
    public partial class RemoveParticipantsOptions
    {
        public RemoveParticipantsOptions(System.Collections.Generic.IEnumerable<Azure.Communication.CommunicationIdentifier> participantsToRemove) { }
        public string OperationContext { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<Azure.Communication.CommunicationIdentifier> ParticipantsToRemove { get { throw null; } }
        public Azure.Communication.CallAutomation.RepeatabilityHeaders RepeatabilityHeaders { get { throw null; } set { } }
    }
    public partial class RemoveParticipantsResult
    {
        internal RemoveParticipantsResult() { }
        public string OperationContext { get { throw null; } }
    }
    public partial class RepeatabilityHeaders
    {
        public RepeatabilityHeaders() { }
        public RepeatabilityHeaders(System.Guid repeatabilityRequestId, System.DateTimeOffset repeatabilityFirstSent) { }
        public System.DateTimeOffset RepeatabilityFirstSent { get { throw null; } }
        public System.Guid RepeatabilityRequestId { get { throw null; } }
    }
    public partial class ResultInformation
    {
        internal ResultInformation() { }
        public int? Code { get { throw null; } }
        public string Message { get { throw null; } }
        public int? SubCode { get { throw null; } }
    }
    public abstract partial class ResultWithWaitForEventBase
    {
        protected ResultWithWaitForEventBase() { }
    }
    public partial class ServerCallLocator : Azure.Communication.CallAutomation.CallLocator
    {
        public ServerCallLocator(string id) { }
        public override bool Equals(Azure.Communication.CallAutomation.CallLocator other) { throw null; }
        public override int GetHashCode() { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class StartRecognizingEventResult : Azure.Communication.CallAutomation.EventResultBase
    {
        internal StartRecognizingEventResult() { }
        public Azure.Communication.CallAutomation.RecognizeFailed FailureEvent { get { throw null; } }
        public Azure.Communication.CallAutomation.RecognizeCompleted SuccessEvent { get { throw null; } }
    }
    public partial class StartRecognizingResult : Azure.Communication.CallAutomation.ResultWithWaitForEventBase
    {
        internal StartRecognizingResult() { }
        public System.Threading.Tasks.Task<Azure.Communication.CallAutomation.StartRecognizingEventResult> WaitForEvent(System.TimeSpan eventTimeout = default(System.TimeSpan)) { throw null; }
    }
    public partial class StartRecordingOptions
    {
        public StartRecordingOptions(Azure.Communication.CallAutomation.CallLocator callLocator) { }
        public System.Collections.Generic.IList<Azure.Communication.CommunicationIdentifier> AudioChannelParticipantOrdering { get { throw null; } }
        public System.Uri ExternalStorageLocation { get { throw null; } set { } }
        public Azure.Communication.CallAutomation.RecordingChannel RecordingChannel { get { throw null; } set { } }
        public Azure.Communication.CallAutomation.RecordingContent RecordingContent { get { throw null; } set { } }
        public Azure.Communication.CallAutomation.RecordingFormat RecordingFormat { get { throw null; } set { } }
        public System.Uri RecordingStateCallbackEndpoint { get { throw null; } set { } }
        public Azure.Communication.CallAutomation.RecordingStorageType? RecordingStorageType { get { throw null; } set { } }
        public Azure.Communication.CallAutomation.RepeatabilityHeaders RepeatabilityHeaders { get { throw null; } set { } }
    }
    public partial class TextSource : Azure.Communication.CallAutomation.PlaySource
    {
        public TextSource(string text) { }
        public TextSource(string text, System.Globalization.CultureInfo sourceLocale, Azure.Communication.CallAutomation.GenderType gender) { }
        public TextSource(string text, string voiceName) { }
        public string SourceLocale { get { throw null; } set { } }
        public string Text { get { throw null; } }
        public Azure.Communication.CallAutomation.GenderType? VoiceGender { get { throw null; } set { } }
        public string VoiceName { get { throw null; } set { } }
    }
    public partial class TransferCallToParticipantEventResult : Azure.Communication.CallAutomation.EventResultBase
    {
        internal TransferCallToParticipantEventResult() { }
        public Azure.Communication.CallAutomation.CallTransferFailed FailureEvent { get { throw null; } }
        public Azure.Communication.CallAutomation.CallTransferAccepted SuccessEvent { get { throw null; } }
    }
    public partial class TransferCallToParticipantResult : Azure.Communication.CallAutomation.ResultWithWaitForEventBase
    {
        internal TransferCallToParticipantResult() { }
        public string OperationContext { get { throw null; } }
        public System.Threading.Tasks.Task<Azure.Communication.CallAutomation.TransferCallToParticipantEventResult> WaitForEvent(System.TimeSpan eventTimeout = default(System.TimeSpan)) { throw null; }
    }
    public partial class TransferToParticipantOptions
    {
        public TransferToParticipantOptions(Azure.Communication.CommunicationIdentifier targetParticipant) { }
        public string OperationContext { get { throw null; } set { } }
        public Azure.Communication.CallAutomation.RepeatabilityHeaders RepeatabilityHeaders { get { throw null; } set { } }
        public Azure.Communication.PhoneNumberIdentifier SourceCallerId { get { throw null; } set { } }
        public Azure.Communication.CommunicationIdentifier TargetParticipant { get { throw null; } }
        public string UserToUserInformation { get { throw null; } set { } }
    }
    public partial class UnmuteParticipantsOptions
    {
        public UnmuteParticipantsOptions(System.Collections.Generic.IEnumerable<Azure.Communication.CommunicationIdentifier> targetParticipant) { }
        public string OperationContext { get { throw null; } set { } }
        public Azure.Communication.CallAutomation.RepeatabilityHeaders RepeatabilityHeaders { get { throw null; } set { } }
        public System.Collections.Generic.IEnumerable<Azure.Communication.CommunicationIdentifier> TargetParticipants { get { throw null; } }
    }
    public partial class UnmuteParticipantsResponse
    {
        internal UnmuteParticipantsResponse() { }
        public string OperationContext { get { throw null; } }
    }
}
