// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using Microsoft.Extensions.Logging;
using Microsoft.Azure.Storage.Blob;

namespace Microsoft.Azure.WebJobs.Host
{
    /// <summary>
    /// A Singleton manager service that uses a blob lease within the given container.
    /// Caller decides whether the container could come from a SAS connection string or a full storage account.
    /// Hosts can set the <see cref="IDistributedLockManager"/> service to completely replace this.
    /// </summary>
    public class CloudBlobContainerDistributedLockManager : StorageBaseDistributedLockManager
    {
        private readonly CloudBlobContainer _container;

        public CloudBlobContainerDistributedLockManager(
            CloudBlobContainer container,
            ILoggerFactory logger) : base(logger)
        {
            _container = container;
        }

        protected override CloudBlobContainer GetContainer(string accountName)
        {
            if (!string.IsNullOrWhiteSpace(accountName))
            {
                throw new InvalidOperationException("Must replace singleton lease manager to support multiple accounts");
            }
            return _container;
        }
    }
}
