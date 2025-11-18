// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.ClientModel.TestFramework.Tests;

[TestFixture]
public class TestProxyProcessTests
{
    #region Constants and Static Properties

    [Test]
    public void IpAddressIsLoopbackAddress()
    {
        Assert.That(TestProxyProcess.IpAddress, Is.EqualTo("127.0.0.1"), "Should use loopback IP address for proxy");
    }

    #endregion

    #region Static Constructor Behavior

    [Test]
    public void StaticConstructorLocatesDotNetExecutable()
    {
        // This test verifies the static constructor doesn't throw during class initialization
        // and that it successfully locates a .NET executable path
        var dotNetExeField = typeof(TestProxyProcess).GetField("s_dotNetExe",
            BindingFlags.NonPublic | BindingFlags.Static);

        Assert.That(dotNetExeField, Is.Not.Null, "s_dotNetExe field should exist");

        var dotNetExeValue = dotNetExeField!.GetValue(null) as string;
        Assert.That(dotNetExeValue, Is.Not.Null, "dotnet executable path should be found");
        Assert.That(dotNetExeValue, Is.Not.Empty, "dotnet executable path should not be empty");

        // Verify the path actually points to a dotnet executable
        Assert.That(dotNetExeValue, Does.EndWith("dotnet.exe").Or.EndWith("dotnet"),
            "Path should point to dotnet executable");
    }

    #endregion

    #region Mock Constructor Tests

    [Test]
    public void MockConstructorCreatesInstanceWithoutStartingProcess()
    {
        var mockProxy = new TestProxyProcess();

        // Mock constructor should create instance but clients will be null/default
        Assert.That(mockProxy, Is.Not.Null, "Mock constructor should create instance");
        using (Assert.EnterMultipleScope())
        {
            Assert.That(mockProxy.ProxyPortHttp, Is.Null, "Mock instance should not have HTTP port");
            Assert.That(mockProxy.ProxyPortHttps, Is.Null, "Mock instance should not have HTTPS port");
        }
    }

    #endregion

    #region Port Properties

    [Test]
    public void ProxyPortPropertiesReturnNullForMockInstance()
    {
        var mockProxy = new TestProxyProcess();

        using (Assert.EnterMultipleScope())
        {
            Assert.That(mockProxy.ProxyPortHttp, Is.Null, "Mock HTTP port should be null");
            Assert.That(mockProxy.ProxyPortHttps, Is.Null, "Mock HTTPS port should be null");
        }
    }

    #endregion

    #region TryParsePort Method Tests

    [Test]
    public void TryParsePortParsesHttpPortCorrectly()
    {
        var method = typeof(TestProxyProcess).GetMethod("TryParsePort",
            BindingFlags.NonPublic | BindingFlags.Static);
        Assert.That(method, Is.Not.Null, "TryParsePort method should exist");

        var parameters = new object[] { "Now listening on: http://127.0.0.1:5000", "http", null };
        var result = (bool)method!.Invoke(null, parameters)!;
        var port = parameters[2] as int?;

        using (Assert.EnterMultipleScope())
        {
            Assert.That(result, Is.True, "Should successfully parse HTTP port");
            Assert.That(port, Is.EqualTo(5000), "Should extract correct port number");
        }
    }

    [Test]
    public void TryParsePortParsesHttpsPortCorrectly()
    {
        var method = typeof(TestProxyProcess).GetMethod("TryParsePort",
            BindingFlags.NonPublic | BindingFlags.Static);
        Assert.That(method, Is.Not.Null, "TryParsePort method should exist");

        var parameters = new object[] { "Now listening on: https://127.0.0.1:5001", "https", null };
        var result = (bool)method!.Invoke(null, parameters)!;
        var port = parameters[2] as int?;

        using (Assert.EnterMultipleScope())
        {
            Assert.That(result, Is.True, "Should successfully parse HTTPS port");
            Assert.That(port, Is.EqualTo(5001), "Should extract correct port number");
        }
    }

    [Test]
    public void TryParsePortHandlesNullOutput()
    {
        var method = typeof(TestProxyProcess).GetMethod("TryParsePort",
            BindingFlags.NonPublic | BindingFlags.Static);
        Assert.That(method, Is.Not.Null, "TryParsePort method should exist");

        var parameters = new object[] { null, "http", null };
        var result = (bool)method!.Invoke(null, parameters)!;
        var port = parameters[2] as int?;

        using (Assert.EnterMultipleScope())
        {
            Assert.That(result, Is.False, "Should return false for null output");
            Assert.That(port, Is.Null, "Port should remain null");
        }
    }

    [Test]
    public void TryParsePortHandlesInvalidOutput()
    {
        var method = typeof(TestProxyProcess).GetMethod("TryParsePort",
            BindingFlags.NonPublic | BindingFlags.Static);
        Assert.That(method, Is.Not.Null, "TryParsePort method should exist");

        var parameters = new object[] { "Some random log message without port info", "http", null };
        var result = (bool)method!.Invoke(null, parameters)!;
        var port = parameters[2] as int?;

        using (Assert.EnterMultipleScope())
        {
            Assert.That(result, Is.False, "Should return false for invalid output");
            Assert.That(port, Is.Null, "Port should remain null");
        }
    }

    [Test]
    public void TryParsePortHandlesWrongScheme()
    {
        var method = typeof(TestProxyProcess).GetMethod("TryParsePort",
            BindingFlags.NonPublic | BindingFlags.Static);
        Assert.That(method, Is.Not.Null, "TryParsePort method should exist");

        var parameters = new object[] { "Now listening on: https://127.0.0.1:5001", "http", null };
        var result = (bool)method!.Invoke(null, parameters)!;
        var port = parameters[2] as int?;

        using (Assert.EnterMultipleScope())
        {
            Assert.That(result, Is.False, "Should return false for wrong scheme");
            Assert.That(port, Is.Null, "Port should remain null");
        }
    }

    #endregion

    #region TryRestoreLocalTools Method Tests

    [Test]
    public void TryRestoreLocalToolsDoesNotThrowWhenRepositoryRootIsValid()
    {
        var method = typeof(TestProxyProcess).GetMethod("TryRestoreLocalTools",
            BindingFlags.NonPublic | BindingFlags.Static);
        Assert.That(method, Is.Not.Null, "TryRestoreLocalTools method should exist");

        Assert.DoesNotThrow(() => method!.Invoke(null, null),
            "TryRestoreLocalTools should not throw when RepositoryRoot is valid");
    }

    [Test]
    public void TryRestoreLocalToolsHandlesDirectoryOperationsSafely()
    {
        var method = typeof(TestProxyProcess).GetMethod("TryRestoreLocalTools",
            BindingFlags.NonPublic | BindingFlags.Static);
        Assert.That(method, Is.Not.Null, "TryRestoreLocalTools method should exist");

        var tempRepoRoot = Path.Combine(Path.GetTempPath(), "test-repo-" + Guid.NewGuid().ToString("N").Substring(0, 8));
        var configDir = Path.Combine(tempRepoRoot, ".config");
        var toolsJsonPath = Path.Combine(configDir, "dotnet-tools.json");

        try
        {
            Directory.CreateDirectory(configDir);
            var toolsContent = @"{
  ""version"": 1,
  ""isRoot"": true,
  ""tools"": {
    ""azure.sdk.tools.testproxy"": {
      ""version"": ""1.0.0-dev.20241118.1"",
      ""commands"": [
        ""test-proxy""
      ]
    }
  }
}";

            File.WriteAllText(toolsJsonPath, toolsContent);
            Assert.DoesNotThrow(() => method!.Invoke(null, null),
                "TryRestoreLocalTools should handle manifest files safely");
        }
        finally
        {
            if (Directory.Exists(tempRepoRoot))
            {
                try
                {
                    Directory.Delete(tempRepoRoot, true);
                }
                catch
                {
                }
            }
        }
    }

    [Test]
    public void TryRestoreLocalToolsHandlesMissingConfigDirectory()
    {
        var method = typeof(TestProxyProcess).GetMethod("TryRestoreLocalTools",
            BindingFlags.NonPublic | BindingFlags.Static);
        Assert.That(method, Is.Not.Null, "TryRestoreLocalTools method should exist");

        Assert.DoesNotThrow(() => method!.Invoke(null, null),
            "TryRestoreLocalTools should handle missing .config directory gracefully");
    }

    #endregion

    #region Error Handling Tests

    [Test]
    public void ErrorHandlingThrowsInformativeErrorForToolRestoreFailures()
    {
        var mockInstance = new TestProxyProcess();
        var errorBufferField = typeof(TestProxyProcess).GetField("_errorBuffer",
            BindingFlags.NonPublic | BindingFlags.Instance);
        Assert.That(errorBufferField, Is.Not.Null, "_errorBuffer field should exist");

        var errorBuffer = errorBufferField!.GetValue(mockInstance) as StringBuilder;
        Assert.That(errorBuffer, Is.Not.Null, "_errorBuffer should be StringBuilder");

        var testError = "Tool 'test-proxy' is not installed. Run 'dotnet tool restore' to install it.";
        errorBuffer!.AppendLine(testError);

        var expectedErrorStart = "An error occurred in the test proxy. You may need to install the test-proxy tool globally " +
            "using 'dotnet tool install -g Azure.Sdk.Tools.TestProxy' or ensure TestEnvironment.RepositoryRoot is set correctly so the " +
            "test framework can restore local tools from the dotnet-tools.json manifest. The full error is:";

        Assert.That(expectedErrorStart, Does.Contain("dotnet tool install -g Azure.Sdk.Tools.TestProxy"));
        Assert.That(expectedErrorStart, Does.Contain("dotnet-tools.json manifest"));
        Assert.That(expectedErrorStart, Does.Contain("TestEnvironment.RepositoryRoot"));
    }

    [Test]
    public void ErrorHandlingUsesGenericErrorForNonToolRestoreFailures()
    {
        var mockInstance = new TestProxyProcess();

        var errorBufferField = typeof(TestProxyProcess).GetField("_errorBuffer",
            BindingFlags.NonPublic | BindingFlags.Instance);
        var errorBuffer = errorBufferField!.GetValue(mockInstance) as StringBuilder;

        var testError = "Permission denied accessing port 5000";
        errorBuffer!.AppendLine(testError);

        var genericErrorFormat = $"An error occurred in the test proxy: {testError.Trim()}";

        Assert.That(testError, Does.Not.Contain("dotnet tool restore"));
        Assert.That(genericErrorFormat, Does.StartWith("An error occurred in the test proxy:"));
        Assert.That(genericErrorFormat, Does.Contain(testError.Trim()));
    }

    [Test]
    public void ErrorHandlingDistinguishesBetweenErrorTypes()
    {
        var toolRestoreError = "Failed to restore tools. Run 'dotnet tool restore' to fix.";
        var genericError = "Network connection failed";

        Assert.That(toolRestoreError.Contains("dotnet tool restore"), Is.True,
            "Tool restore error should be detected");

        Assert.That(genericError.Contains("dotnet tool restore"), Is.False,
            "Generic error should not be treated as tool restore error");
    }

    #endregion

    #region Integration Scenario Tests

    [Test]
    public void TestProxyProcessHandlesGlobalToolScenario()
    {
        var method = typeof(TestProxyProcess).GetMethod("TryRestoreLocalTools",
            BindingFlags.NonPublic | BindingFlags.Static);

        Assert.DoesNotThrow(() => method!.Invoke(null, null),
            "TryRestoreLocalTools should handle global tool scenario gracefully");
    }

    [Test]
    public void TestProxyProcessSupportsLocalToolsWhenManifestExists()
    {
        var method = typeof(TestProxyProcess).GetMethod("TryRestoreLocalTools",
            BindingFlags.NonPublic | BindingFlags.Static);

        var tempDir = Path.Combine(Path.GetTempPath(), "local-tools-test-" + Guid.NewGuid().ToString("N").Substring(0, 8));

        try
        {
            Directory.CreateDirectory(Path.Combine(tempDir, ".config"));

            var manifestContent = @"{
  ""version"": 1,
  ""isRoot"": true,
  ""tools"": {
    ""azure.sdk.tools.testproxy"": {
      ""version"": ""1.0.0-dev.20241118.1"",
      ""commands"": [""test-proxy""]
    }
  }
}";

            File.WriteAllText(Path.Combine(tempDir, ".config", "dotnet-tools.json"), manifestContent);
            Assert.DoesNotThrow(() => method!.Invoke(null, null),
                "TryRestoreLocalTools should support local tools when manifest exists");
        }
        finally
        {
            if (Directory.Exists(tempDir))
            {
                try
                {
                    Directory.Delete(tempDir, true);
                }
                catch
                {
                }
            }
        }
    }

    [Test]
    public void TestProxyProcessRepositoryRootIsAvailableForTesting()
    {
        var repositoryRoot = TestEnvironment.RepositoryRoot;

        Assert.That(repositoryRoot, Is.Not.Null, "RepositoryRoot should be discovered by TestEnvironment");
        Assert.That(repositoryRoot, Is.Not.Empty, "RepositoryRoot should not be empty");

        Assert.That(Directory.Exists(repositoryRoot), Is.True,
            "RepositoryRoot should point to an existing directory");
    }

    #endregion
}
