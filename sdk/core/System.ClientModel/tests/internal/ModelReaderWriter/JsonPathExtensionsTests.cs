// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;
using System.Text;
using System.Text.Json;
using NUnit.Framework;

namespace System.ClientModel.Tests.Internal.ModelReaderWriterTests
{
    public class JsonPathExtensionsTests
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
            var ex = Assert.Throws<InvalidOperationException>(() => json.GetJson(Encoding.UTF8.GetBytes(jsonPathStr)));
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
        [TestCase("$.a[0][1][2]", "$.a")]
        public void GetFirstNonArrayy(string jsonPathStr, string expected)
        {
            byte[] jsonPath = Encoding.UTF8.GetBytes(jsonPathStr);
            var first = jsonPath.GetFirstNonIndexParent();
            Assert.AreEqual(expected, Encoding.UTF8.GetString(first.ToArray()));
        }

        [TestCase(".foo.bar[0]", "foo")]
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
        [TestCase("['pr.op'][0].x", "pr.op")]
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
        [TestCase("$.a[12]", "12")]
        [TestCase("$['a'][\"b\"]", "")]
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

        [TestCase("$.a.b.c", "$.a")]
        [TestCase("$.foo.bar.baz", "$.foo")]
        [TestCase("$['prop'].x.y", "$['prop']")]
        [TestCase("$[\"prop\"].x.y", "$[\"prop\"]")]
        [TestCase("$", "$")]
        public void GetFirstProperty(string jsonPathStr, string expected)
        {
            ReadOnlySpan<byte> jsonPath = Encoding.UTF8.GetBytes(jsonPathStr);
            var first = jsonPath.GetFirstProperty();
            Assert.AreEqual(expected, Encoding.UTF8.GetString(first.ToArray()));
        }

        [TestCase("{\"a\":1,\"b\":2}", "$.c", "3", false, "{\"a\":1,\"b\":2,\"c\":3}")]
        [TestCase("{\"a\":1}", "$.a", "2", true, "{\"a\":2}")]
        [TestCase("{\"arr\":[1,2]}", "$.arr[1]", "10", true, "{\"arr\":[1,10]}")]
        [TestCase("{}", "$.new", "42", false, "{\"new\":42}")]
        public void SetCurrentValue(string jsonStr, string jsonPathStr, string newValue, bool shouldBeFound, string expected)
        {
            ReadOnlyMemory<byte> json = Encoding.UTF8.GetBytes(jsonStr);
            ReadOnlySpan<byte> jsonPath = Encoding.UTF8.GetBytes(jsonPathStr);
            ReadOnlyMemory<byte> value = Encoding.UTF8.GetBytes(newValue);

            var reader = new Utf8JsonReader(json.Span);
            Assert.AreEqual(shouldBeFound, reader.Advance(jsonPath));

            var result = reader.SetCurrentValue(shouldBeFound, jsonPath.GetPropertyName(), json, value);
            Assert.AreEqual(expected, Encoding.UTF8.GetString(result));
        }

        [TestCase("{\"arr\":[1,2,3]}", "$.arr[1]", "10", "{\"arr\":[1,10,2,3]}")]
        [TestCase("{\"arr\":[1,2,3]}", "$.arr[0]", "10", "{\"arr\":[10,1,2,3]}")]
        [TestCase("{\"arr\":[1,2,3]}", "$.arr[3]", "4", "{\"arr\":[1,2,3,4]}")]
        [TestCase("{\"arr\":[1,2,3]}", "$.arr[4]", "4", "{\"arr\":[1,2,3,null,4]}")]
        [TestCase("{\"arr\":[1,2,3]}", "$.arr[5]", "6", "{\"arr\":[1,2,3,null,null,6]}")]
        [TestCase("{\"arr\":null}", "$.arr[0]", "1", "{\"arr\":[1]}")]
        [TestCase("{\"arr\":[[1,2],[3,4]]}", "$.arr[0][1]", "6", "{\"arr\":[[1,6,2],[3,4]]}")]
        [TestCase("{\"arr\":[[1,2],[3,4]]}", "$.arr[3][1]", "6", "{\"arr\":[[1,2],[3,4],null,[null,6]]}")]
        [TestCase("{\"arr\":[[[1],[]],[[3,4]]]}", "$.arr[0][1][1]", "6", "{\"arr\":[[[1],[null,6]],[[3,4]]]}")]
        [TestCase("{\"arr\":[[[1],[]],[[3,4]]]}", "$.arr[3][3][0]", "6", "{\"arr\":[[[1],[]],[[3,4]],null,[null,null,null,[6]]]}")]
        [TestCase("{\"arr\":[[[[1],[]],[[3,4]]]]}", "$.arr[0][0][1][1]", "6", "{\"arr\":[[[[1],[null,6]],[[3,4]]]]}")]
        [TestCase("{\"arr\":[[[[1],[]],[[3,4]]]]}", "$.arr[3][3][3][1]", "6", "{\"arr\":[[[[1],[]],[[3,4]]],null,null,[null,null,null,[null,null,null,[null,6]]]]}")]
        [TestCase("{\"arr\":[]}", "$.arr[3]", "5", "{\"arr\":[null,null,null,5]}")]
        [TestCase("{\"arr\":[]}", "$.arr[3][2]", "7", "{\"arr\":[null,null,null,[null,null,7]]}")]
        public void InsertAt(string jsonStr, string arrayPathStr, string newValue, string expected)
        {
            ReadOnlyMemory<byte> json = Encoding.UTF8.GetBytes(jsonStr);
            ReadOnlySpan<byte> arrayPath = Encoding.UTF8.GetBytes(arrayPathStr);
            ReadOnlyMemory<byte> value = Encoding.UTF8.GetBytes(newValue);

            var result = json.InsertAt(arrayPath, value);
            Assert.AreEqual(expected, Encoding.UTF8.GetString(result));
        }

        [TestCase("{\"arr\":1}", "$.arr[1]")]
        [TestCase("{\"arr\":{}}", "$.arr[1]")]
        [TestCase("{\"arr\":\"x\"}", "$.arr[1]")]
        public void InsertAt_InvalidPath_Throws(string jsonStr, string arrayPathStr)
        {
            ReadOnlyMemory<byte> json = Encoding.UTF8.GetBytes(jsonStr);
            var ex = Assert.Throws<FormatException>(() => json.InsertAt(Encoding.UTF8.GetBytes(arrayPathStr), Encoding.UTF8.GetBytes("1")));
            Assert.AreEqual($"$.arr is not an array.", ex!.Message);
        }

        [TestCase("{\"a\":1,\"b\":2}", "$.a", true)]
        [TestCase("{\"a\":1,\"b\":2}", "$.c", false)]
        [TestCase("{\"arr\":[1,2,3]}", "$.arr[1]", true)]
        [TestCase("{\"arr\":[1,2,3]}", "$.arr[5]", false)]
        [TestCase("{}", "$", true)]
        public void Advance_JsonPath(string jsonStr, string jsonPathStr, bool expected)
        {
            ReadOnlyMemory<byte> json = Encoding.UTF8.GetBytes(jsonStr);
            ReadOnlySpan<byte> jsonPath = Encoding.UTF8.GetBytes(jsonPathStr);

            var reader = new Utf8JsonReader(json.Span);
            bool result = reader.Advance(jsonPath);
            Assert.AreEqual(expected, result);
        }

        [TestCase("{\"a\":1,\"b\":2}", "$.a", true)]
        [TestCase("{\"a\":1,\"b\":2}", "$.c", false)]
        [TestCase("{\"arr\":[1,2,3]}", "$.arr[1]", true)]
        [TestCase("{\"arr\":[1,2,3]}", "$.arr[5]", false)]
        [TestCase("{}", "$", true)]
        public void Advance_PathReader(string jsonStr, string jsonPathStr, bool expected)
        {
            ReadOnlyMemory<byte> json = Encoding.UTF8.GetBytes(jsonStr);
            ReadOnlySpan<byte> jsonPath = Encoding.UTF8.GetBytes(jsonPathStr);

            var reader = new Utf8JsonReader(json.Span);
            var pathReader = new JsonPathReader(jsonPath);
            bool result = reader.Advance(ref pathReader);
            Assert.AreEqual(expected, result);
        }

        [TestCase("{\"arr\":[1]}", "$.arr", "", "2", "{\"arr\":[1,2]}")]
        [TestCase("{\"arr\":[]}", "$.arr", "", "1", "{\"arr\":[1]}")]
        [TestCase("{\"obj\":{}}", "$.obj", "prop", "value", "{\"obj\":{\"prop\":value}}")]
        [TestCase("{\"arr\":[1,2]}", "$.arr", "", "3", "{\"arr\":[1,2,3]}")]
        public void Insert(string jsonStr, string jsonPathStr, string propertyNameStr, string newValue, string expected)
        {
            ReadOnlyMemory<byte> json = Encoding.UTF8.GetBytes(jsonStr);
            ReadOnlySpan<byte> jsonPath = Encoding.UTF8.GetBytes(jsonPathStr);
            ReadOnlyMemory<byte> value = Encoding.UTF8.GetBytes(newValue);
            ReadOnlySpan<byte> propertyName = string.IsNullOrEmpty(propertyNameStr) ? ReadOnlySpan<byte>.Empty : Encoding.UTF8.GetBytes(propertyNameStr);

            var reader = new Utf8JsonReader(json.Span);
            reader.Advance(jsonPath);

            var result = reader.Insert(json, propertyName, value);
            Assert.AreEqual(expected, Encoding.UTF8.GetString(result));
        }

        [TestCase("invalid")]
        [TestCase("")]
        public void GetPropertyName_InvalidPath_Throws(string jsonPathStr)
        {
            var ex = Assert.Throws<ArgumentException>(() => Encoding.UTF8.GetBytes(jsonPathStr).GetPropertyName());
#if NET8_0_OR_GREATER
            Assert.AreEqual("JsonPath must start with '$' (Parameter 'jsonPath')", ex!.Message.Split('\n')[0]);
#else
            Assert.AreEqual("JsonPath must start with '$'\r\nParameter name: jsonPath", ex!.Message);
#endif
        }

        [TestCase("invalid")]
        [TestCase("")]
        public void GetParent_InvalidPath_Throws(string jsonPathStr)
        {
            var ex = Assert.Throws<ArgumentException>(() => Encoding.UTF8.GetBytes(jsonPathStr).GetParent());
#if NET8_0_OR_GREATER
            Assert.AreEqual("JsonPath must start with '$' (Parameter 'jsonPath')", ex!.Message.Split('\n')[0]);
#else
            Assert.AreEqual("JsonPath must start with '$'\r\nParameter name: jsonPath", ex!.Message);
#endif
        }

        [TestCase("invalid")]
        [TestCase("")]
        public void GetIndexSpan_InvalidPath_Throws(string jsonPathStr)
        {
            var ex = Assert.Throws<ArgumentException>(() => Encoding.UTF8.GetBytes(jsonPathStr).GetIndexSpan());
#if NET8_0_OR_GREATER
            Assert.AreEqual("JsonPath must start with '$' (Parameter 'jsonPath')", ex!.Message.Split('\n')[0]);
#else
            Assert.AreEqual("JsonPath must start with '$'\r\nParameter name: jsonPath", ex!.Message);
#endif
        }

        [TestCase("invalid")]
        [TestCase("")]
        public void Advance_InvalidPath_Throws(string jsonPathStr)
        {
            var json = Encoding.UTF8.GetBytes("{}");
            ReadOnlySpan<byte> jsonPath = Encoding.UTF8.GetBytes(jsonPathStr);

            var reader = new Utf8JsonReader(json);
            bool exceptionThrown = false;
            try
            {
                reader.Advance(jsonPath);
            }
            catch (ArgumentException ex)
            {
#if NET8_0_OR_GREATER
                Assert.AreEqual("JsonPath must start with '$' (Parameter 'jsonPath')", ex!.Message);
#else
                Assert.AreEqual("JsonPath must start with '$'\r\nParameter name: jsonPath", ex!.Message);
#endif
                exceptionThrown = true;
            }
            Assert.IsTrue(exceptionThrown);
        }

        [TestCase("{\"arr\":[1,2,3],\"notArray\":1}", "$.notArray", "$.notArray is not an array.")]
        [TestCase("{\"obj\":{}}", "$.missing", "$.missing was not found in the JSON structure.")]
        public void GetArrayLength_InvalidCases_Throws(string jsonStr, string jsonPathStr, string expectedMessage)
        {
            ReadOnlyMemory<byte> json = Encoding.UTF8.GetBytes(jsonStr);
            ReadOnlySpan<byte> jsonPath = Encoding.UTF8.GetBytes(jsonPathStr);

            var reader = new Utf8JsonReader(json.Span);
            bool exceptionThrown = false;
            try
            {
                reader.GetArrayLength(jsonPath);
            }
            catch (Exception ex)
            {
                Assert.AreEqual(expectedMessage, ex!.Message);
                exceptionThrown = true;
            }
            Assert.IsTrue(exceptionThrown);
        }

        [TestCase("$", "/")]
        [TestCase("$[0]", "/0")]
        [TestCase("$.x", "/x")]
        [TestCase("$['x']", "/x")]
        [TestCase("$[\"x\"]", "/x")]
        [TestCase("$.x.['y'][4].[\"z\"][12].a", "/x/y/4/z/12/a")]
        [TestCase("$.x.['y'][4].[\"z~z/\"][12].a", "/x/y/4/z~0z~1/12/a")]
        [TestCase("$.~", "/~0")]
        [TestCase("$.~x", "/~0x")]
        [TestCase("$.x~", "/x~0")]
        [TestCase("$['a~b/c'].x", "/a~0b~1c/x")]
        public void ConvertToJsonPointer(string jsonPathStr, string expectedJsonPointer)
        {
            byte[] jsonPath = Encoding.UTF8.GetBytes(jsonPathStr);
            Span<byte> jsonPointerSpan = stackalloc byte[jsonPath.Length << 1];
            int bytesWritten = jsonPath.ConvertToJsonPointer(jsonPointerSpan);
            Assert.AreEqual(expectedJsonPointer, Encoding.UTF8.GetString(jsonPointerSpan.Slice(0, bytesWritten).ToArray()));
        }

        [TestCase("$", "/-")]
        [TestCase("$[0]", "/0/-")]
        [TestCase("$.x", "/x/-")]
        [TestCase("$['x']", "/x/-")]
        [TestCase("$[\"x\"]", "/x/-")]
        [TestCase("$.x.['y'][4].[\"z\"][12].a", "/x/y/4/z/12/a/-")]
        [TestCase("$.x.['y'][4].[\"z~z/\"][12].a", "/x/y/4/z~0z~1/12/a/-")]
        [TestCase("$.~", "/~0/-")]
        [TestCase("$.~x", "/~0x/-")]
        [TestCase("$.x~", "/x~0/-")]
        [TestCase("$['a~b/c'].x", "/a~0b~1c/x/-")]
        public void ConvertToJsonPointerAppend(string jsonPathStr, string expectedJsonPointer)
        {
            byte[] jsonPath = Encoding.UTF8.GetBytes(jsonPathStr);
            Span<byte> jsonPointerSpan = stackalloc byte[jsonPath.Length << 1];
            int bytesWritten = jsonPath.ConvertToJsonPointer(jsonPointerSpan, true);
            Assert.AreEqual(expectedJsonPointer, Encoding.UTF8.GetString(jsonPointerSpan.Slice(0, bytesWritten).ToArray()));
        }

        [TestCase("{\"x\":1,\"y\":2,\"z\":3}", "$.x", "{\"y\":2,\"z\":3}")]
        [TestCase("{\"x\":1,\"y\":2,\"z\":3}", "$.y", "{\"x\":1,\"z\":3}")]
        [TestCase("{\"x\":1,\"y\":2,\"z\":3}", "$.z", "{\"x\":1,\"y\":2}")]
        [TestCase("{\"x\":1,\"y\":2}", "$.x", "{\"y\":2}")]
        [TestCase("{\"x\":1,\"y\":2}", "$.y", "{\"x\":1}")]
        [TestCase("{\"x\":1, \"y\":2 \r\n}", "$.y", "{\"x\":1}")]
        [TestCase("{\"x\":{\"y\":1},\"a\":{\"b\":2}}", "$.x", "{\"a\":{\"b\":2}}")]
        [TestCase("{\"x\":{\"y\":1},\"a\":{\"b\":2}}", "$.x.y", "{\"x\":{},\"a\":{\"b\":2}}")]
        [TestCase("{\"x\":{\"y\":1},\"a\":{\"b\":2}}", "$.a", "{\"x\":{\"y\":1}}")]
        [TestCase("{\"x\":{\"y\":1},\"a\":{\"b\":2}}", "$.a.b", "{\"x\":{\"y\":1},\"a\":{}}")]
        [TestCase("{\"arr\":[1,2, \r\n3]}", "$.arr[2]", "{\"arr\":[1,2]}")]
        [TestCase("{\"arr\":[1,2, \r\n3  ]}", "$.arr[2]", "{\"arr\":[1,2]}")]
        [TestCase("{\"arr\":[1,2,3]}", "$.arr[1]", "{\"arr\":[1,3]}")]
        [TestCase("{\"arr\":[1,2,3]}", "$.arr[0]", "{\"arr\":[2,3]}")]
        [TestCase("{\"arr\":[1,2,3]}", "$.arr[2]", "{\"arr\":[1,2]}")]
        [TestCase("{\"arr\":[[1,2],[3,4],[5,6]]}", "$.arr[0]", "{\"arr\":[[3,4],[5,6]]}")]
        [TestCase("{\"arr\":[[1,2],[3,4],[5,6]]}", "$.arr[1]", "{\"arr\":[[1,2],[5,6]]}")]
        [TestCase("{\"arr\":[[1,2],[3,4],[5,6]]}", "$.arr[2]", "{\"arr\":[[1,2],[3,4]]}")]
        [TestCase("{\"arr\":[[1,2],[3,4],[5,6]]}", "$.arr[0][0]", "{\"arr\":[[2],[3,4],[5,6]]}")]
        [TestCase("{\"arr\":[[1,2],[3,4],[5,6]]}", "$.arr[1][1]", "{\"arr\":[[1,2],[3],[5,6]]}")]
        [TestCase("{\"arr\":[[1,2],[3,4],[5,6]]}", "$.arr[2][0]", "{\"arr\":[[1,2],[3,4],[6]]}")]
        public void RemoveAt(string jsonStr, string jsonPathStr, string expectedJsonPointer)
        {
            byte[] jsonPath = Encoding.UTF8.GetBytes(jsonPathStr);
            ReadOnlyMemory<byte> json = Encoding.UTF8.GetBytes(jsonStr);
            var newJson = json.Remove(jsonPath.AsSpan());
            Assert.AreEqual(expectedJsonPointer, Encoding.UTF8.GetString(newJson));
        }
    }
}
