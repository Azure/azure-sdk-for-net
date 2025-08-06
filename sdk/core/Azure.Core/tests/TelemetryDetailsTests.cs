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

            // Verify the full user agent string format
            string userAgent = target.ToString();
            string expectedUserAgent = $"{appId} azsdk-net-Core.Tests/{version} ({RuntimeInformation.FrameworkDescription}; {RuntimeInformation.OSDescription})";
            Assert.That(userAgent, Is.EqualTo(expectedUserAgent));
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

        [Test]
        public void AssemblyNameTransformation_AzureAssembly()
        {
            // Test transformation behavior with an Azure.* assembly
            var azureAssembly = typeof(TelemetryDetails).Assembly; // This is Azure.Core
            var target = new TelemetryDetails(azureAssembly, null);

            var userAgent = target.ToString();

            // Azure.Core should become azsdk-net-Core
            Assert.That(userAgent, Does.StartWith("azsdk-net-Core/"));
            Assert.That(userAgent, Does.Not.Contain("Azure.Core"));
        }

        [Test]
        public void AssemblyNameTransformation_SystemAssembly()
        {
            // Test transformation behavior with a System.* assembly
            var systemAssembly = typeof(System.Net.Http.HttpClient).Assembly; // System.Net.Http
            var target = new TelemetryDetails(systemAssembly, null);

            var userAgent = target.ToString();

            // System.Net.Http should become azsdk-net-System.Net.Http (only Azure. prefix is stripped)
            Assert.That(userAgent, Does.StartWith("azsdk-net-System.Net.Http/"));
        }

        [Test]
        public void AssemblyNameTransformation_SystemCoreAssembly()
        {
            // Test transformation behavior with System.Core assembly
            var systemCoreAssembly = typeof(System.Linq.Enumerable).Assembly; // System.Core or System.Linq
            var target = new TelemetryDetails(systemCoreAssembly, null);

            var userAgent = target.ToString();
            var assemblyName = systemCoreAssembly.GetName().Name;

            // Should get azsdk-net- prefix (only Azure. prefix is stripped, everything else is kept)
            Assert.That(userAgent, Does.StartWith("azsdk-net-"));
            var expectedTransformed = "azsdk-net-" + assemblyName;
            Assert.That(userAgent, Does.StartWith($"{expectedTransformed}/"));
        }

        [Test]
        public void AssemblyNameTransformation_NonSystemNonAzureAssembly()
        {
            // Test transformation behavior with a non-System, non-Azure assembly
            // Use System.Text.Json since it has AssemblyInformationalVersionAttribute
            var jsonAssembly = typeof(System.Text.Json.JsonDocument).Assembly; // System.Text.Json
            var target = new TelemetryDetails(jsonAssembly, null);

            var userAgent = target.ToString();
            var assemblyName = jsonAssembly.GetName().Name;

            // Should get azsdk-net- prefix (only Azure. prefix is stripped, everything else is kept)
            Assert.That(userAgent, Does.StartWith("azsdk-net-"));
            var expectedTransformed = "azsdk-net-" + assemblyName;
            Assert.That(userAgent, Does.StartWith($"{expectedTransformed}/"));
        }

        [Test]
        public void AssemblyNameTransformation_WithApplicationId()
        {
            // Test that application ID is preserved with different assembly types
            var systemAssembly = typeof(System.Text.Json.JsonDocument).Assembly; // System.Text.Json
            var target = new TelemetryDetails(systemAssembly, appId);

            var userAgent = target.ToString();
            var assemblyName = systemAssembly.GetName().Name;

            // Should start with application ID
            Assert.That(userAgent, Does.StartWith($"{appId} "));

            // Should contain azsdk-net- prefixed assembly name (only Azure. prefix is stripped)
            Assert.That(userAgent, Does.Contain("azsdk-net-"));
            var expectedTransformed = "azsdk-net-" + assemblyName;
            Assert.That(userAgent, Does.Contain($"{expectedTransformed}/"));
        }

        [Test]
        public void AssemblyNameTransformation_CompleteUserAgentFormat()
        {
            // Test complete user agent format with different assemblies
            var testCases = new[]
            {
                new { Assembly = typeof(TelemetryDetails).Assembly, ExpectedPrefix = "azsdk-net-Core" }, // Azure.Core
                new { Assembly = typeof(System.Net.Http.HttpClient).Assembly, ExpectedPrefix = "azsdk-net-System.Net.Http" }, // System.Net.Http
                new { Assembly = typeof(System.Text.Json.JsonDocument).Assembly, ExpectedPrefix = "azsdk-net-System.Text.Json" } // System.Text.Json
            };

            foreach (var testCase in testCases)
            {
                var target = new TelemetryDetails(testCase.Assembly, appId);
                var userAgent = target.ToString();

                // Get version info
                AssemblyInformationalVersionAttribute versionAttribute = testCase.Assembly.GetCustomAttribute<AssemblyInformationalVersionAttribute>();
                string version = versionAttribute?.InformationalVersion ?? testCase.Assembly.GetName().Version.ToString();
                int hashSeparator = version.IndexOfOrdinal('+');
                if (hashSeparator != -1)
                {
                    version = version.Substring(0, hashSeparator);
                }

                // Verify complete format: "{appId} {transformedAssemblyName}/{version} ({framework}; {os})"
                var expectedUserAgent = $"{appId} {testCase.ExpectedPrefix}/{version} ({RuntimeInformation.FrameworkDescription}; {RuntimeInformation.OSDescription})";
                Assert.That(userAgent, Is.EqualTo(expectedUserAgent), $"Failed for assembly: {testCase.Assembly.GetName().Name}");
            }
        }
    }
}
