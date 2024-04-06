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
    /// <item><description><see cref="WorkloadIdentityCredential"/></description></item>
    /// <item><description><see cref="ManagedIdentityCredential"/></description></item>
    /// <item><description><see cref="SharedTokenCacheCredential"/></description></item>
    /// <item><description><see cref="VisualStudioCredential"/></description></item>
    /// <item><description><see cref="VisualStudioCodeCredential"/></description></item>
    /// <item><description><see cref="AzureCliCredential"/></description></item>
    /// <item><description><see cref="AzurePowerShellCredential"/></description></item>
    /// <item><description><see cref="AzureDeveloperCliCredential"/></description></item>
    /// <item><description><see cref="InteractiveBrowserCredential"/></description></item>
    /// </list>
    /// Consult the documentation of these credential types for more information on how they attempt authentication.
    /// </summary>
    /// <remarks>
    /// Note that credentials requiring user interaction, such as the <see cref="InteractiveBrowserCredential"/>, are not included by default. Callers must explicitly enable this when
    /// constructing the <see cref="DefaultAzureCredential"/> either by setting the includeInteractiveCredentials parameter to true, or the setting the
    /// <see cref="DefaultAzureCredentialOptions.ExcludeInteractiveBrowserCredential"/> property to false when passing <see cref="DefaultAzureCredentialOptions"/>.
    /// </remarks>
    /// <example>
    /// <para>
    /// This example demonstrates authenticating the BlobClient from the Azure.Storage.Blobs client library using the DefaultAzureCredential,
    /// deployed to an Azure resource with a user assigned managed identity configured.
    /// </para>
    /// <code snippet="Snippet:UserAssignedManagedIdentity" language="csharp">
    /// // When deployed to an azure host, the default azure credential will authenticate the specified user assigned managed identity.
    ///
    /// string userAssignedClientId = &quot;&lt;your managed identity client Id&gt;&quot;;
    /// var credential = new DefaultAzureCredential(new DefaultAzureCredentialOptions { ManagedIdentityClientId = userAssignedClientId });
    ///
    /// var blobClient = new BlobClient(new Uri(&quot;https://myaccount.blob.core.windows.net/mycontainer/myblob&quot;), credential);
    /// </code>
    /// </example>
    public class DefaultAzureCredential : TokenCredential
    {
        private const string Troubleshooting = "See the troubleshooting guide for more information. https://aka.ms/azsdk/net/identity/defaultazurecredential/troubleshoot";
        private const string DefaultExceptionMessage = "DefaultAzureCredential failed to retrieve a token from the included credentials. " + Troubleshooting;
        private const string UnhandledExceptionMessage = "DefaultAzureCredential authentication failed due to an unhandled exception: ";

        private readonly CredentialPipeline _pipeline;
        private readonly AsyncLockWithValue<TokenCredential> _credentialLock;

        internal TokenCredential[] _sources;

        internal DefaultAzureCredential() : this(false) { }

        /// <summary>
        /// Creates an instance of the DefaultAzureCredential class.
        /// </summary>
        /// <param name="includeInteractiveCredentials">Specifies whether credentials requiring user interaction will be included in the default authentication flow.</param>
        public DefaultAzureCredential(bool includeInteractiveCredentials = false)
            : this(includeInteractiveCredentials ? new DefaultAzureCredentialOptions { ExcludeInteractiveBrowserCredential = false } : null)
        {
        }

        /// <summary>
        /// Creates an instance of the <see cref="DefaultAzureCredential"/> class.
        /// </summary>
        /// <param name="options">Options that configure the management of the requests sent to Microsoft Entra ID, and determine which credentials are included in the <see cref="DefaultAzureCredential"/> authentication flow.</param>
        public DefaultAzureCredential(DefaultAzureCredentialOptions options)
            // we call ValidateAuthorityHostOption to validate that we have a valid authority host before constructing the DAC chain
            // if we don't validate this up front it will end up throwing an exception out of a static initializer which obscures the error.
            : this(new DefaultAzureCredentialFactory(ValidateAuthorityHostOption(options)))
        {
        }

        internal DefaultAzureCredential(DefaultAzureCredentialFactory factory)
        {
            _pipeline = factory.Pipeline;
            _sources = factory.CreateCredentialChain();
            _credentialLock = new AsyncLockWithValue<TokenCredential>();
        }

        /// <summary>
        /// Sequentially calls <see cref="TokenCredential.GetToken"/> on all the included credentials in the order
        /// <see cref="EnvironmentCredential"/>, <see cref="ManagedIdentityCredential"/>, <see cref="SharedTokenCacheCredential"/>, and
        /// <see cref="InteractiveBrowserCredential"/> returning the first successfully obtained <see cref="AccessToken"/>. Acquired tokens
        /// are cached by the credential instance. Token lifetime and refreshing is handled automatically. Where possible, reuse credential
        /// instances to optimize cache effectiveness.
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
        /// Sequentially calls <see cref="TokenCredential.GetToken"/> on all the included credentials in the order
        /// <see cref="EnvironmentCredential"/>, <see cref="ManagedIdentityCredential"/>, <see cref="SharedTokenCacheCredential"/>, and
        /// <see cref="InteractiveBrowserCredential"/> returning the first successfully obtained <see cref="AccessToken"/>. Acquired tokens
        /// are cached by the credential instance. Token lifetime and refreshing is handled automatically. Where possible, reuse credential
        /// instances to optimize cache effectiveness.
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
            using CredentialDiagnosticScope scope = _pipeline.StartGetTokenScopeGroup("DefaultAzureCredential.GetToken", requestContext);

            try
            {
                using var asyncLock = await _credentialLock.GetLockOrValueAsync(async, cancellationToken).ConfigureAwait(false);

                AccessToken token;
                if (asyncLock.HasValue)
                {
                    token = await GetTokenFromCredentialAsync(asyncLock.Value, requestContext, async, cancellationToken).ConfigureAwait(false);
                }
                else
                {
                    TokenCredential credential;
                    (token, credential) = await GetTokenFromSourcesAsync(_sources, requestContext, async, cancellationToken).ConfigureAwait(false);
                    _sources = default;
                    asyncLock.SetValue(credential);
                    AzureIdentityEventSource.Singleton.DefaultAzureCredentialCredentialSelected(credential.GetType().FullName);
                }

                return scope.Succeeded(token);
            }
            catch (Exception e)
            {
                throw scope.FailWrapAndThrow(e);
            }
        }

        private static async ValueTask<AccessToken> GetTokenFromCredentialAsync(TokenCredential credential, TokenRequestContext requestContext, bool async, CancellationToken cancellationToken)
        {
            try
            {
                return async
                    ? await credential.GetTokenAsync(requestContext, cancellationToken).ConfigureAwait(false)
                    : credential.GetToken(requestContext, cancellationToken);
            }
            catch (Exception e) when (!(e is CredentialUnavailableException))
            {
                throw new AuthenticationFailedException(UnhandledExceptionMessage, e);
            }
        }

        private static async ValueTask<(AccessToken Token, TokenCredential Credential)> GetTokenFromSourcesAsync(TokenCredential[] sources, TokenRequestContext requestContext, bool async, CancellationToken cancellationToken)
        {
            List<CredentialUnavailableException> exceptions = new List<CredentialUnavailableException>();

            for (var i = 0; i < sources.Length && sources[i] != null; i++)
            {
                try
                {
                    AccessToken token = async
                        ? await sources[i].GetTokenAsync(requestContext, cancellationToken).ConfigureAwait(false)
                        : sources[i].GetToken(requestContext, cancellationToken);

                    return (token, sources[i]);
                }
                catch (CredentialUnavailableException e)
                {
                    exceptions.Add(e);
                }
            }

            throw CredentialUnavailableException.CreateAggregateException(DefaultExceptionMessage, exceptions);
        }

        private static DefaultAzureCredentialOptions ValidateAuthorityHostOption(DefaultAzureCredentialOptions options)
        {
            Validations.ValidateAuthorityHost(options?.AuthorityHost ?? AzureAuthorityHosts.GetDefault());

            return options;
        }
    }
}
