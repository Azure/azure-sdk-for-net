// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using NUnit.Framework;

namespace Azure.Core.Tests
{
    public class WriterExtensionTests
    {
        private static object[] ObjectCases =
        {
            new object[] { null, "null" },
            new object[] { new byte[] { 1, 2, 3, 4}, @"""AQIDBA==""" },
            new object[] { 42, "42" },
            new object[] { 42.0m, "42.0" },
            new object[] { 42.0d, "42" },
            new object[] { 42.0f, "42" },
            new object[] { 42L, "42" },
            new object[] { "asdf", @"""asdf""" },
            new object[] { false, "false" },
            new object[] { new Guid ("c6125705-61d7-4cd6-8d6c-f7f247a7a5fa"), @"""c6125705-61d7-4cd6-8d6c-f7f247a7a5fa""" },
            new object[] { new BinaryData (new byte[] { 1, 2, 3, 4}), @"""AQIDBA==""" },
            new object[] { new DateTimeOffset (2001, 1, 1, 1, 1, 1, 1, new TimeSpan ()), @"""2001-01-01T01:01:01.0010000Z""" },
            new object[] { new DateTime (2001, 1, 1, 1, 1, 1, DateTimeKind.Utc), @"""2001-01-01T01:01:01.0000000Z""" },
            new object[] { (IEnumerable<object>)new List<object>() { 1, 2, 3, 4 }, "[1,2,3,4]" },
            new object[] { (IEnumerable<KeyValuePair<string, object>>)new List<KeyValuePair<string, object>>() {
                new KeyValuePair<string, object> ("a", (object)1),
                new KeyValuePair<string, object> ("b", (object)2),
                new KeyValuePair<string, object> ("c", (object)3),
                new KeyValuePair<string, object> ("d", (object)4),
            },
            @"{""a"":1,""b"":2,""c"":3,""d"":4}"
            },
        };

        [Test, TestCaseSource("ObjectCases")]
        public static void WriteObjectValue (object value, string expectedJson)
        {
            using MemoryStream stream = new MemoryStream ();
            using Utf8JsonWriter writer = new Utf8JsonWriter (stream);
            writer.WriteObjectValue (value);

            writer.Flush ();
            Assert.AreEqual (expectedJson, System.Text.Encoding.UTF8.GetString(stream.ToArray()));
        }

        [Test]
        public static void WriteObjectValueJsonElement ()
        {
            using MemoryStream stream = new MemoryStream ();
            using Utf8JsonWriter writer = new Utf8JsonWriter (stream);

            string json = @"{""TablesToMove"": [{""TableName"":""TestTable""}]}";
            Dictionary<string, object> content = JsonSerializer.Deserialize<Dictionary<string, object>>(json);
            JsonElement element = (JsonElement)content["TablesToMove"];
            writer.WriteObjectValue (element);
            writer.Flush ();

            Assert.AreEqual (@"[{""TableName"":""TestTable""}]", System.Text.Encoding.UTF8.GetString(stream.ToArray()));
        }

        [Test]
        public static void WriteObjectValueIUtf8JsonSerializable ()
        {
            using MemoryStream stream = new MemoryStream ();
            using Utf8JsonWriter writer = new Utf8JsonWriter (stream);

            var content = new TestSerialize ();
            writer.WriteObjectValue (content);
            Assert.True (content.didWrite);
        }

        [Test]
        public static void WriteObjectValueNullIUtf8JsonSerializable ()
        {
            using MemoryStream stream = new MemoryStream ();
            using Utf8JsonWriter writer = new Utf8JsonWriter (stream);

            TestSerialize content = null;
            writer.WriteObjectValue(content);

            writer.Flush();
            Assert.AreEqual("null", System.Text.Encoding.UTF8.GetString(stream.ToArray()));
        }

        internal class TestSerialize : IUtf8JsonSerializable
        {
            internal bool didWrite = false;

            public void Write(Utf8JsonWriter writer)
            {
                didWrite = true;
            }
        }
    }
}
