namespace Azure.Communication.CallingServer
{
    public partial class AddParticipantsOptions
    {
        public AddParticipantsOptions() { }
        public int? InvitationTimeoutInSeconds { get { throw null; } set { } }
        public string OperationContext { get { throw null; } set { } }
        public string ReplacementCallConnectionId { get { throw null; } set { } }
        public Azure.Communication.PhoneNumberIdentifier SourceCallerId { get { throw null; } set { } }
    }
    public partial class AddParticipantsResult
    {
        internal AddParticipantsResult() { }
        public string OperationContext { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Communication.CallingServer.CallParticipant> Participants { get { throw null; } }
    }
    public partial class AnswerCallResult
    {
        internal AnswerCallResult() { }
        public Azure.Communication.CallingServer.CallConnection CallConnection { get { throw null; } }
        public Azure.Communication.CallingServer.CallConnectionProperties CallProperties { get { throw null; } }
    }
    public partial class CallConnection
    {
        protected CallConnection() { }
        public virtual string CallConnectionId { get { throw null; } }
        public virtual Azure.Response<Azure.Communication.CallingServer.AddParticipantsResult> AddParticipants(System.Collections.Generic.IEnumerable<Azure.Communication.CommunicationIdentifier> participantsToAdd, Azure.Communication.CallingServer.AddParticipantsOptions options = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Communication.CallingServer.AddParticipantsResult>> AddParticipantsAsync(System.Collections.Generic.IEnumerable<Azure.Communication.CommunicationIdentifier> participantsToAdd, Azure.Communication.CallingServer.AddParticipantsOptions options = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Communication.CallingServer.CallContent GetCallContent() { throw null; }
        public virtual Azure.Response<Azure.Communication.CallingServer.CallParticipant> GetParticipant(string participantMri, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Communication.CallingServer.CallParticipant>> GetParticipantAsync(string participantMri, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<System.Collections.Generic.IReadOnlyList<Azure.Communication.CallingServer.CallParticipant>> GetParticipants(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<System.Collections.Generic.IReadOnlyList<Azure.Communication.CallingServer.CallParticipant>>> GetParticipantsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Communication.CallingServer.CallConnectionProperties> GetProperties(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Communication.CallingServer.CallConnectionProperties>> GetPropertiesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response Hangup(bool forEveryone, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> HangupAsync(bool forEveryone, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Communication.CallingServer.RemoveParticipantsResult> RemoveParticipants(System.Collections.Generic.IEnumerable<Azure.Communication.CommunicationIdentifier> participantsToRemove, Azure.Communication.CallingServer.RemoveParticipantsOptions options = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Communication.CallingServer.RemoveParticipantsResult>> RemoveParticipantsAsync(System.Collections.Generic.IEnumerable<Azure.Communication.CommunicationIdentifier> participantsToRemove, Azure.Communication.CallingServer.RemoveParticipantsOptions options = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Communication.CallingServer.TransferCallToParticipantResult> TransferCallToParticipant(Azure.Communication.CommunicationIdentifier targetParticipant, Azure.Communication.CallingServer.TransferCallToParticipantOptions options = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Communication.CallingServer.TransferCallToParticipantResult>> TransferCallToParticipantAsync(Azure.Communication.CommunicationIdentifier targetParticipant, Azure.Communication.CallingServer.TransferCallToParticipantOptions options = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class CallConnectionProperties
    {
        internal CallConnectionProperties() { }
        public System.Uri CallbackUri { get { throw null; } }
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
    public partial class CallContent
    {
        protected CallContent() { }
        public virtual string CallConnectionId { get { throw null; } }
        public virtual Azure.Response CancelAllMediaOperations(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> CancelAllMediaOperationsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response Play(Azure.Communication.CallingServer.FileSource fileSource, System.Collections.Generic.IEnumerable<Azure.Communication.CommunicationIdentifier> playTo, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> PlayAsync(Azure.Communication.CallingServer.FileSource fileSource, System.Collections.Generic.IEnumerable<Azure.Communication.CommunicationIdentifier> playTo, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response PlayToAll(Azure.Communication.CallingServer.FileSource fileSource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> PlayToAllAsync(Azure.Communication.CallingServer.FileSource fileSource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class CallingServerClient
    {
        protected CallingServerClient() { }
        public CallingServerClient(string connectionString) { }
        public CallingServerClient(string connectionString, Azure.Communication.CallingServer.CallingServerClientOptions options) { }
        public CallingServerClient(System.Uri endpoint, Azure.Core.TokenCredential credential, Azure.Communication.CallingServer.CallingServerClientOptions options = null) { }
        public CallingServerClient(System.Uri pmaEndpoint, string connectionString, Azure.Communication.CallingServer.CallingServerClientOptions options = null) { }
        public virtual Azure.Response<Azure.Communication.CallingServer.AnswerCallResult> AnswerCall(string incomingCallContext, System.Uri callbackUri, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Communication.CallingServer.AnswerCallResult>> AnswerCallAsync(string incomingCallContext, System.Uri callbackUri, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Communication.CallingServer.CreateCallResult> CreateCall(Azure.Communication.CallingServer.CallSource source, System.Collections.Generic.IEnumerable<Azure.Communication.CommunicationIdentifier> targets, System.Uri callbackUri, string subject = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Communication.CallingServer.CreateCallResult>> CreateCallAsync(Azure.Communication.CallingServer.CallSource source, System.Collections.Generic.IEnumerable<Azure.Communication.CommunicationIdentifier> targets, System.Uri callbackUri, string subject = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Communication.CallingServer.CallConnection GetCallConnection(string callConnectionId) { throw null; }
        public virtual Azure.Communication.CallingServer.CallRecording GetCallRecording() { throw null; }
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
    public abstract partial class CallLocator : System.IEquatable<Azure.Communication.CallingServer.CallLocator>
    {
        protected CallLocator() { }
        public string Id { get { throw null; } set { } }
        public abstract bool Equals(Azure.Communication.CallingServer.CallLocator other);
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
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
        public virtual Azure.Response<Azure.Communication.CallingServer.RecordingStatusResult> StartRecording(Azure.Communication.CallingServer.CallLocator callLocator, System.Uri recordingStateCallbackUri, Azure.Communication.CallingServer.RecordingContent? content = default(Azure.Communication.CallingServer.RecordingContent?), Azure.Communication.CallingServer.RecordingChannel? channel = default(Azure.Communication.CallingServer.RecordingChannel?), Azure.Communication.CallingServer.RecordingFormat? format = default(Azure.Communication.CallingServer.RecordingFormat?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Communication.CallingServer.RecordingStatusResult>> StartRecordingAsync(Azure.Communication.CallingServer.CallLocator callLocator, System.Uri recordingStateCallbackUri, Azure.Communication.CallingServer.RecordingContent? content = default(Azure.Communication.CallingServer.RecordingContent?), Azure.Communication.CallingServer.RecordingChannel? channel = default(Azure.Communication.CallingServer.RecordingChannel?), Azure.Communication.CallingServer.RecordingFormat? format = default(Azure.Communication.CallingServer.RecordingFormat?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
        public Azure.Communication.CommunicationIdentifier Identifier { get { throw null; } set { } }
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
        public System.Uri FileUri { get { throw null; } set { } }
    }
    public partial class GroupCallLocator : Azure.Communication.CallingServer.CallLocator
    {
        public GroupCallLocator(string id) { }
        public override bool Equals(Azure.Communication.CallingServer.CallLocator other) { throw null; }
        public override int GetHashCode() { throw null; }
        public override string ToString() { throw null; }
    }
    public abstract partial class PlaySource
    {
        protected PlaySource() { }
        public string PlaySourceId { get { throw null; } set { } }
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
    public static partial class ServerCallingModelFactory
    {
        public static Azure.Communication.CallingServer.AddParticipantsResult AddParticipantsResult(System.Collections.Generic.IEnumerable<Azure.Communication.CallingServer.CallParticipant> participants, string operationContext) { throw null; }
        public static Azure.Communication.CallingServer.AnswerCallResult AnswerCallResult(Azure.Communication.CallingServer.CallConnection callConnection, Azure.Communication.CallingServer.CallConnectionProperties callProperties) { throw null; }
        public static Azure.Communication.CallingServer.CallConnectionProperties CallConnectionProperties(string callConnectionId, string serverCallId, Azure.Communication.CallingServer.CallSource callSource, System.Collections.Generic.IEnumerable<Azure.Communication.CommunicationIdentifier> targets, Azure.Communication.CallingServer.CallConnectionState callConnectionState, string subject, System.Uri callbackUri) { throw null; }
        public static Azure.Communication.CallingServer.CallParticipant CallParticipant(Azure.Communication.CommunicationIdentifier identifier, bool isMuted) { throw null; }
        public static Azure.Communication.CallingServer.CreateCallResult CreateCallResult(Azure.Communication.CallingServer.CallConnection callConnection, Azure.Communication.CallingServer.CallConnectionProperties callProperties) { throw null; }
        public static Azure.Communication.CallingServer.RecordingStatusResult RecordingStatusResult(string recordingId = null, Azure.Communication.CallingServer.RecordingStatus? recordingStatus = default(Azure.Communication.CallingServer.RecordingStatus?)) { throw null; }
        public static Azure.Communication.CallingServer.RemoveParticipantsResult RemoveParticipantsResult(string operationContext = null) { throw null; }
        public static Azure.Communication.CallingServer.TransferCallToParticipantResult TransferCallToParticipantResult(string operationContext = null) { throw null; }
    }
    public partial class ServerCallLocator : Azure.Communication.CallingServer.CallLocator
    {
        public ServerCallLocator(string id) { }
        public override bool Equals(Azure.Communication.CallingServer.CallLocator other) { throw null; }
        public override int GetHashCode() { throw null; }
        public override string ToString() { throw null; }
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
