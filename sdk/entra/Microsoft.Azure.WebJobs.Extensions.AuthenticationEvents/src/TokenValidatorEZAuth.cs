// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.Azure.WebJobs.Extensions.AuthenticationEvents.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Microsoft.Azure.WebJobs.Extensions.AuthenticationEvents
{
    internal class TokenValidatorEZAuth : TokenValidator
    {
        internal override Task<(bool Valid, Dictionary<string, string> Claims)> GetClaimsAndValidate(HttpRequestMessage request, ConfigurationManager configurationManager)
        {
            Dictionary<string, string> Claims = new Dictionary<string, string>();
            try
            {
                string principal = request.Headers.DecodeBase64(ConfigurationManager.HEADER_EZAUTH_PRINCIPAL);
                AuthenticationEventJsonElement jPrincipal = new AuthenticationEventJsonElement(principal);

                foreach (AuthenticationEventJsonElement jVal in jPrincipal.GetPropertyValue<AuthenticationEventJsonElement>("claims").Elements)
                    Claims.Add(jVal.GetPropertyValue("typ"), jVal.GetPropertyValue("val"));

                SupportedTokenSchemaVersions tokenSchemaVersion = TokenValidatorHelper.ParseSupportedTokenVersion(Claims["ver"]);

                return Task.FromResult((Claims.Any(x => x.Key.Equals(tokenSchemaVersion == SupportedTokenSchemaVersions.V2_0 ? ConfigurationManager.TOKEN_V2_VERIFY : ConfigurationManager.TOKEN_V1_VERIFY) &&
                    ConfigurationManager.VerifyServiceId(x.Value)), Claims));
            }
            catch (Exception)
            {
                return Task.FromResult((false, Claims));
            }
        }
    }
}
