// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
using Microsoft.ClientModel.TestFramework;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace Microsoft.ClientModel.TestFramework.Tests;
[TestFixture]
public class TestAsyncEnumerableExtensionsTests
{
    [Test]
    public async Task ToEnumerableAsyncWithEmptyAsyncEnumerableReturnsEmptyList()
    {
        var asyncEnumerable = CreateAsyncEnumerable(new List<int>());
        var result = await asyncEnumerable.ToEnumerableAsync();
        Assert.That(result, Is.Not.Null);
        Assert.That(result.Count, Is.EqualTo(0));
    }

    [Test]
    public async Task ToEnumerableAsyncWithSingleItemReturnsListWithOneItem()
    {
        var items = new List<string> { "single-item" };
        var asyncEnumerable = CreateAsyncEnumerable(items);
        var result = await asyncEnumerable.ToEnumerableAsync();

        Assert.That(result, Is.Not.Null);
        Assert.That(result.Count, Is.EqualTo(1));
        Assert.That(result[0], Is.EqualTo("single-item"));
    }

    [Test]
    public async Task ToEnumerableAsyncWithMultipleItemsReturnsListWithAllItems()
    {
        var items = new List<int> { 1, 2, 3, 4, 5 };
        var asyncEnumerable = CreateAsyncEnumerable(items);
        var result = await asyncEnumerable.ToEnumerableAsync();

        Assert.That(result, Is.Not.Null);
        Assert.That(result.Count, Is.EqualTo(5));
        Assert.That(result, Is.EqualTo(items).AsCollection);
    }

    [Test]
    public async Task ToEnumerableAsyncWithStringItemsPreservesOrder()
    {
        var items = new List<string> { "first", "second", "third", "fourth" };
        var asyncEnumerable = CreateAsyncEnumerable(items);
        var result = await asyncEnumerable.ToEnumerableAsync();

        Assert.That(result, Is.Not.Null);
        Assert.That(result.Count, Is.EqualTo(4));

        for (int i = 0; i < items.Count; i++)
        {
            Assert.That(result[i], Is.EqualTo(items[i]));
        }
    }

    [Test]
    public async Task ToEnumerableAsyncWithNullItemsHandlesNullsCorrectly()
    {
        var items = new List<string> { "not-null", null, "also-not-null", null };
        var asyncEnumerable = CreateAsyncEnumerable(items);
        var result = await asyncEnumerable.ToEnumerableAsync();

        Assert.That(result, Is.Not.Null);
        Assert.That(result.Count, Is.EqualTo(4));
        using (Assert.EnterMultipleScope())
        {
            Assert.That(result[0], Is.EqualTo("not-null"));
            Assert.That(result[1], Is.Null);
            Assert.That(result[2], Is.EqualTo("also-not-null"));
            Assert.That(result[3], Is.Null);
        }
    }

    [Test]
    public async Task ToEnumerableAsyncWithLargeCollectionHandlesLargeDataSets()
    {
        var items = Enumerable.Range(1, 1000).ToList();
        var asyncEnumerable = CreateAsyncEnumerable(items);
        var result = await asyncEnumerable.ToEnumerableAsync();

        Assert.That(result, Is.Not.Null);
        Assert.That(result.Count, Is.EqualTo(1000));
        Assert.That(result, Is.EqualTo(items).AsCollection);
    }

    [Test]
    public async Task ToEnumerableAsyncWithAsyncDelayWaitsForAllItems()
    {
        var items = new List<string> { "delayed1", "delayed2", "delayed3" };
        var asyncEnumerable = CreateAsyncEnumerableWithDelay(items, 10);
        var startTime = DateTime.UtcNow;
        var result = await asyncEnumerable.ToEnumerableAsync();
        var endTime = DateTime.UtcNow;

        Assert.That(result, Is.Not.Null);
        Assert.That(result.Count, Is.EqualTo(3));
        using (Assert.EnterMultipleScope())
        {
            Assert.That(result, Is.EqualTo(items).AsCollection);
            // Verify some delay occurred (should be at least 30ms for 3 items with 10ms delay each)
            Assert.That((endTime - startTime).TotalMilliseconds >= 20, Is.True);
        }
    }

    [Test]
    public async Task ToEnumerableAsyncWithComplexObjectsPreservesObjectReferences()
    {
        var items = new List<TestObject>
        {
            new TestObject { Id = 1, Name = "Object1" },
            new TestObject { Id = 2, Name = "Object2" },
            new TestObject { Id = 3, Name = "Object3" }
        };
        var asyncEnumerable = CreateAsyncEnumerable(items);
        var result = await asyncEnumerable.ToEnumerableAsync();

        Assert.That(result, Is.Not.Null);
        Assert.That(result.Count, Is.EqualTo(3));

        for (int i = 0; i < items.Count; i++)
        {
            Assert.That(result[i], Is.SameAs(items[i]));
            using (Assert.EnterMultipleScope())
            {
                Assert.That(result[i].Id, Is.EqualTo(items[i].Id));
                Assert.That(result[i].Name, Is.EqualTo(items[i].Name));
            }
        }
    }

    [Test]
    public async Task ToEnumerableAsyncCalledMultipleTimesReturnsNewListEachTime()
    {
        var items = new List<int> { 1, 2, 3 };
        var asyncEnumerable = CreateAsyncEnumerable(items);
        var result1 = await asyncEnumerable.ToEnumerableAsync();
        var result2 = await asyncEnumerable.ToEnumerableAsync();

        using (Assert.EnterMultipleScope())
        {
            Assert.That(result1, Is.Not.Null);
            Assert.That(result2, Is.Not.Null);
        }
        Assert.That(result2, Is.Not.SameAs(result1)); // Different list instances
        Assert.That(result2, Is.EqualTo(result1).AsCollection); // Same content
    }

    [Test]
    public void ToEnumerableAsyncWithThrowingAsyncEnumerablePropagatesException()
    {
        var asyncEnumerable = CreateThrowingAsyncEnumerable<int>();
        var exception = Assert.ThrowsAsync<InvalidOperationException>(
            async () => await asyncEnumerable.ToEnumerableAsync());

        Assert.That(exception.Message, Is.EqualTo("Test exception from async enumerable"));
    }

    [Test]
    public void ToEnumerableAsyncWithPartiallyThrowingAsyncEnumerableReturnsItemsBeforeException()
    {
        var asyncEnumerable = CreatePartiallyThrowingAsyncEnumerable();
        var exception = Assert.ThrowsAsync<InvalidOperationException>(
            async () => await asyncEnumerable.ToEnumerableAsync());

        Assert.That(exception.Message, Is.EqualTo("Partial enumeration exception"));
    }

    // Helper methods for creating test async enumerable
    private static async IAsyncEnumerable<T> CreateAsyncEnumerable<T>(IEnumerable<T> items)
    {
        foreach (var item in items)
        {
            await Task.Yield(); // Force async behavior
            yield return item;
        }
    }

    private static async IAsyncEnumerable<T> CreateAsyncEnumerableWithDelay<T>(IEnumerable<T> items, int delayMs)
    {
        foreach (var item in items)
        {
            await Task.Delay(delayMs);
            yield return item;
        }
    }

    private static async IAsyncEnumerable<T> CreateThrowingAsyncEnumerable<T>()
    {
        await Task.Yield();
        throw new InvalidOperationException("Test exception from async enumerable");
#pragma warning disable CS0162 // Unreachable code detected
        yield break;
#pragma warning restore CS0162 // Unreachable code detected
    }

    private static async IAsyncEnumerable<int> CreatePartiallyThrowingAsyncEnumerable()
    {
        yield return 1;
        await Task.Yield();
        yield return 2;
        await Task.Yield();
        throw new InvalidOperationException("Partial enumeration exception");
    }

    private class TestObject
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
    }
}
