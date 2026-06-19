// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using Azure.Core;
using Azure.Identity;
using Microsoft.Extensions.Configuration;
using NUnit.Framework;

namespace Azure.Core.Tests.Identity.CredentialResolvers
{
    public class AzureCredentialResolverTests
    {
        private static IConfigurationSection BuildSection(IDictionary<string, string> values)
        {
            IConfiguration config = new ConfigurationBuilder()
                .AddInMemoryCollection(values)
                .Build();
            return config.GetSection("MyClient:Credential");
        }

        [Test]
        public void TryResolve_NullSection_ReturnsFalse()
        {
            var resolver = new AzureCredentialResolver();
            Assert.IsFalse(resolver.TryResolve(null, out var provider));
            Assert.IsNull(provider);
        }

        [Test]
        public void TryResolve_NonExistentSection_ReturnsFalse()
        {
            IConfiguration config = new ConfigurationBuilder()
                .AddInMemoryCollection(new Dictionary<string, string>())
                .Build();

            var resolver = new AzureCredentialResolver();
            Assert.IsFalse(resolver.TryResolve(config.GetSection("Missing"), out var provider));
            Assert.IsNull(provider);
        }

        [Test]
        public void TryResolve_NoCredentialSource_ReturnsFalse()
        {
            // Section exists but lacks a CredentialSource value — defer to next resolver.
            var section = BuildSection(new Dictionary<string, string>
            {
                ["MyClient:Credential:TenantId"] = "some-tenant",
            });

            var resolver = new AzureCredentialResolver();
            Assert.IsFalse(resolver.TryResolve(section, out var provider));
            Assert.IsNull(provider);
        }

        [Test]
        public void TryResolve_UnknownCredentialSource_ReturnsFalse()
        {
            var section = BuildSection(new Dictionary<string, string>
            {
                ["MyClient:Credential:CredentialSource"] = "NotAKnownCredential",
            });

            var resolver = new AzureCredentialResolver();
            Assert.IsFalse(resolver.TryResolve(section, out var provider));
            Assert.IsNull(provider);
        }

        [Test]
        public void TryResolve_ApiKeyCredential_ReturnsFalse()
        {
            // ApiKey is intentionally not claimed by AzureCredentialResolver. Consuming
            // libraries dispatch on Credential.CredentialSource themselves and read
            // Credential.Key directly.
            var section = BuildSection(new Dictionary<string, string>
            {
                ["MyClient:Credential:CredentialSource"] = "ApiKeyCredential",
                ["MyClient:Credential:Key"] = "secret-api-key-value",
            });

            var resolver = new AzureCredentialResolver();
            Assert.IsFalse(resolver.TryResolve(section, out var provider));
            Assert.IsNull(provider);
        }

        [Test]
        public void TryResolve_ApiKeyCredential_MissingKey_ReturnsFalse()
        {
            // ApiKey path always returns false, regardless of whether Key is present.
            var section = BuildSection(new Dictionary<string, string>
            {
                ["MyClient:Credential:CredentialSource"] = "ApiKeyCredential",
            });

            var resolver = new AzureCredentialResolver();
            Assert.IsFalse(resolver.TryResolve(section, out var provider));
            Assert.IsNull(provider);
        }

        [Test]
        public void TryResolve_ApiKeyShortName_NormalizedAndStillReturnsFalse()
        {
            // CredentialSettings normalizes "apikey" -> "apikeycredential"; the resolver
            // still defers regardless of which alias was supplied.
            var section = BuildSection(new Dictionary<string, string>
            {
                ["MyClient:Credential:CredentialSource"] = "apikey",
                ["MyClient:Credential:Key"] = "k",
            });

            var resolver = new AzureCredentialResolver();
            Assert.IsFalse(resolver.TryResolve(section, out var provider));
            Assert.IsNull(provider);
        }

        [Test]
        public void TryResolve_ChainedTokenCredential_ProducesChainedCredential()
        {
            var section = BuildSection(new Dictionary<string, string>
            {
                ["MyClient:Credential:CredentialSource"] = "ChainedTokenCredential",
                ["MyClient:Credential:Sources:0:CredentialSource"] = "AzureCliCredential",
                ["MyClient:Credential:Sources:1:CredentialSource"] = "EnvironmentCredential",
            });

            var resolver = new AzureCredentialResolver();
            Assert.IsTrue(resolver.TryResolve(section, out var provider));
            Assert.IsInstanceOf<ChainedTokenCredential>(provider);
        }

        [TestCase("AzureCliCredential")]
        [TestCase("AzurePowerShellCredential")]
        [TestCase("AzureDeveloperCliCredential")]
        [TestCase("VisualStudioCredential")]
        [TestCase("VisualStudioCodeCredential")]
        [TestCase("EnvironmentCredential")]
        [TestCase("WorkloadIdentityCredential")]
        [TestCase("ManagedIdentityCredential")]
        [TestCase("InteractiveBrowserCredential")]
        [TestCase("BrokerCredential")]
        public void TryResolve_KnownSingleSource_ProducesDefaultAzureCredential(string source)
        {
            // Single-source dispatch goes through DefaultAzureCredential, which preserves
            // env-var defaults, the broker reflection hop, and other existing behavior.
            var section = BuildSection(new Dictionary<string, string>
            {
                ["MyClient:Credential:CredentialSource"] = source,
            });

            var resolver = new AzureCredentialResolver();
            Assert.IsTrue(resolver.TryResolve(section, out var provider), $"Resolver should claim {source}");
            Assert.IsInstanceOf<DefaultAzureCredential>(provider);
        }

        [Test]
        public void Instance_ReturnsSameSingleton()
        {
            // Internal singleton is reused across all helper paths.
            Assert.AreSame(AzureCredentialResolver.Instance, AzureCredentialResolver.Instance);
        }
    }
}
