// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Linq;
using System.Net;
using Azure.Messaging.EventHubs.Consumer;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.EventHubs;
using Microsoft.Azure.WebJobs.EventHubs.Listeners;
using Microsoft.Azure.WebJobs.EventHubs.Processor;
using Microsoft.Azure.WebJobs.Host.Scale;
using Microsoft.Extensions.Azure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Microsoft.Extensions.Hosting
{
    public static class EventHubWebJobsBuilderExtensions
    {
        public static IWebJobsBuilder AddEventHubs(this IWebJobsBuilder builder)
        {
            if (builder == null)
            {
                throw new ArgumentNullException(nameof(builder));
            }

            builder.AddEventHubs(p => { });
            return builder;
        }

        public static IWebJobsBuilder AddEventHubs(this IWebJobsBuilder builder, Action<EventHubOptions> configure)
        {
            if (builder == null)
            {
                throw new ArgumentNullException(nameof(builder));
            }

            if (configure == null)
            {
                throw new ArgumentNullException(nameof(configure));
            }

            builder.AddExtension<EventHubExtensionConfigProvider>()
                .ConfigureOptions<EventHubOptions>((section, options) =>
                {
                    // Map old property names for backwards compatibility
                    // do it before the binding so new property names take precedence
                    options.TrackLastEnqueuedEventProperties = section.GetValue(
                        "EventProcessorOptions:EnableReceiverRuntimeMetric",
                        options.TrackLastEnqueuedEventProperties);

                    options.MaxEventBatchSize = section.GetValue(
                        "EventProcessorOptions:MaxBatchSize",
                        options.MaxEventBatchSize);

                    options.PrefetchCount = section.GetValue(
                        "EventProcessorOptions:PrefetchCount",
                        options.PrefetchCount);

                    var leaseDuration = section.GetValue<TimeSpan?>(
                        "PartitionManagerOptions:LeaseDuration",
                        null);

                    if (leaseDuration != null)
                    {
                        options.PartitionOwnershipExpirationInterval = leaseDuration.Value;
                    }

                    var renewInterval = section.GetValue<TimeSpan?>(
                        "PartitionManagerOptions:RenewInterval",
                        null);

                    if (renewInterval != null)
                    {
                        options.LoadBalancingUpdateInterval = renewInterval.Value;
                    }

                    var proxy = section.GetValue<string>("WebProxy");
                    if (!string.IsNullOrEmpty(proxy))
                    {
                        options.WebProxy = new WebProxy(proxy);
                    }
                })
                .BindOptions<EventHubOptions>();

            builder.Services.AddAzureClientsCore();
            builder.Services.AddSingleton<EventHubClientFactory>();
            builder.Services.AddSingleton<CheckpointClientProvider>();
            builder.Services.Configure<EventHubOptions>(configure);
            builder.Services.PostConfigure<EventHubOptions>(ConfigureOptions);

            return builder;
        }

        internal static IWebJobsBuilder AddEventHubsScaleForTrigger(this IWebJobsBuilder builder, TriggerMetadata triggerMetadata)
        {
            // We need to register an instance of EventHubsScalerProvider in the DI container and then map it to the interfaces IScaleMonitorProvider and ITargetScalerProvider.
            // Since there can be more than one instance of EventHubsScalerProvider, we have to store a reference to the created instance to filter it out later.
            EventHubsScalerProvider eventHubsScalerProvider  = null;
            builder.Services.AddSingleton(serviceProvider =>
            {
                eventHubsScalerProvider  = new EventHubsScalerProvider(serviceProvider, triggerMetadata);
                return eventHubsScalerProvider ;
            });
            builder.Services.AddSingleton<IScaleMonitorProvider>(serviceProvider => serviceProvider.GetServices<EventHubsScalerProvider>().Single(x => x == eventHubsScalerProvider ));
            builder.Services.AddSingleton<ITargetScalerProvider>(serviceProvider => serviceProvider.GetServices<EventHubsScalerProvider>().Single(x => x == eventHubsScalerProvider ));

            return builder;
        }

        internal static void ConfigureOptions(EventHubOptions options)
        {
            OffsetType? type = options?.InitialOffsetOptions?.Type;
            if (type.HasValue)
            {
                switch (type)
                {
                    case OffsetType.FromStart:
                        options.EventProcessorOptions.DefaultStartingPosition = EventPosition.Earliest;
                        break;
                    case OffsetType.FromEnd:
                        options.EventProcessorOptions.DefaultStartingPosition = EventPosition.Latest;
                        break;
                    case OffsetType.FromEnqueuedTime:
                        if (!options.InitialOffsetOptions.EnqueuedTimeUtc.HasValue)
                        {
                            throw new InvalidOperationException(
                                "A time must be specified for 'enqueuedTimeUtc', when " +
                                "'initialOffsetOptions.type' is set to 'fromEnqueuedTime'.");
                        }

                        options.EventProcessorOptions.DefaultStartingPosition =
                            EventPosition.FromEnqueuedTime(options.InitialOffsetOptions.EnqueuedTimeUtc.Value);
                        break;
                    default:
                        throw new InvalidOperationException(
                            "An unsupported value was supplied for initialOffsetOptions.type");
                }
                // If not specified, EventProcessor's default offset will apply
            }

            if (options.MinEventBatchSize > options.MaxEventBatchSize)
            {
                throw new InvalidOperationException("The minimum event batch size cannot be larger than the maximum event batch size.");
            }
        }
    }
}