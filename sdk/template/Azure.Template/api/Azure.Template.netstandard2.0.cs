namespace Azure.Template
{
    public partial class WebPubSubServiceClient
    {
        protected WebPubSubServiceClient() { }
        public WebPubSubServiceClient(System.Uri endpoint, Azure.Core.TokenCredential credential) { }
        public WebPubSubServiceClient(System.Uri endpoint, Azure.Core.TokenCredential credential, Azure.Template.WebPubSubServiceClientOptions options) { }
        public virtual Azure.Core.Pipeline.HttpPipeline Pipeline { get { throw null; } }
        public virtual Azure.Response AddConnectionToGroup(string hub, string group, string connectionId, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> AddConnectionToGroupAsync(string hub, string group, string connectionId, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response AddUserToGroup(string hub, string userId, string group, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> AddUserToGroupAsync(string hub, string userId, string group, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response CheckPermission(string hub, string permission, string connectionId, string targetName = null, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> CheckPermissionAsync(string hub, string permission, string connectionId, string targetName = null, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response RemoveConnectionFromGroup(string hub, string group, string connectionId, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> RemoveConnectionFromGroupAsync(string hub, string group, string connectionId, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response RemoveUserFromGroup(string hub, string userId, string group, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> RemoveUserFromGroupAsync(string hub, string userId, string group, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response SendToAll(string hub, Azure.Core.RequestContent content, System.Collections.Generic.IEnumerable<string> excluded = null, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> SendToAllAsync(string hub, Azure.Core.RequestContent content, System.Collections.Generic.IEnumerable<string> excluded = null, Azure.RequestContext context = null) { throw null; }
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
