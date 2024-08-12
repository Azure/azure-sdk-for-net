// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#if NETCOREAPP || SNIPPET
using System;
using System.Threading;
using System.Threading.Tasks;

using Azure.Identity;

using Microsoft.AspNetCore.Builder;
using Microsoft.Azure.WebPubSub.Common;
using Microsoft.Extensions.DependencyInjection;

namespace Microsoft.Azure.WebPubSub.AspNetCore.Tests.Samples
{
    public class WebPubSubSampleCreateWithAzureIdentity
    {
#region Snippet:WebPubSubDependencyInjectionWithAzureIdentity
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddWebPubSub(o =>
            {
                o.ServiceEndpoint = new WebPubSubServiceEndpoint(new Uri("<endpoint"), new DefaultAzureCredential());
            }).AddWebPubSubServiceClient<SampleHub>();
        }
#endregion

        public void Configure(IApplicationBuilder app)
        {
            app.UseEndpoints(endpoint =>
            {
                endpoint.MapWebPubSubHub<SampleHub>("/eventhandler");
            });
        }

        private sealed class SampleHub : WebPubSubHub
        {
            internal WebPubSubServiceClient<SampleHub> _serviceClient;

            // Need to ensure service client is injected by call `AddServiceHub<SampleHub>` in ConfigureServices.
            public SampleHub(WebPubSubServiceClient<SampleHub> serviceClient)
            {
                _serviceClient = serviceClient;
            }

            public override ValueTask<ConnectEventResponse> OnConnectAsync(ConnectEventRequest request, CancellationToken cancellationToken)
            {
                var response = new ConnectEventResponse
                {
                    UserId = request.ConnectionContext.UserId
                };
                return new ValueTask<ConnectEventResponse>(response);
            }
        }
    }
}
#endif