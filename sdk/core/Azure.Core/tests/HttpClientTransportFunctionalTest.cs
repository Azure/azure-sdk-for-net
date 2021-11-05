// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Net;
using System.Net.Http;
using System.Reflection;
using Azure.Core.Pipeline;
using NUnit.Framework;

namespace Azure.Core.Tests
{
    public class HttpClientTransportFunctionalTest : TransportFunctionalTests
    {
        static HttpClientTransportFunctionalTest()
        {
            // No way to disable SSL check per HttpClient on NET461
#if NET461
            ServicePointManager.ServerCertificateValidationCallback += (_, _, _, _) => true;
#endif
        }
        public HttpClientTransportFunctionalTest(bool isAsync) : base(isAsync)
        {
        }

        protected override HttpPipelineTransport GetTransport(bool https = false)
        {
            if (https)
            {
#if !NET461
                return new HttpClientTransport(new HttpClientHandler()
                {
                    ServerCertificateCustomValidationCallback = HttpClientHandler.DangerousAcceptAnyServerCertificateValidator
                });
#endif
            }
            return new HttpClientTransport();
        }

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

        private static object GetHandler(HttpClient transportClient)
        {
            return typeof(HttpMessageInvoker).GetField("_handler", BindingFlags.Instance | BindingFlags.NonPublic).GetValue(transportClient);
        }
    }
}