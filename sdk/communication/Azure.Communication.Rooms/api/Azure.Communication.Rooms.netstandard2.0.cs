namespace Azure.Communication.Rooms
{
    public partial class CommunicationRoom
    {
        internal CommunicationRoom() { }
        public System.DateTimeOffset? CreatedOn { get { throw null; } }
        public string Id { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Communication.Rooms.RoomParticipant> Participants { get { throw null; } }
        public Azure.Communication.Rooms.RoomJoinPolicy? RoomJoinPolicy { get { throw null; } }
        public System.DateTimeOffset? ValidFrom { get { throw null; } }
        public System.DateTimeOffset? ValidUntil { get { throw null; } }
    }
    public partial class ParticipantsCollection
    {
        internal ParticipantsCollection() { }
        public System.Collections.Generic.IReadOnlyList<Azure.Communication.Rooms.RoomParticipant> Participants { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RoleType : System.IEquatable<Azure.Communication.Rooms.RoleType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RoleType(string value) { throw null; }
        public static Azure.Communication.Rooms.RoleType Attendee { get { throw null; } }
        public static Azure.Communication.Rooms.RoleType Consumer { get { throw null; } }
        public static Azure.Communication.Rooms.RoleType Presenter { get { throw null; } }
        public bool Equals(Azure.Communication.Rooms.RoleType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Communication.Rooms.RoleType left, Azure.Communication.Rooms.RoleType right) { throw null; }
        public static implicit operator Azure.Communication.Rooms.RoleType (string value) { throw null; }
        public static bool operator !=(Azure.Communication.Rooms.RoleType left, Azure.Communication.Rooms.RoleType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RoomJoinPolicy : System.IEquatable<Azure.Communication.Rooms.RoomJoinPolicy>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RoomJoinPolicy(string value) { throw null; }
        public static Azure.Communication.Rooms.RoomJoinPolicy CommunicationServiceUsers { get { throw null; } }
        public static Azure.Communication.Rooms.RoomJoinPolicy InviteOnly { get { throw null; } }
        public bool Equals(Azure.Communication.Rooms.RoomJoinPolicy other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Communication.Rooms.RoomJoinPolicy left, Azure.Communication.Rooms.RoomJoinPolicy right) { throw null; }
        public static implicit operator Azure.Communication.Rooms.RoomJoinPolicy (string value) { throw null; }
        public static bool operator !=(Azure.Communication.Rooms.RoomJoinPolicy left, Azure.Communication.Rooms.RoomJoinPolicy right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class RoomParticipant
    {
        public RoomParticipant(Azure.Communication.CommunicationIdentifier communicationIdentifier) { }
        public RoomParticipant(Azure.Communication.CommunicationIdentifier communicationIdentifier, Azure.Communication.Rooms.RoleType role) { }
        public Azure.Communication.CommunicationIdentifier CommunicationIdentifier { get { throw null; } }
        public Azure.Communication.Rooms.RoleType? Role { get { throw null; } set { } }
    }
    public partial class RoomsClient
    {
        protected RoomsClient() { }
        public RoomsClient(string connectionString) { }
        public RoomsClient(string connectionString, Azure.Communication.Rooms.RoomsClientOptions options) { }
        public RoomsClient(System.Uri endpoint, Azure.AzureKeyCredential keyCredential, Azure.Communication.Rooms.RoomsClientOptions options = null) { }
        public RoomsClient(System.Uri endpoint, Azure.Core.TokenCredential tokenCredential, Azure.Communication.Rooms.RoomsClientOptions options = null) { }
        public virtual Azure.Response AddParticipants(string roomId, System.Collections.Generic.IEnumerable<Azure.Communication.Rooms.RoomParticipant> participants = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> AddParticipantsAsync(string roomId, System.Collections.Generic.IEnumerable<Azure.Communication.Rooms.RoomParticipant> participants = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Communication.Rooms.CommunicationRoom> CreateRoom(System.DateTimeOffset? validFrom = default(System.DateTimeOffset?), System.DateTimeOffset? validUntil = default(System.DateTimeOffset?), Azure.Communication.Rooms.RoomJoinPolicy? roomJoinPolicy = default(Azure.Communication.Rooms.RoomJoinPolicy?), System.Collections.Generic.IEnumerable<Azure.Communication.Rooms.RoomParticipant> participants = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Communication.Rooms.CommunicationRoom>> CreateRoomAsync(System.DateTimeOffset? validFrom = default(System.DateTimeOffset?), System.DateTimeOffset? validUntil = default(System.DateTimeOffset?), Azure.Communication.Rooms.RoomJoinPolicy? roomJoinPolicy = default(Azure.Communication.Rooms.RoomJoinPolicy?), System.Collections.Generic.IEnumerable<Azure.Communication.Rooms.RoomParticipant> participants = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response DeleteRoom(string roomId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteRoomAsync(string roomId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Communication.Rooms.ParticipantsCollection> GetParticipants(string roomId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Communication.Rooms.ParticipantsCollection>> GetParticipantsAsync(string roomId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Communication.Rooms.CommunicationRoom> GetRoom(string roomId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Communication.Rooms.CommunicationRoom>> GetRoomAsync(string roomId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response RemoveParticipants(string roomId, System.Collections.Generic.IEnumerable<Azure.Communication.CommunicationIdentifier> communicationIdentifiers, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> RemoveParticipantsAsync(string roomId, System.Collections.Generic.IEnumerable<Azure.Communication.CommunicationIdentifier> communicationIdentifiers, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response UpdateParticipants(string roomId, System.Collections.Generic.IEnumerable<Azure.Communication.Rooms.RoomParticipant> participants = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> UpdateParticipantsAsync(string roomId, System.Collections.Generic.IEnumerable<Azure.Communication.Rooms.RoomParticipant> participants = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Communication.Rooms.CommunicationRoom> UpdateRoom(string roomId, System.DateTimeOffset? validFrom = default(System.DateTimeOffset?), System.DateTimeOffset? validUntil = default(System.DateTimeOffset?), Azure.Communication.Rooms.RoomJoinPolicy? roomJoinPolicy = default(Azure.Communication.Rooms.RoomJoinPolicy?), System.Collections.Generic.IEnumerable<Azure.Communication.Rooms.RoomParticipant> participants = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Communication.Rooms.CommunicationRoom>> UpdateRoomAsync(string roomId, System.DateTimeOffset? validFrom = default(System.DateTimeOffset?), System.DateTimeOffset? validUntil = default(System.DateTimeOffset?), Azure.Communication.Rooms.RoomJoinPolicy? roomJoinPolicy = default(Azure.Communication.Rooms.RoomJoinPolicy?), System.Collections.Generic.IEnumerable<Azure.Communication.Rooms.RoomParticipant> participants = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class RoomsClientOptions : Azure.Core.ClientOptions
    {
        public RoomsClientOptions(Azure.Communication.Rooms.RoomsClientOptions.ServiceVersion version = Azure.Communication.Rooms.RoomsClientOptions.ServiceVersion.V2022_02_01_Preview) { }
        public enum ServiceVersion
        {
            V2021_04_07_Preview = 1,
            V2022_02_01_Preview = 2,
        }
    }
}
