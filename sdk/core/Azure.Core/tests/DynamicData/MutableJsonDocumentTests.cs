// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Text.Json;
using Azure.Core.Json;
using Azure.Core.Serialization;
using NUnit.Framework;

namespace Azure.Core.Tests
{
    internal class MutableJsonDocumentTests
    {
        [Test]
        public void CanGetProperty()
        {
            string json = """
                {
                  "Baz" : {
                     "A" : 3.0
                  },
                  "Foo" : 1.2,
                  "Bar" : "Hi!",
                  "Qux" : false
                }
                """;

            using MutableJsonDocument mdoc = MutableJsonDocument.Parse(json);

            Assert.AreEqual(1.2, mdoc.RootElement.GetProperty("Foo").GetDouble());
            Assert.AreEqual("Hi!", mdoc.RootElement.GetProperty("Bar").GetString());
            Assert.AreEqual(3.0, mdoc.RootElement.GetProperty("Baz").GetProperty("A").GetDouble());
            Assert.AreEqual(false, mdoc.RootElement.GetProperty("Qux").GetBoolean());

            ValidateWriteTo(json, mdoc);
        }

        [Test]
        public void CanSetProperty()
        {
            string json = """
                {
                  "Baz" : {
                     "A" : 3
                  },
                  "Foo" : 1,
                  "Bar" : "Hi!",
                  "Qux" : false
                }
                """;

            MutableJsonDocument mdoc = MutableJsonDocument.Parse(json);

            mdoc.RootElement.GetProperty("Foo").Set(2);
            mdoc.RootElement.GetProperty("Bar").Set("Hello");
            mdoc.RootElement.GetProperty("Baz").GetProperty("A").Set(5);
            mdoc.RootElement.GetProperty("Qux").Set(true);

            Assert.AreEqual(2, mdoc.RootElement.GetProperty("Foo").GetInt32());
            Assert.AreEqual("Hello", mdoc.RootElement.GetProperty("Bar").GetString());
            Assert.AreEqual(5, mdoc.RootElement.GetProperty("Baz").GetProperty("A").GetInt32());
            Assert.AreEqual(true, mdoc.RootElement.GetProperty("Qux").GetBoolean());

            string expected = """
                {
                  "Baz" : {
                     "A" : 5
                  },
                  "Foo" : 2,
                  "Bar" : "Hello",
                  "Qux" : true
                }
                """;

            ValidateWriteTo(expected, mdoc);
        }

        [Test]
        public void CanSetPropertyMultipleTimes()
        {
            string json = """
                {
                  "Baz" : {
                     "A" : 3
                  },
                  "Foo" : 1,
                  "Bar" : "Hi!"
                }
                """;

            MutableJsonDocument mdoc = MutableJsonDocument.Parse(json);

            mdoc.RootElement.GetProperty("Foo").Set(2);
            mdoc.RootElement.GetProperty("Foo").Set(3);

            // Last write wins
            Assert.AreEqual(3, mdoc.RootElement.GetProperty("Foo").GetInt32());

            string expected = """
                {
                  "Baz" : {
                     "A" : 3
                  },
                  "Foo" : 3,
                  "Bar" : "Hi!"
                }
                """;

            ValidateWriteTo(expected, mdoc);
        }

        [Test]
        public void CanSetProperty_JsonWithDotProperty()
        {
            string json = """
                {
                  "Baz.NotChild" : {
                     "A" : 3
                  },
                  "Foo" : 1,
                  "Bar" : "Hi!"
                }
                """;

            MutableJsonDocument mdoc = MutableJsonDocument.Parse(json);

            mdoc.RootElement.GetProperty("Foo").Set(3);

            Assert.AreEqual(3, mdoc.RootElement.GetProperty("Foo").GetInt32());

            string expected = """
                {
                  "Baz.NotChild" : {
                     "A" : 3
                  },
                  "Foo" : 3,
                  "Bar" : "Hi!"
                }
                """;

            ValidateWriteTo(expected, mdoc);
        }

        [Test]
        public void JsonWithDelimiterIsInvalidJson()
        {
            char delimiter = MutableJsonDocument.ChangeTracker.Delimiter;
            string propertyName = "\"Baz" + delimiter + "NotChild\"";
            string json = "{" + propertyName + ": {\"A\": 3}, \"Foo\":1}";

            bool parsed = false;
            bool threwJsonException = false;

            try
            {
                MutableJsonDocument.Parse(json);
                parsed = true;
            }
            catch (JsonException)
            {
                threwJsonException = true;
            }

            Assert.IsFalse(parsed);
            Assert.IsTrue(threwJsonException);
        }

        [Test]
        public void CanAddPropertyToRootObject()
        {
            string json = """
                {
                  "Foo" : 1.2
                }
                """;

            MutableJsonDocument mdoc = MutableJsonDocument.Parse(json);

            // Has same semantics as Dictionary
            // https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.dictionary-2.item?view=net-7.0#property-value
            mdoc.RootElement.SetProperty("Bar", "hi");

            // Assert:

            // 1. Old property is present.
            Assert.AreEqual(1.2, mdoc.RootElement.GetProperty("Foo").GetDouble());

            // 2. New property is present.
            Assert.IsNotNull(mdoc.RootElement.GetProperty("Bar"));
            Assert.AreEqual("hi", mdoc.RootElement.GetProperty("Bar").GetString());

            // 3. Type round-trips correctly.
            BinaryData buffer = GetWriteToBuffer(mdoc);
            JsonDocument doc = JsonDocument.Parse(buffer);

            Assert.AreEqual(1.2, doc.RootElement.GetProperty("Foo").GetDouble());
            Assert.AreEqual("hi", doc.RootElement.GetProperty("Bar").GetString());

            string expected = """
                {
                  "Foo" : 1.2,
                  "Bar" : "hi"
                }
                """;
            ValidateWriteTo(expected, mdoc);
        }

        [Test]
        public void CanAddPropertyToObject()
        {
            string json = """
                {
                  "Foo" : {
                    "A": 1.2
                    }
                }
                """;

            MutableJsonDocument mdoc = MutableJsonDocument.Parse(json);

            mdoc.RootElement.GetProperty("Foo").SetProperty("B", "hi");

            // Assert:

            // 1. Old property is present.
            Assert.AreEqual(1.2, mdoc.RootElement.GetProperty("Foo").GetProperty("A").GetDouble());

            // 2. New property is present.
            Assert.IsNotNull(mdoc.RootElement.GetProperty("Foo").GetProperty("B"));
            Assert.AreEqual("hi", mdoc.RootElement.GetProperty("Foo").GetProperty("B").GetString());

            // 3. Type round-trips correctly.
            BinaryData buffer = GetWriteToBuffer(mdoc);
            JsonDocument doc = JsonDocument.Parse(buffer);

            Assert.AreEqual(1.2, doc.RootElement.GetProperty("Foo").GetProperty("A").GetDouble());
            Assert.AreEqual("hi", doc.RootElement.GetProperty("Foo").GetProperty("B").GetString());

            string expected = """
                {
                  "Foo" : {
                    "A": 1.2,
                    "B": "hi"
                    }
                }
                """;

            ValidateWriteTo(expected, mdoc);
        }

        [Test]
        public void CanRemovePropertyFromRootObject()
        {
            string json = """
                {
                  "Foo" : 1.2,
                  "Bar" : "Hi!"
                }
                """;

            MutableJsonDocument mdoc = MutableJsonDocument.Parse(json);

            mdoc.RootElement.RemoveProperty("Bar");

            // Assert:

            // 1. Old property is present.
            Assert.AreEqual(1.2, mdoc.RootElement.GetProperty("Foo").GetDouble());

            // 2. New property not present.
            Assert.IsFalse(mdoc.RootElement.TryGetProperty("Bar", out var _));

            // 3. Type round-trips correctly.
            BinaryData buffer = GetWriteToBuffer(mdoc);
            JsonDocument doc = JsonDocument.Parse(buffer);

            Assert.AreEqual(1.2, doc.RootElement.GetProperty("Foo").GetDouble());
            Assert.IsFalse(doc.RootElement.TryGetProperty("Bar", out JsonElement _));

            string expected = """
                {
                  "Foo" : 1.2
                }
                """;

            ValidateWriteTo(expected, mdoc);
        }

        [Test]
        public void CanRemovePropertyFromObject()
        {
            string json = """
                {
                  "Foo" : {
                    "A": 1.2,
                    "B": "hi"
                    }
                }
                """;

            MutableJsonDocument mdoc = MutableJsonDocument.Parse(json);

            mdoc.RootElement.GetProperty("Foo").RemoveProperty("B");

            // Assert:

            // 1. Old property is present.
            Assert.AreEqual(1.2, mdoc.RootElement.GetProperty("Foo").GetProperty("A").GetDouble());

            // 2. New property is absent.
            Assert.IsFalse(mdoc.RootElement.GetProperty("Foo").TryGetProperty("B", out var _));

            // 3. Type round-trips correctly.
            BinaryData buffer = GetWriteToBuffer(mdoc);
            JsonDocument doc = JsonDocument.Parse(buffer);

            Assert.AreEqual(1.2, doc.RootElement.GetProperty("Foo").GetProperty("A").GetDouble());

            string expected = """
                {
                  "Foo" : {
                    "A": 1.2
                    }
                }
                """;

            ValidateWriteTo(expected, mdoc);
        }

        [Test]
        public void CanReplaceObjectWithAnonymousType()
        {
            string json = """
                {
                  "Baz" : {
                     "A" : 3.0
                  },
                  "Foo" : 1.2
                }
                """;

            using MutableJsonDocument mdoc = MutableJsonDocument.Parse(json);

            JsonElement element = MutableJsonElement.SerializeToJsonElement(new { B = 5.5 });
            mdoc.RootElement.GetProperty("Baz").Set(element);

            // Assert:

            // 1. Old property is present.
            Assert.AreEqual(1.2, mdoc.RootElement.GetProperty("Foo").GetDouble());

            // 2. Object structure has been rewritten
            Assert.IsFalse(mdoc.RootElement.GetProperty("Baz").TryGetProperty("A", out var _));
            Assert.AreEqual(5.5, mdoc.RootElement.GetProperty("Baz").GetProperty("B").GetDouble());

            // 3. Type round-trips correctly.
            BinaryData buffer = GetWriteToBuffer(mdoc);

            BazB baz = JsonSerializer.Deserialize<BazB>(buffer);
            Assert.AreEqual(1.2, baz.Foo);
            Assert.AreEqual(5.5, baz.Baz.B);

            string expected = """
                {
                  "Baz" : {
                     "B" : 5.5
                  },
                  "Foo" : 1.2
                }
                """;

            ValidateWriteTo(expected, mdoc);
        }

        private class BazA
        {
            public double Foo { get; set; }
            public A_ Baz { get; set; }
        }

        private class BazB
        {
            public double Foo { get; set; }
            public B_ Baz { get; set; }
        }

        private class A_
        {
            public double A { get; set; }
        }

        private class B_
        {
            public double B { get; set; }
        }

        [Test]
        public void CanGetArrayElement()
        {
            string json = """
                {
                  "Foo" : [ 1, 2, 3 ]
                }
                """;

            MutableJsonDocument mdoc = MutableJsonDocument.Parse(json);

            Assert.AreEqual(1, mdoc.RootElement.GetProperty("Foo").GetIndexElement(0).GetInt32());
            Assert.AreEqual(2, mdoc.RootElement.GetProperty("Foo").GetIndexElement(1).GetInt32());
            Assert.AreEqual(3, mdoc.RootElement.GetProperty("Foo").GetIndexElement(2).GetInt32());

            ValidateWriteTo(json, mdoc);
        }

        [Test]
        public void CanSetArrayElement()
        {
            string json = """
                {
                  "Foo" : [ 1, 2, 3 ]
                }
                """;

            MutableJsonDocument mdoc = MutableJsonDocument.Parse(json);

            mdoc.RootElement.GetProperty("Foo").GetIndexElement(0).Set(5);
            mdoc.RootElement.GetProperty("Foo").GetIndexElement(1).Set(6);
            mdoc.RootElement.GetProperty("Foo").GetIndexElement(2).Set(7);

            Assert.AreEqual(5, mdoc.RootElement.GetProperty("Foo").GetIndexElement(0).GetInt32());
            Assert.AreEqual(6, mdoc.RootElement.GetProperty("Foo").GetIndexElement(1).GetInt32());
            Assert.AreEqual(7, mdoc.RootElement.GetProperty("Foo").GetIndexElement(2).GetInt32());

            string expected = """
                {
                  "Foo" : [ 5, 6, 7 ]
                }
                """;

            ValidateWriteTo(expected, mdoc);
        }

        [Test]
        public void CanSetArrayElementMultipleTimes()
        {
            string json = """
                {
                  "Foo" : [ 1, 2, 3 ]
                }
                """;

            MutableJsonDocument mdoc = MutableJsonDocument.Parse(json);

            mdoc.RootElement.GetProperty("Foo").GetIndexElement(0).Set(5);
            mdoc.RootElement.GetProperty("Foo").GetIndexElement(0).Set(6);

            Assert.AreEqual(6, mdoc.RootElement.GetProperty("Foo").GetIndexElement(0).GetInt32());

            string expected = """
                {
                  "Foo" : [ 6, 2, 3 ]
                }
                """;

            ValidateWriteTo(expected, mdoc);
        }

        [Test]
        public void CanChangeArrayElementType()
        {
            string json = """
                {
                  "Foo" : [ 1, 2, 3 ]
                }
                """;

            MutableJsonDocument mdoc = MutableJsonDocument.Parse(json);

            mdoc.RootElement.GetProperty("Foo").GetIndexElement(0).Set(5);
            mdoc.RootElement.GetProperty("Foo").GetIndexElement(1).Set("string");
            mdoc.RootElement.GetProperty("Foo").GetIndexElement(2).Set(true);

            Assert.AreEqual(5, mdoc.RootElement.GetProperty("Foo").GetIndexElement(0).GetInt32());
            Assert.AreEqual("string", mdoc.RootElement.GetProperty("Foo").GetIndexElement(1).GetString());
            Assert.AreEqual(true, mdoc.RootElement.GetProperty("Foo").GetIndexElement(2).GetBoolean());

            BinaryData buffer = GetWriteToBuffer(mdoc);
            JsonDocument doc = JsonDocument.Parse(buffer);

            Assert.AreEqual(5, doc.RootElement.GetProperty("Foo")[0].GetInt32());
            Assert.AreEqual("string", doc.RootElement.GetProperty("Foo")[1].GetString());
            Assert.AreEqual(true, doc.RootElement.GetProperty("Foo")[2].GetBoolean());

            string expected = """
                {
                  "Foo" : [ 5, "string", true ]
                }
                """;

            ValidateWriteTo(expected, mdoc);
        }

        [Test]
        public void ChangeToAddedElementReferenceAppearsInDocument()
        {
            // This tests reference semantics.

            string json = """[ { "Foo" : {} } ]""";

            MutableJsonDocument mdoc = MutableJsonDocument.Parse(json);

            // a is a reference to the 0th element; a's path is "0"
            MutableJsonElement a = mdoc.RootElement.GetIndexElement(0);

            a.GetProperty("Foo").SetProperty("Bar", 5);

            Assert.AreEqual(5, a.GetProperty("Foo").GetProperty("Bar").GetInt32());
            Assert.AreEqual(5, mdoc.RootElement.GetIndexElement(0).GetProperty("Foo").GetProperty("Bar").GetInt32());

            string expected = """
                [ {
                    "Foo" : {
                        "Bar" : 5
                    }
                } ]
                """;

            ValidateWriteTo(expected, mdoc);
        }

        [Test]
        public void CanSetProperty_StringToNumber()
        {
            string json = """[ { "Foo" : "hi" } ]""";

            MutableJsonDocument mdoc = MutableJsonDocument.Parse(json);

            Assert.AreEqual("hi", mdoc.RootElement.GetIndexElement(0).GetProperty("Foo").GetString());

            mdoc.RootElement.GetIndexElement(0).GetProperty("Foo").Set(1.2);

            Assert.AreEqual(1.2, mdoc.RootElement.GetIndexElement(0).GetProperty("Foo").GetDouble());

            // 3. Type round-trips correctly.
            BinaryData buffer = GetWriteToBuffer(mdoc);
            JsonDocument doc = JsonDocument.Parse(buffer);

            Assert.AreEqual(1.2, doc.RootElement[0].GetProperty("Foo").GetDouble());

            string expected = """[ { "Foo" : 1.2 } ]""";

            ValidateWriteTo(expected, mdoc);
        }

        [Test]
        public void CanSetProperty_StringToBool()
        {
            string json = """[ { "Foo" : "hi" } ]""";

            MutableJsonDocument mdoc = MutableJsonDocument.Parse(json);

            Assert.AreEqual("hi", mdoc.RootElement.GetIndexElement(0).GetProperty("Foo").GetString());

            mdoc.RootElement.GetIndexElement(0).GetProperty("Foo").Set(false);

            Assert.IsFalse(mdoc.RootElement.GetIndexElement(0).GetProperty("Foo").GetBoolean());

            // 3. Type round-trips correctly.
            BinaryData buffer = GetWriteToBuffer(mdoc);
            JsonDocument doc = JsonDocument.Parse(buffer);

            Assert.IsFalse(doc.RootElement[0].GetProperty("Foo").GetBoolean());

            string expected = """[ { "Foo" : false } ]""";

            ValidateWriteTo(expected, mdoc);
        }

        [Test]
        public void CanSetProperty_StringToObject()
        {
            string json = """{ "Foo" : "hi" }""";

            using MutableJsonDocument mdoc = MutableJsonDocument.Parse(json);

            Assert.AreEqual("hi", mdoc.RootElement.GetProperty("Foo").GetString());

            JsonElement element = MutableJsonElement.SerializeToJsonElement(new
            {
                Bar = 6
            });
            mdoc.RootElement.GetProperty("Foo").Set(element);

            Assert.AreEqual(6, mdoc.RootElement.GetProperty("Foo").GetProperty("Bar").GetInt32());

            BinaryData buffer = GetWriteToBuffer(mdoc);
            JsonDocument doc = JsonDocument.Parse(buffer);

            Assert.AreEqual(6, doc.RootElement.GetProperty("Foo").GetProperty("Bar").GetInt32());

            string expected = """{ "Foo" : {"Bar" : 6 } }""";

            ValidateWriteTo(expected, mdoc);
        }

        [Test]
        public void CanSetProperty_StringToArray()
        {
            string json = """[ { "Foo" : "hi" } ]""";

            using MutableJsonDocument mdoc = MutableJsonDocument.Parse(json);

            Assert.AreEqual("hi", mdoc.RootElement.GetIndexElement(0).GetProperty("Foo").GetString());

            JsonElement element = MutableJsonElement.SerializeToJsonElement(new int[] { 1, 2, 3 });
            mdoc.RootElement.GetIndexElement(0).GetProperty("Foo").Set(element);

            Assert.AreEqual(1, mdoc.RootElement.GetIndexElement(0).GetProperty("Foo").GetIndexElement(0).GetInt32());
            Assert.AreEqual(2, mdoc.RootElement.GetIndexElement(0).GetProperty("Foo").GetIndexElement(1).GetInt32());
            Assert.AreEqual(3, mdoc.RootElement.GetIndexElement(0).GetProperty("Foo").GetIndexElement(2).GetInt32());

            // 3. Type round-trips correctly.
            BinaryData buffer = GetWriteToBuffer(mdoc);
            JsonDocument doc = JsonDocument.Parse(buffer);

            Assert.AreEqual(1, doc.RootElement[0].GetProperty("Foo")[0].GetInt32());
            Assert.AreEqual(2, doc.RootElement[0].GetProperty("Foo")[1].GetInt32());
            Assert.AreEqual(3, doc.RootElement[0].GetProperty("Foo")[2].GetInt32());

            string expected = """[ { "Foo" : [1, 2, 3] }]""";

            ValidateWriteTo(expected, mdoc);
        }

        [Test]
        public void CanSetProperty_StringToNull()
        {
            string json = """[ { "Foo" : "hi" } ]""";

            MutableJsonDocument mdoc = MutableJsonDocument.Parse(json);

            Assert.AreEqual("hi", mdoc.RootElement.GetIndexElement(0).GetProperty("Foo").GetString());

            mdoc.RootElement.GetIndexElement(0).GetProperty("Foo").Set(null);

            Assert.IsNull(mdoc.RootElement.GetIndexElement(0).GetProperty("Foo").GetString());

            // 3. Type round-trips correctly.
            BinaryData buffer = GetWriteToBuffer(mdoc);
            JsonDocument doc = JsonDocument.Parse(buffer);

            Assert.AreEqual(JsonValueKind.Null, doc.RootElement[0].GetProperty("Foo").ValueKind);

            string expected = """[ { "Foo" : null } ]""";

            ValidateWriteTo(expected, mdoc);
        }

        [Test]
        public void CanSerialize()
        {
            string json = """
                {
                  "Foo" : "Hello"
                }
                """;

            MutableJsonDocument mdoc = MutableJsonDocument.Parse(json);
            byte[] bytes = JsonSerializer.SerializeToUtf8Bytes(mdoc);

            JsonDocument doc = JsonDocument.Parse(bytes);

            Assert.AreEqual("Hello", doc.RootElement.GetProperty("Foo").GetString());
        }

        [Test]
        public void CanDispose()
        {
            string json = """
                {
                  "Foo" : "Hello"
                }
                """;

            MutableJsonDocument mdoc = MutableJsonDocument.Parse(json);
            mdoc.Dispose();

            Assert.Throws<ObjectDisposedException>(() => { var foo = mdoc.RootElement.GetProperty("Foo"); });
        }

        [Test]
        public void CanChangeRootElement()
        {
            string json = "1";
            MutableJsonDocument mdoc = MutableJsonDocument.Parse(json);
            mdoc.RootElement.Set(2);

            Assert.AreEqual(2, mdoc.RootElement.GetInt32());
        }

        [Test]
        public void CanParseFromUtf8JsonReader()
        {
            ReadOnlySpan<byte> utf8Json = """
                {
                    "foo": 1
                }
                """u8;
            Utf8JsonReader reader = new(utf8Json);

            MutableJsonDocument mdoc = MutableJsonDocument.Parse(ref reader);

            Assert.AreEqual(1, mdoc.RootElement.GetProperty("foo").GetInt32());

            using MemoryStream stream = new();
            mdoc.WriteTo(stream, "J");
            stream.Flush();
            stream.Position = 0;

            Assert.AreEqual("""{"foo":1}""", BinaryData.FromStream(stream).ToString());
        }

        #region Helpers

        internal static void ValidateWriteTo(BinaryData json, MutableJsonDocument mdoc)
        {
            // To validate MutableJsonDocument.WriteTo(), we want to ensure that
            // its behavior is the same as the behavior of JsonDocument.WriteTo().

            JsonDocument doc = JsonDocument.Parse(json);
            BinaryData jdocBuffer = GetWriteToBuffer(doc);

            BinaryData mdocBuffer = GetWriteToBuffer(mdoc);

            Assert.AreEqual(jdocBuffer.ToString(), mdocBuffer.ToString());
            Assert.IsTrue(jdocBuffer.ToMemory().Span.SequenceEqual(mdocBuffer.ToMemory().Span),
                "JsonDocument buffer does not match MutableJsonDocument buffer.");
        }

        internal static void ValidateWriteTo(string json, MutableJsonDocument mdoc)
        {
            // To validate MutableJsonDocument.WriteTo(), we want to ensure that
            // its behavior is the same as the behavior of JsonDocument.WriteTo().

            JsonDocument doc = JsonDocument.Parse(json);
            BinaryData jdocBuffer = GetWriteToBuffer(doc);

            BinaryData mdocBuffer = GetWriteToBuffer(mdoc);

            Assert.AreEqual(jdocBuffer.ToString(), mdocBuffer.ToString());
            Assert.IsTrue(jdocBuffer.ToMemory().Span.SequenceEqual(mdocBuffer.ToMemory().Span),
                "JsonDocument buffer does not match MutableJsonDocument buffer.");
        }

        internal static BinaryData GetWriteToBuffer(JsonDocument doc)
        {
            using MemoryStream stream = new();
            using Utf8JsonWriter writer = new(stream);
            doc.WriteTo(writer);
            writer.Flush();
            stream.Position = 0;
            return BinaryData.FromStream(stream);
        }

        internal static BinaryData GetWriteToBuffer(MutableJsonDocument mdoc)
        {
            using MemoryStream stream = new();
            using Utf8JsonWriter writer = new(stream);
            mdoc.WriteTo(writer);
            writer.Flush();
            stream.Position = 0;
            return BinaryData.FromStream(stream);
        }

        internal static string RemoveWhiteSpace(string value)
        {
            return value.Replace(" ", "").Replace("\r", "").Replace("\n", "");
        }

        #endregion
    }
}
