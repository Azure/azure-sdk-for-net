// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Microsoft.Azure.WebJobs;

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

            builder.AddExtension<AzureClientsExtensionConfigProvider>();

            return builder;
        }
    }
}
