// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.Pipeline;

namespace Azure.Identity
{
    /// <summary>
    /// Provides a <see cref="TokenCredential"/> implementation which chains multiple <see cref="TokenCredential"/> implementations
    /// to be tried in order until one of the GetToken methods returns a non-default <see cref="AccessToken"/>. For more information,
    /// see <see href="https://aka.ms/azsdk/net/identity/credential-chains#chainedtokencredential-overview">ChainedTokenCredential overview</see>.
    /// </summary>
    /// <example>
    /// <para>
    /// The following example demonstrates creating a credential which will attempt to authenticate using managed identity and fall
    /// back to Azure CLI for authentication if a managed identity is unavailable in the current environment.
    /// </para>
    /// <code snippet="Snippet:CustomChainedTokenCredential" language="csharp">
    /// // Authenticate using managed identity if it is available; otherwise use the Azure CLI to authenticate.
    ///
    /// var credential = new ChainedTokenCredential(new ManagedIdentityCredential(), new AzureCliCredential());
    ///
    /// var eventHubProducerClient = new EventHubProducerClient(&quot;myeventhub.eventhubs.windows.net&quot;, &quot;myhubpath&quot;, credential);
    /// </code>
    /// </example>
    public class ChainedTokenCredential : TokenCredential
    {
        private const string AggregateAllUnavailableErrorMessage = "The ChainedTokenCredential failed to retrieve a token from the included credentials.";

        private const string AuthenticationFailedErrorMessage = "The ChainedTokenCredential failed due to an unhandled exception: ";

        private readonly TokenCredential[] _sources;

        /// <summary>
        /// Protected constructor for <see href="https://aka.ms/azsdk/net/mocking">mocking</see>.
        /// </summary>
        protected ChainedTokenCredential()
        {
            _sources = Array.Empty<TokenCredential>();
        }

        /// <summary>
        /// Creates an instance with the specified <see cref="TokenCredential"/> sources.
        /// </summary>
        /// <param name="sources">The ordered chain of <see cref="TokenCredential"/> implementations to tried when calling <see cref="GetToken"/> or <see cref="GetTokenAsync"/></param>
        public ChainedTokenCredential(params TokenCredential[] sources)
        {
            if (sources is null) throw new ArgumentNullException(nameof(sources));

            if (sources.Length == 0)
            {
                throw new ArgumentException("sources must not be empty", nameof(sources));
            }

            for (int i = 0; i < sources.Length; i++)
            {
                if (sources[i] == null)
                {
                    throw new ArgumentException("sources must not contain null", nameof(sources));
                }
            }

            _sources = sources;
        }

        /// <summary>
        /// Sequentially calls <see cref="TokenCredential.GetToken(TokenRequestContext, CancellationToken)"/> on all the specified sources, returning the first successfully obtained
        /// <see cref="AccessToken"/>. Acquired tokens are <see href="https://aka.ms/azsdk/net/identity/token-cache">cached</see> by the
        /// credential instance. Token lifetime and refreshing is handled automatically. Where possible, <see href="https://aka.ms/azsdk/net/identity/credential-reuse">reuse credential instances</see>
        /// to optimize cache effectiveness.
        /// </summary>
        /// <param name="requestContext">The details of the authentication request.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>The first <see cref="AccessToken"/> returned by the specified sources. Any credential which raises a <see cref="CredentialUnavailableException"/> will be skipped.</returns>
        /// <exception cref="AuthenticationFailedException">Thrown when the authentication failed.</exception>
        public override AccessToken GetToken(TokenRequestContext requestContext, CancellationToken cancellationToken = default)
            => GetTokenImplAsync(false, requestContext, cancellationToken).EnsureCompleted();

        /// <summary>
        /// Sequentially calls <see cref="TokenCredential.GetToken(TokenRequestContext, CancellationToken)"/> on all the specified sources, returning the first successfully obtained
        /// <see cref="AccessToken"/>. Acquired tokens are <see href="https://aka.ms/azsdk/net/identity/token-cache">cached</see> by the
        /// credential instance. Token lifetime and refreshing is handled automatically. Where possible, <see href="https://aka.ms/azsdk/net/identity/credential-reuse">reuse credential instances</see>
        /// to optimize cache effectiveness.
        /// </summary>
        /// <param name="requestContext">The details of the authentication request.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>The first <see cref="AccessToken"/> returned by the specified sources. Any credential which raises a <see cref="CredentialUnavailableException"/> will be skipped.</returns>
        /// <exception cref="AuthenticationFailedException">Thrown when the authentication failed.</exception>
        public override async ValueTask<AccessToken> GetTokenAsync(TokenRequestContext requestContext, CancellationToken cancellationToken = default)
            => await GetTokenImplAsync(true, requestContext, cancellationToken).ConfigureAwait(false);

        private async ValueTask<AccessToken> GetTokenImplAsync(bool async, TokenRequestContext requestContext, CancellationToken cancellationToken)
        {
            var groupScopeHandler = new ScopeGroupHandler(default);
            try
            {
                List<CredentialUnavailableException> exceptions = new List<CredentialUnavailableException>();
                foreach (TokenCredential source in _sources)
                {
                    try
                    {
                        AccessToken token = async
                            ? await source.GetTokenAsync(requestContext, cancellationToken).ConfigureAwait(false)
                            : source.GetToken(requestContext, cancellationToken);
                        groupScopeHandler.Dispose(default, default);
                        return token;
                    }
                    catch (CredentialUnavailableException e)
                    {
                        exceptions.Add(e);
                    }
                    catch (Exception e) when (!cancellationToken.IsCancellationRequested)
                    {
                        throw new AuthenticationFailedException(AuthenticationFailedErrorMessage + e.Message, e);
                    }
                }

                throw CredentialUnavailableException.CreateAggregateException(AggregateAllUnavailableErrorMessage, exceptions);
            }
            catch (Exception exception)
            {
                groupScopeHandler.Fail(default, default, exception);
                throw;
            }
        }
    }
}
