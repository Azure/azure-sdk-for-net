// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Identity
{
    /// <summary>
    /// Data regarding an update of a token cache.
    /// </summary>
    public class TokenCacheUpdatedArgs
    {
        internal TokenCacheUpdatedArgs(byte[] cacheData)
        {
            Data = cacheData;
        }

        /// <summary>
        /// The <see cref="TokenCacheOptions"/> instance which was updated.
        /// </summary>
        public byte[] Data { get; }
    }
}
