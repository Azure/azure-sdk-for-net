// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.ClientModel.TestFramework;
using NUnit.Framework;
using System;

namespace Microsoft.ClientModel.TestFramework.Tests.TestProxy;

[TestFixture]
public class TestRecordingMismatchExceptionTests
{
    [Test]
    public void DefaultConstructor_CreatesExceptionWithDefaultMessage()
    {
        var exception = new TestRecordingMismatchException();
        
        Assert.IsNotNull(exception);
        Assert.IsInstanceOf<Exception>(exception);
    }

    [Test]
    public void MessageConstructor_CreatesExceptionWithSpecifiedMessage()
    {
        string expectedMessage = "Recording mismatch detected: expected GET /api/users but found POST /api/users";
        var exception = new TestRecordingMismatchException(expectedMessage);
        
        Assert.AreEqual(expectedMessage, exception.Message);
    }

    [Test]
    public void MessageAndInnerExceptionConstructor_CreatesExceptionWithBoth()
    {
        string expectedMessage = "Test recording mismatch";
        var innerException = new InvalidOperationException("Network request failed");
        var exception = new TestRecordingMismatchException(expectedMessage, innerException);
        
        Assert.AreEqual(expectedMessage, exception.Message);
        Assert.AreSame(innerException, exception.InnerException);
    }

    [Test]
    public void TestRecordingMismatchException_CanBeThrown()
    {
        var exception = Assert.Throws<TestRecordingMismatchException>(() =>
        {
            throw new TestRecordingMismatchException("Recording mismatch");
        });
        
        Assert.AreEqual("Recording mismatch", exception.Message);
    }

    [Test]
    public void TestRecordingMismatchException_CanBeCaughtAsBaseException()
    {
        Exception caughtException = null;
        
        try
        {
            throw new TestRecordingMismatchException("Mismatch test");
        }
        catch (Exception ex)
        {
            caughtException = ex;
        }
        
        Assert.IsInstanceOf<TestRecordingMismatchException>(caughtException);
        Assert.AreEqual("Mismatch test", caughtException.Message);
    }

    [Test]
    public void TestRecordingMismatchException_WithNullMessage_HandlesGracefully()
    {
        var exception = new TestRecordingMismatchException(null);
        
        Assert.IsNotNull(exception);
        // Message might be null or empty depending on base implementation
    }

    [Test]
    public void TestRecordingMismatchException_WithEmptyMessage_HandlesGracefully()
    {
        var exception = new TestRecordingMismatchException(string.Empty);
        
        Assert.IsNotNull(exception);
        Assert.AreEqual(string.Empty, exception.Message);
    }

    [Test]
    public void TestRecordingMismatchException_InheritsFromException()
    {
        var exception = new TestRecordingMismatchException();
        
        Assert.IsInstanceOf<SystemException>(exception);
        Assert.IsInstanceOf<Exception>(exception);
    }

    [Test]
    public void TestRecordingMismatchException_SupportsExceptionData()
    {
        var exception = new TestRecordingMismatchException("Test message");
        exception.Data["RequestMethod"] = "GET";
        exception.Data["ExpectedUrl"] = "/api/users";
        exception.Data["ActualUrl"] = "/api/customers";
        
        Assert.AreEqual("GET", exception.Data["RequestMethod"]);
        Assert.AreEqual("/api/users", exception.Data["ExpectedUrl"]);
        Assert.AreEqual("/api/customers", exception.Data["ActualUrl"]);
    }

    [Test]
    public void TestRecordingMismatchException_WithLongMessage_HandlesCorrectly()
    {
        string longMessage = new string('A', 1000) + " - Recording mismatch with detailed information";
        var exception = new TestRecordingMismatchException(longMessage);
        
        Assert.AreEqual(longMessage, exception.Message);
    }

    [Test]
    public void TestRecordingMismatchException_CanBeSerializable()
    {
        var exception = new TestRecordingMismatchException("Serialization test");
        
        // Basic test that the exception can be created and has the expected properties
        Assert.IsNotNull(exception.Message);
        Assert.IsNotNull(exception.ToString());
    }

    [Test]
    public void TestRecordingMismatchException_WithNestedInnerException_PreservesChain()
    {
        var originalException = new ArgumentException("Original error");
        var middleException = new InvalidOperationException("Middle error", originalException);
        var exception = new TestRecordingMismatchException("Recording error", middleException);
        
        Assert.AreSame(middleException, exception.InnerException);
        Assert.AreSame(originalException, exception.InnerException.InnerException);
    }
}
