// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;
using NUnit.Framework;

namespace System.ClientModel.Tests.ModelReaderWriterTests
{
    public class JsonPatchAppendTests
    {
        [Test]
        public void AppendWithMoreThanTenAndARemove()
        {
            JsonPatch jp = new("{\"arr\":[1,2,3,4,5,6,7,8,9,10,11],\"x\":1}"u8.ToArray());

            jp.Remove("$.x"u8);
            jp.Append("$.arr"u8, 12);
            jp.Append("$.arr"u8, 13);

            Assert.AreEqual("[1,2,3,4,5,6,7,8,9,10,11,12,13]", jp.GetJson("$.arr"u8).ToString());
            Assert.AreEqual(1, jp.GetInt32("$.arr[0]"u8));
            Assert.AreEqual(2, jp.GetInt32("$.arr[1]"u8));
            Assert.AreEqual(3, jp.GetInt32("$.arr[2]"u8));
            Assert.AreEqual(4, jp.GetInt32("$.arr[3]"u8));
            Assert.AreEqual(5, jp.GetInt32("$.arr[4]"u8));
            Assert.AreEqual(6, jp.GetInt32("$.arr[5]"u8));
            Assert.AreEqual(7, jp.GetInt32("$.arr[6]"u8));
            Assert.AreEqual(8, jp.GetInt32("$.arr[7]"u8));
            Assert.AreEqual(9, jp.GetInt32("$.arr[8]"u8));
            Assert.AreEqual(10, jp.GetInt32("$.arr[9]"u8));
            Assert.AreEqual(11, jp.GetInt32("$.arr[10]"u8));
            Assert.AreEqual(12, jp.GetInt32("$.arr[11]"u8));
            Assert.AreEqual(13, jp.GetInt32("$.arr[12]"u8));

            Assert.AreEqual("{\"arr\":[1,2,3,4,5,6,7,8,9,10,11,12,13]}", jp.ToString("J"));
        }

        [Test]
        public void AppendWithMoreThanTen()
        {
            JsonPatch jp = new("{\"arr\":[1,2,3,4,5,6,7,8,9,10,11]}"u8.ToArray());

            jp.Append("$.arr"u8, 12);
            jp.Append("$.arr"u8, 13);

            Assert.AreEqual("[1,2,3,4,5,6,7,8,9,10,11,12,13]", jp.GetJson("$.arr"u8).ToString());
            Assert.AreEqual(1, jp.GetInt32("$.arr[0]"u8));
            Assert.AreEqual(2, jp.GetInt32("$.arr[1]"u8));
            Assert.AreEqual(3, jp.GetInt32("$.arr[2]"u8));
            Assert.AreEqual(4, jp.GetInt32("$.arr[3]"u8));
            Assert.AreEqual(5, jp.GetInt32("$.arr[4]"u8));
            Assert.AreEqual(6, jp.GetInt32("$.arr[5]"u8));
            Assert.AreEqual(7, jp.GetInt32("$.arr[6]"u8));
            Assert.AreEqual(8, jp.GetInt32("$.arr[7]"u8));
            Assert.AreEqual(9, jp.GetInt32("$.arr[8]"u8));
            Assert.AreEqual(10, jp.GetInt32("$.arr[9]"u8));
            Assert.AreEqual(11, jp.GetInt32("$.arr[10]"u8));
            Assert.AreEqual(12, jp.GetInt32("$.arr[11]"u8));
            Assert.AreEqual(13, jp.GetInt32("$.arr[12]"u8));

            Assert.AreEqual("{\"arr\":[1,2,3,4,5,6,7,8,9,10,11,12,13]}", jp.ToString("J"));
        }

        [Test]
        public void RootAndInsert_ParentBeforeOutOfOrder()
        {
            JsonPatch jp = new("{\"a\":{\"b\":[[\"value1\",\"value3\"],[\"value2\"]]}}"u8.ToArray());

            Assert.AreEqual("{\"b\":[[\"value1\",\"value3\"],[\"value2\"]]}", jp.GetJson("$.a"u8).ToString());
            Assert.AreEqual("[[\"value1\",\"value3\"],[\"value2\"]]", jp.GetJson("$.a.b"u8).ToString());
            Assert.AreEqual("[\"value1\",\"value3\"]", jp.GetJson("$.a.b[0]"u8).ToArray());
            Assert.AreEqual("value1", jp.GetString("$.a.b[0][0]"u8));
            Assert.AreEqual("value3", jp.GetString("$.a.b[0][1]"u8));
            Assert.AreEqual("[\"value2\"]", jp.GetJson("$.a.b[1]"u8).ToArray());
            Assert.AreEqual("value2", jp.GetString("$.a.b[1][0]"u8));

            jp.Append("$.a.b"u8, "[\"value4\"]"u8);

            Assert.AreEqual("[[\"value1\",\"value3\"],[\"value2\"],[\"value4\"]]", jp.GetJson("$.a.b"u8).ToString());

            jp.Append("$.a.b[1]"u8, "value5");

            Assert.AreEqual("[[\"value1\",\"value3\"],[\"value2\",\"value5\"],[\"value4\"]]", jp.GetJson("$.a.b"u8).ToString());

            jp.Append("$.a.b[0]"u8, "value6");

            Assert.AreEqual("[[\"value1\",\"value3\",\"value6\"],[\"value2\",\"value5\"],[\"value4\"]]", jp.GetJson("$.a.b"u8).ToString());
            Assert.AreEqual("[\"value1\",\"value3\",\"value6\"]", jp.GetJson("$.a.b[0]"u8).ToString());
            Assert.AreEqual("value1", jp.GetString("$.a.b[0][0]"u8));
            Assert.AreEqual("value3", jp.GetString("$.a.b[0][1]"u8));
            Assert.AreEqual("value6", jp.GetString("$.a.b[0][2]"u8));
            Assert.AreEqual("[\"value2\",\"value5\"]", jp.GetJson("$.a.b[1]"u8).ToString());
            Assert.AreEqual("value2", jp.GetString("$.a.b[1][0]"u8));
            Assert.AreEqual("value5", jp.GetString("$.a.b[1][1]"u8));
            Assert.AreEqual("[\"value4\"]", jp.GetJson("$.a.b[2]"u8).ToString());
            Assert.AreEqual("value4", jp.GetString("$.a.b[2][0]"u8));

            Assert.AreEqual("{\"a\":{\"b\":[[\"value1\",\"value3\",\"value6\"],[\"value2\",\"value5\"],[\"value4\"]]}}", jp.ToString("J"));
        }

        [Test]
        public void Insert_ParentBeforeOutOfOrder()
        {
            JsonPatch jp = new();

            jp.Append("$.a.b"u8, "[\"value1\"]"u8);

            Assert.AreEqual("{\"b\":[[\"value1\"]]}", jp.GetJson("$.a"u8).ToString());

            jp.Append("$.a.b[1]"u8, "value2");

            Assert.AreEqual("{\"b\":[[\"value1\"],[\"value2\"]]}", jp.GetJson("$.a"u8).ToString());

            jp.Append("$.a.b[0]"u8, "value3");

            Assert.AreEqual("{\"b\":[[\"value1\",\"value3\"],[\"value2\"]]}", jp.GetJson("$.a"u8).ToString());
            Assert.AreEqual("[[\"value1\",\"value3\"],[\"value2\"]]", jp.GetJson("$.a.b"u8).ToString());
            Assert.AreEqual("[\"value1\",\"value3\"]", jp.GetJson("$.a.b[0]"u8).ToArray());
            Assert.AreEqual("value1", jp.GetString("$.a.b[0][0]"u8));
            Assert.AreEqual("value3", jp.GetString("$.a.b[0][1]"u8));
            Assert.AreEqual("[\"value2\"]", jp.GetJson("$.a.b[1]"u8).ToArray());
            Assert.AreEqual("value2", jp.GetString("$.a.b[1][0]"u8));

            Assert.AreEqual("{\"a\":{\"b\":[[\"value1\",\"value3\"],[\"value2\"]]}}", jp.ToString("J"));
        }

        [Test]
        public void RootAndInsert_OutOfOrder()
        {
            JsonPatch jp = new("{\"a\":{\"b\":[[\"value1\"],[\"value2\"]]}}"u8.ToArray());

            Assert.AreEqual("{\"b\":[[\"value1\"],[\"value2\"]]}", jp.GetJson("$.a"u8).ToString());
            Assert.AreEqual("[[\"value1\"],[\"value2\"]]", jp.GetJson("$.a.b"u8).ToString());
            Assert.AreEqual("[\"value1\"]", jp.GetJson("$.a.b[0]"u8).ToArray());
            Assert.AreEqual("value1", jp.GetString("$.a.b[0][0]"u8));
            Assert.AreEqual("[\"value2\"]", jp.GetJson("$.a.b[1]"u8).ToArray());
            Assert.AreEqual("value2", jp.GetString("$.a.b[1][0]"u8));

            jp.Append("$.a.b[0]"u8, "value1b");

            Assert.AreEqual("[\"value1\",\"value1b\"]", jp.GetJson("$.a.b[0]"u8).ToString());

            jp.Append("$.a.b[1]"u8, "value2b");

            Assert.AreEqual("[\"value2\",\"value2b\"]", jp.GetJson("$.a.b[1]"u8).ToString());

            jp.Append("$.a.b[3]"u8, "value4");

            Assert.AreEqual("[\"value4\"]", jp.GetJson("$.a.b[3]"u8).ToString());

            jp.Append("$.a.b[2]"u8, "value3");

            Assert.AreEqual("[\"value3\"]", jp.GetJson("$.a.b[2]"u8).ToString());

            jp.Append("$.a.b"u8, "[\"value5\"]"u8);

            Assert.AreEqual("[[\"value1\",\"value1b\"],[\"value2\",\"value2b\"],[\"value3\"],[\"value4\"],[\"value5\"]]", jp.GetJson("$.a.b"u8).ToString());
            Assert.AreEqual("[\"value1\",\"value1b\"]", jp.GetJson("$.a.b[0]"u8).ToString());
            Assert.AreEqual("value1", jp.GetString("$.a.b[0][0]"u8));
            Assert.AreEqual("value1b", jp.GetString("$.a.b[0][1]"u8));
            Assert.AreEqual("[\"value2\",\"value2b\"]", jp.GetJson("$.a.b[1]"u8).ToString());
            Assert.AreEqual("value2", jp.GetString("$.a.b[1][0]"u8));
            Assert.AreEqual("value2b", jp.GetString("$.a.b[1][1]"u8));
            Assert.AreEqual("[\"value3\"]", jp.GetJson("$.a.b[2]"u8).ToString());
            Assert.AreEqual("value3", jp.GetString("$.a.b[2][0]"u8));
            Assert.AreEqual("[\"value4\"]", jp.GetJson("$.a.b[3]"u8).ToString());
            Assert.AreEqual("value4", jp.GetString("$.a.b[3][0]"u8));
            Assert.AreEqual("[\"value5\"]", jp.GetJson("$.a.b[4]"u8).ToString());
            Assert.AreEqual("value5", jp.GetString("$.a.b[4][0]"u8));

            Assert.AreEqual("{\"a\":{\"b\":[[\"value1\",\"value1b\"],[\"value2\",\"value2b\"],[\"value3\"],[\"value4\"],[\"value5\"]]}}", jp.ToString("J"));
        }

        [Test]
        public void Insert_OutOfOrder()
        {
            JsonPatch jp = new();

            jp.Append("$.a.b[1]"u8, "value2");

            Assert.AreEqual("{\"b\":[null,[\"value2\"]]}", jp.GetJson("$.a"u8).ToString());

            jp.Append("$.a.b[0]"u8, "value1");

            Assert.AreEqual("{\"b\":[[\"value1\"],[\"value2\"]]}", jp.GetJson("$.a"u8).ToString());
            Assert.AreEqual("[[\"value1\"],[\"value2\"]]", jp.GetJson("$.a.b"u8).ToString());
            Assert.AreEqual("[\"value1\"]", jp.GetJson("$.a.b[0]"u8).ToArray());
            Assert.AreEqual("value1", jp.GetString("$.a.b[0][0]"u8));
            Assert.AreEqual("[\"value2\"]", jp.GetJson("$.a.b[1]"u8).ToArray());
            Assert.AreEqual("value2", jp.GetString("$.a.b[1][0]"u8));

            Assert.AreEqual("{\"a\":{\"b\":[[\"value1\"],[\"value2\"]]}}", jp.ToString("J"));
        }

        [Test]
        public void RootAndInsert_ThreeDimensionTwoDimension_WithProperty()
        {
            JsonPatch jp = new("{\"x\":{\"y\":[[[{\"z\":{\"a\":[[{\"b\":\"value1\"},{\"b\":\"value2\"}],[{\"b\":\"value3\"},{\"b\":\"value4\"}]]}},{\"z\":{\"a\":[[{\"b\":\"value5\"},{\"b\":\"value6\"}]]}}],[{\"z\":{\"a\":[[{\"b\":\"value7\"},{\"b\":\"value8\"}],[{\"b\":\"value9\"},{\"b\":\"value10\"}]]}}]],[[{\"z\":{\"a\":[[{\"b\":\"value11\"}]]}}]]]}}"u8.ToArray());

            Assert.AreEqual("{\"y\":[[[{\"z\":{\"a\":[[{\"b\":\"value1\"},{\"b\":\"value2\"}],[{\"b\":\"value3\"},{\"b\":\"value4\"}]]}},{\"z\":{\"a\":[[{\"b\":\"value5\"},{\"b\":\"value6\"}]]}}],[{\"z\":{\"a\":[[{\"b\":\"value7\"},{\"b\":\"value8\"}],[{\"b\":\"value9\"},{\"b\":\"value10\"}]]}}]],[[{\"z\":{\"a\":[[{\"b\":\"value11\"}]]}}]]]}", jp.GetJson("$.x"u8).ToString());
            Assert.AreEqual("[[[{\"z\":{\"a\":[[{\"b\":\"value1\"},{\"b\":\"value2\"}],[{\"b\":\"value3\"},{\"b\":\"value4\"}]]}},{\"z\":{\"a\":[[{\"b\":\"value5\"},{\"b\":\"value6\"}]]}}],[{\"z\":{\"a\":[[{\"b\":\"value7\"},{\"b\":\"value8\"}],[{\"b\":\"value9\"},{\"b\":\"value10\"}]]}}]],[[{\"z\":{\"a\":[[{\"b\":\"value11\"}]]}}]]]", jp.GetJson("$.x.y"u8).ToString());
            Assert.AreEqual("[[{\"z\":{\"a\":[[{\"b\":\"value1\"},{\"b\":\"value2\"}],[{\"b\":\"value3\"},{\"b\":\"value4\"}]]}},{\"z\":{\"a\":[[{\"b\":\"value5\"},{\"b\":\"value6\"}]]}}],[{\"z\":{\"a\":[[{\"b\":\"value7\"},{\"b\":\"value8\"}],[{\"b\":\"value9\"},{\"b\":\"value10\"}]]}}]]", jp.GetJson("$.x.y[0]"u8).ToString());
            Assert.AreEqual("[{\"z\":{\"a\":[[{\"b\":\"value1\"},{\"b\":\"value2\"}],[{\"b\":\"value3\"},{\"b\":\"value4\"}]]}},{\"z\":{\"a\":[[{\"b\":\"value5\"},{\"b\":\"value6\"}]]}}]", jp.GetJson("$.x.y[0][0]"u8).ToString());
            Assert.AreEqual("{\"z\":{\"a\":[[{\"b\":\"value1\"},{\"b\":\"value2\"}],[{\"b\":\"value3\"},{\"b\":\"value4\"}]]}}", jp.GetJson("$.x.y[0][0][0]"u8).ToString());
            Assert.AreEqual("{\"a\":[[{\"b\":\"value1\"},{\"b\":\"value2\"}],[{\"b\":\"value3\"},{\"b\":\"value4\"}]]}", jp.GetJson("$.x.y[0][0][0].z"u8).ToString());
            Assert.AreEqual("[[{\"b\":\"value1\"},{\"b\":\"value2\"}],[{\"b\":\"value3\"},{\"b\":\"value4\"}]]", jp.GetJson("$.x.y[0][0][0].z.a"u8).ToString());
            Assert.AreEqual("[{\"b\":\"value1\"},{\"b\":\"value2\"}]", jp.GetJson("$.x.y[0][0][0].z.a[0]"u8).ToString());
            Assert.AreEqual("{\"b\":\"value1\"}", jp.GetJson("$.x.y[0][0][0].z.a[0][0]"u8).ToString());
            Assert.AreEqual("value1", jp.GetString("$.x.y[0][0][0].z.a[0][0].b"u8));
            Assert.AreEqual("{\"b\":\"value2\"}", jp.GetJson("$.x.y[0][0][0].z.a[0][1]"u8).ToString());
            Assert.AreEqual("value2", jp.GetString("$.x.y[0][0][0].z.a[0][1].b"u8));
            Assert.AreEqual("[{\"b\":\"value3\"},{\"b\":\"value4\"}]", jp.GetJson("$.x.y[0][0][0].z.a[1]"u8).ToString());
            Assert.AreEqual("{\"b\":\"value3\"}", jp.GetJson("$.x.y[0][0][0].z.a[1][0]"u8).ToString());
            Assert.AreEqual("value3", jp.GetString("$.x.y[0][0][0].z.a[1][0].b"u8));
            Assert.AreEqual("{\"b\":\"value4\"}", jp.GetJson("$.x.y[0][0][0].z.a[1][1]"u8).ToString());
            Assert.AreEqual("value4", jp.GetString("$.x.y[0][0][0].z.a[1][1].b"u8));
            Assert.AreEqual("{\"z\":{\"a\":[[{\"b\":\"value5\"},{\"b\":\"value6\"}]]}}", jp.GetJson("$.x.y[0][0][1]"u8).ToString());
            Assert.AreEqual("{\"a\":[[{\"b\":\"value5\"},{\"b\":\"value6\"}]]}", jp.GetJson("$.x.y[0][0][1].z"u8).ToString());
            Assert.AreEqual("[[{\"b\":\"value5\"},{\"b\":\"value6\"}]]", jp.GetJson("$.x.y[0][0][1].z.a"u8).ToString());
            Assert.AreEqual("[{\"b\":\"value5\"},{\"b\":\"value6\"}]", jp.GetJson("$.x.y[0][0][1].z.a[0]"u8).ToString());
            Assert.AreEqual("{\"b\":\"value5\"}", jp.GetJson("$.x.y[0][0][1].z.a[0][0]"u8).ToString());
            Assert.AreEqual("value5", jp.GetString("$.x.y[0][0][1].z.a[0][0].b"u8));
            Assert.AreEqual("{\"b\":\"value6\"}", jp.GetJson("$.x.y[0][0][1].z.a[0][1]"u8).ToString());
            Assert.AreEqual("value6", jp.GetString("$.x.y[0][0][1].z.a[0][1].b"u8));
            Assert.AreEqual("[{\"z\":{\"a\":[[{\"b\":\"value7\"},{\"b\":\"value8\"}],[{\"b\":\"value9\"},{\"b\":\"value10\"}]]}}]", jp.GetJson("$.x.y[0][1]"u8).ToString());
            Assert.AreEqual("{\"z\":{\"a\":[[{\"b\":\"value7\"},{\"b\":\"value8\"}],[{\"b\":\"value9\"},{\"b\":\"value10\"}]]}}", jp.GetJson("$.x.y[0][1][0]"u8).ToString());
            Assert.AreEqual("{\"a\":[[{\"b\":\"value7\"},{\"b\":\"value8\"}],[{\"b\":\"value9\"},{\"b\":\"value10\"}]]}", jp.GetJson("$.x.y[0][1][0].z"u8).ToString());
            Assert.AreEqual("[[{\"b\":\"value7\"},{\"b\":\"value8\"}],[{\"b\":\"value9\"},{\"b\":\"value10\"}]]", jp.GetJson("$.x.y[0][1][0].z.a"u8).ToString());
            Assert.AreEqual("[{\"b\":\"value7\"},{\"b\":\"value8\"}]", jp.GetJson("$.x.y[0][1][0].z.a[0]"u8).ToString());
            Assert.AreEqual("{\"b\":\"value7\"}", jp.GetJson("$.x.y[0][1][0].z.a[0][0]"u8).ToString());
            Assert.AreEqual("value7", jp.GetString("$.x.y[0][1][0].z.a[0][0].b"u8));
            Assert.AreEqual("{\"b\":\"value8\"}", jp.GetJson("$.x.y[0][1][0].z.a[0][1]"u8).ToString());
            Assert.AreEqual("value8", jp.GetString("$.x.y[0][1][0].z.a[0][1].b"u8));
            Assert.AreEqual("[{\"b\":\"value9\"},{\"b\":\"value10\"}]", jp.GetJson("$.x.y[0][1][0].z.a[1]"u8).ToString());
            Assert.AreEqual("{\"b\":\"value9\"}", jp.GetJson("$.x.y[0][1][0].z.a[1][0]"u8).ToString());
            Assert.AreEqual("value9", jp.GetString("$.x.y[0][1][0].z.a[1][0].b"u8));
            Assert.AreEqual("{\"b\":\"value10\"}", jp.GetJson("$.x.y[0][1][0].z.a[1][1]"u8).ToString());
            Assert.AreEqual("value10", jp.GetString("$.x.y[0][1][0].z.a[1][1].b"u8));
            Assert.AreEqual("[[{\"z\":{\"a\":[[{\"b\":\"value11\"}]]}}]]", jp.GetJson("$.x.y[1]"u8).ToString());
            Assert.AreEqual("[{\"z\":{\"a\":[[{\"b\":\"value11\"}]]}}]", jp.GetJson("$.x.y[1][0]"u8).ToString());
            Assert.AreEqual("{\"z\":{\"a\":[[{\"b\":\"value11\"}]]}}", jp.GetJson("$.x.y[1][0][0]"u8).ToString());
            Assert.AreEqual("{\"a\":[[{\"b\":\"value11\"}]]}", jp.GetJson("$.x.y[1][0][0].z"u8).ToString());
            Assert.AreEqual("[[{\"b\":\"value11\"}]]", jp.GetJson("$.x.y[1][0][0].z.a"u8).ToString());
            Assert.AreEqual("[{\"b\":\"value11\"}]", jp.GetJson("$.x.y[1][0][0].z.a[0]"u8).ToString());
            Assert.AreEqual("{\"b\":\"value11\"}", jp.GetJson("$.x.y[1][0][0].z.a[0][0]"u8).ToString());
            Assert.AreEqual("value11", jp.GetString("$.x.y[1][0][0].z.a[0][0].b"u8));

            jp.Append("$.x.y"u8, "[[{\"z\":{\"a\":[[{\"b\":\"value12\"}]]}}]]"u8);

            Assert.AreEqual("[[[{\"z\":{\"a\":[[{\"b\":\"value1\"},{\"b\":\"value2\"}],[{\"b\":\"value3\"},{\"b\":\"value4\"}]]}},{\"z\":{\"a\":[[{\"b\":\"value5\"},{\"b\":\"value6\"}]]}}],[{\"z\":{\"a\":[[{\"b\":\"value7\"},{\"b\":\"value8\"}],[{\"b\":\"value9\"},{\"b\":\"value10\"}]]}}]],[[{\"z\":{\"a\":[[{\"b\":\"value11\"}]]}}]],[[{\"z\":{\"a\":[[{\"b\":\"value12\"}]]}}]]]", jp.GetJson("$.x.y"u8).ToString());

            jp.Append("$.x.y[1]"u8, "[{\"z\":{\"a\":[[{\"b\":\"value13\"}]]}}]"u8);

            Assert.AreEqual("[[[{\"z\":{\"a\":[[{\"b\":\"value1\"},{\"b\":\"value2\"}],[{\"b\":\"value3\"},{\"b\":\"value4\"}]]}},{\"z\":{\"a\":[[{\"b\":\"value5\"},{\"b\":\"value6\"}]]}}],[{\"z\":{\"a\":[[{\"b\":\"value7\"},{\"b\":\"value8\"}],[{\"b\":\"value9\"},{\"b\":\"value10\"}]]}}]],[[{\"z\":{\"a\":[[{\"b\":\"value11\"}]]}}],[{\"z\":{\"a\":[[{\"b\":\"value13\"}]]}}]],[[{\"z\":{\"a\":[[{\"b\":\"value12\"}]]}}]]]", jp.GetJson("$.x.y"u8).ToString());

            jp.Append("$.x.y[1][0]"u8, "{\"z\":{\"a\":[[{\"b\":\"value14\"}]]}}"u8);

            Assert.AreEqual("[[[{\"z\":{\"a\":[[{\"b\":\"value1\"},{\"b\":\"value2\"}],[{\"b\":\"value3\"},{\"b\":\"value4\"}]]}},{\"z\":{\"a\":[[{\"b\":\"value5\"},{\"b\":\"value6\"}]]}}],[{\"z\":{\"a\":[[{\"b\":\"value7\"},{\"b\":\"value8\"}],[{\"b\":\"value9\"},{\"b\":\"value10\"}]]}}]],[[{\"z\":{\"a\":[[{\"b\":\"value11\"}]]}},{\"z\":{\"a\":[[{\"b\":\"value14\"}]]}}],[{\"z\":{\"a\":[[{\"b\":\"value13\"}]]}}]],[[{\"z\":{\"a\":[[{\"b\":\"value12\"}]]}}]]]", jp.GetJson("$.x.y"u8).ToString());

            jp.Append("$.x.y[1][0][0].z.a"u8, "[{\"b\":\"value15\"}]"u8);

            Assert.AreEqual("[[[{\"z\":{\"a\":[[{\"b\":\"value1\"},{\"b\":\"value2\"}],[{\"b\":\"value3\"},{\"b\":\"value4\"}]]}},{\"z\":{\"a\":[[{\"b\":\"value5\"},{\"b\":\"value6\"}]]}}],[{\"z\":{\"a\":[[{\"b\":\"value7\"},{\"b\":\"value8\"}],[{\"b\":\"value9\"},{\"b\":\"value10\"}]]}}]],[[{\"z\":{\"a\":[[{\"b\":\"value11\"}],[{\"b\":\"value15\"}]]}},{\"z\":{\"a\":[[{\"b\":\"value14\"}]]}}],[{\"z\":{\"a\":[[{\"b\":\"value13\"}]]}}]],[[{\"z\":{\"a\":[[{\"b\":\"value12\"}]]}}]]]", jp.GetJson("$.x.y"u8).ToString());

            jp.Append("$.x.y[2][0][0].z.a"u8, "[{\"b\":\"value16\"}]"u8);

            Assert.AreEqual("[[[{\"z\":{\"a\":[[{\"b\":\"value1\"},{\"b\":\"value2\"}],[{\"b\":\"value3\"},{\"b\":\"value4\"}]]}},{\"z\":{\"a\":[[{\"b\":\"value5\"},{\"b\":\"value6\"}]]}}],[{\"z\":{\"a\":[[{\"b\":\"value7\"},{\"b\":\"value8\"}],[{\"b\":\"value9\"},{\"b\":\"value10\"}]]}}]],[[{\"z\":{\"a\":[[{\"b\":\"value11\"}],[{\"b\":\"value15\"}]]}},{\"z\":{\"a\":[[{\"b\":\"value14\"}]]}}],[{\"z\":{\"a\":[[{\"b\":\"value13\"}]]}}]],[[{\"z\":{\"a\":[[{\"b\":\"value12\"}],[{\"b\":\"value16\"}]]}}]]]", jp.GetJson("$.x.y"u8).ToString());

            jp.Append("$.x.y[2][0][0].z.a[1]"u8, "{\"b\":\"value17\"}"u8);

            Assert.AreEqual("{\"y\":[[[{\"z\":{\"a\":[[{\"b\":\"value1\"},{\"b\":\"value2\"}],[{\"b\":\"value3\"},{\"b\":\"value4\"}]]}},{\"z\":{\"a\":[[{\"b\":\"value5\"},{\"b\":\"value6\"}]]}}],[{\"z\":{\"a\":[[{\"b\":\"value7\"},{\"b\":\"value8\"}],[{\"b\":\"value9\"},{\"b\":\"value10\"}]]}}]],[[{\"z\":{\"a\":[[{\"b\":\"value11\"}]]}}]]]}", jp.GetJson("$.x"u8).ToString());
            Assert.AreEqual("[[[{\"z\":{\"a\":[[{\"b\":\"value1\"},{\"b\":\"value2\"}],[{\"b\":\"value3\"},{\"b\":\"value4\"}]]}},{\"z\":{\"a\":[[{\"b\":\"value5\"},{\"b\":\"value6\"}]]}}],[{\"z\":{\"a\":[[{\"b\":\"value7\"},{\"b\":\"value8\"}],[{\"b\":\"value9\"},{\"b\":\"value10\"}]]}}]],[[{\"z\":{\"a\":[[{\"b\":\"value11\"}],[{\"b\":\"value15\"}]]}},{\"z\":{\"a\":[[{\"b\":\"value14\"}]]}}],[{\"z\":{\"a\":[[{\"b\":\"value13\"}]]}}]],[[{\"z\":{\"a\":[[{\"b\":\"value12\"}],[{\"b\":\"value16\"},{\"b\":\"value17\"}]]}}]]]", jp.GetJson("$.x.y"u8).ToString());
            Assert.AreEqual("[[{\"z\":{\"a\":[[{\"b\":\"value1\"},{\"b\":\"value2\"}],[{\"b\":\"value3\"},{\"b\":\"value4\"}]]}},{\"z\":{\"a\":[[{\"b\":\"value5\"},{\"b\":\"value6\"}]]}}],[{\"z\":{\"a\":[[{\"b\":\"value7\"},{\"b\":\"value8\"}],[{\"b\":\"value9\"},{\"b\":\"value10\"}]]}}]]", jp.GetJson("$.x.y[0]"u8).ToString());
            Assert.AreEqual("[{\"z\":{\"a\":[[{\"b\":\"value1\"},{\"b\":\"value2\"}],[{\"b\":\"value3\"},{\"b\":\"value4\"}]]}},{\"z\":{\"a\":[[{\"b\":\"value5\"},{\"b\":\"value6\"}]]}}]", jp.GetJson("$.x.y[0][0]"u8).ToString());
            Assert.AreEqual("{\"z\":{\"a\":[[{\"b\":\"value1\"},{\"b\":\"value2\"}],[{\"b\":\"value3\"},{\"b\":\"value4\"}]]}}", jp.GetJson("$.x.y[0][0][0]"u8).ToString());
            Assert.AreEqual("{\"a\":[[{\"b\":\"value1\"},{\"b\":\"value2\"}],[{\"b\":\"value3\"},{\"b\":\"value4\"}]]}", jp.GetJson("$.x.y[0][0][0].z"u8).ToString());
            Assert.AreEqual("[[{\"b\":\"value1\"},{\"b\":\"value2\"}],[{\"b\":\"value3\"},{\"b\":\"value4\"}]]", jp.GetJson("$.x.y[0][0][0].z.a"u8).ToString());
            Assert.AreEqual("[{\"b\":\"value1\"},{\"b\":\"value2\"}]", jp.GetJson("$.x.y[0][0][0].z.a[0]"u8).ToString());
            Assert.AreEqual("{\"b\":\"value1\"}", jp.GetJson("$.x.y[0][0][0].z.a[0][0]"u8).ToString());
            Assert.AreEqual("value1", jp.GetString("$.x.y[0][0][0].z.a[0][0].b"u8));
            Assert.AreEqual("{\"b\":\"value2\"}", jp.GetJson("$.x.y[0][0][0].z.a[0][1]"u8).ToString());
            Assert.AreEqual("value2", jp.GetString("$.x.y[0][0][0].z.a[0][1].b"u8));
            Assert.AreEqual("[{\"b\":\"value3\"},{\"b\":\"value4\"}]", jp.GetJson("$.x.y[0][0][0].z.a[1]"u8).ToString());
            Assert.AreEqual("{\"b\":\"value3\"}", jp.GetJson("$.x.y[0][0][0].z.a[1][0]"u8).ToString());
            Assert.AreEqual("value3", jp.GetString("$.x.y[0][0][0].z.a[1][0].b"u8));
            Assert.AreEqual("{\"b\":\"value4\"}", jp.GetJson("$.x.y[0][0][0].z.a[1][1]"u8).ToString());
            Assert.AreEqual("value4", jp.GetString("$.x.y[0][0][0].z.a[1][1].b"u8));
            Assert.AreEqual("{\"z\":{\"a\":[[{\"b\":\"value5\"},{\"b\":\"value6\"}]]}}", jp.GetJson("$.x.y[0][0][1]"u8).ToString());
            Assert.AreEqual("{\"a\":[[{\"b\":\"value5\"},{\"b\":\"value6\"}]]}", jp.GetJson("$.x.y[0][0][1].z"u8).ToString());
            Assert.AreEqual("[[{\"b\":\"value5\"},{\"b\":\"value6\"}]]", jp.GetJson("$.x.y[0][0][1].z.a"u8).ToString());
            Assert.AreEqual("[{\"b\":\"value5\"},{\"b\":\"value6\"}]", jp.GetJson("$.x.y[0][0][1].z.a[0]"u8).ToString());
            Assert.AreEqual("{\"b\":\"value5\"}", jp.GetJson("$.x.y[0][0][1].z.a[0][0]"u8).ToString());
            Assert.AreEqual("value5", jp.GetString("$.x.y[0][0][1].z.a[0][0].b"u8));
            Assert.AreEqual("{\"b\":\"value6\"}", jp.GetJson("$.x.y[0][0][1].z.a[0][1]"u8).ToString());
            Assert.AreEqual("value6", jp.GetString("$.x.y[0][0][1].z.a[0][1].b"u8));
            Assert.AreEqual("[{\"z\":{\"a\":[[{\"b\":\"value7\"},{\"b\":\"value8\"}],[{\"b\":\"value9\"},{\"b\":\"value10\"}]]}}]", jp.GetJson("$.x.y[0][1]"u8).ToString());
            Assert.AreEqual("{\"z\":{\"a\":[[{\"b\":\"value7\"},{\"b\":\"value8\"}],[{\"b\":\"value9\"},{\"b\":\"value10\"}]]}}", jp.GetJson("$.x.y[0][1][0]"u8).ToString());
            Assert.AreEqual("{\"a\":[[{\"b\":\"value7\"},{\"b\":\"value8\"}],[{\"b\":\"value9\"},{\"b\":\"value10\"}]]}", jp.GetJson("$.x.y[0][1][0].z"u8).ToString());
            Assert.AreEqual("[[{\"b\":\"value7\"},{\"b\":\"value8\"}],[{\"b\":\"value9\"},{\"b\":\"value10\"}]]", jp.GetJson("$.x.y[0][1][0].z.a"u8).ToString());
            Assert.AreEqual("[{\"b\":\"value7\"},{\"b\":\"value8\"}]", jp.GetJson("$.x.y[0][1][0].z.a[0]"u8).ToString());
            Assert.AreEqual("{\"b\":\"value7\"}", jp.GetJson("$.x.y[0][1][0].z.a[0][0]"u8).ToString());
            Assert.AreEqual("value7", jp.GetString("$.x.y[0][1][0].z.a[0][0].b"u8));
            Assert.AreEqual("{\"b\":\"value8\"}", jp.GetJson("$.x.y[0][1][0].z.a[0][1]"u8).ToString());
            Assert.AreEqual("value8", jp.GetString("$.x.y[0][1][0].z.a[0][1].b"u8));
            Assert.AreEqual("[{\"b\":\"value9\"},{\"b\":\"value10\"}]", jp.GetJson("$.x.y[0][1][0].z.a[1]"u8).ToString());
            Assert.AreEqual("{\"b\":\"value9\"}", jp.GetJson("$.x.y[0][1][0].z.a[1][0]"u8).ToString());
            Assert.AreEqual("value9", jp.GetString("$.x.y[0][1][0].z.a[1][0].b"u8));
            Assert.AreEqual("{\"b\":\"value10\"}", jp.GetJson("$.x.y[0][1][0].z.a[1][1]"u8).ToString());
            Assert.AreEqual("value10", jp.GetString("$.x.y[0][1][0].z.a[1][1].b"u8));
            Assert.AreEqual("[[{\"z\":{\"a\":[[{\"b\":\"value11\"}],[{\"b\":\"value15\"}]]}},{\"z\":{\"a\":[[{\"b\":\"value14\"}]]}}],[{\"z\":{\"a\":[[{\"b\":\"value13\"}]]}}]]", jp.GetJson("$.x.y[1]"u8).ToString());
            Assert.AreEqual("[{\"z\":{\"a\":[[{\"b\":\"value11\"}],[{\"b\":\"value15\"}]]}},{\"z\":{\"a\":[[{\"b\":\"value14\"}]]}}]", jp.GetJson("$.x.y[1][0]"u8).ToString());
            Assert.AreEqual("{\"z\":{\"a\":[[{\"b\":\"value11\"}],[{\"b\":\"value15\"}]]}}", jp.GetJson("$.x.y[1][0][0]"u8).ToString());
            Assert.AreEqual("{\"a\":[[{\"b\":\"value11\"}],[{\"b\":\"value15\"}]]}", jp.GetJson("$.x.y[1][0][0].z"u8).ToString());
            Assert.AreEqual("[[{\"b\":\"value11\"}],[{\"b\":\"value15\"}]]", jp.GetJson("$.x.y[1][0][0].z.a"u8).ToString());
            Assert.AreEqual("[{\"b\":\"value11\"}]", jp.GetJson("$.x.y[1][0][0].z.a[0]"u8).ToString());
            Assert.AreEqual("{\"b\":\"value11\"}", jp.GetJson("$.x.y[1][0][0].z.a[0][0]"u8).ToString());
            Assert.AreEqual("value11", jp.GetString("$.x.y[1][0][0].z.a[0][0].b"u8));
            Assert.AreEqual("[{\"b\":\"value15\"}]", jp.GetJson("$.x.y[1][0][0].z.a[1]"u8).ToString());
            Assert.AreEqual("{\"b\":\"value15\"}", jp.GetJson("$.x.y[1][0][0].z.a[1][0]"u8).ToString());
            Assert.AreEqual("value15", jp.GetString("$.x.y[1][0][0].z.a[1][0].b"u8));
            Assert.AreEqual("{\"z\":{\"a\":[[{\"b\":\"value14\"}]]}}", jp.GetJson("$.x.y[1][0][1]"u8).ToString());
            Assert.AreEqual("{\"a\":[[{\"b\":\"value14\"}]]}", jp.GetJson("$.x.y[1][0][1].z"u8).ToString());
            Assert.AreEqual("[[{\"b\":\"value14\"}]]", jp.GetJson("$.x.y[1][0][1].z.a"u8).ToString());
            Assert.AreEqual("[{\"b\":\"value14\"}]", jp.GetJson("$.x.y[1][0][1].z.a[0]"u8).ToString());
            Assert.AreEqual("{\"b\":\"value14\"}", jp.GetJson("$.x.y[1][0][1].z.a[0][0]"u8).ToString());
            Assert.AreEqual("value14", jp.GetString("$.x.y[1][0][1].z.a[0][0].b"u8));
            Assert.AreEqual("[{\"z\":{\"a\":[[{\"b\":\"value13\"}]]}}]", jp.GetJson("$.x.y[1][1]"u8).ToString());
            Assert.AreEqual("{\"z\":{\"a\":[[{\"b\":\"value13\"}]]}}", jp.GetJson("$.x.y[1][1][0]"u8).ToString());
            Assert.AreEqual("{\"a\":[[{\"b\":\"value13\"}]]}", jp.GetJson("$.x.y[1][1][0].z"u8).ToString());
            Assert.AreEqual("[[{\"b\":\"value13\"}]]", jp.GetJson("$.x.y[1][1][0].z.a"u8).ToString());
            Assert.AreEqual("[{\"b\":\"value13\"}]", jp.GetJson("$.x.y[1][1][0].z.a[0]"u8).ToString());
            Assert.AreEqual("{\"b\":\"value13\"}", jp.GetJson("$.x.y[1][1][0].z.a[0][0]"u8).ToString());
            Assert.AreEqual("value13", jp.GetString("$.x.y[1][1][0].z.a[0][0].b"u8));
            Assert.AreEqual("[[{\"z\":{\"a\":[[{\"b\":\"value12\"}],[{\"b\":\"value16\"},{\"b\":\"value17\"}]]}}]]", jp.GetJson("$.x.y[2]"u8).ToString());
            Assert.AreEqual("[{\"z\":{\"a\":[[{\"b\":\"value12\"}],[{\"b\":\"value16\"},{\"b\":\"value17\"}]]}}]", jp.GetJson("$.x.y[2][0]"u8).ToString());
            Assert.AreEqual("{\"z\":{\"a\":[[{\"b\":\"value12\"}],[{\"b\":\"value16\"},{\"b\":\"value17\"}]]}}", jp.GetJson("$.x.y[2][0][0]"u8).ToString());
            Assert.AreEqual("{\"a\":[[{\"b\":\"value12\"}],[{\"b\":\"value16\"},{\"b\":\"value17\"}]]}", jp.GetJson("$.x.y[2][0][0].z"u8).ToString());
            Assert.AreEqual("[[{\"b\":\"value12\"}],[{\"b\":\"value16\"},{\"b\":\"value17\"}]]", jp.GetJson("$.x.y[2][0][0].z.a"u8).ToString());
            Assert.AreEqual("[{\"b\":\"value12\"}]", jp.GetJson("$.x.y[2][0][0].z.a[0]"u8).ToString());
            Assert.AreEqual("{\"b\":\"value12\"}", jp.GetJson("$.x.y[2][0][0].z.a[0][0]"u8).ToString());
            Assert.AreEqual("value12", jp.GetString("$.x.y[2][0][0].z.a[0][0].b"u8));
            Assert.AreEqual("[{\"b\":\"value16\"},{\"b\":\"value17\"}]", jp.GetJson("$.x.y[2][0][0].z.a[1]"u8).ToString());
            Assert.AreEqual("{\"b\":\"value16\"}", jp.GetJson("$.x.y[2][0][0].z.a[1][0]"u8).ToString());
            Assert.AreEqual("value16", jp.GetString("$.x.y[2][0][0].z.a[1][0].b"u8));
            Assert.AreEqual("{\"b\":\"value17\"}", jp.GetJson("$.x.y[2][0][0].z.a[1][1]"u8).ToString());
            Assert.AreEqual("value17", jp.GetString("$.x.y[2][0][0].z.a[1][1].b"u8));

            Assert.AreEqual("{\"x\":{\"y\":[[[{\"z\":{\"a\":[[{\"b\":\"value1\"},{\"b\":\"value2\"}],[{\"b\":\"value3\"},{\"b\":\"value4\"}]]}},{\"z\":{\"a\":[[{\"b\":\"value5\"},{\"b\":\"value6\"}]]}}],[{\"z\":{\"a\":[[{\"b\":\"value7\"},{\"b\":\"value8\"}],[{\"b\":\"value9\"},{\"b\":\"value10\"}]]}}]],[[{\"z\":{\"a\":[[{\"b\":\"value11\"}],[{\"b\":\"value15\"}]]}},{\"z\":{\"a\":[[{\"b\":\"value14\"}]]}}],[{\"z\":{\"a\":[[{\"b\":\"value13\"}]]}}]],[[{\"z\":{\"a\":[[{\"b\":\"value12\"}],[{\"b\":\"value16\"},{\"b\":\"value17\"}]]}}]]]}}", jp.ToString("J"));
        }

        [Test]
        public void RootAndInsert_ThreeDimensionTwoDimension()
        {
            JsonPatch jp = new("{\"x\":{\"y\":[[[{\"z\":{\"a\":[[\"value1\",\"value2\"],[\"value3\",\"value4\"]]}},{\"z\":{\"a\":[[\"value5\",\"value6\"]]}}],[{\"z\":{\"a\":[[\"value7\",\"value8\"],[\"value9\",\"value10\"]]}}]],[[{\"z\":{\"a\":[[\"value11\"]]}}]]]}}"u8.ToArray());

            Assert.AreEqual("{\"y\":[[[{\"z\":{\"a\":[[\"value1\",\"value2\"],[\"value3\",\"value4\"]]}},{\"z\":{\"a\":[[\"value5\",\"value6\"]]}}],[{\"z\":{\"a\":[[\"value7\",\"value8\"],[\"value9\",\"value10\"]]}}]],[[{\"z\":{\"a\":[[\"value11\"]]}}]]]}", jp.GetJson("$.x"u8).ToString());
            Assert.AreEqual("[[[{\"z\":{\"a\":[[\"value1\",\"value2\"],[\"value3\",\"value4\"]]}},{\"z\":{\"a\":[[\"value5\",\"value6\"]]}}],[{\"z\":{\"a\":[[\"value7\",\"value8\"],[\"value9\",\"value10\"]]}}]],[[{\"z\":{\"a\":[[\"value11\"]]}}]]]", jp.GetJson("$.x.y"u8).ToString());
            Assert.AreEqual("[[{\"z\":{\"a\":[[\"value1\",\"value2\"],[\"value3\",\"value4\"]]}},{\"z\":{\"a\":[[\"value5\",\"value6\"]]}}],[{\"z\":{\"a\":[[\"value7\",\"value8\"],[\"value9\",\"value10\"]]}}]]", jp.GetJson("$.x.y[0]"u8).ToString());
            Assert.AreEqual("[{\"z\":{\"a\":[[\"value1\",\"value2\"],[\"value3\",\"value4\"]]}},{\"z\":{\"a\":[[\"value5\",\"value6\"]]}}]", jp.GetJson("$.x.y[0][0]"u8).ToString());
            Assert.AreEqual("{\"z\":{\"a\":[[\"value1\",\"value2\"],[\"value3\",\"value4\"]]}}", jp.GetJson("$.x.y[0][0][0]"u8).ToString());
            Assert.AreEqual("{\"a\":[[\"value1\",\"value2\"],[\"value3\",\"value4\"]]}", jp.GetJson("$.x.y[0][0][0].z"u8).ToString());
            Assert.AreEqual("[[\"value1\",\"value2\"],[\"value3\",\"value4\"]]", jp.GetJson("$.x.y[0][0][0].z.a"u8).ToString());
            Assert.AreEqual("[\"value1\",\"value2\"]", jp.GetJson("$.x.y[0][0][0].z.a[0]"u8).ToString());
            Assert.AreEqual("value1", jp.GetString("$.x.y[0][0][0].z.a[0][0]"u8));
            Assert.AreEqual("value2", jp.GetString("$.x.y[0][0][0].z.a[0][1]"u8));
            Assert.AreEqual("[\"value3\",\"value4\"]", jp.GetJson("$.x.y[0][0][0].z.a[1]"u8).ToString());
            Assert.AreEqual("value3", jp.GetString("$.x.y[0][0][0].z.a[1][0]"u8));
            Assert.AreEqual("value4", jp.GetString("$.x.y[0][0][0].z.a[1][1]"u8));
            Assert.AreEqual("{\"z\":{\"a\":[[\"value5\",\"value6\"]]}}", jp.GetJson("$.x.y[0][0][1]"u8).ToString());
            Assert.AreEqual("{\"a\":[[\"value5\",\"value6\"]]}", jp.GetJson("$.x.y[0][0][1].z"u8).ToString());
            Assert.AreEqual("[[\"value5\",\"value6\"]]", jp.GetJson("$.x.y[0][0][1].z.a"u8).ToString());
            Assert.AreEqual("[\"value5\",\"value6\"]", jp.GetJson("$.x.y[0][0][1].z.a[0]"u8).ToString());
            Assert.AreEqual("value5", jp.GetString("$.x.y[0][0][1].z.a[0][0]"u8));
            Assert.AreEqual("value6", jp.GetString("$.x.y[0][0][1].z.a[0][1]"u8));
            Assert.AreEqual("[{\"z\":{\"a\":[[\"value7\",\"value8\"],[\"value9\",\"value10\"]]}}]", jp.GetJson("$.x.y[0][1]"u8).ToString());
            Assert.AreEqual("{\"z\":{\"a\":[[\"value7\",\"value8\"],[\"value9\",\"value10\"]]}}", jp.GetJson("$.x.y[0][1][0]"u8).ToString());
            Assert.AreEqual("{\"a\":[[\"value7\",\"value8\"],[\"value9\",\"value10\"]]}", jp.GetJson("$.x.y[0][1][0].z"u8).ToString());
            Assert.AreEqual("[[\"value7\",\"value8\"],[\"value9\",\"value10\"]]", jp.GetJson("$.x.y[0][1][0].z.a"u8).ToString());
            Assert.AreEqual("[\"value7\",\"value8\"]", jp.GetJson("$.x.y[0][1][0].z.a[0]"u8).ToString());
            Assert.AreEqual("value7", jp.GetString("$.x.y[0][1][0].z.a[0][0]"u8));
            Assert.AreEqual("value8", jp.GetString("$.x.y[0][1][0].z.a[0][1]"u8));
            Assert.AreEqual("[\"value9\",\"value10\"]", jp.GetJson("$.x.y[0][1][0].z.a[1]"u8).ToString());
            Assert.AreEqual("value9", jp.GetString("$.x.y[0][1][0].z.a[1][0]"u8));
            Assert.AreEqual("value10", jp.GetString("$.x.y[0][1][0].z.a[1][1]"u8));
            Assert.AreEqual("[[{\"z\":{\"a\":[[\"value11\"]]}}]]", jp.GetJson("$.x.y[1]"u8).ToString());
            Assert.AreEqual("[{\"z\":{\"a\":[[\"value11\"]]}}]", jp.GetJson("$.x.y[1][0]"u8).ToString());
            Assert.AreEqual("{\"z\":{\"a\":[[\"value11\"]]}}", jp.GetJson("$.x.y[1][0][0]"u8).ToString());
            Assert.AreEqual("{\"a\":[[\"value11\"]]}", jp.GetJson("$.x.y[1][0][0].z"u8).ToString());
            Assert.AreEqual("[[\"value11\"]]", jp.GetJson("$.x.y[1][0][0].z.a"u8).ToString());
            Assert.AreEqual("[\"value11\"]", jp.GetJson("$.x.y[1][0][0].z.a[0]"u8).ToString());
            Assert.AreEqual("value11", jp.GetString("$.x.y[1][0][0].z.a[0][0]"u8));

            jp.Append("$.x.y"u8, "[[{\"z\":{\"a\":[[\"value12\"]]}}]]"u8);

            Assert.AreEqual("[[[{\"z\":{\"a\":[[\"value1\",\"value2\"],[\"value3\",\"value4\"]]}},{\"z\":{\"a\":[[\"value5\",\"value6\"]]}}],[{\"z\":{\"a\":[[\"value7\",\"value8\"],[\"value9\",\"value10\"]]}}]],[[{\"z\":{\"a\":[[\"value11\"]]}}]],[[{\"z\":{\"a\":[[\"value12\"]]}}]]]", jp.GetJson("$.x.y"u8).ToString());

            jp.Append("$.x.y[1]"u8, "[{\"z\":{\"a\":[[\"value13\"]]}}]"u8);

            Assert.AreEqual("[[[{\"z\":{\"a\":[[\"value1\",\"value2\"],[\"value3\",\"value4\"]]}},{\"z\":{\"a\":[[\"value5\",\"value6\"]]}}],[{\"z\":{\"a\":[[\"value7\",\"value8\"],[\"value9\",\"value10\"]]}}]],[[{\"z\":{\"a\":[[\"value11\"]]}}],[{\"z\":{\"a\":[[\"value13\"]]}}]],[[{\"z\":{\"a\":[[\"value12\"]]}}]]]", jp.GetJson("$.x.y"u8).ToString());

            jp.Append("$.x.y[1][0]"u8, "{\"z\":{\"a\":[[\"value14\"]]}}"u8);

            Assert.AreEqual("[[[{\"z\":{\"a\":[[\"value1\",\"value2\"],[\"value3\",\"value4\"]]}},{\"z\":{\"a\":[[\"value5\",\"value6\"]]}}],[{\"z\":{\"a\":[[\"value7\",\"value8\"],[\"value9\",\"value10\"]]}}]],[[{\"z\":{\"a\":[[\"value11\"]]}},{\"z\":{\"a\":[[\"value14\"]]}}],[{\"z\":{\"a\":[[\"value13\"]]}}]],[[{\"z\":{\"a\":[[\"value12\"]]}}]]]", jp.GetJson("$.x.y"u8).ToString());

            jp.Append("$.x.y[1][0][0].z.a"u8, "[\"value15\"]"u8);

            Assert.AreEqual("[[[{\"z\":{\"a\":[[\"value1\",\"value2\"],[\"value3\",\"value4\"]]}},{\"z\":{\"a\":[[\"value5\",\"value6\"]]}}],[{\"z\":{\"a\":[[\"value7\",\"value8\"],[\"value9\",\"value10\"]]}}]],[[{\"z\":{\"a\":[[\"value11\"],[\"value15\"]]}},{\"z\":{\"a\":[[\"value14\"]]}}],[{\"z\":{\"a\":[[\"value13\"]]}}]],[[{\"z\":{\"a\":[[\"value12\"]]}}]]]", jp.GetJson("$.x.y"u8).ToString());

            jp.Append("$.x.y[2][0][0].z.a"u8, "[\"value16\"]"u8);

            Assert.AreEqual("[[[{\"z\":{\"a\":[[\"value1\",\"value2\"],[\"value3\",\"value4\"]]}},{\"z\":{\"a\":[[\"value5\",\"value6\"]]}}],[{\"z\":{\"a\":[[\"value7\",\"value8\"],[\"value9\",\"value10\"]]}}]],[[{\"z\":{\"a\":[[\"value11\"],[\"value15\"]]}},{\"z\":{\"a\":[[\"value14\"]]}}],[{\"z\":{\"a\":[[\"value13\"]]}}]],[[{\"z\":{\"a\":[[\"value12\"],[\"value16\"]]}}]]]", jp.GetJson("$.x.y"u8).ToString());

            jp.Append("$.x.y[2][0][0].z.a[1]"u8, "value17");

            Assert.AreEqual("{\"y\":[[[{\"z\":{\"a\":[[\"value1\",\"value2\"],[\"value3\",\"value4\"]]}},{\"z\":{\"a\":[[\"value5\",\"value6\"]]}}],[{\"z\":{\"a\":[[\"value7\",\"value8\"],[\"value9\",\"value10\"]]}}]],[[{\"z\":{\"a\":[[\"value11\"]]}}]]]}", jp.GetJson("$.x"u8).ToString());
            Assert.AreEqual("[[[{\"z\":{\"a\":[[\"value1\",\"value2\"],[\"value3\",\"value4\"]]}},{\"z\":{\"a\":[[\"value5\",\"value6\"]]}}],[{\"z\":{\"a\":[[\"value7\",\"value8\"],[\"value9\",\"value10\"]]}}]],[[{\"z\":{\"a\":[[\"value11\"],[\"value15\"]]}},{\"z\":{\"a\":[[\"value14\"]]}}],[{\"z\":{\"a\":[[\"value13\"]]}}]],[[{\"z\":{\"a\":[[\"value12\"],[\"value16\",\"value17\"]]}}]]]", jp.GetJson("$.x.y"u8).ToString());
            Assert.AreEqual("[[{\"z\":{\"a\":[[\"value1\",\"value2\"],[\"value3\",\"value4\"]]}},{\"z\":{\"a\":[[\"value5\",\"value6\"]]}}],[{\"z\":{\"a\":[[\"value7\",\"value8\"],[\"value9\",\"value10\"]]}}]]", jp.GetJson("$.x.y[0]"u8).ToString());
            Assert.AreEqual("[{\"z\":{\"a\":[[\"value1\",\"value2\"],[\"value3\",\"value4\"]]}},{\"z\":{\"a\":[[\"value5\",\"value6\"]]}}]", jp.GetJson("$.x.y[0][0]"u8).ToString());
            Assert.AreEqual("{\"z\":{\"a\":[[\"value1\",\"value2\"],[\"value3\",\"value4\"]]}}", jp.GetJson("$.x.y[0][0][0]"u8).ToString());
            Assert.AreEqual("{\"a\":[[\"value1\",\"value2\"],[\"value3\",\"value4\"]]}", jp.GetJson("$.x.y[0][0][0].z"u8).ToString());
            Assert.AreEqual("[[\"value1\",\"value2\"],[\"value3\",\"value4\"]]", jp.GetJson("$.x.y[0][0][0].z.a"u8).ToString());
            Assert.AreEqual("[\"value1\",\"value2\"]", jp.GetJson("$.x.y[0][0][0].z.a[0]"u8).ToString());
            Assert.AreEqual("value1", jp.GetString("$.x.y[0][0][0].z.a[0][0]"u8));
            Assert.AreEqual("value2", jp.GetString("$.x.y[0][0][0].z.a[0][1]"u8));
            Assert.AreEqual("[\"value3\",\"value4\"]", jp.GetJson("$.x.y[0][0][0].z.a[1]"u8).ToString());
            Assert.AreEqual("value3", jp.GetString("$.x.y[0][0][0].z.a[1][0]"u8));
            Assert.AreEqual("value4", jp.GetString("$.x.y[0][0][0].z.a[1][1]"u8));
            Assert.AreEqual("{\"z\":{\"a\":[[\"value5\",\"value6\"]]}}", jp.GetJson("$.x.y[0][0][1]"u8).ToString());
            Assert.AreEqual("{\"a\":[[\"value5\",\"value6\"]]}", jp.GetJson("$.x.y[0][0][1].z"u8).ToString());
            Assert.AreEqual("[[\"value5\",\"value6\"]]", jp.GetJson("$.x.y[0][0][1].z.a"u8).ToString());
            Assert.AreEqual("[\"value5\",\"value6\"]", jp.GetJson("$.x.y[0][0][1].z.a[0]"u8).ToString());
            Assert.AreEqual("value5", jp.GetString("$.x.y[0][0][1].z.a[0][0]"u8));
            Assert.AreEqual("value6", jp.GetString("$.x.y[0][0][1].z.a[0][1]"u8));
            Assert.AreEqual("[{\"z\":{\"a\":[[\"value7\",\"value8\"],[\"value9\",\"value10\"]]}}]", jp.GetJson("$.x.y[0][1]"u8).ToString());
            Assert.AreEqual("{\"z\":{\"a\":[[\"value7\",\"value8\"],[\"value9\",\"value10\"]]}}", jp.GetJson("$.x.y[0][1][0]"u8).ToString());
            Assert.AreEqual("{\"a\":[[\"value7\",\"value8\"],[\"value9\",\"value10\"]]}", jp.GetJson("$.x.y[0][1][0].z"u8).ToString());
            Assert.AreEqual("[[\"value7\",\"value8\"],[\"value9\",\"value10\"]]", jp.GetJson("$.x.y[0][1][0].z.a"u8).ToString());
            Assert.AreEqual("[\"value7\",\"value8\"]", jp.GetJson("$.x.y[0][1][0].z.a[0]"u8).ToString());
            Assert.AreEqual("value7", jp.GetString("$.x.y[0][1][0].z.a[0][0]"u8));
            Assert.AreEqual("value8", jp.GetString("$.x.y[0][1][0].z.a[0][1]"u8));
            Assert.AreEqual("[\"value9\",\"value10\"]", jp.GetJson("$.x.y[0][1][0].z.a[1]"u8).ToString());
            Assert.AreEqual("value9", jp.GetString("$.x.y[0][1][0].z.a[1][0]"u8));
            Assert.AreEqual("value10", jp.GetString("$.x.y[0][1][0].z.a[1][1]"u8));
            Assert.AreEqual("[[{\"z\":{\"a\":[[\"value11\"],[\"value15\"]]}},{\"z\":{\"a\":[[\"value14\"]]}}],[{\"z\":{\"a\":[[\"value13\"]]}}]]", jp.GetJson("$.x.y[1]"u8).ToString());
            Assert.AreEqual("[{\"z\":{\"a\":[[\"value11\"],[\"value15\"]]}},{\"z\":{\"a\":[[\"value14\"]]}}]", jp.GetJson("$.x.y[1][0]"u8).ToString());
            Assert.AreEqual("{\"z\":{\"a\":[[\"value11\"],[\"value15\"]]}}", jp.GetJson("$.x.y[1][0][0]"u8).ToString());
            Assert.AreEqual("{\"a\":[[\"value11\"],[\"value15\"]]}", jp.GetJson("$.x.y[1][0][0].z"u8).ToString());
            Assert.AreEqual("[[\"value11\"],[\"value15\"]]", jp.GetJson("$.x.y[1][0][0].z.a"u8).ToString());
            Assert.AreEqual("[\"value11\"]", jp.GetJson("$.x.y[1][0][0].z.a[0]"u8).ToString());
            Assert.AreEqual("value11", jp.GetString("$.x.y[1][0][0].z.a[0][0]"u8));
            Assert.AreEqual("[\"value15\"]", jp.GetJson("$.x.y[1][0][0].z.a[1]"u8).ToString());
            Assert.AreEqual("value15", jp.GetString("$.x.y[1][0][0].z.a[1][0]"u8));
            Assert.AreEqual("{\"z\":{\"a\":[[\"value14\"]]}}", jp.GetJson("$.x.y[1][0][1]"u8).ToString());
            Assert.AreEqual("{\"a\":[[\"value14\"]]}", jp.GetJson("$.x.y[1][0][1].z"u8).ToString());
            Assert.AreEqual("[[\"value14\"]]", jp.GetJson("$.x.y[1][0][1].z.a"u8).ToString());
            Assert.AreEqual("[\"value14\"]", jp.GetJson("$.x.y[1][0][1].z.a[0]"u8).ToString());
            Assert.AreEqual("value14", jp.GetString("$.x.y[1][0][1].z.a[0][0]"u8));
            Assert.AreEqual("[{\"z\":{\"a\":[[\"value13\"]]}}]", jp.GetJson("$.x.y[1][1]"u8).ToString());
            Assert.AreEqual("{\"z\":{\"a\":[[\"value13\"]]}}", jp.GetJson("$.x.y[1][1][0]"u8).ToString());
            Assert.AreEqual("{\"a\":[[\"value13\"]]}", jp.GetJson("$.x.y[1][1][0].z"u8).ToString());
            Assert.AreEqual("[[\"value13\"]]", jp.GetJson("$.x.y[1][1][0].z.a"u8).ToString());
            Assert.AreEqual("[\"value13\"]", jp.GetJson("$.x.y[1][1][0].z.a[0]"u8).ToString());
            Assert.AreEqual("value13", jp.GetString("$.x.y[1][1][0].z.a[0][0]"u8));
            Assert.AreEqual("[[{\"z\":{\"a\":[[\"value12\"],[\"value16\",\"value17\"]]}}]]", jp.GetJson("$.x.y[2]"u8).ToString());
            Assert.AreEqual("[{\"z\":{\"a\":[[\"value12\"],[\"value16\",\"value17\"]]}}]", jp.GetJson("$.x.y[2][0]"u8).ToString());
            Assert.AreEqual("{\"z\":{\"a\":[[\"value12\"],[\"value16\",\"value17\"]]}}", jp.GetJson("$.x.y[2][0][0]"u8).ToString());
            Assert.AreEqual("{\"a\":[[\"value12\"],[\"value16\",\"value17\"]]}", jp.GetJson("$.x.y[2][0][0].z"u8).ToString());
            Assert.AreEqual("[[\"value12\"],[\"value16\",\"value17\"]]", jp.GetJson("$.x.y[2][0][0].z.a"u8).ToString());
            Assert.AreEqual("[\"value12\"]", jp.GetJson("$.x.y[2][0][0].z.a[0]"u8).ToString());
            Assert.AreEqual("value12", jp.GetString("$.x.y[2][0][0].z.a[0][0]"u8));
            Assert.AreEqual("[\"value16\",\"value17\"]", jp.GetJson("$.x.y[2][0][0].z.a[1]"u8).ToString());
            Assert.AreEqual("value16", jp.GetString("$.x.y[2][0][0].z.a[1][0]"u8));
            Assert.AreEqual("value17", jp.GetString("$.x.y[2][0][0].z.a[1][1]"u8));
        }

        [Test]
        public void Insert_ThreeDimensionTwoDimension_WithProperty()
        {
            JsonPatch jp = new();

            jp.Append("$.x.y[0][0][0].z.a[0]"u8, "{\"b\":\"value1\"}"u8);

            Assert.AreEqual("{\"y\":[[[{\"z\":{\"a\":[[{\"b\":\"value1\"}]]}}]]]}", jp.GetJson("$.x"u8).ToString());

            jp.Append("$.x.y[0][0][0].z.a[0]"u8, "{\"b\":\"value2\"}"u8);

            Assert.AreEqual("{\"y\":[[[{\"z\":{\"a\":[[{\"b\":\"value1\"},{\"b\":\"value2\"}]]}}]]]}", jp.GetJson("$.x"u8).ToString());

            jp.Append("$.x.y[0][0][0].z.a[1]"u8, "{\"b\":\"value3\"}"u8);

            Assert.AreEqual("{\"y\":[[[{\"z\":{\"a\":[[{\"b\":\"value1\"},{\"b\":\"value2\"}],[{\"b\":\"value3\"}]]}}]]]}", jp.GetJson("$.x"u8).ToString());

            jp.Append("$.x.y[0][0][0].z.a[1]"u8, "{\"b\":\"value4\"}"u8);

            Assert.AreEqual("{\"y\":[[[{\"z\":{\"a\":[[{\"b\":\"value1\"},{\"b\":\"value2\"}],[{\"b\":\"value3\"},{\"b\":\"value4\"}]]}}]]]}", jp.GetJson("$.x"u8).ToString());

            jp.Append("$.x.y[0][0]"u8, "{\"z\":{\"a\":[[{\"b\":\"value5\"}]]}}"u8);

            Assert.AreEqual("{\"y\":[[[{\"z\":{\"a\":[[{\"b\":\"value1\"},{\"b\":\"value2\"}],[{\"b\":\"value3\"},{\"b\":\"value4\"}]]}},{\"z\":{\"a\":[[{\"b\":\"value5\"}]]}}]]]}", jp.GetJson("$.x"u8).ToString());

            jp.Append("$.x.y[0][0][1].z.a[0]"u8, "{\"b\":\"value6\"}"u8);

            Assert.AreEqual("{\"y\":[[[{\"z\":{\"a\":[[{\"b\":\"value1\"},{\"b\":\"value2\"}],[{\"b\":\"value3\"},{\"b\":\"value4\"}]]}},{\"z\":{\"a\":[[{\"b\":\"value5\"},{\"b\":\"value6\"}]]}}]]]}", jp.GetJson("$.x"u8).ToString());

            jp.Append("$.x.y[0][1]"u8, "{\"z\":{\"a\":[[{\"b\":\"value7\"}]]}}"u8);

            Assert.AreEqual("{\"y\":[[[{\"z\":{\"a\":[[{\"b\":\"value1\"},{\"b\":\"value2\"}],[{\"b\":\"value3\"},{\"b\":\"value4\"}]]}},{\"z\":{\"a\":[[{\"b\":\"value5\"},{\"b\":\"value6\"}]]}}],[{\"z\":{\"a\":[[{\"b\":\"value7\"}]]}}]]]}", jp.GetJson("$.x"u8).ToString());

            jp.Append("$.x.y[0][1][0].z.a[0]"u8, "{\"b\":\"value8\"}"u8);

            Assert.AreEqual("{\"y\":[[[{\"z\":{\"a\":[[{\"b\":\"value1\"},{\"b\":\"value2\"}],[{\"b\":\"value3\"},{\"b\":\"value4\"}]]}},{\"z\":{\"a\":[[{\"b\":\"value5\"},{\"b\":\"value6\"}]]}}],[{\"z\":{\"a\":[[{\"b\":\"value7\"},{\"b\":\"value8\"}]]}}]]]}", jp.GetJson("$.x"u8).ToString());

            jp.Append("$.x.y[0][1][0].z.a[1]"u8, "{\"b\":\"value9\"}"u8);

            Assert.AreEqual("{\"y\":[[[{\"z\":{\"a\":[[{\"b\":\"value1\"},{\"b\":\"value2\"}],[{\"b\":\"value3\"},{\"b\":\"value4\"}]]}},{\"z\":{\"a\":[[{\"b\":\"value5\"},{\"b\":\"value6\"}]]}}],[{\"z\":{\"a\":[[{\"b\":\"value7\"},{\"b\":\"value8\"}],[{\"b\":\"value9\"}]]}}]]]}", jp.GetJson("$.x"u8).ToString());

            jp.Append("$.x.y[0][1][0].z.a[1]"u8, "{\"b\":\"value10\"}"u8);

            Assert.AreEqual("{\"y\":[[[{\"z\":{\"a\":[[{\"b\":\"value1\"},{\"b\":\"value2\"}],[{\"b\":\"value3\"},{\"b\":\"value4\"}]]}},{\"z\":{\"a\":[[{\"b\":\"value5\"},{\"b\":\"value6\"}]]}}],[{\"z\":{\"a\":[[{\"b\":\"value7\"},{\"b\":\"value8\"}],[{\"b\":\"value9\"},{\"b\":\"value10\"}]]}}]]]}", jp.GetJson("$.x"u8).ToString());

            jp.Append("$.x.y[1]"u8, "[{\"z\":{\"a\":[[{\"b\":\"value11\"}]]}}]"u8);

            Assert.AreEqual("{\"y\":[[[{\"z\":{\"a\":[[{\"b\":\"value1\"},{\"b\":\"value2\"}],[{\"b\":\"value3\"},{\"b\":\"value4\"}]]}},{\"z\":{\"a\":[[{\"b\":\"value5\"},{\"b\":\"value6\"}]]}}],[{\"z\":{\"a\":[[{\"b\":\"value7\"},{\"b\":\"value8\"}],[{\"b\":\"value9\"},{\"b\":\"value10\"}]]}}]],[[{\"z\":{\"a\":[[{\"b\":\"value11\"}]]}}]]]}", jp.GetJson("$.x"u8).ToString());
            Assert.AreEqual("[[[{\"z\":{\"a\":[[{\"b\":\"value1\"},{\"b\":\"value2\"}],[{\"b\":\"value3\"},{\"b\":\"value4\"}]]}},{\"z\":{\"a\":[[{\"b\":\"value5\"},{\"b\":\"value6\"}]]}}],[{\"z\":{\"a\":[[{\"b\":\"value7\"},{\"b\":\"value8\"}],[{\"b\":\"value9\"},{\"b\":\"value10\"}]]}}]],[[{\"z\":{\"a\":[[{\"b\":\"value11\"}]]}}]]]", jp.GetJson("$.x.y"u8).ToString());
            Assert.AreEqual("[[{\"z\":{\"a\":[[{\"b\":\"value1\"},{\"b\":\"value2\"}],[{\"b\":\"value3\"},{\"b\":\"value4\"}]]}},{\"z\":{\"a\":[[{\"b\":\"value5\"},{\"b\":\"value6\"}]]}}],[{\"z\":{\"a\":[[{\"b\":\"value7\"},{\"b\":\"value8\"}],[{\"b\":\"value9\"},{\"b\":\"value10\"}]]}}]]", jp.GetJson("$.x.y[0]"u8).ToString());
            Assert.AreEqual("[{\"z\":{\"a\":[[{\"b\":\"value1\"},{\"b\":\"value2\"}],[{\"b\":\"value3\"},{\"b\":\"value4\"}]]}},{\"z\":{\"a\":[[{\"b\":\"value5\"},{\"b\":\"value6\"}]]}}]", jp.GetJson("$.x.y[0][0]"u8).ToString());
            Assert.AreEqual("{\"z\":{\"a\":[[{\"b\":\"value1\"},{\"b\":\"value2\"}],[{\"b\":\"value3\"},{\"b\":\"value4\"}]]}}", jp.GetJson("$.x.y[0][0][0]"u8).ToString());
            Assert.AreEqual("{\"a\":[[{\"b\":\"value1\"},{\"b\":\"value2\"}],[{\"b\":\"value3\"},{\"b\":\"value4\"}]]}", jp.GetJson("$.x.y[0][0][0].z"u8).ToString());
            Assert.AreEqual("[[{\"b\":\"value1\"},{\"b\":\"value2\"}],[{\"b\":\"value3\"},{\"b\":\"value4\"}]]", jp.GetJson("$.x.y[0][0][0].z.a"u8).ToString());
            Assert.AreEqual("[{\"b\":\"value1\"},{\"b\":\"value2\"}]", jp.GetJson("$.x.y[0][0][0].z.a[0]"u8).ToString());
            Assert.AreEqual("{\"b\":\"value1\"}", jp.GetJson("$.x.y[0][0][0].z.a[0][0]"u8).ToString());
            Assert.AreEqual("value1", jp.GetString("$.x.y[0][0][0].z.a[0][0].b"u8));
            Assert.AreEqual("{\"b\":\"value2\"}", jp.GetJson("$.x.y[0][0][0].z.a[0][1]"u8).ToString());
            Assert.AreEqual("value2", jp.GetString("$.x.y[0][0][0].z.a[0][1].b"u8));
            Assert.AreEqual("[{\"b\":\"value3\"},{\"b\":\"value4\"}]", jp.GetJson("$.x.y[0][0][0].z.a[1]"u8).ToString());
            Assert.AreEqual("{\"b\":\"value3\"}", jp.GetJson("$.x.y[0][0][0].z.a[1][0]"u8).ToString());
            Assert.AreEqual("value3", jp.GetString("$.x.y[0][0][0].z.a[1][0].b"u8));
            Assert.AreEqual("{\"b\":\"value4\"}", jp.GetJson("$.x.y[0][0][0].z.a[1][1]"u8).ToString());
            Assert.AreEqual("value4", jp.GetString("$.x.y[0][0][0].z.a[1][1].b"u8));
            Assert.AreEqual("{\"z\":{\"a\":[[{\"b\":\"value5\"},{\"b\":\"value6\"}]]}}", jp.GetJson("$.x.y[0][0][1]"u8).ToString());
            Assert.AreEqual("{\"a\":[[{\"b\":\"value5\"},{\"b\":\"value6\"}]]}", jp.GetJson("$.x.y[0][0][1].z"u8).ToString());
            Assert.AreEqual("[[{\"b\":\"value5\"},{\"b\":\"value6\"}]]", jp.GetJson("$.x.y[0][0][1].z.a"u8).ToString());
            Assert.AreEqual("[{\"b\":\"value5\"},{\"b\":\"value6\"}]", jp.GetJson("$.x.y[0][0][1].z.a[0]"u8).ToString());
            Assert.AreEqual("{\"b\":\"value5\"}", jp.GetJson("$.x.y[0][0][1].z.a[0][0]"u8).ToString());
            Assert.AreEqual("value5", jp.GetString("$.x.y[0][0][1].z.a[0][0].b"u8));
            Assert.AreEqual("{\"b\":\"value6\"}", jp.GetJson("$.x.y[0][0][1].z.a[0][1]"u8).ToString());
            Assert.AreEqual("value6", jp.GetString("$.x.y[0][0][1].z.a[0][1].b"u8));
            Assert.AreEqual("{\"z\":{\"a\":[[{\"b\":\"value7\"},{\"b\":\"value8\"}],[{\"b\":\"value9\"},{\"b\":\"value10\"}]]}}", jp.GetJson("$.x.y[0][1][0]"u8).ToString());
            Assert.AreEqual("{\"a\":[[{\"b\":\"value7\"},{\"b\":\"value8\"}],[{\"b\":\"value9\"},{\"b\":\"value10\"}]]}", jp.GetJson("$.x.y[0][1][0].z"u8).ToString());
            Assert.AreEqual("[[{\"b\":\"value7\"},{\"b\":\"value8\"}],[{\"b\":\"value9\"},{\"b\":\"value10\"}]]", jp.GetJson("$.x.y[0][1][0].z.a"u8).ToString());
            Assert.AreEqual("[{\"b\":\"value7\"},{\"b\":\"value8\"}]", jp.GetJson("$.x.y[0][1][0].z.a[0]"u8).ToString());
            Assert.AreEqual("{\"b\":\"value7\"}", jp.GetJson("$.x.y[0][1][0].z.a[0][0]"u8).ToString());
            Assert.AreEqual("value7", jp.GetString("$.x.y[0][1][0].z.a[0][0].b"u8));
            Assert.AreEqual("{\"b\":\"value8\"}", jp.GetJson("$.x.y[0][1][0].z.a[0][1]"u8).ToString());
            Assert.AreEqual("value8", jp.GetString("$.x.y[0][1][0].z.a[0][1].b"u8));
            Assert.AreEqual("[{\"b\":\"value9\"},{\"b\":\"value10\"}]", jp.GetJson("$.x.y[0][1][0].z.a[1]"u8).ToString());
            Assert.AreEqual("{\"b\":\"value9\"}", jp.GetJson("$.x.y[0][1][0].z.a[1][0]"u8).ToString());
            Assert.AreEqual("value9", jp.GetString("$.x.y[0][1][0].z.a[1][0].b"u8));
            Assert.AreEqual("{\"b\":\"value10\"}", jp.GetJson("$.x.y[0][1][0].z.a[1][1]"u8).ToString());
            Assert.AreEqual("value10", jp.GetString("$.x.y[0][1][0].z.a[1][1].b"u8));
            Assert.AreEqual("[[{\"z\":{\"a\":[[{\"b\":\"value11\"}]]}}]]", jp.GetJson("$.x.y[1]"u8).ToString());
            Assert.AreEqual("[{\"z\":{\"a\":[[{\"b\":\"value11\"}]]}}]", jp.GetJson("$.x.y[1][0]"u8).ToString());
            Assert.AreEqual("{\"z\":{\"a\":[[{\"b\":\"value11\"}]]}}", jp.GetJson("$.x.y[1][0][0]"u8).ToString());
            Assert.AreEqual("{\"a\":[[{\"b\":\"value11\"}]]}", jp.GetJson("$.x.y[1][0][0].z"u8).ToString());
            Assert.AreEqual("[[{\"b\":\"value11\"}]]", jp.GetJson("$.x.y[1][0][0].z.a"u8).ToString());
            Assert.AreEqual("[{\"b\":\"value11\"}]", jp.GetJson("$.x.y[1][0][0].z.a[0]"u8).ToString());
            Assert.AreEqual("{\"b\":\"value11\"}", jp.GetJson("$.x.y[1][0][0].z.a[0][0]"u8).ToString());
            Assert.AreEqual("value11", jp.GetString("$.x.y[1][0][0].z.a[0][0].b"u8));

            Assert.AreEqual("{\"x\":{\"y\":[[[{\"z\":{\"a\":[[{\"b\":\"value1\"},{\"b\":\"value2\"}],[{\"b\":\"value3\"},{\"b\":\"value4\"}]]}},{\"z\":{\"a\":[[{\"b\":\"value5\"},{\"b\":\"value6\"}]]}}],[{\"z\":{\"a\":[[{\"b\":\"value7\"},{\"b\":\"value8\"}],[{\"b\":\"value9\"},{\"b\":\"value10\"}]]}}]],[[{\"z\":{\"a\":[[{\"b\":\"value11\"}]]}}]]]}}", jp.ToString("J"));
        }

        [Test]
        public void Insert_ThreeDimensionTwoDimension()
        {
            JsonPatch jp = new();

            jp.Append("$.x.y[0][0][0].z.a[0]"u8, "value1");

            Assert.AreEqual("{\"y\":[[[{\"z\":{\"a\":[[\"value1\"]]}}]]]}", jp.GetJson("$.x"u8).ToString());

            jp.Append("$.x.y[0][0][0].z.a[0]"u8, "value2");

            Assert.AreEqual("{\"y\":[[[{\"z\":{\"a\":[[\"value1\",\"value2\"]]}}]]]}", jp.GetJson("$.x"u8).ToString());

            jp.Append("$.x.y[0][0][0].z.a[1]"u8, "value3");

            Assert.AreEqual("{\"y\":[[[{\"z\":{\"a\":[[\"value1\",\"value2\"],[\"value3\"]]}}]]]}", jp.GetJson("$.x"u8).ToString());

            jp.Append("$.x.y[0][0][0].z.a[1]"u8, "value4");

            Assert.AreEqual("{\"y\":[[[{\"z\":{\"a\":[[\"value1\",\"value2\"],[\"value3\",\"value4\"]]}}]]]}", jp.GetJson("$.x"u8).ToString());

            jp.Append("$.x.y[0][0]"u8, "{\"z\":{\"a\":[[\"value5\"]]}}"u8);

            Assert.AreEqual("{\"y\":[[[{\"z\":{\"a\":[[\"value1\",\"value2\"],[\"value3\",\"value4\"]]}},{\"z\":{\"a\":[[\"value5\"]]}}]]]}", jp.GetJson("$.x"u8).ToString());

            jp.Append("$.x.y[0][0][1].z.a[0]"u8, "value6");

            Assert.AreEqual("{\"y\":[[[{\"z\":{\"a\":[[\"value1\",\"value2\"],[\"value3\",\"value4\"]]}},{\"z\":{\"a\":[[\"value5\",\"value6\"]]}}]]]}", jp.GetJson("$.x"u8).ToString());

            jp.Append("$.x.y[0][1]"u8, "{\"z\":{\"a\":[[\"value7\"]]}}"u8);

            Assert.AreEqual("{\"y\":[[[{\"z\":{\"a\":[[\"value1\",\"value2\"],[\"value3\",\"value4\"]]}},{\"z\":{\"a\":[[\"value5\",\"value6\"]]}}],[{\"z\":{\"a\":[[\"value7\"]]}}]]]}", jp.GetJson("$.x"u8).ToString());

            jp.Append("$.x.y[0][1][0].z.a[0]"u8, "value8");

            Assert.AreEqual("{\"y\":[[[{\"z\":{\"a\":[[\"value1\",\"value2\"],[\"value3\",\"value4\"]]}},{\"z\":{\"a\":[[\"value5\",\"value6\"]]}}],[{\"z\":{\"a\":[[\"value7\",\"value8\"]]}}]]]}", jp.GetJson("$.x"u8).ToString());

            jp.Append("$.x.y[0][1][0].z.a[1]"u8, "value9");

            Assert.AreEqual("{\"y\":[[[{\"z\":{\"a\":[[\"value1\",\"value2\"],[\"value3\",\"value4\"]]}},{\"z\":{\"a\":[[\"value5\",\"value6\"]]}}],[{\"z\":{\"a\":[[\"value7\",\"value8\"],[\"value9\"]]}}]]]}", jp.GetJson("$.x"u8).ToString());

            jp.Append("$.x.y[0][1][0].z.a[1]"u8, "value10");

            Assert.AreEqual("{\"y\":[[[{\"z\":{\"a\":[[\"value1\",\"value2\"],[\"value3\",\"value4\"]]}},{\"z\":{\"a\":[[\"value5\",\"value6\"]]}}],[{\"z\":{\"a\":[[\"value7\",\"value8\"],[\"value9\",\"value10\"]]}}]]]}", jp.GetJson("$.x"u8).ToString());

            jp.Append("$.x.y[1]"u8, "[{\"z\":{\"a\":[[\"value11\"]]}}]"u8);

            Assert.AreEqual("{\"y\":[[[{\"z\":{\"a\":[[\"value1\",\"value2\"],[\"value3\",\"value4\"]]}},{\"z\":{\"a\":[[\"value5\",\"value6\"]]}}],[{\"z\":{\"a\":[[\"value7\",\"value8\"],[\"value9\",\"value10\"]]}}]],[[{\"z\":{\"a\":[[\"value11\"]]}}]]]}", jp.GetJson("$.x"u8).ToString());
            Assert.AreEqual("[[[{\"z\":{\"a\":[[\"value1\",\"value2\"],[\"value3\",\"value4\"]]}},{\"z\":{\"a\":[[\"value5\",\"value6\"]]}}],[{\"z\":{\"a\":[[\"value7\",\"value8\"],[\"value9\",\"value10\"]]}}]],[[{\"z\":{\"a\":[[\"value11\"]]}}]]]", jp.GetJson("$.x.y"u8).ToString());
            Assert.AreEqual("[[{\"z\":{\"a\":[[\"value1\",\"value2\"],[\"value3\",\"value4\"]]}},{\"z\":{\"a\":[[\"value5\",\"value6\"]]}}],[{\"z\":{\"a\":[[\"value7\",\"value8\"],[\"value9\",\"value10\"]]}}]]", jp.GetJson("$.x.y[0]"u8).ToString());
            Assert.AreEqual("[{\"z\":{\"a\":[[\"value1\",\"value2\"],[\"value3\",\"value4\"]]}},{\"z\":{\"a\":[[\"value5\",\"value6\"]]}}]", jp.GetJson("$.x.y[0][0]"u8).ToString());
            Assert.AreEqual("{\"z\":{\"a\":[[\"value1\",\"value2\"],[\"value3\",\"value4\"]]}}", jp.GetJson("$.x.y[0][0][0]"u8).ToString());
            Assert.AreEqual("{\"a\":[[\"value1\",\"value2\"],[\"value3\",\"value4\"]]}", jp.GetJson("$.x.y[0][0][0].z"u8).ToString());
            Assert.AreEqual("[[\"value1\",\"value2\"],[\"value3\",\"value4\"]]", jp.GetJson("$.x.y[0][0][0].z.a"u8).ToString());
            Assert.AreEqual("[\"value1\",\"value2\"]", jp.GetJson("$.x.y[0][0][0].z.a[0]"u8).ToString());
            Assert.AreEqual("value1", jp.GetString("$.x.y[0][0][0].z.a[0][0]"u8));
            Assert.AreEqual("value2", jp.GetString("$.x.y[0][0][0].z.a[0][1]"u8));
            Assert.AreEqual("[\"value3\",\"value4\"]", jp.GetJson("$.x.y[0][0][0].z.a[1]"u8).ToString());
            Assert.AreEqual("value3", jp.GetString("$.x.y[0][0][0].z.a[1][0]"u8));
            Assert.AreEqual("value4", jp.GetString("$.x.y[0][0][0].z.a[1][1]"u8));
            Assert.AreEqual("{\"z\":{\"a\":[[\"value5\",\"value6\"]]}}", jp.GetJson("$.x.y[0][0][1]"u8).ToString());
            Assert.AreEqual("{\"a\":[[\"value5\",\"value6\"]]}", jp.GetJson("$.x.y[0][0][1].z"u8).ToString());
            Assert.AreEqual("[[\"value5\",\"value6\"]]", jp.GetJson("$.x.y[0][0][1].z.a"u8).ToString());
            Assert.AreEqual("[\"value5\",\"value6\"]", jp.GetJson("$.x.y[0][0][1].z.a[0]"u8).ToString());
            Assert.AreEqual("value5", jp.GetString("$.x.y[0][0][1].z.a[0][0]"u8));
            Assert.AreEqual("value6", jp.GetString("$.x.y[0][0][1].z.a[0][1]"u8));
            Assert.AreEqual("[{\"z\":{\"a\":[[\"value7\",\"value8\"],[\"value9\",\"value10\"]]}}]", jp.GetJson("$.x.y[0][1]"u8).ToString());
            Assert.AreEqual("{\"z\":{\"a\":[[\"value7\",\"value8\"],[\"value9\",\"value10\"]]}}", jp.GetJson("$.x.y[0][1][0]"u8).ToString());
            Assert.AreEqual("{\"a\":[[\"value7\",\"value8\"],[\"value9\",\"value10\"]]}", jp.GetJson("$.x.y[0][1][0].z"u8).ToString());
            Assert.AreEqual("[[\"value7\",\"value8\"],[\"value9\",\"value10\"]]", jp.GetJson("$.x.y[0][1][0].z.a"u8).ToString());
            Assert.AreEqual("[\"value7\",\"value8\"]", jp.GetJson("$.x.y[0][1][0].z.a[0]"u8).ToString());
            Assert.AreEqual("value7", jp.GetString("$.x.y[0][1][0].z.a[0][0]"u8));
            Assert.AreEqual("value8", jp.GetString("$.x.y[0][1][0].z.a[0][1]"u8));
            Assert.AreEqual("[\"value9\",\"value10\"]", jp.GetJson("$.x.y[0][1][0].z.a[1]"u8).ToString());
            Assert.AreEqual("value9", jp.GetString("$.x.y[0][1][0].z.a[1][0]"u8));
            Assert.AreEqual("value10", jp.GetString("$.x.y[0][1][0].z.a[1][1]"u8));
            Assert.AreEqual("[[{\"z\":{\"a\":[[\"value11\"]]}}]]", jp.GetJson("$.x.y[1]"u8).ToString());
            Assert.AreEqual("[{\"z\":{\"a\":[[\"value11\"]]}}]", jp.GetJson("$.x.y[1][0]"u8).ToString());
            Assert.AreEqual("{\"z\":{\"a\":[[\"value11\"]]}}", jp.GetJson("$.x.y[1][0][0]"u8).ToString());
            Assert.AreEqual("{\"a\":[[\"value11\"]]}", jp.GetJson("$.x.y[1][0][0].z"u8).ToString());
            Assert.AreEqual("[[\"value11\"]]", jp.GetJson("$.x.y[1][0][0].z.a"u8).ToString());
            Assert.AreEqual("[\"value11\"]", jp.GetJson("$.x.y[1][0][0].z.a[0]"u8).ToString());
            Assert.AreEqual("value11", jp.GetString("$.x.y[1][0][0].z.a[0][0]"u8));

            Assert.AreEqual("{\"x\":{\"y\":[[[{\"z\":{\"a\":[[\"value1\",\"value2\"],[\"value3\",\"value4\"]]}},{\"z\":{\"a\":[[\"value5\",\"value6\"]]}}],[{\"z\":{\"a\":[[\"value7\",\"value8\"],[\"value9\",\"value10\"]]}}]],[[{\"z\":{\"a\":[[\"value11\"]]}}]]]}}", jp.ToString("J"));
        }

        [Test]
        public void RootAndInsert_TwoDimensionTwoLevel_WithProperty()
        {
            JsonPatch jp = new("{\"x\":{\"y\":[[{\"a\":\"value1\"},{\"a\":\"value2\"}],[{\"a\":\"value3\"},{\"a\":\"value4\"}]]}}"u8.ToArray());

            Assert.AreEqual("{\"y\":[[{\"a\":\"value1\"},{\"a\":\"value2\"}],[{\"a\":\"value3\"},{\"a\":\"value4\"}]]}", jp.GetJson("$.x"u8).ToString());
            Assert.AreEqual("[[{\"a\":\"value1\"},{\"a\":\"value2\"}],[{\"a\":\"value3\"},{\"a\":\"value4\"}]]", jp.GetJson("$.x.y"u8).ToString());
            Assert.AreEqual("[{\"a\":\"value1\"},{\"a\":\"value2\"}]", jp.GetJson("$.x.y[0]"u8).ToString());
            Assert.AreEqual("{\"a\":\"value1\"}", jp.GetJson("$.x.y[0][0]"u8).ToString());
            Assert.AreEqual("value1", jp.GetString("$.x.y[0][0].a"u8));
            Assert.AreEqual("{\"a\":\"value2\"}", jp.GetJson("$.x.y[0][1]"u8).ToString());
            Assert.AreEqual("value2", jp.GetString("$.x.y[0][1].a"u8));
            Assert.AreEqual("[{\"a\":\"value3\"},{\"a\":\"value4\"}]", jp.GetJson("$.x.y[1]"u8).ToString());
            Assert.AreEqual("{\"a\":\"value3\"}", jp.GetJson("$.x.y[1][0]"u8).ToString());
            Assert.AreEqual("value3", jp.GetString("$.x.y[1][0].a"u8));
            Assert.AreEqual("{\"a\":\"value4\"}", jp.GetJson("$.x.y[1][1]"u8).ToString());
            Assert.AreEqual("value4", jp.GetString("$.x.y[1][1].a"u8));

            jp.Append("$.x.y[0]"u8, "{\"a\":\"value5\"}"u8);

            Assert.AreEqual("[{\"a\":\"value1\"},{\"a\":\"value2\"},{\"a\":\"value5\"}]", jp.GetJson("$.x.y[0]"u8).ToString());

            jp.Append("$.x.y[0]"u8, "{\"a\":\"value6\"}"u8);

            Assert.AreEqual("[{\"a\":\"value1\"},{\"a\":\"value2\"},{\"a\":\"value5\"},{\"a\":\"value6\"}]", jp.GetJson("$.x.y[0]"u8).ToString());

            jp.Append("$.x.y[1]"u8, "{\"a\":\"value7\"}"u8);

            Assert.AreEqual("[{\"a\":\"value3\"},{\"a\":\"value4\"},{\"a\":\"value7\"}]", jp.GetJson("$.x.y[1]"u8).ToString());

            jp.Append("$.x.y[1]"u8, "{\"a\":\"value8\"}"u8);

            Assert.AreEqual("[{\"a\":\"value3\"},{\"a\":\"value4\"},{\"a\":\"value7\"},{\"a\":\"value8\"}]", jp.GetJson("$.x.y[1]"u8).ToString());

            jp.Append("$.x.y"u8, "[{\"a\":\"value9\"}]"u8);

            Assert.AreEqual("[[{\"a\":\"value1\"},{\"a\":\"value2\"},{\"a\":\"value5\"},{\"a\":\"value6\"}],[{\"a\":\"value3\"},{\"a\":\"value4\"},{\"a\":\"value7\"},{\"a\":\"value8\"}],[{\"a\":\"value9\"}]]", jp.GetJson("$.x.y"u8).ToString());
            Assert.AreEqual("[{\"a\":\"value1\"},{\"a\":\"value2\"},{\"a\":\"value5\"},{\"a\":\"value6\"}]", jp.GetJson("$.x.y[0]"u8).ToString());
            Assert.AreEqual("{\"a\":\"value1\"}", jp.GetJson("$.x.y[0][0]"u8).ToString());
            Assert.AreEqual("value1", jp.GetString("$.x.y[0][0].a"u8));
            Assert.AreEqual("{\"a\":\"value2\"}", jp.GetJson("$.x.y[0][1]"u8).ToString());
            Assert.AreEqual("value2", jp.GetString("$.x.y[0][1].a"u8));
            Assert.AreEqual("{\"a\":\"value5\"}", jp.GetJson("$.x.y[0][2]"u8).ToString());
            Assert.AreEqual("value5", jp.GetString("$.x.y[0][2].a"u8));
            Assert.AreEqual("{\"a\":\"value6\"}", jp.GetJson("$.x.y[0][3]"u8).ToString());
            Assert.AreEqual("value6", jp.GetString("$.x.y[0][3].a"u8));
            Assert.AreEqual("[{\"a\":\"value3\"},{\"a\":\"value4\"},{\"a\":\"value7\"},{\"a\":\"value8\"}]", jp.GetJson("$.x.y[1]"u8).ToString());
            Assert.AreEqual("{\"a\":\"value3\"}", jp.GetJson("$.x.y[1][0]"u8).ToString());
            Assert.AreEqual("value3", jp.GetString("$.x.y[1][0].a"u8));
            Assert.AreEqual("{\"a\":\"value4\"}", jp.GetJson("$.x.y[1][1]"u8).ToString());
            Assert.AreEqual("value4", jp.GetString("$.x.y[1][1].a"u8));
            Assert.AreEqual("{\"a\":\"value7\"}", jp.GetJson("$.x.y[1][2]"u8).ToString());
            Assert.AreEqual("value7", jp.GetString("$.x.y[1][2].a"u8));
            Assert.AreEqual("{\"a\":\"value8\"}", jp.GetJson("$.x.y[1][3]"u8).ToString());
            Assert.AreEqual("value8", jp.GetString("$.x.y[1][3].a"u8));
            Assert.AreEqual("[{\"a\":\"value9\"}]", jp.GetJson("$.x.y[2]"u8).ToString());
            Assert.AreEqual("{\"a\":\"value9\"}", jp.GetJson("$.x.y[2][0]"u8).ToString());
            Assert.AreEqual("value9", jp.GetString("$.x.y[2][0].a"u8));

            Assert.AreEqual("{\"x\":{\"y\":[[{\"a\":\"value1\"},{\"a\":\"value2\"},{\"a\":\"value5\"},{\"a\":\"value6\"}],[{\"a\":\"value3\"},{\"a\":\"value4\"},{\"a\":\"value7\"},{\"a\":\"value8\"}],[{\"a\":\"value9\"}]]}}", jp.ToString("J"));
        }

        [Test]
        public void RootAndInsert_TwoDimensionTwoLevel()
        {
            JsonPatch jp = new("{\"x\":{\"y\":[[\"value1\",\"value2\"],[\"value3\",\"value4\"]]}}"u8.ToArray());

            Assert.AreEqual("{\"y\":[[\"value1\",\"value2\"],[\"value3\",\"value4\"]]}", jp.GetJson("$.x"u8).ToString());
            Assert.AreEqual("[[\"value1\",\"value2\"],[\"value3\",\"value4\"]]", jp.GetJson("$.x.y"u8).ToString());
            Assert.AreEqual("[\"value1\",\"value2\"]", jp.GetJson("$.x.y[0]"u8).ToString());
            Assert.AreEqual("value1", jp.GetString("$.x.y[0][0]"u8));
            Assert.AreEqual("value2", jp.GetString("$.x.y[0][1]"u8));
            Assert.AreEqual("[\"value3\",\"value4\"]", jp.GetJson("$.x.y[1]"u8).ToString());
            Assert.AreEqual("value3", jp.GetString("$.x.y[1][0]"u8));
            Assert.AreEqual("value4", jp.GetString("$.x.y[1][1]"u8));

            jp.Append("$.x.y[0]"u8, "value5");

            Assert.AreEqual("[\"value1\",\"value2\",\"value5\"]", jp.GetJson("$.x.y[0]"u8).ToString());

            jp.Append("$.x.y[0]"u8, "value6");

            Assert.AreEqual("[\"value1\",\"value2\",\"value5\",\"value6\"]", jp.GetJson("$.x.y[0]"u8).ToString());

            jp.Append("$.x.y[1]"u8, "value7");

            Assert.AreEqual("[\"value3\",\"value4\",\"value7\"]", jp.GetJson("$.x.y[1]"u8).ToString());

            jp.Append("$.x.y[1]"u8, "value8");

            Assert.AreEqual("[\"value3\",\"value4\",\"value7\",\"value8\"]", jp.GetJson("$.x.y[1]"u8).ToString());

            jp.Append("$.x.y"u8, "[\"value9\"]"u8);

            Assert.AreEqual("{\"y\":[[\"value1\",\"value2\"],[\"value3\",\"value4\"]]}", jp.GetJson("$.x"u8).ToString());
            Assert.AreEqual("[[\"value1\",\"value2\",\"value5\",\"value6\"],[\"value3\",\"value4\",\"value7\",\"value8\"],[\"value9\"]]", jp.GetJson("$.x.y"u8).ToString());
            Assert.AreEqual("[\"value1\",\"value2\",\"value5\",\"value6\"]", jp.GetJson("$.x.y[0]"u8).ToString());
            Assert.AreEqual("value1", jp.GetString("$.x.y[0][0]"u8));
            Assert.AreEqual("value2", jp.GetString("$.x.y[0][1]"u8));
            Assert.AreEqual("value5", jp.GetString("$.x.y[0][2]"u8));
            Assert.AreEqual("value6", jp.GetString("$.x.y[0][3]"u8));
            Assert.AreEqual("[\"value3\",\"value4\",\"value7\",\"value8\"]", jp.GetJson("$.x.y[1]"u8).ToString());
            Assert.AreEqual("value3", jp.GetString("$.x.y[1][0]"u8));
            Assert.AreEqual("value4", jp.GetString("$.x.y[1][1]"u8));
            Assert.AreEqual("value7", jp.GetString("$.x.y[1][2]"u8));
            Assert.AreEqual("value8", jp.GetString("$.x.y[1][3]"u8));
            Assert.AreEqual("[\"value9\"]", jp.GetJson("$.x.y[2]"u8).ToString());
            Assert.AreEqual("value9", jp.GetString("$.x.y[2][0]"u8));

            Assert.AreEqual("{\"x\":{\"y\":[[\"value1\",\"value2\",\"value5\",\"value6\"],[\"value3\",\"value4\",\"value7\",\"value8\"],[\"value9\"]]}}", jp.ToString("J"));
        }

        [Test]
        public void Insert_TwoDimensionTwoLevel_WithProperty()
        {
            JsonPatch jp = new();

            jp.Append("$.x.y[0]"u8, "{\"a\":\"value1\"}"u8);

            Assert.AreEqual("{\"y\":[[{\"a\":\"value1\"}]]}", jp.GetJson("$.x"u8).ToString());

            jp.Append("$.x.y[0]"u8, "{\"a\":\"value2\"}"u8);

            Assert.AreEqual("{\"y\":[[{\"a\":\"value1\"},{\"a\":\"value2\"}]]}", jp.GetJson("$.x"u8).ToString());

            jp.Append("$.x.y[1]"u8, "{\"a\":\"value3\"}"u8);

            Assert.AreEqual("{\"y\":[[{\"a\":\"value1\"},{\"a\":\"value2\"}],[{\"a\":\"value3\"}]]}", jp.GetJson("$.x"u8).ToString());

            jp.Append("$.x.y[1]"u8, "{\"a\":\"value4\"}"u8);

            Assert.AreEqual("{\"y\":[[{\"a\":\"value1\"},{\"a\":\"value2\"}],[{\"a\":\"value3\"},{\"a\":\"value4\"}]]}", jp.GetJson("$.x"u8).ToString());

            jp.Append("$.x.y"u8, "[{\"a\":\"value5\"}]"u8);

            Assert.AreEqual("{\"y\":[[{\"a\":\"value1\"},{\"a\":\"value2\"}],[{\"a\":\"value3\"},{\"a\":\"value4\"}],[{\"a\":\"value5\"}]]}", jp.GetJson("$.x"u8).ToString());
            Assert.AreEqual("[[{\"a\":\"value1\"},{\"a\":\"value2\"}],[{\"a\":\"value3\"},{\"a\":\"value4\"}],[{\"a\":\"value5\"}]]", jp.GetJson("$.x.y"u8).ToString());
            Assert.AreEqual("[{\"a\":\"value1\"},{\"a\":\"value2\"}]", jp.GetJson("$.x.y[0]"u8).ToString());
            Assert.AreEqual("{\"a\":\"value1\"}", jp.GetJson("$.x.y[0][0]"u8).ToString());
            Assert.AreEqual("value1", jp.GetString("$.x.y[0][0].a"u8));
            Assert.AreEqual("{\"a\":\"value2\"}", jp.GetJson("$.x.y[0][1]"u8).ToString());
            Assert.AreEqual("value2", jp.GetString("$.x.y[0][1].a"u8));
            Assert.AreEqual("[{\"a\":\"value3\"},{\"a\":\"value4\"}]", jp.GetJson("$.x.y[1]"u8).ToString());
            Assert.AreEqual("{\"a\":\"value3\"}", jp.GetJson("$.x.y[1][0]"u8).ToString());
            Assert.AreEqual("value3", jp.GetString("$.x.y[1][0].a"u8));
            Assert.AreEqual("{\"a\":\"value4\"}", jp.GetJson("$.x.y[1][1]"u8).ToString());
            Assert.AreEqual("value4", jp.GetString("$.x.y[1][1].a"u8));
            Assert.AreEqual("[{\"a\":\"value5\"}]", jp.GetJson("$.x.y[2]"u8).ToString());
            Assert.AreEqual("{\"a\":\"value5\"}", jp.GetJson("$.x.y[2][0]"u8).ToString());
            Assert.AreEqual("value5", jp.GetString("$.x.y[2][0].a"u8));

            Assert.AreEqual("{\"x\":{\"y\":[[{\"a\":\"value1\"},{\"a\":\"value2\"}],[{\"a\":\"value3\"},{\"a\":\"value4\"}],[{\"a\":\"value5\"}]]}}", jp.ToString("J"));
        }

        [Test]
        public void Insert_TwoDimensionTwoLevel()
        {
            JsonPatch jp = new();

            jp.Append("$.x.y[0]"u8, "value1");

            Assert.AreEqual("{\"y\":[[\"value1\"]]}", jp.GetJson("$.x"u8).ToString());

            jp.Append("$.x.y[0]"u8, "value2");

            Assert.AreEqual("{\"y\":[[\"value1\",\"value2\"]]}", jp.GetJson("$.x"u8).ToString());

            jp.Append("$.x.y[1]"u8, "value3");

            Assert.AreEqual("{\"y\":[[\"value1\",\"value2\"],[\"value3\"]]}", jp.GetJson("$.x"u8).ToString());

            jp.Append("$.x.y[1]"u8, "value4");

            Assert.AreEqual("{\"y\":[[\"value1\",\"value2\"],[\"value3\",\"value4\"]]}", jp.GetJson("$.x"u8).ToString());

            jp.Append("$.x.y"u8, "[\"value5\"]"u8);

            Assert.AreEqual("{\"y\":[[\"value1\",\"value2\"],[\"value3\",\"value4\"],[\"value5\"]]}", jp.GetJson("$.x"u8).ToString());
            Assert.AreEqual("[[\"value1\",\"value2\"],[\"value3\",\"value4\"],[\"value5\"]]", jp.GetJson("$.x.y"u8).ToString());
            Assert.AreEqual("[\"value1\",\"value2\"]", jp.GetJson("$.x.y[0]"u8).ToString());
            Assert.AreEqual("value1", jp.GetString("$.x.y[0][0]"u8));
            Assert.AreEqual("value2", jp.GetString("$.x.y[0][1]"u8));
            Assert.AreEqual("[\"value3\",\"value4\"]", jp.GetJson("$.x.y[1]"u8).ToString());
            Assert.AreEqual("value3", jp.GetString("$.x.y[1][0]"u8));
            Assert.AreEqual("value4", jp.GetString("$.x.y[1][1]"u8));
            Assert.AreEqual("[\"value5\"]", jp.GetJson("$.x.y[2]"u8).ToString());
            Assert.AreEqual("value5", jp.GetString("$.x.y[2][0]"u8));

            Assert.AreEqual("{\"x\":{\"y\":[[\"value1\",\"value2\"],[\"value3\",\"value4\"],[\"value5\"]]}}", jp.ToString("J"));
        }

        [Test]
        public void RootAndInsert_TwoDimensionOneLevel_WithProperty()
        {
            JsonPatch jp = new("{\"x\":[[{\"a\":\"value1\"},{\"a\":\"value2\"}],[{\"a\":\"value3\"},{\"a\":\"value4\"}]]}"u8.ToArray());

            Assert.AreEqual("[[{\"a\":\"value1\"},{\"a\":\"value2\"}],[{\"a\":\"value3\"},{\"a\":\"value4\"}]]", jp.GetJson("$.x"u8).ToString());
            Assert.AreEqual("[{\"a\":\"value1\"},{\"a\":\"value2\"}]", jp.GetJson("$.x[0]"u8).ToString());
            Assert.AreEqual("{\"a\":\"value1\"}", jp.GetJson("$.x[0][0]"u8).ToString());
            Assert.AreEqual("value1", jp.GetString("$.x[0][0].a"u8));
            Assert.AreEqual("{\"a\":\"value2\"}", jp.GetJson("$.x[0][1]"u8).ToString());
            Assert.AreEqual("value2", jp.GetString("$.x[0][1].a"u8));
            Assert.AreEqual("[{\"a\":\"value3\"},{\"a\":\"value4\"}]", jp.GetJson("$.x[1]"u8).ToString());
            Assert.AreEqual("{\"a\":\"value3\"}", jp.GetJson("$.x[1][0]"u8).ToString());
            Assert.AreEqual("value3", jp.GetString("$.x[1][0].a"u8));
            Assert.AreEqual("{\"a\":\"value4\"}", jp.GetJson("$.x[1][1]"u8).ToString());
            Assert.AreEqual("value4", jp.GetString("$.x[1][1].a"u8));

            jp.Append("$.x[0]"u8, "{\"a\":\"value5\"}"u8);

            Assert.AreEqual("[{\"a\":\"value1\"},{\"a\":\"value2\"},{\"a\":\"value5\"}]", jp.GetJson("$.x[0]"u8).ToString());

            jp.Append("$.x[0]"u8, "{\"a\":\"value6\"}"u8);

            Assert.AreEqual("[{\"a\":\"value1\"},{\"a\":\"value2\"},{\"a\":\"value5\"},{\"a\":\"value6\"}]", jp.GetJson("$.x[0]"u8).ToString());

            jp.Append("$.x[1]"u8, "{\"a\":\"value7\"}"u8);

            Assert.AreEqual("[{\"a\":\"value3\"},{\"a\":\"value4\"},{\"a\":\"value7\"}]", jp.GetJson("$.x[1]"u8).ToString());

            jp.Append("$.x[1]"u8, "{\"a\":\"value8\"}"u8);

            Assert.AreEqual("[{\"a\":\"value3\"},{\"a\":\"value4\"},{\"a\":\"value7\"},{\"a\":\"value8\"}]", jp.GetJson("$.x[1]"u8).ToString());

            jp.Append("$.x"u8, "[{\"a\":\"value9\"}]"u8);

            Assert.AreEqual("[[{\"a\":\"value1\"},{\"a\":\"value2\"},{\"a\":\"value5\"},{\"a\":\"value6\"}],[{\"a\":\"value3\"},{\"a\":\"value4\"},{\"a\":\"value7\"},{\"a\":\"value8\"}],[{\"a\":\"value9\"}]]", jp.GetJson("$.x"u8).ToString());
            Assert.AreEqual("[{\"a\":\"value1\"},{\"a\":\"value2\"},{\"a\":\"value5\"},{\"a\":\"value6\"}]", jp.GetJson("$.x[0]"u8).ToString());
            Assert.AreEqual("{\"a\":\"value1\"}", jp.GetJson("$.x[0][0]"u8).ToString());
            Assert.AreEqual("value1", jp.GetString("$.x[0][0].a"u8));
            Assert.AreEqual("{\"a\":\"value2\"}", jp.GetJson("$.x[0][1]"u8).ToString());
            Assert.AreEqual("value2", jp.GetString("$.x[0][1].a"u8));
            Assert.AreEqual("{\"a\":\"value5\"}", jp.GetJson("$.x[0][2]"u8).ToString());
            Assert.AreEqual("value5", jp.GetString("$.x[0][2].a"u8));
            Assert.AreEqual("{\"a\":\"value6\"}", jp.GetJson("$.x[0][3]"u8).ToString());
            Assert.AreEqual("value6", jp.GetString("$.x[0][3].a"u8));
            Assert.AreEqual("[{\"a\":\"value3\"},{\"a\":\"value4\"},{\"a\":\"value7\"},{\"a\":\"value8\"}]", jp.GetJson("$.x[1]"u8).ToString());
            Assert.AreEqual("{\"a\":\"value3\"}", jp.GetJson("$.x[1][0]"u8).ToString());
            Assert.AreEqual("value3", jp.GetString("$.x[1][0].a"u8));
            Assert.AreEqual("{\"a\":\"value4\"}", jp.GetJson("$.x[1][1]"u8).ToString());
            Assert.AreEqual("value4", jp.GetString("$.x[1][1].a"u8));
            Assert.AreEqual("{\"a\":\"value7\"}", jp.GetJson("$.x[1][2]"u8).ToString());
            Assert.AreEqual("value7", jp.GetString("$.x[1][2].a"u8));
            Assert.AreEqual("{\"a\":\"value8\"}", jp.GetJson("$.x[1][3]"u8).ToString());
            Assert.AreEqual("value8", jp.GetString("$.x[1][3].a"u8));
            Assert.AreEqual("[{\"a\":\"value9\"}]", jp.GetJson("$.x[2]"u8).ToString());
            Assert.AreEqual("{\"a\":\"value9\"}", jp.GetJson("$.x[2][0]"u8).ToString());
            Assert.AreEqual("value9", jp.GetString("$.x[2][0].a"u8));

            Assert.AreEqual("{\"x\":[[{\"a\":\"value1\"},{\"a\":\"value2\"},{\"a\":\"value5\"},{\"a\":\"value6\"}],[{\"a\":\"value3\"},{\"a\":\"value4\"},{\"a\":\"value7\"},{\"a\":\"value8\"}],[{\"a\":\"value9\"}]]}", jp.ToString("J"));
        }

        [Test]
        public void RootAndInsert_TwoDimensionOneLevel()
        {
            JsonPatch jp = new("{\"x\":[[\"value1\",\"value2\"],[\"value3\",\"value4\"]]}"u8.ToArray());

            Assert.AreEqual("[[\"value1\",\"value2\"],[\"value3\",\"value4\"]]", jp.GetJson("$.x"u8).ToString());
            Assert.AreEqual("[\"value1\",\"value2\"]", jp.GetJson("$.x[0]"u8).ToString());
            Assert.AreEqual("value1", jp.GetString("$.x[0][0]"u8));
            Assert.AreEqual("value2", jp.GetString("$.x[0][1]"u8));
            Assert.AreEqual("[\"value3\",\"value4\"]", jp.GetJson("$.x[1]"u8).ToString());
            Assert.AreEqual("value3", jp.GetString("$.x[1][0]"u8));
            Assert.AreEqual("value4", jp.GetString("$.x[1][1]"u8));

            jp.Append("$.x[0]"u8, "value5");

            Assert.AreEqual("[\"value1\",\"value2\",\"value5\"]", jp.GetJson("$.x[0]"u8).ToString());

            jp.Append("$.x[0]"u8, "value6");

            Assert.AreEqual("[\"value1\",\"value2\",\"value5\",\"value6\"]", jp.GetJson("$.x[0]"u8).ToString());

            jp.Append("$.x[1]"u8, "value7");

            Assert.AreEqual("[\"value3\",\"value4\",\"value7\"]", jp.GetJson("$.x[1]"u8).ToString());

            jp.Append("$.x[1]"u8, "value8");

            Assert.AreEqual("[\"value3\",\"value4\",\"value7\",\"value8\"]", jp.GetJson("$.x[1]"u8).ToString());

            jp.Append("$.x"u8, "[\"value9\"]"u8);

            Assert.AreEqual("[[\"value1\",\"value2\",\"value5\",\"value6\"],[\"value3\",\"value4\",\"value7\",\"value8\"],[\"value9\"]]", jp.GetJson("$.x"u8).ToString());
            Assert.AreEqual("[\"value1\",\"value2\",\"value5\",\"value6\"]", jp.GetJson("$.x[0]"u8).ToString());
            Assert.AreEqual("value1", jp.GetString("$.x[0][0]"u8));
            Assert.AreEqual("value2", jp.GetString("$.x[0][1]"u8));
            Assert.AreEqual("value5", jp.GetString("$.x[0][2]"u8));
            Assert.AreEqual("value6", jp.GetString("$.x[0][3]"u8));
            Assert.AreEqual("[\"value3\",\"value4\",\"value7\",\"value8\"]", jp.GetJson("$.x[1]"u8).ToString());
            Assert.AreEqual("value3", jp.GetString("$.x[1][0]"u8));
            Assert.AreEqual("value4", jp.GetString("$.x[1][1]"u8));
            Assert.AreEqual("value7", jp.GetString("$.x[1][2]"u8));
            Assert.AreEqual("value8", jp.GetString("$.x[1][3]"u8));
            Assert.AreEqual("[\"value9\"]", jp.GetJson("$.x[2]"u8).ToString());
            Assert.AreEqual("value9", jp.GetString("$.x[2][0]"u8));

            Assert.AreEqual("{\"x\":[[\"value1\",\"value2\",\"value5\",\"value6\"],[\"value3\",\"value4\",\"value7\",\"value8\"],[\"value9\"]]}", jp.ToString("J"));
        }

        [Test]
        public void Insert_TwoDimensionOneLevel_WithProperty()
        {
            JsonPatch jp = new();

            jp.Append("$.x[0]"u8, "{\"a\":\"value1\"}"u8);

            Assert.AreEqual("[[{\"a\":\"value1\"}]]", jp.GetJson("$.x"u8).ToString());

            jp.Append("$.x[0]"u8, "{\"a\":\"value2\"}"u8);

            Assert.AreEqual("[[{\"a\":\"value1\"},{\"a\":\"value2\"}]]", jp.GetJson("$.x"u8).ToString());

            jp.Append("$.x[1]"u8, "{\"a\":\"value3\"}"u8);

            Assert.AreEqual("[[{\"a\":\"value1\"},{\"a\":\"value2\"}],[{\"a\":\"value3\"}]]", jp.GetJson("$.x"u8).ToString());

            jp.Append("$.x[1]"u8, "{\"a\":\"value4\"}"u8);

            Assert.AreEqual("[[{\"a\":\"value1\"},{\"a\":\"value2\"}],[{\"a\":\"value3\"},{\"a\":\"value4\"}]]", jp.GetJson("$.x"u8).ToString());

            jp.Append("$.x"u8, "[{\"a\":\"value5\"}]"u8);

            Assert.AreEqual("[[{\"a\":\"value1\"},{\"a\":\"value2\"}],[{\"a\":\"value3\"},{\"a\":\"value4\"}],[{\"a\":\"value5\"}]]", jp.GetJson("$.x"u8).ToString());
            Assert.AreEqual("[{\"a\":\"value1\"},{\"a\":\"value2\"}]", jp.GetJson("$.x[0]"u8).ToString());
            Assert.AreEqual("{\"a\":\"value1\"}", jp.GetJson("$.x[0][0]"u8).ToString());
            Assert.AreEqual("value1", jp.GetString("$.x[0][0].a"u8));
            Assert.AreEqual("{\"a\":\"value2\"}", jp.GetJson("$.x[0][1]"u8).ToString());
            Assert.AreEqual("value2", jp.GetString("$.x[0][1].a"u8));
            Assert.AreEqual("[{\"a\":\"value3\"},{\"a\":\"value4\"}]", jp.GetJson("$.x[1]"u8).ToString());
            Assert.AreEqual("{\"a\":\"value3\"}", jp.GetJson("$.x[1][0]"u8).ToString());
            Assert.AreEqual("value3", jp.GetString("$.x[1][0].a"u8));
            Assert.AreEqual("{\"a\":\"value4\"}", jp.GetJson("$.x[1][1]"u8).ToString());
            Assert.AreEqual("value4", jp.GetString("$.x[1][1].a"u8));
            Assert.AreEqual("[{\"a\":\"value5\"}]", jp.GetJson("$.x[2]"u8).ToString());
            Assert.AreEqual("{\"a\":\"value5\"}", jp.GetJson("$.x[2][0]"u8).ToString());
            Assert.AreEqual("value5", jp.GetString("$.x[2][0].a"u8));

            Assert.AreEqual("{\"x\":[[{\"a\":\"value1\"},{\"a\":\"value2\"}],[{\"a\":\"value3\"},{\"a\":\"value4\"}],[{\"a\":\"value5\"}]]}", jp.ToString("J"));
        }

        [Test]
        public void Insert_TwoDimensionOneLevel()
        {
            JsonPatch jp = new();

            jp.Append("$.x[0]"u8, "value1");

            Assert.AreEqual("[[\"value1\"]]", jp.GetJson("$.x"u8).ToString());

            jp.Append("$.x[0]"u8, "value2");

            Assert.AreEqual("[[\"value1\",\"value2\"]]", jp.GetJson("$.x"u8).ToString());

            jp.Append("$.x[1]"u8, "value3");

            Assert.AreEqual("[[\"value1\",\"value2\"],[\"value3\"]]", jp.GetJson("$.x"u8).ToString());

            jp.Append("$.x[1]"u8, "value4");

            Assert.AreEqual("[[\"value1\",\"value2\"],[\"value3\",\"value4\"]]", jp.GetJson("$.x"u8).ToString());

            jp.Append("$.x"u8, "[\"value5\"]"u8);
            Assert.AreEqual("[[\"value1\",\"value2\"],[\"value3\",\"value4\"],[\"value5\"]]", jp.GetJson("$.x"u8).ToString());
            Assert.AreEqual("[\"value1\",\"value2\"]", jp.GetJson("$.x[0]"u8).ToString());
            Assert.AreEqual("value1", jp.GetString("$.x[0][0]"u8));
            Assert.AreEqual("value2", jp.GetString("$.x[0][1]"u8));
            Assert.AreEqual("[\"value3\",\"value4\"]", jp.GetJson("$.x[1]"u8).ToString());
            Assert.AreEqual("value3", jp.GetString("$.x[1][0]"u8));
            Assert.AreEqual("value4", jp.GetString("$.x[1][1]"u8));
            Assert.AreEqual("[\"value5\"]", jp.GetJson("$.x[2]"u8).ToString());
            Assert.AreEqual("value5", jp.GetString("$.x[2][0]"u8));

            Assert.AreEqual("{\"x\":[[\"value1\",\"value2\"],[\"value3\",\"value4\"],[\"value5\"]]}", jp.ToString("J"));
        }

        [Test]
        public void RootAndInsert_TwoDimension_WithProperty()
        {
            JsonPatch jp = new("[[{\"a\":\"value1\"},{\"a\":\"value2\"}],[{\"a\":\"value3\"},{\"a\":\"value4\"}]]"u8.ToArray());

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

            jp.Append("$[0]"u8, "{\"a\":\"value5\"}"u8);

            Assert.AreEqual("[{\"a\":\"value1\"},{\"a\":\"value2\"},{\"a\":\"value5\"}]", jp.GetJson("$[0]"u8).ToString());

            jp.Append("$[0]"u8, "{\"a\":\"value6\"}"u8);

            Assert.AreEqual("[{\"a\":\"value1\"},{\"a\":\"value2\"},{\"a\":\"value5\"},{\"a\":\"value6\"}]", jp.GetJson("$[0]"u8).ToString());

            jp.Append("$[1]"u8, "{\"a\":\"value7\"}"u8);

            Assert.AreEqual("[{\"a\":\"value3\"},{\"a\":\"value4\"},{\"a\":\"value7\"}]", jp.GetJson("$[1]"u8).ToString());

            jp.Append("$[1]"u8, "{\"a\":\"value8\"}"u8);

            Assert.AreEqual("[{\"a\":\"value3\"},{\"a\":\"value4\"},{\"a\":\"value7\"},{\"a\":\"value8\"}]", jp.GetJson("$[1]"u8).ToString());

            jp.Append("$"u8, "[{\"a\":\"value9\"}]"u8);

            Assert.AreEqual("[[{\"a\":\"value1\"},{\"a\":\"value2\"},{\"a\":\"value5\"},{\"a\":\"value6\"}],[{\"a\":\"value3\"},{\"a\":\"value4\"},{\"a\":\"value7\"},{\"a\":\"value8\"}],[{\"a\":\"value9\"}]]", jp.GetJson("$"u8).ToString());
            Assert.AreEqual("[{\"a\":\"value1\"},{\"a\":\"value2\"},{\"a\":\"value5\"},{\"a\":\"value6\"}]", jp.GetJson("$[0]"u8).ToString());
            Assert.AreEqual("{\"a\":\"value1\"}", jp.GetJson("$[0][0]"u8).ToString());
            Assert.AreEqual("value1", jp.GetString("$[0][0].a"u8));
            Assert.AreEqual("{\"a\":\"value2\"}", jp.GetJson("$[0][1]"u8).ToString());
            Assert.AreEqual("value2", jp.GetString("$[0][1].a"u8));
            Assert.AreEqual("{\"a\":\"value5\"}", jp.GetJson("$[0][2]"u8).ToString());
            Assert.AreEqual("value5", jp.GetString("$[0][2].a"u8));
            Assert.AreEqual("{\"a\":\"value6\"}", jp.GetJson("$[0][3]"u8).ToString());
            Assert.AreEqual("value6", jp.GetString("$[0][3].a"u8));
            Assert.AreEqual("[{\"a\":\"value3\"},{\"a\":\"value4\"},{\"a\":\"value7\"},{\"a\":\"value8\"}]", jp.GetJson("$[1]"u8).ToString());
            Assert.AreEqual("{\"a\":\"value3\"}", jp.GetJson("$[1][0]"u8).ToString());
            Assert.AreEqual("value3", jp.GetString("$[1][0].a"u8));
            Assert.AreEqual("{\"a\":\"value4\"}", jp.GetJson("$[1][1]"u8).ToString());
            Assert.AreEqual("value4", jp.GetString("$[1][1].a"u8));
            Assert.AreEqual("{\"a\":\"value7\"}", jp.GetJson("$[1][2]"u8).ToString());
            Assert.AreEqual("value7", jp.GetString("$[1][2].a"u8));
            Assert.AreEqual("{\"a\":\"value8\"}", jp.GetJson("$[1][3]"u8).ToString());
            Assert.AreEqual("value8", jp.GetString("$[1][3].a"u8));
            Assert.AreEqual("[{\"a\":\"value9\"}]", jp.GetJson("$[2]"u8).ToString());
            Assert.AreEqual("{\"a\":\"value9\"}", jp.GetJson("$[2][0]"u8).ToString());
            Assert.AreEqual("value9", jp.GetString("$[2][0].a"u8));

            Assert.AreEqual("[[{\"a\":\"value1\"},{\"a\":\"value2\"},{\"a\":\"value5\"},{\"a\":\"value6\"}],[{\"a\":\"value3\"},{\"a\":\"value4\"},{\"a\":\"value7\"},{\"a\":\"value8\"}],[{\"a\":\"value9\"}]]", jp.ToString("J"));
        }

        [Test]
        public void RootAndInsert_TwoDimension()
        {
            JsonPatch jp = new("[[\"value1\",\"value2\"],[\"value3\",\"value4\"]]"u8.ToArray());

            Assert.AreEqual("[\"value1\",\"value2\"]", jp.GetJson("$[0]"u8).ToString());
            Assert.AreEqual("value1", jp.GetString("$[0][0]"u8));
            Assert.AreEqual("value2", jp.GetString("$[0][1]"u8));
            Assert.AreEqual("[\"value3\",\"value4\"]", jp.GetJson("$[1]"u8).ToString());
            Assert.AreEqual("value3", jp.GetString("$[1][0]"u8));
            Assert.AreEqual("value4", jp.GetString("$[1][1]"u8));

            jp.Append("$[0]"u8, "value5");

            Assert.AreEqual("[\"value1\",\"value2\",\"value5\"]", jp.GetJson("$[0]"u8).ToString());

            jp.Append("$[0]"u8, "value6");

            Assert.AreEqual("[\"value1\",\"value2\",\"value5\",\"value6\"]", jp.GetJson("$[0]"u8).ToString());

            jp.Append("$[1]"u8, "value7");

            Assert.AreEqual("[\"value3\",\"value4\",\"value7\"]", jp.GetJson("$[1]"u8).ToString());

            jp.Append("$[1]"u8, "value8");

            Assert.AreEqual("[\"value3\",\"value4\",\"value7\",\"value8\"]", jp.GetJson("$[1]"u8).ToString());

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

            Assert.AreEqual("[[\"value1\",\"value2\",\"value5\",\"value6\"],[\"value3\",\"value4\",\"value7\",\"value8\"],[\"value9\"]]", jp.ToString("J"));
        }

        [Test]
        public void Insert_TwoDimension_WithProperty()
        {
            JsonPatch jp = new();

            jp.Append("$[0]"u8, "{\"a\":\"value1\"}"u8);

            Assert.AreEqual("[{\"a\":\"value1\"}]", jp.GetJson("$[0]"u8).ToString());

            jp.Append("$[0]"u8, "{\"a\":\"value2\"}"u8);

            Assert.AreEqual("[{\"a\":\"value1\"},{\"a\":\"value2\"}]", jp.GetJson("$[0]"u8).ToString());

            jp.Append("$[1]"u8, "{\"a\":\"value3\"}"u8);

            Assert.AreEqual("[{\"a\":\"value3\"}]", jp.GetJson("$[1]"u8).ToString());

            jp.Append("$[1]"u8, "{\"a\":\"value4\"}"u8);

            Assert.AreEqual("[{\"a\":\"value3\"},{\"a\":\"value4\"}]", jp.GetJson("$[1]"u8).ToString());

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

            Assert.AreEqual("[[{\"a\":\"value1\"},{\"a\":\"value2\"}],[{\"a\":\"value3\"},{\"a\":\"value4\"}],[{\"a\":\"value5\"}]]", jp.ToString("J"));
        }

        [Test]
        public void Insert_TwoDimension()
        {
            JsonPatch jp = new();

            jp.Append("$[0]"u8, "value1");

            Assert.AreEqual("[\"value1\"]", jp.GetJson("$[0]"u8).ToString());

            jp.Append("$[0]"u8, "value2");

            Assert.AreEqual("[\"value1\",\"value2\"]", jp.GetJson("$[0]"u8).ToString());

            jp.Append("$[1]"u8, "value3");

            Assert.AreEqual("[\"value3\"]", jp.GetJson("$[1]"u8).ToString());

            jp.Append("$[1]"u8, "value4");

            Assert.AreEqual("[\"value3\",\"value4\"]", jp.GetJson("$[1]"u8).ToString());

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

            Assert.AreEqual("[[\"value1\",\"value2\"],[\"value3\",\"value4\"],[\"value5\"]]", jp.ToString("J"));
        }

        [Test]
        public void RootAndInsert_TwoLevelTwoLevel_WithProperty()
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

            Assert.AreEqual("{\"z\":{\"a\":[{\"b\":\"value1\"},{\"b\":\"value2\"},{\"b\":\"value5\"}]}}", jp.GetJson("$.x.y[0]"u8).ToString());

            jp.Append("$.x.y[0].z.a"u8, "{\"b\":\"value6\"}"u8);

            Assert.AreEqual("{\"z\":{\"a\":[{\"b\":\"value1\"},{\"b\":\"value2\"},{\"b\":\"value5\"},{\"b\":\"value6\"}]}}", jp.GetJson("$.x.y[0]"u8).ToString());

            jp.Append("$.x.y[1].z.a"u8, "{\"b\":\"value7\"}"u8);

            Assert.AreEqual("{\"z\":{\"a\":[{\"b\":\"value3\"},{\"b\":\"value4\"},{\"b\":\"value7\"}]}}", jp.GetJson("$.x.y[1]"u8).ToString());

            jp.Append("$.x.y[1].z.a"u8, "{\"b\":\"value8\"}"u8);

            Assert.AreEqual("{\"z\":{\"a\":[{\"b\":\"value3\"},{\"b\":\"value4\"},{\"b\":\"value7\"},{\"b\":\"value8\"}]}}", jp.GetJson("$.x.y[1]"u8).ToString());

            jp.Append("$.x.y"u8, "{\"z\":{\"a\":[{\"b\":\"value9\"}]}}"u8);

            Assert.AreEqual("{\"y\":[{\"z\":{\"a\":[{\"b\":\"value1\"},{\"b\":\"value2\"}]}},{\"z\":{\"a\":[{\"b\":\"value3\"},{\"b\":\"value4\"}]}}]}", jp.GetJson("$.x"u8).ToString());
            Assert.AreEqual("[{\"z\":{\"a\":[{\"b\":\"value1\"},{\"b\":\"value2\"},{\"b\":\"value5\"},{\"b\":\"value6\"}]}},{\"z\":{\"a\":[{\"b\":\"value3\"},{\"b\":\"value4\"},{\"b\":\"value7\"},{\"b\":\"value8\"}]}},{\"z\":{\"a\":[{\"b\":\"value9\"}]}}]", jp.GetJson("$.x.y"u8).ToString());
            Assert.AreEqual("{\"z\":{\"a\":[{\"b\":\"value1\"},{\"b\":\"value2\"},{\"b\":\"value5\"},{\"b\":\"value6\"}]}}", jp.GetJson("$.x.y[0]"u8).ToString());
            Assert.AreEqual("{\"a\":[{\"b\":\"value1\"},{\"b\":\"value2\"},{\"b\":\"value5\"},{\"b\":\"value6\"}]}", jp.GetJson("$.x.y[0].z"u8).ToString());
            Assert.AreEqual("[{\"b\":\"value1\"},{\"b\":\"value2\"},{\"b\":\"value5\"},{\"b\":\"value6\"}]", jp.GetJson("$.x.y[0].z.a"u8).ToString());
            Assert.AreEqual("{\"b\":\"value1\"}", jp.GetJson("$.x.y[0].z.a[0]"u8).ToString());
            Assert.AreEqual("value1", jp.GetString("$.x.y[0].z.a[0].b"u8));
            Assert.AreEqual("{\"b\":\"value2\"}", jp.GetJson("$.x.y[0].z.a[1]"u8).ToString());
            Assert.AreEqual("value2", jp.GetString("$.x.y[0].z.a[1].b"u8));
            Assert.AreEqual("{\"b\":\"value5\"}", jp.GetJson("$.x.y[0].z.a[2]"u8).ToString());
            Assert.AreEqual("value5", jp.GetString("$.x.y[0].z.a[2].b"u8));
            Assert.AreEqual("{\"b\":\"value6\"}", jp.GetJson("$.x.y[0].z.a[3]"u8).ToString());
            Assert.AreEqual("value6", jp.GetString("$.x.y[0].z.a[3].b"u8));
            Assert.AreEqual("{\"z\":{\"a\":[{\"b\":\"value3\"},{\"b\":\"value4\"},{\"b\":\"value7\"},{\"b\":\"value8\"}]}}", jp.GetJson("$.x.y[1]"u8).ToString());
            Assert.AreEqual("{\"a\":[{\"b\":\"value3\"},{\"b\":\"value4\"},{\"b\":\"value7\"},{\"b\":\"value8\"}]}", jp.GetJson("$.x.y[1].z"u8).ToString());
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

            Assert.AreEqual("{\"x\":{\"y\":[{\"z\":{\"a\":[{\"b\":\"value1\"},{\"b\":\"value2\"},{\"b\":\"value5\"},{\"b\":\"value6\"}]}},{\"z\":{\"a\":[{\"b\":\"value3\"},{\"b\":\"value4\"},{\"b\":\"value7\"},{\"b\":\"value8\"}]}},{\"z\":{\"a\":[{\"b\":\"value9\"}]}}]}}", jp.ToString("J"));
        }

        [Test]
        public void RootAndInsert_TwoLevelTwoLevel()
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

            Assert.AreEqual("{\"z\":{\"a\":[\"value1\",\"value2\",\"value5\"]}}", jp.GetJson("$.x.y[0]"u8).ToString());

            jp.Append("$.x.y[0].z.a"u8, "value6");

            Assert.AreEqual("{\"z\":{\"a\":[\"value1\",\"value2\",\"value5\",\"value6\"]}}", jp.GetJson("$.x.y[0]"u8).ToString());

            jp.Append("$.x.y[1].z.a"u8, "value7");

            Assert.AreEqual("{\"z\":{\"a\":[\"value3\",\"value4\",\"value7\"]}}", jp.GetJson("$.x.y[1]"u8).ToString());

            jp.Append("$.x.y[1].z.a"u8, "value8");

            Assert.AreEqual("{\"z\":{\"a\":[\"value3\",\"value4\",\"value7\",\"value8\"]}}", jp.GetJson("$.x.y[1]"u8).ToString());

            jp.Append("$.x.y"u8, "{\"z\":{\"a\":[\"value9\"]}}"u8);

            Assert.AreEqual("{\"y\":[{\"z\":{\"a\":[\"value1\",\"value2\"]}},{\"z\":{\"a\":[\"value3\",\"value4\"]}}]}", jp.GetJson("$.x"u8).ToString());
            Assert.AreEqual("[{\"z\":{\"a\":[\"value1\",\"value2\",\"value5\",\"value6\"]}},{\"z\":{\"a\":[\"value3\",\"value4\",\"value7\",\"value8\"]}},{\"z\":{\"a\":[\"value9\"]}}]", jp.GetJson("$.x.y"u8).ToString());
            Assert.AreEqual("{\"z\":{\"a\":[\"value1\",\"value2\",\"value5\",\"value6\"]}}", jp.GetJson("$.x.y[0]"u8).ToString());
            Assert.AreEqual("{\"a\":[\"value1\",\"value2\",\"value5\",\"value6\"]}", jp.GetJson("$.x.y[0].z"u8).ToString());
            Assert.AreEqual("[\"value1\",\"value2\",\"value5\",\"value6\"]", jp.GetJson("$.x.y[0].z.a"u8).ToString());
            Assert.AreEqual("value1", jp.GetString("$.x.y[0].z.a[0]"u8));
            Assert.AreEqual("value2", jp.GetString("$.x.y[0].z.a[1]"u8));
            Assert.AreEqual("value5", jp.GetString("$.x.y[0].z.a[2]"u8));
            Assert.AreEqual("value6", jp.GetString("$.x.y[0].z.a[3]"u8));
            Assert.AreEqual("{\"z\":{\"a\":[\"value3\",\"value4\",\"value7\",\"value8\"]}}", jp.GetJson("$.x.y[1]"u8).ToString());
            Assert.AreEqual("{\"a\":[\"value3\",\"value4\",\"value7\",\"value8\"]}", jp.GetJson("$.x.y[1].z"u8).ToString());
            Assert.AreEqual("[\"value3\",\"value4\",\"value7\",\"value8\"]", jp.GetJson("$.x.y[1].z.a"u8).ToString());
            Assert.AreEqual("value3", jp.GetString("$.x.y[1].z.a[0]"u8));
            Assert.AreEqual("value4", jp.GetString("$.x.y[1].z.a[1]"u8));
            Assert.AreEqual("value7", jp.GetString("$.x.y[1].z.a[2]"u8));
            Assert.AreEqual("value8", jp.GetString("$.x.y[1].z.a[3]"u8));
            Assert.AreEqual("{\"z\":{\"a\":[\"value9\"]}}", jp.GetJson("$.x.y[2]"u8).ToString());
            Assert.AreEqual("{\"a\":[\"value9\"]}", jp.GetJson("$.x.y[2].z"u8).ToString());
            Assert.AreEqual("[\"value9\"]", jp.GetJson("$.x.y[2].z.a"u8).ToString());
            Assert.AreEqual("value9", jp.GetString("$.x.y[2].z.a[0]"u8));

            Assert.AreEqual("{\"x\":{\"y\":[{\"z\":{\"a\":[\"value1\",\"value2\",\"value5\",\"value6\"]}},{\"z\":{\"a\":[\"value3\",\"value4\",\"value7\",\"value8\"]}},{\"z\":{\"a\":[\"value9\"]}}]}}", jp.ToString("J"));
        }

        [Test]
        public void Insert_TwoLevelTwoLevel_WithProperty()
        {
            JsonPatch jp = new();

            jp.Append("$.x.y[0].z.a"u8, "{\"b\":\"value1\"}"u8);

            Assert.AreEqual("{\"y\":[{\"z\":{\"a\":[{\"b\":\"value1\"}]}}]}", jp.GetJson("$.x"u8).ToString());

            jp.Append("$.x.y[0].z.a"u8, "{\"b\":\"value2\"}"u8);

            Assert.AreEqual("{\"y\":[{\"z\":{\"a\":[{\"b\":\"value1\"},{\"b\":\"value2\"}]}}]}", jp.GetJson("$.x"u8).ToString());

            jp.Append("$.x.y[1].z.a"u8, "{\"b\":\"value3\"}"u8);

            Assert.AreEqual("{\"y\":[{\"z\":{\"a\":[{\"b\":\"value1\"},{\"b\":\"value2\"}]}},{\"z\":{\"a\":[{\"b\":\"value3\"}]}}]}", jp.GetJson("$.x"u8).ToString());

            jp.Append("$.x.y[1].z.a"u8, "{\"b\":\"value4\"}"u8);

            Assert.AreEqual("{\"y\":[{\"z\":{\"a\":[{\"b\":\"value1\"},{\"b\":\"value2\"}]}},{\"z\":{\"a\":[{\"b\":\"value3\"},{\"b\":\"value4\"}]}}]}", jp.GetJson("$.x"u8).ToString());

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

            Assert.AreEqual("{\"x\":{\"y\":[{\"z\":{\"a\":[{\"b\":\"value1\"},{\"b\":\"value2\"}]}},{\"z\":{\"a\":[{\"b\":\"value3\"},{\"b\":\"value4\"}]}},{\"z\":{\"a\":[{\"b\":\"value5\"}]}}]}}", jp.ToString("J"));
        }

        [Test]
        public void Insert_TwoLevelTwoLevel()
        {
            JsonPatch jp = new();

            jp.Append("$.x.y[0].z.a"u8, "value1");

            Assert.AreEqual("{\"y\":[{\"z\":{\"a\":[\"value1\"]}}]}", jp.GetJson("$.x"u8).ToString());

            jp.Append("$.x.y[0].z.a"u8, "value2");

            Assert.AreEqual("{\"y\":[{\"z\":{\"a\":[\"value1\",\"value2\"]}}]}", jp.GetJson("$.x"u8).ToString());

            jp.Append("$.x.y[1].z.a"u8, "value3");

            Assert.AreEqual("{\"y\":[{\"z\":{\"a\":[\"value1\",\"value2\"]}},{\"z\":{\"a\":[\"value3\"]}}]}", jp.GetJson("$.x"u8).ToString());

            jp.Append("$.x.y[1].z.a"u8, "value4");

            Assert.AreEqual("{\"y\":[{\"z\":{\"a\":[\"value1\",\"value2\"]}},{\"z\":{\"a\":[\"value3\",\"value4\"]}}]}", jp.GetJson("$.x"u8).ToString());

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

            Assert.AreEqual("{\"x\":{\"y\":[{\"z\":{\"a\":[\"value1\",\"value2\"]}},{\"z\":{\"a\":[\"value3\",\"value4\"]}},{\"z\":{\"a\":[\"value5\"]}}]}}", jp.ToString("J"));
        }

        [Test]
        public void RootAndInsert_TwoLevel_WithProperty()
        {
            JsonPatch jp = new("{\"x\":{\"y\":[{\"a\":\"value1\"},{\"a\":\"value2\"}]}}"u8.ToArray());

            Assert.AreEqual("{\"y\":[{\"a\":\"value1\"},{\"a\":\"value2\"}]}", jp.GetJson("$.x"u8).ToString());
            Assert.AreEqual("[{\"a\":\"value1\"},{\"a\":\"value2\"}]", jp.GetJson("$.x.y"u8).ToString());
            Assert.AreEqual("{\"a\":\"value1\"}", jp.GetJson("$.x.y[0]"u8).ToString());
            Assert.AreEqual("value1", jp.GetString("$.x.y[0].a"u8));
            Assert.AreEqual("{\"a\":\"value2\"}", jp.GetJson("$.x.y[1]"u8).ToString());
            Assert.AreEqual("value2", jp.GetString("$.x.y[1].a"u8));

            jp.Append("$.x.y"u8, "{\"a\":\"value3\"}"u8);

            Assert.AreEqual("[{\"a\":\"value1\"},{\"a\":\"value2\"},{\"a\":\"value3\"}]", jp.GetJson("$.x.y"u8).ToString());

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

            Assert.AreEqual("{\"x\":{\"y\":[{\"a\":\"value1\"},{\"a\":\"value2\"},{\"a\":\"value3\"},{\"a\":\"value4\"}]}}", jp.ToString("J"));
        }

        [Test]
        public void RootAndInsert_TwoLevel()
        {
            JsonPatch jp = new("{\"x\":{\"y\":[\"value1\",\"value2\"]}}"u8.ToArray());

            Assert.AreEqual("{\"y\":[\"value1\",\"value2\"]}", jp.GetJson("$.x"u8).ToString());
            Assert.AreEqual("[\"value1\",\"value2\"]", jp.GetJson("$.x.y"u8).ToString());
            Assert.AreEqual("value1", jp.GetString("$.x.y[0]"u8));
            Assert.AreEqual("value2", jp.GetString("$.x.y[1]"u8));

            jp.Append("$.x.y"u8, "value3");

            Assert.AreEqual("[\"value1\",\"value2\",\"value3\"]", jp.GetJson("$.x.y"u8).ToString());

            jp.Append("$.x.y"u8, "value4");

            Assert.AreEqual("{\"y\":[\"value1\",\"value2\"]}", jp.GetJson("$.x"u8).ToString());
            Assert.AreEqual("[\"value1\",\"value2\",\"value3\",\"value4\"]", jp.GetJson("$.x.y"u8).ToString());
            Assert.AreEqual("value1", jp.GetString("$.x.y[0]"u8));
            Assert.AreEqual("value2", jp.GetString("$.x.y[1]"u8));
            Assert.AreEqual("value3", jp.GetString("$.x.y[2]"u8));
            Assert.AreEqual("value4", jp.GetString("$.x.y[3]"u8));

            Assert.AreEqual("{\"x\":{\"y\":[\"value1\",\"value2\",\"value3\",\"value4\"]}}", jp.ToString("J"));
        }

        [Test]
        public void Insert_TwoLevel_WithProperty()
        {
            JsonPatch jp = new();

            jp.Append("$.x.y"u8, "{\"a\":\"value1\"}"u8);

            Assert.AreEqual("{\"y\":[{\"a\":\"value1\"}]}", jp.GetJson("$.x"u8).ToString());

            jp.Append("$.x.y"u8, "{\"a\":\"value2\"}"u8);

            Assert.AreEqual("{\"y\":[{\"a\":\"value1\"},{\"a\":\"value2\"}]}", jp.GetJson("$.x"u8).ToString());
            Assert.AreEqual("[{\"a\":\"value1\"},{\"a\":\"value2\"}]", jp.GetJson("$.x.y"u8).ToString());
            Assert.AreEqual("{\"a\":\"value1\"}", jp.GetJson("$.x.y[0]"u8).ToString());
            Assert.AreEqual("value1", jp.GetString("$.x.y[0].a"u8));
            Assert.AreEqual("{\"a\":\"value2\"}", jp.GetJson("$.x.y[1]"u8).ToString());
            Assert.AreEqual("value2", jp.GetString("$.x.y[1].a"u8));

            Assert.AreEqual("{\"x\":{\"y\":[{\"a\":\"value1\"},{\"a\":\"value2\"}]}}", jp.ToString("J"));
        }

        [Test]
        public void Insert_TwoLevel()
        {
            JsonPatch jp = new();

            jp.Append("$.x.y"u8, "value1");

            Assert.AreEqual("{\"y\":[\"value1\"]}", jp.GetJson("$.x"u8).ToString());

            jp.Append("$.x.y"u8, "value2");

            Assert.AreEqual("{\"y\":[\"value1\",\"value2\"]}", jp.GetJson("$.x"u8).ToString());
            Assert.AreEqual("[\"value1\",\"value2\"]", jp.GetJson("$.x.y"u8).ToString());
            Assert.AreEqual("value1", jp.GetString("$.x.y[0]"u8));
            Assert.AreEqual("value2", jp.GetString("$.x.y[1]"u8));

            Assert.AreEqual("{\"x\":{\"y\":[\"value1\",\"value2\"]}}", jp.ToString("J"));
        }

        [Test]
        public void RootAndInsert_OneLevelTwoLevel_WithProperty()
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

            Assert.AreEqual("{\"y\":{\"z\":[{\"a\":\"value1\"},{\"a\":\"value2\"},{\"a\":\"value5\"}]}}", jp.GetJson("$.x[0]"u8).ToString());

            jp.Append("$.x[0].y.z"u8, "{\"a\":\"value6\"}"u8);

            Assert.AreEqual("{\"y\":{\"z\":[{\"a\":\"value1\"},{\"a\":\"value2\"},{\"a\":\"value5\"},{\"a\":\"value6\"}]}}", jp.GetJson("$.x[0]"u8).ToString());

            jp.Append("$.x[1].y.z"u8, "{\"a\":\"value7\"}"u8);

            Assert.AreEqual("{\"y\":{\"z\":[{\"a\":\"value3\"},{\"a\":\"value4\"},{\"a\":\"value7\"}]}}", jp.GetJson("$.x[1]"u8).ToString());

            jp.Append("$.x[1].y.z"u8, "{\"a\":\"value8\"}"u8);

            Assert.AreEqual("{\"y\":{\"z\":[{\"a\":\"value3\"},{\"a\":\"value4\"},{\"a\":\"value7\"},{\"a\":\"value8\"}]}}", jp.GetJson("$.x[1]"u8).ToString());

            jp.Append("$.x"u8, "{\"y\":{\"z\":[{\"a\":\"value9\"}]}}"u8);

            Assert.AreEqual("[{\"y\":{\"z\":[{\"a\":\"value1\"},{\"a\":\"value2\"},{\"a\":\"value5\"},{\"a\":\"value6\"}]}},{\"y\":{\"z\":[{\"a\":\"value3\"},{\"a\":\"value4\"},{\"a\":\"value7\"},{\"a\":\"value8\"}]}},{\"y\":{\"z\":[{\"a\":\"value9\"}]}}]", jp.GetJson("$.x"u8).ToString());
            Assert.AreEqual("{\"y\":{\"z\":[{\"a\":\"value1\"},{\"a\":\"value2\"},{\"a\":\"value5\"},{\"a\":\"value6\"}]}}", jp.GetJson("$.x[0]"u8).ToString());
            Assert.AreEqual("{\"z\":[{\"a\":\"value1\"},{\"a\":\"value2\"},{\"a\":\"value5\"},{\"a\":\"value6\"}]}", jp.GetJson("$.x[0].y"u8).ToString());
            Assert.AreEqual("[{\"a\":\"value1\"},{\"a\":\"value2\"},{\"a\":\"value5\"},{\"a\":\"value6\"}]", jp.GetJson("$.x[0].y.z"u8).ToString());
            Assert.AreEqual("{\"a\":\"value1\"}", jp.GetJson("$.x[0].y.z[0]"u8).ToString());
            Assert.AreEqual("value1", jp.GetString("$.x[0].y.z[0].a"u8));
            Assert.AreEqual("{\"a\":\"value2\"}", jp.GetJson("$.x[0].y.z[1]"u8).ToString());
            Assert.AreEqual("value2", jp.GetString("$.x[0].y.z[1].a"u8));
            Assert.AreEqual("{\"a\":\"value5\"}", jp.GetJson("$.x[0].y.z[2]"u8).ToString());
            Assert.AreEqual("value5", jp.GetString("$.x[0].y.z[2].a"u8));
            Assert.AreEqual("{\"a\":\"value6\"}", jp.GetJson("$.x[0].y.z[3]"u8).ToString());
            Assert.AreEqual("value6", jp.GetString("$.x[0].y.z[3].a"u8));
            Assert.AreEqual("{\"y\":{\"z\":[{\"a\":\"value3\"},{\"a\":\"value4\"},{\"a\":\"value7\"},{\"a\":\"value8\"}]}}", jp.GetJson("$.x[1]"u8).ToString());
            Assert.AreEqual("{\"z\":[{\"a\":\"value3\"},{\"a\":\"value4\"},{\"a\":\"value7\"},{\"a\":\"value8\"}]}", jp.GetJson("$.x[1].y"u8).ToString());
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

            Assert.AreEqual("{\"x\":[{\"y\":{\"z\":[{\"a\":\"value1\"},{\"a\":\"value2\"},{\"a\":\"value5\"},{\"a\":\"value6\"}]}},{\"y\":{\"z\":[{\"a\":\"value3\"},{\"a\":\"value4\"},{\"a\":\"value7\"},{\"a\":\"value8\"}]}},{\"y\":{\"z\":[{\"a\":\"value9\"}]}}]}", jp.ToString("J"));
        }

        [Test]
        public void RootAndInsert_OneLevelTwoLevel()
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

            Assert.AreEqual("{\"y\":{\"z\":[\"value1\",\"value2\",\"value5\"]}}", jp.GetJson("$.x[0]"u8).ToString());

            jp.Append("$.x[0].y.z"u8, "value6");

            Assert.AreEqual("{\"y\":{\"z\":[\"value1\",\"value2\",\"value5\",\"value6\"]}}", jp.GetJson("$.x[0]"u8).ToString());

            jp.Append("$.x[1].y.z"u8, "value7");

            Assert.AreEqual("{\"y\":{\"z\":[\"value3\",\"value4\",\"value7\"]}}", jp.GetJson("$.x[1]"u8).ToString());

            jp.Append("$.x[1].y.z"u8, "value8");

            Assert.AreEqual("{\"y\":{\"z\":[\"value3\",\"value4\",\"value7\",\"value8\"]}}", jp.GetJson("$.x[1]"u8).ToString());

            jp.Append("$.x"u8, "{\"y\":{\"z\":[\"value9\"]}}"u8);

            Assert.AreEqual("[{\"y\":{\"z\":[\"value1\",\"value2\",\"value5\",\"value6\"]}},{\"y\":{\"z\":[\"value3\",\"value4\",\"value7\",\"value8\"]}},{\"y\":{\"z\":[\"value9\"]}}]", jp.GetJson("$.x"u8).ToString());
            Assert.AreEqual("{\"y\":{\"z\":[\"value1\",\"value2\",\"value5\",\"value6\"]}}", jp.GetJson("$.x[0]"u8).ToString());
            Assert.AreEqual("{\"z\":[\"value1\",\"value2\",\"value5\",\"value6\"]}", jp.GetJson("$.x[0].y"u8).ToString());
            Assert.AreEqual("[\"value1\",\"value2\",\"value5\",\"value6\"]", jp.GetJson("$.x[0].y.z"u8).ToString());
            Assert.AreEqual("value1", jp.GetString("$.x[0].y.z[0]"u8));
            Assert.AreEqual("value2", jp.GetString("$.x[0].y.z[1]"u8));
            Assert.AreEqual("value5", jp.GetString("$.x[0].y.z[2]"u8));
            Assert.AreEqual("value6", jp.GetString("$.x[0].y.z[3]"u8));
            Assert.AreEqual("{\"y\":{\"z\":[\"value3\",\"value4\",\"value7\",\"value8\"]}}", jp.GetJson("$.x[1]"u8).ToString());
            Assert.AreEqual("{\"z\":[\"value3\",\"value4\",\"value7\",\"value8\"]}", jp.GetJson("$.x[1].y"u8).ToString());
            Assert.AreEqual("[\"value3\",\"value4\",\"value7\",\"value8\"]", jp.GetJson("$.x[1].y.z"u8).ToString());
            Assert.AreEqual("value3", jp.GetString("$.x[1].y.z[0]"u8));
            Assert.AreEqual("value4", jp.GetString("$.x[1].y.z[1]"u8));
            Assert.AreEqual("value7", jp.GetString("$.x[1].y.z[2]"u8));
            Assert.AreEqual("value8", jp.GetString("$.x[1].y.z[3]"u8));
            Assert.AreEqual("{\"y\":{\"z\":[\"value9\"]}}", jp.GetJson("$.x[2]"u8).ToString());
            Assert.AreEqual("{\"z\":[\"value9\"]}", jp.GetJson("$.x[2].y"u8).ToString());
            Assert.AreEqual("[\"value9\"]", jp.GetJson("$.x[2].y.z"u8).ToString());
            Assert.AreEqual("value9", jp.GetString("$.x[2].y.z[0]"u8));

            Assert.AreEqual("{\"x\":[{\"y\":{\"z\":[\"value1\",\"value2\",\"value5\",\"value6\"]}},{\"y\":{\"z\":[\"value3\",\"value4\",\"value7\",\"value8\"]}},{\"y\":{\"z\":[\"value9\"]}}]}", jp.ToString("J"));
        }

        [Test]
        public void Insert_OneLevelTwoLevel_WithProperty()
        {
            JsonPatch jp = new();

            jp.Append("$.x[0].y.z"u8, "{\"a\":\"value1\"}"u8);

            Assert.AreEqual("[{\"y\":{\"z\":[{\"a\":\"value1\"}]}}]", jp.GetJson("$.x"u8).ToString());

            jp.Append("$.x[0].y.z"u8, "{\"a\":\"value2\"}"u8);

            Assert.AreEqual("[{\"y\":{\"z\":[{\"a\":\"value1\"},{\"a\":\"value2\"}]}}]", jp.GetJson("$.x"u8).ToString());

            jp.Append("$.x[1].y.z"u8, "{\"a\":\"value3\"}"u8);

            Assert.AreEqual("[{\"y\":{\"z\":[{\"a\":\"value1\"},{\"a\":\"value2\"}]}},{\"y\":{\"z\":[{\"a\":\"value3\"}]}}]", jp.GetJson("$.x"u8).ToString());

            jp.Append("$.x[1].y.z"u8, "{\"a\":\"value4\"}"u8);

            Assert.AreEqual("[{\"y\":{\"z\":[{\"a\":\"value1\"},{\"a\":\"value2\"}]}},{\"y\":{\"z\":[{\"a\":\"value3\"},{\"a\":\"value4\"}]}}]", jp.GetJson("$.x"u8).ToString());

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

            Assert.AreEqual("{\"x\":[{\"y\":{\"z\":[{\"a\":\"value1\"},{\"a\":\"value2\"}]}},{\"y\":{\"z\":[{\"a\":\"value3\"},{\"a\":\"value4\"}]}},{\"y\":{\"z\":[{\"a\":\"value5\"}]}}]}", jp.ToString("J"));
        }

        [Test]
        public void Insert_OneLevelTwoLevel()
        {
            JsonPatch jp = new();

            jp.Append("$.x[0].y.z"u8, "value1");

            Assert.AreEqual("[{\"y\":{\"z\":[\"value1\"]}}]", jp.GetJson("$.x"u8).ToString());

            jp.Append("$.x[0].y.z"u8, "value2");

            Assert.AreEqual("[{\"y\":{\"z\":[\"value1\",\"value2\"]}}]", jp.GetJson("$.x"u8).ToString());

            jp.Append("$.x[1].y.z"u8, "value3");

            Assert.AreEqual("[{\"y\":{\"z\":[\"value1\",\"value2\"]}},{\"y\":{\"z\":[\"value3\"]}}]", jp.GetJson("$.x"u8).ToString());

            jp.Append("$.x[1].y.z"u8, "value4");

            Assert.AreEqual("[{\"y\":{\"z\":[\"value1\",\"value2\"]}},{\"y\":{\"z\":[\"value3\",\"value4\"]}}]", jp.GetJson("$.x"u8).ToString());

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

            Assert.AreEqual("{\"x\":[{\"y\":{\"z\":[\"value1\",\"value2\"]}},{\"y\":{\"z\":[\"value3\",\"value4\"]}},{\"y\":{\"z\":[\"value5\"]}}]}", jp.ToString("J"));
        }

        [Test]
        public void RootAndInsert_OneLevelTwice_WithProperty()
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

            Assert.AreEqual("{\"y\":[{\"a\":\"value1\"},{\"a\":\"value2\"},{\"a\":\"value5\"}]}", jp.GetJson("$.x[0]"u8).ToString());

            jp.Append("$.x[0].y"u8, "{\"a\":\"value6\"}"u8);

            Assert.AreEqual("{\"y\":[{\"a\":\"value1\"},{\"a\":\"value2\"},{\"a\":\"value5\"},{\"a\":\"value6\"}]}", jp.GetJson("$.x[0]"u8).ToString());

            jp.Append("$.x[1].y"u8, "{\"a\":\"value7\"}"u8);

            Assert.AreEqual("{\"y\":[{\"a\":\"value3\"},{\"a\":\"value4\"},{\"a\":\"value7\"}]}", jp.GetJson("$.x[1]"u8).ToString());

            jp.Append("$.x[1].y"u8, "{\"a\":\"value8\"}"u8);

            Assert.AreEqual("{\"y\":[{\"a\":\"value3\"},{\"a\":\"value4\"},{\"a\":\"value7\"},{\"a\":\"value8\"}]}", jp.GetJson("$.x[1]"u8).ToString());

            jp.Append("$.x"u8, "{\"y\":[{\"a\":\"value9\"}]}"u8);

            Assert.AreEqual("[{\"y\":[{\"a\":\"value1\"},{\"a\":\"value2\"},{\"a\":\"value5\"},{\"a\":\"value6\"}]},{\"y\":[{\"a\":\"value3\"},{\"a\":\"value4\"},{\"a\":\"value7\"},{\"a\":\"value8\"}]},{\"y\":[{\"a\":\"value9\"}]}]", jp.GetJson("$.x"u8).ToString());
            Assert.AreEqual("{\"y\":[{\"a\":\"value1\"},{\"a\":\"value2\"},{\"a\":\"value5\"},{\"a\":\"value6\"}]}", jp.GetJson("$.x[0]"u8).ToString());
            Assert.AreEqual("[{\"a\":\"value1\"},{\"a\":\"value2\"},{\"a\":\"value5\"},{\"a\":\"value6\"}]", jp.GetJson("$.x[0].y"u8).ToString());
            Assert.AreEqual("{\"a\":\"value1\"}", jp.GetJson("$.x[0].y[0]"u8).ToString());
            Assert.AreEqual("value1", jp.GetString("$.x[0].y[0].a"u8));
            Assert.AreEqual("{\"a\":\"value2\"}", jp.GetJson("$.x[0].y[1]"u8).ToString());
            Assert.AreEqual("value2", jp.GetString("$.x[0].y[1].a"u8));
            Assert.AreEqual("{\"a\":\"value5\"}", jp.GetJson("$.x[0].y[2]"u8).ToString());
            Assert.AreEqual("value5", jp.GetString("$.x[0].y[2].a"u8));
            Assert.AreEqual("{\"a\":\"value6\"}", jp.GetJson("$.x[0].y[3]"u8).ToString());
            Assert.AreEqual("value6", jp.GetString("$.x[0].y[3].a"u8));
            Assert.AreEqual("{\"y\":[{\"a\":\"value3\"},{\"a\":\"value4\"},{\"a\":\"value7\"},{\"a\":\"value8\"}]}", jp.GetJson("$.x[1]"u8).ToString());
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

            Assert.AreEqual("{\"x\":[{\"y\":[{\"a\":\"value1\"},{\"a\":\"value2\"},{\"a\":\"value5\"},{\"a\":\"value6\"}]},{\"y\":[{\"a\":\"value3\"},{\"a\":\"value4\"},{\"a\":\"value7\"},{\"a\":\"value8\"}]},{\"y\":[{\"a\":\"value9\"}]}]}", jp.ToString("J"));
        }

        [Test]
        public void RootAndInsert_OneLevelTwice()
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

            Assert.AreEqual("{\"y\":[\"value1\",\"value2\",\"value5\"]}", jp.GetJson("$.x[0]"u8).ToString());

            jp.Append("$.x[0].y"u8, "value6");

            Assert.AreEqual("{\"y\":[\"value1\",\"value2\",\"value5\",\"value6\"]}", jp.GetJson("$.x[0]"u8).ToString());

            jp.Append("$.x[1].y"u8, "value7");

            Assert.AreEqual("{\"y\":[\"value3\",\"value4\",\"value7\"]}", jp.GetJson("$.x[1]"u8).ToString());

            jp.Append("$.x[1].y"u8, "value8");

            Assert.AreEqual("{\"y\":[\"value3\",\"value4\",\"value7\",\"value8\"]}", jp.GetJson("$.x[1]"u8).ToString());

            jp.Append("$.x"u8, "{\"y\":[\"value9\"]}"u8);

            Assert.AreEqual("[{\"y\":[\"value1\",\"value2\",\"value5\",\"value6\"]},{\"y\":[\"value3\",\"value4\",\"value7\",\"value8\"]},{\"y\":[\"value9\"]}]", jp.GetJson("$.x"u8).ToString());
            Assert.AreEqual("{\"y\":[\"value1\",\"value2\",\"value5\",\"value6\"]}", jp.GetJson("$.x[0]"u8).ToString());
            Assert.AreEqual("[\"value1\",\"value2\",\"value5\",\"value6\"]", jp.GetJson("$.x[0].y"u8).ToString());
            Assert.AreEqual("value1", jp.GetString("$.x[0].y[0]"u8));
            Assert.AreEqual("value2", jp.GetString("$.x[0].y[1]"u8));
            Assert.AreEqual("value5", jp.GetString("$.x[0].y[2]"u8));
            Assert.AreEqual("value6", jp.GetString("$.x[0].y[3]"u8));
            Assert.AreEqual("{\"y\":[\"value3\",\"value4\",\"value7\",\"value8\"]}", jp.GetJson("$.x[1]"u8).ToString());
            Assert.AreEqual("[\"value3\",\"value4\",\"value7\",\"value8\"]", jp.GetJson("$.x[1].y"u8).ToString());
            Assert.AreEqual("value3", jp.GetString("$.x[1].y[0]"u8));
            Assert.AreEqual("value4", jp.GetString("$.x[1].y[1]"u8));
            Assert.AreEqual("value7", jp.GetString("$.x[1].y[2]"u8));
            Assert.AreEqual("value8", jp.GetString("$.x[1].y[3]"u8));
            Assert.AreEqual("{\"y\":[\"value9\"]}", jp.GetJson("$.x[2]"u8).ToString());
            Assert.AreEqual("[\"value9\"]", jp.GetJson("$.x[2].y"u8).ToString());
            Assert.AreEqual("value9", jp.GetString("$.x[2].y[0]"u8));

            Assert.AreEqual("{\"x\":[{\"y\":[\"value1\",\"value2\",\"value5\",\"value6\"]},{\"y\":[\"value3\",\"value4\",\"value7\",\"value8\"]},{\"y\":[\"value9\"]}]}", jp.ToString("J"));
        }

        [Test]
        public void Insert_OneLevelTwice_WithProperty()
        {
            JsonPatch jp = new();

            jp.Append("$.x[0].y"u8, "{\"a\":\"value1\"}"u8);

            Assert.AreEqual("[{\"y\":[{\"a\":\"value1\"}]}]", jp.GetJson("$.x"u8).ToString());

            jp.Append("$.x[0].y"u8, "{\"a\":\"value2\"}"u8);

            Assert.AreEqual("[{\"y\":[{\"a\":\"value1\"},{\"a\":\"value2\"}]}]", jp.GetJson("$.x"u8).ToString());

            jp.Append("$.x[1].y"u8, "{\"a\":\"value3\"}"u8);

            Assert.AreEqual("[{\"y\":[{\"a\":\"value1\"},{\"a\":\"value2\"}]},{\"y\":[{\"a\":\"value3\"}]}]", jp.GetJson("$.x"u8).ToString());

            jp.Append("$.x[1].y"u8, "{\"a\":\"value4\"}"u8);

            Assert.AreEqual("[{\"y\":[{\"a\":\"value1\"},{\"a\":\"value2\"}]},{\"y\":[{\"a\":\"value3\"},{\"a\":\"value4\"}]}]", jp.GetJson("$.x"u8).ToString());

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

            Assert.AreEqual("{\"x\":[{\"y\":[{\"a\":\"value1\"},{\"a\":\"value2\"}]},{\"y\":[{\"a\":\"value3\"},{\"a\":\"value4\"}]},{\"y\":[{\"a\":\"value5\"},{\"a\":\"value6\"}]}]}", jp.ToString("J"));
        }

        [Test]
        public void Insert_OneLevelTwice()
        {
            JsonPatch jp = new();

            jp.Append("$.x[0].y"u8, "value1");

            Assert.AreEqual("[{\"y\":[\"value1\"]}]", jp.GetJson("$.x"u8).ToString());

            jp.Append("$.x[0].y"u8, "value2");

            Assert.AreEqual("[{\"y\":[\"value1\",\"value2\"]}]", jp.GetJson("$.x"u8).ToString());

            jp.Append("$.x[1].y"u8, "value3");

            Assert.AreEqual("[{\"y\":[\"value1\",\"value2\"]},{\"y\":[\"value3\"]}]", jp.GetJson("$.x"u8).ToString());

            jp.Append("$.x[1].y"u8, "value4");

            Assert.AreEqual("[{\"y\":[\"value1\",\"value2\"]},{\"y\":[\"value3\",\"value4\"]}]", jp.GetJson("$.x"u8).ToString());

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

            Assert.AreEqual("{\"x\":[{\"y\":[\"value1\",\"value2\"]},{\"y\":[\"value3\",\"value4\"]},{\"y\":[\"value5\",\"value6\"]}]}", jp.ToString("J"));
        }

        [Test]
        public void RootAndInsert_OneLevel_WithProperty()
        {
            JsonPatch jp = new(new("{\"x\":[{\"a\":\"value1\"},{\"a\":\"value2\"}]}"u8.ToArray()));

            Assert.AreEqual("[{\"a\":\"value1\"},{\"a\":\"value2\"}]", jp.GetJson("$.x"u8).ToString());
            Assert.AreEqual("{\"a\":\"value1\"}", jp.GetJson("$.x[0]"u8).ToString());
            Assert.AreEqual("value1", jp.GetString("$.x[0].a"u8));
            Assert.AreEqual("{\"a\":\"value2\"}", jp.GetJson("$.x[1]"u8).ToString());
            Assert.AreEqual("value2", jp.GetString("$.x[1].a"u8));

            jp.Append("$.x"u8, "{\"a\":\"value3\"}"u8);

            Assert.AreEqual("[{\"a\":\"value1\"},{\"a\":\"value2\"},{\"a\":\"value3\"}]", jp.GetJson("$.x"u8).ToString());

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

            Assert.AreEqual("{\"x\":[{\"a\":\"value1\"},{\"a\":\"value2\"},{\"a\":\"value3\"},{\"a\":\"value4\"}]}", jp.ToString("J"));
        }

        [Test]
        public void RootAndInsert_OneLevel()
        {
            JsonPatch jp = new(new("{\"x\":[\"value1\",\"value2\"]}"u8.ToArray()));

            Assert.AreEqual("[\"value1\",\"value2\"]", jp.GetJson("$.x"u8).ToString());
            Assert.AreEqual("value1", jp.GetString("$.x[0]"u8));
            Assert.AreEqual("value2", jp.GetString("$.x[1]"u8));

            jp.Append("$.x"u8, "value3");

            Assert.AreEqual("[\"value1\",\"value2\",\"value3\"]", jp.GetJson("$.x"u8).ToString());

            jp.Append("$.x"u8, "value4");

            Assert.AreEqual("[\"value1\",\"value2\",\"value3\",\"value4\"]", jp.GetJson("$.x"u8).ToString());
            Assert.AreEqual("value1", jp.GetString("$.x[0]"u8));
            Assert.AreEqual("value2", jp.GetString("$.x[1]"u8));
            Assert.AreEqual("value3", jp.GetString("$.x[2]"u8));
            Assert.AreEqual("value4", jp.GetString("$.x[3]"u8));

            Assert.AreEqual("{\"x\":[\"value1\",\"value2\",\"value3\",\"value4\"]}", jp.ToString("J"));
        }

        [Test]
        public void Insert_OneLevel_WithProperty()
        {
            JsonPatch jp = new();

            jp.Append("$.x"u8, "{\"a\":\"value1\"}"u8);

            Assert.AreEqual("[{\"a\":\"value1\"}]", jp.GetJson("$.x"u8).ToString());

            jp.Append("$.x"u8, "{\"a\":\"value2\"}"u8);

            Assert.AreEqual("[{\"a\":\"value1\"},{\"a\":\"value2\"}]", jp.GetJson("$.x"u8).ToString());
            Assert.AreEqual("{\"a\":\"value1\"}", jp.GetJson("$.x[0]"u8).ToString());
            Assert.AreEqual("value1", jp.GetString("$.x[0].a"u8));
            Assert.AreEqual("{\"a\":\"value2\"}", jp.GetJson("$.x[1]"u8).ToString());
            Assert.AreEqual("value2", jp.GetString("$.x[1].a"u8));

            Assert.AreEqual("{\"x\":[{\"a\":\"value1\"},{\"a\":\"value2\"}]}", jp.ToString("J"));
        }

        [Test]
        public void Insert_OneLevel()
        {
            JsonPatch jp = new();

            jp.Append("$.x"u8, "value1");

            Assert.AreEqual("[\"value1\"]", jp.GetJson("$.x"u8).ToString());

            jp.Append("$.x"u8, "value2");

            Assert.AreEqual("[\"value1\",\"value2\"]", jp.GetJson("$.x"u8).ToString());
            Assert.AreEqual("value1", jp.GetString("$.x[0]"u8));
            Assert.AreEqual("value2", jp.GetString("$.x[1]"u8));

            Assert.AreEqual("{\"x\":[\"value1\",\"value2\"]}", jp.ToString("J"));
        }

        [Test]
        public void RootAndInsert_Root_WithProperty()
        {
            JsonPatch jp = new(new("[{\"a\":\"value1\"},{\"a\":\"value2\"}]"u8.ToArray()));

            Assert.AreEqual("{\"a\":\"value1\"}", jp.GetJson("$[0]"u8).ToString());
            Assert.AreEqual("value1", jp.GetString("$[0].a"u8));
            Assert.AreEqual("{\"a\":\"value2\"}", jp.GetJson("$[1]"u8).ToString());
            Assert.AreEqual("value2", jp.GetString("$[1].a"u8));

            jp.Append("$"u8, "{\"a\":\"value3\"}"u8);

            Assert.AreEqual("[{\"a\":\"value1\"},{\"a\":\"value2\"},{\"a\":\"value3\"}]", jp.GetJson("$"u8).ToString());

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

            Assert.AreEqual("[{\"a\":\"value1\"},{\"a\":\"value2\"},{\"a\":\"value3\"},{\"a\":\"value4\"}]", jp.ToString("J"));
        }

        [Test]
        public void RootAndInsert_Root()
        {
            JsonPatch jp = new(new("[\"value1\",\"value2\"]"u8.ToArray()));

            Assert.AreEqual("value1", jp.GetString("$[0]"u8));
            Assert.AreEqual("value2", jp.GetString("$[1]"u8));

            jp.Append("$"u8, "value3");

            Assert.AreEqual("[\"value1\",\"value2\",\"value3\"]", jp.GetJson("$"u8).ToString());

            jp.Append("$"u8, "value4");

            Assert.AreEqual("[\"value1\",\"value2\",\"value3\",\"value4\"]", jp.GetJson("$"u8).ToString());
            Assert.AreEqual("value1", jp.GetString("$[0]"u8));
            Assert.AreEqual("value2", jp.GetString("$[1]"u8));
            Assert.AreEqual("value3", jp.GetString("$[2]"u8));
            Assert.AreEqual("value4", jp.GetString("$[3]"u8));

            Assert.AreEqual("[\"value1\",\"value2\",\"value3\",\"value4\"]", jp.ToString("J"));
        }

        [Test]
        public void Insert_Root_WithProperty()
        {
            JsonPatch jp = new();

            jp.Append("$"u8, "{\"a\":\"value1\"}"u8);

            Assert.AreEqual("[{\"a\":\"value1\"}]", jp.GetJson("$"u8).ToString());

            jp.Append("$"u8, "{\"a\":\"value2\"}"u8);

            Assert.AreEqual("[{\"a\":\"value1\"},{\"a\":\"value2\"}]", jp.GetJson("$"u8).ToString());
            Assert.AreEqual("{\"a\":\"value1\"}", jp.GetJson("$[0]"u8).ToString());
            Assert.AreEqual("value1", jp.GetString("$[0].a"u8));
            Assert.AreEqual("{\"a\":\"value2\"}", jp.GetJson("$[1]"u8).ToString());
            Assert.AreEqual("value2", jp.GetString("$[1].a"u8));

            Assert.AreEqual("[{\"a\":\"value1\"},{\"a\":\"value2\"}]", jp.ToString("J"));
        }

        [Test]
        public void Insert_Root()
        {
            JsonPatch jp = new();

            jp.Append("$"u8, "value1");

            Assert.AreEqual("[\"value1\"]", jp.GetJson("$"u8).ToString());

            jp.Append("$"u8, "value2");

            Assert.AreEqual("[\"value1\",\"value2\"]", jp.GetJson("$"u8).ToString());
            Assert.AreEqual("value1", jp.GetString("$[0]"u8));
            Assert.AreEqual("value2", jp.GetString("$[1]"u8));

            Assert.AreEqual("[\"value1\",\"value2\"]", jp.ToString("J"));
        }
    }
}
