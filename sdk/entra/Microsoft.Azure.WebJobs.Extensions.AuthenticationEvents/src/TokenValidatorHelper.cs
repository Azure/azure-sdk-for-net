// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Globalization;
using System.Linq;
using System.Net.Http.Headers;

namespace Microsoft.Azure.WebJobs.Extensions.AuthenticationEvents
{
    /// <summary>Helper functions for token validations.</summary>
    internal static class TokenValidatorHelper
    {
        public static SupportedTokenSchemaVersions ParseSupportedTokenVersion(string version)
        {
            string[] v1 = { "1.0", "1", "ver1" };
            string[] v2 = { "2.0", "2", "ver2" };
            if (v1.Contains(version))
            {
                return SupportedTokenSchemaVersions.V1_0;
            }
            else if (v2.Contains(version))
            {
                return SupportedTokenSchemaVersions.V2_0;
            }
            else
            {
                throw new ArgumentException(
                    string.Format(
                        provider: CultureInfo.CurrentCulture,
                        format: AuthenticationEventResource.Ex_Token_Version,
                        arg0: version,
                        arg1: string.Join(",", Enum.GetNames(typeof(SupportedTokenSchemaVersions)))));
            }
        }

        /// <summary>
        /// Checks wheather the header has the correct values for ezauth.
        /// </summary>
        /// <param name="headers"><see cref="HttpRequestHeaders"/> headers to check in.</param>
        /// <returns>True if ezauth is valid</returns>
        internal static bool IsEzAuthValid(HttpRequestHeaders headers)
        {
            return ConfigurationManager.EZAuthEnabled && headers.Matches(ConfigurationManager.HEADER_EZAUTH_ICP, ConfigurationManager.HEADER_EZAUTH_ICP_VERIFY);
        }

        /// <summary>
        /// Validate the authorization party is accurate to the one in configuration.
        /// </summary>
        /// <param name="configurationManager"></param>
        /// <param name="authoizedPartyValueFromTokenOrHeader">The value from either the token or the header.</param>
        internal static void ValidateAuthorizationParty(ConfigurationManager configurationManager, string authoizedPartyValueFromTokenOrHeader)
        {
            if (configurationManager.AuthorizedPartyAppId.EqualsOic(authoizedPartyValueFromTokenOrHeader))
            {
                return;
            }

            throw new UnauthorizedAccessException(
                string.Format(
                    provider: CultureInfo.CurrentCulture,
                    format: AuthenticationEventResource.Ex_Invalid_AuthorizedPartyApplicationId,
                    arg0: authoizedPartyValueFromTokenOrHeader,
                    arg1: configurationManager.AuthorizedPartyAppId));
        }
    }
}
