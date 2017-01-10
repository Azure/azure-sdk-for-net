// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;

namespace Microsoft.Rest
{
    /// <summary>
    /// Interface to a source of access tokens.
    /// </summary>
    public interface ITokenProvider
    {
        /// <summary>
        /// Gets the authentication header with token.
        /// </summary>
        Task<AuthenticationHeaderValue> GetAuthenticationHeaderAsync(CancellationToken cancellationToken);
    }
}
