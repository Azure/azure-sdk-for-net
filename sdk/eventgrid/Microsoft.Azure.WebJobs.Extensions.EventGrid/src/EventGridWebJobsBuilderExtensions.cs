// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace Microsoft.Azure.WebJobs.Extensions.EventGrid
{
    /// <summary>
    /// Extension methods for EventGrid integration
    /// </summary>
    public static class EventGridWebJobsBuilderExtensions
    {
        /// <summary>
        /// Adds the EventGrid extension to the provided <see cref="IWebJobsBuilder"/>.
        /// </summary>
        /// <param name="builder">The <see cref="IWebJobsBuilder"/> to configure.</param>
        public static IWebJobsBuilder AddEventGrid(this IWebJobsBuilder builder)
        {
            if (builder == null)
            {
                throw new ArgumentNullException(nameof(builder));
            }

            builder.Services.TryAddSingleton<HttpRequestProcessor>();
            builder.AddExtension<EventGridExtensionConfigProvider>();
            return builder;
        }
    }
}
