// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Reflection;
using System.Runtime.InteropServices;
using Azure.Core.Pipeline;
using Azure.Core.TestFramework;
using Moq;
using NUnit.Framework;

namespace Azure.Core.Tests
{
    public class TelemetryDetailsTests
    {
        private const string appId = "MyApplicationId";

        [Test]
        public void CtorInitializesValue([Values(null, appId)] string applicationId)
        {
            var target = new TelemetryDetails(typeof(TelemetryDetailsTests).Assembly, applicationId);

            var assembly = Assembly.GetAssembly(GetType());
            AssemblyInformationalVersionAttribute versionAttribute = assembly.GetCustomAttribute<AssemblyInformationalVersionAttribute>();
            string version = versionAttribute.InformationalVersion;
            int hashSeparator = version.IndexOfOrdinal('+');
            if (hashSeparator != -1)
            {
                version = version.Substring(0, hashSeparator);
            }
            if (applicationId == null)
            {
                Assert.AreEqual(
                    $"azsdk-net-Core.Tests/{version} ({RuntimeInformation.FrameworkDescription}; {RuntimeInformation.OSDescription})",
                    target.ToString());
            }
            else
            {
                Assert.AreEqual(
                    $"{applicationId} azsdk-net-Core.Tests/{version} ({RuntimeInformation.FrameworkDescription}; {RuntimeInformation.OSDescription})",
                    target.ToString());
            }
        }

        [Test]
        public void CtorPopulatesProperties([Values(null, appId)] string applicationId)
        {
            var target = new TelemetryDetails(typeof(TelemetryDetailsTests).Assembly, applicationId);

            Assert.AreEqual(typeof(TelemetryDetailsTests).Assembly, target.Assembly);
            Assert.AreEqual(applicationId, target.ApplicationId);
        }

        [Test]
        public void AppliesToMessage()
        {
            var target = new TelemetryDetails(typeof(TelemetryDetailsTests).Assembly, default);
            var message = new HttpMessage(new MockRequest(), ResponseClassifier.Shared);

            target.Apply(message);

            message.TryGetProperty(typeof(UserAgentValueKey), out var obj);
            string actualValue = obj as string;

            Assert.AreEqual(target.ToString(), actualValue);
        }

        [Test]
        [TestCase("MyOSDescription (2023-", "MyOSDescription (2023-)")]
        [TestCase("MyOSDescription (2023-)", "MyOSDescription (2023-)")]
        [TestCase("MyOSDescription (()", "MyOSDescription ()")]
        [TestCase("MyOSDescription (", "MyOSDescription ()")]
        [TestCase("MyOSDescription ())", "MyOSDescription ()")]
        [TestCase("MyOSDescription )", "MyOSDescription ")]
        [TestCase("MyO)SDescription ", "MyOSDescription ")]
        [TestCase("MyO(SDescription ", "MyOSDescription ")]
        public void ValidatesProperParenthesisMatching(string input, string output)
        {
            var mockRuntimeInformation = new MockRuntimeInformation { OSDescriptionMock = input, FrameworkDescriptionMock = RuntimeInformation.FrameworkDescription };
            var assembly = Assembly.GetAssembly(GetType());
            AssemblyInformationalVersionAttribute versionAttribute = assembly.GetCustomAttribute<AssemblyInformationalVersionAttribute>();
            string version = versionAttribute.InformationalVersion;
            int hashSeparator = version.IndexOfOrdinal('+');
            if (hashSeparator != -1)
            {
                version = version.Substring(0, hashSeparator);
            }

            var target = new TelemetryDetails(typeof(TelemetryDetailsTests).Assembly, default, mockRuntimeInformation);

            Assert.AreEqual(
                    $"azsdk-net-Core.Tests/{version} ({mockRuntimeInformation.FrameworkDescription}; {mockRuntimeInformation.OSDescription})",
                    target.ToString());
        }

        private class MockRuntimeInformation : RuntimeInformationWrapper
        {
            public string FrameworkDescriptionMock { get; set; }
            public string OSDescriptionMock { get; set; }
            public Architecture OSArchitectureMock { get; set; }
            public Architecture ProcessArchitectureMock { get; set; }
            public Func<System.Runtime.InteropServices.OSPlatform, bool> IsOSPlatformMock { get; set; }

            public override string OSDescription => OSDescriptionMock;
            public override string FrameworkDescription => FrameworkDescriptionMock;
            public override Architecture OSArchitecture => OSArchitectureMock;
            public override Architecture ProcessArchitecture => ProcessArchitectureMock;
            public override bool IsOSPlatform(OSPlatform osPlatform) => IsOSPlatformMock(osPlatform);
        }
    }
}
