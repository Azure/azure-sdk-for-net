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
        public Azure.Communication.CallingServer.CallingOperationResultDetails ResultInfo { get { throw null; } }
        public Azure.Communication.CallingServer.CallingOperationStatus Status { get { throw null; } }
        public static Azure.Communication.CallingServer.AddParticipantResultEvent Deserialize(string content) { throw null; }
    }
    public partial class AnswerCallResult
    {
        internal AnswerCallResult() { }
        public string CallConnectionId { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AudioRoutingMode : System.IEquatable<Azure.Communication.CallingServer.AudioRoutingMode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AudioRoutingMode(string value) { throw null; }
        public static Azure.Communication.CallingServer.AudioRoutingMode Multicast { get { throw null; } }
        public static Azure.Communication.CallingServer.AudioRoutingMode OneToOne { get { throw null; } }
        public bool Equals(Azure.Communication.CallingServer.AudioRoutingMode other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Communication.CallingServer.AudioRoutingMode left, Azure.Communication.CallingServer.AudioRoutingMode right) { throw null; }
        public static implicit operator Azure.Communication.CallingServer.AudioRoutingMode (string value) { throw null; }
        public static bool operator !=(Azure.Communication.CallingServer.AudioRoutingMode left, Azure.Communication.CallingServer.AudioRoutingMode right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class CallConnection
    {
        protected CallConnection() { }
        public virtual string CallConnectionId { get { throw null; } }
        public virtual Azure.Response<Azure.Communication.CallingServer.AddParticipantResult> AddParticipant(Azure.Communication.CommunicationIdentifier participant, string alternateCallerId = null, string operationContext = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Communication.CallingServer.AddParticipantResult>> AddParticipantAsync(Azure.Communication.CommunicationIdentifier participant, string alternateCallerId = null, string operationContext = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response CancelAllMediaOperations(string operationContext = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> CancelAllMediaOperationsAsync(string operationContext = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response CancelParticipantMediaOperation(Azure.Communication.CommunicationIdentifier participant, string mediaOperationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> CancelParticipantMediaOperationAsync(Azure.Communication.CommunicationIdentifier participant, string mediaOperationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Communication.CallingServer.CreateAudioRoutingGroupResult> CreateAudioRoutingGroup(Azure.Communication.CallingServer.AudioRoutingMode audioRoutingMode, System.Collections.Generic.IEnumerable<Azure.Communication.CommunicationIdentifier> targets, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Communication.CallingServer.CreateAudioRoutingGroupResult>> CreateAudioRoutingGroupAsync(Azure.Communication.CallingServer.AudioRoutingMode audioRoutingMode, System.Collections.Generic.IEnumerable<Azure.Communication.CommunicationIdentifier> targets, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response DeleteAudioRoutingGroup(string audioRoutingGroupId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteAudioRoutingGroupAsync(string audioRoutingGroupId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Communication.CallingServer.CallConnectionProperties> GetCall(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Communication.CallingServer.CallConnectionProperties>> GetCallAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<System.Collections.Generic.IEnumerable<Azure.Communication.CallingServer.CallParticipant>> GetParticipant(Azure.Communication.CommunicationIdentifier participant, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<System.Collections.Generic.IEnumerable<Azure.Communication.CallingServer.CallParticipant>>> GetParticipantAsync(Azure.Communication.CommunicationIdentifier participant, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<System.Collections.Generic.IEnumerable<Azure.Communication.CallingServer.CallParticipant>> GetParticipants(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<System.Collections.Generic.IEnumerable<Azure.Communication.CallingServer.CallParticipant>>> GetParticipantsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response Hangup(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> HangupAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response HoldParticipantMeetingAudio(Azure.Communication.CommunicationIdentifier participant, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> HoldParticipantMeetingAudioAsync(Azure.Communication.CommunicationIdentifier participant, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response KeepAlive(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> KeepAliveAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response MuteParticipant(Azure.Communication.CommunicationIdentifier participant, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> MuteParticipantAsync(Azure.Communication.CommunicationIdentifier participant, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Communication.CallingServer.PlayAudioResult> PlayAudio(System.Uri audioFileUri, Azure.Communication.CallingServer.PlayAudioOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Communication.CallingServer.PlayAudioResult>> PlayAudioAsync(System.Uri audioFileUri, Azure.Communication.CallingServer.PlayAudioOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Communication.CallingServer.PlayAudioResult> PlayAudioToParticipant(Azure.Communication.CommunicationIdentifier participant, System.Uri audioFileUri, Azure.Communication.CallingServer.PlayAudioOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Communication.CallingServer.PlayAudioResult>> PlayAudioToParticipantAsync(Azure.Communication.CommunicationIdentifier participant, System.Uri audioFileUri, Azure.Communication.CallingServer.PlayAudioOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response RemoveParticipant(Azure.Communication.CommunicationIdentifier participant, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> RemoveParticipantAsync(Azure.Communication.CommunicationIdentifier participant, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response ResumeParticipantMeetingAudio(Azure.Communication.CommunicationIdentifier participant, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> ResumeParticipantMeetingAudioAsync(Azure.Communication.CommunicationIdentifier participant, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Communication.CallingServer.TransferCallResult> TransferCall(Azure.Communication.CommunicationIdentifier targetParticipant, string targetCallConnectionId, string userToUserInformation, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Communication.CallingServer.TransferCallResult>> TransferCallAsync(Azure.Communication.CommunicationIdentifier targetParticipant, string targetCallConnectionId, string userToUserInformation, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response UnmuteParticipant(Azure.Communication.CommunicationIdentifier participant, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> UnmuteParticipantAsync(Azure.Communication.CommunicationIdentifier participant, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response UpdateAudioRoutingGroup(string audioRoutingGroupId, System.Collections.Generic.IEnumerable<Azure.Communication.CommunicationIdentifier> targets, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> UpdateAudioRoutingGroupAsync(string audioRoutingGroupId, System.Collections.Generic.IEnumerable<Azure.Communication.CommunicationIdentifier> targets, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class CallConnectionProperties
    {
        internal CallConnectionProperties() { }
        public Azure.Communication.PhoneNumberIdentifier AlternateCallerId { get { throw null; } }
        public System.Uri CallbackUri { get { throw null; } }
        public string CallConnectionId { get { throw null; } }
        public Azure.Communication.CallingServer.CallConnectionState? CallConnectionState { get { throw null; } }
        public Azure.Communication.CallingServer.CallLocator CallLocator { get { throw null; } }
        public System.Collections.Generic.IEnumerable<Azure.Communication.CallingServer.CallingEventSubscriptionType> RequestedCallEvents { get { throw null; } }
        public System.Collections.Generic.IEnumerable<Azure.Communication.CallingServer.CallMediaType> RequestedMediaTypes { get { throw null; } }
        public Azure.Communication.CommunicationIdentifier Source { get { throw null; } }
        public string Subject { get { throw null; } }
        public System.Collections.Generic.IEnumerable<Azure.Communication.CommunicationIdentifier> Targets { get { throw null; } }
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
        public static Azure.Communication.CallingServer.CallConnectionState TransferAccepted { get { throw null; } }
        public static Azure.Communication.CallingServer.CallConnectionState Transferring { get { throw null; } }
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
        public Azure.Communication.CallingServer.CallLocatorModel CallLocator { get { throw null; } }
        public static Azure.Communication.CallingServer.CallConnectionStateChangedEvent Deserialize(string content) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct CallingEventSubscriptionType : System.IEquatable<Azure.Communication.CallingServer.CallingEventSubscriptionType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public CallingEventSubscriptionType(string value) { throw null; }
        public static Azure.Communication.CallingServer.CallingEventSubscriptionType ParticipantsUpdated { get { throw null; } }
        public static Azure.Communication.CallingServer.CallingEventSubscriptionType ToneReceived { get { throw null; } }
        public bool Equals(Azure.Communication.CallingServer.CallingEventSubscriptionType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Communication.CallingServer.CallingEventSubscriptionType left, Azure.Communication.CallingServer.CallingEventSubscriptionType right) { throw null; }
        public static implicit operator Azure.Communication.CallingServer.CallingEventSubscriptionType (string value) { throw null; }
        public static bool operator !=(Azure.Communication.CallingServer.CallingEventSubscriptionType left, Azure.Communication.CallingServer.CallingEventSubscriptionType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class CallingOperationResultDetails
    {
        internal CallingOperationResultDetails() { }
        public int Code { get { throw null; } }
        public string Message { get { throw null; } }
        public int Subcode { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct CallingOperationStatus : System.IEquatable<Azure.Communication.CallingServer.CallingOperationStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public CallingOperationStatus(string value) { throw null; }
        public static Azure.Communication.CallingServer.CallingOperationStatus Completed { get { throw null; } }
        public static Azure.Communication.CallingServer.CallingOperationStatus Failed { get { throw null; } }
        public static Azure.Communication.CallingServer.CallingOperationStatus NotStarted { get { throw null; } }
        public static Azure.Communication.CallingServer.CallingOperationStatus Running { get { throw null; } }
        public bool Equals(Azure.Communication.CallingServer.CallingOperationStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Communication.CallingServer.CallingOperationStatus left, Azure.Communication.CallingServer.CallingOperationStatus right) { throw null; }
        public static implicit operator Azure.Communication.CallingServer.CallingOperationStatus (string value) { throw null; }
        public static bool operator !=(Azure.Communication.CallingServer.CallingOperationStatus left, Azure.Communication.CallingServer.CallingOperationStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class CallingServerClient
    {
        protected CallingServerClient() { }
        public CallingServerClient(string connectionString) { }
        public CallingServerClient(string connectionString, Azure.Communication.CallingServer.CallingServerClientOptions options) { }
        public CallingServerClient(System.Uri endpoint, Azure.Core.TokenCredential credential) { }
        public CallingServerClient(System.Uri endpoint, Azure.Core.TokenCredential credential, Azure.Communication.CallingServer.CallingServerClientOptions options) { }
        public virtual Azure.Response<Azure.Communication.CallingServer.AddParticipantResult> AddParticipant(Azure.Communication.CallingServer.CallLocator callLocator, Azure.Communication.CommunicationIdentifier participant, System.Uri callbackUri, string alternateCallerId = null, string operationContext = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Communication.CallingServer.AddParticipantResult>> AddParticipantAsync(Azure.Communication.CallingServer.CallLocator callLocator, Azure.Communication.CommunicationIdentifier participant, System.Uri callbackUri, string alternateCallerId = null, string operationContext = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Communication.CallingServer.CallConnection> AnswerCall(string incomingCallContext, System.Collections.Generic.IEnumerable<Azure.Communication.CallingServer.CallMediaType> requestedMediaTypes, System.Collections.Generic.IEnumerable<Azure.Communication.CallingServer.CallingEventSubscriptionType> requestedCallEvents, System.Uri callbackUri, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Communication.CallingServer.CallConnection>> AnswerCallAsync(string incomingCallContext, System.Collections.Generic.IEnumerable<Azure.Communication.CallingServer.CallMediaType> requestedMediaTypes, System.Collections.Generic.IEnumerable<Azure.Communication.CallingServer.CallingEventSubscriptionType> requestedCallEvents, System.Uri callbackUri, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response CancelMediaOperation(Azure.Communication.CallingServer.CallLocator callLocator, string mediaOperationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> CancelMediaOperationAsync(Azure.Communication.CallingServer.CallLocator callLocator, string mediaOperationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response CancelParticipantMediaOperation(Azure.Communication.CallingServer.CallLocator callLocator, Azure.Communication.CommunicationIdentifier participant, string mediaOperationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> CancelParticipantMediaOperationAsync(Azure.Communication.CallingServer.CallLocator callLocator, Azure.Communication.CommunicationIdentifier participant, string mediaOperationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Communication.CallingServer.CallConnection> CreateCallConnection(Azure.Communication.CommunicationIdentifier source, System.Collections.Generic.IEnumerable<Azure.Communication.CommunicationIdentifier> targets, Azure.Communication.CallingServer.CreateCallOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Communication.CallingServer.CallConnection>> CreateCallConnectionAsync(Azure.Communication.CommunicationIdentifier source, System.Collections.Generic.IEnumerable<Azure.Communication.CommunicationIdentifier> targets, Azure.Communication.CallingServer.CreateCallOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response DeleteRecording(System.Uri deleteEndpoint, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteRecordingAsync(System.Uri deleteEndpoint, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<System.IO.Stream> DownloadStreaming(System.Uri sourceEndpoint, Azure.HttpRange range = default(Azure.HttpRange), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<System.IO.Stream>> DownloadStreamingAsync(System.Uri sourceEndpoint, Azure.HttpRange range = default(Azure.HttpRange), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response DownloadTo(System.Uri sourceEndpoint, System.IO.Stream destinationStream, Azure.Communication.CallingServer.ContentTransferOptions transferOptions = default(Azure.Communication.CallingServer.ContentTransferOptions), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response DownloadTo(System.Uri sourceEndpoint, string destinationPath, Azure.Communication.CallingServer.ContentTransferOptions transferOptions = default(Azure.Communication.CallingServer.ContentTransferOptions), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DownloadToAsync(System.Uri sourceEndpoint, System.IO.Stream destinationStream, Azure.Communication.CallingServer.ContentTransferOptions transferOptions = default(Azure.Communication.CallingServer.ContentTransferOptions), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DownloadToAsync(System.Uri sourceEndpoint, string destinationPath, Azure.Communication.CallingServer.ContentTransferOptions transferOptions = default(Azure.Communication.CallingServer.ContentTransferOptions), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Communication.CallingServer.CallConnection GetCallConnection(string callConnectionId) { throw null; }
        public virtual Azure.Response<System.Collections.Generic.IEnumerable<Azure.Communication.CallingServer.CallParticipant>> GetParticipant(Azure.Communication.CallingServer.CallLocator callLocator, Azure.Communication.CommunicationIdentifier participant, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<System.Collections.Generic.IEnumerable<Azure.Communication.CallingServer.CallParticipant>>> GetParticipantAsync(Azure.Communication.CallingServer.CallLocator callLocator, Azure.Communication.CommunicationIdentifier participant, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<System.Collections.Generic.IEnumerable<Azure.Communication.CallingServer.CallParticipant>> GetParticipants(Azure.Communication.CallingServer.CallLocator callLocator, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<System.Collections.Generic.IEnumerable<Azure.Communication.CallingServer.CallParticipant>>> GetParticipantsAsync(Azure.Communication.CallingServer.CallLocator callLocator, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Communication.CallingServer.CallRecordingProperties> GetRecordingState(string recordingId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Communication.CallingServer.CallRecordingProperties>> GetRecordingStateAsync(string recordingId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Communication.CallingServer.CallConnection> JoinCall(Azure.Communication.CallingServer.CallLocator callLocator, Azure.Communication.CommunicationIdentifier source, Azure.Communication.CallingServer.JoinCallOptions callOptions, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Communication.CallingServer.CallConnection>> JoinCallAsync(Azure.Communication.CallingServer.CallLocator callLocator, Azure.Communication.CommunicationIdentifier source, Azure.Communication.CallingServer.JoinCallOptions callOptions, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response PauseRecording(string recordingId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> PauseRecordingAsync(string recordingId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Communication.CallingServer.PlayAudioResult> PlayAudio(Azure.Communication.CallingServer.CallLocator callLocator, System.Uri audioFileUri, Azure.Communication.CallingServer.PlayAudioOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Communication.CallingServer.PlayAudioResult>> PlayAudioAsync(Azure.Communication.CallingServer.CallLocator callLocator, System.Uri audioFileUri, Azure.Communication.CallingServer.PlayAudioOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Communication.CallingServer.PlayAudioResult> PlayAudioToParticipant(Azure.Communication.CallingServer.CallLocator callLocator, Azure.Communication.CommunicationIdentifier participant, System.Uri audioFileUri, Azure.Communication.CallingServer.PlayAudioOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Communication.CallingServer.PlayAudioResult>> PlayAudioToParticipantAsync(Azure.Communication.CallingServer.CallLocator callLocator, Azure.Communication.CommunicationIdentifier participant, System.Uri audioFileUri, Azure.Communication.CallingServer.PlayAudioOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response RedirectCall(string incomingCallContext, System.Collections.Generic.IEnumerable<Azure.Communication.CommunicationIdentifier> targets, System.Uri callbackUri, int timeoutInSeconds, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> RedirectCallAsync(string incomingCallContext, System.Collections.Generic.IEnumerable<Azure.Communication.CommunicationIdentifier> targets, System.Uri callbackUri, int timeoutInSeconds, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response RejectCall(string incomingCallContext, Azure.Communication.CallingServer.CallRejectReason callRejectReason, System.Uri callbackUri, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> RejectCallAsync(string incomingCallContext, Azure.Communication.CallingServer.CallRejectReason callRejectReason, System.Uri callbackUri, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response RemoveParticipant(Azure.Communication.CallingServer.CallLocator callLocator, Azure.Communication.CommunicationIdentifier participant, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> RemoveParticipantAsync(Azure.Communication.CallingServer.CallLocator callLocator, Azure.Communication.CommunicationIdentifier participant, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response ResumeRecording(string recordingId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> ResumeRecordingAsync(string recordingId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Communication.CallingServer.StartCallRecordingResult> StartRecording(Azure.Communication.CallingServer.CallLocator callLocator, System.Uri recordingStateCallbackUri, Azure.Communication.CallingServer.RecordingContent? content = default(Azure.Communication.CallingServer.RecordingContent?), Azure.Communication.CallingServer.RecordingChannel? channel = default(Azure.Communication.CallingServer.RecordingChannel?), Azure.Communication.CallingServer.RecordingFormat? format = default(Azure.Communication.CallingServer.RecordingFormat?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Communication.CallingServer.StartCallRecordingResult>> StartRecordingAsync(Azure.Communication.CallingServer.CallLocator callLocator, System.Uri recordingStateCallbackUri, Azure.Communication.CallingServer.RecordingContent? content = default(Azure.Communication.CallingServer.RecordingContent?), Azure.Communication.CallingServer.RecordingChannel? channel = default(Azure.Communication.CallingServer.RecordingChannel?), Azure.Communication.CallingServer.RecordingFormat? format = default(Azure.Communication.CallingServer.RecordingFormat?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response StopRecording(string recordingId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> StopRecordingAsync(string recordingId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class CallingServerClientOptions : Azure.Core.ClientOptions
    {
        public CallingServerClientOptions(Azure.Communication.CallingServer.CallingServerClientOptions.ServiceVersion version = Azure.Communication.CallingServer.CallingServerClientOptions.ServiceVersion.V2021_11_15_Preview) { }
        public enum ServiceVersion
        {
            V2021_11_15_Preview = 1,
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
    public static partial class CallingServerModelFactory
    {
        public static Azure.Communication.CallingServer.AddParticipantResult AddParticipantResult(string participantId = null) { throw null; }
        public static Azure.Communication.CallingServer.AddParticipantResultEvent AddParticipantResultEvent(Azure.Communication.CallingServer.CallingOperationResultDetails resultInfo = null, string operationContext = null, Azure.Communication.CallingServer.CallingOperationStatus status = default(Azure.Communication.CallingServer.CallingOperationStatus)) { throw null; }
        public static Azure.Communication.CallingServer.AnswerCallResult AnswerCallResult(string callConnectionId = null) { throw null; }
        public static Azure.Communication.CallingServer.CallConnectionStateChangedEvent CallConnectionStateChangedEvent(Azure.Communication.CallingServer.CallLocatorModel callLocator = null, string callConnectionId = null, Azure.Communication.CallingServer.CallConnectionState callConnectionState = default(Azure.Communication.CallingServer.CallConnectionState)) { throw null; }
        public static Azure.Communication.CallingServer.CallingOperationResultDetails CallingOperationResultDetails(int code = 0, int subcode = 0, string message = null) { throw null; }
        public static Azure.Communication.CallingServer.CallRecordingProperties CallRecordingProperties(Azure.Communication.CallingServer.CallRecordingState recordingState = default(Azure.Communication.CallingServer.CallRecordingState)) { throw null; }
        public static Azure.Communication.CallingServer.CallRecordingStateChangeEvent CallRecordingStateChangeEvent(string recordingId = null, Azure.Communication.CallingServer.CallRecordingState callRecordingState = default(Azure.Communication.CallingServer.CallRecordingState), System.DateTimeOffset startDateTime = default(System.DateTimeOffset), Azure.Communication.CallingServer.CallLocatorModel callLocator = null) { throw null; }
        public static Azure.Communication.CallingServer.CreateAudioRoutingGroupResult CreateAudioRoutingGroupResult(string audioRoutingGroupId = null) { throw null; }
        public static Azure.Communication.CallingServer.PlayAudioResult PlayAudioResult(string operationId = null, Azure.Communication.CallingServer.CallingOperationStatus status = default(Azure.Communication.CallingServer.CallingOperationStatus), string operationContext = null, Azure.Communication.CallingServer.CallingOperationResultDetails resultInfo = null) { throw null; }
        public static Azure.Communication.CallingServer.PlayAudioResultEvent PlayAudioResultEvent(Azure.Communication.CallingServer.CallingOperationResultDetails resultInfo = null, string operationContext = null, Azure.Communication.CallingServer.CallingOperationStatus status = default(Azure.Communication.CallingServer.CallingOperationStatus)) { throw null; }
        public static Azure.Communication.CallingServer.StartCallRecordingResult StartCallRecordingResult(string recordingId = null) { throw null; }
        public static Azure.Communication.CallingServer.ToneInfo ToneInfo(int sequenceId = 0, Azure.Communication.CallingServer.ToneValue tone = default(Azure.Communication.CallingServer.ToneValue)) { throw null; }
        public static Azure.Communication.CallingServer.ToneReceivedEvent ToneReceivedEvent(Azure.Communication.CallingServer.ToneInfo toneInfo = null, string callConnectionId = null) { throw null; }
        public static Azure.Communication.CallingServer.TransferCallResult TransferCallResult(string operationId = null, Azure.Communication.CallingServer.CallingOperationStatus status = default(Azure.Communication.CallingServer.CallingOperationStatus), string operationContext = null, Azure.Communication.CallingServer.CallingOperationResultDetails resultInfo = null) { throw null; }
    }
    public abstract partial class CallLocator : System.IEquatable<Azure.Communication.CallingServer.CallLocator>
    {
        protected CallLocator() { }
        public abstract bool Equals(Azure.Communication.CallingServer.CallLocator other);
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct CallLocatorKindModel : System.IEquatable<Azure.Communication.CallingServer.CallLocatorKindModel>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public CallLocatorKindModel(string value) { throw null; }
        public static Azure.Communication.CallingServer.CallLocatorKindModel GroupCallLocator { get { throw null; } }
        public static Azure.Communication.CallingServer.CallLocatorKindModel ServerCallLocator { get { throw null; } }
        public bool Equals(Azure.Communication.CallingServer.CallLocatorKindModel other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Communication.CallingServer.CallLocatorKindModel left, Azure.Communication.CallingServer.CallLocatorKindModel right) { throw null; }
        public static implicit operator Azure.Communication.CallingServer.CallLocatorKindModel (string value) { throw null; }
        public static bool operator !=(Azure.Communication.CallingServer.CallLocatorKindModel left, Azure.Communication.CallingServer.CallLocatorKindModel right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class CallLocatorModel
    {
        public CallLocatorModel() { }
        public string GroupCallId { get { throw null; } set { } }
        public Azure.Communication.CallingServer.CallLocatorKindModel? Kind { get { throw null; } set { } }
        public string ServerCallId { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct CallMediaType : System.IEquatable<Azure.Communication.CallingServer.CallMediaType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public CallMediaType(string value) { throw null; }
        public static Azure.Communication.CallingServer.CallMediaType Audio { get { throw null; } }
        public static Azure.Communication.CallingServer.CallMediaType Video { get { throw null; } }
        public bool Equals(Azure.Communication.CallingServer.CallMediaType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Communication.CallingServer.CallMediaType left, Azure.Communication.CallingServer.CallMediaType right) { throw null; }
        public static implicit operator Azure.Communication.CallingServer.CallMediaType (string value) { throw null; }
        public static bool operator !=(Azure.Communication.CallingServer.CallMediaType left, Azure.Communication.CallingServer.CallMediaType right) { throw null; }
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
        public Azure.Communication.CallingServer.CallLocatorModel CallLocator { get { throw null; } }
        public Azure.Communication.CallingServer.CallRecordingState CallRecordingState { get { throw null; } }
        public string RecordingId { get { throw null; } }
        public System.DateTimeOffset StartDateTime { get { throw null; } }
        public static Azure.Communication.CallingServer.CallRecordingStateChangeEvent Deserialize(string content) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct CallRejectReason : System.IEquatable<Azure.Communication.CallingServer.CallRejectReason>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public CallRejectReason(string value) { throw null; }
        public static Azure.Communication.CallingServer.CallRejectReason Busy { get { throw null; } }
        public static Azure.Communication.CallingServer.CallRejectReason Forbidden { get { throw null; } }
        public static Azure.Communication.CallingServer.CallRejectReason None { get { throw null; } }
        public bool Equals(Azure.Communication.CallingServer.CallRejectReason other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Communication.CallingServer.CallRejectReason left, Azure.Communication.CallingServer.CallRejectReason right) { throw null; }
        public static implicit operator Azure.Communication.CallingServer.CallRejectReason (string value) { throw null; }
        public static bool operator !=(Azure.Communication.CallingServer.CallRejectReason left, Azure.Communication.CallingServer.CallRejectReason right) { throw null; }
        public override string ToString() { throw null; }
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
    public partial class CreateAudioRoutingGroupResult
    {
        internal CreateAudioRoutingGroupResult() { }
        public string AudioRoutingGroupId { get { throw null; } }
    }
    public partial class CreateCallOptions
    {
        public CreateCallOptions(System.Uri callbackUri, System.Collections.Generic.IEnumerable<Azure.Communication.CallingServer.CallMediaType> requestedMediaTypes, System.Collections.Generic.IEnumerable<Azure.Communication.CallingServer.CallingEventSubscriptionType> requestedCallEvents) { }
        public Azure.Communication.PhoneNumberIdentifier AlternateCallerId { get { throw null; } set { } }
        public System.Uri CallbackUri { get { throw null; } }
        public System.Collections.Generic.IList<Azure.Communication.CallingServer.CallingEventSubscriptionType> RequestedCallEvents { get { throw null; } }
        public System.Collections.Generic.IList<Azure.Communication.CallingServer.CallMediaType> RequestedMediaTypes { get { throw null; } }
        public string Subject { get { throw null; } set { } }
    }
    public partial class GroupCallLocator : Azure.Communication.CallingServer.CallLocator
    {
        public GroupCallLocator(string id) { }
        public string Id { get { throw null; } }
        public override bool Equals(Azure.Communication.CallingServer.CallLocator other) { throw null; }
        public override int GetHashCode() { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class JoinCallOptions
    {
        public JoinCallOptions(System.Uri callbackUri, System.Collections.Generic.IEnumerable<Azure.Communication.CallingServer.CallMediaType> requestedMediaTypes, System.Collections.Generic.IEnumerable<Azure.Communication.CallingServer.CallingEventSubscriptionType> requestedCallEvents) { }
        public System.Uri CallbackUri { get { throw null; } }
        public System.Collections.Generic.IList<Azure.Communication.CallingServer.CallingEventSubscriptionType> RequestedCallEvents { get { throw null; } }
        public System.Collections.Generic.IList<Azure.Communication.CallingServer.CallMediaType> RequestedMediaTypes { get { throw null; } }
        public string Subject { get { throw null; } set { } }
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
        public System.Uri CallbackUri { get { throw null; } set { } }
        public bool Loop { get { throw null; } set { } }
        public string OperationContext { get { throw null; } set { } }
    }
    public partial class PlayAudioResult
    {
        internal PlayAudioResult() { }
        public string OperationContext { get { throw null; } }
        public string OperationId { get { throw null; } }
        public Azure.Communication.CallingServer.CallingOperationResultDetails ResultInfo { get { throw null; } }
        public Azure.Communication.CallingServer.CallingOperationStatus Status { get { throw null; } }
    }
    public partial class PlayAudioResultEvent : Azure.Communication.CallingServer.CallingServerEventBase
    {
        internal PlayAudioResultEvent() { }
        public string OperationContext { get { throw null; } }
        public Azure.Communication.CallingServer.CallingOperationResultDetails ResultInfo { get { throw null; } }
        public Azure.Communication.CallingServer.CallingOperationStatus Status { get { throw null; } }
        public static Azure.Communication.CallingServer.PlayAudioResultEvent Deserialize(string content) { throw null; }
    }
    public enum RecordingChannel
    {
        Mixed = 0,
        Unmixed = 1,
    }
    public enum RecordingContent
    {
        Audio = 0,
        AudioVideo = 1,
    }
    public enum RecordingFormat
    {
        Wav = 0,
        Mp3 = 1,
        Mp4 = 2,
    }
    public partial class ServerCallLocator : Azure.Communication.CallingServer.CallLocator
    {
        public ServerCallLocator(string id) { }
        public string Id { get { throw null; } }
        public override bool Equals(Azure.Communication.CallingServer.CallLocator other) { throw null; }
        public override int GetHashCode() { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class StartCallRecordingResult
    {
        internal StartCallRecordingResult() { }
        public string RecordingId { get { throw null; } }
    }
    public partial class StartHoldMusicOptions
    {
        public StartHoldMusicOptions() { }
        public string AudioFileId { get { throw null; } set { } }
        public System.Uri AudioFileUri { get { throw null; } set { } }
        public System.Uri CallbackUri { get { throw null; } set { } }
        public bool Loop { get { throw null; } set { } }
        public string OperationContext { get { throw null; } set { } }
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
    public partial class TransferCallResult
    {
        internal TransferCallResult() { }
        public string OperationContext { get { throw null; } }
        public string OperationId { get { throw null; } }
        public Azure.Communication.CallingServer.CallingOperationResultDetails ResultInfo { get { throw null; } }
        public Azure.Communication.CallingServer.CallingOperationStatus Status { get { throw null; } }
    }
}
