// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

using Microsoft.Azure.WebJobs.Extensions.AuthenticationEvents;

namespace Microsoft.Azure.WebJobs.Extensions.AuthenticationEvents
{
    internal class TokenValidatorEZAuth : TokenValidator
    {
        internal override Task<Dictionary<string, string>> ValidateAndGetClaims(
            HttpRequestMessage request,
            ConfigurationManager configurationManager)
        {
            Dictionary<string, string> Claims = new Dictionary<string, string>();
            string principal = request.Headers.DecodeBase64(ConfigurationManager.HEADER_EZAUTH_PRINCIPAL);
            AuthenticationEventJsonElement jPrincipal = new AuthenticationEventJsonElement(principal);

            foreach (AuthenticationEventJsonElement jVal in jPrincipal.GetPropertyValue<AuthenticationEventJsonElement>("claims").Elements)
            {
                Claims.Add(jVal.GetPropertyValue("typ"), jVal.GetPropertyValue("val"));
            }

            SupportedTokenSchemaVersions tokenSchemaVersion = TokenValidatorHelper.ParseSupportedTokenVersion(Claims["ver"]);
            string authorizedPartyKey = tokenSchemaVersion == SupportedTokenSchemaVersions.V2_0 ? ConfigurationManager.AzpKey : ConfigurationManager.AppIdKey;

            TokenValidatorHelper.ValidateAuthorizationParty(configurationManager, Claims[authorizedPartyKey]);

            return Task.FromResult(Claims);
        }
    }
}
