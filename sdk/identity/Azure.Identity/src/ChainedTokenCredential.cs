// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.Identity
{
    public class ChainedTokenCredential : TokenCredential
    {
        private TokenCredential[] _sources;

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

        public override AccessToken GetToken(string[] scopes, CancellationToken cancellationToken = default)
        {
            AccessToken token = new AccessToken();

            for (int i = 0; i < _sources.Length && token.Token == null; i++)
            {
                token = _sources[i].GetToken(scopes, cancellationToken);
            }

            return token;
        }

        public override async Task<AccessToken> GetTokenAsync(string[] scopes, CancellationToken cancellationToken = default)
        {
            AccessToken token = new AccessToken();

            for(int i = 0; i < _sources.Length && token.Token == null; i++)
            {
                token = await _sources[i].GetTokenAsync(scopes, cancellationToken);
            }

            return token;
        }

    }
}
