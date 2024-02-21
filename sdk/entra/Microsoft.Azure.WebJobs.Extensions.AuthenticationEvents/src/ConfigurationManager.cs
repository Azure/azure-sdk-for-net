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
        private const string AzureActiveDirectoryAppId = "99045fe1-7639-4a75-9d4a-577b6ca3810f";
        private const string AzureActiveDirectoryAuthority = "https://login.microsoftonline.com/common";

        /// <summary>
        /// Application Ids for the services to validate against.
        /// </summary>
        internal ServiceInfo ConfiguredService { get; private set; }

        private const string EZAUTH_ENABLED = "WEBSITE_AUTH_ENABLED";
        private const string BYPASS_VALIDATION_KEY = "AuthenticationEvents__BypassTokenValidation";

        private const string AUTHORITY_URL = "AuthenticationEvents__AuthorityUrl";
        private const string TENANT_ID_KEY = "AuthenticationEvents__TenantId";
        private const string AUDIENCE_APPID_KEY = "AuthenticationEvents__AudienceAppId";

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

            // if any of the values are missing, use the default AAD service info.
            // Don't need to check tenant id or application id
            // because they are required and will throw an exception if missing.
            if (string.IsNullOrEmpty(AuthorityUrl))
            {
                // Continue to support the aad as the default service if overrides not provided.
                ConfiguredService = GetAADServiceInfo(TenantId);
            }
            else
            {
                ConfiguredService = new ServiceInfo(
                    appId: AudienceAppId,
                    authorityUrl: AuthorityUrl);
            }
        }

        /// <summary>
        /// Get the tenant id from the environment variable or use the default value from the trigger attribute.
        /// </summary>
        internal string TenantId
        {
            get
            {
                string value = GetConfigValue(TENANT_ID_KEY, triggerAttribute?.TenantId);

                if (string.IsNullOrEmpty(value))
                {
                    throw new MissingFieldException(
                        string.Format(
                            provider: CultureInfo.CurrentCulture,
                            format: AuthenticationEventResource.Ex_Trigger_TenantId_Required,
                            arg0: TENANT_ID_KEY));
                }

                return value;
            }
        }

        /// <summary>
        /// Get the audience app id from the environment variable or use the default value from the trigger attribute.
        /// </summary>
        internal string AudienceAppId
        {
            get
            {
                string value = GetConfigValue(AUDIENCE_APPID_KEY, triggerAttribute?.AudienceAppId);

                if (string.IsNullOrEmpty(value))
                {
                    throw new MissingFieldException(
                        string.Format(
                            provider: CultureInfo.CurrentCulture,
                            format: AuthenticationEventResource.Ex_Trigger_ApplicationId_Required,
                            arg0: AUDIENCE_APPID_KEY));
                }

                return value;
            }
        }

        /// <summary>
        /// Get the OpenId connection host from the environment variable or use the default value.
        /// </summary>
        internal string AuthorityUrl => GetConfigValue(AUTHORITY_URL, triggerAttribute?.AuthorityUrl);

        /// <summary>
        /// If we should bypass the token validation.
        /// Use only for testing and development.
        /// </summary>
        internal bool BypassValidation => GetConfigValue(BYPASS_VALIDATION_KEY, false);

        /// <summary>
        /// If the EZAuth is enabled.
        /// </summary>
        internal bool EZAuthEnabled => GetConfigValue(EZAUTH_ENABLED, false);

        /// <summary>
        /// Try to get the service info based on the service id.
        /// </summary>
        /// <param name="appId">The service id to look for.</param>
        /// <param name="serviceInfo">The service info we found based on the service id.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        internal bool TryGetServiceByAppId(string appId, out ServiceInfo serviceInfo)
        {
            serviceInfo = null;

            if (appId is null)
            {
                throw new ArgumentNullException(nameof(appId));
            }

            if (appId.Equals(ConfiguredService.ApplicationId, StringComparison.OrdinalIgnoreCase))
            {
                serviceInfo = ConfiguredService;
                return true;
            }

            return serviceInfo != null;
        }

        /// <summary>
        /// Verify if the service id is valid by checking if we have the service info for it.
        /// </summary>
        /// <param name="testId"></param>
        /// <returns></returns>
        internal bool VerifyServiceId(string testId)
        {
            return TryGetServiceByAppId(testId, out _);
        }

        /// <summary>
        /// Get config value from environment variable or use the default value.
        /// </summary>
        /// <param name="environmentVariable">Definied Azure function application settings</param>
        /// <param name="defaultValue">Default value, most likely from auth trigger anotation</param>
        /// <returns></returns>
        private static string GetConfigValue(string environmentVariable, string defaultValue)
        {
            return Environment.GetEnvironmentVariable(environmentVariable) ?? defaultValue;
        }

        private static T GetConfigValue<T>(string environmentVariable, T defaultValue) where T : struct
        {
            string value = GetConfigValue(environmentVariable, null);

            return value == null ?
                defaultValue :
                (T)Convert.ChangeType(
                    value: Environment.GetEnvironmentVariable(environmentVariable),
                    conversionType: typeof(T),
                    provider: CultureInfo.CurrentCulture);
        }

        private static ServiceInfo GetAADServiceInfo(string tenantId)
        {
            /* The authority URL is based on the tenant id. if we provide common, it returns a template version of the issure URL.
             * But if we were to provide the actual tenant id, it will return the actual issuer URL with the tenant id in the issure string.
             * Examples below using a random GUID: fa1f83dc-7b13-456e-8358-ba27aebd79ad
             * https://login.windows.net/common/.well-known/openid-configuration : "https://sts.windows.net/{tenantid}/"
             * https://login.windows.net/common/v2.0/.well-known/openid-configuration : "https://login.microsoftonline.com/{tenantid}/v2.0"
             * https://login.windows.net/fa1f83dc-7b13-456e-8358-ba27aebd79ad/.well-known/openid-configuration : "https://sts.windows.net/fa1f83dc-7b13-456e-8358-ba27aebd79ad/"
             * https://login.windows.net/fa1f83dc-7b13-456e-8358-ba27aebd79ad/v2.0/.well-known/openid-configuration : "https://login.microsoftonline.com/fa1f83dc-7b13-456e-8358-ba27aebd79ad/v2.0"
             */

            return new ServiceInfo(
                appId: AzureActiveDirectoryAppId,
                authorityUrl: AzureActiveDirectoryAuthority + "/" + tenantId);
        }
    }
}
