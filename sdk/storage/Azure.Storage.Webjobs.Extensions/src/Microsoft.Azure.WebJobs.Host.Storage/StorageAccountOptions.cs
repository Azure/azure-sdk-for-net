// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Storage;
using Microsoft.Azure.WebJobs.Host.Storage;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace Microsoft.Azure.WebJobs
{

    // $$$ Validate these?  And what are their capabilities? 
    internal class StorageAccountOptionsSetup : IConfigureOptions<StorageAccountOptions>
    {
        private readonly IConfiguration _configuration;
        private readonly IDelegatingHandlerProvider _delegatingHandlerProvider;

        public StorageAccountOptionsSetup(IConfiguration configuration, IDelegatingHandlerProvider delegatingHandlerProvider)
        {
            _configuration = configuration;
            _delegatingHandlerProvider = delegatingHandlerProvider;
        }

        public void Configure(StorageAccountOptions options)
        {
            if (options.Dashboard == null)
            {
                options.Dashboard = _configuration.GetWebJobsConnectionString(ConnectionStringNames.Dashboard);
            }
            if (options.Storage == null)
            {
                options.Storage = _configuration.GetWebJobsConnectionString(ConnectionStringNames.Storage);
            }
        }
    }

    internal class StorageAccountOptions
    {
        // Property names here must match existing names. 
        public string Dashboard { get; set; }
        public string Storage { get; set; }

        /// <summary>
        /// The DelegatingHandlerProvider to be used when creating storage clients.
        /// </summary>
        public IDelegatingHandlerProvider DelegatingHandlerProvider { get; set; }

        public CloudStorageAccount GetDashboardStorageAccount()
        {
            CloudStorageAccount account;
            CloudStorageAccount.TryParse(this.Dashboard, out account);
            return account;
        }

        public CloudStorageAccount GetStorageAccount()
        {
            CloudStorageAccount account;
            CloudStorageAccount.TryParse(this.Storage, out account);
            return account;
        }
    }
}
