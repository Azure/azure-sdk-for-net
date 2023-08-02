// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
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
            Assert.IsTrue(CreateChange("a").IsLessThan(CreateChange("b")));
            Assert.IsTrue(CreateChange("a").IsLessThan(CreateChange($"a{delimiter}a")));

            Assert.IsFalse(CreateChange("a").IsLessThan(CreateChange("a")));

            Assert.IsFalse(CreateChange("b").IsLessThan(CreateChange("a")));
            Assert.IsFalse(CreateChange($"a{delimiter}a").IsLessThan(CreateChange("a")));

            // Test IsGreaterThan
            Assert.IsTrue(CreateChange("b").IsGreaterThan(CreateChange("a")));
            Assert.IsTrue(CreateChange($"a{delimiter}a").IsGreaterThan(CreateChange("a")));

            Assert.IsFalse(CreateChange("a").IsGreaterThan(CreateChange("a")));

            Assert.IsFalse(CreateChange("a").IsGreaterThan(CreateChange("b")));
            Assert.IsFalse(CreateChange("a").IsGreaterThan(CreateChange($"a{delimiter}a")));
        }

        [Test]
        public void CanGetSortedChanges()
        {
            MutableJsonDocument.ChangeTracker changeTracker = new(null);
            char delimiter = MutableJsonDocument.ChangeTracker.Delimiter;

            changeTracker.AddChange("a", 1);
            changeTracker.AddChange("b", 1);
            changeTracker.AddChange($"a{delimiter}a", 1);
            changeTracker.AddChange("a", 2);

            List<MutableJsonChange> changes = new();

            MutableJsonChange? change = changeTracker.GetNextMergePatchChange(null, out int length);

            Assert.AreEqual(3, length);

            while (change != null)
            {
                changes.Add(change.Value);
                change = changeTracker.GetNextMergePatchChange(change, out length);
            }

            // Note, descendants are ignored
            Assert.AreEqual(2, changes.Count);
            Assert.AreEqual("a", changes[0].Path);
            Assert.AreEqual("b", changes[1].Path);
        }

        #region Helpers
        private MutableJsonChange CreateChange(string name)
        {
            return new MutableJsonChange(name, -1, null, null, MutableJsonChangeKind.PropertyValue, null);
        }
        #endregion
    }
}
