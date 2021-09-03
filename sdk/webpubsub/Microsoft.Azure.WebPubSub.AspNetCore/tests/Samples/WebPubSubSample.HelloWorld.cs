using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.Azure.WebPubSub.AspNetCore.Tests.Samples
{
    class WebPubSubSample
    {
        public void Configure(IApplicationBuilder app)
        {
            var wpsHandler = new WebPubSubRequestBuilder()
                .AddValidationOptions(new WebPubSubValidationOptions("<connection-string>"))
                .Build();

            app.UseEndpoints(endpoints =>
            {
                endpoints.Map("/eventhandler", async context =>
                {
                    var testHub = new SampleHub();
                    await wpsHandler.HandleRequest(context, testHub);
                });
            });
        }
    }
}
