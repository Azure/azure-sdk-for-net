// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.Security.KeyVault.Administration.Models;
using Azure.Security.KeyVault.Tests;
using Microsoft.Extensions.Configuration;
using NUnit.Framework;

namespace Azure.Security.KeyVault.Administration.Tests
{
    [NonParallelizable]
    internal class KeyVaultAdministrationProofOfPossessionTests : ContinuousAccessEvaluationTestsBase
    {
        private static readonly Guid s_roleDefinitionName = Guid.Parse("00000000-0000-0000-0000-000000000001");

        [SetUp]
        public void Setup()
        {
            ChallengeBasedAuthenticationPolicy.ClearCache();
        }

        [Test]
        public void BindsEnableProofOfPossessionFromConfiguration()
        {
            // The configuration schema advertises Options:EnableProofOfPossession, so the options constructor
            // that binds a configuration section must read it - otherwise the value is silently discarded.
            IConfigurationSection section = new ConfigurationBuilder()
                .AddInMemoryCollection(new Dictionary<string, string>
                {
                    ["kv:EnableProofOfPossession"] = "true",
                })
                .Build()
                .GetSection("kv");

#pragma warning disable SCME0002 // Experimental configuration-binding constructor.
            KeyVaultAdministrationClientOptions options = new(section);
#pragma warning restore SCME0002

            Assert.IsTrue(options.EnableProofOfPossession);
        }

        [Test]
        public async Task AccessControlClientDoesNotRequestProofOfPossessionByDefault()
        {
            TokenRequestContext? lastRequestContext = null;
            KeyVaultAccessControlClient client = new(
                VaultUri,
                new TokenCredentialStub((context, _) =>
                {
                    lastRequestContext = context;
                    return new AccessToken("token", DateTimeOffset.UtcNow.AddHours(1));
                }, true),
                new KeyVaultAdministrationClientOptions
                {
                    Transport = new MockTransport(defaultInitialChallenge, CreateGetRoleDefinitionResponse()),
                });

            Response<KeyVaultRoleDefinition> response = await client.GetRoleDefinitionAsync(KeyVaultRoleScope.Global, s_roleDefinitionName).ConfigureAwait(false);

            Assert.AreEqual(200, response.GetRawResponse().Status);
            Assert.IsNotNull(lastRequestContext);
            Assert.IsFalse(lastRequestContext.Value.IsProofOfPossessionEnabled);
        }

        [Test]
        public async Task AccessControlClientRequestsProofOfPossessionWhenEnabled()
        {
            TokenRequestContext? lastRequestContext = null;
            KeyVaultAccessControlClient client = new(
                VaultUri,
                new TokenCredentialStub((context, _) =>
                {
                    lastRequestContext = context;
                    return new AccessToken("token", DateTimeOffset.UtcNow.AddHours(1));
                }, true),
                new KeyVaultAdministrationClientOptions
                {
                    Transport = new MockTransport(defaultInitialChallenge, CreateGetRoleDefinitionResponse()),
                    EnableProofOfPossession = true,
                });

            Response<KeyVaultRoleDefinition> response = await client.GetRoleDefinitionAsync(KeyVaultRoleScope.Global, s_roleDefinitionName).ConfigureAwait(false);

            Assert.AreEqual(200, response.GetRawResponse().Status);
            Assert.IsNotNull(lastRequestContext);
            Assert.IsTrue(lastRequestContext.Value.IsProofOfPossessionEnabled);
        }

        [Test]
        public async Task EkmClientDoesNotRequestProofOfPossessionByDefault()
        {
            TokenRequestContext? lastRequestContext = null;
            KeyVaultEkmClient client = new(
                VaultUri,
                new TokenCredentialStub((context, _) =>
                {
                    lastRequestContext = context;
                    return new AccessToken("token", DateTimeOffset.UtcNow.AddHours(1));
                }, true),
                new KeyVaultAdministrationClientOptions
                {
                    Transport = new MockTransport(defaultInitialChallenge, CreateGetEkmConnectionResponse()),
                });

            Response<KeyVaultEkmConnection> response = await client.GetEkmConnectionAsync().ConfigureAwait(false);

            Assert.AreEqual(200, response.GetRawResponse().Status);
            Assert.IsNotNull(lastRequestContext);
            Assert.IsFalse(lastRequestContext.Value.IsProofOfPossessionEnabled);
        }

        [Test]
        public async Task EkmClientRequestsProofOfPossessionWhenEnabled()
        {
            TokenRequestContext? lastRequestContext = null;
            KeyVaultEkmClient client = new(
                VaultUri,
                new TokenCredentialStub((context, _) =>
                {
                    lastRequestContext = context;
                    return new AccessToken("token", DateTimeOffset.UtcNow.AddHours(1));
                }, true),
                new KeyVaultAdministrationClientOptions
                {
                    Transport = new MockTransport(defaultInitialChallenge, CreateGetEkmConnectionResponse()),
                    EnableProofOfPossession = true,
                });

            Response<KeyVaultEkmConnection> response = await client.GetEkmConnectionAsync().ConfigureAwait(false);

            Assert.AreEqual(200, response.GetRawResponse().Status);
            Assert.IsNotNull(lastRequestContext);
            Assert.IsTrue(lastRequestContext.Value.IsProofOfPossessionEnabled);
        }

        private static MockResponse CreateGetRoleDefinitionResponse() =>
            new MockResponse(200).WithJson("""
            {
              "id": "https://test.vault.azure.net/providers/Microsoft.Authorization/roleDefinitions/00000000-0000-0000-0000-000000000001",
              "name": "00000000-0000-0000-0000-000000000001",
              "type": "Microsoft.Authorization/roleDefinitions",
              "properties": {
                "roleName": "Test Role",
                "description": "Test role definition",
                "type": "CustomRole",
                "permissions": [],
                "assignableScopes": [
                  "/"
                ]
              }
            }
            """);

        private static MockResponse CreateGetEkmConnectionResponse() =>
            new MockResponse(200).WithJson("""
            {
              "host": "ekm.contoso.com",
              "path_prefix": "/keys",
              "server_ca_certificates": [
                "AQID"
              ],
              "server_subject_common_name": "CN=ekm.contoso.com"
            }
            """);
    }
}
