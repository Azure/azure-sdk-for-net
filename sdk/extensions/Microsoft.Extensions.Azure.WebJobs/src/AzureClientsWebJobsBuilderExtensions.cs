// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Azure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Microsoft.Extensions.Hosting
{
    /// <summary>
    ///
    /// </summary>
    public static class AzureClientsWebJobsBuilderExtensions
    {
        /// <summary>
        ///
        /// </summary>
        /// <param name="builder"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static IWebJobsBuilder AddAzureClients(this IWebJobsBuilder builder)
        {
            if (builder == null)
            {
                throw new ArgumentNullException(nameof(builder));
            }

            builder.Services.AddAzureClients(builder =>
                builder.SetConfigurationRoot(provider => provider.GetRequiredService<IConfiguration>().GetWebJobsRootConfiguration()));
            builder.AddExtension<AzureClientsExtensionConfigProvider>();

            return builder;
        }
    }
}
