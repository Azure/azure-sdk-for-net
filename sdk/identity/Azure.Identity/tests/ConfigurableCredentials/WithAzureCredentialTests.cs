// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NUnit.Framework;

namespace Azure.Identity.Tests.ConfigurableCredentials
{
    public class WithAzureCredentialTests
    {
        internal class SimpleTestClient
        {
            public SimpleTestClient(SimpleTestSettings settings)
            {
                Settings = settings;
            }

            public SimpleTestSettings Settings { get; }
        }

        internal class SimpleTestClient2
        {
            public SimpleTestClient2(SimpleTestSettings2 settings)
            {
                Settings = settings;
            }

            public SimpleTestSettings2 Settings { get; }
        }

        internal class SimpleTestSettings : ClientSettings
        {
            public string Endpoint { get; set; }

            protected override void BindCore(IConfigurationSection section)
            {
                Endpoint = section["Endpoint"];
            }
        }

        internal class SimpleTestSettings2 : ClientSettings
        {
            public string Endpoint { get; set; }

            protected override void BindCore(IConfigurationSection section)
            {
                Endpoint = section["Endpoint"];
            }
        }

        [Test]
        public void SameCredentialConfig_ReturnsSharedCredentialInstance()
        {
            HostApplicationBuilder builder = Host.CreateApplicationBuilder();
            builder.Configuration.AddInMemoryCollection(new Dictionary<string, string>
            {
                ["Client1:Endpoint"] = "https://one.example.com",
                ["Client1:Credential:CredentialSource"] = "AzureCli",
                ["Client1:Credential:TenantId"] = "tenant-abc",
                ["Client2:Endpoint"] = "https://two.example.com",
                ["Client2:Credential:CredentialSource"] = "AzureCli",
                ["Client2:Credential:TenantId"] = "tenant-abc",
            });

            builder.AddClient<SimpleTestClient, SimpleTestSettings>("Client1").WithAzureCredential();
            builder.AddClient<SimpleTestClient2, SimpleTestSettings2>("Client2").WithAzureCredential();

            IHost host = builder.Build();
            var client1 = host.Services.GetRequiredService<SimpleTestClient>();
            var client2 = host.Services.GetRequiredService<SimpleTestClient2>();

            Assert.That(client1.Settings.CredentialProvider, Is.Not.Null);
            Assert.That(client2.Settings.CredentialProvider, Is.Not.Null);
            Assert.That(client1.Settings.CredentialProvider, Is.SameAs(client2.Settings.CredentialProvider));
        }

        [Test]
        public void DifferentCredentialConfig_ReturnsDifferentCredentialInstances()
        {
            HostApplicationBuilder builder = Host.CreateApplicationBuilder();
            builder.Configuration.AddInMemoryCollection(new Dictionary<string, string>
            {
                ["Client1:Endpoint"] = "https://one.example.com",
                ["Client1:Credential:CredentialSource"] = "AzureCli",
                ["Client1:Credential:TenantId"] = "tenant-abc",
                ["Client2:Endpoint"] = "https://two.example.com",
                ["Client2:Credential:CredentialSource"] = "AzureCli",
                ["Client2:Credential:TenantId"] = "tenant-xyz",
            });

            builder.AddClient<SimpleTestClient, SimpleTestSettings>("Client1").WithAzureCredential();
            builder.AddClient<SimpleTestClient2, SimpleTestSettings2>("Client2").WithAzureCredential();

            IHost host = builder.Build();
            var client1 = host.Services.GetRequiredService<SimpleTestClient>();
            var client2 = host.Services.GetRequiredService<SimpleTestClient2>();

            Assert.That(client1.Settings.CredentialProvider, Is.Not.Null);
            Assert.That(client2.Settings.CredentialProvider, Is.Not.Null);
            Assert.That(client1.Settings.CredentialProvider, Is.Not.SameAs(client2.Settings.CredentialProvider));
        }

        [Test]
        public void SameCredentialConfig_ApiKey_ReturnsSharedInstance()
        {
            HostApplicationBuilder builder = Host.CreateApplicationBuilder();
            builder.Configuration.AddInMemoryCollection(new Dictionary<string, string>
            {
                ["Client1:Endpoint"] = "https://one.example.com",
                ["Client1:Credential:CredentialSource"] = "ApiKey",
                ["Client1:Credential:Key"] = "my-shared-key",
                ["Client2:Endpoint"] = "https://two.example.com",
                ["Client2:Credential:CredentialSource"] = "ApiKey",
                ["Client2:Credential:Key"] = "my-shared-key",
            });

            builder.AddClient<SimpleTestClient, SimpleTestSettings>("Client1").WithAzureCredential();
            builder.AddClient<SimpleTestClient2, SimpleTestSettings2>("Client2").WithAzureCredential();

            IHost host = builder.Build();
            var client1 = host.Services.GetRequiredService<SimpleTestClient>();
            var client2 = host.Services.GetRequiredService<SimpleTestClient2>();

            Assert.That(client1.Settings.CredentialProvider, Is.SameAs(client2.Settings.CredentialProvider));
        }

        [Test]
        public void DifferentApiKeys_ReturnsDifferentInstances()
        {
            HostApplicationBuilder builder = Host.CreateApplicationBuilder();
            builder.Configuration.AddInMemoryCollection(new Dictionary<string, string>
            {
                ["Client1:Endpoint"] = "https://one.example.com",
                ["Client1:Credential:CredentialSource"] = "ApiKey",
                ["Client1:Credential:Key"] = "key-one",
                ["Client2:Endpoint"] = "https://two.example.com",
                ["Client2:Credential:CredentialSource"] = "ApiKey",
                ["Client2:Credential:Key"] = "key-two",
            });

            builder.AddClient<SimpleTestClient, SimpleTestSettings>("Client1").WithAzureCredential();
            builder.AddClient<SimpleTestClient2, SimpleTestSettings2>("Client2").WithAzureCredential();

            IHost host = builder.Build();
            var client1 = host.Services.GetRequiredService<SimpleTestClient>();
            var client2 = host.Services.GetRequiredService<SimpleTestClient2>();

            Assert.That(client1.Settings.CredentialProvider, Is.Not.SameAs(client2.Settings.CredentialProvider));
        }

        [Test]
        public void KeyedClients_SameCredentialConfig_ReturnsSharedInstance()
        {
            HostApplicationBuilder builder = Host.CreateApplicationBuilder();
            builder.Configuration.AddInMemoryCollection(new Dictionary<string, string>
            {
                ["Client1:Endpoint"] = "https://one.example.com",
                ["Client1:Credential:CredentialSource"] = "AzureCli",
                ["Client1:Credential:TenantId"] = "tenant-abc",
                ["Client2:Endpoint"] = "https://two.example.com",
                ["Client2:Credential:CredentialSource"] = "AzureCli",
                ["Client2:Credential:TenantId"] = "tenant-abc",
            });

            builder.AddKeyedClient<SimpleTestClient, SimpleTestSettings>("key1", "Client1").WithAzureCredential();
            builder.AddKeyedClient<SimpleTestClient, SimpleTestSettings>("key2", "Client2").WithAzureCredential();

            IHost host = builder.Build();
            var client1 = host.Services.GetRequiredKeyedService<SimpleTestClient>("key1");
            var client2 = host.Services.GetRequiredKeyedService<SimpleTestClient>("key2");

            Assert.That(client1.Settings.CredentialProvider, Is.Not.Null);
            Assert.That(client2.Settings.CredentialProvider, Is.Not.Null);
            Assert.That(client1.Settings.CredentialProvider, Is.SameAs(client2.Settings.CredentialProvider));
        }

        [Test]
        public void KeyedClients_DifferentCredentialConfig_ReturnsDifferentInstances()
        {
            HostApplicationBuilder builder = Host.CreateApplicationBuilder();
            builder.Configuration.AddInMemoryCollection(new Dictionary<string, string>
            {
                ["Client1:Endpoint"] = "https://one.example.com",
                ["Client1:Credential:CredentialSource"] = "AzureCli",
                ["Client1:Credential:TenantId"] = "tenant-abc",
                ["Client2:Endpoint"] = "https://two.example.com",
                ["Client2:Credential:CredentialSource"] = "AzureCli",
                ["Client2:Credential:TenantId"] = "tenant-xyz",
            });

            builder.AddKeyedClient<SimpleTestClient, SimpleTestSettings>("key1", "Client1").WithAzureCredential();
            builder.AddKeyedClient<SimpleTestClient, SimpleTestSettings>("key2", "Client2").WithAzureCredential();

            IHost host = builder.Build();
            var client1 = host.Services.GetRequiredKeyedService<SimpleTestClient>("key1");
            var client2 = host.Services.GetRequiredKeyedService<SimpleTestClient>("key2");

            Assert.That(client1.Settings.CredentialProvider, Is.Not.Null);
            Assert.That(client2.Settings.CredentialProvider, Is.Not.Null);
            Assert.That(client1.Settings.CredentialProvider, Is.Not.SameAs(client2.Settings.CredentialProvider));
        }

        [Test]
        public void MixedKeyedAndNonKeyed_SameCredentialConfig_ReturnsSharedInstance()
        {
            HostApplicationBuilder builder = Host.CreateApplicationBuilder();
            builder.Configuration.AddInMemoryCollection(new Dictionary<string, string>
            {
                ["Client1:Endpoint"] = "https://one.example.com",
                ["Client1:Credential:CredentialSource"] = "AzureCli",
                ["Client1:Credential:TenantId"] = "tenant-abc",
                ["Client2:Endpoint"] = "https://two.example.com",
                ["Client2:Credential:CredentialSource"] = "AzureCli",
                ["Client2:Credential:TenantId"] = "tenant-abc",
            });

            builder.AddClient<SimpleTestClient, SimpleTestSettings>("Client1").WithAzureCredential();
            builder.AddKeyedClient<SimpleTestClient2, SimpleTestSettings2>("keyed", "Client2").WithAzureCredential();

            IHost host = builder.Build();
            var client1 = host.Services.GetRequiredService<SimpleTestClient>();
            var client2 = host.Services.GetRequiredKeyedService<SimpleTestClient2>("keyed");

            Assert.That(client1.Settings.CredentialProvider, Is.SameAs(client2.Settings.CredentialProvider));
        }

        [Test]
        public void SeparateHosts_SameCredentialConfig_SharesCredentialInstance()
        {
            var sharedConfig = new Dictionary<string, string>
            {
                ["MyClient:Endpoint"] = "https://test.example.com",
                ["MyClient:Credential:CredentialSource"] = "AzureCli",
                ["MyClient:Credential:TenantId"] = "tenant-abc",
            };

            HostApplicationBuilder builder1 = Host.CreateApplicationBuilder();
            builder1.Configuration.AddInMemoryCollection(sharedConfig);
            builder1.AddClient<SimpleTestClient, SimpleTestSettings>("MyClient").WithAzureCredential();

            HostApplicationBuilder builder2 = Host.CreateApplicationBuilder();
            builder2.Configuration.AddInMemoryCollection(sharedConfig);
            builder2.AddClient<SimpleTestClient, SimpleTestSettings>("MyClient").WithAzureCredential();

            IHost host1 = builder1.Build();
            IHost host2 = builder2.Build();
            var client1 = host1.Services.GetRequiredService<SimpleTestClient>();
            var client2 = host2.Services.GetRequiredService<SimpleTestClient>();

            Assert.That(client1.Settings.CredentialProvider, Is.Not.Null);
            Assert.That(client2.Settings.CredentialProvider, Is.Not.Null);
            Assert.That(client1.Settings.CredentialProvider, Is.SameAs(client2.Settings.CredentialProvider));
        }

        [Test]
        public void SeparateHosts_KeyedClients_SameConfig_SharesCredentialInstance()
        {
            var sharedConfig = new Dictionary<string, string>
            {
                ["MyClient:Endpoint"] = "https://test.example.com",
                ["MyClient:Credential:CredentialSource"] = "ApiKey",
                ["MyClient:Credential:Key"] = "shared-key",
            };

            HostApplicationBuilder builder1 = Host.CreateApplicationBuilder();
            builder1.Configuration.AddInMemoryCollection(sharedConfig);
            builder1.AddKeyedClient<SimpleTestClient, SimpleTestSettings>("k1", "MyClient").WithAzureCredential();

            HostApplicationBuilder builder2 = Host.CreateApplicationBuilder();
            builder2.Configuration.AddInMemoryCollection(sharedConfig);
            builder2.AddKeyedClient<SimpleTestClient, SimpleTestSettings>("k1", "MyClient").WithAzureCredential();

            IHost host1 = builder1.Build();
            IHost host2 = builder2.Build();
            var client1 = host1.Services.GetRequiredKeyedService<SimpleTestClient>("k1");
            var client2 = host2.Services.GetRequiredKeyedService<SimpleTestClient>("k1");

            Assert.That(client1.Settings.CredentialProvider, Is.SameAs(client2.Settings.CredentialProvider));
        }

        [Test]
        public void SameConfigSectionPath_SharesCredentialInstance()
        {
            HostApplicationBuilder builder = Host.CreateApplicationBuilder();
            builder.Configuration.AddInMemoryCollection(new Dictionary<string, string>
            {
                ["SharedSection:Endpoint"] = "https://test.example.com",
                ["SharedSection:Credential:CredentialSource"] = "AzureCli",
                ["SharedSection:Credential:TenantId"] = "tenant-abc",
            });

            // Two different client types pointing at the exact same config section
            builder.AddClient<SimpleTestClient, SimpleTestSettings>("SharedSection").WithAzureCredential();
            builder.AddKeyedClient<SimpleTestClient2, SimpleTestSettings2>("keyed", "SharedSection").WithAzureCredential();

            IHost host = builder.Build();
            var client1 = host.Services.GetRequiredService<SimpleTestClient>();
            var client2 = host.Services.GetRequiredKeyedService<SimpleTestClient2>("keyed");

            Assert.That(client1.Settings.CredentialProvider, Is.SameAs(client2.Settings.CredentialProvider));
        }

        [Test]
        public void SingleClient_CredentialProviderIsSet()
        {
            HostApplicationBuilder builder = Host.CreateApplicationBuilder();
            builder.Configuration.AddInMemoryCollection(new Dictionary<string, string>
            {
                ["MyClient:Endpoint"] = "https://test.example.com",
                ["MyClient:Credential:CredentialSource"] = "AzureCli",
            });

            builder.AddClient<SimpleTestClient, SimpleTestSettings>("MyClient").WithAzureCredential();

            IHost host = builder.Build();
            var client = host.Services.GetRequiredService<SimpleTestClient>();

            Assert.That(client.Settings.CredentialProvider, Is.Not.Null);
        }

        [Test]
        public void CredentialSourceDifference_ReturnsDifferentInstances()
        {
            // Same TenantId but different CredentialSource should produce different credentials
            HostApplicationBuilder builder = Host.CreateApplicationBuilder();
            builder.Configuration.AddInMemoryCollection(new Dictionary<string, string>
            {
                ["Client1:Endpoint"] = "https://one.example.com",
                ["Client1:Credential:CredentialSource"] = "AzureCli",
                ["Client1:Credential:TenantId"] = "tenant-abc",
                ["Client2:Endpoint"] = "https://two.example.com",
                ["Client2:Credential:CredentialSource"] = "AzurePowerShell",
                ["Client2:Credential:TenantId"] = "tenant-abc",
            });

            builder.AddClient<SimpleTestClient, SimpleTestSettings>("Client1").WithAzureCredential();
            builder.AddClient<SimpleTestClient2, SimpleTestSettings2>("Client2").WithAzureCredential();

            IHost host = builder.Build();
            var client1 = host.Services.GetRequiredService<SimpleTestClient>();
            var client2 = host.Services.GetRequiredService<SimpleTestClient2>();

            Assert.That(client1.Settings.CredentialProvider, Is.Not.SameAs(client2.Settings.CredentialProvider));
        }

        [Test]
        public void ExtraCredentialProperty_ReturnsDifferentInstances()
        {
            // One section has an extra property the other doesn't — they should not share
            HostApplicationBuilder builder = Host.CreateApplicationBuilder();
            builder.Configuration.AddInMemoryCollection(new Dictionary<string, string>
            {
                ["Client1:Endpoint"] = "https://one.example.com",
                ["Client1:Credential:CredentialSource"] = "AzureCli",
                ["Client2:Endpoint"] = "https://two.example.com",
                ["Client2:Credential:CredentialSource"] = "AzureCli",
                ["Client2:Credential:TenantId"] = "extra-tenant",
            });

            builder.AddClient<SimpleTestClient, SimpleTestSettings>("Client1").WithAzureCredential();
            builder.AddClient<SimpleTestClient2, SimpleTestSettings2>("Client2").WithAzureCredential();

            IHost host = builder.Build();
            var client1 = host.Services.GetRequiredService<SimpleTestClient>();
            var client2 = host.Services.GetRequiredService<SimpleTestClient2>();

            Assert.That(client1.Settings.CredentialProvider, Is.Not.SameAs(client2.Settings.CredentialProvider));
        }

        [Test]
        public void SameAllowedTenants_ReturnsSharedInstance()
        {
            HostApplicationBuilder builder = Host.CreateApplicationBuilder();
            builder.Configuration.AddInMemoryCollection(new Dictionary<string, string>
            {
                ["Client1:Endpoint"] = "https://one.example.com",
                ["Client1:Credential:CredentialSource"] = "AzureCli",
                ["Client1:Credential:AdditionallyAllowedTenants:0"] = "tenant-a",
                ["Client1:Credential:AdditionallyAllowedTenants:1"] = "tenant-b",
                ["Client2:Endpoint"] = "https://two.example.com",
                ["Client2:Credential:CredentialSource"] = "AzureCli",
                ["Client2:Credential:AdditionallyAllowedTenants:0"] = "tenant-a",
                ["Client2:Credential:AdditionallyAllowedTenants:1"] = "tenant-b",
            });

            builder.AddClient<SimpleTestClient, SimpleTestSettings>("Client1").WithAzureCredential();
            builder.AddClient<SimpleTestClient2, SimpleTestSettings2>("Client2").WithAzureCredential();

            IHost host = builder.Build();
            var client1 = host.Services.GetRequiredService<SimpleTestClient>();
            var client2 = host.Services.GetRequiredService<SimpleTestClient2>();

            Assert.That(client1.Settings.CredentialProvider, Is.SameAs(client2.Settings.CredentialProvider));
        }

        [Test]
        public void DifferentAllowedTenants_ReturnsDifferentInstances()
        {
            HostApplicationBuilder builder = Host.CreateApplicationBuilder();
            builder.Configuration.AddInMemoryCollection(new Dictionary<string, string>
            {
                ["Client1:Endpoint"] = "https://one.example.com",
                ["Client1:Credential:CredentialSource"] = "AzureCli",
                ["Client1:Credential:AdditionallyAllowedTenants:0"] = "tenant-a",
                ["Client1:Credential:AdditionallyAllowedTenants:1"] = "tenant-b",
                ["Client2:Endpoint"] = "https://two.example.com",
                ["Client2:Credential:CredentialSource"] = "AzureCli",
                ["Client2:Credential:AdditionallyAllowedTenants:0"] = "tenant-a",
                ["Client2:Credential:AdditionallyAllowedTenants:1"] = "tenant-c",
            });

            builder.AddClient<SimpleTestClient, SimpleTestSettings>("Client1").WithAzureCredential();
            builder.AddClient<SimpleTestClient2, SimpleTestSettings2>("Client2").WithAzureCredential();

            IHost host = builder.Build();
            var client1 = host.Services.GetRequiredService<SimpleTestClient>();
            var client2 = host.Services.GetRequiredService<SimpleTestClient2>();

            Assert.That(client1.Settings.CredentialProvider, Is.Not.SameAs(client2.Settings.CredentialProvider));
        }

        [Test]
        public void DifferentAllowedTenantsLength_ReturnsDifferentInstances()
        {
            HostApplicationBuilder builder = Host.CreateApplicationBuilder();
            builder.Configuration.AddInMemoryCollection(new Dictionary<string, string>
            {
                ["Client1:Endpoint"] = "https://one.example.com",
                ["Client1:Credential:CredentialSource"] = "AzureCli",
                ["Client1:Credential:AdditionallyAllowedTenants:0"] = "tenant-a",
                ["Client2:Endpoint"] = "https://two.example.com",
                ["Client2:Credential:CredentialSource"] = "AzureCli",
                ["Client2:Credential:AdditionallyAllowedTenants:0"] = "tenant-a",
                ["Client2:Credential:AdditionallyAllowedTenants:1"] = "tenant-b",
            });

            builder.AddClient<SimpleTestClient, SimpleTestSettings>("Client1").WithAzureCredential();
            builder.AddClient<SimpleTestClient2, SimpleTestSettings2>("Client2").WithAzureCredential();

            IHost host = builder.Build();
            var client1 = host.Services.GetRequiredService<SimpleTestClient>();
            var client2 = host.Services.GetRequiredService<SimpleTestClient2>();

            Assert.That(client1.Settings.CredentialProvider, Is.Not.SameAs(client2.Settings.CredentialProvider));
        }

        [Test]
        public void DirectAndDI_SameCredentialConfig_SharesCredentialInstance()
        {
            // Create a credential via the direct ClientSettings path
            var config = new ConfigurationBuilder()
                .AddInMemoryCollection(new Dictionary<string, string>
                {
                    ["DirectClient:Endpoint"] = "https://direct.example.com",
                    ["DirectClient:Credential:CredentialSource"] = "AzureCli",
                    ["DirectClient:Credential:TenantId"] = "cross-path-tenant",
                })
                .Build();
            var directSettings = config.GetAzureClientSettings<SimpleTestSettings>("DirectClient");

            // Create a credential via the DI path with the same credential values
            HostApplicationBuilder builder = Host.CreateApplicationBuilder();
            builder.Configuration.AddInMemoryCollection(new Dictionary<string, string>
            {
                ["DIClient:Endpoint"] = "https://di.example.com",
                ["DIClient:Credential:CredentialSource"] = "AzureCli",
                ["DIClient:Credential:TenantId"] = "cross-path-tenant",
            });
            builder.AddClient<SimpleTestClient, SimpleTestSettings>("DIClient").WithAzureCredential();

            IHost host = builder.Build();
            var diClient = host.Services.GetRequiredService<SimpleTestClient>();

            Assert.That(directSettings.CredentialProvider, Is.Not.Null);
            Assert.That(diClient.Settings.CredentialProvider, Is.Not.Null);
            Assert.That(directSettings.CredentialProvider, Is.SameAs(diClient.Settings.CredentialProvider));
        }

        [Test]
        public void DirectAndDI_DifferentCredentialConfig_ReturnsDifferentInstances()
        {
            var config = new ConfigurationBuilder()
                .AddInMemoryCollection(new Dictionary<string, string>
                {
                    ["DirectClient:Endpoint"] = "https://direct.example.com",
                    ["DirectClient:Credential:CredentialSource"] = "AzureCli",
                    ["DirectClient:Credential:TenantId"] = "direct-tenant",
                })
                .Build();
            var directSettings = config.GetAzureClientSettings<SimpleTestSettings>("DirectClient");

            HostApplicationBuilder builder = Host.CreateApplicationBuilder();
            builder.Configuration.AddInMemoryCollection(new Dictionary<string, string>
            {
                ["DIClient:Endpoint"] = "https://di.example.com",
                ["DIClient:Credential:CredentialSource"] = "AzureCli",
                ["DIClient:Credential:TenantId"] = "di-tenant",
            });
            builder.AddClient<SimpleTestClient, SimpleTestSettings>("DIClient").WithAzureCredential();

            IHost host = builder.Build();
            var diClient = host.Services.GetRequiredService<SimpleTestClient>();

            Assert.That(directSettings.CredentialProvider, Is.Not.SameAs(diClient.Settings.CredentialProvider));
        }

        [Test]
        public void DirectPath_SameCredentialConfig_SharesCredentialInstance()
        {
            var config = new ConfigurationBuilder()
                .AddInMemoryCollection(new Dictionary<string, string>
                {
                    ["Client1:Endpoint"] = "https://one.example.com",
                    ["Client1:Credential:CredentialSource"] = "AzureCli",
                    ["Client1:Credential:TenantId"] = "direct-shared-tenant",
                    ["Client2:Endpoint"] = "https://two.example.com",
                    ["Client2:Credential:CredentialSource"] = "AzureCli",
                    ["Client2:Credential:TenantId"] = "direct-shared-tenant",
                })
                .Build();

            var settings1 = config.GetAzureClientSettings<SimpleTestSettings>("Client1");
            var settings2 = config.GetAzureClientSettings<SimpleTestSettings>("Client2");

            Assert.That(settings1.CredentialProvider, Is.Not.Null);
            Assert.That(settings2.CredentialProvider, Is.Not.Null);
            Assert.That(settings1.CredentialProvider, Is.SameAs(settings2.CredentialProvider));
        }

        [Test]
        public void DirectPath_DifferentCredentialConfig_ReturnsDifferentInstances()
        {
            var config = new ConfigurationBuilder()
                .AddInMemoryCollection(new Dictionary<string, string>
                {
                    ["Client1:Endpoint"] = "https://one.example.com",
                    ["Client1:Credential:CredentialSource"] = "AzureCli",
                    ["Client1:Credential:TenantId"] = "direct-tenant-a",
                    ["Client2:Endpoint"] = "https://two.example.com",
                    ["Client2:Credential:CredentialSource"] = "AzureCli",
                    ["Client2:Credential:TenantId"] = "direct-tenant-b",
                })
                .Build();

            var settings1 = config.GetAzureClientSettings<SimpleTestSettings>("Client1");
            var settings2 = config.GetAzureClientSettings<SimpleTestSettings>("Client2");

            Assert.That(settings1.CredentialProvider, Is.Not.SameAs(settings2.CredentialProvider));
        }
    }
}
