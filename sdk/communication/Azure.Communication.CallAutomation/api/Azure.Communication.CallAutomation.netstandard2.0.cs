namespace Azure.Communication.CallAutomation
{
    public partial class AddParticipantsFailed : Azure.Communication.CallAutomation.CallAutomationEventBase
    {
        internal AddParticipantsFailed() { }
        public string EventSource { get { throw null; } }
        public string OperationContext { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Communication.CommunicationIdentifier> Participants { get { throw null; } }
        public string PublicEventType { get { throw null; } }
        public Azure.Communication.CallAutomation.ResultInformation ResultInformation { get { throw null; } }
        public string Version { get { throw null; } }
        public static Azure.Communication.CallAutomation.AddParticipantsFailed Deserialize(string content) { throw null; }
    }
    public partial class AddParticipantsOptions : Azure.Communication.CallAutomation.RepeatabilityHeaders
    {
        public AddParticipantsOptions(System.Collections.Generic.IEnumerable<Azure.Communication.CommunicationIdentifier> participantsToAdd) { }
        public int? InvitationTimeoutInSeconds { get { throw null; } set { } }
        public string OperationContext { get { throw null; } set { } }
        public System.Collections.Generic.IEnumerable<Azure.Communication.CommunicationIdentifier> ParticipantsToAdd { get { throw null; } }
        public Azure.Communication.PhoneNumberIdentifier SourceCallerId { get { throw null; } set { } }
    }
    public partial class AddParticipantsResult
    {
        internal AddParticipantsResult() { }
        public string OperationContext { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Communication.CallAutomation.CallParticipant> Participants { get { throw null; } }
    }
    public partial class AddParticipantsSucceeded : Azure.Communication.CallAutomation.CallAutomationEventBase
    {
        internal AddParticipantsSucceeded() { }
        public string EventSource { get { throw null; } }
        public string OperationContext { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Communication.CommunicationIdentifier> Participants { get { throw null; } }
        public string PublicEventType { get { throw null; } }
        public Azure.Communication.CallAutomation.ResultInformation ResultInformation { get { throw null; } }
        public string Version { get { throw null; } }
        public static Azure.Communication.CallAutomation.AddParticipantsSucceeded Deserialize(string content) { throw null; }
    }
    public partial class AnswerCallOptions : Azure.Communication.CallAutomation.RepeatabilityHeaders
    {
        public AnswerCallOptions(string incomingCallContext, System.Uri callbackUri) { }
        public System.Uri CallbackUri { get { throw null; } }
        public string IncomingCallContext { get { throw null; } }
        public Azure.Communication.CallAutomation.MediaStreamingOptions MediaStreamingOptions { get { throw null; } set { } }
    }
    public partial class AnswerCallResult
    {
        internal AnswerCallResult() { }
        public Azure.Communication.CallAutomation.CallConnection CallConnection { get { throw null; } }
        public Azure.Communication.CallAutomation.CallConnectionProperties CallConnectionProperties { get { throw null; } }
    }
    public partial class CallAutomationClient
    {
        protected CallAutomationClient() { }
        public CallAutomationClient(string connectionString) { }
        public CallAutomationClient(string connectionString, Azure.Communication.CallAutomation.CallAutomationClientOptions options) { }
        public CallAutomationClient(System.Uri endpoint, Azure.Core.TokenCredential credential, Azure.Communication.CallAutomation.CallAutomationClientOptions options = null) { }
        public CallAutomationClient(System.Uri pmaEndpoint, string connectionString, Azure.Communication.CallAutomation.CallAutomationClientOptions options = null) { }
        public virtual Azure.Response<Azure.Communication.CallAutomation.AnswerCallResult> AnswerCall(Azure.Communication.CallAutomation.AnswerCallOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Communication.CallAutomation.AnswerCallResult> AnswerCall(string incomingCallContext, System.Uri callbackUri, System.Guid? repeatabilityRequestId = default(System.Guid?), System.DateTimeOffset? repeatabilityFirstSent = default(System.DateTimeOffset?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Communication.CallAutomation.AnswerCallResult>> AnswerCallAsync(Azure.Communication.CallAutomation.AnswerCallOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Communication.CallAutomation.AnswerCallResult>> AnswerCallAsync(string incomingCallContext, System.Uri callbackUri, System.Guid? repeatabilityRequestId = default(System.Guid?), System.DateTimeOffset? repeatabilityFirstSent = default(System.DateTimeOffset?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Communication.CallAutomation.CreateCallResult> CreateCall(Azure.Communication.CallAutomation.CreateCallOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Communication.CallAutomation.CreateCallResult>> CreateCallAsync(Azure.Communication.CallAutomation.CreateCallOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Communication.CallAutomation.CallConnection GetCallConnection(string callConnectionId) { throw null; }
        public virtual Azure.Communication.CallAutomation.CallRecording GetCallRecording() { throw null; }
        public virtual Azure.Response RedirectCall(string incomingCallContext, Azure.Communication.CommunicationIdentifier target, System.Guid? repeatabilityRequestId = default(System.Guid?), System.DateTimeOffset? repeatabilityFirstSent = default(System.DateTimeOffset?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> RedirectCallAsync(string incomingCallContext, Azure.Communication.CommunicationIdentifier target, System.Guid? repeatabilityRequestId = default(System.Guid?), System.DateTimeOffset? repeatabilityFirstSent = default(System.DateTimeOffset?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response RejectCall(string incomingCallContext, Azure.Communication.CallAutomation.CallRejectReason callRejectReason, System.Guid? repeatabilityRequestId = default(System.Guid?), System.DateTimeOffset? repeatabilityFirstSent = default(System.DateTimeOffset?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> RejectCallAsync(string incomingCallContext, Azure.Communication.CallAutomation.CallRejectReason callRejectReason, System.Guid? repeatabilityRequestId = default(System.Guid?), System.DateTimeOffset? repeatabilityFirstSent = default(System.DateTimeOffset?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class CallAutomationClientOptions : Azure.Core.ClientOptions
    {
        public CallAutomationClientOptions(Azure.Communication.CallAutomation.CallAutomationClientOptions.ServiceVersion version = Azure.Communication.CallAutomation.CallAutomationClientOptions.ServiceVersion.V2022_04_07_Preview) { }
        public enum ServiceVersion
        {
            V2022_04_07_Preview = 1,
        }
    }
    public static partial class CallAutomationErrorMessages
    {
        public const string InvalidRepeatabilityHeadersMessage = "Invalid RepeatabilityHeaders set. Either set both RepeatabilityRequestId and RepeatabilityFirstSent or neither.";
    }
    public abstract partial class CallAutomationEventBase
    {
        protected CallAutomationEventBase() { }
        public string CallConnectionId { get { throw null; } }
        public string CorrelationId { get { throw null; } }
        public string ServerCallId { get { throw null; } }
    }
    public static partial class CallAutomationEventParser
    {
        public const string EventPrefix = "Microsoft.Communication.";
        public static Azure.Communication.CallAutomation.CallAutomationEventBase Parse(Azure.Messaging.CloudEvent cloudEvent) { throw null; }
        public static Azure.Communication.CallAutomation.CallAutomationEventBase Parse(System.BinaryData json) { throw null; }
        public static Azure.Communication.CallAutomation.CallAutomationEventBase Parse(string eventData, string eventType) { throw null; }
        public static Azure.Communication.CallAutomation.CallAutomationEventBase[] ParseMany(Azure.Messaging.CloudEvent[] cloudEvents) { throw null; }
        public static Azure.Communication.CallAutomation.CallAutomationEventBase[] ParseMany(System.BinaryData json) { throw null; }
    }
    public static partial class CallAutomationModelFactory
    {
        public static Azure.Communication.CallAutomation.AddParticipantsFailed AddParticipantsFailed(string operationContext = null, Azure.Communication.CallAutomation.ResultInformation resultInformation = null, System.Collections.Generic.IEnumerable<Azure.Communication.CommunicationIdentifier> participants = null, string version = null, string callConnectionId = null, string serverCallId = null, string correlationId = null) { throw null; }
        public static Azure.Communication.CallAutomation.AddParticipantsResult AddParticipantsResult(System.Collections.Generic.IEnumerable<Azure.Communication.CallAutomation.CallParticipant> participants = null, string operationContext = null) { throw null; }
        public static Azure.Communication.CallAutomation.AddParticipantsSucceeded AddParticipantsSucceeded(string operationContext = null, Azure.Communication.CallAutomation.ResultInformation resultInformation = null, System.Collections.Generic.IEnumerable<Azure.Communication.CommunicationIdentifier> participants = null, string version = null, string callConnectionId = null, string serverCallId = null, string correlationId = null) { throw null; }
        public static Azure.Communication.CallAutomation.AnswerCallResult AnswerCallResult(Azure.Communication.CallAutomation.CallConnection callConnection = null, Azure.Communication.CallAutomation.CallConnectionProperties callConnectionProperties = null) { throw null; }
        public static Azure.Communication.CallAutomation.CallConnected CallConnected(string eventSource = null, string version = null, string operationContext = null, Azure.Communication.CallAutomation.ResultInformation resultInformation = null, string callConnectionId = null, string serverCallId = null, string correlationId = null, string publicEventType = null) { throw null; }
        public static Azure.Communication.CallAutomation.CallConnectionProperties CallConnectionProperties(string callConnectionId = null, string serverCallId = null, Azure.Communication.CallAutomation.CallSource callSource = null, System.Collections.Generic.IEnumerable<Azure.Communication.CommunicationIdentifier> targets = null, Azure.Communication.CallAutomation.CallConnectionState callConnectionState = default(Azure.Communication.CallAutomation.CallConnectionState), string subject = null, System.Uri callbackEndpoint = null, string mediaSubscriptionId = null) { throw null; }
        public static Azure.Communication.CallAutomation.CallDisconnected CallDisconnected(string eventSource = null, string version = null, string operationContext = null, Azure.Communication.CallAutomation.ResultInformation resultInformation = null, string callConnectionId = null, string serverCallId = null, string correlationId = null, string publicEventType = null) { throw null; }
        public static Azure.Communication.CallAutomation.CallParticipant CallParticipant(Azure.Communication.CommunicationIdentifier identifier = null, bool isMuted = false) { throw null; }
        public static Azure.Communication.CallAutomation.CallRecordingStateChanged CallRecordingStateChanged(string eventSource = null, string recordingId = null, Azure.Communication.CallAutomation.RecordingState state = default(Azure.Communication.CallAutomation.RecordingState), System.DateTimeOffset? startDateTime = default(System.DateTimeOffset?), string version = null, string operationContext = null, Azure.Communication.CallAutomation.ResultInformation resultInformation = null, string callConnectionId = null, string serverCallId = null, string correlationId = null, string publicEventType = null) { throw null; }
        public static Azure.Communication.CallAutomation.CallTransferAccepted CallTransferAccepted(string eventSource = null, string operationContext = null, Azure.Communication.CallAutomation.ResultInformation resultInformation = null, string version = null, string callConnectionId = null, string serverCallId = null, string correlationId = null, string publicEventType = null) { throw null; }
        public static Azure.Communication.CallAutomation.CallTransferFailed CallTransferFailed(string eventSource = null, string operationContext = null, Azure.Communication.CallAutomation.ResultInformation resultInformation = null, string version = null, string callConnectionId = null, string serverCallId = null, string correlationId = null, string publicEventType = null) { throw null; }
        public static Azure.Communication.CallAutomation.CollectTonesResult CollectTonesResult(System.Collections.Generic.IEnumerable<Azure.Communication.CallAutomation.DtmfTone> tones = null) { throw null; }
        public static Azure.Communication.CallAutomation.CreateCallResult CreateCallResult(Azure.Communication.CallAutomation.CallConnection callConnection = null, Azure.Communication.CallAutomation.CallConnectionProperties callConnectionProperties = null) { throw null; }
        public static Azure.Communication.CallAutomation.ParticipantsUpdated ParticipantsUpdated(System.Collections.Generic.IEnumerable<Azure.Communication.CommunicationIdentifier> participants = null, string version = null, string operationContext = null, Azure.Communication.CallAutomation.ResultInformation resultInformation = null, string callConnectionId = null, string serverCallId = null, string correlationId = null) { throw null; }
        public static Azure.Communication.CallAutomation.PlayCompleted PlayCompleted(string operationContext = null, Azure.Communication.CallAutomation.ResultInformation resultInformation = null, string version = null, string callConnectionId = null, string serverCallId = null, string correlationId = null, string publicEventType = null) { throw null; }
        public static Azure.Communication.CallAutomation.PlayFailed PlayFailed(string eventSource = null, string operationContext = null, Azure.Communication.CallAutomation.ResultInformation resultInformation = null, string version = null, string callConnectionId = null, string serverCallId = null, string correlationId = null, string publicEventType = null) { throw null; }
        public static Azure.Communication.CallAutomation.RecognizeCompleted RecognizeCompleted(string operationContext = null, Azure.Communication.CallAutomation.ResultInformation resultInformation = null, Azure.Communication.CallAutomation.CallMediaRecognitionType recognitionType = default(Azure.Communication.CallAutomation.CallMediaRecognitionType), Azure.Communication.CallAutomation.CollectTonesResult collectTonesResult = null, string version = null, string callConnectionId = null, string serverCallId = null, string correlationId = null, string publicEventType = null) { throw null; }
        public static Azure.Communication.CallAutomation.RecognizeFailed RecognizeFailed(string operationContext = null, Azure.Communication.CallAutomation.ResultInformation resultInformation = null, string version = null, string callConnectionId = null, string serverCallId = null, string correlationId = null, string publicEventType = null) { throw null; }
        public static Azure.Communication.CallAutomation.RecordingStateResult RecordingStateResult(string recordingId = null, Azure.Communication.CallAutomation.RecordingState? recordingState = default(Azure.Communication.CallAutomation.RecordingState?)) { throw null; }
        public static Azure.Communication.CallAutomation.RemoveParticipantsResult RemoveParticipantsResult(string operationContext = null) { throw null; }
        public static Azure.Communication.CallAutomation.ResultInformation ResultInformation(int? code = default(int?), int? subCode = default(int?), string message = null) { throw null; }
        public static Azure.Communication.CallAutomation.TransferCallToParticipantResult TransferCallToParticipantResult(string operationContext = null) { throw null; }
    }
    public partial class CallConnected : Azure.Communication.CallAutomation.CallAutomationEventBase
    {
        internal CallConnected() { }
        public string EventSource { get { throw null; } }
        public string OperationContext { get { throw null; } }
        public string PublicEventType { get { throw null; } }
        public Azure.Communication.CallAutomation.ResultInformation ResultInformation { get { throw null; } }
        public string Version { get { throw null; } }
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
        public virtual Azure.Response HangUp(bool forEveryone, System.Guid? repeatabilityRequestId = default(System.Guid?), System.DateTimeOffset? repeatabilityFirstSent = default(System.DateTimeOffset?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> HangUpAsync(bool forEveryone, System.Guid? repeatabilityRequestId = default(System.Guid?), System.DateTimeOffset? repeatabilityFirstSent = default(System.DateTimeOffset?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Communication.CallAutomation.RemoveParticipantsResult> RemoveParticipants(System.Collections.Generic.IEnumerable<Azure.Communication.CommunicationIdentifier> participantsToRemove, string operationContext = null, System.Guid? repeatabilityRequestId = default(System.Guid?), System.DateTimeOffset? repeatabilityFirstSent = default(System.DateTimeOffset?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Communication.CallAutomation.RemoveParticipantsResult>> RemoveParticipantsAsync(System.Collections.Generic.IEnumerable<Azure.Communication.CommunicationIdentifier> participantsToRemove, string operationContext = null, System.Guid? repeatabilityRequestId = default(System.Guid?), System.DateTimeOffset? repeatabilityFirstSent = default(System.DateTimeOffset?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Communication.CallAutomation.TransferCallToParticipantResult> TransferCallToParticipant(Azure.Communication.CallAutomation.TransferToParticipantOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Communication.CallAutomation.TransferCallToParticipantResult>> TransferCallToParticipantAsync(Azure.Communication.CallAutomation.TransferToParticipantOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
        public string Subject { get { throw null; } }
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
        public string EventSource { get { throw null; } }
        public string OperationContext { get { throw null; } }
        public string PublicEventType { get { throw null; } }
        public Azure.Communication.CallAutomation.ResultInformation ResultInformation { get { throw null; } }
        public string Version { get { throw null; } }
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
        public virtual Azure.Response CancelAllMediaOperations(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> CancelAllMediaOperationsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response Play(Azure.Communication.CallAutomation.PlaySource playSource, System.Collections.Generic.IEnumerable<Azure.Communication.CommunicationIdentifier> playTo, Azure.Communication.CallAutomation.PlayOptions playOptions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> PlayAsync(Azure.Communication.CallAutomation.PlaySource playSource, System.Collections.Generic.IEnumerable<Azure.Communication.CommunicationIdentifier> playTo, Azure.Communication.CallAutomation.PlayOptions playOptions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response PlayToAll(Azure.Communication.CallAutomation.PlaySource playSource, Azure.Communication.CallAutomation.PlayOptions playOptions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> PlayToAllAsync(Azure.Communication.CallAutomation.PlaySource playSource, Azure.Communication.CallAutomation.PlayOptions playOptions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response StartRecognizing(Azure.Communication.CallAutomation.CallMediaRecognizeOptions recognizeOptions, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> StartRecognizingAsync(Azure.Communication.CallAutomation.CallMediaRecognizeOptions recognizeOptions, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct CallMediaRecognitionType : System.IEquatable<Azure.Communication.CallAutomation.CallMediaRecognitionType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public CallMediaRecognitionType(string value) { throw null; }
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
    public partial class CallRecordingStateChanged : Azure.Communication.CallAutomation.CallAutomationEventBase
    {
        internal CallRecordingStateChanged() { }
        public string EventSource { get { throw null; } }
        public string OperationContext { get { throw null; } }
        public string PublicEventType { get { throw null; } }
        public string RecordingId { get { throw null; } }
        public Azure.Communication.CallAutomation.ResultInformation ResultInformation { get { throw null; } }
        public System.DateTimeOffset? StartDateTime { get { throw null; } }
        public Azure.Communication.CallAutomation.RecordingState State { get { throw null; } set { } }
        public string Version { get { throw null; } }
        public static Azure.Communication.CallAutomation.CallRecordingStateChanged Deserialize(string content) { throw null; }
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
        public string EventSource { get { throw null; } }
        public string OperationContext { get { throw null; } }
        public string PublicEventType { get { throw null; } }
        public Azure.Communication.CallAutomation.ResultInformation ResultInformation { get { throw null; } }
        public string Version { get { throw null; } }
        public static Azure.Communication.CallAutomation.CallTransferAccepted Deserialize(string content) { throw null; }
    }
    public partial class CallTransferFailed : Azure.Communication.CallAutomation.CallAutomationEventBase
    {
        internal CallTransferFailed() { }
        public string EventSource { get { throw null; } }
        public string OperationContext { get { throw null; } }
        public string PublicEventType { get { throw null; } }
        public Azure.Communication.CallAutomation.ResultInformation ResultInformation { get { throw null; } }
        public string Version { get { throw null; } }
        public static Azure.Communication.CallAutomation.CallTransferFailed Deserialize(string content) { throw null; }
    }
    public partial class ChannelAffinity
    {
        public ChannelAffinity() { }
        public int Channel { get { throw null; } set { } }
        public Azure.Communication.CommunicationIdentifier Participant { get { throw null; } set { } }
    }
    public partial class CollectTonesResult
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
    public partial class CreateCallOptions : Azure.Communication.CallAutomation.RepeatabilityHeaders
    {
        public CreateCallOptions(Azure.Communication.CallAutomation.CallSource callSource, System.Collections.Generic.IEnumerable<Azure.Communication.CommunicationIdentifier> targets, System.Uri callbackUri) { }
        public System.Uri CallbackUri { get { throw null; } }
        public Azure.Communication.CallAutomation.CallSource CallSource { get { throw null; } }
        public Azure.Communication.CallAutomation.MediaStreamingOptions MediaStreamingOptions { get { throw null; } set { } }
        public string Subject { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<Azure.Communication.CommunicationIdentifier> Targets { get { throw null; } }
    }
    public partial class CreateCallResult
    {
        internal CreateCallResult() { }
        public Azure.Communication.CallAutomation.CallConnection CallConnection { get { throw null; } }
        public Azure.Communication.CallAutomation.CallConnectionProperties CallConnectionProperties { get { throw null; } }
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
    public partial class FileSource : Azure.Communication.CallAutomation.PlaySource
    {
        public FileSource(System.Uri fileUri) { }
        public System.Uri FileUri { get { throw null; } }
    }
    public partial class GroupCallLocator : Azure.Communication.CallAutomation.CallLocator
    {
        public GroupCallLocator(string id) { }
        public override bool Equals(Azure.Communication.CallAutomation.CallLocator other) { throw null; }
        public override int GetHashCode() { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class MediaStreamingAudio : Azure.Communication.CallAutomation.MediaStreamingPackageBase
    {
        internal MediaStreamingAudio() { }
        public byte[] Data { get { throw null; } }
        public bool IsSilent { get { throw null; } }
        public Azure.Communication.CommunicationIdentifier Participant { get { throw null; } }
        public System.DateTime Timestamp { get { throw null; } }
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
    public partial class MediaStreamingFormat
    {
        internal MediaStreamingFormat() { }
        public int Channels { get { throw null; } }
        public string Encoding { get { throw null; } }
        public double Length { get { throw null; } }
        public int SampleRate { get { throw null; } }
    }
    public partial class MediaStreamingMetadata : Azure.Communication.CallAutomation.MediaStreamingPackageBase
    {
        internal MediaStreamingMetadata() { }
        public Azure.Communication.CallAutomation.MediaStreamingFormat Format { get { throw null; } }
        public string MediaSubscriptionId { get { throw null; } }
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
    public partial class ParticipantsUpdated : Azure.Communication.CallAutomation.CallAutomationEventBase
    {
        internal ParticipantsUpdated() { }
        public string EventSource { get { throw null; } }
        public string OperationContext { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Communication.CommunicationIdentifier> Participants { get { throw null; } }
        public string PublicEventType { get { throw null; } }
        public Azure.Communication.CallAutomation.ResultInformation ResultInformation { get { throw null; } }
        public string Version { get { throw null; } }
        public static Azure.Communication.CallAutomation.ParticipantsUpdated Deserialize(string content) { throw null; }
    }
    public partial class PlayCompleted : Azure.Communication.CallAutomation.CallAutomationEventBase
    {
        internal PlayCompleted() { }
        public string OperationContext { get { throw null; } }
        public string PublicEventType { get { throw null; } }
        public Azure.Communication.CallAutomation.ResultInformation ResultInformation { get { throw null; } }
        public string Version { get { throw null; } }
        public static Azure.Communication.CallAutomation.PlayCompleted Deserialize(string content) { throw null; }
    }
    public partial class PlayFailed : Azure.Communication.CallAutomation.CallAutomationEventBase
    {
        internal PlayFailed() { }
        public string EventSource { get { throw null; } }
        public string OperationContext { get { throw null; } }
        public string PublicEventType { get { throw null; } }
        public Azure.Communication.CallAutomation.ResultInformation ResultInformation { get { throw null; } }
        public string Version { get { throw null; } }
        public static Azure.Communication.CallAutomation.PlayFailed Deserialize(string content) { throw null; }
    }
    public partial class PlayOptions
    {
        public PlayOptions() { }
        public bool Loop { get { throw null; } set { } }
        public string OperationContext { get { throw null; } set { } }
    }
    public abstract partial class PlaySource
    {
        protected PlaySource() { }
        public string PlaySourceId { get { throw null; } set { } }
    }
    public partial class RecognizeCompleted : Azure.Communication.CallAutomation.CallAutomationEventBase
    {
        internal RecognizeCompleted() { }
        public Azure.Communication.CallAutomation.CollectTonesResult CollectTonesResult { get { throw null; } }
        public string OperationContext { get { throw null; } }
        public string PublicEventType { get { throw null; } }
        public Azure.Communication.CallAutomation.CallMediaRecognitionType RecognitionType { get { throw null; } set { } }
        public Azure.Communication.CallAutomation.ResultInformation ResultInformation { get { throw null; } }
        public string Version { get { throw null; } }
        public static Azure.Communication.CallAutomation.RecognizeCompleted Deserialize(string content) { throw null; }
    }
    public partial class RecognizeFailed : Azure.Communication.CallAutomation.CallAutomationEventBase
    {
        internal RecognizeFailed() { }
        public string OperationContext { get { throw null; } }
        public string PublicEventType { get { throw null; } }
        public Azure.Communication.CallAutomation.ResultInformation ResultInformation { get { throw null; } }
        public string Version { get { throw null; } }
        public static Azure.Communication.CallAutomation.RecognizeFailed Deserialize(string content) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RecognizeInputType : System.IEquatable<Azure.Communication.CallAutomation.RecognizeInputType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RecognizeInputType(string value) { throw null; }
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
    public partial class RecordingStateResult
    {
        internal RecordingStateResult() { }
        public string RecordingId { get { throw null; } }
        public Azure.Communication.CallAutomation.RecordingState? RecordingState { get { throw null; } }
    }
    public partial class RemoveParticipantsResult
    {
        internal RemoveParticipantsResult() { }
        public string OperationContext { get { throw null; } }
    }
    public partial class RepeatabilityHeaders
    {
        public RepeatabilityHeaders() { }
        public System.DateTimeOffset? RepeatabilityFirstSent { get { throw null; } set { } }
        public System.Guid? RepeatabilityRequestId { get { throw null; } set { } }
        public string GetRepeatabilityFirstSentString() { throw null; }
        public bool IsValidRepeatabilityHeaders() { throw null; }
    }
    public partial class ResultInformation
    {
        internal ResultInformation() { }
        public int? Code { get { throw null; } }
        public string Message { get { throw null; } }
        public int? SubCode { get { throw null; } }
    }
    public partial class ServerCallLocator : Azure.Communication.CallAutomation.CallLocator
    {
        public ServerCallLocator(string id) { }
        public override bool Equals(Azure.Communication.CallAutomation.CallLocator other) { throw null; }
        public override int GetHashCode() { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class StartRecordingOptions
    {
        public StartRecordingOptions(Azure.Communication.CallAutomation.CallLocator callLocator) { }
        public System.Collections.Generic.IEnumerable<Azure.Communication.CallAutomation.ChannelAffinity> ChannelAffinity { get { throw null; } set { } }
        public Azure.Communication.CallAutomation.RecordingChannel RecordingChannel { get { throw null; } set { } }
        public Azure.Communication.CallAutomation.RecordingContent RecordingContent { get { throw null; } set { } }
        public Azure.Communication.CallAutomation.RecordingFormat RecordingFormat { get { throw null; } set { } }
        public System.Uri RecordingStateCallbackEndpoint { get { throw null; } set { } }
    }
    public partial class TransferCallToParticipantResult
    {
        internal TransferCallToParticipantResult() { }
        public string OperationContext { get { throw null; } }
    }
    public partial class TransferToParticipantOptions : Azure.Communication.CallAutomation.RepeatabilityHeaders
    {
        public TransferToParticipantOptions(Azure.Communication.CommunicationIdentifier targetParticipant) { }
        public string OperationContext { get { throw null; } set { } }
        public Azure.Communication.PhoneNumberIdentifier SourceCallerId { get { throw null; } set { } }
        public Azure.Communication.CommunicationIdentifier TargetParticipant { get { throw null; } }
        public string UserToUserInformation { get { throw null; } set { } }
    }
}
