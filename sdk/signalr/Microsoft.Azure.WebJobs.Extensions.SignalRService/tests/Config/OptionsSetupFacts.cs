// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.Azure.SignalR.Management;
using Microsoft.Azure.WebJobs.Extensions.SignalRService;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging.Abstractions;
using Xunit;

namespace SignalRServiceExtension.Tests.Config
{
    public class OptionsSetupFacts
    {
        [Fact]
        public void TestIdentityBasedSingleEndpointConfiguration()
        {
            var configuration = new ConfigurationBuilder().AddInMemoryCollection().Build();
            var sectionKey = "connection";
            var serviceUri = "http://localhost.signalr.com";
            configuration[$"{sectionKey}:serviceUri"] = serviceUri;
            var optionsSetup = new OptionsSetup(configuration, NullLoggerFactory.Instance, SingletonAzureComponentFactory.Instance, sectionKey);
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
            var optionsSetup = new OptionsSetup(configuration, NullLoggerFactory.Instance, SingletonAzureComponentFactory.Instance, "does_not_matter");
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

            var optionsSetup = new OptionsSetup(configuration, NullLoggerFactory.Instance, SingletonAzureComponentFactory.Instance, namelessEndpointKey);
            var options = new ServiceManagerOptions();
            optionsSetup.Configure(options);

            Assert.Equal(2, options.ServiceEndpoints.Length);
            Assert.Contains(options.ServiceEndpoints, e => endpointName == e.Name && serviceUris[0] == e.Endpoint);
            Assert.Contains(options.ServiceEndpoints, e => string.Empty == e.Name && serviceUris[1] == e.Endpoint);
        }
    }
}
