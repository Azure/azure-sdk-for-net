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

        internal virtual ServiceBusAdministrationClient CreateAdministrationClient(string connection)
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
                // A common mistake is for developers to set their `connection` to a full connection string rather
                // than an informational name.  If the value validates as a connection string, redact it to prevent
                // leaking sensitive information.
                if (IsServiceBusConnectionString(connectionSetting))
                {
                    connectionSetting =  "<< REDACTED >> (a full connection string was incorrectly used instead of a connection setting name)";
                }

                // Not found
                throw new InvalidOperationException($"Service Bus account connection string with name '{connectionSetting}' does not exist in the settings. " +
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

        private static bool IsServiceBusConnectionString(string connectionString)
        {
            try
            {
                var properties = ServiceBusConnectionStringProperties.Parse(connectionString);

                return (!string.IsNullOrEmpty(properties.FullyQualifiedNamespace))
                    || (!string.IsNullOrEmpty(properties.SharedAccessKeyName))
                    || (!string.IsNullOrEmpty(properties.SharedAccessKey))
                    || (!string.IsNullOrEmpty(properties.SharedAccessSignature))
                    || (!string.IsNullOrEmpty(properties.EntityPath));
            }
            catch
            {
                return false;
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
