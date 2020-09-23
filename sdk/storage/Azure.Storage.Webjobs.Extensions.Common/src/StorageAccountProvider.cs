// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Microsoft.Azure.WebJobs.Host;
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

        /// <summary>
        /// TODO.
        /// </summary>
        /// <param name="configuration"></param>
        public StorageAccountProvider(IConfiguration configuration)
        {
            _configuration = configuration;
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
            string connectionString = _configuration.GetWebJobsConnectionString(name);
            if (connectionString == null)
            {
                // Not found
                throw new InvalidOperationException($"Storage account connection string '{IConfigurationExtensions.GetPrefixedConnectionStringName(name)}' does not exist. Make sure that it is a defined App Setting.");
            }

            return StorageAccount.NewFromConnectionString(connectionString);
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
