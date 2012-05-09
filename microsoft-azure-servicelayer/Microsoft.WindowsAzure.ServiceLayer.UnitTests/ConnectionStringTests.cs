//
// Copyright 2012 Microsoft Corporation
// 
// Licensed under the Apache License, Version 2.0 (the "License");
//  you may not use this file except in compliance with the License.
//  You may obtain a copy of the License at
//    http://www.apache.org/licenses/LICENSE-2.0
// 
//  Unless required by applicable law or agreed to in writing, software
//  distributed under the License is distributed on an "AS IS" BASIS,
//  WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//  See the License for the specific language governing permissions and
//  limitations under the License.
//

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;
using Microsoft.WindowsAzure.ServiceLayer;

namespace Microsoft.WindowsAzure.ServiceLayer.UnitTests
{
    /// <summary>
    /// Connection string tests.
    /// </summary>
    [TestClass]
    public class ConnectionStringTests
    {
        /// <summary>
        /// Parses the connection string and verifies the results.
        /// </summary>
        /// <param name="connectionString">Connection strings.</param>
        /// <param name="results">Expected result (key, value)</param>
        private static void ParseTest(string connectionString, params string[] results)
        {
            Dictionary<string, string> expectedValues = new Dictionary<string, string>(StringComparer.Ordinal);
            for (int i = 0; i < results.Length; i += 2)
            {
                expectedValues.Add(results[i], results[i + 1]);
            }

            Dictionary<string, string> actualValues = new Dictionary<string,string>(StringComparer.Ordinal);
            foreach (KeyValuePair<string, string> items in ConnectionStringParser.Parse(connectionString))
            {
                actualValues.Add(items.Key, items.Value);
            }

            Assert.AreEqual(expectedValues.Count, actualValues.Count);
            foreach (KeyValuePair<string, string> expectedItem in expectedValues)
            {
                string actualValue;
                Assert.IsTrue(actualValues.TryGetValue(expectedItem.Key, out actualValue));
                Assert.AreEqual(expectedItem.Value, actualValue, false, CultureInfo.InvariantCulture);
            }
        }

        /// <summary>
        /// Verifies that parsing the given string results in an exception.
        /// </summary>
        /// <param name="value">String to parse.</param>
        private static void TestFailure(string value)
        {
            Assert.ThrowsException<ArgumentException>(
                () =>
                {
                    foreach (KeyValuePair<string, string> item in ConnectionStringParser.Parse(value))
                    {
                        // Do nothing.
                    }
                }
            );
        }

        /// <summary>
        /// Tests valid variations of key names.
        /// </summary>
        [TestMethod]
        public void KeyNames()
        {
            ParseTest("a=b", "a", "b");
            ParseTest(" a =b; c = d", "a", "b", "c", "d");
            ParseTest("a b=c", "a b", "c");
            ParseTest("'a b'=c", "a b", "c");
            ParseTest("\"a b\"=c", "a b", "c");
            ParseTest("\"a=b\"=c", "a=b", "c");
            ParseTest("a=b=c", "a", "b=c");
            ParseTest("'a='=b", "a=", "b");
            ParseTest("\"a=\"=b", "a=", "b");
            ParseTest("\"a'b\"=c", "a'b", "c");
            ParseTest("'a\"b'=c", "a\"b", "c");
            ParseTest("a'b=c", "a'b", "c");
            ParseTest("a\"b=c", "a\"b", "c");
            ParseTest("a'=b", "a'", "b");
            ParseTest("a\"=b", "a\"", "b");
        }

        /// <summary>
        /// Tests valid variations of assignments.
        /// </summary>
        [TestMethod]
        public void Assignments()
        {
            ParseTest("a=b", "a", "b");
            ParseTest("a = b", "a", "b");
            ParseTest("a==b", "a", "=b");
        }

        /// <summary>
        /// Tests valid variations on values.
        /// </summary>
        [TestMethod]
        public void Values()
        {
            ParseTest("a=b", "a", "b");
            ParseTest("a= b ", "a", "b");
            ParseTest("a= b ;c= d;", "a", "b", "c", "d");
            ParseTest("a=", "a", "");
            ParseTest("a=;", "a", "");
            ParseTest("a=;b=", "a", "", "b", "");
            ParseTest("a==b", "a", "=b");
            ParseTest("a=b=;c==d=", "a", "b=", "c", "=d=");
            ParseTest("a='b c'", "a", "b c");
            ParseTest("a=\"b c\"", "a", "b c");
            ParseTest("a=\"b'c\"", "a", "b'c");
            ParseTest("a='b\"c'", "a", "b\"c");
            ParseTest("a='b=c'", "a", "b=c");
            ParseTest("a=\"b=c\"", "a", "b=c");
            ParseTest("a='b;c=d'", "a", "b;c=d");
            ParseTest("a=\"b;c=d\"", "a", "b;c=d");
            ParseTest("a='b c' ", "a", "b c");
            ParseTest("a=\"b c\" ", "a", "b c");
            ParseTest("a=b'c", "a", "b'c");
            ParseTest("a=b\"c", "a", "b\"c");
            ParseTest("a=b'", "a", "b'");
            ParseTest("a=b\"", "a", "b\"");
        }

        /// <summary>
        /// Tests valid variations of separators.
        /// </summary>
        [TestMethod]
        public void Separators()
        {
            ParseTest("a=b;", "a", "b");
            ParseTest("a=b", "a", "b");
            ParseTest("a=b;c=d", "a", "b", "c", "d");
            ParseTest("a=b;c=d;", "a", "b", "c", "d");
            ParseTest("a=b ; c=d", "a", "b", "c", "d");
        }

        /// <summary>
        /// Tests invalid input.
        /// </summary>
        [TestMethod]
        public void InvalidInput()
        {
            TestFailure("=b");          // Missing key name;
            TestFailure("''=b");        // Empty key name;
            TestFailure("\"\"=b");      // Empty key name;
            TestFailure("test");        // Missing assignment;
            TestFailure(";a=b");        // Separator without key=value;
            TestFailure("'a=b");        // Runaway single-quoted string at the beginning of the key name;
            TestFailure("\"a=b");       // Runaway double-quoted string at the beginning of the key name;
            TestFailure("'=b");         // Runaway single-quoted string in key name;
            TestFailure("\"=b");        // Runaway double-quoted string in key name;
            TestFailure("a='b");        // Runaway single-quoted string in value;
            TestFailure("a=\"b");       // Runaway double-quoted string in value;
            TestFailure("a='b'c");      // Extra character after single-quoted value;
            TestFailure("a=\"b\"c");    // Extra character after double-quoted value;
            TestFailure("'a'b=c");      // Extra character after single-quoted key;
            TestFailure("\"a\"b=c");    // Extra character after double-quoted key;
        }

    }
}
