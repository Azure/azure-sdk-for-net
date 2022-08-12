namespace Azure.Communication.CallingServer
{
    public partial class AddParticipantsFailed : Azure.Communication.CallingServer.CallAutomationEventBase
    {
        internal AddParticipantsFailed() { }
        public string OperationContext { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Communication.CommunicationIdentifier> Participants { get { throw null; } }
        public Azure.Communication.CallingServer.ResultInformation ResultInfo { get { throw null; } }
        public static Azure.Communication.CallingServer.AddParticipantsFailed Deserialize(string content) { throw null; }
    }
    public partial class AddParticipantsOptions
    {
        public AddParticipantsOptions() { }
        public int? InvitationTimeoutInSeconds { get { throw null; } set { } }
        public string OperationContext { get { throw null; } set { } }
        public Azure.Communication.PhoneNumberIdentifier SourceCallerId { get { throw null; } set { } }
    }
    public partial class AddParticipantsResult
    {
        internal AddParticipantsResult() { }
        public string OperationContext { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Communication.CallingServer.CallParticipant> Participants { get { throw null; } }
    }
    public partial class AddParticipantsSucceeded : Azure.Communication.CallingServer.CallAutomationEventBase
    {
        internal AddParticipantsSucceeded() { }
        public string OperationContext { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Communication.CommunicationIdentifier> Participants { get { throw null; } }
        public Azure.Communication.CallingServer.ResultInformation ResultInfo { get { throw null; } }
        public static Azure.Communication.CallingServer.AddParticipantsSucceeded Deserialize(string content) { throw null; }
    }
    public partial class AnswerCallResult
    {
        internal AnswerCallResult() { }
        public Azure.Communication.CallingServer.CallConnection CallConnection { get { throw null; } }
        public Azure.Communication.CallingServer.CallConnectionProperties CallProperties { get { throw null; } }
    }
    public partial class CallAutomationClient
    {
        protected CallAutomationClient() { }
        public CallAutomationClient(string connectionString) { }
        public CallAutomationClient(string connectionString, Azure.Communication.CallingServer.CallAutomationClientOptions options) { }
        public CallAutomationClient(System.Uri endpoint, Azure.Core.TokenCredential credential, Azure.Communication.CallingServer.CallAutomationClientOptions options = null) { }
        public CallAutomationClient(System.Uri pmaEndpoint, string connectionString, Azure.Communication.CallingServer.CallAutomationClientOptions options = null) { }
        public virtual Azure.Response<Azure.Communication.CallingServer.AnswerCallResult> AnswerCall(string incomingCallContext, System.Uri callbackEndpoint, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Communication.CallingServer.AnswerCallResult>> AnswerCallAsync(string incomingCallContext, System.Uri callbackEndpoint, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Communication.CallingServer.CreateCallResult> CreateCall(Azure.Communication.CallingServer.CallSource source, System.Collections.Generic.IEnumerable<Azure.Communication.CommunicationIdentifier> targets, System.Uri callbackEndpoint, string subject = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Communication.CallingServer.CreateCallResult>> CreateCallAsync(Azure.Communication.CallingServer.CallSource source, System.Collections.Generic.IEnumerable<Azure.Communication.CommunicationIdentifier> targets, System.Uri callbackEndpoint, string subject = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Communication.CallingServer.CallConnection GetCallConnection(string callConnectionId) { throw null; }
        public virtual Azure.Communication.CallingServer.CallRecording GetCallRecording() { throw null; }
        public virtual Azure.Response RedirectCall(string incomingCallContext, Azure.Communication.CommunicationIdentifier target, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> RedirectCallAsync(string incomingCallContext, Azure.Communication.CommunicationIdentifier target, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response RejectCall(string incomingCallContext, Azure.Communication.CallingServer.CallRejectReason callRejectReason, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> RejectCallAsync(string incomingCallContext, Azure.Communication.CallingServer.CallRejectReason callRejectReason, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class CallAutomationClientOptions : Azure.Core.ClientOptions
    {
        public CallAutomationClientOptions(Azure.Communication.CallingServer.CallAutomationClientOptions.ServiceVersion version = Azure.Communication.CallingServer.CallAutomationClientOptions.ServiceVersion.V2022_04_07_Preview) { }
        public enum ServiceVersion
        {
            V2022_04_07_Preview = 1,
        }
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
        public static Azure.Communication.CallingServer.CallAutomationEventBase Parse(Azure.Messaging.CloudEvent cloudEvent) { throw null; }
        public static Azure.Communication.CallingServer.CallAutomationEventBase Parse(System.BinaryData json) { throw null; }
        public static Azure.Communication.CallingServer.CallAutomationEventBase Parse(string eventData, string eventType) { throw null; }
        public static Azure.Communication.CallingServer.CallAutomationEventBase[] ParseMany(Azure.Messaging.CloudEvent[] cloudEvents) { throw null; }
        public static Azure.Communication.CallingServer.CallAutomationEventBase[] ParseMany(System.BinaryData json) { throw null; }
    }
    public static partial class CallAutomationModelFactory
    {
        public static Azure.Communication.CallingServer.AddParticipantsFailed AddParticipantsFailed(string operationContext = null, Azure.Communication.CallingServer.ResultInformation resultInformation = null, System.Collections.Generic.IEnumerable<Azure.Communication.CommunicationIdentifier> participants = null, string callConnectionId = null, string serverCallId = null, string correlationId = null) { throw null; }
        public static Azure.Communication.CallingServer.AddParticipantsResult AddParticipantsResult(System.Collections.Generic.IEnumerable<Azure.Communication.CallingServer.CallParticipant> participants = null, string operationContext = null) { throw null; }
        public static Azure.Communication.CallingServer.AddParticipantsSucceeded AddParticipantsSucceeded(string operationContext = null, Azure.Communication.CallingServer.ResultInformation resultInformation = null, System.Collections.Generic.IEnumerable<Azure.Communication.CommunicationIdentifier> participants = null, string callConnectionId = null, string serverCallId = null, string correlationId = null) { throw null; }
        public static Azure.Communication.CallingServer.AnswerCallResult AnswerCallResult(Azure.Communication.CallingServer.CallConnection callConnection = null, Azure.Communication.CallingServer.CallConnectionProperties callProperties = null) { throw null; }
        public static Azure.Communication.CallingServer.CallConnected CallConnected(string callConnectionId = null, string serverCallId = null, string correlationId = null) { throw null; }
        public static Azure.Communication.CallingServer.CallConnectionProperties CallConnectionProperties(string callConnectionId = null, string serverCallId = null, Azure.Communication.CallingServer.CallSource callSource = null, System.Collections.Generic.IEnumerable<Azure.Communication.CommunicationIdentifier> targets = null, Azure.Communication.CallingServer.CallConnectionState callConnectionState = default(Azure.Communication.CallingServer.CallConnectionState), string subject = null, System.Uri callbackEndpoint = null) { throw null; }
        public static Azure.Communication.CallingServer.CallDisconnected CallDisconnected(string callConnectionId = null, string serverCallId = null, string correlationId = null) { throw null; }
        public static Azure.Communication.CallingServer.CallParticipant CallParticipant(Azure.Communication.CommunicationIdentifier identifier = null, bool isMuted = false) { throw null; }
        public static Azure.Communication.CallingServer.CallTransferAccepted CallTransferAccepted(string operationContext = null, Azure.Communication.CallingServer.ResultInformation resultInformation = null, string callConnectionId = null, string serverCallId = null, string correlationId = null) { throw null; }
        public static Azure.Communication.CallingServer.CallTransferFailed CallTransferFailed(string operationContext = null, Azure.Communication.CallingServer.ResultInformation resultInformation = null, string callConnectionId = null, string serverCallId = null, string correlationId = null) { throw null; }
        public static Azure.Communication.CallingServer.CreateCallResult CreateCallResult(Azure.Communication.CallingServer.CallConnection callConnection = null, Azure.Communication.CallingServer.CallConnectionProperties callProperties = null) { throw null; }
        public static Azure.Communication.CallingServer.ParticipantsUpdated ParticipantsUpdated(System.Collections.Generic.IEnumerable<Azure.Communication.CommunicationIdentifier> participants = null, string callConnectionId = null, string serverCallId = null, string correlationId = null) { throw null; }
        public static Azure.Communication.CallingServer.RecordingStatusResult RecordingStatusResult(string recordingId = null, Azure.Communication.CallingServer.RecordingStatus? recordingStatus = default(Azure.Communication.CallingServer.RecordingStatus?)) { throw null; }
        public static Azure.Communication.CallingServer.RemoveParticipantsResult RemoveParticipantsResult(string operationContext = null) { throw null; }
        public static Azure.Communication.CallingServer.ResultInformation ResultInformation(int? code = default(int?), int? subCode = default(int?), string message = null) { throw null; }
        public static Azure.Communication.CallingServer.TransferCallToParticipantResult TransferCallToParticipantResult(string operationContext = null) { throw null; }
    }
    public partial class CallConnected : Azure.Communication.CallingServer.CallAutomationEventBase
    {
        internal CallConnected() { }
        public static Azure.Communication.CallingServer.CallConnected Deserialize(string content) { throw null; }
    }
    public partial class CallConnection
    {
        protected CallConnection() { }
        public virtual string CallConnectionId { get { throw null; } }
        public virtual Azure.Response<Azure.Communication.CallingServer.AddParticipantsResult> AddParticipants(System.Collections.Generic.IEnumerable<Azure.Communication.CommunicationIdentifier> participantsToAdd, Azure.Communication.CallingServer.AddParticipantsOptions options = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Communication.CallingServer.AddParticipantsResult>> AddParticipantsAsync(System.Collections.Generic.IEnumerable<Azure.Communication.CommunicationIdentifier> participantsToAdd, Azure.Communication.CallingServer.AddParticipantsOptions options = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Communication.CallingServer.CallMedia GetCallMedia() { throw null; }
        public virtual Azure.Response<Azure.Communication.CallingServer.CallParticipant> GetParticipant(string participantMri, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Communication.CallingServer.CallParticipant>> GetParticipantAsync(string participantMri, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<System.Collections.Generic.IReadOnlyList<Azure.Communication.CallingServer.CallParticipant>> GetParticipants(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<System.Collections.Generic.IReadOnlyList<Azure.Communication.CallingServer.CallParticipant>>> GetParticipantsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Communication.CallingServer.CallConnectionProperties> GetProperties(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Communication.CallingServer.CallConnectionProperties>> GetPropertiesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response HangUp(bool forEveryone, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> HangUpAsync(bool forEveryone, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Communication.CallingServer.RemoveParticipantsResult> RemoveParticipants(System.Collections.Generic.IEnumerable<Azure.Communication.CommunicationIdentifier> participantsToRemove, Azure.Communication.CallingServer.RemoveParticipantsOptions options = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Communication.CallingServer.RemoveParticipantsResult>> RemoveParticipantsAsync(System.Collections.Generic.IEnumerable<Azure.Communication.CommunicationIdentifier> participantsToRemove, Azure.Communication.CallingServer.RemoveParticipantsOptions options = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Communication.CallingServer.TransferCallToParticipantResult> TransferCallToParticipant(Azure.Communication.CommunicationIdentifier targetParticipant, Azure.Communication.CallingServer.TransferCallToParticipantOptions options = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Communication.CallingServer.TransferCallToParticipantResult>> TransferCallToParticipantAsync(Azure.Communication.CommunicationIdentifier targetParticipant, Azure.Communication.CallingServer.TransferCallToParticipantOptions options = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class CallConnectionProperties
    {
        internal CallConnectionProperties() { }
        public System.Uri CallbackEndpoint { get { throw null; } }
        public string CallConnectionId { get { throw null; } }
        public Azure.Communication.CallingServer.CallConnectionState? CallConnectionState { get { throw null; } }
        public Azure.Communication.CallingServer.CallSource CallSource { get { throw null; } }
        public string ServerCallId { get { throw null; } }
        public string Subject { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Communication.CommunicationIdentifier> Targets { get { throw null; } }
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
        public static Azure.Communication.CallingServer.CallConnectionState Unknown { get { throw null; } }
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
    public partial class CallDisconnected : Azure.Communication.CallingServer.CallAutomationEventBase
    {
        internal CallDisconnected() { }
        public static Azure.Communication.CallingServer.CallDisconnected Deserialize(string content) { throw null; }
    }
    public abstract partial class CallLocator : System.IEquatable<Azure.Communication.CallingServer.CallLocator>
    {
        protected CallLocator() { }
        public string Id { get { throw null; } }
        public abstract bool Equals(Azure.Communication.CallingServer.CallLocator other);
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
    }
    public partial class CallMedia
    {
        protected CallMedia() { }
        public virtual string CallConnectionId { get { throw null; } }
        public virtual Azure.Response CancelAllMediaOperations(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> CancelAllMediaOperationsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response Play(Azure.Communication.CallingServer.PlaySource playSource, System.Collections.Generic.IEnumerable<Azure.Communication.CommunicationIdentifier> playTo, Azure.Communication.CallingServer.PlayOptions playOptions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> PlayAsync(Azure.Communication.CallingServer.PlaySource playSource, System.Collections.Generic.IEnumerable<Azure.Communication.CommunicationIdentifier> playTo, Azure.Communication.CallingServer.PlayOptions playOptions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response PlayToAll(Azure.Communication.CallingServer.PlaySource playSource, Azure.Communication.CallingServer.PlayOptions playOptions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> PlayToAllAsync(Azure.Communication.CallingServer.PlaySource playSource, Azure.Communication.CallingServer.PlayOptions playOptions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
        public virtual Azure.Response DownloadTo(System.Uri sourceLocation, System.IO.Stream destinationStream, Azure.Communication.CallingServer.ContentTransferOptions transferOptions = default(Azure.Communication.CallingServer.ContentTransferOptions), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response DownloadTo(System.Uri sourceLocation, string destinationPath, Azure.Communication.CallingServer.ContentTransferOptions transferOptions = default(Azure.Communication.CallingServer.ContentTransferOptions), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DownloadToAsync(System.Uri sourceLocation, System.IO.Stream destinationStream, Azure.Communication.CallingServer.ContentTransferOptions transferOptions = default(Azure.Communication.CallingServer.ContentTransferOptions), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DownloadToAsync(System.Uri sourceLocation, string destinationPath, Azure.Communication.CallingServer.ContentTransferOptions transferOptions = default(Azure.Communication.CallingServer.ContentTransferOptions), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Communication.CallingServer.RecordingStatusResult> GetRecordingState(string recordingId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Communication.CallingServer.RecordingStatusResult>> GetRecordingStateAsync(string recordingId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response PauseRecording(string recordingId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> PauseRecordingAsync(string recordingId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response ResumeRecording(string recordingId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> ResumeRecordingAsync(string recordingId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Communication.CallingServer.RecordingStatusResult> StartRecording(Azure.Communication.CallingServer.StartRecordingOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Communication.CallingServer.RecordingStatusResult>> StartRecordingAsync(Azure.Communication.CallingServer.StartRecordingOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response StopRecording(string recordingId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> StopRecordingAsync(string recordingId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
    public partial class CallSource
    {
        public CallSource(Azure.Communication.CommunicationIdentifier identifier) { }
        public Azure.Communication.PhoneNumberIdentifier CallerId { get { throw null; } set { } }
        public Azure.Communication.CommunicationIdentifier Identifier { get { throw null; } }
    }
    public partial class CallTransferAccepted : Azure.Communication.CallingServer.CallAutomationEventBase
    {
        internal CallTransferAccepted() { }
        public string OperationContext { get { throw null; } }
        public Azure.Communication.CallingServer.ResultInformation ResultInfo { get { throw null; } }
        public static Azure.Communication.CallingServer.CallTransferAccepted Deserialize(string content) { throw null; }
    }
    public partial class CallTransferFailed : Azure.Communication.CallingServer.CallAutomationEventBase
    {
        internal CallTransferFailed() { }
        public string OperationContext { get { throw null; } }
        public Azure.Communication.CallingServer.ResultInformation ResultInfo { get { throw null; } }
        public static Azure.Communication.CallingServer.CallTransferFailed Deserialize(string content) { throw null; }
    }
    public partial class ChannelAffinity
    {
        public ChannelAffinity() { }
        public int Channel { get { throw null; } set { } }
        public Azure.Communication.CommunicationIdentifier Participant { get { throw null; } set { } }
    }
    public partial class CollectTones
    {
        public CollectTones() { }
        public int? InterToneTimeoutInSeconds { get { throw null; } set { } }
        public int? MaxTonesToCollect { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> StopTones { get { throw null; } }
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
    public partial class CreateCallResult
    {
        internal CreateCallResult() { }
        public Azure.Communication.CallingServer.CallConnection CallConnection { get { throw null; } }
        public Azure.Communication.CallingServer.CallConnectionProperties CallProperties { get { throw null; } }
    }
    public partial class FileSource : Azure.Communication.CallingServer.PlaySource
    {
        public FileSource(System.Uri fileUri) { }
        public System.Uri FileUri { get { throw null; } }
    }
    public partial class GroupCallLocator : Azure.Communication.CallingServer.CallLocator
    {
        public GroupCallLocator(string id) { }
        public override bool Equals(Azure.Communication.CallingServer.CallLocator other) { throw null; }
        public override int GetHashCode() { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MediaStreamingAudioChannelTypeDto : System.IEquatable<Azure.Communication.CallingServer.MediaStreamingAudioChannelTypeDto>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MediaStreamingAudioChannelTypeDto(string value) { throw null; }
        public static Azure.Communication.CallingServer.MediaStreamingAudioChannelTypeDto Mixed { get { throw null; } }
        public static Azure.Communication.CallingServer.MediaStreamingAudioChannelTypeDto Unmixed { get { throw null; } }
        public bool Equals(Azure.Communication.CallingServer.MediaStreamingAudioChannelTypeDto other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Communication.CallingServer.MediaStreamingAudioChannelTypeDto left, Azure.Communication.CallingServer.MediaStreamingAudioChannelTypeDto right) { throw null; }
        public static implicit operator Azure.Communication.CallingServer.MediaStreamingAudioChannelTypeDto (string value) { throw null; }
        public static bool operator !=(Azure.Communication.CallingServer.MediaStreamingAudioChannelTypeDto left, Azure.Communication.CallingServer.MediaStreamingAudioChannelTypeDto right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class MediaStreamingConfigurationDto
    {
        public MediaStreamingConfigurationDto() { }
        public Azure.Communication.CallingServer.MediaStreamingAudioChannelTypeDto? AudioChannelType { get { throw null; } set { } }
        public Azure.Communication.CallingServer.MediaStreamingContentTypeDto? ContentType { get { throw null; } set { } }
        public Azure.Communication.CallingServer.MediaStreamingTransportTypeDto? TransportType { get { throw null; } set { } }
        public string TransportUrl { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MediaStreamingContentTypeDto : System.IEquatable<Azure.Communication.CallingServer.MediaStreamingContentTypeDto>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MediaStreamingContentTypeDto(string value) { throw null; }
        public static Azure.Communication.CallingServer.MediaStreamingContentTypeDto Audio { get { throw null; } }
        public bool Equals(Azure.Communication.CallingServer.MediaStreamingContentTypeDto other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Communication.CallingServer.MediaStreamingContentTypeDto left, Azure.Communication.CallingServer.MediaStreamingContentTypeDto right) { throw null; }
        public static implicit operator Azure.Communication.CallingServer.MediaStreamingContentTypeDto (string value) { throw null; }
        public static bool operator !=(Azure.Communication.CallingServer.MediaStreamingContentTypeDto left, Azure.Communication.CallingServer.MediaStreamingContentTypeDto right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MediaStreamingTransportTypeDto : System.IEquatable<Azure.Communication.CallingServer.MediaStreamingTransportTypeDto>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MediaStreamingTransportTypeDto(string value) { throw null; }
        public static Azure.Communication.CallingServer.MediaStreamingTransportTypeDto Websocket { get { throw null; } }
        public bool Equals(Azure.Communication.CallingServer.MediaStreamingTransportTypeDto other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Communication.CallingServer.MediaStreamingTransportTypeDto left, Azure.Communication.CallingServer.MediaStreamingTransportTypeDto right) { throw null; }
        public static implicit operator Azure.Communication.CallingServer.MediaStreamingTransportTypeDto (string value) { throw null; }
        public static bool operator !=(Azure.Communication.CallingServer.MediaStreamingTransportTypeDto left, Azure.Communication.CallingServer.MediaStreamingTransportTypeDto right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ParticipantsUpdated : Azure.Communication.CallingServer.CallAutomationEventBase
    {
        internal ParticipantsUpdated() { }
        public System.Collections.Generic.IReadOnlyList<Azure.Communication.CommunicationIdentifier> Participants { get { throw null; } }
        public static Azure.Communication.CallingServer.ParticipantsUpdated Deserialize(string content) { throw null; }
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
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RecognizeInputType : System.IEquatable<Azure.Communication.CallingServer.RecognizeInputType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RecognizeInputType(string value) { throw null; }
        public static Azure.Communication.CallingServer.RecognizeInputType DTMF { get { throw null; } }
        public bool Equals(Azure.Communication.CallingServer.RecognizeInputType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Communication.CallingServer.RecognizeInputType left, Azure.Communication.CallingServer.RecognizeInputType right) { throw null; }
        public static implicit operator Azure.Communication.CallingServer.RecognizeInputType (string value) { throw null; }
        public static bool operator !=(Azure.Communication.CallingServer.RecognizeInputType left, Azure.Communication.CallingServer.RecognizeInputType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RecordingChannel : System.IEquatable<Azure.Communication.CallingServer.RecordingChannel>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RecordingChannel(string value) { throw null; }
        public static Azure.Communication.CallingServer.RecordingChannel Mixed { get { throw null; } }
        public static Azure.Communication.CallingServer.RecordingChannel Unmixed { get { throw null; } }
        public bool Equals(Azure.Communication.CallingServer.RecordingChannel other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Communication.CallingServer.RecordingChannel left, Azure.Communication.CallingServer.RecordingChannel right) { throw null; }
        public static implicit operator Azure.Communication.CallingServer.RecordingChannel (string value) { throw null; }
        public static bool operator !=(Azure.Communication.CallingServer.RecordingChannel left, Azure.Communication.CallingServer.RecordingChannel right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RecordingContent : System.IEquatable<Azure.Communication.CallingServer.RecordingContent>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RecordingContent(string value) { throw null; }
        public static Azure.Communication.CallingServer.RecordingContent Audio { get { throw null; } }
        public static Azure.Communication.CallingServer.RecordingContent AudioVideo { get { throw null; } }
        public bool Equals(Azure.Communication.CallingServer.RecordingContent other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Communication.CallingServer.RecordingContent left, Azure.Communication.CallingServer.RecordingContent right) { throw null; }
        public static implicit operator Azure.Communication.CallingServer.RecordingContent (string value) { throw null; }
        public static bool operator !=(Azure.Communication.CallingServer.RecordingContent left, Azure.Communication.CallingServer.RecordingContent right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RecordingFormat : System.IEquatable<Azure.Communication.CallingServer.RecordingFormat>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RecordingFormat(string value) { throw null; }
        public static Azure.Communication.CallingServer.RecordingFormat Mp3 { get { throw null; } }
        public static Azure.Communication.CallingServer.RecordingFormat Mp4 { get { throw null; } }
        public static Azure.Communication.CallingServer.RecordingFormat Wav { get { throw null; } }
        public bool Equals(Azure.Communication.CallingServer.RecordingFormat other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Communication.CallingServer.RecordingFormat left, Azure.Communication.CallingServer.RecordingFormat right) { throw null; }
        public static implicit operator Azure.Communication.CallingServer.RecordingFormat (string value) { throw null; }
        public static bool operator !=(Azure.Communication.CallingServer.RecordingFormat left, Azure.Communication.CallingServer.RecordingFormat right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RecordingStatus : System.IEquatable<Azure.Communication.CallingServer.RecordingStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RecordingStatus(string value) { throw null; }
        public static Azure.Communication.CallingServer.RecordingStatus Active { get { throw null; } }
        public static Azure.Communication.CallingServer.RecordingStatus Inactive { get { throw null; } }
        public bool Equals(Azure.Communication.CallingServer.RecordingStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Communication.CallingServer.RecordingStatus left, Azure.Communication.CallingServer.RecordingStatus right) { throw null; }
        public static implicit operator Azure.Communication.CallingServer.RecordingStatus (string value) { throw null; }
        public static bool operator !=(Azure.Communication.CallingServer.RecordingStatus left, Azure.Communication.CallingServer.RecordingStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class RecordingStatusResult
    {
        internal RecordingStatusResult() { }
        public string RecordingId { get { throw null; } }
        public Azure.Communication.CallingServer.RecordingStatus? RecordingStatus { get { throw null; } }
    }
    public partial class RemoveParticipantsOptions
    {
        public RemoveParticipantsOptions() { }
        public string OperationContext { get { throw null; } set { } }
    }
    public partial class RemoveParticipantsResult
    {
        internal RemoveParticipantsResult() { }
        public string OperationContext { get { throw null; } }
    }
    public partial class ResultInformation
    {
        internal ResultInformation() { }
        public int? Code { get { throw null; } }
        public string Message { get { throw null; } }
        public int? SubCode { get { throw null; } }
    }
    public partial class ServerCallLocator : Azure.Communication.CallingServer.CallLocator
    {
        public ServerCallLocator(string id) { }
        public override bool Equals(Azure.Communication.CallingServer.CallLocator other) { throw null; }
        public override int GetHashCode() { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class StartRecordingOptions
    {
        public StartRecordingOptions(Azure.Communication.CallingServer.CallLocator callLocator) { }
        public System.Collections.Generic.IEnumerable<Azure.Communication.CallingServer.ChannelAffinity> ChannelAffinity { get { throw null; } set { } }
        public Azure.Communication.CallingServer.RecordingChannel RecordingChannel { get { throw null; } set { } }
        public Azure.Communication.CallingServer.RecordingContent RecordingContent { get { throw null; } set { } }
        public Azure.Communication.CallingServer.RecordingFormat RecordingFormat { get { throw null; } set { } }
        public System.Uri RecordingStateCallbackEndpoint { get { throw null; } set { } }
    }
    public partial class TransferCallToParticipantOptions
    {
        public TransferCallToParticipantOptions() { }
        public string OperationContext { get { throw null; } set { } }
        public Azure.Communication.PhoneNumberIdentifier SourceCallerId { get { throw null; } set { } }
        public string UserToUserInformation { get { throw null; } set { } }
    }
    public partial class TransferCallToParticipantResult
    {
        internal TransferCallToParticipantResult() { }
        public string OperationContext { get { throw null; } }
    }
}
