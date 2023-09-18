namespace Azure.Communication.CallAutomation
{
    public partial class AddParticipantEventResult
    {
        internal AddParticipantEventResult() { }
        public Azure.Communication.CallAutomation.AddParticipantFailed FailureResult { get { throw null; } }
        public bool IsSuccess { get { throw null; } }
        public Azure.Communication.CommunicationIdentifier Participant { get { throw null; } }
        public Azure.Communication.CallAutomation.AddParticipantSucceeded SuccessResult { get { throw null; } }
    }
    public partial class AddParticipantFailed : Azure.Communication.CallAutomation.CallAutomationEventBase
    {
        internal AddParticipantFailed() { }
        public Azure.Communication.CommunicationIdentifier Participant { get { throw null; } }
        public static Azure.Communication.CallAutomation.AddParticipantFailed Deserialize(string content) { throw null; }
    }
    public partial class AddParticipantOptions
    {
        public AddParticipantOptions(Azure.Communication.CallAutomation.CallInvite participantToAdd) { }
        public int? InvitationTimeoutInSeconds { get { throw null; } set { } }
        public string OperationContext { get { throw null; } set { } }
        public Azure.Communication.CallAutomation.CallInvite ParticipantToAdd { get { throw null; } }
    }
    public partial class AddParticipantResult
    {
        internal AddParticipantResult() { }
        public string OperationContext { get { throw null; } }
        public Azure.Communication.CallAutomation.CallParticipant Participant { get { throw null; } }
        public Azure.Communication.CallAutomation.AddParticipantEventResult WaitForEventProcessor(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public System.Threading.Tasks.Task<Azure.Communication.CallAutomation.AddParticipantEventResult> WaitForEventProcessorAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class AddParticipantSucceeded : Azure.Communication.CallAutomation.CallAutomationEventBase
    {
        internal AddParticipantSucceeded() { }
        public Azure.Communication.CommunicationIdentifier Participant { get { throw null; } }
        public static Azure.Communication.CallAutomation.AddParticipantSucceeded Deserialize(string content) { throw null; }
    }
    public partial class AnswerCallEventResult
    {
        internal AnswerCallEventResult() { }
        public bool IsSuccess { get { throw null; } }
        public Azure.Communication.CallAutomation.CallConnected SuccessResult { get { throw null; } }
    }
    public partial class AnswerCallOptions
    {
        public AnswerCallOptions(string incomingCallContext, System.Uri callbackUri) { }
        public Azure.Communication.CommunicationUserIdentifier AnsweredBy { get { throw null; } set { } }
        public System.Uri CallbackUri { get { throw null; } }
        public System.Uri CognitiveServicesEndpoint { get { throw null; } set { } }
        public string IncomingCallContext { get { throw null; } }
        public string OperationContext { get { throw null; } set { } }
    }
    public partial class AnswerCallResult
    {
        internal AnswerCallResult() { }
        public Azure.Communication.CallAutomation.CallConnection CallConnection { get { throw null; } }
        public Azure.Communication.CallAutomation.CallConnectionProperties CallConnectionProperties { get { throw null; } }
        public Azure.Communication.CallAutomation.AnswerCallEventResult WaitForEventProcessor(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public System.Threading.Tasks.Task<Azure.Communication.CallAutomation.AnswerCallEventResult> WaitForEventProcessorAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class CallAutomationClient
    {
        protected CallAutomationClient() { }
        public CallAutomationClient(string connectionString) { }
        public CallAutomationClient(string connectionString, Azure.Communication.CallAutomation.CallAutomationClientOptions options) { }
        public CallAutomationClient(System.Uri endpoint, Azure.Core.TokenCredential credential, Azure.Communication.CallAutomation.CallAutomationClientOptions options = null) { }
        public Azure.Communication.CommunicationUserIdentifier Source { get { throw null; } }
        public virtual Azure.Response<Azure.Communication.CallAutomation.AnswerCallResult> AnswerCall(Azure.Communication.CallAutomation.AnswerCallOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Communication.CallAutomation.AnswerCallResult> AnswerCall(string incomingCallContext, System.Uri callbackUri, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Communication.CallAutomation.AnswerCallResult>> AnswerCallAsync(Azure.Communication.CallAutomation.AnswerCallOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Communication.CallAutomation.AnswerCallResult>> AnswerCallAsync(string incomingCallContext, System.Uri callbackUri, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Communication.CallAutomation.CreateCallResult> CreateCall(Azure.Communication.CallAutomation.CallInvite callInvite, System.Uri callbackUri, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Communication.CallAutomation.CreateCallResult> CreateCall(Azure.Communication.CallAutomation.CreateCallOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Communication.CallAutomation.CreateCallResult>> CreateCallAsync(Azure.Communication.CallAutomation.CallInvite callInvite, System.Uri callbackUri, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Communication.CallAutomation.CreateCallResult>> CreateCallAsync(Azure.Communication.CallAutomation.CreateCallOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Communication.CallAutomation.CreateCallResult> CreateGroupCall(Azure.Communication.CallAutomation.CreateGroupCallOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Communication.CallAutomation.CreateCallResult>> CreateGroupCallAsync(Azure.Communication.CallAutomation.CreateGroupCallOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Communication.CallAutomation.CallConnection GetCallConnection(string callConnectionId) { throw null; }
        public virtual Azure.Communication.CallAutomation.CallRecording GetCallRecording() { throw null; }
        public virtual Azure.Communication.CallAutomation.CallAutomationEventProcessor GetEventProcessor() { throw null; }
        public virtual Azure.Response RedirectCall(Azure.Communication.CallAutomation.RedirectCallOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response RedirectCall(string incomingCallContext, Azure.Communication.CallAutomation.CallInvite callInvite, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> RedirectCallAsync(Azure.Communication.CallAutomation.RedirectCallOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> RedirectCallAsync(string incomingCallContext, Azure.Communication.CallAutomation.CallInvite callInvite, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response RejectCall(Azure.Communication.CallAutomation.RejectCallOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response RejectCall(string incomingCallContext, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> RejectCallAsync(Azure.Communication.CallAutomation.RejectCallOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> RejectCallAsync(string incomingCallContext, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class CallAutomationClientOptions : Azure.Core.ClientOptions
    {
        public CallAutomationClientOptions(Azure.Communication.CallAutomation.CallAutomationClientOptions.ServiceVersion version = Azure.Communication.CallAutomation.CallAutomationClientOptions.ServiceVersion.V2023_10_15) { }
        public Azure.Communication.CommunicationUserIdentifier Source { get { throw null; } set { } }
        public enum ServiceVersion
        {
            V2023_03_06 = 1,
            V2023_06_15_Preview = 2,
            V2023_10_15 = 3,
        }
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
    public partial class CallAutomationEventProcessor
    {
        internal CallAutomationEventProcessor() { }
        public void AttachOngoingEventProcessor<TEvent>(string callConnectionId, System.Action<TEvent> eventProcessor) where TEvent : Azure.Communication.CallAutomation.CallAutomationEventBase { }
        public void DetachOngoingEventProcessor<TEvent>(string callConnectionId) where TEvent : Azure.Communication.CallAutomation.CallAutomationEventBase { }
        public void ProcessEvents(System.Collections.Generic.IEnumerable<Azure.Communication.CallAutomation.CallAutomationEventBase> events) { }
        public void ProcessEvents(System.Collections.Generic.IEnumerable<Azure.Messaging.CloudEvent> events) { }
        public Azure.Communication.CallAutomation.CallAutomationEventBase WaitForEventProcessor(System.Func<Azure.Communication.CallAutomation.CallAutomationEventBase, bool> predicate, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public System.Threading.Tasks.Task<Azure.Communication.CallAutomation.CallAutomationEventBase> WaitForEventProcessorAsync(System.Func<Azure.Communication.CallAutomation.CallAutomationEventBase, bool> predicate, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public System.Threading.Tasks.Task<TEvent> WaitForEventProcessorAsync<TEvent>(string connectionId = null, string operationContext = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) where TEvent : Azure.Communication.CallAutomation.CallAutomationEventBase { throw null; }
        public TEvent WaitForEventProcessor<TEvent>(string connectionId = null, string operationContext = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) where TEvent : Azure.Communication.CallAutomation.CallAutomationEventBase { throw null; }
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
        public virtual Azure.Response<Azure.Communication.CallAutomation.AddParticipantResult> AddParticipant(Azure.Communication.CallAutomation.AddParticipantOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Communication.CallAutomation.AddParticipantResult> AddParticipant(Azure.Communication.CallAutomation.CallInvite participantToAdd, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Communication.CallAutomation.AddParticipantResult>> AddParticipantAsync(Azure.Communication.CallAutomation.AddParticipantOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Communication.CallAutomation.AddParticipantResult>> AddParticipantAsync(Azure.Communication.CallAutomation.CallInvite participantToAdd, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Communication.CallAutomation.CallConnectionProperties> GetCallConnectionProperties(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Communication.CallAutomation.CallConnectionProperties>> GetCallConnectionPropertiesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Communication.CallAutomation.CallMedia GetCallMedia() { throw null; }
        public virtual Azure.Response<Azure.Communication.CallAutomation.CallParticipant> GetParticipant(Azure.Communication.CommunicationIdentifier participantIdentifier, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Communication.CallAutomation.CallParticipant>> GetParticipantAsync(Azure.Communication.CommunicationIdentifier participantIdentifier, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<System.Collections.Generic.IReadOnlyList<Azure.Communication.CallAutomation.CallParticipant>> GetParticipants(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<System.Collections.Generic.IReadOnlyList<Azure.Communication.CallAutomation.CallParticipant>>> GetParticipantsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response HangUp(bool forEveryone, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> HangUpAsync(bool forEveryone, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Communication.CallAutomation.MuteParticipantResult> MuteParticipant(Azure.Communication.CommunicationIdentifier targetParticipant, string operationContext = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Communication.CallAutomation.MuteParticipantResult>> MuteParticipantAsync(Azure.Communication.CommunicationIdentifier targetParticipant, string operationContext = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Communication.CallAutomation.RemoveParticipantResult> RemoveParticipant(Azure.Communication.CallAutomation.RemoveParticipantOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Communication.CallAutomation.RemoveParticipantResult> RemoveParticipant(Azure.Communication.CommunicationIdentifier participantToRemove, string operationContext = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Communication.CallAutomation.RemoveParticipantResult>> RemoveParticipantAsync(Azure.Communication.CallAutomation.RemoveParticipantOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Communication.CallAutomation.RemoveParticipantResult>> RemoveParticipantAsync(Azure.Communication.CommunicationIdentifier participantToRemove, string operationContext = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Communication.CallAutomation.TransferCallToParticipantResult> TransferCallToParticipant(Azure.Communication.CallAutomation.TransferToParticipantOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Communication.CallAutomation.TransferCallToParticipantResult> TransferCallToParticipant(Azure.Communication.CommunicationIdentifier targetParticipant, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Communication.CallAutomation.TransferCallToParticipantResult>> TransferCallToParticipantAsync(Azure.Communication.CallAutomation.TransferToParticipantOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Communication.CallAutomation.TransferCallToParticipantResult>> TransferCallToParticipantAsync(Azure.Communication.CommunicationIdentifier targetParticipant, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class CallConnectionProperties
    {
        internal CallConnectionProperties() { }
        public Azure.Communication.CommunicationUserIdentifier AnsweredBy { get { throw null; } }
        public System.Uri CallbackUri { get { throw null; } }
        public string CallConnectionId { get { throw null; } }
        public Azure.Communication.CallAutomation.CallConnectionState CallConnectionState { get { throw null; } }
        public string CorrelationId { get { throw null; } }
        public string ServerCallId { get { throw null; } }
        public Azure.Communication.CommunicationIdentifier Source { get { throw null; } }
        public Azure.Communication.PhoneNumberIdentifier SourceCallerIdNumber { get { throw null; } }
        public string SourceDisplayName { get { throw null; } }
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
    public partial class CallInvite
    {
        public CallInvite(Azure.Communication.CommunicationUserIdentifier targetIdentity) { }
        public CallInvite(Azure.Communication.MicrosoftTeamsUserIdentifier targetIdentity) { }
        public CallInvite(Azure.Communication.PhoneNumberIdentifier targetPhoneNumberIdentity, Azure.Communication.PhoneNumberIdentifier callerIdNumber) { }
        public Azure.Communication.PhoneNumberIdentifier SourceCallerIdNumber { get { throw null; } }
        public string SourceDisplayName { get { throw null; } set { } }
        public Azure.Communication.CommunicationIdentifier Target { get { throw null; } }
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
        public virtual Azure.Response<Azure.Communication.CallAutomation.PlayResult> Play(Azure.Communication.CallAutomation.PlayOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Communication.CallAutomation.PlayResult> Play(Azure.Communication.CallAutomation.PlaySource playSource, System.Collections.Generic.IEnumerable<Azure.Communication.CommunicationIdentifier> playTo, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Communication.CallAutomation.PlayResult>> PlayAsync(Azure.Communication.CallAutomation.PlayOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Communication.CallAutomation.PlayResult>> PlayAsync(Azure.Communication.CallAutomation.PlaySource playSource, System.Collections.Generic.IEnumerable<Azure.Communication.CommunicationIdentifier> playTo, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Communication.CallAutomation.PlayResult> PlayToAll(Azure.Communication.CallAutomation.PlaySource playSource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Communication.CallAutomation.PlayResult> PlayToAll(Azure.Communication.CallAutomation.PlayToAllOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Communication.CallAutomation.PlayResult>> PlayToAllAsync(Azure.Communication.CallAutomation.PlaySource playSource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Communication.CallAutomation.PlayResult>> PlayToAllAsync(Azure.Communication.CallAutomation.PlayToAllOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Communication.CallAutomation.SendDtmfTonesResult> SendDtmfTones(System.Collections.Generic.IEnumerable<Azure.Communication.CallAutomation.DtmfTone> tones, Azure.Communication.CommunicationIdentifier targetParticipant, string operationContext = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Communication.CallAutomation.SendDtmfTonesResult>> SendDtmfTonesAsync(System.Collections.Generic.IEnumerable<Azure.Communication.CallAutomation.DtmfTone> tones, Azure.Communication.CommunicationIdentifier targetParticipant, string operationContext = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response StartContinuousDtmfRecognition(Azure.Communication.CommunicationIdentifier targetParticipant, string operationContext = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> StartContinuousDtmfRecognitionAsync(Azure.Communication.CommunicationIdentifier targetParticipant, string operationContext = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Communication.CallAutomation.StartRecognizingCallMediaResult> StartRecognizing(Azure.Communication.CallAutomation.CallMediaRecognizeOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Communication.CallAutomation.StartRecognizingCallMediaResult>> StartRecognizingAsync(Azure.Communication.CallAutomation.CallMediaRecognizeOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response StopContinuousDtmfRecognition(Azure.Communication.CommunicationIdentifier targetParticipant, string operationContext = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> StopContinuousDtmfRecognitionAsync(Azure.Communication.CommunicationIdentifier targetParticipant, string operationContext = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct CallMediaRecognitionType : System.IEquatable<Azure.Communication.CallAutomation.CallMediaRecognitionType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public CallMediaRecognitionType(string value) { throw null; }
        public static Azure.Communication.CallAutomation.CallMediaRecognitionType Choices { get { throw null; } }
        public static Azure.Communication.CallAutomation.CallMediaRecognitionType Dtmf { get { throw null; } }
        public static Azure.Communication.CallAutomation.CallMediaRecognitionType Speech { get { throw null; } }
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
        public CallMediaRecognizeChoiceOptions(Azure.Communication.CommunicationIdentifier targetParticipant, System.Collections.Generic.IEnumerable<Azure.Communication.CallAutomation.RecognitionChoice> choices) : base (default(Azure.Communication.CallAutomation.RecognizeInputType), default(Azure.Communication.CommunicationIdentifier)) { }
        public System.Collections.Generic.IList<Azure.Communication.CallAutomation.RecognitionChoice> Choices { get { throw null; } }
    }
    public partial class CallMediaRecognizeDtmfOptions : Azure.Communication.CallAutomation.CallMediaRecognizeOptions
    {
        public CallMediaRecognizeDtmfOptions(Azure.Communication.CommunicationIdentifier targetParticipant, int maxTonesToCollect) : base (default(Azure.Communication.CallAutomation.RecognizeInputType), default(Azure.Communication.CommunicationIdentifier)) { }
        public System.TimeSpan InterToneTimeout { get { throw null; } set { } }
        public int MaxTonesToCollect { get { throw null; } }
        public System.Collections.Generic.IList<Azure.Communication.CallAutomation.DtmfTone> StopTones { get { throw null; } set { } }
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
        public string SpeechLanguage { get { throw null; } set { } }
        public string SpeechModelEndpointId { get { throw null; } set { } }
        public Azure.Communication.CommunicationIdentifier TargetParticipant { get { throw null; } }
    }
    public partial class CallMediaRecognizeSpeechOptions : Azure.Communication.CallAutomation.CallMediaRecognizeOptions
    {
        public CallMediaRecognizeSpeechOptions(Azure.Communication.CommunicationIdentifier targetParticipant) : base (default(Azure.Communication.CallAutomation.RecognizeInputType), default(Azure.Communication.CommunicationIdentifier)) { }
        public System.TimeSpan EndSilenceTimeout { get { throw null; } set { } }
    }
    public partial class CallMediaRecognizeSpeechOrDtmfOptions : Azure.Communication.CallAutomation.CallMediaRecognizeOptions
    {
        public CallMediaRecognizeSpeechOrDtmfOptions(Azure.Communication.CommunicationIdentifier targetParticipant, int maxTonesToCollect) : base (default(Azure.Communication.CallAutomation.RecognizeInputType), default(Azure.Communication.CommunicationIdentifier)) { }
        public System.TimeSpan EndSilenceTimeout { get { throw null; } set { } }
        public System.TimeSpan InterToneTimeout { get { throw null; } set { } }
        public int MaxTonesToCollect { get { throw null; } }
        public System.Collections.Generic.IList<Azure.Communication.CallAutomation.DtmfTone> StopTones { get { throw null; } set { } }
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
        public virtual Azure.Response Delete(System.Uri recordingLocation, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteAsync(System.Uri recordingLocation, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<System.IO.Stream> DownloadStreaming(System.Uri sourceLocation, Azure.HttpRange range = default(Azure.HttpRange), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<System.IO.Stream>> DownloadStreamingAsync(System.Uri sourceLocation, Azure.HttpRange range = default(Azure.HttpRange), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response DownloadTo(System.Uri sourceLocation, System.IO.Stream destinationStream, Azure.Communication.CallAutomation.ContentTransferOptions transferOptions = default(Azure.Communication.CallAutomation.ContentTransferOptions), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response DownloadTo(System.Uri sourceLocation, string destinationPath, Azure.Communication.CallAutomation.ContentTransferOptions transferOptions = default(Azure.Communication.CallAutomation.ContentTransferOptions), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DownloadToAsync(System.Uri sourceLocation, System.IO.Stream destinationStream, Azure.Communication.CallAutomation.ContentTransferOptions transferOptions = default(Azure.Communication.CallAutomation.ContentTransferOptions), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DownloadToAsync(System.Uri sourceLocation, string destinationPath, Azure.Communication.CallAutomation.ContentTransferOptions transferOptions = default(Azure.Communication.CallAutomation.ContentTransferOptions), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Communication.CallAutomation.RecordingStateResult> GetState(string recordingId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Communication.CallAutomation.RecordingStateResult>> GetStateAsync(string recordingId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response Pause(string recordingId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> PauseAsync(string recordingId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response Resume(string recordingId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> ResumeAsync(string recordingId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Communication.CallAutomation.RecordingStateResult> Start(Azure.Communication.CallAutomation.StartRecordingOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Communication.CallAutomation.RecordingStateResult>> StartAsync(Azure.Communication.CallAutomation.StartRecordingOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response Stop(string recordingId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> StopAsync(string recordingId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
    public partial class CancelAllMediaOperationsEventResult
    {
        internal CancelAllMediaOperationsEventResult() { }
        public bool IsSuccess { get { throw null; } }
        public Azure.Communication.CallAutomation.PlayCanceled PlayCanceledSucessEvent { get { throw null; } }
        public Azure.Communication.CallAutomation.RecognizeCanceled RecognizeCanceledSucessEvent { get { throw null; } }
    }
    public partial class CancelAllMediaOperationsResult
    {
        internal CancelAllMediaOperationsResult() { }
        public Azure.Communication.CallAutomation.CancelAllMediaOperationsEventResult WaitForEventProcessor(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public System.Threading.Tasks.Task<Azure.Communication.CallAutomation.CancelAllMediaOperationsEventResult> WaitForEventProcessorAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ChannelAffinity
    {
        public ChannelAffinity(Azure.Communication.CommunicationIdentifier participant) { }
        public int? Channel { get { throw null; } set { } }
        public Azure.Communication.CommunicationIdentifier Participant { get { throw null; } }
    }
    public partial class ChoiceResult : Azure.Communication.CallAutomation.RecognizeResult
    {
        internal ChoiceResult() { }
        public string Label { get { throw null; } }
        public string RecognizedPhrase { get { throw null; } }
        public override Azure.Communication.CallAutomation.RecognizeResultType ResultType { get { throw null; } }
    }
    public static partial class CommunicationCallAutomationModelFactory
    {
        public static Azure.Communication.CallAutomation.AddParticipantFailed AddParticipantFailed(string callConnectionId = null, string serverCallId = null, string correlationId = null, string operationContext = null, Azure.Communication.CallAutomation.ResultInformation resultInformation = null, Azure.Communication.CommunicationIdentifier participant = null) { throw null; }
        public static Azure.Communication.CallAutomation.AddParticipantResult AddParticipantsResult(Azure.Communication.CallAutomation.CallParticipant participant = null, string operationContext = null) { throw null; }
        public static Azure.Communication.CallAutomation.AddParticipantSucceeded AddParticipantSucceeded(string callConnectionId = null, string serverCallId = null, string correlationId = null, string operationContext = null, Azure.Communication.CallAutomation.ResultInformation resultInformation = null, Azure.Communication.CommunicationIdentifier participant = null) { throw null; }
        public static Azure.Communication.CallAutomation.AnswerCallResult AnswerCallResult(Azure.Communication.CallAutomation.CallConnection callConnection = null, Azure.Communication.CallAutomation.CallConnectionProperties callConnectionProperties = null) { throw null; }
        public static Azure.Communication.CallAutomation.CallConnected CallConnected(string callConnectionId = null, string serverCallId = null, string correlationId = null, string operationContext = null) { throw null; }
        public static Azure.Communication.CallAutomation.CallConnectionProperties CallConnectionProperties(string callConnectionId = null, string serverCallId = null, System.Collections.Generic.IEnumerable<Azure.Communication.CommunicationIdentifier> targets = null, Azure.Communication.CallAutomation.CallConnectionState callConnectionState = default(Azure.Communication.CallAutomation.CallConnectionState), System.Uri callbackUri = null, Azure.Communication.CommunicationIdentifier sourceIdentity = null, Azure.Communication.PhoneNumberIdentifier sourceCallerIdNumber = null, string sourceDisplayName = null, Azure.Communication.CommunicationIdentifier answeredBy = null) { throw null; }
        public static Azure.Communication.CallAutomation.CallDisconnected CallDisconnected(string callConnectionId = null, string serverCallId = null, string correlationId = null, string operationContext = null) { throw null; }
        public static Azure.Communication.CallAutomation.CallParticipant CallParticipant(Azure.Communication.CommunicationIdentifier identifier = null, bool isMuted = false) { throw null; }
        public static Azure.Communication.CallAutomation.CallTransferAccepted CallTransferAccepted(string callConnectionId = null, string serverCallId = null, string correlationId = null, string operationContext = null, Azure.Communication.CallAutomation.ResultInformation resultInformation = null) { throw null; }
        public static Azure.Communication.CallAutomation.CallTransferFailed CallTransferFailed(string callConnectionId = null, string serverCallId = null, string correlationId = null, string operationContext = null, Azure.Communication.CallAutomation.ResultInformation resultInformation = null) { throw null; }
        public static Azure.Communication.CallAutomation.ChoiceResult ChoiceResult(string label = null, string recognizedPhrase = null) { throw null; }
        public static Azure.Communication.CallAutomation.ContinuousDtmfRecognitionStopped ContinuousDtmfRecognitionStopped(string callConnectionId = null, string serverCallId = null, string correlationId = null, string operationContext = null, Azure.Communication.CallAutomation.ResultInformation resultInformation = null) { throw null; }
        public static Azure.Communication.CallAutomation.ContinuousDtmfRecognitionToneFailed ContinuousDtmfRecognitionToneFailed(string callConnectionId = null, string serverCallId = null, string correlationId = null, Azure.Communication.CallAutomation.ResultInformation resultInformation = null, string operationContext = null) { throw null; }
        public static Azure.Communication.CallAutomation.ContinuousDtmfRecognitionToneReceived ContinuousDtmfRecognitionToneReceived(Azure.Communication.CallAutomation.ToneInfo toneInfo = null, string callConnectionId = null, string serverCallId = null, string correlationId = null, Azure.Communication.CallAutomation.ResultInformation resultInformation = null, string operationContext = null) { throw null; }
        public static Azure.Communication.CallAutomation.CreateCallResult CreateCallResult(Azure.Communication.CallAutomation.CallConnection callConnection = null, Azure.Communication.CallAutomation.CallConnectionProperties callConnectionProperties = null) { throw null; }
        public static Azure.Communication.CallAutomation.DtmfResult DtmfResult(System.Collections.Generic.IEnumerable<Azure.Communication.CallAutomation.DtmfTone> tones = null) { throw null; }
        public static Azure.Communication.CallAutomation.MuteParticipantsResult MuteParticipantsResult(string operationContext = null) { throw null; }
        public static Azure.Communication.CallAutomation.ParticipantsUpdated ParticipantsUpdated(string callConnectionId = null, string serverCallId = null, string correlationId = null, System.Collections.Generic.IEnumerable<Azure.Communication.CallAutomation.CallParticipant> participants = null, int sequenceNumber = 0) { throw null; }
        public static Azure.Communication.CallAutomation.PlayCanceled PlayCanceled(string callConnectionId = null, string serverCallId = null, string correlationId = null, string operationContext = null) { throw null; }
        public static Azure.Communication.CallAutomation.PlayCompleted PlayCompleted(string callConnectionId = null, string serverCallId = null, string correlationId = null, string operationContext = null, Azure.Communication.CallAutomation.ResultInformation resultInformation = null) { throw null; }
        public static Azure.Communication.CallAutomation.PlayFailed PlayFailed(string callConnectionId = null, string serverCallId = null, string correlationId = null, string operationContext = null, Azure.Communication.CallAutomation.ResultInformation resultInformation = null) { throw null; }
        public static Azure.Communication.CallAutomation.RecognizeCanceled RecognizeCanceled(string callConnectionId = null, string serverCallId = null, string correlationId = null, string operationContext = null) { throw null; }
        public static Azure.Communication.CallAutomation.RecognizeCompleted RecognizeCompleted(string callConnectionId = null, string serverCallId = null, string correlationId = null, string operationContext = null, Azure.Communication.CallAutomation.ResultInformation resultInformation = null, Azure.Communication.CallAutomation.CallMediaRecognitionType recognitionType = default(Azure.Communication.CallAutomation.CallMediaRecognitionType), Azure.Communication.CallAutomation.RecognizeResult recognizeResult = null) { throw null; }
        public static Azure.Communication.CallAutomation.RecognizeFailed RecognizeFailed(string callConnectionId = null, string serverCallId = null, string correlationId = null, string operationContext = null, Azure.Communication.CallAutomation.ResultInformation resultInformation = null) { throw null; }
        public static Azure.Communication.CallAutomation.RecordingStateChanged RecordingStateChanged(string callConnectionId = null, string serverCallId = null, string correlationId = null, string recordingId = null, Azure.Communication.CallAutomation.RecordingState state = default(Azure.Communication.CallAutomation.RecordingState), System.DateTimeOffset? startDateTime = default(System.DateTimeOffset?)) { throw null; }
        public static Azure.Communication.CallAutomation.RecordingStateResult RecordingStateResult(string recordingId = null, Azure.Communication.CallAutomation.RecordingState? recordingState = default(Azure.Communication.CallAutomation.RecordingState?)) { throw null; }
        public static Azure.Communication.CallAutomation.RemoveParticipantFailed RemoveParticipantFailed(string callConnectionId = null, string serverCallId = null, string correlationId = null, string operationContext = null, Azure.Communication.CallAutomation.ResultInformation resultInformation = null, Azure.Communication.CommunicationIdentifier participant = null) { throw null; }
        public static Azure.Communication.CallAutomation.RemoveParticipantResult RemoveParticipantResult(string operationContext = null) { throw null; }
        public static Azure.Communication.CallAutomation.RemoveParticipantSucceeded RemoveParticipantSucceeded(string callConnectionId = null, string serverCallId = null, string correlationId = null, string operationContext = null, Azure.Communication.CallAutomation.ResultInformation resultInformation = null, Azure.Communication.CommunicationIdentifier participant = null) { throw null; }
        public static Azure.Communication.CallAutomation.ResultInformation ResultInformation(int? code = default(int?), int? subCode = default(int?), string message = null) { throw null; }
        public static Azure.Communication.CallAutomation.SendDtmfTonesCompleted SendDtmfTonesCompleted(string callConnectionId = null, string serverCallId = null, string correlationId = null, string operationContext = null, Azure.Communication.CallAutomation.ResultInformation resultInformation = null) { throw null; }
        public static Azure.Communication.CallAutomation.SendDtmfTonesFailed SendDtmfTonesFailed(string callConnectionId = null, string serverCallId = null, string correlationId = null, string operationContext = null, Azure.Communication.CallAutomation.ResultInformation resultInformation = null) { throw null; }
        public static Azure.Communication.CallAutomation.SpeechResult SpeechResult(string speech = null) { throw null; }
        public static Azure.Communication.CallAutomation.ToneInfo ToneInfo(int sequenceId = 0, Azure.Communication.CallAutomation.DtmfTone tone = default(Azure.Communication.CallAutomation.DtmfTone)) { throw null; }
        public static Azure.Communication.CallAutomation.TransferCallToParticipantResult TransferCallToParticipantResult(string operationContext = null) { throw null; }
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
    public partial class ContinuousDtmfRecognitionStopped : Azure.Communication.CallAutomation.CallAutomationEventBase
    {
        internal ContinuousDtmfRecognitionStopped() { }
        public static Azure.Communication.CallAutomation.ContinuousDtmfRecognitionStopped Deserialize(string content) { throw null; }
    }
    public partial class ContinuousDtmfRecognitionToneFailed : Azure.Communication.CallAutomation.CallAutomationEventBase
    {
        internal ContinuousDtmfRecognitionToneFailed() { }
        public static Azure.Communication.CallAutomation.ContinuousDtmfRecognitionToneFailed Deserialize(string content) { throw null; }
    }
    public partial class ContinuousDtmfRecognitionToneReceived : Azure.Communication.CallAutomation.CallAutomationEventBase
    {
        internal ContinuousDtmfRecognitionToneReceived() { }
        public Azure.Communication.CallAutomation.ToneInfo ToneInfo { get { throw null; } }
        public static Azure.Communication.CallAutomation.ContinuousDtmfRecognitionToneReceived Deserialize(string content) { throw null; }
    }
    public partial class CreateCallEventResult
    {
        internal CreateCallEventResult() { }
        public bool IsSuccess { get { throw null; } }
        public Azure.Communication.CallAutomation.CallConnected SuccessResult { get { throw null; } }
    }
    public partial class CreateCallOptions
    {
        public CreateCallOptions(Azure.Communication.CallAutomation.CallInvite callInvite, System.Uri callbackUri) { }
        public System.Uri CallbackUri { get { throw null; } }
        public Azure.Communication.CallAutomation.CallInvite CallInvite { get { throw null; } }
        public System.Uri CognitiveServicesEndpoint { get { throw null; } set { } }
        public string OperationContext { get { throw null; } set { } }
    }
    public partial class CreateCallResult
    {
        internal CreateCallResult() { }
        public Azure.Communication.CallAutomation.CallConnection CallConnection { get { throw null; } }
        public Azure.Communication.CallAutomation.CallConnectionProperties CallConnectionProperties { get { throw null; } }
        public Azure.Communication.CallAutomation.CreateCallEventResult WaitForEventProcessor(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public System.Threading.Tasks.Task<Azure.Communication.CallAutomation.CreateCallEventResult> WaitForEventProcessorAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class CreateGroupCallOptions
    {
        public CreateGroupCallOptions(System.Collections.Generic.IEnumerable<Azure.Communication.CommunicationIdentifier> targets, System.Uri callbackUri) { }
        public System.Uri CallbackUri { get { throw null; } }
        public System.Uri CognitiveServicesEndpoint { get { throw null; } set { } }
        public string OperationContext { get { throw null; } set { } }
        public Azure.Communication.PhoneNumberIdentifier SourceCallerIdNumber { get { throw null; } set { } }
        public string SourceDisplayName { get { throw null; } set { } }
        public System.Collections.Generic.IEnumerable<Azure.Communication.CommunicationIdentifier> Targets { get { throw null; } }
    }
    public partial class DtmfResult : Azure.Communication.CallAutomation.RecognizeResult
    {
        internal DtmfResult() { }
        public override Azure.Communication.CallAutomation.RecognizeResultType ResultType { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Communication.CallAutomation.DtmfTone> Tones { get { throw null; } }
        public string ConvertToString() { throw null; }
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
        public char ToChar() { throw null; }
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
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MediaEventReasonCode : System.IEquatable<Azure.Communication.CallAutomation.MediaEventReasonCode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MediaEventReasonCode(string value) { throw null; }
        public static Azure.Communication.CallAutomation.MediaEventReasonCode CognitiveServicesError { get { throw null; } }
        public static Azure.Communication.CallAutomation.MediaEventReasonCode CompletedSuccessfully { get { throw null; } }
        public static Azure.Communication.CallAutomation.MediaEventReasonCode PlayDownloadFailed { get { throw null; } }
        public static Azure.Communication.CallAutomation.MediaEventReasonCode PlayInvalidFileFormat { get { throw null; } }
        public static Azure.Communication.CallAutomation.MediaEventReasonCode RecognizeDtmfOptionMatched { get { throw null; } }
        public static Azure.Communication.CallAutomation.MediaEventReasonCode RecognizeIncorrectToneDetected { get { throw null; } }
        public static Azure.Communication.CallAutomation.MediaEventReasonCode RecognizeInitialSilenceTimedOut { get { throw null; } }
        public static Azure.Communication.CallAutomation.MediaEventReasonCode RecognizeInterDigitTimedOut { get { throw null; } }
        public static Azure.Communication.CallAutomation.MediaEventReasonCode RecognizeMaxDigitsReceived { get { throw null; } }
        public static Azure.Communication.CallAutomation.MediaEventReasonCode RecognizePlayPromptFailed { get { throw null; } }
        public static Azure.Communication.CallAutomation.MediaEventReasonCode RecognizeSpeechNotRecognized { get { throw null; } }
        public static Azure.Communication.CallAutomation.MediaEventReasonCode RecognizeSpeechOptionMatched { get { throw null; } }
        public static Azure.Communication.CallAutomation.MediaEventReasonCode RecognizeSpeechOptionNotMatched { get { throw null; } }
        public static Azure.Communication.CallAutomation.MediaEventReasonCode RecognizeSpeechServiceConnectionError { get { throw null; } }
        public static Azure.Communication.CallAutomation.MediaEventReasonCode RecognizeStopToneDetected { get { throw null; } }
        public static Azure.Communication.CallAutomation.MediaEventReasonCode UnspecifiedError { get { throw null; } }
        public bool Equals(Azure.Communication.CallAutomation.MediaEventReasonCode other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public int GetReasonCodeValue() { throw null; }
        public static bool operator ==(Azure.Communication.CallAutomation.MediaEventReasonCode left, Azure.Communication.CallAutomation.MediaEventReasonCode right) { throw null; }
        public static implicit operator Azure.Communication.CallAutomation.MediaEventReasonCode (string value) { throw null; }
        public static bool operator !=(Azure.Communication.CallAutomation.MediaEventReasonCode left, Azure.Communication.CallAutomation.MediaEventReasonCode right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class MuteParticipantResult
    {
        internal MuteParticipantResult() { }
        public string OperationContext { get { throw null; } }
    }
    public partial class MuteParticipantsResult
    {
        internal MuteParticipantsResult() { }
        public string OperationContext { get { throw null; } }
    }
    public partial class ParticipantsUpdated : Azure.Communication.CallAutomation.CallAutomationEventBase
    {
        internal ParticipantsUpdated() { }
        public System.Collections.Generic.IReadOnlyList<Azure.Communication.CallAutomation.CallParticipant> Participants { get { throw null; } }
        public int? SequenceNumber { get { throw null; } }
        public static Azure.Communication.CallAutomation.ParticipantsUpdated Deserialize(string content) { throw null; }
    }
    public partial class PlayCanceled : Azure.Communication.CallAutomation.CallAutomationEventBase
    {
        internal PlayCanceled() { }
        public static Azure.Communication.CallAutomation.PlayCanceled Deserialize(string content) { throw null; }
    }
    public partial class PlayCompleted : Azure.Communication.CallAutomation.CallAutomationEventBase
    {
        internal PlayCompleted() { }
        public Azure.Communication.CallAutomation.MediaEventReasonCode ReasonCode { get { throw null; } }
        public static Azure.Communication.CallAutomation.PlayCompleted Deserialize(string content) { throw null; }
    }
    public partial class PlayEventResult
    {
        internal PlayEventResult() { }
        public Azure.Communication.CallAutomation.PlayFailed FailureResult { get { throw null; } }
        public bool IsSuccess { get { throw null; } }
        public Azure.Communication.CallAutomation.PlayCompleted SuccessResult { get { throw null; } }
    }
    public partial class PlayFailed : Azure.Communication.CallAutomation.CallAutomationEventBase
    {
        internal PlayFailed() { }
        public Azure.Communication.CallAutomation.MediaEventReasonCode ReasonCode { get { throw null; } }
        public static Azure.Communication.CallAutomation.PlayFailed Deserialize(string content) { throw null; }
    }
    public partial class PlayOptions
    {
        public PlayOptions(Azure.Communication.CallAutomation.PlaySource playSource, System.Collections.Generic.IEnumerable<Azure.Communication.CommunicationIdentifier> playTo) { }
        public PlayOptions(System.Collections.Generic.IEnumerable<Azure.Communication.CallAutomation.PlaySource> playSources, System.Collections.Generic.IEnumerable<Azure.Communication.CommunicationIdentifier> playTo) { }
        public bool Loop { get { throw null; } set { } }
        public string OperationContext { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<Azure.Communication.CallAutomation.PlaySource> PlaySources { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Communication.CommunicationIdentifier> PlayTo { get { throw null; } }
    }
    public partial class PlayResult
    {
        internal PlayResult() { }
        public Azure.Communication.CallAutomation.PlayEventResult WaitForEventProcessor(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public System.Threading.Tasks.Task<Azure.Communication.CallAutomation.PlayEventResult> WaitForEventProcessorAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public abstract partial class PlaySource
    {
        protected PlaySource() { }
        public string PlaySourceCacheId { get { throw null; } set { } }
    }
    public partial class PlayToAllOptions
    {
        public PlayToAllOptions(Azure.Communication.CallAutomation.PlaySource playSource) { }
        public PlayToAllOptions(System.Collections.Generic.IEnumerable<Azure.Communication.CallAutomation.PlaySource> playSources) { }
        public bool Loop { get { throw null; } set { } }
        public string OperationContext { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<Azure.Communication.CallAutomation.PlaySource> PlaySources { get { throw null; } }
    }
    public partial class RecognitionChoice
    {
        public RecognitionChoice(string label, System.Collections.Generic.IEnumerable<string> phrases) { }
        public string Label { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Phrases { get { throw null; } }
        public Azure.Communication.CallAutomation.DtmfTone? Tone { get { throw null; } set { } }
    }
    public partial class RecognizeCanceled : Azure.Communication.CallAutomation.CallAutomationEventBase
    {
        internal RecognizeCanceled() { }
        public static Azure.Communication.CallAutomation.RecognizeCanceled Deserialize(string content) { throw null; }
    }
    public partial class RecognizeCompleted : Azure.Communication.CallAutomation.CallAutomationEventBase
    {
        internal RecognizeCompleted() { }
        public Azure.Communication.CallAutomation.CallMediaRecognitionType RecognitionType { get { throw null; } set { } }
        public Azure.Communication.CallAutomation.RecognizeResult RecognizeResult { get { throw null; } }
        public static Azure.Communication.CallAutomation.RecognizeCompleted Deserialize(string content) { throw null; }
        public string Serialize() { throw null; }
    }
    public partial class RecognizeFailed : Azure.Communication.CallAutomation.CallAutomationEventBase
    {
        internal RecognizeFailed() { }
        public Azure.Communication.CallAutomation.MediaEventReasonCode ReasonCode { get { throw null; } }
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
        public static Azure.Communication.CallAutomation.RecognizeInputType Speech { get { throw null; } }
        public static Azure.Communication.CallAutomation.RecognizeInputType SpeechOrDtmf { get { throw null; } }
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
        public abstract Azure.Communication.CallAutomation.RecognizeResultType ResultType { get; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RecognizeResultType : System.IEquatable<Azure.Communication.CallAutomation.RecognizeResultType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RecognizeResultType(string value) { throw null; }
        public static Azure.Communication.CallAutomation.RecognizeResultType ChoiceResult { get { throw null; } }
        public static Azure.Communication.CallAutomation.RecognizeResultType DtmfResult { get { throw null; } }
        public static Azure.Communication.CallAutomation.RecognizeResultType SpeechResult { get { throw null; } }
        public bool Equals(Azure.Communication.CallAutomation.RecognizeResultType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Communication.CallAutomation.RecognizeResultType left, Azure.Communication.CallAutomation.RecognizeResultType right) { throw null; }
        public static implicit operator Azure.Communication.CallAutomation.RecognizeResultType (string value) { throw null; }
        public static bool operator !=(Azure.Communication.CallAutomation.RecognizeResultType left, Azure.Communication.CallAutomation.RecognizeResultType right) { throw null; }
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
    public partial class RedirectCallOptions
    {
        public RedirectCallOptions(string incomingCallContext, Azure.Communication.CallAutomation.CallInvite callInvite) { }
        public Azure.Communication.CallAutomation.CallInvite CallInvite { get { throw null; } }
        public string IncomingCallContext { get { throw null; } }
    }
    public partial class RejectCallOptions
    {
        public RejectCallOptions(string incomingCallContext) { }
        public Azure.Communication.CallAutomation.CallRejectReason CallRejectReason { get { throw null; } set { } }
        public string IncomingCallContext { get { throw null; } }
    }
    public partial class RemoveParticipantEventResult
    {
        internal RemoveParticipantEventResult() { }
        public Azure.Communication.CallAutomation.RemoveParticipantFailed FailureResult { get { throw null; } }
        public bool IsSuccess { get { throw null; } }
        public Azure.Communication.CommunicationIdentifier Participant { get { throw null; } }
        public Azure.Communication.CallAutomation.RemoveParticipantSucceeded SuccessResult { get { throw null; } }
    }
    public partial class RemoveParticipantFailed : Azure.Communication.CallAutomation.CallAutomationEventBase
    {
        internal RemoveParticipantFailed() { }
        public Azure.Communication.CommunicationIdentifier Participant { get { throw null; } }
        public static Azure.Communication.CallAutomation.RemoveParticipantFailed Deserialize(string content) { throw null; }
    }
    public partial class RemoveParticipantOptions
    {
        public RemoveParticipantOptions(Azure.Communication.CommunicationIdentifier participantToRemove) { }
        public string OperationContext { get { throw null; } set { } }
        public Azure.Communication.CommunicationIdentifier ParticipantToRemove { get { throw null; } }
    }
    public partial class RemoveParticipantResult
    {
        internal RemoveParticipantResult() { }
        public string OperationContext { get { throw null; } }
        public Azure.Communication.CallAutomation.RemoveParticipantEventResult WaitForEventProcessor(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public System.Threading.Tasks.Task<Azure.Communication.CallAutomation.RemoveParticipantEventResult> WaitForEventProcessorAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class RemoveParticipantSucceeded : Azure.Communication.CallAutomation.CallAutomationEventBase
    {
        internal RemoveParticipantSucceeded() { }
        public Azure.Communication.CommunicationIdentifier Participant { get { throw null; } }
        public static Azure.Communication.CallAutomation.RemoveParticipantSucceeded Deserialize(string content) { throw null; }
    }
    public partial class ResultInformation
    {
        internal ResultInformation() { }
        public int? Code { get { throw null; } }
        public string Message { get { throw null; } }
        public int? SubCode { get { throw null; } }
    }
    public partial class SendDtmfTonesCompleted : Azure.Communication.CallAutomation.CallAutomationEventBase
    {
        internal SendDtmfTonesCompleted() { }
        public static Azure.Communication.CallAutomation.SendDtmfTonesCompleted Deserialize(string content) { throw null; }
    }
    public partial class SendDtmfTonesEventResult
    {
        internal SendDtmfTonesEventResult() { }
        public Azure.Communication.CallAutomation.SendDtmfTonesFailed FailureResult { get { throw null; } }
        public bool IsSuccess { get { throw null; } }
        public Azure.Communication.CallAutomation.SendDtmfTonesCompleted SuccessResult { get { throw null; } }
    }
    public partial class SendDtmfTonesFailed : Azure.Communication.CallAutomation.CallAutomationEventBase
    {
        internal SendDtmfTonesFailed() { }
        public static Azure.Communication.CallAutomation.SendDtmfTonesFailed Deserialize(string content) { throw null; }
    }
    public partial class SendDtmfTonesResult
    {
        internal SendDtmfTonesResult() { }
        public string OperationContext { get { throw null; } }
        public Azure.Communication.CallAutomation.SendDtmfTonesEventResult WaitForEventProcessor(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public System.Threading.Tasks.Task<Azure.Communication.CallAutomation.SendDtmfTonesEventResult> WaitForEventProcessorAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ServerCallLocator : Azure.Communication.CallAutomation.CallLocator
    {
        public ServerCallLocator(string id) { }
        public override bool Equals(Azure.Communication.CallAutomation.CallLocator other) { throw null; }
        public override int GetHashCode() { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SpeechResult : Azure.Communication.CallAutomation.RecognizeResult
    {
        internal SpeechResult() { }
        public override Azure.Communication.CallAutomation.RecognizeResultType ResultType { get { throw null; } }
        public string Speech { get { throw null; } }
    }
    public partial class SsmlSource : Azure.Communication.CallAutomation.PlaySource
    {
        public SsmlSource(string ssmlText) { }
        public string CustomVoiceEndpointId { get { throw null; } set { } }
        public string SsmlText { get { throw null; } }
    }
    public partial class StartRecognizingCallMediaResult
    {
        internal StartRecognizingCallMediaResult() { }
        public Azure.Communication.CallAutomation.StartRecognizingEventResult WaitForEventProcessor(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public System.Threading.Tasks.Task<Azure.Communication.CallAutomation.StartRecognizingEventResult> WaitForEventProcessorAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class StartRecognizingEventResult
    {
        internal StartRecognizingEventResult() { }
        public Azure.Communication.CallAutomation.RecognizeFailed FailureResult { get { throw null; } }
        public bool IsSuccess { get { throw null; } }
        public Azure.Communication.CallAutomation.RecognizeCompleted SuccessResult { get { throw null; } }
    }
    public partial class StartRecordingOptions
    {
        public StartRecordingOptions(Azure.Communication.CallAutomation.CallLocator callLocator) { }
        public System.Collections.Generic.IList<Azure.Communication.CommunicationIdentifier> AudioChannelParticipantOrdering { get { throw null; } }
        public System.Collections.Generic.IList<Azure.Communication.CallAutomation.ChannelAffinity> ChannelAffinity { get { throw null; } set { } }
        public Azure.Communication.CallAutomation.RecordingChannel RecordingChannel { get { throw null; } set { } }
        public Azure.Communication.CallAutomation.RecordingContent RecordingContent { get { throw null; } set { } }
        public Azure.Communication.CallAutomation.RecordingFormat RecordingFormat { get { throw null; } set { } }
        public System.Uri RecordingStateCallbackUri { get { throw null; } set { } }
    }
    public partial class TextSource : Azure.Communication.CallAutomation.PlaySource
    {
        public TextSource(string text) { }
        public TextSource(string text, string voiceName) { }
        public TextSource(string text, string sourceLocale, Azure.Communication.CallAutomation.VoiceKind voiceKind) { }
        public string CustomVoiceEndpointId { get { throw null; } set { } }
        public string SourceLocale { get { throw null; } set { } }
        public string Text { get { throw null; } }
        public Azure.Communication.CallAutomation.VoiceKind? VoiceKind { get { throw null; } set { } }
        public string VoiceName { get { throw null; } set { } }
    }
    public partial class ToneInfo
    {
        internal ToneInfo() { }
        public int SequenceId { get { throw null; } }
        public Azure.Communication.CallAutomation.DtmfTone Tone { get { throw null; } }
    }
    public partial class TransferCallToParticipantEventResult
    {
        internal TransferCallToParticipantEventResult() { }
        public Azure.Communication.CallAutomation.CallTransferFailed FailureResult { get { throw null; } }
        public bool IsSuccess { get { throw null; } }
        public Azure.Communication.CallAutomation.CallTransferAccepted SuccessResult { get { throw null; } }
    }
    public partial class TransferCallToParticipantResult
    {
        internal TransferCallToParticipantResult() { }
        public string OperationContext { get { throw null; } }
        public Azure.Communication.CallAutomation.TransferCallToParticipantEventResult WaitForEventProcessor(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public System.Threading.Tasks.Task<Azure.Communication.CallAutomation.TransferCallToParticipantEventResult> WaitForEventProcessorAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class TransferToParticipantOptions
    {
        public TransferToParticipantOptions(Azure.Communication.CommunicationUserIdentifier targetIdentity) { }
        public TransferToParticipantOptions(Azure.Communication.MicrosoftTeamsUserIdentifier targetIdentity) { }
        public TransferToParticipantOptions(Azure.Communication.PhoneNumberIdentifier targetPhoneNumberIdentity) { }
        public string OperationContext { get { throw null; } set { } }
        public Azure.Communication.CommunicationIdentifier Target { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct VoiceKind : System.IEquatable<Azure.Communication.CallAutomation.VoiceKind>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public VoiceKind(string value) { throw null; }
        public static Azure.Communication.CallAutomation.VoiceKind Female { get { throw null; } }
        public static Azure.Communication.CallAutomation.VoiceKind Male { get { throw null; } }
        public bool Equals(Azure.Communication.CallAutomation.VoiceKind other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Communication.CallAutomation.VoiceKind left, Azure.Communication.CallAutomation.VoiceKind right) { throw null; }
        public static implicit operator Azure.Communication.CallAutomation.VoiceKind (string value) { throw null; }
        public static bool operator !=(Azure.Communication.CallAutomation.VoiceKind left, Azure.Communication.CallAutomation.VoiceKind right) { throw null; }
        public override string ToString() { throw null; }
    }
}
