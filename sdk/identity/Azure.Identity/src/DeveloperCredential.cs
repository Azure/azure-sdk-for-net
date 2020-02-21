// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;

namespace Azure.Identity
{
    /// <summary>
    /// A <see cref="TokenCredential"/> implementation to be used in a development environment capable of authenticating through various <see cref="DeveloperSignOnSources"/>.
    /// </summary>
    public class DeveloperCredential : TokenCredential
    {
        private TokenCredential _selected = null;

        private DeveloperSignOnSources _excludedSources;
        private CredentialPipeline _pipeline;

        /// <summary>
        /// Creates a new <see cref="DeveloperCredential"/> instance with the specified sources.
        /// </summary>
        /// <param name="options">The configuration options for the <see cref="DeveloperCredential"/>.</param>
        public DeveloperCredential(DeveloperCredentialOptions options = default)
            : this(options, CredentialPipeline.GetInstance(options))
        {

        }

        internal DeveloperCredential(DeveloperCredentialOptions options, CredentialPipeline pipeline)
        {
            _pipeline = pipeline;
            _excludedSources = options?.ExcludedSources ?? 0;
        }

        /// <summary>
        /// Acquires an <see cref="AccessToken"/> from the first available source of the specified <see cref="DeveloperSignOnSources"/>.
        /// </summary>\
        /// <param name="requestContext">The details of the authentication request.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>The first <see cref="AccessToken"/> returned by the specified sources.</returns>
        public override AccessToken GetToken(TokenRequestContext requestContext, CancellationToken cancellationToken = default)
        {
            return GetTokenImplAsync(false, requestContext, cancellationToken).GetAwaiter().GetResult();
        }

        /// <summary>
        /// Acquires an <see cref="AccessToken"/> from the first available source of the specified <see cref="DeveloperSignOnSources"/>.
        /// </summary>\
        /// <param name="requestContext">The details of the authentication request.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>The first <see cref="AccessToken"/> returned by the specified sources.</returns>
        public async override ValueTask<AccessToken> GetTokenAsync(TokenRequestContext requestContext, CancellationToken cancellationToken = default)
        {
            return await GetTokenImplAsync(true, requestContext, cancellationToken).ConfigureAwait(false);
        }

        private IEnumerable<TokenCredential> Sources
        {
            get
            {
                if ((_excludedSources & DeveloperSignOnSources.AzureCli) == 0)
                {
                    yield return new AzureCliCredential();
                }
            }
        }

        private async ValueTask<AccessToken> GetTokenImplAsync(bool isAsync, TokenRequestContext requestContext, CancellationToken cancellationToken)
        {
            using CredentialDiagnosticScope scope = _pipeline.StartGetTokenScope("Azure.Identity.DeveloperCredential.GetToken", requestContext);

            try
            {
                if (_selected != null)
                {
                    return await GetTokenFromCredentialAsync(isAsync, _selected, requestContext, cancellationToken).ConfigureAwait(false);
                }

                List<Exception> unavailableInner = new List<Exception>(); //new AggregateException("One or more developer sign on sources were unavailable.");

                foreach (TokenCredential source in Sources)
                {
                    try
                    {
                        AccessToken token = await GetTokenFromCredentialAsync(isAsync, source, requestContext, cancellationToken).ConfigureAwait(false);

                        _selected = source;

                        return scope.Succeeded(token);
                    }
                    catch (CredentialUnavailableException e)
                    {
                        unavailableInner.Add(e);
                    }
                }

                var inner = unavailableInner.Count > 0 ? new AggregateException("One or more developer sign on sources were unavailable.", unavailableInner) : null;

                throw new CredentialUnavailableException("The DeveloperCredential failed to retrieve a token from the included sources.", inner);
            }
            catch (OperationCanceledException e)
            {
                scope.Failed(e);

                throw;
            }
            catch (Exception e)
            {
                throw scope.Failed(e);
            }
        }

        private static async ValueTask<AccessToken> GetTokenFromCredentialAsync(bool isAsync, TokenCredential credential, TokenRequestContext requestContext, CancellationToken cancellationToken)
        {
            return isAsync ? await credential.GetTokenAsync(requestContext, cancellationToken).ConfigureAwait(false) : credential.GetToken(requestContext, cancellationToken);
        }
    }
}
