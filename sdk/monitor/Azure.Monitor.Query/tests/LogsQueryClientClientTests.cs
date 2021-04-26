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
            object networkOverride = default;

            var mockTransport = MockTransport.FromMessageCallback(message =>
            {
                Assert.True(message.Request.Headers.TryGetValue("prefer", out preferHeader));
                Assert.True(message.TryGetProperty("NetworkTimeoutOverride", out networkOverride));

                return new MockResponse(500);
            });

            var client = new LogsClient(new MockCredential(), new LogsClientOptions()
            {
                Transport = mockTransport
            });

            Assert.ThrowsAsync<RequestFailedException>(() => client.QueryAsync("wid", "tid", options: new LogsQueryOptions()
            {
                Timeout = TimeSpan.FromMinutes(10)
            }));

            Assert.AreEqual("wait=600", preferHeader);
            Assert.AreEqual(TimeSpan.FromMinutes(10), networkOverride);
        }
    }
}