// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net.Http;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;

using Microsoft.Azure.WebJobs.Extensions.AuthenticationEvents;
using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Logging;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using Microsoft.IdentityModel.Tokens;

namespace Microsoft.Azure.WebJobs.Extensions.AuthenticationEvents
{
    internal class TokenValidatorInternal : TokenValidator
    {
        internal async override Task<Dictionary<string, string>> ValidateAndGetClaims(
            HttpRequestMessage request,
            ConfigurationManager configurationManager)
        {
            IdentityModelEventSource.ShowPII = ConfigurationManager.ShowPIIDataInLogs;

            string accessToken = request.Headers?.Authorization?.Parameter;

            if (string.IsNullOrWhiteSpace(accessToken))
            {
                throw new UnauthorizedAccessException("No Access Token in request found.");
            }

            JsonWebToken jsonWebToken = new JsonWebToken(accessToken);
            SupportedTokenSchemaVersions tokenSchemaVersion = TokenValidatorHelper.ParseSupportedTokenVersion(jsonWebToken.Claims.First(x => x.Type.Equals("ver")).Value);

            string authorizedPartyKey = tokenSchemaVersion == SupportedTokenSchemaVersions.V2_0 ? ConfigurationManager.AzpKey : ConfigurationManager.AppIdKey;
            jsonWebToken.TryGetPayloadValue(authorizedPartyKey, out string authorizedPartyValue);

            TokenValidatorHelper.ValidateAuthorizationParty(configurationManager, authorizedPartyValue);

            string oidcConfigAddress = configurationManager.GetOpenIDConfigurationUrlString(tokenSchemaVersion);

            OpenIdConnectConfiguration oidcConfig =
                await OpenIdConnectConfigurationRetriever.GetAsync(
                    address: oidcConfigAddress,
                    cancel: CancellationToken.None).ConfigureAwait(false);

            if (oidcConfig == null)
            {
                throw new UnauthorizedAccessException($"Not able to retrive Open ID Configuration '{oidcConfig}' with configured Authority URL '{configurationManager.AuthorityUrl}'. Please verify Authority URL.");
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

            return result.Claims.ToDictionary(x => x.Type, x => x.Value);
        }
    }
}
