// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.AspNetCore.Builder;

namespace Microsoft.Azure.WebPubSub.AspNetCore.Tests.Samples
{
    public class WebPubSubSample
    {
        public void Configure(IApplicationBuilder app)
        {
            app.UseWebPubSub(builder =>
            {
                builder.MapHub("/eventhander", new SampleHub());
            },
            options =>
            {
                options = new WebPubSubValidationOptions("<connection-string1>", "<connection-string2");
            });
        }
    }
}
