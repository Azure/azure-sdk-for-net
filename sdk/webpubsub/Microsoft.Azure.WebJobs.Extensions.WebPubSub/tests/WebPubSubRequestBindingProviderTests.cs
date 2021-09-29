// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs.Host.Bindings;
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
            Mock<INameResolver> mockResolver = new Mock<INameResolver>(MockBehavior.Strict);
            _provider = new WebPubSubContextBindingProvider(mockResolver.Object, _configuration);
        }

        [TestCase]
        public async Task TryCreateAsync()
        {
            var parameter = GetType().GetMethod("TestFunc").GetParameters()[0];
            var context = new BindingProviderContext(parameter, new Dictionary<string, Type>(), CancellationToken.None);

            var binding = await _provider.TryCreateAsync(context);

            Assert.NotNull(binding);
        }

        public static void TestFunc(
            [WebPubSubContext] WebPubSubContext request)
        {
        }
    }
}
