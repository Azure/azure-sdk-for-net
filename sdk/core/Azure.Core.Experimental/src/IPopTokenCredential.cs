// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading;
using System.Threading.Tasks;

namespace Azure.Core
{
    /// <summary>
    ///
    /// </summary> <summary>
    ///
    /// </summary>
    public interface IPopTokenCredential
    {
        /// <summary>
        ///
        /// </summary>
        /// <param name="requestContext"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public ValueTask<AccessToken> GetTokenAsync(PopTokenRequestContext requestContext, CancellationToken cancellationToken);

        /// <summary>
        ///
        /// </summary>
        /// <param name="requestContext"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public AccessToken GetToken(PopTokenRequestContext requestContext, CancellationToken cancellationToken);
    }
}
