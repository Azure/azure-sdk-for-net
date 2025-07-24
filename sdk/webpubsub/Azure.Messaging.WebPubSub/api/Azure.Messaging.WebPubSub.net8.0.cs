namespace Azure.Messaging.WebPubSub
{
    public static partial class ClientConnectionFilter
    {
        public static string Create(System.FormattableString filter) { throw null; }
        public static string Create(System.FormattableString filter, System.IFormatProvider formatProvider) { throw null; }
    }
    public enum WebPubSubClientProtocol
    {
        Default = 0,
        Mqtt = 1,
        SocketIO = 2,
    }
    public partial class WebPubSubGroupMember
    {
        public WebPubSubGroupMember(string connectionId) { }
        public string ConnectionId { get { throw null; } }
        public string? UserId { get { throw null; } set { } }
    }
    public enum WebPubSubPermission
    {
        SendToGroup = 1,
        JoinLeaveGroup = 2,
    }
    public partial class WebPubSubServiceClient
    {
        protected WebPubSubServiceClient() { }
        public WebPubSubServiceClient(string connectionString, string hub) { }
        public WebPubSubServiceClient(string connectionString, string hub, Azure.Messaging.WebPubSub.WebPubSubServiceClientOptions options) { }
        public WebPubSubServiceClient(System.Uri endpoint, string hub, Azure.AzureKeyCredential credential) { }
        public WebPubSubServiceClient(System.Uri endpoint, string hub, Azure.AzureKeyCredential credential, Azure.Messaging.WebPubSub.WebPubSubServiceClientOptions options) { }
        public WebPubSubServiceClient(System.Uri endpoint, string hub, Azure.Core.TokenCredential credential) { }
        public WebPubSubServiceClient(System.Uri endpoint, string hub, Azure.Core.TokenCredential credential, Azure.Messaging.WebPubSub.WebPubSubServiceClientOptions options) { }
        public virtual System.Uri Endpoint { get { throw null; } }
        public virtual string Hub { get { throw null; } }
        public virtual Azure.Core.Pipeline.HttpPipeline Pipeline { get { throw null; } }
        public virtual Azure.Response AddConnectionsToGroups(System.Collections.Generic.IEnumerable<string> groups, string filter, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> AddConnectionsToGroupsAsync(System.Collections.Generic.IEnumerable<string> groups, string filter, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response AddConnectionToGroup(string group, string connectionId, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> AddConnectionToGroupAsync(string group, string connectionId, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response AddUserToGroup(string group, string userId, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> AddUserToGroupAsync(string group, string userId, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response<bool> CheckPermission(Azure.Messaging.WebPubSub.WebPubSubPermission permission, string connectionId, string targetName = null, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> CheckPermissionAsync(Azure.Messaging.WebPubSub.WebPubSubPermission permission, string connectionId, string targetName = null, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response CloseAllConnections(System.Collections.Generic.IEnumerable<string> excluded = null, string reason = null, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> CloseAllConnectionsAsync(System.Collections.Generic.IEnumerable<string> excluded = null, string reason = null, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response CloseConnection(string connectionId, string reason = null, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> CloseConnectionAsync(string connectionId, string reason = null, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response CloseGroupConnections(string group, System.Collections.Generic.IEnumerable<string> excluded = null, string reason = null, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> CloseGroupConnectionsAsync(string group, System.Collections.Generic.IEnumerable<string> excluded = null, string reason = null, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response CloseUserConnections(string userId, System.Collections.Generic.IEnumerable<string> excluded = null, string reason = null, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> CloseUserConnectionsAsync(string userId, System.Collections.Generic.IEnumerable<string> excluded = null, string reason = null, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response<bool> ConnectionExists(string connectionId, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ConnectionExistsAsync(string connectionId, Azure.RequestContext context = null) { throw null; }
        public virtual System.Uri GetClientAccessUri(System.DateTimeOffset expiresAt, string userId = null, System.Collections.Generic.IEnumerable<string> roles = null, System.Collections.Generic.IEnumerable<string> groups = null, Azure.Messaging.WebPubSub.WebPubSubClientProtocol clientProtocol = Azure.Messaging.WebPubSub.WebPubSubClientProtocol.Default, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public virtual System.Uri GetClientAccessUri(System.DateTimeOffset expiresAt, string userId, System.Collections.Generic.IEnumerable<string> roles, System.Collections.Generic.IEnumerable<string> groups, System.Threading.CancellationToken cancellationToken) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public virtual System.Uri GetClientAccessUri(System.DateTimeOffset expiresAt, string userId, System.Collections.Generic.IEnumerable<string> roles, System.Threading.CancellationToken cancellationToken) { throw null; }
        public virtual System.Uri GetClientAccessUri(System.TimeSpan expiresAfter = default(System.TimeSpan), string userId = null, System.Collections.Generic.IEnumerable<string> roles = null, System.Collections.Generic.IEnumerable<string> groups = null, Azure.Messaging.WebPubSub.WebPubSubClientProtocol clientProtocol = Azure.Messaging.WebPubSub.WebPubSubClientProtocol.Default, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public virtual System.Uri GetClientAccessUri(System.TimeSpan expiresAfter, string userId, System.Collections.Generic.IEnumerable<string> roles, System.Collections.Generic.IEnumerable<string> groups, System.Threading.CancellationToken cancellationToken) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public virtual System.Uri GetClientAccessUri(System.TimeSpan expiresAfter, string userId, System.Collections.Generic.IEnumerable<string> roles, System.Threading.CancellationToken cancellationToken) { throw null; }
        public virtual System.Threading.Tasks.Task<System.Uri> GetClientAccessUriAsync(System.DateTimeOffset expiresAt, string userId = null, System.Collections.Generic.IEnumerable<string> roles = null, System.Collections.Generic.IEnumerable<string> groups = null, Azure.Messaging.WebPubSub.WebPubSubClientProtocol clientProtocol = Azure.Messaging.WebPubSub.WebPubSubClientProtocol.Default, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public virtual System.Threading.Tasks.Task<System.Uri> GetClientAccessUriAsync(System.DateTimeOffset expiresAt, string userId, System.Collections.Generic.IEnumerable<string> roles, System.Collections.Generic.IEnumerable<string> groups, System.Threading.CancellationToken cancellationToken) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public virtual System.Threading.Tasks.Task<System.Uri> GetClientAccessUriAsync(System.DateTimeOffset expiresAt, string userId, System.Collections.Generic.IEnumerable<string> roles, System.Threading.CancellationToken cancellationToken) { throw null; }
        public virtual System.Threading.Tasks.Task<System.Uri> GetClientAccessUriAsync(System.TimeSpan expiresAfter = default(System.TimeSpan), string userId = null, System.Collections.Generic.IEnumerable<string> roles = null, System.Collections.Generic.IEnumerable<string> groups = null, Azure.Messaging.WebPubSub.WebPubSubClientProtocol clientProtocol = Azure.Messaging.WebPubSub.WebPubSubClientProtocol.Default, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public virtual System.Threading.Tasks.Task<System.Uri> GetClientAccessUriAsync(System.TimeSpan expiresAfter, string userId, System.Collections.Generic.IEnumerable<string> roles, System.Collections.Generic.IEnumerable<string> groups, System.Threading.CancellationToken cancellationToken) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public virtual System.Threading.Tasks.Task<System.Uri> GetClientAccessUriAsync(System.TimeSpan expiresAfter, string userId, System.Collections.Generic.IEnumerable<string> roles, System.Threading.CancellationToken cancellationToken) { throw null; }
        public virtual Azure.Response GrantPermission(Azure.Messaging.WebPubSub.WebPubSubPermission permission, string connectionId, string targetName = null, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GrantPermissionAsync(Azure.Messaging.WebPubSub.WebPubSubPermission permission, string connectionId, string targetName = null, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response<bool> GroupExists(string group, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> GroupExistsAsync(string group, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Pageable<Azure.Messaging.WebPubSub.WebPubSubGroupMember> ListConnectionsInGroup(string group, int? maxpagesize = default(int?), int? maxCount = default(int?), string continuationToken = null) { throw null; }
        public virtual Azure.AsyncPageable<Azure.Messaging.WebPubSub.WebPubSubGroupMember> ListConnectionsInGroupAsync(string group, int? maxpagesize = default(int?), int? maxCount = default(int?), string continuationToken = null) { throw null; }
        public virtual Azure.Response RemoveConnectionFromAllGroups(string connectionId, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> RemoveConnectionFromAllGroupsAsync(string connectionId, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response RemoveConnectionFromGroup(string group, string connectionId, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> RemoveConnectionFromGroupAsync(string group, string connectionId, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response RemoveConnectionsFromGroups(System.Collections.Generic.IEnumerable<string> groups, string filter = null, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> RemoveConnectionsFromGroupsAsync(System.Collections.Generic.IEnumerable<string> groups, string filter = null, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response RemoveUserFromAllGroups(string userId, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> RemoveUserFromAllGroupsAsync(string userId, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response RemoveUserFromGroup(string group, string userId, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> RemoveUserFromGroupAsync(string group, string userId, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response RevokePermission(Azure.Messaging.WebPubSub.WebPubSubPermission permission, string connectionId, string targetName = null, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> RevokePermissionAsync(Azure.Messaging.WebPubSub.WebPubSubPermission permission, string connectionId, string targetName = null, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response SendToAll(Azure.Core.RequestContent content, Azure.Core.ContentType contentType, System.Collections.Generic.IEnumerable<string> excluded, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response SendToAll(Azure.Core.RequestContent content, Azure.Core.ContentType contentType, System.Collections.Generic.IEnumerable<string> excluded = null, string filter = null, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response SendToAll(string content, Azure.Core.ContentType contentType = default(Azure.Core.ContentType)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> SendToAllAsync(Azure.Core.RequestContent content, Azure.Core.ContentType contentType, System.Collections.Generic.IEnumerable<string> excluded, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> SendToAllAsync(Azure.Core.RequestContent content, Azure.Core.ContentType contentType, System.Collections.Generic.IEnumerable<string> excluded = null, string filter = null, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> SendToAllAsync(string content, Azure.Core.ContentType contentType = default(Azure.Core.ContentType)) { throw null; }
        public virtual Azure.Response SendToConnection(string connectionId, Azure.Core.RequestContent content, Azure.Core.ContentType contentType, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response SendToConnection(string connectionId, string content, Azure.Core.ContentType contentType = default(Azure.Core.ContentType)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> SendToConnectionAsync(string connectionId, Azure.Core.RequestContent content, Azure.Core.ContentType contentType, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> SendToConnectionAsync(string connectionId, string content, Azure.Core.ContentType contentType = default(Azure.Core.ContentType)) { throw null; }
        public virtual Azure.Response SendToGroup(string group, Azure.Core.RequestContent content, Azure.Core.ContentType contentType, System.Collections.Generic.IEnumerable<string> excluded, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response SendToGroup(string group, Azure.Core.RequestContent content, Azure.Core.ContentType contentType, System.Collections.Generic.IEnumerable<string> excluded = null, string filter = null, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response SendToGroup(string group, string content, Azure.Core.ContentType contentType = default(Azure.Core.ContentType)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> SendToGroupAsync(string group, Azure.Core.RequestContent content, Azure.Core.ContentType contentType, System.Collections.Generic.IEnumerable<string> excluded, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> SendToGroupAsync(string group, Azure.Core.RequestContent content, Azure.Core.ContentType contentType, System.Collections.Generic.IEnumerable<string> excluded = null, string filter = null, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> SendToGroupAsync(string group, string content, Azure.Core.ContentType contentType = default(Azure.Core.ContentType)) { throw null; }
        public virtual Azure.Response SendToUser(string userId, Azure.Core.RequestContent content, Azure.Core.ContentType contentType, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response SendToUser(string userId, Azure.Core.RequestContent content, Azure.Core.ContentType contentType, string filter = null, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response SendToUser(string userId, string content, Azure.Core.ContentType contentType = default(Azure.Core.ContentType)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> SendToUserAsync(string userId, Azure.Core.RequestContent content, Azure.Core.ContentType contentType, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> SendToUserAsync(string userId, Azure.Core.RequestContent content, Azure.Core.ContentType contentType, string filter = null, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> SendToUserAsync(string userId, string content, Azure.Core.ContentType contentType = default(Azure.Core.ContentType)) { throw null; }
        public virtual Azure.Response<bool> UserExists(string userId, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> UserExistsAsync(string userId, Azure.RequestContext context = null) { throw null; }
    }
    public partial class WebPubSubServiceClientOptions : Azure.Core.ClientOptions
    {
        public WebPubSubServiceClientOptions(Azure.Messaging.WebPubSub.WebPubSubServiceClientOptions.ServiceVersion version = Azure.Messaging.WebPubSub.WebPubSubServiceClientOptions.ServiceVersion.V2024_12_01) { }
        public System.Uri ReverseProxyEndpoint { get { throw null; } set { } }
        public enum ServiceVersion
        {
            V2021_10_01 = 1,
            V2024_01_01 = 2,
            V2024_12_01 = 3,
        }
    }
}
namespace Microsoft.Extensions.Azure
{
    public static partial class WebPubSubServiceClientBuilderExtensions
    {
        public static Azure.Core.Extensions.IAzureClientBuilder<Azure.Messaging.WebPubSub.WebPubSubServiceClient, Azure.Messaging.WebPubSub.WebPubSubServiceClientOptions> AddWebPubSubServiceClient<TBuilder>(this TBuilder builder, string connectionString, string hub) where TBuilder : Azure.Core.Extensions.IAzureClientFactoryBuilder { throw null; }
        public static Azure.Core.Extensions.IAzureClientBuilder<Azure.Messaging.WebPubSub.WebPubSubServiceClient, Azure.Messaging.WebPubSub.WebPubSubServiceClientOptions> AddWebPubSubServiceClient<TBuilder>(this TBuilder builder, System.Uri endpoint, string hub, Azure.AzureKeyCredential credential) where TBuilder : Azure.Core.Extensions.IAzureClientFactoryBuilder { throw null; }
        public static Azure.Core.Extensions.IAzureClientBuilder<Azure.Messaging.WebPubSub.WebPubSubServiceClient, Azure.Messaging.WebPubSub.WebPubSubServiceClientOptions> AddWebPubSubServiceClient<TBuilder>(this TBuilder builder, System.Uri endpoint, string hub, Azure.Core.TokenCredential credential) where TBuilder : Azure.Core.Extensions.IAzureClientFactoryBuilder { throw null; }
        [System.Diagnostics.CodeAnalysis.RequiresDynamicCodeAttribute("Binding strongly typed objects to configuration values requires generating dynamic code at runtime, for example instantiating generic types. Use the Configuration Binder Source Generator (EnableConfigurationBindingGenerator=true) instead.")]
        public static Azure.Core.Extensions.IAzureClientBuilder<Azure.Messaging.WebPubSub.WebPubSubServiceClient, Azure.Messaging.WebPubSub.WebPubSubServiceClientOptions> AddWebPubSubServiceClient<TBuilder, TConfiguration>(this TBuilder builder, TConfiguration configuration) where TBuilder : Azure.Core.Extensions.IAzureClientFactoryBuilderWithConfiguration<TConfiguration> { throw null; }
    }
}
