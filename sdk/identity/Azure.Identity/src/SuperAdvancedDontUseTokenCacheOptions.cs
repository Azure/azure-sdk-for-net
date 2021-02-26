// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;

namespace Azure.Identity
{
    /// <summary>
    /// Options controlling the storage of the <see cref="TokenCache"/>.
    /// </summary>
    public class SuperAdvancedDontUseTokenCacheOptions : TokenCacheOptions
    {
        /// <summary>
        /// The delegate to be called when the Updated event fires.
        /// </summary>
        /// <value></value>
        public Func<TokenCacheUpdatedArgs, Task> UpdatedDelegate { get; set; }
    }
}
