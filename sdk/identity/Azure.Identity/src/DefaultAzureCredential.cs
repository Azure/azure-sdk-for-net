// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.Identity
{
    /// <summary>
    /// Provides a default <see cref="TokenCredential"/> authentication flow for applications that will be deployed to Azure.  The following credential
    /// types if enabled will be tried, in order:
    /// - <see cref="EnvironmentCredential"/>
    /// - <see cref="ManagedIdentityCredential"/>
    /// - <see cref="SharedTokenCacheCredential"/>
    /// - <see cref="InteractiveBrowserCredential"/>
    /// Consult the documentation of these credential types for more information on how they attempt authentication.
    /// </summary>
    public class DefaultAzureCredential : TokenCredential
    {
        private static readonly IExtendedTokenCredential[] s_defaultCredentialChain = GetDefaultAzureCredentialChain(CredentialPipeline.GetInstance(null), new DefaultAzureCredentialOptions());

        private readonly Exception[] _unavailableExceptions;
        private readonly IExtendedTokenCredential[] _sources;
        private readonly CredentialPipeline _pipeline;
        /// <summary>
        /// Creates an instance of the DefaultAzureCredential class.
        /// </summary>
        /// <param name="includeInteractiveCredentials">Specifies whether credentials requiring user interaction will be included in the default authentication flow.</param>
        public DefaultAzureCredential(bool includeInteractiveCredentials = false)
        {
            DefaultAzureCredentialOptions options = (includeInteractiveCredentials) ? new DefaultAzureCredentialOptions { ExcludeInteractiveBrowserCredential = !includeInteractiveCredentials } : null;

            _pipeline = CredentialPipeline.GetInstance(options);

            _sources = GetDefaultAzureCredentialChain(_pipeline, options);

            _unavailableExceptions = new Exception[_sources.Length];
        }

        /// <summary>
        /// Creates an instance of the <see cref="DefaultAzureCredential"/> class.
        /// </summary>
        /// <param name="options"></param>
        public DefaultAzureCredential(DefaultAzureCredentialOptions options)
        {
            _pipeline = CredentialPipeline.GetInstance(options);

            _sources = GetDefaultAzureCredentialChain(_pipeline, options);
        }

        /// <summary>
        /// Sequencially calls <see cref="TokenCredential.GetToken"/> on all the specified sources, returning the first successfully retured <see cref="AccessToken"/>.
        /// </summary>
        /// <param name="requestContext">The details of the authentication request.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>The first <see cref="AccessToken"/> returned by the specified sources. Any credential which raises a <see cref="CredentialUnavailableException"/> will be skipped.</returns>
        public override AccessToken GetToken(TokenRequestContext requestContext, CancellationToken cancellationToken)
        {
            return GetTokenAsync(false, requestContext, cancellationToken).GetAwaiter().GetResult();
        }

        /// <summary>
        /// Sequencially calls <see cref="TokenCredential.GetToken"/> on all the specified sources, returning the first successfully retured <see cref="AccessToken"/>.
        /// </summary>
        /// <param name="requestContext">The details of the authentication request.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>The first <see cref="AccessToken"/> returned by the specified sources. Any credential which raises a <see cref="CredentialUnavailableException"/> will be skipped.</returns>
        public override async ValueTask<AccessToken> GetTokenAsync(TokenRequestContext requestContext, CancellationToken cancellationToken)
        {
            return await GetTokenAsync(true, requestContext, cancellationToken).ConfigureAwait(false);
        }

        private async Task<AccessToken> GetTokenAsync(bool isAsync, TokenRequestContext requestContext, CancellationToken cancellationToken)
        {
            using CredentialDiagnosticScope scope = _pipeline.StartGetTokenScope("Azure.Identity.DefaultAcureCredential.GetToken", requestContext);

            for (int i = 0; i < _sources.Length; i++)
            {
                if (_unavailableExceptions[i] == null)
                {
                    ExtendedAccessToken exToken = isAsync ? await _sources[i].GetTokenAsync(requestContext, cancellationToken).ConfigureAwait(false) : _sources[i].GetToken(requestContext, cancellationToken);

                    if (exToken.Exception is null)
                    {
                        return scope.Succeeded(exToken.AccessToken);
                    }

                    if (exToken.Exception is CredentialUnavailableException)
                    {
                        _unavailableExceptions[i] = exToken.Exception;
                    }
                    else
                    {
                        Exception[] aggEx = new Exception[i + 1];

                        Array.Copy(_unavailableExceptions, 0, aggEx, 0, i);

                        aggEx[i] = exToken.Exception;

                        throw scope.Failed(new AggregateAuthenticationException(exToken.Exception.Message, new ReadOnlyMemory<object>(_sources, 0, i + 1), aggEx));
                    }
                }
            }

            throw scope.Failed(new AggregateAuthenticationException(Constants.AggregateAllUnavailableErrorMessage, _sources, _unavailableExceptions));
        }

        private static IExtendedTokenCredential[] GetDefaultAzureCredentialChain(CredentialPipeline pipeline, DefaultAzureCredentialOptions options)
        {
            if (options is null)
            {
                return s_defaultCredentialChain;
            }

            int i = 0;
            IExtendedTokenCredential[] chain = new IExtendedTokenCredential[4];

            if (!options.ExcludeEnvironmentCredential)
            {
                chain[i++] = new EnvironmentCredential(pipeline);
            }

            if (!options.ExcludeManagedIdentityCredential)
            {
                chain[i++] = new ManagedIdentityCredential(options.ManagedIdentityClientId, pipeline);
            }

            if (!options.ExcludeSharedTokenCacheCredential)
            {
                chain[i++] = new SharedTokenCacheCredential(options.SharedTokenCacheUsername, pipeline);
            }

            if (!options.ExcludeInteractiveBrowserCredential)
            {
                chain[i++] = new InteractiveBrowserCredential(null, Constants.DeveloperSignOnClientId, pipeline);
            }

            if (i == 0)
            {
                throw new ArgumentException("At least one credential type must be included in the authentication flow.", nameof(options));
            }

            return chain;
        }
    }
}
