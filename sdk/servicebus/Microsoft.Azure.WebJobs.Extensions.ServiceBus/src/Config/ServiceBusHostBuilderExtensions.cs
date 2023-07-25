// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Net;
using Microsoft.Azure.WebJobs;
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
                });

            builder.Services.AddAzureClientsCore();
            builder.Services.TryAddSingleton<MessagingProvider>();
            builder.Services.AddSingleton<ServiceBusClientFactory>();
            return builder;
        }

        public static IWebJobsBuilder AddServiceBusScaleForTrigger(this IWebJobsBuilder builder, TriggerMetadata triggerMetadata)
        {
            IServiceProvider serviceProvider = null;
            Lazy<ServiceBusScalerProvider> scalerProvider = new Lazy<ServiceBusScalerProvider>(() => new ServiceBusScalerProvider(serviceProvider, triggerMetadata));

            builder.Services.AddSingleton<IScaleMonitorProvider>(resolvedServiceProvider =>
            {
                serviceProvider = serviceProvider ?? resolvedServiceProvider;
                return scalerProvider.Value;
            });

            builder.Services.AddSingleton<ITargetScalerProvider>(resolvedServiceProvider =>
            {
                serviceProvider = serviceProvider ?? resolvedServiceProvider;
                return scalerProvider.Value;
            });

            return builder;
        }
    }
}
