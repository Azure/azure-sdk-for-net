// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace Microsoft.ClientModel.TestFramework.Tests;

[TestFixture]
public class TestProxyProcessTests
{
    [Test]
    public void TryParsePortParsesHttpPortCorrectly()
    {
        var result = TestProxyProcess.TryParsePort("Now listening on: http://127.0.0.1:5000", "http", out var port);

        using (Assert.EnterMultipleScope())
        {
            Assert.That(result, Is.True, "Should successfully parse HTTP port");
            Assert.That(port, Is.EqualTo(5000), "Should extract correct port number");
        }
    }

    [Test]
    public void TryParsePortHandlesNullOutput()
    {
        var result = TestProxyProcess.TryParsePort(null, "http", out var port);

        using (Assert.EnterMultipleScope())
        {
            Assert.That(result, Is.False, "Should return false for null output");
            Assert.That(port, Is.Null, "Port should remain null");
        }
    }

    [Test]
    public void TryParsePortHandlesInvalidOutput()
    {
        var result = TestProxyProcess.TryParsePort("Some random log message without port info", "http", out var port);
        using (Assert.EnterMultipleScope())
        {
            Assert.That(result, Is.False, "Should return false for invalid output");
            Assert.That(port, Is.Null, "Port should remain null");
        }
    }

    [Test]
    public void TryParsePortHandlesWrongScheme()
    {
        var result = TestProxyProcess.TryParsePort("Now listening on: https://127.0.0.1:5001", "http", out var port);

        using (Assert.EnterMultipleScope())
        {
            Assert.That(result, Is.False, "Should return false for wrong scheme");
            Assert.That(port, Is.Null, "Port should remain null");
        }
    }
}
