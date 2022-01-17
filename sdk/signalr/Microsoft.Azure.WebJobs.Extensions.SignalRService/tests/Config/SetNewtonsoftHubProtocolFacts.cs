// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using Microsoft.AspNetCore.SignalR.Protocol;
using Microsoft.Azure.SignalR.Management;
using Microsoft.Azure.SignalR.Tests.Common;
using Microsoft.Azure.WebJobs.Extensions.SignalRService;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging.Abstractions;
using Microsoft.Extensions.Options;
using Newtonsoft.Json.Serialization;
using Xunit;

namespace SignalRServiceExtension.Tests
{
    public class SetNewtonsoftHubProtocolFacts
    {
        [Fact]
        public void EmptyHubProtocolSetting_DoNothing()
        {
            var configuration = new ConfigurationBuilder().AddInMemoryCollection().Build();
            var services = new ServiceCollection()
                .SetHubProtocol(configuration);
            Assert.Empty(services);
        }

#if NETCOREAPP3_1

        [Fact]
        public void SetSystemTextJson_DoNothing()
        {
            var configuration = new ConfigurationBuilder().AddInMemoryCollection().Build();
            configuration[Constants.AzureSignalRHubProtocol] = HubProtocol.SystemTextJson.ToString();
            var services = new ServiceCollection()
                .SetHubProtocol(configuration);
            Assert.Empty(services);
        }

        [Fact]
        public async Task SetNewtonsoftPersistent()
        {
            var serviceManagerStore = CreateServiceManagerStore(out var configuration);
            configuration[Constants.ServiceTransportTypeName] = "Persistent";
            var hubContext = await serviceManagerStore.GetOrAddByConnectionStringKey(Constants.AzureSignalRConnectionStringName).GetAsync("hub") as ServiceHubContextImpl;
            var hubProtocol = hubContext.ServiceProvider.GetRequiredService<IHubProtocol>();
            Assert.IsType<NewtonsoftJsonHubProtocol>(hubProtocol);
            var newtonsoftOptions = hubContext.ServiceProvider.GetRequiredService<IOptions<NewtonsoftJsonHubProtocolOptions>>();
            Assert.Null(newtonsoftOptions.Value.PayloadSerializerSettings.ContractResolver);
        }

        [Fact]
        public async Task SetNewtonsoftInTransientModeAsync()
        {
            var serviceManagerStore = CreateServiceManagerStore(out var configuration);
            var hubContext = await serviceManagerStore.GetOrAddByConnectionStringKey(Constants.AzureSignalRConnectionStringName).GetAsync("hub") as ServiceHubContextImpl;

            var restHubProtocol = hubContext.ServiceProvider.GetRequiredService<IRestHubProtocol>();
            Assert.IsType<NewtonsoftRestHubProtocol>(restHubProtocol);
            var newtonsoftOptions = hubContext.ServiceProvider.GetRequiredService<IOptions<NewtonsoftServiceHubProtocolOptions>>();
            Assert.Null(newtonsoftOptions.Value.PayloadSerializerSettings.ContractResolver);
        }

        [Fact]
        public async Task SetNewtonsoftCamelCaseInTransientModeAsync()
        {
            var serviceManagerStore = CreateServiceManagerStore(out var configuration);
            configuration["Azure:SignalR:HubProtocol:NewtonsoftJson:CamelCase"] = "true";

            var hubContext = await serviceManagerStore.GetOrAddByConnectionStringKey(Constants.AzureSignalRConnectionStringName).GetAsync("hub") as ServiceHubContextImpl;
            var restHubProtocol = hubContext.ServiceProvider.GetRequiredService<IRestHubProtocol>();
            Assert.IsType<NewtonsoftRestHubProtocol>(restHubProtocol);
            var newtonsoftOptions = hubContext.ServiceProvider.GetRequiredService<IOptions<NewtonsoftServiceHubProtocolOptions>>();
            Assert.IsType<CamelCasePropertyNamesContractResolver>(newtonsoftOptions.Value.PayloadSerializerSettings.ContractResolver);
        }

        [Fact]
        public async Task SetNewtonsoftCamelCaseInPersistentModeAsync()
        {
            var serviceManagerStore = CreateServiceManagerStore(out var configuration);
            configuration["Azure:SignalR:HubProtocol:NewtonsoftJson:CamelCase"] = "true";
            configuration[Constants.ServiceTransportTypeName] = "Persistent";

            var hubContext = await serviceManagerStore.GetOrAddByConnectionStringKey(Constants.AzureSignalRConnectionStringName).GetAsync("hub") as ServiceHubContextImpl;
            var hubProtocol = hubContext.ServiceProvider.GetRequiredService<IHubProtocol>();
            Assert.IsType<NewtonsoftJsonHubProtocol>(hubProtocol);
            var newtonsoftOptions = hubContext.ServiceProvider.GetRequiredService<IOptions<NewtonsoftJsonHubProtocolOptions>>();
            Assert.IsType<CamelCasePropertyNamesContractResolver>(newtonsoftOptions.Value.PayloadSerializerSettings.ContractResolver);
        }

        private ServiceManagerStore CreateServiceManagerStore(out IConfiguration configuration)
        {
            configuration = new ConfigurationBuilder().AddInMemoryCollection().Build();
            configuration[Constants.AzureSignalRHubProtocol] = HubProtocol.NewtonsoftJson.ToString();
            configuration[Constants.AzureSignalRConnectionStringName] = FakeEndpointUtils.GetFakeConnectionString(1).Single();

            return new ServiceManagerStore(configuration, NullLoggerFactory.Instance, null);
        }
#endif
    }
}