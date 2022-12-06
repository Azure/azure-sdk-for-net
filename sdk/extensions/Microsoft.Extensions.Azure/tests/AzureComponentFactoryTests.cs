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

            Assert.AreEqual("http://localhost/", client.Uri.ToString());
            Assert.IsInstanceOf<EnvironmentCredential>(client.Credential);
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

            Assert.IsInstanceOf<ClientSecretCredential>(credential);
            var clientSecretCredential = (ClientSecretCredential)credential;

            Assert.AreEqual("ConfigurationClientId", clientSecretCredential.ClientId);
            Assert.AreEqual("ConfigurationClientSecret", clientSecretCredential.ClientSecret);
            Assert.AreEqual("ConfigurationTenantId", clientSecretCredential.TenantId);
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

            Assert.IsInstanceOf<EnvironmentCredential>(credential);
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
            Assert.IsInstanceOf<DefaultAzureCredential>(credential);
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

            Assert.AreEqual("http://localhost/", client.ConnectionString);
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

            Assert.AreEqual("client option value", options.Property);
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

            Assert.AreEqual("client option value", options.Property);
            Assert.AreEqual(TestClientOptions.ServiceVersion.B, options.Version);
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

            Assert.AreEqual("AppId", options.Diagnostics.ApplicationId);
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

            Assert.AreEqual("http://localhost/", client.Uri.ToString());
            Assert.IsInstanceOf<EnvironmentCredential>(client.Credential);

            AzureEventSourceLogForwarder forwarder = provider.GetService<AzureEventSourceLogForwarder>();
            var listener = (AzureEventSourceListener) forwarder.GetType().GetField(
                    "_listener",
                    System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance)!
                .GetValue(forwarder);
            Assert.AreEqual(enableLogging, listener != null);
        }

        private IConfiguration GetConfiguration(params KeyValuePair<string, string>[] items)
        {
            return new ConfigurationBuilder().AddInMemoryCollection(items).Build();
        }
    }
}