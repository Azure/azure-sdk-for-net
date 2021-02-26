// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Identity
{
    /// <summary>
    /// Options controlling the storage of the <see cref="TokenCache"/>.
    /// </summary>
    public class TokenCacheOptions
    {
        /// <summary>
        /// Sets whether the cache should be persisted to disk. The default is false.
        /// </summary>
        public bool PersistCacheToDisk { get; set; }

        /// <summary>
        /// Name uniquely identifying the <see cref="TokenCache"/>.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// If set to true the token cache may be persisted as an unencrypted file if no OS level user encryption is available. When set to false the <see cref="TokenCache"/>
        /// will throw a <see cref="CredentialUnavailableException"/> in the event no OS level user encryption is available.
        /// </summary>
        public bool AllowUnencryptedStorage { get; set; }
    }
}
