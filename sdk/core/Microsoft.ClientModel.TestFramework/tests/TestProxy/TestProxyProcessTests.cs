// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
using Microsoft.ClientModel.TestFramework;
using NUnit.Framework;
using System;
using System.Threading.Tasks;
namespace Microsoft.ClientModel.TestFramework.Tests.TestProxy;
[TestFixture]
public class TestProxyProcessTests
{
    [Test]
    public void IpAddress_HasExpectedValue()
    {
        Assert.AreEqual("127.0.0.1", TestProxyProcess.IpAddress);
    }

    [Test]
    public void IpAddress_IsNotLocalhost()
    {
        Assert.AreNotEqual("localhost", TestProxyProcess.IpAddress);
    }

    [Test]
    public void Constructor_CreatesInstanceSuccessfully()
    {
        TestProxyProcess proxyProcess = null;
        Assert.DoesNotThrow(() => proxyProcess = TestProxyProcess.Start());
        Assert.IsNotNull(proxyProcess);
    }

    [Test]
    public void ProxyPortHttp_IsAccessible()
    {
        var proxyProcess = TestProxyProcess.Start();
        Assert.DoesNotThrow(() => _ = proxyProcess.ProxyPortHttp);
    }

    [Test]
    public void ProxyPortHttps_IsAccessible()
    {
        var proxyProcess = TestProxyProcess.Start();
        Assert.DoesNotThrow(() => _ = proxyProcess.ProxyPortHttps);
    }

    [Test]
    public void Client_IsAccessible()
    {
        var proxyProcess = TestProxyProcess.Start();
        Assert.DoesNotThrow(() => _ = proxyProcess.Client);
    }

    [Test]
    public void ProxyPorts_AreEitherNullOrValidPortNumbers()
    {
        var proxyProcess = TestProxyProcess.Start();
        var httpPort = proxyProcess.ProxyPortHttp;
        var httpsPort = proxyProcess.ProxyPortHttps;
        if (httpPort.HasValue)
        {
            Assert.IsTrue(httpPort.Value > 0 && httpPort.Value <= 65535, "HTTP port should be in valid range");
        }
        if (httpsPort.HasValue)
        {
            Assert.IsTrue(httpsPort.Value > 0 && httpsPort.Value <= 65535, "HTTPS port should be in valid range");
        }
    }

    [Test]
    public void ProxyPorts_AreDifferentWhenBothAssigned()
    {
        var proxyProcess = TestProxyProcess.Start();
        var httpPort = proxyProcess.ProxyPortHttp;
        var httpsPort = proxyProcess.ProxyPortHttps;
        if (httpPort.HasValue && httpsPort.HasValue)
        {
            Assert.AreNotEqual(httpPort.Value, httpsPort.Value, "HTTP and HTTPS ports should be different");
        }
    }

    [Test]
    public void TestProxyProcess_CanCreateMultipleInstances()
    {
        var process1 = TestProxyProcess.Start();
        var process2 = TestProxyProcess.Start();
        Assert.IsNotNull(process1);
        Assert.IsNotNull(process2);
        Assert.AreNotSame(process1, process2);
    }

    [Test]
    public async Task TestProxyProcess_CanHandleAsyncOperations()
    {
        var proxyProcess = TestProxyProcess.Start();
        // Basic test that the process can be used in async context
        await Task.Run(() =>
        {
            Assert.IsNotNull(proxyProcess);
            Assert.DoesNotThrow(() => _ = proxyProcess.ProxyPortHttp);
        });
    }

    [Test]
    public void TestProxyProcess_HasInternalClient()
    {
        var proxyProcess = TestProxyProcess.Start();
        var client = proxyProcess.Client;
        Assert.IsNotNull(client);
    }

    [Test]
    public void TestProxyProcess_ClientConsistentAcrossAccess()
    {
        var proxyProcess = TestProxyProcess.Start();
        var client1 = proxyProcess.Client;
        var client2 = proxyProcess.Client;
        Assert.AreSame(client1, client2, "Client property should return the same instance");
    }

    [Test]
    public void TestProxyProcess_PortsConsistentAcrossAccess()
    {
        var proxyProcess = TestProxyProcess.Start();
        var httpPort1 = proxyProcess.ProxyPortHttp;
        var httpPort2 = proxyProcess.ProxyPortHttp;
        var httpsPort1 = proxyProcess.ProxyPortHttps;
        var httpsPort2 = proxyProcess.ProxyPortHttps;
        Assert.AreEqual(httpPort1, httpPort2, "HTTP port should be consistent");
        Assert.AreEqual(httpsPort1, httpsPort2, "HTTPS port should be consistent");
    }
}
