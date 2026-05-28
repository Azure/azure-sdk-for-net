namespace Microsoft.AspNetCore.Builder
{
    public static partial class WebPubSubEndpointRouteBuilderExtensions
    {
        public static Microsoft.AspNetCore.Builder.IEndpointConventionBuilder MapWebPubSubHub<THub>(this Microsoft.AspNetCore.Routing.IEndpointRouteBuilder endpoints, string path) where THub : Microsoft.Azure.WebPubSub.AspNetCore.WebPubSubHub { throw null; }
        public static Microsoft.AspNetCore.Builder.IEndpointConventionBuilder MapWebPubSubHub<THub>(this Microsoft.AspNetCore.Routing.IEndpointRouteBuilder endpoints, string path, string hubName) where THub : Microsoft.Azure.WebPubSub.AspNetCore.WebPubSubHub { throw null; }
    }
}
namespace Microsoft.Azure.WebPubSub.AspNetCore
{
    public partial class MqttConnectionException : System.Exception
    {
        public MqttConnectionException(Microsoft.Azure.WebPubSub.Common.MqttConnectEventErrorResponse mqttErrorResponse) { }
    }
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
        public Microsoft.Azure.WebPubSub.AspNetCore.WebPubSubServiceEndpoint ServiceEndpoint { get { throw null; } set { } }
    }
    public partial class WebPubSubServiceClient<THub> : Azure.Messaging.WebPubSub.WebPubSubServiceClient where THub : Microsoft.Azure.WebPubSub.AspNetCore.WebPubSubHub
    {
        protected WebPubSubServiceClient() { }
    }
    public partial class WebPubSubServiceEndpoint
    {
        public WebPubSubServiceEndpoint(string connectionString, Azure.Messaging.WebPubSub.WebPubSubServiceClientOptions clientOptions = null) { }
        public WebPubSubServiceEndpoint(System.Uri endpoint, Azure.AzureKeyCredential credential, Azure.Messaging.WebPubSub.WebPubSubServiceClientOptions clientOptions = null) { }
        public WebPubSubServiceEndpoint(System.Uri endpoint, Azure.Core.TokenCredential credential, Azure.Messaging.WebPubSub.WebPubSubServiceClientOptions clientOptions = null) { }
        public Azure.Messaging.WebPubSub.WebPubSubServiceClientOptions ClientOptions { get { throw null; } }
        public System.Uri Endpoint { get { throw null; } }
    }
}
namespace Microsoft.Extensions.DependencyInjection
{
    public static partial class WebPubSubDependencyInjectionExtensions
    {
        public static Microsoft.Extensions.DependencyInjection.IServiceCollection AddWebPubSub(this Microsoft.Extensions.DependencyInjection.IServiceCollection services) { throw null; }
        public static Microsoft.Extensions.DependencyInjection.IServiceCollection AddWebPubSub(this Microsoft.Extensions.DependencyInjection.IServiceCollection services, System.Action<Microsoft.Azure.WebPubSub.AspNetCore.WebPubSubOptions> configure) { throw null; }
        public static Microsoft.Extensions.DependencyInjection.IServiceCollection AddWebPubSubServiceClient<THub>(this Microsoft.Extensions.DependencyInjection.IServiceCollection services) where THub : Microsoft.Azure.WebPubSub.AspNetCore.WebPubSubHub { throw null; }
    }
}
