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

            Assert.That(jp.GetJson("$.arr"u8).ToString(), Is.EqualTo("[1,2,3,4,5,6,7,8,9,10,11,12,13]"));
            Assert.That(jp.GetInt32("$.arr[0]"u8), Is.EqualTo(1));
            Assert.That(jp.GetInt32("$.arr[1]"u8), Is.EqualTo(2));
            Assert.That(jp.GetInt32("$.arr[2]"u8), Is.EqualTo(3));
            Assert.That(jp.GetInt32("$.arr[3]"u8), Is.EqualTo(4));
            Assert.That(jp.GetInt32("$.arr[4]"u8), Is.EqualTo(5));
            Assert.That(jp.GetInt32("$.arr[5]"u8), Is.EqualTo(6));
            Assert.That(jp.GetInt32("$.arr[6]"u8), Is.EqualTo(7));
            Assert.That(jp.GetInt32("$.arr[7]"u8), Is.EqualTo(8));
            Assert.That(jp.GetInt32("$.arr[8]"u8), Is.EqualTo(9));
            Assert.That(jp.GetInt32("$.arr[9]"u8), Is.EqualTo(10));
            Assert.That(jp.GetInt32("$.arr[10]"u8), Is.EqualTo(11));
            Assert.That(jp.GetInt32("$.arr[11]"u8), Is.EqualTo(12));
            Assert.That(jp.GetInt32("$.arr[12]"u8), Is.EqualTo(13));

            Assert.That(jp.ToString("J"), Is.EqualTo("{\"arr\":[1,2,3,4,5,6,7,8,9,10,11,12,13]}"));
        }

        [Test]
        public void AppendWithMoreThanTen()
        {
            JsonPatch jp = new("{\"arr\":[1,2,3,4,5,6,7,8,9,10,11]}"u8.ToArray());

            jp.Append("$.arr"u8, 12);
            jp.Append("$.arr"u8, 13);

            Assert.That(jp.GetJson("$.arr"u8).ToString(), Is.EqualTo("[1,2,3,4,5,6,7,8,9,10,11,12,13]"));
            Assert.That(jp.GetInt32("$.arr[0]"u8), Is.EqualTo(1));
            Assert.That(jp.GetInt32("$.arr[1]"u8), Is.EqualTo(2));
            Assert.That(jp.GetInt32("$.arr[2]"u8), Is.EqualTo(3));
            Assert.That(jp.GetInt32("$.arr[3]"u8), Is.EqualTo(4));
            Assert.That(jp.GetInt32("$.arr[4]"u8), Is.EqualTo(5));
            Assert.That(jp.GetInt32("$.arr[5]"u8), Is.EqualTo(6));
            Assert.That(jp.GetInt32("$.arr[6]"u8), Is.EqualTo(7));
            Assert.That(jp.GetInt32("$.arr[7]"u8), Is.EqualTo(8));
            Assert.That(jp.GetInt32("$.arr[8]"u8), Is.EqualTo(9));
            Assert.That(jp.GetInt32("$.arr[9]"u8), Is.EqualTo(10));
            Assert.That(jp.GetInt32("$.arr[10]"u8), Is.EqualTo(11));
            Assert.That(jp.GetInt32("$.arr[11]"u8), Is.EqualTo(12));
            Assert.That(jp.GetInt32("$.arr[12]"u8), Is.EqualTo(13));

            Assert.That(jp.ToString("J"), Is.EqualTo("{\"arr\":[1,2,3,4,5,6,7,8,9,10,11,12,13]}"));
        }

        [Test]
        public void RootAndInsert_ParentBeforeOutOfOrder()
        {
            JsonPatch jp = new("{\"a\":{\"b\":[[\"value1\",\"value3\"],[\"value2\"]]}}"u8.ToArray());

            Assert.That(jp.GetJson("$.a"u8).ToString(), Is.EqualTo("{\"b\":[[\"value1\",\"value3\"],[\"value2\"]]}"));
            Assert.That(jp.GetJson("$.a.b"u8).ToString(), Is.EqualTo("[[\"value1\",\"value3\"],[\"value2\"]]"));
            Assert.That(jp.GetJson("$.a.b[0]"u8).ToArray(), Is.EqualTo("[\"value1\",\"value3\"]"));
            Assert.That(jp.GetString("$.a.b[0][0]"u8), Is.EqualTo("value1"));
            Assert.That(jp.GetString("$.a.b[0][1]"u8), Is.EqualTo("value3"));
            Assert.That(jp.GetJson("$.a.b[1]"u8).ToArray(), Is.EqualTo("[\"value2\"]"));
            Assert.That(jp.GetString("$.a.b[1][0]"u8), Is.EqualTo("value2"));

            jp.Append("$.a.b"u8, "[\"value4\"]"u8);

            Assert.That(jp.GetJson("$.a.b"u8).ToString(), Is.EqualTo("[[\"value1\",\"value3\"],[\"value2\"],[\"value4\"]]"));

            jp.Append("$.a.b[1]"u8, "value5");

            Assert.That(jp.GetJson("$.a.b"u8).ToString(), Is.EqualTo("[[\"value1\",\"value3\"],[\"value2\",\"value5\"],[\"value4\"]]"));

            jp.Append("$.a.b[0]"u8, "value6");

            Assert.That(jp.GetJson("$.a.b"u8).ToString(), Is.EqualTo("[[\"value1\",\"value3\",\"value6\"],[\"value2\",\"value5\"],[\"value4\"]]"));
            Assert.That(jp.GetJson("$.a.b[0]"u8).ToString(), Is.EqualTo("[\"value1\",\"value3\",\"value6\"]"));
            Assert.That(jp.GetString("$.a.b[0][0]"u8), Is.EqualTo("value1"));
            Assert.That(jp.GetString("$.a.b[0][1]"u8), Is.EqualTo("value3"));
            Assert.That(jp.GetString("$.a.b[0][2]"u8), Is.EqualTo("value6"));
            Assert.That(jp.GetJson("$.a.b[1]"u8).ToString(), Is.EqualTo("[\"value2\",\"value5\"]"));
            Assert.That(jp.GetString("$.a.b[1][0]"u8), Is.EqualTo("value2"));
            Assert.That(jp.GetString("$.a.b[1][1]"u8), Is.EqualTo("value5"));
            Assert.That(jp.GetJson("$.a.b[2]"u8).ToString(), Is.EqualTo("[\"value4\"]"));
            Assert.That(jp.GetString("$.a.b[2][0]"u8), Is.EqualTo("value4"));

            Assert.That(jp.ToString("J"), Is.EqualTo("{\"a\":{\"b\":[[\"value1\",\"value3\",\"value6\"],[\"value2\",\"value5\"],[\"value4\"]]}}"));
        }

        [Test]
        public void Insert_ParentBeforeOutOfOrder()
        {
            JsonPatch jp = new();

            jp.Append("$.a.b"u8, "[\"value1\"]"u8);

            Assert.That(jp.GetJson("$.a"u8).ToString(), Is.EqualTo("{\"b\":[[\"value1\"]]}"));

            jp.Append("$.a.b[1]"u8, "value2");

            Assert.That(jp.GetJson("$.a"u8).ToString(), Is.EqualTo("{\"b\":[[\"value1\"],[\"value2\"]]}"));

            jp.Append("$.a.b[0]"u8, "value3");

            Assert.That(jp.GetJson("$.a"u8).ToString(), Is.EqualTo("{\"b\":[[\"value1\",\"value3\"],[\"value2\"]]}"));
            Assert.That(jp.GetJson("$.a.b"u8).ToString(), Is.EqualTo("[[\"value1\",\"value3\"],[\"value2\"]]"));
            Assert.That(jp.GetJson("$.a.b[0]"u8).ToArray(), Is.EqualTo("[\"value1\",\"value3\"]"));
            Assert.That(jp.GetString("$.a.b[0][0]"u8), Is.EqualTo("value1"));
            Assert.That(jp.GetString("$.a.b[0][1]"u8), Is.EqualTo("value3"));
            Assert.That(jp.GetJson("$.a.b[1]"u8).ToArray(), Is.EqualTo("[\"value2\"]"));
            Assert.That(jp.GetString("$.a.b[1][0]"u8), Is.EqualTo("value2"));

            Assert.That(jp.ToString("J"), Is.EqualTo("{\"a\":{\"b\":[[\"value1\",\"value3\"],[\"value2\"]]}}"));
        }

        [Test]
        public void RootAndInsert_OutOfOrder()
        {
            JsonPatch jp = new("{\"a\":{\"b\":[[\"value1\"],[\"value2\"]]}}"u8.ToArray());

            Assert.That(jp.GetJson("$.a"u8).ToString(), Is.EqualTo("{\"b\":[[\"value1\"],[\"value2\"]]}"));
            Assert.That(jp.GetJson("$.a.b"u8).ToString(), Is.EqualTo("[[\"value1\"],[\"value2\"]]"));
            Assert.That(jp.GetJson("$.a.b[0]"u8).ToArray(), Is.EqualTo("[\"value1\"]"));
            Assert.That(jp.GetString("$.a.b[0][0]"u8), Is.EqualTo("value1"));
            Assert.That(jp.GetJson("$.a.b[1]"u8).ToArray(), Is.EqualTo("[\"value2\"]"));
            Assert.That(jp.GetString("$.a.b[1][0]"u8), Is.EqualTo("value2"));

            jp.Append("$.a.b[0]"u8, "value1b");

            Assert.That(jp.GetJson("$.a.b[0]"u8).ToString(), Is.EqualTo("[\"value1\",\"value1b\"]"));

            jp.Append("$.a.b[1]"u8, "value2b");

            Assert.That(jp.GetJson("$.a.b[1]"u8).ToString(), Is.EqualTo("[\"value2\",\"value2b\"]"));

            jp.Append("$.a.b[3]"u8, "value4");

            Assert.That(jp.GetJson("$.a.b[3]"u8).ToString(), Is.EqualTo("[\"value4\"]"));

            jp.Append("$.a.b[2]"u8, "value3");

            Assert.That(jp.GetJson("$.a.b[2]"u8).ToString(), Is.EqualTo("[\"value3\"]"));

            jp.Append("$.a.b"u8, "[\"value5\"]"u8);

            Assert.That(jp.GetJson("$.a.b"u8).ToString(), Is.EqualTo("[[\"value1\",\"value1b\"],[\"value2\",\"value2b\"],[\"value3\"],[\"value4\"],[\"value5\"]]"));
            Assert.That(jp.GetJson("$.a.b[0]"u8).ToString(), Is.EqualTo("[\"value1\",\"value1b\"]"));
            Assert.That(jp.GetString("$.a.b[0][0]"u8), Is.EqualTo("value1"));
            Assert.That(jp.GetString("$.a.b[0][1]"u8), Is.EqualTo("value1b"));
            Assert.That(jp.GetJson("$.a.b[1]"u8).ToString(), Is.EqualTo("[\"value2\",\"value2b\"]"));
            Assert.That(jp.GetString("$.a.b[1][0]"u8), Is.EqualTo("value2"));
            Assert.That(jp.GetString("$.a.b[1][1]"u8), Is.EqualTo("value2b"));
            Assert.That(jp.GetJson("$.a.b[2]"u8).ToString(), Is.EqualTo("[\"value3\"]"));
            Assert.That(jp.GetString("$.a.b[2][0]"u8), Is.EqualTo("value3"));
            Assert.That(jp.GetJson("$.a.b[3]"u8).ToString(), Is.EqualTo("[\"value4\"]"));
            Assert.That(jp.GetString("$.a.b[3][0]"u8), Is.EqualTo("value4"));
            Assert.That(jp.GetJson("$.a.b[4]"u8).ToString(), Is.EqualTo("[\"value5\"]"));
            Assert.That(jp.GetString("$.a.b[4][0]"u8), Is.EqualTo("value5"));

            Assert.That(jp.ToString("J"), Is.EqualTo("{\"a\":{\"b\":[[\"value1\",\"value1b\"],[\"value2\",\"value2b\"],[\"value3\"],[\"value4\"],[\"value5\"]]}}"));
        }

        [Test]
        public void Insert_OutOfOrder()
        {
            JsonPatch jp = new();

            jp.Append("$.a.b[1]"u8, "value2");

            Assert.That(jp.GetJson("$.a"u8).ToString(), Is.EqualTo("{\"b\":[null,[\"value2\"]]}"));

            jp.Append("$.a.b[0]"u8, "value1");

            Assert.That(jp.GetJson("$.a"u8).ToString(), Is.EqualTo("{\"b\":[[\"value1\"],[\"value2\"]]}"));
            Assert.That(jp.GetJson("$.a.b"u8).ToString(), Is.EqualTo("[[\"value1\"],[\"value2\"]]"));
            Assert.That(jp.GetJson("$.a.b[0]"u8).ToArray(), Is.EqualTo("[\"value1\"]"));
            Assert.That(jp.GetString("$.a.b[0][0]"u8), Is.EqualTo("value1"));
            Assert.That(jp.GetJson("$.a.b[1]"u8).ToArray(), Is.EqualTo("[\"value2\"]"));
            Assert.That(jp.GetString("$.a.b[1][0]"u8), Is.EqualTo("value2"));

            Assert.That(jp.ToString("J"), Is.EqualTo("{\"a\":{\"b\":[[\"value1\"],[\"value2\"]]}}"));
        }

        [Test]
        public void RootAndInsert_ThreeDimensionTwoDimension_WithProperty()
        {
            JsonPatch jp = new("{\"x\":{\"y\":[[[{\"z\":{\"a\":[[{\"b\":\"value1\"},{\"b\":\"value2\"}],[{\"b\":\"value3\"},{\"b\":\"value4\"}]]}},{\"z\":{\"a\":[[{\"b\":\"value5\"},{\"b\":\"value6\"}]]}}],[{\"z\":{\"a\":[[{\"b\":\"value7\"},{\"b\":\"value8\"}],[{\"b\":\"value9\"},{\"b\":\"value10\"}]]}}]],[[{\"z\":{\"a\":[[{\"b\":\"value11\"}]]}}]]]}}"u8.ToArray());

            Assert.That(jp.GetJson("$.x"u8).ToString(), Is.EqualTo("{\"y\":[[[{\"z\":{\"a\":[[{\"b\":\"value1\"},{\"b\":\"value2\"}],[{\"b\":\"value3\"},{\"b\":\"value4\"}]]}},{\"z\":{\"a\":[[{\"b\":\"value5\"},{\"b\":\"value6\"}]]}}],[{\"z\":{\"a\":[[{\"b\":\"value7\"},{\"b\":\"value8\"}],[{\"b\":\"value9\"},{\"b\":\"value10\"}]]}}]],[[{\"z\":{\"a\":[[{\"b\":\"value11\"}]]}}]]]}"));
            Assert.That(jp.GetJson("$.x.y"u8).ToString(), Is.EqualTo("[[[{\"z\":{\"a\":[[{\"b\":\"value1\"},{\"b\":\"value2\"}],[{\"b\":\"value3\"},{\"b\":\"value4\"}]]}},{\"z\":{\"a\":[[{\"b\":\"value5\"},{\"b\":\"value6\"}]]}}],[{\"z\":{\"a\":[[{\"b\":\"value7\"},{\"b\":\"value8\"}],[{\"b\":\"value9\"},{\"b\":\"value10\"}]]}}]],[[{\"z\":{\"a\":[[{\"b\":\"value11\"}]]}}]]]"));
            Assert.That(jp.GetJson("$.x.y[0]"u8).ToString(), Is.EqualTo("[[{\"z\":{\"a\":[[{\"b\":\"value1\"},{\"b\":\"value2\"}],[{\"b\":\"value3\"},{\"b\":\"value4\"}]]}},{\"z\":{\"a\":[[{\"b\":\"value5\"},{\"b\":\"value6\"}]]}}],[{\"z\":{\"a\":[[{\"b\":\"value7\"},{\"b\":\"value8\"}],[{\"b\":\"value9\"},{\"b\":\"value10\"}]]}}]]"));
            Assert.That(jp.GetJson("$.x.y[0][0]"u8).ToString(), Is.EqualTo("[{\"z\":{\"a\":[[{\"b\":\"value1\"},{\"b\":\"value2\"}],[{\"b\":\"value3\"},{\"b\":\"value4\"}]]}},{\"z\":{\"a\":[[{\"b\":\"value5\"},{\"b\":\"value6\"}]]}}]"));
            Assert.That(jp.GetJson("$.x.y[0][0][0]"u8).ToString(), Is.EqualTo("{\"z\":{\"a\":[[{\"b\":\"value1\"},{\"b\":\"value2\"}],[{\"b\":\"value3\"},{\"b\":\"value4\"}]]}}"));
            Assert.That(jp.GetJson("$.x.y[0][0][0].z"u8).ToString(), Is.EqualTo("{\"a\":[[{\"b\":\"value1\"},{\"b\":\"value2\"}],[{\"b\":\"value3\"},{\"b\":\"value4\"}]]}"));
            Assert.That(jp.GetJson("$.x.y[0][0][0].z.a"u8).ToString(), Is.EqualTo("[[{\"b\":\"value1\"},{\"b\":\"value2\"}],[{\"b\":\"value3\"},{\"b\":\"value4\"}]]"));
            Assert.That(jp.GetJson("$.x.y[0][0][0].z.a[0]"u8).ToString(), Is.EqualTo("[{\"b\":\"value1\"},{\"b\":\"value2\"}]"));
            Assert.That(jp.GetJson("$.x.y[0][0][0].z.a[0][0]"u8).ToString(), Is.EqualTo("{\"b\":\"value1\"}"));
            Assert.That(jp.GetString("$.x.y[0][0][0].z.a[0][0].b"u8), Is.EqualTo("value1"));
            Assert.That(jp.GetJson("$.x.y[0][0][0].z.a[0][1]"u8).ToString(), Is.EqualTo("{\"b\":\"value2\"}"));
            Assert.That(jp.GetString("$.x.y[0][0][0].z.a[0][1].b"u8), Is.EqualTo("value2"));
            Assert.That(jp.GetJson("$.x.y[0][0][0].z.a[1]"u8).ToString(), Is.EqualTo("[{\"b\":\"value3\"},{\"b\":\"value4\"}]"));
            Assert.That(jp.GetJson("$.x.y[0][0][0].z.a[1][0]"u8).ToString(), Is.EqualTo("{\"b\":\"value3\"}"));
            Assert.That(jp.GetString("$.x.y[0][0][0].z.a[1][0].b"u8), Is.EqualTo("value3"));
            Assert.That(jp.GetJson("$.x.y[0][0][0].z.a[1][1]"u8).ToString(), Is.EqualTo("{\"b\":\"value4\"}"));
            Assert.That(jp.GetString("$.x.y[0][0][0].z.a[1][1].b"u8), Is.EqualTo("value4"));
            Assert.That(jp.GetJson("$.x.y[0][0][1]"u8).ToString(), Is.EqualTo("{\"z\":{\"a\":[[{\"b\":\"value5\"},{\"b\":\"value6\"}]]}}"));
            Assert.That(jp.GetJson("$.x.y[0][0][1].z"u8).ToString(), Is.EqualTo("{\"a\":[[{\"b\":\"value5\"},{\"b\":\"value6\"}]]}"));
            Assert.That(jp.GetJson("$.x.y[0][0][1].z.a"u8).ToString(), Is.EqualTo("[[{\"b\":\"value5\"},{\"b\":\"value6\"}]]"));
            Assert.That(jp.GetJson("$.x.y[0][0][1].z.a[0]"u8).ToString(), Is.EqualTo("[{\"b\":\"value5\"},{\"b\":\"value6\"}]"));
            Assert.That(jp.GetJson("$.x.y[0][0][1].z.a[0][0]"u8).ToString(), Is.EqualTo("{\"b\":\"value5\"}"));
            Assert.That(jp.GetString("$.x.y[0][0][1].z.a[0][0].b"u8), Is.EqualTo("value5"));
            Assert.That(jp.GetJson("$.x.y[0][0][1].z.a[0][1]"u8).ToString(), Is.EqualTo("{\"b\":\"value6\"}"));
            Assert.That(jp.GetString("$.x.y[0][0][1].z.a[0][1].b"u8), Is.EqualTo("value6"));
            Assert.That(jp.GetJson("$.x.y[0][1]"u8).ToString(), Is.EqualTo("[{\"z\":{\"a\":[[{\"b\":\"value7\"},{\"b\":\"value8\"}],[{\"b\":\"value9\"},{\"b\":\"value10\"}]]}}]"));
            Assert.That(jp.GetJson("$.x.y[0][1][0]"u8).ToString(), Is.EqualTo("{\"z\":{\"a\":[[{\"b\":\"value7\"},{\"b\":\"value8\"}],[{\"b\":\"value9\"},{\"b\":\"value10\"}]]}}"));
            Assert.That(jp.GetJson("$.x.y[0][1][0].z"u8).ToString(), Is.EqualTo("{\"a\":[[{\"b\":\"value7\"},{\"b\":\"value8\"}],[{\"b\":\"value9\"},{\"b\":\"value10\"}]]}"));
            Assert.That(jp.GetJson("$.x.y[0][1][0].z.a"u8).ToString(), Is.EqualTo("[[{\"b\":\"value7\"},{\"b\":\"value8\"}],[{\"b\":\"value9\"},{\"b\":\"value10\"}]]"));
            Assert.That(jp.GetJson("$.x.y[0][1][0].z.a[0]"u8).ToString(), Is.EqualTo("[{\"b\":\"value7\"},{\"b\":\"value8\"}]"));
            Assert.That(jp.GetJson("$.x.y[0][1][0].z.a[0][0]"u8).ToString(), Is.EqualTo("{\"b\":\"value7\"}"));
            Assert.That(jp.GetString("$.x.y[0][1][0].z.a[0][0].b"u8), Is.EqualTo("value7"));
            Assert.That(jp.GetJson("$.x.y[0][1][0].z.a[0][1]"u8).ToString(), Is.EqualTo("{\"b\":\"value8\"}"));
            Assert.That(jp.GetString("$.x.y[0][1][0].z.a[0][1].b"u8), Is.EqualTo("value8"));
            Assert.That(jp.GetJson("$.x.y[0][1][0].z.a[1]"u8).ToString(), Is.EqualTo("[{\"b\":\"value9\"},{\"b\":\"value10\"}]"));
            Assert.That(jp.GetJson("$.x.y[0][1][0].z.a[1][0]"u8).ToString(), Is.EqualTo("{\"b\":\"value9\"}"));
            Assert.That(jp.GetString("$.x.y[0][1][0].z.a[1][0].b"u8), Is.EqualTo("value9"));
            Assert.That(jp.GetJson("$.x.y[0][1][0].z.a[1][1]"u8).ToString(), Is.EqualTo("{\"b\":\"value10\"}"));
            Assert.That(jp.GetString("$.x.y[0][1][0].z.a[1][1].b"u8), Is.EqualTo("value10"));
            Assert.That(jp.GetJson("$.x.y[1]"u8).ToString(), Is.EqualTo("[[{\"z\":{\"a\":[[{\"b\":\"value11\"}]]}}]]"));
            Assert.That(jp.GetJson("$.x.y[1][0]"u8).ToString(), Is.EqualTo("[{\"z\":{\"a\":[[{\"b\":\"value11\"}]]}}]"));
            Assert.That(jp.GetJson("$.x.y[1][0][0]"u8).ToString(), Is.EqualTo("{\"z\":{\"a\":[[{\"b\":\"value11\"}]]}}"));
            Assert.That(jp.GetJson("$.x.y[1][0][0].z"u8).ToString(), Is.EqualTo("{\"a\":[[{\"b\":\"value11\"}]]}"));
            Assert.That(jp.GetJson("$.x.y[1][0][0].z.a"u8).ToString(), Is.EqualTo("[[{\"b\":\"value11\"}]]"));
            Assert.That(jp.GetJson("$.x.y[1][0][0].z.a[0]"u8).ToString(), Is.EqualTo("[{\"b\":\"value11\"}]"));
            Assert.That(jp.GetJson("$.x.y[1][0][0].z.a[0][0]"u8).ToString(), Is.EqualTo("{\"b\":\"value11\"}"));
            Assert.That(jp.GetString("$.x.y[1][0][0].z.a[0][0].b"u8), Is.EqualTo("value11"));

            jp.Append("$.x.y"u8, "[[{\"z\":{\"a\":[[{\"b\":\"value12\"}]]}}]]"u8);

            Assert.That(jp.GetJson("$.x.y"u8).ToString(), Is.EqualTo("[[[{\"z\":{\"a\":[[{\"b\":\"value1\"},{\"b\":\"value2\"}],[{\"b\":\"value3\"},{\"b\":\"value4\"}]]}},{\"z\":{\"a\":[[{\"b\":\"value5\"},{\"b\":\"value6\"}]]}}],[{\"z\":{\"a\":[[{\"b\":\"value7\"},{\"b\":\"value8\"}],[{\"b\":\"value9\"},{\"b\":\"value10\"}]]}}]],[[{\"z\":{\"a\":[[{\"b\":\"value11\"}]]}}]],[[{\"z\":{\"a\":[[{\"b\":\"value12\"}]]}}]]]"));

            jp.Append("$.x.y[1]"u8, "[{\"z\":{\"a\":[[{\"b\":\"value13\"}]]}}]"u8);

            Assert.That(jp.GetJson("$.x.y"u8).ToString(), Is.EqualTo("[[[{\"z\":{\"a\":[[{\"b\":\"value1\"},{\"b\":\"value2\"}],[{\"b\":\"value3\"},{\"b\":\"value4\"}]]}},{\"z\":{\"a\":[[{\"b\":\"value5\"},{\"b\":\"value6\"}]]}}],[{\"z\":{\"a\":[[{\"b\":\"value7\"},{\"b\":\"value8\"}],[{\"b\":\"value9\"},{\"b\":\"value10\"}]]}}]],[[{\"z\":{\"a\":[[{\"b\":\"value11\"}]]}}],[{\"z\":{\"a\":[[{\"b\":\"value13\"}]]}}]],[[{\"z\":{\"a\":[[{\"b\":\"value12\"}]]}}]]]"));

            jp.Append("$.x.y[1][0]"u8, "{\"z\":{\"a\":[[{\"b\":\"value14\"}]]}}"u8);

            Assert.That(jp.GetJson("$.x.y"u8).ToString(), Is.EqualTo("[[[{\"z\":{\"a\":[[{\"b\":\"value1\"},{\"b\":\"value2\"}],[{\"b\":\"value3\"},{\"b\":\"value4\"}]]}},{\"z\":{\"a\":[[{\"b\":\"value5\"},{\"b\":\"value6\"}]]}}],[{\"z\":{\"a\":[[{\"b\":\"value7\"},{\"b\":\"value8\"}],[{\"b\":\"value9\"},{\"b\":\"value10\"}]]}}]],[[{\"z\":{\"a\":[[{\"b\":\"value11\"}]]}},{\"z\":{\"a\":[[{\"b\":\"value14\"}]]}}],[{\"z\":{\"a\":[[{\"b\":\"value13\"}]]}}]],[[{\"z\":{\"a\":[[{\"b\":\"value12\"}]]}}]]]"));

            jp.Append("$.x.y[1][0][0].z.a"u8, "[{\"b\":\"value15\"}]"u8);

            Assert.That(jp.GetJson("$.x.y"u8).ToString(), Is.EqualTo("[[[{\"z\":{\"a\":[[{\"b\":\"value1\"},{\"b\":\"value2\"}],[{\"b\":\"value3\"},{\"b\":\"value4\"}]]}},{\"z\":{\"a\":[[{\"b\":\"value5\"},{\"b\":\"value6\"}]]}}],[{\"z\":{\"a\":[[{\"b\":\"value7\"},{\"b\":\"value8\"}],[{\"b\":\"value9\"},{\"b\":\"value10\"}]]}}]],[[{\"z\":{\"a\":[[{\"b\":\"value11\"}],[{\"b\":\"value15\"}]]}},{\"z\":{\"a\":[[{\"b\":\"value14\"}]]}}],[{\"z\":{\"a\":[[{\"b\":\"value13\"}]]}}]],[[{\"z\":{\"a\":[[{\"b\":\"value12\"}]]}}]]]"));

            jp.Append("$.x.y[2][0][0].z.a"u8, "[{\"b\":\"value16\"}]"u8);

            Assert.That(jp.GetJson("$.x.y"u8).ToString(), Is.EqualTo("[[[{\"z\":{\"a\":[[{\"b\":\"value1\"},{\"b\":\"value2\"}],[{\"b\":\"value3\"},{\"b\":\"value4\"}]]}},{\"z\":{\"a\":[[{\"b\":\"value5\"},{\"b\":\"value6\"}]]}}],[{\"z\":{\"a\":[[{\"b\":\"value7\"},{\"b\":\"value8\"}],[{\"b\":\"value9\"},{\"b\":\"value10\"}]]}}]],[[{\"z\":{\"a\":[[{\"b\":\"value11\"}],[{\"b\":\"value15\"}]]}},{\"z\":{\"a\":[[{\"b\":\"value14\"}]]}}],[{\"z\":{\"a\":[[{\"b\":\"value13\"}]]}}]],[[{\"z\":{\"a\":[[{\"b\":\"value12\"}],[{\"b\":\"value16\"}]]}}]]]"));

            jp.Append("$.x.y[2][0][0].z.a[1]"u8, "{\"b\":\"value17\"}"u8);

            Assert.That(jp.GetJson("$.x"u8).ToString(), Is.EqualTo("{\"y\":[[[{\"z\":{\"a\":[[{\"b\":\"value1\"},{\"b\":\"value2\"}],[{\"b\":\"value3\"},{\"b\":\"value4\"}]]}},{\"z\":{\"a\":[[{\"b\":\"value5\"},{\"b\":\"value6\"}]]}}],[{\"z\":{\"a\":[[{\"b\":\"value7\"},{\"b\":\"value8\"}],[{\"b\":\"value9\"},{\"b\":\"value10\"}]]}}]],[[{\"z\":{\"a\":[[{\"b\":\"value11\"}]]}}]]]}"));
            Assert.That(jp.GetJson("$.x.y"u8).ToString(), Is.EqualTo("[[[{\"z\":{\"a\":[[{\"b\":\"value1\"},{\"b\":\"value2\"}],[{\"b\":\"value3\"},{\"b\":\"value4\"}]]}},{\"z\":{\"a\":[[{\"b\":\"value5\"},{\"b\":\"value6\"}]]}}],[{\"z\":{\"a\":[[{\"b\":\"value7\"},{\"b\":\"value8\"}],[{\"b\":\"value9\"},{\"b\":\"value10\"}]]}}]],[[{\"z\":{\"a\":[[{\"b\":\"value11\"}],[{\"b\":\"value15\"}]]}},{\"z\":{\"a\":[[{\"b\":\"value14\"}]]}}],[{\"z\":{\"a\":[[{\"b\":\"value13\"}]]}}]],[[{\"z\":{\"a\":[[{\"b\":\"value12\"}],[{\"b\":\"value16\"},{\"b\":\"value17\"}]]}}]]]"));
            Assert.That(jp.GetJson("$.x.y[0]"u8).ToString(), Is.EqualTo("[[{\"z\":{\"a\":[[{\"b\":\"value1\"},{\"b\":\"value2\"}],[{\"b\":\"value3\"},{\"b\":\"value4\"}]]}},{\"z\":{\"a\":[[{\"b\":\"value5\"},{\"b\":\"value6\"}]]}}],[{\"z\":{\"a\":[[{\"b\":\"value7\"},{\"b\":\"value8\"}],[{\"b\":\"value9\"},{\"b\":\"value10\"}]]}}]]"));
            Assert.That(jp.GetJson("$.x.y[0][0]"u8).ToString(), Is.EqualTo("[{\"z\":{\"a\":[[{\"b\":\"value1\"},{\"b\":\"value2\"}],[{\"b\":\"value3\"},{\"b\":\"value4\"}]]}},{\"z\":{\"a\":[[{\"b\":\"value5\"},{\"b\":\"value6\"}]]}}]"));
            Assert.That(jp.GetJson("$.x.y[0][0][0]"u8).ToString(), Is.EqualTo("{\"z\":{\"a\":[[{\"b\":\"value1\"},{\"b\":\"value2\"}],[{\"b\":\"value3\"},{\"b\":\"value4\"}]]}}"));
            Assert.That(jp.GetJson("$.x.y[0][0][0].z"u8).ToString(), Is.EqualTo("{\"a\":[[{\"b\":\"value1\"},{\"b\":\"value2\"}],[{\"b\":\"value3\"},{\"b\":\"value4\"}]]}"));
            Assert.That(jp.GetJson("$.x.y[0][0][0].z.a"u8).ToString(), Is.EqualTo("[[{\"b\":\"value1\"},{\"b\":\"value2\"}],[{\"b\":\"value3\"},{\"b\":\"value4\"}]]"));
            Assert.That(jp.GetJson("$.x.y[0][0][0].z.a[0]"u8).ToString(), Is.EqualTo("[{\"b\":\"value1\"},{\"b\":\"value2\"}]"));
            Assert.That(jp.GetJson("$.x.y[0][0][0].z.a[0][0]"u8).ToString(), Is.EqualTo("{\"b\":\"value1\"}"));
            Assert.That(jp.GetString("$.x.y[0][0][0].z.a[0][0].b"u8), Is.EqualTo("value1"));
            Assert.That(jp.GetJson("$.x.y[0][0][0].z.a[0][1]"u8).ToString(), Is.EqualTo("{\"b\":\"value2\"}"));
            Assert.That(jp.GetString("$.x.y[0][0][0].z.a[0][1].b"u8), Is.EqualTo("value2"));
            Assert.That(jp.GetJson("$.x.y[0][0][0].z.a[1]"u8).ToString(), Is.EqualTo("[{\"b\":\"value3\"},{\"b\":\"value4\"}]"));
            Assert.That(jp.GetJson("$.x.y[0][0][0].z.a[1][0]"u8).ToString(), Is.EqualTo("{\"b\":\"value3\"}"));
            Assert.That(jp.GetString("$.x.y[0][0][0].z.a[1][0].b"u8), Is.EqualTo("value3"));
            Assert.That(jp.GetJson("$.x.y[0][0][0].z.a[1][1]"u8).ToString(), Is.EqualTo("{\"b\":\"value4\"}"));
            Assert.That(jp.GetString("$.x.y[0][0][0].z.a[1][1].b"u8), Is.EqualTo("value4"));
            Assert.That(jp.GetJson("$.x.y[0][0][1]"u8).ToString(), Is.EqualTo("{\"z\":{\"a\":[[{\"b\":\"value5\"},{\"b\":\"value6\"}]]}}"));
            Assert.That(jp.GetJson("$.x.y[0][0][1].z"u8).ToString(), Is.EqualTo("{\"a\":[[{\"b\":\"value5\"},{\"b\":\"value6\"}]]}"));
            Assert.That(jp.GetJson("$.x.y[0][0][1].z.a"u8).ToString(), Is.EqualTo("[[{\"b\":\"value5\"},{\"b\":\"value6\"}]]"));
            Assert.That(jp.GetJson("$.x.y[0][0][1].z.a[0]"u8).ToString(), Is.EqualTo("[{\"b\":\"value5\"},{\"b\":\"value6\"}]"));
            Assert.That(jp.GetJson("$.x.y[0][0][1].z.a[0][0]"u8).ToString(), Is.EqualTo("{\"b\":\"value5\"}"));
            Assert.That(jp.GetString("$.x.y[0][0][1].z.a[0][0].b"u8), Is.EqualTo("value5"));
            Assert.That(jp.GetJson("$.x.y[0][0][1].z.a[0][1]"u8).ToString(), Is.EqualTo("{\"b\":\"value6\"}"));
            Assert.That(jp.GetString("$.x.y[0][0][1].z.a[0][1].b"u8), Is.EqualTo("value6"));
            Assert.That(jp.GetJson("$.x.y[0][1]"u8).ToString(), Is.EqualTo("[{\"z\":{\"a\":[[{\"b\":\"value7\"},{\"b\":\"value8\"}],[{\"b\":\"value9\"},{\"b\":\"value10\"}]]}}]"));
            Assert.That(jp.GetJson("$.x.y[0][1][0]"u8).ToString(), Is.EqualTo("{\"z\":{\"a\":[[{\"b\":\"value7\"},{\"b\":\"value8\"}],[{\"b\":\"value9\"},{\"b\":\"value10\"}]]}}"));
            Assert.That(jp.GetJson("$.x.y[0][1][0].z"u8).ToString(), Is.EqualTo("{\"a\":[[{\"b\":\"value7\"},{\"b\":\"value8\"}],[{\"b\":\"value9\"},{\"b\":\"value10\"}]]}"));
            Assert.That(jp.GetJson("$.x.y[0][1][0].z.a"u8).ToString(), Is.EqualTo("[[{\"b\":\"value7\"},{\"b\":\"value8\"}],[{\"b\":\"value9\"},{\"b\":\"value10\"}]]"));
            Assert.That(jp.GetJson("$.x.y[0][1][0].z.a[0]"u8).ToString(), Is.EqualTo("[{\"b\":\"value7\"},{\"b\":\"value8\"}]"));
            Assert.That(jp.GetJson("$.x.y[0][1][0].z.a[0][0]"u8).ToString(), Is.EqualTo("{\"b\":\"value7\"}"));
            Assert.That(jp.GetString("$.x.y[0][1][0].z.a[0][0].b"u8), Is.EqualTo("value7"));
            Assert.That(jp.GetJson("$.x.y[0][1][0].z.a[0][1]"u8).ToString(), Is.EqualTo("{\"b\":\"value8\"}"));
            Assert.That(jp.GetString("$.x.y[0][1][0].z.a[0][1].b"u8), Is.EqualTo("value8"));
            Assert.That(jp.GetJson("$.x.y[0][1][0].z.a[1]"u8).ToString(), Is.EqualTo("[{\"b\":\"value9\"},{\"b\":\"value10\"}]"));
            Assert.That(jp.GetJson("$.x.y[0][1][0].z.a[1][0]"u8).ToString(), Is.EqualTo("{\"b\":\"value9\"}"));
            Assert.That(jp.GetString("$.x.y[0][1][0].z.a[1][0].b"u8), Is.EqualTo("value9"));
            Assert.That(jp.GetJson("$.x.y[0][1][0].z.a[1][1]"u8).ToString(), Is.EqualTo("{\"b\":\"value10\"}"));
            Assert.That(jp.GetString("$.x.y[0][1][0].z.a[1][1].b"u8), Is.EqualTo("value10"));
            Assert.That(jp.GetJson("$.x.y[1]"u8).ToString(), Is.EqualTo("[[{\"z\":{\"a\":[[{\"b\":\"value11\"}],[{\"b\":\"value15\"}]]}},{\"z\":{\"a\":[[{\"b\":\"value14\"}]]}}],[{\"z\":{\"a\":[[{\"b\":\"value13\"}]]}}]]"));
            Assert.That(jp.GetJson("$.x.y[1][0]"u8).ToString(), Is.EqualTo("[{\"z\":{\"a\":[[{\"b\":\"value11\"}],[{\"b\":\"value15\"}]]}},{\"z\":{\"a\":[[{\"b\":\"value14\"}]]}}]"));
            Assert.That(jp.GetJson("$.x.y[1][0][0]"u8).ToString(), Is.EqualTo("{\"z\":{\"a\":[[{\"b\":\"value11\"}],[{\"b\":\"value15\"}]]}}"));
            Assert.That(jp.GetJson("$.x.y[1][0][0].z"u8).ToString(), Is.EqualTo("{\"a\":[[{\"b\":\"value11\"}],[{\"b\":\"value15\"}]]}"));
            Assert.That(jp.GetJson("$.x.y[1][0][0].z.a"u8).ToString(), Is.EqualTo("[[{\"b\":\"value11\"}],[{\"b\":\"value15\"}]]"));
            Assert.That(jp.GetJson("$.x.y[1][0][0].z.a[0]"u8).ToString(), Is.EqualTo("[{\"b\":\"value11\"}]"));
            Assert.That(jp.GetJson("$.x.y[1][0][0].z.a[0][0]"u8).ToString(), Is.EqualTo("{\"b\":\"value11\"}"));
            Assert.That(jp.GetString("$.x.y[1][0][0].z.a[0][0].b"u8), Is.EqualTo("value11"));
            Assert.That(jp.GetJson("$.x.y[1][0][0].z.a[1]"u8).ToString(), Is.EqualTo("[{\"b\":\"value15\"}]"));
            Assert.That(jp.GetJson("$.x.y[1][0][0].z.a[1][0]"u8).ToString(), Is.EqualTo("{\"b\":\"value15\"}"));
            Assert.That(jp.GetString("$.x.y[1][0][0].z.a[1][0].b"u8), Is.EqualTo("value15"));
            Assert.That(jp.GetJson("$.x.y[1][0][1]"u8).ToString(), Is.EqualTo("{\"z\":{\"a\":[[{\"b\":\"value14\"}]]}}"));
            Assert.That(jp.GetJson("$.x.y[1][0][1].z"u8).ToString(), Is.EqualTo("{\"a\":[[{\"b\":\"value14\"}]]}"));
            Assert.That(jp.GetJson("$.x.y[1][0][1].z.a"u8).ToString(), Is.EqualTo("[[{\"b\":\"value14\"}]]"));
            Assert.That(jp.GetJson("$.x.y[1][0][1].z.a[0]"u8).ToString(), Is.EqualTo("[{\"b\":\"value14\"}]"));
            Assert.That(jp.GetJson("$.x.y[1][0][1].z.a[0][0]"u8).ToString(), Is.EqualTo("{\"b\":\"value14\"}"));
            Assert.That(jp.GetString("$.x.y[1][0][1].z.a[0][0].b"u8), Is.EqualTo("value14"));
            Assert.That(jp.GetJson("$.x.y[1][1]"u8).ToString(), Is.EqualTo("[{\"z\":{\"a\":[[{\"b\":\"value13\"}]]}}]"));
            Assert.That(jp.GetJson("$.x.y[1][1][0]"u8).ToString(), Is.EqualTo("{\"z\":{\"a\":[[{\"b\":\"value13\"}]]}}"));
            Assert.That(jp.GetJson("$.x.y[1][1][0].z"u8).ToString(), Is.EqualTo("{\"a\":[[{\"b\":\"value13\"}]]}"));
            Assert.That(jp.GetJson("$.x.y[1][1][0].z.a"u8).ToString(), Is.EqualTo("[[{\"b\":\"value13\"}]]"));
            Assert.That(jp.GetJson("$.x.y[1][1][0].z.a[0]"u8).ToString(), Is.EqualTo("[{\"b\":\"value13\"}]"));
            Assert.That(jp.GetJson("$.x.y[1][1][0].z.a[0][0]"u8).ToString(), Is.EqualTo("{\"b\":\"value13\"}"));
            Assert.That(jp.GetString("$.x.y[1][1][0].z.a[0][0].b"u8), Is.EqualTo("value13"));
            Assert.That(jp.GetJson("$.x.y[2]"u8).ToString(), Is.EqualTo("[[{\"z\":{\"a\":[[{\"b\":\"value12\"}],[{\"b\":\"value16\"},{\"b\":\"value17\"}]]}}]]"));
            Assert.That(jp.GetJson("$.x.y[2][0]"u8).ToString(), Is.EqualTo("[{\"z\":{\"a\":[[{\"b\":\"value12\"}],[{\"b\":\"value16\"},{\"b\":\"value17\"}]]}}]"));
            Assert.That(jp.GetJson("$.x.y[2][0][0]"u8).ToString(), Is.EqualTo("{\"z\":{\"a\":[[{\"b\":\"value12\"}],[{\"b\":\"value16\"},{\"b\":\"value17\"}]]}}"));
            Assert.That(jp.GetJson("$.x.y[2][0][0].z"u8).ToString(), Is.EqualTo("{\"a\":[[{\"b\":\"value12\"}],[{\"b\":\"value16\"},{\"b\":\"value17\"}]]}"));
            Assert.That(jp.GetJson("$.x.y[2][0][0].z.a"u8).ToString(), Is.EqualTo("[[{\"b\":\"value12\"}],[{\"b\":\"value16\"},{\"b\":\"value17\"}]]"));
            Assert.That(jp.GetJson("$.x.y[2][0][0].z.a[0]"u8).ToString(), Is.EqualTo("[{\"b\":\"value12\"}]"));
            Assert.That(jp.GetJson("$.x.y[2][0][0].z.a[0][0]"u8).ToString(), Is.EqualTo("{\"b\":\"value12\"}"));
            Assert.That(jp.GetString("$.x.y[2][0][0].z.a[0][0].b"u8), Is.EqualTo("value12"));
            Assert.That(jp.GetJson("$.x.y[2][0][0].z.a[1]"u8).ToString(), Is.EqualTo("[{\"b\":\"value16\"},{\"b\":\"value17\"}]"));
            Assert.That(jp.GetJson("$.x.y[2][0][0].z.a[1][0]"u8).ToString(), Is.EqualTo("{\"b\":\"value16\"}"));
            Assert.That(jp.GetString("$.x.y[2][0][0].z.a[1][0].b"u8), Is.EqualTo("value16"));
            Assert.That(jp.GetJson("$.x.y[2][0][0].z.a[1][1]"u8).ToString(), Is.EqualTo("{\"b\":\"value17\"}"));
            Assert.That(jp.GetString("$.x.y[2][0][0].z.a[1][1].b"u8), Is.EqualTo("value17"));

            Assert.That(jp.ToString("J"), Is.EqualTo("{\"x\":{\"y\":[[[{\"z\":{\"a\":[[{\"b\":\"value1\"},{\"b\":\"value2\"}],[{\"b\":\"value3\"},{\"b\":\"value4\"}]]}},{\"z\":{\"a\":[[{\"b\":\"value5\"},{\"b\":\"value6\"}]]}}],[{\"z\":{\"a\":[[{\"b\":\"value7\"},{\"b\":\"value8\"}],[{\"b\":\"value9\"},{\"b\":\"value10\"}]]}}]],[[{\"z\":{\"a\":[[{\"b\":\"value11\"}],[{\"b\":\"value15\"}]]}},{\"z\":{\"a\":[[{\"b\":\"value14\"}]]}}],[{\"z\":{\"a\":[[{\"b\":\"value13\"}]]}}]],[[{\"z\":{\"a\":[[{\"b\":\"value12\"}],[{\"b\":\"value16\"},{\"b\":\"value17\"}]]}}]]]}}"));
        }

        [Test]
        public void RootAndInsert_ThreeDimensionTwoDimension()
        {
            JsonPatch jp = new("{\"x\":{\"y\":[[[{\"z\":{\"a\":[[\"value1\",\"value2\"],[\"value3\",\"value4\"]]}},{\"z\":{\"a\":[[\"value5\",\"value6\"]]}}],[{\"z\":{\"a\":[[\"value7\",\"value8\"],[\"value9\",\"value10\"]]}}]],[[{\"z\":{\"a\":[[\"value11\"]]}}]]]}}"u8.ToArray());

            Assert.That(jp.GetJson("$.x"u8).ToString(), Is.EqualTo("{\"y\":[[[{\"z\":{\"a\":[[\"value1\",\"value2\"],[\"value3\",\"value4\"]]}},{\"z\":{\"a\":[[\"value5\",\"value6\"]]}}],[{\"z\":{\"a\":[[\"value7\",\"value8\"],[\"value9\",\"value10\"]]}}]],[[{\"z\":{\"a\":[[\"value11\"]]}}]]]}"));
            Assert.That(jp.GetJson("$.x.y"u8).ToString(), Is.EqualTo("[[[{\"z\":{\"a\":[[\"value1\",\"value2\"],[\"value3\",\"value4\"]]}},{\"z\":{\"a\":[[\"value5\",\"value6\"]]}}],[{\"z\":{\"a\":[[\"value7\",\"value8\"],[\"value9\",\"value10\"]]}}]],[[{\"z\":{\"a\":[[\"value11\"]]}}]]]"));
            Assert.That(jp.GetJson("$.x.y[0]"u8).ToString(), Is.EqualTo("[[{\"z\":{\"a\":[[\"value1\",\"value2\"],[\"value3\",\"value4\"]]}},{\"z\":{\"a\":[[\"value5\",\"value6\"]]}}],[{\"z\":{\"a\":[[\"value7\",\"value8\"],[\"value9\",\"value10\"]]}}]]"));
            Assert.That(jp.GetJson("$.x.y[0][0]"u8).ToString(), Is.EqualTo("[{\"z\":{\"a\":[[\"value1\",\"value2\"],[\"value3\",\"value4\"]]}},{\"z\":{\"a\":[[\"value5\",\"value6\"]]}}]"));
            Assert.That(jp.GetJson("$.x.y[0][0][0]"u8).ToString(), Is.EqualTo("{\"z\":{\"a\":[[\"value1\",\"value2\"],[\"value3\",\"value4\"]]}}"));
            Assert.That(jp.GetJson("$.x.y[0][0][0].z"u8).ToString(), Is.EqualTo("{\"a\":[[\"value1\",\"value2\"],[\"value3\",\"value4\"]]}"));
            Assert.That(jp.GetJson("$.x.y[0][0][0].z.a"u8).ToString(), Is.EqualTo("[[\"value1\",\"value2\"],[\"value3\",\"value4\"]]"));
            Assert.That(jp.GetJson("$.x.y[0][0][0].z.a[0]"u8).ToString(), Is.EqualTo("[\"value1\",\"value2\"]"));
            Assert.That(jp.GetString("$.x.y[0][0][0].z.a[0][0]"u8), Is.EqualTo("value1"));
            Assert.That(jp.GetString("$.x.y[0][0][0].z.a[0][1]"u8), Is.EqualTo("value2"));
            Assert.That(jp.GetJson("$.x.y[0][0][0].z.a[1]"u8).ToString(), Is.EqualTo("[\"value3\",\"value4\"]"));
            Assert.That(jp.GetString("$.x.y[0][0][0].z.a[1][0]"u8), Is.EqualTo("value3"));
            Assert.That(jp.GetString("$.x.y[0][0][0].z.a[1][1]"u8), Is.EqualTo("value4"));
            Assert.That(jp.GetJson("$.x.y[0][0][1]"u8).ToString(), Is.EqualTo("{\"z\":{\"a\":[[\"value5\",\"value6\"]]}}"));
            Assert.That(jp.GetJson("$.x.y[0][0][1].z"u8).ToString(), Is.EqualTo("{\"a\":[[\"value5\",\"value6\"]]}"));
            Assert.That(jp.GetJson("$.x.y[0][0][1].z.a"u8).ToString(), Is.EqualTo("[[\"value5\",\"value6\"]]"));
            Assert.That(jp.GetJson("$.x.y[0][0][1].z.a[0]"u8).ToString(), Is.EqualTo("[\"value5\",\"value6\"]"));
            Assert.That(jp.GetString("$.x.y[0][0][1].z.a[0][0]"u8), Is.EqualTo("value5"));
            Assert.That(jp.GetString("$.x.y[0][0][1].z.a[0][1]"u8), Is.EqualTo("value6"));
            Assert.That(jp.GetJson("$.x.y[0][1]"u8).ToString(), Is.EqualTo("[{\"z\":{\"a\":[[\"value7\",\"value8\"],[\"value9\",\"value10\"]]}}]"));
            Assert.That(jp.GetJson("$.x.y[0][1][0]"u8).ToString(), Is.EqualTo("{\"z\":{\"a\":[[\"value7\",\"value8\"],[\"value9\",\"value10\"]]}}"));
            Assert.That(jp.GetJson("$.x.y[0][1][0].z"u8).ToString(), Is.EqualTo("{\"a\":[[\"value7\",\"value8\"],[\"value9\",\"value10\"]]}"));
            Assert.That(jp.GetJson("$.x.y[0][1][0].z.a"u8).ToString(), Is.EqualTo("[[\"value7\",\"value8\"],[\"value9\",\"value10\"]]"));
            Assert.That(jp.GetJson("$.x.y[0][1][0].z.a[0]"u8).ToString(), Is.EqualTo("[\"value7\",\"value8\"]"));
            Assert.That(jp.GetString("$.x.y[0][1][0].z.a[0][0]"u8), Is.EqualTo("value7"));
            Assert.That(jp.GetString("$.x.y[0][1][0].z.a[0][1]"u8), Is.EqualTo("value8"));
            Assert.That(jp.GetJson("$.x.y[0][1][0].z.a[1]"u8).ToString(), Is.EqualTo("[\"value9\",\"value10\"]"));
            Assert.That(jp.GetString("$.x.y[0][1][0].z.a[1][0]"u8), Is.EqualTo("value9"));
            Assert.That(jp.GetString("$.x.y[0][1][0].z.a[1][1]"u8), Is.EqualTo("value10"));
            Assert.That(jp.GetJson("$.x.y[1]"u8).ToString(), Is.EqualTo("[[{\"z\":{\"a\":[[\"value11\"]]}}]]"));
            Assert.That(jp.GetJson("$.x.y[1][0]"u8).ToString(), Is.EqualTo("[{\"z\":{\"a\":[[\"value11\"]]}}]"));
            Assert.That(jp.GetJson("$.x.y[1][0][0]"u8).ToString(), Is.EqualTo("{\"z\":{\"a\":[[\"value11\"]]}}"));
            Assert.That(jp.GetJson("$.x.y[1][0][0].z"u8).ToString(), Is.EqualTo("{\"a\":[[\"value11\"]]}"));
            Assert.That(jp.GetJson("$.x.y[1][0][0].z.a"u8).ToString(), Is.EqualTo("[[\"value11\"]]"));
            Assert.That(jp.GetJson("$.x.y[1][0][0].z.a[0]"u8).ToString(), Is.EqualTo("[\"value11\"]"));
            Assert.That(jp.GetString("$.x.y[1][0][0].z.a[0][0]"u8), Is.EqualTo("value11"));

            jp.Append("$.x.y"u8, "[[{\"z\":{\"a\":[[\"value12\"]]}}]]"u8);

            Assert.That(jp.GetJson("$.x.y"u8).ToString(), Is.EqualTo("[[[{\"z\":{\"a\":[[\"value1\",\"value2\"],[\"value3\",\"value4\"]]}},{\"z\":{\"a\":[[\"value5\",\"value6\"]]}}],[{\"z\":{\"a\":[[\"value7\",\"value8\"],[\"value9\",\"value10\"]]}}]],[[{\"z\":{\"a\":[[\"value11\"]]}}]],[[{\"z\":{\"a\":[[\"value12\"]]}}]]]"));

            jp.Append("$.x.y[1]"u8, "[{\"z\":{\"a\":[[\"value13\"]]}}]"u8);

            Assert.That(jp.GetJson("$.x.y"u8).ToString(), Is.EqualTo("[[[{\"z\":{\"a\":[[\"value1\",\"value2\"],[\"value3\",\"value4\"]]}},{\"z\":{\"a\":[[\"value5\",\"value6\"]]}}],[{\"z\":{\"a\":[[\"value7\",\"value8\"],[\"value9\",\"value10\"]]}}]],[[{\"z\":{\"a\":[[\"value11\"]]}}],[{\"z\":{\"a\":[[\"value13\"]]}}]],[[{\"z\":{\"a\":[[\"value12\"]]}}]]]"));

            jp.Append("$.x.y[1][0]"u8, "{\"z\":{\"a\":[[\"value14\"]]}}"u8);

            Assert.That(jp.GetJson("$.x.y"u8).ToString(), Is.EqualTo("[[[{\"z\":{\"a\":[[\"value1\",\"value2\"],[\"value3\",\"value4\"]]}},{\"z\":{\"a\":[[\"value5\",\"value6\"]]}}],[{\"z\":{\"a\":[[\"value7\",\"value8\"],[\"value9\",\"value10\"]]}}]],[[{\"z\":{\"a\":[[\"value11\"]]}},{\"z\":{\"a\":[[\"value14\"]]}}],[{\"z\":{\"a\":[[\"value13\"]]}}]],[[{\"z\":{\"a\":[[\"value12\"]]}}]]]"));

            jp.Append("$.x.y[1][0][0].z.a"u8, "[\"value15\"]"u8);

            Assert.That(jp.GetJson("$.x.y"u8).ToString(), Is.EqualTo("[[[{\"z\":{\"a\":[[\"value1\",\"value2\"],[\"value3\",\"value4\"]]}},{\"z\":{\"a\":[[\"value5\",\"value6\"]]}}],[{\"z\":{\"a\":[[\"value7\",\"value8\"],[\"value9\",\"value10\"]]}}]],[[{\"z\":{\"a\":[[\"value11\"],[\"value15\"]]}},{\"z\":{\"a\":[[\"value14\"]]}}],[{\"z\":{\"a\":[[\"value13\"]]}}]],[[{\"z\":{\"a\":[[\"value12\"]]}}]]]"));

            jp.Append("$.x.y[2][0][0].z.a"u8, "[\"value16\"]"u8);

            Assert.That(jp.GetJson("$.x.y"u8).ToString(), Is.EqualTo("[[[{\"z\":{\"a\":[[\"value1\",\"value2\"],[\"value3\",\"value4\"]]}},{\"z\":{\"a\":[[\"value5\",\"value6\"]]}}],[{\"z\":{\"a\":[[\"value7\",\"value8\"],[\"value9\",\"value10\"]]}}]],[[{\"z\":{\"a\":[[\"value11\"],[\"value15\"]]}},{\"z\":{\"a\":[[\"value14\"]]}}],[{\"z\":{\"a\":[[\"value13\"]]}}]],[[{\"z\":{\"a\":[[\"value12\"],[\"value16\"]]}}]]]"));

            jp.Append("$.x.y[2][0][0].z.a[1]"u8, "value17");

            Assert.That(jp.GetJson("$.x"u8).ToString(), Is.EqualTo("{\"y\":[[[{\"z\":{\"a\":[[\"value1\",\"value2\"],[\"value3\",\"value4\"]]}},{\"z\":{\"a\":[[\"value5\",\"value6\"]]}}],[{\"z\":{\"a\":[[\"value7\",\"value8\"],[\"value9\",\"value10\"]]}}]],[[{\"z\":{\"a\":[[\"value11\"]]}}]]]}"));
            Assert.That(jp.GetJson("$.x.y"u8).ToString(), Is.EqualTo("[[[{\"z\":{\"a\":[[\"value1\",\"value2\"],[\"value3\",\"value4\"]]}},{\"z\":{\"a\":[[\"value5\",\"value6\"]]}}],[{\"z\":{\"a\":[[\"value7\",\"value8\"],[\"value9\",\"value10\"]]}}]],[[{\"z\":{\"a\":[[\"value11\"],[\"value15\"]]}},{\"z\":{\"a\":[[\"value14\"]]}}],[{\"z\":{\"a\":[[\"value13\"]]}}]],[[{\"z\":{\"a\":[[\"value12\"],[\"value16\",\"value17\"]]}}]]]"));
            Assert.That(jp.GetJson("$.x.y[0]"u8).ToString(), Is.EqualTo("[[{\"z\":{\"a\":[[\"value1\",\"value2\"],[\"value3\",\"value4\"]]}},{\"z\":{\"a\":[[\"value5\",\"value6\"]]}}],[{\"z\":{\"a\":[[\"value7\",\"value8\"],[\"value9\",\"value10\"]]}}]]"));
            Assert.That(jp.GetJson("$.x.y[0][0]"u8).ToString(), Is.EqualTo("[{\"z\":{\"a\":[[\"value1\",\"value2\"],[\"value3\",\"value4\"]]}},{\"z\":{\"a\":[[\"value5\",\"value6\"]]}}]"));
            Assert.That(jp.GetJson("$.x.y[0][0][0]"u8).ToString(), Is.EqualTo("{\"z\":{\"a\":[[\"value1\",\"value2\"],[\"value3\",\"value4\"]]}}"));
            Assert.That(jp.GetJson("$.x.y[0][0][0].z"u8).ToString(), Is.EqualTo("{\"a\":[[\"value1\",\"value2\"],[\"value3\",\"value4\"]]}"));
            Assert.That(jp.GetJson("$.x.y[0][0][0].z.a"u8).ToString(), Is.EqualTo("[[\"value1\",\"value2\"],[\"value3\",\"value4\"]]"));
            Assert.That(jp.GetJson("$.x.y[0][0][0].z.a[0]"u8).ToString(), Is.EqualTo("[\"value1\",\"value2\"]"));
            Assert.That(jp.GetString("$.x.y[0][0][0].z.a[0][0]"u8), Is.EqualTo("value1"));
            Assert.That(jp.GetString("$.x.y[0][0][0].z.a[0][1]"u8), Is.EqualTo("value2"));
            Assert.That(jp.GetJson("$.x.y[0][0][0].z.a[1]"u8).ToString(), Is.EqualTo("[\"value3\",\"value4\"]"));
            Assert.That(jp.GetString("$.x.y[0][0][0].z.a[1][0]"u8), Is.EqualTo("value3"));
            Assert.That(jp.GetString("$.x.y[0][0][0].z.a[1][1]"u8), Is.EqualTo("value4"));
            Assert.That(jp.GetJson("$.x.y[0][0][1]"u8).ToString(), Is.EqualTo("{\"z\":{\"a\":[[\"value5\",\"value6\"]]}}"));
            Assert.That(jp.GetJson("$.x.y[0][0][1].z"u8).ToString(), Is.EqualTo("{\"a\":[[\"value5\",\"value6\"]]}"));
            Assert.That(jp.GetJson("$.x.y[0][0][1].z.a"u8).ToString(), Is.EqualTo("[[\"value5\",\"value6\"]]"));
            Assert.That(jp.GetJson("$.x.y[0][0][1].z.a[0]"u8).ToString(), Is.EqualTo("[\"value5\",\"value6\"]"));
            Assert.That(jp.GetString("$.x.y[0][0][1].z.a[0][0]"u8), Is.EqualTo("value5"));
            Assert.That(jp.GetString("$.x.y[0][0][1].z.a[0][1]"u8), Is.EqualTo("value6"));
            Assert.That(jp.GetJson("$.x.y[0][1]"u8).ToString(), Is.EqualTo("[{\"z\":{\"a\":[[\"value7\",\"value8\"],[\"value9\",\"value10\"]]}}]"));
            Assert.That(jp.GetJson("$.x.y[0][1][0]"u8).ToString(), Is.EqualTo("{\"z\":{\"a\":[[\"value7\",\"value8\"],[\"value9\",\"value10\"]]}}"));
            Assert.That(jp.GetJson("$.x.y[0][1][0].z"u8).ToString(), Is.EqualTo("{\"a\":[[\"value7\",\"value8\"],[\"value9\",\"value10\"]]}"));
            Assert.That(jp.GetJson("$.x.y[0][1][0].z.a"u8).ToString(), Is.EqualTo("[[\"value7\",\"value8\"],[\"value9\",\"value10\"]]"));
            Assert.That(jp.GetJson("$.x.y[0][1][0].z.a[0]"u8).ToString(), Is.EqualTo("[\"value7\",\"value8\"]"));
            Assert.That(jp.GetString("$.x.y[0][1][0].z.a[0][0]"u8), Is.EqualTo("value7"));
            Assert.That(jp.GetString("$.x.y[0][1][0].z.a[0][1]"u8), Is.EqualTo("value8"));
            Assert.That(jp.GetJson("$.x.y[0][1][0].z.a[1]"u8).ToString(), Is.EqualTo("[\"value9\",\"value10\"]"));
            Assert.That(jp.GetString("$.x.y[0][1][0].z.a[1][0]"u8), Is.EqualTo("value9"));
            Assert.That(jp.GetString("$.x.y[0][1][0].z.a[1][1]"u8), Is.EqualTo("value10"));
            Assert.That(jp.GetJson("$.x.y[1]"u8).ToString(), Is.EqualTo("[[{\"z\":{\"a\":[[\"value11\"],[\"value15\"]]}},{\"z\":{\"a\":[[\"value14\"]]}}],[{\"z\":{\"a\":[[\"value13\"]]}}]]"));
            Assert.That(jp.GetJson("$.x.y[1][0]"u8).ToString(), Is.EqualTo("[{\"z\":{\"a\":[[\"value11\"],[\"value15\"]]}},{\"z\":{\"a\":[[\"value14\"]]}}]"));
            Assert.That(jp.GetJson("$.x.y[1][0][0]"u8).ToString(), Is.EqualTo("{\"z\":{\"a\":[[\"value11\"],[\"value15\"]]}}"));
            Assert.That(jp.GetJson("$.x.y[1][0][0].z"u8).ToString(), Is.EqualTo("{\"a\":[[\"value11\"],[\"value15\"]]}"));
            Assert.That(jp.GetJson("$.x.y[1][0][0].z.a"u8).ToString(), Is.EqualTo("[[\"value11\"],[\"value15\"]]"));
            Assert.That(jp.GetJson("$.x.y[1][0][0].z.a[0]"u8).ToString(), Is.EqualTo("[\"value11\"]"));
            Assert.That(jp.GetString("$.x.y[1][0][0].z.a[0][0]"u8), Is.EqualTo("value11"));
            Assert.That(jp.GetJson("$.x.y[1][0][0].z.a[1]"u8).ToString(), Is.EqualTo("[\"value15\"]"));
            Assert.That(jp.GetString("$.x.y[1][0][0].z.a[1][0]"u8), Is.EqualTo("value15"));
            Assert.That(jp.GetJson("$.x.y[1][0][1]"u8).ToString(), Is.EqualTo("{\"z\":{\"a\":[[\"value14\"]]}}"));
            Assert.That(jp.GetJson("$.x.y[1][0][1].z"u8).ToString(), Is.EqualTo("{\"a\":[[\"value14\"]]}"));
            Assert.That(jp.GetJson("$.x.y[1][0][1].z.a"u8).ToString(), Is.EqualTo("[[\"value14\"]]"));
            Assert.That(jp.GetJson("$.x.y[1][0][1].z.a[0]"u8).ToString(), Is.EqualTo("[\"value14\"]"));
            Assert.That(jp.GetString("$.x.y[1][0][1].z.a[0][0]"u8), Is.EqualTo("value14"));
            Assert.That(jp.GetJson("$.x.y[1][1]"u8).ToString(), Is.EqualTo("[{\"z\":{\"a\":[[\"value13\"]]}}]"));
            Assert.That(jp.GetJson("$.x.y[1][1][0]"u8).ToString(), Is.EqualTo("{\"z\":{\"a\":[[\"value13\"]]}}"));
            Assert.That(jp.GetJson("$.x.y[1][1][0].z"u8).ToString(), Is.EqualTo("{\"a\":[[\"value13\"]]}"));
            Assert.That(jp.GetJson("$.x.y[1][1][0].z.a"u8).ToString(), Is.EqualTo("[[\"value13\"]]"));
            Assert.That(jp.GetJson("$.x.y[1][1][0].z.a[0]"u8).ToString(), Is.EqualTo("[\"value13\"]"));
            Assert.That(jp.GetString("$.x.y[1][1][0].z.a[0][0]"u8), Is.EqualTo("value13"));
            Assert.That(jp.GetJson("$.x.y[2]"u8).ToString(), Is.EqualTo("[[{\"z\":{\"a\":[[\"value12\"],[\"value16\",\"value17\"]]}}]]"));
            Assert.That(jp.GetJson("$.x.y[2][0]"u8).ToString(), Is.EqualTo("[{\"z\":{\"a\":[[\"value12\"],[\"value16\",\"value17\"]]}}]"));
            Assert.That(jp.GetJson("$.x.y[2][0][0]"u8).ToString(), Is.EqualTo("{\"z\":{\"a\":[[\"value12\"],[\"value16\",\"value17\"]]}}"));
            Assert.That(jp.GetJson("$.x.y[2][0][0].z"u8).ToString(), Is.EqualTo("{\"a\":[[\"value12\"],[\"value16\",\"value17\"]]}"));
            Assert.That(jp.GetJson("$.x.y[2][0][0].z.a"u8).ToString(), Is.EqualTo("[[\"value12\"],[\"value16\",\"value17\"]]"));
            Assert.That(jp.GetJson("$.x.y[2][0][0].z.a[0]"u8).ToString(), Is.EqualTo("[\"value12\"]"));
            Assert.That(jp.GetString("$.x.y[2][0][0].z.a[0][0]"u8), Is.EqualTo("value12"));
            Assert.That(jp.GetJson("$.x.y[2][0][0].z.a[1]"u8).ToString(), Is.EqualTo("[\"value16\",\"value17\"]"));
            Assert.That(jp.GetString("$.x.y[2][0][0].z.a[1][0]"u8), Is.EqualTo("value16"));
            Assert.That(jp.GetString("$.x.y[2][0][0].z.a[1][1]"u8), Is.EqualTo("value17"));
        }

        [Test]
        public void Insert_ThreeDimensionTwoDimension_WithProperty()
        {
            JsonPatch jp = new();

            jp.Append("$.x.y[0][0][0].z.a[0]"u8, "{\"b\":\"value1\"}"u8);

            Assert.That(jp.GetJson("$.x"u8).ToString(), Is.EqualTo("{\"y\":[[[{\"z\":{\"a\":[[{\"b\":\"value1\"}]]}}]]]}"));

            jp.Append("$.x.y[0][0][0].z.a[0]"u8, "{\"b\":\"value2\"}"u8);

            Assert.That(jp.GetJson("$.x"u8).ToString(), Is.EqualTo("{\"y\":[[[{\"z\":{\"a\":[[{\"b\":\"value1\"},{\"b\":\"value2\"}]]}}]]]}"));

            jp.Append("$.x.y[0][0][0].z.a[1]"u8, "{\"b\":\"value3\"}"u8);

            Assert.That(jp.GetJson("$.x"u8).ToString(), Is.EqualTo("{\"y\":[[[{\"z\":{\"a\":[[{\"b\":\"value1\"},{\"b\":\"value2\"}],[{\"b\":\"value3\"}]]}}]]]}"));

            jp.Append("$.x.y[0][0][0].z.a[1]"u8, "{\"b\":\"value4\"}"u8);

            Assert.That(jp.GetJson("$.x"u8).ToString(), Is.EqualTo("{\"y\":[[[{\"z\":{\"a\":[[{\"b\":\"value1\"},{\"b\":\"value2\"}],[{\"b\":\"value3\"},{\"b\":\"value4\"}]]}}]]]}"));

            jp.Append("$.x.y[0][0]"u8, "{\"z\":{\"a\":[[{\"b\":\"value5\"}]]}}"u8);

            Assert.That(jp.GetJson("$.x"u8).ToString(), Is.EqualTo("{\"y\":[[[{\"z\":{\"a\":[[{\"b\":\"value1\"},{\"b\":\"value2\"}],[{\"b\":\"value3\"},{\"b\":\"value4\"}]]}},{\"z\":{\"a\":[[{\"b\":\"value5\"}]]}}]]]}"));

            jp.Append("$.x.y[0][0][1].z.a[0]"u8, "{\"b\":\"value6\"}"u8);

            Assert.That(jp.GetJson("$.x"u8).ToString(), Is.EqualTo("{\"y\":[[[{\"z\":{\"a\":[[{\"b\":\"value1\"},{\"b\":\"value2\"}],[{\"b\":\"value3\"},{\"b\":\"value4\"}]]}},{\"z\":{\"a\":[[{\"b\":\"value5\"},{\"b\":\"value6\"}]]}}]]]}"));

            jp.Append("$.x.y[0][1]"u8, "{\"z\":{\"a\":[[{\"b\":\"value7\"}]]}}"u8);

            Assert.That(jp.GetJson("$.x"u8).ToString(), Is.EqualTo("{\"y\":[[[{\"z\":{\"a\":[[{\"b\":\"value1\"},{\"b\":\"value2\"}],[{\"b\":\"value3\"},{\"b\":\"value4\"}]]}},{\"z\":{\"a\":[[{\"b\":\"value5\"},{\"b\":\"value6\"}]]}}],[{\"z\":{\"a\":[[{\"b\":\"value7\"}]]}}]]]}"));

            jp.Append("$.x.y[0][1][0].z.a[0]"u8, "{\"b\":\"value8\"}"u8);

            Assert.That(jp.GetJson("$.x"u8).ToString(), Is.EqualTo("{\"y\":[[[{\"z\":{\"a\":[[{\"b\":\"value1\"},{\"b\":\"value2\"}],[{\"b\":\"value3\"},{\"b\":\"value4\"}]]}},{\"z\":{\"a\":[[{\"b\":\"value5\"},{\"b\":\"value6\"}]]}}],[{\"z\":{\"a\":[[{\"b\":\"value7\"},{\"b\":\"value8\"}]]}}]]]}"));

            jp.Append("$.x.y[0][1][0].z.a[1]"u8, "{\"b\":\"value9\"}"u8);

            Assert.That(jp.GetJson("$.x"u8).ToString(), Is.EqualTo("{\"y\":[[[{\"z\":{\"a\":[[{\"b\":\"value1\"},{\"b\":\"value2\"}],[{\"b\":\"value3\"},{\"b\":\"value4\"}]]}},{\"z\":{\"a\":[[{\"b\":\"value5\"},{\"b\":\"value6\"}]]}}],[{\"z\":{\"a\":[[{\"b\":\"value7\"},{\"b\":\"value8\"}],[{\"b\":\"value9\"}]]}}]]]}"));

            jp.Append("$.x.y[0][1][0].z.a[1]"u8, "{\"b\":\"value10\"}"u8);

            Assert.That(jp.GetJson("$.x"u8).ToString(), Is.EqualTo("{\"y\":[[[{\"z\":{\"a\":[[{\"b\":\"value1\"},{\"b\":\"value2\"}],[{\"b\":\"value3\"},{\"b\":\"value4\"}]]}},{\"z\":{\"a\":[[{\"b\":\"value5\"},{\"b\":\"value6\"}]]}}],[{\"z\":{\"a\":[[{\"b\":\"value7\"},{\"b\":\"value8\"}],[{\"b\":\"value9\"},{\"b\":\"value10\"}]]}}]]]}"));

            jp.Append("$.x.y[1]"u8, "[{\"z\":{\"a\":[[{\"b\":\"value11\"}]]}}]"u8);

            Assert.That(jp.GetJson("$.x"u8).ToString(), Is.EqualTo("{\"y\":[[[{\"z\":{\"a\":[[{\"b\":\"value1\"},{\"b\":\"value2\"}],[{\"b\":\"value3\"},{\"b\":\"value4\"}]]}},{\"z\":{\"a\":[[{\"b\":\"value5\"},{\"b\":\"value6\"}]]}}],[{\"z\":{\"a\":[[{\"b\":\"value7\"},{\"b\":\"value8\"}],[{\"b\":\"value9\"},{\"b\":\"value10\"}]]}}]],[[{\"z\":{\"a\":[[{\"b\":\"value11\"}]]}}]]]}"));
            Assert.That(jp.GetJson("$.x.y"u8).ToString(), Is.EqualTo("[[[{\"z\":{\"a\":[[{\"b\":\"value1\"},{\"b\":\"value2\"}],[{\"b\":\"value3\"},{\"b\":\"value4\"}]]}},{\"z\":{\"a\":[[{\"b\":\"value5\"},{\"b\":\"value6\"}]]}}],[{\"z\":{\"a\":[[{\"b\":\"value7\"},{\"b\":\"value8\"}],[{\"b\":\"value9\"},{\"b\":\"value10\"}]]}}]],[[{\"z\":{\"a\":[[{\"b\":\"value11\"}]]}}]]]"));
            Assert.That(jp.GetJson("$.x.y[0]"u8).ToString(), Is.EqualTo("[[{\"z\":{\"a\":[[{\"b\":\"value1\"},{\"b\":\"value2\"}],[{\"b\":\"value3\"},{\"b\":\"value4\"}]]}},{\"z\":{\"a\":[[{\"b\":\"value5\"},{\"b\":\"value6\"}]]}}],[{\"z\":{\"a\":[[{\"b\":\"value7\"},{\"b\":\"value8\"}],[{\"b\":\"value9\"},{\"b\":\"value10\"}]]}}]]"));
            Assert.That(jp.GetJson("$.x.y[0][0]"u8).ToString(), Is.EqualTo("[{\"z\":{\"a\":[[{\"b\":\"value1\"},{\"b\":\"value2\"}],[{\"b\":\"value3\"},{\"b\":\"value4\"}]]}},{\"z\":{\"a\":[[{\"b\":\"value5\"},{\"b\":\"value6\"}]]}}]"));
            Assert.That(jp.GetJson("$.x.y[0][0][0]"u8).ToString(), Is.EqualTo("{\"z\":{\"a\":[[{\"b\":\"value1\"},{\"b\":\"value2\"}],[{\"b\":\"value3\"},{\"b\":\"value4\"}]]}}"));
            Assert.That(jp.GetJson("$.x.y[0][0][0].z"u8).ToString(), Is.EqualTo("{\"a\":[[{\"b\":\"value1\"},{\"b\":\"value2\"}],[{\"b\":\"value3\"},{\"b\":\"value4\"}]]}"));
            Assert.That(jp.GetJson("$.x.y[0][0][0].z.a"u8).ToString(), Is.EqualTo("[[{\"b\":\"value1\"},{\"b\":\"value2\"}],[{\"b\":\"value3\"},{\"b\":\"value4\"}]]"));
            Assert.That(jp.GetJson("$.x.y[0][0][0].z.a[0]"u8).ToString(), Is.EqualTo("[{\"b\":\"value1\"},{\"b\":\"value2\"}]"));
            Assert.That(jp.GetJson("$.x.y[0][0][0].z.a[0][0]"u8).ToString(), Is.EqualTo("{\"b\":\"value1\"}"));
            Assert.That(jp.GetString("$.x.y[0][0][0].z.a[0][0].b"u8), Is.EqualTo("value1"));
            Assert.That(jp.GetJson("$.x.y[0][0][0].z.a[0][1]"u8).ToString(), Is.EqualTo("{\"b\":\"value2\"}"));
            Assert.That(jp.GetString("$.x.y[0][0][0].z.a[0][1].b"u8), Is.EqualTo("value2"));
            Assert.That(jp.GetJson("$.x.y[0][0][0].z.a[1]"u8).ToString(), Is.EqualTo("[{\"b\":\"value3\"},{\"b\":\"value4\"}]"));
            Assert.That(jp.GetJson("$.x.y[0][0][0].z.a[1][0]"u8).ToString(), Is.EqualTo("{\"b\":\"value3\"}"));
            Assert.That(jp.GetString("$.x.y[0][0][0].z.a[1][0].b"u8), Is.EqualTo("value3"));
            Assert.That(jp.GetJson("$.x.y[0][0][0].z.a[1][1]"u8).ToString(), Is.EqualTo("{\"b\":\"value4\"}"));
            Assert.That(jp.GetString("$.x.y[0][0][0].z.a[1][1].b"u8), Is.EqualTo("value4"));
            Assert.That(jp.GetJson("$.x.y[0][0][1]"u8).ToString(), Is.EqualTo("{\"z\":{\"a\":[[{\"b\":\"value5\"},{\"b\":\"value6\"}]]}}"));
            Assert.That(jp.GetJson("$.x.y[0][0][1].z"u8).ToString(), Is.EqualTo("{\"a\":[[{\"b\":\"value5\"},{\"b\":\"value6\"}]]}"));
            Assert.That(jp.GetJson("$.x.y[0][0][1].z.a"u8).ToString(), Is.EqualTo("[[{\"b\":\"value5\"},{\"b\":\"value6\"}]]"));
            Assert.That(jp.GetJson("$.x.y[0][0][1].z.a[0]"u8).ToString(), Is.EqualTo("[{\"b\":\"value5\"},{\"b\":\"value6\"}]"));
            Assert.That(jp.GetJson("$.x.y[0][0][1].z.a[0][0]"u8).ToString(), Is.EqualTo("{\"b\":\"value5\"}"));
            Assert.That(jp.GetString("$.x.y[0][0][1].z.a[0][0].b"u8), Is.EqualTo("value5"));
            Assert.That(jp.GetJson("$.x.y[0][0][1].z.a[0][1]"u8).ToString(), Is.EqualTo("{\"b\":\"value6\"}"));
            Assert.That(jp.GetString("$.x.y[0][0][1].z.a[0][1].b"u8), Is.EqualTo("value6"));
            Assert.That(jp.GetJson("$.x.y[0][1][0]"u8).ToString(), Is.EqualTo("{\"z\":{\"a\":[[{\"b\":\"value7\"},{\"b\":\"value8\"}],[{\"b\":\"value9\"},{\"b\":\"value10\"}]]}}"));
            Assert.That(jp.GetJson("$.x.y[0][1][0].z"u8).ToString(), Is.EqualTo("{\"a\":[[{\"b\":\"value7\"},{\"b\":\"value8\"}],[{\"b\":\"value9\"},{\"b\":\"value10\"}]]}"));
            Assert.That(jp.GetJson("$.x.y[0][1][0].z.a"u8).ToString(), Is.EqualTo("[[{\"b\":\"value7\"},{\"b\":\"value8\"}],[{\"b\":\"value9\"},{\"b\":\"value10\"}]]"));
            Assert.That(jp.GetJson("$.x.y[0][1][0].z.a[0]"u8).ToString(), Is.EqualTo("[{\"b\":\"value7\"},{\"b\":\"value8\"}]"));
            Assert.That(jp.GetJson("$.x.y[0][1][0].z.a[0][0]"u8).ToString(), Is.EqualTo("{\"b\":\"value7\"}"));
            Assert.That(jp.GetString("$.x.y[0][1][0].z.a[0][0].b"u8), Is.EqualTo("value7"));
            Assert.That(jp.GetJson("$.x.y[0][1][0].z.a[0][1]"u8).ToString(), Is.EqualTo("{\"b\":\"value8\"}"));
            Assert.That(jp.GetString("$.x.y[0][1][0].z.a[0][1].b"u8), Is.EqualTo("value8"));
            Assert.That(jp.GetJson("$.x.y[0][1][0].z.a[1]"u8).ToString(), Is.EqualTo("[{\"b\":\"value9\"},{\"b\":\"value10\"}]"));
            Assert.That(jp.GetJson("$.x.y[0][1][0].z.a[1][0]"u8).ToString(), Is.EqualTo("{\"b\":\"value9\"}"));
            Assert.That(jp.GetString("$.x.y[0][1][0].z.a[1][0].b"u8), Is.EqualTo("value9"));
            Assert.That(jp.GetJson("$.x.y[0][1][0].z.a[1][1]"u8).ToString(), Is.EqualTo("{\"b\":\"value10\"}"));
            Assert.That(jp.GetString("$.x.y[0][1][0].z.a[1][1].b"u8), Is.EqualTo("value10"));
            Assert.That(jp.GetJson("$.x.y[1]"u8).ToString(), Is.EqualTo("[[{\"z\":{\"a\":[[{\"b\":\"value11\"}]]}}]]"));
            Assert.That(jp.GetJson("$.x.y[1][0]"u8).ToString(), Is.EqualTo("[{\"z\":{\"a\":[[{\"b\":\"value11\"}]]}}]"));
            Assert.That(jp.GetJson("$.x.y[1][0][0]"u8).ToString(), Is.EqualTo("{\"z\":{\"a\":[[{\"b\":\"value11\"}]]}}"));
            Assert.That(jp.GetJson("$.x.y[1][0][0].z"u8).ToString(), Is.EqualTo("{\"a\":[[{\"b\":\"value11\"}]]}"));
            Assert.That(jp.GetJson("$.x.y[1][0][0].z.a"u8).ToString(), Is.EqualTo("[[{\"b\":\"value11\"}]]"));
            Assert.That(jp.GetJson("$.x.y[1][0][0].z.a[0]"u8).ToString(), Is.EqualTo("[{\"b\":\"value11\"}]"));
            Assert.That(jp.GetJson("$.x.y[1][0][0].z.a[0][0]"u8).ToString(), Is.EqualTo("{\"b\":\"value11\"}"));
            Assert.That(jp.GetString("$.x.y[1][0][0].z.a[0][0].b"u8), Is.EqualTo("value11"));

            Assert.That(jp.ToString("J"), Is.EqualTo("{\"x\":{\"y\":[[[{\"z\":{\"a\":[[{\"b\":\"value1\"},{\"b\":\"value2\"}],[{\"b\":\"value3\"},{\"b\":\"value4\"}]]}},{\"z\":{\"a\":[[{\"b\":\"value5\"},{\"b\":\"value6\"}]]}}],[{\"z\":{\"a\":[[{\"b\":\"value7\"},{\"b\":\"value8\"}],[{\"b\":\"value9\"},{\"b\":\"value10\"}]]}}]],[[{\"z\":{\"a\":[[{\"b\":\"value11\"}]]}}]]]}}"));
        }

        [Test]
        public void Insert_ThreeDimensionTwoDimension()
        {
            JsonPatch jp = new();

            jp.Append("$.x.y[0][0][0].z.a[0]"u8, "value1");

            Assert.That(jp.GetJson("$.x"u8).ToString(), Is.EqualTo("{\"y\":[[[{\"z\":{\"a\":[[\"value1\"]]}}]]]}"));

            jp.Append("$.x.y[0][0][0].z.a[0]"u8, "value2");

            Assert.That(jp.GetJson("$.x"u8).ToString(), Is.EqualTo("{\"y\":[[[{\"z\":{\"a\":[[\"value1\",\"value2\"]]}}]]]}"));

            jp.Append("$.x.y[0][0][0].z.a[1]"u8, "value3");

            Assert.That(jp.GetJson("$.x"u8).ToString(), Is.EqualTo("{\"y\":[[[{\"z\":{\"a\":[[\"value1\",\"value2\"],[\"value3\"]]}}]]]}"));

            jp.Append("$.x.y[0][0][0].z.a[1]"u8, "value4");

            Assert.That(jp.GetJson("$.x"u8).ToString(), Is.EqualTo("{\"y\":[[[{\"z\":{\"a\":[[\"value1\",\"value2\"],[\"value3\",\"value4\"]]}}]]]}"));

            jp.Append("$.x.y[0][0]"u8, "{\"z\":{\"a\":[[\"value5\"]]}}"u8);

            Assert.That(jp.GetJson("$.x"u8).ToString(), Is.EqualTo("{\"y\":[[[{\"z\":{\"a\":[[\"value1\",\"value2\"],[\"value3\",\"value4\"]]}},{\"z\":{\"a\":[[\"value5\"]]}}]]]}"));

            jp.Append("$.x.y[0][0][1].z.a[0]"u8, "value6");

            Assert.That(jp.GetJson("$.x"u8).ToString(), Is.EqualTo("{\"y\":[[[{\"z\":{\"a\":[[\"value1\",\"value2\"],[\"value3\",\"value4\"]]}},{\"z\":{\"a\":[[\"value5\",\"value6\"]]}}]]]}"));

            jp.Append("$.x.y[0][1]"u8, "{\"z\":{\"a\":[[\"value7\"]]}}"u8);

            Assert.That(jp.GetJson("$.x"u8).ToString(), Is.EqualTo("{\"y\":[[[{\"z\":{\"a\":[[\"value1\",\"value2\"],[\"value3\",\"value4\"]]}},{\"z\":{\"a\":[[\"value5\",\"value6\"]]}}],[{\"z\":{\"a\":[[\"value7\"]]}}]]]}"));

            jp.Append("$.x.y[0][1][0].z.a[0]"u8, "value8");

            Assert.That(jp.GetJson("$.x"u8).ToString(), Is.EqualTo("{\"y\":[[[{\"z\":{\"a\":[[\"value1\",\"value2\"],[\"value3\",\"value4\"]]}},{\"z\":{\"a\":[[\"value5\",\"value6\"]]}}],[{\"z\":{\"a\":[[\"value7\",\"value8\"]]}}]]]}"));

            jp.Append("$.x.y[0][1][0].z.a[1]"u8, "value9");

            Assert.That(jp.GetJson("$.x"u8).ToString(), Is.EqualTo("{\"y\":[[[{\"z\":{\"a\":[[\"value1\",\"value2\"],[\"value3\",\"value4\"]]}},{\"z\":{\"a\":[[\"value5\",\"value6\"]]}}],[{\"z\":{\"a\":[[\"value7\",\"value8\"],[\"value9\"]]}}]]]}"));

            jp.Append("$.x.y[0][1][0].z.a[1]"u8, "value10");

            Assert.That(jp.GetJson("$.x"u8).ToString(), Is.EqualTo("{\"y\":[[[{\"z\":{\"a\":[[\"value1\",\"value2\"],[\"value3\",\"value4\"]]}},{\"z\":{\"a\":[[\"value5\",\"value6\"]]}}],[{\"z\":{\"a\":[[\"value7\",\"value8\"],[\"value9\",\"value10\"]]}}]]]}"));

            jp.Append("$.x.y[1]"u8, "[{\"z\":{\"a\":[[\"value11\"]]}}]"u8);

            Assert.That(jp.GetJson("$.x"u8).ToString(), Is.EqualTo("{\"y\":[[[{\"z\":{\"a\":[[\"value1\",\"value2\"],[\"value3\",\"value4\"]]}},{\"z\":{\"a\":[[\"value5\",\"value6\"]]}}],[{\"z\":{\"a\":[[\"value7\",\"value8\"],[\"value9\",\"value10\"]]}}]],[[{\"z\":{\"a\":[[\"value11\"]]}}]]]}"));
            Assert.That(jp.GetJson("$.x.y"u8).ToString(), Is.EqualTo("[[[{\"z\":{\"a\":[[\"value1\",\"value2\"],[\"value3\",\"value4\"]]}},{\"z\":{\"a\":[[\"value5\",\"value6\"]]}}],[{\"z\":{\"a\":[[\"value7\",\"value8\"],[\"value9\",\"value10\"]]}}]],[[{\"z\":{\"a\":[[\"value11\"]]}}]]]"));
            Assert.That(jp.GetJson("$.x.y[0]"u8).ToString(), Is.EqualTo("[[{\"z\":{\"a\":[[\"value1\",\"value2\"],[\"value3\",\"value4\"]]}},{\"z\":{\"a\":[[\"value5\",\"value6\"]]}}],[{\"z\":{\"a\":[[\"value7\",\"value8\"],[\"value9\",\"value10\"]]}}]]"));
            Assert.That(jp.GetJson("$.x.y[0][0]"u8).ToString(), Is.EqualTo("[{\"z\":{\"a\":[[\"value1\",\"value2\"],[\"value3\",\"value4\"]]}},{\"z\":{\"a\":[[\"value5\",\"value6\"]]}}]"));
            Assert.That(jp.GetJson("$.x.y[0][0][0]"u8).ToString(), Is.EqualTo("{\"z\":{\"a\":[[\"value1\",\"value2\"],[\"value3\",\"value4\"]]}}"));
            Assert.That(jp.GetJson("$.x.y[0][0][0].z"u8).ToString(), Is.EqualTo("{\"a\":[[\"value1\",\"value2\"],[\"value3\",\"value4\"]]}"));
            Assert.That(jp.GetJson("$.x.y[0][0][0].z.a"u8).ToString(), Is.EqualTo("[[\"value1\",\"value2\"],[\"value3\",\"value4\"]]"));
            Assert.That(jp.GetJson("$.x.y[0][0][0].z.a[0]"u8).ToString(), Is.EqualTo("[\"value1\",\"value2\"]"));
            Assert.That(jp.GetString("$.x.y[0][0][0].z.a[0][0]"u8), Is.EqualTo("value1"));
            Assert.That(jp.GetString("$.x.y[0][0][0].z.a[0][1]"u8), Is.EqualTo("value2"));
            Assert.That(jp.GetJson("$.x.y[0][0][0].z.a[1]"u8).ToString(), Is.EqualTo("[\"value3\",\"value4\"]"));
            Assert.That(jp.GetString("$.x.y[0][0][0].z.a[1][0]"u8), Is.EqualTo("value3"));
            Assert.That(jp.GetString("$.x.y[0][0][0].z.a[1][1]"u8), Is.EqualTo("value4"));
            Assert.That(jp.GetJson("$.x.y[0][0][1]"u8).ToString(), Is.EqualTo("{\"z\":{\"a\":[[\"value5\",\"value6\"]]}}"));
            Assert.That(jp.GetJson("$.x.y[0][0][1].z"u8).ToString(), Is.EqualTo("{\"a\":[[\"value5\",\"value6\"]]}"));
            Assert.That(jp.GetJson("$.x.y[0][0][1].z.a"u8).ToString(), Is.EqualTo("[[\"value5\",\"value6\"]]"));
            Assert.That(jp.GetJson("$.x.y[0][0][1].z.a[0]"u8).ToString(), Is.EqualTo("[\"value5\",\"value6\"]"));
            Assert.That(jp.GetString("$.x.y[0][0][1].z.a[0][0]"u8), Is.EqualTo("value5"));
            Assert.That(jp.GetString("$.x.y[0][0][1].z.a[0][1]"u8), Is.EqualTo("value6"));
            Assert.That(jp.GetJson("$.x.y[0][1]"u8).ToString(), Is.EqualTo("[{\"z\":{\"a\":[[\"value7\",\"value8\"],[\"value9\",\"value10\"]]}}]"));
            Assert.That(jp.GetJson("$.x.y[0][1][0]"u8).ToString(), Is.EqualTo("{\"z\":{\"a\":[[\"value7\",\"value8\"],[\"value9\",\"value10\"]]}}"));
            Assert.That(jp.GetJson("$.x.y[0][1][0].z"u8).ToString(), Is.EqualTo("{\"a\":[[\"value7\",\"value8\"],[\"value9\",\"value10\"]]}"));
            Assert.That(jp.GetJson("$.x.y[0][1][0].z.a"u8).ToString(), Is.EqualTo("[[\"value7\",\"value8\"],[\"value9\",\"value10\"]]"));
            Assert.That(jp.GetJson("$.x.y[0][1][0].z.a[0]"u8).ToString(), Is.EqualTo("[\"value7\",\"value8\"]"));
            Assert.That(jp.GetString("$.x.y[0][1][0].z.a[0][0]"u8), Is.EqualTo("value7"));
            Assert.That(jp.GetString("$.x.y[0][1][0].z.a[0][1]"u8), Is.EqualTo("value8"));
            Assert.That(jp.GetJson("$.x.y[0][1][0].z.a[1]"u8).ToString(), Is.EqualTo("[\"value9\",\"value10\"]"));
            Assert.That(jp.GetString("$.x.y[0][1][0].z.a[1][0]"u8), Is.EqualTo("value9"));
            Assert.That(jp.GetString("$.x.y[0][1][0].z.a[1][1]"u8), Is.EqualTo("value10"));
            Assert.That(jp.GetJson("$.x.y[1]"u8).ToString(), Is.EqualTo("[[{\"z\":{\"a\":[[\"value11\"]]}}]]"));
            Assert.That(jp.GetJson("$.x.y[1][0]"u8).ToString(), Is.EqualTo("[{\"z\":{\"a\":[[\"value11\"]]}}]"));
            Assert.That(jp.GetJson("$.x.y[1][0][0]"u8).ToString(), Is.EqualTo("{\"z\":{\"a\":[[\"value11\"]]}}"));
            Assert.That(jp.GetJson("$.x.y[1][0][0].z"u8).ToString(), Is.EqualTo("{\"a\":[[\"value11\"]]}"));
            Assert.That(jp.GetJson("$.x.y[1][0][0].z.a"u8).ToString(), Is.EqualTo("[[\"value11\"]]"));
            Assert.That(jp.GetJson("$.x.y[1][0][0].z.a[0]"u8).ToString(), Is.EqualTo("[\"value11\"]"));
            Assert.That(jp.GetString("$.x.y[1][0][0].z.a[0][0]"u8), Is.EqualTo("value11"));

            Assert.That(jp.ToString("J"), Is.EqualTo("{\"x\":{\"y\":[[[{\"z\":{\"a\":[[\"value1\",\"value2\"],[\"value3\",\"value4\"]]}},{\"z\":{\"a\":[[\"value5\",\"value6\"]]}}],[{\"z\":{\"a\":[[\"value7\",\"value8\"],[\"value9\",\"value10\"]]}}]],[[{\"z\":{\"a\":[[\"value11\"]]}}]]]}}"));
        }

        [Test]
        public void RootAndInsert_TwoDimensionTwoLevel_WithProperty()
        {
            JsonPatch jp = new("{\"x\":{\"y\":[[{\"a\":\"value1\"},{\"a\":\"value2\"}],[{\"a\":\"value3\"},{\"a\":\"value4\"}]]}}"u8.ToArray());

            Assert.That(jp.GetJson("$.x"u8).ToString(), Is.EqualTo("{\"y\":[[{\"a\":\"value1\"},{\"a\":\"value2\"}],[{\"a\":\"value3\"},{\"a\":\"value4\"}]]}"));
            Assert.That(jp.GetJson("$.x.y"u8).ToString(), Is.EqualTo("[[{\"a\":\"value1\"},{\"a\":\"value2\"}],[{\"a\":\"value3\"},{\"a\":\"value4\"}]]"));
            Assert.That(jp.GetJson("$.x.y[0]"u8).ToString(), Is.EqualTo("[{\"a\":\"value1\"},{\"a\":\"value2\"}]"));
            Assert.That(jp.GetJson("$.x.y[0][0]"u8).ToString(), Is.EqualTo("{\"a\":\"value1\"}"));
            Assert.That(jp.GetString("$.x.y[0][0].a"u8), Is.EqualTo("value1"));
            Assert.That(jp.GetJson("$.x.y[0][1]"u8).ToString(), Is.EqualTo("{\"a\":\"value2\"}"));
            Assert.That(jp.GetString("$.x.y[0][1].a"u8), Is.EqualTo("value2"));
            Assert.That(jp.GetJson("$.x.y[1]"u8).ToString(), Is.EqualTo("[{\"a\":\"value3\"},{\"a\":\"value4\"}]"));
            Assert.That(jp.GetJson("$.x.y[1][0]"u8).ToString(), Is.EqualTo("{\"a\":\"value3\"}"));
            Assert.That(jp.GetString("$.x.y[1][0].a"u8), Is.EqualTo("value3"));
            Assert.That(jp.GetJson("$.x.y[1][1]"u8).ToString(), Is.EqualTo("{\"a\":\"value4\"}"));
            Assert.That(jp.GetString("$.x.y[1][1].a"u8), Is.EqualTo("value4"));

            jp.Append("$.x.y[0]"u8, "{\"a\":\"value5\"}"u8);

            Assert.That(jp.GetJson("$.x.y[0]"u8).ToString(), Is.EqualTo("[{\"a\":\"value1\"},{\"a\":\"value2\"},{\"a\":\"value5\"}]"));

            jp.Append("$.x.y[0]"u8, "{\"a\":\"value6\"}"u8);

            Assert.That(jp.GetJson("$.x.y[0]"u8).ToString(), Is.EqualTo("[{\"a\":\"value1\"},{\"a\":\"value2\"},{\"a\":\"value5\"},{\"a\":\"value6\"}]"));

            jp.Append("$.x.y[1]"u8, "{\"a\":\"value7\"}"u8);

            Assert.That(jp.GetJson("$.x.y[1]"u8).ToString(), Is.EqualTo("[{\"a\":\"value3\"},{\"a\":\"value4\"},{\"a\":\"value7\"}]"));

            jp.Append("$.x.y[1]"u8, "{\"a\":\"value8\"}"u8);

            Assert.That(jp.GetJson("$.x.y[1]"u8).ToString(), Is.EqualTo("[{\"a\":\"value3\"},{\"a\":\"value4\"},{\"a\":\"value7\"},{\"a\":\"value8\"}]"));

            jp.Append("$.x.y"u8, "[{\"a\":\"value9\"}]"u8);

            Assert.That(jp.GetJson("$.x.y"u8).ToString(), Is.EqualTo("[[{\"a\":\"value1\"},{\"a\":\"value2\"},{\"a\":\"value5\"},{\"a\":\"value6\"}],[{\"a\":\"value3\"},{\"a\":\"value4\"},{\"a\":\"value7\"},{\"a\":\"value8\"}],[{\"a\":\"value9\"}]]"));
            Assert.That(jp.GetJson("$.x.y[0]"u8).ToString(), Is.EqualTo("[{\"a\":\"value1\"},{\"a\":\"value2\"},{\"a\":\"value5\"},{\"a\":\"value6\"}]"));
            Assert.That(jp.GetJson("$.x.y[0][0]"u8).ToString(), Is.EqualTo("{\"a\":\"value1\"}"));
            Assert.That(jp.GetString("$.x.y[0][0].a"u8), Is.EqualTo("value1"));
            Assert.That(jp.GetJson("$.x.y[0][1]"u8).ToString(), Is.EqualTo("{\"a\":\"value2\"}"));
            Assert.That(jp.GetString("$.x.y[0][1].a"u8), Is.EqualTo("value2"));
            Assert.That(jp.GetJson("$.x.y[0][2]"u8).ToString(), Is.EqualTo("{\"a\":\"value5\"}"));
            Assert.That(jp.GetString("$.x.y[0][2].a"u8), Is.EqualTo("value5"));
            Assert.That(jp.GetJson("$.x.y[0][3]"u8).ToString(), Is.EqualTo("{\"a\":\"value6\"}"));
            Assert.That(jp.GetString("$.x.y[0][3].a"u8), Is.EqualTo("value6"));
            Assert.That(jp.GetJson("$.x.y[1]"u8).ToString(), Is.EqualTo("[{\"a\":\"value3\"},{\"a\":\"value4\"},{\"a\":\"value7\"},{\"a\":\"value8\"}]"));
            Assert.That(jp.GetJson("$.x.y[1][0]"u8).ToString(), Is.EqualTo("{\"a\":\"value3\"}"));
            Assert.That(jp.GetString("$.x.y[1][0].a"u8), Is.EqualTo("value3"));
            Assert.That(jp.GetJson("$.x.y[1][1]"u8).ToString(), Is.EqualTo("{\"a\":\"value4\"}"));
            Assert.That(jp.GetString("$.x.y[1][1].a"u8), Is.EqualTo("value4"));
            Assert.That(jp.GetJson("$.x.y[1][2]"u8).ToString(), Is.EqualTo("{\"a\":\"value7\"}"));
            Assert.That(jp.GetString("$.x.y[1][2].a"u8), Is.EqualTo("value7"));
            Assert.That(jp.GetJson("$.x.y[1][3]"u8).ToString(), Is.EqualTo("{\"a\":\"value8\"}"));
            Assert.That(jp.GetString("$.x.y[1][3].a"u8), Is.EqualTo("value8"));
            Assert.That(jp.GetJson("$.x.y[2]"u8).ToString(), Is.EqualTo("[{\"a\":\"value9\"}]"));
            Assert.That(jp.GetJson("$.x.y[2][0]"u8).ToString(), Is.EqualTo("{\"a\":\"value9\"}"));
            Assert.That(jp.GetString("$.x.y[2][0].a"u8), Is.EqualTo("value9"));

            Assert.That(jp.ToString("J"), Is.EqualTo("{\"x\":{\"y\":[[{\"a\":\"value1\"},{\"a\":\"value2\"},{\"a\":\"value5\"},{\"a\":\"value6\"}],[{\"a\":\"value3\"},{\"a\":\"value4\"},{\"a\":\"value7\"},{\"a\":\"value8\"}],[{\"a\":\"value9\"}]]}}"));
        }

        [Test]
        public void RootAndInsert_TwoDimensionTwoLevel()
        {
            JsonPatch jp = new("{\"x\":{\"y\":[[\"value1\",\"value2\"],[\"value3\",\"value4\"]]}}"u8.ToArray());

            Assert.That(jp.GetJson("$.x"u8).ToString(), Is.EqualTo("{\"y\":[[\"value1\",\"value2\"],[\"value3\",\"value4\"]]}"));
            Assert.That(jp.GetJson("$.x.y"u8).ToString(), Is.EqualTo("[[\"value1\",\"value2\"],[\"value3\",\"value4\"]]"));
            Assert.That(jp.GetJson("$.x.y[0]"u8).ToString(), Is.EqualTo("[\"value1\",\"value2\"]"));
            Assert.That(jp.GetString("$.x.y[0][0]"u8), Is.EqualTo("value1"));
            Assert.That(jp.GetString("$.x.y[0][1]"u8), Is.EqualTo("value2"));
            Assert.That(jp.GetJson("$.x.y[1]"u8).ToString(), Is.EqualTo("[\"value3\",\"value4\"]"));
            Assert.That(jp.GetString("$.x.y[1][0]"u8), Is.EqualTo("value3"));
            Assert.That(jp.GetString("$.x.y[1][1]"u8), Is.EqualTo("value4"));

            jp.Append("$.x.y[0]"u8, "value5");

            Assert.That(jp.GetJson("$.x.y[0]"u8).ToString(), Is.EqualTo("[\"value1\",\"value2\",\"value5\"]"));

            jp.Append("$.x.y[0]"u8, "value6");

            Assert.That(jp.GetJson("$.x.y[0]"u8).ToString(), Is.EqualTo("[\"value1\",\"value2\",\"value5\",\"value6\"]"));

            jp.Append("$.x.y[1]"u8, "value7");

            Assert.That(jp.GetJson("$.x.y[1]"u8).ToString(), Is.EqualTo("[\"value3\",\"value4\",\"value7\"]"));

            jp.Append("$.x.y[1]"u8, "value8");

            Assert.That(jp.GetJson("$.x.y[1]"u8).ToString(), Is.EqualTo("[\"value3\",\"value4\",\"value7\",\"value8\"]"));

            jp.Append("$.x.y"u8, "[\"value9\"]"u8);

            Assert.That(jp.GetJson("$.x"u8).ToString(), Is.EqualTo("{\"y\":[[\"value1\",\"value2\"],[\"value3\",\"value4\"]]}"));
            Assert.That(jp.GetJson("$.x.y"u8).ToString(), Is.EqualTo("[[\"value1\",\"value2\",\"value5\",\"value6\"],[\"value3\",\"value4\",\"value7\",\"value8\"],[\"value9\"]]"));
            Assert.That(jp.GetJson("$.x.y[0]"u8).ToString(), Is.EqualTo("[\"value1\",\"value2\",\"value5\",\"value6\"]"));
            Assert.That(jp.GetString("$.x.y[0][0]"u8), Is.EqualTo("value1"));
            Assert.That(jp.GetString("$.x.y[0][1]"u8), Is.EqualTo("value2"));
            Assert.That(jp.GetString("$.x.y[0][2]"u8), Is.EqualTo("value5"));
            Assert.That(jp.GetString("$.x.y[0][3]"u8), Is.EqualTo("value6"));
            Assert.That(jp.GetJson("$.x.y[1]"u8).ToString(), Is.EqualTo("[\"value3\",\"value4\",\"value7\",\"value8\"]"));
            Assert.That(jp.GetString("$.x.y[1][0]"u8), Is.EqualTo("value3"));
            Assert.That(jp.GetString("$.x.y[1][1]"u8), Is.EqualTo("value4"));
            Assert.That(jp.GetString("$.x.y[1][2]"u8), Is.EqualTo("value7"));
            Assert.That(jp.GetString("$.x.y[1][3]"u8), Is.EqualTo("value8"));
            Assert.That(jp.GetJson("$.x.y[2]"u8).ToString(), Is.EqualTo("[\"value9\"]"));
            Assert.That(jp.GetString("$.x.y[2][0]"u8), Is.EqualTo("value9"));

            Assert.That(jp.ToString("J"), Is.EqualTo("{\"x\":{\"y\":[[\"value1\",\"value2\",\"value5\",\"value6\"],[\"value3\",\"value4\",\"value7\",\"value8\"],[\"value9\"]]}}"));
        }

        [Test]
        public void Insert_TwoDimensionTwoLevel_WithProperty()
        {
            JsonPatch jp = new();

            jp.Append("$.x.y[0]"u8, "{\"a\":\"value1\"}"u8);

            Assert.That(jp.GetJson("$.x"u8).ToString(), Is.EqualTo("{\"y\":[[{\"a\":\"value1\"}]]}"));

            jp.Append("$.x.y[0]"u8, "{\"a\":\"value2\"}"u8);

            Assert.That(jp.GetJson("$.x"u8).ToString(), Is.EqualTo("{\"y\":[[{\"a\":\"value1\"},{\"a\":\"value2\"}]]}"));

            jp.Append("$.x.y[1]"u8, "{\"a\":\"value3\"}"u8);

            Assert.That(jp.GetJson("$.x"u8).ToString(), Is.EqualTo("{\"y\":[[{\"a\":\"value1\"},{\"a\":\"value2\"}],[{\"a\":\"value3\"}]]}"));

            jp.Append("$.x.y[1]"u8, "{\"a\":\"value4\"}"u8);

            Assert.That(jp.GetJson("$.x"u8).ToString(), Is.EqualTo("{\"y\":[[{\"a\":\"value1\"},{\"a\":\"value2\"}],[{\"a\":\"value3\"},{\"a\":\"value4\"}]]}"));

            jp.Append("$.x.y"u8, "[{\"a\":\"value5\"}]"u8);

            Assert.That(jp.GetJson("$.x"u8).ToString(), Is.EqualTo("{\"y\":[[{\"a\":\"value1\"},{\"a\":\"value2\"}],[{\"a\":\"value3\"},{\"a\":\"value4\"}],[{\"a\":\"value5\"}]]}"));
            Assert.That(jp.GetJson("$.x.y"u8).ToString(), Is.EqualTo("[[{\"a\":\"value1\"},{\"a\":\"value2\"}],[{\"a\":\"value3\"},{\"a\":\"value4\"}],[{\"a\":\"value5\"}]]"));
            Assert.That(jp.GetJson("$.x.y[0]"u8).ToString(), Is.EqualTo("[{\"a\":\"value1\"},{\"a\":\"value2\"}]"));
            Assert.That(jp.GetJson("$.x.y[0][0]"u8).ToString(), Is.EqualTo("{\"a\":\"value1\"}"));
            Assert.That(jp.GetString("$.x.y[0][0].a"u8), Is.EqualTo("value1"));
            Assert.That(jp.GetJson("$.x.y[0][1]"u8).ToString(), Is.EqualTo("{\"a\":\"value2\"}"));
            Assert.That(jp.GetString("$.x.y[0][1].a"u8), Is.EqualTo("value2"));
            Assert.That(jp.GetJson("$.x.y[1]"u8).ToString(), Is.EqualTo("[{\"a\":\"value3\"},{\"a\":\"value4\"}]"));
            Assert.That(jp.GetJson("$.x.y[1][0]"u8).ToString(), Is.EqualTo("{\"a\":\"value3\"}"));
            Assert.That(jp.GetString("$.x.y[1][0].a"u8), Is.EqualTo("value3"));
            Assert.That(jp.GetJson("$.x.y[1][1]"u8).ToString(), Is.EqualTo("{\"a\":\"value4\"}"));
            Assert.That(jp.GetString("$.x.y[1][1].a"u8), Is.EqualTo("value4"));
            Assert.That(jp.GetJson("$.x.y[2]"u8).ToString(), Is.EqualTo("[{\"a\":\"value5\"}]"));
            Assert.That(jp.GetJson("$.x.y[2][0]"u8).ToString(), Is.EqualTo("{\"a\":\"value5\"}"));
            Assert.That(jp.GetString("$.x.y[2][0].a"u8), Is.EqualTo("value5"));

            Assert.That(jp.ToString("J"), Is.EqualTo("{\"x\":{\"y\":[[{\"a\":\"value1\"},{\"a\":\"value2\"}],[{\"a\":\"value3\"},{\"a\":\"value4\"}],[{\"a\":\"value5\"}]]}}"));
        }

        [Test]
        public void Insert_TwoDimensionTwoLevel()
        {
            JsonPatch jp = new();

            jp.Append("$.x.y[0]"u8, "value1");

            Assert.That(jp.GetJson("$.x"u8).ToString(), Is.EqualTo("{\"y\":[[\"value1\"]]}"));

            jp.Append("$.x.y[0]"u8, "value2");

            Assert.That(jp.GetJson("$.x"u8).ToString(), Is.EqualTo("{\"y\":[[\"value1\",\"value2\"]]}"));

            jp.Append("$.x.y[1]"u8, "value3");

            Assert.That(jp.GetJson("$.x"u8).ToString(), Is.EqualTo("{\"y\":[[\"value1\",\"value2\"],[\"value3\"]]}"));

            jp.Append("$.x.y[1]"u8, "value4");

            Assert.That(jp.GetJson("$.x"u8).ToString(), Is.EqualTo("{\"y\":[[\"value1\",\"value2\"],[\"value3\",\"value4\"]]}"));

            jp.Append("$.x.y"u8, "[\"value5\"]"u8);

            Assert.That(jp.GetJson("$.x"u8).ToString(), Is.EqualTo("{\"y\":[[\"value1\",\"value2\"],[\"value3\",\"value4\"],[\"value5\"]]}"));
            Assert.That(jp.GetJson("$.x.y"u8).ToString(), Is.EqualTo("[[\"value1\",\"value2\"],[\"value3\",\"value4\"],[\"value5\"]]"));
            Assert.That(jp.GetJson("$.x.y[0]"u8).ToString(), Is.EqualTo("[\"value1\",\"value2\"]"));
            Assert.That(jp.GetString("$.x.y[0][0]"u8), Is.EqualTo("value1"));
            Assert.That(jp.GetString("$.x.y[0][1]"u8), Is.EqualTo("value2"));
            Assert.That(jp.GetJson("$.x.y[1]"u8).ToString(), Is.EqualTo("[\"value3\",\"value4\"]"));
            Assert.That(jp.GetString("$.x.y[1][0]"u8), Is.EqualTo("value3"));
            Assert.That(jp.GetString("$.x.y[1][1]"u8), Is.EqualTo("value4"));
            Assert.That(jp.GetJson("$.x.y[2]"u8).ToString(), Is.EqualTo("[\"value5\"]"));
            Assert.That(jp.GetString("$.x.y[2][0]"u8), Is.EqualTo("value5"));

            Assert.That(jp.ToString("J"), Is.EqualTo("{\"x\":{\"y\":[[\"value1\",\"value2\"],[\"value3\",\"value4\"],[\"value5\"]]}}"));
        }

        [Test]
        public void RootAndInsert_TwoDimensionOneLevel_WithProperty()
        {
            JsonPatch jp = new("{\"x\":[[{\"a\":\"value1\"},{\"a\":\"value2\"}],[{\"a\":\"value3\"},{\"a\":\"value4\"}]]}"u8.ToArray());

            Assert.That(jp.GetJson("$.x"u8).ToString(), Is.EqualTo("[[{\"a\":\"value1\"},{\"a\":\"value2\"}],[{\"a\":\"value3\"},{\"a\":\"value4\"}]]"));
            Assert.That(jp.GetJson("$.x[0]"u8).ToString(), Is.EqualTo("[{\"a\":\"value1\"},{\"a\":\"value2\"}]"));
            Assert.That(jp.GetJson("$.x[0][0]"u8).ToString(), Is.EqualTo("{\"a\":\"value1\"}"));
            Assert.That(jp.GetString("$.x[0][0].a"u8), Is.EqualTo("value1"));
            Assert.That(jp.GetJson("$.x[0][1]"u8).ToString(), Is.EqualTo("{\"a\":\"value2\"}"));
            Assert.That(jp.GetString("$.x[0][1].a"u8), Is.EqualTo("value2"));
            Assert.That(jp.GetJson("$.x[1]"u8).ToString(), Is.EqualTo("[{\"a\":\"value3\"},{\"a\":\"value4\"}]"));
            Assert.That(jp.GetJson("$.x[1][0]"u8).ToString(), Is.EqualTo("{\"a\":\"value3\"}"));
            Assert.That(jp.GetString("$.x[1][0].a"u8), Is.EqualTo("value3"));
            Assert.That(jp.GetJson("$.x[1][1]"u8).ToString(), Is.EqualTo("{\"a\":\"value4\"}"));
            Assert.That(jp.GetString("$.x[1][1].a"u8), Is.EqualTo("value4"));

            jp.Append("$.x[0]"u8, "{\"a\":\"value5\"}"u8);

            Assert.That(jp.GetJson("$.x[0]"u8).ToString(), Is.EqualTo("[{\"a\":\"value1\"},{\"a\":\"value2\"},{\"a\":\"value5\"}]"));

            jp.Append("$.x[0]"u8, "{\"a\":\"value6\"}"u8);

            Assert.That(jp.GetJson("$.x[0]"u8).ToString(), Is.EqualTo("[{\"a\":\"value1\"},{\"a\":\"value2\"},{\"a\":\"value5\"},{\"a\":\"value6\"}]"));

            jp.Append("$.x[1]"u8, "{\"a\":\"value7\"}"u8);

            Assert.That(jp.GetJson("$.x[1]"u8).ToString(), Is.EqualTo("[{\"a\":\"value3\"},{\"a\":\"value4\"},{\"a\":\"value7\"}]"));

            jp.Append("$.x[1]"u8, "{\"a\":\"value8\"}"u8);

            Assert.That(jp.GetJson("$.x[1]"u8).ToString(), Is.EqualTo("[{\"a\":\"value3\"},{\"a\":\"value4\"},{\"a\":\"value7\"},{\"a\":\"value8\"}]"));

            jp.Append("$.x"u8, "[{\"a\":\"value9\"}]"u8);

            Assert.That(jp.GetJson("$.x"u8).ToString(), Is.EqualTo("[[{\"a\":\"value1\"},{\"a\":\"value2\"},{\"a\":\"value5\"},{\"a\":\"value6\"}],[{\"a\":\"value3\"},{\"a\":\"value4\"},{\"a\":\"value7\"},{\"a\":\"value8\"}],[{\"a\":\"value9\"}]]"));
            Assert.That(jp.GetJson("$.x[0]"u8).ToString(), Is.EqualTo("[{\"a\":\"value1\"},{\"a\":\"value2\"},{\"a\":\"value5\"},{\"a\":\"value6\"}]"));
            Assert.That(jp.GetJson("$.x[0][0]"u8).ToString(), Is.EqualTo("{\"a\":\"value1\"}"));
            Assert.That(jp.GetString("$.x[0][0].a"u8), Is.EqualTo("value1"));
            Assert.That(jp.GetJson("$.x[0][1]"u8).ToString(), Is.EqualTo("{\"a\":\"value2\"}"));
            Assert.That(jp.GetString("$.x[0][1].a"u8), Is.EqualTo("value2"));
            Assert.That(jp.GetJson("$.x[0][2]"u8).ToString(), Is.EqualTo("{\"a\":\"value5\"}"));
            Assert.That(jp.GetString("$.x[0][2].a"u8), Is.EqualTo("value5"));
            Assert.That(jp.GetJson("$.x[0][3]"u8).ToString(), Is.EqualTo("{\"a\":\"value6\"}"));
            Assert.That(jp.GetString("$.x[0][3].a"u8), Is.EqualTo("value6"));
            Assert.That(jp.GetJson("$.x[1]"u8).ToString(), Is.EqualTo("[{\"a\":\"value3\"},{\"a\":\"value4\"},{\"a\":\"value7\"},{\"a\":\"value8\"}]"));
            Assert.That(jp.GetJson("$.x[1][0]"u8).ToString(), Is.EqualTo("{\"a\":\"value3\"}"));
            Assert.That(jp.GetString("$.x[1][0].a"u8), Is.EqualTo("value3"));
            Assert.That(jp.GetJson("$.x[1][1]"u8).ToString(), Is.EqualTo("{\"a\":\"value4\"}"));
            Assert.That(jp.GetString("$.x[1][1].a"u8), Is.EqualTo("value4"));
            Assert.That(jp.GetJson("$.x[1][2]"u8).ToString(), Is.EqualTo("{\"a\":\"value7\"}"));
            Assert.That(jp.GetString("$.x[1][2].a"u8), Is.EqualTo("value7"));
            Assert.That(jp.GetJson("$.x[1][3]"u8).ToString(), Is.EqualTo("{\"a\":\"value8\"}"));
            Assert.That(jp.GetString("$.x[1][3].a"u8), Is.EqualTo("value8"));
            Assert.That(jp.GetJson("$.x[2]"u8).ToString(), Is.EqualTo("[{\"a\":\"value9\"}]"));
            Assert.That(jp.GetJson("$.x[2][0]"u8).ToString(), Is.EqualTo("{\"a\":\"value9\"}"));
            Assert.That(jp.GetString("$.x[2][0].a"u8), Is.EqualTo("value9"));

            Assert.That(jp.ToString("J"), Is.EqualTo("{\"x\":[[{\"a\":\"value1\"},{\"a\":\"value2\"},{\"a\":\"value5\"},{\"a\":\"value6\"}],[{\"a\":\"value3\"},{\"a\":\"value4\"},{\"a\":\"value7\"},{\"a\":\"value8\"}],[{\"a\":\"value9\"}]]}"));
        }

        [Test]
        public void RootAndInsert_TwoDimensionOneLevel()
        {
            JsonPatch jp = new("{\"x\":[[\"value1\",\"value2\"],[\"value3\",\"value4\"]]}"u8.ToArray());

            Assert.That(jp.GetJson("$.x"u8).ToString(), Is.EqualTo("[[\"value1\",\"value2\"],[\"value3\",\"value4\"]]"));
            Assert.That(jp.GetJson("$.x[0]"u8).ToString(), Is.EqualTo("[\"value1\",\"value2\"]"));
            Assert.That(jp.GetString("$.x[0][0]"u8), Is.EqualTo("value1"));
            Assert.That(jp.GetString("$.x[0][1]"u8), Is.EqualTo("value2"));
            Assert.That(jp.GetJson("$.x[1]"u8).ToString(), Is.EqualTo("[\"value3\",\"value4\"]"));
            Assert.That(jp.GetString("$.x[1][0]"u8), Is.EqualTo("value3"));
            Assert.That(jp.GetString("$.x[1][1]"u8), Is.EqualTo("value4"));

            jp.Append("$.x[0]"u8, "value5");

            Assert.That(jp.GetJson("$.x[0]"u8).ToString(), Is.EqualTo("[\"value1\",\"value2\",\"value5\"]"));

            jp.Append("$.x[0]"u8, "value6");

            Assert.That(jp.GetJson("$.x[0]"u8).ToString(), Is.EqualTo("[\"value1\",\"value2\",\"value5\",\"value6\"]"));

            jp.Append("$.x[1]"u8, "value7");

            Assert.That(jp.GetJson("$.x[1]"u8).ToString(), Is.EqualTo("[\"value3\",\"value4\",\"value7\"]"));

            jp.Append("$.x[1]"u8, "value8");

            Assert.That(jp.GetJson("$.x[1]"u8).ToString(), Is.EqualTo("[\"value3\",\"value4\",\"value7\",\"value8\"]"));

            jp.Append("$.x"u8, "[\"value9\"]"u8);

            Assert.That(jp.GetJson("$.x"u8).ToString(), Is.EqualTo("[[\"value1\",\"value2\",\"value5\",\"value6\"],[\"value3\",\"value4\",\"value7\",\"value8\"],[\"value9\"]]"));
            Assert.That(jp.GetJson("$.x[0]"u8).ToString(), Is.EqualTo("[\"value1\",\"value2\",\"value5\",\"value6\"]"));
            Assert.That(jp.GetString("$.x[0][0]"u8), Is.EqualTo("value1"));
            Assert.That(jp.GetString("$.x[0][1]"u8), Is.EqualTo("value2"));
            Assert.That(jp.GetString("$.x[0][2]"u8), Is.EqualTo("value5"));
            Assert.That(jp.GetString("$.x[0][3]"u8), Is.EqualTo("value6"));
            Assert.That(jp.GetJson("$.x[1]"u8).ToString(), Is.EqualTo("[\"value3\",\"value4\",\"value7\",\"value8\"]"));
            Assert.That(jp.GetString("$.x[1][0]"u8), Is.EqualTo("value3"));
            Assert.That(jp.GetString("$.x[1][1]"u8), Is.EqualTo("value4"));
            Assert.That(jp.GetString("$.x[1][2]"u8), Is.EqualTo("value7"));
            Assert.That(jp.GetString("$.x[1][3]"u8), Is.EqualTo("value8"));
            Assert.That(jp.GetJson("$.x[2]"u8).ToString(), Is.EqualTo("[\"value9\"]"));
            Assert.That(jp.GetString("$.x[2][0]"u8), Is.EqualTo("value9"));

            Assert.That(jp.ToString("J"), Is.EqualTo("{\"x\":[[\"value1\",\"value2\",\"value5\",\"value6\"],[\"value3\",\"value4\",\"value7\",\"value8\"],[\"value9\"]]}"));
        }

        [Test]
        public void Insert_TwoDimensionOneLevel_WithProperty()
        {
            JsonPatch jp = new();

            jp.Append("$.x[0]"u8, "{\"a\":\"value1\"}"u8);

            Assert.That(jp.GetJson("$.x"u8).ToString(), Is.EqualTo("[[{\"a\":\"value1\"}]]"));

            jp.Append("$.x[0]"u8, "{\"a\":\"value2\"}"u8);

            Assert.That(jp.GetJson("$.x"u8).ToString(), Is.EqualTo("[[{\"a\":\"value1\"},{\"a\":\"value2\"}]]"));

            jp.Append("$.x[1]"u8, "{\"a\":\"value3\"}"u8);

            Assert.That(jp.GetJson("$.x"u8).ToString(), Is.EqualTo("[[{\"a\":\"value1\"},{\"a\":\"value2\"}],[{\"a\":\"value3\"}]]"));

            jp.Append("$.x[1]"u8, "{\"a\":\"value4\"}"u8);

            Assert.That(jp.GetJson("$.x"u8).ToString(), Is.EqualTo("[[{\"a\":\"value1\"},{\"a\":\"value2\"}],[{\"a\":\"value3\"},{\"a\":\"value4\"}]]"));

            jp.Append("$.x"u8, "[{\"a\":\"value5\"}]"u8);

            Assert.That(jp.GetJson("$.x"u8).ToString(), Is.EqualTo("[[{\"a\":\"value1\"},{\"a\":\"value2\"}],[{\"a\":\"value3\"},{\"a\":\"value4\"}],[{\"a\":\"value5\"}]]"));
            Assert.That(jp.GetJson("$.x[0]"u8).ToString(), Is.EqualTo("[{\"a\":\"value1\"},{\"a\":\"value2\"}]"));
            Assert.That(jp.GetJson("$.x[0][0]"u8).ToString(), Is.EqualTo("{\"a\":\"value1\"}"));
            Assert.That(jp.GetString("$.x[0][0].a"u8), Is.EqualTo("value1"));
            Assert.That(jp.GetJson("$.x[0][1]"u8).ToString(), Is.EqualTo("{\"a\":\"value2\"}"));
            Assert.That(jp.GetString("$.x[0][1].a"u8), Is.EqualTo("value2"));
            Assert.That(jp.GetJson("$.x[1]"u8).ToString(), Is.EqualTo("[{\"a\":\"value3\"},{\"a\":\"value4\"}]"));
            Assert.That(jp.GetJson("$.x[1][0]"u8).ToString(), Is.EqualTo("{\"a\":\"value3\"}"));
            Assert.That(jp.GetString("$.x[1][0].a"u8), Is.EqualTo("value3"));
            Assert.That(jp.GetJson("$.x[1][1]"u8).ToString(), Is.EqualTo("{\"a\":\"value4\"}"));
            Assert.That(jp.GetString("$.x[1][1].a"u8), Is.EqualTo("value4"));
            Assert.That(jp.GetJson("$.x[2]"u8).ToString(), Is.EqualTo("[{\"a\":\"value5\"}]"));
            Assert.That(jp.GetJson("$.x[2][0]"u8).ToString(), Is.EqualTo("{\"a\":\"value5\"}"));
            Assert.That(jp.GetString("$.x[2][0].a"u8), Is.EqualTo("value5"));

            Assert.That(jp.ToString("J"), Is.EqualTo("{\"x\":[[{\"a\":\"value1\"},{\"a\":\"value2\"}],[{\"a\":\"value3\"},{\"a\":\"value4\"}],[{\"a\":\"value5\"}]]}"));
        }

        [Test]
        public void Insert_TwoDimensionOneLevel()
        {
            JsonPatch jp = new();

            jp.Append("$.x[0]"u8, "value1");

            Assert.That(jp.GetJson("$.x"u8).ToString(), Is.EqualTo("[[\"value1\"]]"));

            jp.Append("$.x[0]"u8, "value2");

            Assert.That(jp.GetJson("$.x"u8).ToString(), Is.EqualTo("[[\"value1\",\"value2\"]]"));

            jp.Append("$.x[1]"u8, "value3");

            Assert.That(jp.GetJson("$.x"u8).ToString(), Is.EqualTo("[[\"value1\",\"value2\"],[\"value3\"]]"));

            jp.Append("$.x[1]"u8, "value4");

            Assert.That(jp.GetJson("$.x"u8).ToString(), Is.EqualTo("[[\"value1\",\"value2\"],[\"value3\",\"value4\"]]"));

            jp.Append("$.x"u8, "[\"value5\"]"u8);
            Assert.That(jp.GetJson("$.x"u8).ToString(), Is.EqualTo("[[\"value1\",\"value2\"],[\"value3\",\"value4\"],[\"value5\"]]"));
            Assert.That(jp.GetJson("$.x[0]"u8).ToString(), Is.EqualTo("[\"value1\",\"value2\"]"));
            Assert.That(jp.GetString("$.x[0][0]"u8), Is.EqualTo("value1"));
            Assert.That(jp.GetString("$.x[0][1]"u8), Is.EqualTo("value2"));
            Assert.That(jp.GetJson("$.x[1]"u8).ToString(), Is.EqualTo("[\"value3\",\"value4\"]"));
            Assert.That(jp.GetString("$.x[1][0]"u8), Is.EqualTo("value3"));
            Assert.That(jp.GetString("$.x[1][1]"u8), Is.EqualTo("value4"));
            Assert.That(jp.GetJson("$.x[2]"u8).ToString(), Is.EqualTo("[\"value5\"]"));
            Assert.That(jp.GetString("$.x[2][0]"u8), Is.EqualTo("value5"));

            Assert.That(jp.ToString("J"), Is.EqualTo("{\"x\":[[\"value1\",\"value2\"],[\"value3\",\"value4\"],[\"value5\"]]}"));
        }

        [Test]
        public void RootAndInsert_TwoDimension_WithProperty()
        {
            JsonPatch jp = new("[[{\"a\":\"value1\"},{\"a\":\"value2\"}],[{\"a\":\"value3\"},{\"a\":\"value4\"}]]"u8.ToArray());

            Assert.That(jp.GetJson("$[0]"u8).ToString(), Is.EqualTo("[{\"a\":\"value1\"},{\"a\":\"value2\"}]"));
            Assert.That(jp.GetJson("$[0][0]"u8).ToString(), Is.EqualTo("{\"a\":\"value1\"}"));
            Assert.That(jp.GetString("$[0][0].a"u8), Is.EqualTo("value1"));
            Assert.That(jp.GetJson("$[0][1]"u8).ToString(), Is.EqualTo("{\"a\":\"value2\"}"));
            Assert.That(jp.GetString("$[0][1].a"u8), Is.EqualTo("value2"));
            Assert.That(jp.GetJson("$[1]"u8).ToString(), Is.EqualTo("[{\"a\":\"value3\"},{\"a\":\"value4\"}]"));
            Assert.That(jp.GetJson("$[1][0]"u8).ToString(), Is.EqualTo("{\"a\":\"value3\"}"));
            Assert.That(jp.GetString("$[1][0].a"u8), Is.EqualTo("value3"));
            Assert.That(jp.GetJson("$[1][1]"u8).ToString(), Is.EqualTo("{\"a\":\"value4\"}"));
            Assert.That(jp.GetString("$[1][1].a"u8), Is.EqualTo("value4"));

            jp.Append("$[0]"u8, "{\"a\":\"value5\"}"u8);

            Assert.That(jp.GetJson("$[0]"u8).ToString(), Is.EqualTo("[{\"a\":\"value1\"},{\"a\":\"value2\"},{\"a\":\"value5\"}]"));

            jp.Append("$[0]"u8, "{\"a\":\"value6\"}"u8);

            Assert.That(jp.GetJson("$[0]"u8).ToString(), Is.EqualTo("[{\"a\":\"value1\"},{\"a\":\"value2\"},{\"a\":\"value5\"},{\"a\":\"value6\"}]"));

            jp.Append("$[1]"u8, "{\"a\":\"value7\"}"u8);

            Assert.That(jp.GetJson("$[1]"u8).ToString(), Is.EqualTo("[{\"a\":\"value3\"},{\"a\":\"value4\"},{\"a\":\"value7\"}]"));

            jp.Append("$[1]"u8, "{\"a\":\"value8\"}"u8);

            Assert.That(jp.GetJson("$[1]"u8).ToString(), Is.EqualTo("[{\"a\":\"value3\"},{\"a\":\"value4\"},{\"a\":\"value7\"},{\"a\":\"value8\"}]"));

            jp.Append("$"u8, "[{\"a\":\"value9\"}]"u8);

            Assert.That(jp.GetJson("$"u8).ToString(), Is.EqualTo("[[{\"a\":\"value1\"},{\"a\":\"value2\"},{\"a\":\"value5\"},{\"a\":\"value6\"}],[{\"a\":\"value3\"},{\"a\":\"value4\"},{\"a\":\"value7\"},{\"a\":\"value8\"}],[{\"a\":\"value9\"}]]"));
            Assert.That(jp.GetJson("$[0]"u8).ToString(), Is.EqualTo("[{\"a\":\"value1\"},{\"a\":\"value2\"},{\"a\":\"value5\"},{\"a\":\"value6\"}]"));
            Assert.That(jp.GetJson("$[0][0]"u8).ToString(), Is.EqualTo("{\"a\":\"value1\"}"));
            Assert.That(jp.GetString("$[0][0].a"u8), Is.EqualTo("value1"));
            Assert.That(jp.GetJson("$[0][1]"u8).ToString(), Is.EqualTo("{\"a\":\"value2\"}"));
            Assert.That(jp.GetString("$[0][1].a"u8), Is.EqualTo("value2"));
            Assert.That(jp.GetJson("$[0][2]"u8).ToString(), Is.EqualTo("{\"a\":\"value5\"}"));
            Assert.That(jp.GetString("$[0][2].a"u8), Is.EqualTo("value5"));
            Assert.That(jp.GetJson("$[0][3]"u8).ToString(), Is.EqualTo("{\"a\":\"value6\"}"));
            Assert.That(jp.GetString("$[0][3].a"u8), Is.EqualTo("value6"));
            Assert.That(jp.GetJson("$[1]"u8).ToString(), Is.EqualTo("[{\"a\":\"value3\"},{\"a\":\"value4\"},{\"a\":\"value7\"},{\"a\":\"value8\"}]"));
            Assert.That(jp.GetJson("$[1][0]"u8).ToString(), Is.EqualTo("{\"a\":\"value3\"}"));
            Assert.That(jp.GetString("$[1][0].a"u8), Is.EqualTo("value3"));
            Assert.That(jp.GetJson("$[1][1]"u8).ToString(), Is.EqualTo("{\"a\":\"value4\"}"));
            Assert.That(jp.GetString("$[1][1].a"u8), Is.EqualTo("value4"));
            Assert.That(jp.GetJson("$[1][2]"u8).ToString(), Is.EqualTo("{\"a\":\"value7\"}"));
            Assert.That(jp.GetString("$[1][2].a"u8), Is.EqualTo("value7"));
            Assert.That(jp.GetJson("$[1][3]"u8).ToString(), Is.EqualTo("{\"a\":\"value8\"}"));
            Assert.That(jp.GetString("$[1][3].a"u8), Is.EqualTo("value8"));
            Assert.That(jp.GetJson("$[2]"u8).ToString(), Is.EqualTo("[{\"a\":\"value9\"}]"));
            Assert.That(jp.GetJson("$[2][0]"u8).ToString(), Is.EqualTo("{\"a\":\"value9\"}"));
            Assert.That(jp.GetString("$[2][0].a"u8), Is.EqualTo("value9"));

            Assert.That(jp.ToString("J"), Is.EqualTo("[[{\"a\":\"value1\"},{\"a\":\"value2\"},{\"a\":\"value5\"},{\"a\":\"value6\"}],[{\"a\":\"value3\"},{\"a\":\"value4\"},{\"a\":\"value7\"},{\"a\":\"value8\"}],[{\"a\":\"value9\"}]]"));
        }

        [Test]
        public void RootAndInsert_TwoDimension()
        {
            JsonPatch jp = new("[[\"value1\",\"value2\"],[\"value3\",\"value4\"]]"u8.ToArray());

            Assert.That(jp.GetJson("$[0]"u8).ToString(), Is.EqualTo("[\"value1\",\"value2\"]"));
            Assert.That(jp.GetString("$[0][0]"u8), Is.EqualTo("value1"));
            Assert.That(jp.GetString("$[0][1]"u8), Is.EqualTo("value2"));
            Assert.That(jp.GetJson("$[1]"u8).ToString(), Is.EqualTo("[\"value3\",\"value4\"]"));
            Assert.That(jp.GetString("$[1][0]"u8), Is.EqualTo("value3"));
            Assert.That(jp.GetString("$[1][1]"u8), Is.EqualTo("value4"));

            jp.Append("$[0]"u8, "value5");

            Assert.That(jp.GetJson("$[0]"u8).ToString(), Is.EqualTo("[\"value1\",\"value2\",\"value5\"]"));

            jp.Append("$[0]"u8, "value6");

            Assert.That(jp.GetJson("$[0]"u8).ToString(), Is.EqualTo("[\"value1\",\"value2\",\"value5\",\"value6\"]"));

            jp.Append("$[1]"u8, "value7");

            Assert.That(jp.GetJson("$[1]"u8).ToString(), Is.EqualTo("[\"value3\",\"value4\",\"value7\"]"));

            jp.Append("$[1]"u8, "value8");

            Assert.That(jp.GetJson("$[1]"u8).ToString(), Is.EqualTo("[\"value3\",\"value4\",\"value7\",\"value8\"]"));

            jp.Append("$"u8, "[\"value9\"]"u8);

            Assert.That(jp.GetJson("$"u8).ToString(), Is.EqualTo("[[\"value1\",\"value2\",\"value5\",\"value6\"],[\"value3\",\"value4\",\"value7\",\"value8\"],[\"value9\"]]"));
            Assert.That(jp.GetJson("$[0]"u8).ToString(), Is.EqualTo("[\"value1\",\"value2\",\"value5\",\"value6\"]"));
            Assert.That(jp.GetString("$[0][0]"u8), Is.EqualTo("value1"));
            Assert.That(jp.GetString("$[0][1]"u8), Is.EqualTo("value2"));
            Assert.That(jp.GetString("$[0][2]"u8), Is.EqualTo("value5"));
            Assert.That(jp.GetString("$[0][3]"u8), Is.EqualTo("value6"));
            Assert.That(jp.GetJson("$[1]"u8).ToString(), Is.EqualTo("[\"value3\",\"value4\",\"value7\",\"value8\"]"));
            Assert.That(jp.GetString("$[1][0]"u8), Is.EqualTo("value3"));
            Assert.That(jp.GetString("$[1][1]"u8), Is.EqualTo("value4"));
            Assert.That(jp.GetString("$[1][2]"u8), Is.EqualTo("value7"));
            Assert.That(jp.GetString("$[1][3]"u8), Is.EqualTo("value8"));
            Assert.That(jp.GetJson("$[2]"u8).ToString(), Is.EqualTo("[\"value9\"]"));
            Assert.That(jp.GetString("$[2][0]"u8), Is.EqualTo("value9"));

            Assert.That(jp.ToString("J"), Is.EqualTo("[[\"value1\",\"value2\",\"value5\",\"value6\"],[\"value3\",\"value4\",\"value7\",\"value8\"],[\"value9\"]]"));
        }

        [Test]
        public void Insert_TwoDimension_WithProperty()
        {
            JsonPatch jp = new();

            jp.Append("$[0]"u8, "{\"a\":\"value1\"}"u8);

            Assert.That(jp.GetJson("$[0]"u8).ToString(), Is.EqualTo("[{\"a\":\"value1\"}]"));

            jp.Append("$[0]"u8, "{\"a\":\"value2\"}"u8);

            Assert.That(jp.GetJson("$[0]"u8).ToString(), Is.EqualTo("[{\"a\":\"value1\"},{\"a\":\"value2\"}]"));

            jp.Append("$[1]"u8, "{\"a\":\"value3\"}"u8);

            Assert.That(jp.GetJson("$[1]"u8).ToString(), Is.EqualTo("[{\"a\":\"value3\"}]"));

            jp.Append("$[1]"u8, "{\"a\":\"value4\"}"u8);

            Assert.That(jp.GetJson("$[1]"u8).ToString(), Is.EqualTo("[{\"a\":\"value3\"},{\"a\":\"value4\"}]"));

            jp.Append("$"u8, "[{\"a\":\"value5\"}]"u8);

            Assert.That(jp.GetJson("$"u8).ToString(), Is.EqualTo("[[{\"a\":\"value1\"},{\"a\":\"value2\"}],[{\"a\":\"value3\"},{\"a\":\"value4\"}],[{\"a\":\"value5\"}]]"));
            Assert.That(jp.GetJson("$[0]"u8).ToString(), Is.EqualTo("[{\"a\":\"value1\"},{\"a\":\"value2\"}]"));
            Assert.That(jp.GetJson("$[0][0]"u8).ToString(), Is.EqualTo("{\"a\":\"value1\"}"));
            Assert.That(jp.GetString("$[0][0].a"u8), Is.EqualTo("value1"));
            Assert.That(jp.GetJson("$[0][1]"u8).ToString(), Is.EqualTo("{\"a\":\"value2\"}"));
            Assert.That(jp.GetString("$[0][1].a"u8), Is.EqualTo("value2"));
            Assert.That(jp.GetJson("$[1]"u8).ToString(), Is.EqualTo("[{\"a\":\"value3\"},{\"a\":\"value4\"}]"));
            Assert.That(jp.GetJson("$[1][0]"u8).ToString(), Is.EqualTo("{\"a\":\"value3\"}"));
            Assert.That(jp.GetString("$[1][0].a"u8), Is.EqualTo("value3"));
            Assert.That(jp.GetJson("$[1][1]"u8).ToString(), Is.EqualTo("{\"a\":\"value4\"}"));
            Assert.That(jp.GetString("$[1][1].a"u8), Is.EqualTo("value4"));
            Assert.That(jp.GetJson("$[2]"u8).ToString(), Is.EqualTo("[{\"a\":\"value5\"}]"));
            Assert.That(jp.GetJson("$[2][0]"u8).ToString(), Is.EqualTo("{\"a\":\"value5\"}"));
            Assert.That(jp.GetString("$[2][0].a"u8), Is.EqualTo("value5"));

            Assert.That(jp.ToString("J"), Is.EqualTo("[[{\"a\":\"value1\"},{\"a\":\"value2\"}],[{\"a\":\"value3\"},{\"a\":\"value4\"}],[{\"a\":\"value5\"}]]"));
        }

        [Test]
        public void Insert_TwoDimension()
        {
            JsonPatch jp = new();

            jp.Append("$[0]"u8, "value1");

            Assert.That(jp.GetJson("$[0]"u8).ToString(), Is.EqualTo("[\"value1\"]"));

            jp.Append("$[0]"u8, "value2");

            Assert.That(jp.GetJson("$[0]"u8).ToString(), Is.EqualTo("[\"value1\",\"value2\"]"));

            jp.Append("$[1]"u8, "value3");

            Assert.That(jp.GetJson("$[1]"u8).ToString(), Is.EqualTo("[\"value3\"]"));

            jp.Append("$[1]"u8, "value4");

            Assert.That(jp.GetJson("$[1]"u8).ToString(), Is.EqualTo("[\"value3\",\"value4\"]"));

            jp.Append("$"u8, "[\"value5\"]"u8);

            Assert.That(jp.GetJson("$"u8).ToString(), Is.EqualTo("[[\"value1\",\"value2\"],[\"value3\",\"value4\"],[\"value5\"]]"));
            Assert.That(jp.GetJson("$[0]"u8).ToString(), Is.EqualTo("[\"value1\",\"value2\"]"));
            Assert.That(jp.GetString("$[0][0]"u8), Is.EqualTo("value1"));
            Assert.That(jp.GetString("$[0][1]"u8), Is.EqualTo("value2"));
            Assert.That(jp.GetJson("$[1]"u8).ToString(), Is.EqualTo("[\"value3\",\"value4\"]"));
            Assert.That(jp.GetString("$[1][0]"u8), Is.EqualTo("value3"));
            Assert.That(jp.GetString("$[1][1]"u8), Is.EqualTo("value4"));
            Assert.That(jp.GetJson("$[2]"u8).ToString(), Is.EqualTo("[\"value5\"]"));
            Assert.That(jp.GetString("$[2][0]"u8), Is.EqualTo("value5"));

            Assert.That(jp.ToString("J"), Is.EqualTo("[[\"value1\",\"value2\"],[\"value3\",\"value4\"],[\"value5\"]]"));
        }

        [Test]
        public void RootAndInsert_TwoLevelTwoLevel_WithProperty()
        {
            JsonPatch jp = new("{\"x\":{\"y\":[{\"z\":{\"a\":[{\"b\":\"value1\"},{\"b\":\"value2\"}]}},{\"z\":{\"a\":[{\"b\":\"value3\"},{\"b\":\"value4\"}]}}]}}"u8.ToArray());

            Assert.That(jp.GetJson("$.x"u8).ToString(), Is.EqualTo("{\"y\":[{\"z\":{\"a\":[{\"b\":\"value1\"},{\"b\":\"value2\"}]}},{\"z\":{\"a\":[{\"b\":\"value3\"},{\"b\":\"value4\"}]}}]}"));
            Assert.That(jp.GetJson("$.x.y"u8).ToString(), Is.EqualTo("[{\"z\":{\"a\":[{\"b\":\"value1\"},{\"b\":\"value2\"}]}},{\"z\":{\"a\":[{\"b\":\"value3\"},{\"b\":\"value4\"}]}}]"));
            Assert.That(jp.GetJson("$.x.y[0]"u8).ToString(), Is.EqualTo("{\"z\":{\"a\":[{\"b\":\"value1\"},{\"b\":\"value2\"}]}}"));
            Assert.That(jp.GetJson("$.x.y[0].z"u8).ToString(), Is.EqualTo("{\"a\":[{\"b\":\"value1\"},{\"b\":\"value2\"}]}"));
            Assert.That(jp.GetJson("$.x.y[0].z.a"u8).ToString(), Is.EqualTo("[{\"b\":\"value1\"},{\"b\":\"value2\"}]"));
            Assert.That(jp.GetJson("$.x.y[0].z.a[0]"u8).ToString(), Is.EqualTo("{\"b\":\"value1\"}"));
            Assert.That(jp.GetString("$.x.y[0].z.a[0].b"u8), Is.EqualTo("value1"));
            Assert.That(jp.GetJson("$.x.y[0].z.a[1]"u8).ToString(), Is.EqualTo("{\"b\":\"value2\"}"));
            Assert.That(jp.GetString("$.x.y[0].z.a[1].b"u8), Is.EqualTo("value2"));
            Assert.That(jp.GetJson("$.x.y[1]"u8).ToString(), Is.EqualTo("{\"z\":{\"a\":[{\"b\":\"value3\"},{\"b\":\"value4\"}]}}"));
            Assert.That(jp.GetJson("$.x.y[1].z"u8).ToString(), Is.EqualTo("{\"a\":[{\"b\":\"value3\"},{\"b\":\"value4\"}]}"));
            Assert.That(jp.GetJson("$.x.y[1].z.a"u8).ToString(), Is.EqualTo("[{\"b\":\"value3\"},{\"b\":\"value4\"}]"));
            Assert.That(jp.GetJson("$.x.y[1].z.a[0]"u8).ToString(), Is.EqualTo("{\"b\":\"value3\"}"));
            Assert.That(jp.GetString("$.x.y[1].z.a[0].b"u8), Is.EqualTo("value3"));
            Assert.That(jp.GetJson("$.x.y[1].z.a[1]"u8).ToString(), Is.EqualTo("{\"b\":\"value4\"}"));
            Assert.That(jp.GetString("$.x.y[1].z.a[1].b"u8), Is.EqualTo("value4"));

            jp.Append("$.x.y[0].z.a"u8, "{\"b\":\"value5\"}"u8);

            Assert.That(jp.GetJson("$.x.y[0]"u8).ToString(), Is.EqualTo("{\"z\":{\"a\":[{\"b\":\"value1\"},{\"b\":\"value2\"},{\"b\":\"value5\"}]}}"));

            jp.Append("$.x.y[0].z.a"u8, "{\"b\":\"value6\"}"u8);

            Assert.That(jp.GetJson("$.x.y[0]"u8).ToString(), Is.EqualTo("{\"z\":{\"a\":[{\"b\":\"value1\"},{\"b\":\"value2\"},{\"b\":\"value5\"},{\"b\":\"value6\"}]}}"));

            jp.Append("$.x.y[1].z.a"u8, "{\"b\":\"value7\"}"u8);

            Assert.That(jp.GetJson("$.x.y[1]"u8).ToString(), Is.EqualTo("{\"z\":{\"a\":[{\"b\":\"value3\"},{\"b\":\"value4\"},{\"b\":\"value7\"}]}}"));

            jp.Append("$.x.y[1].z.a"u8, "{\"b\":\"value8\"}"u8);

            Assert.That(jp.GetJson("$.x.y[1]"u8).ToString(), Is.EqualTo("{\"z\":{\"a\":[{\"b\":\"value3\"},{\"b\":\"value4\"},{\"b\":\"value7\"},{\"b\":\"value8\"}]}}"));

            jp.Append("$.x.y"u8, "{\"z\":{\"a\":[{\"b\":\"value9\"}]}}"u8);

            Assert.That(jp.GetJson("$.x"u8).ToString(), Is.EqualTo("{\"y\":[{\"z\":{\"a\":[{\"b\":\"value1\"},{\"b\":\"value2\"}]}},{\"z\":{\"a\":[{\"b\":\"value3\"},{\"b\":\"value4\"}]}}]}"));
            Assert.That(jp.GetJson("$.x.y"u8).ToString(), Is.EqualTo("[{\"z\":{\"a\":[{\"b\":\"value1\"},{\"b\":\"value2\"},{\"b\":\"value5\"},{\"b\":\"value6\"}]}},{\"z\":{\"a\":[{\"b\":\"value3\"},{\"b\":\"value4\"},{\"b\":\"value7\"},{\"b\":\"value8\"}]}},{\"z\":{\"a\":[{\"b\":\"value9\"}]}}]"));
            Assert.That(jp.GetJson("$.x.y[0]"u8).ToString(), Is.EqualTo("{\"z\":{\"a\":[{\"b\":\"value1\"},{\"b\":\"value2\"},{\"b\":\"value5\"},{\"b\":\"value6\"}]}}"));
            Assert.That(jp.GetJson("$.x.y[0].z"u8).ToString(), Is.EqualTo("{\"a\":[{\"b\":\"value1\"},{\"b\":\"value2\"},{\"b\":\"value5\"},{\"b\":\"value6\"}]}"));
            Assert.That(jp.GetJson("$.x.y[0].z.a"u8).ToString(), Is.EqualTo("[{\"b\":\"value1\"},{\"b\":\"value2\"},{\"b\":\"value5\"},{\"b\":\"value6\"}]"));
            Assert.That(jp.GetJson("$.x.y[0].z.a[0]"u8).ToString(), Is.EqualTo("{\"b\":\"value1\"}"));
            Assert.That(jp.GetString("$.x.y[0].z.a[0].b"u8), Is.EqualTo("value1"));
            Assert.That(jp.GetJson("$.x.y[0].z.a[1]"u8).ToString(), Is.EqualTo("{\"b\":\"value2\"}"));
            Assert.That(jp.GetString("$.x.y[0].z.a[1].b"u8), Is.EqualTo("value2"));
            Assert.That(jp.GetJson("$.x.y[0].z.a[2]"u8).ToString(), Is.EqualTo("{\"b\":\"value5\"}"));
            Assert.That(jp.GetString("$.x.y[0].z.a[2].b"u8), Is.EqualTo("value5"));
            Assert.That(jp.GetJson("$.x.y[0].z.a[3]"u8).ToString(), Is.EqualTo("{\"b\":\"value6\"}"));
            Assert.That(jp.GetString("$.x.y[0].z.a[3].b"u8), Is.EqualTo("value6"));
            Assert.That(jp.GetJson("$.x.y[1]"u8).ToString(), Is.EqualTo("{\"z\":{\"a\":[{\"b\":\"value3\"},{\"b\":\"value4\"},{\"b\":\"value7\"},{\"b\":\"value8\"}]}}"));
            Assert.That(jp.GetJson("$.x.y[1].z"u8).ToString(), Is.EqualTo("{\"a\":[{\"b\":\"value3\"},{\"b\":\"value4\"},{\"b\":\"value7\"},{\"b\":\"value8\"}]}"));
            Assert.That(jp.GetJson("$.x.y[1].z.a"u8).ToString(), Is.EqualTo("[{\"b\":\"value3\"},{\"b\":\"value4\"},{\"b\":\"value7\"},{\"b\":\"value8\"}]"));
            Assert.That(jp.GetJson("$.x.y[1].z.a[0]"u8).ToString(), Is.EqualTo("{\"b\":\"value3\"}"));
            Assert.That(jp.GetString("$.x.y[1].z.a[0].b"u8), Is.EqualTo("value3"));
            Assert.That(jp.GetJson("$.x.y[1].z.a[1]"u8).ToString(), Is.EqualTo("{\"b\":\"value4\"}"));
            Assert.That(jp.GetString("$.x.y[1].z.a[1].b"u8), Is.EqualTo("value4"));
            Assert.That(jp.GetJson("$.x.y[1].z.a[2]"u8).ToString(), Is.EqualTo("{\"b\":\"value7\"}"));
            Assert.That(jp.GetString("$.x.y[1].z.a[2].b"u8), Is.EqualTo("value7"));
            Assert.That(jp.GetJson("$.x.y[1].z.a[3]"u8).ToString(), Is.EqualTo("{\"b\":\"value8\"}"));
            Assert.That(jp.GetString("$.x.y[1].z.a[3].b"u8), Is.EqualTo("value8"));
            Assert.That(jp.GetJson("$.x.y[2]"u8).ToString(), Is.EqualTo("{\"z\":{\"a\":[{\"b\":\"value9\"}]}}"));
            Assert.That(jp.GetJson("$.x.y[2].z"u8).ToString(), Is.EqualTo("{\"a\":[{\"b\":\"value9\"}]}"));
            Assert.That(jp.GetJson("$.x.y[2].z.a"u8).ToString(), Is.EqualTo("[{\"b\":\"value9\"}]"));
            Assert.That(jp.GetJson("$.x.y[2].z.a[0]"u8).ToString(), Is.EqualTo("{\"b\":\"value9\"}"));
            Assert.That(jp.GetString("$.x.y[2].z.a[0].b"u8), Is.EqualTo("value9"));

            Assert.That(jp.ToString("J"), Is.EqualTo("{\"x\":{\"y\":[{\"z\":{\"a\":[{\"b\":\"value1\"},{\"b\":\"value2\"},{\"b\":\"value5\"},{\"b\":\"value6\"}]}},{\"z\":{\"a\":[{\"b\":\"value3\"},{\"b\":\"value4\"},{\"b\":\"value7\"},{\"b\":\"value8\"}]}},{\"z\":{\"a\":[{\"b\":\"value9\"}]}}]}}"));
        }

        [Test]
        public void RootAndInsert_TwoLevelTwoLevel()
        {
            JsonPatch jp = new("{\"x\":{\"y\":[{\"z\":{\"a\":[\"value1\",\"value2\"]}},{\"z\":{\"a\":[\"value3\",\"value4\"]}}]}}"u8.ToArray());

            Assert.That(jp.GetJson("$.x"u8).ToString(), Is.EqualTo("{\"y\":[{\"z\":{\"a\":[\"value1\",\"value2\"]}},{\"z\":{\"a\":[\"value3\",\"value4\"]}}]}"));
            Assert.That(jp.GetJson("$.x.y"u8).ToString(), Is.EqualTo("[{\"z\":{\"a\":[\"value1\",\"value2\"]}},{\"z\":{\"a\":[\"value3\",\"value4\"]}}]"));
            Assert.That(jp.GetJson("$.x.y[0]"u8).ToString(), Is.EqualTo("{\"z\":{\"a\":[\"value1\",\"value2\"]}}"));
            Assert.That(jp.GetJson("$.x.y[0].z"u8).ToString(), Is.EqualTo("{\"a\":[\"value1\",\"value2\"]}"));
            Assert.That(jp.GetJson("$.x.y[0].z.a"u8).ToString(), Is.EqualTo("[\"value1\",\"value2\"]"));
            Assert.That(jp.GetString("$.x.y[0].z.a[0]"u8), Is.EqualTo("value1"));
            Assert.That(jp.GetString("$.x.y[0].z.a[1]"u8), Is.EqualTo("value2"));
            Assert.That(jp.GetJson("$.x.y[1]"u8).ToString(), Is.EqualTo("{\"z\":{\"a\":[\"value3\",\"value4\"]}}"));
            Assert.That(jp.GetJson("$.x.y[1].z"u8).ToString(), Is.EqualTo("{\"a\":[\"value3\",\"value4\"]}"));
            Assert.That(jp.GetJson("$.x.y[1].z.a"u8).ToString(), Is.EqualTo("[\"value3\",\"value4\"]"));
            Assert.That(jp.GetString("$.x.y[1].z.a[0]"u8), Is.EqualTo("value3"));
            Assert.That(jp.GetString("$.x.y[1].z.a[1]"u8), Is.EqualTo("value4"));

            jp.Append("$.x.y[0].z.a"u8, "value5");

            Assert.That(jp.GetJson("$.x.y[0]"u8).ToString(), Is.EqualTo("{\"z\":{\"a\":[\"value1\",\"value2\",\"value5\"]}}"));

            jp.Append("$.x.y[0].z.a"u8, "value6");

            Assert.That(jp.GetJson("$.x.y[0]"u8).ToString(), Is.EqualTo("{\"z\":{\"a\":[\"value1\",\"value2\",\"value5\",\"value6\"]}}"));

            jp.Append("$.x.y[1].z.a"u8, "value7");

            Assert.That(jp.GetJson("$.x.y[1]"u8).ToString(), Is.EqualTo("{\"z\":{\"a\":[\"value3\",\"value4\",\"value7\"]}}"));

            jp.Append("$.x.y[1].z.a"u8, "value8");

            Assert.That(jp.GetJson("$.x.y[1]"u8).ToString(), Is.EqualTo("{\"z\":{\"a\":[\"value3\",\"value4\",\"value7\",\"value8\"]}}"));

            jp.Append("$.x.y"u8, "{\"z\":{\"a\":[\"value9\"]}}"u8);

            Assert.That(jp.GetJson("$.x"u8).ToString(), Is.EqualTo("{\"y\":[{\"z\":{\"a\":[\"value1\",\"value2\"]}},{\"z\":{\"a\":[\"value3\",\"value4\"]}}]}"));
            Assert.That(jp.GetJson("$.x.y"u8).ToString(), Is.EqualTo("[{\"z\":{\"a\":[\"value1\",\"value2\",\"value5\",\"value6\"]}},{\"z\":{\"a\":[\"value3\",\"value4\",\"value7\",\"value8\"]}},{\"z\":{\"a\":[\"value9\"]}}]"));
            Assert.That(jp.GetJson("$.x.y[0]"u8).ToString(), Is.EqualTo("{\"z\":{\"a\":[\"value1\",\"value2\",\"value5\",\"value6\"]}}"));
            Assert.That(jp.GetJson("$.x.y[0].z"u8).ToString(), Is.EqualTo("{\"a\":[\"value1\",\"value2\",\"value5\",\"value6\"]}"));
            Assert.That(jp.GetJson("$.x.y[0].z.a"u8).ToString(), Is.EqualTo("[\"value1\",\"value2\",\"value5\",\"value6\"]"));
            Assert.That(jp.GetString("$.x.y[0].z.a[0]"u8), Is.EqualTo("value1"));
            Assert.That(jp.GetString("$.x.y[0].z.a[1]"u8), Is.EqualTo("value2"));
            Assert.That(jp.GetString("$.x.y[0].z.a[2]"u8), Is.EqualTo("value5"));
            Assert.That(jp.GetString("$.x.y[0].z.a[3]"u8), Is.EqualTo("value6"));
            Assert.That(jp.GetJson("$.x.y[1]"u8).ToString(), Is.EqualTo("{\"z\":{\"a\":[\"value3\",\"value4\",\"value7\",\"value8\"]}}"));
            Assert.That(jp.GetJson("$.x.y[1].z"u8).ToString(), Is.EqualTo("{\"a\":[\"value3\",\"value4\",\"value7\",\"value8\"]}"));
            Assert.That(jp.GetJson("$.x.y[1].z.a"u8).ToString(), Is.EqualTo("[\"value3\",\"value4\",\"value7\",\"value8\"]"));
            Assert.That(jp.GetString("$.x.y[1].z.a[0]"u8), Is.EqualTo("value3"));
            Assert.That(jp.GetString("$.x.y[1].z.a[1]"u8), Is.EqualTo("value4"));
            Assert.That(jp.GetString("$.x.y[1].z.a[2]"u8), Is.EqualTo("value7"));
            Assert.That(jp.GetString("$.x.y[1].z.a[3]"u8), Is.EqualTo("value8"));
            Assert.That(jp.GetJson("$.x.y[2]"u8).ToString(), Is.EqualTo("{\"z\":{\"a\":[\"value9\"]}}"));
            Assert.That(jp.GetJson("$.x.y[2].z"u8).ToString(), Is.EqualTo("{\"a\":[\"value9\"]}"));
            Assert.That(jp.GetJson("$.x.y[2].z.a"u8).ToString(), Is.EqualTo("[\"value9\"]"));
            Assert.That(jp.GetString("$.x.y[2].z.a[0]"u8), Is.EqualTo("value9"));

            Assert.That(jp.ToString("J"), Is.EqualTo("{\"x\":{\"y\":[{\"z\":{\"a\":[\"value1\",\"value2\",\"value5\",\"value6\"]}},{\"z\":{\"a\":[\"value3\",\"value4\",\"value7\",\"value8\"]}},{\"z\":{\"a\":[\"value9\"]}}]}}"));
        }

        [Test]
        public void Insert_TwoLevelTwoLevel_WithProperty()
        {
            JsonPatch jp = new();

            jp.Append("$.x.y[0].z.a"u8, "{\"b\":\"value1\"}"u8);

            Assert.That(jp.GetJson("$.x"u8).ToString(), Is.EqualTo("{\"y\":[{\"z\":{\"a\":[{\"b\":\"value1\"}]}}]}"));

            jp.Append("$.x.y[0].z.a"u8, "{\"b\":\"value2\"}"u8);

            Assert.That(jp.GetJson("$.x"u8).ToString(), Is.EqualTo("{\"y\":[{\"z\":{\"a\":[{\"b\":\"value1\"},{\"b\":\"value2\"}]}}]}"));

            jp.Append("$.x.y[1].z.a"u8, "{\"b\":\"value3\"}"u8);

            Assert.That(jp.GetJson("$.x"u8).ToString(), Is.EqualTo("{\"y\":[{\"z\":{\"a\":[{\"b\":\"value1\"},{\"b\":\"value2\"}]}},{\"z\":{\"a\":[{\"b\":\"value3\"}]}}]}"));

            jp.Append("$.x.y[1].z.a"u8, "{\"b\":\"value4\"}"u8);

            Assert.That(jp.GetJson("$.x"u8).ToString(), Is.EqualTo("{\"y\":[{\"z\":{\"a\":[{\"b\":\"value1\"},{\"b\":\"value2\"}]}},{\"z\":{\"a\":[{\"b\":\"value3\"},{\"b\":\"value4\"}]}}]}"));

            jp.Append("$.x.y"u8, "{\"z\":{\"a\":[{\"b\":\"value5\"}]}}"u8);

            Assert.That(jp.GetJson("$.x"u8).ToString(), Is.EqualTo("{\"y\":[{\"z\":{\"a\":[{\"b\":\"value1\"},{\"b\":\"value2\"}]}},{\"z\":{\"a\":[{\"b\":\"value3\"},{\"b\":\"value4\"}]}},{\"z\":{\"a\":[{\"b\":\"value5\"}]}}]}"));
            Assert.That(jp.GetJson("$.x.y"u8).ToString(), Is.EqualTo("[{\"z\":{\"a\":[{\"b\":\"value1\"},{\"b\":\"value2\"}]}},{\"z\":{\"a\":[{\"b\":\"value3\"},{\"b\":\"value4\"}]}},{\"z\":{\"a\":[{\"b\":\"value5\"}]}}]"));
            Assert.That(jp.GetJson("$.x.y[0]"u8).ToString(), Is.EqualTo("{\"z\":{\"a\":[{\"b\":\"value1\"},{\"b\":\"value2\"}]}}"));
            Assert.That(jp.GetJson("$.x.y[0].z"u8).ToString(), Is.EqualTo("{\"a\":[{\"b\":\"value1\"},{\"b\":\"value2\"}]}"));
            Assert.That(jp.GetJson("$.x.y[0].z.a"u8).ToString(), Is.EqualTo("[{\"b\":\"value1\"},{\"b\":\"value2\"}]"));
            Assert.That(jp.GetJson("$.x.y[0].z.a[0]"u8).ToString(), Is.EqualTo("{\"b\":\"value1\"}"));
            Assert.That(jp.GetString("$.x.y[0].z.a[0].b"u8), Is.EqualTo("value1"));
            Assert.That(jp.GetJson("$.x.y[0].z.a[1]"u8).ToString(), Is.EqualTo("{\"b\":\"value2\"}"));
            Assert.That(jp.GetString("$.x.y[0].z.a[1].b"u8), Is.EqualTo("value2"));
            Assert.That(jp.GetJson("$.x.y[1]"u8).ToString(), Is.EqualTo("{\"z\":{\"a\":[{\"b\":\"value3\"},{\"b\":\"value4\"}]}}"));
            Assert.That(jp.GetJson("$.x.y[1].z"u8).ToString(), Is.EqualTo("{\"a\":[{\"b\":\"value3\"},{\"b\":\"value4\"}]}"));
            Assert.That(jp.GetJson("$.x.y[1].z.a"u8).ToString(), Is.EqualTo("[{\"b\":\"value3\"},{\"b\":\"value4\"}]"));
            Assert.That(jp.GetJson("$.x.y[1].z.a[0]"u8).ToString(), Is.EqualTo("{\"b\":\"value3\"}"));
            Assert.That(jp.GetString("$.x.y[1].z.a[0].b"u8), Is.EqualTo("value3"));
            Assert.That(jp.GetJson("$.x.y[1].z.a[1]"u8).ToString(), Is.EqualTo("{\"b\":\"value4\"}"));
            Assert.That(jp.GetString("$.x.y[1].z.a[1].b"u8), Is.EqualTo("value4"));
            Assert.That(jp.GetJson("$.x.y[2]"u8).ToString(), Is.EqualTo("{\"z\":{\"a\":[{\"b\":\"value5\"}]}}"));
            Assert.That(jp.GetJson("$.x.y[2].z"u8).ToString(), Is.EqualTo("{\"a\":[{\"b\":\"value5\"}]}"));
            Assert.That(jp.GetJson("$.x.y[2].z.a"u8).ToString(), Is.EqualTo("[{\"b\":\"value5\"}]"));
            Assert.That(jp.GetJson("$.x.y[2].z.a[0]"u8).ToString(), Is.EqualTo("{\"b\":\"value5\"}"));
            Assert.That(jp.GetString("$.x.y[2].z.a[0].b"u8), Is.EqualTo("value5"));

            Assert.That(jp.ToString("J"), Is.EqualTo("{\"x\":{\"y\":[{\"z\":{\"a\":[{\"b\":\"value1\"},{\"b\":\"value2\"}]}},{\"z\":{\"a\":[{\"b\":\"value3\"},{\"b\":\"value4\"}]}},{\"z\":{\"a\":[{\"b\":\"value5\"}]}}]}}"));
        }

        [Test]
        public void Insert_TwoLevelTwoLevel()
        {
            JsonPatch jp = new();

            jp.Append("$.x.y[0].z.a"u8, "value1");

            Assert.That(jp.GetJson("$.x"u8).ToString(), Is.EqualTo("{\"y\":[{\"z\":{\"a\":[\"value1\"]}}]}"));

            jp.Append("$.x.y[0].z.a"u8, "value2");

            Assert.That(jp.GetJson("$.x"u8).ToString(), Is.EqualTo("{\"y\":[{\"z\":{\"a\":[\"value1\",\"value2\"]}}]}"));

            jp.Append("$.x.y[1].z.a"u8, "value3");

            Assert.That(jp.GetJson("$.x"u8).ToString(), Is.EqualTo("{\"y\":[{\"z\":{\"a\":[\"value1\",\"value2\"]}},{\"z\":{\"a\":[\"value3\"]}}]}"));

            jp.Append("$.x.y[1].z.a"u8, "value4");

            Assert.That(jp.GetJson("$.x"u8).ToString(), Is.EqualTo("{\"y\":[{\"z\":{\"a\":[\"value1\",\"value2\"]}},{\"z\":{\"a\":[\"value3\",\"value4\"]}}]}"));

            jp.Append("$.x.y"u8, "{\"z\":{\"a\":[\"value5\"]}}"u8);

            Assert.That(jp.GetJson("$.x"u8).ToString(), Is.EqualTo("{\"y\":[{\"z\":{\"a\":[\"value1\",\"value2\"]}},{\"z\":{\"a\":[\"value3\",\"value4\"]}},{\"z\":{\"a\":[\"value5\"]}}]}"));
            Assert.That(jp.GetJson("$.x.y"u8).ToString(), Is.EqualTo("[{\"z\":{\"a\":[\"value1\",\"value2\"]}},{\"z\":{\"a\":[\"value3\",\"value4\"]}},{\"z\":{\"a\":[\"value5\"]}}]"));
            Assert.That(jp.GetJson("$.x.y[0]"u8).ToString(), Is.EqualTo("{\"z\":{\"a\":[\"value1\",\"value2\"]}}"));
            Assert.That(jp.GetJson("$.x.y[0].z"u8).ToString(), Is.EqualTo("{\"a\":[\"value1\",\"value2\"]}"));
            Assert.That(jp.GetJson("$.x.y[0].z.a"u8).ToString(), Is.EqualTo("[\"value1\",\"value2\"]"));
            Assert.That(jp.GetString("$.x.y[0].z.a[0]"u8), Is.EqualTo("value1"));
            Assert.That(jp.GetString("$.x.y[0].z.a[1]"u8), Is.EqualTo("value2"));
            Assert.That(jp.GetJson("$.x.y[1]"u8).ToString(), Is.EqualTo("{\"z\":{\"a\":[\"value3\",\"value4\"]}}"));
            Assert.That(jp.GetJson("$.x.y[1].z"u8).ToString(), Is.EqualTo("{\"a\":[\"value3\",\"value4\"]}"));
            Assert.That(jp.GetJson("$.x.y[1].z.a"u8).ToString(), Is.EqualTo("[\"value3\",\"value4\"]"));
            Assert.That(jp.GetString("$.x.y[1].z.a[0]"u8), Is.EqualTo("value3"));
            Assert.That(jp.GetString("$.x.y[1].z.a[1]"u8), Is.EqualTo("value4"));
            Assert.That(jp.GetJson("$.x.y[2]"u8).ToString(), Is.EqualTo("{\"z\":{\"a\":[\"value5\"]}}"));
            Assert.That(jp.GetJson("$.x.y[2].z"u8).ToString(), Is.EqualTo("{\"a\":[\"value5\"]}"));
            Assert.That(jp.GetJson("$.x.y[2].z.a"u8).ToString(), Is.EqualTo("[\"value5\"]"));
            Assert.That(jp.GetString("$.x.y[2].z.a[0]"u8), Is.EqualTo("value5"));

            Assert.That(jp.ToString("J"), Is.EqualTo("{\"x\":{\"y\":[{\"z\":{\"a\":[\"value1\",\"value2\"]}},{\"z\":{\"a\":[\"value3\",\"value4\"]}},{\"z\":{\"a\":[\"value5\"]}}]}}"));
        }

        [Test]
        public void RootAndInsert_TwoLevel_WithProperty()
        {
            JsonPatch jp = new("{\"x\":{\"y\":[{\"a\":\"value1\"},{\"a\":\"value2\"}]}}"u8.ToArray());

            Assert.That(jp.GetJson("$.x"u8).ToString(), Is.EqualTo("{\"y\":[{\"a\":\"value1\"},{\"a\":\"value2\"}]}"));
            Assert.That(jp.GetJson("$.x.y"u8).ToString(), Is.EqualTo("[{\"a\":\"value1\"},{\"a\":\"value2\"}]"));
            Assert.That(jp.GetJson("$.x.y[0]"u8).ToString(), Is.EqualTo("{\"a\":\"value1\"}"));
            Assert.That(jp.GetString("$.x.y[0].a"u8), Is.EqualTo("value1"));
            Assert.That(jp.GetJson("$.x.y[1]"u8).ToString(), Is.EqualTo("{\"a\":\"value2\"}"));
            Assert.That(jp.GetString("$.x.y[1].a"u8), Is.EqualTo("value2"));

            jp.Append("$.x.y"u8, "{\"a\":\"value3\"}"u8);

            Assert.That(jp.GetJson("$.x.y"u8).ToString(), Is.EqualTo("[{\"a\":\"value1\"},{\"a\":\"value2\"},{\"a\":\"value3\"}]"));

            jp.Append("$.x.y"u8, "{\"a\":\"value4\"}"u8);

            Assert.That(jp.GetJson("$.x"u8).ToString(), Is.EqualTo("{\"y\":[{\"a\":\"value1\"},{\"a\":\"value2\"}]}"));
            Assert.That(jp.GetJson("$.x.y"u8).ToString(), Is.EqualTo("[{\"a\":\"value1\"},{\"a\":\"value2\"},{\"a\":\"value3\"},{\"a\":\"value4\"}]"));
            Assert.That(jp.GetJson("$.x.y[0]"u8).ToString(), Is.EqualTo("{\"a\":\"value1\"}"));
            Assert.That(jp.GetString("$.x.y[0].a"u8), Is.EqualTo("value1"));
            Assert.That(jp.GetJson("$.x.y[1]"u8).ToString(), Is.EqualTo("{\"a\":\"value2\"}"));
            Assert.That(jp.GetString("$.x.y[1].a"u8), Is.EqualTo("value2"));
            Assert.That(jp.GetJson("$.x.y[2]"u8).ToString(), Is.EqualTo("{\"a\":\"value3\"}"));
            Assert.That(jp.GetString("$.x.y[2].a"u8), Is.EqualTo("value3"));
            Assert.That(jp.GetJson("$.x.y[3]"u8).ToString(), Is.EqualTo("{\"a\":\"value4\"}"));
            Assert.That(jp.GetString("$.x.y[3].a"u8), Is.EqualTo("value4"));

            Assert.That(jp.ToString("J"), Is.EqualTo("{\"x\":{\"y\":[{\"a\":\"value1\"},{\"a\":\"value2\"},{\"a\":\"value3\"},{\"a\":\"value4\"}]}}"));
        }

        [Test]
        public void RootAndInsert_TwoLevel()
        {
            JsonPatch jp = new("{\"x\":{\"y\":[\"value1\",\"value2\"]}}"u8.ToArray());

            Assert.That(jp.GetJson("$.x"u8).ToString(), Is.EqualTo("{\"y\":[\"value1\",\"value2\"]}"));
            Assert.That(jp.GetJson("$.x.y"u8).ToString(), Is.EqualTo("[\"value1\",\"value2\"]"));
            Assert.That(jp.GetString("$.x.y[0]"u8), Is.EqualTo("value1"));
            Assert.That(jp.GetString("$.x.y[1]"u8), Is.EqualTo("value2"));

            jp.Append("$.x.y"u8, "value3");

            Assert.That(jp.GetJson("$.x.y"u8).ToString(), Is.EqualTo("[\"value1\",\"value2\",\"value3\"]"));

            jp.Append("$.x.y"u8, "value4");

            Assert.That(jp.GetJson("$.x"u8).ToString(), Is.EqualTo("{\"y\":[\"value1\",\"value2\"]}"));
            Assert.That(jp.GetJson("$.x.y"u8).ToString(), Is.EqualTo("[\"value1\",\"value2\",\"value3\",\"value4\"]"));
            Assert.That(jp.GetString("$.x.y[0]"u8), Is.EqualTo("value1"));
            Assert.That(jp.GetString("$.x.y[1]"u8), Is.EqualTo("value2"));
            Assert.That(jp.GetString("$.x.y[2]"u8), Is.EqualTo("value3"));
            Assert.That(jp.GetString("$.x.y[3]"u8), Is.EqualTo("value4"));

            Assert.That(jp.ToString("J"), Is.EqualTo("{\"x\":{\"y\":[\"value1\",\"value2\",\"value3\",\"value4\"]}}"));
        }

        [Test]
        public void Insert_TwoLevel_WithProperty()
        {
            JsonPatch jp = new();

            jp.Append("$.x.y"u8, "{\"a\":\"value1\"}"u8);

            Assert.That(jp.GetJson("$.x"u8).ToString(), Is.EqualTo("{\"y\":[{\"a\":\"value1\"}]}"));

            jp.Append("$.x.y"u8, "{\"a\":\"value2\"}"u8);

            Assert.That(jp.GetJson("$.x"u8).ToString(), Is.EqualTo("{\"y\":[{\"a\":\"value1\"},{\"a\":\"value2\"}]}"));
            Assert.That(jp.GetJson("$.x.y"u8).ToString(), Is.EqualTo("[{\"a\":\"value1\"},{\"a\":\"value2\"}]"));
            Assert.That(jp.GetJson("$.x.y[0]"u8).ToString(), Is.EqualTo("{\"a\":\"value1\"}"));
            Assert.That(jp.GetString("$.x.y[0].a"u8), Is.EqualTo("value1"));
            Assert.That(jp.GetJson("$.x.y[1]"u8).ToString(), Is.EqualTo("{\"a\":\"value2\"}"));
            Assert.That(jp.GetString("$.x.y[1].a"u8), Is.EqualTo("value2"));

            Assert.That(jp.ToString("J"), Is.EqualTo("{\"x\":{\"y\":[{\"a\":\"value1\"},{\"a\":\"value2\"}]}}"));
        }

        [Test]
        public void Insert_TwoLevel()
        {
            JsonPatch jp = new();

            jp.Append("$.x.y"u8, "value1");

            Assert.That(jp.GetJson("$.x"u8).ToString(), Is.EqualTo("{\"y\":[\"value1\"]}"));

            jp.Append("$.x.y"u8, "value2");

            Assert.That(jp.GetJson("$.x"u8).ToString(), Is.EqualTo("{\"y\":[\"value1\",\"value2\"]}"));
            Assert.That(jp.GetJson("$.x.y"u8).ToString(), Is.EqualTo("[\"value1\",\"value2\"]"));
            Assert.That(jp.GetString("$.x.y[0]"u8), Is.EqualTo("value1"));
            Assert.That(jp.GetString("$.x.y[1]"u8), Is.EqualTo("value2"));

            Assert.That(jp.ToString("J"), Is.EqualTo("{\"x\":{\"y\":[\"value1\",\"value2\"]}}"));
        }

        [Test]
        public void RootAndInsert_OneLevelTwoLevel_WithProperty()
        {
            JsonPatch jp = new("{\"x\":[{\"y\":{\"z\":[{\"a\":\"value1\"},{\"a\":\"value2\"}]}},{\"y\":{\"z\":[{\"a\":\"value3\"},{\"a\":\"value4\"}]}}]}"u8.ToArray());

            Assert.That(jp.GetJson("$.x"u8).ToString(), Is.EqualTo("[{\"y\":{\"z\":[{\"a\":\"value1\"},{\"a\":\"value2\"}]}},{\"y\":{\"z\":[{\"a\":\"value3\"},{\"a\":\"value4\"}]}}]"));
            Assert.That(jp.GetJson("$.x[0]"u8).ToString(), Is.EqualTo("{\"y\":{\"z\":[{\"a\":\"value1\"},{\"a\":\"value2\"}]}}"));
            Assert.That(jp.GetJson("$.x[0].y"u8).ToString(), Is.EqualTo("{\"z\":[{\"a\":\"value1\"},{\"a\":\"value2\"}]}"));
            Assert.That(jp.GetJson("$.x[0].y.z"u8).ToString(), Is.EqualTo("[{\"a\":\"value1\"},{\"a\":\"value2\"}]"));
            Assert.That(jp.GetJson("$.x[0].y.z[0]"u8).ToString(), Is.EqualTo("{\"a\":\"value1\"}"));
            Assert.That(jp.GetString("$.x[0].y.z[0].a"u8), Is.EqualTo("value1"));
            Assert.That(jp.GetJson("$.x[0].y.z[1]"u8).ToString(), Is.EqualTo("{\"a\":\"value2\"}"));
            Assert.That(jp.GetString("$.x[0].y.z[1].a"u8), Is.EqualTo("value2"));
            Assert.That(jp.GetJson("$.x[1]"u8).ToString(), Is.EqualTo("{\"y\":{\"z\":[{\"a\":\"value3\"},{\"a\":\"value4\"}]}}"));
            Assert.That(jp.GetJson("$.x[1].y"u8).ToString(), Is.EqualTo("{\"z\":[{\"a\":\"value3\"},{\"a\":\"value4\"}]}"));
            Assert.That(jp.GetJson("$.x[1].y.z"u8).ToString(), Is.EqualTo("[{\"a\":\"value3\"},{\"a\":\"value4\"}]"));
            Assert.That(jp.GetJson("$.x[1].y.z[0]"u8).ToString(), Is.EqualTo("{\"a\":\"value3\"}"));
            Assert.That(jp.GetString("$.x[1].y.z[0].a"u8), Is.EqualTo("value3"));
            Assert.That(jp.GetJson("$.x[1].y.z[1]"u8).ToString(), Is.EqualTo("{\"a\":\"value4\"}"));
            Assert.That(jp.GetString("$.x[1].y.z[1].a"u8), Is.EqualTo("value4"));

            jp.Append("$.x[0].y.z"u8, "{\"a\":\"value5\"}"u8);

            Assert.That(jp.GetJson("$.x[0]"u8).ToString(), Is.EqualTo("{\"y\":{\"z\":[{\"a\":\"value1\"},{\"a\":\"value2\"},{\"a\":\"value5\"}]}}"));

            jp.Append("$.x[0].y.z"u8, "{\"a\":\"value6\"}"u8);

            Assert.That(jp.GetJson("$.x[0]"u8).ToString(), Is.EqualTo("{\"y\":{\"z\":[{\"a\":\"value1\"},{\"a\":\"value2\"},{\"a\":\"value5\"},{\"a\":\"value6\"}]}}"));

            jp.Append("$.x[1].y.z"u8, "{\"a\":\"value7\"}"u8);

            Assert.That(jp.GetJson("$.x[1]"u8).ToString(), Is.EqualTo("{\"y\":{\"z\":[{\"a\":\"value3\"},{\"a\":\"value4\"},{\"a\":\"value7\"}]}}"));

            jp.Append("$.x[1].y.z"u8, "{\"a\":\"value8\"}"u8);

            Assert.That(jp.GetJson("$.x[1]"u8).ToString(), Is.EqualTo("{\"y\":{\"z\":[{\"a\":\"value3\"},{\"a\":\"value4\"},{\"a\":\"value7\"},{\"a\":\"value8\"}]}}"));

            jp.Append("$.x"u8, "{\"y\":{\"z\":[{\"a\":\"value9\"}]}}"u8);

            Assert.That(jp.GetJson("$.x"u8).ToString(), Is.EqualTo("[{\"y\":{\"z\":[{\"a\":\"value1\"},{\"a\":\"value2\"},{\"a\":\"value5\"},{\"a\":\"value6\"}]}},{\"y\":{\"z\":[{\"a\":\"value3\"},{\"a\":\"value4\"},{\"a\":\"value7\"},{\"a\":\"value8\"}]}},{\"y\":{\"z\":[{\"a\":\"value9\"}]}}]"));
            Assert.That(jp.GetJson("$.x[0]"u8).ToString(), Is.EqualTo("{\"y\":{\"z\":[{\"a\":\"value1\"},{\"a\":\"value2\"},{\"a\":\"value5\"},{\"a\":\"value6\"}]}}"));
            Assert.That(jp.GetJson("$.x[0].y"u8).ToString(), Is.EqualTo("{\"z\":[{\"a\":\"value1\"},{\"a\":\"value2\"},{\"a\":\"value5\"},{\"a\":\"value6\"}]}"));
            Assert.That(jp.GetJson("$.x[0].y.z"u8).ToString(), Is.EqualTo("[{\"a\":\"value1\"},{\"a\":\"value2\"},{\"a\":\"value5\"},{\"a\":\"value6\"}]"));
            Assert.That(jp.GetJson("$.x[0].y.z[0]"u8).ToString(), Is.EqualTo("{\"a\":\"value1\"}"));
            Assert.That(jp.GetString("$.x[0].y.z[0].a"u8), Is.EqualTo("value1"));
            Assert.That(jp.GetJson("$.x[0].y.z[1]"u8).ToString(), Is.EqualTo("{\"a\":\"value2\"}"));
            Assert.That(jp.GetString("$.x[0].y.z[1].a"u8), Is.EqualTo("value2"));
            Assert.That(jp.GetJson("$.x[0].y.z[2]"u8).ToString(), Is.EqualTo("{\"a\":\"value5\"}"));
            Assert.That(jp.GetString("$.x[0].y.z[2].a"u8), Is.EqualTo("value5"));
            Assert.That(jp.GetJson("$.x[0].y.z[3]"u8).ToString(), Is.EqualTo("{\"a\":\"value6\"}"));
            Assert.That(jp.GetString("$.x[0].y.z[3].a"u8), Is.EqualTo("value6"));
            Assert.That(jp.GetJson("$.x[1]"u8).ToString(), Is.EqualTo("{\"y\":{\"z\":[{\"a\":\"value3\"},{\"a\":\"value4\"},{\"a\":\"value7\"},{\"a\":\"value8\"}]}}"));
            Assert.That(jp.GetJson("$.x[1].y"u8).ToString(), Is.EqualTo("{\"z\":[{\"a\":\"value3\"},{\"a\":\"value4\"},{\"a\":\"value7\"},{\"a\":\"value8\"}]}"));
            Assert.That(jp.GetJson("$.x[1].y.z"u8).ToString(), Is.EqualTo("[{\"a\":\"value3\"},{\"a\":\"value4\"},{\"a\":\"value7\"},{\"a\":\"value8\"}]"));
            Assert.That(jp.GetJson("$.x[1].y.z[0]"u8).ToString(), Is.EqualTo("{\"a\":\"value3\"}"));
            Assert.That(jp.GetString("$.x[1].y.z[0].a"u8), Is.EqualTo("value3"));
            Assert.That(jp.GetJson("$.x[1].y.z[1]"u8).ToString(), Is.EqualTo("{\"a\":\"value4\"}"));
            Assert.That(jp.GetString("$.x[1].y.z[1].a"u8), Is.EqualTo("value4"));
            Assert.That(jp.GetJson("$.x[1].y.z[2]"u8).ToString(), Is.EqualTo("{\"a\":\"value7\"}"));
            Assert.That(jp.GetString("$.x[1].y.z[2].a"u8), Is.EqualTo("value7"));
            Assert.That(jp.GetJson("$.x[1].y.z[3]"u8).ToString(), Is.EqualTo("{\"a\":\"value8\"}"));
            Assert.That(jp.GetString("$.x[1].y.z[3].a"u8), Is.EqualTo("value8"));
            Assert.That(jp.GetJson("$.x[2]"u8).ToString(), Is.EqualTo("{\"y\":{\"z\":[{\"a\":\"value9\"}]}}"));
            Assert.That(jp.GetJson("$.x[2].y"u8).ToString(), Is.EqualTo("{\"z\":[{\"a\":\"value9\"}]}"));
            Assert.That(jp.GetJson("$.x[2].y.z"u8).ToString(), Is.EqualTo("[{\"a\":\"value9\"}]"));
            Assert.That(jp.GetJson("$.x[2].y.z[0]"u8).ToString(), Is.EqualTo("{\"a\":\"value9\"}"));
            Assert.That(jp.GetString("$.x[2].y.z[0].a"u8), Is.EqualTo("value9"));

            Assert.That(jp.ToString("J"), Is.EqualTo("{\"x\":[{\"y\":{\"z\":[{\"a\":\"value1\"},{\"a\":\"value2\"},{\"a\":\"value5\"},{\"a\":\"value6\"}]}},{\"y\":{\"z\":[{\"a\":\"value3\"},{\"a\":\"value4\"},{\"a\":\"value7\"},{\"a\":\"value8\"}]}},{\"y\":{\"z\":[{\"a\":\"value9\"}]}}]}"));
        }

        [Test]
        public void RootAndInsert_OneLevelTwoLevel()
        {
            JsonPatch jp = new("{\"x\":[{\"y\":{\"z\":[\"value1\",\"value2\"]}},{\"y\":{\"z\":[\"value3\",\"value4\"]}}]}"u8.ToArray());

            Assert.That(jp.GetJson("$.x"u8).ToString(), Is.EqualTo("[{\"y\":{\"z\":[\"value1\",\"value2\"]}},{\"y\":{\"z\":[\"value3\",\"value4\"]}}]"));
            Assert.That(jp.GetJson("$.x[0]"u8).ToString(), Is.EqualTo("{\"y\":{\"z\":[\"value1\",\"value2\"]}}"));
            Assert.That(jp.GetJson("$.x[0].y"u8).ToString(), Is.EqualTo("{\"z\":[\"value1\",\"value2\"]}"));
            Assert.That(jp.GetJson("$.x[0].y.z"u8).ToString(), Is.EqualTo("[\"value1\",\"value2\"]"));
            Assert.That(jp.GetString("$.x[0].y.z[0]"u8), Is.EqualTo("value1"));
            Assert.That(jp.GetString("$.x[0].y.z[1]"u8), Is.EqualTo("value2"));
            Assert.That(jp.GetJson("$.x[1]"u8).ToString(), Is.EqualTo("{\"y\":{\"z\":[\"value3\",\"value4\"]}}"));
            Assert.That(jp.GetJson("$.x[1].y"u8).ToString(), Is.EqualTo("{\"z\":[\"value3\",\"value4\"]}"));
            Assert.That(jp.GetJson("$.x[1].y.z"u8).ToString(), Is.EqualTo("[\"value3\",\"value4\"]"));
            Assert.That(jp.GetString("$.x[1].y.z[0]"u8), Is.EqualTo("value3"));
            Assert.That(jp.GetString("$.x[1].y.z[1]"u8), Is.EqualTo("value4"));

            jp.Append("$.x[0].y.z"u8, "value5");

            Assert.That(jp.GetJson("$.x[0]"u8).ToString(), Is.EqualTo("{\"y\":{\"z\":[\"value1\",\"value2\",\"value5\"]}}"));

            jp.Append("$.x[0].y.z"u8, "value6");

            Assert.That(jp.GetJson("$.x[0]"u8).ToString(), Is.EqualTo("{\"y\":{\"z\":[\"value1\",\"value2\",\"value5\",\"value6\"]}}"));

            jp.Append("$.x[1].y.z"u8, "value7");

            Assert.That(jp.GetJson("$.x[1]"u8).ToString(), Is.EqualTo("{\"y\":{\"z\":[\"value3\",\"value4\",\"value7\"]}}"));

            jp.Append("$.x[1].y.z"u8, "value8");

            Assert.That(jp.GetJson("$.x[1]"u8).ToString(), Is.EqualTo("{\"y\":{\"z\":[\"value3\",\"value4\",\"value7\",\"value8\"]}}"));

            jp.Append("$.x"u8, "{\"y\":{\"z\":[\"value9\"]}}"u8);

            Assert.That(jp.GetJson("$.x"u8).ToString(), Is.EqualTo("[{\"y\":{\"z\":[\"value1\",\"value2\",\"value5\",\"value6\"]}},{\"y\":{\"z\":[\"value3\",\"value4\",\"value7\",\"value8\"]}},{\"y\":{\"z\":[\"value9\"]}}]"));
            Assert.That(jp.GetJson("$.x[0]"u8).ToString(), Is.EqualTo("{\"y\":{\"z\":[\"value1\",\"value2\",\"value5\",\"value6\"]}}"));
            Assert.That(jp.GetJson("$.x[0].y"u8).ToString(), Is.EqualTo("{\"z\":[\"value1\",\"value2\",\"value5\",\"value6\"]}"));
            Assert.That(jp.GetJson("$.x[0].y.z"u8).ToString(), Is.EqualTo("[\"value1\",\"value2\",\"value5\",\"value6\"]"));
            Assert.That(jp.GetString("$.x[0].y.z[0]"u8), Is.EqualTo("value1"));
            Assert.That(jp.GetString("$.x[0].y.z[1]"u8), Is.EqualTo("value2"));
            Assert.That(jp.GetString("$.x[0].y.z[2]"u8), Is.EqualTo("value5"));
            Assert.That(jp.GetString("$.x[0].y.z[3]"u8), Is.EqualTo("value6"));
            Assert.That(jp.GetJson("$.x[1]"u8).ToString(), Is.EqualTo("{\"y\":{\"z\":[\"value3\",\"value4\",\"value7\",\"value8\"]}}"));
            Assert.That(jp.GetJson("$.x[1].y"u8).ToString(), Is.EqualTo("{\"z\":[\"value3\",\"value4\",\"value7\",\"value8\"]}"));
            Assert.That(jp.GetJson("$.x[1].y.z"u8).ToString(), Is.EqualTo("[\"value3\",\"value4\",\"value7\",\"value8\"]"));
            Assert.That(jp.GetString("$.x[1].y.z[0]"u8), Is.EqualTo("value3"));
            Assert.That(jp.GetString("$.x[1].y.z[1]"u8), Is.EqualTo("value4"));
            Assert.That(jp.GetString("$.x[1].y.z[2]"u8), Is.EqualTo("value7"));
            Assert.That(jp.GetString("$.x[1].y.z[3]"u8), Is.EqualTo("value8"));
            Assert.That(jp.GetJson("$.x[2]"u8).ToString(), Is.EqualTo("{\"y\":{\"z\":[\"value9\"]}}"));
            Assert.That(jp.GetJson("$.x[2].y"u8).ToString(), Is.EqualTo("{\"z\":[\"value9\"]}"));
            Assert.That(jp.GetJson("$.x[2].y.z"u8).ToString(), Is.EqualTo("[\"value9\"]"));
            Assert.That(jp.GetString("$.x[2].y.z[0]"u8), Is.EqualTo("value9"));

            Assert.That(jp.ToString("J"), Is.EqualTo("{\"x\":[{\"y\":{\"z\":[\"value1\",\"value2\",\"value5\",\"value6\"]}},{\"y\":{\"z\":[\"value3\",\"value4\",\"value7\",\"value8\"]}},{\"y\":{\"z\":[\"value9\"]}}]}"));
        }

        [Test]
        public void Insert_OneLevelTwoLevel_WithProperty()
        {
            JsonPatch jp = new();

            jp.Append("$.x[0].y.z"u8, "{\"a\":\"value1\"}"u8);

            Assert.That(jp.GetJson("$.x"u8).ToString(), Is.EqualTo("[{\"y\":{\"z\":[{\"a\":\"value1\"}]}}]"));

            jp.Append("$.x[0].y.z"u8, "{\"a\":\"value2\"}"u8);

            Assert.That(jp.GetJson("$.x"u8).ToString(), Is.EqualTo("[{\"y\":{\"z\":[{\"a\":\"value1\"},{\"a\":\"value2\"}]}}]"));

            jp.Append("$.x[1].y.z"u8, "{\"a\":\"value3\"}"u8);

            Assert.That(jp.GetJson("$.x"u8).ToString(), Is.EqualTo("[{\"y\":{\"z\":[{\"a\":\"value1\"},{\"a\":\"value2\"}]}},{\"y\":{\"z\":[{\"a\":\"value3\"}]}}]"));

            jp.Append("$.x[1].y.z"u8, "{\"a\":\"value4\"}"u8);

            Assert.That(jp.GetJson("$.x"u8).ToString(), Is.EqualTo("[{\"y\":{\"z\":[{\"a\":\"value1\"},{\"a\":\"value2\"}]}},{\"y\":{\"z\":[{\"a\":\"value3\"},{\"a\":\"value4\"}]}}]"));

            jp.Append("$.x"u8, "{\"y\":{\"z\":[{\"a\":\"value5\"}]}}"u8);

            Assert.That(jp.GetJson("$.x"u8).ToString(), Is.EqualTo("[{\"y\":{\"z\":[{\"a\":\"value1\"},{\"a\":\"value2\"}]}},{\"y\":{\"z\":[{\"a\":\"value3\"},{\"a\":\"value4\"}]}},{\"y\":{\"z\":[{\"a\":\"value5\"}]}}]"));
            Assert.That(jp.GetJson("$.x[0]"u8).ToString(), Is.EqualTo("{\"y\":{\"z\":[{\"a\":\"value1\"},{\"a\":\"value2\"}]}}"));
            Assert.That(jp.GetJson("$.x[0].y"u8).ToString(), Is.EqualTo("{\"z\":[{\"a\":\"value1\"},{\"a\":\"value2\"}]}"));
            Assert.That(jp.GetJson("$.x[0].y.z"u8).ToString(), Is.EqualTo("[{\"a\":\"value1\"},{\"a\":\"value2\"}]"));
            Assert.That(jp.GetJson("$.x[0].y.z[0]"u8).ToString(), Is.EqualTo("{\"a\":\"value1\"}"));
            Assert.That(jp.GetString("$.x[0].y.z[0].a"u8), Is.EqualTo("value1"));
            Assert.That(jp.GetJson("$.x[0].y.z[1]"u8).ToString(), Is.EqualTo("{\"a\":\"value2\"}"));
            Assert.That(jp.GetString("$.x[0].y.z[1].a"u8), Is.EqualTo("value2"));
            Assert.That(jp.GetJson("$.x[1]"u8).ToString(), Is.EqualTo("{\"y\":{\"z\":[{\"a\":\"value3\"},{\"a\":\"value4\"}]}}"));
            Assert.That(jp.GetJson("$.x[1].y"u8).ToString(), Is.EqualTo("{\"z\":[{\"a\":\"value3\"},{\"a\":\"value4\"}]}"));
            Assert.That(jp.GetJson("$.x[1].y.z"u8).ToString(), Is.EqualTo("[{\"a\":\"value3\"},{\"a\":\"value4\"}]"));
            Assert.That(jp.GetJson("$.x[1].y.z[0]"u8).ToString(), Is.EqualTo("{\"a\":\"value3\"}"));
            Assert.That(jp.GetString("$.x[1].y.z[0].a"u8), Is.EqualTo("value3"));
            Assert.That(jp.GetJson("$.x[1].y.z[1]"u8).ToString(), Is.EqualTo("{\"a\":\"value4\"}"));
            Assert.That(jp.GetString("$.x[1].y.z[1].a"u8), Is.EqualTo("value4"));
            Assert.That(jp.GetJson("$.x[2]"u8).ToString(), Is.EqualTo("{\"y\":{\"z\":[{\"a\":\"value5\"}]}}"));
            Assert.That(jp.GetJson("$.x[2].y"u8).ToString(), Is.EqualTo("{\"z\":[{\"a\":\"value5\"}]}"));
            Assert.That(jp.GetJson("$.x[2].y.z"u8).ToString(), Is.EqualTo("[{\"a\":\"value5\"}]"));
            Assert.That(jp.GetJson("$.x[2].y.z[0]"u8).ToString(), Is.EqualTo("{\"a\":\"value5\"}"));
            Assert.That(jp.GetString("$.x[2].y.z[0].a"u8), Is.EqualTo("value5"));

            Assert.That(jp.ToString("J"), Is.EqualTo("{\"x\":[{\"y\":{\"z\":[{\"a\":\"value1\"},{\"a\":\"value2\"}]}},{\"y\":{\"z\":[{\"a\":\"value3\"},{\"a\":\"value4\"}]}},{\"y\":{\"z\":[{\"a\":\"value5\"}]}}]}"));
        }

        [Test]
        public void Insert_OneLevelTwoLevel()
        {
            JsonPatch jp = new();

            jp.Append("$.x[0].y.z"u8, "value1");

            Assert.That(jp.GetJson("$.x"u8).ToString(), Is.EqualTo("[{\"y\":{\"z\":[\"value1\"]}}]"));

            jp.Append("$.x[0].y.z"u8, "value2");

            Assert.That(jp.GetJson("$.x"u8).ToString(), Is.EqualTo("[{\"y\":{\"z\":[\"value1\",\"value2\"]}}]"));

            jp.Append("$.x[1].y.z"u8, "value3");

            Assert.That(jp.GetJson("$.x"u8).ToString(), Is.EqualTo("[{\"y\":{\"z\":[\"value1\",\"value2\"]}},{\"y\":{\"z\":[\"value3\"]}}]"));

            jp.Append("$.x[1].y.z"u8, "value4");

            Assert.That(jp.GetJson("$.x"u8).ToString(), Is.EqualTo("[{\"y\":{\"z\":[\"value1\",\"value2\"]}},{\"y\":{\"z\":[\"value3\",\"value4\"]}}]"));

            jp.Append("$.x"u8, "{\"y\":{\"z\":[\"value5\"]}}"u8);

            Assert.That(jp.GetJson("$.x"u8).ToString(), Is.EqualTo("[{\"y\":{\"z\":[\"value1\",\"value2\"]}},{\"y\":{\"z\":[\"value3\",\"value4\"]}},{\"y\":{\"z\":[\"value5\"]}}]"));
            Assert.That(jp.GetJson("$.x[0]"u8).ToString(), Is.EqualTo("{\"y\":{\"z\":[\"value1\",\"value2\"]}}"));
            Assert.That(jp.GetJson("$.x[0].y"u8).ToString(), Is.EqualTo("{\"z\":[\"value1\",\"value2\"]}"));
            Assert.That(jp.GetJson("$.x[0].y.z"u8).ToString(), Is.EqualTo("[\"value1\",\"value2\"]"));
            Assert.That(jp.GetString("$.x[0].y.z[0]"u8), Is.EqualTo("value1"));
            Assert.That(jp.GetString("$.x[0].y.z[1]"u8), Is.EqualTo("value2"));
            Assert.That(jp.GetJson("$.x[1]"u8).ToString(), Is.EqualTo("{\"y\":{\"z\":[\"value3\",\"value4\"]}}"));
            Assert.That(jp.GetJson("$.x[1].y"u8).ToString(), Is.EqualTo("{\"z\":[\"value3\",\"value4\"]}"));
            Assert.That(jp.GetJson("$.x[1].y.z"u8).ToString(), Is.EqualTo("[\"value3\",\"value4\"]"));
            Assert.That(jp.GetString("$.x[1].y.z[0]"u8), Is.EqualTo("value3"));
            Assert.That(jp.GetString("$.x[1].y.z[1]"u8), Is.EqualTo("value4"));
            Assert.That(jp.GetJson("$.x[2]"u8).ToString(), Is.EqualTo("{\"y\":{\"z\":[\"value5\"]}}"));
            Assert.That(jp.GetJson("$.x[2].y"u8).ToString(), Is.EqualTo("{\"z\":[\"value5\"]}"));
            Assert.That(jp.GetJson("$.x[2].y.z"u8).ToString(), Is.EqualTo("[\"value5\"]"));
            Assert.That(jp.GetString("$.x[2].y.z[0]"u8), Is.EqualTo("value5"));

            Assert.That(jp.ToString("J"), Is.EqualTo("{\"x\":[{\"y\":{\"z\":[\"value1\",\"value2\"]}},{\"y\":{\"z\":[\"value3\",\"value4\"]}},{\"y\":{\"z\":[\"value5\"]}}]}"));
        }

        [Test]
        public void RootAndInsert_OneLevelTwice_WithProperty()
        {
            JsonPatch jp = new(new("{\"x\":[{\"y\":[{\"a\":\"value1\"},{\"a\":\"value2\"}]},{\"y\":[{\"a\":\"value3\"},{\"a\":\"value4\"}]}]}"u8.ToArray()));

            Assert.That(jp.GetJson("$.x"u8).ToString(), Is.EqualTo("[{\"y\":[{\"a\":\"value1\"},{\"a\":\"value2\"}]},{\"y\":[{\"a\":\"value3\"},{\"a\":\"value4\"}]}]"));
            Assert.That(jp.GetJson("$.x[0]"u8).ToString(), Is.EqualTo("{\"y\":[{\"a\":\"value1\"},{\"a\":\"value2\"}]}"));
            Assert.That(jp.GetJson("$.x[0].y"u8).ToString(), Is.EqualTo("[{\"a\":\"value1\"},{\"a\":\"value2\"}]"));
            Assert.That(jp.GetJson("$.x[0].y[0]"u8).ToString(), Is.EqualTo("{\"a\":\"value1\"}"));
            Assert.That(jp.GetString("$.x[0].y[0].a"u8), Is.EqualTo("value1"));
            Assert.That(jp.GetJson("$.x[0].y[1]"u8).ToString(), Is.EqualTo("{\"a\":\"value2\"}"));
            Assert.That(jp.GetString("$.x[0].y[1].a"u8), Is.EqualTo("value2"));
            Assert.That(jp.GetJson("$.x[1]"u8).ToString(), Is.EqualTo("{\"y\":[{\"a\":\"value3\"},{\"a\":\"value4\"}]}"));
            Assert.That(jp.GetJson("$.x[1].y"u8).ToString(), Is.EqualTo("[{\"a\":\"value3\"},{\"a\":\"value4\"}]"));
            Assert.That(jp.GetJson("$.x[1].y[0]"u8).ToString(), Is.EqualTo("{\"a\":\"value3\"}"));
            Assert.That(jp.GetString("$.x[1].y[0].a"u8), Is.EqualTo("value3"));
            Assert.That(jp.GetJson("$.x[1].y[1]"u8).ToString(), Is.EqualTo("{\"a\":\"value4\"}"));
            Assert.That(jp.GetString("$.x[1].y[1].a"u8), Is.EqualTo("value4"));

            jp.Append("$.x[0].y"u8, "{\"a\":\"value5\"}"u8);

            Assert.That(jp.GetJson("$.x[0]"u8).ToString(), Is.EqualTo("{\"y\":[{\"a\":\"value1\"},{\"a\":\"value2\"},{\"a\":\"value5\"}]}"));

            jp.Append("$.x[0].y"u8, "{\"a\":\"value6\"}"u8);

            Assert.That(jp.GetJson("$.x[0]"u8).ToString(), Is.EqualTo("{\"y\":[{\"a\":\"value1\"},{\"a\":\"value2\"},{\"a\":\"value5\"},{\"a\":\"value6\"}]}"));

            jp.Append("$.x[1].y"u8, "{\"a\":\"value7\"}"u8);

            Assert.That(jp.GetJson("$.x[1]"u8).ToString(), Is.EqualTo("{\"y\":[{\"a\":\"value3\"},{\"a\":\"value4\"},{\"a\":\"value7\"}]}"));

            jp.Append("$.x[1].y"u8, "{\"a\":\"value8\"}"u8);

            Assert.That(jp.GetJson("$.x[1]"u8).ToString(), Is.EqualTo("{\"y\":[{\"a\":\"value3\"},{\"a\":\"value4\"},{\"a\":\"value7\"},{\"a\":\"value8\"}]}"));

            jp.Append("$.x"u8, "{\"y\":[{\"a\":\"value9\"}]}"u8);

            Assert.That(jp.GetJson("$.x"u8).ToString(), Is.EqualTo("[{\"y\":[{\"a\":\"value1\"},{\"a\":\"value2\"},{\"a\":\"value5\"},{\"a\":\"value6\"}]},{\"y\":[{\"a\":\"value3\"},{\"a\":\"value4\"},{\"a\":\"value7\"},{\"a\":\"value8\"}]},{\"y\":[{\"a\":\"value9\"}]}]"));
            Assert.That(jp.GetJson("$.x[0]"u8).ToString(), Is.EqualTo("{\"y\":[{\"a\":\"value1\"},{\"a\":\"value2\"},{\"a\":\"value5\"},{\"a\":\"value6\"}]}"));
            Assert.That(jp.GetJson("$.x[0].y"u8).ToString(), Is.EqualTo("[{\"a\":\"value1\"},{\"a\":\"value2\"},{\"a\":\"value5\"},{\"a\":\"value6\"}]"));
            Assert.That(jp.GetJson("$.x[0].y[0]"u8).ToString(), Is.EqualTo("{\"a\":\"value1\"}"));
            Assert.That(jp.GetString("$.x[0].y[0].a"u8), Is.EqualTo("value1"));
            Assert.That(jp.GetJson("$.x[0].y[1]"u8).ToString(), Is.EqualTo("{\"a\":\"value2\"}"));
            Assert.That(jp.GetString("$.x[0].y[1].a"u8), Is.EqualTo("value2"));
            Assert.That(jp.GetJson("$.x[0].y[2]"u8).ToString(), Is.EqualTo("{\"a\":\"value5\"}"));
            Assert.That(jp.GetString("$.x[0].y[2].a"u8), Is.EqualTo("value5"));
            Assert.That(jp.GetJson("$.x[0].y[3]"u8).ToString(), Is.EqualTo("{\"a\":\"value6\"}"));
            Assert.That(jp.GetString("$.x[0].y[3].a"u8), Is.EqualTo("value6"));
            Assert.That(jp.GetJson("$.x[1]"u8).ToString(), Is.EqualTo("{\"y\":[{\"a\":\"value3\"},{\"a\":\"value4\"},{\"a\":\"value7\"},{\"a\":\"value8\"}]}"));
            Assert.That(jp.GetJson("$.x[1].y"u8).ToString(), Is.EqualTo("[{\"a\":\"value3\"},{\"a\":\"value4\"},{\"a\":\"value7\"},{\"a\":\"value8\"}]"));
            Assert.That(jp.GetJson("$.x[1].y[0]"u8).ToString(), Is.EqualTo("{\"a\":\"value3\"}"));
            Assert.That(jp.GetString("$.x[1].y[0].a"u8), Is.EqualTo("value3"));
            Assert.That(jp.GetJson("$.x[1].y[1]"u8).ToString(), Is.EqualTo("{\"a\":\"value4\"}"));
            Assert.That(jp.GetString("$.x[1].y[1].a"u8), Is.EqualTo("value4"));
            Assert.That(jp.GetJson("$.x[1].y[2]"u8).ToString(), Is.EqualTo("{\"a\":\"value7\"}"));
            Assert.That(jp.GetString("$.x[1].y[2].a"u8), Is.EqualTo("value7"));
            Assert.That(jp.GetJson("$.x[1].y[3]"u8).ToString(), Is.EqualTo("{\"a\":\"value8\"}"));
            Assert.That(jp.GetString("$.x[1].y[3].a"u8), Is.EqualTo("value8"));
            Assert.That(jp.GetJson("$.x[2]"u8).ToString(), Is.EqualTo("{\"y\":[{\"a\":\"value9\"}]}"));
            Assert.That(jp.GetJson("$.x[2].y"u8).ToString(), Is.EqualTo("[{\"a\":\"value9\"}]"));
            Assert.That(jp.GetJson("$.x[2].y[0]"u8).ToString(), Is.EqualTo("{\"a\":\"value9\"}"));
            Assert.That(jp.GetString("$.x[2].y[0].a"u8), Is.EqualTo("value9"));

            Assert.That(jp.ToString("J"), Is.EqualTo("{\"x\":[{\"y\":[{\"a\":\"value1\"},{\"a\":\"value2\"},{\"a\":\"value5\"},{\"a\":\"value6\"}]},{\"y\":[{\"a\":\"value3\"},{\"a\":\"value4\"},{\"a\":\"value7\"},{\"a\":\"value8\"}]},{\"y\":[{\"a\":\"value9\"}]}]}"));
        }

        [Test]
        public void RootAndInsert_OneLevelTwice()
        {
            JsonPatch jp = new(new("{\"x\":[{\"y\":[\"value1\",\"value2\"]},{\"y\":[\"value3\",\"value4\"]}]}"u8.ToArray()));

            Assert.That(jp.GetJson("$.x"u8).ToString(), Is.EqualTo("[{\"y\":[\"value1\",\"value2\"]},{\"y\":[\"value3\",\"value4\"]}]"));
            Assert.That(jp.GetJson("$.x[0]"u8).ToString(), Is.EqualTo("{\"y\":[\"value1\",\"value2\"]}"));
            Assert.That(jp.GetJson("$.x[0].y"u8).ToString(), Is.EqualTo("[\"value1\",\"value2\"]"));
            Assert.That(jp.GetString("$.x[0].y[0]"u8), Is.EqualTo("value1"));
            Assert.That(jp.GetString("$.x[0].y[1]"u8), Is.EqualTo("value2"));
            Assert.That(jp.GetJson("$.x[1]"u8).ToString(), Is.EqualTo("{\"y\":[\"value3\",\"value4\"]}"));
            Assert.That(jp.GetJson("$.x[1].y"u8).ToString(), Is.EqualTo("[\"value3\",\"value4\"]"));
            Assert.That(jp.GetString("$.x[1].y[0]"u8), Is.EqualTo("value3"));
            Assert.That(jp.GetString("$.x[1].y[1]"u8), Is.EqualTo("value4"));

            jp.Append("$.x[0].y"u8, "value5");

            Assert.That(jp.GetJson("$.x[0]"u8).ToString(), Is.EqualTo("{\"y\":[\"value1\",\"value2\",\"value5\"]}"));

            jp.Append("$.x[0].y"u8, "value6");

            Assert.That(jp.GetJson("$.x[0]"u8).ToString(), Is.EqualTo("{\"y\":[\"value1\",\"value2\",\"value5\",\"value6\"]}"));

            jp.Append("$.x[1].y"u8, "value7");

            Assert.That(jp.GetJson("$.x[1]"u8).ToString(), Is.EqualTo("{\"y\":[\"value3\",\"value4\",\"value7\"]}"));

            jp.Append("$.x[1].y"u8, "value8");

            Assert.That(jp.GetJson("$.x[1]"u8).ToString(), Is.EqualTo("{\"y\":[\"value3\",\"value4\",\"value7\",\"value8\"]}"));

            jp.Append("$.x"u8, "{\"y\":[\"value9\"]}"u8);

            Assert.That(jp.GetJson("$.x"u8).ToString(), Is.EqualTo("[{\"y\":[\"value1\",\"value2\",\"value5\",\"value6\"]},{\"y\":[\"value3\",\"value4\",\"value7\",\"value8\"]},{\"y\":[\"value9\"]}]"));
            Assert.That(jp.GetJson("$.x[0]"u8).ToString(), Is.EqualTo("{\"y\":[\"value1\",\"value2\",\"value5\",\"value6\"]}"));
            Assert.That(jp.GetJson("$.x[0].y"u8).ToString(), Is.EqualTo("[\"value1\",\"value2\",\"value5\",\"value6\"]"));
            Assert.That(jp.GetString("$.x[0].y[0]"u8), Is.EqualTo("value1"));
            Assert.That(jp.GetString("$.x[0].y[1]"u8), Is.EqualTo("value2"));
            Assert.That(jp.GetString("$.x[0].y[2]"u8), Is.EqualTo("value5"));
            Assert.That(jp.GetString("$.x[0].y[3]"u8), Is.EqualTo("value6"));
            Assert.That(jp.GetJson("$.x[1]"u8).ToString(), Is.EqualTo("{\"y\":[\"value3\",\"value4\",\"value7\",\"value8\"]}"));
            Assert.That(jp.GetJson("$.x[1].y"u8).ToString(), Is.EqualTo("[\"value3\",\"value4\",\"value7\",\"value8\"]"));
            Assert.That(jp.GetString("$.x[1].y[0]"u8), Is.EqualTo("value3"));
            Assert.That(jp.GetString("$.x[1].y[1]"u8), Is.EqualTo("value4"));
            Assert.That(jp.GetString("$.x[1].y[2]"u8), Is.EqualTo("value7"));
            Assert.That(jp.GetString("$.x[1].y[3]"u8), Is.EqualTo("value8"));
            Assert.That(jp.GetJson("$.x[2]"u8).ToString(), Is.EqualTo("{\"y\":[\"value9\"]}"));
            Assert.That(jp.GetJson("$.x[2].y"u8).ToString(), Is.EqualTo("[\"value9\"]"));
            Assert.That(jp.GetString("$.x[2].y[0]"u8), Is.EqualTo("value9"));

            Assert.That(jp.ToString("J"), Is.EqualTo("{\"x\":[{\"y\":[\"value1\",\"value2\",\"value5\",\"value6\"]},{\"y\":[\"value3\",\"value4\",\"value7\",\"value8\"]},{\"y\":[\"value9\"]}]}"));
        }

        [Test]
        public void Insert_OneLevelTwice_WithProperty()
        {
            JsonPatch jp = new();

            jp.Append("$.x[0].y"u8, "{\"a\":\"value1\"}"u8);

            Assert.That(jp.GetJson("$.x"u8).ToString(), Is.EqualTo("[{\"y\":[{\"a\":\"value1\"}]}]"));

            jp.Append("$.x[0].y"u8, "{\"a\":\"value2\"}"u8);

            Assert.That(jp.GetJson("$.x"u8).ToString(), Is.EqualTo("[{\"y\":[{\"a\":\"value1\"},{\"a\":\"value2\"}]}]"));

            jp.Append("$.x[1].y"u8, "{\"a\":\"value3\"}"u8);

            Assert.That(jp.GetJson("$.x"u8).ToString(), Is.EqualTo("[{\"y\":[{\"a\":\"value1\"},{\"a\":\"value2\"}]},{\"y\":[{\"a\":\"value3\"}]}]"));

            jp.Append("$.x[1].y"u8, "{\"a\":\"value4\"}"u8);

            Assert.That(jp.GetJson("$.x"u8).ToString(), Is.EqualTo("[{\"y\":[{\"a\":\"value1\"},{\"a\":\"value2\"}]},{\"y\":[{\"a\":\"value3\"},{\"a\":\"value4\"}]}]"));

            jp.Append("$.x"u8, "{\"y\":[{\"a\":\"value5\"},{\"a\":\"value6\"}]}"u8);

            Assert.That(jp.GetJson("$.x"u8).ToString(), Is.EqualTo("[{\"y\":[{\"a\":\"value1\"},{\"a\":\"value2\"}]},{\"y\":[{\"a\":\"value3\"},{\"a\":\"value4\"}]},{\"y\":[{\"a\":\"value5\"},{\"a\":\"value6\"}]}]"));
            Assert.That(jp.GetJson("$.x[0]"u8).ToString(), Is.EqualTo("{\"y\":[{\"a\":\"value1\"},{\"a\":\"value2\"}]}"));
            Assert.That(jp.GetJson("$.x[0].y"u8).ToString(), Is.EqualTo("[{\"a\":\"value1\"},{\"a\":\"value2\"}]"));
            Assert.That(jp.GetJson("$.x[0].y[0]"u8).ToString(), Is.EqualTo("{\"a\":\"value1\"}"));
            Assert.That(jp.GetString("$.x[0].y[0].a"u8), Is.EqualTo("value1"));
            Assert.That(jp.GetJson("$.x[0].y[1]"u8).ToString(), Is.EqualTo("{\"a\":\"value2\"}"));
            Assert.That(jp.GetString("$.x[0].y[1].a"u8), Is.EqualTo("value2"));
            Assert.That(jp.GetJson("$.x[1]"u8).ToString(), Is.EqualTo("{\"y\":[{\"a\":\"value3\"},{\"a\":\"value4\"}]}"));
            Assert.That(jp.GetJson("$.x[1].y"u8).ToString(), Is.EqualTo("[{\"a\":\"value3\"},{\"a\":\"value4\"}]"));
            Assert.That(jp.GetJson("$.x[1].y[0]"u8).ToString(), Is.EqualTo("{\"a\":\"value3\"}"));
            Assert.That(jp.GetString("$.x[1].y[0].a"u8), Is.EqualTo("value3"));
            Assert.That(jp.GetJson("$.x[1].y[1]"u8).ToString(), Is.EqualTo("{\"a\":\"value4\"}"));
            Assert.That(jp.GetString("$.x[1].y[1].a"u8), Is.EqualTo("value4"));
            Assert.That(jp.GetJson("$.x[2]"u8).ToString(), Is.EqualTo("{\"y\":[{\"a\":\"value5\"},{\"a\":\"value6\"}]}"));
            Assert.That(jp.GetJson("$.x[2].y"u8).ToString(), Is.EqualTo("[{\"a\":\"value5\"},{\"a\":\"value6\"}]"));
            Assert.That(jp.GetJson("$.x[2].y[0]"u8).ToString(), Is.EqualTo("{\"a\":\"value5\"}"));
            Assert.That(jp.GetString("$.x[2].y[0].a"u8), Is.EqualTo("value5"));
            Assert.That(jp.GetJson("$.x[2].y[1]"u8).ToString(), Is.EqualTo("{\"a\":\"value6\"}"));
            Assert.That(jp.GetString("$.x[2].y[1].a"u8), Is.EqualTo("value6"));

            Assert.That(jp.ToString("J"), Is.EqualTo("{\"x\":[{\"y\":[{\"a\":\"value1\"},{\"a\":\"value2\"}]},{\"y\":[{\"a\":\"value3\"},{\"a\":\"value4\"}]},{\"y\":[{\"a\":\"value5\"},{\"a\":\"value6\"}]}]}"));
        }

        [Test]
        public void Insert_OneLevelTwice()
        {
            JsonPatch jp = new();

            jp.Append("$.x[0].y"u8, "value1");

            Assert.That(jp.GetJson("$.x"u8).ToString(), Is.EqualTo("[{\"y\":[\"value1\"]}]"));

            jp.Append("$.x[0].y"u8, "value2");

            Assert.That(jp.GetJson("$.x"u8).ToString(), Is.EqualTo("[{\"y\":[\"value1\",\"value2\"]}]"));

            jp.Append("$.x[1].y"u8, "value3");

            Assert.That(jp.GetJson("$.x"u8).ToString(), Is.EqualTo("[{\"y\":[\"value1\",\"value2\"]},{\"y\":[\"value3\"]}]"));

            jp.Append("$.x[1].y"u8, "value4");

            Assert.That(jp.GetJson("$.x"u8).ToString(), Is.EqualTo("[{\"y\":[\"value1\",\"value2\"]},{\"y\":[\"value3\",\"value4\"]}]"));

            jp.Append("$.x"u8, "{\"y\":[\"value5\",\"value6\"]}"u8);

            Assert.That(jp.GetJson("$.x"u8).ToString(), Is.EqualTo("[{\"y\":[\"value1\",\"value2\"]},{\"y\":[\"value3\",\"value4\"]},{\"y\":[\"value5\",\"value6\"]}]"));
            Assert.That(jp.GetJson("$.x[0]"u8).ToString(), Is.EqualTo("{\"y\":[\"value1\",\"value2\"]}"));
            Assert.That(jp.GetJson("$.x[0].y"u8).ToString(), Is.EqualTo("[\"value1\",\"value2\"]"));
            Assert.That(jp.GetString("$.x[0].y[0]"u8), Is.EqualTo("value1"));
            Assert.That(jp.GetString("$.x[0].y[1]"u8), Is.EqualTo("value2"));
            Assert.That(jp.GetJson("$.x[1]"u8).ToString(), Is.EqualTo("{\"y\":[\"value3\",\"value4\"]}"));
            Assert.That(jp.GetJson("$.x[1].y"u8).ToString(), Is.EqualTo("[\"value3\",\"value4\"]"));
            Assert.That(jp.GetString("$.x[1].y[0]"u8), Is.EqualTo("value3"));
            Assert.That(jp.GetString("$.x[1].y[1]"u8), Is.EqualTo("value4"));
            Assert.That(jp.GetJson("$.x[2]"u8).ToString(), Is.EqualTo("{\"y\":[\"value5\",\"value6\"]}"));
            Assert.That(jp.GetJson("$.x[2].y"u8).ToString(), Is.EqualTo("[\"value5\",\"value6\"]"));
            Assert.That(jp.GetString("$.x[2].y[0]"u8), Is.EqualTo("value5"));
            Assert.That(jp.GetString("$.x[2].y[1]"u8), Is.EqualTo("value6"));

            Assert.That(jp.ToString("J"), Is.EqualTo("{\"x\":[{\"y\":[\"value1\",\"value2\"]},{\"y\":[\"value3\",\"value4\"]},{\"y\":[\"value5\",\"value6\"]}]}"));
        }

        [Test]
        public void RootAndInsert_OneLevel_WithProperty()
        {
            JsonPatch jp = new(new("{\"x\":[{\"a\":\"value1\"},{\"a\":\"value2\"}]}"u8.ToArray()));

            Assert.That(jp.GetJson("$.x"u8).ToString(), Is.EqualTo("[{\"a\":\"value1\"},{\"a\":\"value2\"}]"));
            Assert.That(jp.GetJson("$.x[0]"u8).ToString(), Is.EqualTo("{\"a\":\"value1\"}"));
            Assert.That(jp.GetString("$.x[0].a"u8), Is.EqualTo("value1"));
            Assert.That(jp.GetJson("$.x[1]"u8).ToString(), Is.EqualTo("{\"a\":\"value2\"}"));
            Assert.That(jp.GetString("$.x[1].a"u8), Is.EqualTo("value2"));

            jp.Append("$.x"u8, "{\"a\":\"value3\"}"u8);

            Assert.That(jp.GetJson("$.x"u8).ToString(), Is.EqualTo("[{\"a\":\"value1\"},{\"a\":\"value2\"},{\"a\":\"value3\"}]"));

            jp.Append("$.x"u8, "{\"a\":\"value4\"}"u8);

            Assert.That(jp.GetJson("$.x"u8).ToString(), Is.EqualTo("[{\"a\":\"value1\"},{\"a\":\"value2\"},{\"a\":\"value3\"},{\"a\":\"value4\"}]"));
            Assert.That(jp.GetJson("$.x[0]"u8).ToString(), Is.EqualTo("{\"a\":\"value1\"}"));
            Assert.That(jp.GetString("$.x[0].a"u8), Is.EqualTo("value1"));
            Assert.That(jp.GetJson("$.x[1]"u8).ToString(), Is.EqualTo("{\"a\":\"value2\"}"));
            Assert.That(jp.GetString("$.x[1].a"u8), Is.EqualTo("value2"));
            Assert.That(jp.GetJson("$.x[2]"u8).ToString(), Is.EqualTo("{\"a\":\"value3\"}"));
            Assert.That(jp.GetString("$.x[2].a"u8), Is.EqualTo("value3"));
            Assert.That(jp.GetJson("$.x[3]"u8).ToString(), Is.EqualTo("{\"a\":\"value4\"}"));
            Assert.That(jp.GetString("$.x[3].a"u8), Is.EqualTo("value4"));

            Assert.That(jp.ToString("J"), Is.EqualTo("{\"x\":[{\"a\":\"value1\"},{\"a\":\"value2\"},{\"a\":\"value3\"},{\"a\":\"value4\"}]}"));
        }

        [Test]
        public void RootAndInsert_OneLevel()
        {
            JsonPatch jp = new(new("{\"x\":[\"value1\",\"value2\"]}"u8.ToArray()));

            Assert.That(jp.GetJson("$.x"u8).ToString(), Is.EqualTo("[\"value1\",\"value2\"]"));
            Assert.That(jp.GetString("$.x[0]"u8), Is.EqualTo("value1"));
            Assert.That(jp.GetString("$.x[1]"u8), Is.EqualTo("value2"));

            jp.Append("$.x"u8, "value3");

            Assert.That(jp.GetJson("$.x"u8).ToString(), Is.EqualTo("[\"value1\",\"value2\",\"value3\"]"));

            jp.Append("$.x"u8, "value4");

            Assert.That(jp.GetJson("$.x"u8).ToString(), Is.EqualTo("[\"value1\",\"value2\",\"value3\",\"value4\"]"));
            Assert.That(jp.GetString("$.x[0]"u8), Is.EqualTo("value1"));
            Assert.That(jp.GetString("$.x[1]"u8), Is.EqualTo("value2"));
            Assert.That(jp.GetString("$.x[2]"u8), Is.EqualTo("value3"));
            Assert.That(jp.GetString("$.x[3]"u8), Is.EqualTo("value4"));

            Assert.That(jp.ToString("J"), Is.EqualTo("{\"x\":[\"value1\",\"value2\",\"value3\",\"value4\"]}"));
        }

        [Test]
        public void Insert_OneLevel_WithProperty()
        {
            JsonPatch jp = new();

            jp.Append("$.x"u8, "{\"a\":\"value1\"}"u8);

            Assert.That(jp.GetJson("$.x"u8).ToString(), Is.EqualTo("[{\"a\":\"value1\"}]"));

            jp.Append("$.x"u8, "{\"a\":\"value2\"}"u8);

            Assert.That(jp.GetJson("$.x"u8).ToString(), Is.EqualTo("[{\"a\":\"value1\"},{\"a\":\"value2\"}]"));
            Assert.That(jp.GetJson("$.x[0]"u8).ToString(), Is.EqualTo("{\"a\":\"value1\"}"));
            Assert.That(jp.GetString("$.x[0].a"u8), Is.EqualTo("value1"));
            Assert.That(jp.GetJson("$.x[1]"u8).ToString(), Is.EqualTo("{\"a\":\"value2\"}"));
            Assert.That(jp.GetString("$.x[1].a"u8), Is.EqualTo("value2"));

            Assert.That(jp.ToString("J"), Is.EqualTo("{\"x\":[{\"a\":\"value1\"},{\"a\":\"value2\"}]}"));
        }

        [Test]
        public void Insert_OneLevel()
        {
            JsonPatch jp = new();

            jp.Append("$.x"u8, "value1");

            Assert.That(jp.GetJson("$.x"u8).ToString(), Is.EqualTo("[\"value1\"]"));

            jp.Append("$.x"u8, "value2");

            Assert.That(jp.GetJson("$.x"u8).ToString(), Is.EqualTo("[\"value1\",\"value2\"]"));
            Assert.That(jp.GetString("$.x[0]"u8), Is.EqualTo("value1"));
            Assert.That(jp.GetString("$.x[1]"u8), Is.EqualTo("value2"));

            Assert.That(jp.ToString("J"), Is.EqualTo("{\"x\":[\"value1\",\"value2\"]}"));
        }

        [Test]
        public void RootAndInsert_Root_WithProperty()
        {
            JsonPatch jp = new(new("[{\"a\":\"value1\"},{\"a\":\"value2\"}]"u8.ToArray()));

            Assert.That(jp.GetJson("$[0]"u8).ToString(), Is.EqualTo("{\"a\":\"value1\"}"));
            Assert.That(jp.GetString("$[0].a"u8), Is.EqualTo("value1"));
            Assert.That(jp.GetJson("$[1]"u8).ToString(), Is.EqualTo("{\"a\":\"value2\"}"));
            Assert.That(jp.GetString("$[1].a"u8), Is.EqualTo("value2"));

            jp.Append("$"u8, "{\"a\":\"value3\"}"u8);

            Assert.That(jp.GetJson("$"u8).ToString(), Is.EqualTo("[{\"a\":\"value1\"},{\"a\":\"value2\"},{\"a\":\"value3\"}]"));

            jp.Append("$"u8, "{\"a\":\"value4\"}"u8);

            Assert.That(jp.GetJson("$"u8).ToString(), Is.EqualTo("[{\"a\":\"value1\"},{\"a\":\"value2\"},{\"a\":\"value3\"},{\"a\":\"value4\"}]"));
            Assert.That(jp.GetJson("$[0]"u8).ToString(), Is.EqualTo("{\"a\":\"value1\"}"));
            Assert.That(jp.GetString("$[0].a"u8), Is.EqualTo("value1"));
            Assert.That(jp.GetJson("$[1]"u8).ToString(), Is.EqualTo("{\"a\":\"value2\"}"));
            Assert.That(jp.GetString("$[1].a"u8), Is.EqualTo("value2"));
            Assert.That(jp.GetJson("$[2]"u8).ToString(), Is.EqualTo("{\"a\":\"value3\"}"));
            Assert.That(jp.GetString("$[2].a"u8), Is.EqualTo("value3"));
            Assert.That(jp.GetJson("$[3]"u8).ToString(), Is.EqualTo("{\"a\":\"value4\"}"));
            Assert.That(jp.GetString("$[3].a"u8), Is.EqualTo("value4"));

            Assert.That(jp.ToString("J"), Is.EqualTo("[{\"a\":\"value1\"},{\"a\":\"value2\"},{\"a\":\"value3\"},{\"a\":\"value4\"}]"));
        }

        [Test]
        public void RootAndInsert_Root()
        {
            JsonPatch jp = new(new("[\"value1\",\"value2\"]"u8.ToArray()));

            Assert.That(jp.GetString("$[0]"u8), Is.EqualTo("value1"));
            Assert.That(jp.GetString("$[1]"u8), Is.EqualTo("value2"));

            jp.Append("$"u8, "value3");

            Assert.That(jp.GetJson("$"u8).ToString(), Is.EqualTo("[\"value1\",\"value2\",\"value3\"]"));

            jp.Append("$"u8, "value4");

            Assert.That(jp.GetJson("$"u8).ToString(), Is.EqualTo("[\"value1\",\"value2\",\"value3\",\"value4\"]"));
            Assert.That(jp.GetString("$[0]"u8), Is.EqualTo("value1"));
            Assert.That(jp.GetString("$[1]"u8), Is.EqualTo("value2"));
            Assert.That(jp.GetString("$[2]"u8), Is.EqualTo("value3"));
            Assert.That(jp.GetString("$[3]"u8), Is.EqualTo("value4"));

            Assert.That(jp.ToString("J"), Is.EqualTo("[\"value1\",\"value2\",\"value3\",\"value4\"]"));
        }

        [Test]
        public void Insert_Root_WithProperty()
        {
            JsonPatch jp = new();

            jp.Append("$"u8, "{\"a\":\"value1\"}"u8);

            Assert.That(jp.GetJson("$"u8).ToString(), Is.EqualTo("[{\"a\":\"value1\"}]"));

            jp.Append("$"u8, "{\"a\":\"value2\"}"u8);

            Assert.That(jp.GetJson("$"u8).ToString(), Is.EqualTo("[{\"a\":\"value1\"},{\"a\":\"value2\"}]"));
            Assert.That(jp.GetJson("$[0]"u8).ToString(), Is.EqualTo("{\"a\":\"value1\"}"));
            Assert.That(jp.GetString("$[0].a"u8), Is.EqualTo("value1"));
            Assert.That(jp.GetJson("$[1]"u8).ToString(), Is.EqualTo("{\"a\":\"value2\"}"));
            Assert.That(jp.GetString("$[1].a"u8), Is.EqualTo("value2"));

            Assert.That(jp.ToString("J"), Is.EqualTo("[{\"a\":\"value1\"},{\"a\":\"value2\"}]"));
        }

        [Test]
        public void Insert_Root()
        {
            JsonPatch jp = new();

            jp.Append("$"u8, "value1");

            Assert.That(jp.GetJson("$"u8).ToString(), Is.EqualTo("[\"value1\"]"));

            jp.Append("$"u8, "value2");

            Assert.That(jp.GetJson("$"u8).ToString(), Is.EqualTo("[\"value1\",\"value2\"]"));
            Assert.That(jp.GetString("$[0]"u8), Is.EqualTo("value1"));
            Assert.That(jp.GetString("$[1]"u8), Is.EqualTo("value2"));

            Assert.That(jp.ToString("J"), Is.EqualTo("[\"value1\",\"value2\"]"));
        }
    }
}
