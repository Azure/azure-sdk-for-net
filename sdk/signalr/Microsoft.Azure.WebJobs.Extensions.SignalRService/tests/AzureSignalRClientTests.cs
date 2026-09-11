// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Reflection;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http.Connections;
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
        public async Task GetClientConnectionInfoAsync_AuthenticationRefreshDisabled_UsesOrdinaryNegotiation()
        {
            const string expectedUrl = "https://example.test/client";
            const string expectedAccessToken = "ordinary-access-token";
            NegotiationOptions capturedOptions = null;
            var hubContext = new Mock<ServiceHubContext>();
            hubContext
                .Setup(c => c.NegotiateAsync(It.IsAny<NegotiationOptions>(), It.IsAny<CancellationToken>()))
                .Callback<NegotiationOptions, CancellationToken>((options, _) => capturedOptions = options)
                .Returns(new ValueTask<NegotiationResponse>(new NegotiationResponse
                {
                    Url = expectedUrl,
                    AccessToken = expectedAccessToken,
                }));
            var client = new AzureSignalRClient(hubContext.Object);

            var result = await client.GetClientConnectionInfoAsync("user", new List<Claim>(), httpContext: null);

            Assert.False(capturedOptions.EnableAuthenticationRefresh);
            Assert.Equal(expectedUrl, result.Url);
            Assert.Equal(expectedAccessToken, result.AccessToken);
            Assert.Null(result.TokenLifetimeSeconds);
            hubContext.Verify(
                c => c.NegotiateAsync(It.IsAny<NegotiationOptions>(), It.IsAny<CancellationToken>()),
                Times.Once);
            hubContext.Verify(
                c => c.NegotiateWithTokenLifetimeAsync(It.IsAny<NegotiationOptions>(), It.IsAny<CancellationToken>()),
                Times.Never);
        }

        [Fact]
        public async Task GetClientConnectionInfoAsync_AuthenticationRefreshEnabled_UsesLifetimeNegotiationAndPropagatesOptions()
        {
            const string expectedUrl = "https://example.test/client";
            const string expectedAccessToken = "refresh-access-token";
            const int tokenLifetimeSeconds = 300;
            const int expectedRefreshLifetimeSeconds = 111;
            var expectedExpiresOn = new DateTimeOffset(2030, 1, 2, 3, 4, 5, TimeSpan.Zero);
            var negotiationResult = (NegotiationResult)Activator.CreateInstance(
                typeof(NegotiationResult),
                BindingFlags.Instance | BindingFlags.NonPublic,
                binder: null,
                args: new object[] { expectedUrl, expectedAccessToken, expectedRefreshLifetimeSeconds },
                culture: null);
            NegotiationOptions capturedOptions = null;
            var hubContext = new Mock<ServiceHubContext>();
            hubContext
                .Setup(c => c.NegotiateWithTokenLifetimeAsync(It.IsAny<NegotiationOptions>(), It.IsAny<CancellationToken>()))
                .Callback<NegotiationOptions, CancellationToken>((options, _) => capturedOptions = options)
                .ReturnsAsync(negotiationResult);
            var client = new AzureSignalRClient(hubContext.Object);

            var result = await client.GetClientConnectionInfoAsync(
                userId: "user",
                idToken: null,
                claimTypeList: null,
                httpContext: null,
                enableAuthenticationRefresh: true,
                tokenLifetimeSeconds,
                expectedExpiresOn,
                closeOnAuthenticationExpiration: true);

            Assert.True(capturedOptions.EnableAuthenticationRefresh);
            Assert.Equal(expectedExpiresOn, capturedOptions.AuthenticationExpiresOn);
            Assert.True(capturedOptions.CloseOnAuthenticationExpiration);
            Assert.Equal(TimeSpan.FromSeconds(tokenLifetimeSeconds), capturedOptions.TokenLifetime);
            Assert.Equal(expectedUrl, result.Url);
            Assert.Equal(expectedAccessToken, result.AccessToken);
            Assert.Equal(expectedRefreshLifetimeSeconds, result.TokenLifetimeSeconds);
            hubContext.Verify(
                c => c.NegotiateWithTokenLifetimeAsync(It.IsAny<NegotiationOptions>(), It.IsAny<CancellationToken>()),
                Times.Once);
            hubContext.Verify(
                c => c.NegotiateAsync(It.IsAny<NegotiationOptions>(), It.IsAny<CancellationToken>()),
                Times.Never);
        }

        [Fact]
        public async Task GetClientConnectionInfoAsync_ReservedCustomerClaims_ArePrefixedWithoutRawDuplicates()
        {
            var reservedClaimTypes = new[]
            {
                "aud", "exp", "iat", "nbf", "iss", "actort", "acr", "azp", "c_hash", "jti", "nonce",
            };
            var claims = reservedClaimTypes
                .Select(type => new Claim(type, $"value-{type}"))
                .Concat(new[] { new Claim("custom", "custom-value") })
                .ToList();
            NegotiationOptions capturedOptions = null;
            var hubContext = new Mock<ServiceHubContext>();
            hubContext
                .Setup(c => c.NegotiateAsync(It.IsAny<NegotiationOptions>(), It.IsAny<CancellationToken>()))
                .Callback<NegotiationOptions, CancellationToken>((options, _) => capturedOptions = options)
                .Returns(new ValueTask<NegotiationResponse>(new NegotiationResponse
                {
                    Url = "https://example.test/client",
                    AccessToken = "access-token",
                }));
            var client = new AzureSignalRClient(hubContext.Object);

            _ = await client.GetClientConnectionInfoAsync("user", claims, httpContext: null);

            var encodedClaims = capturedOptions.Claims.ToList();
            foreach (var claimType in reservedClaimTypes)
            {
                Assert.Equal($"value-{claimType}", encodedClaims.Single(c => c.Type == $"{AzureSignalRClient.AzureSignalRUserPrefix}{claimType}").Value);
                Assert.DoesNotContain(encodedClaims, c => c.Type == claimType);
            }
            Assert.Equal("value-iss", encodedClaims.Single(c => c.Type == $"{AzureSignalRClient.AzureSignalRUserPrefix}iss").Value);
            Assert.Equal("value-jti", encodedClaims.Single(c => c.Type == $"{AzureSignalRClient.AzureSignalRUserPrefix}jti").Value);
            Assert.Equal("value-nonce", encodedClaims.Single(c => c.Type == $"{AzureSignalRClient.AzureSignalRUserPrefix}nonce").Value);
            Assert.Equal("custom-value", encodedClaims.Single(c => c.Type == "custom").Value);
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