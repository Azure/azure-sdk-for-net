// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Linq;
using System.ComponentModel;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Storage.Common;
using Microsoft.Azure.WebJobs.Extensions.Storage.Common.Listeners;
using Microsoft.Azure.WebJobs.Extensions.Storage.Queues;
using Microsoft.Azure.WebJobs.Extensions.Storage.Queues.Config;
using Microsoft.Azure.WebJobs.Extensions.Storage.Queues.Listeners;
using Microsoft.Azure.WebJobs.Extensions.Storage.Queues.Triggers;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Azure.WebJobs.Host.Queues;
using Microsoft.Azure.WebJobs.Host.Scale;
using Microsoft.Extensions.Azure;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System.Threading.Tasks;
using Azure.Core;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;

namespace Microsoft.Extensions.Hosting
{
    /// <summary>
    /// Extension methods for Storage Queues integration.
    /// </summary>
    public static class StorageQueuesWebJobsBuilderExtensions
    {
        /// <summary>
        /// Adds the Storage Queues extension to the provided <see cref="IWebJobsBuilder"/>.
        /// </summary>
        /// <param name="builder">The <see cref="IWebJobsBuilder"/> to configure.</param>
        /// <param name="configureQueues">Optional. An action to configure <see cref="QueuesOptions"/>.</param>
        public static IWebJobsBuilder AddAzureStorageQueues(this IWebJobsBuilder builder, Action<QueuesOptions> configureQueues = null)
        {
            builder.Services.AddAzureClientsCore();

            builder.Services.TryAddSingleton<SharedQueueWatcher>();

            // $$$ Remove this, should be done via DI // TODO (kasobol-msft) check this
            builder.Services.TryAddSingleton<ISharedContextProvider, SharedContextProvider>();

            builder.Services.TryAddSingleton<QueueServiceClientProvider>();
            builder.Services.TryAddSingleton<QueueCausalityManager>();

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
                    if (env.IsDevelopment() && options.MaxPollingInterval == QueuePollingIntervals.DefaultMaximum)
                    {
                        options.MaxPollingInterval = TimeSpan.FromSeconds(2);
                    }
                });

            return builder;
        }

        /// <summary>
        /// Adds the Storage Queues extension to the provided <see cref="IWebJobsBuilder"/>.
        /// </summary>
        /// <param name="builder"></param>
        /// <param name="triggerMetadata">Trigger metadata.</param>
        /// <returns></returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static IWebJobsBuilder AddAzureStorageQueuesScaleForTrigger(this IWebJobsBuilder builder, TriggerMetadata triggerMetadata)
        {
            // We need to register an instance of QueueScalerProvider in the DI container and then map it to the interfaces IScaleMonitorProvider and ITargetScalerProvider.
            // Since there can be more than one instance of QueueScalerProvider, we have to store a reference to the created instance to filter it out later.
            QueueScalerProvider queueScalerProvider = null;
            builder.Services.AddSingleton(serviceProvider =>
            {
                queueScalerProvider = new QueueScalerProvider(serviceProvider, triggerMetadata);
                return queueScalerProvider;
            });
            builder.Services.AddSingleton<IScaleMonitorProvider>(serviceProvider => serviceProvider.GetServices<QueueScalerProvider>().Single(x => x == queueScalerProvider));
            builder.Services.AddSingleton<ITargetScalerProvider>(serviceProvider => serviceProvider.GetServices<QueueScalerProvider>().Single(x => x == queueScalerProvider));

            return builder;
        }

        /// <summary>
        /// Validates access credentials for a Queue trigger during host configuration.
        /// Uses either a connection string or a managed identity / token credential with a resolved service URI.
        /// </summary>
        /// <param name="builder">The <see cref="IWebJobsBuilder"/> being configured (for fluent chaining).</param>
        /// <param name="triggerMetadata">The trigger metadata containing queue information.</param>
        /// <param name="connectionName">Logical connection setting name (e.g. "AzureWebJobsStorage").</param>
        /// <param name="tokenCredential">Optional <see cref="TokenCredential"/> for identity-based (managed identity) authentication.</param>
        /// <param name="env">Environment variables map used to resolve connection data.</param>
        /// <param name="logger">Logger used to emit validation diagnostics.</param>
        /// <returns>A task producing the same <see cref="IWebJobsBuilder"/> instance if validation succeeds.</returns>
        /// <exception cref="InvalidOperationException">Thrown when validation fails (queue not accessible or auth failure).</exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static async Task<IWebJobsBuilder> ValidateTriggerCredentialsAsync(
            this IWebJobsBuilder builder,
            TriggerMetadata triggerMetadata,
            string connectionName,
            TokenCredential tokenCredential,
            IDictionary<string, string> env,
            ILogger logger)
        {
            if (!await StorageQueueTriggerValidator.ValidateAsync(triggerMetadata, connectionName, tokenCredential, env, logger).ConfigureAwait(false))
            {
                throw new InvalidOperationException(
                    $"Storage Queue trigger validation failed for function '{triggerMetadata?.FunctionName}' (connection '{connectionName}').");
            }
            return builder;
        }
    }
}
