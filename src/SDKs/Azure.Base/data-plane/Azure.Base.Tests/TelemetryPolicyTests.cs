// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Reflection;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using Azure.Base.Pipeline.Policies;
using Azure.Base.Testing;
using NUnit.Framework;

namespace Azure.Base.Tests
{
    public class TelemetryPolicyTests: PolicyTestBase
    {
        [Test]
        public async Task ComponentNameAndVersionReadFromAssembly()
        {
            var transport = new MockTransport(new MockResponse(200));
            var telemetryPolicy = new TelemetryPolicy(typeof(TelemetryPolicyTests).Assembly, null);

            var assemblyVersion = Assembly.GetExecutingAssembly().GetName().Version.ToString();
            await SendGetRequest(transport, telemetryPolicy);

            Assert.True(transport.SingleRequest.TryGetHeader("User-Agent", out var userAgent));
            Assert.AreEqual(userAgent, $"azsdk-net-base-test/{assemblyVersion} ({RuntimeInformation.FrameworkDescription}; {RuntimeInformation.OSDescription})");
        }

        [Test]
        public async Task ApplicationIdIsIncluded()
        {
            var transport = new MockTransport(new MockResponse(200));
            var telemetryPolicy = new TelemetryPolicy(typeof(TelemetryPolicyTests).Assembly, "application-id");

            var assemblyVersion = Assembly.GetExecutingAssembly().GetName().Version.ToString();
            await SendGetRequest(transport, telemetryPolicy);

            Assert.True(transport.SingleRequest.TryGetHeader("User-Agent", out var userAgent));
            Assert.AreEqual(userAgent, $"application-id azsdk-net-base-test/{assemblyVersion} ({RuntimeInformation.FrameworkDescription}; {RuntimeInformation.OSDescription})");
        }
    }
}
