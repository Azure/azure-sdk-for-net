// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;

namespace Azure.Identity
{
    /// <summary>
    /// Options to configure requests made to MSAL shared token cache
    /// </summary>
    public class SharedTokenCacheCredentialOptions
    {

        /// <summary>
        /// Path to the persisted token cache
        /// </summary>
        public string CacheFilePath { get; set; } = Path.Combine(DefaultCacheDirectory, "msal.cache");

        /// <summary>
        /// Total number of retry attempts to read the shared token cache
        /// </summary>
        public int CacheAccessRetryCount { get; set; } = 100;

        /// <summary>
        /// Millisecond delay between attempts to read the persisted token cache
        /// </summary>
        public TimeSpan CacheAccessRetryDelay { get; set; } = TimeSpan.FromMilliseconds(60000 / 100);

        private static string DefaultCacheDirectory { get; } = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), ".IdentityService");

    }
}
