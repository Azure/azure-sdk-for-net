﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Net.Http;
using Azure.Core;
using Azure.Core.Pipeline;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Azure;
using Microsoft.Extensions.Configuration;
using Microsoft.Azure.WebJobs.Extensions.Clients.Shared;

namespace Microsoft.Azure.WebJobs.Extensions.Storage.Common
{
    /// <summary>
    /// Abstraction to provide storage accounts from the connection names.
    /// This gets the storage account name via the binding attribute's <see cref="IConnectionProvider.Connection"/>
    /// property.
    /// If the connection is not specified on the attribute, it uses a default account.
    /// </summary>
    internal abstract class StorageClientProvider<TClient, TClientOptions> where TClientOptions : ClientOptions
    {
        private readonly IConfiguration _configuration;
        private readonly AzureComponentFactory _componentFactory;
        private readonly AzureEventSourceLogForwarder _logForwarder;

        /// <summary>
        /// TODO.
        /// </summary>
        /// <param name="configuration"></param>
        /// <param name="componentFactory"></param>
        /// <param name="logForwarder"></param>
        public StorageClientProvider(IConfiguration configuration, AzureComponentFactory componentFactory, AzureEventSourceLogForwarder logForwarder)
        {
            _configuration = configuration;
            _componentFactory = componentFactory;
            _logForwarder = logForwarder;
        }

        /// <summary>
        /// TODO.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="resolver"></param>
        /// <returns></returns>
        public virtual TClient Get(string name, INameResolver resolver)
        {
            var resolvedName = resolver.ResolveWholeString(name);
            return this.Get(resolvedName);
        }

        /// <summary>
        /// TODO.
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public virtual TClient Get(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                name = ConnectionStringNames.Storage; // default
            }

            // $$$ Where does validation happen?
            IConfigurationSection connectionSection = _configuration.GetWebJobsConnectionStringSection(name);
            if (!connectionSection.Exists())
            {
                // Not found
                throw new InvalidOperationException($"Storage account connection string '{IConfigurationExtensions.GetPrefixedConnectionStringName(name)}' does not exist. Make sure that it is a defined App Setting.");
            }

            _logForwarder.Start();

            if (!string.IsNullOrWhiteSpace(connectionSection.Value))
            {
                return CreateClientFromConnectionString(connectionSection.Value, CreateClientOptions(null));
            }

            var endpoint = connectionSection["endpoint"];
            if (string.IsNullOrWhiteSpace(endpoint))
            {
                // Not found
                throw new InvalidOperationException($"Connection should have an 'endpoint' property or be a string representing a connection string.");
            }

            var credential = _componentFactory.CreateCredential(connectionSection);
            var endpointUri = new Uri(endpoint);
            return CreateClientFromTokenCredential(endpointUri, credential, CreateClientOptions(connectionSection));
        }

        protected abstract TClient CreateClientFromConnectionString(string connectionString, TClientOptions options);

        protected abstract TClient CreateClientFromTokenCredential(Uri endpointUri, TokenCredential tokenCredential, TClientOptions options);

        /// <summary>
        /// The host account is for internal storage mechanisms like load balancer queuing.
        /// </summary>
        /// <returns></returns>
        public virtual TClient GetHost()
        {
            return this.Get(null);
        }

        private TClientOptions CreateClientOptions(IConfiguration configuration)
        {
            var clientOptions = (TClientOptions) _componentFactory.CreateClientOptions(typeof(TClientOptions), null, configuration);
            clientOptions.Diagnostics.ApplicationId ??= "AzureWebJobs";
            if (SkuUtility.IsDynamicSku)
            {
                clientOptions.Transport = CreateTransportForDynamicSku();
            }

            return clientOptions;
        }

        private HttpPipelineTransport CreateTransportForDynamicSku()
        {
            return new HttpClientTransport(new HttpClient(new HttpClientHandler()
            {
                MaxConnectionsPerServer = 50
            }));
        }
    }
}
