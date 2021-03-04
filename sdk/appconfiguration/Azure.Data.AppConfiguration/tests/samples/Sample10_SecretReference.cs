// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.Identity;
using Azure.Security.KeyVault.Secrets;
using NUnit.Framework;

namespace Azure.Data.AppConfiguration.Samples
{
    public partial class ConfigurationSamples: SamplesBase<AppConfigurationTestEnvironment>
    {
        [Test]
        public async Task CreateSecretReference()
        {
            var connectionString = TestEnvironment.ConnectionString;
            var client = new ConfigurationClient(connectionString);

            #region Snippet:Sample_CreateSecretReference
            var secretId = "https://keyvault_name.vault.azure.net/secrets/<secret_name>";
            /*@@*/ secretId = TestEnvironment.SecretId;
            var secretReferenceSetting = new SecretReferenceConfigurationSetting("setting", new Uri(secretId));
            #endregion

            #region Snippet:Sample_SetSecretReference
            client.SetConfigurationSetting(secretReferenceSetting);
            #endregion

            #region Snippet:Sample_GetSecretReference
            Response<ConfigurationSetting> response = client.GetConfigurationSetting("setting");
            if (response.Value is SecretReferenceConfigurationSetting secretReference)
            {
                var identifier = new KeyVaultSecretIdentifier(secretReference.SecretId);
                var secretClient = new SecretClient(identifier.VaultUri, new DefaultAzureCredential());
                var secret = await secretClient.GetSecretAsync(identifier.Name, identifier.Version);

                Console.WriteLine($"Setting {secretReference.Key} references {secretReference.SecretId} Secret Value: {secret.Value.Value}");
            }
            #endregion

            #region Snippet:Sample_DeleteSecretReference
            client.DeleteConfigurationSetting(secretReferenceSetting);
            #endregion
        }
    }
}
