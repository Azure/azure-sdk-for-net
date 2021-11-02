namespace Microsoft.Azure.WebPubSub.AspNetCore
{
    public abstract partial class WebPubSubHub
    {
        protected WebPubSubHub() { }
        public abstract System.Threading.Tasks.ValueTask<Microsoft.Azure.WebPubSub.Common.WebPubSubEventResponse> OnConnectAsync(Microsoft.Azure.WebPubSub.Common.ConnectEventRequest request, System.Threading.CancellationToken cancellationToken);
        public virtual System.Threading.Tasks.Task OnConnectedAsync(Microsoft.Azure.WebPubSub.Common.ConnectedEventRequest request) { throw null; }
        public virtual System.Threading.Tasks.Task OnDisconnectedAsync(Microsoft.Azure.WebPubSub.Common.DisconnectedEventRequest request) { throw null; }
        public abstract System.Threading.Tasks.ValueTask<Microsoft.Azure.WebPubSub.Common.WebPubSubEventResponse> OnMessageReceivedAsync(Microsoft.Azure.WebPubSub.Common.UserEventRequest request, System.Threading.CancellationToken cancellationToken);
    }
    public partial class WebPubSubOptions
    {
        public WebPubSubOptions() { }
        public Microsoft.Azure.WebPubSub.AspNetCore.WebPubSubValidationOptions ValidationOptions { get { throw null; } set { } }
    }
    public static partial class WebPubSubRequestExtensions
    {
        public static System.Threading.Tasks.Task<Microsoft.Azure.WebPubSub.Common.WebPubSubEventRequest> ReadWebPubSubEventAsync(this Microsoft.AspNetCore.Http.HttpRequest request, Microsoft.Azure.WebPubSub.AspNetCore.WebPubSubValidationOptions options = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class WebPubSubValidationOptions
    {
        public WebPubSubValidationOptions(System.Collections.Generic.IEnumerable<string> connectionStrings) { }
        public WebPubSubValidationOptions(params string[] connectionStrings) { }
        public void Add(string connectionString) { }
    }
}
