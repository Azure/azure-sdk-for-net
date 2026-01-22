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

            Assert.That(result.Diagnostics.Length, Is.EqualTo(0));

            if (!contextAdded)
            {
                Assert.That(result.GenerationSpec, Is.Null);
            }
            else
            {
                Assert.That(result.GenerationSpec, Is.Not.Null);
                Assert.That(result.GenerationSpec!.Type.Name, Is.EqualTo("LocalContext"));
                Assert.That(result.GenerationSpec.Type.Namespace, Is.EqualTo("TestProject"));
                Assert.That(result.GenerationSpec.Modifier, Is.EqualTo("public"));

                //if the persistable is from a dependency, it won't be added to the context builders
                if (!shouldBeFound && type != JsonModel && type != LocalBaseModel)
                {
                    Assert.That(result.GenerationSpec.TypeBuilders.Count, Is.EqualTo(0));
                    return; // early exit if not found
                }

                var expectedBuilders = shouldBeFound ? validations.Count : 0;
                var modelBuidlers = 1;
                if (type == LocalBaseModel)
                    modelBuidlers++; //need to count both the base and derived class for LocalBaseModel
                expectedBuilders += modelBuidlers;
                if (dupeModel)
                    expectedBuilders = expectedBuilders * 2;

                Assert.That(result.GenerationSpec.TypeBuilders.Count, Is.EqualTo(expectedBuilders));
                var dict = result.GenerationSpec.TypeBuilders.ToDictionary(t => $"{t.Type.GetInnerItemType().Namespace}.{t.Type.Name}", t => t);

                var fullName = $"{s_namespaces[type]}.{type}";
                Assert.That(dict.TryGetValue(fullName, out var typeModel), Is.True);
                var builderValidator = s_builderValidators[type];
                builderValidator(typeModel!);

                if (dupeModel)
                {
                    var dupeFullName = $"TestProject1.{type}";
                    Assert.That(dict.TryGetValue(dupeFullName, out var dupeTypeModel), Is.True);
                    builderValidator = s_builderValidators[dupeFullName];
                    builderValidator(dupeTypeModel!);
                }

                if (type == LocalBaseModel)
                {
                    Assert.That(dict[fullName].PersistableModelProxy, Is.Not.Null);
                    AssertUnknownLocalBaseModel(dict[fullName].PersistableModelProxy!);

                    if (dupeModel)
                    {
                        var dupeFullName = $"TestProject1.{type}";
                        Assert.That(dict[dupeFullName].PersistableModelProxy, Is.Not.Null);
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
                ModelReaderWriter.Read <{{string.Format(TypeStringFormat, type)}}> (BinaryData.Empty, ModelReaderWriterOptions.Json, LocalContext.Default);
                ModelReaderWriter.Read <{{string.Format(TypeStringFormat, type)}}> (BinaryData.Empty, ModelReaderWriterOptions.Json, LocalContext.Default);
""";
            }
            else
            {
                code +=
$$"""
                ModelReaderWriter.Read <{{string.Format(TypeStringFormat, type)}}> (BinaryData.Empty, ModelReaderWriterOptions.Json);
                ModelReaderWriter.Read <{{string.Format(TypeStringFormat, type)}}> (BinaryData.Empty, ModelReaderWriterOptions.Json);
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
            Assert.That(jsonModel.Modifier, Is.EqualTo("internal"));
            Assert.That(jsonModel.PersistableModelProxy, Is.Null);
            AssertJsonModel(jsonModel.Type, "TestProject1");
            Assert.That(jsonModel.Kind, Is.EqualTo(TypeBuilderKind.IPersistableModel));
            Assert.That(jsonModel.ContextType, Is.EqualTo(s_modelExpectations[jsonModel.Type.Name].Context));
        }

        internal static void AssertJsonModelBuilder(TypeBuilderSpec jsonModel)
        {
            Assert.That(jsonModel.Modifier, Is.EqualTo("internal"));
            Assert.That(jsonModel.PersistableModelProxy, Is.Null);
            AssertJsonModel(jsonModel.Type);
            Assert.That(jsonModel.Kind, Is.EqualTo(TypeBuilderKind.IPersistableModel));
            Assert.That(jsonModel.ContextType, Is.EqualTo(s_modelExpectations[jsonModel.Type.Name].Context));
        }

        private static void AssertBaseModelBuilder(TypeBuilderSpec baseModel)
        {
            Assert.That(baseModel.Modifier, Is.EqualTo("internal"));
            Assert.That(baseModel.PersistableModelProxy, Is.Not.Null);
            AssertBaseModel(baseModel.Type);
            Assert.That(baseModel.Kind, Is.EqualTo(TypeBuilderKind.IPersistableModel));
            Assert.That(baseModel.ContextType, Is.EqualTo(s_modelExpectations[baseModel.Type.Name].Context));
        }

        private static void AssertAvailabilitySetDataBuilder(TypeBuilderSpec availabilitySetData)
        {
            Assert.That(availabilitySetData.Modifier, Is.EqualTo("internal"));
            Assert.That(availabilitySetData.PersistableModelProxy, Is.Null);
            AssertAvailabilitySetData(availabilitySetData.Type);
            Assert.That(availabilitySetData.Kind, Is.EqualTo(TypeBuilderKind.IPersistableModel));
            Assert.That(availabilitySetData.ContextType, Is.EqualTo(s_modelExpectations[availabilitySetData.Type.Name].Context));
        }

        private static void AssertTestProject1LocalBaseModelBuilder(TypeBuilderSpec localBaseModel)
        {
            Assert.That(localBaseModel.Modifier, Is.EqualTo("internal"));
            Assert.That(localBaseModel.PersistableModelProxy, Is.Not.Null);
            AssertLocalBaseModel(localBaseModel.Type, "TestProject1");
            Assert.That(localBaseModel.Kind, Is.EqualTo(TypeBuilderKind.IPersistableModel));
            Assert.That(localBaseModel.ContextType, Is.EqualTo(s_modelExpectations[localBaseModel.Type.Name].Context));
        }

        private static void AssertLocalBaseModelBuilder(TypeBuilderSpec localBaseModel)
        {
            Assert.That(localBaseModel.Modifier, Is.EqualTo("internal"));
            Assert.That(localBaseModel.PersistableModelProxy, Is.Not.Null);
            AssertLocalBaseModel(localBaseModel.Type);
            Assert.That(localBaseModel.Kind, Is.EqualTo(TypeBuilderKind.IPersistableModel));
            Assert.That(localBaseModel.ContextType, Is.EqualTo(s_modelExpectations[localBaseModel.Type.Name].Context));
        }

        internal static void AssertJsonModel(TypeRef jsonModel, string expectedNamespace = "TestProject")
        {
            Assert.That(jsonModel.Name, Is.EqualTo("JsonModel"));
            Assert.That(jsonModel.Namespace, Is.EqualTo(expectedNamespace));
            Assert.That(jsonModel.TypeCaseName, Is.EqualTo("JsonModel_"));
            Assert.That(jsonModel.CamelCaseName, Is.EqualTo("jsonModel_"));
            Assert.That(jsonModel.ArrayRank, Is.EqualTo(0));
            Assert.That(jsonModel.ItemType, Is.Null);
        }

        internal static void AssertLocalBaseModel(TypeRef localBaseModel, string expectedNamespace = "TestProject")
        {
            Assert.That(localBaseModel.Name, Is.EqualTo("LocalBaseModel"));
            Assert.That(localBaseModel.Namespace, Is.EqualTo(expectedNamespace));
            Assert.That(localBaseModel.TypeCaseName, Is.EqualTo("LocalBaseModel_"));
            Assert.That(localBaseModel.CamelCaseName, Is.EqualTo("localBaseModel_"));
            Assert.That(localBaseModel.ArrayRank, Is.EqualTo(0));
            Assert.That(localBaseModel.ItemType, Is.Null);
        }

        internal static void AssertUnknownLocalBaseModel(TypeRef unknownLocalBaseModel, string expectedNamespace = "TestProject")
        {
            Assert.That(unknownLocalBaseModel.Name, Is.EqualTo("UnknownLocalBaseModel"));
            Assert.That(unknownLocalBaseModel.Namespace, Is.EqualTo(expectedNamespace));
            Assert.That(unknownLocalBaseModel.TypeCaseName, Is.EqualTo("UnknownLocalBaseModel_"));
            Assert.That(unknownLocalBaseModel.CamelCaseName, Is.EqualTo("unknownLocalBaseModel_"));
            Assert.That(unknownLocalBaseModel.ArrayRank, Is.EqualTo(0));
            Assert.That(unknownLocalBaseModel.ItemType, Is.Null);
        }

        internal static void AssertBaseModel(TypeRef baseModel)
        {
            Assert.That(baseModel.Name, Is.EqualTo("BaseModel"));
            Assert.That(baseModel.Namespace, Is.EqualTo("System.ClientModel.Tests.Client.ModelReaderWriterTests.Models"));
            Assert.That(baseModel.TypeCaseName, Is.EqualTo("BaseModel_"));
            Assert.That(baseModel.CamelCaseName, Is.EqualTo("baseModel_"));
            Assert.That(baseModel.ArrayRank, Is.EqualTo(0));
            Assert.That(baseModel.ItemType, Is.Null);
        }

        private static void AssertAvailabilitySetData(TypeRef aset)
        {
            Assert.That(aset.Name, Is.EqualTo("AvailabilitySetData"));
            Assert.That(aset.Namespace, Is.EqualTo("System.ClientModel.Tests.Client.Models.ResourceManager.Compute"));
            Assert.That(aset.TypeCaseName, Is.EqualTo("AvailabilitySetData_"));
            Assert.That(aset.CamelCaseName, Is.EqualTo("availabilitySetData_"));
            Assert.That(aset.ArrayRank, Is.EqualTo(0));
            Assert.That(aset.ItemType, Is.Null);
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
