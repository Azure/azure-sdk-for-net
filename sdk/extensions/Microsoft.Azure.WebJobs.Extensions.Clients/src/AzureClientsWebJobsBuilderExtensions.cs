// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Azure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Primitives;

namespace Microsoft.Extensions.Hosting
{
    /// <summary>
    /// The <see cref="IWebJobsBuilder"/> extensions for Azure SDK client support.
    /// </summary>
    public static class AzureClientsWebJobsBuilderExtensions
    {
        /// <summary>
        /// Adds support for <see cref="AzureClientAttribute"/> and <see cref="IAzureClientFactory{TClient}"/> in WebJobs.
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

            builder.Services.AddAzureClientsCore();
            builder.AddExtension<AzureClientsExtensionConfigProvider>();

            return builder;
        }
    }
}
