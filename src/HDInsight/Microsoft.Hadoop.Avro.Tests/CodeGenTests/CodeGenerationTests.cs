// Copyright (c) Microsoft Corporation
// All rights reserved.

// Licensed under the Apache License, Version 2.0 (the "License"); you may not
// use this file except in compliance with the License.  You may obtain a copy
// of the License at http://www.apache.org/licenses/LICENSE-2.0
// THIS CODE IS PROVIDED *AS IS* BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY
// KIND, EITHER EXPRESS OR IMPLIED, INCLUDING WITHOUT LIMITATION ANY IMPLIED
// WARRANTIES OR CONDITIONS OF TITLE, FITNESS FOR A PARTICULAR PURPOSE,
// MERCHANTABLITY OR NON-INFRINGEMENT.

// See the Apache Version 2.0 License for specific language governing
// permissions and limitations under the License.
namespace Microsoft.Hadoop.Avro.Tests.CodeGenTests
{
    using System.Linq;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public sealed class CodeGenerationTests
    {
        [TestMethod]
        public void CodeGen_NestedSchemaWithoutRootNamespaceUsingDefaultNamespace()
        {
            const string Schema = @"{
                                        ""type"":""record"",
                                        ""name"":""level1"",
                                        ""fields"": [
                                            {
                                                ""name"":""field"",
                                                ""type"": {
                                                        ""type"":""record"",
                                                        ""name"":""level2"",
                                                        ""fields"": [
                                                            {
                                                                ""name"":""field"",
                                                                ""type"":
                                                                {
                                                                        ""type"": ""record"", ""name"": ""level3"", ""fields"": []
                                                                }
                                                            },
                                                        ]
                                                }
                                            },
                                        ]
                                    }";
            var sources = Utilities.GenerateCode(Schema, "Default.Namespace", false).ToList();
            var assembly = Utilities.CompileSources(sources);
            var types = assembly.GetTypes().Select(t => t.ToString()).ToList();
            Assert.IsTrue(types.Contains("Default.Namespace.level1"));
            Assert.IsTrue(types.Contains("Default.Namespace.level2"));
            Assert.IsTrue(types.Contains("Default.Namespace.level3"));
            Assert.AreEqual(assembly.GetType("Default.Namespace.level1").GetProperty("field").PropertyType, assembly.GetType("Default.Namespace.level2"));
            Assert.AreEqual(assembly.GetType("Default.Namespace.level2").GetProperty("field").PropertyType, assembly.GetType("Default.Namespace.level3"));
        }

        [TestMethod]
        public void CodeGen_NestedSchemaWithRootNamespaceUsingDefaultNamespace()
        {
            const string Schema = @"{
                                        ""type"":""record"",
                                        ""name"":""level1"",
                                        ""namespace"":""Root.Namespace"",
                                        ""fields"": [
                                            {
                                                ""name"":""field"",
                                                ""type"": {
                                                        ""type"":""record"",
                                                        ""name"":""level2"",
                                                        ""fields"": [
                                                            {
                                                                ""name"":""field"",
                                                                ""type"":
                                                                {
                                                                        ""type"": ""record"", ""name"": ""level3"", ""fields"": []
                                                                }
                                                            },
                                                        ]
                                                }
                                            },
                                        ]
                                    }";
            var sources = Utilities.GenerateCode(Schema, "Default.Namespace", false).ToList();
            var assembly = Utilities.CompileSources(sources);
            var types = assembly.GetTypes().Select(t => t.ToString()).ToList();
            Assert.IsTrue(types.Contains("Root.Namespace.level1"));
            Assert.IsTrue(types.Contains("Root.Namespace.level2"));
            Assert.IsTrue(types.Contains("Root.Namespace.level3"));
            Assert.AreEqual(assembly.GetType("Root.Namespace.level1").GetProperty("field").PropertyType, assembly.GetType("Root.Namespace.level2"));
            Assert.AreEqual(assembly.GetType("Root.Namespace.level2").GetProperty("field").PropertyType, assembly.GetType("Root.Namespace.level3"));
        }

        [TestMethod]
        public void CodeGen_NestedSchemaWithNoRootNamespaceAndDescendantNamespaceUsingDefaultNamespace()
        {
            const string Schema = @"{
                                        ""type"":""record"",
                                        ""name"":""level1"",
                                        ""fields"": [
                                            {
                                                ""name"":""field"",
                                                ""type"": {
                                                        ""type"":""record"",
                                                        ""name"":""level2"",
                                                        ""namespace"":""Descendant.Namespace"",
                                                        ""fields"": [
                                                            {
                                                                ""name"":""field"",
                                                                ""type"":
                                                                {
                                                                        ""type"": ""record"", ""name"": ""level3"", ""fields"": []
                                                                }
                                                            },
                                                        ]
                                                }
                                            },
                                        ]
                                    }";
            var sources = Utilities.GenerateCode(Schema, "Default.Namespace", false).ToList();
            var assembly = Utilities.CompileSources(sources);
            var types = assembly.GetTypes().Select(t => t.ToString()).ToList();
            Assert.IsTrue(types.Contains("Default.Namespace.level1"));
            Assert.IsTrue(types.Contains("Descendant.Namespace.level2"));
            Assert.IsTrue(types.Contains("Descendant.Namespace.level3"));
            Assert.AreEqual(assembly.GetType("Descendant.Namespace.level2"), assembly.GetType("Default.Namespace.level1").GetProperty("field").PropertyType);
            Assert.AreEqual(assembly.GetType("Descendant.Namespace.level3"), assembly.GetType("Descendant.Namespace.level2").GetProperty("field").PropertyType);
        }

        [TestMethod]
        public void CodeGen_RecursiveSchema()
        {
            const string Schema = @"{
                                        ""type"":""record"",
                                        ""name"":""level1"",
                                        ""namespace"":""Root.Namespace"",
                                        ""fields"": [
                                            {
                                                ""name"":""field"", ""type"": ""Root.Namespace.level1""
                                            }
                                        ]
                                    }";
            var sources = Utilities.GenerateCode(Schema, "Default.Namespace", false).ToList();
            var assembly = Utilities.CompileSources(sources);
            var types = assembly.GetTypes().Select(t => t.ToString()).ToList();
            Assert.IsTrue(types.Contains("Root.Namespace.level1"));
        }

        [TestMethod]
        public void CodeGen_RecursiveSchemaInUnionUsingDefaultNamespace()
        {
            const string Schema = @"{
                                        ""type"":""record"",
                                        ""name"":""level1"",
                                        ""namespace"":""Root.Namespace"",
                                        ""fields"": [
                                            {
                                                ""name"":""field"", ""type"": [""null"", ""Root.Namespace.level1""]
                                            }
                                        ]
                                    }";
            var sources = Utilities.GenerateCode(Schema, "Default.Namespace", false).ToList();
            var assembly = Utilities.CompileSources(sources);
            var types = assembly.GetTypes().Select(t => t.ToString()).ToList();
            Assert.IsTrue(types.Contains("Root.Namespace.level1"));
            Assert.AreEqual(typeof(object), assembly.GetType("Root.Namespace.level1").GetProperty("field").PropertyType);
        }

        [TestMethod]
        public void CodeGen_SchemaWithCStyleComments()
        {
            const string Schema = @"/*
                                     this is an example multiline comment
                                    */
                                    {
                                      ""type"":""record"", //this is a line comment
                                      ""name"":""Student"",
                                      ""namespace"":""MyAvro"",
                                      ""aliases"":[""student1""],
                                      ""fields"": [
                                          {""name"":""field1"",  ""type"":""string"",  ""default"":""Hello//comment ignored here""},
                                          {""name"":""field2"",  ""type"":""string"",  ""default"":""Hello/*comment ignored here*/""}, 
                                      ]
                                    }";
            var sources = Utilities.GenerateCode(Schema, "Default.Namespace", false).ToList();
            var assembly = Utilities.CompileSources(sources);
            var types = assembly.GetTypes().Select(t => t.ToString()).ToList();
            Assert.IsTrue(types.Contains("MyAvro.Student"));
            Assert.AreEqual(typeof(string), assembly.GetType("MyAvro.Student").GetProperty("field1").PropertyType);
            Assert.AreEqual(typeof(string), assembly.GetType("MyAvro.Student").GetProperty("field2").PropertyType);
        }
    }
}
