// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core.Credentials;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.Core.Identity
{
    public class TokenCredentialProvider : TokenCredential
    {
        private TokenCredentialProvider _next;
        private TokenCredentialProvider _first;

        protected TokenCredentialProvider()
        {

        }

        public TokenCredentialProvider(IEnumerable<TokenCredentialProvider> providers)
        {
            providers = providers ?? throw new ArgumentNullException(nameof(providers));

            TokenCredentialProvider previous = null;

            foreach (var provider in providers)
            {
                if (previous != null)
                {
                    previous._next = provider;
                }
                else
                {
                    _first = provider;
                }

                previous = provider;
            }

            if (_first == null)
            {
                throw new ArgumentException("The specified 'providers' cannot be empty.", nameof(providers));
            }
        }

        public override async ValueTask<string> GetTokenAsync(IEnumerable<string> scopes, CancellationToken cancellationToken = default)
        {
            if (_first != null)
            {
                return await _first.GetTokenAsync(scopes, cancellationToken).ConfigureAwait(false);
            }

            var cred = await GetCredentialAsync(scopes, cancellationToken).ConfigureAwait(false);

            if (cred != null)
            {
                return await cred.GetTokenAsync(scopes, cancellationToken).ConfigureAwait(false);
            }

            if (_next != null)
            {
                return await _next.GetTokenAsync(scopes, cancellationToken).ConfigureAwait(false);
            }

            throw new InvalidOperationException("No valid credentials were found, please check the supplied credential provider and your configuration.");
        }

        protected virtual async ValueTask<TokenCredential> GetCredentialAsync(IEnumerable<string> scopes, CancellationToken cancellationToken)
        {
            await Task.CompletedTask.ConfigureAwait(false);

            return null;
        }
    }
}
