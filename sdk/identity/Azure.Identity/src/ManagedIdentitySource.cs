// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Globalization;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;

namespace Azure.Identity
{
    internal abstract class ManagedIdentitySource
    {
        internal const string AuthenticationResponseInvalidFormatError = "Invalid response, the authentication response was not in the expected format.";

        protected ManagedIdentitySource(CredentialPipeline pipeline)
        {
            Pipeline = pipeline;
        }

        protected internal CredentialPipeline Pipeline { get; }
        protected internal string ClientId { get; }

        public virtual async ValueTask<AccessToken> AuthenticateAsync(bool async, TokenRequestContext context, CancellationToken cancellationToken)
        {
            using Request request = CreateRequest(context.Scopes);
            Response response = async
                ? await Pipeline.HttpPipeline.SendRequestAsync(request, cancellationToken).ConfigureAwait(false)
                : Pipeline.HttpPipeline.SendRequest(request, cancellationToken);

            return await HandleResponseAsync(async, context, response, cancellationToken).ConfigureAwait(false);
        }

        protected virtual async ValueTask<AccessToken> HandleResponseAsync(bool async, TokenRequestContext context, Response response, CancellationToken cancellationToken)
        {
            if (response.Status == 200)
            {
                using JsonDocument json = async
                    ? await JsonDocument.ParseAsync(response.ContentStream, default, cancellationToken).ConfigureAwait(false)
                    : JsonDocument.Parse(response.ContentStream);

                return GetTokenFromResponse(json.RootElement);
            }

            throw async
                ? await Pipeline.Diagnostics.CreateRequestFailedExceptionAsync(response).ConfigureAwait(false)
                : Pipeline.Diagnostics.CreateRequestFailedException(response);
        }

        protected abstract Request CreateRequest(string[] scopes);

        private static AccessToken GetTokenFromResponse(in JsonElement root)
        {
            string accessToken = null;
            DateTimeOffset? expiresOn = null;

            foreach (JsonProperty prop in root.EnumerateObject())
            {
                switch (prop.Name)
                {
                    case "access_token":
                        accessToken = prop.Value.GetString();
                        break;

                    case "expires_on":
                        expiresOn = TryParseExpiresOn(prop.Value);
                        break;
                }
            }

            return accessToken != null && expiresOn.HasValue
                ? new AccessToken(accessToken, expiresOn.Value)
                : throw new AuthenticationFailedException(AuthenticationResponseInvalidFormatError);
        }

        private static DateTimeOffset? TryParseExpiresOn(JsonElement jsonExpiresOn)
        {
            // first test if expiresOn is a unix timestamp either as a number or string
            if (jsonExpiresOn.ValueKind == JsonValueKind.Number && jsonExpiresOn.TryGetInt64(out long expiresOnSec) ||
                jsonExpiresOn.ValueKind == JsonValueKind.String && long.TryParse(jsonExpiresOn.GetString(), out expiresOnSec))
            {
                return DateTimeOffset.FromUnixTimeSeconds(expiresOnSec);
            }
            // otherwise if it is a json string try to parse as a datetime offset
            else if (jsonExpiresOn.ValueKind == JsonValueKind.String && DateTimeOffset.TryParse(jsonExpiresOn.GetString(), CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTimeOffset expiresOn))
            {
                return expiresOn;
            }

            return null;
        }
    }
}
