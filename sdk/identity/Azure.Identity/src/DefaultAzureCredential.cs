// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.Pipeline;

namespace Azure.Identity
{
    /// <summary>
    /// Provides a default <see cref="TokenCredential"/> authentication flow for applications that will be deployed to Azure.  The following credential
    /// types if enabled will be tried, in order:
    /// <list type="bullet">
    /// <item><description><see cref="EnvironmentCredential"/></description></item>
    /// <item><description><see cref="ManagedIdentityCredential"/></description></item>
    /// <item><description><see cref="SharedTokenCacheCredential"/></description></item>
    /// <item><description><see cref="InteractiveBrowserCredential"/></description></item>
    /// </list>
    /// Consult the documentation of these credential types for more information on how they attempt authentication.
    /// </summary>
    /// <remarks>
    /// Note that credentials requiring user interaction, such as the <see cref="InteractiveBrowserCredential"/>, are not included by default. Callers must explicitly enable this when
    /// constructing the <see cref="DefaultAzureCredential"/> either by setting the includeInteractiveCredentials parameter to true, or the setting the
    /// <see cref="DefaultAzureCredentialOptions.ExcludeInteractiveBrowserCredential"/> property to false when passing <see cref="DefaultAzureCredentialOptions"/>.
    /// </remarks>
    public class DefaultAzureCredential : TokenCredential
    {
        private const string DefaultExceptionMessage = "DefaultAzureCredential failed to retrieve a token from the included credentials.";
        private const string UnhandledExceptionMessage = "DefaultAzureCredential authentication failed.";
        private static readonly TokenCredential[] s_defaultCredentialChain = GetDefaultAzureCredentialChain(new DefaultAzureCredentialFactory(CredentialPipeline.GetInstance(null)), new DefaultAzureCredentialOptions());

        private readonly CredentialPipeline _pipeline;

        private TokenCredential[] _sources;
        private TokenCredential _credential;

        /// <summary>
        /// Creates an instance of the DefaultAzureCredential class.
        /// </summary>
        /// <param name="includeInteractiveCredentials">Specifies whether credentials requiring user interaction will be included in the default authentication flow.</param>
        public DefaultAzureCredential(bool includeInteractiveCredentials = false)
            : this((includeInteractiveCredentials) ? new DefaultAzureCredentialOptions { ExcludeInteractiveBrowserCredential = !includeInteractiveCredentials } : null)
        {
        }

        /// <summary>
        /// Creates an instance of the <see cref="DefaultAzureCredential"/> class.
        /// </summary>
        /// <param name="options">Options that configure the management of the requests sent to Azure Active Directory services, and determine which credentials are included in the <see cref="DefaultAzureCredential"/> authentication flow.</param>
        public DefaultAzureCredential(DefaultAzureCredentialOptions options)
            : this(new DefaultAzureCredentialFactory(CredentialPipeline.GetInstance(options)), options)
        {
        }

        internal DefaultAzureCredential(DefaultAzureCredentialFactory factory, DefaultAzureCredentialOptions options)
        {
            _pipeline = factory.Pipeline;

            _sources = GetDefaultAzureCredentialChain(factory, options);
        }

        /// <summary>
        /// Sequentially calls <see cref="TokenCredential.GetToken"/> on all the included credentials in the order <see cref="EnvironmentCredential"/>, <see cref="ManagedIdentityCredential"/>, <see cref="SharedTokenCacheCredential"/>,
        /// and <see cref="InteractiveBrowserCredential"/> returning the first successfully obtained <see cref="AccessToken"/>. This method is called by Azure SDK clients. It isn't intended for use in application code.
        /// </summary>
        /// <remarks>
        /// Note that credentials requiring user interaction, such as the <see cref="InteractiveBrowserCredential"/>, are not included by default.
        /// </remarks>
        /// <param name="requestContext">The details of the authentication request.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>The first <see cref="AccessToken"/> returned by the specified sources. Any credential which raises a <see cref="CredentialUnavailableException"/> will be skipped.</returns>
        public override AccessToken GetToken(TokenRequestContext requestContext, CancellationToken cancellationToken = default)
        {
            return GetTokenImplAsync(false, requestContext, cancellationToken).EnsureCompleted();
        }

        /// <summary>
        /// Sequentially calls <see cref="TokenCredential.GetToken"/> on all the included credentials in the order <see cref="EnvironmentCredential"/>, <see cref="ManagedIdentityCredential"/>, <see cref="SharedTokenCacheCredential"/>,
        /// and <see cref="InteractiveBrowserCredential"/> returning the first successfully obtained <see cref="AccessToken"/>. This method is called by Azure SDK clients. It isn't intended for use in application code.
        /// </summary>
        /// <remarks>
        /// Note that credentials requiring user interaction, such as the <see cref="InteractiveBrowserCredential"/>, are not included by default.
        /// </remarks>
        /// <param name="requestContext">The details of the authentication request.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>The first <see cref="AccessToken"/> returned by the specified sources. Any credential which raises a <see cref="CredentialUnavailableException"/> will be skipped.</returns>
        public override async ValueTask<AccessToken> GetTokenAsync(TokenRequestContext requestContext, CancellationToken cancellationToken = default)
        {
            return await GetTokenImplAsync(true, requestContext, cancellationToken).ConfigureAwait(false);
        }

        private async ValueTask<AccessToken> GetTokenImplAsync(bool async, TokenRequestContext requestContext, CancellationToken cancellationToken)
        {
            using CredentialDiagnosticScope scope = _pipeline.StartGetTokenScope("DefaultAzureCredential.GetToken", requestContext);

            try
            {
                AccessToken token;

                if (_credential != null)
                {
                    token = async ? await _credential.GetTokenAsync(requestContext, cancellationToken).ConfigureAwait(false) : _credential.GetToken(requestContext, cancellationToken);
                }
                else
                {
                    token = await GetTokenFromSourcesAsync(async, requestContext, cancellationToken).ConfigureAwait(false);
                }

                return scope.Succeeded(token);
            }
            catch (OperationCanceledException e)
            {
                scope.Failed(e);
                throw;
            }
            catch (Exception e) when (!(e is CredentialUnavailableException))
            {
               throw scope.FailAndWrap(new AuthenticationFailedException(UnhandledExceptionMessage, e));
            }
        }

        private async ValueTask<AccessToken> GetTokenFromSourcesAsync(bool async, TokenRequestContext requestContext, CancellationToken cancellationToken)
        {

            int i;

            List<CredentialUnavailableException> exceptions = new List<CredentialUnavailableException>();

            for (i = 0; i < _sources.Length && _sources[i] != null; i++)
            {
                try
                {
                    AccessToken token = async
                        ? await _sources[i].GetTokenAsync(requestContext, cancellationToken).ConfigureAwait(false)
                        : _sources[i].GetToken(requestContext, cancellationToken);

                    _credential = _sources[i];

                    _sources = null;

                    return token;
                }
                catch (CredentialUnavailableException e)
                {
                    exceptions.Add(e);
                }
            }

            // build the credential unavailable message, this code is only reachable if all credentials throw CredentialUnavailableException
            StringBuilder errorMsg = new StringBuilder(DefaultExceptionMessage);

            foreach (Exception ex in exceptions)
            {
                errorMsg.Append(Environment.NewLine).Append(ex.Message);
            }

            throw new CredentialUnavailableException(errorMsg.ToString());
        }

        private static TokenCredential[] GetDefaultAzureCredentialChain(DefaultAzureCredentialFactory factory, DefaultAzureCredentialOptions options)
        {
            if (options is null)
            {
                return s_defaultCredentialChain;
            }

            int i = 0;
            TokenCredential[] chain = new TokenCredential[4];

            if (!options.ExcludeEnvironmentCredential)
            {
                chain[i++] = factory.CreateEnvironmentCredential();
            }

            if (!options.ExcludeManagedIdentityCredential)
            {
                chain[i++] = factory.CreateManagedIdentityCredential(options.ManagedIdentityClientId);
            }

            if (!options.ExcludeSharedTokenCacheCredential)
            {
                chain[i++] = factory.CreateSharedTokenCacheCredential(options.SharedTokenCacheTenantId, options.SharedTokenCacheUsername);
            }

            if (!options.ExcludeInteractiveBrowserCredential)
            {
                chain[i++] = factory.CreateInteractiveBrowserCredential(options.InteractiveBrowserTenantId);
            }

            if (i == 0)
            {
                throw new ArgumentException("At least one credential type must be included in the authentication flow.", nameof(options));
            }

            return chain;
        }
    }
}
