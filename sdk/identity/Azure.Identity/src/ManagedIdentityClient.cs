// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Globalization;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure.Identity
{
    internal class ManagedIdentityClient
    {
        private const string AuthenticationResponseInvalidFormatError = "Invalid response, the authentication response was not in the expected format.";
        private const string IdentityEndpointInvalidUriError = "The environment variable IDENTITY_ENDPOINT contains an invalid Uri.";
        private const string MsiEndpointInvalidUriError = "The environment variable MSI_ENDPOINT contains an invalid Uri.";
        internal const string MsiUnavailableError = "ManagedIdentityCredential authentication unavailable. No Managed Identity endpoint found.";
        internal const string IdentityUnavailableError = "ManagedIdentityCredential authentication unavailable. The requested identity has not been assigned to this resource.";

        // IMDS constants. Docs for IMDS are available here https://docs.microsoft.com/en-us/azure/active-directory/managed-identities-azure-resources/how-to-use-vm-token#get-a-token-using-http
        private static readonly Uri s_imdsEndpoint = new Uri("http://169.254.169.254/metadata/identity/oauth2/token");
        private static readonly IPAddress s_imdsHostIp = IPAddress.Parse("169.254.169.254");
        private const int s_imdsPort = 80;
        private const int ImdsAvailableTimeoutMs = 1000;

        private readonly AsyncLockWithValue<IAuthRequestBuilder> _msiTypeAsyncLock = new AsyncLockWithValue<IAuthRequestBuilder>();
        private readonly CredentialPipeline _pipeline;
        private string _identityUnavailableErrorMessage;

        protected ManagedIdentityClient()
        {
        }

        public ManagedIdentityClient(CredentialPipeline pipeline, string clientId = null)
        {
            _pipeline = pipeline;

            ClientId = clientId;
        }

        protected string ClientId { get; }

        public virtual async ValueTask<AccessToken> AuthenticateAsync(bool async, string[] scopes, CancellationToken cancellationToken)
        {
            IAuthRequestBuilder requestBuilder = await GetAuthRequestBuilderAsync(async, cancellationToken).ConfigureAwait(false);

            // if msi is unavailable or we were unable to determine the type return CredentialUnavailable exception that no endpoint was found
            if (requestBuilder == default)
            {
                throw new CredentialUnavailableException(_identityUnavailableErrorMessage ?? MsiUnavailableError);
            }

            using Request request = requestBuilder.CreateRequest(scopes);

            Response response = async
                ? await _pipeline.HttpPipeline.SendRequestAsync(request, cancellationToken).ConfigureAwait(false)
                : _pipeline.HttpPipeline.SendRequest(request, cancellationToken);

            switch (response.Status) {
                case 200:
                    var isAppService2017 = requestBuilder is AppServiceV2017AuthRequestBuilder;
                    return await DeserializeAsync(response.ContentStream, isAppService2017, async, cancellationToken).ConfigureAwait(false);
                case 400 when requestBuilder is ImdsAuthRequestBuilder:
                    string message = _identityUnavailableErrorMessage ?? await _pipeline.Diagnostics
                        .CreateRequestFailedMessageAsync(response, IdentityUnavailableError, null, null, async)
                        .ConfigureAwait(false);

                    Interlocked.CompareExchange(ref _identityUnavailableErrorMessage, message, null);
                    throw new CredentialUnavailableException(message);
                default:
                    throw async
                        ? await _pipeline.Diagnostics.CreateRequestFailedExceptionAsync(response).ConfigureAwait(false)
                        : _pipeline.Diagnostics.CreateRequestFailedException(response);
            }
        }

        private protected virtual async ValueTask<IAuthRequestBuilder> GetAuthRequestBuilderAsync(bool async, CancellationToken cancellationToken)
        {
            if (_identityUnavailableErrorMessage != default)
            {
                return default;
            }

            using var asyncLock = await _msiTypeAsyncLock.GetLockOrValueAsync(async, cancellationToken).ConfigureAwait(false);
            if (asyncLock.HasValue)
            {
                return asyncLock.Value;
            }

            IAuthRequestBuilder builder = await CreateAuthRequestBuilderAsync(async, cancellationToken).ConfigureAwait(false);
            asyncLock.SetValue(builder);
            return builder;
        }

        private async ValueTask<IAuthRequestBuilder> CreateAuthRequestBuilderAsync(bool async, CancellationToken cancellationToken)
        {
            string identityEndpoint = EnvironmentVariables.IdentityEndpoint;
            string identityHeader = EnvironmentVariables.IdentityHeader;

            if (!string.IsNullOrEmpty(identityEndpoint) && !string.IsNullOrEmpty(identityHeader))
            {
                Uri endpointUri;
                try
                {
                    endpointUri = new Uri(identityEndpoint);
                }
                catch (FormatException ex)
                {
                    throw new AuthenticationFailedException(IdentityEndpointInvalidUriError, ex);
                }

                return new AppServiceV2019AuthRequestBuilder(_pipeline.HttpPipeline, endpointUri, identityHeader, ClientId);
            }

            string msiEndpoint = EnvironmentVariables.MsiEndpoint;
            string msiSecret = EnvironmentVariables.MsiSecret;

            // if the env var MSI_ENDPOINT is set
            if (!string.IsNullOrEmpty(msiEndpoint))
            {
                Uri endpointUri;
                try
                {
                    endpointUri = new Uri(msiEndpoint);
                }
                catch (FormatException ex)
                {
                    throw new AuthenticationFailedException(MsiEndpointInvalidUriError, ex);
                }

                // if BOTH the env vars MSI_ENDPOINT and MSI_SECRET are set the MsiType is AppService
                if (!string.IsNullOrEmpty(msiSecret))
                {
                    return new AppServiceV2017AuthRequestBuilder(_pipeline.HttpPipeline, endpointUri, msiSecret, ClientId);
                }

                // if ONLY the env var MSI_ENDPOINT is set the MsiType is CloudShell
                return new CloudShellAuthRequestBuilder(_pipeline.HttpPipeline, endpointUri, ClientId);
            }

            // if MSI_ENDPOINT is NOT set AND the IMDS endpoint is available the MsiType is Imds
            if (await ImdsAvailableAsync(async, cancellationToken).ConfigureAwait(false))
            {
                return new ImdsAuthRequestBuilder(_pipeline.HttpPipeline, s_imdsEndpoint, ClientId);
            }
            // if MSI_ENDPOINT is NOT set and IMDS endpoint is not available ManagedIdentity is not available

            return default;
        }

        protected virtual async ValueTask<bool> ImdsAvailableAsync(bool async, CancellationToken cancellationToken)
        {
            AzureIdentityEventSource.Singleton.ProbeImdsEndpoint(s_imdsEndpoint);

            bool available;
            // try to create a TCP connection to the IMDS IP address. If the connection can be established
            // we assume that IMDS is available. If connecting times out or fails to connect assume that
            // IMDS is not available in this environment.
            try
            {
                using var client = new TcpClient();
                Task connectTask = client.ConnectAsync(s_imdsHostIp, s_imdsPort);

                if (async)
                {
                    using var cts = CancellationTokenSource.CreateLinkedTokenSource(cancellationToken);

                    cts.CancelAfter(ImdsAvailableTimeoutMs);
                    await connectTask.AwaitWithCancellation(cts.Token);
                    available = client.Connected;
                }
                else
                {
                    available = connectTask.Wait(ImdsAvailableTimeoutMs, cancellationToken) && client.Connected;
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

        private static async ValueTask<AccessToken> DeserializeAsync(Stream content, bool isAppService2017, bool async, CancellationToken cancellationToken)
        {
            using JsonDocument json = async
                ? await JsonDocument.ParseAsync(content, default, cancellationToken).ConfigureAwait(false)
                : JsonDocument.Parse(content);
            return Deserialize(json.RootElement, isAppService2017);
        }

        private static AccessToken Deserialize(JsonElement json, bool isAppService2017)
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
            // if s_msiType is AppService version 2017-09-01, expires_on will be a string formatted datetimeoffset
            if (isAppService2017)
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
    }
}
