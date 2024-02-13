// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Globalization;

namespace Microsoft.Azure.WebJobs.Extensions.AuthenticationEvents
{
    /// <summary>
    /// Configuration manager for loading up token validations.
    /// </summary>
    internal class ConfigurationManager
    {
        /// <summary>
        /// Application Ids for the services we support.
        /// </summary>
        public static ServiceInfo defaultService { get; private set; }

        /// <summary>
        /// AAD Service Info.
        /// </summary>
        private static readonly ServiceInfo AADServiceInfo = new()
        {
            OpenIdConnectionHost = "https://login.microsoftonline.com/common/v2.0/.well-known/openid-configuration",
            TokenIssuerV1 = "https://sts.windows.net/{0}/",
            TokenIssuerV2 = "https://login.microsoftonline.com/{0}/v2.0",
            ApplicationId = "99045fe1-7639-4a75-9d4a-577b6ca3810f"
        };

        private const string EZAUTH_ENABLED = "WEBSITE_AUTH_ENABLED";

        private const string BYPASS_VALIDATION_KEY = "AuthenticationEvents__BypassTokenValidation";
        private const string OIDC_METADATA_KEY = "AuthenticationEvents__OpenIdConnectionHost";
        private const string TOKEN_ISSUER_KEY = "AuthenticationEvents__TokenIssuer";

        internal const string TENANT_ID_KEY = "AuthenticationEvents__TenantId";
        internal const string AUDIENCE_APPID_KEY = "AuthenticationEvents__AudienceAppId";

        internal const string TOKEN_V1_VERIFY = "appid";
        internal const string TOKEN_V2_VERIFY = "azp";

        internal const string HEADER_EZAUTH_ICP = "X-MS-CLIENT-PRINCIPAL-IDP";
        internal const string HEADER_EZAUTH_ICP_VERIFY = "aad";
        internal const string HEADER_EZAUTH_PRINCIPAL = "X-MS-CLIENT-PRINCIPAL";

        /// <summary>
        /// Annotation for the trigger attribute.
        /// </summary>
        private readonly AuthenticationEventsTriggerAttribute triggerAttribute;

        internal ConfigurationManager(AuthenticationEventsTriggerAttribute triggerAttribute)
        {
            this.triggerAttribute = triggerAttribute;
            CheckForServiceInfoConfigValues();
        }

        /// <summary>
        /// Check if there are any service info values in the custom configurations (environment variables or triggerAttribute).
        /// if not, use the default AAD service info.
        /// if all are there, use the custom service info.
        /// </summary>
        public void CheckForServiceInfoConfigValues()
        {
            // Get the configuration values from the environment variables or use the values triggerAttribute.
            string tid = TenantId;
            string appId = AudienceAppId;
            string oidc = OpenIdConnectionHost;
            string issuer = TokenIssuer;

            // if any of the values are missing, use the default AAD service info.
            if (string.IsNullOrEmpty(tid)
                || string.IsNullOrEmpty(appId)
                || string.IsNullOrEmpty(oidc)
                || string.IsNullOrEmpty(issuer))
            {
                defaultService = AADServiceInfo;
            }
            else
            {
                defaultService = new ServiceInfo
                {
                    OpenIdConnectionHost = oidc,
                    TokenIssuerV1 = issuer,
                    TokenIssuerV2 = issuer,
                    ApplicationId = appId
                };
            }
        }

        /// <summary>
        /// If we should bypass the token validation.
        /// Use only for testing and development.
        /// </summary>
        internal static bool BypassValidation => GetConfigValue(BYPASS_VALIDATION_KEY, false);

        /// <summary>
        /// If the EZAuth is enabled.
        /// </summary>
        internal static bool EZAuthEnabled => GetConfigValue(EZAUTH_ENABLED, false);

        /// <summary>
        /// Get the tenant id from the environment variable or use the default value.
        /// </summary>
        internal string TenantId => GetConfigValue(TENANT_ID_KEY, triggerAttribute.TenantId);

        /// <summary>
        /// Get the audience app id from the environment variable or use the default value.
        /// </summary>
        internal string AudienceAppId => GetConfigValue(AUDIENCE_APPID_KEY, triggerAttribute.AudienceAppId);

        /// <summary>
        /// Get the OpenId connection host from the environment variable or use the default value.
        /// </summary>
        internal string OpenIdConnectionHost => GetConfigValue(OIDC_METADATA_KEY, triggerAttribute.OpenIdConnectionHost);

        /// <summary>
        /// Get the token issuer from the environment variable or use the default value.
        /// </summary>
        internal string TokenIssuer => GetConfigValue(TOKEN_ISSUER_KEY, triggerAttribute.TokenIssuer);

        /// <summary>
        /// Try to get the service info based on the service id.
        /// </summary>
        /// <param name="serviceId">The service id to look for.</param>
        /// <param name="serviceInfo">The service info we found based on the service id.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        internal static bool TryGetService(string serviceId, out ServiceInfo serviceInfo)
        {
            serviceInfo = null;

            if (serviceId is null)
            {
                throw new ArgumentNullException(nameof(serviceId));
            }

            if (serviceId.Equals(defaultService.ApplicationId, StringComparison.OrdinalIgnoreCase))
            {
                serviceInfo = defaultService;
                return true;
            }

            return serviceInfo != null;
        }

        /// <summary>
        /// Verify if the service id is valid by checking if we have the service info for it.
        /// </summary>
        /// <param name="testId"></param>
        /// <returns></returns>
        internal static bool VerifyServiceId(string testId)
        {
            return TryGetService(testId, out _);
        }

        /// <summary>
        /// Get config value from environment variable or use the default value.
        /// </summary>
        /// <param name="environmentVariable"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        private static string GetConfigValue(string environmentVariable, string defaultValue)
        {
            return Environment.GetEnvironmentVariable(environmentVariable) ?? defaultValue;
        }

        private static T GetConfigValue<T>(string environmentVariable, T defaultValue) where T : struct
        {
            return Environment.GetEnvironmentVariable(environmentVariable) == null ?
                defaultValue :
                (T)Convert.ChangeType(Environment.GetEnvironmentVariable(environmentVariable), typeof(T), CultureInfo.CurrentCulture);
        }
    }
}
