// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;

namespace Azure.Identity
{
    internal class ManagedIdentityClient
    {
        internal const string AuthenticationResponseInvalidFormatError = "Invalid response, the authentication response was not in the expected format.";
        internal const string MsiUnavailableError = "ManagedIdentityCredential authentication unavailable. No Managed Identity endpoint found.";

        private readonly AsyncLockWithValue<IManagedIdentitySource> _identitySourceAsyncLock = new AsyncLockWithValue<IManagedIdentitySource>();
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

        public virtual async ValueTask<AccessToken> AuthenticateAsync(bool async, string[] scopes, CancellationToken cancellationToken)
        {
            IManagedIdentitySource identitySource = await GetManagedIdentitySourceAsync(async, cancellationToken).ConfigureAwait(false);

            // if msi is unavailable or we were unable to determine the type return CredentialUnavailable exception that no endpoint was found
            if (identitySource == default)
            {
                throw new CredentialUnavailableException(MsiUnavailableError);
            }

            using Request request = identitySource.CreateRequest(scopes);
            Response response = async
                ? await _pipeline.HttpPipeline.SendRequestAsync(request, cancellationToken).ConfigureAwait(false)
                : _pipeline.HttpPipeline.SendRequest(request, cancellationToken);

            if (response.Status == 200)
            {
                using JsonDocument json = async
                    ? await JsonDocument.ParseAsync(response.ContentStream, default, cancellationToken).ConfigureAwait(false)
                    : JsonDocument.Parse(response.ContentStream);

                (JsonElement accessToken, JsonElement expiresOnProp) = GetAccessTokenProperties(json.RootElement);
                return identitySource.GetAccessTokenFromJson(accessToken, expiresOnProp);
            }

            await identitySource.HandleFailedRequestAsync(response, _pipeline.Diagnostics, async).ConfigureAwait(false);

            throw async
                ? await _pipeline.Diagnostics.CreateRequestFailedExceptionAsync(response).ConfigureAwait(false)
                : _pipeline.Diagnostics.CreateRequestFailedException(response);
        }

        private protected virtual async ValueTask<IManagedIdentitySource> GetManagedIdentitySourceAsync(bool async, CancellationToken cancellationToken)
        {
            using var asyncLock = await _identitySourceAsyncLock.GetLockOrValueAsync(async, cancellationToken).ConfigureAwait(false);
            if (asyncLock.HasValue)
            {
                return asyncLock.Value;
            }

            IManagedIdentitySource identitySource = AppServiceV2019ManagedIdentitySource.TryCreate(_pipeline.HttpPipeline, ClientId) ??
                                                    AppServiceV2017ManagedIdentitySource.TryCreate(_pipeline.HttpPipeline, ClientId) ??
                                                    CloudShellManagedIdentitySource.TryCreate(_pipeline.HttpPipeline, ClientId) ??
                                                    await ImdsManagedIdentitySource.TryCreateAsync(_pipeline.HttpPipeline, ClientId, async, cancellationToken).ConfigureAwait(false);

            asyncLock.SetValue(identitySource);
            return identitySource;
        }

        private static (JsonElement accessToken, JsonElement expiresOnProp) GetAccessTokenProperties(in JsonElement root)
        {
            JsonElement? accessToken = null;
            JsonElement? expiresOnProp = null;

            foreach (JsonProperty prop in root.EnumerateObject())
            {
                switch (prop.Name)
                {
                    case "access_token":
                        accessToken = prop.Value;
                        break;

                    case "expires_on":
                        expiresOnProp = prop.Value;
                        break;
                }
            }

            return accessToken.HasValue && expiresOnProp.HasValue
                ? (accessToken.Value, expiresOnProp.Value)
                : throw new AuthenticationFailedException(AuthenticationResponseInvalidFormatError);
        }
    }
}
