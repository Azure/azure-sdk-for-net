// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Reflection;
using System.Runtime.InteropServices;
using Azure.Core.Pipeline;
using Azure.Core.TestFramework;
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
                    target.ToString(),
                    $"azsdk-net-Core.Tests/{version} ({RuntimeInformation.FrameworkDescription}; {RuntimeInformation.OSDescription})");
            }
            else
            {
                Assert.AreEqual(
                    target.ToString(),
                    $"{applicationId} azsdk-net-Core.Tests/{version} ({RuntimeInformation.FrameworkDescription}; {RuntimeInformation.OSDescription})");
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
            var target = new TelemetryDetails(typeof(TelemetryDetailsTests).Assembly);
            var message = new HttpMessage(new MockRequest(), ResponseClassifier.Shared);

            target.Apply(message);

            message.TryGetProperty(typeof(UserAgentValueKey), out var obj);
            string actualValue = obj as string;

            Assert.AreEqual(target.ToString(), actualValue);
        }
    }
}
