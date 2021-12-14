// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Tables;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace Microsoft.Extensions.Hosting
{
    public static class TablesWebJobsBuilderExtensions
    {
        public static IWebJobsBuilder AddAzureTables(this IWebJobsBuilder builder)
        {
            builder.Services.TryAddSingleton<StorageAccountProvider>();
            builder.AddExtension<TablesExtensionConfigProvider>();
            return builder;
        }
    }
}