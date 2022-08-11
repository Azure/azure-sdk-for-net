// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Globalization;
using System.Linq;

namespace Microsoft.Azure.WebJobs.Extensions.AuthenticationEvents
{
    internal class ConfigurationManager
    {
        private readonly string[] SERVICE_IDs = new string[] { "99045fe1-7639-4a75-9d4a-577b6ca3810f" };
        internal const string OPENID_CONNECTHOST = "https://login.microsoftonline.com";
        private const string BYPASS_VALIDATION = "AuthenticationEvents__BypassTokenValidation";
        private const string CUSTOM_CALLER_APPID = "AuthenticationEvents__CustomCallerAppId";
        internal const string TENANT_ID = "AuthenticationEvents__TenantId";
        internal const string AUDIENCE_APPID = "AuthenticationEvents__AudienceAppId";
        internal const string TOKEN_V1_ISSUER = "https://sts.windows.net/{0}/";
        internal const string TOKEN_V1_VERIFY = "appid";
        internal const string TOKEN_V2_ISSUER = "https://login.microsoftonline.com/{0}/v2.0";
        internal const string TOKEN_V2_VERIFY = "azp";
        private const string EZAUTH_ENABLED = "WEBSITE_AUTH_ENABLED";
        internal const string HEADER_EZAUTH_ICP = "X-MS-CLIENT-PRINCIPAL-IDP";
        internal const string HEADER_EZAUTH_ICP_VERIFY = "aad";
        internal const string HEADER_EZAUTH_PRINCIPAL = "X-MS-CLIENT-PRINCIPAL";

        private readonly AuthenticationEventsTriggerAttribute triggerAttribute;
        internal ConfigurationManager(AuthenticationEventsTriggerAttribute triggerAttribute)
        {
            this.triggerAttribute = triggerAttribute;
        }

        internal static bool BypassValidation => GetConfigValue(BYPASS_VALIDATION, false);
        internal static bool EZAuthEnabled => GetConfigValue(EZAUTH_ENABLED, false);
        internal static string CallerAppId => GetConfigValue(CUSTOM_CALLER_APPID, null);
        internal string TenantId => GetConfigValue(TENANT_ID, triggerAttribute.TenantId);
        internal string AudienceAppId => GetConfigValue(AUDIENCE_APPID, triggerAttribute.AudienceAppId);
        internal string OpenIdConnectHost => triggerAttribute.OpenIdConnectHost;

        internal bool VerifyServiceId(string testId)
        {
            if (CallerAppId != null)
                return testId.Equals(CallerAppId);
            else if (string.IsNullOrEmpty(ConfigurationPersistant.SERVICE_ID))
            {
                string validId = SERVICE_IDs.FirstOrDefault(x => x.Equals(testId));
                if (!string.IsNullOrEmpty(validId))
                    ConfigurationPersistant.SERVICE_ID = validId;
            }

            return testId.Equals(ConfigurationPersistant.SERVICE_ID);
        }

        private static string GetConfigValue(string enviromentVariable, string defaultValue)
        {
            return Environment.GetEnvironmentVariable(enviromentVariable) ?? defaultValue;
        }

        private static T GetConfigValue<T>(string enviromentVariable, T defaultValue) where T : struct
        {
            return Environment.GetEnvironmentVariable(enviromentVariable) == null ?
                defaultValue :
                (T)Convert.ChangeType(Environment.GetEnvironmentVariable(enviromentVariable), typeof(T), CultureInfo.CurrentCulture);
        }
    }
}
