// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Tests.Client.Models.ResourceManager.Compute;
using System.Collections.Generic;
using System.Linq;
using Microsoft.CodeAnalysis;
using NUnit.Framework;

namespace System.ClientModel.SourceGeneration.Tests.Unit.InvocationTests
{
    internal abstract class InvocationTestBase
    {
        internal const string JsonModel = "JsonModel";
        internal const string AvailabilitySetData = "AvailabilitySetData";
        internal delegate void TypeValidation(string type, Action<TypeRef> modelValidation, Dictionary<string, TypeBuilderSpec> dict);

        protected abstract List<TypeValidation> TypeValidations { get; }
        protected virtual string InitializeObject => "new {0}()";
        protected abstract string TypeStringFormat { get; }

        private static readonly Dictionary<string, List<MetadataReference>> _metaData = new()
        {
            {
                AvailabilitySetData,
                [
                    MetadataReference.CreateFromFile(typeof(AvailabilitySetData).Assembly.Location),
                ]
            },
        };

        [Test]
        public void Local_Attribute()
            => RunInvocationTest(
                JsonModel,
                string.Empty,
                true,
                AttributeCall,
                TypeValidations,
                addDefaultContext: false);

        [Test]
        public void Dependency_Attribute()
            => RunInvocationTest(
                AvailabilitySetData,
                string.Empty,
                true,
                AttributeCall,
                TypeValidations,
                addDefaultContext: false);

        [TestCase(true)]
        [TestCase(false)]
        public void Read_Generic_Local(bool contextAdded)
            => RunInvocationTest(
                JsonModel,
                "ModelReaderWriter.Read<{0}>(BinaryData.Empty, ModelReaderWriterOptions.Json, LocalContext.Default);",
                contextAdded,
                LocalCall,
                TypeValidations);

        [TestCase(true)]
        [TestCase(false)]
        public void Read_Generic_Dependency(bool contextAdded)
            => RunInvocationTest(
                AvailabilitySetData,
                "ModelReaderWriter.Read<{0}>(BinaryData.Empty, ModelReaderWriterOptions.Json, LocalContext.Default);",
                contextAdded,
                LocalCall,
                TypeValidations);

        [TestCase(true)]
        [TestCase(false)]
        public void Write_Generic_Local(bool contextAdded)
            => RunInvocationTest(
                JsonModel,
                $"ModelReaderWriter.Write<{{0}}>({InitializeObject}, ModelReaderWriterOptions.Json, LocalContext.Default);",
                contextAdded,
                LocalCall,
                TypeValidations);

        [TestCase(true)]
        [TestCase(false)]
        public void Write_Generic_Dependency(bool contextAdded)
          => RunInvocationTest(
              AvailabilitySetData,
              $"ModelReaderWriter.Write<{{0}}>({InitializeObject}, ModelReaderWriterOptions.Json, LocalContext.Default);",
              contextAdded,
                LocalCall,
                TypeValidations);

        [TestCase(true)]
        [TestCase(false)]
        public void Read_NonGeneric_Local(bool contextAdded)
            => RunInvocationTest(
                JsonModel,
                "ModelReaderWriter.Read(BinaryData.Empty, typeof({0}), ModelReaderWriterOptions.Json, LocalContext.Default);",
                contextAdded,
                LocalCall,
                TypeValidations);

        [TestCase(true)]
        [TestCase(false)]
        public void Read_NonGeneric_Local_NoInit(bool contextAdded)
            => RunInvocationTest(
                JsonModel,
                string.Empty,
                contextAdded,
                LocalNoInitCall,
                TypeValidations,
                false);

        [TestCase(true)]
        [TestCase(false)]
        public void Read_NonGeneric_Local_Parenthesized(bool contextAdded)
            => RunInvocationTest(
                JsonModel,
                "ModelReaderWriter.Read(BinaryData.Empty, (typeof({0})), ModelReaderWriterOptions.Json, LocalContext.Default);",
                contextAdded,
                LocalCall,
                TypeValidations);

        [TestCase(true)]
        [TestCase(false)]
        public void Read_NonGeneric_Parameter(bool contextAdded)
            => RunInvocationTest(
                JsonModel,
                string.Empty,
                contextAdded,
                ParameterCall,
                TypeValidations,
                false);

        [TestCase(true)]
        [TestCase(false)]
        public void Write_NonGeneric_Local(bool contextAdded)
            => RunInvocationTest(
                JsonModel,
                $"ModelReaderWriter.Write((object){InitializeObject}, ModelReaderWriterOptions.Json, LocalContext.Default);",
                contextAdded,
                LocalCall,
                TypeValidations);

        [TestCase(true)]
        [TestCase(false)]
        public void Read_NonGeneric_Dependency(bool contextAdded)
            => RunInvocationTest(
                AvailabilitySetData,
                "ModelReaderWriter.Read(BinaryData.Empty, typeof({0}), ModelReaderWriterOptions.Json, LocalContext.Default);",
                contextAdded,
                LocalCall,
                TypeValidations);

        [TestCase(true)]
        [TestCase(false)]
        public void Read_NonGeneric_Type_Dependency(bool contextAdded)
            => RunInvocationTest(
                AvailabilitySetData,
                $$"""
                Type type = typeof({0});
                ModelReaderWriter.Read(BinaryData.Empty, type, ModelReaderWriterOptions.Json, LocalContext.Default);
                """,
                contextAdded,
                LocalCall,
                TypeValidations);

        [TestCase(true)]
        [TestCase(false)]
        public void Write_NonGeneric_Dependency(bool contextAdded)
            => RunInvocationTest(
                AvailabilitySetData,
                $"ModelReaderWriter.Write((object){InitializeObject}, ModelReaderWriterOptions.Json, LocalContext.Default);",
                contextAdded,
                LocalCall,
                TypeValidations);

        internal static void RunInvocationTest(
            string type,
            string invocation,
            bool contextAdded,
            Func<string, string, string> getCaller,
            List<TypeValidation> validations,
            bool shouldBeFound = true,
            bool addDefaultContext = true)
        {
            string source =
$$"""
using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text.Json;
""";
            if (type == AvailabilitySetData)
            {
                source +=
$"""
using System.ClientModel.Tests.Client.Models.ResourceManager.Compute;
""";
            }
            source +=
$$"""

namespace TestProject
{
""";
            if (addDefaultContext && contextAdded)
            {
                source +=
$$"""

    public partial class LocalContext : ModelReaderWriterContext { }
""";
            }

            if (type == JsonModel)
            {
                source +=
$$"""

    public class JsonModel : IJsonModel<JsonModel>
    {
        public JsonModel Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => new JsonModel();

        public JsonModel Create(BinaryData data, ModelReaderWriterOptions options) => new JsonModel();

        public string GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

        public void Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
        }

        public BinaryData Write(ModelReaderWriterOptions options) => BinaryData.Empty;
    }
""";
            }
            source +=
$$"""
    {{getCaller(type, invocation)}}
}
""";

            if (!_metaData.TryGetValue(type, out var typeMetaData))
            {
                typeMetaData = [];
            }

            Compilation compilation = CompilationHelper.CreateCompilation(
                source,
                additionalReferences:
                [
                    MetadataReference.CreateFromFile(typeof(List<>).Assembly.Location),
                    .. typeMetaData
                ]);

            var result = CompilationHelper.RunSourceGenerator(compilation);

            Assert.AreEqual(0, result.Diagnostics.Length);

            if (!contextAdded)
            {
                Assert.IsNull(result.ContextFile);
            }
            else
            {
                Assert.IsNotNull(result.ContextFile);
                var expectedBuilders = shouldBeFound ? validations.Count + 1 : 1;

                Assert.AreEqual(expectedBuilders, result.ContextFile!.TypeBuilders.Count);
                var dict = result.ContextFile.TypeBuilders.ToDictionary(t => t.Type.Name, t => t);

                Assert.IsTrue(dict.ContainsKey(type));
                var item = dict[type];
                Action<TypeRef> modelValidation = type == JsonModel ? (type) => AssertJsonModel(type) : AssertAvailabilitySetData;
                modelValidation(item.Type);

                if (shouldBeFound)
                {
                    foreach (var validation in validations)
                    {
                        validation(type, modelValidation, dict);
                    }
                }
            }
        }

        private string AttributeCall(string type, string invocation)
        {
            return
$$"""

    [ModelReaderWriterBuildable(typeof({{string.Format(TypeStringFormat, type)}}))]
    public partial class LocalContext : ModelReaderWriterContext
    {
    }
""";
        }

        private string LocalCall(string type, string invocation)
        {
            return
$$"""

    public class Caller
    {
        public void Call()
        {
            {{string.Format(invocation, string.Format(TypeStringFormat, type))}}
        }
    }
""";
        }

        private string DuplicateCall(string type, string invocation)
        {
            return
$$"""

    public class Caller
    {
        public void Call()
        {
            ModelReaderWriter.Read<{{string.Format(TypeStringFormat, type)}}>(BinaryData.Empty, ModelReaderWriterOptions.Json, LocalContext.Default);
            ModelReaderWriter.Read<{{string.Format(TypeStringFormat, type)}}>(BinaryData.Empty, ModelReaderWriterOptions.Json, LocalContext.Default);
        }
    }
""";
        }

        private string ParameterCall(string type, string invocation)
        {
            return
$$"""

    public class Caller
    {
        public void Invoke()
        {
            Call(typeof({{string.Format(TypeStringFormat, type)}}));
        }

        public void Call(Type type)
        {
            ModelReaderWriter.Read(BinaryData.Empty, type, ModelReaderWriterOptions.Json, LocalContext.Default);
        }
    }
""";
        }

        private string LocalNoInitCall(string type, string invocation)
        {
            return
$$"""

    public class Caller
    {
        public void Call()
        {
            object obj = typeof({{string.Format(TypeStringFormat, type)}});
            if (obj is Type type)
            {
                ModelReaderWriter.Read(BinaryData.Empty, type, ModelReaderWriterOptions.Json, LocalContext.Default);
            }
        }
    }
""";
        }

        internal static void AssertJsonModel(TypeRef jsonModel, string expectedNamespace = "TestProject")
        {
            Assert.AreEqual("JsonModel", jsonModel.Name);
            Assert.AreEqual(expectedNamespace, jsonModel.Namespace);
            Assert.IsNull(jsonModel.ItemType);
        }
        private static void AssertAvailabilitySetData(TypeRef aset)
        {
            Assert.AreEqual("AvailabilitySetData", aset.Name);
            Assert.AreEqual("System.ClientModel.Tests.Client.Models.ResourceManager.Compute", aset.Namespace);
            Assert.IsNull(aset.ItemType);
        }

        [TestCase(true)]
        [TestCase(false)]
        public void DuplicateInvocation(bool contextAdded)
            => RunInvocationTest(
                JsonModel,
                string.Empty,
                contextAdded,
                DuplicateCall,
                TypeValidations);
    }
}
