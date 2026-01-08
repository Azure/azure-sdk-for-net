// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Text.Json;
using Azure.Core;
using Azure.ResourceManager.Compute.Models;
using Azure.ResourceManager.Resources.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.Compute.Tests.Unit
{
    public class VirtualMachineExtensionPatchTests
    {
        private const string secretUri = "https://kvname.vault.azure.net/secrets/secretname/79b88b3a6f5440ffb2e73e44a0db712e";
        private const string vaultId = "/subscriptions/a53f7094-a16c-47af-abe4-b05c05d0d79a/resourceGroups/myResourceGroup/providers/Microsoft.KeyVault/vaults/kvName";

        [TestCase]
        public void ValidateSetBinaryDataGetFromModel()
        {
            var binarySetting = BinaryData.FromObjectAsJson(new
            {
                secretUrl = secretUri,
                sourceVault = new
                {
                    id = vaultId
                }
            });
            var data = new VirtualMachineExtensionPatch
            {
                ProtectedSettingsFromKeyVault = binarySetting
            };

            Assert.Multiple(() =>
            {
                Assert.That(data.KeyVaultProtectedSettings.SecretUri.ToString(), Is.EqualTo(secretUri));
                Assert.That(data.KeyVaultProtectedSettings.SourceVaultId.ToString(), Is.EqualTo(vaultId));
            });
        }

        [TestCase]
        public void ValidateModifyModelSetFromBinaryData()
        {
            // set it as binary data
            var binarySetting = BinaryData.FromObjectAsJson(new
            {
                secretUrl = secretUri,
                sourceVault = new
                {
                    id = vaultId
                }
            });
            var data = new VirtualMachineExtensionPatch
            {
                ProtectedSettingsFromKeyVault = binarySetting
            };
            // get it as concrete type property
            var settings = data.KeyVaultProtectedSettings;
            // modify it
            var newVaultId = vaultId + "1";
            settings.SourceVaultId = new ResourceIdentifier(newVaultId);
            // validate the new value also reflected in the binary data property
            var newBinaryDataSetting = data.ProtectedSettingsFromKeyVault;
            var root = newBinaryDataSetting.ToObjectFromJson<JsonElement>();

            Assert.Multiple(() =>
            {
                Assert.That(root.GetProperty("secretUrl").GetString(), Is.EqualTo(secretUri));
                Assert.That(root.GetProperty("sourceVault").GetProperty("id").GetString(), Is.EqualTo(newVaultId));
            });
        }

        [TestCase]
        public void ValidateSetModelGetFromBinaryData()
        {
            var keyVaultSecretReference = new KeyVaultSecretReference(new Uri(secretUri), new WritableSubResource()
            {
                Id = new ResourceIdentifier(vaultId)
            });
            var data = new VirtualMachineExtensionPatch
            {
                KeyVaultProtectedSettings = keyVaultSecretReference
            };
            var binaryDataSetting = data.ProtectedSettingsFromKeyVault;
            var root = binaryDataSetting.ToObjectFromJson<JsonElement>();

            Assert.Multiple(() =>
            {
                Assert.That(root.GetProperty("secretUrl").GetString(), Is.EqualTo(secretUri));
                Assert.That(root.GetProperty("sourceVault").GetProperty("id").GetString(), Is.EqualTo(vaultId));
            });
        }
    }
}
