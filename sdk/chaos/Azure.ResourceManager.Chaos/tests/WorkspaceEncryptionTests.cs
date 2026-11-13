// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Text.Json;
using Azure.Core;
using Azure.ResourceManager.Chaos.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.Chaos.Tests
{
    public class WorkspaceEncryptionTests
    {
        [Test]
        public void CustomerManagedKeyOnboardingDeserializesApplicationIdAsGuid()
        {
            var applicationId = new Guid("12345678-1234-5678-9abc-123456789abc");
            BinaryData data = BinaryData.FromString("{\"customerManagedKeyOnboarding\":{\"applicationId\":\"12345678-1234-5678-9abc-123456789abc\"}}");

            WorkspaceEncryption encryption = ModelReaderWriter.Read<WorkspaceEncryption>(data);
            Guid? actual = encryption.CustomerManagedKeyOnboardingApplicationId;

            Assert.That(actual, Is.EqualTo(applicationId));
        }

        [Test]
        public void CustomerManagedKeyOnboardingApplicationIdIsNullWhenOnboardingIsAbsent()
        {
            WorkspaceEncryption encryption = ModelReaderWriter.Read<WorkspaceEncryption>(BinaryData.FromString("{}"));
            Guid? actual = encryption.CustomerManagedKeyOnboardingApplicationId;

            Assert.That(actual, Is.Null);
        }

        [Test]
        public void CustomerManagedKeyPatchOmitsUnchangedProperties()
        {
            var patch = new ChaosWorkspacePatch
            {
                WorkspaceUpdateCustomerManagedKeyEncryption = new WorkspaceCustomerManagedKeyEncryptionPatch()
            };

            using JsonDocument document = JsonDocument.Parse(ModelReaderWriter.Write(patch, new ModelReaderWriterOptions("W")));
            JsonElement encryption = document.RootElement.GetProperty("properties").GetProperty("encryption").GetProperty("customerManagedKeyEncryption");

            Assert.That(encryption.EnumerateObject(), Is.Empty);
        }

        [Test]
        public void CustomerManagedKeyPatchPreservesExplicitNulls()
        {
            var patch = new ChaosWorkspacePatch
            {
                WorkspaceUpdateCustomerManagedKeyEncryption = new WorkspaceCustomerManagedKeyEncryptionPatch
                {
                    KeyEncryptionKeyUri = null,
                    KeyVaultResourceId = null
                }
            };

            using JsonDocument document = JsonDocument.Parse(ModelReaderWriter.Write(patch, new ModelReaderWriterOptions("W")));
            JsonElement encryption = document.RootElement.GetProperty("properties").GetProperty("encryption").GetProperty("customerManagedKeyEncryption");

            Assert.That(encryption.GetProperty("keyEncryptionKeyUrl").ValueKind, Is.EqualTo(JsonValueKind.Null));
            Assert.That(encryption.GetProperty("keyVaultResourceId").ValueKind, Is.EqualTo(JsonValueKind.Null));
        }

        [Test]
        public void CustomerManagedKeyPatchSerializesKeyReference()
        {
            var keyUri = new Uri("https://example.vault.azure.net/keys/customer-key");
            var vaultId = new ResourceIdentifier("/subscriptions/00000000-0000-0000-0000-000000000001/resourceGroups/test/providers/Microsoft.KeyVault/vaults/example");
            var patch = new ChaosWorkspacePatch
            {
                WorkspaceUpdateCustomerManagedKeyEncryption = new WorkspaceCustomerManagedKeyEncryptionPatch
                {
                    KeyEncryptionKeyUri = keyUri,
                    KeyVaultResourceId = vaultId
                }
            };

            using JsonDocument document = JsonDocument.Parse(ModelReaderWriter.Write(patch, new ModelReaderWriterOptions("W")));
            JsonElement encryption = document.RootElement.GetProperty("properties").GetProperty("encryption").GetProperty("customerManagedKeyEncryption");

            Assert.That(encryption.GetProperty("keyEncryptionKeyUrl").GetString(), Is.EqualTo(keyUri.AbsoluteUri));
            Assert.That(encryption.GetProperty("keyVaultResourceId").GetString(), Is.EqualTo(vaultId.ToString()));
        }
    }
}
