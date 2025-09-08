// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.ClientModel.TestFramework.Mocks;
using NUnit.Framework;
using System;
using System.ClientModel.Primitives;
using System.Threading;
using System.Threading.Tasks;

namespace Microsoft.ClientModel.TestFramework.Tests.SyncAsync;

[TestFixture]
public class SyncAsyncPolicyTestBaseTests
{
    #region Constructor

    [Test]
    public void ConstructorSetsIsAsyncTrue()
    {
        var testBase = new TestSyncAsyncPolicyTestBase(true);

        Assert.That(testBase.IsAsync, Is.True);
    }

    [Test]
    public void ConstructorSetsIsAsyncFalse()
    {
        var testBase = new TestSyncAsyncPolicyTestBase(false);

        Assert.That(testBase.IsAsync, Is.False);
    }

    #endregion

    #region ProcessMessage Method

    [Test]
    public void ProcessMessageCallsAsyncForAsyncMode()
    {
        var testBase = new TestSyncAsyncPolicyTestBase(true);
        var message = new MockPipelineMessage();
        var policy = new TestPolicy();

        testBase.ProcessMessage(message, policy);

        using (Assert.EnterMultipleScope())
        {
            Assert.That(policy.ProcessAsyncCalled, Is.True);
            Assert.That(policy.ProcessSyncCalled, Is.False);
        }
    }

    [Test]
    public void ProcessMessageCallsSyncForSyncMode()
    {
        var testBase = new TestSyncAsyncPolicyTestBase(false);
        var message = new MockPipelineMessage();
        var policy = new TestPolicy();

        testBase.ProcessMessage(message, policy);

        using (Assert.EnterMultipleScope())
        {
            Assert.That(policy.ProcessSyncCalled, Is.True);
            Assert.That(policy.ProcessAsyncCalled, Is.False);
        }
    }

    [Test]
    public void ProcessMessageHandlesAsyncExceptions()
    {
        var testBase = new TestSyncAsyncPolicyTestBase(true);
        var message = new MockPipelineMessage();
        var policy = new TestPolicy { ShouldThrowAsync = true };

        Assert.Throws<InvalidOperationException>(() => testBase.ProcessMessage(message, policy));
    }

    [Test]
    public void ProcessMessageHandlesSyncExceptions()
    {
        var testBase = new TestSyncAsyncPolicyTestBase(false);
        var message = new MockPipelineMessage();
        var policy = new TestPolicy { ShouldThrowSync = true };

        Assert.Throws<InvalidOperationException>(() => testBase.ProcessMessage(message, policy));
    }

    [Test]
    public void ProcessMessageWithNextHandlesAsyncExceptions()
    {
        var testBase = new TestSyncAsyncPolicyTestBase(true);
        var message = new MockPipelineMessage();
        var policy = new TestPolicy { ShouldThrowAsyncWithNext = true };
        var next = new TestPolicy();

        Assert.Throws<InvalidOperationException>(() =>
            testBase.ProcessMessage(message, policy, next.ProcessAsync));
    }

    [Test]
    public void ProcessMessageWithNextHandlesSyncExceptions()
    {
        var testBase = new TestSyncAsyncPolicyTestBase(false);
        var message = new MockPipelineMessage();
        var policy = new TestPolicy { ShouldThrowSyncWithNext = true };
        var next = new TestPolicy();

        Assert.Throws<InvalidOperationException>(() =>
            testBase.ProcessMessage(message, policy, next.Process));
    }

    #endregion

    #region Integration Tests

    [Test]
    public void AsyncModeProcessesMessageCorrectly()
    {
        var testBase = new TestSyncAsyncPolicyTestBase(true);
        var message = new MockPipelineMessage();
        var policy = new TestPolicy();

        testBase.ProcessMessage(message, policy);

        using (Assert.EnterMultipleScope())
        {
            Assert.That(policy.ProcessedMessage, Is.SameAs(message));
            Assert.That(policy.ProcessAsyncCalled, Is.True);
        }
    }

    [Test]
    public void SyncModeProcessesMessageCorrectly()
    {
        var testBase = new TestSyncAsyncPolicyTestBase(false);
        var message = new MockPipelineMessage();
        var policy = new TestPolicy();

        testBase.ProcessMessage(message, policy);

        using (Assert.EnterMultipleScope())
        {
            Assert.That(policy.ProcessedMessage, Is.SameAs(message));
            Assert.That(policy.ProcessSyncCalled, Is.True);
        }
    }

    [Test]
    public void AsyncModeWithNextProcessesMessageCorrectly()
    {
        var testBase = new TestSyncAsyncPolicyTestBase(true);
        var message = new MockPipelineMessage();
        var policy = new TestPolicy();
        var next = new TestPolicy();

        testBase.ProcessMessage(message, policy, next.ProcessAsync);

        using (Assert.EnterMultipleScope())
        {
            Assert.That(policy.ProcessedMessage, Is.SameAs(message));
            Assert.That(policy.NextDelegate, Is.Not.Null);
            Assert.That(policy.ProcessAsyncWithNextCalled, Is.True);
        }
    }

    [Test]
    public void SyncModeWithNextProcessesMessageCorrectly()
    {
        var testBase = new TestSyncAsyncPolicyTestBase(false);
        var message = new MockPipelineMessage();
        var policy = new TestPolicy();
        var next = new TestPolicy();

        testBase.ProcessMessage(message, policy, next.Process);

        using (Assert.EnterMultipleScope())
        {
            Assert.That(policy.ProcessedMessage, Is.SameAs(message));
            Assert.That(policy.NextAction, Is.Not.Null);
            Assert.That(policy.ProcessSyncWithNextCalled, Is.True);
        }
    }

    #endregion

    #region Helper Classes

    private class TestSyncAsyncPolicyTestBase : SyncAsyncPolicyTestBase
    {
        public TestSyncAsyncPolicyTestBase(bool isAsync) : base(isAsync) { }
        public void ProcessMessage(PipelineMessage message, TestPolicy policy)
        {
            if (message == null)
                throw new ArgumentNullException(nameof(message));
            if (policy == null)
                throw new ArgumentNullException(nameof(policy));

            if (IsAsync)
            {
                policy.ProcessAsync(message).AsTask().GetAwaiter().GetResult();
            }
            else
            {
                policy.Process(message);
            }
        }

        public void ProcessMessage(PipelineMessage message, TestPolicy policy, Func<PipelineMessage, ValueTask> next)
        {
            if (message == null)
                throw new ArgumentNullException(nameof(message));
            if (policy == null)
                throw new ArgumentNullException(nameof(policy));
            if (next == null)
                throw new ArgumentNullException(nameof(next));

            if (IsAsync)
            {
                policy.ProcessAsync(message, next).AsTask().GetAwaiter().GetResult();
            }
            else
            {
                throw new NotSupportedException("Sync version should use Action, not Func");
            }
        }

        public void ProcessMessage(PipelineMessage message, TestPolicy policy, Action<PipelineMessage> next)
        {
            if (message == null)
                throw new ArgumentNullException(nameof(message));
            if (policy == null)
                throw new ArgumentNullException(nameof(policy));
            if (next == null)
                throw new ArgumentNullException(nameof(next));

            if (!IsAsync)
            {
                policy.Process(message, next);
            }
            else
            {
                throw new NotSupportedException("Async version should use Func, not Action");
            }
        }
    }

    private class TestPolicy
    {
        public bool ProcessAsyncCalled { get; private set; }
        public bool ProcessSyncCalled { get; private set; }
        public bool ProcessAsyncWithNextCalled { get; private set; }
        public bool ProcessSyncWithNextCalled { get; private set; }
        public PipelineMessage ProcessedMessage { get; private set; }
        public Func<PipelineMessage, ValueTask> NextDelegate { get; private set; }
        public Action<PipelineMessage> NextAction { get; private set; }

        public bool ShouldThrowAsync { get; set; }
        public bool ShouldThrowSync { get; set; }
        public bool ShouldThrowAsyncWithNext { get; set; }
        public bool ShouldThrowSyncWithNext { get; set; }

        public ValueTask ProcessAsync(PipelineMessage message)
        {
            ProcessAsyncCalled = true;
            ProcessedMessage = message;

            if (ShouldThrowAsync)
                throw new InvalidOperationException("Test async exception");

            return new ValueTask();
        }        public void Process(PipelineMessage message)
        {
            ProcessSyncCalled = true;
            ProcessedMessage = message;

            if (ShouldThrowSync)
                throw new InvalidOperationException("Test sync exception");
        }

        public ValueTask ProcessAsync(PipelineMessage message, Func<PipelineMessage, ValueTask> next)
        {
            ProcessAsyncWithNextCalled = true;
            ProcessedMessage = message;
            NextDelegate = next;

            if (ShouldThrowAsyncWithNext)
                throw new InvalidOperationException("Test async with next exception");

            return next(message);
        }

        public void Process(PipelineMessage message, Action<PipelineMessage> next)
        {
            ProcessSyncWithNextCalled = true;
            ProcessedMessage = message;
            NextAction = next;

            if (ShouldThrowSyncWithNext)
                throw new InvalidOperationException("Test sync with next exception");

            next(message);
        }
    }

    #endregion
}
