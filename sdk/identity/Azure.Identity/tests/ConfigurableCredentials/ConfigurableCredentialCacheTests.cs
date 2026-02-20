// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
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

        // Each test uses a unique nonce in its values to avoid interference from the global static cache.
        private static string Unique() => Guid.NewGuid().ToString("N");

        [Test]
        public void GetOrAdd_SameValuesDifferentPaths_ReturnsSameInstance()
        {
            string nonce = Unique();
            var values = new Dictionary<string, string>
            {
                ["TenantId"] = nonce,
                ["CredentialSource"] = "AzureCli"
            };

            var section1 = BuildCredentialSection("Client1:Credential", values);
            var section2 = BuildCredentialSection("Client2:Credential", values);

            var cred1 = ConfigurableCredentialCache.GetOrAdd(section1, () => new ConfigurableCredential());
            var cred2 = ConfigurableCredentialCache.GetOrAdd(section2, () => new ConfigurableCredential());

            Assert.AreSame(cred1, cred2);
        }

        [Test]
        public void GetOrAdd_DifferentValues_ReturnsDifferentInstances()
        {
            var section1 = BuildCredentialSection("Client1:Credential", new Dictionary<string, string>
            {
                ["TenantId"] = Unique()
            });
            var section2 = BuildCredentialSection("Client2:Credential", new Dictionary<string, string>
            {
                ["TenantId"] = Unique()
            });

            var cred1 = ConfigurableCredentialCache.GetOrAdd(section1, () => new ConfigurableCredential());
            var cred2 = ConfigurableCredentialCache.GetOrAdd(section2, () => new ConfigurableCredential());

            Assert.AreNotSame(cred1, cred2);
        }

        [Test]
        public void GetOrAdd_EmptySections_ReturnsSameInstance()
        {
            var section1 = BuildCredentialSection("Client:Credential", new Dictionary<string, string>());
            var section2 = BuildCredentialSection("Other:Credential", new Dictionary<string, string>());

            var cred1 = ConfigurableCredentialCache.GetOrAdd(section1, () => new ConfigurableCredential());
            var cred2 = ConfigurableCredentialCache.GetOrAdd(section2, () => new ConfigurableCredential());

            Assert.AreSame(cred1, cred2);
        }

        [Test]
        public void GetOrAdd_OrderIndependent_ReturnsSameInstance()
        {
            string nonce = Unique();
            var section1 = BuildCredentialSection("A:Credential", new Dictionary<string, string>
            {
                ["Zebra"] = nonce,
                ["Alpha"] = "a"
            });
            var section2 = BuildCredentialSection("B:Credential", new Dictionary<string, string>
            {
                ["Alpha"] = "a",
                ["Zebra"] = nonce
            });

            var cred1 = ConfigurableCredentialCache.GetOrAdd(section1, () => new ConfigurableCredential());
            var cred2 = ConfigurableCredentialCache.GetOrAdd(section2, () => new ConfigurableCredential());

            Assert.AreSame(cred1, cred2);
        }

        [Test]
        public void GetOrAdd_SameValues_FactoryCalledOnce()
        {
            string nonce = Unique();
            int factoryCallCount = 0;

            var section1 = BuildCredentialSection("Client1:Credential", new Dictionary<string, string>
            {
                ["TenantId"] = nonce
            });
            var section2 = BuildCredentialSection("Client2:Credential", new Dictionary<string, string>
            {
                ["TenantId"] = nonce
            });

            var cred1 = ConfigurableCredentialCache.GetOrAdd(section1, () =>
            {
                factoryCallCount++;
                return new ConfigurableCredential();
            });

            var cred2 = ConfigurableCredentialCache.GetOrAdd(section2, () =>
            {
                factoryCallCount++;
                return new ConfigurableCredential();
            });

            Assert.AreSame(cred1, cred2);
            Assert.AreEqual(1, factoryCallCount);
        }

        [Test]
        public void GetOrAdd_NestedValues_SameContentReturnsSameInstance()
        {
            string nonce = Unique();
            var configData1 = new Dictionary<string, string>
            {
                ["Client1:Credential:TenantId"] = nonce,
                ["Client1:Credential:Nested:Value"] = "deep"
            };
            var configData2 = new Dictionary<string, string>
            {
                ["Client2:Credential:TenantId"] = nonce,
                ["Client2:Credential:Nested:Value"] = "deep"
            };

            var config1 = new ConfigurationBuilder().AddInMemoryCollection(configData1).Build();
            var config2 = new ConfigurationBuilder().AddInMemoryCollection(configData2).Build();

            var cred1 = ConfigurableCredentialCache.GetOrAdd(config1.GetSection("Client1:Credential"), () => new ConfigurableCredential());
            var cred2 = ConfigurableCredentialCache.GetOrAdd(config2.GetSection("Client2:Credential"), () => new ConfigurableCredential());

            Assert.AreSame(cred1, cred2);
        }

        [Test]
        public void GetOrAdd_SameArrayValues_ReturnsSameInstance()
        {
            string nonce = Unique();
            var section1 = BuildCredentialSection("Client1:Credential", new Dictionary<string, string>
            {
                ["CredentialSource"] = nonce,
                ["AdditionallyAllowedTenants:0"] = "tenant-a",
                ["AdditionallyAllowedTenants:1"] = "tenant-b",
            });
            var section2 = BuildCredentialSection("Client2:Credential", new Dictionary<string, string>
            {
                ["CredentialSource"] = nonce,
                ["AdditionallyAllowedTenants:0"] = "tenant-a",
                ["AdditionallyAllowedTenants:1"] = "tenant-b",
            });

            var cred1 = ConfigurableCredentialCache.GetOrAdd(section1, () => new ConfigurableCredential());
            var cred2 = ConfigurableCredentialCache.GetOrAdd(section2, () => new ConfigurableCredential());

            Assert.AreSame(cred1, cred2);
        }

        [Test]
        public void GetOrAdd_DifferentArrayValues_ReturnsDifferentInstances()
        {
            string nonce = Unique();
            var section1 = BuildCredentialSection("Client1:Credential", new Dictionary<string, string>
            {
                ["CredentialSource"] = nonce,
                ["AdditionallyAllowedTenants:0"] = Unique(),
            });
            var section2 = BuildCredentialSection("Client2:Credential", new Dictionary<string, string>
            {
                ["CredentialSource"] = nonce,
                ["AdditionallyAllowedTenants:0"] = Unique(),
            });

            var cred1 = ConfigurableCredentialCache.GetOrAdd(section1, () => new ConfigurableCredential());
            var cred2 = ConfigurableCredentialCache.GetOrAdd(section2, () => new ConfigurableCredential());

            Assert.AreNotSame(cred1, cred2);
        }

        [Test]
        public void GetOrAdd_DifferentArrayLength_ReturnsDifferentInstances()
        {
            string nonce = Unique();
            var section1 = BuildCredentialSection("Client1:Credential", new Dictionary<string, string>
            {
                ["CredentialSource"] = nonce,
                ["AdditionallyAllowedTenants:0"] = "tenant-a",
            });
            var section2 = BuildCredentialSection("Client2:Credential", new Dictionary<string, string>
            {
                ["CredentialSource"] = nonce,
                ["AdditionallyAllowedTenants:0"] = "tenant-a",
                ["AdditionallyAllowedTenants:1"] = "tenant-b",
            });

            var cred1 = ConfigurableCredentialCache.GetOrAdd(section1, () => new ConfigurableCredential());
            var cred2 = ConfigurableCredentialCache.GetOrAdd(section2, () => new ConfigurableCredential());

            Assert.AreNotSame(cred1, cred2);
        }
    }
}
