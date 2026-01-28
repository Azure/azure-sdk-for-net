// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using ClientModel.Tests.Mocks;
using NUnit.Framework;
using System.ClientModel.Internal;
using System.ClientModel.Primitives;
using System.Collections.Generic;

namespace System.ClientModel.Tests.Internal;

public class ArrayBackedPropertyBagTests
{
    [Test]
    [TestCase((ulong)1)]
    [TestCase((ulong)2)]
    [TestCase((ulong)3)]
    [TestCase((ulong)5)]
    [TestCase((ulong)20)]
    [TestCase((ulong)1000)]
    public void AddAndGetItems(ulong count)
    {
        var target = new ArrayBackedPropertyBag<ulong, ulong>();
        for (ulong i = 0; i < count; i++)
        {
            target.Set(i, i);
            Assert.That(target.TryGetValue(i, out var value), Is.True);
            Assert.That(value, Is.EqualTo(i));
        }
    }

    [Test]
    public void NoDupeTest()
    {
        ulong readLoops = 1000;
        using PipelineMessage message = new PipelineMessage(new MockPipelineRequest());

        var target = new ArrayBackedPropertyBag<ulong, ulong>();
        for (ulong i = 0; i < 5; i++)
        {
            target.Set(i, i);
            Assert.That(target.TryGetValue(i, out var value), Is.True);
            Assert.That(value, Is.EqualTo(i));
        }
        for (ulong i = 0; i < readLoops; i++)
        {
            target.Set(3, i);
        }
        for (ulong i = 0; i < readLoops; i++)
        {
            target.TryGetValue(4, out ulong _);
        }
    }

    [Test]
    [TestCase((ulong)1)]
    [TestCase((ulong)2)]
    [TestCase((ulong)3)]
    public void DuplicateKeysFetchLastAddedItem(ulong count)
    {
        var target = new ArrayBackedPropertyBag<ulong, ulong>();
        for (ulong i = 1; i <= count; i++)
        {
            target.Set(i, i);
            Assert.That(target.TryGetValue(i, out var value), Is.True);
            Assert.That((ulong)value, Is.EqualTo(i));
        }

        // add a duplicate key and set the value to the negative of its original value
        ulong lastKey = count;
        target.Set(lastKey, lastKey * 10L);
        Assert.That(target.TryGetValue(lastKey, out var newValue), Is.True);
        Assert.That((ulong)newValue, Is.EqualTo(lastKey * 10));
    }

    [Test]
    public void TryGetValueReturnsFalseWhenKeyNotExists()
    {
        var target = new ArrayBackedPropertyBag<ulong, ulong>();
        target.Set(1, 1);

        Assert.That(target.TryGetValue(2, out _), Is.False);
    }

    [Test]
    [TestCase(1, true, new[] { 2, 3, 5, 6 })]
    [TestCase(2, true, new[] { 1, 3, 5, 6 })]
    [TestCase(3, true, new[] { 1, 2, 5, 6 })]
    [TestCase(4, false, new[] { 1, 2, 3, 5, 6 })]
    [TestCase(5, true, new[] { 1, 2, 3, 6 })]
    [TestCase(6, true, new[] { 1, 2, 3, 5 })]
    [TestCase(7, false, new[] { 1, 2, 3, 5, 6 })]
    public void Delete(int keyToDelete, bool isDeleted, int[] expectedKeys)
    {
        var target = new ArrayBackedPropertyBag<int, int>();
        target.Set(1, 1);
        target.Set(2, 2);
        target.Set(3, 3);
        target.Set(5, 5);
        target.Set(6, 6);
        Assert.That(target.TryGetValue(keyToDelete, out _), Is.EqualTo(isDeleted));
        Assert.That(target.TryRemove(keyToDelete), Is.EqualTo(isDeleted));
        Assert.That(target.TryGetValue(keyToDelete, out _), Is.False);
        Assert.That(target.Count, Is.EqualTo(expectedKeys.Length));

        for (var i = 0; i < expectedKeys.Length; i++)
        {
            target.GetAt(i, out var key, out var value);
            Assert.That(key, Is.EqualTo(expectedKeys[i]));
            Assert.That(value, Is.EqualTo(expectedKeys[i]));
        }
    }

    [Test]
    [TestCase(1, 1)]
    [TestCase(2, 1)]
    [TestCase(3, 1)]
    [TestCase(4, 1)]
    [TestCase(4, 2)]
    [TestCase(10, 1)]
    [TestCase(10, 2)]
    [TestCase(30, 1)]
    [TestCase(30, 3)]
    [TestCase(30, 7)]
    public void DeleteMultiple(int total, int increment)
    {
        var target = new ArrayBackedPropertyBag<int, int>();
        var expected = new Dictionary<int, int>();
        for (var key = 0; key < total; key++)
        {
            target.Set(key, key);
            expected.Add(key, key);
        }

        for (var key = 0; key < total; key += increment)
        {
            target.TryRemove(key);
            expected.Remove(key);
        }

        Assert.That(target.Count, Is.EqualTo(expected.Count));
        for (var index = 0; index < expected.Count; index++)
        {
            target.GetAt(index, out var key, out var value);
            Assert.That(value, Is.EqualTo(expected[key]));
        }
    }

    [Test]
    [TestCase(1)]
    [TestCase(2)]
    [TestCase(3)]
    [TestCase(5)]
    [TestCase(10)]
    public void Dispose(int count)
    {
        var target = new ArrayBackedPropertyBag<int, int>();
        for (var key = 0; key < count; key++)
        {
            target.Set(key, key);
        }

        Assert.That(target.Count, Is.EqualTo(count));
        for (var key = 0; key < count; key++)
        {
            Assert.That(target.TryGetValue(key, out var value), Is.True);
            Assert.That(value, Is.EqualTo(key));
        }

        target.Dispose();

#if !DEBUG
            Assert.IsTrue(target.IsEmpty);
            Assert.AreEqual(0, target.Count);
            for (var key = 0; key < count; key++)
            {
                Assert.IsFalse(target.TryGetValue(key, out _));
            }
#endif
    }

    [Test]
    [TestCase(1)]
    [TestCase(2)]
    [TestCase(3)]
    [TestCase(5)]
    [TestCase(10)]
    public void DisposeCreateDispose(int count)
    {
        var first = new ArrayBackedPropertyBag<int, int>();
        for (var key = 0; key < count; key++)
        {
            first.Set(key, key);
        }
        first.Dispose();

        var second = new ArrayBackedPropertyBag<int, int>();
        for (var key = 0; key < count; key++)
        {
            second.Set(key, key);
        }

        first.Dispose();

        Assert.That(second.Count, Is.EqualTo(count));
        for (var key = 0; key < count; key++)
        {
            Assert.That(second.TryGetValue(key, out var value), Is.True);
            Assert.That(value, Is.EqualTo(key));
        }
    }
}
