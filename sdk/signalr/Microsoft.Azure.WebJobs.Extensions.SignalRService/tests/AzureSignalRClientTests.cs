// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Azure.SignalR;
using Microsoft.Azure.SignalR.Management;
using Microsoft.Azure.SignalR.Tests.Common;
using Microsoft.Azure.WebJobs.Extensions.SignalRService;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging.Abstractions;
using Microsoft.Extensions.Options;
using Moq;
using SignalRServiceExtension.Tests.Utils;
using Xunit;
using Constants = Microsoft.Azure.WebJobs.Extensions.SignalRService.Constants;
using SignalRUtils = Microsoft.Azure.WebJobs.Extensions.SignalRService.Utils;

namespace SignalRServiceExtension.Tests
{
    public class AzureSignalRClientTests
    {
        [Fact]
        public async Task GetClientConnectionInfo()
        {
            var hubName = "TestHub";
            var hubUrl = "http://localhost";
            var accessKey = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            var connectionString = $"Endpoint={hubUrl};AccessKey={accessKey};Version=1.0;";
            var userId = "User";
            var idToken = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiIxMjM0NTY3ODkwIiwibmFtZSI6IkpvaG4gRG9lIiwiaWF0IjoxNTE2MjM5MDIyfQ.SflKxwRJSMeKKF2QT4fwpMeJf36POk6yJV_adQssw5c";
            var expectedName = "John Doe";
            var expectedIat = "1516239022";
            var claimTypeList = new string[] { "name", "iat" };
            var connectionStringKey = Constants.AzureSignalRConnectionStringName;
            var configDict = new Dictionary<string, string>() { { Constants.ServiceTransportTypeName, "Transient" }, { connectionStringKey, connectionString } };
            var configuration = new ConfigurationBuilder().AddInMemoryCollection(configDict).Build();
            var serviceManagerStore = new ServiceManagerStore(configuration, NullLoggerFactory.Instance, SingletonAzureComponentFactory.Instance, Options.Create(new SignalROptions()), new TestRouter());
            var azureSignalRClient = await SignalRUtils.GetAzureSignalRClientAsync(connectionStringKey, hubName, serviceManagerStore);
            var connectionInfo = await azureSignalRClient.GetClientConnectionInfoAsync(userId, idToken, claimTypeList, null);

            Assert.Equal(connectionInfo.Url, $"{hubUrl}/client/?hub={hubName.ToLower()}");

            var claims = new JwtSecurityTokenHandler().ReadJwtToken(connectionInfo.AccessToken).Claims;
            Assert.Equal(expectedName, GetClaimValue(claims, "name"));
            Assert.Equal(expectedIat, GetClaimValue(claims, $"{AzureSignalRClient.AzureSignalRUserPrefix}iat"));
        }

        [Fact]
        public async Task ServiceEndpointsNotSet()
        {
            var rootHubContextMock = new Mock<ServiceHubContext>();
            var childHubContextMock = new Mock<ServiceHubContext>();
            rootHubContextMock.Setup(c => c.WithEndpoints(It.IsAny<ServiceEndpoint[]>())).Returns(childHubContextMock.Object);
            rootHubContextMock.Setup(c => c.Clients.All.SendCoreAsync(It.IsAny<string>(), It.IsAny<object[]>(), It.IsAny<CancellationToken>())).Returns(Task.CompletedTask);
            var serviceManagerStore = Mock.Of<IServiceManagerStore>(s => s.GetOrAddByConnectionStringKey(It.IsAny<string>()).GetAsync(It.IsAny<string>()) == new ValueTask<IServiceHubContext>(rootHubContextMock.Object));
            var azureSignalRClient = await SignalRUtils.GetAzureSignalRClientAsync("key", "hub", serviceManagerStore);

            var data = new SignalRData
            {
                Target = "target",
                Arguments = new object[] { "arg1" }
            };
            await azureSignalRClient.SendToAll(data);
            rootHubContextMock.Verify(c => c.Clients.All.SendCoreAsync(data.Target, data.Arguments, default), Times.Once);
            childHubContextMock.Verify(c => c.Clients.All.SendCoreAsync(It.IsAny<string>(), It.IsAny<object[]>(), It.IsAny<CancellationToken>()), Times.Never);
        }

        [Fact]
        public async Task ServiceEndpointsSet()
        {
            var rootHubContextMock = new Mock<ServiceHubContext>();
            var childHubContextMock = new Mock<ServiceHubContext>();
            rootHubContextMock.Setup(c => c.WithEndpoints(It.IsAny<ServiceEndpoint[]>())).Returns(childHubContextMock.Object);
            childHubContextMock.Setup(c => c.Clients.All.SendCoreAsync(It.IsAny<string>(), It.IsAny<object[]>(), It.IsAny<CancellationToken>())).Returns(Task.CompletedTask);
            var serviceManagerStore = Mock.Of<IServiceManagerStore>(s => s.GetOrAddByConnectionStringKey(It.IsAny<string>()).GetAsync(It.IsAny<string>()) == new ValueTask<IServiceHubContext>(rootHubContextMock.Object));
            var azureSignalRClient = await SignalRUtils.GetAzureSignalRClientAsync("key", "hub", serviceManagerStore);
            var data = new SignalRData
            {
                Target = "target",
                Arguments = new object[] { "arg1" },
                Endpoints = FakeEndpointUtils.GetFakeEndpoint(2).ToArray()
            };
            await azureSignalRClient.SendToAll(data);
            rootHubContextMock.Verify(c => c.WithEndpoints(data.Endpoints), Times.Once);
            rootHubContextMock.Verify(c => c.Clients.All.SendCoreAsync(It.IsAny<string>(), It.IsAny<object[]>(), It.IsAny<CancellationToken>()), Times.Never);
            childHubContextMock.Verify(c => c.Clients.All.SendCoreAsync(data.Target, data.Arguments, default), Times.Once);
        }

        private string GetClaimValue(IEnumerable<Claim> claims, string type) =>
            (from c in claims
             where c.Type == type
             select c.Value).FirstOrDefault();
    }
}