// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Microsoft.ClientModel.TestFramework.Tests.RecordedTests;

[TestFixture]
public class TestRetryHelperTests
{
    [Test]
    public void Constructor_WithNoWaitTrue_CreatesInstance()
    {
        // Arrange & Act
        var helper = new TestRetryHelper(noWait: true);

        // Assert
        Assert.That(helper, Is.Not.Null);
    }

    [Test]
    public void Constructor_WithNoWaitFalse_CreatesInstance()
    {
        // Arrange & Act
        var helper = new TestRetryHelper(noWait: false);

        // Assert
        Assert.That(helper, Is.Not.Null);
    }

    [Test]
    public async Task RetryAsync_SuccessfulOperation_ReturnsResultImmediately()
    {
        // Arrange
        var helper = new TestRetryHelper(noWait: true);
        var expectedResult = "success";
        
        Func<Task<string>> operation = () => Task.FromResult(expectedResult);

        // Act
        var result = await helper.RetryAsync(operation);

        // Assert
        Assert.That(result, Is.EqualTo(expectedResult));
    }

    [Test]
    public async Task RetryAsync_SuccessfulOperationAfterFailures_ReturnsResult()
    {
        // Arrange
        var helper = new TestRetryHelper(noWait: true);
        var attemptCount = 0;
        var expectedResult = "success";

        Func<Task<string>> operation = () =>
        {
            attemptCount++;
            if (attemptCount < 3)
            {
                throw new InvalidOperationException($"Attempt {attemptCount} failed");
            }
            return Task.FromResult(expectedResult);
        };

        // Act
        var result = await helper.RetryAsync(operation, maxIterations: 5);

        // Assert
        Assert.That(result, Is.EqualTo(expectedResult));
        Assert.That(attemptCount, Is.EqualTo(3));
    }

    [Test]
    public async Task RetryAsync_AllAttemptsFail_ThrowsAggregateException()
    {
        // Arrange
        var helper = new TestRetryHelper(noWait: true);
        var attemptCount = 0;

        Func<Task<string>> operation = () =>
        {
            attemptCount++;
            throw new InvalidOperationException($"Attempt {attemptCount} failed");
        };

        // Act & Assert
        var exception = await TestUtilities.AssertThrowsAsync<AggregateException>(
            () => helper.RetryAsync(operation, maxIterations: 3));

        Assert.That(exception.InnerExceptions.Count, Is.EqualTo(1));
        Assert.That(attemptCount, Is.EqualTo(3));
    }

    [Test]
    public async Task RetryAsync_WithDefaultDelay_UsesDefaultDelayValue()
    {
        // Arrange
        var helper = new TestRetryHelper(noWait: false);
        var startTime = DateTime.UtcNow;
        var attemptCount = 0;

        Func<Task<string>> operation = () =>
        {
            attemptCount++;
            if (attemptCount < 2)
            {
                throw new InvalidOperationException("First attempt failed");
            }
            return Task.FromResult("success");
        };

        // Act
        var result = await helper.RetryAsync(operation, maxIterations: 3);
        var elapsed = DateTime.UtcNow - startTime;

        // Assert
        Assert.That(result, Is.EqualTo("success"));
        // Should have some delay (5 seconds default, but we only verify it's more than a very small amount)
        Assert.That(elapsed.TotalSeconds, Is.GreaterThan(4.0));
    }

    [Test]
    public async Task RetryAsync_WithNoWaitTrue_DoesNotDelay()
    {
        // Arrange
        var helper = new TestRetryHelper(noWait: true);
        var startTime = DateTime.UtcNow;
        var attemptCount = 0;

        Func<Task<string>> operation = () =>
        {
            attemptCount++;
            if (attemptCount < 2)
            {
                throw new InvalidOperationException("First attempt failed");
            }
            return Task.FromResult("success");
        };

        // Act
        var result = await helper.RetryAsync(operation, maxIterations: 3);
        var elapsed = DateTime.UtcNow - startTime;

        // Assert
        Assert.That(result, Is.EqualTo("success"));
        // Should complete very quickly with no wait
        Assert.That(elapsed.TotalSeconds, Is.LessThan(1.0));
    }

    [Test]
    public async Task RetryAsync_WithCustomDelay_UsesCustomDelay()
    {
        // Arrange
        var helper = new TestRetryHelper(noWait: false);
        var customDelay = TimeSpan.FromMilliseconds(100);
        var startTime = DateTime.UtcNow;
        var attemptCount = 0;

        Func<Task<string>> operation = () =>
        {
            attemptCount++;
            if (attemptCount < 2)
            {
                throw new InvalidOperationException("First attempt failed");
            }
            return Task.FromResult("success");
        };

        // Act
        var result = await helper.RetryAsync(operation, maxIterations: 3, delay: customDelay);
        var elapsed = DateTime.UtcNow - startTime;

        // Assert
        Assert.That(result, Is.EqualTo("success"));
        // Should have at least the custom delay
        Assert.That(elapsed.TotalMilliseconds, Is.GreaterThan(80));
        Assert.That(elapsed.TotalMilliseconds, Is.LessThan(1000)); // But not the default 5 seconds
    }

    [Test]
    public async Task RetryAsync_WithMaxIterations_RespectsLimit()
    {
        // Arrange
        var helper = new TestRetryHelper(noWait: true);
        var attemptCount = 0;
        const int maxIterations = 3;

        Func<Task<string>> operation = () =>
        {
            attemptCount++;
            throw new InvalidOperationException($"Attempt {attemptCount} failed");
        };

        // Act & Assert
        await TestUtilities.AssertThrowsAsync<AggregateException>(
            () => helper.RetryAsync(operation, maxIterations: maxIterations));

        Assert.That(attemptCount, Is.EqualTo(maxIterations));
    }

    [Test]
    public async Task RetryAsync_WithZeroMaxIterations_ThrowsImmediately()
    {
        // Arrange
        var helper = new TestRetryHelper(noWait: true);
        var attemptCount = 0;

        Func<Task<string>> operation = () =>
        {
            attemptCount++;
            throw new InvalidOperationException("Operation failed");
        };

        // Act & Assert
        var exception = await TestUtilities.AssertThrowsAsync<InvalidOperationException>(
            () => helper.RetryAsync(operation, maxIterations: 0));

        Assert.That(exception.Message, Is.EqualTo("operation failed"));
        Assert.That(attemptCount, Is.EqualTo(0));
    }

    [Test]
    public async Task RetryAsync_WithDifferentExceptionTypes_CapturesLastException()
    {
        // Arrange
        var helper = new TestRetryHelper(noWait: true);
        var attemptCount = 0;

        Func<Task<string>> operation = () =>
        {
            attemptCount++;
            if (attemptCount == 1)
            {
                throw new ArgumentException("First failure");
            }
            else if (attemptCount == 2)
            {
                throw new InvalidOperationException("Second failure");
            }
            else
            {
                throw new NotSupportedException("Final failure");
            }
        };

        // Act & Assert
        var exception = await TestUtilities.AssertThrowsAsync<AggregateException>(
            () => helper.RetryAsync(operation, maxIterations: 3));

        // Should contain the last exception
        Assert.That(exception.InnerExceptions.Count, Is.EqualTo(1));
        Assert.That(exception.InnerExceptions[0], Is.InstanceOf<NotSupportedException>());
        Assert.That(exception.InnerExceptions[0].Message, Is.EqualTo("Final failure"));
    }

    [Test]
    public async Task RetryAsync_ReturnsCorrectGenericType()
    {
        // Arrange
        var helper = new TestRetryHelper(noWait: true);

        // Test with different return types
        Func<Task<int>> intOperation = () => Task.FromResult(42);
        Func<Task<bool>> boolOperation = () => Task.FromResult(true);
        Func<Task<List<string>>> listOperation = () => Task.FromResult(new List<string> { "test" });

        // Act
        var intResult = await helper.RetryAsync(intOperation);
        var boolResult = await helper.RetryAsync(boolOperation);
        var listResult = await helper.RetryAsync(listOperation);

        // Assert
        Assert.That(intResult, Is.EqualTo(42));
        Assert.That(boolResult, Is.True);
        Assert.That(listResult.Count, Is.EqualTo(1));
        Assert.That(listResult[0], Is.EqualTo("test"));
    }

    [Test]
    public async Task RetryAsync_WithAsyncOperation_WorksCorrectly()
    {
        // Arrange
        var helper = new TestRetryHelper(noWait: true);
        var attemptCount = 0;

        Func<Task<string>> operation = async () =>
        {
            await Task.Delay(10); // Simulate async work
            attemptCount++;
            if (attemptCount < 2)
            {
                throw new InvalidOperationException("Async operation failed");
            }
            return "async success";
        };

        // Act
        var result = await helper.RetryAsync(operation);

        // Assert
        Assert.That(result, Is.EqualTo("async success"));
        Assert.That(attemptCount, Is.EqualTo(2));
    }

    [Test]
    public async Task RetryAsync_DefaultParameters_WorkCorrectly()
    {
        // Arrange
        var helper = new TestRetryHelper(noWait: true);
        var attemptCount = 0;

        Func<Task<string>> operation = () =>
        {
            attemptCount++;
            if (attemptCount < 15) // Less than default 20
            {
                throw new InvalidOperationException("Still failing");
            }
            return Task.FromResult("finally succeeded");
        };

        // Act
        var result = await helper.RetryAsync(operation); // Using default maxIterations and delay

        // Assert
        Assert.That(result, Is.EqualTo("finally succeeded"));
        Assert.That(attemptCount, Is.EqualTo(15));
    }

    [Test]
    public async Task RetryAsync_WithNoWaitFalse_AndCustomDelay_OverridesWithNoWait()
    {
        // Arrange
        var helper = new TestRetryHelper(noWait: true); // noWait should override custom delay
        var customDelay = TimeSpan.FromSeconds(10);
        var startTime = DateTime.UtcNow;
        var attemptCount = 0;

        Func<Task<string>> operation = () =>
        {
            attemptCount++;
            if (attemptCount < 2)
            {
                throw new InvalidOperationException("First attempt failed");
            }
            return Task.FromResult("success");
        };

        // Act
        var result = await helper.RetryAsync(operation, delay: customDelay);
        var elapsed = DateTime.UtcNow - startTime;

        // Assert
        Assert.That(result, Is.EqualTo("success"));
        // Should be fast despite custom delay because noWait is true
        Assert.That(elapsed.TotalSeconds, Is.LessThan(1.0));
    }

    [Test]
    public async Task RetryAsync_ExceptionHandling_PreservesStackTrace()
    {
        // Arrange
        var helper = new TestRetryHelper(noWait: true);

        Func<Task<string>> operation = () =>
        {
            throw new InvalidOperationException("Test exception");
        };

        // Act & Assert
        var exception = await TestUtilities.AssertThrowsAsync<AggregateException>(
            () => helper.RetryAsync(operation, maxIterations: 1));

        Assert.That(exception.InnerExceptions[0].Message, Is.EqualTo("Test exception"));
        Assert.That(exception.InnerExceptions[0].StackTrace, Is.Not.Null);
    }

    [Test]
    public async Task RetryAsync_SuccessOnLastAttempt_ReturnsResult()
    {
        // Arrange
        var helper = new TestRetryHelper(noWait: true);
        var attemptCount = 0;
        const int maxIterations = 5;

        Func<Task<string>> operation = () =>
        {
            attemptCount++;
            if (attemptCount < maxIterations)
            {
                throw new InvalidOperationException($"Attempt {attemptCount} failed");
            }
            return Task.FromResult("success on last attempt");
        };

        // Act
        var result = await helper.RetryAsync(operation, maxIterations: maxIterations);

        // Assert
        Assert.That(result, Is.EqualTo("success on last attempt"));
        Assert.That(attemptCount, Is.EqualTo(maxIterations));
    }
}
