// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.Serialization;
using Microsoft.AspNetCore.SignalR;
using Microsoft.AspNetCore.SignalR.Protocol;
using Microsoft.Azure.SignalR;
using Microsoft.Azure.SignalR.Common;
using Microsoft.Azure.SignalR.Management;
using Microsoft.Azure.SignalR.Tests.Common;
using Microsoft.Azure.WebJobs.Extensions.SignalRService;
using Microsoft.Extensions.Azure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Memory;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging.Abstractions;
using Microsoft.Extensions.Options;
using Moq;
using Xunit;
using Constants = Microsoft.Azure.WebJobs.Extensions.SignalRService.Constants;

namespace SignalRServiceExtension.Tests
{
    public class ServiceManagerStoreTests
    {
        [Fact]
        public void GetServiceManager_WithSingleEndpoint()
        {
            var connectionString = FakeEndpointUtils.GetFakeConnectionString(1).Single();
            var configuration = new ConfigurationBuilder().AddInMemoryCollection().Build();
            var connectionStringKey = "key";
            configuration[connectionStringKey] = connectionString;

            var managerStore = new ServiceManagerStore(configuration, NullLoggerFactory.Instance, null, Options.Create(new SignalROptions()));
            var hubContextStore = managerStore.GetOrAddByConnectionStringKey(connectionStringKey);
            var manager = hubContextStore.ServiceManager;
        }

        [Fact]
        public void ProductInfoValid()
        {
            var connectionString = FakeEndpointUtils.GetFakeConnectionString(1).Single();
            var configuration = new ConfigurationBuilder().AddInMemoryCollection().Build();
            var connectionStringKey = "key";
            configuration[connectionStringKey] = connectionString;
            configuration[Constants.FunctionsWorkerRuntime] = Constants.DotnetWorker;

            var serviceManagerStore = new ServiceManagerStore(configuration, NullLoggerFactory.Instance, SingletonAzureComponentFactory.Instance, Options.Create(new SignalROptions()));
            var productInfo = (serviceManagerStore.GetOrAddByConnectionStringKey(connectionStringKey).GetAsync("hub").Result as ServiceHubContextImpl).ServiceProvider.GetRequiredService<IOptions<ServiceManagerOptions>>().Value.ProductInfo;
            Assert.NotNull(productInfo);
            Assert.StartsWith("Microsoft.Azure.WebJobs.Extensions.SignalRService", productInfo);
            Assert.EndsWith(" [func=dotnet]", productInfo);
        }

        [Fact]
        public async Task DefaultRouterExists()
        {
            var builder = new HostBuilder();
            var host = builder
                .ConfigureAppConfiguration(b => b.AddInMemoryCollection(
                    new Dictionary<string, string> {
                                { "Azure:SignalR:Endpoints:A", FakeEndpointUtils.GetFakeConnectionString(1).Single() },
                                { "Azure:SignalR:Endpoints:B", FakeEndpointUtils.GetFakeConnectionString(1).Single() },
                                { Constants.ServiceTransportTypeName, ServiceTransportType.Persistent.ToString() }
                            }))
                .ConfigureWebJobs(b => b.AddSignalR().Services.AddAzureClientsCore()).Build();
            var hubContext = await host.Services.GetRequiredService<IServiceManagerStore>().GetOrAddByConnectionStringKey("key").GetAsync("hubName") as ServiceHubContext;
            await Assert.ThrowsAsync<AzureSignalRNotConnectedException>(() => hubContext.NegotiateAsync().AsTask());
        }

        [Fact]
        public async Task TestConfigureSignalROptions()
        {
            var builder = new HostBuilder();
            var host = builder
                .ConfigureWebJobs(b => b.AddSignalR())
                .ConfigureServices(services => services.Configure<SignalROptions>(o =>
                {
                    foreach (var endpoint in FakeEndpointUtils.GetFakeEndpoint(3))
                    {
                        o.ServiceEndpoints.Add(endpoint);
                    }
                    o.ServiceTransportType = ServiceTransportType.Persistent;
                    o.JsonObjectSerializer = new NewtonsoftJsonObjectSerializer();
                })).Build();
            var hubContext = await host.Services.GetRequiredService<IServiceManagerStore>().GetOrAddByConnectionStringKey("key").GetAsync("hubName") as ServiceHubContext;
            var resultOptions = (hubContext as ServiceHubContextImpl).ServiceProvider.GetRequiredService<IOptions<ServiceManagerOptions>>().Value;
            Assert.Equal(3, resultOptions.ServiceEndpoints.Length);
            Assert.Equal(ServiceTransportType.Persistent, resultOptions.ServiceTransportType);
            Assert.IsType<NewtonsoftJsonObjectSerializer>(resultOptions.ObjectSerializer);
        }

        [Fact]
        public async Task TestConfigurationHotReload()
        {
            var mock = new Mock<IEndpointRouter>();
            var connectionStrings = FakeEndpointUtils.GetFakeConnectionString(2).ToArray();
            var initialEndpoint = new ServiceEndpoint(connectionStrings[0]);
            var updatedEndpoint = new ServiceEndpoint(connectionStrings[1]);
            var initialEndpointObserved = new TaskCompletionSource<ServiceEndpoint[]>(TaskCreationOptions.RunContinuationsAsynchronously);
            var endpointsTransitionObserved = new TaskCompletionSource<ServiceEndpoint[]>(TaskCreationOptions.RunContinuationsAsynchronously);
            var observedEndpointSets = new ConcurrentDictionary<string, byte>();
            mock.Setup(router => router.GetEndpointsForUser(It.IsAny<string>(), It.IsAny<IEnumerable<ServiceEndpoint>>()))
                .Callback<string, IEnumerable<ServiceEndpoint>>((_, endpoints) =>
                {
                    var currentEndpoints = endpoints.ToArray();
                    observedEndpointSets.TryAdd(string.Join(", ", currentEndpoints.Select(endpoint => endpoint.Endpoint)), 0);
                    if (currentEndpoints.Length == 1 && currentEndpoints[0].Endpoint == initialEndpoint.Endpoint)
                    {
                        initialEndpointObserved.TrySetResult(currentEndpoints);
                        return;
                    }

                    if (currentEndpoints.Length == 2
                        && currentEndpoints.Any(endpoint => endpoint.Endpoint == initialEndpoint.Endpoint)
                        && currentEndpoints.Any(endpoint => endpoint.Endpoint == updatedEndpoint.Endpoint))
                    {
                        endpointsTransitionObserved.TrySetResult(currentEndpoints);
                    }
                });
            var configuration = new ConfigurationRoot(new List<IConfigurationProvider>() { new MemoryConfigurationProvider(new()) });
            configuration[Constants.AzureSignalRConnectionStringName] = connectionStrings[0];
            // Only persistent mode supports hot reload.
            configuration[Constants.ServiceTransportTypeName] = "Persistent";
            var managerStore = new ServiceManagerStore(configuration, NullLoggerFactory.Instance, SingletonAzureComponentFactory.Instance, Options.Create(new SignalROptions()), mock.Object);
            var hubContextStore = managerStore.GetOrAddByConnectionStringKey(Constants.AzureSignalRConnectionStringName);
            var hubContext = await hubContextStore.GetAsync("hub") as ServiceHubContext;

            using var timeout = new CancellationTokenSource(TimeSpan.FromSeconds(30));
            await hubContext.ClientManager.UserExistsAsync("a");
            var initialEndpoints = await initialEndpointObserved.Task.WaitAsync(timeout.Token);
            Assert.Single(initialEndpoints);
            Assert.Equal(initialEndpoint.Endpoint, initialEndpoints[0].Endpoint);

            configuration[Constants.AzureSignalRConnectionStringName] = connectionStrings[1];
            configuration.Reload();

            while (!endpointsTransitionObserved.Task.IsCompleted && !timeout.IsCancellationRequested)
            {
                await hubContext.ClientManager.UserExistsAsync("a").WaitAsync(timeout.Token);
                await Task.WhenAny(endpointsTransitionObserved.Task, Task.Delay(TimeSpan.FromMilliseconds(50), timeout.Token));
            }

            Assert.True(endpointsTransitionObserved.Task.IsCompleted, $"Observed endpoint sets: {string.Join(" | ", observedEndpointSets.Keys)}");
            var updatedEndpoints = await endpointsTransitionObserved.Task.WaitAsync(timeout.Token);
            Assert.Equal(2, updatedEndpoints.Length);
            Assert.Contains(updatedEndpoints, endpoint => endpoint.Endpoint == initialEndpoint.Endpoint);
            Assert.Contains(updatedEndpoints, endpoint => endpoint.Endpoint == updatedEndpoint.Endpoint);
        }

        [Theory]
        [InlineData(ServiceTransportType.Transient)]
        [InlineData(ServiceTransportType.Persistent)]
        public async void TestAddMessagePackHubProtocolViaSignalROptions(ServiceTransportType serviceTransportType)
        {
            var emptyConfiguration = new ConfigurationBuilder().AddInMemoryCollection().Build();
            var signalROptions = new SignalROptions
            {
                ServiceTransportType = serviceTransportType,
                MessagePackHubProtocol = new MessagePackHubProtocol()
            };
            signalROptions.ServiceEndpoints.Add(FakeEndpointUtils.GetFakeEndpoint(1).Single());
            var managerStore = new ServiceManagerStore(emptyConfiguration, NullLoggerFactory.Instance, SingletonAzureComponentFactory.Instance, Options.Create(signalROptions));
            var hubContextStore = managerStore.GetOrAddByConnectionStringKey("doesn't matter");
            var hubContext = await hubContextStore.GetAsync("hub") as ServiceHubContextImpl;
            var serviceProvider = hubContext.ServiceProvider;
            var hubProtocolResolver = serviceProvider.GetRequiredService<IHubProtocolResolver>();
            Assert.Equal(2, hubProtocolResolver.AllProtocols.Count);
            Assert.Contains(hubProtocolResolver.AllProtocols, h => h.Name.Equals("messagepack", System.StringComparison.OrdinalIgnoreCase));
            Assert.Contains(hubProtocolResolver.AllProtocols, h => h.Name.Equals("json", System.StringComparison.OrdinalIgnoreCase));
        }

        [Theory]
        [InlineData(ServiceTransportType.Transient)]
        [InlineData(ServiceTransportType.Persistent)]
        public async void TestAddMessagePackHubProtocolViaConfiguration(ServiceTransportType serviceTransportType)
        {
            var configuration = new ConfigurationBuilder().AddInMemoryCollection().Build();
            configuration["Azure:SignalR:HubProtocol:MessagePack:Enabled"] = "true";
            configuration["AzureSignalRConnectionString"] = FakeEndpointUtils.GetFakeConnectionString();
            configuration["AzureSignalRServiceTransportType"] = serviceTransportType.ToString();
            var managerStore = new ServiceManagerStore(configuration, NullLoggerFactory.Instance, SingletonAzureComponentFactory.Instance, Options.Create(new SignalROptions()));
            var hubContextStore = managerStore.GetOrAddByConnectionStringKey("AzureSignalRConnectionString");
            var hubContext = await hubContextStore.GetAsync("hub") as ServiceHubContextImpl;
            var serviceProvider = hubContext.ServiceProvider;
            var hubProtocolResolver = serviceProvider.GetRequiredService<IHubProtocolResolver>();
            Assert.Equal(2, hubProtocolResolver.AllProtocols.Count);
            Assert.Contains(hubProtocolResolver.AllProtocols, h => h.Name.Equals("messagepack", System.StringComparison.OrdinalIgnoreCase));
            Assert.Contains(hubProtocolResolver.AllProtocols, h => h.Name.Equals("json", System.StringComparison.OrdinalIgnoreCase));
        }

        [Fact]
        public async void TestTransientModeDefaultHubProtocl()
        {
            var emptyConfiguration = new ConfigurationBuilder().AddInMemoryCollection().Build();
            var signalROptions = new SignalROptions
            {
                ServiceTransportType = ServiceTransportType.Transient,
            };
            signalROptions.ServiceEndpoints.Add(FakeEndpointUtils.GetFakeEndpoint(1).Single());
            var managerStore = new ServiceManagerStore(emptyConfiguration, NullLoggerFactory.Instance, SingletonAzureComponentFactory.Instance, Options.Create(signalROptions));
            var hubContextStore = managerStore.GetOrAddByConnectionStringKey("doesn't matter");
            var hubContext = await hubContextStore.GetAsync("hub") as ServiceHubContextImpl;
            var serviceProvider = hubContext.ServiceProvider;
            var hubProtocolResolver = serviceProvider.GetRequiredService<IHubProtocolResolver>();
            Assert.IsType<JsonObjectSerializerHubProtocol>(hubProtocolResolver.AllProtocols.Single());
        }

        [Fact]
        public async void TestHubProtocolDefaultSettings()
        {
            var emptyConfiguration = new ConfigurationBuilder().AddInMemoryCollection().Build();
            var signalROptions = new SignalROptions
            {
                ServiceTransportType = ServiceTransportType.Persistent,
            };
            signalROptions.ServiceEndpoints.Add(FakeEndpointUtils.GetFakeEndpoint(1).Single());
            var managerStore = new ServiceManagerStore(emptyConfiguration, NullLoggerFactory.Instance, SingletonAzureComponentFactory.Instance, Options.Create(signalROptions));
            var hubContextStore = managerStore.GetOrAddByConnectionStringKey("doesn't matter");
            var hubContext = await hubContextStore.GetAsync("hub") as ServiceHubContextImpl;
            var serviceProvider = hubContext.ServiceProvider;
            var hubProtocolResolver = serviceProvider.GetRequiredService<IHubProtocolResolver>();
            Assert.IsType<JsonHubProtocol>(hubProtocolResolver.AllProtocols.Single());
        }
    }
}