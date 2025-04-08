// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Tests.Client.ModelReaderWriterTests.Models;
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
        internal const string BaseModel = "BaseModel";
        internal const string LocalBaseModel = "LocalBaseModel";
        internal delegate void TypeValidation(string type, string expectedNamespace, Action<TypeRef> modelValidation, Dictionary<string, TypeBuilderSpec> dict);

        public static readonly IEnumerable<string> Types =
        [
            JsonModel,
            AvailabilitySetData,
            BaseModel,
            LocalBaseModel
        ];

        public static readonly IEnumerable<bool> AddedContexts =
        [
            true, // Context added
            false // Context not added
        ];

        private static readonly Dictionary<string, Action<TypeRef>> s_modelValidators = new()
        {
            { JsonModel, (type) => AssertJsonModel(type) },
            { BaseModel, AssertBaseModel },
            { AvailabilitySetData, AssertAvailabilitySetData },
            { LocalBaseModel, AssertLocalBaseModel }
        };

        private static readonly Dictionary<string, string> s_modelNamespaces = new()
        {
            { JsonModel, "TestProject" },
            { BaseModel, "System.ClientModel.Tests.Client.ModelReaderWriterTests.Models" },
            { AvailabilitySetData, "System.ClientModel.Tests.Client.Models.ResourceManager.Compute" },
            { LocalBaseModel, "TestProject" },
        };

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
            {
                BaseModel,
                [
                    MetadataReference.CreateFromFile(typeof(BaseModel).Assembly.Location),
                ]
            },
        };

        [TestCaseSource(nameof(Types))]
        public void Attribute(string type)
            => RunInvocationTest(
                type,
                string.Empty,
                true,
                AttributeCall,
                TypeValidations,
                addDefaultContext: false);

        [Test, Combinatorial]
        public void Read_Generic([ValueSource(nameof(Types))] string type, [ValueSource(nameof(AddedContexts))] bool contextAdded)
            => RunInvocationTest(
                type,
                "ModelReaderWriter.Read<{0}>(BinaryData.Empty, ModelReaderWriterOptions.Json, LocalContext.Default);",
                contextAdded,
                LocalCall,
                TypeValidations);

        [Test, Combinatorial]
        public void Write_Generic([ValueSource(nameof(Types))] string type, [ValueSource(nameof(AddedContexts))] bool contextAdded)
            => RunInvocationTest(
                type,
                $"ModelReaderWriter.Write<{{0}}>({InitializeObject}, ModelReaderWriterOptions.Json, LocalContext.Default);",
                contextAdded,
                LocalCall,
                TypeValidations);

        [Test, Combinatorial]
        public void Read_NonGeneric([ValueSource(nameof(Types))] string type, [ValueSource(nameof(AddedContexts))] bool contextAdded)
            => RunInvocationTest(
                type,
                "ModelReaderWriter.Read(BinaryData.Empty, typeof({0}), ModelReaderWriterOptions.Json, LocalContext.Default);",
                contextAdded,
                LocalCall,
                TypeValidations);

        [Test, Combinatorial]
        public void Read_NonGeneric_NoInitializerSyntax([ValueSource(nameof(Types))] string type, [ValueSource(nameof(AddedContexts))] bool contextAdded)
            => RunInvocationTest(
                type,
                string.Empty,
                contextAdded,
                LocalNoInitCall,
                TypeValidations,
                false);

        [Test, Combinatorial]
        public void Read_NonGeneric_Parenthesized([ValueSource(nameof(Types))] string type, [ValueSource(nameof(AddedContexts))] bool contextAdded)
            => RunInvocationTest(
                type,
                "ModelReaderWriter.Read(BinaryData.Empty, (typeof({0})), ModelReaderWriterOptions.Json, LocalContext.Default);",
                contextAdded,
                LocalCall,
                TypeValidations);

        [Test, Combinatorial]
        public void Read_NonGeneric_Parameter([ValueSource(nameof(Types))] string type, [ValueSource(nameof(AddedContexts))] bool contextAdded)
            => RunInvocationTest(
                type,
                string.Empty,
                contextAdded,
                ParameterCall,
                TypeValidations,
                false);

        [Test, Combinatorial]
        public void Write_NonGeneric([ValueSource(nameof(Types))] string type, [ValueSource(nameof(AddedContexts))] bool contextAdded)
            => RunInvocationTest(
                type,
                $"ModelReaderWriter.Write((object){InitializeObject}, ModelReaderWriterOptions.Json, LocalContext.Default);",
                contextAdded,
                LocalCall,
                TypeValidations);

        [Test, Combinatorial]
        public void Read_NonGeneric_Type([ValueSource(nameof(Types))] string type, [ValueSource(nameof(AddedContexts))] bool contextAdded)
            => RunInvocationTest(
                type,
                $$"""
                Type type = typeof({0});
                ModelReaderWriter.Read(BinaryData.Empty, type, ModelReaderWriterOptions.Json, LocalContext.Default);
                """,
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

            if (type == BaseModel)
            {
                source +=
$"""
using System.ClientModel.Tests.Client.ModelReaderWriterTests.Models;
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

            if (type == LocalBaseModel)
            {
                source +=
$$"""

    [PersistableModelProxy(typeof(UnknownLocalBaseModel))]
    public abstract class LocalBaseModel : IJsonModel<LocalBaseModel>
    {
        public LocalBaseModel Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => new UnknownLocalBaseModel();

        public LocalBaseModel Create(BinaryData data, ModelReaderWriterOptions options) => new UnknownLocalBaseModel();

        public string GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

        public void Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
        }

        public BinaryData Write(ModelReaderWriterOptions options) => BinaryData.Empty;
    }

    internal class UnknownLocalBaseModel : LocalBaseModel, IJsonModel<LocalBaseModel>
    {
        public LocalBaseModel Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => new UnknownLocalBaseModel();

        public LocalBaseModel Create(BinaryData data, ModelReaderWriterOptions options) => new UnknownLocalBaseModel();

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
                Assert.AreEqual("LocalContext", result.ContextFile!.Type.Name);
                Assert.AreEqual("TestProject", result.ContextFile.Type.Namespace);
                Assert.AreEqual("public", result.ContextFile.Modifier);

                //if the persistable is from a dependency, it won't be added to the context builders
                if (!shouldBeFound && type != JsonModel && type != LocalBaseModel)
                {
                    Assert.AreEqual(0, result.ContextFile.TypeBuilders.Count);
                    return; // early exit if not found
                }

                var expectedBuilders = shouldBeFound ? validations.Count + 1 : 1;
                if (type == LocalBaseModel)
                    expectedBuilders++; //need to count both the base and derived class for LocalBaseModel

                Assert.AreEqual(expectedBuilders, result.ContextFile.TypeBuilders.Count);
                var dict = result.ContextFile.TypeBuilders.ToDictionary(t => t.Type.Name, t => t);

                Assert.IsTrue(dict.ContainsKey(type));
                var modelValidator = s_modelValidators[type];
                modelValidator(dict[type].Type);

                if (type == LocalBaseModel)
                {
                    Assert.IsNotNull(dict[type].PersistableModelProxy);
                    AssertUnknownLocalBaseModel(dict[type].PersistableModelProxy!);
                }

                if (shouldBeFound)
                {
                    foreach (var validation in validations)
                    {
                        validation(type, s_modelNamespaces[type], modelValidator, dict);
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
            Assert.AreEqual("JsonModel_", jsonModel.TypeCaseName);
            Assert.AreEqual("jsonModel_", jsonModel.CamelCaseName);
            Assert.AreEqual(0, jsonModel.ArrayRank);
            Assert.IsNull(jsonModel.ItemType);
        }

        internal static void AssertLocalBaseModel(TypeRef localBaseModel)
        {
            Assert.AreEqual("LocalBaseModel", localBaseModel.Name);
            Assert.AreEqual("TestProject", localBaseModel.Namespace);
            Assert.AreEqual("LocalBaseModel_", localBaseModel.TypeCaseName);
            Assert.AreEqual("localBaseModel_", localBaseModel.CamelCaseName);
            Assert.AreEqual(0, localBaseModel.ArrayRank);
            Assert.IsNull(localBaseModel.ItemType);
        }

        internal static void AssertUnknownLocalBaseModel(TypeRef unknownLocalBaseModel)
        {
            Assert.AreEqual("UnknownLocalBaseModel", unknownLocalBaseModel.Name);
            Assert.AreEqual("TestProject", unknownLocalBaseModel.Namespace);
            Assert.AreEqual("UnknownLocalBaseModel_", unknownLocalBaseModel.TypeCaseName);
            Assert.AreEqual("unknownLocalBaseModel_", unknownLocalBaseModel.CamelCaseName);
            Assert.AreEqual(0, unknownLocalBaseModel.ArrayRank);
            Assert.IsNull(unknownLocalBaseModel.ItemType);
        }

        internal static void AssertBaseModel(TypeRef baseModel)
        {
            Assert.AreEqual("BaseModel", baseModel.Name);
            Assert.AreEqual("System.ClientModel.Tests.Client.ModelReaderWriterTests.Models", baseModel.Namespace);
            Assert.AreEqual("BaseModel_", baseModel.TypeCaseName);
            Assert.AreEqual("baseModel_", baseModel.CamelCaseName);
            Assert.AreEqual(0, baseModel.ArrayRank);
            Assert.IsNull(baseModel.ItemType);
        }

        private static void AssertAvailabilitySetData(TypeRef aset)
        {
            Assert.AreEqual("AvailabilitySetData", aset.Name);
            Assert.AreEqual("System.ClientModel.Tests.Client.Models.ResourceManager.Compute", aset.Namespace);
            Assert.AreEqual("AvailabilitySetData_", aset.TypeCaseName);
            Assert.AreEqual("availabilitySetData_", aset.CamelCaseName);
            Assert.AreEqual(0, aset.ArrayRank);
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
