// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs.Host.Triggers;
using Microsoft.Azure.WebPubSub.Common;
using Microsoft.Extensions.Configuration;
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
            var config = new WebPubSubFunctionsOptions();
            _provider = new WebPubSubTriggerBindingProvider(mockDispater.Object, resolver, config, null);
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

        public static void TestFunc(
            [WebPubSubTrigger("%testhub%", WebPubSubEventType.System, "testevent")]WebPubSubConnectionContext context)
        {
        }
    }
}
