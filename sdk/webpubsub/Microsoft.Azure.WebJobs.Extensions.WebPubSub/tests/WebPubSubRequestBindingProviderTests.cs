// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs.Host.Bindings;
using Microsoft.Azure.WebPubSub.Common;
using Microsoft.Extensions.Configuration;
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
            var options = new WebPubSubFunctionsOptions();
            _provider = new WebPubSubContextBindingProvider(mockResolver.Object, _configuration, options);
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

        public static void TestFunc(
            [WebPubSubContext] WebPubSubContext request)
        {
            Console.WriteLine(request.HasError);
        }
    }
}
