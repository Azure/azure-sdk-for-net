// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Identity
{
    /// <summary>
    /// Options controlling the storage of the token cache.
    /// </summary>
    public class TokenCachePersistenceOptions
    {
        /// <summary>
        /// Name uniquely identifying the <see cref="TokenCachePersistenceOptions"/>.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// If set to true the token cache may be persisted as an unencrypted file if no OS level user encryption is available. When set to false the token cache
        /// will throw a <see cref="CredentialUnavailableException"/> in the event no OS level user encryption is available.
        /// </summary>
        public bool UnsafeAllowUnencryptedStorage { get; set; }
    }
}
