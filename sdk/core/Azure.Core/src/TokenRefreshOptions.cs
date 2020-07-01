// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.Core
{
    /// <summary>
    /// Options to configure access token.
    /// </summary>
    public readonly struct TokenRefreshOptions
    {
        /// <summary>
        /// Returns a <see cref="TimeSpan"/> value representing the amount of time to subtract from the token expiry time, whereupon
        /// attempts will be made to refresh the token. By default this will occur two minutes prior to the expiry of the token.
        /// </summary>
        public TimeSpan Offset { get; }

        /// <summary>
        /// Create the instance of a <see cref="TokenCredential"/>.
        /// </summary>
        public TokenRefreshOptions(TimeSpan offset)
        {
            Offset = offset;
        }
    }
}
