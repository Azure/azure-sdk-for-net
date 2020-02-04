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
    public class DeveloperCredential : TokenCredential, IExtendedTokenCredential
    {
        private TokenCredential _selected = null;

        private DeveloperSignOnSources _sources;
        private CredentialPipeline _pipeline;

        /// <summary>
        /// Creates a new <see cref="DeveloperCredential"/> instance with the specified sources.
        /// </summary>
        /// <param name="sources">The sources the <see cref="DeveloperCredential"/> can use to obtain authentication tokens.</param>
        /// <param name="options">The configuration options for the <see cref="DeveloperCredential"/>.</param>
        public DeveloperCredential(DeveloperSignOnSources sources, DeveloperCredentialOptions options = default)
            : this(sources, CredentialPipeline.GetInstance(options))
        {

        }

        internal DeveloperCredential(DeveloperSignOnSources sources, CredentialPipeline pipeline)
        {
            _pipeline = pipeline;
            _sources = sources;
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

        ExtendedAccessToken IExtendedTokenCredential.GetToken(TokenRequestContext requestContext, CancellationToken cancellationToken)
        {
            try
            {
                return new ExtendedAccessToken(GetToken(requestContext, cancellationToken));
            }
            catch (Exception e)
            {
                return new ExtendedAccessToken(e);
            }
        }

        async ValueTask<ExtendedAccessToken> IExtendedTokenCredential.GetTokenAsync(TokenRequestContext requestContext, CancellationToken cancellationToken)
        {
            try
            {
                return new ExtendedAccessToken(await GetTokenAsync(requestContext, cancellationToken).ConfigureAwait(false));
            }
            catch (Exception e)
            {
                return new ExtendedAccessToken(e);
            }
        }

        private IEnumerable<TokenCredential> Sources
        {
            get
            {
                if ((_sources & DeveloperSignOnSources.AzureCli) != 0)
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
                    return await GetTokenFromCredentialAsync(isAsync, _selected, requestContext, cancellationToken);
                }

                List<Exception> unavailableInner = new List<Exception>(); //new AggregateException("One or more developer sign on sources were unavailable.");

                foreach (TokenCredential source in Sources)
                {
                    try
                    {
                        AccessToken token = await GetTokenFromCredentialAsync(isAsync, source, requestContext, cancellationToken);

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
            return isAsync ? credential.GetToken(requestContext, cancellationToken) : await credential.GetTokenAsync(requestContext, cancellationToken).ConfigureAwait(false);
        }
    }
}
