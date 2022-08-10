// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.Azure.WebJobs.Extensions.AuthenticationEvents;
using Microsoft.IdentityModel.Protocols;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Microsoft.Azure.WebJobs.Extensions.AuthenticationEvents
{
    internal class InternalTokenValidator : TokenValidator
    {
        internal override async Task<(bool Valid, Dictionary<string, string> Claims)> GetClaimsAndValidate(HttpRequestMessage request, ConfigurationManager configurationManager)
        {
            if (string.IsNullOrEmpty(configurationManager.TenantId) || string.IsNullOrEmpty(configurationManager.AudienceAppId))
                throw new MissingFieldException(string.Format(CultureInfo.CurrentCulture, AuthEventResource.Ex_Trigger_Required_Attrs, ConfigurationManager.TENANT_ID, ConfigurationManager.AUDIENCE_APPID));

            string accessToken = request.Headers?.Authorization?.Parameter;

            if (string.IsNullOrWhiteSpace(accessToken))
                return (false, null);

            string[] authenticationAppIds = configurationManager.AudienceAppId.Split(';');

            var openIDConfManager = new ConfigurationManager<OpenIdConnectConfiguration>($"{configurationManager.OpenIdConnectHost}/common/v2.0/.well-known/openid-configuration", new OpenIdConnectConfigurationRetriever());
            var openIdConfig = await openIDConfManager.GetConfigurationAsync().ConfigureAwait(false);
            var handler = new JwtSecurityTokenHandler();

            JwtSecurityToken token = handler.ReadJwtToken(accessToken);
            SupportedTokenSchemaVersions tokenSchemaVersion = TokenValidatorHelper.ParseSupportedTokenVersion(token.Claims.First(x => x.Type.Equals("ver")).Value);

            try
            {
                var result = handler.ValidateToken(accessToken, new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateIssuerSigningKey = true,
                    ValidateLifetime = true,
                    ValidIssuer = string.Format(CultureInfo.CurrentCulture, tokenSchemaVersion == SupportedTokenSchemaVersions.V2_0 ?
                        ConfigurationManager.TOKEN_V2_ISSUER :
                        ConfigurationManager.TOKEN_V1_ISSUER, configurationManager.TenantId),
                    ValidAudiences = authenticationAppIds,
                    IssuerSigningKeys = openIdConfig.SigningKeys
                }, out _);

                //Here we validate the version and for version 1 validate that the appid claim matches the authorization party, if version 2, we validate that the azp claim matches the authorization party.
                return (result.Claims.VerifyClaim("ver", $"{tokenSchemaVersion.GetDescription()}") &&
                            result.Claims.VerifyClaim($"{(tokenSchemaVersion == SupportedTokenSchemaVersions.V2_0 ? ConfigurationManager.TOKEN_V2_VERIFY : ConfigurationManager.TOKEN_V1_VERIFY)}", ConfigurationManager.CallerAppId),
                        result.Claims.ToDictionary(x => x.Type, x => x.Value));
            }
            catch (Exception)
            {
                return (false, null);
            }
        }
    }
}
