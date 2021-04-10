// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Globalization;
using Azure.Messaging.EventHubs.Consumer;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.EventHubs;
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

                    options.MaxBatchSize = section.GetValue(
                        "EventProcessorOptions:MaxBatchSize",
                        options.MaxBatchSize);

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
                })
                .BindOptions<EventHubOptions>();

            builder.Services.AddAzureClientsCore();
            builder.Services.AddSingleton<EventHubClientFactory>();
            builder.Services.Configure<EventHubOptions>(configure);
            builder.Services.PostConfigure<EventHubOptions>(ConfigureInitialOffsetOptions);

            return builder;
        }

        internal static void ConfigureInitialOffsetOptions(EventHubOptions options)
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
                        try
                        {
                            options.EventProcessorOptions.DefaultStartingPosition = EventPosition.FromEnqueuedTime(options.InitialOffsetOptions.EnqueuedTimeUtc.Value);
                        }
                        catch (FormatException fe)
                        {
                            string message = $"{nameof(EventHubOptions)}:{nameof(InitialOffsetOptions)}:{nameof(InitialOffsetOptions.EnqueuedTimeUtc)} is configured with an invalid format. " +
                                "Please use a format supported by DateTime.Parse().  e.g. 'yyyy-MM-ddTHH:mm:ssZ'";
                            throw new InvalidOperationException(message, fe);
                        }
                        break;
                    default:
                        throw new InvalidOperationException("An unsupported value was supplied for initialOffsetOptions.type");
                }
                // If not specified, EventProcessor's default offset will apply
            }
        }
    }
}
