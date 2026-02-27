// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NUnit.Framework;

namespace System.ClientModel.Tests.Results;

public class CollectionResultFromPagesTests
{
    #region CollectionResult<T>.FromPages

    [Test]
    public void CanCreateSyncCollectionFromPages()
    {
        var pages = new[]
        {
            new[] { 1, 2 },
            new[] { 3, 4 }
        };

        CollectionResult<int> collection = CollectionResult<int>.FromPages(pages);

        Assert.AreEqual(new[] { 1, 2, 3, 4 }, collection.ToList());
    }

    [Test]
    public void CanCreateSyncCollectionFromSinglePage()
    {
        var pages = new[]
        {
            new[] { 10, 20, 30 }
        };

        CollectionResult<int> collection = CollectionResult<int>.FromPages(pages);

        Assert.AreEqual(new[] { 10, 20, 30 }, collection.ToList());
    }

    [Test]
    public void CanCreateSyncCollectionFromEmptyPages()
    {
        var pages = Array.Empty<IEnumerable<int>>();

        CollectionResult<int> collection = CollectionResult<int>.FromPages(pages);

        Assert.IsEmpty(collection.ToList());
    }

    [Test]
    public void SyncCollectionGetRawPagesReturnsCorrectPageCount()
    {
        var pages = new[]
        {
            new[] { 1, 2 },
            new[] { 3 },
            new[] { 4, 5, 6 }
        };

        CollectionResult<int> collection = CollectionResult<int>.FromPages(pages);

        List<ClientResult> rawPages = collection.GetRawPages().ToList();

        Assert.AreEqual(3, rawPages.Count);
    }

    [Test]
    public void SyncCollectionContinuationTokenIsNullForLastPage()
    {
        var pages = new[]
        {
            new[] { 1, 2 },
            new[] { 3, 4 }
        };

        CollectionResult<int> collection = CollectionResult<int>.FromPages(pages);

        List<ClientResult> rawPages = collection.GetRawPages().ToList();

        Assert.IsNotNull(collection.GetContinuationToken(rawPages[0]));
        Assert.IsNull(collection.GetContinuationToken(rawPages[1]));
    }

    [Test]
    public void SyncCollectionContinuationTokenIsNullForSinglePage()
    {
        var pages = new[]
        {
            new[] { 1 }
        };

        CollectionResult<int> collection = CollectionResult<int>.FromPages(pages);

        List<ClientResult> rawPages = collection.GetRawPages().ToList();

        Assert.AreEqual(1, rawPages.Count);
        Assert.IsNull(collection.GetContinuationToken(rawPages[0]));
    }

    [Test]
    public void SyncFromPagesThrowsOnNull()
    {
        Assert.Throws<ArgumentNullException>(() =>
        {
            CollectionResult<int>.FromPages(null!);
        });
    }

    [Test]
    public void SyncCollectionWithStringValues()
    {
        var pages = new[]
        {
            new[] { "a", "b" },
            new[] { "c" }
        };

        CollectionResult<string> collection = CollectionResult<string>.FromPages(pages);

        Assert.AreEqual(new[] { "a", "b", "c" }, collection.ToList());
    }

    #endregion

    #region AsyncCollectionResult<T>.FromPages

    [Test]
    public async Task CanCreateAsyncCollectionFromPages()
    {
        var pages = new[]
        {
            new[] { 1, 2 },
            new[] { 3, 4 }
        };

        AsyncCollectionResult<int> collection = AsyncCollectionResult<int>.FromPages(pages);

        List<int> values = await ToListAsync(collection);

        Assert.AreEqual(new[] { 1, 2, 3, 4 }, values);
    }

    [Test]
    public async Task CanCreateAsyncCollectionFromSinglePage()
    {
        var pages = new[]
        {
            new[] { 10, 20, 30 }
        };

        AsyncCollectionResult<int> collection = AsyncCollectionResult<int>.FromPages(pages);

        List<int> values = await ToListAsync(collection);

        Assert.AreEqual(new[] { 10, 20, 30 }, values);
    }

    [Test]
    public async Task CanCreateAsyncCollectionFromEmptyPages()
    {
        var pages = Array.Empty<IEnumerable<int>>();

        AsyncCollectionResult<int> collection = AsyncCollectionResult<int>.FromPages(pages);

        List<int> values = await ToListAsync(collection);

        Assert.IsEmpty(values);
    }

    [Test]
    public async Task AsyncCollectionGetRawPagesReturnsCorrectPageCount()
    {
        var pages = new[]
        {
            new[] { 1, 2 },
            new[] { 3 },
            new[] { 4, 5, 6 }
        };

        AsyncCollectionResult<int> collection = AsyncCollectionResult<int>.FromPages(pages);

        List<ClientResult> rawPages = await ToListAsync(collection.GetRawPagesAsync());

        Assert.AreEqual(3, rawPages.Count);
    }

    [Test]
    public async Task AsyncCollectionContinuationTokenIsNullForLastPage()
    {
        var pages = new[]
        {
            new[] { 1, 2 },
            new[] { 3, 4 }
        };

        AsyncCollectionResult<int> collection = AsyncCollectionResult<int>.FromPages(pages);

        List<ClientResult> rawPages = await ToListAsync(collection.GetRawPagesAsync());

        Assert.IsNotNull(collection.GetContinuationToken(rawPages[0]));
        Assert.IsNull(collection.GetContinuationToken(rawPages[1]));
    }

    [Test]
    public async Task AsyncCollectionContinuationTokenIsNullForSinglePage()
    {
        var pages = new[]
        {
            new[] { 1 }
        };

        AsyncCollectionResult<int> collection = AsyncCollectionResult<int>.FromPages(pages);

        List<ClientResult> rawPages = await ToListAsync(collection.GetRawPagesAsync());

        Assert.AreEqual(1, rawPages.Count);
        Assert.IsNull(collection.GetContinuationToken(rawPages[0]));
    }

    [Test]
    public void AsyncFromPagesThrowsOnNull()
    {
        Assert.Throws<ArgumentNullException>(() =>
        {
            AsyncCollectionResult<int>.FromPages(null!);
        });
    }

    [Test]
    public async Task AsyncCollectionWithStringValues()
    {
        var pages = new[]
        {
            new[] { "a", "b" },
            new[] { "c" }
        };

        AsyncCollectionResult<string> collection = AsyncCollectionResult<string>.FromPages(pages);

        List<string> values = await ToListAsync(collection);

        Assert.AreEqual(new[] { "a", "b", "c" }, values);
    }

    #endregion

    #region Helpers

    private static async Task<List<T>> ToListAsync<T>(IAsyncEnumerable<T> source)
    {
        List<T> list = new();
        await foreach (T item in source)
        {
            list.Add(item);
        }
        return list;
    }

    #endregion
}
