// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.Core.Tests
{
    public class ConstraintExtensionsTests
    {
        [Test]
        public void ContainsKeyValueConstraint()
        {
            var map = new Dictionary<string, int>
            {
                ["foo"] = 1,
                ["bar"] = 2,
            };

            // Assert dictionary.
            Assert.That(map, Has.Some.ContainsKeyValue("foo", 1));
            Assert.That(map, Has.None.ContainsKeyValue("baz", 3));

            // Assert with comparer.
            Assert.That(map, Has.One.ContainsKeyValue("FOO", 1).UsingKeyComparer(StringComparer.OrdinalIgnoreCase));
        }

        [Test]
        public void MatchConstraint()
        {
            var items = new Class[]
            {
                new() { A = "foo", B = 1 },
                new() { A = "bar", B = 2 },
            };

            // Assert collections.
            Assert.That(items, Has.All.Match<Class>(c => c.B > 0));
            Assert.That(items, Has.Some.Match<Class>(c => c.A == "foo"));
            Assert.That(items, Has.One.Match<Class>(c => c.A == "bar"));
            Assert.That(items, Has.Some.Not.Match<Class>(c => c.B > 2));

            // Assert a collection item property.
            Assert.That(items, Has.One.Property(nameof(Class.A)).Match<string>(s => s == "foo"));

            // Assert an invalid cast (should not throw).
            Assert.That(items, Has.None.Property(nameof(Class.B)).Match<string>(s => s == "foo"));
        }

        private class Class
        {
            public string A { get; set; }
            public int B { get; set; }
        }
    }
}
