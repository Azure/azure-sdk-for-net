// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Azure.Messaging.ServiceBus;
using Azure.Messaging.ServiceBus.Administration;
using Microsoft.Azure.WebJobs.Extensions.Clients.Shared;
using Microsoft.Azure.WebJobs.ServiceBus;
using Microsoft.Extensions.Azure;
using Microsoft.Extensions.Configuration;
using System;
using Microsoft.Extensions.Options;
using Constants = Microsoft.Azure.WebJobs.ServiceBus.Constants;

namespace Microsoft.Azure.WebJobs.Extensions.ServiceBus.Config
{
    internal class ServiceBusClientFactory
    {
        private readonly IConfiguration _configuration;
        private readonly AzureComponentFactory _componentFactory;
        private readonly MessagingProvider _messagingProvider;
        private readonly ServiceBusOptions _options;

        public ServiceBusClientFactory(
            IConfiguration configuration,
            AzureComponentFactory componentFactory,
            MessagingProvider messagingProvider,
            AzureEventSourceLogForwarder logForwarder,
            IOptions<ServiceBusOptions> options)
        {
            _configuration = configuration;
            _componentFactory = componentFactory;
            _messagingProvider = messagingProvider;
            _options = options?.Value ?? throw new ArgumentNullException(nameof(options));
            logForwarder.Start();
        }

        internal ServiceBusClient CreateClientFromSetting(string connection)
        {
            var connectionInfo = ResolveConnectionInformation(connection);

            return connectionInfo.ConnectionString != null ? _messagingProvider.CreateClient(connectionInfo.ConnectionString, _options.ToClientOptions())
            : _messagingProvider.CreateClient(connectionInfo.FullyQualifiedNamespace, connectionInfo.Credential, _options.ToClientOptions());
        }

        internal ServiceBusAdministrationClient CreateAdministrationClient(string connection)
        {
            var connectionInfo = ResolveConnectionInformation(connection);
            if (connectionInfo.ConnectionString != null)
            {
                return new ServiceBusAdministrationClient(connectionInfo.ConnectionString);
            }
            else
            {
                return new ServiceBusAdministrationClient(connectionInfo.FullyQualifiedNamespace, connectionInfo.Credential);
            }
        }

        private ServiceBusConnectionInformation ResolveConnectionInformation(string connection)
        {
            var connectionSetting = connection ?? Constants.DefaultConnectionStringName;
            IConfigurationSection connectionSection = _configuration.GetWebJobsConnectionStringSectionServiceBus(connectionSetting);
            if (!connectionSection.Exists())
            {
                // Not found
                throw new InvalidOperationException($"Service Bus account connection string '{connectionSetting}' does not exist. " +
                                                    $"Make sure that it is a defined App Setting.");
            }

            if (!string.IsNullOrWhiteSpace(connectionSection.Value))
            {
                return new ServiceBusConnectionInformation(connectionSection.Value);
            }
            else
            {
                string fullyQualifiedNamespace = connectionSection["fullyQualifiedNamespace"];
                if (string.IsNullOrWhiteSpace(fullyQualifiedNamespace))
                {
                    // Not found
                    throw new InvalidOperationException($"Connection should have an 'fullyQualifiedNamespace' property or be a " +
                        $"string representing a connection string.");
                }

                TokenCredential credential = _componentFactory.CreateTokenCredential(connectionSection);
                return new ServiceBusConnectionInformation(fullyQualifiedNamespace, credential);
            }
        }

        private record ServiceBusConnectionInformation
        {
            public ServiceBusConnectionInformation(string connectionString)
            {
                ConnectionString = connectionString;
            }

            public ServiceBusConnectionInformation(string fullyQualifiedNamespace, TokenCredential tokenCredential)
            {
                FullyQualifiedNamespace = fullyQualifiedNamespace;
                Credential = tokenCredential;
            }

            public string ConnectionString { get; }
            public string FullyQualifiedNamespace { get; }
            public TokenCredential Credential { get; }
        }
    }
}
