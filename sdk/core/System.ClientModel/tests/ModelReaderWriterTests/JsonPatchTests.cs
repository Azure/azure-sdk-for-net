// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Internal;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using NUnit.Framework;

namespace System.ClientModel.Tests.ModelReaderWriterTests
{
    internal class JsonPatchTests
    {
        [Test]
        public void AddPrimitive_StringAndInt()
        {
            JsonPatch jp = new();

            jp.Set("$.property"u8, "value");
            jp.Set("$.property2"u8, 10);

            Assert.That(jp.Contains("$.property"u8), Is.True);
            Assert.That(jp.GetString("$.property"u8), Is.EqualTo("value"));
            Assert.That(jp.GetInt32("$.property2"u8), Is.EqualTo(10));

            Assert.That(jp.ToString("J"), Is.EqualTo("{\"property\":\"value\",\"property2\":10}"));
        }

        [Test]
        public void AddRootArray_String()
        {
            JsonPatch jp = new();

            jp.Append("$"u8, "value");

            Assert.That(jp.GetJson("$"u8).ToString(), Is.EqualTo("[\"value\"]"));
            Assert.That(jp.GetString("$[0]"u8), Is.EqualTo("value"));

            Assert.That(jp.ToString("J"), Is.EqualTo("[\"value\"]"));
        }

        [Test]
        public void AddRootArray_Property_String()
        {
            JsonPatch jp = new();

            jp.Set("$[0].property"u8, "value");

            Assert.That(jp.GetJson("$"u8).ToString(), Is.EqualTo("[{\"property\":\"value\"}]"));
            Assert.That(jp.GetJson("$[0]"u8).ToString(), Is.EqualTo("{\"property\":\"value\"}"));
            Assert.That(jp.GetString("$[0].property"u8), Is.EqualTo("value"));

            Assert.That(jp.ToString("J"), Is.EqualTo("[{\"property\":\"value\"}]"));
        }

        [Test]
        public void TryGetJson_RemovedProperty_EntryExists()
        {
            JsonPatch jp = new();

            jp.Set("$[0].property1"u8, "value1");
            jp.Set("$[0].property2"u8, "value2");

            Assert.That(jp.GetJson("$"u8).ToString(), Is.EqualTo("[{\"property1\":\"value1\",\"property2\":\"value2\"}]"));
            Assert.That(jp.GetJson("$[0]"u8).ToString(), Is.EqualTo("{\"property1\":\"value1\",\"property2\":\"value2\"}"));
            Assert.That(jp.GetString("$[0].property1"u8), Is.EqualTo("value1"));
            Assert.That(jp.GetString("$[0].property2"u8), Is.EqualTo("value2"));

            Assert.That(jp.ToString("J"), Is.EqualTo("[{\"property1\":\"value1\",\"property2\":\"value2\"}]"));

            jp.Remove("$[0].property1"u8);

            Assert.That(jp.GetJson("$"u8).ToString(), Is.EqualTo("[{\"property2\":\"value2\"}]"));
            Assert.That(jp.GetJson("$[0]"u8).ToString(), Is.EqualTo("{\"property2\":\"value2\"}"));
            var ex = Assert.Throws<KeyNotFoundException>(() => jp.GetString("$[0].property1"u8));
            Assert.That(ex!.Message, Is.EqualTo("No value found at JSON path '$[0].property1'."));
            Assert.That(jp.GetString("$[0].property2"u8), Is.EqualTo("value2"));

            Assert.That(jp.ToString("J"), Is.EqualTo("[{\"property2\":\"value2\"}]"));
        }

        [Test]
        public void TryGetJson_RemovedProperty_EntryDoesNotExist()
        {
            JsonPatch jp = new();
            jp.Set("$[0].property1"u8, "value1");
            jp.Set("$[0].property2"u8, "value2");

            Assert.That(jp.GetJson("$"u8).ToString(), Is.EqualTo("[{\"property1\":\"value1\",\"property2\":\"value2\"}]"));
            Assert.That(jp.GetJson("$[0]"u8).ToString(), Is.EqualTo("{\"property1\":\"value1\",\"property2\":\"value2\"}"));
            Assert.That(jp.GetString("$[0].property1"u8), Is.EqualTo("value1"));
            Assert.That(jp.GetString("$[0].property2"u8), Is.EqualTo("value2"));

            Assert.That(jp.ToString("J"), Is.EqualTo("[{\"property1\":\"value1\",\"property2\":\"value2\"}]"));

            var ex = Assert.Throws<InvalidOperationException>(() => jp.Remove("$[0].property3"u8));
            Assert.That(ex!.Message, Is.EqualTo("$[0].property3 was not found in the JSON structure."));
        }

        [Test]
        public void ProjectMultipleJsons()
        {
            JsonPatch jp = new();
            jp.Set("$.x.y[2]['z']"u8, 5);

            Assert.That(jp.GetJson("$.x"u8).ToString(), Is.EqualTo("{\"y\":[null,null,{\"z\":5}]}"));
            Assert.That(jp.GetJson("$.x.y"u8).ToString(), Is.EqualTo("[null,null,{\"z\":5}]"));
            Assert.That(jp.GetJson("$.x.y[0]"u8).ToString(), Is.EqualTo("null"));
            Assert.That(jp.GetJson("$.x.y[1]"u8).ToString(), Is.EqualTo("null"));
            Assert.That(jp.GetJson("$.x.y[2]"u8).ToString(), Is.EqualTo("{\"z\":5}"));
            Assert.That(jp.GetInt32("$.x.y[2]['z']"u8), Is.EqualTo(5));

            Assert.That(jp.ToString("J"), Is.EqualTo("{\"x\":{\"y\":[null,null,{\"z\":5}]}}"));

            jp.Set("$.x.z.a[0].b"u8, 10);

            Assert.That(jp.GetJson("$.x"u8).ToString(), Is.EqualTo("{\"y\":[null,null,{\"z\":5}],\"z\":{\"a\":[{\"b\":10}]}}"));
            Assert.That(jp.GetJson("$.x.y"u8).ToString(), Is.EqualTo("[null,null,{\"z\":5}]"));
            Assert.That(jp.GetJson("$.x.y[0]"u8).ToString(), Is.EqualTo("null"));
            Assert.That(jp.GetJson("$.x.y[1]"u8).ToString(), Is.EqualTo("null"));
            Assert.That(jp.GetJson("$.x.y[2]"u8).ToString(), Is.EqualTo("{\"z\":5}"));
            Assert.That(jp.GetInt32("$.x.y[2]['z']"u8), Is.EqualTo(5));
            Assert.That(jp.GetJson("$.x.z"u8).ToString(), Is.EqualTo("{\"a\":[{\"b\":10}]}"));
            Assert.That(jp.GetJson("$.x.z.a"u8).ToString(), Is.EqualTo("[{\"b\":10}]"));
            Assert.That(jp.GetJson("$.x.z.a[0]"u8).ToString(), Is.EqualTo("{\"b\":10}"));
            Assert.That(jp.GetInt32("$.x.z.a[0].b"u8), Is.EqualTo(10));

            Assert.That(jp.ToString("J"), Is.EqualTo("{\"x\":{\"y\":[null,null,{\"z\":5}],\"z\":{\"a\":[{\"b\":10}]}}}"));
        }

        [Test]
        public void AddPropertyNameWithDot()
        {
            JsonPatch jp = new();
            jp.Set("$['pro.perty']"u8, "value");
            Assert.That(jp.Contains("$['pro.perty']"u8), Is.True);
            Assert.That(jp.GetString("$['pro.perty']"u8), Is.EqualTo("value"));

            Assert.That(jp.ToString("J"), Is.EqualTo("{\"pro.perty\":\"value\"}"));
        }

        [Test]
        public void Contains_ArrayAppend_DoesNotReportArrayPath()
        {
            JsonPatch jp = new();
            jp.Append("$.items"u8, "value1");
            Assert.That(jp.Contains("$.items"u8), Is.False, "Append should not cause Contains(path) to report true for the array container path.");

            Assert.That(jp.GetString("$.items[0]"u8), Is.EqualTo("value1"));
        }

        [Test]
        public void Contains_PrefixProperty_ReportsProperty()
        {
            JsonPatch jp = new("{\"parent\":{\"child\":1}}"u8.ToArray());
            jp.Set("$.parent.child"u8, 10);

            Assert.That(jp.Contains("$.parent.child"u8), Is.True);
            Assert.That(jp.Contains("$.parent"u8, "child"u8), Is.True);

            Assert.That(jp.Contains("$.parent"u8, "missing"u8), Is.False);
            Assert.That(jp.Contains("$.parent.child"u8, "grand"u8), Is.False);
        }

        [Test]
        public void Contains_PrefixProperty_ArrayAppendPotentialInconsistency()
        {
            JsonPatch jp = new();
            jp.Append("$.arr"u8, 5);

            Assert.That(jp.Contains("$.arr"u8), Is.False, "Array container path should not be considered 'contained' after only an append.");

            Assert.That(jp.Contains("$"u8, "arr"u8), Is.True, "Prefix/property Contains currently ignores ArrayItemAppend and reports true.");
        }

        [Test]
        public void IsRemoved_Behavior()
        {
            JsonPatch jp = new("{\"obj\":{\"a\":0,\"b\":1}}"u8.ToArray());

            jp.Set("$.obj.a"u8, 1);
            jp.Set("$.obj.b"u8, 2);

            Assert.That(jp.IsRemoved("$.obj.a"u8), Is.False);
            Assert.That(jp.IsRemoved("$.obj.b"u8), Is.False);

            jp.Remove("$.obj.a"u8);

            Assert.That(jp.IsRemoved("$.obj.a"u8), Is.True);
            Assert.That(jp.IsRemoved("$.obj.b"u8), Is.False);

            var ex = Assert.Throws<KeyNotFoundException>(() => jp.GetInt32("$.obj.a"u8));
            Assert.That(ex!.Message, Is.EqualTo("No value found at JSON path '$.obj.a'."));
        }

        [Test]
        public void RemoveThenResetValue()
        {
            JsonPatch jp = new();
            jp.Set("$.p"u8, 5);
            jp.Remove("$.p"u8);
            jp.Set("$.p"u8, 10);
            Assert.That(jp.IsRemoved("$.p"u8), Is.False);
            Assert.That(jp.GetInt32("$.p"u8), Is.EqualTo(10));
        }

        [Test]
        public void UnsupportedNullableType_Throws()
        {
            JsonPatch jp = new();
            jp.Set("$.c"u8, 1); // store as int
            var ex = Assert.Throws<NotSupportedException>(() => jp.GetNullableValue<char>("$.c"u8));
            Assert.That(ex!.Message, Is.EqualTo("Type 'System.Char' is not supported by GetNullableValue."));
        }

        [Test]
        public void ToString_InvalidFormat_Throws()
        {
            JsonPatch jp = new();
            jp.Set("$.x"u8, 1);
            var ex = Assert.Throws<NotSupportedException>(() => jp.ToString("INVALID"));
            Assert.That(ex!.Message, Is.EqualTo("The format 'INVALID' is not supported."));
        }

        [Test]
        public void Overwrite_Property_WithDifferentTypes()
        {
            JsonPatch jp = new();
            jp.Set("$.v"u8, 10);
            Assert.That(jp.GetInt32("$.v"u8), Is.EqualTo(10));
            jp.Set("$.v"u8, "str");
            Assert.That(jp.GetString("$.v"u8), Is.EqualTo("str"));
        }

        [Test]
        public void TryGetValue_Removed_ReturnsFalse()
        {
            JsonPatch jp = new();
            jp.Set("$.x"u8, 5);
            Assert.That(jp.TryGetValue("$.x"u8, out int v) && v == 5, Is.True);
            jp.Remove("$.x"u8);
            Assert.That(jp.TryGetValue("$.x"u8, out int _), Is.False);
        }

        [Test]
        public void TryGetNullableValue_UnsupportedType_ReturnsFalse()
        {
            JsonPatch jp = new();
            jp.Set("$.a"u8, 1);
            bool found = jp.TryGetNullableValue("$.a"u8, out char? c);
            Assert.That(found, Is.False);
            Assert.That(c.HasValue, Is.False);
        }

        [Test]
        public void Append_ToExistingArrayThenSetConcreteIndex()
        {
            JsonPatch jp = new();
            jp.Append("$.arr"u8, 1);
            jp.Append("$.arr"u8, 2);
            Assert.That(jp.Contains("$.arr"u8), Is.False);
            jp.Set("$.arr[0]"u8, 10);
            Assert.That(jp.GetInt32("$.arr[0]"u8), Is.EqualTo(10));
            Assert.That(jp.GetInt32("$.arr[1]"u8), Is.EqualTo(2));
        }

        [Test]
        public void TryGetJson_OnNullValue()
        {
            JsonPatch jp = new();
            jp.SetNull("$.n"u8);
            Assert.That(jp.TryGetJson("$.n"u8, out var mem), Is.True);
            Assert.That(Encoding.UTF8.GetString(mem.Span.ToArray()), Is.EqualTo("null"));
        }

        [Test]
        public void Set_DeepNestedArrayAndProperties()
        {
            JsonPatch jp = new();

            jp.Set("$.a.b[3].c.d[2].e"u8, 1);

            Assert.That(jp.GetJson("$.a"u8).ToString(), Is.EqualTo("{\"b\":[null,null,null,{\"c\":{\"d\":[null,null,{\"e\":1}]}}]}"));
            Assert.That(jp.GetJson("$.a.b"u8).ToString(), Is.EqualTo("[null,null,null,{\"c\":{\"d\":[null,null,{\"e\":1}]}}]"));
            Assert.That(jp.GetJson("$.a.b[0]"u8).ToString(), Is.EqualTo("null"));
            Assert.That(jp.GetJson("$.a.b[1]"u8).ToString(), Is.EqualTo("null"));
            Assert.That(jp.GetJson("$.a.b[2]"u8).ToString(), Is.EqualTo("null"));
            Assert.That(jp.GetJson("$.a.b[3]"u8).ToString(), Is.EqualTo("{\"c\":{\"d\":[null,null,{\"e\":1}]}}"));
            Assert.That(jp.GetJson("$.a.b[3].c"u8).ToString(), Is.EqualTo("{\"d\":[null,null,{\"e\":1}]}"));
            Assert.That(jp.GetJson("$.a.b[3].c.d"u8).ToString(), Is.EqualTo("[null,null,{\"e\":1}]"));
            Assert.That(jp.GetJson("$.a.b[3].c.d[0]"u8).ToString(), Is.EqualTo("null"));
            Assert.That(jp.GetJson("$.a.b[3].c.d[1]"u8).ToString(), Is.EqualTo("null"));
            Assert.That(jp.GetJson("$.a.b[3].c.d[2]"u8).ToString(), Is.EqualTo("{\"e\":1}"));
            Assert.That(jp.GetInt32("$.a.b[3].c.d[2].e"u8), Is.EqualTo(1));

            Assert.That(jp.ToString("J"), Is.EqualTo("{\"a\":{\"b\":[null,null,null,{\"c\":{\"d\":[null,null,{\"e\":1}]}}]}}"));
        }

        [Test]
        public void Append_ArrayItemPath_AppendsArrayInsideArrayIndex()
        {
            JsonPatch jp = new();

            jp.Append("$.a[3]"u8, 5);

            Assert.That(jp.GetJson("$.a"u8).ToString(), Is.EqualTo("[null,null,null,[5]]"));
            Assert.That(jp.GetJson("$.a[0]"u8).ToString(), Is.EqualTo("null"));
            Assert.That(jp.GetJson("$.a[1]"u8).ToString(), Is.EqualTo("null"));
            Assert.That(jp.GetJson("$.a[2]"u8).ToString(), Is.EqualTo("null"));
            Assert.That(jp.GetJson("$.a[3]"u8).ToString(), Is.EqualTo("[5]"));
            Assert.That(jp.GetInt32("$.a[3][0]"u8), Is.EqualTo(5));

            Assert.That(jp.ToString("J"), Is.EqualTo("{\"a\":[null,null,null,[5]]}"));
        }

        [Test]
        public void Append_PropertyLeaf_AppendsArrayAtProperty()
        {
            JsonPatch jp = new();

            jp.Append("$.a"u8, 5);

            Assert.That(jp.GetJson("$.a"u8).ToString(), Is.EqualTo("[5]"));
            Assert.That(jp.GetInt32("$.a[0]"u8), Is.EqualTo(5));

            Assert.That(jp.ToString("J"), Is.EqualTo("{\"a\":[5]}"));
        }

        [Test]
        public void Append_PropertyLeaf_NestedAfterArrayIndex()
        {
            JsonPatch jp = new();

            jp.Append("$.arr[2].items"u8, "x");

            Assert.That(jp.GetJson("$.arr"u8).ToString(), Is.EqualTo("[null,null,{\"items\":[\"x\"]}]"));
            Assert.That(jp.GetJson("$.arr[0]"u8).ToString(), Is.EqualTo("null"));
            Assert.That(jp.GetJson("$.arr[1]"u8).ToString(), Is.EqualTo("null"));
            Assert.That(jp.GetJson("$.arr[2]"u8).ToString(), Is.EqualTo("{\"items\":[\"x\"]}"));
            Assert.That(jp.GetJson("$.arr[2].items"u8).ToString(), Is.EqualTo("[\"x\"]"));
            Assert.That(jp.GetString("$.arr[2].items[0]"u8), Is.EqualTo("x"));

            Assert.That(jp.ToString("J"), Is.EqualTo("{\"arr\":[null,null,{\"items\":[\"x\"]}]}"));
        }

        [Test]
        public void Branch_ArrayIndex_Final_Append()
        {
            JsonPatch jp = new();

            jp.Append("$.arr[2]"u8, 10);

            Assert.That(jp.GetJson("$.arr"u8).ToString(), Is.EqualTo("[null,null,[10]]"));

            Assert.That(jp.ToString("J"), Is.EqualTo("{\"arr\":[null,null,[10]]}"));
        }

        [Test]
        public void Branch_ArrayIndex_Final_Set()
        {
            JsonPatch jp = new();

            jp.Set("$.arr[3]"u8, 11);

            Assert.That(jp.GetJson("$.arr"u8).ToString(), Is.EqualTo("[null,null,null,11]"));

            Assert.That(jp.ToString("J"), Is.EqualTo("{\"arr\":[null,null,null,11]}"));
        }

        [Test]
        public void Branch_PropertySeparator_Final()
        {
            JsonPatch jp = new();
            var ex = Assert.Throws<InvalidOperationException>(() => jp.Set("$.trailing."u8, 5));
            Assert.That(ex!.Message.ToLowerInvariant(), Does.Contain("property"));
        }

        [Test]
        public void Branch_DirectRoot_Final()
        {
            JsonPatch jp = new();

            jp.Set("$"u8, "{\"x\":1}"u8);

            Assert.That(jp.GetJson("$"u8).ToString(), Is.EqualTo("{\"x\":1}"));

            Assert.That(jp.ToString("J"), Is.EqualTo("{\"x\":1}"));
        }

        [Test]
        public void WriteTo_SubPath_Removed()
        {
            JsonPatch jp = new("{\"a\":{\"b\":{\"x\":1,\"y\":2,\"z\":3}}}"u8.ToArray());

            jp.Remove("$.a.b"u8);

            using var buffer = new UnsafeBufferSequence();
            using var writer = new Utf8JsonWriter(buffer);
            writer.WriteStartObject();
            writer.WritePropertyName("a");
            writer.WriteStartObject();
            jp.WriteTo(writer, "$.a.b"u8);
            writer.WriteEndObject();
            writer.WriteEndObject();
            writer.Flush();

            using var reader = buffer.ExtractReader();
            Assert.That(reader.ToBinaryData().ToString(), Is.EqualTo("{\"a\":{}}"));
        }

        [Test]
        public void SerializeEmptyPatch()
        {
            JsonPatch jp = new();

            Assert.That(jp.ToString(), Is.EqualTo("[]"));
            Assert.That(jp.ToString("J"), Is.EqualTo("{}"));
        }

        [Test]
        public void SetEmptyJson()
        {
            JsonPatch jp = new();

            jp.Set("$.a"u8, ""u8);

            var ex = Assert.Throws<ArgumentException>(() => jp.ToString("J"));
            Assert.That(ex!.Message, Is.EqualTo("Empty encoded value"));
        }

        [Test]
        public void SerializeSeededEmptyPatch()
        {
            JsonPatch jp = new("{\"x\":1}"u8.ToArray());

            Assert.That(jp.ToString(), Is.EqualTo("[]"));
            Assert.That(jp.ToString("J"), Is.EqualTo("{\"x\":1}"));
        }

        [Test]
        public void AddMultiplePropertiesToRoot()
        {
            JsonPatch jp = new("{\"z\":100}"u8.ToArray());

            jp.Set("$.a"u8, 1);
            jp.Set("$.b"u8, 2);
            jp.Set("$.c"u8, 3);

            Assert.That(jp.ToString("J"), Is.EqualTo("{\"z\":100,\"a\":1,\"b\":2,\"c\":3}"));
        }

        [Test]
        public void NullException_Format()
        {
            JsonPatch jp = new();
            var ex = Assert.Throws<ArgumentNullException>(() => jp.ToString(null!));
#if NETFRAMEWORK
            Assert.That(ex!.Message, Is.EqualTo("Value cannot be null.\r\nParameter name: format"));
#else
            Assert.That(ex!.Message, Is.EqualTo("Value cannot be null. (Parameter 'format')"));
#endif
        }

        [Test]
        public void AddStringPropertyToComplexObject()
        {
            JsonPatch jp = new("{\"a\":{\"b\":{\"bProp\":1},\"c\":{\"cProp\":true}}}"u8.ToArray());
            jp.Set("$.a.new"u8, "newValue");
            Assert.That(jp.ToString("J"), Is.EqualTo("{\"a\":{\"b\":{\"bProp\":1},\"c\":{\"cProp\":true},\"new\":\"newValue\"}}"));
        }

        [Test]
        public void AddStringArrayElement()
        {
            JsonPatch jp = new("{\"a\":[\"one\",\"two\",\"three\"]}"u8.ToArray());
            jp.Set("$.a[1]"u8, "newTwo");
            Assert.That(jp.ToString("J"), Is.EqualTo("{\"a\":[\"one\",\"newTwo\",\"three\"]}"));
        }

        [Test]
        public void SetStringWithEscapedCharacters()
        {
            JsonPatch jp = new();

            jp.Set("$.text"u8, "Line1\nLine2\tTabbed\"Quote\"");

            // GetString should return single escape
            Assert.That(jp.GetString("$.text"u8), Is.EqualTo("Line1\nLine2\tTabbed\"Quote\""));
            Assert.That(jp.TryGetValue("$.text"u8, out string? value), Is.True);
            Assert.That(value, Is.EqualTo("Line1\nLine2\tTabbed\"Quote\""));
            Assert.That(value!.Contains("\n"), Is.True);
            Assert.That(value.Contains("\\n"), Is.False);

            // GetJson should return the exact byte array we passed in
            Assert.That(jp.GetJson("$.text"u8).ToArray(), Is.EqualTo("Line1\nLine2\tTabbed\"Quote\""u8.ToArray()).AsCollection);

            // EncodedValue should have the exact byte array we passed in
            Assert.That(jp.TryGetEncodedValue("$.text"u8, out var encodedValue), Is.True);
            Assert.That(encodedValue.Value.ToArray(), Is.EqualTo("Line1\nLine2\tTabbed\"Quote\""u8.ToArray()));

            // ToString will have 2 characters to represent the escaped characters 0x0A (\n), 0x09 (\t), and \u0022 (")
            Assert.That(jp.ToString("J"), Is.EqualTo("{\"text\":\"Line1\\nLine2\\tTabbed\\u0022Quote\\u0022\"}"));
        }

        [Test]
        public void SetJsonWithEscapedCharacters()
        {
            JsonPatch jp = new();

            jp.Set("$.text"u8, "\"Line1\\nLine2\\tTabbed\\\"Quote\\\"\""u8);

            // GetString should return single escape
            Assert.That(jp.GetString("$.text"u8), Is.EqualTo("Line1\nLine2\tTabbed\"Quote\""));
            Assert.That(jp.TryGetValue("$.text"u8, out string? value), Is.True);
            Assert.That(value, Is.EqualTo("Line1\nLine2\tTabbed\"Quote\""));
            Assert.That(value!.Contains("\n"), Is.True);
            Assert.That(value.Contains("\\n"), Is.False);

            // GetJson should return the exact byte array we passed in
            Assert.That(jp.GetJson("$.text"u8).ToArray(), Is.EqualTo("\"Line1\\nLine2\\tTabbed\\\"Quote\\\"\""u8.ToArray()).AsCollection);

            // EncodedValue should have the exact byte array we passed in
            Assert.That(jp.TryGetEncodedValue("$.text"u8, out var encodedValue), Is.True);
            Assert.That(encodedValue.Value.ToArray(), Is.EqualTo("\"Line1\\nLine2\\tTabbed\\\"Quote\\\"\""u8.ToArray()));

            // ToString will have 2 characters to represent the escaped characters 0x0A (\n), 0x09 (\t), and \u0022 (")
            Assert.That(jp.ToString("J"), Is.EqualTo("{\"text\":\"Line1\\nLine2\\tTabbed\\\"Quote\\\"\"}"));
        }

        [Test]
        public void SeedWithEscapedCharacters()
        {
            // Start with a seeded json patch with escaped characters
            JsonPatch jp = new("{\"text\":\"Line1\\nLine2\\tTabbed\\\"Quote\\\"\"}"u8.ToArray());

            // GetString should return single escape
            Assert.That(jp.GetString("$.text"u8), Is.EqualTo("Line1\nLine2\tTabbed\"Quote\""));
            Assert.That(jp.TryGetValue("$.text"u8, out string? value), Is.True);
            Assert.That(value, Is.EqualTo("Line1\nLine2\tTabbed\"Quote\""));
            Assert.That(value!.Contains("\n"), Is.True);
            Assert.That(value.Contains("\\n"), Is.False);

            // GetJson should return the exact byte array we passed in
            Assert.That(jp.GetJson("$.text"u8).ToArray(), Is.EqualTo("\"Line1\\nLine2\\tTabbed\\\"Quote\\\"\""u8.ToArray()).AsCollection);

            // EncodedValue should have the exact byte array we passed in
            Assert.That(jp.TryGetEncodedValue("$.text"u8, out var encodedValue), Is.True);
            Assert.That(encodedValue.Value.ToArray(), Is.EqualTo("\"Line1\\nLine2\\tTabbed\\\"Quote\\\"\""u8.ToArray()));

            // ToString will have 2 characters to represent the escaped characters 0x0A (\n), 0x09 (\t), and \u0022 (")
            Assert.That(jp.ToString("J"), Is.EqualTo("{\"text\":\"Line1\\nLine2\\tTabbed\\\"Quote\\\"\"}"));
        }

        [Test]
        public void NonExistentPathShouldNotThrow()
        {
            JsonPatch patch = new("{\"choices\":[{\"delta\":{\"content\":\"hello\"}}]}"u8.ToArray());

            Assert.DoesNotThrow(() => patch.TryGetValue("$.reasoning"u8, out string? value));
        }

        [Test]
        public void IterateOnArray_RemoveItemMatch()
        {
            var json = """
{
  "output": [
    {
      "id": "rs_01dfc61333fbdf3600692dffc53f4c8196b55eae21c8727d1a",
      "type": "reasoning",
      "summary": []
    },
    {
      "id": "ci_01dfc61333fbdf3600692dfff0a80881968003a7f1010139ba", 
      "type": "code_interpreter_call", 
      "status": "completed", 
      "code": "import numpy as np\r\nimport matplotlib.pyplot as plt\r\n\r\n# Generate data\r\nx = np.linspace(0, 2*np.pi, 1000)\r\ny = np.sin(x)\r\n\r\n# Create plot\r\nplt.figure(figsize=(6, 4))\r\nplt.plot(x, y, label='sin(x)', color='royalblue')\r\nplt.title('Sine Wave (0 to 2\u03c0)')\r\nplt.xlabel('x')\r\nplt.ylabel('sin(x)')\r\nplt.grid(True, alpha=0.3)\r\nplt.legend()\r\n\r\n# Save as PNG\r\noutput_path = '/mnt/data/sine_wave.png'\r\nplt.savefig(output_path, dpi=150, bbox_inches='tight')\r\n\r\n# Show the plot inline\r\nplt.show()\r\n\r\noutput_path", 
      "container_id": "cntr_692dffc4e7708190bcd6e0e7c35b27ce000abd71d9736540", 
      "outputs": [
        {
          "type": "image",
          "url": "data:image/png;base64,iVBORw0KGgoAAAANSUhEUg"
        }
      ]
    },
    {
      "id": "msg_01dfc61333fbdf3600692dfffcbcfc81969f92318d9d3c41ca",
      "type": "message",
      "status": "completed",
      "content": [
        {
          "type": "output_text",
          "annotations": [],
          "logprobs": [],
          "text": "I've generated the sine wave plot and embedded it in the tool outputs as a base64 PNG."
        }
      ],
      "role": "assistant"
    }
  ]
}
""";

            var expected = """
{
  "output": [
    {
      "id": "rs_01dfc61333fbdf3600692dffc53f4c8196b55eae21c8727d1a",
      "type": "reasoning",
      "summary": []
    },
    {
      "id": "ci_01dfc61333fbdf3600692dfff0a80881968003a7f1010139ba", 
      "type": "code_interpreter_call", 
      "status": "completed", 
      "code": "import numpy as np\r\nimport matplotlib.pyplot as plt\r\n\r\n# Generate data\r\nx = np.linspace(0, 2*np.pi, 1000)\r\ny = np.sin(x)\r\n\r\n# Create plot\r\nplt.figure(figsize=(6, 4))\r\nplt.plot(x, y, label='sin(x)', color='royalblue')\r\nplt.title('Sine Wave (0 to 2\u03c0)')\r\nplt.xlabel('x')\r\nplt.ylabel('sin(x)')\r\nplt.grid(True, alpha=0.3)\r\nplt.legend()\r\n\r\n# Save as PNG\r\noutput_path = '/mnt/data/sine_wave.png'\r\nplt.savefig(output_path, dpi=150, bbox_inches='tight')\r\n\r\n# Show the plot inline\r\nplt.show()\r\n\r\noutput_path", 
      "container_id": "cntr_692dffc4e7708190bcd6e0e7c35b27ce000abd71d9736540", 
      "outputs": [
        {
          "type": "image"}
      ]
    },
    {
      "id": "msg_01dfc61333fbdf3600692dfffcbcfc81969f92318d9d3c41ca",
      "type": "message",
      "status": "completed",
      "content": [
        {
          "type": "output_text",
          "annotations": [],
          "logprobs": [],
          "text": "I've generated the sine wave plot and embedded it in the tool outputs as a base64 PNG."
        }
      ],
      "role": "assistant"
    }
  ]
}
""";

            var patch = new JsonPatch(BinaryData.FromString(json));
            var index = 0;
            var imageUrl = "";

            while (patch.TryGetValue(Encoding.UTF8.GetBytes($"$.output[{index}].type"), out string? type))
            {
                if (type == "code_interpreter_call")
                {
                    var path = Encoding.UTF8.GetBytes($"$.output[{index}].outputs[0].url");

                    imageUrl = patch.GetString(path);

                    patch.Remove(path);
                }

                ++index;
            }

            Assert.That(patch.ToString("J"), Is.EqualTo(expected));
        }

        [Test]
        public void IterateOverArrayItems()
        {
            var json = """
{
    "items": [
        { "id": 1, "name": "Item1" },
        { "id": 2, "name": "Item2" },
        { "id": 3, "name": "Item3" }
    ]
}
""";
            var patch = new JsonPatch(BinaryData.FromString(json));
            var index = 0;
            while (patch.TryGetValue(Encoding.UTF8.GetBytes($"$.items[{index}].id"), out int id))
            {
                var namePath = Encoding.UTF8.GetBytes($"$.items[{index}].name");
                Assert.That(patch.GetString(namePath), Is.EqualTo($"Item{id}"));
                ++index;
            }

            Assert.That(index, Is.EqualTo(3));
        }

        [Test]
        public void IterateOverArrayItems_WithModify()
        {
            var json = """
{
    "items": [
        { "id": 1, "name": "Item1" },
        { "id": 2, "name": "Item2" },
        { "id": 3, "name": "Item3" }
    ]
}
""";
            var patch = new JsonPatch(BinaryData.FromString(json));
            patch.Set("$.items[1].name"u8, "UpdatedItem2");
            var index = 0;
            while (patch.TryGetValue(Encoding.UTF8.GetBytes($"$.items[{index}].id"), out int id))
            {
                var namePath = Encoding.UTF8.GetBytes($"$.items[{index}].name");
                if (index == 1)
                {
                    Assert.That(patch.GetString(namePath), Is.EqualTo("UpdatedItem2"));
                }
                else
                {
                    Assert.That(patch.GetString(namePath), Is.EqualTo($"Item{id}"));
                }
                ++index;
            }

            Assert.That(index, Is.EqualTo(3));
        }

        [Test]
        public void IterateOverArrayItems_WithRemoveItemProperty()
        {
            var json = """
{
    "items": [
        { "id": 1, "name": "Item1" },
        { "id": 2, "name": "Item2" },
        { "id": 3, "name": "Item3" }
    ]
}
""";
            var patch = new JsonPatch(BinaryData.FromString(json));
            patch.Remove("$.items[1].id"u8);
            var index = 0;
            while (patch.TryGetJson(Encoding.UTF8.GetBytes($"$.items[{index}]"), out var itemJson))
            {
                var namePath = Encoding.UTF8.GetBytes($"$.items[{index}].name");
                Assert.That(patch.GetString(namePath), Is.EqualTo($"Item{index + 1}"));
                ++index;
            }

            Assert.That(index, Is.EqualTo(3));

            // if we look for id it will stop after 1 item because the 2nd item id was removed
            index = 0;
            while (patch.TryGetValue(Encoding.UTF8.GetBytes($"$.items[{index}].id"), out int id))
            {
                var namePath = Encoding.UTF8.GetBytes($"$.items[{index}].name");
                Assert.That(patch.GetString(namePath), Is.EqualTo($"Item{id}"));
                ++index;
            }

            Assert.That(index, Is.EqualTo(1));

            // if we get by json it will iterate over all 3 since the id property removal can still be returned as empty json
            index = 0;
            while (patch.TryGetJson(Encoding.UTF8.GetBytes($"$.items[{index}].id"), out var idJson))
            {
                var namePath = Encoding.UTF8.GetBytes($"$.items[{index}].name");
                Assert.That(patch.GetString(namePath), Is.EqualTo($"Item{index + 1}"));
                ++index;
            }

            Assert.That(index, Is.EqualTo(3));
        }

        [Test]
        public void IterateOverArrayItems_WithRemoveItem()
        {
            var json = """
{
    "items": [
        { "id": 1, "name": "Item1" },
        { "id": 2, "name": "Item2" },
        { "id": 3, "name": "Item3" }
    ]
}
""";
            var patch = new JsonPatch(BinaryData.FromString(json));
            patch.Remove("$.items[1]"u8);
            var index = 0;
            while (patch.TryGetValue(Encoding.UTF8.GetBytes($"$.items[{index}].id"), out int id))
            {
                var namePath = Encoding.UTF8.GetBytes($"$.items[{index}].name");
                Assert.That(patch.GetString(namePath), Is.EqualTo($"Item{id}"));
                ++index;
            }

            // iteration will stop after 1 item because item 2 was removed and therefore it won't have an id
            Assert.That(index, Is.EqualTo(1));
            Assert.That(patch.GetJson("$.items[2]"u8).ToString(), Is.EqualTo("{ \"id\": 3, \"name\": \"Item3\" }"));
            Assert.That(patch.GetInt32("$.items[2].id"u8), Is.EqualTo(3));
            Assert.That(patch.GetString("$.items[2].name"u8), Is.EqualTo("Item3"));
        }

        [Test]
        public void IterateOverArrayItems_WithAppend()
        {
            var json = """
{
    "items": [
        { "id": 1, "name": "Item1" },
        { "id": 2, "name": "Item2" },
        { "id": 3, "name": "Item3" }
    ]
}
""";
            var patch = new JsonPatch(BinaryData.FromString(json));
            patch.Append("$.items"u8, "{\"id\":4,\"name\":\"Item4\"}"u8);
            var index = 0;
            while (patch.TryGetValue(Encoding.UTF8.GetBytes($"$.items[{index}].id"), out int id))
            {
                var namePath = Encoding.UTF8.GetBytes($"$.items[{index}].name");
                Assert.That(patch.GetString(namePath), Is.EqualTo($"Item{id}"));
                ++index;
            }

            Assert.That(index, Is.EqualTo(4));
        }
    }
}
