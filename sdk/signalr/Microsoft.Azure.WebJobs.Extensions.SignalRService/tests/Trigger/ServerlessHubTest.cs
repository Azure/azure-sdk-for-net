// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Azure.SignalR;
using Microsoft.Azure.SignalR.Management;
using Microsoft.Azure.SignalR.Tests.Common;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.SignalRService;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging.Abstractions;
using Microsoft.Extensions.Options;
using Moq;
using Xunit;

namespace SignalRServiceExtension.Tests
{
    public class ServerlessHubTest
    {
        [Fact]
        private async Task ServerlessHubUnitTest()
        {
            var clientProxyMoc = new Mock<IClientProxy>();
            clientProxyMoc
                .Setup(c => c.SendCoreAsync(It.IsAny<string>(), It.IsAny<object[]>(), It.IsAny<CancellationToken>()))
                .Returns(Task.CompletedTask);
            var serviceHubContextMoc = new Mock<IServiceHubContext>();
            var hubClientsMoc = new Mock<IHubClients>();
            hubClientsMoc.SetupGet(h => h.All).Returns(clientProxyMoc.Object);
            serviceHubContextMoc.SetupGet(s => s.Clients).Returns(hubClientsMoc.Object);

            var serviceManagerMoc = new Mock<IServiceManager>();
            var myHub = new MyHub(serviceHubContextMoc.Object, serviceManagerMoc.Object);

            // Unit test negotiate
            var userId = Guid.NewGuid().ToString();
            myHub.Negotiate(userId);
            serviceManagerMoc.Verify(s => s.GetClientEndpoint(nameof(MyHub)), Times.Once);
            serviceManagerMoc.Verify(s => s.GenerateClientAccessToken(nameof(MyHub), userId, It.IsAny<IList<Claim>>(), It.IsAny<TimeSpan?>()), Times.Once);

            // Unit test broadcast method
            var target = Guid.NewGuid().ToString();
            var message = Guid.NewGuid().ToString();
            await myHub.Broadcast(new InvocationContext(), target, message);
            clientProxyMoc.Verify(c => c.SendCoreAsync(target, It.IsAny<object[]>(), It.IsAny<CancellationToken>()), Times.Once);
        }

        [Fact]
        public void GetHubNameTest()
        {
            var configuration = new ConfigurationBuilder().AddInMemoryCollection().Build();
            configuration["AzureSignalRConnectionString:serviceUri"] = "https://abc.com";
            using var serviceManagerStore = new ServiceManagerStore(configuration, NullLoggerFactory.Instance, SingletonAzureComponentFactory.Instance, Options.Create(new SignalROptions()));
            var myHub = new MyHub(serviceManagerStore);
            Assert.Equal("MyHub", myHub.HubName);
        }

        [Fact]
        public async Task ServerlessHubSyncNegotiate()
        {
            var hubContext = await new ServiceManagerBuilder().WithOptions(o => o.ConnectionString = FakeEndpointUtils.GetFakeConnectionString(1).Single()).BuildServiceManager().CreateHubContextAsync("hub", default);
            var serviceManager = Mock.Of<IServiceManager>();
            var myHub = new MyHub(hubContext, serviceManager);
            var connectionInfo = myHub.Negotiate("user");
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

            Assert.Throws<InvalidOperationException>(() => new MyHub(serviceManagerStore));

            configuration["AzureSignalRConnectionString:serviceUri"] = "https://abc.com";
            var myHub = new MyHub(serviceManagerStore);
            Assert.NotNull(serviceManagerStore.GetByConfigurationKey("AzureSignalRConnectionString"));
        }

        [SignalRConnection("SignalRConnection")]
        public class CustomConnectionHub : ServerlessHub
        {
            public CustomConnectionHub(ServiceHubContext serviceHubContext) : base(serviceHubContext) { }

            internal CustomConnectionHub(IServiceManagerStore serviceManagerStore) : base(serviceManagerStore) { }
        }

        private class MyHub : ServerlessHub
        {
            // Use default value = null to reconcile testing and production purpose.
            public MyHub(IServiceHubContext hubContext = null, IServiceManager serviceManager = null) : base(hubContext, serviceManager)
            {
            }

            // Use default value = null to reconcile testing and production purpose.
            public MyHub(IServiceManagerStore serviceManagerStore) : base(serviceManagerStore)
            {
            }

            [FunctionName("negotiate")]
            public SignalRConnectionInfo Negotiate(string userId)
            {
                return base.Negotiate(userId);
            }

            [FunctionName(nameof(Broadcast))]
            public async Task Broadcast([SignalRTrigger] InvocationContext invocationContext, string target, string message)
            {
                await Clients.All.SendAsync(target, message);
            }
        }
    }
}