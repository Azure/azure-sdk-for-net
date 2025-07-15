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
        internal delegate void TypeValidation(ModelExpectation expectation, bool invocationDuped, Dictionary<string, TypeBuilderSpec> dict);
        private const string ContextParmeter = ", LocalContext.Default";

        internal readonly struct ModelExpectation
        {
            public ModelExpectation(
                string type,
                string ns,
                Action<TypeBuilderSpec> modelValidation,
                TypeRef context)
            {
                TypeName = type;
                Namespace = ns;
                ModelValidation = modelValidation;
                Context = context;
            }
            public string TypeName { get; }
            public string Namespace { get; }
            public Action<TypeBuilderSpec> ModelValidation { get; }
            public TypeRef Context { get; }
        }

        internal static readonly TypeRef s_localContext = new("LocalContext", "TestProject", "", "global::TestProject.LocalContext", null);

        internal static readonly Dictionary<string, ModelExpectation> s_modelExpectations = new()
        {
            { JsonModel, new(
                JsonModel,
                "TestProject",
                AssertJsonModelBuilder,
                s_localContext) },
            { AvailabilitySetData, new(
                AvailabilitySetData,
                "System.ClientModel.Tests.Client.Models.ResourceManager.Compute",
                AssertAvailabilitySetDataBuilder,
                new TypeRef(
                    "TestClientModelReaderWriterContext",
                    "System.ClientModel.Tests.ModelReaderWriterTests",
                    "",
                    "global::System.ClientModel.Tests.ModelReaderWriterTests.TestClientModelReaderWriterContext",
                    null)) },
            { BaseModel, new(
                BaseModel,
                "System.ClientModel.Tests.Client.ModelReaderWriterTests.Models",
                AssertBaseModelBuilder,
                new TypeRef(
                    "TestClientModelReaderWriterContext",
                    "System.ClientModel.Tests.ModelReaderWriterTests",
                    "",
                    "global::System.ClientModel.Tests.ModelReaderWriterTests.TestClientModelReaderWriterContext",
                    null)) },
            { LocalBaseModel, new(
                LocalBaseModel,
                "TestProject",
                AssertLocalBaseModelBuilder,
                s_localContext) }
        };

        private static readonly Dictionary<string, string> s_typeSources = new()
        {
            { JsonModel,
"""

    public class JsonModel : IJsonModel<JsonModel>
    {
        JsonModel IJsonModel<JsonModel>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => new JsonModel();
        JsonModel IPersistableModel<JsonModel>.Create(BinaryData data, ModelReaderWriterOptions options) => new JsonModel();
        string IPersistableModel<JsonModel>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";
        void IJsonModel<JsonModel>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options) { }
        BinaryData IPersistableModel<JsonModel>.Write(ModelReaderWriterOptions options) => BinaryData.Empty;
    }
""" },
            { AvailabilitySetData, "" },
            { BaseModel, "" },
            { LocalBaseModel,
"""

    [PersistableModelProxy(typeof(UnknownLocalBaseModel))]
    public abstract class LocalBaseModel : IJsonModel<LocalBaseModel>
    {
        LocalBaseModel IJsonModel<LocalBaseModel>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => new UnknownLocalBaseModel();
        LocalBaseModel IPersistableModel<LocalBaseModel>.Create(BinaryData data, ModelReaderWriterOptions options) => new UnknownLocalBaseModel();
        string IPersistableModel<LocalBaseModel>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";
        void IJsonModel<LocalBaseModel>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options) { }
        BinaryData IPersistableModel<LocalBaseModel>.Write(ModelReaderWriterOptions options) => BinaryData.Empty;
    }

    internal class UnknownLocalBaseModel : LocalBaseModel, IJsonModel<LocalBaseModel>
    {
        LocalBaseModel IJsonModel<LocalBaseModel>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => new UnknownLocalBaseModel();
        LocalBaseModel IPersistableModel<LocalBaseModel>.Create(BinaryData data, ModelReaderWriterOptions options) => new UnknownLocalBaseModel();
        string IPersistableModel<LocalBaseModel>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";
        void IJsonModel<LocalBaseModel>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options) { }
        BinaryData IPersistableModel<LocalBaseModel>.Write(ModelReaderWriterOptions options) => BinaryData.Empty;
    }
""" }
        };

        private static readonly Dictionary<string, string> s_usings = new()
        {
            { JsonModel, "" },
            { AvailabilitySetData, "using System.ClientModel.Tests.Client.Models.ResourceManager.Compute;" },
            { BaseModel, "using System.ClientModel.Tests.Client.ModelReaderWriterTests.Models;" },
            { LocalBaseModel, "" }
        };

        private static readonly Dictionary<string, string> s_namespaces = new()
        {
            { JsonModel, "TestProject" },
            { AvailabilitySetData, "System.ClientModel.Tests.Client.Models.ResourceManager.Compute" },
            { BaseModel, "System.ClientModel.Tests.Client.ModelReaderWriterTests.Models" },
            { LocalBaseModel, "TestProject" }
        };

        public static readonly IEnumerable<string> LocalTypes =
        [
            JsonModel,
            LocalBaseModel
        ];

        public static readonly IEnumerable<string> Types =
        [
            .. LocalTypes,
            AvailabilitySetData,
            BaseModel,
        ];

        public static readonly IEnumerable<bool> AddedContexts =
        [
            true, // Context added
            //false // Context not added will be added after https://github.com/Azure/azure-sdk-for-net/issues/48294 for now it won't compile so no need to test
        ];

        private static readonly Dictionary<string, Action<TypeBuilderSpec>> s_builderValidators = new()
        {
            { JsonModel, AssertJsonModelBuilder },
            { BaseModel, AssertBaseModelBuilder },
            { AvailabilitySetData, AssertAvailabilitySetDataBuilder },
            { LocalBaseModel, AssertLocalBaseModelBuilder },
            { $"TestProject1.{JsonModel}", AssertTestProject1JsonModelBuilder },
            { $"TestProject1.{LocalBaseModel}", AssertTestProject1LocalBaseModelBuilder }
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
        public void Read_Generic_DupeModel([ValueSource(nameof(LocalTypes))] string type, [ValueSource(nameof(AddedContexts))] bool contextAdded)
            => RunInvocationTest(
                type,
                "ModelReaderWriter.Read<{0}>(BinaryData.Empty, ModelReaderWriterOptions.Json, LocalContext.Default);",
                contextAdded,
                DupeModelCall,
                TypeValidations,
                dupeModel: true);

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
        public void Read_NonGeneric_Parenthesized([ValueSource(nameof(Types))] string type, [ValueSource(nameof(AddedContexts))] bool contextAdded)
            => RunInvocationTest(
                type,
                "ModelReaderWriter.Read(BinaryData.Empty, (typeof({0})), ModelReaderWriterOptions.Json, LocalContext.Default);",
                contextAdded,
                LocalCall,
                TypeValidations);

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

        internal void RunInvocationTest(
            string type,
            string invocation,
            bool contextAdded,
            Func<bool, string, string, string> getCaller,
            List<TypeValidation> validations,
            bool shouldBeFound = true,
            bool addDefaultContext = true,
            bool dupeModel = false)
        {
            string source =
$$"""
using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text.Json;
""";
            if (!string.IsNullOrEmpty(s_usings[type]))
            {
                source += s_usings[type];
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

    [ModelReaderWriterBuildable(typeof({{string.Format(TypeStringFormat, type)}}))]
""";
                if (dupeModel)
                {
                    source +=
$$"""
    [ModelReaderWriterBuildable(typeof({{string.Format(TypeStringFormat, $"TestProject1.{type}")}}))]
""";
                }
                if (type == LocalBaseModel)
                {
                    source +=
$$"""
    [ModelReaderWriterBuildable(typeof(UnknownLocalBaseModel))]
""";
                    if (dupeModel)
                    {
                        source +=
$$"""
    [ModelReaderWriterBuildable(typeof(TestProject1.UnknownLocalBaseModel))]
""";
                    }
                }
                source +=
$$"""
    public partial class LocalContext : ModelReaderWriterContext { }
""";
            }

            if (!string.IsNullOrEmpty(s_typeSources[type]))
            {
                source += s_typeSources[type];
            }

            source +=
$$"""
    {{getCaller(contextAdded, type, invocation)}}
}
""";

            if (dupeModel)
            {
                source +=
"""
namespace TestProject1
{
""";
                source += s_typeSources[type];
                source +=
"""
}
""";
            }

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
                Assert.IsNull(result.GenerationSpec);
            }
            else
            {
                Assert.IsNotNull(result.GenerationSpec);
                Assert.AreEqual("LocalContext", result.GenerationSpec!.Type.Name);
                Assert.AreEqual("TestProject", result.GenerationSpec.Type.Namespace);
                Assert.AreEqual("public", result.GenerationSpec.Modifier);

                //if the persistable is from a dependency, it won't be added to the context builders
                if (!shouldBeFound && type != JsonModel && type != LocalBaseModel)
                {
                    Assert.AreEqual(0, result.GenerationSpec.TypeBuilders.Count);
                    return; // early exit if not found
                }

                var expectedBuilders = shouldBeFound ? validations.Count : 0;
                var modelBuidlers = 1;
                if (type == LocalBaseModel)
                    modelBuidlers++; //need to count both the base and derived class for LocalBaseModel
                expectedBuilders += modelBuidlers;
                if (dupeModel)
                    expectedBuilders = expectedBuilders * 2;

                Assert.AreEqual(expectedBuilders, result.GenerationSpec.TypeBuilders.Count);
                var dict = result.GenerationSpec.TypeBuilders.ToDictionary(t => $"{t.Type.GetInnerItemType().Namespace}.{t.Type.Name}", t => t);

                var fullName = $"{s_namespaces[type]}.{type}";
                Assert.IsTrue(dict.TryGetValue(fullName, out var typeModel));
                var builderValidator = s_builderValidators[type];
                builderValidator(typeModel!);

                if (dupeModel)
                {
                    var dupeFullName = $"TestProject1.{type}";
                    Assert.IsTrue(dict.TryGetValue(dupeFullName, out var dupeTypeModel));
                    builderValidator = s_builderValidators[dupeFullName];
                    builderValidator(dupeTypeModel!);
                }

                if (type == LocalBaseModel)
                {
                    Assert.IsNotNull(dict[fullName].PersistableModelProxy);
                    AssertUnknownLocalBaseModel(dict[fullName].PersistableModelProxy!);

                    if (dupeModel)
                    {
                        var dupeFullName = $"TestProject1.{type}";
                        Assert.IsNotNull(dict[dupeFullName].PersistableModelProxy);
                        AssertUnknownLocalBaseModel(dict[dupeFullName].PersistableModelProxy!, "TestProject1");
                    }
                }

                if (shouldBeFound)
                {
                    foreach (var validation in validations)
                    {
                        validation(s_modelExpectations[type], dupeModel, dict);
                    }
                }
            }
        }

        private string AttributeCall(bool contextAdded, string type, string invocation)
        {
            string result =
$$"""

    [ModelReaderWriterBuildable(typeof({{string.Format(TypeStringFormat, type)}}))]
""";

            if (type == LocalBaseModel)
            {
                result +=
$$"""
    [ModelReaderWriterBuildable(typeof(UnknownLocalBaseModel))]
""";
            }

            result +=
$$"""
    public partial class LocalContext : ModelReaderWriterContext
    {
    }
""";
        return result;
        }

        private string LocalCall(bool contextAdded, string type, string invocation)
        {
            var invocationToUse = contextAdded ? invocation : invocation.Remove(invocation.IndexOf(ContextParmeter), ContextParmeter.Length);
            return
$$"""

    public class Caller
    {
        public void Call()
        {
            {{string.Format(invocationToUse, string.Format(TypeStringFormat, type))}}
        }
    }
""";
        }

        private string DupeModelCall(bool contextAdded, string type, string invocation)
        {
            var invocationToUse = contextAdded ? invocation : invocation.Remove(invocation.IndexOf(ContextParmeter), ContextParmeter.Length);
            return
   $$"""

    public class Caller
    {
        public void Call()
        {
            {{string.Format(invocationToUse, string.Format(TypeStringFormat, type))}}
            {{string.Format(invocationToUse, $"{string.Format(TypeStringFormat, $"TestProject1.{type}")}")}}
        }
    }
""";
        }

        private string DuplicateCall(bool contextAdded, string type, string invocation)
        {
            string code =
$$"""

    public class Caller
    {
        public void Call()
        {
""";
            if (contextAdded)
            {
                code +=
$$"""
                ModelReaderWriter.Read <{{ string.Format(TypeStringFormat, type)}}> (BinaryData.Empty, ModelReaderWriterOptions.Json, LocalContext.Default);
                ModelReaderWriter.Read <{{ string.Format(TypeStringFormat, type)}}> (BinaryData.Empty, ModelReaderWriterOptions.Json, LocalContext.Default);
""";
            }
            else
            {
                code +=
$$"""
                ModelReaderWriter.Read <{{ string.Format(TypeStringFormat, type)}}> (BinaryData.Empty, ModelReaderWriterOptions.Json);
                ModelReaderWriter.Read <{{ string.Format(TypeStringFormat, type)}}> (BinaryData.Empty, ModelReaderWriterOptions.Json);
""";
            }

            code +=
"""
        }
    }
""";

            return code;
        }

        internal static void AssertTestProject1JsonModelBuilder(TypeBuilderSpec jsonModel)
        {
            Assert.AreEqual("internal", jsonModel.Modifier);
            Assert.IsNull(jsonModel.PersistableModelProxy);
            AssertJsonModel(jsonModel.Type, "TestProject1");
            Assert.AreEqual(TypeBuilderKind.IPersistableModel, jsonModel.Kind);
            Assert.AreEqual(s_modelExpectations[jsonModel.Type.Name].Context, jsonModel.ContextType);
        }

        internal static void AssertJsonModelBuilder(TypeBuilderSpec jsonModel)
        {
            Assert.AreEqual("internal", jsonModel.Modifier);
            Assert.IsNull(jsonModel.PersistableModelProxy);
            AssertJsonModel(jsonModel.Type);
            Assert.AreEqual(TypeBuilderKind.IPersistableModel, jsonModel.Kind);
            Assert.AreEqual(s_modelExpectations[jsonModel.Type.Name].Context, jsonModel.ContextType);
        }

        private static void AssertBaseModelBuilder(TypeBuilderSpec baseModel)
        {
            Assert.AreEqual("internal", baseModel.Modifier);
            Assert.IsNotNull(baseModel.PersistableModelProxy);
            AssertBaseModel(baseModel.Type);
            Assert.AreEqual(TypeBuilderKind.IPersistableModel, baseModel.Kind);
            Assert.AreEqual(s_modelExpectations[baseModel.Type.Name].Context, baseModel.ContextType);
        }

        private static void AssertAvailabilitySetDataBuilder(TypeBuilderSpec availabilitySetData)
        {
            Assert.AreEqual("internal", availabilitySetData.Modifier);
            Assert.IsNull(availabilitySetData.PersistableModelProxy);
            AssertAvailabilitySetData(availabilitySetData.Type);
            Assert.AreEqual(TypeBuilderKind.IPersistableModel, availabilitySetData.Kind);
            Assert.AreEqual(s_modelExpectations[availabilitySetData.Type.Name].Context, availabilitySetData.ContextType);
        }

        private static void AssertTestProject1LocalBaseModelBuilder(TypeBuilderSpec localBaseModel)
        {
            Assert.AreEqual("internal", localBaseModel.Modifier);
            Assert.IsNotNull(localBaseModel.PersistableModelProxy);
            AssertLocalBaseModel(localBaseModel.Type, "TestProject1");
            Assert.AreEqual(TypeBuilderKind.IPersistableModel, localBaseModel.Kind);
            Assert.AreEqual(s_modelExpectations[localBaseModel.Type.Name].Context, localBaseModel.ContextType);
        }

        private static void AssertLocalBaseModelBuilder(TypeBuilderSpec localBaseModel)
        {
            Assert.AreEqual("internal", localBaseModel.Modifier);
            Assert.IsNotNull(localBaseModel.PersistableModelProxy);
            AssertLocalBaseModel(localBaseModel.Type);
            Assert.AreEqual(TypeBuilderKind.IPersistableModel, localBaseModel.Kind);
            Assert.AreEqual(s_modelExpectations[localBaseModel.Type.Name].Context, localBaseModel.ContextType);
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

        internal static void AssertLocalBaseModel(TypeRef localBaseModel, string expectedNamespace = "TestProject")
        {
            Assert.AreEqual("LocalBaseModel", localBaseModel.Name);
            Assert.AreEqual(expectedNamespace, localBaseModel.Namespace);
            Assert.AreEqual("LocalBaseModel_", localBaseModel.TypeCaseName);
            Assert.AreEqual("localBaseModel_", localBaseModel.CamelCaseName);
            Assert.AreEqual(0, localBaseModel.ArrayRank);
            Assert.IsNull(localBaseModel.ItemType);
        }

        internal static void AssertUnknownLocalBaseModel(TypeRef unknownLocalBaseModel, string expectedNamespace = "TestProject")
        {
            Assert.AreEqual("UnknownLocalBaseModel", unknownLocalBaseModel.Name);
            Assert.AreEqual(expectedNamespace, unknownLocalBaseModel.Namespace);
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

        [Test]
        public void DuplicateInvocation()
            => RunInvocationTest(
                JsonModel,
                string.Empty,
                true,
                DuplicateCall,
                TypeValidations);
    }
}
