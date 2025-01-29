// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Internal;
using System.Collections.Generic;
using NUnit.Framework;

namespace System.ClientModel.Tests.Internal;

internal class ChangeTrackingStringListTests
{
    [Test]
    public void CanDetectAddChange()
    {
        ChangeTrackingStringList list = new(["a"]);

        Assert.IsFalse(list.HasChanged);

        list.Add("b");

        Assert.IsTrue(list.HasChanged);
    }

    [Test]
    public void CanDetectSetChange()
    {
        ChangeTrackingStringList list = new(["a"]);

        Assert.IsFalse(list.HasChanged);

        list[0] = "b";

        Assert.IsTrue(list.HasChanged);
    }

    [Test]
    public void CanDetectClearChange()
    {
        ChangeTrackingStringList list = new(["a"]);

        Assert.IsFalse(list.HasChanged);

        list.Clear();

        Assert.IsTrue(list.HasChanged);
    }

    [Test]
    public void ClearNotAChangeForEmptyList()
    {
        ChangeTrackingStringList list = new();

        Assert.IsFalse(list.HasChanged);

        list.Clear();

        Assert.IsFalse(list.HasChanged);
    }

    [Test]
    public void CanDetectInsertChange()
    {
        ChangeTrackingStringList list = new(["a"]);

        Assert.IsFalse(list.HasChanged);

        list.Insert(0, "b");

        Assert.IsTrue(list.HasChanged);
    }

    [Test]
    public void CanDetectRemoveChange()
    {
        ChangeTrackingStringList list = new(["a"]);

        Assert.IsFalse(list.HasChanged);

        list.Remove("a");

        Assert.IsTrue(list.HasChanged);
    }

    [Test]
    public void RemoveNotAChangeIfNotRemoved()
    {
        ChangeTrackingStringList list = new(["a"]);

        Assert.IsFalse(list.HasChanged);

        bool removed = list.Remove("b");

        Assert.IsFalse(removed);
        Assert.IsFalse(list.HasChanged);
    }

    [Test]
    public void CanDetectRemoveAtChange()
    {
        ChangeTrackingStringList list = new(["a"]);

        Assert.IsFalse(list.HasChanged);

        list.RemoveAt(0);

        Assert.IsTrue(list.HasChanged);
    }

    [Test]
    public void RemoveAtNotAChangeIfNotRemoved()
    {
        ChangeTrackingStringList list = new(["a"]);

        Assert.IsFalse(list.HasChanged);

        Assert.Throws<ArgumentOutOfRangeException>(() => list.RemoveAt(1));

        Assert.IsFalse(list.HasChanged);
    }

    [Test]
    public void CanCreateListFromCollection()
    {
        List<string> originalList = ["a", "b", "c"];
        ChangeTrackingStringList changeTrackingList = new(originalList);

        Assert.AreEqual(originalList.Count, changeTrackingList.Count);
        Assert.IsTrue(changeTrackingList.Contains(originalList[0]));
        Assert.IsTrue(changeTrackingList.Contains(originalList[1]));
        Assert.IsTrue(changeTrackingList.Contains(originalList[2]));
    }

    [Test]
    public void CanCreateListFromCollectionAndTrackChanges()
    {
        List<string> originalList = ["a", "b", "c"];
        ChangeTrackingStringList changeTrackingList = new(originalList);

        changeTrackingList.Add("d");

        Assert.IsTrue(changeTrackingList.HasChanged);
    }

    [Test]
    public void CannotModifyFrozenList()
    {
        ChangeTrackingStringList list = ["a"];

        list.Add("b");
        list.Add("c");

        list.Freeze();

        Assert.Throws<InvalidOperationException>(() => list.Add("d"));
        Assert.Throws<InvalidOperationException>(() => list[0] = "d");
        Assert.Throws<InvalidOperationException>(() => list.Clear());
        Assert.Throws<InvalidOperationException>(() => list.Insert(0, "d"));
        Assert.Throws<InvalidOperationException>(() => list.Remove("a"));
        Assert.Throws<InvalidOperationException>(() => list.RemoveAt(0));
    }
}
