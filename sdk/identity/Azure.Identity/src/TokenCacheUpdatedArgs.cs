// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Identity
{
    /// <summary>
    /// Data regarding an update of a <see cref="TokenCache"/>.
    /// </summary>
    public class TokenCacheUpdatedArgs
    {
        internal TokenCacheUpdatedArgs(TokenCache cache)
        {
            Cache = cache;
        }

        /// <summary>
        /// The <see cref="TokenCache"/> instance which was updated.
        /// </summary>
        public TokenCache Cache { get; }
    }
}
