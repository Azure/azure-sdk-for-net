// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Azure.Core.Diagnostics;
using System;
using System.IO;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.Identity
{
    /// <summary>
    /// Attempts authentication using a managed identity that has been assigned to the deployment environment.This authentication type works in Azure VMs,
    /// App Service and Azure Functions applications, as well as inside of Azure Cloud Shell. More information about configuring managed identities can be found here:
    /// https://docs.microsoft.com/en-us/azure/active-directory/managed-identities-azure-resources/overview
    /// </summary>
    public class ManagedIdentityCredential : TokenCredential, IExtendedTokenCredential
    {
        private enum MsiType
        {
            Unknown = 0,
            Imds = 1,
            AppService = 2,
            CloudShell = 3,
            Unavailable = 4
        }

        private const string MsiUnavailableError = "Managed identity authentication is unavailable.";
        private const string AuthenticationResponseInvalidFormatError = "Invalid response, the authentication response was not in the expected format.";
        private const string MsiEndpointInvalidUriError = "The environment variable MSI_ENDPOINT contains an invalid Uri.";

        // IMDS constants. Docs for IMDS are available here https://docs.microsoft.com/en-us/azure/active-directory/managed-identities-azure-resources/how-to-use-vm-token#get-a-token-using-http
        private static readonly Uri s_imdsEndpoint = new Uri("http://169.254.169.254/metadata/identity/oauth2/token");
        private const string ImdsApiVersion = "2018-02-01";
        private const int ImdsAvailableTimeoutMs = 500;

        // MSI Constants. Docs for MSI are available here https://docs.microsoft.com/en-us/azure/app-service/overview-managed-identity
        private const string AppServiceMsiApiVersion = "2017-09-01";

        private static readonly SemaphoreSlim s_initLock = new SemaphoreSlim(1, 1);
        private static MsiType s_msiType;
        private static Uri s_endpoint;

        private readonly string _clientId;
        private readonly CredentialPipeline _pipeline;

        /// <summary>
        /// Protected constructor for mocking.
        /// </summary>
        protected ManagedIdentityCredential()
        {

        }

        /// <summary>
        /// Creates an instance of the ManagedIdentityCredential capable of authenticating a resource with a managed identity.
        /// </summary>
        /// <param name="clientId">
        /// The client id to authenticate for a user assigned managed identity.  More information on user assigned managed identities cam be found here:
        /// https://docs.microsoft.com/en-us/azure/active-directory/managed-identities-azure-resources/overview#how-a-user-assigned-managed-identity-works-with-an-azure-vm
        /// </param>
        /// <param name="options">Options that allow to configure the management of the requests sent to the Azure Active Directory service.</param>
        public ManagedIdentityCredential(string clientId = null, TokenCredentialOptions options = null)
            : this(clientId, CredentialPipeline.GetInstance(options))
        {
        }

        internal ManagedIdentityCredential(string clientId, CredentialPipeline pipeline)
        {
            _clientId = clientId;

            _pipeline = pipeline;
        }

        /// <summary>
        /// Obtains an <see cref="AccessToken"/> from the Managed Identity service if available.
        /// </summary>
        /// <param name="requestContext">The details of the authentication request.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>An <see cref="AccessToken"/> which can be used to authenticate service client calls, or a default <see cref="AccessToken"/> if no managed identity is available.</returns>
        public override async Task<AccessToken> GetTokenAsync(TokenRequestContext requestContext, CancellationToken cancellationToken = default)
        {
            (AccessToken token, Exception ex) = await GetTokenImplAsync(requestContext, cancellationToken).ConfigureAwait(false);

            if (ex != null)
            {
                throw ex;
            }

            return token;
        }

        /// <summary>
        /// Obtains an <see cref="AccessToken"/> from the Managed Identity service if available.
        /// </summary>
        /// <param name="requestContext">The details of the authentication request.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>An <see cref="AccessToken"/> which can be used to authenticate service client calls, or a default <see cref="AccessToken"/> if no managed identity is available.</returns>
        public override AccessToken GetToken(TokenRequestContext requestContext, CancellationToken cancellationToken = default)
        {
            (AccessToken token, Exception ex) = GetTokenImpl(requestContext, cancellationToken);

            if (ex != null)
            {
                throw ex;
            }

            return token;
        }

        async Task<(AccessToken, Exception)> IExtendedTokenCredential.GetTokenAsync(TokenRequestContext requestContext, CancellationToken cancellationToken)
        {
            return await GetTokenImplAsync(requestContext, cancellationToken).ConfigureAwait(false);
        }

        (AccessToken, Exception) IExtendedTokenCredential.GetToken(TokenRequestContext requestContext, CancellationToken cancellationToken)
        {
            return GetTokenImpl(requestContext, cancellationToken);
        }

        private async Task<(AccessToken, Exception)> GetTokenImplAsync(TokenRequestContext requestContext, CancellationToken cancellationToken)
        {
            Exception ex = null;

            using CredentialDiagnosticScope scope = _pipeline.StartGetTokenScope("Azure.Identity.ManagedIdentityCredential.GetToken", requestContext);

            try
            {
                MsiType msiType = await GetMsiTypeAsync(cancellationToken).ConfigureAwait(false);

                // if msi is unavailable or we were unable to determine the type return a default access token
                if (msiType == MsiType.Unavailable || msiType == MsiType.Unknown)
                {
                    return (default, new CredentialUnavailableException(MsiUnavailableError));
                }

                AccessToken token = await SendAuthRequestAsync(msiType, requestContext.Scopes, _clientId, cancellationToken).ConfigureAwait(false);

                return (token, null);
            }
            catch (Exception e)
            {
                ex = scope.Failed(e);

                return (default, ex);
            }
        }

        private (AccessToken, Exception) GetTokenImpl(TokenRequestContext requestContext, CancellationToken cancellationToken)
        {
            Exception ex = null;

            using CredentialDiagnosticScope scope = _pipeline.StartGetTokenScope("Azure.Identity.ManagedIdentityCredential.GetToken", requestContext);

            try
            {
                MsiType msiType = GetMsiType(cancellationToken);

                // if msi is unavailable or we were unable to determine the type return a default access token
                if (msiType == MsiType.Unavailable || msiType == MsiType.Unknown)
                {
                    return (default, new CredentialUnavailableException(MsiUnavailableError));
                }

                AccessToken token = SendAuthRequest(msiType, requestContext.Scopes, _clientId, cancellationToken);

                return (token, null);
            }
            catch (Exception e)
            {
                ex = scope.Failed(e);

                return (default, ex);
            }
        }

        private async Task<AccessToken> SendAuthRequestAsync(MsiType msiType, string[] scopes, string clientId, CancellationToken cancellationToken)
        {
            using (Request request = CreateAuthRequest(msiType, scopes, clientId))
            {
                Response response = await _pipeline.Pipeline.SendRequestAsync(request, cancellationToken).ConfigureAwait(false);

                if (response.Status == 200)
                {
                    AccessToken result = await DeserializeAsync(response.ContentStream, cancellationToken).ConfigureAwait(false);

                    return result;
                }

                throw await response.CreateRequestFailedExceptionAsync().ConfigureAwait(false);
            }
        }

        private AccessToken SendAuthRequest(MsiType msiType, string[] scopes, string clientId, CancellationToken cancellationToken)
        {
            using (Request request = CreateAuthRequest(msiType, scopes, clientId))
            {
                Response response = _pipeline.Pipeline.SendRequest(request, cancellationToken);

                if (response.Status == 200)
                {
                    AccessToken result = Deserialize(response.ContentStream);

                    return result;
                }

                throw response.CreateRequestFailedException();
            }
        }

        private Request CreateAuthRequest(MsiType msiType, string[] scopes, string clientId)
        {
            return msiType switch
            {
                MsiType.Imds => CreateImdsAuthRequest(scopes, clientId),
                MsiType.AppService => CreateAppServiceAuthRequest(scopes, clientId),
                MsiType.CloudShell => CreateCloudShellAuthRequest(scopes, clientId),
                _ => default,
            };
        }

        private async ValueTask<MsiType> GetMsiTypeAsync(CancellationToken cancellationToken)
        {
            // if we haven't already determined the msi type
            if (s_msiType == MsiType.Unknown)
            {
                // aquire the init lock
                await s_initLock.WaitAsync(cancellationToken).ConfigureAwait(false);

                try
                {
                    // check again if the we already determined the msiType now that we hold the lock
                    if (s_msiType == MsiType.Unknown)
                    {
                        string endpointEnvVar = EnvironmentVariables.MsiEndpoint;
                        string secretEnvVar = EnvironmentVariables.MsiSecret;

                        // if the env var MSI_ENDPOINT is set
                        if (!string.IsNullOrEmpty(endpointEnvVar))
                        {
                            try
                            {
                                s_endpoint = new Uri(endpointEnvVar);
                            }
                            catch (FormatException ex)
                            {
                                throw new AuthenticationFailedException(MsiEndpointInvalidUriError, ex);
                            }

                            // if BOTH the env vars MSI_ENDPOINT and MSI_SECRET are set the MsiType is AppService
                            if (!string.IsNullOrEmpty(secretEnvVar))
                            {
                                s_msiType = MsiType.AppService;
                            }
                            // if ONLY the env var MSI_ENDPOINT is set the MsiType is CloudShell
                            else
                            {
                                s_msiType = MsiType.CloudShell;
                            }
                        }
                        // if MSI_ENDPOINT is NOT set AND the IMDS endpoint is available the MsiType is Imds
                        else if (await ImdsAvailableAsync(cancellationToken).ConfigureAwait(false))
                        {
                            s_endpoint = s_imdsEndpoint;
                            s_msiType = MsiType.Imds;
                        }
                        // if MSI_ENDPOINT is NOT set and IMDS enpoint is not available ManagedIdentity is not available
                        else
                        {
                            s_msiType = MsiType.Unavailable;
                        }
                    }
                }
                // release the init lock
                finally
                {
                    s_initLock.Release();
                }
            }

            return s_msiType;
        }


        private MsiType GetMsiType(CancellationToken cancellationToken)
        {
            // if we haven't already determined the msi type
            if (s_msiType == MsiType.Unknown)
            {
                // aquire the init lock
                s_initLock.Wait(cancellationToken);

                try
                {
                    // check again if the we already determined the msiType now that we hold the lock
                    if (s_msiType == MsiType.Unknown)
                    {
                        string endpointEnvVar = EnvironmentVariables.MsiEndpoint;
                        string secretEnvVar = EnvironmentVariables.MsiSecret;

                        // if the env var MSI_ENDPOINT is set
                        if (!string.IsNullOrEmpty(endpointEnvVar))
                        {
                            try
                            {
                                s_endpoint = new Uri(endpointEnvVar);
                            }
                            catch (FormatException ex)
                            {
                                throw new AuthenticationFailedException(MsiEndpointInvalidUriError, ex);
                            }

                            // if BOTH the env vars MSI_ENDPOINT and MSI_SECRET are set the MsiType is AppService
                            if (!string.IsNullOrEmpty(secretEnvVar))
                            {
                                s_msiType = MsiType.AppService;
                            }
                            // if ONLY the env var MSI_ENDPOINT is set the MsiType is CloudShell
                            else
                            {
                                s_msiType = MsiType.CloudShell;
                            }
                        }
                        // if MSI_ENDPOINT is NOT set AND the IMDS endpoint is available the MsiType is Imds
                        else if (ImdsAvailable(cancellationToken))
                        {
                            s_endpoint = s_imdsEndpoint;
                            s_msiType = MsiType.Imds;
                        }
                        // if MSI_ENDPOINT is NOT set and IMDS enpoint is not available ManagedIdentity is not available
                        else
                        {
                            s_msiType = MsiType.Unavailable;
                        }
                    }
                }
                // release the init lock
                finally
                {
                    s_initLock.Release();
                }
            }

            return s_msiType;
        }

        private bool ImdsAvailable(CancellationToken cancellationToken)
        {
            // send a request without the Metadata header.  This will result in a failed request,
            // but we're just interested in if we get a response before the timeout of 500ms
            // if we don't get a response we assume the imds endpoint is not available
            using (Request request = _pipeline.Pipeline.CreateRequest())
            {
                request.Method = RequestMethod.Get;

                request.Uri.Reset(s_imdsEndpoint);

                request.Uri.AppendQuery("api-version", ImdsApiVersion);

                CancellationToken imdsTimeout = new CancellationTokenSource(ImdsAvailableTimeoutMs).Token;

                try
                {
                    Response response = _pipeline.Pipeline.SendRequest(request, CancellationTokenSource.CreateLinkedTokenSource(cancellationToken, imdsTimeout).Token);

                    return true;
                }
                // we only want to handle the case when the imdsTimeout resulted in the request being cancelled.
                // this indicates that the request timed out and that imds is not available.  If the operation
                // was user cancelled we don't wan't to handle the exception so s_identityAvailable will
                // remain unset, as we still haven't determined if the imds endpoint is available.
                catch (OperationCanceledException) when (!cancellationToken.IsCancellationRequested)
                {
                    return false;
                }
            }
        }

        private async Task<bool> ImdsAvailableAsync(CancellationToken cancellationToken)
        {
            // send a request without the Metadata header.  This will result in a failed request,
            // but we're just interested in if we get a response before the timeout of 500ms
            // if we don't get a response we assume the imds endpoint is not available
            using (Request request = _pipeline.Pipeline.CreateRequest())
            {
                request.Method = RequestMethod.Get;

                request.Uri.Reset(s_imdsEndpoint);

                request.Uri.AppendQuery("api-version", ImdsApiVersion);

                CancellationToken imdsTimeout = new CancellationTokenSource(ImdsAvailableTimeoutMs).Token;

                try
                {
                    AzureIdentityEventSource.Singleton.ProbeImdsEndpoint(request.Uri);

                    Response response = await _pipeline.Pipeline.SendRequestAsync(request, CancellationTokenSource.CreateLinkedTokenSource(cancellationToken, imdsTimeout).Token).ConfigureAwait(false);

                    AzureIdentityEventSource.Singleton.ImdsEndpointFound(request.Uri);

                    return true;
                }
                // we only want to handle the case when the imdsTimeout resulted in the request being cancelled.
                // this indicates that the request timed out and that imds is not available.  If the operation
                // was user cancelled we don't wan't to handle the exception so s_identityAvailable will
                // remain unset, as we still haven't determined if the imds endpoint is available.
                catch (OperationCanceledException) when (!cancellationToken.IsCancellationRequested)
                {
                    AzureIdentityEventSource.Singleton.ImdsEndpointUnavailable(request.Uri);

                    return false;
                }
            }
        }

        private Request CreateImdsAuthRequest(string[] scopes, string clientId)
        {
            // covert the scopes to a resource string
            string resource = ScopeUtilities.ScopesToResource(scopes);

            Request request = _pipeline.Pipeline.CreateRequest();

            request.Method = RequestMethod.Get;

            request.Headers.Add("Metadata", "true");

            request.Uri.Reset(s_endpoint);

            request.Uri.AppendQuery("api-version", ImdsApiVersion);

            request.Uri.AppendQuery("resource", resource);

            if (!string.IsNullOrEmpty(clientId))
            {
                request.Uri.AppendQuery("client_id", clientId);
            }

            return request;
        }

        private Request CreateAppServiceAuthRequest(string[] scopes, string clientId)
        {
            // covert the scopes to a resource string
            string resource = ScopeUtilities.ScopesToResource(scopes);

            Request request = _pipeline.Pipeline.CreateRequest();

            request.Method = RequestMethod.Get;

            request.Headers.Add("secret", EnvironmentVariables.MsiSecret);

            request.Uri.Reset(s_endpoint);

            request.Uri.AppendQuery("api-version", AppServiceMsiApiVersion);

            request.Uri.AppendQuery("resource", resource);

            if (!string.IsNullOrEmpty(clientId))
            {
                request.Uri.AppendQuery("client_id", clientId);
            }

            return request;
        }

        private Request CreateCloudShellAuthRequest(string[] scopes, string clientId)
        {
            // covert the scopes to a resource string
            string resource = ScopeUtilities.ScopesToResource(scopes);

            Request request = _pipeline.Pipeline.CreateRequest();

            request.Method = RequestMethod.Post;

            request.Headers.Add(HttpHeader.Common.FormUrlEncodedContentType);

            request.Uri.Reset(s_endpoint);

            request.Headers.Add("Metadata", "true");

            var bodyStr = $"resource={Uri.EscapeDataString(resource)}";

            if (!string.IsNullOrEmpty(clientId))
            {
                bodyStr += $"&client_id={Uri.EscapeDataString(clientId)}";
            }

            ReadOnlyMemory<byte> content = Encoding.UTF8.GetBytes(bodyStr).AsMemory();

            request.Content = RequestContent.Create(content);

            return request;
        }

        private static async Task<AccessToken> DeserializeAsync(Stream content, CancellationToken cancellationToken)
        {
            using (JsonDocument json = await JsonDocument.ParseAsync(content, default, cancellationToken).ConfigureAwait(false))
            {
                return Deserialize(json.RootElement);
            }
        }

        private static AccessToken Deserialize(Stream content)
        {
            using (JsonDocument json = JsonDocument.Parse(content))
            {
                return Deserialize(json.RootElement);
            }
        }

        private static AccessToken Deserialize(JsonElement json)
        {
            string accessToken = null;
            JsonElement? expiresOnProp = null;

            foreach (JsonProperty prop in json.EnumerateObject())
            {
                switch (prop.Name)
                {
                    case "access_token":
                        accessToken = prop.Value.GetString();
                        break;

                    case "expires_on":
                        expiresOnProp = prop.Value;
                        break;
                }
            }

            if (accessToken is null || !expiresOnProp.HasValue)
            {
                throw new AuthenticationFailedException(AuthenticationResponseInvalidFormatError);
            }

            DateTimeOffset expiresOn;
            // if s_msiType is AppService expires_on will be a string formatted datetimeoffset
            if (s_msiType == MsiType.AppService)
            {
                if (!DateTimeOffset.TryParse(expiresOnProp.Value.GetString(), out expiresOn))
                {
                    throw new AuthenticationFailedException(AuthenticationResponseInvalidFormatError);
                }
            }
            // otherwise expires_on will be a unix timestamp seconds from epoch
            else
            {
                // the seconds from epoch may be returned as a Json number or a Json string which is a number
                // depending on the environment.  If neither of these are the case we throw an AuthException.
                if (!(expiresOnProp.Value.ValueKind == JsonValueKind.Number && expiresOnProp.Value.TryGetInt64(out long expiresOnSec)) &&
                    !(expiresOnProp.Value.ValueKind == JsonValueKind.String && long.TryParse(expiresOnProp.Value.GetString(), out expiresOnSec)))
                {
                    throw new AuthenticationFailedException(AuthenticationResponseInvalidFormatError);
                }

                expiresOn = DateTimeOffset.FromUnixTimeSeconds(expiresOnSec);
            }

            return new AccessToken(accessToken, expiresOn);
        }
    }
}
