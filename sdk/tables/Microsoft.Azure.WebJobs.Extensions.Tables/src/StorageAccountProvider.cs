// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using Azure.Data.Tables;
using Microsoft.Azure.WebJobs.Extensions.Tables;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Configuration;
using TableStorageAccount = Microsoft.Azure.Cosmos.Table.CloudStorageAccount;

namespace Microsoft.Azure.WebJobs
{
    /// <summary>
    /// Abstraction to provide storage accounts from the connection names.
    /// This gets the storage account name via the binding attribute's <see cref="IConnectionProvider.Connection"/>
    /// property.
    /// If the connection is not specified on the attribute, it uses a default account.
    /// </summary>
    internal class StorageAccountProvider
    {
        private readonly IConfiguration _configuration;

        public StorageAccountProvider(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public TableServiceClient Get(string name, INameResolver resolver)
        {
            var resolvedName = resolver.ResolveWholeString(name);
            return this.Get(resolvedName);
        }

        public virtual TableServiceClient Get(string name)
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

            return new TableServiceClient(connectionString);
        }
    }
}