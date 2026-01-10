// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;

namespace Azure.Identity
{
    internal class ConfigurableCredential : TokenCredential
    {
        private TokenCredential _tokenCredential;
        private AccessToken _apiKeyToken;

        public ConfigurableCredential()
            : this(new DefaultAzureCredentialOptions())
        {
        }

        public ConfigurableCredential(CredentialSettings settings)
            : this(new DefaultAzureCredentialOptions(settings))
        {
            if (settings is null)
                throw new ArgumentNullException(nameof(settings));

            //TODO: register for changes
        }

        private ConfigurableCredential(DefaultAzureCredentialOptions options)
        {
            if (options.CredentialSource == Constants.ApiKeyCredential)
            {
                _apiKeyToken = new AccessToken(options.ApiKey, DateTimeOffset.MaxValue);
            }
            else
            {
                _tokenCredential = new DefaultAzureCredential(options);
            }
        }

        /// <inheritdoc/>
        public override ValueTask<AccessToken> GetTokenAsync(TokenRequestContext requestContext, CancellationToken cancellationToken)
        {
            if (_tokenCredential is null)
            {
#if NETSTANDARD2_0
                return new ValueTask<AccessToken>(_apiKeyToken);
#else
                return ValueTask.FromResult(_apiKeyToken);
#endif
            }
            else
            {
                return _tokenCredential.GetTokenAsync(requestContext, cancellationToken);
            }
        }

        /// <inheritdoc/>
        public override AccessToken GetToken(TokenRequestContext requestContext, CancellationToken cancellationToken)
            => _tokenCredential is null ? _apiKeyToken : _tokenCredential.GetToken(requestContext, cancellationToken);
    }
}
