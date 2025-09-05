// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Microsoft.ClientModel.TestFramework.Tests;

[TestFixture]
public class TestRetryHelperTests
{
    [Test]
    public async Task SuccessfulOperationReturnsResultImmediately()
    {
        var helper = new TestRetryHelper(noWait: true);
        var expectedResult = "success";
        Func<Task<string>> operation = () => Task.FromResult(expectedResult);
        var result = await helper.RetryAsync(operation);
        Assert.That(result, Is.EqualTo(expectedResult));
    }

    [Test]
    public async Task SuccessfulOperationAfterFailuresReturnsResult()
    {
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
        var result = await helper.RetryAsync(operation, maxIterations: 5);
        using (Assert.EnterMultipleScope())
        {
            Assert.That(result, Is.EqualTo(expectedResult));
            Assert.That(attemptCount, Is.EqualTo(3));
        }
    }

    [Test]
    public void AllAttemptsFailThrowsAggregateException()
    {
        var helper = new TestRetryHelper(noWait: true);
        var attemptCount = 0;
        Func<Task<string>> operation = () =>
        {
            attemptCount++;
            throw new InvalidOperationException($"Attempt {attemptCount} failed");
        };
        var exception = Assert.ThrowsAsync<AggregateException>(
            () => helper.RetryAsync(operation, maxIterations: 3));
        using (Assert.EnterMultipleScope())
        {
            Assert.That(exception.InnerExceptions.Count, Is.EqualTo(3));
            Assert.That(attemptCount, Is.EqualTo(3));
        }
    }

    [Test]
    public async Task NoWaitDoesNotDelay()
    {
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

        var result = await helper.RetryAsync(operation, maxIterations: 3);
        var elapsed = DateTime.UtcNow - startTime;

        using (Assert.EnterMultipleScope())
        {
            Assert.That(result, Is.EqualTo("success"));
            // Should complete very quickly with no wait
            Assert.That(elapsed.TotalSeconds, Is.LessThan(1.0));
        }
    }

    [Test]
    public async Task RespectsCustomDelay()
    {
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

        var result = await helper.RetryAsync(operation, maxIterations: 3, delay: customDelay);
        var elapsed = DateTime.UtcNow - startTime;

        using (Assert.EnterMultipleScope())
        {
            Assert.That(result, Is.EqualTo("success"));
            // Should have at least the custom delay
            Assert.That(elapsed.TotalMilliseconds, Is.GreaterThan(80));
        }
        Assert.That(elapsed.TotalMilliseconds, Is.LessThan(1000)); // But not the default 5 seconds
    }

    [Test]
    public void RespectsMaxIterations()
    {
        var helper = new TestRetryHelper(noWait: true);
        var attemptCount = 0;
        Func<Task<string>> operation = () =>
        {
            attemptCount++;
            throw new InvalidOperationException("Operation failed");
        };

        var exception = Assert.ThrowsAsync<InvalidOperationException>(
            () => helper.RetryAsync(operation, maxIterations: 0));
        using (Assert.EnterMultipleScope())
        {
            Assert.That(exception.Message, Is.EqualTo("operation failed"));
            Assert.That(attemptCount, Is.EqualTo(0));
        }
    }

    [Test]
    public void CollectsAllExceptions()
    {
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

        var exception = Assert.ThrowsAsync<AggregateException>(
            () => helper.RetryAsync(operation, maxIterations: 3));
        Assert.That(exception.InnerExceptions.Count, Is.EqualTo(3));
        using (Assert.EnterMultipleScope())
        {
            Assert.That(exception.InnerExceptions[0], Is.InstanceOf<ArgumentException>());
            Assert.That(exception.InnerExceptions[1], Is.InstanceOf<InvalidOperationException>());
            Assert.That(exception.InnerExceptions[2], Is.InstanceOf<NotSupportedException>());
        }
    }

    [Test]
    public async Task ReturnsResult()
    {
        var helper = new TestRetryHelper(noWait: true);
        // Test with different return types
        Func<Task<int>> intOperation = () => Task.FromResult(42);
        Func<Task<bool>> boolOperation = () => Task.FromResult(true);
        Func<Task<List<string>>> listOperation = () => Task.FromResult(new List<string> { "test" });

        var intResult = await helper.RetryAsync(intOperation);
        var boolResult = await helper.RetryAsync(boolOperation);
        var listResult = await helper.RetryAsync(listOperation);

        using (Assert.EnterMultipleScope())
        {
            Assert.That(intResult, Is.EqualTo(42));
            Assert.That(boolResult, Is.True);
            Assert.That(listResult.Count, Is.EqualTo(1));
        }
        Assert.That(listResult[0], Is.EqualTo("test"));
    }

    [Test]
    public async Task AsyncOperation()
    {
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

        var result = await helper.RetryAsync(operation);

        using (Assert.EnterMultipleScope())
        {
            Assert.That(result, Is.EqualTo("async success"));
            Assert.That(attemptCount, Is.EqualTo(2));
        }
    }

    [Test]
    public async Task NoWaitIsRespectedWithCustomDelay()
    {
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

        var result = await helper.RetryAsync(operation, delay: customDelay);
        var elapsed = DateTime.UtcNow - startTime;

        using (Assert.EnterMultipleScope())
        {
            Assert.That(result, Is.EqualTo("success"));
            // Should be fast despite custom delay because noWait is true
            Assert.That(elapsed.TotalSeconds, Is.LessThan(1.0));
        }
    }
}
