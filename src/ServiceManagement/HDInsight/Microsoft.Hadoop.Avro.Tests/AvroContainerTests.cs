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
    using System.Text;
    using global::Avro.File;
    using global::Avro.Generic;
    using Microsoft.Hadoop.Avro;
    using Microsoft.Hadoop.Avro.Container;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using ApacheAvro = global::Avro;
    using Codec = Microsoft.Hadoop.Avro.Container.Codec;

    [SuppressMessage("Microsoft.Design", "CA1001:TypesThatOwnDisposableFieldsShouldBeDisposable", Justification = "Test class. Disposing in the tear off method.")]
    [TestClass]
    public sealed class AvroContainerTests
    {
        private Stream resultStream;

        [TestInitialize]
        public void TestInitialize()
        {
            this.resultStream = new MemoryStream();
        }

        [TestCleanup]
        public void TestCleanup()
        {
            this.resultStream.Dispose();
            this.resultStream = null;
        }

        [TestMethod]
        [TestCategory("CheckIn")]
        public void Container_SerializeThreeObjects()
        {
            var expected = new List<ClassOfInt>
                {
                    ClassOfInt.Create(true),
                    ClassOfInt.Create(true),
                    ClassOfInt.Create(true)
                };

            using (var writer = AvroContainer.CreateWriter<ClassOfInt>(this.resultStream, Codec.Null))
            {
                var metadata = new Dictionary<string, byte[]> { { Utilities.GetRandom<string>(false), Utilities.GetRandom<byte[]>(false) } };
                writer.SetMetadata(metadata);

                var block = writer.CreateBlockAsync().Result;
                expected.ForEach(block.Write);
                writer.WriteBlockAsync(block).Wait();
            }

            this.resultStream.Seek(0, SeekOrigin.Begin);
            using (var reader = AvroContainer.CreateReader<ClassOfInt>(this.resultStream))
            {
                reader.MoveNext();
                Assert.IsTrue(expected.SequenceEqual(reader.Current.Objects));
            }
        }

        [TestMethod]
        [TestCategory("CheckIn")]
        public void Container_SerializeHugeObject()
        {
            var single = new SimpleFlatClass
            {
                StringField = new string('a', 16254),
                ByteArrayField = Encoding.ASCII.GetBytes(new string('b', 65666)),
                ZeroByteArrayField = Encoding.ASCII.GetBytes(new string('c', 128344))
            };

            var expected = new List<SimpleFlatClass>
                {
                    single,
                    single,
                    single,
                };

            var writer = AvroContainer.CreateWriter<SimpleFlatClass>(this.resultStream, new AvroSerializerSettings { Resolver = new AvroDataContractResolver(true) }, Codec.Null);

            var block = writer.CreateBlockAsync().Result;
            expected.ForEach(block.Write);
            writer.WriteBlockAsync(block).Wait();
            writer.Dispose();

            this.resultStream.Seek(0, SeekOrigin.Begin);
            var reader = AvroContainer.CreateReader<SimpleFlatClass>(this.resultStream, true, new AvroSerializerSettings { Resolver = new AvroDataContractResolver(true) }, new CodecFactory());
            reader.MoveNext();
            Assert.IsTrue(expected.SequenceEqual(reader.Current.Objects));
        }

        [TestMethod]
        [TestCategory("CheckIn")]
        public void Container_SyncAfterEachObject()
        {
            var expected = new List<ClassOfInt>
                {
                    ClassOfInt.Create(true),
                    ClassOfInt.Create(true),
                    ClassOfInt.Create(true),
                };

            var writer = AvroContainer.CreateWriter<ClassOfInt>(this.resultStream, Codec.Null);

            expected.ForEach(
                e =>
                {
                    var block = writer.CreateBlockAsync().Result;
                    block.Write(e);
                    writer.WriteBlockAsync(block).Wait();
                });
            writer.Dispose();

            this.resultStream.Seek(0, SeekOrigin.Begin);

            var reader = AvroContainer.CreateReader<ClassOfInt>(this.resultStream);

            var actual = new List<ClassOfInt>();
            while (reader.MoveNext())
            {
                actual.AddRange(reader.Current.Objects);
            }
            Assert.IsTrue(expected.SequenceEqual(actual));
        }

        [TestMethod]
        [TestCategory("CheckIn")]
        public void Container_SyncAfter1024Objects()
        {
            var expected = new List<ClassOfInt>();
            for (var j = 0; j < 2600; j++)
            {
                expected.Add(ClassOfInt.Create(true));
            }

            var writer = AvroContainer.CreateWriter<ClassOfInt>(this.resultStream, Codec.Null);

            var i = 0;
            while (i < expected.Count)
            {
                var block = writer.CreateBlockAsync().Result;
                for (var j = 0; j < 1024; j++)
                {
                    if (i >= expected.Count)
                    {
                        break;
                    }
                    block.Write(expected[i]);
                    i++;
                }
                writer.WriteBlockAsync(block).Wait();
            }
            writer.Dispose();

            this.resultStream.Seek(0, SeekOrigin.Begin);
            var reader = AvroContainer.CreateReader<ClassOfInt>(this.resultStream);

            var actual = new List<ClassOfInt>();
            while (reader.MoveNext())
            {
                actual.AddRange(reader.Current.Objects);
            }

            Assert.IsTrue(expected.SequenceEqual(actual));
        }

        [TestMethod]
        [TestCategory("CheckIn")]
        public void Container_SyncAfterDeflateCodec()
        {
            var expected = new List<ClassOfInt>();
            for (var j = 0; j < 7; j++)
            {
                expected.Add(ClassOfInt.Create(true));
            }

            var writer = AvroContainer.CreateWriter<ClassOfInt>(this.resultStream, Codec.Deflate);

            var i = 0;
            while (i < expected.Count)
            {
                var block = writer.CreateBlockAsync().Result;
                for (var j = 0; j < 2; j++)
                {
                    if (i >= expected.Count)
                    {
                        break;
                    }
                    block.Write(expected[i]);
                    i++;
                }
                writer.WriteBlockAsync(block).Wait();
            }
            writer.Dispose();

            this.resultStream.Seek(0, SeekOrigin.Begin);

            var reader = AvroContainer.CreateReader<ClassOfInt>(this.resultStream);

            var actual = new List<ClassOfInt>();
            while (reader.MoveNext())
            {
                actual.AddRange(reader.Current.Objects);
            }
            Assert.IsTrue(expected.SequenceEqual(actual));
        }

        [TestMethod]
        [TestCategory("CheckIn")]
        [SuppressMessage("Microsoft.Usage", "CA2202:DoNotDisposeObjectsMultipleTimes",
        Justification = "There is no double dispose in this test.")]
        public void Container_Reset()
        {
            var expected = new List<ClassOfListOfGuid>();
            for (var i = 0; i < 7; i++)
            {
                expected.Add(ClassOfListOfGuid.Create(true));
            }

            using (var memoryStream = new MemoryStream())
            {
                var writer = AvroContainer.CreateWriter<ClassOfListOfGuid>(memoryStream, new AvroSerializerSettings { Resolver = new AvroDataContractResolver(true) }, Codec.Deflate);

                var i = 0;
                while (i < expected.Count)
                {
                    var block = writer.CreateBlockAsync().Result;
                    for (var j = 0; j < 3; j++)
                    {
                        if (i >= expected.Count)
                        {
                            break;
                        }
                        block.Write(expected[i]);
                        i++;
                    }
                    writer.WriteBlockAsync(block).Wait();
                }
                writer.Dispose();

                memoryStream.Seek(0, SeekOrigin.Begin);
                var reader = AvroContainer.CreateReader<ClassOfListOfGuid>(memoryStream, true, new AvroSerializerSettings { Resolver = new AvroDataContractResolver(true) }, new CodecFactory());

                var actual = new List<ClassOfListOfGuid>();
                var resetActual = new List<ClassOfListOfGuid>();
                while (reader.MoveNext())
                {
                    actual.AddRange(reader.Current.Objects);

                    var e = reader.Current.Objects.GetEnumerator();
                    while (e.MoveNext())
                    {
                        resetActual.Add(e.Current);
                    }
                }

                Assert.IsTrue(expected.SequenceEqual(actual));
                Assert.IsTrue(expected.SequenceEqual(resetActual));
            }
        }

        [TestMethod]
        [TestCategory("CheckIn")]
        [SuppressMessage("Microsoft.Usage", "CA2202:DoNotDisposeObjectsMultipleTimes",
        Justification = "There is no double dispose in this test.")]
        public void Container_MicrosoftWriterApacheReader()
        {
            var expected = new List<ClassOfInt>();
            for (var i = 0; i < 7; i++)
            {
                expected.Add(ClassOfInt.Create(true));
            }

            using (var memoryStream = new MemoryStream())
            {
                var writer = AvroContainer.CreateWriter<ClassOfInt>(memoryStream, Codec.Deflate);

                var i = 0;
                while (i < expected.Count)
                {
                    var block = writer.CreateBlockAsync().Result;
                    for (var j = 0; j < 2; j++)
                    {
                        if (i >= expected.Count)
                        {
                            break;
                        }
                        block.Write(expected[i]);
                        i++;
                    }
                    writer.WriteBlockAsync(block).Wait();
                }
                writer.Dispose();

                memoryStream.Seek(0, SeekOrigin.Begin);
                var reader = DataFileReader<GenericRecord>.OpenReader(memoryStream);
                var actual = new List<GenericRecord>(reader);

                for (var k = 0; k < expected.Count; ++k)
                {
                    Assert.AreEqual(expected[k].PrimitiveInt, actual[k]["PrimitiveInt"]);
                }
            }
        }

        [TestMethod]
        [TestCategory("CheckIn")]
        public void Container_ApacheWriterMicrosoftReader()
        {
            var serializer = AvroSerializer.Create<ClassOfInt>(new AvroSerializerSettings { Resolver = new AvroDataContractResolver(true) });
            var schema = ApacheAvro.Schema.Parse(serializer.WriterSchema.ToString()) as ApacheAvro.UnionSchema;
            Assert.IsNotNull(schema);

            var recordSchema = schema.Schemas[1] as ApacheAvro.RecordSchema;
            Assert.IsNotNull(recordSchema);

            var expected = new List<GenericRecord>();
            for (var i = 0; i < 7; i++)
            {
                var record = new GenericRecord(recordSchema);
                record.Add("PrimitiveInt", ClassOfInt.Create(true).PrimitiveInt);
                expected.Add(record);
            }

            using (var memoryStream = new MemoryStream())
            {
                var datumWriter = new GenericWriter<GenericRecord>(schema);
                var writer = DataFileWriter<GenericRecord>.OpenWriter(datumWriter, memoryStream);

                writer.WriteHeader();
                foreach (var obj in expected)
                {
                    writer.Append(obj);
                }
                writer.Flush();

                memoryStream.Seek(0, SeekOrigin.Begin);

                var reader = AvroContainer.CreateReader<ClassOfInt>(memoryStream, true, new AvroSerializerSettings { Resolver = new AvroDataContractResolver(true) }, new CodecFactory());
                var actual = new List<ClassOfInt>();
                while (reader.MoveNext())
                {
                    actual.AddRange(reader.Current.Objects);
                }

                Assert.AreEqual(expected.Count, actual.Count);
                for (var i = 0; i < expected.Count; ++i)
                {
                    Assert.AreEqual(expected[i]["PrimitiveInt"], actual[i].PrimitiveInt);
                }
            }
        }

        [TestMethod]
        [TestCategory("CheckIn")]
        [SuppressMessage("Microsoft.Usage", "CA2202:DoNotDisposeObjectsMultipleTimes",
        Justification = "There is no double dispose in this test.")]
        public void Container_MicrosoftWriterApacherReaderOfNestedType()
        {
            var expected = new List<NestedClass>();
            for (var i = 0; i < 7; i++)
            {
                expected.Add(NestedClass.Create(true));
            }

            using (var memoryStream = new MemoryStream())
            {
                var writer = AvroContainer.CreateWriter<NestedClass>(memoryStream, new AvroSerializerSettings { Resolver = new AvroDataContractResolver(true) }, Codec.Deflate);

                var i = 0;
                while (i < expected.Count)
                {
                    var block = writer.CreateBlockAsync().Result;
                    for (var j = 0; j < 2; j++)
                    {
                        if (i >= expected.Count)
                        {
                            break;
                        }
                        block.Write(expected[i]);
                        i++;
                    }
                    writer.WriteBlockAsync(block).Wait();
                }
                writer.Dispose();

                memoryStream.Seek(0, SeekOrigin.Begin);

                var reader = DataFileReader<GenericRecord>.OpenReader(memoryStream);
                var actual = new List<GenericRecord>(reader);

                for (var k = 0; k < expected.Count; ++k)
                {
                    Assert.AreEqual(expected[k].PrimitiveInt, actual[k]["PrimitiveInt"]);
                    if (expected[k].ClassOfIntReference == null)
                    {
                        Assert.IsNull(actual[k]["ClassOfIntReference"]);
                    }
                    else
                    {
                        Assert.AreEqual(expected[k].ClassOfIntReference.PrimitiveInt, (actual[k]["ClassOfIntReference"] as GenericRecord)["PrimitiveInt"]);
                    }
                }
            }
        }

        [TestMethod]
        [TestCategory("CheckIn")]
        [SuppressMessage("Microsoft.Usage", "CA2202:DoNotDisposeObjectsMultipleTimes",
        Justification = "There is no double dispose in this test.")]
        public void Container_MicrosoftWriterApacherReaderOfDictionary()
        {
            var expected = new List<ContainingDictionaryClass<string, string>>();
            for (var i = 0; i < 7; i++)
            {
                expected.Add(ContainingDictionaryClass<string, string>.Create(
                    new Dictionary<string, string>
                    {
                        { "testkey" + i, "testvalue" + i }
                    }));
            }

            using (var memoryStream = new MemoryStream())
            {
                var writer = AvroContainer.CreateWriter<ContainingDictionaryClass<string, string>>(memoryStream, Codec.Deflate);

                {
                    var i = 0;
                    while (i < expected.Count)
                    {
                        var block = writer.CreateBlockAsync().Result;
                        for (var j = 0; j < 2; j++)
                        {
                            if (i >= expected.Count)
                            {
                                break;
                            }
                            block.Write(expected[i]);
                            i++;
                        }
                        writer.WriteBlockAsync(block).Wait();
                    }
                    writer.Dispose();
                }

                memoryStream.Seek(0, SeekOrigin.Begin);

                var reader = DataFileReader<GenericRecord>.OpenReader(memoryStream);
                var actual = new List<GenericRecord>(reader);

                Assert.AreEqual(expected.Count, actual.Count);

                for (var i = 0; i < expected.Count; ++i)
                {
                    var actualValue = actual[i]["Property"] as Dictionary<string, object>;
                    Assert.AreEqual(actualValue["testkey" + i] as string, expected[i].Property["testkey" + i]);
                }
            }
        }

        #region Test invalid arguments for creation

        [TestMethod]
        [TestCategory("CheckIn")]
        public void Container_CreateReaderWithNullArguments()
        {
            Utilities.ShouldThrow<ArgumentNullException>(() => AvroContainer.CreateReader<int>(null));
            Utilities.ShouldThrow<ArgumentNullException>(() => AvroContainer.CreateReader<int>(null, true));
            Utilities.ShouldThrow<ArgumentNullException>(() => AvroContainer.CreateReader<int>(null, true, new AvroSerializerSettings(), new CodecFactory()));
            Utilities.ShouldThrow<ArgumentNullException>(() => AvroContainer.CreateReader<int>(this.resultStream, true, null, new CodecFactory()));
            Utilities.ShouldThrow<ArgumentNullException>(() => AvroContainer.CreateReader<int>(this.resultStream, true, new AvroSerializerSettings(), null));
        }

        [TestMethod]
        [TestCategory("CheckIn")]
        public void Container_CreateWriterWithNullArguments()
        {
            Utilities.ShouldThrow<ArgumentNullException>(() => AvroContainer.CreateWriter<int>(null, Codec.Deflate));
            Utilities.ShouldThrow<ArgumentNullException>(() => AvroContainer.CreateWriter<int>(this.resultStream, null));
            Utilities.ShouldThrow<ArgumentNullException>(() => AvroContainer.CreateWriter<int>(null, true, new AvroSerializerSettings(), Codec.Null));
            Utilities.ShouldThrow<ArgumentNullException>(() => AvroContainer.CreateWriter<int>(this.resultStream, true, null, Codec.Null));
            Utilities.ShouldThrow<ArgumentNullException>(() => AvroContainer.CreateWriter<int>(this.resultStream, true, new AvroSerializerSettings(), null));
        }

        [TestMethod]
        [TestCategory("CheckIn")]
        public void Container_GenericWriterWithNullArguments()
        {
            const string WriterSchema =
            @"{
                 ""name"":""RecordContainingArray"",
                 ""type"":""record"",
                 ""fields"":
                           [
                                {""name"":""IntField"", ""type"":""int""},
                           ]
             }";

            Utilities.ShouldThrow<ArgumentNullException>(() => AvroContainer.CreateGenericWriter(null, this.resultStream, Codec.Deflate));
            Utilities.ShouldThrow<ArgumentNullException>(() => AvroContainer.CreateGenericWriter(WriterSchema, null, Codec.Deflate));
            Utilities.ShouldThrow<ArgumentNullException>(() => AvroContainer.CreateGenericWriter(WriterSchema, this.resultStream, null));
        }

        [TestMethod]
        [TestCategory("CheckIn")]
        public void Container_GenericReaderWithNullArguments()
        {
            const string ReaderSchema =
            @"{
                 ""name"":""RecordContainingArray"",
                 ""type"":""record"",
                 ""fields"":
                           [
                                {""name"":""IntField"", ""type"":""int""},
                           ]
             }";

            Utilities.ShouldThrow<ArgumentNullException>(() => AvroContainer.CreateGenericReader(null));
            Utilities.ShouldThrow<ArgumentNullException>(() => AvroContainer.CreateGenericReader(this.resultStream, true, null));
            Utilities.ShouldThrow<ArgumentNullException>(() => AvroContainer.CreateGenericReader(null, this.resultStream, true, new CodecFactory()));
            Utilities.ShouldThrow<ArgumentNullException>(() => AvroContainer.CreateGenericReader(ReaderSchema, null, true, new CodecFactory()));
            Utilities.ShouldThrow<ArgumentNullException>(() => AvroContainer.CreateGenericReader(ReaderSchema, this.resultStream, true, null));
        }

        [TestMethod]
        [TestCategory("CheckIn")]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Container_CreateWriterWithNullBlock()
        {
            using (var s = AvroContainer.CreateWriter<int>(this.resultStream, Codec.Deflate))
            {
                s.WriteBlockAsync(null).Wait();
            }
        }

        [TestMethod]
        [TestCategory("CheckIn")]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Container_WriterSetNullMetadata()
        {
            using (var s = AvroContainer.CreateWriter<int>(this.resultStream, Codec.Deflate))
            {
                s.SetMetadata(null);
            }
        }

        [SuppressMessage("Microsoft.Reliability", "CA2000:Dispose objects before losing scope", Justification = "Ctor should throw.")]
        [SuppressMessage("Microsoft.Usage", "CA1806:DoNotIgnoreMethodResults", Justification = "Ctor should throw.")]
        [TestMethod]
        [TestCategory("CheckIn")]
        public void Container_CreateBufferReaderBlockNullArguments()
        {
            Utilities.ShouldThrow<ArgumentNullException>(() => new AvroBufferReaderBlock<ClassOfInt>(null, Codec.Null, new byte[] { }, 1));
            Utilities.ShouldThrow<ArgumentNullException>(() => new AvroBufferReaderBlock<ClassOfInt>(AvroSerializer.Create<ClassOfInt>(), null, new byte[] { }, 1));
            Utilities.ShouldThrow<ArgumentNullException>(() => new AvroBufferReaderBlock<ClassOfInt>(AvroSerializer.Create<ClassOfInt>(), Codec.Null, null, 1));
            Utilities.ShouldThrow<ArgumentOutOfRangeException>(() => new AvroBufferReaderBlock<ClassOfInt>(AvroSerializer.Create<ClassOfInt>(), Codec.Null, new byte[] { }, -1));
        }

        [SuppressMessage("Microsoft.Reliability", "CA2000:Dispose objects before losing scope", Justification = "Ctor should throw.")]
        [SuppressMessage("Microsoft.Usage", "CA1806:DoNotIgnoreMethodResults", Justification = "Ctor should throw.")]
        [TestMethod]
        [TestCategory("CheckIn")]
        public void Container_CreateBufferWriterBlockNullArguments()
        {
            Utilities.ShouldThrow<ArgumentNullException>(() => new AvroBufferWriterBlock<ClassOfInt>(null, Codec.Null));
            Utilities.ShouldThrow<ArgumentNullException>(() => new AvroBufferWriterBlock<ClassOfInt>(AvroSerializer.Create<ClassOfInt>(), null));
        }

        [TestMethod]
        [TestCategory("CheckIn")]
        [ExpectedException(typeof(ArgumentException))]
        public void Container_GenericWriterUsingCodecFactoryWithInvalidCodecName()
        {
            const string WriterSchema =
            @"{
                 ""name"":""RecordContainingArray"",
                 ""type"":""record"",
                 ""fields"":
                           [
                                {""name"":""IntField"", ""type"":""int""},
                           ]
             }";

            var codecFactory = new CodecFactory();

            using (AvroContainer.CreateGenericWriter(WriterSchema, this.resultStream, codecFactory.Create("InvalidName")))
            {
            }
        }

        [TestMethod]
        [TestCategory("CheckIn")]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Container_GenericWriterUsingCodecFactoryWithNullCodecName()
        {
            const string WriterSchema =
            @"{
                 ""name"":""RecordContainingArray"",
                 ""type"":""record"",
                 ""fields"":
                           [
                                {""name"":""IntField"", ""type"":""int""},
                           ]
             }";

            var codecFactory = new CodecFactory();

            using (AvroContainer.CreateGenericWriter(WriterSchema, this.resultStream, codecFactory.Create(null)))
            {
            }
        }

        #endregion

        [TestMethod]
        [TestCategory("CheckIn")]
        [ExpectedException(typeof(SerializationException))]
        public void Container_WriteInvalidSyncMarker()
        {
            var expected = new List<ClassOfInt>
                {
                    ClassOfInt.Create(true),
                    ClassOfInt.Create(true),
                };

            var writer = AvroContainer.CreateWriter<ClassOfInt>(this.resultStream, Codec.Null);
            foreach (var obj in expected)
            {
                var block = writer.CreateBlockAsync().Result;
                block.Write(obj);
                writer.WriteBlockAsync(block).Wait();
                this.resultStream.Seek(this.resultStream.Position - 1, SeekOrigin.Begin);
                int markerLastByte = this.resultStream.ReadByte();
                this.resultStream.Seek(this.resultStream.Position - 1, SeekOrigin.Begin);
                this.resultStream.WriteByte((byte)((markerLastByte + 10) % 255));
            }
            writer.Dispose();

            this.resultStream.Seek(0, SeekOrigin.Begin);

            var reader = AvroContainer.CreateReader<ClassOfInt>(this.resultStream);

            var actual = new List<ClassOfInt>();
            while (reader.MoveNext())
            {
                actual.AddRange(reader.Current.Objects);
            }
        }

        #region Schema evolution with generic readers and writers

        [TestMethod]
        [TestCategory("CheckIn")]
        [SuppressMessage("Microsoft.Usage", "CA2202:DoNotDisposeObjectsMultipleTimes",
        Justification = "There is no double dispose in this test.")]
        public void Container_SchemaEvolution_RecordContainingArrayWithWriterIntPromotedToReaderLong()
        {
            const string WriterSchema =
            @"{
                 ""name"":""RecordContainingArray"",
                 ""type"":""record"",
                 ""fields"":
                           [
                                {""name"":""ArrayField"", ""type"":{""type"":""array"", ""items"":""int""}},
                           ]
             }";

            const string ReaderSchema =
            @"{
                 ""name"":""RecordContainingArray"",
                 ""type"":""record"",
                 ""fields"":
                           [
                                {""name"":""ArrayField"", ""type"":{""type"":""array"", ""items"":""long""}},
                           ]
             }";

            var serializer = AvroSerializer.CreateGeneric(WriterSchema);
            var schema = serializer.WriterSchema;
            var randomArrays = Utilities.GetRandom<List<int[]>>(false);
            var expected = new List<AvroRecord>();
            foreach (var array in randomArrays)
            {
                dynamic avroRecord = new AvroRecord(schema);
                avroRecord.ArrayField = array;
                expected.Add(avroRecord);
            }

            using (var memoryStream = new MemoryStream())
            {
                var writer = AvroContainer.CreateGenericWriter(WriterSchema, memoryStream, Codec.Null);

                var i = 0;
                while (i < expected.Count)
                {
                    var block = writer.CreateBlockAsync().Result;
                    for (var j = 0; j < 2; j++)
                    {
                        if (i >= expected.Count)
                        {
                            break;
                        }
                        block.Write(expected[i]);
                        i++;
                    }
                    writer.WriteBlockAsync(block).Wait();
                }
                writer.Dispose();

                memoryStream.Seek(0, SeekOrigin.Begin);

                var reader = AvroContainer.CreateGenericReader(ReaderSchema, memoryStream, true, new CodecFactory());
                var actual = new List<AvroRecord>();
                while (reader.MoveNext())
                {
                    actual.AddRange(reader.Current.Objects.Cast<AvroRecord>());
                }

                for (var k = 0; k < expected.Count; ++k)
                {
                    var randomArray = randomArrays[k];
                    Assert.AreEqual(randomArray.Length, ((dynamic)actual[k]).ArrayField.Length);

                    for (int t = 0; t < randomArray.Length; t++)
                    {
                        Assert.AreEqual(randomArray[t], ((dynamic)actual[k]).ArrayField.GetValue(t));
                    }
                }
            }
        }

        [TestMethod]
        [TestCategory("CheckIn")]
        [SuppressMessage("Microsoft.Usage", "CA2202:DoNotDisposeObjectsMultipleTimes",
        Justification = "There is no double dispose in this test.")]
        public void Container_SchemaEvolution_RecordWithPromotionalIntFields()
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
                           ]
             }";

            const string ReaderSchema =
            @"{
                 ""name"":""ClassWithPromotionalFields"",
                 ""namespace"":""Microsoft.Hadoop.Avro.Tests"",
                 ""type"":""record"",
                 ""fields"":
                           [
                                {""name"":""IntToLongField"", ""type"":""long""},
                                {""name"":""IntToFloatField"", ""type"":""float""},
                                {""name"":""IntToDoubleField"", ""type"":""double""},
                           ]
             }";

            const int RecordsCount = 100;

            var serializer = AvroSerializer.CreateGeneric(WriterSchema);
            var schema = serializer.WriterSchema;
            var expected = new List<AvroRecord>();

            for (int counter = 0; counter < RecordsCount; counter++)
            {
                dynamic avroRecord = new AvroRecord(schema);
                avroRecord.IntToLongField = Utilities.GetRandom<int>(false);
                avroRecord.IntToFloatField = Utilities.GetRandom<int>(false);
                avroRecord.IntToDoubleField = Utilities.GetRandom<int>(false);
                expected.Add(avroRecord);
            }

            using (var memoryStream = new MemoryStream())
            {
                var writer = AvroContainer.CreateGenericWriter(WriterSchema, memoryStream, Codec.Null);

                var i = 0;
                while (i < expected.Count)
                {
                    var block = writer.CreateBlockAsync().Result;
                    for (var j = 0; j < 2; j++)
                    {
                        if (i >= expected.Count)
                        {
                            break;
                        }
                        block.Write(expected[i]);
                        i++;
                    }
                    writer.WriteBlockAsync(block).Wait();
                }
                writer.Dispose();

                memoryStream.Seek(0, SeekOrigin.Begin);

                var reader = AvroContainer.CreateGenericReader(ReaderSchema, memoryStream, true, new CodecFactory());
                var actual = new List<AvroRecord>();
                while (reader.MoveNext())
                {
                    actual.AddRange(reader.Current.Objects.Cast<AvroRecord>());
                }

                for (var k = 0; k < expected.Count; ++k)
                {
                    Assert.AreEqual(((dynamic)expected[k]).IntToLongField, ((dynamic)actual[k]).IntToLongField);
                    Assert.AreEqual(((dynamic)expected[k]).IntToFloatField, ((dynamic)actual[k]).IntToFloatField);
                    Assert.AreEqual(((dynamic)expected[k]).IntToDoubleField, ((dynamic)actual[k]).IntToDoubleField);
                }
            }
        }

        [TestMethod]
        [TestCategory("CheckIn")]
        [SuppressMessage("Microsoft.Usage", "CA2202:DoNotDisposeObjectsMultipleTimes",
        Justification = "There is no double dispose in this test.")]
        public void Container_SchemaEvolution_RecordWithPromotionalLongAndFloatFields()
        {
            const string WriterSchema =
            @"{
                 ""name"":""ClassWithPromotionalFields"",
                 ""namespace"":""Microsoft.Hadoop.Avro.Tests"",
                 ""type"":""record"",
                 ""fields"":
                           [
                                {""name"":""LongToFloatField"", ""type"":""long""},
                                {""name"":""LongToDoubleField"", ""type"":""long""},
                                {""name"":""FloatToDoubleField"", ""type"":""float""}
                           ]
             }";

            const string ReaderSchema =
            @"{
                 ""name"":""ClassWithPromotionalFields"",
                 ""namespace"":""Microsoft.Hadoop.Avro.Tests"",
                 ""type"":""record"",
                 ""fields"":
                           [
                                {""name"":""LongToFloatField"", ""type"":""float""},
                                {""name"":""LongToDoubleField"", ""type"":""double""},
                                {""name"":""FloatToDoubleField"", ""type"":""double""}
                           ]
             }";

            const int RecordsCount = 100;

            var serializer = AvroSerializer.CreateGeneric(WriterSchema);
            var schema = serializer.WriterSchema;
            var expected = new List<AvroRecord>();

            for (int counter = 0; counter < RecordsCount; counter++)
            {
                dynamic avroRecord = new AvroRecord(schema);
                avroRecord.LongToFloatField = Utilities.GetRandom<long>(false);
                avroRecord.LongToDoubleField = Utilities.GetRandom<long>(false);
                avroRecord.FloatToDoubleField = Utilities.GetRandom<float>(false);
                expected.Add(avroRecord);
            }

            using (var memoryStream = new MemoryStream())
            {
                var writer = AvroContainer.CreateGenericWriter(WriterSchema, memoryStream, Codec.Null);

                var i = 0;
                while (i < expected.Count)
                {
                    var block = writer.CreateBlockAsync().Result;
                    for (var j = 0; j < 2; j++)
                    {
                        if (i >= expected.Count)
                        {
                            break;
                        }
                        block.Write(expected[i]);
                        i++;
                    }
                    writer.WriteBlockAsync(block).Wait();
                }
                writer.Dispose();

                memoryStream.Seek(0, SeekOrigin.Begin);

                var reader = AvroContainer.CreateGenericReader(ReaderSchema, memoryStream, true, new CodecFactory());
                var actual = new List<AvroRecord>();
                while (reader.MoveNext())
                {
                    actual.AddRange(reader.Current.Objects.Cast<AvroRecord>());
                }

                for (var k = 0; k < expected.Count; ++k)
                {
                    Assert.AreEqual(((dynamic)expected[k]).LongToFloatField, ((dynamic)actual[k]).LongToFloatField);
                    Assert.AreEqual(((dynamic)expected[k]).LongToDoubleField, ((dynamic)actual[k]).LongToDoubleField);
                    Assert.AreEqual(((dynamic)expected[k]).FloatToDoubleField, ((dynamic)actual[k]).FloatToDoubleField);
                }
            }
        }

        [TestMethod]
        [TestCategory("CheckIn")]
        [SuppressMessage("Microsoft.Usage", "CA2202:DoNotDisposeObjectsMultipleTimes",
        Justification = "There is no double dispose in this test.")]
        [SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity",
        Justification = "Tests complex hierarchy.")]
        public void Container_SchemaEvolution_RecordWithPermutatedAndMissingWriterFields()
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

            const string ReaderSchema =
            @"{
                 ""name"":""WriterClass"",
                 ""namespace"":""Microsoft.Hadoop.Avro.Tests"",
                 ""type"":""record"",
                 ""fields"":
                           [
                                {""name"":""DoubleB"", ""type"":""double""},
                                {""name"":""FloatB"", ""type"":""float""},
                                {""name"":""FloatA"", ""type"":""float""},
                                {""name"":""BoolB"", ""type"":""boolean""},
                                {""name"":""BoolA"", ""type"":""boolean""},
                                {""name"":""DoubleA"", ""type"":""double""},
                           ]
             }";

            const int RecordsCount = 100;

            var serializer = AvroSerializer.CreateGeneric(WriterSchema);
            var schema = serializer.WriterSchema;
            var expected = new List<AvroRecord>();

            for (int counter = 0; counter < RecordsCount; counter++)
            {
                dynamic avroRecord = new AvroRecord(schema);
                avroRecord.BoolA = Utilities.GetRandom<bool>(false);
                avroRecord.BoolB = Utilities.GetRandom<bool>(false);
                avroRecord.FloatA = Utilities.GetRandom<float>(false);
                avroRecord.FloatB = Utilities.GetRandom<float>(false);
                avroRecord.DoubleA = Utilities.GetRandom<double>(false);
                avroRecord.DoubleB = Utilities.GetRandom<double>(false);
                avroRecord.IntA = Utilities.GetRandom<int>(false);
                avroRecord.IntB = Utilities.GetRandom<int>(false);
                avroRecord.MyGuid = Utilities.GetRandom<Guid>(false).ToByteArray();
                avroRecord.Arr = Utilities.GetRandom<int[]>(false);
                avroRecord.LongField = Utilities.GetRandom<long>(false);
                avroRecord.LongMap = Utilities.GetRandom<Dictionary<string, long>>(false);
                avroRecord.BytesField = Utilities.GetRandom<byte[]>(false);

                avroRecord.classField = new AvroRecord(serializer.WriterSchema);
                avroRecord.classField.BoolA = Utilities.GetRandom<bool>(false);
                avroRecord.classField.BoolB = Utilities.GetRandom<bool>(false);
                avroRecord.classField.FloatA = Utilities.GetRandom<float>(false);
                avroRecord.classField.FloatB = Utilities.GetRandom<float>(false);
                avroRecord.classField.DoubleA = Utilities.GetRandom<double>(false);
                avroRecord.classField.DoubleB = Utilities.GetRandom<double>(false);
                avroRecord.classField.IntA = Utilities.GetRandom<int>(false);
                avroRecord.classField.IntB = Utilities.GetRandom<int>(false);
                avroRecord.classField.MyGuid = Utilities.GetRandom<Guid>(false).ToByteArray();
                avroRecord.classField.Arr = Utilities.GetRandom<int[]>(false);
                avroRecord.classField.classField = null;
                avroRecord.classField.LongField = Utilities.GetRandom<long>(false);
                avroRecord.classField.LongMap = Utilities.GetRandom<Dictionary<string, long>>(false);
                avroRecord.classField.BytesField = Utilities.GetRandom<byte[]>(false);
                expected.Add(avroRecord);
            }

            using (var memoryStream = new MemoryStream())
            {
                var writer = AvroContainer.CreateGenericWriter(WriterSchema, memoryStream, Codec.Null);

                var i = 0;
                while (i < expected.Count)
                {
                    var block = writer.CreateBlockAsync().Result;
                    for (var j = 0; j < 2; j++)
                    {
                        if (i >= expected.Count)
                        {
                            break;
                        }
                        block.Write(expected[i]);
                        i++;
                    }
                    writer.WriteBlockAsync(block).Wait();
                }
                writer.Dispose();

                memoryStream.Seek(0, SeekOrigin.Begin);

                var reader = AvroContainer.CreateGenericReader(ReaderSchema, memoryStream, true, new CodecFactory());
                var actual = new List<AvroRecord>();
                while (reader.MoveNext())
                {
                    actual.AddRange(reader.Current.Objects.Cast<AvroRecord>());
                }

                for (var k = 0; k < expected.Count; ++k)
                {
                    Assert.AreEqual(((dynamic)expected[k]).DoubleB, ((dynamic)actual[k]).DoubleB);
                    Assert.AreEqual(((dynamic)expected[k]).FloatB, ((dynamic)actual[k]).FloatB);
                    Assert.AreEqual(((dynamic)expected[k]).FloatA, ((dynamic)actual[k]).FloatA);
                    Assert.AreEqual(((dynamic)expected[k]).BoolB, ((dynamic)actual[k]).BoolB);
                    Assert.AreEqual(((dynamic)expected[k]).BoolA, ((dynamic)actual[k]).BoolA);
                    Assert.AreEqual(((dynamic)expected[k]).DoubleA, ((dynamic)actual[k]).DoubleA);
                }
            }
        }

        #endregion //Schema evolution with generic readers and writers
    }
}
