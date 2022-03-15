// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Azure.SignalR;
using Microsoft.Azure.SignalR.Management;
using Microsoft.Azure.SignalR.Tests.Common;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging.Abstractions;
using Microsoft.Extensions.Options;
using SignalRServiceExtension.Tests;
using Xunit;

namespace Microsoft.Azure.WebJobs.Extensions.SignalRService.Tests
{
    public class StronglyTypedServerlessHubTests
    {
        [Fact]
        public async Task NegotiateAsync()
        {
            var serviceManager = new ServiceManagerBuilder().WithOptions(o => o.ConnectionString = FakeEndpointUtils.GetFakeConnectionString(1).Single()).BuildServiceManager();
            var hubContext = await serviceManager.CreateHubContextAsync<IChatClient>("hubName", default);
            var myHub = new TestStronglyTypedHub(hubContext);
            var connectionInfo = await myHub.Negotiate("user");
            Assert.NotNull(connectionInfo);
        }

        [Fact]
        public void TestCustomSignalRConnectionAttribute()
        {
            var configuration = new ConfigurationBuilder().AddInMemoryCollection().Build();
            using var serviceManagerStore = new ServiceManagerStore(configuration, NullLoggerFactory.Instance, SingletonAzureComponentFactory.Instance, Options.Create(new SignalROptions()));

            Assert.Throws<InvalidOperationException>(() => new CustomConnectionHub(serviceManagerStore));

            configuration["SignalRConnection:serviceUri"] = "https://abc.com";
            var myHub = new CustomConnectionHub(serviceManagerStore);
            Assert.NotNull(serviceManagerStore.GetByConfigurationKey("SignalRConnection"));
        }

        [Fact]
        public void TestWithoutSignalRConnectionAttribute()
        {
            var configuration = new ConfigurationBuilder().AddInMemoryCollection().Build();
            using var serviceManagerStore = new ServiceManagerStore(configuration, NullLoggerFactory.Instance, SingletonAzureComponentFactory.Instance, Options.Create(new SignalROptions()));

            Assert.Throws<InvalidOperationException>(() => new TestStronglyTypedHub(serviceManagerStore));

            configuration["AzureSignalRConnectionString:serviceUri"] = "https://abc.com";
            var myHub = new TestStronglyTypedHub(serviceManagerStore);
            Assert.NotNull(serviceManagerStore.GetByConfigurationKey("AzureSignalRConnectionString"));
        }

        [SignalRConnection("SignalRConnection")]
        public class CustomConnectionHub : ServerlessHub<IChatClient>
        {
            public CustomConnectionHub(ServiceHubContext<IChatClient> serviceHubContext) : base(serviceHubContext) { }

            internal CustomConnectionHub(IServiceManagerStore serviceManagerStore) : base(serviceManagerStore) { }
        }

        [Fact]
        public void GetHubNameTest()
        {
            var configuration = new ConfigurationBuilder().AddInMemoryCollection().Build();
            configuration["AzureSignalRConnectionString:serviceUri"] = "https://abc.com";
            using var serviceManagerStore = new ServiceManagerStore(configuration, NullLoggerFactory.Instance, SingletonAzureComponentFactory.Instance, Options.Create(new SignalROptions()), new EndpointRouterDecorator());
            var myHub = new TestStronglyTypedHub(serviceManagerStore);
            Assert.Equal("TestStronglyTypedHub", myHub.HubName);
        }
    }
}