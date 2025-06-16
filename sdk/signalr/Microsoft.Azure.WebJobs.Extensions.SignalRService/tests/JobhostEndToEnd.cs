// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net.Http;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure.SignalR.Common;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.SignalRService;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Azure.WebJobs.Host.Config;
using Microsoft.Extensions.Azure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Moq;
using SignalRServiceExtension.Tests.Utils;
using SignalRServiceExtension.Tests.Utils.Loggings;
using Xunit;
using Xunit.Abstractions;

namespace SignalRServiceExtension.Tests
{
    public class JobhostEndToEnd
    {
        private const string AttrConnStrConfigKey = "AttributeConnectionStringName";
        private const string DefaultUserId = "UserId";
        private const string DefaultHubName = "TestHub";
        private const string DefaultEndpoint = "http://localhostMakeSureNotOneUsedXXXXX";
        private const string DefaultAccessKey = "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA";
        private const string DefaultAttributeAccessKey = "BBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBB";
        private const string DefaultConnectionStringFormat = "Endpoint={0};AccessKey={1};Version=1.0;";
        private static readonly string DefaultConnectionString = string.Format(DefaultConnectionStringFormat, DefaultEndpoint, DefaultAccessKey);
        private static readonly string DefaultAttributeConnectionString = string.Format(DefaultConnectionStringFormat, DefaultEndpoint, DefaultAttributeAccessKey);
        private static Dictionary<string, string> _curConfigDict;
        private readonly ITestOutputHelper _output;

        public static Dictionary<string, string> ConnStrInsideOfAttrConfigDict = new Dictionary<string, string>
        {
            [AttrConnStrConfigKey] = DefaultAttributeConnectionString,
        };

        public static Dictionary<string, string> ConnStrOutsideOfAttrConfigDict = new Dictionary<string, string>
        {
            [Constants.AzureSignalRConnectionStringName] = DefaultConnectionString,
        };

        public static Dictionary<string, string> DiffConfigKeySameConnStrConfigDict = new Dictionary<string, string>
        {
            [AttrConnStrConfigKey] = DefaultConnectionString,
            [Constants.AzureSignalRConnectionStringName] = DefaultConnectionString
        };

        public static Dictionary<string, string> DiffConfigKeyDiffConnStrConfigDict = new Dictionary<string, string>
        {
            [AttrConnStrConfigKey] = DefaultAttributeConnectionString,
            [Constants.AzureSignalRConnectionStringName] = DefaultConnectionString
        };

        public static Dictionary<string, string> MultiConnStrOutsideOfAttrConfigDict = new Dictionary<string, string>
        {
            [AttrConnStrConfigKey] = DefaultAttributeConnectionString,
            [AttrConnStrConfigKey + ":a"] = DefaultAttributeConnectionString,
            [AttrConnStrConfigKey + ":b:primary"] = DefaultAttributeConnectionString
        };

        public static Dictionary<string, string>[] TestConfigDicts = {
            ConnStrInsideOfAttrConfigDict,
            ConnStrOutsideOfAttrConfigDict,
            DiffConfigKeySameConnStrConfigDict,
            DiffConfigKeyDiffConnStrConfigDict,
            DiffConfigKeyDiffConnStrConfigDict,
            MultiConnStrOutsideOfAttrConfigDict
        };

        public static Type[] TestClassTypesForSignalRAttribute =
        {
            typeof(SignalRFunctionsWithCustomizedKey),
            typeof(SignalRFunctions),
            typeof(SignalRFunctionsWithCustomizedKey),
            typeof(SignalRFunctionsWithCustomizedKey),
            typeof(SignalRFunctionsWithMultiKeys),
            typeof(SignalRFunctionsWithCustomizedKey),
        };

        public static Type[] TestClassTypesForSignalRConnectionInfoAttribute =
        {
            typeof(SignalRConnectionInfoFunctionsWithCustomizedKey),
            typeof(SignalRConnectionInfoFunctions),
            typeof(SignalRConnectionInfoFunctionsWithCustomizedKey),
            typeof(SignalRConnectionInfoFunctionsWithCustomizedKey),
            typeof(SignalRConnectionInfoFunctionsWithMultiKeys),
            typeof(SignalRConnectionInfoFunctionsWithCustomizedKey),
        };

        public static IEnumerable<object[]> SignalRAttributeTestData => GenerateTestData(TestClassTypesForSignalRAttribute, TestConfigDicts);

        public static IEnumerable<object[]> SignalRConnectionInfoAttributeTestData => GenerateTestData(TestClassTypesForSignalRConnectionInfoAttribute, TestConfigDicts);

        public JobhostEndToEnd(ITestOutputHelper output)
        {
            _output = output;
        }

        [Theory]
        [MemberData(nameof(SignalRAttributeTestData))]
        [MemberData(nameof(SignalRConnectionInfoAttributeTestData))]
        public async Task ConnectionStringSettingFacts(Type classType, Dictionary<string, string> configDict)
        {
            _curConfigDict = configDict;
            await CreateTestTask(classType, configDict);
        }

        [Fact]
        public async Task SignalRAttribute_MissingConnectionStringSettingFacts()
        {
            var task = CreateTestTask(typeof(SignalRFunctions), null);
            var exception = await Assert.ThrowsAsync<FunctionInvocationException>(() => task);
            Assert.IsType<InvalidOperationException>(exception.GetBaseException());
        }

        [Fact]
        public async Task SignalRConnectionInfoAttribute_MissingConnectionStringSettingFacts()
        {
            var task = CreateTestTask(typeof(SignalRConnectionInfoFunctions), null);
            var exception = await Assert.ThrowsAsync<FunctionInvocationException>(() => task);
            Assert.IsType<InvalidOperationException>(exception.GetBaseException());
        }

        [Fact]
        [Obsolete]
        public void WebhookProviderThrowExceptionTest()
        {
            var builder = new HostBuilder();
            builder.ConfigureWebJobs(b =>
            {
                b.AddSignalR().Services.AddAzureClientsCore();
            });
            var host = builder.Build();
            using (host)
            {
                var configProvider = host.Services.GetRequiredService<IExtensionConfigProvider>();
                var configuration = host.Services.GetRequiredService<IConfiguration>();
                var nameResolver = host.Services.GetRequiredService<INameResolver>();
                var converterManager = host.Services.GetRequiredService<IConverterManager>();
                var webHookProviderMock = new Mock<IWebHookProvider>();
                webHookProviderMock.Setup(w => w.GetUrl(It.IsAny<IExtensionConfigProvider>())).Returns(() =>
                {
                    throw new Exception(null);
                });
                IExtensionRegistry registry = new DefaultExtensionRegistry();
                var context = new ExtensionConfigContext(configuration, nameResolver, converterManager, webHookProviderMock.Object, registry);

                // Assert no exceptions
                configProvider.Initialize(context);
            }
        }

        public static IEnumerable<object[]> GenerateTestData(Type[] classType, Dictionary<string, string>[] configDicts)
        {
            if (classType.Length != configDicts.Length)
            {
                throw new ArgumentException($"Length of {nameof(classType)} and {nameof(configDicts)}  are not the same.");
            }
            for (var i = 0; i < classType.Length; i++)
            {
                yield return new object[] { classType[i], configDicts[i] };
            }
        }

        private static void UpdateFunctionOutConnectionString(SignalRConnectionInfo connectionInfo, string expectedConfigurationKey)
        {
            var handler = new JwtSecurityTokenHandler();
            var accessKeys = new List<string> { DefaultAccessKey, DefaultAttributeAccessKey };
            var validationParameters = new TokenValidationParameters
            {
                ValidateIssuer = false,
                ValidateAudience = false,
                IssuerSigningKeyResolver = (token, securityToken, kid, validationParas) => from key in accessKeys
                                                                                           select new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key))
            };
            handler.ValidateToken(connectionInfo.AccessToken, validationParameters, out var validatedToken);
            var validatedAccessKey = Encoding.UTF8.GetString((validatedToken.SigningKey as SymmetricSecurityKey)?.Key);
            var actualConnectionString = string.Format(DefaultConnectionStringFormat, DefaultEndpoint, validatedAccessKey);
            Assert.Equal(_curConfigDict[expectedConfigurationKey], actualConnectionString);
        }

        private static async Task SimulateSendingMessage(IAsyncCollector<SignalRMessage> signalRMessages)
        {
            try
            {
                await signalRMessages.AddAsync(
                    new SignalRMessage
                    {
                        UserId = DefaultUserId,
                        GroupName = "",
                        Target = "newMessage",
                        Arguments = new[] { "message" }
                    });
            }
            catch (AzureSignalRException ex) when (ex.InnerException is HttpRequestException)
            {
                // ignore, since we don't really connect to Azure SignalR Service
            }
            catch
            {
                throw;
            }
        }

        private Task CreateTestTask(Type classType, Dictionary<string, string> configuration)
        {
            var host = TestHelpers.NewHost(classType, configuration: configuration, loggerProvider: new XunitLoggerProvider(_output));
            return Task.WhenAll(from method in classType.GetMethods(BindingFlags.DeclaredOnly | BindingFlags.Public | BindingFlags.Instance)
                                select host.GetJobHost().CallAsync($"{classType.Name}.{method.Name}"));
        }

        #region SignalRAttributeTests

        public class SignalRFunctionsWithCustomizedKey
        {
            public async Task Func([SignalR(HubName = DefaultHubName, ConnectionStringSetting = AttrConnStrConfigKey)] IAsyncCollector<SignalRMessage> signalRMessages)
            {
                await SimulateSendingMessage(signalRMessages);
                Assert.NotNull(((ServiceManagerStore)StaticServiceHubContextStore.ServiceManagerStore).GetByConfigurationKey(AttrConnStrConfigKey));
            }
        }

        public class SignalRFunctions
        {
            public async Task Func([SignalR(HubName = DefaultHubName)] IAsyncCollector<SignalRMessage> signalRMessages)
            {
                await SimulateSendingMessage(signalRMessages);
                Assert.NotNull(((ServiceManagerStore)StaticServiceHubContextStore.ServiceManagerStore).GetByConfigurationKey(Constants.AzureSignalRConnectionStringName));
            }
        }

        public class SignalRFunctionsWithMultiKeys
        {
            public async Task Func1([SignalR(HubName = DefaultHubName, ConnectionStringSetting = Constants.AzureSignalRConnectionStringName)] IAsyncCollector<SignalRMessage> signalRMessages)
            {
                await SimulateSendingMessage(signalRMessages);
                Assert.NotNull(((ServiceManagerStore)StaticServiceHubContextStore.ServiceManagerStore).GetByConfigurationKey(Constants.AzureSignalRConnectionStringName));
            }

            public async Task Func2([SignalR(HubName = DefaultHubName, ConnectionStringSetting = AttrConnStrConfigKey)] IAsyncCollector<SignalRMessage> signalRMessages)
            {
                await SimulateSendingMessage(signalRMessages);
                Assert.NotNull(((ServiceManagerStore)StaticServiceHubContextStore.ServiceManagerStore).GetByConfigurationKey(AttrConnStrConfigKey));
            }
        }

        #endregion SignalRAttributeTests

        #region SignalRConnectionInfoAttributeTests

        public class SignalRConnectionInfoFunctionsWithCustomizedKey
        {
            public void Func([SignalRConnectionInfo(UserId = DefaultUserId, HubName = DefaultHubName, ConnectionStringSetting = AttrConnStrConfigKey)] SignalRConnectionInfo connectionInfo)
            {
                UpdateFunctionOutConnectionString(connectionInfo, AttrConnStrConfigKey);
            }
        }

        public class SignalRConnectionInfoFunctions
        {
            public void Func([SignalRConnectionInfo(UserId = DefaultUserId, HubName = DefaultHubName)] SignalRConnectionInfo connectionInfo)
            {
                UpdateFunctionOutConnectionString(connectionInfo, Constants.AzureSignalRConnectionStringName);
            }
        }

        public class SignalRConnectionInfoFunctionsWithMultiKeys
        {
            public void Func1([SignalRConnectionInfo(UserId = DefaultUserId, HubName = DefaultHubName, ConnectionStringSetting = Constants.AzureSignalRConnectionStringName)] SignalRConnectionInfo connectionInfo)
            {
                UpdateFunctionOutConnectionString(connectionInfo, Constants.AzureSignalRConnectionStringName);
            }

            public void Func2([SignalRConnectionInfo(UserId = DefaultUserId, HubName = DefaultHubName, ConnectionStringSetting = AttrConnStrConfigKey)] SignalRConnectionInfo connectionInfo)
            {
                UpdateFunctionOutConnectionString(connectionInfo, AttrConnStrConfigKey);
            }
        }

        #endregion SignalRConnectionInfoAttributeTests
    }
}