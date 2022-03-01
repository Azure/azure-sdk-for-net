// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Microsoft.Extensions.Azure;
using Microsoft.Extensions.DependencyInjection;

namespace Microsoft.Azure.WebJobs.Extensions.SignalRService
{
    // Then all resolve jobs are put in resolvers, we can also remove the SignalROption after we apply resolve jobs inside bindings.

    /// <summary>
    /// Extension methods for SignalR Service integration
    /// </summary>
    public static class SignalRWebJobsBuilderExtensions
    {
        /// <summary>
        /// Adds the SignalR extension to the provided <see cref="IWebJobsBuilder"/>.
        /// </summary>
        /// <param name="builder">The <see cref="IWebJobsBuilder"/> to configure.</param>
        public static IWebJobsBuilder AddSignalR(this IWebJobsBuilder builder)
        {
            if (builder == null)
            {
                throw new ArgumentNullException(nameof(builder));
            }

            builder.AddExtension<SignalRConfigProvider>();
            builder.Services
                .AddSingleton<IServiceManagerStore, ServiceManagerStore>()
                .AddAzureClientsCore();
            return builder;
        }
    }
}