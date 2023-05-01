// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Text.Json;
using NUnit.Framework;

namespace Azure.Core.Tests
{
    public class JsonDataTests
    {
        [Test]
        public void DynamicCanConvertToString() => Assert.AreEqual("string", JsonAsType<string>("\"string\""));

        [Test]
        public void DynamicCanConvertToInt() => Assert.AreEqual(5, JsonAsType<int>("5"));

        [Test]
        public void DynamicCanConvertToLong() => Assert.AreEqual(5L, JsonAsType<long>("5"));

        [Test]
        public void DynamicCanConvertToBool() => Assert.AreEqual(true, JsonAsType<bool>("true"));

        [Test]
        public void DynamicCanConvertToNullAsString() => Assert.AreEqual(null, JsonAsType<string>("null"));

        [Test]
        public void DynamicCanConvertToNullAsNullableInt() => Assert.AreEqual(null, JsonAsType<int?>("null"));

        [Test]
        public void DynamicCanConvertToNullAsNullableLong() => Assert.AreEqual(null, JsonAsType<long?>("null"));

        [Test]
        public void DynamicCanConvertToNullAsNullableBool() => Assert.AreEqual(null, JsonAsType<bool?>("null"));

        [Test]
        public void DynamicCanConvertToIEnumerableDynamic()
        {
            dynamic jsonData = DynamicJsonTests.GetDynamicJson("[1, null, \"s\"]");
            int i = 0;
            foreach (var dynamicItem in jsonData)
            {
                switch (i)
                {
                    case 0:
                        Assert.AreEqual(1, (int)dynamicItem);
                        break;
                    case 1:
                        Assert.AreEqual(null, (string)dynamicItem);
                        break;
                    case 2:
                        Assert.AreEqual("s", (string)dynamicItem);
                        break;
                    default:
                        Assert.Fail();
                        break;
                }

                i++;
            }
            Assert.AreEqual(3, i);
        }

        [Test]
        public void DynamicCanConvertToIEnumerableInt()
        {
            dynamic jsonData = DynamicJsonTests.GetDynamicJson("[0, 1, 2, 3]");
            int i = 0;
            foreach (int dynamicItem in jsonData)
            {
                Assert.AreEqual(i, dynamicItem);

                i++;
            }
            Assert.AreEqual(4, i);
        }

        [Test]
        public void CanAccessProperties()
        {
            dynamic jsonData = DynamicJsonTests.GetDynamicJson("""
                {
                  "primitive" : "Hello",
                  "nested" : {
                      "nestedPrimitive": true
                 }
              }
            """);

            Assert.AreEqual("Hello", (string)jsonData.primitive);
            Assert.AreEqual(true, (bool)jsonData.nested.nestedPrimitive);
        }

        [Test]
        public void CanRoundTripSerialize()
        {
            dynamic orig = new BinaryData(
                """
                {
                    "property" : "hello"
                }
                """).ToDynamicFromJson();

            void validate(dynamic d)
            {
                Assert.IsTrue(d.property == "hello");

                int count = 0;
                foreach (dynamic item in d)
                {
                    count++;
                }

                Assert.IsTrue(count == 1);
            }

            validate(orig);

            dynamic roundTrip = JsonSerializer.Deserialize<DynamicData>(JsonSerializer.Serialize(orig, orig.GetType()));

            validate(roundTrip);
        }

        private T JsonAsType<T>(string json)
        {
            dynamic jsonData = DynamicJsonTests.GetDynamicJson(json);
            return (T)jsonData;
        }

#pragma warning disable CS0659 // Type overrides Object.Equals(object o) but does not override Object.GetHashCode()
        internal class SampleModel : IEquatable<SampleModel>
#pragma warning restore CS0659 // Type overrides Object.Equals(object o) but does not override Object.GetHashCode()
        {
            public SampleModel() { }

            public string Message { get; set; }
            public int Number { get; set; }

            public SampleModel(string message, int number)
            {
                Message = message;
                Number = number;
            }

            public override bool Equals(object obj)
            {
                SampleModel other = obj as SampleModel;
                if (other == null)
                {
                    return false;
                }

                return Equals(other);
            }

            public bool Equals(SampleModel obj)
            {
                return Message == obj.Message && Number == obj.Number;
            }
        }
    }
}
