// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs.Extensions.WebPubSubForSocketIO.Trigger.Model;
using Microsoft.Azure.WebJobs.Host.Triggers;
using Microsoft.Azure.WebPubSub.Common;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;

namespace Microsoft.Azure.WebJobs.Extensions.WebPubSubForSocketIO.Tests
{
    public class SocketIOTriggerBindingProviderTests
    {
        private readonly WebPubSubForSocketIOTriggerBindingProvider _provider;
        private readonly IConfiguration _configuration;

        private const string TestHub = "test_hub";

        public static void TestMethod(
            [SocketIOTrigger("%testhub%", "testevent")] SocketIOConnectRequest req)
        {
        }

        public static void TestMethodWithParam(
            [SocketIOTrigger("%testhub%", "testevent")] SocketIOConnectRequest req,
            [SocketIOParameter] string param1,
            [SocketIOParameter] int param2,
            [SocketIOParameter] object param3,
            ILogger logger)
        {
        }

        public SocketIOTriggerBindingProviderTests()
        {
            _configuration = new ConfigurationBuilder()
                .AddEnvironmentVariables()
                .AddInMemoryCollection()
                .Build();
            _configuration["testhub"] = TestHub;
            var resolver = new DefaultNameResolver(_configuration);
            var mockDispater = new Mock<IWebPubSubForSocketIOTriggerDispatcher>(MockBehavior.Strict);
            var config = new SocketIOFunctionsOptions();
            _provider = new WebPubSubForSocketIOTriggerBindingProvider(mockDispater.Object, resolver, config, null);
        }

        [TestCase]
        public void ResolveTriggerAttributeTest()
        {
            var attribute = new SocketIOTriggerAttribute("%testhub%", "testevent", "/ns");
            var paramInfo = GetType().GetMethod(nameof(TestMethod)).GetParameters()[0];
            var resolvedAttr = _provider.GetResolvedAttribute(attribute, paramInfo);
            Assert.AreEqual(resolvedAttr.Hub, TestHub);
            Assert.AreEqual(resolvedAttr.EventName, "testevent");
            Assert.AreEqual("/ns", resolvedAttr.Namespace);
            Assert.IsEmpty(resolvedAttr.ParameterNames);
        }

        [TestCase]
        public void DefaultTriggerAttributeTest()
        {
            var attribute = new SocketIOTriggerAttribute("defaulthub", "testevent");
            var paramInfo = GetType().GetMethod(nameof(TestMethod)).GetParameters()[0];
            var resolvedAttr = _provider.GetResolvedAttribute(attribute, paramInfo);
            Assert.AreEqual(resolvedAttr.Hub, "defaulthub");
            Assert.AreEqual(resolvedAttr.EventName, "testevent");
            Assert.AreEqual("/", resolvedAttr.Namespace);
            Assert.IsEmpty(resolvedAttr.ParameterNames);
        }

        [TestCase]
        public void TriggerAttributeWithParameterNameTest()
        {
            var attribute = new SocketIOTriggerAttribute("defaulthub", "testevent", new[] {"param1", "param2"});
            var paramInfo = GetType().GetMethod(nameof(TestMethod)).GetParameters()[0];
            var resolvedAttr = _provider.GetResolvedAttribute(attribute, paramInfo);
            Assert.AreEqual(resolvedAttr.Hub, "defaulthub");
            Assert.AreEqual(resolvedAttr.EventName, "testevent");
            Assert.AreEqual("/", resolvedAttr.Namespace);
            Assert.AreEqual("param1", resolvedAttr.ParameterNames[0]);
            Assert.AreEqual("param2", resolvedAttr.ParameterNames[1]);
        }

        [TestCase]
        public void TriggerAttributeWithParameterNameAttributeTest()
        {
            var attribute = new SocketIOTriggerAttribute("defaulthub", "testevent");
            var paramInfo = GetType().GetMethod(nameof(TestMethodWithParam)).GetParameters()[0];
            var resolvedAttr = _provider.GetResolvedAttribute(attribute, paramInfo);
            Assert.AreEqual(resolvedAttr.Hub, "defaulthub");
            Assert.AreEqual(resolvedAttr.EventName, "testevent");
            Assert.AreEqual("/", resolvedAttr.Namespace);
            Assert.AreEqual(3, resolvedAttr.ParameterNames.Length);
            Assert.AreEqual("param1", resolvedAttr.ParameterNames[0]);
            Assert.AreEqual("param2", resolvedAttr.ParameterNames[1]);
            Assert.AreEqual("param3", resolvedAttr.ParameterNames[2]);
        }

        [TestCase]
        public void TriggerAttributeWithParameterNameAttributeShouldNotSetTest()
        {
            var attribute = new SocketIOTriggerAttribute("defaulthub", "testevent", new[] { "param1" });
            var paramInfo = GetType().GetMethod(nameof(TestMethodWithParam)).GetParameters()[0];
            Assert.Throws<ArgumentException>(() => _provider.GetResolvedAttribute(attribute, paramInfo),
                "SocketIOTriggerAttribute.ParameterNames and SocketIOParameterAttribute can not be set in the same Function.");
        }

        [TestCase]
        public void ResolveTriggerAttributeTest_NotConfigureThrows()
        {
            var attribute = new SocketIOTriggerAttribute("%nullhub%", "testevent");
            var paramInfo = GetType().GetMethod(nameof(TestMethod)).GetParameters()[0];
            Assert.Throws<ArgumentException>(() => _provider.GetResolvedAttribute(attribute, paramInfo),
                "Failed to resolve substitute configure: %nullhub%, please add.");
        }

        [TestCase]
        public async Task TestCreateAsyncTests()
        {
            var parameter = GetType().GetMethod("TestFunc").GetParameters()[0];
            var context = new TriggerBindingProviderContext(parameter, CancellationToken.None);
            var binding = await _provider.TryCreateAsync(context);

            Assert.NotNull(binding);
        }

        public static void TestFunc(
            [SocketIOTrigger("%testhub%", "testevent")]WebPubSubConnectionContext context)
        {
        }
    }
}
