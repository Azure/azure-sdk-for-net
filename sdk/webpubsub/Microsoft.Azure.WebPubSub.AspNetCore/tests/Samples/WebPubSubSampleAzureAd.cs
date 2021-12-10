// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#if NETCOREAPP3_1_OR_GREATER
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.Azure.WebPubSub.Common;
using Microsoft.Extensions.DependencyInjection;

namespace Microsoft.Azure.WebPubSub.AspNetCore.Tests.Samples
{
    public class WebPubSubSampleAzureAd
    {
        #region Snippet:WebPubSubDependencyInjection
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddWebPubSub(o =>
            {
                o.AuthOptions = new WebPubSubAzureAdAuthOptions()
                {
                    Audience = "", // Empty when using default app.
                    TenantId = "", // TenantId of your app.
                    ClientIds = new string[] { "<managed identity client id>" }
                };
            });
        }
        #endregion

        #region Snippet:WebPubSubMapHub
        public void Configure(IApplicationBuilder app)
        {
            app.UseEndpoints(endpoint =>
            {
                endpoint.MapWebPubSubHub<SampleHub>("/eventhandler").UseWebPubSubAzureAdAuth();
            });
        }
        #endregion

        private sealed class SampleHub : WebPubSubHub
        {
            #region Snippet:WebPubSubConnectMethods
            public override ValueTask<ConnectEventResponse> OnConnectAsync(ConnectEventRequest request, CancellationToken cancellationToken)
            {
                var response = new ConnectEventResponse
                {
                    UserId = request.ConnectionContext.UserId
                };
                return new ValueTask<ConnectEventResponse>(response);
            }
            #endregion

            #region Snippet:WebPubSubDefaultMethods
            public override ValueTask<UserEventResponse> OnMessageReceivedAsync(UserEventRequest request, CancellationToken cancellationToken)
            {
                return base.OnMessageReceivedAsync(request, cancellationToken);
            }
            #endregion
        }
    }
}
#endif
