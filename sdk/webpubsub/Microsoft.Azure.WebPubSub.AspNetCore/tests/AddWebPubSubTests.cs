// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#if NETCOREAPP
using Microsoft.AspNetCore.Builder;
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
                .AddWebPubSub(o => o.ServiceEndpoint = new WebPubSubServiceEndpoint($"Endpoint=https://{testHost};AccessKey=7aab239577fd4f24bc919802fb629f5f;Version=1.0;"))
                .AddWebPubSubServiceClient<TestHub>()
                .BuildServiceProvider();
            var validator = serviceProvider.GetRequiredService<RequestValidator>();

            Assert.That(validator, Is.Not.Null);
            Assert.That(validator.IsValidOrigin(new List<string> { testHost }), Is.True);

            var serviceClient = serviceProvider.GetRequiredService<WebPubSubServiceClient<TestHub>>();
            Assert.That(serviceClient, Is.Not.Null);
        }

        [Test]
        public void TestWebPubSubConfigureEmptyOptions()
        {
            var services = new ServiceCollection();
            var serviceProvider = services
                .AddWebPubSub()
                .BuildServiceProvider();
            var wpsOptions = serviceProvider.GetRequiredService<IOptions<WebPubSubOptions>>();

            // no throws
            Assert.That(wpsOptions, Is.Not.Null);
            Assert.That(wpsOptions.Value, Is.Not.Null);
            Assert.That(wpsOptions.Value.ServiceEndpoint, Is.Null);
        }

        [Test]
        public void TestWebPubSubConfigureEmptyOptionsAndAddHubThrows()
        {
            var serviceProvider = new ServiceCollection()
                .AddWebPubSub()
                .AddWebPubSubServiceClient<TestHub>()
                .BuildServiceProvider();
            var clientFactory = serviceProvider.GetRequiredService<WebPubSubServiceClientFactory>();

            Assert.That(clientFactory, Is.Not.Null);
            Assert.Throws<ArgumentException>(() => clientFactory.Create<TestHub>());
        }

        [Test]
        public void TestMapWebPubSubHubConfigureNormal()
        {
            var testHost = "webpubsub.azure.net";
            WebApplicationBuilder builder = WebApplication.CreateBuilder();
            builder.Services
             .AddWebPubSub(o => o.ServiceEndpoint = new WebPubSubServiceEndpoint($"Endpoint=https://{testHost};AccessKey=7aab239577fd4f24bc919802fb629f5f;Version=1.0;"));

            using var app = builder.Build();
            app.MapWebPubSubHub<TestHub>("/testhub");

            var validator = app.Services.GetRequiredService<RequestValidator>();

            Assert.That(validator, Is.Not.Null);
            Assert.That(validator.IsValidOrigin(new List<string> { testHost }), Is.True);
        }

        [Test]
        public void TestMapWebPubSubHubConfigureCustomHub()
        {
            var testHost = "webpubsub.azure.net";
            var customHub = "customhub";
            WebApplicationBuilder builder = WebApplication.CreateBuilder();
            builder.Services
             .AddWebPubSub(o => o.ServiceEndpoint = new WebPubSubServiceEndpoint($"Endpoint=https://{testHost};AccessKey=7aab239577fd4f24bc919802fb629f5f;Version=1.0;"));

            using var app = builder.Build();
            app.MapWebPubSubHub<TestHub>("/testhub", customHub);

            var validator = app.Services.GetRequiredService<RequestValidator>();
            var adaptor = app.Services.GetRequiredService<ServiceRequestHandlerAdapter>();

            Assert.That(validator, Is.Not.Null);
            Assert.That(adaptor, Is.Not.Null);
            Assert.That(validator.IsValidOrigin(new List<string> { testHost }), Is.True);
            Assert.That(adaptor.GetHub(customHub), Is.Not.Null, "Custom hub should be registered");
        }

        [Test]
        public void TestMapWebPubSubHubConfigureHubByTypeName()
        {
            var testHost = "webpubsub.azure.net";
            WebApplicationBuilder builder = WebApplication.CreateBuilder();
            builder.Services
             .AddWebPubSub(o => o.ServiceEndpoint = new WebPubSubServiceEndpoint($"Endpoint=https://{testHost};AccessKey=7aab239577fd4f24bc919802fb629f5f;Version=1.0;"));

            using var app = builder.Build();
            app.MapWebPubSubHub<TestHub>("/testhub");

            var validator = app.Services.GetRequiredService<RequestValidator>();
            var adaptor = app.Services.GetRequiredService<ServiceRequestHandlerAdapter>();

            Assert.That(validator, Is.Not.Null);
            Assert.That(adaptor, Is.Not.Null);
            Assert.That(validator.IsValidOrigin(new List<string> { testHost }), Is.True);
            Assert.That(adaptor.GetHub(nameof(TestHub)), Is.Not.Null, "Hub with the name that matches the class name should be registered");
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