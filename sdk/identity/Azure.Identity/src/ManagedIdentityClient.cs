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
        internal const string MsiUnavailableError = "ManagedIdentityCredential authentication unavailable. No Managed Identity endpoint found.";
        internal const string IdentityUnavailableError = "ManagedIdentityCredential authentication unavailable. The requested identity has not been assigned to this resource.";

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
            return AppServiceV2019AuthRequestBuilder.TryCreate(_pipeline.HttpPipeline, ClientId)
                ?? AppServiceV2017AuthRequestBuilder.TryCreate(_pipeline.HttpPipeline, ClientId)
                ?? CloudShellAuthRequestBuilder.TryCreate(_pipeline.HttpPipeline, ClientId)
                ?? await ImdsAuthRequestBuilder.TryCreateAsync(_pipeline.HttpPipeline, ClientId, async, cancellationToken).ConfigureAwait(false);
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
