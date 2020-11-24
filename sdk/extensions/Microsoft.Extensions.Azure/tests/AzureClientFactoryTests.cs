// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using Azure.Identity;
using Microsoft.Extensions.Azure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;

namespace Azure.Core.Extensions.Tests
{
    public class AzureClientFactoryTests
    {
        [Test]
        public void AllowsResolvingFactoryAndCreatingClientInstance()
        {
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddAzureClients(builder => builder.AddTestClient(new Uri("http://localhost/")));

            ServiceProvider provider = serviceCollection.BuildServiceProvider();
            IAzureClientFactory<TestClient> factory = provider.GetService<IAzureClientFactory<TestClient>>();

            TestClient client = factory.CreateClient("Default");

            Assert.NotNull(client);
            Assert.AreEqual("http://localhost/", client.Uri.ToString());
        }

        [Test]
        public void ReturnsSameInstanceWhenResolvedMultipleTimes()
        {
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddAzureClients(builder => builder.AddTestClient(new Uri("http://localhost/")));

            ServiceProvider provider = serviceCollection.BuildServiceProvider();
            IAzureClientFactory<TestClient> factory = provider.GetService<IAzureClientFactory<TestClient>>();

            TestClient client = factory.CreateClient("Default");
            TestClient anotherClient = factory.CreateClient("Default");

            Assert.AreSame(client, anotherClient);
        }

        [Test]
        public void ExecutesConfigurationDelegateOnOptions()
        {
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddAzureClients(builder =>
                builder.AddTestClient(new Uri("http://localhost/")).ConfigureOptions(options => options.Property = "Value"));

            ServiceProvider provider = serviceCollection.BuildServiceProvider();
            IAzureClientFactory<TestClient> factory = provider.GetService<IAzureClientFactory<TestClient>>();

            TestClient client = factory.CreateClient("Default");

            Assert.AreSame(client, client);
            Assert.AreEqual("Value", client.Options.Property);
        }

        [Test]
        public void ExecutesConfigureDelegateOnOptions()
        {
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddAzureClients(builder => builder.AddTestClient(new Uri("http://localhost/")));
            serviceCollection.Configure<TestClientOptions>("Default", options => options.Property = "Value");

            ServiceProvider provider = serviceCollection.BuildServiceProvider();
            IAzureClientFactory<TestClient> factory = provider.GetService<IAzureClientFactory<TestClient>>();

            TestClient client = factory.CreateClient("Default");

            Assert.AreSame(client, client);
            Assert.AreEqual("Value", client.Options.Property);
        }

        [Test]
        public void SubsequentRegistrationOverrides()
        {
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddAzureClients(builder => builder.AddTestClient(new Uri("http://localhost/")));
            serviceCollection.AddAzureClients(builder => builder.AddTestClient(new Uri("http://otherhost/")));

            ServiceProvider provider = serviceCollection.BuildServiceProvider();
            IAzureClientFactory<TestClient> factory = provider.GetService<IAzureClientFactory<TestClient>>();

            TestClient client = factory.CreateClient("Default");

            Assert.AreEqual("http://otherhost/", client.Uri.ToString());
        }

        [Test]
        public void CanRegisterMultipleClients()
        {
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddAzureClients(builder => {
                builder.AddTestClient(new Uri("http://localhost/")).ConfigureOptions(options => options.Property = "Value1");
                builder.AddTestClient(new Uri("http://otherhost/")).WithName("OtherClient").ConfigureOptions(options => options.Property = "Value2");
            });

            ServiceProvider provider = serviceCollection.BuildServiceProvider();
            IAzureClientFactory<TestClient> factory = provider.GetService<IAzureClientFactory<TestClient>>();

            TestClient client = factory.CreateClient("Default");
            TestClient otherClient = factory.CreateClient("OtherClient");

            Assert.AreEqual("http://localhost/", client.Uri.ToString());
            Assert.AreEqual("http://otherhost/", otherClient.Uri.ToString());

            Assert.AreEqual("Value1", client.Options.Property);
            Assert.AreEqual("Value2", otherClient.Options.Property);

            Assert.AreNotSame(client, otherClient);
        }

        [Test]
        public void CanCreateClientFromConfiguration()
        {
            var configuration = GetConfiguration(new KeyValuePair<string, string>("uri", "http://localhost/"));
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddAzureClients(builder => builder.AddTestClient(configuration));

            ServiceProvider provider = serviceCollection.BuildServiceProvider();
            IAzureClientFactory<TestClient> factory = provider.GetService<IAzureClientFactory<TestClient>>();

            TestClient client = factory.CreateClient("Default");

            Assert.NotNull(client);
            Assert.AreEqual("http://localhost/", client.Uri.ToString());
        }

        [Test]
        public void SetsOptionsPropertiesFromConfiguration()
        {
            var configuration = GetConfiguration(
                new KeyValuePair<string, string>("connectionstring", "http://localhost/"),
                new KeyValuePair<string, string>("property", "value"),
                new KeyValuePair<string, string>("nested:property", "nested-value"),
                new KeyValuePair<string, string>("intproperty", "15")
                );

            var serviceCollection = new ServiceCollection();
            serviceCollection.AddAzureClients(builder => builder.AddTestClient(configuration));

            ServiceProvider provider = serviceCollection.BuildServiceProvider();
            IAzureClientFactory<TestClient> factory = provider.GetService<IAzureClientFactory<TestClient>>();

            TestClient client = factory.CreateClient("Default");

            Assert.AreEqual("value", client.Options.Property);
            Assert.AreEqual("nested-value", client.Options.Nested.Property);
            Assert.AreEqual(15, client.Options.IntProperty);
            Assert.AreEqual("http://localhost/", client.ConnectionString);
        }

        [Test]
        public void CreateClientThrowsWhenClientIsNotRegistered()
        {
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddAzureClients(builder => builder.AddTestClient(new Uri("http://localhost/")));

            ServiceProvider provider = serviceCollection.BuildServiceProvider();
            IAzureClientFactory<TestClient> factory = provider.GetService<IAzureClientFactory<TestClient>>();
            var exception = Assert.Throws<InvalidOperationException>(() => factory.CreateClient("Other"));

            Assert.AreEqual(exception.Message, "Unable to find client registration with type 'TestClient' and name 'Other'.");
        }

        [Test]
        public void RethrowsExceptionFromClientCreation()
        {
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddAzureClients(builder => builder.AddTestClient("throw"));
            ServiceProvider provider = serviceCollection.BuildServiceProvider();
            IAzureClientFactory<TestClient> factory = provider.GetService<IAzureClientFactory<TestClient>>();

            var exception = Assert.Throws<ArgumentException>(() => factory.CreateClient("Default"));
            var otherException = Assert.Throws<ArgumentException>(() => factory.CreateClient("Default"));

            Assert.AreSame(otherException, exception);
            Assert.AreEqual(exception.Message, "Throwing");
        }

        [Test]
        public void CanSetGlobalOptions()
        {
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddAzureClients(builder => {
                builder.AddTestClient("TestClient1");
                builder.AddTestClientWithCredentials(new Uri("http://localhost"));
                builder.ConfigureDefaults(options => options.Diagnostics.ApplicationId = "GlobalAppId");
            });
            ServiceProvider provider = serviceCollection.BuildServiceProvider();

            TestClient testClient = provider.GetService<IAzureClientFactory<TestClient>>().CreateClient("Default");
            TestClientWithCredentials testClientWithCredentials = provider.GetService<IAzureClientFactory<TestClientWithCredentials>>().CreateClient("Default");

            Assert.AreEqual("GlobalAppId", testClient.Options.Diagnostics.ApplicationId);
            Assert.AreEqual("GlobalAppId", testClientWithCredentials.Options.Diagnostics.ApplicationId);
        }

        [Test]
        public void CanSetGlobalOptionsUsingConfiguration()
        {
            var configuration = GetConfiguration(new KeyValuePair<string, string>("Diagnostics:ApplicationId", "GlobalAppId"));

            var serviceCollection = new ServiceCollection();
            serviceCollection.AddAzureClients(builder => {
                builder.AddTestClient("TestClient1");
                builder.AddTestClientWithCredentials(new Uri("http://localhost"));
                builder.ConfigureDefaults(configuration);
            });
            ServiceProvider provider = serviceCollection.BuildServiceProvider();

            TestClient testClient = provider.GetService<IAzureClientFactory<TestClient>>().CreateClient("Default");
            TestClientWithCredentials testClientWithCredentials = provider.GetService<IAzureClientFactory<TestClientWithCredentials>>().CreateClient("Default");

            Assert.AreEqual("GlobalAppId", testClient.Options.Diagnostics.ApplicationId);
            Assert.AreEqual("GlobalAppId", testClientWithCredentials.Options.Diagnostics.ApplicationId);
        }

        [Test]
        public void ResolvesDefaultClientByDefault()
        {
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddAzureClients(builder => builder.AddTestClient("Connection string"));
            ServiceProvider provider = serviceCollection.BuildServiceProvider();
            var client = provider.GetService<TestClient>();

            Assert.AreEqual("Connection string", client.ConnectionString);
        }

        [Test]
        public void UsesProvidedCredentialIfOverGlobal()
        {
            var serviceCollection = new ServiceCollection();
            var defaultAzureCredential = new ManagedIdentityCredential();
            serviceCollection.AddAzureClients(builder => builder.AddTestClientWithCredentials(new Uri("http://localhost")).WithCredential(defaultAzureCredential));

            ServiceProvider provider = serviceCollection.BuildServiceProvider();
            TestClientWithCredentials client = provider.GetService<TestClientWithCredentials>();

            Assert.AreSame(defaultAzureCredential, client.Credential);
        }

        [Test]
        public void UsesGlobalCredential()
        {
            var serviceCollection = new ServiceCollection();
            var defaultAzureCredential = new ManagedIdentityCredential();
            serviceCollection.AddAzureClients(builder => {
                builder.AddTestClientWithCredentials(new Uri("http://localhost"));
                builder.UseCredential(defaultAzureCredential);
            });

            ServiceProvider provider = serviceCollection.BuildServiceProvider();
            TestClientWithCredentials client = provider.GetService<TestClientWithCredentials>();

            Assert.AreSame(defaultAzureCredential, client.Credential);
        }

        [Test]
        public void UsesCredentialFromGlobalConfiguration()
        {
            var configuration = GetConfiguration(new KeyValuePair<string, string>("clientId", "ConfigurationClientId"),
                new KeyValuePair<string, string>("clientSecret", "ConfigurationClientSecret"),
                new KeyValuePair<string, string>("tenantId", "ConfigurationTenantId"));

            var serviceCollection = new ServiceCollection();
            serviceCollection.AddAzureClients(builder => {
                builder.AddTestClientWithCredentials(new Uri("http://localhost"));
                builder.ConfigureDefaults(configuration);
            });

            ServiceProvider provider = serviceCollection.BuildServiceProvider();
            TestClientWithCredentials client = provider.GetService<TestClientWithCredentials>();

            Assert.IsInstanceOf<ClientSecretCredential>(client.Credential);
            var clientSecretCredential = (ClientSecretCredential)client.Credential;

            Assert.AreEqual("ConfigurationClientId", clientSecretCredential.ClientId);
            Assert.AreEqual("ConfigurationClientSecret", clientSecretCredential.ClientSecret);
            Assert.AreEqual("ConfigurationTenantId", clientSecretCredential.TenantId);
        }

        [Test]
        public void UsesCredentialFromConfiguration()
        {
            var configuration = GetConfiguration(
                new KeyValuePair<string, string>("uri", "http://localhost/"),
                new KeyValuePair<string, string>("clientId", "ConfigurationClientId"),
                new KeyValuePair<string, string>("clientSecret", "ConfigurationClientSecret"),
                new KeyValuePair<string, string>("tenantId", "ConfigurationTenantId"));

            var serviceCollection = new ServiceCollection();
            serviceCollection.AddAzureClients(builder => builder
                .AddTestClientWithCredentials(configuration));

            ServiceProvider provider = serviceCollection.BuildServiceProvider();
            TestClientWithCredentials client = provider.GetService<TestClientWithCredentials>();

            Assert.IsInstanceOf<ClientSecretCredential>(client.Credential);
            var clientSecretCredential = (ClientSecretCredential)client.Credential;

            Assert.AreEqual("http://localhost/", client.Uri.ToString());
            Assert.AreEqual("ConfigurationClientId", clientSecretCredential.ClientId);
            Assert.AreEqual("ConfigurationClientSecret", clientSecretCredential.ClientSecret);
            Assert.AreEqual("ConfigurationTenantId", clientSecretCredential.TenantId);
        }

        [Test]
        public void SupportsSettingVersion()
        {
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddAzureClients(builder => builder.AddTestClient(new Uri("http://localhost/")).WithVersion(TestClientOptions.ServiceVersion.B));

            ServiceProvider provider = serviceCollection.BuildServiceProvider();
            TestClient client = provider.GetService<TestClient>();
            Assert.AreEqual(TestClientOptions.ServiceVersion.B, client.Options.Version);
        }

        [Test]
        public void ThrowsIfCredentialIsNullButIsRequired()
        {
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddAzureClients(builder => builder.AddTestClient(new Uri("http://localhost/")).WithCredential((TokenCredential)null));

            ServiceProvider provider = serviceCollection.BuildServiceProvider();
            InvalidOperationException exception = Assert.Throws<InvalidOperationException>(() => provider.GetService<TestClient>());
            Assert.AreEqual("Client registration requires a TokenCredential. Configure it using UseCredential method.", exception.Message);
        }

        [Test]
        public void CanCreateClientOptionsWithMultipleParameters()
        {
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddAzureClients(builder => builder.AddTestClientOptionsMultipleParameters("http://localhost/"));
            ServiceProvider provider = serviceCollection.BuildServiceProvider();
            TestClientMultipleOptionsParameters client = provider.GetService<TestClientMultipleOptionsParameters>();

            Assert.NotNull(client.Options);
            Assert.AreEqual(TestClientOptionsMultipleParameters.ServiceVersion.D, client.Options.Version);
            Assert.AreEqual("some default value", client.Options.OtherParameter);
        }

        [Test]
        public void CanCreateClientOptionsWithMultipleParametersAndSetVersion()
        {
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddAzureClients(builder => builder.AddTestClientOptionsMultipleParameters("http://localhost/").WithVersion(TestClientOptionsMultipleParameters.ServiceVersion.B));
            ServiceProvider provider = serviceCollection.BuildServiceProvider();
            TestClientMultipleOptionsParameters client = provider.GetService<TestClientMultipleOptionsParameters>();

            Assert.NotNull(client.Options);
            Assert.AreEqual(TestClientOptionsMultipleParameters.ServiceVersion.B, client.Options.Version);
            Assert.AreEqual("some default value", client.Options.OtherParameter);
        }

        private IConfiguration GetConfiguration(params KeyValuePair<string, string>[] items)
        {
            return new ConfigurationBuilder().AddInMemoryCollection(items).Build();
        }
    }
}
