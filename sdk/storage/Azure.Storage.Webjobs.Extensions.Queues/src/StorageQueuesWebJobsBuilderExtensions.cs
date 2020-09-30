// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Storage;
using Microsoft.Azure.WebJobs.Extensions.Storage.Common;
using Microsoft.Azure.WebJobs.Extensions.Storage.Common.Listeners;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Azure.WebJobs.Host.Listeners;
using Microsoft.Azure.WebJobs.Host.Queues;
using Microsoft.Azure.WebJobs.Host.Queues.Config;
using Microsoft.Azure.WebJobs.Host.Queues.Listeners;
using Microsoft.Azure.WebJobs.Host.Queues.Triggers;
using Microsoft.Extensions.Azure;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace Microsoft.Extensions.Hosting
{
    /// <summary>
    /// TODO.
    /// </summary>
    public static class StorageQueuesWebJobsBuilderExtensions
    {
        /// <summary>
        /// TODO.
        /// </summary>
        /// <param name="builder"></param>
        /// <param name="configureQueues"></param>
        /// <returns></returns>
        public static IWebJobsBuilder AddAzureStorageQueues(this IWebJobsBuilder builder, Action<QueuesOptions> configureQueues = null)
        {
            // add webjobs to user agent for all storage calls
            DiagnosticsOptions.DefaultApplicationId = "AzureWebJobs";

            builder.Services.AddAzureClients(_ => { });
            // $$$ Move to Host.Storage?
#pragma warning disable CS0618 // Type or member is obsolete
            // TODO (kasobol-msft) figure out if this is needed in extension and if so if it's needed in both blobs and queues?
            builder.Services.TryAddSingleton<ILoadBalancerQueue, StorageLoadBalancerQueue>();
#pragma warning restore CS0618 // Type or member is obsolete

            builder.Services.TryAddSingleton<SharedQueueWatcher>();

            // $$$ Remove this, should be done via DI // TODO (kasobol-msft) check this
            builder.Services.TryAddSingleton<ISharedContextProvider, SharedContextProvider>();

            builder.Services.TryAddSingleton<StorageAccountProvider>();
            // TODO (kasobol-msft) find replacement, related to connection pool
            //builder.Services.TryAddSingleton<IDelegatingHandlerProvider, DefaultDelegatingHandlerProvider>();

            builder.Services.TryAddSingleton<IContextSetter<IMessageEnqueuedWatcher>>((p) => new ContextAccessor<IMessageEnqueuedWatcher>());
            builder.Services.TryAddSingleton((p) => p.GetService<IContextSetter<IMessageEnqueuedWatcher>>() as IContextGetter<IMessageEnqueuedWatcher>);

            builder.Services.TryAddSingleton<QueueTriggerAttributeBindingProvider>();

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

            return builder;
        }
    }
}
