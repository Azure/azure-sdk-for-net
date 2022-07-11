namespace Azure.Communication.CallingServer
{
    public partial class AddParticipantsOptions
    {
        public AddParticipantsOptions(Azure.Communication.PhoneNumberIdentifier alternateCallerId, string operationContext, int invitationTimeoutInSeconds, string replacementCallConnectionId) { }
        public Azure.Communication.PhoneNumberIdentifier AlternateCallerId { get { throw null; } set { } }
        public int InvitationTimeoutInSeconds { get { throw null; } set { } }
        public string OperationContext { get { throw null; } set { } }
        public string ReplacementCallConnectionId { get { throw null; } set { } }
    }
    public partial class AddParticipantsResponse
    {
        internal AddParticipantsResponse() { }
        public string OperationContext { get { throw null; } }
        public string OperationId { get { throw null; } }
        public Azure.Communication.CallingServer.CallingOperationResultDetailsDto ResultDetails { get { throw null; } }
        public Azure.Communication.CallingServer.CallingOperationStatusDto Status { get { throw null; } }
    }
    public partial class AnswerCallRequest
    {
        public AnswerCallRequest(string incomingCallContext) { }
        public string CallbackUri { get { throw null; } set { } }
        public string IncomingCallContext { get { throw null; } }
    }
    public partial class CallConnection
    {
        protected CallConnection() { }
        public virtual Azure.Communication.PhoneNumberIdentifier AlternateCallerId { get { throw null; } }
        public virtual System.Uri CallbackUri { get { throw null; } }
        public virtual string CallConnectionId { get { throw null; } }
        public virtual Azure.Communication.CallingServer.CallConnectionStateModel? CallConnectionState { get { throw null; } }
        public virtual string ServerCallId { get { throw null; } }
        public virtual Azure.Communication.CommunicationIdentifier Source { get { throw null; } }
        public virtual string Subject { get { throw null; } }
        public virtual System.Collections.Generic.IEnumerable<Azure.Communication.CommunicationIdentifier> Targets { get { throw null; } }
        public virtual Azure.Communication.CallingServer.AddParticipantsResponse AddParticipant(System.Collections.Generic.IEnumerable<Azure.Communication.CommunicationIdentifier> participantsToAdd, Azure.Communication.CallingServer.AddParticipantsOptions options = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Communication.CallingServer.AddParticipantsResponse> AddParticipantAsync(System.Collections.Generic.IEnumerable<Azure.Communication.CommunicationIdentifier> participantsToAdd, Azure.Communication.CallingServer.AddParticipantsOptions options = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Communication.CallingServer.CallParticipant> GetParticipant(Azure.Communication.CommunicationIdentifier participant, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Communication.CallingServer.CallParticipant>> GetParticipantAsync(Azure.Communication.CommunicationIdentifier participant, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Communication.CallingServer.CallParticipantCollection> GetParticipants(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Communication.CallingServer.CallParticipantCollection>> GetParticipantsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response Hangup(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> HangupAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Communication.CallingServer.RemoveParticipantsResponse RemoveParticipant(System.Collections.Generic.IEnumerable<Azure.Communication.CommunicationIdentifier> participantsToRemove, string operationContext = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Communication.CallingServer.RemoveParticipantsResponse> RemoveParticipantAsync(System.Collections.Generic.IEnumerable<Azure.Communication.CommunicationIdentifier> participantsToRemove, string operationContext = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response TerminateCall(string reason, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> TerminateCallAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Communication.CallingServer.TransferCallResponse TransferCallToParticipant(Azure.Communication.CommunicationIdentifier targetParticipant, Azure.Communication.CallingServer.TransferCallOptions options = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Communication.CallingServer.TransferCallResponse> TransferCallToParticipantAsync(Azure.Communication.CommunicationIdentifier targetParticipant, Azure.Communication.CallingServer.TransferCallOptions options = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct CallConnectionStateModel : System.IEquatable<Azure.Communication.CallingServer.CallConnectionStateModel>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public CallConnectionStateModel(string value) { throw null; }
        public static Azure.Communication.CallingServer.CallConnectionStateModel Connected { get { throw null; } }
        public static Azure.Communication.CallingServer.CallConnectionStateModel Connecting { get { throw null; } }
        public static Azure.Communication.CallingServer.CallConnectionStateModel Disconnected { get { throw null; } }
        public static Azure.Communication.CallingServer.CallConnectionStateModel Disconnecting { get { throw null; } }
        public static Azure.Communication.CallingServer.CallConnectionStateModel TransferAccepted { get { throw null; } }
        public static Azure.Communication.CallingServer.CallConnectionStateModel Transferring { get { throw null; } }
        public static Azure.Communication.CallingServer.CallConnectionStateModel Unknown { get { throw null; } }
        public bool Equals(Azure.Communication.CallingServer.CallConnectionStateModel other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Communication.CallingServer.CallConnectionStateModel left, Azure.Communication.CallingServer.CallConnectionStateModel right) { throw null; }
        public static implicit operator Azure.Communication.CallingServer.CallConnectionStateModel (string value) { throw null; }
        public static bool operator !=(Azure.Communication.CallingServer.CallConnectionStateModel left, Azure.Communication.CallingServer.CallConnectionStateModel right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class CallingOperationResultDetailsDto
    {
        internal CallingOperationResultDetailsDto() { }
        public int Code { get { throw null; } }
        public string Message { get { throw null; } }
        public int Subcode { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct CallingOperationStatusDto : System.IEquatable<Azure.Communication.CallingServer.CallingOperationStatusDto>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public CallingOperationStatusDto(string value) { throw null; }
        public static Azure.Communication.CallingServer.CallingOperationStatusDto Completed { get { throw null; } }
        public static Azure.Communication.CallingServer.CallingOperationStatusDto Failed { get { throw null; } }
        public static Azure.Communication.CallingServer.CallingOperationStatusDto NotStarted { get { throw null; } }
        public static Azure.Communication.CallingServer.CallingOperationStatusDto Running { get { throw null; } }
        public bool Equals(Azure.Communication.CallingServer.CallingOperationStatusDto other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Communication.CallingServer.CallingOperationStatusDto left, Azure.Communication.CallingServer.CallingOperationStatusDto right) { throw null; }
        public static implicit operator Azure.Communication.CallingServer.CallingOperationStatusDto (string value) { throw null; }
        public static bool operator !=(Azure.Communication.CallingServer.CallingOperationStatusDto left, Azure.Communication.CallingServer.CallingOperationStatusDto right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class CallingServerClient
    {
        protected CallingServerClient() { }
        public CallingServerClient(string connectionString) { }
        public CallingServerClient(string connectionString, Azure.Communication.CallingServer.CallingServerClientOptions options) { }
        public CallingServerClient(System.Uri endpoint, Azure.Core.TokenCredential credential, Azure.Communication.CallingServer.CallingServerClientOptions options = null) { }
        public CallingServerClient(System.Uri pmaEndpoint, string connectionString, Azure.Communication.CallingServer.CallingServerClientOptions options = null) { }
        public virtual Azure.Response<Azure.Communication.CallingServer.CallConnection> AnswerCall(string incomingCallContext, System.Uri callbackUri, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Communication.CallingServer.CallConnection>> AnswerCallAsync(string incomingCallContext, System.Uri callbackUri, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Communication.CallingServer.CallConnection> CreateCall(Azure.Communication.CallingServer.Models.CallSource source, System.Collections.Generic.IEnumerable<Azure.Communication.CommunicationIdentifier> targets, System.Uri callbackUri, Azure.Communication.CallingServer.CreateCallOptions options = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Communication.CallingServer.CallConnection>> CreateCallAsync(Azure.Communication.CallingServer.Models.CallSource source, System.Collections.Generic.IEnumerable<Azure.Communication.CommunicationIdentifier> targets, System.Uri callbackUri, Azure.Communication.CallingServer.CreateCallOptions options = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response DeleteRecording(System.Uri deleteEndpoint, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteRecordingAsync(System.Uri deleteEndpoint, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<System.IO.Stream> DownloadStreaming(System.Uri sourceEndpoint, Azure.HttpRange range = default(Azure.HttpRange), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<System.IO.Stream>> DownloadStreamingAsync(System.Uri sourceEndpoint, Azure.HttpRange range = default(Azure.HttpRange), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response DownloadTo(System.Uri sourceEndpoint, System.IO.Stream destinationStream, Azure.Communication.CallingServer.ContentTransferOptions transferOptions = default(Azure.Communication.CallingServer.ContentTransferOptions), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response DownloadTo(System.Uri sourceEndpoint, string destinationPath, Azure.Communication.CallingServer.ContentTransferOptions transferOptions = default(Azure.Communication.CallingServer.ContentTransferOptions), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DownloadToAsync(System.Uri sourceEndpoint, System.IO.Stream destinationStream, Azure.Communication.CallingServer.ContentTransferOptions transferOptions = default(Azure.Communication.CallingServer.ContentTransferOptions), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DownloadToAsync(System.Uri sourceEndpoint, string destinationPath, Azure.Communication.CallingServer.ContentTransferOptions transferOptions = default(Azure.Communication.CallingServer.ContentTransferOptions), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Communication.CallingServer.CallConnection> GetCall(string callConnectionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Communication.CallingServer.CallConnection>> GetCallAsync(string callConnectionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Communication.CallingServer.GetCallRecordingStateResponse> GetRecordingState(string recordingId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Communication.CallingServer.GetCallRecordingStateResponse>> GetRecordingStateAsync(string recordingId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response PauseRecording(string recordingId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> PauseRecordingAsync(string recordingId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response RedirectCall(string incomingCallContext, Azure.Communication.CommunicationIdentifier target, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> RedirectCallAsync(string incomingCallContext, Azure.Communication.CommunicationIdentifier target, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response RejectCall(string incomingCallContext, Azure.Communication.CallingServer.CallRejectReason callRejectReason, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> RejectCallAsync(string incomingCallContext, Azure.Communication.CallingServer.CallRejectReason callRejectReason, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response ResumeRecording(string recordingId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> ResumeRecordingAsync(string recordingId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Communication.CallingServer.StartCallRecordingResponse> StartRecording(Azure.Communication.CallingServer.CallLocator callLocator, System.Uri recordingStateCallbackUri, Azure.Communication.CallingServer.RecordingContentType? content = default(Azure.Communication.CallingServer.RecordingContentType?), Azure.Communication.CallingServer.RecordingChannelType? channel = default(Azure.Communication.CallingServer.RecordingChannelType?), Azure.Communication.CallingServer.RecordingFormatType? format = default(Azure.Communication.CallingServer.RecordingFormatType?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Communication.CallingServer.StartCallRecordingResponse>> StartRecordingAsync(Azure.Communication.CallingServer.CallLocator callLocator, System.Uri recordingStateCallbackUri, Azure.Communication.CallingServer.RecordingContentType? content = default(Azure.Communication.CallingServer.RecordingContentType?), Azure.Communication.CallingServer.RecordingChannelType? channel = default(Azure.Communication.CallingServer.RecordingChannelType?), Azure.Communication.CallingServer.RecordingFormatType? format = default(Azure.Communication.CallingServer.RecordingFormatType?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response StopRecording(string recordingId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> StopRecordingAsync(string recordingId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class CallingServerClientOptions : Azure.Core.ClientOptions
    {
        public CallingServerClientOptions(Azure.Communication.CallingServer.CallingServerClientOptions.ServiceVersion version = Azure.Communication.CallingServer.CallingServerClientOptions.ServiceVersion.V2022_04_07_Preview) { }
        public enum ServiceVersion
        {
            V2022_04_07_Preview = 1,
        }
    }
    public partial class CallLocator
    {
        public CallLocator() { }
        public string GroupCallId { get { throw null; } set { } }
        public Azure.Communication.CallingServer.CallLocatorKind? Kind { get { throw null; } set { } }
        public string ServerCallId { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct CallLocatorKind : System.IEquatable<Azure.Communication.CallingServer.CallLocatorKind>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public CallLocatorKind(string value) { throw null; }
        public static Azure.Communication.CallingServer.CallLocatorKind GroupCallLocator { get { throw null; } }
        public static Azure.Communication.CallingServer.CallLocatorKind ServerCallLocator { get { throw null; } }
        public bool Equals(Azure.Communication.CallingServer.CallLocatorKind other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Communication.CallingServer.CallLocatorKind left, Azure.Communication.CallingServer.CallLocatorKind right) { throw null; }
        public static implicit operator Azure.Communication.CallingServer.CallLocatorKind (string value) { throw null; }
        public static bool operator !=(Azure.Communication.CallingServer.CallLocatorKind left, Azure.Communication.CallingServer.CallLocatorKind right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class CallParticipant
    {
        internal CallParticipant() { }
        public Azure.Communication.CommunicationIdentifier Identifier { get { throw null; } }
        public bool? IsMuted { get { throw null; } }
    }
    public partial class CallParticipantCollection
    {
        internal CallParticipantCollection() { }
        public System.Collections.Generic.IReadOnlyList<Azure.Communication.CallingServer.CallParticipant> Value { get { throw null; } }
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
    public partial class ContentCapabilities
    {
        internal ContentCapabilities() { }
        public Azure.Response<Azure.Communication.CallingServer.PlayResponse> Play(Azure.Communication.CallingServer.PlaySource playSource, System.Collections.Generic.IEnumerable<Azure.Communication.CommunicationIdentifier> playTo, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public System.Threading.Tasks.Task<Azure.Response<Azure.Communication.CallingServer.PlayResponse>> PlayAsync(Azure.Communication.CallingServer.PlaySource playSource, System.Collections.Generic.IEnumerable<Azure.Communication.CommunicationIdentifier> playTo, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public Azure.Response<Azure.Communication.CallingServer.PlayResponse> PlayToAll(Azure.Communication.CallingServer.PlaySource playSource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public System.Threading.Tasks.Task<Azure.Response<Azure.Communication.CallingServer.PlayResponse>> PlayToAllAsync(Azure.Communication.CallingServer.PlaySource playSource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
        public CreateCallOptions() { }
        public string Subject { get { throw null; } set { } }
    }
    public partial class GetCallRecordingStateResponse
    {
        internal GetCallRecordingStateResponse() { }
        public Azure.Communication.CallingServer.RecordingState? RecordingState { get { throw null; } }
    }
    public partial class PlayOptions
    {
        public PlayOptions(bool loop) { }
        public bool Loop { get { throw null; } }
    }
    public partial class PlayResponse
    {
        internal PlayResponse() { }
        public string OperationContext { get { throw null; } }
        public string OperationId { get { throw null; } }
        public Azure.Communication.CallingServer.CallingOperationResultDetailsDto ResultDetails { get { throw null; } }
        public Azure.Communication.CallingServer.CallingOperationStatusDto Status { get { throw null; } }
    }
    public partial class PlaySource
    {
        public PlaySource(Azure.Communication.CallingServer.PlaySourceType sourceType) { }
        public string PlaySourceId { get { throw null; } set { } }
        public Azure.Communication.CallingServer.PlaySourceType SourceType { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PlaySourceType : System.IEquatable<Azure.Communication.CallingServer.PlaySourceType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PlaySourceType(string value) { throw null; }
        public static Azure.Communication.CallingServer.PlaySourceType File { get { throw null; } }
        public bool Equals(Azure.Communication.CallingServer.PlaySourceType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Communication.CallingServer.PlaySourceType left, Azure.Communication.CallingServer.PlaySourceType right) { throw null; }
        public static implicit operator Azure.Communication.CallingServer.PlaySourceType (string value) { throw null; }
        public static bool operator !=(Azure.Communication.CallingServer.PlaySourceType left, Azure.Communication.CallingServer.PlaySourceType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RecordingChannelType : System.IEquatable<Azure.Communication.CallingServer.RecordingChannelType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RecordingChannelType(string value) { throw null; }
        public static Azure.Communication.CallingServer.RecordingChannelType Mixed { get { throw null; } }
        public static Azure.Communication.CallingServer.RecordingChannelType Unmixed { get { throw null; } }
        public bool Equals(Azure.Communication.CallingServer.RecordingChannelType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Communication.CallingServer.RecordingChannelType left, Azure.Communication.CallingServer.RecordingChannelType right) { throw null; }
        public static implicit operator Azure.Communication.CallingServer.RecordingChannelType (string value) { throw null; }
        public static bool operator !=(Azure.Communication.CallingServer.RecordingChannelType left, Azure.Communication.CallingServer.RecordingChannelType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RecordingContentType : System.IEquatable<Azure.Communication.CallingServer.RecordingContentType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RecordingContentType(string value) { throw null; }
        public static Azure.Communication.CallingServer.RecordingContentType Audio { get { throw null; } }
        public static Azure.Communication.CallingServer.RecordingContentType AudioVideo { get { throw null; } }
        public bool Equals(Azure.Communication.CallingServer.RecordingContentType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Communication.CallingServer.RecordingContentType left, Azure.Communication.CallingServer.RecordingContentType right) { throw null; }
        public static implicit operator Azure.Communication.CallingServer.RecordingContentType (string value) { throw null; }
        public static bool operator !=(Azure.Communication.CallingServer.RecordingContentType left, Azure.Communication.CallingServer.RecordingContentType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RecordingFormatType : System.IEquatable<Azure.Communication.CallingServer.RecordingFormatType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RecordingFormatType(string value) { throw null; }
        public static Azure.Communication.CallingServer.RecordingFormatType Mp3 { get { throw null; } }
        public static Azure.Communication.CallingServer.RecordingFormatType Mp4 { get { throw null; } }
        public static Azure.Communication.CallingServer.RecordingFormatType Wav { get { throw null; } }
        public bool Equals(Azure.Communication.CallingServer.RecordingFormatType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Communication.CallingServer.RecordingFormatType left, Azure.Communication.CallingServer.RecordingFormatType right) { throw null; }
        public static implicit operator Azure.Communication.CallingServer.RecordingFormatType (string value) { throw null; }
        public static bool operator !=(Azure.Communication.CallingServer.RecordingFormatType left, Azure.Communication.CallingServer.RecordingFormatType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RecordingState : System.IEquatable<Azure.Communication.CallingServer.RecordingState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RecordingState(string value) { throw null; }
        public static Azure.Communication.CallingServer.RecordingState Active { get { throw null; } }
        public static Azure.Communication.CallingServer.RecordingState Inactive { get { throw null; } }
        public bool Equals(Azure.Communication.CallingServer.RecordingState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Communication.CallingServer.RecordingState left, Azure.Communication.CallingServer.RecordingState right) { throw null; }
        public static implicit operator Azure.Communication.CallingServer.RecordingState (string value) { throw null; }
        public static bool operator !=(Azure.Communication.CallingServer.RecordingState left, Azure.Communication.CallingServer.RecordingState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class RejectCallRequest
    {
        public RejectCallRequest(string incomingCallContext) { }
        public Azure.Communication.CallingServer.CallRejectReason? CallRejectReason { get { throw null; } set { } }
        public string IncomingCallContext { get { throw null; } }
    }
    public partial class RemoveParticipantsOptions
    {
        public RemoveParticipantsOptions(string operationContext) { }
        public string OperationContext { get { throw null; } set { } }
    }
    public partial class RemoveParticipantsResponse
    {
        internal RemoveParticipantsResponse() { }
        public string OperationContext { get { throw null; } }
        public string OperationId { get { throw null; } }
        public Azure.Communication.CallingServer.CallingOperationResultDetailsDto ResultDetails { get { throw null; } }
        public Azure.Communication.CallingServer.CallingOperationStatusDto Status { get { throw null; } }
    }
    public static partial class ServerCallingModelFactory
    {
        public static Azure.Communication.CallingServer.AddParticipantsResponse AddParticipantsResponse(string operationId = null, Azure.Communication.CallingServer.CallingOperationStatusDto status = default(Azure.Communication.CallingServer.CallingOperationStatusDto), string operationContext = null, Azure.Communication.CallingServer.CallingOperationResultDetailsDto resultDetails = null) { throw null; }
        public static Azure.Communication.CallingServer.CallingOperationResultDetailsDto CallingOperationResultDetailsDto(int code = 0, int subcode = 0, string message = null) { throw null; }
        public static Azure.Communication.CallingServer.GetCallRecordingStateResponse GetCallRecordingStateResponse(Azure.Communication.CallingServer.RecordingState? recordingState = default(Azure.Communication.CallingServer.RecordingState?)) { throw null; }
        public static Azure.Communication.CallingServer.PlayResponse PlayResponse(string operationId = null, Azure.Communication.CallingServer.CallingOperationStatusDto status = default(Azure.Communication.CallingServer.CallingOperationStatusDto), string operationContext = null, Azure.Communication.CallingServer.CallingOperationResultDetailsDto resultDetails = null) { throw null; }
        public static Azure.Communication.CallingServer.RemoveParticipantsResponse RemoveParticipantsResponse(string operationId = null, Azure.Communication.CallingServer.CallingOperationStatusDto status = default(Azure.Communication.CallingServer.CallingOperationStatusDto), string operationContext = null, Azure.Communication.CallingServer.CallingOperationResultDetailsDto resultDetails = null) { throw null; }
        public static Azure.Communication.CallingServer.StartCallRecordingResponse StartCallRecordingResponse(string recordingId = null) { throw null; }
        public static Azure.Communication.CallingServer.TransferCallResponse TransferCallResponse(string operationId = null, Azure.Communication.CallingServer.CallingOperationStatusDto status = default(Azure.Communication.CallingServer.CallingOperationStatusDto), string operationContext = null, Azure.Communication.CallingServer.CallingOperationResultDetailsDto resultDetails = null) { throw null; }
    }
    public partial class StartCallRecordingRequest
    {
        public StartCallRecordingRequest(Azure.Communication.CallingServer.CallLocator callLocator) { }
        public Azure.Communication.CallingServer.CallLocator CallLocator { get { throw null; } }
        public Azure.Communication.CallingServer.RecordingChannelType? RecordingChannelType { get { throw null; } set { } }
        public Azure.Communication.CallingServer.RecordingContentType? RecordingContentType { get { throw null; } set { } }
        public Azure.Communication.CallingServer.RecordingFormatType? RecordingFormatType { get { throw null; } set { } }
        public string RecordingStateCallbackUri { get { throw null; } set { } }
    }
    public partial class StartCallRecordingResponse
    {
        internal StartCallRecordingResponse() { }
        public string RecordingId { get { throw null; } }
    }
    public partial class TransferCallOptions
    {
        public TransferCallOptions(Azure.Communication.PhoneNumberIdentifier alternateCallerId, string userToUserInformation, string operationContext) { }
        public Azure.Communication.PhoneNumberIdentifier AlternateCallerId { get { throw null; } set { } }
        public string OperationContext { get { throw null; } set { } }
        public string UserToUserInformation { get { throw null; } set { } }
    }
    public partial class TransferCallResponse
    {
        internal TransferCallResponse() { }
        public string OperationContext { get { throw null; } }
        public string OperationId { get { throw null; } }
        public Azure.Communication.CallingServer.CallingOperationResultDetailsDto ResultDetails { get { throw null; } }
        public Azure.Communication.CallingServer.CallingOperationStatusDto Status { get { throw null; } }
    }
}
namespace Azure.Communication.CallingServer.Models
{
    public partial class CallSource
    {
        public CallSource(Azure.Communication.CommunicationIdentifier identifier, Azure.Communication.PhoneNumberIdentifier alternateCallerId = null) { }
        public Azure.Communication.PhoneNumberIdentifier AlternateCallerId { get { throw null; } set { } }
        public Azure.Communication.CommunicationIdentifier Identifier { get { throw null; } }
    }
}
