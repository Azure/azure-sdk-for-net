// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace Microsoft.Azure.WebJobs.Extensions.AuthenticationEvents
{
    internal class ConfigurationManager
    {
        public static Dictionary<string, ServiceInfo> SERVICES = new Dictionary<string, ServiceInfo>()
        {
            { "99045fe1-7639-4a75-9d4a-577b6ca3810f", new ServiceInfo("https://login.microsoftonline.com","https://sts.windows.net/{0}/","https://login.microsoftonline.com/{0}/v2.0"){DefaultService=true } } //Public cloud
        };

        private const string BYPASS_VALIDATION = "AuthenticationEvents__BypassTokenValidation";
        private const string CUSTOM_CALLER_APPID = "AuthenticationEvents__CustomCallerAppId";
        internal const string TENANT_ID = "AuthenticationEvents__TenantId";
        internal const string AUDIENCE_APPID = "AuthenticationEvents__AudienceAppId";
        internal const string TOKEN_V1_VERIFY = "appid";
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

        internal static bool GetService(string serviceId, out ServiceInfo serviceInfo)
        {
            serviceInfo = null;
            if (serviceId is null)
            {
                throw new ArgumentNullException(nameof(serviceId));
            }

            if (CallerAppId != null && serviceId.Equals(CallerAppId))
            {
                serviceInfo = SERVICES.Values.FirstOrDefault(x => x.DefaultService);
            }
            else if (SERVICES.ContainsKey(serviceId))
            {
                serviceInfo = SERVICES[serviceId];
            }

            return serviceInfo != null;
        }

        internal static bool VerifyServiceId(string testId)
        {
            return GetService(testId, out _);
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
