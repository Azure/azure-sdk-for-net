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

            Assert.IsTrue(jp.Contains("$.property"u8));
            Assert.AreEqual("value", jp.GetString("$.property"u8));
            Assert.AreEqual(10, jp.GetInt32("$.property2"u8));

            Assert.AreEqual("{\"property\":\"value\",\"property2\":10}", jp.ToString("J"));
        }

        [Test]
        public void AddRootArray_String()
        {
            JsonPatch jp = new();

            jp.Append("$"u8, "value");

            Assert.AreEqual("[\"value\"]", jp.GetJson("$"u8).ToString());
            Assert.AreEqual("value", jp.GetString("$[0]"u8));

            Assert.AreEqual("[\"value\"]", jp.ToString("J"));
        }

        [Test]
        public void AddRootArray_Property_String()
        {
            JsonPatch jp = new();

            jp.Set("$[0].property"u8, "value");

            Assert.AreEqual("[{\"property\":\"value\"}]", jp.GetJson("$"u8).ToString());
            Assert.AreEqual("{\"property\":\"value\"}", jp.GetJson("$[0]"u8).ToString());
            Assert.AreEqual("value", jp.GetString("$[0].property"u8));

            Assert.AreEqual("[{\"property\":\"value\"}]", jp.ToString("J"));
        }

        [Test]
        public void TryGetJson_RemovedProperty_EntryExists()
        {
            JsonPatch jp = new();

            jp.Set("$[0].property1"u8, "value1");
            jp.Set("$[0].property2"u8, "value2");

            Assert.AreEqual("[{\"property1\":\"value1\",\"property2\":\"value2\"}]", jp.GetJson("$"u8).ToString());
            Assert.AreEqual("{\"property1\":\"value1\",\"property2\":\"value2\"}", jp.GetJson("$[0]"u8).ToString());
            Assert.AreEqual("value1", jp.GetString("$[0].property1"u8));
            Assert.AreEqual("value2", jp.GetString("$[0].property2"u8));

            Assert.AreEqual("[{\"property1\":\"value1\",\"property2\":\"value2\"}]", jp.ToString("J"));

            jp.Remove("$[0].property1"u8);

            Assert.AreEqual("[{\"property2\":\"value2\"}]", jp.GetJson("$"u8).ToString());
            Assert.AreEqual("{\"property2\":\"value2\"}", jp.GetJson("$[0]"u8).ToString());
            var ex = Assert.Throws<InvalidOperationException>(() => jp.GetString("$[0].property1"u8));
            Assert.AreEqual("$[0].property1 was not found in the JSON structure.", ex!.Message);
            Assert.AreEqual("value2", jp.GetString("$[0].property2"u8));

            Assert.AreEqual("[{\"property2\":\"value2\"}]", jp.ToString("J"));
        }

        [Test]
        public void TryGetJson_RemovedProperty_EntryDoesNotExist()
        {
            JsonPatch jp = new();
            jp.Set("$[0].property1"u8, "value1");
            jp.Set("$[0].property2"u8, "value2");

            Assert.AreEqual("[{\"property1\":\"value1\",\"property2\":\"value2\"}]", jp.GetJson("$"u8).ToString());
            Assert.AreEqual("{\"property1\":\"value1\",\"property2\":\"value2\"}", jp.GetJson("$[0]"u8).ToString());
            Assert.AreEqual("value1", jp.GetString("$[0].property1"u8));
            Assert.AreEqual("value2", jp.GetString("$[0].property2"u8));

            Assert.AreEqual("[{\"property1\":\"value1\",\"property2\":\"value2\"}]", jp.ToString("J"));

            var ex = Assert.Throws<InvalidOperationException>(() => jp.Remove("$[0].property3"u8));
            Assert.AreEqual("$[0].property3 was not found in the JSON structure.", ex!.Message);
        }

        [Test]
        public void ProjectMultipleJsons()
        {
            JsonPatch jp = new();
            jp.Set("$.x.y[2]['z']"u8, 5);

            Assert.AreEqual("{\"y\":[null,null,{\"z\":5}]}", jp.GetJson("$.x"u8).ToString());
            Assert.AreEqual("[null,null,{\"z\":5}]", jp.GetJson("$.x.y"u8).ToString());
            Assert.AreEqual("null", jp.GetJson("$.x.y[0]"u8).ToString());
            Assert.AreEqual("null", jp.GetJson("$.x.y[1]"u8).ToString());
            Assert.AreEqual("{\"z\":5}", jp.GetJson("$.x.y[2]"u8).ToString());
            Assert.AreEqual(5, jp.GetInt32("$.x.y[2]['z']"u8));

            Assert.AreEqual("{\"x\":{\"y\":[null,null,{\"z\":5}]}}", jp.ToString("J"));

            jp.Set("$.x.z.a[0].b"u8, 10);

            Assert.AreEqual("{\"y\":[null,null,{\"z\":5}],\"z\":{\"a\":[{\"b\":10}]}}", jp.GetJson("$.x"u8).ToString());
            Assert.AreEqual("[null,null,{\"z\":5}]", jp.GetJson("$.x.y"u8).ToString());
            Assert.AreEqual("null", jp.GetJson("$.x.y[0]"u8).ToString());
            Assert.AreEqual("null", jp.GetJson("$.x.y[1]"u8).ToString());
            Assert.AreEqual("{\"z\":5}", jp.GetJson("$.x.y[2]"u8).ToString());
            Assert.AreEqual(5, jp.GetInt32("$.x.y[2]['z']"u8));
            Assert.AreEqual("{\"a\":[{\"b\":10}]}", jp.GetJson("$.x.z"u8).ToString());
            Assert.AreEqual("[{\"b\":10}]", jp.GetJson("$.x.z.a"u8).ToString());
            Assert.AreEqual("{\"b\":10}", jp.GetJson("$.x.z.a[0]"u8).ToString());
            Assert.AreEqual(10, jp.GetInt32("$.x.z.a[0].b"u8));

            Assert.AreEqual("{\"x\":{\"y\":[null,null,{\"z\":5}],\"z\":{\"a\":[{\"b\":10}]}}}", jp.ToString("J"));
        }

        [Test]
        public void AddPropertyNameWithDot()
        {
            JsonPatch jp = new();
            jp.Set("$['pro.perty']"u8, "value");
            Assert.IsTrue(jp.Contains("$['pro.perty']"u8));
            Assert.AreEqual("value", jp.GetString("$['pro.perty']"u8));

            Assert.AreEqual("{\"pro.perty\":\"value\"}", jp.ToString("J"));
        }

        [Test]
        public void Contains_ArrayAppend_DoesNotReportArrayPath()
        {
            JsonPatch jp = new();
            jp.Append("$.items"u8, "value1");
            Assert.IsFalse(jp.Contains("$.items"u8), "Append should not cause Contains(path) to report true for the array container path.");

            Assert.AreEqual("value1", jp.GetString("$.items[0]"u8));
        }

        [Test]
        public void Contains_PrefixProperty_ReportsProperty()
        {
            JsonPatch jp = new("{\"parent\":{\"child\":1}}"u8.ToArray());
            jp.Set("$.parent.child"u8, 10);

            Assert.IsTrue(jp.Contains("$.parent.child"u8));
            Assert.IsTrue(jp.Contains("$.parent"u8, "child"u8));

            Assert.IsFalse(jp.Contains("$.parent"u8, "missing"u8));
            Assert.IsFalse(jp.Contains("$.parent.child"u8, "grand"u8));
        }

        [Test]
        public void Contains_PrefixProperty_ArrayAppendPotentialInconsistency()
        {
            JsonPatch jp = new();
            jp.Append("$.arr"u8, 5);

            Assert.IsFalse(jp.Contains("$.arr"u8), "Array container path should not be considered 'contained' after only an append.");

            Assert.IsTrue(jp.Contains("$"u8, "arr"u8), "Prefix/property Contains currently ignores ArrayItemAppend and reports true.");
        }

        [Test]
        public void IsRemoved_Behavior()
        {
            JsonPatch jp = new("{\"obj\":{\"a\":0,\"b\":1}}"u8.ToArray());

            jp.Set("$.obj.a"u8, 1);
            jp.Set("$.obj.b"u8, 2);

            Assert.IsFalse(jp.IsRemoved("$.obj.a"u8));
            Assert.IsFalse(jp.IsRemoved("$.obj.b"u8));

            jp.Remove("$.obj.a"u8);

            Assert.IsTrue(jp.IsRemoved("$.obj.a"u8));
            Assert.IsFalse(jp.IsRemoved("$.obj.b"u8));

            var ex = Assert.Throws<KeyNotFoundException>(() => jp.GetInt32("$.obj.a"u8));
            Assert.AreEqual("No value found at JSON path '$.obj.a'.", ex!.Message);
        }

        [Test]
        public void RemoveThenResetValue()
        {
            JsonPatch jp = new();
            jp.Set("$.p"u8, 5);
            jp.Remove("$.p"u8);
            jp.Set("$.p"u8, 10);
            Assert.IsFalse(jp.IsRemoved("$.p"u8));
            Assert.AreEqual(10, jp.GetInt32("$.p"u8));
        }

        [Test]
        public void UnsupportedNullableType_Throws()
        {
            JsonPatch jp = new();
            jp.Set("$.c"u8, 1); // store as int
            var ex = Assert.Throws<NotSupportedException>(() => jp.GetNullableValue<char>("$.c"u8));
            Assert.AreEqual("Type 'System.Char' is not supported by GetNullableValue.", ex!.Message);
        }

        [Test]
        public void ToString_InvalidFormat_Throws()
        {
            JsonPatch jp = new();
            jp.Set("$.x"u8, 1);
            var ex = Assert.Throws<NotSupportedException>(() => jp.ToString("INVALID"));
            Assert.AreEqual("The format 'INVALID' is not supported.", ex!.Message);
        }

        [Test]
        public void Overwrite_Property_WithDifferentTypes()
        {
            JsonPatch jp = new();
            jp.Set("$.v"u8, 10);
            Assert.AreEqual(10, jp.GetInt32("$.v"u8));
            jp.Set("$.v"u8, "str");
            Assert.AreEqual("str", jp.GetString("$.v"u8));
        }

        [Test]
        public void TryGetValue_Removed_ReturnsFalse()
        {
            JsonPatch jp = new();
            jp.Set("$.x"u8, 5);
            Assert.IsTrue(jp.TryGetValue("$.x"u8, out int v) && v == 5);
            jp.Remove("$.x"u8);
            Assert.IsFalse(jp.TryGetValue("$.x"u8, out int _));
        }

        [Test]
        public void TryGetNullableValue_UnsupportedType_ReturnsFalse()
        {
            JsonPatch jp = new();
            jp.Set("$.a"u8, 1);
            bool found = jp.TryGetNullableValue("$.a"u8, out char? c);
            Assert.IsFalse(found);
            Assert.False(c.HasValue);
        }

        [Test]
        public void Append_ToExistingArrayThenSetConcreteIndex()
        {
            JsonPatch jp = new();
            jp.Append("$.arr"u8, 1);
            jp.Append("$.arr"u8, 2);
            Assert.IsFalse(jp.Contains("$.arr"u8));
            jp.Set("$.arr[0]"u8, 10);
            Assert.AreEqual(10, jp.GetInt32("$.arr[0]"u8));
            Assert.AreEqual(2, jp.GetInt32("$.arr[1]"u8));
        }

        [Test]
        public void TryGetJson_OnNullValue()
        {
            JsonPatch jp = new();
            jp.SetNull("$.n"u8);
            Assert.IsTrue(jp.TryGetJson("$.n"u8, out var mem));
            Assert.AreEqual("null", Encoding.UTF8.GetString(mem.Span.ToArray()));
        }

        [Test]
        public void Set_DeepNestedArrayAndProperties()
        {
            JsonPatch jp = new();

            jp.Set("$.a.b[3].c.d[2].e"u8, 1);

            Assert.AreEqual("{\"b\":[null,null,null,{\"c\":{\"d\":[null,null,{\"e\":1}]}}]}", jp.GetJson("$.a"u8).ToString());
            Assert.AreEqual("[null,null,null,{\"c\":{\"d\":[null,null,{\"e\":1}]}}]", jp.GetJson("$.a.b"u8).ToString());
            Assert.AreEqual("null", jp.GetJson("$.a.b[0]"u8).ToString());
            Assert.AreEqual("null", jp.GetJson("$.a.b[1]"u8).ToString());
            Assert.AreEqual("null", jp.GetJson("$.a.b[2]"u8).ToString());
            Assert.AreEqual("{\"c\":{\"d\":[null,null,{\"e\":1}]}}", jp.GetJson("$.a.b[3]"u8).ToString());
            Assert.AreEqual("{\"d\":[null,null,{\"e\":1}]}", jp.GetJson("$.a.b[3].c"u8).ToString());
            Assert.AreEqual("[null,null,{\"e\":1}]", jp.GetJson("$.a.b[3].c.d"u8).ToString());
            Assert.AreEqual("null", jp.GetJson("$.a.b[3].c.d[0]"u8).ToString());
            Assert.AreEqual("null", jp.GetJson("$.a.b[3].c.d[1]"u8).ToString());
            Assert.AreEqual("{\"e\":1}", jp.GetJson("$.a.b[3].c.d[2]"u8).ToString());
            Assert.AreEqual(1, jp.GetInt32("$.a.b[3].c.d[2].e"u8));

            Assert.AreEqual("{\"a\":{\"b\":[null,null,null,{\"c\":{\"d\":[null,null,{\"e\":1}]}}]}}", jp.ToString("J"));
        }

        [Test]
        public void Append_ArrayItemPath_AppendsArrayInsideArrayIndex()
        {
            JsonPatch jp = new();

            jp.Append("$.a[3]"u8, 5);

            Assert.AreEqual("[null,null,null,[5]]", jp.GetJson("$.a"u8).ToString());
            Assert.AreEqual("null", jp.GetJson("$.a[0]"u8).ToString());
            Assert.AreEqual("null", jp.GetJson("$.a[1]"u8).ToString());
            Assert.AreEqual("null", jp.GetJson("$.a[2]"u8).ToString());
            Assert.AreEqual("[5]", jp.GetJson("$.a[3]"u8).ToString());
            Assert.AreEqual(5, jp.GetInt32("$.a[3][0]"u8));

            Assert.AreEqual("{\"a\":[null,null,null,[5]]}", jp.ToString("J"));
        }

        [Test]
        public void Append_PropertyLeaf_AppendsArrayAtProperty()
        {
            JsonPatch jp = new();

            jp.Append("$.a"u8, 5);

            Assert.AreEqual("[5]", jp.GetJson("$.a"u8).ToString());
            Assert.AreEqual(5, jp.GetInt32("$.a[0]"u8));

            Assert.AreEqual("{\"a\":[5]}", jp.ToString("J"));
        }

        [Test]
        public void Append_PropertyLeaf_NestedAfterArrayIndex()
        {
            JsonPatch jp = new();

            jp.Append("$.arr[2].items"u8, "x");

            Assert.AreEqual("[null,null,{\"items\":[\"x\"]}]", jp.GetJson("$.arr"u8).ToString());
            Assert.AreEqual("null", jp.GetJson("$.arr[0]"u8).ToString());
            Assert.AreEqual("null", jp.GetJson("$.arr[1]"u8).ToString());
            Assert.AreEqual("{\"items\":[\"x\"]}", jp.GetJson("$.arr[2]"u8).ToString());
            Assert.AreEqual("[\"x\"]", jp.GetJson("$.arr[2].items"u8).ToString());
            Assert.AreEqual("x", jp.GetString("$.arr[2].items[0]"u8));

            Assert.AreEqual("{\"arr\":[null,null,{\"items\":[\"x\"]}]}", jp.ToString("J"));
        }

        [Test]
        public void Branch_ArrayIndex_Final_Append()
        {
            JsonPatch jp = new();

            jp.Append("$.arr[2]"u8, 10);

            Assert.AreEqual("[null,null,[10]]", jp.GetJson("$.arr"u8).ToString());

            Assert.AreEqual("{\"arr\":[null,null,[10]]}", jp.ToString("J"));
        }

        [Test]
        public void Branch_ArrayIndex_Final_Set()
        {
            JsonPatch jp = new();

            jp.Set("$.arr[3]"u8, 11);

            Assert.AreEqual("[null,null,null,11]", jp.GetJson("$.arr"u8).ToString());

            Assert.AreEqual("{\"arr\":[null,null,null,11]}", jp.ToString("J"));
        }

        [Test]
        public void Branch_PropertySeparator_Final()
        {
            JsonPatch jp = new();
            var ex = Assert.Throws<InvalidOperationException>(() => jp.Set("$.trailing."u8, 5));
            StringAssert.Contains("property", ex!.Message.ToLowerInvariant());
        }

        [Test]
        public void Branch_DirectRoot_Final()
        {
            JsonPatch jp = new();

            jp.Set("$"u8, "{\"x\":1}"u8);

            Assert.AreEqual("{\"x\":1}", jp.GetJson("$"u8).ToString());

            Assert.AreEqual("{\"x\":1}", jp.ToString("J"));
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
            Assert.AreEqual("{\"a\":{}}", reader.ToBinaryData().ToString());
        }

        [Test]
        public void SerializeEmptyPatch()
        {
            JsonPatch jp = new();

            Assert.AreEqual("[]", jp.ToString());
            Assert.AreEqual("{}", jp.ToString("J"));
        }

        [Test]
        public void SetEmptyJson()
        {
            JsonPatch jp = new();

            jp.Set("$.a"u8, ""u8);

            var ex = Assert.Throws<ArgumentException>(() => jp.ToString("J"));
            Assert.AreEqual("Empty encoded value", ex!.Message);
        }

        [Test]
        public void SerializeSeededEmptyPatch()
        {
            JsonPatch jp = new("{\"x\":1}"u8.ToArray());

            Assert.AreEqual("[]", jp.ToString());
            Assert.AreEqual("{\"x\":1}", jp.ToString("J"));
        }

        [Test]
        public void AddMultiplePropertiesToRoot()
        {
            JsonPatch jp = new("{\"z\":100}"u8.ToArray());

            jp.Set("$.a"u8, 1);
            jp.Set("$.b"u8, 2);
            jp.Set("$.c"u8, 3);

            Assert.AreEqual("{\"z\":100,\"a\":1,\"b\":2,\"c\":3}", jp.ToString("J"));
        }

        [Test]
        public void NullException_Format()
        {
            JsonPatch jp = new();
            var ex = Assert.Throws<ArgumentNullException>(() => jp.ToString(null!));
#if NETFRAMEWORK
            Assert.AreEqual("Value cannot be null.\r\nParameter name: format", ex!.Message);
#else
            Assert.AreEqual("Value cannot be null. (Parameter 'format')", ex!.Message);
#endif
        }

        [Test]
        public void AddStringPropertyToComplexObject()
        {
            JsonPatch jp = new("{\"a\":{\"b\":{\"bProp\":1},\"c\":{\"cProp\":true}}}"u8.ToArray());
            jp.Set("$.a.new"u8, "newValue");
            Assert.AreEqual("{\"a\":{\"b\":{\"bProp\":1},\"c\":{\"cProp\":true},\"new\":\"newValue\"}}", jp.ToString("J"));
        }

        [Test]
        public void AddStringArrayElement()
        {
            JsonPatch jp = new("{\"a\":[\"one\",\"two\",\"three\"]}"u8.ToArray());
            jp.Set("$.a[1]"u8, "newTwo");
            Assert.AreEqual("{\"a\":[\"one\",\"newTwo\",\"three\"]}", jp.ToString("J"));
        }
    }
}
