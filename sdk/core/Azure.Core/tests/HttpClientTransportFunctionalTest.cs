// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Security;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.Pipeline;
using Azure.Core.TestFramework;
using Microsoft.AspNetCore.Http;
using NUnit.Framework;

namespace Azure.Core.Tests
{
    [NonParallelizable]
    public class HttpClientTransportFunctionalTest : TransportFunctionalTests
    {
        private static RemoteCertificateValidationCallback certCallback = (_, _, _, _) => true;
        public HttpClientTransportFunctionalTest(bool isAsync) : base(isAsync)
        { }

        protected override HttpPipelineTransport GetTransport(bool https = false, HttpPipelineTransportOptions options = null)
        {
#if !NET462
            if (https)
            {
                return new HttpClientTransport(options ?? new HttpPipelineTransportOptions { ServerCertificateCustomValidationCallback = _ => true });
            }
#endif
            return new HttpClientTransport(options);
        }

#if NET462
        // These setup and teardown actions require that entire test class be NonParallelizable.
        [OneTimeSetUp]
        public void TestSetup()
        {
            // No way to disable SSL check per HttpClient on NET462
            ServicePointManager.ServerCertificateValidationCallback += certCallback;
        }

        [OneTimeTearDown]
        public void TestTeardown()
        {
            // No way to disable SSL check per HttpClient on NET462
            ServicePointManager.ServerCertificateValidationCallback -= certCallback;
        }
#endif

#if NETCOREAPP
        [Test]
        public void UsesSocketsClientTransportOnNetCoreApp()
        {
            var transport = (HttpClientTransport)GetTransport();
            HttpClient transportClient = transport.Client;
            var handler = (SocketsHttpHandler)GetHandler(transportClient);
            Assert.AreEqual(TimeSpan.FromSeconds(300), handler.PooledConnectionLifetime);
            Assert.GreaterOrEqual(handler.MaxConnectionsPerServer, 50);
        }
#else
        [Test]
        public void UsesHttpClientTransportOnNetStandart()
        {
            var transport = (HttpClientTransport)GetTransport();
            HttpClient transportClient = transport.Client;
            var handler = (HttpClientHandler)GetHandler(transportClient);
            Assert.AreEqual(50, handler.MaxConnectionsPerServer);
        }
#endif

        [Test]
        public void DisposeDisposesClient()
        {
            var transport = (HttpClientTransport)GetTransport(options:new HttpPipelineTransportOptions());
            transport.Dispose();
            Assert.Throws<ObjectDisposedException>(() => transport.Client.CancelPendingRequests());
        }

        [Test]
        public void DisposeDoesNotDisposesSharedPipeline()
        {
            var transport = HttpClientTransport.Shared;
            transport.Dispose();
            Assert.DoesNotThrow(() => transport.Client.CancelPendingRequests());
        }

        [Test]
        public async Task CookiesCanBeEnabledUsingSwitch()
        {
            using var appContextSwitch = new TestAppContextSwitch("Azure.Core.Pipeline.HttpClientTransport.EnableCookies", "true");

            await TestCookiesEnabled();
        }

        [Test]
        public async Task CookiesCanBeEnabledUsingEnvVar()
        {
            using var envVar = new TestEnvVar("AZURE_CORE_HTTPCLIENT_ENABLE_COOKIES", "true");

            await TestCookiesEnabled();
        }

        private async Task TestCookiesEnabled()
        {
            int requestCount = 0;
            using (TestServer testServer = new TestServer(
                async context =>
                {
                    if (requestCount++ == 1)
                    {
                        Assert.IsTrue(context.Request.Headers.ContainsKey("cookie"));
                        Assert.AreEqual("stsservicecookie=estsfd",
                            context.Request.Headers["cookie"].First());
                    }

                    context.Response.StatusCode = 200;
                    context.Response.Headers.Add(
                        "set-cookie",
                        "stsservicecookie=estsfd; path=/; secure; samesite=none; httponly");
                    await context.Response.WriteAsync("");
                },
                https: true))
            {
                var transport = GetTransport(https: true);
                Request request = transport.CreateRequest();
                request.Method = RequestMethod.Post;
                request.Uri.Reset(testServer.Address);
                request.Content = RequestContent.Create("Hello");
                await ExecuteRequest(request, transport);

                // create a second request to verify cookies not set
                request = transport.CreateRequest();
                request.Method = RequestMethod.Post;
                request.Uri.Reset(testServer.Address);
                request.Content = RequestContent.Create("Hello");
                await ExecuteRequest(request, transport);
            }
        }

        private static object GetHandler(HttpClient transportClient)
        {
            return typeof(HttpMessageInvoker).GetField("_handler", BindingFlags.Instance | BindingFlags.NonPublic).GetValue(transportClient);
        }
    }
}
