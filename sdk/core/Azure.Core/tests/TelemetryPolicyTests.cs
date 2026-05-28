// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Reflection;
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
            var assembly = Assembly.GetAssembly(GetType());
            var transport = new MockTransport(new MockResponse(200));
            var telemetryPolicy = new TelemetryPolicy(new TelemetryDetails(GetType().Assembly, default));

            await SendGetRequest(transport, telemetryPolicy);

            Assert.True(transport.SingleRequest.TryGetHeader("User-Agent", out var userAgent));

            AssemblyInformationalVersionAttribute versionAttribute = assembly.GetCustomAttribute<AssemblyInformationalVersionAttribute>();
            string version = versionAttribute.InformationalVersion;
            int hashSeparator = version.IndexOfOrdinal('+');
            if (hashSeparator != -1)
            {
                version = version.Substring(0, hashSeparator);
            }
            Assert.AreEqual(userAgent, $"azsdk-net-Core.Tests/{version} ({RuntimeInformation.FrameworkDescription}; {RuntimeInformation.OSDescription})");
        }

        [Test]
        public async Task ApplicationIdIsIncluded()
        {
            var transport = new MockTransport(new MockResponse(200));
            var telemetryPolicy = new TelemetryPolicy(new TelemetryDetails(GetType().Assembly, "application-id"));

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
        { }
    }
}
