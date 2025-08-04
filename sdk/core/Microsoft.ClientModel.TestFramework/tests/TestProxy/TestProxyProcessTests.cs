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
        
        Assert.DoesNotThrow(() => proxyProcess = new TestProxyProcess());
        Assert.IsNotNull(proxyProcess);
    }

    [Test]
    public void ProxyPortHttp_IsAccessible()
    {
        var proxyProcess = new TestProxyProcess();
        
        Assert.DoesNotThrow(() => _ = proxyProcess.ProxyPortHttp);
    }

    [Test]
    public void ProxyPortHttps_IsAccessible()
    {
        var proxyProcess = new TestProxyProcess();
        
        Assert.DoesNotThrow(() => _ = proxyProcess.ProxyPortHttps);
    }

    [Test]
    public void Client_IsAccessible()
    {
        var proxyProcess = new TestProxyProcess();
        
        Assert.DoesNotThrow(() => _ = proxyProcess.Client);
    }

    [Test]
    public void ProxyPorts_AreEitherNullOrValidPortNumbers()
    {
        var proxyProcess = new TestProxyProcess();
        
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
        var proxyProcess = new TestProxyProcess();
        
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
        var process1 = new TestProxyProcess();
        var process2 = new TestProxyProcess();
        
        Assert.IsNotNull(process1);
        Assert.IsNotNull(process2);
        Assert.AreNotSame(process1, process2);
    }

    [Test]
    public void TestProxyProcess_ImplementsIDisposable()
    {
        var proxyProcess = new TestProxyProcess();
        
        Assert.IsInstanceOf<IDisposable>(proxyProcess);
    }

    [Test]
    public void Dispose_CanBeCalledSafely()
    {
        var proxyProcess = new TestProxyProcess();
        
        Assert.DoesNotThrow(() => proxyProcess.Dispose());
    }

    [Test]
    public void Dispose_CanBeCalledMultipleTimes()
    {
        var proxyProcess = new TestProxyProcess();
        
        Assert.DoesNotThrow(() =>
        {
            proxyProcess.Dispose();
            proxyProcess.Dispose();
        });
    }

    [Test]
    public void TestProxyProcess_WithUsingStatement_DisposesCorrectly()
    {
        Assert.DoesNotThrow(() =>
        {
            using var proxyProcess = new TestProxyProcess();
            // Using statement should dispose automatically
        });
    }

    [Test]
    public async Task TestProxyProcess_CanHandleAsyncOperations()
    {
        using var proxyProcess = new TestProxyProcess();
        
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
        using var proxyProcess = new TestProxyProcess();
        
        var client = proxyProcess.Client;
        Assert.IsNotNull(client);
    }

    [Test]
    public void TestProxyProcess_ClientConsistentAcrossAccess()
    {
        using var proxyProcess = new TestProxyProcess();
        
        var client1 = proxyProcess.Client;
        var client2 = proxyProcess.Client;
        
        Assert.AreSame(client1, client2, "Client property should return the same instance");
    }

    [Test]
    public void TestProxyProcess_PortsConsistentAcrossAccess()
    {
        using var proxyProcess = new TestProxyProcess();
        
        var httpPort1 = proxyProcess.ProxyPortHttp;
        var httpPort2 = proxyProcess.ProxyPortHttp;
        var httpsPort1 = proxyProcess.ProxyPortHttps;
        var httpsPort2 = proxyProcess.ProxyPortHttps;
        
        Assert.AreEqual(httpPort1, httpPort2, "HTTP port should be consistent");
        Assert.AreEqual(httpsPort1, httpsPort2, "HTTPS port should be consistent");
    }
}
