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
        internal const string UnexpectedResponse = "Managed Identity response was not in the expected format. See the inner exception for details.";
        private ManagedIdentityResponseClassifier _responseClassifier;

        protected ManagedIdentitySource(CredentialPipeline pipeline)
        {
            Pipeline = pipeline;
            _responseClassifier = new ManagedIdentityResponseClassifier();
        }

        protected internal CredentialPipeline Pipeline { get; }
        protected internal string ClientId { get; }

        public virtual async ValueTask<AccessToken> AuthenticateAsync(bool async, TokenRequestContext context, CancellationToken cancellationToken)
        {
            using HttpMessage message = CreateHttpMessage(CreateRequest(context.Scopes));
            if (async)
            {
                await Pipeline.HttpPipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            }
            else
            {
                Pipeline.HttpPipeline.Send(message, cancellationToken);
            }

            return await HandleResponseAsync(async, context, message.Response, cancellationToken).ConfigureAwait(false);
        }

        protected virtual async ValueTask<AccessToken> HandleResponseAsync(
            bool async,
            TokenRequestContext context,
            Response response,
            CancellationToken cancellationToken)
        {
            Exception exception = null;
            try
            {
                if (response.Status == 200)
                {
                    using JsonDocument json = async
                    ? await JsonDocument.ParseAsync(response.ContentStream, default, cancellationToken).ConfigureAwait(false)
                    : JsonDocument.Parse(response.ContentStream);

                    return GetTokenFromResponse(json.RootElement);
                }
            }
            catch (JsonException jex)
            {
                throw new CredentialUnavailableException(UnexpectedResponse, jex);
            }
            catch (Exception e)
            {
                exception = e;
            }

            //This is a special case for Docker Desktop which responds with a 403 with a message that contains "A socket operation was attempted to an unreachable network/host"
            // rather than just timing out, as expected.
            if (response.Status == 403)
            {
                string message = response.Content.ToString();
                if (message.Contains("unreachable"))
                {
                    throw new CredentialUnavailableException(UnexpectedResponse, new Exception(message));
                }
            }

            throw new RequestFailedException(response, exception);
        }

        protected abstract Request CreateRequest(string[] scopes);

        protected virtual HttpMessage CreateHttpMessage(Request request)
        {
            return new HttpMessage(request, _responseClassifier);
        }

        internal static async Task<string> GetMessageFromResponse(Response response, bool async, CancellationToken cancellationToken)
        {
            if (response?.ContentStream == null || !response.ContentStream.CanRead || response.ContentStream.Length == 0)
            {
                return null;
            }
            try
            {
                response.ContentStream.Position = 0;
                using JsonDocument json = async
                    ? await JsonDocument.ParseAsync(response.ContentStream, default, cancellationToken).ConfigureAwait(false)
                    : JsonDocument.Parse(response.ContentStream);

                return GetMessageFromResponse(json.RootElement);
            }
            catch // parsing failed
            {
                return "Response was not in a valid json format.";
            }
        }

        protected static string GetMessageFromResponse(in JsonElement root)
        {
            // Parse the error, if possible
            foreach (var prop in root.EnumerateObject())
            {
                if (prop.Name == "Message")
                {
                    return prop.Value.GetString();
                }
            }
            return null;
        }

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

        private class ManagedIdentityResponseClassifier : ResponseClassifier
        {
            public override bool IsRetriableResponse(HttpMessage message)
            {
                return message.Response.Status switch
                {
                    404 => true,
                    410 => true,
                    502 => false,
                    _ => base.IsRetriableResponse(message)
                };
            }
        }
    }
}
