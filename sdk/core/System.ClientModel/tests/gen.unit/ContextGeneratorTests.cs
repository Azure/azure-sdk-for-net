// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.SourceGeneration.Tests.Unit.InvocationTests;
using System.ClientModel.Tests.ModelReaderWriterTests;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Microsoft.CodeAnalysis;
using NUnit.Framework;
using static System.ClientModel.SourceGeneration.Tests.Unit.InvocationTests.InvocationTestBase;

namespace System.ClientModel.SourceGeneration.Tests.Unit
{
    public class ContextGeneratorTests
    {
        [Test]
        public void NonAbstractWithProxyAndNoCtorShouldWork()
        {
            string source =
$$"""
using System;
using System.ClientModel.Primitives;

namespace TestProject
{
    [ModelReaderWriterBuildable(typeof(JsonModel))]
    [ModelReaderWriterBuildable(typeof(UnknownJsonModel))]
    public partial class LocalContext : ModelReaderWriterContext { }

    public class Caller
    {
        public void Call()
        {
            ModelReaderWriter.Read(BinaryData.Empty, typeof(JsonModel), ModelReaderWriterOptions.Json, LocalContext.Default);
        }
    }

    [PersistableModelProxy(typeof(UnknownJsonModel))]
    public class JsonModel : IJsonModel<JsonModel>
    {
        protected JsonModel() { }
        public JsonModel Create(ref System.Text.Json.Utf8JsonReader reader, ModelReaderWriterOptions options) => new UnknownJsonModel();
        public JsonModel Create(BinaryData data, ModelReaderWriterOptions options) => new UnknownJsonModel();
        public string GetFormatFromOptions(ModelReaderWriterOptions options) => "J";
        public void Write(System.Text.Json.Utf8JsonWriter writer, ModelReaderWriterOptions options) { }
        public BinaryData Write(ModelReaderWriterOptions options) => BinaryData.Empty;
    }

    internal class UnknownJsonModel : JsonModel {}
}
""";

            Compilation compilation = CompilationHelper.CreateCompilation(source);
            var result = CompilationHelper.RunSourceGenerator(compilation);

            Assert.IsNotNull(result.GenerationSpec);
            Assert.AreEqual("LocalContext", result.GenerationSpec!.Type.Name);
            Assert.AreEqual("TestProject", result.GenerationSpec.Type.Namespace);
            Assert.AreEqual(0, result.Diagnostics.Length);
            Assert.AreEqual("public", result.GenerationSpec!.Modifier);
            Assert.AreEqual(2, result.GenerationSpec.TypeBuilders.Count);
            Assert.AreEqual(0, result.GenerationSpec.ReferencedContexts.Count);

            var jsonModel = result.GenerationSpec.TypeBuilders[0];
            Assert.AreEqual("internal", jsonModel.Modifier);
            AssertJsonModel(jsonModel.Type);
            Assert.AreEqual(TypeBuilderKind.IPersistableModel, jsonModel.Kind);
            Assert.AreEqual(s_modelExpectations[jsonModel.Type.Name].Context, jsonModel.ContextType);
            Assert.IsNotNull(jsonModel.PersistableModelProxy);
            var unknownJsonModel = jsonModel.PersistableModelProxy;
            Assert.AreEqual("UnknownJsonModel", unknownJsonModel!.Name);
            Assert.AreEqual("TestProject", unknownJsonModel.Namespace);

            Assert.AreEqual("UnknownJsonModel", result.GenerationSpec.TypeBuilders[1].Type.Name);
        }

        [TestCase("private", true)]
        [TestCase("protected", true)]
        [TestCase("public", false)]
        [TestCase("internal", false)]
        [TestCase("private protected", true)]
        [TestCase("protected internal", false)]
        public void PersistableModelHasNoEmptyCtor(string modifier, bool expectedDiag)
        {
            string source =
$$"""
using System;
using System.ClientModel.Primitives;

namespace TestProject
{
    [ModelReaderWriterBuildable(typeof(PersistableModel))]
    public partial class LocalContext : ModelReaderWriterContext
    {
    }

    public class PersistableModel : IPersistableModel<PersistableModel>
    {
        {{modifier}} PersistableModel() { }

        public string GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

        public BinaryData Write(ModelReaderWriterOptions options) => BinaryData.Empty;

        PersistableModel IPersistableModel<PersistableModel>.Create(BinaryData data, ModelReaderWriterOptions options) => new PersistableModel();
    }
}
""";

            Compilation compilation = CompilationHelper.CreateCompilation(source);
            var result = CompilationHelper.RunSourceGenerator(compilation);

            Assert.IsNotNull(result.GenerationSpec);
            Assert.AreEqual("LocalContext", result.GenerationSpec!.Type.Name);
            Assert.AreEqual("TestProject", result.GenerationSpec.Type.Namespace);
            Assert.AreEqual("public", result.GenerationSpec!.Modifier);
            Assert.AreEqual(0, result.GenerationSpec.ReferencedContexts.Count);

            if (expectedDiag)
            {
                Assert.AreEqual(1, result.Diagnostics.Length);
                Assert.AreEqual(ModelReaderWriterContextGenerator.DiagnosticDescriptors.TypeMustHaveParameterlessConstructor.Id, result.Diagnostics[0].Id);

                Assert.AreEqual(0, result.GenerationSpec.TypeBuilders.Count);
            }
            else
            {
                Assert.AreEqual(0, result.Diagnostics.Length);

                Assert.AreEqual(1, result.GenerationSpec.TypeBuilders.Count);
                Assert.AreEqual("PersistableModel", result.GenerationSpec.TypeBuilders[0].Type.Name);
                Assert.AreEqual("internal", result.GenerationSpec.TypeBuilders[0].Modifier);
            }
        }

        [Test]
        public void TwoModelsSameNameDifferentNamespaces()
        {
            string source =
$$"""
using System;
using System.ClientModel.Primitives;
using System.Text.Json;

namespace TestProject
{
    [ModelReaderWriterBuildable(typeof(JsonModel))]
    [ModelReaderWriterBuildable(typeof(TestProject2.JsonModel))]
    public partial class LocalContext : ModelReaderWriterContext { }

    public class JsonModel : IJsonModel<JsonModel>
    {
        public JsonModel Create(ref System.Text.Json.Utf8JsonReader reader, ModelReaderWriterOptions options) => new JsonModel();
        public JsonModel Create(BinaryData data, ModelReaderWriterOptions options) => new JsonModel();
        public string GetFormatFromOptions(ModelReaderWriterOptions options) => "J";
        public void Write(System.Text.Json.Utf8JsonWriter writer, ModelReaderWriterOptions options) { }
        public BinaryData Write(ModelReaderWriterOptions options) => BinaryData.Empty;
    }
}

namespace TestProject2
{
    public class JsonModel : IJsonModel<JsonModel>
    {
        public JsonModel Create(ref System.Text.Json.Utf8JsonReader reader, ModelReaderWriterOptions options) => new JsonModel();
        public JsonModel Create(BinaryData data, ModelReaderWriterOptions options) => new JsonModel();
        public string GetFormatFromOptions(ModelReaderWriterOptions options) => "J";
        public void Write(System.Text.Json.Utf8JsonWriter writer, ModelReaderWriterOptions options) { }
        public BinaryData Write(ModelReaderWriterOptions options) => BinaryData.Empty;
    }
}
""";

            Compilation compilation = CompilationHelper.CreateCompilation(source);
            var result = CompilationHelper.RunSourceGenerator(compilation);

            Assert.IsNotNull(result.GenerationSpec);
            Assert.AreEqual("LocalContext", result.GenerationSpec!.Type.Name);
            Assert.AreEqual("TestProject", result.GenerationSpec.Type.Namespace);
            Assert.AreEqual(0, result.Diagnostics.Length);
            Assert.AreEqual("public", result.GenerationSpec!.Modifier);
            Assert.AreEqual(2, result.GenerationSpec.TypeBuilders.Count);
            Assert.AreEqual(0, result.GenerationSpec.ReferencedContexts.Count);

            var dict = result.GenerationSpec.TypeBuilders.ToDictionary(t => $"{t.Type.Namespace}.{t.Type.Name}", t => t);
            Assert.IsTrue(dict.ContainsKey("TestProject.JsonModel"));
            Assert.IsTrue(dict.ContainsKey("TestProject2.JsonModel"));
            var jsonModel = dict["TestProject.JsonModel"];
            InvocationTestBase.AssertJsonModel(jsonModel.Type);
            var jsonModel2 = dict["TestProject2.JsonModel"];
            InvocationTestBase.AssertJsonModel(jsonModel2.Type, "TestProject2");
        }

        [Test]
        public void AbstractWithNoAttributeIsSkipped()
        {
            string source =
$$"""
using System;
using System.ClientModel.Primitives;

namespace TestProject
{
    [ModelReaderWriterBuildable(typeof(JsonModel))]
    [ModelReaderWriterBuildable(typeof(UnknownJsonModel))]
    public partial class LocalContext : ModelReaderWriterContext { }

    public class Caller
    {
        public void Call()
        {
            ModelReaderWriter.Read(BinaryData.Empty, typeof(JsonModel), ModelReaderWriterOptions.Json, LocalContext.Default);
        }
    }

    public abstract class JsonModel : IJsonModel<JsonModel>
    {
        public JsonModel Create(ref System.Text.Json.Utf8JsonReader reader, ModelReaderWriterOptions options) => new UnknownJsonModel();
        public JsonModel Create(BinaryData data, ModelReaderWriterOptions options) => new UnknownJsonModel();
        public string GetFormatFromOptions(ModelReaderWriterOptions options) => "J";
        public void Write(System.Text.Json.Utf8JsonWriter writer, ModelReaderWriterOptions options) { }
        public BinaryData Write(ModelReaderWriterOptions options) => BinaryData.Empty;
    }

    internal class UnknownJsonModel : JsonModel {}
}
""";

            Compilation compilation = CompilationHelper.CreateCompilation(source);
            var result = CompilationHelper.RunSourceGenerator(compilation);

            Assert.IsNotNull(result.GenerationSpec);
            Assert.AreEqual("LocalContext", result.GenerationSpec!.Type.Name);
            Assert.AreEqual("TestProject", result.GenerationSpec.Type.Namespace);
            Assert.AreEqual(1, result.Diagnostics.Length);
            Assert.AreEqual(ModelReaderWriterContextGenerator.DiagnosticDescriptors.AbstractTypeWithoutProxy.Id, result.Diagnostics[0].Id);
            Assert.AreEqual("public", result.GenerationSpec!.Modifier);
            Assert.AreEqual(1, result.GenerationSpec.TypeBuilders.Count);
            Assert.AreEqual(0, result.GenerationSpec.ReferencedContexts.Count);
            Assert.AreEqual("UnknownJsonModel", result.GenerationSpec.TypeBuilders[0].Type.Name);
        }

        [Test]
        public void InvalidAssemblyName()
        {
            string source =
$$"""
using System;
using System.ClientModel.Primitives;

namespace _Type.Foo
{
    [ModelReaderWriterBuildable(typeof(JsonModel))]
    public partial class LocalContext : ModelReaderWriterContext { }

    public class Foo
    {
        public void Caller()
        {
            ModelReaderWriter.Read(BinaryData.Empty, typeof(JsonModel), ModelReaderWriterOptions.Json, LocalContext.Default);
        }
    }

    public class JsonModel : IJsonModel<JsonModel>
    {
        public JsonModel Create(ref System.Text.Json.Utf8JsonReader reader, ModelReaderWriterOptions options) => new JsonModel();
        public JsonModel Create(BinaryData data, ModelReaderWriterOptions options) => new JsonModel();
        public string GetFormatFromOptions(ModelReaderWriterOptions options) => "J";
        public void Write(System.Text.Json.Utf8JsonWriter writer, ModelReaderWriterOptions options) { }
        public BinaryData Write(ModelReaderWriterOptions options) => BinaryData.Empty;
    }
}
""";

            Compilation compilation = CompilationHelper.CreateCompilation(source, assemblyName: "Type.Foo");
            var result = CompilationHelper.RunSourceGenerator(compilation);

            Assert.IsNotNull(result.GenerationSpec);
            Assert.AreEqual("LocalContext", result.GenerationSpec!.Type.Name);
            Assert.AreEqual("_Type.Foo", result.GenerationSpec.Type.Namespace);
            Assert.AreEqual(0, result.Diagnostics.Length);
            Assert.AreEqual("public", result.GenerationSpec!.Modifier);
            Assert.AreEqual(1, result.GenerationSpec.TypeBuilders.Count);
            Assert.AreEqual(0, result.GenerationSpec.ReferencedContexts.Count);

            InvocationTestBase.AssertJsonModel(result.GenerationSpec.TypeBuilders[0].Type, "_Type.Foo");
        }

        [Test]
        public void ValidateRoslynVersion()
        {
            Assembly roslynAssembly = typeof(Compilation).Assembly;
            Version expectedVersion = new Version(4, 3, 0, 0);
            Version? actualVersion = roslynAssembly.GetName().Version;

            //This version is required for the source generator to work correctly.
            Assert.AreEqual(expectedVersion, actualVersion,
                $"Expected Roslyn version {expectedVersion}, but got {actualVersion}");
        }

        [Test]
        public void DepHasJsonModelButInternalContext()
        {
            string depSource =
$$"""
using System;
using System.ClientModel.Primitives;
using System.Text.Json;

namespace TestDependency
{
    [ModelReaderWriterBuildable(typeof(JsonModel))]
    internal partial class LocalContext : ModelReaderWriterContext { }

    public class JsonModel : IJsonModel<JsonModel>
    {
        public JsonModel Create(ref System.Text.Json.Utf8JsonReader reader, ModelReaderWriterOptions options) => new JsonModel();
        public JsonModel Create(BinaryData data, ModelReaderWriterOptions options) => new JsonModel();
        public string GetFormatFromOptions(ModelReaderWriterOptions options) => "J";
        public void Write(System.Text.Json.Utf8JsonWriter writer, ModelReaderWriterOptions options) { }
        public BinaryData Write(ModelReaderWriterOptions options) => BinaryData.Empty;
    }
}
""";

            Compilation depCompilation = CompilationHelper.CreateCompilation(depSource, assemblyName: "TestDependency");

            string source =
$$"""
using System;
using System.ClientModel.Primitives;
using TestDependency;

namespace TestProject
{
    [ModelReaderWriterBuildable(typeof(JsonModel))]
    public partial class MyLocalContext : ModelReaderWriterContext { }

    public class Caller
    {
        public void Call()
        {
            ModelReaderWriter.Read<JsonModel>(BinaryData.Empty, ModelReaderWriterOptions.Json, MyLocalContext.Default);
        }
    }
}
""";

            Compilation compilation = CompilationHelper.CreateCompilation(
                source,
                additionalReferences: [depCompilation.ToMetadataReference()],
                contextName: "MyLocalContext");

            var result = CompilationHelper.RunSourceGenerator(compilation);
            Assert.IsNotNull(result.GenerationSpec);
            Assert.AreEqual("MyLocalContext", result.GenerationSpec!.Type.Name);
            Assert.AreEqual("TestProject", result.GenerationSpec.Type.Namespace);
            Assert.AreEqual(0, result.Diagnostics.Length);
            Assert.AreEqual("public", result.GenerationSpec!.Modifier);
            Assert.AreEqual(0, result.GenerationSpec.TypeBuilders.Count);
            Assert.AreEqual(0, result.GenerationSpec.ReferencedContexts.Count);
        }

        [Test]
        public void DepHasJsonModelButNoContext()
        {
            string depSource =
$$"""
using System;
using System.ClientModel.Primitives;
using System.Text.Json;

namespace TestDependency
{
    public class JsonModel : IJsonModel<JsonModel>
    {
        public JsonModel Create(ref System.Text.Json.Utf8JsonReader reader, ModelReaderWriterOptions options) => new JsonModel();
        public JsonModel Create(BinaryData data, ModelReaderWriterOptions options) => new JsonModel();
        public string GetFormatFromOptions(ModelReaderWriterOptions options) => "J";
        public void Write(System.Text.Json.Utf8JsonWriter writer, ModelReaderWriterOptions options) { }
        public BinaryData Write(ModelReaderWriterOptions options) => BinaryData.Empty;
    }
}
""";

            Compilation depCompilation = CompilationHelper.CreateCompilation(depSource, assemblyName: "TestDependency");

            string source =
$$"""
using System;
using System.ClientModel.Primitives;
using TestDependency;

namespace TestProject
{
    [ModelReaderWriterBuildable(typeof(JsonModel))]
    public partial class LocalContext : ModelReaderWriterContext { }

    public class Caller
    {
        public void Call()
        {
            ModelReaderWriter.Read<JsonModel>(BinaryData.Empty, ModelReaderWriterOptions.Json, LocalContext.Default);
        }
    }
}
""";

            Compilation compilation = CompilationHelper.CreateCompilation(
                source,
                additionalReferences: [depCompilation.ToMetadataReference()]);

            var result = CompilationHelper.RunSourceGenerator(compilation);
            Assert.IsNotNull(result.GenerationSpec);
            Assert.AreEqual("LocalContext", result.GenerationSpec!.Type.Name);
            Assert.AreEqual("TestProject", result.GenerationSpec.Type.Namespace);
            Assert.AreEqual(0, result.Diagnostics.Length);
            Assert.AreEqual("public", result.GenerationSpec!.Modifier);
            Assert.AreEqual(0, result.GenerationSpec.TypeBuilders.Count);
            Assert.AreEqual(0, result.GenerationSpec.ReferencedContexts.Count);
        }

        [Test]
        public void UseMrwWithNonPersistable()
        {
            string source =
$$"""
using System;
using System.ClientModel.Primitives;

namespace TestProject
{
    [ModelReaderWriterBuildable(typeof(Foo))]
    public partial class LocalContext : ModelReaderWriterContext { }

    public class Foo
    {
        public void Caller()
        {
            ModelReaderWriter.Read(BinaryData.Empty, typeof(Foo));
        }
    }
}
""";

            Compilation compilation = CompilationHelper.CreateCompilation(source);
            var result = CompilationHelper.RunSourceGenerator(compilation);

            Assert.IsNotNull(result.GenerationSpec);
            Assert.AreEqual("LocalContext", result.GenerationSpec!.Type.Name);
            Assert.AreEqual("TestProject", result.GenerationSpec.Type.Namespace);
            Assert.AreEqual(0, result.Diagnostics.Length);
            Assert.AreEqual("public", result.GenerationSpec!.Modifier);
            Assert.AreEqual(0, result.GenerationSpec.TypeBuilders.Count);
            Assert.AreEqual(0, result.GenerationSpec.ReferencedContexts.Count);
        }

        [Test]
        public void NoBuilders()
        {
            string source =
$$"""
using System.ClientModel.Primitives;

namespace TestProject
{
    public partial class LocalContext : ModelReaderWriterContext { }

    public class Foo { }
}
""";

            Compilation compilation = CompilationHelper.CreateCompilation(source);
            var result = CompilationHelper.RunSourceGenerator(compilation);

            Assert.IsNull(result.GenerationSpec);
        }

        [Test]
        public void NoBuildersWithJsonModel()
        {
            string source =
$$"""
using System.ClientModel.Primitives;
using System;
using System.Text.Json;

namespace TestProject
{
    public partial class LocalContext : ModelReaderWriterContext { }

    public class JsonModel : IJsonModel<JsonModel>
    {
        public JsonModel Create(ref System.Text.Json.Utf8JsonReader reader, ModelReaderWriterOptions options) => new JsonModel();
        public JsonModel Create(BinaryData data, ModelReaderWriterOptions options) => new JsonModel();
        public string GetFormatFromOptions(ModelReaderWriterOptions options) => "J";
        public void Write(System.Text.Json.Utf8JsonWriter writer, ModelReaderWriterOptions options) { }
        public BinaryData Write(ModelReaderWriterOptions options) => BinaryData.Empty;
    }
}
""";

            Compilation compilation = CompilationHelper.CreateCompilation(source);
            var result = CompilationHelper.RunSourceGenerator(compilation);

            Assert.IsNull(result.GenerationSpec);
        }

        [TestCase("public")]
        [TestCase("internal")]
        public void SingleContext(string modifier)
        {
            string source =
$$"""
using System.ClientModel.Primitives;

namespace TestProject
{
    [ModelReaderWriterBuildable(typeof(int))]
    {{modifier}} partial class LocalContext : ModelReaderWriterContext { }
}
""";

            Compilation compilation = CompilationHelper.CreateCompilation(source);
            var result = CompilationHelper.RunSourceGenerator(compilation);

            Assert.IsNotNull(result.GenerationSpec);
            Assert.AreEqual("LocalContext", result.GenerationSpec!.Type.Name);
            Assert.AreEqual("TestProject", result.GenerationSpec.Type.Namespace);
            Assert.AreEqual(0, result.Diagnostics.Length);
            Assert.AreEqual(modifier, result.GenerationSpec!.Modifier);
            Assert.AreEqual(0, result.GenerationSpec.TypeBuilders.Count);
            Assert.AreEqual(0, result.GenerationSpec.ReferencedContexts.Count);
        }

        [TestCase("public")]
        [TestCase("internal")]
        public void SingleContextWithReference(string modifier)
        {
            string source =
$$"""
using System.ClientModel.Primitives;
using System;
using System.ClientModel.Tests.Client.Models.ResourceManager.Compute;

namespace TestProject
{
    [ModelReaderWriterBuildable(typeof(AvailabilitySetData))]
    {{modifier}} partial class LocalContext : ModelReaderWriterContext { }

    public class Caller
    {
        public void Call()
        {
            ModelReaderWriter.Read(BinaryData.Empty, typeof(AvailabilitySetData), ModelReaderWriterOptions.Json, LocalContext.Default);
        }
    }
}
""";

            Compilation compilation = CompilationHelper.CreateCompilation(
                source,
                additionalReferences:
                [
                    MetadataReference.CreateFromFile(typeof(TestClientModelReaderWriterContext).Assembly.Location)
                ]);
            var result = CompilationHelper.RunSourceGenerator(compilation, out var newCompilation);

            Assert.IsNotNull(result.GenerationSpec);
            Assert.AreEqual("LocalContext", result.GenerationSpec!.Type.Name);
            Assert.AreEqual("TestProject", result.GenerationSpec.Type.Namespace);
            Assert.AreEqual(0, result.Diagnostics.Length);
            Assert.AreEqual(modifier, result.GenerationSpec!.Modifier);
            Assert.AreEqual(1, result.GenerationSpec.TypeBuilders.Count);
            Assert.AreEqual("TestClientModelReaderWriterContext", result.GenerationSpec.TypeBuilders[0].ContextType.Name);
            Assert.AreEqual("AvailabilitySetData", result.GenerationSpec.TypeBuilders[0].Type.Name);
            Assert.AreEqual("System.ClientModel.Tests.Client.Models.ResourceManager.Compute", result.GenerationSpec.TypeBuilders[0].Type.Namespace);
            Assert.AreEqual(1, result.GenerationSpec.ReferencedContexts.Count);
            Assert.AreEqual("TestClientModelReaderWriterContext", result.GenerationSpec.ReferencedContexts[0].Name);
            Assert.AreEqual("System.ClientModel.Tests.ModelReaderWriterTests", result.GenerationSpec.ReferencedContexts[0].Namespace);

            //we shouldn't make a builder just add the reference to forward to TestClientModelReaderWriterContext
            Assert.IsNull(newCompilation.GetTypeByMetadataName($"{result.GenerationSpec.TypeBuilders[0].Type.TypeCaseName}Builder"));
        }

        [Test]
        public void MultipleContextsShouldFail()
        {
            string source =
$$"""
using System.ClientModel.Primitives;
using System.Text.Json;
using System;

namespace TestProject
{
    [ModelReaderWriterBuildable(typeof(JsonModel))]
    public partial class LocalContext1 : ModelReaderWriterContext { }

    [ModelReaderWriterBuildable(typeof(JsonModel))]
    public partial class LocalContext2 : ModelReaderWriterContext { }

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
}
""";

            Compilation compilation = CompilationHelper.CreateCompilation(source);
            var result = CompilationHelper.RunSourceGenerator(compilation);

            Assert.IsNull(result.GenerationSpec);
            Assert.AreEqual(1, result.Diagnostics.Length);
            Assert.AreEqual(ModelReaderWriterContextGenerator.DiagnosticDescriptors.MultipleContextsNotSupported.Id, result.Diagnostics[0].Id);
        }

        [Test]
        public void NestedContextShouldHaveNoResults()
        {
            string source =
$$"""
using System.ClientModel.Primitives;
using System.Text.Json;
using System;

namespace TestProject
{
    public class Foo
    {
        [ModelReaderWriterBuildable(typeof(JsonModel))]
        public partial class LocalContext : ModelReaderWriterContext { }
    }

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
}
""";

            Compilation compilation = CompilationHelper.CreateCompilation(source);
            var result = CompilationHelper.RunSourceGenerator(compilation);

            Assert.IsNull(result.GenerationSpec);
            Assert.AreEqual(0, result.Diagnostics.Length);
        }

        [Test]
        public void NoPartialShouldFail()
        {
            string source =
$$"""
using System.ClientModel.Primitives;

namespace TestProject
{
    [ModelReaderWriterBuildable(typeof(int))]
    public class LocalContext : ModelReaderWriterContext { }
}
""";

            Compilation compilation = CompilationHelper.CreateCompilation(source);
            var result = CompilationHelper.RunSourceGenerator(compilation);

            Assert.IsNull(result.GenerationSpec);
            Assert.AreEqual(1, result.Diagnostics.Length);
            Assert.AreEqual(ModelReaderWriterContextGenerator.DiagnosticDescriptors.ContextMustBePartial.Id, result.Diagnostics[0].Id);
        }

        [Test]
        [Ignore("Temporarily disabled for perf")]
        public void AttributeOnWrongClassTypeShouldFail()
        {
            string source =
$$"""
using System.ClientModel.Primitives;

namespace TestProject
{
    public partial class LocalContext : ModelReaderWriterContext { }

    [ModelReaderWriterBuildable(typeof(int))]
    public class WrongClass { }
}
""";

            Compilation compilation = CompilationHelper.CreateCompilation(source);
            var result = CompilationHelper.RunSourceGenerator(compilation);

            Assert.IsNotNull(result.GenerationSpec);
            Assert.AreEqual("LocalContext", result.GenerationSpec!.Type.Name);
            Assert.AreEqual("TestProject", result.GenerationSpec.Type.Namespace);
            Assert.AreEqual(0, result.GenerationSpec.ReferencedContexts.Count);
            Assert.AreEqual(0, result.GenerationSpec.TypeBuilders.Count);
            Assert.AreEqual(1, result.Diagnostics.Length);
            Assert.AreEqual(ModelReaderWriterContextGenerator.DiagnosticDescriptors.BuildableAttributeRequiresContext.Id, result.Diagnostics[0].Id);
        }

        [Test]
        [Ignore("Temporarily disabled for perf")]
        public void AttributeOnWrongClassWithOneOnCorrectClass()
        {
            string source =
$$"""
using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text.Json;

namespace TestProject
{
    [ModelReaderWriterBuildable(typeof(int))]
    public class BadContext { }

    [ModelReaderWriterBuildable(typeof(List<JsonModel>))]
    public partial class LocalContext : ModelReaderWriterContext { }

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
}
""";

            Compilation compilation = CompilationHelper.CreateCompilation(
                source,
                additionalReferences: [MetadataReference.CreateFromFile(typeof(List<>).Assembly.Location)]);
            var result = CompilationHelper.RunSourceGenerator(compilation);

            Assert.IsNotNull(result.GenerationSpec);
            Assert.AreEqual("LocalContext", result.GenerationSpec!.Type.Name);
            Assert.AreEqual("TestProject", result.GenerationSpec.Type.Namespace);
            Assert.AreEqual(0, result.GenerationSpec.ReferencedContexts.Count);
            Assert.AreEqual(2, result.GenerationSpec.TypeBuilders.Count);

            var dict = result.GenerationSpec.TypeBuilders.ToDictionary(t => $"{t.Type.GetInnerItemType().Namespace}.{t.Type.Name}", t => t);
            ListTests.AssertList(s_modelExpectations[JsonModel], false, dict);

            Assert.IsTrue(dict.TryGetValue($"TestProject.{JsonModel}", out var item));
            AssertJsonModel(item!.Type);

            Assert.AreEqual(1, result.Diagnostics.Length);
            Assert.AreEqual(ModelReaderWriterContextGenerator.DiagnosticDescriptors.BuildableAttributeRequiresContext.Id, result.Diagnostics[0].Id);
        }

        [Test]
        public void DepHasJsonModelAndContext()
        {
            string depSource =
$$"""
using System;
using System.ClientModel.Primitives;
using System.Text.Json;

namespace TestDependency
{
    [ModelReaderWriterBuildable(typeof(JsonModel))]
    public partial class LocalContext : ModelReaderWriterContext { }

    public class JsonModel : IJsonModel<JsonModel>
    {
        JsonModel IJsonModel<JsonModel>.Create(ref System.Text.Json.Utf8JsonReader reader, ModelReaderWriterOptions options) => new JsonModel();
        JsonModel IPersistableModel<JsonModel>.Create(BinaryData data, ModelReaderWriterOptions options) => new JsonModel();
        string IPersistableModel<JsonModel>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";
        void IJsonModel<JsonModel>.Write(System.Text.Json.Utf8JsonWriter writer, ModelReaderWriterOptions options) { }
        BinaryData IPersistableModel<JsonModel>.Write(ModelReaderWriterOptions options) => BinaryData.Empty;
    }
}
""";

            Compilation depCompilation = CompilationHelper.CreateCompilation(depSource, assemblyName: "TestDependency");
            var depResult = CompilationHelper.RunSourceGenerator(depCompilation, out var newDepCompilation);

            Assert.IsNotNull(depResult.GenerationSpec);
            Assert.AreEqual("LocalContext", depResult.GenerationSpec!.Type.Name);
            Assert.AreEqual("TestDependency", depResult.GenerationSpec.Type.Namespace);
            Assert.AreEqual(0, depResult.Diagnostics.Length);
            Assert.AreEqual("public", depResult.GenerationSpec!.Modifier);
            Assert.AreEqual(1, depResult.GenerationSpec.TypeBuilders.Count);

            string source =
$$"""
using System;
using System.ClientModel.Primitives;
using TestDependency;

namespace TestProject
{
    [ModelReaderWriterBuildable(typeof(JsonModel))]
    public partial class MyLocalContext : ModelReaderWriterContext { }

    public class Caller
    {
        public void Call()
        {
            ModelReaderWriter.Read<JsonModel>(BinaryData.Empty, ModelReaderWriterOptions.Json, MyLocalContext.Default);
        }
    }
}
""";

            Compilation compilation = CompilationHelper.CreateCompilation(
                source,
                additionalReferences: [newDepCompilation.ToMetadataReference()],
                contextName: "MyLocalContext");

            var result = CompilationHelper.RunSourceGenerator(compilation, out var newCompilation);

            Assert.IsNotNull(result.GenerationSpec);
            Assert.AreEqual("MyLocalContext", result.GenerationSpec!.Type.Name);
            Assert.AreEqual("TestProject", result.GenerationSpec.Type.Namespace);
            Assert.AreEqual(0, result.Diagnostics.Length);
            Assert.AreEqual("public", result.GenerationSpec!.Modifier);
            Assert.AreEqual(1, result.GenerationSpec.TypeBuilders.Count);
            Assert.AreEqual(1, result.GenerationSpec.ReferencedContexts.Count);

            var myLocalContext = newCompilation.GetTypeByMetadataName("TestProject.MyLocalContext");
            Assert.IsNotNull(myLocalContext, "MyLocalContext should not be null.");

            var referenceContextFiled = myLocalContext!.GetMembers("s_referenceContexts")
                .OfType<IFieldSymbol>()
                .FirstOrDefault(f => f.IsStatic);
            Assert.IsNotNull(referenceContextFiled, "s_referenceContexts field should not be null.");

            //verify it has TestDependency.LocalContext.Default in its initializer somewhere
            var foundInitializer = false;
            foreach (var syntaxReference in referenceContextFiled!.DeclaringSyntaxReferences)
            {
                var syntax = syntaxReference.GetSyntax();
                if (syntax.ToString().Contains("TestDependency.LocalContext.Default"))
                {
                    foundInitializer = true;
                    break;
                }
            }
            Assert.IsTrue(foundInitializer, "s_referenceContexts should be initialized with TestDependency.LocalContext.Default");
        }

        [TestCase(true)]
        [TestCase(false)]
        public void BuilderForObsoletePersistableHasSuppression(bool isError)
        {
            string source =
$$"""
using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text.Json;

namespace TestProject
{
#pragma warning disable CS0618 // Type or member is obsolete
    [ModelReaderWriterBuildable(typeof(JsonModel))]
#pragma warning restore CS0618 // Type or member is obsolete
    public partial class LocalContext : ModelReaderWriterContext { }

    [Obsolete("This is obsolete", {{isError.ToString().ToCamelCase()}})]
    public class JsonModel : IJsonModel<JsonModel>
    {
        JsonModel IJsonModel<JsonModel>.Create(ref System.Text.Json.Utf8JsonReader reader, ModelReaderWriterOptions options) => new JsonModel();
        JsonModel IPersistableModel<JsonModel>.Create(BinaryData data, ModelReaderWriterOptions options) => new JsonModel();
        string IPersistableModel<JsonModel>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";
        void IJsonModel<JsonModel>.Write(System.Text.Json.Utf8JsonWriter writer, ModelReaderWriterOptions options) { }
        BinaryData IPersistableModel<JsonModel>.Write(ModelReaderWriterOptions options) => BinaryData.Empty;
    }
}
""";
            HashSet<string>? additionalSuppress = isError ? ["CS0619"] : null;
            Compilation compilation = CompilationHelper.CreateCompilation(source, additionalSuppress: additionalSuppress);
            var result = CompilationHelper.RunSourceGenerator(compilation, out var newCompilation, additionalSuppress: additionalSuppress);

            Assert.IsNotNull(result.GenerationSpec);
            Assert.AreEqual("LocalContext", result.GenerationSpec!.Type.Name);
            Assert.AreEqual("TestProject", result.GenerationSpec.Type.Namespace);
            Assert.AreEqual(0, result.Diagnostics.Length);
            Assert.AreEqual("public", result.GenerationSpec!.Modifier);
            Assert.AreEqual(isError ? 0 : 1, result.GenerationSpec.TypeBuilders.Count);
            Assert.AreEqual(0, result.GenerationSpec.ReferencedContexts.Count);

            if (!isError)
            {
                Assert.AreEqual("JsonModel", result.GenerationSpec.TypeBuilders[0].Type.Name);
                Assert.AreEqual("internal", result.GenerationSpec.TypeBuilders[0].Modifier);
                Assert.AreEqual(ObsoleteLevel.Warning, result.GenerationSpec.TypeBuilders[0].Type.ObsoleteLevel);
            }
        }

        [TestCase(true, "JsonModel[]")]
        [TestCase(false, "JsonModel[]")]
        [TestCase(true, "List<JsonModel>")]
        [TestCase(false, "List<JsonModel>")]
        [TestCase(true, "Dictionary<string, JsonModel>")]
        [TestCase(false, "Dictionary<string, JsonModel>")]
        [TestCase(true, "ReadOnlyMemory<JsonModel>")]
        [TestCase(false, "ReadOnlyMemory<JsonModel>")]
        [TestCase(true, "JsonModel[][]")]
        [TestCase(false, "JsonModel[][]")]
        [TestCase(true, "JsonModel[,]")]
        [TestCase(false, "JsonModel[,]")]
        public void BuilderForObsoleteCollectionHasSuppression(bool isError, string collectionType)
        {
            string source =
$$"""
using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text.Json;

namespace TestProject
{
#pragma warning disable CS0618 // Type or member is obsolete
    [ModelReaderWriterBuildable(typeof({{collectionType}}))]
#pragma warning restore CS0618 // Type or member is obsolete
    public partial class LocalContext : ModelReaderWriterContext { }

    [Obsolete("This is obsolete", {{isError.ToString().ToCamelCase()}})]
    public class JsonModel : IJsonModel<JsonModel>
    {
        JsonModel IJsonModel<JsonModel>.Create(ref System.Text.Json.Utf8JsonReader reader, ModelReaderWriterOptions options) => new JsonModel();
        JsonModel IPersistableModel<JsonModel>.Create(BinaryData data, ModelReaderWriterOptions options) => new JsonModel();
        string IPersistableModel<JsonModel>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";
        void IJsonModel<JsonModel>.Write(System.Text.Json.Utf8JsonWriter writer, ModelReaderWriterOptions options) { }
        BinaryData IPersistableModel<JsonModel>.Write(ModelReaderWriterOptions options) => BinaryData.Empty;
    }

    public class Caller
    {
        public void Call()
        {
#pragma warning disable CS0618 // Type or member is obsolete
            ModelReaderWriter.Read<{{collectionType}}>(BinaryData.Empty, ModelReaderWriterOptions.Json, LocalContext.Default);
#pragma warning restore CS0618 // Type or member is obsolete
        }
    }
}
""";

            Compilation compilation = CompilationHelper.CreateCompilation(
                source,
                additionalSuppress: isError ? ["CS0619"] : null);

            var result = CompilationHelper.RunSourceGenerator(
                compilation,
                out var newCompilation,
                additionalSuppress: isError ? ["CS0619"] : null);

            Assert.IsNotNull(result.GenerationSpec);
            Assert.AreEqual("LocalContext", result.GenerationSpec!.Type.Name);
            Assert.AreEqual("TestProject", result.GenerationSpec.Type.Namespace);
            Assert.AreEqual(0, result.Diagnostics.Length);
            Assert.AreEqual("public", result.GenerationSpec!.Modifier);
            Assert.AreEqual(isError ? 0 : collectionType == "JsonModel[][]" ? 3 : 2, result.GenerationSpec.TypeBuilders.Count);
            Assert.AreEqual(0, result.GenerationSpec.ReferencedContexts.Count);

            if (!isError)
            {
                var dict = result.GenerationSpec.TypeBuilders.ToDictionary(t => t.Type.Name, t => t);

                Assert.IsTrue(dict.TryGetValue("JsonModel", out var jsonModelBuilder));
                Assert.AreEqual("JsonModel", jsonModelBuilder!.Type.Name);
                Assert.AreEqual("TestProject", jsonModelBuilder.Type.Namespace);
                Assert.AreEqual("internal", jsonModelBuilder.Modifier);
                Assert.AreEqual(ObsoleteLevel.Warning, jsonModelBuilder.Type.ObsoleteLevel);

                Assert.IsTrue(dict.TryGetValue(collectionType, out var collectionBuilder));
                Assert.AreEqual(collectionType, collectionBuilder!.Type.Name);
                if (collectionType == "JsonModel[]" || collectionType == "JsonModel[,]" || collectionType == "JsonModel[][]")
                {
                    Assert.AreEqual("TestProject", collectionBuilder.Type.Namespace);
                }
                else if (collectionType == "ReadOnlyMemory<JsonModel>")
                {
                    Assert.AreEqual("System", collectionBuilder.Type.Namespace);
                }
                else
                {
                    Assert.AreEqual("System.Collections.Generic", collectionBuilder.Type.Namespace);
                }
                Assert.AreEqual("internal", collectionBuilder.Modifier);
                Assert.AreEqual(ObsoleteLevel.Warning, collectionBuilder.Type.ObsoleteLevel);
                if (collectionType == "JsonModel[][]")
                {
                    Assert.AreEqual("JsonModel[]", collectionBuilder.Type.ItemType!.Name);
                    Assert.AreEqual("TestProject", collectionBuilder.Type.ItemType!.Namespace);

                    Assert.IsTrue(dict.TryGetValue("JsonModel[]", out var jsonModelArrayBuilder));
                    Assert.AreEqual("JsonModel[]", jsonModelArrayBuilder!.Type.Name);
                    Assert.AreEqual("TestProject", jsonModelArrayBuilder.Type.Namespace);
                    Assert.AreEqual("internal", jsonModelArrayBuilder.Modifier);
                    Assert.AreEqual(ObsoleteLevel.Warning, jsonModelArrayBuilder.Type.ObsoleteLevel);

                    Assert.AreEqual("JsonModel", jsonModelArrayBuilder.Type.ItemType!.Name);
                    Assert.AreEqual("TestProject", jsonModelArrayBuilder.Type.ItemType!.Namespace);
                    Assert.AreEqual(ObsoleteLevel.Warning, jsonModelArrayBuilder.Type.ItemType!.ObsoleteLevel);
                }
                else
                {
                    Assert.AreEqual("JsonModel", collectionBuilder.Type.ItemType!.Name);
                    Assert.AreEqual("TestProject", collectionBuilder.Type.ItemType!.Namespace);
                    Assert.AreEqual(ObsoleteLevel.Warning, collectionBuilder.Type.ItemType!.ObsoleteLevel);
                }
            }
        }

        [Test]
        public void ClassesWithOnlyCasingDifference()
        {
            string source =
$$"""
using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text.Json;

namespace TestProject
{
    [ModelReaderWriterBuildable(typeof(JsonModel))]
    [ModelReaderWriterBuildable(typeof(Jsonmodel))]
    [ModelReaderWriterBuildable(typeof(JsonmodeL))]
    public partial class LocalContext : ModelReaderWriterContext { }

    public class JsonModel : IJsonModel<JsonModel>
    {
        JsonModel IJsonModel<JsonModel>.Create(ref System.Text.Json.Utf8JsonReader reader, ModelReaderWriterOptions options) => new JsonModel();
        JsonModel IPersistableModel<JsonModel>.Create(BinaryData data, ModelReaderWriterOptions options) => new JsonModel();
        string IPersistableModel<JsonModel>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";
        void IJsonModel<JsonModel>.Write(System.Text.Json.Utf8JsonWriter writer, ModelReaderWriterOptions options) { }
        BinaryData IPersistableModel<JsonModel>.Write(ModelReaderWriterOptions options) => BinaryData.Empty;
    }

    public class Jsonmodel : IJsonModel<Jsonmodel>
    {
        Jsonmodel IJsonModel<Jsonmodel>.Create(ref System.Text.Json.Utf8JsonReader reader, ModelReaderWriterOptions options) => new Jsonmodel();
        Jsonmodel IPersistableModel<Jsonmodel>.Create(BinaryData data, ModelReaderWriterOptions options) => new Jsonmodel();
        string IPersistableModel<Jsonmodel>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";
        void IJsonModel<Jsonmodel>.Write(System.Text.Json.Utf8JsonWriter writer, ModelReaderWriterOptions options) { }
        BinaryData IPersistableModel<Jsonmodel>.Write(ModelReaderWriterOptions options) => BinaryData.Empty;
    }

    public class JsonmodeL : IJsonModel<JsonmodeL>
    {
        JsonmodeL IJsonModel<JsonmodeL>.Create(ref System.Text.Json.Utf8JsonReader reader, ModelReaderWriterOptions options) => new JsonmodeL();
        JsonmodeL IPersistableModel<JsonmodeL>.Create(BinaryData data, ModelReaderWriterOptions options) => new JsonmodeL();
        string IPersistableModel<JsonmodeL>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";
        void IJsonModel<JsonmodeL>.Write(System.Text.Json.Utf8JsonWriter writer, ModelReaderWriterOptions options) { }
        BinaryData IPersistableModel<JsonmodeL>.Write(ModelReaderWriterOptions options) => BinaryData.Empty;
    }
}
""";

            Compilation compilation = CompilationHelper.CreateCompilation(source);

            var result = CompilationHelper.RunSourceGenerator(compilation, out var newCompilation, out var generatedSources);

            Assert.IsNotNull(result.GenerationSpec);
            Assert.AreEqual("LocalContext", result.GenerationSpec!.Type.Name);
            Assert.AreEqual("TestProject", result.GenerationSpec.Type.Namespace);
            Assert.AreEqual(0, result.Diagnostics.Length);
            Assert.AreEqual("public", result.GenerationSpec!.Modifier);
            Assert.AreEqual(3, result.GenerationSpec.TypeBuilders.Count);
            Assert.AreEqual(0, result.GenerationSpec.ReferencedContexts.Count);
            Assert.AreEqual("JsonModel", result.GenerationSpec.TypeBuilders[0].Type.Name);
            Assert.AreEqual("TestProject", result.GenerationSpec.TypeBuilders[0].Type.Namespace);
            Assert.AreEqual("Jsonmodel", result.GenerationSpec.TypeBuilders[1].Type.Name);
            Assert.AreEqual("TestProject", result.GenerationSpec.TypeBuilders[1].Type.Namespace);
            Assert.AreEqual("JsonmodeL", result.GenerationSpec.TypeBuilders[2].Type.Name);
            Assert.AreEqual("TestProject", result.GenerationSpec.TypeBuilders[2].Type.Namespace);

            Assert.AreEqual("TestProject_JsonModel_Builder.g.cs", generatedSources[1].HintName);
            Assert.AreEqual("TestProject_Jsonmodel_Builder_1.g.cs", generatedSources[2].HintName);
            Assert.AreEqual("TestProject_JsonmodeL_Builder_2.g.cs", generatedSources[3].HintName);
        }

        [Test]
        public void ClassWithProblematicNameInCompilation()
        {
            string source =
$$"""
using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text.Json;

namespace TestProject
{
    [ModelReaderWriterBuildable(typeof(JsonModel))]
    public partial class LocalContext : ModelReaderWriterContext { }

    public class JsonModel : IJsonModel<JsonModel>
    {
        JsonModel IJsonModel<JsonModel>.Create(ref System.Text.Json.Utf8JsonReader reader, ModelReaderWriterOptions options) => new JsonModel();
        JsonModel IPersistableModel<JsonModel>.Create(BinaryData data, ModelReaderWriterOptions options) => new JsonModel();
        string IPersistableModel<JsonModel>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";
        void IJsonModel<JsonModel>.Write(System.Text.Json.Utf8JsonWriter writer, ModelReaderWriterOptions options) { }
        BinaryData IPersistableModel<JsonModel>.Write(ModelReaderWriterOptions options) => BinaryData.Empty;
    }

    public readonly struct Type {}
}
""";

            Compilation compilation = CompilationHelper.CreateCompilation(source);

            var result = CompilationHelper.RunSourceGenerator(compilation, out var newCompilation);

            Assert.IsNotNull(result.GenerationSpec);
            Assert.AreEqual("LocalContext", result.GenerationSpec!.Type.Name);
            Assert.AreEqual("TestProject", result.GenerationSpec.Type.Namespace);
            Assert.AreEqual(0, result.Diagnostics.Length);
            Assert.AreEqual("public", result.GenerationSpec!.Modifier);
            Assert.AreEqual(1, result.GenerationSpec.TypeBuilders.Count);
            Assert.AreEqual(0, result.GenerationSpec.ReferencedContexts.Count);
            Assert.AreEqual("JsonModel", result.GenerationSpec.TypeBuilders[0].Type.Name);
            Assert.AreEqual("TestProject", result.GenerationSpec.TypeBuilders[0].Type.Namespace);
        }

        [Test]
        public void TwoPartialClassesSeparateFilesShouldPass()
        {
            // Each class/partial declaration is placed in its own "file" (syntax tree) to
            // simulate a multi-file project layout. Assertions mirror TwoPartialClassesShouldPass.
            const string localContextPart1 =
@"using System;
using System.ClientModel.Primitives;
using System.Text.Json;

namespace TestProject
{
    [ModelReaderWriterBuildable(typeof(JsonModel))]
    public partial class LocalContext : ModelReaderWriterContext { }
}";
            const string jsonModelSource =
@"using System;
using System.ClientModel.Primitives;
using System.Text.Json;

namespace TestProject
{
    public class JsonModel : IJsonModel<JsonModel>
    {
        public JsonModel Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => new JsonModel();
        public JsonModel Create(BinaryData data, ModelReaderWriterOptions options) => new JsonModel();
        public string GetFormatFromOptions(ModelReaderWriterOptions options) => ""J"";
        public void Write(Utf8JsonWriter writer, ModelReaderWriterOptions options) { }
        public BinaryData Write(ModelReaderWriterOptions options) => BinaryData.Empty;
    }
}";
            const string localContextPart2 =
@"using System;
using System.ClientModel.Primitives;
using System.Text.Json;

namespace TestProject
{
    [ModelReaderWriterBuildable(typeof(JsonModel2))]
    public partial class LocalContext : ModelReaderWriterContext { }
}";
            const string jsonModel2Source =
@"using System;
using System.ClientModel.Primitives;
using System.Text.Json;

namespace TestProject
{
    public class JsonModel2 : IJsonModel<JsonModel2>
    {
        public JsonModel2 Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => new JsonModel2();
        public JsonModel2 Create(BinaryData data, ModelReaderWriterOptions options) => new JsonModel2();
        public string GetFormatFromOptions(ModelReaderWriterOptions options) => ""J"";
        public void Write(Utf8JsonWriter writer, ModelReaderWriterOptions options) { }
        public BinaryData Write(ModelReaderWriterOptions options) => BinaryData.Empty;
    }
}";

            Compilation compilation = CompilationHelper.CreateCompilation([localContextPart1, localContextPart2, jsonModelSource, jsonModel2Source]);

            var result = CompilationHelper.RunSourceGenerator(compilation, out var newCompilation);

            Assert.IsNotNull(result.GenerationSpec);
            Assert.AreEqual("LocalContext", result.GenerationSpec!.Type.Name);
            Assert.AreEqual("TestProject", result.GenerationSpec.Type.Namespace);
            Assert.AreEqual(0, result.Diagnostics.Length);
            Assert.AreEqual("public", result.GenerationSpec!.Modifier);
            Assert.AreEqual(2, result.GenerationSpec.TypeBuilders.Count);
            Assert.AreEqual(0, result.GenerationSpec.ReferencedContexts.Count);

            // Order should match the discovery order (first JsonModel, then JsonModel2).
            Assert.AreEqual("JsonModel", result.GenerationSpec.TypeBuilders[0].Type.Name);
            Assert.AreEqual("TestProject", result.GenerationSpec.TypeBuilders[0].Type.Namespace);
            Assert.AreEqual("JsonModel2", result.GenerationSpec.TypeBuilders[1].Type.Name);
            Assert.AreEqual("TestProject", result.GenerationSpec.TypeBuilders[1].Type.Namespace);
        }

        [Test]
        public void TwoPartialClassesShouldPass()
        {
            string source =
$$"""
using System;
using System.ClientModel.Primitives;
using System.Text.Json;

namespace TestProject
{
    [ModelReaderWriterBuildable(typeof(JsonModel))]
    public partial class LocalContext : ModelReaderWriterContext { }

    public class JsonModel : IJsonModel<JsonModel>
    {
        public JsonModel Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => new JsonModel();
        public JsonModel Create(BinaryData data, ModelReaderWriterOptions options) => new JsonModel();
        public string GetFormatFromOptions(ModelReaderWriterOptions options) => "J";
        public void Write(Utf8JsonWriter writer, ModelReaderWriterOptions options) { }
        public BinaryData Write(ModelReaderWriterOptions options) => BinaryData.Empty;
    }

    [ModelReaderWriterBuildable(typeof(JsonModel2))]
    public partial class LocalContext : ModelReaderWriterContext { }

    public class JsonModel2 : IJsonModel<JsonModel2>
    {
        public JsonModel2 Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => new JsonModel2();
        public JsonModel2 Create(BinaryData data, ModelReaderWriterOptions options) => new JsonModel2();
        public string GetFormatFromOptions(ModelReaderWriterOptions options) => "J";
        public void Write(Utf8JsonWriter writer, ModelReaderWriterOptions options) { }
        public BinaryData Write(ModelReaderWriterOptions options) => BinaryData.Empty;
    }
}
""";

            Compilation compilation = CompilationHelper.CreateCompilation(source);

            var result = CompilationHelper.RunSourceGenerator(compilation, out var newCompilation);

            Assert.IsNotNull(result.GenerationSpec);
            Assert.AreEqual("LocalContext", result.GenerationSpec!.Type.Name);
            Assert.AreEqual("TestProject", result.GenerationSpec.Type.Namespace);
            Assert.AreEqual(0, result.Diagnostics.Length);
            Assert.AreEqual("public", result.GenerationSpec!.Modifier);
            Assert.AreEqual(2, result.GenerationSpec.TypeBuilders.Count);
            Assert.AreEqual(0, result.GenerationSpec.ReferencedContexts.Count);
            Assert.AreEqual("JsonModel", result.GenerationSpec.TypeBuilders[0].Type.Name);
            Assert.AreEqual("TestProject", result.GenerationSpec.TypeBuilders[0].Type.Namespace);
            Assert.AreEqual("JsonModel2", result.GenerationSpec.TypeBuilders[1].Type.Name);
            Assert.AreEqual("TestProject", result.GenerationSpec.TypeBuilders[1].Type.Namespace);
        }

#if NET8_0_OR_GREATER
        [Test]
        public void ExperimentalModels()
        {
            string source =
"""
using System;
using System.ClientModel.Primitives;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;

namespace TestProject
{
#pragma warning disable TEST001 // Experimental type
  [ModelReaderWriterBuildable(typeof(JsonModel))]
#pragma warning restore TEST001 // Experimental type
#pragma warning disable TEST002 // Experimental type
  [ModelReaderWriterBuildable(typeof(OtherModel))]
#pragma warning restore TEST002 // Experimental type
  public partial class LocalContext : ModelReaderWriterContext { }

  [Experimental("TEST001")]
  public class JsonModel : IJsonModel<JsonModel>
  {
      JsonModel IJsonModel<JsonModel>.Create(ref System.Text.Json.Utf8JsonReader reader, ModelReaderWriterOptions options) => new JsonModel();
      JsonModel IPersistableModel<JsonModel>.Create(BinaryData data, ModelReaderWriterOptions options) => new JsonModel();
      string IPersistableModel<JsonModel>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";
      void IJsonModel<JsonModel>.Write(System.Text.Json.Utf8JsonWriter writer, ModelReaderWriterOptions options) { }
      BinaryData IPersistableModel<JsonModel>.Write(ModelReaderWriterOptions options) => BinaryData.Empty;
  }

  [Experimental("TEST002")]
  public class OtherModel : IJsonModel<OtherModel>
  {
      OtherModel IJsonModel<OtherModel>.Create(ref System.Text.Json.Utf8JsonReader reader, ModelReaderWriterOptions options) => new OtherModel();
      OtherModel IPersistableModel<OtherModel>.Create(BinaryData data, ModelReaderWriterOptions options) => new OtherModel();
      string IPersistableModel<OtherModel>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";
      void IJsonModel<OtherModel>.Write(System.Text.Json.Utf8JsonWriter writer, ModelReaderWriterOptions options) { }
      BinaryData IPersistableModel<OtherModel>.Write(ModelReaderWriterOptions options) => BinaryData.Empty;
  }
}
""";
            Compilation compilation = CompilationHelper.CreateCompilation(source);

            var result =
                CompilationHelper.RunSourceGenerator(compilation, out var newCompilation, out var generatedSources);
            Assert.IsNotNull(result.GenerationSpec);

            // Verify the new compilation still has warnings for direct usage but not for generated code
            var diagnostics = newCompilation.GetDiagnostics();
            var errors = diagnostics.Where(d => d.Severity == DiagnosticSeverity.Error).ToArray();
            Assert.AreEqual(0, errors.Length, "Compilation should not have errors");

            // Check for experimental warnings - should still have them for direct usage in TestUsage class
            var experimentalWarnings = diagnostics
                .Where(d => (d.Id == "TEST001" || d.Id == "TEST002") && !d.Location.IsInSource).ToArray();
            Assert.AreEqual(0, experimentalWarnings.Length, "Generated code should not produce experimental warnings");

            // Check the context file for pragma suppressions in the constructor
            var contextSource = generatedSources.First(s => s.HintName == "LocalContext.g.cs");
            var contextText = contextSource.SourceText.ToString().Split(['\r', '\n'], StringSplitOptions.RemoveEmptyEntries)
                .Select(line => line.Trim())
                .ToList();

            var startIndex = contextText.FindIndex(line => line.Contains("#pragma warning disable TEST001"));
            Assert.IsTrue(startIndex >= 0, "Could not find #pragma warning disable TEST001");

            Assert.IsTrue(startIndex + 2 < contextText.Count, "Not enough lines after pragma disable");
            StringAssert.Contains("_typeBuilderFactories.Add(typeof(global::TestProject.JsonModel)", contextText[startIndex + 1]);
            StringAssert.Contains("#pragma warning restore TEST001", contextText[startIndex + 2]);

            startIndex = contextText.FindIndex(line => line.Contains("#pragma warning disable TEST002"));
            Assert.IsTrue(startIndex >= 0, "Could not find #pragma warning disable TEST002");
            StringAssert.Contains("_typeBuilderFactories.Add(typeof(global::TestProject.OtherModel)", contextText[startIndex + 1]);
            StringAssert.Contains("#pragma warning restore TEST002", contextText[startIndex + 2]);

            // Also check the builder files
            var jsonModelBuilder = generatedSources.First(s => s.HintName.Contains("JsonModel_Builder"));
            var jsonModelText = jsonModelBuilder.SourceText.ToString();
            StringAssert.Contains("#pragma warning disable TEST001", jsonModelText);
            StringAssert.Contains("#pragma warning restore TEST001", jsonModelText);

            var otherModelBuilder = generatedSources.First(s => s.HintName.Contains("OtherModel_Builder"));
            var otherModelText = otherModelBuilder.SourceText.ToString();
            StringAssert.Contains("#pragma warning disable TEST002", otherModelText);
            StringAssert.Contains("#pragma warning restore TEST002", otherModelText);

            Assert.AreEqual(2, result.GenerationSpec!.TypeBuilders.Count);
            Assert.AreEqual("TEST001", result.GenerationSpec.TypeBuilders[0].Type.ExperimentalDiagnosticId);
            Assert.AreEqual("TEST002", result.GenerationSpec.TypeBuilders[1].Type.ExperimentalDiagnosticId);
        }

        [Test]
        public void ExperimentalAndRegularModels()
        {
            string source =
"""
using System;
using System.ClientModel.Primitives;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;

namespace TestProject
{
#pragma warning disable TEST001 // Experimental type
  [ModelReaderWriterBuildable(typeof(JsonModel))]
#pragma warning restore TEST001 // Experimental type
  [ModelReaderWriterBuildable(typeof(OtherModel))]
  public partial class LocalContext : ModelReaderWriterContext { }

  [Experimental("TEST001")]
  public class JsonModel : IJsonModel<JsonModel>
  {
      JsonModel IJsonModel<JsonModel>.Create(ref System.Text.Json.Utf8JsonReader reader, ModelReaderWriterOptions options) => new JsonModel();
      JsonModel IPersistableModel<JsonModel>.Create(BinaryData data, ModelReaderWriterOptions options) => new JsonModel();
      string IPersistableModel<JsonModel>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";
      void IJsonModel<JsonModel>.Write(System.Text.Json.Utf8JsonWriter writer, ModelReaderWriterOptions options) { }
      BinaryData IPersistableModel<JsonModel>.Write(ModelReaderWriterOptions options) => BinaryData.Empty;
  }

  public class OtherModel : IJsonModel<OtherModel>
  {
      OtherModel IJsonModel<OtherModel>.Create(ref System.Text.Json.Utf8JsonReader reader, ModelReaderWriterOptions options) => new OtherModel();
      OtherModel IPersistableModel<OtherModel>.Create(BinaryData data, ModelReaderWriterOptions options) => new OtherModel();
      string IPersistableModel<OtherModel>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";
      void IJsonModel<OtherModel>.Write(System.Text.Json.Utf8JsonWriter writer, ModelReaderWriterOptions options) { }
      BinaryData IPersistableModel<OtherModel>.Write(ModelReaderWriterOptions options) => BinaryData.Empty;
  }
}
""";
            Compilation compilation = CompilationHelper.CreateCompilation(source);

            var result =
                CompilationHelper.RunSourceGenerator(compilation, out var newCompilation, out var generatedSources);
            Assert.IsNotNull(result.GenerationSpec);

            // Verify the new compilation still has warnings for direct usage but not for generated code
            var diagnostics = newCompilation.GetDiagnostics();
            var errors = diagnostics.Where(d => d.Severity == DiagnosticSeverity.Error).ToArray();
            Assert.AreEqual(0, errors.Length, "Compilation should not have errors");

            // Check for experimental warnings - should still have them for direct usage in TestUsage class
            var experimentalWarnings = diagnostics
                .Where(d => (d.Id == "TEST001") && !d.Location.IsInSource).ToArray();
            Assert.AreEqual(0, experimentalWarnings.Length, "Generated code should not produce experimental warnings");

            // Check the context file for pragma suppressions in the constructor
            var contextSource = generatedSources.First(s => s.HintName == "LocalContext.g.cs");
            var contextText = contextSource.SourceText.ToString().Split(['\r', '\n'], StringSplitOptions.RemoveEmptyEntries)
                .Select(line => line.Trim())
                .ToList();

            var startIndex = contextText.FindIndex(line => line.Contains("#pragma warning disable TEST001"));
            Assert.IsTrue(startIndex >= 0, "Could not find #pragma warning disable TEST001");

            Assert.IsTrue(startIndex + 2 < contextText.Count, "Not enough lines after pragma disable");
            StringAssert.Contains("_typeBuilderFactories.Add(typeof(global::TestProject.JsonModel)", contextText[startIndex + 1]);
            StringAssert.Contains("#pragma warning restore TEST001", contextText[startIndex + 2]);

            // Also check the builder files
            var jsonModelBuilder = generatedSources.First(s => s.HintName.Contains("JsonModel_Builder"));
            var jsonModelText = jsonModelBuilder.SourceText.ToString();
            StringAssert.Contains("#pragma warning disable TEST001", jsonModelText);
            StringAssert.Contains("#pragma warning restore TEST001", jsonModelText);

            var otherModelBuilder = generatedSources.First(s => s.HintName.Contains("OtherModel_Builder"));
            var otherModelText = otherModelBuilder.SourceText.ToString();
            StringAssert.DoesNotContain("#pragma warning disable", otherModelText);
            StringAssert.DoesNotContain("#pragma warning restore", otherModelText);

            Assert.AreEqual(2, result.GenerationSpec!.TypeBuilders.Count);
            Assert.AreEqual("TEST001", result.GenerationSpec.TypeBuilders[0].Type.ExperimentalDiagnosticId);
            Assert.IsNull(result.GenerationSpec.TypeBuilders[1].Type.ExperimentalDiagnosticId);
        }

        [Test]
        public void ExperimentalAndObsoleteModels()
        {
            string source =
$$"""
  using System;
  using System.ClientModel.Primitives;
  using System.Diagnostics.CodeAnalysis;
  using System.Text.Json;

  namespace TestProject
  {
  #pragma warning disable TEST001 // Experimental type
    [ModelReaderWriterBuildable(typeof(JsonModel))]
  #pragma warning restore TEST001 // Experimental type
  #pragma warning disable CS0618 // Type or member is obsolete
    [ModelReaderWriterBuildable(typeof(OtherModel))]
  #pragma warning restore CS0618 // Type or member is obsolete
    public partial class LocalContext : ModelReaderWriterContext { }

    [Experimental("TEST001")]
    public class JsonModel : IJsonModel<JsonModel>
    {
        JsonModel IJsonModel<JsonModel>.Create(ref System.Text.Json.Utf8JsonReader reader, ModelReaderWriterOptions options) => new JsonModel();
        JsonModel IPersistableModel<JsonModel>.Create(BinaryData data, ModelReaderWriterOptions options) => new JsonModel();
        string IPersistableModel<JsonModel>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";
        void IJsonModel<JsonModel>.Write(System.Text.Json.Utf8JsonWriter writer, ModelReaderWriterOptions options) { }
        BinaryData IPersistableModel<JsonModel>.Write(ModelReaderWriterOptions options) => BinaryData.Empty;
    }

    [Obsolete("This is obsolete")]
    public class OtherModel : IJsonModel<OtherModel>
    {
        OtherModel IJsonModel<OtherModel>.Create(ref System.Text.Json.Utf8JsonReader reader, ModelReaderWriterOptions options) => new OtherModel();
        OtherModel IPersistableModel<OtherModel>.Create(BinaryData data, ModelReaderWriterOptions options) => new OtherModel();
        string IPersistableModel<OtherModel>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";
        void IJsonModel<OtherModel>.Write(System.Text.Json.Utf8JsonWriter writer, ModelReaderWriterOptions options) { }
        BinaryData IPersistableModel<OtherModel>.Write(ModelReaderWriterOptions options) => BinaryData.Empty;
    }
}
""";
            Compilation compilation = CompilationHelper.CreateCompilation(source);

            var result =
                CompilationHelper.RunSourceGenerator(compilation, out var newCompilation, out var generatedSources);
            Assert.IsNotNull(result.GenerationSpec);

            // Verify the new compilation still has warnings for direct usage but not for generated code
            var diagnostics = newCompilation.GetDiagnostics();
            var errors = diagnostics.Where(d => d.Severity == DiagnosticSeverity.Error).ToArray();
            Assert.AreEqual(0, errors.Length, "Compilation should not have errors");

            // Check for experimental warnings - should still have them for direct usage in TestUsage class
            var experimentalWarnings = diagnostics
                .Where(d => (d.Id == "TEST001") && !d.Location.IsInSource).ToArray();
            Assert.AreEqual(0, experimentalWarnings.Length, "Generated code should not produce experimental warnings");

            // Check the context file for pragma suppressions in the constructor
            var contextSource = generatedSources.First(s => s.HintName == "LocalContext.g.cs");
            var contextText = contextSource.SourceText.ToString().Split(['\r', '\n'], StringSplitOptions.RemoveEmptyEntries)
                .Select(line => line.Trim())
                .ToList();

            var startIndex = contextText.FindIndex(line => line.Contains("#pragma warning disable TEST001"));
            Assert.IsTrue(startIndex >= 0, "Could not find #pragma warning disable TEST001");

            Assert.IsTrue(startIndex + 2 < contextText.Count, "Not enough lines after pragma disable");
            StringAssert.Contains("_typeBuilderFactories.Add(typeof(global::TestProject.JsonModel)", contextText[startIndex + 1]);
            StringAssert.Contains("#pragma warning restore TEST001", contextText[startIndex + 2]);

            // Also check the builder files
            var jsonModelBuilder = generatedSources.First(s => s.HintName.Contains("JsonModel_Builder"));
            var jsonModelText = jsonModelBuilder.SourceText.ToString();
            StringAssert.Contains("#pragma warning disable TEST001", jsonModelText);
            StringAssert.Contains("#pragma warning restore TEST001", jsonModelText);

            var otherModelBuilder = generatedSources.First(s => s.HintName.Contains("OtherModel_Builder"));
            var otherModelText = otherModelBuilder.SourceText.ToString();
            StringAssert.Contains("#pragma warning disable CS0618", otherModelText);
            StringAssert.Contains("#pragma warning restore CS0618", otherModelText);

            Assert.AreEqual(2, result.GenerationSpec!.TypeBuilders.Count);
            Assert.AreEqual("TEST001", result.GenerationSpec.TypeBuilders[0].Type.ExperimentalDiagnosticId);
            Assert.IsNull(result.GenerationSpec.TypeBuilders[1].Type.ExperimentalDiagnosticId);

            Assert.AreEqual(ObsoleteLevel.Warning, result.GenerationSpec.TypeBuilders[1].Type.ObsoleteLevel);
        }

        [Test]
        public void DepWithExperimentalModel()
        {
            string depSource =
$$"""
  using System;
  using System.ClientModel.Primitives;
  using System.Diagnostics.CodeAnalysis;
  using System.Text.Json;

  namespace TestDependency
  {
  #pragma warning disable TEST001 // Experimental type
      [ModelReaderWriterBuildable(typeof(JsonModel))]
  #pragma warning restore TEST001 // Experimental type
      public partial class LocalContext : ModelReaderWriterContext { }

      [Experimental("TEST001")]
      public class JsonModel : IJsonModel<JsonModel>
      {
          JsonModel IJsonModel<JsonModel>.Create(ref System.Text.Json.Utf8JsonReader reader, ModelReaderWriterOptions options) => new JsonModel();
          JsonModel IPersistableModel<JsonModel>.Create(BinaryData data, ModelReaderWriterOptions options) => new JsonModel();
          string IPersistableModel<JsonModel>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";
          void IJsonModel<JsonModel>.Write(System.Text.Json.Utf8JsonWriter writer, ModelReaderWriterOptions options) { }
          BinaryData IPersistableModel<JsonModel>.Write(ModelReaderWriterOptions options) => BinaryData.Empty;
      }
  }
  """;

            Compilation depCompilation = CompilationHelper.CreateCompilation(depSource, assemblyName: "TestDependency");
            // The dependency compilation should not have experimental warnings
            var depResult = CompilationHelper.RunSourceGenerator(depCompilation, out var newDepCompilation);

            Assert.IsNotNull(depResult.GenerationSpec);
            Assert.AreEqual("LocalContext", depResult.GenerationSpec!.Type.Name);
            Assert.AreEqual("TestDependency", depResult.GenerationSpec.Type.Namespace);
            Assert.AreEqual(0, depResult.Diagnostics.Length);
            Assert.AreEqual("public", depResult.GenerationSpec!.Modifier);
            Assert.AreEqual(1, depResult.GenerationSpec.TypeBuilders.Count);

            string source =
$$"""
  using System;
  using System.ClientModel.Primitives;
  using TestDependency;

  namespace TestProject
  {
  #pragma warning disable TEST001 // Experimental type
      [ModelReaderWriterBuildable(typeof(JsonModel))]
  #pragma warning restore TEST001 // Experimental type
      public partial class MyLocalContext : ModelReaderWriterContext { }

      public class Caller
      {
          public void Call()
          {
  #pragma warning disable TEST001 // Experimental type
              ModelReaderWriter.Read<JsonModel>(BinaryData.Empty, ModelReaderWriterOptions.Json, MyLocalContext.Default);
  #pragma warning restore TEST001 // Experimental type
          }
      }
  }
  """;

            Compilation compilation = CompilationHelper.CreateCompilation(
                source,
                additionalReferences: [newDepCompilation.ToMetadataReference()],
                contextName: "MyLocalContext");

            var result = CompilationHelper.RunSourceGenerator(compilation, out var newCompilation);

            Assert.IsNotNull(result.GenerationSpec);
            Assert.AreEqual("MyLocalContext", result.GenerationSpec!.Type.Name);
            Assert.AreEqual("TestProject", result.GenerationSpec.Type.Namespace);
            Assert.AreEqual(0, result.Diagnostics.Length);
            Assert.AreEqual("public", result.GenerationSpec!.Modifier);
            Assert.AreEqual(1, result.GenerationSpec.TypeBuilders.Count);
            Assert.AreEqual(1, result.GenerationSpec.ReferencedContexts.Count);

            var myLocalContext = newCompilation.GetTypeByMetadataName("TestProject.MyLocalContext");
            Assert.IsNotNull(myLocalContext, "MyLocalContext should not be null.");

            var referenceContextFiled = myLocalContext!.GetMembers("s_referenceContexts")
                .OfType<IFieldSymbol>()
                .FirstOrDefault(f => f.IsStatic);
            Assert.IsNotNull(referenceContextFiled, "s_referenceContexts field should not be null.");
        }

        [TestCase("JsonModel[]")]
        [TestCase("List<JsonModel>")]
        [TestCase("Dictionary<string, JsonModel>")]
        [TestCase("ReadOnlyMemory<JsonModel>")]
        [TestCase("JsonModel[][]")]
        [TestCase("JsonModel[,]")]
        public void BuilderForExperimentalCollectionHasSuppression(string collectionType)
        {
            string source =
$$"""
  using System;
  using System.ClientModel.Primitives;
  using System.Collections.Generic;
  using System.Text.Json;
  using System.Diagnostics.CodeAnalysis;

  namespace TestProject
  {
  #pragma warning disable TEST001 // Type or member is experimental
      [ModelReaderWriterBuildable(typeof({{collectionType}}))]
  #pragma warning restore TEST001 // Type or member is experimental
      public partial class LocalContext : ModelReaderWriterContext { }

      [Experimental("TEST001")]
      public class JsonModel : IJsonModel<JsonModel>
      {
          JsonModel IJsonModel<JsonModel>.Create(ref System.Text.Json.Utf8JsonReader reader, ModelReaderWriterOptions options) => new JsonModel();
          JsonModel IPersistableModel<JsonModel>.Create(BinaryData data, ModelReaderWriterOptions options) => new JsonModel();
          string IPersistableModel<JsonModel>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";
          void IJsonModel<JsonModel>.Write(System.Text.Json.Utf8JsonWriter writer, ModelReaderWriterOptions options) { }
          BinaryData IPersistableModel<JsonModel>.Write(ModelReaderWriterOptions options) => BinaryData.Empty;
      }

      public class Caller
      {
          public void Call()
          {
  #pragma warning disable TEST001 // Type or member is experimental
              ModelReaderWriter.Read<{{collectionType}}>(BinaryData.Empty, ModelReaderWriterOptions.Json, LocalContext.Default);
  #pragma warning restore TEST001 // Type or member is experimental
          }
      }
  }
  """;

            Compilation compilation = CompilationHelper.CreateCompilation(
                source);

            var result = CompilationHelper.RunSourceGenerator(
                compilation,
                out var newCompilation,
                out var generatedSources);

            Assert.IsNotNull(result.GenerationSpec);
            Assert.AreEqual("LocalContext", result.GenerationSpec!.Type.Name);
            Assert.AreEqual("TestProject", result.GenerationSpec.Type.Namespace);
            Assert.AreEqual(0, result.Diagnostics.Length);
            Assert.AreEqual("public", result.GenerationSpec!.Modifier);
            Assert.AreEqual(collectionType == "JsonModel[][]" ? 3 : 2,
                result.GenerationSpec.TypeBuilders.Count);
            Assert.AreEqual(0, result.GenerationSpec.ReferencedContexts.Count);

            var dict = result.GenerationSpec.TypeBuilders.ToDictionary(t => t.Type.Name, t => t);

            Assert.IsTrue(dict.TryGetValue("JsonModel", out var jsonModelBuilder));
            Assert.AreEqual("JsonModel", jsonModelBuilder!.Type.Name);
            Assert.AreEqual("TestProject", jsonModelBuilder.Type.Namespace);
            Assert.AreEqual("internal", jsonModelBuilder.Modifier);
            Assert.AreEqual(ObsoleteLevel.None, jsonModelBuilder.Type.ObsoleteLevel);
            Assert.AreEqual("TEST001", jsonModelBuilder.Type.ExperimentalDiagnosticId);

            Assert.IsTrue(dict.TryGetValue(collectionType, out var collectionBuilder));
            Assert.AreEqual(collectionType, collectionBuilder!.Type.Name);
            if (collectionType == "JsonModel[]" || collectionType == "JsonModel[,]" ||
                collectionType == "JsonModel[][]")
            {
                Assert.AreEqual("TestProject", collectionBuilder.Type.Namespace);
            }
            else if (collectionType == "ReadOnlyMemory<JsonModel>")
            {
                Assert.AreEqual("System", collectionBuilder.Type.Namespace);
            }
            else
            {
                Assert.AreEqual("System.Collections.Generic", collectionBuilder.Type.Namespace);
            }

            Assert.AreEqual("internal", collectionBuilder.Modifier);
            Assert.AreEqual(ObsoleteLevel.None, collectionBuilder.Type.ObsoleteLevel);
            Assert.AreEqual("TEST001", collectionBuilder.Type.ExperimentalDiagnosticId);
            if (collectionType == "JsonModel[][]")
            {
                Assert.AreEqual("JsonModel[]", collectionBuilder.Type.ItemType!.Name);
                Assert.AreEqual("TestProject", collectionBuilder.Type.ItemType!.Namespace);

                Assert.IsTrue(dict.TryGetValue("JsonModel[]", out var jsonModelArrayBuilder));
                Assert.AreEqual("JsonModel[]", jsonModelArrayBuilder!.Type.Name);
                Assert.AreEqual("TestProject", jsonModelArrayBuilder.Type.Namespace);
                Assert.AreEqual("internal", jsonModelArrayBuilder.Modifier);
                Assert.AreEqual("TEST001", jsonModelArrayBuilder.Type.ExperimentalDiagnosticId);

                Assert.AreEqual("JsonModel", jsonModelArrayBuilder.Type.ItemType!.Name);
                Assert.AreEqual("TestProject", jsonModelArrayBuilder.Type.ItemType!.Namespace);
                Assert.AreEqual("TEST001", jsonModelArrayBuilder.Type.ExperimentalDiagnosticId);
            }
            else
            {
                Assert.AreEqual("JsonModel", collectionBuilder.Type.ItemType!.Name);
                Assert.AreEqual("TestProject", collectionBuilder.Type.ItemType!.Namespace);
                Assert.AreEqual("TEST001", collectionBuilder.Type.ExperimentalDiagnosticId);
            }

            // Also check the builder files
            var builders = generatedSources.Where(s => s.HintName.EndsWith("Builder.g.cs"));
            Assert.IsNotEmpty(builders);
            foreach (var builder in builders)
            {
                var builderText = builder.SourceText.ToString();
                StringAssert.Contains("#pragma warning disable TEST001", builderText);
                StringAssert.Contains("#pragma warning restore TEST001", builderText);
            }
        }
#endif
    }
}
