// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
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
                  "Bar" : "Hi!"
                }
                """;

            MutableJsonDocument mdoc = MutableJsonDocument.Parse(json);

            Assert.AreEqual(
                MutableJsonDocumentWriteToTests.RemoveWhiteSpace(json),
                MutableJsonDocumentWriteToTests.RemoveWhiteSpace(mdoc.RootElement.ToString()));
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

            Assert.AreEqual(
                MutableJsonDocumentWriteToTests.RemoveWhiteSpace("""
                {
                  "Bar" : null
                }
                """),
                MutableJsonDocumentWriteToTests.RemoveWhiteSpace(mdoc.RootElement.ToString()));
        }

        [Test]
        public void ChangesToElementAppearInToString()
        {
            string json = """
                {
                  "Bar" : "Hi!"
                }
                """;

            var jd = MutableJsonDocument.Parse(json);

            jd.RootElement.GetProperty("Bar").Set("hello");

            Assert.AreEqual(
                MutableJsonDocumentWriteToTests.RemoveWhiteSpace("""
                {
                  "Bar" : "hello"
                }
                """),
                MutableJsonDocumentWriteToTests.RemoveWhiteSpace(jd.RootElement.ToString()));
        }

        [Test]
        public void ChangesToElementAppearInJsonElement()
        {
            string json = """
                {
                  "Bar" : "Hi!"
                }
                """;

            var jd = MutableJsonDocument.Parse(json);

            jd.RootElement.GetProperty("Bar").Set("hello");

            JsonElement barElement = jd.RootElement.GetProperty("Bar").GetJsonElement();
            Assert.AreEqual("hello", barElement.GetString());

            JsonElement rootElement = jd.RootElement.GetJsonElement();
            Assert.AreEqual(
                MutableJsonDocumentWriteToTests.RemoveWhiteSpace("""
                {
                  "Bar" : "hello"
                }
                """),
                MutableJsonDocumentWriteToTests.RemoveWhiteSpace(rootElement.ToString()));
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
        }
    }
}
