namespace Microsoft.AspNetCore.Builder
{
    public static partial class WebPubSubEndpointRouteBuilderExtensions
    {
        public static Microsoft.AspNetCore.Builder.IEndpointConventionBuilder MapWebPubSubHub<THub>(this Microsoft.AspNetCore.Routing.IEndpointRouteBuilder endpoints, string path) where THub : Microsoft.Azure.WebPubSub.AspNetCore.WebPubSubHub { throw null; }
    }
}
namespace Microsoft.Azure.WebPubSub.AspNetCore
{
    public abstract partial class WebPubSubHub
    {
        protected WebPubSubHub() { }
        public virtual System.Threading.Tasks.ValueTask<Microsoft.Azure.WebPubSub.Common.ConnectEventResponse> OnConnectAsync(Microsoft.Azure.WebPubSub.Common.ConnectEventRequest request, System.Threading.CancellationToken cancellationToken) { throw null; }
        public virtual System.Threading.Tasks.Task OnConnectedAsync(Microsoft.Azure.WebPubSub.Common.ConnectedEventRequest request) { throw null; }
        public virtual System.Threading.Tasks.Task OnDisconnectedAsync(Microsoft.Azure.WebPubSub.Common.DisconnectedEventRequest request) { throw null; }
        public virtual System.Threading.Tasks.ValueTask<Microsoft.Azure.WebPubSub.Common.UserEventResponse> OnMessageReceivedAsync(Microsoft.Azure.WebPubSub.Common.UserEventRequest request, System.Threading.CancellationToken cancellationToken) { throw null; }
    }
    public partial class WebPubSubOptions
    {
        public WebPubSubOptions() { }
        public Microsoft.Azure.WebPubSub.AspNetCore.WebPubSubValidationOptions ValidationOptions { get { throw null; } set { } }
    }
    public partial class WebPubSubValidationOptions
    {
        public WebPubSubValidationOptions(System.Collections.Generic.IEnumerable<string> connectionStrings) { }
        public WebPubSubValidationOptions(params string[] connectionStrings) { }
        public void Add(string connectionString) { }
    }
}
namespace Microsoft.Extensions.DependencyInjection
{
    public static partial class WebPubSubDependencyInjectionExtensions
    {
        public static Microsoft.Extensions.DependencyInjection.IServiceCollection AddWebPubSub(this Microsoft.Extensions.DependencyInjection.IServiceCollection services) { throw null; }
        public static Microsoft.Extensions.DependencyInjection.IServiceCollection AddWebPubSub(this Microsoft.Extensions.DependencyInjection.IServiceCollection services, System.Action<Microsoft.Azure.WebPubSub.AspNetCore.WebPubSubOptions> configure) { throw null; }
    }
}
