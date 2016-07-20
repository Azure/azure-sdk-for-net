// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

namespace Microsoft.Azure.Search.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.Azure.Search.Models;
    using Xunit;

    internal static class SearchAssert
    {
        public static void DocumentsEqual(Document expected, Document actual)
        {
            DictionariesEqual(expected, actual);
        }

        public static void DictionariesEqual(IDictionary<string, object> expected, IDictionary<string, object> actual)
        {
            if (expected == null)
            {
                Assert.Null(actual);
            }

            if (expected.Count != actual.Count)
            {
                string message =
                    String.Format(
                        "Dictionary key count doesn't match. Expected keys: [{0}] Actual keys: [{1}]",
                        String.Join(", ", expected.Keys),
                        String.Join(", ", actual.Keys));

                Assert.True(false, message);
            }

            foreach (string key in expected.Keys)
            {
                Assert.True(actual.ContainsKey(key));

                object expectedObj = expected[key];
                object actualObj = actual[key];

                if (expectedObj == null)
                {
                    Assert.Null(actualObj);
                }
                else
                {
                    Type expectedType = expectedObj.GetType();
                    Type actualType = actualObj.GetType();

                    // Special case for integers.
                    if (expectedType == typeof(long) || actualType == typeof(long))
                    {
                        long expectedLong = Convert.ToInt64(expectedObj);
                        long actualLong = Convert.ToInt64(actualObj);

                        Assert.Equal(expectedLong, actualLong);
                    }
                    else
                    {
                        Assert.IsType(expectedType, actualObj);

                        // Special case for comparing Documents.
                        if (expectedType == typeof(string[]))
                        {
                            Assert.True(((string[])expectedObj).SequenceEqual((string[])actualObj));
                        }
                        else
                        {
                            Assert.Equal(expectedObj, actualObj);
                        }
                    }
                }
            }
        }

        public static void SequenceEqual<T>(
            IEnumerable<T> expected,
            IEnumerable<T> actual,
            Action<T, T> assertElementsEqual = null)
        {
            assertElementsEqual = assertElementsEqual ?? ((a, b) => Assert.Equal(a, b));

            if (expected == null)
            {
                Assert.True(actual == null || !actual.Any());
                return;
            }

            Assert.NotNull(actual);

            T[] expectedArray = expected.ToArray();
            T[] actualArray = actual.ToArray();

            Assert.Equal(expectedArray.Length, actualArray.Length);

            for (int i = 0; i < expectedArray.Length; i++)
            {
                T expectedElement = expectedArray[i];
                T actualElement = actualArray[i];

                assertElementsEqual(expectedElement, actualElement);
            }
        }
    }
}
