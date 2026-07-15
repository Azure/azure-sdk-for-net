// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Azure.SignalR.Management;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.SignalRService;
using Microsoft.Azure.WebJobs.Host.Bindings;
using Microsoft.Extensions.Configuration;
using Moq;
using Xunit;

namespace SignalRServiceExtension.Tests
{
    /// <summary>
    /// Behavioral tests for the [SignalRRefresh] input binding (<see cref="SignalRRefreshInputBinding"/>)
    /// </summary>
    public class SignalRRefreshInputBindingTests
    {
        private const string HttpRequestName = "$request";
        private const string ConnectionStringSetting = Constants.AzureSignalRConnectionStringName;
        private const string HubName = "TestHub";
        private const string ConnectionString = "Endpoint=http://localhost;AccessKey=ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789;Version=1.0;";
        private const string RefreshedToken = "refreshed-access-token";
        private const int RefreshedLifetime = 111;

        private static class ParameterHolder
        {
            public static void Method([SignalRRefresh(ConnectionToken = "ct", HubName = HubName)] SignalRConnectionInfo info)
            {
            }
        }

        [Fact]
        public async Task BuildAsync_MissingConnectionToken_ReturnsNullInfo()
        {
            var (binding, _) = CreateBinding(out _);
            var attr = new SignalRRefreshAttribute { ConnectionToken = null, HubName = HubName, ConnectionStringSetting = ConnectionStringSetting };

            var provider = await binding.InvokeBuildAsync(attr, new Dictionary<string, object>());
            var value = await provider.GetValueAsync();

            Assert.Null(value);
        }

        [Fact]
        public async Task BuildAsync_InvalidToken_ReturnsNullInfo()
        {
            var validator = new Mock<ISecurityTokenValidator>();
            validator.Setup(v => v.ValidateToken(It.IsAny<HttpRequest>())).Returns(SecurityTokenResult.Empty());
            var (binding, hubContext) = CreateBinding(out _, validator.Object);
            var attr = new SignalRRefreshAttribute { ConnectionToken = "ct", HubName = HubName, ConnectionStringSetting = ConnectionStringSetting };
            var bindingData = new Dictionary<string, object> { [HttpRequestName] = new DefaultHttpContext().Request };

            var provider = await binding.InvokeBuildAsync(attr, bindingData);
            var value = await provider.GetValueAsync();

            Assert.Null(value);
            hubContext.Verify(
                c => c.RefreshConnectionAuthenticationAsync(It.IsAny<string>(), It.IsAny<DateTimeOffset>(), It.IsAny<IEnumerable<Claim>>(), It.IsAny<CancellationToken>()),
                Times.Never);
        }

        [Fact]
        public async Task BuildAsync_ValidToken_RefreshesAndReturnsInfo()
        {
            var validator = new Mock<ISecurityTokenValidator>();
            validator.Setup(v => v.ValidateToken(It.IsAny<HttpRequest>()))
                .Returns(SecurityTokenResult.Success(new ClaimsPrincipal(new ClaimsIdentity())));
            var (binding, hubContext) = CreateBinding(out _, validator.Object);
            var attr = new SignalRRefreshAttribute { ConnectionToken = "ct", HubName = HubName, ConnectionStringSetting = ConnectionStringSetting };
            var bindingData = new Dictionary<string, object> { [HttpRequestName] = new DefaultHttpContext().Request };

            var provider = await binding.InvokeBuildAsync(attr, bindingData);
            var value = await provider.GetValueAsync();

            var info = Assert.IsType<SignalRConnectionInfo>(value);
            Assert.Equal(RefreshedToken, info.AccessToken);
            Assert.Equal(RefreshedLifetime, info.TokenLifetimeSeconds);
            hubContext.Verify(
                c => c.RefreshConnectionAuthenticationAsync("ct", It.IsAny<DateTimeOffset>(), It.IsAny<IEnumerable<Claim>>(), It.IsAny<CancellationToken>()),
                Times.Once);
        }

        [Fact]
        public async Task BuildAsync_NoTokenLifetime_UsesDefaultLifetime()
        {
            var (binding, _) = CreateBinding(out var capturedExpireTime);
            var attr = new SignalRRefreshAttribute { ConnectionToken = "ct", HubName = HubName, ConnectionStringSetting = ConnectionStringSetting, TokenLifetimeSeconds = 0 };

            var before = DateTimeOffset.UtcNow;
            var provider = await binding.InvokeBuildAsync(attr, new Dictionary<string, object>());
            _ = await provider.GetValueAsync();
            var after = DateTimeOffset.UtcNow;

            Assert.NotNull(capturedExpireTime.Value);
            Assert.InRange(
                capturedExpireTime.Value.Value,
                before.AddSeconds(Constants.DefaultAccessTokenLifetimeSeconds),
                after.AddSeconds(Constants.DefaultAccessTokenLifetimeSeconds));
        }

        [Fact]
        public async Task BuildAsync_ExplicitTokenLifetime_UsesProvidedLifetime()
        {
            const int lifetime = 300;
            var (binding, _) = CreateBinding(out var capturedExpireTime);
            var attr = new SignalRRefreshAttribute { ConnectionToken = "ct", HubName = HubName, ConnectionStringSetting = ConnectionStringSetting, TokenLifetimeSeconds = lifetime };

            var before = DateTimeOffset.UtcNow;
            var provider = await binding.InvokeBuildAsync(attr, new Dictionary<string, object>());
            _ = await provider.GetValueAsync();
            var after = DateTimeOffset.UtcNow;

            Assert.NotNull(capturedExpireTime.Value);
            Assert.InRange(capturedExpireTime.Value.Value, before.AddSeconds(lifetime), after.AddSeconds(lifetime));
        }

        private static (TestableRefreshBinding Binding, Mock<ServiceHubContext> HubContext) CreateBinding(
            out StrongBox<DateTimeOffset?> capturedExpireTime, ISecurityTokenValidator validator = null)
        {
            var expireBox = new StrongBox<DateTimeOffset?>();
            capturedExpireTime = expireBox;

            var refreshResult = (RefreshConnectionAuthenticationResult)Activator.CreateInstance(
                typeof(RefreshConnectionAuthenticationResult),
                BindingFlags.Instance | BindingFlags.NonPublic,
                binder: null,
                args: new object[] { RefreshedToken, RefreshedLifetime },
                culture: null);

            var hubContextMock = new Mock<ServiceHubContext>();
            hubContextMock
                .Setup(c => c.RefreshConnectionAuthenticationAsync(It.IsAny<string>(), It.IsAny<DateTimeOffset>(), It.IsAny<IEnumerable<Claim>>(), It.IsAny<CancellationToken>()))
                .Callback<string, DateTimeOffset, IEnumerable<Claim>, CancellationToken>((_, expireTime, _, _) => expireBox.Value = expireTime)
                .ReturnsAsync(refreshResult);

            StaticServiceHubContextStore.ServiceManagerStore = Mock.Of<IServiceManagerStore>(s =>
                s.GetOrAddByConnectionStringKey(It.IsAny<string>()).GetAsync(It.IsAny<string>())
                    == new ValueTask<IServiceHubContext>(hubContextMock.Object));

            var configuration = new ConfigurationBuilder()
                .AddInMemoryCollection(new Dictionary<string, string> { [ConnectionStringSetting] = ConnectionString })
                .Build();

            var parameter = typeof(ParameterHolder).GetMethod(nameof(ParameterHolder.Method)).GetParameters()[0];
            var context = new BindingProviderContext(parameter, new Dictionary<string, Type>(), CancellationToken.None);

            var binding = new TestableRefreshBinding(context, configuration, Mock.Of<INameResolver>(), validator, signalRConnectionInfoConfigurer: null);
            return (binding, hubContextMock);
        }

        private sealed class TestableRefreshBinding : SignalRRefreshInputBinding
        {
            public TestableRefreshBinding(
                BindingProviderContext context,
                IConfiguration configuration,
                INameResolver nameResolver,
                ISecurityTokenValidator securityTokenValidator,
                ISignalRConnectionInfoConfigurer signalRConnectionInfoConfigurer)
                : base(context, configuration, nameResolver, securityTokenValidator, signalRConnectionInfoConfigurer)
            {
            }

            public Task<IValueProvider> InvokeBuildAsync(SignalRRefreshAttribute attr, IReadOnlyDictionary<string, object> bindingData) =>
                BuildAsync(attr, bindingData);
        }
    }
}
