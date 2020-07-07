// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using Microsoft.Azure.Storage;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Storage;
using Microsoft.Azure.WebJobs.Extensions.Storage.Blobs.Triggers;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Azure.WebJobs.Host.Bindings;
using Microsoft.Azure.WebJobs.Host.Bindings.StorageAccount;
using Microsoft.Azure.WebJobs.Host.Blobs;
using Microsoft.Azure.WebJobs.Host.Blobs.Bindings;
using Microsoft.Azure.WebJobs.Host.Listeners;
using Microsoft.Azure.WebJobs.Host.Queues;
using Microsoft.Azure.WebJobs.Host.Queues.Config;
using Microsoft.Azure.WebJobs.Host.Queues.Listeners;
using Microsoft.Azure.WebJobs.Host.Queues.Triggers;
using Microsoft.Azure.WebJobs.Host.Tables.Config;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using WebJobs.Extensions.Storage;

namespace Microsoft.Extensions.Hosting
{
    public static class StorageWebJobsBuilderExtensions
    {
        public static IWebJobsBuilder AddAzureStorage(this IWebJobsBuilder builder, Action<QueuesOptions> configureQueues = null, Action<BlobsOptions> configureBlobs = null)
        {
            // add webjobs to user agent for all storage calls
            OperationContext.GlobalSendingRequest += (sender, e) =>
            {
                // TODO: FACAVAL - This is not supported on by the latest version of the
                // storage SDK. Need to re-add this when the capability is reintroduced.
                // e.UserAgent += " AzureWebJobs";
            };

            // $$$ Move to Host.Storage? 
            builder.Services.TryAddSingleton<ILoadBalancerQueue, StorageLoadBalancerQueue>();

            builder.Services.TryAddSingleton<SharedQueueWatcher>();

            // $$$ Remove this, should be done via DI 
            builder.Services.TryAddSingleton<ISharedContextProvider, SharedContextProvider>();

            builder.Services.TryAddSingleton<StorageAccountProvider>();
            builder.Services.TryAddSingleton<IDelegatingHandlerProvider, DefaultDelegatingHandlerProvider>();

            builder.Services.TryAddSingleton<IContextSetter<IBlobWrittenWatcher>>((p) => new ContextAccessor<IBlobWrittenWatcher>());
            builder.Services.TryAddSingleton((p) => p.GetService<IContextSetter<IBlobWrittenWatcher>>() as IContextGetter<IBlobWrittenWatcher>);

            builder.Services.TryAddSingleton<IContextSetter<IMessageEnqueuedWatcher>>((p) => new ContextAccessor<IMessageEnqueuedWatcher>());
            builder.Services.TryAddSingleton((p) => p.GetService<IContextSetter<IMessageEnqueuedWatcher>>() as IContextGetter<IMessageEnqueuedWatcher>);

            builder.Services.TryAddSingleton<BlobTriggerAttributeBindingProvider>();

            builder.Services.TryAddSingleton<QueueTriggerAttributeBindingProvider>();

            builder.Services.TryAddEnumerable(ServiceDescriptor.Singleton<IBindingProvider, CloudStorageAccountBindingProvider>());

            builder.AddExtension<TablesExtensionConfigProvider>();

            builder.AddExtension<QueuesExtensionConfigProvider>()
                .BindOptions<QueuesOptions>();
            if (configureQueues != null)
            {
                builder.Services.Configure<QueuesOptions>(configureQueues);
            }

            builder.Services.TryAddSingleton<IQueueProcessorFactory, DefaultQueueProcessorFactory>();

            builder.Services.AddOptions<QueuesOptions>()
                .Configure<IHostingEnvironment>((options, env) =>
                {
                    if (env.IsDevelopment())
                    {
                        options.MaxPollingInterval = TimeSpan.FromSeconds(2);
                    }
                });

            builder.AddExtension<BlobsExtensionConfigProvider>()
                .BindOptions<BlobsOptions>();
            if (configureBlobs != null)
            {
                builder.Services.Configure<BlobsOptions>(configureBlobs);
            }

            return builder;
        }
    }
}
