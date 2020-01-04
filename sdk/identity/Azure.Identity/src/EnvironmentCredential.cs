// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.Identity
{
    /// <summary>
    /// Enables authentication to Azure Active Directory using client secret, username and password, or SDK auth file.
    /// details configured in the following environment variables:
    /// <list type="table">
    /// <listheader><term>Variable</term><description>Description</description></listheader>
    /// <item><term>AZURE_TENANT_ID</term><description>The Azure Active Directory tenant(directory) ID.</description></item>
    /// <item><term>AZURE_CLIENT_ID</term><description>The client(application) ID of an App Registration in the tenant.</description></item>
    /// <item><term>AZURE_CLIENT_SECRET</term><description>A client secret that was generated for the App Registration.</description></item>
    /// <item><term>AZURE_USERNAME</term><description>The username, also known as upn, of an Azure Active Directory user account.</description></item>
    /// <item><term>AZURE_PASSWORD</term><description>The password of the Azure Active Directory user account. Note this does not support accounts with MFA enabled.</description></item>
    /// <item><term>AZURE_AUTH_LOCATION</term><description>The location of a JSON file which contains authentication information. This can be generated with the Azure CLI using the <code>--sdk-auth</code> flag.</description></item>
    /// </list>
    /// This credential ultimately uses a <see cref="ClientSecretCredential"/> or <see cref="UsernamePasswordCredential"/> to
    /// perform the authentication using these details. Please consult the
    /// documentation of that class for more details.
    /// </summary>
    public class EnvironmentCredential : TokenCredential, IExtendedTokenCredential
    {
        private readonly CredentialPipeline _pipeline;

        // These three member fields are initialized by EnsureInitialized. We cannot initalize them when the credential
        // is constructed because in the case of an authorization file, we need to do I/O to read the file, so they are
        // initialized on the first call to GetToken() or GetTokenAsync() which calls EnsureInitialized.
        private TokenCredential _credential;
        private string _unavailableErrorMessage;
        private Exception _unavailableException;

        /// <summary>
        /// Creates an instance of the EnvironmentCredential class and reads client secret details from environment variables.
        /// </summary>
        public EnvironmentCredential()
            : this(CredentialPipeline.GetInstance(null))
        {
        }

        /// <summary>
        /// Creates an instance of the EnvironmentCredential class and reads client secret details from environment variables.
        /// </summary>
        /// <param name="options">Options that allow to configure the management of the requests sent to the Azure Active Directory service.</param>
        public EnvironmentCredential(TokenCredentialOptions options)
            : this(CredentialPipeline.GetInstance(options))
        {
        }

        internal EnvironmentCredential(CredentialPipeline pipeline)
        {
            _pipeline = pipeline;
        }

        internal EnvironmentCredential(CredentialPipeline pipeline, TokenCredential credential, string unavailableErrorMessage)
        {
            _pipeline = pipeline;
            _credential = credential;
            _unavailableErrorMessage = unavailableErrorMessage;
        }

        /// <summary>
        /// Obtains a token from the Azure Active Directory service, using the specified client details specified in the environment variables.
        /// This method is called by Azure SDK clients. It isn't intended for use in application code.
        /// </summary>
        /// <remarks>
        /// If the environment variables are not configured correctly, a <see cref="CredentialUnavailableException"/> exception is thrown.
        /// </remarks>
        /// <param name="requestContext">The details of the authentication request.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>An <see cref="AccessToken"/> which can be used to authenticate service client calls.</returns>
        public override AccessToken GetToken(TokenRequestContext requestContext, CancellationToken cancellationToken = default)
        {
            return GetTokenImpl(requestContext, cancellationToken).GetTokenOrThrow();
        }

        /// <summary>
        /// Obtains a token from the Azure Active Directory service, using the specified client details specified in the environment variables.
        /// This method is called by Azure SDK clients. It isn't intended for use in application code.
        /// </summary>
        /// <remarks>
        /// If the environment variables are not configured correctly, a <see cref="CredentialUnavailableException"/> exception is thrown.
        /// </remarks>
        /// <param name="requestContext">The details of the authentication request.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>An <see cref="AccessToken"/> which can be used to authenticate service client calls, or a default <see cref="AccessToken"/>.</returns>
        public override async ValueTask<AccessToken> GetTokenAsync(TokenRequestContext requestContext, CancellationToken cancellationToken = default)
        {
            return (await GetTokenImplAsync(requestContext, cancellationToken).ConfigureAwait(false)).GetTokenOrThrow();
        }

        ExtendedAccessToken IExtendedTokenCredential.GetToken(TokenRequestContext requestContext, CancellationToken cancellationToken)
        {
            return GetTokenImpl(requestContext, cancellationToken);
        }

        async ValueTask<ExtendedAccessToken> IExtendedTokenCredential.GetTokenAsync(TokenRequestContext requestContext, CancellationToken cancellationToken)
        {
            return await GetTokenImplAsync(requestContext, cancellationToken).ConfigureAwait(false);
        }

        private ExtendedAccessToken GetTokenImpl(TokenRequestContext requestContext, CancellationToken cancellationToken)
        {
            using CredentialDiagnosticScope scope = _pipeline.StartGetTokenScope("Azure.Identity.EnvironmentCredential.GetToken", requestContext);

            EnsureInitialized(false, cancellationToken).GetAwaiter().GetResult();

            if (_credential is null)
            {
                return new ExtendedAccessToken(scope.Failed(new CredentialUnavailableException(_unavailableErrorMessage, _unavailableException)));
            }

            try
            {
                AccessToken token =  _credential.GetToken(requestContext, cancellationToken);

                return new ExtendedAccessToken(scope.Succeeded(token));
            }
            catch (OperationCanceledException e)
            {
                scope.Failed(e);

                throw;
            }
            catch (Exception e)
            {
                return new ExtendedAccessToken(scope.Failed(e));
            }
        }

        private async ValueTask<ExtendedAccessToken> GetTokenImplAsync(TokenRequestContext requestContext, CancellationToken cancellationToken)
        {
            using CredentialDiagnosticScope scope = _pipeline.StartGetTokenScope("Azure.Identity.EnvironmentCredential.GetToken", requestContext);

            await EnsureInitialized(true, cancellationToken).ConfigureAwait(false);

            if (_credential is null)
            {
                return new ExtendedAccessToken(scope.Failed(new CredentialUnavailableException(_unavailableErrorMessage, _unavailableException)));
            }

            try
            {
                AccessToken token = await _credential.GetTokenAsync(requestContext, cancellationToken).ConfigureAwait(false);

                return new ExtendedAccessToken(scope.Succeeded(token));
            }
            catch (OperationCanceledException e)
            {
                scope.Failed(e);

                throw;
            }
            catch (Exception e)
            {
                return new ExtendedAccessToken(scope.Failed(e));
            }
        }

        /// <summary>
        /// EnsureInitialized intializes this credential based on the current configured environment variables. It should be called before accessing
        /// the _credential, _unavailableErrorMessage or _unavailableException files. After returning, either _credential or _unavailableErrorMessage
        /// will non null.
        /// </summary>
        /// <remarks>
        /// AZURE_AUTH_LOCATION has a lower precedence than the other AZURE_* environment variaibles. When a complete set of these variaibles are set
        /// (i.e. AZURE_TENANT_ID, AZURE_CLIENT_ID and either AZURE_CLIENT_SECRET or AZURE_USERNAME and AZURE_PASSWORD) they are prefered even if
        /// AZURE_AUTH_LOCATON is set.
        /// </remarks>
        /// <param name="isAsync">When true, this method may complete asynchronously.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling cancelation.</param>
        /// <returns></returns>
        private async ValueTask EnsureInitialized(bool isAsync, CancellationToken cancellationToken)
        {
            // If we've already tried to initalize the credential and failed, don't try again.
            if (_unavailableErrorMessage != null)
            {
                return;
            }

            string tenantId = EnvironmentVariables.TenantId;
            string clientId = EnvironmentVariables.ClientId;
            string clientSecret = EnvironmentVariables.ClientSecret;
            string username = EnvironmentVariables.Username;
            string password = EnvironmentVariables.Password;
            string sdkAuthLocation = EnvironmentVariables.SdkAuthLocation;

            if (tenantId != null && clientId != null && ((username != null && password != null) || clientSecret != null))
            {
                if (clientSecret != null)
                {
                    _credential = new ClientSecretCredential(tenantId, clientId, clientSecret, _pipeline);
                }
                else
                {
                    _credential = new UsernamePasswordCredential(username, password, clientId, tenantId, _pipeline);
                }
            }
            else if (sdkAuthLocation != null)
            {
                try
                {
                    _credential = BuildCredentialForCredentialsFile(isAsync ? await ParseCredentialsFileAsync(sdkAuthLocation, cancellationToken).ConfigureAwait(false) : ParseCredentialsFile(sdkAuthLocation));
                }
                catch (Exception e) when (!(e is OperationCanceledException))
                {
                    _unavailableErrorMessage = "Error parsing Azure SDK auth file";
                    _unavailableException = e;
                }
            }
            else
            {
                StringBuilder builder = new StringBuilder("Environment variables not fully configured. AZURE_TENANT_ID and AZURE_CLIENT_ID must be set, along with either AZURE_CLIENT_SECRET or AZURE_USERNAME and AZURE_PASSWORD. Alternately, AZURE_AUTH_LOCATION may be used to specify the location of a Azure SDK Auth file.  Currently set variables [");

                if (tenantId != null)
                {
                    builder.Append(" AZURE_TENANT_ID");
                }

                if (clientId != null)
                {
                    builder.Append(" AZURE_CLIENT_ID");
                }

                if (clientSecret != null)
                {
                    builder.Append(" AZURE_CLIENT_SECRET");
                }

                if (username != null)
                {
                    builder.Append(" AZURE_USERNAME");
                }

                if (password != null)
                {
                    builder.Append(" AZURE_PASSWORD");
                }

                if (sdkAuthLocation != null)
                {
                    builder.Append(" AZURE_AUTH_LOCATION");
                }

                _unavailableErrorMessage = builder.Append(" ]").ToString();
            }
        }

        private static Dictionary<string, string> ParseCredentialsFile(string filePath)
        {
            return JsonSerializer.Deserialize<Dictionary<string, string>>(File.ReadAllText(filePath));
        }

        private static async Task<Dictionary<string, string>> ParseCredentialsFileAsync(string filePath, CancellationToken cancellationToken)
        {
            using Stream s = File.OpenRead(filePath);
            return await JsonSerializer.DeserializeAsync<Dictionary<string, string>>(s, null, cancellationToken);
        }

        private TokenCredential BuildCredentialForCredentialsFile(Dictionary<string, string> authData)
        {
            authData.TryGetValue("clientId", out string clientId);
            authData.TryGetValue("clientSecret", out string clientSecret);
            authData.TryGetValue("tenantId", out string tenantId);
            authData.TryGetValue("activeDirectoryEndpointUrl", out string activeDirectoryEndpointUrl);

            if (clientId == null || clientSecret == null || tenantId == null || activeDirectoryEndpointUrl == null)
            {
                StringBuilder builder = new StringBuilder("Malformed Azure SDK Auth file. The file should contain 'clientId', 'clientSecret', 'tenentId' and 'activeDirectoryEndpointUrl' values. Currently set values [");

                if (clientId != null)
                {
                    builder.Append(" clientId");
                }

                if (clientSecret != null)
                {
                    builder.Append(" clientSecret");
                }

                if (tenantId != null)
                {
                    builder.Append(" tenantId");
                }

                if (tenantId != null)
                {
                    builder.Append(" activeDirectoryEndpointUrl");
                }

                builder.Append(" ]");

                throw new Exception(builder.ToString());
            }

            return new ClientSecretCredential(tenantId, clientId, clientSecret, _pipeline.WithAuthorityHost(new Uri(activeDirectoryEndpointUrl)));
        }
    }
}
