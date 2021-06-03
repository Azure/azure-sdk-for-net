namespace Azure.Communication.Calling.Server
{
    public static partial class AzureCommunicationCallingServerServiceModelFactory
    {
        public static Azure.Communication.Calling.Server.CancelAllMediaOperationsResponse CancelAllMediaOperationsResponse(string id = null, Azure.Communication.Calling.Server.OperationStatus? status = default(Azure.Communication.Calling.Server.OperationStatus?), string operationContext = null, Azure.Communication.Calling.Server.ResultInfo resultInfo = null) { throw null; }
        public static Azure.Communication.Calling.Server.CreateCallResponse CreateCallResponse(string callLegId = null) { throw null; }
        public static Azure.Communication.Calling.Server.GetCallRecordingStateResponse GetCallRecordingStateResponse(Azure.Communication.Calling.Server.CallRecordingState? recordingState = default(Azure.Communication.Calling.Server.CallRecordingState?)) { throw null; }
        public static Azure.Communication.Calling.Server.JoinCallResponse JoinCallResponse(string callLegId = null) { throw null; }
        public static Azure.Communication.Calling.Server.PlayAudioResponse PlayAudioResponse(string id = null, Azure.Communication.Calling.Server.OperationStatus? status = default(Azure.Communication.Calling.Server.OperationStatus?), string operationContext = null, Azure.Communication.Calling.Server.ResultInfo resultInfo = null) { throw null; }
        public static Azure.Communication.Calling.Server.ResultInfo ResultInfo(int? code = default(int?), int? subcode = default(int?), string message = null) { throw null; }
        public static Azure.Communication.Calling.Server.StartCallRecordingResponse StartCallRecordingResponse(string recordingId = null) { throw null; }
    }
    public partial class CallClient
    {
        protected CallClient() { }
        public CallClient(string connectionString) { }
        public CallClient(string connectionString, Azure.Communication.Calling.Server.CallClientOptions options = null) { }
        public CallClient(System.Uri endpoint, Azure.AzureKeyCredential keyCredential, Azure.Communication.Calling.Server.CallClientOptions options = null) { }
        public CallClient(System.Uri endpoint, Azure.Core.TokenCredential tokenCredential, Azure.Communication.Calling.Server.CallClientOptions options = null) { }
        public virtual Azure.Response AddParticipant(string callLegId, Azure.Communication.CommunicationIdentifier participant, string alternateCallerId = null, string operationContext = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> AddParticipantAsync(string callLegId, Azure.Communication.CommunicationIdentifier participant, string alternateCallerId = null, string operationContext = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Communication.Calling.Server.CancelAllMediaOperationsResponse> CancelAllMediaOperations(string callLegId, string operationContext = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Communication.Calling.Server.CancelAllMediaOperationsResponse>> CancelAllMediaOperationsAsync(string callLegId, string operationContext = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Communication.Calling.Server.CreateCallResponse> CreateCall(Azure.Communication.CommunicationIdentifier source, System.Collections.Generic.IEnumerable<Azure.Communication.CommunicationIdentifier> targets, Azure.Communication.Calling.Server.CreateCallOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Communication.Calling.Server.CreateCallResponse>> CreateCallAsync(Azure.Communication.CommunicationIdentifier source, System.Collections.Generic.IEnumerable<Azure.Communication.CommunicationIdentifier> targets, Azure.Communication.Calling.Server.CreateCallOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response DeleteCall(string callLegId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteCallAsync(string callLegId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response HangupCall(string callLegId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> HangupCallAsync(string callLegId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Communication.Calling.Server.PlayAudioResponse> PlayAudio(string callLegId, Azure.Communication.Calling.Server.PlayAudioOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Communication.Calling.Server.PlayAudioResponse> PlayAudio(string callLegId, System.Uri audioFileUri, bool? loop, string audioFileId, System.Uri callbackUri, string operationContext = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Communication.Calling.Server.PlayAudioResponse>> PlayAudioAsync(string callLegId, Azure.Communication.Calling.Server.PlayAudioOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Communication.Calling.Server.PlayAudioResponse>> PlayAudioAsync(string callLegId, System.Uri audioFileUri, bool? loop, string audioFileId, System.Uri callbackUri, string operationContext = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response RemoveParticipant(string callLegId, string participantId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> RemoveParticipantAsync(string callLegId, string participantId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class CallClientOptions : Azure.Core.ClientOptions
    {
        public const Azure.Communication.Calling.Server.CallClientOptions.ServiceVersion LatestVersion = Azure.Communication.Calling.Server.CallClientOptions.ServiceVersion.V2021_04_15_Preview1;
        public CallClientOptions(Azure.Communication.Calling.Server.CallClientOptions.ServiceVersion version = Azure.Communication.Calling.Server.CallClientOptions.ServiceVersion.V2021_04_15_Preview1) { }
        public enum ServiceVersion
        {
            V2021_04_15_Preview1 = 0,
        }
    }
    public abstract partial class CallingServerEventBase
    {
        protected CallingServerEventBase() { }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct CallingServerEventType : System.IEquatable<Azure.Communication.Calling.Server.CallingServerEventType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public CallingServerEventType(string value) { throw null; }
        public static Azure.Communication.Calling.Server.CallingServerEventType CallLegStateChangedEvent { get { throw null; } }
        public static Azure.Communication.Calling.Server.CallingServerEventType CallRecordingStateChangeEvent { get { throw null; } }
        public static Azure.Communication.Calling.Server.CallingServerEventType InviteParticipantsResultEvent { get { throw null; } }
        public static Azure.Communication.Calling.Server.CallingServerEventType ParticipantsUpdatedEvent { get { throw null; } }
        public static Azure.Communication.Calling.Server.CallingServerEventType PlayAudioResultEvent { get { throw null; } }
        public static Azure.Communication.Calling.Server.CallingServerEventType ToneReceivedEvent { get { throw null; } }
        public bool Equals(Azure.Communication.Calling.Server.CallingServerEventType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Communication.Calling.Server.CallingServerEventType left, Azure.Communication.Calling.Server.CallingServerEventType right) { throw null; }
        public static bool operator !=(Azure.Communication.Calling.Server.CallingServerEventType left, Azure.Communication.Calling.Server.CallingServerEventType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class CallLegStateChangedEvent : Azure.Communication.Calling.Server.CallingServerEventBase
    {
        public CallLegStateChangedEvent() { }
        public string CallLegId { get { throw null; } set { } }
        public Azure.Communication.Calling.Server.CallState? CallState { get { throw null; } set { } }
        public string ConversationId { get { throw null; } set { } }
        public static Azure.Communication.Calling.Server.CallLegStateChangedEvent Deserialize(string content) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct CallModality : System.IEquatable<Azure.Communication.Calling.Server.CallModality>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public CallModality(string value) { throw null; }
        public static Azure.Communication.Calling.Server.CallModality Audio { get { throw null; } }
        public static Azure.Communication.Calling.Server.CallModality Video { get { throw null; } }
        public bool Equals(Azure.Communication.Calling.Server.CallModality other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Communication.Calling.Server.CallModality left, Azure.Communication.Calling.Server.CallModality right) { throw null; }
        public static implicit operator Azure.Communication.Calling.Server.CallModality (string value) { throw null; }
        public static bool operator !=(Azure.Communication.Calling.Server.CallModality left, Azure.Communication.Calling.Server.CallModality right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct CallRecordingState : System.IEquatable<Azure.Communication.Calling.Server.CallRecordingState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public CallRecordingState(string value) { throw null; }
        public static Azure.Communication.Calling.Server.CallRecordingState Active { get { throw null; } }
        public static Azure.Communication.Calling.Server.CallRecordingState Inactive { get { throw null; } }
        public bool Equals(Azure.Communication.Calling.Server.CallRecordingState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Communication.Calling.Server.CallRecordingState left, Azure.Communication.Calling.Server.CallRecordingState right) { throw null; }
        public static implicit operator Azure.Communication.Calling.Server.CallRecordingState (string value) { throw null; }
        public static bool operator !=(Azure.Communication.Calling.Server.CallRecordingState left, Azure.Communication.Calling.Server.CallRecordingState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class CallRecordingStateChangeEvent : Azure.Communication.Calling.Server.CallingServerEventBase
    {
        public CallRecordingStateChangeEvent() { }
        public string ConversationId { get { throw null; } set { } }
        public string RecordingId { get { throw null; } set { } }
        public System.DateTimeOffset? StartDateTime { get { throw null; } set { } }
        public Azure.Communication.Calling.Server.CallRecordingState? State { get { throw null; } set { } }
        public static Azure.Communication.Calling.Server.CallRecordingStateChangeEvent Deserialize(string content) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct CallState : System.IEquatable<Azure.Communication.Calling.Server.CallState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public CallState(string value) { throw null; }
        public static Azure.Communication.Calling.Server.CallState Established { get { throw null; } }
        public static Azure.Communication.Calling.Server.CallState Establishing { get { throw null; } }
        public static Azure.Communication.Calling.Server.CallState Hold { get { throw null; } }
        public static Azure.Communication.Calling.Server.CallState Idle { get { throw null; } }
        public static Azure.Communication.Calling.Server.CallState Incoming { get { throw null; } }
        public static Azure.Communication.Calling.Server.CallState Redirecting { get { throw null; } }
        public static Azure.Communication.Calling.Server.CallState Terminated { get { throw null; } }
        public static Azure.Communication.Calling.Server.CallState Terminating { get { throw null; } }
        public static Azure.Communication.Calling.Server.CallState Transferring { get { throw null; } }
        public static Azure.Communication.Calling.Server.CallState Unhold { get { throw null; } }
        public static Azure.Communication.Calling.Server.CallState Unknown { get { throw null; } }
        public bool Equals(Azure.Communication.Calling.Server.CallState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Communication.Calling.Server.CallState left, Azure.Communication.Calling.Server.CallState right) { throw null; }
        public static implicit operator Azure.Communication.Calling.Server.CallState (string value) { throw null; }
        public static bool operator !=(Azure.Communication.Calling.Server.CallState left, Azure.Communication.Calling.Server.CallState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class CancelAllMediaOperationsResponse
    {
        internal CancelAllMediaOperationsResponse() { }
        public string Id { get { throw null; } }
        public string OperationContext { get { throw null; } }
        public Azure.Communication.Calling.Server.ResultInfo ResultInfo { get { throw null; } }
        public Azure.Communication.Calling.Server.OperationStatus? Status { get { throw null; } }
    }
    public partial class CommunicationParticipant
    {
        public CommunicationParticipant() { }
        public CommunicationParticipant(Azure.Communication.CommunicationIdentifier identifier, string participantId, bool? isMuted) { }
        public Azure.Communication.CommunicationIdentifier Identifier { get { throw null; } set { } }
        public bool? IsMuted { get { throw null; } set { } }
        public string ParticipantId { get { throw null; } set { } }
    }
    public partial class ConversationClient
    {
        protected ConversationClient() { }
        public ConversationClient(string connectionString, Azure.Communication.Calling.Server.CallClientOptions options = null) { }
        public ConversationClient(System.Uri endpoint, Azure.AzureKeyCredential keyCredential, Azure.Communication.Calling.Server.CallClientOptions options = null) { }
        public ConversationClient(System.Uri endpoint, Azure.Core.TokenCredential tokenCredential, Azure.Communication.Calling.Server.CallClientOptions options = null) { }
        public virtual Azure.Response AddParticipant(string conversationId, Azure.Communication.CommunicationIdentifier participant, System.Uri callbackUri, string alternateCallerId = null, string operationContext = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> AddParticipantAsync(string conversationId, Azure.Communication.CommunicationIdentifier participant, System.Uri callbackUri, string alternateCallerId = null, string operationContext = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Communication.Calling.Server.GetCallRecordingStateResponse> GetRecordingState(string conversationId, string recordingId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Communication.Calling.Server.GetCallRecordingStateResponse>> GetRecordingStateAsync(string conversationId, string recordingId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Communication.Calling.Server.JoinCallResponse> JoinCall(string conversationId, Azure.Communication.CommunicationIdentifier source, Azure.Communication.Calling.Server.CreateCallOptions callOptions, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Communication.Calling.Server.JoinCallResponse>> JoinCallAsync(string conversationId, Azure.Communication.CommunicationIdentifier source, Azure.Communication.Calling.Server.CreateCallOptions callOptions, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response PauseRecording(string conversationId, string recordingId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> PauseRecordingAsync(string conversationId, string recordingId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Communication.Calling.Server.PlayAudioResponse> PlayAudio(string conversationId, System.Uri audioFileUri, string audioFileId = null, System.Uri callbackUri = null, string operationContext = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Communication.Calling.Server.PlayAudioResponse>> PlayAudioAsync(string conversationId, System.Uri audioFileUri, string audioFileId = null, System.Uri callbackUri = null, string operationContext = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response RemoveParticipant(string conversationId, string participantId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> RemoveParticipantAsync(string conversationId, string participantId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response ResumeRecording(string conversationId, string recordingId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> ResumeRecordingAsync(string conversationId, string recordingId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Communication.Calling.Server.StartCallRecordingResponse> StartRecording(string conversationId, System.Uri recordingStateCallbackUri, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Communication.Calling.Server.StartCallRecordingResponse>> StartRecordingAsync(string conversationId, System.Uri recordingStateCallbackUri, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response StopRecording(string conversationId, string recordingId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> StopRecordingAsync(string conversationId, string recordingId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class CreateCallOptions
    {
        public CreateCallOptions(System.Uri callbackUri, System.Collections.Generic.IEnumerable<Azure.Communication.Calling.Server.CallModality> requestedModalities, System.Collections.Generic.IEnumerable<Azure.Communication.Calling.Server.EventSubscriptionType> requestedCallEvents) { }
        public Azure.Communication.PhoneNumberIdentifier AlternateCallerId { get { throw null; } set { } }
        public System.Uri CallbackUri { get { throw null; } }
        public System.Collections.Generic.IList<Azure.Communication.Calling.Server.EventSubscriptionType> RequestedCallEvents { get { throw null; } }
        public System.Collections.Generic.IList<Azure.Communication.Calling.Server.CallModality> RequestedModalities { get { throw null; } }
        public string Subject { get { throw null; } set { } }
    }
    public partial class CreateCallResponse
    {
        internal CreateCallResponse() { }
        public string CallLegId { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct EventSubscriptionType : System.IEquatable<Azure.Communication.Calling.Server.EventSubscriptionType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public EventSubscriptionType(string value) { throw null; }
        public static Azure.Communication.Calling.Server.EventSubscriptionType DtmfReceived { get { throw null; } }
        public static Azure.Communication.Calling.Server.EventSubscriptionType ParticipantsUpdated { get { throw null; } }
        public bool Equals(Azure.Communication.Calling.Server.EventSubscriptionType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Communication.Calling.Server.EventSubscriptionType left, Azure.Communication.Calling.Server.EventSubscriptionType right) { throw null; }
        public static implicit operator Azure.Communication.Calling.Server.EventSubscriptionType (string value) { throw null; }
        public static bool operator !=(Azure.Communication.Calling.Server.EventSubscriptionType left, Azure.Communication.Calling.Server.EventSubscriptionType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class GetCallRecordingStateResponse
    {
        internal GetCallRecordingStateResponse() { }
        public Azure.Communication.Calling.Server.CallRecordingState? RecordingState { get { throw null; } }
    }
    public partial class InviteParticipantsResultEvent : Azure.Communication.Calling.Server.CallingServerEventBase
    {
        public InviteParticipantsResultEvent() { }
        public string OperationContext { get { throw null; } set { } }
        public Azure.Communication.Calling.Server.ResultInfo ResultInfo { get { throw null; } set { } }
        public Azure.Communication.Calling.Server.OperationStatus? Status { get { throw null; } set { } }
        public static Azure.Communication.Calling.Server.InviteParticipantsResultEvent Deserialize(string content) { throw null; }
    }
    public partial class JoinCallResponse
    {
        internal JoinCallResponse() { }
        public string CallLegId { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct OperationStatus : System.IEquatable<Azure.Communication.Calling.Server.OperationStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public OperationStatus(string value) { throw null; }
        public static Azure.Communication.Calling.Server.OperationStatus Completed { get { throw null; } }
        public static Azure.Communication.Calling.Server.OperationStatus Failed { get { throw null; } }
        public static Azure.Communication.Calling.Server.OperationStatus NotStarted { get { throw null; } }
        public static Azure.Communication.Calling.Server.OperationStatus Running { get { throw null; } }
        public bool Equals(Azure.Communication.Calling.Server.OperationStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Communication.Calling.Server.OperationStatus left, Azure.Communication.Calling.Server.OperationStatus right) { throw null; }
        public static implicit operator Azure.Communication.Calling.Server.OperationStatus (string value) { throw null; }
        public static bool operator !=(Azure.Communication.Calling.Server.OperationStatus left, Azure.Communication.Calling.Server.OperationStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ParticipantsUpdatedEvent : Azure.Communication.Calling.Server.CallingServerEventBase
    {
        public ParticipantsUpdatedEvent() { }
        public string CallLegId { get { throw null; } set { } }
        public System.Collections.Generic.IEnumerable<Azure.Communication.Calling.Server.CommunicationParticipant> Participants { get { throw null; } set { } }
        public static Azure.Communication.Calling.Server.ParticipantsUpdatedEvent Deserialize(string content) { throw null; }
    }
    public partial class PlayAudioOptions
    {
        public PlayAudioOptions() { }
        public string AudioFileId { get { throw null; } set { } }
        public System.Uri AudioFileUri { get { throw null; } set { } }
        public System.Uri CallbackUri { get { throw null; } set { } }
        public bool? Loop { get { throw null; } set { } }
        public string OperationContext { get { throw null; } set { } }
    }
    public partial class PlayAudioResponse
    {
        internal PlayAudioResponse() { }
        public string Id { get { throw null; } }
        public string OperationContext { get { throw null; } }
        public Azure.Communication.Calling.Server.ResultInfo ResultInfo { get { throw null; } }
        public Azure.Communication.Calling.Server.OperationStatus? Status { get { throw null; } }
    }
    public partial class PlayAudioResultEvent : Azure.Communication.Calling.Server.CallingServerEventBase
    {
        public PlayAudioResultEvent() { }
        public string OperationContext { get { throw null; } set { } }
        public Azure.Communication.Calling.Server.ResultInfo ResultInfo { get { throw null; } set { } }
        public Azure.Communication.Calling.Server.OperationStatus? Status { get { throw null; } set { } }
        public static Azure.Communication.Calling.Server.PlayAudioResultEvent Deserialize(string content) { throw null; }
    }
    public partial class ResultInfo
    {
        internal ResultInfo() { }
        public int? Code { get { throw null; } }
        public string Message { get { throw null; } }
        public int? Subcode { get { throw null; } }
    }
    public partial class StartCallRecordingResponse
    {
        internal StartCallRecordingResponse() { }
        public string RecordingId { get { throw null; } }
    }
    public partial class ToneInfo
    {
        public ToneInfo() { }
        public int? SequenceId { get { throw null; } set { } }
        public Azure.Communication.Calling.Server.ToneValue? Tone { get { throw null; } set { } }
    }
    public partial class ToneReceivedEvent : Azure.Communication.Calling.Server.CallingServerEventBase
    {
        public ToneReceivedEvent() { }
        public string CallLegId { get { throw null; } set { } }
        public Azure.Communication.Calling.Server.ToneInfo ToneInfo { get { throw null; } set { } }
        public static Azure.Communication.Calling.Server.ToneReceivedEvent Deserialize(string content) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ToneValue : System.IEquatable<Azure.Communication.Calling.Server.ToneValue>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ToneValue(string value) { throw null; }
        public static Azure.Communication.Calling.Server.ToneValue A { get { throw null; } }
        public static Azure.Communication.Calling.Server.ToneValue B { get { throw null; } }
        public static Azure.Communication.Calling.Server.ToneValue C { get { throw null; } }
        public static Azure.Communication.Calling.Server.ToneValue D { get { throw null; } }
        public static Azure.Communication.Calling.Server.ToneValue Flash { get { throw null; } }
        public static Azure.Communication.Calling.Server.ToneValue Pound { get { throw null; } }
        public static Azure.Communication.Calling.Server.ToneValue Star { get { throw null; } }
        public static Azure.Communication.Calling.Server.ToneValue Tone0 { get { throw null; } }
        public static Azure.Communication.Calling.Server.ToneValue Tone1 { get { throw null; } }
        public static Azure.Communication.Calling.Server.ToneValue Tone2 { get { throw null; } }
        public static Azure.Communication.Calling.Server.ToneValue Tone3 { get { throw null; } }
        public static Azure.Communication.Calling.Server.ToneValue Tone4 { get { throw null; } }
        public static Azure.Communication.Calling.Server.ToneValue Tone5 { get { throw null; } }
        public static Azure.Communication.Calling.Server.ToneValue Tone6 { get { throw null; } }
        public static Azure.Communication.Calling.Server.ToneValue Tone7 { get { throw null; } }
        public static Azure.Communication.Calling.Server.ToneValue Tone8 { get { throw null; } }
        public static Azure.Communication.Calling.Server.ToneValue Tone9 { get { throw null; } }
        public bool Equals(Azure.Communication.Calling.Server.ToneValue other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Communication.Calling.Server.ToneValue left, Azure.Communication.Calling.Server.ToneValue right) { throw null; }
        public static implicit operator Azure.Communication.Calling.Server.ToneValue (string value) { throw null; }
        public static bool operator !=(Azure.Communication.Calling.Server.ToneValue left, Azure.Communication.Calling.Server.ToneValue right) { throw null; }
        public override string ToString() { throw null; }
    }
}
