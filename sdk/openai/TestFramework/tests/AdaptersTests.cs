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

        MockResultCollection<int> sync = new(() => Enumerable.Range(start, num));
        SyncToAsyncResultCollection<int> asyncAdapter = new(sync);

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
        MockResultCollection<int> sync = new(Fail);
        SyncToAsyncResultCollection<int> asyncAdapter = new(sync);

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

        MockPageableCollection<int> sync = new(() => Enumerable.Range(start, num), new MockPipelineResponse());
        SyncToAsyncPageableCollection<int> asyncAdapter = new(sync);

        int numPages = 0;
        int expected = 0;
        await foreach (var page in asyncAdapter.AsPages(pageSizeHint: itemsPerPage).WithCancellation(Token))
        {
            numPages++;
            foreach (int actual in page)
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
        MockPageableCollection<int> sync = new(Fail, new MockPipelineResponse());
        SyncToAsyncPageableCollection<int> asyncAdapter = new(sync);

        await using var asyncEnumerator = asyncAdapter.GetAsyncEnumerator(Token);
        Assert.ThrowsAsync<ApplicationException>(() => asyncEnumerator.MoveNextAsync().AsTask());
    }

    private static IEnumerable<int> Fail()
    {
        throw new ApplicationException("This should fail");
    }
}
