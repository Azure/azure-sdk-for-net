// Copyright (c) Microsoft Corporation
// All rights reserved.
// 
// Licensed under the Apache License, Version 2.0 (the "License"); you may not
// use this file except in compliance with the License.  You may obtain a copy
// of the License at http://www.apache.org/licenses/LICENSE-2.0
// 
// THIS CODE IS PROVIDED *AS IS* BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY
// KIND, EITHER EXPRESS OR IMPLIED, INCLUDING WITHOUT LIMITATION ANY IMPLIED
// WARRANTIES OR CONDITIONS OF TITLE, FITNESS FOR A PARTICULAR PURPOSE,
// MERCHANTABLITY OR NON-INFRINGEMENT.
// 
// See the Apache Version 2.0 License for specific language governing
// permissions and limitations under the License.
namespace Microsoft.Hadoop.Avro.Tests
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Runtime.Serialization;
    using Microsoft.Hadoop.Avro.Schema;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public sealed class AvroGenericsTests : IDisposable
    {
        private MemoryStream stream;

        [TestInitialize]
        public void TestInitialize()
        {
            this.stream = new MemoryStream();
        }

        [TestCleanup]
        public void TestCleanup()
        {
            this.stream.Dispose();
        }

        [TestMethod]
        [TestCategory("CheckIn")]
        public void AvroRecord_CreateWithNonRecordTypeSchema()
        {
            var schema = TypeSchema.Create(@"""float""");
            Utilities.ShouldThrow<ArgumentException>(() =>
            {
                var _ = new AvroRecord(schema);
                Assert.IsNotNull(_);
            });
        }

        [TestMethod]
        [TestCategory("CheckIn")]
        public void AvroRecord_CreateUnionOfAvroRecordAndNull()
        {
            const string Schema =
                        @"[
                             ""null"",
                             {
                                ""type"":""record"",
                                ""name"":""Microsoft.Hadoop.Avro.Tests.SimpleIntClass"",
                                ""fields"":
                                        [
                                            { ""name"":""IntField"", ""type"":""int"" },
                                        ]
                             }
                        ]";

            var serializer = AvroSerializer.CreateGeneric(Schema);
            var unionSchema = (UnionSchema)serializer.WriterSchema;
            var expected = new AvroRecord(unionSchema.Schemas[1]);
            expected["IntField"] = Utilities.GetRandom<int>(false);

            serializer.Serialize(this.stream, null);
            serializer.Serialize(this.stream, expected);

            this.stream.Seek(0, SeekOrigin.Begin);
            var actual1 = serializer.Deserialize(this.stream);
            Assert.IsNull(actual1);

            var actual2 = (AvroRecord)serializer.Deserialize(this.stream);
            Assert.IsNotNull(actual2);
            Assert.AreEqual(expected["IntField"], actual2["IntField"]);
        }

        [TestMethod]
        [TestCategory("CheckIn")]
        public void AvroEnum_CreateUnionOfAvroEnumAndNull()
        {
            const string Schema = @"
                        [
                            ""null"",
                            {
                                ""type"":""enum"",
                                ""name"":""Microsoft.Hadoop.Avro.Tests.TestEnum"",
                                ""symbols"":
                                [
                                    ""EnumValue3"",
                                    ""EnumValue2"",
                                    ""EnumValue1""
                                ]
                            }
                        ]";
            var serializer = AvroSerializer.CreateGeneric(Schema);
            var unionSchema = (UnionSchema)serializer.WriterSchema;

            var expected = new AvroEnum(unionSchema.Schemas[1]) { IntegerValue = 0 };
            serializer.Serialize(this.stream, null);
            serializer.Serialize(this.stream, expected);

            this.stream.Seek(0, SeekOrigin.Begin);

            var actual1 = serializer.Deserialize(this.stream);
            Assert.IsNull(actual1);
            var actual2 = (AvroEnum)serializer.Deserialize(this.stream);
            Assert.AreEqual(expected.Value, actual2.Value);
        }

        [TestMethod]
        [TestCategory("CheckIn")]
        public void AvroRecord_CreateArrayOfAvroRecord()
        {
            const string Schema = @"
                        {
                            ""type"" :""array"",
                            ""items"":
                            {
                                ""type"":""record"",
                                ""name"":""Microsoft.Hadoop.Avro.Tests.SimpleIntClass"",
                                ""fields"":
                                    [
                                        { ""name"":""IntField"", ""type"":""int"" },
                                    ]
                            }
                        }";
            var serializer = AvroSerializer.CreateGeneric(Schema);
            var arraySchema = (ArraySchema)serializer.WriterSchema;

            var expected = Enumerable
                .Range(0, 10)
                .Select(i =>
                {
                    var g = new AvroRecord(arraySchema.ItemSchema);
                    g["IntField"] = i;
                    return g;
                })
                .ToArray();

            serializer.Serialize(this.stream, expected);
            this.stream.Seek(0, SeekOrigin.Begin);

            dynamic actual = serializer.Deserialize(this.stream);
            for (int i = 0; i < 10; i++)
            {
                Assert.AreEqual(expected[i]["IntField"], actual[i].IntField);
            }
        }

        [TestMethod]
        [TestCategory("CheckIn")]
        public void AvroEnum_CreateArrayOfAvroEnum()
        {
            const string Schema = @"
                        {
                            ""type"" :""array"",
                            ""items"":
                            {
                                ""type"":""enum"",
                                ""name"":""Microsoft.Hadoop.Avro.Tests.TestEnum"",
                                ""symbols"":
                                [
                                    ""EnumValue3"",
                                    ""EnumValue2"",
                                    ""EnumValue1""
                                ]
                            }
                        }";
            var serializer = AvroSerializer.CreateGeneric(Schema);
            var arraySchema = (ArraySchema)serializer.WriterSchema;
            var expected = Enumerable
                .Range(0, 100)
                .Select(i => new AvroEnum(arraySchema.ItemSchema) { IntegerValue = i % 3 })
                .ToArray();

            serializer.Serialize(this.stream, expected);
            this.stream.Seek(0, SeekOrigin.Begin);
            dynamic actual = serializer.Deserialize(this.stream);
            for (int i = 0; i < 10; i++)
            {
                Assert.AreEqual(expected[i].Value, actual[i].Value);
            }
        }

        [TestMethod]
        [TestCategory("CheckIn")]
        public void AvroRecord_CreateMapOfArrayOfAvroRecords()
        {
            const string Schema = @"
                {
                    ""type""  :""map"",
                    ""values"":
                        {
                            ""type"" :""array"",
                            ""items"":
                            {
                                ""type"":""record"",
                                ""name"":""Microsoft.Hadoop.Avro.Tests.SimpleIntClass"",
                                ""fields"":
                                    [
                                        { ""name"":""IntField"", ""type"":""int"" },
                                    ]
                            }
                        }
                }";
            var serializer = AvroSerializer.CreateGeneric(Schema);
            var mapSchema = (MapSchema)serializer.WriterSchema;
            var arraySchema = (ArraySchema)mapSchema.ValueSchema;

            var expected = new Dictionary<string, AvroRecord[]>();
            for (int i = 0; i < 5; i++)
            {
                var key = Utilities.GetRandom<string>(false) + i;
                var value = new AvroRecord[10];
                for (int j = 0; j < 10; j++)
                {
                    var record = new AvroRecord(arraySchema.ItemSchema);
                    record["IntField"] = j;
                    value[j] = record;
                }
                expected.Add(key, value);
            }

            serializer.Serialize(this.stream, expected);
            this.stream.Seek(0, SeekOrigin.Begin);
            dynamic actual = serializer.Deserialize(this.stream);
            foreach (var expectedKeyValuePair in expected)
            {
                Assert.IsTrue(actual.ContainsKey(expectedKeyValuePair.Key));
                dynamic actualValue = actual[expectedKeyValuePair.Key];
                for (int i = 0; i < 10; i++)
                {
                    Assert.AreEqual(expectedKeyValuePair.Value[i]["IntField"], actualValue[i].IntField);
                }
            }
        }

        [TestMethod]
        [TestCategory("CheckIn")]
        public void AvroRecord_SerializeRecordWithSByteFields()
        {
            var schema = AvroSerializer.Create<ClassWithSByteFields>().WriterSchema;
            var expected = ClassWithSByteFields.Create();
            var serializer = AvroSerializer.CreateGeneric(schema.ToString());
            using (var stream = new MemoryStream())
            {
                serializer.Serialize(stream, expected.ToAvroRecord(schema));
                stream.Seek(0, SeekOrigin.Begin);
                var result = serializer.Deserialize(stream);
                var actual = ClassWithSByteFields.Create((AvroRecord)result);
                Assert.AreEqual(expected, actual);
            }
        }

        #region Testing for exceptions

        [TestMethod]
        [TestCategory("CheckIn")]
        public void AvroRecord_CheckInvalidField()
        {
            var schema = TypeSchema.Create(
                         @"{
                             ""type"":""record"",
                             ""name"":""testRecord"",
                             ""fields"":
                                       [
                                           { ""name"":""testField"", ""type"":""int"" },
                                       ]
                          }");
            var avroRecord = new AvroRecord(schema);

            Utilities.ShouldThrow<ArgumentException>(() => { var _ = avroRecord[null]; });
            Utilities.ShouldThrow<ArgumentNullException>(() => { avroRecord[null] = 1; });
            Utilities.ShouldThrow<ArgumentOutOfRangeException>(() => { var _ = avroRecord["InvalidField"]; });
            Utilities.ShouldThrow<ArgumentOutOfRangeException>(() => { avroRecord["InvalidField"] = 1; });
        }

        [TestMethod]
        [TestCategory("CheckIn")]
        [ExpectedException(typeof(SerializationException))]
        public void GenericSerializer_UnionOfNullAndArrayWithInvalidArrayType()
        {
            const string Schema = @"[""null"", { ""type"" :""array"", ""items"":""int"" } ]";

            var arrayOfDoubles = Utilities.GetRandom<double[]>(false);

            var serializer = AvroSerializer.CreateGeneric(Schema);
            using (var memoryStream = new MemoryStream())
            {
                serializer.Serialize(memoryStream, arrayOfDoubles);
            }
        }

        [TestMethod]
        [TestCategory("CheckIn")]
        [ExpectedException(typeof(SerializationException))]
        public void GenericSerializer_UnionOfNullAndArrayWithInvalidType()
        {
            const string Schema = @"[""null"", { ""type"" :""array"", ""items"":""int"" } ]";

            var dictionaryOfDoubles = Utilities.GetRandom<Dictionary<string, double>>(false);

            var serializer = AvroSerializer.CreateGeneric(Schema);
            using (var memoryStream = new MemoryStream())
            {
                serializer.Serialize(memoryStream, dictionaryOfDoubles);
            }
        }

        [TestMethod]
        [TestCategory("CheckIn")]
        [ExpectedException(typeof(SerializationException))]
        public void GenericSerializer_UnionOfNullAndMapWithInvalidMapValueType()
        {
            const string Schema = @"[""null"", { ""type"" :""map"", ""values"":""int"" } ]";

            var dictionaryOfDoubles = Utilities.GetRandom<Dictionary<string, double>>(false);

            var serializer = AvroSerializer.CreateGeneric(Schema);
            using (var memoryStream = new MemoryStream())
            {
                serializer.Serialize(memoryStream, dictionaryOfDoubles);
            }
        }

        [TestMethod]
        [TestCategory("CheckIn")]
        [ExpectedException(typeof(SerializationException))]
        public void GenericSerializer_UnionOfNullAndMapWithInvalidType()
        {
            const string Schema = @"[""null"", { ""type"" :""map"", ""values"":""int"" } ]";

            var arrayOfDoubles = Utilities.GetRandom<double[]>(false);

            var serializer = AvroSerializer.CreateGeneric(Schema);
            using (var memoryStream = new MemoryStream())
            {
                serializer.Serialize(memoryStream, arrayOfDoubles);
            }
        }

        [TestMethod]
        [TestCategory("CheckIn")]
        [ExpectedException(typeof(SerializationException))]
        public void GenericSerializer_UnionOfNullAndEnumWithInvalidEnum()
        {
            const string Schema = @"
                [
                    ""null"",
                    {
                        ""type"":""enum"",
                        ""name"":""Microsoft.Hadoop.Avro.Tests.TestEnum"",
                        ""symbols"":
                        [
                            ""EnumValue3"",
                            ""EnumValue2"",
                            ""EnumValue1""
                        ]
                    }
                ]";

            const string InvalidEnumSchema = @"{
                ""type"":""enum"",
                ""name"":""Microsoft.Hadoop.Avro.Tests.InvalidEnum"",
                ""symbols"":
                [
                    ""InvalidValue3"",
                    ""InvalidValue2"",
                    ""InvalidValue1""
                ]
            }";

            var invalidSchemaSerializer = AvroSerializer.CreateGeneric(InvalidEnumSchema);
            var invalidEnum = new AvroEnum(invalidSchemaSerializer.WriterSchema) { Value = "InvalidValue3" };
            var serializer = AvroSerializer.CreateGeneric(Schema);

            using (var memoryStream = new MemoryStream())
            {
                serializer.Serialize(memoryStream, invalidEnum);
            }
        }

        [TestMethod]
        [TestCategory("CheckIn")]
        public void AvroEnum_SerializeInvalidObject()
        {
            const string Schema = @"{
                        ""type"":""enum"",
                        ""name"":""Microsoft.Hadoop.Avro.Tests.TestEnum"",
                        ""symbols"":
                        [
                            ""EnumValue3"",
                            ""EnumValue2"",
                            ""EnumValue1""
                        ]
                    }";

            const string InvalidEnumSchema = @"{
                ""type"":""enum"",
                ""name"":""Microsoft.Hadoop.Avro.Tests.InvalidEnum"",
                ""symbols"":
                [
                    ""InvalidValue3"",
                    ""InvalidValue2"",
                    ""InvalidValue1""
                ]
            }";

            var invalidSchemaSerializer = AvroSerializer.CreateGeneric(InvalidEnumSchema);
            var invalidEnum = new AvroEnum(invalidSchemaSerializer.WriterSchema) { Value = "InvalidValue3" };
            var serializer = AvroSerializer.CreateGeneric(Schema);

            using (var memoryStream = new MemoryStream())
            {
                Utilities.ShouldThrow<ArgumentNullException>(() => serializer.Serialize(memoryStream, null));
                Utilities.ShouldThrow<SerializationException>(() => serializer.Serialize(memoryStream, ClassOfInt.Create(false)));
                Utilities.ShouldThrow<SerializationException>(() => serializer.Serialize(memoryStream, invalidEnum));
            }
        }

        [TestMethod]
        [TestCategory("CheckIn")]
        public void AvroRecord_SerializeInvalidObject()
        {
            const string Schema = @"{
                                ""type"":""record"",
                                ""name"":""Microsoft.Hadoop.Avro.Tests.SimpleIntClass"",
                                ""fields"":
                                    [
                                        { ""name"":""IntField"", ""type"":""int"" },
                                    ]
                            }";

            var serializer = AvroSerializer.CreateGeneric(Schema);

            using (var memoryStream = new MemoryStream())
            {
                Utilities.ShouldThrow<ArgumentNullException>(() => serializer.Serialize(memoryStream, null));
                Utilities.ShouldThrow<SerializationException>(() => serializer.Serialize(memoryStream, ClassOfInt.Create(false)));
            }
        }

        #endregion //Testing for exceptions

        public void Dispose()
        {
            this.stream.Dispose();
        }
    }
}
