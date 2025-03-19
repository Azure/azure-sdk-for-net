// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core.TestFramework;
using Azure.Identity;

namespace Azure.Data.AppConfiguration
{
    public class AppConfigurationTestEnvironment : TestEnvironment
    {
        public string ConnectionString => GetRecordedVariable("APPCONFIGURATION_CONNECTION_STRING", options => options.HasSecretConnectionStringParameter("secret", SanitizedValue.Base64));
        public string Endpoint => GetRecordedVariable("APPCONFIGURATION_ENDPOINT_STRING");
        public string SecretId => GetRecordedVariable("KEYVAULT_SECRET_URL");

        public AppConfigurationAudience GetAudience()
        {
            Uri authorityHost = new(AuthorityHostUrl);

            if (authorityHost == AzureAuthorityHosts.AzurePublicCloud)
            {
                return AppConfigurationAudience.AzurePublicCloud;
            }

            if (authorityHost == AzureAuthorityHosts.AzureChina)
            {
                return AppConfigurationAudience.AzureChina;
            }

            if (authorityHost == AzureAuthorityHosts.AzureGovernment)
            {
                return AppConfigurationAudience.AzureGovernment;
            }

            throw new NotSupportedException($"Cloud for authority host {authorityHost} is not supported.");
        }
    }
}
