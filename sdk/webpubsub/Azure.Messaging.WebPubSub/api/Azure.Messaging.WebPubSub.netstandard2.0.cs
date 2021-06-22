namespace Azure.Messaging.WebPubSub
{
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
        public virtual System.Uri Endpoint { get { throw null; } }
        public virtual string Hub { get { throw null; } }
        public virtual Azure.Core.Pipeline.HttpPipeline Pipeline { get { throw null; } }
        public virtual Azure.Response AddConnectionToGroup(string group, string connectionId, Azure.RequestOptions options = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> AddConnectionToGroupAsync(string group, string connectionId, Azure.RequestOptions options = null) { throw null; }
        public virtual Azure.Response AddUserToGroup(string group, string userId, Azure.RequestOptions options = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> AddUserToGroupAsync(string group, string userId, Azure.RequestOptions options = null) { throw null; }
        public virtual Azure.Response<bool> CheckPermission(Azure.Messaging.WebPubSub.WebPubSubPermission permission, string connectionId, string targetName = null, Azure.RequestOptions options = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> CheckPermissionAsync(Azure.Messaging.WebPubSub.WebPubSubPermission permission, string connectionId, string targetName = null, Azure.RequestOptions options = null) { throw null; }
        public virtual Azure.Response CloseClientConnection(string connectionId, string reason = null, Azure.RequestOptions options = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> CloseClientConnectionAsync(string connectionId, string reason = null, Azure.RequestOptions options = null) { throw null; }
        public virtual Azure.Response<bool> ConnectionExists(string connectionId, Azure.RequestOptions options = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ConnectionExistsAsync(string connectionId, Azure.RequestOptions options = null) { throw null; }
        public virtual System.Uri GenerateClientAccessUri(System.DateTime expiresAtUtc, string userId = null, params string[] roles) { throw null; }
        public virtual System.Uri GenerateClientAccessUri(System.TimeSpan expiresAfter = default(System.TimeSpan), string userId = null, params string[] roles) { throw null; }
        public virtual Azure.Response GrantPermission(Azure.Messaging.WebPubSub.WebPubSubPermission permission, string connectionId, string targetName = null, Azure.RequestOptions options = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GrantPermissionAsync(Azure.Messaging.WebPubSub.WebPubSubPermission permission, string connectionId, string targetName = null, Azure.RequestOptions options = null) { throw null; }
        public virtual Azure.Response<bool> GroupExists(string group, Azure.RequestOptions options = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> GroupExistsAsync(string group, Azure.RequestOptions options = null) { throw null; }
        public virtual Azure.Response RemoveConnectionFromGroup(string group, string connectionId, Azure.RequestOptions options = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> RemoveConnectionFromGroupAsync(string group, string connectionId, Azure.RequestOptions options = null) { throw null; }
        public virtual Azure.Response RemoveUserFromAllGroups(string userId, Azure.RequestOptions options = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> RemoveUserFromAllGroupsAsync(string userId, Azure.RequestOptions options = null) { throw null; }
        public virtual Azure.Response RemoveUserFromGroup(string group, string userId, Azure.RequestOptions options = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> RemoveUserFromGroupAsync(string group, string userId, Azure.RequestOptions options = null) { throw null; }
        public virtual Azure.Response RevokePermission(Azure.Messaging.WebPubSub.WebPubSubPermission permission, string connectionId, string targetName = null, Azure.RequestOptions options = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> RevokePermissionAsync(Azure.Messaging.WebPubSub.WebPubSubPermission permission, string connectionId, string targetName = null, Azure.RequestOptions options = null) { throw null; }
        public virtual Azure.Response SendToAll(string content, Azure.Core.ContentType contentType = default(Azure.Core.ContentType)) { throw null; }
        public virtual Azure.Response SendToAll(string contentType, Azure.Core.RequestContent content, System.Collections.Generic.IEnumerable<string> excluded = null, Azure.RequestOptions options = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> SendToAllAsync(string content, Azure.Core.ContentType contentType = default(Azure.Core.ContentType)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> SendToAllAsync(string contentType, Azure.Core.RequestContent content, System.Collections.Generic.IEnumerable<string> excluded = null, Azure.RequestOptions options = null) { throw null; }
        public virtual Azure.Response SendToConnection(string connectionId, string content, Azure.Core.ContentType contentType = default(Azure.Core.ContentType)) { throw null; }
        public virtual Azure.Response SendToConnection(string connectionId, string contentType, Azure.Core.RequestContent content, Azure.RequestOptions options = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> SendToConnectionAsync(string connectionId, string content, Azure.Core.ContentType contentType = default(Azure.Core.ContentType)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> SendToConnectionAsync(string connectionId, string contentType, Azure.Core.RequestContent content, Azure.RequestOptions options = null) { throw null; }
        public virtual Azure.Response SendToGroup(string group, string content, Azure.Core.ContentType contentType = default(Azure.Core.ContentType)) { throw null; }
        public virtual Azure.Response SendToGroup(string group, string contentType, Azure.Core.RequestContent content, System.Collections.Generic.IEnumerable<string> excluded = null, Azure.RequestOptions options = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> SendToGroupAsync(string group, string content, Azure.Core.ContentType contentType = default(Azure.Core.ContentType)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> SendToGroupAsync(string group, string contentType, Azure.Core.RequestContent content, System.Collections.Generic.IEnumerable<string> excluded = null, Azure.RequestOptions options = null) { throw null; }
        public virtual Azure.Response SendToUser(string userId, string content, Azure.Core.ContentType contentType = default(Azure.Core.ContentType)) { throw null; }
        public virtual Azure.Response SendToUser(string userId, string contentType, Azure.Core.RequestContent content, Azure.RequestOptions options = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> SendToUserAsync(string userId, string content, Azure.Core.ContentType contentType = default(Azure.Core.ContentType)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> SendToUserAsync(string userId, string contentType, Azure.Core.RequestContent content, Azure.RequestOptions options = null) { throw null; }
        public virtual Azure.Response<bool> UserExists(string userId, Azure.RequestOptions options = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> UserExistsAsync(string userId, Azure.RequestOptions options = null) { throw null; }
    }
    public partial class WebPubSubServiceClientOptions : Azure.Core.ClientOptions
    {
        public WebPubSubServiceClientOptions(Azure.Messaging.WebPubSub.WebPubSubServiceClientOptions.ServiceVersion version = Azure.Messaging.WebPubSub.WebPubSubServiceClientOptions.ServiceVersion.V2021_05_01_preview) { }
        public enum ServiceVersion
        {
            V2021_05_01_preview = 1,
        }
    }
}
namespace Microsoft.Extensions.Azure
{
    public static partial class WebPubSubServiceClientBuilderExtensions
    {
        public static Azure.Core.Extensions.IAzureClientBuilder<Azure.Messaging.WebPubSub.WebPubSubServiceClient, Azure.Messaging.WebPubSub.WebPubSubServiceClientOptions> AddWebPubSubServiceClient<TBuilder>(this TBuilder builder, string connectionString, string hub) where TBuilder : Azure.Core.Extensions.IAzureClientFactoryBuilder { throw null; }
        public static Azure.Core.Extensions.IAzureClientBuilder<Azure.Messaging.WebPubSub.WebPubSubServiceClient, Azure.Messaging.WebPubSub.WebPubSubServiceClientOptions> AddWebPubSubServiceClient<TBuilder>(this TBuilder builder, System.Uri endpoint, string hub, Azure.AzureKeyCredential credential) where TBuilder : Azure.Core.Extensions.IAzureClientFactoryBuilder { throw null; }
        public static Azure.Core.Extensions.IAzureClientBuilder<Azure.Messaging.WebPubSub.WebPubSubServiceClient, Azure.Messaging.WebPubSub.WebPubSubServiceClientOptions> AddWebPubSubServiceClient<TBuilder, TConfiguration>(this TBuilder builder, TConfiguration configuration) where TBuilder : Azure.Core.Extensions.IAzureClientFactoryBuilderWithConfiguration<TConfiguration> { throw null; }
    }
}
