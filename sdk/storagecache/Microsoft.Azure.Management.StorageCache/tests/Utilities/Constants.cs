// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Microsoft.Azure.Management.StorageCache.Tests.Utilities
{
    /// <summary>
    /// Contains constants for tests.
    /// </summary>
    public static class Constants
    {
        /// <summary>
        /// Default region for resource group.
        /// </summary>
        public const string DefaultRegion = "eastus";

        /// <summary>
        /// Default API version of storage cache client.
        /// </summary>
        public const string DefaultAPIVersion = "2021-03-01";

        /// <summary>
        /// Default prefix for resource group name.
        /// </summary>
        public const string DefaultResourcePrefix = "hpc";

        /// <summary>
        /// Default size for cache.
        /// </summary>
        public const int DefaultCacheSize = 3072;

        /// <summary>
        /// Default SKU for cache.
        /// </summary>
        public const string DefaultCacheSku = "Standard_2G";

        /// <summary>
        /// Default PrincipalId for Storage Cache Resource Provider.
        /// </summary>
        public const string StorageCacheResourceProviderPrincipalId = "831d4223-7a3c-4121-a445-1e423591e57b";

        // If you want to use existing cache then uncomment below parameters and substitue proper values.

        /// <summary>
        /// Resouce group name.
        /// </summary>
        //public static readonly string ResourceGroupName = "hpc0328x9d473995";


        /// <summary>
        /// Cache name.
        /// </summary>
        //public static readonly string CacheName = "Cache-hpc0328x9d473995";

    }
}
