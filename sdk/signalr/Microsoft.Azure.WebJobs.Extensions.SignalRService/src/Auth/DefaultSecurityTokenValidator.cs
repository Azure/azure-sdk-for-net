// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Primitives;
using Microsoft.IdentityModel.Tokens;

namespace Microsoft.Azure.WebJobs.Extensions.SignalRService
{
    internal class DefaultSecurityTokenValidator : ISecurityTokenValidator
    {
        private const string AuthHeaderName = "Authorization";
        private const string BearerPrefix = "Bearer ";
        private readonly TokenValidationParameters _tokenValidationParameters = new();
        private readonly JwtSecurityTokenHandler _handler = new();

        public DefaultSecurityTokenValidator(Action<TokenValidationParameters> configureTokenValidationParameters)
        {
            if (configureTokenValidationParameters == null)
            {
                throw new ArgumentNullException(nameof(configureTokenValidationParameters));
            }
            configureTokenValidationParameters(_tokenValidationParameters);
        }

        public SecurityTokenResult ValidateToken(HttpRequest request)
        {
            try
            {
                var authHeader = default(StringValues);
                if (request?.Headers.TryGetValue(AuthHeaderName, out authHeader) == true)
                {
                    var authHeaderValue = authHeader.ToString();
                    if (authHeaderValue.StartsWith(BearerPrefix, StringComparison.OrdinalIgnoreCase))
                    {
                        var token = authHeaderValue.Substring(BearerPrefix.Length);
                        var principal = _handler.ValidateToken(token, _tokenValidationParameters, out _);

                        return SecurityTokenResult.Success(principal);
                    }
                }

                // token is null or whitespace
                return SecurityTokenResult.Empty();
            }
            catch (Exception ex) when (
                // 'exp' claim is less than DateTime.UtcNow
                ex is SecurityTokenExpiredException ||

                // 1. token's length is greater than TokenHandler.MaximumTokenSizeInBytes
                // 2. token does not have 3 or 5 parts
                // 3. token cannot be read
                ex is ArgumentException ||

                // 1. TokenValidationParameters.ValidAudience is null or whitespace and TokenValidationParameters.ValidAudiences is null. Audience is not validated if TokenValidationParameters.ValidateAudience is set to false.
                // 2. 'aud' claim did not match either TokenValidationParameters.ValidAudience or one of TokenValidationParameters.ValidAudiences.
                ex is SecurityTokenInvalidAudienceException ||

                // 'nbf' claim is greater than 'exp' claim
                ex is SecurityTokenInvalidLifetimeException ||

                    // Signature is not properly formatted.
                    ex is SecurityTokenInvalidSignatureException ||

                // 1. 'exp' claim is missing and TokenValidationParameters.RequireExpirationTime is true.
                // 2. TokenValidationParameters.TokenReplayCache is not null and expirationTime.HasValue is false. When a TokenReplayCache is set, tokens require an expiration time
                ex is SecurityTokenNoExpirationException ||

                // 'nbf' claim is greater than DateTime.UtcNow.
                ex is SecurityTokenNotYetValidException ||

                // token could not be added to the TokenValidationParameters.TokenReplayCache
                ex is SecurityTokenReplayAddFailedException ||

                // token is found in the cache
                ex is SecurityTokenReplayDetectedException)
            {
                return SecurityTokenResult.Error(ex);
            }
        }
    }
}