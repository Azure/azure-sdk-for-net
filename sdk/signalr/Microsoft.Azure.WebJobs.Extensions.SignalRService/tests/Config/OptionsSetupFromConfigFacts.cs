// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Linq;
using Microsoft.Azure.SignalR.Management;
using Microsoft.Azure.SignalR.Tests.Common;
using Microsoft.Azure.WebJobs.Extensions.SignalRService;
using Microsoft.Extensions.Configuration;
using Xunit;

namespace SignalRServiceExtension.Tests.Config
{
    public class OptionsSetupFromConfigFacts
    {
        [Fact]
        public void TestIdentityBasedSingleEndpointConfiguration()
        {
            var configuration = new ConfigurationBuilder().AddInMemoryCollection().Build();
            var sectionKey = "connection";
            var serviceUri = "http://localhost.signalr.com";
            configuration[$"{sectionKey}:serviceUri"] = serviceUri;
            var optionsSetup = new OptionsSetupFromConfig(configuration, SingletonAzureComponentFactory.Instance, sectionKey);
            var options = new ServiceManagerOptions();
            optionsSetup.Configure(options);

            var endpoint = Assert.Single(options.ServiceEndpoints);
            Assert.Equal(serviceUri, endpoint.Endpoint);
            Assert.Equal(string.Empty, endpoint.Name);
        }

        [Fact]
        public void TestIdentityBasedMultiEndpointConfiguration()
        {
            var serviceUris = new string[] { "http://localhost.signalr.com", "http://localhost2.signalr.com" };
            var endpointNames = new string[] { "eastus", "westus" };
            var configuration = new ConfigurationBuilder().AddInMemoryCollection().Build();
            configuration[$"Azure:SignalR:Endpoints:{endpointNames[0]}:serviceUri"] = serviceUris[0];
            configuration[$"Azure:SignalR:Endpoints:{endpointNames[1]}:serviceUri"] = serviceUris[1];
            var optionsSetup = new OptionsSetupFromConfig(configuration, SingletonAzureComponentFactory.Instance, "does_not_matter");
            var options = new ServiceManagerOptions();
            optionsSetup.Configure(options);

            Assert.Equal(2, options.ServiceEndpoints.Length);
            Assert.Contains(options.ServiceEndpoints, e => endpointNames[0] == e.Name && serviceUris[0] == e.Endpoint);
            Assert.Contains(options.ServiceEndpoints, e => endpointNames[1] == e.Name && serviceUris[1] == e.Endpoint);
        }

        /// <summary>
        /// Test when named endpoints and nameless endpoint are configured, both should be included.
        /// </summary>
        [Fact]
        public void TestIdentityBasedMixedEndpointConfiguration()
        {
            var serviceUris = new string[] { "http://localhost.signalr.com", "http://localhost2.signalr.com" };
            var endpointName = "eastus";
            var namelessEndpointKey = "AzureSignalRConnection";
            var configuration = new ConfigurationBuilder().AddInMemoryCollection().Build();
            configuration[$"Azure:SignalR:Endpoints:{endpointName}:serviceUri"] = serviceUris[0];
            configuration[$"{namelessEndpointKey}:serviceUri"] = serviceUris[1];

            var optionsSetup = new OptionsSetupFromConfig(configuration, SingletonAzureComponentFactory.Instance, namelessEndpointKey);
            var options = new ServiceManagerOptions();
            optionsSetup.Configure(options);

            Assert.Equal(2, options.ServiceEndpoints.Length);
            Assert.Contains(options.ServiceEndpoints, e => endpointName == e.Name && serviceUris[0] == e.Endpoint);
            Assert.Contains(options.ServiceEndpoints, e => string.Empty == e.Name && serviceUris[1] == e.Endpoint);
        }

        /// <summary>
        /// Make sure don't override the settings from SignalROptions when <see cref="IConfiguration"/> doesn't have corresponding items.
        /// </summary>
        [Fact]
        public void TestConfigItemNotExist()
        {
            var configuration = new ConfigurationBuilder().AddInMemoryCollection().Build();
            var optionsSetup = new OptionsSetupFromConfig(configuration, SingletonAzureComponentFactory.Instance, "_");
            var options = new ServiceManagerOptions()
            {
                ServiceEndpoints = FakeEndpointUtils.GetFakeEndpoint(1).ToArray(),
                ServiceTransportType = ServiceTransportType.Persistent
            };
            optionsSetup.Configure(options);
            Assert.NotNull(options.ServiceEndpoints);
            Assert.Single(options.ServiceEndpoints);
            Assert.Equal(ServiceTransportType.Persistent, options.ServiceTransportType);
        }

        /// <summary>
        /// Make sure override the settings from SignalROptions when <see cref="IConfiguration"/> has specific items.
        /// </summary>
        [Fact]
        public void TestConfigItemExist()
        {
            var configuration = new ConfigurationBuilder().AddInMemoryCollection().Build();
            configuration["SignalRConnection:serviceUri"] = "https://signalr.com";
            configuration["AzureSignalRServiceTransportType"] = "Transient";
            var optionsSetup = new OptionsSetupFromConfig(configuration, SingletonAzureComponentFactory.Instance, "SignalRConnection");
            var options = new ServiceManagerOptions()
            {
                ServiceEndpoints = FakeEndpointUtils.GetFakeEndpoint(2).ToArray(),
                ServiceTransportType = ServiceTransportType.Persistent
            };
            optionsSetup.Configure(options);
            Assert.NotNull(options.ServiceEndpoints);
            Assert.Single(options.ServiceEndpoints);
            Assert.Equal(ServiceTransportType.Transient, options.ServiceTransportType);
        }
    }
}
