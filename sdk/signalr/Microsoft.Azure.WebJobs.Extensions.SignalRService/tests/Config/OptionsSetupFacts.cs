// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Reflection;

using Azure.Core.Serialization;

using Microsoft.Azure.SignalR.Management;
using Microsoft.Azure.WebJobs.Extensions.SignalRService;
using Microsoft.Extensions.Configuration;

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
            var optionsSetup = new OptionsSetup(configuration, SingletonAzureComponentFactory.Instance, sectionKey, new());
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
            var optionsSetup = new OptionsSetup(configuration, SingletonAzureComponentFactory.Instance, "does_not_matter", new());
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

            var optionsSetup = new OptionsSetup(configuration, SingletonAzureComponentFactory.Instance, namelessEndpointKey, new());
            var options = new ServiceManagerOptions();
            optionsSetup.Configure(options);

            Assert.Equal(2, options.ServiceEndpoints.Length);
            Assert.Contains(options.ServiceEndpoints, e => endpointName == e.Name && serviceUris[0] == e.Endpoint);
            Assert.Contains(options.ServiceEndpoints, e => string.Empty == e.Name && serviceUris[1] == e.Endpoint);
        }

        [Theory]
        [InlineData("Azure:SignalR:HubProtocol:NewtonsoftJson:CamelCase", "true", typeof(NewtonsoftJsonObjectSerializer))]
        [InlineData("Azure:SignalR:HubProtocol", "NewtonsoftJson", typeof(NewtonsoftJsonObjectSerializer))]
        [InlineData("Azure:SignalR:HubProtocol", "newtonsoftjson", typeof(NewtonsoftJsonObjectSerializer))]
        [InlineData("Azure:SignalR:HubProtocol", "SystemTextJson", typeof(JsonObjectSerializer))]
        [InlineData("Azure:SignalR:HubProtocol", "systemtextjson", typeof(JsonObjectSerializer))]
        [InlineData("Otherkey", "OtherValue", null)]
        public void TestHubProtocolConfiguration(string configKey, string configValue, Type objectSerializerType)
        {
            var configuration = new ConfigurationBuilder().AddInMemoryCollection().Build();
            configuration[configKey] = configValue;
            var options = new ServiceManagerOptions();
            var setup = new OptionsSetup(configuration, SingletonAzureComponentFactory.Instance, "key", new());
            setup.Configure(options);
            // hack to access internal member
            var serializer = typeof(ServiceManagerOptions).GetProperty("ObjectSerializer", BindingFlags.NonPublic | BindingFlags.Instance).GetValue(options);
            Assert.Equal(objectSerializerType, serializer?.GetType());
        }

        [Fact]
        public void TestDefaultRetryOptions()
        {
            var configuration = new ConfigurationBuilder().AddInMemoryCollection().Build();
            var options = new ServiceManagerOptions();
            var setup = new OptionsSetup(configuration, SingletonAzureComponentFactory.Instance, "key", new());
            setup.Configure(options);
            Assert.NotNull(options.RetryOptions);
        }

        // We didn't enable retry by default previously, so we utilize a "Default" name for users to set a retry policy with default settings.
        [Fact]
        public void TestRetryOptionsWithDefaultName()
        {
            var configuration = new ConfigurationBuilder().AddInMemoryCollection().Build();
            configuration[Constants.AzureSignalRRetry + ":Default"] = "";
            var options = new ServiceManagerOptions();
            var setup = new OptionsSetup(configuration, SingletonAzureComponentFactory.Instance, "key", new());
            setup.Configure(options);
            Assert.Equal(3, options.RetryOptions.MaxRetries);
            Assert.Equal(TimeSpan.FromSeconds(0.8), options.RetryOptions.Delay);
            Assert.Equal(TimeSpan.FromMinutes(1), options.RetryOptions.MaxDelay);
            Assert.Equal(ServiceManagerRetryMode.Fixed, options.RetryOptions.Mode);
        }

        [Fact]
        public void TestCustomizedRetryOptions()
        {
            var configuration = new ConfigurationBuilder().AddInMemoryCollection().Build();
            configuration[Constants.AzureSignalRRetry + ":MaxRetries"] = "4";
            configuration[Constants.AzureSignalRRetry + ":Delay"] = "00:00:1";
            configuration[Constants.AzureSignalRRetry + ":MaxDelay"] = "00:02:00";
            configuration[Constants.AzureSignalRRetry + ":Mode"] = "Exponential";
            var options = new ServiceManagerOptions();
            var setup = new OptionsSetup(configuration, SingletonAzureComponentFactory.Instance, "key", new());
            setup.Configure(options);
            Assert.Equal(4, options.RetryOptions.MaxRetries);
            Assert.Equal(TimeSpan.FromSeconds(1), options.RetryOptions.Delay);
            Assert.Equal(TimeSpan.FromMinutes(2), options.RetryOptions.MaxDelay);
            Assert.Equal(ServiceManagerRetryMode.Exponential, options.RetryOptions.Mode);
        }

        [Fact]
        public void TestConfigreHttpClientTimeoutViaCode()
        {
            var configuration = new ConfigurationBuilder().AddInMemoryCollection().Build();
            var options = new ServiceManagerOptions();
            var setup = new OptionsSetup(configuration, SingletonAzureComponentFactory.Instance, "key", new() { HttpClientTimeout = TimeSpan.FromSeconds(10) });
            setup.Configure(options);
            Assert.Equal(TimeSpan.FromSeconds(10), options.HttpClientTimeout);
        }

        [Fact]
        public void TestConfigureHttpClientTimeoutViaConfiguration()
        {
            var configuration = new ConfigurationBuilder().AddInMemoryCollection().Build();
            configuration[Constants.AzureSignalRHttpClientTimeout] = "00:00:10";
            var options = new ServiceManagerOptions();
            var setup = new OptionsSetup(configuration, SingletonAzureComponentFactory.Instance, "key", new());
            setup.Configure(options);
            Assert.Equal(TimeSpan.FromSeconds(10), options.HttpClientTimeout);
        }
    }
}
