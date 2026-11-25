// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Security.Claims;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.SignalR.Common;
using Microsoft.Azure.SignalR.Management;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.SignalRService;
using Microsoft.Azure.WebJobs.Host.Bindings;
using Microsoft.Extensions.Configuration;
using Moq;
using Xunit;
using DefaultSecurityTokenValidatorTests = Microsoft.Azure.WebJobs.Extensions.SignalRService.Tests.DefaultSecurityTokenValidatorTests;
using SecurityTokenValidationException = Microsoft.IdentityModel.Tokens.SecurityTokenValidationException;
using SymmetricSecurityKey = Microsoft.IdentityModel.Tokens.SymmetricSecurityKey;

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
        private const string UserMismatchMessage = "Refresh failed: a different user was specified.";
        private const string ConnectionNotFoundMessage = "Refresh failed: connection not found.";

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

            public static void CustomHeaderMethod([SignalRRefresh(ConnectionToken = "{headers.X-Custom-Connection-Token}", HubName = HubName)] SignalRConnectionInfo info)
            {
            }

            public static void ResultMethod([SignalRRefresh(ConnectionToken = "{headers.X-SignalR-Connection-Token}", HubName = HubName)] SignalRRefreshResult result)
            {
            }
        }

        [Theory]
        [InlineData(true, false, SignalRRefreshStatus.MissingConnectionToken)]
        [InlineData(false, false, SignalRRefreshStatus.Unauthorized)]
        [InlineData(false, true, SignalRRefreshStatus.Succeeded)]
        public async Task BindAsync_ResultParameter_ReportsLocalOutcome(bool missingConnectionToken, bool authorized, SignalRRefreshStatus expectedStatus)
        {
            var validator = new Mock<ISecurityTokenValidator>();
            validator.Setup(v => v.ValidateToken(It.IsAny<HttpRequest>()))
                .Returns(authorized ? SecurityTokenResult.Success(new ClaimsPrincipal(new ClaimsIdentity())) : SecurityTokenResult.Empty());
            var (binding, hubContext) = CreateBinding(out _, validator.Object, useResultParameter: true);
            var request = new DefaultHttpContext().Request;
            request.Headers["X-SignalR-Connection-Token"] = missingConnectionToken ? " " : "ct";

            var provider = await binding.BindAsync(CreateBindingContext(request));
            Assert.Equal(typeof(SignalRRefreshResult), provider.Type);
            var result = Assert.IsType<SignalRRefreshResult>(await provider.GetValueAsync());
            Assert.Equal(expectedStatus, result.Status);
            if (authorized)
            {
                Assert.Equal(RefreshedToken, result.ConnectionInfo.AccessToken);
                Assert.Equal(RefreshedLifetime, result.ConnectionInfo.TokenLifetimeSeconds);
            }
            else
            {
                Assert.Null(result.ConnectionInfo);
            }
            hubContext.Verify(
                c => c.RefreshConnectionAuthenticationAsync(It.IsAny<string>(), It.IsAny<RefreshConnectionAuthenticationOptions>(), It.IsAny<CancellationToken>()),
                authorized ? Times.Once() : Times.Never());
        }

        [Theory]
        [InlineData(UserMismatchMessage, SignalRRefreshStatus.Forbidden)]
        [InlineData(ConnectionNotFoundMessage, SignalRRefreshStatus.ConnectionNotFound)]
        public async Task BindAsync_ResultParameter_MapsKnownManagementSdkRejection(string message, SignalRRefreshStatus expectedStatus)
        {
            var (binding, context) = CreateFailingRefreshBinding(new AzureSignalRException(message), useResultParameter: true);

            var provider = await binding.BindAsync(context);

            var result = Assert.IsType<SignalRRefreshResult>(await provider.GetValueAsync());
            Assert.Equal(expectedStatus, result.Status);
            Assert.Null(result.ConnectionInfo);
        }

        [Theory]
        [InlineData("The operation timed out before the service acknowledged it.", true)]
        [InlineData("The user could not be resolved.", true)]
        [InlineData(UserMismatchMessage, false)]
        [InlineData(ConnectionNotFoundMessage, false)]
        public async Task BindAsync_UnmappedManagementSdkFailure_PropagatesOriginalException(string message, bool useResultParameter)
        {
            var failure = new AzureSignalRException(message);
            var (binding, context) = CreateFailingRefreshBinding(failure, useResultParameter);

            var actual = await Assert.ThrowsAsync<AzureSignalRException>(() => binding.BindAsync(context));

            Assert.Same(failure, actual);
        }

        private static (TestableRefreshBinding Binding, BindingContext Context) CreateFailingRefreshBinding(AzureSignalRException failure, bool useResultParameter)
        {
            var (binding, hubContext) = CreateBinding(out _, CreateValidTokenValidator(), useResultParameter: useResultParameter);
            hubContext.Setup(c => c.RefreshConnectionAuthenticationAsync("ct", It.IsAny<RefreshConnectionAuthenticationOptions>(), It.IsAny<CancellationToken>()))
                .ThrowsAsync(failure);
            var request = new DefaultHttpContext().Request;
            request.Headers["X-SignalR-Connection-Token"] = "ct";

            return (binding, CreateBindingContext(request));
        }

        [Fact]
        public void AuthenticationRefreshSample_NegotiateWithoutConnectionInfo_ReturnsUnauthorized()
        {
            var result = Samples.AuthenticationRefresh.Negotiate(new DefaultHttpContext().Request, null);

            Assert.IsType<UnauthorizedResult>(result);
        }

        [Theory]
        [InlineData(null, StatusCodes.Status400BadRequest)]
        [InlineData("", StatusCodes.Status400BadRequest)]
        [InlineData(" ", StatusCodes.Status400BadRequest)]
        [InlineData("connection-token", StatusCodes.Status200OK)]
        public async Task AuthenticationRefreshSample_BindsDefaultHeaderAndReturnsExpectedStatus(string connectionToken, int expectedStatus)
        {
            var validator = new Mock<ISecurityTokenValidator>(MockBehavior.Strict);
            if (expectedStatus == StatusCodes.Status200OK)
            {
                validator.Setup(v => v.ValidateToken(It.IsAny<HttpRequest>()))
                    .Returns(SecurityTokenResult.Success(new ClaimsPrincipal(new ClaimsIdentity())));
            }
            var parameter = typeof(Samples.AuthenticationRefresh).GetMethod(nameof(Samples.AuthenticationRefresh.Refresh)).GetParameters()[1];
            var (binding, hubContext) = CreateBinding(out _, validator.Object, parameter: parameter);
            var request = new DefaultHttpContext().Request;
            request.QueryString = new QueryString("?id=query-token");
            if (connectionToken is not null)
            {
                request.Headers["X-SignalR-Connection-Token"] = connectionToken;
            }

            var provider = await binding.BindAsync(CreateBindingContext(request));
            var result = Assert.IsType<SignalRRefreshResult>(await provider.GetValueAsync());
            var response = Samples.AuthenticationRefresh.Refresh(request, result);

            if (expectedStatus == StatusCodes.Status200OK)
            {
                var okResult = Assert.IsType<OkObjectResult>(response);
                Assert.Equal(expectedStatus, okResult.StatusCode);
                Assert.Same(result.ConnectionInfo, okResult.Value);
                hubContext.Verify(
                    c => c.RefreshConnectionAuthenticationAsync(connectionToken, It.IsAny<RefreshConnectionAuthenticationOptions>(), It.IsAny<CancellationToken>()),
                    Times.Once);
            }
            else
            {
                Assert.Equal(expectedStatus, Assert.IsType<BadRequestResult>(response).StatusCode);
                Assert.Equal(SignalRRefreshStatus.MissingConnectionToken, result.Status);
                hubContext.Verify(
                    c => c.RefreshConnectionAuthenticationAsync(It.IsAny<string>(), It.IsAny<RefreshConnectionAuthenticationOptions>(), It.IsAny<CancellationToken>()),
                    Times.Never);
            }
        }

        [Theory]
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
        public async Task BindAsync_ExplicitConnectionTokenHeaderExpression_TakesPrecedenceOverDefaultHeader()
        {
            var parameter = typeof(ParameterHolder).GetMethod(nameof(ParameterHolder.CustomHeaderMethod)).GetParameters()[0];
            var (binding, hubContext) = CreateBinding(out _, CreateValidTokenValidator(), parameter: parameter);
            var request = new DefaultHttpContext().Request;
            request.Headers["X-Custom-Connection-Token"] = "custom-token";
            request.Headers["X-SignalR-Connection-Token"] = "default-token";
            request.QueryString = new QueryString("?id=query-token");

            var provider = await binding.BindAsync(CreateBindingContext(request));

            Assert.IsType<SignalRConnectionInfo>(await provider.GetValueAsync());
            hubContext.Verify(
                c => c.RefreshConnectionAuthenticationAsync("custom-token", It.IsAny<RefreshConnectionAuthenticationOptions>(), It.IsAny<CancellationToken>()),
                Times.Once);
        }

        private static BindingContext CreateBindingContext(HttpRequest request)
        {
            var headers = request.Headers.ToDictionary(header => header.Key, header => header.Value.ToString(), StringComparer.OrdinalIgnoreCase);
            return new BindingContext(new ValueBindingContext(new FunctionBindingContext(Guid.Empty, CancellationToken.None), CancellationToken.None),
                new Dictionary<string, object>(StringComparer.OrdinalIgnoreCase) { [HttpRequestName] = request, ["Headers"] = headers });
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
        public async Task BindAsync_BearerWithInvalidIssuer_ReturnsUnauthorizedWithoutRefreshing()
        {
            const string key = "1234567812345678912345678123456789";
            const string audience = "audience";
            var token = DefaultSecurityTokenValidatorTests.GenerateJwtToken(key, "untrusted-issuer", audience, expireMinutes: 10);
            var validator = new DefaultSecurityTokenValidator(parameters =>
            {
                parameters.IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
                parameters.ValidIssuer = "trusted-issuer";
                parameters.ValidAudience = audience;
            });
            var (binding, hubContext) = CreateBinding(out _, validator, useResultParameter: true);
            var request = new DefaultHttpContext().Request;
            request.Headers["Authorization"] = $"Bearer {token}";
            request.Headers["X-SignalR-Connection-Token"] = "ct";

            var provider = await binding.BindAsync(CreateBindingContext(request));

            var result = Assert.IsType<SignalRRefreshResult>(await provider.GetValueAsync());
            Assert.Equal(SignalRRefreshStatus.Unauthorized, result.Status);
            Assert.Null(result.ConnectionInfo);
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
            var (binding, hubContext) = CreateBinding(out var capturedOptions, CreateValidTokenValidator(expectedExpiresOn));
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
            var configurer = new Mock<ISignalRConnectionInfoConfigurer>();
            configurer.SetupGet(c => c.Configure).Returns((_, _, _) => new SignalRConnectionDetail
            {
                UserId = "replacement-user",
                Claims = new List<Claim> { new Claim("replacement", "claim"), new Claim("ASRS.S.UID", "other-user") },
                AuthenticationExpiresOn = replacementExpiresOn,
            });
            var (binding, _) = CreateBinding(out var capturedOptions, CreateValidTokenValidator(originalExpiresOn), configurer.Object);
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
            Assert.Equal(
                new[] { ("asrs.s.uid", "replacement-user"), ("replacement", "claim"), ("ASRS.S.UID", "other-user") },
                capturedOptions.Value.Claims.Select(c => (c.Type, c.Value)));
        }

        [Fact]
        public async Task BuildAsync_ConfigurerReturnsNull_RetainsOriginalClaimsAndExpiration()
        {
            var originalExpiresOn = new DateTimeOffset(2030, 1, 2, 3, 4, 5, TimeSpan.Zero);
            var configurer = new Mock<ISignalRConnectionInfoConfigurer>();
            configurer.SetupGet(c => c.Configure).Returns((_, _, _) => null);
            var (binding, _) = CreateBinding(out var capturedOptions, CreateValidTokenValidator(originalExpiresOn), configurer.Object);
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
        [InlineData("asrs.s.uid", false)]
        [InlineData("ASRS.S.UID", false)]
        [InlineData("asrs.s.uid", true)]
        [InlineData("ASRS.S.UID", true)]
        public async Task BuildAsync_SuppliedUserIdClaimWithoutExplicitUserId_ForwardsClaimsUnchanged(string claimType, bool hasApplicationClaims)
        {
            var configurer = new Mock<ISignalRConnectionInfoConfigurer>();
            configurer.SetupGet(c => c.Configure).Returns((_, _, detail) =>
            {
                detail.Claims = new List<Claim> { new Claim(claimType, "other-user") };
                if (hasApplicationClaims)
                {
                    detail.Claims.Add(new Claim("role", "reader"));
                }
                return detail;
            });
            var (binding, _) = CreateBinding(out var capturedOptions, CreateValidTokenValidator(), configurer.Object);
            var attr = new SignalRRefreshAttribute { ConnectionToken = "ct", HubName = HubName, ConnectionStringSetting = ConnectionStringSetting };
            var bindingData = new Dictionary<string, object> { [HttpRequestName] = new DefaultHttpContext().Request };

            var provider = await binding.InvokeBuildAsync(attr, bindingData);

            Assert.IsType<SignalRConnectionInfo>(await provider.GetValueAsync());
            var expectedClaims = hasApplicationClaims
                ? new[] { (claimType, "other-user"), ("role", "reader") }
                : new[] { (claimType, "other-user") };
            Assert.Equal(expectedClaims, capturedOptions.Value.Claims.Select(c => (c.Type, c.Value)));
        }

        [Theory]
        [InlineData(false, false)]
        [InlineData(false, true)]
        [InlineData(true, false)]
        [InlineData(true, true)]
        public async Task BuildAsync_NoApplicationClaims_UsesUserIdToSelectClearOrPreserve(bool hasUserId, bool configureEmptyClaims)
        {
            var expectedExpiresOn = new DateTimeOffset(2030, 1, 2, 3, 4, 5, TimeSpan.Zero);
            var configurer = new Mock<ISignalRConnectionInfoConfigurer>();
            configurer.SetupGet(c => c.Configure).Returns((_, _, detail) =>
            {
                detail.Claims = new List<Claim>();
                return detail;
            });
            var (binding, hubContext) = CreateBinding(out var capturedOptions, CreateValidTokenValidator(expectedExpiresOn), configureEmptyClaims ? configurer.Object : null);
            const string userId = "original-user";
            var attr = new SignalRRefreshAttribute { ConnectionToken = "ct", HubName = HubName, ConnectionStringSetting = ConnectionStringSetting, UserId = hasUserId ? userId : null };
            var bindingData = new Dictionary<string, object> { [HttpRequestName] = new DefaultHttpContext().Request };

            await binding.InvokeBuildAsync(attr, bindingData);

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
            var (binding, hubContext) = CreateBinding(out var capturedOptions, CreateValidTokenValidator());
            var attr = new SignalRRefreshAttribute { ConnectionToken = "ct", HubName = HubName, ConnectionStringSetting = ConnectionStringSetting, TokenLifetimeSeconds = lifetime };
            var bindingData = new Dictionary<string, object> { [HttpRequestName] = new DefaultHttpContext().Request };

            await binding.InvokeBuildAsync(attr, bindingData);

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
            var configurer = new Mock<ISignalRConnectionInfoConfigurer>();
            configurer.SetupGet(c => c.Configure).Returns((_, _, _) => throw failure);
            var (binding, hubContext) = CreateBinding(out _, CreateValidTokenValidator(), configurer.Object);
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

        private static ISecurityTokenValidator CreateValidTokenValidator(DateTimeOffset? expiresOn = null)
        {
            var validator = new Mock<ISecurityTokenValidator>();
            validator.Setup(v => v.ValidateToken(It.IsAny<HttpRequest>()))
                .Returns(SecurityTokenResult.Success(new ClaimsPrincipal(new ClaimsIdentity()), expiresOn));
            return validator.Object;
        }

        private static (TestableRefreshBinding Binding, Mock<ServiceHubContext> HubContext) CreateBinding(
            out StrongBox<RefreshConnectionAuthenticationOptions> capturedOptions,
            ISecurityTokenValidator validator = null,
            ISignalRConnectionInfoConfigurer configurer = null,
            bool useResultParameter = false,
            ParameterInfo parameter = null)
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

            var method = useResultParameter ? nameof(ParameterHolder.ResultMethod) : nameof(ParameterHolder.Method);
            parameter ??= typeof(ParameterHolder).GetMethod(method).GetParameters()[0];
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
