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
    /// Simplifies authentication while developing apps that deploy to Azure by combining credentials used in Azure
    /// hosting environments with credentials used in local development. In production, it's better to use something
    /// else. See <see href="https://aka.ms/azsdk/net/identity/credential-chains#usage-guidance-for-defaultazurecredential">Usage guidance for DefaultAzureCredential</see>.
    ///
    /// Attempts to authenticate with each of these credentials, in the following order, stopping when one provides
    /// a token:
    /// <list type="bullet">
    /// <item><description><see cref="EnvironmentCredential"/></description></item>
    /// <item><description><see cref="WorkloadIdentityCredential"/></description></item>
    /// <item><description><see cref="ManagedIdentityCredential"/></description></item>
    /// <item><description><see cref="VisualStudioCredential"/></description></item>
    /// <item><description><see cref="VisualStudioCodeCredential"/> (enabled by default for SSO with VS Code on supported platforms when Azure.Identity.Broker is installed)</description></item>
    /// <item><description><see cref="AzureCliCredential"/></description></item>
    /// <item><description><see cref="AzurePowerShellCredential"/></description></item>
    /// <item><description><see cref="AzureDeveloperCliCredential"/></description></item>
    /// <item><description><see cref="InteractiveBrowserCredential"/></description></item>
    /// <item><description>BrokerCredential (a broker-enabled instance of <see cref="InteractiveBrowserCredential"/> that requires Azure.Identity.Broker is installed)</description></item>
    /// </list>
    /// Consult the documentation of these credentials for more information on how they attempt authentication.
    /// </summary>
    /// <remarks>
    /// Note that credentials requiring user interaction, such as the <see cref="InteractiveBrowserCredential"/>, are excluded by default. Callers must explicitly enable this when
    /// constructing <see cref="DefaultAzureCredential"/> either by setting the includeInteractiveCredentials parameter to <c>true</c>, or the setting the
    /// <see cref="DefaultAzureCredentialOptions.ExcludeInteractiveBrowserCredential"/> property to <c>false</c> when passing <see cref="DefaultAzureCredentialOptions"/>.
    /// </remarks>
    /// <example>
    /// <para>
    /// This example demonstrates authenticating the BlobClient from the Azure.Storage.Blobs client library using DefaultAzureCredential,
    /// deployed to an Azure resource with a user-assigned managed identity configured.
    /// </para>
    /// <code snippet="Snippet:UserAssignedManagedIdentityWithClientId" language="csharp">
    /// // When deployed to an Azure host, DefaultAzureCredential will authenticate the specified user-assigned managed identity.
    ///
    /// string userAssignedClientId = &quot;&lt;your managed identity client ID&gt;&quot;;
    /// var credential = new DefaultAzureCredential(
    ///     new DefaultAzureCredentialOptions
    ///     {
    ///         ManagedIdentityClientId = userAssignedClientId
    ///     });
    ///
    /// var blobClient = new BlobClient(
    ///     new Uri(&quot;https://myaccount.blob.core.windows.net/mycontainer/myblob&quot;),
    ///     credential);
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

        /// <summary>
        /// The default environment variable name used for token credential configuration.
        /// </summary>
        public const string DefaultEnvironmentVariableName = "AZURE_TOKEN_CREDENTIALS";

        /// <summary>
        /// Protected constructor for <see href="https://aka.ms/azsdk/net/mocking">mocking</see>.
        /// </summary>
        protected DefaultAzureCredential() : this(false) { }

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

        /// <summary>
        /// Creates an instance of the <see cref="DefaultAzureCredential"/> class that reads credential configuration from a specified environment variable.
        /// </summary>
        /// <param name="configurationEnvironmentVariableName">The name of the environment variable to read credential configuration from. Pass <see cref="DefaultEnvironmentVariableName"/> or a custom environment variable name.</param>
        /// <param name="options">Options that configure the management of the requests sent to Microsoft Entra ID, and determine which credentials are included in the <see cref="DefaultAzureCredential"/> authentication flow.</param>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="configurationEnvironmentVariableName"/> is null.</exception>
        /// <exception cref="ArgumentException">Thrown when <paramref name="configurationEnvironmentVariableName"/> is empty.</exception>
        /// <exception cref="InvalidOperationException">Thrown when the specified environment variable is not set or contains an invalid value.</exception>
        public DefaultAzureCredential(string configurationEnvironmentVariableName, DefaultAzureCredentialOptions options = default)
            : this(new DefaultAzureCredentialFactory(ValidateAuthorityHostOption(options), configurationEnvironmentVariableName))
        {
        }

        internal DefaultAzureCredential(DefaultAzureCredentialFactory factory)
        {
            _pipeline = factory.Pipeline;
            _sources = factory.CreateCredentialChain();
            _credentialLock = new AsyncLockWithValue<TokenCredential>();
        }

        /// <summary>
        /// Sequentially calls <see cref="TokenCredential.GetToken(TokenRequestContext, CancellationToken)"/> on all the included credentials, returning the first successfully
        /// obtained <see cref="AccessToken"/>. Acquired tokens are <see href="https://aka.ms/azsdk/net/identity/token-cache">cached</see>
        /// by the credential instance. Token lifetime and refreshing is handled automatically. Where possible, <see href="https://aka.ms/azsdk/net/identity/credential-reuse">reuse credential instances</see>
        /// to optimize cache effectiveness.
        /// </summary>
        /// <remarks>
        /// Credentials requiring user interaction, such as <see cref="InteractiveBrowserCredential"/>, are excluded by default.
        /// </remarks>
        /// <param name="requestContext">The details of the authentication request.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>The first <see cref="AccessToken"/> returned by the specified sources. Any credential which raises a <see cref="CredentialUnavailableException"/> will be skipped.</returns>
        /// <exception cref="AuthenticationFailedException">Thrown when the authentication failed.</exception>
        public override AccessToken GetToken(TokenRequestContext requestContext, CancellationToken cancellationToken = default)
        {
            return GetTokenImplAsync(false, requestContext, cancellationToken).EnsureCompleted();
        }

        /// <summary>
        /// Sequentially calls <see cref="TokenCredential.GetToken(TokenRequestContext, CancellationToken)"/> on all the included credentials, returning the first successfully
        /// obtained <see cref="AccessToken"/>. Acquired tokens are <see href="https://aka.ms/azsdk/net/identity/token-cache">cached</see>
        /// by the credential instance. Token lifetime and refreshing is handled automatically. Where possible, <see href="https://aka.ms/azsdk/net/identity/credential-reuse">reuse credential instances</see>
        /// to optimize cache effectiveness.
        /// </summary>
        /// <remarks>
        /// Credentials requiring user interaction, such as <see cref="InteractiveBrowserCredential"/>, are excluded by default.
        /// </remarks>
        /// <param name="requestContext">The details of the authentication request.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>The first <see cref="AccessToken"/> returned by the specified sources. Any credential which raises a <see cref="CredentialUnavailableException"/> will be skipped.</returns>
        /// <exception cref="AuthenticationFailedException">Thrown when the authentication failed.</exception>
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
