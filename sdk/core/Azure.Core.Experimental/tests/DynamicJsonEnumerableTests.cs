// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;

namespace Azure.Core.Experimental.Tests
{
    internal class DynamicJsonEnumerableTests
    {
        [Test]
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
        [Ignore("BinaryOperation fails to bind in net461.")]
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
        [Ignore("Needs further investigation.")]
        public void CanConvertToEnumerable()
        {
            dynamic jsonData = DynamicJsonTests.GetDynamicJson("[0, 1, 2, 3]");

            IEnumerable enumerable = (IEnumerable)jsonData;

            int expected = 0;
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
                  "Foo" : 0,
                  "Bar" : true
                }
                """);

            Assert.Throws<InvalidOperationException>(() =>
            {
                foreach (dynamic value in json.Foo)
                { }
            });

            Assert.Throws<InvalidOperationException>(() =>
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
                    "Array" : [ 0, 1, 2 ],
                    "Object" : {   
                        "Zero" : 0,
                        "One" : 1,
                        "Two" : 2
                    }
                }
                """);

            int expected = 0;
            foreach (dynamic value in json.Array)
            {
                Assert.IsTrue(expected++ == value);
            }

            expected = 0;
            string[] expectedNames = new string[] { "Zero", "One", "Two" };

            foreach (dynamic property in json.Object)
            {
                Assert.AreEqual(expectedNames[expected], property.Name);
                Assert.IsTrue(expected == property.Value);
                expected++;
            }
        }
    }
}
