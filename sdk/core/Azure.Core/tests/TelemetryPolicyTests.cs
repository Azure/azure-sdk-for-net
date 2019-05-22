// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using Azure.Core.Pipeline.Policies;
using Azure.Core.Testing;
using NUnit.Framework;

namespace Azure.Core.Tests
{
    public class TelemetryPolicyTests: PolicyTestBase
    {
        [Test]
        public async Task ComponentNameAndVersionReadFromAssembly()
        {
            var transport = new MockTransport(new MockResponse(200));
            var telemetryPolicy = new TelemetryPolicy(new TelemetryOptions(), typeof(TelemetryPolicyTests).Assembly);

            var assemblyVersion = Assembly.GetExecutingAssembly().GetName().Version.ToString();
            await SendGetRequest(transport, telemetryPolicy);

            Assert.True(transport.SingleRequest.TryGetHeader("User-Agent", out var userAgent));
            Assert.AreEqual(userAgent, $"azsdk-net-base-test/{assemblyVersion} ({RuntimeInformation.FrameworkDescription}; {RuntimeInformation.OSDescription})");
        }

        [Test]
        public async Task ApplicationIdIsIncluded()
        {
            var transport = new MockTransport(new MockResponse(200));
            var telemetryPolicy = new TelemetryPolicy(new TelemetryOptions() { ApplicationId = "application-id" }, typeof(TelemetryPolicyTests).Assembly);

            await SendGetRequest(transport, telemetryPolicy);

            Assert.True(transport.SingleRequest.TryGetHeader("User-Agent", out var userAgent));
            StringAssert.StartsWith("application-id ", userAgent);
        }

        [NonParallelizable]
        [Theory]
        [TestCase("true")]
        [TestCase("TRUE")]
        [TestCase("1")]
        public async Task CanDisableTelemetryWithEnvironmentVariable(string value)
        {
            try
            {
                Environment.SetEnvironmentVariable("AZURE_TELEMETRY_DISABLED", value);

                var transport = new MockTransport(new MockResponse(200));
                var telemetryPolicy = new TelemetryPolicy(new TelemetryOptions(), typeof(TelemetryPolicyTests).Assembly);
                await SendGetRequest(transport, telemetryPolicy);

                Assert.False(transport.SingleRequest.TryGetHeader("User-Agent", out var userAgent));
            }
            finally
            {
                Environment.SetEnvironmentVariable("AZURE_TELEMETRY_DISABLED", null);
            }
        }
    }
}
