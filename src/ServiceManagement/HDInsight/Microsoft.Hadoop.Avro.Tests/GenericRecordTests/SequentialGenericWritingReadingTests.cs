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
    using Microsoft.Hadoop.Avro.Container;
    using Microsoft.Hadoop.Avro.Schema;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public sealed class SequentialGenericWritingReadingTests
    {
        private AvroSerializerSettings dataContractSettings;

        [TestInitialize]
        public void TestSetup()
        {
            this.dataContractSettings = new AvroSerializerSettings { Resolver = new AvroDataContractResolver(true) };
        }

        [SuppressMessage("Microsoft.Usage", "CA2202:Do not dispose objects multiple times",
            Justification = "We should handle several disposals properly.")]
        [TestMethod]
        [TestCategory("CheckIn")]
        public void SequentialGenericWritingReading_SimpleRecord()
        {
            const string StringSchema = @"{
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

            using (var stream = new MemoryStream())
            {
                var serializer = AvroSerializer.CreateGeneric(StringSchema);
                using (var streamWriter = AvroContainer.CreateGenericWriter(StringSchema, stream, Codec.Null))
                {
                    using (var writer = new SequentialWriter<object>(streamWriter, 24))
                    {
                        var expected = new List<AvroRecord>();
                        var random = new Random(113);
                        for (int i = 0; i < 10; i++)
                        {
                            dynamic record = new AvroRecord(serializer.WriterSchema);
                            record.PrimitiveInt = random.Next();
                            expected.Add(record);
                        }

                        expected.ForEach(writer.Write);
                        writer.Flush();

                        stream.Seek(0, SeekOrigin.Begin);

                        var streamReader = AvroContainer.CreateReader<ClassOfInt>(stream, true, this.dataContractSettings, new CodecFactory());
                        using (var reader = new SequentialReader<ClassOfInt>(streamReader))
                        {
                            var j = 0;
                            foreach (var avroRecord in reader.Objects)
                            {
                                Assert.AreEqual(expected[j++]["PrimitiveInt"], avroRecord.PrimitiveInt);
                            }
                        }
                    }
                }
            }
        }

        [SuppressMessage("Microsoft.Usage", "CA2202:Do not dispose objects multiple times",
            Justification = "We should handle multiple dispose properly.")]
        [TestMethod]
        [TestCategory("CheckIn")]
        public void SequentialGenericWritingReading_NestedRecord()
        {
            const string StringSchema = @"{
                                        ""type"":""record"",
                                        ""name"":""Microsoft.Hadoop.Avro.Tests.NestedClass"",
                                        ""fields"":[
                                            {
                                                ""name"":""ClassOfIntReference"",
                                                ""type"":{
                                                        ""type"":""record"",
                                                        ""name"":""Microsoft.Hadoop.Avro.Tests.ClassOfInt"",
                                                        ""fields"":[
                                                            {
                                                                 ""name"":""PrimitiveInt"",
                                                                 ""type"":""int""
                                                            }
                                                        ]
                                                    }
                                            },
                                            {
                                                ""name"":""PrimitiveInt"",""type"":""int""
                                            }
                                        ]
                                    }";

            using (var stream = new MemoryStream())
            {
                var serializer = AvroSerializer.CreateGeneric(StringSchema);
                using (var streamWriter = AvroContainer.CreateGenericWriter(StringSchema, stream, Codec.Null))
                {
                    using (var writer = new SequentialWriter<object>(streamWriter, 24))
                    {
                        var expected = new List<AvroRecord>();
                        var random = new Random(83);
                        for (int i = 0; i < 10; i++)
                        {
                            dynamic record = new AvroRecord(serializer.WriterSchema);
                            record.PrimitiveInt = random.Next();
                            record.ClassOfIntReference =
                                new AvroRecord((serializer.WriterSchema as RecordSchema).GetField("ClassOfIntReference").TypeSchema);
                            record.ClassOfIntReference.PrimitiveInt = random.Next();
                            expected.Add(record);
                        }

                        expected.ForEach(writer.Write);
                        writer.Flush();

                        stream.Seek(0, SeekOrigin.Begin);

                        var streamReader = AvroContainer.CreateReader<NestedClass>(stream, true, this.dataContractSettings, new CodecFactory());
                        using (var reader = new SequentialReader<NestedClass>(streamReader))
                        {
                            var j = 0;
                            foreach (var avroRecord in reader.Objects)
                            {
                                Assert.AreEqual(expected[j]["PrimitiveInt"], avroRecord.PrimitiveInt);
                                Assert.AreEqual(((dynamic)expected[j++]["ClassOfIntReference"])["PrimitiveInt"], avroRecord.ClassOfIntReference.PrimitiveInt);
                            }
                        }
                    }
                }
            }
        }

        [TestMethod]
        [TestCategory("CheckIn")]
        [SuppressMessage("Microsoft.Usage", "CA2202:Do not dispose objects multiple times",
            Justification = "We should handle multiple dispose properly.")]
        public void SequentialGenericWritingReading_RecursiveRecord()
        {
            const string StringSchema = @"{
                                ""type"":""record"",
                                ""name"":""Microsoft.Hadoop.Avro.Tests.Recursive"",
                                ""fields"":[
                                    {""name"":""IntField"",""type"":""int""},
                                    {""name"":""RecursiveField"",""type"":[
                                                                            ""null"",
                                                                            ""Microsoft.Hadoop.Avro.Tests.Recursive""
                                                                        ]
                                    }
                            ]}";

            using (var stream = new MemoryStream())
            {
                var serializer = AvroSerializer.CreateGeneric(StringSchema);
                using (var streamWriter = AvroContainer.CreateGenericWriter(StringSchema, stream, Codec.Null))
                {
                    using (var writer = new SequentialWriter<object>(streamWriter, 24))
                    {
                        var expected = new List<AvroRecord>();
                        var random = new Random(93);
                        for (int i = 0; i < 10; i++)
                        {
                            dynamic record = new AvroRecord(serializer.WriterSchema);
                            record.IntField = random.Next();
                            record.RecursiveField =
                                new AvroRecord(
                                    ((serializer.ReaderSchema as RecordSchema).GetField("RecursiveField").TypeSchema as UnionSchema).Schemas[1]);
                            record.RecursiveField.IntField = random.Next();
                            record.RecursiveField.RecursiveField = null;
                            expected.Add(record);
                        }

                        expected.ForEach(writer.Write);
                        writer.Flush();

                        stream.Seek(0, SeekOrigin.Begin);

                        var streamReader = AvroContainer.CreateReader<Recursive>(stream, true, this.dataContractSettings, new CodecFactory());
                        using (var reader = new SequentialReader<Recursive>(streamReader))
                        {
                            var j = 0;
                            foreach (var avroRecord in reader.Objects)
                            {
                                Assert.AreEqual(expected[j]["IntField"], avroRecord.IntField);
                                Assert.AreEqual(((dynamic)expected[j]["RecursiveField"])["IntField"], avroRecord.RecursiveField.IntField);
                                Assert.AreEqual(
                                    ((dynamic)expected[j++]["RecursiveField"])["RecursiveField"], avroRecord.RecursiveField.RecursiveField);
                            }
                        }
                    }
                }
            }
        }
    }
}
