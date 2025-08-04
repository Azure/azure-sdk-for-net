// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
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
        public void TransformsAssemblyNameToAzureSdkFormat()
        {
            // Test that assembly names are correctly transformed to Azure SDK format (azsdk-net- prefix)
            var target = new TelemetryDetails(typeof(TelemetryDetailsTests).Assembly, null);

            var userAgent = target.ToString();

            // Verify the assembly name was transformed correctly
            Assert.That(userAgent, Does.Contain("azsdk-net-Core.Tests"));
            Assert.That(userAgent, Does.Not.Contain("Azure.Core.Tests"));
        }

        [Test]
        public void UserAgentContainsPlatformInformation()
        {
            // Test that user agent contains platform information from System.ClientModel
            var target = new TelemetryDetails(typeof(TelemetryDetailsTests).Assembly, null);

            var userAgent = target.ToString();

            // Should contain runtime framework description
            Assert.That(userAgent, Does.Contain(RuntimeInformation.FrameworkDescription));
            // Should have parentheses indicating platform information
            Assert.That(userAgent, Does.Contain("("));
            Assert.That(userAgent, Does.Contain(")"));
        }

        [Test]
        public void UsesSystemClientModelUserAgentGeneration()
        {
            // Test that the normal code path (without RuntimeInformationWrapper)
            // calls System.ClientModel's UserAgentPolicy.GenerateUserAgentString and applies Azure transformations
            var target = new TelemetryDetails(typeof(TelemetryDetailsTests).Assembly, appId);

            var assembly = Assembly.GetAssembly(GetType());
            AssemblyInformationalVersionAttribute versionAttribute = assembly.GetCustomAttribute<AssemblyInformationalVersionAttribute>();
            string version = versionAttribute.InformationalVersion;
            int hashSeparator = version.IndexOfOrdinal('+');
            if (hashSeparator != -1)
            {
                version = version.Substring(0, hashSeparator);
            }

            // Verify that the assembly name was transformed to Azure SDK format
            string userAgent = target.ToString();
            Assert.That(userAgent, Does.Contain("azsdk-net-Core.Tests"));
            Assert.That(userAgent, Does.Contain($"/{version}"));
            Assert.That(userAgent, Does.Contain(appId));
            Assert.That(userAgent, Does.Contain(RuntimeInformation.FrameworkDescription));

            // Verify it does NOT contain the original assembly name format
            Assert.That(userAgent, Does.Not.Contain("Azure.Core.Tests"));
        }

        [Test]
        public void SystemClientModelIntegrationWithoutApplicationId()
        {
            // Test System.ClientModel integration without application ID
            var target = new TelemetryDetails(typeof(TelemetryDetailsTests).Assembly, null);

            var assembly = Assembly.GetAssembly(GetType());
            AssemblyInformationalVersionAttribute versionAttribute = assembly.GetCustomAttribute<AssemblyInformationalVersionAttribute>();
            string version = versionAttribute.InformationalVersion;
            int hashSeparator = version.IndexOfOrdinal('+');
            if (hashSeparator != -1)
            {
                version = version.Substring(0, hashSeparator);
            }

            string userAgent = target.ToString();

            // Should start with azsdk-net-Core.Tests (no application ID prefix)
            Assert.That(userAgent, Does.StartWith("azsdk-net-Core.Tests"));
            Assert.That(userAgent, Does.Contain($"/{version}"));
            Assert.That(userAgent, Does.Contain(RuntimeInformation.FrameworkDescription));
        }
    }
}
