// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.Azure.WebJobs.Extensions.AuthenticationEvents.Framework;
using Microsoft.IdentityModel.JsonWebTokens;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Microsoft.Azure.WebJobs.Extensions.AuthenticationEvents
{
    internal class TokenValidatorEZAuth : TokenValidator
    {
        internal override Task<(bool Valid, Dictionary<string, string> Claims)> ValidateAndGetClaims(
            HttpRequestMessage request,
            ConfigurationManager configurationManager)
        {
            Dictionary<string, string> Claims = new Dictionary<string, string>();
            try
            {
                string principal = request.Headers.DecodeBase64(ConfigurationManager.HEADER_EZAUTH_PRINCIPAL);
                AuthenticationEventJsonElement jPrincipal = new AuthenticationEventJsonElement(principal);

                foreach (AuthenticationEventJsonElement jVal in jPrincipal.GetPropertyValue<AuthenticationEventJsonElement>("claims").Elements)
                {
                    Claims.Add(jVal.GetPropertyValue("typ"), jVal.GetPropertyValue("val"));
                }

                SupportedTokenSchemaVersions tokenSchemaVersion = TokenValidatorHelper.ParseSupportedTokenVersion(Claims["ver"]);
                string authorizedPartyKey = tokenSchemaVersion == SupportedTokenSchemaVersions.V2_0 ? ConfigurationManager.AzpKey : ConfigurationManager.AppIdKey;

                return Task.FromResult((configurationManager.ValidateAuthorizationParty(Claims[authorizedPartyKey]), Claims));
            }
            catch (Exception)
            {
                return Task.FromResult((false, Claims));
            }
        }
    }
}
