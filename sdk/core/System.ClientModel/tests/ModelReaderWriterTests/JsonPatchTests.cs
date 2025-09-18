// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;
using System.Collections.Generic;
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
    }
}
