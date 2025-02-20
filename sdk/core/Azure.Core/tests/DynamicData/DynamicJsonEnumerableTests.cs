// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace Azure.Core.Tests
{
    internal class DynamicJsonEnumerableTests
    {
        [Test]
        [Ignore("Disallowing general IEnumerable support in current version.")]
        public void CanConvertToIntEnumerable()
        {
            dynamic jsonData = DynamicJsonTests.GetDynamicJson("[0, 1, 2, 3]");

            IEnumerable<int> enumerable = (IEnumerable<int>)jsonData;
            int expected = 0;
            foreach (int i in enumerable)
            {
                Assert.AreEqual(expected++, i);
            }
        }

        [Test]
        [Ignore("BinaryOperation fails to bind in net462.")]
        public void CanConvertToIntEnumerableWithChanges_AddAssign()
        {
            dynamic jsonData = DynamicJsonTests.GetDynamicJson("[0, 1, 2, 3]");

            for (int i = 0; i < 4; i++)
            {
                jsonData[i] += 1;
            }

            IEnumerable<int> enumerable = (IEnumerable<int>)jsonData;
            int expected = 1;
            foreach (int i in enumerable)
            {
                Assert.AreEqual(expected++, i);
            }
        }

        [Test]
        [Ignore("Disallowing general IEnumerable support in current version.")]
        public void CanConvertToIntEnumerableWithChanges()
        {
            dynamic jsonData = DynamicJsonTests.GetDynamicJson("[0, 1, 2, 3]");

            for (int i = 0; i < 4; i++)
            {
                jsonData[i] = i + 1;
            }

            IEnumerable<int> enumerable = (IEnumerable<int>)jsonData;
            int expected = 1;
            foreach (int i in enumerable)
            {
                Assert.AreEqual(expected++, i);
            }
        }

        [Test]
        public void CanForEachOverIntArray()
        {
            dynamic jsonData = DynamicJsonTests.GetDynamicJson("[0, 1, 2, 3]");
            int expected = 0;
            foreach (int i in jsonData)
            {
                Assert.AreEqual(expected++, i);
            }
        }

        [Test]
        public void CanForEachOverObject()
        {
            dynamic json = DynamicJsonTests.GetDynamicJson("""
                {
                  "Zero" : 0,
                  "One" : 1,
                  "Two" : 2,
                  "Three" : 3
                }
                """);

            string[] expectedNames = new string[] { "Zero", "One", "Two", "Three" };

            int expected = 0;
            foreach (dynamic property in json)
            {
                Assert.AreEqual(expectedNames[expected], property.Name);
                Assert.IsTrue(expected == property.Value);
                expected++;
            }
        }

        [Test]
        public void CanForEachOverObjectWithChanges()
        {
            dynamic json = DynamicJsonTests.GetDynamicJson("""
                {
                  "Zero" : 0,
                  "One" : 1,
                  "Two" : 2,
                  "Three" : 3
                }
                """);

            string[] expectedNames = new string[] { "Zero", "One", "Two", "Three" };

            for (int i = 0; i < 4; i++)
            {
                json[expectedNames[i]] = i + 1;
            }

            int index = 0;
            foreach (dynamic property in json)
            {
                Assert.AreEqual(expectedNames[index], property.Name);
                Assert.IsTrue(index + 1 == property.Value);
                index++;
            }
        }

        [Test]
        public void CannotEnumerateNonEnumerable()
        {
            dynamic json = DynamicJsonTests.GetDynamicJson("""
                {
                  "foo" : 0,
                  "bar" : true
                }
                """);

            Assert.Throws<InvalidCastException>(() =>
            {
                foreach (dynamic value in json.Foo)
                { }
            });

            Assert.Throws<InvalidCastException>(() =>
            {
                foreach (dynamic value in json.Bar)
                { }
            });
        }

        [Test]
        public void CanEnumerateNestedValues()
        {
            dynamic json = DynamicJsonTests.GetDynamicJson("""
                {
                    "array" : [ 0, 1, 2 ],
                    "object" : {   
                        "zero" : 0,
                        "one" : 1,
                        "two" : 2
                    }
                }
                """);

            int expected = 0;
            foreach (dynamic value in json.Array)
            {
                Assert.IsTrue(expected++ == value);
            }

            expected = 0;
            string[] expectedNames = new string[] { "zero", "one", "two" };

            foreach (dynamic property in json.Object)
            {
                Assert.AreEqual(expectedNames[expected], property.Name);
                Assert.IsTrue(expected == property.Value);
                expected++;
            }
        }

        [Test]
        public void PropertyEnumeratorIncludesAddedProperties()
        {
            dynamic json = DynamicJsonTests.GetDynamicJson("""
                {
                    "object" : {   
                        "zero" : 0,
                        "one" : 1,
                        "two" : 2
                    }
                }
                """);

            json.Object.Three = 3;
            int expected = 0;
            string[] expectedNames = new string[] { "zero", "one", "two", "three" };

            foreach (dynamic property in json.Object)
            {
                Assert.AreEqual(expectedNames[expected], property.Name);
                Assert.IsTrue(expected == property.Value);
                expected++;
            }
        }

        [Test]
        public void ArrayEnumeratorUsesChanges()
        {
            dynamic json = DynamicJsonTests.GetDynamicJson("""
                {
                    "object" : {   
                        "zero" : 0,
                        "one" : 1,
                        "two" : 2
                    }
                }
                """);

            // Existing Property
            json.Object.Two = new[] { 21, 22, 23 };

            // New Property
            json.Object.Three = new[] { 31, 32, 33 };

            int expected = 21;
            Assert.AreEqual(3, json.Object.Two.Length);
            foreach (dynamic value in json.Object.Two)
            {
                Assert.AreEqual(expected++, (int)value);
            }

            expected = 31;
            Assert.AreEqual(3, json.Object.Three.Length);
            foreach (dynamic value in json.Object.Three)
            {
                Assert.AreEqual(expected++, (int)value);
            }

            // Verify changes over the change are recognized
            json.Object.Two[1] = 23;
            json.Object.Two[2] = 25;

            expected = 21;
            Assert.AreEqual(3, json.Object.Two.Length);
            foreach (dynamic value in json.Object.Two)
            {
                Assert.AreEqual(expected, (int)value);
                expected += 2;
            }
        }

        [Test]
        public void PropertyEnumeratorIncludesAddedPropertiesOverChanges()
        {
            dynamic json = DynamicJsonTests.GetDynamicJson("""
                {
                    "foo" : {   
                        "zero" : 0,
                        "one" : 1,
                        "two" : 2
                    }
                }
                """);

            var update = new
            {
                a = "a",
                b = "b"
            };

            // Existing Property
            json.foo = update;

            // New Property
            json.bar = update;

            int i = 0;
            string[] expected = new string[] { "a", "b" };

            foreach (dynamic property in json.foo)
            {
                Assert.AreEqual(expected[i], property.Name);
                Assert.AreEqual(expected[i], (string)property.Value);
                i++;
            }

            i = 0;
            foreach (dynamic property in json.bar)
            {
                Assert.AreEqual(expected[i], property.Name);
                Assert.AreEqual(expected[i], (string)property.Value);
                i++;
            }

            // Add to update
            json.foo.c = "c";
            json.bar.c = "c";

            i = 0;
            expected = new string[] { "a", "b", "c" };
            foreach (dynamic property in json.foo)
            {
                Assert.AreEqual(expected[i], property.Name);
                Assert.AreEqual(expected[i], (string)property.Value);
                i++;
            }

            i = 0;
            foreach (dynamic property in json.bar)
            {
                Assert.AreEqual(expected[i], property.Name);
                Assert.AreEqual(expected[i], (string)property.Value);
                i++;
            }
        }

        [Test]
        public void PropertyEnumeratorExcludesRemovedProperties()
        {
            dynamic json = DynamicJsonTests.GetDynamicJson("""
                {
                    "object" : {   
                        "zero" : 0,
                        "one" : 1,
                        "two" : 2
                    }
                }
                """);

            json.Object = new { one = 1, two = 2 };
            int expected = 0;
            string[] expectedNames = new string[] { "one", "two" };

            foreach (dynamic property in json.Object)
            {
                Assert.AreEqual(expectedNames[expected], property.Name);
                Assert.IsTrue(++expected == property.Value);
            }
        }
    }
}
