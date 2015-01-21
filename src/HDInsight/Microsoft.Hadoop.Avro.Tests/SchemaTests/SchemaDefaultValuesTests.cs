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
    using System.Diagnostics.CodeAnalysis;
    using System.IO;
    using System.Linq;
    using System.Runtime.Serialization;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class SchemaDefaultValuesTests
    {
        private const string SimpleIntClassRecordSchema = @"{
                             ""type"":""record"",
                             ""name"":""Microsoft.Hadoop.Avro.Tests.SimpleIntClass"",
                             ""fields"":
                                       [
                                           {
                                               ""name"":""IntField"",
                                               ""type"":""int""
                                           }
                                       ]
                          }";

        [SuppressMessage("Microsoft.Globalization", "CA1308:NormalizeStringsToUppercase",
            Justification = "boolean values in Json are written in smallcaps.")]
        [TestMethod]
        [TestCategory("CheckIn")]
        public void SchemaDefaultValues_Bool()
        {
            var randomBool = Utilities.GetRandom<bool>(false);
            RoundTripSerializationWithDefaultsAndCheck(@"""boolean""", randomBool, randomBool.ToString().ToLowerInvariant());
        }

        [TestMethod]
        [TestCategory("CheckIn")]
        public void SchemaDefaultValues_String()
        {
            var randomString = Utilities.GetRandom<string>(false);
            RoundTripSerializationWithDefaultsAndCheck(@"""string""", randomString, @"""" + randomString + @"""");
        }

        [TestMethod]
        [TestCategory("CheckIn")]
        public void SchemaDefaultValues_Int()
        {
            RoundTripSerializationWithDefaultsAndCheck(@"""int""", Utilities.GetRandom<int>(false));
        }

        [TestMethod]
        [TestCategory("CheckIn")]
        public void SchemaDefaultValues_Long()
        {
            RoundTripSerializationWithDefaultsAndCheck(@"""long""", Utilities.GetRandom<long>(false));
        }

        [TestMethod]
        [TestCategory("CheckIn")]
        public void SchemaDefaultValues_Double()
        {
            var extraFieldValue = Utilities.GetRandom<double>(false);
            RoundTripSerializationWithDefaultsAndCheck(
                @"""double""",
                extraFieldValue,
                @"""" + extraFieldValue.ToString("0.0000000000000") + @"""",
                (expected, actual) => Assert.AreEqual(expected.ToString("0.0000000000000"), ((double)actual).ToString("0.0000000000000")));
        }

        [TestMethod]
        [TestCategory("CheckIn")]
        public void SchemaDefaultValues_Float()
        {
            var extraFieldValue = Utilities.GetRandom<float>(false);
            RoundTripSerializationWithDefaultsAndCheck(
                @"""float""",
                extraFieldValue,
                @"""" + extraFieldValue.ToString("0.0000000") + @"""",
                (expected, actual) => Assert.AreEqual(expected.ToString("0.0000000"), ((float)actual).ToString("0.0000000")));
        }

        [TestMethod]
        [TestCategory("CheckIn")]
        public void SchemaDefaultValues_Record()
        {
            const string DefaultSchema =
                @"{""type"":""record"",""name"":""SomeRecord"",""fields"":[{""name"":""Field1"",""type"":""int""}, {""name"":""Field2"", ""type"":""string""}]}";
            var tempSerializer = AvroSerializer.CreateGeneric(DefaultSchema);
            dynamic defaultValue = new AvroRecord(tempSerializer.WriterSchema);
            defaultValue.Field1 = Utilities.GetRandom<int>(false);
            defaultValue.Field2 = Utilities.GetRandom<string>(false);
            dynamic defaultValueJson = @"{""Field1"":" + defaultValue.Field1 + @", ""Field2"":""" + defaultValue.Field2 + @"""}";
            RoundTripSerializationWithDefaultsAndCheck<AvroRecord>(
                DefaultSchema,
                defaultValue,
                defaultValueJson,
                (Action<dynamic, dynamic>)((expected, actual) =>
                {
                    Assert.AreEqual(expected.Field1, actual.Field1);
                    Assert.AreEqual(expected.Field2, actual.Field2);
                }));
        }

        [TestMethod]
        [TestCategory("CheckIn")]
        public void SchemaDefaultValues_Enum()
        {
            const string DefaultSchema = @"{ ""type"": ""enum"",""name"": ""Suit"",""symbols"" : [""SPADES"", ""HEARTS"", ""DIAMONDS"", ""CLUBS""]}";
            var tempSerializer = AvroSerializer.CreateGeneric(DefaultSchema);
            var defaultValue = new AvroEnum(tempSerializer.WriterSchema);
            defaultValue.Value = "DIAMONDS";
            const string DefaultValueJson = @"""DIAMONDS""";
            RoundTripSerializationWithDefaultsAndCheck(
                DefaultSchema,
                defaultValue,
                DefaultValueJson,
                (expected, actual) => Assert.AreEqual(expected.Value, actual.Value));
        }

        [TestMethod]
        [TestCategory("CheckIn")]
        public void SchemaDefaultValues_Fixed()
        {
            const string DefaultSchema = @"{""type"": ""fixed"", ""size"": ""16"", ""name"":""SomeName""}";
            var defaultValue = new byte[] { 0x00, 0x01, 0x02, 0x03, 0x04, 0x05, 0x06, 0x07, 0x08, 0x09, 0x0A, 0x0B, 0x0C, 0x0D, 0x0E, 0x0F };
            const string DefaultValueJson = @"""\u0000\u0001\u0002\u0003\u0004\u0005\u0006\u0007\u0008\u0009\u000A\u000B\u000C\u000D\u000E\u000F""";

            RoundTripSerializationWithDefaultsAndCheck(
                DefaultSchema,
                defaultValue,
                DefaultValueJson,
                (expected, actual) => Assert.IsTrue(((byte[])expected).SequenceEqual((byte[])actual)));
        }

        [TestMethod]
        [TestCategory("CheckIn")]
        public void SchemaDefaultValues_Array()
        {
            const string DefaultSchema = @"{""type"":""array"",""items"":""int""}";
            var defaultValue = new object[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            const string DefaultValueJson = "[1, 2, 3, 4, 5, 6, 7, 8, 9, 10]";

            RoundTripSerializationWithDefaultsAndCheck(
                DefaultSchema,
                defaultValue,
                DefaultValueJson,
                (expected, actual) => Assert.IsTrue(((object[])expected).SequenceEqual((object[])actual)));
        }

        [TestMethod]
        [TestCategory("CheckIn")]
        [ExpectedException(typeof(SerializationException))]
        public void SchemaDefaultValues_ArrayWithWrongValues()
        {
            const string DefaultSchema = @"{""type"":""array"",""items"":""int""}";
            var defaultValue = new object[] { 1, 2, 3, 4 };
            const string DefaultValueJson = "[1.1, 2.1, 3.1, 4.1]";

            RoundTripSerializationWithDefaultsAndCheck(
                DefaultSchema,
                defaultValue,
                DefaultValueJson,
                (expected, actual) => Assert.IsTrue(((object[])expected).SequenceEqual((object[])actual)));
        }

        [TestMethod]
        [TestCategory("CheckIn")]
        public void SchemaDefaultValues_Bytes()
        {
            const string DefaultSchema = @"""bytes""";
            var defaultValue = new byte[] { 0x00, 0x01, 0x02, 0x03, 0x04, 0x05, 0x06, 0x07, 0x08, 0x09, 0x0A, 0x0B, 0x0C, 0x0D, 0x0E, 0x0F };
            const string DefaultValueJson = @"""\u0000\u0001\u0002\u0003\u0004\u0005\u0006\u0007\u0008\u0009\u000A\u000B\u000C\u000D\u000E\u000F""";

            RoundTripSerializationWithDefaultsAndCheck(
                DefaultSchema,
                defaultValue,
                DefaultValueJson,
                (expected, actual) => Assert.IsTrue(((byte[])expected).SequenceEqual((byte[])actual)));
        }

        [TestMethod]
        [TestCategory("CheckIn")]
        public void SchemaDefaultValues_Map()
        {
            const string DefaultSchema = @"{""type"": ""map"", ""values"": ""int""}";
            var defaultValue = new Dictionary<string, object>
            {
                { Utilities.GetRandom<string>(false), Utilities.GetRandom<int>(false) },
                { Utilities.GetRandom<string>(false), Utilities.GetRandom<int>(false) },
                { Utilities.GetRandom<string>(false), Utilities.GetRandom<int>(false) },
                { Utilities.GetRandom<string>(false), Utilities.GetRandom<int>(false) },
                { Utilities.GetRandom<string>(false), Utilities.GetRandom<int>(false) }
            };

            var defaultValueJson = defaultValue.Aggregate("{", (current, item) => current + (@"""" + item.Key + @""": " + item.Value + ","));
            defaultValueJson = defaultValueJson.TrimEnd(',') + "}";

            RoundTripSerializationWithDefaultsAndCheck(
                DefaultSchema,
                defaultValue,
                defaultValueJson,
                (expected, actual) => Assert.IsTrue(((Dictionary<string, object>)expected).SequenceEqual((Dictionary<string, object>)actual)));
        }

        [TestMethod]
        [TestCategory("CheckIn")]
        public void SchemaDefaultValues_UnionWithInt()
        {
            RoundTripSerializationWithDefaultsAndCheck(@"[""int"", ""null""]", Utilities.GetRandom<int>(false));
        }

        [TestMethod]
        [TestCategory("CheckIn")]
        public void SchemaDefaultValues_UnionWithNull()
        {
            RoundTripSerializationWithDefaultsAndCheck<string>(@"[""null"", ""string""]", null, "null");
        }

        [TestMethod]
        [TestCategory("CheckIn")]
        [ExpectedException(typeof(SerializationException))]
        public void SchemaDefaultValues_WrongBool()
        {
            RoundTripSerializationWithDefaultsAndCheck(@"""boolean""", true, "0");
        }

        [TestMethod]
        [TestCategory("CheckIn")]
        [ExpectedException(typeof(SerializationException))]
        public void SchemaDefaultValues_UnicodeCodePointLargerThan255()
        {
            const string DefaultSchema = @"""bytes""";
            var defaultValue = new byte[] { 0x00, 0x01, 0x02 };
            const string DefaultValueJson = @"""\u0100\u0101\u0102""";

            RoundTripSerializationWithDefaultsAndCheck(
                DefaultSchema,
                defaultValue,
                DefaultValueJson,
                (expected, actual) => Assert.IsTrue(((byte[])expected).SequenceEqual((byte[])actual)));
        }

        [TestMethod]
        [TestCategory("CheckIn")]
        [ExpectedException(typeof(SerializationException))]
        public void SchemaDefaultValues_EnumWithInvalidSymbol()
        {
            const string DefaultSchema = @"{ ""type"": ""enum"",""name"": ""Suit"",""symbols"" : [""SPADES"", ""HEARTS"", ""DIAMONDS"", ""CLUBS""]}";
            var tempSerializer = AvroSerializer.CreateGeneric(DefaultSchema);
            var defaultValue = new AvroEnum(tempSerializer.WriterSchema) { Value = "DIAMONDS" };
            const string DefaultValueJson = @"""SOMESYMBOL""";
            RoundTripSerializationWithDefaultsAndCheck(
                DefaultSchema,
                defaultValue,
                DefaultValueJson,
                (expected, actual) => Assert.AreEqual(expected.Value, actual.Value));
        }

        [TestMethod]
        [TestCategory("CheckIn")]
        [ExpectedException(typeof(SerializationException))]
        public void SchemaDefaultValues_FixedWithValueOfInvalidSize()
        {
            const string DefaultSchema = @"{""type"": ""fixed"", ""size"": ""16"", ""name"":""SomeName""}";
            var defaultValue = new byte[] { 0x00, 0x01, 0x02, 0x03 };
            const string DefaultValueJson = @"""\u0000\u0001\u0002\u0003\u0004""";

            RoundTripSerializationWithDefaultsAndCheck(
                DefaultSchema,
                defaultValue,
                DefaultValueJson,
                (expected, actual) => Assert.IsTrue(((byte[])expected).SequenceEqual((byte[])actual)));
        }

        [TestMethod]
        [TestCategory("CheckIn")]
        [ExpectedException(typeof(SerializationException))]
        public void SchemaDefaultValues_NullWithWrongNullValue()
        {
            RoundTripSerializationWithDefaultsAndCheck<string>(@"[""null"", ""string""]", null, "0");
        }

        [TestMethod]
        [TestCategory("CheckIn")]
        [ExpectedException(typeof(SerializationException))]
        public void SchemaDefaultValues_RecordWithInvalidFields()
        {
            const string DefaultSchema =
                @"{""type"":""record"",""name"":""SomeRecord"",""fields"":[{""name"":""Field1"",""type"":""int""}, {""name"":""Field2"", ""type"":""string""}]}";
            var tempSerializer = AvroSerializer.CreateGeneric(DefaultSchema);
            dynamic defaultValue = new AvroRecord(tempSerializer.WriterSchema);
            defaultValue.Field1 = Utilities.GetRandom<int>(false);
            defaultValue.Field2 = "some string " + Utilities.GetRandom<int>(false);
            var defaultValueJson = @"{""Field1"":" + defaultValue.Field1 + @", ""Field2"":""" + defaultValue.Field2 +
                                       @""", ""WRONGFIELD"":""WRONGVALUE""}";
            RoundTripSerializationWithDefaultsAndCheck<AvroRecord>(
                DefaultSchema,
                defaultValue,
                defaultValueJson,
                (Action<dynamic, dynamic>)((expected, actual) =>
                {
                    Assert.AreEqual(expected.Field1, actual.Field1);
                    Assert.AreEqual(expected.Field2, actual.Field2);
                }));
        }

        [TestMethod]
        [TestCategory("CheckIn")]
        public void SchemaDefaultValues_RecordWithIntFieldHavingDefaultValue()
        {
            const string WriterSchema = @"{
                                              ""type"":""record"",
                                              ""name"":""Microsoft.Hadoop.Avro.Tests.SimpleIntClass"",
                                              ""fields"":
                                              [
                                                  {
                                                      ""name"":""IntField"",
                                                      ""type"":""int"",
                                                      ""default"": 0
                                                  }
                                              ]
                                          }";

            var serializer = AvroSerializer.CreateGeneric(WriterSchema);
            var deserializer = AvroSerializer.CreateGenericDeserializerOnly(WriterSchema, WriterSchema);

            using (var stream = new MemoryStream())
            {
                dynamic expected = new AvroRecord(serializer.ReaderSchema);
                expected.IntField = 1;

                serializer.Serialize(stream, expected);
                stream.Seek(0, SeekOrigin.Begin);

                dynamic actual = deserializer.Deserialize(stream);
                Assert.AreEqual(expected.IntField, actual.IntField);
            }
        }

        private static void RoundTripSerializationWithDefaultsAndCheck<TS>(string extraFieldSchema, TS extraFieldValue, string extraValueAsString)
        {
            RoundTripSerializationWithDefaultsAndCheck(
                extraFieldSchema,
                extraFieldValue,
                extraValueAsString,
                (expected, actual) => Assert.AreEqual(expected, actual));
        }

        private static void RoundTripSerializationWithDefaultsAndCheck<TS>(string extraFieldSchema, TS extraFieldValue)
        {
            RoundTripSerializationWithDefaultsAndCheck(
                extraFieldSchema,
                extraFieldValue,
                extraFieldValue.ToString(),
                (expected, actual) => Assert.AreEqual(expected, actual));
        }

        private static void RoundTripSerializationWithDefaultsAndCheck<TS>(
            string extraFieldSchema,
            TS extraFieldValue,
            string extraValueAsString,
            Action<dynamic, dynamic> check)
        {
            var readerSchema = @"{
                             ""type"":""record"",
                             ""name"":""Microsoft.Hadoop.Avro.Tests.SimpleIntClass"",
                             ""fields"":
                                       [
                                           {
                                               ""name"":""IntField"",
                                               ""type"":""int""
                                           },
                                           {
                                               ""name"":""ExtraField"",
                                               ""type"":" + extraFieldSchema + @",
                                               ""default"":" + extraValueAsString + @"
                                           }
                                       ]
                          }";

            var serializer = AvroSerializer.CreateGeneric(SimpleIntClassRecordSchema);
            var deserializer = AvroSerializer.CreateGenericDeserializerOnly(SimpleIntClassRecordSchema, readerSchema);

            using (var memoryStream = new MemoryStream())
            {
                dynamic expected = new AvroRecord(serializer.WriterSchema);
                expected.IntField = Utilities.GetRandom<int>(false);
                serializer.Serialize(memoryStream, expected);
                memoryStream.Seek(0, SeekOrigin.Begin);
                dynamic actual = deserializer.Deserialize(memoryStream);
                Assert.AreEqual(expected.IntField, actual.IntField);
                check(extraFieldValue, actual.ExtraField);
            }
        }
    }
}
