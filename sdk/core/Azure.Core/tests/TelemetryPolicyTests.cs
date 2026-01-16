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

            Assert.That(transport.SingleRequest.TryGetHeader("User-Agent", out var userAgent), Is.True);

            AssemblyInformationalVersionAttribute versionAttribute = assembly.GetCustomAttribute<AssemblyInformationalVersionAttribute>();
            string version = versionAttribute.InformationalVersion;
            int hashSeparator = version.IndexOfOrdinal('+');
            if (hashSeparator != -1)
            {
                version = version.Substring(0, hashSeparator);
            }
            Assert.That($"azsdk-net-Core.Tests/{version} ({RuntimeInformation.FrameworkDescription}; {RuntimeInformation.OSDescription})", Is.EqualTo(userAgent));
        }

        [Test]
        public async Task ApplicationIdIsIncluded()
        {
            var transport = new MockTransport(new MockResponse(200));
            var telemetryPolicy = new TelemetryPolicy(new TelemetryDetails(GetType().Assembly, "application-id"));

            await SendGetRequest(transport, telemetryPolicy);

            Assert.That(transport.SingleRequest.TryGetHeader("User-Agent", out var userAgent), Is.True);
            Assert.That(userAgent, Does.StartWith("application-id "));
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
