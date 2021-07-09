// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using Azure.AI.MetricsAdvisor.Models;
using NUnit.Framework;

namespace Azure.AI.MetricsAdvisor.Tests
{
    public class DimensionKeyTests
    {
        [Test]
        public void DimensionKeyValidatesArguments()
        {
            Assert.That(() => new DimensionKey(null), Throws.ArgumentNullException);
        }

        [Test]
        public void TryGetValueValidatesArguments()
        {
            var dimensions = new Dictionary<string, string>();
            var dimensionKey = new DimensionKey(dimensions);

            Assert.That(() => dimensionKey.TryGetValue(null, out var _), Throws.ArgumentNullException);
            Assert.That(() => dimensionKey.TryGetValue("", out var _), Throws.ArgumentException);
        }

        [Test]
        public void TryGetValueGetsValues()
        {
            var dimensions = new Dictionary<string, string>() { { "name1", "value1" }, { "name2", "value2" } };
            var dimensionKey = new DimensionKey(dimensions);

            Assert.That(dimensionKey.TryGetValue("name1", out string value1));
            Assert.That(dimensionKey.TryGetValue("name2", out string value2));

            Assert.That(value1, Is.EqualTo("value1"));
            Assert.That(value2, Is.EqualTo("value2"));
        }

        [Test]
        public void TryGetValueReturnsFalseForMissingValue()
        {
            var dimensions = new Dictionary<string, string>() { { "name", "value" } };
            var dimensionKey = new DimensionKey(dimensions);

            Assert.That(dimensionKey.TryGetValue("otherName", out string value), Is.False);
            Assert.That(value, Is.Null);
        }

        [Test]
        public void ContainsValidatesArguments()
        {
            var dimensions = new Dictionary<string, string>();
            var dimensionKey = new DimensionKey(dimensions);

            Assert.That(() => dimensionKey.Contains(null), Throws.ArgumentNullException);
            Assert.That(() => dimensionKey.Contains(""), Throws.ArgumentException);
        }

        [Test]
        public void ContainsChecksDimensions()
        {
            var dimensions = new Dictionary<string, string>() { { "name", "value" } };
            var dimensionKey = new DimensionKey(dimensions);

            Assert.That(dimensionKey.Contains("name"));
            Assert.That(dimensionKey.Contains("otherName"), Is.False);
        }

        [Test]
        public void DimensionKeyEnumeratesDimensions()
        {
            var dimensions = new Dictionary<string, string>() { { "name1", "value1" }, { "name2", "value2" } };
            var dimensionKey = new DimensionKey(dimensions);

            var enumeratedDimensions = new Dictionary<string, string>();

            foreach (KeyValuePair<string, string> column in dimensionKey)
            {
                enumeratedDimensions.Add(column.Key, column.Value);
            }

            Assert.That(enumeratedDimensions, Is.EquivalentTo(dimensions));
        }
    }
}
