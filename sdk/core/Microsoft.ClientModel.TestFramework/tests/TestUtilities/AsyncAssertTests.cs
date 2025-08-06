// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
using Microsoft.ClientModel.TestFramework;
using NUnit.Framework;
using System;
using System.Threading.Tasks;
namespace Microsoft.ClientModel.TestFramework.Tests;
[TestFixture]
public class AsyncAssertTests
{
    [Test]
    public async Task ThrowsAsync_WithCorrectExceptionType_ReturnsExpectedException()
    {
        var expectedMessage = "Test exception message";
        Func<Task> action = () => throw new InvalidOperationException(expectedMessage);
        var exception = await AsyncAssert.ThrowsAsync<InvalidOperationException>(action);
        Assert.IsNotNull(exception);
        Assert.AreEqual(expectedMessage, exception.Message);
        Assert.IsInstanceOf<InvalidOperationException>(exception);
    }
    [Test]
    public async Task ThrowsAsync_WithDerivedExceptionType_ReturnsExpectedException()
    {
        Func<Task> action = () => throw new ArgumentNullException("param");
        var exception = await AsyncAssert.ThrowsAsync<ArgumentException>(action);
        Assert.IsNotNull(exception);
        Assert.IsInstanceOf<ArgumentNullException>(exception);
    }
    [Test]
    public void ThrowsAsync_WithWrongExceptionType_ThrowsAssertionException()
    {
        Func<Task> action = () => throw new InvalidOperationException("Wrong exception");
        var assertionException = Assert.ThrowsAsync<NUnit.Framework.AssertionException>(
            async () => await AsyncAssert.ThrowsAsync<ArgumentException>(action));
        Assert.IsTrue(assertionException.Message.Contains("Expected: System.ArgumentException"));
        Assert.IsTrue(assertionException.Message.Contains("But was: System.InvalidOperationException"));
    }
    [Test]
    public void ThrowsAsync_WithNoException_ThrowsAssertionException()
    {
        Func<Task> action = () => Task.CompletedTask;
        var assertionException = Assert.ThrowsAsync<NUnit.Framework.AssertionException>(
            async () => await AsyncAssert.ThrowsAsync<ArgumentException>(action));
        Assert.IsTrue(assertionException.Message.Contains("Expected: System.ArgumentException"));
        Assert.IsTrue(assertionException.Message.Contains("But was: null"));
    }
    [Test]
    public async Task ThrowsAsync_WithAsyncOperation_ReturnsExpectedException()
    {
        Func<Task> action = async () =>
        {
            await Task.Delay(10);
            throw new TimeoutException("Async timeout");
        };
        var exception = await AsyncAssert.ThrowsAsync<TimeoutException>(action);
        Assert.IsNotNull(exception);
        Assert.AreEqual("Async timeout", exception.Message);
    }
    [Test]
    public async Task ThrowsAsync_WithTaskThatThrowsInContinuation_ReturnsExpectedException()
    {
        Func<Task> action = () => Task.FromResult(0).ContinueWith(_ => throw new NotSupportedException("Continuation exception"));
        var exception = await AsyncAssert.ThrowsAsync<NotSupportedException>(action);
        Assert.IsNotNull(exception);
        Assert.AreEqual("Continuation exception", exception.Message);
    }
    [Test]
    public async Task ThrowsAsync_WithAggregateException_ReturnsInnerException()
    {
        Func<Task> action = () =>
        {
            var task = Task.Run(() => throw new ArgumentException("Inner exception"));
            return task;
        };
        var exception = await AsyncAssert.ThrowsAsync<ArgumentException>(action);
        Assert.IsNotNull(exception);
        Assert.AreEqual("Inner exception", exception.Message);
    }
    [Test]
    public async Task ThrowsAsync_WithCustomException_ReturnsExpectedException()
    {
        Func<Task> action = () => throw new CustomTestException("Custom message");
        var exception = await AsyncAssert.ThrowsAsync<CustomTestException>(action);
        Assert.IsNotNull(exception);
        Assert.AreEqual("Custom message", exception.Message);
        Assert.IsInstanceOf<CustomTestException>(exception);
    }
    private class CustomTestException : Exception
    {
        public CustomTestException(string message) : base(message) { }
    }
}
