// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using Azure.Core.Json;
using NUnit.Framework;

namespace Azure.Core.Tests
{
    internal class MutableJsonDocumentChangeTrackerTests
    {
        [Test]
        public void CanCompareChangesByPath()
        {
            char delimiter = MutableJsonDocument.ChangeTracker.Delimiter;

            // Test IsLessThan
            Assert.IsTrue(CreateChange("a").IsLessThan("b".AsSpan()));
            Assert.IsTrue(CreateChange("a").IsLessThan($"a{delimiter}a".AsSpan()));

            Assert.IsFalse(CreateChange("a").IsLessThan("a".AsSpan()));

            Assert.IsFalse(CreateChange("b").IsLessThan("a".AsSpan()));
            Assert.IsFalse(CreateChange($"a{delimiter}a").IsLessThan("a".AsSpan()));

            // Test IsGreaterThan
            Assert.IsTrue(CreateChange("b").IsGreaterThan("a".AsSpan()));
            Assert.IsTrue(CreateChange($"a{delimiter}a").IsGreaterThan("a".AsSpan()));

            Assert.IsFalse(CreateChange("a").IsGreaterThan("a".AsSpan()));

            Assert.IsFalse(CreateChange("a").IsGreaterThan("b".AsSpan()));
            Assert.IsFalse(CreateChange("a").IsGreaterThan($"a{delimiter}a".AsSpan()));
        }

        [Test]
        public void CanGetSortedChanges()
        {
            MutableJsonDocument.ChangeTracker changeTracker = new();
            char delimiter = MutableJsonDocument.ChangeTracker.Delimiter;

            changeTracker.AddChange("a", 1);
            changeTracker.AddChange("b", 1);
            changeTracker.AddChange($"a{delimiter}a", 1);
            changeTracker.AddChange("a", 2);

            List<MutableJsonChange> changes = new();

            MutableJsonChange? change = changeTracker.GetFirstMergePatchChange(ReadOnlySpan<char>.Empty, out int length);

            Assert.AreEqual(3, length);

            while (change != null)
            {
                changes.Add(change.Value);
                change = changeTracker.GetNextMergePatchChange(ReadOnlySpan<char>.Empty, change.Value.Path.AsSpan());
            }

            // Note, descendants are ignored
            Assert.AreEqual(2, changes.Count);
            Assert.AreEqual("a", changes[0].Path);
            Assert.AreEqual("b", changes[1].Path);
        }

        #region Helpers
        private MutableJsonChange CreateChange(string name)
        {
            return new MutableJsonChange(name, -1, null, MutableJsonChangeKind.PropertyUpdate, null);
        }
        #endregion
    }
}
