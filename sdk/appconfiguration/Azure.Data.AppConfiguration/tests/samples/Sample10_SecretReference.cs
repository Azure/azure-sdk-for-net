// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.Data.AppConfiguration.Samples
{
    public partial class ConfigurationSamples: SamplesBase<AppConfigurationTestEnvironment>
    {
        [Test]
        public void CreateSecretReference()
        {
            var connectionString = TestEnvironment.ConnectionString;
            var client = new ConfigurationClient(connectionString);

            #region Snippet:Sample_CreateSecretReference
            var secretReferenceSetting = new SecretReferenceConfigurationSetting("setting", new Uri("https://<keyvault_name>.vault.azure.net/secrets/<secret_name>"));
            #endregion

            #region Snippet:Sample_SetSecretReference
            client.SetConfigurationSetting(secretReferenceSetting);
            #endregion

            #region Snippet:Sample_GetSecretReference
            Response<ConfigurationSetting> response = client.GetConfigurationSetting("setting");
            if (response.Value is SecretReferenceConfigurationSetting secretReference)
            {
                Console.WriteLine($"Setting {secretReference.Key} references {secretReference.SecretId}");
            }
            #endregion

            #region Snippet:Sample_DeleteSecretReference
            client.DeleteConfigurationSetting(secretReferenceSetting);
            #endregion
        }
    }
}
