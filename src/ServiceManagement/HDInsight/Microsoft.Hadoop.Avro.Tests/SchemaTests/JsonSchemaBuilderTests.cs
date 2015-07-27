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
    using ProtoBuf;

    [TestClass]
    public sealed class JsonSchemaTests
    {
        private JsonSchemaBuilder builder;
        private readonly Dictionary<string, string> emptyAttributes = new Dictionary<string, string>();

        [TestMethod]
        [TestCategory("CheckIn")]
        public void JsonSchemaBuilder_BuildBooleanSchema()
        {
            var schema = this.builder.BuildSchema(@"""boolean""");

            Assert.IsTrue(schema is BooleanSchema);
            CollectionAssert.AreEqual(this.emptyAttributes.ToList(), schema.Attributes.ToList());
        }

        [TestMethod]
        [TestCategory("CheckIn")]
        public void JsonSchemaBuilder_BuildIntSchema()
        {
            var schema = this.builder.BuildSchema(@"""int""");

            Assert.IsTrue(schema is IntSchema);
            CollectionAssert.AreEqual(this.emptyAttributes.ToList(), schema.Attributes.ToList());
        }

        [TestMethod]
        [TestCategory("CheckIn")]
        public void JsonSchemaBuilder_BuildLongSchema()
        {
            var schema = this.builder.BuildSchema(@"""long""");

            Assert.IsTrue(schema is LongSchema);
            CollectionAssert.AreEqual(this.emptyAttributes.ToList(), schema.Attributes.ToList());
        }

        [TestMethod]
        [TestCategory("CheckIn")]
        public void JsonSchemaBuilder_ClassOfGuidWriterSchema()
        {
            var settings = new AvroSerializerSettings { Resolver = new AvroDataContractResolver(false) };
            IAvroSerializer<ClassOfGuid> serializer = AvroSerializer.Create<ClassOfGuid>(settings);
            string writerSchema = serializer.WriterSchema.ToString();
             AvroSerializer.CreateDeserializerOnly<ClassOfGuid>(writerSchema, settings);
        }

        [TestMethod]
        [TestCategory("CheckIn")]
        public void JsonSchemaBuilder_BuildFloatSchema()
        {
            var schema = this.builder.BuildSchema(@"""float""");

            Assert.IsTrue(schema is FloatSchema);
            CollectionAssert.AreEqual(this.emptyAttributes.ToList(), schema.Attributes.ToList());
        }

        [TestMethod]
        [TestCategory("CheckIn")]
        public void JsonSchemaBuilder_BuildDoubleSchema()
        {
            var schema = this.builder.BuildSchema(@"""double""");

            Assert.IsTrue(schema is DoubleSchema);
            CollectionAssert.AreEqual(this.emptyAttributes.ToList(), schema.Attributes.ToList());
        }

        [TestMethod]
        [TestCategory("CheckIn")]
        public void JsonSchemaBuilder_BuildStringSchema()
        {
            var schema = this.builder.BuildSchema(@"""string""");

            Assert.IsTrue(schema is StringSchema);
            CollectionAssert.AreEqual(this.emptyAttributes.ToList(), schema.Attributes.ToList());
        }

        [TestMethod]
        [TestCategory("CheckIn")]
        public void JsonSchemaBuilder_BuildEnumSchema()
        {
            var schema =
                this.builder.BuildSchema(@"{ ""type"": ""enum"",""name"": ""Suit"",""symbols"" : [""SPADES"", ""HEARTS"", ""DIAMONDS"", ""CLUBS""]}");
            var actual = schema as EnumSchema;

            Assert.IsNotNull(actual);
            Assert.AreEqual(4, actual.Symbols.Count);
            Assert.AreEqual(4, actual.AvroToCSharpValueMapping.Count());
            Assert.AreEqual(0, actual.AvroToCSharpValueMapping.ElementAt(0));
            Assert.IsTrue(actual.Symbols.ElementAt(0).Equals("SPADES"));
            Assert.AreEqual(3, actual.AvroToCSharpValueMapping.ElementAt(3));
            Assert.IsTrue(actual.Symbols.ElementAt(3).Equals("CLUBS"));
        }

        [TestMethod]
        [TestCategory("CheckIn")]
        public void JsonSchemaBuilder_BuildEnumSchemaUsingPublicMemberContractResolverWithCSharpNulls()
        {
            const string Expected =
                "{" +
                    "\"type\":\"enum\"," +
                    "\"name\":\"Microsoft.Hadoop.Avro.Tests.RandomEnumeration\"," +
                    "\"symbols\":" + "[" +
                        "\"Value0\"," +
                        "\"Value1\"," +
                        "\"Value2\"," +
                        "\"Value3\"," +
                        "\"Value4\"," +
                        "\"Value5\"," +
                        "\"Value6\"," +
                        "\"Value7\"," +
                        "\"Value8\"," +
                        "\"Value9\"" +
                "]}";

            var serializer =
                AvroSerializer.Create<Utilities.RandomEnumeration>(
                    new AvroSerializerSettings { Resolver = new AvroPublicMemberContractResolver(true) });

            Assert.AreEqual(serializer.WriterSchema, serializer.ReaderSchema);
            Assert.AreEqual(Expected, serializer.ReaderSchema.ToString());
        }

        [TestMethod]
        [TestCategory("CheckIn")]
        public void JsonSchemaBuilder_BuildNullSchema()
        {
            const string StringSchema = @"""null""";
            var schema = this.builder.BuildSchema(StringSchema);

            Assert.IsTrue(schema is NullSchema);
            CollectionAssert.AreEqual(this.emptyAttributes.ToList(), schema.Attributes.ToList());

            var actual = SerializeRoundTrip(StringSchema, null);
            Assert.AreEqual(null, actual);
        }

        [TestMethod]
        [TestCategory("CheckIn")]
        public void JsonSchemaBuilder_BuildNullSchemaWithCustomAttribute()
        {
            const string StringSchema = @"{ ""type"" : ""null"", ""custom attribute"": ""custom value"" }";
            var schema = this.builder.BuildSchema(StringSchema);

            Assert.IsTrue(schema is NullSchema);
            Assert.IsTrue(schema.Attributes.ContainsKey("custom attribute"));

            var actual = SerializeRoundTrip(StringSchema, null);
            Assert.AreEqual(null, actual);
        }

        [TestMethod]
        [TestCategory("CheckIn")]
        public void JsonSchemaBuilder_BuildBytesSchema()
        {
            var schema = this.builder.BuildSchema(@"""bytes""");

            Assert.IsTrue(schema is BytesSchema);
            CollectionAssert.AreEqual(this.emptyAttributes.ToList(), schema.Attributes.ToList());
        }

        #region record schema tests

        [TestMethod]
        [TestCategory("CheckIn")]
        public void JsonSchemaBuilder_BuildSimpleRecordSchema()
        {
            const string InputJson = @"{
                  ""type"": ""record"",
                  ""name"": ""testrecord"",
                  "".netclass"": [""testrecordal""],
                  ""aliases"": [""testrecordal""],
                  ""fields"" : 
                  [
                      {
                          ""name"": ""value"",
                          ""type"": ""long"",
                          ""aliases"": [""testrecordal"", ""anotheralias""],
                          ""default"" : 1000
                      },
                  ]
               }";

            var schema = this.builder.BuildSchema(InputJson) as RecordSchema;

            Assert.IsNotNull(schema);
            Assert.AreEqual("testrecord", schema.Name);
            Assert.IsTrue(schema.Attributes.ContainsKey(".netclass"));
        }

        [TestMethod]
        [TestCategory("CheckIn")]
        public void JsonSchemaBuilder_BuildRecordSchemaForIntClassUsingPublicMemberContractResolverWithCSharpNulls()
        {
            const string Expected =
                "[" +
                    "\"null\"," +
                    "{" +
                        "\"type\":\"record\"," +
                        "\"name\":\"Microsoft.Hadoop.Avro.Tests.ClassOfInt\"," +
                        "\"fields\":[{\"name\":\"PrimitiveInt\"," + "\"type\":\"int\"}]" +
                    "}" +
                "]";

            var serializer =
                AvroSerializer.Create<ClassOfInt>(new AvroSerializerSettings { Resolver = new AvroPublicMemberContractResolver(true) });

            Assert.AreEqual(serializer.WriterSchema, serializer.ReaderSchema);
            Assert.AreEqual(Expected, serializer.ReaderSchema.ToString());
        }

        [TestMethod]
        [TestCategory("CheckIn")]
        public void JsonSchemaBuilder_BuildRecordSchemaForNestedClassUsingPublicMemberContractResolverWithCSharpNulls()
        {
            const string Expected =
                "[" +
                    "\"null\"," +
                    "{" +
                        "\"type\":\"record\"," +
                        "\"name\":\"Microsoft.Hadoop.Avro.Tests.NestedClass\"," +
                        "\"fields\":" +
                            "[" +
                                "{" +
                                    "\"name\":\"ClassOfIntReference\"," +
                                    "\"type\":" +
                                        "[" +
                                            "\"null\"," +
                                            "{" +
                                                "\"type\":\"record\"," +
                                                "\"name\":\"Microsoft.Hadoop.Avro.Tests.ClassOfInt\"," +
                                                "\"fields\":" +
                                                    "[" +
                                                        "{" +
                                                            "\"name\":\"PrimitiveInt\"," +
                                                            "\"type\":\"int\"" +
                                                        "}" +
                                                    "]" +
                                            "}" +
                                        "]" +
                                "}," +
                                "{" +
                                    "\"name\":\"PrimitiveInt\"," +
                                    "\"type\":\"int\"" +
                                "}" +
                            "]" +
                    "}" +
                "]";

            var serializer =
                AvroSerializer.Create<NestedClass>(new AvroSerializerSettings { Resolver = new AvroPublicMemberContractResolver(true) });

            Assert.AreEqual(serializer.WriterSchema, serializer.ReaderSchema);
            Assert.AreEqual(Expected, serializer.ReaderSchema.ToString());
        }

        [TestMethod]
        [TestCategory("CheckIn")]
        public void JsonSchemaBuilder_BuildRecordSchemaForRecursiveTypeUsingPublicMemberContractResolverWithCSharpNulls()
        {
            const string Expected =
                "[" +
                    "\"null\"," +
                    "{" +
                        "\"type\":\"record\"," +
                        "\"name\":\"Microsoft.Hadoop.Avro.Tests.Recursive\"," +
                        "\"fields\":" +
                                "[" +
                                    "{\"name\":\"IntField\",\"type\":\"int\"}," +
                                    "{\"name\":\"RecursiveField\",\"type\":[\"null\",\"Microsoft.Hadoop.Avro.Tests.Recursive\"]}" +
                                "]" +
                    "}" +
                "]";

            var serializer =
                AvroSerializer.Create<Recursive>(new AvroSerializerSettings { Resolver = new AvroPublicMemberContractResolver(true) });

            Assert.AreEqual(serializer.WriterSchema, serializer.ReaderSchema);
            Assert.AreEqual(Expected, serializer.ReaderSchema.ToString());
        }

        [TestMethod]
        [TestCategory("CheckIn")]
        public void JsonSchemaBuilder_BuildRecordSchemaWithAliases()
        {
            const string InputJson =
                "{" +
                    "\"type\":\"record\"," +
                    "\"name\":\"Microsoft.Hadoop.Avro.Tests.SomeRecord\"," +
                    "\"aliases\":[\"Alternative1\", \"Alternative2\"]," +
                    "\"fields\":[{\"name\":\"IntField\",\"type\":\"int\"}]" +
                "}";

            var schema = this.builder.BuildSchema(InputJson) as RecordSchema;

            Assert.AreEqual(2, schema.Aliases.Count);
            Assert.AreEqual("Microsoft.Hadoop.Avro.Tests.Alternative1", schema.Aliases[0]);
            Assert.AreEqual("Microsoft.Hadoop.Avro.Tests.Alternative2", schema.Aliases[1]);
        }

        [TestMethod]
        [TestCategory("CheckIn")]
        public void JsonSchemaBuilder_BuildRecordSchemaForClassWithListFieldUsingPublicMemberContractResolverWithCSharpNulls()
        {
            const string Expected =
                "[" +
                    "\"null\"," +
                    "{" +
                        "\"type\":\"record\"," +
                        "\"name\":\"Microsoft.Hadoop.Avro.Tests.ClassOfListOfGuid\"," +
                        "\"fields\":[" +
                            "{" +
                                "\"name\":\"ListOfGuid\"," +
                                "\"type\":[" +
                                    "\"null\"," +
                                    "{\"type\":\"array\",\"items\":{\"type\":\"fixed\",\"name\":\"System.Guid\",\"size\":16}}" +
                                "]" +
                            "}" +
                        "]" +
                    "}" +
                "]";

            var serializer =
                AvroSerializer.Create<ClassOfListOfGuid>(new AvroSerializerSettings { Resolver = new AvroPublicMemberContractResolver(true) });

            Assert.AreEqual(serializer.WriterSchema, serializer.ReaderSchema);
            Assert.AreEqual(Expected, serializer.ReaderSchema.ToString());
        }

        [TestMethod]
        [TestCategory("CheckIn")]
        public void JsonSchemaBuilder_BuildRecordSchemaFromAnotherRecordSchema()
        {
            const string InputJson =
                "{" +
                    "\"type\":\"record\"," +
                    "\"name\":\"Microsoft.Hadoop.Avro.Tests.SomeRecord\"," +
                    "\"aliases\":[\"Alternative1\", \"Alternative2\"]," +
                    "\"fields\":[{\"name\":\"IntField\",\"type\":\"int\", \"order\":\"ignore\"}]," +
                    "\"optionalproperty\":\"optionalvalue\"" +
                "}";
            var expected = this.builder.BuildSchema(InputJson) as RecordSchema;
            var actual = this.builder.BuildSchema(expected.ToString()) as RecordSchema;
            Assert.AreEqual(expected.Name, actual.Name);
            Assert.IsTrue(expected.Aliases.SequenceEqual(actual.Aliases));
            Assert.AreEqual(expected.Fields.Count, actual.Fields.Count);
            Assert.AreEqual(expected.Fields[0].FullName, actual.Fields[0].FullName);
            //TODO Sort order should also be the same
            //TODO Assert.AreEqual(expected.Attributes.Count, actual.Attributes.Count);
        }

        #endregion //record schema tests

        #region union schema tests

        [TestMethod]
        [TestCategory("CheckIn")]
        public void JsonSchemaBuilder_BuildUnionSchema()
        {
            var schema = this.builder.BuildSchema(@"[""string"", ""null""]") as UnionSchema;
            Assert.IsNotNull(schema);
            Assert.AreEqual(2, schema.Schemas.Count());
            Assert.IsTrue(schema.Schemas[0] is StringSchema);
            Assert.IsTrue(schema.Schemas[1] is NullSchema);
        }

        [TestMethod]
        [TestCategory("CheckIn")]
        public void JsonSchemaBuilder_BuildNamedUnionSchema()
        {
            var schema = this.builder.BuildSchema(@"{ ""type"": [""string"", ""null""], ""name"": ""TestUnion""}");
            var schemaAsUnion = schema as UnionSchema;
            Assert.IsNotNull(schemaAsUnion);
            Assert.AreEqual(2, schemaAsUnion.Schemas.Count());
            Assert.IsTrue(schemaAsUnion.Schemas[0] is StringSchema);
            Assert.IsTrue(schemaAsUnion.Schemas[1] is NullSchema);
        }

        [TestMethod]
        [TestCategory("CheckIn")]
        [ExpectedException(typeof(SerializationException))]
        public void JsonSchemaBuilder_BuildDirectNestingUnionsSchema()
        {
            this.builder.BuildSchema(@"{ ""type"": [ [""string"", ""null""], ""null""], ""name"": ""TestUnion""}");
        }

        [TestMethod]
        [TestCategory("CheckIn")]
        [ExpectedException(typeof(SerializationException))]
        public void JsonSchemaBuilder_BuildIndirectNestingUnionsSchema()
        {
            this.builder.BuildSchema(@"{ ""type"": [{""type"": [""string"", ""null""], ""name"": ""TestUnion""}, ""null""], ""name"": ""TestUnion""}");
        }

        [TestMethod]
        [TestCategory("CheckIn")]
        [ExpectedException(typeof(SerializationException))]
        public void JsonSchemaBuilder_BuildUnionWithIdenticalUnnamedTypes()
        {
            this.builder.BuildSchema(@"{ ""type"": [""string"", ""string""], ""name"": ""TestUnion""}");
        }

        #endregion //union schema tests

        [TestMethod]
        [TestCategory("CheckIn")]
        [ExpectedException(typeof(ArgumentNullException))]
        public void JsonSchemaBuilder_BuildEmptySchema()
        {
            this.builder.BuildSchema(string.Empty);
        }

        [TestMethod]
        [TestCategory("CheckIn")]
        [ExpectedException(typeof(SerializationException))]
        public void JsonSchemaBuilder_BuildInvalidSchema()
        {
            this.builder.BuildSchema("1");
        }

        [TestMethod]
        [TestCategory("CheckIn")]
        [ExpectedException(typeof(SerializationException))]
        public void JsonSchemaBuilder_BuildSchemaWithInvalidAvroType()
        {
            const string StringSchema = @"{ ""type"" : ""invalid"", ""custom attribute"": ""custom value"" }";
            this.builder.BuildSchema(StringSchema);
        }

        [TestMethod]
        [TestCategory("CheckIn")]
        [ExpectedException(typeof(SerializationException))]
        public void JsonSchemaBuilder_BuildEnumSchemaWithInvalidSymbols()
        {
            const string Expected =
                "{" +
                    "\"type\":\"enum\"," +
                    "\"name\":\"Microsoft.Hadoop.Avro.Tests.RandomEnumeration\"," +
                    "\"symbols\":" + "[" +
                        "\"Value0\"," +
                        "{\"InvalidName\":\"InvalidValue\"}," +
                "]}";

            this.builder.BuildSchema(Expected);
        }

        [TestMethod]
        [TestCategory("CheckIn")]
        [ExpectedException(typeof(SerializationException))]
        public void JsonSchemaBuilder_BuildArraySchemaWithNoItems()
        {
            const string Expected = "{\"type\":\"array\"}";

            this.builder.BuildSchema(Expected);
        }

        [TestMethod]
        [TestCategory("CheckIn")]
        [ExpectedException(typeof(SerializationException))]
        public void JsonSchemaBuilder_BuildMapSchemaWithNoValues()
        {
            const string Expected = "{\"type\":\"map\"}";

            this.builder.BuildSchema(Expected);
        }

        [TestMethod]
        [TestCategory("CheckIn")]
        [ExpectedException(typeof(SerializationException))]
        public void JsonSchemaBuilder_BuildRecordSchemaWithInvalidAliaseJsonType()
        {
            const string Expected = "{" +
                    "\"type\":\"record\"," +
                    "\"name\":\"Microsoft.Hadoop.Avro.Tests.SomeRecord\"," +
                    "\"aliases\":[{\"InvalidName\":\"InvalidValue\"}, \"Alternative2\"]," +
                    "\"fields\":[{\"name\":\"IntField\",\"type\":\"int\"}]," +
                    "\"optionalproperty\":\"optionalvalue\"" +
                "}";

            this.builder.BuildSchema(Expected);
        }

        [TestMethod]
        [TestCategory("CheckIn")]
        [ExpectedException(typeof(SerializationException))]
        public void JsonSchemaBuilder_BuildRecordSchemaWithEmptyAliases()
        {
            const string Expected = "{" +
                    "\"type\":\"record\"," +
                    "\"name\":\"Microsoft.Hadoop.Avro.Tests.SomeRecord\"," +
                    "\"aliases\":[\"\", \"Alternative2\"]," +
                    "\"fields\":[{\"name\":\"IntField\",\"type\":\"int\"}]," +
                    "\"optionalproperty\":\"optionalvalue\"" +
                "}";

            this.builder.BuildSchema(Expected);
        }

        [TestMethod]
        [TestCategory("CheckIn")]
        [ExpectedException(typeof(SerializationException))]
        public void JsonSchemaBuilder_BuildRecordSchemaWithMissingFieldType()
        {
            const string Expected = "{" +
                    "\"type\":\"record\"," +
                    "\"name\":\"Microsoft.Hadoop.Avro.Tests.SomeRecord\"," +
                    "\"fields\":[{\"name\":\"IntField\"}]" +
                "}";

            this.builder.BuildSchema(Expected);
        }

        [TestMethod]
        [TestCategory("CheckIn")]
        [ExpectedException(typeof(SerializationException))]
        public void JsonSchemaBuilder_BuildRecordSchemaWithInvalidFieldJsonType()
        {
            const string Expected = "{" +
                    "\"type\":\"record\"," +
                    "\"name\":\"Microsoft.Hadoop.Avro.Tests.SomeRecord\"," +
                    "\"fields\":[\"invalidfield\", {\"name\":\"IntField\"}]" +
                "}";

            this.builder.BuildSchema(Expected);
        }

        [TestMethod]
        [TestCategory("CheckIn")]
        [ExpectedException(typeof(SerializationException))]
        public void JsonSchemaBuilder_BuildRecordSchemaWithInvalidSortOrder()
        {
            const string Expected = "{" +
                    "\"type\":\"record\"," +
                    "\"name\":\"Microsoft.Hadoop.Avro.Tests.SomeRecord\"," +
                    "\"fields\":[{\"name\":\"IntField\",\"type\":\"int\", \"order\":\"invalidOrder\"}]," +
                "}";

            this.builder.BuildSchema(Expected);
        }

        [TestMethod]
        [TestCategory("CheckIn")]
        [ExpectedException(typeof(SerializationException))]
        public void JsonSchemaBuilder_BuildFixedSchemaWithInvalidSize()
        {
            const string Expected = "{\"type\": \"fixed\", \"size\": -10, \"name\": \"Name\"}";

            this.builder.BuildSchema(Expected);
        }

        [TestMethod]
        [TestCategory("CheckIn")]
        [ExpectedException(typeof(SerializationException))]
        public void JsonSchemaBuilder_BuildNotMatchingSchema()
        {
            const string StringSchema = @"""null""";
            var schema = this.builder.BuildSchema(StringSchema);

            Assert.IsTrue(schema is NullSchema);
            CollectionAssert.AreEqual(this.emptyAttributes.ToList(), schema.Attributes.ToList());

            SerializeRoundTrip(StringSchema, 5);
        }

        [TestMethod]
        [TestCategory("CheckIn")]
        public void JsonSchemaBuilder_InheritingTheNamespace()
        {
            var schemaWithoutNamespace = @"{
                ""type"":""record"",
                ""name"":""AvroConfiguration"",
                ""namespace"":""com.microsoft.tang.formats.avro"",
                ""fields"":
                [
                    {
                        ""name"":""Bindings"",
                        ""type"":
                        {
                            ""type"":""array"",
                            ""items"":
                            {
                                ""type"":""record"",
                                ""name"":""ConfigurationEntry"",
                                ""fields"":
                                [
                                    {""name"":""Key"",""type"":""string""},
                                    {""name"":""Value"",""type"":""string""}
                                ]
                            }
                        }
                    }
                ]}";

            var schemaWithNamespace = @"{
                ""type"":""record"",
                ""name"":""com.microsoft.tang.formats.avro.AvroConfiguration"",
                ""fields"":
                [
                    {
                        ""name"":""Bindings"",
                        ""type"":
                        {
                            ""type"":""array"",
                            ""items"":
                            {
                                ""type"":""record"",
                                ""name"":""com.microsoft.tang.formats.avro.ConfigurationEntry"",
                                ""fields"":
                                [
                                    {""name"":""Key"",""type"":""string""},
                                    {""name"":""Value"",""type"":""string""}
                                ]
                            }
                        }
                    }
                ]}";

            var schema1 = this.builder.BuildSchema(schemaWithoutNamespace);
            var schema2 = this.builder.BuildSchema(schemaWithNamespace);

            Assert.AreEqual(schema1.ToString(), schema2.ToString());
        }

        // Test for https://github.com/Azure/azure-sdk-for-net/issues/1206
        [TestMethod]
        [TestCategory("CheckIn")]
        public void JsonSchemaBuilder_FixedTypeReferences()
        {
            var guidSchemaJson = "{ \"type\": \"fixed\", \"name\": \"System.Guid\", \"size\": 16 }";

            var schemaWithFixedType = @"{
                ""type"":""record"",
                ""name"":""Config"",
                ""fields"":
                [
                    {
                        ""name"":""ID1"",
                        ""type"": " + guidSchemaJson + @"
                    },
                    {
                        ""name"":""ID2"",
                        ""type"":""System.Guid""
                    }
                ]}";
            var schema = this.builder.BuildSchema(schemaWithFixedType);
        }

        [TestInitialize]
        public void TestSetup()
        {
            this.builder = new JsonSchemaBuilder();
        }

        [TestCleanup]
        public void TestTeardown()
        {
            this.builder = null;
        }

        private static object SerializeRoundTrip(string schema, object obj)
        {
            using (var stream = new MemoryStream())
            {
                var serializer = AvroSerializer.CreateGeneric(schema);
                serializer.Serialize(stream, obj);
                stream.Seek(0, SeekOrigin.Begin);
                return serializer.Deserialize(stream);
            }
        }
    }
}
