// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.Azure.SignalR.Common;
using Microsoft.Azure.SignalR.Management;
using Microsoft.Azure.SignalR.Tests.Common;
using Microsoft.Azure.WebJobs.Extensions.SignalRService;
using Microsoft.Extensions.Azure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging.Abstractions;
using Microsoft.Extensions.Options;
using Xunit;

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

            var managerStore = new ServiceManagerStore(configuration, NullLoggerFactory.Instance, null);
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

            var productInfo = new ServiceCollection()
                .AddSignalRServiceManager(new OptionsSetup(configuration, NullLoggerFactory.Instance, SingletonAzureComponentFactory.Instance, connectionStringKey))
                .BuildServiceProvider()
                .GetRequiredService<IOptions<ServiceManagerOptions>>()
                .Value.ProductInfo;

            Assert.NotNull(productInfo);
            var reg = new Regex(@"\[(\w*)=(\w*)\]");
            var match = reg.Match(productInfo);
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
    }
}