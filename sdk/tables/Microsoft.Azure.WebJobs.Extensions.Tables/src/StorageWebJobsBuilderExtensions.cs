// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Storage;
using Microsoft.Azure.WebJobs.Host.Bindings;
using Microsoft.Azure.WebJobs.Host.Bindings.StorageAccount;
using Microsoft.Azure.WebJobs.Host.Tables.Config;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
namespace Microsoft.Extensions.Hosting
{
    public static class StorageWebJobsBuilderExtensions
    {
        public static IWebJobsBuilder AddAzureStorage(this IWebJobsBuilder builder)
        {
            builder.Services.TryAddSingleton<StorageAccountProvider>();
            builder.Services.TryAddEnumerable(ServiceDescriptor.Singleton<IBindingProvider, CloudStorageAccountBindingProvider>());
            builder.AddExtension<TablesExtensionConfigProvider>();
            return builder;
        }
    }
}