// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
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

            builder.AddEventHubs(p => {});

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
                    options.InvokeProcessorAfterReceiveTimeout = section.GetValue(
                        "EventProcessorOptions:InvokeProcessorAfterReceiveTimeout",
                        options.InvokeProcessorAfterReceiveTimeout);

                    options.EventProcessorOptions.TrackLastEnqueuedEventProperties = section.GetValue(
                        "EventProcessorOptions:EnableReceiverRuntimeMetric",
                        options.EventProcessorOptions.TrackLastEnqueuedEventProperties);

                    options.MaxBatchSize = section.GetValue(
                        "EventProcessorOptions:MaxBatchSize",
                        options.MaxBatchSize);

                    var receiveTimeout = section.GetValue<TimeSpan?>(
                        "EventProcessorOptions:ReceiveTimeout",
                        null);

                    if (receiveTimeout != null)
                    {
                        options.EventProcessorOptions.MaximumWaitTime = receiveTimeout.Value;
                    }

                    var leaseDuration = section.GetValue<TimeSpan?>(
                        "PartitionManagerOptions:LeaseDuration",
                        null);

                    if (leaseDuration != null)
                    {
                        options.EventProcessorOptions.PartitionOwnershipExpirationInterval = leaseDuration.Value;
                    }

                    var renewInterval = section.GetValue<TimeSpan?>(
                        "PartitionManagerOptions:RenewInterval",
                        null);

                    if (renewInterval != null)
                    {
                        options.EventProcessorOptions.LoadBalancingUpdateInterval = renewInterval.Value;
                    }
                })
                .BindOptions<EventHubOptions>();

            builder.Services.AddAzureClientsCore();
            builder.Services.AddSingleton<EventHubClientFactory>();
            builder.Services.Configure<EventHubOptions>(configure);

            return builder;
        }
    }
}
