// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel;
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

    [Test]
    public async Task TestSyncToAsyncPageableCollection()
    {
        const int start = 0;
        const int num = 100;
        const int itemsPerPage = 10;
        int expectedPages = (int)Math.Ceiling((double)num / itemsPerPage);

        MockPageCollection<int> sync = new(() => Enumerable.Range(start, num), new MockPipelineResponse(), itemsPerPage);
        SyncToAsyncPageCollection<int> asyncAdapter = new(sync);

        int numPages = 0;
        int expected = 0;
        await foreach (var page in asyncAdapter)
        {
            numPages++;
            foreach (int actual in page.Values)
            {
                Assert.That(actual, Is.EqualTo(expected));
                expected++;
            }
        }

        Assert.That(numPages, Is.EqualTo(expectedPages));
    }

    [Test]
    public async Task TestFailedSyncToAsyncPageableCollection()
    {
        MockPageCollection<int> sync = new(Fail, new MockPipelineResponse());
        SyncToAsyncPageCollection<int> asyncAdapter = new(sync);

        await using var asyncEnumerator = ((IAsyncEnumerable<PageResult<int>>)asyncAdapter).GetAsyncEnumerator(Token);
        Assert.ThrowsAsync<ApplicationException>(() => asyncEnumerator.MoveNextAsync().AsTask());
    }

    private static IEnumerable<int> Fail()
    {
        throw new ApplicationException("This should fail");
    }
}
