namespace Azure.Communication.Rooms
{
    public partial class CommunicationRoom
    {
        internal CommunicationRoom() { }
        public System.DateTimeOffset CreatedAt { get { throw null; } }
        public string Id { get { throw null; } }
        public System.DateTimeOffset ValidFrom { get { throw null; } }
        public System.DateTimeOffset ValidUntil { get { throw null; } }
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
    public partial class ParticipantsCollection
    {
        internal ParticipantsCollection() { }
        public string NextLink { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Communication.Rooms.RoomParticipant> Value { get { throw null; } }
    }
    public partial class RoomParticipant
    {
        public RoomParticipant(Azure.Communication.CommunicationIdentifier communicationIdentifier) { }
        public RoomParticipant(Azure.Communication.CommunicationIdentifier communicationIdentifier, Azure.Communication.Rooms.ParticipantRole role) { }
        public Azure.Communication.CommunicationIdentifier CommunicationIdentifier { get { throw null; } }
        public Azure.Communication.Rooms.ParticipantRole? Role { get { throw null; } set { } }
    }
    public partial class RoomsClient
    {
        protected RoomsClient() { }
        public RoomsClient(string connectionString) { }
        public RoomsClient(string connectionString, Azure.Communication.Rooms.RoomsClientOptions options) { }
        public RoomsClient(System.Uri endpoint, Azure.AzureKeyCredential keyCredential, Azure.Communication.Rooms.RoomsClientOptions options = null) { }
        public RoomsClient(System.Uri endpoint, Azure.Core.TokenCredential tokenCredential, Azure.Communication.Rooms.RoomsClientOptions options = null) { }
        public virtual Azure.Response<Azure.Communication.Rooms.CommunicationRoom> CreateRoom(System.DateTimeOffset? validFrom = default(System.DateTimeOffset?), System.DateTimeOffset? validUntil = default(System.DateTimeOffset?), System.Collections.Generic.IEnumerable<Azure.Communication.Rooms.RoomParticipant> participants = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Communication.Rooms.CommunicationRoom>> CreateRoomAsync(System.DateTimeOffset? validFrom = default(System.DateTimeOffset?), System.DateTimeOffset? validUntil = default(System.DateTimeOffset?), System.Collections.Generic.IEnumerable<Azure.Communication.Rooms.RoomParticipant> participants = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response DeleteRoom(string roomId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteRoomAsync(string roomId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Communication.Rooms.ParticipantsCollection> GetParticipants(string roomId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Communication.Rooms.ParticipantsCollection>> GetParticipantsAsync(string roomId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Communication.Rooms.CommunicationRoom> GetRoom(string roomId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Communication.Rooms.CommunicationRoom>> GetRoomAsync(string roomId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Communication.Rooms.RoomsCollection> ListRooms(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Communication.Rooms.RoomsCollection>> ListRoomsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<object> RemoveParticipants(string roomId, System.Collections.Generic.IEnumerable<Azure.Communication.CommunicationIdentifier> communicationIdentifiers, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<object>> RemoveParticipantsAsync(string roomId, System.Collections.Generic.IEnumerable<Azure.Communication.CommunicationIdentifier> communicationIdentifiers, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Communication.Rooms.CommunicationRoom> UpdateRoom(string roomId, System.DateTimeOffset? validFrom = default(System.DateTimeOffset?), System.DateTimeOffset? validUntil = default(System.DateTimeOffset?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Communication.Rooms.CommunicationRoom>> UpdateRoomAsync(string roomId, System.DateTimeOffset? validFrom = default(System.DateTimeOffset?), System.DateTimeOffset? validUntil = default(System.DateTimeOffset?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<object> UpsertParticipants(string roomId, System.Collections.Generic.IEnumerable<Azure.Communication.Rooms.RoomParticipant> participants = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<object>> UpsertParticipantsAsync(string roomId, System.Collections.Generic.IEnumerable<Azure.Communication.Rooms.RoomParticipant> participants = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class RoomsClientOptions : Azure.Core.ClientOptions
    {
        public RoomsClientOptions(Azure.Communication.Rooms.RoomsClientOptions.ServiceVersion version = Azure.Communication.Rooms.RoomsClientOptions.ServiceVersion.V2023_03_31_Preview) { }
        public enum ServiceVersion
        {
            V2021_04_07_Preview = 1,
            V2022_02_01_Preview = 2,
            V2023_03_31_Preview = 3,
        }
    }
    public partial class RoomsCollection
    {
        internal RoomsCollection() { }
        public string NextLink { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Communication.Rooms.CommunicationRoom> Value { get { throw null; } }
    }
    public static partial class RoomsModelFactory
    {
        public static Azure.Communication.Rooms.CommunicationRoom CommunicationRoom(string id = null, System.DateTimeOffset createdAt = default(System.DateTimeOffset), System.DateTimeOffset validFrom = default(System.DateTimeOffset), System.DateTimeOffset validUntil = default(System.DateTimeOffset)) { throw null; }
        public static Azure.Communication.Rooms.ParticipantsCollection ParticipantsCollection(System.Collections.Generic.IEnumerable<Azure.Communication.Rooms.RoomParticipant> value = null, string nextLink = null) { throw null; }
        public static Azure.Communication.Rooms.RoomsCollection RoomsCollection(System.Collections.Generic.IEnumerable<Azure.Communication.Rooms.CommunicationRoom> value = null, string nextLink = null) { throw null; }
    }
}
