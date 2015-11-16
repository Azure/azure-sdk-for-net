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
            if (expected == null)
            {
                Assert.Null(actual);
            }

            if (expected.Count != actual.Count)
            {
                string message = 
                    String.Format(
                        "Document field count doesn't match. Expected fields: [{0}] Actual fields: [{1}]",
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
                    Assert.IsType(expectedType, actualObj);

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

        public static void SequenceEqual<T>(IEnumerable<T> expected, IEnumerable<T> actual)
        {
            string message =
                String.Format(
                    "Expected: ['{0}'] Actual: ['{1}']",
                    String.Join("', '", expected),
                    String.Join("', '", actual));

            Assert.True(expected.SequenceEqual(actual), message);
        }
    }
}
