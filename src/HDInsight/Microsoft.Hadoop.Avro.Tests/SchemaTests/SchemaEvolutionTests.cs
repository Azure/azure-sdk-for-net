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
    using System.Runtime.Serialization;
    using Microsoft.Hadoop.Avro.Schema;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Microsoft.WindowsAzure.Management.HDInsight.TestUtilities;

    [TestClass]
    public sealed class SchemaEvolutionTests
    {
        private AvroSerializerSettings dataContractSettings;

        [TestInitialize]
        public void TestSetup()
        {
            this.dataContractSettings = new AvroSerializerSettings();
        }

        [TestMethod]
        [TestCategory("CheckIn")]
        public void SchemaEvolution_ArrayWithIdenticalElementType()
        {
            const string WriterSchema =
                                @"{
                                    ""type"":""array"",
                                    ""items"":""int""
                                }";

            var serializer = AvroSerializer.CreateGeneric(WriterSchema);
            var deserializer = AvroSerializer.CreateDeserializerOnly<int[]>(WriterSchema, new AvroSerializerSettings());

            using (var stream = new MemoryStream())
            {
                var expected = new int[] { 1, 2, 3, 4 };

                serializer.Serialize(stream, expected);
                stream.Position = 0;

                var actual = deserializer.Deserialize(stream);
                CollectionAssert.AreEqual(expected, actual);
            }
        }

        [TestMethod]
        [TestCategory("CheckIn")]
        public void SchemaEvolution_ArrayWithWriterIntPromotedToReaderLong()
        {
            const string WriterSchema =
                                @"{
                                    ""type"":""array"",
                                    ""items"":""int""
                                }";

            var serializer = AvroSerializer.CreateGeneric(WriterSchema);
            var deserializer = AvroSerializer.CreateDeserializerOnly<long[]>(WriterSchema, new AvroSerializerSettings());

            using (var stream = new MemoryStream())
            {
                var expected = new int[] { 1, 2, 3, 4 };

                serializer.Serialize(stream, expected);
                stream.Position = 0;

                var actual = deserializer.Deserialize(stream);
                CollectionAssert.AreEqual(Array.ConvertAll(expected, i => (long)i), actual);
            }
        }

        [TestMethod]
        [TestCategory("CheckIn")]
        public void SchemaEvolution_RecordWithPromotionalNumericFields()
        {
            const string WriterSchema =
            @"{
                 ""name"":""ClassWithPromotionalFields"",
                 ""namespace"":""Microsoft.Hadoop.Avro.Tests"",
                 ""type"":""record"",
                 ""fields"":
                           [
                                {""name"":""IntToLongField"", ""type"":""int""},
                                {""name"":""IntToFloatField"", ""type"":""int""},
                                {""name"":""IntToDoubleField"", ""type"":""int""},
                                {""name"":""LongToFloatField"", ""type"":""long""},
                                {""name"":""LongToDoubleField"", ""type"":""long""},
                                {""name"":""FloatToDoubleField"", ""type"":""float""}
                           ]
             }";

            var serializer = AvroSerializer.CreateGeneric(WriterSchema);
            var deserializer = AvroSerializer.CreateDeserializerOnly<ReaderClassWithPromotionalFields>(WriterSchema, this.dataContractSettings);

            using (var stream = new MemoryStream())
            {
                var random = new Random(13);
                dynamic expected = new AvroRecord(serializer.WriterSchema);
                expected.IntToLongField = random.Next();
                expected.IntToFloatField = random.Next();
                expected.IntToDoubleField = random.Next();
                expected.LongToFloatField = (long)random.Next();
                expected.LongToDoubleField = (long)random.Next();
                expected.FloatToDoubleField = (float)random.NextDouble();

                serializer.Serialize(stream, expected);
                stream.Position = 0;

                var actual = deserializer.Deserialize(stream);
                Assert.AreEqual(expected.IntToLongField, actual.IntToLongField);
                Assert.AreEqual(expected.IntToFloatField, actual.IntToFloatField);
                Assert.AreEqual(expected.IntToDoubleField, actual.IntToDoubleField);
                Assert.AreEqual(expected.LongToFloatField, actual.LongToFloatField);
                Assert.AreEqual(expected.LongToDoubleField, actual.LongToDoubleField);
                Assert.AreEqual(expected.FloatToDoubleField, actual.FloatToDoubleField);
            }
        }

        [SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity",
            Justification = "Tests complex hierarchy."), TestMethod]
        [TestCategory("CheckIn")]
        public void SchemaEvolution_RecordWithPermutatedAndMissingWriterFields()
        {
            const string WriterSchema =
            @"{
                 ""name"":""WriterClass"",
                 ""namespace"":""Microsoft.Hadoop.Avro.Tests"",
                 ""type"":""record"",
                 ""fields"":
                           [
                                {""name"":""BoolA"", ""type"":""boolean""},
                                {""name"":""BoolB"", ""type"":""boolean""},
                                {""name"":""FloatA"", ""type"":""float""},
                                {""name"":""FloatB"", ""type"":""float""},
                                {""name"":""DoubleA"", ""type"":""double""},
                                {""name"":""DoubleB"", ""type"":""double""},
                                {""name"":""IntA"", ""type"":""int""},
                                {""name"":""IntB"", ""type"":""int""},
                                {""name"":""MyGuid"", ""type"": {""type"":""fixed"", ""size"":16, ""name"": ""q"" }},
                                {""name"": ""classField"", ""type"" : [ ""null"", ""Microsoft.Hadoop.Avro.Tests.WriterClass""] },
                                {""name"":""Arr"", ""type"": {""type"":""array"", ""items"":""int""}},
                                {""name"":""LongField"", ""type"":""long""},
                                {""name"":""LongMap"", ""type"": {""type"":""map"", ""values"":""long""}},
                                {""name"":""BytesField"", ""type"":""bytes""},
                           ]
             }";

            var serializer = AvroSerializer.CreateGeneric(WriterSchema);
            var deserializer = AvroSerializer.CreateDeserializerOnly<WriterClassWithPermutatedFields>(WriterSchema, this.dataContractSettings);

            using (var stream = new MemoryStream())
            {
                dynamic expected = new AvroRecord(serializer.WriterSchema);
                expected.BoolA = Utilities.GetRandom<bool>(false);
                expected.BoolB = Utilities.GetRandom<bool>(false);
                expected.FloatA = Utilities.GetRandom<float>(false);
                expected.FloatB = Utilities.GetRandom<float>(false);
                expected.DoubleA = Utilities.GetRandom<double>(false);
                expected.DoubleB = Utilities.GetRandom<double>(false);
                expected.IntA = Utilities.GetRandom<int>(false);
                expected.IntB = Utilities.GetRandom<int>(false);
                expected.MyGuid = Utilities.GetRandom<Guid>(false).ToByteArray();
                expected.Arr = Utilities.GetRandom<int[]>(false);
                expected.LongField = Utilities.GetRandom<long>(false);
                expected.LongMap = Utilities.GetRandom<Dictionary<string, long>>(false);
                expected.BytesField = Utilities.GetRandom<byte[]>(false);

                expected.classField = new AvroRecord(serializer.WriterSchema);
                expected.classField.BoolA = Utilities.GetRandom<bool>(false);
                expected.classField.BoolB = Utilities.GetRandom<bool>(false);
                expected.classField.FloatA = Utilities.GetRandom<float>(false);
                expected.classField.FloatB = Utilities.GetRandom<float>(false);
                expected.classField.DoubleA = Utilities.GetRandom<double>(false);
                expected.classField.DoubleB = Utilities.GetRandom<double>(false);
                expected.classField.IntA = Utilities.GetRandom<int>(false);
                expected.classField.IntB = Utilities.GetRandom<int>(false);
                expected.classField.MyGuid = Utilities.GetRandom<Guid>(false).ToByteArray();
                expected.classField.Arr = Utilities.GetRandom<int[]>(false);
                expected.classField.classField = null;
                expected.classField.LongField = Utilities.GetRandom<long>(false);
                expected.classField.LongMap = Utilities.GetRandom<Dictionary<string, long>>(false);
                expected.classField.BytesField = Utilities.GetRandom<byte[]>(false);

                serializer.Serialize(stream, expected);
                stream.Position = 0;

                var actual = deserializer.Deserialize(stream);
                Assert.AreEqual(expected.DoubleB, actual.DoubleB);
                Assert.AreEqual(expected.FloatB, actual.FloatB);
                Assert.AreEqual(expected.FloatA, actual.FloatA);
                Assert.AreEqual(expected.BoolB, actual.BoolB);
                Assert.AreEqual(expected.BoolA, actual.BoolA);
                Assert.AreEqual(expected.DoubleA, actual.DoubleA);
            }
        }

        [SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity",
            Justification = "Tests complex hierarchy."), TestMethod]
        [TestCategory("CheckIn")]
        public void SchemaEvolution_RecordSkippers()
        {
            const string WriterSchema =
            @"{
                 ""name"":""WriterClass"",
                 ""namespace"":""Microsoft.Hadoop.Avro.Tests"",
                 ""type"":""record"",
                 ""fields"":
                           [
                                {""name"":""Existing"", ""type"":""boolean""},
                                {""name"":""BoolField"", ""type"":""boolean""},
                                {""name"":""FloatField"", ""type"":""float""},
                                {""name"":""DoubleField"", ""type"":""double""},
                                {""name"":""IntField"", ""type"":""int""},
                                {""name"":""GuidField"", ""type"": {""type"":""fixed"", ""size"":16, ""name"": ""q"" }},
                                {""name"": ""classField"", ""type"" : [ ""null"", ""Microsoft.Hadoop.Avro.Tests.WriterClass""] },
                                {""name"":""ArrayField"", ""type"": {""type"":""array"", ""items"":""int""}},
                                {""name"":""LongField"", ""type"":""long""},
                                {""name"":""LongMap"", ""type"": {""type"":""map"", ""values"":""long""}},
                                {""name"":""BytesField"", ""type"":""bytes""},
                                {""name"":""AnotherExisting"", ""type"":""int""},
                           ]
             }";

            const string ReaderSchema =
            @"{
                 ""name"":""WriterClass"",
                 ""namespace"":""Microsoft.Hadoop.Avro.Tests"",
                 ""type"":""record"",
                 ""fields"":
                           [
                                {""name"":""Existing"", ""type"":""boolean""},
                                {""name"":""AnotherExisting"", ""type"":""int""},
                           ]
             }";

            var serializer = AvroSerializer.CreateGeneric(WriterSchema);
            var deserializer = AvroSerializer.CreateGenericDeserializerOnly(WriterSchema, ReaderSchema);

            using (var stream = new MemoryStream())
            {
                dynamic expected = new AvroRecord(serializer.WriterSchema);
                expected.Existing = true;
                expected.BoolField = Utilities.GetRandom<bool>(false);
                expected.FloatField = Utilities.GetRandom<float>(false);
                expected.DoubleField = Utilities.GetRandom<double>(false);
                expected.IntField = Utilities.GetRandom<int>(false);
                expected.GuidField = new byte[16];
                expected.ArrayField = new int[] { 1, 2, 3 };
                expected.LongField = (long)13;
                expected.LongMap = new Dictionary<string, long> { { "test", 1 } };
                expected.BytesField = new byte[3] { 4, 5, 6 };
                expected.AnotherExisting = Utilities.GetRandom<int>(false);

                expected.classField = new AvroRecord(serializer.WriterSchema);
                expected.classField.Existing = Utilities.GetRandom<bool>(false);
                expected.classField.BoolField = Utilities.GetRandom<bool>(false);
                expected.classField.FloatField = Utilities.GetRandom<float>(false);
                expected.classField.DoubleField = Utilities.GetRandom<double>(false);
                expected.classField.IntField = Utilities.GetRandom<int>(false);
                expected.classField.GuidField = new byte[16];
                expected.classField.ArrayField = new int[] { 1, 2, 3 };
                expected.classField.LongField = (long)13;
                expected.classField.LongMap = new Dictionary<string, long> { { "test", 1 } };
                expected.classField.BytesField = new byte[3] { 4, 5, 6 };
                expected.classField.AnotherExisting = 13;
                expected.classField.classField = null;

                serializer.Serialize(stream, expected);
                stream.Position = 0;

                dynamic actual = deserializer.Deserialize(stream);
                Assert.AreEqual(expected.Existing, actual.Existing);
                Assert.AreEqual(expected.AnotherExisting, actual.AnotherExisting);
            }
        }

        [TestMethod]
        [TestCategory("CheckIn")]
        public void SchemaEvolution_RecordWithIdenticalFields()
        {
            const string WriterSchema = @"{
                             ""type"":""record"",
                             ""name"":""Microsoft.Hadoop.Avro.Tests.ClassOfInt"",
                             ""fields"":
                                       [
                                           {""name"":""PrimitiveInt"", ""type"":""int""}
                                       ]
                          }";

            var serializer = AvroSerializer.CreateGeneric(WriterSchema);
            var deserializer = AvroSerializer.CreateDeserializerOnly<ClassOfInt>(WriterSchema, this.dataContractSettings);

            using (var stream = new MemoryStream())
            {
                dynamic expected = new AvroRecord(serializer.WriterSchema);
                expected.PrimitiveInt = 5;

                serializer.Serialize(stream, expected);
                stream.Position = 0;

                var actual = deserializer.Deserialize(stream);
                Assert.AreEqual(expected.PrimitiveInt, actual.PrimitiveInt);
            }
        }

        [TestCategory("CheckIn")]
        public void TestRecordEvolutionWithExtraReaderFieldsAndDefaultValues()
        {
            const string WriterSchema = @"{
                             ""type"":""record"",
                             ""name"":""Microsoft.Hadoop.Avro.Tests.ClassOfInt"",
                             ""fields"":
                                       [
                                           {
                                               ""name"":""PrimitiveInt"",
                                               ""type"":""int""
                                           }
                                       ]
                          }";

            var serializer = AvroSerializer.CreateGeneric(WriterSchema);
            var deserializer = AvroSerializer.CreateDeserializerOnly<SimpleIntClassWithExtraFields>(WriterSchema, this.dataContractSettings);

            using (var stream = new MemoryStream())
            {
                dynamic expected = new AvroRecord(serializer.WriterSchema);
                expected.IntField = 4;

                serializer.Serialize(stream, expected);
                stream.Seek(0, SeekOrigin.Begin);

                dynamic actual = deserializer.Deserialize(stream);
                Assert.AreEqual(actual.ExtraFieldInt, 0);
                Assert.AreEqual(actual.ExtraFieldLong, 0);
                Assert.AreEqual(actual.ExtraFieldFloat, 0.0f);
                Assert.AreEqual(actual.ExtraFieldDouble, 0.0d);
                Assert.AreEqual(actual.ExtraFieldString, null);
                Assert.AreEqual(actual.ExtraFieldBool, false);
                Assert.AreEqual(expected.IntField, actual.IntField);
            }
        }

        [TestMethod]
        [TestCategory("CheckIn")]
        [ExpectedException(typeof(SerializationException))]
        public void SchemaEvolution_RecordWithIncompatibleReaderAndWriterValueTypes()
        {
            const string WriterSchema = @"{
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

            var serializer = AvroSerializer.CreateGeneric(WriterSchema);
            var deserializer = AvroSerializer.CreateDeserializerOnly<SimpleIntClassWithStringFieldType>(WriterSchema, this.dataContractSettings);
            Assert.Fail();
        }

        [TestMethod]
        [TestCategory("CheckIn")]
        public void SchemaEvolution_RecordWithNoMatchedFields()
        {
            const string WriterSchema = @"{
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

            var serializer = AvroSerializer.CreateGeneric(WriterSchema);
            var deserializer = AvroSerializer.CreateDeserializerOnly<SimpleIntClassWithDifferentFieldName>(WriterSchema, this.dataContractSettings);
        }

        [TestMethod]
        [TestCategory("CheckIn")]
        public void SchemaEvolution_RecordWithAliasRelativeToNamespace()
        {
            const string WriterSchema =
                        @"{
                             ""type"":""record"",
                             ""name"":""Microsoft.Hadoop.Avro.Tests.SimpleIntClass"",
                             ""fields"":
                                       [
                                           {""name"":""IntField"", ""type"":""int""}
                                       ]
                          }";

            const string ReaderSchema =
                        @"{
                            ""type"":""record"",
                            ""name"":""Microsoft.Hadoop.Avro.Tests.IntClassNewName"",
                            ""aliases"":[""SimpleIntClass""],
                            ""fields"":
                                    [
                                        {""name"":""IntField"",""type"":""int""},
                                    ]
                        }";

            var serializer = AvroSerializer.CreateGeneric(WriterSchema);
            var deserializer = AvroSerializer.CreateGenericDeserializerOnly(WriterSchema, ReaderSchema);

            using (var stream = new MemoryStream())
            {
                dynamic expected = new AvroRecord(serializer.WriterSchema);
                expected.IntField = 1;

                serializer.Serialize(stream, expected);
                stream.Seek(0, SeekOrigin.Begin);

                dynamic actual = deserializer.Deserialize(stream);
                Assert.AreEqual(expected.IntField, actual.IntField);
            }
        }

        [TestMethod]
        [TestCategory("CheckIn")]
        public void SchemaEvolution_RecordWithMemberOrderChanged()
        {
            var settings = new AvroSerializerSettings() { Resolver = new AvroDataContractResolver(true, true) };
            var serializer = AvroSerializer.Create<Rectangle>(settings);
            var deserializer = AvroSerializer.Create<AnotherRectangle>(settings);

            using (var stream = new MemoryStream())
            {
                Rectangle expected = Rectangle.Create();
                serializer.Serialize(stream, expected);
                stream.Seek(0, SeekOrigin.Begin);

                AnotherRectangle actual = deserializer.Deserialize(stream);
                Assert.AreEqual(expected.Width, actual.Width);
                Assert.AreEqual(expected.Height, actual.Height);
            }
        }

        [TestMethod]
        [TestCategory("CheckIn")]
        public void SchemaEvolution_SerializeWithoutGetter()
        {
            try
            {
                AvroSerializer.Create<AbstractNoGetter>();
            }
            catch (SerializationException ex)
            {
                Assert.AreEqual(true, ex.Message.Contains("Microsoft.Hadoop.Avro.Tests.NoGetter"));
            }
        }

        [TestMethod]
        [TestCategory("CheckIn")]
        public void SchemaEvolution_RecordWithFullyQualifiedAlias()
        {
            const string WriterSchema =
                        @"{
                             ""type"":""record"",
                             ""name"":""Microsoft.Hadoop.Avro.Tests.SimpleIntClass"",
                             ""fields"":
                                       [
                                           {""name"":""IntField"", ""type"":""int""}
                                       ]
                          }";

            const string ReaderSchema =
                        @"{
                            ""type"":""record"",
                            ""name"":""Microsoft.Hadoop.Avro.Tests.IntClassNewName"",
                            ""aliases"":[""Microsoft.Hadoop.Avro.Tests.SimpleIntClass""],
                            ""fields"":
                                    [
                                        {""name"":""IntField"",""type"":""int""},
                                    ]
                        }";

            var serializer = AvroSerializer.CreateGeneric(WriterSchema);
            var deserializer = AvroSerializer.CreateGenericDeserializerOnly(WriterSchema, ReaderSchema);

            using (var stream = new MemoryStream())
            {
                dynamic expected = new AvroRecord(serializer.WriterSchema);
                expected.IntField = 1;

                serializer.Serialize(stream, expected);
                stream.Seek(0, SeekOrigin.Begin);

                dynamic actual = deserializer.Deserialize(stream);
                Assert.AreEqual(expected.IntField, actual.IntField);
            }
        }

        [TestMethod]
        [TestCategory("CheckIn")]
        public void SchemaEvolution_RecordWithUnionWriterAndUnionReaderContainingMoreOptions()
        {
            const string WriterSchema =
           @"{
                 ""name"":""Category"",
                 ""namespace"":""ApacheAvro.Types"",
                 ""type"":""record"",
                 ""fields"":
                           [
                                {""name"":""CategoryName"", ""type"":""string""},
                                {""name"":""Description"", ""type"":[""string"",""null""]},
                                {""name"":""Picture"", ""type"":[""bytes"", ""null""]},
                                {""name"":""Id"", ""type"":[""int"", ""null""]}
                           ]
             }";

            const string ReaderSchema =
           @"{
                 ""name"":""Category"",
                 ""namespace"":""ApacheAvro.Types"",
                 ""type"":""record"",
                 ""fields"":
                           [
                                {""name"":""CategoryName"", ""type"":""string""},
                                {""name"":""Description"", ""type"":[""null"", ""string""]},
                                {""name"":""Picture"", ""type"":[""string"",""bytes"", ""null""]},
                                {""name"":""Id"", ""type"":[""int"", ""null""]}
                           ]
             }";

            var serializer = AvroSerializer.CreateGeneric(WriterSchema);
            var deserializer = AvroSerializer.CreateGenericDeserializerOnly(WriterSchema, ReaderSchema);

            using (var stream = new MemoryStream())
            {
                dynamic expected = new AvroRecord(serializer.WriterSchema);
                expected.CategoryName = "Test";
                expected.Description = "Test";
                expected.Picture = new byte[] { 0x10, 0x20, 0x30, 0x40 };
                expected.Id = 1;

                serializer.Serialize(stream, expected);
                stream.Seek(0, SeekOrigin.Begin);

                dynamic actual = deserializer.Deserialize(stream);
                Assert.AreEqual(expected.CategoryName, actual.CategoryName);
                Assert.AreEqual(expected.Description, actual.Description);
                CollectionAssert.AreEqual(expected.Picture, actual.Picture);
            }
        }

        [TestMethod]
        [TestCategory("CheckIn")]
        public void SchemaEvolution_RecordWithUnionReaderAndNonUnionWriter()
        {
            const string WriterSchema =
           @"{
                 ""name"":""Category"",
                 ""namespace"":""ApacheAvro.Types"",
                 ""type"":""record"",
                 ""fields"":
                           [
                                {""name"":""CategoryName"", ""type"":""string""},
                                {""name"":""Description"", ""type"":""string""},
                                {""name"":""Picture"", ""type"":""bytes""},
                                {""name"":""Id"", ""type"":""int""}
                           ]
             }";

            const string ReaderSchema =
           @"{
                 ""name"":""Category"",
                 ""namespace"":""ApacheAvro.Types"",
                 ""type"":""record"",
                 ""fields"":
                           [
                                {""name"":""CategoryName"", ""type"":""string""},
                                {""name"":""Description"", ""type"":[""null"", ""string""]},
                                {""name"":""Picture"", ""type"":[""bytes"", ""null""]},
                                {""name"":""Id"", ""type"":[""int"", ""null""]}
                           ]
             }";

            var serializer = AvroSerializer.CreateGeneric(WriterSchema);
            var deserializer = AvroSerializer.CreateGenericDeserializerOnly(WriterSchema, ReaderSchema);

            using (var stream = new MemoryStream())
            {
                dynamic expected = new AvroRecord(serializer.WriterSchema);
                expected.CategoryName = "Test";
                expected.Description = "Test";
                expected.Picture = new byte[] { 0x10, 0x20, 0x30, 0x40 };
                expected.Id = 1;

                serializer.Serialize(stream, expected);
                stream.Seek(0, SeekOrigin.Begin);

                dynamic actual = deserializer.Deserialize(stream);
                Assert.AreEqual(expected.CategoryName, actual.CategoryName);
                Assert.AreEqual(expected.Description, actual.Description);
                CollectionAssert.AreEqual(expected.Picture, actual.Picture);
            }
        }

        [TestMethod]
        [TestCategory("CheckIn")]
        public void SchemaEvolution_RecordWithNonUnionReaderAndUnionWriter()
        {
            const string WriterSchema =
           @"{
                 ""name"":""Category"",
                 ""namespace"":""ApacheAvro.Types"",
                 ""type"":""record"",
                 ""fields"":
                           [
                                {""name"":""CategoryName"", ""type"":""string""},
                                {""name"":""Description"", ""type"":[""null"", ""string""]},
                                {""name"":""Picture"", ""type"":[""bytes"", ""null""]},
                                {""name"":""Id"", ""type"":[""int"", ""null""]}
                           ]
             }";

            const string ReaderSchema =
           @"{
                 ""name"":""Category"",
                 ""namespace"":""ApacheAvro.Types"",
                 ""type"":""record"",
                 ""fields"":
                           [
                                {""name"":""CategoryName"", ""type"":""string""},
                                {""name"":""Description"", ""type"":""string""},
                                {""name"":""Picture"", ""type"":""bytes""},
                                {""name"":""Id"", ""type"":""int""}
                           ]
             }";

            var serializer = AvroSerializer.CreateGeneric(WriterSchema);
            var deserializer = AvroSerializer.CreateGenericDeserializerOnly(WriterSchema, ReaderSchema);

            using (var stream = new MemoryStream())
            {
                dynamic expected = new AvroRecord(serializer.WriterSchema);
                expected.CategoryName = "Test";
                expected.Description = "Test";
                expected.Picture = new byte[] { 0x10, 0x20, 0x30, 0x40 };
                expected.Id = 1;

                serializer.Serialize(stream, expected);
                stream.Seek(0, SeekOrigin.Begin);

                dynamic actual = deserializer.Deserialize(stream);
                Assert.AreEqual(expected.CategoryName, actual.CategoryName);
                Assert.AreEqual(expected.Description, actual.Description);
                CollectionAssert.AreEqual(expected.Picture, actual.Picture);
            }
        }

        [TestMethod]
        [TestCategory("CheckIn")]
        [ExpectedException(typeof(SerializationException))]
        public void SchemaEvolution_RecordWithWrongUnionReaderAndUnionWriter()
        {
            const string WriterSchema =
           @"{
                 ""name"":""Category"",
                 ""namespace"":""ApacheAvro.Types"",
                 ""type"":""record"",
                 ""fields"":
                           [
                                {""name"":""CategoryName"", ""type"":""string""},
                                {""name"":""Id"", ""type"":[""int"", ""null""]}
                           ]
             }";

            const string ReaderSchema =
           @"{
                 ""name"":""Category"",
                 ""namespace"":""ApacheAvro.Types"",
                 ""type"":""record"",
                 ""fields"":
                           [
                                {""name"":""CategoryName"", ""type"":""string""},
                                {""name"":""Id"", ""type"":[""string"", ""null""]}
                           ]
             }";

            var serializer = AvroSerializer.CreateGeneric(WriterSchema);
            var deserializer = AvroSerializer.CreateGenericDeserializerOnly(WriterSchema, ReaderSchema);

            using (var stream = new MemoryStream())
            {
                dynamic expected = new AvroRecord(serializer.WriterSchema);
                expected.CategoryName = "Test";
                expected.Description = "Test";
                expected.Picture = new byte[] { 0x10, 0x20, 0x30, 0x40 };
                expected.Id = 1;

                serializer.Serialize(stream, expected);
                stream.Seek(0, SeekOrigin.Begin);

                dynamic actual = deserializer.Deserialize(stream);
                Assert.AreEqual(expected.CategoryName, actual.CategoryName);
                Assert.AreEqual(expected.Description, actual.Description);
                CollectionAssert.AreEqual(expected.Picture, actual.Picture);
            }
        }

        [TestMethod]
        [TestCategory("CheckIn")]
        [ExpectedException(typeof(SerializationException))]
        public void SchemaEvolution_RecordWithWrongNonUnionReaderAndUnionWriter()
        {
            const string WriterSchema =
           @"{
                 ""name"":""Category"",
                 ""namespace"":""ApacheAvro.Types"",
                 ""type"":""record"",
                 ""fields"":
                           [
                                {""name"":""CategoryName"", ""type"":""string""},
                                {""name"":""Description"", ""type"":[""null"", ""string""]},
                                {""name"":""Picture"", ""type"":[""bytes"", ""null""]},
                                {""name"":""Id"", ""type"":[""int"", ""null""]}
                           ]
             }";

            const string ReaderSchema =
           @"{
                 ""name"":""Category"",
                 ""namespace"":""ApacheAvro.Types"",
                 ""type"":""record"",
                 ""fields"":
                           [
                                {""name"":""CategoryName"", ""type"":""string""},
                                {""name"":""Description"", ""type"":""string""},
                                {""name"":""Picture"", ""type"":""string""},
                                {""name"":""Id"", ""type"":""int""}
                           ]
             }";

            var serializer = AvroSerializer.CreateGeneric(WriterSchema);
            var deserializer = AvroSerializer.CreateGenericDeserializerOnly(WriterSchema, ReaderSchema);

            using (var stream = new MemoryStream())
            {
                dynamic expected = new AvroRecord(serializer.WriterSchema);
                expected.CategoryName = "Test";
                expected.Description = "Test";
                expected.Picture = new byte[] { 0x10, 0x20, 0x30, 0x40 };
                expected.Id = 1;

                serializer.Serialize(stream, expected);
                stream.Seek(0, SeekOrigin.Begin);

                dynamic actual = deserializer.Deserialize(stream);
                Assert.AreEqual(expected.CategoryName, actual.CategoryName);
                Assert.AreEqual(expected.Description, actual.Description);
                CollectionAssert.AreEqual(expected.Picture, actual.Picture);
            }
        }

        [TestMethod]
        [TestCategory("CheckIn")]
        [ExpectedException(typeof(SerializationException))]
        public void SchemaEvolution_RecordWithWrongUnionReaderAndNonUnionWriter()
        {
            const string WriterSchema =
           @"{
                 ""name"":""Category"",
                 ""namespace"":""ApacheAvro.Types"",
                 ""type"":""record"",
                 ""fields"":
                           [
                                {""name"":""CategoryName"", ""type"":""string""},
                                {""name"":""Description"", ""type"":""string""},
                                {""name"":""Picture"", ""type"":""bytes""},
                                {""name"":""Id"", ""type"":""int""}
                           ]
             }";

            const string ReaderSchema =
           @"{
                 ""name"":""Category"",
                 ""namespace"":""ApacheAvro.Types"",
                 ""type"":""record"",
                 ""fields"":
                           [
                                {""name"":""CategoryName"", ""type"":""string""},
                                {""name"":""Id"", ""type"":[""string"", ""null""]}
                           ]
             }";

            var serializer = AvroSerializer.CreateGeneric(WriterSchema);
            var deserializer = AvroSerializer.CreateGenericDeserializerOnly(WriterSchema, ReaderSchema);

            using (var stream = new MemoryStream())
            {
                dynamic expected = new AvroRecord(serializer.WriterSchema);
                expected.CategoryName = "Test";
                expected.Description = "Test";
                expected.Picture = new byte[] { 0x10, 0x20, 0x30, 0x40 };
                expected.Id = 1;

                serializer.Serialize(stream, expected);
                stream.Seek(0, SeekOrigin.Begin);

                dynamic actual = deserializer.Deserialize(stream);
                Assert.AreEqual(expected.CategoryName, actual.CategoryName);
                Assert.AreEqual(expected.Description, actual.Description);
                CollectionAssert.AreEqual(expected.Picture, actual.Picture);
            }
        }

        [TestMethod]
        [TestCategory("CheckIn")]
        [ExpectedException(typeof(SerializationException))]
        public void SchemaEvolution_EnumCaseSensitiveSymbolMatching()
        {
            const string WriterSchema = @"{ 
                ""type"": ""enum"",
                ""name"": ""Suit"",
                ""namespace"":""Microsoft.Hadoop.Avro.Tests"",
                ""symbols"" : [""Spades"", ""Hearts"", ""Diamonds"", ""Clubs""]}";

            var serializer = AvroSerializer.CreateGeneric(WriterSchema);
            var deserializer = AvroSerializer.CreateDeserializerOnly<SuitAllCaps>(WriterSchema, this.dataContractSettings);
            Assert.Fail();
        }

        [TestMethod]
        [TestCategory("CheckIn")]
        [ExpectedException(typeof(SerializationException))]
        public void SchemaEvolution_EnumMatchingWithMissingWriterSymbols()
        {
            const string WriterSchema = @"{ 
                ""type"": ""enum"",
                ""name"": ""Suit"",
                ""namespace"":""Microsoft.Hadoop.Avro.Tests"",
                ""symbols"" : [""Spades"", ""Hearts"", ""Diamonds"", ""Clubs""]}";

            var serializer = AvroSerializer.CreateGeneric(WriterSchema);
            var deserializer = AvroSerializer.CreateDeserializerOnly<SuitMissingSymbols>(WriterSchema, this.dataContractSettings);
            Assert.Fail();
        }

        [TestMethod]
        [TestCategory("CheckIn")]
        [ExpectedException(typeof(SerializationException))]
        public void SchemaEvolution_EnumMatchingWithDifferentNames()
        {
            const string WriterSchema = @"{ 
                ""type"": ""enum"",
                ""name"": ""MySuit"",
                ""namespace"":""Microsoft.Hadoop.Avro.Tests"",
                ""symbols"" : [""Spades"", ""Hearts"", ""Diamonds"", ""Clubs""]}";

            var serializer = AvroSerializer.CreateGeneric(WriterSchema);
            var deserializer = AvroSerializer.CreateDeserializerOnly<Suit>(WriterSchema, this.dataContractSettings);
            Assert.Fail();
        }

        [TestMethod]
        [TestCategory("CheckIn")]
        public void SchemaEvolution_EnumWithExtraReaderSymbols()
        {
            const string WriterSchema = @"{
                ""type"": ""enum"",
                ""name"": ""Suit"",
                ""namespace"":""Microsoft.Hadoop.Avro.Tests"",
                ""symbols"" : [""Spades"", ""Hearts"", ""Diamonds"", ""Clubs""]}";

            var serializer = AvroSerializer.CreateGeneric(WriterSchema);
            var deserializer = AvroSerializer.CreateDeserializerOnly<SuitWithExtraFields>(WriterSchema, this.dataContractSettings);

            using (var stream = new MemoryStream())
            {
                dynamic expected = new AvroEnum(serializer.WriterSchema);
                expected.Value = "Spades";

                serializer.Serialize(stream, expected);
                stream.Seek(0, SeekOrigin.Begin);

                var actual = deserializer.Deserialize(stream);
                Assert.AreEqual(expected.Value, actual.ToString());
            }
        }

        [TestMethod]
        [TestCategory("CheckIn")]
        public void SchemaEvolution_CompatibleConversionOfFixedRecordToGuid()
        {
            const string WriterSchema = @"{ 
                ""type"": ""fixed"",
                ""name"": ""Guid"",
                ""namespace"":""System"",
                ""size"":16}";

            var serializer = AvroSerializer.CreateGeneric(WriterSchema);
            var deserializer = AvroSerializer.CreateDeserializerOnly<Guid>(WriterSchema, this.dataContractSettings);

            using (var stream = new MemoryStream())
            {
                var expected = new byte[]
                {
                    0x00, 0x01, 0x02, 0x03, 0x04, 0x05, 0x06, 0x07,
                    0x08, 0x09, 0x0A, 0x0B, 0x0C, 0x0D, 0x0E, 0x0F
                };

                serializer.Serialize(stream, expected);
                stream.Seek(0, SeekOrigin.Begin);

                var actual = deserializer.Deserialize(stream);
                CollectionAssert.AreEqual(expected, actual.ToByteArray());
            }
        }

        [TestMethod]
        [TestCategory("CheckIn")]
        public void SchemaEvolution_CompatibleConversionOfDictionaryRecordToDictionaryClass()
        {
            const string WriterSchema = @"{
                ""type"":""record"",
                ""name"":""SimpleMap"",
                ""namespace"":""Microsoft.Hadoop.Avro.Tests"",
                ""fields"":[
                    {""name"":""Values"",""type"":{""type"": ""map"",""values"": ""string""}}
                ]}";

            var serializer = AvroSerializer.CreateGeneric(WriterSchema);
            var deserializer = AvroSerializer.CreateDeserializerOnly<SimpleMap>(WriterSchema, this.dataContractSettings);

            using (var stream = new MemoryStream())
            {
                dynamic expected = new AvroRecord(serializer.WriterSchema);
                expected.Values = new Dictionary<string, object>();
                expected.Values.Add("key1", "value1");
                expected.Values.Add("key2", "value2");

                serializer.Serialize(stream, expected);
                stream.Seek(0, SeekOrigin.Begin);

                var actual = deserializer.Deserialize(stream);
                Assert.AreEqual(expected.Values["key1"], actual.Values["key1"]);
                Assert.AreEqual(expected.Values["key2"], actual.Values["key2"]);
                Assert.AreEqual(expected.Values.Count, actual.Values.Count);
                Assert.AreEqual(2, actual.Values.Count);
            }
        }

        [TestMethod]
        [TestCategory("CheckIn")]
        public void SchemaEvolution_CompatiblePromotionOfDictionaryRecordOfIntToDictionaryOfLong()
        {
            const string WriterSchema = @"{
                ""type"":""record"",
                ""name"":""SimpleMap"",
                ""namespace"":""Microsoft.Hadoop.Avro.Tests"",
                ""fields"":[
                    {""name"":""Values"",""type"":{""type"": ""map"",""values"": ""int""}}
                ]}";

            var serializer = AvroSerializer.CreateGeneric(WriterSchema);
            var deserializer = AvroSerializer.CreateDeserializerOnly<SimpleMapWithLongValues>(WriterSchema, this.dataContractSettings);

            using (var stream = new MemoryStream())
            {
                dynamic expected = new AvroRecord(serializer.WriterSchema);
                expected.Values = new Dictionary<string, int>();
                expected.Values.Add("key1", 1);
                expected.Values.Add("key2", 2);

                serializer.Serialize(stream, expected);
                stream.Seek(0, SeekOrigin.Begin);

                var actual = deserializer.Deserialize(stream);
                Assert.AreEqual(expected.Values["key1"], actual.Values["key1"]);
                Assert.AreEqual(expected.Values["key2"], actual.Values["key2"]);
                Assert.AreEqual(expected.Values.Count, actual.Values.Count);
                Assert.AreEqual(2, actual.Values.Count);
            }
        }

        [TestMethod]
        [TestCategory("CheckIn")]
        [ExpectedException(typeof(SerializationException))]
        public void SchemaEvolution_IncompatibleReaderAndWriterValueTypes()
        {
            const string WriterSchema = @"{
                ""type"":""record"",
                ""name"":""SimpleMap"",
                ""namespace"":""Microsoft.Hadoop.Avro.Tests"",
                ""fields"":[
                    {""name"":""Values"",""type"":{""type"": ""map"",""values"": ""string""}}
                ]}";

            AvroSerializer.CreateGeneric(WriterSchema);
            AvroSerializer.CreateDeserializerOnly<SimpleMapWithLongValues>(WriterSchema, this.dataContractSettings);
            Assert.Fail();
        }

        [SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity",
            Justification = "Have to compare a typed object to dynamic one, this leads to a lot of Asserts")]
        [TestMethod]
        [TestCategory("CheckIn")]
        public void SchemaEvolution_MapEvolutionWithRecordContainingPromotionalTypes()
        {
            const string WriterSchema =
            @"{
                ""type"":""record"",
                ""name"":""SimpleMap"",
                ""namespace"":""Microsoft.Hadoop.Avro.Tests"",
                ""fields"":
                [
                    {
                        ""name"":""Values"",
                        ""type"":
                        {
                            ""type"": ""map"",
                            ""values"":
                            {
                                ""type"":""record"",
                                ""name"":""ClassWithPromotionalFields"",
                                ""namespace"":""Microsoft.Hadoop.Avro.Tests"",
                                ""fields"":
                                [
                                    {""name"":""IntToLongField"",""type"":""int""},
                                    {""name"":""IntToFloatField"",""type"":""int""},
                                    {""name"":""IntToDoubleField"",""type"":""int""},
                                    {""name"":""LongToFloatField"",""type"":""long""},
                                    {""name"":""LongToDoubleField"",""type"":""long""},
                                    {""name"":""FloatToDoubleField"",""type"":""float""}
                                ]
                            }
                        }
                    }
                ]
            }";

            var serializer = AvroSerializer.CreateGeneric(WriterSchema);
            var deserializer = AvroSerializer.CreateDeserializerOnly<SimpleMapWithReaderClassWithPromotionalFields>(WriterSchema, this.dataContractSettings);

            using (var stream = new MemoryStream())
            {
                var valueSchema = ((serializer.WriterSchema as RecordSchema).GetField("Values").TypeSchema as MapSchema).ValueSchema;
                dynamic expected = new AvroRecord(serializer.WriterSchema);
                dynamic valueRecord = new AvroRecord(valueSchema);
                valueRecord.IntToLongField = 1;
                valueRecord.IntToFloatField = 2;
                valueRecord.IntToDoubleField = 3;
                valueRecord.LongToFloatField = 4L;
                valueRecord.LongToDoubleField = 5L;
                valueRecord.FloatToDoubleField = 6.0f;

                expected.Values = new Dictionary<string, AvroRecord>();
                expected.Values.Add("key1", valueRecord);

                serializer.Serialize(stream, expected);
                stream.Seek(0, SeekOrigin.Begin);

                var actual = deserializer.Deserialize(stream);
                Assert.AreEqual(expected.Values["key1"].IntToLongField, actual.Values["key1"].IntToLongField);
                Assert.AreEqual(expected.Values["key1"].IntToFloatField, actual.Values["key1"].IntToFloatField);
                Assert.AreEqual(expected.Values["key1"].IntToDoubleField, actual.Values["key1"].IntToDoubleField);
                Assert.AreEqual(expected.Values["key1"].LongToFloatField, actual.Values["key1"].LongToFloatField);
                Assert.AreEqual(expected.Values["key1"].LongToDoubleField, actual.Values["key1"].LongToDoubleField);
                Assert.AreEqual(expected.Values["key1"].FloatToDoubleField, actual.Values["key1"].FloatToDoubleField);
            }
        }

        [TestMethod]
        [TestCategory("CheckIn")]
        [ExpectedException(typeof(SerializationException))]
        public void SchemaEvolution_IncompatibleReaderSchemaAndWriterSchema()
        {
            const string WriterSchema =
            @"{
                 ""name"":""OldName"",
                 ""namespace"":""Microsoft.Hadoop.Avro.Tests"",
                 ""type"":""record"",
                 ""fields"":
                           [
                                {""name"":""IntField"", ""type"":""int""},
                           ]
             }";

            const string ReaderSchema =
            @"{
                 ""name"":""NewNameNotInAliases"",
                 ""namespace"":""Microsoft.Hadoop.Avro.Tests"",
                 ""type"":""record"",
                 ""fields"":
                           [
                                {""name"":""IntField"", ""type"":""int""},
                           ]
             }";

            var serializer = AvroSerializer.CreateGeneric(WriterSchema);
            var deserializer = AvroSerializer.CreateGenericDeserializerOnly(WriterSchema, ReaderSchema);
        }
    }
}
