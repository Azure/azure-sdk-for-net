// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.IO;
using System;
using System.Text.Json;
using Azure.Core.Json;
using NUnit.Framework;

namespace Azure.Core.Experimental.Tests
{
    internal class MutableJsonElementTests
    {
        [Test]
        public void ToStringWorksWithNoChanges()
        {
            string json = """
                {
                  "Bar" : "Hi!",
                  "Foo" : "\"+"
                }
                """;

            MutableJsonElement element = MutableJsonDocument.Parse(json).RootElement;

            ValidateToString(json, element);
        }

        private static void ValidateToString(string json, MutableJsonElement element)
        {
            // Validate that MutableJsonElement.ToString() has the same behavior as JsonElement.

            Assert.AreEqual(JsonDocument.Parse(json).RootElement.ToString(), element.ToString());
        }

        [Test]
        public void ToStringWorksWithChanges()
        {
            string json = """
                {
                  "Bar" : "Hi!"
                }
                """;

            MutableJsonDocument mdoc = MutableJsonDocument.Parse(json);
            mdoc.RootElement.GetProperty("Bar").Set(null);

            string expected = """
                {
                  "Bar" : null
                }
                """;

            Assert.AreEqual(
				MutableJsonDocumentWriteToTests.RemoveWhiteSpace(expected),
				MutableJsonDocumentWriteToTests.RemoveWhiteSpace(mdoc.RootElement.ToString())
			);
        }

        [Test]
        public void ChangesToElementAppearInToString()
        {
            string json = """
                {
                  "Bar" : "Hi!"
                }
                """;

            MutableJsonDocument mdoc = MutableJsonDocument.Parse(json);

            mdoc.RootElement.GetProperty("Bar").Set("hello");

            string expected = """
                {
                  "Bar" : "hello"
                }
                """;

            Assert.AreEqual(
				MutableJsonDocumentWriteToTests.RemoveWhiteSpace(expected),
				MutableJsonDocumentWriteToTests.RemoveWhiteSpace(mdoc.RootElement.ToString())
			);
        }

        [Test]
        public void ChangesToElementAppearInJsonElement()
        {
            string json = """
                {
                  "Bar" : "Hi!"
                }
                """;

            MutableJsonDocument mdoc = MutableJsonDocument.Parse(json);

            mdoc.RootElement.GetProperty("Bar").Set("hello");

            JsonElement barElement = mdoc.RootElement.GetProperty("Bar").GetJsonElement();
            Assert.AreEqual("hello", barElement.GetString());

            JsonElement rootElement = mdoc.RootElement.GetJsonElement();

            string expected = """
                {
                  "Bar" : "hello"
                }
                """;

            Assert.AreEqual(
				MutableJsonDocumentWriteToTests.RemoveWhiteSpace(expected),
				MutableJsonDocumentWriteToTests.RemoveWhiteSpace(rootElement.ToString())
			);
        }

        [Test]
        public void CanGetNullElement()
        {
            string json = """
                {
                  "Bar" : null
                }
                """;

            var jd = MutableJsonDocument.Parse(json);

            MutableJsonElement bar = jd.RootElement.GetProperty("Bar");

            Assert.AreEqual(JsonValueKind.Null, bar.ValueKind);
        }

        [Test]
        public void ValueKindReflectsChanges()
        {
            string json = """
                {
                  "Bar" : "Hi!"
                }
            """;

            var jd = MutableJsonDocument.Parse(json);

            Assert.AreEqual(JsonValueKind.String, jd.RootElement.GetProperty("Bar").ValueKind);

            jd.RootElement.GetProperty("Bar").Set(1.2);

            Assert.AreEqual(JsonValueKind.Number, jd.RootElement.GetProperty("Bar").ValueKind);

            jd.RootElement.GetProperty("Bar").Set(null);

            Assert.AreEqual(JsonValueKind.Null, jd.RootElement.GetProperty("Bar").ValueKind);
        }

        [Test]
        public void CanEnumerateArray()
        {
            string json = "[0, 1, 2, 3]";

            MutableJsonDocument jd = MutableJsonDocument.Parse(json);

            MutableJsonElement.ArrayEnumerator enumerator = jd.RootElement.EnumerateArray();

            int expected = 0;
            foreach (MutableJsonElement el in enumerator)
            {
                Assert.AreEqual(expected++, el.GetInt32());
            }

            Assert.AreEqual(4, expected);
        }

        [Test]
        public void CanEnumerateArrayWithChanges()
        {
            string json = "[0, 1, 2, 3]";

            MutableJsonDocument jd = MutableJsonDocument.Parse(json);

            for (int i = 0; i < 4; i++)
            {
                jd.RootElement.GetIndexElement(i).Set(i + 1);
            }

            MutableJsonElement.ArrayEnumerator enumerator = jd.RootElement.EnumerateArray();

            int expected = 1;
            foreach (MutableJsonElement el in enumerator)
            {
                Assert.AreEqual(expected++, el.GetInt32());
            }

            Assert.AreEqual(5, expected);
        }

        [Test]
        public void EnumeratedArrayValueCanBeChanged()
        {
            string json = "[0, 1, 2, 3]";

            MutableJsonDocument mdoc = MutableJsonDocument.Parse(json);
            MutableJsonElement.ArrayEnumerator enumerator = mdoc.RootElement.EnumerateArray();

            MutableJsonElement value = default;
            foreach (MutableJsonElement item in enumerator)
            {
                value = item;
            }

            value.Set(5);
            Assert.AreEqual(5, value.GetInt32());
            Assert.AreEqual(5, mdoc.RootElement.GetIndexElement(3).GetInt32());
        }

        [Test]
        public void CanEnumerateObject()
        {
            string json = """
                {
                  "Zero" : 0,
                  "One" : 1,
                  "Two" : 2,
                  "Three" : 3
                }
                """;

            MutableJsonDocument mdoc = MutableJsonDocument.Parse(json);

            MutableJsonElement.ObjectEnumerator enumerator = mdoc.RootElement.EnumerateObject();

            int expected = 0;
            string[] expectedNames = new string[] { "Zero", "One", "Two", "Three" };

            foreach ((string Name, MutableJsonElement Value) property in enumerator)
            {
                Assert.AreEqual(expectedNames[expected], property.Name);
                Assert.AreEqual(expected, property.Value.GetInt32());
                expected++;
            }

            Assert.AreEqual(4, expected);
        }

        [Test]
        public void CanEnumerateObjectWithChanges()
        {
            string json = """
                {
                  "Zero" : 0,
                  "One" : 1,
                  "Two" : 2,
                  "Three" : 3
                }
                """;

            MutableJsonDocument mdoc = MutableJsonDocument.Parse(json);

            string[] expectedNames = new string[] { "Zero", "One", "Two", "Three" };

            for (int i = 0; i < 4; i++)
            {
                mdoc.RootElement.GetProperty(expectedNames[i]).Set(i + 1);
            }

            MutableJsonElement.ObjectEnumerator enumerator = mdoc.RootElement.EnumerateObject();

            int index = 0;
            foreach ((string Name, MutableJsonElement Value) property in enumerator)
            {
                Assert.AreEqual(expectedNames[index], property.Name);
                Assert.AreEqual(index + 1, property.Value.GetInt32());
                index++;
            }

            Assert.AreEqual(4, index);
        }

        [Test]
        public void EnumeratedPropertyValueCanBeChanged()
        {
            string json = """
                {
                  "Foo" : 0,
                  "Bar" : 1
                }
                """;

            MutableJsonDocument mdoc = MutableJsonDocument.Parse(json);
            MutableJsonElement.ObjectEnumerator enumerator = mdoc.RootElement.EnumerateObject();

            int index = 0;
            MutableJsonElement value = default;
            foreach ((string Name, MutableJsonElement Value) property in enumerator)
            {
                value = property.Value;
                index++;
            }

            value.Set(5);

            Assert.AreEqual(5, value.GetInt32());
            Assert.AreEqual(5, mdoc.RootElement.GetProperty("Bar").GetInt32());
        }
    }
}
