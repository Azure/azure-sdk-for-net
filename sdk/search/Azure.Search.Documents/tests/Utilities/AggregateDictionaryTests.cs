// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace Azure.Search.Documents.Tests.Utilities
{
    public class AggregateDictionaryTests
    {
        [Test]
        public void ConstructorNullThrows() =>
            Assert.Throws<ArgumentNullException>(() => new TestDictionary());

        [Test]
        public void GetIndexKeyNullThrows() =>
            Assert.Throws<ArgumentNullException>(() => { int _ = TestDictionary.Create()[null]; });

        [Test]
        public void GetIndexKeyNotFoundThrows()
        {
            TestDictionary d = TestDictionary.Create();
            Assert.Throws<KeyNotFoundException>(() => { int _ = d["zero"]; });
        }

        [Test]
        public void GetIndex()
        {
            TestDictionary d = TestDictionary.CreateWithData();
            Assert.AreEqual(1, d["one"]);
        }

        [Test]
        public void SetIndexKeyNullThrows() =>
            Assert.Throws<ArgumentNullException>(() => TestDictionary.Create()[null] = 0);

        [Test]
        public void SetIndex() =>
            TestDictionary.Create()["zero"] = 0;

        [Test]
        public void KeysAndValuesGrow()
        {
            TestDictionary d = TestDictionary.Create();
            ICollection<string> keys = d.Keys;
            ICollection<int> values = d.Values;

            Assert.AreEqual(0, keys.Count);
            Assert.AreEqual(0, values.Count);

            d["zero"] = 0;

            Assert.AreEqual(1, keys.Count);
            Assert.AreEqual(1, values.Count);

        }

        [Test]
        public void CountGrows()
        {
            TestDictionary d = TestDictionary.Create();
            Assert.AreEqual(0, d.Count);

            d["zero"] = 0;

            Assert.AreEqual(1, d.Count);
        }

        // TODO: Continue...

        private class TestDictionary : AggregateDictionary<string, int>
        {
            private readonly IDictionary<string, int> _evens;
            private readonly IDictionary<string, int> _odds;

            public TestDictionary() : base(null)
            {
            }

            private TestDictionary(IDictionary<string, int> evens, IDictionary<string, int> odds) :
                base(new[] { evens, odds })
            {
                _evens = evens;
                _odds = odds;
            }

            public static TestDictionary Create(IDictionary<string, int> values = null)
            {
                TestDictionary d = new TestDictionary(new Dictionary<string, int>(), new Dictionary<string, int>());
                if (values != null)
                {
                    foreach (KeyValuePair<string, int> pair in values)
                    {
                        d.Add(pair);
                    }
                }

                return d;
            }

            public static TestDictionary CreateWithData() =>
                Create(new Dictionary<string, int>
                {
                    ["zero"] = 0,
                    ["one"] = 1,
                    ["two"] = 2,
                });

            protected override void Set(string key, int value)
            {
                if (value % 2 == 0)
                {
                    _evens[key] = value;
                }
                else
                {
                    _odds[key] = value;
                }
            }
        }
    }
}
