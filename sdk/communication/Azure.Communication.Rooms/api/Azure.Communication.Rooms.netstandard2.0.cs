namespace Azure.Communication.Rooms
{
    public partial class RoomsClient
    {
        protected RoomsClient() { }
        public RoomsClient(string connectionString) { }
        public RoomsClient(string connectionString, Azure.Communication.Rooms.RoomsClientOptions options) { }
        public RoomsClient(System.Uri endpoint, Azure.AzureKeyCredential keyCredential, Azure.Communication.Rooms.RoomsClientOptions options = null) { }
        public RoomsClient(System.Uri endpoint, Azure.Core.TokenCredential tokenCredential, Azure.Communication.Rooms.RoomsClientOptions options = null) { }
        public virtual Azure.Response<Azure.Communication.Rooms.Models.CommunicationRoom> AddParticipants(string roomId, System.Collections.Generic.IEnumerable<Azure.Communication.Rooms.Models.RoomParticipant> participants, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Communication.Rooms.Models.CommunicationRoom>> AddParticipantsAsync(string roomId, System.Collections.Generic.IEnumerable<Azure.Communication.Rooms.Models.RoomParticipant> participants, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Communication.Rooms.Models.CommunicationRoom> CreateRoom(System.Collections.Generic.IEnumerable<Azure.Communication.Rooms.Models.RoomParticipant> participants = null, System.DateTimeOffset? validFrom = default(System.DateTimeOffset?), System.DateTimeOffset? validUntil = default(System.DateTimeOffset?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Communication.Rooms.Models.CommunicationRoom>> CreateRoomAsync(System.Collections.Generic.IEnumerable<Azure.Communication.Rooms.Models.RoomParticipant> participants = null, System.DateTimeOffset? validFrom = default(System.DateTimeOffset?), System.DateTimeOffset? validUntil = default(System.DateTimeOffset?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response DeleteRoom(string roomId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteRoomAsync(string roomId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Communication.Rooms.Models.CommunicationRoom> GetRoom(string roomId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Communication.Rooms.Models.CommunicationRoom>> GetRoomAsync(string roomId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Communication.Rooms.Models.CommunicationRoom> RemoveParticipants(string roomId, System.Collections.Generic.IEnumerable<string> communicationUsers, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Communication.Rooms.Models.CommunicationRoom>> RemoveParticipantsAsync(string roomId, System.Collections.Generic.IEnumerable<string> communicationUsers, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Communication.Rooms.Models.CommunicationRoom> UpdateParticipants(string roomId, System.Collections.Generic.IEnumerable<Azure.Communication.Rooms.Models.RoomParticipant> participants, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Communication.Rooms.Models.CommunicationRoom>> UpdateParticipantsAsync(string roomId, System.Collections.Generic.IEnumerable<Azure.Communication.Rooms.Models.RoomParticipant> participants, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Communication.Rooms.Models.CommunicationRoom> UpdateRoom(string roomId, System.DateTimeOffset? validFrom = default(System.DateTimeOffset?), System.DateTimeOffset? validUntil = default(System.DateTimeOffset?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Communication.Rooms.Models.CommunicationRoom>> UpdateRoomAsync(string roomId, System.DateTimeOffset? validFrom = default(System.DateTimeOffset?), System.DateTimeOffset? validUntil = default(System.DateTimeOffset?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
namespace Azure.Communication.Rooms.Models
{
    public partial class CommunicationRoom
    {
        internal CommunicationRoom() { }
        public System.DateTimeOffset? CreatedDateTime { get { throw null; } }
        public string Id { get { throw null; } }
        public System.Collections.Generic.IEnumerable<Azure.Communication.Rooms.Models.RoomParticipant> Participants { get { throw null; } }
        public System.DateTimeOffset? ValidFrom { get { throw null; } }
        public System.DateTimeOffset? ValidUntil { get { throw null; } }
    }
    public partial class RoomParticipant
    {
        public RoomParticipant(string identifier, string roleName) { }
        public string Identifier { get { throw null; } set { } }
        public string RoleName { get { throw null; } set { } }
    }
}
