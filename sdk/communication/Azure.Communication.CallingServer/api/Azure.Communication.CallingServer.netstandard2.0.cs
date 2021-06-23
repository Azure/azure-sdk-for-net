namespace Azure.Communication.CallingServer
{
    public partial class AddParticipantResult
    {
        internal AddParticipantResult() { }
        public string ParticipantId { get { throw null; } }
    }
    public partial class AddParticipantResultEvent : Azure.Communication.CallingServer.CallingServerEventBase
    {
        internal AddParticipantResultEvent() { }
        public string OperationContext { get { throw null; } }
        public Azure.Communication.CallingServer.ResultInfo ResultInfo { get { throw null; } }
        public Azure.Communication.CallingServer.OperationStatus Status { get { throw null; } }
        public static Azure.Communication.CallingServer.AddParticipantResultEvent Deserialize(string content) { throw null; }
    }
    public partial class CallConnection
    {
        protected CallConnection() { }
        public virtual string CallConnectionId { get { throw null; } }
        public virtual Azure.Response<Azure.Communication.CallingServer.AddParticipantResult> AddParticipant(Azure.Communication.CommunicationIdentifier participant, string alternateCallerId = null, string operationContext = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Communication.CallingServer.AddParticipantResult>> AddParticipantAsync(Azure.Communication.CommunicationIdentifier participant, string alternateCallerId = null, string operationContext = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Communication.CallingServer.CancelAllMediaOperationsResult> CancelAllMediaOperations(string operationContext = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Communication.CallingServer.CancelAllMediaOperationsResult>> CancelAllMediaOperationsAsync(string operationContext = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response Hangup(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> HangupAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Communication.CallingServer.PlayAudioResult> PlayAudio(Azure.Communication.CallingServer.PlayAudioOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Communication.CallingServer.PlayAudioResult> PlayAudio(System.Uri audioFileUri, bool? loop, string audioFileId, System.Uri callbackUri, string operationContext = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Communication.CallingServer.PlayAudioResult>> PlayAudioAsync(Azure.Communication.CallingServer.PlayAudioOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Communication.CallingServer.PlayAudioResult>> PlayAudioAsync(System.Uri audioFileUri, bool? loop, string audioFileId, System.Uri callbackUri, string operationContext = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response RemoveParticipant(string participantId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> RemoveParticipantAsync(string participantId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct CallConnectionState : System.IEquatable<Azure.Communication.CallingServer.CallConnectionState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public CallConnectionState(string value) { throw null; }
        public static Azure.Communication.CallingServer.CallConnectionState Connected { get { throw null; } }
        public static Azure.Communication.CallingServer.CallConnectionState Connecting { get { throw null; } }
        public static Azure.Communication.CallingServer.CallConnectionState Disconnected { get { throw null; } }
        public static Azure.Communication.CallingServer.CallConnectionState Disconnecting { get { throw null; } }
        public static Azure.Communication.CallingServer.CallConnectionState Incoming { get { throw null; } }
        public bool Equals(Azure.Communication.CallingServer.CallConnectionState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Communication.CallingServer.CallConnectionState left, Azure.Communication.CallingServer.CallConnectionState right) { throw null; }
        public static implicit operator Azure.Communication.CallingServer.CallConnectionState (string value) { throw null; }
        public static bool operator !=(Azure.Communication.CallingServer.CallConnectionState left, Azure.Communication.CallingServer.CallConnectionState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class CallConnectionStateChangedEvent : Azure.Communication.CallingServer.CallingServerEventBase
    {
        internal CallConnectionStateChangedEvent() { }
        public string CallConnectionId { get { throw null; } }
        public Azure.Communication.CallingServer.CallConnectionState CallConnectionState { get { throw null; } }
        public string ServerCallId { get { throw null; } }
        public static Azure.Communication.CallingServer.CallConnectionStateChangedEvent Deserialize(string content) { throw null; }
    }
    public partial class CallingServerClient
    {
        protected CallingServerClient() { }
        public CallingServerClient(string connectionString) { }
        public CallingServerClient(string connectionString, Azure.Communication.CallingServer.CallingServerClientOptions options) { }
        public virtual Azure.Response<Azure.Communication.CallingServer.CallConnection> CreateCallConnection(Azure.Communication.CommunicationIdentifier source, System.Collections.Generic.IEnumerable<Azure.Communication.CommunicationIdentifier> targets, Azure.Communication.CallingServer.CreateCallOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Communication.CallingServer.CallConnection>> CreateCallConnectionAsync(Azure.Communication.CommunicationIdentifier source, System.Collections.Generic.IEnumerable<Azure.Communication.CommunicationIdentifier> targets, Azure.Communication.CallingServer.CreateCallOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<System.IO.Stream> DownloadStreaming(System.Uri sourceEndpoint, Azure.HttpRange range = default(Azure.HttpRange), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<System.IO.Stream>> DownloadStreamingAsync(System.Uri sourceEndpoint, Azure.HttpRange range = default(Azure.HttpRange), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response DownloadTo(System.Uri sourceEndpoint, System.IO.Stream destinationStream, Azure.Communication.CallingServer.ContentTransferOptions transferOptions = default(Azure.Communication.CallingServer.ContentTransferOptions), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response DownloadTo(System.Uri sourceEndpoint, string destinationPath, Azure.Communication.CallingServer.ContentTransferOptions transferOptions = default(Azure.Communication.CallingServer.ContentTransferOptions), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DownloadToAsync(System.Uri sourceEndpoint, System.IO.Stream destinationStream, Azure.Communication.CallingServer.ContentTransferOptions transferOptions = default(Azure.Communication.CallingServer.ContentTransferOptions), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DownloadToAsync(System.Uri sourceEndpoint, string destinationPath, Azure.Communication.CallingServer.ContentTransferOptions transferOptions = default(Azure.Communication.CallingServer.ContentTransferOptions), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Communication.CallingServer.CallConnection GetCallConnection(string callConnectionId) { throw null; }
        public virtual Azure.Communication.CallingServer.ServerCall InitializeServerCall(string serverCallId) { throw null; }
        public virtual Azure.Response<Azure.Communication.CallingServer.CallConnection> JoinCall(string serverCallId, Azure.Communication.CommunicationIdentifier source, Azure.Communication.CallingServer.JoinCallOptions callOptions, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Communication.CallingServer.CallConnection>> JoinCallAsync(string serverCallId, Azure.Communication.CommunicationIdentifier source, Azure.Communication.CallingServer.JoinCallOptions callOptions, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class CallingServerClientOptions : Azure.Core.ClientOptions
    {
        public CallingServerClientOptions(Azure.Communication.CallingServer.CallingServerClientOptions.ServiceVersion version = Azure.Communication.CallingServer.CallingServerClientOptions.ServiceVersion.V2021_06_15_Preview) { }
        public enum ServiceVersion
        {
            V2021_06_15_Preview = 1,
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
        public static Azure.Communication.CallingServer.CallingServerEventType AddParticipantResultEvent { get { throw null; } }
        public static Azure.Communication.CallingServer.CallingServerEventType CallConnectionStateChangedEvent { get { throw null; } }
        public static Azure.Communication.CallingServer.CallingServerEventType CallRecordingStateChangeEvent { get { throw null; } }
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
    public partial class CallParticipant
    {
        internal CallParticipant() { }
        public Azure.Communication.CommunicationIdentifier Identifier { get { throw null; } }
        public bool IsMuted { get { throw null; } }
        public string ParticipantId { get { throw null; } }
    }
    public partial class CallRecordingProperties
    {
        internal CallRecordingProperties() { }
        public Azure.Communication.CallingServer.CallRecordingState RecordingState { get { throw null; } }
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
        internal CallRecordingStateChangeEvent() { }
        public string RecordingId { get { throw null; } }
        public string ServerCallId { get { throw null; } }
        public System.DateTimeOffset StartDateTime { get { throw null; } }
        public Azure.Communication.CallingServer.CallRecordingState State { get { throw null; } }
        public static Azure.Communication.CallingServer.CallRecordingStateChangeEvent Deserialize(string content) { throw null; }
    }
    public partial class CancelAllMediaOperationsResult
    {
        internal CancelAllMediaOperationsResult() { }
        public string OperationContext { get { throw null; } }
        public string OperationId { get { throw null; } }
        public Azure.Communication.CallingServer.ResultInfo ResultInfo { get { throw null; } }
        public Azure.Communication.CallingServer.OperationStatus Status { get { throw null; } }
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
    public partial class CreateCallOptions
    {
        public CreateCallOptions(System.Uri callbackUri, System.Collections.Generic.IEnumerable<Azure.Communication.CallingServer.MediaType> requestedMediaTypes, System.Collections.Generic.IEnumerable<Azure.Communication.CallingServer.EventSubscriptionType> requestedCallEvents) { }
        public Azure.Communication.PhoneNumberIdentifier AlternateCallerId { get { throw null; } set { } }
        public System.Uri CallbackUri { get { throw null; } }
        public System.Collections.Generic.IList<Azure.Communication.CallingServer.EventSubscriptionType> RequestedCallEvents { get { throw null; } }
        public System.Collections.Generic.IList<Azure.Communication.CallingServer.MediaType> RequestedMediaTypes { get { throw null; } }
        public string Subject { get { throw null; } set { } }
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
    public partial class JoinCallOptions
    {
        public JoinCallOptions(System.Uri callbackUri, System.Collections.Generic.IEnumerable<Azure.Communication.CallingServer.MediaType> requestedMediaTypes, System.Collections.Generic.IEnumerable<Azure.Communication.CallingServer.EventSubscriptionType> requestedCallEvents) { }
        public System.Uri CallbackUri { get { throw null; } }
        public System.Collections.Generic.IList<Azure.Communication.CallingServer.EventSubscriptionType> RequestedCallEvents { get { throw null; } }
        public System.Collections.Generic.IList<Azure.Communication.CallingServer.MediaType> RequestedMediaTypes { get { throw null; } }
        public string Subject { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MediaType : System.IEquatable<Azure.Communication.CallingServer.MediaType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MediaType(string value) { throw null; }
        public static Azure.Communication.CallingServer.MediaType Audio { get { throw null; } }
        public static Azure.Communication.CallingServer.MediaType Video { get { throw null; } }
        public bool Equals(Azure.Communication.CallingServer.MediaType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Communication.CallingServer.MediaType left, Azure.Communication.CallingServer.MediaType right) { throw null; }
        public static implicit operator Azure.Communication.CallingServer.MediaType (string value) { throw null; }
        public static bool operator !=(Azure.Communication.CallingServer.MediaType left, Azure.Communication.CallingServer.MediaType right) { throw null; }
        public override string ToString() { throw null; }
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
        internal ParticipantsUpdatedEvent() { }
        public string CallConnectionId { get { throw null; } }
        public System.Collections.Generic.IEnumerable<Azure.Communication.CallingServer.CallParticipant> Participants { get { throw null; } }
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
    public partial class PlayAudioResult
    {
        internal PlayAudioResult() { }
        public string OperationContext { get { throw null; } }
        public string OperationId { get { throw null; } }
        public Azure.Communication.CallingServer.ResultInfo ResultInfo { get { throw null; } }
        public Azure.Communication.CallingServer.OperationStatus Status { get { throw null; } }
    }
    public partial class PlayAudioResultEvent : Azure.Communication.CallingServer.CallingServerEventBase
    {
        internal PlayAudioResultEvent() { }
        public string OperationContext { get { throw null; } }
        public Azure.Communication.CallingServer.ResultInfo ResultInfo { get { throw null; } }
        public Azure.Communication.CallingServer.OperationStatus Status { get { throw null; } }
        public static Azure.Communication.CallingServer.PlayAudioResultEvent Deserialize(string content) { throw null; }
    }
    public partial class ResultInfo
    {
        internal ResultInfo() { }
        public int Code { get { throw null; } }
        public string Message { get { throw null; } }
        public int Subcode { get { throw null; } }
    }
    public partial class ServerCall
    {
        protected ServerCall() { }
        public virtual Azure.Response<Azure.Communication.CallingServer.AddParticipantResult> AddParticipant(Azure.Communication.CommunicationIdentifier participant, System.Uri callbackUri, string alternateCallerId = null, string operationContext = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Communication.CallingServer.AddParticipantResult>> AddParticipantAsync(Azure.Communication.CommunicationIdentifier participant, System.Uri callbackUri, string alternateCallerId = null, string operationContext = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Communication.CallingServer.CallRecordingProperties> GetRecordingState(string recordingId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Communication.CallingServer.CallRecordingProperties>> GetRecordingStateAsync(string recordingId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response PauseRecording(string recordingId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> PauseRecordingAsync(string recordingId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Communication.CallingServer.PlayAudioResult> PlayAudio(System.Uri audioFileUri, string audioFileId, System.Uri callbackUri, string operationContext = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Communication.CallingServer.PlayAudioResult>> PlayAudioAsync(System.Uri audioFileUri, string audioFileId, System.Uri callbackUri, string operationContext = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response RemoveParticipant(string participantId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> RemoveParticipantAsync(string participantId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response ResumeRecording(string recordingId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> ResumeRecordingAsync(string recordingId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Communication.CallingServer.StartCallRecordingResult> StartRecording(System.Uri recordingStateCallbackUri, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Communication.CallingServer.StartCallRecordingResult>> StartRecordingAsync(System.Uri recordingStateCallbackUri, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response StopRecording(string recordingId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> StopRecordingAsync(string recordingId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class StartCallRecordingResult
    {
        internal StartCallRecordingResult() { }
        public string RecordingId { get { throw null; } }
    }
    public partial class ToneInfo
    {
        internal ToneInfo() { }
        public int SequenceId { get { throw null; } }
        public Azure.Communication.CallingServer.ToneValue Tone { get { throw null; } }
    }
    public partial class ToneReceivedEvent : Azure.Communication.CallingServer.CallingServerEventBase
    {
        internal ToneReceivedEvent() { }
        public string CallConnectionId { get { throw null; } }
        public Azure.Communication.CallingServer.ToneInfo ToneInfo { get { throw null; } }
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
namespace Azure.Communication.CallingServer.Models
{
    public static partial class CallingServerModelFactory
    {
        public static Azure.Communication.CallingServer.AddParticipantResult AddParticipantResult(string participantId = null) { throw null; }
        public static Azure.Communication.CallingServer.AddParticipantResultEvent AddParticipantResultEvent(Azure.Communication.CallingServer.ResultInfo resultInfo = null, string operationContext = null, Azure.Communication.CallingServer.OperationStatus status = default(Azure.Communication.CallingServer.OperationStatus)) { throw null; }
        public static Azure.Communication.CallingServer.CallConnectionStateChangedEvent CallConnectionStateChangedEvent(string serverCallId = null, string callConnectionId = null, Azure.Communication.CallingServer.CallConnectionState callConnectionState = default(Azure.Communication.CallingServer.CallConnectionState)) { throw null; }
        public static Azure.Communication.CallingServer.CallRecordingProperties CallRecordingProperties(Azure.Communication.CallingServer.CallRecordingState recordingState = default(Azure.Communication.CallingServer.CallRecordingState)) { throw null; }
        public static Azure.Communication.CallingServer.CallRecordingStateChangeEvent CallRecordingStateChangeEvent(string recordingId = null, Azure.Communication.CallingServer.CallRecordingState state = default(Azure.Communication.CallingServer.CallRecordingState), System.DateTimeOffset startDateTime = default(System.DateTimeOffset), string serverCallId = null) { throw null; }
        public static Azure.Communication.CallingServer.CancelAllMediaOperationsResult CancelAllMediaOperationsResult(string operationId = null, Azure.Communication.CallingServer.OperationStatus status = default(Azure.Communication.CallingServer.OperationStatus), string operationContext = null, Azure.Communication.CallingServer.ResultInfo resultInfo = null) { throw null; }
        public static Azure.Communication.CallingServer.PlayAudioResult PlayAudioResult(string operationId = null, Azure.Communication.CallingServer.OperationStatus status = default(Azure.Communication.CallingServer.OperationStatus), string operationContext = null, Azure.Communication.CallingServer.ResultInfo resultInfo = null) { throw null; }
        public static Azure.Communication.CallingServer.PlayAudioResultEvent PlayAudioResultEvent(Azure.Communication.CallingServer.ResultInfo resultInfo = null, string operationContext = null, Azure.Communication.CallingServer.OperationStatus status = default(Azure.Communication.CallingServer.OperationStatus)) { throw null; }
        public static Azure.Communication.CallingServer.ResultInfo ResultInfo(int code = 0, int subcode = 0, string message = null) { throw null; }
        public static Azure.Communication.CallingServer.StartCallRecordingResult StartCallRecordingResult(string recordingId = null) { throw null; }
        public static Azure.Communication.CallingServer.ToneInfo ToneInfo(int sequenceId = 0, Azure.Communication.CallingServer.ToneValue tone = default(Azure.Communication.CallingServer.ToneValue)) { throw null; }
        public static Azure.Communication.CallingServer.ToneReceivedEvent ToneReceivedEvent(Azure.Communication.CallingServer.ToneInfo toneInfo = null, string callConnectionId = null) { throw null; }
    }
}
