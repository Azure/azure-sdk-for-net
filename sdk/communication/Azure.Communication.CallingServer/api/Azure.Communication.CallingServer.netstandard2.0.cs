namespace Azure.Communication.CallingServer
{
    public static partial class AzureCommunicationCallingServerServiceModelFactory
    {
        public static Azure.Communication.CallingServer.CancelAllMediaOperationsResponse CancelAllMediaOperationsResponse(string id = null, Azure.Communication.CallingServer.OperationStatus? status = default(Azure.Communication.CallingServer.OperationStatus?), string operationContext = null, Azure.Communication.CallingServer.ResultInfo resultInfo = null) { throw null; }
        public static Azure.Communication.CallingServer.CreateCallResponse CreateCallResponse(string callLegId = null) { throw null; }
        public static Azure.Communication.CallingServer.GetCallRecordingStateResponse GetCallRecordingStateResponse(Azure.Communication.CallingServer.CallRecordingState? recordingState = default(Azure.Communication.CallingServer.CallRecordingState?)) { throw null; }
        public static Azure.Communication.CallingServer.JoinCallResponse JoinCallResponse(string callLegId = null) { throw null; }
        public static Azure.Communication.CallingServer.PlayAudioResponse PlayAudioResponse(string id = null, Azure.Communication.CallingServer.OperationStatus? status = default(Azure.Communication.CallingServer.OperationStatus?), string operationContext = null, Azure.Communication.CallingServer.ResultInfo resultInfo = null) { throw null; }
        public static Azure.Communication.CallingServer.ResultInfo ResultInfo(int? code = default(int?), int? subcode = default(int?), string message = null) { throw null; }
        public static Azure.Communication.CallingServer.StartCallRecordingResponse StartCallRecordingResponse(string recordingId = null) { throw null; }
    }
    public partial class CallClient
    {
        protected CallClient() { }
        public CallClient(string connectionString) { }
        public CallClient(string connectionString, Azure.Communication.CallingServer.CallClientOptions options = null) { }
        public CallClient(System.Uri endpoint, Azure.AzureKeyCredential keyCredential, Azure.Communication.CallingServer.CallClientOptions options = null) { }
        public CallClient(System.Uri endpoint, Azure.Core.TokenCredential tokenCredential, Azure.Communication.CallingServer.CallClientOptions options = null) { }
        public virtual Azure.Response AddParticipant(string callLegId, Azure.Communication.CommunicationIdentifier participant, string alternateCallerId = null, string operationContext = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> AddParticipantAsync(string callLegId, Azure.Communication.CommunicationIdentifier participant, string alternateCallerId = null, string operationContext = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Communication.CallingServer.CancelAllMediaOperationsResponse> CancelAllMediaOperations(string callLegId, string operationContext = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Communication.CallingServer.CancelAllMediaOperationsResponse>> CancelAllMediaOperationsAsync(string callLegId, string operationContext = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Communication.CallingServer.CreateCallResponse> CreateCall(Azure.Communication.CommunicationIdentifier source, System.Collections.Generic.IEnumerable<Azure.Communication.CommunicationIdentifier> targets, Azure.Communication.CallingServer.CreateCallOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Communication.CallingServer.CreateCallResponse>> CreateCallAsync(Azure.Communication.CommunicationIdentifier source, System.Collections.Generic.IEnumerable<Azure.Communication.CommunicationIdentifier> targets, Azure.Communication.CallingServer.CreateCallOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response DeleteCall(string callLegId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteCallAsync(string callLegId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response HangupCall(string callLegId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> HangupCallAsync(string callLegId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Communication.CallingServer.PlayAudioResponse> PlayAudio(string callLegId, Azure.Communication.CallingServer.PlayAudioOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Communication.CallingServer.PlayAudioResponse> PlayAudio(string callLegId, System.Uri audioFileUri, bool? loop, string audioFileId, System.Uri callbackUri, string operationContext = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Communication.CallingServer.PlayAudioResponse>> PlayAudioAsync(string callLegId, Azure.Communication.CallingServer.PlayAudioOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Communication.CallingServer.PlayAudioResponse>> PlayAudioAsync(string callLegId, System.Uri audioFileUri, bool? loop, string audioFileId, System.Uri callbackUri, string operationContext = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response RemoveParticipant(string callLegId, string participantId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> RemoveParticipantAsync(string callLegId, string participantId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class CallClientOptions : Azure.Core.ClientOptions
    {
        public const Azure.Communication.CallingServer.CallClientOptions.ServiceVersion LatestVersion = Azure.Communication.CallingServer.CallClientOptions.ServiceVersion.V2021_04_15_Preview1;
        public CallClientOptions(Azure.Communication.CallingServer.CallClientOptions.ServiceVersion version = Azure.Communication.CallingServer.CallClientOptions.ServiceVersion.V2021_04_15_Preview1) { }
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
    public readonly partial struct CallingServerEventType : System.IEquatable<Azure.Communication.CallingServer.CallingServerEventType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public CallingServerEventType(string value) { throw null; }
        public static Azure.Communication.CallingServer.CallingServerEventType CallLegStateChangedEvent { get { throw null; } }
        public static Azure.Communication.CallingServer.CallingServerEventType CallRecordingStateChangeEvent { get { throw null; } }
        public static Azure.Communication.CallingServer.CallingServerEventType InviteParticipantsResultEvent { get { throw null; } }
        public static Azure.Communication.CallingServer.CallingServerEventType ParticipantsUpdatedEvent { get { throw null; } }
        public static Azure.Communication.CallingServer.CallingServerEventType PlayAudioResultEvent { get { throw null; } }
        public static Azure.Communication.CallingServer.CallingServerEventType ToneReceivedEvent { get { throw null; } }
        public bool Equals(Azure.Communication.CallingServer.CallingServerEventType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Communication.CallingServer.CallingServerEventType left, Azure.Communication.CallingServer.CallingServerEventType right) { throw null; }
        public static bool operator !=(Azure.Communication.CallingServer.CallingServerEventType left, Azure.Communication.CallingServer.CallingServerEventType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class CallLegStateChangedEvent : Azure.Communication.CallingServer.CallingServerEventBase
    {
        public CallLegStateChangedEvent() { }
        public string CallLegId { get { throw null; } set { } }
        public Azure.Communication.CallingServer.CallState? CallState { get { throw null; } set { } }
        public string ConversationId { get { throw null; } set { } }
        public static Azure.Communication.CallingServer.CallLegStateChangedEvent Deserialize(string content) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct CallModality : System.IEquatable<Azure.Communication.CallingServer.CallModality>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public CallModality(string value) { throw null; }
        public static Azure.Communication.CallingServer.CallModality Audio { get { throw null; } }
        public static Azure.Communication.CallingServer.CallModality Video { get { throw null; } }
        public bool Equals(Azure.Communication.CallingServer.CallModality other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Communication.CallingServer.CallModality left, Azure.Communication.CallingServer.CallModality right) { throw null; }
        public static implicit operator Azure.Communication.CallingServer.CallModality (string value) { throw null; }
        public static bool operator !=(Azure.Communication.CallingServer.CallModality left, Azure.Communication.CallingServer.CallModality right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct CallRecordingState : System.IEquatable<Azure.Communication.CallingServer.CallRecordingState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public CallRecordingState(string value) { throw null; }
        public static Azure.Communication.CallingServer.CallRecordingState Active { get { throw null; } }
        public static Azure.Communication.CallingServer.CallRecordingState Inactive { get { throw null; } }
        public bool Equals(Azure.Communication.CallingServer.CallRecordingState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Communication.CallingServer.CallRecordingState left, Azure.Communication.CallingServer.CallRecordingState right) { throw null; }
        public static implicit operator Azure.Communication.CallingServer.CallRecordingState (string value) { throw null; }
        public static bool operator !=(Azure.Communication.CallingServer.CallRecordingState left, Azure.Communication.CallingServer.CallRecordingState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class CallRecordingStateChangeEvent : Azure.Communication.CallingServer.CallingServerEventBase
    {
        public CallRecordingStateChangeEvent() { }
        public string ConversationId { get { throw null; } set { } }
        public string RecordingId { get { throw null; } set { } }
        public System.DateTimeOffset? StartDateTime { get { throw null; } set { } }
        public Azure.Communication.CallingServer.CallRecordingState? State { get { throw null; } set { } }
        public static Azure.Communication.CallingServer.CallRecordingStateChangeEvent Deserialize(string content) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct CallState : System.IEquatable<Azure.Communication.CallingServer.CallState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public CallState(string value) { throw null; }
        public static Azure.Communication.CallingServer.CallState Established { get { throw null; } }
        public static Azure.Communication.CallingServer.CallState Establishing { get { throw null; } }
        public static Azure.Communication.CallingServer.CallState Hold { get { throw null; } }
        public static Azure.Communication.CallingServer.CallState Idle { get { throw null; } }
        public static Azure.Communication.CallingServer.CallState Incoming { get { throw null; } }
        public static Azure.Communication.CallingServer.CallState Redirecting { get { throw null; } }
        public static Azure.Communication.CallingServer.CallState Terminated { get { throw null; } }
        public static Azure.Communication.CallingServer.CallState Terminating { get { throw null; } }
        public static Azure.Communication.CallingServer.CallState Transferring { get { throw null; } }
        public static Azure.Communication.CallingServer.CallState Unhold { get { throw null; } }
        public static Azure.Communication.CallingServer.CallState Unknown { get { throw null; } }
        public bool Equals(Azure.Communication.CallingServer.CallState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Communication.CallingServer.CallState left, Azure.Communication.CallingServer.CallState right) { throw null; }
        public static implicit operator Azure.Communication.CallingServer.CallState (string value) { throw null; }
        public static bool operator !=(Azure.Communication.CallingServer.CallState left, Azure.Communication.CallingServer.CallState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class CancelAllMediaOperationsResponse
    {
        internal CancelAllMediaOperationsResponse() { }
        public string Id { get { throw null; } }
        public string OperationContext { get { throw null; } }
        public Azure.Communication.CallingServer.ResultInfo ResultInfo { get { throw null; } }
        public Azure.Communication.CallingServer.OperationStatus? Status { get { throw null; } }
    }
    public partial class CommunicationParticipant
    {
        public CommunicationParticipant() { }
        public CommunicationParticipant(Azure.Communication.CommunicationIdentifier identifier, string participantId, bool? isMuted) { }
        public Azure.Communication.CommunicationIdentifier Identifier { get { throw null; } set { } }
        public bool? IsMuted { get { throw null; } set { } }
        public string ParticipantId { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public partial struct ContentTransferOptions : System.IEquatable<Azure.Communication.CallingServer.ContentTransferOptions>
    {
        public long InitialTransferSize { get { throw null; } set { } }
        public int MaximumConcurrency { get { throw null; } set { } }
        public long MaximumTransferSize { get { throw null; } set { } }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public bool Equals(Azure.Communication.CallingServer.ContentTransferOptions obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static bool operator ==(Azure.Communication.CallingServer.ContentTransferOptions left, Azure.Communication.CallingServer.ContentTransferOptions right) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static bool operator !=(Azure.Communication.CallingServer.ContentTransferOptions left, Azure.Communication.CallingServer.ContentTransferOptions right) { throw null; }
    }
    public partial class ConversationClient
    {
        protected ConversationClient() { }
        public ConversationClient(string connectionString) { }
        public ConversationClient(string connectionString, Azure.Communication.CallingServer.CallClientOptions options) { }
        public ConversationClient(System.Uri endpoint, Azure.AzureKeyCredential keyCredential, Azure.Communication.CallingServer.CallClientOptions options = null) { }
        public ConversationClient(System.Uri endpoint, Azure.Core.TokenCredential tokenCredential, Azure.Communication.CallingServer.CallClientOptions options = null) { }
        public virtual Azure.Response AddParticipant(string conversationId, Azure.Communication.CommunicationIdentifier participant, System.Uri callbackUri, string alternateCallerId = null, string operationContext = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> AddParticipantAsync(string conversationId, Azure.Communication.CommunicationIdentifier participant, System.Uri callbackUri, string alternateCallerId = null, string operationContext = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<System.IO.Stream> DownloadStreaming(System.Uri sourceEndpoint, Azure.HttpRange range = default(Azure.HttpRange), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<System.IO.Stream>> DownloadStreamingAsync(System.Uri sourceEndpoint, Azure.HttpRange range = default(Azure.HttpRange), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response DownloadTo(System.Uri sourceEndpoint, System.IO.Stream destinationStream, Azure.Communication.CallingServer.ContentTransferOptions transferOptions = default(Azure.Communication.CallingServer.ContentTransferOptions), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response DownloadTo(System.Uri sourceEndpoint, string destinationPath, Azure.Communication.CallingServer.ContentTransferOptions transferOptions = default(Azure.Communication.CallingServer.ContentTransferOptions), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DownloadToAsync(System.Uri sourceEndpoint, System.IO.Stream destinationStream, Azure.Communication.CallingServer.ContentTransferOptions transferOptions = default(Azure.Communication.CallingServer.ContentTransferOptions), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DownloadToAsync(System.Uri sourceEndpoint, string destinationPath, Azure.Communication.CallingServer.ContentTransferOptions transferOptions = default(Azure.Communication.CallingServer.ContentTransferOptions), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Communication.CallingServer.GetCallRecordingStateResponse> GetRecordingState(string conversationId, string recordingId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Communication.CallingServer.GetCallRecordingStateResponse>> GetRecordingStateAsync(string conversationId, string recordingId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Communication.CallingServer.JoinCallResponse> JoinCall(string conversationId, Azure.Communication.CommunicationIdentifier source, Azure.Communication.CallingServer.JoinCallOptions callOptions, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Communication.CallingServer.JoinCallResponse>> JoinCallAsync(string conversationId, Azure.Communication.CommunicationIdentifier source, Azure.Communication.CallingServer.JoinCallOptions callOptions, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response PauseRecording(string conversationId, string recordingId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> PauseRecordingAsync(string conversationId, string recordingId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Communication.CallingServer.PlayAudioResponse> PlayAudio(string conversationId, Azure.Communication.CallingServer.PlayAudioOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Communication.CallingServer.PlayAudioResponse> PlayAudio(string conversationId, System.Uri audioFileUri, string audioFileId, System.Uri callbackUri, string operationContext = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Communication.CallingServer.PlayAudioResponse>> PlayAudioAsync(string conversationId, Azure.Communication.CallingServer.PlayAudioOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Communication.CallingServer.PlayAudioResponse>> PlayAudioAsync(string conversationId, System.Uri audioFileUri, string audioFileId, System.Uri callbackUri, string operationContext = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response RemoveParticipant(string conversationId, string participantId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> RemoveParticipantAsync(string conversationId, string participantId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response ResumeRecording(string conversationId, string recordingId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> ResumeRecordingAsync(string conversationId, string recordingId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Communication.CallingServer.StartCallRecordingResponse> StartRecording(string conversationId, System.Uri recordingStateCallbackUri, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Communication.CallingServer.StartCallRecordingResponse>> StartRecordingAsync(string conversationId, System.Uri recordingStateCallbackUri, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response StopRecording(string conversationId, string recordingId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> StopRecordingAsync(string conversationId, string recordingId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class CreateCallOptions
    {
        public CreateCallOptions(System.Uri callbackUri, System.Collections.Generic.IEnumerable<Azure.Communication.CallingServer.CallModality> requestedModalities, System.Collections.Generic.IEnumerable<Azure.Communication.CallingServer.EventSubscriptionType> requestedCallEvents) { }
        public Azure.Communication.PhoneNumberIdentifier AlternateCallerId { get { throw null; } set { } }
        public System.Uri CallbackUri { get { throw null; } }
        public System.Collections.Generic.IList<Azure.Communication.CallingServer.EventSubscriptionType> RequestedCallEvents { get { throw null; } }
        public System.Collections.Generic.IList<Azure.Communication.CallingServer.CallModality> RequestedModalities { get { throw null; } }
        public string Subject { get { throw null; } set { } }
    }
    public partial class CreateCallResponse
    {
        internal CreateCallResponse() { }
        public string CallLegId { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct EventSubscriptionType : System.IEquatable<Azure.Communication.CallingServer.EventSubscriptionType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public EventSubscriptionType(string value) { throw null; }
        public static Azure.Communication.CallingServer.EventSubscriptionType DtmfReceived { get { throw null; } }
        public static Azure.Communication.CallingServer.EventSubscriptionType ParticipantsUpdated { get { throw null; } }
        public bool Equals(Azure.Communication.CallingServer.EventSubscriptionType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Communication.CallingServer.EventSubscriptionType left, Azure.Communication.CallingServer.EventSubscriptionType right) { throw null; }
        public static implicit operator Azure.Communication.CallingServer.EventSubscriptionType (string value) { throw null; }
        public static bool operator !=(Azure.Communication.CallingServer.EventSubscriptionType left, Azure.Communication.CallingServer.EventSubscriptionType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class GetCallRecordingStateResponse
    {
        internal GetCallRecordingStateResponse() { }
        public Azure.Communication.CallingServer.CallRecordingState? RecordingState { get { throw null; } }
    }
    public partial class InviteParticipantsResultEvent : Azure.Communication.CallingServer.CallingServerEventBase
    {
        public InviteParticipantsResultEvent() { }
        public string OperationContext { get { throw null; } set { } }
        public Azure.Communication.CallingServer.ResultInfo ResultInfo { get { throw null; } set { } }
        public Azure.Communication.CallingServer.OperationStatus? Status { get { throw null; } set { } }
        public static Azure.Communication.CallingServer.InviteParticipantsResultEvent Deserialize(string content) { throw null; }
    }
    public partial class JoinCallOptions
    {
        public JoinCallOptions(System.Uri callbackUri, System.Collections.Generic.IEnumerable<Azure.Communication.CallingServer.CallModality> requestedModalities, System.Collections.Generic.IEnumerable<Azure.Communication.CallingServer.EventSubscriptionType> requestedCallEvents) { }
        public System.Uri CallbackUri { get { throw null; } }
        public System.Collections.Generic.IList<Azure.Communication.CallingServer.EventSubscriptionType> RequestedCallEvents { get { throw null; } }
        public System.Collections.Generic.IList<Azure.Communication.CallingServer.CallModality> RequestedModalities { get { throw null; } }
        public string Subject { get { throw null; } set { } }
    }
    public partial class JoinCallResponse
    {
        internal JoinCallResponse() { }
        public string CallLegId { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct OperationStatus : System.IEquatable<Azure.Communication.CallingServer.OperationStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public OperationStatus(string value) { throw null; }
        public static Azure.Communication.CallingServer.OperationStatus Completed { get { throw null; } }
        public static Azure.Communication.CallingServer.OperationStatus Failed { get { throw null; } }
        public static Azure.Communication.CallingServer.OperationStatus NotStarted { get { throw null; } }
        public static Azure.Communication.CallingServer.OperationStatus Running { get { throw null; } }
        public bool Equals(Azure.Communication.CallingServer.OperationStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Communication.CallingServer.OperationStatus left, Azure.Communication.CallingServer.OperationStatus right) { throw null; }
        public static implicit operator Azure.Communication.CallingServer.OperationStatus (string value) { throw null; }
        public static bool operator !=(Azure.Communication.CallingServer.OperationStatus left, Azure.Communication.CallingServer.OperationStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ParticipantsUpdatedEvent : Azure.Communication.CallingServer.CallingServerEventBase
    {
        public ParticipantsUpdatedEvent() { }
        public string CallLegId { get { throw null; } set { } }
        public System.Collections.Generic.IEnumerable<Azure.Communication.CallingServer.CommunicationParticipant> Participants { get { throw null; } set { } }
        public static Azure.Communication.CallingServer.ParticipantsUpdatedEvent Deserialize(string content) { throw null; }
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
        public Azure.Communication.CallingServer.ResultInfo ResultInfo { get { throw null; } }
        public Azure.Communication.CallingServer.OperationStatus? Status { get { throw null; } }
    }
    public partial class PlayAudioResultEvent : Azure.Communication.CallingServer.CallingServerEventBase
    {
        public PlayAudioResultEvent() { }
        public string OperationContext { get { throw null; } set { } }
        public Azure.Communication.CallingServer.ResultInfo ResultInfo { get { throw null; } set { } }
        public Azure.Communication.CallingServer.OperationStatus? Status { get { throw null; } set { } }
        public static Azure.Communication.CallingServer.PlayAudioResultEvent Deserialize(string content) { throw null; }
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
        public Azure.Communication.CallingServer.ToneValue? Tone { get { throw null; } set { } }
    }
    public partial class ToneReceivedEvent : Azure.Communication.CallingServer.CallingServerEventBase
    {
        public ToneReceivedEvent() { }
        public string CallLegId { get { throw null; } set { } }
        public Azure.Communication.CallingServer.ToneInfo ToneInfo { get { throw null; } set { } }
        public static Azure.Communication.CallingServer.ToneReceivedEvent Deserialize(string content) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ToneValue : System.IEquatable<Azure.Communication.CallingServer.ToneValue>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ToneValue(string value) { throw null; }
        public static Azure.Communication.CallingServer.ToneValue A { get { throw null; } }
        public static Azure.Communication.CallingServer.ToneValue B { get { throw null; } }
        public static Azure.Communication.CallingServer.ToneValue C { get { throw null; } }
        public static Azure.Communication.CallingServer.ToneValue D { get { throw null; } }
        public static Azure.Communication.CallingServer.ToneValue Flash { get { throw null; } }
        public static Azure.Communication.CallingServer.ToneValue Pound { get { throw null; } }
        public static Azure.Communication.CallingServer.ToneValue Star { get { throw null; } }
        public static Azure.Communication.CallingServer.ToneValue Tone0 { get { throw null; } }
        public static Azure.Communication.CallingServer.ToneValue Tone1 { get { throw null; } }
        public static Azure.Communication.CallingServer.ToneValue Tone2 { get { throw null; } }
        public static Azure.Communication.CallingServer.ToneValue Tone3 { get { throw null; } }
        public static Azure.Communication.CallingServer.ToneValue Tone4 { get { throw null; } }
        public static Azure.Communication.CallingServer.ToneValue Tone5 { get { throw null; } }
        public static Azure.Communication.CallingServer.ToneValue Tone6 { get { throw null; } }
        public static Azure.Communication.CallingServer.ToneValue Tone7 { get { throw null; } }
        public static Azure.Communication.CallingServer.ToneValue Tone8 { get { throw null; } }
        public static Azure.Communication.CallingServer.ToneValue Tone9 { get { throw null; } }
        public bool Equals(Azure.Communication.CallingServer.ToneValue other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Communication.CallingServer.ToneValue left, Azure.Communication.CallingServer.ToneValue right) { throw null; }
        public static implicit operator Azure.Communication.CallingServer.ToneValue (string value) { throw null; }
        public static bool operator !=(Azure.Communication.CallingServer.ToneValue left, Azure.Communication.CallingServer.ToneValue right) { throw null; }
        public override string ToString() { throw null; }
    }
}
