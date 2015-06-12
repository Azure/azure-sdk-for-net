// 
// Copyright (c) Microsoft.  All rights reserved. 
// 
// Licensed under the Apache License, Version 2.0 (the "License"); 
// you may not use this file except in compliance with the License. 
// You may obtain a copy of the License at 
//   http://www.apache.org/licenses/LICENSE-2.0 
// 
// Unless required by applicable law or agreed to in writing, software 
// distributed under the License is distributed on an "AS IS" BASIS, 
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied. 
// See the License for the specific language governing permissions and 
// limitations under the License. 
// 

using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Azure.Search.Models;
using Xunit;

namespace Microsoft.Azure.Search.Tests
{
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
