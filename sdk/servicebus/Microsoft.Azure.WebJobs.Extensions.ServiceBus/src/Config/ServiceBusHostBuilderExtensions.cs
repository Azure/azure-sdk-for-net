// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Linq;
using System.Net;
using Microsoft.Azure.WebJobs;
#if NET6_0_OR_GREATER
using Microsoft.Azure.WebJobs.Extensions.Rpc;
using Microsoft.Azure.WebJobs.Extensions.ServiceBus.Grpc;
#endif
using Microsoft.Azure.WebJobs.Extensions.ServiceBus.Config;
using Microsoft.Azure.WebJobs.Extensions.ServiceBus.Listeners;
using Microsoft.Azure.WebJobs.Host.Scale;
using Microsoft.Azure.WebJobs.ServiceBus;
using Microsoft.Azure.WebJobs.ServiceBus.Config;
using Microsoft.Extensions.Azure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace Microsoft.Extensions.Hosting
{
    public static class ServiceBusHostBuilderExtensions
    {
        public static IWebJobsBuilder AddServiceBus(this IWebJobsBuilder builder)
        {
            if (builder == null)
            {
                throw new ArgumentNullException(nameof(builder));
            }

            builder.AddServiceBus(p => { });
            return builder;
        }

        public static IWebJobsBuilder AddServiceBus(this IWebJobsBuilder builder, Action<ServiceBusOptions> configure)
        {
            if (builder == null)
            {
                throw new ArgumentNullException(nameof(builder));
            }

            if (configure == null)
            {
                throw new ArgumentNullException(nameof(configure));
            }

            builder.AddExtension<ServiceBusExtensionConfigProvider>()
                .ConfigureOptions<ServiceBusOptions>((config, path, options) =>
                {
                    IConfigurationSection section = config.GetSection(path);

                    bool? autoCompleteMessages = section.GetValue(
                        "MessageHandlerOptions:AutoComplete",
                        section.GetValue<bool?>("SessionHandlerOptions:AutoComplete"));
                    autoCompleteMessages ??= section.GetValue<bool?>("BatchOptions:AutoComplete");
                    if (autoCompleteMessages != null)
                    {
                        options.AutoCompleteMessages = autoCompleteMessages.Value;
                    }

                    options.PrefetchCount = section.GetValue(
                        "PrefetchCount",
                        options.PrefetchCount);

                    var maxAutoLockDuration = section.GetValue(
                        "MessageHandlerOptions:MaxAutoRenewDuration",
                        section.GetValue<TimeSpan?>("SessionHandlerOptions:MaxAutoRenewDuration"));

                    if (maxAutoLockDuration != null)
                    {
                        options.MaxAutoLockRenewalDuration = maxAutoLockDuration.Value;
                    }

                    options.MaxConcurrentCalls = section.GetValue(
                        "MessageHandlerOptions:MaxConcurrentCalls",
                        options.MaxConcurrentCalls);

                    options.MaxConcurrentSessions = section.GetValue(
                        "SessionHandlerOptions:MaxConcurrentSessions",
                        options.MaxConcurrentSessions);

                    options.MaxMessageBatchSize = section.GetValue(
                        "BatchOptions:MaxMessageCount",
                        options.MaxMessageBatchSize);

                    var proxy = section.GetValue<string>("WebProxy");
                    if (!string.IsNullOrEmpty(proxy))
                    {
                        options.WebProxy = new WebProxy(proxy);
                    }

                    options.SessionIdleTimeout = section.GetValue("SessionHandlerOptions:MessageWaitTime", options.SessionIdleTimeout);

                    section.Bind(options);

                    if (options.MinMessageBatchSize > options.MaxMessageBatchSize)
                    {
                        throw new InvalidOperationException("The minimum message batch size must be less than the maximum message batch size");
                    }

                    if (options.MaxBatchWaitTime > TimeSpan.FromSeconds(150))
                    {
                        throw new InvalidOperationException("This value should be no longer then 50% of the entity message lock duration, meaning the maximum allowed value is 2 minutes and 30 seconds. Otherwise, you may get lock exceptions when messages are pulled from the cache.");
                    }

                    configure(options);
                })
#if NET6_0_OR_GREATER
                .MapWorkerGrpcService<SettlementService>()
#endif
                ;

            builder.Services.AddAzureClientsCore();
            builder.Services.TryAddSingleton<MessagingProvider>();
            builder.Services.AddSingleton<CleanupService>();
            builder.Services.AddSingleton<ServiceBusClientFactory>();
            #if NET6_0_OR_GREATER
            builder.Services.AddSingleton<SettlementService>();
            #endif
            return builder;
        }

        internal static IWebJobsBuilder AddServiceBusScaleForTrigger(this IWebJobsBuilder builder, TriggerMetadata triggerMetadata)
        {
            // We need to register an instance of ServiceBusScalerProvider in the DI container and then map it to the interfaces IScaleMonitorProvider and ITargetScalerProvider.
            // Since there can be more than one instance of ServiceBusScalerProvider, we have to store a reference to the created instance to filter it out later.
            ServiceBusScalerProvider serviceBusScalerProvider = null;
            builder.Services.AddSingleton(serviceProvider => {
                serviceBusScalerProvider = new ServiceBusScalerProvider(serviceProvider, triggerMetadata);
                return serviceBusScalerProvider;
            });
            builder.Services.AddSingleton<IScaleMonitorProvider>(serviceProvider => serviceProvider.GetServices<ServiceBusScalerProvider>().Single(x => x == serviceBusScalerProvider));
            builder.Services.AddSingleton<ITargetScalerProvider>(serviceProvider => serviceProvider.GetServices<ServiceBusScalerProvider>().Single(x => x == serviceBusScalerProvider));

            return builder;
        }
    }
}
