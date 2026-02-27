// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Diagnostics.CodeAnalysis;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;

namespace Azure.Identity
{
    [Experimental("SCME0002")]
    internal class ConfigurableCredential : TokenCredential
    {
        private DefaultAzureCredential _tokenCredential;
        private AccessToken _apiKeyToken;

        public ConfigurableCredential()
            : this(new DefaultAzureCredentialOptions())
        {
        }

        public ConfigurableCredential(CredentialSettings settings)
            : this(new DefaultAzureCredentialOptions(settings, null))
        {
        }

        public ConfigurableCredential(DefaultAzureCredentialOptions options)
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
        public override async ValueTask<AccessToken> GetTokenAsync(TokenRequestContext requestContext, CancellationToken cancellationToken = default)
        {
            if (_tokenCredential is null)
            {
                return _apiKeyToken;
            }

            using CredentialDiagnosticScope scope = _tokenCredential.Pipeline.StartGetTokenScope("ConfigurableCredential.GetToken", requestContext);

            try
            {
                return await _tokenCredential.GetTokenAsync(requestContext, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                throw scope.FailWrapAndThrow(ex);
            }
        }

        /// <inheritdoc/>
        public override AccessToken GetToken(TokenRequestContext requestContext, CancellationToken cancellationToken = default)
        {
            if (_tokenCredential is null)
            {
                return _apiKeyToken;
            }

            using CredentialDiagnosticScope scope = _tokenCredential.Pipeline.StartGetTokenScope("ConfigurableCredential.GetToken", requestContext);

            try
            {
                return _tokenCredential.GetToken(requestContext, cancellationToken);
            }
            catch (Exception ex)
            {
                throw scope.FailWrapAndThrow(ex);
            }
        }
    }
}
