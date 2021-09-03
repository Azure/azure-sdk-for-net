// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.AspNetCore.Builder;
using System.Threading.Tasks;

namespace Microsoft.Azure.WebPubSub.AspNetCore.Tests.Samples
{
    public class WebPubSubSample
    {
        public void Configure(IApplicationBuilder app)
        {
            #region Snippet:WebPubSubValidationOptions
            var wpsHandler = new WebPubSubRequestBuilder()
                .AddValidationOptions(new WebPubSubValidationOptions("<connection-string>"))
                .Build();
            #endregion

            app.UseEndpoints(endpoints =>
            {
                endpoints.Map("/eventhandler", async context =>
                {
                    var testHub = new SampleHub();
                    await wpsHandler.HandleRequest(context, testHub);
                });
            });
        }

        private sealed class SampleHub : ServiceHub
        {
            #region Snippet:WebPubSubConnectMethods
            public override Task<ServiceResponse> Connect(ConnectEventRequest request)
            {
                var response = new ConnectResponse
                {
                    UserId = request.ConnectionContext.UserId
                };
                return Task.FromResult<ServiceResponse>(response);
            }
            #endregion

            public override Task<ServiceResponse> Message(MessageEventRequest request)
            {
                var response = new MessageResponse("ack");
                return Task.FromResult<ServiceResponse>(response);
            }
        }
    }
}
