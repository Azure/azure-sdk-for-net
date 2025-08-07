// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel;
using System.Runtime.CompilerServices;
using OpenAI.TestFramework.Mocks;

namespace OpenAI.TestFramework.Tests.Helpers;

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

    public virtual AsyncCollectionResult<int> ResultCollectionAsync(int num, int increment = 5)
    {
        Interlocked.Increment(ref _asyncHit);
        return new MockAsyncCollectionResult<int>(() => EnumerateAsync(num, increment));
    }

    public virtual CollectionResult<int> ResultCollection(int num, int increment = 5)
    {
        Interlocked.Increment(ref _syncHit);
        return new MockCollectionResult<int>(() => Enumerate(num, increment));
    }

    public virtual AsyncCollectionResult<int> FailResultCollectionAsync(string message)
    {
        Interlocked.Increment(ref _asyncHit);
        return new MockAsyncCollectionResult<int>(() => FailEnumerateAsync(message));
    }

    public virtual CollectionResult<int> FailResultCollection(string message)
    {
        Interlocked.Increment(ref _syncHit);
        return new MockCollectionResult<int>(() => FailEnumerate(message));
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
