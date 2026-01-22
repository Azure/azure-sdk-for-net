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

            Assert.That(mdoc.RootElement.GetProperty("Foo").GetDouble(), Is.EqualTo(1.2));
            Assert.That(mdoc.RootElement.GetProperty("Bar").GetString(), Is.EqualTo("Hi!"));
            Assert.That(mdoc.RootElement.GetProperty("Baz").GetProperty("A").GetDouble(), Is.EqualTo(3.0));
            Assert.That(mdoc.RootElement.GetProperty("Qux").GetBoolean(), Is.EqualTo(false));

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

            Assert.That(mdoc.RootElement.GetProperty("Foo").GetInt32(), Is.EqualTo(2));
            Assert.That(mdoc.RootElement.GetProperty("Bar").GetString(), Is.EqualTo("Hello"));
            Assert.That(mdoc.RootElement.GetProperty("Baz").GetProperty("A").GetInt32(), Is.EqualTo(5));
            Assert.That(mdoc.RootElement.GetProperty("Qux").GetBoolean(), Is.EqualTo(true));

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
            Assert.That(mdoc.RootElement.GetProperty("Foo").GetInt32(), Is.EqualTo(3));

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

            Assert.That(mdoc.RootElement.GetProperty("Foo").GetInt32(), Is.EqualTo(3));

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

            Assert.That(parsed, Is.False);
            Assert.That(threwJsonException, Is.True);
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
            Assert.That(mdoc.RootElement.GetProperty("Foo").GetDouble(), Is.EqualTo(1.2));

            // 2. New property is present.
            Assert.That(mdoc.RootElement.GetProperty("Bar"), Is.Not.Null);
            Assert.That(mdoc.RootElement.GetProperty("Bar").GetString(), Is.EqualTo("hi"));

            // 3. Type round-trips correctly.
            BinaryData buffer = GetWriteToBuffer(mdoc);
            JsonDocument doc = JsonDocument.Parse(buffer);

            Assert.That(doc.RootElement.GetProperty("Foo").GetDouble(), Is.EqualTo(1.2));
            Assert.That(doc.RootElement.GetProperty("Bar").GetString(), Is.EqualTo("hi"));

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
            Assert.That(mdoc.RootElement.GetProperty("Foo").GetProperty("A").GetDouble(), Is.EqualTo(1.2));

            // 2. New property is present.
            Assert.That(mdoc.RootElement.GetProperty("Foo").GetProperty("B"), Is.Not.Null);
            Assert.That(mdoc.RootElement.GetProperty("Foo").GetProperty("B").GetString(), Is.EqualTo("hi"));

            // 3. Type round-trips correctly.
            BinaryData buffer = GetWriteToBuffer(mdoc);
            JsonDocument doc = JsonDocument.Parse(buffer);

            Assert.That(doc.RootElement.GetProperty("Foo").GetProperty("A").GetDouble(), Is.EqualTo(1.2));
            Assert.That(doc.RootElement.GetProperty("Foo").GetProperty("B").GetString(), Is.EqualTo("hi"));

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
            Assert.That(mdoc.RootElement.GetProperty("Foo").GetDouble(), Is.EqualTo(1.2));

            // 2. New property not present.
            Assert.That(mdoc.RootElement.TryGetProperty("Bar", out var _), Is.False);

            // 3. Type round-trips correctly.
            BinaryData buffer = GetWriteToBuffer(mdoc);
            JsonDocument doc = JsonDocument.Parse(buffer);

            Assert.That(doc.RootElement.GetProperty("Foo").GetDouble(), Is.EqualTo(1.2));
            Assert.That(doc.RootElement.TryGetProperty("Bar", out JsonElement _), Is.False);

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
            Assert.That(mdoc.RootElement.GetProperty("Foo").GetProperty("A").GetDouble(), Is.EqualTo(1.2));

            // 2. New property is absent.
            Assert.That(mdoc.RootElement.GetProperty("Foo").TryGetProperty("B", out var _), Is.False);

            // 3. Type round-trips correctly.
            BinaryData buffer = GetWriteToBuffer(mdoc);
            JsonDocument doc = JsonDocument.Parse(buffer);

            Assert.That(doc.RootElement.GetProperty("Foo").GetProperty("A").GetDouble(), Is.EqualTo(1.2));

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
            Assert.That(mdoc.RootElement.GetProperty("Foo").GetDouble(), Is.EqualTo(1.2));

            // 2. Object structure has been rewritten
            Assert.That(mdoc.RootElement.GetProperty("Baz").TryGetProperty("A", out var _), Is.False);
            Assert.That(mdoc.RootElement.GetProperty("Baz").GetProperty("B").GetDouble(), Is.EqualTo(5.5));

            // 3. Type round-trips correctly.
            BinaryData buffer = GetWriteToBuffer(mdoc);

            BazB baz = JsonSerializer.Deserialize<BazB>(buffer);
            Assert.That(baz.Foo, Is.EqualTo(1.2));
            Assert.That(baz.Baz.B, Is.EqualTo(5.5));

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

            Assert.That(mdoc.RootElement.GetProperty("Foo").GetIndexElement(0).GetInt32(), Is.EqualTo(1));
            Assert.That(mdoc.RootElement.GetProperty("Foo").GetIndexElement(1).GetInt32(), Is.EqualTo(2));
            Assert.That(mdoc.RootElement.GetProperty("Foo").GetIndexElement(2).GetInt32(), Is.EqualTo(3));

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

            Assert.That(mdoc.RootElement.GetProperty("Foo").GetIndexElement(0).GetInt32(), Is.EqualTo(5));
            Assert.That(mdoc.RootElement.GetProperty("Foo").GetIndexElement(1).GetInt32(), Is.EqualTo(6));
            Assert.That(mdoc.RootElement.GetProperty("Foo").GetIndexElement(2).GetInt32(), Is.EqualTo(7));

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

            Assert.That(mdoc.RootElement.GetProperty("Foo").GetIndexElement(0).GetInt32(), Is.EqualTo(6));

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

            Assert.That(mdoc.RootElement.GetProperty("Foo").GetIndexElement(0).GetInt32(), Is.EqualTo(5));
            Assert.That(mdoc.RootElement.GetProperty("Foo").GetIndexElement(1).GetString(), Is.EqualTo("string"));
            Assert.That(mdoc.RootElement.GetProperty("Foo").GetIndexElement(2).GetBoolean(), Is.EqualTo(true));

            BinaryData buffer = GetWriteToBuffer(mdoc);
            JsonDocument doc = JsonDocument.Parse(buffer);

            Assert.That(doc.RootElement.GetProperty("Foo")[0].GetInt32(), Is.EqualTo(5));
            Assert.That(doc.RootElement.GetProperty("Foo")[1].GetString(), Is.EqualTo("string"));
            Assert.That(doc.RootElement.GetProperty("Foo")[2].GetBoolean(), Is.EqualTo(true));

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

            Assert.That(a.GetProperty("Foo").GetProperty("Bar").GetInt32(), Is.EqualTo(5));
            Assert.That(mdoc.RootElement.GetIndexElement(0).GetProperty("Foo").GetProperty("Bar").GetInt32(), Is.EqualTo(5));

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

            Assert.That(mdoc.RootElement.GetIndexElement(0).GetProperty("Foo").GetString(), Is.EqualTo("hi"));

            mdoc.RootElement.GetIndexElement(0).GetProperty("Foo").Set(1.2);

            Assert.That(mdoc.RootElement.GetIndexElement(0).GetProperty("Foo").GetDouble(), Is.EqualTo(1.2));

            // 3. Type round-trips correctly.
            BinaryData buffer = GetWriteToBuffer(mdoc);
            JsonDocument doc = JsonDocument.Parse(buffer);

            Assert.That(doc.RootElement[0].GetProperty("Foo").GetDouble(), Is.EqualTo(1.2));

            string expected = """[ { "Foo" : 1.2 } ]""";

            ValidateWriteTo(expected, mdoc);
        }

        [Test]
        public void CanSetProperty_StringToBool()
        {
            string json = """[ { "Foo" : "hi" } ]""";

            MutableJsonDocument mdoc = MutableJsonDocument.Parse(json);

            Assert.That(mdoc.RootElement.GetIndexElement(0).GetProperty("Foo").GetString(), Is.EqualTo("hi"));

            mdoc.RootElement.GetIndexElement(0).GetProperty("Foo").Set(false);

            Assert.That(mdoc.RootElement.GetIndexElement(0).GetProperty("Foo").GetBoolean(), Is.False);

            // 3. Type round-trips correctly.
            BinaryData buffer = GetWriteToBuffer(mdoc);
            JsonDocument doc = JsonDocument.Parse(buffer);

            Assert.That(doc.RootElement[0].GetProperty("Foo").GetBoolean(), Is.False);

            string expected = """[ { "Foo" : false } ]""";

            ValidateWriteTo(expected, mdoc);
        }

        [Test]
        public void CanSetProperty_StringToObject()
        {
            string json = """{ "Foo" : "hi" }""";

            using MutableJsonDocument mdoc = MutableJsonDocument.Parse(json);

            Assert.That(mdoc.RootElement.GetProperty("Foo").GetString(), Is.EqualTo("hi"));

            JsonElement element = MutableJsonElement.SerializeToJsonElement(new
            {
                Bar = 6
            });
            mdoc.RootElement.GetProperty("Foo").Set(element);

            Assert.That(mdoc.RootElement.GetProperty("Foo").GetProperty("Bar").GetInt32(), Is.EqualTo(6));

            BinaryData buffer = GetWriteToBuffer(mdoc);
            JsonDocument doc = JsonDocument.Parse(buffer);

            Assert.That(doc.RootElement.GetProperty("Foo").GetProperty("Bar").GetInt32(), Is.EqualTo(6));

            string expected = """{ "Foo" : {"Bar" : 6 } }""";

            ValidateWriteTo(expected, mdoc);
        }

        [Test]
        public void CanSetProperty_StringToArray()
        {
            string json = """[ { "Foo" : "hi" } ]""";

            using MutableJsonDocument mdoc = MutableJsonDocument.Parse(json);

            Assert.That(mdoc.RootElement.GetIndexElement(0).GetProperty("Foo").GetString(), Is.EqualTo("hi"));

            JsonElement element = MutableJsonElement.SerializeToJsonElement(new int[] { 1, 2, 3 });
            mdoc.RootElement.GetIndexElement(0).GetProperty("Foo").Set(element);

            Assert.That(mdoc.RootElement.GetIndexElement(0).GetProperty("Foo").GetIndexElement(0).GetInt32(), Is.EqualTo(1));
            Assert.That(mdoc.RootElement.GetIndexElement(0).GetProperty("Foo").GetIndexElement(1).GetInt32(), Is.EqualTo(2));
            Assert.That(mdoc.RootElement.GetIndexElement(0).GetProperty("Foo").GetIndexElement(2).GetInt32(), Is.EqualTo(3));

            // 3. Type round-trips correctly.
            BinaryData buffer = GetWriteToBuffer(mdoc);
            JsonDocument doc = JsonDocument.Parse(buffer);

            Assert.That(doc.RootElement[0].GetProperty("Foo")[0].GetInt32(), Is.EqualTo(1));
            Assert.That(doc.RootElement[0].GetProperty("Foo")[1].GetInt32(), Is.EqualTo(2));
            Assert.That(doc.RootElement[0].GetProperty("Foo")[2].GetInt32(), Is.EqualTo(3));

            string expected = """[ { "Foo" : [1, 2, 3] }]""";

            ValidateWriteTo(expected, mdoc);
        }

        [Test]
        public void CanSetProperty_StringToNull()
        {
            string json = """[ { "Foo" : "hi" } ]""";

            MutableJsonDocument mdoc = MutableJsonDocument.Parse(json);

            Assert.That(mdoc.RootElement.GetIndexElement(0).GetProperty("Foo").GetString(), Is.EqualTo("hi"));

            mdoc.RootElement.GetIndexElement(0).GetProperty("Foo").Set(null);

            Assert.That(mdoc.RootElement.GetIndexElement(0).GetProperty("Foo").GetString(), Is.Null);

            // 3. Type round-trips correctly.
            BinaryData buffer = GetWriteToBuffer(mdoc);
            JsonDocument doc = JsonDocument.Parse(buffer);

            Assert.That(doc.RootElement[0].GetProperty("Foo").ValueKind, Is.EqualTo(JsonValueKind.Null));

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

            Assert.That(doc.RootElement.GetProperty("Foo").GetString(), Is.EqualTo("Hello"));
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

            Assert.That(mdoc.RootElement.GetInt32(), Is.EqualTo(2));
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

            Assert.That(mdoc.RootElement.GetProperty("foo").GetInt32(), Is.EqualTo(1));

            using MemoryStream stream = new();
            mdoc.WriteTo(stream, "J");
            stream.Flush();
            stream.Position = 0;

            Assert.That(BinaryData.FromStream(stream).ToString(), Is.EqualTo("""{"foo":1}"""));
        }

        #region Helpers

        internal static void ValidateWriteTo(BinaryData json, MutableJsonDocument mdoc)
        {
            // To validate MutableJsonDocument.WriteTo(), we want to ensure that
            // its behavior is the same as the behavior of JsonDocument.WriteTo().

            JsonDocument doc = JsonDocument.Parse(json);
            BinaryData jdocBuffer = GetWriteToBuffer(doc);

            BinaryData mdocBuffer = GetWriteToBuffer(mdoc);

            Assert.That(mdocBuffer.ToString(), Is.EqualTo(jdocBuffer.ToString()));
            Assert.That(jdocBuffer.ToMemory().Span.SequenceEqual(mdocBuffer.ToMemory().Span),
                Is.True,
                "JsonDocument buffer does not match MutableJsonDocument buffer.");
        }

        internal static void ValidateWriteTo(string json, MutableJsonDocument mdoc)
        {
            // To validate MutableJsonDocument.WriteTo(), we want to ensure that
            // its behavior is the same as the behavior of JsonDocument.WriteTo().

            JsonDocument doc = JsonDocument.Parse(json);
            BinaryData jdocBuffer = GetWriteToBuffer(doc);

            BinaryData mdocBuffer = GetWriteToBuffer(mdoc);

            Assert.That(mdocBuffer.ToString(), Is.EqualTo(jdocBuffer.ToString()));
            Assert.That(jdocBuffer.ToMemory().Span.SequenceEqual(mdocBuffer.ToMemory().Span),
                Is.True,
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
