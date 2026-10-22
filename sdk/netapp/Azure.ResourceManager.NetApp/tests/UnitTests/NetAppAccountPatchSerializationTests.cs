// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text.Json;
using Azure.ResourceManager.NetApp.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.NetApp.Tests
{
    public class NetAppAccountPatchSerializationTests
    {
        private static readonly ModelReaderWriterOptions WireOptions = new ModelReaderWriterOptions("W");

        [Test]
        public void SerializePreservesMutationsToAssignedEncryption()
        {
            var encryption = new NetAppAccountEncryption();
            var patch = new NetAppAccountPatch("westus2") { Encryption = encryption };

            encryption.KeySource = new NetAppKeySource("Microsoft.KeyVault");

            Assert.That(patch.Encryption, Is.SameAs(encryption));
            using JsonDocument document = Serialize(patch);
            Assert.That(document.RootElement.GetProperty("properties").GetProperty("encryption")
                .GetProperty("keySource").GetString(), Is.EqualTo("Microsoft.KeyVault"));
        }

        [Test]
        public void SerializePreservesGetterAndNestedEncryptionMutations()
        {
            var encryption = new NetAppAccountEncryption
            {
                Identity = new NetAppEncryptionIdentity(),
                KeyVaultProperties = new NetAppKeyVaultProperties(new Uri("https://example.vault.azure.net"), "original")
            };
            var patch = new NetAppAccountPatch("westus2") { Encryption = encryption };

            patch.Encryption.KeySource = new NetAppKeySource("Microsoft.KeyVault");
            patch.Encryption.KeyVaultProperties.KeyName = "updated";
            patch.Encryption.Identity.FederatedClientId = "updated-client";

            Assert.That(encryption.KeyVaultProperties.KeyName, Is.EqualTo("updated"));
            using JsonDocument document = Serialize(patch);
            JsonElement serialized = document.RootElement.GetProperty("properties").GetProperty("encryption");
            Assert.That(serialized.GetProperty("keySource").GetString(), Is.EqualTo("Microsoft.KeyVault"));
            Assert.That(serialized.GetProperty("keyVaultProperties").GetProperty("keyName").GetString(), Is.EqualTo("updated"));
            Assert.That(serialized.GetProperty("identity").GetProperty("federatedClientId").GetString(), Is.EqualTo("updated-client"));
        }

        [Test]
        public void SerializePreservesActiveDirectoryItemMutationsAfterAdd()
        {
            var directory = new NetAppAccountActiveDirectory { Domain = "original.example" };
            var patch = new NetAppAccountPatch("westus2");
            IList<NetAppAccountActiveDirectory> directories = patch.ActiveDirectories;
            directories.Add(directory);

            directory.Domain = "updated.example";
            directory.Administrators.Add("administrator");

            Assert.That(directories[0], Is.SameAs(directory));
            using JsonDocument document = Serialize(patch);
            JsonElement serialized = document.RootElement.GetProperty("properties").GetProperty("activeDirectories")[0];
            Assert.That(serialized.GetProperty("domain").GetString(), Is.EqualTo("updated.example"));
            Assert.That(serialized.GetProperty("administrators")[0].GetString(), Is.EqualTo("administrator"));
        }

        [Test]
        public void SerializePreservesActiveDirectoryReplacementRemovalAndClear()
        {
            var patch = new NetAppAccountPatch("westus2");
            patch.ActiveDirectories.Add(new NetAppAccountActiveDirectory { Domain = "first.example" });
            patch.ActiveDirectories.Add(new NetAppAccountActiveDirectory { Domain = "second.example" });

            patch.ActiveDirectories[0] = new NetAppAccountActiveDirectory { Domain = "replacement.example" };
            using (JsonDocument document = Serialize(patch))
            {
                JsonElement directories = document.RootElement.GetProperty("properties").GetProperty("activeDirectories");
                Assert.That(directories.GetArrayLength(), Is.EqualTo(2));
                Assert.That(directories[0].GetProperty("domain").GetString(), Is.EqualTo("replacement.example"));
            }

            patch.ActiveDirectories.RemoveAt(1);
            using (JsonDocument document = Serialize(patch))
            {
                Assert.That(document.RootElement.GetProperty("properties").GetProperty("activeDirectories").GetArrayLength(), Is.EqualTo(1));
            }

            patch.ActiveDirectories.Clear();
            using (JsonDocument document = Serialize(patch))
            {
                Assert.That(document.RootElement.GetProperty("properties").GetProperty("activeDirectories").GetArrayLength(), Is.Zero);
            }
        }

        [Test]
        public void SerializeUsesOriginalNfsDomainWireName()
        {
            var patch = new NetAppAccountPatch("westus2") { NfsV4IdDomain = "contoso.com" };

            using JsonDocument document = Serialize(patch);
            JsonElement properties = document.RootElement.GetProperty("properties");
            Assert.That(properties.GetProperty("nfsV4IDDomain").GetString(), Is.EqualTo("contoso.com"));
            Assert.That(properties.TryGetProperty("nfsV4IdDomain", out _), Is.False);
        }

        [Test]
        public void RoundTripPreservesMutableAccountPatchModels()
        {
            var patch = new NetAppAccountPatch("westus2")
            {
                NfsV4IdDomain = "contoso.com",
                Encryption = new NetAppAccountEncryption
                {
                    KeySource = new NetAppKeySource("Microsoft.KeyVault"),
                    KeyVaultProperties = new NetAppKeyVaultProperties(new Uri("https://example.vault.azure.net"), "original")
                }
            };
            patch.ActiveDirectories.Add(new NetAppAccountActiveDirectory { Domain = "original.example" });
            BinaryData data = ModelReaderWriter.Write(patch, WireOptions, AzureResourceManagerNetAppContext.Default);

            NetAppAccountPatch restored = ModelReaderWriter.Read<NetAppAccountPatch>(data, WireOptions, AzureResourceManagerNetAppContext.Default);
            Assert.That(restored.NfsV4IdDomain, Is.EqualTo("contoso.com"));
            restored.Encryption.KeyVaultProperties.KeyName = "updated";
            restored.ActiveDirectories[0].Domain = "updated.example";

            using JsonDocument document = Serialize(restored);
            JsonElement properties = document.RootElement.GetProperty("properties");
            Assert.That(properties.GetProperty("encryption").GetProperty("keyVaultProperties")
                .GetProperty("keyName").GetString(), Is.EqualTo("updated"));
            Assert.That(properties.GetProperty("activeDirectories")[0].GetProperty("domain").GetString(), Is.EqualTo("updated.example"));
            Assert.That(properties.GetProperty("nfsV4IDDomain").GetString(), Is.EqualTo("contoso.com"));
        }

        [Test]
        public void AccountPatchFactoryPreservesMutableModelsAndNfsDomain()
        {
            var directory = new NetAppAccountActiveDirectory();
            var encryption = new NetAppAccountEncryption();
            NetAppAccountPatch patch = ArmNetAppModelFactory.NetAppAccountPatch(
                null, null, default, null, null, "westus2", null,
                new[] { directory }, encryption, "contoso.com", null, null);

            directory.Domain = "updated.example";
            encryption.KeySource = new NetAppKeySource("Microsoft.KeyVault");

            Assert.That(patch.Encryption, Is.SameAs(encryption));
            Assert.That(patch.ActiveDirectories[0], Is.SameAs(directory));
            using JsonDocument document = Serialize(patch);
            JsonElement properties = document.RootElement.GetProperty("properties");
            Assert.That(properties.GetProperty("activeDirectories")[0].GetProperty("domain").GetString(), Is.EqualTo("updated.example"));
            Assert.That(properties.GetProperty("encryption").GetProperty("keySource").GetString(), Is.EqualTo("Microsoft.KeyVault"));
            Assert.That(properties.GetProperty("nfsV4IDDomain").GetString(), Is.EqualTo("contoso.com"));
        }

        private static JsonDocument Serialize(NetAppAccountPatch patch)
        {
            return JsonDocument.Parse(ModelReaderWriter.Write(patch, WireOptions, AzureResourceManagerNetAppContext.Default));
        }
    }
}
