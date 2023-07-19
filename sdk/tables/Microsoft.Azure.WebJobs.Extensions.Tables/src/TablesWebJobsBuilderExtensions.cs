// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Tables;
using Microsoft.Extensions.Azure;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace Microsoft.Extensions.Hosting
{
    public static class TablesWebJobsBuilderExtensions
    {
        public static IWebJobsBuilder AddTables(this IWebJobsBuilder builder)
        {
            builder.Services.AddAzureClientsCore();
            builder.Services.TryAddSingleton<TablesAccountProvider>();
            builder.AddExtension<TablesExtensionConfigProvider>();
            return builder;
        }
    }
}