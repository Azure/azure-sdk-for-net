namespace Azure.Rest.WebPubSub
{
    public partial class WebPubSubServiceRestClient
    {
        protected WebPubSubServiceRestClient() { }
        public WebPubSubServiceRestClient(System.Uri endpoint, Azure.AzureKeyCredential credential) { }
        public WebPubSubServiceRestClient(System.Uri endpoint, Azure.AzureKeyCredential credential, Azure.Rest.WebPubSub.WebPubSubServiceRestClientOptions options) { }
        public virtual Azure.Response AddConnectionToGroup(string hub, string group, string connectionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> AddConnectionToGroupAsync(string hub, string group, string connectionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response CheckConnectionExistence(string hub, string connectionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> CheckConnectionExistenceAsync(string hub, string connectionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response CheckGroupExistence(string hub, string group, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> CheckGroupExistenceAsync(string hub, string group, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response CheckPermission(string hub, string permission, string connectionId, string targetName = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> CheckPermissionAsync(string hub, string permission, string connectionId, string targetName = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response CheckUserExistence(string hub, string userId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> CheckUserExistenceAsync(string hub, string userId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response CheckUserExistenceInGroup(string hub, string group, string userId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> CheckUserExistenceInGroupAsync(string hub, string group, string userId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GrantPermission(string hub, string permission, string connectionId, string targetName = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GrantPermissionAsync(string hub, string permission, string connectionId, string targetName = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response RemoveUserFromAllGroups(string hub, string userId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> RemoveUserFromAllGroupsAsync(string hub, string userId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response RevokePermission(string hub, string permission, string connectionId, string targetName = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> RevokePermissionAsync(string hub, string permission, string connectionId, string targetName = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response SendToAll(string hub, Azure.Core.RequestContent payloadMessage, System.Collections.Generic.IEnumerable<string> excluded = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response SendToAll(string hub, System.IO.Stream payloadMessage, System.Collections.Generic.IEnumerable<string> excluded = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response SendToAll(string hub, string payloadMessage, System.Collections.Generic.IEnumerable<string> excluded = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> SendToAllAsync(string hub, System.IO.Stream payloadMessage, System.Collections.Generic.IEnumerable<string> excluded = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> SendToAllAsync(string hub, string payloadMessage, System.Collections.Generic.IEnumerable<string> excluded = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response SendToConnection(string hub, string connectionId, System.IO.Stream payloadMessage, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response SendToConnection(string hub, string connectionId, string payloadMessage, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> SendToConnectionAsync(string hub, string connectionId, System.IO.Stream payloadMessage, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> SendToConnectionAsync(string hub, string connectionId, string payloadMessage, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response SendToGroup(string hub, string group, System.IO.Stream payloadMessage, System.Collections.Generic.IEnumerable<string> excluded = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response SendToGroup(string hub, string group, string payloadMessage, System.Collections.Generic.IEnumerable<string> excluded = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> SendToGroupAsync(string hub, string group, System.IO.Stream payloadMessage, System.Collections.Generic.IEnumerable<string> excluded = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> SendToGroupAsync(string hub, string group, string payloadMessage, System.Collections.Generic.IEnumerable<string> excluded = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response SendToUser(string hub, string userId, System.IO.Stream payloadMessage, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response SendToUser(string hub, string userId, string payloadMessage, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> SendToUserAsync(string hub, string userId, System.IO.Stream payloadMessage, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> SendToUserAsync(string hub, string userId, string payloadMessage, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class WebPubSubServiceRestClientOptions : Azure.Core.ClientOptions
    {
        public WebPubSubServiceRestClientOptions() { }
    }
}
