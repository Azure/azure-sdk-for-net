// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
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
            serviceCollection.AddAzureClients(builder => builder.AddTestClient("Default", new Uri("http://localhost/")));

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
            serviceCollection.AddAzureClients(builder => builder.AddTestClient("Default", new Uri("http://localhost/")));

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
                builder.AddTestClient("Default", new Uri("http://localhost/"), options => options.Property = "Value"));

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
            serviceCollection.AddAzureClients(builder => builder.AddTestClient("Default", new Uri("http://localhost/")));
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
            serviceCollection.AddAzureClients(builder => builder.AddTestClient("Default", new Uri("http://localhost/")));
            serviceCollection.AddAzureClients(builder => builder.AddTestClient("Default", new Uri("http://otherhost/")));

            ServiceProvider provider = serviceCollection.BuildServiceProvider();
            IAzureClientFactory<TestClient> factory = provider.GetService<IAzureClientFactory<TestClient>>();

            TestClient client = factory.CreateClient("Default");

            Assert.AreEqual("http://otherhost/", client.Uri.ToString());
        }

        [Test]
        public void CanRegisterMultipleClients()
        {
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddAzureClients(builder => builder
                .AddTestClient("Default", new Uri("http://localhost/"), options => options.Property = "Value1")
                .AddTestClient("OtherClient", new Uri("http://otherhost/"), options => options.Property = "Value2"));

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
            serviceCollection.AddAzureClients(builder => builder.AddTestClient("Default", configuration));

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
            serviceCollection.AddAzureClients(builder => builder.AddTestClient("Default", configuration));

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
            serviceCollection.AddAzureClients(builder => builder.AddTestClient("Default", new Uri("http://localhost/")));

            ServiceProvider provider = serviceCollection.BuildServiceProvider();
            IAzureClientFactory<TestClient> factory = provider.GetService<IAzureClientFactory<TestClient>>();
            var exception = Assert.Throws<InvalidOperationException>(() => factory.CreateClient("Other"));

            Assert.AreEqual(exception.Message, "Unable to find client registration with type 'TestClient' and name 'Other'.");
        }

        private IConfiguration GetConfiguration(params KeyValuePair<string, string>[] items)
        {
            return new ConfigurationBuilder().AddInMemoryCollection(items).Build();
        }
    }
}
