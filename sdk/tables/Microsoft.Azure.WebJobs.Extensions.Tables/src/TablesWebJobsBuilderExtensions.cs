// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Tables;
using Microsoft.Extensions.Azure;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace Microsoft.Extensions.Hosting
{
    /// <summary>
    /// Extension methods for registering the Tables extension with an <see cref="IWebJobsBuilder"/>.
    /// </summary>
    public static class TablesWebJobsBuilderExtensions
    {
        /// <summary>
        /// Adds the Tables extension to the provided <see cref="IWebJobsBuilder"/>.
        /// </summary>
        /// <param name="builder">The builder to add the extension to.</param>
        /// <returns>The <paramref name="builder"/> so that additional calls can be chained.</returns>
        public static IWebJobsBuilder AddTables(this IWebJobsBuilder builder)
        {
            builder.Services.AddAzureClientsCore();
            builder.Services.TryAddSingleton<TablesAccountProvider>();
            builder.AddExtension<TablesExtensionConfigProvider>();
            return builder;
        }
    }
}