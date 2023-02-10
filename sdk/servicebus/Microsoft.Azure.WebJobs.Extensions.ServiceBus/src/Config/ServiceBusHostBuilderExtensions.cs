// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Net;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.ServiceBus.Config;
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

                    configure(options);
                });

            builder.Services.AddAzureClientsCore();
            builder.Services.TryAddSingleton<MessagingProvider>();
            builder.Services.AddSingleton<ServiceBusClientFactory>();
            return builder;
        }
    }
}
