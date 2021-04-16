// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;
using Microsoft.Extensions.Configuration;

namespace Microsoft.Azure.WebJobs.Extensions.WebPubSub
{
    public static class WebPubSubJobsBuilderExtensions
    {
        public static IWebJobsBuilder AddWebPubSub(this IWebJobsBuilder builder)
        {

            if (builder == null)
            {
                throw new ArgumentNullException(nameof(builder));
            }

            builder.AddExtension<WebPubSubConfigProvider>()
                .ConfigureOptions<WebPubSubOptions>(ApplyConfiguration);
            return builder;
        }

        private static void ApplyConfiguration(IConfiguration config, WebPubSubOptions options)
        {
            if (config == null)
            {
                return;
            }

            config.Bind(options);
        }
    }
}
