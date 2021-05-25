// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.Monitor.Query.Tests
{
    public class LogsQueryClientClientTests
    {
        [Test]
        public void CanSetServiceTimeout_Mocked()
        {
            string preferHeader = null;
            // TODO: https://github.com/Azure/azure-sdk-for-net/issues/20859
            // TimeSpan? networkOverride = default;

            var mockTransport = MockTransport.FromMessageCallback(message =>
            {
                Assert.True(message.Request.Headers.TryGetValue("prefer", out preferHeader));
                // TODO: https://github.com/Azure/azure-sdk-for-net/issues/20859
                //networkOverride = message.NetworkTimeout;

                return new MockResponse(500);
            });

            var client = new LogsClient(new Uri("https://api.loganalytics.io"), new MockCredential(), new LogsClientOptions()
            {
                Transport = mockTransport
            });

            Assert.ThrowsAsync<RequestFailedException>(() => client.QueryAsync("wid", "tid", TimeSpan.FromDays(1), options: new LogsQueryOptions()
            {
                Timeout = TimeSpan.FromMinutes(10)
            }));

            Assert.AreEqual("wait=600", preferHeader);
            // TODO: https://github.com/Azure/azure-sdk-for-net/issues/20859
            //Assert.AreEqual(TimeSpan.FromMinutes(10), networkOverride);
        }
    }
}