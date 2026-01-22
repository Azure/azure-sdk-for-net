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

        Assert.That(list.HasChanged, Is.False);

        list.Add("b");

        Assert.That(list.HasChanged, Is.True);
    }

    [Test]
    public void CanDetectSetChange()
    {
        ChangeTrackingStringList list = new(["a"]);

        Assert.That(list.HasChanged, Is.False);

        list[0] = "b";

        Assert.That(list.HasChanged, Is.True);
    }

    [Test]
    public void CanDetectClearChange()
    {
        ChangeTrackingStringList list = new(["a"]);

        Assert.That(list.HasChanged, Is.False);

        list.Clear();

        Assert.That(list.HasChanged, Is.True);
    }

    [Test]
    public void ClearNotAChangeForEmptyList()
    {
        ChangeTrackingStringList list = new();

        Assert.That(list.HasChanged, Is.False);

        list.Clear();

        Assert.That(list.HasChanged, Is.False);
    }

    [Test]
    public void CanDetectInsertChange()
    {
        ChangeTrackingStringList list = new(["a"]);

        Assert.That(list.HasChanged, Is.False);

        list.Insert(0, "b");

        Assert.That(list.HasChanged, Is.True);
    }

    [Test]
    public void CanDetectRemoveChange()
    {
        ChangeTrackingStringList list = new(["a"]);

        Assert.That(list.HasChanged, Is.False);

        list.Remove("a");

        Assert.That(list.HasChanged, Is.True);
    }

    [Test]
    public void RemoveNotAChangeIfNotRemoved()
    {
        ChangeTrackingStringList list = new(["a"]);

        Assert.That(list.HasChanged, Is.False);

        bool removed = list.Remove("b");

        Assert.That(removed, Is.False);
        Assert.That(list.HasChanged, Is.False);
    }

    [Test]
    public void CanDetectRemoveAtChange()
    {
        ChangeTrackingStringList list = new(["a"]);

        Assert.That(list.HasChanged, Is.False);

        list.RemoveAt(0);

        Assert.That(list.HasChanged, Is.True);
    }

    [Test]
    public void RemoveAtNotAChangeIfNotRemoved()
    {
        ChangeTrackingStringList list = new(["a"]);

        Assert.That(list.HasChanged, Is.False);

        Assert.Throws<ArgumentOutOfRangeException>(() => list.RemoveAt(1));

        Assert.That(list.HasChanged, Is.False);
    }

    [Test]
    public void CanCreateListFromCollection()
    {
        List<string> originalList = ["a", "b", "c"];
        ChangeTrackingStringList changeTrackingList = new(originalList);

        Assert.That(originalList.Count, Is.EqualTo(changeTrackingList.Count));
        Assert.That(changeTrackingList.Contains(originalList[0]), Is.True);
        Assert.That(changeTrackingList.Contains(originalList[1]), Is.True);
        Assert.That(changeTrackingList.Contains(originalList[2]), Is.True);
    }

    [Test]
    public void CanCreateListFromCollectionAndTrackChanges()
    {
        List<string> originalList = ["a", "b", "c"];
        ChangeTrackingStringList changeTrackingList = new(originalList);

        changeTrackingList.Add("d");

        Assert.That(changeTrackingList.HasChanged, Is.True);
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
