// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
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
    [Collection("SignalR input binding tests")]
    public class SignalRRefreshInputBindingTests
    {
        private const string HttpRequestName = "$request";
        private const string ConnectionStringSetting = Constants.AzureSignalRConnectionStringName;
        private const string HubName = "TestHub";
        private const string ConnectionString = "Endpoint=http://localhost;AccessKey=ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789;Version=1.0;";
        private const string RefreshedToken = "refreshed-access-token";
        private const int RefreshedLifetime = 111;

        private static readonly string IdToken = new JwtSecurityTokenHandler().WriteToken(
            new JwtSecurityToken(claims: new[]
            {
                new Claim("name", "John Doe"),
                new Claim("iat", "1516239022"),
            }));

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
                c => c.RefreshConnectionAuthenticationAsync(It.IsAny<string>(), It.IsAny<RefreshConnectionAuthenticationOptions>(), It.IsAny<CancellationToken>()),
                Times.Never);
        }

        [Fact]
        public async Task BuildAsync_ValidToken_PropagatesValidatedAuthenticationOptions()
        {
            var expectedExpiresOn = new DateTimeOffset(2030, 1, 2, 3, 4, 5, TimeSpan.Zero);
            var validator = new Mock<ISecurityTokenValidator>();
            validator.Setup(v => v.ValidateToken(It.IsAny<HttpRequest>()))
                .Returns(SecurityTokenResult.Success(new ClaimsPrincipal(new ClaimsIdentity()), expectedExpiresOn));
            var (binding, hubContext) = CreateBinding(out var capturedOptions, validator.Object);
            var attr = new SignalRRefreshAttribute
            {
                ConnectionToken = "ct",
                HubName = HubName,
                ConnectionStringSetting = ConnectionStringSetting,
                IdToken = IdToken,
                ClaimTypeList = new[] { "name", "iat" },
            };
            var bindingData = new Dictionary<string, object> { [HttpRequestName] = new DefaultHttpContext().Request };

            var provider = await binding.InvokeBuildAsync(attr, bindingData);
            var value = await provider.GetValueAsync();

            var info = Assert.IsType<SignalRConnectionInfo>(value);
            Assert.Equal(RefreshedToken, info.AccessToken);
            Assert.Equal(RefreshedLifetime, info.TokenLifetimeSeconds);
            Assert.Equal(expectedExpiresOn, capturedOptions.Value.AuthenticationExpiresOn);
            Assert.Equal(TimeSpan.FromHours(1), capturedOptions.Value.TokenLifetime);
            Assert.Equal("John Doe", capturedOptions.Value.Claims.Single(c => c.Type == "name").Value);
            Assert.Equal("1516239022", capturedOptions.Value.Claims.Single(c => c.Type == $"{AzureSignalRClient.AzureSignalRUserPrefix}iat").Value);
            hubContext.Verify(
                c => c.RefreshConnectionAuthenticationAsync("ct", It.IsAny<RefreshConnectionAuthenticationOptions>(), It.IsAny<CancellationToken>()),
                Times.Once);
        }

        [Fact]
        public async Task BuildAsync_ConfigurerReturnsReplacement_UsesReplacementClaimsAndExpiration()
        {
            var originalExpiresOn = new DateTimeOffset(2030, 1, 2, 3, 4, 5, TimeSpan.Zero);
            var replacementExpiresOn = originalExpiresOn.AddHours(1);
            var validator = new Mock<ISecurityTokenValidator>();
            validator.Setup(v => v.ValidateToken(It.IsAny<HttpRequest>()))
                .Returns(SecurityTokenResult.Success(new ClaimsPrincipal(new ClaimsIdentity()), originalExpiresOn));
            var configurer = new Mock<ISignalRConnectionInfoConfigurer>();
            configurer.SetupGet(c => c.Configure).Returns((_, _, _) => new SignalRConnectionDetail
            {
                UserId = "replacement-user",
                Claims = new List<Claim> { new Claim("replacement", "claim") },
                AuthenticationExpiresOn = replacementExpiresOn,
            });
            var (binding, _) = CreateBinding(out var capturedOptions, validator.Object, configurer.Object);
            var attr = new SignalRRefreshAttribute
            {
                ConnectionToken = "ct",
                HubName = HubName,
                ConnectionStringSetting = ConnectionStringSetting,
                UserId = "original-user",
                IdToken = IdToken,
                ClaimTypeList = new[] { "name" },
            };
            var bindingData = new Dictionary<string, object> { [HttpRequestName] = new DefaultHttpContext().Request };

            var provider = await binding.InvokeBuildAsync(attr, bindingData);
            var value = await provider.GetValueAsync();

            var info = Assert.IsType<SignalRConnectionInfo>(value);
            Assert.Equal(RefreshedToken, info.AccessToken);
            Assert.Equal(replacementExpiresOn, capturedOptions.Value.AuthenticationExpiresOn);
            var claim = Assert.Single(capturedOptions.Value.Claims);
            Assert.Equal("replacement", claim.Type);
            Assert.Equal("claim", claim.Value);
        }

        [Fact]
        public async Task BuildAsync_ConfigurerReturnsNull_RetainsOriginalClaimsAndExpiration()
        {
            var originalExpiresOn = new DateTimeOffset(2030, 1, 2, 3, 4, 5, TimeSpan.Zero);
            var validator = new Mock<ISecurityTokenValidator>();
            validator.Setup(v => v.ValidateToken(It.IsAny<HttpRequest>()))
                .Returns(SecurityTokenResult.Success(new ClaimsPrincipal(new ClaimsIdentity()), originalExpiresOn));
            var configurer = new Mock<ISignalRConnectionInfoConfigurer>();
            configurer.SetupGet(c => c.Configure).Returns((_, _, _) => null);
            var (binding, _) = CreateBinding(out var capturedOptions, validator.Object, configurer.Object);
            var attr = new SignalRRefreshAttribute
            {
                ConnectionToken = "ct",
                HubName = HubName,
                ConnectionStringSetting = ConnectionStringSetting,
                IdToken = IdToken,
                ClaimTypeList = new[] { "name" },
            };
            var bindingData = new Dictionary<string, object> { [HttpRequestName] = new DefaultHttpContext().Request };

            var provider = await binding.InvokeBuildAsync(attr, bindingData);
            var value = await provider.GetValueAsync();

            Assert.IsType<SignalRConnectionInfo>(value);
            Assert.Equal(originalExpiresOn, capturedOptions.Value.AuthenticationExpiresOn);
            var claim = Assert.Single(capturedOptions.Value.Claims);
            Assert.Equal("name", claim.Type);
            Assert.Equal("John Doe", claim.Value);
        }

        [Fact]
        public async Task BuildAsync_WithoutRequest_ReturnsNullInfo()
        {
            var validator = new Mock<ISecurityTokenValidator>();
            validator.Setup(v => v.ValidateToken(It.IsAny<HttpRequest>()))
                .Returns(SecurityTokenResult.Success(new ClaimsPrincipal(new ClaimsIdentity())));
            var (binding, hubContext) = CreateBinding(out _, validator.Object);
            var attr = new SignalRRefreshAttribute { ConnectionToken = "ct", HubName = HubName, ConnectionStringSetting = ConnectionStringSetting };

            var provider = await binding.InvokeBuildAsync(attr, new Dictionary<string, object>());
            var value = await provider.GetValueAsync();

            Assert.Null(value);
            hubContext.Verify(
                c => c.RefreshConnectionAuthenticationAsync(It.IsAny<string>(), It.IsAny<RefreshConnectionAuthenticationOptions>(), It.IsAny<CancellationToken>()),
                Times.Never);
        }

        [Fact]
        public async Task BuildAsync_WithoutValidator_ReturnsNullInfo()
        {
            var (binding, hubContext) = CreateBinding(out _);
            var attr = new SignalRRefreshAttribute { ConnectionToken = "ct", HubName = HubName, ConnectionStringSetting = ConnectionStringSetting };
            var bindingData = new Dictionary<string, object> { [HttpRequestName] = new DefaultHttpContext().Request };

            var provider = await binding.InvokeBuildAsync(attr, bindingData);
            var value = await provider.GetValueAsync();

            Assert.Null(value);
            hubContext.Verify(
                c => c.RefreshConnectionAuthenticationAsync(It.IsAny<string>(), It.IsAny<RefreshConnectionAuthenticationOptions>(), It.IsAny<CancellationToken>()),
                Times.Never);
        }

        [Fact]
        public async Task BuildAsync_NoCustomClaims_PreservesExistingClaimsAndUsesDefaultTokenLifetime()
        {
            var validator = new Mock<ISecurityTokenValidator>();
            validator.Setup(v => v.ValidateToken(It.IsAny<HttpRequest>()))
                .Returns(SecurityTokenResult.Success(new ClaimsPrincipal(new ClaimsIdentity())));
            var (binding, hubContext) = CreateBinding(out var capturedOptions, validator.Object);
            var attr = new SignalRRefreshAttribute { ConnectionToken = "ct", HubName = HubName, ConnectionStringSetting = ConnectionStringSetting, TokenLifetimeSeconds = 0 };
            var bindingData = new Dictionary<string, object> { [HttpRequestName] = new DefaultHttpContext().Request };

            var provider = await binding.InvokeBuildAsync(attr, bindingData);
            _ = await provider.GetValueAsync();

            Assert.Null(capturedOptions.Value.AuthenticationExpiresOn);
            Assert.Null(capturedOptions.Value.Claims);
            Assert.Equal(TimeSpan.FromHours(1), capturedOptions.Value.TokenLifetime);
            hubContext.Verify(
                c => c.RefreshConnectionAuthenticationAsync("ct", It.IsAny<RefreshConnectionAuthenticationOptions>(), It.IsAny<CancellationToken>()),
                Times.Once);
        }

        [Fact]
        public async Task BuildAsync_WithExplicitTokenLifetime_UsesConfiguredMaximum()
        {
            const int lifetime = 300;
            var validator = new Mock<ISecurityTokenValidator>();
            validator.Setup(v => v.ValidateToken(It.IsAny<HttpRequest>()))
                .Returns(SecurityTokenResult.Success(new ClaimsPrincipal(new ClaimsIdentity())));
            var (binding, hubContext) = CreateBinding(out var capturedOptions, validator.Object);
            var attr = new SignalRRefreshAttribute { ConnectionToken = "ct", HubName = HubName, ConnectionStringSetting = ConnectionStringSetting, TokenLifetimeSeconds = lifetime };
            var bindingData = new Dictionary<string, object> { [HttpRequestName] = new DefaultHttpContext().Request };

            var provider = await binding.InvokeBuildAsync(attr, bindingData);
            _ = await provider.GetValueAsync();

            Assert.Null(capturedOptions.Value.AuthenticationExpiresOn);
            Assert.Null(capturedOptions.Value.Claims);
            Assert.Equal(TimeSpan.FromSeconds(lifetime), capturedOptions.Value.TokenLifetime);
            hubContext.Verify(
                c => c.RefreshConnectionAuthenticationAsync("ct", It.IsAny<RefreshConnectionAuthenticationOptions>(), It.IsAny<CancellationToken>()),
                Times.Once);
        }

        private static (TestableRefreshBinding Binding, Mock<ServiceHubContext> HubContext) CreateBinding(
            out StrongBox<RefreshConnectionAuthenticationOptions> capturedOptions,
            ISecurityTokenValidator validator = null,
            ISignalRConnectionInfoConfigurer configurer = null)
        {
            var optionsBox = new StrongBox<RefreshConnectionAuthenticationOptions>();
            capturedOptions = optionsBox;

            var refreshResult = (RefreshConnectionAuthenticationResult)Activator.CreateInstance(
                typeof(RefreshConnectionAuthenticationResult),
                BindingFlags.Instance | BindingFlags.NonPublic,
                binder: null,
                args: new object[] { RefreshedToken, RefreshedLifetime },
                culture: null);

            var hubContextMock = new Mock<ServiceHubContext>();
            hubContextMock
                .Setup(c => c.RefreshConnectionAuthenticationAsync(It.IsAny<string>(), It.IsAny<RefreshConnectionAuthenticationOptions>(), It.IsAny<CancellationToken>()))
                .Callback<string, RefreshConnectionAuthenticationOptions, CancellationToken>((_, options, _) => optionsBox.Value = options)
                .ReturnsAsync(refreshResult);

            StaticServiceHubContextStore.ServiceManagerStore = Mock.Of<IServiceManagerStore>(s =>
                s.GetOrAddByConnectionStringKey(It.IsAny<string>()).GetAsync(It.IsAny<string>())
                    == new ValueTask<IServiceHubContext>(hubContextMock.Object));

            var configuration = new ConfigurationBuilder()
                .AddInMemoryCollection(new Dictionary<string, string> { [ConnectionStringSetting] = ConnectionString })
                .Build();

            var parameter = typeof(ParameterHolder).GetMethod(nameof(ParameterHolder.Method)).GetParameters()[0];
            var context = new BindingProviderContext(parameter, new Dictionary<string, Type>(), CancellationToken.None);

            var binding = new TestableRefreshBinding(context, configuration, Mock.Of<INameResolver>(), validator, configurer);
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
                BuildAsync(attr, bindingData, CancellationToken.None);
        }
    }
}
