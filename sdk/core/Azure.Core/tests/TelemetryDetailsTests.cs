// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Net;
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
        [TestCase("ValidParens (2023-)", "ValidParens (2023-)")]
        [TestCase("(ValidParens (2023-))", "(ValidParens (2023-))")]
        [TestCase("ProperlyEscapedParens \\(2023-\\)", "ProperlyEscapedParens \\(2023-\\)")]
        [TestCase("UnescapedOnlyParens (2023-)", "UnescapedOnlyParens (2023-)")]
        [TestCase("UnmatchedOpenParen (2023-", "UnmatchedOpenParen \\(2023-")]
        [TestCase("UnEscapedParenWithValidParens (()", "UnEscapedParenWithValidParens \\(\\(\\)")]
        [TestCase("UnEscapedInvalidParen (", "UnEscapedInvalidParen \\(")]
        [TestCase("UnEscapedParenWithValidParens2 ())", "UnEscapedParenWithValidParens2 \\(\\)\\)")]
        [TestCase("InvalidParen )", "InvalidParen \\)")]
        [TestCase("(InvalidParen ", "\\(InvalidParen ")]
        [TestCase("UnescapedParenInText MyO)SDescription ", "UnescapedParenInText MyO\\)SDescription ")]
        [TestCase("UnescapedParenInText MyO(SDescription ", "UnescapedParenInText MyO\\(SDescription ")]
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
                    $"azsdk-net-Core.Tests/{version} ({mockRuntimeInformation.FrameworkDescription}; {output})",
                    target.ToString());
        }

        [Test]
        [TestCase("Win64; x64", "Win64; x64")]
        [TestCase("Intel Mac OS X 10_15_7", "Intel Mac OS X 10_15_7")]
        [TestCase("Android 10; SM-G973F", "Android 10; SM-G973F")]
        [TestCase("Win64; x64; Xbox; Xbox One", "Win64; x64; Xbox; Xbox One")]
        public void AsciiDoesNotEncode(string input, string output)
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
                    $"azsdk-net-Core.Tests/{version} ({mockRuntimeInformation.FrameworkDescription}; {output})",
                    target.ToString());
        }

        [Test]
        [TestCase("»-Browser¢sample", "%C2%BB-Browser%C2%A2sample")]
        [TestCase("NixOS 24.11 (Vicuña)", "NixOS+24.11+(Vicu%C3%B1a)")]
        public void NonAsciiCharactersAreUrlEncoded(string input, string output)
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
                    $"azsdk-net-Core.Tests/{version} ({mockRuntimeInformation.FrameworkDescription}; {output})",
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
