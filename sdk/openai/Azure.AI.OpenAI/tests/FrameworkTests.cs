// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable enable

using System;
using System.ClientModel;
using System.ClientModel.TestFramework;
using System.ClientModel.TestFramework.Mocks;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.AI.OpenAI.Tests;

public class FrameworkTests(bool useAsync) : SyncAsyncTestBase(useAsync)
{
    private static readonly string EX_MSG = Guid.NewGuid().ToString();

    [Test]
    public void CanGetOriginal()
    {
        MockClient original = new MockClient();

        MockClient instrumented = InstrumentClient(original);
        Assert.That(instrumented, Is.Not.Null);
        Assert.That(ReferenceEquals(original, instrumented), Is.False);
        Assert.That(typeof(MockClient).IsAssignableFrom(instrumented.GetType()), Is.True);

        MockClient recovered = GetOriginalClient(instrumented);
        Assert.That(recovered, Is.Not.Null);
        Assert.That(ReferenceEquals(original, recovered), Is.True);
    }

    [Test]
    public void CanGetContext()
    {
        var context = new MockClientContext();

        MockClient client = InstrumentClient(new MockClient(), context);
        Assert.That(client, Is.Not.Null);

        var recoveredContext = GetClientContext(client) as MockClientContext;
        Assert.That(recoveredContext, Is.Not.Null);
        Assert.That(recoveredContext!.Id, Is.EqualTo(context.Id));
        Assert.That(ReferenceEquals(recoveredContext, context), Is.True);
    }

    [Test]
    public async Task TaskWorks()
    {
        MockClient client = InstrumentClient(new MockClient());
        await client.DoAsync();

        if (IsAsync)
        {
            Assert.That(client.AsyncHit, Is.EqualTo(1));
            Assert.That(client.SyncHit, Is.EqualTo(0));
        }
        else
        {
            Assert.That(client.AsyncHit, Is.EqualTo(0));
            Assert.That(client.SyncHit, Is.EqualTo(1));
        }
    }

    [Test]
    public void FailedTaskWorks()
    {
        MockClient client = InstrumentClient(new MockClient());
        ArgumentException? ex = Assert.ThrowsAsync<ArgumentException>(() => client.FailAsync(EX_MSG));
        Assert.That(ex, Is.Not.Null);
        Assert.That(ex!.Message, Is.EqualTo(EX_MSG));

        if (IsAsync)
        {
            Assert.That(client.AsyncHit, Is.EqualTo(1));
            Assert.That(client.SyncHit, Is.EqualTo(0));
        }
        else
        {
            Assert.That(client.AsyncHit, Is.EqualTo(0));
            Assert.That(client.SyncHit, Is.EqualTo(1));
        }
    }

    [Test]
    public async Task TaskWithResultWorks()
    {
        MockClient client = InstrumentClient(new MockClient());
        int count = await client.CountAsync();

        if (IsAsync)
        {
            Assert.That(count, Is.EqualTo(12));
            Assert.That(client.AsyncHit, Is.EqualTo(1));
            Assert.That(client.SyncHit, Is.EqualTo(0));
        }
        else
        {
            Assert.That(count, Is.EqualTo(5));
            Assert.That(client.AsyncHit, Is.EqualTo(0));
            Assert.That(client.SyncHit, Is.EqualTo(1));
        }
    }

    [Test]
    public void FailedTaskWithResultWorks()
    {
        MockClient client = InstrumentClient(new MockClient());
        ArgumentException? ex = Assert.ThrowsAsync<ArgumentException>(() => client.FailWithResultAsync(EX_MSG));
        Assert.That(ex, Is.Not.Null);
        Assert.That(ex!.Message, Is.EqualTo(EX_MSG));

        if (IsAsync)
        {
            Assert.That(client.AsyncHit, Is.EqualTo(1));
            Assert.That(client.SyncHit, Is.EqualTo(0));
        }
        else
        {
            Assert.That(client.AsyncHit, Is.EqualTo(0));
            Assert.That(client.SyncHit, Is.EqualTo(1));
        }
    }

    [Test]
    public async Task ResultCollectionWorks()
    {
        const int num = 3;
        const int increment = 2;

        MockClient client = InstrumentClient(new MockClient());
        AsyncResultCollection<int> coll = client.ResultCollectionAsync(num, increment);

        Assert.IsNotNull(coll);
        Assert.That(coll.GetRawResponse(), Is.Not.Null);
        Assert.That(coll.GetRawResponse().Status, Is.EqualTo(200));
        Assert.That(coll.GetRawResponse().ReasonPhrase, Is.EqualTo("OK"));

        int numResults = 0;
        await foreach (int i in coll)
        {
            Assert.That(i, Is.EqualTo(numResults * increment));
            numResults++;
        }

        Assert.That(numResults, Is.EqualTo(num));
    }

    [Test]
    public void FailedResultCollection()
    {
        MockClient client = InstrumentClient(new MockClient());

        // For now we mimic how the OpenAI and Azure OpenAI libraries work in that no service requests are sent
        // until we try to enumerate the async collections. So exceptions aren't expected initially
        AsyncResultCollection<int> coll = client.FailResultCollectionAsync(EX_MSG);
        Assert.That(coll, Is.Not.Null);

        IAsyncEnumerator<int> enumerator = coll.GetAsyncEnumerator();
        Assert.That(enumerator, Is.Not.Null);
        ArgumentException? ex = Assert.ThrowsAsync<ArgumentException>(() => enumerator.MoveNextAsync().AsTask());
        Assert.That(ex, Is.Not.Null);
        Assert.That(ex!.Message, Is.EqualTo(EX_MSG));
    }

    #region Helper classes

    public class MockClient
    {
        private int _asyncHit;
        private int _syncHit;

        public virtual int AsyncHit => _asyncHit;
        public virtual int SyncHit => _syncHit;

        public virtual Task DoAsync()
        {
            Interlocked.Increment(ref _asyncHit);
            return Task.Delay(200);
        }

        public virtual void Do()
        {
            Interlocked.Increment(ref _syncHit);
        }

        public virtual Task FailAsync(string message)
        {
            Interlocked.Increment(ref _asyncHit);
            return Task.FromException(new ArgumentException(message));
        }

        public virtual void Fail(string message)
        {
            Interlocked.Increment(ref _syncHit);
            throw new ArgumentException(message);
        }

        public virtual async Task<int> CountAsync()
        {
            Interlocked.Increment(ref _asyncHit);
            await Task.Delay(100).ConfigureAwait(false);
            return 12;
        }

        public virtual int Count()
        {
            Interlocked.Increment(ref _syncHit);
            return 5;
        }

        public virtual Task<int> FailWithResultAsync(string message)
        {
            Interlocked.Increment(ref _asyncHit);
            return Task.FromException<int>(new ArgumentException(message));
        }

        public virtual int FailWithResult(string message)
        {
            Interlocked.Increment(ref _syncHit);
            throw new ArgumentException(message);
        }

        public virtual AsyncResultCollection<int> ResultCollectionAsync(int num, int increment = 5)
        {
            return new MockAsyncResultCollection<int>(() => EnumerateAsync(num, increment));
        }

        public virtual ResultCollection<int> ResultCollection(int num, int increment = 5)
        {
            return new MockResultCollection<int>(() => Enumerate(num, increment));
        }

        public virtual AsyncResultCollection<int> FailResultCollectionAsync(string message)
        {
            return new MockAsyncResultCollection<int>(() => FailEnumerateAsync(message));
        }

        public virtual ResultCollection<int> FailResultCollection(string message)
        {
            return new MockResultCollection<int>(() => FailEnumerate(message));
        }

        private class CounterAsyncCollection : AsyncResultCollection<int>
        {
            public override IAsyncEnumerator<int> GetAsyncEnumerator(CancellationToken cancellationToken = default)
            {
                throw new NotImplementedException();
            }
        }

        private async IAsyncEnumerable<int> EnumerateAsync(int num, int increment, [EnumeratorCancellation] CancellationToken token = default)
        {
            int running = 0;
            for (int i = 0; i < num; i++, running += increment)
            {
                await Task.Delay(100);
                yield return running;
            }
        }

        private IEnumerable<int> Enumerate(int num, int increment)
        {
            int running = 0;
            for (int i = 0; i < num; i++, running += increment)
            {
                yield return running;
            }
        }

        private async IAsyncEnumerable<int> FailEnumerateAsync(string message, [EnumeratorCancellation] CancellationToken token = default)
        {
            bool c = true;
            await Task.Delay(100).ConfigureAwait(false);
            if (c)
            {
                throw new ArgumentException(message);
            }

            yield break;
        }

        private IEnumerable<int> FailEnumerate(string message)
        {
            throw new ArgumentException(message);
        }
    }

    private class MockClientContext
    {
        public string Id { get; } = Guid.NewGuid().ToString();
    }

    #endregion
}
