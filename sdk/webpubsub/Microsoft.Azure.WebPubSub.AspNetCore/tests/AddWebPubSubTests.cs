// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#if NETCOREAPP
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace Microsoft.Azure.WebPubSub.AspNetCore.Tests
{
    [TestFixture]
    public class AddWebPubSubTests
    {
        [Test]
        public void TestWebPubSubConfigureNormal()
        {
            var testHost = "webpubsub.azure.net";
            var services = new ServiceCollection();
            var serviceProvider = services
                .AddWebPubSub(o => o.ServiceEndpoint = new ServiceEndpoint($"Endpoint=https://{testHost};AccessKey=7aab239577fd4f24bc919802fb629f5f;Version=1.0;"))
                .AddWebPubSubServiceClient<TestHub>()
                .Services.BuildServiceProvider();
            var validator = serviceProvider.GetRequiredService<RequestValidator>();

            Assert.NotNull(validator);
            Assert.True(validator.IsValidOrigin(new List<string> { testHost }));

            var serviceClient = serviceProvider.GetRequiredService<WebPubSubServiceClient<TestHub>>();
            Assert.NotNull(serviceClient);
        }

        [Test]
        public void TestWebPubSubConfigureEmptyOptions()
        {
            var services = new ServiceCollection();
            var serviceProvider = services
                .AddWebPubSub()
                .Services.BuildServiceProvider();
            var wpsOptions = serviceProvider.GetRequiredService<IOptions<WebPubSubOptions>>();

            // no throws
            Assert.NotNull(wpsOptions);
            Assert.NotNull(wpsOptions.Value);
            Assert.Null(wpsOptions.Value.ServiceEndpoint);
        }

        [Test]
        public void TestWebPubSubConfigureEmptyOptionsAndAddHubThrows()
        {
            var serviceProvider = new ServiceCollection()
                .AddWebPubSub()
                .AddWebPubSubServiceClient<TestHub>()
                .Services
                .BuildServiceProvider();
            var clientFactory = serviceProvider.GetRequiredService<WebPubSubServiceClientFactory>();

            Assert.NotNull(clientFactory);
            Assert.Throws<ArgumentException>(() => clientFactory.Create<TestHub>());
        }

        private sealed class TestHub : WebPubSubHub
        { }

        private sealed class TestHubWithService : WebPubSubHub
        {
            public TestHubWithService(WebPubSubServiceClient<TestHubWithService> service)
            {
            }
        }
    }
}
#endif