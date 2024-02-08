// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Globalization;

namespace Microsoft.Azure.WebJobs.Extensions.AuthenticationEvents
{
    internal class ConfigurationManager
    {
        /// <summary>
        /// Application Ids for the services we support.
        /// </summary>
        public static ServiceInfo defaultService { get; private set; }

        private static readonly ServiceInfo AADServiceInfo = new()
        {
            OpenIdConnectionHost = "https://login.microsoftonline.com/common/v2.0/.well-known/openid-configuration",
            TokenIssuerV1 = "https://sts.windows.net/{0}/",
            TokenIssuerV2 = "https://login.microsoftonline.com/{0}/v2.0",
            ApplicationId = "99045fe1-7639-4a75-9d4a-577b6ca3810f"
        };

        private const string BYPASS_VALIDATION = "AuthenticationEvents__BypassTokenValidation";
        private const string EZAUTH_ENABLED = "WEBSITE_AUTH_ENABLED";

        internal const string OIDC_METADATA = "AuthenticationEvents__OpenIdConnectionHost";
        internal const string TOKEN_ISSUER= "AuthenticationEvents__TokenIssuer";
        internal const string TENANT_ID = "AuthenticationEvents__TenantId";
        internal const string AUDIENCE_APPID = "AuthenticationEvents__AudienceAppId";

        internal const string TOKEN_V1_VERIFY = "appid";
        internal const string TOKEN_V2_VERIFY = "azp";

        internal const string HEADER_EZAUTH_ICP = "X-MS-CLIENT-PRINCIPAL-IDP";
        internal const string HEADER_EZAUTH_ICP_VERIFY = "aad";
        internal const string HEADER_EZAUTH_PRINCIPAL = "X-MS-CLIENT-PRINCIPAL";

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
            string tid = GetConfigValue(TENANT_ID, triggerAttribute.TenantId);
            string appId = GetConfigValue(AUDIENCE_APPID, triggerAttribute.AudienceAppId);
            string oidc = GetConfigValue(OIDC_METADATA, triggerAttribute.OpenIdConnectionHost);
            string issuer = GetConfigValue(TOKEN_ISSUER, triggerAttribute.TokenIssuer);

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

        internal static bool BypassValidation => GetConfigValue(BYPASS_VALIDATION, false);

        internal static bool EZAuthEnabled => GetConfigValue(EZAUTH_ENABLED, false);

        internal string TenantId => GetConfigValue(TENANT_ID, triggerAttribute.TenantId);

        internal string AudienceAppId => GetConfigValue(AUDIENCE_APPID, triggerAttribute.AudienceAppId);

        internal string OpenIdConnectionHost => GetConfigValue(OIDC_METADATA, triggerAttribute.OpenIdConnectionHost);

        internal string TokenIssuer => GetConfigValue(TOKEN_ISSUER, triggerAttribute.TokenIssuer);

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

        internal static bool VerifyServiceId(string testId)
        {
            return TryGetService(testId, out _);
        }

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
