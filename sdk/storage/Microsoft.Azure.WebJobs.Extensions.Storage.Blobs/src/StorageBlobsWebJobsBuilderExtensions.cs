// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.EventGrid;
using Microsoft.Azure.WebJobs.Extensions.Storage.Blobs;
using Microsoft.Azure.WebJobs.Extensions.Storage.Blobs.Config;
using Microsoft.Azure.WebJobs.Extensions.Storage.Blobs.Listeners;
using Microsoft.Azure.WebJobs.Extensions.Storage.Blobs.Triggers;
using Microsoft.Azure.WebJobs.Extensions.Storage.Common;
using Microsoft.Azure.WebJobs.Extensions.Storage.Common.Listeners;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Azure.WebJobs.Host.Scale;
using Microsoft.Extensions.Azure;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace Microsoft.Extensions.Hosting
{
    /// <summary>
    /// Extension methods for Storage Blobs integration.
    /// </summary>
    public static class StorageBlobsWebJobsBuilderExtensions
    {
        /// <summary>
        /// Adds the Storage Blobs extension to the provided <see cref="IWebJobsBuilder"/>.
        /// </summary>
        /// <param name="builder">The <see cref="IWebJobsBuilder"/> to configure.</param>
        /// <param name="configureBlobs">Optional. An action to configure <see cref="BlobsOptions"/>.</param>
        public static IWebJobsBuilder AddAzureStorageBlobs(this IWebJobsBuilder builder, Action<BlobsOptions> configureBlobs = null)
        {
            builder.Services.AddAzureClientsCore();
            // $$$ Move to Host.Storage?
#pragma warning disable CS0618 // Type or member is obsolete
            // TODO (kasobol-msft) figure out if this is needed in extension and if so if it's needed in both blobs and queues?
            builder.Services.TryAddSingleton<ILoadBalancerQueue, StorageLoadBalancerQueue>();
#pragma warning restore CS0618 // Type or member is obsolete

            builder.Services.TryAddSingleton<SharedQueueWatcher>();

            // $$$ Remove this, should be done via DI // TODO (kasobol-msft) check this
            builder.Services.TryAddSingleton<ISharedContextProvider, SharedContextProvider>();

            builder.Services.TryAddSingleton<BlobServiceClientProvider>();
            builder.Services.TryAddSingleton<QueueServiceClientProvider>();
            builder.Services.TryAddSingleton<HttpRequestProcessor>();
            builder.Services.TryAddSingleton<BlobTriggerQueueWriterFactory>();

            builder.Services.TryAddSingleton<IContextSetter<IBlobWrittenWatcher>>((p) => new ContextAccessor<IBlobWrittenWatcher>());
            builder.Services.TryAddSingleton((p) => p.GetService<IContextSetter<IBlobWrittenWatcher>>() as IContextGetter<IBlobWrittenWatcher>);

            builder.Services.TryAddSingleton<IContextSetter<IMessageEnqueuedWatcher>>((p) => new ContextAccessor<IMessageEnqueuedWatcher>());
            builder.Services.TryAddSingleton((p) => p.GetService<IContextSetter<IMessageEnqueuedWatcher>>() as IContextGetter<IMessageEnqueuedWatcher>);

            builder.Services.TryAddSingleton<BlobTriggerAttributeBindingProvider>();

            builder.AddExtension<BlobsExtensionConfigProvider>()
                .BindOptions<BlobsOptions>();
            if (configureBlobs != null)
            {
                builder.Services.Configure<BlobsOptions>(configureBlobs);
            }

            return builder;
        }

        /// <summary>
        /// Adds the Storage Queues extension to the provided <see cref="IWebJobsBuilder"/>.
        /// </summary>
        /// <param name="builder"></param>
        /// <param name="triggerMetadata">Trigger metadata.</param>
        /// <returns></returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static IWebJobsBuilder AddAzureStorageBlobsScaleForTrigger(this IWebJobsBuilder builder, TriggerMetadata triggerMetadata)
        {
            builder.Services.AddSingleton<ITargetScalerProvider>(serviceProvider =>
            {
                return new BlobTargetScalerProvider(serviceProvider, triggerMetadata);
            });

            return builder;
        }
    }
}
