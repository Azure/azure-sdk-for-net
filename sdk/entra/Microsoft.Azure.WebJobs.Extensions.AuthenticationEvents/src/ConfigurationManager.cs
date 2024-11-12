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
        private const string OpenIdConfigurationPath = "/.well-known/openid-configuration";
        private const string OpenIdConfigurationPathV2 = "/v2.0/.well-known/openid-configuration";

        private const string AuthenticationEventsKeyPrefix = "AuthenticationEvents__";
        private const string AuthorityUrlKey = AuthenticationEventsKeyPrefix + "AuthorityUrl";
        private const string AuthorizedPartyAppIdKey = AuthenticationEventsKeyPrefix + "AuthorizedPartyAppId";
        private const string AudienceAppIdKey = AuthenticationEventsKeyPrefix + "AudienceAppId";
        private const string BypassTokenValidationKey = AuthenticationEventsKeyPrefix + "BypassTokenValidation";
        private const string IsUnsafeSupportLoggingEnabledKey = AuthenticationEventsKeyPrefix + "IsUnsafeSupportLoggingEnabled";

        private const string EZAUTH_ENABLED = "WEBSITE_AUTH_ENABLED";

        internal const string AppIdKey = "appid";
        internal const string AzpKey = "azp";

        internal const string HEADER_EZAUTH_ICP = "X-MS-CLIENT-PRINCIPAL-IDP";
        internal const string HEADER_EZAUTH_ICP_VERIFY = "aad";
        internal const string HEADER_EZAUTH_PRINCIPAL = "X-MS-CLIENT-PRINCIPAL";

        /// <summary>
        /// Annotation for the trigger attribute.
        /// </summary>
        private readonly WebJobsAuthenticationEventsTriggerAttribute triggerAttribute;

        internal ConfigurationManager(WebJobsAuthenticationEventsTriggerAttribute triggerAttribute)
        {
            this.triggerAttribute = triggerAttribute;
        }

        /// <summary>
        /// Get the audience app id from the environment variable or use the default value from the trigger attribute.
        /// REQUIRED FEILD
        /// </summary>
        internal string AudienceAppId
        {
            get
            {
                string value = GetConfigValue(AudienceAppIdKey, triggerAttribute?.AudienceAppId);

                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new MissingFieldException(
                        string.Format(
                            provider: CultureInfo.CurrentCulture,
                            format: AuthenticationEventResource.Ex_Trigger_ApplicationId_Required,
                            arg0: AudienceAppIdKey));
                }

                return value;
            }
        }

        /// <summary>
        /// Get the OpenId connection host from the environment variable or use the default value.
        /// REQUIRD FEILD
        /// </summary>
        internal string AuthorityUrl
        {
            get
            {
                string value = GetConfigValue(AuthorityUrlKey, triggerAttribute?.AuthorityUrl);

                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new MissingFieldException(
                        string.Format(
                            provider: CultureInfo.CurrentCulture,
                            format: AuthenticationEventResource.Ex_Trigger_AuthorityUrl_Required,
                            arg0: AuthorityUrlKey));
                }

                return value;
            }
        }

        /// <summary>
        /// Get the OpenId connection host from the environment variable or use the default value.
        /// OPTIONAL FEILD, defaults to public cloud id.
        /// </summary>
        internal string AuthorizedPartyAppId
        {
            get
            {
                string value = GetConfigValue(AuthorizedPartyAppIdKey, triggerAttribute?.AuthorizedPartyAppId);

                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new MissingFieldException(
                        string.Format(
                            provider: CultureInfo.CurrentCulture,
                            format: AuthenticationEventResource.Ex_Trigger_AuthorizedPartyApplicationId_Required,
                            arg0: AuthorizedPartyAppIdKey));
                }

                return value;
            }
        }

        /// <summary>
        /// Show PII data in logs.
        /// </summary>
        internal static bool IsUnsafeSupportLoggingEnabled => GetConfigValue(IsUnsafeSupportLoggingEnabledKey, false);

        /// <summary>
        /// If we should bypass the token validation.
        /// Use only for testing and development.
        /// </summary>
        internal static bool BypassValidation => GetConfigValue(BypassTokenValidationKey, false);

        /// <summary>
        /// If the EZAuth is enabled.
        /// </summary>
        internal static bool EZAuthEnabled => GetConfigValue(EZAUTH_ENABLED, false);

        /// <summary>
        /// Get the issuer string based on the token schema version.
        /// </summary>
        /// <param name="tokenSchemaVersion">v2 will return v2 odic url, v1 will return v1</param>
        /// <returns></returns>
        internal string GetOpenIDConfigurationUrlString(SupportedTokenSchemaVersions tokenSchemaVersion)
        {
            return tokenSchemaVersion == SupportedTokenSchemaVersions.V2_0 ?
                AuthorityUrl + OpenIdConfigurationPathV2 :
                AuthorityUrl + OpenIdConfigurationPath;
        }

        /// <summary>
        /// Get config value from environment variable or use the default value.
        /// </summary>
        /// <param name="environmentVariable">Definied Azure function application settings</param>
        /// <param name="defaultValue">Default value, most likely from auth trigger anotation</param>
        /// <returns>Config Value found or default</returns>
        private static string GetConfigValue(string environmentVariable, string defaultValue)
        {
            return Environment.GetEnvironmentVariable(environmentVariable) ?? defaultValue;
        }

        /// <summary>
        /// Get config value from environment variable or use the default value.
        /// </summary>
        /// <typeparam name="T">Type the config value would be</typeparam>
        /// <param name="environmentVariable">Definied Azure function application settings</param>
        /// <param name="defaultValue">Default value, most likely from auth trigger anotation</param>
        /// <returns>Config Value found or default</returns>
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
    }
}
