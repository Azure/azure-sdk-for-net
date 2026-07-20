// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs.Host.Listeners;
using Microsoft.Azure.WebJobs.Host.Triggers;
using Microsoft.Azure.WebPubSub.Common;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging.Abstractions;
using Moq;
using NUnit.Framework;

namespace Microsoft.Azure.WebJobs.Extensions.WebPubSub.Tests
{
    public class WebPubSubTriggerBindingProviderTests
    {
        private readonly WebPubSubTriggerBindingProvider _provider;
        private readonly IConfiguration _configuration;

        private const string TestHub = "test_hub";

        public WebPubSubTriggerBindingProviderTests()
        {
            _configuration = new ConfigurationBuilder()
                .AddEnvironmentVariables()
                .AddInMemoryCollection()
                .Build();
            _configuration["testhub"] = TestHub;
            var resolver = new DefaultNameResolver(_configuration);
            var mockDispater = new Mock<IWebPubSubTriggerDispatcher>(MockBehavior.Strict);
            var options = new WebPubSubServiceAccessOptions();
            var accessFactory = new WebPubSubServiceAccessFactory(_configuration, TestAzureComponentFactory.Instance);
            _provider = new WebPubSubTriggerBindingProvider(mockDispater.Object, resolver, options, null, accessFactory, NullLogger.Instance);
        }

        [TestCase]
        public void ResolveTriggerAttributeTest()
        {
            var attribute = new WebPubSubTriggerAttribute("%testhub%", WebPubSubEventType.System, "testevent");
            var resolvedAttr = _provider.GetResolvedAttribute(attribute);
            Assert.AreEqual(resolvedAttr.Hub, TestHub);
            Assert.AreEqual(resolvedAttr.EventName, "testevent");
        }

        [TestCase]
        public void DefaultTriggerAttributeTest()
        {
            var attribute = new WebPubSubTriggerAttribute("defaulthub", WebPubSubEventType.System, "testevent");
            var resolvedAttr = _provider.GetResolvedAttribute(attribute);
            Assert.AreEqual(resolvedAttr.Hub, "defaulthub");
            Assert.AreEqual(resolvedAttr.EventName, "testevent");
        }

        [TestCase]
        public void ResolveTriggerAttributeTest_NotConfigureThrows()
        {
            var attribute = new WebPubSubTriggerAttribute("%nullhub%", WebPubSubEventType.System, "testevent");
            Assert.Throws<ArgumentException>(() => _provider.GetResolvedAttribute(attribute),
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

        [TestCase]
        public void TriggerAttribute_LegacyConnection_NullOrEmpty_DoesNotPopulateConnections()
        {
#pragma warning disable CS0618 // Type or member is obsolete
            var attributeWithNull = new WebPubSubTriggerAttribute("defaulthub", WebPubSubEventType.System, "testevent")
            {
                Connection = null,
            };

            var attributeWithEmpty = new WebPubSubTriggerAttribute("defaulthub", WebPubSubEventType.System, "testevent")
            {
                Connection = string.Empty,
            };
#pragma warning restore CS0618 // Type or member is obsolete

            Assert.IsNull(attributeWithNull.Connections);
            Assert.IsNull(attributeWithEmpty.Connections);
        }

        [TestCase]
        public void TriggerAttribute_LegacyConnection_WithValue_PopulatesConnections()
        {
            var attribute = new WebPubSubTriggerAttribute("defaulthub", WebPubSubEventType.System, "testevent");

#pragma warning disable CS0618 // Type or member is obsolete
            attribute.Connection = "connectionA";
#pragma warning restore CS0618 // Type or member is obsolete

            Assert.NotNull(attribute.Connections);
            Assert.AreEqual(1, attribute.Connections.Length);
            Assert.AreEqual("connectionA", attribute.Connections[0]);
        }

        [TestCase]
        public void TriggerAttribute_LegacyConnection_DoesNotOverrideConnections_WhenAlreadySet()
        {
            var attribute = new WebPubSubTriggerAttribute("defaulthub", WebPubSubEventType.System, "testevent", "connectionA", "connectionB");

#pragma warning disable CS0618 // Type or member is obsolete
            attribute.Connection = "connectionC";
#pragma warning restore CS0618 // Type or member is obsolete

            Assert.AreEqual(2, attribute.Connections.Length);
            Assert.AreEqual("connectionA", attribute.Connections[0]);
            Assert.AreEqual("connectionB", attribute.Connections[1]);
        }

        [TestCase]
        public void TriggerAttribute_LegacyConnection_Getter_ReturnsFirstConnection()
        {
            var attribute = new WebPubSubTriggerAttribute("defaulthub", WebPubSubEventType.System, "testevent", "connectionA", "connectionB");

#pragma warning disable CS0618 // Type or member is obsolete
            Assert.AreEqual("connectionA", attribute.Connection);
#pragma warning restore CS0618 // Type or member is obsolete
        }

        public static void TestFunc(
            [WebPubSubTrigger("%testhub%", WebPubSubEventType.System, "testevent")] WebPubSubConnectionContext context)
        {
        }
    }
}
