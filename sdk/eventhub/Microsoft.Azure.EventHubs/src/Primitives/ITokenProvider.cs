// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Azure.EventHubs
{
    using System;
    using System.Threading.Tasks;

    /// <summary>
    /// Provides interface definition of a token provider.
    /// </summary>
    public interface ITokenProvider
    {
        /// <summary>
        /// Gets a <see cref="SecurityToken"/>.
        /// </summary>
        /// <param name="appliesTo">The URI which the access token applies to</param>
        /// <param name="timeout">The time span that specifies the timeout value for the message that gets the security token</param>
        /// <returns><see cref="SecurityToken"/></returns>
        Task<SecurityToken> GetTokenAsync(string appliesTo, TimeSpan timeout);
    }
}
