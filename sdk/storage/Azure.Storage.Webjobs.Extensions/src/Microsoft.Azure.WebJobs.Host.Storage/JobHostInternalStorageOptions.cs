// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Extensions.Options;
using Microsoft.Azure.Storage.Blob;
using System;

namespace Microsoft.Azure.WebJobs
{
    /// <summary>
    /// Config object for providing a container for distributed lock manager.
    /// This is hydrated from a <see cref="JobHostInternalStorageOptions"/>
    /// </summary>
    public class DistributedLockManagerContainerProvider
    {
        public DistributedLockManagerContainerProvider() { } 
        public DistributedLockManagerContainerProvider(IOptions<JobHostInternalStorageOptions> x )
        {
            var sasBlobContainer = x.Value.InternalSasBlobContainer;
            if (sasBlobContainer != null)
            {
                var uri = new Uri(sasBlobContainer);
                this.InternalContainer = new CloudBlobContainer(uri);
            }
        }

        /// <summary>
        /// A SAS to a Blob Container. This allows services to create blob leases and do distributed locking.
        /// If this is set, <see cref="JobHostConfiguration.StorageConnectionString"/> and 
        /// <see cref="JobHostConfiguration.DashboardConnectionString"/> can be set to null and the runtime will use the container.
        /// </summary>
        public CloudBlobContainer InternalContainer { get; set; }
    }

    /// <summary>
    /// The storage configuration that the JobHost needs for its own operations (independent of binding)
    /// For example, this can support <see cref="SingletonAttribute"/>, blob leases, timers, etc. 
    /// This provides a common place to set storage that the various subsequent services can use. 
    /// </summary>
    public class JobHostInternalStorageOptions
    {
        public string InternalSasBlobContainer { get; set; }
    }
}