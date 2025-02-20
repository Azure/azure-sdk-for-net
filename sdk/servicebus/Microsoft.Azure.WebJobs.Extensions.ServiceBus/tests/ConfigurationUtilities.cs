// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using Microsoft.Azure.WebJobs.Extensions.ServiceBus.Config;
using Microsoft.Extensions.Azure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging.Abstractions;
using Microsoft.Extensions.Options;
using Moq;

namespace Microsoft.Azure.WebJobs.ServiceBus.Tests
{
    public static class ConfigurationUtilities
    {
        public static IConfiguration CreateConfiguration(params KeyValuePair<string, string>[] data)
        {
            return new ConfigurationBuilder().AddInMemoryCollection(data).Build();
        }

        internal static ServiceBusClientFactory CreateFactory(IConfiguration configuration, ServiceBusOptions options, AzureComponentFactory componentFactory = null)
        {
            componentFactory ??= Mock.Of<AzureComponentFactory>();
            var loggerFactory = new NullLoggerFactory();
            var azureEventSourceLogForwarder = new AzureEventSourceLogForwarder(loggerFactory);
            return new ServiceBusClientFactory(
                configuration,
                componentFactory,
                new MessagingProvider(Options.Create(options)),
                azureEventSourceLogForwarder,
                Options.Create(options));
        }
    }
}
