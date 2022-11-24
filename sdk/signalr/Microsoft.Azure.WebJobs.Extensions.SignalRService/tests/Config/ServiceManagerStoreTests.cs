// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Azure.Core.Serialization;
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
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using Microsoft.Extensions.Options;
using Moq;
using SignalRServiceExtension.Tests.Utils.Loggings;
using Xunit;
using Xunit.Abstractions;
using Constants = Microsoft.Azure.WebJobs.Extensions.SignalRService.Constants;

namespace SignalRServiceExtension.Tests
{
    public class ServiceManagerStoreTests
    {
        private readonly ITestOutputHelper _output;

        public ServiceManagerStoreTests(ITestOutputHelper output)
        {
            _output = output;
        }

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

            var setup = new OptionsSetup(configuration, SingletonAzureComponentFactory.Instance, connectionStringKey, new());
            var options = new ServiceManagerOptions();
            setup.Configure(options);
            Assert.NotNull(options.ProductInfo);
            var reg = new Regex(@"\[(\w*)=(\w*)\]");
            var match = reg.Match(options.ProductInfo);
            Assert.Equal(Constants.FunctionsWorkerProductInfoKey, match.Groups[1].Value);
            Assert.Equal(Constants.DotnetWorker, match.Groups[2].Value);
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
        public async void TestConfigurationHotReload()
        {
            var mock = new Mock<IEndpointRouter>();
            var connectionStrings = FakeEndpointUtils.GetFakeConnectionString(2).ToArray();
            var configuration = new ConfigurationRoot(new List<IConfigurationProvider>() { new MemoryConfigurationProvider(new()) });
            configuration[Constants.AzureSignalRConnectionStringName] = connectionStrings[0];
            // Only persistent mode supports hot reload.
            configuration[Constants.ServiceTransportTypeName] = "Persistent";
            var loggerFactory = new LoggerFactory();
            loggerFactory.AddProvider(new XunitLoggerProvider(_output));
            var managerStore = new ServiceManagerStore(configuration, loggerFactory, SingletonAzureComponentFactory.Instance, Options.Create(new SignalROptions()), mock.Object);
            var hubContextStore = managerStore.GetOrAddByConnectionStringKey(Constants.AzureSignalRConnectionStringName);
            var hubContext = await hubContextStore.GetAsync("hub") as ServiceHubContext;
            await hubContext.ClientManager.UserExistsAsync("a");

            configuration[Constants.AzureSignalRConnectionStringName] = connectionStrings[1];
            configuration.Reload();
            await Task.Delay(6000);
            await hubContext.ClientManager.UserExistsAsync("a");

            Assert.Equal(2, mock.Invocations.Count);
            // By design, the new endpoint is firstly appended to the original endpoint list instead of replacing the old endpoint.
            Assert.Equal(2, (mock.Invocations.Last().Arguments[1] as IEnumerable<ServiceEndpoint>).Count());
        }
    }
}