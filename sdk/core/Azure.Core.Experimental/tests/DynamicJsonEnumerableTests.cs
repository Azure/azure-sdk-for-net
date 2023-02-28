// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

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
                Assert.AreEqual(expected, property.Value.GetInt32());
                expected++;
            }
        }
    }
}
