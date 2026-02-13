// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using NUnit.Framework;

namespace Azure.Identity.Tests.ConfigurableCredentials
{
    public class ConfigurableCredentialCacheTests
    {
        private static IConfigurationSection BuildCredentialSection(string sectionPath, Dictionary<string, string> values)
        {
            var configData = new Dictionary<string, string>();
            foreach (var kvp in values)
            {
                configData[$"{sectionPath}:{kvp.Key}"] = kvp.Value;
            }

            var configuration = new ConfigurationBuilder()
                .AddInMemoryCollection(configData)
                .Build();

            return configuration.GetSection(sectionPath);
        }

        [Test]
        public void CreateKey_SameValuesDifferentPaths_ProducesSameKey()
        {
            var values = new Dictionary<string, string>
            {
                ["TenantId"] = "abc-123",
                ["CredentialSource"] = "AzureCli"
            };

            var section1 = BuildCredentialSection("Client1:Credential", values);
            var section2 = BuildCredentialSection("Client2:Credential", values);

            string key1 = ConfigurableCredentialCache.CreateKey(section1);
            string key2 = ConfigurableCredentialCache.CreateKey(section2);

            Assert.AreEqual(key1, key2);
        }

        [Test]
        public void CreateKey_DifferentValues_ProducesDifferentKeys()
        {
            var section1 = BuildCredentialSection("Client1:Credential", new Dictionary<string, string>
            {
                ["TenantId"] = "tenant-a"
            });
            var section2 = BuildCredentialSection("Client2:Credential", new Dictionary<string, string>
            {
                ["TenantId"] = "tenant-b"
            });

            string key1 = ConfigurableCredentialCache.CreateKey(section1);
            string key2 = ConfigurableCredentialCache.CreateKey(section2);

            Assert.AreNotEqual(key1, key2);
        }

        [Test]
        public void CreateKey_EmptySection_ProducesConsistentKey()
        {
            var section = BuildCredentialSection("Client:Credential", new Dictionary<string, string>());

            string key = ConfigurableCredentialCache.CreateKey(section);

            Assert.IsNotNull(key);
            Assert.IsNotEmpty(key);
            // Same empty section should produce the same hash
            var section2 = BuildCredentialSection("Other:Credential", new Dictionary<string, string>());
            Assert.AreEqual(key, ConfigurableCredentialCache.CreateKey(section2));
        }

        [Test]
        public void CreateKey_OrderIndependent_ProducesSameKey()
        {
            // Build two sections with the same values but inserted in different order
            var section1 = BuildCredentialSection("A:Credential", new Dictionary<string, string>
            {
                ["Zebra"] = "z",
                ["Alpha"] = "a"
            });
            var section2 = BuildCredentialSection("B:Credential", new Dictionary<string, string>
            {
                ["Alpha"] = "a",
                ["Zebra"] = "z"
            });

            string key1 = ConfigurableCredentialCache.CreateKey(section1);
            string key2 = ConfigurableCredentialCache.CreateKey(section2);

            Assert.AreEqual(key1, key2);
        }

        [Test]
        public void GetOrAdd_SameKey_ReturnsSameInstance()
        {
            var cache = new ConfigurableCredentialCache();
            int factoryCallCount = 0;

            var cred1 = cache.GetOrAdd("key1", () =>
            {
                factoryCallCount++;
                return new ConfigurableCredential();
            });

            var cred2 = cache.GetOrAdd("key1", () =>
            {
                factoryCallCount++;
                return new ConfigurableCredential();
            });

            Assert.AreSame(cred1, cred2);
            Assert.AreEqual(1, factoryCallCount);
        }

        [Test]
        public void GetOrAdd_DifferentKeys_ReturnsDifferentInstances()
        {
            var cache = new ConfigurableCredentialCache();

            var cred1 = cache.GetOrAdd("key1", () => new ConfigurableCredential());
            var cred2 = cache.GetOrAdd("key2", () => new ConfigurableCredential());

            Assert.AreNotSame(cred1, cred2);
        }

        [Test]
        public void CreateKey_NestedValues_ProducesSameKeyRegardlessOfPath()
        {
            var configData1 = new Dictionary<string, string>
            {
                ["Client1:Credential:TenantId"] = "abc",
                ["Client1:Credential:Nested:Value"] = "deep"
            };
            var configData2 = new Dictionary<string, string>
            {
                ["Client2:Credential:TenantId"] = "abc",
                ["Client2:Credential:Nested:Value"] = "deep"
            };

            var config1 = new ConfigurationBuilder().AddInMemoryCollection(configData1).Build();
            var config2 = new ConfigurationBuilder().AddInMemoryCollection(configData2).Build();

            string key1 = ConfigurableCredentialCache.CreateKey(config1.GetSection("Client1:Credential"));
            string key2 = ConfigurableCredentialCache.CreateKey(config2.GetSection("Client2:Credential"));

            Assert.AreEqual(key1, key2);
        }

        [Test]
        public void CreateKey_SameArrayValues_ProducesSameKey()
        {
            var section1 = BuildCredentialSection("Client1:Credential", new Dictionary<string, string>
            {
                ["CredentialSource"] = "AzureCli",
                ["AdditionallyAllowedTenants:0"] = "tenant-a",
                ["AdditionallyAllowedTenants:1"] = "tenant-b",
            });
            var section2 = BuildCredentialSection("Client2:Credential", new Dictionary<string, string>
            {
                ["CredentialSource"] = "AzureCli",
                ["AdditionallyAllowedTenants:0"] = "tenant-a",
                ["AdditionallyAllowedTenants:1"] = "tenant-b",
            });

            string key1 = ConfigurableCredentialCache.CreateKey(section1);
            string key2 = ConfigurableCredentialCache.CreateKey(section2);

            Assert.AreEqual(key1, key2);
        }

        [Test]
        public void CreateKey_DifferentArrayValues_ProducesDifferentKeys()
        {
            var section1 = BuildCredentialSection("Client1:Credential", new Dictionary<string, string>
            {
                ["CredentialSource"] = "AzureCli",
                ["AdditionallyAllowedTenants:0"] = "tenant-a",
                ["AdditionallyAllowedTenants:1"] = "tenant-b",
            });
            var section2 = BuildCredentialSection("Client2:Credential", new Dictionary<string, string>
            {
                ["CredentialSource"] = "AzureCli",
                ["AdditionallyAllowedTenants:0"] = "tenant-a",
                ["AdditionallyAllowedTenants:1"] = "tenant-c",
            });

            string key1 = ConfigurableCredentialCache.CreateKey(section1);
            string key2 = ConfigurableCredentialCache.CreateKey(section2);

            Assert.AreNotEqual(key1, key2);
        }

        [Test]
        public void CreateKey_DifferentArrayLength_ProducesDifferentKeys()
        {
            var section1 = BuildCredentialSection("Client1:Credential", new Dictionary<string, string>
            {
                ["CredentialSource"] = "AzureCli",
                ["AdditionallyAllowedTenants:0"] = "tenant-a",
            });
            var section2 = BuildCredentialSection("Client2:Credential", new Dictionary<string, string>
            {
                ["CredentialSource"] = "AzureCli",
                ["AdditionallyAllowedTenants:0"] = "tenant-a",
                ["AdditionallyAllowedTenants:1"] = "tenant-b",
            });

            string key1 = ConfigurableCredentialCache.CreateKey(section1);
            string key2 = ConfigurableCredentialCache.CreateKey(section2);

            Assert.AreNotEqual(key1, key2);
        }
    }
}
