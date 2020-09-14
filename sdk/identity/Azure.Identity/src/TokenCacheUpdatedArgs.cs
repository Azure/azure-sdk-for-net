using System;
using System.Collections.Generic;
using System.Text;

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
