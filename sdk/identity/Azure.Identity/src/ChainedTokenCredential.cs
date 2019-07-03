// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.Identity
{
    /// <summary>
    /// Provides a <see cref="TokenCredential"/> implementation which chains multiple <see cref="TokenCredential"/> implementations to be tried in order 
    /// until one of the getToken methods returns a non-default <see cref="AccessToken"/>.
    /// </summary>
    public class ChainedTokenCredential : TokenCredential
    {
        private TokenCredential[] _sources;

        /// <summary>
        /// Creates an instance with the specified <see cref="TokenCredential"/> sources.
        /// </summary>
        /// <param name="sources">The ordered chain of <see cref="TokenCredential"/> implementations to tried when calling <see cref="GetToken"/> or <see cref="GetTokenAsync"/></param>
        public ChainedTokenCredential(params TokenCredential[] sources)
        {
            if (sources == null) throw new ArgumentNullException(nameof(sources));

            if (sources.Length == 0) throw new ArgumentException("sources must not be empty", nameof(sources));

            for(int i = 0; i < sources.Length; i++)
            {
                if (sources[i] == null)
                {
                    throw new ArgumentException("sources must not contain null", nameof(sources));
                }
            }

            _sources = sources;
        }

        /// <summary>
        /// Sequencially calls <see cref="TokenCredential.GetToken"/> on all the specified sources, returning the first non default <see cref="AccessToken"/>.
        /// </summary>
        /// <param name="scopes">The list of scopes for which the token will have access.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>The first non default <see cref="AccessToken"/> returned by the specified sources.  If all credentials in the chain return default a default <see cref="AccessToken"/> is returned.</returns>
        public override AccessToken GetToken(string[] scopes, CancellationToken cancellationToken = default)
        {
            AccessToken token = new AccessToken();

            for (int i = 0; i < _sources.Length && token.Token == null; i++)
            {
                token = _sources[i].GetToken(scopes, cancellationToken);
            }

            return token;
        }

        /// <summary>
        /// Sequencially calls <see cref="TokenCredential.GetTokenAsync"/> on all the specified sources, returning the first non default <see cref="AccessToken"/>.
        /// </summary>
        /// <param name="scopes">The list of scopes for which the token will have access.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>The first non default <see cref="AccessToken"/> returned by the specified sources.  If all credentials in the chain return default a default <see cref="AccessToken"/> is returned.</returns>
        public override async Task<AccessToken> GetTokenAsync(string[] scopes, CancellationToken cancellationToken = default)
        {
            AccessToken token = new AccessToken();

            for(int i = 0; i < _sources.Length && token.Token == null; i++)
            {
                token = await _sources[i].GetTokenAsync(scopes, cancellationToken).ConfigureAwait(false);
            }

            return token;
        }
    }
}
