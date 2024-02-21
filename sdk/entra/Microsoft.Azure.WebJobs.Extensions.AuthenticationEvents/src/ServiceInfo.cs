// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Microsoft.Azure.WebJobs.Extensions.AuthenticationEvents
{
    /// <summary>
    /// The services we support and their configuration.
    /// </summary>
    internal class ServiceInfo
    {
        private const string OpenIdConfigurationPath = "/.well-known/openid-configuration";
        private const string OpenIdConfigurationPathV2 = "/v2.0/.well-known/openid-configuration";

        public ServiceInfo(
            string appId,
            string authorityUrl)
        {
            ApplicationId = appId;
            Authority = authorityUrl;
        }

        /// <summary>
        /// The Application Id of the custom extension. This is the audience of the token.
        /// </summary>
        internal string ApplicationId { get; private set; }

        /// <summary>
        /// The authority is a URL that indicates a directory that the tokens from.
        /// </summary>
        internal string Authority { get; private set; }

        /// <summary>
        /// Get the issuer string based on the token schema version.
        /// </summary>
        /// <param name="tokenSchemaVersion">v2 will return v2 odic url, v1 will return v1</param>
        /// <returns></returns>
        internal string GetOpenIDConfigurationUrlString(SupportedTokenSchemaVersions tokenSchemaVersion)
        {
            return tokenSchemaVersion == SupportedTokenSchemaVersions.V2_0 ?
                this.Authority + OpenIdConfigurationPathV2 :
                this.Authority + OpenIdConfigurationPath;
        }
    }
}