// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Azure.Core.Pipeline;
using System;
using System.IO;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.Http;

namespace Azure.Identity
{
    internal class ManagedIdentityClient
    {
        private static Lazy<ManagedIdentityClient> s_sharedClient = new Lazy<ManagedIdentityClient>(() => new ManagedIdentityClient(null));

        private const string AuthenticationResponseInvalidFormatError = "Invalid response, the authentication response was not in the expected format.";
        private const string MsiEndpointInvalidUriError = "The environment variable MSI_ENDPOINT contains an invalid Uri.";
        private const string AuthenticationRequestFailedError = "The request to the identity service failed. See inner exception for details.";

        // IMDS constants. Docs for IMDS are available here https://docs.microsoft.com/en-us/azure/active-directory/managed-identities-azure-resources/how-to-use-vm-token#get-a-token-using-http
        private static readonly Uri ImdsEndpoint = new Uri("http://169.254.169.254/metadata/identity/oauth2/token");
        private const string ImdsApiVersion = "2018-02-01";
        private const int ImdsAvailableTimeoutMs = 500;

        // MSI Constants. Docs for MSI are available here https://docs.microsoft.com/en-us/azure/app-service/overview-managed-identity
        private const string MsiEndpointEnvironemntVariable = "MSI_ENDPOINT";
        private const string MsiSecretEnvironemntVariable = "MSI_SECRET";
        private const string AppServiceMsiApiVersion = "2017-09-01";

        private static SemaphoreSlim s_initLock = new SemaphoreSlim(1, 1);
        private static MsiType s_msiType;
        private static Uri s_endpoint;

        private readonly IdentityClientOptions _options;
        private readonly HttpPipeline _pipeline;

        protected ManagedIdentityClient()
        {
        }

        public ManagedIdentityClient(IdentityClientOptions options = null)
        {
            _options = options ?? new IdentityClientOptions();

            _pipeline = HttpPipelineBuilder.Build(_options, bufferResponse: true);
        }

        private enum MsiType
        {
            Unknown = 0,
            Imds = 1,
            AppService = 2,
            CloudShell = 3,
            Unavailable = 4
        }

        public static ManagedIdentityClient SharedClient { get { return s_sharedClient.Value; } }

        public virtual async Task<AccessToken> AuthenticateAsync(string[] scopes, string clientId = null, CancellationToken cancellationToken = default)
        {
            MsiType msiType = await GetMsiTypeAsync(cancellationToken).ConfigureAwait(false);

            // if msi is unavailable or we were unable to determine the type return a default access token
            if (msiType == MsiType.Unavailable || msiType == MsiType.Unknown)
            {
                return default;
            }

            using DiagnosticScope scope = _pipeline.Diagnostics.CreateScope("Azure.Identity.ManagedIdentityClient.Authenticate");
            scope.Start();

            try
            {
                try
                {
                    return await SendAuthRequestAsync(msiType, scopes, clientId, cancellationToken).ConfigureAwait(false);
                }
                catch (RequestFailedException ex)
                {
                    throw new AuthenticationFailedException(AuthenticationRequestFailedError, ex);
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        public virtual AccessToken Authenticate(string[] scopes, string clientId = null, CancellationToken cancellationToken = default)
        {
            MsiType msiType = GetMsiType(cancellationToken);

            // if msi is unavailable or we were unable to determine the type return a default access token
            if (msiType == MsiType.Unavailable || msiType == MsiType.Unknown)
            {
                return default;
            }

            using DiagnosticScope scope = _pipeline.Diagnostics.CreateScope("Azure.Identity.ManagedIdentityClient.Authenticate");
            scope.Start();

            try
            {
                try
                {
                    return SendAuthRequest(msiType, scopes, clientId, cancellationToken);
                }
                catch(RequestFailedException ex)
                {
                    throw new AuthenticationFailedException(AuthenticationRequestFailedError, ex);
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        private async Task<AccessToken> SendAuthRequestAsync(MsiType msiType, string[] scopes, string clientId, CancellationToken cancellationToken)
        {
            using (Request request = CreateAuthRequest(msiType, scopes, clientId))
            {
                var response = await _pipeline.SendRequestAsync(request, cancellationToken).ConfigureAwait(false);

                if (response.Status == 200)
                {
                    var result = await DeserializeAsync(response.ContentStream, cancellationToken).ConfigureAwait(false);

                    return result;
                }

                throw await response.CreateRequestFailedExceptionAsync().ConfigureAwait(false);
            }
        }

        private AccessToken SendAuthRequest(MsiType msiType, string[] scopes, string clientId, CancellationToken cancellationToken)
        {
            using (Request request = CreateAuthRequest(msiType, scopes, clientId))
            {
                var response = _pipeline.SendRequest(request, cancellationToken);

                if (response.Status == 200)
                {
                    var result = Deserialize(response.ContentStream);

                    return result;
                }

                throw response.CreateRequestFailedException();
            }
        }

        private Request CreateAuthRequest(MsiType msiType, string[] scopes, string clientId)
        {
            switch (msiType)
            {
                case MsiType.Imds:
                    return CreateImdsAuthRequest(scopes, clientId);
                case MsiType.AppService:
                    return CreateAppServiceAuthRequest(scopes, clientId);
                case MsiType.CloudShell:
                    return CreateCloudShellAuthRequest(scopes, clientId);
                default:
                    return default;
            }
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
                        string endpointEnvVar = Environment.GetEnvironmentVariable(MsiEndpointEnvironemntVariable);
                        string secretEnvVar = Environment.GetEnvironmentVariable(MsiSecretEnvironemntVariable);

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
                            s_endpoint = ImdsEndpoint;
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
                        string endpointEnvVar = Environment.GetEnvironmentVariable(MsiEndpointEnvironemntVariable);
                        string secretEnvVar = Environment.GetEnvironmentVariable(MsiSecretEnvironemntVariable);

                        // if the env var MSI_ENDPOINT is set
                        if (!string.IsNullOrEmpty(endpointEnvVar))
                        {
                            try
                            {
                                s_endpoint = new Uri(endpointEnvVar);
                            }
                            catch(FormatException ex)
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
                            s_endpoint = ImdsEndpoint;
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
            using (Request request = _pipeline.CreateRequest())
            {
                request.Method = RequestMethod.Get;

                request.UriBuilder.Uri = ImdsEndpoint;

                request.UriBuilder.AppendQuery("api-version", ImdsApiVersion);

                var imdsTimeout = new CancellationTokenSource(ImdsAvailableTimeoutMs).Token;

                try
                {
                    var response = _pipeline.SendRequest(request, CancellationTokenSource.CreateLinkedTokenSource(cancellationToken, imdsTimeout).Token);

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
            using (Request request = _pipeline.CreateRequest())
            {
                request.Method = RequestMethod.Get;

                request.UriBuilder.Uri = ImdsEndpoint;

                request.UriBuilder.AppendQuery("api-version", ImdsApiVersion);

                var imdsTimeout = new CancellationTokenSource(ImdsAvailableTimeoutMs).Token;

                try
                {
                    var response = await _pipeline.SendRequestAsync(request, CancellationTokenSource.CreateLinkedTokenSource(cancellationToken, imdsTimeout).Token).ConfigureAwait(false);

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

        private Request CreateImdsAuthRequest(string[] scopes, string clientId)
        {
            // covert the scopes to a resource string
            string resource = ScopeUtilities.ScopesToResource(scopes);

            Request request = _pipeline.CreateRequest();

            request.Method = RequestMethod.Get;

            request.Headers.Add("Metadata", "true");

            request.UriBuilder.Uri = s_endpoint;

            request.UriBuilder.AppendQuery("api-version", ImdsApiVersion);

            request.UriBuilder.AppendQuery("resource", Uri.EscapeDataString(resource));

            if (!string.IsNullOrEmpty(clientId))
            {
                request.UriBuilder.AppendQuery("client_id", Uri.EscapeDataString(clientId));
            }

            return request;
        }

        private Request CreateAppServiceAuthRequest(string[] scopes, string clientId)
        {
            // covert the scopes to a resource string
            string resource = ScopeUtilities.ScopesToResource(scopes);

            Request request = _pipeline.CreateRequest();

            request.Method = RequestMethod.Get;

            request.Headers.Add("secret", Environment.GetEnvironmentVariable(MsiSecretEnvironemntVariable));

            request.UriBuilder.Uri = s_endpoint;

            request.UriBuilder.AppendQuery("api-version", AppServiceMsiApiVersion);

            request.UriBuilder.AppendQuery("resource", Uri.EscapeDataString(resource));

            if (!string.IsNullOrEmpty(clientId))
            {
                request.UriBuilder.AppendQuery("client_id", Uri.EscapeDataString(clientId));
            }

            return request;
        }

        private Request CreateCloudShellAuthRequest(string[] scopes, string clientId)
        {
            // covert the scopes to a resource string
            string resource = ScopeUtilities.ScopesToResource(scopes);

            Request request = _pipeline.CreateRequest();

            request.Method = RequestMethod.Post;

            request.Headers.Add(HttpHeader.Common.FormUrlEncodedContentType);

            request.UriBuilder.Uri = s_endpoint;

            request.Headers.Add("Metadata", "true");

            var bodyStr = $"resource={Uri.EscapeDataString(resource)}";

            if (!string.IsNullOrEmpty(clientId))
            {
                bodyStr += $"&client_id={Uri.EscapeDataString(clientId)}";
            }

            ReadOnlyMemory<byte> content = Encoding.UTF8.GetBytes(bodyStr).AsMemory();

            request.Content = HttpPipelineRequestContent.Create(content);

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

            DateTimeOffset expiresOn = DateTimeOffset.MaxValue;

            if (!json.TryGetProperty("access_token", out JsonElement accessTokenProp))
            {
                throw new AuthenticationFailedException(AuthenticationResponseInvalidFormatError);
            }

            accessToken = accessTokenProp.GetString();

            if (!json.TryGetProperty("expires_on", out JsonElement expiresOnProp))
            {
                throw new AuthenticationFailedException(AuthenticationResponseInvalidFormatError);
            }

            // if s_msiType is AppService expires_on will be a string formatted datetimeoffset
            if (s_msiType == MsiType.AppService)
            {
                if(!DateTimeOffset.TryParse(expiresOnProp.GetString(), out expiresOn))
                {
                    throw new AuthenticationFailedException(AuthenticationResponseInvalidFormatError);
                }
            }
            // otherwise expires_on will be a unix timestamp seconds from epoch
            else
            {
                // the seconds from epoch may be returned as a Json number or a Json string which is a number
                // depending on the environment.  If neither of these are the case we throw an AuthException.
                if (!(expiresOnProp.ValueKind == JsonValueKind.Number && expiresOnProp.TryGetInt64(out long expiresOnSec)) &&
                    !(expiresOnProp.ValueKind == JsonValueKind.String && long.TryParse(expiresOnProp.GetString(), out expiresOnSec)))
                {
                    throw new AuthenticationFailedException(AuthenticationResponseInvalidFormatError);
                }

                expiresOn = DateTimeOffset.FromUnixTimeSeconds(expiresOnSec);
            }

            return new AccessToken(accessToken, expiresOn);
        }
    }
}