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
        public void GetOrAdd_SameValuesDifferentPaths_ReturnsSameInstance()
        {
            var cache = new ConfigurableCredentialCache();
            var values = new Dictionary<string, string>
            {
                ["TenantId"] = "abc-123",
                ["CredentialSource"] = "AzureCli"
            };

            var section1 = BuildCredentialSection("Client1:Credential", values);
            var section2 = BuildCredentialSection("Client2:Credential", values);

            var cred1 = cache.GetOrAdd(section1, () => new ConfigurableCredential());
            var cred2 = cache.GetOrAdd(section2, () => new ConfigurableCredential());

            Assert.AreSame(cred1, cred2);
        }

        [Test]
        public void GetOrAdd_DifferentValues_ReturnsDifferentInstances()
        {
            var cache = new ConfigurableCredentialCache();

            var section1 = BuildCredentialSection("Client1:Credential", new Dictionary<string, string>
            {
                ["TenantId"] = "tenant-a"
            });
            var section2 = BuildCredentialSection("Client2:Credential", new Dictionary<string, string>
            {
                ["TenantId"] = "tenant-b"
            });

            var cred1 = cache.GetOrAdd(section1, () => new ConfigurableCredential());
            var cred2 = cache.GetOrAdd(section2, () => new ConfigurableCredential());

            Assert.AreNotSame(cred1, cred2);
        }

        [Test]
        public void GetOrAdd_EmptySections_ReturnsSameInstance()
        {
            var cache = new ConfigurableCredentialCache();

            var section1 = BuildCredentialSection("Client:Credential", new Dictionary<string, string>());
            var section2 = BuildCredentialSection("Other:Credential", new Dictionary<string, string>());

            var cred1 = cache.GetOrAdd(section1, () => new ConfigurableCredential());
            var cred2 = cache.GetOrAdd(section2, () => new ConfigurableCredential());

            Assert.AreSame(cred1, cred2);
        }

        [Test]
        public void GetOrAdd_OrderIndependent_ReturnsSameInstance()
        {
            var cache = new ConfigurableCredentialCache();

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

            var cred1 = cache.GetOrAdd(section1, () => new ConfigurableCredential());
            var cred2 = cache.GetOrAdd(section2, () => new ConfigurableCredential());

            Assert.AreSame(cred1, cred2);
        }

        [Test]
        public void GetOrAdd_SameSection_FactoryCalledOnce()
        {
            var cache = new ConfigurableCredentialCache();
            int factoryCallCount = 0;

            var section1 = BuildCredentialSection("Client1:Credential", new Dictionary<string, string>
            {
                ["TenantId"] = "abc"
            });
            var section2 = BuildCredentialSection("Client2:Credential", new Dictionary<string, string>
            {
                ["TenantId"] = "abc"
            });

            var cred1 = cache.GetOrAdd(section1, () =>
            {
                factoryCallCount++;
                return new ConfigurableCredential();
            });

            var cred2 = cache.GetOrAdd(section2, () =>
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
            var cache = new ConfigurableCredentialCache();

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

            var cred1 = cache.GetOrAdd(config1.GetSection("Client1:Credential"), () => new ConfigurableCredential());
            var cred2 = cache.GetOrAdd(config2.GetSection("Client2:Credential"), () => new ConfigurableCredential());

            Assert.AreSame(cred1, cred2);
        }

        [Test]
        public void GetOrAdd_SameArrayValues_ReturnsSameInstance()
        {
            var cache = new ConfigurableCredentialCache();

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

            var cred1 = cache.GetOrAdd(section1, () => new ConfigurableCredential());
            var cred2 = cache.GetOrAdd(section2, () => new ConfigurableCredential());

            Assert.AreSame(cred1, cred2);
        }

        [Test]
        public void GetOrAdd_DifferentArrayValues_ReturnsDifferentInstances()
        {
            var cache = new ConfigurableCredentialCache();

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

            var cred1 = cache.GetOrAdd(section1, () => new ConfigurableCredential());
            var cred2 = cache.GetOrAdd(section2, () => new ConfigurableCredential());

            Assert.AreNotSame(cred1, cred2);
        }

        [Test]
        public void GetOrAdd_DifferentArrayLength_ReturnsDifferentInstances()
        {
            var cache = new ConfigurableCredentialCache();

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

            var cred1 = cache.GetOrAdd(section1, () => new ConfigurableCredential());
            var cred2 = cache.GetOrAdd(section2, () => new ConfigurableCredential());

            Assert.AreNotSame(cred1, cred2);
        }
    }
}
