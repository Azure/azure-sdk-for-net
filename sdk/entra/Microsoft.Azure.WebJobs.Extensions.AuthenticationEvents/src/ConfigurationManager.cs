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

        private const string EZAUTH_ENABLED = "WEBSITE_AUTH_ENABLED";
        private const string BYPASS_VALIDATION_KEY = "AuthenticationEvents__BypassTokenValidation";

        private const string OIDC_METADATA_KEY = "AuthenticationEvents__OpenIdConnectionHost";
        private const string TOKEN_ISSUER_V1_KEY = "AuthenticationEvents__TokenIssuer_V1";
        private const string TOKEN_ISSUER_V2_KEY = "AuthenticationEvents__TokenIssuer_V2";
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
            CheckForCustomServiceInfoConfigValues();
        }

        /// <summary>
        /// Check if there are any service info values in the custom configurations (environment variables or triggerAttribute).
        /// if not, use the default AAD service info.
        /// if all are there, use the custom service info.
        /// </summary>
        private void CheckForCustomServiceInfoConfigValues()
        {
            // if any of the values are missing, use the default AAD service info.
            // Don't need to check tenant id or application id
            // because they are required and will throw an exception if missing.
            if (string.IsNullOrEmpty(OpenIdConnectionHost)
                || string.IsNullOrEmpty(TokenIssuerV1)
                || string.IsNullOrEmpty(TokenIssuerV2))
            {
                // Continue to support the aad as the default service if overrides not provided.
                defaultService = GetAADServiceInfo(TenantId);
            }
            else
            {
                defaultService = new ServiceInfo
                {
                    TenantId = TenantId,
                    ApplicationId = AudienceAppId,
                    OpenIdConnectionHost = OpenIdConnectionHost,
                    TokenIssuerV1 = TokenIssuerV1,
                    TokenIssuerV2 = TokenIssuerV2,
                    IsDefault = false
                };
            }
        }

        /// <summary>
        /// Get the tenant id from the environment variable or use the default value from the trigger attribute.
        /// </summary>
        internal string TenantId
        {
            get
            {
                string value = GetConfigValue(TENANT_ID_KEY, triggerAttribute.TenantId);

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
                string value = GetConfigValue(AUDIENCE_APPID_KEY, triggerAttribute.AudienceAppId);

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
        internal string OpenIdConnectionHost => GetConfigValue(OIDC_METADATA_KEY, triggerAttribute.OpenIdConnectionHost);

        /// <summary>
        /// Get the token issuer from the environment variable or use the default value.
        /// </summary>
        internal string TokenIssuerV1 => GetConfigValue(TOKEN_ISSUER_V1_KEY, triggerAttribute.TokenIssuer);

        /// <summary>
        /// Get the token issuer from the environment variable or use the default value.
        /// </summary>
        internal string TokenIssuerV2 => GetConfigValue(TOKEN_ISSUER_V2_KEY, triggerAttribute.TokenIssuer);

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

        private static ServiceInfo GetAADServiceInfo(string tid)
        {
            return new ServiceInfo()
            {
                OpenIdConnectionHost = "https://login.microsoftonline.com/common/v2.0/.well-known/openid-configuration",
                TokenIssuerV1 = $"https://sts.windows.net/{tid}/",
                TokenIssuerV2 = $"https://login.microsoftonline.com/{tid}/v2.0",
                ApplicationId = "99045fe1-7639-4a75-9d4a-577b6ca3810f",
                IsDefault = true
            };
        }
    }
}
