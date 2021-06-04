﻿// Copyright (c) Microsoft Corporation. All rights reserved.
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
            TimeSpan? networkOverride = default;

            var mockTransport = MockTransport.FromMessageCallback(message =>
            {
                Assert.True(message.Request.Headers.TryGetValue("prefer", out preferHeader));
                networkOverride = message.NetworkTimeout;

                return new MockResponse(500);
            });

            var client = new LogsQueryClient(new Uri("https://api.loganalytics.io"), new MockCredential(), new LogsQueryClientOptions()
            {
                Transport = mockTransport
            });

            Assert.ThrowsAsync<RequestFailedException>(() => client.QueryAsync("wid", "tid", TimeSpan.FromDays(1), options: new LogsQueryOptions()
            {
                ServerTimeout = TimeSpan.FromMinutes(10)
            }));

            Assert.AreEqual("wait=600", preferHeader);
            Assert.AreEqual(TimeSpan.FromMinutes(10), networkOverride);
        }
    }
}