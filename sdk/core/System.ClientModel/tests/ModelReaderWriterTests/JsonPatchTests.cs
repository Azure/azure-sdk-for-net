// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;
using System.IO;
using System.Text;
using System.Text.Json;
using NUnit.Framework;

namespace System.ClientModel.Tests.ModelReaderWriterTests
{
    internal class JsonPatchTests
    {
        [Test]
        public void AddPrimitive_String()
        {
            JsonPatch jp = new();

            jp.Set("$.property"u8, "value");

            Assert.IsTrue(jp.Contains("$.property"u8));
            Assert.AreEqual("value", jp.GetString("$.property"u8));

            Assert.AreEqual("{\"property\":\"value\"}", GetJsonString(jp));
        }

        [Test]
        public void AddPrimitive_StringAndInt()
        {
            JsonPatch jp = new();

            jp.Set("$.property"u8, "value");
            jp.Set("$.property2"u8, 10);

            Assert.IsTrue(jp.Contains("$.property"u8));
            Assert.AreEqual("value", jp.GetString("$.property"u8));
            Assert.AreEqual(10, jp.GetInt32("$.property2"u8));

            Assert.AreEqual("{\"property\":\"value\",\"property2\":10}", GetJsonString(jp));
        }

        [Test]
        public void AddRootArray_String()
        {
            JsonPatch jp = new();

            jp.Append("$"u8, "value");

            Assert.AreEqual("[\"value\"]", jp.GetJson("$"u8).ToString());
            Assert.AreEqual("value", jp.GetString("$[0]"u8));

            Assert.AreEqual("[\"value\"]", GetJsonString(jp));
        }

        [Test]
        public void AddRootArray_Property_String()
        {
            JsonPatch jp = new();

            jp.Set("$[0].property"u8, "value");

            Assert.AreEqual("[{\"property\":\"value\"}]", jp.GetJson("$"u8).ToString());
            Assert.AreEqual("{\"property\":\"value\"}", jp.GetJson("$[0]"u8).ToString());
            Assert.AreEqual("value", jp.GetString("$[0].property"u8));

            Assert.AreEqual("[{\"property\":\"value\"}]", GetJsonString(jp));
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

            Assert.AreEqual("[{\"property1\":\"value1\",\"property2\":\"value2\"}]", GetJsonString(jp));

            jp.Remove("$[0].property1"u8);

            Assert.AreEqual("[{\"property2\":\"value2\"}]", jp.GetJson("$"u8).ToString());
            Assert.AreEqual("{\"property2\":\"value2\"}", jp.GetJson("$[0]"u8).ToString());
            var ex = Assert.Throws<Exception>(() => jp.GetString("$[0].property1"u8));
            Assert.AreEqual("$.property1 was not found in the JSON structure.", ex!.Message);
            Assert.AreEqual("value2", jp.GetString("$[0].property2"u8));

            Assert.AreEqual("[{\"property2\":\"value2\"}]", GetJsonString(jp));
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

            Assert.AreEqual("[{\"property1\":\"value1\",\"property2\":\"value2\"}]", GetJsonString(jp));

            var ex = Assert.Throws<Exception>(() => jp.Remove("$[0].property3"u8));
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

            Assert.AreEqual("{\"x\":{\"y\":[null,null,{\"z\":5}]}}", GetJsonString(jp));

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

            Assert.AreEqual("{\"x\":{\"y\":[null,null,{\"z\":5}],\"z\":{\"a\":[{\"b\":10}]}}}", GetJsonString(jp));
        }

        [Test]
        public void AddPropertyNameWithDot()
        {
            JsonPatch jp = new();
            jp.Set("$['pro.perty']"u8, "value");
            Assert.IsTrue(jp.Contains("$['pro.perty']"u8));
            Assert.AreEqual("value", jp.GetString("$['pro.perty']"u8));

            Assert.AreEqual("{\"pro.perty\":\"value\"}", GetJsonString(jp));
        }

        [Test]
        public void ArrayIndex_Root()
        {
            // insert only
            // insert + root
            // array dimensions
            // $[][]
            // $[][].a
            // $.x[][]
            // $.x[][].a
            // $.x.y[][]
            // $.x.y[][].a
            // $.x.y[][][].z.a[][]
            // $.x.y[][][].z.a[][].b
        }

        [Test]
        [Ignore("wip")]
        public void ArrayIndex_RootAndInsert_TwoDimension()
        {
            JsonPatch jp = new("[[\"value1\",\"value2\"],[\"value3\",\"value4\"]]"u8.ToArray());

            Assert.AreEqual("[\"value1\",\"value2\"]", jp.GetJson("$[0]"u8).ToString());
            Assert.AreEqual("value1", jp.GetString("$[0][0]"u8));
            Assert.AreEqual("value2", jp.GetString("$[0][1]"u8));
            Assert.AreEqual("[\"value3\",\"value4\"]", jp.GetJson("$[1]"u8).ToString());
            Assert.AreEqual("value3", jp.GetString("$[1][0]"u8));
            Assert.AreEqual("value4", jp.GetString("$[1][1]"u8));

            jp.Append("$[0]"u8, "value5");

            Assert.AreEqual("[[\"value1\",\"value2\",\"value5\"],[\"value3\",\"value4\"]]", jp.GetJson("$"u8).ToString());
            Assert.AreEqual("[\"value1\",\"value2\",\"value5\"]", jp.GetJson("$[0]"u8).ToString());
            Assert.AreEqual("value1", jp.GetString("$[0][0]"u8));
            Assert.AreEqual("value2", jp.GetString("$[0][1]"u8));
            Assert.AreEqual("value5", jp.GetString("$[0][2]"u8));
            Assert.AreEqual("[\"value3\",\"value4\"]", jp.GetJson("$[1]"u8).ToString());
            Assert.AreEqual("value3", jp.GetString("$[1][0]"u8));
            Assert.AreEqual("value4", jp.GetString("$[1][1]"u8));

            jp.Append("$[0]"u8, "value6");

            Assert.AreEqual("[[\"value1\",\"value2\",\"value5\",\"value6\"],[\"value3\",\"value4\"]]", jp.GetJson("$"u8).ToString());
            Assert.AreEqual("[\"value1\",\"value2\",\"value5\",\"value6\"]", jp.GetJson("$[0]"u8).ToString());
            Assert.AreEqual("value1", jp.GetString("$[0][0]"u8));
            Assert.AreEqual("value2", jp.GetString("$[0][1]"u8));
            Assert.AreEqual("value5", jp.GetString("$[0][2]"u8));
            Assert.AreEqual("value6", jp.GetString("$[0][3]"u8));
            Assert.AreEqual("[\"value3\",\"value4\"]", jp.GetJson("$[1]"u8).ToString());
            Assert.AreEqual("value3", jp.GetString("$[1][0]"u8));
            Assert.AreEqual("value4", jp.GetString("$[1][1]"u8));

            jp.Append("$[1]"u8, "value7");

            Assert.AreEqual("[[\"value1\",\"value2\",\"value5\",\"value6\"],[\"value3\",\"value4\",\"value7\"]]", jp.GetJson("$"u8).ToString());
            Assert.AreEqual("[\"value1\",\"value2\",\"value5\",\"value6\"]", jp.GetJson("$[0]"u8).ToString());
            Assert.AreEqual("value1", jp.GetString("$[0][0]"u8));
            Assert.AreEqual("value2", jp.GetString("$[0][1]"u8));
            Assert.AreEqual("value5", jp.GetString("$[0][2]"u8));
            Assert.AreEqual("value6", jp.GetString("$[0][3]"u8));
            Assert.AreEqual("[\"value3\",\"value4\",\"value7\"]", jp.GetJson("$[1]"u8).ToString());
            Assert.AreEqual("value3", jp.GetString("$[1][0]"u8));
            Assert.AreEqual("value4", jp.GetString("$[1][1]"u8));
            Assert.AreEqual("value7", jp.GetString("$[1][2]"u8));

            jp.Append("$[1]"u8, "value8");

            Assert.AreEqual("[[\"value1\",\"value2\",\"value5\",\"value6\"],[\"value3\",\"value4\",\"value7\",\"value8\"]]", jp.GetJson("$"u8).ToString());
            Assert.AreEqual("[\"value1\",\"value2\",\"value5\",\"value6\"]", jp.GetJson("$[0]"u8).ToString());
            Assert.AreEqual("value1", jp.GetString("$[0][0]"u8));
            Assert.AreEqual("value2", jp.GetString("$[0][1]"u8));
            Assert.AreEqual("value5", jp.GetString("$[0][2]"u8));
            Assert.AreEqual("value6", jp.GetString("$[0][3]"u8));
            Assert.AreEqual("[\"value3\",\"value4\",\"value7\",\"value8\"]", jp.GetJson("$[1]"u8).ToString());
            Assert.AreEqual("value3", jp.GetString("$[1][0]"u8));
            Assert.AreEqual("value4", jp.GetString("$[1][1]"u8));
            Assert.AreEqual("value7", jp.GetString("$[1][2]"u8));
            Assert.AreEqual("value8", jp.GetString("$[1][3]"u8));

            jp.Append("$"u8, "[\"value9\"]"u8);

            Assert.AreEqual("[[\"value1\",\"value2\",\"value5\",\"value6\"],[\"value3\",\"value4\",\"value7\",\"value8\"],[\"value9\"]]", jp.GetJson("$"u8).ToString());
            Assert.AreEqual("[\"value1\",\"value2\",\"value5\",\"value6\"]", jp.GetJson("$[0]"u8).ToString());
            Assert.AreEqual("value1", jp.GetString("$[0][0]"u8));
            Assert.AreEqual("value2", jp.GetString("$[0][1]"u8));
            Assert.AreEqual("value5", jp.GetString("$[0][2]"u8));
            Assert.AreEqual("value6", jp.GetString("$[0][3]"u8));
            Assert.AreEqual("[\"value3\",\"value4\",\"value7\",\"value8\"]", jp.GetJson("$[1]"u8).ToString());
            Assert.AreEqual("value3", jp.GetString("$[1][0]"u8));
            Assert.AreEqual("value4", jp.GetString("$[1][1]"u8));
            Assert.AreEqual("value7", jp.GetString("$[1][2]"u8));
            Assert.AreEqual("value8", jp.GetString("$[1][3]"u8));
            Assert.AreEqual("[\"value9\"]", jp.GetJson("$[2]"u8).ToString());
            Assert.AreEqual("value9", jp.GetString("$[2][0]"u8));

            Assert.AreEqual("[[\"value1\",\"value2\",\"value5\",\"value6\"],[\"value3\",\"value4\",\"value7\",\"value8\"],[\"value9\"]]", GetJsonString(jp));
        }

        [Test]
        public void ArrayIndex_Insert_TwoDimension_WithProperty()
        {
            JsonPatch jp = new();

            jp.Append("$[0]"u8, "{\"a\":\"value1\"}"u8);

            Assert.AreEqual("[[{\"a\":\"value1\"}]]", jp.GetJson("$"u8).ToString());
            Assert.AreEqual("[{\"a\":\"value1\"}]", jp.GetJson("$[0]"u8).ToString());
            Assert.AreEqual("{\"a\":\"value1\"}", jp.GetJson("$[0][0]"u8).ToString());
            Assert.AreEqual("value1", jp.GetString("$[0][0].a"u8));

            jp.Append("$[0]"u8, "{\"a\":\"value2\"}"u8);

            Assert.AreEqual("[[{\"a\":\"value1\"},{\"a\":\"value2\"}]]", jp.GetJson("$"u8).ToString());
            Assert.AreEqual("[{\"a\":\"value1\"},{\"a\":\"value2\"}]", jp.GetJson("$[0]"u8).ToString());
            Assert.AreEqual("{\"a\":\"value1\"}", jp.GetJson("$[0][0]"u8).ToString());
            Assert.AreEqual("value1", jp.GetString("$[0][0].a"u8));
            Assert.AreEqual("{\"a\":\"value2\"}", jp.GetJson("$[0][1]"u8).ToString());
            Assert.AreEqual("value2", jp.GetString("$[0][1].a"u8));

            jp.Append("$[1]"u8, "{\"a\":\"value3\"}"u8);

            Assert.AreEqual("[[{\"a\":\"value1\"},{\"a\":\"value2\"}],[{\"a\":\"value3\"}]]", jp.GetJson("$"u8).ToString());
            Assert.AreEqual("[{\"a\":\"value1\"},{\"a\":\"value2\"}]", jp.GetJson("$[0]"u8).ToString());
            Assert.AreEqual("{\"a\":\"value1\"}", jp.GetJson("$[0][0]"u8).ToString());
            Assert.AreEqual("value1", jp.GetString("$[0][0].a"u8));
            Assert.AreEqual("{\"a\":\"value2\"}", jp.GetJson("$[0][1]"u8).ToString());
            Assert.AreEqual("value2", jp.GetString("$[0][1].a"u8));
            Assert.AreEqual("[{\"a\":\"value3\"}]", jp.GetJson("$[1]"u8).ToString());
            Assert.AreEqual("{\"a\":\"value3\"}", jp.GetJson("$[1][0]"u8).ToString());
            Assert.AreEqual("value3", jp.GetString("$[1][0].a"u8));

            jp.Append("$[1]"u8, "{\"a\":\"value4\"}"u8);

            Assert.AreEqual("[[{\"a\":\"value1\"},{\"a\":\"value2\"}],[{\"a\":\"value3\"},{\"a\":\"value4\"}]]", jp.GetJson("$"u8).ToString());
            Assert.AreEqual("[{\"a\":\"value1\"},{\"a\":\"value2\"}]", jp.GetJson("$[0]"u8).ToString());
            Assert.AreEqual("{\"a\":\"value1\"}", jp.GetJson("$[0][0]"u8).ToString());
            Assert.AreEqual("value1", jp.GetString("$[0][0].a"u8));
            Assert.AreEqual("{\"a\":\"value2\"}", jp.GetJson("$[0][1]"u8).ToString());
            Assert.AreEqual("value2", jp.GetString("$[0][1].a"u8));
            Assert.AreEqual("[{\"a\":\"value3\"},{\"a\":\"value4\"}]", jp.GetJson("$[1]"u8).ToString());
            Assert.AreEqual("{\"a\":\"value3\"}", jp.GetJson("$[1][0]"u8).ToString());
            Assert.AreEqual("value3", jp.GetString("$[1][0].a"u8));
            Assert.AreEqual("{\"a\":\"value4\"}", jp.GetJson("$[1][1]"u8).ToString());
            Assert.AreEqual("value4", jp.GetString("$[1][1].a"u8));

            jp.Append("$"u8, "[{\"a\":\"value5\"}]"u8);

            Assert.AreEqual("[[{\"a\":\"value1\"},{\"a\":\"value2\"}],[{\"a\":\"value3\"},{\"a\":\"value4\"}],[{\"a\":\"value5\"}]]", jp.GetJson("$"u8).ToString());
            Assert.AreEqual("[{\"a\":\"value1\"},{\"a\":\"value2\"}]", jp.GetJson("$[0]"u8).ToString());
            Assert.AreEqual("{\"a\":\"value1\"}", jp.GetJson("$[0][0]"u8).ToString());
            Assert.AreEqual("value1", jp.GetString("$[0][0].a"u8));
            Assert.AreEqual("{\"a\":\"value2\"}", jp.GetJson("$[0][1]"u8).ToString());
            Assert.AreEqual("value2", jp.GetString("$[0][1].a"u8));
            Assert.AreEqual("[{\"a\":\"value3\"},{\"a\":\"value4\"}]", jp.GetJson("$[1]"u8).ToString());
            Assert.AreEqual("{\"a\":\"value3\"}", jp.GetJson("$[1][0]"u8).ToString());
            Assert.AreEqual("value3", jp.GetString("$[1][0].a"u8));
            Assert.AreEqual("{\"a\":\"value4\"}", jp.GetJson("$[1][1]"u8).ToString());
            Assert.AreEqual("value4", jp.GetString("$[1][1].a"u8));
            Assert.AreEqual("[{\"a\":\"value5\"}]", jp.GetJson("$[2]"u8).ToString());
            Assert.AreEqual("{\"a\":\"value5\"}", jp.GetJson("$[2][0]"u8).ToString());
            Assert.AreEqual("value5", jp.GetString("$[2][0].a"u8));

            Assert.AreEqual("[[{\"a\":\"value1\"},{\"a\":\"value2\"}],[{\"a\":\"value3\"},{\"a\":\"value4\"}],[{\"a\":\"value5\"}]]", GetJsonString(jp));
        }

        [Test]
        public void ArrayIndex_Insert_TwoDimension()
        {
            JsonPatch jp = new();

            jp.Append("$[0]"u8, "value1");

            Assert.AreEqual("[[\"value1\"]]", jp.GetJson("$"u8).ToString());
            Assert.AreEqual("[\"value1\"]", jp.GetJson("$[0]"u8).ToString());
            Assert.AreEqual("value1", jp.GetString("$[0][0]"u8));

            jp.Append("$[0]"u8, "value2");

            Assert.AreEqual("[[\"value1\",\"value2\"]]", jp.GetJson("$"u8).ToString());
            Assert.AreEqual("[\"value1\",\"value2\"]", jp.GetJson("$[0]"u8).ToString());
            Assert.AreEqual("value1", jp.GetString("$[0][0]"u8));
            Assert.AreEqual("value2", jp.GetString("$[0][1]"u8));

            jp.Append("$[1]"u8, "value3");

            Assert.AreEqual("[[\"value1\",\"value2\"],[\"value3\"]]", jp.GetJson("$"u8).ToString());
            Assert.AreEqual("[\"value1\",\"value2\"]", jp.GetJson("$[0]"u8).ToString());
            Assert.AreEqual("value1", jp.GetString("$[0][0]"u8));
            Assert.AreEqual("value2", jp.GetString("$[0][1]"u8));
            Assert.AreEqual("[\"value3\"]", jp.GetJson("$[1]"u8).ToString());
            Assert.AreEqual("value3", jp.GetString("$[1][0]"u8));

            jp.Append("$[1]"u8, "value4");

            Assert.AreEqual("[[\"value1\",\"value2\"],[\"value3\",\"value4\"]]", jp.GetJson("$"u8).ToString());
            Assert.AreEqual("[\"value1\",\"value2\"]", jp.GetJson("$[0]"u8).ToString());
            Assert.AreEqual("value1", jp.GetString("$[0][0]"u8));
            Assert.AreEqual("value2", jp.GetString("$[0][1]"u8));
            Assert.AreEqual("[\"value3\",\"value4\"]", jp.GetJson("$[1]"u8).ToString());
            Assert.AreEqual("value3", jp.GetString("$[1][0]"u8));
            Assert.AreEqual("value4", jp.GetString("$[1][1]"u8));

            jp.Append("$"u8, "[\"value5\"]"u8);

            Assert.AreEqual("[[\"value1\",\"value2\"],[\"value3\",\"value4\"],[\"value5\"]]", jp.GetJson("$"u8).ToString());
            Assert.AreEqual("[\"value1\",\"value2\"]", jp.GetJson("$[0]"u8).ToString());
            Assert.AreEqual("value1", jp.GetString("$[0][0]"u8));
            Assert.AreEqual("value2", jp.GetString("$[0][1]"u8));
            Assert.AreEqual("[\"value3\",\"value4\"]", jp.GetJson("$[1]"u8).ToString());
            Assert.AreEqual("value3", jp.GetString("$[1][0]"u8));
            Assert.AreEqual("value4", jp.GetString("$[1][1]"u8));
            Assert.AreEqual("[\"value5\"]", jp.GetJson("$[2]"u8).ToString());
            Assert.AreEqual("value5", jp.GetString("$[2][0]"u8));

            Assert.AreEqual("[[\"value1\",\"value2\"],[\"value3\",\"value4\"],[\"value5\"]]", GetJsonString(jp));
        }

        [Test]
        public void ArrayIndex_RootAndInsert_TwoLevelTwoLevel_WithProperty()
        {
            JsonPatch jp = new("{\"x\":{\"y\":[{\"z\":{\"a\":[{\"b\":\"value1\"},{\"b\":\"value2\"}]}},{\"z\":{\"a\":[{\"b\":\"value3\"},{\"b\":\"value4\"}]}}]}}"u8.ToArray());

            Assert.AreEqual("{\"y\":[{\"z\":{\"a\":[{\"b\":\"value1\"},{\"b\":\"value2\"}]}},{\"z\":{\"a\":[{\"b\":\"value3\"},{\"b\":\"value4\"}]}}]}", jp.GetJson("$.x"u8).ToString());
            Assert.AreEqual("[{\"z\":{\"a\":[{\"b\":\"value1\"},{\"b\":\"value2\"}]}},{\"z\":{\"a\":[{\"b\":\"value3\"},{\"b\":\"value4\"}]}}]", jp.GetJson("$.x.y"u8).ToString());
            Assert.AreEqual("{\"z\":{\"a\":[{\"b\":\"value1\"},{\"b\":\"value2\"}]}}", jp.GetJson("$.x.y[0]"u8).ToString());
            Assert.AreEqual("{\"a\":[{\"b\":\"value1\"},{\"b\":\"value2\"}]}", jp.GetJson("$.x.y[0].z"u8).ToString());
            Assert.AreEqual("[{\"b\":\"value1\"},{\"b\":\"value2\"}]", jp.GetJson("$.x.y[0].z.a"u8).ToString());
            Assert.AreEqual("{\"b\":\"value1\"}", jp.GetJson("$.x.y[0].z.a[0]"u8).ToString());
            Assert.AreEqual("value1", jp.GetString("$.x.y[0].z.a[0].b"u8));
            Assert.AreEqual("{\"b\":\"value2\"}", jp.GetJson("$.x.y[0].z.a[1]"u8).ToString());
            Assert.AreEqual("value2", jp.GetString("$.x.y[0].z.a[1].b"u8));
            Assert.AreEqual("{\"z\":{\"a\":[{\"b\":\"value3\"},{\"b\":\"value4\"}]}}", jp.GetJson("$.x.y[1]"u8).ToString());
            Assert.AreEqual("{\"a\":[{\"b\":\"value3\"},{\"b\":\"value4\"}]}", jp.GetJson("$.x.y[1].z"u8).ToString());
            Assert.AreEqual("[{\"b\":\"value3\"},{\"b\":\"value4\"}]", jp.GetJson("$.x.y[1].z.a"u8).ToString());
            Assert.AreEqual("{\"b\":\"value3\"}", jp.GetJson("$.x.y[1].z.a[0]"u8).ToString());
            Assert.AreEqual("value3", jp.GetString("$.x.y[1].z.a[0].b"u8));
            Assert.AreEqual("{\"b\":\"value4\"}", jp.GetJson("$.x.y[1].z.a[1]"u8).ToString());
            Assert.AreEqual("value4", jp.GetString("$.x.y[1].z.a[1].b"u8));

            jp.Append("$.x.y[0].z.a"u8, "{\"b\":\"value5\"}"u8);

            Assert.AreEqual("{\"y\":[{\"z\":{\"a\":[{\"b\":\"value1\"},{\"b\":\"value2\"}]}},{\"z\":{\"a\":[{\"b\":\"value3\"},{\"b\":\"value4\"}]}}]}", jp.GetJson("$.x"u8).ToString());
            Assert.AreEqual("[{\"z\":{\"a\":[{\"b\":\"value1\"},{\"b\":\"value2\"}]}},{\"z\":{\"a\":[{\"b\":\"value3\"},{\"b\":\"value4\"}]}}]", jp.GetJson("$.x.y"u8).ToString());
            Assert.AreEqual("{\"z\":{\"a\":[{\"b\":\"value1\"},{\"b\":\"value2\"}]}}", jp.GetJson("$.x.y[0]"u8).ToString());
            Assert.AreEqual("{\"a\":[{\"b\":\"value1\"},{\"b\":\"value2\"}]}", jp.GetJson("$.x.y[0].z"u8).ToString());
            Assert.AreEqual("[{\"b\":\"value1\"},{\"b\":\"value2\"},{\"b\":\"value5\"}]", jp.GetJson("$.x.y[0].z.a"u8).ToString());
            Assert.AreEqual("{\"b\":\"value1\"}", jp.GetJson("$.x.y[0].z.a[0]"u8).ToString());
            Assert.AreEqual("value1", jp.GetString("$.x.y[0].z.a[0].b"u8));
            Assert.AreEqual("{\"b\":\"value2\"}", jp.GetJson("$.x.y[0].z.a[1]"u8).ToString());
            Assert.AreEqual("value2", jp.GetString("$.x.y[0].z.a[1].b"u8));
            Assert.AreEqual("{\"b\":\"value5\"}", jp.GetJson("$.x.y[0].z.a[2]"u8).ToString());
            Assert.AreEqual("value5", jp.GetString("$.x.y[0].z.a[2].b"u8));
            Assert.AreEqual("{\"z\":{\"a\":[{\"b\":\"value3\"},{\"b\":\"value4\"}]}}", jp.GetJson("$.x.y[1]"u8).ToString());
            Assert.AreEqual("{\"a\":[{\"b\":\"value3\"},{\"b\":\"value4\"}]}", jp.GetJson("$.x.y[1].z"u8).ToString());
            Assert.AreEqual("[{\"b\":\"value3\"},{\"b\":\"value4\"}]", jp.GetJson("$.x.y[1].z.a"u8).ToString());
            Assert.AreEqual("{\"b\":\"value3\"}", jp.GetJson("$.x.y[1].z.a[0]"u8).ToString());
            Assert.AreEqual("value3", jp.GetString("$.x.y[1].z.a[0].b"u8));
            Assert.AreEqual("{\"b\":\"value4\"}", jp.GetJson("$.x.y[1].z.a[1]"u8).ToString());
            Assert.AreEqual("value4", jp.GetString("$.x.y[1].z.a[1].b"u8));

            jp.Append("$.x.y[0].z.a"u8, "{\"b\":\"value6\"}"u8);

            Assert.AreEqual("{\"y\":[{\"z\":{\"a\":[{\"b\":\"value1\"},{\"b\":\"value2\"}]}},{\"z\":{\"a\":[{\"b\":\"value3\"},{\"b\":\"value4\"}]}}]}", jp.GetJson("$.x"u8).ToString());
            Assert.AreEqual("[{\"z\":{\"a\":[{\"b\":\"value1\"},{\"b\":\"value2\"}]}},{\"z\":{\"a\":[{\"b\":\"value3\"},{\"b\":\"value4\"}]}}]", jp.GetJson("$.x.y"u8).ToString());
            Assert.AreEqual("{\"z\":{\"a\":[{\"b\":\"value1\"},{\"b\":\"value2\"}]}}", jp.GetJson("$.x.y[0]"u8).ToString());
            Assert.AreEqual("{\"a\":[{\"b\":\"value1\"},{\"b\":\"value2\"}]}", jp.GetJson("$.x.y[0].z"u8).ToString());
            Assert.AreEqual("[{\"b\":\"value1\"},{\"b\":\"value2\"},{\"b\":\"value5\"},{\"b\":\"value6\"}]", jp.GetJson("$.x.y[0].z.a"u8).ToString());
            Assert.AreEqual("{\"b\":\"value1\"}", jp.GetJson("$.x.y[0].z.a[0]"u8).ToString());
            Assert.AreEqual("value1", jp.GetString("$.x.y[0].z.a[0].b"u8));
            Assert.AreEqual("{\"b\":\"value2\"}", jp.GetJson("$.x.y[0].z.a[1]"u8).ToString());
            Assert.AreEqual("value2", jp.GetString("$.x.y[0].z.a[1].b"u8));
            Assert.AreEqual("{\"b\":\"value5\"}", jp.GetJson("$.x.y[0].z.a[2]"u8).ToString());
            Assert.AreEqual("value5", jp.GetString("$.x.y[0].z.a[2].b"u8));
            Assert.AreEqual("{\"b\":\"value6\"}", jp.GetJson("$.x.y[0].z.a[3]"u8).ToString());
            Assert.AreEqual("value6", jp.GetString("$.x.y[0].z.a[3].b"u8));
            Assert.AreEqual("{\"z\":{\"a\":[{\"b\":\"value3\"},{\"b\":\"value4\"}]}}", jp.GetJson("$.x.y[1]"u8).ToString());
            Assert.AreEqual("{\"a\":[{\"b\":\"value3\"},{\"b\":\"value4\"}]}", jp.GetJson("$.x.y[1].z"u8).ToString());
            Assert.AreEqual("[{\"b\":\"value3\"},{\"b\":\"value4\"}]", jp.GetJson("$.x.y[1].z.a"u8).ToString());
            Assert.AreEqual("{\"b\":\"value3\"}", jp.GetJson("$.x.y[1].z.a[0]"u8).ToString());
            Assert.AreEqual("value3", jp.GetString("$.x.y[1].z.a[0].b"u8));
            Assert.AreEqual("{\"b\":\"value4\"}", jp.GetJson("$.x.y[1].z.a[1]"u8).ToString());
            Assert.AreEqual("value4", jp.GetString("$.x.y[1].z.a[1].b"u8));

            jp.Append("$.x.y[1].z.a"u8, "{\"b\":\"value7\"}"u8);

            Assert.AreEqual("{\"y\":[{\"z\":{\"a\":[{\"b\":\"value1\"},{\"b\":\"value2\"}]}},{\"z\":{\"a\":[{\"b\":\"value3\"},{\"b\":\"value4\"}]}}]}", jp.GetJson("$.x"u8).ToString());
            Assert.AreEqual("[{\"z\":{\"a\":[{\"b\":\"value1\"},{\"b\":\"value2\"}]}},{\"z\":{\"a\":[{\"b\":\"value3\"},{\"b\":\"value4\"}]}}]", jp.GetJson("$.x.y"u8).ToString());
            Assert.AreEqual("{\"z\":{\"a\":[{\"b\":\"value1\"},{\"b\":\"value2\"}]}}", jp.GetJson("$.x.y[0]"u8).ToString());
            Assert.AreEqual("{\"a\":[{\"b\":\"value1\"},{\"b\":\"value2\"}]}", jp.GetJson("$.x.y[0].z"u8).ToString());
            Assert.AreEqual("[{\"b\":\"value1\"},{\"b\":\"value2\"},{\"b\":\"value5\"},{\"b\":\"value6\"}]", jp.GetJson("$.x.y[0].z.a"u8).ToString());
            Assert.AreEqual("{\"b\":\"value1\"}", jp.GetJson("$.x.y[0].z.a[0]"u8).ToString());
            Assert.AreEqual("value1", jp.GetString("$.x.y[0].z.a[0].b"u8));
            Assert.AreEqual("{\"b\":\"value2\"}", jp.GetJson("$.x.y[0].z.a[1]"u8).ToString());
            Assert.AreEqual("value2", jp.GetString("$.x.y[0].z.a[1].b"u8));
            Assert.AreEqual("{\"b\":\"value5\"}", jp.GetJson("$.x.y[0].z.a[2]"u8).ToString());
            Assert.AreEqual("value5", jp.GetString("$.x.y[0].z.a[2].b"u8));
            Assert.AreEqual("{\"b\":\"value6\"}", jp.GetJson("$.x.y[0].z.a[3]"u8).ToString());
            Assert.AreEqual("value6", jp.GetString("$.x.y[0].z.a[3].b"u8));
            Assert.AreEqual("{\"z\":{\"a\":[{\"b\":\"value3\"},{\"b\":\"value4\"}]}}", jp.GetJson("$.x.y[1]"u8).ToString());
            Assert.AreEqual("{\"a\":[{\"b\":\"value3\"},{\"b\":\"value4\"}]}", jp.GetJson("$.x.y[1].z"u8).ToString());
            Assert.AreEqual("[{\"b\":\"value3\"},{\"b\":\"value4\"},{\"b\":\"value7\"}]", jp.GetJson("$.x.y[1].z.a"u8).ToString());
            Assert.AreEqual("{\"b\":\"value3\"}", jp.GetJson("$.x.y[1].z.a[0]"u8).ToString());
            Assert.AreEqual("value3", jp.GetString("$.x.y[1].z.a[0].b"u8));
            Assert.AreEqual("{\"b\":\"value4\"}", jp.GetJson("$.x.y[1].z.a[1]"u8).ToString());
            Assert.AreEqual("value4", jp.GetString("$.x.y[1].z.a[1].b"u8));
            Assert.AreEqual("{\"b\":\"value7\"}", jp.GetJson("$.x.y[1].z.a[2]"u8).ToString());
            Assert.AreEqual("value7", jp.GetString("$.x.y[1].z.a[2].b"u8));

            jp.Append("$.x.y[1].z.a"u8, "{\"b\":\"value8\"}"u8);

            Assert.AreEqual("{\"y\":[{\"z\":{\"a\":[{\"b\":\"value1\"},{\"b\":\"value2\"}]}},{\"z\":{\"a\":[{\"b\":\"value3\"},{\"b\":\"value4\"}]}}]}", jp.GetJson("$.x"u8).ToString());
            Assert.AreEqual("[{\"z\":{\"a\":[{\"b\":\"value1\"},{\"b\":\"value2\"}]}},{\"z\":{\"a\":[{\"b\":\"value3\"},{\"b\":\"value4\"}]}}]", jp.GetJson("$.x.y"u8).ToString());
            Assert.AreEqual("{\"z\":{\"a\":[{\"b\":\"value1\"},{\"b\":\"value2\"}]}}", jp.GetJson("$.x.y[0]"u8).ToString());
            Assert.AreEqual("{\"a\":[{\"b\":\"value1\"},{\"b\":\"value2\"}]}", jp.GetJson("$.x.y[0].z"u8).ToString());
            Assert.AreEqual("[{\"b\":\"value1\"},{\"b\":\"value2\"},{\"b\":\"value5\"},{\"b\":\"value6\"}]", jp.GetJson("$.x.y[0].z.a"u8).ToString());
            Assert.AreEqual("{\"b\":\"value1\"}", jp.GetJson("$.x.y[0].z.a[0]"u8).ToString());
            Assert.AreEqual("value1", jp.GetString("$.x.y[0].z.a[0].b"u8));
            Assert.AreEqual("{\"b\":\"value2\"}", jp.GetJson("$.x.y[0].z.a[1]"u8).ToString());
            Assert.AreEqual("value2", jp.GetString("$.x.y[0].z.a[1].b"u8));
            Assert.AreEqual("{\"b\":\"value5\"}", jp.GetJson("$.x.y[0].z.a[2]"u8).ToString());
            Assert.AreEqual("value5", jp.GetString("$.x.y[0].z.a[2].b"u8));
            Assert.AreEqual("{\"b\":\"value6\"}", jp.GetJson("$.x.y[0].z.a[3]"u8).ToString());
            Assert.AreEqual("value6", jp.GetString("$.x.y[0].z.a[3].b"u8));
            Assert.AreEqual("{\"z\":{\"a\":[{\"b\":\"value3\"},{\"b\":\"value4\"}]}}", jp.GetJson("$.x.y[1]"u8).ToString());
            Assert.AreEqual("{\"a\":[{\"b\":\"value3\"},{\"b\":\"value4\"}]}", jp.GetJson("$.x.y[1].z"u8).ToString());
            Assert.AreEqual("[{\"b\":\"value3\"},{\"b\":\"value4\"},{\"b\":\"value7\"},{\"b\":\"value8\"}]", jp.GetJson("$.x.y[1].z.a"u8).ToString());
            Assert.AreEqual("{\"b\":\"value3\"}", jp.GetJson("$.x.y[1].z.a[0]"u8).ToString());
            Assert.AreEqual("value3", jp.GetString("$.x.y[1].z.a[0].b"u8));
            Assert.AreEqual("{\"b\":\"value4\"}", jp.GetJson("$.x.y[1].z.a[1]"u8).ToString());
            Assert.AreEqual("value4", jp.GetString("$.x.y[1].z.a[1].b"u8));
            Assert.AreEqual("{\"b\":\"value7\"}", jp.GetJson("$.x.y[1].z.a[2]"u8).ToString());
            Assert.AreEqual("value7", jp.GetString("$.x.y[1].z.a[2].b"u8));
            Assert.AreEqual("{\"b\":\"value8\"}", jp.GetJson("$.x.y[1].z.a[3]"u8).ToString());
            Assert.AreEqual("value8", jp.GetString("$.x.y[1].z.a[3].b"u8));

            jp.Append("$.x.y"u8, "{\"z\":{\"a\":[{\"b\":\"value9\"}]}}"u8);

            Assert.AreEqual("{\"y\":[{\"z\":{\"a\":[{\"b\":\"value1\"},{\"b\":\"value2\"}]}},{\"z\":{\"a\":[{\"b\":\"value3\"},{\"b\":\"value4\"}]}}]}", jp.GetJson("$.x"u8).ToString());
            Assert.AreEqual("[{\"z\":{\"a\":[{\"b\":\"value1\"},{\"b\":\"value2\"}]}},{\"z\":{\"a\":[{\"b\":\"value3\"},{\"b\":\"value4\"}]}},{\"z\":{\"a\":[{\"b\":\"value9\"}]}}]", jp.GetJson("$.x.y"u8).ToString());
            Assert.AreEqual("{\"z\":{\"a\":[{\"b\":\"value1\"},{\"b\":\"value2\"}]}}", jp.GetJson("$.x.y[0]"u8).ToString());
            Assert.AreEqual("{\"a\":[{\"b\":\"value1\"},{\"b\":\"value2\"}]}", jp.GetJson("$.x.y[0].z"u8).ToString());
            Assert.AreEqual("[{\"b\":\"value1\"},{\"b\":\"value2\"},{\"b\":\"value5\"},{\"b\":\"value6\"}]", jp.GetJson("$.x.y[0].z.a"u8).ToString());
            Assert.AreEqual("{\"b\":\"value1\"}", jp.GetJson("$.x.y[0].z.a[0]"u8).ToString());
            Assert.AreEqual("value1", jp.GetString("$.x.y[0].z.a[0].b"u8));
            Assert.AreEqual("{\"b\":\"value2\"}", jp.GetJson("$.x.y[0].z.a[1]"u8).ToString());
            Assert.AreEqual("value2", jp.GetString("$.x.y[0].z.a[1].b"u8));
            Assert.AreEqual("{\"b\":\"value5\"}", jp.GetJson("$.x.y[0].z.a[2]"u8).ToString());
            Assert.AreEqual("value5", jp.GetString("$.x.y[0].z.a[2].b"u8));
            Assert.AreEqual("{\"b\":\"value6\"}", jp.GetJson("$.x.y[0].z.a[3]"u8).ToString());
            Assert.AreEqual("value6", jp.GetString("$.x.y[0].z.a[3].b"u8));
            Assert.AreEqual("{\"z\":{\"a\":[{\"b\":\"value3\"},{\"b\":\"value4\"}]}}", jp.GetJson("$.x.y[1]"u8).ToString());
            Assert.AreEqual("{\"a\":[{\"b\":\"value3\"},{\"b\":\"value4\"}]}", jp.GetJson("$.x.y[1].z"u8).ToString());
            Assert.AreEqual("[{\"b\":\"value3\"},{\"b\":\"value4\"},{\"b\":\"value7\"},{\"b\":\"value8\"}]", jp.GetJson("$.x.y[1].z.a"u8).ToString());
            Assert.AreEqual("{\"b\":\"value3\"}", jp.GetJson("$.x.y[1].z.a[0]"u8).ToString());
            Assert.AreEqual("value3", jp.GetString("$.x.y[1].z.a[0].b"u8));
            Assert.AreEqual("{\"b\":\"value4\"}", jp.GetJson("$.x.y[1].z.a[1]"u8).ToString());
            Assert.AreEqual("value4", jp.GetString("$.x.y[1].z.a[1].b"u8));
            Assert.AreEqual("{\"b\":\"value7\"}", jp.GetJson("$.x.y[1].z.a[2]"u8).ToString());
            Assert.AreEqual("value7", jp.GetString("$.x.y[1].z.a[2].b"u8));
            Assert.AreEqual("{\"b\":\"value8\"}", jp.GetJson("$.x.y[1].z.a[3]"u8).ToString());
            Assert.AreEqual("value8", jp.GetString("$.x.y[1].z.a[3].b"u8));
            Assert.AreEqual("{\"z\":{\"a\":[{\"b\":\"value9\"}]}}", jp.GetJson("$.x.y[2]"u8).ToString());
            Assert.AreEqual("{\"a\":[{\"b\":\"value9\"}]}", jp.GetJson("$.x.y[2].z"u8).ToString());
            Assert.AreEqual("[{\"b\":\"value9\"}]", jp.GetJson("$.x.y[2].z.a"u8).ToString());
            Assert.AreEqual("{\"b\":\"value9\"}", jp.GetJson("$.x.y[2].z.a[0]"u8).ToString());
            Assert.AreEqual("value9", jp.GetString("$.x.y[2].z.a[0].b"u8));

            Assert.AreEqual("{\"x\":{\"y\":[{\"z\":{\"a\":[{\"b\":\"value1\"},{\"b\":\"value2\"},{\"b\":\"value5\"},{\"b\":\"value6\"}]}},{\"z\":{\"a\":[{\"b\":\"value3\"},{\"b\":\"value4\"},{\"b\":\"value7\"},{\"b\":\"value8\"}]}},{\"z\":{\"a\":[{\"b\":\"value9\"}]}}]}}", GetJsonString(jp));
        }

        [Test]
        public void ArrayIndex_RootAndInsert_TwoLevelTwoLevel()
        {
            JsonPatch jp = new("{\"x\":{\"y\":[{\"z\":{\"a\":[\"value1\",\"value2\"]}},{\"z\":{\"a\":[\"value3\",\"value4\"]}}]}}"u8.ToArray());

            Assert.AreEqual("{\"y\":[{\"z\":{\"a\":[\"value1\",\"value2\"]}},{\"z\":{\"a\":[\"value3\",\"value4\"]}}]}", jp.GetJson("$.x"u8).ToString());
            Assert.AreEqual("[{\"z\":{\"a\":[\"value1\",\"value2\"]}},{\"z\":{\"a\":[\"value3\",\"value4\"]}}]", jp.GetJson("$.x.y"u8).ToString());
            Assert.AreEqual("{\"z\":{\"a\":[\"value1\",\"value2\"]}}", jp.GetJson("$.x.y[0]"u8).ToString());
            Assert.AreEqual("{\"a\":[\"value1\",\"value2\"]}", jp.GetJson("$.x.y[0].z"u8).ToString());
            Assert.AreEqual("[\"value1\",\"value2\"]", jp.GetJson("$.x.y[0].z.a"u8).ToString());
            Assert.AreEqual("value1", jp.GetString("$.x.y[0].z.a[0]"u8));
            Assert.AreEqual("value2", jp.GetString("$.x.y[0].z.a[1]"u8));
            Assert.AreEqual("{\"z\":{\"a\":[\"value3\",\"value4\"]}}", jp.GetJson("$.x.y[1]"u8).ToString());
            Assert.AreEqual("{\"a\":[\"value3\",\"value4\"]}", jp.GetJson("$.x.y[1].z"u8).ToString());
            Assert.AreEqual("[\"value3\",\"value4\"]", jp.GetJson("$.x.y[1].z.a"u8).ToString());
            Assert.AreEqual("value3", jp.GetString("$.x.y[1].z.a[0]"u8));
            Assert.AreEqual("value4", jp.GetString("$.x.y[1].z.a[1]"u8));

            jp.Append("$.x.y[0].z.a"u8, "value5");

            Assert.AreEqual("{\"y\":[{\"z\":{\"a\":[\"value1\",\"value2\"]}},{\"z\":{\"a\":[\"value3\",\"value4\"]}}]}", jp.GetJson("$.x"u8).ToString());
            Assert.AreEqual("[{\"z\":{\"a\":[\"value1\",\"value2\"]}},{\"z\":{\"a\":[\"value3\",\"value4\"]}}]", jp.GetJson("$.x.y"u8).ToString());
            Assert.AreEqual("{\"z\":{\"a\":[\"value1\",\"value2\"]}}", jp.GetJson("$.x.y[0]"u8).ToString());
            Assert.AreEqual("{\"a\":[\"value1\",\"value2\"]}", jp.GetJson("$.x.y[0].z"u8).ToString());
            Assert.AreEqual("[\"value1\",\"value2\",\"value5\"]", jp.GetJson("$.x.y[0].z.a"u8).ToString());
            Assert.AreEqual("value1", jp.GetString("$.x.y[0].z.a[0]"u8));
            Assert.AreEqual("value2", jp.GetString("$.x.y[0].z.a[1]"u8));
            Assert.AreEqual("value5", jp.GetString("$.x.y[0].z.a[2]"u8));
            Assert.AreEqual("{\"z\":{\"a\":[\"value3\",\"value4\"]}}", jp.GetJson("$.x.y[1]"u8).ToString());
            Assert.AreEqual("{\"a\":[\"value3\",\"value4\"]}", jp.GetJson("$.x.y[1].z"u8).ToString());
            Assert.AreEqual("[\"value3\",\"value4\"]", jp.GetJson("$.x.y[1].z.a"u8).ToString());
            Assert.AreEqual("value3", jp.GetString("$.x.y[1].z.a[0]"u8));
            Assert.AreEqual("value4", jp.GetString("$.x.y[1].z.a[1]"u8));

            jp.Append("$.x.y[0].z.a"u8, "value6");

            Assert.AreEqual("{\"y\":[{\"z\":{\"a\":[\"value1\",\"value2\"]}},{\"z\":{\"a\":[\"value3\",\"value4\"]}}]}", jp.GetJson("$.x"u8).ToString());
            Assert.AreEqual("[{\"z\":{\"a\":[\"value1\",\"value2\"]}},{\"z\":{\"a\":[\"value3\",\"value4\"]}}]", jp.GetJson("$.x.y"u8).ToString());
            Assert.AreEqual("{\"z\":{\"a\":[\"value1\",\"value2\"]}}", jp.GetJson("$.x.y[0]"u8).ToString());
            Assert.AreEqual("{\"a\":[\"value1\",\"value2\"]}", jp.GetJson("$.x.y[0].z"u8).ToString());
            Assert.AreEqual("[\"value1\",\"value2\",\"value5\",\"value6\"]", jp.GetJson("$.x.y[0].z.a"u8).ToString());
            Assert.AreEqual("value1", jp.GetString("$.x.y[0].z.a[0]"u8));
            Assert.AreEqual("value2", jp.GetString("$.x.y[0].z.a[1]"u8));
            Assert.AreEqual("value5", jp.GetString("$.x.y[0].z.a[2]"u8));
            Assert.AreEqual("value6", jp.GetString("$.x.y[0].z.a[3]"u8));
            Assert.AreEqual("{\"z\":{\"a\":[\"value3\",\"value4\"]}}", jp.GetJson("$.x.y[1]"u8).ToString());
            Assert.AreEqual("{\"a\":[\"value3\",\"value4\"]}", jp.GetJson("$.x.y[1].z"u8).ToString());
            Assert.AreEqual("[\"value3\",\"value4\"]", jp.GetJson("$.x.y[1].z.a"u8).ToString());
            Assert.AreEqual("value3", jp.GetString("$.x.y[1].z.a[0]"u8));
            Assert.AreEqual("value4", jp.GetString("$.x.y[1].z.a[1]"u8));

            jp.Append("$.x.y[1].z.a"u8, "value7");

            Assert.AreEqual("{\"y\":[{\"z\":{\"a\":[\"value1\",\"value2\"]}},{\"z\":{\"a\":[\"value3\",\"value4\"]}}]}", jp.GetJson("$.x"u8).ToString());
            Assert.AreEqual("[{\"z\":{\"a\":[\"value1\",\"value2\"]}},{\"z\":{\"a\":[\"value3\",\"value4\"]}}]", jp.GetJson("$.x.y"u8).ToString());
            Assert.AreEqual("{\"z\":{\"a\":[\"value1\",\"value2\"]}}", jp.GetJson("$.x.y[0]"u8).ToString());
            Assert.AreEqual("{\"a\":[\"value1\",\"value2\"]}", jp.GetJson("$.x.y[0].z"u8).ToString());
            Assert.AreEqual("[\"value1\",\"value2\",\"value5\",\"value6\"]", jp.GetJson("$.x.y[0].z.a"u8).ToString());
            Assert.AreEqual("value1", jp.GetString("$.x.y[0].z.a[0]"u8));
            Assert.AreEqual("value2", jp.GetString("$.x.y[0].z.a[1]"u8));
            Assert.AreEqual("value5", jp.GetString("$.x.y[0].z.a[2]"u8));
            Assert.AreEqual("value6", jp.GetString("$.x.y[0].z.a[3]"u8));
            Assert.AreEqual("{\"z\":{\"a\":[\"value3\",\"value4\"]}}", jp.GetJson("$.x.y[1]"u8).ToString());
            Assert.AreEqual("{\"a\":[\"value3\",\"value4\"]}", jp.GetJson("$.x.y[1].z"u8).ToString());
            Assert.AreEqual("[\"value3\",\"value4\",\"value7\"]", jp.GetJson("$.x.y[1].z.a"u8).ToString());
            Assert.AreEqual("value3", jp.GetString("$.x.y[1].z.a[0]"u8));
            Assert.AreEqual("value4", jp.GetString("$.x.y[1].z.a[1]"u8));
            Assert.AreEqual("value7", jp.GetString("$.x.y[1].z.a[2]"u8));

            jp.Append("$.x.y[1].z.a"u8, "value8");

            Assert.AreEqual("{\"y\":[{\"z\":{\"a\":[\"value1\",\"value2\"]}},{\"z\":{\"a\":[\"value3\",\"value4\"]}}]}", jp.GetJson("$.x"u8).ToString());
            Assert.AreEqual("[{\"z\":{\"a\":[\"value1\",\"value2\"]}},{\"z\":{\"a\":[\"value3\",\"value4\"]}}]", jp.GetJson("$.x.y"u8).ToString());
            Assert.AreEqual("{\"z\":{\"a\":[\"value1\",\"value2\"]}}", jp.GetJson("$.x.y[0]"u8).ToString());
            Assert.AreEqual("{\"a\":[\"value1\",\"value2\"]}", jp.GetJson("$.x.y[0].z"u8).ToString());
            Assert.AreEqual("[\"value1\",\"value2\",\"value5\",\"value6\"]", jp.GetJson("$.x.y[0].z.a"u8).ToString());
            Assert.AreEqual("value1", jp.GetString("$.x.y[0].z.a[0]"u8));
            Assert.AreEqual("value2", jp.GetString("$.x.y[0].z.a[1]"u8));
            Assert.AreEqual("value5", jp.GetString("$.x.y[0].z.a[2]"u8));
            Assert.AreEqual("value6", jp.GetString("$.x.y[0].z.a[3]"u8));
            Assert.AreEqual("{\"z\":{\"a\":[\"value3\",\"value4\"]}}", jp.GetJson("$.x.y[1]"u8).ToString());
            Assert.AreEqual("{\"a\":[\"value3\",\"value4\"]}", jp.GetJson("$.x.y[1].z"u8).ToString());
            Assert.AreEqual("[\"value3\",\"value4\",\"value7\",\"value8\"]", jp.GetJson("$.x.y[1].z.a"u8).ToString());
            Assert.AreEqual("value3", jp.GetString("$.x.y[1].z.a[0]"u8));
            Assert.AreEqual("value4", jp.GetString("$.x.y[1].z.a[1]"u8));
            Assert.AreEqual("value7", jp.GetString("$.x.y[1].z.a[2]"u8));
            Assert.AreEqual("value8", jp.GetString("$.x.y[1].z.a[3]"u8));

            jp.Append("$.x.y"u8, "{\"z\":{\"a\":[\"value9\"]}}"u8);

            Assert.AreEqual("{\"y\":[{\"z\":{\"a\":[\"value1\",\"value2\"]}},{\"z\":{\"a\":[\"value3\",\"value4\"]}}]}", jp.GetJson("$.x"u8).ToString());
            Assert.AreEqual("[{\"z\":{\"a\":[\"value1\",\"value2\"]}},{\"z\":{\"a\":[\"value3\",\"value4\"]}},{\"z\":{\"a\":[\"value9\"]}}]", jp.GetJson("$.x.y"u8).ToString());
            Assert.AreEqual("{\"z\":{\"a\":[\"value1\",\"value2\"]}}", jp.GetJson("$.x.y[0]"u8).ToString());
            Assert.AreEqual("{\"a\":[\"value1\",\"value2\"]}", jp.GetJson("$.x.y[0].z"u8).ToString());
            Assert.AreEqual("[\"value1\",\"value2\",\"value5\",\"value6\"]", jp.GetJson("$.x.y[0].z.a"u8).ToString());
            Assert.AreEqual("value1", jp.GetString("$.x.y[0].z.a[0]"u8));
            Assert.AreEqual("value2", jp.GetString("$.x.y[0].z.a[1]"u8));
            Assert.AreEqual("value5", jp.GetString("$.x.y[0].z.a[2]"u8));
            Assert.AreEqual("value6", jp.GetString("$.x.y[0].z.a[3]"u8));
            Assert.AreEqual("{\"z\":{\"a\":[\"value3\",\"value4\"]}}", jp.GetJson("$.x.y[1]"u8).ToString());
            Assert.AreEqual("{\"a\":[\"value3\",\"value4\"]}", jp.GetJson("$.x.y[1].z"u8).ToString());
            Assert.AreEqual("[\"value3\",\"value4\",\"value7\",\"value8\"]", jp.GetJson("$.x.y[1].z.a"u8).ToString());
            Assert.AreEqual("value3", jp.GetString("$.x.y[1].z.a[0]"u8));
            Assert.AreEqual("value4", jp.GetString("$.x.y[1].z.a[1]"u8));
            Assert.AreEqual("value7", jp.GetString("$.x.y[1].z.a[2]"u8));
            Assert.AreEqual("value8", jp.GetString("$.x.y[1].z.a[3]"u8));
            Assert.AreEqual("{\"z\":{\"a\":[\"value9\"]}}", jp.GetJson("$.x.y[2]"u8).ToString());
            Assert.AreEqual("{\"a\":[\"value9\"]}", jp.GetJson("$.x.y[2].z"u8).ToString());
            Assert.AreEqual("[\"value9\"]", jp.GetJson("$.x.y[2].z.a"u8).ToString());
            Assert.AreEqual("value9", jp.GetString("$.x.y[2].z.a[0]"u8));

            Assert.AreEqual("{\"x\":{\"y\":[{\"z\":{\"a\":[\"value1\",\"value2\",\"value5\",\"value6\"]}},{\"z\":{\"a\":[\"value3\",\"value4\",\"value7\",\"value8\"]}},{\"z\":{\"a\":[\"value9\"]}}]}}", GetJsonString(jp));
        }

        [Test]
        public void ArrayIndex_Insert_TwoLevelTwoLevel_WithProperty()
        {
            JsonPatch jp = new();

            jp.Append("$.x.y[0].z.a"u8, "{\"b\":\"value1\"}"u8);

            Assert.AreEqual("{\"y\":[{\"z\":{\"a\":[{\"b\":\"value1\"}]}}]}", jp.GetJson("$.x"u8).ToString());
            Assert.AreEqual("[{\"z\":{\"a\":[{\"b\":\"value1\"}]}}]", jp.GetJson("$.x.y"u8).ToString());
            Assert.AreEqual("{\"z\":{\"a\":[{\"b\":\"value1\"}]}}", jp.GetJson("$.x.y[0]"u8).ToString());
            Assert.AreEqual("{\"a\":[{\"b\":\"value1\"}]}", jp.GetJson("$.x.y[0].z"u8).ToString());
            Assert.AreEqual("[{\"b\":\"value1\"}]", jp.GetJson("$.x.y[0].z.a"u8).ToString());
            Assert.AreEqual("{\"b\":\"value1\"}", jp.GetJson("$.x.y[0].z.a[0]"u8).ToString());
            Assert.AreEqual("value1", jp.GetString("$.x.y[0].z.a[0].b"u8));

            jp.Append("$.x.y[0].z.a"u8, "{\"b\":\"value2\"}"u8);

            Assert.AreEqual("{\"y\":[{\"z\":{\"a\":[{\"b\":\"value1\"},{\"b\":\"value2\"}]}}]}", jp.GetJson("$.x"u8).ToString());
            Assert.AreEqual("[{\"z\":{\"a\":[{\"b\":\"value1\"},{\"b\":\"value2\"}]}}]", jp.GetJson("$.x.y"u8).ToString());
            Assert.AreEqual("{\"z\":{\"a\":[{\"b\":\"value1\"},{\"b\":\"value2\"}]}}", jp.GetJson("$.x.y[0]"u8).ToString());
            Assert.AreEqual("{\"a\":[{\"b\":\"value1\"},{\"b\":\"value2\"}]}", jp.GetJson("$.x.y[0].z"u8).ToString());
            Assert.AreEqual("[{\"b\":\"value1\"},{\"b\":\"value2\"}]", jp.GetJson("$.x.y[0].z.a"u8).ToString());
            Assert.AreEqual("{\"b\":\"value1\"}", jp.GetJson("$.x.y[0].z.a[0]"u8).ToString());
            Assert.AreEqual("value1", jp.GetString("$.x.y[0].z.a[0].b"u8));
            Assert.AreEqual("{\"b\":\"value2\"}", jp.GetJson("$.x.y[0].z.a[1]"u8).ToString());
            Assert.AreEqual("value2", jp.GetString("$.x.y[0].z.a[1].b"u8));

            jp.Append("$.x.y[1].z.a"u8, "{\"b\":\"value3\"}"u8);

            Assert.AreEqual("{\"y\":[{\"z\":{\"a\":[{\"b\":\"value1\"},{\"b\":\"value2\"}]}},{\"z\":{\"a\":[{\"b\":\"value3\"}]}}]}", jp.GetJson("$.x"u8).ToString());
            Assert.AreEqual("[{\"z\":{\"a\":[{\"b\":\"value1\"},{\"b\":\"value2\"}]}},{\"z\":{\"a\":[{\"b\":\"value3\"}]}}]", jp.GetJson("$.x.y"u8).ToString());
            Assert.AreEqual("{\"z\":{\"a\":[{\"b\":\"value1\"},{\"b\":\"value2\"}]}}", jp.GetJson("$.x.y[0]"u8).ToString());
            Assert.AreEqual("{\"a\":[{\"b\":\"value1\"},{\"b\":\"value2\"}]}", jp.GetJson("$.x.y[0].z"u8).ToString());
            Assert.AreEqual("[{\"b\":\"value1\"},{\"b\":\"value2\"}]", jp.GetJson("$.x.y[0].z.a"u8).ToString());
            Assert.AreEqual("{\"b\":\"value1\"}", jp.GetJson("$.x.y[0].z.a[0]"u8).ToString());
            Assert.AreEqual("value1", jp.GetString("$.x.y[0].z.a[0].b"u8));
            Assert.AreEqual("{\"b\":\"value2\"}", jp.GetJson("$.x.y[0].z.a[1]"u8).ToString());
            Assert.AreEqual("value2", jp.GetString("$.x.y[0].z.a[1].b"u8));
            Assert.AreEqual("{\"z\":{\"a\":[{\"b\":\"value3\"}]}}", jp.GetJson("$.x.y[1]"u8).ToString());
            Assert.AreEqual("{\"a\":[{\"b\":\"value3\"}]}", jp.GetJson("$.x.y[1].z"u8).ToString());
            Assert.AreEqual("[{\"b\":\"value3\"}]", jp.GetJson("$.x.y[1].z.a"u8).ToString());
            Assert.AreEqual("{\"b\":\"value3\"}", jp.GetJson("$.x.y[1].z.a[0]"u8).ToString());
            Assert.AreEqual("value3", jp.GetString("$.x.y[1].z.a[0].b"u8));

            jp.Append("$.x.y[1].z.a"u8, "{\"b\":\"value4\"}"u8);

            Assert.AreEqual("{\"y\":[{\"z\":{\"a\":[{\"b\":\"value1\"},{\"b\":\"value2\"}]}},{\"z\":{\"a\":[{\"b\":\"value3\"},{\"b\":\"value4\"}]}}]}", jp.GetJson("$.x"u8).ToString());
            Assert.AreEqual("[{\"z\":{\"a\":[{\"b\":\"value1\"},{\"b\":\"value2\"}]}},{\"z\":{\"a\":[{\"b\":\"value3\"},{\"b\":\"value4\"}]}}]", jp.GetJson("$.x.y"u8).ToString());
            Assert.AreEqual("{\"z\":{\"a\":[{\"b\":\"value1\"},{\"b\":\"value2\"}]}}", jp.GetJson("$.x.y[0]"u8).ToString());
            Assert.AreEqual("{\"a\":[{\"b\":\"value1\"},{\"b\":\"value2\"}]}", jp.GetJson("$.x.y[0].z"u8).ToString());
            Assert.AreEqual("[{\"b\":\"value1\"},{\"b\":\"value2\"}]", jp.GetJson("$.x.y[0].z.a"u8).ToString());
            Assert.AreEqual("{\"b\":\"value1\"}", jp.GetJson("$.x.y[0].z.a[0]"u8).ToString());
            Assert.AreEqual("value1", jp.GetString("$.x.y[0].z.a[0].b"u8));
            Assert.AreEqual("{\"b\":\"value2\"}", jp.GetJson("$.x.y[0].z.a[1]"u8).ToString());
            Assert.AreEqual("value2", jp.GetString("$.x.y[0].z.a[1].b"u8));
            Assert.AreEqual("{\"z\":{\"a\":[{\"b\":\"value3\"},{\"b\":\"value4\"}]}}", jp.GetJson("$.x.y[1]"u8).ToString());
            Assert.AreEqual("{\"a\":[{\"b\":\"value3\"},{\"b\":\"value4\"}]}", jp.GetJson("$.x.y[1].z"u8).ToString());
            Assert.AreEqual("[{\"b\":\"value3\"},{\"b\":\"value4\"}]", jp.GetJson("$.x.y[1].z.a"u8).ToString());
            Assert.AreEqual("{\"b\":\"value3\"}", jp.GetJson("$.x.y[1].z.a[0]"u8).ToString());
            Assert.AreEqual("value3", jp.GetString("$.x.y[1].z.a[0].b"u8));
            Assert.AreEqual("{\"b\":\"value4\"}", jp.GetJson("$.x.y[1].z.a[1]"u8).ToString());
            Assert.AreEqual("value4", jp.GetString("$.x.y[1].z.a[1].b"u8));

            jp.Append("$.x.y"u8, "{\"z\":{\"a\":[{\"b\":\"value5\"}]}}"u8);
            Assert.AreEqual("{\"y\":[{\"z\":{\"a\":[{\"b\":\"value1\"},{\"b\":\"value2\"}]}},{\"z\":{\"a\":[{\"b\":\"value3\"},{\"b\":\"value4\"}]}},{\"z\":{\"a\":[{\"b\":\"value5\"}]}}]}", jp.GetJson("$.x"u8).ToString());
            Assert.AreEqual("[{\"z\":{\"a\":[{\"b\":\"value1\"},{\"b\":\"value2\"}]}},{\"z\":{\"a\":[{\"b\":\"value3\"},{\"b\":\"value4\"}]}},{\"z\":{\"a\":[{\"b\":\"value5\"}]}}]", jp.GetJson("$.x.y"u8).ToString());
            Assert.AreEqual("{\"z\":{\"a\":[{\"b\":\"value1\"},{\"b\":\"value2\"}]}}", jp.GetJson("$.x.y[0]"u8).ToString());
            Assert.AreEqual("{\"a\":[{\"b\":\"value1\"},{\"b\":\"value2\"}]}", jp.GetJson("$.x.y[0].z"u8).ToString());
            Assert.AreEqual("[{\"b\":\"value1\"},{\"b\":\"value2\"}]", jp.GetJson("$.x.y[0].z.a"u8).ToString());
            Assert.AreEqual("{\"b\":\"value1\"}", jp.GetJson("$.x.y[0].z.a[0]"u8).ToString());
            Assert.AreEqual("value1", jp.GetString("$.x.y[0].z.a[0].b"u8));
            Assert.AreEqual("{\"b\":\"value2\"}", jp.GetJson("$.x.y[0].z.a[1]"u8).ToString());
            Assert.AreEqual("value2", jp.GetString("$.x.y[0].z.a[1].b"u8));
            Assert.AreEqual("{\"z\":{\"a\":[{\"b\":\"value3\"},{\"b\":\"value4\"}]}}", jp.GetJson("$.x.y[1]"u8).ToString());
            Assert.AreEqual("{\"a\":[{\"b\":\"value3\"},{\"b\":\"value4\"}]}", jp.GetJson("$.x.y[1].z"u8).ToString());
            Assert.AreEqual("[{\"b\":\"value3\"},{\"b\":\"value4\"}]", jp.GetJson("$.x.y[1].z.a"u8).ToString());
            Assert.AreEqual("{\"b\":\"value3\"}", jp.GetJson("$.x.y[1].z.a[0]"u8).ToString());
            Assert.AreEqual("value3", jp.GetString("$.x.y[1].z.a[0].b"u8));
            Assert.AreEqual("{\"b\":\"value4\"}", jp.GetJson("$.x.y[1].z.a[1]"u8).ToString());
            Assert.AreEqual("value4", jp.GetString("$.x.y[1].z.a[1].b"u8));
            Assert.AreEqual("{\"z\":{\"a\":[{\"b\":\"value5\"}]}}", jp.GetJson("$.x.y[2]"u8).ToString());
            Assert.AreEqual("{\"a\":[{\"b\":\"value5\"}]}", jp.GetJson("$.x.y[2].z"u8).ToString());
            Assert.AreEqual("[{\"b\":\"value5\"}]", jp.GetJson("$.x.y[2].z.a"u8).ToString());
            Assert.AreEqual("{\"b\":\"value5\"}", jp.GetJson("$.x.y[2].z.a[0]"u8).ToString());
            Assert.AreEqual("value5", jp.GetString("$.x.y[2].z.a[0].b"u8));

            Assert.AreEqual("{\"x\":{\"y\":[{\"z\":{\"a\":[{\"b\":\"value1\"},{\"b\":\"value2\"}]}},{\"z\":{\"a\":[{\"b\":\"value3\"},{\"b\":\"value4\"}]}},{\"z\":{\"a\":[{\"b\":\"value5\"}]}}]}}", GetJsonString(jp));
        }

        [Test]
        public void ArrayIndex_Insert_TwoLevelTwoLevel()
        {
            JsonPatch jp = new();

            jp.Append("$.x.y[0].z.a"u8, "value1");

            Assert.AreEqual("{\"y\":[{\"z\":{\"a\":[\"value1\"]}}]}", jp.GetJson("$.x"u8).ToString());
            Assert.AreEqual("[{\"z\":{\"a\":[\"value1\"]}}]", jp.GetJson("$.x.y"u8).ToString());
            Assert.AreEqual("{\"z\":{\"a\":[\"value1\"]}}", jp.GetJson("$.x.y[0]"u8).ToString());
            Assert.AreEqual("{\"a\":[\"value1\"]}", jp.GetJson("$.x.y[0].z"u8).ToString());
            Assert.AreEqual("[\"value1\"]", jp.GetJson("$.x.y[0].z.a"u8).ToString());
            Assert.AreEqual("value1", jp.GetString("$.x.y[0].z.a[0]"u8));

            jp.Append("$.x.y[0].z.a"u8, "value2");

            Assert.AreEqual("{\"y\":[{\"z\":{\"a\":[\"value1\",\"value2\"]}}]}", jp.GetJson("$.x"u8).ToString());
            Assert.AreEqual("[{\"z\":{\"a\":[\"value1\",\"value2\"]}}]", jp.GetJson("$.x.y"u8).ToString());
            Assert.AreEqual("{\"z\":{\"a\":[\"value1\",\"value2\"]}}", jp.GetJson("$.x.y[0]"u8).ToString());
            Assert.AreEqual("{\"a\":[\"value1\",\"value2\"]}", jp.GetJson("$.x.y[0].z"u8).ToString());
            Assert.AreEqual("[\"value1\",\"value2\"]", jp.GetJson("$.x.y[0].z.a"u8).ToString());
            Assert.AreEqual("value1", jp.GetString("$.x.y[0].z.a[0]"u8));
            Assert.AreEqual("value2", jp.GetString("$.x.y[0].z.a[1]"u8));

            jp.Append("$.x.y[1].z.a"u8, "value3");

            Assert.AreEqual("{\"y\":[{\"z\":{\"a\":[\"value1\",\"value2\"]}},{\"z\":{\"a\":[\"value3\"]}}]}", jp.GetJson("$.x"u8).ToString());
            Assert.AreEqual("[{\"z\":{\"a\":[\"value1\",\"value2\"]}},{\"z\":{\"a\":[\"value3\"]}}]", jp.GetJson("$.x.y"u8).ToString());
            Assert.AreEqual("{\"z\":{\"a\":[\"value1\",\"value2\"]}}", jp.GetJson("$.x.y[0]"u8).ToString());
            Assert.AreEqual("{\"a\":[\"value1\",\"value2\"]}", jp.GetJson("$.x.y[0].z"u8).ToString());
            Assert.AreEqual("[\"value1\",\"value2\"]", jp.GetJson("$.x.y[0].z.a"u8).ToString());
            Assert.AreEqual("value1", jp.GetString("$.x.y[0].z.a[0]"u8));
            Assert.AreEqual("value2", jp.GetString("$.x.y[0].z.a[1]"u8));
            Assert.AreEqual("{\"z\":{\"a\":[\"value3\"]}}", jp.GetJson("$.x.y[1]"u8).ToString());
            Assert.AreEqual("{\"a\":[\"value3\"]}", jp.GetJson("$.x.y[1].z"u8).ToString());
            Assert.AreEqual("[\"value3\"]", jp.GetJson("$.x.y[1].z.a"u8).ToString());
            Assert.AreEqual("value3", jp.GetString("$.x.y[1].z.a[0]"u8));

            jp.Append("$.x.y[1].z.a"u8, "value4");

            Assert.AreEqual("{\"y\":[{\"z\":{\"a\":[\"value1\",\"value2\"]}},{\"z\":{\"a\":[\"value3\",\"value4\"]}}]}", jp.GetJson("$.x"u8).ToString());
            Assert.AreEqual("[{\"z\":{\"a\":[\"value1\",\"value2\"]}},{\"z\":{\"a\":[\"value3\",\"value4\"]}}]", jp.GetJson("$.x.y"u8).ToString());
            Assert.AreEqual("{\"z\":{\"a\":[\"value1\",\"value2\"]}}", jp.GetJson("$.x.y[0]"u8).ToString());
            Assert.AreEqual("{\"a\":[\"value1\",\"value2\"]}", jp.GetJson("$.x.y[0].z"u8).ToString());
            Assert.AreEqual("[\"value1\",\"value2\"]", jp.GetJson("$.x.y[0].z.a"u8).ToString());
            Assert.AreEqual("value1", jp.GetString("$.x.y[0].z.a[0]"u8));
            Assert.AreEqual("value2", jp.GetString("$.x.y[0].z.a[1]"u8));
            Assert.AreEqual("{\"z\":{\"a\":[\"value3\",\"value4\"]}}", jp.GetJson("$.x.y[1]"u8).ToString());
            Assert.AreEqual("{\"a\":[\"value3\",\"value4\"]}", jp.GetJson("$.x.y[1].z"u8).ToString());
            Assert.AreEqual("[\"value3\",\"value4\"]", jp.GetJson("$.x.y[1].z.a"u8).ToString());
            Assert.AreEqual("value3", jp.GetString("$.x.y[1].z.a[0]"u8));
            Assert.AreEqual("value4", jp.GetString("$.x.y[1].z.a[1]"u8));

            jp.Append("$.x.y"u8, "{\"z\":{\"a\":[\"value5\"]}}"u8);

            Assert.AreEqual("{\"y\":[{\"z\":{\"a\":[\"value1\",\"value2\"]}},{\"z\":{\"a\":[\"value3\",\"value4\"]}},{\"z\":{\"a\":[\"value5\"]}}]}", jp.GetJson("$.x"u8).ToString());
            Assert.AreEqual("[{\"z\":{\"a\":[\"value1\",\"value2\"]}},{\"z\":{\"a\":[\"value3\",\"value4\"]}},{\"z\":{\"a\":[\"value5\"]}}]", jp.GetJson("$.x.y"u8).ToString());
            Assert.AreEqual("{\"z\":{\"a\":[\"value1\",\"value2\"]}}", jp.GetJson("$.x.y[0]"u8).ToString());
            Assert.AreEqual("{\"a\":[\"value1\",\"value2\"]}", jp.GetJson("$.x.y[0].z"u8).ToString());
            Assert.AreEqual("[\"value1\",\"value2\"]", jp.GetJson("$.x.y[0].z.a"u8).ToString());
            Assert.AreEqual("value1", jp.GetString("$.x.y[0].z.a[0]"u8));
            Assert.AreEqual("value2", jp.GetString("$.x.y[0].z.a[1]"u8));
            Assert.AreEqual("{\"z\":{\"a\":[\"value3\",\"value4\"]}}", jp.GetJson("$.x.y[1]"u8).ToString());
            Assert.AreEqual("{\"a\":[\"value3\",\"value4\"]}", jp.GetJson("$.x.y[1].z"u8).ToString());
            Assert.AreEqual("[\"value3\",\"value4\"]", jp.GetJson("$.x.y[1].z.a"u8).ToString());
            Assert.AreEqual("value3", jp.GetString("$.x.y[1].z.a[0]"u8));
            Assert.AreEqual("value4", jp.GetString("$.x.y[1].z.a[1]"u8));
            Assert.AreEqual("{\"z\":{\"a\":[\"value5\"]}}", jp.GetJson("$.x.y[2]"u8).ToString());
            Assert.AreEqual("{\"a\":[\"value5\"]}", jp.GetJson("$.x.y[2].z"u8).ToString());
            Assert.AreEqual("[\"value5\"]", jp.GetJson("$.x.y[2].z.a"u8).ToString());
            Assert.AreEqual("value5", jp.GetString("$.x.y[2].z.a[0]"u8));

            Assert.AreEqual("{\"x\":{\"y\":[{\"z\":{\"a\":[\"value1\",\"value2\"]}},{\"z\":{\"a\":[\"value3\",\"value4\"]}},{\"z\":{\"a\":[\"value5\"]}}]}}", GetJsonString(jp));
        }

        [Test]
        public void ArrayIndex_RootAndInsert_TwoLevel_WithProperty()
        {
            JsonPatch jp = new("{\"x\":{\"y\":[{\"a\":\"value1\"},{\"a\":\"value2\"}]}}"u8.ToArray());

            Assert.AreEqual("{\"y\":[{\"a\":\"value1\"},{\"a\":\"value2\"}]}", jp.GetJson("$.x"u8).ToString());
            Assert.AreEqual("[{\"a\":\"value1\"},{\"a\":\"value2\"}]", jp.GetJson("$.x.y"u8).ToString());
            Assert.AreEqual("{\"a\":\"value1\"}", jp.GetJson("$.x.y[0]"u8).ToString());
            Assert.AreEqual("value1", jp.GetString("$.x.y[0].a"u8));
            Assert.AreEqual("{\"a\":\"value2\"}", jp.GetJson("$.x.y[1]"u8).ToString());
            Assert.AreEqual("value2", jp.GetString("$.x.y[1].a"u8));

            jp.Append("$.x.y"u8, "{\"a\":\"value3\"}"u8);

            Assert.AreEqual("{\"y\":[{\"a\":\"value1\"},{\"a\":\"value2\"}]}", jp.GetJson("$.x"u8).ToString());
            Assert.AreEqual("[{\"a\":\"value1\"},{\"a\":\"value2\"},{\"a\":\"value3\"}]", jp.GetJson("$.x.y"u8).ToString());
            Assert.AreEqual("{\"a\":\"value1\"}", jp.GetJson("$.x.y[0]"u8).ToString());
            Assert.AreEqual("value1", jp.GetString("$.x.y[0].a"u8));
            Assert.AreEqual("{\"a\":\"value2\"}", jp.GetJson("$.x.y[1]"u8).ToString());
            Assert.AreEqual("value2", jp.GetString("$.x.y[1].a"u8));
            Assert.AreEqual("{\"a\":\"value3\"}", jp.GetJson("$.x.y[2]"u8).ToString());
            Assert.AreEqual("value3", jp.GetString("$.x.y[2].a"u8));

            jp.Append("$.x.y"u8, "{\"a\":\"value4\"}"u8);

            Assert.AreEqual("{\"y\":[{\"a\":\"value1\"},{\"a\":\"value2\"}]}", jp.GetJson("$.x"u8).ToString());
            Assert.AreEqual("[{\"a\":\"value1\"},{\"a\":\"value2\"},{\"a\":\"value3\"},{\"a\":\"value4\"}]", jp.GetJson("$.x.y"u8).ToString());
            Assert.AreEqual("{\"a\":\"value1\"}", jp.GetJson("$.x.y[0]"u8).ToString());
            Assert.AreEqual("value1", jp.GetString("$.x.y[0].a"u8));
            Assert.AreEqual("{\"a\":\"value2\"}", jp.GetJson("$.x.y[1]"u8).ToString());
            Assert.AreEqual("value2", jp.GetString("$.x.y[1].a"u8));
            Assert.AreEqual("{\"a\":\"value3\"}", jp.GetJson("$.x.y[2]"u8).ToString());
            Assert.AreEqual("value3", jp.GetString("$.x.y[2].a"u8));
            Assert.AreEqual("{\"a\":\"value4\"}", jp.GetJson("$.x.y[3]"u8).ToString());
            Assert.AreEqual("value4", jp.GetString("$.x.y[3].a"u8));

            Assert.AreEqual("{\"x\":{\"y\":[{\"a\":\"value1\"},{\"a\":\"value2\"},{\"a\":\"value3\"},{\"a\":\"value4\"}]}}", GetJsonString(jp));
        }

        [Test]
        public void ArrayIndex_RootAndInsert_TwoLevel()
        {
            JsonPatch jp = new("{\"x\":{\"y\":[\"value1\",\"value2\"]}}"u8.ToArray());

            Assert.AreEqual("{\"y\":[\"value1\",\"value2\"]}", jp.GetJson("$.x"u8).ToString());
            Assert.AreEqual("[\"value1\",\"value2\"]", jp.GetJson("$.x.y"u8).ToString());
            Assert.AreEqual("value1", jp.GetString("$.x.y[0]"u8));
            Assert.AreEqual("value2", jp.GetString("$.x.y[1]"u8));

            jp.Append("$.x.y"u8, "value3");

            Assert.AreEqual("{\"y\":[\"value1\",\"value2\"]}", jp.GetJson("$.x"u8).ToString());
            Assert.AreEqual("[\"value1\",\"value2\",\"value3\"]", jp.GetJson("$.x.y"u8).ToString());
            Assert.AreEqual("value1", jp.GetString("$.x.y[0]"u8));
            Assert.AreEqual("value2", jp.GetString("$.x.y[1]"u8));
            Assert.AreEqual("value3", jp.GetString("$.x.y[2]"u8));

            jp.Append("$.x.y"u8, "value4");

            Assert.AreEqual("{\"y\":[\"value1\",\"value2\"]}", jp.GetJson("$.x"u8).ToString());
            Assert.AreEqual("[\"value1\",\"value2\",\"value3\",\"value4\"]", jp.GetJson("$.x.y"u8).ToString());
            Assert.AreEqual("value1", jp.GetString("$.x.y[0]"u8));
            Assert.AreEqual("value2", jp.GetString("$.x.y[1]"u8));
            Assert.AreEqual("value3", jp.GetString("$.x.y[2]"u8));
            Assert.AreEqual("value4", jp.GetString("$.x.y[3]"u8));

            Assert.AreEqual("{\"x\":{\"y\":[\"value1\",\"value2\",\"value3\",\"value4\"]}}", GetJsonString(jp));
        }

        [Test]
        public void ArrayIndex_Insert_TwoLevel_WithProperty()
        {
            JsonPatch jp = new();

            jp.Append("$.x.y"u8, "{\"a\":\"value1\"}"u8);

            Assert.AreEqual("{\"y\":[{\"a\":\"value1\"}]}", jp.GetJson("$.x"u8).ToString());
            Assert.AreEqual("[{\"a\":\"value1\"}]", jp.GetJson("$.x.y"u8).ToString());
            Assert.AreEqual("{\"a\":\"value1\"}", jp.GetJson("$.x.y[0]"u8).ToString());
            Assert.AreEqual("value1", jp.GetString("$.x.y[0].a"u8));

            jp.Append("$.x.y"u8, "{\"a\":\"value2\"}"u8);

            Assert.AreEqual("{\"y\":[{\"a\":\"value1\"},{\"a\":\"value2\"}]}", jp.GetJson("$.x"u8).ToString());
            Assert.AreEqual("[{\"a\":\"value1\"},{\"a\":\"value2\"}]", jp.GetJson("$.x.y"u8).ToString());
            Assert.AreEqual("{\"a\":\"value1\"}", jp.GetJson("$.x.y[0]"u8).ToString());
            Assert.AreEqual("value1", jp.GetString("$.x.y[0].a"u8));
            Assert.AreEqual("{\"a\":\"value2\"}", jp.GetJson("$.x.y[1]"u8).ToString());
            Assert.AreEqual("value2", jp.GetString("$.x.y[1].a"u8));

            Assert.AreEqual("{\"x\":{\"y\":[{\"a\":\"value1\"},{\"a\":\"value2\"}]}}", GetJsonString(jp));
        }

        [Test]
        public void ArrayIndex_Insert_TwoLevel()
        {
            JsonPatch jp = new();

            jp.Append("$.x.y"u8, "value1");

            Assert.AreEqual("{\"y\":[\"value1\"]}", jp.GetJson("$.x"u8).ToString());
            Assert.AreEqual("[\"value1\"]", jp.GetJson("$.x.y"u8).ToString());
            Assert.AreEqual("value1", jp.GetString("$.x.y[0]"u8));

            jp.Append("$.x.y"u8, "value2");

            Assert.AreEqual("{\"y\":[\"value1\",\"value2\"]}", jp.GetJson("$.x"u8).ToString());
            Assert.AreEqual("[\"value1\",\"value2\"]", jp.GetJson("$.x.y"u8).ToString());
            Assert.AreEqual("value1", jp.GetString("$.x.y[0]"u8));
            Assert.AreEqual("value2", jp.GetString("$.x.y[1]"u8));

            Assert.AreEqual("{\"x\":{\"y\":[\"value1\",\"value2\"]}}", GetJsonString(jp));
        }

        [Test]
        public void ArrayIndex_RootAndInsert_OneLevelTwoLevel_WithProperty()
        {
            JsonPatch jp = new("{\"x\":[{\"y\":{\"z\":[{\"a\":\"value1\"},{\"a\":\"value2\"}]}},{\"y\":{\"z\":[{\"a\":\"value3\"},{\"a\":\"value4\"}]}}]}"u8.ToArray());

            Assert.AreEqual("[{\"y\":{\"z\":[{\"a\":\"value1\"},{\"a\":\"value2\"}]}},{\"y\":{\"z\":[{\"a\":\"value3\"},{\"a\":\"value4\"}]}}]", jp.GetJson("$.x"u8).ToString());
            Assert.AreEqual("{\"y\":{\"z\":[{\"a\":\"value1\"},{\"a\":\"value2\"}]}}", jp.GetJson("$.x[0]"u8).ToString());
            Assert.AreEqual("{\"z\":[{\"a\":\"value1\"},{\"a\":\"value2\"}]}", jp.GetJson("$.x[0].y"u8).ToString());
            Assert.AreEqual("[{\"a\":\"value1\"},{\"a\":\"value2\"}]", jp.GetJson("$.x[0].y.z"u8).ToString());
            Assert.AreEqual("{\"a\":\"value1\"}", jp.GetJson("$.x[0].y.z[0]"u8).ToString());
            Assert.AreEqual("value1", jp.GetString("$.x[0].y.z[0].a"u8));
            Assert.AreEqual("{\"a\":\"value2\"}", jp.GetJson("$.x[0].y.z[1]"u8).ToString());
            Assert.AreEqual("value2", jp.GetString("$.x[0].y.z[1].a"u8));
            Assert.AreEqual("{\"y\":{\"z\":[{\"a\":\"value3\"},{\"a\":\"value4\"}]}}", jp.GetJson("$.x[1]"u8).ToString());
            Assert.AreEqual("{\"z\":[{\"a\":\"value3\"},{\"a\":\"value4\"}]}", jp.GetJson("$.x[1].y"u8).ToString());
            Assert.AreEqual("[{\"a\":\"value3\"},{\"a\":\"value4\"}]", jp.GetJson("$.x[1].y.z"u8).ToString());
            Assert.AreEqual("{\"a\":\"value3\"}", jp.GetJson("$.x[1].y.z[0]"u8).ToString());
            Assert.AreEqual("value3", jp.GetString("$.x[1].y.z[0].a"u8));
            Assert.AreEqual("{\"a\":\"value4\"}", jp.GetJson("$.x[1].y.z[1]"u8).ToString());
            Assert.AreEqual("value4", jp.GetString("$.x[1].y.z[1].a"u8));

            jp.Append("$.x[0].y.z"u8, "{\"a\":\"value5\"}"u8);

            Assert.AreEqual("[{\"y\":{\"z\":[{\"a\":\"value1\"},{\"a\":\"value2\"}]}},{\"y\":{\"z\":[{\"a\":\"value3\"},{\"a\":\"value4\"}]}}]", jp.GetJson("$.x"u8).ToString());
            Assert.AreEqual("{\"y\":{\"z\":[{\"a\":\"value1\"},{\"a\":\"value2\"}]}}", jp.GetJson("$.x[0]"u8).ToString());
            Assert.AreEqual("{\"z\":[{\"a\":\"value1\"},{\"a\":\"value2\"}]}", jp.GetJson("$.x[0].y"u8).ToString());
            Assert.AreEqual("[{\"a\":\"value1\"},{\"a\":\"value2\"},{\"a\":\"value5\"}]", jp.GetJson("$.x[0].y.z"u8).ToString());
            Assert.AreEqual("{\"a\":\"value1\"}", jp.GetJson("$.x[0].y.z[0]"u8).ToString());
            Assert.AreEqual("value1", jp.GetString("$.x[0].y.z[0].a"u8));
            Assert.AreEqual("{\"a\":\"value2\"}", jp.GetJson("$.x[0].y.z[1]"u8).ToString());
            Assert.AreEqual("value2", jp.GetString("$.x[0].y.z[1].a"u8));
            Assert.AreEqual("{\"a\":\"value5\"}", jp.GetJson("$.x[0].y.z[2]"u8).ToString());
            Assert.AreEqual("value5", jp.GetString("$.x[0].y.z[2].a"u8));
            Assert.AreEqual("{\"y\":{\"z\":[{\"a\":\"value3\"},{\"a\":\"value4\"}]}}", jp.GetJson("$.x[1]"u8).ToString());
            Assert.AreEqual("{\"z\":[{\"a\":\"value3\"},{\"a\":\"value4\"}]}", jp.GetJson("$.x[1].y"u8).ToString());
            Assert.AreEqual("[{\"a\":\"value3\"},{\"a\":\"value4\"}]", jp.GetJson("$.x[1].y.z"u8).ToString());
            Assert.AreEqual("{\"a\":\"value3\"}", jp.GetJson("$.x[1].y.z[0]"u8).ToString());
            Assert.AreEqual("value3", jp.GetString("$.x[1].y.z[0].a"u8));
            Assert.AreEqual("{\"a\":\"value4\"}", jp.GetJson("$.x[1].y.z[1]"u8).ToString());
            Assert.AreEqual("value4", jp.GetString("$.x[1].y.z[1].a"u8));

            jp.Append("$.x[0].y.z"u8, "{\"a\":\"value6\"}"u8);

            Assert.AreEqual("[{\"y\":{\"z\":[{\"a\":\"value1\"},{\"a\":\"value2\"}]}},{\"y\":{\"z\":[{\"a\":\"value3\"},{\"a\":\"value4\"}]}}]", jp.GetJson("$.x"u8).ToString());
            Assert.AreEqual("{\"y\":{\"z\":[{\"a\":\"value1\"},{\"a\":\"value2\"}]}}", jp.GetJson("$.x[0]"u8).ToString());
            Assert.AreEqual("{\"z\":[{\"a\":\"value1\"},{\"a\":\"value2\"}]}", jp.GetJson("$.x[0].y"u8).ToString());
            Assert.AreEqual("[{\"a\":\"value1\"},{\"a\":\"value2\"},{\"a\":\"value5\"},{\"a\":\"value6\"}]", jp.GetJson("$.x[0].y.z"u8).ToString());
            Assert.AreEqual("{\"a\":\"value1\"}", jp.GetJson("$.x[0].y.z[0]"u8).ToString());
            Assert.AreEqual("value1", jp.GetString("$.x[0].y.z[0].a"u8));
            Assert.AreEqual("{\"a\":\"value2\"}", jp.GetJson("$.x[0].y.z[1]"u8).ToString());
            Assert.AreEqual("value2", jp.GetString("$.x[0].y.z[1].a"u8));
            Assert.AreEqual("{\"a\":\"value5\"}", jp.GetJson("$.x[0].y.z[2]"u8).ToString());
            Assert.AreEqual("value5", jp.GetString("$.x[0].y.z[2].a"u8));
            Assert.AreEqual("{\"a\":\"value6\"}", jp.GetJson("$.x[0].y.z[3]"u8).ToString());
            Assert.AreEqual("value6", jp.GetString("$.x[0].y.z[3].a"u8));
            Assert.AreEqual("{\"y\":{\"z\":[{\"a\":\"value3\"},{\"a\":\"value4\"}]}}", jp.GetJson("$.x[1]"u8).ToString());
            Assert.AreEqual("{\"z\":[{\"a\":\"value3\"},{\"a\":\"value4\"}]}", jp.GetJson("$.x[1].y"u8).ToString());
            Assert.AreEqual("[{\"a\":\"value3\"},{\"a\":\"value4\"}]", jp.GetJson("$.x[1].y.z"u8).ToString());
            Assert.AreEqual("{\"a\":\"value3\"}", jp.GetJson("$.x[1].y.z[0]"u8).ToString());
            Assert.AreEqual("value3", jp.GetString("$.x[1].y.z[0].a"u8));
            Assert.AreEqual("{\"a\":\"value4\"}", jp.GetJson("$.x[1].y.z[1]"u8).ToString());
            Assert.AreEqual("value4", jp.GetString("$.x[1].y.z[1].a"u8));

            jp.Append("$.x[1].y.z"u8, "{\"a\":\"value7\"}"u8);

            Assert.AreEqual("[{\"y\":{\"z\":[{\"a\":\"value1\"},{\"a\":\"value2\"}]}},{\"y\":{\"z\":[{\"a\":\"value3\"},{\"a\":\"value4\"}]}}]", jp.GetJson("$.x"u8).ToString());
            Assert.AreEqual("{\"y\":{\"z\":[{\"a\":\"value1\"},{\"a\":\"value2\"}]}}", jp.GetJson("$.x[0]"u8).ToString());
            Assert.AreEqual("{\"z\":[{\"a\":\"value1\"},{\"a\":\"value2\"}]}", jp.GetJson("$.x[0].y"u8).ToString());
            Assert.AreEqual("[{\"a\":\"value1\"},{\"a\":\"value2\"},{\"a\":\"value5\"},{\"a\":\"value6\"}]", jp.GetJson("$.x[0].y.z"u8).ToString());
            Assert.AreEqual("{\"a\":\"value1\"}", jp.GetJson("$.x[0].y.z[0]"u8).ToString());
            Assert.AreEqual("value1", jp.GetString("$.x[0].y.z[0].a"u8));
            Assert.AreEqual("{\"a\":\"value2\"}", jp.GetJson("$.x[0].y.z[1]"u8).ToString());
            Assert.AreEqual("value2", jp.GetString("$.x[0].y.z[1].a"u8));
            Assert.AreEqual("{\"a\":\"value5\"}", jp.GetJson("$.x[0].y.z[2]"u8).ToString());
            Assert.AreEqual("value5", jp.GetString("$.x[0].y.z[2].a"u8));
            Assert.AreEqual("{\"a\":\"value6\"}", jp.GetJson("$.x[0].y.z[3]"u8).ToString());
            Assert.AreEqual("value6", jp.GetString("$.x[0].y.z[3].a"u8));
            Assert.AreEqual("{\"y\":{\"z\":[{\"a\":\"value3\"},{\"a\":\"value4\"}]}}", jp.GetJson("$.x[1]"u8).ToString());
            Assert.AreEqual("{\"z\":[{\"a\":\"value3\"},{\"a\":\"value4\"}]}", jp.GetJson("$.x[1].y"u8).ToString());
            Assert.AreEqual("[{\"a\":\"value3\"},{\"a\":\"value4\"},{\"a\":\"value7\"}]", jp.GetJson("$.x[1].y.z"u8).ToString());
            Assert.AreEqual("{\"a\":\"value3\"}", jp.GetJson("$.x[1].y.z[0]"u8).ToString());
            Assert.AreEqual("value3", jp.GetString("$.x[1].y.z[0].a"u8));
            Assert.AreEqual("{\"a\":\"value4\"}", jp.GetJson("$.x[1].y.z[1]"u8).ToString());
            Assert.AreEqual("value4", jp.GetString("$.x[1].y.z[1].a"u8));
            Assert.AreEqual("{\"a\":\"value7\"}", jp.GetJson("$.x[1].y.z[2]"u8).ToString());
            Assert.AreEqual("value7", jp.GetString("$.x[1].y.z[2].a"u8));

            jp.Append("$.x[1].y.z"u8, "{\"a\":\"value8\"}"u8);

            Assert.AreEqual("[{\"y\":{\"z\":[{\"a\":\"value1\"},{\"a\":\"value2\"}]}},{\"y\":{\"z\":[{\"a\":\"value3\"},{\"a\":\"value4\"}]}}]", jp.GetJson("$.x"u8).ToString());
            Assert.AreEqual("{\"y\":{\"z\":[{\"a\":\"value1\"},{\"a\":\"value2\"}]}}", jp.GetJson("$.x[0]"u8).ToString());
            Assert.AreEqual("{\"z\":[{\"a\":\"value1\"},{\"a\":\"value2\"}]}", jp.GetJson("$.x[0].y"u8).ToString());
            Assert.AreEqual("[{\"a\":\"value1\"},{\"a\":\"value2\"},{\"a\":\"value5\"},{\"a\":\"value6\"}]", jp.GetJson("$.x[0].y.z"u8).ToString());
            Assert.AreEqual("{\"a\":\"value1\"}", jp.GetJson("$.x[0].y.z[0]"u8).ToString());
            Assert.AreEqual("value1", jp.GetString("$.x[0].y.z[0].a"u8));
            Assert.AreEqual("{\"a\":\"value2\"}", jp.GetJson("$.x[0].y.z[1]"u8).ToString());
            Assert.AreEqual("value2", jp.GetString("$.x[0].y.z[1].a"u8));
            Assert.AreEqual("{\"a\":\"value5\"}", jp.GetJson("$.x[0].y.z[2]"u8).ToString());
            Assert.AreEqual("value5", jp.GetString("$.x[0].y.z[2].a"u8));
            Assert.AreEqual("{\"a\":\"value6\"}", jp.GetJson("$.x[0].y.z[3]"u8).ToString());
            Assert.AreEqual("value6", jp.GetString("$.x[0].y.z[3].a"u8));
            Assert.AreEqual("{\"y\":{\"z\":[{\"a\":\"value3\"},{\"a\":\"value4\"}]}}", jp.GetJson("$.x[1]"u8).ToString());
            Assert.AreEqual("{\"z\":[{\"a\":\"value3\"},{\"a\":\"value4\"}]}", jp.GetJson("$.x[1].y"u8).ToString());
            Assert.AreEqual("[{\"a\":\"value3\"},{\"a\":\"value4\"},{\"a\":\"value7\"},{\"a\":\"value8\"}]", jp.GetJson("$.x[1].y.z"u8).ToString());
            Assert.AreEqual("{\"a\":\"value3\"}", jp.GetJson("$.x[1].y.z[0]"u8).ToString());
            Assert.AreEqual("value3", jp.GetString("$.x[1].y.z[0].a"u8));
            Assert.AreEqual("{\"a\":\"value4\"}", jp.GetJson("$.x[1].y.z[1]"u8).ToString());
            Assert.AreEqual("value4", jp.GetString("$.x[1].y.z[1].a"u8));
            Assert.AreEqual("{\"a\":\"value7\"}", jp.GetJson("$.x[1].y.z[2]"u8).ToString());
            Assert.AreEqual("value7", jp.GetString("$.x[1].y.z[2].a"u8));
            Assert.AreEqual("{\"a\":\"value8\"}", jp.GetJson("$.x[1].y.z[3]"u8).ToString());
            Assert.AreEqual("value8", jp.GetString("$.x[1].y.z[3].a"u8));

            jp.Append("$.x"u8, "{\"y\":{\"z\":[{\"a\":\"value9\"}]}}"u8);

            Assert.AreEqual("[{\"y\":{\"z\":[{\"a\":\"value1\"},{\"a\":\"value2\"}]}},{\"y\":{\"z\":[{\"a\":\"value3\"},{\"a\":\"value4\"}]}},{\"y\":{\"z\":[{\"a\":\"value9\"}]}}]", jp.GetJson("$.x"u8).ToString());
            Assert.AreEqual("{\"y\":{\"z\":[{\"a\":\"value1\"},{\"a\":\"value2\"}]}}", jp.GetJson("$.x[0]"u8).ToString());
            Assert.AreEqual("{\"z\":[{\"a\":\"value1\"},{\"a\":\"value2\"}]}", jp.GetJson("$.x[0].y"u8).ToString());
            Assert.AreEqual("[{\"a\":\"value1\"},{\"a\":\"value2\"},{\"a\":\"value5\"},{\"a\":\"value6\"}]", jp.GetJson("$.x[0].y.z"u8).ToString());
            Assert.AreEqual("{\"a\":\"value1\"}", jp.GetJson("$.x[0].y.z[0]"u8).ToString());
            Assert.AreEqual("value1", jp.GetString("$.x[0].y.z[0].a"u8));
            Assert.AreEqual("{\"a\":\"value2\"}", jp.GetJson("$.x[0].y.z[1]"u8).ToString());
            Assert.AreEqual("value2", jp.GetString("$.x[0].y.z[1].a"u8));
            Assert.AreEqual("{\"a\":\"value5\"}", jp.GetJson("$.x[0].y.z[2]"u8).ToString());
            Assert.AreEqual("value5", jp.GetString("$.x[0].y.z[2].a"u8));
            Assert.AreEqual("{\"a\":\"value6\"}", jp.GetJson("$.x[0].y.z[3]"u8).ToString());
            Assert.AreEqual("value6", jp.GetString("$.x[0].y.z[3].a"u8));
            Assert.AreEqual("{\"y\":{\"z\":[{\"a\":\"value3\"},{\"a\":\"value4\"}]}}", jp.GetJson("$.x[1]"u8).ToString());
            Assert.AreEqual("{\"z\":[{\"a\":\"value3\"},{\"a\":\"value4\"}]}", jp.GetJson("$.x[1].y"u8).ToString());
            Assert.AreEqual("[{\"a\":\"value3\"},{\"a\":\"value4\"},{\"a\":\"value7\"},{\"a\":\"value8\"}]", jp.GetJson("$.x[1].y.z"u8).ToString());
            Assert.AreEqual("{\"a\":\"value3\"}", jp.GetJson("$.x[1].y.z[0]"u8).ToString());
            Assert.AreEqual("value3", jp.GetString("$.x[1].y.z[0].a"u8));
            Assert.AreEqual("{\"a\":\"value4\"}", jp.GetJson("$.x[1].y.z[1]"u8).ToString());
            Assert.AreEqual("value4", jp.GetString("$.x[1].y.z[1].a"u8));
            Assert.AreEqual("{\"a\":\"value7\"}", jp.GetJson("$.x[1].y.z[2]"u8).ToString());
            Assert.AreEqual("value7", jp.GetString("$.x[1].y.z[2].a"u8));
            Assert.AreEqual("{\"a\":\"value8\"}", jp.GetJson("$.x[1].y.z[3]"u8).ToString());
            Assert.AreEqual("value8", jp.GetString("$.x[1].y.z[3].a"u8));
            Assert.AreEqual("{\"y\":{\"z\":[{\"a\":\"value9\"}]}}", jp.GetJson("$.x[2]"u8).ToString());
            Assert.AreEqual("{\"z\":[{\"a\":\"value9\"}]}", jp.GetJson("$.x[2].y"u8).ToString());
            Assert.AreEqual("[{\"a\":\"value9\"}]", jp.GetJson("$.x[2].y.z"u8).ToString());
            Assert.AreEqual("{\"a\":\"value9\"}", jp.GetJson("$.x[2].y.z[0]"u8).ToString());
            Assert.AreEqual("value9", jp.GetString("$.x[2].y.z[0].a"u8));

            Assert.AreEqual("{\"x\":[{\"y\":{\"z\":[{\"a\":\"value1\"},{\"a\":\"value2\"},{\"a\":\"value5\"},{\"a\":\"value6\"}]}},{\"y\":{\"z\":[{\"a\":\"value3\"},{\"a\":\"value4\"},{\"a\":\"value7\"},{\"a\":\"value8\"}]}},{\"y\":{\"z\":[{\"a\":\"value9\"}]}}]}", GetJsonString(jp));
        }

        [Test]
        public void ArrayIndex_RootAndInsert_OneLevelTwoLevel()
        {
            JsonPatch jp = new("{\"x\":[{\"y\":{\"z\":[\"value1\",\"value2\"]}},{\"y\":{\"z\":[\"value3\",\"value4\"]}}]}"u8.ToArray());

            Assert.AreEqual("[{\"y\":{\"z\":[\"value1\",\"value2\"]}},{\"y\":{\"z\":[\"value3\",\"value4\"]}}]", jp.GetJson("$.x"u8).ToString());
            Assert.AreEqual("{\"y\":{\"z\":[\"value1\",\"value2\"]}}", jp.GetJson("$.x[0]"u8).ToString());
            Assert.AreEqual("{\"z\":[\"value1\",\"value2\"]}", jp.GetJson("$.x[0].y"u8).ToString());
            Assert.AreEqual("[\"value1\",\"value2\"]", jp.GetJson("$.x[0].y.z"u8).ToString());
            Assert.AreEqual("value1", jp.GetString("$.x[0].y.z[0]"u8));
            Assert.AreEqual("value2", jp.GetString("$.x[0].y.z[1]"u8));
            Assert.AreEqual("{\"y\":{\"z\":[\"value3\",\"value4\"]}}", jp.GetJson("$.x[1]"u8).ToString());
            Assert.AreEqual("{\"z\":[\"value3\",\"value4\"]}", jp.GetJson("$.x[1].y"u8).ToString());
            Assert.AreEqual("[\"value3\",\"value4\"]", jp.GetJson("$.x[1].y.z"u8).ToString());
            Assert.AreEqual("value3", jp.GetString("$.x[1].y.z[0]"u8));
            Assert.AreEqual("value4", jp.GetString("$.x[1].y.z[1]"u8));

            jp.Append("$.x[0].y.z"u8, "value5");

            Assert.AreEqual("[{\"y\":{\"z\":[\"value1\",\"value2\"]}},{\"y\":{\"z\":[\"value3\",\"value4\"]}}]", jp.GetJson("$.x"u8).ToString());
            Assert.AreEqual("{\"y\":{\"z\":[\"value1\",\"value2\"]}}", jp.GetJson("$.x[0]"u8).ToString());
            Assert.AreEqual("{\"z\":[\"value1\",\"value2\"]}", jp.GetJson("$.x[0].y"u8).ToString());
            Assert.AreEqual("[\"value1\",\"value2\",\"value5\"]", jp.GetJson("$.x[0].y.z"u8).ToString());
            Assert.AreEqual("value1", jp.GetString("$.x[0].y.z[0]"u8));
            Assert.AreEqual("value2", jp.GetString("$.x[0].y.z[1]"u8));
            Assert.AreEqual("value5", jp.GetString("$.x[0].y.z[2]"u8));
            Assert.AreEqual("{\"y\":{\"z\":[\"value3\",\"value4\"]}}", jp.GetJson("$.x[1]"u8).ToString());
            Assert.AreEqual("{\"z\":[\"value3\",\"value4\"]}", jp.GetJson("$.x[1].y"u8).ToString());
            Assert.AreEqual("[\"value3\",\"value4\"]", jp.GetJson("$.x[1].y.z"u8).ToString());
            Assert.AreEqual("value3", jp.GetString("$.x[1].y.z[0]"u8));
            Assert.AreEqual("value4", jp.GetString("$.x[1].y.z[1]"u8));

            jp.Append("$.x[0].y.z"u8, "value6");

            Assert.AreEqual("[{\"y\":{\"z\":[\"value1\",\"value2\"]}},{\"y\":{\"z\":[\"value3\",\"value4\"]}}]", jp.GetJson("$.x"u8).ToString());
            Assert.AreEqual("{\"y\":{\"z\":[\"value1\",\"value2\"]}}", jp.GetJson("$.x[0]"u8).ToString());
            Assert.AreEqual("{\"z\":[\"value1\",\"value2\"]}", jp.GetJson("$.x[0].y"u8).ToString());
            Assert.AreEqual("[\"value1\",\"value2\",\"value5\",\"value6\"]", jp.GetJson("$.x[0].y.z"u8).ToString());
            Assert.AreEqual("value1", jp.GetString("$.x[0].y.z[0]"u8));
            Assert.AreEqual("value2", jp.GetString("$.x[0].y.z[1]"u8));
            Assert.AreEqual("value5", jp.GetString("$.x[0].y.z[2]"u8));
            Assert.AreEqual("value6", jp.GetString("$.x[0].y.z[3]"u8));
            Assert.AreEqual("{\"y\":{\"z\":[\"value3\",\"value4\"]}}", jp.GetJson("$.x[1]"u8).ToString());
            Assert.AreEqual("{\"z\":[\"value3\",\"value4\"]}", jp.GetJson("$.x[1].y"u8).ToString());
            Assert.AreEqual("[\"value3\",\"value4\"]", jp.GetJson("$.x[1].y.z"u8).ToString());
            Assert.AreEqual("value3", jp.GetString("$.x[1].y.z[0]"u8));
            Assert.AreEqual("value4", jp.GetString("$.x[1].y.z[1]"u8));

            jp.Append("$.x[1].y.z"u8, "value7");

            Assert.AreEqual("[{\"y\":{\"z\":[\"value1\",\"value2\"]}},{\"y\":{\"z\":[\"value3\",\"value4\"]}}]", jp.GetJson("$.x"u8).ToString());
            Assert.AreEqual("{\"y\":{\"z\":[\"value1\",\"value2\"]}}", jp.GetJson("$.x[0]"u8).ToString());
            Assert.AreEqual("{\"z\":[\"value1\",\"value2\"]}", jp.GetJson("$.x[0].y"u8).ToString());
            Assert.AreEqual("[\"value1\",\"value2\",\"value5\",\"value6\"]", jp.GetJson("$.x[0].y.z"u8).ToString());
            Assert.AreEqual("value1", jp.GetString("$.x[0].y.z[0]"u8));
            Assert.AreEqual("value2", jp.GetString("$.x[0].y.z[1]"u8));
            Assert.AreEqual("value5", jp.GetString("$.x[0].y.z[2]"u8));
            Assert.AreEqual("value6", jp.GetString("$.x[0].y.z[3]"u8));
            Assert.AreEqual("{\"y\":{\"z\":[\"value3\",\"value4\"]}}", jp.GetJson("$.x[1]"u8).ToString());
            Assert.AreEqual("{\"z\":[\"value3\",\"value4\"]}", jp.GetJson("$.x[1].y"u8).ToString());
            Assert.AreEqual("[\"value3\",\"value4\",\"value7\"]", jp.GetJson("$.x[1].y.z"u8).ToString());
            Assert.AreEqual("value3", jp.GetString("$.x[1].y.z[0]"u8));
            Assert.AreEqual("value4", jp.GetString("$.x[1].y.z[1]"u8));
            Assert.AreEqual("value7", jp.GetString("$.x[1].y.z[2]"u8));

            jp.Append("$.x[1].y.z"u8, "value8");

            Assert.AreEqual("[{\"y\":{\"z\":[\"value1\",\"value2\"]}},{\"y\":{\"z\":[\"value3\",\"value4\"]}}]", jp.GetJson("$.x"u8).ToString());
            Assert.AreEqual("{\"y\":{\"z\":[\"value1\",\"value2\"]}}", jp.GetJson("$.x[0]"u8).ToString());
            Assert.AreEqual("{\"z\":[\"value1\",\"value2\"]}", jp.GetJson("$.x[0].y"u8).ToString());
            Assert.AreEqual("[\"value1\",\"value2\",\"value5\",\"value6\"]", jp.GetJson("$.x[0].y.z"u8).ToString());
            Assert.AreEqual("value1", jp.GetString("$.x[0].y.z[0]"u8));
            Assert.AreEqual("value2", jp.GetString("$.x[0].y.z[1]"u8));
            Assert.AreEqual("value5", jp.GetString("$.x[0].y.z[2]"u8));
            Assert.AreEqual("value6", jp.GetString("$.x[0].y.z[3]"u8));
            Assert.AreEqual("{\"y\":{\"z\":[\"value3\",\"value4\"]}}", jp.GetJson("$.x[1]"u8).ToString());
            Assert.AreEqual("{\"z\":[\"value3\",\"value4\"]}", jp.GetJson("$.x[1].y"u8).ToString());
            Assert.AreEqual("[\"value3\",\"value4\",\"value7\",\"value8\"]", jp.GetJson("$.x[1].y.z"u8).ToString());
            Assert.AreEqual("value3", jp.GetString("$.x[1].y.z[0]"u8));
            Assert.AreEqual("value4", jp.GetString("$.x[1].y.z[1]"u8));
            Assert.AreEqual("value7", jp.GetString("$.x[1].y.z[2]"u8));
            Assert.AreEqual("value8", jp.GetString("$.x[1].y.z[3]"u8));

            jp.Append("$.x"u8, "{\"y\":{\"z\":[\"value9\"]}}"u8);

            Assert.AreEqual("[{\"y\":{\"z\":[\"value1\",\"value2\"]}},{\"y\":{\"z\":[\"value3\",\"value4\"]}},{\"y\":{\"z\":[\"value9\"]}}]", jp.GetJson("$.x"u8).ToString());
            Assert.AreEqual("{\"y\":{\"z\":[\"value1\",\"value2\"]}}", jp.GetJson("$.x[0]"u8).ToString());
            Assert.AreEqual("{\"z\":[\"value1\",\"value2\"]}", jp.GetJson("$.x[0].y"u8).ToString());
            Assert.AreEqual("[\"value1\",\"value2\",\"value5\",\"value6\"]", jp.GetJson("$.x[0].y.z"u8).ToString());
            Assert.AreEqual("value1", jp.GetString("$.x[0].y.z[0]"u8));
            Assert.AreEqual("value2", jp.GetString("$.x[0].y.z[1]"u8));
            Assert.AreEqual("value5", jp.GetString("$.x[0].y.z[2]"u8));
            Assert.AreEqual("value6", jp.GetString("$.x[0].y.z[3]"u8));
            Assert.AreEqual("{\"y\":{\"z\":[\"value3\",\"value4\"]}}", jp.GetJson("$.x[1]"u8).ToString());
            Assert.AreEqual("{\"z\":[\"value3\",\"value4\"]}", jp.GetJson("$.x[1].y"u8).ToString());
            Assert.AreEqual("[\"value3\",\"value4\",\"value7\",\"value8\"]", jp.GetJson("$.x[1].y.z"u8).ToString());
            Assert.AreEqual("value3", jp.GetString("$.x[1].y.z[0]"u8));
            Assert.AreEqual("value4", jp.GetString("$.x[1].y.z[1]"u8));
            Assert.AreEqual("value7", jp.GetString("$.x[1].y.z[2]"u8));
            Assert.AreEqual("value8", jp.GetString("$.x[1].y.z[3]"u8));
            Assert.AreEqual("{\"y\":{\"z\":[\"value9\"]}}", jp.GetJson("$.x[2]"u8).ToString());
            Assert.AreEqual("{\"z\":[\"value9\"]}", jp.GetJson("$.x[2].y"u8).ToString());
            Assert.AreEqual("[\"value9\"]", jp.GetJson("$.x[2].y.z"u8).ToString());
            Assert.AreEqual("value9", jp.GetString("$.x[2].y.z[0]"u8));

            Assert.AreEqual("{\"x\":[{\"y\":{\"z\":[\"value1\",\"value2\",\"value5\",\"value6\"]}},{\"y\":{\"z\":[\"value3\",\"value4\",\"value7\",\"value8\"]}},{\"y\":{\"z\":[\"value9\"]}}]}", GetJsonString(jp));
        }

        [Test]
        public void ArrayIndex_Insert_OneLevelTwoLevel_WithProperty()
        {
            JsonPatch jp = new();

            jp.Append("$.x[0].y.z"u8, "{\"a\":\"value1\"}"u8);

            Assert.AreEqual("[{\"y\":{\"z\":[{\"a\":\"value1\"}]}}]", jp.GetJson("$.x"u8).ToString());
            Assert.AreEqual("{\"y\":{\"z\":[{\"a\":\"value1\"}]}}", jp.GetJson("$.x[0]"u8).ToString());
            Assert.AreEqual("{\"z\":[{\"a\":\"value1\"}]}", jp.GetJson("$.x[0].y"u8).ToString());
            Assert.AreEqual("[{\"a\":\"value1\"}]", jp.GetJson("$.x[0].y.z"u8).ToString());
            Assert.AreEqual("{\"a\":\"value1\"}", jp.GetJson("$.x[0].y.z[0]"u8).ToString());
            Assert.AreEqual("value1", jp.GetString("$.x[0].y.z[0].a"u8));

            jp.Append("$.x[0].y.z"u8, "{\"a\":\"value2\"}"u8);

            Assert.AreEqual("[{\"y\":{\"z\":[{\"a\":\"value1\"},{\"a\":\"value2\"}]}}]", jp.GetJson("$.x"u8).ToString());
            Assert.AreEqual("{\"y\":{\"z\":[{\"a\":\"value1\"},{\"a\":\"value2\"}]}}", jp.GetJson("$.x[0]"u8).ToString());
            Assert.AreEqual("{\"z\":[{\"a\":\"value1\"},{\"a\":\"value2\"}]}", jp.GetJson("$.x[0].y"u8).ToString());
            Assert.AreEqual("[{\"a\":\"value1\"},{\"a\":\"value2\"}]", jp.GetJson("$.x[0].y.z"u8).ToString());
            Assert.AreEqual("{\"a\":\"value1\"}", jp.GetJson("$.x[0].y.z[0]"u8).ToString());
            Assert.AreEqual("value1", jp.GetString("$.x[0].y.z[0].a"u8));
            Assert.AreEqual("{\"a\":\"value2\"}", jp.GetJson("$.x[0].y.z[1]"u8).ToString());
            Assert.AreEqual("value2", jp.GetString("$.x[0].y.z[1].a"u8));

            jp.Append("$.x[1].y.z"u8, "{\"a\":\"value3\"}"u8);

            Assert.AreEqual("[{\"y\":{\"z\":[{\"a\":\"value1\"},{\"a\":\"value2\"}]}},{\"y\":{\"z\":[{\"a\":\"value3\"}]}}]", jp.GetJson("$.x"u8).ToString());
            Assert.AreEqual("{\"y\":{\"z\":[{\"a\":\"value1\"},{\"a\":\"value2\"}]}}", jp.GetJson("$.x[0]"u8).ToString());
            Assert.AreEqual("{\"z\":[{\"a\":\"value1\"},{\"a\":\"value2\"}]}", jp.GetJson("$.x[0].y"u8).ToString());
            Assert.AreEqual("[{\"a\":\"value1\"},{\"a\":\"value2\"}]", jp.GetJson("$.x[0].y.z"u8).ToString());
            Assert.AreEqual("{\"a\":\"value1\"}", jp.GetJson("$.x[0].y.z[0]"u8).ToString());
            Assert.AreEqual("value1", jp.GetString("$.x[0].y.z[0].a"u8));
            Assert.AreEqual("{\"a\":\"value2\"}", jp.GetJson("$.x[0].y.z[1]"u8).ToString());
            Assert.AreEqual("value2", jp.GetString("$.x[0].y.z[1].a"u8));
            Assert.AreEqual("{\"y\":{\"z\":[{\"a\":\"value3\"}]}}", jp.GetJson("$.x[1]"u8).ToString());
            Assert.AreEqual("{\"z\":[{\"a\":\"value3\"}]}", jp.GetJson("$.x[1].y"u8).ToString());
            Assert.AreEqual("[{\"a\":\"value3\"}]", jp.GetJson("$.x[1].y.z"u8).ToString());
            Assert.AreEqual("{\"a\":\"value3\"}", jp.GetJson("$.x[1].y.z[0]"u8).ToString());
            Assert.AreEqual("value3", jp.GetString("$.x[1].y.z[0].a"u8));

            jp.Append("$.x[1].y.z"u8, "{\"a\":\"value4\"}"u8);

            Assert.AreEqual("[{\"y\":{\"z\":[{\"a\":\"value1\"},{\"a\":\"value2\"}]}},{\"y\":{\"z\":[{\"a\":\"value3\"},{\"a\":\"value4\"}]}}]", jp.GetJson("$.x"u8).ToString());
            Assert.AreEqual("{\"y\":{\"z\":[{\"a\":\"value1\"},{\"a\":\"value2\"}]}}", jp.GetJson("$.x[0]"u8).ToString());
            Assert.AreEqual("{\"z\":[{\"a\":\"value1\"},{\"a\":\"value2\"}]}", jp.GetJson("$.x[0].y"u8).ToString());
            Assert.AreEqual("[{\"a\":\"value1\"},{\"a\":\"value2\"}]", jp.GetJson("$.x[0].y.z"u8).ToString());
            Assert.AreEqual("{\"a\":\"value1\"}", jp.GetJson("$.x[0].y.z[0]"u8).ToString());
            Assert.AreEqual("value1", jp.GetString("$.x[0].y.z[0].a"u8));
            Assert.AreEqual("{\"a\":\"value2\"}", jp.GetJson("$.x[0].y.z[1]"u8).ToString());
            Assert.AreEqual("value2", jp.GetString("$.x[0].y.z[1].a"u8));
            Assert.AreEqual("{\"y\":{\"z\":[{\"a\":\"value3\"},{\"a\":\"value4\"}]}}", jp.GetJson("$.x[1]"u8).ToString());
            Assert.AreEqual("{\"z\":[{\"a\":\"value3\"},{\"a\":\"value4\"}]}", jp.GetJson("$.x[1].y"u8).ToString());
            Assert.AreEqual("[{\"a\":\"value3\"},{\"a\":\"value4\"}]", jp.GetJson("$.x[1].y.z"u8).ToString());
            Assert.AreEqual("{\"a\":\"value3\"}", jp.GetJson("$.x[1].y.z[0]"u8).ToString());
            Assert.AreEqual("value3", jp.GetString("$.x[1].y.z[0].a"u8));
            Assert.AreEqual("{\"a\":\"value4\"}", jp.GetJson("$.x[1].y.z[1]"u8).ToString());
            Assert.AreEqual("value4", jp.GetString("$.x[1].y.z[1].a"u8));

            jp.Append("$.x"u8, "{\"y\":{\"z\":[{\"a\":\"value5\"}]}}"u8);

            Assert.AreEqual("[{\"y\":{\"z\":[{\"a\":\"value1\"},{\"a\":\"value2\"}]}},{\"y\":{\"z\":[{\"a\":\"value3\"},{\"a\":\"value4\"}]}},{\"y\":{\"z\":[{\"a\":\"value5\"}]}}]", jp.GetJson("$.x"u8).ToString());
            Assert.AreEqual("{\"y\":{\"z\":[{\"a\":\"value1\"},{\"a\":\"value2\"}]}}", jp.GetJson("$.x[0]"u8).ToString());
            Assert.AreEqual("{\"z\":[{\"a\":\"value1\"},{\"a\":\"value2\"}]}", jp.GetJson("$.x[0].y"u8).ToString());
            Assert.AreEqual("[{\"a\":\"value1\"},{\"a\":\"value2\"}]", jp.GetJson("$.x[0].y.z"u8).ToString());
            Assert.AreEqual("{\"a\":\"value1\"}", jp.GetJson("$.x[0].y.z[0]"u8).ToString());
            Assert.AreEqual("value1", jp.GetString("$.x[0].y.z[0].a"u8));
            Assert.AreEqual("{\"a\":\"value2\"}", jp.GetJson("$.x[0].y.z[1]"u8).ToString());
            Assert.AreEqual("value2", jp.GetString("$.x[0].y.z[1].a"u8));
            Assert.AreEqual("{\"y\":{\"z\":[{\"a\":\"value3\"},{\"a\":\"value4\"}]}}", jp.GetJson("$.x[1]"u8).ToString());
            Assert.AreEqual("{\"z\":[{\"a\":\"value3\"},{\"a\":\"value4\"}]}", jp.GetJson("$.x[1].y"u8).ToString());
            Assert.AreEqual("[{\"a\":\"value3\"},{\"a\":\"value4\"}]", jp.GetJson("$.x[1].y.z"u8).ToString());
            Assert.AreEqual("{\"a\":\"value3\"}", jp.GetJson("$.x[1].y.z[0]"u8).ToString());
            Assert.AreEqual("value3", jp.GetString("$.x[1].y.z[0].a"u8));
            Assert.AreEqual("{\"a\":\"value4\"}", jp.GetJson("$.x[1].y.z[1]"u8).ToString());
            Assert.AreEqual("value4", jp.GetString("$.x[1].y.z[1].a"u8));
            Assert.AreEqual("{\"y\":{\"z\":[{\"a\":\"value5\"}]}}", jp.GetJson("$.x[2]"u8).ToString());
            Assert.AreEqual("{\"z\":[{\"a\":\"value5\"}]}", jp.GetJson("$.x[2].y"u8).ToString());
            Assert.AreEqual("[{\"a\":\"value5\"}]", jp.GetJson("$.x[2].y.z"u8).ToString());
            Assert.AreEqual("{\"a\":\"value5\"}", jp.GetJson("$.x[2].y.z[0]"u8).ToString());
            Assert.AreEqual("value5", jp.GetString("$.x[2].y.z[0].a"u8));

            Assert.AreEqual("{\"x\":[{\"y\":{\"z\":[{\"a\":\"value1\"},{\"a\":\"value2\"}]}},{\"y\":{\"z\":[{\"a\":\"value3\"},{\"a\":\"value4\"}]}},{\"y\":{\"z\":[{\"a\":\"value5\"}]}}]}", GetJsonString(jp));
        }

        [Test]
        public void ArrayIndex_Insert_OneLevelTwoLevel()
        {
            JsonPatch jp = new();

            jp.Append("$.x[0].y.z"u8, "value1");

            Assert.AreEqual("[{\"y\":{\"z\":[\"value1\"]}}]", jp.GetJson("$.x"u8).ToString());
            Assert.AreEqual("{\"y\":{\"z\":[\"value1\"]}}", jp.GetJson("$.x[0]"u8).ToString());
            Assert.AreEqual("{\"z\":[\"value1\"]}", jp.GetJson("$.x[0].y"u8).ToString());
            Assert.AreEqual("[\"value1\"]", jp.GetJson("$.x[0].y.z"u8).ToString());
            Assert.AreEqual("value1", jp.GetString("$.x[0].y.z[0]"u8));

            jp.Append("$.x[0].y.z"u8, "value2");

            Assert.AreEqual("[{\"y\":{\"z\":[\"value1\",\"value2\"]}}]", jp.GetJson("$.x"u8).ToString());
            Assert.AreEqual("{\"y\":{\"z\":[\"value1\",\"value2\"]}}", jp.GetJson("$.x[0]"u8).ToString());
            Assert.AreEqual("{\"z\":[\"value1\",\"value2\"]}", jp.GetJson("$.x[0].y"u8).ToString());
            Assert.AreEqual("[\"value1\",\"value2\"]", jp.GetJson("$.x[0].y.z"u8).ToString());
            Assert.AreEqual("value1", jp.GetString("$.x[0].y.z[0]"u8));
            Assert.AreEqual("value2", jp.GetString("$.x[0].y.z[1]"u8));

            jp.Append("$.x[1].y.z"u8, "value3");

            Assert.AreEqual("[{\"y\":{\"z\":[\"value1\",\"value2\"]}},{\"y\":{\"z\":[\"value3\"]}}]", jp.GetJson("$.x"u8).ToString());
            Assert.AreEqual("{\"y\":{\"z\":[\"value1\",\"value2\"]}}", jp.GetJson("$.x[0]"u8).ToString());
            Assert.AreEqual("{\"z\":[\"value1\",\"value2\"]}", jp.GetJson("$.x[0].y"u8).ToString());
            Assert.AreEqual("[\"value1\",\"value2\"]", jp.GetJson("$.x[0].y.z"u8).ToString());
            Assert.AreEqual("value1", jp.GetString("$.x[0].y.z[0]"u8));
            Assert.AreEqual("value2", jp.GetString("$.x[0].y.z[1]"u8));
            Assert.AreEqual("{\"y\":{\"z\":[\"value3\"]}}", jp.GetJson("$.x[1]"u8).ToString());
            Assert.AreEqual("{\"z\":[\"value3\"]}", jp.GetJson("$.x[1].y"u8).ToString());
            Assert.AreEqual("[\"value3\"]", jp.GetJson("$.x[1].y.z"u8).ToString());
            Assert.AreEqual("value3", jp.GetString("$.x[1].y.z[0]"u8));

            jp.Append("$.x[1].y.z"u8, "value4");

            Assert.AreEqual("[{\"y\":{\"z\":[\"value1\",\"value2\"]}},{\"y\":{\"z\":[\"value3\",\"value4\"]}}]", jp.GetJson("$.x"u8).ToString());
            Assert.AreEqual("{\"y\":{\"z\":[\"value1\",\"value2\"]}}", jp.GetJson("$.x[0]"u8).ToString());
            Assert.AreEqual("{\"z\":[\"value1\",\"value2\"]}", jp.GetJson("$.x[0].y"u8).ToString());
            Assert.AreEqual("[\"value1\",\"value2\"]", jp.GetJson("$.x[0].y.z"u8).ToString());
            Assert.AreEqual("value1", jp.GetString("$.x[0].y.z[0]"u8));
            Assert.AreEqual("value2", jp.GetString("$.x[0].y.z[1]"u8));
            Assert.AreEqual("{\"y\":{\"z\":[\"value3\",\"value4\"]}}", jp.GetJson("$.x[1]"u8).ToString());
            Assert.AreEqual("{\"z\":[\"value3\",\"value4\"]}", jp.GetJson("$.x[1].y"u8).ToString());
            Assert.AreEqual("[\"value3\",\"value4\"]", jp.GetJson("$.x[1].y.z"u8).ToString());
            Assert.AreEqual("value3", jp.GetString("$.x[1].y.z[0]"u8));
            Assert.AreEqual("value4", jp.GetString("$.x[1].y.z[1]"u8));

            jp.Append("$.x"u8, "{\"y\":{\"z\":[\"value5\"]}}"u8);

            Assert.AreEqual("[{\"y\":{\"z\":[\"value1\",\"value2\"]}},{\"y\":{\"z\":[\"value3\",\"value4\"]}},{\"y\":{\"z\":[\"value5\"]}}]", jp.GetJson("$.x"u8).ToString());
            Assert.AreEqual("{\"y\":{\"z\":[\"value1\",\"value2\"]}}", jp.GetJson("$.x[0]"u8).ToString());
            Assert.AreEqual("{\"z\":[\"value1\",\"value2\"]}", jp.GetJson("$.x[0].y"u8).ToString());
            Assert.AreEqual("[\"value1\",\"value2\"]", jp.GetJson("$.x[0].y.z"u8).ToString());
            Assert.AreEqual("value1", jp.GetString("$.x[0].y.z[0]"u8));
            Assert.AreEqual("value2", jp.GetString("$.x[0].y.z[1]"u8));
            Assert.AreEqual("{\"y\":{\"z\":[\"value3\",\"value4\"]}}", jp.GetJson("$.x[1]"u8).ToString());
            Assert.AreEqual("{\"z\":[\"value3\",\"value4\"]}", jp.GetJson("$.x[1].y"u8).ToString());
            Assert.AreEqual("[\"value3\",\"value4\"]", jp.GetJson("$.x[1].y.z"u8).ToString());
            Assert.AreEqual("value3", jp.GetString("$.x[1].y.z[0]"u8));
            Assert.AreEqual("value4", jp.GetString("$.x[1].y.z[1]"u8));
            Assert.AreEqual("{\"y\":{\"z\":[\"value5\"]}}", jp.GetJson("$.x[2]"u8).ToString());
            Assert.AreEqual("{\"z\":[\"value5\"]}", jp.GetJson("$.x[2].y"u8).ToString());
            Assert.AreEqual("[\"value5\"]", jp.GetJson("$.x[2].y.z"u8).ToString());
            Assert.AreEqual("value5", jp.GetString("$.x[2].y.z[0]"u8));

            Assert.AreEqual("{\"x\":[{\"y\":{\"z\":[\"value1\",\"value2\"]}},{\"y\":{\"z\":[\"value3\",\"value4\"]}},{\"y\":{\"z\":[\"value5\"]}}]}", GetJsonString(jp));
        }

        [Test]
        public void ArrayItem_RootAndInsert_OneLevelTwice_WithProperty()
        {
            JsonPatch jp = new(new("{\"x\":[{\"y\":[{\"a\":\"value1\"},{\"a\":\"value2\"}]},{\"y\":[{\"a\":\"value3\"},{\"a\":\"value4\"}]}]}"u8.ToArray()));

            Assert.AreEqual("[{\"y\":[{\"a\":\"value1\"},{\"a\":\"value2\"}]},{\"y\":[{\"a\":\"value3\"},{\"a\":\"value4\"}]}]", jp.GetJson("$.x"u8).ToString());
            Assert.AreEqual("{\"y\":[{\"a\":\"value1\"},{\"a\":\"value2\"}]}", jp.GetJson("$.x[0]"u8).ToString());
            Assert.AreEqual("[{\"a\":\"value1\"},{\"a\":\"value2\"}]", jp.GetJson("$.x[0].y"u8).ToString());
            Assert.AreEqual("{\"a\":\"value1\"}", jp.GetJson("$.x[0].y[0]"u8).ToString());
            Assert.AreEqual("value1", jp.GetString("$.x[0].y[0].a"u8));
            Assert.AreEqual("{\"a\":\"value2\"}", jp.GetJson("$.x[0].y[1]"u8).ToString());
            Assert.AreEqual("value2", jp.GetString("$.x[0].y[1].a"u8));
            Assert.AreEqual("{\"y\":[{\"a\":\"value3\"},{\"a\":\"value4\"}]}", jp.GetJson("$.x[1]"u8).ToString());
            Assert.AreEqual("[{\"a\":\"value3\"},{\"a\":\"value4\"}]", jp.GetJson("$.x[1].y"u8).ToString());
            Assert.AreEqual("{\"a\":\"value3\"}", jp.GetJson("$.x[1].y[0]"u8).ToString());
            Assert.AreEqual("value3", jp.GetString("$.x[1].y[0].a"u8));
            Assert.AreEqual("{\"a\":\"value4\"}", jp.GetJson("$.x[1].y[1]"u8).ToString());
            Assert.AreEqual("value4", jp.GetString("$.x[1].y[1].a"u8));

            jp.Append("$.x[0].y"u8, "{\"a\":\"value5\"}"u8);

            // value5 won't exist because I have not inserted a patch for $.x therefore we just pull from root
            Assert.AreEqual("[{\"y\":[{\"a\":\"value1\"},{\"a\":\"value2\"}]},{\"y\":[{\"a\":\"value3\"},{\"a\":\"value4\"}]}]", jp.GetJson("$.x"u8).ToString());
            Assert.AreEqual("{\"y\":[{\"a\":\"value1\"},{\"a\":\"value2\"}]}", jp.GetJson("$.x[0]"u8).ToString());
            //I have done an insert on $.x[0].y so this will pull from the patch
            Assert.AreEqual("[{\"a\":\"value1\"},{\"a\":\"value2\"},{\"a\":\"value5\"}]", jp.GetJson("$.x[0].y"u8).ToString());
            Assert.AreEqual("{\"a\":\"value1\"}", jp.GetJson("$.x[0].y[0]"u8).ToString());
            Assert.AreEqual("value1", jp.GetString("$.x[0].y[0].a"u8));
            Assert.AreEqual("{\"a\":\"value2\"}", jp.GetJson("$.x[0].y[1]"u8).ToString());
            Assert.AreEqual("value2", jp.GetString("$.x[0].y[1].a"u8));
            Assert.AreEqual("{\"a\":\"value5\"}", jp.GetJson("$.x[0].y[2]"u8).ToString());
            Assert.AreEqual("value5", jp.GetString("$.x[0].y[2].a"u8));
            Assert.AreEqual("{\"y\":[{\"a\":\"value3\"},{\"a\":\"value4\"}]}", jp.GetJson("$.x[1]"u8).ToString());
            Assert.AreEqual("[{\"a\":\"value3\"},{\"a\":\"value4\"}]", jp.GetJson("$.x[1].y"u8).ToString());
            Assert.AreEqual("{\"a\":\"value3\"}", jp.GetJson("$.x[1].y[0]"u8).ToString());
            Assert.AreEqual("value3", jp.GetString("$.x[1].y[0].a"u8));
            Assert.AreEqual("{\"a\":\"value4\"}", jp.GetJson("$.x[1].y[1]"u8).ToString());
            Assert.AreEqual("value4", jp.GetString("$.x[1].y[1].a"u8));

            jp.Append("$.x[0].y"u8, "{\"a\":\"value6\"}"u8);

            Assert.AreEqual("[{\"y\":[{\"a\":\"value1\"},{\"a\":\"value2\"}]},{\"y\":[{\"a\":\"value3\"},{\"a\":\"value4\"}]}]", jp.GetJson("$.x"u8).ToString());
            Assert.AreEqual("{\"y\":[{\"a\":\"value1\"},{\"a\":\"value2\"}]}", jp.GetJson("$.x[0]"u8).ToString());
            Assert.AreEqual("[{\"a\":\"value1\"},{\"a\":\"value2\"},{\"a\":\"value5\"},{\"a\":\"value6\"}]", jp.GetJson("$.x[0].y"u8).ToString());
            Assert.AreEqual("{\"a\":\"value1\"}", jp.GetJson("$.x[0].y[0]"u8).ToString());
            Assert.AreEqual("value1", jp.GetString("$.x[0].y[0].a"u8));
            Assert.AreEqual("{\"a\":\"value2\"}", jp.GetJson("$.x[0].y[1]"u8).ToString());
            Assert.AreEqual("value2", jp.GetString("$.x[0].y[1].a"u8));
            Assert.AreEqual("{\"a\":\"value5\"}", jp.GetJson("$.x[0].y[2]"u8).ToString());
            Assert.AreEqual("value5", jp.GetString("$.x[0].y[2].a"u8));
            Assert.AreEqual("{\"a\":\"value6\"}", jp.GetJson("$.x[0].y[3]"u8).ToString());
            Assert.AreEqual("value6", jp.GetString("$.x[0].y[3].a"u8));
            Assert.AreEqual("{\"y\":[{\"a\":\"value3\"},{\"a\":\"value4\"}]}", jp.GetJson("$.x[1]"u8).ToString());
            Assert.AreEqual("[{\"a\":\"value3\"},{\"a\":\"value4\"}]", jp.GetJson("$.x[1].y"u8).ToString());
            Assert.AreEqual("{\"a\":\"value3\"}", jp.GetJson("$.x[1].y[0]"u8).ToString());
            Assert.AreEqual("value3", jp.GetString("$.x[1].y[0].a"u8));
            Assert.AreEqual("{\"a\":\"value4\"}", jp.GetJson("$.x[1].y[1]"u8).ToString());
            Assert.AreEqual("value4", jp.GetString("$.x[1].y[1].a"u8));

            jp.Append("$.x[1].y"u8, "{\"a\":\"value7\"}"u8);

            Assert.AreEqual("[{\"y\":[{\"a\":\"value1\"},{\"a\":\"value2\"}]},{\"y\":[{\"a\":\"value3\"},{\"a\":\"value4\"}]}]", jp.GetJson("$.x"u8).ToString());
            Assert.AreEqual("{\"y\":[{\"a\":\"value1\"},{\"a\":\"value2\"}]}", jp.GetJson("$.x[0]"u8).ToString());
            Assert.AreEqual("[{\"a\":\"value1\"},{\"a\":\"value2\"},{\"a\":\"value5\"},{\"a\":\"value6\"}]", jp.GetJson("$.x[0].y"u8).ToString());
            Assert.AreEqual("{\"a\":\"value1\"}", jp.GetJson("$.x[0].y[0]"u8).ToString());
            Assert.AreEqual("value1", jp.GetString("$.x[0].y[0].a"u8));
            Assert.AreEqual("{\"a\":\"value2\"}", jp.GetJson("$.x[0].y[1]"u8).ToString());
            Assert.AreEqual("value2", jp.GetString("$.x[0].y[1].a"u8));
            Assert.AreEqual("{\"a\":\"value5\"}", jp.GetJson("$.x[0].y[2]"u8).ToString());
            Assert.AreEqual("value5", jp.GetString("$.x[0].y[2].a"u8));
            Assert.AreEqual("{\"a\":\"value6\"}", jp.GetJson("$.x[0].y[3]"u8).ToString());
            Assert.AreEqual("value6", jp.GetString("$.x[0].y[3].a"u8));
            Assert.AreEqual("{\"y\":[{\"a\":\"value3\"},{\"a\":\"value4\"}]}", jp.GetJson("$.x[1]"u8).ToString());
            Assert.AreEqual("[{\"a\":\"value3\"},{\"a\":\"value4\"},{\"a\":\"value7\"}]", jp.GetJson("$.x[1].y"u8).ToString());
            Assert.AreEqual("{\"a\":\"value3\"}", jp.GetJson("$.x[1].y[0]"u8).ToString());
            Assert.AreEqual("value3", jp.GetString("$.x[1].y[0].a"u8));
            Assert.AreEqual("{\"a\":\"value4\"}", jp.GetJson("$.x[1].y[1]"u8).ToString());
            Assert.AreEqual("value4", jp.GetString("$.x[1].y[1].a"u8));
            Assert.AreEqual("{\"a\":\"value7\"}", jp.GetJson("$.x[1].y[2]"u8).ToString());
            Assert.AreEqual("value7", jp.GetString("$.x[1].y[2].a"u8));

            jp.Append("$.x[1].y"u8, "{\"a\":\"value8\"}"u8);

            Assert.AreEqual("[{\"y\":[{\"a\":\"value1\"},{\"a\":\"value2\"}]},{\"y\":[{\"a\":\"value3\"},{\"a\":\"value4\"}]}]", jp.GetJson("$.x"u8).ToString());
            Assert.AreEqual("{\"y\":[{\"a\":\"value1\"},{\"a\":\"value2\"}]}", jp.GetJson("$.x[0]"u8).ToString());
            Assert.AreEqual("[{\"a\":\"value1\"},{\"a\":\"value2\"},{\"a\":\"value5\"},{\"a\":\"value6\"}]", jp.GetJson("$.x[0].y"u8).ToString());
            Assert.AreEqual("{\"a\":\"value1\"}", jp.GetJson("$.x[0].y[0]"u8).ToString());
            Assert.AreEqual("value1", jp.GetString("$.x[0].y[0].a"u8));
            Assert.AreEqual("{\"a\":\"value2\"}", jp.GetJson("$.x[0].y[1]"u8).ToString());
            Assert.AreEqual("value2", jp.GetString("$.x[0].y[1].a"u8));
            Assert.AreEqual("{\"a\":\"value5\"}", jp.GetJson("$.x[0].y[2]"u8).ToString());
            Assert.AreEqual("value5", jp.GetString("$.x[0].y[2].a"u8));
            Assert.AreEqual("{\"a\":\"value6\"}", jp.GetJson("$.x[0].y[3]"u8).ToString());
            Assert.AreEqual("value6", jp.GetString("$.x[0].y[3].a"u8));
            Assert.AreEqual("{\"y\":[{\"a\":\"value3\"},{\"a\":\"value4\"}]}", jp.GetJson("$.x[1]"u8).ToString());
            Assert.AreEqual("[{\"a\":\"value3\"},{\"a\":\"value4\"},{\"a\":\"value7\"},{\"a\":\"value8\"}]", jp.GetJson("$.x[1].y"u8).ToString());
            Assert.AreEqual("{\"a\":\"value3\"}", jp.GetJson("$.x[1].y[0]"u8).ToString());
            Assert.AreEqual("value3", jp.GetString("$.x[1].y[0].a"u8));
            Assert.AreEqual("{\"a\":\"value4\"}", jp.GetJson("$.x[1].y[1]"u8).ToString());
            Assert.AreEqual("value4", jp.GetString("$.x[1].y[1].a"u8));
            Assert.AreEqual("{\"a\":\"value7\"}", jp.GetJson("$.x[1].y[2]"u8).ToString());
            Assert.AreEqual("value7", jp.GetString("$.x[1].y[2].a"u8));
            Assert.AreEqual("{\"a\":\"value8\"}", jp.GetJson("$.x[1].y[3]"u8).ToString());
            Assert.AreEqual("value8", jp.GetString("$.x[1].y[3].a"u8));

            Assert.AreEqual("{\"x\":[{\"y\":[{\"a\":\"value1\"},{\"a\":\"value2\"},{\"a\":\"value5\"},{\"a\":\"value6\"}]},{\"y\":[{\"a\":\"value3\"},{\"a\":\"value4\"},{\"a\":\"value7\"},{\"a\":\"value8\"}]}]}", GetJsonString(jp));

            jp.Append("$.x"u8, "{\"y\":[{\"a\":\"value9\"}]}"u8);

            Assert.AreEqual("[{\"y\":[{\"a\":\"value1\"},{\"a\":\"value2\"}]},{\"y\":[{\"a\":\"value3\"},{\"a\":\"value4\"}]},{\"y\":[{\"a\":\"value9\"}]}]", jp.GetJson("$.x"u8).ToString());
            Assert.AreEqual("{\"y\":[{\"a\":\"value1\"},{\"a\":\"value2\"}]}", jp.GetJson("$.x[0]"u8).ToString());
            Assert.AreEqual("[{\"a\":\"value1\"},{\"a\":\"value2\"},{\"a\":\"value5\"},{\"a\":\"value6\"}]", jp.GetJson("$.x[0].y"u8).ToString());
            Assert.AreEqual("{\"a\":\"value1\"}", jp.GetJson("$.x[0].y[0]"u8).ToString());
            Assert.AreEqual("value1", jp.GetString("$.x[0].y[0].a"u8));
            Assert.AreEqual("{\"a\":\"value2\"}", jp.GetJson("$.x[0].y[1]"u8).ToString());
            Assert.AreEqual("value2", jp.GetString("$.x[0].y[1].a"u8));
            Assert.AreEqual("{\"a\":\"value5\"}", jp.GetJson("$.x[0].y[2]"u8).ToString());
            Assert.AreEqual("value5", jp.GetString("$.x[0].y[2].a"u8));
            Assert.AreEqual("{\"a\":\"value6\"}", jp.GetJson("$.x[0].y[3]"u8).ToString());
            Assert.AreEqual("value6", jp.GetString("$.x[0].y[3].a"u8));
            Assert.AreEqual("{\"y\":[{\"a\":\"value3\"},{\"a\":\"value4\"}]}", jp.GetJson("$.x[1]"u8).ToString());
            Assert.AreEqual("[{\"a\":\"value3\"},{\"a\":\"value4\"},{\"a\":\"value7\"},{\"a\":\"value8\"}]", jp.GetJson("$.x[1].y"u8).ToString());
            Assert.AreEqual("{\"a\":\"value3\"}", jp.GetJson("$.x[1].y[0]"u8).ToString());
            Assert.AreEqual("value3", jp.GetString("$.x[1].y[0].a"u8));
            Assert.AreEqual("{\"a\":\"value4\"}", jp.GetJson("$.x[1].y[1]"u8).ToString());
            Assert.AreEqual("value4", jp.GetString("$.x[1].y[1].a"u8));
            Assert.AreEqual("{\"a\":\"value7\"}", jp.GetJson("$.x[1].y[2]"u8).ToString());
            Assert.AreEqual("value7", jp.GetString("$.x[1].y[2].a"u8));
            Assert.AreEqual("{\"a\":\"value8\"}", jp.GetJson("$.x[1].y[3]"u8).ToString());
            Assert.AreEqual("value8", jp.GetString("$.x[1].y[3].a"u8));
            Assert.AreEqual("{\"y\":[{\"a\":\"value9\"}]}", jp.GetJson("$.x[2]"u8).ToString());
            Assert.AreEqual("[{\"a\":\"value9\"}]", jp.GetJson("$.x[2].y"u8).ToString());
            Assert.AreEqual("{\"a\":\"value9\"}", jp.GetJson("$.x[2].y[0]"u8).ToString());
            Assert.AreEqual("value9", jp.GetString("$.x[2].y[0].a"u8));

            Assert.AreEqual("{\"x\":[{\"y\":[{\"a\":\"value1\"},{\"a\":\"value2\"},{\"a\":\"value5\"},{\"a\":\"value6\"}]},{\"y\":[{\"a\":\"value3\"},{\"a\":\"value4\"},{\"a\":\"value7\"},{\"a\":\"value8\"}]},{\"y\":[{\"a\":\"value9\"}]}]}", GetJsonString(jp));
        }

        [Test]
        public void ArrayItem_RootAndInsert_OneLevelTwice()
        {
            JsonPatch jp = new(new("{\"x\":[{\"y\":[\"value1\",\"value2\"]},{\"y\":[\"value3\",\"value4\"]}]}"u8.ToArray()));

            Assert.AreEqual("[{\"y\":[\"value1\",\"value2\"]},{\"y\":[\"value3\",\"value4\"]}]", jp.GetJson("$.x"u8).ToString());
            Assert.AreEqual("{\"y\":[\"value1\",\"value2\"]}", jp.GetJson("$.x[0]"u8).ToString());
            Assert.AreEqual("[\"value1\",\"value2\"]", jp.GetJson("$.x[0].y"u8).ToString());
            Assert.AreEqual("value1", jp.GetString("$.x[0].y[0]"u8));
            Assert.AreEqual("value2", jp.GetString("$.x[0].y[1]"u8));
            Assert.AreEqual("{\"y\":[\"value3\",\"value4\"]}", jp.GetJson("$.x[1]"u8).ToString());
            Assert.AreEqual("[\"value3\",\"value4\"]", jp.GetJson("$.x[1].y"u8).ToString());
            Assert.AreEqual("value3", jp.GetString("$.x[1].y[0]"u8));
            Assert.AreEqual("value4", jp.GetString("$.x[1].y[1]"u8));

            jp.Append("$.x[0].y"u8, "value5");

            // value5 won't exist because I have not inserted a patch for $.x therefore we just pull from root
            Assert.AreEqual("[{\"y\":[\"value1\",\"value2\"]},{\"y\":[\"value3\",\"value4\"]}]", jp.GetJson("$.x"u8).ToString());
            Assert.AreEqual("{\"y\":[\"value1\",\"value2\"]}", jp.GetJson("$.x[0]"u8).ToString());
            //I have done an insert on $.x[0].y so this will pull from the patch
            Assert.AreEqual("[\"value1\",\"value2\",\"value5\"]", jp.GetJson("$.x[0].y"u8).ToString());
            Assert.AreEqual("value1", jp.GetString("$.x[0].y[0]"u8));
            Assert.AreEqual("value2", jp.GetString("$.x[0].y[1]"u8));
            Assert.AreEqual("value5", jp.GetString("$.x[0].y[2]"u8));
            Assert.AreEqual("{\"y\":[\"value3\",\"value4\"]}", jp.GetJson("$.x[1]"u8).ToString());
            Assert.AreEqual("[\"value3\",\"value4\"]", jp.GetJson("$.x[1].y"u8).ToString());
            Assert.AreEqual("value3", jp.GetString("$.x[1].y[0]"u8));
            Assert.AreEqual("value4", jp.GetString("$.x[1].y[1]"u8));

            jp.Append("$.x[0].y"u8, "value6");

            Assert.AreEqual("[{\"y\":[\"value1\",\"value2\"]},{\"y\":[\"value3\",\"value4\"]}]", jp.GetJson("$.x"u8).ToString());
            Assert.AreEqual("{\"y\":[\"value1\",\"value2\"]}", jp.GetJson("$.x[0]"u8).ToString());
            Assert.AreEqual("[\"value1\",\"value2\",\"value5\",\"value6\"]", jp.GetJson("$.x[0].y"u8).ToString());
            Assert.AreEqual("value1", jp.GetString("$.x[0].y[0]"u8));
            Assert.AreEqual("value2", jp.GetString("$.x[0].y[1]"u8));
            Assert.AreEqual("value5", jp.GetString("$.x[0].y[2]"u8));
            Assert.AreEqual("value6", jp.GetString("$.x[0].y[3]"u8));
            Assert.AreEqual("{\"y\":[\"value3\",\"value4\"]}", jp.GetJson("$.x[1]"u8).ToString());
            Assert.AreEqual("[\"value3\",\"value4\"]", jp.GetJson("$.x[1].y"u8).ToString());
            Assert.AreEqual("value3", jp.GetString("$.x[1].y[0]"u8));
            Assert.AreEqual("value4", jp.GetString("$.x[1].y[1]"u8));

            jp.Append("$.x[1].y"u8, "value7");

            Assert.AreEqual("[{\"y\":[\"value1\",\"value2\"]},{\"y\":[\"value3\",\"value4\"]}]", jp.GetJson("$.x"u8).ToString());
            Assert.AreEqual("{\"y\":[\"value1\",\"value2\"]}", jp.GetJson("$.x[0]"u8).ToString());
            Assert.AreEqual("[\"value1\",\"value2\",\"value5\",\"value6\"]", jp.GetJson("$.x[0].y"u8).ToString());
            Assert.AreEqual("value1", jp.GetString("$.x[0].y[0]"u8));
            Assert.AreEqual("value2", jp.GetString("$.x[0].y[1]"u8));
            Assert.AreEqual("value5", jp.GetString("$.x[0].y[2]"u8));
            Assert.AreEqual("value6", jp.GetString("$.x[0].y[3]"u8));
            Assert.AreEqual("{\"y\":[\"value3\",\"value4\"]}", jp.GetJson("$.x[1]"u8).ToString());
            Assert.AreEqual("[\"value3\",\"value4\",\"value7\"]", jp.GetJson("$.x[1].y"u8).ToString());
            Assert.AreEqual("value3", jp.GetString("$.x[1].y[0]"u8));
            Assert.AreEqual("value4", jp.GetString("$.x[1].y[1]"u8));
            Assert.AreEqual("value7", jp.GetString("$.x[1].y[2]"u8));

            jp.Append("$.x[1].y"u8, "value8");

            Assert.AreEqual("[{\"y\":[\"value1\",\"value2\"]},{\"y\":[\"value3\",\"value4\"]}]", jp.GetJson("$.x"u8).ToString());
            Assert.AreEqual("{\"y\":[\"value1\",\"value2\"]}", jp.GetJson("$.x[0]"u8).ToString());
            Assert.AreEqual("[\"value1\",\"value2\",\"value5\",\"value6\"]", jp.GetJson("$.x[0].y"u8).ToString());
            Assert.AreEqual("value1", jp.GetString("$.x[0].y[0]"u8));
            Assert.AreEqual("value2", jp.GetString("$.x[0].y[1]"u8));
            Assert.AreEqual("value5", jp.GetString("$.x[0].y[2]"u8));
            Assert.AreEqual("value6", jp.GetString("$.x[0].y[3]"u8));
            Assert.AreEqual("{\"y\":[\"value3\",\"value4\"]}", jp.GetJson("$.x[1]"u8).ToString());
            Assert.AreEqual("[\"value3\",\"value4\",\"value7\",\"value8\"]", jp.GetJson("$.x[1].y"u8).ToString());
            Assert.AreEqual("value3", jp.GetString("$.x[1].y[0]"u8));
            Assert.AreEqual("value4", jp.GetString("$.x[1].y[1]"u8));
            Assert.AreEqual("value7", jp.GetString("$.x[1].y[2]"u8));
            Assert.AreEqual("value8", jp.GetString("$.x[1].y[3]"u8));

            Assert.AreEqual("{\"x\":[{\"y\":[\"value1\",\"value2\",\"value5\",\"value6\"]},{\"y\":[\"value3\",\"value4\",\"value7\",\"value8\"]}]}", GetJsonString(jp));

            jp.Append("$.x"u8, "{\"y\":[\"value9\"]}"u8);

            Assert.AreEqual("[{\"y\":[\"value1\",\"value2\"]},{\"y\":[\"value3\",\"value4\"]},{\"y\":[\"value9\"]}]", jp.GetJson("$.x"u8).ToString());
            Assert.AreEqual("{\"y\":[\"value1\",\"value2\"]}", jp.GetJson("$.x[0]"u8).ToString());
            Assert.AreEqual("[\"value1\",\"value2\",\"value5\",\"value6\"]", jp.GetJson("$.x[0].y"u8).ToString());
            Assert.AreEqual("value1", jp.GetString("$.x[0].y[0]"u8));
            Assert.AreEqual("value2", jp.GetString("$.x[0].y[1]"u8));
            Assert.AreEqual("value5", jp.GetString("$.x[0].y[2]"u8));
            Assert.AreEqual("value6", jp.GetString("$.x[0].y[3]"u8));
            Assert.AreEqual("{\"y\":[\"value3\",\"value4\"]}", jp.GetJson("$.x[1]"u8).ToString());
            Assert.AreEqual("[\"value3\",\"value4\",\"value7\",\"value8\"]", jp.GetJson("$.x[1].y"u8).ToString());
            Assert.AreEqual("value3", jp.GetString("$.x[1].y[0]"u8));
            Assert.AreEqual("value4", jp.GetString("$.x[1].y[1]"u8));
            Assert.AreEqual("value7", jp.GetString("$.x[1].y[2]"u8));
            Assert.AreEqual("value8", jp.GetString("$.x[1].y[3]"u8));
            Assert.AreEqual("{\"y\":[\"value9\"]}", jp.GetJson("$.x[2]"u8).ToString());
            Assert.AreEqual("[\"value9\"]", jp.GetJson("$.x[2].y"u8).ToString());
            Assert.AreEqual("value9", jp.GetString("$.x[2].y[0]"u8));

            Assert.AreEqual("{\"x\":[{\"y\":[\"value1\",\"value2\",\"value5\",\"value6\"]},{\"y\":[\"value3\",\"value4\",\"value7\",\"value8\"]},{\"y\":[\"value9\"]}]}", GetJsonString(jp));
        }

        [Test]
        public void ArrayItem_Insert_OneLevelTwice_WithProperty()
        {
            JsonPatch jp = new();

            jp.Append("$.x[0].y"u8, "{\"a\":\"value1\"}"u8);

            Assert.AreEqual("[{\"y\":[{\"a\":\"value1\"}]}]", jp.GetJson("$.x"u8).ToString());
            Assert.AreEqual("{\"y\":[{\"a\":\"value1\"}]}", jp.GetJson("$.x[0]"u8).ToString());
            Assert.AreEqual("[{\"a\":\"value1\"}]", jp.GetJson("$.x[0].y"u8).ToString());
            Assert.AreEqual("{\"a\":\"value1\"}", jp.GetJson("$.x[0].y[0]"u8).ToString());
            Assert.AreEqual("value1", jp.GetString("$.x[0].y[0].a"u8));

            jp.Append("$.x[0].y"u8, "{\"a\":\"value2\"}"u8);

            Assert.AreEqual("[{\"y\":[{\"a\":\"value1\"},{\"a\":\"value2\"}]}]", jp.GetJson("$.x"u8).ToString());
            Assert.AreEqual("{\"y\":[{\"a\":\"value1\"},{\"a\":\"value2\"}]}", jp.GetJson("$.x[0]"u8).ToString());
            Assert.AreEqual("[{\"a\":\"value1\"},{\"a\":\"value2\"}]", jp.GetJson("$.x[0].y"u8).ToString());
            Assert.AreEqual("{\"a\":\"value1\"}", jp.GetJson("$.x[0].y[0]"u8).ToString());
            Assert.AreEqual("value1", jp.GetString("$.x[0].y[0].a"u8));
            Assert.AreEqual("{\"a\":\"value2\"}", jp.GetJson("$.x[0].y[1]"u8).ToString());
            Assert.AreEqual("value2", jp.GetString("$.x[0].y[1].a"u8));

            jp.Append("$.x[1].y"u8, "{\"a\":\"value3\"}"u8);

            Assert.AreEqual("[{\"y\":[{\"a\":\"value1\"},{\"a\":\"value2\"}]},{\"y\":[{\"a\":\"value3\"}]}]", jp.GetJson("$.x"u8).ToString());
            Assert.AreEqual("{\"y\":[{\"a\":\"value1\"},{\"a\":\"value2\"}]}", jp.GetJson("$.x[0]"u8).ToString());
            Assert.AreEqual("[{\"a\":\"value1\"},{\"a\":\"value2\"}]", jp.GetJson("$.x[0].y"u8).ToString());
            Assert.AreEqual("{\"a\":\"value1\"}", jp.GetJson("$.x[0].y[0]"u8).ToString());
            Assert.AreEqual("value1", jp.GetString("$.x[0].y[0].a"u8));
            Assert.AreEqual("{\"a\":\"value2\"}", jp.GetJson("$.x[0].y[1]"u8).ToString());
            Assert.AreEqual("value2", jp.GetString("$.x[0].y[1].a"u8));
            Assert.AreEqual("{\"y\":[{\"a\":\"value3\"}]}", jp.GetJson("$.x[1]"u8).ToString());
            Assert.AreEqual("[{\"a\":\"value3\"}]", jp.GetJson("$.x[1].y"u8).ToString());
            Assert.AreEqual("{\"a\":\"value3\"}", jp.GetJson("$.x[1].y[0]"u8).ToString());
            Assert.AreEqual("value3", jp.GetString("$.x[1].y[0].a"u8));

            jp.Append("$.x[1].y"u8, "{\"a\":\"value4\"}"u8);

            Assert.AreEqual("[{\"y\":[{\"a\":\"value1\"},{\"a\":\"value2\"}]},{\"y\":[{\"a\":\"value3\"},{\"a\":\"value4\"}]}]", jp.GetJson("$.x"u8).ToString());
            Assert.AreEqual("{\"y\":[{\"a\":\"value1\"},{\"a\":\"value2\"}]}", jp.GetJson("$.x[0]"u8).ToString());
            Assert.AreEqual("[{\"a\":\"value1\"},{\"a\":\"value2\"}]", jp.GetJson("$.x[0].y"u8).ToString());
            Assert.AreEqual("{\"a\":\"value1\"}", jp.GetJson("$.x[0].y[0]"u8).ToString());
            Assert.AreEqual("value1", jp.GetString("$.x[0].y[0].a"u8));
            Assert.AreEqual("{\"a\":\"value2\"}", jp.GetJson("$.x[0].y[1]"u8).ToString());
            Assert.AreEqual("value2", jp.GetString("$.x[0].y[1].a"u8));
            Assert.AreEqual("{\"y\":[{\"a\":\"value3\"},{\"a\":\"value4\"}]}", jp.GetJson("$.x[1]"u8).ToString());
            Assert.AreEqual("[{\"a\":\"value3\"},{\"a\":\"value4\"}]", jp.GetJson("$.x[1].y"u8).ToString());
            Assert.AreEqual("{\"a\":\"value3\"}", jp.GetJson("$.x[1].y[0]"u8).ToString());
            Assert.AreEqual("value3", jp.GetString("$.x[1].y[0].a"u8));
            Assert.AreEqual("{\"a\":\"value4\"}", jp.GetJson("$.x[1].y[1]"u8).ToString());
            Assert.AreEqual("value4", jp.GetString("$.x[1].y[1].a"u8));

            Assert.AreEqual("{\"x\":[{\"y\":[{\"a\":\"value1\"},{\"a\":\"value2\"}]},{\"y\":[{\"a\":\"value3\"},{\"a\":\"value4\"}]}]}", GetJsonString(jp));

            jp.Append("$.x"u8, "{\"y\":[{\"a\":\"value5\"},{\"a\":\"value6\"}]}"u8);

            Assert.AreEqual("[{\"y\":[{\"a\":\"value1\"},{\"a\":\"value2\"}]},{\"y\":[{\"a\":\"value3\"},{\"a\":\"value4\"}]},{\"y\":[{\"a\":\"value5\"},{\"a\":\"value6\"}]}]", jp.GetJson("$.x"u8).ToString());
            Assert.AreEqual("{\"y\":[{\"a\":\"value1\"},{\"a\":\"value2\"}]}", jp.GetJson("$.x[0]"u8).ToString());
            Assert.AreEqual("[{\"a\":\"value1\"},{\"a\":\"value2\"}]", jp.GetJson("$.x[0].y"u8).ToString());
            Assert.AreEqual("{\"a\":\"value1\"}", jp.GetJson("$.x[0].y[0]"u8).ToString());
            Assert.AreEqual("value1", jp.GetString("$.x[0].y[0].a"u8));
            Assert.AreEqual("{\"a\":\"value2\"}", jp.GetJson("$.x[0].y[1]"u8).ToString());
            Assert.AreEqual("value2", jp.GetString("$.x[0].y[1].a"u8));
            Assert.AreEqual("{\"y\":[{\"a\":\"value3\"},{\"a\":\"value4\"}]}", jp.GetJson("$.x[1]"u8).ToString());
            Assert.AreEqual("[{\"a\":\"value3\"},{\"a\":\"value4\"}]", jp.GetJson("$.x[1].y"u8).ToString());
            Assert.AreEqual("{\"a\":\"value3\"}", jp.GetJson("$.x[1].y[0]"u8).ToString());
            Assert.AreEqual("value3", jp.GetString("$.x[1].y[0].a"u8));
            Assert.AreEqual("{\"a\":\"value4\"}", jp.GetJson("$.x[1].y[1]"u8).ToString());
            Assert.AreEqual("value4", jp.GetString("$.x[1].y[1].a"u8));
            Assert.AreEqual("{\"y\":[{\"a\":\"value5\"},{\"a\":\"value6\"}]}", jp.GetJson("$.x[2]"u8).ToString());
            Assert.AreEqual("[{\"a\":\"value5\"},{\"a\":\"value6\"}]", jp.GetJson("$.x[2].y"u8).ToString());
            Assert.AreEqual("{\"a\":\"value5\"}", jp.GetJson("$.x[2].y[0]"u8).ToString());
            Assert.AreEqual("value5", jp.GetString("$.x[2].y[0].a"u8));
            Assert.AreEqual("{\"a\":\"value6\"}", jp.GetJson("$.x[2].y[1]"u8).ToString());
            Assert.AreEqual("value6", jp.GetString("$.x[2].y[1].a"u8));

            Assert.AreEqual("{\"x\":[{\"y\":[{\"a\":\"value1\"},{\"a\":\"value2\"}]},{\"y\":[{\"a\":\"value3\"},{\"a\":\"value4\"}]},{\"y\":[{\"a\":\"value5\"},{\"a\":\"value6\"}]}]}", GetJsonString(jp));
        }

        [Test]
        public void ArrayIndex_Insert_OneLevelTwice()
        {
            JsonPatch jp = new();

            jp.Append("$.x[0].y"u8, "value1");

            Assert.AreEqual("[{\"y\":[\"value1\"]}]", jp.GetJson("$.x"u8).ToString());
            Assert.AreEqual("{\"y\":[\"value1\"]}", jp.GetJson("$.x[0]"u8).ToString());
            Assert.AreEqual("[\"value1\"]", jp.GetJson("$.x[0].y"u8).ToString());
            Assert.AreEqual("value1", jp.GetString("$.x[0].y[0]"u8));

            jp.Append("$.x[0].y"u8, "value2");

            Assert.AreEqual("[{\"y\":[\"value1\",\"value2\"]}]", jp.GetJson("$.x"u8).ToString());
            Assert.AreEqual("{\"y\":[\"value1\",\"value2\"]}", jp.GetJson("$.x[0]"u8).ToString());
            Assert.AreEqual("[\"value1\",\"value2\"]", jp.GetJson("$.x[0].y"u8).ToString());
            Assert.AreEqual("value1", jp.GetString("$.x[0].y[0]"u8));
            Assert.AreEqual("value2", jp.GetString("$.x[0].y[1]"u8));

            jp.Append("$.x[1].y"u8, "value3");

            Assert.AreEqual("[{\"y\":[\"value1\",\"value2\"]},{\"y\":[\"value3\"]}]", jp.GetJson("$.x"u8).ToString());
            Assert.AreEqual("{\"y\":[\"value1\",\"value2\"]}", jp.GetJson("$.x[0]"u8).ToString());
            Assert.AreEqual("[\"value1\",\"value2\"]", jp.GetJson("$.x[0].y"u8).ToString());
            Assert.AreEqual("value1", jp.GetString("$.x[0].y[0]"u8));
            Assert.AreEqual("value2", jp.GetString("$.x[0].y[1]"u8));
            Assert.AreEqual("{\"y\":[\"value3\"]}", jp.GetJson("$.x[1]"u8).ToString());
            Assert.AreEqual("[\"value3\"]", jp.GetJson("$.x[1].y"u8).ToString());
            Assert.AreEqual("value3", jp.GetString("$.x[1].y[0]"u8));

            jp.Append("$.x[1].y"u8, "value4");

            Assert.AreEqual("[{\"y\":[\"value1\",\"value2\"]},{\"y\":[\"value3\",\"value4\"]}]", jp.GetJson("$.x"u8).ToString());
            Assert.AreEqual("{\"y\":[\"value1\",\"value2\"]}", jp.GetJson("$.x[0]"u8).ToString());
            Assert.AreEqual("[\"value1\",\"value2\"]", jp.GetJson("$.x[0].y"u8).ToString());
            Assert.AreEqual("value1", jp.GetString("$.x[0].y[0]"u8));
            Assert.AreEqual("value2", jp.GetString("$.x[0].y[1]"u8));
            Assert.AreEqual("{\"y\":[\"value3\",\"value4\"]}", jp.GetJson("$.x[1]"u8).ToString());
            Assert.AreEqual("[\"value3\",\"value4\"]", jp.GetJson("$.x[1].y"u8).ToString());
            Assert.AreEqual("value3", jp.GetString("$.x[1].y[0]"u8));
            Assert.AreEqual("value4", jp.GetString("$.x[1].y[1]"u8));

            Assert.AreEqual("{\"x\":[{\"y\":[\"value1\",\"value2\"]},{\"y\":[\"value3\",\"value4\"]}]}", GetJsonString(jp));

            jp.Append("$.x"u8, "{\"y\":[\"value5\",\"value6\"]}"u8);

            Assert.AreEqual("[{\"y\":[\"value1\",\"value2\"]},{\"y\":[\"value3\",\"value4\"]},{\"y\":[\"value5\",\"value6\"]}]", jp.GetJson("$.x"u8).ToString());
            Assert.AreEqual("{\"y\":[\"value1\",\"value2\"]}", jp.GetJson("$.x[0]"u8).ToString());
            Assert.AreEqual("[\"value1\",\"value2\"]", jp.GetJson("$.x[0].y"u8).ToString());
            Assert.AreEqual("value1", jp.GetString("$.x[0].y[0]"u8));
            Assert.AreEqual("value2", jp.GetString("$.x[0].y[1]"u8));
            Assert.AreEqual("{\"y\":[\"value3\",\"value4\"]}", jp.GetJson("$.x[1]"u8).ToString());
            Assert.AreEqual("[\"value3\",\"value4\"]", jp.GetJson("$.x[1].y"u8).ToString());
            Assert.AreEqual("value3", jp.GetString("$.x[1].y[0]"u8));
            Assert.AreEqual("value4", jp.GetString("$.x[1].y[1]"u8));
            Assert.AreEqual("{\"y\":[\"value5\",\"value6\"]}", jp.GetJson("$.x[2]"u8).ToString());
            Assert.AreEqual("[\"value5\",\"value6\"]", jp.GetJson("$.x[2].y"u8).ToString());
            Assert.AreEqual("value5", jp.GetString("$.x[2].y[0]"u8));
            Assert.AreEqual("value6", jp.GetString("$.x[2].y[1]"u8));

            Assert.AreEqual("{\"x\":[{\"y\":[\"value1\",\"value2\"]},{\"y\":[\"value3\",\"value4\"]},{\"y\":[\"value5\",\"value6\"]}]}", GetJsonString(jp));
        }

        [Test]
        public void ArrayIndex_RootAndInsert_OneLevel_WithProperty()
        {
            JsonPatch jp = new(new("{\"x\":[{\"a\":\"value1\"},{\"a\":\"value2\"}]}"u8.ToArray()));

            Assert.AreEqual("[{\"a\":\"value1\"},{\"a\":\"value2\"}]", jp.GetJson("$.x"u8).ToString());
            Assert.AreEqual("{\"a\":\"value1\"}", jp.GetJson("$.x[0]"u8).ToString());
            Assert.AreEqual("value1", jp.GetString("$.x[0].a"u8));
            Assert.AreEqual("{\"a\":\"value2\"}", jp.GetJson("$.x[1]"u8).ToString());
            Assert.AreEqual("value2", jp.GetString("$.x[1].a"u8));

            jp.Append("$.x"u8, "{\"a\":\"value3\"}"u8);

            Assert.AreEqual("[{\"a\":\"value1\"},{\"a\":\"value2\"},{\"a\":\"value3\"}]", jp.GetJson("$.x"u8).ToString());
            Assert.AreEqual("{\"a\":\"value1\"}", jp.GetJson("$.x[0]"u8).ToString());
            Assert.AreEqual("value1", jp.GetString("$.x[0].a"u8));
            Assert.AreEqual("{\"a\":\"value2\"}", jp.GetJson("$.x[1]"u8).ToString());
            Assert.AreEqual("value2", jp.GetString("$.x[1].a"u8));
            Assert.AreEqual("{\"a\":\"value3\"}", jp.GetJson("$.x[2]"u8).ToString());
            Assert.AreEqual("value3", jp.GetString("$.x[2].a"u8));

            jp.Append("$.x"u8, "{\"a\":\"value4\"}"u8);

            Assert.AreEqual("[{\"a\":\"value1\"},{\"a\":\"value2\"},{\"a\":\"value3\"},{\"a\":\"value4\"}]", jp.GetJson("$.x"u8).ToString());
            Assert.AreEqual("{\"a\":\"value1\"}", jp.GetJson("$.x[0]"u8).ToString());
            Assert.AreEqual("value1", jp.GetString("$.x[0].a"u8));
            Assert.AreEqual("{\"a\":\"value2\"}", jp.GetJson("$.x[1]"u8).ToString());
            Assert.AreEqual("value2", jp.GetString("$.x[1].a"u8));
            Assert.AreEqual("{\"a\":\"value3\"}", jp.GetJson("$.x[2]"u8).ToString());
            Assert.AreEqual("value3", jp.GetString("$.x[2].a"u8));
            Assert.AreEqual("{\"a\":\"value4\"}", jp.GetJson("$.x[3]"u8).ToString());
            Assert.AreEqual("value4", jp.GetString("$.x[3].a"u8));

            Assert.AreEqual("{\"x\":[{\"a\":\"value1\"},{\"a\":\"value2\"},{\"a\":\"value3\"},{\"a\":\"value4\"}]}", GetJsonString(jp));
        }

        [Test]
        public void ArrayIndex_RootAndInsert_OneLevel()
        {
            JsonPatch jp = new(new("{\"x\":[\"value1\",\"value2\"]}"u8.ToArray()));

            Assert.AreEqual("[\"value1\",\"value2\"]", jp.GetJson("$.x"u8).ToString());
            Assert.AreEqual("value1", jp.GetString("$.x[0]"u8));
            Assert.AreEqual("value2", jp.GetString("$.x[1]"u8));

            jp.Append("$.x"u8, "value3");

            Assert.AreEqual("[\"value1\",\"value2\",\"value3\"]", jp.GetJson("$.x"u8).ToString());
            Assert.AreEqual("value1", jp.GetString("$.x[0]"u8));
            Assert.AreEqual("value2", jp.GetString("$.x[1]"u8));
            Assert.AreEqual("value3", jp.GetString("$.x[2]"u8));

            jp.Append("$.x"u8, "value4");

            Assert.AreEqual("[\"value1\",\"value2\",\"value3\",\"value4\"]", jp.GetJson("$.x"u8).ToString());
            Assert.AreEqual("value1", jp.GetString("$.x[0]"u8));
            Assert.AreEqual("value2", jp.GetString("$.x[1]"u8));
            Assert.AreEqual("value3", jp.GetString("$.x[2]"u8));
            Assert.AreEqual("value4", jp.GetString("$.x[3]"u8));

            Assert.AreEqual("{\"x\":[\"value1\",\"value2\",\"value3\",\"value4\"]}", GetJsonString(jp));
        }

        [Test]
        public void ArrayIndex_Insert_OneLevel_WithProperty()
        {
            JsonPatch jp = new();

            jp.Append("$.x"u8, "{\"a\":\"value1\"}"u8);

            Assert.AreEqual("[{\"a\":\"value1\"}]", jp.GetJson("$.x"u8).ToString());
            Assert.AreEqual("{\"a\":\"value1\"}", jp.GetJson("$.x[0]"u8).ToString());
            Assert.AreEqual("value1", jp.GetString("$.x[0].a"u8));

            jp.Append("$.x"u8, "{\"a\":\"value2\"}"u8);

            Assert.AreEqual("[{\"a\":\"value1\"},{\"a\":\"value2\"}]", jp.GetJson("$.x"u8).ToString());
            Assert.AreEqual("{\"a\":\"value1\"}", jp.GetJson("$.x[0]"u8).ToString());
            Assert.AreEqual("value1", jp.GetString("$.x[0].a"u8));
            Assert.AreEqual("{\"a\":\"value2\"}", jp.GetJson("$.x[1]"u8).ToString());
            Assert.AreEqual("value2", jp.GetString("$.x[1].a"u8));

            Assert.AreEqual("{\"x\":[{\"a\":\"value1\"},{\"a\":\"value2\"}]}", GetJsonString(jp));
        }

        [Test]
        public void ArrayIndex_Insert_OneLevel()
        {
            JsonPatch jp = new();

            jp.Append("$.x"u8, "value1");

            Assert.AreEqual("[\"value1\"]", jp.GetJson("$.x"u8).ToString());
            Assert.AreEqual("value1", jp.GetString("$.x[0]"u8));

            jp.Append("$.x"u8, "value2");

            Assert.AreEqual("[\"value1\",\"value2\"]", jp.GetJson("$.x"u8).ToString());
            Assert.AreEqual("value1", jp.GetString("$.x[0]"u8));
            Assert.AreEqual("value2", jp.GetString("$.x[1]"u8));

            Assert.AreEqual("{\"x\":[\"value1\",\"value2\"]}", GetJsonString(jp));
        }

        [Test]
        public void ArrayIndex_RootAndInsert_Root_WithProperty()
        {
            JsonPatch jp = new(new("[{\"a\":\"value1\"},{\"a\":\"value2\"}]"u8.ToArray()));

            Assert.AreEqual("{\"a\":\"value1\"}", jp.GetJson("$[0]"u8).ToString());
            Assert.AreEqual("value1", jp.GetString("$[0].a"u8));
            Assert.AreEqual("{\"a\":\"value2\"}", jp.GetJson("$[1]"u8).ToString());
            Assert.AreEqual("value2", jp.GetString("$[1].a"u8));

            jp.Append("$"u8, "{\"a\":\"value3\"}"u8);

            Assert.AreEqual("[{\"a\":\"value1\"},{\"a\":\"value2\"},{\"a\":\"value3\"}]", jp.GetJson("$"u8).ToString());
            Assert.AreEqual("{\"a\":\"value1\"}", jp.GetJson("$[0]"u8).ToString());
            Assert.AreEqual("value1", jp.GetString("$[0].a"u8));
            Assert.AreEqual("{\"a\":\"value2\"}", jp.GetJson("$[1]"u8).ToString());
            Assert.AreEqual("value2", jp.GetString("$[1].a"u8));
            Assert.AreEqual("{\"a\":\"value3\"}", jp.GetJson("$[2]"u8).ToString());
            Assert.AreEqual("value3", jp.GetString("$[2].a"u8));

            jp.Append("$"u8, "{\"a\":\"value4\"}"u8);

            Assert.AreEqual("[{\"a\":\"value1\"},{\"a\":\"value2\"},{\"a\":\"value3\"},{\"a\":\"value4\"}]", jp.GetJson("$"u8).ToString());
            Assert.AreEqual("{\"a\":\"value1\"}", jp.GetJson("$[0]"u8).ToString());
            Assert.AreEqual("value1", jp.GetString("$[0].a"u8));
            Assert.AreEqual("{\"a\":\"value2\"}", jp.GetJson("$[1]"u8).ToString());
            Assert.AreEqual("value2", jp.GetString("$[1].a"u8));
            Assert.AreEqual("{\"a\":\"value3\"}", jp.GetJson("$[2]"u8).ToString());
            Assert.AreEqual("value3", jp.GetString("$[2].a"u8));
            Assert.AreEqual("{\"a\":\"value4\"}", jp.GetJson("$[3]"u8).ToString());
            Assert.AreEqual("value4", jp.GetString("$[3].a"u8));

            Assert.AreEqual("[{\"a\":\"value1\"},{\"a\":\"value2\"},{\"a\":\"value3\"},{\"a\":\"value4\"}]", GetJsonString(jp));
        }

        [Test]
        public void ArrayIndex_RootAndInsert_Root()
        {
            JsonPatch jp = new(new("[\"value1\",\"value2\"]"u8.ToArray()));

            Assert.AreEqual("value1", jp.GetString("$[0]"u8));
            Assert.AreEqual("value2", jp.GetString("$[1]"u8));

            jp.Append("$"u8, "value3");

            Assert.AreEqual("[\"value1\",\"value2\",\"value3\"]", jp.GetJson("$"u8).ToString());
            Assert.AreEqual("value1", jp.GetString("$[0]"u8));
            Assert.AreEqual("value2", jp.GetString("$[1]"u8));
            Assert.AreEqual("value3", jp.GetString("$[2]"u8));

            jp.Append("$"u8, "value4");

            Assert.AreEqual("[\"value1\",\"value2\",\"value3\",\"value4\"]", jp.GetJson("$"u8).ToString());
            Assert.AreEqual("value1", jp.GetString("$[0]"u8));
            Assert.AreEqual("value2", jp.GetString("$[1]"u8));
            Assert.AreEqual("value3", jp.GetString("$[2]"u8));
            Assert.AreEqual("value4", jp.GetString("$[3]"u8));

            Assert.AreEqual("[\"value1\",\"value2\",\"value3\",\"value4\"]", GetJsonString(jp));
        }

        [Test]
        public void ArrayIndex_Insert_Root_WithProperty()
        {
            JsonPatch jp = new();

            jp.Append("$"u8, "{\"a\":\"value1\"}"u8);

            Assert.AreEqual("[{\"a\":\"value1\"}]", jp.GetJson("$"u8).ToString());
            Assert.AreEqual("{\"a\":\"value1\"}", jp.GetJson("$[0]"u8).ToString());
            Assert.AreEqual("value1", jp.GetString("$[0].a"u8));

            jp.Append("$"u8, "{\"a\":\"value2\"}"u8);

            Assert.AreEqual("[{\"a\":\"value1\"},{\"a\":\"value2\"}]", jp.GetJson("$"u8).ToString());
            Assert.AreEqual("{\"a\":\"value1\"}", jp.GetJson("$[0]"u8).ToString());
            Assert.AreEqual("value1", jp.GetString("$[0].a"u8));
            Assert.AreEqual("{\"a\":\"value2\"}", jp.GetJson("$[1]"u8).ToString());
            Assert.AreEqual("value2", jp.GetString("$[1].a"u8));

            Assert.AreEqual("[{\"a\":\"value1\"},{\"a\":\"value2\"}]", GetJsonString(jp));
        }

        [Test]
        public void ArrayIndex_Insert_Root()
        {
            JsonPatch jp = new();

            jp.Append("$"u8, "value1");

            Assert.AreEqual("[\"value1\"]", jp.GetJson("$"u8).ToString());
            Assert.AreEqual("value1", jp.GetString("$[0]"u8));

            jp.Append("$"u8, "value2");

            Assert.AreEqual("[\"value1\",\"value2\"]", jp.GetJson("$"u8).ToString());
            Assert.AreEqual("value1", jp.GetString("$[0]"u8));
            Assert.AreEqual("value2", jp.GetString("$[1]"u8));

            Assert.AreEqual("[\"value1\",\"value2\"]", GetJsonString(jp));
        }

        private static string GetJsonString(JsonPatch patch)
        {
            using var stream = new MemoryStream();
            Utf8JsonWriter writer = new Utf8JsonWriter(stream);
            patch.Write(writer);
            writer.Flush();
            return Encoding.UTF8.GetString(stream.GetBuffer().AsSpan().Slice(0, (int)stream.Position).ToArray());
        }
    }
}
