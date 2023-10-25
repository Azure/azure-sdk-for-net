namespace Azure.Communication.Rooms
{
    public partial class CommunicationRoom
    {
        internal CommunicationRoom() { }
        public System.DateTimeOffset CreatedAt { get { throw null; } }
        public string Id { get { throw null; } }
        public bool PstnDialOutEnabled { get { throw null; } }
        public System.DateTimeOffset ValidFrom { get { throw null; } }
        public System.DateTimeOffset ValidUntil { get { throw null; } }
    }
    public partial class CreateRoomOptions
    {
        public CreateRoomOptions() { }
        public System.Collections.Generic.IList<Azure.Communication.Rooms.RoomParticipant> Participants { get { throw null; } set { } }
        public bool? PstnDialOutEnabled { get { throw null; } set { } }
        public System.DateTimeOffset? ValidFrom { get { throw null; } set { } }
        public System.DateTimeOffset? ValidUntil { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ParticipantRole : System.IEquatable<Azure.Communication.Rooms.ParticipantRole>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ParticipantRole(string value) { throw null; }
        public static Azure.Communication.Rooms.ParticipantRole Attendee { get { throw null; } }
        public static Azure.Communication.Rooms.ParticipantRole Consumer { get { throw null; } }
        public static Azure.Communication.Rooms.ParticipantRole Presenter { get { throw null; } }
        public bool Equals(Azure.Communication.Rooms.ParticipantRole other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Communication.Rooms.ParticipantRole left, Azure.Communication.Rooms.ParticipantRole right) { throw null; }
        public static implicit operator Azure.Communication.Rooms.ParticipantRole (string value) { throw null; }
        public static bool operator !=(Azure.Communication.Rooms.ParticipantRole left, Azure.Communication.Rooms.ParticipantRole right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class RoomParticipant
    {
        public RoomParticipant(Azure.Communication.CommunicationIdentifier communicationIdentifier) { }
        public Azure.Communication.CommunicationIdentifier CommunicationIdentifier { get { throw null; } }
        public Azure.Communication.Rooms.ParticipantRole Role { get { throw null; } set { } }
    }
    public partial class RoomsClient
    {
        protected RoomsClient() { }
        public RoomsClient(string connectionString) { }
        public RoomsClient(string connectionString, Azure.Communication.Rooms.RoomsClientOptions options) { }
        public RoomsClient(System.Uri endpoint, Azure.AzureKeyCredential credential, Azure.Communication.Rooms.RoomsClientOptions options = null) { }
        public RoomsClient(System.Uri endpoint, Azure.Core.TokenCredential credential, Azure.Communication.Rooms.RoomsClientOptions options = null) { }
        public virtual Azure.Response AddOrUpdateParticipants(string roomId, System.Collections.Generic.IEnumerable<Azure.Communication.Rooms.RoomParticipant> participants, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> AddOrUpdateParticipantsAsync(string roomId, System.Collections.Generic.IEnumerable<Azure.Communication.Rooms.RoomParticipant> participants, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Communication.Rooms.CommunicationRoom> CreateRoom(Azure.Communication.Rooms.CreateRoomOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Communication.Rooms.CommunicationRoom> CreateRoom(System.DateTimeOffset? validFrom = default(System.DateTimeOffset?), System.DateTimeOffset? validUntil = default(System.DateTimeOffset?), System.Collections.Generic.IEnumerable<Azure.Communication.Rooms.RoomParticipant> participants = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Communication.Rooms.CommunicationRoom>> CreateRoomAsync(Azure.Communication.Rooms.CreateRoomOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Communication.Rooms.CommunicationRoom>> CreateRoomAsync(System.DateTimeOffset? validFrom = default(System.DateTimeOffset?), System.DateTimeOffset? validUntil = default(System.DateTimeOffset?), System.Collections.Generic.IEnumerable<Azure.Communication.Rooms.RoomParticipant> participants = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response DeleteRoom(string roomId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteRoomAsync(string roomId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.Communication.Rooms.RoomParticipant> GetParticipants(string roomId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.Communication.Rooms.RoomParticipant> GetParticipantsAsync(string roomId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Communication.Rooms.CommunicationRoom> GetRoom(string roomId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Communication.Rooms.CommunicationRoom>> GetRoomAsync(string roomId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.Communication.Rooms.CommunicationRoom> GetRooms(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.Communication.Rooms.CommunicationRoom> GetRoomsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response RemoveParticipants(string roomId, System.Collections.Generic.IEnumerable<Azure.Communication.CommunicationIdentifier> participantIdentifiers, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> RemoveParticipantsAsync(string roomId, System.Collections.Generic.IEnumerable<Azure.Communication.CommunicationIdentifier> participantIdentifiers, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Communication.Rooms.CommunicationRoom> UpdateRoom(string roomId, Azure.Communication.Rooms.UpdateRoomOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Communication.Rooms.CommunicationRoom> UpdateRoom(string roomId, System.DateTimeOffset? validFrom = default(System.DateTimeOffset?), System.DateTimeOffset? validUntil = default(System.DateTimeOffset?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Communication.Rooms.CommunicationRoom>> UpdateRoomAsync(string roomId, Azure.Communication.Rooms.UpdateRoomOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Communication.Rooms.CommunicationRoom>> UpdateRoomAsync(string roomId, System.DateTimeOffset? validFrom = default(System.DateTimeOffset?), System.DateTimeOffset? validUntil = default(System.DateTimeOffset?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class RoomsClientOptions : Azure.Core.ClientOptions
    {
        public RoomsClientOptions(Azure.Communication.Rooms.RoomsClientOptions.ServiceVersion version = Azure.Communication.Rooms.RoomsClientOptions.ServiceVersion.V2023_10_30_Preview) { }
        public enum ServiceVersion
        {
            V2023_06_14 = 1,
            V2023_10_30_Preview = 2,
        }
    }
    public static partial class RoomsModelFactory
    {
        public static Azure.Communication.Rooms.CommunicationRoom CommunicationRoom(string id = null, System.DateTimeOffset createdAt = default(System.DateTimeOffset), System.DateTimeOffset validFrom = default(System.DateTimeOffset), System.DateTimeOffset validUntil = default(System.DateTimeOffset)) { throw null; }
        public static Azure.Communication.Rooms.CommunicationRoom CommunicationRoom(string id = null, System.DateTimeOffset createdAt = default(System.DateTimeOffset), System.DateTimeOffset validFrom = default(System.DateTimeOffset), System.DateTimeOffset validUntil = default(System.DateTimeOffset), bool pstnDialOutEnabled = false) { throw null; }
        public static Azure.Communication.Rooms.RoomParticipant RoomParticipant(string rawId, Azure.Communication.Rooms.ParticipantRole role) { throw null; }
    }
    public partial class UpdateRoomOptions
    {
        public UpdateRoomOptions() { }
        public bool? PstnDialOutEnabled { get { throw null; } set { } }
        public System.DateTimeOffset? ValidFrom { get { throw null; } set { } }
        public System.DateTimeOffset? ValidUntil { get { throw null; } set { } }
    }
}
