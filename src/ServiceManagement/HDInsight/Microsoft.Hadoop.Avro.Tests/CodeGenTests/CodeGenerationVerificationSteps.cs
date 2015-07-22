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
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Reflection;
    using System.Text;

    using Microsoft.Hadoop.Avro.Schema;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using Newtonsoft.Json.Linq;

    using TechTalk.SpecFlow;

    [Binding]
    public class CodeGenerationVerificationSteps
    {
        private string RootSchema { get; set; }

        private List<string> Sources { get; set; }

        private Assembly Assembly { get; set; }

        private object Expected { get; set; }

        private object Actual { get; set; }

        private Schema ActualSchema { get; set; }

        private Stream Stream { get; set; }

        private string Namespace { get; set; }

        private bool NamespaceIsForced { get; set; }

        private bool HasParentNamespace { get; set; }

        private const string ParentNamespace = "Parent.Namespace";

        [When(@"I generate CSharp code from the schema using a (default|forced) namespace ""(.*)"" and compile the generated code")]
        public void WhenIGenerateCSharpCodeFromTheSchemaUsingADefaultOrForcedNamespaceAndCompileTheGeneratedCode(string forcedOrDefault, string theNamespace)
        {
            this.NamespaceIsForced = forcedOrDefault == @"forced";
            this.Namespace = theNamespace;
            this.Sources = Utilities.GenerateCode(this.RootSchema, this.Namespace, this.NamespaceIsForced).ToList();
            this.Assembly = Utilities.CompileSources(this.Sources);
        }

        [Given(@"I have a record schema (with Parent\.Namespace|without) namespace containing only """"(.*)"""" field")]
        public void GivenIHaveARecordSchemaWithParent_NamespaceNamespaceContainingOnlyField(string withNamespaceOrNot, string fieldSchema)
        {
            this.HasParentNamespace = withNamespaceOrNot == @"with Parent.Namespace";
            var stringBuilder = new StringBuilder();
            stringBuilder.Append(
                @"{""type"":""record"", ""name"":""AvroRecord""");
            if (this.HasParentNamespace)
            {
                stringBuilder.Append(@", ""namespace"":""" + ParentNamespace + @"""");
            }
            stringBuilder.Append(
                @", ""fields"": [");
            stringBuilder.Append(@"{""name"":""AvroField"", ""type"":");
            stringBuilder.Append(fieldSchema);
            stringBuilder.Append(@"}]}");
            this.RootSchema = stringBuilder.ToString();
        }

        [Given(@"the field has a default value """"(.*)""""")]
        public void GivenTheFieldHasA(string defaultValue)
        {
            this.RootSchema = this.RootSchema.Insert(this.RootSchema.Length - 3, @", ""default"":" + defaultValue);
        }

        [Then(@"the generated code is a class containing one field of the corresponding ""(.*)""")]
        public void ThenTheGeneratedCodeIsAClassContainingOneFieldOfTheCorresponding(string type)
        {
            Assert.IsTrue(this.GetRecordType().IsClass);
            Type fieldType = this.GetRecordType().GetProperty("AvroField").PropertyType;
            Assert.AreEqual(Utilities.GetTypeFullName(type), fieldType.ToString());
        }

        [Then(@"I can perform roundtrip serialization of (a randomly created|an) object of the generated class")]
        public void ThenICanPerformRoundtripSerializationOfARandomlyCreatedObjectOfTheGeneratedClass(string randomOrNot)
        {
            if (randomOrNot == "an")
            {
                this.Expected = Activator.CreateInstance(this.GetRecordType());
            }
            else
            {
                var generateMethod = typeof(Utilities).GetMethod("GetRandom", new[] { typeof(bool) }).MakeGenericMethod(new[] { this.GetRecordType() });
                this.Expected = generateMethod.Invoke(null, new object[] { false });
            }
            Type type = this.GetRecordType();

            var firstOrDefault = typeof(AvroSerializer).GetMethods().FirstOrDefault(methodInfo => methodInfo.Name == "Create" && methodInfo.GetParameters().Any() && methodInfo.GetParameters()[0].ParameterType == typeof(AvroSerializerSettings));
            if (firstOrDefault != null)
            {
                object serializer = firstOrDefault.MakeGenericMethod(new[] { type })
                    .Invoke(null, new object[] { new AvroSerializerSettings { Resolver = new AvroDataContractResolver(true) } });
                this.Stream = new MemoryStream();
                serializer.GetType()
                    .GetMethod("Serialize", new[] { typeof(Stream), type })
                    .Invoke(serializer, new[] { this.Stream, this.Expected });
                this.Stream.Seek(0, SeekOrigin.Begin);
                this.Actual = serializer.GetType().GetMethod("Deserialize", new[] { typeof(Stream) })
                    .Invoke(serializer, new object[] { this.Stream });
                this.ActualSchema = (Schema)serializer.GetType().GetProperty("WriterSchema").GetGetMethod().Invoke(serializer, new object[] { });
            }
            Assert.IsNotNull(this.Actual);
        }

        [Then(@"The serialized object should match the deserialized object and namespace of original schema should match namespace of serialized schema")]
        public void ThenTheSerializedObjectShouldMatchTheDeserializedObjectAndNamespacesOfOriginalAndSerializedSchemataShouldMatch()
        {
            Assert.IsTrue(Utilities.GeneratedTypesEquality(this.Expected, this.Actual));
            Assert.AreEqual(JObject.Parse(this.RootSchema)["namespace"].ToString(), ((NamedSchema)((UnionSchema)this.ActualSchema).Schemas[1]).Namespace);
        }

        [Given(@"The default namespace is ""(.*)""")]
        public void GivenTheDefaultNamespaceIs(string defaultNamespace)
        {
            this.Namespace = defaultNamespace;
        }

        [Then(@"the ""(.*)"" must have the namespace ""(.*)""")]
        public void ThenTheMustHaveTheNamespace(string generatedUnionType, string defaultNamespace)
        {
            var namespaces = this.Assembly.GetTypes().Select(t => t.Namespace).Distinct();
            Assert.IsTrue(namespaces.Contains(defaultNamespace));
            var generatedTypeFullName = string.Concat(defaultNamespace, ".", generatedUnionType);
            Assert.IsNotNull(this.Assembly.GetType(generatedTypeFullName));
        }

        [Then(@"the generated class should have one field of the ""(.*)""")]
        public void ThenTheGeneratedClassShouldHaveOneFieldOfThe(string type)
        {
            Type fieldType = this.GetRecordType().GetProperty("AvroField").PropertyType;
            Assert.AreEqual(this.Namespace + "." + type, fieldType.ToString());
        }

        private Type GetRecordType()
        {
            if (!this.NamespaceIsForced && this.HasParentNamespace)
            {
                return this.Assembly.GetType(ParentNamespace + ".AvroRecord");
            }
            return this.Assembly.GetType(this.Namespace + ".AvroRecord");
        }
    }
}