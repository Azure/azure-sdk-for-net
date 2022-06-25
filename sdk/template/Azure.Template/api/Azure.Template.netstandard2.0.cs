namespace Azure.Template
{
    public partial class WebPubSubServiceClient
    {
        protected WebPubSubServiceClient() { }
        public WebPubSubServiceClient(System.Uri endpoint, Azure.Core.TokenCredential credential) { }
        public WebPubSubServiceClient(System.Uri endpoint, Azure.Core.TokenCredential credential, Azure.Template.WebPubSubServiceClientOptions options) { }
        public virtual Azure.Core.Pipeline.HttpPipeline Pipeline { get { throw null; } }
        public virtual Azure.Response AddConnectionToGroup(string group, string connectionId, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> AddConnectionToGroupAsync(string group, string connectionId, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response AddUserToGroup(string userId, string group, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> AddUserToGroupAsync(string userId, string group, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response CheckPermission(string permission, string connectionId, string targetName = null, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> CheckPermissionAsync(string permission, string connectionId, string targetName = null, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response RemoveConnectionFromGroup(string group, string connectionId, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> RemoveConnectionFromGroupAsync(string group, string connectionId, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response RemoveUserFromGroup(string userId, string group, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> RemoveUserFromGroupAsync(string userId, string group, Azure.RequestContext context = null) { throw null; }
    }
    public partial class WebPubSubServiceClientOptions : Azure.Core.ClientOptions
    {
        public WebPubSubServiceClientOptions(Azure.Template.WebPubSubServiceClientOptions.ServiceVersion version = Azure.Template.WebPubSubServiceClientOptions.ServiceVersion.V2021_10_01) { }
        public enum ServiceVersion
        {
            V2021_10_01 = 1,
        }
    }
}
