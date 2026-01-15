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
            Assert.That(CreateChange("a").IsLessThan("b".AsSpan()), Is.True);
            Assert.That(CreateChange("a").IsLessThan($"a{delimiter}a".AsSpan()), Is.True);

            Assert.That(CreateChange("a").IsLessThan("a".AsSpan()), Is.False);

            Assert.That(CreateChange("b").IsLessThan("a".AsSpan()), Is.False);
            Assert.That(CreateChange($"a{delimiter}a").IsLessThan("a".AsSpan()), Is.False);

            // Test IsGreaterThan
            Assert.That(CreateChange("b").IsGreaterThan("a".AsSpan()), Is.True);
            Assert.That(CreateChange($"a{delimiter}a").IsGreaterThan("a".AsSpan()), Is.True);

            Assert.That(CreateChange("a").IsGreaterThan("a".AsSpan()), Is.False);

            Assert.That(CreateChange("a").IsGreaterThan("b".AsSpan()), Is.False);
            Assert.That(CreateChange("a").IsGreaterThan($"a{delimiter}a".AsSpan()), Is.False);
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

            Assert.That(length, Is.EqualTo(3));

            while (change != null)
            {
                changes.Add(change.Value);
                change = changeTracker.GetNextMergePatchChange(ReadOnlySpan<char>.Empty, change.Value.Path.AsSpan());
            }

            // Note, descendants are ignored
            Assert.That(changes.Count, Is.EqualTo(2));
            Assert.That(changes[0].Path, Is.EqualTo("a"));
            Assert.That(changes[1].Path, Is.EqualTo("b"));
        }

        #region Helpers
        private MutableJsonChange CreateChange(string name)
        {
            return new MutableJsonChange(name, -1, null, MutableJsonChangeKind.PropertyUpdate, null);
        }
        #endregion
    }
}
