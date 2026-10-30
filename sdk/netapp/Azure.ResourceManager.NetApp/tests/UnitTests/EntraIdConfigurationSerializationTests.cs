// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Text.Json;
using Azure.Core;
using Azure.ResourceManager.NetApp.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.NetApp.Tests
{
    public class EntraIdConfigurationSerializationTests
    {
        private const string Identity = "/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/test/providers/Microsoft.ManagedIdentity/userAssignedIdentities/test";
        private const string KeyVaultJson = "{\"azureKeyVaultUri\":\"https://test.vault.azure.net/\",\"certificateName\":\"certificate\",\"userAssignedIdentity\":\"" + Identity + "\"}";
        private const string ConfigurationJson = "{\"applicationId\":\"application\",\"domain\":\"contoso.com\",\"serverNamePrefix\":\"server\",\"entraIdAkvConfig\":" + KeyVaultJson + "}";

        [TestCase("J")]
        [TestCase("W")]
        public void AccountConfigurationIsConnectedToWireModel(string format)
        {
            var options = new ModelReaderWriterOptions(format);
            var configuration = CreateConfiguration();
            var account = new NetAppAccountData("westus2") { EntraIdConfig = configuration };

            Assert.That(account.EntraIdConfig, Is.SameAs(configuration));
            AssertAccountPayload(account, options);

            var restored = ModelReaderWriter.Read<NetAppAccountData>(
                BinaryData.FromString("{\"location\":\"westus2\",\"properties\":{\"entraIdConfig\":" + ConfigurationJson + "}}"),
                options, AzureResourceManagerNetAppContext.Default);
            Assert.That(restored.EntraIdConfig.ApplicationId, Is.EqualTo("application"));
            Assert.That(restored.EntraIdConfig.EntraIdAkvConfig.UserAssignedIdentity.ToString(), Is.EqualTo(Identity));
            AssertAccountPayload(restored, options);

            restored.EntraIdConfig = CreateConfiguration();
            restored.EntraIdConfig.Domain = "updated.contoso.com";
            using JsonDocument updated = Serialize(restored, options);
            Assert.That(updated.RootElement.GetProperty("properties").GetProperty("entraIdConfig").GetProperty("domain").GetString(),
                Is.EqualTo("updated.contoso.com"));
        }

        [TestCase("J")]
        [TestCase("W")]
        public void PatchConfigurationIsConnectedToWireModel(string format)
        {
            var options = new ModelReaderWriterOptions(format);
            var configuration = CreatePatchConfiguration();
            var patch = new NetAppAccountPatch("westus2") { EntraIdConfig = configuration };

            Assert.That(patch.EntraIdConfig, Is.SameAs(configuration));
            AssertAccountPayload(patch, options);

            var restored = ModelReaderWriter.Read<NetAppAccountPatch>(
                BinaryData.FromString("{\"location\":\"westus2\",\"properties\":{\"entraIdConfig\":" + ConfigurationJson + "}}"),
                options, AzureResourceManagerNetAppContext.Default);
            Assert.That(restored.EntraIdConfig.ApplicationId, Is.EqualTo("application"));
            Assert.That(restored.EntraIdConfig.EntraIdAkvConfig.UserAssignedIdentity.ToString(), Is.EqualTo(Identity));
            AssertAccountPayload(restored, options);

            restored.EntraIdConfig = CreatePatchConfiguration();
            restored.EntraIdConfig.Domain = "updated.contoso.com";
            using JsonDocument updated = Serialize(restored, options);
            Assert.That(updated.RootElement.GetProperty("properties").GetProperty("entraIdConfig").GetProperty("domain").GetString(),
                Is.EqualTo("updated.contoso.com"));
        }

        [TestCase("J")]
        [TestCase("W")]
        public void SettersInitializeMissingWireProperties(string format)
        {
            var options = new ModelReaderWriterOptions(format);
            var data = BinaryData.FromString("{\"location\":\"westus2\"}");
            var account = ModelReaderWriter.Read<NetAppAccountData>(data, options, AzureResourceManagerNetAppContext.Default);
            var patch = ModelReaderWriter.Read<NetAppAccountPatch>(data, options, AzureResourceManagerNetAppContext.Default);

            Assert.That(account.EntraIdConfig, Is.Null);
            Assert.That(patch.EntraIdConfig, Is.Null);
            account.EntraIdConfig = CreateConfiguration();
            patch.EntraIdConfig = CreatePatchConfiguration();
            AssertAccountPayload(account, options);
            AssertAccountPayload(patch, options);
        }

        [TestCase("J")]
        [TestCase("W")]
        public void DirectModelsSupportAllSerializationEntryPoints(string format)
        {
            var options = new ModelReaderWriterOptions(format);
            AssertModelRoundTrip(CreateConfiguration(), ConfigurationJson, options);
            AssertModelRoundTrip(CreatePatchConfiguration(), ConfigurationJson, options);
            AssertModelRoundTrip(CreateConfiguration().EntraIdAkvConfig, KeyVaultJson, options);
            AssertModelRoundTrip(CreatePatchConfiguration().EntraIdAkvConfig, KeyVaultJson, options);
        }

        [TestCase("J")]
        [TestCase("W")]
        public void FactoryConfigurationsAreSerialized(string format)
        {
            var options = new ModelReaderWriterOptions(format);
            var configuration = ArmNetAppModelFactory.EntraIdConfig("application", "contoso.com", "server",
                ArmNetAppModelFactory.EntraIdAkvConfig(new Uri("https://test.vault.azure.net/"), "certificate", new ResourceIdentifier(Identity)));
            var patchConfiguration = ArmNetAppModelFactory.EntraIdConfigPatch("application", "contoso.com", "server",
                ArmNetAppModelFactory.EntraIdAkvConfigPatch(new Uri("https://test.vault.azure.net/"), "certificate", new ResourceIdentifier(Identity)));

            AssertAccountPayload(ArmNetAppModelFactory.NetAppAccountData(
                null, null, default, null, null, "westus2", null, null, configuration, null, null, null, null, null, null, null), options);
            AssertAccountPayload(ArmNetAppModelFactory.NetAppAccountPatch(
                null, null, default, null, null, "westus2", null, null, null, null, patchConfiguration, (LdapConfigurationPatch)null), options);
            AssertAccountPayload(ArmNetAppModelFactory.NetAppAccountData(
                null, null, default, null, null, "westus2", null, null, null, null, null, null,
                configuration, (LdapConfiguration)null), options);
            AssertAccountPayload(ArmNetAppModelFactory.NetAppAccountPatch(
                null, null, default, null, null, "westus2", null, null, null, null, null,
                patchConfiguration, (LdapConfiguration)null), options);
        }

        [TestCase("J")]
        [TestCase("W")]
        public void ClearingPublicConfigurationOmitsWireProperty(string format)
        {
            var options = new ModelReaderWriterOptions(format);
            var account = new NetAppAccountData("westus2") { EntraIdConfig = CreateConfiguration() };
            var patch = new NetAppAccountPatch("westus2") { EntraIdConfig = CreatePatchConfiguration() };
            account.EntraIdConfig = null;
            patch.EntraIdConfig = null;
            Assert.That(account.EntraIdConfig, Is.Null);
            Assert.That(patch.EntraIdConfig, Is.Null);
            using JsonDocument accountJson = Serialize(account, options);
            using JsonDocument patchJson = Serialize(patch, options);
            Assert.That(accountJson.RootElement.GetProperty("properties").TryGetProperty("entraIdConfig", out _), Is.False);
            Assert.That(patchJson.RootElement.GetProperty("properties").TryGetProperty("entraIdConfig", out _), Is.False);
        }

        [TestCase("J")]
        [TestCase("W")]
        public void OptionalConfigurationValuesAreOmitted(string format)
        {
            var options = new ModelReaderWriterOptions(format);
            AssertModelRoundTrip(new EntraIdConfig(null, null, null), "{}", options);
            AssertModelRoundTrip(new EntraIdConfigPatch(), "{}", options);
            AssertModelRoundTrip(new EntraIdAkvConfig(), "{}", options);
            AssertModelRoundTrip(new EntraIdAkvConfigPatch(), "{}", options);
        }

        [TestCase("J")]
        [TestCase("W")]
        public void UnknownPropertiesFollowPersistenceAndWireSemantics(string format)
        {
            var options = new ModelReaderWriterOptions(format);
            const string json = "{\"applicationId\":\"application\",\"futureSetting\":42,\"entraIdAkvConfig\":{\"futureVaultSetting\":true}}";
            AssertUnknownProperties<EntraIdConfig>(json, options);
            AssertUnknownProperties<EntraIdConfigPatch>(json, options);
        }

        [Test]
        public void UnsupportedFormatsAreRejected()
        {
            AssertUnsupportedFormat(CreateConfiguration());
            AssertUnsupportedFormat(CreatePatchConfiguration());
            AssertUnsupportedFormat(CreateConfiguration().EntraIdAkvConfig);
            AssertUnsupportedFormat(CreatePatchConfiguration().EntraIdAkvConfig);
        }

        private static EntraIdConfig CreateConfiguration() =>
            new EntraIdConfig("application", "contoso.com", "server")
            {
                EntraIdAkvConfig = new EntraIdAkvConfig(new Uri("https://test.vault.azure.net/"), "certificate")
                {
                    UserAssignedIdentity = new ResourceIdentifier(Identity)
                }
            };

        private static EntraIdConfigPatch CreatePatchConfiguration() =>
            new EntraIdConfigPatch
            {
                ApplicationId = "application",
                Domain = "contoso.com",
                ServerNamePrefix = "server",
                EntraIdAkvConfig = new EntraIdAkvConfigPatch
                {
                    AzureKeyVaultUri = new Uri("https://test.vault.azure.net/"),
                    CertificateName = "certificate",
                    UserAssignedIdentity = new ResourceIdentifier(Identity)
                }
            };

        private static JsonDocument Serialize<T>(T model, ModelReaderWriterOptions options) =>
            JsonDocument.Parse(ModelReaderWriter.Write(model, options, AzureResourceManagerNetAppContext.Default));

        private static void AssertAccountPayload<T>(T account, ModelReaderWriterOptions options)
        {
            using JsonDocument document = Serialize(account, options);
            Assert.That(document.RootElement.GetProperty("properties").GetProperty("entraIdConfig").GetRawText(),
                Is.EqualTo(ConfigurationJson));
        }

        private static void AssertModelRoundTrip<T>(T model, string expectedJson, ModelReaderWriterOptions options)
            where T : IJsonModel<T>
        {
            var persistable = (IPersistableModel<T>)model;
            BinaryData data = persistable.Write(options);
            Assert.That(data.ToString(), Is.EqualTo(expectedJson));
            T restored = persistable.Create(data, options);
            Assert.That(ModelReaderWriter.Write(restored, options, AzureResourceManagerNetAppContext.Default).ToString(),
                Is.EqualTo(expectedJson));
            var reader = new Utf8JsonReader(data.ToArray());
            reader.Read();
            T fromReader = model.Create(ref reader, options);
            Assert.That(ModelReaderWriter.Write(fromReader, options, AzureResourceManagerNetAppContext.Default).ToString(),
                Is.EqualTo(expectedJson));
        }

        private static void AssertUnknownProperties<T>(string json, ModelReaderWriterOptions options)
        {
            T model = ModelReaderWriter.Read<T>(BinaryData.FromString(json), options, AzureResourceManagerNetAppContext.Default);
            using JsonDocument document = Serialize(model, options);
            JsonElement root = document.RootElement;
            Assert.That(root.GetProperty("applicationId").GetString(), Is.EqualTo("application"));
            bool preserveUnknown = options.Format == "J";
            Assert.That(root.TryGetProperty("futureSetting", out JsonElement setting), Is.EqualTo(preserveUnknown));
            Assert.That(root.GetProperty("entraIdAkvConfig").TryGetProperty("futureVaultSetting", out JsonElement vaultSetting),
                Is.EqualTo(preserveUnknown));
            if (preserveUnknown)
            {
                Assert.That(setting.GetInt32(), Is.EqualTo(42));
                Assert.That(vaultSetting.GetBoolean(), Is.True);
            }
        }

        private static void AssertUnsupportedFormat<T>(T model) where T : IPersistableModel<T>
        {
            var options = new ModelReaderWriterOptions("X");
            Assert.Throws<FormatException>(() => model.Write(options));
            Assert.Throws<FormatException>(() => model.Create(BinaryData.FromString("{}"), options));
        }
    }
}
