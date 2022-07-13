namespace Azure.Communication.CallingServer
{
    public partial class AddParticipantsResponse
    {
        internal AddParticipantsResponse() { }
        public string OperationContext { get { throw null; } }
        public string OperationId { get { throw null; } }
        public Azure.Communication.CallingServer.CallingOperationResultDetails ResultDetails { get { throw null; } }
        public Azure.Communication.CallingServer.CallingOperationStatus Status { get { throw null; } }
    }
    public partial class CallConnectionClient
    {
        protected CallConnectionClient() { }
        public virtual string CallConnectionId { get { throw null; } }
        public virtual Azure.Response<Azure.Communication.CallingServer.AddParticipantsResponse> AddParticipants(System.Collections.Generic.IEnumerable<Azure.Communication.CommunicationIdentifier> participantsToAdd, Azure.Communication.CallingServer.Models.AddParticipantsOptions options = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Communication.CallingServer.AddParticipantsResponse>> AddParticipantsAsync(System.Collections.Generic.IEnumerable<Azure.Communication.CommunicationIdentifier> participantsToAdd, Azure.Communication.CallingServer.Models.AddParticipantsOptions options = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Communication.CallingServer.Models.CallParticipant> GetParticipant(Azure.Communication.CommunicationIdentifier participant, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Communication.CallingServer.Models.CallParticipant>> GetParticipantAsync(Azure.Communication.CommunicationIdentifier participant, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<System.Collections.Generic.IReadOnlyList<Azure.Communication.CallingServer.Models.CallParticipant>> GetParticipants(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<System.Collections.Generic.IReadOnlyList<Azure.Communication.CallingServer.Models.CallParticipant>>> GetParticipantsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response Hangup(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> HangupAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Communication.CallingServer.RemoveParticipantsResponse> RemoveParticipants(System.Collections.Generic.IEnumerable<Azure.Communication.CommunicationIdentifier> participantsToRemove, string operationContext = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Communication.CallingServer.RemoveParticipantsResponse>> RemoveParticipantsAsync(System.Collections.Generic.IEnumerable<Azure.Communication.CommunicationIdentifier> participantsToRemove, string operationContext = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response TerminateCall(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> TerminateCallAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Communication.CallingServer.TransferCallResponse> TransferCallToParticipant(Azure.Communication.CommunicationIdentifier targetParticipant, Azure.Communication.CallingServer.Models.TransferCallToParticipantOptions options = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Communication.CallingServer.TransferCallResponse>> TransferCallToParticipantAsync(Azure.Communication.CommunicationIdentifier targetParticipant, Azure.Communication.CallingServer.Models.TransferCallToParticipantOptions options = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
    public partial class CallContentClient
    {
        protected CallContentClient() { }
        public virtual string CallConnectionId { get { throw null; } }
        public virtual Azure.Response<Azure.Communication.CallingServer.PlayResponse> PlayMedia(Azure.Communication.CallingServer.Models.PlaySource playSource, System.Collections.Generic.IEnumerable<Azure.Communication.CommunicationIdentifier> playTo, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Communication.CallingServer.PlayResponse>> PlayMediaAsync(Azure.Communication.CallingServer.Models.PlaySource playSource, System.Collections.Generic.IEnumerable<Azure.Communication.CommunicationIdentifier> playTo, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Communication.CallingServer.PlayResponse> PlayMediaToAll(Azure.Communication.CallingServer.Models.PlaySource playSource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Communication.CallingServer.PlayResponse>> PlayMediaToAllAsync(Azure.Communication.CallingServer.Models.PlaySource playSource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
        public CallingServerClient(System.Uri endpoint, Azure.Core.TokenCredential credential, Azure.Communication.CallingServer.CallingServerClientOptions options = null) { }
        public CallingServerClient(System.Uri pmaEndpoint, string connectionString, Azure.Communication.CallingServer.CallingServerClientOptions options = null) { }
        public virtual Azure.Response<Azure.Communication.CallingServer.Models.CallConnectionProperties> AnswerCall(string incomingCallContext, System.Uri callbackUri, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Communication.CallingServer.Models.CallConnectionProperties>> AnswerCallAsync(string incomingCallContext, System.Uri callbackUri, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Communication.CallingServer.Models.CallConnectionProperties> CreateCall(Azure.Communication.CallingServer.Models.CallSource source, System.Collections.Generic.IEnumerable<Azure.Communication.CommunicationIdentifier> targets, System.Uri callbackUri, Azure.Communication.CallingServer.Models.CreateCallOptions options = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Communication.CallingServer.Models.CallConnectionProperties>> CreateCallAsync(Azure.Communication.CallingServer.Models.CallSource source, System.Collections.Generic.IEnumerable<Azure.Communication.CommunicationIdentifier> targets, System.Uri callbackUri, Azure.Communication.CallingServer.Models.CreateCallOptions options = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Communication.CallingServer.CallConnectionClient GetCallConnectionClient(string callConnectionId) { throw null; }
        public virtual Azure.Response<Azure.Communication.CallingServer.Models.CallConnectionProperties> GetCallConnectionProperties(string callConnectionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Communication.CallingServer.Models.CallConnectionProperties>> GetCallConnectionPropertiesAsync(string callConnectionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Communication.CallingServer.CallContentClient GetCallContentClient(string callConnectionId) { throw null; }
        public virtual Azure.Communication.CallingServer.CallRecordingClient GetCallRecordingClient() { throw null; }
        public virtual Azure.Response RedirectCall(string incomingCallContext, Azure.Communication.CommunicationIdentifier target, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> RedirectCallAsync(string incomingCallContext, Azure.Communication.CommunicationIdentifier target, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response RejectCall(string incomingCallContext, Azure.Communication.CallingServer.CallRejectReason callRejectReason, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> RejectCallAsync(string incomingCallContext, Azure.Communication.CallingServer.CallRejectReason callRejectReason, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class CallingServerClientOptions : Azure.Core.ClientOptions
    {
        public CallingServerClientOptions(Azure.Communication.CallingServer.CallingServerClientOptions.ServiceVersion version = Azure.Communication.CallingServer.CallingServerClientOptions.ServiceVersion.V2022_04_07_Preview) { }
        public enum ServiceVersion
        {
            V2022_04_07_Preview = 1,
        }
    }
    public partial class CallRecordingClient
    {
        protected CallRecordingClient() { }
        public virtual Azure.Response DeleteRecording(System.Uri deleteEndpoint, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteRecordingAsync(System.Uri deleteEndpoint, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<System.IO.Stream> DownloadStreaming(System.Uri sourceEndpoint, Azure.HttpRange range = default(Azure.HttpRange), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<System.IO.Stream>> DownloadStreamingAsync(System.Uri sourceEndpoint, Azure.HttpRange range = default(Azure.HttpRange), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response DownloadTo(System.Uri sourceEndpoint, System.IO.Stream destinationStream, Azure.Communication.CallingServer.Models.ContentTransferOptions transferOptions = default(Azure.Communication.CallingServer.Models.ContentTransferOptions), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response DownloadTo(System.Uri sourceEndpoint, string destinationPath, Azure.Communication.CallingServer.Models.ContentTransferOptions transferOptions = default(Azure.Communication.CallingServer.Models.ContentTransferOptions), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DownloadToAsync(System.Uri sourceEndpoint, System.IO.Stream destinationStream, Azure.Communication.CallingServer.Models.ContentTransferOptions transferOptions = default(Azure.Communication.CallingServer.Models.ContentTransferOptions), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DownloadToAsync(System.Uri sourceEndpoint, string destinationPath, Azure.Communication.CallingServer.Models.ContentTransferOptions transferOptions = default(Azure.Communication.CallingServer.Models.ContentTransferOptions), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Communication.CallingServer.GetCallRecordingStateResponse> GetRecordingState(string recordingId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Communication.CallingServer.GetCallRecordingStateResponse>> GetRecordingStateAsync(string recordingId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response PauseRecording(string recordingId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> PauseRecordingAsync(string recordingId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response ResumeRecording(string recordingId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> ResumeRecordingAsync(string recordingId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Communication.CallingServer.StartCallRecordingResponse> StartRecording(Azure.Communication.CallingServer.Models.CallLocator callLocator, System.Uri recordingStateCallbackUri, Azure.Communication.CallingServer.RecordingContentType? content = default(Azure.Communication.CallingServer.RecordingContentType?), Azure.Communication.CallingServer.RecordingChannelType? channel = default(Azure.Communication.CallingServer.RecordingChannelType?), Azure.Communication.CallingServer.RecordingFormatType? format = default(Azure.Communication.CallingServer.RecordingFormatType?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Communication.CallingServer.StartCallRecordingResponse>> StartRecordingAsync(Azure.Communication.CallingServer.Models.CallLocator callLocator, System.Uri recordingStateCallbackUri, Azure.Communication.CallingServer.RecordingContentType? content = default(Azure.Communication.CallingServer.RecordingContentType?), Azure.Communication.CallingServer.RecordingChannelType? channel = default(Azure.Communication.CallingServer.RecordingChannelType?), Azure.Communication.CallingServer.RecordingFormatType? format = default(Azure.Communication.CallingServer.RecordingFormatType?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
        public Azure.Communication.CallingServer.CallingOperationResultDetails ResultDetails { get { throw null; } }
        public Azure.Communication.CallingServer.CallingOperationStatus Status { get { throw null; } }
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
    public partial class RemoveParticipantsResponse
    {
        internal RemoveParticipantsResponse() { }
        public string OperationContext { get { throw null; } }
        public string OperationId { get { throw null; } }
        public Azure.Communication.CallingServer.CallingOperationResultDetails ResultDetails { get { throw null; } }
        public Azure.Communication.CallingServer.CallingOperationStatus Status { get { throw null; } }
    }
    public static partial class ServerCallingModelFactory
    {
        public static Azure.Communication.CallingServer.AddParticipantsResponse AddParticipantsResponse(string operationId = null, Azure.Communication.CallingServer.CallingOperationStatus status = default(Azure.Communication.CallingServer.CallingOperationStatus), string operationContext = null, Azure.Communication.CallingServer.CallingOperationResultDetails resultDetails = null) { throw null; }
        public static Azure.Communication.CallingServer.CallingOperationResultDetails CallingOperationResultDetails(int code = 0, int subcode = 0, string message = null) { throw null; }
        public static Azure.Communication.CallingServer.GetCallRecordingStateResponse GetCallRecordingStateResponse(Azure.Communication.CallingServer.RecordingState? recordingState = default(Azure.Communication.CallingServer.RecordingState?)) { throw null; }
        public static Azure.Communication.CallingServer.PlayResponse PlayResponse(string operationId = null, Azure.Communication.CallingServer.CallingOperationStatus status = default(Azure.Communication.CallingServer.CallingOperationStatus), string operationContext = null, Azure.Communication.CallingServer.CallingOperationResultDetails resultDetails = null) { throw null; }
        public static Azure.Communication.CallingServer.RemoveParticipantsResponse RemoveParticipantsResponse(string operationId = null, Azure.Communication.CallingServer.CallingOperationStatus status = default(Azure.Communication.CallingServer.CallingOperationStatus), string operationContext = null, Azure.Communication.CallingServer.CallingOperationResultDetails resultDetails = null) { throw null; }
        public static Azure.Communication.CallingServer.StartCallRecordingResponse StartCallRecordingResponse(string recordingId = null) { throw null; }
        public static Azure.Communication.CallingServer.TransferCallResponse TransferCallResponse(string operationId = null, Azure.Communication.CallingServer.CallingOperationStatus status = default(Azure.Communication.CallingServer.CallingOperationStatus), string operationContext = null, Azure.Communication.CallingServer.CallingOperationResultDetails resultDetails = null) { throw null; }
    }
    public partial class StartCallRecordingResponse
    {
        internal StartCallRecordingResponse() { }
        public string RecordingId { get { throw null; } }
    }
    public partial class TransferCallResponse
    {
        internal TransferCallResponse() { }
        public string OperationContext { get { throw null; } }
        public string OperationId { get { throw null; } }
        public Azure.Communication.CallingServer.CallingOperationResultDetails ResultDetails { get { throw null; } }
        public Azure.Communication.CallingServer.CallingOperationStatus Status { get { throw null; } }
    }
}
namespace Azure.Communication.CallingServer.Models
{
    public partial class AddParticipantsOptions
    {
        public AddParticipantsOptions(Azure.Communication.PhoneNumberIdentifier alternateCallerId = null, string operationContext = null, int? invitationTimeoutInSeconds = default(int?), string replacementCallConnectionId = null) { }
        public Azure.Communication.PhoneNumberIdentifier AlternateCallerId { get { throw null; } set { } }
        public int? InvitationTimeoutInSeconds { get { throw null; } set { } }
        public string OperationContext { get { throw null; } set { } }
        public string ReplacementCallConnectionId { get { throw null; } set { } }
    }
    public partial class CallConnectionProperties
    {
        internal CallConnectionProperties() { }
        public Azure.Communication.PhoneNumberIdentifier AlternateCallerId { get { throw null; } }
        public System.Uri CallbackUri { get { throw null; } }
        public string CallConnectionId { get { throw null; } }
        public Azure.Communication.CallingServer.CallConnectionState? CallConnectionState { get { throw null; } }
        public string ServerCallId { get { throw null; } }
        public Azure.Communication.CommunicationIdentifier Source { get { throw null; } }
        public string Subject { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Communication.CommunicationIdentifier> Targets { get { throw null; } }
    }
    public abstract partial class CallLocator : System.IEquatable<Azure.Communication.CallingServer.Models.CallLocator>
    {
        protected CallLocator() { }
        public string Id { get { throw null; } set { } }
        public abstract bool Equals(Azure.Communication.CallingServer.Models.CallLocator other);
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
    }
    public partial class CallParticipant
    {
        internal CallParticipant() { }
        public Azure.Communication.CommunicationIdentifier Identifier { get { throw null; } }
        public bool IsMuted { get { throw null; } }
    }
    public partial class CallSource
    {
        public CallSource(Azure.Communication.CommunicationIdentifier identifier, Azure.Communication.PhoneNumberIdentifier alternateCallerId = null) { }
        public Azure.Communication.PhoneNumberIdentifier AlternateCallerId { get { throw null; } set { } }
        public Azure.Communication.CommunicationIdentifier Identifier { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public partial struct ContentTransferOptions : System.IEquatable<Azure.Communication.CallingServer.Models.ContentTransferOptions>
    {
        public long InitialTransferSize { get { throw null; } set { } }
        public int MaximumConcurrency { get { throw null; } set { } }
        public long MaximumTransferSize { get { throw null; } set { } }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public bool Equals(Azure.Communication.CallingServer.Models.ContentTransferOptions obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static bool operator ==(Azure.Communication.CallingServer.Models.ContentTransferOptions left, Azure.Communication.CallingServer.Models.ContentTransferOptions right) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static bool operator !=(Azure.Communication.CallingServer.Models.ContentTransferOptions left, Azure.Communication.CallingServer.Models.ContentTransferOptions right) { throw null; }
    }
    public partial class CreateCallOptions
    {
        public CreateCallOptions(string subject = null) { }
        public string Subject { get { throw null; } set { } }
    }
    public partial class GroupCallLocator : Azure.Communication.CallingServer.Models.CallLocator
    {
        public GroupCallLocator(string id) { }
        public override bool Equals(Azure.Communication.CallingServer.Models.CallLocator other) { throw null; }
        public override int GetHashCode() { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class PlaySource
    {
        public PlaySource(Azure.Communication.CallingServer.PlaySourceType sourceType, string playSourceId = null) { }
        public string PlaySourceId { get { throw null; } set { } }
        public Azure.Communication.CallingServer.PlaySourceType SourceType { get { throw null; } set { } }
    }
    public partial class RemoveParticipantsOptions
    {
        public RemoveParticipantsOptions(string operationContext = null) { }
        public string OperationContext { get { throw null; } set { } }
    }
    public partial class ServerCallLocator : Azure.Communication.CallingServer.Models.CallLocator
    {
        public ServerCallLocator(string id) { }
        public override bool Equals(Azure.Communication.CallingServer.Models.CallLocator other) { throw null; }
        public override int GetHashCode() { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class TransferCallToParticipantOptions
    {
        public TransferCallToParticipantOptions(Azure.Communication.PhoneNumberIdentifier alternateCallerId = null, string userToUserInformation = null, string operationContext = null) { }
        public Azure.Communication.PhoneNumberIdentifier AlternateCallerId { get { throw null; } set { } }
        public string OperationContext { get { throw null; } set { } }
        public string UserToUserInformation { get { throw null; } set { } }
    }
}
