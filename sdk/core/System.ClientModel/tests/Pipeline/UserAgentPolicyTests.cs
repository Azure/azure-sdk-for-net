// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using ClientModel.Tests;
using ClientModel.Tests.Mocks;
using NUnit.Framework;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace System.ClientModel.Tests.Pipeline;

public class UserAgentPolicyTests : SyncAsyncTestBase
{
    public UserAgentPolicyTests(bool isAsync) : base(isAsync)
    {
    }

    [Test]
    public async Task UserAgentTelemetryNotIncludedByDefault()
    {
        ClientPipelineOptions options = new()
        {
            Transport = new ObservableTransport("Transport")
        };

        ClientPipeline pipeline = ClientPipeline.Create(options);
        PipelineMessage message = pipeline.CreateMessage();
        message.Request.Uri = new Uri("https://example.com");
        message.Request.Method = "GET";

        await pipeline.SendSyncOrAsync(message, IsAsync);

        // User-Agent header should not be present when user agent policy is not added
        Assert.IsFalse(message.Request.Headers.TryGetValue("User-Agent", out _));
    }

    [Test]
    public async Task UserAgentTelemetryAddsHeaderWhenPolicyIncluded()
    {
        MockPipelineTransport transport = new("Transport", 200);
        PipelineRequest? capturedRequest = null;

        transport.OnSendingRequest = (message) =>
        {
            capturedRequest = message.Request;
        };

        ClientPipelineOptions options = new()
        {
            Transport = transport
        };

        // Library author explicitly adds user agent policy when creating pipeline
        var userAgentPolicy = new UserAgentPolicy(Assembly.GetExecutingAssembly());
        ClientPipeline pipeline = ClientPipeline.Create(
            options,
            perCallPolicies: new[] { userAgentPolicy },
            perTryPolicies: ReadOnlySpan<PipelinePolicy>.Empty,
            beforeTransportPolicies: ReadOnlySpan<PipelinePolicy>.Empty);
        PipelineMessage message = pipeline.CreateMessage();
        message.Request.Uri = new Uri("https://example.com");
        message.Request.Method = "GET";

        await pipeline.SendSyncOrAsync(message, IsAsync);

        // User-Agent header should be present when user agent policy is included
        Assert.IsNotNull(capturedRequest);
        Assert.IsTrue(capturedRequest!.Headers.TryGetValue("User-Agent", out string? userAgent));
        Assert.IsNotNull(userAgent);

        // Should contain assembly name and version
        Assert.That(userAgent, Does.Contain("ClientModel.Tests"));
    }

    [Test]
    public void UserAgentPolicyGeneratesValidUserAgent()
    {
        Assembly assembly = Assembly.GetExecutingAssembly();
        UserAgentPolicy userAgentPolicy = new(assembly);

        // Create a mock transport and add user agent policy to verify behavior
        MockPipelineTransport transport = new("Transport", 200);
        PipelineRequest? capturedRequest = null;

        transport.OnSendingRequest = (message) =>
        {
            capturedRequest = message.Request;
        };

        ClientPipelineOptions options = new()
        {
            Transport = transport
        };

        ClientPipeline pipeline = ClientPipeline.Create(
            options,
            perCallPolicies: new[] { userAgentPolicy },
            perTryPolicies: ReadOnlySpan<PipelinePolicy>.Empty,
            beforeTransportPolicies: ReadOnlySpan<PipelinePolicy>.Empty);
        PipelineMessage message = pipeline.CreateMessage();
        message.Request.Uri = new Uri("https://example.com");
        message.Request.Method = "GET";

        // Send through pipeline to test user agent functionality
        pipeline.Send(message);

        Assert.IsNotNull(capturedRequest);
        Assert.IsTrue(capturedRequest!.Headers.TryGetValue("User-Agent", out string? userAgent));
        Assert.IsNotNull(userAgent);
        Assert.IsNotEmpty(userAgent);

        // Should contain assembly name and version
        string assemblyName = assembly.GetName().Name!;
        Assert.That(userAgent, Does.Contain(assemblyName));

        // Should contain framework and OS information
        Assert.That(userAgent, Does.Contain("("));
        Assert.That(userAgent, Does.Contain(")"));
    }

    [Test]
    public void UserAgentPolicyWithApplicationId()
    {
        Assembly assembly = Assembly.GetExecutingAssembly();
        string applicationId = "TestApp/2.0";
        UserAgentPolicy userAgentPolicy = new(assembly, applicationId);

        // Verify the application ID is used by checking the properties
        Assert.AreEqual(applicationId, userAgentPolicy.ApplicationId);

        // Also verify by processing a message and checking the header through the pipeline
        MockPipelineTransport transport = new("Transport", 200);
        PipelineRequest? capturedRequest = null;

        transport.OnSendingRequest = (message) =>
        {
            capturedRequest = message.Request;
        };

        ClientPipelineOptions options = new()
        {
            Transport = transport
        };

        ClientPipeline pipeline = ClientPipeline.Create(
            options,
            perCallPolicies: new[] { userAgentPolicy },
            perTryPolicies: ReadOnlySpan<PipelinePolicy>.Empty,
            beforeTransportPolicies: ReadOnlySpan<PipelinePolicy>.Empty);
        PipelineMessage message = pipeline.CreateMessage();
        message.Request.Uri = new Uri("https://example.com");
        message.Request.Method = "GET";

        pipeline.Send(message);

        Assert.IsNotNull(capturedRequest);
        Assert.IsTrue(capturedRequest!.Headers.TryGetValue("User-Agent", out string? userAgent));
        Assert.That(userAgent, Does.StartWith(applicationId));
    }

    [Test]
    public void UserAgentPolicyThrowsForLongApplicationId()
    {
        Assembly assembly = Assembly.GetExecutingAssembly();
        string longApplicationId = new string('a', 30); // More than 24 characters

        Assert.Throws<ArgumentOutOfRangeException>(() => new UserAgentPolicy(assembly, longApplicationId));
    }

    [Test]
    public void UserAgentPolicyThrowsForNullAssembly()
    {
        Assert.Throws<ArgumentNullException>(() => new UserAgentPolicy(null!));
    }

    [Test]
    public void GenerateUserAgentString_ProducesValidUserAgent()
    {
        Assembly assembly = Assembly.GetExecutingAssembly();

        // Test without application ID
        var policy = new UserAgentPolicy(assembly);
        Assert.IsNotNull(policy);
        Assert.IsNull(policy.ApplicationId);
        Assert.AreEqual(assembly, policy.Assembly);

        // Should contain assembly name and version
        var userAgent = policy.UserAgentValue;
        string assemblyName = assembly.GetName().Name!;
        Assert.That(userAgent, Does.Contain(assemblyName));

        // Should contain framework and OS information in parentheses
        Assert.That(userAgent, Does.Contain("("));
        Assert.That(userAgent, Does.Contain(")"));
    }

    [Test]
    public void GenerateUserAgentString_WithApplicationId_ProducesValidUserAgent()
    {
        Assembly assembly = Assembly.GetExecutingAssembly();
        string applicationId = "TestApp/1.0";

        var policy = new UserAgentPolicy(assembly, applicationId);
        Assert.IsNotNull(policy);
        Assert.AreEqual(applicationId, policy.ApplicationId);
        Assert.AreEqual(assembly, policy.Assembly);
        var userAgent = policy.UserAgentValue;

        // Should start with application ID
        Assert.That(userAgent, Does.StartWith(applicationId));

        // Should contain assembly name and version
        string assemblyName = assembly.GetName().Name!;
        Assert.That(userAgent, Does.Contain(assemblyName));
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
        var mockRuntimeInformation = new MockRuntimeInformation
        {
            OSDescriptionMock = input,
            FrameworkDescriptionMock = RuntimeInformation.FrameworkDescription
        };
        var assembly = Assembly.GetExecutingAssembly();
        AssemblyInformationalVersionAttribute? versionAttribute = assembly.GetCustomAttribute<AssemblyInformationalVersionAttribute>();
        string version = versionAttribute!.InformationalVersion;
        int hashSeparator = version.IndexOf('+');
        if (hashSeparator != -1)
        {
            version = version.Substring(0, hashSeparator);
        }

        string userAgent = UserAgentPolicy.GenerateUserAgentString(assembly, null, mockRuntimeInformation);
        string assemblyName = assembly.GetName().Name!;

        Assert.AreEqual(
                $"{assemblyName}/{version} ({mockRuntimeInformation.FrameworkDescription}; {output})",
                userAgent);
    }

    [Test]
    [TestCase("Win64; x64", "Win64; x64")]
    [TestCase("Intel Mac OS X 10_15_7", "Intel Mac OS X 10_15_7")]
    [TestCase("Android 10; SM-G973F", "Android 10; SM-G973F")]
    [TestCase("Win64; x64; Xbox; Xbox One", "Win64; x64; Xbox; Xbox One")]
    public void AsciiDoesNotEncode(string input, string output)
    {
        var mockRuntimeInformation = new MockRuntimeInformation
        {
            OSDescriptionMock = input,
            FrameworkDescriptionMock = RuntimeInformation.FrameworkDescription
        };
        var assembly = Assembly.GetExecutingAssembly();
        AssemblyInformationalVersionAttribute? versionAttribute = assembly.GetCustomAttribute<AssemblyInformationalVersionAttribute>();
        string version = versionAttribute!.InformationalVersion;
        int hashSeparator = version.IndexOf('+');
        if (hashSeparator != -1)
        {
            version = version.Substring(0, hashSeparator);
        }

        string userAgent = UserAgentPolicy.GenerateUserAgentString(assembly, null, mockRuntimeInformation);
        string assemblyName = assembly.GetName().Name!;

        Assert.AreEqual(
                $"{assemblyName}/{version} ({mockRuntimeInformation.FrameworkDescription}; {output})",
                userAgent);
    }

    [Test]
    [TestCase("»-Browser¢sample", "%C2%BB-Browser%C2%A2sample")]
    [TestCase("NixOS 24.11 (Vicuña)", "NixOS+24.11+(Vicu%C3%B1a)")]
    public void NonAsciiCharactersAreUrlEncoded(string input, string output)
    {
        var mockRuntimeInformation = new MockRuntimeInformation
        {
            OSDescriptionMock = input,
            FrameworkDescriptionMock = RuntimeInformation.FrameworkDescription
        };
        var assembly = Assembly.GetExecutingAssembly();
        AssemblyInformationalVersionAttribute? versionAttribute = assembly.GetCustomAttribute<AssemblyInformationalVersionAttribute>();
        string version = versionAttribute!.InformationalVersion;
        int hashSeparator = version.IndexOf('+');
        if (hashSeparator != -1)
        {
            version = version.Substring(0, hashSeparator);
        }

        string userAgent = UserAgentPolicy.GenerateUserAgentString(assembly, null, mockRuntimeInformation);
        string assemblyName = assembly.GetName().Name!;

        Assert.AreEqual(
                $"{assemblyName}/{version} ({mockRuntimeInformation.FrameworkDescription}; {output})",
                userAgent);
    }

    [Test]
    public void GenerateUserAgentString_WithCustomRuntimeInfo_ProducesValidUserAgent()
    {
        var assembly = Assembly.GetExecutingAssembly();
        var mockRuntimeInfo = new MockRuntimeInformation
        {
            OSDescriptionMock = "Test OS",
            FrameworkDescriptionMock = "Test Framework"
        };

        string userAgent = UserAgentPolicy.GenerateUserAgentString(assembly, null, mockRuntimeInfo);

        // Get expected values
        string assemblyName = assembly.GetName().Name!;
        AssemblyInformationalVersionAttribute? versionAttribute = assembly.GetCustomAttribute<AssemblyInformationalVersionAttribute>();
        string version = versionAttribute!.InformationalVersion;
        int hashSeparator = version.IndexOf('+');
        if (hashSeparator != -1)
        {
            version = version.Substring(0, hashSeparator);
        }

        string expectedUserAgent = $"{assemblyName}/{version} ({mockRuntimeInfo.FrameworkDescriptionMock}; {mockRuntimeInfo.OSDescriptionMock})";
        Assert.AreEqual(expectedUserAgent, userAgent);
    }

    [Test]
    public void GenerateUserAgentString_WithCustomRuntimeInfoAndApplicationId_ProducesValidUserAgent()
    {
        var assembly = Assembly.GetExecutingAssembly();
        string applicationId = "TestApp/1.0";
        var mockRuntimeInfo = new MockRuntimeInformation
        {
            OSDescriptionMock = "Test OS",
            FrameworkDescriptionMock = "Test Framework"
        };

        string userAgent = UserAgentPolicy.GenerateUserAgentString(assembly, applicationId, mockRuntimeInfo);

        // Get expected values
        string assemblyName = assembly.GetName().Name!;
        AssemblyInformationalVersionAttribute? versionAttribute = assembly.GetCustomAttribute<AssemblyInformationalVersionAttribute>();
        string version = versionAttribute!.InformationalVersion;
        int hashSeparator = version.IndexOf('+');
        if (hashSeparator != -1)
        {
            version = version.Substring(0, hashSeparator);
        }

        string expectedUserAgent = $"{applicationId} {assemblyName}/{version} ({mockRuntimeInfo.FrameworkDescriptionMock}; {mockRuntimeInfo.OSDescriptionMock})";
        Assert.AreEqual(expectedUserAgent, userAgent);
    }
}
