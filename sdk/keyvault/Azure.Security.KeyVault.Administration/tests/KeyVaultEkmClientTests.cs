// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Microsoft.Extensions.Configuration;
using NUnit.Framework;

namespace Azure.Security.KeyVault.Administration.Tests
{
    public class KeyVaultEkmClientTests
    {
        private Uri VaultUri { get; } = new Uri("https://myhsm.managedhsm.azure.net");

        [Test]
        public void NewVaultUriNullThrows() =>
            Assert.Throws<ArgumentNullException>(() => new KeyVaultEkmClient(null, new MockCredential()));

        [Test]
        public void NewCredentialNullThrows() =>
            Assert.Throws<ArgumentNullException>(() => new KeyVaultEkmClient(VaultUri, null));

        [Test]
        public void NewWithOptions_VaultUriNullThrows() =>
            Assert.Throws<ArgumentNullException>(
                () => new KeyVaultEkmClient(null, new MockCredential(), new KeyVaultAdministrationClientOptions()));

        [Test]
        public void NewWithOptions_CredentialNullThrows() =>
            Assert.Throws<ArgumentNullException>(
                () => new KeyVaultEkmClient(VaultUri, null, new KeyVaultAdministrationClientOptions()));

        [Test]
        public void NewWithNullOptions_DoesNotThrow() =>
            Assert.DoesNotThrow(() => new KeyVaultEkmClient(VaultUri, new MockCredential(), null));

        [Test]
        public void VaultUri_ReturnsSuppliedUri()
        {
            KeyVaultEkmClient client = new(VaultUri, new MockCredential());
            Assert.AreEqual(VaultUri, client.VaultUri);
        }

#pragma warning disable SCME0002 // Client settings are experimental.
        [Test]
        public void Settings_BindVaultUriKeyAdvertisedByConfigurationSchema()
        {
            string schemaPath = Path.Combine(TestContext.CurrentContext.TestDirectory, "ConfigurationSchema.json");
            using JsonDocument schema = JsonDocument.Parse(File.ReadAllText(schemaPath));
            JsonElement properties = schema.RootElement
                .GetProperty("properties").GetProperty("AzureClients")
                .GetProperty("properties").GetProperty(nameof(KeyVaultEkmClient))
                .GetProperty("properties");

            Assert.IsTrue(properties.TryGetProperty("VaultUri", out _));
            Assert.IsFalse(properties.TryGetProperty("VaultBaseUrl", out _));

            IConfiguration configuration = new ConfigurationBuilder()
                .AddInMemoryCollection(new Dictionary<string, string> { ["Ekm:VaultUri"] = VaultUri.OriginalString })
                .Build();
            KeyVaultEkmClientSettings settings = new();
            settings.Bind(configuration.GetSection("Ekm"));
            settings.CredentialProvider = new MockCredential();

            Assert.AreEqual(VaultUri, settings.VaultUri);
            Assert.AreEqual(VaultUri, new KeyVaultEkmClient(settings).VaultUri);
        }

        [Test]
        public async Task Settings_ClientAuthenticatesWithConfiguredCredential()
        {
            MockTransport transport = new(request =>
            {
                if (!request.Headers.Contains(HttpHeader.Names.Authorization))
                {
                    MockResponse challenge = new(401);
                    challenge.AddHeader(new HttpHeader("WWW-Authenticate", "Bearer authorization=\"https://login.microsoftonline.com/72f988bf-86f1-41af-91ab-2d7cd011db47\", resource=\"https://managedhsm.azure.net\""));
                    return challenge;
                }

                MockResponse response = new(200);
                response.SetContent("{\"host\":\"ekm.contoso.com\"}");
                return response;
            });

            IConfiguration configuration = new ConfigurationBuilder()
                .AddInMemoryCollection(new Dictionary<string, string> { ["Ekm:VaultUri"] = VaultUri.OriginalString })
                .Build();
            KeyVaultEkmClientSettings settings = new();
            settings.Bind(configuration.GetSection("Ekm"));
            // CredentialProvider is a no-op until Bind has created the Credential settings.
            settings.CredentialProvider = new MockCredential();
            settings.Options = new KeyVaultAdministrationClientOptions { Transport = transport };

            KeyVaultEkmConnection connection = await new KeyVaultEkmClient(settings).GetEkmConnectionAsync();

            Assert.AreEqual("ekm.contoso.com", connection.HostName);
        }
#pragma warning restore SCME0002

        [Test]
        public void CreateEkmConnectionNullThrows()
        {
            KeyVaultEkmClient client = new(VaultUri, new MockCredential());
            Assert.Throws<ArgumentNullException>(() => client.CreateEkmConnection(null));
            Assert.ThrowsAsync<ArgumentNullException>(async () => await client.CreateEkmConnectionAsync(null));
        }

        [Test]
        public void UpdateEkmConnectionNullThrows()
        {
            KeyVaultEkmClient client = new(VaultUri, new MockCredential());
            Assert.Throws<ArgumentNullException>(() => client.UpdateEkmConnection(null));
            Assert.ThrowsAsync<ArgumentNullException>(async () => await client.UpdateEkmConnectionAsync(null));
        }
    }
}