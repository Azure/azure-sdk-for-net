// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using Azure.Core.Pipeline;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.Core.Tests
{
    public class TelemetryPolicyTests : PolicyTestBase
    {
        [Test]
        public async Task IncludesComponentNameAndVersion()
        {
            var transport = new MockTransport(new MockResponse(200));
            var telemetryPolicy = new TelemetryPolicy("base-test", "1.0.0", null);

            await SendGetRequest(transport, telemetryPolicy);

            Assert.True(transport.SingleRequest.TryGetHeader("User-Agent", out var userAgent));
            Assert.AreEqual(userAgent, $"azsdk-net-base-test/1.0.0 ({RuntimeInformation.FrameworkDescription}; {RuntimeInformation.OSDescription})");
        }

        [Test]
        public async Task ApplicationIdIsIncluded()
        {
            var transport = new MockTransport(new MockResponse(200));
            var telemetryPolicy = new TelemetryPolicy("base-test", "1.0.0", "application-id");

            await SendGetRequest(transport, telemetryPolicy);

            Assert.True(transport.SingleRequest.TryGetHeader("User-Agent", out var userAgent));
            StringAssert.StartsWith("application-id ", userAgent);
        }

        [Test]
        public void ApplicationIdLimitedTo24Chars()
        {
            var options = new DiagnosticsOptions();
            Assert.Throws<ArgumentOutOfRangeException>(() => options.ApplicationId = "0123456789012345678912345");
        }

        private class TestOptions : ClientOptions
        {
        }
    }
}
