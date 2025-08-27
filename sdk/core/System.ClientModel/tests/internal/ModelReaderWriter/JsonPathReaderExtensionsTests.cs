// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;
using System.Text;
using System.Text.Json;
using NUnit.Framework;

namespace System.ClientModel.Tests.Internal.ModelReaderWriterTests
{
    public class JsonPathReaderExtensionsTests
    {
        [TestCase("{\"obj\":{\"a\":1}}", "$.obj", "{\"a\":1}")]
        [TestCase("{\"ob.j\":{\"a\":1}}", "$['ob.j']", "{\"a\":1}")]
        [TestCase("{\"ob\\\"j\":{\"a\":1}}", "$['ob\\\"j']", "{\"a\":1}")]
        [TestCase("{\"obj\":{\"arr\":[1,2,3]}}", "$.obj.arr[1]", "2")]
        [TestCase("{\"obj\":{\"arr\":[{\"x\":{\"y\":1}},{\"x\":{\"y\":2}},{\"x\":{\"y\":3}}]}}", "$.obj.arr[1]", "{\"x\":{\"y\":2}}")]
        [TestCase("{\"obj\":{\"arr\":[{\"x\":{\"y\":1}},{\"x\":{\"y\":2}},{\"x\":{\"y\":3}}]}}", "$.obj.arr", "[{\"x\":{\"y\":1}},{\"x\":{\"y\":2}},{\"x\":{\"y\":3}}]")]
        [TestCase("{\"obj\":{\"arr\":[{\"x\":{\"y\":1}},{\"x\":{\"y\":2}},{\"x\":{\"y\":3}}]}}", "$.obj.arr[2].x", "{\"y\":3}")]
        public void TryGetJson_Found(string jsonStr, string jsonPathStr, string expected)
        {
            ReadOnlyMemory<byte> json = Encoding.UTF8.GetBytes(jsonStr);
            ReadOnlySpan<byte> jsonPath = Encoding.UTF8.GetBytes(jsonPathStr);
            Assert.IsTrue(json.TryGetJson(jsonPath, out var slice));
            Assert.AreEqual(expected, Encoding.UTF8.GetString(slice.ToArray()));
        }

        [TestCase("{\"a\":1}", "$.missing")]
        [TestCase("{\"a\":1}", "$.a[0]")]
        [TestCase("{\"a\":[1,2]}", "$.a[2]")]
        [TestCase("{\"a\":[1,2]}", "$.a[10]")]
        [TestCase("{\"a\":[1,2]}", "$.a[0].x")]
        public void GetJson_NotFound_Throws(string jsonStr, string jsonPathStr)
        {
            ReadOnlyMemory<byte> json = Encoding.UTF8.GetBytes(jsonStr);
            var ex = Assert.Throws<Exception>(() => json.GetJson(Encoding.UTF8.GetBytes(jsonPathStr)));
            Assert.AreEqual($"{jsonPathStr} was not found in the JSON structure.", ex!.Message);
        }

        [TestCase("{\"a\":1,\"b\":2}", "$.b", "100", "{\"a\":1,\"b\":100}")]
        [TestCase("{\"a\":1,\"b\":2}", "$.a", "100", "{\"a\":100,\"b\":2}")]
        [TestCase("{\"a\":1,\"b\":\"value\"}", "$.b", "\"newValue\"", "{\"a\":1,\"b\":\"newValue\"}")]
        [TestCase("{\"a\":1,\"b\":\"value\",\"c\":[1,2,3]}", "$.c[0]", "10", "{\"a\":1,\"b\":\"value\",\"c\":[10,2,3]}")]
        [TestCase("{\"a\":1,\"b\":\"value\",\"c\":[1,2,3]}", "$.c[1]", "10", "{\"a\":1,\"b\":\"value\",\"c\":[1,10,3]}")]
        [TestCase("{\"a\":1,\"b\":\"value\",\"c\":[1,2,3]}", "$.c[2]", "10", "{\"a\":1,\"b\":\"value\",\"c\":[1,2,10]}")]
        [TestCase("{\"a\":1}", "$.b", "2", "{\"a\":1,\"b\":2}")]
        public void Json_Set(string jsonStr, string jsonPathStr, string newValue, string expected)
        {
            ReadOnlyMemory<byte> json = Encoding.UTF8.GetBytes(jsonStr);
            ReadOnlySpan<byte> jsonPath = Encoding.UTF8.GetBytes(jsonPathStr);
            ReadOnlyMemory<byte> value = Encoding.UTF8.GetBytes(newValue);
            var replaced = json.Set(jsonPath, value);
            Assert.AreEqual(expected, Encoding.UTF8.GetString(replaced));
        }

        [TestCase("{\"a\":1,\"b\":2}", "$.b", "{\"a\":1}")]
        [TestCase("{\"a\":1}", "$.a", "{}")]
        [TestCase("{\"a\":1,\"b\":2,\"c\":3}", "$.b", "{\"a\":1,\"c\":3}")]
        public void Json_Remove(string jsonStr, string jsonPathStr, string expected)
        {
            ReadOnlyMemory<byte> json = Encoding.UTF8.GetBytes(jsonStr);
            ReadOnlySpan<byte> jsonPath = Encoding.UTF8.GetBytes(jsonPathStr);
            var updated = json.Remove(jsonPath);
            Assert.AreEqual(expected, Encoding.UTF8.GetString(updated));
        }

        [TestCase("{\"arr\":[1]}", "$.arr", "2", "{\"arr\":[1,2]}")]
        [TestCase("{\"arr\":[]}", "$.arr", "2", "{\"arr\":[2]}")]
        [TestCase("{\"arr\":[{\"x\":1}]}", "$.arr", "{\"x\":2}", "{\"arr\":[{\"x\":1},{\"x\":2}]}")]
        [TestCase("{\"arr\":[]}", "$.arr", "{\"x\":2}", "{\"arr\":[{\"x\":2}]}")]
        public void Append_Array(string jsonStr, string jsonPathStr, string newValue, string expected)
        {
            ReadOnlyMemory<byte> json = Encoding.UTF8.GetBytes(jsonStr);
            ReadOnlySpan<byte> jsonPath = Encoding.UTF8.GetBytes(jsonPathStr);
            ReadOnlyMemory<byte> value = Encoding.UTF8.GetBytes(newValue);
            var appended = json.Append(jsonPath, value);
            Assert.AreEqual(expected, Encoding.UTF8.GetString(appended));
        }

        [TestCase("{\"arr\":[10,20,30]}", "$.arr", 3)]
        [TestCase("{\"arr\":[]}", "$.arr", 0)]
        public void GetArrayLength(string jsonStr, string jsonPathStr, int expectedLength)
        {
            ReadOnlyMemory<byte> json = Encoding.UTF8.GetBytes(jsonStr);
            ReadOnlySpan<byte> jsonPath = Encoding.UTF8.GetBytes(jsonPathStr);
            var reader = new Utf8JsonReader(json.Span);
            int length = reader.GetArrayLength(jsonPath);
            Assert.AreEqual(expectedLength, length);
        }

        [TestCase("$[0]", true)]
        [TestCase("$.x[0]", true)]
        [TestCase("$[0].x", false)]
        public void IsArrayIndex_Positive(string jsonPathStr, bool expected)
        {
            ReadOnlySpan<byte> jsonPath = Encoding.UTF8.GetBytes(jsonPathStr);
            Assert.AreEqual(expected, jsonPath.IsArrayIndex());
        }

        [TestCase("$[0][1].a", "$[0][1].a")]
        [TestCase("$[0][1]", "$")]
        [TestCase("$.x[0][1].a", "$.x[0][1].a")]
        [TestCase("$.x[0][1]", "$.x")]
        [TestCase("$.x.y[0][1].a", "$.x.y[0][1].a")]
        [TestCase("$.x.y[0][1]", "$.x.y")]
        [TestCase("$[0].x[1].a", "$[0].x[1].a")]
        [TestCase("$[0].x[1]", "$[0].x")]
        public void GetFirstNonArrayy(string jsonPathStr, string expected)
        {
            byte[] jsonPath = Encoding.UTF8.GetBytes(jsonPathStr);
            var first = jsonPath.GetFirstNonIndexParent();
            Assert.AreEqual(expected, Encoding.UTF8.GetString(first.ToArray()));
        }

        [TestCase("foo.bar", "foo")]
        [TestCase("['prop'].x", "prop")]
        [TestCase("$['prop'].x", "prop")]
        [TestCase("prop'].x", "prop")]
        [TestCase("pr'op'].x", "pr'op")]
        [TestCase("pr\"op'].x", "pr\"op")]
        [TestCase("pr.op'].x", "pr")]
        [TestCase("prop.x", "prop")]
        [TestCase("pr'op.x", "pr'op")]
        [TestCase("pr\"op.x", "pr\"op")]
        [TestCase("pr.op.x", "pr")]
        [TestCase("prop\"].x", "prop")]
        [TestCase("pr'op\"].x", "pr'op")]
        [TestCase("pr\"op\"].x", "pr\"op")]
        [TestCase("pr.op\"].x", "pr")]
        [TestCase("prop[0].x", "prop")]
        [TestCase("['pr\"op'][0].x", "pr\"op")]
        public void GetPropertyNameFromSlice(string jsonSliceStr, string expected)
        {
            ReadOnlySpan<byte> jsonSlice = Encoding.UTF8.GetBytes(jsonSliceStr);
            var name = jsonSlice.GetPropertyNameFromSlice();
            Assert.AreEqual(expected, Encoding.UTF8.GetString(name.ToArray()));
        }

        [TestCase("$.a.b.c", "c")]
        [TestCase("$.a.b['c']", "c")]
        [TestCase("$.a.b[\"c\"]", "c")]
        [TestCase("$.a.b.c[0]", "c")]
        [TestCase("$", "")]
        public void GetPropertyName(string jsonPathStr, string expected)
        {
            ReadOnlySpan<byte> jsonPath = Encoding.UTF8.GetBytes(jsonPathStr);
            var last = jsonPath.GetPropertyName();
            Assert.AreEqual(expected, Encoding.UTF8.GetString(last.ToArray()));
        }

        [TestCase("$.foo.bar", "$.foo")]
        [TestCase("$['foo'].bar", "$['foo']")]
        [TestCase("$[0].bar", "$[0]")]
        [TestCase("$.x[0].bar", "$.x[0]")]
        [TestCase("$.x[0]", "$.x")]
        [TestCase("$[0]", "$")]
        [TestCase("$['f.oo'].bar", "$['f.oo']")]
        [TestCase("$.bar['f.oo']", "$.bar")]
        public void GetParent(string jsonPathStr, string expected)
        {
            var result = Encoding.UTF8.GetBytes(jsonPathStr).GetParent();
            Assert.AreEqual(expected, Encoding.UTF8.GetString(result.ToArray()));
        }

        [TestCase("$[123]", "123")]
        [TestCase("$[0]", "0")]
        [TestCase("$['0']", "")]
        public void GetIndexSpan_Value(string jsonPathStr, string expected)
        {
            var index = Encoding.UTF8.GetBytes(jsonPathStr).GetIndexSpan();
            Assert.AreEqual(expected, Encoding.UTF8.GetString(index.ToArray()));
        }

        [TestCase("$", true)]
        [TestCase(".$", false)]
        [TestCase("$.x", false)]
        public void IsRoot(string jsonPathStr, bool expected)
        {
            var root = Encoding.UTF8.GetBytes(jsonPathStr);
            Assert.AreEqual(expected, root.IsRoot());
        }

        [TestCase("[10,20,30]", "10", 0, 0)]
        [TestCase("[10,20,30]", "20", 1, 1)]
        [TestCase("[10,20,30]", "30", 2, 2)]
        public void SkipToIndex(string jsonStr, string expectedValue, int index, int expectedMaxIndex)
        {
            var json = Encoding.UTF8.GetBytes(jsonStr);
            var reader = new Utf8JsonReader(json);
            Assert.IsTrue(reader.Read());
            int maxIndex;
            Assert.IsTrue(reader.SkipToIndex(index, out maxIndex));
            Assert.AreEqual(expectedValue, Encoding.UTF8.GetString(reader.ValueSpan.ToArray()));
            Assert.AreEqual(expectedMaxIndex, maxIndex);
        }

        [TestCase("[10,20,30]", -1, 3)]
        [TestCase("[10,20,30]", 3, 3)]
        [TestCase("[10,20,30]", 10, 3)]
        public void SkipToIndex_NotFound_Throws(string jsonStr, int index, int expectedMaxIndex)
        {
            var json = Encoding.UTF8.GetBytes(jsonStr);
            var reader = new Utf8JsonReader(json);
            Assert.IsTrue(reader.Read());
            int maxIndex;
            Assert.IsFalse(reader.SkipToIndex(index, out maxIndex));
            Assert.AreEqual(expectedMaxIndex, maxIndex);
        }
    }
}
