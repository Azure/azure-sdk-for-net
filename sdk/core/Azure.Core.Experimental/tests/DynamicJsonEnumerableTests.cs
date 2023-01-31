// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections;
using System.Collections.Generic;
using Azure.Core.Dynamic;
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
        public void CanConvertToIntEnumerableWithChanges()
        {
            dynamic jsonData = DynamicJsonTests.GetDynamicJson("[0, 1, 2, 3]");

            for (int i = 0; i < 4; i++)
            {
                // TODO: Support `++` operator?
                //jsonData[i]++; <-- not supported
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
    }
}
