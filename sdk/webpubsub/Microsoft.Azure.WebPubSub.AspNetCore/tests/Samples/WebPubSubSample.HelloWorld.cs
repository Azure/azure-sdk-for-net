#if NETCOREAPP3_0_OR_GREATER
using Microsoft.AspNetCore.Builder;
using Microsoft.Azure.WebPubSub.Common;
using Microsoft.Extensions.DependencyInjection;
using System.Threading;
using System.Threading.Tasks;

namespace Microsoft.Azure.WebPubSub.AspNetCore.Tests.Samples
{
    public class WebPubSubSample
    {
        #region Snippet:WebPubSubDependencyInjection
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddWebPubSub(o =>
            {
                o.ValidationOptions.Add("<connection-string>");
            });
        }
        #endregion

        #region Snippet:WebPubSubMapHub
        public void Configure(IApplicationBuilder app)
        {
            app.UseEndpoints(endpoint =>
            {
                endpoint.MapWebPubSubHub<SampleHub>("/eventhandler");
            });
        }
        #endregion

        private sealed class SampleHub : WebPubSubHub
        {
            #region Snippet:WebPubSubConnectMethods
            public override ValueTask<WebPubSubEventResponse> OnConnectAsync(ConnectEventRequest request, CancellationToken cancellationToken)
            {
                var response = new ConnectEventResponse
                {
                    UserId = request.ConnectionContext.UserId
                };
                return new ValueTask<WebPubSubEventResponse>(response);
            }
            #endregion

            public override ValueTask<WebPubSubEventResponse> OnMessageReceivedAsync(UserEventRequest request, CancellationToken cancellationToken)
            {
                return new ValueTask<WebPubSubEventResponse>(request.CreateResponse("ack"));
            }
        }
    }
}
#endif
