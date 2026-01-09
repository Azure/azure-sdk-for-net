// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using Azure.Core.Diagnostics;
using Azure.Identity;
using Microsoft.Extensions.Azure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;

namespace Azure.Core.Extensions.Tests
{
    public class AzureComponentFactoryTests
    {
        [Test]
        public void CanCreateClientWithoutRegistration()
        {
            var configuration = GetConfiguration(
                new KeyValuePair<string, string>("TestClient:uri", "http://localhost/"));

            var serviceCollection = new ServiceCollection();
            serviceCollection.AddAzureClientsCore();

            ServiceProvider provider = serviceCollection.BuildServiceProvider();
            AzureComponentFactory factory = provider.GetService<AzureComponentFactory>();
            TestClientWithCredentials client = (TestClientWithCredentials) factory.CreateClient(typeof(TestClientWithCredentials), configuration.GetSection("TestClient"), new EnvironmentCredential(), new TestClientOptions());

            Assert.Multiple(() =>
            {
                Assert.That(client.Uri.ToString(), Is.EqualTo("http://localhost/"));
                Assert.That(client.Credential, Is.InstanceOf<EnvironmentCredential>());
            });
        }

        [Test]
        public void CanCreateCredential()
        {
            var configuration = GetConfiguration(
                new KeyValuePair<string, string>("TestClient:clientId", "ConfigurationClientId"),
                new KeyValuePair<string, string>("TestClient:clientSecret", "ConfigurationClientSecret"),
                new KeyValuePair<string, string>("TestClient:tenantId", "ConfigurationTenantId"));

            var serviceCollection = new ServiceCollection();
            serviceCollection.AddAzureClientsCore();

            ServiceProvider provider = serviceCollection.BuildServiceProvider();
            AzureComponentFactory factory = provider.GetService<AzureComponentFactory>();
            TokenCredential credential = factory.CreateTokenCredential(configuration.GetSection("TestClient"));

            Assert.That(credential, Is.InstanceOf<ClientSecretCredential>());
            var clientSecretCredential = (ClientSecretCredential)credential;

            Assert.Multiple(() =>
            {
                Assert.That(clientSecretCredential.ClientId, Is.EqualTo("ConfigurationClientId"));
                Assert.That(clientSecretCredential.ClientSecret, Is.EqualTo("ConfigurationClientSecret"));
                Assert.That(clientSecretCredential.TenantId, Is.EqualTo("ConfigurationTenantId"));
            });
        }

        [Test]
        public void UsesSpecifiedCredentialFactoryWhenNoConfig()
        {
            var configuration = GetConfiguration();

            var serviceCollection = new ServiceCollection();
            serviceCollection.AddAzureClients(builder => builder.UseCredential(new EnvironmentCredential()));

            ServiceProvider provider = serviceCollection.BuildServiceProvider();
            AzureComponentFactory factory = provider.GetService<AzureComponentFactory>();
            TokenCredential credential = factory.CreateTokenCredential(configuration);

            Assert.That(credential, Is.InstanceOf<EnvironmentCredential>());
        }

        [Test]
        public void UsesDefaultAzureCredentialWithConfig()
        {
            var configuration = GetConfiguration(
                new KeyValuePair<string, string>("TestClient:clientId", "ConfigurationClientId"),
                new KeyValuePair<string, string>("TestClient:tenantId", "ConfigurationTenantId"));

            var serviceCollection = new ServiceCollection();
            serviceCollection.AddAzureClients(builder => builder.UseCredential(new EnvironmentCredential()));

            ServiceProvider provider = serviceCollection.BuildServiceProvider();
            AzureComponentFactory factory = provider.GetService<AzureComponentFactory>();
            TokenCredential credential = factory.CreateTokenCredential(configuration.GetSection("TestClient"));

            // credential factory is not used because there is configuration specified
            Assert.That(credential, Is.InstanceOf<DefaultAzureCredential>());
        }

        [Test]
        public void CanCreateClientWithoutRegistrationUsingConnectionString()
        {
            var configuration = GetConfiguration(
                new KeyValuePair<string, string>("TestClient", "http://localhost/"));

            var serviceCollection = new ServiceCollection();
            serviceCollection.AddAzureClientsCore();

            ServiceProvider provider = serviceCollection.BuildServiceProvider();
            AzureComponentFactory factory = provider.GetService<AzureComponentFactory>();
            TestClient client = (TestClient) factory.CreateClient(typeof(TestClient), configuration.GetSection("TestClient"), null, new TestClientOptions());

            Assert.That(client.ConnectionString, Is.EqualTo("http://localhost/"));
        }

        [Test]
        public void CanReadClientOptionsFromConfiguration()
        {
            var configuration = GetConfiguration(
                new KeyValuePair<string, string>("TestClient:Property", "client option value"));

            var serviceCollection = new ServiceCollection();
            serviceCollection.AddAzureClientsCore();

            ServiceProvider provider = serviceCollection.BuildServiceProvider();
            AzureComponentFactory factory = provider.GetService<AzureComponentFactory>();
            TestClientOptions options = (TestClientOptions)factory.CreateClientOptions(typeof(TestClientOptions), null, configuration.GetSection("TestClient"));

            Assert.That(options.Property, Is.EqualTo("client option value"));
        }

        [Test]
        public void UsesProvidedServiceVersionForOptions()
        {
            var configuration = GetConfiguration(
                new KeyValuePair<string, string>("TestClient:Property", "client option value"));

            var serviceCollection = new ServiceCollection();
            serviceCollection.AddAzureClientsCore();

            ServiceProvider provider = serviceCollection.BuildServiceProvider();
            AzureComponentFactory factory = provider.GetService<AzureComponentFactory>();
            TestClientOptions options = (TestClientOptions)factory.CreateClientOptions(typeof(TestClientOptions), TestClientOptions.ServiceVersion.B, configuration.GetSection("TestClient"));

            Assert.Multiple(() =>
            {
                Assert.That(options.Property, Is.EqualTo("client option value"));
                Assert.That(options.Version, Is.EqualTo(TestClientOptions.ServiceVersion.B));
            });
        }

        [Test]
        public void GlobalOptionsAppliedToAzureComponentFactoryCreateClientOptions()
        {
            var configuration = GetConfiguration();

            var serviceCollection = new ServiceCollection();
            serviceCollection.AddAzureClients(builder => builder.ConfigureDefaults(clientOptions => clientOptions.Diagnostics.ApplicationId = "AppId"));

            ServiceProvider provider = serviceCollection.BuildServiceProvider();
            AzureComponentFactory factory = provider.GetService<AzureComponentFactory>();
            TestClientOptions options = (TestClientOptions)factory.CreateClientOptions(typeof(TestClientOptions), configuration["TestClient"], null);

            Assert.That(options.Diagnostics.ApplicationId, Is.EqualTo("AppId"));
        }

        [Test]
        [TestCase(true)]
        [TestCase(false)]
        public void EnableLoggingRespectedWhenCallingAddAzureClientsCore(bool enableLogging)
        {
            var configuration = GetConfiguration(
                new KeyValuePair<string, string>("TestClient:uri", "http://localhost/"));

            var serviceCollection = new ServiceCollection();
            serviceCollection.AddAzureClientsCore(enableLogging);

            ServiceProvider provider = serviceCollection.BuildServiceProvider();
            AzureComponentFactory factory = provider.GetService<AzureComponentFactory>();
            TestClientWithCredentials client = (TestClientWithCredentials) factory.CreateClient(typeof(TestClientWithCredentials), configuration.GetSection("TestClient"), new EnvironmentCredential(), new TestClientOptions());

            Assert.Multiple(() =>
            {
                Assert.That(client.Uri.ToString(), Is.EqualTo("http://localhost/"));
                Assert.That(client.Credential, Is.InstanceOf<EnvironmentCredential>());
            });

            AzureEventSourceLogForwarder forwarder = provider.GetService<AzureEventSourceLogForwarder>();
            var listener = (AzureEventSourceListener) forwarder.GetType().GetField(
                    "_listener",
                    System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance)!
                .GetValue(forwarder);
            Assert.That(listener != null, Is.EqualTo(enableLogging));
        }

        private IConfiguration GetConfiguration(params KeyValuePair<string, string>[] items)
        {
            return new ConfigurationBuilder().AddInMemoryCollection(items).Build();
        }
    }
}