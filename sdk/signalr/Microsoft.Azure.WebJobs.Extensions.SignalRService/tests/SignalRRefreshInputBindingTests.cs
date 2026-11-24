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
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.SignalR.Management;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.SignalRService;
using Microsoft.Azure.WebJobs.Host.Bindings;
using Microsoft.Extensions.Configuration;
using Moq;
using Xunit;
using SecurityTokenValidationException = Microsoft.IdentityModel.Tokens.SecurityTokenValidationException;

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
            public static void Method([SignalRRefresh(ConnectionToken = "{headers.X-SignalR-Connection-Token}", HubName = HubName)] SignalRConnectionInfo info)
            {
            }
        }

        [Fact]
        public void AuthenticationRefreshSample_NegotiateWithoutConnectionInfo_ReturnsUnauthorized()
        {
            var result = Samples.AuthenticationRefresh.Negotiate(new DefaultHttpContext().Request, null);

            Assert.IsType<UnauthorizedResult>(result);
        }

        [Theory]
        [InlineData("connection-token")]
        [InlineData(null)]
        public void AuthenticationRefreshSample_RefreshWithoutConnectionInfo_ReturnsUnauthorized(string connectionToken)
        {
            var request = new DefaultHttpContext().Request;
            if (connectionToken is not null)
            {
                request.Headers["X-SignalR-Connection-Token"] = connectionToken;
            }

            var result = Samples.AuthenticationRefresh.Refresh(request, null);

            Assert.IsType<UnauthorizedResult>(result);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData(" ")]
        public async Task BuildAsync_MissingOrBlankResolvedConnectionToken_DoesNotUseRequestFallback(string configuredToken)
        {
            var validator = new Mock<ISecurityTokenValidator>(MockBehavior.Strict);
            var (binding, hubContext) = CreateBinding(out _, validator.Object);
            var attr = new SignalRRefreshAttribute { ConnectionToken = configuredToken, HubName = HubName, ConnectionStringSetting = ConnectionStringSetting };
            var request = new DefaultHttpContext().Request;
            request.QueryString = new QueryString("?id=query-token");
            request.Headers["X-SignalR-Connection-Token"] = "header-token";

            var provider = await binding.InvokeBuildAsync(attr, new Dictionary<string, object> { [HttpRequestName] = request });
            var value = await provider.GetValueAsync();

            Assert.Null(value);
            hubContext.Verify(
                c => c.RefreshConnectionAuthenticationAsync(It.IsAny<string>(), It.IsAny<RefreshConnectionAuthenticationOptions>(), It.IsAny<CancellationToken>()),
                Times.Never);
        }

        [Fact]
        public async Task BindAsync_UsesExplicitConnectionTokenHeaderExpression()
        {
            var validator = new Mock<ISecurityTokenValidator>();
            validator.Setup(v => v.ValidateToken(It.IsAny<HttpRequest>()))
                .Returns(SecurityTokenResult.Success(new ClaimsPrincipal(new ClaimsIdentity())));
            var (binding, hubContext) = CreateBinding(out _, validator.Object);
            var request = new DefaultHttpContext().Request;
            request.Headers["X-SignalR-Connection-Token"] = "header-token";
            request.QueryString = new QueryString("?id=query-token");

            var headers = request.Headers.ToDictionary(header => header.Key, header => header.Value.ToString(), StringComparer.OrdinalIgnoreCase);
            var context = new BindingContext(new ValueBindingContext(new FunctionBindingContext(Guid.Empty, CancellationToken.None), CancellationToken.None),
                new Dictionary<string, object>(StringComparer.OrdinalIgnoreCase) { [HttpRequestName] = request, ["Headers"] = headers });
            var provider = await binding.BindAsync(context);

            Assert.IsType<SignalRConnectionInfo>(await provider.GetValueAsync());
            hubContext.Verify(
                c => c.RefreshConnectionAuthenticationAsync("header-token", It.IsAny<RefreshConnectionAuthenticationOptions>(), It.IsAny<CancellationToken>()),
                Times.Once);
        }

        [Theory]
        [InlineData(false)]
        [InlineData(true)]
        public async Task BuildAsync_MissingOrInvalidBearer_ReturnsNullInfo(bool invalidBearer)
        {
            var validator = new Mock<ISecurityTokenValidator>();
            validator.Setup(v => v.ValidateToken(It.IsAny<HttpRequest>()))
                .Returns(invalidBearer ? SecurityTokenResult.Error(new InvalidOperationException()) : SecurityTokenResult.Empty());
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
        public async Task BuildAsync_ValidatedBearerPastActualExpiration_DoesNotRefresh()
        {
            var validator = new Mock<ISecurityTokenValidator>();
            validator.Setup(v => v.ValidateToken(It.IsAny<HttpRequest>()))
                .Returns(SecurityTokenResult.Success(new ClaimsPrincipal(new ClaimsIdentity()), DateTimeOffset.UtcNow.AddMinutes(-1)));
            var configurer = new Mock<ISignalRConnectionInfoConfigurer>(MockBehavior.Strict);
            var (binding, hubContext) = CreateBinding(out _, validator.Object, configurer.Object);
            var attr = new SignalRRefreshAttribute { ConnectionToken = "ct", HubName = HubName, ConnectionStringSetting = ConnectionStringSetting };
            var bindingData = new Dictionary<string, object> { [HttpRequestName] = new DefaultHttpContext().Request };

            var provider = await binding.InvokeBuildAsync(attr, bindingData);

            Assert.Null(await provider.GetValueAsync());
            hubContext.Verify(
                c => c.RefreshConnectionAuthenticationAsync(It.IsAny<string>(), It.IsAny<RefreshConnectionAuthenticationOptions>(), It.IsAny<CancellationToken>()),
                Times.Never);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("original-user")]
        public async Task BuildAsync_ValidToken_PropagatesValidatedAuthenticationOptions(string userId)
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
                UserId = userId,
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
            Assert.Equal(userId, capturedOptions.Value.Claims.SingleOrDefault(c => c.Type == "asrs.s.uid")?.Value);
            hubContext.Verify(
                c => c.RefreshConnectionAuthenticationAsync("ct", It.IsAny<RefreshConnectionAuthenticationOptions>(), It.IsAny<CancellationToken>()),
                Times.Once);
        }

        [Fact]
        public async Task BuildAsync_ConfigurerReturnsReplacement_UsesReplacementUserIdClaimsAndExpiration()
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
                Claims = new List<Claim> { new Claim("replacement", "claim"), new Claim("ASRS.S.UID", "other-user") },
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
            Assert.Equal(2, capturedOptions.Value.Claims.Count());
            Assert.Equal("claim", capturedOptions.Value.Claims.Single(c => c.Type == "replacement").Value);
            Assert.Equal("replacement-user", capturedOptions.Value.Claims.Single(c => c.Type == "asrs.s.uid").Value);
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

        [Theory]
        [InlineData(false)]
        [InlineData(true)]
        public async Task BuildAsync_WithoutHttpRequest_ThrowsConfigurationError(bool hasNonHttpRequest)
        {
            var validator = new Mock<ISecurityTokenValidator>(MockBehavior.Strict);
            var (binding, hubContext) = CreateBinding(out _, validator.Object);
            var attr = new SignalRRefreshAttribute { ConnectionToken = "ct", HubName = HubName, ConnectionStringSetting = ConnectionStringSetting };
            var bindingData = new Dictionary<string, object>();
            if (hasNonHttpRequest)
            {
                bindingData.Add(HttpRequestName, new object());
            }

            var exception = await Assert.ThrowsAsync<InvalidOperationException>(() => binding.InvokeBuildAsync(attr, bindingData));

            Assert.Contains("HTTP-triggered", exception.Message);
            hubContext.Verify(
                c => c.RefreshConnectionAuthenticationAsync(It.IsAny<string>(), It.IsAny<RefreshConnectionAuthenticationOptions>(), It.IsAny<CancellationToken>()),
                Times.Never);
        }

        [Fact]
        public async Task BuildAsync_WithoutValidator_ThrowsConfigurationErrorEvenWithMissingConnectionToken()
        {
            var (binding, hubContext) = CreateBinding(out _);
            var attr = new SignalRRefreshAttribute { HubName = HubName, ConnectionStringSetting = ConnectionStringSetting };
            var bindingData = new Dictionary<string, object> { [HttpRequestName] = new DefaultHttpContext().Request };

            var exception = await Assert.ThrowsAsync<InvalidOperationException>(() => binding.InvokeBuildAsync(attr, bindingData));

            Assert.Contains("AddDefaultAuth", exception.Message);
            hubContext.Verify(
                c => c.RefreshConnectionAuthenticationAsync(It.IsAny<string>(), It.IsAny<RefreshConnectionAuthenticationOptions>(), It.IsAny<CancellationToken>()),
                Times.Never);
        }

        [Theory]
        [InlineData(false, false)]
        [InlineData(false, true)]
        [InlineData(true, false)]
        [InlineData(true, true)]
        public async Task BuildAsync_NoApplicationClaims_UsesUserIdToSelectClearOrPreserve(bool hasUserId, bool configureEmptyClaims)
        {
            var expectedExpiresOn = new DateTimeOffset(2030, 1, 2, 3, 4, 5, TimeSpan.Zero);
            var validator = new Mock<ISecurityTokenValidator>();
            validator.Setup(v => v.ValidateToken(It.IsAny<HttpRequest>()))
                .Returns(SecurityTokenResult.Success(new ClaimsPrincipal(new ClaimsIdentity()), expectedExpiresOn));
            var configurer = new Mock<ISignalRConnectionInfoConfigurer>();
            configurer.SetupGet(c => c.Configure).Returns((_, _, detail) =>
            {
                detail.Claims = new List<Claim>();
                return detail;
            });
            var (binding, hubContext) = CreateBinding(out var capturedOptions, validator.Object, configureEmptyClaims ? configurer.Object : null);
            const string userId = "original-user";
            var attr = new SignalRRefreshAttribute { ConnectionToken = "ct", HubName = HubName, ConnectionStringSetting = ConnectionStringSetting, UserId = hasUserId ? userId : null };
            var bindingData = new Dictionary<string, object> { [HttpRequestName] = new DefaultHttpContext().Request };

            var provider = await binding.InvokeBuildAsync(attr, bindingData);
            _ = await provider.GetValueAsync();

            Assert.Equal(expectedExpiresOn, capturedOptions.Value.AuthenticationExpiresOn);
            if (hasUserId)
            {
                var claim = Assert.Single(capturedOptions.Value.Claims);
                Assert.Equal("asrs.s.uid", claim.Type);
                Assert.Equal(userId, claim.Value);
            }
            else
            {
                Assert.Null(capturedOptions.Value.Claims);
            }
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

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public async Task BuildAsync_ConfigurerFailure_RejectsIdentityAndPropagatesOtherErrors(bool rejectsIdentity)
        {
            var failure = rejectsIdentity
                ? (Exception)new SecurityTokenValidationException("Missing user ID.")
                : new InvalidOperationException("Configuration error.");
            var validator = new Mock<ISecurityTokenValidator>();
            validator.Setup(v => v.ValidateToken(It.IsAny<HttpRequest>()))
                .Returns(SecurityTokenResult.Success(new ClaimsPrincipal(new ClaimsIdentity())));
            var configurer = new Mock<ISignalRConnectionInfoConfigurer>();
            configurer.SetupGet(c => c.Configure).Returns((_, _, _) => throw failure);
            var (binding, hubContext) = CreateBinding(out _, validator.Object, configurer.Object);
            var attr = new SignalRRefreshAttribute { ConnectionToken = "ct", HubName = HubName, ConnectionStringSetting = ConnectionStringSetting };
            var bindingData = new Dictionary<string, object> { [HttpRequestName] = new DefaultHttpContext().Request };

            if (rejectsIdentity)
            {
                var provider = await binding.InvokeBuildAsync(attr, bindingData);
                Assert.Null(await provider.GetValueAsync());
            }
            else
            {
                Assert.Same(failure, await Assert.ThrowsAsync<InvalidOperationException>(() => binding.InvokeBuildAsync(attr, bindingData)));
            }

            hubContext.Verify(
                c => c.RefreshConnectionAuthenticationAsync(It.IsAny<string>(), It.IsAny<RefreshConnectionAuthenticationOptions>(), It.IsAny<CancellationToken>()),
                Times.Never);
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
            var context = new BindingProviderContext(parameter,
                new Dictionary<string, Type>(StringComparer.OrdinalIgnoreCase) { ["Headers"] = typeof(IDictionary<string, string>) }, CancellationToken.None);

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
