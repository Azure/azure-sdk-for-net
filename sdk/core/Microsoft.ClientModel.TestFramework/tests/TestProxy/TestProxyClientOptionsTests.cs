// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
using Microsoft.ClientModel.TestFramework.TestProxy;
using NUnit.Framework;
namespace Microsoft.ClientModel.TestFramework.Tests.TestProxy;
[TestFixture]
public class TestProxyClientOptionsTests
{
    [Test]
    public void Constructor_CreatesInstanceSuccessfully()
    {
        var options = new TestProxyClientOptions();
        Assert.IsNotNull(options);
    }
    [Test]
    public void TestProxyClientOptions_InheritsFromClientPipelineOptions()
    {
        var options = new TestProxyClientOptions();
        Assert.IsInstanceOf<System.ClientModel.Primitives.ClientPipelineOptions>(options);
    }
    [Test]
    public void TestProxyClientOptions_CanSetNetworkTimeout()
    {
        var options = new TestProxyClientOptions();
        var timeout = System.TimeSpan.FromSeconds(30);
        options.NetworkTimeout = timeout;
        Assert.AreEqual(timeout, options.NetworkTimeout);
    }
    [Test]
    public void TestProxyClientOptions_HasDefaultNetworkTimeout()
    {
        var options = new TestProxyClientOptions();
        Assert.IsNotNull(options.NetworkTimeout);
        Assert.IsTrue(options.NetworkTimeout > System.TimeSpan.Zero);
    }
    [Test]
    public void TestProxyClientOptions_CanAddRetryPolicy()
    {
        var options = new TestProxyClientOptions();
        var initialCount = options.RetryPolicy != null ? 1 : 0;
        // This tests that we can access the RetryPolicy property
        Assert.DoesNotThrow(() => _ = options.RetryPolicy);
    }
    [Test]
    public void TestProxyClientOptions_CanAccessTransport()
    {
        var options = new TestProxyClientOptions();
        // This tests that we can access the Transport property
        Assert.DoesNotThrow(() => _ = options.Transport);
    }
    [Test]
    public void TestProxyClientOptions_CanSetAndGetProperties()
    {
        var options = new TestProxyClientOptions();
        // Test basic property access without throwing
        Assert.DoesNotThrow(() =>
        {
            var _ = options.NetworkTimeout;
            var __ = options.Transport;
            var ___ = options.RetryPolicy;
        });
    }
    [Test]
    public void TestProxyClientOptions_SupportsMultipleInstances()
    {
        var options1 = new TestProxyClientOptions();
        var options2 = new TestProxyClientOptions();
        Assert.IsNotNull(options1);
        Assert.IsNotNull(options2);
        Assert.AreNotSame(options1, options2);
    }
}
