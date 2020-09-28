// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Azure;
using Microsoft.Extensions.Configuration;

namespace Microsoft.Azure.WebJobs.Extensions.Storage.Common
{
    /// <summary>
    /// Abstraction to provide storage accounts from the connection names.
    /// This gets the storage account name via the binding attribute's <see cref="IConnectionProvider.Connection"/>
    /// property.
    /// If the connection is not specified on the attribute, it uses a default account.
    /// </summary>
    public class StorageAccountProvider
    {
        private readonly IConfiguration _configuration;
        private readonly AzureComponentFactory _componentFactory;

        /// <summary>
        /// TODO.
        /// </summary>
        /// <param name="configuration"></param>
        /// <param name="componentFactory"></param>
        public StorageAccountProvider(IConfiguration configuration, AzureComponentFactory componentFactory)
        {
            _configuration = configuration;
            _componentFactory = componentFactory;
        }

        /// <summary>
        /// TODO.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="resolver"></param>
        /// <returns></returns>
        public StorageAccount Get(string name, INameResolver resolver)
        {
            var resolvedName = resolver.ResolveWholeString(name);
            return this.Get(resolvedName);
        }

        /// <summary>
        /// TODO.
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public virtual StorageAccount Get(string name)
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

            if (!string.IsNullOrWhiteSpace(connectionSection.Value))
            {
                return StorageAccount.NewFromConnectionString(connectionSection.Value);
            }

            var endpoint = connectionSection["endpoint"];
            if (string.IsNullOrWhiteSpace(endpoint))
            {
                // Not found
                throw new InvalidOperationException($"Connection should have an 'endpoint' property or be a string representing a connection string.");
            }

            return new StorageAccount(new Uri(endpoint), _componentFactory.CreateCredential(connectionSection));
        }

        /// <summary>
        /// The host account is for internal storage mechanisms like load balancer queuing.
        /// </summary>
        /// <returns></returns>
        public virtual StorageAccount GetHost()
        {
            return this.Get(null);
        }
    }
}
