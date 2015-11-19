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
    using System.Collections;
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

    [SuppressMessage("Microsoft.Design", "CA1001:TypesThatOwnDisposableFieldsShouldBeDisposable", Justification = "Test class.")]
    [TestClass]
    public sealed class SequentialContainerTests
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
        public void SequentialReaderWriter_SerializeThreeObjects()
        {
            var expected = new List<ClassOfInt>
                {
                    ClassOfInt.Create(true),
                    ClassOfInt.Create(true),
                    ClassOfInt.Create(true),
                };

            var w = AvroContainer.CreateWriter<ClassOfInt>(this.resultStream, Codec.Null);
            using (var writer = new SequentialWriter<ClassOfInt>(w, 24))
            {
                expected.ForEach(writer.Write);
            }

            this.resultStream.Seek(0, SeekOrigin.Begin);
            var r = AvroContainer.CreateReader<ClassOfInt>(this.resultStream);
            using (var reader = new SequentialReader<ClassOfInt>(r))
            {
                Assert.IsTrue(expected.SequenceEqual(reader.Objects));
            }
        }

        [TestMethod]
        [TestCategory("CheckIn")]
        public void SequentialReaderWriter_SerializeHugeObject()
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

            var w = AvroContainer.CreateWriter<SimpleFlatClass>(this.resultStream, new AvroSerializerSettings { Resolver = new AvroDataContractResolver(true) }, Codec.Null);
            using (var writer = new SequentialWriter<SimpleFlatClass>(w, 24))
            {
                expected.ForEach(writer.Write);
            }

            this.resultStream.Seek(0, SeekOrigin.Begin);
            var r = AvroContainer.CreateReader<SimpleFlatClass>(this.resultStream, true, new AvroSerializerSettings { Resolver = new AvroDataContractResolver(true) }, new CodecFactory());
            using (var reader = new SequentialReader<SimpleFlatClass>(r))
            {
                Assert.IsTrue(expected.SequenceEqual(reader.Objects));
            }
        }

        [TestMethod]
        [TestCategory("CheckIn")]
        public void SequentialReaderWriter_SyncAfterEachObject()
        {
            var expected = new List<ClassOfInt>
                {
                    ClassOfInt.Create(true),
                    ClassOfInt.Create(true),
                    ClassOfInt.Create(true),
                };

            var w = AvroContainer.CreateWriter<ClassOfInt>(this.resultStream, Codec.Null);
            using (var writer = new SequentialWriter<ClassOfInt>(w, 1))
            {
                expected.ForEach(writer.Write);
            }

            this.resultStream.Seek(0, SeekOrigin.Begin);
            var r = AvroContainer.CreateReader<ClassOfInt>(this.resultStream);
            using (var reader = new SequentialReader<ClassOfInt>(r))
            {
                Assert.IsTrue(expected.SequenceEqual(reader.Objects));
            }
        }

        [TestMethod]
        [TestCategory("CheckIn")]
        public void SequentialReaderWriter_SyncAfter1024Objects()
        {
            var expected = new List<ClassOfInt>();
            for (var i = 0; i < 2600; i++)
            {
                expected.Add(ClassOfInt.Create(true));
            }

            var w = AvroContainer.CreateWriter<ClassOfInt>(this.resultStream, Codec.Null);
            using (var writer = new SequentialWriter<ClassOfInt>(w, 1024))
            {
                expected.ForEach(writer.Write);
            }

            this.resultStream.Seek(0, SeekOrigin.Begin);
            var r = AvroContainer.CreateReader<ClassOfInt>(this.resultStream);
            using (var reader = new SequentialReader<ClassOfInt>(r))
            {
                Assert.IsTrue(expected.SequenceEqual(reader.Objects));
            }
        }

        [TestMethod]
        [TestCategory("CheckIn")]
        public void SequentialReaderWriter_SyncAfterDeflateCodec()
        {
            var expected = new List<ClassOfInt>();
            for (var i = 0; i < 7; i++)
            {
                expected.Add(ClassOfInt.Create(true));
            }

            var w = AvroContainer.CreateWriter<ClassOfInt>(this.resultStream, Codec.Deflate);
            using (var writer = new SequentialWriter<ClassOfInt>(w, 2))
            {
                expected.ForEach(writer.Write);
            }

            this.resultStream.Seek(0, SeekOrigin.Begin);
            var r = AvroContainer.CreateReader<ClassOfInt>(this.resultStream);
            using (var reader = new SequentialReader<ClassOfInt>(r))
            {
                Assert.IsTrue(expected.SequenceEqual(reader.Objects));
            }
        }

        [TestMethod]
        [TestCategory("CheckIn")]
        public void SequentialReaderWriter_Reset()
        {
            var expected = new List<ClassOfListOfGuid>();
            for (var i = 0; i < 7; i++)
            {
                expected.Add(ClassOfListOfGuid.Create(true));
            }

            var w = AvroContainer.CreateWriter<ClassOfListOfGuid>(this.resultStream, Codec.Deflate);
            using (var writer = new SequentialWriter<ClassOfListOfGuid>(w, 3))
            {
                expected.ForEach(writer.Write);
            }

            this.resultStream.Seek(0, SeekOrigin.Begin);

            var r = AvroContainer.CreateReader<ClassOfListOfGuid>(this.resultStream);
            using (var reader = new SequentialReader<ClassOfListOfGuid>(r))
            {
                Assert.IsTrue(expected.SequenceEqual(reader.Objects));

                var enumerator = (IEnumerator)reader.Objects.GetEnumerator();
                Assert.IsFalse(enumerator.MoveNext());
            }
        }

        [TestMethod]
        [TestCategory("CheckIn")]
        public void SequentialWriter_MicrosoftWriterApacheReader()
        {
            var expected = new List<ClassOfInt>();
            for (var i = 0; i < 7; i++)
            {
                expected.Add(ClassOfInt.Create(true));
            }

            var w = AvroContainer.CreateWriter<ClassOfInt>(this.resultStream, Codec.Deflate);
            using (var writer = new SequentialWriter<ClassOfInt>(w, 2))
            {
                expected.ForEach(writer.Write);
            }

            this.resultStream.Seek(0, SeekOrigin.Begin);
            var reader = DataFileReader<GenericRecord>.OpenReader(this.resultStream);
            var actual = new List<GenericRecord>(reader);

            for (var i = 0; i < expected.Count; ++i)
            {
                Assert.AreEqual(expected[i].PrimitiveInt, actual[i]["PrimitiveInt"]);
            }
        }

        [TestMethod]
        [TestCategory("CheckIn")]
        public void SequentialReader_ApacheWriterMicrosoftReader()
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

            var datumWriter = new GenericWriter<GenericRecord>(schema);
            var writer = DataFileWriter<GenericRecord>.OpenWriter(datumWriter, this.resultStream);

            writer.WriteHeader();
            foreach (var obj in expected)
            {
                writer.Append(obj);
            }
            writer.Flush();

            this.resultStream.Seek(0, SeekOrigin.Begin);

            var r = AvroContainer.CreateReader<ClassOfInt>(this.resultStream, true, new AvroSerializerSettings { Resolver = new AvroDataContractResolver(true) }, new CodecFactory());
            using (var reader = new SequentialReader<ClassOfInt>(r))
            {
                var actual = reader.Objects.ToList();

                Assert.AreEqual(expected.Count, actual.Count);
                for (var i = 0; i < expected.Count; ++i)
                {
                    Assert.AreEqual(expected[i]["PrimitiveInt"], actual[i].PrimitiveInt);
                }
            }
        }

        [TestMethod]
        [TestCategory("CheckIn")]
        public void SequentialWriter_MicrosoftWriterApacherReaderOfNestedType()
        {
            var expected = new List<NestedClass>();
            for (var i = 0; i < 7; i++)
            {
                expected.Add(NestedClass.Create(true));
            }

            var w = AvroContainer.CreateWriter<NestedClass>(this.resultStream, new AvroSerializerSettings { Resolver = new AvroDataContractResolver(true) }, Codec.Deflate);
            using (var writer = new SequentialWriter<NestedClass>(w, 2))
            {
                expected.ForEach(writer.Write);
            }

            this.resultStream.Seek(0, SeekOrigin.Begin);

            var reader = DataFileReader<GenericRecord>.OpenReader(this.resultStream);
            var actual = new List<GenericRecord>(reader);

            for (var i = 0; i < expected.Count; ++i)
            {
                Assert.AreEqual(expected[i].PrimitiveInt, actual[i]["PrimitiveInt"]);
                if (expected[i].ClassOfIntReference == null)
                {
                    Assert.IsNull(actual[i]["ClassOfIntReference"]);
                }
                else
                {
                    Assert.IsNotNull(actual[i]["ClassOfIntReference"] as GenericRecord);
                    Assert.AreEqual(expected[i].ClassOfIntReference.PrimitiveInt, (actual[i]["ClassOfIntReference"] as GenericRecord)["PrimitiveInt"]);
                }
            }
        }

        [TestMethod]
        [TestCategory("CheckIn")]
        public void SequentialWriter_MicrosoftWriterApacherReaderOfDictionary()
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

            var w = AvroContainer.CreateWriter<ContainingDictionaryClass<string, string>>(this.resultStream, Codec.Deflate);
            using (var writer = new SequentialWriter<ContainingDictionaryClass<string, string>>(w, 2))
            {
                expected.ForEach(writer.Write);
            }

            this.resultStream.Seek(0, SeekOrigin.Begin);

            var reader = DataFileReader<GenericRecord>.OpenReader(this.resultStream);
            var actual = new List<GenericRecord>(reader);

            Assert.AreEqual(expected.Count, actual.Count);

            for (var i = 0; i < expected.Count; ++i)
            {
                var actualValue = actual[i]["Property"] as Dictionary<string, object>;
                Assert.IsNotNull(actualValue);
                Assert.AreEqual(actualValue["testkey" + i] as string, expected[i].Property["testkey" + i]);
            }
        }

        [TestMethod]
        [TestCategory("CheckIn")]
        [ExpectedException(typeof(ArgumentNullException))]
        public void SequentialWriter_CreateWithNullStream()
        {
            using (new SequentialWriter<ClassOfInt>(null, 0))
            {
            }
        }

        [TestMethod]
        [TestCategory("CheckIn")]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void SequentialWriter_CreateWithInvalidNumberOfSyncObjects()
        {
            var writer = AvroContainer.CreateWriter<ClassOfInt>(this.resultStream, Codec.Null);
            using (new SequentialWriter<ClassOfInt>(writer, -10))
            {
            }
        }

        [TestMethod]
        [TestCategory("CheckIn")]
        [ExpectedException(typeof(SerializationException))]
        public void SequentialReader_CorruptedMagicInHeader()
        {
            var randomByteArray = new byte[] { 0, 1, 2, 3, 4 };
            using (var stream = new MemoryStream(randomByteArray))
            {
                var reader = AvroContainer.CreateReader<ClassWithNullableIntField>(stream);
            }
        }

        [TestMethod]
        [TestCategory("CheckIn")]
        [ExpectedException(typeof(ArgumentNullException))]
        public void SequentialWriter_AddMetadataWithNullKey()
        {
            var writer = AvroContainer.CreateWriter<ClassOfInt>(this.resultStream, Codec.Null);
            using (var sequentialWriter = new SequentialWriter<ClassOfInt>(writer, 2))
            {
                sequentialWriter.AddMetadata(null, Utilities.GetRandom<byte[]>(false));
            }
        }

        [TestMethod]
        [TestCategory("CheckIn")]
        [ExpectedException(typeof(ArgumentNullException))]
        public void SequentialWriter_AddMetadataWithNullValue()
        {
            var writer = AvroContainer.CreateWriter<ClassOfInt>(this.resultStream, Codec.Null);
            using (var sequentialWriter = new SequentialWriter<ClassOfInt>(writer, 2))
            {
                sequentialWriter.AddMetadata("Key", null);
            }
        }

        [TestMethod]
        [TestCategory("CheckIn")]
        [ExpectedException(typeof(ArgumentNullException))]
        public void SequentialReader_CreateWithNullReader()
        {
            using (new SequentialReader<ClassOfInt>(null))
            {
            }
        }

        [TestMethod]
        [TestCategory("CheckIn")]
        public void SequentialReaderWriter_CreateReaderForSchemaWithNullableField()
        {
            var expected = new ClassWithNullableIntField { NullableIntField = 10 };

            using (var writer = AvroContainer.CreateWriter<ClassWithNullableIntField>(this.resultStream, Codec.Deflate))
            {
                using (var swriter = new SequentialWriter<ClassWithNullableIntField>(writer, 2))
                {
                    swriter.Write(expected);
                    swriter.Write(expected);
                    swriter.Write(expected);
                    swriter.Write(expected);
                }
            }

            this.resultStream.Seek(0, SeekOrigin.Begin);

            using (var reader = AvroContainer.CreateReader<ClassWithNullableIntField>(this.resultStream))
            {
                using (var sreader = new SequentialReader<ClassWithNullableIntField>(reader))
                {
                    foreach (var actual in sreader.Objects)
                    {
                        Assert.AreEqual(expected.NullableIntField, actual.NullableIntField);
                    }
                }
            }
        }
    }
}
