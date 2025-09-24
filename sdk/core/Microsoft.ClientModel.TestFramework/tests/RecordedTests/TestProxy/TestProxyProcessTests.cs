// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using NUnit.Framework;
using System;
using System.Collections.Generic;
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
}
