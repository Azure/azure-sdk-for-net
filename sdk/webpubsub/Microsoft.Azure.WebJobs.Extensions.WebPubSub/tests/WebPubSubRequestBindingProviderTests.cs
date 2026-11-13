// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs.Host.Bindings;
using Microsoft.Azure.WebPubSub.Common;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging.Abstractions;
using Moq;
using NUnit.Framework;

namespace Microsoft.Azure.WebJobs.Extensions.WebPubSub.Tests
{
    public class WebPubSubRequestBindingProviderTests
    {
        private readonly WebPubSubContextBindingProvider _provider;
        private readonly IConfiguration _configuration;

        public WebPubSubRequestBindingProviderTests()
        {
            _configuration = new ConfigurationBuilder()
                   .AddEnvironmentVariables()
                   .Build();
            var mockResolver = new Mock<INameResolver>(MockBehavior.Strict);
            var options = new WebPubSubServiceAccessOptions();
            var accessFactory = new WebPubSubServiceAccessFactory(_configuration, TestAzureComponentFactory.Instance);
            _provider = new WebPubSubContextBindingProvider(mockResolver.Object, _configuration, options, accessFactory, NullLogger.Instance);
        }

        [TestCase]
        public async Task TestInputBinding_ValidationRequest()
        {
            var parameter = GetType().GetMethod("TestFunc").GetParameters()[0];
            var context = new BindingProviderContext(parameter, new Dictionary<string, Type>(), CancellationToken.None);

            var binding = await _provider.TryCreateAsync(context);

            Assert.AreEqual(typeof(WebPubSubContextBinding), binding.GetType());

            var wpsBinding = binding as WebPubSubContextBinding;
            var functionContext = new FunctionBindingContext(Guid.NewGuid(), CancellationToken.None);
            var valueBindingContext = new ValueBindingContext(functionContext, CancellationToken.None);
            var bindingData = new Dictionary<string, object>
            {
                { "$request", TestHelpers.CreateHttpRequest("OPTIONS", "http://localhost/api/testfunc")},
            };
            var bindingContext = new BindingContext(valueBindingContext, bindingData);
            var result = await wpsBinding.BindAsync(bindingContext);

            Assert.AreEqual(typeof(WebPubSubContextValueProvider), result.GetType());

            var valueProvider = result as WebPubSubContextValueProvider;
            var value = await valueProvider.GetValueAsync();
            Assert.AreEqual(typeof(WebPubSubContext), value.GetType());

            var request = value as WebPubSubContext;
            Assert.AreEqual(typeof(PreflightRequest), request.Request.GetType());
            Assert.True((request.Request as PreflightRequest).IsValid);
        }

        [TestCase]
        public void ContextAttribute_LegacyConnection_NullOrEmpty_DoesNotPopulateConnections()
        {
#pragma warning disable CS0618 // Type or member is obsolete
            var attributeWithNull = new WebPubSubContextAttribute
            {
                Connection = null,
            };

            var attributeWithEmpty = new WebPubSubContextAttribute
            {
                Connection = string.Empty,
            };
#pragma warning restore CS0618 // Type or member is obsolete

            Assert.IsNull(attributeWithNull.Connections);
            Assert.IsNull(attributeWithEmpty.Connections);
        }

        [TestCase]
        public void ContextAttribute_LegacyConnection_WithValue_PopulatesConnections()
        {
            var attribute = new WebPubSubContextAttribute();

#pragma warning disable CS0618 // Type or member is obsolete
            attribute.Connection = "connectionA";
#pragma warning restore CS0618 // Type or member is obsolete

            Assert.NotNull(attribute.Connections);
            Assert.AreEqual(1, attribute.Connections.Length);
            Assert.AreEqual("connectionA", attribute.Connections[0]);
        }

        [TestCase]
        public void ContextAttribute_LegacyConnection_DoesNotOverrideConnections_WhenAlreadySet()
        {
            var attribute = new WebPubSubContextAttribute("connectionA", "connectionB");

#pragma warning disable CS0618 // Type or member is obsolete
            attribute.Connection = "connectionC";
#pragma warning restore CS0618 // Type or member is obsolete

            Assert.AreEqual(2, attribute.Connections.Length);
            Assert.AreEqual("connectionA", attribute.Connections[0]);
            Assert.AreEqual("connectionB", attribute.Connections[1]);
        }

        [TestCase]
        public void ContextAttribute_LegacyConnection_Getter_ReturnsFirstConnection()
        {
            var attribute = new WebPubSubContextAttribute("connectionA", "connectionB");

#pragma warning disable CS0618 // Type or member is obsolete
            Assert.AreEqual("connectionA", attribute.Connection);
#pragma warning restore CS0618 // Type or member is obsolete
        }

        public static void TestFunc(
            [WebPubSubContext] WebPubSubContext request)
        {
            Console.WriteLine(request.HasError);
        }
    }
}
