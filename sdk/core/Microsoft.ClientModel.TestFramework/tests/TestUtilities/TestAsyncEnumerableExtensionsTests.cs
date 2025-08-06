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
    public async Task ToEnumerableAsync_WithEmptyAsyncEnumerable_ReturnsEmptyList()
    {
        var asyncEnumerable = CreateAsyncEnumerable(new List<int>());
        var result = await asyncEnumerable.ToEnumerableAsync();
        Assert.IsNotNull(result);
        Assert.AreEqual(0, result.Count);
    }
    [Test]
    public async Task ToEnumerableAsync_WithSingleItem_ReturnsListWithOneItem()
    {
        var items = new List<string> { "single-item" };
        var asyncEnumerable = CreateAsyncEnumerable(items);
        var result = await asyncEnumerable.ToEnumerableAsync();
        Assert.IsNotNull(result);
        Assert.AreEqual(1, result.Count);
        Assert.AreEqual("single-item", result[0]);
    }
    [Test]
    public async Task ToEnumerableAsync_WithMultipleItems_ReturnsListWithAllItems()
    {
        var items = new List<int> { 1, 2, 3, 4, 5 };
        var asyncEnumerable = CreateAsyncEnumerable(items);
        var result = await asyncEnumerable.ToEnumerableAsync();
        Assert.IsNotNull(result);
        Assert.AreEqual(5, result.Count);
        CollectionAssert.AreEqual(items, result);
    }
    [Test]
    public async Task ToEnumerableAsync_WithStringItems_PreservesOrder()
    {
        var items = new List<string> { "first", "second", "third", "fourth" };
        var asyncEnumerable = CreateAsyncEnumerable(items);
        var result = await asyncEnumerable.ToEnumerableAsync();
        Assert.IsNotNull(result);
        Assert.AreEqual(4, result.Count);
        for (int i = 0; i < items.Count; i++)
        {
            Assert.AreEqual(items[i], result[i]);
        }
    }
    [Test]
    public async Task ToEnumerableAsync_WithNullItems_HandlesNullsCorrectly()
    {
        var items = new List<string> { "not-null", null, "also-not-null", null };
        var asyncEnumerable = CreateAsyncEnumerable(items);
        var result = await asyncEnumerable.ToEnumerableAsync();
        Assert.IsNotNull(result);
        Assert.AreEqual(4, result.Count);
        Assert.AreEqual("not-null", result[0]);
        Assert.IsNull(result[1]);
        Assert.AreEqual("also-not-null", result[2]);
        Assert.IsNull(result[3]);
    }
    [Test]
    public async Task ToEnumerableAsync_WithLargeCollection_HandlesLargeDataSets()
    {
        var items = Enumerable.Range(1, 1000).ToList();
        var asyncEnumerable = CreateAsyncEnumerable(items);
        var result = await asyncEnumerable.ToEnumerableAsync();
        Assert.IsNotNull(result);
        Assert.AreEqual(1000, result.Count);
        CollectionAssert.AreEqual(items, result);
    }
    [Test]
    public async Task ToEnumerableAsync_WithAsyncDelay_WaitsForAllItems()
    {
        var items = new List<string> { "delayed1", "delayed2", "delayed3" };
        var asyncEnumerable = CreateAsyncEnumerableWithDelay(items, 10);
        var startTime = DateTime.UtcNow;
        var result = await asyncEnumerable.ToEnumerableAsync();
        var endTime = DateTime.UtcNow;
        Assert.IsNotNull(result);
        Assert.AreEqual(3, result.Count);
        CollectionAssert.AreEqual(items, result);
        // Verify some delay occurred (should be at least 30ms for 3 items with 10ms delay each)
        Assert.IsTrue((endTime - startTime).TotalMilliseconds >= 20);
    }
    [Test]
    public async Task ToEnumerableAsync_WithComplexObjects_PreservesObjectReferences()
    {
        var items = new List<TestObject>
        {
            new TestObject { Id = 1, Name = "Object1" },
            new TestObject { Id = 2, Name = "Object2" },
            new TestObject { Id = 3, Name = "Object3" }
        };
        var asyncEnumerable = CreateAsyncEnumerable(items);
        var result = await asyncEnumerable.ToEnumerableAsync();
        Assert.IsNotNull(result);
        Assert.AreEqual(3, result.Count);
        for (int i = 0; i < items.Count; i++)
        {
            Assert.AreSame(items[i], result[i]);
            Assert.AreEqual(items[i].Id, result[i].Id);
            Assert.AreEqual(items[i].Name, result[i].Name);
        }
    }
    [Test]
    public async Task ToEnumerableAsync_CalledMultipleTimes_ReturnsNewListEachTime()
    {
        var items = new List<int> { 1, 2, 3 };
        var asyncEnumerable = CreateAsyncEnumerable(items);
        var result1 = await asyncEnumerable.ToEnumerableAsync();
        var result2 = await asyncEnumerable.ToEnumerableAsync();
        Assert.IsNotNull(result1);
        Assert.IsNotNull(result2);
        Assert.AreNotSame(result1, result2); // Different list instances
        CollectionAssert.AreEqual(result1, result2); // Same content
    }
    [Test]
    public async Task ToEnumerableAsync_WithThrowingAsyncEnumerable_PropagatesException()
    {
        var asyncEnumerable = CreateThrowingAsyncEnumerable<int>();
        var exception = await AsyncAssert.ThrowsAsync<InvalidOperationException>(
            async () => await asyncEnumerable.ToEnumerableAsync());
        Assert.AreEqual("Test exception from async enumerable", exception.Message);
    }
    [Test]
    public async Task ToEnumerableAsync_WithPartiallyThrowingAsyncEnumerable_ReturnsItemsBeforeException()
    {
        var asyncEnumerable = CreatePartiallyThrowingAsyncEnumerable();
        var exception = await AsyncAssert.ThrowsAsync<InvalidOperationException>(
            async () => await asyncEnumerable.ToEnumerableAsync());
        Assert.AreEqual("Partial enumeration exception", exception.Message);
    }
    // Helper methods for creating test async enumerables
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
