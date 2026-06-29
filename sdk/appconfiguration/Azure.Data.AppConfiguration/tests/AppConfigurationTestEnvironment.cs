// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Azure.Core.TestFramework;
using Azure.Identity;

namespace Azure.Data.AppConfiguration
{
    public class AppConfigurationTestEnvironment : TestEnvironment
    {
        public string Endpoint => GetRecordedVariable("APPCONFIGURATION_ENDPOINT_STRING");
        public string SecretId => GetRecordedVariable("KEYVAULT_SECRET_URL");

        protected override TokenCredential CreateDeveloperCredential()
            => new ChainedTokenCredential(
                new AzurePowerShellCredential(),
                new AzureCliCredential(),
                base.CreateDeveloperCredential());
    }
}
