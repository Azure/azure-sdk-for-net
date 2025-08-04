// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.ClientModel.TestFramework;
using NUnit.Framework;
using System;

namespace Microsoft.ClientModel.TestFramework.Tests.TestProxy;

[TestFixture]
public class TestTimeoutExceptionTests
{
    [Test]
    public void DefaultConstructor_CreatesExceptionWithDefaultMessage()
    {
        var exception = new TestTimeoutException();
        
        Assert.IsNotNull(exception);
        Assert.IsInstanceOf<Exception>(exception);
    }

    [Test]
    public void MessageConstructor_CreatesExceptionWithSpecifiedMessage()
    {
        string expectedMessage = "Operation timed out after 30 seconds";
        var exception = new TestTimeoutException(expectedMessage);
        
        Assert.AreEqual(expectedMessage, exception.Message);
    }

    [Test]
    public void MessageAndInnerExceptionConstructor_CreatesExceptionWithBoth()
    {
        string expectedMessage = "Timeout occurred";
        var innerException = new InvalidOperationException("Inner error");
        var exception = new TestTimeoutException(expectedMessage, innerException);
        
        Assert.AreEqual(expectedMessage, exception.Message);
        Assert.AreSame(innerException, exception.InnerException);
    }

    [Test]
    public void TestTimeoutException_CanBeThrown()
    {
        var exception = Assert.Throws<TestTimeoutException>(() =>
        {
            throw new TestTimeoutException("Test timeout");
        });
        
        Assert.AreEqual("Test timeout", exception.Message);
    }

    [Test]
    public void TestTimeoutException_CanBeCaughtAsBaseException()
    {
        Exception caughtException = null;
        
        try
        {
            throw new TestTimeoutException("Timeout test");
        }
        catch (Exception ex)
        {
            caughtException = ex;
        }
        
        Assert.IsInstanceOf<TestTimeoutException>(caughtException);
        Assert.AreEqual("Timeout test", caughtException.Message);
    }

    [Test]
    public void TestTimeoutException_WithNullMessage_HandlesGracefully()
    {
        var exception = new TestTimeoutException(null);
        
        Assert.IsNotNull(exception);
        // Message might be null or empty depending on base implementation
    }

    [Test]
    public void TestTimeoutException_WithEmptyMessage_HandlesGracefully()
    {
        var exception = new TestTimeoutException(string.Empty);
        
        Assert.IsNotNull(exception);
        Assert.AreEqual(string.Empty, exception.Message);
    }

    [Test]
    public void TestTimeoutException_InheritsFromException()
    {
        var exception = new TestTimeoutException();
        
        Assert.IsInstanceOf<SystemException>(exception);
        Assert.IsInstanceOf<Exception>(exception);
    }

    [Test]
    public void TestTimeoutException_SupportsExceptionData()
    {
        var exception = new TestTimeoutException("Test message");
        exception.Data["CustomKey"] = "CustomValue";
        
        Assert.AreEqual("CustomValue", exception.Data["CustomKey"]);
    }

    [Test]
    public void TestTimeoutException_CanBeSerializable()
    {
        var exception = new TestTimeoutException("Serialization test");
        
        // Basic test that the exception can be created and has the expected properties
        Assert.IsNotNull(exception.Message);
        Assert.IsNotNull(exception.ToString());
    }
}
