// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Linq;

using Azure.Core.Serialization;
using Azure.Identity;

using Microsoft.Azure.SignalR;
using Microsoft.Azure.SignalR.Tests.Common;
using Microsoft.Azure.WebJobs.Extensions.SignalRService;
using Microsoft.Extensions.Azure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using Xunit;

namespace SignalRServiceExtension.Tests.Config
{
    public class IConfigurationExtensionsFacts
    {
        [Fact]
        public void TestGetNamedEndpointFromIdentityWithNoUri()
        {
            var services = new ServiceCollection();
            services.AddAzureClientsCore();
            var factory = services.BuildServiceProvider().GetRequiredService<AzureComponentFactory>();
            var config = new ConfigurationBuilder().AddInMemoryCollection().Build();
            Assert.False(config.GetSection("eastus").TryGetEndpointFromIdentity(factory, out _));
        }

        [Fact]
        public void TestGetNamedEndpointFromIdentityWithOnlyUri()
        {
            var services = new ServiceCollection();
            services.AddAzureClientsCore();
            var factory = services.BuildServiceProvider().GetRequiredService<AzureComponentFactory>();

            var config = new ConfigurationBuilder().AddInMemoryCollection().Build();
            var uri = "http://signalr.service.uri.com:441";
            config["eastus:serviceUri"] = uri;

            Assert.True(config.GetSection("eastus").TryGetEndpointFromIdentity(factory, out var endpoint));
            Assert.Equal("eastus", endpoint.Name);
            Assert.Equal(uri, endpoint.Endpoint);
            Assert.IsType<DefaultAzureCredential>((endpoint.AccessKey as MicrosoftEntraAccessKey).TokenCredential);
            Assert.Equal(EndpointType.Primary, endpoint.EndpointType);
        }

        [Fact]
        public void TestGetNamedEndpointFromIdentityWithAllEndpointField()
        {
            var services = new ServiceCollection();
            services.AddAzureClientsCore();
            var factory = services.BuildServiceProvider().GetRequiredService<AzureComponentFactory>();

            var config = new ConfigurationBuilder().AddInMemoryCollection().Build();
            var uri = "http://signalr.service.uri.com:441";
            config["eastus:serviceUri"] = uri;
            config["eastus:credential"] = "managedidentity";
            config["eastus:type"] = "secondary";
            config["eastus:serverEndpoint"] = "https://serverEndpoint.com";
            config["eastus:clientEndpoint"] = "https://clientEndpoint.com";

            Assert.True(config.GetSection("eastus").TryGetEndpointFromIdentity(factory, out var endpoint));
            Assert.Equal("eastus", endpoint.Name);
            Assert.Equal(uri, endpoint.Endpoint);
            Assert.Equal(new Uri("https://serverEndpoint.com"), endpoint.ServerEndpoint);
            Assert.Equal(new Uri("https://clientEndpoint.com"), endpoint.ClientEndpoint);
            Assert.IsType<ManagedIdentityCredential>((endpoint.AccessKey as MicrosoftEntraAccessKey).TokenCredential);
            Assert.Equal(EndpointType.Secondary, endpoint.EndpointType);
        }

        [Fact]
        public void TestGetNamedEndpointsFromConnectionString()
        {
            var connectionString = FakeEndpointUtils.GetFakeConnectionString(1).Single();
            var config = new ConfigurationBuilder().AddInMemoryCollection().Build();
            config["eastus"] = connectionString;
            config["eastus:primary"] = connectionString;
            config["eastus:secondary"] = connectionString;
            var endpoints = config.GetSection("eastus").GetNamedEndpointsFromConnectionString().ToArray();
            Assert.Equal(3, endpoints.Length);
            Assert.All(endpoints, e => Assert.Equal("eastus", e.Name));
            Assert.Equal(EndpointType.Primary, endpoints[0].EndpointType);
            Assert.Equal(EndpointType.Primary, endpoints[1].EndpointType);
            Assert.Equal(EndpointType.Secondary, endpoints[2].EndpointType);
        }

        [Fact]
        public void TestGetEndpointsFromIdentityAndConnectionString()
        {
            var services = new ServiceCollection();
            services.AddAzureClientsCore();
            var factory = services.BuildServiceProvider().GetRequiredService<AzureComponentFactory>();
            var config = new ConfigurationBuilder().AddInMemoryCollection().Build();

            var serviceUri = "http://signalr.service.uri.com:441";
            config["endpoints:eastus:serviceUri"] = serviceUri;
            config["endpoints:westus:secondary"] = FakeEndpointUtils.GetFakeConnectionString(1).Single();

            var endpoints = config.GetSection("endpoints").GetEndpoints(factory).ToArray();
            Assert.Collection(endpoints, e =>
            {
                Assert.Equal("eastus", e.Name);
                Assert.Equal(serviceUri, e.Endpoint);
            }, e =>
            {
                Assert.Equal("westus", e.Name);
                Assert.Equal(EndpointType.Secondary, e.EndpointType);
            });
        }

        [Theory]
        [InlineData(null)]
        [InlineData("dotnet")]
        public void NullHubProtocolSetting_DoNothing(string workerRuntime)
        {
            var configuration = new ConfigurationBuilder().AddInMemoryCollection().Build();
            configuration["FUNCTIONS_WORKER_RUNTIME"] = workerRuntime;
            Assert.False(configuration.TryGetJsonObjectSerializer(out var serializer));
        }

        [Theory]
        [InlineData("dotnet-isolated")]
        [InlineData("node")]
        public void NullHubProtocolWithIsolatedWorker(string workerRuntime)
        {
            var configuration = new ConfigurationBuilder().AddInMemoryCollection().Build();
            configuration["FUNCTIONS_WORKER_RUNTIME"] = workerRuntime;
            Assert.True(configuration.TryGetJsonObjectSerializer(out var serializer));
            Assert.IsType<NewtonsoftJsonObjectSerializer>(serializer); ;
        }

        [Fact]
        public void SetSystemTextJson()
        {
            var configuration = new ConfigurationBuilder().AddInMemoryCollection().Build();
            configuration["Azure:SignalR:HubProtocol"] = HubProtocol.SystemTextJson.ToString();
            Assert.True(configuration.TryGetJsonObjectSerializer(out var serializer));
            Assert.IsType<JsonObjectSerializer>(serializer);
        }

        [Fact]
        public void SetNewtonsoft()
        {
            var configuration = new ConfigurationBuilder().AddInMemoryCollection().Build();
            configuration["Azure:SignalR:HubProtocol"] = HubProtocol.NewtonsoftJson.ToString();
            Assert.True(configuration.TryGetJsonObjectSerializer(out var serializer));
            Assert.IsType<NewtonsoftJsonObjectSerializer>(serializer);
        }

        [Fact]
        public void SetNewtonsoftCamelCase()
        {
            var configuration = new ConfigurationBuilder().AddInMemoryCollection().Build();
            configuration["Azure:SignalR:HubProtocol:NewtonsoftJson:CamelCase"] = "true";
            configuration["Azure:SignalR:HubProtocol"] = HubProtocol.NewtonsoftJson.ToString();
            Assert.True(configuration.TryGetJsonObjectSerializer(out var serializer));
            Assert.IsType<NewtonsoftJsonObjectSerializer>(serializer);
            var obj = new
            {
                Key = "value"
            };
            Assert.Equal("{\"key\":\"value\"}", serializer.Serialize(obj).ToString());
        }
    }
}
