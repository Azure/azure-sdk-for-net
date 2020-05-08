// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Globalization;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;

namespace Azure.Identity
{
    internal class ManagedIdentityClient
    {
        private const string AuthenticationResponseInvalidFormatError = "Invalid response, the authentication response was not in the expected format.";
        private const string MsiEndpointInvalidUriError = "The environment variable MSI_ENDPOINT contains an invalid Uri.";
        internal const string MsiUnavailableError = "ManagedIdentityCredential authentication unavailable. No Managed Identity endpoint found.";
        internal const string IdentityUnavailableError = "ManagedIdentityCredential authentication unavailable. The requested identity has not been assigned to this resource.";

        // IMDS constants. Docs for IMDS are available here https://docs.microsoft.com/en-us/azure/active-directory/managed-identities-azure-resources/how-to-use-vm-token#get-a-token-using-http
        private static readonly Uri s_imdsEndpoint = new Uri("http://169.254.169.254/metadata/identity/oauth2/token");
        private static readonly IPAddress s_imdsHostIp = IPAddress.Parse("169.254.169.254");
        private const int s_imdsPort = 80;
        private const string ImdsApiVersion = "2018-02-01";
        private const int ImdsAvailableTimeoutMs = 1000;

        // MSI Constants. Docs for MSI are available here https://docs.microsoft.com/en-us/azure/app-service/overview-managed-identity
        private const string AppServiceMsiApiVersion = "2017-09-01";

        private static readonly SemaphoreSlim _initLock = new SemaphoreSlim(1, 1);
        private MsiType _msiType;
        private Uri _endpoint;

        private readonly CredentialPipeline _pipeline;

        protected ManagedIdentityClient()
        {
        }

        public ManagedIdentityClient(CredentialPipeline pipeline, string clientId = null)
        {
            _pipeline = pipeline;

            ClientId = clientId;
        }

        protected string ClientId { get; }

        public virtual AccessToken Authenticate(string[] scopes, CancellationToken cancellationToken)
        {
            MsiType msiType = GetMsiType(cancellationToken);

            // if msi is unavailable or we were unable to determine the type return CredentialUnavailable exception that no endpoint was found
            if (msiType == MsiType.Unavailable || msiType == MsiType.Unknown)
            {
                throw new CredentialUnavailableException(MsiUnavailableError);
            }

            using Request request = CreateAuthRequest(msiType, scopes);

            Response response = _pipeline.HttpPipeline.SendRequest(request, cancellationToken);

            if (response.Status == 200)
            {
                AccessToken result = Deserialize(response.ContentStream);

                return result;
            }

            if (response.Status == 400 && msiType == MsiType.Imds)
            {
                _msiType = MsiType.Unavailable;

                string message = _pipeline.Diagnostics.CreateRequestFailedMessage(response, message: IdentityUnavailableError);

                throw new CredentialUnavailableException(message);
            }

            throw _pipeline.Diagnostics.CreateRequestFailedException(response);
        }

        public virtual async Task<AccessToken> AuthenticateAsync(string[] scopes, CancellationToken cancellationToken)
        {
            MsiType msiType = await GetMsiTypeAsync(cancellationToken).ConfigureAwait(false);

            // if msi is unavailable or we were unable to determine the type return CredentialUnavailable exception that no endpoint was found
            if (msiType == MsiType.Unavailable || msiType == MsiType.Unknown)
            {
                throw new CredentialUnavailableException(MsiUnavailableError);
            }

            using Request request = CreateAuthRequest(msiType, scopes);

            Response response = await _pipeline.HttpPipeline.SendRequestAsync(request, cancellationToken).ConfigureAwait(false);

            if (response.Status == 200)
            {
                AccessToken result = await DeserializeAsync(response.ContentStream, cancellationToken).ConfigureAwait(false);

                return result;
            }

            if (response.Status == 400 && msiType == MsiType.Imds)
            {
                _msiType = MsiType.Unavailable;

                string message = await _pipeline.Diagnostics.CreateRequestFailedMessageAsync(response, message: IdentityUnavailableError, errorCode: null).ConfigureAwait(false);

                throw new CredentialUnavailableException(message);
            }

            throw await _pipeline.Diagnostics.CreateRequestFailedExceptionAsync(response).ConfigureAwait(false);
        }

        protected virtual MsiType GetMsiType(CancellationToken cancellationToken)
        {
            // if we haven't already determined the msi type
            if (_msiType == MsiType.Unknown)
            {
                // acquire the init lock
                _initLock.Wait(cancellationToken);

                try
                {
                    // check again if the we already determined the msiType now that we hold the lock
                    if (_msiType == MsiType.Unknown)
                    {
                        string endpointEnvVar = EnvironmentVariables.MsiEndpoint;
                        string secretEnvVar = EnvironmentVariables.MsiSecret;

                        // if the env var MSI_ENDPOINT is set
                        if (!string.IsNullOrEmpty(endpointEnvVar))
                        {
                            try
                            {
                                _endpoint = new Uri(endpointEnvVar);
                            }
                            catch (FormatException ex)
                            {
                                throw new AuthenticationFailedException(MsiEndpointInvalidUriError, ex);
                            }

                            // if BOTH the env vars MSI_ENDPOINT and MSI_SECRET are set the MsiType is AppService
                            if (!string.IsNullOrEmpty(secretEnvVar))
                            {
                                _msiType = MsiType.AppService;
                            }
                            // if ONLY the env var MSI_ENDPOINT is set the MsiType is CloudShell
                            else
                            {
                                _msiType = MsiType.CloudShell;
                            }
                        }
                        // if MSI_ENDPOINT is NOT set AND the IMDS endpoint is available the MsiType is Imds
                        else if (ImdsAvailable(cancellationToken))
                        {
                            _endpoint = s_imdsEndpoint;
                            _msiType = MsiType.Imds;
                        }
                        // if MSI_ENDPOINT is NOT set and IMDS endpoint is not available ManagedIdentity is not available
                        else
                        {
                            _msiType = MsiType.Unavailable;
                        }
                    }
                }
                // release the init lock
                finally
                {
                    _initLock.Release();
                }
            }

            return _msiType;
        }

        protected virtual async Task<MsiType> GetMsiTypeAsync(CancellationToken cancellationToken)
        {
            // if we haven't already determined the msi type
            if (_msiType == MsiType.Unknown)
            {
                // acquire the init lock
                await _initLock.WaitAsync(cancellationToken).ConfigureAwait(false);

                try
                {
                    // check again if the we already determined the msiType now that we hold the lock
                    if (_msiType == MsiType.Unknown)
                    {
                        string endpointEnvVar = EnvironmentVariables.MsiEndpoint;
                        string secretEnvVar = EnvironmentVariables.MsiSecret;

                        // if the env var MSI_ENDPOINT is set
                        if (!string.IsNullOrEmpty(endpointEnvVar))
                        {
                            try
                            {
                                _endpoint = new Uri(endpointEnvVar);
                            }
                            catch (FormatException ex)
                            {
                                throw new AuthenticationFailedException(MsiEndpointInvalidUriError, ex);
                            }

                            // if BOTH the env vars MSI_ENDPOINT and MSI_SECRET are set the MsiType is AppService
                            if (!string.IsNullOrEmpty(secretEnvVar))
                            {
                                _msiType = MsiType.AppService;
                            }
                            // if ONLY the env var MSI_ENDPOINT is set the MsiType is CloudShell
                            else
                            {
                                _msiType = MsiType.CloudShell;
                            }
                        }
                        // if MSI_ENDPOINT is NOT set AND the IMDS endpoint is available the MsiType is Imds
                        else if (await ImdsAvailableAsync(cancellationToken).ConfigureAwait(false))
                        {
                            _endpoint = s_imdsEndpoint;
                            _msiType = MsiType.Imds;
                        }
                        // if MSI_ENDPOINT is NOT set and IMDS endpoint is not available ManagedIdentity is not available
                        else
                        {
                            _msiType = MsiType.Unavailable;
                        }
                    }
                }
                // release the init lock
                finally
                {
                    _initLock.Release();
                }
            }

            return _msiType;
        }

        protected virtual bool ImdsAvailable(CancellationToken cancellationToken)
        {
            AzureIdentityEventSource.Singleton.ProbeImdsEndpoint(s_imdsEndpoint);

            bool available;
            // try to create a TCP connection to the IMDS IP address. If the connection can be established
            // we assume that IMDS is available. If connecting times out or fails to connect assume that
            // IMDS is not available in this environment.
            try
            {
                using (var client = new TcpClient())
                {
                    var result = client.BeginConnect(s_imdsHostIp, s_imdsPort, null, null);

                    var success = result.AsyncWaitHandle.WaitOne(ImdsAvailableTimeoutMs);

                    available = success && client.Connected;
                }
            }
            catch
            {
                available = false;
            }

            if (available)
            {
                AzureIdentityEventSource.Singleton.ImdsEndpointFound(s_imdsEndpoint);
            }
            else
            {
                AzureIdentityEventSource.Singleton.ImdsEndpointUnavailable(s_imdsEndpoint);
            }

            return available;
        }

        protected virtual async Task<bool> ImdsAvailableAsync(CancellationToken cancellationToken)
        {
            AzureIdentityEventSource.Singleton.ProbeImdsEndpoint(s_imdsEndpoint);

            bool available;
            // try to create a TCP connection to the IMDS IP address. If the connection can be established
            // we assume that IMDS is available. If connecting times out or fails to connect assume that
            // IMDS is not available in this environment.
            try
            {
                using (var client = new TcpClient())
                {
                    var result = client.BeginConnect(s_imdsHostIp, s_imdsPort, null, null);

                    var success = await Task.Run<bool>(() => result.AsyncWaitHandle.WaitOne(ImdsAvailableTimeoutMs), cancellationToken).ConfigureAwait(false);

                    available = success && client.Connected;
                }
            }
            catch
            {
                available = false;
            }

            if (available)
            {
                AzureIdentityEventSource.Singleton.ImdsEndpointFound(s_imdsEndpoint);
            }
            else
            {
                AzureIdentityEventSource.Singleton.ImdsEndpointUnavailable(s_imdsEndpoint);
            }

            return available;
        }

        private Request CreateAuthRequest(MsiType msiType, string[] scopes)
        {
            return msiType switch
            {
                MsiType.Imds => CreateImdsAuthRequest(scopes),
                MsiType.AppService => CreateAppServiceAuthRequest(scopes),
                MsiType.CloudShell => CreateCloudShellAuthRequest(scopes),
                _ => default,
            };
        }

        private Request CreateImdsAuthRequest(string[] scopes)
        {
            // covert the scopes to a resource string
            string resource = ScopeUtilities.ScopesToResource(scopes);

            Request request = _pipeline.HttpPipeline.CreateRequest();

            request.Method = RequestMethod.Get;

            request.Headers.Add("Metadata", "true");

            request.Uri.Reset(_endpoint);

            request.Uri.AppendQuery("api-version", ImdsApiVersion);

            request.Uri.AppendQuery("resource", resource);

            if (!string.IsNullOrEmpty(ClientId))
            {
                request.Uri.AppendQuery("client_id", ClientId);
            }

            return request;
        }

        private Request CreateAppServiceAuthRequest(string[] scopes)
        {
            // covert the scopes to a resource string
            string resource = ScopeUtilities.ScopesToResource(scopes);

            Request request = _pipeline.HttpPipeline.CreateRequest();

            request.Method = RequestMethod.Get;

            request.Headers.Add("secret", EnvironmentVariables.MsiSecret);

            request.Uri.Reset(_endpoint);

            request.Uri.AppendQuery("api-version", AppServiceMsiApiVersion);

            request.Uri.AppendQuery("resource", resource);

            if (!string.IsNullOrEmpty(ClientId))
            {
                request.Uri.AppendQuery("clientid", ClientId);
            }

            return request;
        }

        private Request CreateCloudShellAuthRequest(string[] scopes)
        {
            // covert the scopes to a resource string
            string resource = ScopeUtilities.ScopesToResource(scopes);

            Request request = _pipeline.HttpPipeline.CreateRequest();

            request.Method = RequestMethod.Post;

            request.Headers.Add(HttpHeader.Common.FormUrlEncodedContentType);

            request.Uri.Reset(_endpoint);

            request.Headers.Add("Metadata", "true");

            var bodyStr = $"resource={Uri.EscapeDataString(resource)}";

            if (!string.IsNullOrEmpty(ClientId))
            {
                bodyStr += $"&client_id={Uri.EscapeDataString(ClientId)}";
            }

            ReadOnlyMemory<byte> content = Encoding.UTF8.GetBytes(bodyStr).AsMemory();

            request.Content = RequestContent.Create(content);

            return request;
        }

        private async Task<AccessToken> DeserializeAsync(Stream content, CancellationToken cancellationToken)
        {
            using (JsonDocument json = await JsonDocument.ParseAsync(content, default, cancellationToken).ConfigureAwait(false))
            {
                return Deserialize(json.RootElement);
            }
        }

        private AccessToken Deserialize(Stream content)
        {
            using (JsonDocument json = JsonDocument.Parse(content))
            {
                return Deserialize(json.RootElement);
            }
        }

        private AccessToken Deserialize(JsonElement json)
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
            if (_msiType == MsiType.AppService)
            {
                if (!DateTimeOffset.TryParse(expiresOnProp.Value.GetString(), CultureInfo.InvariantCulture, DateTimeStyles.None, out expiresOn))
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

        private struct Error
        {
            public string Code { get; set; }

            public string Message { get; set; }
        }
    }
}
