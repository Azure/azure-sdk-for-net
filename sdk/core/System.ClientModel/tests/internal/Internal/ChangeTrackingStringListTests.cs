// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Internal;
using NUnit.Framework;

namespace System.ClientModel.Tests.Internal;

internal class ChangeTrackingStringListTests
{
    [Test]
    public void ChangesPriorToTrackingArentDetected()
    {
        ChangeTrackingStringList list = new() { "a" };

        Assert.IsFalse(list.HasChanged);

        list.Add("b");

        Assert.IsFalse(list.HasChanged);
    }

    [Test]
    public void ChangesAfterTrackingArentDetected()
    {
        ChangeTrackingStringList list = new() { "a" };

        Assert.IsFalse(list.HasChanged);

        list.StartTracking();
        list.StopTracking();

        Assert.IsFalse(list.HasChanged);

        list.Add("b");

        Assert.IsFalse(list.HasChanged);
    }

    [Test]
    public void CanDetectAddChange()
    {
        ChangeTrackingStringList list = new() { "a" };
        list.StartTracking();

        Assert.IsFalse(list.HasChanged);

        list.Add("b");

        Assert.IsTrue(list.HasChanged);
    }

    [Test]
    public void CanDetectSetChange()
    {
        ChangeTrackingStringList list = new() { "a" };
        list.StartTracking();

        Assert.IsFalse(list.HasChanged);

        list[0] = "b";

        Assert.IsTrue(list.HasChanged);
    }

    [Test]
    public void CanDetectClearChange()
    {
        ChangeTrackingStringList list = new() { "a" };
        list.StartTracking();

        Assert.IsFalse(list.HasChanged);

        list.Clear();

        Assert.IsTrue(list.HasChanged);
    }

    [Test]
    public void ClearNotAChangeForEmptyList()
    {
        ChangeTrackingStringList list = new();
        list.StartTracking();

        Assert.IsFalse(list.HasChanged);

        list.Clear();

        Assert.IsFalse(list.HasChanged);
    }

    [Test]
    public void CanDetectInsertChange()
    {
        ChangeTrackingStringList list = new() { "a" };
        list.StartTracking();

        Assert.IsFalse(list.HasChanged);

        list.Insert(0, "b");

        Assert.IsTrue(list.HasChanged);
    }

    [Test]
    public void CanDetectRemoveChange()
    {
        ChangeTrackingStringList list = new() { "a" };
        list.StartTracking();

        Assert.IsFalse(list.HasChanged);

        list.Remove("a");

        Assert.IsTrue(list.HasChanged);
    }

    [Test]
    public void RemoveNotAChangeIfNotRemoved()
    {
        ChangeTrackingStringList list = new() { "a" };
        list.StartTracking();

        Assert.IsFalse(list.HasChanged);

        bool removed = list.Remove("b");

        Assert.IsFalse(removed);
        Assert.IsFalse(list.HasChanged);
    }

    [Test]
    public void CanDetectRemoveAtChange()
    {
        ChangeTrackingStringList list = new() { "a" };
        list.StartTracking();

        Assert.IsFalse(list.HasChanged);

        list.RemoveAt(0);

        Assert.IsTrue(list.HasChanged);
    }

    [Test]
    public void RemoveAtNotAChangeIfNotRemoved()
    {
        ChangeTrackingStringList list = new() { "a" };
        list.StartTracking();

        Assert.IsFalse(list.HasChanged);

        Assert.Throws<ArgumentOutOfRangeException>(() => list.RemoveAt(1));

        Assert.IsFalse(list.HasChanged);
    }
}
