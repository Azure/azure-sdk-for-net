// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Connections;
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
    [Collection("SignalR input binding tests")]
    public class SignalRConnectionInputBindingTests
    {
        private const string HttpRequestName = "$request";
        private const string ConnectionStringSetting = Constants.AzureSignalRConnectionStringName;
        private const string HubName = "TestHub";
        private const string ConnectionString = "Endpoint=http://localhost;AccessKey=ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789;Version=1.0;";

        private static readonly string IdToken = new JwtSecurityTokenHandler().WriteToken(
            new JwtSecurityToken(claims: new[]
            {
                new Claim("name", "John Doe"),
                new Claim("iat", "1516239022"),
            }));

        private static class ParameterHolder
        {
            public static void Method([SignalRConnectionInfo(HubName = HubName)] SignalRConnectionInfo info)
            {
            }
        }

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public async Task BuildAsync_ExplicitDeadline_ForwardsDeadlineWithOrWithoutValidator(bool useValidator)
        {
            var (binding, capturedOptions) = CreateBinding(null, useValidator);
            var attr = new SignalRConnectionInfoAttribute
            {
                HubName = HubName,
                ConnectionStringSetting = ConnectionStringSetting,
                CloseOnAuthenticationExpiration = true,
                AuthenticationExpiresOn = "2030-01-02T03:04:05+02:00",
            };

            var provider = await binding.InvokeBuildAsync(attr, CreateBindingData());

            Assert.IsType<SignalRConnectionInfo>(await provider.GetValueAsync());
            Assert.Equal(new DateTimeOffset(2030, 1, 2, 1, 4, 5, TimeSpan.Zero), capturedOptions.Value.AuthenticationExpiresOn);
        }

        [Fact]
        public async Task BuildAsync_ConfigurerReturnsReplacement_UsesReplacementUserClaimsAndExpiration()
        {
            var originalExpiresOn = new DateTimeOffset(2030, 1, 2, 3, 4, 5, TimeSpan.Zero);
            var replacementExpiresOn = originalExpiresOn.AddHours(1);
            var replacement = new SignalRConnectionDetail
            {
                UserId = "replacement-user",
                Claims = new List<Claim> { new Claim("replacement", "claim") },
                AuthenticationExpiresOn = replacementExpiresOn,
            };
            var configurer = new Mock<ISignalRConnectionInfoConfigurer>();
            configurer.SetupGet(c => c.Configure).Returns((_, _, _) => replacement);
            var (binding, capturedOptions) = CreateBinding(configurer.Object);
            var attr = new SignalRConnectionInfoAttribute
            {
                AuthenticationExpiresOn = originalExpiresOn.ToString("O"),
                HubName = HubName,
                ConnectionStringSetting = ConnectionStringSetting,
                UserId = "original-user",
                IdToken = IdToken,
                ClaimTypeList = new[] { "name" },
            };

            var provider = await binding.InvokeBuildAsync(attr, CreateBindingData());
            var value = await provider.GetValueAsync();

            var info = Assert.IsType<SignalRConnectionInfo>(value);
            Assert.Equal("access-token", info.AccessToken);
            Assert.Equal("replacement-user", capturedOptions.Value.UserId);
            Assert.Equal(replacementExpiresOn, capturedOptions.Value.AuthenticationExpiresOn);
            var claim = Assert.Single(capturedOptions.Value.Claims);
            Assert.Equal("replacement", claim.Type);
            Assert.Equal("claim", claim.Value);
        }

        [Fact]
        public async Task BuildAsync_NoDeadlineAndConfigurerReturnsNull_RetainsUserClaims()
        {
            var configurer = new Mock<ISignalRConnectionInfoConfigurer>();
            configurer.SetupGet(c => c.Configure).Returns((_, _, _) => null);
            var (binding, capturedOptions) = CreateBinding(configurer.Object);
            var attr = new SignalRConnectionInfoAttribute
            {
                HubName = HubName,
                ConnectionStringSetting = ConnectionStringSetting,
                UserId = "original-user",
                IdToken = IdToken,
                ClaimTypeList = new[] { "name" },
            };

            var provider = await binding.InvokeBuildAsync(attr, CreateBindingData());
            var value = await provider.GetValueAsync();

            Assert.IsType<SignalRConnectionInfo>(value);
            Assert.Equal("original-user", capturedOptions.Value.UserId);
            Assert.Null(capturedOptions.Value.AuthenticationExpiresOn);
            var claim = Assert.Single(capturedOptions.Value.Claims);
            Assert.Equal("name", claim.Type);
            Assert.Equal("John Doe", claim.Value);
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
            var (binding, capturedOptions) = CreateBinding(configurer.Object);
            var attr = new SignalRConnectionInfoAttribute { HubName = HubName, ConnectionStringSetting = ConnectionStringSetting };

            if (rejectsIdentity)
            {
                var provider = await binding.InvokeBuildAsync(attr, CreateBindingData());
                Assert.Null(await provider.GetValueAsync());
            }
            else
            {
                Assert.Same(failure, await Assert.ThrowsAsync<InvalidOperationException>(() => binding.InvokeBuildAsync(attr, CreateBindingData())));
            }

            Assert.Null(capturedOptions.Value);
        }

        private static (TestableConnectionBinding Binding, StrongBox<NegotiationOptions> CapturedOptions) CreateBinding(
            ISignalRConnectionInfoConfigurer configurer,
            bool useValidator = true)
        {
            var capturedOptions = new StrongBox<NegotiationOptions>();
            var hubContext = new Mock<ServiceHubContext>(MockBehavior.Strict);
            hubContext
                .Setup(c => c.NegotiateAsync(It.IsAny<NegotiationOptions>(), It.IsAny<CancellationToken>()))
                .Callback<NegotiationOptions, CancellationToken>((options, _) => capturedOptions.Value = options)
                .Returns(new ValueTask<NegotiationResponse>(new NegotiationResponse
                {
                    Url = "https://example.test/client",
                    AccessToken = "access-token",
                }));
            StaticServiceHubContextStore.ServiceManagerStore = Mock.Of<IServiceManagerStore>(s =>
                s.GetOrAddByConnectionStringKey(It.IsAny<string>()).GetAsync(It.IsAny<string>())
                    == new ValueTask<IServiceHubContext>(hubContext.Object));
            var configuration = new ConfigurationBuilder()
                .AddInMemoryCollection(new Dictionary<string, string> { [ConnectionStringSetting] = ConnectionString })
                .Build();
            var parameter = typeof(ParameterHolder).GetMethod(nameof(ParameterHolder.Method)).GetParameters()[0];
            var context = new BindingProviderContext(parameter, new Dictionary<string, Type>(), CancellationToken.None);
            var validator = new Mock<ISecurityTokenValidator>();
            validator.Setup(v => v.ValidateToken(It.IsAny<HttpRequest>()))
                .Returns(SecurityTokenResult.Success(new ClaimsPrincipal(new ClaimsIdentity())));

            return (new TestableConnectionBinding(context, configuration, Mock.Of<INameResolver>(), useValidator ? validator.Object : null, configurer), capturedOptions);
        }

        private static IReadOnlyDictionary<string, object> CreateBindingData() =>
            new Dictionary<string, object> { [HttpRequestName] = new DefaultHttpContext().Request };

        private sealed class StrongBox<T>
        {
            public T Value { get; set; }
        }

        private sealed class TestableConnectionBinding : SignalRConnectionInputBinding
        {
            public TestableConnectionBinding(
                BindingProviderContext context,
                IConfiguration configuration,
                INameResolver nameResolver,
                ISecurityTokenValidator securityTokenValidator,
                ISignalRConnectionInfoConfigurer signalRConnectionInfoConfigurer)
                : base(context, configuration, nameResolver, securityTokenValidator, signalRConnectionInfoConfigurer)
            {
            }

            public Task<IValueProvider> InvokeBuildAsync(SignalRConnectionInfoAttribute attr, IReadOnlyDictionary<string, object> bindingData) =>
                BuildAsync(attr, bindingData, CancellationToken.None);
        }
    }
}