// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Diagnostics;
using NUnit.Framework;
using OpenAI.TestFramework.Adapters;
using OpenAI.TestFramework.Mocks;

namespace OpenAI.TestFramework.Tests;

[TestFixture]
public class AdaptersTests
{
    public CancellationToken Token =>
        new CancellationTokenSource(Debugger.IsAttached
            ? TimeSpan.FromMinutes(15)
            : TimeSpan.FromSeconds(5))
        .Token;

    [Test]
    public async Task TestSyncToAsyncEnumerator()
    {
        const int start = 0;
        const int num = 100;

        IEnumerator<int> sync = Enumerable.Range(start, num).GetEnumerator();
        await using SyncToAsyncEnumerator<int> async = new(sync, Token);

        for (int i = start; i < num; i++)
        {
            bool success = await async.MoveNextAsync();
            Assert.That(success, Is.True);
            Assert.That(async.Current, Is.EqualTo(i));
        }
    }

    [Test]
    public async Task TestSyncToAsyncResultCollection()
    {
        const int start = 0;
        const int num = 100;

        MockCollectionResult<int> sync = new(() => Enumerable.Range(start, num));
        SyncToAsyncCollectionResult<int> asyncAdapter = new(sync);

        await using var asyncEnumerator = asyncAdapter.GetAsyncEnumerator(Token);

        for (int i = start; i < num; i++)
        {
            bool success = await asyncEnumerator.MoveNextAsync();
            Assert.That(success, Is.True);
            Assert.That(asyncEnumerator.Current, Is.EqualTo(i));
        }
    }

    [Test]
    public async Task TestFailedSyncToAsyncResultCollection()
    {
        MockCollectionResult<int> sync = new(Fail);
        SyncToAsyncCollectionResult<int> asyncAdapter = new(sync);

        await using var asyncEnumerator = asyncAdapter.GetAsyncEnumerator(Token);
        Assert.ThrowsAsync<ApplicationException>(() => asyncEnumerator.MoveNextAsync().AsTask());
    }

    private static IEnumerable<int> Fail()
    {
        throw new ApplicationException("This should fail");
    }
}
