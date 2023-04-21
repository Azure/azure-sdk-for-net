// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Globalization;
using System.Net;
using Azure.Messaging.EventHubs.Consumer;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.EventHubs;
using Microsoft.Azure.WebJobs.EventHubs.Processor;
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