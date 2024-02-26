// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.Azure.WebJobs.Extensions.AuthenticationEvents;
using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net.Http;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;

namespace Microsoft.Azure.WebJobs.Extensions.AuthenticationEvents
{
    internal class TokenValidatorInternal : TokenValidator
    {
        internal async override Task<(bool Valid, Dictionary<string, string> Claims)> ValidateAndGetClaims(
            HttpRequestMessage request,
            ConfigurationManager configurationManager)
        {
            string accessToken = request.Headers?.Authorization?.Parameter;

            if (string.IsNullOrWhiteSpace(accessToken))
            {
                return (false, null);
            }

            JsonWebToken jsonWebToken = new JsonWebToken(accessToken);
            SupportedTokenSchemaVersions tokenSchemaVersion = TokenValidatorHelper.ParseSupportedTokenVersion(jsonWebToken.Claims.First(x => x.Type.Equals("ver")).Value);

            string authorizedPartyKey = tokenSchemaVersion == SupportedTokenSchemaVersions.V2_0 ? ConfigurationManager.AzpKey : ConfigurationManager.AppIdKey;
            jsonWebToken.TryGetPayloadValue(authorizedPartyKey, out string authorizedPartyValue);

            if (TokenValidatorHelper.ValidateAuthorizationParty(configurationManager, authorizedPartyValue) == false)
            {
                return (false, null);
            }

            try
            {
                string oidcConfigAddress = configurationManager.GetOpenIDConfigurationUrlString(tokenSchemaVersion);

                OpenIdConnectConfiguration oidcConfig =
                    await OpenIdConnectConfigurationRetriever.GetAsync(
                        address: oidcConfigAddress,
                        cancel: CancellationToken.None).ConfigureAwait(false);

                if (oidcConfig == null)
                {
                    return (false, null);
                }

                var handler = new JwtSecurityTokenHandler();

                ClaimsPrincipal result = handler.ValidateToken(
                    token: accessToken,
                    validationParameters: new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = oidcConfig.Issuer,
                        ValidAudience = configurationManager.AudienceAppId,
                        IssuerSigningKeys = oidcConfig.SigningKeys,
                    },
                    validatedToken: out _);

                return (true, result.Claims.ToDictionary(x => x.Type, x => x.Value));
            }
            catch (Exception)
            {
                return (false, null);
            }
        }
    }
}
